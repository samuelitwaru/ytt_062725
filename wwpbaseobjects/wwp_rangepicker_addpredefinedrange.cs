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
   public class wwp_rangepicker_addpredefinedrange : GXProcedure
   {
      public wwp_rangepicker_addpredefinedrange( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_rangepicker_addpredefinedrange( IGxContext context )
      {
         this.context = context;
         IsMain = false;
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
         cleanup();
      }

      public void gxep_past( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* Past Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "Past";
         GXt_dtime1 = DateTimeUtil.ResetTime( context.localUtil.YMDToD( 1970, 1, 1) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (-1)) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_yesterday( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* Yesterday Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "Yesterday";
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (-1)) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (-1)) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_today( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* Today Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "Today";
         GXt_dtime1 = DateTimeUtil.ResetTime( Gx_date ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( Gx_date ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_tomorrow( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* Tomorrow Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "Tomorrow";
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (1)) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (1)) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_inthefuture( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* InTheFuture Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "In the future";
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (1)) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( context.localUtil.YMDToD( 2039, 12, 31) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_lastweek( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* LastWeek Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "Last week";
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.DAdd( Gx_date , - ( (int)(DateTimeUtil.Dow( Gx_date)) )) , - ( (int)(6) )) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date , - ( (int)(DateTimeUtil.Dow( Gx_date)) )) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_lastmonth( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* LastMonth Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "Last month";
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.DAdd( DateTimeUtil.AddMth( Gx_date, -1) , - ( DateTimeUtil.Day( Gx_date) )) , + ( (int)(1) )) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DateEndOfMonth( DateTimeUtil.AddMth( Gx_date, -1)) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_lastyear( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* LastYear Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "Last year";
         GXt_dtime1 = DateTimeUtil.ResetTime( context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date)-1, 1, 1) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date)-1, 12, 31) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_thisweek( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* ThisWeek Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "This week";
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.DAdd( Gx_date , - ( (int)(DateTimeUtil.Dow( Gx_date)) )) , + ( (int)(1) )) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.DAdd( Gx_date , - ( (int)(DateTimeUtil.Dow( Gx_date)) )) , + ( (int)(7) )) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_thismonth( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* ThisMonth Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "This month";
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.DAdd( Gx_date , - ( DateTimeUtil.Day( Gx_date) )) , + ( (int)(1) )) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DateEndOfMonth( Gx_date) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_thisyear( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* ThisYear Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "This year";
         GXt_dtime1 = DateTimeUtil.ResetTime( context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 1, 1) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), 12, 31) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_nextweek( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* NextWeek Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "Next week";
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.DAdd( DateTimeUtil.DAdd( Gx_date , + ( (int)(7) )) , - ( (int)(DateTimeUtil.Dow( Gx_date)) )) , + ( (int)(1) )) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.DAdd( Gx_date , + ( (int)(14) )) , - ( (int)(DateTimeUtil.Dow( Gx_date)) )) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_nextmonth( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* NextMonth Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "Next month";
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( DateTimeUtil.DAdd( DateTimeUtil.AddMth( Gx_date, 1) , - ( DateTimeUtil.Day( Gx_date) )) , + ( (int)(1) )) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DateEndOfMonth( DateTimeUtil.AddMth( Gx_date, 1)) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
         cleanup();
      }

      public void gxep_nextyear( ref WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = aP0_PickerOptions;
         initialize();
         /* NextYear Constructor */
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV9PickerOption.gxTpr_Displayname = "Next year";
         GXt_dtime1 = DateTimeUtil.ResetTime( context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date)+1, 1, 1) ) ;
         AV9PickerOption.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date)+1, 12, 31) ) ;
         AV9PickerOption.gxTpr_Enddate = GXt_dtime1;
         AV8PickerOptions.gxTpr_Ranges.Add(AV9PickerOption, 0);
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
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
         AV9PickerOption = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         Gx_date = DateTime.MinValue;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private DateTime GXt_dtime1 ;
      private DateTime Gx_date ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions AV8PickerOptions ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem AV9PickerOption ;
   }

}
