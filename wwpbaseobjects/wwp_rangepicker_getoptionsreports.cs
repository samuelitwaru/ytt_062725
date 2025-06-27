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
   public class wwp_rangepicker_getoptionsreports : GXProcedure
   {
      public wwp_rangepicker_getoptionsreports( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_rangepicker_getoptionsreports( IGxContext context )
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
         AV8PickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         AV8PickerOptions.gxTpr_Datepicker.gxTpr_Showweeknumbers = true;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_yesterday( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_today( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_lastweek( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_lastmonth( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_thisweek( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_thismonth( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_lastyear( ref  AV8PickerOptions) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_addpredefinedrange(context ).gxep_thisyear( ref  AV8PickerOptions) ;
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
         AV8PickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         /* GeneXus formulas. */
      }

      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions AV8PickerOptions ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions aP0_PickerOptions ;
   }

}
