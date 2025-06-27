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
   public class wwp_aigetlistdata : GXProcedure
   {
      public wwp_aigetlistdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_aigetlistdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Info ,
                           string aP1_ListName ,
                           GXProperties aP2_ExtraParameters ,
                           out GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> aP3_WWP_AIListDatas )
      {
         this.AV8Info = aP0_Info;
         this.AV9ListName = aP1_ListName;
         this.AV15ExtraParameters = aP2_ExtraParameters;
         this.AV12WWP_AIListDatas = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP3_WWP_AIListDatas=this.AV12WWP_AIListDatas;
      }

      public GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> executeUdp( string aP0_Info ,
                                                                                              string aP1_ListName ,
                                                                                              GXProperties aP2_ExtraParameters )
      {
         execute(aP0_Info, aP1_ListName, aP2_ExtraParameters, out aP3_WWP_AIListDatas);
         return AV12WWP_AIListDatas ;
      }

      public void executeSubmit( string aP0_Info ,
                                 string aP1_ListName ,
                                 GXProperties aP2_ExtraParameters ,
                                 out GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> aP3_WWP_AIListDatas )
      {
         this.AV8Info = aP0_Info;
         this.AV9ListName = aP1_ListName;
         this.AV15ExtraParameters = aP2_ExtraParameters;
         this.AV12WWP_AIListDatas = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4") ;
         SubmitImpl();
         aP3_WWP_AIListDatas=this.AV12WWP_AIListDatas;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9ListName)) )
         {
            /* Execute user subroutine: 'ADD ALL LIST DATA' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'ADD SPECIFIC LIST DATA' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ADD ALL LIST DATA' Routine */
         returnInSub = false;
      }

      protected void S121( )
      {
         /* 'ADD SPECIFIC LIST DATA' Routine */
         returnInSub = false;
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
         AV12WWP_AIListDatas = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private string AV8Info ;
      private string AV9ListName ;
      private GXProperties AV15ExtraParameters ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> AV12WWP_AIListDatas ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> aP3_WWP_AIListDatas ;
   }

}
