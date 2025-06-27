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
namespace GeneXus.Programs {
   public class aloadeventssampleproc : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aloadeventssampleproc().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
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

      public aloadeventssampleproc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aloadeventssampleproc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_dateFrom ,
                           DateTime aP1_dateTo ,
                           out SdtSchedulerEvents aP2_events )
      {
         this.AV10dateFrom = aP0_dateFrom;
         this.AV11dateTo = aP1_dateTo;
         this.AV9events = new SdtSchedulerEvents(context) ;
         initialize();
         ExecuteImpl();
         aP2_events=this.AV9events;
      }

      public SdtSchedulerEvents executeUdp( DateTime aP0_dateFrom ,
                                            DateTime aP1_dateTo )
      {
         execute(aP0_dateFrom, aP1_dateTo, out aP2_events);
         return AV9events ;
      }

      public void executeSubmit( DateTime aP0_dateFrom ,
                                 DateTime aP1_dateTo ,
                                 out SdtSchedulerEvents aP2_events )
      {
         this.AV10dateFrom = aP0_dateFrom;
         this.AV11dateTo = aP1_dateTo;
         this.AV9events = new SdtSchedulerEvents(context) ;
         SubmitImpl();
         aP2_events=this.AV9events;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8event.gxTpr_Id = "Sample1";
         AV8event.gxTpr_Name = "Wimbledon Match";
         AV8event.gxTpr_Notes = "Wimbledon Match";
         AV8event.gxTpr_Link = "http://www.genexus.com";
         AV8event.gxTpr_Starttime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( Gx_date)), (short)(DateTimeUtil.Month( Gx_date)), (short)(DateTimeUtil.Day( Gx_date)), 15, 30, 0);
         AV8event.gxTpr_Endtime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( Gx_date)), (short)(DateTimeUtil.Month( Gx_date)), (short)(DateTimeUtil.Day( Gx_date)), 17, 30, 0);
         AV8event.gxTpr_Additionalinformation = "";
         AV9events.gxTpr_Items.Add(AV8event, 0);
         AV8event = new SdtSchedulerEvents_event(context);
         AV8event.gxTpr_Id = "Sample2";
         AV8event.gxTpr_Name = "NBA Finals";
         AV8event.gxTpr_Notes = "NBA Finals";
         AV8event.gxTpr_Link = "http://www.gxtechnical.com";
         AV8event.gxTpr_Starttime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( Gx_date)), (short)(DateTimeUtil.Month( Gx_date)), (short)(DateTimeUtil.Day( Gx_date)), 21, 0, 0);
         AV8event.gxTpr_Endtime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( Gx_date)), (short)(DateTimeUtil.Month( Gx_date)), (short)(DateTimeUtil.Day( Gx_date)), 22, 45, 0);
         AV8event.gxTpr_Additionalinformation = "";
         AV9events.gxTpr_Items.Add(AV8event, 0);
         AV8event = new SdtSchedulerEvents_event(context);
         AV8event.gxTpr_Id = "Sample3";
         AV8event.gxTpr_Name = "Meeting with clients";
         AV8event.gxTpr_Notes = "Meeting with clients";
         AV8event.gxTpr_Link = "http://www.gxtechnical.com/gxsearch";
         AV8event.gxTpr_Starttime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( Gx_date)), (short)(DateTimeUtil.Month( Gx_date)), (short)(DateTimeUtil.Day( Gx_date)+1), 8, 30, 0);
         AV8event.gxTpr_Endtime = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( Gx_date)), (short)(DateTimeUtil.Month( Gx_date)), (short)(DateTimeUtil.Day( Gx_date)+1), 11, 30, 0);
         AV8event.gxTpr_Additionalinformation = "";
         AV9events.gxTpr_Items.Add(AV8event, 0);
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
         AV9events = new SdtSchedulerEvents(context);
         AV8event = new SdtSchedulerEvents_event(context);
         Gx_date = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private DateTime AV10dateFrom ;
      private DateTime AV11dateTo ;
      private DateTime Gx_date ;
      private SdtSchedulerEvents AV9events ;
      private SdtSchedulerEvents_event AV8event ;
      private SdtSchedulerEvents aP2_events ;
   }

}
