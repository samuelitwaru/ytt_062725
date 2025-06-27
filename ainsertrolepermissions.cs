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
   public class ainsertrolepermissions : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new ainsertrolepermissions().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public ainsertrolepermissions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ainsertrolepermissions( IGxContext context )
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
         AV21ManagerPerms = "downloadapp_Execute,employee_dataprovider_Execute,employee_Delete,employee_Execute,employee_FullControl,employeehasprojectcopy1_Execute,employee_Insert,employee_Services_Execute,employee_Update,employeeview_Execute,employeeweekreport_Execute,employeeww_Execute,employeeww_Services_Execute,fullcalendar_Execute,gamchangeyourpassword_Execute,holiday_Delete,holiday_Execute,holiday_FullControl,holiday_Insert,holiday_Update,holidayview_Execute,holidayww_Execute,holidayww_Services_Execute,leavecalendar_Execute,leavecalendarview_Execute,leavedetailspopup_Execute,leaverequest_dataprovider_Execute,leaverequest_Delete,leaverequest_Execute,leaverequest_FullControl,leaverequest_Insert,leaverequest_Services_Delete,leaverequest_Services_Execute,leaverequest_Services_FullControl,leaverequest_Services_Insert,leaverequest_Services_Update,leaverequests_Execute,leaverequests_Services_Execute,leaverequest_Update,leaverequestview_Execute,leaverequestwebpanel_Execute,leaverequestww_Execute,leaverequestww_Services_Execute,leavetype_dataprovider_Execute,leavetype_Delete,leavetype_Execute,leavetype_FullControl,leavetype_Insert,leavetype_Services_Delete,leavetype_Services_Execute,leavetype_Services_FullControl,leavetype_Services_Insert,leavetype_Services_Update,leavetype_Update,leavetypeview_Execute,leavetypeww_Execute,leavetypeww_Services_Execute,logworkhours_Execute,project_dataprovider_Execute,project_Delete,project_Execute,project_FullControl,project_Insert,projectsincompanytest_Execute,project_Update,projectview_Execute,projectww_Execute,projectww_Services_Execute,reports_Execute,schedulerdetailsform_Execute,workhourloglist_Execute,workhourloglist_Services_Execute";
         AV22GManagerPerms = "company_dataprovider_Execute,company_Delete,company_Execute,Company,company_FullControl,company_Insert,companylocation_dataprovider_Execute,companylocation_Delete,companylocation_Execute,companylocation_FullControl,companylocation_Insert,companylocation_Update,companylocationview_Execute,companylocationww_Execute,companylocationww_Services_Execute,company_Update,companyview_Execute,companyww_Execute,Company,companyww_Services_Execute,employee_dataprovider_Execute,employee_Delete,employee_Execute,Employee,employee_FullControl,employeehasprojectcopy1_Execute,employee_Insert,employeelist_Execute,Employee,employeelist_Services_Execute,employeeprojectmatrixcopy1_Execute,employeeprojectmatrix_Execute,employee_Services_Execute,employee_Update,employeeview_Execute,employeeww_Execute,Employee,employeeww_Services_Execute,gamchangeyourpassword_Execute,leavecalendar_Execute,leavecalendarview_Execute,project_dataprovider_Execute,project_Delete,project_Execute,Project,project_FullControl,project_Insert,projectsincompanytest_Execute,project_Update,projectview_Execute,projectww_Execute,Project,projectww_Services_Execute,reportdetail4_Execute,reports_Execute,Reports,schedulerdetailsform_Execute,workhourloglist_Execute,workhourloglist_Services_Execute";
         AV23EmployeePerms = "downloadapp_Execute,gamchangeyourpassword_Execute,leaverequest_dataprovider_Execute,leaverequest_Delete,leaverequest_Execute,leaverequest_FullControl,leaverequest_Insert,leaverequest_Services_Delete,leaverequest_Services_Execute,leaverequest_Services_FullControl,leaverequest_Services_Insert,leaverequest_Services_Update,leaverequests_Execute,leaverequestsgridpaneldata_Execute,leaverequestsgridpanelgeneral_Execute,leaverequestsgridpanelprompt_Execute,leaverequestsgridpanelview_Execute,leaverequests_Services_Execute,leaverequest_Update,leaverequestview_Execute,leaverequestww_Execute,leaverequestww_Services_Execute,leavetype_Services_Execute,logworkhours_Execute";
         AV24PManagerPerms = "downloadapp_Execute,employeeww_Execute,Employee,leaverequest_dataprovider_Execute,leaverequest_Delete,leaverequest_Execute,leaverequest_FullControl,leaverequest_Insert,leaverequest_Services_Delete,leaverequest_Services_Execute,leaverequest_Services_FullControl,leaverequest_Services_Insert,leaverequest_Services_Update,leaverequests_Execute,leaverequestsgridpaneldata_Execute,leaverequestsgridpanelgeneral_Execute,leaverequestsgridpanelprompt_Execute,leaverequestsgridpanelview_Execute,leaverequests_Services_Execute,leaverequest_Update,leaverequestview_Execute,leaverequestwebpanel_Execute,leaverequestww_Execute,leaverequestww_Services_Execute,reports_Execute,Reports,workhourloglist_Execute,workhourloglist_Services_Execute";
         AV12Perms = (GxSimpleCollection<string>)(GxRegex.Split(AV23EmployeePerms,","));
         AV8GAMRole = AV17GAMRepository.getrolebyexternalid("Is"+"Employee", out  AV10GAMErrorCollection);
         AV14GAMUser = AV17GAMRepository.getuserbylogin("local", "admin", out  AV10GAMErrorCollection);
         AV15GAMPermissionFilter.gxTpr_Applicationid = 2;
         AV16GAMPermissions = AV14GAMUser.getallpermissions(AV15GAMPermissionFilter, out  AV10GAMErrorCollection);
         AV25GXV1 = 1;
         while ( AV25GXV1 <= AV16GAMPermissions.Count )
         {
            AV13GAMPermission = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV16GAMPermissions.Item(AV25GXV1));
            AV19Name = StringUtil.Trim( AV13GAMPermission.gxTpr_Name);
            if ( (AV12Perms.IndexOf(StringUtil.RTrim( AV19Name))>0) )
            {
               AV20isok = AV8GAMRole.addpermission(AV13GAMPermission, out  AV10GAMErrorCollection);
               if ( AV20isok )
               {
                  context.CommitDataStores("insertrolepermissions",pr_default);
               }
            }
            AV25GXV1 = (int)(AV25GXV1+1);
         }
         AV9PermString = AV12Perms.ToJSonString(false);
         AV18Count = (short)(AV16GAMPermissions.Count);
         cleanup();
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
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
         AV21ManagerPerms = "";
         AV22GManagerPerms = "";
         AV23EmployeePerms = "";
         AV24PManagerPerms = "";
         AV12Perms = new GxSimpleCollection<string>();
         AV8GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV10GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV17GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV14GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV15GAMPermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter(context);
         AV16GAMPermissions = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMPermission", "GeneXus.Programs");
         AV13GAMPermission = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         AV19Name = "";
         AV9PermString = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.ainsertrolepermissions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ainsertrolepermissions__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18Count ;
      private int AV25GXV1 ;
      private string AV19Name ;
      private bool AV20isok ;
      private string AV21ManagerPerms ;
      private string AV22GManagerPerms ;
      private string AV23EmployeePerms ;
      private string AV24PManagerPerms ;
      private string AV9PermString ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV12Perms ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV8GAMRole ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV17GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV14GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter AV15GAMPermissionFilter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission> AV16GAMPermissions ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV13GAMPermission ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
   }

   public class ainsertrolepermissions__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class ainsertrolepermissions__default : DataStoreHelperBase, IDataStoreHelper
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
