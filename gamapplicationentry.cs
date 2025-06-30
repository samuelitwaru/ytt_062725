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
namespace GeneXus.Programs {
   public class gamapplicationentry : GXDataArea
   {
      public gamapplicationentry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamapplicationentry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref long aP1_Id )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV43Id = aP1_Id;
         ExecuteImpl();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Id=this.AV43Id;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavReturnmenuoptionswithoutpermission = new GXCheckbox();
         cmbavMainmenu = new GXCombobox();
         chkavUseabsoluteurlbyenvironment = new GXCheckbox();
         cmbavClientaccessstatus = new GXCombobox();
         chkavClientauthrequestmustincludeuserscopes = new GXCheckbox();
         chkavClientdonotshareuserids = new GXCheckbox();
         chkavClientallowremoteauth = new GXCheckbox();
         chkavClientallowgetuserdata = new GXCheckbox();
         chkavClientallowgetuseradddata = new GXCheckbox();
         chkavClientallowgetuserroles = new GXCheckbox();
         chkavClientallowgetsessioniniprop = new GXCheckbox();
         chkavClientallowgetsessionappdata = new GXCheckbox();
         chkavClientcallbackurliscustom = new GXCheckbox();
         chkavClientallowremoterestauth = new GXCheckbox();
         chkavClientallowgetuserdatarest = new GXCheckbox();
         chkavClientallowgetuseradddatarest = new GXCheckbox();
         chkavClientallowgetuserrolesrest = new GXCheckbox();
         chkavClientallowgetsessioniniproprest = new GXCheckbox();
         chkavClientallowgetsessionappdatarest = new GXCheckbox();
         chkavClientaccessuniquebyuser = new GXCheckbox();
         chkavAccessrequirespermission = new GXCheckbox();
         chkavIsauthorizationdelegated = new GXCheckbox();
         cmbavDelegateauthorizationversion = new GXCombobox();
         chkavSsorestenable = new GXCheckbox();
         cmbavSsorestmode = new GXCombobox();
         chkavSsorestserverurl_iscustom = new GXCheckbox();
         chkavStsprotocolenable = new GXCheckbox();
         cmbavStsmode = new GXCombobox();
         chkavMiniappenable = new GXCheckbox();
         cmbavMiniappmode = new GXCombobox();
         chkavMiniappclienturl_iscustom = new GXCheckbox();
         cmbavMiniappuserauthenticationtypename = new GXCombobox();
         chkavMiniappserverurl_iscustom = new GXCheckbox();
         chkavApikeyenable = new GXCheckbox();
         cmbavApikeyallowonlyauthenticationtypename = new GXCombobox();
         chkavApikeyallowscopecustomization = new GXCheckbox();
         chkavEnvironmentsecureprotocol = new GXCheckbox();
         chkavOnline = new GXCheckbox();
         chkavAutoregisteranomymoususer = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlanguages") == 0 )
            {
               gxnrGridlanguages_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridlanguages") == 0 )
            {
               gxgrGridlanguages_refresh_invoke( ) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV43Id = (long)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV43Id", StringUtil.LTrimStr( (decimal)(AV43Id), 12, 0));
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

      protected void gxnrGridlanguages_newrow_invoke( )
      {
         nRC_GXsfl_567 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_567"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_567_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_567_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_567_idx = GetPar( "sGXsfl_567_idx");
         chkavOnline.Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, chkavOnline_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOnline.Enabled), 5, 0), !bGXsfl_567_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlanguages_newrow( ) ;
         /* End function gxnrGridlanguages_newrow_invoke */
      }

