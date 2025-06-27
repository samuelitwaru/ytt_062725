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
   public class wpleavereport : GXDataArea
   {
      public wpleavereport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpleavereport( IGxContext context )
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
         nRC_GXsfl_77 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_77"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_77_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_77_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_77_idx = GetPar( "sGXsfl_77_idx");
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
         AV26ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21ColumnsSelector);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV13GridState);
         AV72Pgmname = GetPar( "Pgmname");
         AV48Date = context.localUtil.ParseDateParm( GetPar( "Date"));
         AV49Date_To = context.localUtil.ParseDateParm( GetPar( "Date_To"));
         AV40PeriodicCategory = (short)(Math.Round(NumberUtil.Val( GetPar( "PeriodicCategory"), "."), 18, MidpointRounding.ToEven));
         AV39EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ProjectId);
         AV60CompanyLocationId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyLocationId"), "."), 18, MidpointRounding.ToEven));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         AV41LocationId = (long)(Math.Round(NumberUtil.Val( GetPar( "LocationId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
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
            return "wpleavereport_Execute" ;
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
         PA2Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2Z2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpleavereport.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV72Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV72Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41LocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV41LocationId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtleavereport", AV16SDTLeaveReport);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtleavereport", AV16SDTLeaveReport);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_77", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_77), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV27DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV27DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPERIODICCATEGORY_DATA", AV42PeriodicCategory_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPERIODICCATEGORY_DATA", AV42PeriodicCategory_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID_DATA", AV44EmployeeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID_DATA", AV44EmployeeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID_DATA", AV57ProjectId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID_DATA", AV57ProjectId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYLOCATIONID_DATA", AV61CompanyLocationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYLOCATIONID_DATA", AV61CompanyLocationId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV31GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV34AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV34AGExportData);
         }
         GxWebStd.gx_hidden_field( context, "vDATE", context.localUtil.DToC( AV48Date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATE_TO", context.localUtil.DToC( AV49Date_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDATE_RANGEPICKEROPTIONS", AV59Date_RangePickerOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDATE_RANGEPICKEROPTIONS", AV59Date_RangePickerOptions);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ManageFiltersExecutionStep), 1, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV13GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV13GridState);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV72Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV72Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vPERIODICCATEGORY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40PeriodicCategory), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39EmployeeId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID", AV38ProjectId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID", AV38ProjectId);
         }
         GxWebStd.gx_hidden_field( context, "vCOMPANYLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60CompanyLocationId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTLEAVEREPORT", AV16SDTLeaveReport);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTLEAVEREPORT", AV16SDTLeaveReport);
         }
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41LocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV41LocationId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PERIODICCATEGORY_Cls", StringUtil.RTrim( Combo_periodiccategory_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PERIODICCATEGORY_Selectedvalue_set", StringUtil.RTrim( Combo_periodiccategory_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PERIODICCATEGORY_Datalisttype", StringUtil.RTrim( Combo_periodiccategory_Datalisttype));
         GxWebStd.gx_hidden_field( context, "COMBO_PERIODICCATEGORY_Datalistfixedvalues", StringUtil.RTrim( Combo_periodiccategory_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "COMBO_PERIODICCATEGORY_Emptyitem", StringUtil.BoolToStr( Combo_periodiccategory_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Cls", StringUtil.RTrim( Combo_employeeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_set", StringUtil.RTrim( Combo_employeeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedtext_set", StringUtil.RTrim( Combo_employeeid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Gamoauthtoken", StringUtil.RTrim( Combo_employeeid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Datalistproc", StringUtil.RTrim( Combo_employeeid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_employeeid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Emptyitemtext", StringUtil.RTrim( Combo_employeeid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Cls", StringUtil.RTrim( Combo_projectid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_set", StringUtil.RTrim( Combo_projectid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedtext_set", StringUtil.RTrim( Combo_projectid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Gamoauthtoken", StringUtil.RTrim( Combo_projectid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Allowmultipleselection", StringUtil.BoolToStr( Combo_projectid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Datalistproc", StringUtil.RTrim( Combo_projectid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_projectid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_projectid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Emptyitem", StringUtil.BoolToStr( Combo_projectid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Multiplevaluestype", StringUtil.RTrim( Combo_projectid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Cls", StringUtil.RTrim( Combo_companylocationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedtext_set", StringUtil.RTrim( Combo_companylocationid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Gamoauthtoken", StringUtil.RTrim( Combo_companylocationid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Datalistproc", StringUtil.RTrim( Combo_companylocationid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_companylocationid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Emptyitem", StringUtil.BoolToStr( Combo_companylocationid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Width", StringUtil.RTrim( Dvpanel_unnamedtable1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Cls", StringUtil.RTrim( Dvpanel_unnamedtable1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Title", StringUtil.RTrim( Dvpanel_unnamedtable1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoscroll));
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
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PERIODICCATEGORY_Selectedvalue_get", StringUtil.RTrim( Combo_periodiccategory_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PERIODICCATEGORY_Selectedvalue_get", StringUtil.RTrim( Combo_periodiccategory_Selectedvalue_get));
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
         if ( ! ( WebComp_Grid_dwc == null ) )
         {
            WebComp_Grid_dwc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE2Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2Z2( ) ;
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
         return formatLink("wpleavereport.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPLeaveReport" ;
      }

      public override string GetPgmdesc( )
      {
         return "" ;
      }

      protected void WB2Z0( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(77), 2, 0)+","+"null"+");", "Export", bttBtnagexport_Jsonclick, 0, "Export", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WPLeaveReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(77), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WPLeaveReport.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV24ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltertable_Internalname, 1, 100, "%", 100, "%", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:;grid-template-rows:;", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltertable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDate_rangetext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDate_rangetext_Internalname, "Date Range", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDate_rangetext_Internalname, AV51Date_RangeText, StringUtil.RTrim( context.localUtil.Format( AV51Date_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavDate_rangetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDate_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPLeaveReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfiltertextperiodiccategory_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFiltertextperiodiccategory_Internalname, "View", "", "", lblFiltertextperiodiccategory_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPLeaveReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_periodiccategory.SetProperty("Caption", Combo_periodiccategory_Caption);
            ucCombo_periodiccategory.SetProperty("Cls", Combo_periodiccategory_Cls);
            ucCombo_periodiccategory.SetProperty("DataListType", Combo_periodiccategory_Datalisttype);
            ucCombo_periodiccategory.SetProperty("DataListFixedValues", Combo_periodiccategory_Datalistfixedvalues);
            ucCombo_periodiccategory.SetProperty("EmptyItem", Combo_periodiccategory_Emptyitem);
            ucCombo_periodiccategory.SetProperty("DropDownOptionsTitleSettingsIcons", AV27DDO_TitleSettingsIcons);
            ucCombo_periodiccategory.SetProperty("DropDownOptionsData", AV42PeriodicCategory_Data);
            ucCombo_periodiccategory.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_periodiccategory_Internalname, "COMBO_PERIODICCATEGORYContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfiltertextemployeeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFiltertextemployeeid_Internalname, "Employee", "", "", lblFiltertextemployeeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPLeaveReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_employeeid.SetProperty("Caption", Combo_employeeid_Caption);
            ucCombo_employeeid.SetProperty("Cls", Combo_employeeid_Cls);
            ucCombo_employeeid.SetProperty("DataListProc", Combo_employeeid_Datalistproc);
            ucCombo_employeeid.SetProperty("DataListProcParametersPrefix", Combo_employeeid_Datalistprocparametersprefix);
            ucCombo_employeeid.SetProperty("EmptyItemText", Combo_employeeid_Emptyitemtext);
            ucCombo_employeeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV27DDO_TitleSettingsIcons);
            ucCombo_employeeid.SetProperty("DropDownOptionsData", AV44EmployeeId_Data);
            ucCombo_employeeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_employeeid_Internalname, "COMBO_EMPLOYEEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfiltertextprojectid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFiltertextprojectid_Internalname, "Project", "", "", lblFiltertextprojectid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPLeaveReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_projectid.SetProperty("Caption", Combo_projectid_Caption);
            ucCombo_projectid.SetProperty("Cls", Combo_projectid_Cls);
            ucCombo_projectid.SetProperty("AllowMultipleSelection", Combo_projectid_Allowmultipleselection);
            ucCombo_projectid.SetProperty("DataListProc", Combo_projectid_Datalistproc);
            ucCombo_projectid.SetProperty("DataListProcParametersPrefix", Combo_projectid_Datalistprocparametersprefix);
            ucCombo_projectid.SetProperty("IncludeOnlySelectedOption", Combo_projectid_Includeonlyselectedoption);
            ucCombo_projectid.SetProperty("EmptyItem", Combo_projectid_Emptyitem);
            ucCombo_projectid.SetProperty("MultipleValuesType", Combo_projectid_Multiplevaluestype);
            ucCombo_projectid.SetProperty("DropDownOptionsTitleSettingsIcons", AV27DDO_TitleSettingsIcons);
            ucCombo_projectid.SetProperty("DropDownOptionsData", AV57ProjectId_Data);
            ucCombo_projectid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_projectid_Internalname, "COMBO_PROJECTIDContainer");
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
            GxWebStd.gx_div_start( context, divTablesplittedfiltertextcompanylocationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFiltertextcompanylocationid_Internalname, "Location", "", "", lblFiltertextcompanylocationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WPLeaveReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_companylocationid.SetProperty("Caption", Combo_companylocationid_Caption);
            ucCombo_companylocationid.SetProperty("Cls", Combo_companylocationid_Cls);
            ucCombo_companylocationid.SetProperty("DataListProc", Combo_companylocationid_Datalistproc);
            ucCombo_companylocationid.SetProperty("DataListProcParametersPrefix", Combo_companylocationid_Datalistprocparametersprefix);
            ucCombo_companylocationid.SetProperty("EmptyItem", Combo_companylocationid_Emptyitem);
            ucCombo_companylocationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV27DDO_TitleSettingsIcons);
            ucCombo_companylocationid.SetProperty("DropDownOptionsData", AV61CompanyLocationId_Data);
            ucCombo_companylocationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_companylocationid_Internalname, "COMBO_COMPANYLOCATIONIDContainer");
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
            /* User Defined Control */
            ucDvpanel_unnamedtable1.SetProperty("Width", Dvpanel_unnamedtable1_Width);
            ucDvpanel_unnamedtable1.SetProperty("AutoWidth", Dvpanel_unnamedtable1_Autowidth);
            ucDvpanel_unnamedtable1.SetProperty("AutoHeight", Dvpanel_unnamedtable1_Autoheight);
            ucDvpanel_unnamedtable1.SetProperty("Cls", Dvpanel_unnamedtable1_Cls);
            ucDvpanel_unnamedtable1.SetProperty("Title", Dvpanel_unnamedtable1_Title);
            ucDvpanel_unnamedtable1.SetProperty("Collapsible", Dvpanel_unnamedtable1_Collapsible);
            ucDvpanel_unnamedtable1.SetProperty("Collapsed", Dvpanel_unnamedtable1_Collapsed);
            ucDvpanel_unnamedtable1.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable1_Showcollapseicon);
            ucDvpanel_unnamedtable1.SetProperty("IconPosition", Dvpanel_unnamedtable1_Iconposition);
            ucDvpanel_unnamedtable1.SetProperty("AutoScroll", Dvpanel_unnamedtable1_Autoscroll);
            ucDvpanel_unnamedtable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable1_Internalname, "DVPANEL_UNNAMEDTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE1Container"+"UnnamedTable1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", divUnnamedtable1_Height, "px", "CellNoPaddingHorizontal", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            StartGridControl77( ) ;
         }
         if ( wbEnd == 77 )
         {
            wbEnd = 0;
            nRC_GXsfl_77 = (int)(nGXsfl_77_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV62GXV1 = nGXsfl_77_idx;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV29GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV30GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV31GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_grid_dwc_Internalname, 1, 0, "px", 0, "px", divCell_grid_dwc_Class, "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0092"+"", StringUtil.RTrim( WebComp_Grid_dwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0092"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_77_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldGrid_dwc), StringUtil.Lower( WebComp_Grid_dwc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0092"+"");
                     }
                     WebComp_Grid_dwc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldGrid_dwc), StringUtil.Lower( WebComp_Grid_dwc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV34AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDate_rangepicker.SetProperty("Start Date", AV48Date);
            ucDate_rangepicker.SetProperty("End Date", AV49Date_To);
            ucDate_rangepicker.SetProperty("PickerOptions", AV59Date_RangePickerOptions);
            ucDate_rangepicker.Render(context, "wwp.daterangepicker", Date_rangepicker_Internalname, "DATE_RANGEPICKERContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV27DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV27DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV21ColumnsSelector);
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
         if ( wbEnd == 77 )
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
                  AV62GXV1 = nGXsfl_77_idx;
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

      protected void START2Z2( )
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
         Form.Meta.addItem("description", "", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2Z0( ) ;
      }

      protected void WS2Z2( )
      {
         START2Z2( ) ;
         EVT2Z2( ) ;
      }

      protected void EVT2Z2( )
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
                              E112Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PERIODICCATEGORY.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_periodiccategory.Onoptionclicked */
                              E122Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_EMPLOYEEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_employeeid.Onoptionclicked */
                              E132Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PROJECTID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_projectid.Onoptionclicked */
                              E142Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E152Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E162Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E172Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DATE_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Date_rangepicker.Daterangechanged */
                              E182Z2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E192Z2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "VDETAILWEBCOMPONENT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "VDETAILWEBCOMPONENT.CLICK") == 0 ) )
                           {
                              nGXsfl_77_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
                              SubsflControlProps_772( ) ;
                              AV62GXV1 = (int)(nGXsfl_77_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV16SDTLeaveReport.gxTpr_Periodcollection.Count >= AV62GXV1 ) && ( AV62GXV1 > 0 ) )
                              {
                                 AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem = ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1));
                                 AV52DetailWebComponent = cgiGet( edtavDetailwebcomponent_Internalname);
                                 AssignAttri("", false, edtavDetailwebcomponent_Internalname, AV52DetailWebComponent);
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
                                    E202Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E212Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E222Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDETAILWEBCOMPONENT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E232Z2 ();
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 92 )
                        {
                           OldGrid_dwc = cgiGet( "W0092");
                           if ( ( StringUtil.Len( OldGrid_dwc) == 0 ) || ( StringUtil.StrCmp(OldGrid_dwc, WebComp_Grid_dwc_Component) != 0 ) )
                           {
                              WebComp_Grid_dwc = getWebComponent(GetType(), "GeneXus.Programs", OldGrid_dwc, new Object[] {context} );
                              WebComp_Grid_dwc.ComponentInit();
                              WebComp_Grid_dwc.Name = "OldGrid_dwc";
                              WebComp_Grid_dwc_Component = OldGrid_dwc;
                           }
                           if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
                           {
                              WebComp_Grid_dwc.componentprocess("W0092", "", sEvt);
                           }
                           WebComp_Grid_dwc_Component = OldGrid_dwc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2Z2( )
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

      protected void PA2Z2( )
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
               GX_FocusControl = edtavDate_rangetext_Internalname;
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
         SubsflControlProps_772( ) ;
         while ( nGXsfl_77_idx <= nRC_GXsfl_77 )
         {
            sendrow_772( ) ;
            nGXsfl_77_idx = ((subGrid_Islastpage==1)&&(nGXsfl_77_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_77_idx+1);
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_772( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV26ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV21ColumnsSelector ,
                                       WorkWithPlus.workwithplus_web.SdtWWPGridState AV13GridState ,
                                       string AV72Pgmname ,
                                       DateTime AV48Date ,
                                       DateTime AV49Date_To ,
                                       short AV40PeriodicCategory ,
                                       long AV39EmployeeId ,
                                       GxSimpleCollection<long> AV38ProjectId ,
                                       long AV60CompanyLocationId ,
                                       DateTime Gx_date ,
                                       long AV41LocationId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2Z2( ) ;
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
         RF2Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV72Pgmname = "WPLeaveReport";
         Gx_date = DateTimeUtil.Today( context);
         edtavSdtleavereport_periodcollection__label_Enabled = 0;
         edtavSdtleavereport_periodcollection__fromdate_Enabled = 0;
         edtavSdtleavereport_periodcollection__todate_Enabled = 0;
         edtavSdtleavereport_periodcollection__mean_Enabled = 0;
         edtavSdtleavereport_periodcollection__number_Enabled = 0;
         edtavSdtleavereport_periodcollection__totalleave_Enabled = 0;
         edtavSdtleavereport_periodcollection__formattedtotalwork_Enabled = 0;
         edtavSdtleavereport_periodcollection__formattedtotalleave_Enabled = 0;
         edtavDetailwebcomponent_Enabled = 0;
      }

      protected void RF2Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 77;
         /* Execute user event: Refresh */
         E212Z2 ();
         nGXsfl_77_idx = 1;
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_772( ) ;
         bGXsfl_77_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
               {
                  WebComp_Grid_dwc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_772( ) ;
            /* Execute user event: Grid.Load */
            E222Z2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_77_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E222Z2 ();
            }
            wbEnd = 77;
            WB2Z0( ) ;
         }
         bGXsfl_77_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2Z2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV72Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV72Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41LocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV41LocationId), "ZZZZZZZZZ9"), context));
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
         return AV16SDTLeaveReport.gxTpr_Periodcollection.Count ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV72Pgmname = "WPLeaveReport";
         Gx_date = DateTimeUtil.Today( context);
         edtavSdtleavereport_periodcollection__label_Enabled = 0;
         edtavSdtleavereport_periodcollection__fromdate_Enabled = 0;
         edtavSdtleavereport_periodcollection__todate_Enabled = 0;
         edtavSdtleavereport_periodcollection__mean_Enabled = 0;
         edtavSdtleavereport_periodcollection__number_Enabled = 0;
         edtavSdtleavereport_periodcollection__totalleave_Enabled = 0;
         edtavSdtleavereport_periodcollection__formattedtotalwork_Enabled = 0;
         edtavSdtleavereport_periodcollection__formattedtotalleave_Enabled = 0;
         edtavDetailwebcomponent_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E202Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtleavereport"), AV16SDTLeaveReport);
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV27DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vPERIODICCATEGORY_DATA"), AV42PeriodicCategory_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEEID_DATA"), AV44EmployeeId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vPROJECTID_DATA"), AV57ProjectId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCOMPANYLOCATIONID_DATA"), AV61CompanyLocationId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV34AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDATE_RANGEPICKEROPTIONS"), AV59Date_RangePickerOptions);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTLEAVEREPORT"), AV16SDTLeaveReport);
            /* Read saved values. */
            nRC_GXsfl_77 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_77"), ".", ","), 18, MidpointRounding.ToEven));
            AV29GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV30GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV31GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV48Date = context.localUtil.CToD( cgiGet( "vDATE"), 0);
            AV49Date_To = context.localUtil.CToD( cgiGet( "vDATE_TO"), 0);
            AV60CompanyLocationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCOMPANYLOCATIONID"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Combo_periodiccategory_Cls = cgiGet( "COMBO_PERIODICCATEGORY_Cls");
            Combo_periodiccategory_Selectedvalue_set = cgiGet( "COMBO_PERIODICCATEGORY_Selectedvalue_set");
            Combo_periodiccategory_Datalisttype = cgiGet( "COMBO_PERIODICCATEGORY_Datalisttype");
            Combo_periodiccategory_Datalistfixedvalues = cgiGet( "COMBO_PERIODICCATEGORY_Datalistfixedvalues");
            Combo_periodiccategory_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PERIODICCATEGORY_Emptyitem"));
            Combo_employeeid_Cls = cgiGet( "COMBO_EMPLOYEEID_Cls");
            Combo_employeeid_Selectedvalue_set = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_set");
            Combo_employeeid_Selectedtext_set = cgiGet( "COMBO_EMPLOYEEID_Selectedtext_set");
            Combo_employeeid_Gamoauthtoken = cgiGet( "COMBO_EMPLOYEEID_Gamoauthtoken");
            Combo_employeeid_Datalistproc = cgiGet( "COMBO_EMPLOYEEID_Datalistproc");
            Combo_employeeid_Datalistprocparametersprefix = cgiGet( "COMBO_EMPLOYEEID_Datalistprocparametersprefix");
            Combo_employeeid_Emptyitemtext = cgiGet( "COMBO_EMPLOYEEID_Emptyitemtext");
            Combo_projectid_Cls = cgiGet( "COMBO_PROJECTID_Cls");
            Combo_projectid_Selectedvalue_set = cgiGet( "COMBO_PROJECTID_Selectedvalue_set");
            Combo_projectid_Selectedtext_set = cgiGet( "COMBO_PROJECTID_Selectedtext_set");
            Combo_projectid_Gamoauthtoken = cgiGet( "COMBO_PROJECTID_Gamoauthtoken");
            Combo_projectid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Allowmultipleselection"));
            Combo_projectid_Datalistproc = cgiGet( "COMBO_PROJECTID_Datalistproc");
            Combo_projectid_Datalistprocparametersprefix = cgiGet( "COMBO_PROJECTID_Datalistprocparametersprefix");
            Combo_projectid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Includeonlyselectedoption"));
            Combo_projectid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Emptyitem"));
            Combo_projectid_Multiplevaluestype = cgiGet( "COMBO_PROJECTID_Multiplevaluestype");
            Combo_companylocationid_Cls = cgiGet( "COMBO_COMPANYLOCATIONID_Cls");
            Combo_companylocationid_Selectedvalue_set = cgiGet( "COMBO_COMPANYLOCATIONID_Selectedvalue_set");
            Combo_companylocationid_Selectedtext_set = cgiGet( "COMBO_COMPANYLOCATIONID_Selectedtext_set");
            Combo_companylocationid_Gamoauthtoken = cgiGet( "COMBO_COMPANYLOCATIONID_Gamoauthtoken");
            Combo_companylocationid_Datalistproc = cgiGet( "COMBO_COMPANYLOCATIONID_Datalistproc");
            Combo_companylocationid_Datalistprocparametersprefix = cgiGet( "COMBO_COMPANYLOCATIONID_Datalistprocparametersprefix");
            Combo_companylocationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Emptyitem"));
            Dvpanel_unnamedtable1_Width = cgiGet( "DVPANEL_UNNAMEDTABLE1_Width");
            Dvpanel_unnamedtable1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autowidth"));
            Dvpanel_unnamedtable1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoheight"));
            Dvpanel_unnamedtable1_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE1_Cls");
            Dvpanel_unnamedtable1_Title = cgiGet( "DVPANEL_UNNAMEDTABLE1_Title");
            Dvpanel_unnamedtable1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsible"));
            Dvpanel_unnamedtable1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsed"));
            Dvpanel_unnamedtable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Showcollapseicon"));
            Dvpanel_unnamedtable1_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE1_Iconposition");
            Dvpanel_unnamedtable1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoscroll"));
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
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
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
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            Combo_projectid_Selectedvalue_get = cgiGet( "COMBO_PROJECTID_Selectedvalue_get");
            Combo_employeeid_Selectedvalue_get = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_get");
            Combo_periodiccategory_Selectedvalue_get = cgiGet( "COMBO_PERIODICCATEGORY_Selectedvalue_get");
            nRC_GXsfl_77 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_77"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_77_fel_idx = 0;
            while ( nGXsfl_77_fel_idx < nRC_GXsfl_77 )
            {
               nGXsfl_77_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_77_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_77_fel_idx+1);
               sGXsfl_77_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_772( ) ;
               AV62GXV1 = (int)(nGXsfl_77_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV16SDTLeaveReport.gxTpr_Periodcollection.Count >= AV62GXV1 ) && ( AV62GXV1 > 0 ) )
               {
                  AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem = ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1));
                  AV52DetailWebComponent = cgiGet( edtavDetailwebcomponent_Internalname);
               }
            }
            if ( nGXsfl_77_fel_idx == 0 )
            {
               nGXsfl_77_idx = 1;
               sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
               SubsflControlProps_772( ) ;
            }
            nGXsfl_77_fel_idx = 1;
            /* Read variables values. */
            AV51Date_RangeText = cgiGet( edtavDate_rangetext_Internalname);
            AssignAttri("", false, "AV51Date_RangeText", AV51Date_RangeText);
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
         E202Z2 ();
         if (returnInSub) return;
      }

      protected void E202Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV48Date = Gx_date;
         AssignAttri("", false, "AV48Date", context.localUtil.Format(AV48Date, "99/99/99"));
         AV49Date_To = Gx_date;
         AssignAttri("", false, "AV49Date_To", context.localUtil.Format(AV49Date_To, "99/99/99"));
         AV39EmployeeId = 0;
         AssignAttri("", false, "AV39EmployeeId", StringUtil.LTrimStr( (decimal)(AV39EmployeeId), 10, 0));
         AV40PeriodicCategory = 2;
         AssignAttri("", false, "AV40PeriodicCategory", StringUtil.LTrimStr( (decimal)(AV40PeriodicCategory), 4, 0));
         AV41LocationId = 0;
         AssignAttri("", false, "AV41LocationId", StringUtil.LTrimStr( (decimal)(AV41LocationId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV41LocationId), "ZZZZZZZZZ9"), context));
         GXt_SdtSDTLeaveReport1 = AV16SDTLeaveReport;
         new dpleavereport(context ).execute(  AV48Date,  AV49Date_To,  AV39EmployeeId,  AV41LocationId,  AV38ProjectId,  AV40PeriodicCategory, out  GXt_SdtSDTLeaveReport1) ;
         AV16SDTLeaveReport = GXt_SdtSDTLeaveReport1;
         gx_BV77 = true;
         divCell_grid_dwc_Class = "Invisible WCD_"+StringUtil.Upper( subGrid_Internalname);
         AssignProp("", false, divCell_grid_dwc_Internalname, "Class", divCell_grid_dwc_Class, true);
         divUnnamedtable1_Height = 1;
         AssignProp("", false, divUnnamedtable1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divUnnamedtable1_Height), 9, 0), true);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV27DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV27DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         AV45GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV46GAMErrors);
         Combo_companylocationid_Gamoauthtoken = AV45GAMSession.gxTpr_Token;
         ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "GAMOAuthToken", Combo_companylocationid_Gamoauthtoken);
         Combo_projectid_Gamoauthtoken = AV45GAMSession.gxTpr_Token;
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "GAMOAuthToken", Combo_projectid_Gamoauthtoken);
         Combo_employeeid_Gamoauthtoken = AV45GAMSession.gxTpr_Token;
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "GAMOAuthToken", Combo_employeeid_Gamoauthtoken);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV10HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV34AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV35AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV35AGExportDataItem.gxTpr_Title = "Excel";
         AV35AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV35AGExportDataItem.gxTpr_Eventkey = "Export";
         AV35AGExportDataItem.gxTpr_Isdivider = false;
         AV34AGExportData.Add(AV35AGExportDataItem, 0);
         this.executeUsercontrolMethod("", false, "DATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDate_rangetext_Internalname});
         GXt_SdtWWPDateRangePickerOptions3 = AV59Date_RangePickerOptions;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_getoptionsreports(context ).execute( out  GXt_SdtWWPDateRangePickerOptions3) ;
         AV59Date_RangePickerOptions = GXt_SdtWWPDateRangePickerOptions3;
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV27DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV27DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E212Z2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV26ManageFiltersExecutionStep == 1 )
         {
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV26ManageFiltersExecutionStep == 2 )
         {
            AV26ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV23Session.Get("WPLeaveReportColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("WPLeaveReportColumnsSelector");
            AV21ColumnsSelector.FromXml(AV19ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S142 ();
            if (returnInSub) return;
         }
         edtavSdtleavereport_periodcollection__label_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdtleavereport_periodcollection__label_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtleavereport_periodcollection__label_Visible), 5, 0), !bGXsfl_77_Refreshing);
         edtavSdtleavereport_periodcollection__fromdate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdtleavereport_periodcollection__fromdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtleavereport_periodcollection__fromdate_Visible), 5, 0), !bGXsfl_77_Refreshing);
         edtavSdtleavereport_periodcollection__todate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdtleavereport_periodcollection__todate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtleavereport_periodcollection__todate_Visible), 5, 0), !bGXsfl_77_Refreshing);
         edtavSdtleavereport_periodcollection__formattedtotalwork_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdtleavereport_periodcollection__formattedtotalwork_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtleavereport_periodcollection__formattedtotalwork_Visible), 5, 0), !bGXsfl_77_Refreshing);
         edtavSdtleavereport_periodcollection__formattedtotalleave_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavSdtleavereport_periodcollection__formattedtotalleave_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSdtleavereport_periodcollection__formattedtotalleave_Visible), 5, 0), !bGXsfl_77_Refreshing);
         AV53LoadGridData = (bool)(((AV13GridState.gxTpr_Filtervalues.Count>0)));
         Gridpaginationbar_Emptygridcaption = (AV53LoadGridData ? "No records found" : "Apply at least one filter to show data");
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S152 ();
         if (returnInSub) return;
         AV29GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV29GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV29GridCurrentPage), 10, 0));
         AV30GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV30GridPageCount", StringUtil.LTrimStr( (decimal)(AV30GridPageCount), 10, 0));
         GXt_char4 = AV31GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV72Pgmname, out  GXt_char4) ;
         AV31GridAppliedFilters = GXt_char4;
         AssignAttri("", false, "AV31GridAppliedFilters", AV31GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
      }

      protected void E152Z2( )
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
            AV28PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV28PageToGo) ;
         }
      }

      protected void E162Z2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E222Z2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV16SDTLeaveReport.gxTpr_Periodcollection.Count )
         {
            AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem = ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1));
            AV52DetailWebComponent = "Details";
            AssignAttri("", false, edtavDetailwebcomponent_Internalname, AV52DetailWebComponent);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 77;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_772( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_77_Refreshing )
            {
               DoAjaxLoad(77, GridRow);
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E192Z2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WPLeaveReportColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
      }

      protected void E112Z2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S132 ();
            if (returnInSub) return;
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("WPLeaveReportFilters")),UrlEncode(StringUtil.RTrim(AV72Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("WPLeaveReportFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char4 = AV25ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WPLeaveReportFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char4) ;
            AV25ManageFiltersXml = GXt_char4;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if (returnInSub) return;
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV72Pgmname+"GridState",  AV25ManageFiltersXml) ;
               AV13GridState.FromXml(AV25ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ProjectId", AV38ProjectId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42PeriodicCategory_Data", AV42PeriodicCategory_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E172Z2( )
      {
         AV62GXV1 = (int)(nGXsfl_77_idx+GRID_nFirstRecordOnPage);
         if ( ( AV62GXV1 > 0 ) && ( AV16SDTLeaveReport.gxTpr_Periodcollection.Count >= AV62GXV1 ) )
         {
            AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem = ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1));
         }
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S182 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ProjectId", AV38ProjectId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42PeriodicCategory_Data", AV42PeriodicCategory_Data);
      }

      protected void E182Z2( )
      {
         AV62GXV1 = (int)(nGXsfl_77_idx+GRID_nFirstRecordOnPage);
         if ( ( AV62GXV1 > 0 ) && ( AV16SDTLeaveReport.gxTpr_Periodcollection.Count >= AV62GXV1 ) )
         {
            AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem = ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1));
         }
         /* Date_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         if ( (DateTime.MinValue==AV48Date) && (DateTime.MinValue==AV49Date_To) )
         {
            AV48Date = Gx_date;
            AssignAttri("", false, "AV48Date", context.localUtil.Format(AV48Date, "99/99/99"));
            AV49Date_To = Gx_date;
            AssignAttri("", false, "AV49Date_To", context.localUtil.Format(AV49Date_To, "99/99/99"));
         }
         AssignAttri("", false, "AV48Date", context.localUtil.Format(AV48Date, "99/99/99"));
         AssignAttri("", false, "AV49Date_To", context.localUtil.Format(AV49Date_To, "99/99/99"));
         AV54DateRange = 0;
         GXt_SdtSDTLeaveReport1 = AV16SDTLeaveReport;
         new dpleavereport(context ).execute(  AV48Date,  AV49Date_To,  AV39EmployeeId,  AV41LocationId,  AV38ProjectId,  AV40PeriodicCategory, out  GXt_SdtSDTLeaveReport1) ;
         AV16SDTLeaveReport = GXt_SdtSDTLeaveReport1;
         gx_BV77 = true;
         AssignAttri("", false, "AV48Date", context.localUtil.Format(AV48Date, "99/99/99"));
         AssignAttri("", false, "AV49Date_To", context.localUtil.Format(AV49Date_To, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
         /*  Sending Event outputs  */
         if ( gx_BV77 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16SDTLeaveReport", AV16SDTLeaveReport);
            nGXsfl_77_bak_idx = nGXsfl_77_idx;
            gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
            nGXsfl_77_idx = nGXsfl_77_bak_idx;
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_772( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
      }

      protected void E232Z2( )
      {
         AV62GXV1 = (int)(nGXsfl_77_idx+GRID_nFirstRecordOnPage);
         if ( ( AV62GXV1 > 0 ) && ( AV16SDTLeaveReport.gxTpr_Periodcollection.Count >= AV62GXV1 ) )
         {
            AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem = ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1));
         }
         /* Detailwebcomponent_Click Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Grid_dwc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Grid_dwc_Component), StringUtil.Lower( "EmployeeHoursListDetail")) != 0 )
         {
            WebComp_Grid_dwc = getWebComponent(GetType(), "GeneXus.Programs", "employeehourslistdetail", new Object[] {context} );
            WebComp_Grid_dwc.ComponentInit();
            WebComp_Grid_dwc.Name = "EmployeeHoursListDetail";
            WebComp_Grid_dwc_Component = "EmployeeHoursListDetail";
         }
         if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
         {
            WebComp_Grid_dwc.setjustcreated();
            WebComp_Grid_dwc.componentprepare(new Object[] {(string)"W0092",(string)"",((SdtSDTLeaveReport_PeriodCollectionItem)(AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem)).gxTpr_Fromdate,((SdtSDTLeaveReport_PeriodCollectionItem)(AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem)).gxTpr_Todate,(long)AV39EmployeeId,(long)AV60CompanyLocationId,((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible,((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible});
            WebComp_Grid_dwc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Grid_dwc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0092"+"");
            WebComp_Grid_dwc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E142Z2( )
      {
         AV62GXV1 = (int)(nGXsfl_77_idx+GRID_nFirstRecordOnPage);
         if ( ( AV62GXV1 > 0 ) && ( AV16SDTLeaveReport.gxTpr_Periodcollection.Count >= AV62GXV1 ) )
         {
            AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem = ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1));
         }
         /* Combo_projectid_Onoptionclicked Routine */
         returnInSub = false;
         AV38ProjectId.FromJSonString(Combo_projectid_Selectedvalue_get, null);
         GXt_SdtSDTLeaveReport1 = AV16SDTLeaveReport;
         new dpleavereport(context ).execute(  AV48Date,  AV49Date_To,  AV39EmployeeId,  AV41LocationId,  AV38ProjectId,  AV40PeriodicCategory, out  GXt_SdtSDTLeaveReport1) ;
         AV16SDTLeaveReport = GXt_SdtSDTLeaveReport1;
         gx_BV77 = true;
         AV38ProjectId.FromJSonString(Combo_projectid_Selectedvalue_get, null);
         gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ProjectId", AV38ProjectId);
         if ( gx_BV77 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16SDTLeaveReport", AV16SDTLeaveReport);
            nGXsfl_77_bak_idx = nGXsfl_77_idx;
            gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
            nGXsfl_77_idx = nGXsfl_77_bak_idx;
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_772( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
      }

      protected void E132Z2( )
      {
         AV62GXV1 = (int)(nGXsfl_77_idx+GRID_nFirstRecordOnPage);
         if ( ( AV62GXV1 > 0 ) && ( AV16SDTLeaveReport.gxTpr_Periodcollection.Count >= AV62GXV1 ) )
         {
            AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem = ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1));
         }
         /* Combo_employeeid_Onoptionclicked Routine */
         returnInSub = false;
         AV39EmployeeId = (long)(Math.Round(NumberUtil.Val( Combo_employeeid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV39EmployeeId", StringUtil.LTrimStr( (decimal)(AV39EmployeeId), 10, 0));
         GXt_SdtSDTLeaveReport1 = AV16SDTLeaveReport;
         new dpleavereport(context ).execute(  AV48Date,  AV49Date_To,  AV39EmployeeId,  AV41LocationId,  AV38ProjectId,  AV40PeriodicCategory, out  GXt_SdtSDTLeaveReport1) ;
         AV16SDTLeaveReport = GXt_SdtSDTLeaveReport1;
         gx_BV77 = true;
         AV39EmployeeId = (long)(Math.Round(NumberUtil.Val( Combo_employeeid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV39EmployeeId", StringUtil.LTrimStr( (decimal)(AV39EmployeeId), 10, 0));
         gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
         /*  Sending Event outputs  */
         if ( gx_BV77 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16SDTLeaveReport", AV16SDTLeaveReport);
            nGXsfl_77_bak_idx = nGXsfl_77_idx;
            gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
            nGXsfl_77_idx = nGXsfl_77_bak_idx;
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_772( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
      }

      protected void E122Z2( )
      {
         AV62GXV1 = (int)(nGXsfl_77_idx+GRID_nFirstRecordOnPage);
         if ( ( AV62GXV1 > 0 ) && ( AV16SDTLeaveReport.gxTpr_Periodcollection.Count >= AV62GXV1 ) )
         {
            AV16SDTLeaveReport.gxTpr_Periodcollection.CurrentItem = ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1));
         }
         /* Combo_periodiccategory_Onoptionclicked Routine */
         returnInSub = false;
         AV40PeriodicCategory = (short)(Math.Round(NumberUtil.Val( Combo_periodiccategory_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV40PeriodicCategory", StringUtil.LTrimStr( (decimal)(AV40PeriodicCategory), 4, 0));
         GXt_SdtSDTLeaveReport1 = AV16SDTLeaveReport;
         new dpleavereport(context ).execute(  AV48Date,  AV49Date_To,  AV39EmployeeId,  AV41LocationId,  AV38ProjectId,  AV40PeriodicCategory, out  GXt_SdtSDTLeaveReport1) ;
         AV16SDTLeaveReport = GXt_SdtSDTLeaveReport1;
         gx_BV77 = true;
         AV40PeriodicCategory = (short)(Math.Round(NumberUtil.Val( Combo_periodiccategory_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV40PeriodicCategory", StringUtil.LTrimStr( (decimal)(AV40PeriodicCategory), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
         /*  Sending Event outputs  */
         if ( gx_BV77 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16SDTLeaveReport", AV16SDTLeaveReport);
            nGXsfl_77_bak_idx = nGXsfl_77_idx;
            gxgrGrid_refresh( subGrid_Rows, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV13GridState, AV72Pgmname, AV48Date, AV49Date_To, AV40PeriodicCategory, AV39EmployeeId, AV38ProjectId, AV60CompanyLocationId, Gx_date, AV41LocationId) ;
            nGXsfl_77_idx = nGXsfl_77_bak_idx;
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_772( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
      }

      protected void S152( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV21ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "SDTLeaveReport_PeriodCollection__Label",  "",  "Period",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "SDTLeaveReport_PeriodCollection__FromDate",  "",  "DateFrom",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "SDTLeaveReport_PeriodCollection__ToDate",  "",  "Date To",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "SDTLeaveReport_PeriodCollection__FormattedTotalWork",  "",  "Work Hours",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "SDTLeaveReport_PeriodCollection__FormattedTotalLeave",  "",  "Leave Hours",  true,  "") ;
         GXt_char4 = AV20UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WPLeaveReportColumnsSelector", out  GXt_char4) ;
         AV20UserCustomValue = GXt_char4;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV20UserCustomValue)) ) )
         {
            AV22ColumnsSelectorAux.FromXml(AV20UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV22ColumnsSelectorAux, ref  AV21ColumnsSelector) ;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV24ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WPLeaveReportFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV48Date = DateTime.MinValue;
         AssignAttri("", false, "AV48Date", context.localUtil.Format(AV48Date, "99/99/99"));
         AV49Date_To = DateTime.MinValue;
         AssignAttri("", false, "AV49Date_To", context.localUtil.Format(AV49Date_To, "99/99/99"));
         AV40PeriodicCategory = 0;
         AssignAttri("", false, "AV40PeriodicCategory", StringUtil.LTrimStr( (decimal)(AV40PeriodicCategory), 4, 0));
         Combo_periodiccategory_Selectedvalue_set = "";
         ucCombo_periodiccategory.SendProperty(context, "", false, Combo_periodiccategory_Internalname, "SelectedValue_set", Combo_periodiccategory_Selectedvalue_set);
         AV39EmployeeId = 0;
         AssignAttri("", false, "AV39EmployeeId", StringUtil.LTrimStr( (decimal)(AV39EmployeeId), 10, 0));
         Combo_employeeid_Selectedvalue_set = "";
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
         Combo_employeeid_Selectedtext_set = "";
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedText_set", Combo_employeeid_Selectedtext_set);
         AV38ProjectId = (GxSimpleCollection<long>)(new GxSimpleCollection<long>());
         Combo_projectid_Selectedvalue_set = "";
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedValue_set", Combo_projectid_Selectedvalue_set);
         Combo_projectid_Selectedtext_set = "";
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedText_set", Combo_projectid_Selectedtext_set);
         AV60CompanyLocationId = 0;
         AssignAttri("", false, "AV60CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV60CompanyLocationId), 10, 0));
         Combo_companylocationid_Selectedvalue_set = "";
         ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "SelectedValue_set", Combo_companylocationid_Selectedvalue_set);
         Combo_companylocationid_Selectedtext_set = "";
         ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "SelectedText_set", Combo_companylocationid_Selectedtext_set);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get(AV72Pgmname+"GridState"), "") == 0 )
         {
            AV13GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV72Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV13GridState.FromXml(AV23Session.Get(AV72Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV13GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV13GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV73GXV10 = 1;
         while ( AV73GXV10 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV73GXV10));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "DATE") == 0 )
            {
               AV48Date = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV48Date", context.localUtil.Format(AV48Date, "99/99/99"));
               AV49Date_To = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV49Date_To", context.localUtil.Format(AV49Date_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "PERIODICCATEGORY") == 0 )
            {
               AV40PeriodicCategory = (short)(Math.Round(NumberUtil.Val( AV14GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV40PeriodicCategory", StringUtil.LTrimStr( (decimal)(AV40PeriodicCategory), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "EMPLOYEEID") == 0 )
            {
               AV39EmployeeId = (long)(Math.Round(NumberUtil.Val( AV14GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39EmployeeId", StringUtil.LTrimStr( (decimal)(AV39EmployeeId), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "PROJECTID") == 0 )
            {
               AV38ProjectId.FromJSonString(AV14GridStateFilterValue.gxTpr_Value, null);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "COMPANYLOCATIONID") == 0 )
            {
               AV60CompanyLocationId = (long)(Math.Round(NumberUtil.Val( AV14GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV60CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV60CompanyLocationId), 10, 0));
            }
            AV73GXV10 = (int)(AV73GXV10+1);
         }
         /* Execute user subroutine: 'LOADCOMBOPERIODICCATEGORY' */
         S222 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S192 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S202 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCOMPANYLOCATIONID' */
         S212 ();
         if (returnInSub) return;
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV13GridState.FromXml(AV23Session.Get(AV72Pgmname+"GridState"), null, "", "");
         AV13GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "DATE",  "Date Range",  !((DateTime.MinValue==AV48Date)&&(DateTime.MinValue==AV49Date_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV48Date, 2, "/")),  ((DateTime.MinValue==AV48Date) ? "" : StringUtil.Trim( context.localUtil.Format( AV48Date, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV49Date_To, 2, "/")),  ((DateTime.MinValue==AV49Date_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV49Date_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "PERIODICCATEGORY",  "View",  !(0==AV40PeriodicCategory),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV40PeriodicCategory), 4, 0)),  StringUtil.Trim( gxdomainperiodiccategory.getDescription(context,AV40PeriodicCategory)),  false,  "",  "") ;
         GXt_char4 = AV47AuxText;
         new wpleavereportloaddvcombo(context ).execute(  "EmployeeId",  "GET_DSC",  StringUtil.Str( (decimal)(AV39EmployeeId), 10, 0), out  GXt_char4) ;
         AV47AuxText = GXt_char4;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "EMPLOYEEID",  "Employee",  !(0==AV39EmployeeId),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV39EmployeeId), 10, 0)),  AV47AuxText,  false,  "",  "") ;
         GXt_char4 = AV47AuxText;
         new wpleavereportloaddvcombo(context ).execute(  "ProjectId",  "GET_DSC_TEXT",  AV38ProjectId.ToJSonString(false), out  GXt_char4) ;
         AV47AuxText = GXt_char4;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "PROJECTID",  "Project",  !(AV38ProjectId.Count==0),  0,  AV38ProjectId.ToJSonString(false),  ((AV38ProjectId.Count==1) ? AV47AuxText : "multiple values"),  false,  "",  "") ;
         GXt_char4 = AV47AuxText;
         new wpleavereportloaddvcombo(context ).execute(  "CompanyLocationId",  "GET_DSC",  StringUtil.Str( (decimal)(AV60CompanyLocationId), 10, 0), out  GXt_char4) ;
         AV47AuxText = GXt_char4;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "COMPANYLOCATIONID",  "Location",  !(0==AV60CompanyLocationId),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV60CompanyLocationId), 10, 0)),  AV47AuxText,  false,  "",  "") ;
         AV13GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV13GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV72Pgmname+"GridState",  AV13GridState.ToXml(false, true, "", "")) ;
      }

      protected void S182( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         new wpleavereportexport(context ).execute(  AV16SDTLeaveReport, out  AV17ExcelFilename, out  AV18ErrorMessage) ;
         if ( StringUtil.StrCmp(AV17ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV17ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV18ErrorMessage);
         }
      }

      protected void S212( )
      {
         /* 'LOADCOMBOCOMPANYLOCATIONID' Routine */
         returnInSub = false;
         GXt_char4 = "";
         new wpleavereportloaddvcombo(context ).execute(  "CompanyLocationId",  "GET_DSC",  StringUtil.Str( (decimal)(AV60CompanyLocationId), 10, 0), out  GXt_char4) ;
         Combo_companylocationid_Selectedtext_set = GXt_char4;
         ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "SelectedText_set", Combo_companylocationid_Selectedtext_set);
         Combo_companylocationid_Selectedvalue_set = ((0==AV60CompanyLocationId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV60CompanyLocationId), 10, 0)));
         ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "SelectedValue_set", Combo_companylocationid_Selectedvalue_set);
      }

      protected void S202( )
      {
         /* 'LOADCOMBOPROJECTID' Routine */
         returnInSub = false;
         GXt_char4 = "";
         new wpleavereportloaddvcombo(context ).execute(  "ProjectId",  "GET_DSC",  AV38ProjectId.ToJSonString(false), out  GXt_char4) ;
         Combo_projectid_Selectedtext_set = GXt_char4;
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedText_set", Combo_projectid_Selectedtext_set);
         Combo_projectid_Selectedvalue_set = AV38ProjectId.ToJSonString(false);
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedValue_set", Combo_projectid_Selectedvalue_set);
      }

      protected void S192( )
      {
         /* 'LOADCOMBOEMPLOYEEID' Routine */
         returnInSub = false;
         GXt_char4 = "";
         new wpleavereportloaddvcombo(context ).execute(  "EmployeeId",  "GET_DSC",  StringUtil.Str( (decimal)(AV39EmployeeId), 10, 0), out  GXt_char4) ;
         Combo_employeeid_Selectedtext_set = GXt_char4;
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedText_set", Combo_employeeid_Selectedtext_set);
         Combo_employeeid_Selectedvalue_set = ((0==AV39EmployeeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV39EmployeeId), 10, 0)));
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
      }

      protected void S222( )
      {
         /* 'LOADCOMBOPERIODICCATEGORY' Routine */
         returnInSub = false;
         AV42PeriodicCategory_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Combo_periodiccategory_Selectedvalue_set = ((0==AV40PeriodicCategory) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV40PeriodicCategory), 4, 0)));
         ucCombo_periodiccategory.SendProperty(context, "", false, Combo_periodiccategory_Internalname, "SelectedValue_set", Combo_periodiccategory_Selectedvalue_set);
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
         PA2Z2( ) ;
         WS2Z2( ) ;
         WE2Z2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Grid_dwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
            {
               WebComp_Grid_dwc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025626755892", true, true);
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
         context.AddJavascriptSource("wpleavereport.js", "?2025626755894", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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

      protected void SubsflControlProps_772( )
      {
         edtavSdtleavereport_periodcollection__label_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__LABEL_"+sGXsfl_77_idx;
         edtavSdtleavereport_periodcollection__fromdate_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__FROMDATE_"+sGXsfl_77_idx;
         edtavSdtleavereport_periodcollection__todate_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__TODATE_"+sGXsfl_77_idx;
         edtavSdtleavereport_periodcollection__mean_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__MEAN_"+sGXsfl_77_idx;
         edtavSdtleavereport_periodcollection__number_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__NUMBER_"+sGXsfl_77_idx;
         edtavSdtleavereport_periodcollection__totalleave_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__TOTALLEAVE_"+sGXsfl_77_idx;
         edtavSdtleavereport_periodcollection__formattedtotalwork_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALWORK_"+sGXsfl_77_idx;
         edtavSdtleavereport_periodcollection__formattedtotalleave_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALLEAVE_"+sGXsfl_77_idx;
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT_"+sGXsfl_77_idx;
      }

      protected void SubsflControlProps_fel_772( )
      {
         edtavSdtleavereport_periodcollection__label_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__LABEL_"+sGXsfl_77_fel_idx;
         edtavSdtleavereport_periodcollection__fromdate_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__FROMDATE_"+sGXsfl_77_fel_idx;
         edtavSdtleavereport_periodcollection__todate_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__TODATE_"+sGXsfl_77_fel_idx;
         edtavSdtleavereport_periodcollection__mean_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__MEAN_"+sGXsfl_77_fel_idx;
         edtavSdtleavereport_periodcollection__number_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__NUMBER_"+sGXsfl_77_fel_idx;
         edtavSdtleavereport_periodcollection__totalleave_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__TOTALLEAVE_"+sGXsfl_77_fel_idx;
         edtavSdtleavereport_periodcollection__formattedtotalwork_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALWORK_"+sGXsfl_77_fel_idx;
         edtavSdtleavereport_periodcollection__formattedtotalleave_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALLEAVE_"+sGXsfl_77_fel_idx;
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT_"+sGXsfl_77_fel_idx;
      }

      protected void sendrow_772( )
      {
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_772( ) ;
         WB2Z0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_77_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_77_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_77_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdtleavereport_periodcollection__label_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_77_idx + "',77)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtleavereport_periodcollection__label_Internalname,((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Label,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtleavereport_periodcollection__label_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdtleavereport_periodcollection__label_Visible,(int)edtavSdtleavereport_periodcollection__label_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavSdtleavereport_periodcollection__fromdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_77_idx + "',77)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtleavereport_periodcollection__fromdate_Internalname,context.localUtil.Format(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Fromdate, "99/99/99"),context.localUtil.Format( ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Fromdate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtleavereport_periodcollection__fromdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdtleavereport_periodcollection__fromdate_Visible,(int)edtavSdtleavereport_periodcollection__fromdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavSdtleavereport_periodcollection__todate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_77_idx + "',77)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtleavereport_periodcollection__todate_Internalname,context.localUtil.Format(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Todate, "99/99/99"),context.localUtil.Format( ((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Todate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,80);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtleavereport_periodcollection__todate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdtleavereport_periodcollection__todate_Visible,(int)edtavSdtleavereport_periodcollection__todate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtleavereport_periodcollection__mean_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Mean), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtleavereport_periodcollection__mean_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Mean), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Mean), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtleavereport_periodcollection__mean_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtleavereport_periodcollection__mean_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtleavereport_periodcollection__number_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Number), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtleavereport_periodcollection__number_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Number), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Number), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtleavereport_periodcollection__number_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtleavereport_periodcollection__number_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtleavereport_periodcollection__totalleave_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Totalleave), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtleavereport_periodcollection__totalleave_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Totalleave), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Totalleave), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtleavereport_periodcollection__totalleave_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtleavereport_periodcollection__totalleave_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdtleavereport_periodcollection__formattedtotalwork_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_77_idx + "',77)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtleavereport_periodcollection__formattedtotalwork_Internalname,((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Formattedtotalwork,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtleavereport_periodcollection__formattedtotalwork_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdtleavereport_periodcollection__formattedtotalwork_Visible,(int)edtavSdtleavereport_periodcollection__formattedtotalwork_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavSdtleavereport_periodcollection__formattedtotalleave_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_77_idx + "',77)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtleavereport_periodcollection__formattedtotalleave_Internalname,((SdtSDTLeaveReport_PeriodCollectionItem)AV16SDTLeaveReport.gxTpr_Periodcollection.Item(AV62GXV1)).gxTpr_Formattedtotalleave,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtleavereport_periodcollection__formattedtotalleave_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavSdtleavereport_periodcollection__formattedtotalleave_Visible,(int)edtavSdtleavereport_periodcollection__formattedtotalleave_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_77_idx + "',77)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDetailwebcomponent_Internalname,StringUtil.RTrim( AV52DetailWebComponent),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"","'"+""+"'"+",false,"+"'"+"EVDETAILWEBCOMPONENT.CLICK."+sGXsfl_77_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDetailwebcomponent_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWActionColumn WCD_ActionColumn",(string)"",(short)-1,(int)edtavDetailwebcomponent_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2Z2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_77_idx = ((subGrid_Islastpage==1)&&(nGXsfl_77_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_77_idx+1);
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_772( ) ;
         }
         /* End function sendrow_772 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl77( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"77\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdtleavereport_periodcollection__label_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Period") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdtleavereport_periodcollection__fromdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "DateFrom") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdtleavereport_periodcollection__todate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Date To") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdtleavereport_periodcollection__formattedtotalwork_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Work Hours") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavSdtleavereport_periodcollection__formattedtotalleave_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Leave Hours") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__label_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__label_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__fromdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__fromdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__todate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__todate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__mean_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__number_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__totalleave_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__formattedtotalwork_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__formattedtotalwork_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__formattedtotalleave_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtleavereport_periodcollection__formattedtotalleave_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV52DetailWebComponent)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetailwebcomponent_Enabled), 5, 0, ".", "")));
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
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divFiltertable_Internalname = "FILTERTABLE";
         edtavDate_rangetext_Internalname = "vDATE_RANGETEXT";
         lblFiltertextperiodiccategory_Internalname = "FILTERTEXTPERIODICCATEGORY";
         Combo_periodiccategory_Internalname = "COMBO_PERIODICCATEGORY";
         divTablesplittedfiltertextperiodiccategory_Internalname = "TABLESPLITTEDFILTERTEXTPERIODICCATEGORY";
         lblFiltertextemployeeid_Internalname = "FILTERTEXTEMPLOYEEID";
         Combo_employeeid_Internalname = "COMBO_EMPLOYEEID";
         divTablesplittedfiltertextemployeeid_Internalname = "TABLESPLITTEDFILTERTEXTEMPLOYEEID";
         lblFiltertextprojectid_Internalname = "FILTERTEXTPROJECTID";
         Combo_projectid_Internalname = "COMBO_PROJECTID";
         divTablesplittedfiltertextprojectid_Internalname = "TABLESPLITTEDFILTERTEXTPROJECTID";
         lblFiltertextcompanylocationid_Internalname = "FILTERTEXTCOMPANYLOCATIONID";
         Combo_companylocationid_Internalname = "COMBO_COMPANYLOCATIONID";
         divTablesplittedfiltertextcompanylocationid_Internalname = "TABLESPLITTEDFILTERTEXTCOMPANYLOCATIONID";
         divFiltertable2_Internalname = "FILTERTABLE2";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Dvpanel_unnamedtable1_Internalname = "DVPANEL_UNNAMEDTABLE1";
         edtavSdtleavereport_periodcollection__label_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__LABEL";
         edtavSdtleavereport_periodcollection__fromdate_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__FROMDATE";
         edtavSdtleavereport_periodcollection__todate_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__TODATE";
         edtavSdtleavereport_periodcollection__mean_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__MEAN";
         edtavSdtleavereport_periodcollection__number_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__NUMBER";
         edtavSdtleavereport_periodcollection__totalleave_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__TOTALLEAVE";
         edtavSdtleavereport_periodcollection__formattedtotalwork_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALWORK";
         edtavSdtleavereport_periodcollection__formattedtotalleave_Internalname = "SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALLEAVE";
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divCell_grid_dwc_Internalname = "CELL_GRID_DWC";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Date_rangepicker_Internalname = "DATE_RANGEPICKER";
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
         edtavDetailwebcomponent_Jsonclick = "";
         edtavDetailwebcomponent_Enabled = 1;
         edtavSdtleavereport_periodcollection__formattedtotalleave_Jsonclick = "";
         edtavSdtleavereport_periodcollection__formattedtotalleave_Enabled = 0;
         edtavSdtleavereport_periodcollection__formattedtotalleave_Visible = -1;
         edtavSdtleavereport_periodcollection__formattedtotalwork_Jsonclick = "";
         edtavSdtleavereport_periodcollection__formattedtotalwork_Enabled = 0;
         edtavSdtleavereport_periodcollection__formattedtotalwork_Visible = -1;
         edtavSdtleavereport_periodcollection__totalleave_Jsonclick = "";
         edtavSdtleavereport_periodcollection__totalleave_Enabled = 0;
         edtavSdtleavereport_periodcollection__number_Jsonclick = "";
         edtavSdtleavereport_periodcollection__number_Enabled = 0;
         edtavSdtleavereport_periodcollection__mean_Jsonclick = "";
         edtavSdtleavereport_periodcollection__mean_Enabled = 0;
         edtavSdtleavereport_periodcollection__todate_Jsonclick = "";
         edtavSdtleavereport_periodcollection__todate_Enabled = 0;
         edtavSdtleavereport_periodcollection__todate_Visible = -1;
         edtavSdtleavereport_periodcollection__fromdate_Jsonclick = "";
         edtavSdtleavereport_periodcollection__fromdate_Enabled = 0;
         edtavSdtleavereport_periodcollection__fromdate_Visible = -1;
         edtavSdtleavereport_periodcollection__label_Jsonclick = "";
         edtavSdtleavereport_periodcollection__label_Enabled = 0;
         edtavSdtleavereport_periodcollection__label_Visible = -1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSdtleavereport_periodcollection__formattedtotalleave_Visible = -1;
         edtavSdtleavereport_periodcollection__formattedtotalwork_Visible = -1;
         edtavSdtleavereport_periodcollection__todate_Visible = -1;
         edtavSdtleavereport_periodcollection__fromdate_Visible = -1;
         edtavSdtleavereport_periodcollection__label_Visible = -1;
         subGrid_Sortable = 0;
         edtavSdtleavereport_periodcollection__formattedtotalleave_Enabled = -1;
         edtavSdtleavereport_periodcollection__formattedtotalwork_Enabled = -1;
         edtavSdtleavereport_periodcollection__totalleave_Enabled = -1;
         edtavSdtleavereport_periodcollection__number_Enabled = -1;
         edtavSdtleavereport_periodcollection__mean_Enabled = -1;
         edtavSdtleavereport_periodcollection__todate_Enabled = -1;
         edtavSdtleavereport_periodcollection__fromdate_Enabled = -1;
         edtavSdtleavereport_periodcollection__label_Enabled = -1;
         divCell_grid_dwc_Class = "col-xs-12";
         divUnnamedtable1_Height = 0;
         Combo_companylocationid_Caption = "";
         Combo_projectid_Caption = "";
         Combo_employeeid_Caption = "";
         Combo_periodiccategory_Caption = "";
         edtavDate_rangetext_Jsonclick = "";
         edtavDate_rangetext_Enabled = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Columnssortvalues = "||||";
         Ddo_grid_Columnids = "0:SDTLeaveReport_PeriodCollection__Label|1:SDTLeaveReport_PeriodCollection__FromDate|2:SDTLeaveReport_PeriodCollection__ToDate|6:SDTLeaveReport_PeriodCollection__FormattedTotalWork|7:SDTLeaveReport_PeriodCollection__FormattedTotalLeave";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
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
         Dvpanel_unnamedtable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Iconposition = "Right";
         Dvpanel_unnamedtable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Title = "";
         Dvpanel_unnamedtable1_Cls = "ActionGroup";
         Dvpanel_unnamedtable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Width = "100%";
         Combo_companylocationid_Emptyitem = Convert.ToBoolean( 0);
         Combo_companylocationid_Datalistprocparametersprefix = " \"ComboName\": \"CompanyLocationId\"";
         Combo_companylocationid_Datalistproc = "WPLeaveReportLoadDVCombo";
         Combo_companylocationid_Cls = "ExtendedCombo Attribute";
         Combo_projectid_Multiplevaluestype = "Tags";
         Combo_projectid_Emptyitem = Convert.ToBoolean( 0);
         Combo_projectid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_projectid_Datalistprocparametersprefix = " \"ComboName\": \"ProjectId\"";
         Combo_projectid_Datalistproc = "WPLeaveReportLoadDVCombo";
         Combo_projectid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_projectid_Cls = "ExtendedCombo Attribute";
         Combo_employeeid_Emptyitemtext = "All";
         Combo_employeeid_Datalistprocparametersprefix = " \"ComboName\": \"EmployeeId\"";
         Combo_employeeid_Datalistproc = "WPLeaveReportLoadDVCombo";
         Combo_employeeid_Cls = "ExtendedCombo Attribute";
         Combo_periodiccategory_Emptyitem = Convert.ToBoolean( 0);
         Combo_periodiccategory_Datalistfixedvalues = "Weekly:1,Monthly:2,Yearly:3";
         Combo_periodiccategory_Datalisttype = "FixedValues";
         Combo_periodiccategory_Cls = "ExtendedCombo Attribute";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV41LocationId","fld":"vLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__LABEL","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FROMDATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__TODATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALWORK","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALLEAVE","prop":"Visible"},{"av":"Gridpaginationbar_Emptygridcaption","ctrl":"GRIDPAGINATIONBAR","prop":"EmptyGridCaption"},{"av":"AV29GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV30GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV31GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV13GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E152Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV41LocationId","fld":"vLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E162Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV41LocationId","fld":"vLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E222Z2","iparms":[]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV52DetailWebComponent","fld":"vDETAILWEBCOMPONENT"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E192Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV41LocationId","fld":"vLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__LABEL","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FROMDATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__TODATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALWORK","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALLEAVE","prop":"Visible"},{"av":"Gridpaginationbar_Emptygridcaption","ctrl":"GRIDPAGINATIONBAR","prop":"EmptyGridCaption"},{"av":"AV29GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV30GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV31GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV13GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E112Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV41LocationId","fld":"vLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"Combo_periodiccategory_Selectedvalue_set","ctrl":"COMBO_PERIODICCATEGORY","prop":"SelectedValue_set"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"Combo_employeeid_Selectedtext_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedText_set"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"},{"av":"Combo_projectid_Selectedtext_set","ctrl":"COMBO_PROJECTID","prop":"SelectedText_set"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Combo_companylocationid_Selectedvalue_set","ctrl":"COMBO_COMPANYLOCATIONID","prop":"SelectedValue_set"},{"av":"Combo_companylocationid_Selectedtext_set","ctrl":"COMBO_COMPANYLOCATIONID","prop":"SelectedText_set"},{"av":"AV42PeriodicCategory_Data","fld":"vPERIODICCATEGORY_DATA"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__LABEL","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FROMDATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__TODATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALWORK","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALLEAVE","prop":"Visible"},{"av":"Gridpaginationbar_Emptygridcaption","ctrl":"GRIDPAGINATIONBAR","prop":"EmptyGridCaption"},{"av":"AV29GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV30GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV31GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","""{"handler":"E172Z2","iparms":[{"av":"Ddo_agexport_Activeeventkey","ctrl":"DDO_AGEXPORT","prop":"ActiveEventKey"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",""","oparms":[{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV41LocationId","fld":"vLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV42PeriodicCategory_Data","fld":"vPERIODICCATEGORY_DATA"},{"av":"Combo_periodiccategory_Selectedvalue_set","ctrl":"COMBO_PERIODICCATEGORY","prop":"SelectedValue_set"},{"av":"Combo_employeeid_Selectedtext_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedText_set"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"Combo_projectid_Selectedtext_set","ctrl":"COMBO_PROJECTID","prop":"SelectedText_set"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"},{"av":"Combo_companylocationid_Selectedtext_set","ctrl":"COMBO_COMPANYLOCATIONID","prop":"SelectedText_set"},{"av":"Combo_companylocationid_Selectedvalue_set","ctrl":"COMBO_COMPANYLOCATIONID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("DATE_RANGEPICKER.DATERANGECHANGED","""{"handler":"E182Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV41LocationId","fld":"vLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("DATE_RANGEPICKER.DATERANGECHANGED",""","oparms":[{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__LABEL","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FROMDATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__TODATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALWORK","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALLEAVE","prop":"Visible"},{"av":"Gridpaginationbar_Emptygridcaption","ctrl":"GRIDPAGINATIONBAR","prop":"EmptyGridCaption"},{"av":"AV29GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV30GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV31GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV13GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VDETAILWEBCOMPONENT.CLICK","""{"handler":"E232Z2","iparms":[{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"}]""");
         setEventMetadata("VDETAILWEBCOMPONENT.CLICK",""","oparms":[{"ctrl":"GRID_DWC"}]}""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED","""{"handler":"E142Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV41LocationId","fld":"vLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Combo_projectid_Selectedvalue_get","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED",""","oparms":[{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__LABEL","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FROMDATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__TODATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALWORK","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALLEAVE","prop":"Visible"},{"av":"Gridpaginationbar_Emptygridcaption","ctrl":"GRIDPAGINATIONBAR","prop":"EmptyGridCaption"},{"av":"AV29GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV30GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV31GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV13GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED","""{"handler":"E132Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV41LocationId","fld":"vLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Combo_employeeid_Selectedvalue_get","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__LABEL","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FROMDATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__TODATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALWORK","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALLEAVE","prop":"Visible"},{"av":"Gridpaginationbar_Emptygridcaption","ctrl":"GRIDPAGINATIONBAR","prop":"EmptyGridCaption"},{"av":"AV29GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV30GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV31GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV13GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("COMBO_PERIODICCATEGORY.ONOPTIONCLICKED","""{"handler":"E122Z2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV72Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV48Date","fld":"vDATE"},{"av":"AV49Date_To","fld":"vDATE_TO"},{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV38ProjectId","fld":"vPROJECTID"},{"av":"AV60CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV41LocationId","fld":"vLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Combo_periodiccategory_Selectedvalue_get","ctrl":"COMBO_PERIODICCATEGORY","prop":"SelectedValue_get"}]""");
         setEventMetadata("COMBO_PERIODICCATEGORY.ONOPTIONCLICKED",""","oparms":[{"av":"AV40PeriodicCategory","fld":"vPERIODICCATEGORY","pic":"ZZZ9"},{"av":"AV16SDTLeaveReport","fld":"vSDTLEAVEREPORT"},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRID","prop":"GridRC","grid":77},{"av":"AV26ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV21ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__LABEL","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FROMDATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__TODATE","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALWORK","prop":"Visible"},{"ctrl":"SDTLEAVEREPORT_PERIODCOLLECTION__FORMATTEDTOTALLEAVE","prop":"Visible"},{"av":"Gridpaginationbar_Emptygridcaption","ctrl":"GRIDPAGINATIONBAR","prop":"EmptyGridCaption"},{"av":"AV29GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV30GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV31GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV24ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV13GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Detailwebcomponent","iparms":[]}""");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         Combo_companylocationid_Selectedvalue_get = "";
         Combo_projectid_Selectedvalue_get = "";
         Combo_employeeid_Selectedvalue_get = "";
         Combo_periodiccategory_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV21ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV13GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV72Pgmname = "";
         AV48Date = DateTime.MinValue;
         AV49Date_To = DateTime.MinValue;
         AV38ProjectId = new GxSimpleCollection<long>();
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV16SDTLeaveReport = new SdtSDTLeaveReport(context);
         AV24ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV27DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV42PeriodicCategory_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV44EmployeeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV57ProjectId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV61CompanyLocationId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV31GridAppliedFilters = "";
         AV34AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV59Date_RangePickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         Combo_periodiccategory_Selectedvalue_set = "";
         Combo_employeeid_Selectedvalue_set = "";
         Combo_employeeid_Selectedtext_set = "";
         Combo_employeeid_Gamoauthtoken = "";
         Combo_projectid_Selectedvalue_set = "";
         Combo_projectid_Selectedtext_set = "";
         Combo_projectid_Gamoauthtoken = "";
         Combo_companylocationid_Selectedvalue_set = "";
         Combo_companylocationid_Selectedtext_set = "";
         Combo_companylocationid_Gamoauthtoken = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         AV51Date_RangeText = "";
         lblFiltertextperiodiccategory_Jsonclick = "";
         ucCombo_periodiccategory = new GXUserControl();
         lblFiltertextemployeeid_Jsonclick = "";
         ucCombo_employeeid = new GXUserControl();
         lblFiltertextprojectid_Jsonclick = "";
         ucCombo_projectid = new GXUserControl();
         lblFiltertextcompanylocationid_Jsonclick = "";
         ucCombo_companylocationid = new GXUserControl();
         ucDvpanel_unnamedtable1 = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         WebComp_Grid_dwc_Component = "";
         OldGrid_dwc = "";
         ucDdo_agexport = new GXUserControl();
         ucDate_rangepicker = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV52DetailWebComponent = "";
         AV45GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV46GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10HTTPRequest = new GxHttpRequest( context);
         AV35AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtWWPDateRangePickerOptions3 = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV19ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV25ManageFiltersXml = "";
         GXt_SdtSDTLeaveReport1 = new SdtSDTLeaveReport(context);
         AV20UserCustomValue = "";
         AV22ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV14GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV47AuxText = "";
         AV17ExcelFilename = "";
         AV18ErrorMessage = "";
         GXt_char4 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         WebComp_Grid_dwc = new GeneXus.Http.GXNullWebComponent();
         AV72Pgmname = "WPLeaveReport";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         AV72Pgmname = "WPLeaveReport";
         Gx_date = DateTimeUtil.Today( context);
         edtavSdtleavereport_periodcollection__label_Enabled = 0;
         edtavSdtleavereport_periodcollection__fromdate_Enabled = 0;
         edtavSdtleavereport_periodcollection__todate_Enabled = 0;
         edtavSdtleavereport_periodcollection__mean_Enabled = 0;
         edtavSdtleavereport_periodcollection__number_Enabled = 0;
         edtavSdtleavereport_periodcollection__totalleave_Enabled = 0;
         edtavSdtleavereport_periodcollection__formattedtotalwork_Enabled = 0;
         edtavSdtleavereport_periodcollection__formattedtotalleave_Enabled = 0;
         edtavDetailwebcomponent_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26ManageFiltersExecutionStep ;
      private short AV40PeriodicCategory ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_77 ;
      private int nGXsfl_77_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavDate_rangetext_Enabled ;
      private int divUnnamedtable1_Height ;
      private int AV62GXV1 ;
      private int subGrid_Islastpage ;
      private int edtavSdtleavereport_periodcollection__label_Enabled ;
      private int edtavSdtleavereport_periodcollection__fromdate_Enabled ;
      private int edtavSdtleavereport_periodcollection__todate_Enabled ;
      private int edtavSdtleavereport_periodcollection__mean_Enabled ;
      private int edtavSdtleavereport_periodcollection__number_Enabled ;
      private int edtavSdtleavereport_periodcollection__totalleave_Enabled ;
      private int edtavSdtleavereport_periodcollection__formattedtotalwork_Enabled ;
      private int edtavSdtleavereport_periodcollection__formattedtotalleave_Enabled ;
      private int edtavDetailwebcomponent_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_77_fel_idx=1 ;
      private int edtavSdtleavereport_periodcollection__label_Visible ;
      private int edtavSdtleavereport_periodcollection__fromdate_Visible ;
      private int edtavSdtleavereport_periodcollection__todate_Visible ;
      private int edtavSdtleavereport_periodcollection__formattedtotalwork_Visible ;
      private int edtavSdtleavereport_periodcollection__formattedtotalleave_Visible ;
      private int AV28PageToGo ;
      private int nGXsfl_77_bak_idx=1 ;
      private int AV73GXV10 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV39EmployeeId ;
      private long AV60CompanyLocationId ;
      private long AV41LocationId ;
      private long AV29GridCurrentPage ;
      private long AV30GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long AV54DateRange ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string Combo_companylocationid_Selectedvalue_get ;
      private string Combo_projectid_Selectedvalue_get ;
      private string Combo_employeeid_Selectedvalue_get ;
      private string Combo_periodiccategory_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_77_idx="0001" ;
      private string AV72Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Combo_periodiccategory_Cls ;
      private string Combo_periodiccategory_Selectedvalue_set ;
      private string Combo_periodiccategory_Datalisttype ;
      private string Combo_periodiccategory_Datalistfixedvalues ;
      private string Combo_employeeid_Cls ;
      private string Combo_employeeid_Selectedvalue_set ;
      private string Combo_employeeid_Selectedtext_set ;
      private string Combo_employeeid_Gamoauthtoken ;
      private string Combo_employeeid_Datalistproc ;
      private string Combo_employeeid_Datalistprocparametersprefix ;
      private string Combo_employeeid_Emptyitemtext ;
      private string Combo_projectid_Cls ;
      private string Combo_projectid_Selectedvalue_set ;
      private string Combo_projectid_Selectedtext_set ;
      private string Combo_projectid_Gamoauthtoken ;
      private string Combo_projectid_Datalistproc ;
      private string Combo_projectid_Datalistprocparametersprefix ;
      private string Combo_projectid_Multiplevaluestype ;
      private string Combo_companylocationid_Cls ;
      private string Combo_companylocationid_Selectedvalue_set ;
      private string Combo_companylocationid_Selectedtext_set ;
      private string Combo_companylocationid_Gamoauthtoken ;
      private string Combo_companylocationid_Datalistproc ;
      private string Combo_companylocationid_Datalistprocparametersprefix ;
      private string Dvpanel_unnamedtable1_Width ;
      private string Dvpanel_unnamedtable1_Cls ;
      private string Dvpanel_unnamedtable1_Title ;
      private string Dvpanel_unnamedtable1_Iconposition ;
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
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Fixable ;
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
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string divFiltertable_Internalname ;
      private string divFiltertable2_Internalname ;
      private string edtavDate_rangetext_Internalname ;
      private string edtavDate_rangetext_Jsonclick ;
      private string divTablesplittedfiltertextperiodiccategory_Internalname ;
      private string lblFiltertextperiodiccategory_Internalname ;
      private string lblFiltertextperiodiccategory_Jsonclick ;
      private string Combo_periodiccategory_Caption ;
      private string Combo_periodiccategory_Internalname ;
      private string divTablesplittedfiltertextemployeeid_Internalname ;
      private string lblFiltertextemployeeid_Internalname ;
      private string lblFiltertextemployeeid_Jsonclick ;
      private string Combo_employeeid_Caption ;
      private string Combo_employeeid_Internalname ;
      private string divTablesplittedfiltertextprojectid_Internalname ;
      private string lblFiltertextprojectid_Internalname ;
      private string lblFiltertextprojectid_Jsonclick ;
      private string Combo_projectid_Caption ;
      private string Combo_projectid_Internalname ;
      private string divTablesplittedfiltertextcompanylocationid_Internalname ;
      private string lblFiltertextcompanylocationid_Internalname ;
      private string lblFiltertextcompanylocationid_Jsonclick ;
      private string Combo_companylocationid_Caption ;
      private string Combo_companylocationid_Internalname ;
      private string Dvpanel_unnamedtable1_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divCell_grid_dwc_Internalname ;
      private string divCell_grid_dwc_Class ;
      private string WebComp_Grid_dwc_Component ;
      private string OldGrid_dwc ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Date_rangepicker_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV52DetailWebComponent ;
      private string edtavDetailwebcomponent_Internalname ;
      private string sGXsfl_77_fel_idx="0001" ;
      private string edtavSdtleavereport_periodcollection__label_Internalname ;
      private string edtavSdtleavereport_periodcollection__fromdate_Internalname ;
      private string edtavSdtleavereport_periodcollection__todate_Internalname ;
      private string edtavSdtleavereport_periodcollection__formattedtotalwork_Internalname ;
      private string edtavSdtleavereport_periodcollection__formattedtotalleave_Internalname ;
      private string GXt_char4 ;
      private string edtavSdtleavereport_periodcollection__mean_Internalname ;
      private string edtavSdtleavereport_periodcollection__number_Internalname ;
      private string edtavSdtleavereport_periodcollection__totalleave_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSdtleavereport_periodcollection__label_Jsonclick ;
      private string edtavSdtleavereport_periodcollection__fromdate_Jsonclick ;
      private string edtavSdtleavereport_periodcollection__todate_Jsonclick ;
      private string edtavSdtleavereport_periodcollection__mean_Jsonclick ;
      private string edtavSdtleavereport_periodcollection__number_Jsonclick ;
      private string edtavSdtleavereport_periodcollection__totalleave_Jsonclick ;
      private string edtavSdtleavereport_periodcollection__formattedtotalwork_Jsonclick ;
      private string edtavSdtleavereport_periodcollection__formattedtotalleave_Jsonclick ;
      private string edtavDetailwebcomponent_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV48Date ;
      private DateTime AV49Date_To ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Combo_periodiccategory_Emptyitem ;
      private bool Combo_projectid_Allowmultipleselection ;
      private bool Combo_projectid_Includeonlyselectedoption ;
      private bool Combo_projectid_Emptyitem ;
      private bool Combo_companylocationid_Emptyitem ;
      private bool Dvpanel_unnamedtable1_Autowidth ;
      private bool Dvpanel_unnamedtable1_Autoheight ;
      private bool Dvpanel_unnamedtable1_Collapsible ;
      private bool Dvpanel_unnamedtable1_Collapsed ;
      private bool Dvpanel_unnamedtable1_Showcollapseicon ;
      private bool Dvpanel_unnamedtable1_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_77_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV77 ;
      private bool gx_refresh_fired ;
      private bool AV53LoadGridData ;
      private bool bDynCreated_Grid_dwc ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV31GridAppliedFilters ;
      private string AV51Date_RangeText ;
      private string AV47AuxText ;
      private string AV17ExcelFilename ;
      private string AV18ErrorMessage ;
      private IGxSession AV23Session ;
      private GXWebComponent WebComp_Grid_dwc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucCombo_periodiccategory ;
      private GXUserControl ucCombo_employeeid ;
      private GXUserControl ucCombo_projectid ;
      private GXUserControl ucCombo_companylocationid ;
      private GXUserControl ucDvpanel_unnamedtable1 ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDate_rangepicker ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV10HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV13GridState ;
      private GxSimpleCollection<long> AV38ProjectId ;
      private SdtSDTLeaveReport AV16SDTLeaveReport ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV27DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV42PeriodicCategory_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV44EmployeeId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV57ProjectId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV61CompanyLocationId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV34AGExportData ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions AV59Date_RangePickerOptions ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV45GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV46GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item AV35AGExportDataItem ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions3 ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private SdtSDTLeaveReport GXt_SdtSDTLeaveReport1 ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV14GridStateFilterValue ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
