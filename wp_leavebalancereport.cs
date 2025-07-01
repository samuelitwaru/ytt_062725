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
   public class wp_leavebalancereport : GXDataArea
   {
      public wp_leavebalancereport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_leavebalancereport( IGxContext context )
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
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
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
         AV60Pgmname = GetPar( "Pgmname");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV14SDT_EmployeeBalanceActions);
         AV38Year = (short)(Math.Round(NumberUtil.Val( GetPar( "Year"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV60Pgmname, AV14SDT_EmployeeBalanceActions, AV38Year) ;
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
            return "wp_leavebalancereport_Execute" ;
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
         PA5E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5E2( ) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_leavebalancereport.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vYEAR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV38Year), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WP_LeaveBalanceReport");
         forbiddenHiddens.Add("Year", context.localUtil.Format( (decimal)(AV38Year), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wp_leavebalancereport:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdt_employeebalanceactions", AV14SDT_EmployeeBalanceActions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdt_employeebalanceactions", AV14SDT_EmployeeBalanceActions);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_43), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID_DATA", AV40EmployeeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID_DATA", AV40EmployeeId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV29GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_EMPLOYEEBALANCEACTIONS", AV14SDT_EmployeeBalanceActions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_EMPLOYEEBALANCEACTIONS", AV14SDT_EmployeeBalanceActions);
         }
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "VACATIONSETDATE", context.localUtil.DToC( A186VacationSetDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "COMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "VACATIONSETDESCRIPTION", A189VacationSetDescription);
         GxWebStd.gx_hidden_field( context, "VACATIONSETDAYS", StringUtil.LTrim( StringUtil.NToC( A179VacationSetDays, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEVACTIONDAYS", StringUtil.LTrim( StringUtil.NToC( A146EmployeeVactionDays, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "LEAVEREQUESTSTATUS", StringUtil.RTrim( A132LeaveRequestStatus));
         GxWebStd.gx_hidden_field( context, "LEAVETYPEVACATIONLEAVE", StringUtil.RTrim( A144LeaveTypeVacationLeave));
         GxWebStd.gx_hidden_field( context, "LEAVETYPELOGGINGWORKHOURS", StringUtil.RTrim( A145LeaveTypeLoggingWorkHours));
         GxWebStd.gx_hidden_field( context, "LEAVEREQUESTSTARTDATE", context.localUtil.DToC( A129LeaveRequestStartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "LEAVEREQUESTENDDATE", context.localUtil.DToC( A130LeaveRequestEndDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "LEAVEREQUESTDURATION", StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "LEAVEREQUESTDESCRIPTION", A133LeaveRequestDescription);
         GxWebStd.gx_boolean_hidden_field( context, "HOLIDAYISACTIVE", A139HolidayIsActive);
         GxWebStd.gx_hidden_field( context, "HOLIDAYSTARTDATE", context.localUtil.DToC( A115HolidayStartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "HOLIDAYENDDATE", context.localUtil.DToC( A116HolidayEndDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "HOLIDAYNAME", StringUtil.RTrim( A114HolidayName));
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEVACATIONDAYSSETDATE", context.localUtil.DToC( AV48EmployeeVacationDaysSetDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Cls", StringUtil.RTrim( Combo_employeeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_set", StringUtil.RTrim( Combo_employeeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Emptyitem", StringUtil.BoolToStr( Combo_employeeid_Emptyitem));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERDELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_userdelete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERDELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_userdelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERDELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_userdelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERDELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_userdelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERDELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_userdelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERDELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_userdelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERDELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_userdelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, "SETVACATIONDAYSBTN_MODAL_Width", StringUtil.RTrim( Setvacationdaysbtn_modal_Width));
         GxWebStd.gx_hidden_field( context, "SETVACATIONDAYSBTN_MODAL_Title", StringUtil.RTrim( Setvacationdaysbtn_modal_Title));
         GxWebStd.gx_hidden_field( context, "SETVACATIONDAYSBTN_MODAL_Confirmtype", StringUtil.RTrim( Setvacationdaysbtn_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "SETVACATIONDAYSBTN_MODAL_Bodytype", StringUtil.RTrim( Setvacationdaysbtn_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_userdelete_Result));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_userdelete_Result));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
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
            WE5E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5E2( ) ;
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
         return formatLink("wp_leavebalancereport.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_LeaveBalanceReport" ;
      }

      public override string GetPgmdesc( )
      {
         return "Leave Balance Report" ;
      }

      protected void WB5E0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop ExtendedComboCell", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedemployeeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_employeeid_Internalname, "Employee", "", "", lblTextblockcombo_employeeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_LeaveBalanceReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_employeeid.SetProperty("Caption", Combo_employeeid_Caption);
            ucCombo_employeeid.SetProperty("Cls", Combo_employeeid_Cls);
            ucCombo_employeeid.SetProperty("EmptyItem", Combo_employeeid_Emptyitem);
            ucCombo_employeeid.SetProperty("DropDownOptionsData", AV40EmployeeId_Data);
            ucCombo_employeeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_employeeid_Internalname, "COMBO_EMPLOYEEIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableyear_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockyear_Internalname, "Year", "", "", lblTextblockyear_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_LeaveBalanceReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavYear_Internalname, "Year", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavYear_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38Year), 4, 0, ".", "")), StringUtil.LTrim( ((edtavYear_Enabled!=0) ? context.localUtil.Format( (decimal)(AV38Year), "ZZZ9") : context.localUtil.Format( (decimal)(AV38Year), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavYear_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavYear_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_LeaveBalanceReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DscTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableemployeebalance_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockemployeebalance_Internalname, "Employee Balance", "", "", lblTextblockemployeebalance_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_LeaveBalanceReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmployeebalance_Internalname, "Employee Balance", "col-sm-3 AttributeDateLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV37EmployeeBalance, 4, 1, ".", "")), StringUtil.LTrim( ((edtavEmployeebalance_Enabled!=0) ? context.localUtil.Format( AV37EmployeeBalance, "Z9.9") : context.localUtil.Format( AV37EmployeeBalance, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployeebalance_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavEmployeebalance_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_LeaveBalanceReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsetvacationdaysbtn_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(43), 2, 0)+","+"null"+");", "Set Vacation Days", bttBtnsetvacationdaysbtn_Jsonclick, 5, "Set Vacation Days", "", StyleString, ClassString, bttBtnsetvacationdaysbtn_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOSETVACATIONDAYSBTN\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_LeaveBalanceReport.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            StartGridControl43( ) ;
         }
         if ( wbEnd == 43 )
         {
            wbEnd = 0;
            nRC_GXsfl_43 = (int)(nGXsfl_43_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV49GXV1 = nGXsfl_43_idx;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV27GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV28GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV29GridAppliedFilters);
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_43_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployeeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39EmployeeId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39EmployeeId), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployeeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmployeeid_Visible, 1, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_LeaveBalanceReport.htm");
            wb_table1_60_5E2( true) ;
         }
         else
         {
            wb_table1_60_5E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_60_5E2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_65_5E2( true) ;
         }
         else
         {
            wb_table2_65_5E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_65_5E2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0072"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0072"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_43_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0072"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
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
         }
         if ( wbEnd == 43 )
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
                  AV49GXV1 = nGXsfl_43_idx;
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

      protected void START5E2( )
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
         Form.Meta.addItem("description", "Leave Balance Report", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5E0( ) ;
      }

      protected void WS5E2( )
      {
         START5E2( ) ;
         EVT5E2( ) ;
      }

      protected void EVT5E2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_EMPLOYEEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_employeeid.Onoptionclicked */
                              E115E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E125E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E135E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERDELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_userdelete.Close */
                              E145E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SETVACATIONDAYSBTN_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Setvacationdaysbtn_modal.Close */
                              E155E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSETVACATIONDAYSBTN'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoSetVacationDaysBtn' */
                              E165E2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) )
                           {
                              nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
                              SubsflControlProps_432( ) ;
                              AV49GXV1 = (int)(nGXsfl_43_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV14SDT_EmployeeBalanceActions.Count >= AV49GXV1 ) && ( AV49GXV1 > 0 ) )
                              {
                                 AV14SDT_EmployeeBalanceActions.CurrentItem = ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1));
                                 AV31Delete = cgiGet( edtavDelete_Internalname);
                                 AssignAttri("", false, edtavDelete_Internalname, AV31Delete);
                                 AV30Update = cgiGet( edtavUpdate_Internalname);
                                 AssignAttri("", false, edtavUpdate_Internalname, AV30Update);
                                 AV47UserDelete = cgiGet( edtavUserdelete_Internalname);
                                 AssignAttri("", false, edtavUserdelete_Internalname, AV47UserDelete);
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
                                    E175E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E185E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E195E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUPDATE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E205E2 ();
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
                        if ( nCmpId == 72 )
                        {
                           OldWwpaux_wc = cgiGet( "W0072");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0072", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5E2( )
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

      protected void PA5E2( )
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
               GX_FocusControl = edtavYear_Internalname;
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
         SubsflControlProps_432( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            sendrow_432( ) ;
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV60Pgmname ,
                                       GXBaseCollection<SdtSDT_EmployeeBalanceAction> AV14SDT_EmployeeBalanceActions ,
                                       short AV38Year )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WP_LeaveBalanceReport");
         forbiddenHiddens.Add("Year", context.localUtil.Format( (decimal)(AV38Year), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wp_leavebalancereport:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
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
         RF5E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV60Pgmname = "WP_LeaveBalanceReport";
         edtavYear_Enabled = 0;
         AssignProp("", false, edtavYear_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavYear_Enabled), 5, 0), true);
         edtavEmployeebalance_Enabled = 0;
         AssignProp("", false, edtavEmployeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployeebalance_Enabled), 5, 0), true);
         edtavDelete_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavUserdelete_Enabled = 0;
         edtavSdt_employeebalanceactions__type_Enabled = 0;
         edtavSdt_employeebalanceactions__description_Enabled = 0;
         edtavSdt_employeebalanceactions__startdate_Enabled = 0;
         edtavSdt_employeebalanceactions__enddate_Enabled = 0;
         edtavSdt_employeebalanceactions__durationinhours_Enabled = 0;
         edtavSdt_employeebalanceactions__durationindays_Enabled = 0;
      }

      protected void RF5E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 43;
         /* Execute user event: Refresh */
         E185E2 ();
         nGXsfl_43_idx = 1;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         bGXsfl_43_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_432( ) ;
            /* Execute user event: Grid.Load */
            E195E2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_43_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E195E2 ();
            }
            wbEnd = 43;
            WB5E0( ) ;
         }
         bGXsfl_43_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5E2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
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
         return AV14SDT_EmployeeBalanceActions.Count ;
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
            gxgrGrid_refresh( subGrid_Rows, AV60Pgmname, AV14SDT_EmployeeBalanceActions, AV38Year) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV60Pgmname, AV14SDT_EmployeeBalanceActions, AV38Year) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV60Pgmname, AV14SDT_EmployeeBalanceActions, AV38Year) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV60Pgmname, AV14SDT_EmployeeBalanceActions, AV38Year) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV60Pgmname, AV14SDT_EmployeeBalanceActions, AV38Year) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV60Pgmname = "WP_LeaveBalanceReport";
         edtavYear_Enabled = 0;
         AssignProp("", false, edtavYear_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavYear_Enabled), 5, 0), true);
         edtavEmployeebalance_Enabled = 0;
         AssignProp("", false, edtavEmployeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployeebalance_Enabled), 5, 0), true);
         edtavDelete_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavUserdelete_Enabled = 0;
         edtavSdt_employeebalanceactions__type_Enabled = 0;
         edtavSdt_employeebalanceactions__description_Enabled = 0;
         edtavSdt_employeebalanceactions__startdate_Enabled = 0;
         edtavSdt_employeebalanceactions__enddate_Enabled = 0;
         edtavSdt_employeebalanceactions__durationinhours_Enabled = 0;
         edtavSdt_employeebalanceactions__durationindays_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E175E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdt_employeebalanceactions"), AV14SDT_EmployeeBalanceActions);
            ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEEID_DATA"), AV40EmployeeId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_EMPLOYEEBALANCEACTIONS"), AV14SDT_EmployeeBalanceActions);
            /* Read saved values. */
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), ".", ","), 18, MidpointRounding.ToEven));
            AV27GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV28GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV29GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            Gx_mode = cgiGet( "vMODE");
            AV48EmployeeVacationDaysSetDate = context.localUtil.CToD( cgiGet( "vEMPLOYEEVACATIONDAYSSETDATE"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Combo_employeeid_Cls = cgiGet( "COMBO_EMPLOYEEID_Cls");
            Combo_employeeid_Selectedvalue_set = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_set");
            Combo_employeeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Emptyitem"));
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
            Dvelop_confirmpanel_userdelete_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERDELETE_Title");
            Dvelop_confirmpanel_userdelete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERDELETE_Confirmationtext");
            Dvelop_confirmpanel_userdelete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERDELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_userdelete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERDELETE_Nobuttoncaption");
            Dvelop_confirmpanel_userdelete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERDELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_userdelete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERDELETE_Yesbuttonposition");
            Dvelop_confirmpanel_userdelete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERDELETE_Confirmtype");
            Setvacationdaysbtn_modal_Width = cgiGet( "SETVACATIONDAYSBTN_MODAL_Width");
            Setvacationdaysbtn_modal_Title = cgiGet( "SETVACATIONDAYSBTN_MODAL_Title");
            Setvacationdaysbtn_modal_Confirmtype = cgiGet( "SETVACATIONDAYSBTN_MODAL_Confirmtype");
            Setvacationdaysbtn_modal_Bodytype = cgiGet( "SETVACATIONDAYSBTN_MODAL_Bodytype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_userdelete_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERDELETE_Result");
            Combo_employeeid_Selectedvalue_get = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_get");
            nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_43_fel_idx = 0;
            while ( nGXsfl_43_fel_idx < nRC_GXsfl_43 )
            {
               nGXsfl_43_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_fel_idx+1);
               sGXsfl_43_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_432( ) ;
               AV49GXV1 = (int)(nGXsfl_43_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV14SDT_EmployeeBalanceActions.Count >= AV49GXV1 ) && ( AV49GXV1 > 0 ) )
               {
                  AV14SDT_EmployeeBalanceActions.CurrentItem = ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1));
                  AV31Delete = cgiGet( edtavDelete_Internalname);
                  AV30Update = cgiGet( edtavUpdate_Internalname);
                  AV47UserDelete = cgiGet( edtavUserdelete_Internalname);
               }
            }
            if ( nGXsfl_43_fel_idx == 0 )
            {
               nGXsfl_43_idx = 1;
               sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
               SubsflControlProps_432( ) ;
            }
            nGXsfl_43_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavYear_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavYear_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vYEAR");
               GX_FocusControl = edtavYear_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV38Year = 0;
               AssignAttri("", false, "AV38Year", StringUtil.LTrimStr( (decimal)(AV38Year), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vYEAR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV38Year), "ZZZ9"), context));
            }
            else
            {
               AV38Year = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavYear_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV38Year", StringUtil.LTrimStr( (decimal)(AV38Year), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vYEAR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV38Year), "ZZZ9"), context));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployeebalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployeebalance_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vEMPLOYEEBALANCE");
               GX_FocusControl = edtavEmployeebalance_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV37EmployeeBalance = 0;
               AssignAttri("", false, "AV37EmployeeBalance", StringUtil.LTrimStr( AV37EmployeeBalance, 4, 1));
            }
            else
            {
               AV37EmployeeBalance = context.localUtil.CToN( cgiGet( edtavEmployeebalance_Internalname), ".", ",");
               AssignAttri("", false, "AV37EmployeeBalance", StringUtil.LTrimStr( AV37EmployeeBalance, 4, 1));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployeeid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployeeid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vEMPLOYEEID");
               GX_FocusControl = edtavEmployeeid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39EmployeeId = 0;
               AssignAttri("", false, "AV39EmployeeId", StringUtil.LTrimStr( (decimal)(AV39EmployeeId), 4, 0));
            }
            else
            {
               AV39EmployeeId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmployeeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39EmployeeId", StringUtil.LTrimStr( (decimal)(AV39EmployeeId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WP_LeaveBalanceReport");
            AV38Year = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavYear_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV38Year", StringUtil.LTrimStr( (decimal)(AV38Year), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vYEAR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV38Year), "ZZZ9"), context));
            forbiddenHiddens.Add("Year", context.localUtil.Format( (decimal)(AV38Year), "ZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wp_leavebalancereport:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
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
         E175E2 ();
         if (returnInSub) return;
      }

      protected void E175E2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV38Year = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV38Year", StringUtil.LTrimStr( (decimal)(AV38Year), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vYEAR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV38Year), "ZZZ9"), context));
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AV57Udparg1 = new getloggedinemployeeid(context).executeUdp( );
            /* Using cursor H005E2 */
            pr_default.execute(0, new Object[] {AV57Udparg1});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A162ProjectManagerId = H005E2_A162ProjectManagerId[0];
               n162ProjectManagerId = H005E2_n162ProjectManagerId[0];
               A102ProjectId = H005E2_A102ProjectId[0];
               AV42ProjectManagerProjectIds.Add(A102ProjectId, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            GXt_objcol_int1 = AV43EmployeeIdsToShow;
            new getemployeeidsbyproject(context ).execute(  AV42ProjectManagerProjectIds, out  GXt_objcol_int1) ;
            AV43EmployeeIdsToShow = GXt_objcol_int1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AV59Udparg2 = new getloggedinusercompanyid(context).executeUdp( );
            /* Using cursor H005E3 */
            pr_default.execute(1, new Object[] {AV59Udparg2});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A100CompanyId = H005E3_A100CompanyId[0];
               A106EmployeeId = H005E3_A106EmployeeId[0];
               AV43EmployeeIdsToShow.Add(A106EmployeeId, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( AV43EmployeeIdsToShow.Count > 0 )
         {
            AV39EmployeeId = (short)(AV43EmployeeIdsToShow.GetNumeric(1));
            AssignAttri("", false, "AV39EmployeeId", StringUtil.LTrimStr( (decimal)(AV39EmployeeId), 4, 0));
         }
         edtavEmployeeid_Visible = 0;
         AssignProp("", false, edtavEmployeeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmployeeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S112 ();
         if (returnInSub) return;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Form.Caption = "WP_Leave Balance Report";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         /* Execute user subroutine: 'GETDATA' */
         S132 ();
         if (returnInSub) return;
      }

      protected void E185E2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S162 ();
         if (returnInSub) return;
         AV27GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV27GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV27GridCurrentPage), 10, 0));
         AV28GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV28GridPageCount", StringUtil.LTrimStr( (decimal)(AV28GridPageCount), 10, 0));
         GXt_char2 = AV29GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV60Pgmname, out  GXt_char2) ;
         AV29GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV29GridAppliedFilters", AV29GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E125E2( )
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
            AV26PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV26PageToGo) ;
         }
      }

      protected void E135E2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E195E2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV14SDT_EmployeeBalanceActions.Count )
         {
            AV14SDT_EmployeeBalanceActions.CurrentItem = ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1));
            AV31Delete = "<i class=\"fa fa-times\"></i>";
            AssignAttri("", false, edtavDelete_Internalname, AV31Delete);
            AV30Update = "<i class=\"fa fa-pen\"></i>";
            AssignAttri("", false, edtavUpdate_Internalname, AV30Update);
            if ( StringUtil.StrCmp(((SdtSDT_EmployeeBalanceAction)(AV14SDT_EmployeeBalanceActions.CurrentItem)).gxTpr_Type, "SET") == 0 )
            {
               edtavUpdate_Class = "Attribute";
            }
            else
            {
               edtavUpdate_Class = "Invisible";
            }
            AV47UserDelete = "<i class=\"fas fa-xmark\"></i>";
            AssignAttri("", false, edtavUserdelete_Internalname, AV47UserDelete);
            if ( StringUtil.StrCmp(((SdtSDT_EmployeeBalanceAction)(AV14SDT_EmployeeBalanceActions.CurrentItem)).gxTpr_Type, "SET") == 0 )
            {
               edtavUserdelete_Class = "Attribute";
            }
            else
            {
               edtavUserdelete_Class = "Invisible";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 43;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_432( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_43_Refreshing )
            {
               DoAjaxLoad(43, GridRow);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E145E2( )
      {
         AV49GXV1 = (int)(nGXsfl_43_idx+GRID_nFirstRecordOnPage);
         if ( ( AV49GXV1 > 0 ) && ( AV14SDT_EmployeeBalanceActions.Count >= AV49GXV1 ) )
         {
            AV14SDT_EmployeeBalanceActions.CurrentItem = ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1));
         }
         /* Dvelop_confirmpanel_userdelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_userdelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO USERDELETE' */
            S172 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_EmployeeBalanceActions", AV14SDT_EmployeeBalanceActions);
         nGXsfl_43_bak_idx = nGXsfl_43_idx;
         gxgrGrid_refresh( subGrid_Rows, AV60Pgmname, AV14SDT_EmployeeBalanceActions, AV38Year) ;
         nGXsfl_43_idx = nGXsfl_43_bak_idx;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
      }

      protected void E165E2( )
      {
         /* 'DoSetVacationDaysBtn' Routine */
         returnInSub = false;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV48EmployeeVacationDaysSetDate = DateTimeUtil.Today( context);
         AssignAttri("", false, "AV48EmployeeVacationDaysSetDate", context.localUtil.Format(AV48EmployeeVacationDaysSetDate, "99/99/99"));
         this.executeUsercontrolMethod("", false, "SETVACATIONDAYSBTN_MODALContainer", "Confirm", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E155E2( )
      {
         /* Setvacationdaysbtn_modal_Close Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETDATA' */
         S132 ();
         if (returnInSub) return;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         if ( gx_BV43 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_EmployeeBalanceActions", AV14SDT_EmployeeBalanceActions);
            nGXsfl_43_bak_idx = nGXsfl_43_idx;
            gxgrGrid_refresh( subGrid_Rows, AV60Pgmname, AV14SDT_EmployeeBalanceActions, AV38Year) ;
            nGXsfl_43_idx = nGXsfl_43_bak_idx;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
      }

      protected void E115E2( )
      {
         /* Combo_employeeid_Onoptionclicked Routine */
         returnInSub = false;
         AV39EmployeeId = (short)(Math.Round(NumberUtil.Val( Combo_employeeid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV39EmployeeId", StringUtil.LTrimStr( (decimal)(AV39EmployeeId), 4, 0));
         /* Execute user subroutine: 'GETDATA' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV43 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_EmployeeBalanceActions", AV14SDT_EmployeeBalanceActions);
            nGXsfl_43_bak_idx = nGXsfl_43_idx;
            gxgrGrid_refresh( subGrid_Rows, AV60Pgmname, AV14SDT_EmployeeBalanceActions, AV38Year) ;
            nGXsfl_43_idx = nGXsfl_43_bak_idx;
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
      }

      protected void S162( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( new userhasrole(context).executeUdp(  "Manager") ) || ( new userhasrole(context).executeUdp(  "Project Manager") ) ) )
         {
            bttBtnsetvacationdaysbtn_Visible = 0;
            AssignProp("", false, bttBtnsetvacationdaysbtn_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsetvacationdaysbtn_Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'DO USERDELETE' Routine */
         returnInSub = false;
         /* Using cursor H005E4 */
         pr_default.execute(2, new Object[] {AV39EmployeeId, ((SdtSDT_EmployeeBalanceAction)(AV14SDT_EmployeeBalanceActions.CurrentItem)).gxTpr_Startdate});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A186VacationSetDate = H005E4_A186VacationSetDate[0];
            A106EmployeeId = H005E4_A106EmployeeId[0];
            AV45BC_Employee.Load(AV39EmployeeId);
            AV45BC_Employee.gxTpr_Vacationset.RemoveByKey(A186VacationSetDate) ;
            AV45BC_Employee.Save();
            if ( AV45BC_Employee.Success() )
            {
               AV45BC_Employee.Save();
               context.CommitDataStores("wp_leavebalancereport",pr_default);
               GX_msglist.addItem("Vacation Set Days Deleted");
               /* Execute user subroutine: 'GETDATA' */
               S132 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
            }
            else
            {
               AV64GXV9 = 1;
               AV63GXV8 = AV45BC_Employee.GetMessages();
               while ( AV64GXV9 <= AV63GXV8.Count )
               {
                  AV46Message = ((GeneXus.Utils.SdtMessages_Message)AV63GXV8.Item(AV64GXV9));
                  GX_msglist.addItem(AV46Message.gxTpr_Description);
                  AV64GXV9 = (int)(AV64GXV9+1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get(AV60Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV60Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV21Session.Get(AV60Pgmname+"GridState"), null, "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV21Session.Get(AV60Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOEMPLOYEEID' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV43EmployeeIdsToShow ,
                                              AV43EmployeeIdsToShow.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor H005E5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A106EmployeeId = H005E5_A106EmployeeId[0];
            A148EmployeeName = H005E5_A148EmployeeName[0];
            AV41Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV41Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
            AV41Combo_DataItem.gxTpr_Title = A148EmployeeName;
            AV40EmployeeId_Data.Add(AV41Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         Combo_employeeid_Selectedvalue_set = ((0==AV39EmployeeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV39EmployeeId), 4, 0)));
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
      }

      protected void E205E2( )
      {
         AV49GXV1 = (int)(nGXsfl_43_idx+GRID_nFirstRecordOnPage);
         if ( ( AV49GXV1 > 0 ) && ( AV14SDT_EmployeeBalanceActions.Count >= AV49GXV1 ) )
         {
            AV14SDT_EmployeeBalanceActions.CurrentItem = ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1));
         }
         /* Update_Click Routine */
         returnInSub = false;
         Gx_mode = "UPD";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV48EmployeeVacationDaysSetDate = ((SdtSDT_EmployeeBalanceAction)(AV14SDT_EmployeeBalanceActions.CurrentItem)).gxTpr_Startdate;
         AssignAttri("", false, "AV48EmployeeVacationDaysSetDate", context.localUtil.Format(AV48EmployeeVacationDaysSetDate, "99/99/99"));
         this.executeUsercontrolMethod("", false, "SETVACATIONDAYSBTN_MODALContainer", "Confirm", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'GETDATA' Routine */
         returnInSub = false;
         AV14SDT_EmployeeBalanceActions.Clear();
         gx_BV43 = true;
         /* Using cursor H005E6 */
         pr_default.execute(4, new Object[] {AV39EmployeeId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A106EmployeeId = H005E6_A106EmployeeId[0];
            A146EmployeeVactionDays = H005E6_A146EmployeeVactionDays[0];
            A100CompanyId = H005E6_A100CompanyId[0];
            AV36CompanyId = A100CompanyId;
            AssignAttri("", false, "AV36CompanyId", StringUtil.LTrimStr( (decimal)(AV36CompanyId), 10, 0));
            GXt_decimal3 = AV37EmployeeBalance;
            new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
            AV37EmployeeBalance = GXt_decimal3;
            AssignAttri("", false, "AV37EmployeeBalance", StringUtil.LTrimStr( AV37EmployeeBalance, 4, 1));
            /* Using cursor H005E7 */
            pr_default.execute(5, new Object[] {A106EmployeeId, AV38Year});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A186VacationSetDate = H005E7_A186VacationSetDate[0];
               A189VacationSetDescription = H005E7_A189VacationSetDescription[0];
               n189VacationSetDescription = H005E7_n189VacationSetDescription[0];
               A179VacationSetDays = H005E7_A179VacationSetDays[0];
               AV34SDT_EmployeeBalanceAction = new SdtSDT_EmployeeBalanceAction(context);
               AV34SDT_EmployeeBalanceAction.gxTpr_Startdate = A186VacationSetDate;
               AV34SDT_EmployeeBalanceAction.gxTpr_Enddate = A186VacationSetDate;
               AV34SDT_EmployeeBalanceAction.gxTpr_Type = "SET";
               AV34SDT_EmployeeBalanceAction.gxTpr_Description = A189VacationSetDescription;
               AV34SDT_EmployeeBalanceAction.gxTpr_Durationindays = A179VacationSetDays;
               AV34SDT_EmployeeBalanceAction.gxTpr_Durationinhours = (decimal)(A179VacationSetDays*8);
               AV35EmployeeVactionDays = A146EmployeeVactionDays;
               AV14SDT_EmployeeBalanceActions.Add(AV34SDT_EmployeeBalanceAction, 0);
               gx_BV43 = true;
               pr_default.readNext(5);
            }
            pr_default.close(5);
            /* Using cursor H005E8 */
            pr_default.execute(6, new Object[] {A106EmployeeId, AV38Year});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A124LeaveTypeId = H005E8_A124LeaveTypeId[0];
               A130LeaveRequestEndDate = H005E8_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = H005E8_A129LeaveRequestStartDate[0];
               A145LeaveTypeLoggingWorkHours = H005E8_A145LeaveTypeLoggingWorkHours[0];
               A144LeaveTypeVacationLeave = H005E8_A144LeaveTypeVacationLeave[0];
               A132LeaveRequestStatus = H005E8_A132LeaveRequestStatus[0];
               A131LeaveRequestDuration = H005E8_A131LeaveRequestDuration[0];
               A133LeaveRequestDescription = H005E8_A133LeaveRequestDescription[0];
               A145LeaveTypeLoggingWorkHours = H005E8_A145LeaveTypeLoggingWorkHours[0];
               A144LeaveTypeVacationLeave = H005E8_A144LeaveTypeVacationLeave[0];
               AV34SDT_EmployeeBalanceAction = new SdtSDT_EmployeeBalanceAction(context);
               AV34SDT_EmployeeBalanceAction.gxTpr_Startdate = A129LeaveRequestStartDate;
               AV34SDT_EmployeeBalanceAction.gxTpr_Enddate = A130LeaveRequestEndDate;
               AV34SDT_EmployeeBalanceAction.gxTpr_Type = "LEAVE";
               AV34SDT_EmployeeBalanceAction.gxTpr_Durationindays = (decimal)(A131LeaveRequestDuration*-1);
               AV34SDT_EmployeeBalanceAction.gxTpr_Durationinhours = (decimal)(A131LeaveRequestDuration*8*-1);
               AV34SDT_EmployeeBalanceAction.gxTpr_Description = A133LeaveRequestDescription;
               AV14SDT_EmployeeBalanceActions.Add(AV34SDT_EmployeeBalanceAction, 0);
               gx_BV43 = true;
               /* Using cursor H005E9 */
               pr_default.execute(7, new Object[] {AV36CompanyId, A129LeaveRequestStartDate, A130LeaveRequestEndDate});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A115HolidayStartDate = H005E9_A115HolidayStartDate[0];
                  A139HolidayIsActive = H005E9_A139HolidayIsActive[0];
                  A100CompanyId = H005E9_A100CompanyId[0];
                  A116HolidayEndDate = H005E9_A116HolidayEndDate[0];
                  n116HolidayEndDate = H005E9_n116HolidayEndDate[0];
                  A114HolidayName = H005E9_A114HolidayName[0];
                  AV34SDT_EmployeeBalanceAction = new SdtSDT_EmployeeBalanceAction(context);
                  AV34SDT_EmployeeBalanceAction.gxTpr_Startdate = A115HolidayStartDate;
                  AV34SDT_EmployeeBalanceAction.gxTpr_Enddate = A116HolidayEndDate;
                  AV34SDT_EmployeeBalanceAction.gxTpr_Type = "HOLIDAY (MUTATION)";
                  AV34SDT_EmployeeBalanceAction.gxTpr_Durationindays = (decimal)(1);
                  AV34SDT_EmployeeBalanceAction.gxTpr_Durationinhours = (decimal)(8);
                  AV34SDT_EmployeeBalanceAction.gxTpr_Description = A114HolidayName;
                  AV14SDT_EmployeeBalanceActions.Add(AV34SDT_EmployeeBalanceAction, 0);
                  gx_BV43 = true;
                  pr_default.readNext(7);
               }
               pr_default.close(7);
               pr_default.readNext(6);
            }
            pr_default.close(6);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         AV14SDT_EmployeeBalanceActions.Sort("StartDate");
         gx_BV43 = true;
      }

      protected void wb_table2_65_5E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablesetvacationdaysbtn_modal_Internalname, tblTablesetvacationdaysbtn_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucSetvacationdaysbtn_modal.SetProperty("Width", Setvacationdaysbtn_modal_Width);
            ucSetvacationdaysbtn_modal.SetProperty("Title", Setvacationdaysbtn_modal_Title);
            ucSetvacationdaysbtn_modal.SetProperty("ConfirmType", Setvacationdaysbtn_modal_Confirmtype);
            ucSetvacationdaysbtn_modal.SetProperty("BodyType", Setvacationdaysbtn_modal_Bodytype);
            ucSetvacationdaysbtn_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Setvacationdaysbtn_modal_Internalname, "SETVACATIONDAYSBTN_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"SETVACATIONDAYSBTN_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_65_5E2e( true) ;
         }
         else
         {
            wb_table2_65_5E2e( false) ;
         }
      }

      protected void wb_table1_60_5E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_userdelete_Internalname, tblTabledvelop_confirmpanel_userdelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_userdelete.SetProperty("Title", Dvelop_confirmpanel_userdelete_Title);
            ucDvelop_confirmpanel_userdelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_userdelete_Confirmationtext);
            ucDvelop_confirmpanel_userdelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_userdelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_userdelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_userdelete_Nobuttoncaption);
            ucDvelop_confirmpanel_userdelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_userdelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_userdelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_userdelete_Yesbuttonposition);
            ucDvelop_confirmpanel_userdelete.SetProperty("ConfirmType", Dvelop_confirmpanel_userdelete_Confirmtype);
            ucDvelop_confirmpanel_userdelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_userdelete_Internalname, "DVELOP_CONFIRMPANEL_USERDELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_USERDELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_60_5E2e( true) ;
         }
         else
         {
            wb_table1_60_5E2e( false) ;
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
         PA5E2( ) ;
         WS5E2( ) ;
         WE5E2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025711934195", true, true);
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
         context.AddJavascriptSource("wp_leavebalancereport.js", "?2025711934196", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_432( )
      {
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_43_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_idx;
         edtavUserdelete_Internalname = "vUSERDELETE_"+sGXsfl_43_idx;
         edtavSdt_employeebalanceactions__type_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__TYPE_"+sGXsfl_43_idx;
         edtavSdt_employeebalanceactions__description_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DESCRIPTION_"+sGXsfl_43_idx;
         edtavSdt_employeebalanceactions__startdate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__STARTDATE_"+sGXsfl_43_idx;
         edtavSdt_employeebalanceactions__enddate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__ENDDATE_"+sGXsfl_43_idx;
         edtavSdt_employeebalanceactions__durationinhours_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINHOURS_"+sGXsfl_43_idx;
         edtavSdt_employeebalanceactions__durationindays_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINDAYS_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_432( )
      {
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_43_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_43_fel_idx;
         edtavUserdelete_Internalname = "vUSERDELETE_"+sGXsfl_43_fel_idx;
         edtavSdt_employeebalanceactions__type_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__TYPE_"+sGXsfl_43_fel_idx;
         edtavSdt_employeebalanceactions__description_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DESCRIPTION_"+sGXsfl_43_fel_idx;
         edtavSdt_employeebalanceactions__startdate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__STARTDATE_"+sGXsfl_43_fel_idx;
         edtavSdt_employeebalanceactions__enddate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__ENDDATE_"+sGXsfl_43_fel_idx;
         edtavSdt_employeebalanceactions__durationinhours_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINHOURS_"+sGXsfl_43_fel_idx;
         edtavSdt_employeebalanceactions__durationindays_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINDAYS_"+sGXsfl_43_fel_idx;
      }

      protected void sendrow_432( )
      {
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_432( ) ;
         WB5E0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_43_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_43_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV31Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs hidden-sm hidden-md hidden-lg",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = edtavUpdate_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV30Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"","'"+""+"'"+",false,"+"'"+"EVUPDATE.CLICK."+sGXsfl_43_idx+"'",(string)"",(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)5,(string)edtavUpdate_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = edtavUserdelete_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUserdelete_Internalname,StringUtil.RTrim( AV47UserDelete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+"e215e2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUserdelete_Jsonclick,(short)7,(string)edtavUserdelete_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUserdelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__type_Internalname,StringUtil.RTrim( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Type),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__type_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__type_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__description_Internalname,((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Description,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__description_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__description_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__startdate_Internalname,context.localUtil.Format(((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Startdate, "99/99/99"),context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Startdate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__startdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__startdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__enddate_Internalname,context.localUtil.Format(((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Enddate, "99/99/99"),context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Enddate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__enddate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__enddate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__durationinhours_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Durationinhours, 5, 1, ".", "")),StringUtil.LTrim( ((edtavSdt_employeebalanceactions__durationinhours_Enabled!=0) ? context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Durationinhours, "ZZ9.9") : context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Durationinhours, "ZZ9.9"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,51);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__durationinhours_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__durationinhours_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_43_idx + "',43)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__durationindays_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Durationindays, 4, 1, ".", "")),StringUtil.LTrim( ((edtavSdt_employeebalanceactions__durationindays_Enabled!=0) ? context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Durationindays, "Z9.9") : context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV49GXV1)).gxTpr_Durationindays, "Z9.9"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,52);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__durationindays_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__durationindays_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes5E2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_43_idx = ((subGrid_Islastpage==1)&&(nGXsfl_43_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_432( ) ;
         }
         /* End function sendrow_432 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl43( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"43\">") ;
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
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUpdate_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUserdelete_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Start Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "End Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Duration (Hours)") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Duration (Days)") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV31Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV30Update)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUpdate_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV47UserDelete)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUserdelete_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUserdelete_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_employeebalanceactions__type_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_employeebalanceactions__description_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_employeebalanceactions__startdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_employeebalanceactions__enddate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_employeebalanceactions__durationinhours_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_employeebalanceactions__durationindays_Enabled), 5, 0, ".", "")));
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
         lblTextblockcombo_employeeid_Internalname = "TEXTBLOCKCOMBO_EMPLOYEEID";
         Combo_employeeid_Internalname = "COMBO_EMPLOYEEID";
         divTablesplittedemployeeid_Internalname = "TABLESPLITTEDEMPLOYEEID";
         lblTextblockyear_Internalname = "TEXTBLOCKYEAR";
         edtavYear_Internalname = "vYEAR";
         divUnnamedtableyear_Internalname = "UNNAMEDTABLEYEAR";
         lblTextblockemployeebalance_Internalname = "TEXTBLOCKEMPLOYEEBALANCE";
         edtavEmployeebalance_Internalname = "vEMPLOYEEBALANCE";
         divUnnamedtableemployeebalance_Internalname = "UNNAMEDTABLEEMPLOYEEBALANCE";
         bttBtnsetvacationdaysbtn_Internalname = "BTNSETVACATIONDAYSBTN";
         divTableheader_Internalname = "TABLEHEADER";
         edtavDelete_Internalname = "vDELETE";
         edtavUpdate_Internalname = "vUPDATE";
         edtavUserdelete_Internalname = "vUSERDELETE";
         edtavSdt_employeebalanceactions__type_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__TYPE";
         edtavSdt_employeebalanceactions__description_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DESCRIPTION";
         edtavSdt_employeebalanceactions__startdate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__STARTDATE";
         edtavSdt_employeebalanceactions__enddate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__ENDDATE";
         edtavSdt_employeebalanceactions__durationinhours_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINHOURS";
         edtavSdt_employeebalanceactions__durationindays_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINDAYS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         edtavEmployeeid_Internalname = "vEMPLOYEEID";
         Dvelop_confirmpanel_userdelete_Internalname = "DVELOP_CONFIRMPANEL_USERDELETE";
         tblTabledvelop_confirmpanel_userdelete_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERDELETE";
         Setvacationdaysbtn_modal_Internalname = "SETVACATIONDAYSBTN_MODAL";
         tblTablesetvacationdaysbtn_modal_Internalname = "TABLESETVACATIONDAYSBTN_MODAL";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         edtavSdt_employeebalanceactions__durationindays_Jsonclick = "";
         edtavSdt_employeebalanceactions__durationindays_Enabled = 0;
         edtavSdt_employeebalanceactions__durationinhours_Jsonclick = "";
         edtavSdt_employeebalanceactions__durationinhours_Enabled = 0;
         edtavSdt_employeebalanceactions__enddate_Jsonclick = "";
         edtavSdt_employeebalanceactions__enddate_Enabled = 0;
         edtavSdt_employeebalanceactions__startdate_Jsonclick = "";
         edtavSdt_employeebalanceactions__startdate_Enabled = 0;
         edtavSdt_employeebalanceactions__description_Jsonclick = "";
         edtavSdt_employeebalanceactions__description_Enabled = 0;
         edtavSdt_employeebalanceactions__type_Jsonclick = "";
         edtavSdt_employeebalanceactions__type_Enabled = 0;
         edtavUserdelete_Jsonclick = "";
         edtavUserdelete_Class = "Attribute";
         edtavUserdelete_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Class = "Attribute";
         edtavUpdate_Enabled = 1;
         edtavDelete_Jsonclick = "";
         edtavDelete_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSdt_employeebalanceactions__durationindays_Enabled = -1;
         edtavSdt_employeebalanceactions__durationinhours_Enabled = -1;
         edtavSdt_employeebalanceactions__enddate_Enabled = -1;
         edtavSdt_employeebalanceactions__startdate_Enabled = -1;
         edtavSdt_employeebalanceactions__description_Enabled = -1;
         edtavSdt_employeebalanceactions__type_Enabled = -1;
         edtavEmployeeid_Jsonclick = "";
         edtavEmployeeid_Visible = 1;
         bttBtnsetvacationdaysbtn_Visible = 1;
         edtavEmployeebalance_Jsonclick = "";
         edtavEmployeebalance_Enabled = 1;
         edtavYear_Jsonclick = "";
         edtavYear_Enabled = 1;
         Setvacationdaysbtn_modal_Bodytype = "WebComponent";
         Setvacationdaysbtn_modal_Confirmtype = "";
         Setvacationdaysbtn_modal_Title = "Set Employee Vacation Days";
         Setvacationdaysbtn_modal_Width = "600";
         Dvelop_confirmpanel_userdelete_Confirmtype = "1";
         Dvelop_confirmpanel_userdelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_userdelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_userdelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_userdelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_userdelete_Confirmationtext = "Are sure you want to delete Vacation Days Set";
         Dvelop_confirmpanel_userdelete_Title = "Comfirm Delete";
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
         Combo_employeeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_employeeid_Cls = "ExtendedCombo Attribute";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Leave Balance Report";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV38Year","fld":"vYEAR","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV29GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"ctrl":"BTNSETVACATIONDAYSBTN","prop":"Visible"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E125E2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"AV38Year","fld":"vYEAR","pic":"ZZZ9","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E135E2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"AV38Year","fld":"vYEAR","pic":"ZZZ9","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E195E2","iparms":[{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV31Delete","fld":"vDELETE"},{"av":"AV30Update","fld":"vUPDATE"},{"av":"edtavUpdate_Class","ctrl":"vUPDATE","prop":"Class"},{"av":"AV47UserDelete","fld":"vUSERDELETE"},{"av":"edtavUserdelete_Class","ctrl":"vUSERDELETE","prop":"Class"}]}""");
         setEventMetadata("VUSERDELETE.CLICK","""{"handler":"E215E2","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERDELETE.CLOSE","""{"handler":"E145E2","iparms":[{"av":"Dvelop_confirmpanel_userdelete_Result","ctrl":"DVELOP_CONFIRMPANEL_USERDELETE","prop":"Result"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZ9"},{"av":"A186VacationSetDate","fld":"VACATIONSETDATE"},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"AV38Year","fld":"vYEAR","pic":"ZZZ9","hsh":true},{"av":"A189VacationSetDescription","fld":"VACATIONSETDESCRIPTION"},{"av":"A179VacationSetDays","fld":"VACATIONSETDAYS","pic":"Z9.9"},{"av":"A146EmployeeVactionDays","fld":"EMPLOYEEVACTIONDAYS","pic":"Z9.9"},{"av":"A132LeaveRequestStatus","fld":"LEAVEREQUESTSTATUS"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"},{"av":"A129LeaveRequestStartDate","fld":"LEAVEREQUESTSTARTDATE"},{"av":"A130LeaveRequestEndDate","fld":"LEAVEREQUESTENDDATE"},{"av":"A131LeaveRequestDuration","fld":"LEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"A133LeaveRequestDescription","fld":"LEAVEREQUESTDESCRIPTION"},{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"},{"av":"A115HolidayStartDate","fld":"HOLIDAYSTARTDATE"},{"av":"A116HolidayEndDate","fld":"HOLIDAYENDDATE"},{"av":"A114HolidayName","fld":"HOLIDAYNAME"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERDELETE.CLOSE",""","oparms":[{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"AV36CompanyId","fld":"vCOMPANYID","pic":"ZZZZZZZZZ9"},{"av":"AV37EmployeeBalance","fld":"vEMPLOYEEBALANCE","pic":"Z9.9"}]}""");
         setEventMetadata("'DOSETVACATIONDAYSBTN'","""{"handler":"E165E2","iparms":[]""");
         setEventMetadata("'DOSETVACATIONDAYSBTN'",""","oparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV48EmployeeVacationDaysSetDate","fld":"vEMPLOYEEVACATIONDAYSSETDATE"}]}""");
         setEventMetadata("SETVACATIONDAYSBTN_MODAL.CLOSE","""{"handler":"E155E2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"AV38Year","fld":"vYEAR","pic":"ZZZ9","hsh":true},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZ9"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A186VacationSetDate","fld":"VACATIONSETDATE"},{"av":"A189VacationSetDescription","fld":"VACATIONSETDESCRIPTION"},{"av":"A179VacationSetDays","fld":"VACATIONSETDAYS","pic":"Z9.9"},{"av":"A146EmployeeVactionDays","fld":"EMPLOYEEVACTIONDAYS","pic":"Z9.9"},{"av":"A132LeaveRequestStatus","fld":"LEAVEREQUESTSTATUS"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"},{"av":"A129LeaveRequestStartDate","fld":"LEAVEREQUESTSTARTDATE"},{"av":"A130LeaveRequestEndDate","fld":"LEAVEREQUESTENDDATE"},{"av":"A131LeaveRequestDuration","fld":"LEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"A133LeaveRequestDescription","fld":"LEAVEREQUESTDESCRIPTION"},{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"},{"av":"A115HolidayStartDate","fld":"HOLIDAYSTARTDATE"},{"av":"A116HolidayEndDate","fld":"HOLIDAYENDDATE"},{"av":"A114HolidayName","fld":"HOLIDAYNAME"}]""");
         setEventMetadata("SETVACATIONDAYSBTN_MODAL.CLOSE",""","oparms":[{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"AV36CompanyId","fld":"vCOMPANYID","pic":"ZZZZZZZZZ9"},{"av":"AV37EmployeeBalance","fld":"vEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV29GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"ctrl":"BTNSETVACATIONDAYSBTN","prop":"Visible"}]}""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED","""{"handler":"E115E2","iparms":[{"av":"Combo_employeeid_Selectedvalue_get","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_get"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZ9"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A186VacationSetDate","fld":"VACATIONSETDATE"},{"av":"AV38Year","fld":"vYEAR","pic":"ZZZ9","hsh":true},{"av":"A189VacationSetDescription","fld":"VACATIONSETDESCRIPTION"},{"av":"A179VacationSetDays","fld":"VACATIONSETDAYS","pic":"Z9.9"},{"av":"A146EmployeeVactionDays","fld":"EMPLOYEEVACTIONDAYS","pic":"Z9.9"},{"av":"A132LeaveRequestStatus","fld":"LEAVEREQUESTSTATUS"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"},{"av":"A129LeaveRequestStartDate","fld":"LEAVEREQUESTSTARTDATE"},{"av":"A130LeaveRequestEndDate","fld":"LEAVEREQUESTENDDATE"},{"av":"A131LeaveRequestDuration","fld":"LEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"A133LeaveRequestDescription","fld":"LEAVEREQUESTDESCRIPTION"},{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"},{"av":"A115HolidayStartDate","fld":"HOLIDAYSTARTDATE"},{"av":"A116HolidayEndDate","fld":"HOLIDAYENDDATE"},{"av":"A114HolidayName","fld":"HOLIDAYNAME"},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true}]""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV39EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZ9"},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43},{"av":"AV36CompanyId","fld":"vCOMPANYID","pic":"ZZZZZZZZZ9"},{"av":"AV37EmployeeBalance","fld":"vEMPLOYEEBALANCE","pic":"Z9.9"}]}""");
         setEventMetadata("VUPDATE.CLICK","""{"handler":"E205E2","iparms":[{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":43},{"av":"nGXsfl_43_idx","ctrl":"GRID","prop":"GridCurrRow","grid":43},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_43","ctrl":"GRID","prop":"GridRC","grid":43}]""");
         setEventMetadata("VUPDATE.CLICK",""","oparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV48EmployeeVacationDaysSetDate","fld":"vEMPLOYEEVACATIONDAYSSETDATE"}]}""");
         setEventMetadata("VALIDV_EMPLOYEEID","""{"handler":"Validv_Employeeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv7","iparms":[]}""");
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
         Dvelop_confirmpanel_userdelete_Result = "";
         Combo_employeeid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV60Pgmname = "";
         AV14SDT_EmployeeBalanceActions = new GXBaseCollection<SdtSDT_EmployeeBalanceAction>( context, "SDT_EmployeeBalanceAction", "YTT_version4");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         AV40EmployeeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV29GridAppliedFilters = "";
         A186VacationSetDate = DateTime.MinValue;
         A189VacationSetDescription = "";
         A132LeaveRequestStatus = "";
         A144LeaveTypeVacationLeave = "";
         A145LeaveTypeLoggingWorkHours = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A133LeaveRequestDescription = "";
         A115HolidayStartDate = DateTime.MinValue;
         A116HolidayEndDate = DateTime.MinValue;
         A114HolidayName = "";
         AV48EmployeeVacationDaysSetDate = DateTime.MinValue;
         Gx_mode = "";
         Combo_employeeid_Selectedvalue_set = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblockcombo_employeeid_Jsonclick = "";
         ucCombo_employeeid = new GXUserControl();
         Combo_employeeid_Caption = "";
         lblTextblockyear_Jsonclick = "";
         TempTags = "";
         lblTextblockemployeebalance_Jsonclick = "";
         bttBtnsetvacationdaysbtn_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV31Delete = "";
         AV30Update = "";
         AV47UserDelete = "";
         hsh = "";
         H005E2_A162ProjectManagerId = new long[1] ;
         H005E2_n162ProjectManagerId = new bool[] {false} ;
         H005E2_A102ProjectId = new long[1] ;
         AV42ProjectManagerProjectIds = new GxSimpleCollection<long>();
         AV43EmployeeIdsToShow = new GxSimpleCollection<long>();
         GXt_objcol_int1 = new GxSimpleCollection<long>();
         H005E3_A100CompanyId = new long[1] ;
         H005E3_A106EmployeeId = new long[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         H005E4_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         H005E4_A106EmployeeId = new long[1] ;
         AV45BC_Employee = new SdtEmployee(context);
         AV63GXV8 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV46Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV21Session = context.GetSession();
         AV11GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         H005E5_A106EmployeeId = new long[1] ;
         H005E5_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         AV41Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H005E6_A106EmployeeId = new long[1] ;
         H005E6_A146EmployeeVactionDays = new decimal[1] ;
         H005E6_A100CompanyId = new long[1] ;
         H005E7_A106EmployeeId = new long[1] ;
         H005E7_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         H005E7_A189VacationSetDescription = new string[] {""} ;
         H005E7_n189VacationSetDescription = new bool[] {false} ;
         H005E7_A179VacationSetDays = new decimal[1] ;
         AV34SDT_EmployeeBalanceAction = new SdtSDT_EmployeeBalanceAction(context);
         H005E8_A127LeaveRequestId = new long[1] ;
         H005E8_A124LeaveTypeId = new long[1] ;
         H005E8_A106EmployeeId = new long[1] ;
         H005E8_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         H005E8_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         H005E8_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         H005E8_A144LeaveTypeVacationLeave = new string[] {""} ;
         H005E8_A132LeaveRequestStatus = new string[] {""} ;
         H005E8_A131LeaveRequestDuration = new decimal[1] ;
         H005E8_A133LeaveRequestDescription = new string[] {""} ;
         H005E9_A113HolidayId = new long[1] ;
         H005E9_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         H005E9_A139HolidayIsActive = new bool[] {false} ;
         H005E9_A100CompanyId = new long[1] ;
         H005E9_A116HolidayEndDate = new DateTime[] {DateTime.MinValue} ;
         H005E9_n116HolidayEndDate = new bool[] {false} ;
         H005E9_A114HolidayName = new string[] {""} ;
         ucSetvacationdaysbtn_modal = new GXUserControl();
         ucDvelop_confirmpanel_userdelete = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_leavebalancereport__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_leavebalancereport__default(),
            new Object[][] {
                new Object[] {
               H005E2_A162ProjectManagerId, H005E2_n162ProjectManagerId, H005E2_A102ProjectId
               }
               , new Object[] {
               H005E3_A100CompanyId, H005E3_A106EmployeeId
               }
               , new Object[] {
               H005E4_A186VacationSetDate, H005E4_A106EmployeeId
               }
               , new Object[] {
               H005E5_A106EmployeeId, H005E5_A148EmployeeName
               }
               , new Object[] {
               H005E6_A106EmployeeId, H005E6_A146EmployeeVactionDays, H005E6_A100CompanyId
               }
               , new Object[] {
               H005E7_A106EmployeeId, H005E7_A186VacationSetDate, H005E7_A189VacationSetDescription, H005E7_n189VacationSetDescription, H005E7_A179VacationSetDays
               }
               , new Object[] {
               H005E8_A127LeaveRequestId, H005E8_A124LeaveTypeId, H005E8_A106EmployeeId, H005E8_A130LeaveRequestEndDate, H005E8_A129LeaveRequestStartDate, H005E8_A145LeaveTypeLoggingWorkHours, H005E8_A144LeaveTypeVacationLeave, H005E8_A132LeaveRequestStatus, H005E8_A131LeaveRequestDuration, H005E8_A133LeaveRequestDescription
               }
               , new Object[] {
               H005E9_A113HolidayId, H005E9_A115HolidayStartDate, H005E9_A139HolidayIsActive, H005E9_A100CompanyId, H005E9_A116HolidayEndDate, H005E9_n116HolidayEndDate, H005E9_A114HolidayName
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV60Pgmname = "WP_LeaveBalanceReport";
         /* GeneXus formulas. */
         AV60Pgmname = "WP_LeaveBalanceReport";
         edtavYear_Enabled = 0;
         edtavEmployeebalance_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavUserdelete_Enabled = 0;
         edtavSdt_employeebalanceactions__type_Enabled = 0;
         edtavSdt_employeebalanceactions__description_Enabled = 0;
         edtavSdt_employeebalanceactions__startdate_Enabled = 0;
         edtavSdt_employeebalanceactions__enddate_Enabled = 0;
         edtavSdt_employeebalanceactions__durationinhours_Enabled = 0;
         edtavSdt_employeebalanceactions__durationindays_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
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
      private short AV38Year ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV39EmployeeId ;
      private short nCmpId ;
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
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavYear_Enabled ;
      private int edtavEmployeebalance_Enabled ;
      private int bttBtnsetvacationdaysbtn_Visible ;
      private int AV49GXV1 ;
      private int edtavEmployeeid_Visible ;
      private int subGrid_Islastpage ;
      private int edtavDelete_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavUserdelete_Enabled ;
      private int edtavSdt_employeebalanceactions__type_Enabled ;
      private int edtavSdt_employeebalanceactions__description_Enabled ;
      private int edtavSdt_employeebalanceactions__startdate_Enabled ;
      private int edtavSdt_employeebalanceactions__enddate_Enabled ;
      private int edtavSdt_employeebalanceactions__durationinhours_Enabled ;
      private int edtavSdt_employeebalanceactions__durationindays_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_43_fel_idx=1 ;
      private int AV26PageToGo ;
      private int nGXsfl_43_bak_idx=1 ;
      private int AV64GXV9 ;
      private int AV43EmployeeIdsToShow_Count ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV27GridCurrentPage ;
      private long AV28GridPageCount ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long AV57Udparg1 ;
      private long A162ProjectManagerId ;
      private long A102ProjectId ;
      private long AV59Udparg2 ;
      private long AV36CompanyId ;
      private long A124LeaveTypeId ;
      private decimal A179VacationSetDays ;
      private decimal A146EmployeeVactionDays ;
      private decimal A131LeaveRequestDuration ;
      private decimal AV37EmployeeBalance ;
      private decimal GXt_decimal3 ;
      private decimal AV35EmployeeVactionDays ;
      private string Gridpaginationbar_Selectedpage ;
      private string Dvelop_confirmpanel_userdelete_Result ;
      private string Combo_employeeid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_43_idx="0001" ;
      private string AV60Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A132LeaveRequestStatus ;
      private string A144LeaveTypeVacationLeave ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A114HolidayName ;
      private string Gx_mode ;
      private string Combo_employeeid_Cls ;
      private string Combo_employeeid_Selectedvalue_set ;
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
      private string Dvelop_confirmpanel_userdelete_Title ;
      private string Dvelop_confirmpanel_userdelete_Confirmationtext ;
      private string Dvelop_confirmpanel_userdelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_userdelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_userdelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_userdelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_userdelete_Confirmtype ;
      private string Setvacationdaysbtn_modal_Width ;
      private string Setvacationdaysbtn_modal_Title ;
      private string Setvacationdaysbtn_modal_Confirmtype ;
      private string Setvacationdaysbtn_modal_Bodytype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string divTablesplittedemployeeid_Internalname ;
      private string lblTextblockcombo_employeeid_Internalname ;
      private string lblTextblockcombo_employeeid_Jsonclick ;
      private string Combo_employeeid_Caption ;
      private string Combo_employeeid_Internalname ;
      private string divUnnamedtableyear_Internalname ;
      private string lblTextblockyear_Internalname ;
      private string lblTextblockyear_Jsonclick ;
      private string edtavYear_Internalname ;
      private string TempTags ;
      private string edtavYear_Jsonclick ;
      private string divUnnamedtableemployeebalance_Internalname ;
      private string lblTextblockemployeebalance_Internalname ;
      private string lblTextblockemployeebalance_Jsonclick ;
      private string edtavEmployeebalance_Internalname ;
      private string edtavEmployeebalance_Jsonclick ;
      private string bttBtnsetvacationdaysbtn_Internalname ;
      private string bttBtnsetvacationdaysbtn_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavEmployeeid_Internalname ;
      private string edtavEmployeeid_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV31Delete ;
      private string edtavDelete_Internalname ;
      private string AV30Update ;
      private string edtavUpdate_Internalname ;
      private string AV47UserDelete ;
      private string edtavUserdelete_Internalname ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string hsh ;
      private string GXt_char2 ;
      private string edtavUpdate_Class ;
      private string edtavUserdelete_Class ;
      private string A148EmployeeName ;
      private string tblTablesetvacationdaysbtn_modal_Internalname ;
      private string Setvacationdaysbtn_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_userdelete_Internalname ;
      private string Dvelop_confirmpanel_userdelete_Internalname ;
      private string edtavSdt_employeebalanceactions__type_Internalname ;
      private string edtavSdt_employeebalanceactions__description_Internalname ;
      private string edtavSdt_employeebalanceactions__startdate_Internalname ;
      private string edtavSdt_employeebalanceactions__enddate_Internalname ;
      private string edtavSdt_employeebalanceactions__durationinhours_Internalname ;
      private string edtavSdt_employeebalanceactions__durationindays_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDelete_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavUserdelete_Jsonclick ;
      private string edtavSdt_employeebalanceactions__type_Jsonclick ;
      private string edtavSdt_employeebalanceactions__description_Jsonclick ;
      private string edtavSdt_employeebalanceactions__startdate_Jsonclick ;
      private string edtavSdt_employeebalanceactions__enddate_Jsonclick ;
      private string edtavSdt_employeebalanceactions__durationinhours_Jsonclick ;
      private string edtavSdt_employeebalanceactions__durationindays_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A186VacationSetDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A115HolidayStartDate ;
      private DateTime A116HolidayEndDate ;
      private DateTime AV48EmployeeVacationDaysSetDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A139HolidayIsActive ;
      private bool Combo_employeeid_Emptyitem ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n162ProjectManagerId ;
      private bool gx_refresh_fired ;
      private bool gx_BV43 ;
      private bool n189VacationSetDescription ;
      private bool n116HolidayEndDate ;
      private string AV29GridAppliedFilters ;
      private string A189VacationSetDescription ;
      private string A133LeaveRequestDescription ;
      private IGxSession AV21Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucCombo_employeeid ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucSetvacationdaysbtn_modal ;
      private GXUserControl ucDvelop_confirmpanel_userdelete ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_EmployeeBalanceAction> AV14SDT_EmployeeBalanceActions ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV40EmployeeId_Data ;
      private IDataStoreProvider pr_default ;
      private long[] H005E2_A162ProjectManagerId ;
      private bool[] H005E2_n162ProjectManagerId ;
      private long[] H005E2_A102ProjectId ;
      private GxSimpleCollection<long> AV42ProjectManagerProjectIds ;
      private GxSimpleCollection<long> AV43EmployeeIdsToShow ;
      private GxSimpleCollection<long> GXt_objcol_int1 ;
      private long[] H005E3_A100CompanyId ;
      private long[] H005E3_A106EmployeeId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private DateTime[] H005E4_A186VacationSetDate ;
      private long[] H005E4_A106EmployeeId ;
      private SdtEmployee AV45BC_Employee ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV63GXV8 ;
      private GeneXus.Utils.SdtMessages_Message AV46Message ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private long[] H005E5_A106EmployeeId ;
      private string[] H005E5_A148EmployeeName ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV41Combo_DataItem ;
      private long[] H005E6_A106EmployeeId ;
      private decimal[] H005E6_A146EmployeeVactionDays ;
      private long[] H005E6_A100CompanyId ;
      private long[] H005E7_A106EmployeeId ;
      private DateTime[] H005E7_A186VacationSetDate ;
      private string[] H005E7_A189VacationSetDescription ;
      private bool[] H005E7_n189VacationSetDescription ;
      private decimal[] H005E7_A179VacationSetDays ;
      private SdtSDT_EmployeeBalanceAction AV34SDT_EmployeeBalanceAction ;
      private long[] H005E8_A127LeaveRequestId ;
      private long[] H005E8_A124LeaveTypeId ;
      private long[] H005E8_A106EmployeeId ;
      private DateTime[] H005E8_A130LeaveRequestEndDate ;
      private DateTime[] H005E8_A129LeaveRequestStartDate ;
      private string[] H005E8_A145LeaveTypeLoggingWorkHours ;
      private string[] H005E8_A144LeaveTypeVacationLeave ;
      private string[] H005E8_A132LeaveRequestStatus ;
      private decimal[] H005E8_A131LeaveRequestDuration ;
      private string[] H005E8_A133LeaveRequestDescription ;
      private long[] H005E9_A113HolidayId ;
      private DateTime[] H005E9_A115HolidayStartDate ;
      private bool[] H005E9_A139HolidayIsActive ;
      private long[] H005E9_A100CompanyId ;
      private DateTime[] H005E9_A116HolidayEndDate ;
      private bool[] H005E9_n116HolidayEndDate ;
      private string[] H005E9_A114HolidayName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_leavebalancereport__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_leavebalancereport__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H005E5( IGxContext context ,
                                           long A106EmployeeId ,
                                           GxSimpleCollection<long> AV43EmployeeIdsToShow ,
                                           int AV43EmployeeIdsToShow_Count )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       Object[] GXv_Object4 = new Object[2];
       scmdbuf = "SELECT EmployeeId, EmployeeName FROM Employee";
       if ( AV43EmployeeIdsToShow_Count > 0 )
       {
          AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV43EmployeeIdsToShow, "EmployeeId IN (", ")")+")");
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY EmployeeName";
       GXv_Object4[0] = scmdbuf;
       return GXv_Object4 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 3 :
                   return conditional_H005E5(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
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
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH005E2;
        prmH005E2 = new Object[] {
        new ParDef("AV57Udparg1",GXType.Int64,10,0)
        };
        Object[] prmH005E3;
        prmH005E3 = new Object[] {
        new ParDef("AV59Udparg2",GXType.Int64,10,0)
        };
        Object[] prmH005E4;
        prmH005E4 = new Object[] {
        new ParDef("AV39EmployeeId",GXType.Int16,4,0) ,
        new ParDef("SdtSDTCurrentItem_1Startd",GXType.Date,8,0)
        };
        Object[] prmH005E6;
        prmH005E6 = new Object[] {
        new ParDef("AV39EmployeeId",GXType.Int16,4,0)
        };
        Object[] prmH005E7;
        prmH005E7 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("AV38Year",GXType.Int16,4,0)
        };
        Object[] prmH005E8;
        prmH005E8 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("AV38Year",GXType.Int16,4,0)
        };
        Object[] prmH005E9;
        prmH005E9 = new Object[] {
        new ParDef("AV36CompanyId",GXType.Int64,10,0) ,
        new ParDef("LeaveRequestStartDate",GXType.Date,8,0) ,
        new ParDef("LeaveRequestEndDate",GXType.Date,8,0)
        };
        Object[] prmH005E5;
        prmH005E5 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H005E2", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV57Udparg1 ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005E3", "SELECT CompanyId, EmployeeId FROM Employee WHERE CompanyId = :AV59Udparg2 ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E3,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005E4", "SELECT VacationSetDate, EmployeeId FROM EmployeeVacationSet WHERE EmployeeId = :AV39EmployeeId and VacationSetDate = :SdtSDTCurrentItem_1Startd ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E4,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("H005E5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005E6", "SELECT EmployeeId, EmployeeVactionDays, CompanyId FROM Employee WHERE EmployeeId = :AV39EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("H005E7", "SELECT EmployeeId, VacationSetDate, VacationSetDescription, VacationSetDays FROM EmployeeVacationSet WHERE (EmployeeId = :EmployeeId) AND (date_part('year', VacationSetDate) = :AV38Year) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005E8", "SELECT T1.LeaveRequestId, T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeLoggingWorkHours, T2.LeaveTypeVacationLeave, T1.LeaveRequestStatus, T1.LeaveRequestDuration, T1.LeaveRequestDescription FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :EmployeeId) AND (date_part('year', T1.LeaveRequestStartDate) = :AV38Year) AND (T1.LeaveRequestStatus = ( 'Approved')) AND (T2.LeaveTypeVacationLeave = ( 'Yes')) AND (T2.LeaveTypeLoggingWorkHours = ( 'No')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005E9", "SELECT HolidayId, HolidayStartDate, HolidayIsActive, CompanyId, HolidayEndDate, HolidayName FROM Holiday WHERE (CompanyId = :AV36CompanyId) AND (HolidayStartDate >= :LeaveRequestStartDate) AND (HolidayStartDate <= :LeaveRequestEndDate) AND (HolidayIsActive = TRUE) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005E9,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((long[]) buf[2])[0] = rslt.getLong(2);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 2 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 100);
              return;
     }
  }

}

}
