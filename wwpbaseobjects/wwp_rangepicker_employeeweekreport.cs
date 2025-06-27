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
   public class wwp_rangepicker_employeeweekreport : GXProcedure
   {
      public wwp_rangepicker_employeeweekreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_rangepicker_employeeweekreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context) ;
         initialize();
         ExecuteImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
      }

      public WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions executeUdp( )
      {
         execute(out aP0_PickerOptions);
         return AV8PickerOptions ;
      }

      public void executeSubmit( out WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions )
      {
         this.AV8PickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context) ;
         SubmitImpl();
         aP0_PickerOptions=this.AV8PickerOptions;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: 'GETWEEKSTARTDATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV8PickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         AV13Count = 5;
         while ( AV13Count > 0 )
         {
            AV11Range = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
            GXt_dtime1 = DateTimeUtil.ResetTime( AV12WeekStartDate ) ;
            AV11Range.gxTpr_Startdate = GXt_dtime1;
            GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( AV12WeekStartDate, (6)) ) ;
            AV11Range.gxTpr_Enddate = GXt_dtime1;
            GXt_char2 = "";
            new formatdatetime(context ).execute(  AV12WeekStartDate,  "DD MMMM", out  GXt_char2) ;
            GXt_char3 = "";
            new formatdatetime(context ).execute(  DateTimeUtil.DAdd( AV12WeekStartDate, (6)),  "DD MMMM", out  GXt_char3) ;
            AV11Range.gxTpr_Displayname = GXt_char2+" - "+GXt_char3;
            AV8PickerOptions.gxTpr_Ranges.Add(AV11Range, 0);
            AV12WeekStartDate = DateTimeUtil.DAdd( AV12WeekStartDate, (7));
            AV13Count = (short)(AV13Count-1);
         }
         AV12WeekStartDate = DateTimeUtil.DAdd( Gx_date, (-1*(DateTimeUtil.Dow( Gx_date)-2)));
         AV14ThisWeekRange = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV12WeekStartDate ) ;
         AV14ThisWeekRange.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( AV12WeekStartDate, (6)) ) ;
         AV14ThisWeekRange.gxTpr_Enddate = GXt_dtime1;
         AV14ThisWeekRange.gxTpr_Displayname = "This Week";
         AV12WeekStartDate = DateTimeUtil.DAdd( AV12WeekStartDate, (-7));
         AV15LastWeekRange = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV12WeekStartDate ) ;
         AV15LastWeekRange.gxTpr_Startdate = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( AV12WeekStartDate, (6)) ) ;
         AV15LastWeekRange.gxTpr_Enddate = GXt_dtime1;
         AV15LastWeekRange.gxTpr_Displayname = "Last Week";
         AV8PickerOptions.gxTpr_Ranges.Add(AV15LastWeekRange, 0);
         AV8PickerOptions.gxTpr_Ranges.Add(AV14ThisWeekRange, 0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'GETWEEKSTARTDATE' Routine */
         returnInSub = false;
         AV12WeekStartDate = DateTimeUtil.DAdd( Gx_date, (-1*(DateTimeUtil.Dow( Gx_date)-2)));
         AV12WeekStartDate = DateTimeUtil.DAdd( AV12WeekStartDate, (-42));
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
         AV8PickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         AV11Range = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV12WeekStartDate = DateTime.MinValue;
         GXt_char2 = "";
         GXt_char3 = "";
         Gx_date = DateTime.MinValue;
         AV14ThisWeekRange = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         AV15LastWeekRange = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem(context);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV13Count ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private DateTime GXt_dtime1 ;
      private DateTime AV12WeekStartDate ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions AV8PickerOptions ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem AV11Range ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem AV14ThisWeekRange ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions_RangesItem AV15LastWeekRange ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions ;
   }

}
