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
   public class leaverequestlist : GXDataArea
   {
      public leaverequestlist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestlist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_LeaveTypeId ,
                           long aP1_EmployeeId ,
                           DateTime aP2_FromDate ,
                           DateTime aP3_ToDate ,
                           long aP4_CompanyLocationId )
      {
         this.AV64LeaveTypeId = aP0_LeaveTypeId;
         this.AV65EmployeeId = aP1_EmployeeId;
         this.AV66FromDate = aP2_FromDate;
         this.AV67ToDate = aP3_ToDate;
         this.AV68CompanyLocationId = aP4_CompanyLocationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbLeaveRequestStatus = new GXCombobox();
         radLeaveTypeVacationLeave = new GXRadio();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "LeaveTypeId");
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
               gxfirstwebparm = GetFirstPar( "LeaveTypeId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "LeaveTypeId");
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
               AV64LeaveTypeId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV64LeaveTypeId", StringUtil.LTrimStr( (decimal)(AV64LeaveTypeId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vLEAVETYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV64LeaveTypeId), "ZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV65EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV65EmployeeId", StringUtil.LTrimStr( (decimal)(AV65EmployeeId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65EmployeeId), "ZZZZZZZZZ9"), context));
                  AV66FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
                  AssignAttri("", false, "AV66FromDate", context.localUtil.Format(AV66FromDate, "99/99/99"));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFROMDATE", GetSecureSignedToken( "", AV66FromDate, context));
                  AV67ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
                  AssignAttri("", false, "AV67ToDate", context.localUtil.Format(AV67ToDate, "99/99/99"));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTODATE", GetSecureSignedToken( "", AV67ToDate, context));
                  AV68CompanyLocationId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyLocationId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV68CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV68CompanyLocationId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCOMPANYLOCATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV68CompanyLocationId), "ZZZZZZZZZ9"), context));
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_35 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
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
         AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV17OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV19FilterFullText = GetPar( "FilterFullText");
         AV64LeaveTypeId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveTypeId"), "."), 18, MidpointRounding.ToEven));
         AV65EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
         AV66FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV67ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         AV29ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV69Pgmname = GetPar( "Pgmname");
         AV30TFLeaveTypeName = GetPar( "TFLeaveTypeName");
         AV31TFLeaveTypeName_Sel = GetPar( "TFLeaveTypeName_Sel");
         AV32TFEmployeeName = GetPar( "TFEmployeeName");
         AV33TFEmployeeName_Sel = GetPar( "TFEmployeeName_Sel");
         AV34TFLeaveRequestStartDate = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestStartDate"));
         AV35TFLeaveRequestStartDate_To = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestStartDate_To"));
         AV39TFLeaveRequestEndDate = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestEndDate"));
         AV40TFLeaveRequestEndDate_To = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestEndDate_To"));
         AV44TFLeaveRequestHalfDay = GetPar( "TFLeaveRequestHalfDay");
         AV45TFLeaveRequestHalfDay_Sel = GetPar( "TFLeaveRequestHalfDay_Sel");
         AV46TFLeaveRequestDuration = NumberUtil.Val( GetPar( "TFLeaveRequestDuration"), ".");
         AV47TFLeaveRequestDuration_To = NumberUtil.Val( GetPar( "TFLeaveRequestDuration_To"), ".");
         AV50TFLeaveRequestDescription = GetPar( "TFLeaveRequestDescription");
         AV51TFLeaveRequestDescription_Sel = GetPar( "TFLeaveRequestDescription_Sel");
         AV68CompanyLocationId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyLocationId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV64LeaveTypeId, AV65EmployeeId, AV66FromDate, AV67ToDate, AV29ManageFiltersExecutionStep, AV69Pgmname, AV30TFLeaveTypeName, AV31TFLeaveTypeName_Sel, AV32TFEmployeeName, AV33TFEmployeeName_Sel, AV34TFLeaveRequestStartDate, AV35TFLeaveRequestStartDate_To, AV39TFLeaveRequestEndDate, AV40TFLeaveRequestEndDate_To, AV44TFLeaveRequestHalfDay, AV45TFLeaveRequestHalfDay_Sel, AV46TFLeaveRequestDuration, AV47TFLeaveRequestDuration_To, AV50TFLeaveRequestDescription, AV51TFLeaveRequestDescription_Sel, AV68CompanyLocationId) ;
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
            return "leaverequestlist_Execute" ;
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
         PA5F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5F2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leaverequestlist.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV64LeaveTypeId,10,0)),UrlEncode(StringUtil.LTrimStr(AV65EmployeeId,10,0)),UrlEncode(DateTimeUtil.FormatDateParm(AV66FromDate)),UrlEncode(DateTimeUtil.FormatDateParm(AV67ToDate)),UrlEncode(StringUtil.LTrimStr(AV68CompanyLocationId,10,0))}, new string[] {"LeaveTypeId","EmployeeId","FromDate","ToDate","CompanyLocationId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vLEAVETYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64LeaveTypeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVETYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV64LeaveTypeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vFROMDATE", context.localUtil.DToC( AV66FromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vFROMDATE", GetSecureSignedToken( "", AV66FromDate, context));
         GxWebStd.gx_hidden_field( context, "vTODATE", context.localUtil.DToC( AV67ToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODATE", GetSecureSignedToken( "", AV67ToDate, context));
         GxWebStd.gx_hidden_field( context, "vCOMPANYLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMPANYLOCATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV68CompanyLocationId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV17OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV19FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV27ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV27ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV9GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV60AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV60AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV54DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV54DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTSTARTDATEAUXDATE", context.localUtil.DToC( AV36DDO_LeaveRequestStartDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTSTARTDATEAUXDATETO", context.localUtil.DToC( AV37DDO_LeaveRequestStartDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTENDDATEAUXDATE", context.localUtil.DToC( AV41DDO_LeaveRequestEndDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTENDDATEAUXDATETO", context.localUtil.DToC( AV42DDO_LeaveRequestEndDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFLEAVETYPENAME", StringUtil.RTrim( AV30TFLeaveTypeName));
         GxWebStd.gx_hidden_field( context, "vTFLEAVETYPENAME_SEL", StringUtil.RTrim( AV31TFLeaveTypeName_Sel));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEENAME", StringUtil.RTrim( AV32TFEmployeeName));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEENAME_SEL", StringUtil.RTrim( AV33TFEmployeeName_Sel));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTSTARTDATE", context.localUtil.DToC( AV34TFLeaveRequestStartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTSTARTDATE_TO", context.localUtil.DToC( AV35TFLeaveRequestStartDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTENDDATE", context.localUtil.DToC( AV39TFLeaveRequestEndDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTENDDATE_TO", context.localUtil.DToC( AV40TFLeaveRequestEndDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTHALFDAY", StringUtil.RTrim( AV44TFLeaveRequestHalfDay));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTHALFDAY_SEL", StringUtil.RTrim( AV45TFLeaveRequestHalfDay_Sel));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDURATION", StringUtil.LTrim( StringUtil.NToC( AV46TFLeaveRequestDuration, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDURATION_TO", StringUtil.LTrim( StringUtil.NToC( AV47TFLeaveRequestDuration_To, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDESCRIPTION", AV50TFLeaveRequestDescription);
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDESCRIPTION_SEL", AV51TFLeaveRequestDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV17OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vLEAVETYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64LeaveTypeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVETYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV64LeaveTypeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vFROMDATE", context.localUtil.DToC( AV66FromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vFROMDATE", GetSecureSignedToken( "", AV66FromDate, context));
         GxWebStd.gx_hidden_field( context, "vTODATE", context.localUtil.DToC( AV67ToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODATE", GetSecureSignedToken( "", AV67ToDate, context));
         GxWebStd.gx_hidden_field( context, "vCOMPANYLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMPANYLOCATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV68CompanyLocationId), "ZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV14GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV14GridState);
         }
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            WE5F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5F2( ) ;
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
         return formatLink("leaverequestlist.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV64LeaveTypeId,10,0)),UrlEncode(StringUtil.LTrimStr(AV65EmployeeId,10,0)),UrlEncode(DateTimeUtil.FormatDateParm(AV66FromDate)),UrlEncode(DateTimeUtil.FormatDateParm(AV67ToDate)),UrlEncode(StringUtil.LTrimStr(AV68CompanyLocationId,10,0))}, new string[] {"LeaveTypeId","EmployeeId","FromDate","ToDate","CompanyLocationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "LeaveRequestList" ;
      }

      public override string GetPgmdesc( )
      {
         return " Leave Request" ;
      }

      protected void WB5F0( )
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
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", "Export", bttBtnagexport_Jsonclick, 0, "Export", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestList.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV27ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV19FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV19FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_LeaveRequestList.htm");
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
            StartGridControl35( ) ;
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV58GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV59GridPageCount);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV60AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_leaverequeststartdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_leaverequeststartdateauxdatetext_Internalname, AV38DDO_LeaveRequestStartDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV38DDO_LeaveRequestStartDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_leaverequeststartdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequestList.htm");
            /* User Defined Control */
            ucTfleaverequeststartdate_rangepicker.SetProperty("Start Date", AV36DDO_LeaveRequestStartDateAuxDate);
            ucTfleaverequeststartdate_rangepicker.SetProperty("End Date", AV37DDO_LeaveRequestStartDateAuxDateTo);
            ucTfleaverequeststartdate_rangepicker.Render(context, "wwp.daterangepicker", Tfleaverequeststartdate_rangepicker_Internalname, "TFLEAVEREQUESTSTARTDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_leaverequestenddateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_leaverequestenddateauxdatetext_Internalname, AV43DDO_LeaveRequestEndDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV43DDO_LeaveRequestEndDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_leaverequestenddateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequestList.htm");
            /* User Defined Control */
            ucTfleaverequestenddate_rangepicker.SetProperty("Start Date", AV41DDO_LeaveRequestEndDateAuxDate);
            ucTfleaverequestenddate_rangepicker.SetProperty("End Date", AV42DDO_LeaveRequestEndDateAuxDateTo);
            ucTfleaverequestenddate_rangepicker.Render(context, "wwp.daterangepicker", Tfleaverequestenddate_rangepicker_Internalname, "TFLEAVEREQUESTENDDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 35 )
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

      protected void START5F2( )
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
         Form.Meta.addItem("description", " Leave Request", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5F0( ) ;
      }

      protected void WS5F2( )
      {
         START5F2( ) ;
         EVT5F2( ) ;
      }

      protected void EVT5F2( )
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
                              E115F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E125F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E135F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E145F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E155F2 ();
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
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              A127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveRequestId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A124LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A125LeaveTypeName = cgiGet( edtLeaveTypeName_Internalname);
                              A128LeaveRequestDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtLeaveRequestDate_Internalname), 0));
                              A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
                              A129LeaveRequestStartDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtLeaveRequestStartDate_Internalname), 0));
                              A130LeaveRequestEndDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtLeaveRequestEndDate_Internalname), 0));
                              A171LeaveRequestHalfDay = cgiGet( edtLeaveRequestHalfDay_Internalname);
                              n171LeaveRequestHalfDay = false;
                              A131LeaveRequestDuration = context.localUtil.CToN( cgiGet( edtLeaveRequestDuration_Internalname), ".", ",");
                              cmbLeaveRequestStatus.Name = cmbLeaveRequestStatus_Internalname;
                              cmbLeaveRequestStatus.CurrentValue = cgiGet( cmbLeaveRequestStatus_Internalname);
                              A132LeaveRequestStatus = cgiGet( cmbLeaveRequestStatus_Internalname);
                              A133LeaveRequestDescription = cgiGet( edtLeaveRequestDescription_Internalname);
                              A134LeaveRequestRejectionReason = cgiGet( edtLeaveRequestRejectionReason_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A147EmployeeBalance = context.localUtil.CToN( cgiGet( edtEmployeeBalance_Internalname), ".", ",");
                              A144LeaveTypeVacationLeave = cgiGet( radLeaveTypeVacationLeave_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E165F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E175F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E185F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV16OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV17OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV19FilterFullText) != 0 )
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

      protected void WE5F2( )
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

      protected void PA5F2( )
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
         SubsflControlProps_352( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_352( ) ;
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV16OrderedBy ,
                                       bool AV17OrderedDsc ,
                                       string AV19FilterFullText ,
                                       long AV64LeaveTypeId ,
                                       long AV65EmployeeId ,
                                       DateTime AV66FromDate ,
                                       DateTime AV67ToDate ,
                                       short AV29ManageFiltersExecutionStep ,
                                       string AV69Pgmname ,
                                       string AV30TFLeaveTypeName ,
                                       string AV31TFLeaveTypeName_Sel ,
                                       string AV32TFEmployeeName ,
                                       string AV33TFEmployeeName_Sel ,
                                       DateTime AV34TFLeaveRequestStartDate ,
                                       DateTime AV35TFLeaveRequestStartDate_To ,
                                       DateTime AV39TFLeaveRequestEndDate ,
                                       DateTime AV40TFLeaveRequestEndDate_To ,
                                       string AV44TFLeaveRequestHalfDay ,
                                       string AV45TFLeaveRequestHalfDay_Sel ,
                                       decimal AV46TFLeaveRequestDuration ,
                                       decimal AV47TFLeaveRequestDuration_To ,
                                       string AV50TFLeaveRequestDescription ,
                                       string AV51TFLeaveRequestDescription_Sel ,
                                       long AV68CompanyLocationId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5F2( ) ;
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
         RF5F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV69Pgmname = "LeaveRequestList";
      }

      protected void RF5F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 35;
         /* Execute user event: Refresh */
         E175F2 ();
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         bGXsfl_35_Refreshing = true;
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
            SubsflControlProps_352( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV70Leaverequestlistds_1_filterfulltext ,
                                                 AV72Leaverequestlistds_3_tfleavetypename_sel ,
                                                 AV71Leaverequestlistds_2_tfleavetypename ,
                                                 AV74Leaverequestlistds_5_tfemployeename_sel ,
                                                 AV73Leaverequestlistds_4_tfemployeename ,
                                                 AV75Leaverequestlistds_6_tfleaverequeststartdate ,
                                                 AV76Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                                 AV77Leaverequestlistds_8_tfleaverequestenddate ,
                                                 AV78Leaverequestlistds_9_tfleaverequestenddate_to ,
                                                 AV80Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                                 AV79Leaverequestlistds_10_tfleaverequesthalfday ,
                                                 AV81Leaverequestlistds_12_tfleaverequestduration ,
                                                 AV82Leaverequestlistds_13_tfleaverequestduration_to ,
                                                 AV84Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                                 AV83Leaverequestlistds_14_tfleaverequestdescription ,
                                                 AV64LeaveTypeId ,
                                                 AV65EmployeeId ,
                                                 A125LeaveTypeName ,
                                                 A148EmployeeName ,
                                                 A171LeaveRequestHalfDay ,
                                                 A131LeaveRequestDuration ,
                                                 A133LeaveRequestDescription ,
                                                 A129LeaveRequestStartDate ,
                                                 A130LeaveRequestEndDate ,
                                                 A124LeaveTypeId ,
                                                 A106EmployeeId ,
                                                 AV16OrderedBy ,
                                                 AV17OrderedDsc ,
                                                 AV67ToDate ,
                                                 AV66FromDate } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            lV70Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext), "%", "");
            lV70Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext), "%", "");
            lV70Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext), "%", "");
            lV70Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext), "%", "");
            lV70Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext), "%", "");
            lV71Leaverequestlistds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV71Leaverequestlistds_2_tfleavetypename), 100, "%");
            lV73Leaverequestlistds_4_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV73Leaverequestlistds_4_tfemployeename), 100, "%");
            lV79Leaverequestlistds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV79Leaverequestlistds_10_tfleaverequesthalfday), 20, "%");
            lV83Leaverequestlistds_14_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV83Leaverequestlistds_14_tfleaverequestdescription), "%", "");
            /* Using cursor H005F2 */
            pr_default.execute(0, new Object[] {AV67ToDate, AV66FromDate, lV70Leaverequestlistds_1_filterfulltext, lV70Leaverequestlistds_1_filterfulltext, lV70Leaverequestlistds_1_filterfulltext, lV70Leaverequestlistds_1_filterfulltext, lV70Leaverequestlistds_1_filterfulltext, lV71Leaverequestlistds_2_tfleavetypename, AV72Leaverequestlistds_3_tfleavetypename_sel, lV73Leaverequestlistds_4_tfemployeename, AV74Leaverequestlistds_5_tfemployeename_sel, AV75Leaverequestlistds_6_tfleaverequeststartdate, AV76Leaverequestlistds_7_tfleaverequeststartdate_to, AV77Leaverequestlistds_8_tfleaverequestenddate, AV78Leaverequestlistds_9_tfleaverequestenddate_to, lV79Leaverequestlistds_10_tfleaverequesthalfday, AV80Leaverequestlistds_11_tfleaverequesthalfday_sel, AV81Leaverequestlistds_12_tfleaverequestduration, AV82Leaverequestlistds_13_tfleaverequestduration_to, lV83Leaverequestlistds_14_tfleaverequestdescription, AV84Leaverequestlistds_15_tfleaverequestdescription_sel, AV64LeaveTypeId, AV65EmployeeId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_35_idx = 1;
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A144LeaveTypeVacationLeave = H005F2_A144LeaveTypeVacationLeave[0];
               A147EmployeeBalance = H005F2_A147EmployeeBalance[0];
               A106EmployeeId = H005F2_A106EmployeeId[0];
               A134LeaveRequestRejectionReason = H005F2_A134LeaveRequestRejectionReason[0];
               A133LeaveRequestDescription = H005F2_A133LeaveRequestDescription[0];
               A132LeaveRequestStatus = H005F2_A132LeaveRequestStatus[0];
               A131LeaveRequestDuration = H005F2_A131LeaveRequestDuration[0];
               A171LeaveRequestHalfDay = H005F2_A171LeaveRequestHalfDay[0];
               n171LeaveRequestHalfDay = H005F2_n171LeaveRequestHalfDay[0];
               A130LeaveRequestEndDate = H005F2_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = H005F2_A129LeaveRequestStartDate[0];
               A148EmployeeName = H005F2_A148EmployeeName[0];
               A128LeaveRequestDate = H005F2_A128LeaveRequestDate[0];
               A125LeaveTypeName = H005F2_A125LeaveTypeName[0];
               A124LeaveTypeId = H005F2_A124LeaveTypeId[0];
               A127LeaveRequestId = H005F2_A127LeaveRequestId[0];
               A147EmployeeBalance = H005F2_A147EmployeeBalance[0];
               A148EmployeeName = H005F2_A148EmployeeName[0];
               A144LeaveTypeVacationLeave = H005F2_A144LeaveTypeVacationLeave[0];
               A125LeaveTypeName = H005F2_A125LeaveTypeName[0];
               /* Execute user event: Grid.Load */
               E185F2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 35;
            WB5F0( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5F2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
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
         AV70Leaverequestlistds_1_filterfulltext = AV19FilterFullText;
         AV71Leaverequestlistds_2_tfleavetypename = AV30TFLeaveTypeName;
         AV72Leaverequestlistds_3_tfleavetypename_sel = AV31TFLeaveTypeName_Sel;
         AV73Leaverequestlistds_4_tfemployeename = AV32TFEmployeeName;
         AV74Leaverequestlistds_5_tfemployeename_sel = AV33TFEmployeeName_Sel;
         AV75Leaverequestlistds_6_tfleaverequeststartdate = AV34TFLeaveRequestStartDate;
         AV76Leaverequestlistds_7_tfleaverequeststartdate_to = AV35TFLeaveRequestStartDate_To;
         AV77Leaverequestlistds_8_tfleaverequestenddate = AV39TFLeaveRequestEndDate;
         AV78Leaverequestlistds_9_tfleaverequestenddate_to = AV40TFLeaveRequestEndDate_To;
         AV79Leaverequestlistds_10_tfleaverequesthalfday = AV44TFLeaveRequestHalfDay;
         AV80Leaverequestlistds_11_tfleaverequesthalfday_sel = AV45TFLeaveRequestHalfDay_Sel;
         AV81Leaverequestlistds_12_tfleaverequestduration = AV46TFLeaveRequestDuration;
         AV82Leaverequestlistds_13_tfleaverequestduration_to = AV47TFLeaveRequestDuration_To;
         AV83Leaverequestlistds_14_tfleaverequestdescription = AV50TFLeaveRequestDescription;
         AV84Leaverequestlistds_15_tfleaverequestdescription_sel = AV51TFLeaveRequestDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV70Leaverequestlistds_1_filterfulltext ,
                                              AV72Leaverequestlistds_3_tfleavetypename_sel ,
                                              AV71Leaverequestlistds_2_tfleavetypename ,
                                              AV74Leaverequestlistds_5_tfemployeename_sel ,
                                              AV73Leaverequestlistds_4_tfemployeename ,
                                              AV75Leaverequestlistds_6_tfleaverequeststartdate ,
                                              AV76Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                              AV77Leaverequestlistds_8_tfleaverequestenddate ,
                                              AV78Leaverequestlistds_9_tfleaverequestenddate_to ,
                                              AV80Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                              AV79Leaverequestlistds_10_tfleaverequesthalfday ,
                                              AV81Leaverequestlistds_12_tfleaverequestduration ,
                                              AV82Leaverequestlistds_13_tfleaverequestduration_to ,
                                              AV84Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                              AV83Leaverequestlistds_14_tfleaverequestdescription ,
                                              AV64LeaveTypeId ,
                                              AV65EmployeeId ,
                                              A125LeaveTypeName ,
                                              A148EmployeeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A124LeaveTypeId ,
                                              A106EmployeeId ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV67ToDate ,
                                              AV66FromDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV70Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext), "%", "");
         lV70Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext), "%", "");
         lV70Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext), "%", "");
         lV70Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext), "%", "");
         lV70Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext), "%", "");
         lV71Leaverequestlistds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV71Leaverequestlistds_2_tfleavetypename), 100, "%");
         lV73Leaverequestlistds_4_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV73Leaverequestlistds_4_tfemployeename), 100, "%");
         lV79Leaverequestlistds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV79Leaverequestlistds_10_tfleaverequesthalfday), 20, "%");
         lV83Leaverequestlistds_14_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV83Leaverequestlistds_14_tfleaverequestdescription), "%", "");
         /* Using cursor H005F3 */
         pr_default.execute(1, new Object[] {AV67ToDate, AV66FromDate, lV70Leaverequestlistds_1_filterfulltext, lV70Leaverequestlistds_1_filterfulltext, lV70Leaverequestlistds_1_filterfulltext, lV70Leaverequestlistds_1_filterfulltext, lV70Leaverequestlistds_1_filterfulltext, lV71Leaverequestlistds_2_tfleavetypename, AV72Leaverequestlistds_3_tfleavetypename_sel, lV73Leaverequestlistds_4_tfemployeename, AV74Leaverequestlistds_5_tfemployeename_sel, AV75Leaverequestlistds_6_tfleaverequeststartdate, AV76Leaverequestlistds_7_tfleaverequeststartdate_to, AV77Leaverequestlistds_8_tfleaverequestenddate, AV78Leaverequestlistds_9_tfleaverequestenddate_to, lV79Leaverequestlistds_10_tfleaverequesthalfday, AV80Leaverequestlistds_11_tfleaverequesthalfday_sel, AV81Leaverequestlistds_12_tfleaverequestduration, AV82Leaverequestlistds_13_tfleaverequestduration_to, lV83Leaverequestlistds_14_tfleaverequestdescription, AV84Leaverequestlistds_15_tfleaverequestdescription_sel, AV64LeaveTypeId, AV65EmployeeId});
         GRID_nRecordCount = H005F3_AGRID_nRecordCount[0];
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
         AV70Leaverequestlistds_1_filterfulltext = AV19FilterFullText;
         AV71Leaverequestlistds_2_tfleavetypename = AV30TFLeaveTypeName;
         AV72Leaverequestlistds_3_tfleavetypename_sel = AV31TFLeaveTypeName_Sel;
         AV73Leaverequestlistds_4_tfemployeename = AV32TFEmployeeName;
         AV74Leaverequestlistds_5_tfemployeename_sel = AV33TFEmployeeName_Sel;
         AV75Leaverequestlistds_6_tfleaverequeststartdate = AV34TFLeaveRequestStartDate;
         AV76Leaverequestlistds_7_tfleaverequeststartdate_to = AV35TFLeaveRequestStartDate_To;
         AV77Leaverequestlistds_8_tfleaverequestenddate = AV39TFLeaveRequestEndDate;
         AV78Leaverequestlistds_9_tfleaverequestenddate_to = AV40TFLeaveRequestEndDate_To;
         AV79Leaverequestlistds_10_tfleaverequesthalfday = AV44TFLeaveRequestHalfDay;
         AV80Leaverequestlistds_11_tfleaverequesthalfday_sel = AV45TFLeaveRequestHalfDay_Sel;
         AV81Leaverequestlistds_12_tfleaverequestduration = AV46TFLeaveRequestDuration;
         AV82Leaverequestlistds_13_tfleaverequestduration_to = AV47TFLeaveRequestDuration_To;
         AV83Leaverequestlistds_14_tfleaverequestdescription = AV50TFLeaveRequestDescription;
         AV84Leaverequestlistds_15_tfleaverequestdescription_sel = AV51TFLeaveRequestDescription_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV64LeaveTypeId, AV65EmployeeId, AV66FromDate, AV67ToDate, AV29ManageFiltersExecutionStep, AV69Pgmname, AV30TFLeaveTypeName, AV31TFLeaveTypeName_Sel, AV32TFEmployeeName, AV33TFEmployeeName_Sel, AV34TFLeaveRequestStartDate, AV35TFLeaveRequestStartDate_To, AV39TFLeaveRequestEndDate, AV40TFLeaveRequestEndDate_To, AV44TFLeaveRequestHalfDay, AV45TFLeaveRequestHalfDay_Sel, AV46TFLeaveRequestDuration, AV47TFLeaveRequestDuration_To, AV50TFLeaveRequestDescription, AV51TFLeaveRequestDescription_Sel, AV68CompanyLocationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV70Leaverequestlistds_1_filterfulltext = AV19FilterFullText;
         AV71Leaverequestlistds_2_tfleavetypename = AV30TFLeaveTypeName;
         AV72Leaverequestlistds_3_tfleavetypename_sel = AV31TFLeaveTypeName_Sel;
         AV73Leaverequestlistds_4_tfemployeename = AV32TFEmployeeName;
         AV74Leaverequestlistds_5_tfemployeename_sel = AV33TFEmployeeName_Sel;
         AV75Leaverequestlistds_6_tfleaverequeststartdate = AV34TFLeaveRequestStartDate;
         AV76Leaverequestlistds_7_tfleaverequeststartdate_to = AV35TFLeaveRequestStartDate_To;
         AV77Leaverequestlistds_8_tfleaverequestenddate = AV39TFLeaveRequestEndDate;
         AV78Leaverequestlistds_9_tfleaverequestenddate_to = AV40TFLeaveRequestEndDate_To;
         AV79Leaverequestlistds_10_tfleaverequesthalfday = AV44TFLeaveRequestHalfDay;
         AV80Leaverequestlistds_11_tfleaverequesthalfday_sel = AV45TFLeaveRequestHalfDay_Sel;
         AV81Leaverequestlistds_12_tfleaverequestduration = AV46TFLeaveRequestDuration;
         AV82Leaverequestlistds_13_tfleaverequestduration_to = AV47TFLeaveRequestDuration_To;
         AV83Leaverequestlistds_14_tfleaverequestdescription = AV50TFLeaveRequestDescription;
         AV84Leaverequestlistds_15_tfleaverequestdescription_sel = AV51TFLeaveRequestDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV64LeaveTypeId, AV65EmployeeId, AV66FromDate, AV67ToDate, AV29ManageFiltersExecutionStep, AV69Pgmname, AV30TFLeaveTypeName, AV31TFLeaveTypeName_Sel, AV32TFEmployeeName, AV33TFEmployeeName_Sel, AV34TFLeaveRequestStartDate, AV35TFLeaveRequestStartDate_To, AV39TFLeaveRequestEndDate, AV40TFLeaveRequestEndDate_To, AV44TFLeaveRequestHalfDay, AV45TFLeaveRequestHalfDay_Sel, AV46TFLeaveRequestDuration, AV47TFLeaveRequestDuration_To, AV50TFLeaveRequestDescription, AV51TFLeaveRequestDescription_Sel, AV68CompanyLocationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV70Leaverequestlistds_1_filterfulltext = AV19FilterFullText;
         AV71Leaverequestlistds_2_tfleavetypename = AV30TFLeaveTypeName;
         AV72Leaverequestlistds_3_tfleavetypename_sel = AV31TFLeaveTypeName_Sel;
         AV73Leaverequestlistds_4_tfemployeename = AV32TFEmployeeName;
         AV74Leaverequestlistds_5_tfemployeename_sel = AV33TFEmployeeName_Sel;
         AV75Leaverequestlistds_6_tfleaverequeststartdate = AV34TFLeaveRequestStartDate;
         AV76Leaverequestlistds_7_tfleaverequeststartdate_to = AV35TFLeaveRequestStartDate_To;
         AV77Leaverequestlistds_8_tfleaverequestenddate = AV39TFLeaveRequestEndDate;
         AV78Leaverequestlistds_9_tfleaverequestenddate_to = AV40TFLeaveRequestEndDate_To;
         AV79Leaverequestlistds_10_tfleaverequesthalfday = AV44TFLeaveRequestHalfDay;
         AV80Leaverequestlistds_11_tfleaverequesthalfday_sel = AV45TFLeaveRequestHalfDay_Sel;
         AV81Leaverequestlistds_12_tfleaverequestduration = AV46TFLeaveRequestDuration;
         AV82Leaverequestlistds_13_tfleaverequestduration_to = AV47TFLeaveRequestDuration_To;
         AV83Leaverequestlistds_14_tfleaverequestdescription = AV50TFLeaveRequestDescription;
         AV84Leaverequestlistds_15_tfleaverequestdescription_sel = AV51TFLeaveRequestDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV64LeaveTypeId, AV65EmployeeId, AV66FromDate, AV67ToDate, AV29ManageFiltersExecutionStep, AV69Pgmname, AV30TFLeaveTypeName, AV31TFLeaveTypeName_Sel, AV32TFEmployeeName, AV33TFEmployeeName_Sel, AV34TFLeaveRequestStartDate, AV35TFLeaveRequestStartDate_To, AV39TFLeaveRequestEndDate, AV40TFLeaveRequestEndDate_To, AV44TFLeaveRequestHalfDay, AV45TFLeaveRequestHalfDay_Sel, AV46TFLeaveRequestDuration, AV47TFLeaveRequestDuration_To, AV50TFLeaveRequestDescription, AV51TFLeaveRequestDescription_Sel, AV68CompanyLocationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV70Leaverequestlistds_1_filterfulltext = AV19FilterFullText;
         AV71Leaverequestlistds_2_tfleavetypename = AV30TFLeaveTypeName;
         AV72Leaverequestlistds_3_tfleavetypename_sel = AV31TFLeaveTypeName_Sel;
         AV73Leaverequestlistds_4_tfemployeename = AV32TFEmployeeName;
         AV74Leaverequestlistds_5_tfemployeename_sel = AV33TFEmployeeName_Sel;
         AV75Leaverequestlistds_6_tfleaverequeststartdate = AV34TFLeaveRequestStartDate;
         AV76Leaverequestlistds_7_tfleaverequeststartdate_to = AV35TFLeaveRequestStartDate_To;
         AV77Leaverequestlistds_8_tfleaverequestenddate = AV39TFLeaveRequestEndDate;
         AV78Leaverequestlistds_9_tfleaverequestenddate_to = AV40TFLeaveRequestEndDate_To;
         AV79Leaverequestlistds_10_tfleaverequesthalfday = AV44TFLeaveRequestHalfDay;
         AV80Leaverequestlistds_11_tfleaverequesthalfday_sel = AV45TFLeaveRequestHalfDay_Sel;
         AV81Leaverequestlistds_12_tfleaverequestduration = AV46TFLeaveRequestDuration;
         AV82Leaverequestlistds_13_tfleaverequestduration_to = AV47TFLeaveRequestDuration_To;
         AV83Leaverequestlistds_14_tfleaverequestdescription = AV50TFLeaveRequestDescription;
         AV84Leaverequestlistds_15_tfleaverequestdescription_sel = AV51TFLeaveRequestDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV64LeaveTypeId, AV65EmployeeId, AV66FromDate, AV67ToDate, AV29ManageFiltersExecutionStep, AV69Pgmname, AV30TFLeaveTypeName, AV31TFLeaveTypeName_Sel, AV32TFEmployeeName, AV33TFEmployeeName_Sel, AV34TFLeaveRequestStartDate, AV35TFLeaveRequestStartDate_To, AV39TFLeaveRequestEndDate, AV40TFLeaveRequestEndDate_To, AV44TFLeaveRequestHalfDay, AV45TFLeaveRequestHalfDay_Sel, AV46TFLeaveRequestDuration, AV47TFLeaveRequestDuration_To, AV50TFLeaveRequestDescription, AV51TFLeaveRequestDescription_Sel, AV68CompanyLocationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV70Leaverequestlistds_1_filterfulltext = AV19FilterFullText;
         AV71Leaverequestlistds_2_tfleavetypename = AV30TFLeaveTypeName;
         AV72Leaverequestlistds_3_tfleavetypename_sel = AV31TFLeaveTypeName_Sel;
         AV73Leaverequestlistds_4_tfemployeename = AV32TFEmployeeName;
         AV74Leaverequestlistds_5_tfemployeename_sel = AV33TFEmployeeName_Sel;
         AV75Leaverequestlistds_6_tfleaverequeststartdate = AV34TFLeaveRequestStartDate;
         AV76Leaverequestlistds_7_tfleaverequeststartdate_to = AV35TFLeaveRequestStartDate_To;
         AV77Leaverequestlistds_8_tfleaverequestenddate = AV39TFLeaveRequestEndDate;
         AV78Leaverequestlistds_9_tfleaverequestenddate_to = AV40TFLeaveRequestEndDate_To;
         AV79Leaverequestlistds_10_tfleaverequesthalfday = AV44TFLeaveRequestHalfDay;
         AV80Leaverequestlistds_11_tfleaverequesthalfday_sel = AV45TFLeaveRequestHalfDay_Sel;
         AV81Leaverequestlistds_12_tfleaverequestduration = AV46TFLeaveRequestDuration;
         AV82Leaverequestlistds_13_tfleaverequestduration_to = AV47TFLeaveRequestDuration_To;
         AV83Leaverequestlistds_14_tfleaverequestdescription = AV50TFLeaveRequestDescription;
         AV84Leaverequestlistds_15_tfleaverequestdescription_sel = AV51TFLeaveRequestDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV64LeaveTypeId, AV65EmployeeId, AV66FromDate, AV67ToDate, AV29ManageFiltersExecutionStep, AV69Pgmname, AV30TFLeaveTypeName, AV31TFLeaveTypeName_Sel, AV32TFEmployeeName, AV33TFEmployeeName_Sel, AV34TFLeaveRequestStartDate, AV35TFLeaveRequestStartDate_To, AV39TFLeaveRequestEndDate, AV40TFLeaveRequestEndDate_To, AV44TFLeaveRequestHalfDay, AV45TFLeaveRequestHalfDay_Sel, AV46TFLeaveRequestDuration, AV47TFLeaveRequestDuration_To, AV50TFLeaveRequestDescription, AV51TFLeaveRequestDescription_Sel, AV68CompanyLocationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV69Pgmname = "LeaveRequestList";
         edtLeaveRequestId_Enabled = 0;
         edtLeaveTypeId_Enabled = 0;
         edtLeaveTypeName_Enabled = 0;
         edtLeaveRequestDate_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         edtLeaveRequestStartDate_Enabled = 0;
         edtLeaveRequestEndDate_Enabled = 0;
         edtLeaveRequestHalfDay_Enabled = 0;
         edtLeaveRequestDuration_Enabled = 0;
         cmbLeaveRequestStatus.Enabled = 0;
         edtLeaveRequestDescription_Enabled = 0;
         edtLeaveRequestRejectionReason_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtEmployeeBalance_Enabled = 0;
         radLeaveTypeVacationLeave.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E165F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV27ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV60AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV54DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), ".", ","), 18, MidpointRounding.ToEven));
            AV58GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV59GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV9GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV36DDO_LeaveRequestStartDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTSTARTDATEAUXDATE"), 0);
            AV37DDO_LeaveRequestStartDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTSTARTDATEAUXDATETO"), 0);
            AV41DDO_LeaveRequestEndDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTENDDATEAUXDATE"), 0);
            AV42DDO_LeaveRequestEndDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTENDDATEAUXDATETO"), 0);
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
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV19FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            AV38DDO_LeaveRequestStartDateAuxDateText = cgiGet( edtavDdo_leaverequeststartdateauxdatetext_Internalname);
            AssignAttri("", false, "AV38DDO_LeaveRequestStartDateAuxDateText", AV38DDO_LeaveRequestStartDateAuxDateText);
            AV43DDO_LeaveRequestEndDateAuxDateText = cgiGet( edtavDdo_leaverequestenddateauxdatetext_Internalname);
            AssignAttri("", false, "AV43DDO_LeaveRequestEndDateAuxDateText", AV43DDO_LeaveRequestEndDateAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV16OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV17OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV19FilterFullText) != 0 )
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
         E165F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E165F2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFLEAVEREQUESTENDDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_leaverequestenddateauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFLEAVEREQUESTSTARTDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_leaverequeststartdateauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV11HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV60AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV61AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV61AGExportDataItem.gxTpr_Title = "Excel";
         AV61AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV61AGExportDataItem.gxTpr_Eventkey = "Export";
         AV61AGExportDataItem.gxTpr_Isdivider = false;
         AV60AGExportData.Add(AV61AGExportDataItem, 0);
         AV55GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV56GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV55GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Leave Request";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV16OrderedBy < 1 )
         {
            AV16OrderedBy = 1;
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV54DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV54DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E175F2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV29ManageFiltersExecutionStep == 1 )
         {
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV29ManageFiltersExecutionStep == 2 )
         {
            AV29ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV58GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV58GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV58GridCurrentPage), 10, 0));
         AV59GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV59GridPageCount", StringUtil.LTrimStr( (decimal)(AV59GridPageCount), 10, 0));
         GXt_char2 = AV9GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV69Pgmname, out  GXt_char2) ;
         AV9GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV9GridAppliedFilters", AV9GridAppliedFilters);
         AV70Leaverequestlistds_1_filterfulltext = AV19FilterFullText;
         AV71Leaverequestlistds_2_tfleavetypename = AV30TFLeaveTypeName;
         AV72Leaverequestlistds_3_tfleavetypename_sel = AV31TFLeaveTypeName_Sel;
         AV73Leaverequestlistds_4_tfemployeename = AV32TFEmployeeName;
         AV74Leaverequestlistds_5_tfemployeename_sel = AV33TFEmployeeName_Sel;
         AV75Leaverequestlistds_6_tfleaverequeststartdate = AV34TFLeaveRequestStartDate;
         AV76Leaverequestlistds_7_tfleaverequeststartdate_to = AV35TFLeaveRequestStartDate_To;
         AV77Leaverequestlistds_8_tfleaverequestenddate = AV39TFLeaveRequestEndDate;
         AV78Leaverequestlistds_9_tfleaverequestenddate_to = AV40TFLeaveRequestEndDate_To;
         AV79Leaverequestlistds_10_tfleaverequesthalfday = AV44TFLeaveRequestHalfDay;
         AV80Leaverequestlistds_11_tfleaverequesthalfday_sel = AV45TFLeaveRequestHalfDay_Sel;
         AV81Leaverequestlistds_12_tfleaverequestduration = AV46TFLeaveRequestDuration;
         AV82Leaverequestlistds_13_tfleaverequestduration_to = AV47TFLeaveRequestDuration_To;
         AV83Leaverequestlistds_14_tfleaverequestdescription = AV50TFLeaveRequestDescription;
         AV84Leaverequestlistds_15_tfleaverequestdescription_sel = AV51TFLeaveRequestDescription_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14GridState", AV14GridState);
      }

      protected void E125F2( )
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
            AV57PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV57PageToGo) ;
         }
      }

      protected void E135F2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E155F2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
            AV17OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveTypeName") == 0 )
            {
               AV30TFLeaveTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV30TFLeaveTypeName", AV30TFLeaveTypeName);
               AV31TFLeaveTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV31TFLeaveTypeName_Sel", AV31TFLeaveTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeName") == 0 )
            {
               AV32TFEmployeeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV32TFEmployeeName", AV32TFEmployeeName);
               AV33TFEmployeeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV33TFEmployeeName_Sel", AV33TFEmployeeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestStartDate") == 0 )
            {
               AV34TFLeaveRequestStartDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV34TFLeaveRequestStartDate", context.localUtil.Format(AV34TFLeaveRequestStartDate, "99/99/99"));
               AV35TFLeaveRequestStartDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV35TFLeaveRequestStartDate_To", context.localUtil.Format(AV35TFLeaveRequestStartDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestEndDate") == 0 )
            {
               AV39TFLeaveRequestEndDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV39TFLeaveRequestEndDate", context.localUtil.Format(AV39TFLeaveRequestEndDate, "99/99/99"));
               AV40TFLeaveRequestEndDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV40TFLeaveRequestEndDate_To", context.localUtil.Format(AV40TFLeaveRequestEndDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestHalfDay") == 0 )
            {
               AV44TFLeaveRequestHalfDay = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFLeaveRequestHalfDay", AV44TFLeaveRequestHalfDay);
               AV45TFLeaveRequestHalfDay_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFLeaveRequestHalfDay_Sel", AV45TFLeaveRequestHalfDay_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestDuration") == 0 )
            {
               AV46TFLeaveRequestDuration = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV46TFLeaveRequestDuration", StringUtil.LTrimStr( AV46TFLeaveRequestDuration, 4, 1));
               AV47TFLeaveRequestDuration_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV47TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV47TFLeaveRequestDuration_To, 4, 1));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestDescription") == 0 )
            {
               AV50TFLeaveRequestDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFLeaveRequestDescription", AV50TFLeaveRequestDescription);
               AV51TFLeaveRequestDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFLeaveRequestDescription_Sel", AV51TFLeaveRequestDescription_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E185F2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 35;
         }
         sendrow_352( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
         {
            DoAjaxLoad(35, GridRow);
         }
      }

      protected void E115F2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
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
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("LeaveRequestListFilters")),UrlEncode(StringUtil.RTrim(AV69Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("LeaveRequestListFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV28ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "LeaveRequestListFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV28ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV28ManageFiltersXml) ;
               AV14GridState.FromXml(AV28ManageFiltersXml, null, "", "");
               AV16OrderedBy = AV14GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
               AV17OrderedDsc = AV14GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14GridState", AV14GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
      }

      protected void E145F2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderedBy), 4, 0))+":"+(AV17OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV27ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "LeaveRequestListFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV27ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV19FilterFullText = "";
         AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
         AV30TFLeaveTypeName = "";
         AssignAttri("", false, "AV30TFLeaveTypeName", AV30TFLeaveTypeName);
         AV31TFLeaveTypeName_Sel = "";
         AssignAttri("", false, "AV31TFLeaveTypeName_Sel", AV31TFLeaveTypeName_Sel);
         AV32TFEmployeeName = "";
         AssignAttri("", false, "AV32TFEmployeeName", AV32TFEmployeeName);
         AV33TFEmployeeName_Sel = "";
         AssignAttri("", false, "AV33TFEmployeeName_Sel", AV33TFEmployeeName_Sel);
         AV34TFLeaveRequestStartDate = DateTime.MinValue;
         AssignAttri("", false, "AV34TFLeaveRequestStartDate", context.localUtil.Format(AV34TFLeaveRequestStartDate, "99/99/99"));
         AV35TFLeaveRequestStartDate_To = DateTime.MinValue;
         AssignAttri("", false, "AV35TFLeaveRequestStartDate_To", context.localUtil.Format(AV35TFLeaveRequestStartDate_To, "99/99/99"));
         AV39TFLeaveRequestEndDate = DateTime.MinValue;
         AssignAttri("", false, "AV39TFLeaveRequestEndDate", context.localUtil.Format(AV39TFLeaveRequestEndDate, "99/99/99"));
         AV40TFLeaveRequestEndDate_To = DateTime.MinValue;
         AssignAttri("", false, "AV40TFLeaveRequestEndDate_To", context.localUtil.Format(AV40TFLeaveRequestEndDate_To, "99/99/99"));
         AV44TFLeaveRequestHalfDay = "";
         AssignAttri("", false, "AV44TFLeaveRequestHalfDay", AV44TFLeaveRequestHalfDay);
         AV45TFLeaveRequestHalfDay_Sel = "";
         AssignAttri("", false, "AV45TFLeaveRequestHalfDay_Sel", AV45TFLeaveRequestHalfDay_Sel);
         AV46TFLeaveRequestDuration = 0;
         AssignAttri("", false, "AV46TFLeaveRequestDuration", StringUtil.LTrimStr( AV46TFLeaveRequestDuration, 4, 1));
         AV47TFLeaveRequestDuration_To = 0;
         AssignAttri("", false, "AV47TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV47TFLeaveRequestDuration_To, 4, 1));
         AV50TFLeaveRequestDescription = "";
         AssignAttri("", false, "AV50TFLeaveRequestDescription", AV50TFLeaveRequestDescription);
         AV51TFLeaveRequestDescription_Sel = "";
         AssignAttri("", false, "AV51TFLeaveRequestDescription_Sel", AV51TFLeaveRequestDescription_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get(AV69Pgmname+"GridState"), "") == 0 )
         {
            AV14GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV69Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV14GridState.FromXml(AV26Session.Get(AV69Pgmname+"GridState"), null, "", "");
         }
         AV16OrderedBy = AV14GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
         AV17OrderedDsc = AV14GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV14GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV14GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV14GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV14GridState.gxTpr_Filtervalues.Count )
         {
            AV15GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV14GridState.gxTpr_Filtervalues.Item(AV85GXV1));
            if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV30TFLeaveTypeName = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFLeaveTypeName", AV30TFLeaveTypeName);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV31TFLeaveTypeName_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFLeaveTypeName_Sel", AV31TFLeaveTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV32TFEmployeeName = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFEmployeeName", AV32TFEmployeeName);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV33TFEmployeeName_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFEmployeeName_Sel", AV33TFEmployeeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV34TFLeaveRequestStartDate = context.localUtil.CToD( AV15GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV34TFLeaveRequestStartDate", context.localUtil.Format(AV34TFLeaveRequestStartDate, "99/99/99"));
               AV35TFLeaveRequestStartDate_To = context.localUtil.CToD( AV15GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV35TFLeaveRequestStartDate_To", context.localUtil.Format(AV35TFLeaveRequestStartDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV39TFLeaveRequestEndDate = context.localUtil.CToD( AV15GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV39TFLeaveRequestEndDate", context.localUtil.Format(AV39TFLeaveRequestEndDate, "99/99/99"));
               AV40TFLeaveRequestEndDate_To = context.localUtil.CToD( AV15GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV40TFLeaveRequestEndDate_To", context.localUtil.Format(AV40TFLeaveRequestEndDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV44TFLeaveRequestHalfDay = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFLeaveRequestHalfDay", AV44TFLeaveRequestHalfDay);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV45TFLeaveRequestHalfDay_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFLeaveRequestHalfDay_Sel", AV45TFLeaveRequestHalfDay_Sel);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV46TFLeaveRequestDuration = NumberUtil.Val( AV15GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV46TFLeaveRequestDuration", StringUtil.LTrimStr( AV46TFLeaveRequestDuration, 4, 1));
               AV47TFLeaveRequestDuration_To = NumberUtil.Val( AV15GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV47TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV47TFLeaveRequestDuration_To, 4, 1));
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION") == 0 )
            {
               AV50TFLeaveRequestDescription = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFLeaveRequestDescription", AV50TFLeaveRequestDescription);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION_SEL") == 0 )
            {
               AV51TFLeaveRequestDescription_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFLeaveRequestDescription_Sel", AV51TFLeaveRequestDescription_Sel);
            }
            AV85GXV1 = (int)(AV85GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFLeaveTypeName_Sel)),  AV31TFLeaveTypeName_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEmployeeName_Sel)),  AV33TFEmployeeName_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFLeaveRequestHalfDay_Sel)),  AV45TFLeaveRequestHalfDay_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFLeaveRequestDescription_Sel)),  AV51TFLeaveRequestDescription_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|||"+GXt_char5+"||"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFLeaveTypeName)),  AV30TFLeaveTypeName, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFEmployeeName)),  AV32TFEmployeeName, out  GXt_char5) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFLeaveRequestHalfDay)),  AV44TFLeaveRequestHalfDay, out  GXt_char4) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFLeaveRequestDescription)),  AV50TFLeaveRequestDescription, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+((DateTime.MinValue==AV34TFLeaveRequestStartDate) ? "" : context.localUtil.DToC( AV34TFLeaveRequestStartDate, 2, "/"))+"|"+((DateTime.MinValue==AV39TFLeaveRequestEndDate) ? "" : context.localUtil.DToC( AV39TFLeaveRequestEndDate, 2, "/"))+"|"+GXt_char4+"|"+((Convert.ToDecimal(0)==AV46TFLeaveRequestDuration) ? "" : StringUtil.Str( AV46TFLeaveRequestDuration, 4, 1))+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV35TFLeaveRequestStartDate_To) ? "" : context.localUtil.DToC( AV35TFLeaveRequestStartDate_To, 2, "/"))+"|"+((DateTime.MinValue==AV40TFLeaveRequestEndDate_To) ? "" : context.localUtil.DToC( AV40TFLeaveRequestEndDate_To, 2, "/"))+"||"+((Convert.ToDecimal(0)==AV47TFLeaveRequestDuration_To) ? "" : StringUtil.Str( AV47TFLeaveRequestDuration_To, 4, 1))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV14GridState.FromXml(AV26Session.Get(AV69Pgmname+"GridState"), null, "", "");
         AV14GridState.gxTpr_Orderedby = AV16OrderedBy;
         AV14GridState.gxTpr_Ordereddsc = AV17OrderedDsc;
         AV14GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV14GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)),  0,  AV19FilterFullText,  AV19FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFLEAVETYPENAME",  "Type Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFLeaveTypeName)),  0,  AV30TFLeaveTypeName,  AV30TFLeaveTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFLeaveTypeName_Sel)),  AV31TFLeaveTypeName_Sel,  AV31TFLeaveTypeName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFEMPLOYEENAME",  "Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFEmployeeName)),  0,  AV32TFEmployeeName,  AV32TFEmployeeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFEmployeeName_Sel)),  AV33TFEmployeeName_Sel,  AV33TFEmployeeName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV14GridState,  "TFLEAVEREQUESTSTARTDATE",  "Start Date",  !((DateTime.MinValue==AV34TFLeaveRequestStartDate)&&(DateTime.MinValue==AV35TFLeaveRequestStartDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV34TFLeaveRequestStartDate, 2, "/")),  ((DateTime.MinValue==AV34TFLeaveRequestStartDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV34TFLeaveRequestStartDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV35TFLeaveRequestStartDate_To, 2, "/")),  ((DateTime.MinValue==AV35TFLeaveRequestStartDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV35TFLeaveRequestStartDate_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV14GridState,  "TFLEAVEREQUESTENDDATE",  "End Date",  !((DateTime.MinValue==AV39TFLeaveRequestEndDate)&&(DateTime.MinValue==AV40TFLeaveRequestEndDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV39TFLeaveRequestEndDate, 2, "/")),  ((DateTime.MinValue==AV39TFLeaveRequestEndDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFLeaveRequestEndDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV40TFLeaveRequestEndDate_To, 2, "/")),  ((DateTime.MinValue==AV40TFLeaveRequestEndDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV40TFLeaveRequestEndDate_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFLEAVEREQUESTHALFDAY",  "Half Day",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFLeaveRequestHalfDay)),  0,  AV44TFLeaveRequestHalfDay,  AV44TFLeaveRequestHalfDay,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFLeaveRequestHalfDay_Sel)),  AV45TFLeaveRequestHalfDay_Sel,  AV45TFLeaveRequestHalfDay_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV14GridState,  "TFLEAVEREQUESTDURATION",  "Request Duration",  !((Convert.ToDecimal(0)==AV46TFLeaveRequestDuration)&&(Convert.ToDecimal(0)==AV47TFLeaveRequestDuration_To)),  0,  StringUtil.Trim( StringUtil.Str( AV46TFLeaveRequestDuration, 4, 1)),  ((Convert.ToDecimal(0)==AV46TFLeaveRequestDuration) ? "" : StringUtil.Trim( context.localUtil.Format( AV46TFLeaveRequestDuration, "Z9.9"))),  true,  StringUtil.Trim( StringUtil.Str( AV47TFLeaveRequestDuration_To, 4, 1)),  ((Convert.ToDecimal(0)==AV47TFLeaveRequestDuration_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV47TFLeaveRequestDuration_To, "Z9.9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFLEAVEREQUESTDESCRIPTION",  "Request Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFLeaveRequestDescription)),  0,  AV50TFLeaveRequestDescription,  AV50TFLeaveRequestDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFLeaveRequestDescription_Sel)),  AV51TFLeaveRequestDescription_Sel,  AV51TFLeaveRequestDescription_Sel) ;
         if ( ! (0==AV64LeaveTypeId) )
         {
            AV15GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV15GridStateFilterValue.gxTpr_Name = "PARM_&LEAVETYPEID";
            AV15GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV64LeaveTypeId), 10, 0);
            AV14GridState.gxTpr_Filtervalues.Add(AV15GridStateFilterValue, 0);
         }
         if ( ! (0==AV65EmployeeId) )
         {
            AV15GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV15GridStateFilterValue.gxTpr_Name = "PARM_&EMPLOYEEID";
            AV15GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV65EmployeeId), 10, 0);
            AV14GridState.gxTpr_Filtervalues.Add(AV15GridStateFilterValue, 0);
         }
         if ( ! (DateTime.MinValue==AV66FromDate) )
         {
            AV15GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV15GridStateFilterValue.gxTpr_Name = "PARM_&FROMDATE";
            AV15GridStateFilterValue.gxTpr_Value = context.localUtil.DToC( AV66FromDate, 2, "/");
            AV14GridState.gxTpr_Filtervalues.Add(AV15GridStateFilterValue, 0);
         }
         if ( ! (DateTime.MinValue==AV67ToDate) )
         {
            AV15GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV15GridStateFilterValue.gxTpr_Name = "PARM_&TODATE";
            AV15GridStateFilterValue.gxTpr_Value = context.localUtil.DToC( AV67ToDate, 2, "/");
            AV14GridState.gxTpr_Filtervalues.Add(AV15GridStateFilterValue, 0);
         }
         if ( ! (0==AV68CompanyLocationId) )
         {
            AV15GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV15GridStateFilterValue.gxTpr_Name = "PARM_&COMPANYLOCATIONID";
            AV15GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV68CompanyLocationId), 10, 0);
            AV14GridState.gxTpr_Filtervalues.Add(AV15GridStateFilterValue, 0);
         }
         AV14GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV14GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV14GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12TrnContext.gxTpr_Callerobject = AV69Pgmname;
         AV12TrnContext.gxTpr_Callerondelete = true;
         AV12TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV12TrnContext.gxTpr_Transactionname = "LeaveRequest";
         AV26Session.Set("TrnContext", AV12TrnContext.ToXml(false, true, "", ""));
      }

      protected void S182( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         new leaverequestlistexport(context ).execute( out  AV20ExcelFilename, out  AV21ErrorMessage) ;
         if ( StringUtil.StrCmp(AV20ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV20ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV21ErrorMessage);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV64LeaveTypeId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV64LeaveTypeId", StringUtil.LTrimStr( (decimal)(AV64LeaveTypeId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVETYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV64LeaveTypeId), "ZZZZZZZZZ9"), context));
         AV65EmployeeId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV65EmployeeId", StringUtil.LTrimStr( (decimal)(AV65EmployeeId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65EmployeeId), "ZZZZZZZZZ9"), context));
         AV66FromDate = (DateTime)getParm(obj,2);
         AssignAttri("", false, "AV66FromDate", context.localUtil.Format(AV66FromDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_vFROMDATE", GetSecureSignedToken( "", AV66FromDate, context));
         AV67ToDate = (DateTime)getParm(obj,3);
         AssignAttri("", false, "AV67ToDate", context.localUtil.Format(AV67ToDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODATE", GetSecureSignedToken( "", AV67ToDate, context));
         AV68CompanyLocationId = Convert.ToInt64(getParm(obj,4));
         AssignAttri("", false, "AV68CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV68CompanyLocationId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMPANYLOCATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV68CompanyLocationId), "ZZZZZZZZZ9"), context));
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
         PA5F2( ) ;
         WS5F2( ) ;
         WE5F2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025627530776", true, true);
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
         context.AddJavascriptSource("leaverequestlist.js", "?2025627530780", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_352( )
      {
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID_"+sGXsfl_35_idx;
         edtLeaveTypeId_Internalname = "LEAVETYPEID_"+sGXsfl_35_idx;
         edtLeaveTypeName_Internalname = "LEAVETYPENAME_"+sGXsfl_35_idx;
         edtLeaveRequestDate_Internalname = "LEAVEREQUESTDATE_"+sGXsfl_35_idx;
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_35_idx;
         edtLeaveRequestStartDate_Internalname = "LEAVEREQUESTSTARTDATE_"+sGXsfl_35_idx;
         edtLeaveRequestEndDate_Internalname = "LEAVEREQUESTENDDATE_"+sGXsfl_35_idx;
         edtLeaveRequestHalfDay_Internalname = "LEAVEREQUESTHALFDAY_"+sGXsfl_35_idx;
         edtLeaveRequestDuration_Internalname = "LEAVEREQUESTDURATION_"+sGXsfl_35_idx;
         cmbLeaveRequestStatus_Internalname = "LEAVEREQUESTSTATUS_"+sGXsfl_35_idx;
         edtLeaveRequestDescription_Internalname = "LEAVEREQUESTDESCRIPTION_"+sGXsfl_35_idx;
         edtLeaveRequestRejectionReason_Internalname = "LEAVEREQUESTREJECTIONREASON_"+sGXsfl_35_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_35_idx;
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE_"+sGXsfl_35_idx;
         radLeaveTypeVacationLeave_Internalname = "LEAVETYPEVACATIONLEAVE_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID_"+sGXsfl_35_fel_idx;
         edtLeaveTypeId_Internalname = "LEAVETYPEID_"+sGXsfl_35_fel_idx;
         edtLeaveTypeName_Internalname = "LEAVETYPENAME_"+sGXsfl_35_fel_idx;
         edtLeaveRequestDate_Internalname = "LEAVEREQUESTDATE_"+sGXsfl_35_fel_idx;
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_35_fel_idx;
         edtLeaveRequestStartDate_Internalname = "LEAVEREQUESTSTARTDATE_"+sGXsfl_35_fel_idx;
         edtLeaveRequestEndDate_Internalname = "LEAVEREQUESTENDDATE_"+sGXsfl_35_fel_idx;
         edtLeaveRequestHalfDay_Internalname = "LEAVEREQUESTHALFDAY_"+sGXsfl_35_fel_idx;
         edtLeaveRequestDuration_Internalname = "LEAVEREQUESTDURATION_"+sGXsfl_35_fel_idx;
         cmbLeaveRequestStatus_Internalname = "LEAVEREQUESTSTATUS_"+sGXsfl_35_fel_idx;
         edtLeaveRequestDescription_Internalname = "LEAVEREQUESTDESCRIPTION_"+sGXsfl_35_fel_idx;
         edtLeaveRequestRejectionReason_Internalname = "LEAVEREQUESTREJECTIONREASON_"+sGXsfl_35_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_35_fel_idx;
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE_"+sGXsfl_35_fel_idx;
         radLeaveTypeVacationLeave_Internalname = "LEAVETYPEVACATIONLEAVE_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         WB5F0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_35_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_35_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveTypeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A124LeaveTypeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A124LeaveTypeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveTypeName_Internalname,StringUtil.RTrim( A125LeaveTypeName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDate_Internalname,context.localUtil.Format(A128LeaveRequestDate, "99/99/99"),context.localUtil.Format( A128LeaveRequestDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,StringUtil.RTrim( A148EmployeeName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestStartDate_Internalname,context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"),context.localUtil.Format( A129LeaveRequestStartDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestStartDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestEndDate_Internalname,context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"),context.localUtil.Format( A130LeaveRequestEndDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestEndDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestHalfDay_Internalname,StringUtil.RTrim( A171LeaveRequestHalfDay),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestHalfDay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDuration_Internalname,StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", "")),StringUtil.LTrim( context.localUtil.Format( A131LeaveRequestDuration, "Z9.9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDuration_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbLeaveRequestStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "LEAVEREQUESTSTATUS_" + sGXsfl_35_idx;
               cmbLeaveRequestStatus.Name = GXCCtl;
               cmbLeaveRequestStatus.WebTags = "";
               cmbLeaveRequestStatus.addItem("Pending", "Pending", 0);
               cmbLeaveRequestStatus.addItem("Approved", "Approved", 0);
               cmbLeaveRequestStatus.addItem("Rejected", "Rejected", 0);
               if ( cmbLeaveRequestStatus.ItemCount > 0 )
               {
                  A132LeaveRequestStatus = cmbLeaveRequestStatus.getValidValue(A132LeaveRequestStatus);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbLeaveRequestStatus,(string)cmbLeaveRequestStatus_Internalname,StringUtil.RTrim( A132LeaveRequestStatus),(short)1,(string)cmbLeaveRequestStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbLeaveRequestStatus.CurrentValue = StringUtil.RTrim( A132LeaveRequestStatus);
            AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Values", (string)(cmbLeaveRequestStatus.ToJavascriptSource()), !bGXsfl_35_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDescription_Internalname,(string)A133LeaveRequestDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestRejectionReason_Internalname,(string)A134LeaveRequestRejectionReason,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestRejectionReason_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeBalance_Internalname,StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")),StringUtil.LTrim( context.localUtil.Format( A147EmployeeBalance, "Z9.9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeBalance_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            if ( ( radLeaveTypeVacationLeave.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "LEAVETYPEVACATIONLEAVE_" + sGXsfl_35_idx;
               radLeaveTypeVacationLeave.Name = GXCCtl;
               radLeaveTypeVacationLeave.WebTags = "";
               radLeaveTypeVacationLeave.addItem("No", "No", 0);
               radLeaveTypeVacationLeave.addItem("Yes", "Yes", 0);
            }
            GridRow.AddColumnProperties("radio", 2, isAjaxCallMode( ), new Object[] {(GXRadio)radLeaveTypeVacationLeave,(string)radLeaveTypeVacationLeave_Internalname,StringUtil.RTrim( A144LeaveTypeVacationLeave),(string)"",(short)0,(short)0,(short)0,(short)0,(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(short)0,(string)radLeaveTypeVacationLeave_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)""});
            send_integrity_lvl_hashes5F2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         /* End function sendrow_352 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "LEAVEREQUESTSTATUS_" + sGXsfl_35_idx;
         cmbLeaveRequestStatus.Name = GXCCtl;
         cmbLeaveRequestStatus.WebTags = "";
         cmbLeaveRequestStatus.addItem("Pending", "Pending", 0);
         cmbLeaveRequestStatus.addItem("Approved", "Approved", 0);
         cmbLeaveRequestStatus.addItem("Rejected", "Rejected", 0);
         if ( cmbLeaveRequestStatus.ItemCount > 0 )
         {
            A132LeaveRequestStatus = cmbLeaveRequestStatus.getValidValue(A132LeaveRequestStatus);
         }
         GXCCtl = "LEAVETYPEVACATIONLEAVE_" + sGXsfl_35_idx;
         radLeaveTypeVacationLeave.Name = GXCCtl;
         radLeaveTypeVacationLeave.WebTags = "";
         radLeaveTypeVacationLeave.addItem("No", "No", 0);
         radLeaveTypeVacationLeave.addItem("Yes", "Yes", 0);
         /* End function init_web_controls */
      }

      protected void StartGridControl35( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"35\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Request Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Type Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Type Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Request Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Start Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "End Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Half Day") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Request Duration") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Request Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Request Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Rejection Reason") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Balance") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Vacation Leave") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A124LeaveTypeId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A125LeaveTypeName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A128LeaveRequestDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A148EmployeeName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A171LeaveRequestHalfDay)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A132LeaveRequestStatus)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A133LeaveRequestDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A134LeaveRequestRejectionReason));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A144LeaveTypeVacationLeave)));
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
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID";
         edtLeaveTypeId_Internalname = "LEAVETYPEID";
         edtLeaveTypeName_Internalname = "LEAVETYPENAME";
         edtLeaveRequestDate_Internalname = "LEAVEREQUESTDATE";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         edtLeaveRequestStartDate_Internalname = "LEAVEREQUESTSTARTDATE";
         edtLeaveRequestEndDate_Internalname = "LEAVEREQUESTENDDATE";
         edtLeaveRequestHalfDay_Internalname = "LEAVEREQUESTHALFDAY";
         edtLeaveRequestDuration_Internalname = "LEAVEREQUESTDURATION";
         cmbLeaveRequestStatus_Internalname = "LEAVEREQUESTSTATUS";
         edtLeaveRequestDescription_Internalname = "LEAVEREQUESTDESCRIPTION";
         edtLeaveRequestRejectionReason_Internalname = "LEAVEREQUESTREJECTIONREASON";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE";
         radLeaveTypeVacationLeave_Internalname = "LEAVETYPEVACATIONLEAVE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_leaverequeststartdateauxdatetext_Internalname = "vDDO_LEAVEREQUESTSTARTDATEAUXDATETEXT";
         Tfleaverequeststartdate_rangepicker_Internalname = "TFLEAVEREQUESTSTARTDATE_RANGEPICKER";
         divDdo_leaverequeststartdateauxdates_Internalname = "DDO_LEAVEREQUESTSTARTDATEAUXDATES";
         edtavDdo_leaverequestenddateauxdatetext_Internalname = "vDDO_LEAVEREQUESTENDDATEAUXDATETEXT";
         Tfleaverequestenddate_rangepicker_Internalname = "TFLEAVEREQUESTENDDATE_RANGEPICKER";
         divDdo_leaverequestenddateauxdates_Internalname = "DDO_LEAVEREQUESTENDDATEAUXDATES";
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
         radLeaveTypeVacationLeave_Jsonclick = "";
         edtEmployeeBalance_Jsonclick = "";
         edtEmployeeId_Jsonclick = "";
         edtLeaveRequestRejectionReason_Jsonclick = "";
         edtLeaveRequestDescription_Jsonclick = "";
         cmbLeaveRequestStatus_Jsonclick = "";
         edtLeaveRequestDuration_Jsonclick = "";
         edtLeaveRequestHalfDay_Jsonclick = "";
         edtLeaveRequestEndDate_Jsonclick = "";
         edtLeaveRequestStartDate_Jsonclick = "";
         edtEmployeeName_Jsonclick = "";
         edtLeaveRequestDate_Jsonclick = "";
         edtLeaveTypeName_Jsonclick = "";
         edtLeaveTypeId_Jsonclick = "";
         edtLeaveRequestId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         radLeaveTypeVacationLeave.Enabled = 0;
         edtEmployeeBalance_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtLeaveRequestRejectionReason_Enabled = 0;
         edtLeaveRequestDescription_Enabled = 0;
         cmbLeaveRequestStatus.Enabled = 0;
         edtLeaveRequestDuration_Enabled = 0;
         edtLeaveRequestHalfDay_Enabled = 0;
         edtLeaveRequestEndDate_Enabled = 0;
         edtLeaveRequestStartDate_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         edtLeaveRequestDate_Enabled = 0;
         edtLeaveTypeName_Enabled = 0;
         edtLeaveTypeId_Enabled = 0;
         edtLeaveRequestId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_leaverequestenddateauxdatetext_Jsonclick = "";
         edtavDdo_leaverequeststartdateauxdatetext_Jsonclick = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|||||4.1|";
         Ddo_grid_Datalistproc = "LeaveRequestListGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|||Dynamic||Dynamic";
         Ddo_grid_Includedatalist = "T|T|||T||T";
         Ddo_grid_Filterisrange = "||P|P||T|";
         Ddo_grid_Filtertype = "Character|Character|Date|Date|Character|Numeric|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8";
         Ddo_grid_Columnids = "2:LeaveTypeName|4:EmployeeName|5:LeaveRequestStartDate|6:LeaveRequestEndDate|7:LeaveRequestHalfDay|8:LeaveRequestDuration|10:LeaveRequestDescription";
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
         Form.Caption = " Leave Request";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV64LeaveTypeId","fld":"vLEAVETYPEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV65EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV66FromDate","fld":"vFROMDATE","hsh":true},{"av":"AV67ToDate","fld":"vTODATE","hsh":true},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV31TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV32TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV33TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV34TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV35TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV39TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV40TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV44TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV45TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV46TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV47TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV50TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV51TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV68CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV14GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E125F2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV64LeaveTypeId","fld":"vLEAVETYPEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV65EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV66FromDate","fld":"vFROMDATE","hsh":true},{"av":"AV67ToDate","fld":"vTODATE","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV31TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV32TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV33TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV34TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV35TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV39TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV40TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV44TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV45TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV46TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV47TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV50TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV51TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV68CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E135F2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV64LeaveTypeId","fld":"vLEAVETYPEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV65EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV66FromDate","fld":"vFROMDATE","hsh":true},{"av":"AV67ToDate","fld":"vTODATE","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV31TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV32TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV33TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV34TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV35TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV39TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV40TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV44TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV45TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV46TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV47TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV50TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV51TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV68CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E155F2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV64LeaveTypeId","fld":"vLEAVETYPEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV65EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV66FromDate","fld":"vFROMDATE","hsh":true},{"av":"AV67ToDate","fld":"vTODATE","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV31TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV32TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV33TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV34TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV35TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV39TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV40TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV44TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV45TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV46TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV47TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV50TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV51TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV68CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV50TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV51TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV46TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV47TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV44TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV45TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV39TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV40TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV34TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV35TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV32TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV33TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV30TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV31TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E185F2","iparms":[]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E115F2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV64LeaveTypeId","fld":"vLEAVETYPEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV65EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV66FromDate","fld":"vFROMDATE","hsh":true},{"av":"AV67ToDate","fld":"vTODATE","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV31TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV32TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV33TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV34TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV35TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV39TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV40TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV44TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV45TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV46TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV47TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV50TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV51TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV68CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV14GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV14GridState","fld":"vGRIDSTATE"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV30TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV31TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV32TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV33TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV34TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV35TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV39TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV40TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV44TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV45TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV46TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV47TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV50TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV51TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV58GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV59GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","""{"handler":"E145F2","iparms":[{"av":"Ddo_agexport_Activeeventkey","ctrl":"DDO_AGEXPORT","prop":"ActiveEventKey"}]}""");
         setEventMetadata("VALID_LEAVETYPEID","""{"handler":"Valid_Leavetypeid","iparms":[]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Leavetypevacationleave","iparms":[]}""");
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
         wcpOAV66FromDate = DateTime.MinValue;
         wcpOAV67ToDate = DateTime.MinValue;
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV19FilterFullText = "";
         AV69Pgmname = "";
         AV30TFLeaveTypeName = "";
         AV31TFLeaveTypeName_Sel = "";
         AV32TFEmployeeName = "";
         AV33TFEmployeeName_Sel = "";
         AV34TFLeaveRequestStartDate = DateTime.MinValue;
         AV35TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV39TFLeaveRequestEndDate = DateTime.MinValue;
         AV40TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV44TFLeaveRequestHalfDay = "";
         AV45TFLeaveRequestHalfDay_Sel = "";
         AV50TFLeaveRequestDescription = "";
         AV51TFLeaveRequestDescription_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV27ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV9GridAppliedFilters = "";
         AV60AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV54DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV36DDO_LeaveRequestStartDateAuxDate = DateTime.MinValue;
         AV37DDO_LeaveRequestStartDateAuxDateTo = DateTime.MinValue;
         AV41DDO_LeaveRequestEndDateAuxDate = DateTime.MinValue;
         AV42DDO_LeaveRequestEndDateAuxDateTo = DateTime.MinValue;
         AV14GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnagexport_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV38DDO_LeaveRequestStartDateAuxDateText = "";
         ucTfleaverequeststartdate_rangepicker = new GXUserControl();
         AV43DDO_LeaveRequestEndDateAuxDateText = "";
         ucTfleaverequestenddate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A125LeaveTypeName = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A148EmployeeName = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A171LeaveRequestHalfDay = "";
         A132LeaveRequestStatus = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         A144LeaveTypeVacationLeave = "";
         lV70Leaverequestlistds_1_filterfulltext = "";
         lV71Leaverequestlistds_2_tfleavetypename = "";
         lV73Leaverequestlistds_4_tfemployeename = "";
         lV79Leaverequestlistds_10_tfleaverequesthalfday = "";
         lV83Leaverequestlistds_14_tfleaverequestdescription = "";
         AV70Leaverequestlistds_1_filterfulltext = "";
         AV72Leaverequestlistds_3_tfleavetypename_sel = "";
         AV71Leaverequestlistds_2_tfleavetypename = "";
         AV74Leaverequestlistds_5_tfemployeename_sel = "";
         AV73Leaverequestlistds_4_tfemployeename = "";
         AV75Leaverequestlistds_6_tfleaverequeststartdate = DateTime.MinValue;
         AV76Leaverequestlistds_7_tfleaverequeststartdate_to = DateTime.MinValue;
         AV77Leaverequestlistds_8_tfleaverequestenddate = DateTime.MinValue;
         AV78Leaverequestlistds_9_tfleaverequestenddate_to = DateTime.MinValue;
         AV80Leaverequestlistds_11_tfleaverequesthalfday_sel = "";
         AV79Leaverequestlistds_10_tfleaverequesthalfday = "";
         AV84Leaverequestlistds_15_tfleaverequestdescription_sel = "";
         AV83Leaverequestlistds_14_tfleaverequestdescription = "";
         H005F2_A144LeaveTypeVacationLeave = new string[] {""} ;
         H005F2_A147EmployeeBalance = new decimal[1] ;
         H005F2_A106EmployeeId = new long[1] ;
         H005F2_A134LeaveRequestRejectionReason = new string[] {""} ;
         H005F2_A133LeaveRequestDescription = new string[] {""} ;
         H005F2_A132LeaveRequestStatus = new string[] {""} ;
         H005F2_A131LeaveRequestDuration = new decimal[1] ;
         H005F2_A171LeaveRequestHalfDay = new string[] {""} ;
         H005F2_n171LeaveRequestHalfDay = new bool[] {false} ;
         H005F2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         H005F2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         H005F2_A148EmployeeName = new string[] {""} ;
         H005F2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         H005F2_A125LeaveTypeName = new string[] {""} ;
         H005F2_A124LeaveTypeId = new long[1] ;
         H005F2_A127LeaveRequestId = new long[1] ;
         H005F3_AGRID_nRecordCount = new long[1] ;
         AV11HTTPRequest = new GxHttpRequest( context);
         AV61AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV55GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV56GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV28ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV26Session = context.GetSession();
         AV15GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV20ExcelFilename = "";
         AV21ErrorMessage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestlist__default(),
            new Object[][] {
                new Object[] {
               H005F2_A144LeaveTypeVacationLeave, H005F2_A147EmployeeBalance, H005F2_A106EmployeeId, H005F2_A134LeaveRequestRejectionReason, H005F2_A133LeaveRequestDescription, H005F2_A132LeaveRequestStatus, H005F2_A131LeaveRequestDuration, H005F2_A171LeaveRequestHalfDay, H005F2_n171LeaveRequestHalfDay, H005F2_A130LeaveRequestEndDate,
               H005F2_A129LeaveRequestStartDate, H005F2_A148EmployeeName, H005F2_A128LeaveRequestDate, H005F2_A125LeaveTypeName, H005F2_A124LeaveTypeId, H005F2_A127LeaveRequestId
               }
               , new Object[] {
               H005F3_AGRID_nRecordCount
               }
            }
         );
         AV69Pgmname = "LeaveRequestList";
         /* GeneXus formulas. */
         AV69Pgmname = "LeaveRequestList";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16OrderedBy ;
      private short AV29ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
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
      private int nRC_GXsfl_35 ;
      private int nGXsfl_35_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtLeaveRequestId_Enabled ;
      private int edtLeaveTypeId_Enabled ;
      private int edtLeaveTypeName_Enabled ;
      private int edtLeaveRequestDate_Enabled ;
      private int edtEmployeeName_Enabled ;
      private int edtLeaveRequestStartDate_Enabled ;
      private int edtLeaveRequestEndDate_Enabled ;
      private int edtLeaveRequestHalfDay_Enabled ;
      private int edtLeaveRequestDuration_Enabled ;
      private int edtLeaveRequestDescription_Enabled ;
      private int edtLeaveRequestRejectionReason_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeBalance_Enabled ;
      private int AV57PageToGo ;
      private int AV85GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV64LeaveTypeId ;
      private long AV65EmployeeId ;
      private long AV68CompanyLocationId ;
      private long wcpOAV64LeaveTypeId ;
      private long wcpOAV65EmployeeId ;
      private long wcpOAV68CompanyLocationId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV58GridCurrentPage ;
      private long AV59GridPageCount ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV46TFLeaveRequestDuration ;
      private decimal AV47TFLeaveRequestDuration_To ;
      private decimal A131LeaveRequestDuration ;
      private decimal A147EmployeeBalance ;
      private decimal AV81Leaverequestlistds_12_tfleaverequestduration ;
      private decimal AV82Leaverequestlistds_13_tfleaverequestduration_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_35_idx="0001" ;
      private string AV69Pgmname ;
      private string AV30TFLeaveTypeName ;
      private string AV31TFLeaveTypeName_Sel ;
      private string AV32TFEmployeeName ;
      private string AV33TFEmployeeName_Sel ;
      private string AV44TFLeaveRequestHalfDay ;
      private string AV45TFLeaveRequestHalfDay_Sel ;
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
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
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
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
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
      private string Grid_empowerer_Internalname ;
      private string divDdo_leaverequeststartdateauxdates_Internalname ;
      private string edtavDdo_leaverequeststartdateauxdatetext_Internalname ;
      private string edtavDdo_leaverequeststartdateauxdatetext_Jsonclick ;
      private string Tfleaverequeststartdate_rangepicker_Internalname ;
      private string divDdo_leaverequestenddateauxdates_Internalname ;
      private string edtavDdo_leaverequestenddateauxdatetext_Internalname ;
      private string edtavDdo_leaverequestenddateauxdatetext_Jsonclick ;
      private string Tfleaverequestenddate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtLeaveRequestId_Internalname ;
      private string edtLeaveTypeId_Internalname ;
      private string A125LeaveTypeName ;
      private string edtLeaveTypeName_Internalname ;
      private string edtLeaveRequestDate_Internalname ;
      private string A148EmployeeName ;
      private string edtEmployeeName_Internalname ;
      private string edtLeaveRequestStartDate_Internalname ;
      private string edtLeaveRequestEndDate_Internalname ;
      private string A171LeaveRequestHalfDay ;
      private string edtLeaveRequestHalfDay_Internalname ;
      private string edtLeaveRequestDuration_Internalname ;
      private string cmbLeaveRequestStatus_Internalname ;
      private string A132LeaveRequestStatus ;
      private string edtLeaveRequestDescription_Internalname ;
      private string edtLeaveRequestRejectionReason_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string edtEmployeeBalance_Internalname ;
      private string A144LeaveTypeVacationLeave ;
      private string radLeaveTypeVacationLeave_Internalname ;
      private string lV71Leaverequestlistds_2_tfleavetypename ;
      private string lV73Leaverequestlistds_4_tfemployeename ;
      private string lV79Leaverequestlistds_10_tfleaverequesthalfday ;
      private string AV72Leaverequestlistds_3_tfleavetypename_sel ;
      private string AV71Leaverequestlistds_2_tfleavetypename ;
      private string AV74Leaverequestlistds_5_tfemployeename_sel ;
      private string AV73Leaverequestlistds_4_tfemployeename ;
      private string AV80Leaverequestlistds_11_tfleaverequesthalfday_sel ;
      private string AV79Leaverequestlistds_10_tfleaverequesthalfday ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtLeaveRequestId_Jsonclick ;
      private string edtLeaveTypeId_Jsonclick ;
      private string edtLeaveTypeName_Jsonclick ;
      private string edtLeaveRequestDate_Jsonclick ;
      private string edtEmployeeName_Jsonclick ;
      private string edtLeaveRequestStartDate_Jsonclick ;
      private string edtLeaveRequestEndDate_Jsonclick ;
      private string edtLeaveRequestHalfDay_Jsonclick ;
      private string edtLeaveRequestDuration_Jsonclick ;
      private string GXCCtl ;
      private string cmbLeaveRequestStatus_Jsonclick ;
      private string edtLeaveRequestDescription_Jsonclick ;
      private string edtLeaveRequestRejectionReason_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeBalance_Jsonclick ;
      private string radLeaveTypeVacationLeave_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV66FromDate ;
      private DateTime AV67ToDate ;
      private DateTime wcpOAV66FromDate ;
      private DateTime wcpOAV67ToDate ;
      private DateTime AV34TFLeaveRequestStartDate ;
      private DateTime AV35TFLeaveRequestStartDate_To ;
      private DateTime AV39TFLeaveRequestEndDate ;
      private DateTime AV40TFLeaveRequestEndDate_To ;
      private DateTime AV36DDO_LeaveRequestStartDateAuxDate ;
      private DateTime AV37DDO_LeaveRequestStartDateAuxDateTo ;
      private DateTime AV41DDO_LeaveRequestEndDateAuxDate ;
      private DateTime AV42DDO_LeaveRequestEndDateAuxDateTo ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime AV75Leaverequestlistds_6_tfleaverequeststartdate ;
      private DateTime AV76Leaverequestlistds_7_tfleaverequeststartdate_to ;
      private DateTime AV77Leaverequestlistds_8_tfleaverequestenddate ;
      private DateTime AV78Leaverequestlistds_9_tfleaverequestenddate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n171LeaveRequestHalfDay ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV28ManageFiltersXml ;
      private string AV19FilterFullText ;
      private string AV50TFLeaveRequestDescription ;
      private string AV51TFLeaveRequestDescription_Sel ;
      private string AV9GridAppliedFilters ;
      private string AV38DDO_LeaveRequestStartDateAuxDateText ;
      private string AV43DDO_LeaveRequestEndDateAuxDateText ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private string lV70Leaverequestlistds_1_filterfulltext ;
      private string lV83Leaverequestlistds_14_tfleaverequestdescription ;
      private string AV70Leaverequestlistds_1_filterfulltext ;
      private string AV84Leaverequestlistds_15_tfleaverequestdescription_sel ;
      private string AV83Leaverequestlistds_14_tfleaverequestdescription ;
      private string AV20ExcelFilename ;
      private string AV21ErrorMessage ;
      private IGxSession AV26Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfleaverequeststartdate_rangepicker ;
      private GXUserControl ucTfleaverequestenddate_rangepicker ;
      private GxHttpRequest AV11HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbLeaveRequestStatus ;
      private GXRadio radLeaveTypeVacationLeave ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV27ManageFiltersData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV60AGExportData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV54DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV14GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H005F2_A144LeaveTypeVacationLeave ;
      private decimal[] H005F2_A147EmployeeBalance ;
      private long[] H005F2_A106EmployeeId ;
      private string[] H005F2_A134LeaveRequestRejectionReason ;
      private string[] H005F2_A133LeaveRequestDescription ;
      private string[] H005F2_A132LeaveRequestStatus ;
      private decimal[] H005F2_A131LeaveRequestDuration ;
      private string[] H005F2_A171LeaveRequestHalfDay ;
      private bool[] H005F2_n171LeaveRequestHalfDay ;
      private DateTime[] H005F2_A130LeaveRequestEndDate ;
      private DateTime[] H005F2_A129LeaveRequestStartDate ;
      private string[] H005F2_A148EmployeeName ;
      private DateTime[] H005F2_A128LeaveRequestDate ;
      private string[] H005F2_A125LeaveTypeName ;
      private long[] H005F2_A124LeaveTypeId ;
      private long[] H005F2_A127LeaveRequestId ;
      private long[] H005F3_AGRID_nRecordCount ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item AV61AGExportDataItem ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV55GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV56GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV15GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class leaverequestlist__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005F2( IGxContext context ,
                                             string AV70Leaverequestlistds_1_filterfulltext ,
                                             string AV72Leaverequestlistds_3_tfleavetypename_sel ,
                                             string AV71Leaverequestlistds_2_tfleavetypename ,
                                             string AV74Leaverequestlistds_5_tfemployeename_sel ,
                                             string AV73Leaverequestlistds_4_tfemployeename ,
                                             DateTime AV75Leaverequestlistds_6_tfleaverequeststartdate ,
                                             DateTime AV76Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                             DateTime AV77Leaverequestlistds_8_tfleaverequestenddate ,
                                             DateTime AV78Leaverequestlistds_9_tfleaverequestenddate_to ,
                                             string AV80Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                             string AV79Leaverequestlistds_10_tfleaverequesthalfday ,
                                             decimal AV81Leaverequestlistds_12_tfleaverequestduration ,
                                             decimal AV82Leaverequestlistds_13_tfleaverequestduration_to ,
                                             string AV84Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                             string AV83Leaverequestlistds_14_tfleaverequestdescription ,
                                             long AV64LeaveTypeId ,
                                             long AV65EmployeeId ,
                                             string A125LeaveTypeName ,
                                             string A148EmployeeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A124LeaveTypeId ,
                                             long A106EmployeeId ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             DateTime AV67ToDate ,
                                             DateTime AV66FromDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[26];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T3.LeaveTypeVacationLeave, T2.EmployeeBalance, T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestStatus, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.EmployeeName, T1.LeaveRequestDate, T3.LeaveTypeName, T1.LeaveTypeId, T1.LeaveRequestId";
         sFromString = " FROM ((LeaveRequest T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T3 ON T3.LeaveTypeId = T1.LeaveTypeId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate < :AV67ToDate and T1.LeaveRequestEndDate > :AV66FromDate)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.LeaveTypeName like '%' || :lV70Leaverequestlistds_1_filterfulltext) or ( T2.EmployeeName like '%' || :lV70Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV70Leaverequestlistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV70Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestDescription like '%' || :lV70Leaverequestlistds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestlistds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Leaverequestlistds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T3.LeaveTypeName like :lV71Leaverequestlistds_2_tfleavetypename)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestlistds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV72Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.LeaveTypeName = ( :AV72Leaverequestlistds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV72Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.LeaveTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestlistds_5_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Leaverequestlistds_4_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV73Leaverequestlistds_4_tfemployeename)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestlistds_5_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV74Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV74Leaverequestlistds_5_tfemployeename_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV74Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV75Leaverequestlistds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV75Leaverequestlistds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Leaverequestlistds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV76Leaverequestlistds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Leaverequestlistds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV77Leaverequestlistds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Leaverequestlistds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV78Leaverequestlistds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestlistds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV79Leaverequestlistds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV80Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV80Leaverequestlistds_11_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV80Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Leaverequestlistds_12_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV81Leaverequestlistds_12_tfleaverequestduration)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Leaverequestlistds_13_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV82Leaverequestlistds_13_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Leaverequestlistds_15_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Leaverequestlistds_14_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription like :lV83Leaverequestlistds_14_tfleaverequestdescription)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Leaverequestlistds_15_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV84Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV84Leaverequestlistds_15_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV84Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( ! (0==AV64LeaveTypeId) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId = :AV64LeaveTypeId)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! (0==AV65EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV65EmployeeId)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( AV16OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.LeaveRequestDate, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T3.LeaveTypeName, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.LeaveTypeName DESC, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T2.EmployeeName, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.EmployeeName DESC, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestStartDate, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestStartDate DESC, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestEndDate, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestEndDate DESC, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestHalfDay, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestHalfDay DESC, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestDuration, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestDuration DESC, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T1.LeaveRequestDescription, T1.LeaveRequestId";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.LeaveRequestDescription DESC, T1.LeaveRequestId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.LeaveRequestId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H005F3( IGxContext context ,
                                             string AV70Leaverequestlistds_1_filterfulltext ,
                                             string AV72Leaverequestlistds_3_tfleavetypename_sel ,
                                             string AV71Leaverequestlistds_2_tfleavetypename ,
                                             string AV74Leaverequestlistds_5_tfemployeename_sel ,
                                             string AV73Leaverequestlistds_4_tfemployeename ,
                                             DateTime AV75Leaverequestlistds_6_tfleaverequeststartdate ,
                                             DateTime AV76Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                             DateTime AV77Leaverequestlistds_8_tfleaverequestenddate ,
                                             DateTime AV78Leaverequestlistds_9_tfleaverequestenddate_to ,
                                             string AV80Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                             string AV79Leaverequestlistds_10_tfleaverequesthalfday ,
                                             decimal AV81Leaverequestlistds_12_tfleaverequestduration ,
                                             decimal AV82Leaverequestlistds_13_tfleaverequestduration_to ,
                                             string AV84Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                             string AV83Leaverequestlistds_14_tfleaverequestdescription ,
                                             long AV64LeaveTypeId ,
                                             long AV65EmployeeId ,
                                             string A125LeaveTypeName ,
                                             string A148EmployeeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A124LeaveTypeId ,
                                             long A106EmployeeId ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             DateTime AV67ToDate ,
                                             DateTime AV66FromDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[23];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((LeaveRequest T1 INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate < :AV67ToDate and T1.LeaveRequestEndDate > :AV66FromDate)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Leaverequestlistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.LeaveTypeName like '%' || :lV70Leaverequestlistds_1_filterfulltext) or ( T3.EmployeeName like '%' || :lV70Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV70Leaverequestlistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV70Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestDescription like '%' || :lV70Leaverequestlistds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestlistds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Leaverequestlistds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV71Leaverequestlistds_2_tfleavetypename)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestlistds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV72Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV72Leaverequestlistds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV72Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestlistds_5_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Leaverequestlistds_4_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV73Leaverequestlistds_4_tfemployeename)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestlistds_5_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV74Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV74Leaverequestlistds_5_tfemployeename_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV74Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV75Leaverequestlistds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV75Leaverequestlistds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Leaverequestlistds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV76Leaverequestlistds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Leaverequestlistds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV77Leaverequestlistds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Leaverequestlistds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV78Leaverequestlistds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Leaverequestlistds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV79Leaverequestlistds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV80Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV80Leaverequestlistds_11_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV80Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Leaverequestlistds_12_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV81Leaverequestlistds_12_tfleaverequestduration)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Leaverequestlistds_13_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV82Leaverequestlistds_13_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Leaverequestlistds_15_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Leaverequestlistds_14_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription like :lV83Leaverequestlistds_14_tfleaverequestdescription)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Leaverequestlistds_15_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV84Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV84Leaverequestlistds_15_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( StringUtil.StrCmp(AV84Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( ! (0==AV64LeaveTypeId) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId = :AV64LeaveTypeId)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! (0==AV65EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV65EmployeeId)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] );
               case 1 :
                     return conditional_H005F3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005F2;
          prmH005F2 = new Object[] {
          new ParDef("AV67ToDate",GXType.Date,8,0) ,
          new ParDef("AV66FromDate",GXType.Date,8,0) ,
          new ParDef("lV70Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Leaverequestlistds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV72Leaverequestlistds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("lV73Leaverequestlistds_4_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV74Leaverequestlistds_5_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("AV75Leaverequestlistds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV76Leaverequestlistds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV77Leaverequestlistds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV78Leaverequestlistds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV79Leaverequestlistds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV80Leaverequestlistds_11_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV81Leaverequestlistds_12_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV82Leaverequestlistds_13_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV83Leaverequestlistds_14_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV84Leaverequestlistds_15_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV64LeaveTypeId",GXType.Int64,10,0) ,
          new ParDef("AV65EmployeeId",GXType.Int64,10,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005F3;
          prmH005F3 = new Object[] {
          new ParDef("AV67ToDate",GXType.Date,8,0) ,
          new ParDef("AV66FromDate",GXType.Date,8,0) ,
          new ParDef("lV70Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Leaverequestlistds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV72Leaverequestlistds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("lV73Leaverequestlistds_4_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV74Leaverequestlistds_5_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("AV75Leaverequestlistds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV76Leaverequestlistds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV77Leaverequestlistds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV78Leaverequestlistds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV79Leaverequestlistds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV80Leaverequestlistds_11_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV81Leaverequestlistds_12_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV82Leaverequestlistds_13_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV83Leaverequestlistds_14_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV84Leaverequestlistds_15_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV64LeaveTypeId",GXType.Int64,10,0) ,
          new ParDef("AV65EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005F2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005F3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 100);
                ((long[]) buf[14])[0] = rslt.getLong(14);
                ((long[]) buf[15])[0] = rslt.getLong(15);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
