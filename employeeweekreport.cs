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
   public class employeeweekreport : GXDataArea
   {
      public employeeweekreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeeweekreport( IGxContext context )
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
         chkavSdtemployeeweekreports__mon_isholiday = new GXCheckbox();
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
         AV95Pgmname = GetPar( "Pgmname");
         AV20DateRange_To = context.localUtil.ParseDateParm( GetPar( "DateRange_To"));
         AV17DateRange = context.localUtil.ParseDateParm( GetPar( "DateRange"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV12CompanyLocationId);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV58EmployeeIds);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV59ProjectId);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41SDTEmployeeWeekReports);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
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
            return "employeeweekreport_Execute" ;
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
         PA4W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4W2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_SetWeekTableHeadersRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("employeeweekreport.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV95Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV95Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtemployeeweekreports", AV41SDTEmployeeWeekReports);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtemployeeweekreports", AV41SDTEmployeeWeekReports);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_40", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_40), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV21DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYLOCATIONID_DATA", AV13CompanyLocationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYLOCATIONID_DATA", AV13CompanyLocationId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID_DATA", AV60ProjectId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID_DATA", AV60ProjectId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV29GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vDATERANGE", context.localUtil.DToC( AV17DateRange, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATERANGE_TO", context.localUtil.DToC( AV20DateRange_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDATERANGE_RANGEPICKEROPTIONS", AV18DateRange_RangePickerOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDATERANGE_RANGEPICKEROPTIONS", AV18DateRange_RangePickerOptions);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV95Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV95Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYLOCATIONID", AV12CompanyLocationId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYLOCATIONID", AV12CompanyLocationId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEIDS", AV58EmployeeIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEIDS", AV58EmployeeIds);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID", AV59ProjectId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID", AV59ProjectId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTEMPLOYEEWEEKREPORTS", AV41SDTEmployeeWeekReports);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTEMPLOYEEWEEKREPORTS", AV41SDTEmployeeWeekReports);
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Cls", StringUtil.RTrim( Combo_companylocationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Enabled", StringUtil.BoolToStr( Combo_companylocationid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Allowmultipleselection", StringUtil.BoolToStr( Combo_companylocationid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_companylocationid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Emptyitem", StringUtil.BoolToStr( Combo_companylocationid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Multiplevaluestype", StringUtil.RTrim( Combo_companylocationid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Cls", StringUtil.RTrim( Combo_projectid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_set", StringUtil.RTrim( Combo_projectid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Allowmultipleselection", StringUtil.BoolToStr( Combo_projectid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_projectid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Emptyitem", StringUtil.BoolToStr( Combo_projectid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Multiplevaluestype", StringUtil.RTrim( Combo_projectid_Multiplevaluestype));
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
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Fromdate", StringUtil.RTrim( Usercontrol1_Fromdate));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Todate", StringUtil.RTrim( Usercontrol1_Todate));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_get));
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
            WE4W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4W2( ) ;
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
         return formatLink("employeeweekreport.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "EmployeeWeekReport" ;
      }

      public override string GetPgmdesc( )
      {
         return "" ;
      }

      protected void WB4W0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom15", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 700, "px", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:30fr 30fr 30fr;grid-template-rows:auto;grid-column-gap:10px;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MaxWidth-207 DscTop", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableaterange_rangetext_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockdaterange_rangetext_Internalname, "Week", "", "", lblTextblockdaterange_rangetext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_EmployeeWeekReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDaterange_rangetext_Internalname, "Date Range_Range Text", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'" + sGXsfl_40_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDaterange_rangetext_Internalname, AV19DateRange_RangeText, StringUtil.RTrim( context.localUtil.Format( AV19DateRange_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDaterange_rangetext_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavDaterange_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EmployeeWeekReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop ExtendedComboCell", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcompanylocationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_companylocationid_Internalname, "Location", "", "", lblTextblockcombo_companylocationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_EmployeeWeekReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_companylocationid.SetProperty("Caption", Combo_companylocationid_Caption);
            ucCombo_companylocationid.SetProperty("Cls", Combo_companylocationid_Cls);
            ucCombo_companylocationid.SetProperty("AllowMultipleSelection", Combo_companylocationid_Allowmultipleselection);
            ucCombo_companylocationid.SetProperty("IncludeOnlySelectedOption", Combo_companylocationid_Includeonlyselectedoption);
            ucCombo_companylocationid.SetProperty("EmptyItem", Combo_companylocationid_Emptyitem);
            ucCombo_companylocationid.SetProperty("MultipleValuesType", Combo_companylocationid_Multiplevaluestype);
            ucCombo_companylocationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV21DDO_TitleSettingsIcons);
            ucCombo_companylocationid.SetProperty("DropDownOptionsData", AV13CompanyLocationId_Data);
            ucCombo_companylocationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_companylocationid_Internalname, "COMBO_COMPANYLOCATIONIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop ExtendedComboCell", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedprojectid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_projectid_Internalname, "Project", "", "", lblTextblockcombo_projectid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_EmployeeWeekReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_projectid.SetProperty("Caption", Combo_projectid_Caption);
            ucCombo_projectid.SetProperty("Cls", Combo_projectid_Cls);
            ucCombo_projectid.SetProperty("AllowMultipleSelection", Combo_projectid_Allowmultipleselection);
            ucCombo_projectid.SetProperty("IncludeOnlySelectedOption", Combo_projectid_Includeonlyselectedoption);
            ucCombo_projectid.SetProperty("EmptyItem", Combo_projectid_Emptyitem);
            ucCombo_projectid.SetProperty("MultipleValuesType", Combo_projectid_Multiplevaluestype);
            ucCombo_projectid.SetProperty("DropDownOptionsTitleSettingsIcons", AV21DDO_TitleSettingsIcons);
            ucCombo_projectid.SetProperty("DropDownOptionsData", AV60ProjectId_Data);
            ucCombo_projectid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_projectid_Internalname, "COMBO_PROJECTIDContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell StickyHeaderTableContainer HasGridEmpowerer", "start", "top", "", "", "div");
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
               AV69GXV1 = nGXsfl_40_idx;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV30GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV31GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV29GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            ucUsercontrol1.Render(context, "uc_setweektableheaders", Usercontrol1_Internalname, "USERCONTROL1Container");
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
            ucDaterange_rangepicker.SetProperty("Start Date", AV17DateRange);
            ucDaterange_rangepicker.SetProperty("End Date", AV20DateRange_To);
            ucDaterange_rangepicker.SetProperty("PickerOptions", AV18DateRange_RangePickerOptions);
            ucDaterange_rangepicker.Render(context, "wwp.daterangepicker", Daterange_rangepicker_Internalname, "DATERANGE_RANGEPICKERContainer");
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
                  AV69GXV1 = nGXsfl_40_idx;
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

      protected void START4W2( )
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
         STRUP4W0( ) ;
      }

      protected void WS4W2( )
      {
         START4W2( ) ;
         EVT4W2( ) ;
      }

      protected void EVT4W2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_companylocationid.Onoptionclicked */
                              E114W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PROJECTID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_projectid.Onoptionclicked */
                              E124W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E134W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E144W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DATERANGE_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Daterange_rangepicker.Daterangechanged */
                              E154W2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'DOPREV'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'DONEXT'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_40_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
                              SubsflControlProps_402( ) ;
                              AV69GXV1 = (int)(nGXsfl_40_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV41SDTEmployeeWeekReports.Count >= AV69GXV1 ) && ( AV69GXV1 > 0 ) )
                              {
                                 AV41SDTEmployeeWeekReports.CurrentItem = ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1));
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
                                    E164W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E174W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E184W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOPREV'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoPrev' */
                                    E194W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoNext' */
                                    E204W2 ();
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

      protected void WE4W2( )
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

      protected void PA4W2( )
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
               GX_FocusControl = edtavDaterange_rangetext_Internalname;
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
                                       string AV95Pgmname ,
                                       DateTime AV20DateRange_To ,
                                       DateTime AV17DateRange ,
                                       GxSimpleCollection<long> AV12CompanyLocationId ,
                                       GxSimpleCollection<long> AV58EmployeeIds ,
                                       GxSimpleCollection<long> AV59ProjectId ,
                                       GXBaseCollection<SdtSDTEmployeeWeekReport> AV41SDTEmployeeWeekReports )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4W2( ) ;
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
         RF4W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV95Pgmname = "EmployeeWeekReport";
         Gx_date = DateTimeUtil.Today( context);
         edtavSdtemployeeweekreports__employeename_Enabled = 0;
         edtavSdtemployeeweekreports__mon_Enabled = 0;
         edtavSdtemployeeweekreports__tue_Enabled = 0;
         edtavSdtemployeeweekreports__wed_Enabled = 0;
         edtavSdtemployeeweekreports__thu_Enabled = 0;
         edtavSdtemployeeweekreports__fri_Enabled = 0;
         edtavSdtemployeeweekreports__sat_Enabled = 0;
         edtavSdtemployeeweekreports__sun_Enabled = 0;
         edtavSdtemployeeweekreports__leave_Enabled = 0;
         edtavSdtemployeeweekreports__expected_Enabled = 0;
         edtavSdtemployeeweekreports__total_Enabled = 0;
         edtavSdtemployeeweekreports__mon_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__tue_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__wed_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__thu_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__fri_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__sat_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__sun_formatted_Enabled = 0;
         chkavSdtemployeeweekreports__mon_isholiday.Enabled = 0;
         edtavSdtemployeeweekreports__leave_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__expected_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__total_formatted_Enabled = 0;
      }

      protected void RF4W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 40;
         /* Execute user event: Refresh */
         E174W2 ();
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
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_402( ) ;
            /* Execute user event: Grid.Load */
            E184W2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_40_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E184W2 ();
            }
            wbEnd = 40;
            WB4W0( ) ;
         }
         bGXsfl_40_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4W2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV95Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV95Pgmname, "")), context));
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
         return AV41SDTEmployeeWeekReports.Count ;
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
            gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV95Pgmname = "EmployeeWeekReport";
         Gx_date = DateTimeUtil.Today( context);
         edtavSdtemployeeweekreports__employeename_Enabled = 0;
         edtavSdtemployeeweekreports__mon_Enabled = 0;
         edtavSdtemployeeweekreports__tue_Enabled = 0;
         edtavSdtemployeeweekreports__wed_Enabled = 0;
         edtavSdtemployeeweekreports__thu_Enabled = 0;
         edtavSdtemployeeweekreports__fri_Enabled = 0;
         edtavSdtemployeeweekreports__sat_Enabled = 0;
         edtavSdtemployeeweekreports__sun_Enabled = 0;
         edtavSdtemployeeweekreports__leave_Enabled = 0;
         edtavSdtemployeeweekreports__expected_Enabled = 0;
         edtavSdtemployeeweekreports__total_Enabled = 0;
         edtavSdtemployeeweekreports__mon_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__tue_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__wed_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__thu_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__fri_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__sat_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__sun_formatted_Enabled = 0;
         chkavSdtemployeeweekreports__mon_isholiday.Enabled = 0;
         edtavSdtemployeeweekreports__leave_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__expected_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__total_formatted_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E164W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtemployeeweekreports"), AV41SDTEmployeeWeekReports);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV21DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOMPANYLOCATIONID_DATA"), AV13CompanyLocationId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vPROJECTID_DATA"), AV60ProjectId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vDATERANGE_RANGEPICKEROPTIONS"), AV18DateRange_RangePickerOptions);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTEMPLOYEEWEEKREPORTS"), AV41SDTEmployeeWeekReports);
            /* Read saved values. */
            nRC_GXsfl_40 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_40"), ".", ","), 18, MidpointRounding.ToEven));
            AV30GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV31GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV29GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV17DateRange = context.localUtil.CToD( cgiGet( "vDATERANGE"), 0);
            AV20DateRange_To = context.localUtil.CToD( cgiGet( "vDATERANGE_TO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Combo_companylocationid_Cls = cgiGet( "COMBO_COMPANYLOCATIONID_Cls");
            Combo_companylocationid_Selectedvalue_set = cgiGet( "COMBO_COMPANYLOCATIONID_Selectedvalue_set");
            Combo_companylocationid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Enabled"));
            Combo_companylocationid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Allowmultipleselection"));
            Combo_companylocationid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Includeonlyselectedoption"));
            Combo_companylocationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Emptyitem"));
            Combo_companylocationid_Multiplevaluestype = cgiGet( "COMBO_COMPANYLOCATIONID_Multiplevaluestype");
            Combo_projectid_Cls = cgiGet( "COMBO_PROJECTID_Cls");
            Combo_projectid_Selectedvalue_set = cgiGet( "COMBO_PROJECTID_Selectedvalue_set");
            Combo_projectid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Allowmultipleselection"));
            Combo_projectid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Includeonlyselectedoption"));
            Combo_projectid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Emptyitem"));
            Combo_projectid_Multiplevaluestype = cgiGet( "COMBO_PROJECTID_Multiplevaluestype");
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
            Usercontrol1_Fromdate = cgiGet( "USERCONTROL1_Fromdate");
            Usercontrol1_Todate = cgiGet( "USERCONTROL1_Todate");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Combo_projectid_Selectedvalue_get = cgiGet( "COMBO_PROJECTID_Selectedvalue_get");
            Combo_companylocationid_Selectedvalue_get = cgiGet( "COMBO_COMPANYLOCATIONID_Selectedvalue_get");
            nRC_GXsfl_40 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_40"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_40_fel_idx = 0;
            while ( nGXsfl_40_fel_idx < nRC_GXsfl_40 )
            {
               nGXsfl_40_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_40_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_fel_idx+1);
               sGXsfl_40_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_402( ) ;
               AV69GXV1 = (int)(nGXsfl_40_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV41SDTEmployeeWeekReports.Count >= AV69GXV1 ) && ( AV69GXV1 > 0 ) )
               {
                  AV41SDTEmployeeWeekReports.CurrentItem = ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1));
               }
            }
            if ( nGXsfl_40_fel_idx == 0 )
            {
               nGXsfl_40_idx = 1;
               sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
               SubsflControlProps_402( ) ;
            }
            nGXsfl_40_fel_idx = 1;
            /* Read variables values. */
            AV19DateRange_RangeText = cgiGet( edtavDaterange_rangetext_Internalname);
            AssignAttri("", false, "AV19DateRange_RangeText", AV19DateRange_RangeText);
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
         E164W2 ();
         if (returnInSub) return;
      }

      protected void E164W2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV17DateRange = Gx_date;
         AssignAttri("", false, "AV17DateRange", context.localUtil.Format(AV17DateRange, "99/99/99"));
         GXt_int1 = AV5LoggedInEmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV5LoggedInEmployeeId = GXt_int1;
         AssignAttri("", false, "AV5LoggedInEmployeeId", StringUtil.LTrimStr( (decimal)(AV5LoggedInEmployeeId), 10, 0));
         GXt_boolean2 = AV56IsProjectManager;
         new userhasrole(context ).execute(  "Project Manager", out  GXt_boolean2) ;
         AV56IsProjectManager = GXt_boolean2;
         AssignAttri("", false, "AV56IsProjectManager", AV56IsProjectManager);
         if ( ! (0==AV5LoggedInEmployeeId) && ! AV56IsProjectManager )
         {
            /* Using cursor H004W2 */
            pr_default.execute(0, new Object[] {AV5LoggedInEmployeeId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A100CompanyId = H004W2_A100CompanyId[0];
               A106EmployeeId = H004W2_A106EmployeeId[0];
               A157CompanyLocationId = H004W2_A157CompanyLocationId[0];
               A157CompanyLocationId = H004W2_A157CompanyLocationId[0];
               AV23EmployeeCompanyLocationId = A157CompanyLocationId;
               AssignAttri("", false, "AV23EmployeeCompanyLocationId", StringUtil.LTrimStr( (decimal)(AV23EmployeeCompanyLocationId), 10, 0));
               AV12CompanyLocationId.Add(A157CompanyLocationId, 0);
               Combo_companylocationid_Enabled = false;
               ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_companylocationid_Enabled));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV56IsProjectManager ,
                                              A162ProjectManagerId ,
                                              AV5LoggedInEmployeeId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         /* Using cursor H004W3 */
         pr_default.execute(1, new Object[] {AV5LoggedInEmployeeId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A162ProjectManagerId = H004W3_A162ProjectManagerId[0];
            n162ProjectManagerId = H004W3_n162ProjectManagerId[0];
            A102ProjectId = H004W3_A102ProjectId[0];
            AV57ProjectIds.Add(A102ProjectId, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Execute user subroutine: 'GETEMPLOYEEIDSBYPROJECT' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = AV21DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3) ;
         AV21DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3;
         this.executeUsercontrolMethod("", false, "DATERANGE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDaterange_rangetext_Internalname});
         GXt_SdtWWPDateRangePickerOptions4 = AV18DateRange_RangePickerOptions;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_employeeweekreport(context ).execute( out  GXt_SdtWWPDateRangePickerOptions4) ;
         AV18DateRange_RangePickerOptions = GXt_SdtWWPDateRangePickerOptions4;
         /* Execute user subroutine: 'LOADCOMBOCOMPANYLOCATIONID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S142 ();
         if (returnInSub) return;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Form.Caption = "";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S152 ();
         if (returnInSub) return;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         Form.Caption = "Employee Week Hours";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         GXt_SdtWWPDateRangePickerOptions4 = AV39Options;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_getoptionsreports(context ).execute( out  GXt_SdtWWPDateRangePickerOptions4) ;
         AV39Options = GXt_SdtWWPDateRangePickerOptions4;
         this.executeExternalObjectMethod("", false, "WWPActions", "DateTimePicker_SetOptions", new Object[] {(string)edtavDaterange_rangetext_Internalname,AV39Options.ToJSonString(false, true)}, false);
      }

      protected void E174W2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV55WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S172 ();
         if (returnInSub) return;
         AV30GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV30GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV30GridCurrentPage), 10, 0));
         AV31GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV31GridPageCount", StringUtil.LTrimStr( (decimal)(AV31GridPageCount), 10, 0));
         GXt_char5 = AV29GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV95Pgmname, out  GXt_char5) ;
         AV29GridAppliedFilters = GXt_char5;
         AssignAttri("", false, "AV29GridAppliedFilters", AV29GridAppliedFilters);
         edtavSdtemployeeweekreports__mon_formatted_Columnheaderclass = "WWColumn ColumnAlignCenter WeekDay";
         AssignProp("", false, edtavSdtemployeeweekreports__mon_formatted_Internalname, "Columnheaderclass", edtavSdtemployeeweekreports__mon_formatted_Columnheaderclass, !bGXsfl_40_Refreshing);
         edtavSdtemployeeweekreports__tue_formatted_Columnheaderclass = "WWColumn ColumnAlignCenter WeekDay";
         AssignProp("", false, edtavSdtemployeeweekreports__tue_formatted_Internalname, "Columnheaderclass", edtavSdtemployeeweekreports__tue_formatted_Columnheaderclass, !bGXsfl_40_Refreshing);
         edtavSdtemployeeweekreports__wed_formatted_Columnheaderclass = "WWColumn ColumnAlignCenter WeekDay";
         AssignProp("", false, edtavSdtemployeeweekreports__wed_formatted_Internalname, "Columnheaderclass", edtavSdtemployeeweekreports__wed_formatted_Columnheaderclass, !bGXsfl_40_Refreshing);
         edtavSdtemployeeweekreports__thu_formatted_Columnheaderclass = "WWColumn ColumnAlignCenter WeekDay";
         AssignProp("", false, edtavSdtemployeeweekreports__thu_formatted_Internalname, "Columnheaderclass", edtavSdtemployeeweekreports__thu_formatted_Columnheaderclass, !bGXsfl_40_Refreshing);
         edtavSdtemployeeweekreports__fri_formatted_Columnheaderclass = "WWColumn ColumnAlignCenter WeekDay";
         AssignProp("", false, edtavSdtemployeeweekreports__fri_formatted_Internalname, "Columnheaderclass", edtavSdtemployeeweekreports__fri_formatted_Columnheaderclass, !bGXsfl_40_Refreshing);
         edtavSdtemployeeweekreports__total_formatted_Columnheaderclass = "WWColumn ColumnAlignCenter";
         AssignProp("", false, edtavSdtemployeeweekreports__total_formatted_Internalname, "Columnheaderclass", edtavSdtemployeeweekreports__total_formatted_Columnheaderclass, !bGXsfl_40_Refreshing);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41SDTEmployeeWeekReports", AV41SDTEmployeeWeekReports);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ProjectId", AV59ProjectId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58EmployeeIds", AV58EmployeeIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
      }

      protected void E134W2( )
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
            AV40PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV40PageToGo) ;
         }
      }

      protected void E144W2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E184W2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV41SDTEmployeeWeekReports.Count )
         {
            AV41SDTEmployeeWeekReports.CurrentItem = ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1));
            if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Mon_isholiday )
            {
               edtavSdtemployeeweekreports__mon_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnWarning WWColumnWarningSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Mon > 480 )
            {
               edtavSdtemployeeweekreports__mon_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnSuccess WWColumnSuccessSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Mon < 480 )
            {
               edtavSdtemployeeweekreports__mon_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnDanger WWColumnDangerSingleCell";
            }
            else
            {
               edtavSdtemployeeweekreports__mon_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay";
            }
            if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Tue_isholiday )
            {
               edtavSdtemployeeweekreports__tue_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnWarning WWColumnWarningSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Tue > 480 )
            {
               edtavSdtemployeeweekreports__tue_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnSuccess WWColumnSuccessSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Tue < 480 )
            {
               edtavSdtemployeeweekreports__tue_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnDanger WWColumnDangerSingleCell";
            }
            else
            {
               edtavSdtemployeeweekreports__tue_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay";
            }
            if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Wed_isholiday )
            {
               edtavSdtemployeeweekreports__wed_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnWarning WWColumnWarningSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Wed > 480 )
            {
               edtavSdtemployeeweekreports__wed_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnSuccess WWColumnSuccessSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Wed < 480 )
            {
               edtavSdtemployeeweekreports__wed_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnDanger WWColumnDangerSingleCell";
            }
            else
            {
               edtavSdtemployeeweekreports__wed_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay";
            }
            if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Thu_isholiday )
            {
               edtavSdtemployeeweekreports__thu_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnWarning WWColumnWarningSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Thu > 480 )
            {
               edtavSdtemployeeweekreports__thu_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnSuccess WWColumnSuccessSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Thu < 480 )
            {
               edtavSdtemployeeweekreports__thu_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnDanger WWColumnDangerSingleCell";
            }
            else
            {
               edtavSdtemployeeweekreports__thu_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay";
            }
            if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Fri_isholiday )
            {
               edtavSdtemployeeweekreports__fri_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnWarning WWColumnWarningSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Fri > 480 )
            {
               edtavSdtemployeeweekreports__fri_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnSuccess WWColumnSuccessSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Fri < 480 )
            {
               edtavSdtemployeeweekreports__fri_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay WWColumnDanger WWColumnDangerSingleCell";
            }
            else
            {
               edtavSdtemployeeweekreports__fri_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay";
            }
            chkavSdtemployeeweekreports__mon_isholiday_Columnclass = ((((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Mon_isholiday) ? "WWColumn ColumnAlignCenter WWColumnWarning WWColumnWarningSingleCell" : "WWColumn ColumnAlignCenter");
            edtavSdtemployeeweekreports__leave_formatted_Columnclass = ((((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Leave>0) ? "WWColumn ColumnAlignCenter WWColumnWarning WWColumnWarningSingleCell" : "WWColumn ColumnAlignCenter");
            if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Total > ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Expected )
            {
               edtavSdtemployeeweekreports__total_formatted_Columnclass = "WWColumn ColumnAlignCenter WWColumnSuccess WWColumnSuccessSingleCell";
            }
            else if ( ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Total < ((SdtSDTEmployeeWeekReport)(AV41SDTEmployeeWeekReports.CurrentItem)).gxTpr_Expected )
            {
               edtavSdtemployeeweekreports__total_formatted_Columnclass = "WWColumn ColumnAlignCenter WWColumnDanger WWColumnDangerSingleCell";
            }
            else
            {
               edtavSdtemployeeweekreports__total_formatted_Columnclass = "WWColumn ColumnAlignCenter";
            }
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
            if ( isFullAjaxMode( ) && ! bGXsfl_40_Refreshing )
            {
               DoAjaxLoad(40, GridRow);
            }
            AV69GXV1 = (int)(AV69GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E124W2( )
      {
         AV69GXV1 = (int)(nGXsfl_40_idx+GRID_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV41SDTEmployeeWeekReports.Count >= AV69GXV1 ) )
         {
            AV41SDTEmployeeWeekReports.CurrentItem = ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1));
         }
         /* Combo_projectid_Onoptionclicked Routine */
         returnInSub = false;
         AV57ProjectIds.FromJSonString(Combo_projectid_Selectedvalue_get, null);
         GXt_objcol_int6 = AV58EmployeeIds;
         new getemployeeidsbyproject(context ).execute(  AV57ProjectIds, out  GXt_objcol_int6) ;
         AV58EmployeeIds = GXt_objcol_int6;
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         AV59ProjectId.FromJSonString(Combo_projectid_Selectedvalue_get, null);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57ProjectIds", AV57ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58EmployeeIds", AV58EmployeeIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ProjectId", AV59ProjectId);
         if ( gx_BV40 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41SDTEmployeeWeekReports", AV41SDTEmployeeWeekReports);
            nGXsfl_40_bak_idx = nGXsfl_40_idx;
            gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
            nGXsfl_40_idx = nGXsfl_40_bak_idx;
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
      }

      protected void E114W2( )
      {
         AV69GXV1 = (int)(nGXsfl_40_idx+GRID_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV41SDTEmployeeWeekReports.Count >= AV69GXV1 ) )
         {
            AV41SDTEmployeeWeekReports.CurrentItem = ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1));
         }
         /* Combo_companylocationid_Onoptionclicked Routine */
         returnInSub = false;
         AV12CompanyLocationId.FromJSonString(Combo_companylocationid_Selectedvalue_get, null);
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         AV12CompanyLocationId.FromJSonString(Combo_companylocationid_Selectedvalue_get, null);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
         if ( gx_BV40 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41SDTEmployeeWeekReports", AV41SDTEmployeeWeekReports);
            nGXsfl_40_bak_idx = nGXsfl_40_idx;
            gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
            nGXsfl_40_idx = nGXsfl_40_bak_idx;
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ProjectId", AV59ProjectId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58EmployeeIds", AV58EmployeeIds);
      }

      protected void S172( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV44Session.Get(AV95Pgmname+"GridState"), "") == 0 )
         {
            AV32GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV95Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV44Session.Get(AV95Pgmname+"GridState"), null, "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV32GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV32GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV32GridState.gxTpr_Currentpage) ;
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV32GridState.FromXml(AV44Session.Get(AV95Pgmname+"GridState"), null, "", "");
         AV32GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV32GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV95Pgmname+"GridState",  AV32GridState.ToXml(false, true, "", "")) ;
      }

      protected void S142( )
      {
         /* 'LOADCOMBOPROJECTID' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV57ProjectIds } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor H004W4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A102ProjectId = H004W4_A102ProjectId[0];
            A103ProjectName = H004W4_A103ProjectName[0];
            AV11Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0));
            AV11Combo_DataItem.gxTpr_Title = A103ProjectName;
            AV60ProjectId_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_projectid_Selectedvalue_set = AV59ProjectId.ToJSonString(false);
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedValue_set", Combo_projectid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCOMPANYLOCATIONID' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV23EmployeeCompanyLocationId ,
                                              A157CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H004W5 */
         pr_default.execute(3, new Object[] {AV23EmployeeCompanyLocationId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A157CompanyLocationId = H004W5_A157CompanyLocationId[0];
            A158CompanyLocationName = H004W5_A158CompanyLocationName[0];
            AV11Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0));
            AV11Combo_DataItem.gxTpr_Title = A158CompanyLocationName;
            AV13CompanyLocationId_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_companylocationid_Selectedvalue_set = AV12CompanyLocationId.ToJSonString(false);
         ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "SelectedValue_set", Combo_companylocationid_Selectedvalue_set);
      }

      protected void E194W2( )
      {
         AV69GXV1 = (int)(nGXsfl_40_idx+GRID_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV41SDTEmployeeWeekReports.Count >= AV69GXV1 ) )
         {
            AV41SDTEmployeeWeekReports.CurrentItem = ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1));
         }
         /* 'DoPrev' Routine */
         returnInSub = false;
         AV17DateRange = DateTimeUtil.DAdd( AV17DateRange, (-7));
         AssignAttri("", false, "AV17DateRange", context.localUtil.Format(AV17DateRange, "99/99/99"));
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV40 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41SDTEmployeeWeekReports", AV41SDTEmployeeWeekReports);
            nGXsfl_40_bak_idx = nGXsfl_40_idx;
            gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
            nGXsfl_40_idx = nGXsfl_40_bak_idx;
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ProjectId", AV59ProjectId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58EmployeeIds", AV58EmployeeIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
      }

      protected void E204W2( )
      {
         AV69GXV1 = (int)(nGXsfl_40_idx+GRID_nFirstRecordOnPage);
         if ( ( AV69GXV1 > 0 ) && ( AV41SDTEmployeeWeekReports.Count >= AV69GXV1 ) )
         {
            AV41SDTEmployeeWeekReports.CurrentItem = ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1));
         }
         /* 'DoNext' Routine */
         returnInSub = false;
         AV17DateRange = DateTimeUtil.DAdd( AV17DateRange, (7));
         AssignAttri("", false, "AV17DateRange", context.localUtil.Format(AV17DateRange, "99/99/99"));
         /* Execute user subroutine: 'GETDATA' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV40 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41SDTEmployeeWeekReports", AV41SDTEmployeeWeekReports);
            nGXsfl_40_bak_idx = nGXsfl_40_idx;
            gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
            nGXsfl_40_idx = nGXsfl_40_bak_idx;
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ProjectId", AV59ProjectId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58EmployeeIds", AV58EmployeeIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
      }

      protected void E154W2( )
      {
         /* Daterange_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         GXt_SdtWWPDateRangePickerOptions4 = AV18DateRange_RangePickerOptions;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_getoptionsreports(context ).execute( out  GXt_SdtWWPDateRangePickerOptions4) ;
         AV18DateRange_RangePickerOptions = GXt_SdtWWPDateRangePickerOptions4;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18DateRange_RangePickerOptions", AV18DateRange_RangePickerOptions);
         if ( gx_BV40 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41SDTEmployeeWeekReports", AV41SDTEmployeeWeekReports);
            nGXsfl_40_bak_idx = nGXsfl_40_idx;
            gxgrGrid_refresh( subGrid_Rows, AV95Pgmname, AV20DateRange_To, AV17DateRange, AV12CompanyLocationId, AV58EmployeeIds, AV59ProjectId, AV41SDTEmployeeWeekReports) ;
            nGXsfl_40_idx = nGXsfl_40_bak_idx;
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59ProjectId", AV59ProjectId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58EmployeeIds", AV58EmployeeIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
      }

      protected void S182( )
      {
         /* 'GETWEEKSTARTDATE' Routine */
         returnInSub = false;
         AV17DateRange = DateTimeUtil.DAdd( AV17DateRange, (-1*(DateTimeUtil.Dow( AV17DateRange)-2)));
         AssignAttri("", false, "AV17DateRange", context.localUtil.Format(AV17DateRange, "99/99/99"));
         AV20DateRange_To = DateTimeUtil.DAdd( AV17DateRange, (6));
         AssignAttri("", false, "AV20DateRange_To", context.localUtil.Format(AV20DateRange_To, "99/99/99"));
      }

      protected void S122( )
      {
         /* 'GETDATA' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETWEEKSTARTDATE' */
         S182 ();
         if (returnInSub) return;
         if ( ( DateTimeUtil.DDiff( AV20DateRange_To , AV17DateRange ) < 6 ) )
         {
            AV20DateRange_To = DateTimeUtil.DAdd( AV17DateRange, (6));
            AssignAttri("", false, "AV20DateRange_To", context.localUtil.Format(AV20DateRange_To, "99/99/99"));
         }
         GXt_objcol_SdtSDTEmployeeWeekReport7 = AV41SDTEmployeeWeekReports;
         new prc_employeeweekreport(context ).execute( ref  AV17DateRange, ref  AV20DateRange_To, ref  AV12CompanyLocationId, ref  AV58EmployeeIds, ref  AV59ProjectId, out  GXt_objcol_SdtSDTEmployeeWeekReport7) ;
         AssignAttri("", false, "AV17DateRange", context.localUtil.Format(AV17DateRange, "99/99/99"));
         AssignAttri("", false, "AV20DateRange_To", context.localUtil.Format(AV20DateRange_To, "99/99/99"));
         AV41SDTEmployeeWeekReports = GXt_objcol_SdtSDTEmployeeWeekReport7;
         gx_BV40 = true;
         GXt_char5 = "";
         new formatdatetime(context ).execute(  AV17DateRange,  "YYYY-MM-DD", out  GXt_char5) ;
         Usercontrol1_Fromdate = GXt_char5;
         ucUsercontrol1.SendProperty(context, "", false, Usercontrol1_Internalname, "fromDate", Usercontrol1_Fromdate);
         GXt_char5 = "";
         new formatdatetime(context ).execute(  AV20DateRange_To,  "YYYY-MM-DD", out  GXt_char5) ;
         Usercontrol1_Todate = GXt_char5;
         ucUsercontrol1.SendProperty(context, "", false, Usercontrol1_Internalname, "toDate", Usercontrol1_Todate);
      }

      protected void S112( )
      {
         /* 'GETEMPLOYEEIDSBYPROJECT' Routine */
         returnInSub = false;
         GXt_objcol_int6 = AV58EmployeeIds;
         new getemployeeidsbyproject(context ).execute(  AV57ProjectIds, out  GXt_objcol_int6) ;
         AV58EmployeeIds = GXt_objcol_int6;
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
         PA4W2( ) ;
         WS4W2( ) ;
         WE4W2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267553393", true, true);
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
            context.AddJavascriptSource("employeeweekreport.js", "?20256267553395", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
            context.AddJavascriptSource("UserControls/UC_SetWeekTableHeadersRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_402( )
      {
         edtavSdtemployeeweekreports__employeename_Internalname = "SDTEMPLOYEEWEEKREPORTS__EMPLOYEENAME_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__mon_Internalname = "SDTEMPLOYEEWEEKREPORTS__MON_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__tue_Internalname = "SDTEMPLOYEEWEEKREPORTS__TUE_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__wed_Internalname = "SDTEMPLOYEEWEEKREPORTS__WED_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__thu_Internalname = "SDTEMPLOYEEWEEKREPORTS__THU_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__fri_Internalname = "SDTEMPLOYEEWEEKREPORTS__FRI_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__sat_Internalname = "SDTEMPLOYEEWEEKREPORTS__SAT_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__sun_Internalname = "SDTEMPLOYEEWEEKREPORTS__SUN_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__leave_Internalname = "SDTEMPLOYEEWEEKREPORTS__LEAVE_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__expected_Internalname = "SDTEMPLOYEEWEEKREPORTS__EXPECTED_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__total_Internalname = "SDTEMPLOYEEWEEKREPORTS__TOTAL_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__mon_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__MON_FORMATTED_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__tue_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__TUE_FORMATTED_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__wed_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__WED_FORMATTED_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__thu_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__THU_FORMATTED_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__fri_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__FRI_FORMATTED_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__sat_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__SAT_FORMATTED_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__sun_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__SUN_FORMATTED_"+sGXsfl_40_idx;
         chkavSdtemployeeweekreports__mon_isholiday_Internalname = "SDTEMPLOYEEWEEKREPORTS__MON_ISHOLIDAY_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__leave_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__LEAVE_FORMATTED_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__expected_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__EXPECTED_FORMATTED_"+sGXsfl_40_idx;
         edtavSdtemployeeweekreports__total_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__TOTAL_FORMATTED_"+sGXsfl_40_idx;
      }

      protected void SubsflControlProps_fel_402( )
      {
         edtavSdtemployeeweekreports__employeename_Internalname = "SDTEMPLOYEEWEEKREPORTS__EMPLOYEENAME_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__mon_Internalname = "SDTEMPLOYEEWEEKREPORTS__MON_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__tue_Internalname = "SDTEMPLOYEEWEEKREPORTS__TUE_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__wed_Internalname = "SDTEMPLOYEEWEEKREPORTS__WED_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__thu_Internalname = "SDTEMPLOYEEWEEKREPORTS__THU_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__fri_Internalname = "SDTEMPLOYEEWEEKREPORTS__FRI_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__sat_Internalname = "SDTEMPLOYEEWEEKREPORTS__SAT_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__sun_Internalname = "SDTEMPLOYEEWEEKREPORTS__SUN_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__leave_Internalname = "SDTEMPLOYEEWEEKREPORTS__LEAVE_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__expected_Internalname = "SDTEMPLOYEEWEEKREPORTS__EXPECTED_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__total_Internalname = "SDTEMPLOYEEWEEKREPORTS__TOTAL_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__mon_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__MON_FORMATTED_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__tue_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__TUE_FORMATTED_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__wed_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__WED_FORMATTED_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__thu_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__THU_FORMATTED_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__fri_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__FRI_FORMATTED_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__sat_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__SAT_FORMATTED_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__sun_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__SUN_FORMATTED_"+sGXsfl_40_fel_idx;
         chkavSdtemployeeweekreports__mon_isholiday_Internalname = "SDTEMPLOYEEWEEKREPORTS__MON_ISHOLIDAY_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__leave_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__LEAVE_FORMATTED_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__expected_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__EXPECTED_FORMATTED_"+sGXsfl_40_fel_idx;
         edtavSdtemployeeweekreports__total_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__TOTAL_FORMATTED_"+sGXsfl_40_fel_idx;
      }

      protected void sendrow_402( )
      {
         sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
         SubsflControlProps_402( ) ;
         WB4W0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__employeename_Internalname,StringUtil.RTrim( ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Employeename),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__employeename_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtemployeeweekreports__employeename_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__mon_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Mon), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtemployeeweekreports__mon_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Mon), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Mon), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__mon_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtemployeeweekreports__mon_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__tue_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Tue), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtemployeeweekreports__tue_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Tue), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Tue), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__tue_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtemployeeweekreports__tue_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__wed_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Wed), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtemployeeweekreports__wed_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Wed), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Wed), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__wed_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtemployeeweekreports__wed_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__thu_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Thu), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtemployeeweekreports__thu_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Thu), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Thu), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__thu_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtemployeeweekreports__thu_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__fri_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Fri), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtemployeeweekreports__fri_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Fri), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Fri), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__fri_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtemployeeweekreports__fri_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__sat_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Sat), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtemployeeweekreports__sat_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Sat), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Sat), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__sat_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtemployeeweekreports__sat_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__sun_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Sun), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtemployeeweekreports__sun_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Sun), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Sun), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__sun_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtemployeeweekreports__sun_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__leave_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Leave), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtemployeeweekreports__leave_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Leave), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Leave), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__leave_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtemployeeweekreports__leave_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__expected_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Expected), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtemployeeweekreports__expected_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Expected), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Expected), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__expected_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtemployeeweekreports__expected_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__total_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Total), 10, 0, ".", "")),StringUtil.LTrim( ((edtavSdtemployeeweekreports__total_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Total), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Total), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__total_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtemployeeweekreports__total_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__mon_formatted_Internalname,((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Mon_formatted,((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Mon_formatted,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__mon_formatted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdtemployeeweekreports__mon_formatted_Columnclass,(string)edtavSdtemployeeweekreports__mon_formatted_Columnheaderclass,(short)-1,(int)edtavSdtemployeeweekreports__mon_formatted_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)1,(short)40,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__tue_formatted_Internalname,((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Tue_formatted,((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Tue_formatted,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__tue_formatted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdtemployeeweekreports__tue_formatted_Columnclass,(string)edtavSdtemployeeweekreports__tue_formatted_Columnheaderclass,(short)-1,(int)edtavSdtemployeeweekreports__tue_formatted_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)1,(short)40,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__wed_formatted_Internalname,((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Wed_formatted,((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Wed_formatted,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__wed_formatted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdtemployeeweekreports__wed_formatted_Columnclass,(string)edtavSdtemployeeweekreports__wed_formatted_Columnheaderclass,(short)-1,(int)edtavSdtemployeeweekreports__wed_formatted_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)1,(short)40,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__thu_formatted_Internalname,((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Thu_formatted,((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Thu_formatted,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__thu_formatted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdtemployeeweekreports__thu_formatted_Columnclass,(string)edtavSdtemployeeweekreports__thu_formatted_Columnheaderclass,(short)-1,(int)edtavSdtemployeeweekreports__thu_formatted_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)1,(short)40,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__fri_formatted_Internalname,((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Fri_formatted,((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Fri_formatted,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__fri_formatted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdtemployeeweekreports__fri_formatted_Columnclass,(string)edtavSdtemployeeweekreports__fri_formatted_Columnheaderclass,(short)-1,(int)edtavSdtemployeeweekreports__fri_formatted_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)1,(short)40,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__sat_formatted_Internalname,StringUtil.RTrim( ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Sat_formatted),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__sat_formatted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnAlignCenter WeekDay",(string)"",(short)-1,(int)edtavSdtemployeeweekreports__sat_formatted_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__sun_formatted_Internalname,StringUtil.RTrim( ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Sun_formatted),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__sun_formatted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnAlignCenter WeekDay",(string)"",(short)-1,(int)edtavSdtemployeeweekreports__sun_formatted_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "SDTEMPLOYEEWEEKREPORTS__MON_ISHOLIDAY_" + sGXsfl_40_idx;
            chkavSdtemployeeweekreports__mon_isholiday.Name = GXCCtl;
            chkavSdtemployeeweekreports__mon_isholiday.WebTags = "";
            chkavSdtemployeeweekreports__mon_isholiday.Caption = "";
            AssignProp("", false, chkavSdtemployeeweekreports__mon_isholiday_Internalname, "TitleCaption", chkavSdtemployeeweekreports__mon_isholiday.Caption, !bGXsfl_40_Refreshing);
            chkavSdtemployeeweekreports__mon_isholiday.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSdtemployeeweekreports__mon_isholiday_Internalname,StringUtil.BoolToStr( ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Mon_isholiday),(string)"",(string)"",(short)0,chkavSdtemployeeweekreports__mon_isholiday.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)chkavSdtemployeeweekreports__mon_isholiday_Columnclass,(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__leave_formatted_Internalname,StringUtil.RTrim( ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Leave_formatted),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__leave_formatted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdtemployeeweekreports__leave_formatted_Columnclass,(string)"",(short)0,(int)edtavSdtemployeeweekreports__leave_formatted_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__expected_formatted_Internalname,StringUtil.RTrim( ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Expected_formatted),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__expected_formatted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn ColumnAlignCenter",(string)"",(short)-1,(int)edtavSdtemployeeweekreports__expected_formatted_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_40_idx + "',40)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtemployeeweekreports__total_formatted_Internalname,StringUtil.RTrim( ((SdtSDTEmployeeWeekReport)AV41SDTEmployeeWeekReports.Item(AV69GXV1)).gxTpr_Total_formatted),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtemployeeweekreports__total_formatted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavSdtemployeeweekreports__total_formatted_Columnclass,(string)edtavSdtemployeeweekreports__total_formatted_Columnheaderclass,(short)-1,(int)edtavSdtemployeeweekreports__total_formatted_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)40,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4W2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_40_idx = ((subGrid_Islastpage==1)&&(nGXsfl_40_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_40_idx+1);
            sGXsfl_40_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_40_idx), 4, 0), 4, "0");
            SubsflControlProps_402( ) ;
         }
         /* End function sendrow_402 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SDTEMPLOYEEWEEKREPORTS__MON_ISHOLIDAY_" + sGXsfl_40_idx;
         chkavSdtemployeeweekreports__mon_isholiday.Name = GXCCtl;
         chkavSdtemployeeweekreports__mon_isholiday.WebTags = "";
         chkavSdtemployeeweekreports__mon_isholiday.Caption = "";
         AssignProp("", false, chkavSdtemployeeweekreports__mon_isholiday_Internalname, "TitleCaption", chkavSdtemployeeweekreports__mon_isholiday.Caption, !bGXsfl_40_Refreshing);
         chkavSdtemployeeweekreports__mon_isholiday.CheckedValue = "false";
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Employees") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Mon") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tue") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Wed") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Thu") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Fri") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Sat") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Sun") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Leave") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Expected") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Total") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "M") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "T") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "W") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "T") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "F") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "S") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "S") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "M") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Leave/Holiday") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Expected") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total") ;
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
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__employeename_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__mon_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__tue_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__wed_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__thu_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__fri_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__sat_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__sun_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__leave_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__expected_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__total_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdtemployeeweekreports__mon_formatted_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSdtemployeeweekreports__mon_formatted_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__mon_formatted_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdtemployeeweekreports__tue_formatted_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSdtemployeeweekreports__tue_formatted_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__tue_formatted_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdtemployeeweekreports__wed_formatted_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSdtemployeeweekreports__wed_formatted_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__wed_formatted_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdtemployeeweekreports__thu_formatted_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSdtemployeeweekreports__thu_formatted_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__thu_formatted_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdtemployeeweekreports__fri_formatted_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSdtemployeeweekreports__fri_formatted_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__fri_formatted_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__sat_formatted_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__sun_formatted_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( chkavSdtemployeeweekreports__mon_isholiday_Columnclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavSdtemployeeweekreports__mon_isholiday.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdtemployeeweekreports__leave_formatted_Columnclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__leave_formatted_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__expected_formatted_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavSdtemployeeweekreports__total_formatted_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavSdtemployeeweekreports__total_formatted_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtemployeeweekreports__total_formatted_Enabled), 5, 0, ".", "")));
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
         lblTextblockdaterange_rangetext_Internalname = "TEXTBLOCKDATERANGE_RANGETEXT";
         edtavDaterange_rangetext_Internalname = "vDATERANGE_RANGETEXT";
         divUnnamedtableaterange_rangetext_Internalname = "UNNAMEDTABLEATERANGE_RANGETEXT";
         lblTextblockcombo_companylocationid_Internalname = "TEXTBLOCKCOMBO_COMPANYLOCATIONID";
         Combo_companylocationid_Internalname = "COMBO_COMPANYLOCATIONID";
         divTablesplittedcompanylocationid_Internalname = "TABLESPLITTEDCOMPANYLOCATIONID";
         lblTextblockcombo_projectid_Internalname = "TEXTBLOCKCOMBO_PROJECTID";
         Combo_projectid_Internalname = "COMBO_PROJECTID";
         divTablesplittedprojectid_Internalname = "TABLESPLITTEDPROJECTID";
         divTable_Internalname = "TABLE";
         edtavSdtemployeeweekreports__employeename_Internalname = "SDTEMPLOYEEWEEKREPORTS__EMPLOYEENAME";
         edtavSdtemployeeweekreports__mon_Internalname = "SDTEMPLOYEEWEEKREPORTS__MON";
         edtavSdtemployeeweekreports__tue_Internalname = "SDTEMPLOYEEWEEKREPORTS__TUE";
         edtavSdtemployeeweekreports__wed_Internalname = "SDTEMPLOYEEWEEKREPORTS__WED";
         edtavSdtemployeeweekreports__thu_Internalname = "SDTEMPLOYEEWEEKREPORTS__THU";
         edtavSdtemployeeweekreports__fri_Internalname = "SDTEMPLOYEEWEEKREPORTS__FRI";
         edtavSdtemployeeweekreports__sat_Internalname = "SDTEMPLOYEEWEEKREPORTS__SAT";
         edtavSdtemployeeweekreports__sun_Internalname = "SDTEMPLOYEEWEEKREPORTS__SUN";
         edtavSdtemployeeweekreports__leave_Internalname = "SDTEMPLOYEEWEEKREPORTS__LEAVE";
         edtavSdtemployeeweekreports__expected_Internalname = "SDTEMPLOYEEWEEKREPORTS__EXPECTED";
         edtavSdtemployeeweekreports__total_Internalname = "SDTEMPLOYEEWEEKREPORTS__TOTAL";
         edtavSdtemployeeweekreports__mon_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__MON_FORMATTED";
         edtavSdtemployeeweekreports__tue_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__TUE_FORMATTED";
         edtavSdtemployeeweekreports__wed_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__WED_FORMATTED";
         edtavSdtemployeeweekreports__thu_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__THU_FORMATTED";
         edtavSdtemployeeweekreports__fri_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__FRI_FORMATTED";
         edtavSdtemployeeweekreports__sat_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__SAT_FORMATTED";
         edtavSdtemployeeweekreports__sun_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__SUN_FORMATTED";
         chkavSdtemployeeweekreports__mon_isholiday_Internalname = "SDTEMPLOYEEWEEKREPORTS__MON_ISHOLIDAY";
         edtavSdtemployeeweekreports__leave_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__LEAVE_FORMATTED";
         edtavSdtemployeeweekreports__expected_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__EXPECTED_FORMATTED";
         edtavSdtemployeeweekreports__total_formatted_Internalname = "SDTEMPLOYEEWEEKREPORTS__TOTAL_FORMATTED";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         Usercontrol1_Internalname = "USERCONTROL1";
         divTablemain_Internalname = "TABLEMAIN";
         Daterange_rangepicker_Internalname = "DATERANGE_RANGEPICKER";
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
         edtavSdtemployeeweekreports__total_formatted_Jsonclick = "";
         edtavSdtemployeeweekreports__total_formatted_Columnheaderclass = "";
         edtavSdtemployeeweekreports__total_formatted_Columnclass = "WWColumn ColumnAlignCenter";
         edtavSdtemployeeweekreports__total_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__expected_formatted_Jsonclick = "";
         edtavSdtemployeeweekreports__expected_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__leave_formatted_Jsonclick = "";
         edtavSdtemployeeweekreports__leave_formatted_Columnclass = "WWColumn ColumnAlignCenter";
         edtavSdtemployeeweekreports__leave_formatted_Enabled = 0;
         chkavSdtemployeeweekreports__mon_isholiday.Caption = "";
         chkavSdtemployeeweekreports__mon_isholiday_Columnclass = "WWColumn ColumnAlignCenter";
         chkavSdtemployeeweekreports__mon_isholiday.Enabled = 0;
         edtavSdtemployeeweekreports__sun_formatted_Jsonclick = "";
         edtavSdtemployeeweekreports__sun_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__sat_formatted_Jsonclick = "";
         edtavSdtemployeeweekreports__sat_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__fri_formatted_Jsonclick = "";
         edtavSdtemployeeweekreports__fri_formatted_Columnheaderclass = "";
         edtavSdtemployeeweekreports__fri_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay";
         edtavSdtemployeeweekreports__fri_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__thu_formatted_Jsonclick = "";
         edtavSdtemployeeweekreports__thu_formatted_Columnheaderclass = "";
         edtavSdtemployeeweekreports__thu_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay";
         edtavSdtemployeeweekreports__thu_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__wed_formatted_Jsonclick = "";
         edtavSdtemployeeweekreports__wed_formatted_Columnheaderclass = "";
         edtavSdtemployeeweekreports__wed_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay";
         edtavSdtemployeeweekreports__wed_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__tue_formatted_Jsonclick = "";
         edtavSdtemployeeweekreports__tue_formatted_Columnheaderclass = "";
         edtavSdtemployeeweekreports__tue_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay";
         edtavSdtemployeeweekreports__tue_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__mon_formatted_Jsonclick = "";
         edtavSdtemployeeweekreports__mon_formatted_Columnheaderclass = "";
         edtavSdtemployeeweekreports__mon_formatted_Columnclass = "WWColumn ColumnAlignCenter WeekDay";
         edtavSdtemployeeweekreports__mon_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__total_Jsonclick = "";
         edtavSdtemployeeweekreports__total_Enabled = 0;
         edtavSdtemployeeweekreports__expected_Jsonclick = "";
         edtavSdtemployeeweekreports__expected_Enabled = 0;
         edtavSdtemployeeweekreports__leave_Jsonclick = "";
         edtavSdtemployeeweekreports__leave_Enabled = 0;
         edtavSdtemployeeweekreports__sun_Jsonclick = "";
         edtavSdtemployeeweekreports__sun_Enabled = 0;
         edtavSdtemployeeweekreports__sat_Jsonclick = "";
         edtavSdtemployeeweekreports__sat_Enabled = 0;
         edtavSdtemployeeweekreports__fri_Jsonclick = "";
         edtavSdtemployeeweekreports__fri_Enabled = 0;
         edtavSdtemployeeweekreports__thu_Jsonclick = "";
         edtavSdtemployeeweekreports__thu_Enabled = 0;
         edtavSdtemployeeweekreports__wed_Jsonclick = "";
         edtavSdtemployeeweekreports__wed_Enabled = 0;
         edtavSdtemployeeweekreports__tue_Jsonclick = "";
         edtavSdtemployeeweekreports__tue_Enabled = 0;
         edtavSdtemployeeweekreports__mon_Jsonclick = "";
         edtavSdtemployeeweekreports__mon_Enabled = 0;
         edtavSdtemployeeweekreports__employeename_Jsonclick = "";
         edtavSdtemployeeweekreports__employeename_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSdtemployeeweekreports__total_formatted_Enabled = -1;
         edtavSdtemployeeweekreports__expected_formatted_Enabled = -1;
         edtavSdtemployeeweekreports__leave_formatted_Enabled = -1;
         chkavSdtemployeeweekreports__mon_isholiday.Enabled = -1;
         edtavSdtemployeeweekreports__sun_formatted_Enabled = -1;
         edtavSdtemployeeweekreports__sat_formatted_Enabled = -1;
         edtavSdtemployeeweekreports__fri_formatted_Enabled = -1;
         edtavSdtemployeeweekreports__thu_formatted_Enabled = -1;
         edtavSdtemployeeweekreports__wed_formatted_Enabled = -1;
         edtavSdtemployeeweekreports__tue_formatted_Enabled = -1;
         edtavSdtemployeeweekreports__mon_formatted_Enabled = -1;
         edtavSdtemployeeweekreports__total_Enabled = -1;
         edtavSdtemployeeweekreports__expected_Enabled = -1;
         edtavSdtemployeeweekreports__leave_Enabled = -1;
         edtavSdtemployeeweekreports__sun_Enabled = -1;
         edtavSdtemployeeweekreports__sat_Enabled = -1;
         edtavSdtemployeeweekreports__fri_Enabled = -1;
         edtavSdtemployeeweekreports__thu_Enabled = -1;
         edtavSdtemployeeweekreports__wed_Enabled = -1;
         edtavSdtemployeeweekreports__tue_Enabled = -1;
         edtavSdtemployeeweekreports__mon_Enabled = -1;
         edtavSdtemployeeweekreports__employeename_Enabled = -1;
         Combo_projectid_Caption = "";
         Combo_companylocationid_Caption = "";
         edtavDaterange_rangetext_Jsonclick = "";
         edtavDaterange_rangetext_Enabled = 1;
         Usercontrol1_Todate = "";
         Usercontrol1_Fromdate = "";
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
         Combo_projectid_Multiplevaluestype = "Tags";
         Combo_projectid_Emptyitem = Convert.ToBoolean( 0);
         Combo_projectid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_projectid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_projectid_Cls = "ExtendedCombo Attribute";
         Combo_companylocationid_Multiplevaluestype = "Tags";
         Combo_companylocationid_Emptyitem = Convert.ToBoolean( 0);
         Combo_companylocationid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_companylocationid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_companylocationid_Enabled = Convert.ToBoolean( -1);
         Combo_companylocationid_Cls = "ExtendedCombo Attribute";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV95Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV59ProjectId","fld":"vPROJECTID"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV30GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV31GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV29GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__MON_FORMATTED","prop":"Columnheaderclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__TUE_FORMATTED","prop":"Columnheaderclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__WED_FORMATTED","prop":"Columnheaderclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__THU_FORMATTED","prop":"Columnheaderclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__FRI_FORMATTED","prop":"Columnheaderclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__TOTAL_FORMATTED","prop":"Columnheaderclass"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"Usercontrol1_Fromdate","ctrl":"USERCONTROL1","prop":"fromDate"},{"av":"Usercontrol1_Todate","ctrl":"USERCONTROL1","prop":"toDate"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E134W2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV95Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E144W2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV95Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E184W2","iparms":[{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"ctrl":"SDTEMPLOYEEWEEKREPORTS__MON_FORMATTED","prop":"Columnclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__TUE_FORMATTED","prop":"Columnclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__WED_FORMATTED","prop":"Columnclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__THU_FORMATTED","prop":"Columnclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__FRI_FORMATTED","prop":"Columnclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__MON_ISHOLIDAY","prop":"Columnclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__LEAVE_FORMATTED","prop":"Columnclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__TOTAL_FORMATTED","prop":"Columnclass"}]}""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED","""{"handler":"E124W2","iparms":[{"av":"Combo_projectid_Selectedvalue_get","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_get"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV95Pgmname","fld":"vPGMNAME","hsh":true}]""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED",""","oparms":[{"av":"AV57ProjectIds","fld":"vPROJECTIDS"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"Usercontrol1_Fromdate","ctrl":"USERCONTROL1","prop":"fromDate"},{"av":"Usercontrol1_Todate","ctrl":"USERCONTROL1","prop":"toDate"}]}""");
         setEventMetadata("COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED","""{"handler":"E114W2","iparms":[{"av":"Combo_companylocationid_Selectedvalue_get","ctrl":"COMBO_COMPANYLOCATIONID","prop":"SelectedValue_get"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV95Pgmname","fld":"vPGMNAME","hsh":true}]""");
         setEventMetadata("COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"Usercontrol1_Fromdate","ctrl":"USERCONTROL1","prop":"fromDate"},{"av":"Usercontrol1_Todate","ctrl":"USERCONTROL1","prop":"toDate"}]}""");
         setEventMetadata("'DOPREV'","""{"handler":"E194W2","iparms":[{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV95Pgmname","fld":"vPGMNAME","hsh":true}]""");
         setEventMetadata("'DOPREV'",""","oparms":[{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"Usercontrol1_Fromdate","ctrl":"USERCONTROL1","prop":"fromDate"},{"av":"Usercontrol1_Todate","ctrl":"USERCONTROL1","prop":"toDate"}]}""");
         setEventMetadata("'DONEXT'","""{"handler":"E204W2","iparms":[{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV95Pgmname","fld":"vPGMNAME","hsh":true}]""");
         setEventMetadata("'DONEXT'",""","oparms":[{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"Usercontrol1_Fromdate","ctrl":"USERCONTROL1","prop":"fromDate"},{"av":"Usercontrol1_Todate","ctrl":"USERCONTROL1","prop":"toDate"}]}""");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED","""{"handler":"E154W2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV95Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40}]""");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED",""","oparms":[{"av":"AV18DateRange_RangePickerOptions","fld":"vDATERANGE_RANGEPICKEROPTIONS"},{"av":"AV30GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV31GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV29GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__MON_FORMATTED","prop":"Columnheaderclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__TUE_FORMATTED","prop":"Columnheaderclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__WED_FORMATTED","prop":"Columnheaderclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__THU_FORMATTED","prop":"Columnheaderclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__FRI_FORMATTED","prop":"Columnheaderclass"},{"ctrl":"SDTEMPLOYEEWEEKREPORTS__TOTAL_FORMATTED","prop":"Columnheaderclass"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV41SDTEmployeeWeekReports","fld":"vSDTEMPLOYEEWEEKREPORTS","grid":40},{"av":"nGXsfl_40_idx","ctrl":"GRID","prop":"GridCurrRow","grid":40},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_40","ctrl":"GRID","prop":"GridRC","grid":40},{"av":"AV59ProjectId","fld":"vPROJECTID"},{"av":"AV58EmployeeIds","fld":"vEMPLOYEEIDS"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV17DateRange","fld":"vDATERANGE"},{"av":"Usercontrol1_Fromdate","ctrl":"USERCONTROL1","prop":"fromDate"},{"av":"Usercontrol1_Todate","ctrl":"USERCONTROL1","prop":"toDate"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv23","iparms":[]}""");
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
         Combo_projectid_Selectedvalue_get = "";
         Combo_companylocationid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV95Pgmname = "";
         AV20DateRange_To = DateTime.MinValue;
         AV17DateRange = DateTime.MinValue;
         AV12CompanyLocationId = new GxSimpleCollection<long>();
         AV58EmployeeIds = new GxSimpleCollection<long>();
         AV59ProjectId = new GxSimpleCollection<long>();
         AV41SDTEmployeeWeekReports = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV21DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13CompanyLocationId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV60ProjectId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV29GridAppliedFilters = "";
         AV18DateRange_RangePickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         Combo_companylocationid_Selectedvalue_set = "";
         Combo_projectid_Selectedvalue_set = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblockdaterange_rangetext_Jsonclick = "";
         TempTags = "";
         AV19DateRange_RangeText = "";
         lblTextblockcombo_companylocationid_Jsonclick = "";
         ucCombo_companylocationid = new GXUserControl();
         lblTextblockcombo_projectid_Jsonclick = "";
         ucCombo_projectid = new GXUserControl();
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucUsercontrol1 = new GXUserControl();
         ucDaterange_rangepicker = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Gx_date = DateTime.MinValue;
         H004W2_A100CompanyId = new long[1] ;
         H004W2_A106EmployeeId = new long[1] ;
         H004W2_A157CompanyLocationId = new long[1] ;
         H004W3_A162ProjectManagerId = new long[1] ;
         H004W3_n162ProjectManagerId = new bool[] {false} ;
         H004W3_A102ProjectId = new long[1] ;
         AV57ProjectIds = new GxSimpleCollection<long>();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV39Options = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         AV55WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV44Session = context.GetSession();
         AV32GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         H004W4_A102ProjectId = new long[1] ;
         H004W4_A103ProjectName = new string[] {""} ;
         A103ProjectName = "";
         AV11Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H004W5_A157CompanyLocationId = new long[1] ;
         H004W5_A158CompanyLocationName = new string[] {""} ;
         A158CompanyLocationName = "";
         GXt_SdtWWPDateRangePickerOptions4 = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         GXt_objcol_SdtSDTEmployeeWeekReport7 = new GXBaseCollection<SdtSDTEmployeeWeekReport>( context, "SDTEmployeeWeekReport", "YTT_version4");
         GXt_char5 = "";
         GXt_objcol_int6 = new GxSimpleCollection<long>();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeeweekreport__default(),
            new Object[][] {
                new Object[] {
               H004W2_A100CompanyId, H004W2_A106EmployeeId, H004W2_A157CompanyLocationId
               }
               , new Object[] {
               H004W3_A162ProjectManagerId, H004W3_n162ProjectManagerId, H004W3_A102ProjectId
               }
               , new Object[] {
               H004W4_A102ProjectId, H004W4_A103ProjectName
               }
               , new Object[] {
               H004W5_A157CompanyLocationId, H004W5_A158CompanyLocationName
               }
            }
         );
         AV95Pgmname = "EmployeeWeekReport";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         AV95Pgmname = "EmployeeWeekReport";
         Gx_date = DateTimeUtil.Today( context);
         edtavSdtemployeeweekreports__employeename_Enabled = 0;
         edtavSdtemployeeweekreports__mon_Enabled = 0;
         edtavSdtemployeeweekreports__tue_Enabled = 0;
         edtavSdtemployeeweekreports__wed_Enabled = 0;
         edtavSdtemployeeweekreports__thu_Enabled = 0;
         edtavSdtemployeeweekreports__fri_Enabled = 0;
         edtavSdtemployeeweekreports__sat_Enabled = 0;
         edtavSdtemployeeweekreports__sun_Enabled = 0;
         edtavSdtemployeeweekreports__leave_Enabled = 0;
         edtavSdtemployeeweekreports__expected_Enabled = 0;
         edtavSdtemployeeweekreports__total_Enabled = 0;
         edtavSdtemployeeweekreports__mon_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__tue_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__wed_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__thu_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__fri_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__sat_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__sun_formatted_Enabled = 0;
         chkavSdtemployeeweekreports__mon_isholiday.Enabled = 0;
         edtavSdtemployeeweekreports__leave_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__expected_formatted_Enabled = 0;
         edtavSdtemployeeweekreports__total_formatted_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_40 ;
      private int nGXsfl_40_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavDaterange_rangetext_Enabled ;
      private int AV69GXV1 ;
      private int subGrid_Islastpage ;
      private int edtavSdtemployeeweekreports__employeename_Enabled ;
      private int edtavSdtemployeeweekreports__mon_Enabled ;
      private int edtavSdtemployeeweekreports__tue_Enabled ;
      private int edtavSdtemployeeweekreports__wed_Enabled ;
      private int edtavSdtemployeeweekreports__thu_Enabled ;
      private int edtavSdtemployeeweekreports__fri_Enabled ;
      private int edtavSdtemployeeweekreports__sat_Enabled ;
      private int edtavSdtemployeeweekreports__sun_Enabled ;
      private int edtavSdtemployeeweekreports__leave_Enabled ;
      private int edtavSdtemployeeweekreports__expected_Enabled ;
      private int edtavSdtemployeeweekreports__total_Enabled ;
      private int edtavSdtemployeeweekreports__mon_formatted_Enabled ;
      private int edtavSdtemployeeweekreports__tue_formatted_Enabled ;
      private int edtavSdtemployeeweekreports__wed_formatted_Enabled ;
      private int edtavSdtemployeeweekreports__thu_formatted_Enabled ;
      private int edtavSdtemployeeweekreports__fri_formatted_Enabled ;
      private int edtavSdtemployeeweekreports__sat_formatted_Enabled ;
      private int edtavSdtemployeeweekreports__sun_formatted_Enabled ;
      private int edtavSdtemployeeweekreports__leave_formatted_Enabled ;
      private int edtavSdtemployeeweekreports__expected_formatted_Enabled ;
      private int edtavSdtemployeeweekreports__total_formatted_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_40_fel_idx=1 ;
      private int AV40PageToGo ;
      private int nGXsfl_40_bak_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV30GridCurrentPage ;
      private long AV31GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long AV5LoggedInEmployeeId ;
      private long GXt_int1 ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long AV23EmployeeCompanyLocationId ;
      private long A162ProjectManagerId ;
      private long A102ProjectId ;
      private string Gridpaginationbar_Selectedpage ;
      private string Combo_projectid_Selectedvalue_get ;
      private string Combo_companylocationid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_40_idx="0001" ;
      private string AV95Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Combo_companylocationid_Cls ;
      private string Combo_companylocationid_Selectedvalue_set ;
      private string Combo_companylocationid_Multiplevaluestype ;
      private string Combo_projectid_Cls ;
      private string Combo_projectid_Selectedvalue_set ;
      private string Combo_projectid_Multiplevaluestype ;
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
      private string Usercontrol1_Fromdate ;
      private string Usercontrol1_Todate ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTable_Internalname ;
      private string divUnnamedtableaterange_rangetext_Internalname ;
      private string lblTextblockdaterange_rangetext_Internalname ;
      private string lblTextblockdaterange_rangetext_Jsonclick ;
      private string edtavDaterange_rangetext_Internalname ;
      private string TempTags ;
      private string edtavDaterange_rangetext_Jsonclick ;
      private string divTablesplittedcompanylocationid_Internalname ;
      private string lblTextblockcombo_companylocationid_Internalname ;
      private string lblTextblockcombo_companylocationid_Jsonclick ;
      private string Combo_companylocationid_Caption ;
      private string Combo_companylocationid_Internalname ;
      private string divTablesplittedprojectid_Internalname ;
      private string lblTextblockcombo_projectid_Internalname ;
      private string lblTextblockcombo_projectid_Jsonclick ;
      private string Combo_projectid_Caption ;
      private string Combo_projectid_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string Usercontrol1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Daterange_rangepicker_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sGXsfl_40_fel_idx="0001" ;
      private string edtavSdtemployeeweekreports__mon_formatted_Columnheaderclass ;
      private string edtavSdtemployeeweekreports__mon_formatted_Internalname ;
      private string edtavSdtemployeeweekreports__tue_formatted_Columnheaderclass ;
      private string edtavSdtemployeeweekreports__tue_formatted_Internalname ;
      private string edtavSdtemployeeweekreports__wed_formatted_Columnheaderclass ;
      private string edtavSdtemployeeweekreports__wed_formatted_Internalname ;
      private string edtavSdtemployeeweekreports__thu_formatted_Columnheaderclass ;
      private string edtavSdtemployeeweekreports__thu_formatted_Internalname ;
      private string edtavSdtemployeeweekreports__fri_formatted_Columnheaderclass ;
      private string edtavSdtemployeeweekreports__fri_formatted_Internalname ;
      private string edtavSdtemployeeweekreports__total_formatted_Columnheaderclass ;
      private string edtavSdtemployeeweekreports__total_formatted_Internalname ;
      private string edtavSdtemployeeweekreports__mon_formatted_Columnclass ;
      private string edtavSdtemployeeweekreports__tue_formatted_Columnclass ;
      private string edtavSdtemployeeweekreports__wed_formatted_Columnclass ;
      private string edtavSdtemployeeweekreports__thu_formatted_Columnclass ;
      private string edtavSdtemployeeweekreports__fri_formatted_Columnclass ;
      private string chkavSdtemployeeweekreports__mon_isholiday_Columnclass ;
      private string edtavSdtemployeeweekreports__leave_formatted_Columnclass ;
      private string edtavSdtemployeeweekreports__total_formatted_Columnclass ;
      private string A103ProjectName ;
      private string A158CompanyLocationName ;
      private string GXt_char5 ;
      private string edtavSdtemployeeweekreports__employeename_Internalname ;
      private string edtavSdtemployeeweekreports__mon_Internalname ;
      private string edtavSdtemployeeweekreports__tue_Internalname ;
      private string edtavSdtemployeeweekreports__wed_Internalname ;
      private string edtavSdtemployeeweekreports__thu_Internalname ;
      private string edtavSdtemployeeweekreports__fri_Internalname ;
      private string edtavSdtemployeeweekreports__sat_Internalname ;
      private string edtavSdtemployeeweekreports__sun_Internalname ;
      private string edtavSdtemployeeweekreports__leave_Internalname ;
      private string edtavSdtemployeeweekreports__expected_Internalname ;
      private string edtavSdtemployeeweekreports__total_Internalname ;
      private string edtavSdtemployeeweekreports__sat_formatted_Internalname ;
      private string edtavSdtemployeeweekreports__sun_formatted_Internalname ;
      private string chkavSdtemployeeweekreports__mon_isholiday_Internalname ;
      private string edtavSdtemployeeweekreports__leave_formatted_Internalname ;
      private string edtavSdtemployeeweekreports__expected_formatted_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSdtemployeeweekreports__employeename_Jsonclick ;
      private string edtavSdtemployeeweekreports__mon_Jsonclick ;
      private string edtavSdtemployeeweekreports__tue_Jsonclick ;
      private string edtavSdtemployeeweekreports__wed_Jsonclick ;
      private string edtavSdtemployeeweekreports__thu_Jsonclick ;
      private string edtavSdtemployeeweekreports__fri_Jsonclick ;
      private string edtavSdtemployeeweekreports__sat_Jsonclick ;
      private string edtavSdtemployeeweekreports__sun_Jsonclick ;
      private string edtavSdtemployeeweekreports__leave_Jsonclick ;
      private string edtavSdtemployeeweekreports__expected_Jsonclick ;
      private string edtavSdtemployeeweekreports__total_Jsonclick ;
      private string edtavSdtemployeeweekreports__mon_formatted_Jsonclick ;
      private string edtavSdtemployeeweekreports__tue_formatted_Jsonclick ;
      private string edtavSdtemployeeweekreports__wed_formatted_Jsonclick ;
      private string edtavSdtemployeeweekreports__thu_formatted_Jsonclick ;
      private string edtavSdtemployeeweekreports__fri_formatted_Jsonclick ;
      private string edtavSdtemployeeweekreports__sat_formatted_Jsonclick ;
      private string edtavSdtemployeeweekreports__sun_formatted_Jsonclick ;
      private string GXCCtl ;
      private string edtavSdtemployeeweekreports__leave_formatted_Jsonclick ;
      private string edtavSdtemployeeweekreports__expected_formatted_Jsonclick ;
      private string edtavSdtemployeeweekreports__total_formatted_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV20DateRange_To ;
      private DateTime AV17DateRange ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Combo_companylocationid_Enabled ;
      private bool Combo_companylocationid_Allowmultipleselection ;
      private bool Combo_companylocationid_Includeonlyselectedoption ;
      private bool Combo_companylocationid_Emptyitem ;
      private bool Combo_projectid_Allowmultipleselection ;
      private bool Combo_projectid_Includeonlyselectedoption ;
      private bool Combo_projectid_Emptyitem ;
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
      private bool AV56IsProjectManager ;
      private bool GXt_boolean2 ;
      private bool n162ProjectManagerId ;
      private bool gx_refresh_fired ;
      private bool gx_BV40 ;
      private string AV29GridAppliedFilters ;
      private string AV19DateRange_RangeText ;
      private IGxSession AV44Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucCombo_companylocationid ;
      private GXUserControl ucCombo_projectid ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucUsercontrol1 ;
      private GXUserControl ucDaterange_rangepicker ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavSdtemployeeweekreports__mon_isholiday ;
      private GxSimpleCollection<long> AV12CompanyLocationId ;
      private GxSimpleCollection<long> AV58EmployeeIds ;
      private GxSimpleCollection<long> AV59ProjectId ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> AV41SDTEmployeeWeekReports ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV21DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV13CompanyLocationId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV60ProjectId_Data ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions AV18DateRange_RangePickerOptions ;
      private IDataStoreProvider pr_default ;
      private long[] H004W2_A100CompanyId ;
      private long[] H004W2_A106EmployeeId ;
      private long[] H004W2_A157CompanyLocationId ;
      private long[] H004W3_A162ProjectManagerId ;
      private bool[] H004W3_n162ProjectManagerId ;
      private long[] H004W3_A102ProjectId ;
      private GxSimpleCollection<long> AV57ProjectIds ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions AV39Options ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV55WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV32GridState ;
      private long[] H004W4_A102ProjectId ;
      private string[] H004W4_A103ProjectName ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV11Combo_DataItem ;
      private long[] H004W5_A157CompanyLocationId ;
      private string[] H004W5_A158CompanyLocationName ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions4 ;
      private GXBaseCollection<SdtSDTEmployeeWeekReport> GXt_objcol_SdtSDTEmployeeWeekReport7 ;
      private GxSimpleCollection<long> GXt_objcol_int6 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class employeeweekreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004W3( IGxContext context ,
                                             bool AV56IsProjectManager ,
                                             long A162ProjectManagerId ,
                                             long AV5LoggedInEmployeeId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[1];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT ProjectManagerId, ProjectId FROM Project";
         if ( AV56IsProjectManager )
         {
            AddWhere(sWhereString, "(ProjectManagerId = :AV5LoggedInEmployeeId)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProjectId";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H004W4( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV57ProjectIds )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT ProjectId, ProjectName FROM Project";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV57ProjectIds, "ProjectId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProjectName";
         GXv_Object10[0] = scmdbuf;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H004W5( IGxContext context ,
                                             long AV23EmployeeCompanyLocationId ,
                                             long A157CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[1];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation";
         if ( ! (0==AV23EmployeeCompanyLocationId) )
         {
            AddWhere(sWhereString, "(CompanyLocationId = :AV23EmployeeCompanyLocationId)");
         }
         else
         {
            GXv_int12[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY CompanyLocationName";
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
               case 1 :
                     return conditional_H004W3(context, (bool)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] );
               case 2 :
                     return conditional_H004W4(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
               case 3 :
                     return conditional_H004W5(context, (long)dynConstraints[0] , (long)dynConstraints[1] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004W2;
          prmH004W2 = new Object[] {
          new ParDef("AV5LoggedInEmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH004W3;
          prmH004W3 = new Object[] {
          new ParDef("AV5LoggedInEmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH004W4;
          prmH004W4 = new Object[] {
          };
          Object[] prmH004W5;
          prmH004W5 = new Object[] {
          new ParDef("AV23EmployeeCompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004W2", "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T1.EmployeeId = :AV5LoggedInEmployeeId ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004W2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H004W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004W3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004W4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004W4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004W5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004W5,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
