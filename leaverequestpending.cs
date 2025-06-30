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
   public class leaverequestpending : GXWebComponent
   {
      public leaverequestpending( )
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

      public leaverequestpending( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbLeaveRequestStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
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
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
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
         AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV16OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV18FilterFullText = GetPar( "FilterFullText");
         AV28ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV23ColumnsSelector);
         AV99Pgmname = GetPar( "Pgmname");
         AV29TFEmployeeName = GetPar( "TFEmployeeName");
         AV30TFEmployeeName_Sel = GetPar( "TFEmployeeName_Sel");
         AV31TFLeaveTypeName = GetPar( "TFLeaveTypeName");
         AV32TFLeaveTypeName_Sel = GetPar( "TFLeaveTypeName_Sel");
         AV38TFLeaveRequestStartDate = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestStartDate"));
         AV39TFLeaveRequestStartDate_To = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestStartDate_To"));
         AV43TFLeaveRequestEndDate = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestEndDate"));
         AV44TFLeaveRequestEndDate_To = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestEndDate_To"));
         AV82TFLeaveRequestHalfDay = GetPar( "TFLeaveRequestHalfDay");
         AV84TFLeaveRequestHalfDayOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "TFLeaveRequestHalfDayOperator"), "."), 18, MidpointRounding.ToEven));
         AV83TFLeaveRequestHalfDay_Sel = GetPar( "TFLeaveRequestHalfDay_Sel");
         AV48TFLeaveRequestDuration = NumberUtil.Val( GetPar( "TFLeaveRequestDuration"), ".");
         AV49TFLeaveRequestDuration_To = NumberUtil.Val( GetPar( "TFLeaveRequestDuration_To"), ".");
         AV86TFEmployeeBalance = NumberUtil.Val( GetPar( "TFEmployeeBalance"), ".");
         AV87TFEmployeeBalance_To = NumberUtil.Val( GetPar( "TFEmployeeBalance_To"), ".");
         A162ProjectManagerId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectManagerId"), "."), 18, MidpointRounding.ToEven));
         n162ProjectManagerId = false;
         AV120Udparg20 = (long)(Math.Round(NumberUtil.Val( GetPar( "Udparg20"), "."), 18, MidpointRounding.ToEven));
         A102ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV78ProjectIds);
         AV92DVelop_ConfirmPanel_RejectButton_Comment = GetPar( "DVelop_ConfirmPanel_RejectButton_Comment");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV28ManageFiltersExecutionStep, AV23ColumnsSelector, AV99Pgmname, AV29TFEmployeeName, AV30TFEmployeeName_Sel, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV82TFLeaveRequestHalfDay, AV84TFLeaveRequestHalfDayOperator, AV83TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV86TFEmployeeBalance, AV87TFEmployeeBalance_To, A162ProjectManagerId, AV120Udparg20, A102ProjectId, AV78ProjectIds, AV92DVelop_ConfirmPanel_RejectButton_Comment, sPrefix) ;
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
            PA392( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV99Pgmname = "LeaveRequestPending";
               edtavLeaverequestdescriptionvariable_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequestdescriptionvariable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequestdescriptionvariable_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavUseraction1_Enabled = 0;
               AssignProp(sPrefix, false, edtavUseraction1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseraction1_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavUseraction2_Enabled = 0;
               AssignProp(sPrefix, false, edtavUseraction2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUseraction2_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavUpdateleaverequest_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdateleaverequest_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdateleaverequest_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               WS392( ) ;
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
            context.SendWebValue( " Leave Request") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leaverequestpending.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG20", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV120Udparg20), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG20", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV120Udparg20), "9999999999"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROJECTIDS", AV78ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROJECTIDS", AV78ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROJECTIDS", GetSecureSignedToken( sPrefix, AV78ProjectIds, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT", AV92DVelop_ConfirmPanel_RejectButton_Comment);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT", GetSecureSignedToken( sPrefix, AV92DVelop_ConfirmPanel_RejectButton_Comment, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV16OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV18FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV26ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV26ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV56GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vAGEXPORTDATA", AV62AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vAGEXPORTDATA", AV62AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOLUMNSSELECTOR", AV23ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOLUMNSSELECTOR", AV23ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_LEAVEREQUESTSTARTDATEAUXDATE", context.localUtil.DToC( AV40DDO_LeaveRequestStartDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_LEAVEREQUESTSTARTDATEAUXDATETO", context.localUtil.DToC( AV41DDO_LeaveRequestStartDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_LEAVEREQUESTENDDATEAUXDATE", context.localUtil.DToC( AV45DDO_LeaveRequestEndDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_LEAVEREQUESTENDDATEAUXDATETO", context.localUtil.DToC( AV46DDO_LeaveRequestEndDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFEMPLOYEENAME", StringUtil.RTrim( AV29TFEmployeeName));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFEMPLOYEENAME_SEL", StringUtil.RTrim( AV30TFEmployeeName_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVETYPENAME", StringUtil.RTrim( AV31TFLeaveTypeName));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVETYPENAME_SEL", StringUtil.RTrim( AV32TFLeaveTypeName_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVEREQUESTSTARTDATE", context.localUtil.DToC( AV38TFLeaveRequestStartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVEREQUESTSTARTDATE_TO", context.localUtil.DToC( AV39TFLeaveRequestStartDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVEREQUESTENDDATE", context.localUtil.DToC( AV43TFLeaveRequestEndDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVEREQUESTENDDATE_TO", context.localUtil.DToC( AV44TFLeaveRequestEndDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVEREQUESTHALFDAY", StringUtil.RTrim( AV82TFLeaveRequestHalfDay));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVEREQUESTHALFDAYOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV84TFLeaveRequestHalfDayOperator), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVEREQUESTHALFDAY_SEL", StringUtil.RTrim( AV83TFLeaveRequestHalfDay_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVEREQUESTDURATION", StringUtil.LTrim( StringUtil.NToC( AV48TFLeaveRequestDuration, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLEAVEREQUESTDURATION_TO", StringUtil.LTrim( StringUtil.NToC( AV49TFLeaveRequestDuration_To, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFEMPLOYEEBALANCE", StringUtil.LTrim( StringUtil.NToC( AV86TFEmployeeBalance, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFEMPLOYEEBALANCE_TO", StringUtil.LTrim( StringUtil.NToC( AV87TFEmployeeBalance_To, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROJECTMANAGERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A162ProjectManagerId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG20", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV120Udparg20), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG20", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV120Udparg20), "9999999999"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROJECTIDS", AV78ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROJECTIDS", AV78ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROJECTIDS", GetSecureSignedToken( sPrefix, AV78ProjectIds, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV16OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV13GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV13GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vEMPLOYEENAME", StringUtil.RTrim( AV90employeename));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT", AV92DVelop_ConfirmPanel_RejectButton_Comment);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT", GetSecureSignedToken( sPrefix, AV92DVelop_ConfirmPanel_RejectButton_Comment, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLEAVEREQUESTID_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70LeaveRequestId_Selected), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Fixedfilters", StringUtil.RTrim( Ddo_grid_Fixedfilters));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedfixedfilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Title", StringUtil.RTrim( Dvelop_confirmpanel_useraction1_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useraction1_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useraction1_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useraction1_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useraction1_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useraction1_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useraction1_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Title", StringUtil.RTrim( Dvelop_confirmpanel_useraction2_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useraction2_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useraction2_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useraction2_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useraction2_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useraction2_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useraction2_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Result", StringUtil.RTrim( Dvelop_confirmpanel_useraction1_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Result", StringUtil.RTrim( Dvelop_confirmpanel_useraction2_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumnfixedfilter", StringUtil.RTrim( Ddo_grid_Selectedcolumnfixedfilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Result", StringUtil.RTrim( Dvelop_confirmpanel_useraction1_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Result", StringUtil.RTrim( Dvelop_confirmpanel_useraction2_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
      }

      protected void RenderHtmlCloseForm392( )
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
         return "LeaveRequestPending" ;
      }

      public override string GetPgmdesc( )
      {
         return " Leave Request" ;
      }

      protected void WB390( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "leaverequestpending.aspx");
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
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Export", bttBtnagexport_Jsonclick, 0, "Export", "", StyleString, ClassString, 1, 0, "standard", "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestPending.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestPending.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV26ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV18FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV18FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_LeaveRequestPending.htm");
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridHover HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV54GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV55GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV56GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV62AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, sPrefix+"DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("FixedFilters", Ddo_grid_Fixedfilters);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV23ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, sPrefix+"DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_65_392( true) ;
         }
         else
         {
            wb_table1_65_392( false) ;
         }
         return  ;
      }

      protected void wb_table1_65_392e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_70_392( true) ;
         }
         else
         {
            wb_table2_70_392( false) ;
         }
         return  ;
      }

      protected void wb_table2_70_392e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_leaverequeststartdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_leaverequeststartdateauxdatetext_Internalname, AV42DDO_LeaveRequestStartDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV42DDO_LeaveRequestStartDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_leaverequeststartdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequestPending.htm");
            /* User Defined Control */
            ucTfleaverequeststartdate_rangepicker.SetProperty("Start Date", AV40DDO_LeaveRequestStartDateAuxDate);
            ucTfleaverequeststartdate_rangepicker.SetProperty("End Date", AV41DDO_LeaveRequestStartDateAuxDateTo);
            ucTfleaverequeststartdate_rangepicker.Render(context, "wwp.daterangepicker", Tfleaverequeststartdate_rangepicker_Internalname, sPrefix+"TFLEAVEREQUESTSTARTDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_leaverequestenddateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_leaverequestenddateauxdatetext_Internalname, AV47DDO_LeaveRequestEndDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV47DDO_LeaveRequestEndDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_leaverequestenddateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequestPending.htm");
            /* User Defined Control */
            ucTfleaverequestenddate_rangepicker.SetProperty("Start Date", AV45DDO_LeaveRequestEndDateAuxDate);
            ucTfleaverequestenddate_rangepicker.SetProperty("End Date", AV46DDO_LeaveRequestEndDateAuxDateTo);
            ucTfleaverequestenddate_rangepicker.Render(context, "wwp.daterangepicker", Tfleaverequestenddate_rangepicker_Internalname, sPrefix+"TFLEAVEREQUESTENDDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 37 )
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

      protected void START392( )
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
            Form.Meta.addItem("description", " Leave Request", 0) ;
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
               STRUP390( ) ;
            }
         }
      }

      protected void WS392( )
      {
         START392( ) ;
         EVT392( ) ;
      }

      protected void EVT392( )
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
                                 STRUP390( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP390( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11392 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP390( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12392 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP390( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13392 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP390( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_agexport.Onoptionclicked */
                                    E14392 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP390( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E15392 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP390( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                                    E16392 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTION1.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP390( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_useraction1.Close */
                                    E17392 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTION2.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP390( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_useraction2.Close */
                                    E18392 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP390( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavLeaverequestdescriptionvariable_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP390( ) ;
                              }
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              A127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveRequestId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A124LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
                              A125LeaveTypeName = cgiGet( edtLeaveTypeName_Internalname);
                              A128LeaveRequestDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtLeaveRequestDate_Internalname), 0));
                              A129LeaveRequestStartDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtLeaveRequestStartDate_Internalname), 0));
                              A130LeaveRequestEndDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtLeaveRequestEndDate_Internalname), 0));
                              A171LeaveRequestHalfDay = cgiGet( edtLeaveRequestHalfDay_Internalname);
                              n171LeaveRequestHalfDay = false;
                              A131LeaveRequestDuration = context.localUtil.CToN( cgiGet( edtLeaveRequestDuration_Internalname), ".", ",");
                              cmbLeaveRequestStatus.Name = cmbLeaveRequestStatus_Internalname;
                              cmbLeaveRequestStatus.CurrentValue = cgiGet( cmbLeaveRequestStatus_Internalname);
                              A132LeaveRequestStatus = cgiGet( cmbLeaveRequestStatus_Internalname);
                              A133LeaveRequestDescription = cgiGet( edtLeaveRequestDescription_Internalname);
                              AV85LeaveRequestDescriptionVariable = cgiGet( edtavLeaverequestdescriptionvariable_Internalname);
                              AssignAttri(sPrefix, false, edtavLeaverequestdescriptionvariable_Internalname, AV85LeaveRequestDescriptionVariable);
                              A134LeaveRequestRejectionReason = cgiGet( edtLeaveRequestRejectionReason_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A147EmployeeBalance = context.localUtil.CToN( cgiGet( edtEmployeeBalance_Internalname), ".", ",");
                              AV88UserAction1 = cgiGet( edtavUseraction1_Internalname);
                              AssignAttri(sPrefix, false, edtavUseraction1_Internalname, AV88UserAction1);
                              AV89UserAction2 = cgiGet( edtavUseraction2_Internalname);
                              AssignAttri(sPrefix, false, edtavUseraction2_Internalname, AV89UserAction2);
                              AV94UpdateLeaverequest = cgiGet( edtavUpdateleaverequest_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdateleaverequest_Internalname, AV94UpdateLeaverequest);
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
                                          GX_FocusControl = edtavLeaverequestdescriptionvariable_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E19392 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavLeaverequestdescriptionvariable_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E20392 ();
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
                                          GX_FocusControl = edtavLeaverequestdescriptionvariable_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E21392 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV15OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV16OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV18FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
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
                                       STRUP390( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavLeaverequestdescriptionvariable_Internalname;
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

      protected void WE392( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm392( ) ;
            }
         }
      }

      protected void PA392( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
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
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV15OrderedBy ,
                                       bool AV16OrderedDsc ,
                                       string AV18FilterFullText ,
                                       short AV28ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV23ColumnsSelector ,
                                       string AV99Pgmname ,
                                       string AV29TFEmployeeName ,
                                       string AV30TFEmployeeName_Sel ,
                                       string AV31TFLeaveTypeName ,
                                       string AV32TFLeaveTypeName_Sel ,
                                       DateTime AV38TFLeaveRequestStartDate ,
                                       DateTime AV39TFLeaveRequestStartDate_To ,
                                       DateTime AV43TFLeaveRequestEndDate ,
                                       DateTime AV44TFLeaveRequestEndDate_To ,
                                       string AV82TFLeaveRequestHalfDay ,
                                       short AV84TFLeaveRequestHalfDayOperator ,
                                       string AV83TFLeaveRequestHalfDay_Sel ,
                                       decimal AV48TFLeaveRequestDuration ,
                                       decimal AV49TFLeaveRequestDuration_To ,
                                       decimal AV86TFEmployeeBalance ,
                                       decimal AV87TFEmployeeBalance_To ,
                                       long A162ProjectManagerId ,
                                       long AV120Udparg20 ,
                                       long A102ProjectId ,
                                       GxSimpleCollection<long> AV78ProjectIds ,
                                       string AV92DVelop_ConfirmPanel_RejectButton_Comment ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF392( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_LEAVEREQUESTID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"LEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", "")));
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
         RF392( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV99Pgmname = "LeaveRequestPending";
         edtavLeaverequestdescriptionvariable_Enabled = 0;
         edtavUseraction1_Enabled = 0;
         edtavUseraction2_Enabled = 0;
         edtavUpdateleaverequest_Enabled = 0;
      }

      protected void RF392( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E20392 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
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
            SubsflControlProps_372( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A106EmployeeId ,
                                                 AV79EmployeeIds ,
                                                 AV100Leaverequestpendingds_4_filterfulltext ,
                                                 AV102Leaverequestpendingds_6_tfemployeename_sel ,
                                                 AV101Leaverequestpendingds_5_tfemployeename ,
                                                 AV104Leaverequestpendingds_8_tfleavetypename_sel ,
                                                 AV103Leaverequestpendingds_7_tfleavetypename ,
                                                 AV105Leaverequestpendingds_9_tfleaverequeststartdate ,
                                                 AV106Leaverequestpendingds_10_tfleaverequeststartdate_to ,
                                                 AV107Leaverequestpendingds_11_tfleaverequestenddate ,
                                                 AV108Leaverequestpendingds_12_tfleaverequestenddate_to ,
                                                 AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel ,
                                                 AV109Leaverequestpendingds_13_tfleaverequesthalfday ,
                                                 AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator ,
                                                 AV112Leaverequestpendingds_16_tfleaverequestduration ,
                                                 AV113Leaverequestpendingds_17_tfleaverequestduration_to ,
                                                 AV114Leaverequestpendingds_18_tfemployeebalance ,
                                                 AV115Leaverequestpendingds_19_tfemployeebalance_to ,
                                                 A148EmployeeName ,
                                                 A125LeaveTypeName ,
                                                 A171LeaveRequestHalfDay ,
                                                 A131LeaveRequestDuration ,
                                                 A147EmployeeBalance ,
                                                 A129LeaveRequestStartDate ,
                                                 A130LeaveRequestEndDate ,
                                                 AV15OrderedBy ,
                                                 AV16OrderedDsc ,
                                                 A132LeaveRequestStatus ,
                                                 AV96Udparg1 ,
                                                 AV97Udparg2 ,
                                                 A100CompanyId ,
                                                 AV98Udparg3 } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                                 TypeConstants.LONG
                                                 }
            });
            lV100Leaverequestpendingds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext), "%", "");
            lV100Leaverequestpendingds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext), "%", "");
            lV100Leaverequestpendingds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext), "%", "");
            lV100Leaverequestpendingds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext), "%", "");
            lV100Leaverequestpendingds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext), "%", "");
            lV101Leaverequestpendingds_5_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV101Leaverequestpendingds_5_tfemployeename), 100, "%");
            lV103Leaverequestpendingds_7_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV103Leaverequestpendingds_7_tfleavetypename), 100, "%");
            lV109Leaverequestpendingds_13_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV109Leaverequestpendingds_13_tfleaverequesthalfday), 20, "%");
            /* Using cursor H00392 */
            pr_default.execute(0, new Object[] {AV96Udparg1, AV97Udparg2, AV98Udparg3, lV100Leaverequestpendingds_4_filterfulltext, lV100Leaverequestpendingds_4_filterfulltext, lV100Leaverequestpendingds_4_filterfulltext, lV100Leaverequestpendingds_4_filterfulltext, lV100Leaverequestpendingds_4_filterfulltext, lV101Leaverequestpendingds_5_tfemployeename, AV102Leaverequestpendingds_6_tfemployeename_sel, lV103Leaverequestpendingds_7_tfleavetypename, AV104Leaverequestpendingds_8_tfleavetypename_sel, AV105Leaverequestpendingds_9_tfleaverequeststartdate, AV106Leaverequestpendingds_10_tfleaverequeststartdate_to, AV107Leaverequestpendingds_11_tfleaverequestenddate, AV108Leaverequestpendingds_12_tfleaverequestenddate_to, lV109Leaverequestpendingds_13_tfleaverequesthalfday, AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel, AV112Leaverequestpendingds_16_tfleaverequestduration, AV113Leaverequestpendingds_17_tfleaverequestduration_to, AV114Leaverequestpendingds_18_tfemployeebalance, AV115Leaverequestpendingds_19_tfemployeebalance_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A100CompanyId = H00392_A100CompanyId[0];
               A147EmployeeBalance = H00392_A147EmployeeBalance[0];
               A106EmployeeId = H00392_A106EmployeeId[0];
               A134LeaveRequestRejectionReason = H00392_A134LeaveRequestRejectionReason[0];
               A133LeaveRequestDescription = H00392_A133LeaveRequestDescription[0];
               A132LeaveRequestStatus = H00392_A132LeaveRequestStatus[0];
               A131LeaveRequestDuration = H00392_A131LeaveRequestDuration[0];
               A171LeaveRequestHalfDay = H00392_A171LeaveRequestHalfDay[0];
               n171LeaveRequestHalfDay = H00392_n171LeaveRequestHalfDay[0];
               A130LeaveRequestEndDate = H00392_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = H00392_A129LeaveRequestStartDate[0];
               A128LeaveRequestDate = H00392_A128LeaveRequestDate[0];
               A125LeaveTypeName = H00392_A125LeaveTypeName[0];
               A148EmployeeName = H00392_A148EmployeeName[0];
               A124LeaveTypeId = H00392_A124LeaveTypeId[0];
               A127LeaveRequestId = H00392_A127LeaveRequestId[0];
               A147EmployeeBalance = H00392_A147EmployeeBalance[0];
               A148EmployeeName = H00392_A148EmployeeName[0];
               A100CompanyId = H00392_A100CompanyId[0];
               A125LeaveTypeName = H00392_A125LeaveTypeName[0];
               /* Execute user event: Grid.Load */
               E21392 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB390( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes392( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUDPARG20", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV120Udparg20), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUDPARG20", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV120Udparg20), "9999999999"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROJECTIDS", AV78ProjectIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROJECTIDS", AV78ProjectIds);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPROJECTIDS", GetSecureSignedToken( sPrefix, AV78ProjectIds, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_LEAVEREQUESTID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sPrefix+sGXsfl_37_idx, context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT", AV92DVelop_ConfirmPanel_RejectButton_Comment);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT", GetSecureSignedToken( sPrefix, AV92DVelop_ConfirmPanel_RejectButton_Comment, context));
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
         AV100Leaverequestpendingds_4_filterfulltext = AV18FilterFullText;
         AV101Leaverequestpendingds_5_tfemployeename = AV29TFEmployeeName;
         AV102Leaverequestpendingds_6_tfemployeename_sel = AV30TFEmployeeName_Sel;
         AV103Leaverequestpendingds_7_tfleavetypename = AV31TFLeaveTypeName;
         AV104Leaverequestpendingds_8_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV105Leaverequestpendingds_9_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV106Leaverequestpendingds_10_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV107Leaverequestpendingds_11_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV108Leaverequestpendingds_12_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV109Leaverequestpendingds_13_tfleaverequesthalfday = AV82TFLeaveRequestHalfDay;
         AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator = AV84TFLeaveRequestHalfDayOperator;
         AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel = AV83TFLeaveRequestHalfDay_Sel;
         AV112Leaverequestpendingds_16_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV113Leaverequestpendingds_17_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV114Leaverequestpendingds_18_tfemployeebalance = AV86TFEmployeeBalance;
         AV115Leaverequestpendingds_19_tfemployeebalance_to = AV87TFEmployeeBalance_To;
         AV96Udparg1 = new userhasrole(context).executeUdp(  "Manager");
         AV97Udparg2 = new userhasrole(context).executeUdp(  "Project Manager");
         AV98Udparg3 = new getloggedinusercompanyid(context).executeUdp( );
         AV120Udparg20 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV79EmployeeIds ,
                                              AV100Leaverequestpendingds_4_filterfulltext ,
                                              AV102Leaverequestpendingds_6_tfemployeename_sel ,
                                              AV101Leaverequestpendingds_5_tfemployeename ,
                                              AV104Leaverequestpendingds_8_tfleavetypename_sel ,
                                              AV103Leaverequestpendingds_7_tfleavetypename ,
                                              AV105Leaverequestpendingds_9_tfleaverequeststartdate ,
                                              AV106Leaverequestpendingds_10_tfleaverequeststartdate_to ,
                                              AV107Leaverequestpendingds_11_tfleaverequestenddate ,
                                              AV108Leaverequestpendingds_12_tfleaverequestenddate_to ,
                                              AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel ,
                                              AV109Leaverequestpendingds_13_tfleaverequesthalfday ,
                                              AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator ,
                                              AV112Leaverequestpendingds_16_tfleaverequestduration ,
                                              AV113Leaverequestpendingds_17_tfleaverequestduration_to ,
                                              AV114Leaverequestpendingds_18_tfemployeebalance ,
                                              AV115Leaverequestpendingds_19_tfemployeebalance_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A147EmployeeBalance ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              AV15OrderedBy ,
                                              AV16OrderedDsc ,
                                              A132LeaveRequestStatus ,
                                              AV96Udparg1 ,
                                              AV97Udparg2 ,
                                              A100CompanyId ,
                                              AV98Udparg3 } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV100Leaverequestpendingds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext), "%", "");
         lV100Leaverequestpendingds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext), "%", "");
         lV100Leaverequestpendingds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext), "%", "");
         lV100Leaverequestpendingds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext), "%", "");
         lV100Leaverequestpendingds_4_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext), "%", "");
         lV101Leaverequestpendingds_5_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV101Leaverequestpendingds_5_tfemployeename), 100, "%");
         lV103Leaverequestpendingds_7_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV103Leaverequestpendingds_7_tfleavetypename), 100, "%");
         lV109Leaverequestpendingds_13_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV109Leaverequestpendingds_13_tfleaverequesthalfday), 20, "%");
         /* Using cursor H00393 */
         pr_default.execute(1, new Object[] {AV96Udparg1, AV97Udparg2, AV98Udparg3, lV100Leaverequestpendingds_4_filterfulltext, lV100Leaverequestpendingds_4_filterfulltext, lV100Leaverequestpendingds_4_filterfulltext, lV100Leaverequestpendingds_4_filterfulltext, lV100Leaverequestpendingds_4_filterfulltext, lV101Leaverequestpendingds_5_tfemployeename, AV102Leaverequestpendingds_6_tfemployeename_sel, lV103Leaverequestpendingds_7_tfleavetypename, AV104Leaverequestpendingds_8_tfleavetypename_sel, AV105Leaverequestpendingds_9_tfleaverequeststartdate, AV106Leaverequestpendingds_10_tfleaverequeststartdate_to, AV107Leaverequestpendingds_11_tfleaverequestenddate, AV108Leaverequestpendingds_12_tfleaverequestenddate_to, lV109Leaverequestpendingds_13_tfleaverequesthalfday, AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel, AV112Leaverequestpendingds_16_tfleaverequestduration, AV113Leaverequestpendingds_17_tfleaverequestduration_to, AV114Leaverequestpendingds_18_tfemployeebalance, AV115Leaverequestpendingds_19_tfemployeebalance_to});
         GRID_nRecordCount = H00393_AGRID_nRecordCount[0];
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
         AV100Leaverequestpendingds_4_filterfulltext = AV18FilterFullText;
         AV101Leaverequestpendingds_5_tfemployeename = AV29TFEmployeeName;
         AV102Leaverequestpendingds_6_tfemployeename_sel = AV30TFEmployeeName_Sel;
         AV103Leaverequestpendingds_7_tfleavetypename = AV31TFLeaveTypeName;
         AV104Leaverequestpendingds_8_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV105Leaverequestpendingds_9_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV106Leaverequestpendingds_10_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV107Leaverequestpendingds_11_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV108Leaverequestpendingds_12_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV109Leaverequestpendingds_13_tfleaverequesthalfday = AV82TFLeaveRequestHalfDay;
         AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator = AV84TFLeaveRequestHalfDayOperator;
         AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel = AV83TFLeaveRequestHalfDay_Sel;
         AV112Leaverequestpendingds_16_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV113Leaverequestpendingds_17_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV114Leaverequestpendingds_18_tfemployeebalance = AV86TFEmployeeBalance;
         AV115Leaverequestpendingds_19_tfemployeebalance_to = AV87TFEmployeeBalance_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV28ManageFiltersExecutionStep, AV23ColumnsSelector, AV99Pgmname, AV29TFEmployeeName, AV30TFEmployeeName_Sel, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV82TFLeaveRequestHalfDay, AV84TFLeaveRequestHalfDayOperator, AV83TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV86TFEmployeeBalance, AV87TFEmployeeBalance_To, A162ProjectManagerId, AV120Udparg20, A102ProjectId, AV78ProjectIds, AV92DVelop_ConfirmPanel_RejectButton_Comment, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV100Leaverequestpendingds_4_filterfulltext = AV18FilterFullText;
         AV101Leaverequestpendingds_5_tfemployeename = AV29TFEmployeeName;
         AV102Leaverequestpendingds_6_tfemployeename_sel = AV30TFEmployeeName_Sel;
         AV103Leaverequestpendingds_7_tfleavetypename = AV31TFLeaveTypeName;
         AV104Leaverequestpendingds_8_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV105Leaverequestpendingds_9_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV106Leaverequestpendingds_10_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV107Leaverequestpendingds_11_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV108Leaverequestpendingds_12_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV109Leaverequestpendingds_13_tfleaverequesthalfday = AV82TFLeaveRequestHalfDay;
         AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator = AV84TFLeaveRequestHalfDayOperator;
         AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel = AV83TFLeaveRequestHalfDay_Sel;
         AV112Leaverequestpendingds_16_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV113Leaverequestpendingds_17_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV114Leaverequestpendingds_18_tfemployeebalance = AV86TFEmployeeBalance;
         AV115Leaverequestpendingds_19_tfemployeebalance_to = AV87TFEmployeeBalance_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV28ManageFiltersExecutionStep, AV23ColumnsSelector, AV99Pgmname, AV29TFEmployeeName, AV30TFEmployeeName_Sel, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV82TFLeaveRequestHalfDay, AV84TFLeaveRequestHalfDayOperator, AV83TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV86TFEmployeeBalance, AV87TFEmployeeBalance_To, A162ProjectManagerId, AV120Udparg20, A102ProjectId, AV78ProjectIds, AV92DVelop_ConfirmPanel_RejectButton_Comment, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV100Leaverequestpendingds_4_filterfulltext = AV18FilterFullText;
         AV101Leaverequestpendingds_5_tfemployeename = AV29TFEmployeeName;
         AV102Leaverequestpendingds_6_tfemployeename_sel = AV30TFEmployeeName_Sel;
         AV103Leaverequestpendingds_7_tfleavetypename = AV31TFLeaveTypeName;
         AV104Leaverequestpendingds_8_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV105Leaverequestpendingds_9_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV106Leaverequestpendingds_10_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV107Leaverequestpendingds_11_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV108Leaverequestpendingds_12_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV109Leaverequestpendingds_13_tfleaverequesthalfday = AV82TFLeaveRequestHalfDay;
         AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator = AV84TFLeaveRequestHalfDayOperator;
         AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel = AV83TFLeaveRequestHalfDay_Sel;
         AV112Leaverequestpendingds_16_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV113Leaverequestpendingds_17_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV114Leaverequestpendingds_18_tfemployeebalance = AV86TFEmployeeBalance;
         AV115Leaverequestpendingds_19_tfemployeebalance_to = AV87TFEmployeeBalance_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV28ManageFiltersExecutionStep, AV23ColumnsSelector, AV99Pgmname, AV29TFEmployeeName, AV30TFEmployeeName_Sel, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV82TFLeaveRequestHalfDay, AV84TFLeaveRequestHalfDayOperator, AV83TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV86TFEmployeeBalance, AV87TFEmployeeBalance_To, A162ProjectManagerId, AV120Udparg20, A102ProjectId, AV78ProjectIds, AV92DVelop_ConfirmPanel_RejectButton_Comment, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV100Leaverequestpendingds_4_filterfulltext = AV18FilterFullText;
         AV101Leaverequestpendingds_5_tfemployeename = AV29TFEmployeeName;
         AV102Leaverequestpendingds_6_tfemployeename_sel = AV30TFEmployeeName_Sel;
         AV103Leaverequestpendingds_7_tfleavetypename = AV31TFLeaveTypeName;
         AV104Leaverequestpendingds_8_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV105Leaverequestpendingds_9_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV106Leaverequestpendingds_10_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV107Leaverequestpendingds_11_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV108Leaverequestpendingds_12_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV109Leaverequestpendingds_13_tfleaverequesthalfday = AV82TFLeaveRequestHalfDay;
         AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator = AV84TFLeaveRequestHalfDayOperator;
         AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel = AV83TFLeaveRequestHalfDay_Sel;
         AV112Leaverequestpendingds_16_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV113Leaverequestpendingds_17_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV114Leaverequestpendingds_18_tfemployeebalance = AV86TFEmployeeBalance;
         AV115Leaverequestpendingds_19_tfemployeebalance_to = AV87TFEmployeeBalance_To;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV28ManageFiltersExecutionStep, AV23ColumnsSelector, AV99Pgmname, AV29TFEmployeeName, AV30TFEmployeeName_Sel, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV82TFLeaveRequestHalfDay, AV84TFLeaveRequestHalfDayOperator, AV83TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV86TFEmployeeBalance, AV87TFEmployeeBalance_To, A162ProjectManagerId, AV120Udparg20, A102ProjectId, AV78ProjectIds, AV92DVelop_ConfirmPanel_RejectButton_Comment, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV100Leaverequestpendingds_4_filterfulltext = AV18FilterFullText;
         AV101Leaverequestpendingds_5_tfemployeename = AV29TFEmployeeName;
         AV102Leaverequestpendingds_6_tfemployeename_sel = AV30TFEmployeeName_Sel;
         AV103Leaverequestpendingds_7_tfleavetypename = AV31TFLeaveTypeName;
         AV104Leaverequestpendingds_8_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV105Leaverequestpendingds_9_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV106Leaverequestpendingds_10_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV107Leaverequestpendingds_11_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV108Leaverequestpendingds_12_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV109Leaverequestpendingds_13_tfleaverequesthalfday = AV82TFLeaveRequestHalfDay;
         AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator = AV84TFLeaveRequestHalfDayOperator;
         AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel = AV83TFLeaveRequestHalfDay_Sel;
         AV112Leaverequestpendingds_16_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV113Leaverequestpendingds_17_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV114Leaverequestpendingds_18_tfemployeebalance = AV86TFEmployeeBalance;
         AV115Leaverequestpendingds_19_tfemployeebalance_to = AV87TFEmployeeBalance_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV28ManageFiltersExecutionStep, AV23ColumnsSelector, AV99Pgmname, AV29TFEmployeeName, AV30TFEmployeeName_Sel, AV31TFLeaveTypeName, AV32TFLeaveTypeName_Sel, AV38TFLeaveRequestStartDate, AV39TFLeaveRequestStartDate_To, AV43TFLeaveRequestEndDate, AV44TFLeaveRequestEndDate_To, AV82TFLeaveRequestHalfDay, AV84TFLeaveRequestHalfDayOperator, AV83TFLeaveRequestHalfDay_Sel, AV48TFLeaveRequestDuration, AV49TFLeaveRequestDuration_To, AV86TFEmployeeBalance, AV87TFEmployeeBalance_To, A162ProjectManagerId, AV120Udparg20, A102ProjectId, AV78ProjectIds, AV92DVelop_ConfirmPanel_RejectButton_Comment, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV99Pgmname = "LeaveRequestPending";
         edtavLeaverequestdescriptionvariable_Enabled = 0;
         edtavUseraction1_Enabled = 0;
         edtavUseraction2_Enabled = 0;
         edtavUpdateleaverequest_Enabled = 0;
         edtLeaveRequestId_Enabled = 0;
         edtLeaveTypeId_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         edtLeaveTypeName_Enabled = 0;
         edtLeaveRequestDate_Enabled = 0;
         edtLeaveRequestStartDate_Enabled = 0;
         edtLeaveRequestEndDate_Enabled = 0;
         edtLeaveRequestHalfDay_Enabled = 0;
         edtLeaveRequestDuration_Enabled = 0;
         cmbLeaveRequestStatus.Enabled = 0;
         edtLeaveRequestDescription_Enabled = 0;
         edtLeaveRequestRejectionReason_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtEmployeeBalance_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP390( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19392 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV26ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vAGEXPORTDATA"), AV62AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vCOLUMNSSELECTOR"), AV23ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_37"), ".", ","), 18, MidpointRounding.ToEven));
            AV54GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV55GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV56GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV40DDO_LeaveRequestStartDateAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_LEAVEREQUESTSTARTDATEAUXDATE"), 0);
            AV41DDO_LeaveRequestStartDateAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_LEAVEREQUESTSTARTDATEAUXDATETO"), 0);
            AV45DDO_LeaveRequestEndDateAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_LEAVEREQUESTENDDATEAUXDATE"), 0);
            AV46DDO_LeaveRequestEndDateAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_LEAVEREQUESTENDDATEAUXDATETO"), 0);
            AV70LeaveRequestId_Selected = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vLEAVEREQUESTID_SELECTED"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), ".", ","), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( sPrefix+"DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( sPrefix+"DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( sPrefix+"DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( sPrefix+"DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( sPrefix+"DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( sPrefix+"DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Fixedfilters = cgiGet( sPrefix+"DDO_GRID_Fixedfilters");
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Ddo_grid_Selectedfixedfilter = cgiGet( sPrefix+"DDO_GRID_Selectedfixedfilter");
            Ddo_gridcolumnsselector_Icontype = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Dvelop_confirmpanel_useraction1_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Title");
            Dvelop_confirmpanel_useraction1_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Confirmationtext");
            Dvelop_confirmpanel_useraction1_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Yesbuttoncaption");
            Dvelop_confirmpanel_useraction1_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Nobuttoncaption");
            Dvelop_confirmpanel_useraction1_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Cancelbuttoncaption");
            Dvelop_confirmpanel_useraction1_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Yesbuttonposition");
            Dvelop_confirmpanel_useraction1_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Confirmtype");
            Dvelop_confirmpanel_useraction2_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Title");
            Dvelop_confirmpanel_useraction2_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Confirmationtext");
            Dvelop_confirmpanel_useraction2_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Yesbuttoncaption");
            Dvelop_confirmpanel_useraction2_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Nobuttoncaption");
            Dvelop_confirmpanel_useraction2_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Cancelbuttoncaption");
            Dvelop_confirmpanel_useraction2_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Yesbuttonposition");
            Dvelop_confirmpanel_useraction2_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumnfixedfilter = cgiGet( sPrefix+"DDO_GRID_Selectedcolumnfixedfilter");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( sPrefix+"DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_useraction1_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1_Result");
            Dvelop_confirmpanel_useraction2_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2_Result");
            Ddo_agexport_Activeeventkey = cgiGet( sPrefix+"DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV18FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV18FilterFullText", AV18FilterFullText);
            AV42DDO_LeaveRequestStartDateAuxDateText = cgiGet( edtavDdo_leaverequeststartdateauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV42DDO_LeaveRequestStartDateAuxDateText", AV42DDO_LeaveRequestStartDateAuxDateText);
            AV47DDO_LeaveRequestEndDateAuxDateText = cgiGet( edtavDdo_leaverequestenddateauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV47DDO_LeaveRequestEndDateAuxDateText", AV47DDO_LeaveRequestEndDateAuxDateText);
            /* Read subfile selected row values. */
            nGXsfl_37_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), ".", ","), 18, MidpointRounding.ToEven));
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            if ( nGXsfl_37_idx > 0 )
            {
               A127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveRequestId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               A124LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
               A125LeaveTypeName = cgiGet( edtLeaveTypeName_Internalname);
               A128LeaveRequestDate = context.localUtil.CToD( cgiGet( edtLeaveRequestDate_Internalname), 2);
               A129LeaveRequestStartDate = context.localUtil.CToD( cgiGet( edtLeaveRequestStartDate_Internalname), 2);
               A130LeaveRequestEndDate = context.localUtil.CToD( cgiGet( edtLeaveRequestEndDate_Internalname), 2);
               A171LeaveRequestHalfDay = cgiGet( edtLeaveRequestHalfDay_Internalname);
               n171LeaveRequestHalfDay = false;
               A131LeaveRequestDuration = context.localUtil.CToN( cgiGet( edtLeaveRequestDuration_Internalname), ".", ",");
               cmbLeaveRequestStatus.Name = cmbLeaveRequestStatus_Internalname;
               cmbLeaveRequestStatus.CurrentValue = cgiGet( cmbLeaveRequestStatus_Internalname);
               A132LeaveRequestStatus = cgiGet( cmbLeaveRequestStatus_Internalname);
               A133LeaveRequestDescription = cgiGet( edtLeaveRequestDescription_Internalname);
               AV85LeaveRequestDescriptionVariable = cgiGet( edtavLeaverequestdescriptionvariable_Internalname);
               AssignAttri(sPrefix, false, edtavLeaverequestdescriptionvariable_Internalname, AV85LeaveRequestDescriptionVariable);
               A134LeaveRequestRejectionReason = cgiGet( edtLeaveRequestRejectionReason_Internalname);
               A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               A147EmployeeBalance = context.localUtil.CToN( cgiGet( edtEmployeeBalance_Internalname), ".", ",");
               AV88UserAction1 = cgiGet( edtavUseraction1_Internalname);
               AssignAttri(sPrefix, false, edtavUseraction1_Internalname, AV88UserAction1);
               AV89UserAction2 = cgiGet( edtavUseraction2_Internalname);
               AssignAttri(sPrefix, false, edtavUseraction2_Internalname, AV89UserAction2);
               AV94UpdateLeaverequest = cgiGet( edtavUpdateleaverequest_Internalname);
               AssignAttri(sPrefix, false, edtavUpdateleaverequest_Internalname, AV94UpdateLeaverequest);
            }
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV15OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV16OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV18FilterFullText) != 0 )
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
         E19392 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19392( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_char1 = AV90employeename;
         new getloggedinemployeename(context ).execute( out  GXt_char1) ;
         AV90employeename = GXt_char1;
         AssignAttri(sPrefix, false, "AV90employeename", AV90employeename);
         /* Execute user subroutine: 'GETEMPLOYEEIDSBYPROJECT' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod(sPrefix, false, "TFLEAVEREQUESTENDDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_leaverequestenddateauxdatetext_Internalname});
         this.executeUsercontrolMethod(sPrefix, false, "TFLEAVEREQUESTSTARTDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_leaverequeststartdateauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, sPrefix, false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, sPrefix, false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV62AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV63AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV63AGExportDataItem.gxTpr_Title = "Excel";
         AV63AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV63AGExportDataItem.gxTpr_Eventkey = "Export";
         AV63AGExportDataItem.gxTpr_Isdivider = false;
         AV62AGExportData.Add(AV63AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
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
         if ( AV15OrderedBy < 1 )
         {
            AV15OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV52DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV52DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, sPrefix, false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E20392( )
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
         if ( AV28ManageFiltersExecutionStep == 1 )
         {
            AV28ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV28ManageFiltersExecutionStep == 2 )
         {
            AV28ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV25Session.Get("LeaveRequestPendingColumnsSelector"), "") != 0 )
         {
            AV21ColumnsSelectorXML = AV25Session.Get("LeaveRequestPendingColumnsSelector");
            AV23ColumnsSelector.FromXml(AV21ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtEmployeeName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV23ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtLeaveTypeName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV23ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtLeaveTypeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveTypeName_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtLeaveRequestStartDate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV23ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtLeaveRequestStartDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestStartDate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtLeaveRequestEndDate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV23ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtLeaveRequestEndDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtLeaveRequestHalfDay_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV23ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtLeaveRequestHalfDay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestHalfDay_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtLeaveRequestDuration_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV23ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtLeaveRequestDuration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDuration_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtavLeaverequestdescriptionvariable_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV23ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtavLeaverequestdescriptionvariable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequestdescriptionvariable_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtEmployeeBalance_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV23ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtEmployeeBalance_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeBalance_Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV54GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV54GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV54GridCurrentPage), 10, 0));
         AV55GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV55GridPageCount", StringUtil.LTrimStr( (decimal)(AV55GridPageCount), 10, 0));
         GXt_char1 = AV56GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV99Pgmname, out  GXt_char1) ;
         AV56GridAppliedFilters = GXt_char1;
         AssignAttri(sPrefix, false, "AV56GridAppliedFilters", AV56GridAppliedFilters);
         edtLeaveRequestHalfDay_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp(sPrefix, false, edtLeaveRequestHalfDay_Internalname, "Columnheaderclass", edtLeaveRequestHalfDay_Columnheaderclass, !bGXsfl_37_Refreshing);
         AV100Leaverequestpendingds_4_filterfulltext = AV18FilterFullText;
         AV101Leaverequestpendingds_5_tfemployeename = AV29TFEmployeeName;
         AV102Leaverequestpendingds_6_tfemployeename_sel = AV30TFEmployeeName_Sel;
         AV103Leaverequestpendingds_7_tfleavetypename = AV31TFLeaveTypeName;
         AV104Leaverequestpendingds_8_tfleavetypename_sel = AV32TFLeaveTypeName_Sel;
         AV105Leaverequestpendingds_9_tfleaverequeststartdate = AV38TFLeaveRequestStartDate;
         AV106Leaverequestpendingds_10_tfleaverequeststartdate_to = AV39TFLeaveRequestStartDate_To;
         AV107Leaverequestpendingds_11_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV108Leaverequestpendingds_12_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV109Leaverequestpendingds_13_tfleaverequesthalfday = AV82TFLeaveRequestHalfDay;
         AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator = AV84TFLeaveRequestHalfDayOperator;
         AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel = AV83TFLeaveRequestHalfDay_Sel;
         AV112Leaverequestpendingds_16_tfleaverequestduration = AV48TFLeaveRequestDuration;
         AV113Leaverequestpendingds_17_tfleaverequestduration_to = AV49TFLeaveRequestDuration_To;
         AV114Leaverequestpendingds_18_tfemployeebalance = AV86TFEmployeeBalance;
         AV115Leaverequestpendingds_19_tfemployeebalance_to = AV87TFEmployeeBalance_To;
         AV96Udparg1 = new userhasrole(context).executeUdp(  "Manager");
         AV97Udparg2 = new userhasrole(context).executeUdp(  "Project Manager");
         AV98Udparg3 = new getloggedinusercompanyid(context).executeUdp( );
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23ColumnsSelector", AV23ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV78ProjectIds", AV78ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26ManageFiltersData", AV26ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13GridState", AV13GridState);
      }

      protected void E12392( )
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
            AV53PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV53PageToGo) ;
         }
      }

      protected void E13392( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15392( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            AV16OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
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
               AV29TFEmployeeName = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV29TFEmployeeName", AV29TFEmployeeName);
               AV30TFEmployeeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV30TFEmployeeName_Sel", AV30TFEmployeeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveTypeName") == 0 )
            {
               AV31TFLeaveTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV31TFLeaveTypeName", AV31TFLeaveTypeName);
               AV32TFLeaveTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV32TFLeaveTypeName_Sel", AV32TFLeaveTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestStartDate") == 0 )
            {
               AV38TFLeaveRequestStartDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri(sPrefix, false, "AV38TFLeaveRequestStartDate", context.localUtil.Format(AV38TFLeaveRequestStartDate, "99/99/99"));
               AV39TFLeaveRequestStartDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri(sPrefix, false, "AV39TFLeaveRequestStartDate_To", context.localUtil.Format(AV39TFLeaveRequestStartDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestEndDate") == 0 )
            {
               AV43TFLeaveRequestEndDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri(sPrefix, false, "AV43TFLeaveRequestEndDate", context.localUtil.Format(AV43TFLeaveRequestEndDate, "99/99/99"));
               AV44TFLeaveRequestEndDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri(sPrefix, false, "AV44TFLeaveRequestEndDate_To", context.localUtil.Format(AV44TFLeaveRequestEndDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestHalfDay") == 0 )
            {
               if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "1") == 0 )
               {
                  AV84TFLeaveRequestHalfDayOperator = 1;
                  AssignAttri(sPrefix, false, "AV84TFLeaveRequestHalfDayOperator", StringUtil.LTrimStr( (decimal)(AV84TFLeaveRequestHalfDayOperator), 4, 0));
                  AV82TFLeaveRequestHalfDay = "";
                  AssignAttri(sPrefix, false, "AV82TFLeaveRequestHalfDay", AV82TFLeaveRequestHalfDay);
                  AV83TFLeaveRequestHalfDay_Sel = "";
                  AssignAttri(sPrefix, false, "AV83TFLeaveRequestHalfDay_Sel", AV83TFLeaveRequestHalfDay_Sel);
               }
               else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumnfixedfilter, "2") == 0 )
               {
                  AV84TFLeaveRequestHalfDayOperator = 2;
                  AssignAttri(sPrefix, false, "AV84TFLeaveRequestHalfDayOperator", StringUtil.LTrimStr( (decimal)(AV84TFLeaveRequestHalfDayOperator), 4, 0));
                  AV82TFLeaveRequestHalfDay = "";
                  AssignAttri(sPrefix, false, "AV82TFLeaveRequestHalfDay", AV82TFLeaveRequestHalfDay);
                  AV83TFLeaveRequestHalfDay_Sel = "";
                  AssignAttri(sPrefix, false, "AV83TFLeaveRequestHalfDay_Sel", AV83TFLeaveRequestHalfDay_Sel);
               }
               else
               {
                  AV84TFLeaveRequestHalfDayOperator = 0;
                  AssignAttri(sPrefix, false, "AV84TFLeaveRequestHalfDayOperator", StringUtil.LTrimStr( (decimal)(AV84TFLeaveRequestHalfDayOperator), 4, 0));
                  AV82TFLeaveRequestHalfDay = Ddo_grid_Filteredtext_get;
                  AssignAttri(sPrefix, false, "AV82TFLeaveRequestHalfDay", AV82TFLeaveRequestHalfDay);
                  AV83TFLeaveRequestHalfDay_Sel = Ddo_grid_Selectedvalue_get;
                  AssignAttri(sPrefix, false, "AV83TFLeaveRequestHalfDay_Sel", AV83TFLeaveRequestHalfDay_Sel);
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestDuration") == 0 )
            {
               AV48TFLeaveRequestDuration = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV48TFLeaveRequestDuration", StringUtil.LTrimStr( AV48TFLeaveRequestDuration, 4, 1));
               AV49TFLeaveRequestDuration_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV49TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV49TFLeaveRequestDuration_To, 4, 1));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeBalance") == 0 )
            {
               AV86TFEmployeeBalance = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV86TFEmployeeBalance", StringUtil.LTrimStr( AV86TFEmployeeBalance, 4, 1));
               AV87TFEmployeeBalance_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV87TFEmployeeBalance_To", StringUtil.LTrimStr( AV87TFEmployeeBalance_To, 4, 1));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E21392( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( StringUtil.Len( A133LeaveRequestDescription) < 25 )
         {
            AV85LeaveRequestDescriptionVariable = A133LeaveRequestDescription;
            AssignAttri(sPrefix, false, edtavLeaverequestdescriptionvariable_Internalname, AV85LeaveRequestDescriptionVariable);
         }
         else
         {
            AV85LeaveRequestDescriptionVariable = StringUtil.Substring( A133LeaveRequestDescription, 1, 25) + " ...";
            AssignAttri(sPrefix, false, edtavLeaverequestdescriptionvariable_Internalname, AV85LeaveRequestDescriptionVariable);
         }
         AV88UserAction1 = "<i class=\"fas fa-thumbs-up\"></i>";
         AssignAttri(sPrefix, false, edtavUseraction1_Internalname, AV88UserAction1);
         AV89UserAction2 = "<i class=\"fas fa-thumbs-down\"></i>";
         AssignAttri(sPrefix, false, edtavUseraction2_Internalname, AV89UserAction2);
         AV94UpdateLeaverequest = "<i class=\"fas fa-pencil\"></i>";
         AssignAttri(sPrefix, false, edtavUpdateleaverequest_Internalname, AV94UpdateLeaverequest);
         if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Morning") == 0 )
         {
            edtLeaveRequestHalfDay_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagInfo WWColumnTagInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Afternoon") == 0 )
         {
            edtLeaveRequestHalfDay_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else
         {
            edtLeaveRequestHalfDay_Columnclass = "WWColumn hidden-xs";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 37;
         }
         sendrow_372( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E16392( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV21ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV23ColumnsSelector.FromJSonString(AV21ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "LeaveRequestPendingColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV21ColumnsSelectorXML)) ? "" : AV23ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23ColumnsSelector", AV23ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV78ProjectIds", AV78ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26ManageFiltersData", AV26ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13GridState", AV13GridState);
      }

      protected void E11392( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
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
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("LeaveRequestPendingFilters")),UrlEncode(StringUtil.RTrim(AV99Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV28ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("LeaveRequestPendingFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV28ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char1 = AV27ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "LeaveRequestPendingFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char1) ;
            AV27ManageFiltersXml = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27ManageFiltersXml)) )
            {
               GX_msglist.addItem("The selected filter no longer exist.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV99Pgmname+"GridState",  AV27ManageFiltersXml) ;
               AV13GridState.FromXml(AV27ManageFiltersXml, null, "", "");
               AV15OrderedBy = AV13GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
               AV16OrderedDsc = AV13GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S152 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13GridState", AV13GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23ColumnsSelector", AV23ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV78ProjectIds", AV78ProjectIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26ManageFiltersData", AV26ManageFiltersData);
      }

      protected void E17392( )
      {
         /* Dvelop_confirmpanel_useraction1_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useraction1_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO USERACTION1' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E18392( )
      {
         /* Dvelop_confirmpanel_useraction2_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useraction2_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO USERACTION2' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E14392( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13GridState", AV13GridState);
      }

      protected void S152( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0))+":"+(AV16OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV23ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "EmployeeName",  "",  "Employee Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "LeaveTypeName",  "",  "Leave Type Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "LeaveRequestStartDate",  "",  "Start Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "LeaveRequestEndDate",  "",  "End Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "LeaveRequestHalfDay",  "",  "Half Day",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "LeaveRequestDuration",  "",  "Request Duration",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "&LeaveRequestDescriptionVariable",  "",  "Leave Description",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "EmployeeBalance",  "",  "Vacation Balance",  true,  "") ;
         GXt_char1 = AV22UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "LeaveRequestPendingColumnsSelector", out  GXt_char1) ;
         AV22UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV22UserCustomValue)) ) )
         {
            AV24ColumnsSelectorAux.FromXml(AV22UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV24ColumnsSelectorAux, ref  AV23ColumnsSelector) ;
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV26ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "LeaveRequestPendingFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV26ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV18FilterFullText = "";
         AssignAttri(sPrefix, false, "AV18FilterFullText", AV18FilterFullText);
         AV29TFEmployeeName = "";
         AssignAttri(sPrefix, false, "AV29TFEmployeeName", AV29TFEmployeeName);
         AV30TFEmployeeName_Sel = "";
         AssignAttri(sPrefix, false, "AV30TFEmployeeName_Sel", AV30TFEmployeeName_Sel);
         AV31TFLeaveTypeName = "";
         AssignAttri(sPrefix, false, "AV31TFLeaveTypeName", AV31TFLeaveTypeName);
         AV32TFLeaveTypeName_Sel = "";
         AssignAttri(sPrefix, false, "AV32TFLeaveTypeName_Sel", AV32TFLeaveTypeName_Sel);
         AV38TFLeaveRequestStartDate = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV38TFLeaveRequestStartDate", context.localUtil.Format(AV38TFLeaveRequestStartDate, "99/99/99"));
         AV39TFLeaveRequestStartDate_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV39TFLeaveRequestStartDate_To", context.localUtil.Format(AV39TFLeaveRequestStartDate_To, "99/99/99"));
         AV43TFLeaveRequestEndDate = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV43TFLeaveRequestEndDate", context.localUtil.Format(AV43TFLeaveRequestEndDate, "99/99/99"));
         AV44TFLeaveRequestEndDate_To = DateTime.MinValue;
         AssignAttri(sPrefix, false, "AV44TFLeaveRequestEndDate_To", context.localUtil.Format(AV44TFLeaveRequestEndDate_To, "99/99/99"));
         AV82TFLeaveRequestHalfDay = "";
         AssignAttri(sPrefix, false, "AV82TFLeaveRequestHalfDay", AV82TFLeaveRequestHalfDay);
         AV83TFLeaveRequestHalfDay_Sel = "";
         AssignAttri(sPrefix, false, "AV83TFLeaveRequestHalfDay_Sel", AV83TFLeaveRequestHalfDay_Sel);
         AV84TFLeaveRequestHalfDayOperator = 0;
         AssignAttri(sPrefix, false, "AV84TFLeaveRequestHalfDayOperator", StringUtil.LTrimStr( (decimal)(AV84TFLeaveRequestHalfDayOperator), 4, 0));
         Ddo_grid_Selectedfixedfilter = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
         AV48TFLeaveRequestDuration = 0;
         AssignAttri(sPrefix, false, "AV48TFLeaveRequestDuration", StringUtil.LTrimStr( AV48TFLeaveRequestDuration, 4, 1));
         AV49TFLeaveRequestDuration_To = 0;
         AssignAttri(sPrefix, false, "AV49TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV49TFLeaveRequestDuration_To, 4, 1));
         AV86TFEmployeeBalance = 0;
         AssignAttri(sPrefix, false, "AV86TFEmployeeBalance", StringUtil.LTrimStr( AV86TFEmployeeBalance, 4, 1));
         AV87TFEmployeeBalance_To = 0;
         AssignAttri(sPrefix, false, "AV87TFEmployeeBalance_To", StringUtil.LTrimStr( AV87TFEmployeeBalance_To, 4, 1));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S202( )
      {
         /* 'DO USERACTION1' Routine */
         returnInSub = false;
         AV65LeaveRequest.Load(A127LeaveRequestId);
         AV65LeaveRequest.gxTpr_Leaverequeststatus = "Approved";
         if ( AV65LeaveRequest.Update() )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
            AV75Employee.Load(AV65LeaveRequest.gxTpr_Employeeid);
            AV76LeaveType.Load(AV65LeaveRequest.gxTpr_Leavetypeid);
            if ( AV75Employee.Update() )
            {
               GXt_char1 = AV76LeaveType.gxTpr_Leavetypename + " approved";
               GXt_char4 = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Request Approved</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV75Employee.gxTpr_Employeename + ",</p>" + "<p>We are pleased to inform you that your leave request has been approved by " + AV90employeename + " .</p>" + "<p>Start Date: <b>" + context.localUtil.DToC( AV65LeaveRequest.gxTpr_Leaverequeststartdate, 2, "/") + "</b></p>" + "<p>End Date: <b>" + context.localUtil.DToC( AV65LeaveRequest.gxTpr_Leaverequestenddate, 2, "/") + "</b></p>" + "<p>Description: <b>" + AV65LeaveRequest.gxTpr_Leaverequestdescription + "</b></p><p>If you have any questions or need further assistance, please do not hesitate to contact us.</p><p>Best Regards,</p><p>Yukon Time Tracker Team</p></div></div>";
               new sendemail(context).executeSubmit(  AV75Employee.gxTpr_Employeeemail, ref  GXt_char1, ref  GXt_char4) ;
               GX_msglist.addItem("Leave Approved Successfully");
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
            }
            else
            {
               context.RollbackDataStores("leaverequestpending",pr_default);
            }
            context.CommitDataStores("leaverequestpending",pr_default);
         }
         else
         {
            context.RollbackDataStores("leaverequestpending",pr_default);
            AV117GXV2 = 1;
            AV116GXV1 = AV65LeaveRequest.GetMessages();
            while ( AV117GXV2 <= AV116GXV1.Count )
            {
               AV91Message = ((GeneXus.Utils.SdtMessages_Message)AV116GXV1.Item(AV117GXV2));
               GX_msglist.addItem(AV91Message.gxTpr_Description);
               AV117GXV2 = (int)(AV117GXV2+1);
            }
         }
      }

      protected void S212( )
      {
         /* 'DO USERACTION2' Routine */
         returnInSub = false;
         AV65LeaveRequest.Load(A127LeaveRequestId);
         AV65LeaveRequest.gxTpr_Leaverequeststatus = "Rejected";
         AV65LeaveRequest.gxTpr_Leaverequestrejectionreason = AV92DVelop_ConfirmPanel_RejectButton_Comment;
         if ( AV65LeaveRequest.Update() )
         {
            AV75Employee.Load(AV65LeaveRequest.gxTpr_Employeeid);
            AV76LeaveType.Load(AV65LeaveRequest.gxTpr_Leavetypeid);
            GXt_char4 = AV76LeaveType.gxTpr_Leavetypename + " rejected";
            GXt_char1 = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Request Rejected</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV75Employee.gxTpr_Employeename + ",</p>" + "<p>We regret to inform you that your leave request has been rejected by " + AV90employeename + ".</p>" + "<p>Start Date: <b>" + context.localUtil.DToC( AV65LeaveRequest.gxTpr_Leaverequeststartdate, 2, "/") + "</b></p>" + "<p>EndDate: <b>" + context.localUtil.DToC( AV65LeaveRequest.gxTpr_Leaverequestenddate, 2, "/") + "</b></p>" + "<p>Reason for Rejection: <b>" + AV65LeaveRequest.gxTpr_Leaverequestrejectionreason + "</b></p><p>If you have any concerns or need clarification, please reach out to us.</p><p> Best Regards</p><p>The Yukon Time Tracker Team</p></div></div>";
            new sendemail(context).executeSubmit(  AV75Employee.gxTpr_Employeeemail, ref  GXt_char4, ref  GXt_char1) ;
            GX_msglist.addItem("Leave Rejected Successfully");
            new sdsendpushnotifications(context ).execute(  "Leave Request Rejected",  "Your leave request made on "+context.localUtil.DToC( AV65LeaveRequest.gxTpr_Leaverequestdate, 2, "/")+" has been rejected",  AV65LeaveRequest.gxTpr_Employeeid) ;
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
         }
         else
         {
            context.RollbackDataStores("leaverequestpending",pr_default);
         }
         context.CommitDataStores("leaverequestpending",pr_default);
      }

      protected void S142( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV25Session.Get(AV99Pgmname+"GridState"), "") == 0 )
         {
            AV13GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV99Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV13GridState.FromXml(AV25Session.Get(AV99Pgmname+"GridState"), null, "", "");
         }
         AV15OrderedBy = AV13GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         AV16OrderedDsc = AV13GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV13GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV13GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV118GXV3 = 1;
         while ( AV118GXV3 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV118GXV3));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18FilterFullText", AV18FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV29TFEmployeeName = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29TFEmployeeName", AV29TFEmployeeName);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV30TFEmployeeName_Sel = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV30TFEmployeeName_Sel", AV30TFEmployeeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV31TFLeaveTypeName = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV31TFLeaveTypeName", AV31TFLeaveTypeName);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV32TFLeaveTypeName_Sel = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV32TFLeaveTypeName_Sel", AV32TFLeaveTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV38TFLeaveRequestStartDate = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV38TFLeaveRequestStartDate", context.localUtil.Format(AV38TFLeaveRequestStartDate, "99/99/99"));
               AV39TFLeaveRequestStartDate_To = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri(sPrefix, false, "AV39TFLeaveRequestStartDate_To", context.localUtil.Format(AV39TFLeaveRequestStartDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV43TFLeaveRequestEndDate = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV43TFLeaveRequestEndDate", context.localUtil.Format(AV43TFLeaveRequestEndDate, "99/99/99"));
               AV44TFLeaveRequestEndDate_To = context.localUtil.CToD( AV14GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri(sPrefix, false, "AV44TFLeaveRequestEndDate_To", context.localUtil.Format(AV44TFLeaveRequestEndDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV84TFLeaveRequestHalfDayOperator = AV14GridStateFilterValue.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV84TFLeaveRequestHalfDayOperator", StringUtil.LTrimStr( (decimal)(AV84TFLeaveRequestHalfDayOperator), 4, 0));
               if ( AV84TFLeaveRequestHalfDayOperator == 0 )
               {
                  AV82TFLeaveRequestHalfDay = AV14GridStateFilterValue.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV82TFLeaveRequestHalfDay", AV82TFLeaveRequestHalfDay);
               }
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV83TFLeaveRequestHalfDay_Sel = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV83TFLeaveRequestHalfDay_Sel", AV83TFLeaveRequestHalfDay_Sel);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV48TFLeaveRequestDuration = NumberUtil.Val( AV14GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV48TFLeaveRequestDuration", StringUtil.LTrimStr( AV48TFLeaveRequestDuration, 4, 1));
               AV49TFLeaveRequestDuration_To = NumberUtil.Val( AV14GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV49TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV49TFLeaveRequestDuration_To, 4, 1));
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEBALANCE") == 0 )
            {
               AV86TFEmployeeBalance = NumberUtil.Val( AV14GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV86TFEmployeeBalance", StringUtil.LTrimStr( AV86TFEmployeeBalance, 4, 1));
               AV87TFEmployeeBalance_To = NumberUtil.Val( AV14GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV87TFEmployeeBalance_To", StringUtil.LTrimStr( AV87TFEmployeeBalance_To, 4, 1));
            }
            AV118GXV3 = (int)(AV118GXV3+1);
         }
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFEmployeeName_Sel)),  AV30TFEmployeeName_Sel, out  GXt_char4) ;
         GXt_char1 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFLeaveTypeName_Sel)),  AV32TFLeaveTypeName_Sel, out  GXt_char1) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV83TFLeaveRequestHalfDay_Sel)),  AV83TFLeaveRequestHalfDay_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char4+"|"+GXt_char1+"|||"+GXt_char5+"|||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFEmployeeName)),  AV29TFEmployeeName, out  GXt_char5) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFLeaveTypeName)),  AV31TFLeaveTypeName, out  GXt_char4) ;
         GXt_char1 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  !(0==AV84TFLeaveRequestHalfDayOperator)||String.IsNullOrEmpty(StringUtil.RTrim( AV82TFLeaveRequestHalfDay)),  AV82TFLeaveRequestHalfDay, out  GXt_char1) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char4+"|"+((DateTime.MinValue==AV38TFLeaveRequestStartDate) ? "" : context.localUtil.DToC( AV38TFLeaveRequestStartDate, 2, "/"))+"|"+((DateTime.MinValue==AV43TFLeaveRequestEndDate) ? "" : context.localUtil.DToC( AV43TFLeaveRequestEndDate, 2, "/"))+"|"+GXt_char1+"|"+((Convert.ToDecimal(0)==AV48TFLeaveRequestDuration) ? "" : StringUtil.Str( AV48TFLeaveRequestDuration, 4, 1))+"||"+((Convert.ToDecimal(0)==AV86TFEmployeeBalance) ? "" : StringUtil.Str( AV86TFEmployeeBalance, 4, 1));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV39TFLeaveRequestStartDate_To) ? "" : context.localUtil.DToC( AV39TFLeaveRequestStartDate_To, 2, "/"))+"|"+((DateTime.MinValue==AV44TFLeaveRequestEndDate_To) ? "" : context.localUtil.DToC( AV44TFLeaveRequestEndDate_To, 2, "/"))+"||"+((Convert.ToDecimal(0)==AV49TFLeaveRequestDuration_To) ? "" : StringUtil.Str( AV49TFLeaveRequestDuration_To, 4, 1))+"||"+((Convert.ToDecimal(0)==AV87TFEmployeeBalance_To) ? "" : StringUtil.Str( AV87TFEmployeeBalance_To, 4, 1));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         Ddo_grid_Selectedfixedfilter = "||||"+((AV84TFLeaveRequestHalfDayOperator!=1) ? "" : "1")+((AV84TFLeaveRequestHalfDayOperator!=2) ? "" : "2")+"|||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedFixedFilter", Ddo_grid_Selectedfixedfilter);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV13GridState.FromXml(AV25Session.Get(AV99Pgmname+"GridState"), null, "", "");
         AV13GridState.gxTpr_Orderedby = AV15OrderedBy;
         AV13GridState.gxTpr_Ordereddsc = AV16OrderedDsc;
         AV13GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)),  0,  AV18FilterFullText,  AV18FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV13GridState,  "TFEMPLOYEENAME",  "Employee Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFEmployeeName)),  0,  AV29TFEmployeeName,  AV29TFEmployeeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFEmployeeName_Sel)),  AV30TFEmployeeName_Sel,  AV30TFEmployeeName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV13GridState,  "TFLEAVETYPENAME",  "Leave Type Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFLeaveTypeName)),  0,  AV31TFLeaveTypeName,  AV31TFLeaveTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFLeaveTypeName_Sel)),  AV32TFLeaveTypeName_Sel,  AV32TFLeaveTypeName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "TFLEAVEREQUESTSTARTDATE",  "Start Date",  !((DateTime.MinValue==AV38TFLeaveRequestStartDate)&&(DateTime.MinValue==AV39TFLeaveRequestStartDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV38TFLeaveRequestStartDate, 2, "/")),  ((DateTime.MinValue==AV38TFLeaveRequestStartDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV38TFLeaveRequestStartDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV39TFLeaveRequestStartDate_To, 2, "/")),  ((DateTime.MinValue==AV39TFLeaveRequestStartDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFLeaveRequestStartDate_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "TFLEAVEREQUESTENDDATE",  "End Date",  !((DateTime.MinValue==AV43TFLeaveRequestEndDate)&&(DateTime.MinValue==AV44TFLeaveRequestEndDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV43TFLeaveRequestEndDate, 2, "/")),  ((DateTime.MinValue==AV43TFLeaveRequestEndDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV43TFLeaveRequestEndDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV44TFLeaveRequestEndDate_To, 2, "/")),  ((DateTime.MinValue==AV44TFLeaveRequestEndDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFLeaveRequestEndDate_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV13GridState,  "TFLEAVEREQUESTHALFDAY",  "Half Day",  !(String.IsNullOrEmpty(StringUtil.RTrim( AV82TFLeaveRequestHalfDay))&&(0==AV84TFLeaveRequestHalfDayOperator)),  AV84TFLeaveRequestHalfDayOperator,  AV82TFLeaveRequestHalfDay,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV84TFLeaveRequestHalfDayOperator+1), 10, 0)), AV82TFLeaveRequestHalfDay, "Morning", "Afternoon", "", "", "", "", "", ""),  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV83TFLeaveRequestHalfDay_Sel)),  AV83TFLeaveRequestHalfDay_Sel,  AV83TFLeaveRequestHalfDay_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "TFLEAVEREQUESTDURATION",  "Request Duration",  !((Convert.ToDecimal(0)==AV48TFLeaveRequestDuration)&&(Convert.ToDecimal(0)==AV49TFLeaveRequestDuration_To)),  0,  StringUtil.Trim( StringUtil.Str( AV48TFLeaveRequestDuration, 4, 1)),  ((Convert.ToDecimal(0)==AV48TFLeaveRequestDuration) ? "" : StringUtil.Trim( context.localUtil.Format( AV48TFLeaveRequestDuration, "Z9.9"))),  true,  StringUtil.Trim( StringUtil.Str( AV49TFLeaveRequestDuration_To, 4, 1)),  ((Convert.ToDecimal(0)==AV49TFLeaveRequestDuration_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV49TFLeaveRequestDuration_To, "Z9.9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "TFEMPLOYEEBALANCE",  "Vacation Balance",  !((Convert.ToDecimal(0)==AV86TFEmployeeBalance)&&(Convert.ToDecimal(0)==AV87TFEmployeeBalance_To)),  0,  StringUtil.Trim( StringUtil.Str( AV86TFEmployeeBalance, 4, 1)),  ((Convert.ToDecimal(0)==AV86TFEmployeeBalance) ? "" : StringUtil.Trim( context.localUtil.Format( AV86TFEmployeeBalance, "Z9.9"))),  true,  StringUtil.Trim( StringUtil.Str( AV87TFEmployeeBalance_To, 4, 1)),  ((Convert.ToDecimal(0)==AV87TFEmployeeBalance_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV87TFEmployeeBalance_To, "Z9.9")))) ;
         AV13GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV13GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV99Pgmname+"GridState",  AV13GridState.ToXml(false, true, "", "")) ;
      }

      protected void S132( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11TrnContext.gxTpr_Callerobject = AV99Pgmname;
         AV11TrnContext.gxTpr_Callerondelete = true;
         AV11TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV11TrnContext.gxTpr_Transactionname = "LeaveRequest";
         AV25Session.Set("TrnContext", AV11TrnContext.ToXml(false, true, "", ""));
      }

      protected void S222( )
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
         new leaverequestpendingexport(context ).execute( out  AV19ExcelFilename, out  AV20ErrorMessage) ;
         if ( StringUtil.StrCmp(AV19ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV19ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV20ErrorMessage);
         }
      }

      protected void S112( )
      {
         /* 'GETEMPLOYEEIDSBYPROJECT' Routine */
         returnInSub = false;
         AV120Udparg20 = new getloggedinemployeeid(context).executeUdp( );
         /* Using cursor H00394 */
         pr_default.execute(2, new Object[] {AV120Udparg20});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A162ProjectManagerId = H00394_A162ProjectManagerId[0];
            n162ProjectManagerId = H00394_n162ProjectManagerId[0];
            A102ProjectId = H00394_A102ProjectId[0];
            AV78ProjectIds.Add(A102ProjectId, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         GXt_objcol_int6 = AV79EmployeeIds;
         new getemployeeidsbyproject(context ).execute(  AV78ProjectIds, out  GXt_objcol_int6) ;
         AV79EmployeeIds = GXt_objcol_int6;
      }

      protected void wb_table2_70_392( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useraction2_Internalname, tblTabledvelop_confirmpanel_useraction2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useraction2.SetProperty("Title", Dvelop_confirmpanel_useraction2_Title);
            ucDvelop_confirmpanel_useraction2.SetProperty("ConfirmationText", Dvelop_confirmpanel_useraction2_Confirmationtext);
            ucDvelop_confirmpanel_useraction2.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useraction2_Yesbuttoncaption);
            ucDvelop_confirmpanel_useraction2.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useraction2_Nobuttoncaption);
            ucDvelop_confirmpanel_useraction2.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useraction2_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useraction2.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useraction2_Yesbuttonposition);
            ucDvelop_confirmpanel_useraction2.SetProperty("ConfirmType", Dvelop_confirmpanel_useraction2_Confirmtype);
            ucDvelop_confirmpanel_useraction2.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useraction2_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2Container"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_70_392e( true) ;
         }
         else
         {
            wb_table2_70_392e( false) ;
         }
      }

      protected void wb_table1_65_392( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useraction1_Internalname, tblTabledvelop_confirmpanel_useraction1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useraction1.SetProperty("Title", Dvelop_confirmpanel_useraction1_Title);
            ucDvelop_confirmpanel_useraction1.SetProperty("ConfirmationText", Dvelop_confirmpanel_useraction1_Confirmationtext);
            ucDvelop_confirmpanel_useraction1.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useraction1_Yesbuttoncaption);
            ucDvelop_confirmpanel_useraction1.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useraction1_Nobuttoncaption);
            ucDvelop_confirmpanel_useraction1.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useraction1_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useraction1.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useraction1_Yesbuttonposition);
            ucDvelop_confirmpanel_useraction1.SetProperty("ConfirmType", Dvelop_confirmpanel_useraction1_Confirmtype);
            ucDvelop_confirmpanel_useraction1.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useraction1_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1Container"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_65_392e( true) ;
         }
         else
         {
            wb_table1_65_392e( false) ;
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
         PA392( ) ;
         WS392( ) ;
         WE392( ) ;
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
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA392( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "leaverequestpending", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA392( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA392( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS392( ) ;
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
         WS392( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE392( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025627525532", true, true);
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
         context.AddJavascriptSource("leaverequestpending.js", "?2025627525533", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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

      protected void SubsflControlProps_372( )
      {
         edtLeaveRequestId_Internalname = sPrefix+"LEAVEREQUESTID_"+sGXsfl_37_idx;
         edtLeaveTypeId_Internalname = sPrefix+"LEAVETYPEID_"+sGXsfl_37_idx;
         edtEmployeeName_Internalname = sPrefix+"EMPLOYEENAME_"+sGXsfl_37_idx;
         edtLeaveTypeName_Internalname = sPrefix+"LEAVETYPENAME_"+sGXsfl_37_idx;
         edtLeaveRequestDate_Internalname = sPrefix+"LEAVEREQUESTDATE_"+sGXsfl_37_idx;
         edtLeaveRequestStartDate_Internalname = sPrefix+"LEAVEREQUESTSTARTDATE_"+sGXsfl_37_idx;
         edtLeaveRequestEndDate_Internalname = sPrefix+"LEAVEREQUESTENDDATE_"+sGXsfl_37_idx;
         edtLeaveRequestHalfDay_Internalname = sPrefix+"LEAVEREQUESTHALFDAY_"+sGXsfl_37_idx;
         edtLeaveRequestDuration_Internalname = sPrefix+"LEAVEREQUESTDURATION_"+sGXsfl_37_idx;
         cmbLeaveRequestStatus_Internalname = sPrefix+"LEAVEREQUESTSTATUS_"+sGXsfl_37_idx;
         edtLeaveRequestDescription_Internalname = sPrefix+"LEAVEREQUESTDESCRIPTION_"+sGXsfl_37_idx;
         edtavLeaverequestdescriptionvariable_Internalname = sPrefix+"vLEAVEREQUESTDESCRIPTIONVARIABLE_"+sGXsfl_37_idx;
         edtLeaveRequestRejectionReason_Internalname = sPrefix+"LEAVEREQUESTREJECTIONREASON_"+sGXsfl_37_idx;
         edtEmployeeId_Internalname = sPrefix+"EMPLOYEEID_"+sGXsfl_37_idx;
         edtEmployeeBalance_Internalname = sPrefix+"EMPLOYEEBALANCE_"+sGXsfl_37_idx;
         edtavUseraction1_Internalname = sPrefix+"vUSERACTION1_"+sGXsfl_37_idx;
         edtavUseraction2_Internalname = sPrefix+"vUSERACTION2_"+sGXsfl_37_idx;
         edtavUpdateleaverequest_Internalname = sPrefix+"vUPDATELEAVEREQUEST_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtLeaveRequestId_Internalname = sPrefix+"LEAVEREQUESTID_"+sGXsfl_37_fel_idx;
         edtLeaveTypeId_Internalname = sPrefix+"LEAVETYPEID_"+sGXsfl_37_fel_idx;
         edtEmployeeName_Internalname = sPrefix+"EMPLOYEENAME_"+sGXsfl_37_fel_idx;
         edtLeaveTypeName_Internalname = sPrefix+"LEAVETYPENAME_"+sGXsfl_37_fel_idx;
         edtLeaveRequestDate_Internalname = sPrefix+"LEAVEREQUESTDATE_"+sGXsfl_37_fel_idx;
         edtLeaveRequestStartDate_Internalname = sPrefix+"LEAVEREQUESTSTARTDATE_"+sGXsfl_37_fel_idx;
         edtLeaveRequestEndDate_Internalname = sPrefix+"LEAVEREQUESTENDDATE_"+sGXsfl_37_fel_idx;
         edtLeaveRequestHalfDay_Internalname = sPrefix+"LEAVEREQUESTHALFDAY_"+sGXsfl_37_fel_idx;
         edtLeaveRequestDuration_Internalname = sPrefix+"LEAVEREQUESTDURATION_"+sGXsfl_37_fel_idx;
         cmbLeaveRequestStatus_Internalname = sPrefix+"LEAVEREQUESTSTATUS_"+sGXsfl_37_fel_idx;
         edtLeaveRequestDescription_Internalname = sPrefix+"LEAVEREQUESTDESCRIPTION_"+sGXsfl_37_fel_idx;
         edtavLeaverequestdescriptionvariable_Internalname = sPrefix+"vLEAVEREQUESTDESCRIPTIONVARIABLE_"+sGXsfl_37_fel_idx;
         edtLeaveRequestRejectionReason_Internalname = sPrefix+"LEAVEREQUESTREJECTIONREASON_"+sGXsfl_37_fel_idx;
         edtEmployeeId_Internalname = sPrefix+"EMPLOYEEID_"+sGXsfl_37_fel_idx;
         edtEmployeeBalance_Internalname = sPrefix+"EMPLOYEEBALANCE_"+sGXsfl_37_fel_idx;
         edtavUseraction1_Internalname = sPrefix+"vUSERACTION1_"+sGXsfl_37_fel_idx;
         edtavUseraction2_Internalname = sPrefix+"vUSERACTION2_"+sGXsfl_37_fel_idx;
         edtavUpdateleaverequest_Internalname = sPrefix+"vUPDATELEAVEREQUEST_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB390( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveTypeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A124LeaveTypeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A124LeaveTypeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEmployeeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,StringUtil.RTrim( A148EmployeeName),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtEmployeeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtLeaveTypeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveTypeName_Internalname,StringUtil.RTrim( A125LeaveTypeName),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtLeaveTypeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDate_Internalname,context.localUtil.Format(A128LeaveRequestDate, "99/99/99"),context.localUtil.Format( A128LeaveRequestDate, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtLeaveRequestStartDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestStartDate_Internalname,context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"),context.localUtil.Format( A129LeaveRequestStartDate, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestStartDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtLeaveRequestStartDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtLeaveRequestEndDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestEndDate_Internalname,context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"),context.localUtil.Format( A130LeaveRequestEndDate, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestEndDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtLeaveRequestEndDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtLeaveRequestHalfDay_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestHalfDay_Internalname,StringUtil.RTrim( A171LeaveRequestHalfDay),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestHalfDay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtLeaveRequestHalfDay_Columnclass,(string)edtLeaveRequestHalfDay_Columnheaderclass,(int)edtLeaveRequestHalfDay_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtLeaveRequestDuration_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDuration_Internalname,StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", "")),StringUtil.LTrim( context.localUtil.Format( A131LeaveRequestDuration, "Z9.9")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDuration_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtLeaveRequestDuration_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbLeaveRequestStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "LEAVEREQUESTSTATUS_" + sGXsfl_37_idx;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbLeaveRequestStatus,(string)cmbLeaveRequestStatus_Internalname,StringUtil.RTrim( A132LeaveRequestStatus),(short)1,(string)cmbLeaveRequestStatus_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbLeaveRequestStatus.CurrentValue = StringUtil.RTrim( A132LeaveRequestStatus);
            AssignProp(sPrefix, false, cmbLeaveRequestStatus_Internalname, "Values", (string)(cmbLeaveRequestStatus.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDescription_Internalname,(string)A133LeaveRequestDescription,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavLeaverequestdescriptionvariable_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavLeaverequestdescriptionvariable_Internalname,(string)AV85LeaveRequestDescriptionVariable,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavLeaverequestdescriptionvariable_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavLeaverequestdescriptionvariable_Visible,(int)edtavLeaverequestdescriptionvariable_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestRejectionReason_Internalname,(string)A134LeaveRequestRejectionReason,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestRejectionReason_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtEmployeeBalance_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeBalance_Internalname,StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")),StringUtil.LTrim( context.localUtil.Format( A147EmployeeBalance, "Z9.9")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeBalance_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtEmployeeBalance_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction1_Internalname,StringUtil.RTrim( AV88UserAction1),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+"e22392_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseraction1_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUseraction1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction2_Internalname,StringUtil.RTrim( AV89UserAction2),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+"e23392_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseraction2_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUseraction2_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdateleaverequest_Internalname,StringUtil.RTrim( AV94UpdateLeaverequest),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+"e24392_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUpdateleaverequest_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdateleaverequest_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes392( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "LEAVEREQUESTSTATUS_" + sGXsfl_37_idx;
         cmbLeaveRequestStatus.Name = GXCCtl;
         cmbLeaveRequestStatus.WebTags = "";
         cmbLeaveRequestStatus.addItem("Pending", "Pending", 0);
         cmbLeaveRequestStatus.addItem("Approved", "Approved", 0);
         cmbLeaveRequestStatus.addItem("Rejected", "Rejected", 0);
         if ( cmbLeaveRequestStatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Employee Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveTypeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Leave Type Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestStartDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Start Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestEndDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "End Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestHalfDay_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Half Day") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestDuration_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Request Duration") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavLeaverequestdescriptionvariable_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Leave Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeBalance_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Vacation Balance") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A124LeaveTypeId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A148EmployeeName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A125LeaveTypeName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveTypeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A128LeaveRequestDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestStartDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestEndDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A171LeaveRequestHalfDay)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtLeaveRequestHalfDay_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtLeaveRequestHalfDay_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestHalfDay_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestDuration_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A132LeaveRequestStatus)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A133LeaveRequestDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV85LeaveRequestDescriptionVariable));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLeaverequestdescriptionvariable_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavLeaverequestdescriptionvariable_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A134LeaveRequestRejectionReason));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeBalance_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV88UserAction1)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction1_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV89UserAction2)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction2_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV94UpdateLeaverequest)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdateleaverequest_Enabled), 5, 0, ".", "")));
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
         bttBtnagexport_Internalname = sPrefix+"BTNAGEXPORT";
         bttBtneditcolumns_Internalname = sPrefix+"BTNEDITCOLUMNS";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtLeaveRequestId_Internalname = sPrefix+"LEAVEREQUESTID";
         edtLeaveTypeId_Internalname = sPrefix+"LEAVETYPEID";
         edtEmployeeName_Internalname = sPrefix+"EMPLOYEENAME";
         edtLeaveTypeName_Internalname = sPrefix+"LEAVETYPENAME";
         edtLeaveRequestDate_Internalname = sPrefix+"LEAVEREQUESTDATE";
         edtLeaveRequestStartDate_Internalname = sPrefix+"LEAVEREQUESTSTARTDATE";
         edtLeaveRequestEndDate_Internalname = sPrefix+"LEAVEREQUESTENDDATE";
         edtLeaveRequestHalfDay_Internalname = sPrefix+"LEAVEREQUESTHALFDAY";
         edtLeaveRequestDuration_Internalname = sPrefix+"LEAVEREQUESTDURATION";
         cmbLeaveRequestStatus_Internalname = sPrefix+"LEAVEREQUESTSTATUS";
         edtLeaveRequestDescription_Internalname = sPrefix+"LEAVEREQUESTDESCRIPTION";
         edtavLeaverequestdescriptionvariable_Internalname = sPrefix+"vLEAVEREQUESTDESCRIPTIONVARIABLE";
         edtLeaveRequestRejectionReason_Internalname = sPrefix+"LEAVEREQUESTREJECTIONREASON";
         edtEmployeeId_Internalname = sPrefix+"EMPLOYEEID";
         edtEmployeeBalance_Internalname = sPrefix+"EMPLOYEEBALANCE";
         edtavUseraction1_Internalname = sPrefix+"vUSERACTION1";
         edtavUseraction2_Internalname = sPrefix+"vUSERACTION2";
         edtavUpdateleaverequest_Internalname = sPrefix+"vUPDATELEAVEREQUEST";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_agexport_Internalname = sPrefix+"DDO_AGEXPORT";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = sPrefix+"DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_useraction1_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_USERACTION1";
         tblTabledvelop_confirmpanel_useraction1_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_USERACTION1";
         Dvelop_confirmpanel_useraction2_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_USERACTION2";
         tblTabledvelop_confirmpanel_useraction2_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_USERACTION2";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_leaverequeststartdateauxdatetext_Internalname = sPrefix+"vDDO_LEAVEREQUESTSTARTDATEAUXDATETEXT";
         Tfleaverequeststartdate_rangepicker_Internalname = sPrefix+"TFLEAVEREQUESTSTARTDATE_RANGEPICKER";
         divDdo_leaverequeststartdateauxdates_Internalname = sPrefix+"DDO_LEAVEREQUESTSTARTDATEAUXDATES";
         edtavDdo_leaverequestenddateauxdatetext_Internalname = sPrefix+"vDDO_LEAVEREQUESTENDDATEAUXDATETEXT";
         Tfleaverequestenddate_rangepicker_Internalname = sPrefix+"TFLEAVEREQUESTENDDATE_RANGEPICKER";
         divDdo_leaverequestenddateauxdates_Internalname = sPrefix+"DDO_LEAVEREQUESTENDDATEAUXDATES";
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
         subGrid_Allowhovering = -1;
         subGrid_Allowselection = 1;
         subGrid_Header = "";
         edtavUpdateleaverequest_Jsonclick = "";
         edtavUpdateleaverequest_Enabled = 1;
         edtavUseraction2_Jsonclick = "";
         edtavUseraction2_Enabled = 1;
         edtavUseraction1_Jsonclick = "";
         edtavUseraction1_Enabled = 1;
         edtEmployeeBalance_Jsonclick = "";
         edtEmployeeId_Jsonclick = "";
         edtLeaveRequestRejectionReason_Jsonclick = "";
         edtavLeaverequestdescriptionvariable_Jsonclick = "";
         edtavLeaverequestdescriptionvariable_Enabled = 1;
         edtLeaveRequestDescription_Jsonclick = "";
         cmbLeaveRequestStatus_Jsonclick = "";
         edtLeaveRequestDuration_Jsonclick = "";
         edtLeaveRequestHalfDay_Jsonclick = "";
         edtLeaveRequestHalfDay_Columnclass = "WWColumn hidden-xs";
         edtLeaveRequestEndDate_Jsonclick = "";
         edtLeaveRequestStartDate_Jsonclick = "";
         edtLeaveRequestDate_Jsonclick = "";
         edtLeaveTypeName_Jsonclick = "";
         edtEmployeeName_Jsonclick = "";
         edtLeaveTypeId_Jsonclick = "";
         edtLeaveRequestId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtLeaveRequestHalfDay_Columnheaderclass = "";
         edtEmployeeBalance_Visible = -1;
         edtavLeaverequestdescriptionvariable_Visible = -1;
         edtLeaveRequestDuration_Visible = -1;
         edtLeaveRequestHalfDay_Visible = -1;
         edtLeaveRequestEndDate_Visible = -1;
         edtLeaveRequestStartDate_Visible = -1;
         edtLeaveTypeName_Visible = -1;
         edtEmployeeName_Visible = -1;
         edtEmployeeBalance_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtLeaveRequestRejectionReason_Enabled = 0;
         edtLeaveRequestDescription_Enabled = 0;
         cmbLeaveRequestStatus.Enabled = 0;
         edtLeaveRequestDuration_Enabled = 0;
         edtLeaveRequestHalfDay_Enabled = 0;
         edtLeaveRequestEndDate_Enabled = 0;
         edtLeaveRequestStartDate_Enabled = 0;
         edtLeaveRequestDate_Enabled = 0;
         edtLeaveTypeName_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         edtLeaveTypeId_Enabled = 0;
         edtLeaveRequestId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_leaverequestenddateauxdatetext_Jsonclick = "";
         edtavDdo_leaverequeststartdateauxdatetext_Jsonclick = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_useraction2_Confirmtype = "1";
         Dvelop_confirmpanel_useraction2_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useraction2_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useraction2_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useraction2_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useraction2_Confirmationtext = "Reject Leave Request?";
         Dvelop_confirmpanel_useraction2_Title = "Confirm";
         Dvelop_confirmpanel_useraction1_Confirmtype = "1";
         Dvelop_confirmpanel_useraction1_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useraction1_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useraction1_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useraction1_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useraction1_Confirmationtext = "Approve Leave Request?";
         Dvelop_confirmpanel_useraction1_Title = "Approve";
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "|||||4.1||4.1";
         Ddo_grid_Fixedfilters = "||||1:Morning:fa fa-circle FontColorIconInfo FontColorIconSmall ConditionalFormattingFilterIcon,2:Afternoon:fa fa-circle FontColorIconWarning FontColorIconSmall ConditionalFormattingFilterIcon|||";
         Ddo_grid_Datalistproc = "LeaveRequestPendingGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|||Dynamic|||";
         Ddo_grid_Includedatalist = "T|T|||T|||";
         Ddo_grid_Filterisrange = "||P|P||T||T";
         Ddo_grid_Filtertype = "Character|Character|Date|Date|Character|Numeric||Numeric";
         Ddo_grid_Includefilter = "T|T|T|T|T|T||T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T||";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7||";
         Ddo_grid_Columnids = "2:EmployeeName|3:LeaveTypeName|5:LeaveRequestStartDate|6:LeaveRequestEndDate|7:LeaveRequestHalfDay|8:LeaveRequestDuration|11:LeaveRequestDescriptionVariable|14:EmployeeBalance";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "No records ";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"sPrefix"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV30TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV31TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV32TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV38TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV39TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV43TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV44TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV82TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV84TFLeaveRequestHalfDayOperator","fld":"vTFLEAVEREQUESTHALFDAYOPERATOR","pic":"ZZZ9"},{"av":"AV83TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV48TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV49TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV86TFEmployeeBalance","fld":"vTFEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV87TFEmployeeBalance_To","fld":"vTFEMPLOYEEBALANCE_TO","pic":"Z9.9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV120Udparg20","fld":"vUDPARG20","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV78ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV92DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"edtLeaveTypeName_Visible","ctrl":"LEAVETYPENAME","prop":"Visible"},{"av":"edtLeaveRequestStartDate_Visible","ctrl":"LEAVEREQUESTSTARTDATE","prop":"Visible"},{"av":"edtLeaveRequestEndDate_Visible","ctrl":"LEAVEREQUESTENDDATE","prop":"Visible"},{"av":"edtLeaveRequestHalfDay_Visible","ctrl":"LEAVEREQUESTHALFDAY","prop":"Visible"},{"av":"edtLeaveRequestDuration_Visible","ctrl":"LEAVEREQUESTDURATION","prop":"Visible"},{"av":"edtavLeaverequestdescriptionvariable_Visible","ctrl":"vLEAVEREQUESTDESCRIPTIONVARIABLE","prop":"Visible"},{"av":"edtEmployeeBalance_Visible","ctrl":"EMPLOYEEBALANCE","prop":"Visible"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtLeaveRequestHalfDay_Columnheaderclass","ctrl":"LEAVEREQUESTHALFDAY","prop":"Columnheaderclass"},{"av":"AV78ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV13GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12392","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV30TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV31TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV32TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV38TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV39TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV43TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV44TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV82TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV84TFLeaveRequestHalfDayOperator","fld":"vTFLEAVEREQUESTHALFDAYOPERATOR","pic":"ZZZ9"},{"av":"AV83TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV48TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV49TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV86TFEmployeeBalance","fld":"vTFEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV87TFEmployeeBalance_To","fld":"vTFEMPLOYEEBALANCE_TO","pic":"Z9.9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV120Udparg20","fld":"vUDPARG20","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV78ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV92DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13392","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV30TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV31TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV32TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV38TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV39TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV43TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV44TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV82TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV84TFLeaveRequestHalfDayOperator","fld":"vTFLEAVEREQUESTHALFDAYOPERATOR","pic":"ZZZ9"},{"av":"AV83TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV48TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV49TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV86TFEmployeeBalance","fld":"vTFEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV87TFEmployeeBalance_To","fld":"vTFEMPLOYEEBALANCE_TO","pic":"Z9.9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV120Udparg20","fld":"vUDPARG20","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV78ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV92DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT","hsh":true},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E15392","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV30TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV31TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV32TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV38TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV39TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV43TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV44TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV82TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV84TFLeaveRequestHalfDayOperator","fld":"vTFLEAVEREQUESTHALFDAYOPERATOR","pic":"ZZZ9"},{"av":"AV83TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV48TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV49TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV86TFEmployeeBalance","fld":"vTFEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV87TFEmployeeBalance_To","fld":"vTFEMPLOYEEBALANCE_TO","pic":"Z9.9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV120Udparg20","fld":"vUDPARG20","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV78ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV92DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumnfixedfilter","ctrl":"DDO_GRID","prop":"SelectedColumnFixedFilter"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV86TFEmployeeBalance","fld":"vTFEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV87TFEmployeeBalance_To","fld":"vTFEMPLOYEEBALANCE_TO","pic":"Z9.9"},{"av":"AV48TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV49TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV84TFLeaveRequestHalfDayOperator","fld":"vTFLEAVEREQUESTHALFDAYOPERATOR","pic":"ZZZ9"},{"av":"AV82TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV83TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV43TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV44TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV38TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV39TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV31TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV32TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV29TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV30TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E21392","iparms":[{"av":"A133LeaveRequestDescription","fld":"LEAVEREQUESTDESCRIPTION"},{"av":"A171LeaveRequestHalfDay","fld":"LEAVEREQUESTHALFDAY"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV85LeaveRequestDescriptionVariable","fld":"vLEAVEREQUESTDESCRIPTIONVARIABLE"},{"av":"AV88UserAction1","fld":"vUSERACTION1"},{"av":"AV89UserAction2","fld":"vUSERACTION2"},{"av":"AV94UpdateLeaverequest","fld":"vUPDATELEAVEREQUEST"},{"av":"edtLeaveRequestHalfDay_Columnclass","ctrl":"LEAVEREQUESTHALFDAY","prop":"Columnclass"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E16392","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV30TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV31TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV32TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV38TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV39TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV43TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV44TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV82TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV84TFLeaveRequestHalfDayOperator","fld":"vTFLEAVEREQUESTHALFDAYOPERATOR","pic":"ZZZ9"},{"av":"AV83TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV48TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV49TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV86TFEmployeeBalance","fld":"vTFEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV87TFEmployeeBalance_To","fld":"vTFEMPLOYEEBALANCE_TO","pic":"Z9.9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV120Udparg20","fld":"vUDPARG20","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV78ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV92DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV23ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"edtLeaveTypeName_Visible","ctrl":"LEAVETYPENAME","prop":"Visible"},{"av":"edtLeaveRequestStartDate_Visible","ctrl":"LEAVEREQUESTSTARTDATE","prop":"Visible"},{"av":"edtLeaveRequestEndDate_Visible","ctrl":"LEAVEREQUESTENDDATE","prop":"Visible"},{"av":"edtLeaveRequestHalfDay_Visible","ctrl":"LEAVEREQUESTHALFDAY","prop":"Visible"},{"av":"edtLeaveRequestDuration_Visible","ctrl":"LEAVEREQUESTDURATION","prop":"Visible"},{"av":"edtavLeaverequestdescriptionvariable_Visible","ctrl":"vLEAVEREQUESTDESCRIPTIONVARIABLE","prop":"Visible"},{"av":"edtEmployeeBalance_Visible","ctrl":"EMPLOYEEBALANCE","prop":"Visible"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtLeaveRequestHalfDay_Columnheaderclass","ctrl":"LEAVEREQUESTHALFDAY","prop":"Columnheaderclass"},{"av":"AV78ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV13GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11392","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV30TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV31TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV32TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV38TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV39TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV43TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV44TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV82TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV84TFLeaveRequestHalfDayOperator","fld":"vTFLEAVEREQUESTHALFDAYOPERATOR","pic":"ZZZ9"},{"av":"AV83TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV48TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV49TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV86TFEmployeeBalance","fld":"vTFEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV87TFEmployeeBalance_To","fld":"vTFEMPLOYEEBALANCE_TO","pic":"Z9.9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV120Udparg20","fld":"vUDPARG20","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV78ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV92DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV13GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV29TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV30TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV31TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV32TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV38TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV39TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV43TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV44TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV82TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV83TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV84TFLeaveRequestHalfDayOperator","fld":"vTFLEAVEREQUESTHALFDAYOPERATOR","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedfixedfilter","ctrl":"DDO_GRID","prop":"SelectedFixedFilter"},{"av":"AV48TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV49TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV86TFEmployeeBalance","fld":"vTFEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV87TFEmployeeBalance_To","fld":"vTFEMPLOYEEBALANCE_TO","pic":"Z9.9"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV23ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"edtLeaveTypeName_Visible","ctrl":"LEAVETYPENAME","prop":"Visible"},{"av":"edtLeaveRequestStartDate_Visible","ctrl":"LEAVEREQUESTSTARTDATE","prop":"Visible"},{"av":"edtLeaveRequestEndDate_Visible","ctrl":"LEAVEREQUESTENDDATE","prop":"Visible"},{"av":"edtLeaveRequestHalfDay_Visible","ctrl":"LEAVEREQUESTHALFDAY","prop":"Visible"},{"av":"edtLeaveRequestDuration_Visible","ctrl":"LEAVEREQUESTDURATION","prop":"Visible"},{"av":"edtavLeaverequestdescriptionvariable_Visible","ctrl":"vLEAVEREQUESTDESCRIPTIONVARIABLE","prop":"Visible"},{"av":"edtEmployeeBalance_Visible","ctrl":"EMPLOYEEBALANCE","prop":"Visible"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtLeaveRequestHalfDay_Columnheaderclass","ctrl":"LEAVEREQUESTHALFDAY","prop":"Columnheaderclass"},{"av":"AV78ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VUSERACTION1.CLICK","""{"handler":"E22392","iparms":[{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTION1.CLOSE","""{"handler":"E17392","iparms":[{"av":"Dvelop_confirmpanel_useraction1_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTION1","prop":"Result"},{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV90employeename","fld":"vEMPLOYEENAME"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTION1.CLOSE",""","oparms":[{"av":"AV90employeename","fld":"vEMPLOYEENAME"}]}""");
         setEventMetadata("VUSERACTION2.CLICK","""{"handler":"E23392","iparms":[{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTION2.CLOSE","""{"handler":"E18392","iparms":[{"av":"Dvelop_confirmpanel_useraction2_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTION2","prop":"Result"},{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV92DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT","hsh":true},{"av":"AV90employeename","fld":"vEMPLOYEENAME"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTION2.CLOSE",""","oparms":[{"av":"AV90employeename","fld":"vEMPLOYEENAME"}]}""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","""{"handler":"E14392","iparms":[{"av":"Ddo_agexport_Activeeventkey","ctrl":"DDO_AGEXPORT","prop":"ActiveEventKey"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV30TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV32TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV83TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV29TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV31TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV38TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV43TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV84TFLeaveRequestHalfDayOperator","fld":"vTFLEAVEREQUESTHALFDAYOPERATOR","pic":"ZZZ9"},{"av":"AV82TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV48TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV86TFEmployeeBalance","fld":"vTFEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV39TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV44TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV49TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV87TFEmployeeBalance_To","fld":"vTFEMPLOYEEBALANCE_TO","pic":"Z9.9"}]""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",""","oparms":[{"av":"AV13GridState","fld":"vGRIDSTATE"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV23ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV29TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV30TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV31TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV32TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV38TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV39TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV43TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV44TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV82TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV84TFLeaveRequestHalfDayOperator","fld":"vTFLEAVEREQUESTHALFDAYOPERATOR","pic":"ZZZ9"},{"av":"AV83TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV48TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV49TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV86TFEmployeeBalance","fld":"vTFEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV87TFEmployeeBalance_To","fld":"vTFEMPLOYEEBALANCE_TO","pic":"Z9.9"},{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"AV120Udparg20","fld":"vUDPARG20","pic":"9999999999","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV78ProjectIds","fld":"vPROJECTIDS","hsh":true},{"av":"AV92DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT","hsh":true},{"av":"sPrefix"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Selectedfixedfilter","ctrl":"DDO_GRID","prop":"SelectedFixedFilter"}]}""");
         setEventMetadata("VUPDATELEAVEREQUEST.CLICK","""{"handler":"E24392","iparms":[{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("VALID_LEAVETYPEID","""{"handler":"Valid_Leavetypeid","iparms":[]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Updateleaverequest","iparms":[]}""");
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
         Ddo_grid_Selectedcolumnfixedfilter = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_useraction1_Result = "";
         Dvelop_confirmpanel_useraction2_Result = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV18FilterFullText = "";
         AV23ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV99Pgmname = "";
         AV29TFEmployeeName = "";
         AV30TFEmployeeName_Sel = "";
         AV31TFLeaveTypeName = "";
         AV32TFLeaveTypeName_Sel = "";
         AV38TFLeaveRequestStartDate = DateTime.MinValue;
         AV39TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV43TFLeaveRequestEndDate = DateTime.MinValue;
         AV44TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV82TFLeaveRequestHalfDay = "";
         AV83TFLeaveRequestHalfDay_Sel = "";
         AV78ProjectIds = new GxSimpleCollection<long>();
         AV92DVelop_ConfirmPanel_RejectButton_Comment = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV26ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV56GridAppliedFilters = "";
         AV62AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV52DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV40DDO_LeaveRequestStartDateAuxDate = DateTime.MinValue;
         AV41DDO_LeaveRequestStartDateAuxDateTo = DateTime.MinValue;
         AV45DDO_LeaveRequestEndDateAuxDate = DateTime.MinValue;
         AV46DDO_LeaveRequestEndDateAuxDateTo = DateTime.MinValue;
         AV13GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV90employeename = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_grid_Selectedfixedfilter = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
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
         AV42DDO_LeaveRequestStartDateAuxDateText = "";
         ucTfleaverequeststartdate_rangepicker = new GXUserControl();
         AV47DDO_LeaveRequestEndDateAuxDateText = "";
         ucTfleaverequestenddate_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A148EmployeeName = "";
         A125LeaveTypeName = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A171LeaveRequestHalfDay = "";
         A132LeaveRequestStatus = "";
         A133LeaveRequestDescription = "";
         AV85LeaveRequestDescriptionVariable = "";
         A134LeaveRequestRejectionReason = "";
         AV88UserAction1 = "";
         AV89UserAction2 = "";
         AV94UpdateLeaverequest = "";
         lV100Leaverequestpendingds_4_filterfulltext = "";
         lV101Leaverequestpendingds_5_tfemployeename = "";
         lV103Leaverequestpendingds_7_tfleavetypename = "";
         lV109Leaverequestpendingds_13_tfleaverequesthalfday = "";
         AV79EmployeeIds = new GxSimpleCollection<long>();
         AV100Leaverequestpendingds_4_filterfulltext = "";
         AV102Leaverequestpendingds_6_tfemployeename_sel = "";
         AV101Leaverequestpendingds_5_tfemployeename = "";
         AV104Leaverequestpendingds_8_tfleavetypename_sel = "";
         AV103Leaverequestpendingds_7_tfleavetypename = "";
         AV105Leaverequestpendingds_9_tfleaverequeststartdate = DateTime.MinValue;
         AV106Leaverequestpendingds_10_tfleaverequeststartdate_to = DateTime.MinValue;
         AV107Leaverequestpendingds_11_tfleaverequestenddate = DateTime.MinValue;
         AV108Leaverequestpendingds_12_tfleaverequestenddate_to = DateTime.MinValue;
         AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel = "";
         AV109Leaverequestpendingds_13_tfleaverequesthalfday = "";
         H00392_A100CompanyId = new long[1] ;
         H00392_A147EmployeeBalance = new decimal[1] ;
         H00392_A106EmployeeId = new long[1] ;
         H00392_A134LeaveRequestRejectionReason = new string[] {""} ;
         H00392_A133LeaveRequestDescription = new string[] {""} ;
         H00392_A132LeaveRequestStatus = new string[] {""} ;
         H00392_A131LeaveRequestDuration = new decimal[1] ;
         H00392_A171LeaveRequestHalfDay = new string[] {""} ;
         H00392_n171LeaveRequestHalfDay = new bool[] {false} ;
         H00392_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         H00392_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         H00392_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         H00392_A125LeaveTypeName = new string[] {""} ;
         H00392_A148EmployeeName = new string[] {""} ;
         H00392_A124LeaveTypeId = new long[1] ;
         H00392_A127LeaveRequestId = new long[1] ;
         H00393_AGRID_nRecordCount = new long[1] ;
         AV63AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Session = context.GetSession();
         AV21ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV27ManageFiltersXml = "";
         AV22UserCustomValue = "";
         AV24ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV65LeaveRequest = new SdtLeaveRequest(context);
         AV75Employee = new SdtEmployee(context);
         AV76LeaveType = new SdtLeaveType(context);
         AV116GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV91Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV14GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char1 = "";
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV19ExcelFilename = "";
         AV20ErrorMessage = "";
         H00394_A162ProjectManagerId = new long[1] ;
         H00394_n162ProjectManagerId = new bool[] {false} ;
         H00394_A102ProjectId = new long[1] ;
         GXt_objcol_int6 = new GxSimpleCollection<long>();
         ucDvelop_confirmpanel_useraction2 = new GXUserControl();
         ucDvelop_confirmpanel_useraction1 = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.leaverequestpending__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestpending__default(),
            new Object[][] {
                new Object[] {
               H00392_A100CompanyId, H00392_A147EmployeeBalance, H00392_A106EmployeeId, H00392_A134LeaveRequestRejectionReason, H00392_A133LeaveRequestDescription, H00392_A132LeaveRequestStatus, H00392_A131LeaveRequestDuration, H00392_A171LeaveRequestHalfDay, H00392_n171LeaveRequestHalfDay, H00392_A130LeaveRequestEndDate,
               H00392_A129LeaveRequestStartDate, H00392_A128LeaveRequestDate, H00392_A125LeaveTypeName, H00392_A148EmployeeName, H00392_A124LeaveTypeId, H00392_A127LeaveRequestId
               }
               , new Object[] {
               H00393_AGRID_nRecordCount
               }
               , new Object[] {
               H00394_A162ProjectManagerId, H00394_n162ProjectManagerId, H00394_A102ProjectId
               }
            }
         );
         AV99Pgmname = "LeaveRequestPending";
         /* GeneXus formulas. */
         AV99Pgmname = "LeaveRequestPending";
         edtavLeaverequestdescriptionvariable_Enabled = 0;
         edtavUseraction1_Enabled = 0;
         edtavUseraction2_Enabled = 0;
         edtavUpdateleaverequest_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV15OrderedBy ;
      private short AV28ManageFiltersExecutionStep ;
      private short AV84TFLeaveRequestHalfDayOperator ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int edtavLeaverequestdescriptionvariable_Enabled ;
      private int edtavUseraction1_Enabled ;
      private int edtavUseraction2_Enabled ;
      private int edtavUpdateleaverequest_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtLeaveRequestId_Enabled ;
      private int edtLeaveTypeId_Enabled ;
      private int edtEmployeeName_Enabled ;
      private int edtLeaveTypeName_Enabled ;
      private int edtLeaveRequestDate_Enabled ;
      private int edtLeaveRequestStartDate_Enabled ;
      private int edtLeaveRequestEndDate_Enabled ;
      private int edtLeaveRequestHalfDay_Enabled ;
      private int edtLeaveRequestDuration_Enabled ;
      private int edtLeaveRequestDescription_Enabled ;
      private int edtLeaveRequestRejectionReason_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeBalance_Enabled ;
      private int edtEmployeeName_Visible ;
      private int edtLeaveTypeName_Visible ;
      private int edtLeaveRequestStartDate_Visible ;
      private int edtLeaveRequestEndDate_Visible ;
      private int edtLeaveRequestHalfDay_Visible ;
      private int edtLeaveRequestDuration_Visible ;
      private int edtavLeaverequestdescriptionvariable_Visible ;
      private int edtEmployeeBalance_Visible ;
      private int AV53PageToGo ;
      private int AV117GXV2 ;
      private int AV118GXV3 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A162ProjectManagerId ;
      private long AV120Udparg20 ;
      private long A102ProjectId ;
      private long AV54GridCurrentPage ;
      private long AV55GridPageCount ;
      private long AV70LeaveRequestId_Selected ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long GRID_nCurrentRecord ;
      private long A100CompanyId ;
      private long AV98Udparg3 ;
      private long GRID_nRecordCount ;
      private decimal AV48TFLeaveRequestDuration ;
      private decimal AV49TFLeaveRequestDuration_To ;
      private decimal AV86TFEmployeeBalance ;
      private decimal AV87TFEmployeeBalance_To ;
      private decimal A131LeaveRequestDuration ;
      private decimal A147EmployeeBalance ;
      private decimal AV112Leaverequestpendingds_16_tfleaverequestduration ;
      private decimal AV113Leaverequestpendingds_17_tfleaverequestduration_to ;
      private decimal AV114Leaverequestpendingds_18_tfemployeebalance ;
      private decimal AV115Leaverequestpendingds_19_tfemployeebalance_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumnfixedfilter ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_useraction1_Result ;
      private string Dvelop_confirmpanel_useraction2_Result ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_37_idx="0001" ;
      private string AV99Pgmname ;
      private string AV29TFEmployeeName ;
      private string AV30TFEmployeeName_Sel ;
      private string AV31TFLeaveTypeName ;
      private string AV32TFLeaveTypeName_Sel ;
      private string AV82TFLeaveRequestHalfDay ;
      private string AV83TFLeaveRequestHalfDay_Sel ;
      private string edtavLeaverequestdescriptionvariable_Internalname ;
      private string edtavUseraction1_Internalname ;
      private string edtavUseraction2_Internalname ;
      private string edtavUpdateleaverequest_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV90employeename ;
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
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Fixedfilters ;
      private string Ddo_grid_Format ;
      private string Ddo_grid_Selectedfixedfilter ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Dvelop_confirmpanel_useraction1_Title ;
      private string Dvelop_confirmpanel_useraction1_Confirmationtext ;
      private string Dvelop_confirmpanel_useraction1_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useraction1_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useraction1_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useraction1_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useraction1_Confirmtype ;
      private string Dvelop_confirmpanel_useraction2_Title ;
      private string Dvelop_confirmpanel_useraction2_Confirmationtext ;
      private string Dvelop_confirmpanel_useraction2_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useraction2_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useraction2_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useraction2_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useraction2_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
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
      private string divDdo_leaverequeststartdateauxdates_Internalname ;
      private string edtavDdo_leaverequeststartdateauxdatetext_Internalname ;
      private string edtavDdo_leaverequeststartdateauxdatetext_Jsonclick ;
      private string Tfleaverequeststartdate_rangepicker_Internalname ;
      private string divDdo_leaverequestenddateauxdates_Internalname ;
      private string edtavDdo_leaverequestenddateauxdatetext_Internalname ;
      private string edtavDdo_leaverequestenddateauxdatetext_Jsonclick ;
      private string Tfleaverequestenddate_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtLeaveRequestId_Internalname ;
      private string edtLeaveTypeId_Internalname ;
      private string A148EmployeeName ;
      private string edtEmployeeName_Internalname ;
      private string A125LeaveTypeName ;
      private string edtLeaveTypeName_Internalname ;
      private string edtLeaveRequestDate_Internalname ;
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
      private string AV88UserAction1 ;
      private string AV89UserAction2 ;
      private string AV94UpdateLeaverequest ;
      private string lV101Leaverequestpendingds_5_tfemployeename ;
      private string lV103Leaverequestpendingds_7_tfleavetypename ;
      private string lV109Leaverequestpendingds_13_tfleaverequesthalfday ;
      private string AV102Leaverequestpendingds_6_tfemployeename_sel ;
      private string AV101Leaverequestpendingds_5_tfemployeename ;
      private string AV104Leaverequestpendingds_8_tfleavetypename_sel ;
      private string AV103Leaverequestpendingds_7_tfleavetypename ;
      private string AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel ;
      private string AV109Leaverequestpendingds_13_tfleaverequesthalfday ;
      private string edtLeaveRequestHalfDay_Columnheaderclass ;
      private string edtLeaveRequestHalfDay_Columnclass ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char1 ;
      private string tblTabledvelop_confirmpanel_useraction2_Internalname ;
      private string Dvelop_confirmpanel_useraction2_Internalname ;
      private string tblTabledvelop_confirmpanel_useraction1_Internalname ;
      private string Dvelop_confirmpanel_useraction1_Internalname ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtLeaveRequestId_Jsonclick ;
      private string edtLeaveTypeId_Jsonclick ;
      private string edtEmployeeName_Jsonclick ;
      private string edtLeaveTypeName_Jsonclick ;
      private string edtLeaveRequestDate_Jsonclick ;
      private string edtLeaveRequestStartDate_Jsonclick ;
      private string edtLeaveRequestEndDate_Jsonclick ;
      private string edtLeaveRequestHalfDay_Jsonclick ;
      private string edtLeaveRequestDuration_Jsonclick ;
      private string GXCCtl ;
      private string cmbLeaveRequestStatus_Jsonclick ;
      private string edtLeaveRequestDescription_Jsonclick ;
      private string edtavLeaverequestdescriptionvariable_Jsonclick ;
      private string edtLeaveRequestRejectionReason_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeBalance_Jsonclick ;
      private string edtavUseraction1_Jsonclick ;
      private string edtavUseraction2_Jsonclick ;
      private string edtavUpdateleaverequest_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV38TFLeaveRequestStartDate ;
      private DateTime AV39TFLeaveRequestStartDate_To ;
      private DateTime AV43TFLeaveRequestEndDate ;
      private DateTime AV44TFLeaveRequestEndDate_To ;
      private DateTime AV40DDO_LeaveRequestStartDateAuxDate ;
      private DateTime AV41DDO_LeaveRequestStartDateAuxDateTo ;
      private DateTime AV45DDO_LeaveRequestEndDateAuxDate ;
      private DateTime AV46DDO_LeaveRequestEndDateAuxDateTo ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime AV105Leaverequestpendingds_9_tfleaverequeststartdate ;
      private DateTime AV106Leaverequestpendingds_10_tfleaverequeststartdate_to ;
      private DateTime AV107Leaverequestpendingds_11_tfleaverequestenddate ;
      private DateTime AV108Leaverequestpendingds_12_tfleaverequestenddate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV16OrderedDsc ;
      private bool n162ProjectManagerId ;
      private bool bGXsfl_37_Refreshing=false ;
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
      private bool n171LeaveRequestHalfDay ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV96Udparg1 ;
      private bool AV97Udparg2 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV92DVelop_ConfirmPanel_RejectButton_Comment ;
      private string AV21ColumnsSelectorXML ;
      private string AV27ManageFiltersXml ;
      private string AV22UserCustomValue ;
      private string AV18FilterFullText ;
      private string AV56GridAppliedFilters ;
      private string AV42DDO_LeaveRequestStartDateAuxDateText ;
      private string AV47DDO_LeaveRequestEndDateAuxDateText ;
      private string A133LeaveRequestDescription ;
      private string AV85LeaveRequestDescriptionVariable ;
      private string A134LeaveRequestRejectionReason ;
      private string lV100Leaverequestpendingds_4_filterfulltext ;
      private string AV100Leaverequestpendingds_4_filterfulltext ;
      private string AV19ExcelFilename ;
      private string AV20ErrorMessage ;
      private IGxSession AV25Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfleaverequeststartdate_rangepicker ;
      private GXUserControl ucTfleaverequestenddate_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_useraction2 ;
      private GXUserControl ucDvelop_confirmpanel_useraction1 ;
      private GXWebForm Form ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbLeaveRequestStatus ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV23ColumnsSelector ;
      private GxSimpleCollection<long> AV78ProjectIds ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV26ManageFiltersData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV62AGExportData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV13GridState ;
      private GxSimpleCollection<long> AV79EmployeeIds ;
      private IDataStoreProvider pr_default ;
      private long[] H00392_A100CompanyId ;
      private decimal[] H00392_A147EmployeeBalance ;
      private long[] H00392_A106EmployeeId ;
      private string[] H00392_A134LeaveRequestRejectionReason ;
      private string[] H00392_A133LeaveRequestDescription ;
      private string[] H00392_A132LeaveRequestStatus ;
      private decimal[] H00392_A131LeaveRequestDuration ;
      private string[] H00392_A171LeaveRequestHalfDay ;
      private bool[] H00392_n171LeaveRequestHalfDay ;
      private DateTime[] H00392_A130LeaveRequestEndDate ;
      private DateTime[] H00392_A129LeaveRequestStartDate ;
      private DateTime[] H00392_A128LeaveRequestDate ;
      private string[] H00392_A125LeaveTypeName ;
      private string[] H00392_A148EmployeeName ;
      private long[] H00392_A124LeaveTypeId ;
      private long[] H00392_A127LeaveRequestId ;
      private long[] H00393_AGRID_nRecordCount ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item AV63AGExportDataItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private SdtLeaveRequest AV65LeaveRequest ;
      private SdtEmployee AV75Employee ;
      private SdtLeaveType AV76LeaveType ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV116GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV91Message ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV14GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private long[] H00394_A162ProjectManagerId ;
      private bool[] H00394_n162ProjectManagerId ;
      private long[] H00394_A102ProjectId ;
      private GxSimpleCollection<long> GXt_objcol_int6 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class leaverequestpending__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class leaverequestpending__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H00392( IGxContext context ,
                                           long A106EmployeeId ,
                                           GxSimpleCollection<long> AV79EmployeeIds ,
                                           string AV100Leaverequestpendingds_4_filterfulltext ,
                                           string AV102Leaverequestpendingds_6_tfemployeename_sel ,
                                           string AV101Leaverequestpendingds_5_tfemployeename ,
                                           string AV104Leaverequestpendingds_8_tfleavetypename_sel ,
                                           string AV103Leaverequestpendingds_7_tfleavetypename ,
                                           DateTime AV105Leaverequestpendingds_9_tfleaverequeststartdate ,
                                           DateTime AV106Leaverequestpendingds_10_tfleaverequeststartdate_to ,
                                           DateTime AV107Leaverequestpendingds_11_tfleaverequestenddate ,
                                           DateTime AV108Leaverequestpendingds_12_tfleaverequestenddate_to ,
                                           string AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel ,
                                           string AV109Leaverequestpendingds_13_tfleaverequesthalfday ,
                                           short AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator ,
                                           decimal AV112Leaverequestpendingds_16_tfleaverequestduration ,
                                           decimal AV113Leaverequestpendingds_17_tfleaverequestduration_to ,
                                           decimal AV114Leaverequestpendingds_18_tfemployeebalance ,
                                           decimal AV115Leaverequestpendingds_19_tfemployeebalance_to ,
                                           string A148EmployeeName ,
                                           string A125LeaveTypeName ,
                                           string A171LeaveRequestHalfDay ,
                                           decimal A131LeaveRequestDuration ,
                                           decimal A147EmployeeBalance ,
                                           DateTime A129LeaveRequestStartDate ,
                                           DateTime A130LeaveRequestEndDate ,
                                           short AV15OrderedBy ,
                                           bool AV16OrderedDsc ,
                                           string A132LeaveRequestStatus ,
                                           bool AV96Udparg1 ,
                                           bool AV97Udparg2 ,
                                           long A100CompanyId ,
                                           long AV98Udparg3 )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int7 = new short[25];
       Object[] GXv_Object8 = new Object[2];
       string sSelectString;
       string sFromString;
       string sOrderString;
       sSelectString = " T3.CompanyId, T2.EmployeeBalance, T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestStatus, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDate, T3.LeaveTypeName, T2.EmployeeName, T1.LeaveTypeId, T1.LeaveRequestId";
       sFromString = " FROM ((LeaveRequest T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T3 ON T3.LeaveTypeId = T1.LeaveTypeId)";
       sOrderString = "";
       AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
       AddWhere(sWhereString, "(Not ( :AV96Udparg1 and Not :AV97Udparg2) or ( T3.CompanyId = :AV98Udparg3))");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext)) )
       {
          AddWhere(sWhereString, "(( T2.EmployeeName like '%' || :lV100Leaverequestpendingds_4_filterfulltext) or ( T3.LeaveTypeName like '%' || :lV100Leaverequestpendingds_4_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV100Leaverequestpendingds_4_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV100Leaverequestpendingds_4_filterfulltext) or ( SUBSTR(TO_CHAR(T2.EmployeeBalance,'90.9'), 2) like '%' || :lV100Leaverequestpendingds_4_filterfulltext))");
       }
       else
       {
          GXv_int7[3] = 1;
          GXv_int7[4] = 1;
          GXv_int7[5] = 1;
          GXv_int7[6] = 1;
          GXv_int7[7] = 1;
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Leaverequestpendingds_6_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Leaverequestpendingds_5_tfemployeename)) ) )
       {
          AddWhere(sWhereString, "(T2.EmployeeName like :lV101Leaverequestpendingds_5_tfemployeename)");
       }
       else
       {
          GXv_int7[8] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Leaverequestpendingds_6_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV102Leaverequestpendingds_6_tfemployeename_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T2.EmployeeName = ( :AV102Leaverequestpendingds_6_tfemployeename_sel))");
       }
       else
       {
          GXv_int7[9] = 1;
       }
       if ( StringUtil.StrCmp(AV102Leaverequestpendingds_6_tfemployeename_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Leaverequestpendingds_8_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Leaverequestpendingds_7_tfleavetypename)) ) )
       {
          AddWhere(sWhereString, "(T3.LeaveTypeName like :lV103Leaverequestpendingds_7_tfleavetypename)");
       }
       else
       {
          GXv_int7[10] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Leaverequestpendingds_8_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV104Leaverequestpendingds_8_tfleavetypename_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T3.LeaveTypeName = ( :AV104Leaverequestpendingds_8_tfleavetypename_sel))");
       }
       else
       {
          GXv_int7[11] = 1;
       }
       if ( StringUtil.StrCmp(AV104Leaverequestpendingds_8_tfleavetypename_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.LeaveTypeName))=0))");
       }
       if ( ! (DateTime.MinValue==AV105Leaverequestpendingds_9_tfleaverequeststartdate) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV105Leaverequestpendingds_9_tfleaverequeststartdate)");
       }
       else
       {
          GXv_int7[12] = 1;
       }
       if ( ! (DateTime.MinValue==AV106Leaverequestpendingds_10_tfleaverequeststartdate_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV106Leaverequestpendingds_10_tfleaverequeststartdate_to)");
       }
       else
       {
          GXv_int7[13] = 1;
       }
       if ( ! (DateTime.MinValue==AV107Leaverequestpendingds_11_tfleaverequestenddate) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV107Leaverequestpendingds_11_tfleaverequestenddate)");
       }
       else
       {
          GXv_int7[14] = 1;
       }
       if ( ! (DateTime.MinValue==AV108Leaverequestpendingds_12_tfleaverequestenddate_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV108Leaverequestpendingds_12_tfleaverequestenddate_to)");
       }
       else
       {
          GXv_int7[15] = 1;
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Leaverequestpendingds_13_tfleaverequesthalfday)) ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV109Leaverequestpendingds_13_tfleaverequesthalfday)");
       }
       else
       {
          GXv_int7[16] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel))");
       }
       else
       {
          GXv_int7[17] = 1;
       }
       if ( StringUtil.StrCmp(AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
       }
       if ( AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator == 1 )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
       }
       if ( AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator == 2 )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
       }
       if ( ! (Convert.ToDecimal(0)==AV112Leaverequestpendingds_16_tfleaverequestduration) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV112Leaverequestpendingds_16_tfleaverequestduration)");
       }
       else
       {
          GXv_int7[18] = 1;
       }
       if ( ! (Convert.ToDecimal(0)==AV113Leaverequestpendingds_17_tfleaverequestduration_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV113Leaverequestpendingds_17_tfleaverequestduration_to)");
       }
       else
       {
          GXv_int7[19] = 1;
       }
       if ( ! (Convert.ToDecimal(0)==AV114Leaverequestpendingds_18_tfemployeebalance) )
       {
          AddWhere(sWhereString, "(T2.EmployeeBalance >= :AV114Leaverequestpendingds_18_tfemployeebalance)");
       }
       else
       {
          GXv_int7[20] = 1;
       }
       if ( ! (Convert.ToDecimal(0)==AV115Leaverequestpendingds_19_tfemployeebalance_to) )
       {
          AddWhere(sWhereString, "(T2.EmployeeBalance <= :AV115Leaverequestpendingds_19_tfemployeebalance_to)");
       }
       else
       {
          GXv_int7[21] = 1;
       }
       if ( new userhasrole(context).executeUdp(  "Project Manager") )
       {
          AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV79EmployeeIds, "T1.EmployeeId IN (", ")")+")");
       }
       if ( AV15OrderedBy == 1 )
       {
          sOrderString += " ORDER BY T1.LeaveRequestId DESC";
       }
       else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
       {
          sOrderString += " ORDER BY T2.EmployeeName, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
       {
          sOrderString += " ORDER BY T2.EmployeeName DESC, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
       {
          sOrderString += " ORDER BY T3.LeaveTypeName, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
       {
          sOrderString += " ORDER BY T3.LeaveTypeName DESC, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 4 ) && ! AV16OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestStartDate, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 4 ) && ( AV16OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestStartDate DESC, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 5 ) && ! AV16OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestEndDate, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 5 ) && ( AV16OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestEndDate DESC, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 6 ) && ! AV16OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestHalfDay, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 6 ) && ( AV16OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestHalfDay DESC, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 7 ) && ! AV16OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestDuration, T1.LeaveRequestId";
       }
       else if ( ( AV15OrderedBy == 7 ) && ( AV16OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestDuration DESC, T1.LeaveRequestId";
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

    protected Object[] conditional_H00393( IGxContext context ,
                                           long A106EmployeeId ,
                                           GxSimpleCollection<long> AV79EmployeeIds ,
                                           string AV100Leaverequestpendingds_4_filterfulltext ,
                                           string AV102Leaverequestpendingds_6_tfemployeename_sel ,
                                           string AV101Leaverequestpendingds_5_tfemployeename ,
                                           string AV104Leaverequestpendingds_8_tfleavetypename_sel ,
                                           string AV103Leaverequestpendingds_7_tfleavetypename ,
                                           DateTime AV105Leaverequestpendingds_9_tfleaverequeststartdate ,
                                           DateTime AV106Leaverequestpendingds_10_tfleaverequeststartdate_to ,
                                           DateTime AV107Leaverequestpendingds_11_tfleaverequestenddate ,
                                           DateTime AV108Leaverequestpendingds_12_tfleaverequestenddate_to ,
                                           string AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel ,
                                           string AV109Leaverequestpendingds_13_tfleaverequesthalfday ,
                                           short AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator ,
                                           decimal AV112Leaverequestpendingds_16_tfleaverequestduration ,
                                           decimal AV113Leaverequestpendingds_17_tfleaverequestduration_to ,
                                           decimal AV114Leaverequestpendingds_18_tfemployeebalance ,
                                           decimal AV115Leaverequestpendingds_19_tfemployeebalance_to ,
                                           string A148EmployeeName ,
                                           string A125LeaveTypeName ,
                                           string A171LeaveRequestHalfDay ,
                                           decimal A131LeaveRequestDuration ,
                                           decimal A147EmployeeBalance ,
                                           DateTime A129LeaveRequestStartDate ,
                                           DateTime A130LeaveRequestEndDate ,
                                           short AV15OrderedBy ,
                                           bool AV16OrderedDsc ,
                                           string A132LeaveRequestStatus ,
                                           bool AV96Udparg1 ,
                                           bool AV97Udparg2 ,
                                           long A100CompanyId ,
                                           long AV98Udparg3 )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int9 = new short[22];
       Object[] GXv_Object10 = new Object[2];
       scmdbuf = "SELECT COUNT(*) FROM ((LeaveRequest T1 INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
       AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
       AddWhere(sWhereString, "(Not ( :AV96Udparg1 and Not :AV97Udparg2) or ( T2.CompanyId = :AV98Udparg3))");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Leaverequestpendingds_4_filterfulltext)) )
       {
          AddWhere(sWhereString, "(( T3.EmployeeName like '%' || :lV100Leaverequestpendingds_4_filterfulltext) or ( T2.LeaveTypeName like '%' || :lV100Leaverequestpendingds_4_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV100Leaverequestpendingds_4_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV100Leaverequestpendingds_4_filterfulltext) or ( SUBSTR(TO_CHAR(T3.EmployeeBalance,'90.9'), 2) like '%' || :lV100Leaverequestpendingds_4_filterfulltext))");
       }
       else
       {
          GXv_int9[3] = 1;
          GXv_int9[4] = 1;
          GXv_int9[5] = 1;
          GXv_int9[6] = 1;
          GXv_int9[7] = 1;
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Leaverequestpendingds_6_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Leaverequestpendingds_5_tfemployeename)) ) )
       {
          AddWhere(sWhereString, "(T3.EmployeeName like :lV101Leaverequestpendingds_5_tfemployeename)");
       }
       else
       {
          GXv_int9[8] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Leaverequestpendingds_6_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV102Leaverequestpendingds_6_tfemployeename_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T3.EmployeeName = ( :AV102Leaverequestpendingds_6_tfemployeename_sel))");
       }
       else
       {
          GXv_int9[9] = 1;
       }
       if ( StringUtil.StrCmp(AV102Leaverequestpendingds_6_tfemployeename_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Leaverequestpendingds_8_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Leaverequestpendingds_7_tfleavetypename)) ) )
       {
          AddWhere(sWhereString, "(T2.LeaveTypeName like :lV103Leaverequestpendingds_7_tfleavetypename)");
       }
       else
       {
          GXv_int9[10] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Leaverequestpendingds_8_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV104Leaverequestpendingds_8_tfleavetypename_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV104Leaverequestpendingds_8_tfleavetypename_sel))");
       }
       else
       {
          GXv_int9[11] = 1;
       }
       if ( StringUtil.StrCmp(AV104Leaverequestpendingds_8_tfleavetypename_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
       }
       if ( ! (DateTime.MinValue==AV105Leaverequestpendingds_9_tfleaverequeststartdate) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV105Leaverequestpendingds_9_tfleaverequeststartdate)");
       }
       else
       {
          GXv_int9[12] = 1;
       }
       if ( ! (DateTime.MinValue==AV106Leaverequestpendingds_10_tfleaverequeststartdate_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV106Leaverequestpendingds_10_tfleaverequeststartdate_to)");
       }
       else
       {
          GXv_int9[13] = 1;
       }
       if ( ! (DateTime.MinValue==AV107Leaverequestpendingds_11_tfleaverequestenddate) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV107Leaverequestpendingds_11_tfleaverequestenddate)");
       }
       else
       {
          GXv_int9[14] = 1;
       }
       if ( ! (DateTime.MinValue==AV108Leaverequestpendingds_12_tfleaverequestenddate_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV108Leaverequestpendingds_12_tfleaverequestenddate_to)");
       }
       else
       {
          GXv_int9[15] = 1;
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Leaverequestpendingds_13_tfleaverequesthalfday)) ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV109Leaverequestpendingds_13_tfleaverequesthalfday)");
       }
       else
       {
          GXv_int9[16] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel))");
       }
       else
       {
          GXv_int9[17] = 1;
       }
       if ( StringUtil.StrCmp(AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
       }
       if ( AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator == 1 )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
       }
       if ( AV110Leaverequestpendingds_14_tfleaverequesthalfdayoperator == 2 )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
       }
       if ( ! (Convert.ToDecimal(0)==AV112Leaverequestpendingds_16_tfleaverequestduration) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV112Leaverequestpendingds_16_tfleaverequestduration)");
       }
       else
       {
          GXv_int9[18] = 1;
       }
       if ( ! (Convert.ToDecimal(0)==AV113Leaverequestpendingds_17_tfleaverequestduration_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV113Leaverequestpendingds_17_tfleaverequestduration_to)");
       }
       else
       {
          GXv_int9[19] = 1;
       }
       if ( ! (Convert.ToDecimal(0)==AV114Leaverequestpendingds_18_tfemployeebalance) )
       {
          AddWhere(sWhereString, "(T3.EmployeeBalance >= :AV114Leaverequestpendingds_18_tfemployeebalance)");
       }
       else
       {
          GXv_int9[20] = 1;
       }
       if ( ! (Convert.ToDecimal(0)==AV115Leaverequestpendingds_19_tfemployeebalance_to) )
       {
          AddWhere(sWhereString, "(T3.EmployeeBalance <= :AV115Leaverequestpendingds_19_tfemployeebalance_to)");
       }
       else
       {
          GXv_int9[21] = 1;
       }
       if ( new userhasrole(context).executeUdp(  "Project Manager") )
       {
          AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV79EmployeeIds, "T1.EmployeeId IN (", ")")+")");
       }
       scmdbuf += sWhereString;
       if ( AV15OrderedBy == 1 )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 4 ) && ! AV16OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 4 ) && ( AV16OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 5 ) && ! AV16OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 5 ) && ( AV16OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 6 ) && ! AV16OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 6 ) && ( AV16OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 7 ) && ! AV16OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV15OrderedBy == 7 ) && ( AV16OrderedDsc ) )
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
                   return conditional_H00392(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (string)dynConstraints[27] , (bool)dynConstraints[28] , (bool)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] );
             case 1 :
                   return conditional_H00393(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (string)dynConstraints[27] , (bool)dynConstraints[28] , (bool)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] );
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
        Object[] prmH00394;
        prmH00394 = new Object[] {
        new ParDef("AV120Udparg20",GXType.Int64,10,0)
        };
        Object[] prmH00392;
        prmH00392 = new Object[] {
        new ParDef("AV96Udparg1",GXType.Boolean,4,0) ,
        new ParDef("AV97Udparg2",GXType.Boolean,4,0) ,
        new ParDef("AV98Udparg3",GXType.Int64,10,0) ,
        new ParDef("lV100Leaverequestpendingds_4_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV100Leaverequestpendingds_4_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV100Leaverequestpendingds_4_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV100Leaverequestpendingds_4_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV100Leaverequestpendingds_4_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV101Leaverequestpendingds_5_tfemployeename",GXType.Char,100,0) ,
        new ParDef("AV102Leaverequestpendingds_6_tfemployeename_sel",GXType.Char,100,0) ,
        new ParDef("lV103Leaverequestpendingds_7_tfleavetypename",GXType.Char,100,0) ,
        new ParDef("AV104Leaverequestpendingds_8_tfleavetypename_sel",GXType.Char,100,0) ,
        new ParDef("AV105Leaverequestpendingds_9_tfleaverequeststartdate",GXType.Date,8,0) ,
        new ParDef("AV106Leaverequestpendingds_10_tfleaverequeststartdate_to",GXType.Date,8,0) ,
        new ParDef("AV107Leaverequestpendingds_11_tfleaverequestenddate",GXType.Date,8,0) ,
        new ParDef("AV108Leaverequestpendingds_12_tfleaverequestenddate_to",GXType.Date,8,0) ,
        new ParDef("lV109Leaverequestpendingds_13_tfleaverequesthalfday",GXType.Char,20,0) ,
        new ParDef("AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
        new ParDef("AV112Leaverequestpendingds_16_tfleaverequestduration",GXType.Number,4,1) ,
        new ParDef("AV113Leaverequestpendingds_17_tfleaverequestduration_to",GXType.Number,4,1) ,
        new ParDef("AV114Leaverequestpendingds_18_tfemployeebalance",GXType.Number,4,1) ,
        new ParDef("AV115Leaverequestpendingds_19_tfemployeebalance_to",GXType.Number,4,1) ,
        new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo2",GXType.Int32,9,0)
        };
        Object[] prmH00393;
        prmH00393 = new Object[] {
        new ParDef("AV96Udparg1",GXType.Boolean,4,0) ,
        new ParDef("AV97Udparg2",GXType.Boolean,4,0) ,
        new ParDef("AV98Udparg3",GXType.Int64,10,0) ,
        new ParDef("lV100Leaverequestpendingds_4_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV100Leaverequestpendingds_4_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV100Leaverequestpendingds_4_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV100Leaverequestpendingds_4_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV100Leaverequestpendingds_4_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV101Leaverequestpendingds_5_tfemployeename",GXType.Char,100,0) ,
        new ParDef("AV102Leaverequestpendingds_6_tfemployeename_sel",GXType.Char,100,0) ,
        new ParDef("lV103Leaverequestpendingds_7_tfleavetypename",GXType.Char,100,0) ,
        new ParDef("AV104Leaverequestpendingds_8_tfleavetypename_sel",GXType.Char,100,0) ,
        new ParDef("AV105Leaverequestpendingds_9_tfleaverequeststartdate",GXType.Date,8,0) ,
        new ParDef("AV106Leaverequestpendingds_10_tfleaverequeststartdate_to",GXType.Date,8,0) ,
        new ParDef("AV107Leaverequestpendingds_11_tfleaverequestenddate",GXType.Date,8,0) ,
        new ParDef("AV108Leaverequestpendingds_12_tfleaverequestenddate_to",GXType.Date,8,0) ,
        new ParDef("lV109Leaverequestpendingds_13_tfleaverequesthalfday",GXType.Char,20,0) ,
        new ParDef("AV111Leaverequestpendingds_15_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
        new ParDef("AV112Leaverequestpendingds_16_tfleaverequestduration",GXType.Number,4,1) ,
        new ParDef("AV113Leaverequestpendingds_17_tfleaverequestduration_to",GXType.Number,4,1) ,
        new ParDef("AV114Leaverequestpendingds_18_tfemployeebalance",GXType.Number,4,1) ,
        new ParDef("AV115Leaverequestpendingds_19_tfemployeebalance_to",GXType.Number,4,1)
        };
        def= new CursorDef[] {
            new CursorDef("H00392", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00392,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00393", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00393,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00394", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV120Udparg20 ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00394,100, GxCacheFrequency.OFF ,false,false )
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
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 100);
              ((string[]) buf[13])[0] = rslt.getString(13, 100);
              ((long[]) buf[14])[0] = rslt.getLong(14);
              ((long[]) buf[15])[0] = rslt.getLong(15);
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
