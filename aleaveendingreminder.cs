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
   public class aleaveendingreminder : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aleaveendingreminder( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aleaveendingreminder( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15Subject = "Leave ending Reminder";
         /* Using cursor P005X2 */
         pr_default.execute(0, new Object[] {Gx_date});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P005X2_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P005X2_A132LeaveRequestStatus[0];
            A130LeaveRequestEndDate = P005X2_A130LeaveRequestEndDate[0];
            A125LeaveTypeName = P005X2_A125LeaveTypeName[0];
            A107EmployeeFirstName = P005X2_A107EmployeeFirstName[0];
            A109EmployeeEmail = P005X2_A109EmployeeEmail[0];
            A106EmployeeId = P005X2_A106EmployeeId[0];
            A127LeaveRequestId = P005X2_A127LeaveRequestId[0];
            A125LeaveTypeName = P005X2_A125LeaveTypeName[0];
            A107EmployeeFirstName = P005X2_A107EmployeeFirstName[0];
            A109EmployeeEmail = P005X2_A109EmployeeEmail[0];
            AV16LeaveTypeName = A125LeaveTypeName;
            AV12name = A107EmployeeFirstName;
            AV9email = A109EmployeeEmail;
            AV8Body = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Ending Reminder</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV12name + ",</p><p>This is a reminder that your leave (" + AV16LeaveTypeName + ") is ending today. Please ensure all necessary arrangements are made.</p><p>We appreciate your attention to this matter.</p><p>Best regards,</p></div></div>";
            new sendemail(context ).execute(  AV9email, ref  AV15Subject, ref  AV8Body) ;
            new sdsendpushnotifications(context ).execute(  "Leave Reminder:",  "This is a reminder that your leave ("+AV16LeaveTypeName+") is ending today.",  A106EmployeeId) ;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV15Subject = "";
         Gx_date = DateTime.MinValue;
         P005X2_A124LeaveTypeId = new long[1] ;
         P005X2_A132LeaveRequestStatus = new string[] {""} ;
         P005X2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P005X2_A125LeaveTypeName = new string[] {""} ;
         P005X2_A107EmployeeFirstName = new string[] {""} ;
         P005X2_A109EmployeeEmail = new string[] {""} ;
         P005X2_A106EmployeeId = new long[1] ;
         P005X2_A127LeaveRequestId = new long[1] ;
         A132LeaveRequestStatus = "";
         A130LeaveRequestEndDate = DateTime.MinValue;
         A125LeaveTypeName = "";
         A107EmployeeFirstName = "";
         A109EmployeeEmail = "";
         AV16LeaveTypeName = "";
         AV12name = "";
         AV9email = "";
         AV8Body = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aleaveendingreminder__default(),
            new Object[][] {
                new Object[] {
               P005X2_A124LeaveTypeId, P005X2_A132LeaveRequestStatus, P005X2_A130LeaveRequestEndDate, P005X2_A125LeaveTypeName, P005X2_A107EmployeeFirstName, P005X2_A109EmployeeEmail, P005X2_A106EmployeeId, P005X2_A127LeaveRequestId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15Subject ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private string A107EmployeeFirstName ;
      private string AV16LeaveTypeName ;
      private string AV12name ;
      private DateTime Gx_date ;
      private DateTime A130LeaveRequestEndDate ;
      private bool entryPointCalled ;
      private string AV8Body ;
      private string A109EmployeeEmail ;
      private string AV9email ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005X2_A124LeaveTypeId ;
      private string[] P005X2_A132LeaveRequestStatus ;
      private DateTime[] P005X2_A130LeaveRequestEndDate ;
      private string[] P005X2_A125LeaveTypeName ;
      private string[] P005X2_A107EmployeeFirstName ;
      private string[] P005X2_A109EmployeeEmail ;
      private long[] P005X2_A106EmployeeId ;
      private long[] P005X2_A127LeaveRequestId ;
   }

   public class aleaveendingreminder__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005X2;
          prmP005X2 = new Object[] {
          new ParDef("Gx_date",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005X2", "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T1.LeaveRequestEndDate, T2.LeaveTypeName, T3.EmployeeFirstName, T3.EmployeeEmail, T1.EmployeeId, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) WHERE (T1.LeaveRequestEndDate = :Gx_date) AND (T1.LeaveRequestStatus = ( 'Approved')) ORDER BY T1.LeaveRequestId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
