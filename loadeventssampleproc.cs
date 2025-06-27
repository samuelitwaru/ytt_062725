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
   public class loadeventssampleproc : GXProcedure
   {
      public loadeventssampleproc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public loadeventssampleproc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_dateFrom ,
                           DateTime aP1_dateTo ,
                           out SdtSchedulerEvents aP2_events )
      {
         this.AV2dateFrom = aP0_dateFrom;
         this.AV3dateTo = aP1_dateTo;
         this.AV4events = new SdtSchedulerEvents(context) ;
         initialize();
         ExecuteImpl();
         aP2_events=this.AV4events;
      }

      public SdtSchedulerEvents executeUdp( DateTime aP0_dateFrom ,
                                            DateTime aP1_dateTo )
      {
         execute(aP0_dateFrom, aP1_dateTo, out aP2_events);
         return AV4events ;
      }

      public void executeSubmit( DateTime aP0_dateFrom ,
                                 DateTime aP1_dateTo ,
                                 out SdtSchedulerEvents aP2_events )
      {
         this.AV2dateFrom = aP0_dateFrom;
         this.AV3dateTo = aP1_dateTo;
         this.AV4events = new SdtSchedulerEvents(context) ;
         SubmitImpl();
         aP2_events=this.AV4events;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(DateTime)AV2dateFrom,(DateTime)AV3dateTo,(SdtSchedulerEvents)AV4events} ;
         ClassLoader.Execute("aloadeventssampleproc","GeneXus.Programs","aloadeventssampleproc", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV4events = (SdtSchedulerEvents)(args[2]) ;
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
      }

      public override void initialize( )
      {
         AV4events = new SdtSchedulerEvents(context);
         /* GeneXus formulas. */
      }

      private DateTime AV2dateFrom ;
      private DateTime AV3dateTo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSchedulerEvents AV4events ;
      private Object[] args ;
      private SdtSchedulerEvents aP2_events ;
   }

}
