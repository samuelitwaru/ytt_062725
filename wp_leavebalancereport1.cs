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
   public class wp_leavebalancereport1 : GXDataArea
   {
      public wp_leavebalancereport1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_leavebalancereport1( IGxContext context )
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
         nRC_GXsfl_38 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
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
         AV56Pgmname = GetPar( "Pgmname");
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         AV35Year = (short)(Math.Round(NumberUtil.Val( GetPar( "Year"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV56Pgmname, Gx_date, AV35Year) ;
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
         PA5D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5D2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_leavebalancereport1.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vYEAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35Year), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vYEAR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV35Year), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_38), 8, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEVACATIONDAYSSETDATE", context.localUtil.DToC( A177EmployeeVacationDaysSetDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEVACTIONDAYS", StringUtil.LTrim( StringUtil.NToC( A146EmployeeVactionDays, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEBALANCE", StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "VACATIONSETDATE", context.localUtil.DToC( A186VacationSetDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vYEAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35Year), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vYEAR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV35Year), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "VACATIONSETDAYS", StringUtil.LTrim( StringUtil.NToC( A179VacationSetDays, 4, 1, ".", "")));
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_EMPLOYEEBALANCEACTIONS", AV14SDT_EmployeeBalanceActions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_EMPLOYEEBALANCEACTIONS", AV14SDT_EmployeeBalanceActions);
         }
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE5D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5D2( ) ;
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
         return formatLink("wp_leavebalancereport1.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_LeaveBalanceReport1" ;
      }

      public override string GetPgmdesc( )
      {
         return "WP_Leave Balance Report" ;
      }

      protected void WB5D0( )
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedemployeeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_employeeid_Internalname, "Employee", "", "", lblTextblockcombo_employeeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_LeaveBalanceReport1.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmployeebalance_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmployeebalance_Internalname, "Employee Balance", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'" + sGXsfl_38_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV44EmployeeBalance, 4, 1, ".", "")), StringUtil.LTrim( ((edtavEmployeebalance_Enabled!=0) ? context.localUtil.Format( AV44EmployeeBalance, "Z9.9") : context.localUtil.Format( AV44EmployeeBalance, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployeebalance_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmployeebalance_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_LeaveBalanceReport1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmployeevactiondays_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmployeevactiondays_Internalname, "SET", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_38_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployeevactiondays_Internalname, StringUtil.LTrim( StringUtil.NToC( AV42EmployeeVactionDays, 4, 1, ".", "")), StringUtil.LTrim( ((edtavEmployeevactiondays_Enabled!=0) ? context.localUtil.Format( AV42EmployeeVactionDays, "Z9.9") : context.localUtil.Format( AV42EmployeeVactionDays, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployeevactiondays_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmployeevactiondays_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_LeaveBalanceReport1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 CellMarginTop10 CellPaddingTop10", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsetbutton_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(38), 2, 0)+","+"null"+");", "SET", bttBtnsetbutton_Jsonclick, 5, "SET", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOSETBUTTON\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_LeaveBalanceReport1.htm");
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
               AV45GXV1 = nGXsfl_38_idx;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_38_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployeeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36EmployeeId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36EmployeeId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployeeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmployeeid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_LeaveBalanceReport1.htm");
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
                  AV45GXV1 = nGXsfl_38_idx;
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

      protected void START5D2( )
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
         Form.Meta.addItem("description", "WP_Leave Balance Report", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5D0( ) ;
      }

      protected void WS5D2( )
      {
         START5D2( ) ;
         EVT5D2( ) ;
      }

      protected void EVT5D2( )
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
                              E115D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E125D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E135D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSETBUTTON'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoSetButton' */
                              E145D2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
                              SubsflControlProps_382( ) ;
                              AV45GXV1 = (int)(nGXsfl_38_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV14SDT_EmployeeBalanceActions.Count >= AV45GXV1 ) && ( AV45GXV1 > 0 ) )
                              {
                                 AV14SDT_EmployeeBalanceActions.CurrentItem = ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1));
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
                                    E155D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E165D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E175D2 ();
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

      protected void WE5D2( )
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

      protected void PA5D2( )
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
               GX_FocusControl = edtavEmployeebalance_Internalname;
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
                                       string AV56Pgmname ,
                                       DateTime Gx_date ,
                                       short AV35Year )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5D2( ) ;
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
         RF5D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV56Pgmname = "WP_LeaveBalanceReport1";
         edtavEmployeebalance_Enabled = 0;
         AssignProp("", false, edtavEmployeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployeebalance_Enabled), 5, 0), true);
         edtavSdt_employeebalanceactions__startdate_Enabled = 0;
         edtavSdt_employeebalanceactions__enddate_Enabled = 0;
         edtavSdt_employeebalanceactions__type_Enabled = 0;
         edtavSdt_employeebalanceactions__description_Enabled = 0;
         edtavSdt_employeebalanceactions__durationinhours_Enabled = 0;
         edtavSdt_employeebalanceactions__durationindays_Enabled = 0;
      }

      protected void RF5D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 38;
         /* Execute user event: Refresh */
         E165D2 ();
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
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_382( ) ;
            /* Execute user event: Grid.Load */
            E175D2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_38_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               /* Execute user event: Grid.Load */
               E175D2 ();
            }
            wbEnd = 38;
            WB5D0( ) ;
         }
         bGXsfl_38_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5D2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV56Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV56Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vYEAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35Year), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vYEAR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV35Year), "ZZZ9"), context));
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
            gxgrGrid_refresh( subGrid_Rows, AV56Pgmname, Gx_date, AV35Year) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV56Pgmname, Gx_date, AV35Year) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV56Pgmname, Gx_date, AV35Year) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV56Pgmname, Gx_date, AV35Year) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV56Pgmname, Gx_date, AV35Year) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV56Pgmname = "WP_LeaveBalanceReport1";
         edtavEmployeebalance_Enabled = 0;
         AssignProp("", false, edtavEmployeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployeebalance_Enabled), 5, 0), true);
         edtavSdt_employeebalanceactions__startdate_Enabled = 0;
         edtavSdt_employeebalanceactions__enddate_Enabled = 0;
         edtavSdt_employeebalanceactions__type_Enabled = 0;
         edtavSdt_employeebalanceactions__description_Enabled = 0;
         edtavSdt_employeebalanceactions__durationinhours_Enabled = 0;
         edtavSdt_employeebalanceactions__durationindays_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E155D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdt_employeebalanceactions"), AV14SDT_EmployeeBalanceActions);
            ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEEID_DATA"), AV40EmployeeId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_EMPLOYEEBALANCEACTIONS"), AV14SDT_EmployeeBalanceActions);
            /* Read saved values. */
            nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), ".", ","), 18, MidpointRounding.ToEven));
            AV27GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV28GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV29GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Combo_employeeid_Selectedvalue_get = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_get");
            nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_38_fel_idx = 0;
            while ( nGXsfl_38_fel_idx < nRC_GXsfl_38 )
            {
               nGXsfl_38_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_38_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_fel_idx+1);
               sGXsfl_38_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_382( ) ;
               AV45GXV1 = (int)(nGXsfl_38_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV14SDT_EmployeeBalanceActions.Count >= AV45GXV1 ) && ( AV45GXV1 > 0 ) )
               {
                  AV14SDT_EmployeeBalanceActions.CurrentItem = ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1));
               }
            }
            if ( nGXsfl_38_fel_idx == 0 )
            {
               nGXsfl_38_idx = 1;
               sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
               SubsflControlProps_382( ) ;
            }
            nGXsfl_38_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployeebalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployeebalance_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vEMPLOYEEBALANCE");
               GX_FocusControl = edtavEmployeebalance_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44EmployeeBalance = 0;
               AssignAttri("", false, "AV44EmployeeBalance", StringUtil.LTrimStr( AV44EmployeeBalance, 4, 1));
            }
            else
            {
               AV44EmployeeBalance = context.localUtil.CToN( cgiGet( edtavEmployeebalance_Internalname), ".", ",");
               AssignAttri("", false, "AV44EmployeeBalance", StringUtil.LTrimStr( AV44EmployeeBalance, 4, 1));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployeevactiondays_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployeevactiondays_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vEMPLOYEEVACTIONDAYS");
               GX_FocusControl = edtavEmployeevactiondays_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV42EmployeeVactionDays = 0;
               AssignAttri("", false, "AV42EmployeeVactionDays", StringUtil.LTrimStr( AV42EmployeeVactionDays, 4, 1));
            }
            else
            {
               AV42EmployeeVactionDays = context.localUtil.CToN( cgiGet( edtavEmployeevactiondays_Internalname), ".", ",");
               AssignAttri("", false, "AV42EmployeeVactionDays", StringUtil.LTrimStr( AV42EmployeeVactionDays, 4, 1));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployeeid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployeeid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vEMPLOYEEID");
               GX_FocusControl = edtavEmployeeid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV36EmployeeId = 0;
               AssignAttri("", false, "AV36EmployeeId", StringUtil.LTrimStr( (decimal)(AV36EmployeeId), 10, 0));
            }
            else
            {
               AV36EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmployeeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV36EmployeeId", StringUtil.LTrimStr( (decimal)(AV36EmployeeId), 10, 0));
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
         E155D2 ();
         if (returnInSub) return;
      }

      protected void E155D2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV35Year = (short)(DateTimeUtil.Year( DateTimeUtil.Today( context)));
         AssignAttri("", false, "AV35Year", StringUtil.LTrimStr( (decimal)(AV35Year), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vYEAR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV35Year), "ZZZ9"), context));
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AV53Udparg1 = new getloggedinemployeeid(context).executeUdp( );
            /* Using cursor H005D2 */
            pr_default.execute(0, new Object[] {AV53Udparg1});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A162ProjectManagerId = H005D2_A162ProjectManagerId[0];
               n162ProjectManagerId = H005D2_n162ProjectManagerId[0];
               A102ProjectId = H005D2_A102ProjectId[0];
               AV39ProjectManagerProjectIds.Add(A102ProjectId, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            GXt_objcol_int1 = AV38EmployeeIdsToShow;
            new getemployeeidsbyproject(context ).execute(  AV39ProjectManagerProjectIds, out  GXt_objcol_int1) ;
            AV38EmployeeIdsToShow = GXt_objcol_int1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            AV55Udparg2 = new getloggedinusercompanyid(context).executeUdp( );
            /* Using cursor H005D3 */
            pr_default.execute(1, new Object[] {AV55Udparg2});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A100CompanyId = H005D3_A100CompanyId[0];
               A106EmployeeId = H005D3_A106EmployeeId[0];
               AV38EmployeeIdsToShow.Add(A106EmployeeId, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( AV38EmployeeIdsToShow.Count > 0 )
         {
            AV36EmployeeId = (long)(AV38EmployeeIdsToShow.GetNumeric(1));
            AssignAttri("", false, "AV36EmployeeId", StringUtil.LTrimStr( (decimal)(AV36EmployeeId), 10, 0));
         }
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         edtavEmployeeid_Visible = 0;
         AssignProp("", false, edtavEmployeeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmployeeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S122 ();
         if (returnInSub) return;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Form.Caption = "WP_Leave Balance Report";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if (returnInSub) return;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E165D2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSDT' */
         S152 ();
         if (returnInSub) return;
         AV27GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV27GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV27GridCurrentPage), 10, 0));
         AV28GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV28GridPageCount", StringUtil.LTrimStr( (decimal)(AV28GridPageCount), 10, 0));
         GXt_char2 = AV29GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV56Pgmname, out  GXt_char2) ;
         AV29GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV29GridAppliedFilters", AV29GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E125D2( )
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

      protected void E135D2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E175D2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV14SDT_EmployeeBalanceActions.Count )
         {
            AV14SDT_EmployeeBalanceActions.CurrentItem = ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1));
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
            if ( isFullAjaxMode( ) && ! bGXsfl_38_Refreshing )
            {
               DoAjaxLoad(38, GridRow);
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
      }

      protected void E145D2( )
      {
         /* 'DoSetButton' Routine */
         returnInSub = false;
         AV43BC_Employee.Load(AV36EmployeeId);
         AV43BC_Employee.gxTpr_Employeevactiondays = AV42EmployeeVactionDays;
         AV43BC_Employee.gxTpr_Employeevacationdayssetdate = Gx_date;
      }

      protected void E115D2( )
      {
         /* Combo_employeeid_Onoptionclicked Routine */
         returnInSub = false;
         AV36EmployeeId = (long)(Math.Round(NumberUtil.Val( Combo_employeeid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV36EmployeeId", StringUtil.LTrimStr( (decimal)(AV36EmployeeId), 10, 0));
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV38 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDT_EmployeeBalanceActions", AV14SDT_EmployeeBalanceActions);
            nGXsfl_38_bak_idx = nGXsfl_38_idx;
            gxgrGrid_refresh( subGrid_Rows, AV56Pgmname, Gx_date, AV35Year) ;
            nGXsfl_38_idx = nGXsfl_38_bak_idx;
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
         }
      }

      protected void S152( )
      {
         /* 'LOADGRIDSDT' Routine */
         returnInSub = false;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21Session.Get(AV56Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV56Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV21Session.Get(AV56Pgmname+"GridState"), null, "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV21Session.Get(AV56Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV56Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOEMPLOYEEID' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV38EmployeeIdsToShow } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor H005D4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A106EmployeeId = H005D4_A106EmployeeId[0];
            A148EmployeeName = H005D4_A148EmployeeName[0];
            AV41Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV41Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
            AV41Combo_DataItem.gxTpr_Title = A148EmployeeName;
            AV40EmployeeId_Data.Add(AV41Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         Combo_employeeid_Selectedvalue_set = ((0==AV36EmployeeId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(AV36EmployeeId), 10, 0)));
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
      }

      protected void S112( )
      {
         /* 'GETDATA' Routine */
         returnInSub = false;
         AV14SDT_EmployeeBalanceActions.Clear();
         gx_BV38 = true;
         /* Using cursor H005D5 */
         pr_default.execute(3, new Object[] {AV36EmployeeId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A106EmployeeId = H005D5_A106EmployeeId[0];
            A146EmployeeVactionDays = H005D5_A146EmployeeVactionDays[0];
            A177EmployeeVacationDaysSetDate = H005D5_A177EmployeeVacationDaysSetDate[0];
            A100CompanyId = H005D5_A100CompanyId[0];
            A147EmployeeBalance = H005D5_A147EmployeeBalance[0];
            AV34SDT_EmployeeBalanceAction = new SdtSDT_EmployeeBalanceAction(context);
            AV34SDT_EmployeeBalanceAction.gxTpr_Startdate = A177EmployeeVacationDaysSetDate;
            AV34SDT_EmployeeBalanceAction.gxTpr_Enddate = A177EmployeeVacationDaysSetDate;
            AV34SDT_EmployeeBalanceAction.gxTpr_Type = "SET";
            AV34SDT_EmployeeBalanceAction.gxTpr_Durationindays = A146EmployeeVactionDays;
            AV34SDT_EmployeeBalanceAction.gxTpr_Durationinhours = (decimal)(A146EmployeeVactionDays*8);
            AV42EmployeeVactionDays = A146EmployeeVactionDays;
            AssignAttri("", false, "AV42EmployeeVactionDays", StringUtil.LTrimStr( AV42EmployeeVactionDays, 4, 1));
            AV14SDT_EmployeeBalanceActions.Add(AV34SDT_EmployeeBalanceAction, 0);
            gx_BV38 = true;
            AV37CompanyId = A100CompanyId;
            AssignAttri("", false, "AV37CompanyId", StringUtil.LTrimStr( (decimal)(AV37CompanyId), 10, 0));
            AV44EmployeeBalance = A147EmployeeBalance;
            AssignAttri("", false, "AV44EmployeeBalance", StringUtil.LTrimStr( AV44EmployeeBalance, 4, 1));
            /* Using cursor H005D6 */
            pr_default.execute(4, new Object[] {A106EmployeeId, AV35Year});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A186VacationSetDate = H005D6_A186VacationSetDate[0];
               A179VacationSetDays = H005D6_A179VacationSetDays[0];
               AV34SDT_EmployeeBalanceAction = new SdtSDT_EmployeeBalanceAction(context);
               AV34SDT_EmployeeBalanceAction.gxTpr_Startdate = A186VacationSetDate;
               AV34SDT_EmployeeBalanceAction.gxTpr_Enddate = A186VacationSetDate;
               AV34SDT_EmployeeBalanceAction.gxTpr_Type = "SET";
               AV34SDT_EmployeeBalanceAction.gxTpr_Durationindays = A179VacationSetDays;
               AV34SDT_EmployeeBalanceAction.gxTpr_Durationinhours = (decimal)(A179VacationSetDays*8);
               AV42EmployeeVactionDays = A146EmployeeVactionDays;
               AssignAttri("", false, "AV42EmployeeVactionDays", StringUtil.LTrimStr( AV42EmployeeVactionDays, 4, 1));
               AV14SDT_EmployeeBalanceActions.Add(AV34SDT_EmployeeBalanceAction, 0);
               gx_BV38 = true;
               pr_default.readNext(4);
            }
            pr_default.close(4);
            /* Using cursor H005D7 */
            pr_default.execute(5, new Object[] {A106EmployeeId, AV35Year});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A124LeaveTypeId = H005D7_A124LeaveTypeId[0];
               A129LeaveRequestStartDate = H005D7_A129LeaveRequestStartDate[0];
               A145LeaveTypeLoggingWorkHours = H005D7_A145LeaveTypeLoggingWorkHours[0];
               A144LeaveTypeVacationLeave = H005D7_A144LeaveTypeVacationLeave[0];
               A132LeaveRequestStatus = H005D7_A132LeaveRequestStatus[0];
               A130LeaveRequestEndDate = H005D7_A130LeaveRequestEndDate[0];
               A131LeaveRequestDuration = H005D7_A131LeaveRequestDuration[0];
               A133LeaveRequestDescription = H005D7_A133LeaveRequestDescription[0];
               A145LeaveTypeLoggingWorkHours = H005D7_A145LeaveTypeLoggingWorkHours[0];
               A144LeaveTypeVacationLeave = H005D7_A144LeaveTypeVacationLeave[0];
               AV34SDT_EmployeeBalanceAction = new SdtSDT_EmployeeBalanceAction(context);
               AV34SDT_EmployeeBalanceAction.gxTpr_Startdate = A129LeaveRequestStartDate;
               AV34SDT_EmployeeBalanceAction.gxTpr_Enddate = A130LeaveRequestEndDate;
               AV34SDT_EmployeeBalanceAction.gxTpr_Type = "LEAVE";
               AV34SDT_EmployeeBalanceAction.gxTpr_Durationindays = (decimal)(A131LeaveRequestDuration*-1);
               AV34SDT_EmployeeBalanceAction.gxTpr_Durationinhours = (decimal)(A131LeaveRequestDuration*8*-1);
               AV34SDT_EmployeeBalanceAction.gxTpr_Description = A133LeaveRequestDescription;
               AV14SDT_EmployeeBalanceActions.Add(AV34SDT_EmployeeBalanceAction, 0);
               gx_BV38 = true;
               pr_default.readNext(5);
            }
            pr_default.close(5);
            /* Using cursor H005D8 */
            pr_default.execute(6, new Object[] {AV37CompanyId, AV35Year});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A115HolidayStartDate = H005D8_A115HolidayStartDate[0];
               A139HolidayIsActive = H005D8_A139HolidayIsActive[0];
               A100CompanyId = H005D8_A100CompanyId[0];
               A116HolidayEndDate = H005D8_A116HolidayEndDate[0];
               n116HolidayEndDate = H005D8_n116HolidayEndDate[0];
               A114HolidayName = H005D8_A114HolidayName[0];
               AV34SDT_EmployeeBalanceAction = new SdtSDT_EmployeeBalanceAction(context);
               AV34SDT_EmployeeBalanceAction.gxTpr_Startdate = A115HolidayStartDate;
               AV34SDT_EmployeeBalanceAction.gxTpr_Enddate = A116HolidayEndDate;
               AV34SDT_EmployeeBalanceAction.gxTpr_Type = "HOLIDAY";
               AV34SDT_EmployeeBalanceAction.gxTpr_Durationindays = (decimal)(1);
               AV34SDT_EmployeeBalanceAction.gxTpr_Durationinhours = (decimal)(8);
               AV34SDT_EmployeeBalanceAction.gxTpr_Description = A114HolidayName;
               AV14SDT_EmployeeBalanceActions.Add(AV34SDT_EmployeeBalanceAction, 0);
               gx_BV38 = true;
               pr_default.readNext(6);
            }
            pr_default.close(6);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         AV14SDT_EmployeeBalanceActions.Sort("StartDate");
         gx_BV38 = true;
         context.DoAjaxRefresh();
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
         PA5D2( ) ;
         WS5D2( ) ;
         WE5D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267553998", true, true);
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
         context.AddJavascriptSource("wp_leavebalancereport1.js", "?20256267553998", false, true);
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
         edtavSdt_employeebalanceactions__startdate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__STARTDATE_"+sGXsfl_38_idx;
         edtavSdt_employeebalanceactions__enddate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__ENDDATE_"+sGXsfl_38_idx;
         edtavSdt_employeebalanceactions__type_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__TYPE_"+sGXsfl_38_idx;
         edtavSdt_employeebalanceactions__description_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DESCRIPTION_"+sGXsfl_38_idx;
         edtavSdt_employeebalanceactions__durationinhours_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINHOURS_"+sGXsfl_38_idx;
         edtavSdt_employeebalanceactions__durationindays_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINDAYS_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_382( )
      {
         edtavSdt_employeebalanceactions__startdate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__STARTDATE_"+sGXsfl_38_fel_idx;
         edtavSdt_employeebalanceactions__enddate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__ENDDATE_"+sGXsfl_38_fel_idx;
         edtavSdt_employeebalanceactions__type_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__TYPE_"+sGXsfl_38_fel_idx;
         edtavSdt_employeebalanceactions__description_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DESCRIPTION_"+sGXsfl_38_fel_idx;
         edtavSdt_employeebalanceactions__durationinhours_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINHOURS_"+sGXsfl_38_fel_idx;
         edtavSdt_employeebalanceactions__durationindays_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINDAYS_"+sGXsfl_38_fel_idx;
      }

      protected void sendrow_382( )
      {
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_382( ) ;
         WB5D0( ) ;
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__startdate_Internalname,context.localUtil.Format(((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Startdate, "99/99/99"),context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Startdate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__startdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__startdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__enddate_Internalname,context.localUtil.Format(((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Enddate, "99/99/99"),context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Enddate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__enddate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__enddate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__type_Internalname,StringUtil.RTrim( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Type),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__type_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__type_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__description_Internalname,((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Description,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__description_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__description_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__durationinhours_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Durationinhours, 5, 1, ".", "")),StringUtil.LTrim( ((edtavSdt_employeebalanceactions__durationinhours_Enabled!=0) ? context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Durationinhours, "ZZ9.9") : context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Durationinhours, "ZZ9.9"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__durationinhours_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__durationinhours_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_38_idx + "',38)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_employeebalanceactions__durationindays_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Durationindays, 4, 1, ".", "")),StringUtil.LTrim( ((edtavSdt_employeebalanceactions__durationindays_Enabled!=0) ? context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Durationindays, "Z9.9") : context.localUtil.Format( ((SdtSDT_EmployeeBalanceAction)AV14SDT_EmployeeBalanceActions.Item(AV45GXV1)).gxTpr_Durationindays, "Z9.9"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_employeebalanceactions__durationindays_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_employeebalanceactions__durationindays_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes5D2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_38_idx = ((subGrid_Islastpage==1)&&(nGXsfl_38_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
         }
         /* End function sendrow_382 */
      }

      protected void init_web_controls( )
      {
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Start Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "End Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Duration In Hours") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Duration In Days") ;
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
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_employeebalanceactions__startdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_employeebalanceactions__enddate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_employeebalanceactions__type_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_employeebalanceactions__description_Enabled), 5, 0, ".", "")));
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
         edtavEmployeebalance_Internalname = "vEMPLOYEEBALANCE";
         edtavEmployeevactiondays_Internalname = "vEMPLOYEEVACTIONDAYS";
         bttBtnsetbutton_Internalname = "BTNSETBUTTON";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTableheader_Internalname = "TABLEHEADER";
         edtavSdt_employeebalanceactions__startdate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__STARTDATE";
         edtavSdt_employeebalanceactions__enddate_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__ENDDATE";
         edtavSdt_employeebalanceactions__type_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__TYPE";
         edtavSdt_employeebalanceactions__description_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DESCRIPTION";
         edtavSdt_employeebalanceactions__durationinhours_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINHOURS";
         edtavSdt_employeebalanceactions__durationindays_Internalname = "SDT_EMPLOYEEBALANCEACTIONS__DURATIONINDAYS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         edtavEmployeeid_Internalname = "vEMPLOYEEID";
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
         edtavSdt_employeebalanceactions__durationindays_Jsonclick = "";
         edtavSdt_employeebalanceactions__durationindays_Enabled = 0;
         edtavSdt_employeebalanceactions__durationinhours_Jsonclick = "";
         edtavSdt_employeebalanceactions__durationinhours_Enabled = 0;
         edtavSdt_employeebalanceactions__description_Jsonclick = "";
         edtavSdt_employeebalanceactions__description_Enabled = 0;
         edtavSdt_employeebalanceactions__type_Jsonclick = "";
         edtavSdt_employeebalanceactions__type_Enabled = 0;
         edtavSdt_employeebalanceactions__enddate_Jsonclick = "";
         edtavSdt_employeebalanceactions__enddate_Enabled = 0;
         edtavSdt_employeebalanceactions__startdate_Jsonclick = "";
         edtavSdt_employeebalanceactions__startdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSdt_employeebalanceactions__durationindays_Enabled = -1;
         edtavSdt_employeebalanceactions__durationinhours_Enabled = -1;
         edtavSdt_employeebalanceactions__description_Enabled = -1;
         edtavSdt_employeebalanceactions__type_Enabled = -1;
         edtavSdt_employeebalanceactions__enddate_Enabled = -1;
         edtavSdt_employeebalanceactions__startdate_Enabled = -1;
         edtavEmployeeid_Jsonclick = "";
         edtavEmployeeid_Visible = 1;
         edtavEmployeevactiondays_Jsonclick = "";
         edtavEmployeevactiondays_Enabled = 1;
         edtavEmployeebalance_Jsonclick = "";
         edtavEmployeebalance_Enabled = 1;
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
         Form.Caption = "WP_Leave Balance Report";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"nRC_GXsfl_38","ctrl":"GRID","prop":"GridRC","grid":38},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV35Year","fld":"vYEAR","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV29GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E125D2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"nRC_GXsfl_38","ctrl":"GRID","prop":"GridRC","grid":38},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV35Year","fld":"vYEAR","pic":"ZZZ9","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E135D2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"nRC_GXsfl_38","ctrl":"GRID","prop":"GridRC","grid":38},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV35Year","fld":"vYEAR","pic":"ZZZ9","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E175D2","iparms":[]}""");
         setEventMetadata("'DOSETBUTTON'","""{"handler":"E145D2","iparms":[{"av":"AV36EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV42EmployeeVactionDays","fld":"vEMPLOYEEVACTIONDAYS","pic":"Z9.9"},{"av":"Gx_date","fld":"vTODAY","hsh":true}]}""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED","""{"handler":"E115D2","iparms":[{"av":"Combo_employeeid_Selectedvalue_get","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_get"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"nRC_GXsfl_38","ctrl":"GRID","prop":"GridRC","grid":38},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV56Pgmname","fld":"vPGMNAME","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV35Year","fld":"vYEAR","pic":"ZZZ9","hsh":true},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV36EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A177EmployeeVacationDaysSetDate","fld":"EMPLOYEEVACATIONDAYSSETDATE"},{"av":"A146EmployeeVactionDays","fld":"EMPLOYEEVACTIONDAYS","pic":"Z9.9"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A147EmployeeBalance","fld":"EMPLOYEEBALANCE","pic":"Z9.9"},{"av":"A186VacationSetDate","fld":"VACATIONSETDATE"},{"av":"A179VacationSetDays","fld":"VACATIONSETDAYS","pic":"Z9.9"},{"av":"A132LeaveRequestStatus","fld":"LEAVEREQUESTSTATUS"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"},{"av":"A129LeaveRequestStartDate","fld":"LEAVEREQUESTSTARTDATE"},{"av":"A130LeaveRequestEndDate","fld":"LEAVEREQUESTENDDATE"},{"av":"A131LeaveRequestDuration","fld":"LEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"A133LeaveRequestDescription","fld":"LEAVEREQUESTDESCRIPTION"},{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"},{"av":"A115HolidayStartDate","fld":"HOLIDAYSTARTDATE"},{"av":"A116HolidayEndDate","fld":"HOLIDAYENDDATE"},{"av":"A114HolidayName","fld":"HOLIDAYNAME"}]""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV36EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV14SDT_EmployeeBalanceActions","fld":"vSDT_EMPLOYEEBALANCEACTIONS","grid":38},{"av":"nGXsfl_38_idx","ctrl":"GRID","prop":"GridCurrRow","grid":38},{"av":"GRID_nFirstRecordOnPage"},{"av":"nRC_GXsfl_38","ctrl":"GRID","prop":"GridRC","grid":38},{"av":"AV42EmployeeVactionDays","fld":"vEMPLOYEEVACTIONDAYS","pic":"Z9.9"},{"av":"AV37CompanyId","fld":"vCOMPANYID","pic":"ZZZZZZZZZ9"},{"av":"AV44EmployeeBalance","fld":"vEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV27GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV28GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV29GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"}]}""");
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
         Combo_employeeid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV56Pgmname = "";
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV14SDT_EmployeeBalanceActions = new GXBaseCollection<SdtSDT_EmployeeBalanceAction>( context, "SDT_EmployeeBalanceAction", "YTT_version4");
         AV40EmployeeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV29GridAppliedFilters = "";
         A177EmployeeVacationDaysSetDate = DateTime.MinValue;
         A186VacationSetDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A144LeaveTypeVacationLeave = "";
         A145LeaveTypeLoggingWorkHours = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A133LeaveRequestDescription = "";
         A115HolidayStartDate = DateTime.MinValue;
         A116HolidayEndDate = DateTime.MinValue;
         A114HolidayName = "";
         Combo_employeeid_Selectedvalue_set = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblockcombo_employeeid_Jsonclick = "";
         ucCombo_employeeid = new GXUserControl();
         Combo_employeeid_Caption = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnsetbutton_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H005D2_A162ProjectManagerId = new long[1] ;
         H005D2_n162ProjectManagerId = new bool[] {false} ;
         H005D2_A102ProjectId = new long[1] ;
         AV39ProjectManagerProjectIds = new GxSimpleCollection<long>();
         AV38EmployeeIdsToShow = new GxSimpleCollection<long>();
         GXt_objcol_int1 = new GxSimpleCollection<long>();
         H005D3_A100CompanyId = new long[1] ;
         H005D3_A106EmployeeId = new long[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV43BC_Employee = new SdtEmployee(context);
         AV21Session = context.GetSession();
         AV11GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         H005D4_A106EmployeeId = new long[1] ;
         H005D4_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         AV41Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H005D5_A106EmployeeId = new long[1] ;
         H005D5_A146EmployeeVactionDays = new decimal[1] ;
         H005D5_A177EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         H005D5_A100CompanyId = new long[1] ;
         H005D5_A147EmployeeBalance = new decimal[1] ;
         AV34SDT_EmployeeBalanceAction = new SdtSDT_EmployeeBalanceAction(context);
         H005D6_A106EmployeeId = new long[1] ;
         H005D6_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         H005D6_A179VacationSetDays = new decimal[1] ;
         H005D7_A127LeaveRequestId = new long[1] ;
         H005D7_A124LeaveTypeId = new long[1] ;
         H005D7_A106EmployeeId = new long[1] ;
         H005D7_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         H005D7_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         H005D7_A144LeaveTypeVacationLeave = new string[] {""} ;
         H005D7_A132LeaveRequestStatus = new string[] {""} ;
         H005D7_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         H005D7_A131LeaveRequestDuration = new decimal[1] ;
         H005D7_A133LeaveRequestDescription = new string[] {""} ;
         H005D8_A113HolidayId = new long[1] ;
         H005D8_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         H005D8_A139HolidayIsActive = new bool[] {false} ;
         H005D8_A100CompanyId = new long[1] ;
         H005D8_A116HolidayEndDate = new DateTime[] {DateTime.MinValue} ;
         H005D8_n116HolidayEndDate = new bool[] {false} ;
         H005D8_A114HolidayName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_leavebalancereport1__default(),
            new Object[][] {
                new Object[] {
               H005D2_A162ProjectManagerId, H005D2_n162ProjectManagerId, H005D2_A102ProjectId
               }
               , new Object[] {
               H005D3_A100CompanyId, H005D3_A106EmployeeId
               }
               , new Object[] {
               H005D4_A106EmployeeId, H005D4_A148EmployeeName
               }
               , new Object[] {
               H005D5_A106EmployeeId, H005D5_A146EmployeeVactionDays, H005D5_A177EmployeeVacationDaysSetDate, H005D5_A100CompanyId, H005D5_A147EmployeeBalance
               }
               , new Object[] {
               H005D6_A106EmployeeId, H005D6_A186VacationSetDate, H005D6_A179VacationSetDays
               }
               , new Object[] {
               H005D7_A127LeaveRequestId, H005D7_A124LeaveTypeId, H005D7_A106EmployeeId, H005D7_A129LeaveRequestStartDate, H005D7_A145LeaveTypeLoggingWorkHours, H005D7_A144LeaveTypeVacationLeave, H005D7_A132LeaveRequestStatus, H005D7_A130LeaveRequestEndDate, H005D7_A131LeaveRequestDuration, H005D7_A133LeaveRequestDescription
               }
               , new Object[] {
               H005D8_A113HolidayId, H005D8_A115HolidayStartDate, H005D8_A139HolidayIsActive, H005D8_A100CompanyId, H005D8_A116HolidayEndDate, H005D8_n116HolidayEndDate, H005D8_A114HolidayName
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV56Pgmname = "WP_LeaveBalanceReport1";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV56Pgmname = "WP_LeaveBalanceReport1";
         edtavEmployeebalance_Enabled = 0;
         edtavSdt_employeebalanceactions__startdate_Enabled = 0;
         edtavSdt_employeebalanceactions__enddate_Enabled = 0;
         edtavSdt_employeebalanceactions__type_Enabled = 0;
         edtavSdt_employeebalanceactions__description_Enabled = 0;
         edtavSdt_employeebalanceactions__durationinhours_Enabled = 0;
         edtavSdt_employeebalanceactions__durationindays_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV35Year ;
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
      private int nRC_GXsfl_38 ;
      private int nGXsfl_38_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavEmployeebalance_Enabled ;
      private int edtavEmployeevactiondays_Enabled ;
      private int AV45GXV1 ;
      private int edtavEmployeeid_Visible ;
      private int subGrid_Islastpage ;
      private int edtavSdt_employeebalanceactions__startdate_Enabled ;
      private int edtavSdt_employeebalanceactions__enddate_Enabled ;
      private int edtavSdt_employeebalanceactions__type_Enabled ;
      private int edtavSdt_employeebalanceactions__description_Enabled ;
      private int edtavSdt_employeebalanceactions__durationinhours_Enabled ;
      private int edtavSdt_employeebalanceactions__durationindays_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_38_fel_idx=1 ;
      private int AV26PageToGo ;
      private int nGXsfl_38_bak_idx=1 ;
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
      private long AV36EmployeeId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long AV53Udparg1 ;
      private long A162ProjectManagerId ;
      private long A102ProjectId ;
      private long AV55Udparg2 ;
      private long AV37CompanyId ;
      private long A124LeaveTypeId ;
      private decimal A146EmployeeVactionDays ;
      private decimal A147EmployeeBalance ;
      private decimal A179VacationSetDays ;
      private decimal A131LeaveRequestDuration ;
      private decimal AV44EmployeeBalance ;
      private decimal AV42EmployeeVactionDays ;
      private string Gridpaginationbar_Selectedpage ;
      private string Combo_employeeid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_38_idx="0001" ;
      private string AV56Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A132LeaveRequestStatus ;
      private string A144LeaveTypeVacationLeave ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A114HolidayName ;
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
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divTablesplittedemployeeid_Internalname ;
      private string lblTextblockcombo_employeeid_Internalname ;
      private string lblTextblockcombo_employeeid_Jsonclick ;
      private string Combo_employeeid_Caption ;
      private string Combo_employeeid_Internalname ;
      private string edtavEmployeebalance_Internalname ;
      private string TempTags ;
      private string edtavEmployeebalance_Jsonclick ;
      private string edtavEmployeevactiondays_Internalname ;
      private string edtavEmployeevactiondays_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnsetbutton_Internalname ;
      private string bttBtnsetbutton_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavEmployeeid_Internalname ;
      private string edtavEmployeeid_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string GXt_char2 ;
      private string A148EmployeeName ;
      private string edtavSdt_employeebalanceactions__startdate_Internalname ;
      private string edtavSdt_employeebalanceactions__enddate_Internalname ;
      private string edtavSdt_employeebalanceactions__type_Internalname ;
      private string edtavSdt_employeebalanceactions__description_Internalname ;
      private string edtavSdt_employeebalanceactions__durationinhours_Internalname ;
      private string edtavSdt_employeebalanceactions__durationindays_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_employeebalanceactions__startdate_Jsonclick ;
      private string edtavSdt_employeebalanceactions__enddate_Jsonclick ;
      private string edtavSdt_employeebalanceactions__type_Jsonclick ;
      private string edtavSdt_employeebalanceactions__description_Jsonclick ;
      private string edtavSdt_employeebalanceactions__durationinhours_Jsonclick ;
      private string edtavSdt_employeebalanceactions__durationindays_Jsonclick ;
      private string subGrid_Header ;
      private DateTime Gx_date ;
      private DateTime A177EmployeeVacationDaysSetDate ;
      private DateTime A186VacationSetDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A115HolidayStartDate ;
      private DateTime A116HolidayEndDate ;
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
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_38_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n162ProjectManagerId ;
      private bool gx_refresh_fired ;
      private bool gx_BV38 ;
      private bool n116HolidayEndDate ;
      private string AV29GridAppliedFilters ;
      private string A133LeaveRequestDescription ;
      private IGxSession AV21Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucCombo_employeeid ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_EmployeeBalanceAction> AV14SDT_EmployeeBalanceActions ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV40EmployeeId_Data ;
      private IDataStoreProvider pr_default ;
      private long[] H005D2_A162ProjectManagerId ;
      private bool[] H005D2_n162ProjectManagerId ;
      private long[] H005D2_A102ProjectId ;
      private GxSimpleCollection<long> AV39ProjectManagerProjectIds ;
      private GxSimpleCollection<long> AV38EmployeeIdsToShow ;
      private GxSimpleCollection<long> GXt_objcol_int1 ;
      private long[] H005D3_A100CompanyId ;
      private long[] H005D3_A106EmployeeId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private SdtEmployee AV43BC_Employee ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private long[] H005D4_A106EmployeeId ;
      private string[] H005D4_A148EmployeeName ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV41Combo_DataItem ;
      private long[] H005D5_A106EmployeeId ;
      private decimal[] H005D5_A146EmployeeVactionDays ;
      private DateTime[] H005D5_A177EmployeeVacationDaysSetDate ;
      private long[] H005D5_A100CompanyId ;
      private decimal[] H005D5_A147EmployeeBalance ;
      private SdtSDT_EmployeeBalanceAction AV34SDT_EmployeeBalanceAction ;
      private long[] H005D6_A106EmployeeId ;
      private DateTime[] H005D6_A186VacationSetDate ;
      private decimal[] H005D6_A179VacationSetDays ;
      private long[] H005D7_A127LeaveRequestId ;
      private long[] H005D7_A124LeaveTypeId ;
      private long[] H005D7_A106EmployeeId ;
      private DateTime[] H005D7_A129LeaveRequestStartDate ;
      private string[] H005D7_A145LeaveTypeLoggingWorkHours ;
      private string[] H005D7_A144LeaveTypeVacationLeave ;
      private string[] H005D7_A132LeaveRequestStatus ;
      private DateTime[] H005D7_A130LeaveRequestEndDate ;
      private decimal[] H005D7_A131LeaveRequestDuration ;
      private string[] H005D7_A133LeaveRequestDescription ;
      private long[] H005D8_A113HolidayId ;
      private DateTime[] H005D8_A115HolidayStartDate ;
      private bool[] H005D8_A139HolidayIsActive ;
      private long[] H005D8_A100CompanyId ;
      private DateTime[] H005D8_A116HolidayEndDate ;
      private bool[] H005D8_n116HolidayEndDate ;
      private string[] H005D8_A114HolidayName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_leavebalancereport1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005D4( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV38EmployeeIdsToShow )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT EmployeeId, EmployeeName FROM Employee";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV38EmployeeIdsToShow, "EmployeeId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeName";
         GXv_Object3[0] = scmdbuf;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_H005D4(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005D2;
          prmH005D2 = new Object[] {
          new ParDef("AV53Udparg1",GXType.Int64,10,0)
          };
          Object[] prmH005D3;
          prmH005D3 = new Object[] {
          new ParDef("AV55Udparg2",GXType.Int64,10,0)
          };
          Object[] prmH005D5;
          prmH005D5 = new Object[] {
          new ParDef("AV36EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH005D6;
          prmH005D6 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV35Year",GXType.Int16,4,0)
          };
          Object[] prmH005D7;
          prmH005D7 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV35Year",GXType.Int16,4,0)
          };
          Object[] prmH005D8;
          prmH005D8 = new Object[] {
          new ParDef("AV37CompanyId",GXType.Int64,10,0) ,
          new ParDef("AV35Year",GXType.Int16,4,0)
          };
          Object[] prmH005D4;
          prmH005D4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H005D2", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV53Udparg1 ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005D2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005D3", "SELECT CompanyId, EmployeeId FROM Employee WHERE CompanyId = :AV55Udparg2 ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005D3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005D4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005D4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005D5", "SELECT EmployeeId, EmployeeVactionDays, EmployeeVacationDaysSetDate, CompanyId, EmployeeBalance FROM Employee WHERE EmployeeId = :AV36EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005D5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H005D6", "SELECT EmployeeId, VacationSetDate, VacationSetDays FROM EmployeeVacationSet WHERE (EmployeeId = :EmployeeId) AND (date_part('year', VacationSetDate) = :AV35Year) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005D6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005D7", "SELECT T1.LeaveRequestId, T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestStartDate, T2.LeaveTypeLoggingWorkHours, T2.LeaveTypeVacationLeave, T1.LeaveRequestStatus, T1.LeaveRequestEndDate, T1.LeaveRequestDuration, T1.LeaveRequestDescription FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :EmployeeId) AND (date_part('year', T1.LeaveRequestStartDate) = :AV35Year) AND (T1.LeaveRequestStatus = ( 'Approved')) AND (T2.LeaveTypeVacationLeave = ( 'Yes')) AND (T2.LeaveTypeLoggingWorkHours = ( 'No')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005D7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005D8", "SELECT HolidayId, HolidayStartDate, HolidayIsActive, CompanyId, HolidayEndDate, HolidayName FROM Holiday WHERE (CompanyId = :AV37CompanyId) AND (date_part('year', HolidayStartDate) = :AV35Year) AND (HolidayIsActive = TRUE) ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005D8,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                return;
             case 6 :
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
