using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
namespace GeneXus.Programs.wwpbaseobjects {
   public class listwwpprograms : GXProcedure
   {
      public listwwpprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listwwpprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName>( context, "ProgramName", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      public GXBaseCollection<WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV9ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName>( context, "ProgramName", "YTT_version4") ;
         SubmitImpl();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ProgramNames = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName>( context, "ProgramName", "YTT_version4");
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV13name = "WorkHourLogDetail";
         AV14description = "";
         AV15link = formatLink("workhourlogdetail.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "GAMWWAuthTypes";
         AV14description = "Authentication Types";
         AV15link = formatLink("gamwwauthtypes.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "LeaveRequestWW";
         AV14description = " Leave Request";
         AV15link = formatLink("leaverequestww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "SiteSettingWW";
         AV14description = " Site Setting";
         AV15link = formatLink("sitesettingww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "EmployeeList";
         AV14description = " Employees";
         AV15link = formatLink("employeelist.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WP_LeaveBalanceReport1";
         AV14description = "WP_Leave Balance Report";
         AV15link = formatLink("wp_leavebalancereport1.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "GAMWWSecurityPolicy";
         AV14description = "Security Policies";
         AV15link = formatLink("gamwwsecuritypolicy.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "LeaveTypeWW";
         AV14description = " Leave Types";
         AV15link = formatLink("leavetypeww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "GAMWWConnections";
         AV14description = "Connections";
         AV15link = formatLink("gamwwconnections.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "HolidayWW";
         AV14description = " National Holiday";
         AV15link = formatLink("holidayww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "LeaveRequests";
         AV14description = " My Leave Requests";
         AV15link = formatLink("leaverequests.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "CompanyWW";
         AV14description = "Location";
         AV15link = formatLink("companyww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "GAMWWApplications";
         AV14description = "Applications";
         AV15link = formatLink("gamwwapplications.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WorkWithPlus.WWP_ParameterWW";
         AV14description = "Parameter";
         AV15link = formatLink("workwithplus.wwp_parameterww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "GAMWWRepositories";
         AV14description = "Repositories";
         AV15link = formatLink("gamwwrepositories.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "TestProjectLogsByEmployee";
         AV14description = " Work Hour Log";
         AV15link = formatLink("testprojectlogsbyemployee.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "CompanyLocationWW";
         AV14description = "Countries";
         AV15link = formatLink("companylocationww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WorkHourLogWW";
         AV14description = " Work Hour Log";
         AV15link = formatLink("workhourlogww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         AV14description = "Visualize all notifications";
         AV15link = formatLink("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ProjectWW";
         AV14description = " Project";
         AV15link = formatLink("projectww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "GAMWWEventSubscriptions";
         AV14description = "Event subscriptions";
         AV15link = formatLink("gamwweventsubscriptions.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettings";
         AV14description = "Manage my Subscriptions";
         AV15link = formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionssettings.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "EmployeeWeekReport";
         AV14description = "";
         AV15link = formatLink("employeeweekreport.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "GAMWWRoles";
         AV14description = "Roles";
         AV15link = formatLink("gamwwroles.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "TrnNewWW";
         AV14description = " Trn New";
         AV15link = formatLink("trnnewww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WP_LeaveBalanceReport";
         AV14description = "Leave Balance Report";
         AV15link = formatLink("wp_leavebalancereport.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "GAMWWUsers";
         AV14description = "Users";
         AV15link = formatLink("gamwwusers.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WPLeaveReport";
         AV14description = "";
         AV15link = formatLink("wpleavereport.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "EmployeeWW";
         AV14description = " Employees";
         AV15link = formatLink("employeeww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ADDPROGRAM' Routine */
         returnInSub = false;
         AV8IsAuthorized = true;
         if ( AV8IsAuthorized )
         {
            AV10ProgramName = new WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName(context);
            AV10ProgramName.gxTpr_Name = AV13name;
            AV10ProgramName.gxTpr_Description = AV14description;
            AV10ProgramName.gxTpr_Link = AV15link;
            AV9ProgramNames.Add(AV10ProgramName, 0);
         }
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
         AV9ProgramNames = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName>( context, "ProgramName", "YTT_version4");
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13name = "";
         AV14description = "";
         AV15link = "";
         AV10ProgramName = new WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private string AV13name ;
      private string AV14description ;
      private string AV15link ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName> AV9ProgramNames ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName AV10ProgramName ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtProgramNames_ProgramName> aP0_ProgramNames ;
   }

}
