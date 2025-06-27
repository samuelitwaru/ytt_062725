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
   public class gamsdnotauthorized_level_detail : GXDataGridProcedure
   {
      public gamsdnotauthorized_level_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
      }

      public gamsdnotauthorized_level_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_gxid ,
                           out SdtGAMSDNotAuthorized_Level_DetailSdt aP1_GXM1GAMSDNotAuthorized_Level_DetailSdt )
      {
         this.AV11gxid = aP0_gxid;
         this.AV14GXM1GAMSDNotAuthorized_Level_DetailSdt = new SdtGAMSDNotAuthorized_Level_DetailSdt(context) ;
         initialize();
         ExecuteImpl();
         aP1_GXM1GAMSDNotAuthorized_Level_DetailSdt=this.AV14GXM1GAMSDNotAuthorized_Level_DetailSdt;
      }

      public SdtGAMSDNotAuthorized_Level_DetailSdt executeUdp( int aP0_gxid )
      {
         execute(aP0_gxid, out aP1_GXM1GAMSDNotAuthorized_Level_DetailSdt);
         return AV14GXM1GAMSDNotAuthorized_Level_DetailSdt ;
      }

      public void executeSubmit( int aP0_gxid ,
                                 out SdtGAMSDNotAuthorized_Level_DetailSdt aP1_GXM1GAMSDNotAuthorized_Level_DetailSdt )
      {
         this.AV11gxid = aP0_gxid;
         this.AV14GXM1GAMSDNotAuthorized_Level_DetailSdt = new SdtGAMSDNotAuthorized_Level_DetailSdt(context) ;
         SubmitImpl();
         aP1_GXM1GAMSDNotAuthorized_Level_DetailSdt=this.AV14GXM1GAMSDNotAuthorized_Level_DetailSdt;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV11gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            Gxwebsession.Set(Gxids, "true");
         }
         AV14GXM1GAMSDNotAuthorized_Level_DetailSdt.gxTpr_User = AV10User;
         AV14GXM1GAMSDNotAuthorized_Level_DetailSdt.gxTpr_Password = AV9Password;
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
         AV14GXM1GAMSDNotAuthorized_Level_DetailSdt = new SdtGAMSDNotAuthorized_Level_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         AV10User = "";
         AV9Password = "";
         /* GeneXus formulas. */
      }

      private int AV11gxid ;
      private string Gxids ;
      private string AV9Password ;
      private string AV10User ;
      private IGxSession Gxwebsession ;
      private SdtGAMSDNotAuthorized_Level_DetailSdt AV14GXM1GAMSDNotAuthorized_Level_DetailSdt ;
      private SdtGAMSDNotAuthorized_Level_DetailSdt aP1_GXM1GAMSDNotAuthorized_Level_DetailSdt ;
   }

}
