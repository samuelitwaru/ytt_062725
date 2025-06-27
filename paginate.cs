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
   public class paginate : GXProcedure
   {
      public paginate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public paginate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtSDTPage> aP0_pages_to_show ,
                           out short aP1_total_pages ,
                           ref SdtSDTPage aP2_current_page )
      {
         this.AV10pages_to_show = new GXBaseCollection<SdtSDTPage>( context, "SDTPage", "YTT_version4") ;
         this.AV14total_pages = 0 ;
         this.AV8current_page = aP2_current_page;
         initialize();
         ExecuteImpl();
         aP0_pages_to_show=this.AV10pages_to_show;
         aP1_total_pages=this.AV14total_pages;
         aP2_current_page=this.AV8current_page;
      }

      public SdtSDTPage executeUdp( out GXBaseCollection<SdtSDTPage> aP0_pages_to_show ,
                                    out short aP1_total_pages )
      {
         execute(out aP0_pages_to_show, out aP1_total_pages, ref aP2_current_page);
         return AV8current_page ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTPage> aP0_pages_to_show ,
                                 out short aP1_total_pages ,
                                 ref SdtSDTPage aP2_current_page )
      {
         this.AV10pages_to_show = new GXBaseCollection<SdtSDTPage>( context, "SDTPage", "YTT_version4") ;
         this.AV14total_pages = 0 ;
         this.AV8current_page = aP2_current_page;
         SubmitImpl();
         aP0_pages_to_show=this.AV10pages_to_show;
         aP1_total_pages=this.AV14total_pages;
         aP2_current_page=this.AV8current_page;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12rows = 20;
         AV11per_page = 5;
         AV8current_page = new SdtSDTPage(context);
         AV8current_page.gxTpr_Page = 1;
         AV8current_page.gxTpr_Iscurrent = true;
         AV14total_pages = (short)(AV12rows/ (decimal)(AV11per_page));
         AV13segments = 2;
         if ( ( AV8current_page.gxTpr_Page > AV14total_pages ) || ( AV8current_page.gxTpr_Page < 1 ) )
         {
            AV8current_page.gxTpr_Page = 1;
         }
         if ( AV13segments > AV14total_pages )
         {
            AV13segments = AV14total_pages;
         }
         AV9iteration = 1;
         AV10pages_to_show.Add(AV8current_page, 0);
         while ( ( AV10pages_to_show.Count < AV13segments ) && ( AV14total_pages >= AV13segments ) )
         {
            if ( AV8current_page.gxTpr_Page - AV9iteration > 0 )
            {
               AV15page1 = new SdtSDTPage(context);
               AV15page1.gxTpr_Page = (short)(AV8current_page.gxTpr_Page-AV9iteration);
               AV10pages_to_show.Add(AV15page1, 0);
            }
            if ( AV8current_page.gxTpr_Page + AV9iteration <= AV14total_pages )
            {
               AV15page1 = new SdtSDTPage(context);
               AV15page1.gxTpr_Page = (short)(AV8current_page.gxTpr_Page+AV9iteration);
               AV10pages_to_show.Add(AV15page1, 0);
            }
            AV9iteration = (short)(AV9iteration+1);
         }
         AV10pages_to_show.Sort("");
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
         AV10pages_to_show = new GXBaseCollection<SdtSDTPage>( context, "SDTPage", "YTT_version4");
         AV15page1 = new SdtSDTPage(context);
         /* GeneXus formulas. */
      }

      private short AV14total_pages ;
      private short AV12rows ;
      private short AV11per_page ;
      private short AV13segments ;
      private short AV9iteration ;
      private GXBaseCollection<SdtSDTPage> AV10pages_to_show ;
      private SdtSDTPage AV8current_page ;
      private SdtSDTPage aP2_current_page ;
      private SdtSDTPage AV15page1 ;
      private GXBaseCollection<SdtSDTPage> aP0_pages_to_show ;
      private short aP1_total_pages ;
   }

}
