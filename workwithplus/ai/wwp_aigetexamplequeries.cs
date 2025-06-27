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
   public class wwp_aigetexamplequeries : GXProcedure
   {
      public wwp_aigetexamplequeries( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_aigetexamplequeries( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ListName ,
                           out string aP1_Examples )
      {
         this.AV10ListName = aP0_ListName;
         this.AV9Examples = "" ;
         initialize();
         ExecuteImpl();
         aP1_Examples=this.AV9Examples;
      }

      public string executeUdp( string aP0_ListName )
      {
         execute(aP0_ListName, out aP1_Examples);
         return AV9Examples ;
      }

      public void executeSubmit( string aP0_ListName ,
                                 out string aP1_Examples )
      {
         this.AV10ListName = aP0_ListName;
         this.AV9Examples = "" ;
         SubmitImpl();
         aP1_Examples=this.AV9Examples;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SystemContent = "";
         AV11SystemContent += "You are an assistant that answer 3 concrete, real and very simple examples of queries in natural language to list information available in a described software system.";
         AV11SystemContent += " One in each line. Examples must include concrete values (made up).";
         AV11SystemContent += " 70 characters maximum length per line.";
         AV11SystemContent += " The query cannot reference information from other entity than the listed one." + StringUtil.NewLine( );
         AV11SystemContent += "The format of the response must be (total lines 3) with no technical information, just the query in natural language";
         AV15Lang = context.GetLanguage( );
         if ( StringUtil.StrCmp(AV15Lang, "English") != 0 )
         {
            AV11SystemContent += ", always in " + AV15Lang;
         }
         AV11SystemContent += ":" + StringUtil.NewLine( );
         AV11SystemContent += "- (example 1)" + StringUtil.NewLine( ) + "- (example 2)" + StringUtil.NewLine( ) + "- (example 3)";
         AV12UserQuery = "";
         AV12UserQuery += "The system contains the following queryable entities:" + StringUtil.NewLine( );
         GXt_objcol_SdtWWP_AIListData1 = AV13WWP_AIListDatas;
         GXt_objcol_SdtWWP_AIListData2 = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>();
         new GeneXus.Programs.workwithplus.ai.wwp_aigetlistdata(context ).execute(  "Examples",  AV10ListName,  (GXProperties)(GXt_objcol_SdtWWP_AIListData1), out  GXt_objcol_SdtWWP_AIListData2) ;
         AV13WWP_AIListDatas = GXt_objcol_SdtWWP_AIListData1;
         if ( AV13WWP_AIListDatas.Count > 0 )
         {
            AV16HasContextInfo = false;
            AV17MaxContextForExamples = 10;
            AV18GXV1 = 1;
            while ( AV18GXV1 <= AV13WWP_AIListDatas.Count )
            {
               AV14WWP_AIListData = ((GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData)AV13WWP_AIListDatas.Item(AV18GXV1));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14WWP_AIListData.gxTpr_Examples.gxTpr_Contextinfo)) )
               {
                  AV12UserQuery += AV14WWP_AIListData.gxTpr_Examples.gxTpr_Contextinfo + StringUtil.NewLine( );
                  AV16HasContextInfo = true;
                  AV17MaxContextForExamples = (short)(AV17MaxContextForExamples-1);
                  if ( (0==AV17MaxContextForExamples) )
                  {
                     if (true) break;
                  }
               }
               AV18GXV1 = (int)(AV18GXV1+1);
            }
            if ( AV16HasContextInfo )
            {
               GXt_char3 = AV9Examples;
               new GeneXus.Programs.workwithplus.ai.wwp_aigetairesponse(context ).execute(  AV11SystemContent,  AV12UserQuery, out  AV8ErrorMessage, out  GXt_char3) ;
               AV9Examples = GXt_char3;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8ErrorMessage)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Examples)) )
               {
                  AV9Examples = "E.g.:" + StringUtil.NewLine( ) + AV9Examples;
               }
            }
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
         AV9Examples = "";
         AV11SystemContent = "";
         AV15Lang = "";
         AV12UserQuery = "";
         AV13WWP_AIListDatas = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         GXt_objcol_SdtWWP_AIListData1 = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         GXt_objcol_SdtWWP_AIListData2 = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         AV14WWP_AIListData = new GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData(context);
         GXt_char3 = "";
         AV8ErrorMessage = "";
         /* GeneXus formulas. */
      }

      private short AV17MaxContextForExamples ;
      private int AV18GXV1 ;
      private string GXt_char3 ;
      private bool AV16HasContextInfo ;
      private string AV10ListName ;
      private string AV9Examples ;
      private string AV11SystemContent ;
      private string AV15Lang ;
      private string AV12UserQuery ;
      private string AV8ErrorMessage ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> AV13WWP_AIListDatas ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> GXt_objcol_SdtWWP_AIListData1 ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> GXt_objcol_SdtWWP_AIListData2 ;
      private GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData AV14WWP_AIListData ;
      private string aP1_Examples ;
   }

}
