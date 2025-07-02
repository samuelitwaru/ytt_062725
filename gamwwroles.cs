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
   public class gamwwroles : GXDataArea
   {
      public gamwwroles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamwwroles( IGxContext context )
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
         cmbavGridactions = new GXCombobox();
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
         nRC_GXsfl_38 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
         edtavBtnrole_Title = GetNextPar( );
         AssignProp("", false, edtavBtnrole_Internalname, "Title", edtavBtnrole_Title, !bGXsfl_38_Refreshing);
         edtavBtnprm_Title = GetNextPar( );
         AssignProp("", false, edtavBtnprm_Internalname, "Title", edtavBtnprm_Title, !bGXsfl_38_Refreshing);
         edtavBtnsaveas_Title = GetNextPar( );
         AssignProp("", false, edtavBtnsaveas_Internalname, "Title", edtavBtnsaveas_Title, !bGXsfl_38_Refreshing);
         edtavBtntranslations_Title = GetNextPar( );
         AssignProp("", false, edtavBtntranslations_Internalname, "Title", edtavBtntranslations_Title, !bGXsfl_38_Refreshing);
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
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV60Pgmname = GetPar( "Pgmname");
         AV15FilName = GetPar( "FilName");
         edtavBtnrole_Title = GetNextPar( );
         AssignProp("", false, edtavBtnrole_Internalname, "Title", edtavBtnrole_Title, !bGXsfl_38_Refreshing);
         edtavBtnprm_Title = GetNextPar( );
         AssignProp("", false, edtavBtnprm_Internalname, "Title", edtavBtnprm_Title, !bGXsfl_38_Refreshing);
         edtavBtnsaveas_Title = GetNextPar( );
         AssignProp("", false, edtavBtnsaveas_Internalname, "Title", edtavBtnsaveas_Title, !bGXsfl_38_Refreshing);
         edtavBtntranslations_Title = GetNextPar( );
         AssignProp("", false, edtavBtntranslations_Internalname, "Title", edtavBtntranslations_Title, !bGXsfl_38_Refreshing);
         AV14FilExternalId = GetPar( "FilExternalId");
         AV54IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV55IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV56IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV21IsAuthorized_BtnRole = StringUtil.StrToBool( GetPar( "IsAuthorized_BtnRole"));
         AV20IsAuthorized_BtnPrm = StringUtil.StrToBool( GetPar( "IsAuthorized_BtnPrm"));
         AV23IsAuthorized_Name = StringUtil.StrToBool( GetPar( "IsAuthorized_Name"));
         AV59IsAuthorized_BtnTranslations = StringUtil.StrToBool( GetPar( "IsAuthorized_BtnTranslations"));
         AV57IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV43ManageFiltersExecutionStep, AV60Pgmname, AV15FilName, AV14FilExternalId, AV54IsAuthorized_Display, AV55IsAuthorized_Update, AV56IsAuthorized_Delete, AV21IsAuthorized_BtnRole, AV20IsAuthorized_BtnPrm, AV23IsAuthorized_Name, AV59IsAuthorized_BtnTranslations, AV57IsAuthorized_Insert) ;
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
            return "gamwwroles_Execute" ;
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
         PA1Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1Q2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamwwroles.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vFILEXTERNALID", StringUtil.RTrim( AV14FilExternalId));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILEXTERNALID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14FilExternalId, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV54IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV54IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNROLE", AV21IsAuthorized_BtnRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV21IsAuthorized_BtnRole, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNPRM", AV20IsAuthorized_BtnPrm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPRM", GetSecureSignedToken( "", AV20IsAuthorized_BtnPrm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NAME", AV23IsAuthorized_Name);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV23IsAuthorized_Name, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNTRANSLATIONS", AV59IsAuthorized_BtnTranslations);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNTRANSLATIONS", GetSecureSignedToken( "", AV59IsAuthorized_BtnTranslations, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_38), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV47ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV47ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV51GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vFILEXTERNALID", StringUtil.RTrim( AV14FilExternalId));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILEXTERNALID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14FilExternalId, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV54IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV54IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNROLE", AV21IsAuthorized_BtnRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV21IsAuthorized_BtnRole, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNPRM", AV20IsAuthorized_BtnPrm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPRM", GetSecureSignedToken( "", AV20IsAuthorized_BtnPrm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NAME", AV23IsAuthorized_Name);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV23IsAuthorized_Name, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV40GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV40GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNTRANSLATIONS", AV59IsAuthorized_BtnTranslations);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNTRANSLATIONS", GetSecureSignedToken( "", AV59IsAuthorized_BtnTranslations, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "vBTNROLE_Title", StringUtil.RTrim( edtavBtnrole_Title));
         GxWebStd.gx_hidden_field( context, "vBTNPRM_Title", StringUtil.RTrim( edtavBtnprm_Title));
         GxWebStd.gx_hidden_field( context, "vBTNSAVEAS_Title", StringUtil.RTrim( edtavBtnsaveas_Title));
         GxWebStd.gx_hidden_field( context, "vBTNTRANSLATIONS_Title", StringUtil.RTrim( edtavBtntranslations_Title));
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
            WE1Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1Q2( ) ;
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
         return formatLink("gamwwroles.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "GAMWWRoles" ;
      }

      public override string GetPgmdesc( )
      {
         return "Roles" ;
      }

      protected void WB1Q0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColorFilledActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(38), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWRoles.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6 CellFloatRight CellWidthAuto", "start", "top", "", "", "div");
            wb_table1_19_1Q2( true) ;
         }
         else
         {
            wb_table1_19_1Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_19_1Q2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell CellMarginTop HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl38( ) ;
         }
         if ( wbEnd == 38 )
         {
            wbEnd = 0;
            nRC_GXsfl_38 = (int)(nGXsfl_38_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV49GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV17GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV51GridAppliedFilters);
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
         if ( wbEnd == 38 )
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

      protected void START1Q2( )
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
         Form.Meta.addItem("description", "Roles", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1Q0( ) ;
      }

      protected void WS1Q2( )
      {
         START1Q2( ) ;
         EVT1Q2( ) ;
      }

      protected void EVT1Q2( )
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
                              E111Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E121Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E131Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E141Q2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "VBTNTRANSLATIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "VBTNSAVEAS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "VBTNSAVEAS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "VBTNTRANSLATIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
                              SubsflControlProps_382( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV50GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV50GridActions), 4, 0));
                              AV9BtnRole = cgiGet( edtavBtnrole_Internalname);
                              AssignAttri("", false, edtavBtnrole_Internalname, AV9BtnRole);
                              AV8BtnPrm = cgiGet( edtavBtnprm_Internalname);
                              AssignAttri("", false, edtavBtnprm_Internalname, AV8BtnPrm);
                              AV31BtnSaveAs = cgiGet( edtavBtnsaveas_Internalname);
                              AssignAttri("", false, edtavBtnsaveas_Internalname, AV31BtnSaveAs);
                              AV58BtnTranslations = cgiGet( edtavBtntranslations_Internalname);
                              AssignAttri("", false, edtavBtntranslations_Internalname, AV58BtnTranslations);
                              AV24Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV24Name);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
                                 GX_FocusControl = edtavId_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV18Id = 0;
                                 AssignAttri("", false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV18Id), 12, 0));
                              }
                              else
                              {
                                 AV18Id = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV18Id), 12, 0));
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
                                    E151Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E161Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E171Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E181Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VBTNTRANSLATIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E191Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VBTNSAVEAS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E201Q2 ();
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

      protected void WE1Q2( )
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

      protected void PA1Q2( )
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
               GX_FocusControl = edtavFilname_Internalname;
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
         SubsflControlProps_382( ) ;
         while ( nGXsfl_38_idx <= nRC_GXsfl_38 )
         {
            sendrow_382( ) ;
            nGXsfl_38_idx = ((subGrid_Islastpage==1)&&(nGXsfl_38_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV43ManageFiltersExecutionStep ,
                                       string AV60Pgmname ,
                                       string AV15FilName ,
                                       string AV14FilExternalId ,
                                       bool AV54IsAuthorized_Display ,
                                       bool AV55IsAuthorized_Update ,
                                       bool AV56IsAuthorized_Delete ,
                                       bool AV21IsAuthorized_BtnRole ,
                                       bool AV20IsAuthorized_BtnPrm ,
                                       bool AV23IsAuthorized_Name ,
                                       bool AV59IsAuthorized_BtnTranslations ,
                                       bool AV57IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1Q2( ) ;
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
         RF1Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV60Pgmname = "GAMWWRoles";
         edtavBtnrole_Enabled = 0;
         edtavBtnprm_Enabled = 0;
         edtavBtnsaveas_Enabled = 0;
         edtavBtntranslations_Enabled = 0;
         edtavName_Enabled = 0;
         edtavId_Enabled = 0;
      }

      protected void RF1Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 38;
         /* Execute user event: Refresh */
         E161Q2 ();
         nGXsfl_38_idx = 1;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_382( ) ;
         bGXsfl_38_Refreshing = true;
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
            SubsflControlProps_382( ) ;
            /* Execute user event: Grid.Load */
            E171Q2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_38_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E171Q2 ();
            }
            wbEnd = 38;
            WB1Q0( ) ;
         }
         bGXsfl_38_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1Q2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vFILEXTERNALID", StringUtil.RTrim( AV14FilExternalId));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILEXTERNALID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14FilExternalId, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV54IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV54IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNROLE", AV21IsAuthorized_BtnRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV21IsAuthorized_BtnRole, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNPRM", AV20IsAuthorized_BtnPrm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPRM", GetSecureSignedToken( "", AV20IsAuthorized_BtnPrm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NAME", AV23IsAuthorized_Name);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV23IsAuthorized_Name, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BTNTRANSLATIONS", AV59IsAuthorized_BtnTranslations);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNTRANSLATIONS", GetSecureSignedToken( "", AV59IsAuthorized_BtnTranslations, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
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
            gxgrGrid_refresh( subGrid_Rows, AV43ManageFiltersExecutionStep, AV60Pgmname, AV15FilName, AV14FilExternalId, AV54IsAuthorized_Display, AV55IsAuthorized_Update, AV56IsAuthorized_Delete, AV21IsAuthorized_BtnRole, AV20IsAuthorized_BtnPrm, AV23IsAuthorized_Name, AV59IsAuthorized_BtnTranslations, AV57IsAuthorized_Insert) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV43ManageFiltersExecutionStep, AV60Pgmname, AV15FilName, AV14FilExternalId, AV54IsAuthorized_Display, AV55IsAuthorized_Update, AV56IsAuthorized_Delete, AV21IsAuthorized_BtnRole, AV20IsAuthorized_BtnPrm, AV23IsAuthorized_Name, AV59IsAuthorized_BtnTranslations, AV57IsAuthorized_Insert) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV43ManageFiltersExecutionStep, AV60Pgmname, AV15FilName, AV14FilExternalId, AV54IsAuthorized_Display, AV55IsAuthorized_Update, AV56IsAuthorized_Delete, AV21IsAuthorized_BtnRole, AV20IsAuthorized_BtnPrm, AV23IsAuthorized_Name, AV59IsAuthorized_BtnTranslations, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV43ManageFiltersExecutionStep, AV60Pgmname, AV15FilName, AV14FilExternalId, AV54IsAuthorized_Display, AV55IsAuthorized_Update, AV56IsAuthorized_Delete, AV21IsAuthorized_BtnRole, AV20IsAuthorized_BtnPrm, AV23IsAuthorized_Name, AV59IsAuthorized_BtnTranslations, AV57IsAuthorized_Insert) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV43ManageFiltersExecutionStep, AV60Pgmname, AV15FilName, AV14FilExternalId, AV54IsAuthorized_Display, AV55IsAuthorized_Update, AV56IsAuthorized_Delete, AV21IsAuthorized_BtnRole, AV20IsAuthorized_BtnPrm, AV23IsAuthorized_Name, AV59IsAuthorized_BtnTranslations, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV60Pgmname = "GAMWWRoles";
         edtavBtnrole_Enabled = 0;
         edtavBtnprm_Enabled = 0;
         edtavBtnsaveas_Enabled = 0;
         edtavBtntranslations_Enabled = 0;
         edtavName_Enabled = 0;
         edtavId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E151Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV47ManageFiltersData);
            /* Read saved values. */
            nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), ".", ","), 18, MidpointRounding.ToEven));
            AV49GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV17GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV51GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV15FilName = cgiGet( edtavFilname_Internalname);
            AssignAttri("", false, "AV15FilName", AV15FilName);
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
         E151Q2 ();
         if (returnInSub) return;
      }

      protected void E151Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV36HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         GXt_boolean1 = AV23IsAuthorized_Name;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamroleentry_Execute", out  GXt_boolean1) ;
         AV23IsAuthorized_Name = GXt_boolean1;
         AssignAttri("", false, "AV23IsAuthorized_Name", AV23IsAuthorized_Name);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NAME", GetSecureSignedToken( "", AV23IsAuthorized_Name, context));
         Form.Caption = "Roles";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         edtavBtnrole_Title = "Children";
         AssignProp("", false, edtavBtnrole_Internalname, "Title", edtavBtnrole_Title, !bGXsfl_38_Refreshing);
         edtavBtnprm_Title = "Permissions";
         AssignProp("", false, edtavBtnprm_Internalname, "Title", edtavBtnprm_Title, !bGXsfl_38_Refreshing);
         edtavBtnsaveas_Title = "Copy";
         AssignProp("", false, edtavBtnsaveas_Internalname, "Title", edtavBtnsaveas_Title, !bGXsfl_38_Refreshing);
         edtavBtntranslations_Title = "Translations";
         AssignProp("", false, edtavBtntranslations_Internalname, "Title", edtavBtntranslations_Title, !bGXsfl_38_Refreshing);
      }

      protected void E161Q2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV37WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         if ( AV43ManageFiltersExecutionStep == 1 )
         {
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV43ManageFiltersExecutionStep == 2 )
         {
            AV43ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         AV49GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV49GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV49GridCurrentPage), 10, 0));
         GXt_char2 = AV51GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV60Pgmname, out  GXt_char2) ;
         AV51GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV51GridAppliedFilters", AV51GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40GridState", AV40GridState);
      }

      protected void E121Q2( )
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

      protected void E131Q2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E171Q2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV29GridPageSize = subGrid_Rows;
         AV16Filter.gxTpr_Name = "%"+AV15FilName;
         AV16Filter.gxTpr_Externalid = "%"+AV14FilExternalId;
         AV28GAMRoles = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getroles(AV16Filter, out  AV13Errors);
         if ( AV28GAMRoles.Count == 0 )
         {
            AV17GridPageCount = 0;
            AssignAttri("", false, "AV17GridPageCount", StringUtil.LTrimStr( (decimal)(AV17GridPageCount), 10, 0));
         }
         else
         {
            AV17GridPageCount = (long)((AV28GAMRoles.Count/ (decimal)(AV29GridPageSize))+((((int)((AV28GAMRoles.Count) % (AV29GridPageSize)))>0) ? 1 : 0));
            AssignAttri("", false, "AV17GridPageCount", StringUtil.LTrimStr( (decimal)(AV17GridPageCount), 10, 0));
         }
         AV30GridRecordCount = AV28GAMRoles.Count;
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV28GAMRoles.Count )
         {
            AV26Role = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV28GAMRoles.Item(AV61GXV1));
            AV18Id = AV26Role.gxTpr_Id;
            AssignAttri("", false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV18Id), 12, 0));
            AV24Name = AV26Role.gxTpr_Name;
            AssignAttri("", false, edtavName_Internalname, AV24Name);
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            if ( AV54IsAuthorized_Display )
            {
               cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Display", "fa fa-search", "", "", "", "", "", "", ""), 0);
            }
            if ( AV55IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Update", "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV56IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", "Delete", "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            if ( cmbavGridactions.ItemCount == 1 )
            {
               cmbavGridactions_Class = "Invisible";
            }
            else
            {
               cmbavGridactions_Class = "ConvertToDDO";
            }
            AV9BtnRole = "<i class=\"fa fa-cog\"></i>";
            AssignAttri("", false, edtavBtnrole_Internalname, AV9BtnRole);
            if ( AV21IsAuthorized_BtnRole )
            {
               edtavBtnrole_Link = formatLink("gamwwroleroles.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV18Id,12,0)),UrlEncode(StringUtil.LTrimStr(AV18Id,12,0))}, new string[] {"RoleId","RoleIdAux"}) ;
            }
            AV8BtnPrm = "<i class=\"fa fa-lock\"></i>";
            AssignAttri("", false, edtavBtnprm_Internalname, AV8BtnPrm);
            if ( AV20IsAuthorized_BtnPrm )
            {
               edtavBtnprm_Link = formatLink("gamwwrolepermissions.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV18Id,12,0)),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"RoleId","pApplicationId"}) ;
            }
            AV31BtnSaveAs = "<i class=\"fas fa-copy\"></i>";
            AssignAttri("", false, edtavBtnsaveas_Internalname, AV31BtnSaveAs);
            AV58BtnTranslations = "<i class=\"fas fa-globe\"></i>";
            AssignAttri("", false, edtavBtntranslations_Internalname, AV58BtnTranslations);
            if ( AV23IsAuthorized_Name )
            {
               edtavName_Link = formatLink("gamroleentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(AV18Id,12,0))}, new string[] {"Mode","Id"}) ;
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 38;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_382( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            subGrid_Recordcount = (int)(GRID_nCurrentRecord);
            if ( isFullAjaxMode( ) && ! bGXsfl_38_Refreshing )
            {
               DoAjaxLoad(38, GridRow);
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16Filter", AV16Filter);
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActions), 4, 0));
      }

      protected void E111Q2( )
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
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("GAMWWRolesFilters")),UrlEncode(StringUtil.RTrim(AV60Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("GAMWWRolesFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV44ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "GAMWWRolesFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV44ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S152 ();
               if (returnInSub) return;
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV44ManageFiltersXml) ;
               AV40GridState.FromXml(AV44ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S162 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40GridState", AV40GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
      }

      protected void E181Q2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV50GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S172 ();
            if (returnInSub) return;
         }
         else if ( AV50GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S182 ();
            if (returnInSub) return;
         }
         else if ( AV50GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S192 ();
            if (returnInSub) return;
         }
         AV50GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV50GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40GridState", AV40GridState);
      }

      protected void E191Q2( )
      {
         /* Btntranslations_Click Routine */
         returnInSub = false;
         if ( AV59IsAuthorized_BtnTranslations )
         {
            context.PopUp(formatLink("gamtranslations.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim("Role")),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.LTrimStr(AV18Id,12,0)),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","Type","Title","PrimaryID","SecondaryID","TertiaryID"}) , new Object[] {});
            context.DoAjaxRefresh();
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40GridState", AV40GridState);
      }

      protected void E141Q2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV57IsAuthorized_Insert )
         {
            CallWebObject(formatLink("gamroleentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","Id"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40GridState", AV40GridState);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV54IsAuthorized_Display;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamroleentry_Execute", out  GXt_boolean1) ;
         AV54IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV54IsAuthorized_Display", AV54IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV54IsAuthorized_Display, context));
         GXt_boolean1 = AV55IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamroleentry_Execute", out  GXt_boolean1) ;
         AV55IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV55IsAuthorized_Update", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GXt_boolean1 = AV56IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamroleentry_Execute", out  GXt_boolean1) ;
         AV56IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV56IsAuthorized_Delete", AV56IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV56IsAuthorized_Delete, context));
         GXt_boolean1 = AV21IsAuthorized_BtnRole;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamwwroleroles_Execute", out  GXt_boolean1) ;
         AV21IsAuthorized_BtnRole = GXt_boolean1;
         AssignAttri("", false, "AV21IsAuthorized_BtnRole", AV21IsAuthorized_BtnRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNROLE", GetSecureSignedToken( "", AV21IsAuthorized_BtnRole, context));
         if ( ! ( AV21IsAuthorized_BtnRole ) )
         {
            edtavBtnrole_Visible = 0;
            AssignProp("", false, edtavBtnrole_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnrole_Visible), 5, 0), !bGXsfl_38_Refreshing);
         }
         GXt_boolean1 = AV20IsAuthorized_BtnPrm;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamwwrolepermissions_Execute", out  GXt_boolean1) ;
         AV20IsAuthorized_BtnPrm = GXt_boolean1;
         AssignAttri("", false, "AV20IsAuthorized_BtnPrm", AV20IsAuthorized_BtnPrm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNPRM", GetSecureSignedToken( "", AV20IsAuthorized_BtnPrm, context));
         if ( ! ( AV20IsAuthorized_BtnPrm ) )
         {
            edtavBtnprm_Visible = 0;
            AssignProp("", false, edtavBtnprm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtnprm_Visible), 5, 0), !bGXsfl_38_Refreshing);
         }
         GXt_boolean1 = AV59IsAuthorized_BtnTranslations;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamexampleroleselect_Execute", out  GXt_boolean1) ;
         AV59IsAuthorized_BtnTranslations = GXt_boolean1;
         AssignAttri("", false, "AV59IsAuthorized_BtnTranslations", AV59IsAuthorized_BtnTranslations);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BTNTRANSLATIONS", GetSecureSignedToken( "", AV59IsAuthorized_BtnTranslations, context));
         if ( ! ( AV59IsAuthorized_BtnTranslations ) )
         {
            edtavBtntranslations_Visible = 0;
            AssignProp("", false, edtavBtntranslations_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBtntranslations_Visible), 5, 0), !bGXsfl_38_Refreshing);
         }
         GXt_boolean1 = AV57IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "gamroleentry_Execute", out  GXt_boolean1) ;
         AV57IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV57IsAuthorized_Insert", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
         if ( ! ( AV57IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV47ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "GAMWWRolesFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV47ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S152( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilName = "";
         AssignAttri("", false, "AV15FilName", AV15FilName);
      }

      protected void S172( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV54IsAuthorized_Display )
         {
            CallWebObject(formatLink("gamroleentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(AV18Id,12,0))}, new string[] {"Mode","Id"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
      }

      protected void S182( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV55IsAuthorized_Update )
         {
            CallWebObject(formatLink("gamroleentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(AV18Id,12,0))}, new string[] {"Mode","Id"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
      }

      protected void S192( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV56IsAuthorized_Delete )
         {
            CallWebObject(formatLink("gamroleentry.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(AV18Id,12,0))}, new string[] {"Mode","Id"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get(AV60Pgmname+"GridState"), "") == 0 )
         {
            AV40GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV60Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV42Session.Get(AV60Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S162 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV40GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV40GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV40GridState.gxTpr_Currentpage) ;
      }

      protected void S162( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV62GXV2 = 1;
         while ( AV62GXV2 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV62GXV2));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILNAME") == 0 )
            {
               AV15FilName = AV41GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilName", AV15FilName);
            }
            AV62GXV2 = (int)(AV62GXV2+1);
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV40GridState.FromXml(AV42Session.Get(AV60Pgmname+"GridState"), null, "", "");
         AV40GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV40GridState,  "FILNAME",  "Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilName)),  0,  AV15FilName,  AV15FilName,  false,  "",  "") ;
         AV40GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV40GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV40GridState.ToXml(false, true, "", "")) ;
      }

      protected void E201Q2( )
      {
         /* Btnsaveas_Click Routine */
         returnInSub = false;
         AV26Role.load( AV18Id);
         AV32isOK = AV26Role.saveas(out  AV33NewGAMRole, out  AV13Errors);
         if ( AV32isOK )
         {
            context.CommitDataStores("gamwwroles",pr_default);
            context.DoAjaxRefresh();
         }
         else
         {
            AV63GXV3 = 1;
            while ( AV63GXV3 <= AV13Errors.Count )
            {
               AV12Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13Errors.Item(AV63GXV3));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV12Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV12Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV63GXV3 = (int)(AV63GXV3+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40GridState", AV40GridState);
      }

      protected void wb_table1_19_1Q2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV47ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_24_1Q2( true) ;
         }
         else
         {
            wb_table2_24_1Q2( false) ;
         }
         return  ;
      }

      protected void wb_table2_24_1Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_19_1Q2e( true) ;
         }
         else
         {
            wb_table1_19_1Q2e( false) ;
         }
      }

      protected void wb_table2_24_1Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellFormGroupMarginBottom5'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavFilname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilname_Internalname, "Name", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_38_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilname_Internalname, StringUtil.RTrim( AV15FilName), StringUtil.RTrim( context.localUtil.Format( AV15FilName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilname_Enabled, 0, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMWWRoles.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_24_1Q2e( true) ;
         }
         else
         {
            wb_table2_24_1Q2e( false) ;
         }
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
         PA1Q2( ) ;
         WS1Q2( ) ;
         WE1Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025712113843", true, true);
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
         context.AddJavascriptSource("gamwwroles.js", "?2025712113845", false, true);
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

      protected void SubsflControlProps_382( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_38_idx;
         edtavBtnrole_Internalname = "vBTNROLE_"+sGXsfl_38_idx;
         edtavBtnprm_Internalname = "vBTNPRM_"+sGXsfl_38_idx;
         edtavBtnsaveas_Internalname = "vBTNSAVEAS_"+sGXsfl_38_idx;
         edtavBtntranslations_Internalname = "vBTNTRANSLATIONS_"+sGXsfl_38_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_38_idx;
         edtavId_Internalname = "vID_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_382( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_38_fel_idx;
         edtavBtnrole_Internalname = "vBTNROLE_"+sGXsfl_38_fel_idx;
         edtavBtnprm_Internalname = "vBTNPRM_"+sGXsfl_38_fel_idx;
         edtavBtnsaveas_Internalname = "vBTNSAVEAS_"+sGXsfl_38_fel_idx;
         edtavBtntranslations_Internalname = "vBTNTRANSLATIONS_"+sGXsfl_38_fel_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_38_fel_idx;
         edtavId_Internalname = "vID_"+sGXsfl_38_fel_idx;
      }

      protected void sendrow_382( )
      {
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_382( ) ;
         WB1Q0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_38_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_38_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_38_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_38_idx + "',38)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_38_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV50GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV50GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_38_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactions_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_38_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavBtnrole_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnrole_Internalname,StringUtil.RTrim( AV9BtnRole),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavBtnrole_Link,(string)"",(string)"Roles",(string)"",(string)edtavBtnrole_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs",(string)"",(int)edtavBtnrole_Visible,(int)edtavBtnrole_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavBtnprm_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnprm_Internalname,StringUtil.RTrim( AV8BtnPrm),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavBtnprm_Link,(string)"",(string)"Permissions",(string)"",(string)edtavBtnprm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs",(string)"",(int)edtavBtnprm_Visible,(int)edtavBtnprm_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnsaveas_Internalname,StringUtil.RTrim( AV31BtnSaveAs),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"","'"+""+"'"+",false,"+"'"+"EVBTNSAVEAS.CLICK."+sGXsfl_38_idx+"'",(string)"",(string)"",(string)"Copy",(string)"",(string)edtavBtnsaveas_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs",(string)"",(short)-1,(int)edtavBtnsaveas_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavBtntranslations_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtntranslations_Internalname,StringUtil.RTrim( AV58BtnTranslations),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"","'"+""+"'"+",false,"+"'"+"EVBTNTRANSLATIONS.CLICK."+sGXsfl_38_idx+"'",(string)"",(string)"",(string)"Translations",(string)"",(string)edtavBtntranslations_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavBtntranslations_Visible,(int)edtavBtntranslations_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV24Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavName_Link,(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Id), 12, 0, ".", "")),StringUtil.LTrim( ((edtavId_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18Id), "ZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes1Q2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_38_idx = ((subGrid_Islastpage==1)&&(nGXsfl_38_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
         }
         /* End function sendrow_382 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_38_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV50GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV50GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl38( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"38\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavGridactions_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtnrole_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( edtavBtnrole_Title) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtnprm_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( edtavBtnprm_Title) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( edtavBtnsaveas_Title) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavBtntranslations_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( edtavBtntranslations_Title) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactions_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV9BtnRole)));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavBtnrole_Title));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnrole_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavBtnrole_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnrole_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV8BtnPrm)));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavBtnprm_Title));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnprm_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavBtnprm_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnprm_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV31BtnSaveAs)));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavBtnsaveas_Title));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnsaveas_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV58BtnTranslations)));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavBtntranslations_Title));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtntranslations_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtntranslations_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV24Name)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Id), 12, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
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
         bttBtninsert_Internalname = "BTNINSERT";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilname_Internalname = "vFILNAME";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtavBtnrole_Internalname = "vBTNROLE";
         edtavBtnprm_Internalname = "vBTNPRM";
         edtavBtnsaveas_Internalname = "vBTNSAVEAS";
         edtavBtntranslations_Internalname = "vBTNTRANSLATIONS";
         edtavName_Internalname = "vNAME";
         edtavId_Internalname = "vID";
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
         edtavId_Jsonclick = "";
         edtavId_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Link = "";
         edtavName_Enabled = 1;
         edtavBtntranslations_Jsonclick = "";
         edtavBtntranslations_Enabled = 1;
         edtavBtnsaveas_Jsonclick = "";
         edtavBtnsaveas_Enabled = 1;
         edtavBtnprm_Jsonclick = "";
         edtavBtnprm_Link = "";
         edtavBtnprm_Enabled = 1;
         edtavBtnrole_Jsonclick = "";
         edtavBtnrole_Link = "";
         edtavBtnrole_Enabled = 1;
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions_Class = "ConvertToDDO";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilname_Jsonclick = "";
         edtavFilname_Enabled = 1;
         edtavBtntranslations_Visible = -1;
         edtavBtnprm_Visible = -1;
         edtavBtnrole_Visible = -1;
         bttBtninsert_Visible = 1;
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
         Form.Caption = "Roles";
         edtavBtntranslations_Title = "";
         edtavBtnsaveas_Title = "";
         edtavBtnprm_Title = "";
         edtavBtnrole_Title = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"edtavBtnrole_Title","ctrl":"vBTNROLE","prop":"Title"},{"av":"edtavBtnprm_Title","ctrl":"vBTNPRM","prop":"Title"},{"av":"edtavBtnsaveas_Title","ctrl":"vBTNSAVEAS","prop":"Title"},{"av":"edtavBtntranslations_Title","ctrl":"vBTNTRANSLATIONS","prop":"Title"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilName","fld":"vFILNAME"},{"av":"AV14FilExternalId","fld":"vFILEXTERNALID","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"AV23IsAuthorized_Name","fld":"vISAUTHORIZED_NAME","hsh":true},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV51GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"edtavBtnrole_Visible","ctrl":"vBTNROLE","prop":"Visible"},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"edtavBtnprm_Visible","ctrl":"vBTNPRM","prop":"Visible"},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"edtavBtntranslations_Visible","ctrl":"vBTNTRANSLATIONS","prop":"Visible"},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV47ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV40GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E121Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilName","fld":"vFILNAME"},{"av":"edtavBtnrole_Title","ctrl":"vBTNROLE","prop":"Title"},{"av":"edtavBtnprm_Title","ctrl":"vBTNPRM","prop":"Title"},{"av":"edtavBtnsaveas_Title","ctrl":"vBTNSAVEAS","prop":"Title"},{"av":"edtavBtntranslations_Title","ctrl":"vBTNTRANSLATIONS","prop":"Title"},{"av":"AV14FilExternalId","fld":"vFILEXTERNALID","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"AV23IsAuthorized_Name","fld":"vISAUTHORIZED_NAME","hsh":true},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E131Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilName","fld":"vFILNAME"},{"av":"edtavBtnrole_Title","ctrl":"vBTNROLE","prop":"Title"},{"av":"edtavBtnprm_Title","ctrl":"vBTNPRM","prop":"Title"},{"av":"edtavBtnsaveas_Title","ctrl":"vBTNSAVEAS","prop":"Title"},{"av":"edtavBtntranslations_Title","ctrl":"vBTNTRANSLATIONS","prop":"Title"},{"av":"AV14FilExternalId","fld":"vFILEXTERNALID","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"AV23IsAuthorized_Name","fld":"vISAUTHORIZED_NAME","hsh":true},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E171Q2","iparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15FilName","fld":"vFILNAME"},{"av":"AV14FilExternalId","fld":"vFILEXTERNALID","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"AV23IsAuthorized_Name","fld":"vISAUTHORIZED_NAME","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV17GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV18Id","fld":"vID","pic":"ZZZZZZZZZZZ9"},{"av":"AV24Name","fld":"vNAME"},{"av":"cmbavGridactions"},{"av":"AV50GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"},{"av":"AV9BtnRole","fld":"vBTNROLE"},{"av":"edtavBtnrole_Link","ctrl":"vBTNROLE","prop":"Link"},{"av":"AV8BtnPrm","fld":"vBTNPRM"},{"av":"edtavBtnprm_Link","ctrl":"vBTNPRM","prop":"Link"},{"av":"AV31BtnSaveAs","fld":"vBTNSAVEAS"},{"av":"AV58BtnTranslations","fld":"vBTNTRANSLATIONS"},{"av":"edtavName_Link","ctrl":"vNAME","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E111Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilName","fld":"vFILNAME"},{"av":"edtavBtnrole_Title","ctrl":"vBTNROLE","prop":"Title"},{"av":"edtavBtnprm_Title","ctrl":"vBTNPRM","prop":"Title"},{"av":"edtavBtnsaveas_Title","ctrl":"vBTNSAVEAS","prop":"Title"},{"av":"edtavBtntranslations_Title","ctrl":"vBTNTRANSLATIONS","prop":"Title"},{"av":"AV14FilExternalId","fld":"vFILEXTERNALID","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"AV23IsAuthorized_Name","fld":"vISAUTHORIZED_NAME","hsh":true},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV40GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV40GridState","fld":"vGRIDSTATE"},{"av":"AV15FilName","fld":"vFILNAME"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV51GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"edtavBtnrole_Visible","ctrl":"vBTNROLE","prop":"Visible"},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"edtavBtnprm_Visible","ctrl":"vBTNPRM","prop":"Visible"},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"edtavBtntranslations_Visible","ctrl":"vBTNTRANSLATIONS","prop":"Visible"},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV47ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VGRIDACTIONS.CLICK","""{"handler":"E181Q2","iparms":[{"av":"cmbavGridactions"},{"av":"AV50GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilName","fld":"vFILNAME"},{"av":"edtavBtnrole_Title","ctrl":"vBTNROLE","prop":"Title"},{"av":"edtavBtnprm_Title","ctrl":"vBTNPRM","prop":"Title"},{"av":"edtavBtnsaveas_Title","ctrl":"vBTNSAVEAS","prop":"Title"},{"av":"edtavBtntranslations_Title","ctrl":"vBTNTRANSLATIONS","prop":"Title"},{"av":"AV14FilExternalId","fld":"vFILEXTERNALID","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"AV23IsAuthorized_Name","fld":"vISAUTHORIZED_NAME","hsh":true},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV18Id","fld":"vID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VGRIDACTIONS.CLICK",""","oparms":[{"av":"cmbavGridactions"},{"av":"AV50GridActions","fld":"vGRIDACTIONS","pic":"ZZZ9"},{"av":"AV18Id","fld":"vID","pic":"ZZZZZZZZZZZ9"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV51GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"edtavBtnrole_Visible","ctrl":"vBTNROLE","prop":"Visible"},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"edtavBtnprm_Visible","ctrl":"vBTNPRM","prop":"Visible"},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"edtavBtntranslations_Visible","ctrl":"vBTNTRANSLATIONS","prop":"Visible"},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV47ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV40GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VBTNTRANSLATIONS.CLICK","""{"handler":"E191Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilName","fld":"vFILNAME"},{"av":"edtavBtnrole_Title","ctrl":"vBTNROLE","prop":"Title"},{"av":"edtavBtnprm_Title","ctrl":"vBTNPRM","prop":"Title"},{"av":"edtavBtnsaveas_Title","ctrl":"vBTNSAVEAS","prop":"Title"},{"av":"edtavBtntranslations_Title","ctrl":"vBTNTRANSLATIONS","prop":"Title"},{"av":"AV14FilExternalId","fld":"vFILEXTERNALID","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"AV23IsAuthorized_Name","fld":"vISAUTHORIZED_NAME","hsh":true},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV18Id","fld":"vID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VBTNTRANSLATIONS.CLICK",""","oparms":[{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV51GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"edtavBtnrole_Visible","ctrl":"vBTNROLE","prop":"Visible"},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"edtavBtnprm_Visible","ctrl":"vBTNPRM","prop":"Visible"},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"edtavBtntranslations_Visible","ctrl":"vBTNTRANSLATIONS","prop":"Visible"},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV47ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV40GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E141Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilName","fld":"vFILNAME"},{"av":"edtavBtnrole_Title","ctrl":"vBTNROLE","prop":"Title"},{"av":"edtavBtnprm_Title","ctrl":"vBTNPRM","prop":"Title"},{"av":"edtavBtnsaveas_Title","ctrl":"vBTNSAVEAS","prop":"Title"},{"av":"edtavBtntranslations_Title","ctrl":"vBTNTRANSLATIONS","prop":"Title"},{"av":"AV14FilExternalId","fld":"vFILEXTERNALID","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"AV23IsAuthorized_Name","fld":"vISAUTHORIZED_NAME","hsh":true},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV51GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"edtavBtnrole_Visible","ctrl":"vBTNROLE","prop":"Visible"},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"edtavBtnprm_Visible","ctrl":"vBTNPRM","prop":"Visible"},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"edtavBtntranslations_Visible","ctrl":"vBTNTRANSLATIONS","prop":"Visible"},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV47ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV40GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VBTNSAVEAS.CLICK","""{"handler":"E201Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilName","fld":"vFILNAME"},{"av":"edtavBtnrole_Title","ctrl":"vBTNROLE","prop":"Title"},{"av":"edtavBtnprm_Title","ctrl":"vBTNPRM","prop":"Title"},{"av":"edtavBtnsaveas_Title","ctrl":"vBTNSAVEAS","prop":"Title"},{"av":"edtavBtntranslations_Title","ctrl":"vBTNTRANSLATIONS","prop":"Title"},{"av":"AV14FilExternalId","fld":"vFILEXTERNALID","hsh":true},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"AV23IsAuthorized_Name","fld":"vISAUTHORIZED_NAME","hsh":true},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV18Id","fld":"vID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VBTNSAVEAS.CLICK",""","oparms":[{"av":"AV43ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV49GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV51GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV54IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV56IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV21IsAuthorized_BtnRole","fld":"vISAUTHORIZED_BTNROLE","hsh":true},{"av":"edtavBtnrole_Visible","ctrl":"vBTNROLE","prop":"Visible"},{"av":"AV20IsAuthorized_BtnPrm","fld":"vISAUTHORIZED_BTNPRM","hsh":true},{"av":"edtavBtnprm_Visible","ctrl":"vBTNPRM","prop":"Visible"},{"av":"AV59IsAuthorized_BtnTranslations","fld":"vISAUTHORIZED_BTNTRANSLATIONS","hsh":true},{"av":"edtavBtntranslations_Visible","ctrl":"vBTNTRANSLATIONS","prop":"Visible"},{"av":"AV57IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV47ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV40GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Id","iparms":[]}""");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV60Pgmname = "";
         AV15FilName = "";
         AV14FilExternalId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV47ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV51GridAppliedFilters = "";
         AV40GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9BtnRole = "";
         AV8BtnPrm = "";
         AV31BtnSaveAs = "";
         AV58BtnTranslations = "";
         AV24Name = "";
         AV36HTTPRequest = new GxHttpRequest( context);
         AV37WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16Filter = new GeneXus.Programs.genexussecurity.SdtGAMRoleFilter(context);
         AV28GAMRoles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV13Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV26Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         GridRow = new GXWebRow();
         AV44ManageFiltersXml = "";
         GXt_char2 = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV42Session = context.GetSession();
         AV41GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV33NewGAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV12Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamwwroles__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamwwroles__default(),
            new Object[][] {
            }
         );
         AV60Pgmname = "GAMWWRoles";
         /* GeneXus formulas. */
         AV60Pgmname = "GAMWWRoles";
         edtavBtnrole_Enabled = 0;
         edtavBtnprm_Enabled = 0;
         edtavBtnsaveas_Enabled = 0;
         edtavBtntranslations_Enabled = 0;
         edtavName_Enabled = 0;
         edtavId_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV43ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV50GridActions ;
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
      private int nRC_GXsfl_38 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_38_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int subGrid_Islastpage ;
      private int edtavBtnrole_Enabled ;
      private int edtavBtnprm_Enabled ;
      private int edtavBtnsaveas_Enabled ;
      private int edtavBtntranslations_Enabled ;
      private int edtavName_Enabled ;
      private int edtavId_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int AV25PageToGo ;
      private int AV61GXV1 ;
      private int edtavBtnrole_Visible ;
      private int edtavBtnprm_Visible ;
      private int edtavBtntranslations_Visible ;
      private int AV62GXV2 ;
      private int AV63GXV3 ;
      private int edtavFilname_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV49GridCurrentPage ;
      private long AV17GridPageCount ;
      private long AV18Id ;
      private long GRID_nCurrentRecord ;
      private long AV29GridPageSize ;
      private long AV30GridRecordCount ;
      private string edtavBtnrole_Title ;
      private string edtavBtnprm_Title ;
      private string edtavBtnsaveas_Title ;
      private string edtavBtntranslations_Title ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_38_idx="0001" ;
      private string edtavBtnrole_Internalname ;
      private string edtavBtnprm_Internalname ;
      private string edtavBtnsaveas_Internalname ;
      private string edtavBtntranslations_Internalname ;
      private string AV60Pgmname ;
      private string AV15FilName ;
      private string AV14FilExternalId ;
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
      private string cmbavGridactions_Internalname ;
      private string AV9BtnRole ;
      private string AV8BtnPrm ;
      private string AV31BtnSaveAs ;
      private string AV58BtnTranslations ;
      private string AV24Name ;
      private string edtavName_Internalname ;
      private string edtavId_Internalname ;
      private string edtavFilname_Internalname ;
      private string cmbavGridactions_Class ;
      private string edtavBtnrole_Link ;
      private string edtavBtnprm_Link ;
      private string edtavName_Link ;
      private string GXt_char2 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilname_Jsonclick ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtavBtnrole_Jsonclick ;
      private string edtavBtnprm_Jsonclick ;
      private string edtavBtnsaveas_Jsonclick ;
      private string edtavBtntranslations_Jsonclick ;
      private string edtavName_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_38_Refreshing=false ;
      private bool AV54IsAuthorized_Display ;
      private bool AV55IsAuthorized_Update ;
      private bool AV56IsAuthorized_Delete ;
      private bool AV21IsAuthorized_BtnRole ;
      private bool AV20IsAuthorized_BtnPrm ;
      private bool AV23IsAuthorized_Name ;
      private bool AV59IsAuthorized_BtnTranslations ;
      private bool AV57IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean1 ;
      private bool AV32isOK ;
      private string AV44ManageFiltersXml ;
      private string AV51GridAppliedFilters ;
      private IGxSession AV42Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV36HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactions ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV47ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV37WWPContext ;
      private GeneXus.Programs.genexussecurity.SdtGAMRoleFilter AV16Filter ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV28GAMRoles ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV26Role ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV33NewGAMRole ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV12Error ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamwwroles__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamwwroles__default : DataStoreHelperBase, IDataStoreHelper
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
