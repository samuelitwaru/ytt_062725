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
   public class wwp_aigetqueryredirection : GXProcedure
   {
      public wwp_aigetqueryredirection( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_aigetqueryredirection( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserQuery ,
                           out string aP1_Link ,
                           out string aP2_ErrorMessage )
      {
         this.AV21UserQuery = aP0_UserQuery;
         this.AV11Link = "" ;
         this.AV9ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_Link=this.AV11Link;
         aP2_ErrorMessage=this.AV9ErrorMessage;
      }

      public string executeUdp( string aP0_UserQuery ,
                                out string aP1_Link )
      {
         execute(aP0_UserQuery, out aP1_Link, out aP2_ErrorMessage);
         return AV9ErrorMessage ;
      }

      public void executeSubmit( string aP0_UserQuery ,
                                 out string aP1_Link ,
                                 out string aP2_ErrorMessage )
      {
         this.AV21UserQuery = aP0_UserQuery;
         this.AV11Link = "" ;
         this.AV9ErrorMessage = "" ;
         SubmitImpl();
         aP1_Link=this.AV11Link;
         aP2_ErrorMessage=this.AV9ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19SystemContent += "You are a JSON generator that resolves which Web Page has the ability to resolve a query." + StringUtil.NewLine( );
         AV19SystemContent += "You respond only in the following format:" + StringUtil.NewLine( );
         AV19SystemContent += "{" + StringUtil.NewLine( );
         AV19SystemContent += "  \"page\": the name of the web page or null if there are no matches," + StringUtil.NewLine( );
         AV19SystemContent += "  \"description\": the name of the web page or null if there are no matches" + StringUtil.NewLine( );
         AV19SystemContent += "}" + StringUtil.NewLine( );
         AV19SystemContent += "The pages available to resolve the user's query are (page: description):" + StringUtil.NewLine( );
         AV12LinkedPages = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_objcol_SdtWWP_AIListData1 = AV24WWP_AIListDatas;
         GXt_objcol_SdtWWP_AIListData2 = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>();
         new GeneXus.Programs.workwithplus.ai.wwp_aigetlistdata(context ).execute(  "RedirectToList",  "",  (GXProperties)(GXt_objcol_SdtWWP_AIListData1), out  GXt_objcol_SdtWWP_AIListData2) ;
         AV24WWP_AIListDatas = GXt_objcol_SdtWWP_AIListData1;
         GXt_objcol_SdtWWP_AIListData2 = AV27WWP_AIUserDatas;
         new GeneXus.Programs.workwithplus.ai.wwp_aigetusercustomredirections(context ).execute( out  GXt_objcol_SdtWWP_AIListData2) ;
         AV27WWP_AIUserDatas = GXt_objcol_SdtWWP_AIListData2;
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV27WWP_AIUserDatas.Count )
         {
            AV23WWP_AIListData = ((GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData)AV27WWP_AIUserDatas.Item(AV28GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23WWP_AIListData.gxTpr_Redirecttolist.gxTpr_Listname)) )
            {
               AV23WWP_AIListData.gxTpr_Redirecttolist.gxTpr_Listname = "UCR_"+AV23WWP_AIListData.gxTpr_Redirecttolist.gxTpr_Listname;
               AV24WWP_AIListDatas.Add(AV23WWP_AIListData, 0);
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
         AV8DataAdded = false;
         AV29GXV2 = 1;
         while ( AV29GXV2 <= AV24WWP_AIListDatas.Count )
         {
            AV23WWP_AIListData = ((GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData)AV24WWP_AIListDatas.Item(AV29GXV2));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23WWP_AIListData.gxTpr_Redirecttolist.gxTpr_Listname)) )
            {
               AV8DataAdded = true;
               AV19SystemContent += StringUtil.Format( "%1: %2", StringUtil.StringReplace( AV23WWP_AIListData.gxTpr_Redirecttolist.gxTpr_Listname, ".", "_"), AV23WWP_AIListData.gxTpr_Redirecttolist.gxTpr_Description, "", "", "", "", "", "", "") + StringUtil.NewLine( );
               AV12LinkedPages.Add(StringUtil.Lower( StringUtil.Trim( AV23WWP_AIListData.gxTpr_Listquery.gxTpr_Link)), 0);
               if ( StringUtil.Len( AV19SystemContent) > 50000 )
               {
                  if (true) break;
               }
            }
            AV29GXV2 = (int)(AV29GXV2+1);
         }
         /* Execute user subroutine: 'ADD MENU OPTIONS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( AV8DataAdded )
         {
            GXt_char3 = AV18ResponseText;
            new GeneXus.Programs.workwithplus.ai.wwp_aigetairesponse(context ).execute(  AV19SystemContent,  AV21UserQuery, out  AV9ErrorMessage, out  GXt_char3) ;
            AV18ResponseText = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV9ErrorMessage))) )
            {
               AV25i = (short)(StringUtil.StringSearch( AV18ResponseText, ":", 1));
               if ( AV25i > 0 )
               {
                  AV18ResponseText = "{\"Result\"" + StringUtil.Substring( AV18ResponseText, AV25i, -1);
                  AV26SDTResult.FromJSonString(AV18ResponseText, null);
                  AV13ListName = StringUtil.Trim( AV26SDTResult.gxTpr_Result);
               }
               AV13ListName = StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV13ListName, StringUtil.Chr( 10), ","), " ", ","), ":", ",");
               if ( StringUtil.Contains( AV13ListName, ",") )
               {
                  AV13ListName = StringUtil.Substring( AV13ListName, 1, StringUtil.StringSearch( AV13ListName, ",", 1)-1);
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13ListName)) || ( StringUtil.StrCmp(StringUtil.Lower( AV13ListName), "null") == 0 ) )
               {
                  AV9ErrorMessage = "No page was found to resolve the query. Please include more details.";
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9ErrorMessage)) )
            {
               AV10IsMenuOption = StringUtil.StartsWith( AV13ListName, "Page_");
               if ( AV10IsMenuOption )
               {
                  /* Execute user subroutine: 'SEARCH MENU OPTION' */
                  S121 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               else
               {
                  if ( StringUtil.Contains( AV13ListName, "_") )
                  {
                     AV30GXV3 = 1;
                     while ( AV30GXV3 <= AV24WWP_AIListDatas.Count )
                     {
                        AV23WWP_AIListData = ((GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData)AV24WWP_AIListDatas.Item(AV30GXV3));
                        if ( StringUtil.StrCmp(StringUtil.StringReplace( AV23WWP_AIListData.gxTpr_Redirecttolist.gxTpr_Listname, ".", "_"), AV13ListName) == 0 )
                        {
                           AV13ListName = AV23WWP_AIListData.gxTpr_Redirecttolist.gxTpr_Listname;
                           AV11Link = AV23WWP_AIListData.gxTpr_Listquery.gxTpr_Link;
                           if (true) break;
                        }
                        AV30GXV3 = (int)(AV30GXV3+1);
                     }
                  }
                  if ( StringUtil.StartsWith( AV13ListName, "UCR_") )
                  {
                     AV13ListName = StringUtil.Substring( AV13ListName, 5, -1);
                     new GeneXus.Programs.workwithplus.ai.wwp_aiprocessusercustomredirection(context ).execute(  AV13ListName,  AV21UserQuery, ref  AV11Link, out  AV9ErrorMessage) ;
                  }
                  else
                  {
                     new GeneXus.Programs.workwithplus.ai.wwp_aigetnlfilterfromai(context ).execute(  AV13ListName,  AV21UserQuery, out  AV11Link, out  AV9ErrorMessage) ;
                  }
               }
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9ErrorMessage)) )
            {
               AV11Link = "";
            }
            else
            {
               if ( ! AV10IsMenuOption )
               {
                  new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV13ListName+"NLQuery",  AV21UserQuery) ;
               }
            }
         }
         else
         {
            AV9ErrorMessage = "No page available to resolve natural language queries.";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ADD MENU OPTIONS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVelop_Menu_Item4 = AV16DVelop_Menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdata(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item4) ;
         AV16DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item4;
         new WorkWithPlus.workwithplus_webgam.getmenuauthorizedoptions(context ).execute( ref  AV16DVelop_Menu) ;
         AV20SystemContentLength = (short)(StringUtil.Len( AV19SystemContent));
         new GeneXus.Programs.workwithplus.ai.wwp_aigetqueryredirectionmenuoptions(context ).execute(  AV16DVelop_Menu,  "", ref  AV12LinkedPages, ref  AV19SystemContent) ;
         AV8DataAdded = (bool)(AV8DataAdded||(AV20SystemContentLength<StringUtil.Len( AV19SystemContent)));
      }

      protected void S121( )
      {
         /* 'SEARCH MENU OPTION' Routine */
         returnInSub = false;
         AV17MenuOptionsToAnalize = AV16DVelop_Menu;
         AV11Link = "";
         while ( String.IsNullOrEmpty(StringUtil.RTrim( AV11Link)) && ( AV17MenuOptionsToAnalize.Count > 0 ) )
         {
            AV14MenuOption = ((WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item)AV17MenuOptionsToAnalize.Item(1));
            AV17MenuOptionsToAnalize.RemoveItem(1);
            if ( AV14MenuOption.gxTpr_Subitems.Count > 0 )
            {
               AV31GXV4 = 1;
               while ( AV31GXV4 <= AV14MenuOption.gxTpr_Subitems.Count )
               {
                  AV15MenuOptionAux = ((WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item)AV14MenuOption.gxTpr_Subitems.Item(AV31GXV4));
                  AV17MenuOptionsToAnalize.Add(AV15MenuOptionAux, 0);
                  AV31GXV4 = (int)(AV31GXV4+1);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(StringUtil.Format( "Page_%1%2", StringUtil.StringReplace( StringUtil.Trim( AV14MenuOption.gxTpr_Caption), " ", ""), StringUtil.Trim( AV14MenuOption.gxTpr_Id), "", "", "", "", "", "", ""), AV13ListName) == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV14MenuOption.gxTpr_Link))) )
               {
                  AV11Link = AV14MenuOption.gxTpr_Link;
               }
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11Link)) )
         {
            AV9ErrorMessage = StringUtil.Format( "Menu with id %1 not found", AV13ListName, "", "", "", "", "", "", "", "");
         }
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
         AV11Link = "";
         AV9ErrorMessage = "";
         AV19SystemContent = "";
         AV12LinkedPages = new GxSimpleCollection<string>();
         AV24WWP_AIListDatas = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         GXt_objcol_SdtWWP_AIListData1 = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         AV27WWP_AIUserDatas = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         GXt_objcol_SdtWWP_AIListData2 = new GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData>( context, "WWP_AIListData", "YTT_version4");
         AV23WWP_AIListData = new GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData(context);
         AV18ResponseText = "";
         GXt_char3 = "";
         AV26SDTResult = new WorkWithPlus.workwithplus_web.SdtWWP_SDTResult(context);
         AV13ListName = "";
         AV16DVelop_Menu = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item>( context, "Item", "YTT_version4");
         GXt_objcol_SdtDVelop_Menu_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item>( context, "Item", "YTT_version4");
         AV17MenuOptionsToAnalize = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item>( context, "Item", "YTT_version4");
         AV14MenuOption = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         AV15MenuOptionAux = new WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item(context);
         /* GeneXus formulas. */
      }

      private short AV25i ;
      private short AV20SystemContentLength ;
      private int AV28GXV1 ;
      private int AV29GXV2 ;
      private int AV30GXV3 ;
      private int AV31GXV4 ;
      private string GXt_char3 ;
      private bool AV8DataAdded ;
      private bool returnInSub ;
      private bool AV10IsMenuOption ;
      private string AV21UserQuery ;
      private string AV11Link ;
      private string AV9ErrorMessage ;
      private string AV19SystemContent ;
      private string AV18ResponseText ;
      private string AV13ListName ;
      private GxSimpleCollection<string> AV12LinkedPages ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> AV24WWP_AIListDatas ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> GXt_objcol_SdtWWP_AIListData1 ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> AV27WWP_AIUserDatas ;
      private GXBaseCollection<GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData> GXt_objcol_SdtWWP_AIListData2 ;
      private GeneXus.Programs.workwithplus.ai.SdtWWP_AIListData AV23WWP_AIListData ;
      private WorkWithPlus.workwithplus_web.SdtWWP_SDTResult AV26SDTResult ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> AV16DVelop_Menu ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item4 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item> AV17MenuOptionsToAnalize ;
      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item AV14MenuOption ;
      private WorkWithPlus.workwithplus_web.SdtDVelop_Menu_Item AV15MenuOptionAux ;
      private string aP1_Link ;
      private string aP2_ErrorMessage ;
   }

}
