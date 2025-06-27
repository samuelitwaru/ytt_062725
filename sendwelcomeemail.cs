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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class sendwelcomeemail : GXProcedure
   {
      public sendwelcomeemail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sendwelcomeemail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           string aP1_Password ,
                           out string aP2_successMessage )
      {
         this.A106EmployeeId = aP0_EmployeeId;
         this.AV12Password = aP1_Password;
         this.AV20successMessage = "" ;
         initialize();
         ExecuteImpl();
         aP2_successMessage=this.AV20successMessage;
      }

      public string executeUdp( long aP0_EmployeeId ,
                                string aP1_Password )
      {
         execute(aP0_EmployeeId, aP1_Password, out aP2_successMessage);
         return AV20successMessage ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 string aP1_Password ,
                                 out string aP2_successMessage )
      {
         this.A106EmployeeId = aP0_EmployeeId;
         this.AV12Password = aP1_Password;
         this.AV20successMessage = "" ;
         SubmitImpl();
         aP2_successMessage=this.AV20successMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV18Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV18Repository.gxTpr_Useractivationmethod, "U") == 0 )
         {
            AV8Employee.Load(A106EmployeeId);
            AV19User.load( AV8Employee.gxTpr_Gamuserguid);
            AV17ActivactionKey = AV19User.getnewactivationkey(out  AV16Errors);
            AV19User.save();
            context.CommitDataStores("sendwelcomeemail",pr_default);
            AV13SMTPSession.Host = "timetracker.yukon.software";
            AV13SMTPSession.Port = 465;
            AV13SMTPSession.Authentication = 0;
            AV13SMTPSession.AuthenticationMethod = "";
            AV13SMTPSession.UserName = "redfu@timetracker.yukon.software";
            AV13SMTPSession.Password = "3Vzo5oOFuxkquz+e";
            AV13SMTPSession.Secure = 1;
            AV13SMTPSession.Sender.Address = "noreply@timetracker.yukon.software";
            AV13SMTPSession.Sender.Name = "Yukon Time Tracker";
            AV10MailRecipient.Address = AV8Employee.gxTpr_Employeeemail;
            AV10MailRecipient.Name = AV8Employee.gxTpr_Employeename;
            AV9MailMessage.Subject = "Invitation to the Yukon Time Tracker";
            AV9MailMessage.HTMLText = "<div style=\"max-width: 600px; margin: 0 auto; font-family: Arial, sans-serif; border: 1px solid #e0e0e0; padding: 20px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);\">"+"<div style=\"background-color: #333; color: #ffffff; text-align: center; padding: 20px 0;\"><h2>Yukon Time Tracker</h2></div><div style=\"padding: 20px; line-height: 1.5;\"><p>Dear "+AV8Employee.gxTpr_Employeename+",</p><p>Welcome to Yukon Time Tracker! We are thrilled to have you on board.</p><p>To get started, we need to verify your email address. Please click the button below to confirm your email and complete the onboarding process:</p>"+"</b></p><a href=\""+AV21HttpRequest.BaseURL+"emailverify.aspx?ActivationKey="+AV17ActivactionKey+"&GamGuid="+AV8Employee.gxTpr_Gamuserguid+"\" style=\"display: block; padding: 10px 20px; width: 150px;  margin: 20px auto; background-color: #FFCC00; text-align: center; border-radius: 8px; color: white; font-weight: bold; line-height: 30px; text-decoration: none;\">Confirm Email</a>"+"<p>Please note that the link expires in 36 hours.</p>"+"<p>Once you have verified your email, you will gain access to our web panel where you can complete your profile and start using Yukon TimeTracker.</p>"+"<br><p>Empower customer’s success!</p><br><p>Yukon Software</p></div></div>";
            AV9MailMessage.To.Add(AV10MailRecipient);
            AV13SMTPSession.Login();
            if ( AV13SMTPSession.ErrCode == 0 )
            {
               AV13SMTPSession.Send(AV9MailMessage);
               AV13SMTPSession.Logout();
               AV20successMessage = "Invitation sent successfully";
            }
            else
            {
               GX_msglist.addItem(AV13SMTPSession.ErrDescription);
            }
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
         AV20successMessage = "";
         AV18Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV8Employee = new SdtEmployee(context);
         AV19User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV17ActivactionKey = "";
         AV16Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV10MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV9MailMessage = new GeneXus.Mail.GXMailMessage();
         AV21HttpRequest = new GxHttpRequest( context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.sendwelcomeemail__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sendwelcomeemail__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private long A106EmployeeId ;
      private string AV12Password ;
      private string AV17ActivactionKey ;
      private string AV20successMessage ;
      private GxHttpRequest AV21HttpRequest ;
      private GeneXus.Mail.GXMailMessage AV9MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV10MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV13SMTPSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV18Repository ;
      private SdtEmployee AV8Employee ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV19User ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV16Errors ;
      private IDataStoreProvider pr_default ;
      private string aP2_successMessage ;
      private IDataStoreProvider pr_gam ;
   }

   public class sendwelcomeemail__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class sendwelcomeemail__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
