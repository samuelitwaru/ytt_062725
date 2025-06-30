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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class exportoptions : GXDataArea
   {
      public exportoptions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public exportoptions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ExcelFileName ,
                           string aP1_DefaultTitle )
      {
         this.AV7ExcelFileName = aP0_ExcelFileName;
         this.AV6DefaultTitle = aP1_DefaultTitle;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavExporttype = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ExcelFileName");
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
               gxfirstwebparm = GetFirstPar( "ExcelFileName");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ExcelFileName");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV7ExcelFileName = gxfirstwebparm;
               AssignAttri("", false, "AV7ExcelFileName", AV7ExcelFileName);
               GxWebStd.gx_hidden_field( context, "gxhash_vEXCELFILENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ExcelFileName, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV6DefaultTitle = GetPar( "DefaultTitle");
                  AssignAttri("", false, "AV6DefaultTitle", AV6DefaultTitle);
                  GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DefaultTitle, "")), context));
               }
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
            return "exportoptions_Execute" ;
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
         PA0G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0G2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wwpbaseobjects.exportoptions.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV7ExcelFileName)),UrlEncode(StringUtil.RTrim(AV6DefaultTitle))}, new string[] {"ExcelFileName","DefaultTitle"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vGOOGLEDOCRESULTXML", AV9GoogleDocResultXML);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOOGLEDOCRESULTXML", GetSecureSignedToken( "", AV9GoogleDocResultXML, context));
         GxWebStd.gx_hidden_field( context, "vEXCELFILENAME", AV7ExcelFileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vEXCELFILENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ExcelFileName, "")), context));
         GxWebStd.gx_hidden_field( context, "vDEFAULTTITLE", AV6DefaultTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DefaultTitle, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vGOOGLEDOCRESULTXML", AV9GoogleDocResultXML);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOOGLEDOCRESULTXML", GetSecureSignedToken( "", AV9GoogleDocResultXML, context));
         GxWebStd.gx_hidden_field( context, "vEXCELFILENAME", AV7ExcelFileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vEXCELFILENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ExcelFileName, "")), context));
         GxWebStd.gx_hidden_field( context, "vDEFAULTTITLE", AV6DefaultTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DefaultTitle, "")), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Width", StringUtil.RTrim( Dvpanel_tableexport_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Autowidth", StringUtil.BoolToStr( Dvpanel_tableexport_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Autoheight", StringUtil.BoolToStr( Dvpanel_tableexport_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Cls", StringUtil.RTrim( Dvpanel_tableexport_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Title", StringUtil.RTrim( Dvpanel_tableexport_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Collapsible", StringUtil.BoolToStr( Dvpanel_tableexport_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Collapsed", StringUtil.BoolToStr( Dvpanel_tableexport_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableexport_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Iconposition", StringUtil.RTrim( Dvpanel_tableexport_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEEXPORT_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableexport_Autoscroll));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
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
         context.WriteHtmlTextNl( "</form>") ;
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0G2( ) ;
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
         return formatLink("wwpbaseobjects.exportoptions.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV7ExcelFileName)),UrlEncode(StringUtil.RTrim(AV6DefaultTitle))}, new string[] {"ExcelFileName","DefaultTitle"})  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.ExportOptions" ;
      }

      public override string GetPgmdesc( )
      {
         return "Excel Export Options" ;
      }

      protected void WB0G0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_6_0G2( true) ;
         }
         else
         {
            wb_table1_6_0G2( false) ;
         }
         return  ;
      }

      protected void wb_table1_6_0G2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0G2( )
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
         Form.Meta.addItem("description", "Excel Export Options", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0G0( ) ;
      }

      protected void WS0G2( )
      {
         START0G2( ) ;
         EVT0G2( ) ;
      }

      protected void EVT0G2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E110G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODOWNLOADTOFILE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoDownloadToFile' */
                              E120G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSAVEGOOGLEDRIVE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoSaveGoogleDrive' */
                              E130G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E140G2 ();
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0G2( )
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

      protected void PA0G2( )
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
               GX_FocusControl = cmbavExporttype_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         if ( cmbavExporttype.ItemCount > 0 )
         {
            AV8ExportType = (short)(Math.Round(NumberUtil.Val( cmbavExporttype.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8ExportType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8ExportType", StringUtil.Str( (decimal)(AV8ExportType), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavExporttype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ExportType), 1, 0));
            AssignProp("", false, cmbavExporttype_Internalname, "Values", cmbavExporttype.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E140G2 ();
            WB0G0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0G2( )
      {
         GxWebStd.gx_hidden_field( context, "vGOOGLEDOCRESULTXML", AV9GoogleDocResultXML);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOOGLEDOCRESULTXML", GetSecureSignedToken( "", AV9GoogleDocResultXML, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_tableexport_Width = cgiGet( "DVPANEL_TABLEEXPORT_Width");
            Dvpanel_tableexport_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Autowidth"));
            Dvpanel_tableexport_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Autoheight"));
            Dvpanel_tableexport_Cls = cgiGet( "DVPANEL_TABLEEXPORT_Cls");
            Dvpanel_tableexport_Title = cgiGet( "DVPANEL_TABLEEXPORT_Title");
            Dvpanel_tableexport_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Collapsible"));
            Dvpanel_tableexport_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Collapsed"));
            Dvpanel_tableexport_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Showcollapseicon"));
            Dvpanel_tableexport_Iconposition = cgiGet( "DVPANEL_TABLEEXPORT_Iconposition");
            Dvpanel_tableexport_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEEXPORT_Autoscroll"));
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            /* Read variables values. */
            cmbavExporttype.CurrentValue = cgiGet( cmbavExporttype_Internalname);
            AV8ExportType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavExporttype_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8ExportType", StringUtil.Str( (decimal)(AV8ExportType), 1, 0));
            AV14User = cgiGet( edtavUser_Internalname);
            AssignAttri("", false, "AV14User", AV14User);
            AV5DocTitle = cgiGet( edtavDoctitle_Internalname);
            AssignAttri("", false, "AV5DocTitle", AV5DocTitle);
            AV12Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV12Password", AV12Password);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110G2 ();
         if (returnInSub) return;
      }

      protected void E110G2( )
      {
         /* Start Routine */
         returnInSub = false;
         tblTablecontent_Height = 388;
         AssignProp("", false, tblTablecontent_Internalname, "Height", StringUtil.LTrimStr( (decimal)(tblTablecontent_Height), 9, 0), true);
         AV5DocTitle = AV6DefaultTitle;
         AssignAttri("", false, "AV5DocTitle", AV5DocTitle);
         edtavPassword_Ispassword = 1;
         AssignProp("", false, edtavPassword_Internalname, "Ispassword", StringUtil.Str( (decimal)(edtavPassword_Ispassword), 1, 0), true);
         if ( StringUtil.StrCmp(AV11HttpRequest.Method, "GET") == 0 )
         {
            tblTablegoogledriveinfo_Visible = 0;
            AssignProp("", false, tblTablegoogledriveinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablegoogledriveinfo_Visible), 5, 0), true);
            bttBtnsavegoogledrive_Visible = 0;
            AssignProp("", false, bttBtnsavegoogledrive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsavegoogledrive_Visible), 5, 0), true);
         }
         AV13URL = formatLink(AV7ExcelFileName) ;
         bttBtndownloadtofile_Jsonclick = "exportActionDownloadFile('"+AV13URL+"')";
         AssignProp("", false, bttBtndownloadtofile_Internalname, "Jsonclick", bttBtndownloadtofile_Jsonclick, true);
         lblJs_Caption = "<script type=\"text/javascript\">function exportActionDownloadFile(u) { var element = document.createElement(\"iframe\"); element.setAttribute(\"src\", u);document.body.appendChild(element); return true; }</script>";
         AssignProp("", false, lblJs_Internalname, "Caption", lblJs_Caption, true);
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         tblTablecontent_Width = 560;
         AssignProp("", false, tblTablecontent_Internalname, "Width", StringUtil.LTrimStr( (decimal)(tblTablecontent_Width), 9, 0), true);
         tblTablecontent_Height = 386;
         AssignProp("", false, tblTablecontent_Internalname, "Height", StringUtil.LTrimStr( (decimal)(tblTablecontent_Height), 9, 0), true);
      }

      protected void E120G2( )
      {
         /* 'DoDownloadToFile' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E130G2( )
      {
         /* 'DoSaveGoogleDrive' Routine */
         returnInSub = false;
         AV10GoogleDocsResult.FromXml(AV9GoogleDocResultXML, null, "", "");
         if ( AV10GoogleDocsResult.gxTpr_Success )
         {
            Innewwindow1_Target = ((GeneXus.Programs.wwpbaseobjects.SdtGoogleDocsResult_Doc)AV10GoogleDocsResult.gxTpr_Docs.Item(1)).gxTpr_Url;
            ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
            Innewwindow1_Height = "600";
            ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
            Innewwindow1_Width = "800";
            ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
            this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
            GX_msglist.addItem("The document was succesully uploaded to Google Drive");
            bttBtncancel_Caption = "Close";
            AssignProp("", false, bttBtncancel_Internalname, "Caption", bttBtncancel_Caption, true);
            tblTablecontent_Visible = 0;
            AssignProp("", false, tblTablecontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablecontent_Visible), 5, 0), true);
            bttBtndownloadtofile_Visible = 0;
            AssignProp("", false, bttBtndownloadtofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndownloadtofile_Visible), 5, 0), true);
            bttBtnsavegoogledrive_Visible = 0;
            AssignProp("", false, bttBtnsavegoogledrive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsavegoogledrive_Visible), 5, 0), true);
         }
         else
         {
            GX_msglist.addItem("Error uploading Spreadsheet:  "+AV10GoogleDocsResult.gxTpr_Error);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E140G2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_6_0G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableMainTransaction", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divLefttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PopupContentCell", "start", "top", "", "", "div");
            wb_table2_18_0G2( true) ;
         }
         else
         {
            wb_table2_18_0G2( false) ;
         }
         return  ;
      }

      protected void wb_table2_18_0G2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupRight", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndownloadtofile_Internalname, "", "Save", bttBtndownloadtofile_Jsonclick, 5, "Save", "", StyleString, ClassString, bttBtndownloadtofile_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DODOWNLOADTOFILE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/ExportOptions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsavegoogledrive_Internalname, "", "Save", bttBtnsavegoogledrive_Jsonclick, 5, "Save", "", StyleString, ClassString, bttBtnsavegoogledrive_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOSAVEGOOGLEDRIVE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/ExportOptions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", bttBtncancel_Caption, bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/ExportOptions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divRighttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJs_Internalname, lblJs_Caption, "", "", lblJs_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects/ExportOptions.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_usertable_ut_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            wb_table3_68_0G2( true) ;
         }
         else
         {
            wb_table3_68_0G2( false) ;
         }
         return  ;
      }

      protected void wb_table3_68_0G2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_6_0G2e( true) ;
         }
         else
         {
            wb_table1_6_0G2e( false) ;
         }
      }

      protected void wb_table3_68_0G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUt_Internalname, tblUt_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr class='Table'>") ;
            context.WriteHtmlText( "<td class='Table'>") ;
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_68_0G2e( true) ;
         }
         else
         {
            wb_table3_68_0G2e( false) ;
         }
      }

      protected void wb_table2_18_0G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablecontent_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            sStyleString += " height: " + StringUtil.LTrimStr( (decimal)(tblTablecontent_Height), 10, 0) + "px" + ";";
            sStyleString += " width: " + StringUtil.LTrimStr( (decimal)(tblTablecontent_Width), 10, 0) + "px" + ";";
            GxWebStd.gx_table_start( context, tblTablecontent_Internalname, tblTablecontent_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellPaddingTop10 CellMarginLeft15'>") ;
            /* User Defined Control */
            ucDvpanel_tableexport.SetProperty("Width", Dvpanel_tableexport_Width);
            ucDvpanel_tableexport.SetProperty("AutoWidth", Dvpanel_tableexport_Autowidth);
            ucDvpanel_tableexport.SetProperty("AutoHeight", Dvpanel_tableexport_Autoheight);
            ucDvpanel_tableexport.SetProperty("Cls", Dvpanel_tableexport_Cls);
            ucDvpanel_tableexport.SetProperty("Title", Dvpanel_tableexport_Title);
            ucDvpanel_tableexport.SetProperty("Collapsible", Dvpanel_tableexport_Collapsible);
            ucDvpanel_tableexport.SetProperty("Collapsed", Dvpanel_tableexport_Collapsed);
            ucDvpanel_tableexport.SetProperty("ShowCollapseIcon", Dvpanel_tableexport_Showcollapseicon);
            ucDvpanel_tableexport.SetProperty("IconPosition", Dvpanel_tableexport_Iconposition);
            ucDvpanel_tableexport.SetProperty("AutoScroll", Dvpanel_tableexport_Autoscroll);
            ucDvpanel_tableexport.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableexport_Internalname, "DVPANEL_TABLEEXPORTContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEEXPORTContainer"+"TableExport"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableexport_Internalname, 1, 0, "px", 0, "px", "TableData", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavExporttype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavExporttype_Internalname, "Export type", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavExporttype, cmbavExporttype_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8ExportType), 1, 0)), 1, cmbavExporttype_Jsonclick, 7, "'"+""+"'"+",false,"+"'"+"e150g1_client"+"'", "int", "", 1, cmbavExporttype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 0, "HLP_WWPBaseObjects/ExportOptions.htm");
            cmbavExporttype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8ExportType), 1, 0));
            AssignProp("", false, cmbavExporttype_Internalname, "Values", (string)(cmbavExporttype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellPaddingTop10 CellMarginLeft15'>") ;
            wb_table4_31_0G2( true) ;
         }
         else
         {
            wb_table4_31_0G2( false) ;
         }
         return  ;
      }

      protected void wb_table4_31_0G2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_18_0G2e( true) ;
         }
         else
         {
            wb_table2_18_0G2e( false) ;
         }
      }

      protected void wb_table4_31_0G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablegoogledriveinfo_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablegoogledriveinfo_Internalname, tblTablegoogledriveinfo_Internalname, "", "Table100x100", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUser_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUser_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUser_Internalname, AV14User, StringUtil.RTrim( context.localUtil.Format( AV14User, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUser_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUser_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/ExportOptions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDoctitle_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDoctitle_Internalname, "Document title", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDoctitle_Internalname, AV5DocTitle, StringUtil.RTrim( context.localUtil.Format( AV5DocTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDoctitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDoctitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/ExportOptions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, "Password", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, AV12Password, StringUtil.RTrim( context.localUtil.Format( AV12Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, edtavPassword_Ispassword, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/ExportOptions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_31_0G2e( true) ;
         }
         else
         {
            wb_table4_31_0G2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7ExcelFileName = (string)getParm(obj,0);
         AssignAttri("", false, "AV7ExcelFileName", AV7ExcelFileName);
         GxWebStd.gx_hidden_field( context, "gxhash_vEXCELFILENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ExcelFileName, "")), context));
         AV6DefaultTitle = (string)getParm(obj,1);
         AssignAttri("", false, "AV6DefaultTitle", AV6DefaultTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEFAULTTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DefaultTitle, "")), context));
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
         PA0G2( ) ;
         WS0G2( ) ;
         WE0G2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025627525971", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wwpbaseobjects/exportoptions.js", "?2025627525971", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavExporttype.Name = "vEXPORTTYPE";
         cmbavExporttype.WebTags = "";
         cmbavExporttype.addItem("1", "Download to disk", 0);
         cmbavExporttype.addItem("2", "Upload to Google Drive", 0);
         if ( cmbavExporttype.ItemCount > 0 )
         {
            AV8ExportType = (short)(Math.Round(NumberUtil.Val( cmbavExporttype.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8ExportType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8ExportType", StringUtil.Str( (decimal)(AV8ExportType), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         cmbavExporttype_Internalname = "vEXPORTTYPE";
         divTableexport_Internalname = "TABLEEXPORT";
         Dvpanel_tableexport_Internalname = "DVPANEL_TABLEEXPORT";
         edtavUser_Internalname = "vUSER";
         edtavDoctitle_Internalname = "vDOCTITLE";
         edtavPassword_Internalname = "vPASSWORD";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         tblTablegoogledriveinfo_Internalname = "TABLEGOOGLEDRIVEINFO";
         tblTablecontent_Internalname = "TABLECONTENT";
         bttBtndownloadtofile_Internalname = "BTNDOWNLOADTOFILE";
         bttBtnsavegoogledrive_Internalname = "BTNSAVEGOOGLEDRIVE";
         bttBtncancel_Internalname = "BTNCANCEL";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         lblJs_Internalname = "JS";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         tblUt_Internalname = "UT";
         divHtml_usertable_ut_Internalname = "HTML_USERTABLE_UT";
         tblTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavPassword_Jsonclick = "";
         edtavPassword_Enabled = 1;
         edtavDoctitle_Jsonclick = "";
         edtavDoctitle_Enabled = 1;
         edtavUser_Jsonclick = "";
         edtavUser_Enabled = 1;
         cmbavExporttype_Jsonclick = "";
         cmbavExporttype.Enabled = 1;
         tblTablecontent_Width = 0;
         tblTablecontent_Height = 0;
         bttBtnsavegoogledrive_Visible = 1;
         bttBtndownloadtofile_Visible = 1;
         tblTablecontent_Visible = 1;
         bttBtncancel_Caption = "Cancel";
         lblJs_Caption = "JS";
         tblTablegoogledriveinfo_Visible = 1;
         edtavPassword_Ispassword = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Dvpanel_tableexport_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableexport_Iconposition = "Right";
         Dvpanel_tableexport_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableexport_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableexport_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableexport_Title = "Where to export?";
         Dvpanel_tableexport_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableexport_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableexport_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableexport_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Excel Export Options";
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV9GoogleDocResultXML","fld":"vGOOGLEDOCRESULTXML","hsh":true},{"av":"AV7ExcelFileName","fld":"vEXCELFILENAME","hsh":true},{"av":"AV6DefaultTitle","fld":"vDEFAULTTITLE","hsh":true}]}""");
         setEventMetadata("'DODOWNLOADTOFILE'","""{"handler":"E120G2","iparms":[]}""");
         setEventMetadata("'DOSAVEGOOGLEDRIVE'","""{"handler":"E130G2","iparms":[{"av":"AV9GoogleDocResultXML","fld":"vGOOGLEDOCRESULTXML","hsh":true}]""");
         setEventMetadata("'DOSAVEGOOGLEDRIVE'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"ctrl":"BTNCANCEL","prop":"Caption"},{"av":"tblTablecontent_Visible","ctrl":"TABLECONTENT","prop":"Visible"},{"ctrl":"BTNDOWNLOADTOFILE","prop":"Visible"},{"ctrl":"BTNSAVEGOOGLEDRIVE","prop":"Visible"}]}""");
         setEventMetadata("VEXPORTTYPE.CLICK","""{"handler":"E150G1","iparms":[{"av":"cmbavExporttype"},{"av":"AV8ExportType","fld":"vEXPORTTYPE","pic":"9"}]""");
         setEventMetadata("VEXPORTTYPE.CLICK",""","oparms":[{"av":"tblTablegoogledriveinfo_Visible","ctrl":"TABLEGOOGLEDRIVEINFO","prop":"Visible"},{"ctrl":"BTNDOWNLOADTOFILE","prop":"Visible"},{"ctrl":"BTNSAVEGOOGLEDRIVE","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_EXPORTTYPE","""{"handler":"Validv_Exporttype","iparms":[]}""");
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
         wcpOAV7ExcelFileName = "";
         wcpOAV6DefaultTitle = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV9GoogleDocResultXML = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV14User = "";
         AV5DocTitle = "";
         AV12Password = "";
         AV11HttpRequest = new GxHttpRequest( context);
         AV13URL = "";
         bttBtndownloadtofile_Jsonclick = "";
         AV10GoogleDocsResult = new GeneXus.Programs.wwpbaseobjects.SdtGoogleDocsResult(context);
         ucInnewwindow1 = new GXUserControl();
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnsavegoogledrive_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         lblJs_Jsonclick = "";
         ucDvpanel_tableexport = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV8ExportType ;
      private short edtavPassword_Ispassword ;
      private short nGXWrapped ;
      private int tblTablecontent_Height ;
      private int tblTablegoogledriveinfo_Visible ;
      private int bttBtnsavegoogledrive_Visible ;
      private int tblTablecontent_Width ;
      private int tblTablecontent_Visible ;
      private int bttBtndownloadtofile_Visible ;
      private int edtavUser_Enabled ;
      private int edtavDoctitle_Enabled ;
      private int edtavPassword_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tableexport_Width ;
      private string Dvpanel_tableexport_Cls ;
      private string Dvpanel_tableexport_Title ;
      private string Dvpanel_tableexport_Iconposition ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavExporttype_Internalname ;
      private string edtavUser_Internalname ;
      private string edtavDoctitle_Internalname ;
      private string edtavPassword_Internalname ;
      private string tblTablecontent_Internalname ;
      private string tblTablegoogledriveinfo_Internalname ;
      private string bttBtnsavegoogledrive_Internalname ;
      private string bttBtndownloadtofile_Jsonclick ;
      private string bttBtndownloadtofile_Internalname ;
      private string lblJs_Caption ;
      private string lblJs_Internalname ;
      private string Innewwindow1_Internalname ;
      private string bttBtncancel_Caption ;
      private string bttBtncancel_Internalname ;
      private string sStyleString ;
      private string tblTablemain_Internalname ;
      private string divLefttable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string bttBtnsavegoogledrive_Jsonclick ;
      private string bttBtncancel_Jsonclick ;
      private string divRighttable_Internalname ;
      private string lblJs_Jsonclick ;
      private string divHtml_usertable_ut_Internalname ;
      private string tblUt_Internalname ;
      private string Dvpanel_tableexport_Internalname ;
      private string divTableexport_Internalname ;
      private string cmbavExporttype_Jsonclick ;
      private string divTableattributes_Internalname ;
      private string edtavUser_Jsonclick ;
      private string edtavDoctitle_Jsonclick ;
      private string edtavPassword_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tableexport_Autowidth ;
      private bool Dvpanel_tableexport_Autoheight ;
      private bool Dvpanel_tableexport_Collapsible ;
      private bool Dvpanel_tableexport_Collapsed ;
      private bool Dvpanel_tableexport_Showcollapseicon ;
      private bool Dvpanel_tableexport_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV9GoogleDocResultXML ;
      private string AV7ExcelFileName ;
      private string AV6DefaultTitle ;
      private string wcpOAV7ExcelFileName ;
      private string wcpOAV6DefaultTitle ;
      private string AV14User ;
      private string AV5DocTitle ;
      private string AV12Password ;
      private string AV13URL ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDvpanel_tableexport ;
      private GxHttpRequest AV11HttpRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavExporttype ;
      private GeneXus.Programs.wwpbaseobjects.SdtGoogleDocsResult AV10GoogleDocsResult ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
