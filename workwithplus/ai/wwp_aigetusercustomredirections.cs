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
namespace GeneXus.Programs.workwithplus.ai {
   public class wwp_aigetusercustomredirections : GXProcedure
   {
      public wwp_aigetusercustomredirections( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_aigetusercustomredirections( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> aP0_AICustomRedirections )
      {
         this.AV9AICustomRedirections = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_AICustomRedirections=this.AV9AICustomRedirections;
      }

      public GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> executeUdp( )
      {
         execute(out aP0_AICustomRedirections);
         return AV9AICustomRedirections ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> aP0_AICustomRedirections )
      {
         this.AV9AICustomRedirections = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4") ;
         SubmitImpl();
         aP0_AICustomRedirections=this.AV9AICustomRedirections;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         AV9AICustomRedirections = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> AV9AICustomRedirections ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> aP0_AICustomRedirections ;
   }

}
