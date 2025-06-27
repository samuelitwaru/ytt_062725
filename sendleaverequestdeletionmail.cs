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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class sendleaverequestdeletionmail : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public sendleaverequestdeletionmail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sendleaverequestdeletionmail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_LeaveRequestId )
      {
         this.AV12LeaveRequestId = aP0_LeaveRequestId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_LeaveRequestId )
      {
         this.AV12LeaveRequestId = aP0_LeaveRequestId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new getloggedinuser(context ).execute( out  AV9GAMUser, out  AV8Employee) ;
         AV10LeaveRequest.Load(AV12LeaveRequestId);
         /* Using cursor P008I2 */
         pr_default.execute(0, new Object[] {AV8Employee.gxTpr_Companyid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112EmployeeIsActive = P008I2_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P008I2_A110EmployeeIsManager[0];
            A100CompanyId = P008I2_A100CompanyId[0];
            A109EmployeeEmail = P008I2_A109EmployeeEmail[0];
            A106EmployeeId = P008I2_A106EmployeeId[0];
            AV13ManagerEmail = A109EmployeeEmail;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV15Subject = " Leave Request Deletion ";
         AV11Body = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2></h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear Manager,</p><p>This is to inform you that the leave request for <b>" + AV8Employee.gxTpr_Employeename + "</b> has been deleted</p><p><h3>Leave Details:</h3></p><p>Start Date: <b>" + context.localUtil.DToC( AV10LeaveRequest.gxTpr_Leaverequeststartdate, 2, "/") + "</b></p><p>End Date: <b>" + context.localUtil.DToC( AV10LeaveRequest.gxTpr_Leaverequestenddate, 2, "/") + "</b></p><p>Description: <b>" + AV10LeaveRequest.gxTpr_Leaverequestdescription + "</b></p><p>Thank you for your attention to this matter</p><p>Best regards,</p><p><b>Yukon Time Tracker Team<b></div></div>";
         new sendemail(context ).execute(  AV13ManagerEmail, ref  AV15Subject, ref  AV11Body) ;
         AV14NotificationText = AV8Employee.gxTpr_Employeename + " has deleted a leave request.";
         new sdsendpushnotifications(context ).execute(  "Leave Request",  AV14NotificationText,  0) ;
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
         AV9GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV8Employee = new SdtEmployee(context);
         AV10LeaveRequest = new SdtLeaveRequest(context);
         P008I2_A112EmployeeIsActive = new bool[] {false} ;
         P008I2_A110EmployeeIsManager = new bool[] {false} ;
         P008I2_A100CompanyId = new long[1] ;
         P008I2_A109EmployeeEmail = new string[] {""} ;
         P008I2_A106EmployeeId = new long[1] ;
         A109EmployeeEmail = "";
         AV13ManagerEmail = "";
         AV15Subject = "";
         AV11Body = "";
         AV14NotificationText = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sendleaverequestdeletionmail__default(),
            new Object[][] {
                new Object[] {
               P008I2_A112EmployeeIsActive, P008I2_A110EmployeeIsManager, P008I2_A100CompanyId, P008I2_A109EmployeeEmail, P008I2_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV12LeaveRequestId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private bool A112EmployeeIsActive ;
      private bool A110EmployeeIsManager ;
      private string AV11Body ;
      private string A109EmployeeEmail ;
      private string AV13ManagerEmail ;
      private string AV15Subject ;
      private string AV14NotificationText ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9GAMUser ;
      private SdtEmployee AV8Employee ;
      private SdtLeaveRequest AV10LeaveRequest ;
      private IDataStoreProvider pr_default ;
      private bool[] P008I2_A112EmployeeIsActive ;
      private bool[] P008I2_A110EmployeeIsManager ;
      private long[] P008I2_A100CompanyId ;
      private string[] P008I2_A109EmployeeEmail ;
      private long[] P008I2_A106EmployeeId ;
   }

   public class sendleaverequestdeletionmail__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008I2;
          prmP008I2 = new Object[] {
          new ParDef("AV8Employee__Companyid",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008I2", "SELECT EmployeeIsActive, EmployeeIsManager, CompanyId, EmployeeEmail, EmployeeId FROM Employee WHERE (CompanyId = :AV8Employee__Companyid) AND (EmployeeIsManager = TRUE) AND (EmployeeIsActive = TRUE) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