      protected void gxgrGridlanguages_refresh_invoke( )
      {
         subGridlanguages_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridlanguages_Rows"), "."), 18, MidpointRounding.ToEven));
         chkavOnline.Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, chkavOnline_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOnline.Enabled), 5, 0), !bGXsfl_567_Refreshing);
         Gx_mode = GetPar( "Mode");
         AV156ReturnMenuOptionsWithoutPermission = StringUtil.StrToBool( GetPar( "ReturnMenuOptionsWithoutPermission"));
         AV61UseAbsoluteUrlByEnvironment = StringUtil.StrToBool( GetPar( "UseAbsoluteUrlByEnvironment"));
         AV128ClientAuthRequestMustIncludeUserScopes = StringUtil.StrToBool( GetPar( "ClientAuthRequestMustIncludeUserScopes"));
         AV129ClientDoNotShareUserIDs = StringUtil.StrToBool( GetPar( "ClientDoNotShareUserIDs"));
         AV17ClientAllowRemoteAuth = StringUtil.StrToBool( GetPar( "ClientAllowRemoteAuth"));
         AV126ClientAllowGetUserData = StringUtil.StrToBool( GetPar( "ClientAllowGetUserData"));
         AV13ClientAllowGetUserAddData = StringUtil.StrToBool( GetPar( "ClientAllowGetUserAddData"));
         AV15ClientAllowGetUserRoles = StringUtil.StrToBool( GetPar( "ClientAllowGetUserRoles"));
         AV11ClientAllowGetSessionIniProp = StringUtil.StrToBool( GetPar( "ClientAllowGetSessionIniProp"));
         AV9ClientAllowGetSessionAppData = StringUtil.StrToBool( GetPar( "ClientAllowGetSessionAppData"));
         AV20ClientCallbackURLisCustom = StringUtil.StrToBool( GetPar( "ClientCallbackURLisCustom"));
         AV18ClientAllowRemoteRestAuth = StringUtil.StrToBool( GetPar( "ClientAllowRemoteRestAuth"));
         AV127ClientAllowGetUserDataREST = StringUtil.StrToBool( GetPar( "ClientAllowGetUserDataREST"));
         AV14ClientAllowGetUserAddDataRest = StringUtil.StrToBool( GetPar( "ClientAllowGetUserAddDataRest"));
         AV16ClientAllowGetUserRolesRest = StringUtil.StrToBool( GetPar( "ClientAllowGetUserRolesRest"));
         AV12ClientAllowGetSessionIniPropRest = StringUtil.StrToBool( GetPar( "ClientAllowGetSessionIniPropRest"));
         AV10ClientAllowGetSessionAppDataREST = StringUtil.StrToBool( GetPar( "ClientAllowGetSessionAppDataREST"));
         AV8ClientAccessUniqueByUser = StringUtil.StrToBool( GetPar( "ClientAccessUniqueByUser"));
         AV5AccessRequiresPermission = StringUtil.StrToBool( GetPar( "AccessRequiresPermission"));
         AV143IsAuthorizationDelegated = StringUtil.StrToBool( GetPar( "IsAuthorizationDelegated"));
         AV50SSORestEnable = StringUtil.StrToBool( GetPar( "SSORestEnable"));
         AV159SSORestServerURL_isCustom = StringUtil.StrToBool( GetPar( "SSORestServerURL_isCustom"));
         AV57STSProtocolEnable = StringUtil.StrToBool( GetPar( "STSProtocolEnable"));
         AV148MiniAppEnable = StringUtil.StrToBool( GetPar( "MiniAppEnable"));
         AV147MiniAppClientURL_isCustom = StringUtil.StrToBool( GetPar( "MiniAppClientURL_isCustom"));
         AV152MiniAppServerURL_isCustom = StringUtil.StrToBool( GetPar( "MiniAppServerURL_isCustom"));
         AV120APIKeyEnable = StringUtil.StrToBool( GetPar( "APIKeyEnable"));
         AV119APIKeyAllowScopeCustomization = StringUtil.StrToBool( GetPar( "APIKeyAllowScopeCustomization"));
         AV36EnvironmentSecureProtocol = StringUtil.StrToBool( GetPar( "EnvironmentSecureProtocol"));
         AV7AutoRegisterAnomymousUser = StringUtil.StrToBool( GetPar( "AutoRegisterAnomymousUser"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridlanguages_refresh( subGridlanguages_Rows, Gx_mode, AV156ReturnMenuOptionsWithoutPermission, AV61UseAbsoluteUrlByEnvironment, AV128ClientAuthRequestMustIncludeUserScopes, AV129ClientDoNotShareUserIDs, AV17ClientAllowRemoteAuth, AV126ClientAllowGetUserData, AV13ClientAllowGetUserAddData, AV15ClientAllowGetUserRoles, AV11ClientAllowGetSessionIniProp, AV9ClientAllowGetSessionAppData, AV20ClientCallbackURLisCustom, AV18ClientAllowRemoteRestAuth, AV127ClientAllowGetUserDataREST, AV14ClientAllowGetUserAddDataRest, AV16ClientAllowGetUserRolesRest, AV12ClientAllowGetSessionIniPropRest, AV10ClientAllowGetSessionAppDataREST, AV8ClientAccessUniqueByUser, AV5AccessRequiresPermission, AV143IsAuthorizationDelegated, AV50SSORestEnable, AV159SSORestServerURL_isCustom, AV57STSProtocolEnable, AV148MiniAppEnable, AV147MiniAppClientURL_isCustom, AV152MiniAppServerURL_isCustom, AV120APIKeyEnable, AV119APIKeyAllowScopeCustomization, AV36EnvironmentSecureProtocol, AV7AutoRegisterAnomymousUser) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridlanguages_refresh_invoke */
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
            return "gamapplicationentry_Execute" ;
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
         PA0Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0Y2( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamapplicationentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV43Id,12,0))}, new string[] {"Gx_mode","Id"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_567", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_567), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDLANGUAGESPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV141GridLanguagesPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDLANGUAGESAPPLIEDFILTERS", AV139GridLanguagesAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLANGUAGES_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLANGUAGES_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "subGridlanguages_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Width", StringUtil.RTrim( Dvpanel_unnamedtable6_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Cls", StringUtil.RTrim( Dvpanel_unnamedtable6_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Title", StringUtil.RTrim( Dvpanel_unnamedtable6_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable6_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE6_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable6_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE7_Width", StringUtil.RTrim( Dvpanel_unnamedtable7_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE7_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE7_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE7_Cls", StringUtil.RTrim( Dvpanel_unnamedtable7_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE7_Title", StringUtil.RTrim( Dvpanel_unnamedtable7_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE7_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE7_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE7_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE7_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable7_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE7_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE8_Width", StringUtil.RTrim( Dvpanel_unnamedtable8_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE8_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE8_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE8_Cls", StringUtil.RTrim( Dvpanel_unnamedtable8_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE8_Title", StringUtil.RTrim( Dvpanel_unnamedtable8_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE8_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE8_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE8_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE8_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable8_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE8_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Class", StringUtil.RTrim( Gridlanguagespaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridlanguagespaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridlanguagespaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridlanguagespaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridlanguagespaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridlanguagespaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridlanguagespaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridlanguagespaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridlanguagespaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridlanguagespaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridlanguagespaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridlanguagespaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Previous", StringUtil.RTrim( Gridlanguagespaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Next", StringUtil.RTrim( Gridlanguagespaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Caption", StringUtil.RTrim( Gridlanguagespaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridlanguagespaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridlanguagespaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridlanguages_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridlanguagespaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridlanguagespaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vONLINE_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavOnline.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridlanguagespaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGESPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridlanguagespaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0Y2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gamapplicationentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV43Id,12,0))}, new string[] {"Gx_mode","Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "GAMApplicationEntry" ;
      }

      public override string GetPgmdesc( )
      {
         return "Application" ;
      }

      protected void WB0Y0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 100, "%", 0, "px", "TableMain", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto auto auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLefttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
            ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
            ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
            ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, "GXUITABSPANEL_TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "General", "", "", lblGeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavId_Internalname, "Id", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43Id), 12, 0, ".", "")), StringUtil.LTrim( ((edtavId_Enabled!=0) ? context.localUtil.Format( (decimal)(AV43Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV43Id), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "end", false, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, "GUID", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV41GUID), StringUtil.RTrim( context.localUtil.Format( AV41GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavGuid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV49Name), StringUtil.RTrim( context.localUtil.Format( AV49Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDsc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, "Description", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV30Dsc), StringUtil.RTrim( context.localUtil.Format( AV30Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavVersion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVersion_Internalname, "Version", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVersion_Internalname, StringUtil.RTrim( AV64Version), StringUtil.RTrim( context.localUtil.Format( AV64Version, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVersion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavVersion_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCompany_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCompany_Internalname, "Company", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCompany_Internalname, StringUtil.RTrim( AV28Company), StringUtil.RTrim( context.localUtil.Format( AV28Company, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCompany_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCompany_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCopyright_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCopyright_Internalname, "Copyright", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCopyright_Internalname, StringUtil.RTrim( AV29Copyright), StringUtil.RTrim( context.localUtil.Format( AV29Copyright, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCopyright_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCopyright_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavReturnmenuoptionswithoutpermission_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavReturnmenuoptionswithoutpermission_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavReturnmenuoptionswithoutpermission_Internalname, StringUtil.BoolToStr( AV156ReturnMenuOptionsWithoutPermission), "", " ", 1, chkavReturnmenuoptionswithoutpermission.Enabled, "true", "Return menu options without permission?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(64, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,64);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavMainmenu_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMainmenu_Internalname, "Main Menu", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_567_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMainmenu, cmbavMainmenu_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV46MainMenu), 12, 0)), 1, cmbavMainmenu_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavMainmenu.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_GAMApplicationEntry.htm");
            cmbavMainmenu.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV46MainMenu), 12, 0));
            AssignProp("", false, cmbavMainmenu_Internalname, "Values", (string)(cmbavMainmenu.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavUseabsoluteurlbyenvironment_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUseabsoluteurlbyenvironment_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUseabsoluteurlbyenvironment_Internalname, StringUtil.BoolToStr( AV61UseAbsoluteUrlByEnvironment), "", " ", 1, chkavUseabsoluteurlbyenvironment.Enabled, "true", "Use absolute URL by Environment", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavHomeobject_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHomeobject_Internalname, "Home Object", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavHomeobject_Internalname, AV42HomeObject, StringUtil.RTrim( context.localUtil.Format( AV42HomeObject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHomeobject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavHomeobject_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAccountactivationobject_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAccountactivationobject_Internalname, "Account Activation Object", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAccountactivationobject_Internalname, AV66AccountActivationObject, StringUtil.RTrim( context.localUtil.Format( AV66AccountActivationObject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAccountactivationobject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAccountactivationobject_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedlogoutobject_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocklogoutobject_Internalname, "Local Logout Object (specify an object or a URL)", "", "", lblTextblocklogoutobject_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_92_0Y2( true) ;
         }
         else
         {
            wb_table1_92_0Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_92_0Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRemoteauthentication_title_Internalname, "OAuth Authentication", "", "", lblRemoteauthentication_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "RemoteAuthentication") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavClientaccessstatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavClientaccessstatus_Internalname, "Status", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_567_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClientaccessstatus, cmbavClientaccessstatus_Internalname, StringUtil.RTrim( AV123ClientAccessStatus), 1, cmbavClientaccessstatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavClientaccessstatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "", true, 0, "HLP_GAMApplicationEntry.htm");
            cmbavClientaccessstatus.CurrentValue = StringUtil.RTrim( AV123ClientAccessStatus);
            AssignProp("", false, cmbavClientaccessstatus_Internalname, "Values", (string)(cmbavClientaccessstatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavClientrevoked_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientrevoked_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientrevoked_Internalname, "Revoked", " AttributeDateTimeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'" + sGXsfl_567_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavClientrevoked_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavClientrevoked_Internalname, context.localUtil.TToC( AV26ClientRevoked, 10, 8, 1, 3, "/", ":", " "), context.localUtil.Format( AV26ClientRevoked, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,12,'eng',false,0);"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientrevoked_Jsonclick, 0, "AttributeDateTime", "", "", "", "", edtavClientrevoked_Visible, edtavClientrevoked_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "end", false, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_bitmap( context, edtavClientrevoked_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavClientrevoked_Visible==0)||(edtavClientrevoked_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMApplicationEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientid_Internalname, "Client Id", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientid_Internalname, StringUtil.RTrim( AV22ClientId), StringUtil.RTrim( context.localUtil.Format( AV22ClientId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMClientApplicationId", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedclientsecret_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockclientsecret_Internalname, "Client secret", "", "", lblTextblockclientsecret_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table2_126_0Y2( true) ;
         }
         else
         {
            wb_table2_126_0Y2( false) ;
         }
         return  ;
      }

      protected void wb_table2_126_0Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientauthrequestmustincludeuserscopes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientauthrequestmustincludeuserscopes_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientauthrequestmustincludeuserscopes_Internalname, StringUtil.BoolToStr( AV128ClientAuthRequestMustIncludeUserScopes), "", " ", 1, chkavClientauthrequestmustincludeuserscopes.Enabled, "true", "Authentication request must include user scopes?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(137, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,137);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientdonotshareuserids_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientdonotshareuserids_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientdonotshareuserids_Internalname, StringUtil.BoolToStr( AV129ClientDoNotShareUserIDs), "", " ", 1, chkavClientdonotshareuserids.Enabled, "true", "Do not share user IDs", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(142, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,142);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable6.SetProperty("Width", Dvpanel_unnamedtable6_Width);
            ucDvpanel_unnamedtable6.SetProperty("AutoWidth", Dvpanel_unnamedtable6_Autowidth);
            ucDvpanel_unnamedtable6.SetProperty("AutoHeight", Dvpanel_unnamedtable6_Autoheight);
            ucDvpanel_unnamedtable6.SetProperty("Cls", Dvpanel_unnamedtable6_Cls);
            ucDvpanel_unnamedtable6.SetProperty("Title", Dvpanel_unnamedtable6_Title);
            ucDvpanel_unnamedtable6.SetProperty("Collapsible", Dvpanel_unnamedtable6_Collapsible);
            ucDvpanel_unnamedtable6.SetProperty("Collapsed", Dvpanel_unnamedtable6_Collapsed);
            ucDvpanel_unnamedtable6.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable6_Showcollapseicon);
            ucDvpanel_unnamedtable6.SetProperty("IconPosition", Dvpanel_unnamedtable6_Iconposition);
            ucDvpanel_unnamedtable6.SetProperty("AutoScroll", Dvpanel_unnamedtable6_Autoscroll);
            ucDvpanel_unnamedtable6.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable6_Internalname, "DVPANEL_UNNAMEDTABLE6Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE6Container"+"UnnamedTable6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowremoteauth_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowremoteauth_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowremoteauth_Internalname, StringUtil.BoolToStr( AV17ClientAllowRemoteAuth), "", " ", 1, chkavClientallowremoteauth.Enabled, "true", "Allow remote authentication?", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,152);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblwebauth_Internalname, divTblwebauth_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowgetuserdata_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuserdata_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuserdata_Internalname, StringUtil.BoolToStr( AV126ClientAllowGetUserData), "", " ", 1, chkavClientallowgetuserdata.Enabled, "true", "User data", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(160, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,160);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowgetuseradddata_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuseradddata_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuseradddata_Internalname, StringUtil.BoolToStr( AV13ClientAllowGetUserAddData), "", " ", 1, chkavClientallowgetuseradddata.Enabled, "true", "Can get user additional data?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(165, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,165);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowgetuserroles_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuserroles_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuserroles_Internalname, StringUtil.BoolToStr( AV15ClientAllowGetUserRoles), "", " ", 1, chkavClientallowgetuserroles.Enabled, "true", "Can get user roles?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(170, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,170);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowgetsessioniniprop_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetsessioniniprop_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetsessioniniprop_Internalname, StringUtil.BoolToStr( AV11ClientAllowGetSessionIniProp), "", " ", 1, chkavClientallowgetsessioniniprop.Enabled, "true", "Can get session initial properties?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(175, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,175);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowgetsessionappdata_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetsessionappdata_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetsessionappdata_Internalname, StringUtil.BoolToStr( AV9ClientAllowGetSessionAppData), "", " ", 1, chkavClientallowgetsessionappdata.Enabled, "true", "Session application data", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(180, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,180);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientallowadditionalscope_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientallowadditionalscope_Internalname, "Additional user scopes", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 185,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientallowadditionalscope_Internalname, AV124ClientAllowAdditionalScope, StringUtil.RTrim( context.localUtil.Format( AV124ClientAllowAdditionalScope, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,185);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientallowadditionalscope_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientallowadditionalscope_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientimageurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientimageurl_Internalname, "Image URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientimageurl_Internalname, AV23ClientImageURL, StringUtil.RTrim( context.localUtil.Format( AV23ClientImageURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,190);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientimageurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientimageurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientlocalloginurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientlocalloginurl_Internalname, "Local Login URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 195,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientlocalloginurl_Internalname, AV24ClientLocalLoginURL, StringUtil.RTrim( context.localUtil.Format( AV24ClientLocalLoginURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,195);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientlocalloginurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientlocalloginurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientcallbackurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientcallbackurl_Internalname, "Callback URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientcallbackurl_Internalname, AV19ClientCallbackURL, StringUtil.RTrim( context.localUtil.Format( AV19ClientCallbackURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,200);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientcallbackurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientcallbackurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientcallbackurliscustom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientcallbackurliscustom_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientcallbackurliscustom_Internalname, StringUtil.BoolToStr( AV20ClientCallbackURLisCustom), "", " ", 1, chkavClientcallbackurliscustom.Enabled, "true", "Custom callback URL?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(205, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,205);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientcallbackurlstatename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientcallbackurlstatename_Internalname, "State parameter name in response", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 210,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientcallbackurlstatename_Internalname, StringUtil.RTrim( AV65ClientCallbackURLStateName), StringUtil.RTrim( context.localUtil.Format( AV65ClientCallbackURLStateName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,210);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientcallbackurlstatename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientcallbackurlstatename_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable7.SetProperty("Width", Dvpanel_unnamedtable7_Width);
            ucDvpanel_unnamedtable7.SetProperty("AutoWidth", Dvpanel_unnamedtable7_Autowidth);
            ucDvpanel_unnamedtable7.SetProperty("AutoHeight", Dvpanel_unnamedtable7_Autoheight);
            ucDvpanel_unnamedtable7.SetProperty("Cls", Dvpanel_unnamedtable7_Cls);
            ucDvpanel_unnamedtable7.SetProperty("Title", Dvpanel_unnamedtable7_Title);
            ucDvpanel_unnamedtable7.SetProperty("Collapsible", Dvpanel_unnamedtable7_Collapsible);
            ucDvpanel_unnamedtable7.SetProperty("Collapsed", Dvpanel_unnamedtable7_Collapsed);
            ucDvpanel_unnamedtable7.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable7_Showcollapseicon);
            ucDvpanel_unnamedtable7.SetProperty("IconPosition", Dvpanel_unnamedtable7_Iconposition);
            ucDvpanel_unnamedtable7.SetProperty("AutoScroll", Dvpanel_unnamedtable7_Autoscroll);
            ucDvpanel_unnamedtable7.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable7_Internalname, "DVPANEL_UNNAMEDTABLE7Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE7Container"+"UnnamedTable7"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowremoterestauth_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowremoterestauth_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 220,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowremoterestauth_Internalname, StringUtil.BoolToStr( AV18ClientAllowRemoteRestAuth), "", " ", 1, chkavClientallowremoterestauth.Enabled, "true", "Allow authentication v.2.0 ?", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,220);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblrestauth_Internalname, divTblrestauth_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowgetuserdatarest_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuserdatarest_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 228,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuserdatarest_Internalname, StringUtil.BoolToStr( AV127ClientAllowGetUserDataREST), "", " ", 1, chkavClientallowgetuserdatarest.Enabled, "true", "User data", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(228, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,228);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowgetuseradddatarest_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuseradddatarest_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 233,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuseradddatarest_Internalname, StringUtil.BoolToStr( AV14ClientAllowGetUserAddDataRest), "", " ", 1, chkavClientallowgetuseradddatarest.Enabled, "true", "Can get user additional data?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(233, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,233);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowgetuserrolesrest_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetuserrolesrest_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 238,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetuserrolesrest_Internalname, StringUtil.BoolToStr( AV16ClientAllowGetUserRolesRest), "", " ", 1, chkavClientallowgetuserrolesrest.Enabled, "true", "Can get user roles?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(238, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,238);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowgetsessioniniproprest_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetsessioniniproprest_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 243,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetsessioniniproprest_Internalname, StringUtil.BoolToStr( AV12ClientAllowGetSessionIniPropRest), "", " ", 1, chkavClientallowgetsessioniniproprest.Enabled, "true", "Can get session initial properties?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(243, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,243);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientallowgetsessionappdatarest_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientallowgetsessionappdatarest_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 248,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientallowgetsessionappdatarest_Internalname, StringUtil.BoolToStr( AV10ClientAllowGetSessionAppDataREST), "", " ", 1, chkavClientallowgetsessionappdatarest.Enabled, "true", "Session application data", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(248, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,248);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientallowadditionalscoperest_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientallowadditionalscoperest_Internalname, "Additional user scopes", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 253,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientallowadditionalscoperest_Internalname, AV125ClientAllowAdditionalScopeREST, StringUtil.RTrim( context.localUtil.Format( AV125ClientAllowAdditionalScopeREST, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,253);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientallowadditionalscoperest_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientallowadditionalscoperest_Enabled, 1, "text", "", 100, "%", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblgeneralauth_Internalname, divTblgeneralauth_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable8.SetProperty("Width", Dvpanel_unnamedtable8_Width);
            ucDvpanel_unnamedtable8.SetProperty("AutoWidth", Dvpanel_unnamedtable8_Autowidth);
            ucDvpanel_unnamedtable8.SetProperty("AutoHeight", Dvpanel_unnamedtable8_Autoheight);
            ucDvpanel_unnamedtable8.SetProperty("Cls", Dvpanel_unnamedtable8_Cls);
            ucDvpanel_unnamedtable8.SetProperty("Title", Dvpanel_unnamedtable8_Title);
            ucDvpanel_unnamedtable8.SetProperty("Collapsible", Dvpanel_unnamedtable8_Collapsible);
            ucDvpanel_unnamedtable8.SetProperty("Collapsed", Dvpanel_unnamedtable8_Collapsed);
            ucDvpanel_unnamedtable8.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable8_Showcollapseicon);
            ucDvpanel_unnamedtable8.SetProperty("IconPosition", Dvpanel_unnamedtable8_Iconposition);
            ucDvpanel_unnamedtable8.SetProperty("AutoScroll", Dvpanel_unnamedtable8_Autoscroll);
            ucDvpanel_unnamedtable8.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable8_Internalname, "DVPANEL_UNNAMEDTABLE8Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE8Container"+"UnnamedTable8"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavClientaccessuniquebyuser_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavClientaccessuniquebyuser_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 266,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavClientaccessuniquebyuser_Internalname, StringUtil.BoolToStr( AV8ClientAccessUniqueByUser), "", " ", 1, chkavClientaccessuniquebyuser.Enabled, "true", "Single user access?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(266, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,266);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedclientencryptionkey_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockclientencryptionkey_Internalname, "Private encryption key", "", "", lblTextblockclientencryptionkey_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table3_274_0Y2( true) ;
         }
         else
         {
            wb_table3_274_0Y2( false) ;
         }
         return  ;
      }

      protected void wb_table3_274_0Y2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavClientrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientrepositoryguid_Internalname, "Repository guid", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 285,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientrepositoryguid_Internalname, StringUtil.RTrim( AV25ClientRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV25ClientRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,285);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientrepositoryguid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientrepositoryguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAuthorization_title_Internalname, "Authorization", "", "", lblAuthorization_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Authorization") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAccessrequirespermission_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAccessrequirespermission_Internalname, "Enable Authorization?", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 295,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAccessrequirespermission_Internalname, StringUtil.BoolToStr( AV5AccessRequiresPermission), "", "Enable Authorization?", 1, chkavAccessrequirespermission.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(295, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,295);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbldelegateauthorization_Internalname, divTbldelegateauthorization_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavIsauthorizationdelegated_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsauthorizationdelegated_Internalname, "Delegate authorization checking to an external program?", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 303,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsauthorizationdelegated_Internalname, StringUtil.BoolToStr( AV143IsAuthorizationDelegated), "", "Delegate authorization checking to an external program?", 1, chkavIsauthorizationdelegated.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(303, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,303);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbldelegateauthorizationprop_Internalname, divTbldelegateauthorizationprop_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavDelegateauthorizationversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDelegateauthorizationversion_Internalname, "Version", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 311,'',false,'" + sGXsfl_567_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDelegateauthorizationversion, cmbavDelegateauthorizationversion_Internalname, StringUtil.RTrim( AV134DelegateAuthorizationVersion), 1, cmbavDelegateauthorizationversion_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavDelegateauthorizationversion.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,311);\"", "", true, 0, "HLP_GAMApplicationEntry.htm");
            cmbavDelegateauthorizationversion.CurrentValue = StringUtil.RTrim( AV134DelegateAuthorizationVersion);
            AssignProp("", false, cmbavDelegateauthorizationversion_Internalname, "Values", (string)(cmbavDelegateauthorizationversion.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDelegateauthorizationfilename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDelegateauthorizationfilename_Internalname, "File name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 316,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDelegateauthorizationfilename_Internalname, StringUtil.RTrim( AV131DelegateAuthorizationFileName), StringUtil.RTrim( context.localUtil.Format( AV131DelegateAuthorizationFileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,316);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDelegateauthorizationfilename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDelegateauthorizationfilename_Enabled, 1, "text", "", 60, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDelegateauthorizationpackage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDelegateauthorizationpackage_Internalname, "Package Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 321,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDelegateauthorizationpackage_Internalname, StringUtil.RTrim( AV133DelegateAuthorizationPackage), StringUtil.RTrim( context.localUtil.Format( AV133DelegateAuthorizationPackage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,321);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDelegateauthorizationpackage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDelegateauthorizationpackage_Enabled, 1, "text", "", 60, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDelegateauthorizationclassname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDelegateauthorizationclassname_Internalname, "Class Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 326,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDelegateauthorizationclassname_Internalname, StringUtil.RTrim( AV130DelegateAuthorizationClassName), StringUtil.RTrim( context.localUtil.Format( AV130DelegateAuthorizationClassName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,326);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDelegateauthorizationclassname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDelegateauthorizationclassname_Enabled, 1, "text", "", 60, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDelegateauthorizationmethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDelegateauthorizationmethod_Internalname, "Method Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 331,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDelegateauthorizationmethod_Internalname, StringUtil.RTrim( AV132DelegateAuthorizationMethod), StringUtil.RTrim( context.localUtil.Format( AV132DelegateAuthorizationMethod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,331);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDelegateauthorizationmethod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDelegateauthorizationmethod_Enabled, 1, "text", "", 60, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSsorest_title_Internalname, "SSO Rest", "", "", lblSsorest_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "SSORest") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavSsorestenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSsorestenable_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 341,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSsorestenable_Internalname, StringUtil.BoolToStr( AV50SSORestEnable), "", " ", 1, chkavSsorestenable.Enabled, "true", "Enable SSO Rest services?", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,341);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablessorest_Internalname, divTablessorest_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSsorestmode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSsorestmode_Internalname, "Mode SSO Rest", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 349,'',false,'" + sGXsfl_567_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSsorestmode, cmbavSsorestmode_Internalname, StringUtil.RTrim( AV51SSORestMode), 1, cmbavSsorestmode_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVSSORESTMODE.CLICK."+"'", "char", "", 1, cmbavSsorestmode.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,349);\"", "", true, 0, "HLP_GAMApplicationEntry.htm");
            cmbavSsorestmode.CurrentValue = StringUtil.RTrim( AV51SSORestMode);
            AssignProp("", false, cmbavSsorestmode_Internalname, "Values", (string)(cmbavSsorestmode.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblssorestmodeclient_Internalname, divTblssorestmodeclient_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSsorestuserauthtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSsorestuserauthtypename_Internalname, "User authentication type name in this server", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 357,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSsorestuserauthtypename_Internalname, StringUtil.RTrim( AV53SSORestUserAuthTypeName), StringUtil.RTrim( context.localUtil.Format( AV53SSORestUserAuthTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,357);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSsorestuserauthtypename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSsorestuserauthtypename_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSsorestserverurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSsorestserverurl_Internalname, "Server URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 362,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSsorestserverurl_Internalname, AV52SSORestServerURL, StringUtil.RTrim( context.localUtil.Format( AV52SSORestServerURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,362);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSsorestserverurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSsorestserverurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavSsorestserverurl_iscustom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSsorestserverurl_iscustom_Internalname, "Custom server URL SSO", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 367,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSsorestserverurl_iscustom_Internalname, StringUtil.BoolToStr( AV159SSORestServerURL_isCustom), "", "Custom server URL SSO", 1, chkavSsorestserverurl_iscustom.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(367, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,367);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSsorestserverurl_slo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSsorestserverurl_slo_Internalname, "Server URL SLO", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 372,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSsorestserverurl_slo_Internalname, AV160SSORestServerURL_SLO, StringUtil.RTrim( context.localUtil.Format( AV160SSORestServerURL_SLO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,372);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSsorestserverurl_slo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSsorestserverurl_slo_Enabled, 1, "text", "", 60, "chr", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSsorestserverrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSsorestserverrepositoryguid_Internalname, "Server repository GUID", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 377,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSsorestserverrepositoryguid_Internalname, StringUtil.RTrim( AV158SSORestServerRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV158SSORestServerRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,377);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSsorestserverrepositoryguid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSsorestserverrepositoryguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSsorestserverkey_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSsorestserverkey_Internalname, "Server encryption key", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 382,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSsorestserverkey_Internalname, StringUtil.RTrim( AV157SSORestServerKey), StringUtil.RTrim( context.localUtil.Format( AV157SSORestServerKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,382);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSsorestserverkey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSsorestserverkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title5"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSts_title_Internalname, "STS", "", "", lblSts_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "STS") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavStsprotocolenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavStsprotocolenable_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 392,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavStsprotocolenable_Internalname, StringUtil.BoolToStr( AV57STSProtocolEnable), "", " ", 1, chkavStsprotocolenable.Enabled, "true", "Enable STS protocol?", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,392);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablests_Internalname, divTablests_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavStsmode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavStsmode_Internalname, "STS Mode", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 400,'',false,'" + sGXsfl_567_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavStsmode, cmbavStsmode_Internalname, StringUtil.RTrim( AV56STSMode), 1, cmbavStsmode_Jsonclick, 7, "'"+""+"'"+",false,"+"'"+"e110y1_client"+"'", "char", "", 1, cmbavStsmode.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,400);\"", "", true, 0, "HLP_GAMApplicationEntry.htm");
            cmbavStsmode.CurrentValue = StringUtil.RTrim( AV56STSMode);
            AssignProp("", false, cmbavStsmode_Internalname, "Values", (string)(cmbavStsmode.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablestsserverchecktoken_Internalname, divTablestsserverchecktoken_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavStsauthorizationusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStsauthorizationusername_Internalname, "User name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 408,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStsauthorizationusername_Internalname, AV55STSAuthorizationUserName, StringUtil.RTrim( context.localUtil.Format( AV55STSAuthorizationUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,408);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStsauthorizationusername_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavStsauthorizationusername_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divTablestsclientgettoken_Internalname, divTablestsclientgettoken_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divStsserverclientpassword_cell_Internalname, 1, 0, "px", 0, "px", divStsserverclientpassword_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavStsserverclientpassword_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavStsserverclientpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStsserverclientpassword_Internalname, "Client password", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 416,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStsserverclientpassword_Internalname, StringUtil.RTrim( AV58STSServerClientPassword), StringUtil.RTrim( context.localUtil.Format( AV58STSServerClientPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,416);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStsserverclientpassword_Jsonclick, 0, "Attribute", "", "", "", "", edtavStsserverclientpassword_Visible, edtavStsserverclientpassword_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divTablestsclient_Internalname, divTablestsclient_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavStsserverurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStsserverurl_Internalname, "Server URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 424,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStsserverurl_Internalname, AV60STSServerURL, StringUtil.RTrim( context.localUtil.Format( AV60STSServerURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,424);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStsserverurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavStsserverurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavStsserverrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStsserverrepositoryguid_Internalname, "Repository guid", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 429,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStsserverrepositoryguid_Internalname, StringUtil.RTrim( AV59STSServerRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV59STSServerRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,429);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStsserverrepositoryguid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavStsserverrepositoryguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title6"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMiniapp_title_Internalname, "MiniApp", "", "", lblMiniapp_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "MiniApp") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divMiniapptable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavMiniappenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavMiniappenable_Internalname, "Enable work as MiniApp?", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 439,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavMiniappenable_Internalname, StringUtil.BoolToStr( AV148MiniAppEnable), "", "Enable work as MiniApp?", 1, chkavMiniappenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(439, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,439);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblminiapp_Internalname, divTblminiapp_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavMiniappmode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMiniappmode_Internalname, "Mode", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 447,'',false,'" + sGXsfl_567_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMiniappmode, cmbavMiniappmode_Internalname, StringUtil.RTrim( AV149MiniAppMode), 1, cmbavMiniappmode_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavMiniappmode.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,447);\"", "", true, 0, "HLP_GAMApplicationEntry.htm");
            cmbavMiniappmode.CurrentValue = StringUtil.RTrim( AV149MiniAppMode);
            AssignProp("", false, cmbavMiniappmode_Internalname, "Values", (string)(cmbavMiniappmode.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblminiappserver_Internalname, divTblminiappserver_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMiniappclienturl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMiniappclienturl_Internalname, "MiniApp client URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 455,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMiniappclienturl_Internalname, AV146MiniAppClientURL, StringUtil.RTrim( context.localUtil.Format( AV146MiniAppClientURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,455);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMiniappclienturl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavMiniappclienturl_Enabled, 1, "text", "", 100, "%", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavMiniappclienturl_iscustom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavMiniappclienturl_iscustom_Internalname, "Custom MiniApp client URL", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 460,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavMiniappclienturl_iscustom_Internalname, StringUtil.BoolToStr( AV147MiniAppClientURL_isCustom), "", "Custom MiniApp client URL", 1, chkavMiniappclienturl_iscustom.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(460, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,460);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMiniappclientrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMiniappclientrepositoryguid_Internalname, "MiniApp client repository GUID", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 465,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMiniappclientrepositoryguid_Internalname, StringUtil.RTrim( AV145MiniAppClientRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV145MiniAppClientRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,465);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMiniappclientrepositoryguid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavMiniappclientrepositoryguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divTblminiappclient_Internalname, divTblminiappclient_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavMiniappuserauthenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMiniappuserauthenticationtypename_Internalname, "User authentication type name in this client", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 473,'',false,'" + sGXsfl_567_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMiniappuserauthenticationtypename, cmbavMiniappuserauthenticationtypename_Internalname, StringUtil.RTrim( AV153MiniAppUserAuthenticationTypeName), 1, cmbavMiniappuserauthenticationtypename_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavMiniappuserauthenticationtypename.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,473);\"", "", true, 0, "HLP_GAMApplicationEntry.htm");
            cmbavMiniappuserauthenticationtypename.CurrentValue = StringUtil.RTrim( AV153MiniAppUserAuthenticationTypeName);
            AssignProp("", false, cmbavMiniappuserauthenticationtypename_Internalname, "Values", (string)(cmbavMiniappuserauthenticationtypename.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMiniappserverurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMiniappserverurl_Internalname, "SuperApp server URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 478,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMiniappserverurl_Internalname, AV151MiniAppServerURL, StringUtil.RTrim( context.localUtil.Format( AV151MiniAppServerURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,478);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMiniappserverurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavMiniappserverurl_Enabled, 1, "text", "", 100, "%", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavMiniappserverurl_iscustom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavMiniappserverurl_iscustom_Internalname, "Custom SuperApp server URL", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 483,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavMiniappserverurl_iscustom_Internalname, StringUtil.BoolToStr( AV152MiniAppServerURL_isCustom), "", "Custom SuperApp server URL", 1, chkavMiniappserverurl_iscustom.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(483, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,483);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavMiniappserverrepositoryguid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMiniappserverrepositoryguid_Internalname, "SuperApp repository GUID", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 488,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavMiniappserverrepositoryguid_Internalname, StringUtil.RTrim( AV150MiniAppServerRepositoryGUID), StringUtil.RTrim( context.localUtil.Format( AV150MiniAppServerRepositoryGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,488);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavMiniappserverrepositoryguid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavMiniappserverrepositoryguid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title7"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblApikey_title_Internalname, "API Key", "", "", lblApikey_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "APIkey") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel7"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divApikeytable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavApikeyenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavApikeyenable_Internalname, "Enable work with API keys", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 498,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavApikeyenable_Internalname, StringUtil.BoolToStr( AV120APIKeyEnable), "", "Enable work with API keys", 1, chkavApikeyenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(498, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,498);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblapikey_Internalname, divTblapikey_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavApikeytimeout_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavApikeytimeout_Internalname, "API Key timeout (In hours)", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 506,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavApikeytimeout_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV121APIKeyTimeout), 9, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV121APIKeyTimeout), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,506);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavApikeytimeout_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavApikeytimeout_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumShort", "end", false, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavApikeyallowonlyauthenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavApikeyallowonlyauthenticationtypename_Internalname, "Allow only this authentication type name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 511,'',false,'" + sGXsfl_567_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavApikeyallowonlyauthenticationtypename, cmbavApikeyallowonlyauthenticationtypename_Internalname, StringUtil.RTrim( AV118APIKeyAllowOnlyAuthenticationTypeName), 1, cmbavApikeyallowonlyauthenticationtypename_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavApikeyallowonlyauthenticationtypename.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,511);\"", "", true, 0, "HLP_GAMApplicationEntry.htm");
            cmbavApikeyallowonlyauthenticationtypename.CurrentValue = StringUtil.RTrim( AV118APIKeyAllowOnlyAuthenticationTypeName);
            AssignProp("", false, cmbavApikeyallowonlyauthenticationtypename_Internalname, "Values", (string)(cmbavApikeyallowonlyauthenticationtypename.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavApikeyallowscopecustomization_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavApikeyallowscopecustomization_Internalname, "API Key Allow Scope Customization", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 516,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavApikeyallowscopecustomization_Internalname, StringUtil.BoolToStr( AV119APIKeyAllowScopeCustomization), "", "API Key Allow Scope Customization", 1, chkavApikeyallowscopecustomization.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(516, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,516);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title8"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEnvironmentsettings_title_Internalname, "Environment Settings", "", "", lblEnvironmentsettings_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "EnvironmentSettings") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel8"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnvironmentname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentname_Internalname, "Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 526,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentname_Internalname, StringUtil.RTrim( AV32EnvironmentName), StringUtil.RTrim( context.localUtil.Format( AV32EnvironmentName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,526);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmentname_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavEnvironmentsecureprotocol_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEnvironmentsecureprotocol_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 531,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEnvironmentsecureprotocol_Internalname, StringUtil.BoolToStr( AV36EnvironmentSecureProtocol), "", " ", 1, chkavEnvironmentsecureprotocol.Enabled, "true", "Is HTTPS?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(531, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,531);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnvironmenthost_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmenthost_Internalname, "Host", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 536,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmenthost_Internalname, StringUtil.RTrim( AV31EnvironmentHost), StringUtil.RTrim( context.localUtil.Format( AV31EnvironmentHost, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,536);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmenthost_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmenthost_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnvironmentport_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentport_Internalname, "Port", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 541,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentport_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33EnvironmentPort), 5, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33EnvironmentPort), "ZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,541);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentport_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmentport_Enabled, 1, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnvironmentvirtualdirectory_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentvirtualdirectory_Internalname, "Virtual Directory", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 546,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentvirtualdirectory_Internalname, StringUtil.RTrim( AV37EnvironmentVirtualDirectory), StringUtil.RTrim( context.localUtil.Format( AV37EnvironmentVirtualDirectory, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,546);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentvirtualdirectory_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmentvirtualdirectory_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnvironmentprogrampackage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentprogrampackage_Internalname, "Package", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 551,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentprogrampackage_Internalname, StringUtil.RTrim( AV35EnvironmentProgramPackage), StringUtil.RTrim( context.localUtil.Format( AV35EnvironmentProgramPackage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,551);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentprogrampackage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmentprogrampackage_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEnvironmentprogramextension_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnvironmentprogramextension_Internalname, "Extension", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 556,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEnvironmentprogramextension_Internalname, StringUtil.RTrim( AV34EnvironmentProgramExtension), StringUtil.RTrim( context.localUtil.Format( AV34EnvironmentProgramExtension, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,556);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnvironmentprogramextension_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEnvironmentprogramextension_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title9"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLanguages_title_Internalname, "Languages", "", "", lblLanguages_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMApplicationEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Languages") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel9"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divLanguagestable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridlanguagestablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridlanguagesContainer.SetWrapped(nGXWrapped);
            StartGridControl567( ) ;
         }
         if ( wbEnd == 567 )
         {
            wbEnd = 0;
            nRC_GXsfl_567 = (int)(nGXsfl_567_idx-1);
            if ( GridlanguagesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridlanguagesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlanguages", GridlanguagesContainer, subGridlanguages_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridlanguagesContainerData", GridlanguagesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridlanguagesContainerData"+"V", GridlanguagesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridlanguagesContainerData"+"V"+"\" value='"+GridlanguagesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridlanguagespaginationbar.SetProperty("Class", Gridlanguagespaginationbar_Class);
            ucGridlanguagespaginationbar.SetProperty("ShowFirst", Gridlanguagespaginationbar_Showfirst);
            ucGridlanguagespaginationbar.SetProperty("ShowPrevious", Gridlanguagespaginationbar_Showprevious);
            ucGridlanguagespaginationbar.SetProperty("ShowNext", Gridlanguagespaginationbar_Shownext);
            ucGridlanguagespaginationbar.SetProperty("ShowLast", Gridlanguagespaginationbar_Showlast);
            ucGridlanguagespaginationbar.SetProperty("PagesToShow", Gridlanguagespaginationbar_Pagestoshow);
            ucGridlanguagespaginationbar.SetProperty("PagingButtonsPosition", Gridlanguagespaginationbar_Pagingbuttonsposition);
            ucGridlanguagespaginationbar.SetProperty("PagingCaptionPosition", Gridlanguagespaginationbar_Pagingcaptionposition);
            ucGridlanguagespaginationbar.SetProperty("EmptyGridClass", Gridlanguagespaginationbar_Emptygridclass);
            ucGridlanguagespaginationbar.SetProperty("RowsPerPageSelector", Gridlanguagespaginationbar_Rowsperpageselector);
            ucGridlanguagespaginationbar.SetProperty("RowsPerPageOptions", Gridlanguagespaginationbar_Rowsperpageoptions);
            ucGridlanguagespaginationbar.SetProperty("Previous", Gridlanguagespaginationbar_Previous);
            ucGridlanguagespaginationbar.SetProperty("Next", Gridlanguagespaginationbar_Next);
            ucGridlanguagespaginationbar.SetProperty("Caption", Gridlanguagespaginationbar_Caption);
            ucGridlanguagespaginationbar.SetProperty("EmptyGridCaption", Gridlanguagespaginationbar_Emptygridcaption);
            ucGridlanguagespaginationbar.SetProperty("RowsPerPageCaption", Gridlanguagespaginationbar_Rowsperpagecaption);
            ucGridlanguagespaginationbar.SetProperty("CurrentPage", AV140GridLanguagesCurrentPage);
            ucGridlanguagespaginationbar.SetProperty("PageCount", AV141GridLanguagesPageCount);
            ucGridlanguagespaginationbar.SetProperty("AppliedFilters", AV139GridLanguagesAppliedFilters);
            ucGridlanguagespaginationbar.Render(context, "dvelop.dvpaginationbar", Gridlanguagespaginationbar_Internalname, "GRIDLANGUAGESPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 577,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(567), 3, 0)+","+"null"+");", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 579,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(567), 3, 0)+","+"null"+");", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRighttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 585,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGridlanguagescurrentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV140GridLanguagesCurrentPage), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV140GridLanguagesCurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,585);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGridlanguagescurrentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGridlanguagescurrentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_GAMApplicationEntry.htm");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 586,'',false,'" + sGXsfl_567_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAutoregisteranomymoususer_Internalname, StringUtil.BoolToStr( AV7AutoRegisterAnomymousUser), "", "", chkavAutoregisteranomymoususer.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(586, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,586);\"");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 587,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStsauthorizationuserguid_Internalname, StringUtil.RTrim( AV54STSAuthorizationUserGUID), StringUtil.RTrim( context.localUtil.Format( AV54STSAuthorizationUserGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,587);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStsauthorizationuserguid_Jsonclick, 0, "Attribute", "", "", "", "", edtavStsauthorizationuserguid_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_GAMApplicationEntry.htm");
            /* User Defined Control */
            ucGridlanguages_empowerer.Render(context, "wwp.gridempowerer", Gridlanguages_empowerer_Internalname, "GRIDLANGUAGES_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 567 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridlanguagesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridlanguagesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlanguages", GridlanguagesContainer, subGridlanguages_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridlanguagesContainerData", GridlanguagesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridlanguagesContainerData"+"V", GridlanguagesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridlanguagesContainerData"+"V"+"\" value='"+GridlanguagesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0Y2( )
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
         Form.Meta.addItem("description", "Application", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0Y0( ) ;
      }

      protected void WS0Y2( )
      {
         START0Y2( ) ;
         EVT0Y2( ) ;
      }

      protected void EVT0Y2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDLANGUAGESPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridlanguagespaginationbar.Changepage */
                              E120Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDLANGUAGESPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridlanguagespaginationbar.Changerowsperpage */
                              E130Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOGENERATEKEYGAMREMOTE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoGenerateKeyGAMRemote' */
                              E140Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOREVOKEALLOW'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoRevokeAllow' */
                              E150Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E160Y2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSSORESTENABLE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E170Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSSORESTMODE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E180Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VMINIAPPENABLE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E190Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VMINIAPPMODE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E200Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VAPIKEYENABLE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E210Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSSORESTMODE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E220Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSSORESTENABLE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E230Y2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "GRIDLANGUAGES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "'GENERATEKEYGAMREMOTE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "'REVOKE-AUTHORIZE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'TRANSLATIONS'") == 0 ) )
                           {
                              nGXsfl_567_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_567_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_567_idx), 4, 0), 4, "0");
                              SubsflControlProps_5672( ) ;
                              AV154Online = StringUtil.StrToBool( cgiGet( chkavOnline_Internalname));
                              AssignAttri("", false, chkavOnline_Internalname, AV154Online);
                              AV144Language = cgiGet( edtavLanguage_Internalname);
                              AssignAttri("", false, edtavLanguage_Internalname, AV144Language);
                              GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE"+"_"+sGXsfl_567_idx, GetSecureSignedToken( sGXsfl_567_idx, StringUtil.RTrim( context.localUtil.Format( AV144Language, "")), context));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E240Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E250Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDLANGUAGES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridlanguages.Load */
                                    E260Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'GENERATEKEYGAMREMOTE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'GenerateKeyGAMRemote' */
                                    E270Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'REVOKE-AUTHORIZE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Revoke-Authorize' */
                                    E280Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'TRANSLATIONS'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Translations' */
                                    E290Y2 ();
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

      protected void WE0Y2( )
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

      protected void PA0Y2( )
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
               GX_FocusControl = edtavGuid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridlanguages_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_5672( ) ;
         while ( nGXsfl_567_idx <= nRC_GXsfl_567 )
         {
            sendrow_5672( ) ;
            nGXsfl_567_idx = ((subGridlanguages_Islastpage==1)&&(nGXsfl_567_idx+1>subGridlanguages_fnc_Recordsperpage( )) ? 1 : nGXsfl_567_idx+1);
            sGXsfl_567_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_567_idx), 4, 0), 4, "0");
            SubsflControlProps_5672( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridlanguagesContainer)) ;
         /* End function gxnrGridlanguages_newrow */
      }

      protected void gxgrGridlanguages_refresh( int subGridlanguages_Rows ,
                                                string Gx_mode ,
                                                bool AV156ReturnMenuOptionsWithoutPermission ,
                                                bool AV61UseAbsoluteUrlByEnvironment ,
                                                bool AV128ClientAuthRequestMustIncludeUserScopes ,
                                                bool AV129ClientDoNotShareUserIDs ,
                                                bool AV17ClientAllowRemoteAuth ,
                                                bool AV126ClientAllowGetUserData ,
                                                bool AV13ClientAllowGetUserAddData ,
                                                bool AV15ClientAllowGetUserRoles ,
                                                bool AV11ClientAllowGetSessionIniProp ,
                                                bool AV9ClientAllowGetSessionAppData ,
                                                bool AV20ClientCallbackURLisCustom ,
                                                bool AV18ClientAllowRemoteRestAuth ,
                                                bool AV127ClientAllowGetUserDataREST ,
                                                bool AV14ClientAllowGetUserAddDataRest ,
                                                bool AV16ClientAllowGetUserRolesRest ,
                                                bool AV12ClientAllowGetSessionIniPropRest ,
                                                bool AV10ClientAllowGetSessionAppDataREST ,
                                                bool AV8ClientAccessUniqueByUser ,
                                                bool AV5AccessRequiresPermission ,
                                                bool AV143IsAuthorizationDelegated ,
                                                bool AV50SSORestEnable ,
                                                bool AV159SSORestServerURL_isCustom ,
                                                bool AV57STSProtocolEnable ,
                                                bool AV148MiniAppEnable ,
                                                bool AV147MiniAppClientURL_isCustom ,
                                                bool AV152MiniAppServerURL_isCustom ,
                                                bool AV120APIKeyEnable ,
                                                bool AV119APIKeyAllowScopeCustomization ,
                                                bool AV36EnvironmentSecureProtocol ,
                                                bool AV7AutoRegisterAnomymousUser )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDLANGUAGES_nCurrentRecord = 0;
         RF0Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridlanguages_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV144Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", AV144Language);
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
         AV156ReturnMenuOptionsWithoutPermission = StringUtil.StrToBool( StringUtil.BoolToStr( AV156ReturnMenuOptionsWithoutPermission));
         AssignAttri("", false, "AV156ReturnMenuOptionsWithoutPermission", AV156ReturnMenuOptionsWithoutPermission);
         if ( cmbavMainmenu.ItemCount > 0 )
         {
            AV46MainMenu = (long)(Math.Round(NumberUtil.Val( cmbavMainmenu.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV46MainMenu), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV46MainMenu", StringUtil.LTrimStr( (decimal)(AV46MainMenu), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMainmenu.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV46MainMenu), 12, 0));
            AssignProp("", false, cmbavMainmenu_Internalname, "Values", cmbavMainmenu.ToJavascriptSource(), true);
         }
         AV61UseAbsoluteUrlByEnvironment = StringUtil.StrToBool( StringUtil.BoolToStr( AV61UseAbsoluteUrlByEnvironment));
         AssignAttri("", false, "AV61UseAbsoluteUrlByEnvironment", AV61UseAbsoluteUrlByEnvironment);
         if ( cmbavClientaccessstatus.ItemCount > 0 )
         {
            AV123ClientAccessStatus = cmbavClientaccessstatus.getValidValue(AV123ClientAccessStatus);
            AssignAttri("", false, "AV123ClientAccessStatus", AV123ClientAccessStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClientaccessstatus.CurrentValue = StringUtil.RTrim( AV123ClientAccessStatus);
            AssignProp("", false, cmbavClientaccessstatus_Internalname, "Values", cmbavClientaccessstatus.ToJavascriptSource(), true);
         }
         AV128ClientAuthRequestMustIncludeUserScopes = StringUtil.StrToBool( StringUtil.BoolToStr( AV128ClientAuthRequestMustIncludeUserScopes));
         AssignAttri("", false, "AV128ClientAuthRequestMustIncludeUserScopes", AV128ClientAuthRequestMustIncludeUserScopes);
         AV129ClientDoNotShareUserIDs = StringUtil.StrToBool( StringUtil.BoolToStr( AV129ClientDoNotShareUserIDs));
         AssignAttri("", false, "AV129ClientDoNotShareUserIDs", AV129ClientDoNotShareUserIDs);
         AV17ClientAllowRemoteAuth = StringUtil.StrToBool( StringUtil.BoolToStr( AV17ClientAllowRemoteAuth));
         AssignAttri("", false, "AV17ClientAllowRemoteAuth", AV17ClientAllowRemoteAuth);
         AV126ClientAllowGetUserData = StringUtil.StrToBool( StringUtil.BoolToStr( AV126ClientAllowGetUserData));
         AssignAttri("", false, "AV126ClientAllowGetUserData", AV126ClientAllowGetUserData);
         AV13ClientAllowGetUserAddData = StringUtil.StrToBool( StringUtil.BoolToStr( AV13ClientAllowGetUserAddData));
         AssignAttri("", false, "AV13ClientAllowGetUserAddData", AV13ClientAllowGetUserAddData);
         AV15ClientAllowGetUserRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV15ClientAllowGetUserRoles));
         AssignAttri("", false, "AV15ClientAllowGetUserRoles", AV15ClientAllowGetUserRoles);
         AV11ClientAllowGetSessionIniProp = StringUtil.StrToBool( StringUtil.BoolToStr( AV11ClientAllowGetSessionIniProp));
         AssignAttri("", false, "AV11ClientAllowGetSessionIniProp", AV11ClientAllowGetSessionIniProp);
         AV9ClientAllowGetSessionAppData = StringUtil.StrToBool( StringUtil.BoolToStr( AV9ClientAllowGetSessionAppData));
         AssignAttri("", false, "AV9ClientAllowGetSessionAppData", AV9ClientAllowGetSessionAppData);
         AV20ClientCallbackURLisCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV20ClientCallbackURLisCustom));
         AssignAttri("", false, "AV20ClientCallbackURLisCustom", AV20ClientCallbackURLisCustom);
         AV18ClientAllowRemoteRestAuth = StringUtil.StrToBool( StringUtil.BoolToStr( AV18ClientAllowRemoteRestAuth));
         AssignAttri("", false, "AV18ClientAllowRemoteRestAuth", AV18ClientAllowRemoteRestAuth);
         AV127ClientAllowGetUserDataREST = StringUtil.StrToBool( StringUtil.BoolToStr( AV127ClientAllowGetUserDataREST));
         AssignAttri("", false, "AV127ClientAllowGetUserDataREST", AV127ClientAllowGetUserDataREST);
         AV14ClientAllowGetUserAddDataRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV14ClientAllowGetUserAddDataRest));
         AssignAttri("", false, "AV14ClientAllowGetUserAddDataRest", AV14ClientAllowGetUserAddDataRest);
         AV16ClientAllowGetUserRolesRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV16ClientAllowGetUserRolesRest));
         AssignAttri("", false, "AV16ClientAllowGetUserRolesRest", AV16ClientAllowGetUserRolesRest);
         AV12ClientAllowGetSessionIniPropRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV12ClientAllowGetSessionIniPropRest));
         AssignAttri("", false, "AV12ClientAllowGetSessionIniPropRest", AV12ClientAllowGetSessionIniPropRest);
         AV10ClientAllowGetSessionAppDataREST = StringUtil.StrToBool( StringUtil.BoolToStr( AV10ClientAllowGetSessionAppDataREST));
         AssignAttri("", false, "AV10ClientAllowGetSessionAppDataREST", AV10ClientAllowGetSessionAppDataREST);
         AV8ClientAccessUniqueByUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV8ClientAccessUniqueByUser));
         AssignAttri("", false, "AV8ClientAccessUniqueByUser", AV8ClientAccessUniqueByUser);
         AV5AccessRequiresPermission = StringUtil.StrToBool( StringUtil.BoolToStr( AV5AccessRequiresPermission));
         AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
         AV143IsAuthorizationDelegated = StringUtil.StrToBool( StringUtil.BoolToStr( AV143IsAuthorizationDelegated));
         AssignAttri("", false, "AV143IsAuthorizationDelegated", AV143IsAuthorizationDelegated);
         if ( cmbavDelegateauthorizationversion.ItemCount > 0 )
         {
            AV134DelegateAuthorizationVersion = cmbavDelegateauthorizationversion.getValidValue(AV134DelegateAuthorizationVersion);
            AssignAttri("", false, "AV134DelegateAuthorizationVersion", AV134DelegateAuthorizationVersion);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDelegateauthorizationversion.CurrentValue = StringUtil.RTrim( AV134DelegateAuthorizationVersion);
            AssignProp("", false, cmbavDelegateauthorizationversion_Internalname, "Values", cmbavDelegateauthorizationversion.ToJavascriptSource(), true);
         }
         AV50SSORestEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV50SSORestEnable));
         AssignAttri("", false, "AV50SSORestEnable", AV50SSORestEnable);
         if ( cmbavSsorestmode.ItemCount > 0 )
         {
            AV51SSORestMode = cmbavSsorestmode.getValidValue(AV51SSORestMode);
            AssignAttri("", false, "AV51SSORestMode", AV51SSORestMode);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSsorestmode.CurrentValue = StringUtil.RTrim( AV51SSORestMode);
            AssignProp("", false, cmbavSsorestmode_Internalname, "Values", cmbavSsorestmode.ToJavascriptSource(), true);
         }
         AV159SSORestServerURL_isCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV159SSORestServerURL_isCustom));
         AssignAttri("", false, "AV159SSORestServerURL_isCustom", AV159SSORestServerURL_isCustom);
         AV57STSProtocolEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV57STSProtocolEnable));
         AssignAttri("", false, "AV57STSProtocolEnable", AV57STSProtocolEnable);
         if ( cmbavStsmode.ItemCount > 0 )
         {
            AV56STSMode = cmbavStsmode.getValidValue(AV56STSMode);
            AssignAttri("", false, "AV56STSMode", AV56STSMode);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavStsmode.CurrentValue = StringUtil.RTrim( AV56STSMode);
            AssignProp("", false, cmbavStsmode_Internalname, "Values", cmbavStsmode.ToJavascriptSource(), true);
         }
         AV148MiniAppEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV148MiniAppEnable));
         AssignAttri("", false, "AV148MiniAppEnable", AV148MiniAppEnable);
         if ( cmbavMiniappmode.ItemCount > 0 )
         {
            AV149MiniAppMode = cmbavMiniappmode.getValidValue(AV149MiniAppMode);
            AssignAttri("", false, "AV149MiniAppMode", AV149MiniAppMode);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMiniappmode.CurrentValue = StringUtil.RTrim( AV149MiniAppMode);
            AssignProp("", false, cmbavMiniappmode_Internalname, "Values", cmbavMiniappmode.ToJavascriptSource(), true);
         }
         AV147MiniAppClientURL_isCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV147MiniAppClientURL_isCustom));
         AssignAttri("", false, "AV147MiniAppClientURL_isCustom", AV147MiniAppClientURL_isCustom);
         if ( cmbavMiniappuserauthenticationtypename.ItemCount > 0 )
         {
            AV153MiniAppUserAuthenticationTypeName = cmbavMiniappuserauthenticationtypename.getValidValue(AV153MiniAppUserAuthenticationTypeName);
            AssignAttri("", false, "AV153MiniAppUserAuthenticationTypeName", AV153MiniAppUserAuthenticationTypeName);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMiniappuserauthenticationtypename.CurrentValue = StringUtil.RTrim( AV153MiniAppUserAuthenticationTypeName);
            AssignProp("", false, cmbavMiniappuserauthenticationtypename_Internalname, "Values", cmbavMiniappuserauthenticationtypename.ToJavascriptSource(), true);
         }
         AV152MiniAppServerURL_isCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV152MiniAppServerURL_isCustom));
         AssignAttri("", false, "AV152MiniAppServerURL_isCustom", AV152MiniAppServerURL_isCustom);
         AV120APIKeyEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV120APIKeyEnable));
         AssignAttri("", false, "AV120APIKeyEnable", AV120APIKeyEnable);
         if ( cmbavApikeyallowonlyauthenticationtypename.ItemCount > 0 )
         {
            AV118APIKeyAllowOnlyAuthenticationTypeName = cmbavApikeyallowonlyauthenticationtypename.getValidValue(AV118APIKeyAllowOnlyAuthenticationTypeName);
            AssignAttri("", false, "AV118APIKeyAllowOnlyAuthenticationTypeName", AV118APIKeyAllowOnlyAuthenticationTypeName);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavApikeyallowonlyauthenticationtypename.CurrentValue = StringUtil.RTrim( AV118APIKeyAllowOnlyAuthenticationTypeName);
            AssignProp("", false, cmbavApikeyallowonlyauthenticationtypename_Internalname, "Values", cmbavApikeyallowonlyauthenticationtypename.ToJavascriptSource(), true);
         }
         AV119APIKeyAllowScopeCustomization = StringUtil.StrToBool( StringUtil.BoolToStr( AV119APIKeyAllowScopeCustomization));
         AssignAttri("", false, "AV119APIKeyAllowScopeCustomization", AV119APIKeyAllowScopeCustomization);
         AV36EnvironmentSecureProtocol = StringUtil.StrToBool( StringUtil.BoolToStr( AV36EnvironmentSecureProtocol));
         AssignAttri("", false, "AV36EnvironmentSecureProtocol", AV36EnvironmentSecureProtocol);
         AV7AutoRegisterAnomymousUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV7AutoRegisterAnomymousUser));
         AssignAttri("", false, "AV7AutoRegisterAnomymousUser", AV7AutoRegisterAnomymousUser);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), true);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         edtavClientrevoked_Enabled = 0;
         AssignProp("", false, edtavClientrevoked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrevoked_Enabled), 5, 0), true);
         chkavOnline.Enabled = 0;
         edtavLanguage_Enabled = 0;
      }

      protected void RF0Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridlanguagesContainer.ClearRows();
         }
         wbStart = 567;
         /* Execute user event: Refresh */
         E250Y2 ();
         nGXsfl_567_idx = 1;
         sGXsfl_567_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_567_idx), 4, 0), 4, "0");
         SubsflControlProps_5672( ) ;
         bGXsfl_567_Refreshing = true;
         GridlanguagesContainer.AddObjectProperty("GridName", "Gridlanguages");
         GridlanguagesContainer.AddObjectProperty("CmpContext", "");
         GridlanguagesContainer.AddObjectProperty("InMasterPage", "false");
         GridlanguagesContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridlanguagesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridlanguagesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridlanguagesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Backcolorstyle), 1, 0, ".", "")));
         GridlanguagesContainer.PageSize = subGridlanguages_fnc_Recordsperpage( );
         if ( subGridlanguages_Islastpage != 0 )
         {
            GRIDLANGUAGES_nFirstRecordOnPage = (long)(subGridlanguages_fnc_Recordcount( )-subGridlanguages_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLANGUAGES_nFirstRecordOnPage), 15, 0, ".", "")));
            GridlanguagesContainer.AddObjectProperty("GRIDLANGUAGES_nFirstRecordOnPage", GRIDLANGUAGES_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_5672( ) ;
            /* Execute user event: Gridlanguages.Load */
            E260Y2 ();
            if ( ( subGridlanguages_Islastpage == 0 ) && ( GRIDLANGUAGES_nCurrentRecord > 0 ) && ( GRIDLANGUAGES_nGridOutOfScope == 0 ) && ( nGXsfl_567_idx == 1 ) )
            {
               GRIDLANGUAGES_nCurrentRecord = 0;
               GRIDLANGUAGES_nGridOutOfScope = 1;
               subgridlanguages_firstpage( ) ;
               /* Execute user event: Gridlanguages.Load */
               E260Y2 ();
            }
            wbEnd = 567;
            WB0Y0( ) ;
         }
         bGXsfl_567_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Y2( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE"+"_"+sGXsfl_567_idx, GetSecureSignedToken( sGXsfl_567_idx, StringUtil.RTrim( context.localUtil.Format( AV144Language, "")), context));
      }

      protected int subGridlanguages_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridlanguages_fnc_Recordcount( )
      {
         return (int)(((subGridlanguages_Recordcount==0) ? GRIDLANGUAGES_nFirstRecordOnPage+1 : subGridlanguages_Recordcount)) ;
      }

      protected int subGridlanguages_fnc_Recordsperpage( )
      {
         if ( subGridlanguages_Rows > 0 )
         {
            return subGridlanguages_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridlanguages_fnc_Currentpage( )
      {
         return (int)(((subGridlanguages_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGridlanguages_fnc_Recordcount( )/ (decimal)(subGridlanguages_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGridlanguages_fnc_Recordcount( )) % (subGridlanguages_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRIDLANGUAGES_nFirstRecordOnPage/ (decimal)(subGridlanguages_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgridlanguages_firstpage( )
      {
         GRIDLANGUAGES_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLANGUAGES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlanguages_refresh( subGridlanguages_Rows, Gx_mode, AV156ReturnMenuOptionsWithoutPermission, AV61UseAbsoluteUrlByEnvironment, AV128ClientAuthRequestMustIncludeUserScopes, AV129ClientDoNotShareUserIDs, AV17ClientAllowRemoteAuth, AV126ClientAllowGetUserData, AV13ClientAllowGetUserAddData, AV15ClientAllowGetUserRoles, AV11ClientAllowGetSessionIniProp, AV9ClientAllowGetSessionAppData, AV20ClientCallbackURLisCustom, AV18ClientAllowRemoteRestAuth, AV127ClientAllowGetUserDataREST, AV14ClientAllowGetUserAddDataRest, AV16ClientAllowGetUserRolesRest, AV12ClientAllowGetSessionIniPropRest, AV10ClientAllowGetSessionAppDataREST, AV8ClientAccessUniqueByUser, AV5AccessRequiresPermission, AV143IsAuthorizationDelegated, AV50SSORestEnable, AV159SSORestServerURL_isCustom, AV57STSProtocolEnable, AV148MiniAppEnable, AV147MiniAppClientURL_isCustom, AV152MiniAppServerURL_isCustom, AV120APIKeyEnable, AV119APIKeyAllowScopeCustomization, AV36EnvironmentSecureProtocol, AV7AutoRegisterAnomymousUser) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlanguages_nextpage( )
      {
         if ( GRIDLANGUAGES_nEOF == 0 )
         {
            GRIDLANGUAGES_nFirstRecordOnPage = (long)(GRIDLANGUAGES_nFirstRecordOnPage+subGridlanguages_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLANGUAGES_nFirstRecordOnPage), 15, 0, ".", "")));
         GridlanguagesContainer.AddObjectProperty("GRIDLANGUAGES_nFirstRecordOnPage", GRIDLANGUAGES_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlanguages_refresh( subGridlanguages_Rows, Gx_mode, AV156ReturnMenuOptionsWithoutPermission, AV61UseAbsoluteUrlByEnvironment, AV128ClientAuthRequestMustIncludeUserScopes, AV129ClientDoNotShareUserIDs, AV17ClientAllowRemoteAuth, AV126ClientAllowGetUserData, AV13ClientAllowGetUserAddData, AV15ClientAllowGetUserRoles, AV11ClientAllowGetSessionIniProp, AV9ClientAllowGetSessionAppData, AV20ClientCallbackURLisCustom, AV18ClientAllowRemoteRestAuth, AV127ClientAllowGetUserDataREST, AV14ClientAllowGetUserAddDataRest, AV16ClientAllowGetUserRolesRest, AV12ClientAllowGetSessionIniPropRest, AV10ClientAllowGetSessionAppDataREST, AV8ClientAccessUniqueByUser, AV5AccessRequiresPermission, AV143IsAuthorizationDelegated, AV50SSORestEnable, AV159SSORestServerURL_isCustom, AV57STSProtocolEnable, AV148MiniAppEnable, AV147MiniAppClientURL_isCustom, AV152MiniAppServerURL_isCustom, AV120APIKeyEnable, AV119APIKeyAllowScopeCustomization, AV36EnvironmentSecureProtocol, AV7AutoRegisterAnomymousUser) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDLANGUAGES_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridlanguages_previouspage( )
      {
         if ( GRIDLANGUAGES_nFirstRecordOnPage >= subGridlanguages_fnc_Recordsperpage( ) )
         {
            GRIDLANGUAGES_nFirstRecordOnPage = (long)(GRIDLANGUAGES_nFirstRecordOnPage-subGridlanguages_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLANGUAGES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlanguages_refresh( subGridlanguages_Rows, Gx_mode, AV156ReturnMenuOptionsWithoutPermission, AV61UseAbsoluteUrlByEnvironment, AV128ClientAuthRequestMustIncludeUserScopes, AV129ClientDoNotShareUserIDs, AV17ClientAllowRemoteAuth, AV126ClientAllowGetUserData, AV13ClientAllowGetUserAddData, AV15ClientAllowGetUserRoles, AV11ClientAllowGetSessionIniProp, AV9ClientAllowGetSessionAppData, AV20ClientCallbackURLisCustom, AV18ClientAllowRemoteRestAuth, AV127ClientAllowGetUserDataREST, AV14ClientAllowGetUserAddDataRest, AV16ClientAllowGetUserRolesRest, AV12ClientAllowGetSessionIniPropRest, AV10ClientAllowGetSessionAppDataREST, AV8ClientAccessUniqueByUser, AV5AccessRequiresPermission, AV143IsAuthorizationDelegated, AV50SSORestEnable, AV159SSORestServerURL_isCustom, AV57STSProtocolEnable, AV148MiniAppEnable, AV147MiniAppClientURL_isCustom, AV152MiniAppServerURL_isCustom, AV120APIKeyEnable, AV119APIKeyAllowScopeCustomization, AV36EnvironmentSecureProtocol, AV7AutoRegisterAnomymousUser) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlanguages_lastpage( )
      {
         subGridlanguages_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlanguages_refresh( subGridlanguages_Rows, Gx_mode, AV156ReturnMenuOptionsWithoutPermission, AV61UseAbsoluteUrlByEnvironment, AV128ClientAuthRequestMustIncludeUserScopes, AV129ClientDoNotShareUserIDs, AV17ClientAllowRemoteAuth, AV126ClientAllowGetUserData, AV13ClientAllowGetUserAddData, AV15ClientAllowGetUserRoles, AV11ClientAllowGetSessionIniProp, AV9ClientAllowGetSessionAppData, AV20ClientCallbackURLisCustom, AV18ClientAllowRemoteRestAuth, AV127ClientAllowGetUserDataREST, AV14ClientAllowGetUserAddDataRest, AV16ClientAllowGetUserRolesRest, AV12ClientAllowGetSessionIniPropRest, AV10ClientAllowGetSessionAppDataREST, AV8ClientAccessUniqueByUser, AV5AccessRequiresPermission, AV143IsAuthorizationDelegated, AV50SSORestEnable, AV159SSORestServerURL_isCustom, AV57STSProtocolEnable, AV148MiniAppEnable, AV147MiniAppClientURL_isCustom, AV152MiniAppServerURL_isCustom, AV120APIKeyEnable, AV119APIKeyAllowScopeCustomization, AV36EnvironmentSecureProtocol, AV7AutoRegisterAnomymousUser) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridlanguages_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDLANGUAGES_nFirstRecordOnPage = (long)(subGridlanguages_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDLANGUAGES_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLANGUAGES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlanguages_refresh( subGridlanguages_Rows, Gx_mode, AV156ReturnMenuOptionsWithoutPermission, AV61UseAbsoluteUrlByEnvironment, AV128ClientAuthRequestMustIncludeUserScopes, AV129ClientDoNotShareUserIDs, AV17ClientAllowRemoteAuth, AV126ClientAllowGetUserData, AV13ClientAllowGetUserAddData, AV15ClientAllowGetUserRoles, AV11ClientAllowGetSessionIniProp, AV9ClientAllowGetSessionAppData, AV20ClientCallbackURLisCustom, AV18ClientAllowRemoteRestAuth, AV127ClientAllowGetUserDataREST, AV14ClientAllowGetUserAddDataRest, AV16ClientAllowGetUserRolesRest, AV12ClientAllowGetSessionIniPropRest, AV10ClientAllowGetSessionAppDataREST, AV8ClientAccessUniqueByUser, AV5AccessRequiresPermission, AV143IsAuthorizationDelegated, AV50SSORestEnable, AV159SSORestServerURL_isCustom, AV57STSProtocolEnable, AV148MiniAppEnable, AV147MiniAppClientURL_isCustom, AV152MiniAppServerURL_isCustom, AV120APIKeyEnable, AV119APIKeyAllowScopeCustomization, AV36EnvironmentSecureProtocol, AV7AutoRegisterAnomymousUser) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), true);
         edtavGuid_Enabled = 0;
         AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
         edtavClientrevoked_Enabled = 0;
         AssignProp("", false, edtavClientrevoked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrevoked_Enabled), 5, 0), true);
         chkavOnline.Enabled = 0;
         edtavLanguage_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E240Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_567 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_567"), ".", ","), 18, MidpointRounding.ToEven));
            AV141GridLanguagesPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDLANGUAGESPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV139GridLanguagesAppliedFilters = cgiGet( "vGRIDLANGUAGESAPPLIEDFILTERS");
            Gx_mode = cgiGet( "vMODE");
            GRIDLANGUAGES_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLANGUAGES_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDLANGUAGES_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLANGUAGES_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGridlanguages_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGridlanguages_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            subGridlanguages_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLANGUAGES_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Rows), 6, 0, ".", "")));
            Dvpanel_unnamedtable6_Width = cgiGet( "DVPANEL_UNNAMEDTABLE6_Width");
            Dvpanel_unnamedtable6_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Autowidth"));
            Dvpanel_unnamedtable6_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Autoheight"));
            Dvpanel_unnamedtable6_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE6_Cls");
            Dvpanel_unnamedtable6_Title = cgiGet( "DVPANEL_UNNAMEDTABLE6_Title");
            Dvpanel_unnamedtable6_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Collapsible"));
            Dvpanel_unnamedtable6_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Collapsed"));
            Dvpanel_unnamedtable6_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Showcollapseicon"));
            Dvpanel_unnamedtable6_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE6_Iconposition");
            Dvpanel_unnamedtable6_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE6_Autoscroll"));
            Dvpanel_unnamedtable7_Width = cgiGet( "DVPANEL_UNNAMEDTABLE7_Width");
            Dvpanel_unnamedtable7_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE7_Autowidth"));
            Dvpanel_unnamedtable7_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE7_Autoheight"));
            Dvpanel_unnamedtable7_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE7_Cls");
            Dvpanel_unnamedtable7_Title = cgiGet( "DVPANEL_UNNAMEDTABLE7_Title");
            Dvpanel_unnamedtable7_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE7_Collapsible"));
            Dvpanel_unnamedtable7_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE7_Collapsed"));
            Dvpanel_unnamedtable7_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE7_Showcollapseicon"));
            Dvpanel_unnamedtable7_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE7_Iconposition");
            Dvpanel_unnamedtable7_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE7_Autoscroll"));
            Dvpanel_unnamedtable8_Width = cgiGet( "DVPANEL_UNNAMEDTABLE8_Width");
            Dvpanel_unnamedtable8_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE8_Autowidth"));
            Dvpanel_unnamedtable8_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE8_Autoheight"));
            Dvpanel_unnamedtable8_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE8_Cls");
            Dvpanel_unnamedtable8_Title = cgiGet( "DVPANEL_UNNAMEDTABLE8_Title");
            Dvpanel_unnamedtable8_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE8_Collapsible"));
            Dvpanel_unnamedtable8_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE8_Collapsed"));
            Dvpanel_unnamedtable8_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE8_Showcollapseicon"));
            Dvpanel_unnamedtable8_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE8_Iconposition");
            Dvpanel_unnamedtable8_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE8_Autoscroll"));
            Gridlanguagespaginationbar_Class = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Class");
            Gridlanguagespaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Showfirst"));
            Gridlanguagespaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Showprevious"));
            Gridlanguagespaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Shownext"));
            Gridlanguagespaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Showlast"));
            Gridlanguagespaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Pagestoshow"), ".", ","), 18, MidpointRounding.ToEven));
            Gridlanguagespaginationbar_Pagingbuttonsposition = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Pagingbuttonsposition");
            Gridlanguagespaginationbar_Pagingcaptionposition = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Pagingcaptionposition");
            Gridlanguagespaginationbar_Emptygridclass = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Emptygridclass");
            Gridlanguagespaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Rowsperpageselector"));
            Gridlanguagespaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Gridlanguagespaginationbar_Rowsperpageoptions = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Rowsperpageoptions");
            Gridlanguagespaginationbar_Previous = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Previous");
            Gridlanguagespaginationbar_Next = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Next");
            Gridlanguagespaginationbar_Caption = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Caption");
            Gridlanguagespaginationbar_Emptygridcaption = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Emptygridcaption");
            Gridlanguagespaginationbar_Rowsperpagecaption = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Rowsperpagecaption");
            Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), ".", ","), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
            Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
            Gridlanguages_empowerer_Gridinternalname = cgiGet( "GRIDLANGUAGES_EMPOWERER_Gridinternalname");
            Gridlanguagespaginationbar_Selectedpage = cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Selectedpage");
            Gridlanguagespaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLANGUAGESPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV43Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV43Id", StringUtil.LTrimStr( (decimal)(AV43Id), 12, 0));
            AV41GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV41GUID", AV41GUID);
            AV49Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV49Name", AV49Name);
            AV30Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri("", false, "AV30Dsc", AV30Dsc);
            AV64Version = cgiGet( edtavVersion_Internalname);
            AssignAttri("", false, "AV64Version", AV64Version);
            AV28Company = cgiGet( edtavCompany_Internalname);
            AssignAttri("", false, "AV28Company", AV28Company);
            AV29Copyright = cgiGet( edtavCopyright_Internalname);
            AssignAttri("", false, "AV29Copyright", AV29Copyright);
            AV156ReturnMenuOptionsWithoutPermission = StringUtil.StrToBool( cgiGet( chkavReturnmenuoptionswithoutpermission_Internalname));
            AssignAttri("", false, "AV156ReturnMenuOptionsWithoutPermission", AV156ReturnMenuOptionsWithoutPermission);
            cmbavMainmenu.Name = cmbavMainmenu_Internalname;
            cmbavMainmenu.CurrentValue = cgiGet( cmbavMainmenu_Internalname);
            AV46MainMenu = (long)(Math.Round(NumberUtil.Val( cgiGet( cmbavMainmenu_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV46MainMenu", StringUtil.LTrimStr( (decimal)(AV46MainMenu), 12, 0));
            AV61UseAbsoluteUrlByEnvironment = StringUtil.StrToBool( cgiGet( chkavUseabsoluteurlbyenvironment_Internalname));
            AssignAttri("", false, "AV61UseAbsoluteUrlByEnvironment", AV61UseAbsoluteUrlByEnvironment);
            AV42HomeObject = cgiGet( edtavHomeobject_Internalname);
            AssignAttri("", false, "AV42HomeObject", AV42HomeObject);
            AV66AccountActivationObject = cgiGet( edtavAccountactivationobject_Internalname);
            AssignAttri("", false, "AV66AccountActivationObject", AV66AccountActivationObject);
            AV45LogoutObject = cgiGet( edtavLogoutobject_Internalname);
            AssignAttri("", false, "AV45LogoutObject", AV45LogoutObject);
            cmbavClientaccessstatus.Name = cmbavClientaccessstatus_Internalname;
            cmbavClientaccessstatus.CurrentValue = cgiGet( cmbavClientaccessstatus_Internalname);
            AV123ClientAccessStatus = cgiGet( cmbavClientaccessstatus_Internalname);
            AssignAttri("", false, "AV123ClientAccessStatus", AV123ClientAccessStatus);
            if ( context.localUtil.VCDateTime( cgiGet( edtavClientrevoked_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Client Revoked"}), 1, "vCLIENTREVOKED");
               GX_FocusControl = edtavClientrevoked_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26ClientRevoked = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV26ClientRevoked", context.localUtil.TToC( AV26ClientRevoked, 10, 5, 1, 3, "/", ":", " "));
            }
            else
            {
               AV26ClientRevoked = context.localUtil.CToT( cgiGet( edtavClientrevoked_Internalname));
               AssignAttri("", false, "AV26ClientRevoked", context.localUtil.TToC( AV26ClientRevoked, 10, 5, 1, 3, "/", ":", " "));
            }
            AV22ClientId = cgiGet( edtavClientid_Internalname);
            AssignAttri("", false, "AV22ClientId", AV22ClientId);
            AV27ClientSecret = cgiGet( edtavClientsecret_Internalname);
            AssignAttri("", false, "AV27ClientSecret", AV27ClientSecret);
            AV128ClientAuthRequestMustIncludeUserScopes = StringUtil.StrToBool( cgiGet( chkavClientauthrequestmustincludeuserscopes_Internalname));
            AssignAttri("", false, "AV128ClientAuthRequestMustIncludeUserScopes", AV128ClientAuthRequestMustIncludeUserScopes);
            AV129ClientDoNotShareUserIDs = StringUtil.StrToBool( cgiGet( chkavClientdonotshareuserids_Internalname));
            AssignAttri("", false, "AV129ClientDoNotShareUserIDs", AV129ClientDoNotShareUserIDs);
            AV17ClientAllowRemoteAuth = StringUtil.StrToBool( cgiGet( chkavClientallowremoteauth_Internalname));
            AssignAttri("", false, "AV17ClientAllowRemoteAuth", AV17ClientAllowRemoteAuth);
            AV126ClientAllowGetUserData = StringUtil.StrToBool( cgiGet( chkavClientallowgetuserdata_Internalname));
            AssignAttri("", false, "AV126ClientAllowGetUserData", AV126ClientAllowGetUserData);
            AV13ClientAllowGetUserAddData = StringUtil.StrToBool( cgiGet( chkavClientallowgetuseradddata_Internalname));
            AssignAttri("", false, "AV13ClientAllowGetUserAddData", AV13ClientAllowGetUserAddData);
            AV15ClientAllowGetUserRoles = StringUtil.StrToBool( cgiGet( chkavClientallowgetuserroles_Internalname));
            AssignAttri("", false, "AV15ClientAllowGetUserRoles", AV15ClientAllowGetUserRoles);
            AV11ClientAllowGetSessionIniProp = StringUtil.StrToBool( cgiGet( chkavClientallowgetsessioniniprop_Internalname));
            AssignAttri("", false, "AV11ClientAllowGetSessionIniProp", AV11ClientAllowGetSessionIniProp);
            AV9ClientAllowGetSessionAppData = StringUtil.StrToBool( cgiGet( chkavClientallowgetsessionappdata_Internalname));
            AssignAttri("", false, "AV9ClientAllowGetSessionAppData", AV9ClientAllowGetSessionAppData);
            AV124ClientAllowAdditionalScope = cgiGet( edtavClientallowadditionalscope_Internalname);
            AssignAttri("", false, "AV124ClientAllowAdditionalScope", AV124ClientAllowAdditionalScope);
            AV23ClientImageURL = cgiGet( edtavClientimageurl_Internalname);
            AssignAttri("", false, "AV23ClientImageURL", AV23ClientImageURL);
            AV24ClientLocalLoginURL = cgiGet( edtavClientlocalloginurl_Internalname);
            AssignAttri("", false, "AV24ClientLocalLoginURL", AV24ClientLocalLoginURL);
            AV19ClientCallbackURL = cgiGet( edtavClientcallbackurl_Internalname);
            AssignAttri("", false, "AV19ClientCallbackURL", AV19ClientCallbackURL);
            AV20ClientCallbackURLisCustom = StringUtil.StrToBool( cgiGet( chkavClientcallbackurliscustom_Internalname));
            AssignAttri("", false, "AV20ClientCallbackURLisCustom", AV20ClientCallbackURLisCustom);
            AV65ClientCallbackURLStateName = cgiGet( edtavClientcallbackurlstatename_Internalname);
            AssignAttri("", false, "AV65ClientCallbackURLStateName", AV65ClientCallbackURLStateName);
            AV18ClientAllowRemoteRestAuth = StringUtil.StrToBool( cgiGet( chkavClientallowremoterestauth_Internalname));
            AssignAttri("", false, "AV18ClientAllowRemoteRestAuth", AV18ClientAllowRemoteRestAuth);
            AV127ClientAllowGetUserDataREST = StringUtil.StrToBool( cgiGet( chkavClientallowgetuserdatarest_Internalname));
            AssignAttri("", false, "AV127ClientAllowGetUserDataREST", AV127ClientAllowGetUserDataREST);
            AV14ClientAllowGetUserAddDataRest = StringUtil.StrToBool( cgiGet( chkavClientallowgetuseradddatarest_Internalname));
            AssignAttri("", false, "AV14ClientAllowGetUserAddDataRest", AV14ClientAllowGetUserAddDataRest);
            AV16ClientAllowGetUserRolesRest = StringUtil.StrToBool( cgiGet( chkavClientallowgetuserrolesrest_Internalname));
            AssignAttri("", false, "AV16ClientAllowGetUserRolesRest", AV16ClientAllowGetUserRolesRest);
            AV12ClientAllowGetSessionIniPropRest = StringUtil.StrToBool( cgiGet( chkavClientallowgetsessioniniproprest_Internalname));
            AssignAttri("", false, "AV12ClientAllowGetSessionIniPropRest", AV12ClientAllowGetSessionIniPropRest);
            AV10ClientAllowGetSessionAppDataREST = StringUtil.StrToBool( cgiGet( chkavClientallowgetsessionappdatarest_Internalname));
            AssignAttri("", false, "AV10ClientAllowGetSessionAppDataREST", AV10ClientAllowGetSessionAppDataREST);
            AV125ClientAllowAdditionalScopeREST = cgiGet( edtavClientallowadditionalscoperest_Internalname);
            AssignAttri("", false, "AV125ClientAllowAdditionalScopeREST", AV125ClientAllowAdditionalScopeREST);
            AV8ClientAccessUniqueByUser = StringUtil.StrToBool( cgiGet( chkavClientaccessuniquebyuser_Internalname));
            AssignAttri("", false, "AV8ClientAccessUniqueByUser", AV8ClientAccessUniqueByUser);
            AV21ClientEncryptionKey = cgiGet( edtavClientencryptionkey_Internalname);
            AssignAttri("", false, "AV21ClientEncryptionKey", AV21ClientEncryptionKey);
            AV25ClientRepositoryGUID = cgiGet( edtavClientrepositoryguid_Internalname);
            AssignAttri("", false, "AV25ClientRepositoryGUID", AV25ClientRepositoryGUID);
            AV5AccessRequiresPermission = StringUtil.StrToBool( cgiGet( chkavAccessrequirespermission_Internalname));
            AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
            AV143IsAuthorizationDelegated = StringUtil.StrToBool( cgiGet( chkavIsauthorizationdelegated_Internalname));
            AssignAttri("", false, "AV143IsAuthorizationDelegated", AV143IsAuthorizationDelegated);
            cmbavDelegateauthorizationversion.Name = cmbavDelegateauthorizationversion_Internalname;
            cmbavDelegateauthorizationversion.CurrentValue = cgiGet( cmbavDelegateauthorizationversion_Internalname);
            AV134DelegateAuthorizationVersion = cgiGet( cmbavDelegateauthorizationversion_Internalname);
            AssignAttri("", false, "AV134DelegateAuthorizationVersion", AV134DelegateAuthorizationVersion);
            AV131DelegateAuthorizationFileName = cgiGet( edtavDelegateauthorizationfilename_Internalname);
            AssignAttri("", false, "AV131DelegateAuthorizationFileName", AV131DelegateAuthorizationFileName);
            AV133DelegateAuthorizationPackage = cgiGet( edtavDelegateauthorizationpackage_Internalname);
            AssignAttri("", false, "AV133DelegateAuthorizationPackage", AV133DelegateAuthorizationPackage);
            AV130DelegateAuthorizationClassName = cgiGet( edtavDelegateauthorizationclassname_Internalname);
            AssignAttri("", false, "AV130DelegateAuthorizationClassName", AV130DelegateAuthorizationClassName);
            AV132DelegateAuthorizationMethod = cgiGet( edtavDelegateauthorizationmethod_Internalname);
            AssignAttri("", false, "AV132DelegateAuthorizationMethod", AV132DelegateAuthorizationMethod);
            AV50SSORestEnable = StringUtil.StrToBool( cgiGet( chkavSsorestenable_Internalname));
            AssignAttri("", false, "AV50SSORestEnable", AV50SSORestEnable);
            cmbavSsorestmode.Name = cmbavSsorestmode_Internalname;
            cmbavSsorestmode.CurrentValue = cgiGet( cmbavSsorestmode_Internalname);
            AV51SSORestMode = cgiGet( cmbavSsorestmode_Internalname);
            AssignAttri("", false, "AV51SSORestMode", AV51SSORestMode);
            AV53SSORestUserAuthTypeName = cgiGet( edtavSsorestuserauthtypename_Internalname);
            AssignAttri("", false, "AV53SSORestUserAuthTypeName", AV53SSORestUserAuthTypeName);
            AV52SSORestServerURL = cgiGet( edtavSsorestserverurl_Internalname);
            AssignAttri("", false, "AV52SSORestServerURL", AV52SSORestServerURL);
            AV159SSORestServerURL_isCustom = StringUtil.StrToBool( cgiGet( chkavSsorestserverurl_iscustom_Internalname));
            AssignAttri("", false, "AV159SSORestServerURL_isCustom", AV159SSORestServerURL_isCustom);
            AV160SSORestServerURL_SLO = cgiGet( edtavSsorestserverurl_slo_Internalname);
            AssignAttri("", false, "AV160SSORestServerURL_SLO", AV160SSORestServerURL_SLO);
            AV158SSORestServerRepositoryGUID = cgiGet( edtavSsorestserverrepositoryguid_Internalname);
            AssignAttri("", false, "AV158SSORestServerRepositoryGUID", AV158SSORestServerRepositoryGUID);
            AV157SSORestServerKey = cgiGet( edtavSsorestserverkey_Internalname);
            AssignAttri("", false, "AV157SSORestServerKey", AV157SSORestServerKey);
            AV57STSProtocolEnable = StringUtil.StrToBool( cgiGet( chkavStsprotocolenable_Internalname));
            AssignAttri("", false, "AV57STSProtocolEnable", AV57STSProtocolEnable);
            cmbavStsmode.Name = cmbavStsmode_Internalname;
            cmbavStsmode.CurrentValue = cgiGet( cmbavStsmode_Internalname);
            AV56STSMode = cgiGet( cmbavStsmode_Internalname);
            AssignAttri("", false, "AV56STSMode", AV56STSMode);
            AV55STSAuthorizationUserName = cgiGet( edtavStsauthorizationusername_Internalname);
            AssignAttri("", false, "AV55STSAuthorizationUserName", AV55STSAuthorizationUserName);
            AV58STSServerClientPassword = cgiGet( edtavStsserverclientpassword_Internalname);
            AssignAttri("", false, "AV58STSServerClientPassword", AV58STSServerClientPassword);
            AV60STSServerURL = cgiGet( edtavStsserverurl_Internalname);
            AssignAttri("", false, "AV60STSServerURL", AV60STSServerURL);
            AV59STSServerRepositoryGUID = cgiGet( edtavStsserverrepositoryguid_Internalname);
            AssignAttri("", false, "AV59STSServerRepositoryGUID", AV59STSServerRepositoryGUID);
            AV148MiniAppEnable = StringUtil.StrToBool( cgiGet( chkavMiniappenable_Internalname));
            AssignAttri("", false, "AV148MiniAppEnable", AV148MiniAppEnable);
            cmbavMiniappmode.Name = cmbavMiniappmode_Internalname;
            cmbavMiniappmode.CurrentValue = cgiGet( cmbavMiniappmode_Internalname);
            AV149MiniAppMode = cgiGet( cmbavMiniappmode_Internalname);
            AssignAttri("", false, "AV149MiniAppMode", AV149MiniAppMode);
            AV146MiniAppClientURL = cgiGet( edtavMiniappclienturl_Internalname);
            AssignAttri("", false, "AV146MiniAppClientURL", AV146MiniAppClientURL);
            AV147MiniAppClientURL_isCustom = StringUtil.StrToBool( cgiGet( chkavMiniappclienturl_iscustom_Internalname));
            AssignAttri("", false, "AV147MiniAppClientURL_isCustom", AV147MiniAppClientURL_isCustom);
            AV145MiniAppClientRepositoryGUID = cgiGet( edtavMiniappclientrepositoryguid_Internalname);
            AssignAttri("", false, "AV145MiniAppClientRepositoryGUID", AV145MiniAppClientRepositoryGUID);
            cmbavMiniappuserauthenticationtypename.Name = cmbavMiniappuserauthenticationtypename_Internalname;
            cmbavMiniappuserauthenticationtypename.CurrentValue = cgiGet( cmbavMiniappuserauthenticationtypename_Internalname);
            AV153MiniAppUserAuthenticationTypeName = cgiGet( cmbavMiniappuserauthenticationtypename_Internalname);
            AssignAttri("", false, "AV153MiniAppUserAuthenticationTypeName", AV153MiniAppUserAuthenticationTypeName);
            AV151MiniAppServerURL = cgiGet( edtavMiniappserverurl_Internalname);
            AssignAttri("", false, "AV151MiniAppServerURL", AV151MiniAppServerURL);
            AV152MiniAppServerURL_isCustom = StringUtil.StrToBool( cgiGet( chkavMiniappserverurl_iscustom_Internalname));
            AssignAttri("", false, "AV152MiniAppServerURL_isCustom", AV152MiniAppServerURL_isCustom);
            AV150MiniAppServerRepositoryGUID = cgiGet( edtavMiniappserverrepositoryguid_Internalname);
            AssignAttri("", false, "AV150MiniAppServerRepositoryGUID", AV150MiniAppServerRepositoryGUID);
            AV120APIKeyEnable = StringUtil.StrToBool( cgiGet( chkavApikeyenable_Internalname));
            AssignAttri("", false, "AV120APIKeyEnable", AV120APIKeyEnable);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavApikeytimeout_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavApikeytimeout_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAPIKEYTIMEOUT");
               GX_FocusControl = edtavApikeytimeout_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV121APIKeyTimeout = 0;
               AssignAttri("", false, "AV121APIKeyTimeout", StringUtil.LTrimStr( (decimal)(AV121APIKeyTimeout), 9, 0));
            }
            else
            {
               AV121APIKeyTimeout = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavApikeytimeout_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV121APIKeyTimeout", StringUtil.LTrimStr( (decimal)(AV121APIKeyTimeout), 9, 0));
            }
            cmbavApikeyallowonlyauthenticationtypename.Name = cmbavApikeyallowonlyauthenticationtypename_Internalname;
            cmbavApikeyallowonlyauthenticationtypename.CurrentValue = cgiGet( cmbavApikeyallowonlyauthenticationtypename_Internalname);
            AV118APIKeyAllowOnlyAuthenticationTypeName = cgiGet( cmbavApikeyallowonlyauthenticationtypename_Internalname);
            AssignAttri("", false, "AV118APIKeyAllowOnlyAuthenticationTypeName", AV118APIKeyAllowOnlyAuthenticationTypeName);
            AV119APIKeyAllowScopeCustomization = StringUtil.StrToBool( cgiGet( chkavApikeyallowscopecustomization_Internalname));
            AssignAttri("", false, "AV119APIKeyAllowScopeCustomization", AV119APIKeyAllowScopeCustomization);
            AV32EnvironmentName = cgiGet( edtavEnvironmentname_Internalname);
            AssignAttri("", false, "AV32EnvironmentName", AV32EnvironmentName);
            AV36EnvironmentSecureProtocol = StringUtil.StrToBool( cgiGet( chkavEnvironmentsecureprotocol_Internalname));
            AssignAttri("", false, "AV36EnvironmentSecureProtocol", AV36EnvironmentSecureProtocol);
            AV31EnvironmentHost = cgiGet( edtavEnvironmenthost_Internalname);
            AssignAttri("", false, "AV31EnvironmentHost", AV31EnvironmentHost);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEnvironmentport_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEnvironmentport_Internalname), ".", ",") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vENVIRONMENTPORT");
               GX_FocusControl = edtavEnvironmentport_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33EnvironmentPort = 0;
               AssignAttri("", false, "AV33EnvironmentPort", StringUtil.LTrimStr( (decimal)(AV33EnvironmentPort), 5, 0));
            }
            else
            {
               AV33EnvironmentPort = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavEnvironmentport_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV33EnvironmentPort", StringUtil.LTrimStr( (decimal)(AV33EnvironmentPort), 5, 0));
            }
            AV37EnvironmentVirtualDirectory = cgiGet( edtavEnvironmentvirtualdirectory_Internalname);
            AssignAttri("", false, "AV37EnvironmentVirtualDirectory", AV37EnvironmentVirtualDirectory);
            AV35EnvironmentProgramPackage = cgiGet( edtavEnvironmentprogrampackage_Internalname);
            AssignAttri("", false, "AV35EnvironmentProgramPackage", AV35EnvironmentProgramPackage);
            AV34EnvironmentProgramExtension = cgiGet( edtavEnvironmentprogramextension_Internalname);
            AssignAttri("", false, "AV34EnvironmentProgramExtension", AV34EnvironmentProgramExtension);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGridlanguagescurrentpage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGridlanguagescurrentpage_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRIDLANGUAGESCURRENTPAGE");
               GX_FocusControl = edtavGridlanguagescurrentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV140GridLanguagesCurrentPage = 0;
               AssignAttri("", false, "AV140GridLanguagesCurrentPage", StringUtil.LTrimStr( (decimal)(AV140GridLanguagesCurrentPage), 10, 0));
            }
            else
            {
               AV140GridLanguagesCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGridlanguagescurrentpage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV140GridLanguagesCurrentPage", StringUtil.LTrimStr( (decimal)(AV140GridLanguagesCurrentPage), 10, 0));
            }
            AV7AutoRegisterAnomymousUser = StringUtil.StrToBool( cgiGet( chkavAutoregisteranomymoususer_Internalname));
            AssignAttri("", false, "AV7AutoRegisterAnomymousUser", AV7AutoRegisterAnomymousUser);
            AV54STSAuthorizationUserGUID = cgiGet( edtavStsauthorizationuserguid_Internalname);
            AssignAttri("", false, "AV54STSAuthorizationUserGUID", AV54STSAuthorizationUserGUID);
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
         E240Y2 ();
         if (returnInSub) return;
      }

      protected void E240Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavStsauthorizationuserguid_Visible = 0;
         AssignProp("", false, edtavStsauthorizationuserguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStsauthorizationuserguid_Visible), 5, 0), true);
         chkavOnline.Enabled = (((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? false : true) ? 1 : 0);
         AssignProp("", false, chkavOnline_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOnline.Enabled), 5, 0), !bGXsfl_567_Refreshing);
         cmbavMainmenu.addItem("0", "none", 0);
         bttBtnchangeclientsecret_Visible = 0;
         AssignProp("", false, bttBtnchangeclientsecret_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnchangeclientsecret_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               bttBtnchangeclientsecret_Visible = 1;
               AssignProp("", false, bttBtnchangeclientsecret_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnchangeclientsecret_Visible), 5, 0), true);
            }
            edtavClientsecret_Enabled = 0;
            AssignProp("", false, edtavClientsecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientsecret_Enabled), 5, 0), true);
            AV135GAMApplication.load( AV43Id);
            AV43Id = AV135GAMApplication.gxTpr_Id;
            AssignAttri("", false, "AV43Id", StringUtil.LTrimStr( (decimal)(AV43Id), 12, 0));
            AV41GUID = AV135GAMApplication.gxTpr_Guid;
            AssignAttri("", false, "AV41GUID", AV41GUID);
            AV49Name = AV135GAMApplication.gxTpr_Name;
            AssignAttri("", false, "AV49Name", AV49Name);
            AV30Dsc = AV135GAMApplication.gxTpr_Description;
            AssignAttri("", false, "AV30Dsc", AV30Dsc);
            AV64Version = AV135GAMApplication.gxTpr_Version;
            AssignAttri("", false, "AV64Version", AV64Version);
            AV29Copyright = AV135GAMApplication.gxTpr_Copyright;
            AssignAttri("", false, "AV29Copyright", AV29Copyright);
            AV28Company = AV135GAMApplication.gxTpr_Companyname;
            AssignAttri("", false, "AV28Company", AV28Company);
            AV156ReturnMenuOptionsWithoutPermission = AV135GAMApplication.gxTpr_Returnmenuoptionswithoutpermission;
            AssignAttri("", false, "AV156ReturnMenuOptionsWithoutPermission", AV156ReturnMenuOptionsWithoutPermission);
            AV46MainMenu = AV135GAMApplication.gxTpr_Mainmenuid;
            AssignAttri("", false, "AV46MainMenu", StringUtil.LTrimStr( (decimal)(AV46MainMenu), 12, 0));
            AV61UseAbsoluteUrlByEnvironment = AV135GAMApplication.gxTpr_Useabsoluteurlbyenvironment;
            AssignAttri("", false, "AV61UseAbsoluteUrlByEnvironment", AV61UseAbsoluteUrlByEnvironment);
            AV42HomeObject = AV135GAMApplication.gxTpr_Homeobject;
            AssignAttri("", false, "AV42HomeObject", AV42HomeObject);
            AV66AccountActivationObject = AV135GAMApplication.gxTpr_Accountactivationobject;
            AssignAttri("", false, "AV66AccountActivationObject", AV66AccountActivationObject);
            AV45LogoutObject = AV135GAMApplication.gxTpr_Logoutobject;
            AssignAttri("", false, "AV45LogoutObject", AV45LogoutObject);
            /* Execute user subroutine: 'SHOWAPPLICATIONSTATUS' */
            S112 ();
            if (returnInSub) return;
            AV22ClientId = AV135GAMApplication.gxTpr_Clientid;
            AssignAttri("", false, "AV22ClientId", AV22ClientId);
            AV27ClientSecret = AV135GAMApplication.gxTpr_Clientsecret;
            AssignAttri("", false, "AV27ClientSecret", AV27ClientSecret);
            AV128ClientAuthRequestMustIncludeUserScopes = AV135GAMApplication.gxTpr_Clientauthenticationrequestmustincludeuserscopes;
            AssignAttri("", false, "AV128ClientAuthRequestMustIncludeUserScopes", AV128ClientAuthRequestMustIncludeUserScopes);
            AV129ClientDoNotShareUserIDs = AV135GAMApplication.gxTpr_Clientdonotshareuserids;
            AssignAttri("", false, "AV129ClientDoNotShareUserIDs", AV129ClientDoNotShareUserIDs);
            AV17ClientAllowRemoteAuth = AV135GAMApplication.gxTpr_Clientallowremoteauthentication;
            AssignAttri("", false, "AV17ClientAllowRemoteAuth", AV17ClientAllowRemoteAuth);
            AV126ClientAllowGetUserData = AV135GAMApplication.gxTpr_Clientallowgetuserdata;
            AssignAttri("", false, "AV126ClientAllowGetUserData", AV126ClientAllowGetUserData);
            AV13ClientAllowGetUserAddData = AV135GAMApplication.gxTpr_Clientallowgetuseradditionaldata;
            AssignAttri("", false, "AV13ClientAllowGetUserAddData", AV13ClientAllowGetUserAddData);
            AV15ClientAllowGetUserRoles = AV135GAMApplication.gxTpr_Clientallowgetuserroles;
            AssignAttri("", false, "AV15ClientAllowGetUserRoles", AV15ClientAllowGetUserRoles);
            AV11ClientAllowGetSessionIniProp = AV135GAMApplication.gxTpr_Clientallowgetsessioninitialproperties;
            AssignAttri("", false, "AV11ClientAllowGetSessionIniProp", AV11ClientAllowGetSessionIniProp);
            AV9ClientAllowGetSessionAppData = AV135GAMApplication.gxTpr_Clientallowgetsessionapplicationdata;
            AssignAttri("", false, "AV9ClientAllowGetSessionAppData", AV9ClientAllowGetSessionAppData);
            AV124ClientAllowAdditionalScope = AV135GAMApplication.gxTpr_Clientallowadditionalscope;
            AssignAttri("", false, "AV124ClientAllowAdditionalScope", AV124ClientAllowAdditionalScope);
            AV23ClientImageURL = AV135GAMApplication.gxTpr_Clientimageurl;
            AssignAttri("", false, "AV23ClientImageURL", AV23ClientImageURL);
            AV24ClientLocalLoginURL = AV135GAMApplication.gxTpr_Clientlocalloginurl;
            AssignAttri("", false, "AV24ClientLocalLoginURL", AV24ClientLocalLoginURL);
            AV19ClientCallbackURL = AV135GAMApplication.gxTpr_Clientcallbackurl;
            AssignAttri("", false, "AV19ClientCallbackURL", AV19ClientCallbackURL);
            AV20ClientCallbackURLisCustom = AV135GAMApplication.gxTpr_Clientcallbackurliscustom;
            AssignAttri("", false, "AV20ClientCallbackURLisCustom", AV20ClientCallbackURLisCustom);
            AV65ClientCallbackURLStateName = AV135GAMApplication.gxTpr_Clientcallbackurlstatename;
            AssignAttri("", false, "AV65ClientCallbackURLStateName", AV65ClientCallbackURLStateName);
            AV18ClientAllowRemoteRestAuth = AV135GAMApplication.gxTpr_Clientallowremoterestauthentication;
            AssignAttri("", false, "AV18ClientAllowRemoteRestAuth", AV18ClientAllowRemoteRestAuth);
            AV127ClientAllowGetUserDataREST = AV135GAMApplication.gxTpr_Clientallowgetuserdatarest;
            AssignAttri("", false, "AV127ClientAllowGetUserDataREST", AV127ClientAllowGetUserDataREST);
            AV14ClientAllowGetUserAddDataRest = AV135GAMApplication.gxTpr_Clientallowgetuseradditionaldatarest;
            AssignAttri("", false, "AV14ClientAllowGetUserAddDataRest", AV14ClientAllowGetUserAddDataRest);
            AV16ClientAllowGetUserRolesRest = AV135GAMApplication.gxTpr_Clientallowgetuserrolesrest;
            AssignAttri("", false, "AV16ClientAllowGetUserRolesRest", AV16ClientAllowGetUserRolesRest);
            AV12ClientAllowGetSessionIniPropRest = AV135GAMApplication.gxTpr_Clientallowgetsessioninitialpropertiesrest;
            AssignAttri("", false, "AV12ClientAllowGetSessionIniPropRest", AV12ClientAllowGetSessionIniPropRest);
            AV10ClientAllowGetSessionAppDataREST = AV135GAMApplication.gxTpr_Clientallowgetsessionapplicationdatarest;
            AssignAttri("", false, "AV10ClientAllowGetSessionAppDataREST", AV10ClientAllowGetSessionAppDataREST);
            AV125ClientAllowAdditionalScopeREST = AV135GAMApplication.gxTpr_Clientallowadditionalscoperest;
            AssignAttri("", false, "AV125ClientAllowAdditionalScopeREST", AV125ClientAllowAdditionalScopeREST);
            AV8ClientAccessUniqueByUser = AV135GAMApplication.gxTpr_Clientaccessuniquebyuser;
            AssignAttri("", false, "AV8ClientAccessUniqueByUser", AV8ClientAccessUniqueByUser);
            AV21ClientEncryptionKey = AV135GAMApplication.gxTpr_Clientencryptionkey;
            AssignAttri("", false, "AV21ClientEncryptionKey", AV21ClientEncryptionKey);
            AV25ClientRepositoryGUID = AV135GAMApplication.gxTpr_Clientrepositoryguid;
            AssignAttri("", false, "AV25ClientRepositoryGUID", AV25ClientRepositoryGUID);
            AV5AccessRequiresPermission = AV135GAMApplication.gxTpr_Accessrequirespermission;
            AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
            AV143IsAuthorizationDelegated = AV135GAMApplication.gxTpr_Isauthorizationdelegated;
            AssignAttri("", false, "AV143IsAuthorizationDelegated", AV143IsAuthorizationDelegated);
            AV134DelegateAuthorizationVersion = AV135GAMApplication.gxTpr_Delegateauthorization.gxTpr_Version;
            AssignAttri("", false, "AV134DelegateAuthorizationVersion", AV134DelegateAuthorizationVersion);
            AV131DelegateAuthorizationFileName = AV135GAMApplication.gxTpr_Delegateauthorization.gxTpr_Filename;
            AssignAttri("", false, "AV131DelegateAuthorizationFileName", AV131DelegateAuthorizationFileName);
            AV133DelegateAuthorizationPackage = AV135GAMApplication.gxTpr_Delegateauthorization.gxTpr_Package;
            AssignAttri("", false, "AV133DelegateAuthorizationPackage", AV133DelegateAuthorizationPackage);
            AV130DelegateAuthorizationClassName = AV135GAMApplication.gxTpr_Delegateauthorization.gxTpr_Classname;
            AssignAttri("", false, "AV130DelegateAuthorizationClassName", AV130DelegateAuthorizationClassName);
            AV132DelegateAuthorizationMethod = AV135GAMApplication.gxTpr_Delegateauthorization.gxTpr_Method;
            AssignAttri("", false, "AV132DelegateAuthorizationMethod", AV132DelegateAuthorizationMethod);
            AV50SSORestEnable = AV135GAMApplication.gxTpr_Ssorestenable;
            AssignAttri("", false, "AV50SSORestEnable", AV50SSORestEnable);
            AV51SSORestMode = AV135GAMApplication.gxTpr_Ssorestmode;
            AssignAttri("", false, "AV51SSORestMode", AV51SSORestMode);
            AV53SSORestUserAuthTypeName = AV135GAMApplication.gxTpr_Ssorestuserauthenticationtypename;
            AssignAttri("", false, "AV53SSORestUserAuthTypeName", AV53SSORestUserAuthTypeName);
            AV52SSORestServerURL = AV135GAMApplication.gxTpr_Ssorestserverurl;
            AssignAttri("", false, "AV52SSORestServerURL", AV52SSORestServerURL);
            AV159SSORestServerURL_isCustom = AV135GAMApplication.gxTpr_Ssorestserverurl_iscustom;
            AssignAttri("", false, "AV159SSORestServerURL_isCustom", AV159SSORestServerURL_isCustom);
            AV160SSORestServerURL_SLO = AV135GAMApplication.gxTpr_Ssorestserverurl_slo;
            AssignAttri("", false, "AV160SSORestServerURL_SLO", AV160SSORestServerURL_SLO);
            AV158SSORestServerRepositoryGUID = AV135GAMApplication.gxTpr_Ssorestserverrepositoryguid;
            AssignAttri("", false, "AV158SSORestServerRepositoryGUID", AV158SSORestServerRepositoryGUID);
            AV157SSORestServerKey = AV135GAMApplication.gxTpr_Ssorestserverkey;
            AssignAttri("", false, "AV157SSORestServerKey", AV157SSORestServerKey);
            AV57STSProtocolEnable = AV135GAMApplication.gxTpr_Stsprotocolenable;
            AssignAttri("", false, "AV57STSProtocolEnable", AV57STSProtocolEnable);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135GAMApplication.gxTpr_Stsauthorizationuserguid)) )
            {
               AV40GAMUser.load( AV135GAMApplication.gxTpr_Stsauthorizationuserguid);
               AV55STSAuthorizationUserName = AV40GAMUser.gxTpr_Name;
               AssignAttri("", false, "AV55STSAuthorizationUserName", AV55STSAuthorizationUserName);
            }
            AV56STSMode = AV135GAMApplication.gxTpr_Stsmode;
            AssignAttri("", false, "AV56STSMode", AV56STSMode);
            AV60STSServerURL = AV135GAMApplication.gxTpr_Stsserverurl;
            AssignAttri("", false, "AV60STSServerURL", AV60STSServerURL);
            AV58STSServerClientPassword = AV135GAMApplication.gxTpr_Stsserverclientpassword;
            AssignAttri("", false, "AV58STSServerClientPassword", AV58STSServerClientPassword);
            AV59STSServerRepositoryGUID = AV135GAMApplication.gxTpr_Stsserverrepositoryguid;
            AssignAttri("", false, "AV59STSServerRepositoryGUID", AV59STSServerRepositoryGUID);
            AV148MiniAppEnable = AV135GAMApplication.gxTpr_Miniappenable;
            AssignAttri("", false, "AV148MiniAppEnable", AV148MiniAppEnable);
            AV149MiniAppMode = AV135GAMApplication.gxTpr_Miniappmode;
            AssignAttri("", false, "AV149MiniAppMode", AV149MiniAppMode);
            AV146MiniAppClientURL = AV135GAMApplication.gxTpr_Miniappclienturl;
            AssignAttri("", false, "AV146MiniAppClientURL", AV146MiniAppClientURL);
            AV147MiniAppClientURL_isCustom = AV135GAMApplication.gxTpr_Miniappclienturl_iscustom;
            AssignAttri("", false, "AV147MiniAppClientURL_isCustom", AV147MiniAppClientURL_isCustom);
            AV145MiniAppClientRepositoryGUID = AV135GAMApplication.gxTpr_Miniappclientrepositoryguid;
            AssignAttri("", false, "AV145MiniAppClientRepositoryGUID", AV145MiniAppClientRepositoryGUID);
            AV153MiniAppUserAuthenticationTypeName = AV135GAMApplication.gxTpr_Miniappuserauthenticationtypename;
            AssignAttri("", false, "AV153MiniAppUserAuthenticationTypeName", AV153MiniAppUserAuthenticationTypeName);
            AV151MiniAppServerURL = AV135GAMApplication.gxTpr_Miniappserverurl;
            AssignAttri("", false, "AV151MiniAppServerURL", AV151MiniAppServerURL);
            AV152MiniAppServerURL_isCustom = AV135GAMApplication.gxTpr_Miniappserverurl_iscustom;
            AssignAttri("", false, "AV152MiniAppServerURL_isCustom", AV152MiniAppServerURL_isCustom);
            AV150MiniAppServerRepositoryGUID = AV135GAMApplication.gxTpr_Miniappserverrepositoryguid;
            AssignAttri("", false, "AV150MiniAppServerRepositoryGUID", AV150MiniAppServerRepositoryGUID);
            AV120APIKeyEnable = AV135GAMApplication.gxTpr_Apikeyenable;
            AssignAttri("", false, "AV120APIKeyEnable", AV120APIKeyEnable);
            AV121APIKeyTimeout = AV135GAMApplication.gxTpr_Apikeytimeout;
            AssignAttri("", false, "AV121APIKeyTimeout", StringUtil.LTrimStr( (decimal)(AV121APIKeyTimeout), 9, 0));
            AV118APIKeyAllowOnlyAuthenticationTypeName = AV135GAMApplication.gxTpr_Apikeyallowonlyauthenticationtypename;
            AssignAttri("", false, "AV118APIKeyAllowOnlyAuthenticationTypeName", AV118APIKeyAllowOnlyAuthenticationTypeName);
            AV119APIKeyAllowScopeCustomization = AV135GAMApplication.gxTpr_Apikeyallowscopecustomization;
            AssignAttri("", false, "AV119APIKeyAllowScopeCustomization", AV119APIKeyAllowScopeCustomization);
            AV32EnvironmentName = AV135GAMApplication.gxTpr_Environment.gxTpr_Name;
            AssignAttri("", false, "AV32EnvironmentName", AV32EnvironmentName);
            AV36EnvironmentSecureProtocol = AV135GAMApplication.gxTpr_Environment.gxTpr_Secureprotocol;
            AssignAttri("", false, "AV36EnvironmentSecureProtocol", AV36EnvironmentSecureProtocol);
            AV31EnvironmentHost = AV135GAMApplication.gxTpr_Environment.gxTpr_Host;
            AssignAttri("", false, "AV31EnvironmentHost", AV31EnvironmentHost);
            AV33EnvironmentPort = AV135GAMApplication.gxTpr_Environment.gxTpr_Port;
            AssignAttri("", false, "AV33EnvironmentPort", StringUtil.LTrimStr( (decimal)(AV33EnvironmentPort), 5, 0));
            AV37EnvironmentVirtualDirectory = AV135GAMApplication.gxTpr_Environment.gxTpr_Virtualdirectory;
            AssignAttri("", false, "AV37EnvironmentVirtualDirectory", AV37EnvironmentVirtualDirectory);
            AV35EnvironmentProgramPackage = AV135GAMApplication.gxTpr_Environment.gxTpr_Programpackage;
            AssignAttri("", false, "AV35EnvironmentProgramPackage", AV35EnvironmentProgramPackage);
            AV34EnvironmentProgramExtension = AV135GAMApplication.gxTpr_Environment.gxTpr_Programextension;
            AssignAttri("", false, "AV34EnvironmentProgramExtension", AV34EnvironmentProgramExtension);
            AV163GXV2 = 1;
            AV162GXV1 = AV135GAMApplication.getmenus(AV48MenuFilter, out  AV116GAMErrorCollection);
            while ( AV163GXV2 <= AV162GXV1.Count )
            {
               AV47Menu = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV162GXV1.Item(AV163GXV2));
               cmbavMainmenu.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV47Menu.gxTpr_Id), 12, 0)), AV47Menu.gxTpr_Name, 0);
               AV163GXV2 = (int)(AV163GXV2+1);
            }
         }
         else
         {
            edtavClientsecret_Enabled = 1;
            AssignProp("", false, edtavClientsecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientsecret_Enabled), 5, 0), true);
            AV128ClientAuthRequestMustIncludeUserScopes = true;
            AssignAttri("", false, "AV128ClientAuthRequestMustIncludeUserScopes", AV128ClientAuthRequestMustIncludeUserScopes);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavGuid_Enabled = 0;
            AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
            edtavName_Enabled = 0;
            AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            edtavDsc_Enabled = 0;
            AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
            edtavVersion_Enabled = 0;
            AssignProp("", false, edtavVersion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVersion_Enabled), 5, 0), true);
            edtavCopyright_Enabled = 0;
            AssignProp("", false, edtavCopyright_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCopyright_Enabled), 5, 0), true);
            edtavCompany_Enabled = 0;
            AssignProp("", false, edtavCompany_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCompany_Enabled), 5, 0), true);
            chkavReturnmenuoptionswithoutpermission.Enabled = 0;
            AssignProp("", false, chkavReturnmenuoptionswithoutpermission_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavReturnmenuoptionswithoutpermission.Enabled), 5, 0), true);
            cmbavMainmenu.Enabled = 0;
            AssignProp("", false, cmbavMainmenu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMainmenu.Enabled), 5, 0), true);
            chkavUseabsoluteurlbyenvironment.Enabled = 0;
            AssignProp("", false, chkavUseabsoluteurlbyenvironment_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUseabsoluteurlbyenvironment.Enabled), 5, 0), true);
            edtavHomeobject_Enabled = 0;
            AssignProp("", false, edtavHomeobject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomeobject_Enabled), 5, 0), true);
            edtavAccountactivationobject_Enabled = 0;
            AssignProp("", false, edtavAccountactivationobject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAccountactivationobject_Enabled), 5, 0), true);
            edtavLogoutobject_Enabled = 0;
            AssignProp("", false, edtavLogoutobject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLogoutobject_Enabled), 5, 0), true);
            edtavClientid_Enabled = 0;
            AssignProp("", false, edtavClientid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientid_Enabled), 5, 0), true);
            edtavClientsecret_Enabled = 0;
            AssignProp("", false, edtavClientsecret_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientsecret_Enabled), 5, 0), true);
            chkavClientauthrequestmustincludeuserscopes.Enabled = 0;
            AssignProp("", false, chkavClientauthrequestmustincludeuserscopes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientauthrequestmustincludeuserscopes.Enabled), 5, 0), true);
            chkavClientdonotshareuserids.Enabled = 0;
            AssignProp("", false, chkavClientdonotshareuserids_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientdonotshareuserids.Enabled), 5, 0), true);
            chkavClientallowremoteauth.Enabled = 0;
            AssignProp("", false, chkavClientallowremoteauth_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowremoteauth.Enabled), 5, 0), true);
            chkavClientallowgetuserdata.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuserdata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuserdata.Enabled), 5, 0), true);
            chkavClientallowgetuseradddata.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuseradddata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuseradddata.Enabled), 5, 0), true);
            chkavClientallowgetuserroles.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuserroles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuserroles.Enabled), 5, 0), true);
            chkavClientallowgetsessioniniprop.Enabled = 0;
            AssignProp("", false, chkavClientallowgetsessioniniprop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetsessioniniprop.Enabled), 5, 0), true);
            chkavClientallowgetsessionappdata.Enabled = 0;
            AssignProp("", false, chkavClientallowgetsessionappdata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetsessionappdata.Enabled), 5, 0), true);
            edtavClientallowadditionalscope_Enabled = 0;
            AssignProp("", false, edtavClientallowadditionalscope_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientallowadditionalscope_Enabled), 5, 0), true);
            edtavClientimageurl_Enabled = 0;
            AssignProp("", false, edtavClientimageurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientimageurl_Enabled), 5, 0), true);
            edtavClientlocalloginurl_Enabled = 0;
            AssignProp("", false, edtavClientlocalloginurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientlocalloginurl_Enabled), 5, 0), true);
            edtavClientcallbackurl_Enabled = 0;
            AssignProp("", false, edtavClientcallbackurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientcallbackurl_Enabled), 5, 0), true);
            chkavClientcallbackurliscustom.Enabled = 0;
            AssignProp("", false, chkavClientcallbackurliscustom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientcallbackurliscustom.Enabled), 5, 0), true);
            edtavClientcallbackurlstatename_Enabled = 0;
            AssignProp("", false, edtavClientcallbackurlstatename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientcallbackurlstatename_Enabled), 5, 0), true);
            chkavClientallowremoterestauth.Enabled = 0;
            AssignProp("", false, chkavClientallowremoterestauth_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowremoterestauth.Enabled), 5, 0), true);
            chkavClientallowgetuserdatarest.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuserdatarest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuserdatarest.Enabled), 5, 0), true);
            chkavClientallowgetuseradddatarest.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuseradddatarest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuseradddatarest.Enabled), 5, 0), true);
            chkavClientallowgetuserrolesrest.Enabled = 0;
            AssignProp("", false, chkavClientallowgetuserrolesrest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetuserrolesrest.Enabled), 5, 0), true);
            chkavClientallowgetsessioniniproprest.Enabled = 0;
            AssignProp("", false, chkavClientallowgetsessioniniproprest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetsessioniniproprest.Enabled), 5, 0), true);
            chkavClientallowgetsessionappdatarest.Enabled = 0;
            AssignProp("", false, chkavClientallowgetsessionappdatarest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientallowgetsessionappdatarest.Enabled), 5, 0), true);
            edtavClientallowadditionalscoperest_Enabled = 0;
            AssignProp("", false, edtavClientallowadditionalscoperest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientallowadditionalscoperest_Enabled), 5, 0), true);
            chkavClientaccessuniquebyuser.Enabled = 0;
            AssignProp("", false, chkavClientaccessuniquebyuser_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavClientaccessuniquebyuser.Enabled), 5, 0), true);
            edtavClientencryptionkey_Enabled = 0;
            AssignProp("", false, edtavClientencryptionkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientencryptionkey_Enabled), 5, 0), true);
            edtavClientrepositoryguid_Enabled = 0;
            AssignProp("", false, edtavClientrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClientrepositoryguid_Enabled), 5, 0), true);
            chkavAccessrequirespermission.Enabled = 0;
            AssignProp("", false, chkavAccessrequirespermission_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAccessrequirespermission.Enabled), 5, 0), true);
            chkavIsauthorizationdelegated.Enabled = 0;
            AssignProp("", false, chkavIsauthorizationdelegated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsauthorizationdelegated.Enabled), 5, 0), true);
            cmbavDelegateauthorizationversion.Enabled = 0;
            AssignProp("", false, cmbavDelegateauthorizationversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavDelegateauthorizationversion.Enabled), 5, 0), true);
            edtavDelegateauthorizationfilename_Enabled = 0;
            AssignProp("", false, edtavDelegateauthorizationfilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelegateauthorizationfilename_Enabled), 5, 0), true);
            edtavDelegateauthorizationpackage_Enabled = 0;
            AssignProp("", false, edtavDelegateauthorizationpackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelegateauthorizationpackage_Enabled), 5, 0), true);
            edtavDelegateauthorizationclassname_Enabled = 0;
            AssignProp("", false, edtavDelegateauthorizationclassname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelegateauthorizationclassname_Enabled), 5, 0), true);
            edtavDelegateauthorizationmethod_Enabled = 0;
            AssignProp("", false, edtavDelegateauthorizationmethod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelegateauthorizationmethod_Enabled), 5, 0), true);
            chkavSsorestenable.Enabled = 0;
            AssignProp("", false, chkavSsorestenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavSsorestenable.Enabled), 5, 0), true);
            cmbavSsorestmode.Enabled = 0;
            AssignProp("", false, cmbavSsorestmode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSsorestmode.Enabled), 5, 0), true);
            edtavSsorestuserauthtypename_Enabled = 0;
            AssignProp("", false, edtavSsorestuserauthtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSsorestuserauthtypename_Enabled), 5, 0), true);
            edtavSsorestserverurl_Enabled = 0;
            AssignProp("", false, edtavSsorestserverurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSsorestserverurl_Enabled), 5, 0), true);
            chkavSsorestserverurl_iscustom.Enabled = 0;
            AssignProp("", false, chkavSsorestserverurl_iscustom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavSsorestserverurl_iscustom.Enabled), 5, 0), true);
            edtavSsorestserverurl_slo_Enabled = 0;
            AssignProp("", false, edtavSsorestserverurl_slo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSsorestserverurl_slo_Enabled), 5, 0), true);
            edtavSsorestserverrepositoryguid_Enabled = 0;
            AssignProp("", false, edtavSsorestserverrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSsorestserverrepositoryguid_Enabled), 5, 0), true);
            edtavSsorestserverkey_Enabled = 0;
            AssignProp("", false, edtavSsorestserverkey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSsorestserverkey_Enabled), 5, 0), true);
            chkavStsprotocolenable.Enabled = 0;
            AssignProp("", false, chkavStsprotocolenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavStsprotocolenable.Enabled), 5, 0), true);
            edtavStsauthorizationusername_Enabled = 0;
            AssignProp("", false, edtavStsauthorizationusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStsauthorizationusername_Enabled), 5, 0), true);
            cmbavStsmode.Enabled = 0;
            AssignProp("", false, cmbavStsmode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavStsmode.Enabled), 5, 0), true);
            edtavStsserverurl_Enabled = 0;
            AssignProp("", false, edtavStsserverurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStsserverurl_Enabled), 5, 0), true);
            edtavStsserverclientpassword_Enabled = 0;
            AssignProp("", false, edtavStsserverclientpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStsserverclientpassword_Enabled), 5, 0), true);
            edtavStsserverrepositoryguid_Enabled = 0;
            AssignProp("", false, edtavStsserverrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavStsserverrepositoryguid_Enabled), 5, 0), true);
            chkavMiniappenable.Enabled = 0;
            AssignProp("", false, chkavMiniappenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavMiniappenable.Enabled), 5, 0), true);
            cmbavMiniappmode.Enabled = 0;
            AssignProp("", false, cmbavMiniappmode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMiniappmode.Enabled), 5, 0), true);
            edtavMiniappclienturl_Enabled = 0;
            AssignProp("", false, edtavMiniappclienturl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMiniappclienturl_Enabled), 5, 0), true);
            chkavMiniappclienturl_iscustom.Enabled = 0;
            AssignProp("", false, chkavMiniappclienturl_iscustom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavMiniappclienturl_iscustom.Enabled), 5, 0), true);
            edtavMiniappclientrepositoryguid_Enabled = 0;
            AssignProp("", false, edtavMiniappclientrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMiniappclientrepositoryguid_Enabled), 5, 0), true);
            cmbavMiniappuserauthenticationtypename.Enabled = 0;
            AssignProp("", false, cmbavMiniappuserauthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMiniappuserauthenticationtypename.Enabled), 5, 0), true);
            edtavMiniappserverurl_Enabled = 0;
            AssignProp("", false, edtavMiniappserverurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMiniappserverurl_Enabled), 5, 0), true);
            chkavMiniappserverurl_iscustom.Enabled = 0;
            AssignProp("", false, chkavMiniappserverurl_iscustom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavMiniappserverurl_iscustom.Enabled), 5, 0), true);
            edtavMiniappserverrepositoryguid_Enabled = 0;
            AssignProp("", false, edtavMiniappserverrepositoryguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavMiniappserverrepositoryguid_Enabled), 5, 0), true);
            chkavApikeyenable.Enabled = 0;
            AssignProp("", false, chkavApikeyenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavApikeyenable.Enabled), 5, 0), true);
            edtavApikeytimeout_Enabled = 0;
            AssignProp("", false, edtavApikeytimeout_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavApikeytimeout_Enabled), 5, 0), true);
            cmbavApikeyallowonlyauthenticationtypename.Enabled = 0;
            AssignProp("", false, cmbavApikeyallowonlyauthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavApikeyallowonlyauthenticationtypename.Enabled), 5, 0), true);
            chkavApikeyallowscopecustomization.Enabled = 0;
            AssignProp("", false, chkavApikeyallowscopecustomization_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavApikeyallowscopecustomization.Enabled), 5, 0), true);
            edtavEnvironmentname_Enabled = 0;
            AssignProp("", false, edtavEnvironmentname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentname_Enabled), 5, 0), true);
            chkavEnvironmentsecureprotocol.Enabled = 0;
            AssignProp("", false, chkavEnvironmentsecureprotocol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavEnvironmentsecureprotocol.Enabled), 5, 0), true);
            edtavEnvironmenthost_Enabled = 0;
            AssignProp("", false, edtavEnvironmenthost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmenthost_Enabled), 5, 0), true);
            edtavEnvironmentport_Enabled = 0;
            AssignProp("", false, edtavEnvironmentport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentport_Enabled), 5, 0), true);
            edtavEnvironmentvirtualdirectory_Enabled = 0;
            AssignProp("", false, edtavEnvironmentvirtualdirectory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentvirtualdirectory_Enabled), 5, 0), true);
            edtavEnvironmentprogrampackage_Enabled = 0;
            AssignProp("", false, edtavEnvironmentprogrampackage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentprogrampackage_Enabled), 5, 0), true);
            edtavEnvironmentprogramextension_Enabled = 0;
            AssignProp("", false, edtavEnvironmentprogramextension_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnvironmentprogramextension_Enabled), 5, 0), true);
            bttBtngeneratekeygamremote_Visible = 0;
            AssignProp("", false, bttBtngeneratekeygamremote_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtngeneratekeygamremote_Visible), 5, 0), true);
            if ( (DateTime.MinValue==AV135GAMApplication.gxTpr_Clientrevoked) )
            {
               bttBtnrevokeallow_Caption = "Revoke";
               AssignProp("", false, bttBtnrevokeallow_Internalname, "Caption", bttBtnrevokeallow_Caption, true);
            }
            else
            {
               bttBtnrevokeallow_Caption = "WWP_GAM_Authorize";
               AssignProp("", false, bttBtnrevokeallow_Internalname, "Caption", bttBtnrevokeallow_Caption, true);
            }
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               bttBtnenter_Caption = "Delete";
               AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
            }
         }
         /* Execute user subroutine: 'UI_REMOTEAUTHENTICATIONWEB' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_REMOTEAUTHENTICATIONREST' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_DELEGATEAUTHORIZATION' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_SSOREST' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_STSPROTOCOL' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_MINIAPP' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_APIKEY' */
         S182 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S192 ();
         if (returnInSub) return;
         chkavAutoregisteranomymoususer.Visible = 0;
         AssignProp("", false, chkavAutoregisteranomymoususer_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavAutoregisteranomymoususer.Visible), 5, 0), true);
         edtavStsauthorizationuserguid_Visible = 0;
         AssignProp("", false, edtavStsauthorizationuserguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStsauthorizationuserguid_Visible), 5, 0), true);
         Gridlanguages_empowerer_Gridinternalname = subGridlanguages_Internalname;
         ucGridlanguages_empowerer.SendProperty(context, "", false, Gridlanguages_empowerer_Internalname, "GridInternalName", Gridlanguages_empowerer_Gridinternalname);
         subGridlanguages_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Rows), 6, 0, ".", "")));
         AV140GridLanguagesCurrentPage = 1;
         AssignAttri("", false, "AV140GridLanguagesCurrentPage", StringUtil.LTrimStr( (decimal)(AV140GridLanguagesCurrentPage), 10, 0));
         edtavGridlanguagescurrentpage_Visible = 0;
         AssignProp("", false, edtavGridlanguagescurrentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGridlanguagescurrentpage_Visible), 5, 0), true);
         AV141GridLanguagesPageCount = -1;
         AssignAttri("", false, "AV141GridLanguagesPageCount", StringUtil.LTrimStr( (decimal)(AV141GridLanguagesPageCount), 10, 0));
         Gridlanguagespaginationbar_Rowsperpageselectedvalue = subGridlanguages_Rows;
         ucGridlanguagespaginationbar.SendProperty(context, "", false, Gridlanguagespaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridlanguagespaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E250Y2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
      }

      private void E260Y2( )
      {
         /* Gridlanguages_Load Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLANGUAGES' */
         S202 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E120Y2( )
      {
         /* Gridlanguagespaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridlanguagespaginationbar_Selectedpage, "Previous") == 0 )
         {
            AV140GridLanguagesCurrentPage = (long)(AV140GridLanguagesCurrentPage-1);
            AssignAttri("", false, "AV140GridLanguagesCurrentPage", StringUtil.LTrimStr( (decimal)(AV140GridLanguagesCurrentPage), 10, 0));
            subgridlanguages_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridlanguagespaginationbar_Selectedpage, "Next") == 0 )
         {
            AV140GridLanguagesCurrentPage = (long)(AV140GridLanguagesCurrentPage+1);
            AssignAttri("", false, "AV140GridLanguagesCurrentPage", StringUtil.LTrimStr( (decimal)(AV140GridLanguagesCurrentPage), 10, 0));
            subgridlanguages_nextpage( ) ;
         }
         else
         {
            AV155PageToGo = (int)(Math.Round(NumberUtil.Val( Gridlanguagespaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV140GridLanguagesCurrentPage = AV155PageToGo;
            AssignAttri("", false, "AV140GridLanguagesCurrentPage", StringUtil.LTrimStr( (decimal)(AV140GridLanguagesCurrentPage), 10, 0));
            subgridlanguages_gotopage( AV155PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E130Y2( )
      {
         /* Gridlanguagespaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGridlanguages_Rows = Gridlanguagespaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Rows), 6, 0, ".", "")));
         AV140GridLanguagesCurrentPage = 1;
         AssignAttri("", false, "AV140GridLanguagesCurrentPage", StringUtil.LTrimStr( (decimal)(AV140GridLanguagesCurrentPage), 10, 0));
         subgridlanguages_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E140Y2( )
      {
         /* 'DoGenerateKeyGAMRemote' Routine */
         returnInSub = false;
         AV21ClientEncryptionKey = Crypto.GetEncryptionKey( );
         AssignAttri("", false, "AV21ClientEncryptionKey", AV21ClientEncryptionKey);
         /*  Sending Event outputs  */
      }

      protected void E150Y2( )
      {
         /* 'DoRevokeAllow' Routine */
         returnInSub = false;
         AV135GAMApplication.load( AV43Id);
         if ( (DateTime.MinValue==AV135GAMApplication.gxTpr_Clientrevoked) )
         {
            AV44isOk = AV135GAMApplication.revokeclient(out  AV39Errors);
         }
         else
         {
            AV44isOk = AV135GAMApplication.authorizeclient(out  AV39Errors);
         }
         if ( AV44isOk )
         {
            if ( (DateTime.MinValue==AV135GAMApplication.gxTpr_Clientrevoked) )
            {
               bttBtnrevokeallow_Caption = "Revoke";
               AssignProp("", false, bttBtnrevokeallow_Internalname, "Caption", bttBtnrevokeallow_Caption, true);
            }
            else
            {
               bttBtnrevokeallow_Caption = "WWP_GAM_Authorize";
               AssignProp("", false, bttBtnrevokeallow_Internalname, "Caption", bttBtnrevokeallow_Caption, true);
            }
            context.CommitDataStores("gamapplicationentry",pr_default);
            context.DoAjaxRefresh();
         }
         else
         {
            /* Execute user subroutine: 'ERRORS' */
            S212 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV135GAMApplication", AV135GAMApplication);
      }

      protected void S192( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV56STSMode, "fulltoken") == 0 ) || ( StringUtil.StrCmp(AV56STSMode, "gettoken") == 0 ) ) )
         {
            edtavStsserverclientpassword_Visible = 0;
            AssignProp("", false, edtavStsserverclientpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStsserverclientpassword_Visible), 5, 0), true);
            divStsserverclientpassword_cell_Class = "Invisible";
            AssignProp("", false, divStsserverclientpassword_cell_Internalname, "Class", divStsserverclientpassword_cell_Class, true);
         }
         else
         {
            edtavStsserverclientpassword_Visible = 1;
            AssignProp("", false, edtavStsserverclientpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavStsserverclientpassword_Visible), 5, 0), true);
            divStsserverclientpassword_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp("", false, divStsserverclientpassword_cell_Internalname, "Class", divStsserverclientpassword_cell_Class, true);
         }
         if ( edtavStsserverclientpassword_Visible == 0 )
         {
            divTablestsclientgettoken_Visible = 0;
            AssignProp("", false, divTablestsclientgettoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsclientgettoken_Visible), 5, 0), true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E160Y2 ();
         if (returnInSub) return;
      }

      protected void E160Y2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            AV135GAMApplication.load( AV43Id);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            AV135GAMApplication.gxTpr_Name = AV49Name;
            AV135GAMApplication.gxTpr_Description = AV30Dsc;
            AV135GAMApplication.gxTpr_Version = AV64Version;
            AV135GAMApplication.gxTpr_Copyright = AV29Copyright;
            AV135GAMApplication.gxTpr_Companyname = AV28Company;
            AV135GAMApplication.gxTpr_Returnmenuoptionswithoutpermission = AV156ReturnMenuOptionsWithoutPermission;
            AV135GAMApplication.gxTpr_Mainmenuid = AV46MainMenu;
            AV135GAMApplication.gxTpr_Useabsoluteurlbyenvironment = AV61UseAbsoluteUrlByEnvironment;
            AV135GAMApplication.gxTpr_Homeobject = AV42HomeObject;
            AV135GAMApplication.gxTpr_Accountactivationobject = AV66AccountActivationObject;
            AV135GAMApplication.gxTpr_Logoutobject = AV45LogoutObject;
            AV135GAMApplication.gxTpr_Clientid = AV22ClientId;
            AV135GAMApplication.gxTpr_Clientsecret = AV27ClientSecret;
            AV135GAMApplication.gxTpr_Clientauthenticationrequestmustincludeuserscopes = AV128ClientAuthRequestMustIncludeUserScopes;
            AV135GAMApplication.gxTpr_Clientdonotshareuserids = AV129ClientDoNotShareUserIDs;
            AV135GAMApplication.gxTpr_Clientaccessuniquebyuser = AV8ClientAccessUniqueByUser;
            AV135GAMApplication.gxTpr_Clientallowremoteauthentication = AV17ClientAllowRemoteAuth;
            AV135GAMApplication.gxTpr_Clientallowgetuserdata = AV126ClientAllowGetUserData;
            AV135GAMApplication.gxTpr_Clientallowgetuseradditionaldata = AV13ClientAllowGetUserAddData;
            AV135GAMApplication.gxTpr_Clientallowgetuserroles = AV15ClientAllowGetUserRoles;
            AV135GAMApplication.gxTpr_Clientallowgetsessioninitialproperties = AV11ClientAllowGetSessionIniProp;
            AV135GAMApplication.gxTpr_Clientallowgetsessionapplicationdata = AV9ClientAllowGetSessionAppData;
            AV135GAMApplication.gxTpr_Clientallowadditionalscope = AV124ClientAllowAdditionalScope;
            AV135GAMApplication.gxTpr_Clientlocalloginurl = AV24ClientLocalLoginURL;
            AV135GAMApplication.gxTpr_Clientcallbackurl = AV19ClientCallbackURL;
            AV135GAMApplication.gxTpr_Clientcallbackurliscustom = AV20ClientCallbackURLisCustom;
            AV135GAMApplication.gxTpr_Clientcallbackurlstatename = AV65ClientCallbackURLStateName;
            AV135GAMApplication.gxTpr_Clientimageurl = AV23ClientImageURL;
            AV135GAMApplication.gxTpr_Clientallowremoterestauthentication = AV18ClientAllowRemoteRestAuth;
            AV135GAMApplication.gxTpr_Clientallowgetuserdatarest = AV127ClientAllowGetUserDataREST;
            AV135GAMApplication.gxTpr_Clientallowgetuseradditionaldatarest = AV14ClientAllowGetUserAddDataRest;
            AV135GAMApplication.gxTpr_Clientallowgetuserrolesrest = AV16ClientAllowGetUserRolesRest;
            AV135GAMApplication.gxTpr_Clientallowgetsessioninitialpropertiesrest = AV12ClientAllowGetSessionIniPropRest;
            AV135GAMApplication.gxTpr_Clientallowgetsessionapplicationdatarest = AV10ClientAllowGetSessionAppDataREST;
            AV135GAMApplication.gxTpr_Clientallowadditionalscoperest = AV125ClientAllowAdditionalScopeREST;
            AV135GAMApplication.gxTpr_Clientencryptionkey = AV21ClientEncryptionKey;
            AV135GAMApplication.gxTpr_Clientrepositoryguid = AV25ClientRepositoryGUID;
            AV135GAMApplication.gxTpr_Accessrequirespermission = AV5AccessRequiresPermission;
            AV135GAMApplication.gxTpr_Isauthorizationdelegated = AV143IsAuthorizationDelegated;
            AV135GAMApplication.gxTpr_Delegateauthorization.gxTpr_Version = AV134DelegateAuthorizationVersion;
            AV135GAMApplication.gxTpr_Delegateauthorization.gxTpr_Filename = AV131DelegateAuthorizationFileName;
            AV135GAMApplication.gxTpr_Delegateauthorization.gxTpr_Package = AV133DelegateAuthorizationPackage;
            AV135GAMApplication.gxTpr_Delegateauthorization.gxTpr_Classname = AV130DelegateAuthorizationClassName;
            AV135GAMApplication.gxTpr_Delegateauthorization.gxTpr_Method = AV132DelegateAuthorizationMethod;
            AV135GAMApplication.gxTpr_Ssorestenable = AV50SSORestEnable;
            AV135GAMApplication.gxTpr_Ssorestmode = AV51SSORestMode;
            AV135GAMApplication.gxTpr_Ssorestuserauthenticationtypename = AV53SSORestUserAuthTypeName;
            AV135GAMApplication.gxTpr_Ssorestserverurl = AV52SSORestServerURL;
            AV135GAMApplication.gxTpr_Ssorestserverurl_iscustom = AV159SSORestServerURL_isCustom;
            AV135GAMApplication.gxTpr_Ssorestserverurl_slo = AV160SSORestServerURL_SLO;
            AV135GAMApplication.gxTpr_Ssorestserverrepositoryguid = AV158SSORestServerRepositoryGUID;
            AV135GAMApplication.gxTpr_Ssorestserverkey = AV157SSORestServerKey;
            AV135GAMApplication.gxTpr_Stsprotocolenable = AV57STSProtocolEnable;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55STSAuthorizationUserName)) )
            {
               AV40GAMUser = AV40GAMUser.getbylogin("local", AV55STSAuthorizationUserName, out  AV63UserErrors);
               AV54STSAuthorizationUserGUID = AV40GAMUser.gxTpr_Guid;
               AssignAttri("", false, "AV54STSAuthorizationUserGUID", AV54STSAuthorizationUserGUID);
            }
            AV135GAMApplication.gxTpr_Stsauthorizationuserguid = AV54STSAuthorizationUserGUID;
            AV135GAMApplication.gxTpr_Stsmode = AV56STSMode;
            AV135GAMApplication.gxTpr_Stsserverurl = AV60STSServerURL;
            AV135GAMApplication.gxTpr_Stsserverclientpassword = AV58STSServerClientPassword;
            AV135GAMApplication.gxTpr_Stsserverrepositoryguid = AV59STSServerRepositoryGUID;
            AV135GAMApplication.gxTpr_Miniappenable = AV148MiniAppEnable;
            AV135GAMApplication.gxTpr_Miniappmode = AV149MiniAppMode;
            AV135GAMApplication.gxTpr_Miniappclienturl = AV146MiniAppClientURL;
            AV135GAMApplication.gxTpr_Miniappclienturl_iscustom = AV147MiniAppClientURL_isCustom;
            AV135GAMApplication.gxTpr_Miniappclientrepositoryguid = AV145MiniAppClientRepositoryGUID;
            AV135GAMApplication.gxTpr_Miniappuserauthenticationtypename = AV153MiniAppUserAuthenticationTypeName;
            AV135GAMApplication.gxTpr_Miniappserverurl = AV151MiniAppServerURL;
            AV135GAMApplication.gxTpr_Miniappserverurl_iscustom = AV152MiniAppServerURL_isCustom;
            AV135GAMApplication.gxTpr_Miniappserverrepositoryguid = AV150MiniAppServerRepositoryGUID;
            AV135GAMApplication.gxTpr_Apikeyenable = AV120APIKeyEnable;
            AV135GAMApplication.gxTpr_Apikeytimeout = AV121APIKeyTimeout;
            AV135GAMApplication.gxTpr_Apikeyallowonlyauthenticationtypename = AV118APIKeyAllowOnlyAuthenticationTypeName;
            AV135GAMApplication.gxTpr_Apikeyallowscopecustomization = AV119APIKeyAllowScopeCustomization;
            AV135GAMApplication.gxTpr_Environment.gxTpr_Name = AV32EnvironmentName;
            AV135GAMApplication.gxTpr_Environment.gxTpr_Secureprotocol = AV36EnvironmentSecureProtocol;
            AV135GAMApplication.gxTpr_Environment.gxTpr_Host = AV31EnvironmentHost;
            AV135GAMApplication.gxTpr_Environment.gxTpr_Port = AV33EnvironmentPort;
            AV135GAMApplication.gxTpr_Environment.gxTpr_Virtualdirectory = AV37EnvironmentVirtualDirectory;
            AV135GAMApplication.gxTpr_Environment.gxTpr_Programpackage = AV35EnvironmentProgramPackage;
            AV135GAMApplication.gxTpr_Environment.gxTpr_Programextension = AV34EnvironmentProgramExtension;
            /* Execute user subroutine: 'SAVELANGUAGES' */
            S222 ();
            if (returnInSub) return;
            AV135GAMApplication.save();
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV135GAMApplication.delete();
         }
         if ( AV135GAMApplication.success() && ( AV63UserErrors.Count == 0 ) )
         {
            context.CommitDataStores("gamapplicationentry",pr_default);
            CallWebObject(formatLink("gamwwapplications.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV39Errors = AV135GAMApplication.geterrors();
            /* Execute user subroutine: 'ERRORS' */
            S212 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV135GAMApplication", AV135GAMApplication);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40GAMUser", AV40GAMUser);
      }

      protected void E270Y2( )
      {
         /* 'GenerateKeyGAMRemote' Routine */
         returnInSub = false;
         AV21ClientEncryptionKey = Crypto.GetEncryptionKey( );
         AssignAttri("", false, "AV21ClientEncryptionKey", AV21ClientEncryptionKey);
         /*  Sending Event outputs  */
      }

      protected void E280Y2( )
      {
         /* 'Revoke-Authorize' Routine */
         returnInSub = false;
         AV135GAMApplication.load( AV43Id);
         if ( ! (DateTime.MinValue==AV135GAMApplication.gxTpr_Clientrevoked) )
         {
            AV44isOk = AV135GAMApplication.revokeclient(out  AV116GAMErrorCollection);
            GX_msglist.addItem(StringUtil.Format( "The application %1 was revoked", AV135GAMApplication.gxTpr_Name, "", "", "", "", "", "", "", ""));
         }
         else
         {
            AV44isOk = AV135GAMApplication.authorizeclient(out  AV116GAMErrorCollection);
            GX_msglist.addItem(StringUtil.Format( "The application %1 was activated", AV135GAMApplication.gxTpr_Name, "", "", "", "", "", "", "", ""));
         }
         if ( AV44isOk )
         {
            context.CommitDataStores("gamapplicationentry",pr_default);
            /* Execute user subroutine: 'SHOWAPPLICATIONSTATUS' */
            S112 ();
            if (returnInSub) return;
         }
         AV39Errors = AV116GAMErrorCollection;
         /* Execute user subroutine: 'ERRORS' */
         S212 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV135GAMApplication", AV135GAMApplication);
         cmbavClientaccessstatus.CurrentValue = StringUtil.RTrim( AV123ClientAccessStatus);
         AssignProp("", false, cmbavClientaccessstatus_Internalname, "Values", cmbavClientaccessstatus.ToJavascriptSource(), true);
      }

      protected void E290Y2( )
      {
         /* 'Translations' Routine */
         returnInSub = false;
         /* Window Datatype Object Property */
         AV117Window.Url = formatLink("gamtranslations.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim("Application")),UrlEncode(StringUtil.RTrim(AV49Name)),UrlEncode(StringUtil.LTrimStr(AV43Id,12,0)),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","Type","Title","PrimaryID","SecondaryID","TertiaryID"}) ;
         AV117Window.SetReturnParms(new Object[] {});
         context.NewWindow(AV117Window);
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E170Y2( )
      {
         /* Ssorestenable_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UI_SSOREST' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E180Y2( )
      {
         /* Ssorestmode_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UI_SSOREST' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E190Y2( )
      {
         /* Miniappenable_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UI_MINIAPP' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavMiniappuserauthenticationtypename.CurrentValue = StringUtil.RTrim( AV153MiniAppUserAuthenticationTypeName);
         AssignProp("", false, cmbavMiniappuserauthenticationtypename_Internalname, "Values", cmbavMiniappuserauthenticationtypename.ToJavascriptSource(), true);
      }

      protected void E200Y2( )
      {
         /* Miniappmode_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UI_MINIAPP' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavMiniappuserauthenticationtypename.CurrentValue = StringUtil.RTrim( AV153MiniAppUserAuthenticationTypeName);
         AssignProp("", false, cmbavMiniappuserauthenticationtypename_Internalname, "Values", cmbavMiniappuserauthenticationtypename.ToJavascriptSource(), true);
      }

      protected void E210Y2( )
      {
         /* Apikeyenable_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UI_APIKEY' */
         S182 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavApikeyallowonlyauthenticationtypename.CurrentValue = StringUtil.RTrim( AV118APIKeyAllowOnlyAuthenticationTypeName);
         AssignProp("", false, cmbavApikeyallowonlyauthenticationtypename_Internalname, "Values", cmbavApikeyallowonlyauthenticationtypename.ToJavascriptSource(), true);
      }

      protected void E220Y2( )
      {
         /* Ssorestmode_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UI_SSOREST' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E230Y2( )
      {
         /* Ssorestenable_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UI_SSOREST' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S212( )
      {
         /* 'ERRORS' Routine */
         returnInSub = false;
         if ( AV39Errors.Count > 0 )
         {
            AV164GXV3 = 1;
            while ( AV164GXV3 <= AV39Errors.Count )
            {
               AV38Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV39Errors.Item(AV164GXV3));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV38Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV38Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV164GXV3 = (int)(AV164GXV3+1);
            }
         }
         if ( AV63UserErrors.Count > 0 )
         {
            AV165GXV4 = 1;
            while ( AV165GXV4 <= AV63UserErrors.Count )
            {
               AV38Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV63UserErrors.Item(AV165GXV4));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV38Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV38Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV165GXV4 = (int)(AV165GXV4+1);
            }
         }
      }

      protected void S112( )
      {
         /* 'SHOWAPPLICATIONSTATUS' Routine */
         returnInSub = false;
         if ( (DateTime.MinValue==AV135GAMApplication.gxTpr_Clientrevoked) )
         {
            bttBtnrevokeallow_Caption = "Revoke";
            AssignProp("", false, bttBtnrevokeallow_Internalname, "Caption", bttBtnrevokeallow_Caption, true);
            AV123ClientAccessStatus = "on";
            AssignAttri("", false, "AV123ClientAccessStatus", AV123ClientAccessStatus);
            edtavClientrevoked_Visible = 0;
            AssignProp("", false, edtavClientrevoked_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientrevoked_Visible), 5, 0), true);
         }
         else
         {
            bttBtnrevokeallow_Caption = "Activate";
            AssignProp("", false, bttBtnrevokeallow_Internalname, "Caption", bttBtnrevokeallow_Caption, true);
            AV123ClientAccessStatus = "off";
            AssignAttri("", false, "AV123ClientAccessStatus", AV123ClientAccessStatus);
            edtavClientrevoked_Visible = 1;
            AssignProp("", false, edtavClientrevoked_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientrevoked_Visible), 5, 0), true);
            AV26ClientRevoked = AV135GAMApplication.gxTpr_Clientrevoked;
            AssignAttri("", false, "AV26ClientRevoked", context.localUtil.TToC( AV26ClientRevoked, 10, 5, 1, 3, "/", ":", " "));
         }
      }

      protected void S122( )
      {
         /* 'UI_REMOTEAUTHENTICATIONWEB' Routine */
         returnInSub = false;
         if ( AV17ClientAllowRemoteAuth )
         {
            divTblwebauth_Visible = 1;
            AssignProp("", false, divTblwebauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblwebauth_Visible), 5, 0), true);
            divTblgeneralauth_Visible = 1;
            AssignProp("", false, divTblgeneralauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblgeneralauth_Visible), 5, 0), true);
         }
         else
         {
            divTblwebauth_Visible = 0;
            AssignProp("", false, divTblwebauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblwebauth_Visible), 5, 0), true);
            if ( ! AV18ClientAllowRemoteRestAuth )
            {
               divTblgeneralauth_Visible = 0;
               AssignProp("", false, divTblgeneralauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblgeneralauth_Visible), 5, 0), true);
            }
         }
      }

      protected void S132( )
      {
         /* 'UI_REMOTEAUTHENTICATIONREST' Routine */
         returnInSub = false;
         if ( AV18ClientAllowRemoteRestAuth )
         {
            divTblrestauth_Visible = 1;
            AssignProp("", false, divTblrestauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblrestauth_Visible), 5, 0), true);
            divTblgeneralauth_Visible = 1;
            AssignProp("", false, divTblgeneralauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblgeneralauth_Visible), 5, 0), true);
         }
         else
         {
            divTblrestauth_Visible = 0;
            AssignProp("", false, divTblrestauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblrestauth_Visible), 5, 0), true);
            if ( ! AV17ClientAllowRemoteAuth )
            {
               divTblgeneralauth_Visible = 0;
               AssignProp("", false, divTblgeneralauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblgeneralauth_Visible), 5, 0), true);
            }
         }
      }

      protected void S142( )
      {
         /* 'UI_DELEGATEAUTHORIZATION' Routine */
         returnInSub = false;
         if ( AV5AccessRequiresPermission )
         {
            divTbldelegateauthorization_Visible = 1;
            AssignProp("", false, divTbldelegateauthorization_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbldelegateauthorization_Visible), 5, 0), true);
            if ( AV143IsAuthorizationDelegated )
            {
               divTbldelegateauthorizationprop_Visible = 1;
               AssignProp("", false, divTbldelegateauthorizationprop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbldelegateauthorizationprop_Visible), 5, 0), true);
            }
            else
            {
               divTbldelegateauthorizationprop_Visible = 0;
               AssignProp("", false, divTbldelegateauthorizationprop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbldelegateauthorizationprop_Visible), 5, 0), true);
            }
         }
         else
         {
            divTbldelegateauthorization_Visible = 0;
            AssignProp("", false, divTbldelegateauthorization_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbldelegateauthorization_Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'UI_SSOREST' Routine */
         returnInSub = false;
         if ( AV50SSORestEnable )
         {
            /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPESSOREST' */
            S232 ();
            if (returnInSub) return;
            divTablessorest_Visible = 1;
            AssignProp("", false, divTablessorest_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablessorest_Visible), 5, 0), true);
            divTblssorestmodeclient_Visible = 0;
            AssignProp("", false, divTblssorestmodeclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblssorestmodeclient_Visible), 5, 0), true);
            if ( StringUtil.StrCmp(AV51SSORestMode, "server") == 0 )
            {
               divTblssorestmodeclient_Visible = 0;
               AssignProp("", false, divTblssorestmodeclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblssorestmodeclient_Visible), 5, 0), true);
            }
            else if ( StringUtil.StrCmp(AV51SSORestMode, "client") == 0 )
            {
               divTblssorestmodeclient_Visible = 1;
               AssignProp("", false, divTblssorestmodeclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblssorestmodeclient_Visible), 5, 0), true);
            }
         }
         else
         {
            divTablessorest_Visible = 0;
            AssignProp("", false, divTablessorest_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablessorest_Visible), 5, 0), true);
         }
      }

      protected void S162( )
      {
         /* 'UI_STSPROTOCOL' Routine */
         returnInSub = false;
         if ( AV57STSProtocolEnable )
         {
            divTablests_Visible = 1;
            AssignProp("", false, divTablests_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablests_Visible), 5, 0), true);
            if ( StringUtil.StrCmp(AV56STSMode, "server") == 0 )
            {
               divTablestsserverchecktoken_Visible = 1;
               AssignProp("", false, divTablestsserverchecktoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsserverchecktoken_Visible), 5, 0), true);
               divTablestsclientgettoken_Visible = 0;
               AssignProp("", false, divTablestsclientgettoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsclientgettoken_Visible), 5, 0), true);
               divTablestsclient_Visible = 0;
               AssignProp("", false, divTablestsclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsclient_Visible), 5, 0), true);
            }
            else if ( StringUtil.StrCmp(AV56STSMode, "gettoken") == 0 )
            {
               divTablestsserverchecktoken_Visible = 0;
               AssignProp("", false, divTablestsserverchecktoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsserverchecktoken_Visible), 5, 0), true);
               divTablestsclientgettoken_Visible = 1;
               AssignProp("", false, divTablestsclientgettoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsclientgettoken_Visible), 5, 0), true);
               divTablestsclient_Visible = 1;
               AssignProp("", false, divTablestsclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsclient_Visible), 5, 0), true);
            }
            else if ( StringUtil.StrCmp(AV56STSMode, "checktoken") == 0 )
            {
               divTablestsserverchecktoken_Visible = 1;
               AssignProp("", false, divTablestsserverchecktoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsserverchecktoken_Visible), 5, 0), true);
               divTablestsclientgettoken_Visible = 0;
               AssignProp("", false, divTablestsclientgettoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsclientgettoken_Visible), 5, 0), true);
               divTablestsclient_Visible = 1;
               AssignProp("", false, divTablestsclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsclient_Visible), 5, 0), true);
            }
            else if ( StringUtil.StrCmp(AV56STSMode, "fulltoken") == 0 )
            {
               divTablestsserverchecktoken_Visible = 1;
               AssignProp("", false, divTablestsserverchecktoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsserverchecktoken_Visible), 5, 0), true);
               divTablestsclientgettoken_Visible = 1;
               AssignProp("", false, divTablestsclientgettoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsclientgettoken_Visible), 5, 0), true);
               divTablestsclient_Visible = 1;
               AssignProp("", false, divTablestsclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablestsclient_Visible), 5, 0), true);
            }
         }
         else
         {
            divTablests_Visible = 0;
            AssignProp("", false, divTablests_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablests_Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'UI_MINIAPP' Routine */
         returnInSub = false;
         if ( AV148MiniAppEnable )
         {
            divTblminiapp_Visible = 1;
            AssignProp("", false, divTblminiapp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblminiapp_Visible), 5, 0), true);
            /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEMINIAPP' */
            S242 ();
            if (returnInSub) return;
            divTblminiappserver_Visible = 0;
            AssignProp("", false, divTblminiappserver_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblminiappserver_Visible), 5, 0), true);
            divTblminiappclient_Visible = 0;
            AssignProp("", false, divTblminiappclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblminiappclient_Visible), 5, 0), true);
            if ( StringUtil.StrCmp(AV149MiniAppMode, "server") == 0 )
            {
               divTblminiappserver_Visible = 1;
               AssignProp("", false, divTblminiappserver_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblminiappserver_Visible), 5, 0), true);
            }
            else if ( StringUtil.StrCmp(AV149MiniAppMode, "client") == 0 )
            {
               divTblminiappclient_Visible = 1;
               AssignProp("", false, divTblminiappclient_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblminiappclient_Visible), 5, 0), true);
            }
         }
         else
         {
            divTblminiapp_Visible = 0;
            AssignProp("", false, divTblminiapp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblminiapp_Visible), 5, 0), true);
         }
      }

      protected void S182( )
      {
         /* 'UI_APIKEY' Routine */
         returnInSub = false;
         if ( AV120APIKeyEnable )
         {
            divTblapikey_Visible = 1;
            AssignProp("", false, divTblapikey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblapikey_Visible), 5, 0), true);
            /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEAPIKEY' */
            S252 ();
            if (returnInSub) return;
         }
         else
         {
            divTblapikey_Visible = 0;
            AssignProp("", false, divTblapikey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblapikey_Visible), 5, 0), true);
         }
      }

      protected void S232( )
      {
         /* 'GETLISTAUTHENTICATIONTYPESSOREST' Routine */
         returnInSub = false;
         AV136GAMAuthenticationTypeFilter = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter(context);
         AV136GAMAuthenticationTypeFilter.gxTpr_Canusersbedefined = "T";
         AV167GXV6 = 1;
         AV166GXV5 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getauthenticationtypes(AV136GAMAuthenticationTypeFilter, out  AV116GAMErrorCollection);
         while ( AV167GXV6 <= AV166GXV5.Count )
         {
            AV122AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType)AV166GXV5.Item(AV167GXV6));
            AV167GXV6 = (int)(AV167GXV6+1);
         }
      }

      protected void S242( )
      {
         /* 'GETLISTAUTHENTICATIONTYPEMINIAPP' Routine */
         returnInSub = false;
         AV136GAMAuthenticationTypeFilter = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter(context);
         AV136GAMAuthenticationTypeFilter.gxTpr_Canusersbedefined = "T";
         AV169GXV8 = 1;
         AV168GXV7 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getauthenticationtypes(AV136GAMAuthenticationTypeFilter, out  AV116GAMErrorCollection);
         while ( AV169GXV8 <= AV168GXV7.Count )
         {
            AV122AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType)AV168GXV7.Item(AV169GXV8));
            cmbavMiniappuserauthenticationtypename.addItem(AV122AuthenticationType.gxTpr_Name, AV122AuthenticationType.gxTpr_Name, 0);
            AV169GXV8 = (int)(AV169GXV8+1);
         }
      }

      protected void S252( )
      {
         /* 'GETLISTAUTHENTICATIONTYPEAPIKEY' Routine */
         returnInSub = false;
         AV136GAMAuthenticationTypeFilter = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter(context);
         AV136GAMAuthenticationTypeFilter.gxTpr_Type = "APIkey";
         AV171GXV10 = 1;
         AV170GXV9 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getauthenticationtypes(AV136GAMAuthenticationTypeFilter, out  AV116GAMErrorCollection);
         while ( AV171GXV10 <= AV170GXV9.Count )
         {
            AV122AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType)AV170GXV9.Item(AV171GXV10));
            cmbavApikeyallowonlyauthenticationtypename.addItem(AV122AuthenticationType.gxTpr_Name, AV122AuthenticationType.gxTpr_Name, 0);
            AV171GXV10 = (int)(AV171GXV10+1);
         }
      }

      protected void S202( )
      {
         /* 'LOADLANGUAGES' Routine */
         returnInSub = false;
         AV138GAMLanguages = new GeneXus.Programs.genexussecurity.SdtGAM(context).getlanguages(AV135GAMApplication.gxTpr_Languages);
         AV172GXV11 = 1;
         while ( AV172GXV11 <= AV138GAMLanguages.Count )
         {
            AV137GAMLanguage = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage)AV138GAMLanguages.Item(AV172GXV11));
            AV154Online = AV137GAMLanguage.gxTpr_Online;
            AssignAttri("", false, chkavOnline_Internalname, AV154Online);
            AV144Language = AV137GAMLanguage.gxTpr_Name;
            AssignAttri("", false, edtavLanguage_Internalname, AV144Language);
            GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE"+"_"+sGXsfl_567_idx, GetSecureSignedToken( sGXsfl_567_idx, StringUtil.RTrim( context.localUtil.Format( AV144Language, "")), context));
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 567;
               }
               if ( ( subGridlanguages_Islastpage == 1 ) || ( subGridlanguages_Rows == 0 ) || ( ( GRIDLANGUAGES_nCurrentRecord >= GRIDLANGUAGES_nFirstRecordOnPage ) && ( GRIDLANGUAGES_nCurrentRecord < GRIDLANGUAGES_nFirstRecordOnPage + subGridlanguages_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_5672( ) ;
               }
               GRIDLANGUAGES_nEOF = (short)(((GRIDLANGUAGES_nCurrentRecord<GRIDLANGUAGES_nFirstRecordOnPage+subGridlanguages_fnc_Recordsperpage( )) ? 1 : 0));
               GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLANGUAGES_nEOF), 1, 0, ".", "")));
               GRIDLANGUAGES_nCurrentRecord = (long)(GRIDLANGUAGES_nCurrentRecord+1);
               subGridlanguages_Recordcount = (int)(GRIDLANGUAGES_nCurrentRecord);
               if ( isFullAjaxMode( ) && ! bGXsfl_567_Refreshing )
               {
                  DoAjaxLoad(567, GridlanguagesRow);
               }
            }
            else
            {
               if ( AV154Online )
               {
                  /* Load Method */
                  if ( wbStart != -1 )
                  {
                     wbStart = 567;
                  }
                  if ( ( subGridlanguages_Islastpage == 1 ) || ( subGridlanguages_Rows == 0 ) || ( ( GRIDLANGUAGES_nCurrentRecord >= GRIDLANGUAGES_nFirstRecordOnPage ) && ( GRIDLANGUAGES_nCurrentRecord < GRIDLANGUAGES_nFirstRecordOnPage + subGridlanguages_fnc_Recordsperpage( ) ) ) )
                  {
                     sendrow_5672( ) ;
                  }
                  GRIDLANGUAGES_nEOF = (short)(((GRIDLANGUAGES_nCurrentRecord<GRIDLANGUAGES_nFirstRecordOnPage+subGridlanguages_fnc_Recordsperpage( )) ? 1 : 0));
                  GxWebStd.gx_hidden_field( context, "GRIDLANGUAGES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLANGUAGES_nEOF), 1, 0, ".", "")));
                  GRIDLANGUAGES_nCurrentRecord = (long)(GRIDLANGUAGES_nCurrentRecord+1);
                  subGridlanguages_Recordcount = (int)(GRIDLANGUAGES_nCurrentRecord);
                  if ( isFullAjaxMode( ) && ! bGXsfl_567_Refreshing )
                  {
                     DoAjaxLoad(567, GridlanguagesRow);
                  }
               }
            }
            AV172GXV11 = (int)(AV172GXV11+1);
         }
      }

      protected void S222( )
      {
         /* 'SAVELANGUAGES' Routine */
         returnInSub = false;
         AV138GAMLanguages = new GeneXus.Programs.genexussecurity.SdtGAM(context).getlanguages(AV135GAMApplication.gxTpr_Languages);
         /* Start For Each Line */
         nRC_GXsfl_567 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_567"), ".", ","), 18, MidpointRounding.ToEven));
         nGXsfl_567_fel_idx = 0;
         while ( nGXsfl_567_fel_idx < nRC_GXsfl_567 )
         {
            nGXsfl_567_fel_idx = ((subGridlanguages_Islastpage==1)&&(nGXsfl_567_fel_idx+1>subGridlanguages_fnc_Recordsperpage( )) ? 1 : nGXsfl_567_fel_idx+1);
            sGXsfl_567_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_567_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_5672( ) ;
            AV154Online = StringUtil.StrToBool( cgiGet( chkavOnline_Internalname));
            AV144Language = cgiGet( edtavLanguage_Internalname);
            AV174GXV12 = 1;
            while ( AV174GXV12 <= AV138GAMLanguages.Count )
            {
               AV137GAMLanguage = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage)AV138GAMLanguages.Item(AV174GXV12));
               if ( StringUtil.StrCmp(AV137GAMLanguage.gxTpr_Name, AV144Language) == 0 )
               {
                  AV137GAMLanguage.gxTpr_Online = AV154Online;
               }
               AV174GXV12 = (int)(AV174GXV12+1);
            }
            /* End For Each Line */
         }
         if ( nGXsfl_567_fel_idx == 0 )
         {
            nGXsfl_567_idx = 1;
            sGXsfl_567_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_567_idx), 4, 0), 4, "0");
            SubsflControlProps_5672( ) ;
         }
         nGXsfl_567_fel_idx = 1;
         AV135GAMApplication.gxTpr_Languages = AV138GAMLanguages;
      }

      protected void wb_table3_274_0Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedclientencryptionkey_Internalname, tblTablemergedclientencryptionkey_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientencryptionkey_Internalname, "Client Encryption Key", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 278,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientencryptionkey_Internalname, StringUtil.RTrim( AV21ClientEncryptionKey), StringUtil.RTrim( context.localUtil.Format( AV21ClientEncryptionKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,278);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientencryptionkey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientencryptionkey_Enabled, 1, "text", "", 32, "chr", 1, "row", 32, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEncryptionKey", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 280,'',false,'',0)\"";
            ClassString = "Button ButtonMaterialGAM";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtngeneratekeygamremote_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(567), 3, 0)+","+"null"+");", "Generate key GAMRemote", bttBtngeneratekeygamremote_Jsonclick, 5, "Generate key GAMRemote", "", StyleString, ClassString, bttBtngeneratekeygamremote_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOGENERATEKEYGAMREMOTE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMApplicationEntry.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_274_0Y2e( true) ;
         }
         else
         {
            wb_table3_274_0Y2e( false) ;
         }
      }

      protected void wb_table2_126_0Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedclientsecret_Internalname, tblTablemergedclientsecret_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientsecret_Internalname, "Client Secret", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientsecret_Internalname, StringUtil.RTrim( AV27ClientSecret), StringUtil.RTrim( context.localUtil.Format( AV27ClientSecret, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientsecret_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavClientsecret_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMClientApplicationSecret", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
            ClassString = "Button ButtonMaterialGAM";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnchangeclientsecret_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(567), 3, 0)+","+"null"+");", "Change", bttBtnchangeclientsecret_Jsonclick, 7, "Change", "", StyleString, ClassString, bttBtnchangeclientsecret_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e300y1_client"+"'", TempTags, "", 2, "HLP_GAMApplicationEntry.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_126_0Y2e( true) ;
         }
         else
         {
            wb_table2_126_0Y2e( false) ;
         }
      }

      protected void wb_table1_92_0Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedlogoutobject_Internalname, tblTablemergedlogoutobject_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLogoutobject_Internalname, "Logout Object", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_567_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLogoutobject_Internalname, AV45LogoutObject, StringUtil.RTrim( context.localUtil.Format( AV45LogoutObject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLogoutobject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLogoutobject_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMApplicationEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "Button ButtonMaterialGAM";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrevokeallow_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(567), 3, 0)+","+"null"+");", bttBtnrevokeallow_Caption, bttBtnrevokeallow_Jsonclick, 5, "Revoke", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOREVOKEALLOW\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMApplicationEntry.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_92_0Y2e( true) ;
         }
         else
         {
            wb_table1_92_0Y2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV43Id = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV43Id", StringUtil.LTrimStr( (decimal)(AV43Id), 12, 0));
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
         PA0Y2( ) ;
         WS0Y2( ) ;
         WE0Y2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256275311052", true, true);
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
         context.AddJavascriptSource("gamapplicationentry.js", "?20256275311061", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_5672( )
      {
         chkavOnline_Internalname = "vONLINE_"+sGXsfl_567_idx;
         edtavLanguage_Internalname = "vLANGUAGE_"+sGXsfl_567_idx;
      }

      protected void SubsflControlProps_fel_5672( )
      {
         chkavOnline_Internalname = "vONLINE_"+sGXsfl_567_fel_idx;
         edtavLanguage_Internalname = "vLANGUAGE_"+sGXsfl_567_fel_idx;
      }

      protected void sendrow_5672( )
      {
         sGXsfl_567_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_567_idx), 4, 0), 4, "0");
         SubsflControlProps_5672( ) ;
         WB0Y0( ) ;
         if ( ( subGridlanguages_Rows * 1 == 0 ) || ( nGXsfl_567_idx <= subGridlanguages_fnc_Recordsperpage( ) * 1 ) )
         {
            GridlanguagesRow = GXWebRow.GetNew(context,GridlanguagesContainer);
            if ( subGridlanguages_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridlanguages_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridlanguages_Class, "") != 0 )
               {
                  subGridlanguages_Linesclass = subGridlanguages_Class+"Odd";
               }
            }
            else if ( subGridlanguages_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridlanguages_Backstyle = 0;
               subGridlanguages_Backcolor = subGridlanguages_Allbackcolor;
               if ( StringUtil.StrCmp(subGridlanguages_Class, "") != 0 )
               {
                  subGridlanguages_Linesclass = subGridlanguages_Class+"Uniform";
               }
            }
            else if ( subGridlanguages_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridlanguages_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridlanguages_Class, "") != 0 )
               {
                  subGridlanguages_Linesclass = subGridlanguages_Class+"Odd";
               }
               subGridlanguages_Backcolor = (int)(0x0);
            }
            else if ( subGridlanguages_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridlanguages_Backstyle = 1;
               if ( ((int)((nGXsfl_567_idx) % (2))) == 0 )
               {
                  subGridlanguages_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlanguages_Class, "") != 0 )
                  {
                     subGridlanguages_Linesclass = subGridlanguages_Class+"Even";
                  }
               }
               else
               {
                  subGridlanguages_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlanguages_Class, "") != 0 )
                  {
                     subGridlanguages_Linesclass = subGridlanguages_Class+"Odd";
                  }
               }
            }
            if ( GridlanguagesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_567_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridlanguagesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 568,'',false,'" + sGXsfl_567_idx + "',567)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vONLINE_" + sGXsfl_567_idx;
            chkavOnline.Name = GXCCtl;
            chkavOnline.WebTags = "";
            chkavOnline.Caption = "";
            AssignProp("", false, chkavOnline_Internalname, "TitleCaption", chkavOnline.Caption, !bGXsfl_567_Refreshing);
            chkavOnline.CheckedValue = "false";
            AV154Online = StringUtil.StrToBool( StringUtil.BoolToStr( AV154Online));
            AssignAttri("", false, chkavOnline_Internalname, AV154Online);
            GridlanguagesRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavOnline_Internalname,StringUtil.BoolToStr( AV154Online),(string)"",(string)"",(short)-1,chkavOnline.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(568, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,568);\""});
            /* Subfile cell */
            if ( GridlanguagesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 569,'',false,'" + sGXsfl_567_idx + "',567)\"";
            ROClassString = "Attribute";
            GridlanguagesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLanguage_Internalname,(string)AV144Language,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,569);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLanguage_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavLanguage_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)567,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes0Y2( ) ;
            GridlanguagesContainer.AddRow(GridlanguagesRow);
            nGXsfl_567_idx = ((subGridlanguages_Islastpage==1)&&(nGXsfl_567_idx+1>subGridlanguages_fnc_Recordsperpage( )) ? 1 : nGXsfl_567_idx+1);
            sGXsfl_567_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_567_idx), 4, 0), 4, "0");
            SubsflControlProps_5672( ) ;
         }
         /* End function sendrow_5672 */
      }

      protected void init_web_controls( )
      {
         chkavReturnmenuoptionswithoutpermission.Name = "vRETURNMENUOPTIONSWITHOUTPERMISSION";
         chkavReturnmenuoptionswithoutpermission.WebTags = "";
         chkavReturnmenuoptionswithoutpermission.Caption = " ";
         AssignProp("", false, chkavReturnmenuoptionswithoutpermission_Internalname, "TitleCaption", chkavReturnmenuoptionswithoutpermission.Caption, true);
         chkavReturnmenuoptionswithoutpermission.CheckedValue = "false";
         AV156ReturnMenuOptionsWithoutPermission = StringUtil.StrToBool( StringUtil.BoolToStr( AV156ReturnMenuOptionsWithoutPermission));
         AssignAttri("", false, "AV156ReturnMenuOptionsWithoutPermission", AV156ReturnMenuOptionsWithoutPermission);
         cmbavMainmenu.Name = "vMAINMENU";
         cmbavMainmenu.WebTags = "";
         if ( cmbavMainmenu.ItemCount > 0 )
         {
            AV46MainMenu = (long)(Math.Round(NumberUtil.Val( cmbavMainmenu.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV46MainMenu), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV46MainMenu", StringUtil.LTrimStr( (decimal)(AV46MainMenu), 12, 0));
         }
         chkavUseabsoluteurlbyenvironment.Name = "vUSEABSOLUTEURLBYENVIRONMENT";
         chkavUseabsoluteurlbyenvironment.WebTags = "";
         chkavUseabsoluteurlbyenvironment.Caption = " ";
         AssignProp("", false, chkavUseabsoluteurlbyenvironment_Internalname, "TitleCaption", chkavUseabsoluteurlbyenvironment.Caption, true);
         chkavUseabsoluteurlbyenvironment.CheckedValue = "false";
         AV61UseAbsoluteUrlByEnvironment = StringUtil.StrToBool( StringUtil.BoolToStr( AV61UseAbsoluteUrlByEnvironment));
         AssignAttri("", false, "AV61UseAbsoluteUrlByEnvironment", AV61UseAbsoluteUrlByEnvironment);
         cmbavClientaccessstatus.Name = "vCLIENTACCESSSTATUS";
         cmbavClientaccessstatus.WebTags = "";
         cmbavClientaccessstatus.addItem("on", "Online", 0);
         cmbavClientaccessstatus.addItem("off", "Offline", 0);
         if ( cmbavClientaccessstatus.ItemCount > 0 )
         {
            AV123ClientAccessStatus = cmbavClientaccessstatus.getValidValue(AV123ClientAccessStatus);
            AssignAttri("", false, "AV123ClientAccessStatus", AV123ClientAccessStatus);
         }
         chkavClientauthrequestmustincludeuserscopes.Name = "vCLIENTAUTHREQUESTMUSTINCLUDEUSERSCOPES";
         chkavClientauthrequestmustincludeuserscopes.WebTags = "";
         chkavClientauthrequestmustincludeuserscopes.Caption = " ";
         AssignProp("", false, chkavClientauthrequestmustincludeuserscopes_Internalname, "TitleCaption", chkavClientauthrequestmustincludeuserscopes.Caption, true);
         chkavClientauthrequestmustincludeuserscopes.CheckedValue = "false";
         AV128ClientAuthRequestMustIncludeUserScopes = StringUtil.StrToBool( StringUtil.BoolToStr( AV128ClientAuthRequestMustIncludeUserScopes));
         AssignAttri("", false, "AV128ClientAuthRequestMustIncludeUserScopes", AV128ClientAuthRequestMustIncludeUserScopes);
         chkavClientdonotshareuserids.Name = "vCLIENTDONOTSHAREUSERIDS";
         chkavClientdonotshareuserids.WebTags = "";
         chkavClientdonotshareuserids.Caption = " ";
         AssignProp("", false, chkavClientdonotshareuserids_Internalname, "TitleCaption", chkavClientdonotshareuserids.Caption, true);
         chkavClientdonotshareuserids.CheckedValue = "false";
         AV129ClientDoNotShareUserIDs = StringUtil.StrToBool( StringUtil.BoolToStr( AV129ClientDoNotShareUserIDs));
         AssignAttri("", false, "AV129ClientDoNotShareUserIDs", AV129ClientDoNotShareUserIDs);
         chkavClientallowremoteauth.Name = "vCLIENTALLOWREMOTEAUTH";
         chkavClientallowremoteauth.WebTags = "";
         chkavClientallowremoteauth.Caption = " ";
         AssignProp("", false, chkavClientallowremoteauth_Internalname, "TitleCaption", chkavClientallowremoteauth.Caption, true);
         chkavClientallowremoteauth.CheckedValue = "false";
         AV17ClientAllowRemoteAuth = StringUtil.StrToBool( StringUtil.BoolToStr( AV17ClientAllowRemoteAuth));
         AssignAttri("", false, "AV17ClientAllowRemoteAuth", AV17ClientAllowRemoteAuth);
         chkavClientallowgetuserdata.Name = "vCLIENTALLOWGETUSERDATA";
         chkavClientallowgetuserdata.WebTags = "";
         chkavClientallowgetuserdata.Caption = " ";
         AssignProp("", false, chkavClientallowgetuserdata_Internalname, "TitleCaption", chkavClientallowgetuserdata.Caption, true);
         chkavClientallowgetuserdata.CheckedValue = "false";
         AV126ClientAllowGetUserData = StringUtil.StrToBool( StringUtil.BoolToStr( AV126ClientAllowGetUserData));
         AssignAttri("", false, "AV126ClientAllowGetUserData", AV126ClientAllowGetUserData);
         chkavClientallowgetuseradddata.Name = "vCLIENTALLOWGETUSERADDDATA";
         chkavClientallowgetuseradddata.WebTags = "";
         chkavClientallowgetuseradddata.Caption = " ";
         AssignProp("", false, chkavClientallowgetuseradddata_Internalname, "TitleCaption", chkavClientallowgetuseradddata.Caption, true);
         chkavClientallowgetuseradddata.CheckedValue = "false";
         AV13ClientAllowGetUserAddData = StringUtil.StrToBool( StringUtil.BoolToStr( AV13ClientAllowGetUserAddData));
         AssignAttri("", false, "AV13ClientAllowGetUserAddData", AV13ClientAllowGetUserAddData);
         chkavClientallowgetuserroles.Name = "vCLIENTALLOWGETUSERROLES";
         chkavClientallowgetuserroles.WebTags = "";
         chkavClientallowgetuserroles.Caption = " ";
         AssignProp("", false, chkavClientallowgetuserroles_Internalname, "TitleCaption", chkavClientallowgetuserroles.Caption, true);
         chkavClientallowgetuserroles.CheckedValue = "false";
         AV15ClientAllowGetUserRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV15ClientAllowGetUserRoles));
         AssignAttri("", false, "AV15ClientAllowGetUserRoles", AV15ClientAllowGetUserRoles);
         chkavClientallowgetsessioniniprop.Name = "vCLIENTALLOWGETSESSIONINIPROP";
         chkavClientallowgetsessioniniprop.WebTags = "";
         chkavClientallowgetsessioniniprop.Caption = " ";
         AssignProp("", false, chkavClientallowgetsessioniniprop_Internalname, "TitleCaption", chkavClientallowgetsessioniniprop.Caption, true);
         chkavClientallowgetsessioniniprop.CheckedValue = "false";
         AV11ClientAllowGetSessionIniProp = StringUtil.StrToBool( StringUtil.BoolToStr( AV11ClientAllowGetSessionIniProp));
         AssignAttri("", false, "AV11ClientAllowGetSessionIniProp", AV11ClientAllowGetSessionIniProp);
         chkavClientallowgetsessionappdata.Name = "vCLIENTALLOWGETSESSIONAPPDATA";
         chkavClientallowgetsessionappdata.WebTags = "";
         chkavClientallowgetsessionappdata.Caption = " ";
         AssignProp("", false, chkavClientallowgetsessionappdata_Internalname, "TitleCaption", chkavClientallowgetsessionappdata.Caption, true);
         chkavClientallowgetsessionappdata.CheckedValue = "false";
         AV9ClientAllowGetSessionAppData = StringUtil.StrToBool( StringUtil.BoolToStr( AV9ClientAllowGetSessionAppData));
         AssignAttri("", false, "AV9ClientAllowGetSessionAppData", AV9ClientAllowGetSessionAppData);
         chkavClientcallbackurliscustom.Name = "vCLIENTCALLBACKURLISCUSTOM";
         chkavClientcallbackurliscustom.WebTags = "";
         chkavClientcallbackurliscustom.Caption = " ";
         AssignProp("", false, chkavClientcallbackurliscustom_Internalname, "TitleCaption", chkavClientcallbackurliscustom.Caption, true);
         chkavClientcallbackurliscustom.CheckedValue = "false";
         AV20ClientCallbackURLisCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV20ClientCallbackURLisCustom));
         AssignAttri("", false, "AV20ClientCallbackURLisCustom", AV20ClientCallbackURLisCustom);
         chkavClientallowremoterestauth.Name = "vCLIENTALLOWREMOTERESTAUTH";
         chkavClientallowremoterestauth.WebTags = "";
         chkavClientallowremoterestauth.Caption = " ";
         AssignProp("", false, chkavClientallowremoterestauth_Internalname, "TitleCaption", chkavClientallowremoterestauth.Caption, true);
         chkavClientallowremoterestauth.CheckedValue = "false";
         AV18ClientAllowRemoteRestAuth = StringUtil.StrToBool( StringUtil.BoolToStr( AV18ClientAllowRemoteRestAuth));
         AssignAttri("", false, "AV18ClientAllowRemoteRestAuth", AV18ClientAllowRemoteRestAuth);
         chkavClientallowgetuserdatarest.Name = "vCLIENTALLOWGETUSERDATAREST";
         chkavClientallowgetuserdatarest.WebTags = "";
         chkavClientallowgetuserdatarest.Caption = " ";
         AssignProp("", false, chkavClientallowgetuserdatarest_Internalname, "TitleCaption", chkavClientallowgetuserdatarest.Caption, true);
         chkavClientallowgetuserdatarest.CheckedValue = "false";
         AV127ClientAllowGetUserDataREST = StringUtil.StrToBool( StringUtil.BoolToStr( AV127ClientAllowGetUserDataREST));
         AssignAttri("", false, "AV127ClientAllowGetUserDataREST", AV127ClientAllowGetUserDataREST);
         chkavClientallowgetuseradddatarest.Name = "vCLIENTALLOWGETUSERADDDATAREST";
         chkavClientallowgetuseradddatarest.WebTags = "";
         chkavClientallowgetuseradddatarest.Caption = " ";
         AssignProp("", false, chkavClientallowgetuseradddatarest_Internalname, "TitleCaption", chkavClientallowgetuseradddatarest.Caption, true);
         chkavClientallowgetuseradddatarest.CheckedValue = "false";
         AV14ClientAllowGetUserAddDataRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV14ClientAllowGetUserAddDataRest));
         AssignAttri("", false, "AV14ClientAllowGetUserAddDataRest", AV14ClientAllowGetUserAddDataRest);
         chkavClientallowgetuserrolesrest.Name = "vCLIENTALLOWGETUSERROLESREST";
         chkavClientallowgetuserrolesrest.WebTags = "";
         chkavClientallowgetuserrolesrest.Caption = " ";
         AssignProp("", false, chkavClientallowgetuserrolesrest_Internalname, "TitleCaption", chkavClientallowgetuserrolesrest.Caption, true);
         chkavClientallowgetuserrolesrest.CheckedValue = "false";
         AV16ClientAllowGetUserRolesRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV16ClientAllowGetUserRolesRest));
         AssignAttri("", false, "AV16ClientAllowGetUserRolesRest", AV16ClientAllowGetUserRolesRest);
         chkavClientallowgetsessioniniproprest.Name = "vCLIENTALLOWGETSESSIONINIPROPREST";
         chkavClientallowgetsessioniniproprest.WebTags = "";
         chkavClientallowgetsessioniniproprest.Caption = " ";
         AssignProp("", false, chkavClientallowgetsessioniniproprest_Internalname, "TitleCaption", chkavClientallowgetsessioniniproprest.Caption, true);
         chkavClientallowgetsessioniniproprest.CheckedValue = "false";
         AV12ClientAllowGetSessionIniPropRest = StringUtil.StrToBool( StringUtil.BoolToStr( AV12ClientAllowGetSessionIniPropRest));
         AssignAttri("", false, "AV12ClientAllowGetSessionIniPropRest", AV12ClientAllowGetSessionIniPropRest);
         chkavClientallowgetsessionappdatarest.Name = "vCLIENTALLOWGETSESSIONAPPDATAREST";
         chkavClientallowgetsessionappdatarest.WebTags = "";
         chkavClientallowgetsessionappdatarest.Caption = " ";
         AssignProp("", false, chkavClientallowgetsessionappdatarest_Internalname, "TitleCaption", chkavClientallowgetsessionappdatarest.Caption, true);
         chkavClientallowgetsessionappdatarest.CheckedValue = "false";
         AV10ClientAllowGetSessionAppDataREST = StringUtil.StrToBool( StringUtil.BoolToStr( AV10ClientAllowGetSessionAppDataREST));
         AssignAttri("", false, "AV10ClientAllowGetSessionAppDataREST", AV10ClientAllowGetSessionAppDataREST);
         chkavClientaccessuniquebyuser.Name = "vCLIENTACCESSUNIQUEBYUSER";
         chkavClientaccessuniquebyuser.WebTags = "";
         chkavClientaccessuniquebyuser.Caption = " ";
         AssignProp("", false, chkavClientaccessuniquebyuser_Internalname, "TitleCaption", chkavClientaccessuniquebyuser.Caption, true);
         chkavClientaccessuniquebyuser.CheckedValue = "false";
         AV8ClientAccessUniqueByUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV8ClientAccessUniqueByUser));
         AssignAttri("", false, "AV8ClientAccessUniqueByUser", AV8ClientAccessUniqueByUser);
         chkavAccessrequirespermission.Name = "vACCESSREQUIRESPERMISSION";
         chkavAccessrequirespermission.WebTags = "";
         chkavAccessrequirespermission.Caption = "Enable Authorization?";
         AssignProp("", false, chkavAccessrequirespermission_Internalname, "TitleCaption", chkavAccessrequirespermission.Caption, true);
         chkavAccessrequirespermission.CheckedValue = "false";
         AV5AccessRequiresPermission = StringUtil.StrToBool( StringUtil.BoolToStr( AV5AccessRequiresPermission));
         AssignAttri("", false, "AV5AccessRequiresPermission", AV5AccessRequiresPermission);
         chkavIsauthorizationdelegated.Name = "vISAUTHORIZATIONDELEGATED";
         chkavIsauthorizationdelegated.WebTags = "";
         chkavIsauthorizationdelegated.Caption = "Delegate authorization checking to an external program?";
         AssignProp("", false, chkavIsauthorizationdelegated_Internalname, "TitleCaption", chkavIsauthorizationdelegated.Caption, true);
         chkavIsauthorizationdelegated.CheckedValue = "false";
         AV143IsAuthorizationDelegated = StringUtil.StrToBool( StringUtil.BoolToStr( AV143IsAuthorizationDelegated));
         AssignAttri("", false, "AV143IsAuthorizationDelegated", AV143IsAuthorizationDelegated);
         cmbavDelegateauthorizationversion.Name = "vDELEGATEAUTHORIZATIONVERSION";
         cmbavDelegateauthorizationversion.WebTags = "";
         cmbavDelegateauthorizationversion.addItem("10", "Version 1.0", 0);
         if ( cmbavDelegateauthorizationversion.ItemCount > 0 )
         {
            AV134DelegateAuthorizationVersion = cmbavDelegateauthorizationversion.getValidValue(AV134DelegateAuthorizationVersion);
            AssignAttri("", false, "AV134DelegateAuthorizationVersion", AV134DelegateAuthorizationVersion);
         }
         chkavSsorestenable.Name = "vSSORESTENABLE";
         chkavSsorestenable.WebTags = "";
         chkavSsorestenable.Caption = " ";
         AssignProp("", false, chkavSsorestenable_Internalname, "TitleCaption", chkavSsorestenable.Caption, true);
         chkavSsorestenable.CheckedValue = "false";
         AV50SSORestEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV50SSORestEnable));
         AssignAttri("", false, "AV50SSORestEnable", AV50SSORestEnable);
         cmbavSsorestmode.Name = "vSSORESTMODE";
         cmbavSsorestmode.WebTags = "";
         cmbavSsorestmode.addItem("server", "Server", 0);
         cmbavSsorestmode.addItem("client", "Client", 0);
         if ( cmbavSsorestmode.ItemCount > 0 )
         {
            AV51SSORestMode = cmbavSsorestmode.getValidValue(AV51SSORestMode);
            AssignAttri("", false, "AV51SSORestMode", AV51SSORestMode);
         }
         chkavSsorestserverurl_iscustom.Name = "vSSORESTSERVERURL_ISCUSTOM";
         chkavSsorestserverurl_iscustom.WebTags = "";
         chkavSsorestserverurl_iscustom.Caption = "Custom server URL SSO";
         AssignProp("", false, chkavSsorestserverurl_iscustom_Internalname, "TitleCaption", chkavSsorestserverurl_iscustom.Caption, true);
         chkavSsorestserverurl_iscustom.CheckedValue = "false";
         AV159SSORestServerURL_isCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV159SSORestServerURL_isCustom));
         AssignAttri("", false, "AV159SSORestServerURL_isCustom", AV159SSORestServerURL_isCustom);
         chkavStsprotocolenable.Name = "vSTSPROTOCOLENABLE";
         chkavStsprotocolenable.WebTags = "";
         chkavStsprotocolenable.Caption = " ";
         AssignProp("", false, chkavStsprotocolenable_Internalname, "TitleCaption", chkavStsprotocolenable.Caption, true);
         chkavStsprotocolenable.CheckedValue = "false";
         AV57STSProtocolEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV57STSProtocolEnable));
         AssignAttri("", false, "AV57STSProtocolEnable", AV57STSProtocolEnable);
         cmbavStsmode.Name = "vSTSMODE";
         cmbavStsmode.WebTags = "";
         cmbavStsmode.addItem("server", "Server", 0);
         cmbavStsmode.addItem("gettoken", "Get token", 0);
         cmbavStsmode.addItem("checktoken", "Check token", 0);
         cmbavStsmode.addItem("fulltoken", "Get and check token", 0);
         if ( cmbavStsmode.ItemCount > 0 )
         {
            AV56STSMode = cmbavStsmode.getValidValue(AV56STSMode);
            AssignAttri("", false, "AV56STSMode", AV56STSMode);
         }
         chkavMiniappenable.Name = "vMINIAPPENABLE";
         chkavMiniappenable.WebTags = "";
         chkavMiniappenable.Caption = "Enable work as MiniApp?";
         AssignProp("", false, chkavMiniappenable_Internalname, "TitleCaption", chkavMiniappenable.Caption, true);
         chkavMiniappenable.CheckedValue = "false";
         AV148MiniAppEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV148MiniAppEnable));
         AssignAttri("", false, "AV148MiniAppEnable", AV148MiniAppEnable);
         cmbavMiniappmode.Name = "vMINIAPPMODE";
         cmbavMiniappmode.WebTags = "";
         cmbavMiniappmode.addItem("server", "Server", 0);
         cmbavMiniappmode.addItem("client", "Client", 0);
         if ( cmbavMiniappmode.ItemCount > 0 )
         {
            AV149MiniAppMode = cmbavMiniappmode.getValidValue(AV149MiniAppMode);
            AssignAttri("", false, "AV149MiniAppMode", AV149MiniAppMode);
         }
         chkavMiniappclienturl_iscustom.Name = "vMINIAPPCLIENTURL_ISCUSTOM";
         chkavMiniappclienturl_iscustom.WebTags = "";
         chkavMiniappclienturl_iscustom.Caption = "Custom MiniApp client URL";
         AssignProp("", false, chkavMiniappclienturl_iscustom_Internalname, "TitleCaption", chkavMiniappclienturl_iscustom.Caption, true);
         chkavMiniappclienturl_iscustom.CheckedValue = "false";
         AV147MiniAppClientURL_isCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV147MiniAppClientURL_isCustom));
         AssignAttri("", false, "AV147MiniAppClientURL_isCustom", AV147MiniAppClientURL_isCustom);
         cmbavMiniappuserauthenticationtypename.Name = "vMINIAPPUSERAUTHENTICATIONTYPENAME";
         cmbavMiniappuserauthenticationtypename.WebTags = "";
         cmbavMiniappuserauthenticationtypename.addItem("", "(Select)", 0);
         if ( cmbavMiniappuserauthenticationtypename.ItemCount > 0 )
         {
            AV153MiniAppUserAuthenticationTypeName = cmbavMiniappuserauthenticationtypename.getValidValue(AV153MiniAppUserAuthenticationTypeName);
            AssignAttri("", false, "AV153MiniAppUserAuthenticationTypeName", AV153MiniAppUserAuthenticationTypeName);
         }
         chkavMiniappserverurl_iscustom.Name = "vMINIAPPSERVERURL_ISCUSTOM";
         chkavMiniappserverurl_iscustom.WebTags = "";
         chkavMiniappserverurl_iscustom.Caption = "Custom SuperApp server URL";
         AssignProp("", false, chkavMiniappserverurl_iscustom_Internalname, "TitleCaption", chkavMiniappserverurl_iscustom.Caption, true);
         chkavMiniappserverurl_iscustom.CheckedValue = "false";
         AV152MiniAppServerURL_isCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV152MiniAppServerURL_isCustom));
         AssignAttri("", false, "AV152MiniAppServerURL_isCustom", AV152MiniAppServerURL_isCustom);
         chkavApikeyenable.Name = "vAPIKEYENABLE";
         chkavApikeyenable.WebTags = "";
         chkavApikeyenable.Caption = "Enable work with API keys";
         AssignProp("", false, chkavApikeyenable_Internalname, "TitleCaption", chkavApikeyenable.Caption, true);
         chkavApikeyenable.CheckedValue = "false";
         AV120APIKeyEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV120APIKeyEnable));
         AssignAttri("", false, "AV120APIKeyEnable", AV120APIKeyEnable);
         cmbavApikeyallowonlyauthenticationtypename.Name = "vAPIKEYALLOWONLYAUTHENTICATIONTYPENAME";
         cmbavApikeyallowonlyauthenticationtypename.WebTags = "";
         cmbavApikeyallowonlyauthenticationtypename.addItem("", "(All)", 0);
         if ( cmbavApikeyallowonlyauthenticationtypename.ItemCount > 0 )
         {
            AV118APIKeyAllowOnlyAuthenticationTypeName = cmbavApikeyallowonlyauthenticationtypename.getValidValue(AV118APIKeyAllowOnlyAuthenticationTypeName);
            AssignAttri("", false, "AV118APIKeyAllowOnlyAuthenticationTypeName", AV118APIKeyAllowOnlyAuthenticationTypeName);
         }
         chkavApikeyallowscopecustomization.Name = "vAPIKEYALLOWSCOPECUSTOMIZATION";
         chkavApikeyallowscopecustomization.WebTags = "";
         chkavApikeyallowscopecustomization.Caption = "API Key Allow Scope Customization";
         AssignProp("", false, chkavApikeyallowscopecustomization_Internalname, "TitleCaption", chkavApikeyallowscopecustomization.Caption, true);
         chkavApikeyallowscopecustomization.CheckedValue = "false";
         AV119APIKeyAllowScopeCustomization = StringUtil.StrToBool( StringUtil.BoolToStr( AV119APIKeyAllowScopeCustomization));
         AssignAttri("", false, "AV119APIKeyAllowScopeCustomization", AV119APIKeyAllowScopeCustomization);
         chkavEnvironmentsecureprotocol.Name = "vENVIRONMENTSECUREPROTOCOL";
         chkavEnvironmentsecureprotocol.WebTags = "";
         chkavEnvironmentsecureprotocol.Caption = " ";
         AssignProp("", false, chkavEnvironmentsecureprotocol_Internalname, "TitleCaption", chkavEnvironmentsecureprotocol.Caption, true);
         chkavEnvironmentsecureprotocol.CheckedValue = "false";
         AV36EnvironmentSecureProtocol = StringUtil.StrToBool( StringUtil.BoolToStr( AV36EnvironmentSecureProtocol));
         AssignAttri("", false, "AV36EnvironmentSecureProtocol", AV36EnvironmentSecureProtocol);
         GXCCtl = "vONLINE_" + sGXsfl_567_idx;
         chkavOnline.Name = GXCCtl;
         chkavOnline.WebTags = "";
         chkavOnline.Caption = "";
         AssignProp("", false, chkavOnline_Internalname, "TitleCaption", chkavOnline.Caption, !bGXsfl_567_Refreshing);
         chkavOnline.CheckedValue = "false";
         AV154Online = StringUtil.StrToBool( StringUtil.BoolToStr( AV154Online));
         AssignAttri("", false, chkavOnline_Internalname, AV154Online);
         chkavAutoregisteranomymoususer.Name = "vAUTOREGISTERANOMYMOUSUSER";
         chkavAutoregisteranomymoususer.WebTags = "";
         chkavAutoregisteranomymoususer.Caption = "";
         AssignProp("", false, chkavAutoregisteranomymoususer_Internalname, "TitleCaption", chkavAutoregisteranomymoususer.Caption, true);
         chkavAutoregisteranomymoususer.CheckedValue = "false";
         AV7AutoRegisterAnomymousUser = StringUtil.StrToBool( StringUtil.BoolToStr( AV7AutoRegisterAnomymousUser));
         AssignAttri("", false, "AV7AutoRegisterAnomymousUser", AV7AutoRegisterAnomymousUser);
         /* End function init_web_controls */
      }

      protected void StartGridControl567( )
      {
         if ( GridlanguagesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridlanguagesContainer"+"DivS\" data-gxgridid=\"567\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridlanguages_Internalname, subGridlanguages_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridlanguages_Backcolorstyle == 0 )
            {
               subGridlanguages_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridlanguages_Class) > 0 )
               {
                  subGridlanguages_Linesclass = subGridlanguages_Class+"Title";
               }
            }
            else
            {
               subGridlanguages_Titlebackstyle = 1;
               if ( subGridlanguages_Backcolorstyle == 1 )
               {
                  subGridlanguages_Titlebackcolor = subGridlanguages_Allbackcolor;
                  if ( StringUtil.Len( subGridlanguages_Class) > 0 )
                  {
                     subGridlanguages_Linesclass = subGridlanguages_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridlanguages_Class) > 0 )
                  {
                     subGridlanguages_Linesclass = subGridlanguages_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Online") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Languages") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridlanguagesContainer.AddObjectProperty("GridName", "Gridlanguages");
         }
         else
         {
            GridlanguagesContainer.AddObjectProperty("GridName", "Gridlanguages");
            GridlanguagesContainer.AddObjectProperty("Header", subGridlanguages_Header);
            GridlanguagesContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridlanguagesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridlanguagesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridlanguagesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Backcolorstyle), 1, 0, ".", "")));
            GridlanguagesContainer.AddObjectProperty("CmpContext", "");
            GridlanguagesContainer.AddObjectProperty("InMasterPage", "false");
            GridlanguagesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridlanguagesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV154Online)));
            GridlanguagesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavOnline.Enabled), 5, 0, ".", "")));
            GridlanguagesContainer.AddColumnProperties(GridlanguagesColumn);
            GridlanguagesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridlanguagesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV144Language));
            GridlanguagesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLanguage_Enabled), 5, 0, ".", "")));
            GridlanguagesContainer.AddColumnProperties(GridlanguagesColumn);
            GridlanguagesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Selectedindex), 4, 0, ".", "")));
            GridlanguagesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Allowselection), 1, 0, ".", "")));
            GridlanguagesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Selectioncolor), 9, 0, ".", "")));
            GridlanguagesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Allowhovering), 1, 0, ".", "")));
            GridlanguagesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Hoveringcolor), 9, 0, ".", "")));
            GridlanguagesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Allowcollapsing), 1, 0, ".", "")));
            GridlanguagesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlanguages_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         lblGeneral_title_Internalname = "GENERAL_TITLE";
         edtavId_Internalname = "vID";
         edtavGuid_Internalname = "vGUID";
         edtavName_Internalname = "vNAME";
         edtavDsc_Internalname = "vDSC";
         edtavVersion_Internalname = "vVERSION";
         edtavCompany_Internalname = "vCOMPANY";
         edtavCopyright_Internalname = "vCOPYRIGHT";
         chkavReturnmenuoptionswithoutpermission_Internalname = "vRETURNMENUOPTIONSWITHOUTPERMISSION";
         cmbavMainmenu_Internalname = "vMAINMENU";
         chkavUseabsoluteurlbyenvironment_Internalname = "vUSEABSOLUTEURLBYENVIRONMENT";
         edtavHomeobject_Internalname = "vHOMEOBJECT";
         edtavAccountactivationobject_Internalname = "vACCOUNTACTIVATIONOBJECT";
         lblTextblocklogoutobject_Internalname = "TEXTBLOCKLOGOUTOBJECT";
         edtavLogoutobject_Internalname = "vLOGOUTOBJECT";
         bttBtnrevokeallow_Internalname = "BTNREVOKEALLOW";
         tblTablemergedlogoutobject_Internalname = "TABLEMERGEDLOGOUTOBJECT";
         divTablesplittedlogoutobject_Internalname = "TABLESPLITTEDLOGOUTOBJECT";
         divUnnamedtable9_Internalname = "UNNAMEDTABLE9";
         lblRemoteauthentication_title_Internalname = "REMOTEAUTHENTICATION_TITLE";
         cmbavClientaccessstatus_Internalname = "vCLIENTACCESSSTATUS";
         edtavClientrevoked_Internalname = "vCLIENTREVOKED";
         edtavClientid_Internalname = "vCLIENTID";
         lblTextblockclientsecret_Internalname = "TEXTBLOCKCLIENTSECRET";
         edtavClientsecret_Internalname = "vCLIENTSECRET";
         bttBtnchangeclientsecret_Internalname = "BTNCHANGECLIENTSECRET";
         tblTablemergedclientsecret_Internalname = "TABLEMERGEDCLIENTSECRET";
         divTablesplittedclientsecret_Internalname = "TABLESPLITTEDCLIENTSECRET";
         chkavClientauthrequestmustincludeuserscopes_Internalname = "vCLIENTAUTHREQUESTMUSTINCLUDEUSERSCOPES";
         chkavClientdonotshareuserids_Internalname = "vCLIENTDONOTSHAREUSERIDS";
         chkavClientallowremoteauth_Internalname = "vCLIENTALLOWREMOTEAUTH";
         chkavClientallowgetuserdata_Internalname = "vCLIENTALLOWGETUSERDATA";
         chkavClientallowgetuseradddata_Internalname = "vCLIENTALLOWGETUSERADDDATA";
         chkavClientallowgetuserroles_Internalname = "vCLIENTALLOWGETUSERROLES";
         chkavClientallowgetsessioniniprop_Internalname = "vCLIENTALLOWGETSESSIONINIPROP";
         chkavClientallowgetsessionappdata_Internalname = "vCLIENTALLOWGETSESSIONAPPDATA";
         edtavClientallowadditionalscope_Internalname = "vCLIENTALLOWADDITIONALSCOPE";
         edtavClientimageurl_Internalname = "vCLIENTIMAGEURL";
         edtavClientlocalloginurl_Internalname = "vCLIENTLOCALLOGINURL";
         edtavClientcallbackurl_Internalname = "vCLIENTCALLBACKURL";
         chkavClientcallbackurliscustom_Internalname = "vCLIENTCALLBACKURLISCUSTOM";
         edtavClientcallbackurlstatename_Internalname = "vCLIENTCALLBACKURLSTATENAME";
         divTblwebauth_Internalname = "TBLWEBAUTH";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         Dvpanel_unnamedtable6_Internalname = "DVPANEL_UNNAMEDTABLE6";
         chkavClientallowremoterestauth_Internalname = "vCLIENTALLOWREMOTERESTAUTH";
         chkavClientallowgetuserdatarest_Internalname = "vCLIENTALLOWGETUSERDATAREST";
         chkavClientallowgetuseradddatarest_Internalname = "vCLIENTALLOWGETUSERADDDATAREST";
         chkavClientallowgetuserrolesrest_Internalname = "vCLIENTALLOWGETUSERROLESREST";
         chkavClientallowgetsessioniniproprest_Internalname = "vCLIENTALLOWGETSESSIONINIPROPREST";
         chkavClientallowgetsessionappdatarest_Internalname = "vCLIENTALLOWGETSESSIONAPPDATAREST";
         edtavClientallowadditionalscoperest_Internalname = "vCLIENTALLOWADDITIONALSCOPEREST";
         divTblrestauth_Internalname = "TBLRESTAUTH";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         Dvpanel_unnamedtable7_Internalname = "DVPANEL_UNNAMEDTABLE7";
         chkavClientaccessuniquebyuser_Internalname = "vCLIENTACCESSUNIQUEBYUSER";
         lblTextblockclientencryptionkey_Internalname = "TEXTBLOCKCLIENTENCRYPTIONKEY";
         edtavClientencryptionkey_Internalname = "vCLIENTENCRYPTIONKEY";
         bttBtngeneratekeygamremote_Internalname = "BTNGENERATEKEYGAMREMOTE";
         tblTablemergedclientencryptionkey_Internalname = "TABLEMERGEDCLIENTENCRYPTIONKEY";
         divTablesplittedclientencryptionkey_Internalname = "TABLESPLITTEDCLIENTENCRYPTIONKEY";
         edtavClientrepositoryguid_Internalname = "vCLIENTREPOSITORYGUID";
         divUnnamedtable8_Internalname = "UNNAMEDTABLE8";
         Dvpanel_unnamedtable8_Internalname = "DVPANEL_UNNAMEDTABLE8";
         divTblgeneralauth_Internalname = "TBLGENERALAUTH";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         lblAuthorization_title_Internalname = "AUTHORIZATION_TITLE";
         chkavAccessrequirespermission_Internalname = "vACCESSREQUIRESPERMISSION";
         chkavIsauthorizationdelegated_Internalname = "vISAUTHORIZATIONDELEGATED";
         cmbavDelegateauthorizationversion_Internalname = "vDELEGATEAUTHORIZATIONVERSION";
         edtavDelegateauthorizationfilename_Internalname = "vDELEGATEAUTHORIZATIONFILENAME";
         edtavDelegateauthorizationpackage_Internalname = "vDELEGATEAUTHORIZATIONPACKAGE";
         edtavDelegateauthorizationclassname_Internalname = "vDELEGATEAUTHORIZATIONCLASSNAME";
         edtavDelegateauthorizationmethod_Internalname = "vDELEGATEAUTHORIZATIONMETHOD";
         divTbldelegateauthorizationprop_Internalname = "TBLDELEGATEAUTHORIZATIONPROP";
         divTbldelegateauthorization_Internalname = "TBLDELEGATEAUTHORIZATION";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         lblSsorest_title_Internalname = "SSOREST_TITLE";
         chkavSsorestenable_Internalname = "vSSORESTENABLE";
         cmbavSsorestmode_Internalname = "vSSORESTMODE";
         edtavSsorestuserauthtypename_Internalname = "vSSORESTUSERAUTHTYPENAME";
         edtavSsorestserverurl_Internalname = "vSSORESTSERVERURL";
         chkavSsorestserverurl_iscustom_Internalname = "vSSORESTSERVERURL_ISCUSTOM";
         edtavSsorestserverurl_slo_Internalname = "vSSORESTSERVERURL_SLO";
         edtavSsorestserverrepositoryguid_Internalname = "vSSORESTSERVERREPOSITORYGUID";
         edtavSsorestserverkey_Internalname = "vSSORESTSERVERKEY";
         divTblssorestmodeclient_Internalname = "TBLSSORESTMODECLIENT";
         divTablessorest_Internalname = "TABLESSOREST";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblSts_title_Internalname = "STS_TITLE";
         chkavStsprotocolenable_Internalname = "vSTSPROTOCOLENABLE";
         cmbavStsmode_Internalname = "vSTSMODE";
         edtavStsauthorizationusername_Internalname = "vSTSAUTHORIZATIONUSERNAME";
         divTablestsserverchecktoken_Internalname = "TABLESTSSERVERCHECKTOKEN";
         edtavStsserverclientpassword_Internalname = "vSTSSERVERCLIENTPASSWORD";
         divStsserverclientpassword_cell_Internalname = "STSSERVERCLIENTPASSWORD_CELL";
         divTablestsclientgettoken_Internalname = "TABLESTSCLIENTGETTOKEN";
         edtavStsserverurl_Internalname = "vSTSSERVERURL";
         edtavStsserverrepositoryguid_Internalname = "vSTSSERVERREPOSITORYGUID";
         divTablestsclient_Internalname = "TABLESTSCLIENT";
         divTablests_Internalname = "TABLESTS";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblMiniapp_title_Internalname = "MINIAPP_TITLE";
         chkavMiniappenable_Internalname = "vMINIAPPENABLE";
         cmbavMiniappmode_Internalname = "vMINIAPPMODE";
         edtavMiniappclienturl_Internalname = "vMINIAPPCLIENTURL";
         chkavMiniappclienturl_iscustom_Internalname = "vMINIAPPCLIENTURL_ISCUSTOM";
         edtavMiniappclientrepositoryguid_Internalname = "vMINIAPPCLIENTREPOSITORYGUID";
         divTblminiappserver_Internalname = "TBLMINIAPPSERVER";
         cmbavMiniappuserauthenticationtypename_Internalname = "vMINIAPPUSERAUTHENTICATIONTYPENAME";
         edtavMiniappserverurl_Internalname = "vMINIAPPSERVERURL";
         chkavMiniappserverurl_iscustom_Internalname = "vMINIAPPSERVERURL_ISCUSTOM";
         edtavMiniappserverrepositoryguid_Internalname = "vMINIAPPSERVERREPOSITORYGUID";
         divTblminiappclient_Internalname = "TBLMINIAPPCLIENT";
         divTblminiapp_Internalname = "TBLMINIAPP";
         divMiniapptable1_Internalname = "MINIAPPTABLE1";
         lblApikey_title_Internalname = "APIKEY_TITLE";
         chkavApikeyenable_Internalname = "vAPIKEYENABLE";
         edtavApikeytimeout_Internalname = "vAPIKEYTIMEOUT";
         cmbavApikeyallowonlyauthenticationtypename_Internalname = "vAPIKEYALLOWONLYAUTHENTICATIONTYPENAME";
         chkavApikeyallowscopecustomization_Internalname = "vAPIKEYALLOWSCOPECUSTOMIZATION";
         divTblapikey_Internalname = "TBLAPIKEY";
         divApikeytable1_Internalname = "APIKEYTABLE1";
         lblEnvironmentsettings_title_Internalname = "ENVIRONMENTSETTINGS_TITLE";
         edtavEnvironmentname_Internalname = "vENVIRONMENTNAME";
         chkavEnvironmentsecureprotocol_Internalname = "vENVIRONMENTSECUREPROTOCOL";
         edtavEnvironmenthost_Internalname = "vENVIRONMENTHOST";
         edtavEnvironmentport_Internalname = "vENVIRONMENTPORT";
         edtavEnvironmentvirtualdirectory_Internalname = "vENVIRONMENTVIRTUALDIRECTORY";
         edtavEnvironmentprogrampackage_Internalname = "vENVIRONMENTPROGRAMPACKAGE";
         edtavEnvironmentprogramextension_Internalname = "vENVIRONMENTPROGRAMEXTENSION";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         lblLanguages_title_Internalname = "LANGUAGES_TITLE";
         chkavOnline_Internalname = "vONLINE";
         edtavLanguage_Internalname = "vLANGUAGE";
         Gridlanguagespaginationbar_Internalname = "GRIDLANGUAGESPAGINATIONBAR";
         divGridlanguagestablewithpaginationbar_Internalname = "GRIDLANGUAGESTABLEWITHPAGINATIONBAR";
         divLanguagestable1_Internalname = "LANGUAGESTABLE1";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavGridlanguagescurrentpage_Internalname = "vGRIDLANGUAGESCURRENTPAGE";
         chkavAutoregisteranomymoususer_Internalname = "vAUTOREGISTERANOMYMOUSUSER";
         edtavStsauthorizationuserguid_Internalname = "vSTSAUTHORIZATIONUSERGUID";
         Gridlanguages_empowerer_Internalname = "GRIDLANGUAGES_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlanguages_Internalname = "GRIDLANGUAGES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlanguages_Allowcollapsing = 0;
         subGridlanguages_Allowselection = 0;
         subGridlanguages_Header = "";
         chkavAutoregisteranomymoususer.Caption = "";
         chkavEnvironmentsecureprotocol.Caption = " ";
         chkavApikeyallowscopecustomization.Caption = "API Key Allow Scope Customization";
         chkavApikeyenable.Caption = "Enable work with API keys";
         chkavMiniappserverurl_iscustom.Caption = "Custom SuperApp server URL";
         chkavMiniappclienturl_iscustom.Caption = "Custom MiniApp client URL";
         chkavMiniappenable.Caption = "Enable work as MiniApp?";
         chkavStsprotocolenable.Caption = " ";
         chkavSsorestserverurl_iscustom.Caption = "Custom server URL SSO";
         chkavSsorestenable.Caption = " ";
         chkavIsauthorizationdelegated.Caption = "Delegate authorization checking to an external program?";
         chkavAccessrequirespermission.Caption = "Enable Authorization?";
         chkavClientaccessuniquebyuser.Caption = " ";
         chkavClientallowgetsessionappdatarest.Caption = " ";
         chkavClientallowgetsessioniniproprest.Caption = " ";
         chkavClientallowgetuserrolesrest.Caption = " ";
         chkavClientallowgetuseradddatarest.Caption = " ";
         chkavClientallowgetuserdatarest.Caption = " ";
         chkavClientallowremoterestauth.Caption = " ";
         chkavClientcallbackurliscustom.Caption = " ";
         chkavClientallowgetsessionappdata.Caption = " ";
         chkavClientallowgetsessioniniprop.Caption = " ";
         chkavClientallowgetuserroles.Caption = " ";
         chkavClientallowgetuseradddata.Caption = " ";
         chkavClientallowgetuserdata.Caption = " ";
         chkavClientallowremoteauth.Caption = " ";
         chkavClientdonotshareuserids.Caption = " ";
         chkavClientauthrequestmustincludeuserscopes.Caption = " ";
         chkavUseabsoluteurlbyenvironment.Caption = " ";
         chkavReturnmenuoptionswithoutpermission.Caption = " ";
         edtavLanguage_Jsonclick = "";
         edtavLanguage_Enabled = 1;
         chkavOnline.Caption = "";
         subGridlanguages_Class = "GridWithPaginationBar WorkWith";
         subGridlanguages_Backcolorstyle = 0;
         edtavLogoutobject_Jsonclick = "";
         bttBtnchangeclientsecret_Visible = 1;
         edtavClientsecret_Jsonclick = "";
         bttBtngeneratekeygamremote_Visible = 1;
         edtavClientencryptionkey_Jsonclick = "";
         bttBtnrevokeallow_Caption = "Revoke";
         edtavClientencryptionkey_Enabled = 1;
         edtavLogoutobject_Enabled = 1;
         edtavClientsecret_Enabled = 1;
         edtavStsauthorizationuserguid_Jsonclick = "";
         edtavStsauthorizationuserguid_Visible = 1;
         chkavAutoregisteranomymoususer.Visible = 1;
         edtavGridlanguagescurrentpage_Jsonclick = "";
         edtavGridlanguagescurrentpage_Visible = 1;
         bttBtnenter_Caption = "Confirm";
         bttBtnenter_Visible = 1;
         edtavEnvironmentprogramextension_Jsonclick = "";
         edtavEnvironmentprogramextension_Enabled = 1;
         edtavEnvironmentprogrampackage_Jsonclick = "";
         edtavEnvironmentprogrampackage_Enabled = 1;
         edtavEnvironmentvirtualdirectory_Jsonclick = "";
         edtavEnvironmentvirtualdirectory_Enabled = 1;
         edtavEnvironmentport_Jsonclick = "";
         edtavEnvironmentport_Enabled = 1;
         edtavEnvironmenthost_Jsonclick = "";
         edtavEnvironmenthost_Enabled = 1;
         chkavEnvironmentsecureprotocol.Enabled = 1;
         edtavEnvironmentname_Jsonclick = "";
         edtavEnvironmentname_Enabled = 1;
         chkavApikeyallowscopecustomization.Enabled = 1;
         cmbavApikeyallowonlyauthenticationtypename_Jsonclick = "";
         cmbavApikeyallowonlyauthenticationtypename.Enabled = 1;
         edtavApikeytimeout_Jsonclick = "";
         edtavApikeytimeout_Enabled = 1;
         divTblapikey_Visible = 1;
         chkavApikeyenable.Enabled = 1;
         edtavMiniappserverrepositoryguid_Jsonclick = "";
         edtavMiniappserverrepositoryguid_Enabled = 1;
         chkavMiniappserverurl_iscustom.Enabled = 1;
         edtavMiniappserverurl_Jsonclick = "";
         edtavMiniappserverurl_Enabled = 1;
         cmbavMiniappuserauthenticationtypename_Jsonclick = "";
         cmbavMiniappuserauthenticationtypename.Enabled = 1;
         divTblminiappclient_Visible = 1;
         edtavMiniappclientrepositoryguid_Jsonclick = "";
         edtavMiniappclientrepositoryguid_Enabled = 1;
         chkavMiniappclienturl_iscustom.Enabled = 1;
         edtavMiniappclienturl_Jsonclick = "";
         edtavMiniappclienturl_Enabled = 1;
         divTblminiappserver_Visible = 1;
         cmbavMiniappmode_Jsonclick = "";
         cmbavMiniappmode.Enabled = 1;
         divTblminiapp_Visible = 1;
         chkavMiniappenable.Enabled = 1;
         edtavStsserverrepositoryguid_Jsonclick = "";
         edtavStsserverrepositoryguid_Enabled = 1;
         edtavStsserverurl_Jsonclick = "";
         edtavStsserverurl_Enabled = 1;
         divTablestsclient_Visible = 1;
         edtavStsserverclientpassword_Jsonclick = "";
         edtavStsserverclientpassword_Enabled = 1;
         edtavStsserverclientpassword_Visible = 1;
         divStsserverclientpassword_cell_Class = "col-xs-12";
         divTablestsclientgettoken_Visible = 1;
         edtavStsauthorizationusername_Jsonclick = "";
         edtavStsauthorizationusername_Enabled = 1;
         divTablestsserverchecktoken_Visible = 1;
         cmbavStsmode_Jsonclick = "";
         cmbavStsmode.Enabled = 1;
         divTablests_Visible = 1;
         chkavStsprotocolenable.Enabled = 1;
         edtavSsorestserverkey_Jsonclick = "";
         edtavSsorestserverkey_Enabled = 1;
         edtavSsorestserverrepositoryguid_Jsonclick = "";
         edtavSsorestserverrepositoryguid_Enabled = 1;
         edtavSsorestserverurl_slo_Jsonclick = "";
         edtavSsorestserverurl_slo_Enabled = 1;
         chkavSsorestserverurl_iscustom.Enabled = 1;
         edtavSsorestserverurl_Jsonclick = "";
         edtavSsorestserverurl_Enabled = 1;
         edtavSsorestuserauthtypename_Jsonclick = "";
         edtavSsorestuserauthtypename_Enabled = 1;
         divTblssorestmodeclient_Visible = 1;
         cmbavSsorestmode_Jsonclick = "";
         cmbavSsorestmode.Enabled = 1;
         divTablessorest_Visible = 1;
         chkavSsorestenable.Enabled = 1;
         edtavDelegateauthorizationmethod_Jsonclick = "";
         edtavDelegateauthorizationmethod_Enabled = 1;
         edtavDelegateauthorizationclassname_Jsonclick = "";
         edtavDelegateauthorizationclassname_Enabled = 1;
         edtavDelegateauthorizationpackage_Jsonclick = "";
         edtavDelegateauthorizationpackage_Enabled = 1;
         edtavDelegateauthorizationfilename_Jsonclick = "";
         edtavDelegateauthorizationfilename_Enabled = 1;
         cmbavDelegateauthorizationversion_Jsonclick = "";
         cmbavDelegateauthorizationversion.Enabled = 1;
         divTbldelegateauthorizationprop_Visible = 1;
         chkavIsauthorizationdelegated.Enabled = 1;
         divTbldelegateauthorization_Visible = 1;
         chkavAccessrequirespermission.Enabled = 1;
         edtavClientrepositoryguid_Jsonclick = "";
         edtavClientrepositoryguid_Enabled = 1;
         chkavClientaccessuniquebyuser.Enabled = 1;
         divTblgeneralauth_Visible = 1;
         edtavClientallowadditionalscoperest_Jsonclick = "";
         edtavClientallowadditionalscoperest_Enabled = 1;
         chkavClientallowgetsessionappdatarest.Enabled = 1;
         chkavClientallowgetsessioniniproprest.Enabled = 1;
         chkavClientallowgetuserrolesrest.Enabled = 1;
         chkavClientallowgetuseradddatarest.Enabled = 1;
         chkavClientallowgetuserdatarest.Enabled = 1;
         divTblrestauth_Visible = 1;
         chkavClientallowremoterestauth.Enabled = 1;
         edtavClientcallbackurlstatename_Jsonclick = "";
         edtavClientcallbackurlstatename_Enabled = 1;
         chkavClientcallbackurliscustom.Enabled = 1;
         edtavClientcallbackurl_Jsonclick = "";
         edtavClientcallbackurl_Enabled = 1;
         edtavClientlocalloginurl_Jsonclick = "";
         edtavClientlocalloginurl_Enabled = 1;
         edtavClientimageurl_Jsonclick = "";
         edtavClientimageurl_Enabled = 1;
         edtavClientallowadditionalscope_Jsonclick = "";
         edtavClientallowadditionalscope_Enabled = 1;
         chkavClientallowgetsessionappdata.Enabled = 1;
         chkavClientallowgetsessioniniprop.Enabled = 1;
         chkavClientallowgetuserroles.Enabled = 1;
         chkavClientallowgetuseradddata.Enabled = 1;
         chkavClientallowgetuserdata.Enabled = 1;
         divTblwebauth_Visible = 1;
         chkavClientallowremoteauth.Enabled = 1;
         chkavClientdonotshareuserids.Enabled = 1;
         chkavClientauthrequestmustincludeuserscopes.Enabled = 1;
         edtavClientid_Jsonclick = "";
         edtavClientid_Enabled = 1;
         edtavClientrevoked_Jsonclick = "";
         edtavClientrevoked_Enabled = 1;
         edtavClientrevoked_Visible = 1;
         cmbavClientaccessstatus_Jsonclick = "";
         cmbavClientaccessstatus.Enabled = 1;
         edtavAccountactivationobject_Jsonclick = "";
         edtavAccountactivationobject_Enabled = 1;
         edtavHomeobject_Jsonclick = "";
         edtavHomeobject_Enabled = 1;
         chkavUseabsoluteurlbyenvironment.Enabled = 1;
         cmbavMainmenu_Jsonclick = "";
         cmbavMainmenu.Enabled = 1;
         chkavReturnmenuoptionswithoutpermission.Enabled = 1;
         edtavCopyright_Jsonclick = "";
         edtavCopyright_Enabled = 1;
         edtavCompany_Jsonclick = "";
         edtavCompany_Enabled = 1;
         edtavVersion_Jsonclick = "";
         edtavVersion_Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Enabled = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "Tab";
         Gxuitabspanel_tabs_Pagecount = 9;
         Gridlanguagespaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridlanguagespaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridlanguagespaginationbar_Caption = "Page <CURRENT_PAGE> of <TOTAL_PAGES>";
         Gridlanguagespaginationbar_Next = "WWP_PagingNextCaption";
         Gridlanguagespaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridlanguagespaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridlanguagespaginationbar_Rowsperpageselectedvalue = 10;
         Gridlanguagespaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridlanguagespaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridlanguagespaginationbar_Pagingcaptionposition = "Left";
         Gridlanguagespaginationbar_Pagingbuttonsposition = "Right";
         Gridlanguagespaginationbar_Pagestoshow = 5;
         Gridlanguagespaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridlanguagespaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridlanguagespaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridlanguagespaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridlanguagespaginationbar_Class = "PaginationBar";
         Dvpanel_unnamedtable8_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Iconposition = "Right";
         Dvpanel_unnamedtable8_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable8_Title = "General";
         Dvpanel_unnamedtable8_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable8_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable8_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Width = "100%";
         Dvpanel_unnamedtable7_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Iconposition = "Right";
         Dvpanel_unnamedtable7_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable7_Title = "REST (GAMRemoteREST, SSO REST, MiniApp, API key)";
         Dvpanel_unnamedtable7_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable7_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable7_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Width = "100%";
         Dvpanel_unnamedtable6_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Iconposition = "Right";
         Dvpanel_unnamedtable6_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable6_Title = "GAM_WEB (GAMRemote, IDP using SSO)";
         Dvpanel_unnamedtable6_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable6_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable6_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable6_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Application";
         chkavOnline.Enabled = 1;
         subGridlanguages_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDLANGUAGES_nFirstRecordOnPage"},{"av":"GRIDLANGUAGES_nEOF"},{"av":"subGridlanguages_Rows","ctrl":"GRIDLANGUAGES","prop":"Rows"},{"av":"chkavOnline.Enabled","ctrl":"vONLINE","prop":"Enabled"},{"av":"AV156ReturnMenuOptionsWithoutPermission","fld":"vRETURNMENUOPTIONSWITHOUTPERMISSION"},{"av":"AV61UseAbsoluteUrlByEnvironment","fld":"vUSEABSOLUTEURLBYENVIRONMENT"},{"av":"AV128ClientAuthRequestMustIncludeUserScopes","fld":"vCLIENTAUTHREQUESTMUSTINCLUDEUSERSCOPES"},{"av":"AV129ClientDoNotShareUserIDs","fld":"vCLIENTDONOTSHAREUSERIDS"},{"av":"AV17ClientAllowRemoteAuth","fld":"vCLIENTALLOWREMOTEAUTH"},{"av":"AV126ClientAllowGetUserData","fld":"vCLIENTALLOWGETUSERDATA"},{"av":"AV13ClientAllowGetUserAddData","fld":"vCLIENTALLOWGETUSERADDDATA"},{"av":"AV15ClientAllowGetUserRoles","fld":"vCLIENTALLOWGETUSERROLES"},{"av":"AV11ClientAllowGetSessionIniProp","fld":"vCLIENTALLOWGETSESSIONINIPROP"},{"av":"AV9ClientAllowGetSessionAppData","fld":"vCLIENTALLOWGETSESSIONAPPDATA"},{"av":"AV20ClientCallbackURLisCustom","fld":"vCLIENTCALLBACKURLISCUSTOM"},{"av":"AV18ClientAllowRemoteRestAuth","fld":"vCLIENTALLOWREMOTERESTAUTH"},{"av":"AV127ClientAllowGetUserDataREST","fld":"vCLIENTALLOWGETUSERDATAREST"},{"av":"AV14ClientAllowGetUserAddDataRest","fld":"vCLIENTALLOWGETUSERADDDATAREST"},{"av":"AV16ClientAllowGetUserRolesRest","fld":"vCLIENTALLOWGETUSERROLESREST"},{"av":"AV12ClientAllowGetSessionIniPropRest","fld":"vCLIENTALLOWGETSESSIONINIPROPREST"},{"av":"AV10ClientAllowGetSessionAppDataREST","fld":"vCLIENTALLOWGETSESSIONAPPDATAREST"},{"av":"AV8ClientAccessUniqueByUser","fld":"vCLIENTACCESSUNIQUEBYUSER"},{"av":"AV5AccessRequiresPermission","fld":"vACCESSREQUIRESPERMISSION"},{"av":"AV143IsAuthorizationDelegated","fld":"vISAUTHORIZATIONDELEGATED"},{"av":"AV50SSORestEnable","fld":"vSSORESTENABLE"},{"av":"AV159SSORestServerURL_isCustom","fld":"vSSORESTSERVERURL_ISCUSTOM"},{"av":"AV57STSProtocolEnable","fld":"vSTSPROTOCOLENABLE"},{"av":"AV148MiniAppEnable","fld":"vMINIAPPENABLE"},{"av":"AV147MiniAppClientURL_isCustom","fld":"vMINIAPPCLIENTURL_ISCUSTOM"},{"av":"AV152MiniAppServerURL_isCustom","fld":"vMINIAPPSERVERURL_ISCUSTOM"},{"av":"AV120APIKeyEnable","fld":"vAPIKEYENABLE"},{"av":"AV119APIKeyAllowScopeCustomization","fld":"vAPIKEYALLOWSCOPECUSTOMIZATION"},{"av":"AV36EnvironmentSecureProtocol","fld":"vENVIRONMENTSECUREPROTOCOL"},{"av":"AV7AutoRegisterAnomymousUser","fld":"vAUTOREGISTERANOMYMOUSUSER"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true}]}""");
         setEventMetadata("GRIDLANGUAGES.LOAD","""{"handler":"E260Y2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true}]""");
         setEventMetadata("GRIDLANGUAGES.LOAD",""","oparms":[{"av":"AV154Online","fld":"vONLINE"},{"av":"AV144Language","fld":"vLANGUAGE","hsh":true}]}""");
         setEventMetadata("GRIDLANGUAGESPAGINATIONBAR.CHANGEPAGE","""{"handler":"E120Y2","iparms":[{"av":"GRIDLANGUAGES_nFirstRecordOnPage"},{"av":"GRIDLANGUAGES_nEOF"},{"av":"subGridlanguages_Rows","ctrl":"GRIDLANGUAGES","prop":"Rows"},{"av":"chkavOnline.Enabled","ctrl":"vONLINE","prop":"Enabled"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV156ReturnMenuOptionsWithoutPermission","fld":"vRETURNMENUOPTIONSWITHOUTPERMISSION"},{"av":"AV61UseAbsoluteUrlByEnvironment","fld":"vUSEABSOLUTEURLBYENVIRONMENT"},{"av":"AV128ClientAuthRequestMustIncludeUserScopes","fld":"vCLIENTAUTHREQUESTMUSTINCLUDEUSERSCOPES"},{"av":"AV129ClientDoNotShareUserIDs","fld":"vCLIENTDONOTSHAREUSERIDS"},{"av":"AV17ClientAllowRemoteAuth","fld":"vCLIENTALLOWREMOTEAUTH"},{"av":"AV126ClientAllowGetUserData","fld":"vCLIENTALLOWGETUSERDATA"},{"av":"AV13ClientAllowGetUserAddData","fld":"vCLIENTALLOWGETUSERADDDATA"},{"av":"AV15ClientAllowGetUserRoles","fld":"vCLIENTALLOWGETUSERROLES"},{"av":"AV11ClientAllowGetSessionIniProp","fld":"vCLIENTALLOWGETSESSIONINIPROP"},{"av":"AV9ClientAllowGetSessionAppData","fld":"vCLIENTALLOWGETSESSIONAPPDATA"},{"av":"AV20ClientCallbackURLisCustom","fld":"vCLIENTCALLBACKURLISCUSTOM"},{"av":"AV18ClientAllowRemoteRestAuth","fld":"vCLIENTALLOWREMOTERESTAUTH"},{"av":"AV127ClientAllowGetUserDataREST","fld":"vCLIENTALLOWGETUSERDATAREST"},{"av":"AV14ClientAllowGetUserAddDataRest","fld":"vCLIENTALLOWGETUSERADDDATAREST"},{"av":"AV16ClientAllowGetUserRolesRest","fld":"vCLIENTALLOWGETUSERROLESREST"},{"av":"AV12ClientAllowGetSessionIniPropRest","fld":"vCLIENTALLOWGETSESSIONINIPROPREST"},{"av":"AV10ClientAllowGetSessionAppDataREST","fld":"vCLIENTALLOWGETSESSIONAPPDATAREST"},{"av":"AV8ClientAccessUniqueByUser","fld":"vCLIENTACCESSUNIQUEBYUSER"},{"av":"AV5AccessRequiresPermission","fld":"vACCESSREQUIRESPERMISSION"},{"av":"AV143IsAuthorizationDelegated","fld":"vISAUTHORIZATIONDELEGATED"},{"av":"AV50SSORestEnable","fld":"vSSORESTENABLE"},{"av":"AV159SSORestServerURL_isCustom","fld":"vSSORESTSERVERURL_ISCUSTOM"},{"av":"AV57STSProtocolEnable","fld":"vSTSPROTOCOLENABLE"},{"av":"AV148MiniAppEnable","fld":"vMINIAPPENABLE"},{"av":"AV147MiniAppClientURL_isCustom","fld":"vMINIAPPCLIENTURL_ISCUSTOM"},{"av":"AV152MiniAppServerURL_isCustom","fld":"vMINIAPPSERVERURL_ISCUSTOM"},{"av":"AV120APIKeyEnable","fld":"vAPIKEYENABLE"},{"av":"AV119APIKeyAllowScopeCustomization","fld":"vAPIKEYALLOWSCOPECUSTOMIZATION"},{"av":"AV36EnvironmentSecureProtocol","fld":"vENVIRONMENTSECUREPROTOCOL"},{"av":"AV7AutoRegisterAnomymousUser","fld":"vAUTOREGISTERANOMYMOUSUSER"},{"av":"Gridlanguagespaginationbar_Selectedpage","ctrl":"GRIDLANGUAGESPAGINATIONBAR","prop":"SelectedPage"},{"av":"AV140GridLanguagesCurrentPage","fld":"vGRIDLANGUAGESCURRENTPAGE","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("GRIDLANGUAGESPAGINATIONBAR.CHANGEPAGE",""","oparms":[{"av":"AV140GridLanguagesCurrentPage","fld":"vGRIDLANGUAGESCURRENTPAGE","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GRIDLANGUAGESPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E130Y2","iparms":[{"av":"GRIDLANGUAGES_nFirstRecordOnPage"},{"av":"GRIDLANGUAGES_nEOF"},{"av":"subGridlanguages_Rows","ctrl":"GRIDLANGUAGES","prop":"Rows"},{"av":"chkavOnline.Enabled","ctrl":"vONLINE","prop":"Enabled"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV156ReturnMenuOptionsWithoutPermission","fld":"vRETURNMENUOPTIONSWITHOUTPERMISSION"},{"av":"AV61UseAbsoluteUrlByEnvironment","fld":"vUSEABSOLUTEURLBYENVIRONMENT"},{"av":"AV128ClientAuthRequestMustIncludeUserScopes","fld":"vCLIENTAUTHREQUESTMUSTINCLUDEUSERSCOPES"},{"av":"AV129ClientDoNotShareUserIDs","fld":"vCLIENTDONOTSHAREUSERIDS"},{"av":"AV17ClientAllowRemoteAuth","fld":"vCLIENTALLOWREMOTEAUTH"},{"av":"AV126ClientAllowGetUserData","fld":"vCLIENTALLOWGETUSERDATA"},{"av":"AV13ClientAllowGetUserAddData","fld":"vCLIENTALLOWGETUSERADDDATA"},{"av":"AV15ClientAllowGetUserRoles","fld":"vCLIENTALLOWGETUSERROLES"},{"av":"AV11ClientAllowGetSessionIniProp","fld":"vCLIENTALLOWGETSESSIONINIPROP"},{"av":"AV9ClientAllowGetSessionAppData","fld":"vCLIENTALLOWGETSESSIONAPPDATA"},{"av":"AV20ClientCallbackURLisCustom","fld":"vCLIENTCALLBACKURLISCUSTOM"},{"av":"AV18ClientAllowRemoteRestAuth","fld":"vCLIENTALLOWREMOTERESTAUTH"},{"av":"AV127ClientAllowGetUserDataREST","fld":"vCLIENTALLOWGETUSERDATAREST"},{"av":"AV14ClientAllowGetUserAddDataRest","fld":"vCLIENTALLOWGETUSERADDDATAREST"},{"av":"AV16ClientAllowGetUserRolesRest","fld":"vCLIENTALLOWGETUSERROLESREST"},{"av":"AV12ClientAllowGetSessionIniPropRest","fld":"vCLIENTALLOWGETSESSIONINIPROPREST"},{"av":"AV10ClientAllowGetSessionAppDataREST","fld":"vCLIENTALLOWGETSESSIONAPPDATAREST"},{"av":"AV8ClientAccessUniqueByUser","fld":"vCLIENTACCESSUNIQUEBYUSER"},{"av":"AV5AccessRequiresPermission","fld":"vACCESSREQUIRESPERMISSION"},{"av":"AV143IsAuthorizationDelegated","fld":"vISAUTHORIZATIONDELEGATED"},{"av":"AV50SSORestEnable","fld":"vSSORESTENABLE"},{"av":"AV159SSORestServerURL_isCustom","fld":"vSSORESTSERVERURL_ISCUSTOM"},{"av":"AV57STSProtocolEnable","fld":"vSTSPROTOCOLENABLE"},{"av":"AV148MiniAppEnable","fld":"vMINIAPPENABLE"},{"av":"AV147MiniAppClientURL_isCustom","fld":"vMINIAPPCLIENTURL_ISCUSTOM"},{"av":"AV152MiniAppServerURL_isCustom","fld":"vMINIAPPSERVERURL_ISCUSTOM"},{"av":"AV120APIKeyEnable","fld":"vAPIKEYENABLE"},{"av":"AV119APIKeyAllowScopeCustomization","fld":"vAPIKEYALLOWSCOPECUSTOMIZATION"},{"av":"AV36EnvironmentSecureProtocol","fld":"vENVIRONMENTSECUREPROTOCOL"},{"av":"AV7AutoRegisterAnomymousUser","fld":"vAUTOREGISTERANOMYMOUSUSER"},{"av":"Gridlanguagespaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDLANGUAGESPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDLANGUAGESPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGridlanguages_Rows","ctrl":"GRIDLANGUAGES","prop":"Rows"},{"av":"AV140GridLanguagesCurrentPage","fld":"vGRIDLANGUAGESCURRENTPAGE","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOCHANGECLIENTSECRET'","""{"handler":"E300Y1","iparms":[{"av":"AV22ClientId","fld":"vCLIENTID"},{"av":"AV43Id","fld":"vID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("'DOCHANGECLIENTSECRET'",""","oparms":[{"av":"AV43Id","fld":"vID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOGENERATEKEYGAMREMOTE'","""{"handler":"E140Y2","iparms":[]""");
         setEventMetadata("'DOGENERATEKEYGAMREMOTE'",""","oparms":[{"av":"AV21ClientEncryptionKey","fld":"vCLIENTENCRYPTIONKEY"}]}""");
         setEventMetadata("'DOREVOKEALLOW'","""{"handler":"E150Y2","iparms":[{"av":"GRIDLANGUAGES_nFirstRecordOnPage"},{"av":"GRIDLANGUAGES_nEOF"},{"av":"subGridlanguages_Rows","ctrl":"GRIDLANGUAGES","prop":"Rows"},{"av":"chkavOnline.Enabled","ctrl":"vONLINE","prop":"Enabled"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV156ReturnMenuOptionsWithoutPermission","fld":"vRETURNMENUOPTIONSWITHOUTPERMISSION"},{"av":"AV61UseAbsoluteUrlByEnvironment","fld":"vUSEABSOLUTEURLBYENVIRONMENT"},{"av":"AV128ClientAuthRequestMustIncludeUserScopes","fld":"vCLIENTAUTHREQUESTMUSTINCLUDEUSERSCOPES"},{"av":"AV129ClientDoNotShareUserIDs","fld":"vCLIENTDONOTSHAREUSERIDS"},{"av":"AV17ClientAllowRemoteAuth","fld":"vCLIENTALLOWREMOTEAUTH"},{"av":"AV126ClientAllowGetUserData","fld":"vCLIENTALLOWGETUSERDATA"},{"av":"AV13ClientAllowGetUserAddData","fld":"vCLIENTALLOWGETUSERADDDATA"},{"av":"AV15ClientAllowGetUserRoles","fld":"vCLIENTALLOWGETUSERROLES"},{"av":"AV11ClientAllowGetSessionIniProp","fld":"vCLIENTALLOWGETSESSIONINIPROP"},{"av":"AV9ClientAllowGetSessionAppData","fld":"vCLIENTALLOWGETSESSIONAPPDATA"},{"av":"AV20ClientCallbackURLisCustom","fld":"vCLIENTCALLBACKURLISCUSTOM"},{"av":"AV18ClientAllowRemoteRestAuth","fld":"vCLIENTALLOWREMOTERESTAUTH"},{"av":"AV127ClientAllowGetUserDataREST","fld":"vCLIENTALLOWGETUSERDATAREST"},{"av":"AV14ClientAllowGetUserAddDataRest","fld":"vCLIENTALLOWGETUSERADDDATAREST"},{"av":"AV16ClientAllowGetUserRolesRest","fld":"vCLIENTALLOWGETUSERROLESREST"},{"av":"AV12ClientAllowGetSessionIniPropRest","fld":"vCLIENTALLOWGETSESSIONINIPROPREST"},{"av":"AV10ClientAllowGetSessionAppDataREST","fld":"vCLIENTALLOWGETSESSIONAPPDATAREST"},{"av":"AV8ClientAccessUniqueByUser","fld":"vCLIENTACCESSUNIQUEBYUSER"},{"av":"AV5AccessRequiresPermission","fld":"vACCESSREQUIRESPERMISSION"},{"av":"AV143IsAuthorizationDelegated","fld":"vISAUTHORIZATIONDELEGATED"},{"av":"AV50SSORestEnable","fld":"vSSORESTENABLE"},{"av":"AV159SSORestServerURL_isCustom","fld":"vSSORESTSERVERURL_ISCUSTOM"},{"av":"AV57STSProtocolEnable","fld":"vSTSPROTOCOLENABLE"},{"av":"AV148MiniAppEnable","fld":"vMINIAPPENABLE"},{"av":"AV147MiniAppClientURL_isCustom","fld":"vMINIAPPCLIENTURL_ISCUSTOM"},{"av":"AV152MiniAppServerURL_isCustom","fld":"vMINIAPPSERVERURL_ISCUSTOM"},{"av":"AV120APIKeyEnable","fld":"vAPIKEYENABLE"},{"av":"AV119APIKeyAllowScopeCustomization","fld":"vAPIKEYALLOWSCOPECUSTOMIZATION"},{"av":"AV36EnvironmentSecureProtocol","fld":"vENVIRONMENTSECUREPROTOCOL"},{"av":"AV7AutoRegisterAnomymousUser","fld":"vAUTOREGISTERANOMYMOUSUSER"},{"av":"AV43Id","fld":"vID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("'DOREVOKEALLOW'",""","oparms":[{"ctrl":"BTNREVOKEALLOW","prop":"Caption"}]}""");
         setEventMetadata("ENTER","""{"handler":"E160Y2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV43Id","fld":"vID","pic":"ZZZZZZZZZZZ9"},{"av":"AV49Name","fld":"vNAME"},{"av":"AV30Dsc","fld":"vDSC"},{"av":"AV64Version","fld":"vVERSION"},{"av":"AV29Copyright","fld":"vCOPYRIGHT"},{"av":"AV28Company","fld":"vCOMPANY"},{"av":"AV156ReturnMenuOptionsWithoutPermission","fld":"vRETURNMENUOPTIONSWITHOUTPERMISSION"},{"av":"cmbavMainmenu"},{"av":"AV46MainMenu","fld":"vMAINMENU","pic":"ZZZZZZZZZZZ9"},{"av":"AV61UseAbsoluteUrlByEnvironment","fld":"vUSEABSOLUTEURLBYENVIRONMENT"},{"av":"AV42HomeObject","fld":"vHOMEOBJECT"},{"av":"AV66AccountActivationObject","fld":"vACCOUNTACTIVATIONOBJECT"},{"av":"AV45LogoutObject","fld":"vLOGOUTOBJECT"},{"av":"AV22ClientId","fld":"vCLIENTID"},{"av":"AV27ClientSecret","fld":"vCLIENTSECRET"},{"av":"AV128ClientAuthRequestMustIncludeUserScopes","fld":"vCLIENTAUTHREQUESTMUSTINCLUDEUSERSCOPES"},{"av":"AV129ClientDoNotShareUserIDs","fld":"vCLIENTDONOTSHAREUSERIDS"},{"av":"AV8ClientAccessUniqueByUser","fld":"vCLIENTACCESSUNIQUEBYUSER"},{"av":"AV17ClientAllowRemoteAuth","fld":"vCLIENTALLOWREMOTEAUTH"},{"av":"AV126ClientAllowGetUserData","fld":"vCLIENTALLOWGETUSERDATA"},{"av":"AV13ClientAllowGetUserAddData","fld":"vCLIENTALLOWGETUSERADDDATA"},{"av":"AV15ClientAllowGetUserRoles","fld":"vCLIENTALLOWGETUSERROLES"},{"av":"AV11ClientAllowGetSessionIniProp","fld":"vCLIENTALLOWGETSESSIONINIPROP"},{"av":"AV9ClientAllowGetSessionAppData","fld":"vCLIENTALLOWGETSESSIONAPPDATA"},{"av":"AV124ClientAllowAdditionalScope","fld":"vCLIENTALLOWADDITIONALSCOPE"},{"av":"AV24ClientLocalLoginURL","fld":"vCLIENTLOCALLOGINURL"},{"av":"AV19ClientCallbackURL","fld":"vCLIENTCALLBACKURL"},{"av":"AV20ClientCallbackURLisCustom","fld":"vCLIENTCALLBACKURLISCUSTOM"},{"av":"AV65ClientCallbackURLStateName","fld":"vCLIENTCALLBACKURLSTATENAME"},{"av":"AV23ClientImageURL","fld":"vCLIENTIMAGEURL"},{"av":"AV18ClientAllowRemoteRestAuth","fld":"vCLIENTALLOWREMOTERESTAUTH"},{"av":"AV127ClientAllowGetUserDataREST","fld":"vCLIENTALLOWGETUSERDATAREST"},{"av":"AV14ClientAllowGetUserAddDataRest","fld":"vCLIENTALLOWGETUSERADDDATAREST"},{"av":"AV16ClientAllowGetUserRolesRest","fld":"vCLIENTALLOWGETUSERROLESREST"},{"av":"AV12ClientAllowGetSessionIniPropRest","fld":"vCLIENTALLOWGETSESSIONINIPROPREST"},{"av":"AV10ClientAllowGetSessionAppDataREST","fld":"vCLIENTALLOWGETSESSIONAPPDATAREST"},{"av":"AV125ClientAllowAdditionalScopeREST","fld":"vCLIENTALLOWADDITIONALSCOPEREST"},{"av":"AV21ClientEncryptionKey","fld":"vCLIENTENCRYPTIONKEY"},{"av":"AV25ClientRepositoryGUID","fld":"vCLIENTREPOSITORYGUID"},{"av":"AV5AccessRequiresPermission","fld":"vACCESSREQUIRESPERMISSION"},{"av":"AV143IsAuthorizationDelegated","fld":"vISAUTHORIZATIONDELEGATED"},{"av":"cmbavDelegateauthorizationversion"},{"av":"AV134DelegateAuthorizationVersion","fld":"vDELEGATEAUTHORIZATIONVERSION"},{"av":"AV131DelegateAuthorizationFileName","fld":"vDELEGATEAUTHORIZATIONFILENAME"},{"av":"AV133DelegateAuthorizationPackage","fld":"vDELEGATEAUTHORIZATIONPACKAGE"},{"av":"AV130DelegateAuthorizationClassName","fld":"vDELEGATEAUTHORIZATIONCLASSNAME"},{"av":"AV132DelegateAuthorizationMethod","fld":"vDELEGATEAUTHORIZATIONMETHOD"},{"av":"AV50SSORestEnable","fld":"vSSORESTENABLE"},{"av":"cmbavSsorestmode"},{"av":"AV51SSORestMode","fld":"vSSORESTMODE"},{"av":"AV53SSORestUserAuthTypeName","fld":"vSSORESTUSERAUTHTYPENAME"},{"av":"AV52SSORestServerURL","fld":"vSSORESTSERVERURL"},{"av":"AV159SSORestServerURL_isCustom","fld":"vSSORESTSERVERURL_ISCUSTOM"},{"av":"AV160SSORestServerURL_SLO","fld":"vSSORESTSERVERURL_SLO"},{"av":"AV158SSORestServerRepositoryGUID","fld":"vSSORESTSERVERREPOSITORYGUID"},{"av":"AV157SSORestServerKey","fld":"vSSORESTSERVERKEY"},{"av":"AV57STSProtocolEnable","fld":"vSTSPROTOCOLENABLE"},{"av":"AV55STSAuthorizationUserName","fld":"vSTSAUTHORIZATIONUSERNAME"},{"av":"AV54STSAuthorizationUserGUID","fld":"vSTSAUTHORIZATIONUSERGUID"},{"av":"cmbavStsmode"},{"av":"AV56STSMode","fld":"vSTSMODE"},{"av":"AV60STSServerURL","fld":"vSTSSERVERURL"},{"av":"AV58STSServerClientPassword","fld":"vSTSSERVERCLIENTPASSWORD"},{"av":"AV59STSServerRepositoryGUID","fld":"vSTSSERVERREPOSITORYGUID"},{"av":"AV148MiniAppEnable","fld":"vMINIAPPENABLE"},{"av":"cmbavMiniappmode"},{"av":"AV149MiniAppMode","fld":"vMINIAPPMODE"},{"av":"AV146MiniAppClientURL","fld":"vMINIAPPCLIENTURL"},{"av":"AV147MiniAppClientURL_isCustom","fld":"vMINIAPPCLIENTURL_ISCUSTOM"},{"av":"AV145MiniAppClientRepositoryGUID","fld":"vMINIAPPCLIENTREPOSITORYGUID"},{"av":"cmbavMiniappuserauthenticationtypename"},{"av":"AV153MiniAppUserAuthenticationTypeName","fld":"vMINIAPPUSERAUTHENTICATIONTYPENAME"},{"av":"AV151MiniAppServerURL","fld":"vMINIAPPSERVERURL"},{"av":"AV152MiniAppServerURL_isCustom","fld":"vMINIAPPSERVERURL_ISCUSTOM"},{"av":"AV150MiniAppServerRepositoryGUID","fld":"vMINIAPPSERVERREPOSITORYGUID"},{"av":"AV120APIKeyEnable","fld":"vAPIKEYENABLE"},{"av":"AV121APIKeyTimeout","fld":"vAPIKEYTIMEOUT","pic":"ZZZZZZZZ9"},{"av":"cmbavApikeyallowonlyauthenticationtypename"},{"av":"AV118APIKeyAllowOnlyAuthenticationTypeName","fld":"vAPIKEYALLOWONLYAUTHENTICATIONTYPENAME"},{"av":"AV119APIKeyAllowScopeCustomization","fld":"vAPIKEYALLOWSCOPECUSTOMIZATION"},{"av":"AV32EnvironmentName","fld":"vENVIRONMENTNAME"},{"av":"AV36EnvironmentSecureProtocol","fld":"vENVIRONMENTSECUREPROTOCOL"},{"av":"AV31EnvironmentHost","fld":"vENVIRONMENTHOST"},{"av":"AV33EnvironmentPort","fld":"vENVIRONMENTPORT","pic":"ZZZZ9"},{"av":"AV37EnvironmentVirtualDirectory","fld":"vENVIRONMENTVIRTUALDIRECTORY"},{"av":"AV35EnvironmentProgramPackage","fld":"vENVIRONMENTPROGRAMPACKAGE"},{"av":"AV34EnvironmentProgramExtension","fld":"vENVIRONMENTPROGRAMEXTENSION"},{"av":"AV144Language","fld":"vLANGUAGE","grid":567,"hsh":true},{"av":"GRIDLANGUAGES_nFirstRecordOnPage"},{"av":"nRC_GXsfl_567","ctrl":"GRIDLANGUAGES","grid":567,"prop":"GridRC","grid":567},{"av":"AV154Online","fld":"vONLINE","grid":567}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV54STSAuthorizationUserGUID","fld":"vSTSAUTHORIZATIONUSERGUID"}]}""");
         setEventMetadata("'GENERATEKEYGAMREMOTE'","""{"handler":"E270Y2","iparms":[]""");
         setEventMetadata("'GENERATEKEYGAMREMOTE'",""","oparms":[{"av":"AV21ClientEncryptionKey","fld":"vCLIENTENCRYPTIONKEY"}]}""");
         setEventMetadata("'REVOKE-AUTHORIZE'","""{"handler":"E280Y2","iparms":[{"av":"AV43Id","fld":"vID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("'REVOKE-AUTHORIZE'",""","oparms":[{"av":"AV26ClientRevoked","fld":"vCLIENTREVOKED","pic":"99/99/9999 99:99"},{"ctrl":"BTNREVOKEALLOW","prop":"Caption"},{"av":"cmbavClientaccessstatus"},{"av":"AV123ClientAccessStatus","fld":"vCLIENTACCESSSTATUS"},{"av":"edtavClientrevoked_Visible","ctrl":"vCLIENTREVOKED","prop":"Visible"}]}""");
         setEventMetadata("'TRANSLATIONS'","""{"handler":"E290Y2","iparms":[{"av":"GRIDLANGUAGES_nFirstRecordOnPage"},{"av":"GRIDLANGUAGES_nEOF"},{"av":"subGridlanguages_Rows","ctrl":"GRIDLANGUAGES","prop":"Rows"},{"av":"chkavOnline.Enabled","ctrl":"vONLINE","prop":"Enabled"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV156ReturnMenuOptionsWithoutPermission","fld":"vRETURNMENUOPTIONSWITHOUTPERMISSION"},{"av":"AV61UseAbsoluteUrlByEnvironment","fld":"vUSEABSOLUTEURLBYENVIRONMENT"},{"av":"AV128ClientAuthRequestMustIncludeUserScopes","fld":"vCLIENTAUTHREQUESTMUSTINCLUDEUSERSCOPES"},{"av":"AV129ClientDoNotShareUserIDs","fld":"vCLIENTDONOTSHAREUSERIDS"},{"av":"AV17ClientAllowRemoteAuth","fld":"vCLIENTALLOWREMOTEAUTH"},{"av":"AV126ClientAllowGetUserData","fld":"vCLIENTALLOWGETUSERDATA"},{"av":"AV13ClientAllowGetUserAddData","fld":"vCLIENTALLOWGETUSERADDDATA"},{"av":"AV15ClientAllowGetUserRoles","fld":"vCLIENTALLOWGETUSERROLES"},{"av":"AV11ClientAllowGetSessionIniProp","fld":"vCLIENTALLOWGETSESSIONINIPROP"},{"av":"AV9ClientAllowGetSessionAppData","fld":"vCLIENTALLOWGETSESSIONAPPDATA"},{"av":"AV20ClientCallbackURLisCustom","fld":"vCLIENTCALLBACKURLISCUSTOM"},{"av":"AV18ClientAllowRemoteRestAuth","fld":"vCLIENTALLOWREMOTERESTAUTH"},{"av":"AV127ClientAllowGetUserDataREST","fld":"vCLIENTALLOWGETUSERDATAREST"},{"av":"AV14ClientAllowGetUserAddDataRest","fld":"vCLIENTALLOWGETUSERADDDATAREST"},{"av":"AV16ClientAllowGetUserRolesRest","fld":"vCLIENTALLOWGETUSERROLESREST"},{"av":"AV12ClientAllowGetSessionIniPropRest","fld":"vCLIENTALLOWGETSESSIONINIPROPREST"},{"av":"AV10ClientAllowGetSessionAppDataREST","fld":"vCLIENTALLOWGETSESSIONAPPDATAREST"},{"av":"AV8ClientAccessUniqueByUser","fld":"vCLIENTACCESSUNIQUEBYUSER"},{"av":"AV5AccessRequiresPermission","fld":"vACCESSREQUIRESPERMISSION"},{"av":"AV143IsAuthorizationDelegated","fld":"vISAUTHORIZATIONDELEGATED"},{"av":"AV50SSORestEnable","fld":"vSSORESTENABLE"},{"av":"AV159SSORestServerURL_isCustom","fld":"vSSORESTSERVERURL_ISCUSTOM"},{"av":"AV57STSProtocolEnable","fld":"vSTSPROTOCOLENABLE"},{"av":"AV148MiniAppEnable","fld":"vMINIAPPENABLE"},{"av":"AV147MiniAppClientURL_isCustom","fld":"vMINIAPPCLIENTURL_ISCUSTOM"},{"av":"AV152MiniAppServerURL_isCustom","fld":"vMINIAPPSERVERURL_ISCUSTOM"},{"av":"AV120APIKeyEnable","fld":"vAPIKEYENABLE"},{"av":"AV119APIKeyAllowScopeCustomization","fld":"vAPIKEYALLOWSCOPECUSTOMIZATION"},{"av":"AV36EnvironmentSecureProtocol","fld":"vENVIRONMENTSECUREPROTOCOL"},{"av":"AV7AutoRegisterAnomymousUser","fld":"vAUTOREGISTERANOMYMOUSUSER"},{"av":"AV49Name","fld":"vNAME"},{"av":"AV43Id","fld":"vID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VSSORESTENABLE.CONTROLVALUECHANGED","""{"handler":"E170Y2","iparms":[{"av":"AV50SSORestEnable","fld":"vSSORESTENABLE"},{"av":"cmbavSsorestmode"},{"av":"AV51SSORestMode","fld":"vSSORESTMODE"}]""");
         setEventMetadata("VSSORESTENABLE.CONTROLVALUECHANGED",""","oparms":[{"av":"divTblssorestmodeclient_Visible","ctrl":"TBLSSORESTMODECLIENT","prop":"Visible"},{"av":"divTablessorest_Visible","ctrl":"TABLESSOREST","prop":"Visible"}]}""");
         setEventMetadata("VSSORESTMODE.CONTROLVALUECHANGED","""{"handler":"E180Y2","iparms":[{"av":"AV50SSORestEnable","fld":"vSSORESTENABLE"},{"av":"cmbavSsorestmode"},{"av":"AV51SSORestMode","fld":"vSSORESTMODE"}]""");
         setEventMetadata("VSSORESTMODE.CONTROLVALUECHANGED",""","oparms":[{"av":"divTblssorestmodeclient_Visible","ctrl":"TBLSSORESTMODECLIENT","prop":"Visible"},{"av":"divTablessorest_Visible","ctrl":"TABLESSOREST","prop":"Visible"}]}""");
         setEventMetadata("VMINIAPPENABLE.CONTROLVALUECHANGED","""{"handler":"E190Y2","iparms":[{"av":"AV148MiniAppEnable","fld":"vMINIAPPENABLE"},{"av":"cmbavMiniappmode"},{"av":"AV149MiniAppMode","fld":"vMINIAPPMODE"},{"av":"cmbavMiniappuserauthenticationtypename"},{"av":"AV153MiniAppUserAuthenticationTypeName","fld":"vMINIAPPUSERAUTHENTICATIONTYPENAME"}]""");
         setEventMetadata("VMINIAPPENABLE.CONTROLVALUECHANGED",""","oparms":[{"av":"divTblminiappserver_Visible","ctrl":"TBLMINIAPPSERVER","prop":"Visible"},{"av":"divTblminiappclient_Visible","ctrl":"TBLMINIAPPCLIENT","prop":"Visible"},{"av":"divTblminiapp_Visible","ctrl":"TBLMINIAPP","prop":"Visible"},{"av":"cmbavMiniappuserauthenticationtypename"},{"av":"AV153MiniAppUserAuthenticationTypeName","fld":"vMINIAPPUSERAUTHENTICATIONTYPENAME"}]}""");
         setEventMetadata("VMINIAPPMODE.CONTROLVALUECHANGED","""{"handler":"E200Y2","iparms":[{"av":"AV148MiniAppEnable","fld":"vMINIAPPENABLE"},{"av":"cmbavMiniappmode"},{"av":"AV149MiniAppMode","fld":"vMINIAPPMODE"},{"av":"cmbavMiniappuserauthenticationtypename"},{"av":"AV153MiniAppUserAuthenticationTypeName","fld":"vMINIAPPUSERAUTHENTICATIONTYPENAME"}]""");
         setEventMetadata("VMINIAPPMODE.CONTROLVALUECHANGED",""","oparms":[{"av":"divTblminiappserver_Visible","ctrl":"TBLMINIAPPSERVER","prop":"Visible"},{"av":"divTblminiappclient_Visible","ctrl":"TBLMINIAPPCLIENT","prop":"Visible"},{"av":"divTblminiapp_Visible","ctrl":"TBLMINIAPP","prop":"Visible"},{"av":"cmbavMiniappuserauthenticationtypename"},{"av":"AV153MiniAppUserAuthenticationTypeName","fld":"vMINIAPPUSERAUTHENTICATIONTYPENAME"}]}""");
         setEventMetadata("VAPIKEYENABLE.CONTROLVALUECHANGED","""{"handler":"E210Y2","iparms":[{"av":"AV120APIKeyEnable","fld":"vAPIKEYENABLE"},{"av":"cmbavApikeyallowonlyauthenticationtypename"},{"av":"AV118APIKeyAllowOnlyAuthenticationTypeName","fld":"vAPIKEYALLOWONLYAUTHENTICATIONTYPENAME"}]""");
         setEventMetadata("VAPIKEYENABLE.CONTROLVALUECHANGED",""","oparms":[{"av":"divTblapikey_Visible","ctrl":"TBLAPIKEY","prop":"Visible"},{"av":"cmbavApikeyallowonlyauthenticationtypename"},{"av":"AV118APIKeyAllowOnlyAuthenticationTypeName","fld":"vAPIKEYALLOWONLYAUTHENTICATIONTYPENAME"}]}""");
         setEventMetadata("VSSORESTMODE.CLICK","""{"handler":"E220Y2","iparms":[{"av":"AV50SSORestEnable","fld":"vSSORESTENABLE"},{"av":"cmbavSsorestmode"},{"av":"AV51SSORestMode","fld":"vSSORESTMODE"}]""");
         setEventMetadata("VSSORESTMODE.CLICK",""","oparms":[{"av":"divTblssorestmodeclient_Visible","ctrl":"TBLSSORESTMODECLIENT","prop":"Visible"},{"av":"divTablessorest_Visible","ctrl":"TABLESSOREST","prop":"Visible"}]}""");
         setEventMetadata("VSTSMODE.CLICK","""{"handler":"E110Y1","iparms":[{"av":"cmbavStsmode"},{"av":"AV56STSMode","fld":"vSTSMODE"}]""");
         setEventMetadata("VSTSMODE.CLICK",""","oparms":[{"av":"divTablestsserverchecktoken_Visible","ctrl":"TABLESTSSERVERCHECKTOKEN","prop":"Visible"},{"av":"divTablestsclient_Visible","ctrl":"TABLESTSCLIENT","prop":"Visible"},{"av":"edtavStsserverclientpassword_Visible","ctrl":"vSTSSERVERCLIENTPASSWORD","prop":"Visible"},{"av":"divStsserverclientpassword_cell_Class","ctrl":"STSSERVERCLIENTPASSWORD_CELL","prop":"Class"},{"av":"divTablestsclientgettoken_Visible","ctrl":"TABLESTSCLIENTGETTOKEN","prop":"Visible"}]}""");
         setEventMetadata("VSSORESTENABLE.CLICK","""{"handler":"E230Y2","iparms":[{"av":"AV50SSORestEnable","fld":"vSSORESTENABLE"},{"av":"cmbavSsorestmode"},{"av":"AV51SSORestMode","fld":"vSSORESTMODE"}]""");
         setEventMetadata("VSSORESTENABLE.CLICK",""","oparms":[{"av":"divTblssorestmodeclient_Visible","ctrl":"TBLSSORESTMODECLIENT","prop":"Visible"},{"av":"divTablessorest_Visible","ctrl":"TABLESSOREST","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_CLIENTACCESSSTATUS","""{"handler":"Validv_Clientaccessstatus","iparms":[]}""");
         setEventMetadata("VALIDV_DELEGATEAUTHORIZATIONVERSION","""{"handler":"Validv_Delegateauthorizationversion","iparms":[]}""");
         setEventMetadata("VALIDV_SSORESTMODE","""{"handler":"Validv_Ssorestmode","iparms":[]}""");
         setEventMetadata("VALIDV_STSMODE","""{"handler":"Validv_Stsmode","iparms":[]}""");
         setEventMetadata("VALIDV_MINIAPPMODE","""{"handler":"Validv_Miniappmode","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Language","iparms":[]}""");
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
         wcpOGx_mode = "";
         Gridlanguagespaginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV139GridLanguagesAppliedFilters = "";
         Gridlanguages_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         TempTags = "";
         AV41GUID = "";
         AV49Name = "";
         AV30Dsc = "";
         AV64Version = "";
         AV28Company = "";
         AV29Copyright = "";
         AV42HomeObject = "";
         AV66AccountActivationObject = "";
         lblTextblocklogoutobject_Jsonclick = "";
         lblRemoteauthentication_title_Jsonclick = "";
         AV123ClientAccessStatus = "";
         AV26ClientRevoked = (DateTime)(DateTime.MinValue);
         AV22ClientId = "";
         lblTextblockclientsecret_Jsonclick = "";
         ucDvpanel_unnamedtable6 = new GXUserControl();
         AV124ClientAllowAdditionalScope = "";
         AV23ClientImageURL = "";
         AV24ClientLocalLoginURL = "";
         AV19ClientCallbackURL = "";
         AV65ClientCallbackURLStateName = "";
         ucDvpanel_unnamedtable7 = new GXUserControl();
         AV125ClientAllowAdditionalScopeREST = "";
         ucDvpanel_unnamedtable8 = new GXUserControl();
         lblTextblockclientencryptionkey_Jsonclick = "";
         AV25ClientRepositoryGUID = "";
         lblAuthorization_title_Jsonclick = "";
         AV134DelegateAuthorizationVersion = "";
         AV131DelegateAuthorizationFileName = "";
         AV133DelegateAuthorizationPackage = "";
         AV130DelegateAuthorizationClassName = "";
         AV132DelegateAuthorizationMethod = "";
         lblSsorest_title_Jsonclick = "";
         AV51SSORestMode = "";
         AV53SSORestUserAuthTypeName = "";
         AV52SSORestServerURL = "";
         AV160SSORestServerURL_SLO = "";
         AV158SSORestServerRepositoryGUID = "";
         AV157SSORestServerKey = "";
         lblSts_title_Jsonclick = "";
         AV56STSMode = "";
         AV55STSAuthorizationUserName = "";
         AV58STSServerClientPassword = "";
         AV60STSServerURL = "";
         AV59STSServerRepositoryGUID = "";
         lblMiniapp_title_Jsonclick = "";
         AV149MiniAppMode = "";
         AV146MiniAppClientURL = "";
         AV145MiniAppClientRepositoryGUID = "";
         AV153MiniAppUserAuthenticationTypeName = "";
         AV151MiniAppServerURL = "";
         AV150MiniAppServerRepositoryGUID = "";
         lblApikey_title_Jsonclick = "";
         AV118APIKeyAllowOnlyAuthenticationTypeName = "";
         lblEnvironmentsettings_title_Jsonclick = "";
         AV32EnvironmentName = "";
         AV31EnvironmentHost = "";
         AV37EnvironmentVirtualDirectory = "";
         AV35EnvironmentProgramPackage = "";
         AV34EnvironmentProgramExtension = "";
         lblLanguages_title_Jsonclick = "";
         GridlanguagesContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridlanguagespaginationbar = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         AV54STSAuthorizationUserGUID = "";
         ucGridlanguages_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV144Language = "";
         AV45LogoutObject = "";
         AV27ClientSecret = "";
         AV21ClientEncryptionKey = "";
         AV135GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV40GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV162GXV1 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu", "GeneXus.Programs");
         AV48MenuFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter(context);
         AV116GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV47Menu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV39Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV63UserErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV117Window = new GXWindow();
         AV38Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV136GAMAuthenticationTypeFilter = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter(context);
         AV166GXV5 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType", "GeneXus.Programs");
         AV122AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         AV168GXV7 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType", "GeneXus.Programs");
         AV170GXV9 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType", "GeneXus.Programs");
         AV138GAMLanguages = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage", "GeneXus.Programs");
         AV137GAMLanguage = new GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage(context);
         GridlanguagesRow = new GXWebRow();
         bttBtngeneratekeygamremote_Jsonclick = "";
         bttBtnchangeclientsecret_Jsonclick = "";
         bttBtnrevokeallow_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridlanguages_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridlanguagesColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamapplicationentry__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamapplicationentry__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavId_Enabled = 0;
         edtavGuid_Enabled = 0;
         edtavClientrevoked_Enabled = 0;
         chkavOnline.Enabled = 0;
         edtavLanguage_Enabled = 0;
      }

      private short GRIDLANGUAGES_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridlanguages_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGridlanguages_Backstyle ;
      private short subGridlanguages_Titlebackstyle ;
      private short subGridlanguages_Allowselection ;
      private short subGridlanguages_Allowhovering ;
      private short subGridlanguages_Allowcollapsing ;
      private short subGridlanguages_Collapsed ;
      private int Gridlanguagespaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_567 ;
      private int subGridlanguages_Recordcount ;
      private int subGridlanguages_Rows ;
      private int nGXsfl_567_idx=1 ;
      private int Gridlanguagespaginationbar_Pagestoshow ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtavId_Enabled ;
      private int edtavGuid_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavVersion_Enabled ;
      private int edtavCompany_Enabled ;
      private int edtavCopyright_Enabled ;
      private int edtavHomeobject_Enabled ;
      private int edtavAccountactivationobject_Enabled ;
      private int edtavClientrevoked_Visible ;
      private int edtavClientrevoked_Enabled ;
      private int edtavClientid_Enabled ;
      private int divTblwebauth_Visible ;
      private int edtavClientallowadditionalscope_Enabled ;
      private int edtavClientimageurl_Enabled ;
      private int edtavClientlocalloginurl_Enabled ;
      private int edtavClientcallbackurl_Enabled ;
      private int edtavClientcallbackurlstatename_Enabled ;
      private int divTblrestauth_Visible ;
      private int edtavClientallowadditionalscoperest_Enabled ;
      private int divTblgeneralauth_Visible ;
      private int edtavClientrepositoryguid_Enabled ;
      private int divTbldelegateauthorization_Visible ;
      private int divTbldelegateauthorizationprop_Visible ;
      private int edtavDelegateauthorizationfilename_Enabled ;
      private int edtavDelegateauthorizationpackage_Enabled ;
      private int edtavDelegateauthorizationclassname_Enabled ;
      private int edtavDelegateauthorizationmethod_Enabled ;
      private int divTablessorest_Visible ;
      private int divTblssorestmodeclient_Visible ;
      private int edtavSsorestuserauthtypename_Enabled ;
      private int edtavSsorestserverurl_Enabled ;
      private int edtavSsorestserverurl_slo_Enabled ;
      private int edtavSsorestserverrepositoryguid_Enabled ;
      private int edtavSsorestserverkey_Enabled ;
      private int divTablests_Visible ;
      private int divTablestsserverchecktoken_Visible ;
      private int edtavStsauthorizationusername_Enabled ;
      private int divTablestsclientgettoken_Visible ;
      private int edtavStsserverclientpassword_Visible ;
      private int edtavStsserverclientpassword_Enabled ;
      private int divTablestsclient_Visible ;
      private int edtavStsserverurl_Enabled ;
      private int edtavStsserverrepositoryguid_Enabled ;
      private int divTblminiapp_Visible ;
      private int divTblminiappserver_Visible ;
      private int edtavMiniappclienturl_Enabled ;
      private int edtavMiniappclientrepositoryguid_Enabled ;
      private int divTblminiappclient_Visible ;
      private int edtavMiniappserverurl_Enabled ;
      private int edtavMiniappserverrepositoryguid_Enabled ;
      private int divTblapikey_Visible ;
      private int AV121APIKeyTimeout ;
      private int edtavApikeytimeout_Enabled ;
      private int edtavEnvironmentname_Enabled ;
      private int edtavEnvironmenthost_Enabled ;
      private int AV33EnvironmentPort ;
      private int edtavEnvironmentport_Enabled ;
      private int edtavEnvironmentvirtualdirectory_Enabled ;
      private int edtavEnvironmentprogrampackage_Enabled ;
      private int edtavEnvironmentprogramextension_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavGridlanguagescurrentpage_Visible ;
      private int edtavStsauthorizationuserguid_Visible ;
      private int subGridlanguages_Islastpage ;
      private int edtavLanguage_Enabled ;
      private int GRIDLANGUAGES_nGridOutOfScope ;
      private int bttBtnchangeclientsecret_Visible ;
      private int edtavClientsecret_Enabled ;
      private int AV163GXV2 ;
      private int edtavLogoutobject_Enabled ;
      private int edtavClientencryptionkey_Enabled ;
      private int bttBtngeneratekeygamremote_Visible ;
      private int AV155PageToGo ;
      private int AV164GXV3 ;
      private int AV165GXV4 ;
      private int AV167GXV6 ;
      private int AV169GXV8 ;
      private int AV171GXV10 ;
      private int AV172GXV11 ;
      private int nGXsfl_567_fel_idx=1 ;
      private int AV174GXV12 ;
      private int idxLst ;
      private int subGridlanguages_Backcolor ;
      private int subGridlanguages_Allbackcolor ;
      private int subGridlanguages_Titlebackcolor ;
      private int subGridlanguages_Selectedindex ;
      private int subGridlanguages_Selectioncolor ;
      private int subGridlanguages_Hoveringcolor ;
      private long AV43Id ;
      private long wcpOAV43Id ;
      private long GRIDLANGUAGES_nFirstRecordOnPage ;
      private long AV141GridLanguagesPageCount ;
      private long AV46MainMenu ;
      private long AV140GridLanguagesCurrentPage ;
      private long GRIDLANGUAGES_nCurrentRecord ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string Gridlanguagespaginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_567_idx="0001" ;
      private string chkavOnline_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_unnamedtable6_Width ;
      private string Dvpanel_unnamedtable6_Cls ;
      private string Dvpanel_unnamedtable6_Title ;
      private string Dvpanel_unnamedtable6_Iconposition ;
      private string Dvpanel_unnamedtable7_Width ;
      private string Dvpanel_unnamedtable7_Cls ;
      private string Dvpanel_unnamedtable7_Title ;
      private string Dvpanel_unnamedtable7_Iconposition ;
      private string Dvpanel_unnamedtable8_Width ;
      private string Dvpanel_unnamedtable8_Cls ;
      private string Dvpanel_unnamedtable8_Title ;
      private string Dvpanel_unnamedtable8_Iconposition ;
      private string Gridlanguagespaginationbar_Class ;
      private string Gridlanguagespaginationbar_Pagingbuttonsposition ;
      private string Gridlanguagespaginationbar_Pagingcaptionposition ;
      private string Gridlanguagespaginationbar_Emptygridclass ;
      private string Gridlanguagespaginationbar_Rowsperpageoptions ;
      private string Gridlanguagespaginationbar_Previous ;
      private string Gridlanguagespaginationbar_Next ;
      private string Gridlanguagespaginationbar_Caption ;
      private string Gridlanguagespaginationbar_Emptygridcaption ;
      private string Gridlanguagespaginationbar_Rowsperpagecaption ;
      private string Gxuitabspanel_tabs_Class ;
      private string Gridlanguages_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divLefttable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divUnnamedtable9_Internalname ;
      private string edtavId_Internalname ;
      private string TempTags ;
      private string edtavId_Jsonclick ;
      private string edtavGuid_Internalname ;
      private string AV41GUID ;
      private string edtavGuid_Jsonclick ;
      private string edtavName_Internalname ;
      private string AV49Name ;
      private string edtavName_Jsonclick ;
      private string edtavDsc_Internalname ;
      private string AV30Dsc ;
      private string edtavDsc_Jsonclick ;
      private string edtavVersion_Internalname ;
      private string AV64Version ;
      private string edtavVersion_Jsonclick ;
      private string edtavCompany_Internalname ;
      private string AV28Company ;
      private string edtavCompany_Jsonclick ;
      private string edtavCopyright_Internalname ;
      private string AV29Copyright ;
      private string edtavCopyright_Jsonclick ;
      private string chkavReturnmenuoptionswithoutpermission_Internalname ;
      private string cmbavMainmenu_Internalname ;
      private string cmbavMainmenu_Jsonclick ;
      private string chkavUseabsoluteurlbyenvironment_Internalname ;
      private string edtavHomeobject_Internalname ;
      private string edtavHomeobject_Jsonclick ;
      private string edtavAccountactivationobject_Internalname ;
      private string edtavAccountactivationobject_Jsonclick ;
      private string divTablesplittedlogoutobject_Internalname ;
      private string lblTextblocklogoutobject_Internalname ;
      private string lblTextblocklogoutobject_Jsonclick ;
      private string lblRemoteauthentication_title_Internalname ;
      private string lblRemoteauthentication_title_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string cmbavClientaccessstatus_Internalname ;
      private string AV123ClientAccessStatus ;
      private string cmbavClientaccessstatus_Jsonclick ;
      private string edtavClientrevoked_Internalname ;
      private string edtavClientrevoked_Jsonclick ;
      private string edtavClientid_Internalname ;
      private string AV22ClientId ;
      private string edtavClientid_Jsonclick ;
      private string divTablesplittedclientsecret_Internalname ;
      private string lblTextblockclientsecret_Internalname ;
      private string lblTextblockclientsecret_Jsonclick ;
      private string chkavClientauthrequestmustincludeuserscopes_Internalname ;
      private string chkavClientdonotshareuserids_Internalname ;
      private string Dvpanel_unnamedtable6_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string chkavClientallowremoteauth_Internalname ;
      private string divTblwebauth_Internalname ;
      private string chkavClientallowgetuserdata_Internalname ;
      private string chkavClientallowgetuseradddata_Internalname ;
      private string chkavClientallowgetuserroles_Internalname ;
      private string chkavClientallowgetsessioniniprop_Internalname ;
      private string chkavClientallowgetsessionappdata_Internalname ;
      private string edtavClientallowadditionalscope_Internalname ;
      private string edtavClientallowadditionalscope_Jsonclick ;
      private string edtavClientimageurl_Internalname ;
      private string edtavClientimageurl_Jsonclick ;
      private string edtavClientlocalloginurl_Internalname ;
      private string edtavClientlocalloginurl_Jsonclick ;
      private string edtavClientcallbackurl_Internalname ;
      private string edtavClientcallbackurl_Jsonclick ;
      private string chkavClientcallbackurliscustom_Internalname ;
      private string edtavClientcallbackurlstatename_Internalname ;
      private string AV65ClientCallbackURLStateName ;
      private string edtavClientcallbackurlstatename_Jsonclick ;
      private string Dvpanel_unnamedtable7_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string chkavClientallowremoterestauth_Internalname ;
      private string divTblrestauth_Internalname ;
      private string chkavClientallowgetuserdatarest_Internalname ;
      private string chkavClientallowgetuseradddatarest_Internalname ;
      private string chkavClientallowgetuserrolesrest_Internalname ;
      private string chkavClientallowgetsessioniniproprest_Internalname ;
      private string chkavClientallowgetsessionappdatarest_Internalname ;
      private string edtavClientallowadditionalscoperest_Internalname ;
      private string edtavClientallowadditionalscoperest_Jsonclick ;
      private string divTblgeneralauth_Internalname ;
      private string Dvpanel_unnamedtable8_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string chkavClientaccessuniquebyuser_Internalname ;
      private string divTablesplittedclientencryptionkey_Internalname ;
      private string lblTextblockclientencryptionkey_Internalname ;
      private string lblTextblockclientencryptionkey_Jsonclick ;
      private string edtavClientrepositoryguid_Internalname ;
      private string AV25ClientRepositoryGUID ;
      private string edtavClientrepositoryguid_Jsonclick ;
      private string lblAuthorization_title_Internalname ;
      private string lblAuthorization_title_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string chkavAccessrequirespermission_Internalname ;
      private string divTbldelegateauthorization_Internalname ;
      private string chkavIsauthorizationdelegated_Internalname ;
      private string divTbldelegateauthorizationprop_Internalname ;
      private string cmbavDelegateauthorizationversion_Internalname ;
      private string AV134DelegateAuthorizationVersion ;
      private string cmbavDelegateauthorizationversion_Jsonclick ;
      private string edtavDelegateauthorizationfilename_Internalname ;
      private string AV131DelegateAuthorizationFileName ;
      private string edtavDelegateauthorizationfilename_Jsonclick ;
      private string edtavDelegateauthorizationpackage_Internalname ;
      private string AV133DelegateAuthorizationPackage ;
      private string edtavDelegateauthorizationpackage_Jsonclick ;
      private string edtavDelegateauthorizationclassname_Internalname ;
      private string AV130DelegateAuthorizationClassName ;
      private string edtavDelegateauthorizationclassname_Jsonclick ;
      private string edtavDelegateauthorizationmethod_Internalname ;
      private string AV132DelegateAuthorizationMethod ;
      private string edtavDelegateauthorizationmethod_Jsonclick ;
      private string lblSsorest_title_Internalname ;
      private string lblSsorest_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string chkavSsorestenable_Internalname ;
      private string divTablessorest_Internalname ;
      private string cmbavSsorestmode_Internalname ;
      private string AV51SSORestMode ;
      private string cmbavSsorestmode_Jsonclick ;
      private string divTblssorestmodeclient_Internalname ;
      private string edtavSsorestuserauthtypename_Internalname ;
      private string AV53SSORestUserAuthTypeName ;
      private string edtavSsorestuserauthtypename_Jsonclick ;
      private string edtavSsorestserverurl_Internalname ;
      private string edtavSsorestserverurl_Jsonclick ;
      private string chkavSsorestserverurl_iscustom_Internalname ;
      private string edtavSsorestserverurl_slo_Internalname ;
      private string edtavSsorestserverurl_slo_Jsonclick ;
      private string edtavSsorestserverrepositoryguid_Internalname ;
      private string AV158SSORestServerRepositoryGUID ;
      private string edtavSsorestserverrepositoryguid_Jsonclick ;
      private string edtavSsorestserverkey_Internalname ;
      private string AV157SSORestServerKey ;
      private string edtavSsorestserverkey_Jsonclick ;
      private string lblSts_title_Internalname ;
      private string lblSts_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string chkavStsprotocolenable_Internalname ;
      private string divTablests_Internalname ;
      private string cmbavStsmode_Internalname ;
      private string AV56STSMode ;
      private string cmbavStsmode_Jsonclick ;
      private string divTablestsserverchecktoken_Internalname ;
      private string edtavStsauthorizationusername_Internalname ;
      private string edtavStsauthorizationusername_Jsonclick ;
      private string divTablestsclientgettoken_Internalname ;
      private string divStsserverclientpassword_cell_Internalname ;
      private string divStsserverclientpassword_cell_Class ;
      private string edtavStsserverclientpassword_Internalname ;
      private string AV58STSServerClientPassword ;
      private string edtavStsserverclientpassword_Jsonclick ;
      private string divTablestsclient_Internalname ;
      private string edtavStsserverurl_Internalname ;
      private string edtavStsserverurl_Jsonclick ;
      private string edtavStsserverrepositoryguid_Internalname ;
      private string AV59STSServerRepositoryGUID ;
      private string edtavStsserverrepositoryguid_Jsonclick ;
      private string lblMiniapp_title_Internalname ;
      private string lblMiniapp_title_Jsonclick ;
      private string divMiniapptable1_Internalname ;
      private string chkavMiniappenable_Internalname ;
      private string divTblminiapp_Internalname ;
      private string cmbavMiniappmode_Internalname ;
      private string AV149MiniAppMode ;
      private string cmbavMiniappmode_Jsonclick ;
      private string divTblminiappserver_Internalname ;
      private string edtavMiniappclienturl_Internalname ;
      private string edtavMiniappclienturl_Jsonclick ;
      private string chkavMiniappclienturl_iscustom_Internalname ;
      private string edtavMiniappclientrepositoryguid_Internalname ;
      private string AV145MiniAppClientRepositoryGUID ;
      private string edtavMiniappclientrepositoryguid_Jsonclick ;
      private string divTblminiappclient_Internalname ;
      private string cmbavMiniappuserauthenticationtypename_Internalname ;
      private string AV153MiniAppUserAuthenticationTypeName ;
      private string cmbavMiniappuserauthenticationtypename_Jsonclick ;
      private string edtavMiniappserverurl_Internalname ;
      private string edtavMiniappserverurl_Jsonclick ;
      private string chkavMiniappserverurl_iscustom_Internalname ;
      private string edtavMiniappserverrepositoryguid_Internalname ;
      private string AV150MiniAppServerRepositoryGUID ;
      private string edtavMiniappserverrepositoryguid_Jsonclick ;
      private string lblApikey_title_Internalname ;
      private string lblApikey_title_Jsonclick ;
      private string divApikeytable1_Internalname ;
      private string chkavApikeyenable_Internalname ;
      private string divTblapikey_Internalname ;
      private string edtavApikeytimeout_Internalname ;
      private string edtavApikeytimeout_Jsonclick ;
      private string cmbavApikeyallowonlyauthenticationtypename_Internalname ;
      private string AV118APIKeyAllowOnlyAuthenticationTypeName ;
      private string cmbavApikeyallowonlyauthenticationtypename_Jsonclick ;
      private string chkavApikeyallowscopecustomization_Internalname ;
      private string lblEnvironmentsettings_title_Internalname ;
      private string lblEnvironmentsettings_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string edtavEnvironmentname_Internalname ;
      private string AV32EnvironmentName ;
      private string edtavEnvironmentname_Jsonclick ;
      private string chkavEnvironmentsecureprotocol_Internalname ;
      private string edtavEnvironmenthost_Internalname ;
      private string AV31EnvironmentHost ;
      private string edtavEnvironmenthost_Jsonclick ;
      private string edtavEnvironmentport_Internalname ;
      private string edtavEnvironmentport_Jsonclick ;
      private string edtavEnvironmentvirtualdirectory_Internalname ;
      private string AV37EnvironmentVirtualDirectory ;
      private string edtavEnvironmentvirtualdirectory_Jsonclick ;
      private string edtavEnvironmentprogrampackage_Internalname ;
      private string AV35EnvironmentProgramPackage ;
      private string edtavEnvironmentprogrampackage_Jsonclick ;
      private string edtavEnvironmentprogramextension_Internalname ;
      private string AV34EnvironmentProgramExtension ;
      private string edtavEnvironmentprogramextension_Jsonclick ;
      private string lblLanguages_title_Internalname ;
      private string lblLanguages_title_Jsonclick ;
      private string divLanguagestable1_Internalname ;
      private string divGridlanguagestablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGridlanguages_Internalname ;
      private string Gridlanguagespaginationbar_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavGridlanguagescurrentpage_Internalname ;
      private string edtavGridlanguagescurrentpage_Jsonclick ;
      private string chkavAutoregisteranomymoususer_Internalname ;
      private string edtavStsauthorizationuserguid_Internalname ;
      private string AV54STSAuthorizationUserGUID ;
      private string edtavStsauthorizationuserguid_Jsonclick ;
      private string Gridlanguages_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLanguage_Internalname ;
      private string edtavLogoutobject_Internalname ;
      private string AV27ClientSecret ;
      private string edtavClientsecret_Internalname ;
      private string AV21ClientEncryptionKey ;
      private string edtavClientencryptionkey_Internalname ;
      private string bttBtnchangeclientsecret_Internalname ;
      private string bttBtngeneratekeygamremote_Internalname ;
      private string bttBtnrevokeallow_Caption ;
      private string bttBtnrevokeallow_Internalname ;
      private string sGXsfl_567_fel_idx="0001" ;
      private string tblTablemergedclientencryptionkey_Internalname ;
      private string edtavClientencryptionkey_Jsonclick ;
      private string bttBtngeneratekeygamremote_Jsonclick ;
      private string tblTablemergedclientsecret_Internalname ;
      private string edtavClientsecret_Jsonclick ;
      private string bttBtnchangeclientsecret_Jsonclick ;
      private string tblTablemergedlogoutobject_Internalname ;
      private string edtavLogoutobject_Jsonclick ;
      private string bttBtnrevokeallow_Jsonclick ;
      private string subGridlanguages_Class ;
      private string subGridlanguages_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavLanguage_Jsonclick ;
      private string subGridlanguages_Header ;
      private DateTime AV26ClientRevoked ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_567_Refreshing=false ;
      private bool AV156ReturnMenuOptionsWithoutPermission ;
      private bool AV61UseAbsoluteUrlByEnvironment ;
      private bool AV128ClientAuthRequestMustIncludeUserScopes ;
      private bool AV129ClientDoNotShareUserIDs ;
      private bool AV17ClientAllowRemoteAuth ;
      private bool AV126ClientAllowGetUserData ;
      private bool AV13ClientAllowGetUserAddData ;
      private bool AV15ClientAllowGetUserRoles ;
      private bool AV11ClientAllowGetSessionIniProp ;
      private bool AV9ClientAllowGetSessionAppData ;
      private bool AV20ClientCallbackURLisCustom ;
      private bool AV18ClientAllowRemoteRestAuth ;
      private bool AV127ClientAllowGetUserDataREST ;
      private bool AV14ClientAllowGetUserAddDataRest ;
      private bool AV16ClientAllowGetUserRolesRest ;
      private bool AV12ClientAllowGetSessionIniPropRest ;
      private bool AV10ClientAllowGetSessionAppDataREST ;
      private bool AV8ClientAccessUniqueByUser ;
      private bool AV5AccessRequiresPermission ;
      private bool AV143IsAuthorizationDelegated ;
      private bool AV50SSORestEnable ;
      private bool AV159SSORestServerURL_isCustom ;
      private bool AV57STSProtocolEnable ;
      private bool AV148MiniAppEnable ;
      private bool AV147MiniAppClientURL_isCustom ;
      private bool AV152MiniAppServerURL_isCustom ;
      private bool AV120APIKeyEnable ;
      private bool AV119APIKeyAllowScopeCustomization ;
      private bool AV36EnvironmentSecureProtocol ;
      private bool AV7AutoRegisterAnomymousUser ;
      private bool Dvpanel_unnamedtable6_Autowidth ;
      private bool Dvpanel_unnamedtable6_Autoheight ;
      private bool Dvpanel_unnamedtable6_Collapsible ;
      private bool Dvpanel_unnamedtable6_Collapsed ;
      private bool Dvpanel_unnamedtable6_Showcollapseicon ;
      private bool Dvpanel_unnamedtable6_Autoscroll ;
      private bool Dvpanel_unnamedtable7_Autowidth ;
      private bool Dvpanel_unnamedtable7_Autoheight ;
      private bool Dvpanel_unnamedtable7_Collapsible ;
      private bool Dvpanel_unnamedtable7_Collapsed ;
      private bool Dvpanel_unnamedtable7_Showcollapseicon ;
      private bool Dvpanel_unnamedtable7_Autoscroll ;
      private bool Dvpanel_unnamedtable8_Autowidth ;
      private bool Dvpanel_unnamedtable8_Autoheight ;
      private bool Dvpanel_unnamedtable8_Collapsible ;
      private bool Dvpanel_unnamedtable8_Collapsed ;
      private bool Dvpanel_unnamedtable8_Showcollapseicon ;
      private bool Dvpanel_unnamedtable8_Autoscroll ;
      private bool Gridlanguagespaginationbar_Showfirst ;
      private bool Gridlanguagespaginationbar_Showprevious ;
      private bool Gridlanguagespaginationbar_Shownext ;
      private bool Gridlanguagespaginationbar_Showlast ;
      private bool Gridlanguagespaginationbar_Rowsperpageselector ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV154Online ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV44isOk ;
      private string AV139GridLanguagesAppliedFilters ;
      private string AV42HomeObject ;
      private string AV66AccountActivationObject ;
      private string AV124ClientAllowAdditionalScope ;
      private string AV23ClientImageURL ;
      private string AV24ClientLocalLoginURL ;
      private string AV19ClientCallbackURL ;
      private string AV125ClientAllowAdditionalScopeREST ;
      private string AV52SSORestServerURL ;
      private string AV160SSORestServerURL_SLO ;
      private string AV55STSAuthorizationUserName ;
      private string AV60STSServerURL ;
      private string AV146MiniAppClientURL ;
      private string AV151MiniAppServerURL ;
      private string AV144Language ;
      private string AV45LogoutObject ;
      private GXWebGrid GridlanguagesContainer ;
      private GXWebRow GridlanguagesRow ;
      private GXWebColumn GridlanguagesColumn ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXUserControl ucDvpanel_unnamedtable6 ;
      private GXUserControl ucDvpanel_unnamedtable7 ;
      private GXUserControl ucDvpanel_unnamedtable8 ;
      private GXUserControl ucGridlanguagespaginationbar ;
      private GXUserControl ucGridlanguages_empowerer ;
      private GXWebForm Form ;
      private GXWindow AV117Window ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private long aP1_Id ;
      private GXCheckbox chkavReturnmenuoptionswithoutpermission ;
      private GXCombobox cmbavMainmenu ;
      private GXCheckbox chkavUseabsoluteurlbyenvironment ;
      private GXCombobox cmbavClientaccessstatus ;
      private GXCheckbox chkavClientauthrequestmustincludeuserscopes ;
      private GXCheckbox chkavClientdonotshareuserids ;
      private GXCheckbox chkavClientallowremoteauth ;
      private GXCheckbox chkavClientallowgetuserdata ;
      private GXCheckbox chkavClientallowgetuseradddata ;
      private GXCheckbox chkavClientallowgetuserroles ;
      private GXCheckbox chkavClientallowgetsessioniniprop ;
      private GXCheckbox chkavClientallowgetsessionappdata ;
      private GXCheckbox chkavClientcallbackurliscustom ;
      private GXCheckbox chkavClientallowremoterestauth ;
      private GXCheckbox chkavClientallowgetuserdatarest ;
      private GXCheckbox chkavClientallowgetuseradddatarest ;
      private GXCheckbox chkavClientallowgetuserrolesrest ;
      private GXCheckbox chkavClientallowgetsessioniniproprest ;
      private GXCheckbox chkavClientallowgetsessionappdatarest ;
      private GXCheckbox chkavClientaccessuniquebyuser ;
      private GXCheckbox chkavAccessrequirespermission ;
      private GXCheckbox chkavIsauthorizationdelegated ;
      private GXCombobox cmbavDelegateauthorizationversion ;
      private GXCheckbox chkavSsorestenable ;
      private GXCombobox cmbavSsorestmode ;
      private GXCheckbox chkavSsorestserverurl_iscustom ;
      private GXCheckbox chkavStsprotocolenable ;
      private GXCombobox cmbavStsmode ;
      private GXCheckbox chkavMiniappenable ;
      private GXCombobox cmbavMiniappmode ;
      private GXCheckbox chkavMiniappclienturl_iscustom ;
      private GXCombobox cmbavMiniappuserauthenticationtypename ;
      private GXCheckbox chkavMiniappserverurl_iscustom ;
      private GXCheckbox chkavApikeyenable ;
      private GXCombobox cmbavApikeyallowonlyauthenticationtypename ;
      private GXCheckbox chkavApikeyallowscopecustomization ;
      private GXCheckbox chkavEnvironmentsecureprotocol ;
      private GXCheckbox chkavOnline ;
      private GXCheckbox chkavAutoregisteranomymoususer ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV135GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV40GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu> AV162GXV1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuFilter AV48MenuFilter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV116GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV47Menu ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV39Errors ;
      private IDataStoreProvider pr_default ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV63UserErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV38Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter AV136GAMAuthenticationTypeFilter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType> AV166GXV5 ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV122AuthenticationType ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType> AV168GXV7 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType> AV170GXV9 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage> AV138GAMLanguages ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage AV137GAMLanguage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamapplicationentry__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class gamapplicationentry__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
