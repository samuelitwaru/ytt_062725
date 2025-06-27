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
   public class gamwcauthenticationtypeentryoauth20 : GXWebComponent
   {
      public gamwcauthenticationtypeentryoauth20( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public gamwcauthenticationtypeentryoauth20( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref string aP1_Name ,
                           ref string aP2_TypeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV34Name = aP1_Name;
         this.AV68TypeId = aP2_TypeId;
         ExecuteImpl();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Name=this.AV34Name;
         aP2_TypeId=this.AV68TypeId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavIdp = new GXCombobox();
         cmbavFunctionid = new GXCombobox();
         chkavIsenable = new GXCheckbox();
         cmbavImpersonate = new GXCombobox();
         chkavOauth20redirecturliscustom = new GXCheckbox();
         chkavOauth20redirecturl_autocompletevirtualdirectory = new GXCheckbox();
         chkavOauth20redirecttoauthenticate = new GXCheckbox();
         chkavAuthresptypeinclude = new GXCheckbox();
         chkavAuthscopeinclude = new GXCheckbox();
         chkavAuthstateinclude = new GXCheckbox();
         chkavAuthclientidinclude = new GXCheckbox();
         chkavAuthclientsecretinclude = new GXCheckbox();
         chkavAuthredirurlinclude = new GXCheckbox();
         chkavAuthopenidconnectprotocolenable = new GXCheckbox();
         chkavAuthvalididtoken = new GXCheckbox();
         chkavAuthallowonlyuseremailverified = new GXCheckbox();
         cmbavTokenmethod = new GXCombobox();
         chkavTokenheaderauthenticationinclude = new GXCheckbox();
         chkavTokenheaderauthorizationbasicinclude = new GXCheckbox();
         cmbavTokenheaderauthenticationmethod = new GXCombobox();
         chkavTokengranttypeinclude = new GXCheckbox();
         chkavTokenaccesscodeinclude = new GXCheckbox();
         chkavTokencliidinclude = new GXCheckbox();
         chkavTokenclisecretinclude = new GXCheckbox();
         chkavTokenredirecturlinclude = new GXCheckbox();
         chkavAutovalidateexternaltokenandrefresh = new GXCheckbox();
         cmbavUserinfomethod = new GXCombobox();
         chkavUserinfoaccesstokeninclude = new GXCheckbox();
         chkavUserinfoclientidinclude = new GXCheckbox();
         chkavUserinfoclientsecretinclude = new GXCheckbox();
         chkavUserinfouseridinclude = new GXCheckbox();
         chkavUserinforesponseuserlastnamegenauto = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  Gx_mode = GetPar( "Mode");
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  AV34Name = GetPar( "Name");
                  AssignAttri(sPrefix, false, "AV34Name", AV34Name);
                  AV68TypeId = GetPar( "TypeId");
                  AssignAttri(sPrefix, false, "AV68TypeId", AV68TypeId);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV34Name,(string)AV68TypeId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_548 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_548"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_548_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_548_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_548_idx = GetPar( "sGXsfl_548_idx");
         sPrefix = GetPar( "sPrefix");
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
         Gx_mode = GetPar( "Mode");
         AV33IsEnable = StringUtil.StrToBool( GetPar( "IsEnable"));
         AV40Oauth20RedirectURLisCustom = StringUtil.StrToBool( GetPar( "Oauth20RedirectURLisCustom"));
         AV111Oauth20RedirectURL_AutocompleteVirtualDirectory = StringUtil.StrToBool( GetPar( "Oauth20RedirectURL_AutocompleteVirtualDirectory"));
         AV39Oauth20RedirectToAuthenticate = StringUtil.StrToBool( GetPar( "Oauth20RedirectToAuthenticate"));
         AV14AuthRespTypeInclude = StringUtil.StrToBool( GetPar( "AuthRespTypeInclude"));
         AV17AuthScopeInclude = StringUtil.StrToBool( GetPar( "AuthScopeInclude"));
         AV98AuthStateInclude = StringUtil.StrToBool( GetPar( "AuthStateInclude"));
         AV7AuthClientIdInclude = StringUtil.StrToBool( GetPar( "AuthClientIdInclude"));
         AV8AuthClientSecretInclude = StringUtil.StrToBool( GetPar( "AuthClientSecretInclude"));
         AV99AuthRedirURLInclude = StringUtil.StrToBool( GetPar( "AuthRedirURLInclude"));
         AV109AuthOpenIDConnectProtocolEnable = StringUtil.StrToBool( GetPar( "AuthOpenIDConnectProtocolEnable"));
         AV110AuthValidIdToken = StringUtil.StrToBool( GetPar( "AuthValidIdToken"));
         AV106AuthAllowOnlyUserEmailVerified = StringUtil.StrToBool( GetPar( "AuthAllowOnlyUserEmailVerified"));
         AV51TokenHeaderAuthenticationInclude = StringUtil.StrToBool( GetPar( "TokenHeaderAuthenticationInclude"));
         AV54TokenHeaderAuthorizationBasicInclude = StringUtil.StrToBool( GetPar( "TokenHeaderAuthorizationBasicInclude"));
         AV48TokenGrantTypeInclude = StringUtil.StrToBool( GetPar( "TokenGrantTypeInclude"));
         AV44TokenAccessCodeInclude = StringUtil.StrToBool( GetPar( "TokenAccessCodeInclude"));
         AV46TokenCliIdInclude = StringUtil.StrToBool( GetPar( "TokenCliIdInclude"));
         AV47TokenCliSecretInclude = StringUtil.StrToBool( GetPar( "TokenCliSecretInclude"));
         AV58TokenRedirectURLInclude = StringUtil.StrToBool( GetPar( "TokenRedirectURLInclude"));
         AV22AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( GetPar( "AutovalidateExternalTokenAndRefresh"));
         AV69UserInfoAccessTokenInclude = StringUtil.StrToBool( GetPar( "UserInfoAccessTokenInclude"));
         AV72UserInfoClientIdInclude = StringUtil.StrToBool( GetPar( "UserInfoClientIdInclude"));
         AV74UserInfoClientSecretInclude = StringUtil.StrToBool( GetPar( "UserInfoClientSecretInclude"));
         AV95UserInfoUserIdInclude = StringUtil.StrToBool( GetPar( "UserInfoUserIdInclude"));
         AV87UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( GetPar( "UserInfoResponseUserLastNameGenAuto"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV33IsEnable, AV40Oauth20RedirectURLisCustom, AV111Oauth20RedirectURL_AutocompleteVirtualDirectory, AV39Oauth20RedirectToAuthenticate, AV14AuthRespTypeInclude, AV17AuthScopeInclude, AV98AuthStateInclude, AV7AuthClientIdInclude, AV8AuthClientSecretInclude, AV99AuthRedirURLInclude, AV109AuthOpenIDConnectProtocolEnable, AV110AuthValidIdToken, AV106AuthAllowOnlyUserEmailVerified, AV51TokenHeaderAuthenticationInclude, AV54TokenHeaderAuthorizationBasicInclude, AV48TokenGrantTypeInclude, AV44TokenAccessCodeInclude, AV46TokenCliIdInclude, AV47TokenCliSecretInclude, AV58TokenRedirectURLInclude, AV22AutovalidateExternalTokenAndRefresh, AV69UserInfoAccessTokenInclude, AV72UserInfoClientIdInclude, AV74UserInfoClientSecretInclude, AV95UserInfoUserIdInclude, AV87UserInfoResponseUserLastNameGenAuto, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA142( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS142( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Authentication Type Entry Oauth20") ;
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
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamwcauthenticationtypeentryoauth20.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV34Name)),UrlEncode(StringUtil.RTrim(AV68TypeId))}, new string[] {"Gx_mode","Name","TypeId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_548", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_548), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV34Name", StringUtil.RTrim( wcpOAV34Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV68TypeId", StringUtil.RTrim( wcpOAV68TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNAMEINIT", StringUtil.RTrim( AV155NameInit));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV105CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vAUTHSTATEINCUDE", AV20AuthStateIncude);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTYPEID", StringUtil.RTrim( AV68TypeId));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Width", StringUtil.RTrim( Dvpanel_groupauthopenidconnecttable1_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_groupauthopenidconnecttable1_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_groupauthopenidconnecttable1_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Cls", StringUtil.RTrim( Dvpanel_groupauthopenidconnecttable1_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Title", StringUtil.RTrim( Dvpanel_groupauthopenidconnecttable1_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_groupauthopenidconnecttable1_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_groupauthopenidconnecttable1_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_groupauthopenidconnecttable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_groupauthopenidconnecttable1_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_groupauthopenidconnecttable1_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE14_Width", StringUtil.RTrim( Dvpanel_unnamedtable14_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE14_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable14_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE14_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable14_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE14_Cls", StringUtil.RTrim( Dvpanel_unnamedtable14_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE14_Title", StringUtil.RTrim( Dvpanel_unnamedtable14_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE14_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable14_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE14_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable14_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE14_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable14_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE14_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable14_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE14_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable14_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE13_Width", StringUtil.RTrim( Dvpanel_unnamedtable13_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE13_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable13_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE13_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable13_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE13_Cls", StringUtil.RTrim( Dvpanel_unnamedtable13_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE13_Title", StringUtil.RTrim( Dvpanel_unnamedtable13_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE13_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable13_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE13_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable13_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE13_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable13_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE13_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable13_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE13_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable13_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Width", StringUtil.RTrim( Dvpanel_unnamedtable7_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Cls", StringUtil.RTrim( Dvpanel_unnamedtable7_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Title", StringUtil.RTrim( Dvpanel_unnamedtable7_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable7_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE7_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable7_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Width", StringUtil.RTrim( Dvpanel_unnamedtable9_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Cls", StringUtil.RTrim( Dvpanel_unnamedtable9_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Title", StringUtil.RTrim( Dvpanel_unnamedtable9_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable9_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE9_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable9_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Width", StringUtil.RTrim( Dvpanel_unnamedtable10_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Cls", StringUtil.RTrim( Dvpanel_unnamedtable10_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Title", StringUtil.RTrim( Dvpanel_unnamedtable10_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable10_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE10_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable10_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE11_Width", StringUtil.RTrim( Dvpanel_unnamedtable11_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE11_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable11_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE11_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable11_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE11_Cls", StringUtil.RTrim( Dvpanel_unnamedtable11_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE11_Title", StringUtil.RTrim( Dvpanel_unnamedtable11_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE11_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable11_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE11_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable11_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE11_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable11_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE11_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable11_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE11_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable11_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Width", StringUtil.RTrim( Dvpanel_unnamedtable8_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Cls", StringUtil.RTrim( Dvpanel_unnamedtable8_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Title", StringUtil.RTrim( Dvpanel_unnamedtable8_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable8_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE8_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable8_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Width", StringUtil.RTrim( Dvpanel_unnamedtable2_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Cls", StringUtil.RTrim( Dvpanel_unnamedtable2_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Title", StringUtil.RTrim( Dvpanel_unnamedtable2_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable2_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE2_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable2_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELUSERBODY_Width", StringUtil.RTrim( Dvpanel_paneluserbody_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELUSERBODY_Autowidth", StringUtil.BoolToStr( Dvpanel_paneluserbody_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELUSERBODY_Autoheight", StringUtil.BoolToStr( Dvpanel_paneluserbody_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELUSERBODY_Cls", StringUtil.RTrim( Dvpanel_paneluserbody_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELUSERBODY_Title", StringUtil.RTrim( Dvpanel_paneluserbody_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELUSERBODY_Collapsible", StringUtil.BoolToStr( Dvpanel_paneluserbody_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELUSERBODY_Collapsed", StringUtil.BoolToStr( Dvpanel_paneluserbody_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELUSERBODY_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_paneluserbody_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELUSERBODY_Iconposition", StringUtil.RTrim( Dvpanel_paneluserbody_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_PANELUSERBODY_Autoscroll", StringUtil.BoolToStr( Dvpanel_paneluserbody_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Width", StringUtil.RTrim( Dvpanel_unnamedtable4_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Cls", StringUtil.RTrim( Dvpanel_unnamedtable4_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Title", StringUtil.RTrim( Dvpanel_unnamedtable4_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable4_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE4_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable4_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Width", StringUtil.RTrim( Dvpanel_unnamedtable5_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Cls", StringUtil.RTrim( Dvpanel_unnamedtable5_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Title", StringUtil.RTrim( Dvpanel_unnamedtable5_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable5_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE5_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable5_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Width", StringUtil.RTrim( Dvpanel_unnamedtable3_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Cls", StringUtil.RTrim( Dvpanel_unnamedtable3_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Title", StringUtil.RTrim( Dvpanel_unnamedtable3_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable3_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
      }

      protected void RenderHtmlCloseForm142( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "GAMWCAuthenticationTypeEntryOauth20" ;
      }

      public override string GetPgmdesc( )
      {
         return "Authentication Type Entry Oauth20" ;
      }

      protected void WB140( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "gamwcauthenticationtypeentryoauth20.aspx");
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
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavIdp.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavIdp_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavIdp_Internalname, "IDP", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavIdp, cmbavIdp_Internalname, StringUtil.RTrim( AV151IDP), 1, cmbavIdp_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavIdp.Visible, cmbavIdp.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            cmbavIdp.CurrentValue = StringUtil.RTrim( AV151IDP);
            AssignProp(sPrefix, false, cmbavIdp_Internalname, "Values", (string)(cmbavIdp.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV34Name), StringUtil.RTrim( context.localUtil.Format( AV34Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavFunctionid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFunctionid_Internalname, "Function", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFunctionid, cmbavFunctionid_Internalname, StringUtil.RTrim( AV30FunctionId), 1, cmbavFunctionid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavFunctionid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV30FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", (string)(cmbavFunctionid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDsc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, "Description", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV25Dsc), StringUtil.RTrim( context.localUtil.Format( AV25Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionMedium", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavIsenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsenable_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenable_Internalname, StringUtil.BoolToStr( AV33IsEnable), "", " ", 1, chkavIsenable.Enabled, "true", "Enabled?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(38, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,38);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavImpersonate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavImpersonate_Internalname, "Impersonate", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavImpersonate, cmbavImpersonate_Internalname, StringUtil.RTrim( AV32Impersonate), 1, cmbavImpersonate_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavImpersonate.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            cmbavImpersonate.CurrentValue = StringUtil.RTrim( AV32Impersonate);
            AssignProp(sPrefix, false, cmbavImpersonate_Internalname, "Values", (string)(cmbavImpersonate.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavSmallimagename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSmallimagename_Internalname, "Small image name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSmallimagename_Internalname, StringUtil.RTrim( AV43SmallImageName), StringUtil.RTrim( context.localUtil.Format( AV43SmallImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSmallimagename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSmallimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavBigimagename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBigimagename_Internalname, "Big image name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBigimagename_Internalname, StringUtil.RTrim( AV23BigImageName), StringUtil.RTrim( context.localUtil.Format( AV23BigImageName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBigimagename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavBigimagename_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
            ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
            ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
            ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, sPrefix+"GXUITABSPANEL_TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "General", "", "", lblGeneral_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable15_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOauth20clientidtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientidtag_Internalname, "Client Id Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientidtag_Internalname, StringUtil.RTrim( AV35Oauth20ClientIdTag), StringUtil.RTrim( context.localUtil.Format( AV35Oauth20ClientIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientidtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20clientidtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOauth20clientidvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientidvalue_Internalname, "Client Id Value", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientidvalue_Internalname, AV36Oauth20ClientIdValue, StringUtil.RTrim( context.localUtil.Format( AV36Oauth20ClientIdValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientidvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20clientidvalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOauth20clientsecrettag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientsecrettag_Internalname, "Client Secret Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientsecrettag_Internalname, StringUtil.RTrim( AV37Oauth20ClientSecretTag), StringUtil.RTrim( context.localUtil.Format( AV37Oauth20ClientSecretTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientsecrettag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20clientsecrettag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOauth20clientsecretvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20clientsecretvalue_Internalname, "Client Secret Value", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20clientsecretvalue_Internalname, AV38Oauth20ClientSecretValue, StringUtil.RTrim( context.localUtil.Format( AV38Oauth20ClientSecretValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20clientsecretvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20clientsecretvalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOauth20redirecturltag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20redirecturltag_Internalname, "Redirect URL Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20redirecturltag_Internalname, StringUtil.RTrim( AV41Oauth20RedirectURLTag), StringUtil.RTrim( context.localUtil.Format( AV41Oauth20RedirectURLTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20redirecturltag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20redirecturltag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOauth20redirecturlvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOauth20redirecturlvalue_Internalname, "Redirect URL Value", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOauth20redirecturlvalue_Internalname, AV42Oauth20RedirectURLvalue, StringUtil.RTrim( context.localUtil.Format( AV42Oauth20RedirectURLvalue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOauth20redirecturlvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOauth20redirecturlvalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavOauth20redirecturliscustom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOauth20redirecturliscustom_Internalname, " ", " AttributeCheckBoxLabel BootstrapTooltipRightLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox BootstrapTooltipRight";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOauth20redirecturliscustom_Internalname, StringUtil.BoolToStr( AV40Oauth20RedirectURLisCustom), chkavOauth20redirecturliscustom.TooltipText, " ", 1, chkavOauth20redirecturliscustom.Enabled, "true", "Custom Redirect URL?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(91, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,91);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable16_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbhelpcustomredirect_Internalname, "Customize the IDP callback URL, you should implement the object that handles this response.", "", "", lblTbhelpcustomredirect_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextblockExtraSmall AttributeSizeSmall", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblautocompletevirtualdirectory_Internalname, divTblautocompletevirtualdirectory_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-7 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavOauth20redirecturl_autocompletevirtualdirectory_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOauth20redirecturl_autocompletevirtualdirectory_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOauth20redirecturl_autocompletevirtualdirectory_Internalname, StringUtil.BoolToStr( AV111Oauth20RedirectURL_AutocompleteVirtualDirectory), "", " ", 1, chkavOauth20redirecturl_autocompletevirtualdirectory.Enabled, "true", "Autocomplete redirect URL with virtual directory", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(104, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,104);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbhelpautocompletevirtualdirectory_Internalname, "Autocomplete redirect URL with virtual directory where application services are running (Callback URL).", "", "", lblTbhelpautocompletevirtualdirectory_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextblockExtraSmall AttributeSizeSmall", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavOauth20redirecttoauthenticate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOauth20redirecttoauthenticate_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOauth20redirecttoauthenticate_Internalname, StringUtil.BoolToStr( AV39Oauth20RedirectToAuthenticate), "", " ", 1, chkavOauth20redirecttoauthenticate.Enabled, "true", "Redirect to authenticate?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(112, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,112);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbhelp0redirecttoauthenticate_Internalname, "This option allows you to authenticate using the IDP without redirecting to it.", "", "", lblTbhelp0redirecttoauthenticate_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextblockExtraSmall AttributeSizeSmall", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAuthorization_title_Internalname, "Authorization", "", "", lblAuthorization_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Authorization") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable12_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthorizeurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthorizeurl_Internalname, "URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthorizeurl_Internalname, AV10AuthorizeURL, StringUtil.RTrim( context.localUtil.Format( AV10AuthorizeURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthorizeurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthorizeurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable13.SetProperty("Width", Dvpanel_unnamedtable13_Width);
            ucDvpanel_unnamedtable13.SetProperty("AutoWidth", Dvpanel_unnamedtable13_Autowidth);
            ucDvpanel_unnamedtable13.SetProperty("AutoHeight", Dvpanel_unnamedtable13_Autoheight);
            ucDvpanel_unnamedtable13.SetProperty("Cls", Dvpanel_unnamedtable13_Cls);
            ucDvpanel_unnamedtable13.SetProperty("Title", Dvpanel_unnamedtable13_Title);
            ucDvpanel_unnamedtable13.SetProperty("Collapsible", Dvpanel_unnamedtable13_Collapsible);
            ucDvpanel_unnamedtable13.SetProperty("Collapsed", Dvpanel_unnamedtable13_Collapsed);
            ucDvpanel_unnamedtable13.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable13_Showcollapseicon);
            ucDvpanel_unnamedtable13.SetProperty("IconPosition", Dvpanel_unnamedtable13_Iconposition);
            ucDvpanel_unnamedtable13.SetProperty("AutoScroll", Dvpanel_unnamedtable13_Autoscroll);
            ucDvpanel_unnamedtable13.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable13_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE13Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE13Container"+"UnnamedTable13"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable13_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAuthresptypeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthresptypeinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthresptypeinclude_Internalname, StringUtil.BoolToStr( AV14AuthRespTypeInclude), "", " ", 1, chkavAuthresptypeinclude.Enabled, "true", "Include Response Type", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(134, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,134);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthresptypetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresptypetag_Internalname, "Response Type Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresptypetag_Internalname, StringUtil.RTrim( AV15AuthRespTypeTag), StringUtil.RTrim( context.localUtil.Format( AV15AuthRespTypeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresptypetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthresptypetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthresptypevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresptypevalue_Internalname, "Response Type Value", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresptypevalue_Internalname, AV16AuthRespTypeValue, StringUtil.RTrim( context.localUtil.Format( AV16AuthRespTypeValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresptypevalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthresptypevalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAuthscopeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthscopeinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthscopeinclude_Internalname, StringUtil.BoolToStr( AV17AuthScopeInclude), "", " ", 1, chkavAuthscopeinclude.Enabled, "true", "Include scope", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(147, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,147);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthscopetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthscopetag_Internalname, "Scope Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthscopetag_Internalname, StringUtil.RTrim( AV18AuthScopeTag), StringUtil.RTrim( context.localUtil.Format( AV18AuthScopeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthscopetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthscopetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthscopevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthscopevalue_Internalname, "Scope Value", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthscopevalue_Internalname, AV19AuthScopeValue, StringUtil.RTrim( context.localUtil.Format( AV19AuthScopeValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,155);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthscopevalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthscopevalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAuthstateinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthstateinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthstateinclude_Internalname, StringUtil.BoolToStr( AV98AuthStateInclude), "", " ", 1, chkavAuthstateinclude.Enabled, "true", "Include state", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(160, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,160);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthstatetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthstatetag_Internalname, "State Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthstatetag_Internalname, StringUtil.RTrim( AV21AuthStateTag), StringUtil.RTrim( context.localUtil.Format( AV21AuthStateTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,164);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthstatetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthstatetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAuthclientidinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthclientidinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthclientidinclude_Internalname, StringUtil.BoolToStr( AV7AuthClientIdInclude), "", " ", 1, chkavAuthclientidinclude.Enabled, "true", "Include Client Id", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(169, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,169);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAuthclientsecretinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthclientsecretinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthclientsecretinclude_Internalname, StringUtil.BoolToStr( AV8AuthClientSecretInclude), "", " ", 1, chkavAuthclientsecretinclude.Enabled, "true", "Include Client Secret", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(173, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,173);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAuthredirurlinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthredirurlinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthredirurlinclude_Internalname, StringUtil.BoolToStr( AV99AuthRedirURLInclude), "", " ", 1, chkavAuthredirurlinclude.Enabled, "true", "Include Redirect URL", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(177, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,177);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthadditionalparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthadditionalparameters_Internalname, "Additional Parameters", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthadditionalparameters_Internalname, StringUtil.RTrim( AV5AuthAdditionalParameters), StringUtil.RTrim( context.localUtil.Format( AV5AuthAdditionalParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,182);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthadditionalparameters_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthadditionalparameters_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthadditionalparameterssd_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthadditionalparameterssd_Internalname, "Additional Parameters for Smart Devices", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthadditionalparameterssd_Internalname, StringUtil.RTrim( AV6AuthAdditionalParametersSD), StringUtil.RTrim( context.localUtil.Format( AV6AuthAdditionalParametersSD, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,186);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthadditionalparameterssd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthadditionalparameterssd_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAuthopenidconnectprotocolenable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthopenidconnectprotocolenable_Internalname, "Enable OpenID Connect Protocol?", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthopenidconnectprotocolenable_Internalname, StringUtil.BoolToStr( AV109AuthOpenIDConnectProtocolEnable), "", "Enable OpenID Connect Protocol?", 1, chkavAuthopenidconnectprotocolenable.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(190, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,190);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbl_openidconnect_Internalname, divTbl_openidconnect_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_groupauthopenidconnecttable1.SetProperty("Width", Dvpanel_groupauthopenidconnecttable1_Width);
            ucDvpanel_groupauthopenidconnecttable1.SetProperty("AutoWidth", Dvpanel_groupauthopenidconnecttable1_Autowidth);
            ucDvpanel_groupauthopenidconnecttable1.SetProperty("AutoHeight", Dvpanel_groupauthopenidconnecttable1_Autoheight);
            ucDvpanel_groupauthopenidconnecttable1.SetProperty("Cls", Dvpanel_groupauthopenidconnecttable1_Cls);
            ucDvpanel_groupauthopenidconnecttable1.SetProperty("Title", Dvpanel_groupauthopenidconnecttable1_Title);
            ucDvpanel_groupauthopenidconnecttable1.SetProperty("Collapsible", Dvpanel_groupauthopenidconnecttable1_Collapsible);
            ucDvpanel_groupauthopenidconnecttable1.SetProperty("Collapsed", Dvpanel_groupauthopenidconnecttable1_Collapsed);
            ucDvpanel_groupauthopenidconnecttable1.SetProperty("ShowCollapseIcon", Dvpanel_groupauthopenidconnecttable1_Showcollapseicon);
            ucDvpanel_groupauthopenidconnecttable1.SetProperty("IconPosition", Dvpanel_groupauthopenidconnecttable1_Iconposition);
            ucDvpanel_groupauthopenidconnecttable1.SetProperty("AutoScroll", Dvpanel_groupauthopenidconnecttable1_Autoscroll);
            ucDvpanel_groupauthopenidconnecttable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_groupauthopenidconnecttable1_Internalname, sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1Container"+"GroupAuthOpenIDConnectTable1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGroupauthopenidconnecttable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAuthvalididtoken_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthvalididtoken_Internalname, "Validate ID Token?", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 203,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthvalididtoken_Internalname, StringUtil.BoolToStr( AV110AuthValidIdToken), "", "Validate ID Token?", 1, chkavAuthvalididtoken.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(203, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,203);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbl_valididtoken_Internalname, divTbl_valididtoken_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthissuerurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthissuerurl_Internalname, "Issuer URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthissuerurl_Internalname, AV108AuthIssuerURL, StringUtil.RTrim( context.localUtil.Format( AV108AuthIssuerURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,211);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthissuerurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthissuerurl_Enabled, 1, "text", "", 100, "%", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthcertificatepathfilename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthcertificatepathfilename_Internalname, "Path to server certificate filename", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthcertificatepathfilename_Internalname, AV107AuthCertificatePathFileName, StringUtil.RTrim( context.localUtil.Format( AV107AuthCertificatePathFileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,216);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthcertificatepathfilename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthcertificatepathfilename_Enabled, 1, "text", "", 100, "%", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAuthallowonlyuseremailverified_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAuthallowonlyuseremailverified_Internalname, "Allow only users with verified email?", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAuthallowonlyuseremailverified_Internalname, StringUtil.BoolToStr( AV106AuthAllowOnlyUserEmailVerified), "", "Allow only users with verified email?", 1, chkavAuthallowonlyuseremailverified.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(221, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,221);\"");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable14.SetProperty("Width", Dvpanel_unnamedtable14_Width);
            ucDvpanel_unnamedtable14.SetProperty("AutoWidth", Dvpanel_unnamedtable14_Autowidth);
            ucDvpanel_unnamedtable14.SetProperty("AutoHeight", Dvpanel_unnamedtable14_Autoheight);
            ucDvpanel_unnamedtable14.SetProperty("Cls", Dvpanel_unnamedtable14_Cls);
            ucDvpanel_unnamedtable14.SetProperty("Title", Dvpanel_unnamedtable14_Title);
            ucDvpanel_unnamedtable14.SetProperty("Collapsible", Dvpanel_unnamedtable14_Collapsible);
            ucDvpanel_unnamedtable14.SetProperty("Collapsed", Dvpanel_unnamedtable14_Collapsed);
            ucDvpanel_unnamedtable14.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable14_Showcollapseicon);
            ucDvpanel_unnamedtable14.SetProperty("IconPosition", Dvpanel_unnamedtable14_Iconposition);
            ucDvpanel_unnamedtable14.SetProperty("AutoScroll", Dvpanel_unnamedtable14_Autoscroll);
            ucDvpanel_unnamedtable14.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable14_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE14Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE14Container"+"UnnamedTable14"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable14_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthresponseaccesscodetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresponseaccesscodetag_Internalname, "Access Code Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 231,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresponseaccesscodetag_Internalname, StringUtil.RTrim( AV12AuthResponseAccessCodeTag), StringUtil.RTrim( context.localUtil.Format( AV12AuthResponseAccessCodeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,231);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresponseaccesscodetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthresponseaccesscodetag_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthresponseerrordesctag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthresponseerrordesctag_Internalname, "Error Description Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 236,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthresponseerrordesctag_Internalname, StringUtil.RTrim( AV13AuthResponseErrorDescTag), StringUtil.RTrim( context.localUtil.Format( AV13AuthResponseErrorDescTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,236);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthresponseerrordesctag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuthresponseerrordesctag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblToken_title_Internalname, "Token", "", "", lblToken_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Token") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenurl_Internalname, "URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenurl_Internalname, AV67TokenURL, StringUtil.RTrim( context.localUtil.Format( AV67TokenURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,246);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavTokenmethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTokenmethod_Internalname, "Token method", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTokenmethod, cmbavTokenmethod_Internalname, StringUtil.RTrim( AV57TokenMethod), 1, cmbavTokenmethod_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavTokenmethod.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,251);\"", "", true, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            cmbavTokenmethod.CurrentValue = StringUtil.RTrim( AV57TokenMethod);
            AssignProp(sPrefix, false, cmbavTokenmethod_Internalname, "Values", (string)(cmbavTokenmethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
            ucDvpanel_unnamedtable7.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable7_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE7Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE7Container"+"UnnamedTable7"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenheaderkeytag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenheaderkeytag_Internalname, "Header Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 261,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenheaderkeytag_Internalname, StringUtil.RTrim( AV55TokenHeaderKeyTag), StringUtil.RTrim( context.localUtil.Format( AV55TokenHeaderKeyTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,261);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenheaderkeytag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenheaderkeytag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenheaderkeyvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenheaderkeyvalue_Internalname, "Header Value", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 266,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenheaderkeyvalue_Internalname, AV56TokenHeaderKeyValue, StringUtil.RTrim( context.localUtil.Format( AV56TokenHeaderKeyValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,266);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenheaderkeyvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenheaderkeyvalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavTokenheaderauthenticationinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenheaderauthenticationinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 271,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenheaderauthenticationinclude_Internalname, StringUtil.BoolToStr( AV51TokenHeaderAuthenticationInclude), "", " ", 1, chkavTokenheaderauthenticationinclude.Enabled, "true", "Token Header Authentication Include", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(271, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,271);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavTokenheaderauthorizationbasicinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenheaderauthorizationbasicinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 276,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenheaderauthorizationbasicinclude_Internalname, StringUtil.BoolToStr( AV54TokenHeaderAuthorizationBasicInclude), "", " ", 1, chkavTokenheaderauthorizationbasicinclude.Enabled, "true", "Include Authorization header with Basic value?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(276, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,276);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavTokenheaderauthenticationmethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavTokenheaderauthenticationmethod_Internalname, "Method", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 281,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavTokenheaderauthenticationmethod, cmbavTokenheaderauthenticationmethod_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV52TokenHeaderAuthenticationMethod), 4, 0)), 1, cmbavTokenheaderauthenticationmethod_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavTokenheaderauthenticationmethod.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,281);\"", "", true, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            cmbavTokenheaderauthenticationmethod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52TokenHeaderAuthenticationMethod), 4, 0));
            AssignProp(sPrefix, false, cmbavTokenheaderauthenticationmethod_Internalname, "Values", (string)(cmbavTokenheaderauthenticationmethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenheaderauthenticationrealm_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenheaderauthenticationrealm_Internalname, "Realm", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 286,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenheaderauthenticationrealm_Internalname, StringUtil.RTrim( AV53TokenHeaderAuthenticationRealm), StringUtil.RTrim( context.localUtil.Format( AV53TokenHeaderAuthenticationRealm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,286);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenheaderauthenticationrealm_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenheaderauthenticationrealm_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            ucDvpanel_unnamedtable8.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable8_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE8Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE8Container"+"UnnamedTable8"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable9.SetProperty("Width", Dvpanel_unnamedtable9_Width);
            ucDvpanel_unnamedtable9.SetProperty("AutoWidth", Dvpanel_unnamedtable9_Autowidth);
            ucDvpanel_unnamedtable9.SetProperty("AutoHeight", Dvpanel_unnamedtable9_Autoheight);
            ucDvpanel_unnamedtable9.SetProperty("Cls", Dvpanel_unnamedtable9_Cls);
            ucDvpanel_unnamedtable9.SetProperty("Title", Dvpanel_unnamedtable9_Title);
            ucDvpanel_unnamedtable9.SetProperty("Collapsible", Dvpanel_unnamedtable9_Collapsible);
            ucDvpanel_unnamedtable9.SetProperty("Collapsed", Dvpanel_unnamedtable9_Collapsed);
            ucDvpanel_unnamedtable9.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable9_Showcollapseicon);
            ucDvpanel_unnamedtable9.SetProperty("IconPosition", Dvpanel_unnamedtable9_Iconposition);
            ucDvpanel_unnamedtable9.SetProperty("AutoScroll", Dvpanel_unnamedtable9_Autoscroll);
            ucDvpanel_unnamedtable9.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable9_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE9Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE9Container"+"UnnamedTable9"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavTokengranttypeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokengranttypeinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 301,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokengranttypeinclude_Internalname, StringUtil.BoolToStr( AV48TokenGrantTypeInclude), "", " ", 1, chkavTokengranttypeinclude.Enabled, "true", "Grant Type", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(301, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,301);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokengranttypetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokengranttypetag_Internalname, "Grant Type Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 306,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokengranttypetag_Internalname, StringUtil.RTrim( AV49TokenGrantTypeTag), StringUtil.RTrim( context.localUtil.Format( AV49TokenGrantTypeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,306);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokengranttypetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokengranttypetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokengranttypevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokengranttypevalue_Internalname, "Grant Type Value", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 311,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokengranttypevalue_Internalname, AV50TokenGrantTypeValue, StringUtil.RTrim( context.localUtil.Format( AV50TokenGrantTypeValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,311);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokengranttypevalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokengranttypevalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavTokenaccesscodeinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenaccesscodeinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 316,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenaccesscodeinclude_Internalname, StringUtil.BoolToStr( AV44TokenAccessCodeInclude), "", " ", 1, chkavTokenaccesscodeinclude.Enabled, "true", "Include Access Code", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(316, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,316);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavTokencliidinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokencliidinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 321,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokencliidinclude_Internalname, StringUtil.BoolToStr( AV46TokenCliIdInclude), "", " ", 1, chkavTokencliidinclude.Enabled, "true", "Include Client Id", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(321, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,321);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavTokenclisecretinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenclisecretinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 326,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenclisecretinclude_Internalname, StringUtil.BoolToStr( AV47TokenCliSecretInclude), "", " ", 1, chkavTokenclisecretinclude.Enabled, "true", "Include Client Secret", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(326, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,326);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavTokenredirecturlinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTokenredirecturlinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 331,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTokenredirecturlinclude_Internalname, StringUtil.BoolToStr( AV58TokenRedirectURLInclude), "", " ", 1, chkavTokenredirecturlinclude.Enabled, "true", "Include Redirect URL", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(331, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,331);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenadditionalparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenadditionalparameters_Internalname, "Additional Parameters", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 336,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenadditionalparameters_Internalname, StringUtil.RTrim( AV45TokenAdditionalParameters), StringUtil.RTrim( context.localUtil.Format( AV45TokenAdditionalParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,336);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenadditionalparameters_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenadditionalparameters_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable10.SetProperty("Width", Dvpanel_unnamedtable10_Width);
            ucDvpanel_unnamedtable10.SetProperty("AutoWidth", Dvpanel_unnamedtable10_Autowidth);
            ucDvpanel_unnamedtable10.SetProperty("AutoHeight", Dvpanel_unnamedtable10_Autoheight);
            ucDvpanel_unnamedtable10.SetProperty("Cls", Dvpanel_unnamedtable10_Cls);
            ucDvpanel_unnamedtable10.SetProperty("Title", Dvpanel_unnamedtable10_Title);
            ucDvpanel_unnamedtable10.SetProperty("Collapsible", Dvpanel_unnamedtable10_Collapsible);
            ucDvpanel_unnamedtable10.SetProperty("Collapsed", Dvpanel_unnamedtable10_Collapsed);
            ucDvpanel_unnamedtable10.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable10_Showcollapseicon);
            ucDvpanel_unnamedtable10.SetProperty("IconPosition", Dvpanel_unnamedtable10_Iconposition);
            ucDvpanel_unnamedtable10.SetProperty("AutoScroll", Dvpanel_unnamedtable10_Autoscroll);
            ucDvpanel_unnamedtable10.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable10_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE10Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE10Container"+"UnnamedTable10"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenresponseaccesstokentag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseaccesstokentag_Internalname, "Access Code Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 345,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseaccesstokentag_Internalname, StringUtil.RTrim( AV60TokenResponseAccessTokenTag), StringUtil.RTrim( context.localUtil.Format( AV60TokenResponseAccessTokenTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,345);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseaccesstokentag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponseaccesstokentag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenresponsetokentypetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponsetokentypetag_Internalname, "Token Type Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 349,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponsetokentypetag_Internalname, StringUtil.RTrim( AV65TokenResponseTokenTypeTag), StringUtil.RTrim( context.localUtil.Format( AV65TokenResponseTokenTypeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,349);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponsetokentypetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponsetokentypetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenresponseexpiresintag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseexpiresintag_Internalname, "Expires in Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 354,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseexpiresintag_Internalname, StringUtil.RTrim( AV62TokenResponseExpiresInTag), StringUtil.RTrim( context.localUtil.Format( AV62TokenResponseExpiresInTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,354);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseexpiresintag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponseexpiresintag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenresponsescopetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponsescopetag_Internalname, "Scope Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 358,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponsescopetag_Internalname, StringUtil.RTrim( AV64TokenResponseScopeTag), StringUtil.RTrim( context.localUtil.Format( AV64TokenResponseScopeTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,358);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponsescopetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponsescopetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenresponseuseridtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseuseridtag_Internalname, "User Id Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 363,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseuseridtag_Internalname, StringUtil.RTrim( AV66TokenResponseUserIdTag), StringUtil.RTrim( context.localUtil.Format( AV66TokenResponseUserIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,363);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseuseridtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponseuseridtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenresponserefreshtokentag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponserefreshtokentag_Internalname, "Refresh Token Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 367,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponserefreshtokentag_Internalname, StringUtil.RTrim( AV63TokenResponseRefreshTokenTag), StringUtil.RTrim( context.localUtil.Format( AV63TokenResponseRefreshTokenTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,367);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponserefreshtokentag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponserefreshtokentag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenresponseerrordescriptiontag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenresponseerrordescriptiontag_Internalname, "Error Description Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 372,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenresponseerrordescriptiontag_Internalname, StringUtil.RTrim( AV61TokenResponseErrorDescriptionTag), StringUtil.RTrim( context.localUtil.Format( AV61TokenResponseErrorDescriptionTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,372);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenresponseerrordescriptiontag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenresponseerrordescriptiontag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable11.SetProperty("Width", Dvpanel_unnamedtable11_Width);
            ucDvpanel_unnamedtable11.SetProperty("AutoWidth", Dvpanel_unnamedtable11_Autowidth);
            ucDvpanel_unnamedtable11.SetProperty("AutoHeight", Dvpanel_unnamedtable11_Autoheight);
            ucDvpanel_unnamedtable11.SetProperty("Cls", Dvpanel_unnamedtable11_Cls);
            ucDvpanel_unnamedtable11.SetProperty("Title", Dvpanel_unnamedtable11_Title);
            ucDvpanel_unnamedtable11.SetProperty("Collapsible", Dvpanel_unnamedtable11_Collapsible);
            ucDvpanel_unnamedtable11.SetProperty("Collapsed", Dvpanel_unnamedtable11_Collapsed);
            ucDvpanel_unnamedtable11.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable11_Showcollapseicon);
            ucDvpanel_unnamedtable11.SetProperty("IconPosition", Dvpanel_unnamedtable11_Iconposition);
            ucDvpanel_unnamedtable11.SetProperty("AutoScroll", Dvpanel_unnamedtable11_Autoscroll);
            ucDvpanel_unnamedtable11.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable11_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE11Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE11Container"+"UnnamedTable11"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable11_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAutovalidateexternaltokenandrefresh_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAutovalidateexternaltokenandrefresh_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 381,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAutovalidateexternaltokenandrefresh_Internalname, StringUtil.BoolToStr( AV22AutovalidateExternalTokenAndRefresh), "", " ", 1, chkavAutovalidateexternaltokenandrefresh.Enabled, "true", "Validate External Token", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(381, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,381);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTokenrefreshtokenurl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTokenrefreshtokenurl_Internalname, "Refresh Token URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 385,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTokenrefreshtokenurl_Internalname, AV59TokenRefreshTokenURL, StringUtil.RTrim( context.localUtil.Format( AV59TokenRefreshTokenURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,385);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTokenrefreshtokenurl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTokenrefreshtokenurl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUserinfo_title_Internalname, "User Information", "", "", lblUserinfo_title_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "UserInfo") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"GXUITABSPANEL_TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinfourl_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfourl_Internalname, "URL", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 395,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfourl_Internalname, AV94UserInfoURL, StringUtil.RTrim( context.localUtil.Format( AV94UserInfoURL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,395);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfourl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfourl_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavUserinfomethod_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUserinfomethod_Internalname, "User Info Method", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 400,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUserinfomethod, cmbavUserinfomethod_Internalname, StringUtil.RTrim( AV78UserInfoMethod), 1, cmbavUserinfomethod_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavUserinfomethod.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,400);\"", "", true, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            cmbavUserinfomethod.CurrentValue = StringUtil.RTrim( AV78UserInfoMethod);
            AssignProp(sPrefix, false, cmbavUserinfomethod_Internalname, "Values", (string)(cmbavUserinfomethod.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable2.SetProperty("Width", Dvpanel_unnamedtable2_Width);
            ucDvpanel_unnamedtable2.SetProperty("AutoWidth", Dvpanel_unnamedtable2_Autowidth);
            ucDvpanel_unnamedtable2.SetProperty("AutoHeight", Dvpanel_unnamedtable2_Autoheight);
            ucDvpanel_unnamedtable2.SetProperty("Cls", Dvpanel_unnamedtable2_Cls);
            ucDvpanel_unnamedtable2.SetProperty("Title", Dvpanel_unnamedtable2_Title);
            ucDvpanel_unnamedtable2.SetProperty("Collapsible", Dvpanel_unnamedtable2_Collapsible);
            ucDvpanel_unnamedtable2.SetProperty("Collapsed", Dvpanel_unnamedtable2_Collapsed);
            ucDvpanel_unnamedtable2.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable2_Showcollapseicon);
            ucDvpanel_unnamedtable2.SetProperty("IconPosition", Dvpanel_unnamedtable2_Iconposition);
            ucDvpanel_unnamedtable2.SetProperty("AutoScroll", Dvpanel_unnamedtable2_Autoscroll);
            ucDvpanel_unnamedtable2.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable2_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE2Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE2Container"+"UnnamedTable2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinfoheaderkeytag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoheaderkeytag_Internalname, "Header Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 410,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoheaderkeytag_Internalname, StringUtil.RTrim( AV76UserInfoHeaderKeyTag), StringUtil.RTrim( context.localUtil.Format( AV76UserInfoHeaderKeyTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,410);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoheaderkeytag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoheaderkeytag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinfoheaderkeyvalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoheaderkeyvalue_Internalname, "Header Value", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 415,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoheaderkeyvalue_Internalname, AV77UserInfoHeaderKeyValue, StringUtil.RTrim( context.localUtil.Format( AV77UserInfoHeaderKeyValue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,415);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoheaderkeyvalue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoheaderkeyvalue_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            ucDvpanel_unnamedtable3.SetProperty("Width", Dvpanel_unnamedtable3_Width);
            ucDvpanel_unnamedtable3.SetProperty("AutoWidth", Dvpanel_unnamedtable3_Autowidth);
            ucDvpanel_unnamedtable3.SetProperty("AutoHeight", Dvpanel_unnamedtable3_Autoheight);
            ucDvpanel_unnamedtable3.SetProperty("Cls", Dvpanel_unnamedtable3_Cls);
            ucDvpanel_unnamedtable3.SetProperty("Title", Dvpanel_unnamedtable3_Title);
            ucDvpanel_unnamedtable3.SetProperty("Collapsible", Dvpanel_unnamedtable3_Collapsible);
            ucDvpanel_unnamedtable3.SetProperty("Collapsed", Dvpanel_unnamedtable3_Collapsed);
            ucDvpanel_unnamedtable3.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable3_Showcollapseicon);
            ucDvpanel_unnamedtable3.SetProperty("IconPosition", Dvpanel_unnamedtable3_Iconposition);
            ucDvpanel_unnamedtable3.SetProperty("AutoScroll", Dvpanel_unnamedtable3_Autoscroll);
            ucDvpanel_unnamedtable3.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable3_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE3Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE3Container"+"UnnamedTable3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_paneluserbody.SetProperty("Width", Dvpanel_paneluserbody_Width);
            ucDvpanel_paneluserbody.SetProperty("AutoWidth", Dvpanel_paneluserbody_Autowidth);
            ucDvpanel_paneluserbody.SetProperty("AutoHeight", Dvpanel_paneluserbody_Autoheight);
            ucDvpanel_paneluserbody.SetProperty("Cls", Dvpanel_paneluserbody_Cls);
            ucDvpanel_paneluserbody.SetProperty("Title", Dvpanel_paneluserbody_Title);
            ucDvpanel_paneluserbody.SetProperty("Collapsible", Dvpanel_paneluserbody_Collapsible);
            ucDvpanel_paneluserbody.SetProperty("Collapsed", Dvpanel_paneluserbody_Collapsed);
            ucDvpanel_paneluserbody.SetProperty("ShowCollapseIcon", Dvpanel_paneluserbody_Showcollapseicon);
            ucDvpanel_paneluserbody.SetProperty("IconPosition", Dvpanel_paneluserbody_Iconposition);
            ucDvpanel_paneluserbody.SetProperty("AutoScroll", Dvpanel_paneluserbody_Autoscroll);
            ucDvpanel_paneluserbody.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_paneluserbody_Internalname, sPrefix+"DVPANEL_PANELUSERBODYContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_PANELUSERBODYContainer"+"PanelUserBody"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPaneluserbody_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavUserinfoaccesstokeninclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfoaccesstokeninclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 430,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfoaccesstokeninclude_Internalname, StringUtil.BoolToStr( AV69UserInfoAccessTokenInclude), "", " ", 1, chkavUserinfoaccesstokeninclude.Enabled, "true", "Include Access Token", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(430, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,430);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinfoaccesstokenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoaccesstokenname_Internalname, "Access Token Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 435,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoaccesstokenname_Internalname, StringUtil.RTrim( AV70UserInfoAccessTokenName), StringUtil.RTrim( context.localUtil.Format( AV70UserInfoAccessTokenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,435);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoaccesstokenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoaccesstokenname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavUserinfoclientidinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfoclientidinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 440,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfoclientidinclude_Internalname, StringUtil.BoolToStr( AV72UserInfoClientIdInclude), "", " ", 1, chkavUserinfoclientidinclude.Enabled, "true", "Include Client Id", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(440, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,440);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinfoclientidname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoclientidname_Internalname, "Client Id Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 445,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoclientidname_Internalname, StringUtil.RTrim( AV73UserInfoClientIdName), StringUtil.RTrim( context.localUtil.Format( AV73UserInfoClientIdName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,445);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoclientidname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoclientidname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavUserinfoclientsecretinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfoclientsecretinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 450,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfoclientsecretinclude_Internalname, StringUtil.BoolToStr( AV74UserInfoClientSecretInclude), "", " ", 1, chkavUserinfoclientsecretinclude.Enabled, "true", "Include Client Secret", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(450, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,450);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinfoclientsecretname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoclientsecretname_Internalname, "Client Secret Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 455,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoclientsecretname_Internalname, StringUtil.RTrim( AV75UserInfoClientSecretName), StringUtil.RTrim( context.localUtil.Format( AV75UserInfoClientSecretName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,455);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoclientsecretname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinfoclientsecretname_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavUserinfouseridinclude_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinfouseridinclude_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 460,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinfouseridinclude_Internalname, StringUtil.BoolToStr( AV95UserInfoUserIdInclude), "", " ", 1, chkavUserinfouseridinclude.Enabled, "true", "Include User Id", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(460, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,460);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserinfoadditionalparameters_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinfoadditionalparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinfoadditionalparameters_Internalname, "Additional Parameters", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 465,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinfoadditionalparameters_Internalname, StringUtil.RTrim( AV71UserInfoAdditionalParameters), StringUtil.RTrim( context.localUtil.Format( AV71UserInfoAdditionalParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,465);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinfoadditionalparameters_Jsonclick, 0, "Attribute", "", "", "", "", edtavUserinfoadditionalparameters_Visible, edtavUserinfoadditionalparameters_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable4.SetProperty("Width", Dvpanel_unnamedtable4_Width);
            ucDvpanel_unnamedtable4.SetProperty("AutoWidth", Dvpanel_unnamedtable4_Autowidth);
            ucDvpanel_unnamedtable4.SetProperty("AutoHeight", Dvpanel_unnamedtable4_Autoheight);
            ucDvpanel_unnamedtable4.SetProperty("Cls", Dvpanel_unnamedtable4_Cls);
            ucDvpanel_unnamedtable4.SetProperty("Title", Dvpanel_unnamedtable4_Title);
            ucDvpanel_unnamedtable4.SetProperty("Collapsible", Dvpanel_unnamedtable4_Collapsible);
            ucDvpanel_unnamedtable4.SetProperty("Collapsed", Dvpanel_unnamedtable4_Collapsed);
            ucDvpanel_unnamedtable4.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable4_Showcollapseicon);
            ucDvpanel_unnamedtable4.SetProperty("IconPosition", Dvpanel_unnamedtable4_Iconposition);
            ucDvpanel_unnamedtable4.SetProperty("AutoScroll", Dvpanel_unnamedtable4_Autoscroll);
            ucDvpanel_unnamedtable4.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable4_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE4Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE4Container"+"UnnamedTable4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuseremailtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuseremailtag_Internalname, "User Email Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 474,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuseremailtag_Internalname, StringUtil.RTrim( AV81UserInfoResponseUserEmailTag), StringUtil.RTrim( context.localUtil.Format( AV81UserInfoResponseUserEmailTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,474);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuseremailtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuseremailtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserverifiedemailtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserverifiedemailtag_Internalname, "User Verified Email Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 478,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserverifiedemailtag_Internalname, StringUtil.RTrim( AV93UserInfoResponseUserVerifiedEmailTag), StringUtil.RTrim( context.localUtil.Format( AV93UserInfoResponseUserVerifiedEmailTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,478);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserverifiedemailtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserverifiedemailtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserexternalidtag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserexternalidtag_Internalname, "External Id Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 483,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserexternalidtag_Internalname, StringUtil.RTrim( AV82UserInfoResponseUserExternalIdTag), StringUtil.RTrim( context.localUtil.Format( AV82UserInfoResponseUserExternalIdTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,483);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserexternalidtag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserexternalidtag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseusernametag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusernametag_Internalname, "User Name Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 487,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusernametag_Internalname, StringUtil.RTrim( AV89UserInfoResponseUserNameTag), StringUtil.RTrim( context.localUtil.Format( AV89UserInfoResponseUserNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,487);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusernametag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusernametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserfirstnametag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserfirstnametag_Internalname, "User First Name Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 492,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserfirstnametag_Internalname, StringUtil.RTrim( AV83UserInfoResponseUserFirstNameTag), StringUtil.RTrim( context.localUtil.Format( AV83UserInfoResponseUserFirstNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,492);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserfirstnametag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserfirstnametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavUserinforesponseuserlastnamegenauto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUserinforesponseuserlastnamegenauto_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 497,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUserinforesponseuserlastnamegenauto_Internalname, StringUtil.BoolToStr( AV87UserInfoResponseUserLastNameGenAuto), "", " ", 1, chkavUserinforesponseuserlastnamegenauto.Enabled, "true", "Generate automatic Last Name", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(497, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,497);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbuserlastnamehelp_Internalname, lblTbuserlastnamehelp_Caption, "", "", lblTbuserlastnamehelp_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeSizeSmall", 0, "", 1, 1, 0, 0, "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUserinforesponseuserlastnametag_cell_Internalname, 1, 0, "px", 0, "px", divUserinforesponseuserlastnametag_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserinforesponseuserlastnametag_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserlastnametag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserlastnametag_Internalname, "User Last Name Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 504,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserlastnametag_Internalname, StringUtil.RTrim( AV88UserInfoResponseUserLastNameTag), StringUtil.RTrim( context.localUtil.Format( AV88UserInfoResponseUserLastNameTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,504);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserlastnametag_Jsonclick, 0, "Attribute", "", "", "", "", edtavUserinforesponseuserlastnametag_Visible, edtavUserinforesponseuserlastnametag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseusergendertag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusergendertag_Internalname, "User Gender Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 508,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusergendertag_Internalname, StringUtil.RTrim( AV84UserInfoResponseUserGenderTag), StringUtil.RTrim( context.localUtil.Format( AV84UserInfoResponseUserGenderTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,508);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusergendertag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusergendertag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseusergendervalues_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusergendervalues_Internalname, "User Gender Values", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 513,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusergendervalues_Internalname, AV85UserInfoResponseUserGenderValues, StringUtil.RTrim( context.localUtil.Format( AV85UserInfoResponseUserGenderValues, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,513);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusergendervalues_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusergendervalues_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMPropertyValue", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserbirthdaytag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserbirthdaytag_Internalname, "User Birthday Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 517,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserbirthdaytag_Internalname, StringUtil.RTrim( AV80UserInfoResponseUserBirthdayTag), StringUtil.RTrim( context.localUtil.Format( AV80UserInfoResponseUserBirthdayTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,517);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserbirthdaytag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserbirthdaytag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserurlimagetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserurlimagetag_Internalname, "User URL Image Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 522,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserurlimagetag_Internalname, StringUtil.RTrim( AV91UserInfoResponseUserURLImageTag), StringUtil.RTrim( context.localUtil.Format( AV91UserInfoResponseUserURLImageTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,522);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserurlimagetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserurlimagetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserurlprofiletag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserurlprofiletag_Internalname, "User URL Profile Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 526,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserurlprofiletag_Internalname, StringUtil.RTrim( AV92UserInfoResponseUserURLProfileTag), StringUtil.RTrim( context.localUtil.Format( AV92UserInfoResponseUserURLProfileTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,526);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserurlprofiletag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserurlprofiletag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseuserlanguagetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseuserlanguagetag_Internalname, "User Language Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 531,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseuserlanguagetag_Internalname, StringUtil.RTrim( AV86UserInfoResponseUserLanguageTag), StringUtil.RTrim( context.localUtil.Format( AV86UserInfoResponseUserLanguageTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,531);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseuserlanguagetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseuserlanguagetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseusertimezonetag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseusertimezonetag_Internalname, "User Timezone Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 535,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseusertimezonetag_Internalname, StringUtil.RTrim( AV90UserInfoResponseUserTimeZoneTag), StringUtil.RTrim( context.localUtil.Format( AV90UserInfoResponseUserTimeZoneTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,535);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseusertimezonetag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseusertimezonetag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserinforesponseerrordescriptiontag_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserinforesponseerrordescriptiontag_Internalname, "Error Description Tag", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 540,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserinforesponseerrordescriptiontag_Internalname, StringUtil.RTrim( AV79UserInfoResponseErrorDescriptionTag), StringUtil.RTrim( context.localUtil.Format( AV79UserInfoResponseErrorDescriptionTag, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,540);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserinforesponseerrordescriptiontag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserinforesponseerrordescriptiontag_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            ucDvpanel_unnamedtable5.SetProperty("Width", Dvpanel_unnamedtable5_Width);
            ucDvpanel_unnamedtable5.SetProperty("AutoWidth", Dvpanel_unnamedtable5_Autowidth);
            ucDvpanel_unnamedtable5.SetProperty("AutoHeight", Dvpanel_unnamedtable5_Autoheight);
            ucDvpanel_unnamedtable5.SetProperty("Cls", Dvpanel_unnamedtable5_Cls);
            ucDvpanel_unnamedtable5.SetProperty("Title", Dvpanel_unnamedtable5_Title);
            ucDvpanel_unnamedtable5.SetProperty("Collapsible", Dvpanel_unnamedtable5_Collapsible);
            ucDvpanel_unnamedtable5.SetProperty("Collapsed", Dvpanel_unnamedtable5_Collapsed);
            ucDvpanel_unnamedtable5.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable5_Showcollapseicon);
            ucDvpanel_unnamedtable5.SetProperty("IconPosition", Dvpanel_unnamedtable5_Iconposition);
            ucDvpanel_unnamedtable5.SetProperty("AutoScroll", Dvpanel_unnamedtable5_Autoscroll);
            ucDvpanel_unnamedtable5.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable5_Internalname, sPrefix+"DVPANEL_UNNAMEDTABLE5Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_UNNAMEDTABLE5Container"+"UnnamedTable5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell CellMarginTop HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl548( ) ;
         }
         if ( wbEnd == 548 )
         {
            wbEnd = 0;
            nRC_GXsfl_548 = (int)(nGXsfl_548_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 554,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonAddNewRow";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnadd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(548), 3, 0)+","+"null"+");", "Insert", bttBtnadd_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtnadd_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 559,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(548), 3, 0)+","+"null"+");", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 561,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(548), 3, 0)+","+"null"+");", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWCAuthenticationTypeEntryOauth20.htm");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 548 )
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
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START142( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", "Authentication Type Entry Oauth20", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP140( ) ;
            }
         }
      }

      protected void WS142( )
      {
         START142( ) ;
         EVT142( ) ;
      }

      protected void EVT142( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAdd' */
                                    E11142 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VIDP.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E12142 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E13142 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDynamicpropname_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VDELETEPROPERTY.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "VDELETEPROPERTY.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP140( ) ;
                              }
                              nGXsfl_548_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_548_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_548_idx), 4, 0), 4, "0");
                              SubsflControlProps_5482( ) ;
                              AV26DynamicPropName = cgiGet( edtavDynamicpropname_Internalname);
                              AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV26DynamicPropName);
                              AV27DynamicPropTag = cgiGet( edtavDynamicproptag_Internalname);
                              AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV27DynamicPropTag);
                              AV24DeleteProperty = cgiGet( edtavDeleteproperty_Internalname);
                              AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24DeleteProperty)) ? AV221Deleteproperty_GXI : context.convertURL( context.PathToRelativeUrl( AV24DeleteProperty))), !bGXsfl_548_Refreshing);
                              AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "SrcSet", context.GetImageSrcSet( AV24DeleteProperty), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E14142 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E15142 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETEPROPERTY.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E16142 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP140( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDynamicpropname_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WE142( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm142( ) ;
            }
         }
      }

      protected void PA142( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = cmbavIdp_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_5482( ) ;
         while ( nGXsfl_548_idx <= nRC_GXsfl_548 )
         {
            sendrow_5482( ) ;
            nGXsfl_548_idx = ((subGrid_Islastpage==1)&&(nGXsfl_548_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_548_idx+1);
            sGXsfl_548_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_548_idx), 4, 0), 4, "0");
            SubsflControlProps_5482( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string Gx_mode ,
                                       bool AV33IsEnable ,
                                       bool AV40Oauth20RedirectURLisCustom ,
                                       bool AV111Oauth20RedirectURL_AutocompleteVirtualDirectory ,
                                       bool AV39Oauth20RedirectToAuthenticate ,
                                       bool AV14AuthRespTypeInclude ,
                                       bool AV17AuthScopeInclude ,
                                       bool AV98AuthStateInclude ,
                                       bool AV7AuthClientIdInclude ,
                                       bool AV8AuthClientSecretInclude ,
                                       bool AV99AuthRedirURLInclude ,
                                       bool AV109AuthOpenIDConnectProtocolEnable ,
                                       bool AV110AuthValidIdToken ,
                                       bool AV106AuthAllowOnlyUserEmailVerified ,
                                       bool AV51TokenHeaderAuthenticationInclude ,
                                       bool AV54TokenHeaderAuthorizationBasicInclude ,
                                       bool AV48TokenGrantTypeInclude ,
                                       bool AV44TokenAccessCodeInclude ,
                                       bool AV46TokenCliIdInclude ,
                                       bool AV47TokenCliSecretInclude ,
                                       bool AV58TokenRedirectURLInclude ,
                                       bool AV22AutovalidateExternalTokenAndRefresh ,
                                       bool AV69UserInfoAccessTokenInclude ,
                                       bool AV72UserInfoClientIdInclude ,
                                       bool AV74UserInfoClientSecretInclude ,
                                       bool AV95UserInfoUserIdInclude ,
                                       bool AV87UserInfoResponseUserLastNameGenAuto ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF142( ) ;
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
         if ( cmbavIdp.ItemCount > 0 )
         {
            AV151IDP = cmbavIdp.getValidValue(AV151IDP);
            AssignAttri(sPrefix, false, "AV151IDP", AV151IDP);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavIdp.CurrentValue = StringUtil.RTrim( AV151IDP);
            AssignProp(sPrefix, false, cmbavIdp_Internalname, "Values", cmbavIdp.ToJavascriptSource(), true);
         }
         if ( cmbavFunctionid.ItemCount > 0 )
         {
            AV30FunctionId = cmbavFunctionid.getValidValue(AV30FunctionId);
            AssignAttri(sPrefix, false, "AV30FunctionId", AV30FunctionId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV30FunctionId);
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", cmbavFunctionid.ToJavascriptSource(), true);
         }
         AV33IsEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV33IsEnable));
         AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
         if ( cmbavImpersonate.ItemCount > 0 )
         {
            AV32Impersonate = cmbavImpersonate.getValidValue(AV32Impersonate);
            AssignAttri(sPrefix, false, "AV32Impersonate", AV32Impersonate);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavImpersonate.CurrentValue = StringUtil.RTrim( AV32Impersonate);
            AssignProp(sPrefix, false, cmbavImpersonate_Internalname, "Values", cmbavImpersonate.ToJavascriptSource(), true);
         }
         AV40Oauth20RedirectURLisCustom = StringUtil.StrToBool( StringUtil.BoolToStr( AV40Oauth20RedirectURLisCustom));
         AssignAttri(sPrefix, false, "AV40Oauth20RedirectURLisCustom", AV40Oauth20RedirectURLisCustom);
         AV111Oauth20RedirectURL_AutocompleteVirtualDirectory = StringUtil.StrToBool( StringUtil.BoolToStr( AV111Oauth20RedirectURL_AutocompleteVirtualDirectory));
         AssignAttri(sPrefix, false, "AV111Oauth20RedirectURL_AutocompleteVirtualDirectory", AV111Oauth20RedirectURL_AutocompleteVirtualDirectory);
         AV39Oauth20RedirectToAuthenticate = StringUtil.StrToBool( StringUtil.BoolToStr( AV39Oauth20RedirectToAuthenticate));
         AssignAttri(sPrefix, false, "AV39Oauth20RedirectToAuthenticate", AV39Oauth20RedirectToAuthenticate);
         AV14AuthRespTypeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV14AuthRespTypeInclude));
         AssignAttri(sPrefix, false, "AV14AuthRespTypeInclude", AV14AuthRespTypeInclude);
         AV17AuthScopeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV17AuthScopeInclude));
         AssignAttri(sPrefix, false, "AV17AuthScopeInclude", AV17AuthScopeInclude);
         AV98AuthStateInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV98AuthStateInclude));
         AssignAttri(sPrefix, false, "AV98AuthStateInclude", AV98AuthStateInclude);
         AV7AuthClientIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV7AuthClientIdInclude));
         AssignAttri(sPrefix, false, "AV7AuthClientIdInclude", AV7AuthClientIdInclude);
         AV8AuthClientSecretInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV8AuthClientSecretInclude));
         AssignAttri(sPrefix, false, "AV8AuthClientSecretInclude", AV8AuthClientSecretInclude);
         AV99AuthRedirURLInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV99AuthRedirURLInclude));
         AssignAttri(sPrefix, false, "AV99AuthRedirURLInclude", AV99AuthRedirURLInclude);
         AV109AuthOpenIDConnectProtocolEnable = StringUtil.StrToBool( StringUtil.BoolToStr( AV109AuthOpenIDConnectProtocolEnable));
         AssignAttri(sPrefix, false, "AV109AuthOpenIDConnectProtocolEnable", AV109AuthOpenIDConnectProtocolEnable);
         AV110AuthValidIdToken = StringUtil.StrToBool( StringUtil.BoolToStr( AV110AuthValidIdToken));
         AssignAttri(sPrefix, false, "AV110AuthValidIdToken", AV110AuthValidIdToken);
         AV106AuthAllowOnlyUserEmailVerified = StringUtil.StrToBool( StringUtil.BoolToStr( AV106AuthAllowOnlyUserEmailVerified));
         AssignAttri(sPrefix, false, "AV106AuthAllowOnlyUserEmailVerified", AV106AuthAllowOnlyUserEmailVerified);
         if ( cmbavTokenmethod.ItemCount > 0 )
         {
            AV57TokenMethod = cmbavTokenmethod.getValidValue(AV57TokenMethod);
            AssignAttri(sPrefix, false, "AV57TokenMethod", AV57TokenMethod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTokenmethod.CurrentValue = StringUtil.RTrim( AV57TokenMethod);
            AssignProp(sPrefix, false, cmbavTokenmethod_Internalname, "Values", cmbavTokenmethod.ToJavascriptSource(), true);
         }
         AV51TokenHeaderAuthenticationInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV51TokenHeaderAuthenticationInclude));
         AssignAttri(sPrefix, false, "AV51TokenHeaderAuthenticationInclude", AV51TokenHeaderAuthenticationInclude);
         AV54TokenHeaderAuthorizationBasicInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV54TokenHeaderAuthorizationBasicInclude));
         AssignAttri(sPrefix, false, "AV54TokenHeaderAuthorizationBasicInclude", AV54TokenHeaderAuthorizationBasicInclude);
         if ( cmbavTokenheaderauthenticationmethod.ItemCount > 0 )
         {
            AV52TokenHeaderAuthenticationMethod = (short)(Math.Round(NumberUtil.Val( cmbavTokenheaderauthenticationmethod.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52TokenHeaderAuthenticationMethod), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV52TokenHeaderAuthenticationMethod", StringUtil.LTrimStr( (decimal)(AV52TokenHeaderAuthenticationMethod), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavTokenheaderauthenticationmethod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52TokenHeaderAuthenticationMethod), 4, 0));
            AssignProp(sPrefix, false, cmbavTokenheaderauthenticationmethod_Internalname, "Values", cmbavTokenheaderauthenticationmethod.ToJavascriptSource(), true);
         }
         AV48TokenGrantTypeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV48TokenGrantTypeInclude));
         AssignAttri(sPrefix, false, "AV48TokenGrantTypeInclude", AV48TokenGrantTypeInclude);
         AV44TokenAccessCodeInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV44TokenAccessCodeInclude));
         AssignAttri(sPrefix, false, "AV44TokenAccessCodeInclude", AV44TokenAccessCodeInclude);
         AV46TokenCliIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV46TokenCliIdInclude));
         AssignAttri(sPrefix, false, "AV46TokenCliIdInclude", AV46TokenCliIdInclude);
         AV47TokenCliSecretInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV47TokenCliSecretInclude));
         AssignAttri(sPrefix, false, "AV47TokenCliSecretInclude", AV47TokenCliSecretInclude);
         AV58TokenRedirectURLInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV58TokenRedirectURLInclude));
         AssignAttri(sPrefix, false, "AV58TokenRedirectURLInclude", AV58TokenRedirectURLInclude);
         AV22AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( StringUtil.BoolToStr( AV22AutovalidateExternalTokenAndRefresh));
         AssignAttri(sPrefix, false, "AV22AutovalidateExternalTokenAndRefresh", AV22AutovalidateExternalTokenAndRefresh);
         if ( cmbavUserinfomethod.ItemCount > 0 )
         {
            AV78UserInfoMethod = cmbavUserinfomethod.getValidValue(AV78UserInfoMethod);
            AssignAttri(sPrefix, false, "AV78UserInfoMethod", AV78UserInfoMethod);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUserinfomethod.CurrentValue = StringUtil.RTrim( AV78UserInfoMethod);
            AssignProp(sPrefix, false, cmbavUserinfomethod_Internalname, "Values", cmbavUserinfomethod.ToJavascriptSource(), true);
         }
         AV69UserInfoAccessTokenInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV69UserInfoAccessTokenInclude));
         AssignAttri(sPrefix, false, "AV69UserInfoAccessTokenInclude", AV69UserInfoAccessTokenInclude);
         AV72UserInfoClientIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV72UserInfoClientIdInclude));
         AssignAttri(sPrefix, false, "AV72UserInfoClientIdInclude", AV72UserInfoClientIdInclude);
         AV74UserInfoClientSecretInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV74UserInfoClientSecretInclude));
         AssignAttri(sPrefix, false, "AV74UserInfoClientSecretInclude", AV74UserInfoClientSecretInclude);
         AV95UserInfoUserIdInclude = StringUtil.StrToBool( StringUtil.BoolToStr( AV95UserInfoUserIdInclude));
         AssignAttri(sPrefix, false, "AV95UserInfoUserIdInclude", AV95UserInfoUserIdInclude);
         AV87UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( StringUtil.BoolToStr( AV87UserInfoResponseUserLastNameGenAuto));
         AssignAttri(sPrefix, false, "AV87UserInfoResponseUserLastNameGenAuto", AV87UserInfoResponseUserLastNameGenAuto);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF142( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF142( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 548;
         nGXsfl_548_idx = 1;
         sGXsfl_548_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_548_idx), 4, 0), 4, "0");
         SubsflControlProps_5482( ) ;
         bGXsfl_548_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_5482( ) ;
            /* Execute user event: Grid.Load */
            E15142 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_548_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E15142 ();
            }
            wbEnd = 548;
            WB140( ) ;
         }
         bGXsfl_548_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes142( )
      {
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
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
         return (int)(((subGrid_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV33IsEnable, AV40Oauth20RedirectURLisCustom, AV111Oauth20RedirectURL_AutocompleteVirtualDirectory, AV39Oauth20RedirectToAuthenticate, AV14AuthRespTypeInclude, AV17AuthScopeInclude, AV98AuthStateInclude, AV7AuthClientIdInclude, AV8AuthClientSecretInclude, AV99AuthRedirURLInclude, AV109AuthOpenIDConnectProtocolEnable, AV110AuthValidIdToken, AV106AuthAllowOnlyUserEmailVerified, AV51TokenHeaderAuthenticationInclude, AV54TokenHeaderAuthorizationBasicInclude, AV48TokenGrantTypeInclude, AV44TokenAccessCodeInclude, AV46TokenCliIdInclude, AV47TokenCliSecretInclude, AV58TokenRedirectURLInclude, AV22AutovalidateExternalTokenAndRefresh, AV69UserInfoAccessTokenInclude, AV72UserInfoClientIdInclude, AV74UserInfoClientSecretInclude, AV95UserInfoUserIdInclude, AV87UserInfoResponseUserLastNameGenAuto, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV33IsEnable, AV40Oauth20RedirectURLisCustom, AV111Oauth20RedirectURL_AutocompleteVirtualDirectory, AV39Oauth20RedirectToAuthenticate, AV14AuthRespTypeInclude, AV17AuthScopeInclude, AV98AuthStateInclude, AV7AuthClientIdInclude, AV8AuthClientSecretInclude, AV99AuthRedirURLInclude, AV109AuthOpenIDConnectProtocolEnable, AV110AuthValidIdToken, AV106AuthAllowOnlyUserEmailVerified, AV51TokenHeaderAuthenticationInclude, AV54TokenHeaderAuthorizationBasicInclude, AV48TokenGrantTypeInclude, AV44TokenAccessCodeInclude, AV46TokenCliIdInclude, AV47TokenCliSecretInclude, AV58TokenRedirectURLInclude, AV22AutovalidateExternalTokenAndRefresh, AV69UserInfoAccessTokenInclude, AV72UserInfoClientIdInclude, AV74UserInfoClientSecretInclude, AV95UserInfoUserIdInclude, AV87UserInfoResponseUserLastNameGenAuto, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV33IsEnable, AV40Oauth20RedirectURLisCustom, AV111Oauth20RedirectURL_AutocompleteVirtualDirectory, AV39Oauth20RedirectToAuthenticate, AV14AuthRespTypeInclude, AV17AuthScopeInclude, AV98AuthStateInclude, AV7AuthClientIdInclude, AV8AuthClientSecretInclude, AV99AuthRedirURLInclude, AV109AuthOpenIDConnectProtocolEnable, AV110AuthValidIdToken, AV106AuthAllowOnlyUserEmailVerified, AV51TokenHeaderAuthenticationInclude, AV54TokenHeaderAuthorizationBasicInclude, AV48TokenGrantTypeInclude, AV44TokenAccessCodeInclude, AV46TokenCliIdInclude, AV47TokenCliSecretInclude, AV58TokenRedirectURLInclude, AV22AutovalidateExternalTokenAndRefresh, AV69UserInfoAccessTokenInclude, AV72UserInfoClientIdInclude, AV74UserInfoClientSecretInclude, AV95UserInfoUserIdInclude, AV87UserInfoResponseUserLastNameGenAuto, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV33IsEnable, AV40Oauth20RedirectURLisCustom, AV111Oauth20RedirectURL_AutocompleteVirtualDirectory, AV39Oauth20RedirectToAuthenticate, AV14AuthRespTypeInclude, AV17AuthScopeInclude, AV98AuthStateInclude, AV7AuthClientIdInclude, AV8AuthClientSecretInclude, AV99AuthRedirURLInclude, AV109AuthOpenIDConnectProtocolEnable, AV110AuthValidIdToken, AV106AuthAllowOnlyUserEmailVerified, AV51TokenHeaderAuthenticationInclude, AV54TokenHeaderAuthorizationBasicInclude, AV48TokenGrantTypeInclude, AV44TokenAccessCodeInclude, AV46TokenCliIdInclude, AV47TokenCliSecretInclude, AV58TokenRedirectURLInclude, AV22AutovalidateExternalTokenAndRefresh, AV69UserInfoAccessTokenInclude, AV72UserInfoClientIdInclude, AV74UserInfoClientSecretInclude, AV95UserInfoUserIdInclude, AV87UserInfoResponseUserLastNameGenAuto, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, Gx_mode, AV33IsEnable, AV40Oauth20RedirectURLisCustom, AV111Oauth20RedirectURL_AutocompleteVirtualDirectory, AV39Oauth20RedirectToAuthenticate, AV14AuthRespTypeInclude, AV17AuthScopeInclude, AV98AuthStateInclude, AV7AuthClientIdInclude, AV8AuthClientSecretInclude, AV99AuthRedirURLInclude, AV109AuthOpenIDConnectProtocolEnable, AV110AuthValidIdToken, AV106AuthAllowOnlyUserEmailVerified, AV51TokenHeaderAuthenticationInclude, AV54TokenHeaderAuthorizationBasicInclude, AV48TokenGrantTypeInclude, AV44TokenAccessCodeInclude, AV46TokenCliIdInclude, AV47TokenCliSecretInclude, AV58TokenRedirectURLInclude, AV22AutovalidateExternalTokenAndRefresh, AV69UserInfoAccessTokenInclude, AV72UserInfoClientIdInclude, AV74UserInfoClientSecretInclude, AV95UserInfoUserIdInclude, AV87UserInfoResponseUserLastNameGenAuto, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP140( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14142 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_548 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_548"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV34Name = cgiGet( sPrefix+"wcpOAV34Name");
            wcpOAV68TypeId = cgiGet( sPrefix+"wcpOAV68TypeId");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"subGrid_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvpanel_groupauthopenidconnecttable1_Width = cgiGet( sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Width");
            Dvpanel_groupauthopenidconnecttable1_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Autowidth"));
            Dvpanel_groupauthopenidconnecttable1_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Autoheight"));
            Dvpanel_groupauthopenidconnecttable1_Cls = cgiGet( sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Cls");
            Dvpanel_groupauthopenidconnecttable1_Title = cgiGet( sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Title");
            Dvpanel_groupauthopenidconnecttable1_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Collapsible"));
            Dvpanel_groupauthopenidconnecttable1_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Collapsed"));
            Dvpanel_groupauthopenidconnecttable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Showcollapseicon"));
            Dvpanel_groupauthopenidconnecttable1_Iconposition = cgiGet( sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Iconposition");
            Dvpanel_groupauthopenidconnecttable1_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1_Autoscroll"));
            Dvpanel_unnamedtable14_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE14_Width");
            Dvpanel_unnamedtable14_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE14_Autowidth"));
            Dvpanel_unnamedtable14_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE14_Autoheight"));
            Dvpanel_unnamedtable14_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE14_Cls");
            Dvpanel_unnamedtable14_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE14_Title");
            Dvpanel_unnamedtable14_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE14_Collapsible"));
            Dvpanel_unnamedtable14_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE14_Collapsed"));
            Dvpanel_unnamedtable14_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE14_Showcollapseicon"));
            Dvpanel_unnamedtable14_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE14_Iconposition");
            Dvpanel_unnamedtable14_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE14_Autoscroll"));
            Dvpanel_unnamedtable13_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE13_Width");
            Dvpanel_unnamedtable13_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE13_Autowidth"));
            Dvpanel_unnamedtable13_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE13_Autoheight"));
            Dvpanel_unnamedtable13_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE13_Cls");
            Dvpanel_unnamedtable13_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE13_Title");
            Dvpanel_unnamedtable13_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE13_Collapsible"));
            Dvpanel_unnamedtable13_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE13_Collapsed"));
            Dvpanel_unnamedtable13_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE13_Showcollapseicon"));
            Dvpanel_unnamedtable13_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE13_Iconposition");
            Dvpanel_unnamedtable13_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE13_Autoscroll"));
            Dvpanel_unnamedtable7_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Width");
            Dvpanel_unnamedtable7_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Autowidth"));
            Dvpanel_unnamedtable7_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Autoheight"));
            Dvpanel_unnamedtable7_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Cls");
            Dvpanel_unnamedtable7_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Title");
            Dvpanel_unnamedtable7_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Collapsible"));
            Dvpanel_unnamedtable7_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Collapsed"));
            Dvpanel_unnamedtable7_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Showcollapseicon"));
            Dvpanel_unnamedtable7_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Iconposition");
            Dvpanel_unnamedtable7_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE7_Autoscroll"));
            Dvpanel_unnamedtable9_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Width");
            Dvpanel_unnamedtable9_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Autowidth"));
            Dvpanel_unnamedtable9_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Autoheight"));
            Dvpanel_unnamedtable9_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Cls");
            Dvpanel_unnamedtable9_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Title");
            Dvpanel_unnamedtable9_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Collapsible"));
            Dvpanel_unnamedtable9_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Collapsed"));
            Dvpanel_unnamedtable9_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Showcollapseicon"));
            Dvpanel_unnamedtable9_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Iconposition");
            Dvpanel_unnamedtable9_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE9_Autoscroll"));
            Dvpanel_unnamedtable10_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Width");
            Dvpanel_unnamedtable10_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Autowidth"));
            Dvpanel_unnamedtable10_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Autoheight"));
            Dvpanel_unnamedtable10_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Cls");
            Dvpanel_unnamedtable10_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Title");
            Dvpanel_unnamedtable10_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Collapsible"));
            Dvpanel_unnamedtable10_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Collapsed"));
            Dvpanel_unnamedtable10_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Showcollapseicon"));
            Dvpanel_unnamedtable10_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Iconposition");
            Dvpanel_unnamedtable10_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE10_Autoscroll"));
            Dvpanel_unnamedtable11_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE11_Width");
            Dvpanel_unnamedtable11_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE11_Autowidth"));
            Dvpanel_unnamedtable11_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE11_Autoheight"));
            Dvpanel_unnamedtable11_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE11_Cls");
            Dvpanel_unnamedtable11_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE11_Title");
            Dvpanel_unnamedtable11_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE11_Collapsible"));
            Dvpanel_unnamedtable11_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE11_Collapsed"));
            Dvpanel_unnamedtable11_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE11_Showcollapseicon"));
            Dvpanel_unnamedtable11_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE11_Iconposition");
            Dvpanel_unnamedtable11_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE11_Autoscroll"));
            Dvpanel_unnamedtable8_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Width");
            Dvpanel_unnamedtable8_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Autowidth"));
            Dvpanel_unnamedtable8_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Autoheight"));
            Dvpanel_unnamedtable8_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Cls");
            Dvpanel_unnamedtable8_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Title");
            Dvpanel_unnamedtable8_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Collapsible"));
            Dvpanel_unnamedtable8_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Collapsed"));
            Dvpanel_unnamedtable8_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Showcollapseicon"));
            Dvpanel_unnamedtable8_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Iconposition");
            Dvpanel_unnamedtable8_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE8_Autoscroll"));
            Dvpanel_unnamedtable2_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Width");
            Dvpanel_unnamedtable2_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Autowidth"));
            Dvpanel_unnamedtable2_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Autoheight"));
            Dvpanel_unnamedtable2_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Cls");
            Dvpanel_unnamedtable2_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Title");
            Dvpanel_unnamedtable2_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Collapsible"));
            Dvpanel_unnamedtable2_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Collapsed"));
            Dvpanel_unnamedtable2_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Showcollapseicon"));
            Dvpanel_unnamedtable2_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Iconposition");
            Dvpanel_unnamedtable2_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE2_Autoscroll"));
            Dvpanel_paneluserbody_Width = cgiGet( sPrefix+"DVPANEL_PANELUSERBODY_Width");
            Dvpanel_paneluserbody_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELUSERBODY_Autowidth"));
            Dvpanel_paneluserbody_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELUSERBODY_Autoheight"));
            Dvpanel_paneluserbody_Cls = cgiGet( sPrefix+"DVPANEL_PANELUSERBODY_Cls");
            Dvpanel_paneluserbody_Title = cgiGet( sPrefix+"DVPANEL_PANELUSERBODY_Title");
            Dvpanel_paneluserbody_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELUSERBODY_Collapsible"));
            Dvpanel_paneluserbody_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELUSERBODY_Collapsed"));
            Dvpanel_paneluserbody_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELUSERBODY_Showcollapseicon"));
            Dvpanel_paneluserbody_Iconposition = cgiGet( sPrefix+"DVPANEL_PANELUSERBODY_Iconposition");
            Dvpanel_paneluserbody_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_PANELUSERBODY_Autoscroll"));
            Dvpanel_unnamedtable4_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Width");
            Dvpanel_unnamedtable4_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Autowidth"));
            Dvpanel_unnamedtable4_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Autoheight"));
            Dvpanel_unnamedtable4_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Cls");
            Dvpanel_unnamedtable4_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Title");
            Dvpanel_unnamedtable4_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Collapsible"));
            Dvpanel_unnamedtable4_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Collapsed"));
            Dvpanel_unnamedtable4_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Showcollapseicon"));
            Dvpanel_unnamedtable4_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Iconposition");
            Dvpanel_unnamedtable4_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE4_Autoscroll"));
            Dvpanel_unnamedtable5_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Width");
            Dvpanel_unnamedtable5_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Autowidth"));
            Dvpanel_unnamedtable5_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Autoheight"));
            Dvpanel_unnamedtable5_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Cls");
            Dvpanel_unnamedtable5_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Title");
            Dvpanel_unnamedtable5_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Collapsible"));
            Dvpanel_unnamedtable5_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Collapsed"));
            Dvpanel_unnamedtable5_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Showcollapseicon"));
            Dvpanel_unnamedtable5_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Iconposition");
            Dvpanel_unnamedtable5_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE5_Autoscroll"));
            Dvpanel_unnamedtable3_Width = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Width");
            Dvpanel_unnamedtable3_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Autowidth"));
            Dvpanel_unnamedtable3_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoheight"));
            Dvpanel_unnamedtable3_Cls = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Cls");
            Dvpanel_unnamedtable3_Title = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Title");
            Dvpanel_unnamedtable3_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsible"));
            Dvpanel_unnamedtable3_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Collapsed"));
            Dvpanel_unnamedtable3_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Showcollapseicon"));
            Dvpanel_unnamedtable3_Iconposition = cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Iconposition");
            Dvpanel_unnamedtable3_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_UNNAMEDTABLE3_Autoscroll"));
            Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GXUITABSPANEL_TABS_Pagecount"), ".", ","), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs_Class = cgiGet( sPrefix+"GXUITABSPANEL_TABS_Class");
            Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( sPrefix+"GXUITABSPANEL_TABS_Historymanagement"));
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            /* Read variables values. */
            cmbavIdp.Name = cmbavIdp_Internalname;
            cmbavIdp.CurrentValue = cgiGet( cmbavIdp_Internalname);
            AV151IDP = cgiGet( cmbavIdp_Internalname);
            AssignAttri(sPrefix, false, "AV151IDP", AV151IDP);
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               AV34Name = cgiGet( edtavName_Internalname);
               AssignAttri(sPrefix, false, "AV34Name", AV34Name);
            }
            cmbavFunctionid.Name = cmbavFunctionid_Internalname;
            cmbavFunctionid.CurrentValue = cgiGet( cmbavFunctionid_Internalname);
            AV30FunctionId = cgiGet( cmbavFunctionid_Internalname);
            AssignAttri(sPrefix, false, "AV30FunctionId", AV30FunctionId);
            AV25Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri(sPrefix, false, "AV25Dsc", AV25Dsc);
            AV33IsEnable = StringUtil.StrToBool( cgiGet( chkavIsenable_Internalname));
            AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
            cmbavImpersonate.Name = cmbavImpersonate_Internalname;
            cmbavImpersonate.CurrentValue = cgiGet( cmbavImpersonate_Internalname);
            AV32Impersonate = cgiGet( cmbavImpersonate_Internalname);
            AssignAttri(sPrefix, false, "AV32Impersonate", AV32Impersonate);
            AV43SmallImageName = cgiGet( edtavSmallimagename_Internalname);
            AssignAttri(sPrefix, false, "AV43SmallImageName", AV43SmallImageName);
            AV23BigImageName = cgiGet( edtavBigimagename_Internalname);
            AssignAttri(sPrefix, false, "AV23BigImageName", AV23BigImageName);
            AV35Oauth20ClientIdTag = cgiGet( edtavOauth20clientidtag_Internalname);
            AssignAttri(sPrefix, false, "AV35Oauth20ClientIdTag", AV35Oauth20ClientIdTag);
            AV36Oauth20ClientIdValue = cgiGet( edtavOauth20clientidvalue_Internalname);
            AssignAttri(sPrefix, false, "AV36Oauth20ClientIdValue", AV36Oauth20ClientIdValue);
            AV37Oauth20ClientSecretTag = cgiGet( edtavOauth20clientsecrettag_Internalname);
            AssignAttri(sPrefix, false, "AV37Oauth20ClientSecretTag", AV37Oauth20ClientSecretTag);
            AV38Oauth20ClientSecretValue = cgiGet( edtavOauth20clientsecretvalue_Internalname);
            AssignAttri(sPrefix, false, "AV38Oauth20ClientSecretValue", AV38Oauth20ClientSecretValue);
            AV41Oauth20RedirectURLTag = cgiGet( edtavOauth20redirecturltag_Internalname);
            AssignAttri(sPrefix, false, "AV41Oauth20RedirectURLTag", AV41Oauth20RedirectURLTag);
            AV42Oauth20RedirectURLvalue = cgiGet( edtavOauth20redirecturlvalue_Internalname);
            AssignAttri(sPrefix, false, "AV42Oauth20RedirectURLvalue", AV42Oauth20RedirectURLvalue);
            AV40Oauth20RedirectURLisCustom = StringUtil.StrToBool( cgiGet( chkavOauth20redirecturliscustom_Internalname));
            AssignAttri(sPrefix, false, "AV40Oauth20RedirectURLisCustom", AV40Oauth20RedirectURLisCustom);
            AV111Oauth20RedirectURL_AutocompleteVirtualDirectory = StringUtil.StrToBool( cgiGet( chkavOauth20redirecturl_autocompletevirtualdirectory_Internalname));
            AssignAttri(sPrefix, false, "AV111Oauth20RedirectURL_AutocompleteVirtualDirectory", AV111Oauth20RedirectURL_AutocompleteVirtualDirectory);
            AV39Oauth20RedirectToAuthenticate = StringUtil.StrToBool( cgiGet( chkavOauth20redirecttoauthenticate_Internalname));
            AssignAttri(sPrefix, false, "AV39Oauth20RedirectToAuthenticate", AV39Oauth20RedirectToAuthenticate);
            AV10AuthorizeURL = cgiGet( edtavAuthorizeurl_Internalname);
            AssignAttri(sPrefix, false, "AV10AuthorizeURL", AV10AuthorizeURL);
            AV14AuthRespTypeInclude = StringUtil.StrToBool( cgiGet( chkavAuthresptypeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV14AuthRespTypeInclude", AV14AuthRespTypeInclude);
            AV15AuthRespTypeTag = cgiGet( edtavAuthresptypetag_Internalname);
            AssignAttri(sPrefix, false, "AV15AuthRespTypeTag", AV15AuthRespTypeTag);
            AV16AuthRespTypeValue = cgiGet( edtavAuthresptypevalue_Internalname);
            AssignAttri(sPrefix, false, "AV16AuthRespTypeValue", AV16AuthRespTypeValue);
            AV17AuthScopeInclude = StringUtil.StrToBool( cgiGet( chkavAuthscopeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV17AuthScopeInclude", AV17AuthScopeInclude);
            AV18AuthScopeTag = cgiGet( edtavAuthscopetag_Internalname);
            AssignAttri(sPrefix, false, "AV18AuthScopeTag", AV18AuthScopeTag);
            AV19AuthScopeValue = cgiGet( edtavAuthscopevalue_Internalname);
            AssignAttri(sPrefix, false, "AV19AuthScopeValue", AV19AuthScopeValue);
            AV98AuthStateInclude = StringUtil.StrToBool( cgiGet( chkavAuthstateinclude_Internalname));
            AssignAttri(sPrefix, false, "AV98AuthStateInclude", AV98AuthStateInclude);
            AV21AuthStateTag = cgiGet( edtavAuthstatetag_Internalname);
            AssignAttri(sPrefix, false, "AV21AuthStateTag", AV21AuthStateTag);
            AV7AuthClientIdInclude = StringUtil.StrToBool( cgiGet( chkavAuthclientidinclude_Internalname));
            AssignAttri(sPrefix, false, "AV7AuthClientIdInclude", AV7AuthClientIdInclude);
            AV8AuthClientSecretInclude = StringUtil.StrToBool( cgiGet( chkavAuthclientsecretinclude_Internalname));
            AssignAttri(sPrefix, false, "AV8AuthClientSecretInclude", AV8AuthClientSecretInclude);
            AV99AuthRedirURLInclude = StringUtil.StrToBool( cgiGet( chkavAuthredirurlinclude_Internalname));
            AssignAttri(sPrefix, false, "AV99AuthRedirURLInclude", AV99AuthRedirURLInclude);
            AV5AuthAdditionalParameters = cgiGet( edtavAuthadditionalparameters_Internalname);
            AssignAttri(sPrefix, false, "AV5AuthAdditionalParameters", AV5AuthAdditionalParameters);
            AV6AuthAdditionalParametersSD = cgiGet( edtavAuthadditionalparameterssd_Internalname);
            AssignAttri(sPrefix, false, "AV6AuthAdditionalParametersSD", AV6AuthAdditionalParametersSD);
            AV109AuthOpenIDConnectProtocolEnable = StringUtil.StrToBool( cgiGet( chkavAuthopenidconnectprotocolenable_Internalname));
            AssignAttri(sPrefix, false, "AV109AuthOpenIDConnectProtocolEnable", AV109AuthOpenIDConnectProtocolEnable);
            AV110AuthValidIdToken = StringUtil.StrToBool( cgiGet( chkavAuthvalididtoken_Internalname));
            AssignAttri(sPrefix, false, "AV110AuthValidIdToken", AV110AuthValidIdToken);
            AV108AuthIssuerURL = cgiGet( edtavAuthissuerurl_Internalname);
            AssignAttri(sPrefix, false, "AV108AuthIssuerURL", AV108AuthIssuerURL);
            AV107AuthCertificatePathFileName = cgiGet( edtavAuthcertificatepathfilename_Internalname);
            AssignAttri(sPrefix, false, "AV107AuthCertificatePathFileName", AV107AuthCertificatePathFileName);
            AV106AuthAllowOnlyUserEmailVerified = StringUtil.StrToBool( cgiGet( chkavAuthallowonlyuseremailverified_Internalname));
            AssignAttri(sPrefix, false, "AV106AuthAllowOnlyUserEmailVerified", AV106AuthAllowOnlyUserEmailVerified);
            AV12AuthResponseAccessCodeTag = cgiGet( edtavAuthresponseaccesscodetag_Internalname);
            AssignAttri(sPrefix, false, "AV12AuthResponseAccessCodeTag", AV12AuthResponseAccessCodeTag);
            AV13AuthResponseErrorDescTag = cgiGet( edtavAuthresponseerrordesctag_Internalname);
            AssignAttri(sPrefix, false, "AV13AuthResponseErrorDescTag", AV13AuthResponseErrorDescTag);
            AV67TokenURL = cgiGet( edtavTokenurl_Internalname);
            AssignAttri(sPrefix, false, "AV67TokenURL", AV67TokenURL);
            cmbavTokenmethod.Name = cmbavTokenmethod_Internalname;
            cmbavTokenmethod.CurrentValue = cgiGet( cmbavTokenmethod_Internalname);
            AV57TokenMethod = cgiGet( cmbavTokenmethod_Internalname);
            AssignAttri(sPrefix, false, "AV57TokenMethod", AV57TokenMethod);
            AV55TokenHeaderKeyTag = cgiGet( edtavTokenheaderkeytag_Internalname);
            AssignAttri(sPrefix, false, "AV55TokenHeaderKeyTag", AV55TokenHeaderKeyTag);
            AV56TokenHeaderKeyValue = cgiGet( edtavTokenheaderkeyvalue_Internalname);
            AssignAttri(sPrefix, false, "AV56TokenHeaderKeyValue", AV56TokenHeaderKeyValue);
            AV51TokenHeaderAuthenticationInclude = StringUtil.StrToBool( cgiGet( chkavTokenheaderauthenticationinclude_Internalname));
            AssignAttri(sPrefix, false, "AV51TokenHeaderAuthenticationInclude", AV51TokenHeaderAuthenticationInclude);
            AV54TokenHeaderAuthorizationBasicInclude = StringUtil.StrToBool( cgiGet( chkavTokenheaderauthorizationbasicinclude_Internalname));
            AssignAttri(sPrefix, false, "AV54TokenHeaderAuthorizationBasicInclude", AV54TokenHeaderAuthorizationBasicInclude);
            cmbavTokenheaderauthenticationmethod.Name = cmbavTokenheaderauthenticationmethod_Internalname;
            cmbavTokenheaderauthenticationmethod.CurrentValue = cgiGet( cmbavTokenheaderauthenticationmethod_Internalname);
            AV52TokenHeaderAuthenticationMethod = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavTokenheaderauthenticationmethod_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV52TokenHeaderAuthenticationMethod", StringUtil.LTrimStr( (decimal)(AV52TokenHeaderAuthenticationMethod), 4, 0));
            AV53TokenHeaderAuthenticationRealm = cgiGet( edtavTokenheaderauthenticationrealm_Internalname);
            AssignAttri(sPrefix, false, "AV53TokenHeaderAuthenticationRealm", AV53TokenHeaderAuthenticationRealm);
            AV48TokenGrantTypeInclude = StringUtil.StrToBool( cgiGet( chkavTokengranttypeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV48TokenGrantTypeInclude", AV48TokenGrantTypeInclude);
            AV49TokenGrantTypeTag = cgiGet( edtavTokengranttypetag_Internalname);
            AssignAttri(sPrefix, false, "AV49TokenGrantTypeTag", AV49TokenGrantTypeTag);
            AV50TokenGrantTypeValue = cgiGet( edtavTokengranttypevalue_Internalname);
            AssignAttri(sPrefix, false, "AV50TokenGrantTypeValue", AV50TokenGrantTypeValue);
            AV44TokenAccessCodeInclude = StringUtil.StrToBool( cgiGet( chkavTokenaccesscodeinclude_Internalname));
            AssignAttri(sPrefix, false, "AV44TokenAccessCodeInclude", AV44TokenAccessCodeInclude);
            AV46TokenCliIdInclude = StringUtil.StrToBool( cgiGet( chkavTokencliidinclude_Internalname));
            AssignAttri(sPrefix, false, "AV46TokenCliIdInclude", AV46TokenCliIdInclude);
            AV47TokenCliSecretInclude = StringUtil.StrToBool( cgiGet( chkavTokenclisecretinclude_Internalname));
            AssignAttri(sPrefix, false, "AV47TokenCliSecretInclude", AV47TokenCliSecretInclude);
            AV58TokenRedirectURLInclude = StringUtil.StrToBool( cgiGet( chkavTokenredirecturlinclude_Internalname));
            AssignAttri(sPrefix, false, "AV58TokenRedirectURLInclude", AV58TokenRedirectURLInclude);
            AV45TokenAdditionalParameters = cgiGet( edtavTokenadditionalparameters_Internalname);
            AssignAttri(sPrefix, false, "AV45TokenAdditionalParameters", AV45TokenAdditionalParameters);
            AV60TokenResponseAccessTokenTag = cgiGet( edtavTokenresponseaccesstokentag_Internalname);
            AssignAttri(sPrefix, false, "AV60TokenResponseAccessTokenTag", AV60TokenResponseAccessTokenTag);
            AV65TokenResponseTokenTypeTag = cgiGet( edtavTokenresponsetokentypetag_Internalname);
            AssignAttri(sPrefix, false, "AV65TokenResponseTokenTypeTag", AV65TokenResponseTokenTypeTag);
            AV62TokenResponseExpiresInTag = cgiGet( edtavTokenresponseexpiresintag_Internalname);
            AssignAttri(sPrefix, false, "AV62TokenResponseExpiresInTag", AV62TokenResponseExpiresInTag);
            AV64TokenResponseScopeTag = cgiGet( edtavTokenresponsescopetag_Internalname);
            AssignAttri(sPrefix, false, "AV64TokenResponseScopeTag", AV64TokenResponseScopeTag);
            AV66TokenResponseUserIdTag = cgiGet( edtavTokenresponseuseridtag_Internalname);
            AssignAttri(sPrefix, false, "AV66TokenResponseUserIdTag", AV66TokenResponseUserIdTag);
            AV63TokenResponseRefreshTokenTag = cgiGet( edtavTokenresponserefreshtokentag_Internalname);
            AssignAttri(sPrefix, false, "AV63TokenResponseRefreshTokenTag", AV63TokenResponseRefreshTokenTag);
            AV61TokenResponseErrorDescriptionTag = cgiGet( edtavTokenresponseerrordescriptiontag_Internalname);
            AssignAttri(sPrefix, false, "AV61TokenResponseErrorDescriptionTag", AV61TokenResponseErrorDescriptionTag);
            AV22AutovalidateExternalTokenAndRefresh = StringUtil.StrToBool( cgiGet( chkavAutovalidateexternaltokenandrefresh_Internalname));
            AssignAttri(sPrefix, false, "AV22AutovalidateExternalTokenAndRefresh", AV22AutovalidateExternalTokenAndRefresh);
            AV59TokenRefreshTokenURL = cgiGet( edtavTokenrefreshtokenurl_Internalname);
            AssignAttri(sPrefix, false, "AV59TokenRefreshTokenURL", AV59TokenRefreshTokenURL);
            AV94UserInfoURL = cgiGet( edtavUserinfourl_Internalname);
            AssignAttri(sPrefix, false, "AV94UserInfoURL", AV94UserInfoURL);
            cmbavUserinfomethod.Name = cmbavUserinfomethod_Internalname;
            cmbavUserinfomethod.CurrentValue = cgiGet( cmbavUserinfomethod_Internalname);
            AV78UserInfoMethod = cgiGet( cmbavUserinfomethod_Internalname);
            AssignAttri(sPrefix, false, "AV78UserInfoMethod", AV78UserInfoMethod);
            AV76UserInfoHeaderKeyTag = cgiGet( edtavUserinfoheaderkeytag_Internalname);
            AssignAttri(sPrefix, false, "AV76UserInfoHeaderKeyTag", AV76UserInfoHeaderKeyTag);
            AV77UserInfoHeaderKeyValue = cgiGet( edtavUserinfoheaderkeyvalue_Internalname);
            AssignAttri(sPrefix, false, "AV77UserInfoHeaderKeyValue", AV77UserInfoHeaderKeyValue);
            AV69UserInfoAccessTokenInclude = StringUtil.StrToBool( cgiGet( chkavUserinfoaccesstokeninclude_Internalname));
            AssignAttri(sPrefix, false, "AV69UserInfoAccessTokenInclude", AV69UserInfoAccessTokenInclude);
            AV70UserInfoAccessTokenName = cgiGet( edtavUserinfoaccesstokenname_Internalname);
            AssignAttri(sPrefix, false, "AV70UserInfoAccessTokenName", AV70UserInfoAccessTokenName);
            AV72UserInfoClientIdInclude = StringUtil.StrToBool( cgiGet( chkavUserinfoclientidinclude_Internalname));
            AssignAttri(sPrefix, false, "AV72UserInfoClientIdInclude", AV72UserInfoClientIdInclude);
            AV73UserInfoClientIdName = cgiGet( edtavUserinfoclientidname_Internalname);
            AssignAttri(sPrefix, false, "AV73UserInfoClientIdName", AV73UserInfoClientIdName);
            AV74UserInfoClientSecretInclude = StringUtil.StrToBool( cgiGet( chkavUserinfoclientsecretinclude_Internalname));
            AssignAttri(sPrefix, false, "AV74UserInfoClientSecretInclude", AV74UserInfoClientSecretInclude);
            AV75UserInfoClientSecretName = cgiGet( edtavUserinfoclientsecretname_Internalname);
            AssignAttri(sPrefix, false, "AV75UserInfoClientSecretName", AV75UserInfoClientSecretName);
            AV95UserInfoUserIdInclude = StringUtil.StrToBool( cgiGet( chkavUserinfouseridinclude_Internalname));
            AssignAttri(sPrefix, false, "AV95UserInfoUserIdInclude", AV95UserInfoUserIdInclude);
            AV71UserInfoAdditionalParameters = cgiGet( edtavUserinfoadditionalparameters_Internalname);
            AssignAttri(sPrefix, false, "AV71UserInfoAdditionalParameters", AV71UserInfoAdditionalParameters);
            AV81UserInfoResponseUserEmailTag = cgiGet( edtavUserinforesponseuseremailtag_Internalname);
            AssignAttri(sPrefix, false, "AV81UserInfoResponseUserEmailTag", AV81UserInfoResponseUserEmailTag);
            AV93UserInfoResponseUserVerifiedEmailTag = cgiGet( edtavUserinforesponseuserverifiedemailtag_Internalname);
            AssignAttri(sPrefix, false, "AV93UserInfoResponseUserVerifiedEmailTag", AV93UserInfoResponseUserVerifiedEmailTag);
            AV82UserInfoResponseUserExternalIdTag = cgiGet( edtavUserinforesponseuserexternalidtag_Internalname);
            AssignAttri(sPrefix, false, "AV82UserInfoResponseUserExternalIdTag", AV82UserInfoResponseUserExternalIdTag);
            AV89UserInfoResponseUserNameTag = cgiGet( edtavUserinforesponseusernametag_Internalname);
            AssignAttri(sPrefix, false, "AV89UserInfoResponseUserNameTag", AV89UserInfoResponseUserNameTag);
            AV83UserInfoResponseUserFirstNameTag = cgiGet( edtavUserinforesponseuserfirstnametag_Internalname);
            AssignAttri(sPrefix, false, "AV83UserInfoResponseUserFirstNameTag", AV83UserInfoResponseUserFirstNameTag);
            AV87UserInfoResponseUserLastNameGenAuto = StringUtil.StrToBool( cgiGet( chkavUserinforesponseuserlastnamegenauto_Internalname));
            AssignAttri(sPrefix, false, "AV87UserInfoResponseUserLastNameGenAuto", AV87UserInfoResponseUserLastNameGenAuto);
            AV88UserInfoResponseUserLastNameTag = cgiGet( edtavUserinforesponseuserlastnametag_Internalname);
            AssignAttri(sPrefix, false, "AV88UserInfoResponseUserLastNameTag", AV88UserInfoResponseUserLastNameTag);
            AV84UserInfoResponseUserGenderTag = cgiGet( edtavUserinforesponseusergendertag_Internalname);
            AssignAttri(sPrefix, false, "AV84UserInfoResponseUserGenderTag", AV84UserInfoResponseUserGenderTag);
            AV85UserInfoResponseUserGenderValues = cgiGet( edtavUserinforesponseusergendervalues_Internalname);
            AssignAttri(sPrefix, false, "AV85UserInfoResponseUserGenderValues", AV85UserInfoResponseUserGenderValues);
            AV80UserInfoResponseUserBirthdayTag = cgiGet( edtavUserinforesponseuserbirthdaytag_Internalname);
            AssignAttri(sPrefix, false, "AV80UserInfoResponseUserBirthdayTag", AV80UserInfoResponseUserBirthdayTag);
            AV91UserInfoResponseUserURLImageTag = cgiGet( edtavUserinforesponseuserurlimagetag_Internalname);
            AssignAttri(sPrefix, false, "AV91UserInfoResponseUserURLImageTag", AV91UserInfoResponseUserURLImageTag);
            AV92UserInfoResponseUserURLProfileTag = cgiGet( edtavUserinforesponseuserurlprofiletag_Internalname);
            AssignAttri(sPrefix, false, "AV92UserInfoResponseUserURLProfileTag", AV92UserInfoResponseUserURLProfileTag);
            AV86UserInfoResponseUserLanguageTag = cgiGet( edtavUserinforesponseuserlanguagetag_Internalname);
            AssignAttri(sPrefix, false, "AV86UserInfoResponseUserLanguageTag", AV86UserInfoResponseUserLanguageTag);
            AV90UserInfoResponseUserTimeZoneTag = cgiGet( edtavUserinforesponseusertimezonetag_Internalname);
            AssignAttri(sPrefix, false, "AV90UserInfoResponseUserTimeZoneTag", AV90UserInfoResponseUserTimeZoneTag);
            AV79UserInfoResponseErrorDescriptionTag = cgiGet( edtavUserinforesponseerrordescriptiontag_Internalname);
            AssignAttri(sPrefix, false, "AV79UserInfoResponseErrorDescriptionTag", AV79UserInfoResponseErrorDescriptionTag);
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
         E14142 ();
         if (returnInSub) return;
      }

      protected void E14142( )
      {
         /* Start Routine */
         returnInSub = false;
         cmbavIdp.Visible = 0;
         AssignProp(sPrefix, false, cmbavIdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavIdp.Visible), 5, 0), true);
         AV155NameInit = AV34Name;
         AssignAttri(sPrefix, false, "AV155NameInit", AV155NameInit);
         /* Execute user subroutine: 'INITAUTHENTICATIONOAUTH20' */
         S112 ();
         if (returnInSub) return;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
            {
               bttBtnenter_Visible = 0;
               AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
            }
            cmbavFunctionid.Enabled = 0;
            AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
            chkavIsenable.Enabled = 0;
            AssignProp(sPrefix, false, chkavIsenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsenable.Enabled), 5, 0), true);
            edtavDsc_Enabled = 0;
            AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
            edtavSmallimagename_Enabled = 0;
            AssignProp(sPrefix, false, edtavSmallimagename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSmallimagename_Enabled), 5, 0), true);
            edtavBigimagename_Enabled = 0;
            AssignProp(sPrefix, false, edtavBigimagename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBigimagename_Enabled), 5, 0), true);
            cmbavImpersonate.Enabled = 0;
            AssignProp(sPrefix, false, cmbavImpersonate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavImpersonate.Enabled), 5, 0), true);
            bttBtnenter_Caption = "Delete";
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
            bttBtnadd_Visible = 0;
            AssignProp(sPrefix, false, bttBtnadd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnadd_Visible), 5, 0), true);
            edtavName_Enabled = 0;
            AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            chkavIsenable.Enabled = 0;
            AssignProp(sPrefix, false, chkavIsenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsenable.Enabled), 5, 0), true);
            edtavDsc_Enabled = 0;
            AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
            edtavSmallimagename_Enabled = 0;
            AssignProp(sPrefix, false, edtavSmallimagename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSmallimagename_Enabled), 5, 0), true);
            edtavBigimagename_Enabled = 0;
            AssignProp(sPrefix, false, edtavBigimagename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBigimagename_Enabled), 5, 0), true);
            cmbavImpersonate.Enabled = 0;
            AssignProp(sPrefix, false, cmbavImpersonate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavImpersonate.Enabled), 5, 0), true);
            edtavOauth20clientidtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20clientidtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20clientidtag_Enabled), 5, 0), true);
            edtavOauth20clientidvalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20clientidvalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20clientidvalue_Enabled), 5, 0), true);
            edtavOauth20clientsecrettag_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20clientsecrettag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20clientsecrettag_Enabled), 5, 0), true);
            edtavOauth20clientsecretvalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20clientsecretvalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20clientsecretvalue_Enabled), 5, 0), true);
            edtavOauth20redirecturltag_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20redirecturltag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20redirecturltag_Enabled), 5, 0), true);
            edtavOauth20redirecturlvalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavOauth20redirecturlvalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOauth20redirecturlvalue_Enabled), 5, 0), true);
            chkavOauth20redirecturliscustom.Enabled = 0;
            AssignProp(sPrefix, false, chkavOauth20redirecturliscustom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOauth20redirecturliscustom.Enabled), 5, 0), true);
            chkavOauth20redirecturl_autocompletevirtualdirectory.Enabled = 0;
            AssignProp(sPrefix, false, chkavOauth20redirecturl_autocompletevirtualdirectory_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOauth20redirecturl_autocompletevirtualdirectory.Enabled), 5, 0), true);
            chkavOauth20redirecttoauthenticate.Enabled = 0;
            AssignProp(sPrefix, false, chkavOauth20redirecttoauthenticate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOauth20redirecttoauthenticate.Enabled), 5, 0), true);
            edtavAuthorizeurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthorizeurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthorizeurl_Enabled), 5, 0), true);
            chkavAuthresptypeinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthresptypeinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthresptypeinclude.Enabled), 5, 0), true);
            edtavAuthresptypetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthresptypetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthresptypetag_Enabled), 5, 0), true);
            edtavAuthresptypevalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthresptypevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthresptypevalue_Enabled), 5, 0), true);
            chkavAuthscopeinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthscopeinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthscopeinclude.Enabled), 5, 0), true);
            edtavAuthscopetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthscopetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthscopetag_Enabled), 5, 0), true);
            edtavAuthscopevalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthscopevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthscopevalue_Enabled), 5, 0), true);
            chkavAuthstateinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthstateinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthstateinclude.Enabled), 5, 0), true);
            edtavAuthstatetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthstatetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthstatetag_Enabled), 5, 0), true);
            chkavAuthclientidinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthclientidinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthclientidinclude.Enabled), 5, 0), true);
            chkavAuthclientsecretinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthclientsecretinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthclientsecretinclude.Enabled), 5, 0), true);
            chkavAuthredirurlinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthredirurlinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthredirurlinclude.Enabled), 5, 0), true);
            edtavAuthadditionalparameters_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthadditionalparameters_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthadditionalparameters_Enabled), 5, 0), true);
            edtavAuthadditionalparameterssd_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthadditionalparameterssd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthadditionalparameterssd_Enabled), 5, 0), true);
            chkavAuthopenidconnectprotocolenable.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthopenidconnectprotocolenable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthopenidconnectprotocolenable.Enabled), 5, 0), true);
            chkavAuthvalididtoken.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthvalididtoken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthvalididtoken.Enabled), 5, 0), true);
            edtavAuthcertificatepathfilename_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthcertificatepathfilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthcertificatepathfilename_Enabled), 5, 0), true);
            edtavAuthissuerurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthissuerurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthissuerurl_Enabled), 5, 0), true);
            chkavAuthallowonlyuseremailverified.Enabled = 0;
            AssignProp(sPrefix, false, chkavAuthallowonlyuseremailverified_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAuthallowonlyuseremailverified.Enabled), 5, 0), true);
            edtavAuthresponseaccesscodetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthresponseaccesscodetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthresponseaccesscodetag_Enabled), 5, 0), true);
            edtavAuthresponseerrordesctag_Enabled = 0;
            AssignProp(sPrefix, false, edtavAuthresponseerrordesctag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAuthresponseerrordesctag_Enabled), 5, 0), true);
            edtavTokenurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenurl_Enabled), 5, 0), true);
            cmbavTokenmethod.Enabled = 0;
            AssignProp(sPrefix, false, cmbavTokenmethod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTokenmethod.Enabled), 5, 0), true);
            edtavTokenheaderkeytag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenheaderkeytag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenheaderkeytag_Enabled), 5, 0), true);
            edtavTokenheaderkeyvalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenheaderkeyvalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenheaderkeyvalue_Enabled), 5, 0), true);
            chkavTokenheaderauthenticationinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokenheaderauthenticationinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokenheaderauthenticationinclude.Enabled), 5, 0), true);
            cmbavTokenheaderauthenticationmethod.Enabled = 0;
            AssignProp(sPrefix, false, cmbavTokenheaderauthenticationmethod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTokenheaderauthenticationmethod.Enabled), 5, 0), true);
            edtavTokenheaderauthenticationrealm_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenheaderauthenticationrealm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenheaderauthenticationrealm_Enabled), 5, 0), true);
            chkavTokenheaderauthorizationbasicinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokenheaderauthorizationbasicinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokenheaderauthorizationbasicinclude.Enabled), 5, 0), true);
            chkavTokengranttypeinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokengranttypeinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokengranttypeinclude.Enabled), 5, 0), true);
            edtavTokengranttypetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokengranttypetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokengranttypetag_Enabled), 5, 0), true);
            edtavTokengranttypevalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokengranttypevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokengranttypevalue_Enabled), 5, 0), true);
            chkavTokenaccesscodeinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokenaccesscodeinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokenaccesscodeinclude.Enabled), 5, 0), true);
            chkavTokencliidinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokencliidinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokencliidinclude.Enabled), 5, 0), true);
            chkavTokenclisecretinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokenclisecretinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokenclisecretinclude.Enabled), 5, 0), true);
            chkavTokenredirecturlinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavTokenredirecturlinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTokenredirecturlinclude.Enabled), 5, 0), true);
            edtavTokenadditionalparameters_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenadditionalparameters_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenadditionalparameters_Enabled), 5, 0), true);
            edtavTokenresponseaccesstokentag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponseaccesstokentag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponseaccesstokentag_Enabled), 5, 0), true);
            edtavTokenresponsetokentypetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponsetokentypetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponsetokentypetag_Enabled), 5, 0), true);
            edtavTokenresponseexpiresintag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponseexpiresintag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponseexpiresintag_Enabled), 5, 0), true);
            edtavTokenresponsescopetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponsescopetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponsescopetag_Enabled), 5, 0), true);
            edtavTokenresponseuseridtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponseuseridtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponseuseridtag_Enabled), 5, 0), true);
            edtavTokenresponserefreshtokentag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponserefreshtokentag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponserefreshtokentag_Enabled), 5, 0), true);
            edtavTokenresponseerrordescriptiontag_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenresponseerrordescriptiontag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenresponseerrordescriptiontag_Enabled), 5, 0), true);
            chkavAutovalidateexternaltokenandrefresh.Enabled = 0;
            AssignProp(sPrefix, false, chkavAutovalidateexternaltokenandrefresh_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavAutovalidateexternaltokenandrefresh.Enabled), 5, 0), true);
            edtavTokenrefreshtokenurl_Enabled = 0;
            AssignProp(sPrefix, false, edtavTokenrefreshtokenurl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTokenrefreshtokenurl_Enabled), 5, 0), true);
            edtavUserinfourl_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfourl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfourl_Enabled), 5, 0), true);
            cmbavUserinfomethod.Enabled = 0;
            AssignProp(sPrefix, false, cmbavUserinfomethod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavUserinfomethod.Enabled), 5, 0), true);
            edtavUserinfoheaderkeytag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoheaderkeytag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoheaderkeytag_Enabled), 5, 0), true);
            edtavUserinfoheaderkeyvalue_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoheaderkeyvalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoheaderkeyvalue_Enabled), 5, 0), true);
            chkavUserinfoaccesstokeninclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinfoaccesstokeninclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinfoaccesstokeninclude.Enabled), 5, 0), true);
            edtavUserinfoaccesstokenname_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoaccesstokenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoaccesstokenname_Enabled), 5, 0), true);
            chkavUserinfoclientidinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinfoclientidinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinfoclientidinclude.Enabled), 5, 0), true);
            edtavUserinfoclientidname_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoclientidname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoclientidname_Enabled), 5, 0), true);
            chkavUserinfoclientsecretinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinfoclientsecretinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinfoclientsecretinclude.Enabled), 5, 0), true);
            edtavUserinfoclientsecretname_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoclientsecretname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoclientsecretname_Enabled), 5, 0), true);
            chkavUserinfouseridinclude.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinfouseridinclude_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinfouseridinclude.Enabled), 5, 0), true);
            edtavUserinfoadditionalparameters_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinfoadditionalparameters_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinfoadditionalparameters_Enabled), 5, 0), true);
            edtavUserinforesponseuseremailtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuseremailtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuseremailtag_Enabled), 5, 0), true);
            edtavUserinforesponseuserverifiedemailtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserverifiedemailtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserverifiedemailtag_Enabled), 5, 0), true);
            edtavUserinforesponseuserexternalidtag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserexternalidtag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserexternalidtag_Enabled), 5, 0), true);
            edtavUserinforesponseusernametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusernametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusernametag_Enabled), 5, 0), true);
            edtavUserinforesponseuserfirstnametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserfirstnametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserfirstnametag_Enabled), 5, 0), true);
            chkavUserinforesponseuserlastnamegenauto.Enabled = 0;
            AssignProp(sPrefix, false, chkavUserinforesponseuserlastnamegenauto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavUserinforesponseuserlastnamegenauto.Enabled), 5, 0), true);
            edtavUserinforesponseuserlastnametag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Enabled), 5, 0), true);
            edtavUserinforesponseusergendertag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusergendertag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusergendertag_Enabled), 5, 0), true);
            edtavUserinforesponseusergendervalues_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusergendervalues_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusergendervalues_Enabled), 5, 0), true);
            edtavUserinforesponseuserbirthdaytag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserbirthdaytag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserbirthdaytag_Enabled), 5, 0), true);
            edtavUserinforesponseuserurlimagetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserurlimagetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserurlimagetag_Enabled), 5, 0), true);
            edtavUserinforesponseuserurlprofiletag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserurlprofiletag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserurlprofiletag_Enabled), 5, 0), true);
            edtavUserinforesponseuserlanguagetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlanguagetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlanguagetag_Enabled), 5, 0), true);
            edtavUserinforesponseusertimezonetag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseusertimezonetag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseusertimezonetag_Enabled), 5, 0), true);
            edtavUserinforesponseerrordescriptiontag_Enabled = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseerrordescriptiontag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseerrordescriptiontag_Enabled), 5, 0), true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               edtavName_Enabled = 1;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
               cmbavIdp.Visible = 1;
               AssignProp(sPrefix, false, cmbavIdp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavIdp.Visible), 5, 0), true);
            }
            else
            {
               edtavName_Enabled = 0;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            }
         }
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp(sPrefix, false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         chkavOauth20redirecturliscustom.TooltipText = "Customize the IDP callback URL, you should implement the object that handles this response.";
         AssignProp(sPrefix, false, chkavOauth20redirecturliscustom_Internalname, "Tooltiptext", chkavOauth20redirecturliscustom.TooltipText, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      private void E15142( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV220GXV1 = 1;
         while ( AV220GXV1 <= AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserproperties.Count )
         {
            AV31GAMPropertySimple = ((GeneXus.Programs.genexussecurity.SdtGAMPropertySimple)AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserproperties.Item(AV220GXV1));
            edtavDeleteproperty_gximage = "ActionCancel";
            AV24DeleteProperty = context.GetImagePath( "f454b006-8fb2-471d-b379-a84a77f89118", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavDeleteproperty_Internalname, AV24DeleteProperty);
            AV221Deleteproperty_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f454b006-8fb2-471d-b379-a84a77f89118", "", context.GetTheme( )), context);
            AV26DynamicPropName = AV31GAMPropertySimple.gxTpr_Id;
            AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV26DynamicPropName);
            AV27DynamicPropTag = AV31GAMPropertySimple.gxTpr_Value;
            AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV27DynamicPropTag);
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtavDeleteproperty_Visible = 0;
               edtavDynamicpropname_Enabled = 0;
               edtavDynamicproptag_Enabled = 0;
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 548;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_5482( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            subGrid_Recordcount = (int)(GRID_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_548_Refreshing )
            {
               DoAjaxLoad(548, GridRow);
            }
            AV220GXV1 = (int)(AV220GXV1+1);
         }
         edtavDeleteproperty_gximage = "ActionDelete";
         AV24DeleteProperty = context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( ));
         AssignAttri(sPrefix, false, edtavDeleteproperty_Internalname, AV24DeleteProperty);
         AV221Deleteproperty_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( )), context);
         edtavDeleteproperty_Tooltiptext = "";
         /*  Sending Event outputs  */
      }

      protected void E11142( )
      {
         /* 'DoAdd' Routine */
         returnInSub = false;
         edtavDeleteproperty_gximage = "ActionCancel";
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "gximage", edtavDeleteproperty_gximage, !bGXsfl_548_Refreshing);
         AV24DeleteProperty = context.GetImagePath( "f454b006-8fb2-471d-b379-a84a77f89118", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24DeleteProperty)) ? AV221Deleteproperty_GXI : context.convertURL( context.PathToRelativeUrl( AV24DeleteProperty))), !bGXsfl_548_Refreshing);
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "SrcSet", context.GetImageSrcSet( AV24DeleteProperty), true);
         AV221Deleteproperty_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f454b006-8fb2-471d-b379-a84a77f89118", "", context.GetTheme( )), context);
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24DeleteProperty)) ? AV221Deleteproperty_GXI : context.convertURL( context.PathToRelativeUrl( AV24DeleteProperty))), !bGXsfl_548_Refreshing);
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "SrcSet", context.GetImageSrcSet( AV24DeleteProperty), true);
         edtavDeleteproperty_Visible = 1;
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDeleteproperty_Visible), 5, 0), !bGXsfl_548_Refreshing);
         edtavDynamicpropname_Enabled = 1;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Enabled), 5, 0), !bGXsfl_548_Refreshing);
         edtavDynamicpropname_Visible = 1;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Visible), 5, 0), !bGXsfl_548_Refreshing);
         edtavDynamicproptag_Enabled = 1;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Enabled), 5, 0), !bGXsfl_548_Refreshing);
         edtavDynamicproptag_Visible = 1;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Visible), 5, 0), !bGXsfl_548_Refreshing);
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            sendrow_5482( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         subGrid_Recordcount = (int)(GRID_nCurrentRecord);
         if ( isFullAjaxMode( ) && ! bGXsfl_548_Refreshing )
         {
            DoAjaxLoad(548, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S182( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV105CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV105CheckRequiredFieldsResult", AV105CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34Name)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Name", "", "", "", "", "", "", "", ""),  "error",  edtavName_Internalname,  "true",  ""));
            AV105CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV105CheckRequiredFieldsResult", AV105CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ! AV87UserInfoResponseUserLastNameGenAuto ) )
         {
            edtavUserinforesponseuserlastnametag_Visible = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Visible), 5, 0), true);
            divUserinforesponseuserlastnametag_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divUserinforesponseuserlastnametag_cell_Internalname, "Class", divUserinforesponseuserlastnametag_cell_Class, true);
         }
         else
         {
            edtavUserinforesponseuserlastnametag_Visible = 1;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Visible), 5, 0), true);
            divUserinforesponseuserlastnametag_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp(sPrefix, false, divUserinforesponseuserlastnametag_cell_Internalname, "Class", divUserinforesponseuserlastnametag_cell_Class, true);
         }
      }

      protected void E12142( )
      {
         /* Idp_Controlvaluechanged Routine */
         returnInSub = false;
         AV155NameInit = AV151IDP;
         AssignAttri(sPrefix, false, "AV155NameInit", AV155NameInit);
         /* Execute user subroutine: 'INITAUTHENTICATIONOAUTH20' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9AuthenticationTypeOauth20", AV9AuthenticationTypeOauth20);
         cmbavImpersonate.CurrentValue = StringUtil.RTrim( AV32Impersonate);
         AssignProp(sPrefix, false, cmbavImpersonate_Internalname, "Values", cmbavImpersonate.ToJavascriptSource(), true);
         cmbavTokenmethod.CurrentValue = StringUtil.RTrim( AV57TokenMethod);
         AssignProp(sPrefix, false, cmbavTokenmethod_Internalname, "Values", cmbavTokenmethod.ToJavascriptSource(), true);
         cmbavTokenheaderauthenticationmethod.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52TokenHeaderAuthenticationMethod), 4, 0));
         AssignProp(sPrefix, false, cmbavTokenheaderauthenticationmethod_Internalname, "Values", cmbavTokenheaderauthenticationmethod.ToJavascriptSource(), true);
         cmbavUserinfomethod.CurrentValue = StringUtil.RTrim( AV78UserInfoMethod);
         AssignProp(sPrefix, false, cmbavUserinfomethod_Internalname, "Values", cmbavUserinfomethod.ToJavascriptSource(), true);
         cmbavFunctionid.CurrentValue = StringUtil.RTrim( AV30FunctionId);
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Values", cmbavFunctionid.ToJavascriptSource(), true);
      }

      protected void E16142( )
      {
         /* Deleteproperty_Click Routine */
         returnInSub = false;
         edtavDeleteproperty_gximage = "ActionCancel";
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "gximage", edtavDeleteproperty_gximage, !bGXsfl_548_Refreshing);
         AV24DeleteProperty = context.GetImagePath( "f454b006-8fb2-471d-b379-a84a77f89118", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24DeleteProperty)) ? AV221Deleteproperty_GXI : context.convertURL( context.PathToRelativeUrl( AV24DeleteProperty))), !bGXsfl_548_Refreshing);
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "SrcSet", context.GetImageSrcSet( AV24DeleteProperty), true);
         AV221Deleteproperty_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f454b006-8fb2-471d-b379-a84a77f89118", "", context.GetTheme( )), context);
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24DeleteProperty)) ? AV221Deleteproperty_GXI : context.convertURL( context.PathToRelativeUrl( AV24DeleteProperty))), !bGXsfl_548_Refreshing);
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "SrcSet", context.GetImageSrcSet( AV24DeleteProperty), true);
         edtavDeleteproperty_Visible = 0;
         AssignProp(sPrefix, false, edtavDeleteproperty_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDeleteproperty_Visible), 5, 0), !bGXsfl_548_Refreshing);
         edtavDynamicpropname_Visible = 0;
         AssignProp(sPrefix, false, edtavDynamicpropname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicpropname_Visible), 5, 0), !bGXsfl_548_Refreshing);
         edtavDynamicproptag_Visible = 0;
         AssignProp(sPrefix, false, edtavDynamicproptag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDynamicproptag_Visible), 5, 0), !bGXsfl_548_Refreshing);
         AV26DynamicPropName = "";
         AssignAttri(sPrefix, false, edtavDynamicpropname_Internalname, AV26DynamicPropName);
         AV27DynamicPropTag = "";
         AssignAttri(sPrefix, false, edtavDynamicproptag_Internalname, AV27DynamicPropTag);
         AV9AuthenticationTypeOauth20.gxTpr_Name = AV34Name;
         AV9AuthenticationTypeOauth20.removeuserinfoproperty( AV26DynamicPropName, out  AV29Errors);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9AuthenticationTypeOauth20", AV9AuthenticationTypeOauth20);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E13142 ();
         if (returnInSub) return;
      }

      protected void E13142( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S182 ();
         if (returnInSub) return;
         if ( AV105CheckRequiredFieldsResult )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               /* Execute user subroutine: 'SAVEAUTHENTICATIONOAUTH20' */
               S192 ();
               if (returnInSub) return;
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV9AuthenticationTypeOauth20.load( AV34Name);
               AV9AuthenticationTypeOauth20.delete();
            }
            if ( AV9AuthenticationTypeOauth20.success() )
            {
               context.CommitDataStores("gamwcauthenticationtypeentryoauth20",pr_default);
               CallWebObject(formatLink("gamwwauthtypes.aspx") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               AV29Errors = AV9AuthenticationTypeOauth20.geterrors();
               /* Execute user subroutine: 'SHOWMESSAGES' */
               S202 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9AuthenticationTypeOauth20", AV9AuthenticationTypeOauth20);
      }

      protected void S112( )
      {
         /* 'INITAUTHENTICATIONOAUTH20' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' */
         S212 ();
         if (returnInSub) return;
         AV9AuthenticationTypeOauth20.load( AV155NameInit);
         AV34Name = AV9AuthenticationTypeOauth20.gxTpr_Name;
         AssignAttri(sPrefix, false, "AV34Name", AV34Name);
         AV33IsEnable = AV9AuthenticationTypeOauth20.gxTpr_Isenable;
         AssignAttri(sPrefix, false, "AV33IsEnable", AV33IsEnable);
         AV25Dsc = AV9AuthenticationTypeOauth20.gxTpr_Description;
         AssignAttri(sPrefix, false, "AV25Dsc", AV25Dsc);
         AV43SmallImageName = AV9AuthenticationTypeOauth20.gxTpr_Smallimagename;
         AssignAttri(sPrefix, false, "AV43SmallImageName", AV43SmallImageName);
         AV23BigImageName = AV9AuthenticationTypeOauth20.gxTpr_Bigimagename;
         AssignAttri(sPrefix, false, "AV23BigImageName", AV23BigImageName);
         AV32Impersonate = AV9AuthenticationTypeOauth20.gxTpr_Impersonate;
         AssignAttri(sPrefix, false, "AV32Impersonate", AV32Impersonate);
         AV35Oauth20ClientIdTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_name;
         AssignAttri(sPrefix, false, "AV35Oauth20ClientIdTag", AV35Oauth20ClientIdTag);
         AV36Oauth20ClientIdValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_value;
         AssignAttri(sPrefix, false, "AV36Oauth20ClientIdValue", AV36Oauth20ClientIdValue);
         AV37Oauth20ClientSecretTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_name;
         AssignAttri(sPrefix, false, "AV37Oauth20ClientSecretTag", AV37Oauth20ClientSecretTag);
         AV38Oauth20ClientSecretValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_value;
         AssignAttri(sPrefix, false, "AV38Oauth20ClientSecretValue", AV38Oauth20ClientSecretValue);
         AV41Oauth20RedirectURLTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_name;
         AssignAttri(sPrefix, false, "AV41Oauth20RedirectURLTag", AV41Oauth20RedirectURLTag);
         AV42Oauth20RedirectURLvalue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_value;
         AssignAttri(sPrefix, false, "AV42Oauth20RedirectURLvalue", AV42Oauth20RedirectURLvalue);
         AV40Oauth20RedirectURLisCustom = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_iscustom;
         AssignAttri(sPrefix, false, "AV40Oauth20RedirectURLisCustom", AV40Oauth20RedirectURLisCustom);
         AV111Oauth20RedirectURL_AutocompleteVirtualDirectory = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_autocompletevirtualdirectory;
         AssignAttri(sPrefix, false, "AV111Oauth20RedirectURL_AutocompleteVirtualDirectory", AV111Oauth20RedirectURL_AutocompleteVirtualDirectory);
         AV39Oauth20RedirectToAuthenticate = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecttoauthenticate;
         AssignAttri(sPrefix, false, "AV39Oauth20RedirectToAuthenticate", AV39Oauth20RedirectToAuthenticate);
         AV10AuthorizeURL = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Url;
         AssignAttri(sPrefix, false, "AV10AuthorizeURL", AV10AuthorizeURL);
         AV14AuthRespTypeInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_include;
         AssignAttri(sPrefix, false, "AV14AuthRespTypeInclude", AV14AuthRespTypeInclude);
         AV15AuthRespTypeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_name;
         AssignAttri(sPrefix, false, "AV15AuthRespTypeTag", AV15AuthRespTypeTag);
         AV16AuthRespTypeValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_value;
         AssignAttri(sPrefix, false, "AV16AuthRespTypeValue", AV16AuthRespTypeValue);
         AV17AuthScopeInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_include;
         AssignAttri(sPrefix, false, "AV17AuthScopeInclude", AV17AuthScopeInclude);
         AV18AuthScopeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_name;
         AssignAttri(sPrefix, false, "AV18AuthScopeTag", AV18AuthScopeTag);
         AV19AuthScopeValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_value;
         AssignAttri(sPrefix, false, "AV19AuthScopeValue", AV19AuthScopeValue);
         AV20AuthStateIncude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_include;
         AssignAttri(sPrefix, false, "AV20AuthStateIncude", AV20AuthStateIncude);
         AV21AuthStateTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_name;
         AssignAttri(sPrefix, false, "AV21AuthStateTag", AV21AuthStateTag);
         AV7AuthClientIdInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientid_include;
         AssignAttri(sPrefix, false, "AV7AuthClientIdInclude", AV7AuthClientIdInclude);
         AV8AuthClientSecretInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientsecret_include;
         AssignAttri(sPrefix, false, "AV8AuthClientSecretInclude", AV8AuthClientSecretInclude);
         AV99AuthRedirURLInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Redirecturl_include;
         AssignAttri(sPrefix, false, "AV99AuthRedirURLInclude", AV99AuthRedirURLInclude);
         AV5AuthAdditionalParameters = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparameters;
         AssignAttri(sPrefix, false, "AV5AuthAdditionalParameters", AV5AuthAdditionalParameters);
         AV6AuthAdditionalParametersSD = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparametersnativesd;
         AssignAttri(sPrefix, false, "AV6AuthAdditionalParametersSD", AV6AuthAdditionalParametersSD);
         AV109AuthOpenIDConnectProtocolEnable = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Enable;
         AssignAttri(sPrefix, false, "AV109AuthOpenIDConnectProtocolEnable", AV109AuthOpenIDConnectProtocolEnable);
         AV110AuthValidIdToken = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Valididtoken;
         AssignAttri(sPrefix, false, "AV110AuthValidIdToken", AV110AuthValidIdToken);
         AV107AuthCertificatePathFileName = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Certificatepathfilename;
         AssignAttri(sPrefix, false, "AV107AuthCertificatePathFileName", AV107AuthCertificatePathFileName);
         AV108AuthIssuerURL = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Issuerurl;
         AssignAttri(sPrefix, false, "AV108AuthIssuerURL", AV108AuthIssuerURL);
         AV106AuthAllowOnlyUserEmailVerified = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Allowonlyuseremailverified;
         AssignAttri(sPrefix, false, "AV106AuthAllowOnlyUserEmailVerified", AV106AuthAllowOnlyUserEmailVerified);
         AV12AuthResponseAccessCodeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseaccesscode_name;
         AssignAttri(sPrefix, false, "AV12AuthResponseAccessCodeTag", AV12AuthResponseAccessCodeTag);
         AV13AuthResponseErrorDescTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV13AuthResponseErrorDescTag", AV13AuthResponseErrorDescTag);
         AV67TokenURL = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Url;
         AssignAttri(sPrefix, false, "AV67TokenURL", AV67TokenURL);
         AV57TokenMethod = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Method;
         AssignAttri(sPrefix, false, "AV57TokenMethod", AV57TokenMethod);
         AV55TokenHeaderKeyTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_key;
         AssignAttri(sPrefix, false, "AV55TokenHeaderKeyTag", AV55TokenHeaderKeyTag);
         AV56TokenHeaderKeyValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_value;
         AssignAttri(sPrefix, false, "AV56TokenHeaderKeyValue", AV56TokenHeaderKeyValue);
         AV51TokenHeaderAuthenticationInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_include;
         AssignAttri(sPrefix, false, "AV51TokenHeaderAuthenticationInclude", AV51TokenHeaderAuthenticationInclude);
         AV52TokenHeaderAuthenticationMethod = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_method;
         AssignAttri(sPrefix, false, "AV52TokenHeaderAuthenticationMethod", StringUtil.LTrimStr( (decimal)(AV52TokenHeaderAuthenticationMethod), 4, 0));
         AV53TokenHeaderAuthenticationRealm = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_realm;
         AssignAttri(sPrefix, false, "AV53TokenHeaderAuthenticationRealm", AV53TokenHeaderAuthenticationRealm);
         AV54TokenHeaderAuthorizationBasicInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authorizationbasic_include;
         AssignAttri(sPrefix, false, "AV54TokenHeaderAuthorizationBasicInclude", AV54TokenHeaderAuthorizationBasicInclude);
         AV48TokenGrantTypeInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_include;
         AssignAttri(sPrefix, false, "AV48TokenGrantTypeInclude", AV48TokenGrantTypeInclude);
         AV49TokenGrantTypeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_name;
         AssignAttri(sPrefix, false, "AV49TokenGrantTypeTag", AV49TokenGrantTypeTag);
         AV50TokenGrantTypeValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_value;
         AssignAttri(sPrefix, false, "AV50TokenGrantTypeValue", AV50TokenGrantTypeValue);
         AV44TokenAccessCodeInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Accesscode_include;
         AssignAttri(sPrefix, false, "AV44TokenAccessCodeInclude", AV44TokenAccessCodeInclude);
         AV46TokenCliIdInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientid_include;
         AssignAttri(sPrefix, false, "AV46TokenCliIdInclude", AV46TokenCliIdInclude);
         AV47TokenCliSecretInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientsecret_include;
         AssignAttri(sPrefix, false, "AV47TokenCliSecretInclude", AV47TokenCliSecretInclude);
         AV58TokenRedirectURLInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Redirecturl_include;
         AssignAttri(sPrefix, false, "AV58TokenRedirectURLInclude", AV58TokenRedirectURLInclude);
         AV45TokenAdditionalParameters = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Additionalparameters;
         AssignAttri(sPrefix, false, "AV45TokenAdditionalParameters", AV45TokenAdditionalParameters);
         AV60TokenResponseAccessTokenTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseaccesstoken_name;
         AssignAttri(sPrefix, false, "AV60TokenResponseAccessTokenTag", AV60TokenResponseAccessTokenTag);
         AV65TokenResponseTokenTypeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsetokentype_name;
         AssignAttri(sPrefix, false, "AV65TokenResponseTokenTypeTag", AV65TokenResponseTokenTypeTag);
         AV62TokenResponseExpiresInTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseexpiresin_name;
         AssignAttri(sPrefix, false, "AV62TokenResponseExpiresInTag", AV62TokenResponseExpiresInTag);
         AV64TokenResponseScopeTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsescope_name;
         AssignAttri(sPrefix, false, "AV64TokenResponseScopeTag", AV64TokenResponseScopeTag);
         AV66TokenResponseUserIdTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseuserid_name;
         AssignAttri(sPrefix, false, "AV66TokenResponseUserIdTag", AV66TokenResponseUserIdTag);
         AV63TokenResponseRefreshTokenTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responserefreshtoken_name;
         AssignAttri(sPrefix, false, "AV63TokenResponseRefreshTokenTag", AV63TokenResponseRefreshTokenTag);
         AV61TokenResponseErrorDescriptionTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV61TokenResponseErrorDescriptionTag", AV61TokenResponseErrorDescriptionTag);
         AV22AutovalidateExternalTokenAndRefresh = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Autovalidateexternaltokenandrefresh;
         AssignAttri(sPrefix, false, "AV22AutovalidateExternalTokenAndRefresh", AV22AutovalidateExternalTokenAndRefresh);
         AV59TokenRefreshTokenURL = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Refreshtoken_url;
         AssignAttri(sPrefix, false, "AV59TokenRefreshTokenURL", AV59TokenRefreshTokenURL);
         AV94UserInfoURL = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Url;
         AssignAttri(sPrefix, false, "AV94UserInfoURL", AV94UserInfoURL);
         AV78UserInfoMethod = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Method;
         AssignAttri(sPrefix, false, "AV78UserInfoMethod", AV78UserInfoMethod);
         AV76UserInfoHeaderKeyTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_key;
         AssignAttri(sPrefix, false, "AV76UserInfoHeaderKeyTag", AV76UserInfoHeaderKeyTag);
         AV77UserInfoHeaderKeyValue = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_value;
         AssignAttri(sPrefix, false, "AV77UserInfoHeaderKeyValue", AV77UserInfoHeaderKeyValue);
         AV69UserInfoAccessTokenInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_include;
         AssignAttri(sPrefix, false, "AV69UserInfoAccessTokenInclude", AV69UserInfoAccessTokenInclude);
         AV70UserInfoAccessTokenName = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_name;
         AssignAttri(sPrefix, false, "AV70UserInfoAccessTokenName", AV70UserInfoAccessTokenName);
         AV72UserInfoClientIdInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_include;
         AssignAttri(sPrefix, false, "AV72UserInfoClientIdInclude", AV72UserInfoClientIdInclude);
         AV73UserInfoClientIdName = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_name;
         AssignAttri(sPrefix, false, "AV73UserInfoClientIdName", AV73UserInfoClientIdName);
         AV74UserInfoClientSecretInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_include;
         AssignAttri(sPrefix, false, "AV74UserInfoClientSecretInclude", AV74UserInfoClientSecretInclude);
         AV75UserInfoClientSecretName = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_name;
         AssignAttri(sPrefix, false, "AV75UserInfoClientSecretName", AV75UserInfoClientSecretName);
         AV95UserInfoUserIdInclude = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Userid_include;
         AssignAttri(sPrefix, false, "AV95UserInfoUserIdInclude", AV95UserInfoUserIdInclude);
         AV71UserInfoAdditionalParameters = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Additionalparameters;
         AssignAttri(sPrefix, false, "AV71UserInfoAdditionalParameters", AV71UserInfoAdditionalParameters);
         AV81UserInfoResponseUserEmailTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuseremail_name;
         AssignAttri(sPrefix, false, "AV81UserInfoResponseUserEmailTag", AV81UserInfoResponseUserEmailTag);
         AV93UserInfoResponseUserVerifiedEmailTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserverifiedemail_name;
         AssignAttri(sPrefix, false, "AV93UserInfoResponseUserVerifiedEmailTag", AV93UserInfoResponseUserVerifiedEmailTag);
         AV82UserInfoResponseUserExternalIdTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserexternalid_name;
         AssignAttri(sPrefix, false, "AV82UserInfoResponseUserExternalIdTag", AV82UserInfoResponseUserExternalIdTag);
         AV89UserInfoResponseUserNameTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusername_name;
         AssignAttri(sPrefix, false, "AV89UserInfoResponseUserNameTag", AV89UserInfoResponseUserNameTag);
         AV83UserInfoResponseUserFirstNameTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserfirstname_name;
         AssignAttri(sPrefix, false, "AV83UserInfoResponseUserFirstNameTag", AV83UserInfoResponseUserFirstNameTag);
         AV87UserInfoResponseUserLastNameGenAuto = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_generateautomatic;
         AssignAttri(sPrefix, false, "AV87UserInfoResponseUserLastNameGenAuto", AV87UserInfoResponseUserLastNameGenAuto);
         AV88UserInfoResponseUserLastNameTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_name;
         AssignAttri(sPrefix, false, "AV88UserInfoResponseUserLastNameTag", AV88UserInfoResponseUserLastNameTag);
         AV84UserInfoResponseUserGenderTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_name;
         AssignAttri(sPrefix, false, "AV84UserInfoResponseUserGenderTag", AV84UserInfoResponseUserGenderTag);
         AV85UserInfoResponseUserGenderValues = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_values;
         AssignAttri(sPrefix, false, "AV85UserInfoResponseUserGenderValues", AV85UserInfoResponseUserGenderValues);
         AV80UserInfoResponseUserBirthdayTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserbirthday_name;
         AssignAttri(sPrefix, false, "AV80UserInfoResponseUserBirthdayTag", AV80UserInfoResponseUserBirthdayTag);
         AV91UserInfoResponseUserURLImageTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlimage_name;
         AssignAttri(sPrefix, false, "AV91UserInfoResponseUserURLImageTag", AV91UserInfoResponseUserURLImageTag);
         AV92UserInfoResponseUserURLProfileTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlprofile_name;
         AssignAttri(sPrefix, false, "AV92UserInfoResponseUserURLProfileTag", AV92UserInfoResponseUserURLProfileTag);
         AV86UserInfoResponseUserLanguageTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlanguage_name;
         AssignAttri(sPrefix, false, "AV86UserInfoResponseUserLanguageTag", AV86UserInfoResponseUserLanguageTag);
         AV90UserInfoResponseUserTimeZoneTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusertimezone_name;
         AssignAttri(sPrefix, false, "AV90UserInfoResponseUserTimeZoneTag", AV90UserInfoResponseUserTimeZoneTag);
         AV79UserInfoResponseErrorDescriptionTag = AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseerrordescription_name;
         AssignAttri(sPrefix, false, "AV79UserInfoResponseErrorDescriptionTag", AV79UserInfoResponseErrorDescriptionTag);
         AV30FunctionId = "OnlyAuthentication";
         AssignAttri(sPrefix, false, "AV30FunctionId", AV30FunctionId);
         cmbavFunctionid.Enabled = 0;
         AssignProp(sPrefix, false, cmbavFunctionid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavFunctionid.Enabled), 5, 0), true);
         /* Execute user subroutine: 'USERINFOLASTNAMEFIELDTAG' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_OPENIDCONNECT' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_VALIDIDTOKEN' */
         S172 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV9AuthenticationTypeOauth20 = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20(context);
         }
         /* Execute user subroutine: 'SETCAPTIONGROUPUSERBODY' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UI_AUTOCOMPLETEVIRTUALDIRECTORY' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S192( )
      {
         /* 'SAVEAUTHENTICATIONOAUTH20' Routine */
         returnInSub = false;
         AV9AuthenticationTypeOauth20.load( AV34Name);
         AV9AuthenticationTypeOauth20.gxTpr_Name = AV34Name;
         AV9AuthenticationTypeOauth20.gxTpr_Isenable = AV33IsEnable;
         AV9AuthenticationTypeOauth20.gxTpr_Description = AV25Dsc;
         AV9AuthenticationTypeOauth20.gxTpr_Smallimagename = AV43SmallImageName;
         AV9AuthenticationTypeOauth20.gxTpr_Bigimagename = AV23BigImageName;
         AV9AuthenticationTypeOauth20.gxTpr_Impersonate = AV32Impersonate;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_name = AV35Oauth20ClientIdTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientid_value = AV36Oauth20ClientIdValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_name = AV37Oauth20ClientSecretTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Clientsecret_value = AV38Oauth20ClientSecretValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_name = AV41Oauth20RedirectURLTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_value = AV42Oauth20RedirectURLvalue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_iscustom = AV40Oauth20RedirectURLisCustom;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecturl_autocompletevirtualdirectory = AV111Oauth20RedirectURL_AutocompleteVirtualDirectory;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Redirecttoauthenticate = AV39Oauth20RedirectToAuthenticate;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Url = AV10AuthorizeURL;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_include = AV14AuthRespTypeInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_name = AV15AuthRespTypeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responsetype_value = AV16AuthRespTypeValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_include = AV17AuthScopeInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_name = AV18AuthScopeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Scope_value = AV19AuthScopeValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_include = AV20AuthStateIncude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_State_name = AV21AuthStateTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientid_include = AV7AuthClientIdInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Clientsecret_include = AV8AuthClientSecretInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Redirecturl_include = AV99AuthRedirURLInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparameters = AV5AuthAdditionalParameters;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Additionalparametersnativesd = AV6AuthAdditionalParametersSD;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Enable = AV109AuthOpenIDConnectProtocolEnable;
         if ( AV109AuthOpenIDConnectProtocolEnable )
         {
            AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Valididtoken = AV110AuthValidIdToken;
            AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Certificatepathfilename = AV107AuthCertificatePathFileName;
            AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Issuerurl = AV108AuthIssuerURL;
            AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Allowonlyuseremailverified = AV106AuthAllowOnlyUserEmailVerified;
         }
         else
         {
            AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Valididtoken = false;
            AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Certificatepathfilename = "";
            AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Issuerurl = "";
            AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Openidconnectauthentication.gxTpr_Allowonlyuseremailverified = false;
         }
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseaccesscode_name = AV12AuthResponseAccessCodeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Authorize.gxTpr_Responseerrordescription_name = AV13AuthResponseErrorDescTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Url = AV67TokenURL;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Method = AV57TokenMethod;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_key = AV55TokenHeaderKeyTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_value = AV56TokenHeaderKeyValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_include = AV51TokenHeaderAuthenticationInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_method = AV52TokenHeaderAuthenticationMethod;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authentication_realm = AV53TokenHeaderAuthenticationRealm;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Header_authorizationbasic_include = AV54TokenHeaderAuthorizationBasicInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_include = AV48TokenGrantTypeInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_name = AV49TokenGrantTypeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Granttype_value = AV50TokenGrantTypeValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Accesscode_include = AV44TokenAccessCodeInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientid_include = AV46TokenCliIdInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Clientsecret_include = AV47TokenCliSecretInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Redirecturl_include = AV58TokenRedirectURLInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Additionalparameters = AV45TokenAdditionalParameters;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseaccesstoken_name = AV60TokenResponseAccessTokenTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsetokentype_name = AV65TokenResponseTokenTypeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseexpiresin_name = AV62TokenResponseExpiresInTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responsescope_name = AV64TokenResponseScopeTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseuserid_name = AV66TokenResponseUserIdTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responserefreshtoken_name = AV63TokenResponseRefreshTokenTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Responseerrordescription_name = AV61TokenResponseErrorDescriptionTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Autovalidateexternaltokenandrefresh = AV22AutovalidateExternalTokenAndRefresh;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Token.gxTpr_Refreshtoken_url = AV59TokenRefreshTokenURL;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Url = AV94UserInfoURL;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Method = AV78UserInfoMethod;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_key = AV76UserInfoHeaderKeyTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Header_value = AV77UserInfoHeaderKeyValue;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_include = AV69UserInfoAccessTokenInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Accesstoken_name = AV70UserInfoAccessTokenName;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_include = AV72UserInfoClientIdInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientid_name = AV73UserInfoClientIdName;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_include = AV74UserInfoClientSecretInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Clientsecret_name = AV75UserInfoClientSecretName;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Userid_include = AV95UserInfoUserIdInclude;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Additionalparameters = AV71UserInfoAdditionalParameters;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuseremail_name = AV81UserInfoResponseUserEmailTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserverifiedemail_name = AV93UserInfoResponseUserVerifiedEmailTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserexternalid_name = AV82UserInfoResponseUserExternalIdTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusername_name = AV89UserInfoResponseUserNameTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserfirstname_name = AV83UserInfoResponseUserFirstNameTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_generateautomatic = AV87UserInfoResponseUserLastNameGenAuto;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlastname_name = AV88UserInfoResponseUserLastNameTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_name = AV84UserInfoResponseUserGenderTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusergender_values = AV85UserInfoResponseUserGenderValues;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserbirthday_name = AV80UserInfoResponseUserBirthdayTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlimage_name = AV91UserInfoResponseUserURLImageTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserurlprofile_name = AV92UserInfoResponseUserURLProfileTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseuserlanguage_name = AV86UserInfoResponseUserLanguageTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseusertimezone_name = AV90UserInfoResponseUserTimeZoneTag;
         AV9AuthenticationTypeOauth20.gxTpr_Oauth20.gxTpr_Userinfo.gxTpr_Responseerrordescription_name = AV79UserInfoResponseErrorDescriptionTag;
         AV9AuthenticationTypeOauth20.save();
         /* Start For Each Line */
         nRC_GXsfl_548 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_548"), ".", ","), 18, MidpointRounding.ToEven));
         nGXsfl_548_fel_idx = 0;
         while ( nGXsfl_548_fel_idx < nRC_GXsfl_548 )
         {
            nGXsfl_548_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_548_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_548_fel_idx+1);
            sGXsfl_548_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_548_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_5482( ) ;
            AV26DynamicPropName = cgiGet( edtavDynamicpropname_Internalname);
            AV27DynamicPropTag = cgiGet( edtavDynamicproptag_Internalname);
            AV24DeleteProperty = cgiGet( edtavDeleteproperty_Internalname);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26DynamicPropName)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27DynamicPropTag)) )
            {
               AV31GAMPropertySimple = new GeneXus.Programs.genexussecurity.SdtGAMPropertySimple(context);
               AV31GAMPropertySimple.gxTpr_Id = AV26DynamicPropName;
               AV31GAMPropertySimple.gxTpr_Value = AV27DynamicPropTag;
               if ( ! AV9AuthenticationTypeOauth20.setuserinfoproperty(AV31GAMPropertySimple, out  AV29Errors) )
               {
                  /* Execute user subroutine: 'SHOWMESSAGES' */
                  S202 ();
                  if (returnInSub) return;
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_548_fel_idx == 0 )
         {
            nGXsfl_548_idx = 1;
            sGXsfl_548_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_548_idx), 4, 0), 4, "0");
            SubsflControlProps_5482( ) ;
         }
         nGXsfl_548_fel_idx = 1;
      }

      protected void S142( )
      {
         /* 'UI_AUTOCOMPLETEVIRTUALDIRECTORY' Routine */
         returnInSub = false;
         if ( AV40Oauth20RedirectURLisCustom )
         {
            divTblautocompletevirtualdirectory_Visible = 0;
            AssignProp(sPrefix, false, divTblautocompletevirtualdirectory_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblautocompletevirtualdirectory_Visible), 5, 0), true);
         }
         else
         {
            divTblautocompletevirtualdirectory_Visible = 1;
            AssignProp(sPrefix, false, divTblautocompletevirtualdirectory_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblautocompletevirtualdirectory_Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'SHOWMESSAGES' Routine */
         returnInSub = false;
         AV223GXV2 = 1;
         while ( AV223GXV2 <= AV29Errors.Count )
         {
            AV28Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV29Errors.Item(AV223GXV2));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV28Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV28Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV223GXV2 = (int)(AV223GXV2+1);
         }
      }

      protected void S152( )
      {
         /* 'SETCAPTIONGROUPUSERBODY' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV78UserInfoMethod, "POST") == 0 )
         {
            Dvpanel_paneluserbody_Title = "Body";
            ucDvpanel_paneluserbody.SendProperty(context, sPrefix, false, Dvpanel_paneluserbody_Internalname, "Title", Dvpanel_paneluserbody_Title);
            edtavUserinfoadditionalparameters_Visible = 0;
            AssignProp(sPrefix, false, edtavUserinfoadditionalparameters_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserinfoadditionalparameters_Visible), 5, 0), true);
         }
         else
         {
            Dvpanel_paneluserbody_Title = "Parameters";
            ucDvpanel_paneluserbody.SendProperty(context, sPrefix, false, Dvpanel_paneluserbody_Internalname, "Title", Dvpanel_paneluserbody_Title);
            edtavUserinfoadditionalparameters_Visible = 1;
            AssignProp(sPrefix, false, edtavUserinfoadditionalparameters_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserinfoadditionalparameters_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'USERINFOLASTNAMEFIELDTAG' Routine */
         returnInSub = false;
         if ( AV87UserInfoResponseUserLastNameGenAuto )
         {
            edtavUserinforesponseuserlastnametag_Visible = 0;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Visible), 5, 0), true);
            lblTbuserlastnamehelp_Caption = "*Generate Last Name automatically using the first name spaces";
            AssignProp(sPrefix, false, lblTbuserlastnamehelp_Internalname, "Caption", lblTbuserlastnamehelp_Caption, true);
         }
         else
         {
            edtavUserinforesponseuserlastnametag_Visible = 1;
            AssignProp(sPrefix, false, edtavUserinforesponseuserlastnametag_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserinforesponseuserlastnametag_Visible), 5, 0), true);
            lblTbuserlastnamehelp_Caption = "";
            AssignProp(sPrefix, false, lblTbuserlastnamehelp_Internalname, "Caption", lblTbuserlastnamehelp_Caption, true);
         }
      }

      protected void S212( )
      {
         /* 'GETLISTAUTHENTICATIONTYPEIMPERSONATE' Routine */
         returnInSub = false;
         AV225GXV4 = 1;
         AV224GXV3 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getauthenticationtypes(AV218GAMAuthenticationTypeFilter, out  AV29Errors);
         while ( AV225GXV4 <= AV224GXV3.Count )
         {
            AV122AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType)AV224GXV3.Item(AV225GXV4));
            if ( StringUtil.StrCmp(AV122AuthenticationType.gxTpr_Name, AV34Name) != 0 )
            {
               cmbavImpersonate.addItem(AV122AuthenticationType.gxTpr_Name, AV122AuthenticationType.gxTpr_Name, 0);
            }
            AV225GXV4 = (int)(AV225GXV4+1);
         }
      }

      protected void S162( )
      {
         /* 'UI_OPENIDCONNECT' Routine */
         returnInSub = false;
         if ( AV109AuthOpenIDConnectProtocolEnable )
         {
            divTbl_openidconnect_Visible = 1;
            AssignProp(sPrefix, false, divTbl_openidconnect_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbl_openidconnect_Visible), 5, 0), true);
         }
         else
         {
            divTbl_openidconnect_Visible = 0;
            AssignProp(sPrefix, false, divTbl_openidconnect_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbl_openidconnect_Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'UI_VALIDIDTOKEN' Routine */
         returnInSub = false;
         if ( AV109AuthOpenIDConnectProtocolEnable && AV110AuthValidIdToken )
         {
            divTbl_valididtoken_Visible = 1;
            AssignProp(sPrefix, false, divTbl_valididtoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbl_valididtoken_Visible), 5, 0), true);
         }
         else
         {
            divTbl_valididtoken_Visible = 0;
            AssignProp(sPrefix, false, divTbl_valididtoken_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbl_valididtoken_Visible), 5, 0), true);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV34Name = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV34Name", AV34Name);
         AV68TypeId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV68TypeId", AV68TypeId);
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
         PA142( ) ;
         WS142( ) ;
         WE142( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV34Name = (string)((string)getParm(obj,1));
         sCtrlAV68TypeId = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA142( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "gamwcauthenticationtypeentryoauth20", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA142( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV34Name = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV34Name", AV34Name);
            AV68TypeId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV68TypeId", AV68TypeId);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV34Name = cgiGet( sPrefix+"wcpOAV34Name");
         wcpOAV68TypeId = cgiGet( sPrefix+"wcpOAV68TypeId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV34Name, wcpOAV34Name) != 0 ) || ( StringUtil.StrCmp(AV68TypeId, wcpOAV68TypeId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV34Name = AV34Name;
         wcpOAV68TypeId = AV68TypeId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV34Name = cgiGet( sPrefix+"AV34Name_CTRL");
         if ( StringUtil.Len( sCtrlAV34Name) > 0 )
         {
            AV34Name = cgiGet( sCtrlAV34Name);
            AssignAttri(sPrefix, false, "AV34Name", AV34Name);
         }
         else
         {
            AV34Name = cgiGet( sPrefix+"AV34Name_PARM");
         }
         sCtrlAV68TypeId = cgiGet( sPrefix+"AV68TypeId_CTRL");
         if ( StringUtil.Len( sCtrlAV68TypeId) > 0 )
         {
            AV68TypeId = cgiGet( sCtrlAV68TypeId);
            AssignAttri(sPrefix, false, "AV68TypeId", AV68TypeId);
         }
         else
         {
            AV68TypeId = cgiGet( sPrefix+"AV68TypeId_PARM");
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA142( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS142( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS142( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV34Name_PARM", StringUtil.RTrim( AV34Name));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV34Name)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV34Name_CTRL", StringUtil.RTrim( sCtrlAV34Name));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV68TypeId_PARM", StringUtil.RTrim( AV68TypeId));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV68TypeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV68TypeId_CTRL", StringUtil.RTrim( sCtrlAV68TypeId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE142( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267491133", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("gamwcauthenticationtypeentryoauth20.js", "?20256267491137", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_5482( )
      {
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME_"+sGXsfl_548_idx;
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG_"+sGXsfl_548_idx;
         edtavDeleteproperty_Internalname = sPrefix+"vDELETEPROPERTY_"+sGXsfl_548_idx;
      }

      protected void SubsflControlProps_fel_5482( )
      {
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME_"+sGXsfl_548_fel_idx;
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG_"+sGXsfl_548_fel_idx;
         edtavDeleteproperty_Internalname = sPrefix+"vDELETEPROPERTY_"+sGXsfl_548_fel_idx;
      }

      protected void sendrow_5482( )
      {
         sGXsfl_548_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_548_idx), 4, 0), 4, "0");
         SubsflControlProps_5482( ) ;
         WB140( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_548_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_548_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_548_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDynamicpropname_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 549,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',548)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDynamicpropname_Internalname,StringUtil.RTrim( AV26DynamicPropName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,549);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDynamicpropname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDynamicpropname_Visible,(int)edtavDynamicpropname_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)548,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMPropertyId",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDynamicproptag_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 550,'" + sPrefix + "',false,'" + sGXsfl_548_idx + "',548)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDynamicproptag_Internalname,StringUtil.RTrim( AV27DynamicPropTag),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,550);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDynamicproptag_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDynamicproptag_Visible,(int)edtavDynamicproptag_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)548,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDeleteproperty_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 551,'" + sPrefix + "',false,'',548)\"";
            ClassString = "ActionBaseColorAttribute" + " " + ((StringUtil.StrCmp(edtavDeleteproperty_gximage, "")==0) ? "" : "GX_Image_"+edtavDeleteproperty_gximage+"_Class");
            StyleString = "";
            AV24DeleteProperty_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV24DeleteProperty))&&String.IsNullOrEmpty(StringUtil.RTrim( AV221Deleteproperty_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV24DeleteProperty)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV24DeleteProperty)) ? AV221Deleteproperty_GXI : context.PathToRelativeUrl( AV24DeleteProperty));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeleteproperty_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtavDeleteproperty_Visible,(short)1,(string)"",(string)edtavDeleteproperty_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavDeleteproperty_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDELETEPROPERTY.CLICK."+sGXsfl_548_idx+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV24DeleteProperty_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes142( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_548_idx = ((subGrid_Islastpage==1)&&(nGXsfl_548_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_548_idx+1);
            sGXsfl_548_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_548_idx), 4, 0), 4, "0");
            SubsflControlProps_5482( ) ;
         }
         /* End function sendrow_5482 */
      }

      protected void init_web_controls( )
      {
         cmbavIdp.Name = "vIDP";
         cmbavIdp.WebTags = "";
         cmbavIdp.addItem("GAMInitAuthTypeOAuth20-Default", "Default", 0);
         cmbavIdp.addItem("GAMInitAuthTypeOAuth20-Azure", "Microsoft Entra ID", 0);
         if ( cmbavIdp.ItemCount > 0 )
         {
         }
         cmbavFunctionid.Name = "vFUNCTIONID";
         cmbavFunctionid.WebTags = "";
         cmbavFunctionid.addItem("AuthenticationAndRoles", "Authentication and roles", 0);
         cmbavFunctionid.addItem("OnlyAuthentication", "Only authentication", 0);
         if ( cmbavFunctionid.ItemCount > 0 )
         {
         }
         chkavIsenable.Name = "vISENABLE";
         chkavIsenable.WebTags = "";
         chkavIsenable.Caption = " ";
         AssignProp(sPrefix, false, chkavIsenable_Internalname, "TitleCaption", chkavIsenable.Caption, true);
         chkavIsenable.CheckedValue = "false";
         cmbavImpersonate.Name = "vIMPERSONATE";
         cmbavImpersonate.WebTags = "";
         cmbavImpersonate.addItem("", "(None)", 0);
         if ( cmbavImpersonate.ItemCount > 0 )
         {
         }
         chkavOauth20redirecturliscustom.Name = "vOAUTH20REDIRECTURLISCUSTOM";
         chkavOauth20redirecturliscustom.WebTags = "";
         chkavOauth20redirecturliscustom.Caption = " ";
         AssignProp(sPrefix, false, chkavOauth20redirecturliscustom_Internalname, "TitleCaption", chkavOauth20redirecturliscustom.Caption, true);
         chkavOauth20redirecturliscustom.CheckedValue = "false";
         chkavOauth20redirecturl_autocompletevirtualdirectory.Name = "vOAUTH20REDIRECTURL_AUTOCOMPLETEVIRTUALDIRECTORY";
         chkavOauth20redirecturl_autocompletevirtualdirectory.WebTags = "";
         chkavOauth20redirecturl_autocompletevirtualdirectory.Caption = " ";
         AssignProp(sPrefix, false, chkavOauth20redirecturl_autocompletevirtualdirectory_Internalname, "TitleCaption", chkavOauth20redirecturl_autocompletevirtualdirectory.Caption, true);
         chkavOauth20redirecturl_autocompletevirtualdirectory.CheckedValue = "false";
         chkavOauth20redirecttoauthenticate.Name = "vOAUTH20REDIRECTTOAUTHENTICATE";
         chkavOauth20redirecttoauthenticate.WebTags = "";
         chkavOauth20redirecttoauthenticate.Caption = " ";
         AssignProp(sPrefix, false, chkavOauth20redirecttoauthenticate_Internalname, "TitleCaption", chkavOauth20redirecttoauthenticate.Caption, true);
         chkavOauth20redirecttoauthenticate.CheckedValue = "false";
         chkavAuthresptypeinclude.Name = "vAUTHRESPTYPEINCLUDE";
         chkavAuthresptypeinclude.WebTags = "";
         chkavAuthresptypeinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavAuthresptypeinclude_Internalname, "TitleCaption", chkavAuthresptypeinclude.Caption, true);
         chkavAuthresptypeinclude.CheckedValue = "false";
         chkavAuthscopeinclude.Name = "vAUTHSCOPEINCLUDE";
         chkavAuthscopeinclude.WebTags = "";
         chkavAuthscopeinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavAuthscopeinclude_Internalname, "TitleCaption", chkavAuthscopeinclude.Caption, true);
         chkavAuthscopeinclude.CheckedValue = "false";
         chkavAuthstateinclude.Name = "vAUTHSTATEINCLUDE";
         chkavAuthstateinclude.WebTags = "";
         chkavAuthstateinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavAuthstateinclude_Internalname, "TitleCaption", chkavAuthstateinclude.Caption, true);
         chkavAuthstateinclude.CheckedValue = "false";
         chkavAuthclientidinclude.Name = "vAUTHCLIENTIDINCLUDE";
         chkavAuthclientidinclude.WebTags = "";
         chkavAuthclientidinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavAuthclientidinclude_Internalname, "TitleCaption", chkavAuthclientidinclude.Caption, true);
         chkavAuthclientidinclude.CheckedValue = "false";
         chkavAuthclientsecretinclude.Name = "vAUTHCLIENTSECRETINCLUDE";
         chkavAuthclientsecretinclude.WebTags = "";
         chkavAuthclientsecretinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavAuthclientsecretinclude_Internalname, "TitleCaption", chkavAuthclientsecretinclude.Caption, true);
         chkavAuthclientsecretinclude.CheckedValue = "false";
         chkavAuthredirurlinclude.Name = "vAUTHREDIRURLINCLUDE";
         chkavAuthredirurlinclude.WebTags = "";
         chkavAuthredirurlinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavAuthredirurlinclude_Internalname, "TitleCaption", chkavAuthredirurlinclude.Caption, true);
         chkavAuthredirurlinclude.CheckedValue = "false";
         chkavAuthopenidconnectprotocolenable.Name = "vAUTHOPENIDCONNECTPROTOCOLENABLE";
         chkavAuthopenidconnectprotocolenable.WebTags = "";
         chkavAuthopenidconnectprotocolenable.Caption = "Enable OpenID Connect Protocol?";
         AssignProp(sPrefix, false, chkavAuthopenidconnectprotocolenable_Internalname, "TitleCaption", chkavAuthopenidconnectprotocolenable.Caption, true);
         chkavAuthopenidconnectprotocolenable.CheckedValue = "false";
         chkavAuthvalididtoken.Name = "vAUTHVALIDIDTOKEN";
         chkavAuthvalididtoken.WebTags = "";
         chkavAuthvalididtoken.Caption = "Validate ID Token?";
         AssignProp(sPrefix, false, chkavAuthvalididtoken_Internalname, "TitleCaption", chkavAuthvalididtoken.Caption, true);
         chkavAuthvalididtoken.CheckedValue = "false";
         chkavAuthallowonlyuseremailverified.Name = "vAUTHALLOWONLYUSEREMAILVERIFIED";
         chkavAuthallowonlyuseremailverified.WebTags = "";
         chkavAuthallowonlyuseremailverified.Caption = "Allow only users with verified email?";
         AssignProp(sPrefix, false, chkavAuthallowonlyuseremailverified_Internalname, "TitleCaption", chkavAuthallowonlyuseremailverified.Caption, true);
         chkavAuthallowonlyuseremailverified.CheckedValue = "false";
         cmbavTokenmethod.Name = "vTOKENMETHOD";
         cmbavTokenmethod.WebTags = "";
         cmbavTokenmethod.addItem("POST", "POST", 0);
         cmbavTokenmethod.addItem("GET", "GET", 0);
         if ( cmbavTokenmethod.ItemCount > 0 )
         {
         }
         chkavTokenheaderauthenticationinclude.Name = "vTOKENHEADERAUTHENTICATIONINCLUDE";
         chkavTokenheaderauthenticationinclude.WebTags = "";
         chkavTokenheaderauthenticationinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavTokenheaderauthenticationinclude_Internalname, "TitleCaption", chkavTokenheaderauthenticationinclude.Caption, true);
         chkavTokenheaderauthenticationinclude.CheckedValue = "false";
         chkavTokenheaderauthorizationbasicinclude.Name = "vTOKENHEADERAUTHORIZATIONBASICINCLUDE";
         chkavTokenheaderauthorizationbasicinclude.WebTags = "";
         chkavTokenheaderauthorizationbasicinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavTokenheaderauthorizationbasicinclude_Internalname, "TitleCaption", chkavTokenheaderauthorizationbasicinclude.Caption, true);
         chkavTokenheaderauthorizationbasicinclude.CheckedValue = "false";
         cmbavTokenheaderauthenticationmethod.Name = "vTOKENHEADERAUTHENTICATIONMETHOD";
         cmbavTokenheaderauthenticationmethod.WebTags = "";
         cmbavTokenheaderauthenticationmethod.addItem("0", "Basic", 0);
         cmbavTokenheaderauthenticationmethod.addItem("1", "Digest", 0);
         cmbavTokenheaderauthenticationmethod.addItem("2", "NTLM", 0);
         cmbavTokenheaderauthenticationmethod.addItem("3", "Kerberos", 0);
         cmbavTokenheaderauthenticationmethod.addItem("4", "OAuth", 0);
         if ( cmbavTokenheaderauthenticationmethod.ItemCount > 0 )
         {
         }
         chkavTokengranttypeinclude.Name = "vTOKENGRANTTYPEINCLUDE";
         chkavTokengranttypeinclude.WebTags = "";
         chkavTokengranttypeinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavTokengranttypeinclude_Internalname, "TitleCaption", chkavTokengranttypeinclude.Caption, true);
         chkavTokengranttypeinclude.CheckedValue = "false";
         chkavTokenaccesscodeinclude.Name = "vTOKENACCESSCODEINCLUDE";
         chkavTokenaccesscodeinclude.WebTags = "";
         chkavTokenaccesscodeinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavTokenaccesscodeinclude_Internalname, "TitleCaption", chkavTokenaccesscodeinclude.Caption, true);
         chkavTokenaccesscodeinclude.CheckedValue = "false";
         chkavTokencliidinclude.Name = "vTOKENCLIIDINCLUDE";
         chkavTokencliidinclude.WebTags = "";
         chkavTokencliidinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavTokencliidinclude_Internalname, "TitleCaption", chkavTokencliidinclude.Caption, true);
         chkavTokencliidinclude.CheckedValue = "false";
         chkavTokenclisecretinclude.Name = "vTOKENCLISECRETINCLUDE";
         chkavTokenclisecretinclude.WebTags = "";
         chkavTokenclisecretinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavTokenclisecretinclude_Internalname, "TitleCaption", chkavTokenclisecretinclude.Caption, true);
         chkavTokenclisecretinclude.CheckedValue = "false";
         chkavTokenredirecturlinclude.Name = "vTOKENREDIRECTURLINCLUDE";
         chkavTokenredirecturlinclude.WebTags = "";
         chkavTokenredirecturlinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavTokenredirecturlinclude_Internalname, "TitleCaption", chkavTokenredirecturlinclude.Caption, true);
         chkavTokenredirecturlinclude.CheckedValue = "false";
         chkavAutovalidateexternaltokenandrefresh.Name = "vAUTOVALIDATEEXTERNALTOKENANDREFRESH";
         chkavAutovalidateexternaltokenandrefresh.WebTags = "";
         chkavAutovalidateexternaltokenandrefresh.Caption = " ";
         AssignProp(sPrefix, false, chkavAutovalidateexternaltokenandrefresh_Internalname, "TitleCaption", chkavAutovalidateexternaltokenandrefresh.Caption, true);
         chkavAutovalidateexternaltokenandrefresh.CheckedValue = "false";
         cmbavUserinfomethod.Name = "vUSERINFOMETHOD";
         cmbavUserinfomethod.WebTags = "";
         cmbavUserinfomethod.addItem("POST", "POST", 0);
         cmbavUserinfomethod.addItem("GET", "GET", 0);
         if ( cmbavUserinfomethod.ItemCount > 0 )
         {
         }
         chkavUserinfoaccesstokeninclude.Name = "vUSERINFOACCESSTOKENINCLUDE";
         chkavUserinfoaccesstokeninclude.WebTags = "";
         chkavUserinfoaccesstokeninclude.Caption = " ";
         AssignProp(sPrefix, false, chkavUserinfoaccesstokeninclude_Internalname, "TitleCaption", chkavUserinfoaccesstokeninclude.Caption, true);
         chkavUserinfoaccesstokeninclude.CheckedValue = "false";
         chkavUserinfoclientidinclude.Name = "vUSERINFOCLIENTIDINCLUDE";
         chkavUserinfoclientidinclude.WebTags = "";
         chkavUserinfoclientidinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavUserinfoclientidinclude_Internalname, "TitleCaption", chkavUserinfoclientidinclude.Caption, true);
         chkavUserinfoclientidinclude.CheckedValue = "false";
         chkavUserinfoclientsecretinclude.Name = "vUSERINFOCLIENTSECRETINCLUDE";
         chkavUserinfoclientsecretinclude.WebTags = "";
         chkavUserinfoclientsecretinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavUserinfoclientsecretinclude_Internalname, "TitleCaption", chkavUserinfoclientsecretinclude.Caption, true);
         chkavUserinfoclientsecretinclude.CheckedValue = "false";
         chkavUserinfouseridinclude.Name = "vUSERINFOUSERIDINCLUDE";
         chkavUserinfouseridinclude.WebTags = "";
         chkavUserinfouseridinclude.Caption = " ";
         AssignProp(sPrefix, false, chkavUserinfouseridinclude_Internalname, "TitleCaption", chkavUserinfouseridinclude.Caption, true);
         chkavUserinfouseridinclude.CheckedValue = "false";
         chkavUserinforesponseuserlastnamegenauto.Name = "vUSERINFORESPONSEUSERLASTNAMEGENAUTO";
         chkavUserinforesponseuserlastnamegenauto.WebTags = "";
         chkavUserinforesponseuserlastnamegenauto.Caption = " ";
         AssignProp(sPrefix, false, chkavUserinforesponseuserlastnamegenauto_Internalname, "TitleCaption", chkavUserinforesponseuserlastnamegenauto.Caption, true);
         chkavUserinforesponseuserlastnamegenauto.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl548( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"548\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDynamicpropname_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Attribute Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDynamicproptag_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Attribute Tag") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ActionBaseColorAttribute"+" "+((StringUtil.StrCmp(edtavDeleteproperty_gximage, "")==0) ? "" : "GX_Image_"+edtavDeleteproperty_gximage+"_Class")+"\" "+" style=\""+((edtavDeleteproperty_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV26DynamicPropName)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicpropname_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicpropname_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27DynamicPropTag)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicproptag_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDynamicproptag_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV24DeleteProperty));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDeleteproperty_Tooltiptext));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeleteproperty_Visible), 5, 0, ".", "")));
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
         cmbavIdp_Internalname = sPrefix+"vIDP";
         edtavName_Internalname = sPrefix+"vNAME";
         cmbavFunctionid_Internalname = sPrefix+"vFUNCTIONID";
         edtavDsc_Internalname = sPrefix+"vDSC";
         chkavIsenable_Internalname = sPrefix+"vISENABLE";
         cmbavImpersonate_Internalname = sPrefix+"vIMPERSONATE";
         edtavSmallimagename_Internalname = sPrefix+"vSMALLIMAGENAME";
         edtavBigimagename_Internalname = sPrefix+"vBIGIMAGENAME";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         lblGeneral_title_Internalname = sPrefix+"GENERAL_TITLE";
         edtavOauth20clientidtag_Internalname = sPrefix+"vOAUTH20CLIENTIDTAG";
         edtavOauth20clientidvalue_Internalname = sPrefix+"vOAUTH20CLIENTIDVALUE";
         edtavOauth20clientsecrettag_Internalname = sPrefix+"vOAUTH20CLIENTSECRETTAG";
         edtavOauth20clientsecretvalue_Internalname = sPrefix+"vOAUTH20CLIENTSECRETVALUE";
         edtavOauth20redirecturltag_Internalname = sPrefix+"vOAUTH20REDIRECTURLTAG";
         edtavOauth20redirecturlvalue_Internalname = sPrefix+"vOAUTH20REDIRECTURLVALUE";
         chkavOauth20redirecturliscustom_Internalname = sPrefix+"vOAUTH20REDIRECTURLISCUSTOM";
         lblTbhelpcustomredirect_Internalname = sPrefix+"TBHELPCUSTOMREDIRECT";
         chkavOauth20redirecturl_autocompletevirtualdirectory_Internalname = sPrefix+"vOAUTH20REDIRECTURL_AUTOCOMPLETEVIRTUALDIRECTORY";
         lblTbhelpautocompletevirtualdirectory_Internalname = sPrefix+"TBHELPAUTOCOMPLETEVIRTUALDIRECTORY";
         divTblautocompletevirtualdirectory_Internalname = sPrefix+"TBLAUTOCOMPLETEVIRTUALDIRECTORY";
         chkavOauth20redirecttoauthenticate_Internalname = sPrefix+"vOAUTH20REDIRECTTOAUTHENTICATE";
         lblTbhelp0redirecttoauthenticate_Internalname = sPrefix+"TBHELP0REDIRECTTOAUTHENTICATE";
         divUnnamedtable16_Internalname = sPrefix+"UNNAMEDTABLE16";
         divUnnamedtable15_Internalname = sPrefix+"UNNAMEDTABLE15";
         lblAuthorization_title_Internalname = sPrefix+"AUTHORIZATION_TITLE";
         edtavAuthorizeurl_Internalname = sPrefix+"vAUTHORIZEURL";
         chkavAuthresptypeinclude_Internalname = sPrefix+"vAUTHRESPTYPEINCLUDE";
         edtavAuthresptypetag_Internalname = sPrefix+"vAUTHRESPTYPETAG";
         edtavAuthresptypevalue_Internalname = sPrefix+"vAUTHRESPTYPEVALUE";
         chkavAuthscopeinclude_Internalname = sPrefix+"vAUTHSCOPEINCLUDE";
         edtavAuthscopetag_Internalname = sPrefix+"vAUTHSCOPETAG";
         edtavAuthscopevalue_Internalname = sPrefix+"vAUTHSCOPEVALUE";
         chkavAuthstateinclude_Internalname = sPrefix+"vAUTHSTATEINCLUDE";
         edtavAuthstatetag_Internalname = sPrefix+"vAUTHSTATETAG";
         chkavAuthclientidinclude_Internalname = sPrefix+"vAUTHCLIENTIDINCLUDE";
         chkavAuthclientsecretinclude_Internalname = sPrefix+"vAUTHCLIENTSECRETINCLUDE";
         chkavAuthredirurlinclude_Internalname = sPrefix+"vAUTHREDIRURLINCLUDE";
         edtavAuthadditionalparameters_Internalname = sPrefix+"vAUTHADDITIONALPARAMETERS";
         edtavAuthadditionalparameterssd_Internalname = sPrefix+"vAUTHADDITIONALPARAMETERSSD";
         chkavAuthopenidconnectprotocolenable_Internalname = sPrefix+"vAUTHOPENIDCONNECTPROTOCOLENABLE";
         chkavAuthvalididtoken_Internalname = sPrefix+"vAUTHVALIDIDTOKEN";
         edtavAuthissuerurl_Internalname = sPrefix+"vAUTHISSUERURL";
         edtavAuthcertificatepathfilename_Internalname = sPrefix+"vAUTHCERTIFICATEPATHFILENAME";
         chkavAuthallowonlyuseremailverified_Internalname = sPrefix+"vAUTHALLOWONLYUSEREMAILVERIFIED";
         divTbl_valididtoken_Internalname = sPrefix+"TBL_VALIDIDTOKEN";
         divGroupauthopenidconnecttable1_Internalname = sPrefix+"GROUPAUTHOPENIDCONNECTTABLE1";
         Dvpanel_groupauthopenidconnecttable1_Internalname = sPrefix+"DVPANEL_GROUPAUTHOPENIDCONNECTTABLE1";
         divTbl_openidconnect_Internalname = sPrefix+"TBL_OPENIDCONNECT";
         edtavAuthresponseaccesscodetag_Internalname = sPrefix+"vAUTHRESPONSEACCESSCODETAG";
         edtavAuthresponseerrordesctag_Internalname = sPrefix+"vAUTHRESPONSEERRORDESCTAG";
         divUnnamedtable14_Internalname = sPrefix+"UNNAMEDTABLE14";
         Dvpanel_unnamedtable14_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE14";
         divUnnamedtable13_Internalname = sPrefix+"UNNAMEDTABLE13";
         Dvpanel_unnamedtable13_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE13";
         divUnnamedtable12_Internalname = sPrefix+"UNNAMEDTABLE12";
         lblToken_title_Internalname = sPrefix+"TOKEN_TITLE";
         edtavTokenurl_Internalname = sPrefix+"vTOKENURL";
         cmbavTokenmethod_Internalname = sPrefix+"vTOKENMETHOD";
         edtavTokenheaderkeytag_Internalname = sPrefix+"vTOKENHEADERKEYTAG";
         edtavTokenheaderkeyvalue_Internalname = sPrefix+"vTOKENHEADERKEYVALUE";
         chkavTokenheaderauthenticationinclude_Internalname = sPrefix+"vTOKENHEADERAUTHENTICATIONINCLUDE";
         chkavTokenheaderauthorizationbasicinclude_Internalname = sPrefix+"vTOKENHEADERAUTHORIZATIONBASICINCLUDE";
         cmbavTokenheaderauthenticationmethod_Internalname = sPrefix+"vTOKENHEADERAUTHENTICATIONMETHOD";
         edtavTokenheaderauthenticationrealm_Internalname = sPrefix+"vTOKENHEADERAUTHENTICATIONREALM";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         Dvpanel_unnamedtable7_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE7";
         chkavTokengranttypeinclude_Internalname = sPrefix+"vTOKENGRANTTYPEINCLUDE";
         edtavTokengranttypetag_Internalname = sPrefix+"vTOKENGRANTTYPETAG";
         edtavTokengranttypevalue_Internalname = sPrefix+"vTOKENGRANTTYPEVALUE";
         chkavTokenaccesscodeinclude_Internalname = sPrefix+"vTOKENACCESSCODEINCLUDE";
         chkavTokencliidinclude_Internalname = sPrefix+"vTOKENCLIIDINCLUDE";
         chkavTokenclisecretinclude_Internalname = sPrefix+"vTOKENCLISECRETINCLUDE";
         chkavTokenredirecturlinclude_Internalname = sPrefix+"vTOKENREDIRECTURLINCLUDE";
         edtavTokenadditionalparameters_Internalname = sPrefix+"vTOKENADDITIONALPARAMETERS";
         divUnnamedtable9_Internalname = sPrefix+"UNNAMEDTABLE9";
         Dvpanel_unnamedtable9_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE9";
         edtavTokenresponseaccesstokentag_Internalname = sPrefix+"vTOKENRESPONSEACCESSTOKENTAG";
         edtavTokenresponsetokentypetag_Internalname = sPrefix+"vTOKENRESPONSETOKENTYPETAG";
         edtavTokenresponseexpiresintag_Internalname = sPrefix+"vTOKENRESPONSEEXPIRESINTAG";
         edtavTokenresponsescopetag_Internalname = sPrefix+"vTOKENRESPONSESCOPETAG";
         edtavTokenresponseuseridtag_Internalname = sPrefix+"vTOKENRESPONSEUSERIDTAG";
         edtavTokenresponserefreshtokentag_Internalname = sPrefix+"vTOKENRESPONSEREFRESHTOKENTAG";
         edtavTokenresponseerrordescriptiontag_Internalname = sPrefix+"vTOKENRESPONSEERRORDESCRIPTIONTAG";
         divUnnamedtable10_Internalname = sPrefix+"UNNAMEDTABLE10";
         Dvpanel_unnamedtable10_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE10";
         chkavAutovalidateexternaltokenandrefresh_Internalname = sPrefix+"vAUTOVALIDATEEXTERNALTOKENANDREFRESH";
         edtavTokenrefreshtokenurl_Internalname = sPrefix+"vTOKENREFRESHTOKENURL";
         divUnnamedtable11_Internalname = sPrefix+"UNNAMEDTABLE11";
         Dvpanel_unnamedtable11_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE11";
         divUnnamedtable8_Internalname = sPrefix+"UNNAMEDTABLE8";
         Dvpanel_unnamedtable8_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE8";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         lblUserinfo_title_Internalname = sPrefix+"USERINFO_TITLE";
         edtavUserinfourl_Internalname = sPrefix+"vUSERINFOURL";
         cmbavUserinfomethod_Internalname = sPrefix+"vUSERINFOMETHOD";
         edtavUserinfoheaderkeytag_Internalname = sPrefix+"vUSERINFOHEADERKEYTAG";
         edtavUserinfoheaderkeyvalue_Internalname = sPrefix+"vUSERINFOHEADERKEYVALUE";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         Dvpanel_unnamedtable2_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE2";
         chkavUserinfoaccesstokeninclude_Internalname = sPrefix+"vUSERINFOACCESSTOKENINCLUDE";
         edtavUserinfoaccesstokenname_Internalname = sPrefix+"vUSERINFOACCESSTOKENNAME";
         chkavUserinfoclientidinclude_Internalname = sPrefix+"vUSERINFOCLIENTIDINCLUDE";
         edtavUserinfoclientidname_Internalname = sPrefix+"vUSERINFOCLIENTIDNAME";
         chkavUserinfoclientsecretinclude_Internalname = sPrefix+"vUSERINFOCLIENTSECRETINCLUDE";
         edtavUserinfoclientsecretname_Internalname = sPrefix+"vUSERINFOCLIENTSECRETNAME";
         chkavUserinfouseridinclude_Internalname = sPrefix+"vUSERINFOUSERIDINCLUDE";
         edtavUserinfoadditionalparameters_Internalname = sPrefix+"vUSERINFOADDITIONALPARAMETERS";
         divPaneluserbody_Internalname = sPrefix+"PANELUSERBODY";
         Dvpanel_paneluserbody_Internalname = sPrefix+"DVPANEL_PANELUSERBODY";
         edtavUserinforesponseuseremailtag_Internalname = sPrefix+"vUSERINFORESPONSEUSEREMAILTAG";
         edtavUserinforesponseuserverifiedemailtag_Internalname = sPrefix+"vUSERINFORESPONSEUSERVERIFIEDEMAILTAG";
         edtavUserinforesponseuserexternalidtag_Internalname = sPrefix+"vUSERINFORESPONSEUSEREXTERNALIDTAG";
         edtavUserinforesponseusernametag_Internalname = sPrefix+"vUSERINFORESPONSEUSERNAMETAG";
         edtavUserinforesponseuserfirstnametag_Internalname = sPrefix+"vUSERINFORESPONSEUSERFIRSTNAMETAG";
         chkavUserinforesponseuserlastnamegenauto_Internalname = sPrefix+"vUSERINFORESPONSEUSERLASTNAMEGENAUTO";
         lblTbuserlastnamehelp_Internalname = sPrefix+"TBUSERLASTNAMEHELP";
         edtavUserinforesponseuserlastnametag_Internalname = sPrefix+"vUSERINFORESPONSEUSERLASTNAMETAG";
         divUserinforesponseuserlastnametag_cell_Internalname = sPrefix+"USERINFORESPONSEUSERLASTNAMETAG_CELL";
         edtavUserinforesponseusergendertag_Internalname = sPrefix+"vUSERINFORESPONSEUSERGENDERTAG";
         edtavUserinforesponseusergendervalues_Internalname = sPrefix+"vUSERINFORESPONSEUSERGENDERVALUES";
         edtavUserinforesponseuserbirthdaytag_Internalname = sPrefix+"vUSERINFORESPONSEUSERBIRTHDAYTAG";
         edtavUserinforesponseuserurlimagetag_Internalname = sPrefix+"vUSERINFORESPONSEUSERURLIMAGETAG";
         edtavUserinforesponseuserurlprofiletag_Internalname = sPrefix+"vUSERINFORESPONSEUSERURLPROFILETAG";
         edtavUserinforesponseuserlanguagetag_Internalname = sPrefix+"vUSERINFORESPONSEUSERLANGUAGETAG";
         edtavUserinforesponseusertimezonetag_Internalname = sPrefix+"vUSERINFORESPONSEUSERTIMEZONETAG";
         edtavUserinforesponseerrordescriptiontag_Internalname = sPrefix+"vUSERINFORESPONSEERRORDESCRIPTIONTAG";
         divUnnamedtable4_Internalname = sPrefix+"UNNAMEDTABLE4";
         Dvpanel_unnamedtable4_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE4";
         edtavDynamicpropname_Internalname = sPrefix+"vDYNAMICPROPNAME";
         edtavDynamicproptag_Internalname = sPrefix+"vDYNAMICPROPTAG";
         edtavDeleteproperty_Internalname = sPrefix+"vDELETEPROPERTY";
         bttBtnadd_Internalname = sPrefix+"BTNADD";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         Dvpanel_unnamedtable5_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE5";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         Dvpanel_unnamedtable3_Internalname = sPrefix+"DVPANEL_UNNAMEDTABLE3";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         Gxuitabspanel_tabs_Internalname = sPrefix+"GXUITABSPANEL_TABS";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkavUserinforesponseuserlastnamegenauto.Caption = " ";
         chkavUserinfouseridinclude.Caption = " ";
         chkavUserinfoclientsecretinclude.Caption = " ";
         chkavUserinfoclientidinclude.Caption = " ";
         chkavUserinfoaccesstokeninclude.Caption = " ";
         chkavAutovalidateexternaltokenandrefresh.Caption = " ";
         chkavTokenredirecturlinclude.Caption = " ";
         chkavTokenclisecretinclude.Caption = " ";
         chkavTokencliidinclude.Caption = " ";
         chkavTokenaccesscodeinclude.Caption = " ";
         chkavTokengranttypeinclude.Caption = " ";
         chkavTokenheaderauthorizationbasicinclude.Caption = " ";
         chkavTokenheaderauthenticationinclude.Caption = " ";
         chkavAuthallowonlyuseremailverified.Caption = "Allow only users with verified email?";
         chkavAuthvalididtoken.Caption = "Validate ID Token?";
         chkavAuthopenidconnectprotocolenable.Caption = "Enable OpenID Connect Protocol?";
         chkavAuthredirurlinclude.Caption = " ";
         chkavAuthclientsecretinclude.Caption = " ";
         chkavAuthclientidinclude.Caption = " ";
         chkavAuthstateinclude.Caption = " ";
         chkavAuthscopeinclude.Caption = " ";
         chkavAuthresptypeinclude.Caption = " ";
         chkavOauth20redirecttoauthenticate.Caption = " ";
         chkavOauth20redirecturl_autocompletevirtualdirectory.Caption = " ";
         chkavOauth20redirecturliscustom.Caption = " ";
         chkavIsenable.Caption = " ";
         edtavDeleteproperty_Jsonclick = "";
         edtavDeleteproperty_Tooltiptext = "";
         edtavDynamicproptag_Jsonclick = "";
         edtavDynamicpropname_Jsonclick = "";
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDynamicproptag_Visible = -1;
         edtavDynamicproptag_Enabled = 1;
         edtavDynamicpropname_Visible = -1;
         edtavDynamicpropname_Enabled = 1;
         edtavDeleteproperty_Visible = -1;
         edtavDeleteproperty_gximage = "";
         bttBtnenter_Caption = "Confirm";
         bttBtnenter_Visible = 1;
         bttBtnadd_Visible = 1;
         edtavUserinforesponseerrordescriptiontag_Jsonclick = "";
         edtavUserinforesponseerrordescriptiontag_Enabled = 1;
         edtavUserinforesponseusertimezonetag_Jsonclick = "";
         edtavUserinforesponseusertimezonetag_Enabled = 1;
         edtavUserinforesponseuserlanguagetag_Jsonclick = "";
         edtavUserinforesponseuserlanguagetag_Enabled = 1;
         edtavUserinforesponseuserurlprofiletag_Jsonclick = "";
         edtavUserinforesponseuserurlprofiletag_Enabled = 1;
         edtavUserinforesponseuserurlimagetag_Jsonclick = "";
         edtavUserinforesponseuserurlimagetag_Enabled = 1;
         edtavUserinforesponseuserbirthdaytag_Jsonclick = "";
         edtavUserinforesponseuserbirthdaytag_Enabled = 1;
         edtavUserinforesponseusergendervalues_Jsonclick = "";
         edtavUserinforesponseusergendervalues_Enabled = 1;
         edtavUserinforesponseusergendertag_Jsonclick = "";
         edtavUserinforesponseusergendertag_Enabled = 1;
         edtavUserinforesponseuserlastnametag_Jsonclick = "";
         edtavUserinforesponseuserlastnametag_Enabled = 1;
         edtavUserinforesponseuserlastnametag_Visible = 1;
         divUserinforesponseuserlastnametag_cell_Class = "col-xs-12 col-sm-6";
         lblTbuserlastnamehelp_Caption = "Generate Last Name automatically using the first name spaces";
         chkavUserinforesponseuserlastnamegenauto.Enabled = 1;
         edtavUserinforesponseuserfirstnametag_Jsonclick = "";
         edtavUserinforesponseuserfirstnametag_Enabled = 1;
         edtavUserinforesponseusernametag_Jsonclick = "";
         edtavUserinforesponseusernametag_Enabled = 1;
         edtavUserinforesponseuserexternalidtag_Jsonclick = "";
         edtavUserinforesponseuserexternalidtag_Enabled = 1;
         edtavUserinforesponseuserverifiedemailtag_Jsonclick = "";
         edtavUserinforesponseuserverifiedemailtag_Enabled = 1;
         edtavUserinforesponseuseremailtag_Jsonclick = "";
         edtavUserinforesponseuseremailtag_Enabled = 1;
         edtavUserinfoadditionalparameters_Jsonclick = "";
         edtavUserinfoadditionalparameters_Enabled = 1;
         edtavUserinfoadditionalparameters_Visible = 1;
         chkavUserinfouseridinclude.Enabled = 1;
         edtavUserinfoclientsecretname_Jsonclick = "";
         edtavUserinfoclientsecretname_Enabled = 1;
         chkavUserinfoclientsecretinclude.Enabled = 1;
         edtavUserinfoclientidname_Jsonclick = "";
         edtavUserinfoclientidname_Enabled = 1;
         chkavUserinfoclientidinclude.Enabled = 1;
         edtavUserinfoaccesstokenname_Jsonclick = "";
         edtavUserinfoaccesstokenname_Enabled = 1;
         chkavUserinfoaccesstokeninclude.Enabled = 1;
         edtavUserinfoheaderkeyvalue_Jsonclick = "";
         edtavUserinfoheaderkeyvalue_Enabled = 1;
         edtavUserinfoheaderkeytag_Jsonclick = "";
         edtavUserinfoheaderkeytag_Enabled = 1;
         cmbavUserinfomethod_Jsonclick = "";
         cmbavUserinfomethod.Enabled = 1;
         edtavUserinfourl_Jsonclick = "";
         edtavUserinfourl_Enabled = 1;
         edtavTokenrefreshtokenurl_Jsonclick = "";
         edtavTokenrefreshtokenurl_Enabled = 1;
         chkavAutovalidateexternaltokenandrefresh.Enabled = 1;
         edtavTokenresponseerrordescriptiontag_Jsonclick = "";
         edtavTokenresponseerrordescriptiontag_Enabled = 1;
         edtavTokenresponserefreshtokentag_Jsonclick = "";
         edtavTokenresponserefreshtokentag_Enabled = 1;
         edtavTokenresponseuseridtag_Jsonclick = "";
         edtavTokenresponseuseridtag_Enabled = 1;
         edtavTokenresponsescopetag_Jsonclick = "";
         edtavTokenresponsescopetag_Enabled = 1;
         edtavTokenresponseexpiresintag_Jsonclick = "";
         edtavTokenresponseexpiresintag_Enabled = 1;
         edtavTokenresponsetokentypetag_Jsonclick = "";
         edtavTokenresponsetokentypetag_Enabled = 1;
         edtavTokenresponseaccesstokentag_Jsonclick = "";
         edtavTokenresponseaccesstokentag_Enabled = 1;
         edtavTokenadditionalparameters_Jsonclick = "";
         edtavTokenadditionalparameters_Enabled = 1;
         chkavTokenredirecturlinclude.Enabled = 1;
         chkavTokenclisecretinclude.Enabled = 1;
         chkavTokencliidinclude.Enabled = 1;
         chkavTokenaccesscodeinclude.Enabled = 1;
         edtavTokengranttypevalue_Jsonclick = "";
         edtavTokengranttypevalue_Enabled = 1;
         edtavTokengranttypetag_Jsonclick = "";
         edtavTokengranttypetag_Enabled = 1;
         chkavTokengranttypeinclude.Enabled = 1;
         edtavTokenheaderauthenticationrealm_Jsonclick = "";
         edtavTokenheaderauthenticationrealm_Enabled = 1;
         cmbavTokenheaderauthenticationmethod_Jsonclick = "";
         cmbavTokenheaderauthenticationmethod.Enabled = 1;
         chkavTokenheaderauthorizationbasicinclude.Enabled = 1;
         chkavTokenheaderauthenticationinclude.Enabled = 1;
         edtavTokenheaderkeyvalue_Jsonclick = "";
         edtavTokenheaderkeyvalue_Enabled = 1;
         edtavTokenheaderkeytag_Jsonclick = "";
         edtavTokenheaderkeytag_Enabled = 1;
         cmbavTokenmethod_Jsonclick = "";
         cmbavTokenmethod.Enabled = 1;
         edtavTokenurl_Jsonclick = "";
         edtavTokenurl_Enabled = 1;
         edtavAuthresponseerrordesctag_Jsonclick = "";
         edtavAuthresponseerrordesctag_Enabled = 1;
         edtavAuthresponseaccesscodetag_Jsonclick = "";
         edtavAuthresponseaccesscodetag_Enabled = 1;
         chkavAuthallowonlyuseremailverified.Enabled = 1;
         edtavAuthcertificatepathfilename_Jsonclick = "";
         edtavAuthcertificatepathfilename_Enabled = 1;
         edtavAuthissuerurl_Jsonclick = "";
         edtavAuthissuerurl_Enabled = 1;
         divTbl_valididtoken_Visible = 1;
         chkavAuthvalididtoken.Enabled = 1;
         divTbl_openidconnect_Visible = 1;
         chkavAuthopenidconnectprotocolenable.Enabled = 1;
         edtavAuthadditionalparameterssd_Jsonclick = "";
         edtavAuthadditionalparameterssd_Enabled = 1;
         edtavAuthadditionalparameters_Jsonclick = "";
         edtavAuthadditionalparameters_Enabled = 1;
         chkavAuthredirurlinclude.Enabled = 1;
         chkavAuthclientsecretinclude.Enabled = 1;
         chkavAuthclientidinclude.Enabled = 1;
         edtavAuthstatetag_Jsonclick = "";
         edtavAuthstatetag_Enabled = 1;
         chkavAuthstateinclude.Enabled = 1;
         edtavAuthscopevalue_Jsonclick = "";
         edtavAuthscopevalue_Enabled = 1;
         edtavAuthscopetag_Jsonclick = "";
         edtavAuthscopetag_Enabled = 1;
         chkavAuthscopeinclude.Enabled = 1;
         edtavAuthresptypevalue_Jsonclick = "";
         edtavAuthresptypevalue_Enabled = 1;
         edtavAuthresptypetag_Jsonclick = "";
         edtavAuthresptypetag_Enabled = 1;
         chkavAuthresptypeinclude.Enabled = 1;
         edtavAuthorizeurl_Jsonclick = "";
         edtavAuthorizeurl_Enabled = 1;
         chkavOauth20redirecttoauthenticate.Enabled = 1;
         chkavOauth20redirecturl_autocompletevirtualdirectory.Enabled = 1;
         divTblautocompletevirtualdirectory_Visible = 1;
         chkavOauth20redirecturliscustom.TooltipText = "";
         chkavOauth20redirecturliscustom.Enabled = 1;
         edtavOauth20redirecturlvalue_Jsonclick = "";
         edtavOauth20redirecturlvalue_Enabled = 1;
         edtavOauth20redirecturltag_Jsonclick = "";
         edtavOauth20redirecturltag_Enabled = 1;
         edtavOauth20clientsecretvalue_Jsonclick = "";
         edtavOauth20clientsecretvalue_Enabled = 1;
         edtavOauth20clientsecrettag_Jsonclick = "";
         edtavOauth20clientsecrettag_Enabled = 1;
         edtavOauth20clientidvalue_Jsonclick = "";
         edtavOauth20clientidvalue_Enabled = 1;
         edtavOauth20clientidtag_Jsonclick = "";
         edtavOauth20clientidtag_Enabled = 1;
         edtavBigimagename_Jsonclick = "";
         edtavBigimagename_Enabled = 1;
         edtavSmallimagename_Jsonclick = "";
         edtavSmallimagename_Enabled = 1;
         cmbavImpersonate_Jsonclick = "";
         cmbavImpersonate.Enabled = 1;
         chkavIsenable.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         cmbavFunctionid_Jsonclick = "";
         cmbavFunctionid.Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 0;
         cmbavIdp_Jsonclick = "";
         cmbavIdp.Enabled = 1;
         cmbavIdp.Visible = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "Tab";
         Gxuitabspanel_tabs_Pagecount = 4;
         Dvpanel_unnamedtable3_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Iconposition = "Right";
         Dvpanel_unnamedtable3_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable3_Title = "Advanced configuration";
         Dvpanel_unnamedtable3_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable3_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable3_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Width = "100%";
         Dvpanel_unnamedtable5_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Iconposition = "Right";
         Dvpanel_unnamedtable5_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable5_Title = "Custom User Attributes";
         Dvpanel_unnamedtable5_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable5_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable5_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable5_Width = "100%";
         Dvpanel_unnamedtable4_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable4_Iconposition = "Right";
         Dvpanel_unnamedtable4_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable4_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable4_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable4_Title = "Response";
         Dvpanel_unnamedtable4_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable4_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable4_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable4_Width = "100%";
         Dvpanel_paneluserbody_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_paneluserbody_Iconposition = "Right";
         Dvpanel_paneluserbody_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_paneluserbody_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_paneluserbody_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_paneluserbody_Title = "Body";
         Dvpanel_paneluserbody_Cls = "PanelCard_GrayTitle";
         Dvpanel_paneluserbody_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_paneluserbody_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_paneluserbody_Width = "100%";
         Dvpanel_unnamedtable2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Iconposition = "Right";
         Dvpanel_unnamedtable2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable2_Title = "Header";
         Dvpanel_unnamedtable2_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable2_Width = "100%";
         Dvpanel_unnamedtable8_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Iconposition = "Right";
         Dvpanel_unnamedtable8_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_unnamedtable8_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable8_Title = "Advanced configuration";
         Dvpanel_unnamedtable8_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable8_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable8_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable8_Width = "100%";
         Dvpanel_unnamedtable11_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable11_Iconposition = "Right";
         Dvpanel_unnamedtable11_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable11_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable11_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable11_Title = "Refresh Token";
         Dvpanel_unnamedtable11_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable11_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable11_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable11_Width = "100%";
         Dvpanel_unnamedtable10_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable10_Iconposition = "Right";
         Dvpanel_unnamedtable10_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable10_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable10_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable10_Title = "Response";
         Dvpanel_unnamedtable10_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable10_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable10_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable10_Width = "100%";
         Dvpanel_unnamedtable9_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable9_Iconposition = "Right";
         Dvpanel_unnamedtable9_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable9_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable9_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable9_Title = "Body";
         Dvpanel_unnamedtable9_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable9_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable9_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable9_Width = "100%";
         Dvpanel_unnamedtable7_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Iconposition = "Right";
         Dvpanel_unnamedtable7_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable7_Title = "Header";
         Dvpanel_unnamedtable7_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable7_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable7_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable7_Width = "100%";
         Dvpanel_unnamedtable13_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable13_Iconposition = "Right";
         Dvpanel_unnamedtable13_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable13_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_unnamedtable13_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable13_Title = "Advanced configuration";
         Dvpanel_unnamedtable13_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable13_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable13_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable13_Width = "100%";
         Dvpanel_unnamedtable14_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable14_Iconposition = "Right";
         Dvpanel_unnamedtable14_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable14_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable14_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable14_Title = "Response";
         Dvpanel_unnamedtable14_Cls = "PanelCard_GrayTitle";
         Dvpanel_unnamedtable14_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable14_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable14_Width = "100%";
         Dvpanel_groupauthopenidconnecttable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_groupauthopenidconnecttable1_Iconposition = "Right";
         Dvpanel_groupauthopenidconnecttable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_groupauthopenidconnecttable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_groupauthopenidconnecttable1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_groupauthopenidconnecttable1_Title = "OpenID Connect";
         Dvpanel_groupauthopenidconnecttable1_Cls = "PanelCard_GrayTitle";
         Dvpanel_groupauthopenidconnecttable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_groupauthopenidconnecttable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_groupauthopenidconnecttable1_Width = "100%";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"sPrefix"},{"av":"AV33IsEnable","fld":"vISENABLE"},{"av":"AV40Oauth20RedirectURLisCustom","fld":"vOAUTH20REDIRECTURLISCUSTOM"},{"av":"AV111Oauth20RedirectURL_AutocompleteVirtualDirectory","fld":"vOAUTH20REDIRECTURL_AUTOCOMPLETEVIRTUALDIRECTORY"},{"av":"AV39Oauth20RedirectToAuthenticate","fld":"vOAUTH20REDIRECTTOAUTHENTICATE"},{"av":"AV14AuthRespTypeInclude","fld":"vAUTHRESPTYPEINCLUDE"},{"av":"AV17AuthScopeInclude","fld":"vAUTHSCOPEINCLUDE"},{"av":"AV98AuthStateInclude","fld":"vAUTHSTATEINCLUDE"},{"av":"AV7AuthClientIdInclude","fld":"vAUTHCLIENTIDINCLUDE"},{"av":"AV8AuthClientSecretInclude","fld":"vAUTHCLIENTSECRETINCLUDE"},{"av":"AV99AuthRedirURLInclude","fld":"vAUTHREDIRURLINCLUDE"},{"av":"AV109AuthOpenIDConnectProtocolEnable","fld":"vAUTHOPENIDCONNECTPROTOCOLENABLE"},{"av":"AV110AuthValidIdToken","fld":"vAUTHVALIDIDTOKEN"},{"av":"AV106AuthAllowOnlyUserEmailVerified","fld":"vAUTHALLOWONLYUSEREMAILVERIFIED"},{"av":"AV51TokenHeaderAuthenticationInclude","fld":"vTOKENHEADERAUTHENTICATIONINCLUDE"},{"av":"AV54TokenHeaderAuthorizationBasicInclude","fld":"vTOKENHEADERAUTHORIZATIONBASICINCLUDE"},{"av":"AV48TokenGrantTypeInclude","fld":"vTOKENGRANTTYPEINCLUDE"},{"av":"AV44TokenAccessCodeInclude","fld":"vTOKENACCESSCODEINCLUDE"},{"av":"AV46TokenCliIdInclude","fld":"vTOKENCLIIDINCLUDE"},{"av":"AV47TokenCliSecretInclude","fld":"vTOKENCLISECRETINCLUDE"},{"av":"AV58TokenRedirectURLInclude","fld":"vTOKENREDIRECTURLINCLUDE"},{"av":"AV22AutovalidateExternalTokenAndRefresh","fld":"vAUTOVALIDATEEXTERNALTOKENANDREFRESH"},{"av":"AV69UserInfoAccessTokenInclude","fld":"vUSERINFOACCESSTOKENINCLUDE"},{"av":"AV72UserInfoClientIdInclude","fld":"vUSERINFOCLIENTIDINCLUDE"},{"av":"AV74UserInfoClientSecretInclude","fld":"vUSERINFOCLIENTSECRETINCLUDE"},{"av":"AV95UserInfoUserIdInclude","fld":"vUSERINFOUSERIDINCLUDE"},{"av":"AV87UserInfoResponseUserLastNameGenAuto","fld":"vUSERINFORESPONSEUSERLASTNAMEGENAUTO"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E15142","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV24DeleteProperty","fld":"vDELETEPROPERTY"},{"av":"AV26DynamicPropName","fld":"vDYNAMICPROPNAME"},{"av":"AV27DynamicPropTag","fld":"vDYNAMICPROPTAG"},{"av":"edtavDeleteproperty_Visible","ctrl":"vDELETEPROPERTY","prop":"Visible"},{"av":"edtavDynamicpropname_Enabled","ctrl":"vDYNAMICPROPNAME","prop":"Enabled"},{"av":"edtavDynamicproptag_Enabled","ctrl":"vDYNAMICPROPTAG","prop":"Enabled"},{"av":"edtavDeleteproperty_Tooltiptext","ctrl":"vDELETEPROPERTY","prop":"Tooltiptext"}]}""");
         setEventMetadata("'DOADD'","""{"handler":"E11142","iparms":[]""");
         setEventMetadata("'DOADD'",""","oparms":[{"av":"AV24DeleteProperty","fld":"vDELETEPROPERTY"},{"av":"edtavDeleteproperty_Visible","ctrl":"vDELETEPROPERTY","prop":"Visible"},{"av":"edtavDynamicpropname_Enabled","ctrl":"vDYNAMICPROPNAME","prop":"Enabled"},{"av":"edtavDynamicpropname_Visible","ctrl":"vDYNAMICPROPNAME","prop":"Visible"},{"av":"edtavDynamicproptag_Enabled","ctrl":"vDYNAMICPROPTAG","prop":"Enabled"},{"av":"edtavDynamicproptag_Visible","ctrl":"vDYNAMICPROPTAG","prop":"Visible"}]}""");
         setEventMetadata("VIDP.CONTROLVALUECHANGED","""{"handler":"E12142","iparms":[{"av":"cmbavIdp"},{"av":"AV151IDP","fld":"vIDP"},{"av":"AV155NameInit","fld":"vNAMEINIT"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV34Name","fld":"vNAME"},{"av":"cmbavImpersonate"},{"av":"AV32Impersonate","fld":"vIMPERSONATE"},{"av":"AV87UserInfoResponseUserLastNameGenAuto","fld":"vUSERINFORESPONSEUSERLASTNAMEGENAUTO"},{"av":"AV109AuthOpenIDConnectProtocolEnable","fld":"vAUTHOPENIDCONNECTPROTOCOLENABLE"},{"av":"AV110AuthValidIdToken","fld":"vAUTHVALIDIDTOKEN"},{"av":"cmbavUserinfomethod"},{"av":"AV78UserInfoMethod","fld":"vUSERINFOMETHOD"},{"av":"AV40Oauth20RedirectURLisCustom","fld":"vOAUTH20REDIRECTURLISCUSTOM"}]""");
         setEventMetadata("VIDP.CONTROLVALUECHANGED",""","oparms":[{"av":"AV155NameInit","fld":"vNAMEINIT"},{"av":"AV34Name","fld":"vNAME"},{"av":"AV33IsEnable","fld":"vISENABLE"},{"av":"AV25Dsc","fld":"vDSC"},{"av":"AV43SmallImageName","fld":"vSMALLIMAGENAME"},{"av":"AV23BigImageName","fld":"vBIGIMAGENAME"},{"av":"cmbavImpersonate"},{"av":"AV32Impersonate","fld":"vIMPERSONATE"},{"av":"AV35Oauth20ClientIdTag","fld":"vOAUTH20CLIENTIDTAG"},{"av":"AV36Oauth20ClientIdValue","fld":"vOAUTH20CLIENTIDVALUE"},{"av":"AV37Oauth20ClientSecretTag","fld":"vOAUTH20CLIENTSECRETTAG"},{"av":"AV38Oauth20ClientSecretValue","fld":"vOAUTH20CLIENTSECRETVALUE"},{"av":"AV41Oauth20RedirectURLTag","fld":"vOAUTH20REDIRECTURLTAG"},{"av":"AV42Oauth20RedirectURLvalue","fld":"vOAUTH20REDIRECTURLVALUE"},{"av":"AV40Oauth20RedirectURLisCustom","fld":"vOAUTH20REDIRECTURLISCUSTOM"},{"av":"AV111Oauth20RedirectURL_AutocompleteVirtualDirectory","fld":"vOAUTH20REDIRECTURL_AUTOCOMPLETEVIRTUALDIRECTORY"},{"av":"AV39Oauth20RedirectToAuthenticate","fld":"vOAUTH20REDIRECTTOAUTHENTICATE"},{"av":"AV10AuthorizeURL","fld":"vAUTHORIZEURL"},{"av":"AV14AuthRespTypeInclude","fld":"vAUTHRESPTYPEINCLUDE"},{"av":"AV15AuthRespTypeTag","fld":"vAUTHRESPTYPETAG"},{"av":"AV16AuthRespTypeValue","fld":"vAUTHRESPTYPEVALUE"},{"av":"AV17AuthScopeInclude","fld":"vAUTHSCOPEINCLUDE"},{"av":"AV18AuthScopeTag","fld":"vAUTHSCOPETAG"},{"av":"AV19AuthScopeValue","fld":"vAUTHSCOPEVALUE"},{"av":"AV20AuthStateIncude","fld":"vAUTHSTATEINCUDE"},{"av":"AV21AuthStateTag","fld":"vAUTHSTATETAG"},{"av":"AV7AuthClientIdInclude","fld":"vAUTHCLIENTIDINCLUDE"},{"av":"AV8AuthClientSecretInclude","fld":"vAUTHCLIENTSECRETINCLUDE"},{"av":"AV99AuthRedirURLInclude","fld":"vAUTHREDIRURLINCLUDE"},{"av":"AV5AuthAdditionalParameters","fld":"vAUTHADDITIONALPARAMETERS"},{"av":"AV6AuthAdditionalParametersSD","fld":"vAUTHADDITIONALPARAMETERSSD"},{"av":"AV109AuthOpenIDConnectProtocolEnable","fld":"vAUTHOPENIDCONNECTPROTOCOLENABLE"},{"av":"AV110AuthValidIdToken","fld":"vAUTHVALIDIDTOKEN"},{"av":"AV107AuthCertificatePathFileName","fld":"vAUTHCERTIFICATEPATHFILENAME"},{"av":"AV108AuthIssuerURL","fld":"vAUTHISSUERURL"},{"av":"AV106AuthAllowOnlyUserEmailVerified","fld":"vAUTHALLOWONLYUSEREMAILVERIFIED"},{"av":"AV12AuthResponseAccessCodeTag","fld":"vAUTHRESPONSEACCESSCODETAG"},{"av":"AV13AuthResponseErrorDescTag","fld":"vAUTHRESPONSEERRORDESCTAG"},{"av":"AV67TokenURL","fld":"vTOKENURL"},{"av":"cmbavTokenmethod"},{"av":"AV57TokenMethod","fld":"vTOKENMETHOD"},{"av":"AV55TokenHeaderKeyTag","fld":"vTOKENHEADERKEYTAG"},{"av":"AV56TokenHeaderKeyValue","fld":"vTOKENHEADERKEYVALUE"},{"av":"AV51TokenHeaderAuthenticationInclude","fld":"vTOKENHEADERAUTHENTICATIONINCLUDE"},{"av":"cmbavTokenheaderauthenticationmethod"},{"av":"AV52TokenHeaderAuthenticationMethod","fld":"vTOKENHEADERAUTHENTICATIONMETHOD","pic":"ZZZ9"},{"av":"AV53TokenHeaderAuthenticationRealm","fld":"vTOKENHEADERAUTHENTICATIONREALM"},{"av":"AV54TokenHeaderAuthorizationBasicInclude","fld":"vTOKENHEADERAUTHORIZATIONBASICINCLUDE"},{"av":"AV48TokenGrantTypeInclude","fld":"vTOKENGRANTTYPEINCLUDE"},{"av":"AV49TokenGrantTypeTag","fld":"vTOKENGRANTTYPETAG"},{"av":"AV50TokenGrantTypeValue","fld":"vTOKENGRANTTYPEVALUE"},{"av":"AV44TokenAccessCodeInclude","fld":"vTOKENACCESSCODEINCLUDE"},{"av":"AV46TokenCliIdInclude","fld":"vTOKENCLIIDINCLUDE"},{"av":"AV47TokenCliSecretInclude","fld":"vTOKENCLISECRETINCLUDE"},{"av":"AV58TokenRedirectURLInclude","fld":"vTOKENREDIRECTURLINCLUDE"},{"av":"AV45TokenAdditionalParameters","fld":"vTOKENADDITIONALPARAMETERS"},{"av":"AV60TokenResponseAccessTokenTag","fld":"vTOKENRESPONSEACCESSTOKENTAG"},{"av":"AV65TokenResponseTokenTypeTag","fld":"vTOKENRESPONSETOKENTYPETAG"},{"av":"AV62TokenResponseExpiresInTag","fld":"vTOKENRESPONSEEXPIRESINTAG"},{"av":"AV64TokenResponseScopeTag","fld":"vTOKENRESPONSESCOPETAG"},{"av":"AV66TokenResponseUserIdTag","fld":"vTOKENRESPONSEUSERIDTAG"},{"av":"AV63TokenResponseRefreshTokenTag","fld":"vTOKENRESPONSEREFRESHTOKENTAG"},{"av":"AV61TokenResponseErrorDescriptionTag","fld":"vTOKENRESPONSEERRORDESCRIPTIONTAG"},{"av":"AV22AutovalidateExternalTokenAndRefresh","fld":"vAUTOVALIDATEEXTERNALTOKENANDREFRESH"},{"av":"AV59TokenRefreshTokenURL","fld":"vTOKENREFRESHTOKENURL"},{"av":"AV94UserInfoURL","fld":"vUSERINFOURL"},{"av":"cmbavUserinfomethod"},{"av":"AV78UserInfoMethod","fld":"vUSERINFOMETHOD"},{"av":"AV76UserInfoHeaderKeyTag","fld":"vUSERINFOHEADERKEYTAG"},{"av":"AV77UserInfoHeaderKeyValue","fld":"vUSERINFOHEADERKEYVALUE"},{"av":"AV69UserInfoAccessTokenInclude","fld":"vUSERINFOACCESSTOKENINCLUDE"},{"av":"AV70UserInfoAccessTokenName","fld":"vUSERINFOACCESSTOKENNAME"},{"av":"AV72UserInfoClientIdInclude","fld":"vUSERINFOCLIENTIDINCLUDE"},{"av":"AV73UserInfoClientIdName","fld":"vUSERINFOCLIENTIDNAME"},{"av":"AV74UserInfoClientSecretInclude","fld":"vUSERINFOCLIENTSECRETINCLUDE"},{"av":"AV75UserInfoClientSecretName","fld":"vUSERINFOCLIENTSECRETNAME"},{"av":"AV95UserInfoUserIdInclude","fld":"vUSERINFOUSERIDINCLUDE"},{"av":"AV71UserInfoAdditionalParameters","fld":"vUSERINFOADDITIONALPARAMETERS"},{"av":"AV81UserInfoResponseUserEmailTag","fld":"vUSERINFORESPONSEUSEREMAILTAG"},{"av":"AV93UserInfoResponseUserVerifiedEmailTag","fld":"vUSERINFORESPONSEUSERVERIFIEDEMAILTAG"},{"av":"AV82UserInfoResponseUserExternalIdTag","fld":"vUSERINFORESPONSEUSEREXTERNALIDTAG"},{"av":"AV89UserInfoResponseUserNameTag","fld":"vUSERINFORESPONSEUSERNAMETAG"},{"av":"AV83UserInfoResponseUserFirstNameTag","fld":"vUSERINFORESPONSEUSERFIRSTNAMETAG"},{"av":"AV87UserInfoResponseUserLastNameGenAuto","fld":"vUSERINFORESPONSEUSERLASTNAMEGENAUTO"},{"av":"AV88UserInfoResponseUserLastNameTag","fld":"vUSERINFORESPONSEUSERLASTNAMETAG"},{"av":"AV84UserInfoResponseUserGenderTag","fld":"vUSERINFORESPONSEUSERGENDERTAG"},{"av":"AV85UserInfoResponseUserGenderValues","fld":"vUSERINFORESPONSEUSERGENDERVALUES"},{"av":"AV80UserInfoResponseUserBirthdayTag","fld":"vUSERINFORESPONSEUSERBIRTHDAYTAG"},{"av":"AV91UserInfoResponseUserURLImageTag","fld":"vUSERINFORESPONSEUSERURLIMAGETAG"},{"av":"AV92UserInfoResponseUserURLProfileTag","fld":"vUSERINFORESPONSEUSERURLPROFILETAG"},{"av":"AV86UserInfoResponseUserLanguageTag","fld":"vUSERINFORESPONSEUSERLANGUAGETAG"},{"av":"AV90UserInfoResponseUserTimeZoneTag","fld":"vUSERINFORESPONSEUSERTIMEZONETAG"},{"av":"AV79UserInfoResponseErrorDescriptionTag","fld":"vUSERINFORESPONSEERRORDESCRIPTIONTAG"},{"av":"cmbavFunctionid"},{"av":"AV30FunctionId","fld":"vFUNCTIONID"},{"av":"edtavUserinforesponseuserlastnametag_Visible","ctrl":"vUSERINFORESPONSEUSERLASTNAMETAG","prop":"Visible"},{"av":"lblTbuserlastnamehelp_Caption","ctrl":"TBUSERLASTNAMEHELP","prop":"Caption"},{"av":"divTbl_openidconnect_Visible","ctrl":"TBL_OPENIDCONNECT","prop":"Visible"},{"av":"divTbl_valididtoken_Visible","ctrl":"TBL_VALIDIDTOKEN","prop":"Visible"},{"av":"Dvpanel_paneluserbody_Title","ctrl":"DVPANEL_PANELUSERBODY","prop":"Title"},{"av":"edtavUserinfoadditionalparameters_Visible","ctrl":"vUSERINFOADDITIONALPARAMETERS","prop":"Visible"},{"av":"divTblautocompletevirtualdirectory_Visible","ctrl":"TBLAUTOCOMPLETEVIRTUALDIRECTORY","prop":"Visible"}]}""");
         setEventMetadata("VDELETEPROPERTY.CLICK","""{"handler":"E16142","iparms":[{"av":"AV34Name","fld":"vNAME"}]""");
         setEventMetadata("VDELETEPROPERTY.CLICK",""","oparms":[{"av":"AV24DeleteProperty","fld":"vDELETEPROPERTY"},{"av":"edtavDeleteproperty_Visible","ctrl":"vDELETEPROPERTY","prop":"Visible"},{"av":"edtavDynamicpropname_Visible","ctrl":"vDYNAMICPROPNAME","prop":"Visible"},{"av":"edtavDynamicproptag_Visible","ctrl":"vDYNAMICPROPTAG","prop":"Visible"},{"av":"AV26DynamicPropName","fld":"vDYNAMICPROPNAME"},{"av":"AV27DynamicPropTag","fld":"vDYNAMICPROPTAG"}]}""");
         setEventMetadata("ENTER","""{"handler":"E13142","iparms":[{"av":"AV105CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV34Name","fld":"vNAME"},{"av":"AV33IsEnable","fld":"vISENABLE"},{"av":"AV25Dsc","fld":"vDSC"},{"av":"AV43SmallImageName","fld":"vSMALLIMAGENAME"},{"av":"AV23BigImageName","fld":"vBIGIMAGENAME"},{"av":"cmbavImpersonate"},{"av":"AV32Impersonate","fld":"vIMPERSONATE"},{"av":"AV35Oauth20ClientIdTag","fld":"vOAUTH20CLIENTIDTAG"},{"av":"AV36Oauth20ClientIdValue","fld":"vOAUTH20CLIENTIDVALUE"},{"av":"AV37Oauth20ClientSecretTag","fld":"vOAUTH20CLIENTSECRETTAG"},{"av":"AV38Oauth20ClientSecretValue","fld":"vOAUTH20CLIENTSECRETVALUE"},{"av":"AV41Oauth20RedirectURLTag","fld":"vOAUTH20REDIRECTURLTAG"},{"av":"AV42Oauth20RedirectURLvalue","fld":"vOAUTH20REDIRECTURLVALUE"},{"av":"AV40Oauth20RedirectURLisCustom","fld":"vOAUTH20REDIRECTURLISCUSTOM"},{"av":"AV111Oauth20RedirectURL_AutocompleteVirtualDirectory","fld":"vOAUTH20REDIRECTURL_AUTOCOMPLETEVIRTUALDIRECTORY"},{"av":"AV39Oauth20RedirectToAuthenticate","fld":"vOAUTH20REDIRECTTOAUTHENTICATE"},{"av":"AV10AuthorizeURL","fld":"vAUTHORIZEURL"},{"av":"AV14AuthRespTypeInclude","fld":"vAUTHRESPTYPEINCLUDE"},{"av":"AV15AuthRespTypeTag","fld":"vAUTHRESPTYPETAG"},{"av":"AV16AuthRespTypeValue","fld":"vAUTHRESPTYPEVALUE"},{"av":"AV17AuthScopeInclude","fld":"vAUTHSCOPEINCLUDE"},{"av":"AV18AuthScopeTag","fld":"vAUTHSCOPETAG"},{"av":"AV19AuthScopeValue","fld":"vAUTHSCOPEVALUE"},{"av":"AV20AuthStateIncude","fld":"vAUTHSTATEINCUDE"},{"av":"AV21AuthStateTag","fld":"vAUTHSTATETAG"},{"av":"AV7AuthClientIdInclude","fld":"vAUTHCLIENTIDINCLUDE"},{"av":"AV8AuthClientSecretInclude","fld":"vAUTHCLIENTSECRETINCLUDE"},{"av":"AV99AuthRedirURLInclude","fld":"vAUTHREDIRURLINCLUDE"},{"av":"AV5AuthAdditionalParameters","fld":"vAUTHADDITIONALPARAMETERS"},{"av":"AV6AuthAdditionalParametersSD","fld":"vAUTHADDITIONALPARAMETERSSD"},{"av":"AV109AuthOpenIDConnectProtocolEnable","fld":"vAUTHOPENIDCONNECTPROTOCOLENABLE"},{"av":"AV110AuthValidIdToken","fld":"vAUTHVALIDIDTOKEN"},{"av":"AV107AuthCertificatePathFileName","fld":"vAUTHCERTIFICATEPATHFILENAME"},{"av":"AV108AuthIssuerURL","fld":"vAUTHISSUERURL"},{"av":"AV106AuthAllowOnlyUserEmailVerified","fld":"vAUTHALLOWONLYUSEREMAILVERIFIED"},{"av":"AV12AuthResponseAccessCodeTag","fld":"vAUTHRESPONSEACCESSCODETAG"},{"av":"AV13AuthResponseErrorDescTag","fld":"vAUTHRESPONSEERRORDESCTAG"},{"av":"AV67TokenURL","fld":"vTOKENURL"},{"av":"cmbavTokenmethod"},{"av":"AV57TokenMethod","fld":"vTOKENMETHOD"},{"av":"AV55TokenHeaderKeyTag","fld":"vTOKENHEADERKEYTAG"},{"av":"AV56TokenHeaderKeyValue","fld":"vTOKENHEADERKEYVALUE"},{"av":"AV51TokenHeaderAuthenticationInclude","fld":"vTOKENHEADERAUTHENTICATIONINCLUDE"},{"av":"cmbavTokenheaderauthenticationmethod"},{"av":"AV52TokenHeaderAuthenticationMethod","fld":"vTOKENHEADERAUTHENTICATIONMETHOD","pic":"ZZZ9"},{"av":"AV53TokenHeaderAuthenticationRealm","fld":"vTOKENHEADERAUTHENTICATIONREALM"},{"av":"AV54TokenHeaderAuthorizationBasicInclude","fld":"vTOKENHEADERAUTHORIZATIONBASICINCLUDE"},{"av":"AV48TokenGrantTypeInclude","fld":"vTOKENGRANTTYPEINCLUDE"},{"av":"AV49TokenGrantTypeTag","fld":"vTOKENGRANTTYPETAG"},{"av":"AV50TokenGrantTypeValue","fld":"vTOKENGRANTTYPEVALUE"},{"av":"AV44TokenAccessCodeInclude","fld":"vTOKENACCESSCODEINCLUDE"},{"av":"AV46TokenCliIdInclude","fld":"vTOKENCLIIDINCLUDE"},{"av":"AV47TokenCliSecretInclude","fld":"vTOKENCLISECRETINCLUDE"},{"av":"AV58TokenRedirectURLInclude","fld":"vTOKENREDIRECTURLINCLUDE"},{"av":"AV45TokenAdditionalParameters","fld":"vTOKENADDITIONALPARAMETERS"},{"av":"AV60TokenResponseAccessTokenTag","fld":"vTOKENRESPONSEACCESSTOKENTAG"},{"av":"AV65TokenResponseTokenTypeTag","fld":"vTOKENRESPONSETOKENTYPETAG"},{"av":"AV62TokenResponseExpiresInTag","fld":"vTOKENRESPONSEEXPIRESINTAG"},{"av":"AV64TokenResponseScopeTag","fld":"vTOKENRESPONSESCOPETAG"},{"av":"AV66TokenResponseUserIdTag","fld":"vTOKENRESPONSEUSERIDTAG"},{"av":"AV63TokenResponseRefreshTokenTag","fld":"vTOKENRESPONSEREFRESHTOKENTAG"},{"av":"AV61TokenResponseErrorDescriptionTag","fld":"vTOKENRESPONSEERRORDESCRIPTIONTAG"},{"av":"AV22AutovalidateExternalTokenAndRefresh","fld":"vAUTOVALIDATEEXTERNALTOKENANDREFRESH"},{"av":"AV59TokenRefreshTokenURL","fld":"vTOKENREFRESHTOKENURL"},{"av":"AV94UserInfoURL","fld":"vUSERINFOURL"},{"av":"cmbavUserinfomethod"},{"av":"AV78UserInfoMethod","fld":"vUSERINFOMETHOD"},{"av":"AV76UserInfoHeaderKeyTag","fld":"vUSERINFOHEADERKEYTAG"},{"av":"AV77UserInfoHeaderKeyValue","fld":"vUSERINFOHEADERKEYVALUE"},{"av":"AV69UserInfoAccessTokenInclude","fld":"vUSERINFOACCESSTOKENINCLUDE"},{"av":"AV70UserInfoAccessTokenName","fld":"vUSERINFOACCESSTOKENNAME"},{"av":"AV72UserInfoClientIdInclude","fld":"vUSERINFOCLIENTIDINCLUDE"},{"av":"AV73UserInfoClientIdName","fld":"vUSERINFOCLIENTIDNAME"},{"av":"AV74UserInfoClientSecretInclude","fld":"vUSERINFOCLIENTSECRETINCLUDE"},{"av":"AV75UserInfoClientSecretName","fld":"vUSERINFOCLIENTSECRETNAME"},{"av":"AV95UserInfoUserIdInclude","fld":"vUSERINFOUSERIDINCLUDE"},{"av":"AV71UserInfoAdditionalParameters","fld":"vUSERINFOADDITIONALPARAMETERS"},{"av":"AV81UserInfoResponseUserEmailTag","fld":"vUSERINFORESPONSEUSEREMAILTAG"},{"av":"AV93UserInfoResponseUserVerifiedEmailTag","fld":"vUSERINFORESPONSEUSERVERIFIEDEMAILTAG"},{"av":"AV82UserInfoResponseUserExternalIdTag","fld":"vUSERINFORESPONSEUSEREXTERNALIDTAG"},{"av":"AV89UserInfoResponseUserNameTag","fld":"vUSERINFORESPONSEUSERNAMETAG"},{"av":"AV83UserInfoResponseUserFirstNameTag","fld":"vUSERINFORESPONSEUSERFIRSTNAMETAG"},{"av":"AV87UserInfoResponseUserLastNameGenAuto","fld":"vUSERINFORESPONSEUSERLASTNAMEGENAUTO"},{"av":"AV88UserInfoResponseUserLastNameTag","fld":"vUSERINFORESPONSEUSERLASTNAMETAG"},{"av":"AV84UserInfoResponseUserGenderTag","fld":"vUSERINFORESPONSEUSERGENDERTAG"},{"av":"AV85UserInfoResponseUserGenderValues","fld":"vUSERINFORESPONSEUSERGENDERVALUES"},{"av":"AV80UserInfoResponseUserBirthdayTag","fld":"vUSERINFORESPONSEUSERBIRTHDAYTAG"},{"av":"AV91UserInfoResponseUserURLImageTag","fld":"vUSERINFORESPONSEUSERURLIMAGETAG"},{"av":"AV92UserInfoResponseUserURLProfileTag","fld":"vUSERINFORESPONSEUSERURLPROFILETAG"},{"av":"AV86UserInfoResponseUserLanguageTag","fld":"vUSERINFORESPONSEUSERLANGUAGETAG"},{"av":"AV90UserInfoResponseUserTimeZoneTag","fld":"vUSERINFORESPONSEUSERTIMEZONETAG"},{"av":"AV79UserInfoResponseErrorDescriptionTag","fld":"vUSERINFORESPONSEERRORDESCRIPTIONTAG"},{"av":"AV26DynamicPropName","fld":"vDYNAMICPROPNAME","grid":548},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_548","ctrl":"GRID","grid":548,"prop":"GridRC","grid":548},{"av":"AV27DynamicPropTag","fld":"vDYNAMICPROPTAG","grid":548}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV105CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"sPrefix"},{"av":"AV33IsEnable","fld":"vISENABLE"},{"av":"AV40Oauth20RedirectURLisCustom","fld":"vOAUTH20REDIRECTURLISCUSTOM"},{"av":"AV111Oauth20RedirectURL_AutocompleteVirtualDirectory","fld":"vOAUTH20REDIRECTURL_AUTOCOMPLETEVIRTUALDIRECTORY"},{"av":"AV39Oauth20RedirectToAuthenticate","fld":"vOAUTH20REDIRECTTOAUTHENTICATE"},{"av":"AV14AuthRespTypeInclude","fld":"vAUTHRESPTYPEINCLUDE"},{"av":"AV17AuthScopeInclude","fld":"vAUTHSCOPEINCLUDE"},{"av":"AV98AuthStateInclude","fld":"vAUTHSTATEINCLUDE"},{"av":"AV7AuthClientIdInclude","fld":"vAUTHCLIENTIDINCLUDE"},{"av":"AV8AuthClientSecretInclude","fld":"vAUTHCLIENTSECRETINCLUDE"},{"av":"AV99AuthRedirURLInclude","fld":"vAUTHREDIRURLINCLUDE"},{"av":"AV109AuthOpenIDConnectProtocolEnable","fld":"vAUTHOPENIDCONNECTPROTOCOLENABLE"},{"av":"AV110AuthValidIdToken","fld":"vAUTHVALIDIDTOKEN"},{"av":"AV106AuthAllowOnlyUserEmailVerified","fld":"vAUTHALLOWONLYUSEREMAILVERIFIED"},{"av":"AV51TokenHeaderAuthenticationInclude","fld":"vTOKENHEADERAUTHENTICATIONINCLUDE"},{"av":"AV54TokenHeaderAuthorizationBasicInclude","fld":"vTOKENHEADERAUTHORIZATIONBASICINCLUDE"},{"av":"AV48TokenGrantTypeInclude","fld":"vTOKENGRANTTYPEINCLUDE"},{"av":"AV44TokenAccessCodeInclude","fld":"vTOKENACCESSCODEINCLUDE"},{"av":"AV46TokenCliIdInclude","fld":"vTOKENCLIIDINCLUDE"},{"av":"AV47TokenCliSecretInclude","fld":"vTOKENCLISECRETINCLUDE"},{"av":"AV58TokenRedirectURLInclude","fld":"vTOKENREDIRECTURLINCLUDE"},{"av":"AV22AutovalidateExternalTokenAndRefresh","fld":"vAUTOVALIDATEEXTERNALTOKENANDREFRESH"},{"av":"AV69UserInfoAccessTokenInclude","fld":"vUSERINFOACCESSTOKENINCLUDE"},{"av":"AV72UserInfoClientIdInclude","fld":"vUSERINFOCLIENTIDINCLUDE"},{"av":"AV74UserInfoClientSecretInclude","fld":"vUSERINFOCLIENTSECRETINCLUDE"},{"av":"AV95UserInfoUserIdInclude","fld":"vUSERINFOUSERIDINCLUDE"},{"av":"AV87UserInfoResponseUserLastNameGenAuto","fld":"vUSERINFORESPONSEUSERLASTNAMEGENAUTO"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"sPrefix"},{"av":"AV33IsEnable","fld":"vISENABLE"},{"av":"AV40Oauth20RedirectURLisCustom","fld":"vOAUTH20REDIRECTURLISCUSTOM"},{"av":"AV111Oauth20RedirectURL_AutocompleteVirtualDirectory","fld":"vOAUTH20REDIRECTURL_AUTOCOMPLETEVIRTUALDIRECTORY"},{"av":"AV39Oauth20RedirectToAuthenticate","fld":"vOAUTH20REDIRECTTOAUTHENTICATE"},{"av":"AV14AuthRespTypeInclude","fld":"vAUTHRESPTYPEINCLUDE"},{"av":"AV17AuthScopeInclude","fld":"vAUTHSCOPEINCLUDE"},{"av":"AV98AuthStateInclude","fld":"vAUTHSTATEINCLUDE"},{"av":"AV7AuthClientIdInclude","fld":"vAUTHCLIENTIDINCLUDE"},{"av":"AV8AuthClientSecretInclude","fld":"vAUTHCLIENTSECRETINCLUDE"},{"av":"AV99AuthRedirURLInclude","fld":"vAUTHREDIRURLINCLUDE"},{"av":"AV109AuthOpenIDConnectProtocolEnable","fld":"vAUTHOPENIDCONNECTPROTOCOLENABLE"},{"av":"AV110AuthValidIdToken","fld":"vAUTHVALIDIDTOKEN"},{"av":"AV106AuthAllowOnlyUserEmailVerified","fld":"vAUTHALLOWONLYUSEREMAILVERIFIED"},{"av":"AV51TokenHeaderAuthenticationInclude","fld":"vTOKENHEADERAUTHENTICATIONINCLUDE"},{"av":"AV54TokenHeaderAuthorizationBasicInclude","fld":"vTOKENHEADERAUTHORIZATIONBASICINCLUDE"},{"av":"AV48TokenGrantTypeInclude","fld":"vTOKENGRANTTYPEINCLUDE"},{"av":"AV44TokenAccessCodeInclude","fld":"vTOKENACCESSCODEINCLUDE"},{"av":"AV46TokenCliIdInclude","fld":"vTOKENCLIIDINCLUDE"},{"av":"AV47TokenCliSecretInclude","fld":"vTOKENCLISECRETINCLUDE"},{"av":"AV58TokenRedirectURLInclude","fld":"vTOKENREDIRECTURLINCLUDE"},{"av":"AV22AutovalidateExternalTokenAndRefresh","fld":"vAUTOVALIDATEEXTERNALTOKENANDREFRESH"},{"av":"AV69UserInfoAccessTokenInclude","fld":"vUSERINFOACCESSTOKENINCLUDE"},{"av":"AV72UserInfoClientIdInclude","fld":"vUSERINFOCLIENTIDINCLUDE"},{"av":"AV74UserInfoClientSecretInclude","fld":"vUSERINFOCLIENTSECRETINCLUDE"},{"av":"AV95UserInfoUserIdInclude","fld":"vUSERINFOUSERIDINCLUDE"},{"av":"AV87UserInfoResponseUserLastNameGenAuto","fld":"vUSERINFORESPONSEUSERLASTNAMEGENAUTO"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"sPrefix"},{"av":"AV33IsEnable","fld":"vISENABLE"},{"av":"AV40Oauth20RedirectURLisCustom","fld":"vOAUTH20REDIRECTURLISCUSTOM"},{"av":"AV111Oauth20RedirectURL_AutocompleteVirtualDirectory","fld":"vOAUTH20REDIRECTURL_AUTOCOMPLETEVIRTUALDIRECTORY"},{"av":"AV39Oauth20RedirectToAuthenticate","fld":"vOAUTH20REDIRECTTOAUTHENTICATE"},{"av":"AV14AuthRespTypeInclude","fld":"vAUTHRESPTYPEINCLUDE"},{"av":"AV17AuthScopeInclude","fld":"vAUTHSCOPEINCLUDE"},{"av":"AV98AuthStateInclude","fld":"vAUTHSTATEINCLUDE"},{"av":"AV7AuthClientIdInclude","fld":"vAUTHCLIENTIDINCLUDE"},{"av":"AV8AuthClientSecretInclude","fld":"vAUTHCLIENTSECRETINCLUDE"},{"av":"AV99AuthRedirURLInclude","fld":"vAUTHREDIRURLINCLUDE"},{"av":"AV109AuthOpenIDConnectProtocolEnable","fld":"vAUTHOPENIDCONNECTPROTOCOLENABLE"},{"av":"AV110AuthValidIdToken","fld":"vAUTHVALIDIDTOKEN"},{"av":"AV106AuthAllowOnlyUserEmailVerified","fld":"vAUTHALLOWONLYUSEREMAILVERIFIED"},{"av":"AV51TokenHeaderAuthenticationInclude","fld":"vTOKENHEADERAUTHENTICATIONINCLUDE"},{"av":"AV54TokenHeaderAuthorizationBasicInclude","fld":"vTOKENHEADERAUTHORIZATIONBASICINCLUDE"},{"av":"AV48TokenGrantTypeInclude","fld":"vTOKENGRANTTYPEINCLUDE"},{"av":"AV44TokenAccessCodeInclude","fld":"vTOKENACCESSCODEINCLUDE"},{"av":"AV46TokenCliIdInclude","fld":"vTOKENCLIIDINCLUDE"},{"av":"AV47TokenCliSecretInclude","fld":"vTOKENCLISECRETINCLUDE"},{"av":"AV58TokenRedirectURLInclude","fld":"vTOKENREDIRECTURLINCLUDE"},{"av":"AV22AutovalidateExternalTokenAndRefresh","fld":"vAUTOVALIDATEEXTERNALTOKENANDREFRESH"},{"av":"AV69UserInfoAccessTokenInclude","fld":"vUSERINFOACCESSTOKENINCLUDE"},{"av":"AV72UserInfoClientIdInclude","fld":"vUSERINFOCLIENTIDINCLUDE"},{"av":"AV74UserInfoClientSecretInclude","fld":"vUSERINFOCLIENTSECRETINCLUDE"},{"av":"AV95UserInfoUserIdInclude","fld":"vUSERINFOUSERIDINCLUDE"},{"av":"AV87UserInfoResponseUserLastNameGenAuto","fld":"vUSERINFORESPONSEUSERLASTNAMEGENAUTO"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"sPrefix"},{"av":"AV33IsEnable","fld":"vISENABLE"},{"av":"AV40Oauth20RedirectURLisCustom","fld":"vOAUTH20REDIRECTURLISCUSTOM"},{"av":"AV111Oauth20RedirectURL_AutocompleteVirtualDirectory","fld":"vOAUTH20REDIRECTURL_AUTOCOMPLETEVIRTUALDIRECTORY"},{"av":"AV39Oauth20RedirectToAuthenticate","fld":"vOAUTH20REDIRECTTOAUTHENTICATE"},{"av":"AV14AuthRespTypeInclude","fld":"vAUTHRESPTYPEINCLUDE"},{"av":"AV17AuthScopeInclude","fld":"vAUTHSCOPEINCLUDE"},{"av":"AV98AuthStateInclude","fld":"vAUTHSTATEINCLUDE"},{"av":"AV7AuthClientIdInclude","fld":"vAUTHCLIENTIDINCLUDE"},{"av":"AV8AuthClientSecretInclude","fld":"vAUTHCLIENTSECRETINCLUDE"},{"av":"AV99AuthRedirURLInclude","fld":"vAUTHREDIRURLINCLUDE"},{"av":"AV109AuthOpenIDConnectProtocolEnable","fld":"vAUTHOPENIDCONNECTPROTOCOLENABLE"},{"av":"AV110AuthValidIdToken","fld":"vAUTHVALIDIDTOKEN"},{"av":"AV106AuthAllowOnlyUserEmailVerified","fld":"vAUTHALLOWONLYUSEREMAILVERIFIED"},{"av":"AV51TokenHeaderAuthenticationInclude","fld":"vTOKENHEADERAUTHENTICATIONINCLUDE"},{"av":"AV54TokenHeaderAuthorizationBasicInclude","fld":"vTOKENHEADERAUTHORIZATIONBASICINCLUDE"},{"av":"AV48TokenGrantTypeInclude","fld":"vTOKENGRANTTYPEINCLUDE"},{"av":"AV44TokenAccessCodeInclude","fld":"vTOKENACCESSCODEINCLUDE"},{"av":"AV46TokenCliIdInclude","fld":"vTOKENCLIIDINCLUDE"},{"av":"AV47TokenCliSecretInclude","fld":"vTOKENCLISECRETINCLUDE"},{"av":"AV58TokenRedirectURLInclude","fld":"vTOKENREDIRECTURLINCLUDE"},{"av":"AV22AutovalidateExternalTokenAndRefresh","fld":"vAUTOVALIDATEEXTERNALTOKENANDREFRESH"},{"av":"AV69UserInfoAccessTokenInclude","fld":"vUSERINFOACCESSTOKENINCLUDE"},{"av":"AV72UserInfoClientIdInclude","fld":"vUSERINFOCLIENTIDINCLUDE"},{"av":"AV74UserInfoClientSecretInclude","fld":"vUSERINFOCLIENTSECRETINCLUDE"},{"av":"AV95UserInfoUserIdInclude","fld":"vUSERINFOUSERIDINCLUDE"},{"av":"AV87UserInfoResponseUserLastNameGenAuto","fld":"vUSERINFORESPONSEUSERLASTNAMEGENAUTO"},{"av":"subGrid_Recordcount"}]}""");
         setEventMetadata("VALIDV_IDP","""{"handler":"Validv_Idp","iparms":[]}""");
         setEventMetadata("VALIDV_FUNCTIONID","""{"handler":"Validv_Functionid","iparms":[]}""");
         setEventMetadata("VALIDV_TOKENMETHOD","""{"handler":"Validv_Tokenmethod","iparms":[]}""");
         setEventMetadata("VALIDV_TOKENHEADERAUTHENTICATIONMETHOD","""{"handler":"Validv_Tokenheaderauthenticationmethod","iparms":[]}""");
         setEventMetadata("VALIDV_USERINFOMETHOD","""{"handler":"Validv_Userinfomethod","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Deleteproperty","iparms":[]}""");
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
         wcpOAV34Name = "";
         wcpOAV68TypeId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV155NameInit = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV151IDP = "";
         AV30FunctionId = "";
         AV25Dsc = "";
         AV32Impersonate = "";
         AV43SmallImageName = "";
         AV23BigImageName = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         AV35Oauth20ClientIdTag = "";
         AV36Oauth20ClientIdValue = "";
         AV37Oauth20ClientSecretTag = "";
         AV38Oauth20ClientSecretValue = "";
         AV41Oauth20RedirectURLTag = "";
         AV42Oauth20RedirectURLvalue = "";
         lblTbhelpcustomredirect_Jsonclick = "";
         lblTbhelpautocompletevirtualdirectory_Jsonclick = "";
         lblTbhelp0redirecttoauthenticate_Jsonclick = "";
         lblAuthorization_title_Jsonclick = "";
         AV10AuthorizeURL = "";
         ucDvpanel_unnamedtable13 = new GXUserControl();
         AV15AuthRespTypeTag = "";
         AV16AuthRespTypeValue = "";
         AV18AuthScopeTag = "";
         AV19AuthScopeValue = "";
         AV21AuthStateTag = "";
         AV5AuthAdditionalParameters = "";
         AV6AuthAdditionalParametersSD = "";
         ucDvpanel_groupauthopenidconnecttable1 = new GXUserControl();
         AV108AuthIssuerURL = "";
         AV107AuthCertificatePathFileName = "";
         ucDvpanel_unnamedtable14 = new GXUserControl();
         AV12AuthResponseAccessCodeTag = "";
         AV13AuthResponseErrorDescTag = "";
         lblToken_title_Jsonclick = "";
         AV67TokenURL = "";
         AV57TokenMethod = "";
         ucDvpanel_unnamedtable7 = new GXUserControl();
         AV55TokenHeaderKeyTag = "";
         AV56TokenHeaderKeyValue = "";
         AV53TokenHeaderAuthenticationRealm = "";
         ucDvpanel_unnamedtable8 = new GXUserControl();
         ucDvpanel_unnamedtable9 = new GXUserControl();
         AV49TokenGrantTypeTag = "";
         AV50TokenGrantTypeValue = "";
         AV45TokenAdditionalParameters = "";
         ucDvpanel_unnamedtable10 = new GXUserControl();
         AV60TokenResponseAccessTokenTag = "";
         AV65TokenResponseTokenTypeTag = "";
         AV62TokenResponseExpiresInTag = "";
         AV64TokenResponseScopeTag = "";
         AV66TokenResponseUserIdTag = "";
         AV63TokenResponseRefreshTokenTag = "";
         AV61TokenResponseErrorDescriptionTag = "";
         ucDvpanel_unnamedtable11 = new GXUserControl();
         AV59TokenRefreshTokenURL = "";
         lblUserinfo_title_Jsonclick = "";
         AV94UserInfoURL = "";
         AV78UserInfoMethod = "";
         ucDvpanel_unnamedtable2 = new GXUserControl();
         AV76UserInfoHeaderKeyTag = "";
         AV77UserInfoHeaderKeyValue = "";
         ucDvpanel_unnamedtable3 = new GXUserControl();
         ucDvpanel_paneluserbody = new GXUserControl();
         AV70UserInfoAccessTokenName = "";
         AV73UserInfoClientIdName = "";
         AV75UserInfoClientSecretName = "";
         AV71UserInfoAdditionalParameters = "";
         ucDvpanel_unnamedtable4 = new GXUserControl();
         AV81UserInfoResponseUserEmailTag = "";
         AV93UserInfoResponseUserVerifiedEmailTag = "";
         AV82UserInfoResponseUserExternalIdTag = "";
         AV89UserInfoResponseUserNameTag = "";
         AV83UserInfoResponseUserFirstNameTag = "";
         lblTbuserlastnamehelp_Jsonclick = "";
         AV88UserInfoResponseUserLastNameTag = "";
         AV84UserInfoResponseUserGenderTag = "";
         AV85UserInfoResponseUserGenderValues = "";
         AV80UserInfoResponseUserBirthdayTag = "";
         AV91UserInfoResponseUserURLImageTag = "";
         AV92UserInfoResponseUserURLProfileTag = "";
         AV86UserInfoResponseUserLanguageTag = "";
         AV90UserInfoResponseUserTimeZoneTag = "";
         AV79UserInfoResponseErrorDescriptionTag = "";
         ucDvpanel_unnamedtable5 = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtnadd_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV26DynamicPropName = "";
         AV27DynamicPropTag = "";
         AV24DeleteProperty = "";
         AV221Deleteproperty_GXI = "";
         AV9AuthenticationTypeOauth20 = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20(context);
         AV31GAMPropertySimple = new GeneXus.Programs.genexussecurity.SdtGAMPropertySimple(context);
         GridRow = new GXWebRow();
         AV29Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV28Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV224GXV3 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType", "GeneXus.Programs");
         AV218GAMAuthenticationTypeFilter = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter(context);
         AV122AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV34Name = "";
         sCtrlAV68TypeId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamwcauthenticationtypeentryoauth20__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamwcauthenticationtypeentryoauth20__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short AV52TokenHeaderAuthenticationMethod ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_548 ;
      private int subGrid_Recordcount ;
      private int subGrid_Rows ;
      private int nGXsfl_548_idx=1 ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavSmallimagename_Enabled ;
      private int edtavBigimagename_Enabled ;
      private int edtavOauth20clientidtag_Enabled ;
      private int edtavOauth20clientidvalue_Enabled ;
      private int edtavOauth20clientsecrettag_Enabled ;
      private int edtavOauth20clientsecretvalue_Enabled ;
      private int edtavOauth20redirecturltag_Enabled ;
      private int edtavOauth20redirecturlvalue_Enabled ;
      private int divTblautocompletevirtualdirectory_Visible ;
      private int edtavAuthorizeurl_Enabled ;
      private int edtavAuthresptypetag_Enabled ;
      private int edtavAuthresptypevalue_Enabled ;
      private int edtavAuthscopetag_Enabled ;
      private int edtavAuthscopevalue_Enabled ;
      private int edtavAuthstatetag_Enabled ;
      private int edtavAuthadditionalparameters_Enabled ;
      private int edtavAuthadditionalparameterssd_Enabled ;
      private int divTbl_openidconnect_Visible ;
      private int divTbl_valididtoken_Visible ;
      private int edtavAuthissuerurl_Enabled ;
      private int edtavAuthcertificatepathfilename_Enabled ;
      private int edtavAuthresponseaccesscodetag_Enabled ;
      private int edtavAuthresponseerrordesctag_Enabled ;
      private int edtavTokenurl_Enabled ;
      private int edtavTokenheaderkeytag_Enabled ;
      private int edtavTokenheaderkeyvalue_Enabled ;
      private int edtavTokenheaderauthenticationrealm_Enabled ;
      private int edtavTokengranttypetag_Enabled ;
      private int edtavTokengranttypevalue_Enabled ;
      private int edtavTokenadditionalparameters_Enabled ;
      private int edtavTokenresponseaccesstokentag_Enabled ;
      private int edtavTokenresponsetokentypetag_Enabled ;
      private int edtavTokenresponseexpiresintag_Enabled ;
      private int edtavTokenresponsescopetag_Enabled ;
      private int edtavTokenresponseuseridtag_Enabled ;
      private int edtavTokenresponserefreshtokentag_Enabled ;
      private int edtavTokenresponseerrordescriptiontag_Enabled ;
      private int edtavTokenrefreshtokenurl_Enabled ;
      private int edtavUserinfourl_Enabled ;
      private int edtavUserinfoheaderkeytag_Enabled ;
      private int edtavUserinfoheaderkeyvalue_Enabled ;
      private int edtavUserinfoaccesstokenname_Enabled ;
      private int edtavUserinfoclientidname_Enabled ;
      private int edtavUserinfoclientsecretname_Enabled ;
      private int edtavUserinfoadditionalparameters_Visible ;
      private int edtavUserinfoadditionalparameters_Enabled ;
      private int edtavUserinforesponseuseremailtag_Enabled ;
      private int edtavUserinforesponseuserverifiedemailtag_Enabled ;
      private int edtavUserinforesponseuserexternalidtag_Enabled ;
      private int edtavUserinforesponseusernametag_Enabled ;
      private int edtavUserinforesponseuserfirstnametag_Enabled ;
      private int edtavUserinforesponseuserlastnametag_Visible ;
      private int edtavUserinforesponseuserlastnametag_Enabled ;
      private int edtavUserinforesponseusergendertag_Enabled ;
      private int edtavUserinforesponseusergendervalues_Enabled ;
      private int edtavUserinforesponseuserbirthdaytag_Enabled ;
      private int edtavUserinforesponseuserurlimagetag_Enabled ;
      private int edtavUserinforesponseuserurlprofiletag_Enabled ;
      private int edtavUserinforesponseuserlanguagetag_Enabled ;
      private int edtavUserinforesponseusertimezonetag_Enabled ;
      private int edtavUserinforesponseerrordescriptiontag_Enabled ;
      private int bttBtnadd_Visible ;
      private int bttBtnenter_Visible ;
      private int subGrid_Islastpage ;
      private int GRID_nGridOutOfScope ;
      private int AV220GXV1 ;
      private int edtavDeleteproperty_Visible ;
      private int edtavDynamicpropname_Enabled ;
      private int edtavDynamicproptag_Enabled ;
      private int edtavDynamicpropname_Visible ;
      private int edtavDynamicproptag_Visible ;
      private int nGXsfl_548_fel_idx=1 ;
      private int AV223GXV2 ;
      private int AV225GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private string Gx_mode ;
      private string AV34Name ;
      private string AV68TypeId ;
      private string wcpOGx_mode ;
      private string wcpOAV34Name ;
      private string wcpOAV68TypeId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_548_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV155NameInit ;
      private string Dvpanel_groupauthopenidconnecttable1_Width ;
      private string Dvpanel_groupauthopenidconnecttable1_Cls ;
      private string Dvpanel_groupauthopenidconnecttable1_Title ;
      private string Dvpanel_groupauthopenidconnecttable1_Iconposition ;
      private string Dvpanel_unnamedtable14_Width ;
      private string Dvpanel_unnamedtable14_Cls ;
      private string Dvpanel_unnamedtable14_Title ;
      private string Dvpanel_unnamedtable14_Iconposition ;
      private string Dvpanel_unnamedtable13_Width ;
      private string Dvpanel_unnamedtable13_Cls ;
      private string Dvpanel_unnamedtable13_Title ;
      private string Dvpanel_unnamedtable13_Iconposition ;
      private string Dvpanel_unnamedtable7_Width ;
      private string Dvpanel_unnamedtable7_Cls ;
      private string Dvpanel_unnamedtable7_Title ;
      private string Dvpanel_unnamedtable7_Iconposition ;
      private string Dvpanel_unnamedtable9_Width ;
      private string Dvpanel_unnamedtable9_Cls ;
      private string Dvpanel_unnamedtable9_Title ;
      private string Dvpanel_unnamedtable9_Iconposition ;
      private string Dvpanel_unnamedtable10_Width ;
      private string Dvpanel_unnamedtable10_Cls ;
      private string Dvpanel_unnamedtable10_Title ;
      private string Dvpanel_unnamedtable10_Iconposition ;
      private string Dvpanel_unnamedtable11_Width ;
      private string Dvpanel_unnamedtable11_Cls ;
      private string Dvpanel_unnamedtable11_Title ;
      private string Dvpanel_unnamedtable11_Iconposition ;
      private string Dvpanel_unnamedtable8_Width ;
      private string Dvpanel_unnamedtable8_Cls ;
      private string Dvpanel_unnamedtable8_Title ;
      private string Dvpanel_unnamedtable8_Iconposition ;
      private string Dvpanel_unnamedtable2_Width ;
      private string Dvpanel_unnamedtable2_Cls ;
      private string Dvpanel_unnamedtable2_Title ;
      private string Dvpanel_unnamedtable2_Iconposition ;
      private string Dvpanel_paneluserbody_Width ;
      private string Dvpanel_paneluserbody_Cls ;
      private string Dvpanel_paneluserbody_Title ;
      private string Dvpanel_paneluserbody_Iconposition ;
      private string Dvpanel_unnamedtable4_Width ;
      private string Dvpanel_unnamedtable4_Cls ;
      private string Dvpanel_unnamedtable4_Title ;
      private string Dvpanel_unnamedtable4_Iconposition ;
      private string Dvpanel_unnamedtable5_Width ;
      private string Dvpanel_unnamedtable5_Cls ;
      private string Dvpanel_unnamedtable5_Title ;
      private string Dvpanel_unnamedtable5_Iconposition ;
      private string Dvpanel_unnamedtable3_Width ;
      private string Dvpanel_unnamedtable3_Cls ;
      private string Dvpanel_unnamedtable3_Title ;
      private string Dvpanel_unnamedtable3_Iconposition ;
      private string Gxuitabspanel_tabs_Class ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string cmbavIdp_Internalname ;
      private string TempTags ;
      private string cmbavIdp_Jsonclick ;
      private string edtavName_Internalname ;
      private string edtavName_Jsonclick ;
      private string cmbavFunctionid_Internalname ;
      private string AV30FunctionId ;
      private string cmbavFunctionid_Jsonclick ;
      private string edtavDsc_Internalname ;
      private string AV25Dsc ;
      private string edtavDsc_Jsonclick ;
      private string chkavIsenable_Internalname ;
      private string cmbavImpersonate_Internalname ;
      private string AV32Impersonate ;
      private string cmbavImpersonate_Jsonclick ;
      private string edtavSmallimagename_Internalname ;
      private string AV43SmallImageName ;
      private string edtavSmallimagename_Jsonclick ;
      private string edtavBigimagename_Internalname ;
      private string AV23BigImageName ;
      private string edtavBigimagename_Jsonclick ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divUnnamedtable15_Internalname ;
      private string edtavOauth20clientidtag_Internalname ;
      private string AV35Oauth20ClientIdTag ;
      private string edtavOauth20clientidtag_Jsonclick ;
      private string edtavOauth20clientidvalue_Internalname ;
      private string edtavOauth20clientidvalue_Jsonclick ;
      private string edtavOauth20clientsecrettag_Internalname ;
      private string AV37Oauth20ClientSecretTag ;
      private string edtavOauth20clientsecrettag_Jsonclick ;
      private string edtavOauth20clientsecretvalue_Internalname ;
      private string edtavOauth20clientsecretvalue_Jsonclick ;
      private string edtavOauth20redirecturltag_Internalname ;
      private string AV41Oauth20RedirectURLTag ;
      private string edtavOauth20redirecturltag_Jsonclick ;
      private string edtavOauth20redirecturlvalue_Internalname ;
      private string edtavOauth20redirecturlvalue_Jsonclick ;
      private string chkavOauth20redirecturliscustom_Internalname ;
      private string divUnnamedtable16_Internalname ;
      private string lblTbhelpcustomredirect_Internalname ;
      private string lblTbhelpcustomredirect_Jsonclick ;
      private string divTblautocompletevirtualdirectory_Internalname ;
      private string chkavOauth20redirecturl_autocompletevirtualdirectory_Internalname ;
      private string lblTbhelpautocompletevirtualdirectory_Internalname ;
      private string lblTbhelpautocompletevirtualdirectory_Jsonclick ;
      private string chkavOauth20redirecttoauthenticate_Internalname ;
      private string lblTbhelp0redirecttoauthenticate_Internalname ;
      private string lblTbhelp0redirecttoauthenticate_Jsonclick ;
      private string lblAuthorization_title_Internalname ;
      private string lblAuthorization_title_Jsonclick ;
      private string divUnnamedtable12_Internalname ;
      private string edtavAuthorizeurl_Internalname ;
      private string edtavAuthorizeurl_Jsonclick ;
      private string Dvpanel_unnamedtable13_Internalname ;
      private string divUnnamedtable13_Internalname ;
      private string chkavAuthresptypeinclude_Internalname ;
      private string edtavAuthresptypetag_Internalname ;
      private string AV15AuthRespTypeTag ;
      private string edtavAuthresptypetag_Jsonclick ;
      private string edtavAuthresptypevalue_Internalname ;
      private string edtavAuthresptypevalue_Jsonclick ;
      private string chkavAuthscopeinclude_Internalname ;
      private string edtavAuthscopetag_Internalname ;
      private string AV18AuthScopeTag ;
      private string edtavAuthscopetag_Jsonclick ;
      private string edtavAuthscopevalue_Internalname ;
      private string edtavAuthscopevalue_Jsonclick ;
      private string chkavAuthstateinclude_Internalname ;
      private string edtavAuthstatetag_Internalname ;
      private string AV21AuthStateTag ;
      private string edtavAuthstatetag_Jsonclick ;
      private string chkavAuthclientidinclude_Internalname ;
      private string chkavAuthclientsecretinclude_Internalname ;
      private string chkavAuthredirurlinclude_Internalname ;
      private string edtavAuthadditionalparameters_Internalname ;
      private string AV5AuthAdditionalParameters ;
      private string edtavAuthadditionalparameters_Jsonclick ;
      private string edtavAuthadditionalparameterssd_Internalname ;
      private string AV6AuthAdditionalParametersSD ;
      private string edtavAuthadditionalparameterssd_Jsonclick ;
      private string chkavAuthopenidconnectprotocolenable_Internalname ;
      private string divTbl_openidconnect_Internalname ;
      private string Dvpanel_groupauthopenidconnecttable1_Internalname ;
      private string divGroupauthopenidconnecttable1_Internalname ;
      private string chkavAuthvalididtoken_Internalname ;
      private string divTbl_valididtoken_Internalname ;
      private string edtavAuthissuerurl_Internalname ;
      private string edtavAuthissuerurl_Jsonclick ;
      private string edtavAuthcertificatepathfilename_Internalname ;
      private string edtavAuthcertificatepathfilename_Jsonclick ;
      private string chkavAuthallowonlyuseremailverified_Internalname ;
      private string Dvpanel_unnamedtable14_Internalname ;
      private string divUnnamedtable14_Internalname ;
      private string edtavAuthresponseaccesscodetag_Internalname ;
      private string AV12AuthResponseAccessCodeTag ;
      private string edtavAuthresponseaccesscodetag_Jsonclick ;
      private string edtavAuthresponseerrordesctag_Internalname ;
      private string AV13AuthResponseErrorDescTag ;
      private string edtavAuthresponseerrordesctag_Jsonclick ;
      private string lblToken_title_Internalname ;
      private string lblToken_title_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string edtavTokenurl_Internalname ;
      private string edtavTokenurl_Jsonclick ;
      private string cmbavTokenmethod_Internalname ;
      private string AV57TokenMethod ;
      private string cmbavTokenmethod_Jsonclick ;
      private string Dvpanel_unnamedtable7_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string edtavTokenheaderkeytag_Internalname ;
      private string AV55TokenHeaderKeyTag ;
      private string edtavTokenheaderkeytag_Jsonclick ;
      private string edtavTokenheaderkeyvalue_Internalname ;
      private string edtavTokenheaderkeyvalue_Jsonclick ;
      private string chkavTokenheaderauthenticationinclude_Internalname ;
      private string chkavTokenheaderauthorizationbasicinclude_Internalname ;
      private string cmbavTokenheaderauthenticationmethod_Internalname ;
      private string cmbavTokenheaderauthenticationmethod_Jsonclick ;
      private string edtavTokenheaderauthenticationrealm_Internalname ;
      private string AV53TokenHeaderAuthenticationRealm ;
      private string edtavTokenheaderauthenticationrealm_Jsonclick ;
      private string Dvpanel_unnamedtable8_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string Dvpanel_unnamedtable9_Internalname ;
      private string divUnnamedtable9_Internalname ;
      private string chkavTokengranttypeinclude_Internalname ;
      private string edtavTokengranttypetag_Internalname ;
      private string AV49TokenGrantTypeTag ;
      private string edtavTokengranttypetag_Jsonclick ;
      private string edtavTokengranttypevalue_Internalname ;
      private string edtavTokengranttypevalue_Jsonclick ;
      private string chkavTokenaccesscodeinclude_Internalname ;
      private string chkavTokencliidinclude_Internalname ;
      private string chkavTokenclisecretinclude_Internalname ;
      private string chkavTokenredirecturlinclude_Internalname ;
      private string edtavTokenadditionalparameters_Internalname ;
      private string AV45TokenAdditionalParameters ;
      private string edtavTokenadditionalparameters_Jsonclick ;
      private string Dvpanel_unnamedtable10_Internalname ;
      private string divUnnamedtable10_Internalname ;
      private string edtavTokenresponseaccesstokentag_Internalname ;
      private string AV60TokenResponseAccessTokenTag ;
      private string edtavTokenresponseaccesstokentag_Jsonclick ;
      private string edtavTokenresponsetokentypetag_Internalname ;
      private string AV65TokenResponseTokenTypeTag ;
      private string edtavTokenresponsetokentypetag_Jsonclick ;
      private string edtavTokenresponseexpiresintag_Internalname ;
      private string AV62TokenResponseExpiresInTag ;
      private string edtavTokenresponseexpiresintag_Jsonclick ;
      private string edtavTokenresponsescopetag_Internalname ;
      private string AV64TokenResponseScopeTag ;
      private string edtavTokenresponsescopetag_Jsonclick ;
      private string edtavTokenresponseuseridtag_Internalname ;
      private string AV66TokenResponseUserIdTag ;
      private string edtavTokenresponseuseridtag_Jsonclick ;
      private string edtavTokenresponserefreshtokentag_Internalname ;
      private string AV63TokenResponseRefreshTokenTag ;
      private string edtavTokenresponserefreshtokentag_Jsonclick ;
      private string edtavTokenresponseerrordescriptiontag_Internalname ;
      private string AV61TokenResponseErrorDescriptionTag ;
      private string edtavTokenresponseerrordescriptiontag_Jsonclick ;
      private string Dvpanel_unnamedtable11_Internalname ;
      private string divUnnamedtable11_Internalname ;
      private string chkavAutovalidateexternaltokenandrefresh_Internalname ;
      private string edtavTokenrefreshtokenurl_Internalname ;
      private string edtavTokenrefreshtokenurl_Jsonclick ;
      private string lblUserinfo_title_Internalname ;
      private string lblUserinfo_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string edtavUserinfourl_Internalname ;
      private string edtavUserinfourl_Jsonclick ;
      private string cmbavUserinfomethod_Internalname ;
      private string AV78UserInfoMethod ;
      private string cmbavUserinfomethod_Jsonclick ;
      private string Dvpanel_unnamedtable2_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtavUserinfoheaderkeytag_Internalname ;
      private string AV76UserInfoHeaderKeyTag ;
      private string edtavUserinfoheaderkeytag_Jsonclick ;
      private string edtavUserinfoheaderkeyvalue_Internalname ;
      private string edtavUserinfoheaderkeyvalue_Jsonclick ;
      private string Dvpanel_unnamedtable3_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string Dvpanel_paneluserbody_Internalname ;
      private string divPaneluserbody_Internalname ;
      private string chkavUserinfoaccesstokeninclude_Internalname ;
      private string edtavUserinfoaccesstokenname_Internalname ;
      private string AV70UserInfoAccessTokenName ;
      private string edtavUserinfoaccesstokenname_Jsonclick ;
      private string chkavUserinfoclientidinclude_Internalname ;
      private string edtavUserinfoclientidname_Internalname ;
      private string AV73UserInfoClientIdName ;
      private string edtavUserinfoclientidname_Jsonclick ;
      private string chkavUserinfoclientsecretinclude_Internalname ;
      private string edtavUserinfoclientsecretname_Internalname ;
      private string AV75UserInfoClientSecretName ;
      private string edtavUserinfoclientsecretname_Jsonclick ;
      private string chkavUserinfouseridinclude_Internalname ;
      private string edtavUserinfoadditionalparameters_Internalname ;
      private string AV71UserInfoAdditionalParameters ;
      private string edtavUserinfoadditionalparameters_Jsonclick ;
      private string Dvpanel_unnamedtable4_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string edtavUserinforesponseuseremailtag_Internalname ;
      private string AV81UserInfoResponseUserEmailTag ;
      private string edtavUserinforesponseuseremailtag_Jsonclick ;
      private string edtavUserinforesponseuserverifiedemailtag_Internalname ;
      private string AV93UserInfoResponseUserVerifiedEmailTag ;
      private string edtavUserinforesponseuserverifiedemailtag_Jsonclick ;
      private string edtavUserinforesponseuserexternalidtag_Internalname ;
      private string AV82UserInfoResponseUserExternalIdTag ;
      private string edtavUserinforesponseuserexternalidtag_Jsonclick ;
      private string edtavUserinforesponseusernametag_Internalname ;
      private string AV89UserInfoResponseUserNameTag ;
      private string edtavUserinforesponseusernametag_Jsonclick ;
      private string edtavUserinforesponseuserfirstnametag_Internalname ;
      private string AV83UserInfoResponseUserFirstNameTag ;
      private string edtavUserinforesponseuserfirstnametag_Jsonclick ;
      private string chkavUserinforesponseuserlastnamegenauto_Internalname ;
      private string lblTbuserlastnamehelp_Internalname ;
      private string lblTbuserlastnamehelp_Caption ;
      private string lblTbuserlastnamehelp_Jsonclick ;
      private string divUserinforesponseuserlastnametag_cell_Internalname ;
      private string divUserinforesponseuserlastnametag_cell_Class ;
      private string edtavUserinforesponseuserlastnametag_Internalname ;
      private string AV88UserInfoResponseUserLastNameTag ;
      private string edtavUserinforesponseuserlastnametag_Jsonclick ;
      private string edtavUserinforesponseusergendertag_Internalname ;
      private string AV84UserInfoResponseUserGenderTag ;
      private string edtavUserinforesponseusergendertag_Jsonclick ;
      private string edtavUserinforesponseusergendervalues_Internalname ;
      private string edtavUserinforesponseusergendervalues_Jsonclick ;
      private string edtavUserinforesponseuserbirthdaytag_Internalname ;
      private string AV80UserInfoResponseUserBirthdayTag ;
      private string edtavUserinforesponseuserbirthdaytag_Jsonclick ;
      private string edtavUserinforesponseuserurlimagetag_Internalname ;
      private string AV91UserInfoResponseUserURLImageTag ;
      private string edtavUserinforesponseuserurlimagetag_Jsonclick ;
      private string edtavUserinforesponseuserurlprofiletag_Internalname ;
      private string AV92UserInfoResponseUserURLProfileTag ;
      private string edtavUserinforesponseuserurlprofiletag_Jsonclick ;
      private string edtavUserinforesponseuserlanguagetag_Internalname ;
      private string AV86UserInfoResponseUserLanguageTag ;
      private string edtavUserinforesponseuserlanguagetag_Jsonclick ;
      private string edtavUserinforesponseusertimezonetag_Internalname ;
      private string AV90UserInfoResponseUserTimeZoneTag ;
      private string edtavUserinforesponseusertimezonetag_Jsonclick ;
      private string edtavUserinforesponseerrordescriptiontag_Internalname ;
      private string AV79UserInfoResponseErrorDescriptionTag ;
      private string edtavUserinforesponseerrordescriptiontag_Jsonclick ;
      private string Dvpanel_unnamedtable5_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string bttBtnadd_Internalname ;
      private string bttBtnadd_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavDynamicpropname_Internalname ;
      private string AV26DynamicPropName ;
      private string AV27DynamicPropTag ;
      private string edtavDynamicproptag_Internalname ;
      private string edtavDeleteproperty_Internalname ;
      private string edtavDeleteproperty_gximage ;
      private string edtavDeleteproperty_Tooltiptext ;
      private string sGXsfl_548_fel_idx="0001" ;
      private string sCtrlGx_mode ;
      private string sCtrlAV34Name ;
      private string sCtrlAV68TypeId ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDynamicpropname_Jsonclick ;
      private string edtavDynamicproptag_Jsonclick ;
      private string sImgUrl ;
      private string edtavDeleteproperty_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV33IsEnable ;
      private bool AV40Oauth20RedirectURLisCustom ;
      private bool AV111Oauth20RedirectURL_AutocompleteVirtualDirectory ;
      private bool AV39Oauth20RedirectToAuthenticate ;
      private bool AV14AuthRespTypeInclude ;
      private bool AV17AuthScopeInclude ;
      private bool AV98AuthStateInclude ;
      private bool AV7AuthClientIdInclude ;
      private bool AV8AuthClientSecretInclude ;
      private bool AV99AuthRedirURLInclude ;
      private bool AV109AuthOpenIDConnectProtocolEnable ;
      private bool AV110AuthValidIdToken ;
      private bool AV106AuthAllowOnlyUserEmailVerified ;
      private bool AV51TokenHeaderAuthenticationInclude ;
      private bool AV54TokenHeaderAuthorizationBasicInclude ;
      private bool AV48TokenGrantTypeInclude ;
      private bool AV44TokenAccessCodeInclude ;
      private bool AV46TokenCliIdInclude ;
      private bool AV47TokenCliSecretInclude ;
      private bool AV58TokenRedirectURLInclude ;
      private bool AV22AutovalidateExternalTokenAndRefresh ;
      private bool AV69UserInfoAccessTokenInclude ;
      private bool AV72UserInfoClientIdInclude ;
      private bool AV74UserInfoClientSecretInclude ;
      private bool AV95UserInfoUserIdInclude ;
      private bool AV87UserInfoResponseUserLastNameGenAuto ;
      private bool AV105CheckRequiredFieldsResult ;
      private bool AV20AuthStateIncude ;
      private bool Dvpanel_groupauthopenidconnecttable1_Autowidth ;
      private bool Dvpanel_groupauthopenidconnecttable1_Autoheight ;
      private bool Dvpanel_groupauthopenidconnecttable1_Collapsible ;
      private bool Dvpanel_groupauthopenidconnecttable1_Collapsed ;
      private bool Dvpanel_groupauthopenidconnecttable1_Showcollapseicon ;
      private bool Dvpanel_groupauthopenidconnecttable1_Autoscroll ;
      private bool Dvpanel_unnamedtable14_Autowidth ;
      private bool Dvpanel_unnamedtable14_Autoheight ;
      private bool Dvpanel_unnamedtable14_Collapsible ;
      private bool Dvpanel_unnamedtable14_Collapsed ;
      private bool Dvpanel_unnamedtable14_Showcollapseicon ;
      private bool Dvpanel_unnamedtable14_Autoscroll ;
      private bool Dvpanel_unnamedtable13_Autowidth ;
      private bool Dvpanel_unnamedtable13_Autoheight ;
      private bool Dvpanel_unnamedtable13_Collapsible ;
      private bool Dvpanel_unnamedtable13_Collapsed ;
      private bool Dvpanel_unnamedtable13_Showcollapseicon ;
      private bool Dvpanel_unnamedtable13_Autoscroll ;
      private bool Dvpanel_unnamedtable7_Autowidth ;
      private bool Dvpanel_unnamedtable7_Autoheight ;
      private bool Dvpanel_unnamedtable7_Collapsible ;
      private bool Dvpanel_unnamedtable7_Collapsed ;
      private bool Dvpanel_unnamedtable7_Showcollapseicon ;
      private bool Dvpanel_unnamedtable7_Autoscroll ;
      private bool Dvpanel_unnamedtable9_Autowidth ;
      private bool Dvpanel_unnamedtable9_Autoheight ;
      private bool Dvpanel_unnamedtable9_Collapsible ;
      private bool Dvpanel_unnamedtable9_Collapsed ;
      private bool Dvpanel_unnamedtable9_Showcollapseicon ;
      private bool Dvpanel_unnamedtable9_Autoscroll ;
      private bool Dvpanel_unnamedtable10_Autowidth ;
      private bool Dvpanel_unnamedtable10_Autoheight ;
      private bool Dvpanel_unnamedtable10_Collapsible ;
      private bool Dvpanel_unnamedtable10_Collapsed ;
      private bool Dvpanel_unnamedtable10_Showcollapseicon ;
      private bool Dvpanel_unnamedtable10_Autoscroll ;
      private bool Dvpanel_unnamedtable11_Autowidth ;
      private bool Dvpanel_unnamedtable11_Autoheight ;
      private bool Dvpanel_unnamedtable11_Collapsible ;
      private bool Dvpanel_unnamedtable11_Collapsed ;
      private bool Dvpanel_unnamedtable11_Showcollapseicon ;
      private bool Dvpanel_unnamedtable11_Autoscroll ;
      private bool Dvpanel_unnamedtable8_Autowidth ;
      private bool Dvpanel_unnamedtable8_Autoheight ;
      private bool Dvpanel_unnamedtable8_Collapsible ;
      private bool Dvpanel_unnamedtable8_Collapsed ;
      private bool Dvpanel_unnamedtable8_Showcollapseicon ;
      private bool Dvpanel_unnamedtable8_Autoscroll ;
      private bool Dvpanel_unnamedtable2_Autowidth ;
      private bool Dvpanel_unnamedtable2_Autoheight ;
      private bool Dvpanel_unnamedtable2_Collapsible ;
      private bool Dvpanel_unnamedtable2_Collapsed ;
      private bool Dvpanel_unnamedtable2_Showcollapseicon ;
      private bool Dvpanel_unnamedtable2_Autoscroll ;
      private bool Dvpanel_paneluserbody_Autowidth ;
      private bool Dvpanel_paneluserbody_Autoheight ;
      private bool Dvpanel_paneluserbody_Collapsible ;
      private bool Dvpanel_paneluserbody_Collapsed ;
      private bool Dvpanel_paneluserbody_Showcollapseicon ;
      private bool Dvpanel_paneluserbody_Autoscroll ;
      private bool Dvpanel_unnamedtable4_Autowidth ;
      private bool Dvpanel_unnamedtable4_Autoheight ;
      private bool Dvpanel_unnamedtable4_Collapsible ;
      private bool Dvpanel_unnamedtable4_Collapsed ;
      private bool Dvpanel_unnamedtable4_Showcollapseicon ;
      private bool Dvpanel_unnamedtable4_Autoscroll ;
      private bool Dvpanel_unnamedtable5_Autowidth ;
      private bool Dvpanel_unnamedtable5_Autoheight ;
      private bool Dvpanel_unnamedtable5_Collapsible ;
      private bool Dvpanel_unnamedtable5_Collapsed ;
      private bool Dvpanel_unnamedtable5_Showcollapseicon ;
      private bool Dvpanel_unnamedtable5_Autoscroll ;
      private bool Dvpanel_unnamedtable3_Autowidth ;
      private bool Dvpanel_unnamedtable3_Autoheight ;
      private bool Dvpanel_unnamedtable3_Collapsible ;
      private bool Dvpanel_unnamedtable3_Collapsed ;
      private bool Dvpanel_unnamedtable3_Showcollapseicon ;
      private bool Dvpanel_unnamedtable3_Autoscroll ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_548_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV24DeleteProperty_IsBlob ;
      private string AV151IDP ;
      private string AV36Oauth20ClientIdValue ;
      private string AV38Oauth20ClientSecretValue ;
      private string AV42Oauth20RedirectURLvalue ;
      private string AV10AuthorizeURL ;
      private string AV16AuthRespTypeValue ;
      private string AV19AuthScopeValue ;
      private string AV108AuthIssuerURL ;
      private string AV107AuthCertificatePathFileName ;
      private string AV67TokenURL ;
      private string AV56TokenHeaderKeyValue ;
      private string AV50TokenGrantTypeValue ;
      private string AV59TokenRefreshTokenURL ;
      private string AV94UserInfoURL ;
      private string AV77UserInfoHeaderKeyValue ;
      private string AV85UserInfoResponseUserGenderValues ;
      private string AV221Deleteproperty_GXI ;
      private string AV24DeleteProperty ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXUserControl ucDvpanel_unnamedtable13 ;
      private GXUserControl ucDvpanel_groupauthopenidconnecttable1 ;
      private GXUserControl ucDvpanel_unnamedtable14 ;
      private GXUserControl ucDvpanel_unnamedtable7 ;
      private GXUserControl ucDvpanel_unnamedtable8 ;
      private GXUserControl ucDvpanel_unnamedtable9 ;
      private GXUserControl ucDvpanel_unnamedtable10 ;
      private GXUserControl ucDvpanel_unnamedtable11 ;
      private GXUserControl ucDvpanel_unnamedtable2 ;
      private GXUserControl ucDvpanel_unnamedtable3 ;
      private GXUserControl ucDvpanel_paneluserbody ;
      private GXUserControl ucDvpanel_unnamedtable4 ;
      private GXUserControl ucDvpanel_unnamedtable5 ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_Name ;
      private string aP2_TypeId ;
      private GXCombobox cmbavIdp ;
      private GXCombobox cmbavFunctionid ;
      private GXCheckbox chkavIsenable ;
      private GXCombobox cmbavImpersonate ;
      private GXCheckbox chkavOauth20redirecturliscustom ;
      private GXCheckbox chkavOauth20redirecturl_autocompletevirtualdirectory ;
      private GXCheckbox chkavOauth20redirecttoauthenticate ;
      private GXCheckbox chkavAuthresptypeinclude ;
      private GXCheckbox chkavAuthscopeinclude ;
      private GXCheckbox chkavAuthstateinclude ;
      private GXCheckbox chkavAuthclientidinclude ;
      private GXCheckbox chkavAuthclientsecretinclude ;
      private GXCheckbox chkavAuthredirurlinclude ;
      private GXCheckbox chkavAuthopenidconnectprotocolenable ;
      private GXCheckbox chkavAuthvalididtoken ;
      private GXCheckbox chkavAuthallowonlyuseremailverified ;
      private GXCombobox cmbavTokenmethod ;
      private GXCheckbox chkavTokenheaderauthenticationinclude ;
      private GXCheckbox chkavTokenheaderauthorizationbasicinclude ;
      private GXCombobox cmbavTokenheaderauthenticationmethod ;
      private GXCheckbox chkavTokengranttypeinclude ;
      private GXCheckbox chkavTokenaccesscodeinclude ;
      private GXCheckbox chkavTokencliidinclude ;
      private GXCheckbox chkavTokenclisecretinclude ;
      private GXCheckbox chkavTokenredirecturlinclude ;
      private GXCheckbox chkavAutovalidateexternaltokenandrefresh ;
      private GXCombobox cmbavUserinfomethod ;
      private GXCheckbox chkavUserinfoaccesstokeninclude ;
      private GXCheckbox chkavUserinfoclientidinclude ;
      private GXCheckbox chkavUserinfoclientsecretinclude ;
      private GXCheckbox chkavUserinfouseridinclude ;
      private GXCheckbox chkavUserinforesponseuserlastnamegenauto ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeOauth20 AV9AuthenticationTypeOauth20 ;
      private GeneXus.Programs.genexussecurity.SdtGAMPropertySimple AV31GAMPropertySimple ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV29Errors ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV28Error ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType> AV224GXV3 ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeFilter AV218GAMAuthenticationTypeFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV122AuthenticationType ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamwcauthenticationtypeentryoauth20__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamwcauthenticationtypeentryoauth20__default : DataStoreHelperBase, IDataStoreHelper
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
