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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class home : GXDataArea
   {
      public home( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public home( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_103 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_103"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_103_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_103_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_103_idx = GetPar( "sGXsfl_103_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV7SDTNotificationsData);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV7SDTNotificationsData) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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

      protected override string ExecutePermissionPrefix
      {
         get {
            return "home_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0H2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1918140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("home.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtnotificationsdata", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtnotificationsdata", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_Sdtnotificationsdata", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_103", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_103), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV18Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV18Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERS", AV19Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERS", AV19Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCLICKDATA", AV20ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCLICKDATA", AV20ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMDOUBLECLICKDATA", AV21ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMDOUBLECLICKDATA", AV21ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDRAGANDDROPDATA", AV22DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDRAGANDDROPDATA", AV22DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERCHANGEDDATA", AV23FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERCHANGEDDATA", AV23FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMEXPANDDATA", AV24ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMEXPANDDATA", AV24ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCOLLAPSEDATA", AV25ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCOLLAPSEDATA", AV25ItemCollapseData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD1_PROGRESS_Caption", StringUtil.RTrim( Card1_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARD1_PROGRESS_Cls", StringUtil.RTrim( Card1_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARD1_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card1_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD1_PROGRESS_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card1_progress_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD1_PROGRESS_Circleprogresswidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card1_progress_Circleprogresswidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD1_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_card1_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD1_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_card1_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD1_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_card1_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD1_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_card1_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD1_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_card1_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD1_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_card1_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD1_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_card1_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD1_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_card1_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD1_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_card1_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD1_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_card1_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "CARD2_PROGRESS_Caption", StringUtil.RTrim( Card2_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARD2_PROGRESS_Cls", StringUtil.RTrim( Card2_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARD2_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card2_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD2_PROGRESS_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card2_progress_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD2_PROGRESS_Circleprogresswidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card2_progress_Circleprogresswidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD2_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_card2_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD2_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_card2_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD2_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_card2_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD2_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_card2_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD2_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_card2_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD2_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_card2_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD2_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_card2_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD2_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_card2_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD2_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_card2_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD2_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_card2_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "CARD3_PROGRESS_Caption", StringUtil.RTrim( Card3_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARD3_PROGRESS_Cls", StringUtil.RTrim( Card3_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARD3_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card3_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD3_PROGRESS_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card3_progress_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD3_PROGRESS_Circleprogresswidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card3_progress_Circleprogresswidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD3_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_card3_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD3_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_card3_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD3_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_card3_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD3_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_card3_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD3_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_card3_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD3_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_card3_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD3_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_card3_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD3_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_card3_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD3_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_card3_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD3_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_card3_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "CARD4_PROGRESS_Caption", StringUtil.RTrim( Card4_progress_Caption));
         GxWebStd.gx_hidden_field( context, "CARD4_PROGRESS_Cls", StringUtil.RTrim( Card4_progress_Cls));
         GxWebStd.gx_hidden_field( context, "CARD4_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card4_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD4_PROGRESS_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card4_progress_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARD4_PROGRESS_Circleprogresswidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Card4_progress_Circleprogresswidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD4_MAINTABLE_Width", StringUtil.RTrim( Dvpanel_card4_maintable_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD4_MAINTABLE_Autowidth", StringUtil.BoolToStr( Dvpanel_card4_maintable_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD4_MAINTABLE_Autoheight", StringUtil.BoolToStr( Dvpanel_card4_maintable_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD4_MAINTABLE_Cls", StringUtil.RTrim( Dvpanel_card4_maintable_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD4_MAINTABLE_Title", StringUtil.RTrim( Dvpanel_card4_maintable_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD4_MAINTABLE_Collapsible", StringUtil.BoolToStr( Dvpanel_card4_maintable_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD4_MAINTABLE_Collapsed", StringUtil.BoolToStr( Dvpanel_card4_maintable_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD4_MAINTABLE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_card4_maintable_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD4_MAINTABLE_Iconposition", StringUtil.RTrim( Dvpanel_card4_maintable_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_CARD4_MAINTABLE_Autoscroll", StringUtil.BoolToStr( Dvpanel_card4_maintable_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Height", StringUtil.RTrim( Utchartdoughnut_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Type", StringUtil.RTrim( Utchartdoughnut_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Showvalues", StringUtil.BoolToStr( Utchartdoughnut_Showvalues));
         GxWebStd.gx_hidden_field( context, "UTCHARTDOUGHNUT_Charttype", StringUtil.RTrim( Utchartdoughnut_Charttype));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Width", StringUtil.RTrim( Dvpanel_tablechart3_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart3_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart3_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Cls", StringUtil.RTrim( Dvpanel_tablechart3_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Title", StringUtil.RTrim( Dvpanel_tablechart3_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart3_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart3_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart3_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Iconposition", StringUtil.RTrim( Dvpanel_tablechart3_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART3_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart3_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Height", StringUtil.RTrim( Utchartsmoothline_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Type", StringUtil.RTrim( Utchartsmoothline_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Charttype", StringUtil.RTrim( Utchartsmoothline_Charttype));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Width", StringUtil.RTrim( Dvpanel_tablechart4_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart4_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart4_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Cls", StringUtil.RTrim( Dvpanel_tablechart4_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Title", StringUtil.RTrim( Dvpanel_tablechart4_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart4_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart4_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart4_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Iconposition", StringUtil.RTrim( Dvpanel_tablechart4_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart4_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Type", StringUtil.RTrim( Utchartsmootharea_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Charttype", StringUtil.RTrim( Utchartsmootharea_Charttype));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Width", StringUtil.RTrim( Dvpanel_tablechart1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Cls", StringUtil.RTrim( Dvpanel_tablechart1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Title", StringUtil.RTrim( Dvpanel_tablechart1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Iconposition", StringUtil.RTrim( Dvpanel_tablechart1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Width", StringUtil.RTrim( Dvpanel_tablenotifications_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Cls", StringUtil.RTrim( Dvpanel_tablenotifications_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Title", StringUtil.RTrim( Dvpanel_tablenotifications_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablenotifications_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Iconposition", StringUtil.RTrim( Dvpanel_tablenotifications_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0H2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("home.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Home" ;
      }

      public override string GetPgmdesc( )
      {
         return "Home" ;
      }

      protected void WB0H0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-3 CellMarginTopMedium", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_card1_maintable.SetProperty("Width", Dvpanel_card1_maintable_Width);
            ucDvpanel_card1_maintable.SetProperty("AutoWidth", Dvpanel_card1_maintable_Autowidth);
            ucDvpanel_card1_maintable.SetProperty("AutoHeight", Dvpanel_card1_maintable_Autoheight);
            ucDvpanel_card1_maintable.SetProperty("Cls", Dvpanel_card1_maintable_Cls);
            ucDvpanel_card1_maintable.SetProperty("Title", Dvpanel_card1_maintable_Title);
            ucDvpanel_card1_maintable.SetProperty("Collapsible", Dvpanel_card1_maintable_Collapsible);
            ucDvpanel_card1_maintable.SetProperty("Collapsed", Dvpanel_card1_maintable_Collapsed);
            ucDvpanel_card1_maintable.SetProperty("ShowCollapseIcon", Dvpanel_card1_maintable_Showcollapseicon);
            ucDvpanel_card1_maintable.SetProperty("IconPosition", Dvpanel_card1_maintable_Iconposition);
            ucDvpanel_card1_maintable.SetProperty("AutoScroll", Dvpanel_card1_maintable_Autoscroll);
            ucDvpanel_card1_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_card1_maintable_Internalname, "DVPANEL_CARD1_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARD1_MAINTABLEContainer"+"Card1_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard1_maintable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard1_content_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard1_value_Internalname, "Card1_Value", "col-sm-3 DashboardNumberCardLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_103_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard1_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Card1_Value), 15, 0, ".", "")), StringUtil.LTrim( ((edtavCard1_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8Card1_Value), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV8Card1_Value), "ZZZ,ZZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard1_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCard1_value_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\KPINumericValue", "end", false, "", "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard1_description_Internalname, "Sales", "", "", lblCard1_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCard1_progress.SetProperty("Caption", Card1_progress_Caption);
            ucCard1_progress.SetProperty("Cls", Card1_progress_Cls);
            ucCard1_progress.SetProperty("Percentage", Card1_progress_Percentage);
            ucCard1_progress.SetProperty("CircleWidth", Card1_progress_Circlewidth);
            ucCard1_progress.SetProperty("CircleProgressWidth", Card1_progress_Circleprogresswidth);
            ucCard1_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Card1_progress_Internalname, "CARD1_PROGRESSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-3 CellMarginTopMedium", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_card2_maintable.SetProperty("Width", Dvpanel_card2_maintable_Width);
            ucDvpanel_card2_maintable.SetProperty("AutoWidth", Dvpanel_card2_maintable_Autowidth);
            ucDvpanel_card2_maintable.SetProperty("AutoHeight", Dvpanel_card2_maintable_Autoheight);
            ucDvpanel_card2_maintable.SetProperty("Cls", Dvpanel_card2_maintable_Cls);
            ucDvpanel_card2_maintable.SetProperty("Title", Dvpanel_card2_maintable_Title);
            ucDvpanel_card2_maintable.SetProperty("Collapsible", Dvpanel_card2_maintable_Collapsible);
            ucDvpanel_card2_maintable.SetProperty("Collapsed", Dvpanel_card2_maintable_Collapsed);
            ucDvpanel_card2_maintable.SetProperty("ShowCollapseIcon", Dvpanel_card2_maintable_Showcollapseicon);
            ucDvpanel_card2_maintable.SetProperty("IconPosition", Dvpanel_card2_maintable_Iconposition);
            ucDvpanel_card2_maintable.SetProperty("AutoScroll", Dvpanel_card2_maintable_Autoscroll);
            ucDvpanel_card2_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_card2_maintable_Internalname, "DVPANEL_CARD2_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARD2_MAINTABLEContainer"+"Card2_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard2_maintable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard2_content_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard2_value_Internalname, "Card2_Value", "col-sm-3 DashboardNumberCardLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_103_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard2_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Card2_Value), 15, 0, ".", "")), StringUtil.LTrim( ((edtavCard2_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9Card2_Value), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV9Card2_Value), "ZZZ,ZZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard2_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCard2_value_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\KPINumericValue", "end", false, "", "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard2_description_Internalname, "Revenue", "", "", lblCard2_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCard2_progress.SetProperty("Caption", Card2_progress_Caption);
            ucCard2_progress.SetProperty("Cls", Card2_progress_Cls);
            ucCard2_progress.SetProperty("Percentage", Card2_progress_Percentage);
            ucCard2_progress.SetProperty("CircleWidth", Card2_progress_Circlewidth);
            ucCard2_progress.SetProperty("CircleProgressWidth", Card2_progress_Circleprogresswidth);
            ucCard2_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Card2_progress_Internalname, "CARD2_PROGRESSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-3 CellMarginTopMedium", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_card3_maintable.SetProperty("Width", Dvpanel_card3_maintable_Width);
            ucDvpanel_card3_maintable.SetProperty("AutoWidth", Dvpanel_card3_maintable_Autowidth);
            ucDvpanel_card3_maintable.SetProperty("AutoHeight", Dvpanel_card3_maintable_Autoheight);
            ucDvpanel_card3_maintable.SetProperty("Cls", Dvpanel_card3_maintable_Cls);
            ucDvpanel_card3_maintable.SetProperty("Title", Dvpanel_card3_maintable_Title);
            ucDvpanel_card3_maintable.SetProperty("Collapsible", Dvpanel_card3_maintable_Collapsible);
            ucDvpanel_card3_maintable.SetProperty("Collapsed", Dvpanel_card3_maintable_Collapsed);
            ucDvpanel_card3_maintable.SetProperty("ShowCollapseIcon", Dvpanel_card3_maintable_Showcollapseicon);
            ucDvpanel_card3_maintable.SetProperty("IconPosition", Dvpanel_card3_maintable_Iconposition);
            ucDvpanel_card3_maintable.SetProperty("AutoScroll", Dvpanel_card3_maintable_Autoscroll);
            ucDvpanel_card3_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_card3_maintable_Internalname, "DVPANEL_CARD3_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARD3_MAINTABLEContainer"+"Card3_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard3_maintable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard3_content_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard3_value_Internalname, "Card3_Value", "col-sm-3 DashboardNumberCardLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_103_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard3_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10Card3_Value), 15, 0, ".", "")), StringUtil.LTrim( ((edtavCard3_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10Card3_Value), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV10Card3_Value), "ZZZ,ZZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard3_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCard3_value_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\KPINumericValue", "end", false, "", "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard3_description_Internalname, "Users", "", "", lblCard3_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCard3_progress.SetProperty("Caption", Card3_progress_Caption);
            ucCard3_progress.SetProperty("Cls", Card3_progress_Cls);
            ucCard3_progress.SetProperty("Percentage", Card3_progress_Percentage);
            ucCard3_progress.SetProperty("CircleWidth", Card3_progress_Circlewidth);
            ucCard3_progress.SetProperty("CircleProgressWidth", Card3_progress_Circleprogresswidth);
            ucCard3_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Card3_progress_Internalname, "CARD3_PROGRESSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-3 CellMarginTopMedium", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_card4_maintable.SetProperty("Width", Dvpanel_card4_maintable_Width);
            ucDvpanel_card4_maintable.SetProperty("AutoWidth", Dvpanel_card4_maintable_Autowidth);
            ucDvpanel_card4_maintable.SetProperty("AutoHeight", Dvpanel_card4_maintable_Autoheight);
            ucDvpanel_card4_maintable.SetProperty("Cls", Dvpanel_card4_maintable_Cls);
            ucDvpanel_card4_maintable.SetProperty("Title", Dvpanel_card4_maintable_Title);
            ucDvpanel_card4_maintable.SetProperty("Collapsible", Dvpanel_card4_maintable_Collapsible);
            ucDvpanel_card4_maintable.SetProperty("Collapsed", Dvpanel_card4_maintable_Collapsed);
            ucDvpanel_card4_maintable.SetProperty("ShowCollapseIcon", Dvpanel_card4_maintable_Showcollapseicon);
            ucDvpanel_card4_maintable.SetProperty("IconPosition", Dvpanel_card4_maintable_Iconposition);
            ucDvpanel_card4_maintable.SetProperty("AutoScroll", Dvpanel_card4_maintable_Autoscroll);
            ucDvpanel_card4_maintable.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_card4_maintable_Internalname, "DVPANEL_CARD4_MAINTABLEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_CARD4_MAINTABLEContainer"+"Card4_MainTable"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard4_maintable_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard4_content_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard4_value_Internalname, "Card4_Value", "col-sm-3 DashboardNumberCardLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_103_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard4_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Card4_Value), 15, 0, ".", "")), StringUtil.LTrim( ((edtavCard4_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11Card4_Value), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV11Card4_Value), "ZZZ,ZZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard4_value_Jsonclick, 0, "DashboardNumberCard", "", "", "", "", 1, edtavCard4_value_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\KPINumericValue", "end", false, "", "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard4_description_Internalname, "Views", "", "", lblCard4_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCard4_progress.SetProperty("Caption", Card4_progress_Caption);
            ucCard4_progress.SetProperty("Cls", Card4_progress_Cls);
            ucCard4_progress.SetProperty("Percentage", Card4_progress_Percentage);
            ucCard4_progress.SetProperty("CircleWidth", Card4_progress_Circlewidth);
            ucCard4_progress.SetProperty("CircleProgressWidth", Card4_progress_Circleprogresswidth);
            ucCard4_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Card4_progress_Internalname, "CARD4_PROGRESSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-5 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart3.SetProperty("Width", Dvpanel_tablechart3_Width);
            ucDvpanel_tablechart3.SetProperty("AutoWidth", Dvpanel_tablechart3_Autowidth);
            ucDvpanel_tablechart3.SetProperty("AutoHeight", Dvpanel_tablechart3_Autoheight);
            ucDvpanel_tablechart3.SetProperty("Cls", Dvpanel_tablechart3_Cls);
            ucDvpanel_tablechart3.SetProperty("Title", Dvpanel_tablechart3_Title);
            ucDvpanel_tablechart3.SetProperty("Collapsible", Dvpanel_tablechart3_Collapsible);
            ucDvpanel_tablechart3.SetProperty("Collapsed", Dvpanel_tablechart3_Collapsed);
            ucDvpanel_tablechart3.SetProperty("ShowCollapseIcon", Dvpanel_tablechart3_Showcollapseicon);
            ucDvpanel_tablechart3.SetProperty("IconPosition", Dvpanel_tablechart3_Iconposition);
            ucDvpanel_tablechart3.SetProperty("AutoScroll", Dvpanel_tablechart3_Autoscroll);
            ucDvpanel_tablechart3.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart3_Internalname, "DVPANEL_TABLECHART3Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART3Container"+"TableChart3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart3_Internalname, 1, 0, "px", divTablechart3_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartdoughnut.SetProperty("Elements", AV18Elements);
            ucUtchartdoughnut.SetProperty("Parameters", AV19Parameters);
            ucUtchartdoughnut.SetProperty("Height", Utchartdoughnut_Height);
            ucUtchartdoughnut.SetProperty("Type", Utchartdoughnut_Type);
            ucUtchartdoughnut.SetProperty("Title", Utchartdoughnut_Title);
            ucUtchartdoughnut.SetProperty("ShowValues", Utchartdoughnut_Showvalues);
            ucUtchartdoughnut.SetProperty("ChartType", Utchartdoughnut_Charttype);
            ucUtchartdoughnut.SetProperty("ItemClickData", AV20ItemClickData);
            ucUtchartdoughnut.SetProperty("ItemDoubleClickData", AV21ItemDoubleClickData);
            ucUtchartdoughnut.SetProperty("DragAndDropData", AV22DragAndDropData);
            ucUtchartdoughnut.SetProperty("FilterChangedData", AV23FilterChangedData);
            ucUtchartdoughnut.SetProperty("ItemExpandData", AV24ItemExpandData);
            ucUtchartdoughnut.SetProperty("ItemCollapseData", AV25ItemCollapseData);
            ucUtchartdoughnut.Render(context, "queryviewer", Utchartdoughnut_Internalname, "UTCHARTDOUGHNUTContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-7 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart4.SetProperty("Width", Dvpanel_tablechart4_Width);
            ucDvpanel_tablechart4.SetProperty("AutoWidth", Dvpanel_tablechart4_Autowidth);
            ucDvpanel_tablechart4.SetProperty("AutoHeight", Dvpanel_tablechart4_Autoheight);
            ucDvpanel_tablechart4.SetProperty("Cls", Dvpanel_tablechart4_Cls);
            ucDvpanel_tablechart4.SetProperty("Title", Dvpanel_tablechart4_Title);
            ucDvpanel_tablechart4.SetProperty("Collapsible", Dvpanel_tablechart4_Collapsible);
            ucDvpanel_tablechart4.SetProperty("Collapsed", Dvpanel_tablechart4_Collapsed);
            ucDvpanel_tablechart4.SetProperty("ShowCollapseIcon", Dvpanel_tablechart4_Showcollapseicon);
            ucDvpanel_tablechart4.SetProperty("IconPosition", Dvpanel_tablechart4_Iconposition);
            ucDvpanel_tablechart4.SetProperty("AutoScroll", Dvpanel_tablechart4_Autoscroll);
            ucDvpanel_tablechart4.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart4_Internalname, "DVPANEL_TABLECHART4Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART4Container"+"TableChart4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart4_Internalname, 1, 0, "px", divTablechart4_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartsmoothline.SetProperty("Elements", AV18Elements);
            ucUtchartsmoothline.SetProperty("Parameters", AV19Parameters);
            ucUtchartsmoothline.SetProperty("Height", Utchartsmoothline_Height);
            ucUtchartsmoothline.SetProperty("Type", Utchartsmoothline_Type);
            ucUtchartsmoothline.SetProperty("Title", Utchartsmoothline_Title);
            ucUtchartsmoothline.SetProperty("ChartType", Utchartsmoothline_Charttype);
            ucUtchartsmoothline.SetProperty("ItemClickData", AV20ItemClickData);
            ucUtchartsmoothline.SetProperty("ItemDoubleClickData", AV21ItemDoubleClickData);
            ucUtchartsmoothline.SetProperty("DragAndDropData", AV22DragAndDropData);
            ucUtchartsmoothline.SetProperty("FilterChangedData", AV23FilterChangedData);
            ucUtchartsmoothline.SetProperty("ItemExpandData", AV24ItemExpandData);
            ucUtchartsmoothline.SetProperty("ItemCollapseData", AV25ItemCollapseData);
            ucUtchartsmoothline.Render(context, "queryviewer", Utchartsmoothline_Internalname, "UTCHARTSMOOTHLINEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-7 col-lg-8 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart1.SetProperty("Width", Dvpanel_tablechart1_Width);
            ucDvpanel_tablechart1.SetProperty("AutoWidth", Dvpanel_tablechart1_Autowidth);
            ucDvpanel_tablechart1.SetProperty("AutoHeight", Dvpanel_tablechart1_Autoheight);
            ucDvpanel_tablechart1.SetProperty("Cls", Dvpanel_tablechart1_Cls);
            ucDvpanel_tablechart1.SetProperty("Title", Dvpanel_tablechart1_Title);
            ucDvpanel_tablechart1.SetProperty("Collapsible", Dvpanel_tablechart1_Collapsible);
            ucDvpanel_tablechart1.SetProperty("Collapsed", Dvpanel_tablechart1_Collapsed);
            ucDvpanel_tablechart1.SetProperty("ShowCollapseIcon", Dvpanel_tablechart1_Showcollapseicon);
            ucDvpanel_tablechart1.SetProperty("IconPosition", Dvpanel_tablechart1_Iconposition);
            ucDvpanel_tablechart1.SetProperty("AutoScroll", Dvpanel_tablechart1_Autoscroll);
            ucDvpanel_tablechart1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart1_Internalname, "DVPANEL_TABLECHART1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART1Container"+"TableChart1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart1_Internalname, 1, 0, "px", divTablechart1_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartsmootharea.SetProperty("Elements", AV18Elements);
            ucUtchartsmootharea.SetProperty("Parameters", AV19Parameters);
            ucUtchartsmootharea.SetProperty("Type", Utchartsmootharea_Type);
            ucUtchartsmootharea.SetProperty("Title", Utchartsmootharea_Title);
            ucUtchartsmootharea.SetProperty("ChartType", Utchartsmootharea_Charttype);
            ucUtchartsmootharea.SetProperty("ItemClickData", AV20ItemClickData);
            ucUtchartsmootharea.SetProperty("ItemDoubleClickData", AV21ItemDoubleClickData);
            ucUtchartsmootharea.SetProperty("DragAndDropData", AV22DragAndDropData);
            ucUtchartsmootharea.SetProperty("FilterChangedData", AV23FilterChangedData);
            ucUtchartsmootharea.SetProperty("ItemExpandData", AV24ItemExpandData);
            ucUtchartsmootharea.SetProperty("ItemCollapseData", AV25ItemCollapseData);
            ucUtchartsmootharea.Render(context, "queryviewer", Utchartsmootharea_Internalname, "UTCHARTSMOOTHAREAContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-5 col-lg-4 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablenotifications.SetProperty("Width", Dvpanel_tablenotifications_Width);
            ucDvpanel_tablenotifications.SetProperty("AutoWidth", Dvpanel_tablenotifications_Autowidth);
            ucDvpanel_tablenotifications.SetProperty("AutoHeight", Dvpanel_tablenotifications_Autoheight);
            ucDvpanel_tablenotifications.SetProperty("Cls", Dvpanel_tablenotifications_Cls);
            ucDvpanel_tablenotifications.SetProperty("Title", Dvpanel_tablenotifications_Title);
            ucDvpanel_tablenotifications.SetProperty("Collapsible", Dvpanel_tablenotifications_Collapsible);
            ucDvpanel_tablenotifications.SetProperty("Collapsed", Dvpanel_tablenotifications_Collapsed);
            ucDvpanel_tablenotifications.SetProperty("ShowCollapseIcon", Dvpanel_tablenotifications_Showcollapseicon);
            ucDvpanel_tablenotifications.SetProperty("IconPosition", Dvpanel_tablenotifications_Iconposition);
            ucDvpanel_tablenotifications.SetProperty("AutoScroll", Dvpanel_tablenotifications_Autoscroll);
            ucDvpanel_tablenotifications.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablenotifications_Internalname, "DVPANEL_TABLENOTIFICATIONSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLENOTIFICATIONSContainer"+"TableNotifications"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotifications_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 NotificationSubtitleCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationssubtitle_Internalname, lblNotificationssubtitle_Caption, "", "", lblNotificationssubtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 GridNoBorderNoHeader CellMarginTop HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl103( ) ;
         }
         if ( wbEnd == 103 )
         {
            wbEnd = 0;
            nRC_GXsfl_103 = (int)(nGXsfl_103_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               AV29GXV1 = nGXsfl_103_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 103 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  AV29GXV1 = nGXsfl_103_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0H2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Home", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0H0( ) ;
      }

      protected void WS0H2( )
      {
         START0H2( ) ;
         EVT0H2( ) ;
      }

      protected void EVT0H2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_103_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
                              SubsflControlProps_1032( ) ;
                              AV29GXV1 = (int)(nGXsfl_103_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV7SDTNotificationsData.Count >= AV29GXV1 ) && ( AV29GXV1 > 0 ) )
                              {
                                 AV7SDTNotificationsData.CurrentItem = ((WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV29GXV1));
                                 AV6NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
                                 AssignAttri("", false, edtavNotificationicon_Internalname, AV6NotificationIcon);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E120H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0H2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavCard1_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1032( ) ;
         while ( nGXsfl_103_idx <= nRC_GXsfl_103 )
         {
            sendrow_1032( ) ;
            nGXsfl_103_idx = ((subGrid_Islastpage==1)&&(nGXsfl_103_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_103_idx+1);
            sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
            SubsflControlProps_1032( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> AV7SDTNotificationsData )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavCard1_value_Enabled = 0;
         AssignProp("", false, edtavCard1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard1_value_Enabled), 5, 0), true);
         edtavCard2_value_Enabled = 0;
         AssignProp("", false, edtavCard2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard2_value_Enabled), 5, 0), true);
         edtavCard3_value_Enabled = 0;
         AssignProp("", false, edtavCard3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard3_value_Enabled), 5, 0), true);
         edtavCard4_value_Enabled = 0;
         AssignProp("", false, edtavCard4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard4_value_Enabled), 5, 0), true);
         edtavNotificationicon_Enabled = 0;
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
      }

      protected void RF0H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 103;
         nGXsfl_103_idx = 1;
         sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
         SubsflControlProps_1032( ) ;
         bGXsfl_103_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1032( ) ;
            /* Execute user event: Grid.Load */
            E120H2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_103_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E120H2 ();
            }
            wbEnd = 103;
            WB0H0( ) ;
         }
         bGXsfl_103_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0H2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return AV7SDTNotificationsData.Count ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavCard1_value_Enabled = 0;
         AssignProp("", false, edtavCard1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard1_value_Enabled), 5, 0), true);
         edtavCard2_value_Enabled = 0;
         AssignProp("", false, edtavCard2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard2_value_Enabled), 5, 0), true);
         edtavCard3_value_Enabled = 0;
         AssignProp("", false, edtavCard3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard3_value_Enabled), 5, 0), true);
         edtavCard4_value_Enabled = 0;
         AssignProp("", false, edtavCard4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard4_value_Enabled), 5, 0), true);
         edtavNotificationicon_Enabled = 0;
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtnotificationsdata"), AV7SDTNotificationsData);
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV18Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERS"), AV19Parameters);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCLICKDATA"), AV20ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMDOUBLECLICKDATA"), AV21ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vDRAGANDDROPDATA"), AV22DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERCHANGEDDATA"), AV23FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMEXPANDDATA"), AV24ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCOLLAPSEDATA"), AV25ItemCollapseData);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTNOTIFICATIONSDATA"), AV7SDTNotificationsData);
            /* Read saved values. */
            nRC_GXsfl_103 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_103"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Card1_progress_Caption = cgiGet( "CARD1_PROGRESS_Caption");
            Card1_progress_Cls = cgiGet( "CARD1_PROGRESS_Cls");
            Card1_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD1_PROGRESS_Percentage"), ".", ","), 18, MidpointRounding.ToEven));
            Card1_progress_Circlewidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD1_PROGRESS_Circlewidth"), ".", ","), 18, MidpointRounding.ToEven));
            Card1_progress_Circleprogresswidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD1_PROGRESS_Circleprogresswidth"), ".", ","), 18, MidpointRounding.ToEven));
            Dvpanel_card1_maintable_Width = cgiGet( "DVPANEL_CARD1_MAINTABLE_Width");
            Dvpanel_card1_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD1_MAINTABLE_Autowidth"));
            Dvpanel_card1_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD1_MAINTABLE_Autoheight"));
            Dvpanel_card1_maintable_Cls = cgiGet( "DVPANEL_CARD1_MAINTABLE_Cls");
            Dvpanel_card1_maintable_Title = cgiGet( "DVPANEL_CARD1_MAINTABLE_Title");
            Dvpanel_card1_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD1_MAINTABLE_Collapsible"));
            Dvpanel_card1_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD1_MAINTABLE_Collapsed"));
            Dvpanel_card1_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD1_MAINTABLE_Showcollapseicon"));
            Dvpanel_card1_maintable_Iconposition = cgiGet( "DVPANEL_CARD1_MAINTABLE_Iconposition");
            Dvpanel_card1_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD1_MAINTABLE_Autoscroll"));
            Card2_progress_Caption = cgiGet( "CARD2_PROGRESS_Caption");
            Card2_progress_Cls = cgiGet( "CARD2_PROGRESS_Cls");
            Card2_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD2_PROGRESS_Percentage"), ".", ","), 18, MidpointRounding.ToEven));
            Card2_progress_Circlewidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD2_PROGRESS_Circlewidth"), ".", ","), 18, MidpointRounding.ToEven));
            Card2_progress_Circleprogresswidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD2_PROGRESS_Circleprogresswidth"), ".", ","), 18, MidpointRounding.ToEven));
            Dvpanel_card2_maintable_Width = cgiGet( "DVPANEL_CARD2_MAINTABLE_Width");
            Dvpanel_card2_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD2_MAINTABLE_Autowidth"));
            Dvpanel_card2_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD2_MAINTABLE_Autoheight"));
            Dvpanel_card2_maintable_Cls = cgiGet( "DVPANEL_CARD2_MAINTABLE_Cls");
            Dvpanel_card2_maintable_Title = cgiGet( "DVPANEL_CARD2_MAINTABLE_Title");
            Dvpanel_card2_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD2_MAINTABLE_Collapsible"));
            Dvpanel_card2_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD2_MAINTABLE_Collapsed"));
            Dvpanel_card2_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD2_MAINTABLE_Showcollapseicon"));
            Dvpanel_card2_maintable_Iconposition = cgiGet( "DVPANEL_CARD2_MAINTABLE_Iconposition");
            Dvpanel_card2_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD2_MAINTABLE_Autoscroll"));
            Card3_progress_Caption = cgiGet( "CARD3_PROGRESS_Caption");
            Card3_progress_Cls = cgiGet( "CARD3_PROGRESS_Cls");
            Card3_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD3_PROGRESS_Percentage"), ".", ","), 18, MidpointRounding.ToEven));
            Card3_progress_Circlewidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD3_PROGRESS_Circlewidth"), ".", ","), 18, MidpointRounding.ToEven));
            Card3_progress_Circleprogresswidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD3_PROGRESS_Circleprogresswidth"), ".", ","), 18, MidpointRounding.ToEven));
            Dvpanel_card3_maintable_Width = cgiGet( "DVPANEL_CARD3_MAINTABLE_Width");
            Dvpanel_card3_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD3_MAINTABLE_Autowidth"));
            Dvpanel_card3_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD3_MAINTABLE_Autoheight"));
            Dvpanel_card3_maintable_Cls = cgiGet( "DVPANEL_CARD3_MAINTABLE_Cls");
            Dvpanel_card3_maintable_Title = cgiGet( "DVPANEL_CARD3_MAINTABLE_Title");
            Dvpanel_card3_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD3_MAINTABLE_Collapsible"));
            Dvpanel_card3_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD3_MAINTABLE_Collapsed"));
            Dvpanel_card3_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD3_MAINTABLE_Showcollapseicon"));
            Dvpanel_card3_maintable_Iconposition = cgiGet( "DVPANEL_CARD3_MAINTABLE_Iconposition");
            Dvpanel_card3_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD3_MAINTABLE_Autoscroll"));
            Card4_progress_Caption = cgiGet( "CARD4_PROGRESS_Caption");
            Card4_progress_Cls = cgiGet( "CARD4_PROGRESS_Cls");
            Card4_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD4_PROGRESS_Percentage"), ".", ","), 18, MidpointRounding.ToEven));
            Card4_progress_Circlewidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD4_PROGRESS_Circlewidth"), ".", ","), 18, MidpointRounding.ToEven));
            Card4_progress_Circleprogresswidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CARD4_PROGRESS_Circleprogresswidth"), ".", ","), 18, MidpointRounding.ToEven));
            Dvpanel_card4_maintable_Width = cgiGet( "DVPANEL_CARD4_MAINTABLE_Width");
            Dvpanel_card4_maintable_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD4_MAINTABLE_Autowidth"));
            Dvpanel_card4_maintable_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD4_MAINTABLE_Autoheight"));
            Dvpanel_card4_maintable_Cls = cgiGet( "DVPANEL_CARD4_MAINTABLE_Cls");
            Dvpanel_card4_maintable_Title = cgiGet( "DVPANEL_CARD4_MAINTABLE_Title");
            Dvpanel_card4_maintable_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD4_MAINTABLE_Collapsible"));
            Dvpanel_card4_maintable_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD4_MAINTABLE_Collapsed"));
            Dvpanel_card4_maintable_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD4_MAINTABLE_Showcollapseicon"));
            Dvpanel_card4_maintable_Iconposition = cgiGet( "DVPANEL_CARD4_MAINTABLE_Iconposition");
            Dvpanel_card4_maintable_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_CARD4_MAINTABLE_Autoscroll"));
            Utchartdoughnut_Height = cgiGet( "UTCHARTDOUGHNUT_Height");
            Utchartdoughnut_Type = cgiGet( "UTCHARTDOUGHNUT_Type");
            Utchartdoughnut_Showvalues = StringUtil.StrToBool( cgiGet( "UTCHARTDOUGHNUT_Showvalues"));
            Utchartdoughnut_Charttype = cgiGet( "UTCHARTDOUGHNUT_Charttype");
            Dvpanel_tablechart3_Width = cgiGet( "DVPANEL_TABLECHART3_Width");
            Dvpanel_tablechart3_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Autowidth"));
            Dvpanel_tablechart3_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Autoheight"));
            Dvpanel_tablechart3_Cls = cgiGet( "DVPANEL_TABLECHART3_Cls");
            Dvpanel_tablechart3_Title = cgiGet( "DVPANEL_TABLECHART3_Title");
            Dvpanel_tablechart3_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Collapsible"));
            Dvpanel_tablechart3_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Collapsed"));
            Dvpanel_tablechart3_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Showcollapseicon"));
            Dvpanel_tablechart3_Iconposition = cgiGet( "DVPANEL_TABLECHART3_Iconposition");
            Dvpanel_tablechart3_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART3_Autoscroll"));
            Utchartsmoothline_Height = cgiGet( "UTCHARTSMOOTHLINE_Height");
            Utchartsmoothline_Type = cgiGet( "UTCHARTSMOOTHLINE_Type");
            Utchartsmoothline_Charttype = cgiGet( "UTCHARTSMOOTHLINE_Charttype");
            Dvpanel_tablechart4_Width = cgiGet( "DVPANEL_TABLECHART4_Width");
            Dvpanel_tablechart4_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autowidth"));
            Dvpanel_tablechart4_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autoheight"));
            Dvpanel_tablechart4_Cls = cgiGet( "DVPANEL_TABLECHART4_Cls");
            Dvpanel_tablechart4_Title = cgiGet( "DVPANEL_TABLECHART4_Title");
            Dvpanel_tablechart4_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Collapsible"));
            Dvpanel_tablechart4_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Collapsed"));
            Dvpanel_tablechart4_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Showcollapseicon"));
            Dvpanel_tablechart4_Iconposition = cgiGet( "DVPANEL_TABLECHART4_Iconposition");
            Dvpanel_tablechart4_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autoscroll"));
            Utchartsmootharea_Type = cgiGet( "UTCHARTSMOOTHAREA_Type");
            Utchartsmootharea_Charttype = cgiGet( "UTCHARTSMOOTHAREA_Charttype");
            Dvpanel_tablechart1_Width = cgiGet( "DVPANEL_TABLECHART1_Width");
            Dvpanel_tablechart1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autowidth"));
            Dvpanel_tablechart1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoheight"));
            Dvpanel_tablechart1_Cls = cgiGet( "DVPANEL_TABLECHART1_Cls");
            Dvpanel_tablechart1_Title = cgiGet( "DVPANEL_TABLECHART1_Title");
            Dvpanel_tablechart1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsible"));
            Dvpanel_tablechart1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsed"));
            Dvpanel_tablechart1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Showcollapseicon"));
            Dvpanel_tablechart1_Iconposition = cgiGet( "DVPANEL_TABLECHART1_Iconposition");
            Dvpanel_tablechart1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoscroll"));
            Dvpanel_tablenotifications_Width = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Width");
            Dvpanel_tablenotifications_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autowidth"));
            Dvpanel_tablenotifications_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoheight"));
            Dvpanel_tablenotifications_Cls = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Cls");
            Dvpanel_tablenotifications_Title = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Title");
            Dvpanel_tablenotifications_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsible"));
            Dvpanel_tablenotifications_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsed"));
            Dvpanel_tablenotifications_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon"));
            Dvpanel_tablenotifications_Iconposition = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Iconposition");
            Dvpanel_tablenotifications_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoscroll"));
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            nRC_GXsfl_103 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_103"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_103_fel_idx = 0;
            while ( nGXsfl_103_fel_idx < nRC_GXsfl_103 )
            {
               nGXsfl_103_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_103_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_103_fel_idx+1);
               sGXsfl_103_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1032( ) ;
               AV29GXV1 = (int)(nGXsfl_103_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV7SDTNotificationsData.Count >= AV29GXV1 ) && ( AV29GXV1 > 0 ) )
               {
                  AV7SDTNotificationsData.CurrentItem = ((WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV29GXV1));
                  AV6NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
               }
            }
            if ( nGXsfl_103_fel_idx == 0 )
            {
               nGXsfl_103_idx = 1;
               sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
               SubsflControlProps_1032( ) ;
            }
            nGXsfl_103_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard1_value_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard1_value_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD1_VALUE");
               GX_FocusControl = edtavCard1_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Card1_Value = 0;
               AssignAttri("", false, "AV8Card1_Value", StringUtil.LTrimStr( (decimal)(AV8Card1_Value), 12, 0));
            }
            else
            {
               AV8Card1_Value = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCard1_value_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8Card1_Value", StringUtil.LTrimStr( (decimal)(AV8Card1_Value), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard2_value_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard2_value_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD2_VALUE");
               GX_FocusControl = edtavCard2_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9Card2_Value = 0;
               AssignAttri("", false, "AV9Card2_Value", StringUtil.LTrimStr( (decimal)(AV9Card2_Value), 12, 0));
            }
            else
            {
               AV9Card2_Value = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCard2_value_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9Card2_Value", StringUtil.LTrimStr( (decimal)(AV9Card2_Value), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard3_value_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard3_value_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD3_VALUE");
               GX_FocusControl = edtavCard3_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10Card3_Value = 0;
               AssignAttri("", false, "AV10Card3_Value", StringUtil.LTrimStr( (decimal)(AV10Card3_Value), 12, 0));
            }
            else
            {
               AV10Card3_Value = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCard3_value_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10Card3_Value", StringUtil.LTrimStr( (decimal)(AV10Card3_Value), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard4_value_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard4_value_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD4_VALUE");
               GX_FocusControl = edtavCard4_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11Card4_Value = 0;
               AssignAttri("", false, "AV11Card4_Value", StringUtil.LTrimStr( (decimal)(AV11Card4_Value), 12, 0));
            }
            else
            {
               AV11Card4_Value = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCard4_value_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Card4_Value", StringUtil.LTrimStr( (decimal)(AV11Card4_Value), 12, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110H2 ();
         if (returnInSub) return;
      }

      protected void E110H2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV8Card1_Value = 352;
         AssignAttri("", false, "AV8Card1_Value", StringUtil.LTrimStr( (decimal)(AV8Card1_Value), 12, 0));
         AV9Card2_Value = 7552;
         AssignAttri("", false, "AV9Card2_Value", StringUtil.LTrimStr( (decimal)(AV9Card2_Value), 12, 0));
         AV10Card3_Value = 825;
         AssignAttri("", false, "AV10Card3_Value", StringUtil.LTrimStr( (decimal)(AV10Card3_Value), 12, 0));
         AV11Card4_Value = 2540;
         AssignAttri("", false, "AV11Card4_Value", StringUtil.LTrimStr( (decimal)(AV11Card4_Value), 12, 0));
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 = AV5HomeSampleData;
         new WorkWithPlus.workwithplus_web.gethomesampledata(context ).execute( out  GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1) ;
         AV5HomeSampleData = GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1;
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "ProductStatus";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "Check";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         GXt_objcol_SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem2 = AV7SDTNotificationsData;
         new WorkWithPlus.workwithplus_web.getnotificationsamples(context ).execute( out  GXt_objcol_SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem2) ;
         AV7SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem2;
         gx_BV103 = true;
         if ( AV7SDTNotificationsData.Count == 0 )
         {
            lblNotificationssubtitle_Caption = "No new notifications";
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         else if ( AV7SDTNotificationsData.Count == 1 )
         {
            lblNotificationssubtitle_Caption = "You have 1 new notification";
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         else
         {
            lblNotificationssubtitle_Caption = StringUtil.Format( "You have %1 new notifications", StringUtil.Trim( StringUtil.Str( (decimal)(AV7SDTNotificationsData.Count), 9, 0)), "", "", "", "", "", "", "", "");
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         AV14Card1_ProgressValue = (decimal)(20);
         AV15Card2_ProgressValue = (decimal)(30);
         AV16Card3_ProgressValue = (decimal)(40);
         AV17Card4_ProgressValue = (decimal)(60);
         divTablechart1_Height = 447;
         AssignProp("", false, divTablechart1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart1_Height), 9, 0), true);
         divTablechart4_Height = 427;
         AssignProp("", false, divTablechart4_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart4_Height), 9, 0), true);
         divTablechart3_Height = 427;
         AssignProp("", false, divTablechart3_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart3_Height), 9, 0), true);
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Card1_progress_Percentage = (int)(Math.Round(AV14Card1_ProgressValue, 18, MidpointRounding.ToEven));
         ucCard1_progress.SendProperty(context, "", false, Card1_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Card1_progress_Percentage), 9, 0));
         Card1_progress_Caption = context.localUtil.Format( AV14Card1_ProgressValue, "Z9%");
         ucCard1_progress.SendProperty(context, "", false, Card1_progress_Internalname, "Caption", Card1_progress_Caption);
         Card2_progress_Percentage = (int)(Math.Round(AV15Card2_ProgressValue, 18, MidpointRounding.ToEven));
         ucCard2_progress.SendProperty(context, "", false, Card2_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Card2_progress_Percentage), 9, 0));
         Card2_progress_Caption = context.localUtil.Format( AV15Card2_ProgressValue, "Z9%");
         ucCard2_progress.SendProperty(context, "", false, Card2_progress_Internalname, "Caption", Card2_progress_Caption);
         Card3_progress_Percentage = (int)(Math.Round(AV16Card3_ProgressValue, 18, MidpointRounding.ToEven));
         ucCard3_progress.SendProperty(context, "", false, Card3_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Card3_progress_Percentage), 9, 0));
         Card3_progress_Caption = context.localUtil.Format( AV16Card3_ProgressValue, "Z9%");
         ucCard3_progress.SendProperty(context, "", false, Card3_progress_Internalname, "Caption", Card3_progress_Caption);
         Card4_progress_Percentage = (int)(Math.Round(AV17Card4_ProgressValue, 18, MidpointRounding.ToEven));
         ucCard4_progress.SendProperty(context, "", false, Card4_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Card4_progress_Percentage), 9, 0));
         Card4_progress_Caption = context.localUtil.Format( AV17Card4_ProgressValue, "Z9%");
         ucCard4_progress.SendProperty(context, "", false, Card4_progress_Internalname, "Caption", Card4_progress_Caption);
      }

      private void E120H2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV29GXV1 = 1;
         while ( AV29GXV1 <= AV7SDTNotificationsData.Count )
         {
            AV7SDTNotificationsData.CurrentItem = ((WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV29GXV1));
            edtavNotificationicon_Format = 2;
            AV6NotificationIcon = StringUtil.Format( "<i class=\"%1 %2\"></i>", ((WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)(AV7SDTNotificationsData.CurrentItem)).gxTpr_Notificationiconclass, "NotificationFontIconGrid", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavNotificationicon_Internalname, AV6NotificationIcon);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 103;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1032( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_103_Refreshing )
            {
               DoAjaxLoad(103, GridRow);
            }
            AV29GXV1 = (int)(AV29GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0H2( ) ;
         WS0H2( ) ;
         WE0H2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202571210113", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("home.js", "?202571210114", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1032( )
      {
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON_"+sGXsfl_103_idx;
         edtavSdtnotificationsdata__notificationiconclass_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_103_idx;
         edtavSdtnotificationsdata__notificationtitle_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_103_idx;
         edtavSdtnotificationsdata__notificationdatetime_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_103_idx;
      }

      protected void SubsflControlProps_fel_1032( )
      {
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON_"+sGXsfl_103_fel_idx;
         edtavSdtnotificationsdata__notificationiconclass_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_103_fel_idx;
         edtavSdtnotificationsdata__notificationtitle_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_103_fel_idx;
         edtavSdtnotificationsdata__notificationdatetime_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_103_fel_idx;
      }

      protected void sendrow_1032( )
      {
         sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
         SubsflControlProps_1032( ) ;
         WB0H0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_103_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_103_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_103_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_103_idx + "',103)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationicon_Internalname,(string)AV6NotificationIcon,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationicon_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNotificationicon_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)edtavNotificationicon_Format,(short)103,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationiconclass_Internalname,((WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV29GXV1)).gxTpr_Notificationiconclass,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationiconclass_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtnotificationsdata__notificationiconclass_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)103,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_103_idx + "',103)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationtitle_Internalname,((WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV29GXV1)).gxTpr_Notificationtitle,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationtitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtnotificationsdata__notificationtitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)103,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_103_idx + "',103)\"";
            ROClassString = "AttributeSecondary";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationdatetime_Internalname,context.localUtil.TToC( ((WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV29GXV1)).gxTpr_Notificationdatetime, 10, 8, 1, 3, "/", ":", " "),context.localUtil.Format( ((WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV29GXV1)).gxTpr_Notificationdatetime, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,12,'eng',false,0);"+";gx.evt.onblur(this,107);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationdatetime_Jsonclick,(short)0,(string)"AttributeSecondary",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtnotificationsdata__notificationdatetime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)103,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes0H2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_103_idx = ((subGrid_Islastpage==1)&&(nGXsfl_103_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_103_idx+1);
            sGXsfl_103_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_103_idx), 4, 0), 4, "0");
            SubsflControlProps_1032( ) ;
         }
         /* End function sendrow_1032 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl103( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"103\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Notification Icon Class") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Title") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeSecondary"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Datetime") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV6NotificationIcon));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Format", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon_Format), 4, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationiconclass_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavCard1_value_Internalname = "vCARD1_VALUE";
         lblCard1_description_Internalname = "CARD1_DESCRIPTION";
         divCard1_content_Internalname = "CARD1_CONTENT";
         Card1_progress_Internalname = "CARD1_PROGRESS";
         divCard1_maintable_Internalname = "CARD1_MAINTABLE";
         Dvpanel_card1_maintable_Internalname = "DVPANEL_CARD1_MAINTABLE";
         edtavCard2_value_Internalname = "vCARD2_VALUE";
         lblCard2_description_Internalname = "CARD2_DESCRIPTION";
         divCard2_content_Internalname = "CARD2_CONTENT";
         Card2_progress_Internalname = "CARD2_PROGRESS";
         divCard2_maintable_Internalname = "CARD2_MAINTABLE";
         Dvpanel_card2_maintable_Internalname = "DVPANEL_CARD2_MAINTABLE";
         edtavCard3_value_Internalname = "vCARD3_VALUE";
         lblCard3_description_Internalname = "CARD3_DESCRIPTION";
         divCard3_content_Internalname = "CARD3_CONTENT";
         Card3_progress_Internalname = "CARD3_PROGRESS";
         divCard3_maintable_Internalname = "CARD3_MAINTABLE";
         Dvpanel_card3_maintable_Internalname = "DVPANEL_CARD3_MAINTABLE";
         edtavCard4_value_Internalname = "vCARD4_VALUE";
         lblCard4_description_Internalname = "CARD4_DESCRIPTION";
         divCard4_content_Internalname = "CARD4_CONTENT";
         Card4_progress_Internalname = "CARD4_PROGRESS";
         divCard4_maintable_Internalname = "CARD4_MAINTABLE";
         Dvpanel_card4_maintable_Internalname = "DVPANEL_CARD4_MAINTABLE";
         divTablecards_Internalname = "TABLECARDS";
         Utchartdoughnut_Internalname = "UTCHARTDOUGHNUT";
         divTablechart3_Internalname = "TABLECHART3";
         Dvpanel_tablechart3_Internalname = "DVPANEL_TABLECHART3";
         Utchartsmoothline_Internalname = "UTCHARTSMOOTHLINE";
         divTablechart4_Internalname = "TABLECHART4";
         Dvpanel_tablechart4_Internalname = "DVPANEL_TABLECHART4";
         Utchartsmootharea_Internalname = "UTCHARTSMOOTHAREA";
         divTablechart1_Internalname = "TABLECHART1";
         Dvpanel_tablechart1_Internalname = "DVPANEL_TABLECHART1";
         lblNotificationssubtitle_Internalname = "NOTIFICATIONSSUBTITLE";
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON";
         edtavSdtnotificationsdata__notificationiconclass_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS";
         edtavSdtnotificationsdata__notificationtitle_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE";
         edtavSdtnotificationsdata__notificationdatetime_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME";
         divTablenotifications_Internalname = "TABLENOTIFICATIONS";
         Dvpanel_tablenotifications_Internalname = "DVPANEL_TABLENOTIFICATIONS";
         divTablemain_Internalname = "TABLEMAIN";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavSdtnotificationsdata__notificationdatetime_Jsonclick = "";
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavSdtnotificationsdata__notificationtitle_Jsonclick = "";
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavSdtnotificationsdata__notificationiconclass_Jsonclick = "";
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavNotificationicon_Jsonclick = "";
         edtavNotificationicon_Enabled = 0;
         edtavNotificationicon_Format = 1;
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSdtnotificationsdata__notificationdatetime_Enabled = -1;
         edtavSdtnotificationsdata__notificationtitle_Enabled = -1;
         edtavSdtnotificationsdata__notificationiconclass_Enabled = -1;
         lblNotificationssubtitle_Caption = "You have %1 new notifications";
         Utchartsmootharea_Title = "";
         divTablechart1_Height = 0;
         Utchartsmoothline_Title = "";
         divTablechart4_Height = 0;
         Utchartdoughnut_Title = "";
         divTablechart3_Height = 0;
         edtavCard4_value_Jsonclick = "";
         edtavCard4_value_Enabled = 1;
         edtavCard3_value_Jsonclick = "";
         edtavCard3_value_Enabled = 1;
         edtavCard2_value_Jsonclick = "";
         edtavCard2_value_Enabled = 1;
         edtavCard1_value_Jsonclick = "";
         edtavCard1_value_Enabled = 1;
         Dvpanel_tablenotifications_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Iconposition = "Right";
         Dvpanel_tablenotifications_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Title = "Notifications";
         Dvpanel_tablenotifications_Cls = "PanelCard_GrayTitle";
         Dvpanel_tablenotifications_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablenotifications_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Width = "100%";
         Dvpanel_tablechart1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Iconposition = "Right";
         Dvpanel_tablechart1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Title = "Sales Table";
         Dvpanel_tablechart1_Cls = "PanelCard_GrayTitle";
         Dvpanel_tablechart1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Width = "100%";
         Utchartsmootharea_Charttype = "StackedArea";
         Utchartsmootharea_Type = "Chart";
         Dvpanel_tablechart4_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Iconposition = "Right";
         Dvpanel_tablechart4_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Title = "Task Board";
         Dvpanel_tablechart4_Cls = "PanelCard_GrayTitle";
         Dvpanel_tablechart4_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart4_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Width = "100%";
         Utchartsmoothline_Charttype = "SmoothLine";
         Utchartsmoothline_Type = "Chart";
         Utchartsmoothline_Height = "450";
         Dvpanel_tablechart3_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Iconposition = "Right";
         Dvpanel_tablechart3_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Title = "Orders";
         Dvpanel_tablechart3_Cls = "PanelCard_GrayTitle";
         Dvpanel_tablechart3_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart3_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart3_Width = "100%";
         Utchartdoughnut_Charttype = "Doughnut";
         Utchartdoughnut_Showvalues = Convert.ToBoolean( 0);
         Utchartdoughnut_Type = "Chart";
         Utchartdoughnut_Height = "450";
         Dvpanel_card4_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_card4_maintable_Iconposition = "Right";
         Dvpanel_card4_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_card4_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_card4_maintable_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_card4_maintable_Title = "";
         Dvpanel_card4_maintable_Cls = "PanelNoHeader";
         Dvpanel_card4_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_card4_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_card4_maintable_Width = "100%";
         Card4_progress_Circleprogresswidth = 5;
         Card4_progress_Circlewidth = 80;
         Card4_progress_Percentage = 20;
         Card4_progress_Cls = "Progress ProgressDanger";
         Card4_progress_Caption = "20%";
         Dvpanel_card3_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_card3_maintable_Iconposition = "Right";
         Dvpanel_card3_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_card3_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_card3_maintable_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_card3_maintable_Title = "";
         Dvpanel_card3_maintable_Cls = "PanelNoHeader";
         Dvpanel_card3_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_card3_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_card3_maintable_Width = "100%";
         Card3_progress_Circleprogresswidth = 5;
         Card3_progress_Circlewidth = 80;
         Card3_progress_Percentage = 20;
         Card3_progress_Cls = "Progress ProgressWarning";
         Card3_progress_Caption = "20%";
         Dvpanel_card2_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_card2_maintable_Iconposition = "Right";
         Dvpanel_card2_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_card2_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_card2_maintable_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_card2_maintable_Title = "";
         Dvpanel_card2_maintable_Cls = "PanelNoHeader";
         Dvpanel_card2_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_card2_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_card2_maintable_Width = "100%";
         Card2_progress_Circleprogresswidth = 5;
         Card2_progress_Circlewidth = 80;
         Card2_progress_Percentage = 20;
         Card2_progress_Cls = "Progress ProgressInfoLight";
         Card2_progress_Caption = "20%";
         Dvpanel_card1_maintable_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_card1_maintable_Iconposition = "Right";
         Dvpanel_card1_maintable_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_card1_maintable_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_card1_maintable_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_card1_maintable_Title = "";
         Dvpanel_card1_maintable_Cls = "PanelNoHeader";
         Dvpanel_card1_maintable_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_card1_maintable_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_card1_maintable_Width = "100%";
         Card1_progress_Circleprogresswidth = 5;
         Card1_progress_Circlewidth = 80;
         Card1_progress_Percentage = 20;
         Card1_progress_Cls = "Progress ProgressInfo";
         Card1_progress_Caption = "20%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Home";
         subGrid_Rows = 0;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV7SDTNotificationsData","fld":"vSDTNOTIFICATIONSDATA","grid":103,"hsh":true},{"av":"nGXsfl_103_idx","ctrl":"GRID","prop":"GridCurrRow","grid":103},{"av":"nRC_GXsfl_103","ctrl":"GRID","prop":"GridRC","grid":103}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E120H2","iparms":[{"av":"AV7SDTNotificationsData","fld":"vSDTNOTIFICATIONSDATA","grid":103,"hsh":true},{"av":"nGXsfl_103_idx","ctrl":"GRID","prop":"GridCurrRow","grid":103},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_103","ctrl":"GRID","prop":"GridRC","grid":103}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtavNotificationicon_Format","ctrl":"vNOTIFICATIONICON","prop":"Format"},{"av":"AV6NotificationIcon","fld":"vNOTIFICATIONICON"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV7SDTNotificationsData","fld":"vSDTNOTIFICATIONSDATA","grid":103,"hsh":true},{"av":"nGXsfl_103_idx","ctrl":"GRID","prop":"GridCurrRow","grid":103},{"av":"nRC_GXsfl_103","ctrl":"GRID","prop":"GridRC","grid":103}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV7SDTNotificationsData","fld":"vSDTNOTIFICATIONSDATA","grid":103,"hsh":true},{"av":"nGXsfl_103_idx","ctrl":"GRID","prop":"GridCurrRow","grid":103},{"av":"nRC_GXsfl_103","ctrl":"GRID","prop":"GridRC","grid":103}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV7SDTNotificationsData","fld":"vSDTNOTIFICATIONSDATA","grid":103,"hsh":true},{"av":"nGXsfl_103_idx","ctrl":"GRID","prop":"GridCurrRow","grid":103},{"av":"nRC_GXsfl_103","ctrl":"GRID","prop":"GridRC","grid":103}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV7SDTNotificationsData","fld":"vSDTNOTIFICATIONSDATA","grid":103,"hsh":true},{"av":"nGXsfl_103_idx","ctrl":"GRID","prop":"GridCurrRow","grid":103},{"av":"nRC_GXsfl_103","ctrl":"GRID","prop":"GridRC","grid":103}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv4","iparms":[]}""");
         return  ;
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7SDTNotificationsData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem>( context, "WWP_SDTNotificationsDataSampleItem", "YTT_version4");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV18Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV19Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV20ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV21ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV22DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV23FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV24ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV25ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_card1_maintable = new GXUserControl();
         TempTags = "";
         lblCard1_description_Jsonclick = "";
         ucCard1_progress = new GXUserControl();
         ucDvpanel_card2_maintable = new GXUserControl();
         lblCard2_description_Jsonclick = "";
         ucCard2_progress = new GXUserControl();
         ucDvpanel_card3_maintable = new GXUserControl();
         lblCard3_description_Jsonclick = "";
         ucCard3_progress = new GXUserControl();
         ucDvpanel_card4_maintable = new GXUserControl();
         lblCard4_description_Jsonclick = "";
         ucCard4_progress = new GXUserControl();
         ucDvpanel_tablechart3 = new GXUserControl();
         ucUtchartdoughnut = new GXUserControl();
         ucDvpanel_tablechart4 = new GXUserControl();
         ucUtchartsmoothline = new GXUserControl();
         ucDvpanel_tablechart1 = new GXUserControl();
         ucUtchartsmootharea = new GXUserControl();
         ucDvpanel_tablenotifications = new GXUserControl();
         lblNotificationssubtitle_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6NotificationIcon = "";
         AV5HomeSampleData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "YTT_version4");
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "YTT_version4");
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV12Axes = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         GXt_objcol_SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem2 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem>( context, "WWP_SDTNotificationsDataSampleItem", "YTT_version4");
         GridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavCard1_value_Enabled = 0;
         edtavCard2_value_Enabled = 0;
         edtavCard3_value_Enabled = 0;
         edtavCard4_value_Enabled = 0;
         edtavNotificationicon_Enabled = 0;
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short edtavNotificationicon_Format ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_103 ;
      private int subGrid_Rows ;
      private int nGXsfl_103_idx=1 ;
      private int Card1_progress_Percentage ;
      private int Card1_progress_Circlewidth ;
      private int Card1_progress_Circleprogresswidth ;
      private int Card2_progress_Percentage ;
      private int Card2_progress_Circlewidth ;
      private int Card2_progress_Circleprogresswidth ;
      private int Card3_progress_Percentage ;
      private int Card3_progress_Circlewidth ;
      private int Card3_progress_Circleprogresswidth ;
      private int Card4_progress_Percentage ;
      private int Card4_progress_Circlewidth ;
      private int Card4_progress_Circleprogresswidth ;
      private int edtavCard1_value_Enabled ;
      private int edtavCard2_value_Enabled ;
      private int edtavCard3_value_Enabled ;
      private int edtavCard4_value_Enabled ;
      private int divTablechart3_Height ;
      private int divTablechart4_Height ;
      private int divTablechart1_Height ;
      private int AV29GXV1 ;
      private int subGrid_Islastpage ;
      private int edtavNotificationicon_Enabled ;
      private int edtavSdtnotificationsdata__notificationiconclass_Enabled ;
      private int edtavSdtnotificationsdata__notificationtitle_Enabled ;
      private int edtavSdtnotificationsdata__notificationdatetime_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_103_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV8Card1_Value ;
      private long AV9Card2_Value ;
      private long AV10Card3_Value ;
      private long AV11Card4_Value ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV14Card1_ProgressValue ;
      private decimal AV15Card2_ProgressValue ;
      private decimal AV16Card3_ProgressValue ;
      private decimal AV17Card4_ProgressValue ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_103_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Card1_progress_Caption ;
      private string Card1_progress_Cls ;
      private string Dvpanel_card1_maintable_Width ;
      private string Dvpanel_card1_maintable_Cls ;
      private string Dvpanel_card1_maintable_Title ;
      private string Dvpanel_card1_maintable_Iconposition ;
      private string Card2_progress_Caption ;
      private string Card2_progress_Cls ;
      private string Dvpanel_card2_maintable_Width ;
      private string Dvpanel_card2_maintable_Cls ;
      private string Dvpanel_card2_maintable_Title ;
      private string Dvpanel_card2_maintable_Iconposition ;
      private string Card3_progress_Caption ;
      private string Card3_progress_Cls ;
      private string Dvpanel_card3_maintable_Width ;
      private string Dvpanel_card3_maintable_Cls ;
      private string Dvpanel_card3_maintable_Title ;
      private string Dvpanel_card3_maintable_Iconposition ;
      private string Card4_progress_Caption ;
      private string Card4_progress_Cls ;
      private string Dvpanel_card4_maintable_Width ;
      private string Dvpanel_card4_maintable_Cls ;
      private string Dvpanel_card4_maintable_Title ;
      private string Dvpanel_card4_maintable_Iconposition ;
      private string Utchartdoughnut_Height ;
      private string Utchartdoughnut_Type ;
      private string Utchartdoughnut_Charttype ;
      private string Dvpanel_tablechart3_Width ;
      private string Dvpanel_tablechart3_Cls ;
      private string Dvpanel_tablechart3_Title ;
      private string Dvpanel_tablechart3_Iconposition ;
      private string Utchartsmoothline_Height ;
      private string Utchartsmoothline_Type ;
      private string Utchartsmoothline_Charttype ;
      private string Dvpanel_tablechart4_Width ;
      private string Dvpanel_tablechart4_Cls ;
      private string Dvpanel_tablechart4_Title ;
      private string Dvpanel_tablechart4_Iconposition ;
      private string Utchartsmootharea_Type ;
      private string Utchartsmootharea_Charttype ;
      private string Dvpanel_tablechart1_Width ;
      private string Dvpanel_tablechart1_Cls ;
      private string Dvpanel_tablechart1_Title ;
      private string Dvpanel_tablechart1_Iconposition ;
      private string Dvpanel_tablenotifications_Width ;
      private string Dvpanel_tablenotifications_Cls ;
      private string Dvpanel_tablenotifications_Title ;
      private string Dvpanel_tablenotifications_Iconposition ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecards_Internalname ;
      private string Dvpanel_card1_maintable_Internalname ;
      private string divCard1_maintable_Internalname ;
      private string divCard1_content_Internalname ;
      private string edtavCard1_value_Internalname ;
      private string TempTags ;
      private string edtavCard1_value_Jsonclick ;
      private string lblCard1_description_Internalname ;
      private string lblCard1_description_Jsonclick ;
      private string Card1_progress_Internalname ;
      private string Dvpanel_card2_maintable_Internalname ;
      private string divCard2_maintable_Internalname ;
      private string divCard2_content_Internalname ;
      private string edtavCard2_value_Internalname ;
      private string edtavCard2_value_Jsonclick ;
      private string lblCard2_description_Internalname ;
      private string lblCard2_description_Jsonclick ;
      private string Card2_progress_Internalname ;
      private string Dvpanel_card3_maintable_Internalname ;
      private string divCard3_maintable_Internalname ;
      private string divCard3_content_Internalname ;
      private string edtavCard3_value_Internalname ;
      private string edtavCard3_value_Jsonclick ;
      private string lblCard3_description_Internalname ;
      private string lblCard3_description_Jsonclick ;
      private string Card3_progress_Internalname ;
      private string Dvpanel_card4_maintable_Internalname ;
      private string divCard4_maintable_Internalname ;
      private string divCard4_content_Internalname ;
      private string edtavCard4_value_Internalname ;
      private string edtavCard4_value_Jsonclick ;
      private string lblCard4_description_Internalname ;
      private string lblCard4_description_Jsonclick ;
      private string Card4_progress_Internalname ;
      private string Dvpanel_tablechart3_Internalname ;
      private string divTablechart3_Internalname ;
      private string Utchartdoughnut_Title ;
      private string Utchartdoughnut_Internalname ;
      private string Dvpanel_tablechart4_Internalname ;
      private string divTablechart4_Internalname ;
      private string Utchartsmoothline_Title ;
      private string Utchartsmoothline_Internalname ;
      private string Dvpanel_tablechart1_Internalname ;
      private string divTablechart1_Internalname ;
      private string Utchartsmootharea_Title ;
      private string Utchartsmootharea_Internalname ;
      private string Dvpanel_tablenotifications_Internalname ;
      private string divTablenotifications_Internalname ;
      private string lblNotificationssubtitle_Internalname ;
      private string lblNotificationssubtitle_Caption ;
      private string lblNotificationssubtitle_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNotificationicon_Internalname ;
      private string sGXsfl_103_fel_idx="0001" ;
      private string edtavSdtnotificationsdata__notificationiconclass_Internalname ;
      private string edtavSdtnotificationsdata__notificationtitle_Internalname ;
      private string edtavSdtnotificationsdata__notificationdatetime_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavNotificationicon_Jsonclick ;
      private string edtavSdtnotificationsdata__notificationiconclass_Jsonclick ;
      private string edtavSdtnotificationsdata__notificationtitle_Jsonclick ;
      private string edtavSdtnotificationsdata__notificationdatetime_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_card1_maintable_Autowidth ;
      private bool Dvpanel_card1_maintable_Autoheight ;
      private bool Dvpanel_card1_maintable_Collapsible ;
      private bool Dvpanel_card1_maintable_Collapsed ;
      private bool Dvpanel_card1_maintable_Showcollapseicon ;
      private bool Dvpanel_card1_maintable_Autoscroll ;
      private bool Dvpanel_card2_maintable_Autowidth ;
      private bool Dvpanel_card2_maintable_Autoheight ;
      private bool Dvpanel_card2_maintable_Collapsible ;
      private bool Dvpanel_card2_maintable_Collapsed ;
      private bool Dvpanel_card2_maintable_Showcollapseicon ;
      private bool Dvpanel_card2_maintable_Autoscroll ;
      private bool Dvpanel_card3_maintable_Autowidth ;
      private bool Dvpanel_card3_maintable_Autoheight ;
      private bool Dvpanel_card3_maintable_Collapsible ;
      private bool Dvpanel_card3_maintable_Collapsed ;
      private bool Dvpanel_card3_maintable_Showcollapseicon ;
      private bool Dvpanel_card3_maintable_Autoscroll ;
      private bool Dvpanel_card4_maintable_Autowidth ;
      private bool Dvpanel_card4_maintable_Autoheight ;
      private bool Dvpanel_card4_maintable_Collapsible ;
      private bool Dvpanel_card4_maintable_Collapsed ;
      private bool Dvpanel_card4_maintable_Showcollapseicon ;
      private bool Dvpanel_card4_maintable_Autoscroll ;
      private bool Utchartdoughnut_Showvalues ;
      private bool Dvpanel_tablechart3_Autowidth ;
      private bool Dvpanel_tablechart3_Autoheight ;
      private bool Dvpanel_tablechart3_Collapsible ;
      private bool Dvpanel_tablechart3_Collapsed ;
      private bool Dvpanel_tablechart3_Showcollapseicon ;
      private bool Dvpanel_tablechart3_Autoscroll ;
      private bool Dvpanel_tablechart4_Autowidth ;
      private bool Dvpanel_tablechart4_Autoheight ;
      private bool Dvpanel_tablechart4_Collapsible ;
      private bool Dvpanel_tablechart4_Collapsed ;
      private bool Dvpanel_tablechart4_Showcollapseicon ;
      private bool Dvpanel_tablechart4_Autoscroll ;
      private bool Dvpanel_tablechart1_Autowidth ;
      private bool Dvpanel_tablechart1_Autoheight ;
      private bool Dvpanel_tablechart1_Collapsible ;
      private bool Dvpanel_tablechart1_Collapsed ;
      private bool Dvpanel_tablechart1_Showcollapseicon ;
      private bool Dvpanel_tablechart1_Autoscroll ;
      private bool Dvpanel_tablenotifications_Autowidth ;
      private bool Dvpanel_tablenotifications_Autoheight ;
      private bool Dvpanel_tablenotifications_Collapsible ;
      private bool Dvpanel_tablenotifications_Collapsed ;
      private bool Dvpanel_tablenotifications_Showcollapseicon ;
      private bool Dvpanel_tablenotifications_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_103_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV103 ;
      private string AV6NotificationIcon ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_card1_maintable ;
      private GXUserControl ucCard1_progress ;
      private GXUserControl ucDvpanel_card2_maintable ;
      private GXUserControl ucCard2_progress ;
      private GXUserControl ucDvpanel_card3_maintable ;
      private GXUserControl ucCard3_progress ;
      private GXUserControl ucDvpanel_card4_maintable ;
      private GXUserControl ucCard4_progress ;
      private GXUserControl ucDvpanel_tablechart3 ;
      private GXUserControl ucUtchartdoughnut ;
      private GXUserControl ucDvpanel_tablechart4 ;
      private GXUserControl ucUtchartsmoothline ;
      private GXUserControl ucDvpanel_tablechart1 ;
      private GXUserControl ucUtchartsmootharea ;
      private GXUserControl ucDvpanel_tablenotifications ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> AV7SDTNotificationsData ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV18Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV19Parameters ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV20ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV21ItemDoubleClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV22DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV23FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV24ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV25ItemCollapseData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtHomeSampleData_HomeSampleDataItem> AV5HomeSampleData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtHomeSampleData_HomeSampleDataItem> GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element AV13Axis ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV12Axes ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> GXt_objcol_SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem2 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
