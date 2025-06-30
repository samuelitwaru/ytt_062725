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
   public class employeeww : GXDataArea
   {
      public employeeww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeeww( IGxContext context )
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
         chkEmployeeIsManager = new GXCheckbox();
         chkEmployeeIsActive = new GXCheckbox();
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
         nRC_GXsfl_39 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
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
         AV17OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV18OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV20FilterFullText = GetPar( "FilterFullText");
         AV30ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV25ColumnsSelector);
         AV89Pgmname = GetPar( "Pgmname");
         AV66TFEmployeeName = GetPar( "TFEmployeeName");
         AV67TFEmployeeName_Sel = GetPar( "TFEmployeeName_Sel");
         AV37TFEmployeeEmail = GetPar( "TFEmployeeEmail");
         AV38TFEmployeeEmail_Sel = GetPar( "TFEmployeeEmail_Sel");
         AV43TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEmployeeIsManager_Sel"), "."), 18, MidpointRounding.ToEven));
         AV46TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFEmployeeIsActive_Sel"), "."), 18, MidpointRounding.ToEven));
         A162ProjectManagerId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectManagerId"), "."), 18, MidpointRounding.ToEven));
         n162ProjectManagerId = false;
         AV99Udparg11 = (long)(Math.Round(NumberUtil.Val( GetPar( "Udparg11"), "."), 18, MidpointRounding.ToEven));
         A102ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV68ProjectIds);
         AV80InviteEmployee = StringUtil.StrToBool( GetPar( "InviteEmployee"));
         AV58IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV60IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV65IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV89Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, A162ProjectManagerId, AV99Udparg11, A102ProjectId, AV68ProjectIds, AV80InviteEmployee, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
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
            return "employeeww_Execute" ;
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
         PA2V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2V2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("employeeww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV89Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUDPARG11", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV99Udparg11), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG11", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV99Udparg11), "9999999999"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTIDS", AV68ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTIDS", AV68ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTIDS", GetSecureSignedToken( "", AV68ProjectIds, context));
         GxWebStd.gx_boolean_hidden_field( context, "vINVITEEMPLOYEE", AV80InviteEmployee);
         GxWebStd.gx_hidden_field( context, "gxhash_vINVITEEMPLOYEE", GetSecureSignedToken( "", AV80InviteEmployee, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV60IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV60IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV18OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV20FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV28ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV28ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV9GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV63AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV63AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV51DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV51DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV25ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV25ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV89Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEENAME", StringUtil.RTrim( AV66TFEmployeeName));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEENAME_SEL", StringUtil.RTrim( AV67TFEmployeeName_Sel));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEEMAIL", AV37TFEmployeeEmail);
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEEMAIL_SEL", AV38TFEmployeeEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEISMANAGER_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEISACTIVE_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROJECTMANAGERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A162ProjectManagerId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUDPARG11", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV99Udparg11), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG11", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV99Udparg11), "9999999999"), context));
         GxWebStd.gx_hidden_field( context, "PROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTIDS", AV68ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTIDS", AV68ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTIDS", GetSecureSignedToken( "", AV68ProjectIds, context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV18OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vINVITEEMPLOYEE", AV80InviteEmployee);
         GxWebStd.gx_hidden_field( context, "gxhash_vINVITEEMPLOYEE", GetSecureSignedToken( "", AV80InviteEmployee, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV60IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV60IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV15GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV15GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
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
            WE2V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2V2( ) ;
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
         return formatLink("employeeww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "EmployeeWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Employees" ;
      }

      protected void WB2V0( )
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
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupGrouped", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EmployeeWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Export", bttBtnagexport_Jsonclick, 0, "Export", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_EmployeeWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_EmployeeWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV28ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV20FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV20FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_EmployeeWW.htm");
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
            StartGridControl39( ) ;
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            nRC_GXsfl_39 = (int)(nGXsfl_39_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV55GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV56GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV9GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV63AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV51DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV51DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV25ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 39 )
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

      protected void START2V2( )
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
         Form.Meta.addItem("description", " Employees", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2V0( ) ;
      }

      protected void WS2V2( )
      {
         START2V2( ) ;
         EVT2V2( ) ;
      }

      protected void EVT2V2( )
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
                              E112V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E122V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E132V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E142V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E152V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E162V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E172V2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VINVITE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VINVITE.CLICK") == 0 ) )
                           {
                              nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              AV70Invite = cgiGet( edtavInvite_Internalname);
                              AssignAttri("", false, edtavInvite_Internalname, AV70Invite);
                              AV57Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV57Update);
                              AV59Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV59Delete);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A107EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
                              A108EmployeeLastName = cgiGet( edtEmployeeLastName_Internalname);
                              A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
                              A109EmployeeEmail = cgiGet( edtEmployeeEmail_Internalname);
                              A100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCompanyId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A101CompanyName = cgiGet( edtCompanyName_Internalname);
                              A110EmployeeIsManager = StringUtil.StrToBool( cgiGet( chkEmployeeIsManager_Internalname));
                              A111GAMUserGUID = cgiGet( edtGAMUserGUID_Internalname);
                              A112EmployeeIsActive = StringUtil.StrToBool( cgiGet( chkEmployeeIsActive_Internalname));
                              A146EmployeeVactionDays = context.localUtil.CToN( cgiGet( edtEmployeeVactionDays_Internalname), ".", ",");
                              A147EmployeeBalance = context.localUtil.CToN( cgiGet( edtEmployeeBalance_Internalname), ".", ",");
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployeebalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployeebalance_Internalname), ".", ",") > 99.9m ) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vEMPLOYEEBALANCE");
                                 GX_FocusControl = edtavEmployeebalance_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV85EmployeeBalance = 0;
                                 AssignAttri("", false, edtavEmployeebalance_Internalname, StringUtil.LTrimStr( AV85EmployeeBalance, 4, 1));
                              }
                              else
                              {
                                 AV85EmployeeBalance = context.localUtil.CToN( cgiGet( edtavEmployeebalance_Internalname), ".", ",");
                                 AssignAttri("", false, edtavEmployeebalance_Internalname, StringUtil.LTrimStr( AV85EmployeeBalance, 4, 1));
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
                                    E182V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E192V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E202V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VINVITE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E212V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV17OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV18OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV20FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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

      protected void WE2V2( )
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

      protected void PA2V2( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
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
         SubsflControlProps_392( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            sendrow_392( ) ;
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV17OrderedBy ,
                                       bool AV18OrderedDsc ,
                                       string AV20FilterFullText ,
                                       short AV30ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelector ,
                                       string AV89Pgmname ,
                                       string AV66TFEmployeeName ,
                                       string AV67TFEmployeeName_Sel ,
                                       string AV37TFEmployeeEmail ,
                                       string AV38TFEmployeeEmail_Sel ,
                                       short AV43TFEmployeeIsManager_Sel ,
                                       short AV46TFEmployeeIsActive_Sel ,
                                       long A162ProjectManagerId ,
                                       long AV99Udparg11 ,
                                       long A102ProjectId ,
                                       GxSimpleCollection<long> AV68ProjectIds ,
                                       bool AV80InviteEmployee ,
                                       bool AV58IsAuthorized_Update ,
                                       bool AV60IsAuthorized_Delete ,
                                       bool AV65IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_EMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
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
         RF2V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV89Pgmname = "EmployeeWW";
         edtavInvite_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavEmployeebalance_Enabled = 0;
      }

      protected void RF2V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E192V2 ();
         nGXsfl_39_idx = 1;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         bGXsfl_39_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_392( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A106EmployeeId ,
                                                 AV69EmployeeIds ,
                                                 AV90Employeewwds_4_filterfulltext ,
                                                 AV92Employeewwds_6_tfemployeename_sel ,
                                                 AV91Employeewwds_5_tfemployeename ,
                                                 AV94Employeewwds_8_tfemployeeemail_sel ,
                                                 AV93Employeewwds_7_tfemployeeemail ,
                                                 AV95Employeewwds_9_tfemployeeismanager_sel ,
                                                 AV96Employeewwds_10_tfemployeeisactive_sel ,
                                                 A148EmployeeName ,
                                                 A109EmployeeEmail ,
                                                 A110EmployeeIsManager ,
                                                 A112EmployeeIsActive ,
                                                 AV17OrderedBy ,
                                                 AV18OrderedDsc ,
                                                 AV86Udparg1 ,
                                                 AV87Udparg2 ,
                                                 A100CompanyId ,
                                                 AV88Udparg3 } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                                 TypeConstants.LONG
                                                 }
            });
            lV90Employeewwds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Employeewwds_4_filterfulltext), "%", "");
            lV90Employeewwds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Employeewwds_4_filterfulltext), "%", "");
            lV91Employeewwds_5_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV91Employeewwds_5_tfemployeename), 100, "%");
            lV93Employeewwds_7_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV93Employeewwds_7_tfemployeeemail), "%", "");
            /* Using cursor H002V2 */
            pr_default.execute(0, new Object[] {AV86Udparg1, AV87Udparg2, AV88Udparg3, lV90Employeewwds_4_filterfulltext, lV90Employeewwds_4_filterfulltext, lV91Employeewwds_5_tfemployeename, AV92Employeewwds_6_tfemployeename_sel, lV93Employeewwds_7_tfemployeeemail, AV94Employeewwds_8_tfemployeeemail_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A147EmployeeBalance = H002V2_A147EmployeeBalance[0];
               A146EmployeeVactionDays = H002V2_A146EmployeeVactionDays[0];
               A112EmployeeIsActive = H002V2_A112EmployeeIsActive[0];
               A111GAMUserGUID = H002V2_A111GAMUserGUID[0];
               A110EmployeeIsManager = H002V2_A110EmployeeIsManager[0];
               A101CompanyName = H002V2_A101CompanyName[0];
               A100CompanyId = H002V2_A100CompanyId[0];
               A109EmployeeEmail = H002V2_A109EmployeeEmail[0];
               A148EmployeeName = H002V2_A148EmployeeName[0];
               A108EmployeeLastName = H002V2_A108EmployeeLastName[0];
               A107EmployeeFirstName = H002V2_A107EmployeeFirstName[0];
               A106EmployeeId = H002V2_A106EmployeeId[0];
               A101CompanyName = H002V2_A101CompanyName[0];
               /* Execute user event: Grid.Load */
               E202V2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WB2V0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2V2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV89Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV89Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vUDPARG11", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV99Udparg11), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUDPARG11", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV99Udparg11), "9999999999"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTIDS", AV68ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTIDS", AV68ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTIDS", GetSecureSignedToken( "", AV68ProjectIds, context));
         GxWebStd.gx_boolean_hidden_field( context, "vINVITEEMPLOYEE", AV80InviteEmployee);
         GxWebStd.gx_hidden_field( context, "gxhash_vINVITEEMPLOYEE", GetSecureSignedToken( "", AV80InviteEmployee, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV60IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV60IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_EMPLOYEEID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"), context));
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
         AV90Employeewwds_4_filterfulltext = AV20FilterFullText;
         AV91Employeewwds_5_tfemployeename = AV66TFEmployeeName;
         AV92Employeewwds_6_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV93Employeewwds_7_tfemployeeemail = AV37TFEmployeeEmail;
         AV94Employeewwds_8_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV95Employeewwds_9_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV96Employeewwds_10_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
         AV86Udparg1 = new userhasrole(context).executeUdp(  "Manager");
         AV87Udparg2 = new userhasrole(context).executeUdp(  "Project Manager");
         AV88Udparg3 = new getloggedinusercompanyid(context).executeUdp( );
         AV99Udparg11 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV69EmployeeIds ,
                                              AV90Employeewwds_4_filterfulltext ,
                                              AV92Employeewwds_6_tfemployeename_sel ,
                                              AV91Employeewwds_5_tfemployeename ,
                                              AV94Employeewwds_8_tfemployeeemail_sel ,
                                              AV93Employeewwds_7_tfemployeeemail ,
                                              AV95Employeewwds_9_tfemployeeismanager_sel ,
                                              AV96Employeewwds_10_tfemployeeisactive_sel ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV86Udparg1 ,
                                              AV87Udparg2 ,
                                              A100CompanyId ,
                                              AV88Udparg3 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV90Employeewwds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Employeewwds_4_filterfulltext), "%", "");
         lV90Employeewwds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV90Employeewwds_4_filterfulltext), "%", "");
         lV91Employeewwds_5_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV91Employeewwds_5_tfemployeename), 100, "%");
         lV93Employeewwds_7_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV93Employeewwds_7_tfemployeeemail), "%", "");
         /* Using cursor H002V3 */
         pr_default.execute(1, new Object[] {AV86Udparg1, AV87Udparg2, AV88Udparg3, lV90Employeewwds_4_filterfulltext, lV90Employeewwds_4_filterfulltext, lV91Employeewwds_5_tfemployeename, AV92Employeewwds_6_tfemployeename_sel, lV93Employeewwds_7_tfemployeeemail, AV94Employeewwds_8_tfemployeeemail_sel});
         GRID_nRecordCount = H002V3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
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
         AV90Employeewwds_4_filterfulltext = AV20FilterFullText;
         AV91Employeewwds_5_tfemployeename = AV66TFEmployeeName;
         AV92Employeewwds_6_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV93Employeewwds_7_tfemployeeemail = AV37TFEmployeeEmail;
         AV94Employeewwds_8_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV95Employeewwds_9_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV96Employeewwds_10_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV89Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, A162ProjectManagerId, AV99Udparg11, A102ProjectId, AV68ProjectIds, AV80InviteEmployee, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV90Employeewwds_4_filterfulltext = AV20FilterFullText;
         AV91Employeewwds_5_tfemployeename = AV66TFEmployeeName;
         AV92Employeewwds_6_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV93Employeewwds_7_tfemployeeemail = AV37TFEmployeeEmail;
         AV94Employeewwds_8_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV95Employeewwds_9_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV96Employeewwds_10_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV89Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, A162ProjectManagerId, AV99Udparg11, A102ProjectId, AV68ProjectIds, AV80InviteEmployee, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV90Employeewwds_4_filterfulltext = AV20FilterFullText;
         AV91Employeewwds_5_tfemployeename = AV66TFEmployeeName;
         AV92Employeewwds_6_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV93Employeewwds_7_tfemployeeemail = AV37TFEmployeeEmail;
         AV94Employeewwds_8_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV95Employeewwds_9_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV96Employeewwds_10_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV89Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, A162ProjectManagerId, AV99Udparg11, A102ProjectId, AV68ProjectIds, AV80InviteEmployee, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV90Employeewwds_4_filterfulltext = AV20FilterFullText;
         AV91Employeewwds_5_tfemployeename = AV66TFEmployeeName;
         AV92Employeewwds_6_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV93Employeewwds_7_tfemployeeemail = AV37TFEmployeeEmail;
         AV94Employeewwds_8_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV95Employeewwds_9_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV96Employeewwds_10_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV89Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, A162ProjectManagerId, AV99Udparg11, A102ProjectId, AV68ProjectIds, AV80InviteEmployee, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV90Employeewwds_4_filterfulltext = AV20FilterFullText;
         AV91Employeewwds_5_tfemployeename = AV66TFEmployeeName;
         AV92Employeewwds_6_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV93Employeewwds_7_tfemployeeemail = AV37TFEmployeeEmail;
         AV94Employeewwds_8_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV95Employeewwds_9_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV96Employeewwds_10_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV30ManageFiltersExecutionStep, AV25ColumnsSelector, AV89Pgmname, AV66TFEmployeeName, AV67TFEmployeeName_Sel, AV37TFEmployeeEmail, AV38TFEmployeeEmail_Sel, AV43TFEmployeeIsManager_Sel, AV46TFEmployeeIsActive_Sel, A162ProjectManagerId, AV99Udparg11, A102ProjectId, AV68ProjectIds, AV80InviteEmployee, AV58IsAuthorized_Update, AV60IsAuthorized_Delete, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV89Pgmname = "EmployeeWW";
         edtavInvite_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavEmployeebalance_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtEmployeeFirstName_Enabled = 0;
         edtEmployeeLastName_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         edtEmployeeEmail_Enabled = 0;
         edtCompanyId_Enabled = 0;
         edtCompanyName_Enabled = 0;
         chkEmployeeIsManager.Enabled = 0;
         edtGAMUserGUID_Enabled = 0;
         chkEmployeeIsActive.Enabled = 0;
         edtEmployeeVactionDays_Enabled = 0;
         edtEmployeeBalance_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E182V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV28ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV63AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV51DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV25ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), ".", ","), 18, MidpointRounding.ToEven));
            AV55GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV56GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV9GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
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
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV20FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV20FilterFullText", AV20FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV17OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV18OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV20FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E182V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182V2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Message)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  AV83Message,  "success",  "",  "true",  ""));
            AV83Message = "";
            AssignAttri("", false, "AV83Message", AV83Message);
         }
         GXt_boolean1 = AV80InviteEmployee;
         new userhasrole(context ).execute(  "Manager", out  GXt_boolean1) ;
         GXt_boolean2 = AV80InviteEmployee;
         new userhasrole(context ).execute(  "General Manager", out  GXt_boolean2) ;
         GXt_boolean3 = AV80InviteEmployee;
         new userhasrole(context ).execute(  "Administrator", out  GXt_boolean3) ;
         AV80InviteEmployee = (bool)(GXt_boolean1||GXt_boolean2||GXt_boolean3);
         AssignAttri("", false, "AV80InviteEmployee", AV80InviteEmployee);
         GxWebStd.gx_hidden_field( context, "gxhash_vINVITEEMPLOYEE", GetSecureSignedToken( "", AV80InviteEmployee, context));
         /* Execute user subroutine: 'GETEMPLOYEEIDSBYPROJECT' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV12HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV63AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV64AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV64AGExportDataItem.gxTpr_Title = "Excel";
         AV64AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV64AGExportDataItem.gxTpr_Eventkey = "Export";
         AV64AGExportDataItem.gxTpr_Isdivider = false;
         AV63AGExportData.Add(AV64AGExportDataItem, 0);
         AV52GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV53GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV52GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Employees";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV17OrderedBy < 1 )
         {
            AV17OrderedBy = 1;
            AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = AV51DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4) ;
         AV51DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         Form.Caption = "Employees";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
      }

      protected void E192V2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETEMPLOYEEIDSBYPROJECT' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV30ManageFiltersExecutionStep == 1 )
         {
            AV30ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV30ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV30ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV30ManageFiltersExecutionStep == 2 )
         {
            AV30ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV30ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV30ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV27Session.Get("EmployeeWWColumnsSelector"), "") != 0 )
         {
            AV23ColumnsSelectorXML = AV27Session.Get("EmployeeWWColumnsSelector");
            AV25ColumnsSelector.FromXml(AV23ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtEmployeeName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtEmployeeEmail_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEmployeeEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Visible), 5, 0), !bGXsfl_39_Refreshing);
         chkEmployeeIsManager.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkEmployeeIsManager_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkEmployeeIsManager.Visible), 5, 0), !bGXsfl_39_Refreshing);
         chkEmployeeIsActive.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkEmployeeIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavEmployeebalance_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavEmployeebalance_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmployeebalance_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV55GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV55GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV55GridCurrentPage), 10, 0));
         AV56GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV56GridPageCount", StringUtil.LTrimStr( (decimal)(AV56GridPageCount), 10, 0));
         GXt_char5 = AV9GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV89Pgmname, out  GXt_char5) ;
         AV9GridAppliedFilters = GXt_char5;
         AssignAttri("", false, "AV9GridAppliedFilters", AV9GridAppliedFilters);
         AV90Employeewwds_4_filterfulltext = AV20FilterFullText;
         AV91Employeewwds_5_tfemployeename = AV66TFEmployeeName;
         AV92Employeewwds_6_tfemployeename_sel = AV67TFEmployeeName_Sel;
         AV93Employeewwds_7_tfemployeeemail = AV37TFEmployeeEmail;
         AV94Employeewwds_8_tfemployeeemail_sel = AV38TFEmployeeEmail_Sel;
         AV95Employeewwds_9_tfemployeeismanager_sel = AV43TFEmployeeIsManager_Sel;
         AV96Employeewwds_10_tfemployeeisactive_sel = AV46TFEmployeeIsActive_Sel;
         AV86Udparg1 = new userhasrole(context).executeUdp(  "Manager");
         AV87Udparg2 = new userhasrole(context).executeUdp(  "Project Manager");
         AV88Udparg3 = new getloggedinusercompanyid(context).executeUdp( );
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ProjectIds", AV68ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E122V2( )
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
            AV54PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV54PageToGo) ;
         }
      }

      protected void E132V2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E152V2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV17OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
            AV18OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeName") == 0 )
            {
               AV66TFEmployeeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV66TFEmployeeName", AV66TFEmployeeName);
               AV67TFEmployeeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV67TFEmployeeName_Sel", AV67TFEmployeeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeEmail") == 0 )
            {
               AV37TFEmployeeEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFEmployeeEmail", AV37TFEmployeeEmail);
               AV38TFEmployeeEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFEmployeeEmail_Sel", AV38TFEmployeeEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeIsManager") == 0 )
            {
               AV43TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFEmployeeIsManager_Sel", StringUtil.Str( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeIsActive") == 0 )
            {
               AV46TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFEmployeeIsActive_Sel", StringUtil.Str( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E202V2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV77GamUser.load( A111GAMUserGUID);
         AV78isActive = AV77GamUser.gxTpr_Isactive;
         AV81isActiveEmployee = AV77GamUser.gxTpr_Isenabledinrepository;
         AV70Invite = "Invite";
         AssignAttri("", false, edtavInvite_Internalname, AV70Invite);
         if ( ! AV78isActive && ( AV80InviteEmployee ) && ( AV81isActiveEmployee ) )
         {
            edtavInvite_Class = "Attribute";
         }
         else
         {
            edtavInvite_Class = "Invisible";
         }
         AV57Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV57Update);
         if ( AV58IsAuthorized_Update )
         {
            edtavUpdate_Link = formatLink("employee.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A106EmployeeId,10,0))}, new string[] {"Mode","EmployeeId"}) ;
         }
         AV59Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV59Delete);
         if ( AV60IsAuthorized_Delete )
         {
            edtavDelete_Link = formatLink("employee.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A106EmployeeId,10,0))}, new string[] {"Mode","EmployeeId"}) ;
         }
         GXt_decimal6 = AV85EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal6) ;
         AV85EmployeeBalance = GXt_decimal6;
         AssignAttri("", false, edtavEmployeebalance_Internalname, StringUtil.LTrimStr( AV85EmployeeBalance, 4, 1));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 39;
         }
         sendrow_392( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
         {
            DoAjaxLoad(39, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E162V2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV23ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV25ColumnsSelector.FromJSonString(AV23ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "EmployeeWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV23ColumnsSelectorXML)) ? "" : AV25ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ProjectIds", AV68ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E112V2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("EmployeeWWFilters")),UrlEncode(StringUtil.RTrim(AV89Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV30ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV30ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV30ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("EmployeeWWFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV30ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV30ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV30ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char5 = AV29ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "EmployeeWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char5) ;
            AV29ManageFiltersXml = GXt_char5;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV29ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV89Pgmname+"GridState",  AV29ManageFiltersXml) ;
               AV15GridState.FromXml(AV29ManageFiltersXml, null, "", "");
               AV17OrderedBy = AV15GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
               AV18OrderedDsc = AV15GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S152 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ProjectIds", AV68ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
      }

      protected void E172V2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV65IsAuthorized_Insert )
         {
            CallWebObject(formatLink("employee.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","EmployeeId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ProjectIds", AV68ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28ManageFiltersData", AV28ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E142V2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void S152( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV17OrderedBy), 4, 0))+":"+(AV18OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV25ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeName",  "",  "Employee Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeEmail",  "",  "Email",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeIsManager",  "",  "Is HR Manager",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeIsActive",  "",  "Is Active",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "&EmployeeBalance",  "",  "Balance",  true,  "") ;
         GXt_char5 = AV24UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "EmployeeWWColumnsSelector", out  GXt_char5) ;
         AV24UserCustomValue = GXt_char5;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV24UserCustomValue)) ) )
         {
            AV26ColumnsSelectorAux.FromXml(AV24UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV26ColumnsSelectorAux, ref  AV25ColumnsSelector) ;
         }
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV58IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "employee_Update", out  GXt_boolean3) ;
         AV58IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV58IsAuthorized_Update", AV58IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV58IsAuthorized_Update, context));
         if ( ! ( AV58IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_39_Refreshing);
         }
         GXt_boolean3 = AV60IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "employee_Delete", out  GXt_boolean3) ;
         AV60IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV60IsAuthorized_Delete", AV60IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV60IsAuthorized_Delete, context));
         if ( ! ( AV60IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_39_Refreshing);
         }
         GXt_boolean3 = AV65IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "employee_Insert", out  GXt_boolean3) ;
         AV65IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV65IsAuthorized_Insert", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         if ( ! ( AV65IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7 = AV28ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "EmployeeWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7) ;
         AV28ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV20FilterFullText = "";
         AssignAttri("", false, "AV20FilterFullText", AV20FilterFullText);
         AV66TFEmployeeName = "";
         AssignAttri("", false, "AV66TFEmployeeName", AV66TFEmployeeName);
         AV67TFEmployeeName_Sel = "";
         AssignAttri("", false, "AV67TFEmployeeName_Sel", AV67TFEmployeeName_Sel);
         AV37TFEmployeeEmail = "";
         AssignAttri("", false, "AV37TFEmployeeEmail", AV37TFEmployeeEmail);
         AV38TFEmployeeEmail_Sel = "";
         AssignAttri("", false, "AV38TFEmployeeEmail_Sel", AV38TFEmployeeEmail_Sel);
         AV43TFEmployeeIsManager_Sel = 0;
         AssignAttri("", false, "AV43TFEmployeeIsManager_Sel", StringUtil.Str( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0));
         AV46TFEmployeeIsActive_Sel = 0;
         AssignAttri("", false, "AV46TFEmployeeIsActive_Sel", StringUtil.Str( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S142( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get(AV89Pgmname+"GridState"), "") == 0 )
         {
            AV15GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV89Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV15GridState.FromXml(AV27Session.Get(AV89Pgmname+"GridState"), null, "", "");
         }
         AV17OrderedBy = AV15GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
         AV18OrderedDsc = AV15GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV15GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV15GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV97GXV1 = 1;
         while ( AV97GXV1 <= AV15GridState.gxTpr_Filtervalues.Count )
         {
            AV16GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV15GridState.gxTpr_Filtervalues.Item(AV97GXV1));
            if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV20FilterFullText = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20FilterFullText", AV20FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV66TFEmployeeName = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFEmployeeName", AV66TFEmployeeName);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV67TFEmployeeName_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFEmployeeName_Sel", AV67TFEmployeeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL") == 0 )
            {
               AV37TFEmployeeEmail = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFEmployeeEmail", AV37TFEmployeeEmail);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL_SEL") == 0 )
            {
               AV38TFEmployeeEmail_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFEmployeeEmail_Sel", AV38TFEmployeeEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISMANAGER_SEL") == 0 )
            {
               AV43TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFEmployeeIsManager_Sel", StringUtil.Str( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISACTIVE_SEL") == 0 )
            {
               AV46TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFEmployeeIsActive_Sel", StringUtil.Str( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0));
            }
            AV97GXV1 = (int)(AV97GXV1+1);
         }
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFEmployeeName_Sel)),  AV67TFEmployeeName_Sel, out  GXt_char5) ;
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEmployeeEmail_Sel)),  AV38TFEmployeeEmail_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = GXt_char5+"|"+GXt_char8+"|"+((0==AV43TFEmployeeIsManager_Sel) ? "" : StringUtil.Str( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0))+"|"+((0==AV46TFEmployeeIsActive_Sel) ? "" : StringUtil.Str( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFEmployeeName)),  AV66TFEmployeeName, out  GXt_char8) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEmployeeEmail)),  AV37TFEmployeeEmail, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char8+"|"+GXt_char5+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV15GridState.FromXml(AV27Session.Get(AV89Pgmname+"GridState"), null, "", "");
         AV15GridState.gxTpr_Orderedby = AV17OrderedBy;
         AV15GridState.gxTpr_Ordereddsc = AV18OrderedDsc;
         AV15GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20FilterFullText)),  0,  AV20FilterFullText,  AV20FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFEMPLOYEENAME",  "Employee Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFEmployeeName)),  0,  AV66TFEmployeeName,  AV66TFEmployeeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFEmployeeName_Sel)),  AV67TFEmployeeName_Sel,  AV67TFEmployeeName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFEMPLOYEEEMAIL",  "Email",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEmployeeEmail)),  0,  AV37TFEmployeeEmail,  AV37TFEmployeeEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEmployeeEmail_Sel)),  AV38TFEmployeeEmail_Sel,  AV38TFEmployeeEmail_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "TFEMPLOYEEISMANAGER_SEL",  "Is HR Manager",  !(0==AV43TFEmployeeIsManager_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFEmployeeIsManager_Sel), 1, 0)),  ((AV43TFEmployeeIsManager_Sel==1) ? "Checked" : "Unchecked"),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "TFEMPLOYEEISACTIVE_SEL",  "Is Active",  !(0==AV46TFEmployeeIsActive_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV46TFEmployeeIsActive_Sel), 1, 0)),  ((AV46TFEmployeeIsActive_Sel==1) ? "Checked" : "Unchecked"),  false,  "",  "") ;
         AV15GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV15GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV89Pgmname+"GridState",  AV15GridState.ToXml(false, true, "", "")) ;
      }

      protected void S132( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV13TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV13TrnContext.gxTpr_Callerobject = AV89Pgmname;
         AV13TrnContext.gxTpr_Callerondelete = true;
         AV13TrnContext.gxTpr_Callerurl = AV12HTTPRequest.ScriptName+"?"+AV12HTTPRequest.QueryString;
         AV13TrnContext.gxTpr_Transactionname = "Employee";
         AV27Session.Set("TrnContext", AV13TrnContext.ToXml(false, true, "", ""));
      }

      protected void S212( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new employeewwexport(context ).execute( out  AV21ExcelFilename, out  AV22ErrorMessage) ;
         if ( StringUtil.StrCmp(AV21ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV21ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV22ErrorMessage);
         }
      }

      protected void E212V2( )
      {
         /* Invite_Click Routine */
         returnInSub = false;
         new sendwelcomeemail(context ).execute(  A106EmployeeId,  "", out  AV79successMessage) ;
         GX_msglist.addItem(AV79successMessage);
      }

      protected void S112( )
      {
         /* 'GETEMPLOYEEIDSBYPROJECT' Routine */
         returnInSub = false;
         AV99Udparg11 = new getloggedinemployeeid(context).executeUdp( );
         /* Using cursor H002V4 */
         pr_default.execute(2, new Object[] {AV99Udparg11});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A162ProjectManagerId = H002V4_A162ProjectManagerId[0];
            n162ProjectManagerId = H002V4_n162ProjectManagerId[0];
            A102ProjectId = H002V4_A102ProjectId[0];
            AV68ProjectIds.Add(A102ProjectId, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         GXt_objcol_int9 = AV69EmployeeIds;
         new getemployeeidsbyproject(context ).execute(  AV68ProjectIds, out  GXt_objcol_int9) ;
         AV69EmployeeIds = GXt_objcol_int9;
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
         PA2V2( ) ;
         WS2V2( ) ;
         WE2V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256275275413", true, true);
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
         context.AddJavascriptSource("employeeww.js", "?20256275275417", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtavInvite_Internalname = "vINVITE_"+sGXsfl_39_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_39_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_39_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_39_idx;
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME_"+sGXsfl_39_idx;
         edtEmployeeLastName_Internalname = "EMPLOYEELASTNAME_"+sGXsfl_39_idx;
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_39_idx;
         edtEmployeeEmail_Internalname = "EMPLOYEEEMAIL_"+sGXsfl_39_idx;
         edtCompanyId_Internalname = "COMPANYID_"+sGXsfl_39_idx;
         edtCompanyName_Internalname = "COMPANYNAME_"+sGXsfl_39_idx;
         chkEmployeeIsManager_Internalname = "EMPLOYEEISMANAGER_"+sGXsfl_39_idx;
         edtGAMUserGUID_Internalname = "GAMUSERGUID_"+sGXsfl_39_idx;
         chkEmployeeIsActive_Internalname = "EMPLOYEEISACTIVE_"+sGXsfl_39_idx;
         edtEmployeeVactionDays_Internalname = "EMPLOYEEVACTIONDAYS_"+sGXsfl_39_idx;
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE_"+sGXsfl_39_idx;
         edtavEmployeebalance_Internalname = "vEMPLOYEEBALANCE_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtavInvite_Internalname = "vINVITE_"+sGXsfl_39_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_39_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_39_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_39_fel_idx;
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME_"+sGXsfl_39_fel_idx;
         edtEmployeeLastName_Internalname = "EMPLOYEELASTNAME_"+sGXsfl_39_fel_idx;
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_39_fel_idx;
         edtEmployeeEmail_Internalname = "EMPLOYEEEMAIL_"+sGXsfl_39_fel_idx;
         edtCompanyId_Internalname = "COMPANYID_"+sGXsfl_39_fel_idx;
         edtCompanyName_Internalname = "COMPANYNAME_"+sGXsfl_39_fel_idx;
         chkEmployeeIsManager_Internalname = "EMPLOYEEISMANAGER_"+sGXsfl_39_fel_idx;
         edtGAMUserGUID_Internalname = "GAMUSERGUID_"+sGXsfl_39_fel_idx;
         chkEmployeeIsActive_Internalname = "EMPLOYEEISACTIVE_"+sGXsfl_39_fel_idx;
         edtEmployeeVactionDays_Internalname = "EMPLOYEEVACTIONDAYS_"+sGXsfl_39_fel_idx;
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE_"+sGXsfl_39_fel_idx;
         edtavEmployeebalance_Internalname = "vEMPLOYEEBALANCE_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WB2V0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_39_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_39_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = edtavInvite_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavInvite_Internalname,StringUtil.RTrim( AV70Invite),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"","'"+""+"'"+",false,"+"'"+"EVINVITE.CLICK."+sGXsfl_39_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavInvite_Jsonclick,(short)5,(string)edtavInvite_Class,(string)"",(string)ROClassString,(string)"WWActionColumn",(string)"",(short)-1,(int)edtavInvite_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV57Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV59Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeFirstName_Internalname,StringUtil.RTrim( A107EmployeeFirstName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeFirstName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeLastName_Internalname,StringUtil.RTrim( A108EmployeeLastName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeLastName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEmployeeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,StringUtil.RTrim( A148EmployeeName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtEmployeeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEmployeeEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeEmail_Internalname,(string)A109EmployeeEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A109EmployeeEmail,(string)"",(string)"",(string)"",(string)edtEmployeeEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEmployeeEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCompanyId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCompanyId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCompanyName_Internalname,StringUtil.RTrim( A101CompanyName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCompanyName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkEmployeeIsManager.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "EMPLOYEEISMANAGER_" + sGXsfl_39_idx;
            chkEmployeeIsManager.Name = GXCCtl;
            chkEmployeeIsManager.WebTags = "";
            chkEmployeeIsManager.Caption = "";
            AssignProp("", false, chkEmployeeIsManager_Internalname, "TitleCaption", chkEmployeeIsManager.Caption, !bGXsfl_39_Refreshing);
            chkEmployeeIsManager.CheckedValue = "false";
            A110EmployeeIsManager = StringUtil.StrToBool( StringUtil.BoolToStr( A110EmployeeIsManager));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkEmployeeIsManager_Internalname,StringUtil.BoolToStr( A110EmployeeIsManager),(string)"",(string)"",chkEmployeeIsManager.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtGAMUserGUID_Internalname,(string)A111GAMUserGUID,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtGAMUserGUID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkEmployeeIsActive.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "EMPLOYEEISACTIVE_" + sGXsfl_39_idx;
            chkEmployeeIsActive.Name = GXCCtl;
            chkEmployeeIsActive.WebTags = "";
            chkEmployeeIsActive.Caption = "";
            AssignProp("", false, chkEmployeeIsActive_Internalname, "TitleCaption", chkEmployeeIsActive.Caption, !bGXsfl_39_Refreshing);
            chkEmployeeIsActive.CheckedValue = "false";
            A112EmployeeIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A112EmployeeIsActive));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkEmployeeIsActive_Internalname,StringUtil.BoolToStr( A112EmployeeIsActive),(string)"",(string)"",chkEmployeeIsActive.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeVactionDays_Internalname,StringUtil.LTrim( StringUtil.NToC( A146EmployeeVactionDays, 4, 1, ".", "")),StringUtil.LTrim( context.localUtil.Format( A146EmployeeVactionDays, "Z9.9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeVactionDays_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeBalance_Internalname,StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")),StringUtil.LTrim( context.localUtil.Format( A147EmployeeBalance, "Z9.9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeBalance_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavEmployeebalance_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEmployeebalance_Internalname,StringUtil.LTrim( StringUtil.NToC( AV85EmployeeBalance, 4, 1, ".", "")),StringUtil.LTrim( ((edtavEmployeebalance_Enabled!=0) ? context.localUtil.Format( AV85EmployeeBalance, "Z9.9") : context.localUtil.Format( AV85EmployeeBalance, "Z9.9"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEmployeebalance_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavEmployeebalance_Visible,(int)edtavEmployeebalance_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes2V2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "EMPLOYEEISMANAGER_" + sGXsfl_39_idx;
         chkEmployeeIsManager.Name = GXCCtl;
         chkEmployeeIsManager.WebTags = "";
         chkEmployeeIsManager.Caption = "";
         AssignProp("", false, chkEmployeeIsManager_Internalname, "TitleCaption", chkEmployeeIsManager.Caption, !bGXsfl_39_Refreshing);
         chkEmployeeIsManager.CheckedValue = "false";
         A110EmployeeIsManager = StringUtil.StrToBool( StringUtil.BoolToStr( A110EmployeeIsManager));
         GXCCtl = "EMPLOYEEISACTIVE_" + sGXsfl_39_idx;
         chkEmployeeIsActive.Name = GXCCtl;
         chkEmployeeIsActive.WebTags = "";
         chkEmployeeIsActive.Caption = "";
         AssignProp("", false, chkEmployeeIsActive_Internalname, "TitleCaption", chkEmployeeIsActive.Caption, !bGXsfl_39_Refreshing);
         chkEmployeeIsActive.CheckedValue = "false";
         A112EmployeeIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A112EmployeeIsActive));
         /* End function init_web_controls */
      }

      protected void StartGridControl39( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"39\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavInvite_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Employee Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+((chkEmployeeIsManager.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Is HR Manager") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+((chkEmployeeIsActive.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Is Active") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavEmployeebalance_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Balance") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV70Invite)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavInvite_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavInvite_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV57Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV59Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EmployeeFirstName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A108EmployeeLastName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A148EmployeeName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A109EmployeeEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A101CompanyName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A110EmployeeIsManager)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEmployeeIsManager.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A111GAMUserGUID));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A112EmployeeIsActive)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEmployeeIsActive.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A146EmployeeVactionDays, 4, 1, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV85EmployeeBalance, 4, 1, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEmployeebalance_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEmployeebalance_Visible), 5, 0, ".", "")));
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
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavInvite_Internalname = "vINVITE";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME";
         edtEmployeeLastName_Internalname = "EMPLOYEELASTNAME";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         edtEmployeeEmail_Internalname = "EMPLOYEEEMAIL";
         edtCompanyId_Internalname = "COMPANYID";
         edtCompanyName_Internalname = "COMPANYNAME";
         chkEmployeeIsManager_Internalname = "EMPLOYEEISMANAGER";
         edtGAMUserGUID_Internalname = "GAMUSERGUID";
         chkEmployeeIsActive_Internalname = "EMPLOYEEISACTIVE";
         edtEmployeeVactionDays_Internalname = "EMPLOYEEVACTIONDAYS";
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE";
         edtavEmployeebalance_Internalname = "vEMPLOYEEBALANCE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
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
         edtavEmployeebalance_Jsonclick = "";
         edtavEmployeebalance_Enabled = 1;
         edtEmployeeBalance_Jsonclick = "";
         edtEmployeeVactionDays_Jsonclick = "";
         chkEmployeeIsActive.Caption = "";
         edtGAMUserGUID_Jsonclick = "";
         chkEmployeeIsManager.Caption = "";
         edtCompanyName_Jsonclick = "";
         edtCompanyId_Jsonclick = "";
         edtEmployeeEmail_Jsonclick = "";
         edtEmployeeName_Jsonclick = "";
         edtEmployeeLastName_Jsonclick = "";
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         edtavInvite_Jsonclick = "";
         edtavInvite_Class = "Attribute";
         edtavInvite_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtavEmployeebalance_Visible = -1;
         chkEmployeeIsActive.Visible = -1;
         chkEmployeeIsManager.Visible = -1;
         edtEmployeeEmail_Visible = -1;
         edtEmployeeName_Visible = -1;
         edtEmployeeBalance_Enabled = 0;
         edtEmployeeVactionDays_Enabled = 0;
         chkEmployeeIsActive.Enabled = 0;
         edtGAMUserGUID_Enabled = 0;
         chkEmployeeIsManager.Enabled = 0;
         edtCompanyName_Enabled = 0;
         edtCompanyId_Enabled = 0;
         edtEmployeeEmail_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         edtEmployeeLastName_Enabled = 0;
         edtEmployeeFirstName_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "EmployeeWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues|FixedValues|";
         Ddo_grid_Includedatalist = "T|T|T|T|";
         Ddo_grid_Filtertype = "Character|Character|||";
         Ddo_grid_Includefilter = "T|T|||";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|";
         Ddo_grid_Columnssortvalues = "2|3|4|5|";
         Ddo_grid_Columnids = "6:EmployeeName|7:EmployeeEmail|10:EmployeeIsManager|12:EmployeeIsActive|15:EmployeeBalance";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
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
         Form.Caption = " Employees";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV99Udparg11","fld":"vUDPARG11","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV80InviteEmployee","fld":"vINVITEEMPLOYEE","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"edtEmployeeEmail_Visible","ctrl":"EMPLOYEEEMAIL","prop":"Visible"},{"av":"chkEmployeeIsManager.Visible","ctrl":"EMPLOYEEISMANAGER","prop":"Visible"},{"av":"chkEmployeeIsActive.Visible","ctrl":"EMPLOYEEISACTIVE","prop":"Visible"},{"av":"edtavEmployeebalance_Visible","ctrl":"vEMPLOYEEBALANCE","prop":"Visible"},{"av":"AV55GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV56GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E122V2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV99Udparg11","fld":"vUDPARG11","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV80InviteEmployee","fld":"vINVITEEMPLOYEE","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E132V2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV99Udparg11","fld":"vUDPARG11","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV80InviteEmployee","fld":"vINVITEEMPLOYEE","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E152V2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV99Udparg11","fld":"vUDPARG11","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV80InviteEmployee","fld":"vINVITEEMPLOYEE","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E202V2","iparms":[{"av":"A111GAMUserGUID","fld":"GAMUSERGUID"},{"av":"AV80InviteEmployee","fld":"vINVITEEMPLOYEE","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV70Invite","fld":"vINVITE"},{"av":"edtavInvite_Class","ctrl":"vINVITE","prop":"Class"},{"av":"AV57Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV59Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"AV85EmployeeBalance","fld":"vEMPLOYEEBALANCE","pic":"Z9.9"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E162V2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV99Udparg11","fld":"vUDPARG11","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV80InviteEmployee","fld":"vINVITEEMPLOYEE","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"edtEmployeeEmail_Visible","ctrl":"EMPLOYEEEMAIL","prop":"Visible"},{"av":"chkEmployeeIsManager.Visible","ctrl":"EMPLOYEEISMANAGER","prop":"Visible"},{"av":"chkEmployeeIsActive.Visible","ctrl":"EMPLOYEEISACTIVE","prop":"Visible"},{"av":"edtavEmployeebalance_Visible","ctrl":"vEMPLOYEEBALANCE","prop":"Visible"},{"av":"AV55GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV56GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E112V2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV99Udparg11","fld":"vUDPARG11","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV80InviteEmployee","fld":"vINVITEEMPLOYEE","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV15GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"edtEmployeeEmail_Visible","ctrl":"EMPLOYEEEMAIL","prop":"Visible"},{"av":"chkEmployeeIsManager.Visible","ctrl":"EMPLOYEEISMANAGER","prop":"Visible"},{"av":"chkEmployeeIsActive.Visible","ctrl":"EMPLOYEEISACTIVE","prop":"Visible"},{"av":"edtavEmployeebalance_Visible","ctrl":"vEMPLOYEEBALANCE","prop":"Visible"},{"av":"AV55GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV56GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E172V2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV99Udparg11","fld":"vUDPARG11","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV80InviteEmployee","fld":"vINVITEEMPLOYEE","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"edtEmployeeEmail_Visible","ctrl":"EMPLOYEEEMAIL","prop":"Visible"},{"av":"chkEmployeeIsManager.Visible","ctrl":"EMPLOYEEISMANAGER","prop":"Visible"},{"av":"chkEmployeeIsActive.Visible","ctrl":"EMPLOYEEISACTIVE","prop":"Visible"},{"av":"edtavEmployeebalance_Visible","ctrl":"vEMPLOYEEBALANCE","prop":"Visible"},{"av":"AV55GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV56GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV28ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","""{"handler":"E142V2","iparms":[{"av":"Ddo_agexport_Activeeventkey","ctrl":"DDO_AGEXPORT","prop":"ActiveEventKey"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"}]""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",""","oparms":[{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV30ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV89Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV66TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV67TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV37TFEmployeeEmail","fld":"vTFEMPLOYEEEMAIL"},{"av":"AV38TFEmployeeEmail_Sel","fld":"vTFEMPLOYEEEMAIL_SEL"},{"av":"AV43TFEmployeeIsManager_Sel","fld":"vTFEMPLOYEEISMANAGER_SEL","pic":"9"},{"av":"AV46TFEmployeeIsActive_Sel","fld":"vTFEMPLOYEEISACTIVE_SEL","pic":"9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV99Udparg11","fld":"vUDPARG11","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV68ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV80InviteEmployee","fld":"vINVITEEMPLOYEE","hsh":true},{"av":"AV58IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV60IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV65IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"}]}""");
         setEventMetadata("VINVITE.CLICK","""{"handler":"E212V2","iparms":[{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("VALID_COMPANYID","""{"handler":"Valid_Companyid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Employeebalance","iparms":[]}""");
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
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV20FilterFullText = "";
         AV25ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV89Pgmname = "";
         AV66TFEmployeeName = "";
         AV67TFEmployeeName_Sel = "";
         AV37TFEmployeeEmail = "";
         AV38TFEmployeeEmail_Sel = "";
         AV68ProjectIds = new GxSimpleCollection<long>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV28ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV9GridAppliedFilters = "";
         AV63AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV51DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV70Invite = "";
         AV57Update = "";
         AV59Delete = "";
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         A101CompanyName = "";
         A111GAMUserGUID = "";
         lV90Employeewwds_4_filterfulltext = "";
         lV91Employeewwds_5_tfemployeename = "";
         lV93Employeewwds_7_tfemployeeemail = "";
         AV69EmployeeIds = new GxSimpleCollection<long>();
         AV90Employeewwds_4_filterfulltext = "";
         AV92Employeewwds_6_tfemployeename_sel = "";
         AV91Employeewwds_5_tfemployeename = "";
         AV94Employeewwds_8_tfemployeeemail_sel = "";
         AV93Employeewwds_7_tfemployeeemail = "";
         H002V2_A147EmployeeBalance = new decimal[1] ;
         H002V2_A146EmployeeVactionDays = new decimal[1] ;
         H002V2_A112EmployeeIsActive = new bool[] {false} ;
         H002V2_A111GAMUserGUID = new string[] {""} ;
         H002V2_A110EmployeeIsManager = new bool[] {false} ;
         H002V2_A101CompanyName = new string[] {""} ;
         H002V2_A100CompanyId = new long[1] ;
         H002V2_A109EmployeeEmail = new string[] {""} ;
         H002V2_A148EmployeeName = new string[] {""} ;
         H002V2_A108EmployeeLastName = new string[] {""} ;
         H002V2_A107EmployeeFirstName = new string[] {""} ;
         H002V2_A106EmployeeId = new long[1] ;
         H002V3_AGRID_nRecordCount = new long[1] ;
         AV83Message = "";
         AV12HTTPRequest = new GxHttpRequest( context);
         AV64AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV52GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV53GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV23ColumnsSelectorXML = "";
         AV77GamUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         GridRow = new GXWebRow();
         AV29ManageFiltersXml = "";
         AV24UserCustomValue = "";
         AV26ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV16GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char8 = "";
         GXt_char5 = "";
         AV13TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV21ExcelFilename = "";
         AV22ErrorMessage = "";
         AV79successMessage = "";
         H002V4_A162ProjectManagerId = new long[1] ;
         H002V4_n162ProjectManagerId = new bool[] {false} ;
         H002V4_A102ProjectId = new long[1] ;
         GXt_objcol_int9 = new GxSimpleCollection<long>();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeeww__default(),
            new Object[][] {
                new Object[] {
               H002V2_A147EmployeeBalance, H002V2_A146EmployeeVactionDays, H002V2_A112EmployeeIsActive, H002V2_A111GAMUserGUID, H002V2_A110EmployeeIsManager, H002V2_A101CompanyName, H002V2_A100CompanyId, H002V2_A109EmployeeEmail, H002V2_A148EmployeeName, H002V2_A108EmployeeLastName,
               H002V2_A107EmployeeFirstName, H002V2_A106EmployeeId
               }
               , new Object[] {
               H002V3_AGRID_nRecordCount
               }
               , new Object[] {
               H002V4_A162ProjectManagerId, H002V4_n162ProjectManagerId, H002V4_A102ProjectId
               }
            }
         );
         AV89Pgmname = "EmployeeWW";
         /* GeneXus formulas. */
         AV89Pgmname = "EmployeeWW";
         edtavInvite_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavEmployeebalance_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV17OrderedBy ;
      private short AV30ManageFiltersExecutionStep ;
      private short AV43TFEmployeeIsManager_Sel ;
      private short AV46TFEmployeeIsActive_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV95Employeewwds_9_tfemployeeismanager_sel ;
      private short AV96Employeewwds_10_tfemployeeisactive_sel ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_39 ;
      private int nGXsfl_39_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavInvite_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int edtavEmployeebalance_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeFirstName_Enabled ;
      private int edtEmployeeLastName_Enabled ;
      private int edtEmployeeName_Enabled ;
      private int edtEmployeeEmail_Enabled ;
      private int edtCompanyId_Enabled ;
      private int edtCompanyName_Enabled ;
      private int edtGAMUserGUID_Enabled ;
      private int edtEmployeeVactionDays_Enabled ;
      private int edtEmployeeBalance_Enabled ;
      private int edtEmployeeName_Visible ;
      private int edtEmployeeEmail_Visible ;
      private int edtavEmployeebalance_Visible ;
      private int AV54PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV97GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A162ProjectManagerId ;
      private long AV99Udparg11 ;
      private long A102ProjectId ;
      private long AV55GridCurrentPage ;
      private long AV56GridPageCount ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long GRID_nCurrentRecord ;
      private long AV88Udparg3 ;
      private long GRID_nRecordCount ;
      private decimal A146EmployeeVactionDays ;
      private decimal A147EmployeeBalance ;
      private decimal AV85EmployeeBalance ;
      private decimal GXt_decimal6 ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV89Pgmname ;
      private string AV66TFEmployeeName ;
      private string AV67TFEmployeeName_Sel ;
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
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV70Invite ;
      private string edtavInvite_Internalname ;
      private string AV57Update ;
      private string edtavUpdate_Internalname ;
      private string AV59Delete ;
      private string edtavDelete_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string A107EmployeeFirstName ;
      private string edtEmployeeFirstName_Internalname ;
      private string A108EmployeeLastName ;
      private string edtEmployeeLastName_Internalname ;
      private string A148EmployeeName ;
      private string edtEmployeeName_Internalname ;
      private string edtEmployeeEmail_Internalname ;
      private string edtCompanyId_Internalname ;
      private string A101CompanyName ;
      private string edtCompanyName_Internalname ;
      private string chkEmployeeIsManager_Internalname ;
      private string edtGAMUserGUID_Internalname ;
      private string chkEmployeeIsActive_Internalname ;
      private string edtEmployeeVactionDays_Internalname ;
      private string edtEmployeeBalance_Internalname ;
      private string edtavEmployeebalance_Internalname ;
      private string lV91Employeewwds_5_tfemployeename ;
      private string AV92Employeewwds_6_tfemployeename_sel ;
      private string AV91Employeewwds_5_tfemployeename ;
      private string edtavInvite_Class ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string GXt_char8 ;
      private string GXt_char5 ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavInvite_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeFirstName_Jsonclick ;
      private string edtEmployeeLastName_Jsonclick ;
      private string edtEmployeeName_Jsonclick ;
      private string edtEmployeeEmail_Jsonclick ;
      private string edtCompanyId_Jsonclick ;
      private string edtCompanyName_Jsonclick ;
      private string GXCCtl ;
      private string edtGAMUserGUID_Jsonclick ;
      private string edtEmployeeVactionDays_Jsonclick ;
      private string edtEmployeeBalance_Jsonclick ;
      private string edtavEmployeebalance_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18OrderedDsc ;
      private bool n162ProjectManagerId ;
      private bool AV80InviteEmployee ;
      private bool AV58IsAuthorized_Update ;
      private bool AV60IsAuthorized_Delete ;
      private bool AV65IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV86Udparg1 ;
      private bool AV87Udparg2 ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool GXt_boolean2 ;
      private bool gx_refresh_fired ;
      private bool AV78isActive ;
      private bool AV81isActiveEmployee ;
      private bool GXt_boolean3 ;
      private string AV23ColumnsSelectorXML ;
      private string AV29ManageFiltersXml ;
      private string AV24UserCustomValue ;
      private string AV20FilterFullText ;
      private string AV37TFEmployeeEmail ;
      private string AV38TFEmployeeEmail_Sel ;
      private string AV9GridAppliedFilters ;
      private string A109EmployeeEmail ;
      private string A111GAMUserGUID ;
      private string lV90Employeewwds_4_filterfulltext ;
      private string lV93Employeewwds_7_tfemployeeemail ;
      private string AV90Employeewwds_4_filterfulltext ;
      private string AV94Employeewwds_8_tfemployeeemail_sel ;
      private string AV93Employeewwds_7_tfemployeeemail ;
      private string AV83Message ;
      private string AV21ExcelFilename ;
      private string AV22ErrorMessage ;
      private string AV79successMessage ;
      private IGxSession AV27Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV12HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkEmployeeIsManager ;
      private GXCheckbox chkEmployeeIsActive ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelector ;
      private GxSimpleCollection<long> AV68ProjectIds ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV28ManageFiltersData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV63AGExportData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV51DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV15GridState ;
      private GxSimpleCollection<long> AV69EmployeeIds ;
      private IDataStoreProvider pr_default ;
      private decimal[] H002V2_A147EmployeeBalance ;
      private decimal[] H002V2_A146EmployeeVactionDays ;
      private bool[] H002V2_A112EmployeeIsActive ;
      private string[] H002V2_A111GAMUserGUID ;
      private bool[] H002V2_A110EmployeeIsManager ;
      private string[] H002V2_A101CompanyName ;
      private long[] H002V2_A100CompanyId ;
      private string[] H002V2_A109EmployeeEmail ;
      private string[] H002V2_A148EmployeeName ;
      private string[] H002V2_A108EmployeeLastName ;
      private string[] H002V2_A107EmployeeFirstName ;
      private long[] H002V2_A106EmployeeId ;
      private long[] H002V3_AGRID_nRecordCount ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item AV64AGExportDataItem ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV52GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV53GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV77GamUser ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV26ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV16GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV13TrnContext ;
      private long[] H002V4_A162ProjectManagerId ;
      private bool[] H002V4_n162ProjectManagerId ;
      private long[] H002V4_A102ProjectId ;
      private GxSimpleCollection<long> GXt_objcol_int9 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class employeeww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002V2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV69EmployeeIds ,
                                             string AV90Employeewwds_4_filterfulltext ,
                                             string AV92Employeewwds_6_tfemployeename_sel ,
                                             string AV91Employeewwds_5_tfemployeename ,
                                             string AV94Employeewwds_8_tfemployeeemail_sel ,
                                             string AV93Employeewwds_7_tfemployeeemail ,
                                             short AV95Employeewwds_9_tfemployeeismanager_sel ,
                                             short AV96Employeewwds_10_tfemployeeisactive_sel ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool AV86Udparg1 ,
                                             bool AV87Udparg2 ,
                                             long A100CompanyId ,
                                             long AV88Udparg3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[12];
         Object[] GXv_Object11 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.EmployeeBalance, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.GAMUserGUID, T1.EmployeeIsManager, T2.CompanyName, T1.CompanyId, T1.EmployeeEmail, T1.EmployeeName, T1.EmployeeLastName, T1.EmployeeFirstName, T1.EmployeeId";
         sFromString = " FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         sOrderString = "";
         AddWhere(sWhereString, "(Not ( :AV86Udparg1 and Not :AV87Udparg2) or ( T1.CompanyId = :AV88Udparg3))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Employeewwds_4_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.EmployeeName like '%' || :lV90Employeewwds_4_filterfulltext) or ( T1.EmployeeEmail like '%' || :lV90Employeewwds_4_filterfulltext))");
         }
         else
         {
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Employeewwds_6_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Employeewwds_5_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV91Employeewwds_5_tfemployeename)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Employeewwds_6_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV92Employeewwds_6_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV92Employeewwds_6_tfemployeename_sel))");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( StringUtil.StrCmp(AV92Employeewwds_6_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Employeewwds_8_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Employeewwds_7_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV93Employeewwds_7_tfemployeeemail)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Employeewwds_8_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV94Employeewwds_8_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV94Employeewwds_8_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( StringUtil.StrCmp(AV94Employeewwds_8_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( AV95Employeewwds_9_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV95Employeewwds_9_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( AV96Employeewwds_10_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV96Employeewwds_10_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV69EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         if ( AV17OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.EmployeeFirstName, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeName, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeName DESC, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeEmail";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeEmail DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeIsManager, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeIsManager DESC, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeIsActive, T1.EmployeeId";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeIsActive DESC, T1.EmployeeId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.EmployeeId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H002V3( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV69EmployeeIds ,
                                             string AV90Employeewwds_4_filterfulltext ,
                                             string AV92Employeewwds_6_tfemployeename_sel ,
                                             string AV91Employeewwds_5_tfemployeename ,
                                             string AV94Employeewwds_8_tfemployeeemail_sel ,
                                             string AV93Employeewwds_7_tfemployeeemail ,
                                             short AV95Employeewwds_9_tfemployeeismanager_sel ,
                                             short AV96Employeewwds_10_tfemployeeisactive_sel ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             bool AV86Udparg1 ,
                                             bool AV87Udparg2 ,
                                             long A100CompanyId ,
                                             long AV88Udparg3 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[9];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "(Not ( :AV86Udparg1 and Not :AV87Udparg2) or ( T1.CompanyId = :AV88Udparg3))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Employeewwds_4_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.EmployeeName like '%' || :lV90Employeewwds_4_filterfulltext) or ( T1.EmployeeEmail like '%' || :lV90Employeewwds_4_filterfulltext))");
         }
         else
         {
            GXv_int12[3] = 1;
            GXv_int12[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Employeewwds_6_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Employeewwds_5_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV91Employeewwds_5_tfemployeename)");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Employeewwds_6_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV92Employeewwds_6_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV92Employeewwds_6_tfemployeename_sel))");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( StringUtil.StrCmp(AV92Employeewwds_6_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Employeewwds_8_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Employeewwds_7_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV93Employeewwds_7_tfemployeeemail)");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Employeewwds_8_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV94Employeewwds_8_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV94Employeewwds_8_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( StringUtil.StrCmp(AV94Employeewwds_8_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( AV95Employeewwds_9_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV95Employeewwds_9_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( AV96Employeewwds_10_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV96Employeewwds_10_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV69EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002V2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] , (bool)dynConstraints[15] , (bool)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] );
               case 1 :
                     return conditional_H002V3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] , (bool)dynConstraints[15] , (bool)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002V4;
          prmH002V4 = new Object[] {
          new ParDef("AV99Udparg11",GXType.Int64,10,0)
          };
          Object[] prmH002V2;
          prmH002V2 = new Object[] {
          new ParDef("AV86Udparg1",GXType.Boolean,4,0) ,
          new ParDef("AV87Udparg2",GXType.Boolean,4,0) ,
          new ParDef("AV88Udparg3",GXType.Int64,10,0) ,
          new ParDef("lV90Employeewwds_4_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Employeewwds_4_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Employeewwds_5_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV92Employeewwds_6_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV93Employeewwds_7_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV94Employeewwds_8_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002V3;
          prmH002V3 = new Object[] {
          new ParDef("AV86Udparg1",GXType.Boolean,4,0) ,
          new ParDef("AV87Udparg2",GXType.Boolean,4,0) ,
          new ParDef("AV88Udparg3",GXType.Int64,10,0) ,
          new ParDef("lV90Employeewwds_4_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV90Employeewwds_4_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV91Employeewwds_5_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV92Employeewwds_6_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV93Employeewwds_7_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV94Employeewwds_8_tfemployeeemail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002V2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002V3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002V4", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV99Udparg11 ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002V4,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
