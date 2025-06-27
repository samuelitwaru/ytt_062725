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
   public class gamwwuserroles : GXDataArea
   {
      public gamwwuserroles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamwwuserroles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserId )
      {
         this.AV28UserId = aP0_UserId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavDisplayinheritroles = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "UserId");
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
               gxfirstwebparm = GetFirstPar( "UserId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "UserId");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV28UserId = gxfirstwebparm;
               AssignAttri("", false, "AV28UserId", AV28UserId);
               GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28UserId, "")), context));
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
         nRC_GXsfl_40 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_40"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_40_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_40_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_40_idx = GetPar( "sGXsfl_40_idx");
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
         AV57ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV69Pgmname = GetPar( "Pgmname");
         AV11DisplayInheritRoles = StringUtil.StrToBool( GetPar( "DisplayInheritRoles"));
         AV28UserId = GetPar( "UserId");
         AV67IsAuthorized_Back = StringUtil.StrToBool( GetPar( "IsAuthorized_Back"));
         AV68IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         AV27RolesId = (long)(Math.Round(NumberUtil.Val( GetPar( "RolesId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV57ManageFiltersExecutionStep, AV69Pgmname, AV11DisplayInheritRoles, AV28UserId, AV67IsAuthorized_Back, AV68IsAuthorized_Insert, AV27RolesId) ;
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
            return "gamwwuserroles_Execute" ;
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
         PA1T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1T2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamwwuserroles.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV28UserId))}, new string[] {"UserId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERID", StringUtil.RTrim( AV28UserId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28UserId, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BACK", AV67IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV67IsAuthorized_Back, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV68IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV68IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vROLESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27RolesId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27RolesId), "ZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_40", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_40), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV61ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV61ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV66GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERID", StringUtil.RTrim( AV28UserId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28UserId, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV37GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV37GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BACK", AV67IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV67IsAuthorized_Back, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV68IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV68IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vROLESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27RolesId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27RolesId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            WE1T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1T2( ) ;
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
         return formatLink("gamwwuserroles.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV28UserId))}, new string[] {"UserId"})  ;
      }

      public override string GetPgmname( )
      {
         return "GAMWWUserRoles" ;
      }

      public override string GetPgmdesc( )
      {
         return "Roles of user" ;
      }

      protected void WB1T0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidthAuto", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "TableCellsWidthAuto", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupGrouped", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnback_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Back", bttBtnback_Jsonclick, 5, "Back", "", StyleString, ClassString, bttBtnback_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBACK\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWUserRoles.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(40), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWUserRoles.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6 CellFloatRight CellWidthAuto", "start", "top", "", "", "div");
            wb_table1_21_1T2( true) ;
         }
         else
         {
            wb_table1_21_1T2( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_1T2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl40( ) ;
         }
         if ( wbEnd == 40 )
         {
            wbEnd = 0;
            nRC_GXsfl_40 = (int)(nGXsfl_40_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV64GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV18GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV66GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 40 )
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

      protected void START1T2( )
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
         Form.Meta.addItem("description", "Roles of user", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1T0( ) ;
      }

      protected void WS1T2( )
      {
         START1T2( ) ;
         EVT1T2( ) ;
      }

      protected void EVT1T2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E111T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E121T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E131T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBACK'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBack' */
                              E141T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E151T2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "'DOADD'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VBTNMAINROLE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VBTNMAINROLE.CLICK") == 0 ) )
                           {
                              nGXsfl_40_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
                              SubsflControlProps_402( ) ;
                              AV5Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV5Delete);
                              AV9BtnMainRole = cgiGet( edtavBtnmainrole_Internalname);
                              AssignAttri("", false, edtavBtnmainrole_Internalname, AV9BtnMainRole);
                              GxWebStd.gx_hidden_field( context, "gxhash_vBTNMAINROLE"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, StringUtil.RTrim( context.localUtil.Format( AV9BtnMainRole, "")), context));
                              AV24Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV24Name);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
                                 GX_FocusControl = edtavId_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV22Id = 0;
                                 AssignAttri("", false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV22Id), 12, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, context.localUtil.Format( (decimal)(AV22Id), "ZZZZZZZZZZZ9"), context));
                              }
                              else
                              {
                                 AV22Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV22Id), 12, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, context.localUtil.Format( (decimal)(AV22Id), "ZZZZZZZZZZZ9"), context));
                              }
                              AV21GUID = cgiGet( edtavGuid_Internalname);
                              AssignAttri("", false, edtavGuid_Internalname, AV21GUID);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E161T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E171T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E181T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E191T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOADD'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoAdd' */
                                    E201T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VBTNMAINROLE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E211T2 ();
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

      protected void WE1T2( )
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

      protected void PA1T2( )
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
               GX_FocusControl = chkavDisplayinheritroles_Internalname;
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
         SubsflControlProps_402( ) ;
         while ( nGXsfl_40_idx <= nRC_GXsfl_40 )
         {
            sendrow_402( ) ;
            nGXsfl_40_idx = ((subGrid_Islastpage==1)&&(nGXsfl_40_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV57ManageFiltersExecutionStep ,
                                       string AV69Pgmname ,
                                       bool AV11DisplayInheritRoles ,
                                       string AV28UserId ,
                                       bool AV67IsAuthorized_Back ,
                                       bool AV68IsAuthorized_Insert ,
                                       long AV27RolesId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV22Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Id), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBTNMAINROLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9BtnMainRole, "")), context));
         GxWebStd.gx_hidden_field( context, "vBTNMAINROLE", StringUtil.RTrim( AV9BtnMainRole));
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
         AV11DisplayInheritRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11DisplayInheritRoles));
         AssignAttri("", false, "AV11DisplayInheritRoles", AV11DisplayInheritRoles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV69Pgmname = "GAMWWUserRoles";
         edtavDelete_Enabled = 0;
         edtavBtnmainrole_Enabled = 0;
         edtavName_Enabled = 0;
         edtavId_Enabled = 0;
         edtavGuid_Enabled = 0;
      }

      protected void RF1T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 40;
         /* Execute user event: Refresh */
         E171T2 ();
         nGXsfl_40_idx = 1;
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         bGXsfl_40_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_402( ) ;
            /* Execute user event: Grid.Load */
            E181T2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_40_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E181T2 ();
            }
            wbEnd = 40;
            WB1T0( ) ;
         }
         bGXsfl_40_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1T2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BACK", AV67IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV67IsAuthorized_Back, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV68IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV68IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, context.localUtil.Format( (decimal)(AV22Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vROLESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27RolesId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27RolesId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vBTNMAINROLE"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, StringUtil.RTrim( context.localUtil.Format( AV9BtnMainRole, "")), context));
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV57ManageFiltersExecutionStep, AV69Pgmname, AV11DisplayInheritRoles, AV28UserId, AV67IsAuthorized_Back, AV68IsAuthorized_Insert, AV27RolesId) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV57ManageFiltersExecutionStep, AV69Pgmname, AV11DisplayInheritRoles, AV28UserId, AV67IsAuthorized_Back, AV68IsAuthorized_Insert, AV27RolesId) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV57ManageFiltersExecutionStep, AV69Pgmname, AV11DisplayInheritRoles, AV28UserId, AV67IsAuthorized_Back, AV68IsAuthorized_Insert, AV27RolesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV57ManageFiltersExecutionStep, AV69Pgmname, AV11DisplayInheritRoles, AV28UserId, AV67IsAuthorized_Back, AV68IsAuthorized_Insert, AV27RolesId) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV57ManageFiltersExecutionStep, AV69Pgmname, AV11DisplayInheritRoles, AV28UserId, AV67IsAuthorized_Back, AV68IsAuthorized_Insert, AV27RolesId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV69Pgmname = "GAMWWUserRoles";
         edtavDelete_Enabled = 0;
         edtavBtnmainrole_Enabled = 0;
         edtavName_Enabled = 0;
         edtavId_Enabled = 0;
         edtavGuid_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E161T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV61ManageFiltersData);
            /* Read saved values. */
            nRC_GXsfl_40 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_40"), ".", ","), 18, MidpointRounding.ToEven));
            AV64GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV18GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV66GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ".", ","), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV11DisplayInheritRoles = StringUtil.StrToBool( cgiGet( chkavDisplayinheritroles_Internalname));
            AssignAttri("", false, "AV11DisplayInheritRoles", AV11DisplayInheritRoles);
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
         E161T2 ();
         if (returnInSub) return;
      }

      protected void E161T2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV33HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         Form.Caption = "Roles of user";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         AV6GAMUser.load( AV28UserId);
         AV29UserName = StringUtil.Trim( AV6GAMUser.gxTpr_Firstname) + " " + StringUtil.Trim( AV6GAMUser.gxTpr_Lastname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29UserName)) )
         {
            AV29UserName = StringUtil.Trim( AV6GAMUser.gxTpr_Login);
         }
         Form.Caption = StringUtil.Format( "Roles of User: %1", AV29UserName, "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
      }

      protected void E171T2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV34WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         if ( AV57ManageFiltersExecutionStep == 1 )
         {
            AV57ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV57ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV57ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV57ManageFiltersExecutionStep == 2 )
         {
            AV57ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV57ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV57ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         AV64GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV64GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV64GridCurrentPage), 10, 0));
         GXt_char1 = AV66GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV69Pgmname, out  GXt_char1) ;
         AV66GridAppliedFilters = GXt_char1;
         AssignAttri("", false, "AV66GridAppliedFilters", AV66GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ManageFiltersData", AV61ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37GridState", AV37GridState);
      }

      protected void E121T2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV25PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV25PageToGo) ;
         }
      }

      protected void E131T2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E181T2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV5Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV5Delete);
         AV9BtnMainRole = "Set as main";
         AssignAttri("", false, edtavBtnmainrole_Internalname, AV9BtnMainRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vBTNMAINROLE"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, StringUtil.RTrim( context.localUtil.Format( AV9BtnMainRole, "")), context));
         AV6GAMUser.load( AV28UserId);
         AV19GridPageSize = subGrid_Rows;
         if ( ! AV11DisplayInheritRoles )
         {
            AV16GAMRoles = AV6GAMUser.getroles(out  AV13Errors);
            if ( AV16GAMRoles.Count == 0 )
            {
               AV18GridPageCount = 0;
               AssignAttri("", false, "AV18GridPageCount", StringUtil.LTrimStr( (decimal)(AV18GridPageCount), 10, 0));
            }
            else
            {
               AV18GridPageCount = (long)((AV16GAMRoles.Count/ (decimal)(AV19GridPageSize))+((((int)((AV16GAMRoles.Count) % (AV19GridPageSize)))>0) ? 1 : 0));
               AssignAttri("", false, "AV18GridPageCount", StringUtil.LTrimStr( (decimal)(AV18GridPageCount), 10, 0));
            }
            AV20GridRecordCount = AV16GAMRoles.Count;
            AV70GXV1 = 1;
            while ( AV70GXV1 <= AV16GAMRoles.Count )
            {
               AV14GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV16GAMRoles.Item(AV70GXV1));
               AV24Name = AV14GAMRole.gxTpr_Name;
               AssignAttri("", false, edtavName_Internalname, AV24Name);
               edtavDelete_Visible = 1;
               if ( AV14GAMRole.gxTpr_Id == AV6GAMUser.gxTpr_Defaultroleid )
               {
                  AV9BtnMainRole = "";
                  AssignAttri("", false, edtavBtnmainrole_Internalname, AV9BtnMainRole);
                  GxWebStd.gx_hidden_field( context, "gxhash_vBTNMAINROLE"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, StringUtil.RTrim( context.localUtil.Format( AV9BtnMainRole, "")), context));
                  AV24Name += "Main";
                  AssignAttri("", false, edtavName_Internalname, AV24Name);
               }
               else
               {
                  AV9BtnMainRole = "Set as main";
                  AssignAttri("", false, edtavBtnmainrole_Internalname, AV9BtnMainRole);
                  GxWebStd.gx_hidden_field( context, "gxhash_vBTNMAINROLE"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, StringUtil.RTrim( context.localUtil.Format( AV9BtnMainRole, "")), context));
               }
               AV21GUID = AV26Role.gxTpr_Guid;
               AssignAttri("", false, edtavGuid_Internalname, AV21GUID);
               AV22Id = AV14GAMRole.gxTpr_Id;
               AssignAttri("", false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV22Id), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, context.localUtil.Format( (decimal)(AV22Id), "ZZZZZZZZZZZ9"), context));
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 40;
               }
               if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_402( ) ;
               }
               GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
               GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
               subGrid_Recordcount = (int)(GRID_nCurrentRecord);
               if ( isFullAjaxMode( ) && ! bGXsfl_40_Refreshing )
               {
                  DoAjaxLoad(40, GridRow);
               }
               AV70GXV1 = (int)(AV70GXV1+1);
            }
         }
         else
         {
            AV17GAMRolesDirect = AV6GAMUser.getroles(out  AV13Errors);
            AV16GAMRoles = AV6GAMUser.getallroles(out  AV13Errors);
            if ( AV17GAMRolesDirect.Count > 0 )
            {
               AV18GridPageCount = (long)((AV16GAMRoles.Count/ (decimal)(AV19GridPageSize))+((((int)((AV16GAMRoles.Count) % (AV19GridPageSize)))>0) ? 1 : 0));
               AssignAttri("", false, "AV18GridPageCount", StringUtil.LTrimStr( (decimal)(AV18GridPageCount), 10, 0));
               AV20GridRecordCount = AV16GAMRoles.Count;
               AV71GXV2 = 1;
               while ( AV71GXV2 <= AV16GAMRoles.Count )
               {
                  AV14GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV16GAMRoles.Item(AV71GXV2));
                  AV23isDirectRole = false;
                  AV72GXV3 = 1;
                  while ( AV72GXV3 <= AV17GAMRolesDirect.Count )
                  {
                     AV15GAMRoleAux = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV17GAMRolesDirect.Item(AV72GXV3));
                     if ( AV14GAMRole.gxTpr_Id == AV15GAMRoleAux.gxTpr_Id )
                     {
                        AV23isDirectRole = true;
                        if (true) break;
                     }
                     AV72GXV3 = (int)(AV72GXV3+1);
                  }
                  if ( AV23isDirectRole )
                  {
                     edtavDelete_Visible = 0;
                     if ( AV14GAMRole.gxTpr_Id == AV6GAMUser.gxTpr_Defaultroleid )
                     {
                        AV9BtnMainRole = "Main";
                        AssignAttri("", false, edtavBtnmainrole_Internalname, AV9BtnMainRole);
                        GxWebStd.gx_hidden_field( context, "gxhash_vBTNMAINROLE"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, StringUtil.RTrim( context.localUtil.Format( AV9BtnMainRole, "")), context));
                     }
                     else
                     {
                        AV9BtnMainRole = "Set as main";
                        AssignAttri("", false, edtavBtnmainrole_Internalname, AV9BtnMainRole);
                        GxWebStd.gx_hidden_field( context, "gxhash_vBTNMAINROLE"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, StringUtil.RTrim( context.localUtil.Format( AV9BtnMainRole, "")), context));
                     }
                  }
                  else
                  {
                     edtavDelete_Visible = 0;
                     edtavBtnmainrole_Visible = 0;
                  }
                  AV21GUID = AV26Role.gxTpr_Guid;
                  AssignAttri("", false, edtavGuid_Internalname, AV21GUID);
                  AV22Id = AV14GAMRole.gxTpr_Id;
                  AssignAttri("", false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV22Id), 12, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_40_idx, GetSecureSignedToken( sGXsfl_40_idx, context.localUtil.Format( (decimal)(AV22Id), "ZZZZZZZZZZZ9"), context));
                  AV24Name = AV14GAMRole.gxTpr_Name;
                  AssignAttri("", false, edtavName_Internalname, AV24Name);
                  /* Load Method */
                  if ( wbStart != -1 )
                  {
                     wbStart = 40;
                  }
                  if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
                  {
                     sendrow_402( ) ;
                  }
                  GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
                  GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
                  GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
                  subGrid_Recordcount = (int)(GRID_nCurrentRecord);
                  if ( isFullAjaxMode( ) && ! bGXsfl_40_Refreshing )
                  {
                     DoAjaxLoad(40, GridRow);
                  }
                  AV71GXV2 = (int)(AV71GXV2+1);
               }
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E111T2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S152 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S142 ();
            if (returnInSub) return;
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("GAMWWUserRolesFilters")),UrlEncode(StringUtil.RTrim(AV69Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV57ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV57ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV57ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("GAMWWUserRolesFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV57ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV57ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV57ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char1 = AV58ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "GAMWWUserRolesFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char1) ;
            AV58ManageFiltersXml = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S152 ();
               if (returnInSub) return;
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV58ManageFiltersXml) ;
               AV37GridState.FromXml(AV58ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S162 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37GridState", AV37GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ManageFiltersData", AV61ManageFiltersData);
      }

      protected void E141T2( )
      {
         /* 'DoBack' Routine */
         returnInSub = false;
         if ( AV67IsAuthorized_Back )
         {
            CallWebObject(formatLink("gamwwusers.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ManageFiltersData", AV61ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37GridState", AV37GridState);
      }

      protected void E151T2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV68IsAuthorized_Insert )
         {
            CallWebObject(formatLink("gamuserroleselect.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV28UserId))}, new string[] {"UserId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ManageFiltersData", AV61ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37GridState", AV37GridState);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean2 = AV67IsAuthorized_Back;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamwwusers_Execute", out  GXt_boolean2) ;
         AV67IsAuthorized_Back = GXt_boolean2;
         AssignAttri("", false, "AV67IsAuthorized_Back", AV67IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV67IsAuthorized_Back, context));
         if ( ! ( AV67IsAuthorized_Back ) )
         {
            bttBtnback_Visible = 0;
            AssignProp("", false, bttBtnback_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnback_Visible), 5, 0), true);
         }
         GXt_boolean2 = AV68IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamuserroleselect_Execute", out  GXt_boolean2) ;
         AV68IsAuthorized_Insert = GXt_boolean2;
         AssignAttri("", false, "AV68IsAuthorized_Insert", AV68IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV68IsAuthorized_Insert, context));
         if ( ! ( AV68IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV61ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "GAMWWUserRolesFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV61ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S152( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV11DisplayInheritRoles = false;
         AssignAttri("", false, "AV11DisplayInheritRoles", AV11DisplayInheritRoles);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV56Session.Get(AV69Pgmname+"GridState"), "") == 0 )
         {
            AV37GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV69Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV56Session.Get(AV69Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S162 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV37GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV37GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV37GridState.gxTpr_Currentpage) ;
      }

      protected void S162( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV73GXV4 = 1;
         while ( AV73GXV4 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV73GXV4));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "DISPLAYINHERITROLES") == 0 )
            {
               AV11DisplayInheritRoles = BooleanUtil.Val( AV38GridStateFilterValue.gxTpr_Value);
               AssignAttri("", false, "AV11DisplayInheritRoles", AV11DisplayInheritRoles);
            }
            AV73GXV4 = (int)(AV73GXV4+1);
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV37GridState.FromXml(AV56Session.Get(AV69Pgmname+"GridState"), null, "", "");
         AV37GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV37GridState,  "DISPLAYINHERITROLES",  "",  !(false==AV11DisplayInheritRoles),  0,  StringUtil.Trim( StringUtil.BoolToStr( AV11DisplayInheritRoles)),  "",  false,  "",  "") ;
         AV37GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV37GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV37GridState.ToXml(false, true, "", "")) ;
      }

      protected void E191T2( )
      {
         /* Delete_Click Routine */
         returnInSub = false;
         AV6GAMUser.load( AV28UserId);
         AV7isOK = AV6GAMUser.deleterolebyid(AV22Id, out  AV13Errors);
         if ( AV7isOK )
         {
            context.CommitDataStores("gamwwuserroles",pr_default);
            context.DoAjaxRefresh();
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYERRORS' */
            S172 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ManageFiltersData", AV61ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37GridState", AV37GridState);
      }

      protected void E201T2( )
      {
         /* 'DoAdd' Routine */
         returnInSub = false;
         if ( ! (0==AV27RolesId) )
         {
            AV6GAMUser.load( AV28UserId);
            AV7isOK = AV6GAMUser.addrolebyid(AV27RolesId, out  AV13Errors);
            if ( AV7isOK )
            {
               context.CommitDataStores("gamwwuserroles",pr_default);
               context.DoAjaxRefresh();
            }
            else
            {
               /* Execute user subroutine: 'DISPLAYERRORS' */
               S172 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ManageFiltersData", AV61ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37GridState", AV37GridState);
      }

      protected void E211T2( )
      {
         /* Btnmainrole_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV9BtnMainRole, "Main") != 0 )
         {
            AV6GAMUser.load( AV28UserId);
            AV7isOK = AV6GAMUser.setmainrolebyid(AV22Id, out  AV13Errors);
            if ( AV7isOK )
            {
               context.CommitDataStores("gamwwuserroles",pr_default);
               context.DoAjaxRefresh();
            }
            else
            {
               /* Execute user subroutine: 'DISPLAYERRORS' */
               S172 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61ManageFiltersData", AV61ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37GridState", AV37GridState);
      }

      protected void S172( )
      {
         /* 'DISPLAYERRORS' Routine */
         returnInSub = false;
         if ( AV13Errors.Count > 0 )
         {
            AV74GXV5 = 1;
            while ( AV74GXV5 <= AV13Errors.Count )
            {
               AV12Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13Errors.Item(AV74GXV5));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV12Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV12Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV74GXV5 = (int)(AV74GXV5+1);
            }
         }
      }

      protected void wb_table1_21_1T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTopPaddingTop2'>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV61ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_26_1T2( true) ;
         }
         else
         {
            wb_table2_26_1T2( false) ;
         }
         return  ;
      }

      protected void wb_table2_26_1T2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_21_1T2e( true) ;
         }
         else
         {
            wb_table1_21_1T2e( false) ;
         }
      }

      protected void wb_table2_26_1T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellFormGroupMarginBottom5'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+chkavDisplayinheritroles_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_40_idx + "',0)\"";
            ClassString = "AttributeCheckBoxCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDisplayinheritroles_Internalname, StringUtil.BoolToStr( AV11DisplayInheritRoles), "", "", 1, chkavDisplayinheritroles.Enabled, "true", "Display inherited roles", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(31, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,31);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_26_1T2e( true) ;
         }
         else
         {
            wb_table2_26_1T2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV28UserId = (string)getParm(obj,0);
         AssignAttri("", false, "AV28UserId", AV28UserId);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28UserId, "")), context));
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
         PA1T2( ) ;
         WS1T2( ) ;
         WE1T2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267531085", true, true);
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
         context.AddJavascriptSource("gamwwuserroles.js", "?20256267531087", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_402( )
      {
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_40_idx;
         edtavBtnmainrole_Internalname = "vBTNMAINROLE_"+sGXsfl_40_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_40_idx;
         edtavId_Internalname = "vID_"+sGXsfl_40_idx;
         edtavGuid_Internalname = "vGUID_"+sGXsfl_40_idx;
      }

      protected void SubsflControlProps_fel_402( )
      {
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_40_fel_idx;
         edtavBtnmainrole_Internalname = "vBTNMAINROLE_"+sGXsfl_40_fel_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_40_fel_idx;
         edtavId_Internalname = "vID_"+sGXsfl_40_fel_idx;
         edtavGuid_Internalname = "vGUID_"+sGXsfl_40_fel_idx;
      }

      protected void sendrow_402( )
      {
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         WB1T0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_40_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_40_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_40_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV5Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"","'"+""+"'"+",false,"+"'"+"EVDELETE.CLICK."+sGXsfl_40_idx+"'",(string)"",(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavBtnmainrole_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnmainrole_Internalname,StringUtil.RTrim( AV9BtnMainRole),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"","'"+""+"'"+",false,"+"'"+"EVBTNMAINROLE.CLICK."+sGXsfl_40_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavBtnmainrole_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWActionColumn",(string)"",(int)edtavBtnmainrole_Visible,(int)edtavBtnmainrole_Enabled,(short)0,(string)"text",(string)"",(short)120,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV24Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Id), 12, 0, ".", "")),StringUtil.LTrim( ((edtavId_Enabled!=0) ? context.localUtil.Format( (decimal)(AV22Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV22Id), "ZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavGuid_Internalname,StringUtil.RTrim( AV21GUID),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavGuid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavGuid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes1T2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_40_idx = ((subGrid_Islastpage==1)&&(nGXsfl_40_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         /* End function sendrow_402 */
      }

      protected void init_web_controls( )
      {
         chkavDisplayinheritroles.Name = "vDISPLAYINHERITROLES";
         chkavDisplayinheritroles.WebTags = "";
         chkavDisplayinheritroles.Caption = "";
         AssignProp("", false, chkavDisplayinheritroles_Internalname, "TitleCaption", chkavDisplayinheritroles.Caption, true);
         chkavDisplayinheritroles.CheckedValue = "false";
         AV11DisplayInheritRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11DisplayInheritRoles));
         AssignAttri("", false, "AV11DisplayInheritRoles", AV11DisplayInheritRoles);
         /* End function init_web_controls */
      }

      protected void StartGridControl40( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"40\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(120), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtnmainrole_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Role") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Key Numeric Long") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "GUID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV5Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV9BtnMainRole)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnmainrole_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnmainrole_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV24Name)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Id), 12, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV21GUID)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavGuid_Enabled), 5, 0, ".", "")));
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
         bttBtnback_Internalname = "BTNBACK";
         bttBtninsert_Internalname = "BTNINSERT";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         chkavDisplayinheritroles_Internalname = "vDISPLAYINHERITROLES";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheader_Internalname = "TABLEHEADER";
         edtavDelete_Internalname = "vDELETE";
         edtavBtnmainrole_Internalname = "vBTNMAINROLE";
         edtavName_Internalname = "vNAME";
         edtavId_Internalname = "vID";
         edtavGuid_Internalname = "vGUID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
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
         chkavDisplayinheritroles.Caption = "";
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavBtnmainrole_Jsonclick = "";
         edtavBtnmainrole_Enabled = 1;
         edtavBtnmainrole_Visible = -1;
         edtavDelete_Jsonclick = "";
         edtavDelete_Enabled = 1;
         edtavDelete_Visible = -1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         chkavDisplayinheritroles.Enabled = 1;
         bttBtninsert_Visible = 1;
         bttBtnback_Visible = 1;
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Page <CURRENT_PAGE> of <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Roles of user";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"},{"av":"AV28UserId","fld":"vUSERID","hsh":true},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV27RolesId","fld":"vROLESID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV61ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV37GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E121T2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"},{"av":"AV28UserId","fld":"vUSERID","hsh":true},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV27RolesId","fld":"vROLESID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E131T2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"},{"av":"AV28UserId","fld":"vUSERID","hsh":true},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV27RolesId","fld":"vROLESID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E181T2","iparms":[{"av":"AV28UserId","fld":"vUSERID","hsh":true},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV5Delete","fld":"vDELETE"},{"av":"AV9BtnMainRole","fld":"vBTNMAINROLE","hsh":true},{"av":"AV18GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV24Name","fld":"vNAME"},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV21GUID","fld":"vGUID"},{"av":"AV22Id","fld":"vID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"edtavBtnmainrole_Visible","ctrl":"vBTNMAINROLE","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E111T2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"},{"av":"AV28UserId","fld":"vUSERID","hsh":true},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV27RolesId","fld":"vROLESID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV37GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV37GridState","fld":"vGRIDSTATE"},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV61ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOBACK'","""{"handler":"E141T2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"},{"av":"AV28UserId","fld":"vUSERID","hsh":true},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV27RolesId","fld":"vROLESID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOBACK'",""","oparms":[{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV61ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV37GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E151T2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"},{"av":"AV28UserId","fld":"vUSERID","hsh":true},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV27RolesId","fld":"vROLESID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV61ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV37GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VDELETE.CLICK","""{"handler":"E191T2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"},{"av":"AV28UserId","fld":"vUSERID","hsh":true},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV27RolesId","fld":"vROLESID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV22Id","fld":"vID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VDELETE.CLICK",""","oparms":[{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV61ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV37GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOADD'","""{"handler":"E201T2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"},{"av":"AV28UserId","fld":"vUSERID","hsh":true},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV27RolesId","fld":"vROLESID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOADD'",""","oparms":[{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV61ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV37GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VBTNMAINROLE.CLICK","""{"handler":"E211T2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV11DisplayInheritRoles","fld":"vDISPLAYINHERITROLES"},{"av":"AV28UserId","fld":"vUSERID","hsh":true},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV27RolesId","fld":"vROLESID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV9BtnMainRole","fld":"vBTNMAINROLE","hsh":true},{"av":"AV22Id","fld":"vID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VBTNMAINROLE.CLICK",""","oparms":[{"av":"AV57ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV64GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV66GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV67IsAuthorized_Back","fld":"vISAUTHORIZED_BACK","hsh":true},{"ctrl":"BTNBACK","prop":"Visible"},{"av":"AV68IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV61ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV37GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Guid","iparms":[]}""");
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
         wcpOAV28UserId = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV69Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV61ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV66GridAppliedFilters = "";
         AV37GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnback_Jsonclick = "";
         bttBtninsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5Delete = "";
         AV9BtnMainRole = "";
         AV24Name = "";
         AV21GUID = "";
         AV33HTTPRequest = new GxHttpRequest( context);
         AV6GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV29UserName = "";
         AV34WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16GAMRoles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV13Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV26Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         GridRow = new GXWebRow();
         AV17GAMRolesDirect = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV15GAMRoleAux = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV58ManageFiltersXml = "";
         GXt_char1 = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV56Session = context.GetSession();
         AV38GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV12Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamwwuserroles__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamwwuserroles__default(),
            new Object[][] {
            }
         );
         AV69Pgmname = "GAMWWUserRoles";
         /* GeneXus formulas. */
         AV69Pgmname = "GAMWWUserRoles";
         edtavDelete_Enabled = 0;
         edtavBtnmainrole_Enabled = 0;
         edtavName_Enabled = 0;
         edtavId_Enabled = 0;
         edtavGuid_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV57ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
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
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_40 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_40_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnback_Visible ;
      private int bttBtninsert_Visible ;
      private int subGrid_Islastpage ;
      private int edtavDelete_Enabled ;
      private int edtavBtnmainrole_Enabled ;
      private int edtavName_Enabled ;
      private int edtavId_Enabled ;
      private int edtavGuid_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int AV25PageToGo ;
      private int AV70GXV1 ;
      private int edtavDelete_Visible ;
      private int AV71GXV2 ;
      private int AV72GXV3 ;
      private int edtavBtnmainrole_Visible ;
      private int AV73GXV4 ;
      private int AV74GXV5 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV27RolesId ;
      private long AV64GridCurrentPage ;
      private long AV18GridPageCount ;
      private long AV22Id ;
      private long GRID_nCurrentRecord ;
      private long AV19GridPageSize ;
      private long AV20GridRecordCount ;
      private string AV28UserId ;
      private string wcpOAV28UserId ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_40_idx="0001" ;
      private string AV69Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnback_Internalname ;
      private string bttBtnback_Jsonclick ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV5Delete ;
      private string edtavDelete_Internalname ;
      private string AV9BtnMainRole ;
      private string edtavBtnmainrole_Internalname ;
      private string AV24Name ;
      private string edtavName_Internalname ;
      private string edtavId_Internalname ;
      private string AV21GUID ;
      private string edtavGuid_Internalname ;
      private string chkavDisplayinheritroles_Internalname ;
      private string AV29UserName ;
      private string GXt_char1 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string sGXsfl_40_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDelete_Jsonclick ;
      private string edtavBtnmainrole_Jsonclick ;
      private string edtavName_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string edtavGuid_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11DisplayInheritRoles ;
      private bool AV67IsAuthorized_Back ;
      private bool AV68IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_40_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV23isDirectRole ;
      private bool GXt_boolean2 ;
      private bool AV7isOK ;
      private string AV58ManageFiltersXml ;
      private string AV66GridAppliedFilters ;
      private IGxSession AV56Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV33HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavDisplayinheritroles ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV61ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV6GAMUser ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV34WWPContext ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV16GAMRoles ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV14GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV26Role ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV17GAMRolesDirect ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV15GAMRoleAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV12Error ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamwwuserroles__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamwwuserroles__default : DataStoreHelperBase, IDataStoreHelper
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
