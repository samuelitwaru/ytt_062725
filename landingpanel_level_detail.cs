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
   public class landingpanel_level_detail : GXDataGridProcedure
   {
      public landingpanel_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public landingpanel_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtLandingPanel_Level_DetailSdt aP1_GXM1LandingPanel_Level_DetailSdt )
      {
         this.AV8gxid = aP0_gxid;
         this.AV11GXM1LandingPanel_Level_DetailSdt = new SdtLandingPanel_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM1LandingPanel_Level_DetailSdt=this.AV11GXM1LandingPanel_Level_DetailSdt;
      }

      public SdtLandingPanel_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1LandingPanel_Level_DetailSdt);
         return AV11GXM1LandingPanel_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtLandingPanel_Level_DetailSdt aP1_GXM1LandingPanel_Level_DetailSdt )
      {
         this.AV8gxid = aP0_gxid;
         this.AV11GXM1LandingPanel_Level_DetailSdt = new SdtLandingPanel_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM1LandingPanel_Level_DetailSdt=this.AV11GXM1LandingPanel_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV8gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            new sdassignuserdevice(context ).execute( ) ;
            Gxwebsession.Set(Gxids, "true");
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
         AV11GXM1LandingPanel_Level_DetailSdt = new SdtLandingPanel_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         /* GeneXus formulas. */
      }

      private int AV8gxid ;
      private string Gxids ;
      private IGxSession Gxwebsession ;
      private SdtLandingPanel_Level_DetailSdt AV11GXM1LandingPanel_Level_DetailSdt ;
      private SdtLandingPanel_Level_DetailSdt aP1_GXM1LandingPanel_Level_DetailSdt ;
   }

}
