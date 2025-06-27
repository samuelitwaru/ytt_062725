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
   public class yttv3sd_level_detail : GXDataGridProcedure
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

      public yttv3sd_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public yttv3sd_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtYTTV3SD_Level_DetailSdt aP1_GXM1YTTV3SD_Level_DetailSdt )
      {
         this.AV12gxid = aP0_gxid;
         this.AV15GXM1YTTV3SD_Level_DetailSdt = new SdtYTTV3SD_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM1YTTV3SD_Level_DetailSdt=this.AV15GXM1YTTV3SD_Level_DetailSdt;
      }

      public SdtYTTV3SD_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1YTTV3SD_Level_DetailSdt);
         return AV15GXM1YTTV3SD_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtYTTV3SD_Level_DetailSdt aP1_GXM1YTTV3SD_Level_DetailSdt )
      {
         this.AV12gxid = aP0_gxid;
         this.AV15GXM1YTTV3SD_Level_DetailSdt = new SdtYTTV3SD_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM1YTTV3SD_Level_DetailSdt=this.AV15GXM1YTTV3SD_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV12gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            Gxwebsession.Set(Gxids, "true");
         }
         AV15GXM1YTTV3SD_Level_DetailSdt.gxTpr_Pagetitle = AV11PageTitle;
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
         AV15GXM1YTTV3SD_Level_DetailSdt = new SdtYTTV3SD_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV11PageTitle = "";
         /* GeneXus formulas. */
      }

      private int AV12gxid ;
      private string Gxids ;
      private string AV11PageTitle ;
      private IGxSession Gxwebsession ;
      private SdtYTTV3SD_Level_DetailSdt AV15GXM1YTTV3SD_Level_DetailSdt ;
      private SdtYTTV3SD_Level_DetailSdt aP1_GXM1YTTV3SD_Level_DetailSdt ;
   }

}
