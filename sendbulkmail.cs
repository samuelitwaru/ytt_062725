using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class sendbulkmail : GXProcedure
   {
      public sendbulkmail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sendbulkmail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GxSimpleCollection<string> aP0_emails ,
                           ref string aP1_Subject ,
                           ref string aP2_Body )
      {
         this.AV17emails = aP0_emails;
         this.AV12Subject = aP1_Subject;
         this.AV8Body = aP2_Body;
         initialize();
         ExecuteImpl();
         aP1_Subject=this.AV12Subject;
         aP2_Body=this.AV8Body;
      }

      public string executeUdp( GxSimpleCollection<string> aP0_emails ,
                                ref string aP1_Subject )
      {
         execute(aP0_emails, ref aP1_Subject, ref aP2_Body);
         return AV8Body ;
      }

      public void executeSubmit( GxSimpleCollection<string> aP0_emails ,
                                 ref string aP1_Subject ,
                                 ref string aP2_Body )
      {
         this.AV17emails = aP0_emails;
         this.AV12Subject = aP1_Subject;
         this.AV8Body = aP2_Body;
         SubmitImpl();
         aP1_Subject=this.AV12Subject;
         aP2_Body=this.AV8Body;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SMTPSession.Host = "timetracker.yukon.software";
         AV11SMTPSession.Port = 465;
         AV11SMTPSession.Authentication = 0;
         AV11SMTPSession.AuthenticationMethod = "";
         AV11SMTPSession.UserName = "redfu@timetracker.yukon.software";
         AV11SMTPSession.Password = "3Vzo5oOFuxkquz+e";
         AV11SMTPSession.Secure = 1;
         AV11SMTPSession.Sender.Address = "noreply@timetracker.yukon.software";
         AV11SMTPSession.Sender.Name = "Yukon Time Tracker";
         AV10MailRecipient.Address = AV13email;
         AV10MailRecipient.Name = AV14name;
         AV9MailMessage.Subject = AV12Subject;
         AV9MailMessage.HTMLText = AV8Body;
         if ( StringUtil.Contains( AV12Subject, "approved") || StringUtil.Contains( AV12Subject, "rejected") )
         {
            /* Using cursor P009U2 */
            pr_default.execute(0, new Object[] {AV13email});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A109EmployeeEmail = P009U2_A109EmployeeEmail[0];
               A100CompanyId = P009U2_A100CompanyId[0];
               A106EmployeeId = P009U2_A106EmployeeId[0];
               AV16EmployeeCompanyId = A100CompanyId;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P009U3 */
            pr_default.execute(1, new Object[] {AV16EmployeeCompanyId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A112EmployeeIsActive = P009U3_A112EmployeeIsActive[0];
               A110EmployeeIsManager = P009U3_A110EmployeeIsManager[0];
               A100CompanyId = P009U3_A100CompanyId[0];
               A109EmployeeEmail = P009U3_A109EmployeeEmail[0];
               A148EmployeeName = P009U3_A148EmployeeName[0];
               A106EmployeeId = P009U3_A106EmployeeId[0];
               AV15ReplyMailRecipient.Address = A109EmployeeEmail;
               AV15ReplyMailRecipient.Name = A148EmployeeName;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV9MailMessage.ReplyTo.Add(AV15ReplyMailRecipient);
         }
         AV21GXV1 = 1;
         while ( AV21GXV1 <= AV17emails.Count )
         {
            AV13email = ((string)AV17emails.Item(AV21GXV1));
            AV10MailRecipient.Address = AV13email;
            AV10MailRecipient.Name = AV14name;
            AV9MailMessage.To.Add(AV10MailRecipient);
            AV21GXV1 = (int)(AV21GXV1+1);
         }
         AV11SMTPSession.Login();
         if ( AV11SMTPSession.ErrCode == 0 )
         {
            AV11SMTPSession.Send(AV9MailMessage);
            AV11SMTPSession.Logout();
         }
         else
         {
            GX_msglist.addItem(AV11SMTPSession.ErrDescription);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV10MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV13email = "";
         AV14name = "";
         AV9MailMessage = new GeneXus.Mail.GXMailMessage();
         P009U2_A109EmployeeEmail = new string[] {""} ;
         P009U2_A100CompanyId = new long[1] ;
         P009U2_A106EmployeeId = new long[1] ;
         A109EmployeeEmail = "";
         P009U3_A112EmployeeIsActive = new bool[] {false} ;
         P009U3_A110EmployeeIsManager = new bool[] {false} ;
         P009U3_A100CompanyId = new long[1] ;
         P009U3_A109EmployeeEmail = new string[] {""} ;
         P009U3_A148EmployeeName = new string[] {""} ;
         P009U3_A106EmployeeId = new long[1] ;
         A148EmployeeName = "";
         AV15ReplyMailRecipient = new GeneXus.Mail.GXMailRecipient();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sendbulkmail__default(),
            new Object[][] {
                new Object[] {
               P009U2_A109EmployeeEmail, P009U2_A100CompanyId, P009U2_A106EmployeeId
               }
               , new Object[] {
               P009U3_A112EmployeeIsActive, P009U3_A110EmployeeIsManager, P009U3_A100CompanyId, P009U3_A109EmployeeEmail, P009U3_A148EmployeeName, P009U3_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV21GXV1 ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long AV16EmployeeCompanyId ;
      private string AV12Subject ;
      private string AV14name ;
      private string A148EmployeeName ;
      private bool A112EmployeeIsActive ;
      private bool A110EmployeeIsManager ;
      private string AV8Body ;
      private string AV13email ;
      private string A109EmployeeEmail ;
      private GeneXus.Mail.GXMailMessage AV9MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV10MailRecipient ;
      private GeneXus.Mail.GXMailRecipient AV15ReplyMailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV11SMTPSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV17emails ;
      private string aP1_Subject ;
      private string aP2_Body ;
      private IDataStoreProvider pr_default ;
      private string[] P009U2_A109EmployeeEmail ;
      private long[] P009U2_A100CompanyId ;
      private long[] P009U2_A106EmployeeId ;
      private bool[] P009U3_A112EmployeeIsActive ;
      private bool[] P009U3_A110EmployeeIsManager ;
      private long[] P009U3_A100CompanyId ;
      private string[] P009U3_A109EmployeeEmail ;
      private string[] P009U3_A148EmployeeName ;
      private long[] P009U3_A106EmployeeId ;
   }

   public class sendbulkmail__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009U2;
          prmP009U2 = new Object[] {
          new ParDef("AV13email",GXType.VarChar,100,0)
          };
          Object[] prmP009U3;
          prmP009U3 = new Object[] {
          new ParDef("AV16EmployeeCompanyId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009U2", "SELECT EmployeeEmail, CompanyId, EmployeeId FROM Employee WHERE EmployeeEmail = ( :AV13email) ORDER BY EmployeeEmail ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009U2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009U3", "SELECT EmployeeIsActive, EmployeeIsManager, CompanyId, EmployeeEmail, EmployeeName, EmployeeId FROM Employee WHERE (CompanyId = :AV16EmployeeCompanyId) AND (EmployeeIsManager = TRUE) AND (EmployeeIsActive = TRUE) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009U3,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
