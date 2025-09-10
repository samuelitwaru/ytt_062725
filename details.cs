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
   public class details : GXDataArea
   {
      public details( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public details( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           long aP1_LeaveRequestId )
      {
         this.AV11TrnMode = aP0_TrnMode;
         this.AV15LeaveRequestId = aP1_LeaveRequestId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavLeaverequest_leavetypeid = new GXCombobox();
         radavLeaverequest_leaverequesthalfday = new GXRadio();
         radavLeaverequest_leavetypevacationleave = new GXRadio();
         cmbavLeaverequest_leaverequeststatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TrnMode");
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
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TrnMode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
               AV11TrnMode = gxfirstwebparm;
               AssignAttri("", false, "AV11TrnMode", AV11TrnMode);
               GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV15LeaveRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV15LeaveRequestId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15LeaveRequestId), "ZZZZZZZZZ9"), context));
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_119 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_119"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_119_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_119_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_119_idx = GetPar( "sGXsfl_119_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV15LeaveRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestId"), "."), 18, MidpointRounding.ToEven));
         AV41CanApprove = StringUtil.StrToBool( GetPar( "CanApprove"));
         AV19ActionLeaveRole = StringUtil.StrToBool( GetPar( "ActionLeaveRole"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV8LeaveRequest);
         AV36LoggedInEmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "LoggedInEmployeeId"), "."), 18, MidpointRounding.ToEven));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         dynavLeaverequest_leavetypeid.FromJSonString( GetNextPar( ));
         AV8LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AV8LeaveRequest.gxTpr_Leaverequesthalfday = GetNextPar( );
         AV8LeaveRequest.gxTpr_Leavetypevacationleave = GetNextPar( );
         AV11TrnMode = GetPar( "TrnMode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV15LeaveRequestId, AV41CanApprove, AV19ActionLeaveRole, AV8LeaveRequest, AV36LoggedInEmployeeId, Gx_date, AV8LeaveRequest.gxTpr_Leavetypeid, AV8LeaveRequest.gxTpr_Leaverequesthalfday, AV8LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
            return "leavedetailspopup_Execute" ;
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
         PA4H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4H2( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("details.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11TrnMode)),UrlEncode(StringUtil.LTrimStr(AV15LeaveRequestId,10,0))}, new string[] {"TrnMode","LeaveRequestId"}) +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vCANAPPROVE", AV41CanApprove);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANAPPROVE", GetSecureSignedToken( "", AV41CanApprove, context));
         GxWebStd.gx_boolean_hidden_field( context, "vACTIONLEAVEROLE", AV19ActionLeaveRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vACTIONLEAVEROLE", GetSecureSignedToken( "", AV19ActionLeaveRole, context));
         GxWebStd.gx_hidden_field( context, "vLOGGEDINEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36LoggedInEmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGGEDINEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36LoggedInEmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vLEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15LeaveRequestId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Leaverequest", AV8LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Leaverequest", AV8LeaveRequest);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_119", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_119), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRID1PAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48Grid1PageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRID1APPLIEDFILTERS", AV49Grid1AppliedFilters);
         GxWebStd.gx_boolean_hidden_field( context, "vCANAPPROVE", AV41CanApprove);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANAPPROVE", GetSecureSignedToken( "", AV41CanApprove, context));
         GxWebStd.gx_boolean_hidden_field( context, "vACTIONLEAVEROLE", AV19ActionLeaveRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vACTIONLEAVEROLE", GetSecureSignedToken( "", AV19ActionLeaveRole, context));
         GxWebStd.gx_hidden_field( context, "vLOGGEDINEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36LoggedInEmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGGEDINEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36LoggedInEmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vLEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15LeaveRequestId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLEAVEREQUEST", AV8LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLEAVEREQUEST", AV8LeaveRequest);
         }
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Class", StringUtil.RTrim( Grid1paginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Grid1paginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Grid1paginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Shownext", StringUtil.BoolToStr( Grid1paginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Showlast", StringUtil.BoolToStr( Grid1paginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Grid1paginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Grid1paginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Grid1paginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Grid1paginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Grid1paginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Previous", StringUtil.RTrim( Grid1paginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Next", StringUtil.RTrim( Grid1paginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Caption", StringUtil.RTrim( Grid1paginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Grid1paginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Grid1paginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Title", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Title", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Comment", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Comment));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Bodycontentinternalname", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETEBUTTON_Title", StringUtil.RTrim( Dvelop_confirmpanel_deletebutton_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETEBUTTON_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_deletebutton_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETEBUTTON_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_deletebutton_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETEBUTTON_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_deletebutton_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETEBUTTON_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_deletebutton_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETEBUTTON_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_deletebutton_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETEBUTTON_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_deletebutton_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETEBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_deletebutton_Result));
         GxWebStd.gx_hidden_field( context, "vLEAVEREQUEST_Leavetypeid", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETEBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_deletebutton_Result));
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
            WE4H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4H2( ) ;
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
         return formatLink("details.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11TrnMode)),UrlEncode(StringUtil.LTrimStr(AV15LeaveRequestId,10,0))}, new string[] {"TrnMode","LeaveRequestId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Details" ;
      }

      public override string GetPgmdesc( )
      {
         return "Details" ;
      }

      protected void WB4H0( )
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
            /* User Defined Control */
            ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
            ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
            ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
            ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab1_title_Internalname, "Details", "", "", lblTab1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Details.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab1") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm col-md-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLefttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, divMaintable_Width, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableeditaction_Internalname, divTableeditaction_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBtneditbutton_Internalname, "<i class='fas fa-pen'></i>", "", "", lblBtneditbutton_Jsonclick, "'"+""+"'"+",false,"+"'"+"e114h1_client"+"'", "", "", 7, "", 1, 1, 0, 1, "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_employeename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_employeename_Internalname, "Employee Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeename_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Employeename), StringUtil.RTrim( context.localUtil.Format( AV8LeaveRequest.gxTpr_Employeename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeename_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavLeaverequest_leavetypeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLeaverequest_leavetypeid_Internalname, "Leave Type", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLeaverequest_leavetypeid, dynavLeaverequest_leavetypeid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0)), 1, dynavLeaverequest_leavetypeid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavLeaverequest_leavetypeid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 0, "HLP_Details.htm");
            dynavLeaverequest_leavetypeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0));
            AssignProp("", false, dynavLeaverequest_leavetypeid_Internalname, "Values", (string)(dynavLeaverequest_leavetypeid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDeductfromvacationdaysvariable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDeductfromvacationdaysvariable_Internalname, "Deduct from vacation days", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDeductfromvacationdaysvariable_Internalname, StringUtil.RTrim( AV20DeductFromVacationDaysVariable), StringUtil.RTrim( context.localUtil.Format( AV20DeductFromVacationDaysVariable, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDeductfromvacationdaysvariable_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDeductfromvacationdaysvariable_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_employeebalance_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_employeebalance_Internalname, "Vacation Days", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8LeaveRequest.gxTpr_Employeebalance, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_employeebalance_Enabled!=0) ? context.localUtil.Format( AV8LeaveRequest.gxTpr_Employeebalance, "Z9.9") : context.localUtil.Format( AV8LeaveRequest.gxTpr_Employeebalance, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeebalance_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeebalance_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequeststartdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequeststartdate_Internalname, "Start Date", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_119_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequeststartdate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequeststartdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequeststartdate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequeststartdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Details.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestenddate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestenddate_Internalname, "End Date", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_119_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestenddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestenddate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestenddate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequestenddate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestenddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequestenddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Details.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavLeaverequest_leaverequesthalfday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Half Day", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavLeaverequest_leaverequesthalfday, radavLeaverequest_leaverequesthalfday_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequesthalfday), "", 1, radavLeaverequest_leaverequesthalfday.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radavLeaverequest_leaverequesthalfday_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestduration_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestduration_Internalname, "Request Duration", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestduration_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8LeaveRequest.gxTpr_Leaverequestduration, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_leaverequestduration_Enabled!=0) ? context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestduration, "Z9.9") : context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestduration, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestduration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leaverequestduration_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestdescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestdescription_Internalname, "Request Description", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_119_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestdescription_Internalname, AV8LeaveRequest.gxTpr_Leaverequestdescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", 0, 1, edtavLeaverequest_leaverequestdescription_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLeaverequest_leaverequestrejectionreason_cell_Internalname, 1, 0, "px", 0, "px", divLeaverequest_leaverequestrejectionreason_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavLeaverequest_leaverequestrejectionreason_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestrejectionreason_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Rejection Reason", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_119_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, AV8LeaveRequest.gxTpr_Leaverequestrejectionreason, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", 0, edtavLeaverequest_leaverequestrejectionreason_Visible, edtavLeaverequest_leaverequestrejectionreason_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableupdateaction_Internalname, divTableupdateaction_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdatebutton_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Update", bttBtnupdatebutton_Jsonclick, 5, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUPDATEBUTTON\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancelupdatebutton_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Cancel", bttBtncancelupdatebutton_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCANCELUPDATEBUTTON\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableapproveaction_Internalname, divTableapproveaction_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnapprovebutton_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Approve", bttBtnapprovebutton_Jsonclick, 7, "Approve", "", StyleString, ClassString, bttBtnapprovebutton_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e124h1_client"+"'", TempTags, "", 2, "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrejectbutton_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Reject", bttBtnrejectbutton_Jsonclick, 7, "Reject", "", StyleString, ClassString, bttBtnrejectbutton_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e134h1_client"+"'", TempTags, "", 2, "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "ButtonMaterial RedButton";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndeletebutton_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(119), 3, 0)+","+"null"+");", "Delete", bttBtndeletebutton_Jsonclick, 7, "Delete", "", StyleString, ClassString, bttBtndeletebutton_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e144h1_client"+"'", TempTags, "", 2, "HLP_Details.htm");
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
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm col-md-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRighttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTab2_title_Internalname, "Change History", "", "", lblTab2_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Details.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "Tab2") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGrid1tablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl119( ) ;
         }
         if ( wbEnd == 119 )
         {
            wbEnd = 0;
            nRC_GXsfl_119 = (int)(nGXsfl_119_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGrid1paginationbar.SetProperty("Class", Grid1paginationbar_Class);
            ucGrid1paginationbar.SetProperty("ShowFirst", Grid1paginationbar_Showfirst);
            ucGrid1paginationbar.SetProperty("ShowPrevious", Grid1paginationbar_Showprevious);
            ucGrid1paginationbar.SetProperty("ShowNext", Grid1paginationbar_Shownext);
            ucGrid1paginationbar.SetProperty("ShowLast", Grid1paginationbar_Showlast);
            ucGrid1paginationbar.SetProperty("PagesToShow", Grid1paginationbar_Pagestoshow);
            ucGrid1paginationbar.SetProperty("PagingButtonsPosition", Grid1paginationbar_Pagingbuttonsposition);
            ucGrid1paginationbar.SetProperty("PagingCaptionPosition", Grid1paginationbar_Pagingcaptionposition);
            ucGrid1paginationbar.SetProperty("EmptyGridClass", Grid1paginationbar_Emptygridclass);
            ucGrid1paginationbar.SetProperty("RowsPerPageSelector", Grid1paginationbar_Rowsperpageselector);
            ucGrid1paginationbar.SetProperty("RowsPerPageOptions", Grid1paginationbar_Rowsperpageoptions);
            ucGrid1paginationbar.SetProperty("Previous", Grid1paginationbar_Previous);
            ucGrid1paginationbar.SetProperty("Next", Grid1paginationbar_Next);
            ucGrid1paginationbar.SetProperty("Caption", Grid1paginationbar_Caption);
            ucGrid1paginationbar.SetProperty("EmptyGridCaption", Grid1paginationbar_Emptygridcaption);
            ucGrid1paginationbar.SetProperty("RowsPerPageCaption", Grid1paginationbar_Rowsperpagecaption);
            ucGrid1paginationbar.SetProperty("CurrentPage", AV47Grid1CurrentPage);
            ucGrid1paginationbar.SetProperty("PageCount", AV48Grid1PageCount);
            ucGrid1paginationbar.SetProperty("AppliedFilters", AV49Grid1AppliedFilters);
            ucGrid1paginationbar.Render(context, "dvelop.dvpaginationbar", Grid1paginationbar_Internalname, "GRID1PAGINATIONBARContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGrid1currentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47Grid1CurrentPage), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV47Grid1CurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,135);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGrid1currentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGrid1currentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavLeaverequest_leavetypevacationleave, radavLeaverequest_leavetypevacationleave_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leavetypevacationleave), "", radavLeaverequest_leavetypevacationleave.Visible, 1, 0, 0, StyleString, ClassString, "", "", 0, radavLeaverequest_leavetypevacationleave_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "HLP_Details.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8LeaveRequest.gxTpr_Leaverequestid), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8LeaveRequest.gxTpr_Leaverequestid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leaverequestid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'" + sGXsfl_119_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leavetypename_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leavetypename), StringUtil.RTrim( context.localUtil.Format( AV8LeaveRequest.gxTpr_Leavetypename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leavetypename_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leavetypename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Details.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_119_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestdate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestdate_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leaverequestdate_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavLeaverequest_leaverequestdate_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Details.htm");
            context.WriteHtmlTextNl( "</div>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'" + sGXsfl_119_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLeaverequest_leaverequeststatus, cmbavLeaverequest_leaverequeststatus_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus), 1, cmbavLeaverequest_leaverequeststatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavLeaverequest_leaverequeststatus.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"", "", true, 0, "HLP_Details.htm");
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", (string)(cmbavLeaverequest_leaverequeststatus.ToJavascriptSource()), true);
            wb_table1_141_4H2( true) ;
         }
         else
         {
            wb_table1_141_4H2( false) ;
         }
         return  ;
      }

      protected void wb_table1_141_4H2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_146_4H2( true) ;
         }
         else
         {
            wb_table2_146_4H2( false) ;
         }
         return  ;
      }

      protected void wb_table2_146_4H2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_dvelop_confirmpanel_rejectbutton_body_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'" + sGXsfl_119_idx + "',0)\"";
            ClassString = "ConfirmComment";
            StyleString = "";
            ClassString = "ConfirmComment";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDvelop_confirmpanel_rejectbutton_comment_Internalname, AV18DVelop_ConfirmPanel_RejectButton_Comment, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", 0, 1, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "Reason for rejection", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            wb_table3_153_4H2( true) ;
         }
         else
         {
            wb_table3_153_4H2( false) ;
         }
         return  ;
      }

      protected void wb_table3_153_4H2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, "GRID1_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 119 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4H2( )
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
         Form.Meta.addItem("description", "Details", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4H0( ) ;
      }

      protected void WS4H2( )
      {
         START4H2( ) ;
         EVT4H2( ) ;
      }

      protected void EVT4H2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Grid1paginationbar.Changepage */
                              E154H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Grid1paginationbar.Changerowsperpage */
                              E164H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_APPROVEBUTTON.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_approvebutton.Close */
                              E174H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_REJECTBUTTON.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_rejectbutton.Close */
                              E184H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_DELETEBUTTON.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_deletebutton.Close */
                              E194H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATEBUTTON'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUpdateButton' */
                              E204H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCANCELUPDATEBUTTON'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCancelUpdateButton' */
                              E214H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUEST_LEAVETYPEID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Leaverequest_leavetypeid.Controlvaluechanged */
                              E224H2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_119_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
                              SubsflControlProps_1192( ) ;
                              A204AuditId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAuditId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A206AuditTableName = cgiGet( edtAuditTableName_Internalname);
                              A209AuditAction = cgiGet( edtAuditAction_Internalname);
                              A205AuditDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtAuditDate_Internalname), 0));
                              A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
                              A208AuditShortDescription = cgiGet( edtAuditShortDescription_Internalname);
                              A207AuditDescription = cgiGet( edtAuditDescription_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A211Trn_Id = cgiGet( edtTrn_Id_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E234H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E244H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid1.Load */
                                    E254H2 ();
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

      protected void WE4H2( )
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

      protected void PA4H2( )
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
               GX_FocusControl = edtavLeaverequest_employeename_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVLEAVEREQUEST_LEAVETYPEID4H1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVLEAVEREQUEST_LEAVETYPEID_data4H1( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVLEAVEREQUEST_LEAVETYPEID_html4H1( )
      {
         long gxdynajaxvalue;
         GXDLVLEAVEREQUEST_LEAVETYPEID_data4H1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLeaverequest_leavetypeid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavLeaverequest_leavetypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
         {
            AV8LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
      }

      protected void GXDLVLEAVEREQUEST_LEAVETYPEID_data4H1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H004H2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H004H2_A124LeaveTypeId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H004H2_A125LeaveTypeName[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1192( ) ;
         while ( nGXsfl_119_idx <= nRC_GXsfl_119 )
         {
            sendrow_1192( ) ;
            nGXsfl_119_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_119_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_119_idx+1);
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV15LeaveRequestId ,
                                        bool AV41CanApprove ,
                                        bool AV19ActionLeaveRole ,
                                        SdtLeaveRequest AV8LeaveRequest ,
                                        long AV36LoggedInEmployeeId ,
                                        DateTime Gx_date ,
                                        long GXV2 ,
                                        string GXV6 ,
                                        string GXV10 ,
                                        string AV11TrnMode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF4H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavLeaverequest_leavetypeid.Name = "LEAVEREQUEST_LEAVETYPEID";
            dynavLeaverequest_leavetypeid.WebTags = "";
            dynavLeaverequest_leavetypeid.removeAllItems();
            /* Using cursor H004H3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynavLeaverequest_leavetypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H004H3_A124LeaveTypeId[0]), 10, 0)), H004H3_A125LeaveTypeName[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
            {
               AV8LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
         {
            AV8LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLeaverequest_leavetypeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0));
            AssignProp("", false, dynavLeaverequest_leavetypeid_Internalname, "Values", dynavLeaverequest_leavetypeid.ToJavascriptSource(), true);
         }
         if ( cmbavLeaverequest_leaverequeststatus.ItemCount > 0 )
         {
            AV8LeaveRequest.gxTpr_Leaverequeststatus = cmbavLeaverequest_leaverequeststatus.getValidValue(AV8LeaveRequest.gxTpr_Leaverequeststatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", cmbavLeaverequest_leaverequeststatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         dynavLeaverequest_leavetypeid.Enabled = 0;
         AssignProp("", false, dynavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_leavetypeid.Enabled), 5, 0), true);
         edtavDeductfromvacationdaysvariable_Enabled = 0;
         AssignProp("", false, edtavDeductfromvacationdaysvariable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeductfromvacationdaysvariable_Enabled), 5, 0), true);
         edtavLeaverequest_employeebalance_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         radavLeaverequest_leaverequesthalfday.Enabled = 0;
         AssignProp("", false, radavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leaverequesthalfday.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
      }

      protected void RF4H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 119;
         /* Execute user event: Refresh */
         E244H2 ();
         nGXsfl_119_idx = 1;
         sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
         SubsflControlProps_1192( ) ;
         bGXsfl_119_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1192( ) ;
            GXPagingFrom2 = (int)(((subGrid1_Rows==0) ? 0 : GRID1_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid1_Rows==0) ? 10000 : subGrid1_fnc_Recordsperpage( )+1);
            /* Using cursor H004H4 */
            pr_default.execute(2, new Object[] {AV15LeaveRequestId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_119_idx = 1;
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGrid1_Rows == 0 ) || ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) ) )
            {
               A211Trn_Id = H004H4_A211Trn_Id[0];
               A106EmployeeId = H004H4_A106EmployeeId[0];
               A207AuditDescription = H004H4_A207AuditDescription[0];
               A208AuditShortDescription = H004H4_A208AuditShortDescription[0];
               A148EmployeeName = H004H4_A148EmployeeName[0];
               A205AuditDate = H004H4_A205AuditDate[0];
               A209AuditAction = H004H4_A209AuditAction[0];
               A206AuditTableName = H004H4_A206AuditTableName[0];
               A204AuditId = H004H4_A204AuditId[0];
               A148EmployeeName = H004H4_A148EmployeeName[0];
               /* Execute user event: Grid1.Load */
               E254H2 ();
               pr_default.readNext(2);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 119;
            WB4H0( ) ;
         }
         bGXsfl_119_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4H2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vCANAPPROVE", AV41CanApprove);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANAPPROVE", GetSecureSignedToken( "", AV41CanApprove, context));
         GxWebStd.gx_boolean_hidden_field( context, "vACTIONLEAVEROLE", AV19ActionLeaveRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vACTIONLEAVEROLE", GetSecureSignedToken( "", AV19ActionLeaveRole, context));
         GxWebStd.gx_hidden_field( context, "vLOGGEDINEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36LoggedInEmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGGEDINEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36LoggedInEmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         /* Using cursor H004H5 */
         pr_default.execute(3, new Object[] {AV15LeaveRequestId});
         GRID1_nRecordCount = H004H5_AGRID1_nRecordCount[0];
         pr_default.close(3);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         if ( subGrid1_Rows > 0 )
         {
            return subGrid1_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV15LeaveRequestId, AV41CanApprove, AV19ActionLeaveRole, AV8LeaveRequest, AV36LoggedInEmployeeId, Gx_date, AV8LeaveRequest.gxTpr_Leavetypeid, AV8LeaveRequest.gxTpr_Leaverequesthalfday, AV8LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV15LeaveRequestId, AV41CanApprove, AV19ActionLeaveRole, AV8LeaveRequest, AV36LoggedInEmployeeId, Gx_date, AV8LeaveRequest.gxTpr_Leavetypeid, AV8LeaveRequest.gxTpr_Leaverequesthalfday, AV8LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV15LeaveRequestId, AV41CanApprove, AV19ActionLeaveRole, AV8LeaveRequest, AV36LoggedInEmployeeId, Gx_date, AV8LeaveRequest.gxTpr_Leavetypeid, AV8LeaveRequest.gxTpr_Leaverequesthalfday, AV8LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV15LeaveRequestId, AV41CanApprove, AV19ActionLeaveRole, AV8LeaveRequest, AV36LoggedInEmployeeId, Gx_date, AV8LeaveRequest.gxTpr_Leavetypeid, AV8LeaveRequest.gxTpr_Leaverequesthalfday, AV8LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV15LeaveRequestId, AV41CanApprove, AV19ActionLeaveRole, AV8LeaveRequest, AV36LoggedInEmployeeId, Gx_date, AV8LeaveRequest.gxTpr_Leavetypeid, AV8LeaveRequest.gxTpr_Leaverequesthalfday, AV8LeaveRequest.gxTpr_Leavetypevacationleave, AV11TrnMode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         dynavLeaverequest_leavetypeid.Enabled = 0;
         AssignProp("", false, dynavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_leavetypeid.Enabled), 5, 0), true);
         edtavDeductfromvacationdaysvariable_Enabled = 0;
         AssignProp("", false, edtavDeductfromvacationdaysvariable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeductfromvacationdaysvariable_Enabled), 5, 0), true);
         edtavLeaverequest_employeebalance_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         radavLeaverequest_leaverequesthalfday.Enabled = 0;
         AssignProp("", false, radavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leaverequesthalfday.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
         edtAuditId_Enabled = 0;
         edtAuditTableName_Enabled = 0;
         edtAuditAction_Enabled = 0;
         edtAuditDate_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         edtAuditShortDescription_Enabled = 0;
         edtAuditDescription_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtTrn_Id_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E234H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLEAVEREQUEST"), AV8LeaveRequest);
            ajax_req_read_hidden_sdt(cgiGet( "Leaverequest"), AV8LeaveRequest);
            /* Read saved values. */
            nRC_GXsfl_119 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_119"), ".", ","), 18, MidpointRounding.ToEven));
            AV48Grid1PageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRID1PAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV49Grid1AppliedFilters = cgiGet( "vGRID1APPLIEDFILTERS");
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            Grid1paginationbar_Class = cgiGet( "GRID1PAGINATIONBAR_Class");
            Grid1paginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Showfirst"));
            Grid1paginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Showprevious"));
            Grid1paginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Shownext"));
            Grid1paginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Showlast"));
            Grid1paginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Pagestoshow"), ".", ","), 18, MidpointRounding.ToEven));
            Grid1paginationbar_Pagingbuttonsposition = cgiGet( "GRID1PAGINATIONBAR_Pagingbuttonsposition");
            Grid1paginationbar_Pagingcaptionposition = cgiGet( "GRID1PAGINATIONBAR_Pagingcaptionposition");
            Grid1paginationbar_Emptygridclass = cgiGet( "GRID1PAGINATIONBAR_Emptygridclass");
            Grid1paginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselector"));
            Grid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Grid1paginationbar_Rowsperpageoptions = cgiGet( "GRID1PAGINATIONBAR_Rowsperpageoptions");
            Grid1paginationbar_Previous = cgiGet( "GRID1PAGINATIONBAR_Previous");
            Grid1paginationbar_Next = cgiGet( "GRID1PAGINATIONBAR_Next");
            Grid1paginationbar_Caption = cgiGet( "GRID1PAGINATIONBAR_Caption");
            Grid1paginationbar_Emptygridcaption = cgiGet( "GRID1PAGINATIONBAR_Emptygridcaption");
            Grid1paginationbar_Rowsperpagecaption = cgiGet( "GRID1PAGINATIONBAR_Rowsperpagecaption");
            Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), ".", ","), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
            Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
            Dvelop_confirmpanel_approvebutton_Title = cgiGet( "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Title");
            Dvelop_confirmpanel_approvebutton_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Confirmationtext");
            Dvelop_confirmpanel_approvebutton_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Yesbuttoncaption");
            Dvelop_confirmpanel_approvebutton_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Nobuttoncaption");
            Dvelop_confirmpanel_approvebutton_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Cancelbuttoncaption");
            Dvelop_confirmpanel_approvebutton_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Yesbuttonposition");
            Dvelop_confirmpanel_approvebutton_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Confirmtype");
            Dvelop_confirmpanel_rejectbutton_Title = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Title");
            Dvelop_confirmpanel_rejectbutton_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Confirmationtext");
            Dvelop_confirmpanel_rejectbutton_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Yesbuttoncaption");
            Dvelop_confirmpanel_rejectbutton_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Nobuttoncaption");
            Dvelop_confirmpanel_rejectbutton_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Cancelbuttoncaption");
            Dvelop_confirmpanel_rejectbutton_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Yesbuttonposition");
            Dvelop_confirmpanel_rejectbutton_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Confirmtype");
            Dvelop_confirmpanel_rejectbutton_Comment = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Comment");
            Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Bodycontentinternalname");
            Dvelop_confirmpanel_deletebutton_Title = cgiGet( "DVELOP_CONFIRMPANEL_DELETEBUTTON_Title");
            Dvelop_confirmpanel_deletebutton_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_DELETEBUTTON_Confirmationtext");
            Dvelop_confirmpanel_deletebutton_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETEBUTTON_Yesbuttoncaption");
            Dvelop_confirmpanel_deletebutton_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETEBUTTON_Nobuttoncaption");
            Dvelop_confirmpanel_deletebutton_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETEBUTTON_Cancelbuttoncaption");
            Dvelop_confirmpanel_deletebutton_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_DELETEBUTTON_Yesbuttonposition");
            Dvelop_confirmpanel_deletebutton_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_DELETEBUTTON_Confirmtype");
            Grid1_empowerer_Gridinternalname = cgiGet( "GRID1_EMPOWERER_Gridinternalname");
            Grid1paginationbar_Selectedpage = cgiGet( "GRID1PAGINATIONBAR_Selectedpage");
            Grid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Dvelop_confirmpanel_approvebutton_Result = cgiGet( "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Result");
            Dvelop_confirmpanel_rejectbutton_Result = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Result");
            Dvelop_confirmpanel_deletebutton_Result = cgiGet( "DVELOP_CONFIRMPANEL_DELETEBUTTON_Result");
            /* Read variables values. */
            AV8LeaveRequest.gxTpr_Employeename = cgiGet( edtavLeaverequest_employeename_Internalname);
            dynavLeaverequest_leavetypeid.Name = dynavLeaverequest_leavetypeid_Internalname;
            dynavLeaverequest_leavetypeid.CurrentValue = cgiGet( dynavLeaverequest_leavetypeid_Internalname);
            AV8LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavLeaverequest_leavetypeid_Internalname), "."), 18, MidpointRounding.ToEven));
            AV20DeductFromVacationDaysVariable = cgiGet( edtavDeductfromvacationdaysvariable_Internalname);
            AssignAttri("", false, "AV20DeductFromVacationDaysVariable", AV20DeductFromVacationDaysVariable);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_EMPLOYEEBALANCE");
               GX_FocusControl = edtavLeaverequest_employeebalance_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Employeebalance = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Employeebalance = context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",");
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Start Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTSTARTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequeststartdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequeststartdate = DateTime.MinValue;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequeststartdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 2);
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request End Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTENDDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestenddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestenddate = DateTime.MinValue;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestenddate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 2);
            }
            AV8LeaveRequest.gxTpr_Leaverequesthalfday = cgiGet( radavLeaverequest_leaverequesthalfday_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVEREQUESTDURATION");
               GX_FocusControl = edtavLeaverequest_leaverequestduration_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestduration = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestduration = context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",");
            }
            AV8LeaveRequest.gxTpr_Leaverequestdescription = cgiGet( edtavLeaverequest_leaverequestdescription_Internalname);
            AV8LeaveRequest.gxTpr_Leaverequestrejectionreason = cgiGet( edtavLeaverequest_leaverequestrejectionreason_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRID1CURRENTPAGE");
               GX_FocusControl = edtavGrid1currentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV47Grid1CurrentPage = 0;
               AssignAttri("", false, "AV47Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV47Grid1CurrentPage), 10, 0));
            }
            else
            {
               AV47Grid1CurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV47Grid1CurrentPage), 10, 0));
            }
            AV8LeaveRequest.gxTpr_Leavetypevacationleave = cgiGet( radavLeaverequest_leavetypevacationleave_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVEREQUESTID");
               GX_FocusControl = edtavLeaverequest_leaverequestid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestid = 0;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            AV8LeaveRequest.gxTpr_Leavetypename = cgiGet( edtavLeaverequest_leavetypename_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8LeaveRequest.gxTpr_Leaverequestdate = DateTime.MinValue;
            }
            else
            {
               AV8LeaveRequest.gxTpr_Leaverequestdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestdate_Internalname), 2);
            }
            cmbavLeaverequest_leaverequeststatus.Name = cmbavLeaverequest_leaverequeststatus_Internalname;
            cmbavLeaverequest_leaverequeststatus.CurrentValue = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV8LeaveRequest.gxTpr_Leaverequeststatus = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV18DVelop_ConfirmPanel_RejectButton_Comment = cgiGet( edtavDvelop_confirmpanel_rejectbutton_comment_Internalname);
            AssignAttri("", false, "AV18DVelop_ConfirmPanel_RejectButton_Comment", AV18DVelop_ConfirmPanel_RejectButton_Comment);
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
         E234H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E234H2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV8LeaveRequest.Load(AV15LeaveRequestId);
         GXt_int1 = AV36LoggedInEmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV36LoggedInEmployeeId = GXt_int1;
         AssignAttri("", false, "AV36LoggedInEmployeeId", StringUtil.LTrimStr( (decimal)(AV36LoggedInEmployeeId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vLOGGEDINEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV36LoggedInEmployeeId), "ZZZZZZZZZ9"), context));
         AV41CanApprove = false;
         AssignAttri("", false, "AV41CanApprove", AV41CanApprove);
         GxWebStd.gx_hidden_field( context, "gxhash_vCANAPPROVE", GetSecureSignedToken( "", AV41CanApprove, context));
         AV37IsEditable = false;
         AssignAttri("", false, "AV37IsEditable", AV37IsEditable);
         AV19ActionLeaveRole = false;
         AssignAttri("", false, "AV19ActionLeaveRole", AV19ActionLeaveRole);
         GxWebStd.gx_hidden_field( context, "gxhash_vACTIONLEAVEROLE", GetSecureSignedToken( "", AV19ActionLeaveRole, context));
         if ( new userhasrole(context).executeUdp(  "Manager") || new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AV19ActionLeaveRole = true;
            AssignAttri("", false, "AV19ActionLeaveRole", AV19ActionLeaveRole);
            GxWebStd.gx_hidden_field( context, "gxhash_vACTIONLEAVEROLE", GetSecureSignedToken( "", AV19ActionLeaveRole, context));
         }
         if ( new userhasrole(context).executeUdp(  "Employee") && ( ( AV8LeaveRequest.gxTpr_Employeeid == AV36LoggedInEmployeeId ) ) && ( ( DateTimeUtil.ResetTime ( AV8LeaveRequest.gxTpr_Leaverequeststartdate ) > DateTimeUtil.ResetTime ( Gx_date ) ) ) )
         {
            AV37IsEditable = true;
            AssignAttri("", false, "AV37IsEditable", AV37IsEditable);
         }
         else
         {
            if ( new userhasrole(context).executeUdp(  "Manager") || new userhasrole(context).executeUdp(  "Project Manager") )
            {
               AV37IsEditable = true;
               AssignAttri("", false, "AV37IsEditable", AV37IsEditable);
               AV41CanApprove = (bool)(!((StringUtil.StrCmp(AV8LeaveRequest.gxTpr_Leaverequeststatus, "Approved")==0)));
               AssignAttri("", false, "AV41CanApprove", AV41CanApprove);
               GxWebStd.gx_hidden_field( context, "gxhash_vCANAPPROVE", GetSecureSignedToken( "", AV41CanApprove, context));
            }
         }
         divTableupdateaction_Visible = 0;
         AssignProp("", false, divTableupdateaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableupdateaction_Visible), 5, 0), true);
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV12LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV11TrnMode, "INS") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Insert") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "UPD") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Update") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "leaverequest_Delete") ) )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "INS") != 0 )
            {
               AV8LeaveRequest.Load(AV15LeaveRequestId);
               AV12LoadSuccess = AV8LeaveRequest.Success();
               if ( ! AV12LoadSuccess )
               {
                  AV10Messages = AV8LeaveRequest.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               if ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) )
               {
               }
            }
         }
         else
         {
            AV12LoadSuccess = false;
            CallWebObject(formatLink("gamnotauthorized.aspx") );
            context.wjLocDisableFrm = 1;
         }
         if ( AV12LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem("Confirm deletion.");
            }
         }
         divMaintable_Width = 750;
         AssignProp("", false, divMaintable_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divMaintable_Width), 9, 0), true);
         Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname = edtavDvelop_confirmpanel_rejectbutton_comment_Internalname;
         ucDvelop_confirmpanel_rejectbutton.SendProperty(context, "", false, Dvelop_confirmpanel_rejectbutton_Internalname, "BodyContentInternalName", Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         radavLeaverequest_leavetypevacationleave.Visible = 0;
         AssignProp("", false, radavLeaverequest_leavetypevacationleave_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leavetypevacationleave.Visible), 5, 0), true);
         edtavLeaverequest_leaverequestid_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestid_Visible), 5, 0), true);
         edtavLeaverequest_leavetypename_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leavetypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leavetypename_Visible), 5, 0), true);
         edtavLeaverequest_leaverequestdate_Visible = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdate_Visible), 5, 0), true);
         cmbavLeaverequest_leaverequeststatus.Visible = 0;
         AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLeaverequest_leaverequeststatus.Visible), 5, 0), true);
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, "", false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV47Grid1CurrentPage = 1;
         AssignAttri("", false, "AV47Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV47Grid1CurrentPage), 10, 0));
         edtavGrid1currentpage_Visible = 0;
         AssignProp("", false, edtavGrid1currentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGrid1currentpage_Visible), 5, 0), true);
         AV48Grid1PageCount = -1;
         AssignAttri("", false, "AV48Grid1PageCount", StringUtil.LTrimStr( (decimal)(AV48Grid1PageCount), 10, 0));
         Grid1paginationbar_Rowsperpageselectedvalue = subGrid1_Rows;
         ucGrid1paginationbar.SendProperty(context, "", false, Grid1paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0));
         AV20DeductFromVacationDaysVariable = AV8LeaveRequest.gxTpr_Leavetypevacationleave;
         AssignAttri("", false, "AV20DeductFromVacationDaysVariable", AV20DeductFromVacationDaysVariable);
      }

      protected void E244H2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      private void E254H2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 119;
         }
         sendrow_1192( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_119_Refreshing )
         {
            DoAjaxLoad(119, Grid1Row);
         }
      }

      protected void E154H2( )
      {
         /* Grid1paginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Previous") == 0 )
         {
            AV47Grid1CurrentPage = (long)(AV47Grid1CurrentPage-1);
            AssignAttri("", false, "AV47Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV47Grid1CurrentPage), 10, 0));
            subgrid1_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Next") == 0 )
         {
            AV47Grid1CurrentPage = (long)(AV47Grid1CurrentPage+1);
            AssignAttri("", false, "AV47Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV47Grid1CurrentPage), 10, 0));
            subgrid1_nextpage( ) ;
         }
         else
         {
            AV43PageToGo = (int)(Math.Round(NumberUtil.Val( Grid1paginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV47Grid1CurrentPage = AV43PageToGo;
            AssignAttri("", false, "AV47Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV47Grid1CurrentPage), 10, 0));
            subgrid1_gotopage( AV43PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E164H2( )
      {
         /* Grid1paginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid1_Rows = Grid1paginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV47Grid1CurrentPage = 1;
         AssignAttri("", false, "AV47Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV47Grid1CurrentPage), 10, 0));
         subgrid1_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E174H2( )
      {
         /* Dvelop_confirmpanel_approvebutton_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_approvebutton_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION APPROVEBUTTON' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
      }

      protected void E184H2( )
      {
         /* Dvelop_confirmpanel_rejectbutton_Close Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Dvelop_confirmpanel_rejectbutton_Result, "Yes") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18DVelop_ConfirmPanel_RejectButton_Comment)) )
         {
            /* Execute user subroutine: 'DO ACTION REJECTBUTTON' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
      }

      protected void E194H2( )
      {
         /* Dvelop_confirmpanel_deletebutton_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_deletebutton_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION DELETEBUTTON' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
      }

      protected void E204H2( )
      {
         /* 'DoUpdateButton' Routine */
         returnInSub = false;
         divTableeditaction_Visible = 1;
         AssignProp("", false, divTableeditaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableeditaction_Visible), 5, 0), true);
         divTableupdateaction_Visible = 0;
         AssignProp("", false, divTableupdateaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableupdateaction_Visible), 5, 0), true);
         divTableapproveaction_Visible = 1;
         AssignProp("", false, divTableapproveaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableapproveaction_Visible), 5, 0), true);
         /* Execute user subroutine: 'FORMFIELDSDISABLED' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV8LeaveRequest.Update() )
         {
            context.CommitDataStores("details",pr_default);
            GX_msglist.addItem("Leave Updated Successfully");
            this.executeExternalObjectMethod("", false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod("", false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod("", false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
            this.executeExternalObjectMethod("", false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
            AV8LeaveRequest.Load(AV15LeaveRequestId);
         }
         else
         {
            AV66GXV16 = 1;
            AV65GXV15 = AV8LeaveRequest.GetMessages();
            while ( AV66GXV16 <= AV65GXV15.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV65GXV15.Item(AV66GXV16));
               GX_msglist.addItem(AV9Message.gxTpr_Description);
               AV66GXV16 = (int)(AV66GXV16+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
      }

      protected void E214H2( )
      {
         /* 'DoCancelUpdateButton' Routine */
         returnInSub = false;
         divTableapproveaction_Visible = 1;
         AssignProp("", false, divTableapproveaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableapproveaction_Visible), 5, 0), true);
         divTableeditaction_Visible = 1;
         AssignProp("", false, divTableeditaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableeditaction_Visible), 5, 0), true);
         divTableupdateaction_Visible = 0;
         AssignProp("", false, divTableupdateaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableupdateaction_Visible), 5, 0), true);
         AV8LeaveRequest.Load(AV15LeaveRequestId);
         /* Execute user subroutine: 'FORMFIELDSDISABLED' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( AV41CanApprove ) )
         {
            bttBtnapprovebutton_Visible = 0;
            AssignProp("", false, bttBtnapprovebutton_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnapprovebutton_Visible), 5, 0), true);
         }
         if ( ! ( AV19ActionLeaveRole && ( StringUtil.StrCmp(AV8LeaveRequest.gxTpr_Leaverequeststatus, "Rejected") != 0 ) ) )
         {
            bttBtnrejectbutton_Visible = 0;
            AssignProp("", false, bttBtnrejectbutton_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnrejectbutton_Visible), 5, 0), true);
         }
         if ( ! ( ( AV8LeaveRequest.gxTpr_Employeeid == AV36LoggedInEmployeeId ) && ( DateTimeUtil.ResetTime ( AV8LeaveRequest.gxTpr_Leaverequeststartdate ) > DateTimeUtil.ResetTime ( Gx_date ) ) ) )
         {
            bttBtndeletebutton_Visible = 0;
            AssignProp("", false, bttBtndeletebutton_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndeletebutton_Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'DO ACTION APPROVEBUTTON' Routine */
         returnInSub = false;
         AV8LeaveRequest.gxTpr_Leaverequeststatus = "Approved";
         if ( AV8LeaveRequest.Update() )
         {
            this.executeExternalObjectMethod("", false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
            AV16Employee.Load(AV8LeaveRequest.gxTpr_Employeeid);
            AV17LeaveType.Load(AV8LeaveRequest.gxTpr_Leavetypeid);
            if ( AV16Employee.Update() )
            {
               GXt_char2 = AV17LeaveType.gxTpr_Leavetypename + " approved";
               GXt_char3 = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Request Approved</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV16Employee.gxTpr_Employeename + ",</p>" + "<p>We are pleased to inform you that your leave request has been approved. </p>" + "<p>Start Date: <b>" + context.localUtil.DToC( AV8LeaveRequest.gxTpr_Leaverequeststartdate, 2, "/") + "</b></p>" + "<p>End Date: <b>" + context.localUtil.DToC( AV8LeaveRequest.gxTpr_Leaverequestenddate, 2, "/") + "</b></p>" + "<p>Description: <b>" + AV8LeaveRequest.gxTpr_Leaverequestdescription + "</b></p><p>If you have any questions or need further assistance, please do not hesitate to contact us.</p><p>Best Regards,</p><p>Yukon Time Tracker Team</p></div></div>";
               new sendemail(context).executeSubmit(  AV16Employee.gxTpr_Employeeemail, ref  GXt_char2, ref  GXt_char3) ;
               new sdsendpushnotifications(context ).execute(  "Leave Request Approved",  "Your leave request made on "+context.localUtil.DToC( AV8LeaveRequest.gxTpr_Leaverequestdate, 2, "/")+" has been approved",  AV8LeaveRequest.gxTpr_Employeeid) ;
               context.CommitDataStores("details",pr_default);
               context.DoAjaxRefresh();
               GX_msglist.addItem("Leave Approved Successfully");
               this.executeExternalObjectMethod("", false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod("", false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod("", false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
               this.executeExternalObjectMethod("", false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod("", false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               context.RollbackDataStores("details",pr_default);
            }
         }
         else
         {
            context.RollbackDataStores("details",pr_default);
            AV68GXV18 = 1;
            AV67GXV17 = AV8LeaveRequest.GetMessages();
            while ( AV68GXV18 <= AV67GXV17.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV67GXV17.Item(AV68GXV18));
               GX_msglist.addItem(AV9Message.gxTpr_Description);
               AV68GXV18 = (int)(AV68GXV18+1);
            }
         }
      }

      protected void S152( )
      {
         /* 'DO ACTION REJECTBUTTON' Routine */
         returnInSub = false;
         AV8LeaveRequest.gxTpr_Leaverequeststatus = "Rejected";
         AV8LeaveRequest.gxTpr_Leaverequestrejectionreason = AV18DVelop_ConfirmPanel_RejectButton_Comment;
         if ( AV8LeaveRequest.Update() )
         {
            AV16Employee.Load(AV8LeaveRequest.gxTpr_Employeeid);
            AV17LeaveType.Load(AV8LeaveRequest.gxTpr_Leavetypeid);
            GXt_char3 = AV17LeaveType.gxTpr_Leavetypename + " rejected";
            GXt_char2 = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Request Rejected</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV16Employee.gxTpr_Employeename + ",</p>" + "<p>We regret to inform you that your leave request has been rejected. </p>" + "<p>Start Date: <b>" + context.localUtil.DToC( AV8LeaveRequest.gxTpr_Leaverequeststartdate, 2, "/") + "</b></p>" + "<p>EndDate: <b>" + context.localUtil.DToC( AV8LeaveRequest.gxTpr_Leaverequestenddate, 2, "/") + "</b></p>" + "<p>Reason for Rejection: <b>" + AV8LeaveRequest.gxTpr_Leaverequestrejectionreason + "</b></p><p>If you have any concerns or need clarification, please reach out to us.</p><p> Best Regards</p><p>The Yukon Time Tracker Team</p></div></div>";
            new sendemail(context).executeSubmit(  AV16Employee.gxTpr_Employeeemail, ref  GXt_char3, ref  GXt_char2) ;
            context.CommitDataStores("details",pr_default);
            GX_msglist.addItem("Leave Rejected Successfully");
            new sdsendpushnotifications(context ).execute(  "Leave Request Rejected",  "Your leave request made on "+context.localUtil.DToC( AV8LeaveRequest.gxTpr_Leaverequestdate, 2, "/")+" has been rejected",  AV8LeaveRequest.gxTpr_Employeeid) ;
            this.executeExternalObjectMethod("", false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod("", false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod("", false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
            this.executeExternalObjectMethod("", false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            context.RollbackDataStores("details",pr_default);
            AV70GXV20 = 1;
            AV69GXV19 = AV8LeaveRequest.GetMessages();
            while ( AV70GXV20 <= AV69GXV19.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV69GXV19.Item(AV70GXV20));
               GX_msglist.addItem(AV9Message.gxTpr_Description);
               AV70GXV20 = (int)(AV70GXV20+1);
            }
         }
      }

      protected void S162( )
      {
         /* 'DO ACTION DELETEBUTTON' Routine */
         returnInSub = false;
         AV8LeaveRequest.Delete();
         if ( AV8LeaveRequest.Success() )
         {
            context.CommitDataStores("details",pr_default);
            GX_msglist.addItem("Leave Deleted Successfully");
            this.executeExternalObjectMethod("", false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod("", false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod("", false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
            this.executeExternalObjectMethod("", false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV72GXV22 = 1;
            AV71GXV21 = AV8LeaveRequest.GetMessages();
            while ( AV72GXV22 <= AV71GXV21.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV71GXV21.Item(AV72GXV22));
               GX_msglist.addItem(AV9Message.gxTpr_Description);
               AV72GXV22 = (int)(AV72GXV22+1);
            }
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV8LeaveRequest.gxTpr_Leaverequestrejectionreason, "") != 0 ) ) )
         {
            edtavLeaverequest_leaverequestrejectionreason_Visible = 0;
            AssignProp("", false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Visible), 5, 0), true);
            divLeaverequest_leaverequestrejectionreason_cell_Class = "Invisible";
            AssignProp("", false, divLeaverequest_leaverequestrejectionreason_cell_Internalname, "Class", divLeaverequest_leaverequestrejectionreason_cell_Class, true);
         }
         else
         {
            edtavLeaverequest_leaverequestrejectionreason_Visible = 1;
            AssignProp("", false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Visible), 5, 0), true);
            divLeaverequest_leaverequestrejectionreason_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp("", false, divLeaverequest_leaverequestrejectionreason_cell_Internalname, "Class", divLeaverequest_leaverequestrejectionreason_cell_Class, true);
         }
         divTableeditaction_Visible = ((AV37IsEditable) ? 1 : 0);
         AssignProp("", false, divTableeditaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableeditaction_Visible), 5, 0), true);
         divTableapproveaction_Visible = (((AV37IsEditable)) ? 1 : 0);
         AssignProp("", false, divTableapproveaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableapproveaction_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV73GXV23 = 1;
         while ( AV73GXV23 <= AV10Messages.Count )
         {
            AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV10Messages.Item(AV73GXV23));
            GX_msglist.addItem(AV9Message.gxTpr_Description);
            AV73GXV23 = (int)(AV73GXV23+1);
         }
      }

      protected void E224H2( )
      {
         /* Leaverequest_leavetypeid_Controlvaluechanged Routine */
         returnInSub = false;
         AV17LeaveType.Load(AV8LeaveRequest.gxTpr_Leavetypeid);
         AV20DeductFromVacationDaysVariable = AV17LeaveType.gxTpr_Leavetypevacationleave;
         AssignAttri("", false, "AV20DeductFromVacationDaysVariable", AV20DeductFromVacationDaysVariable);
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'LEAVEDURATIONSUB' Routine */
         returnInSub = false;
      }

      protected void S172( )
      {
         /* 'FORMFIELDSDISABLED' Routine */
         returnInSub = false;
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         dynavLeaverequest_leavetypeid.Enabled = 0;
         AssignProp("", false, dynavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_leavetypeid.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         radavLeaverequest_leaverequesthalfday.Enabled = 0;
         AssignProp("", false, radavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leaverequesthalfday.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         AssignProp("", false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
      }

      protected void S182( )
      {
         /* 'FORFIELDSENABLED' Routine */
         returnInSub = false;
         dynavLeaverequest_leavetypeid.Enabled = 1;
         AssignProp("", false, dynavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_leavetypeid.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 1;
         AssignProp("", false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 1;
         AssignProp("", false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         radavLeaverequest_leaverequesthalfday.Enabled = 1;
         AssignProp("", false, radavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leaverequesthalfday.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 1;
         AssignProp("", false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 1;
         AssignProp("", false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
      }

      protected void wb_table3_153_4H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_deletebutton_Internalname, tblTabledvelop_confirmpanel_deletebutton_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_deletebutton.SetProperty("Title", Dvelop_confirmpanel_deletebutton_Title);
            ucDvelop_confirmpanel_deletebutton.SetProperty("ConfirmationText", Dvelop_confirmpanel_deletebutton_Confirmationtext);
            ucDvelop_confirmpanel_deletebutton.SetProperty("YesButtonCaption", Dvelop_confirmpanel_deletebutton_Yesbuttoncaption);
            ucDvelop_confirmpanel_deletebutton.SetProperty("NoButtonCaption", Dvelop_confirmpanel_deletebutton_Nobuttoncaption);
            ucDvelop_confirmpanel_deletebutton.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_deletebutton_Cancelbuttoncaption);
            ucDvelop_confirmpanel_deletebutton.SetProperty("YesButtonPosition", Dvelop_confirmpanel_deletebutton_Yesbuttonposition);
            ucDvelop_confirmpanel_deletebutton.SetProperty("ConfirmType", Dvelop_confirmpanel_deletebutton_Confirmtype);
            ucDvelop_confirmpanel_deletebutton.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_deletebutton_Internalname, "DVELOP_CONFIRMPANEL_DELETEBUTTONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_DELETEBUTTONContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_153_4H2e( true) ;
         }
         else
         {
            wb_table3_153_4H2e( false) ;
         }
      }

      protected void wb_table2_146_4H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_rejectbutton_Internalname, tblTabledvelop_confirmpanel_rejectbutton_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_rejectbutton.SetProperty("Title", Dvelop_confirmpanel_rejectbutton_Title);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("ConfirmationText", Dvelop_confirmpanel_rejectbutton_Confirmationtext);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("YesButtonCaption", Dvelop_confirmpanel_rejectbutton_Yesbuttoncaption);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("NoButtonCaption", Dvelop_confirmpanel_rejectbutton_Nobuttoncaption);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_rejectbutton_Cancelbuttoncaption);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("YesButtonPosition", Dvelop_confirmpanel_rejectbutton_Yesbuttonposition);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("ConfirmType", Dvelop_confirmpanel_rejectbutton_Confirmtype);
            ucDvelop_confirmpanel_rejectbutton.SetProperty("Comment", Dvelop_confirmpanel_rejectbutton_Comment);
            ucDvelop_confirmpanel_rejectbutton.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_rejectbutton_Internalname, "DVELOP_CONFIRMPANEL_REJECTBUTTONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_REJECTBUTTONContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_146_4H2e( true) ;
         }
         else
         {
            wb_table2_146_4H2e( false) ;
         }
      }

      protected void wb_table1_141_4H2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_approvebutton_Internalname, tblTabledvelop_confirmpanel_approvebutton_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_approvebutton.SetProperty("Title", Dvelop_confirmpanel_approvebutton_Title);
            ucDvelop_confirmpanel_approvebutton.SetProperty("ConfirmationText", Dvelop_confirmpanel_approvebutton_Confirmationtext);
            ucDvelop_confirmpanel_approvebutton.SetProperty("YesButtonCaption", Dvelop_confirmpanel_approvebutton_Yesbuttoncaption);
            ucDvelop_confirmpanel_approvebutton.SetProperty("NoButtonCaption", Dvelop_confirmpanel_approvebutton_Nobuttoncaption);
            ucDvelop_confirmpanel_approvebutton.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_approvebutton_Cancelbuttoncaption);
            ucDvelop_confirmpanel_approvebutton.SetProperty("YesButtonPosition", Dvelop_confirmpanel_approvebutton_Yesbuttonposition);
            ucDvelop_confirmpanel_approvebutton.SetProperty("ConfirmType", Dvelop_confirmpanel_approvebutton_Confirmtype);
            ucDvelop_confirmpanel_approvebutton.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_approvebutton_Internalname, "DVELOP_CONFIRMPANEL_APPROVEBUTTONContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_APPROVEBUTTONContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_141_4H2e( true) ;
         }
         else
         {
            wb_table1_141_4H2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV11TrnMode", AV11TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         AV15LeaveRequestId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV15LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV15LeaveRequestId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVEREQUESTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15LeaveRequestId), "ZZZZZZZZZ9"), context));
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
         PA4H2( ) ;
         WS4H2( ) ;
         WE4H2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202591096458", true, true);
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
         context.AddJavascriptSource("details.js", "?202591096458", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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

      protected void SubsflControlProps_1192( )
      {
         edtAuditId_Internalname = "AUDITID_"+sGXsfl_119_idx;
         edtAuditTableName_Internalname = "AUDITTABLENAME_"+sGXsfl_119_idx;
         edtAuditAction_Internalname = "AUDITACTION_"+sGXsfl_119_idx;
         edtAuditDate_Internalname = "AUDITDATE_"+sGXsfl_119_idx;
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_119_idx;
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION_"+sGXsfl_119_idx;
         edtAuditDescription_Internalname = "AUDITDESCRIPTION_"+sGXsfl_119_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_119_idx;
         edtTrn_Id_Internalname = "TRN_ID_"+sGXsfl_119_idx;
      }

      protected void SubsflControlProps_fel_1192( )
      {
         edtAuditId_Internalname = "AUDITID_"+sGXsfl_119_fel_idx;
         edtAuditTableName_Internalname = "AUDITTABLENAME_"+sGXsfl_119_fel_idx;
         edtAuditAction_Internalname = "AUDITACTION_"+sGXsfl_119_fel_idx;
         edtAuditDate_Internalname = "AUDITDATE_"+sGXsfl_119_fel_idx;
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_119_fel_idx;
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION_"+sGXsfl_119_fel_idx;
         edtAuditDescription_Internalname = "AUDITDESCRIPTION_"+sGXsfl_119_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_119_fel_idx;
         edtTrn_Id_Internalname = "TRN_ID_"+sGXsfl_119_fel_idx;
      }

      protected void sendrow_1192( )
      {
         sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
         SubsflControlProps_1192( ) ;
         WB4H0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_119_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_119_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_119_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A204AuditId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A204AuditId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditTableName_Internalname,StringUtil.RTrim( A206AuditTableName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditTableName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditAction_Internalname,(string)A209AuditAction,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditAction_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditDate_Internalname,context.localUtil.Format(A205AuditDate, "99/99/99"),context.localUtil.Format( A205AuditDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,StringUtil.RTrim( A148EmployeeName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditShortDescription_Internalname,(string)A208AuditShortDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditShortDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditDescription_Internalname,(string)A207AuditDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTrn_Id_Internalname,(string)A211Trn_Id,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTrn_Id_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)119,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4H2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_119_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_119_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_119_idx+1);
            sGXsfl_119_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_119_idx), 4, 0), 4, "0");
            SubsflControlProps_1192( ) ;
         }
         /* End function sendrow_1192 */
      }

      protected void init_web_controls( )
      {
         dynavLeaverequest_leavetypeid.Name = "LEAVEREQUEST_LEAVETYPEID";
         dynavLeaverequest_leavetypeid.WebTags = "";
         dynavLeaverequest_leavetypeid.removeAllItems();
         /* Using cursor H004H6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            dynavLeaverequest_leavetypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H004H6_A124LeaveTypeId[0]), 10, 0)), H004H6_A125LeaveTypeName[0], 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
         {
            AV8LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
         radavLeaverequest_leaverequesthalfday.Name = "LEAVEREQUEST_LEAVEREQUESTHALFDAY";
         radavLeaverequest_leaverequesthalfday.WebTags = "";
         radavLeaverequest_leaverequesthalfday.addItem("", "None", 0);
         radavLeaverequest_leaverequesthalfday.addItem("Morning", "Morning", 0);
         radavLeaverequest_leaverequesthalfday.addItem("Afternoon", "Afternoon", 0);
         radavLeaverequest_leavetypevacationleave.Name = "LEAVEREQUEST_LEAVETYPEVACATIONLEAVE";
         radavLeaverequest_leavetypevacationleave.WebTags = "";
         radavLeaverequest_leavetypevacationleave.addItem("No", "No", 0);
         radavLeaverequest_leavetypevacationleave.addItem("Yes", "Yes", 0);
         cmbavLeaverequest_leaverequeststatus.Name = "LEAVEREQUEST_LEAVEREQUESTSTATUS";
         cmbavLeaverequest_leaverequeststatus.WebTags = "";
         cmbavLeaverequest_leaverequeststatus.addItem("Pending", "Pending", 0);
         cmbavLeaverequest_leaverequeststatus.addItem("Approved", "Approved", 0);
         cmbavLeaverequest_leaverequeststatus.addItem("Rejected", "Rejected", 0);
         if ( cmbavLeaverequest_leaverequeststatus.ItemCount > 0 )
         {
            AV8LeaveRequest.gxTpr_Leaverequeststatus = cmbavLeaverequest_leaverequeststatus.getValidValue(AV8LeaveRequest.gxTpr_Leaverequeststatus);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl119( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"119\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Audit Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Audit Table Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Action") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Audit Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Action By") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Audit Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Employee Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Trn_Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A204AuditId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A206AuditTableName)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A209AuditAction));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A205AuditDate, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A148EmployeeName)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A208AuditShortDescription));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A207AuditDescription));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A211Trn_Id));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTab1_title_Internalname = "TAB1_TITLE";
         divLefttable_Internalname = "LEFTTABLE";
         lblBtneditbutton_Internalname = "BTNEDITBUTTON";
         divTableeditaction_Internalname = "TABLEEDITACTION";
         edtavLeaverequest_employeename_Internalname = "LEAVEREQUEST_EMPLOYEENAME";
         dynavLeaverequest_leavetypeid_Internalname = "LEAVEREQUEST_LEAVETYPEID";
         edtavDeductfromvacationdaysvariable_Internalname = "vDEDUCTFROMVACATIONDAYSVARIABLE";
         edtavLeaverequest_employeebalance_Internalname = "LEAVEREQUEST_EMPLOYEEBALANCE";
         edtavLeaverequest_leaverequeststartdate_Internalname = "LEAVEREQUEST_LEAVEREQUESTSTARTDATE";
         edtavLeaverequest_leaverequestenddate_Internalname = "LEAVEREQUEST_LEAVEREQUESTENDDATE";
         radavLeaverequest_leaverequesthalfday_Internalname = "LEAVEREQUEST_LEAVEREQUESTHALFDAY";
         edtavLeaverequest_leaverequestduration_Internalname = "LEAVEREQUEST_LEAVEREQUESTDURATION";
         edtavLeaverequest_leaverequestdescription_Internalname = "LEAVEREQUEST_LEAVEREQUESTDESCRIPTION";
         edtavLeaverequest_leaverequestrejectionreason_Internalname = "LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON";
         divLeaverequest_leaverequestrejectionreason_cell_Internalname = "LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON_CELL";
         bttBtnupdatebutton_Internalname = "BTNUPDATEBUTTON";
         bttBtncancelupdatebutton_Internalname = "BTNCANCELUPDATEBUTTON";
         divTableupdateaction_Internalname = "TABLEUPDATEACTION";
         bttBtnapprovebutton_Internalname = "BTNAPPROVEBUTTON";
         bttBtnrejectbutton_Internalname = "BTNREJECTBUTTON";
         bttBtndeletebutton_Internalname = "BTNDELETEBUTTON";
         divTableapproveaction_Internalname = "TABLEAPPROVEACTION";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblTab2_title_Internalname = "TAB2_TITLE";
         edtAuditId_Internalname = "AUDITID";
         edtAuditTableName_Internalname = "AUDITTABLENAME";
         edtAuditAction_Internalname = "AUDITACTION";
         edtAuditDate_Internalname = "AUDITDATE";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION";
         edtAuditDescription_Internalname = "AUDITDESCRIPTION";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtTrn_Id_Internalname = "TRN_ID";
         Grid1paginationbar_Internalname = "GRID1PAGINATIONBAR";
         divGrid1tablewithpaginationbar_Internalname = "GRID1TABLEWITHPAGINATIONBAR";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         divTablemain_Internalname = "TABLEMAIN";
         edtavGrid1currentpage_Internalname = "vGRID1CURRENTPAGE";
         radavLeaverequest_leavetypevacationleave_Internalname = "LEAVEREQUEST_LEAVETYPEVACATIONLEAVE";
         edtavLeaverequest_leaverequestid_Internalname = "LEAVEREQUEST_LEAVEREQUESTID";
         edtavLeaverequest_leavetypename_Internalname = "LEAVEREQUEST_LEAVETYPENAME";
         edtavLeaverequest_leaverequestdate_Internalname = "LEAVEREQUEST_LEAVEREQUESTDATE";
         cmbavLeaverequest_leaverequeststatus_Internalname = "LEAVEREQUEST_LEAVEREQUESTSTATUS";
         Dvelop_confirmpanel_approvebutton_Internalname = "DVELOP_CONFIRMPANEL_APPROVEBUTTON";
         tblTabledvelop_confirmpanel_approvebutton_Internalname = "TABLEDVELOP_CONFIRMPANEL_APPROVEBUTTON";
         Dvelop_confirmpanel_rejectbutton_Internalname = "DVELOP_CONFIRMPANEL_REJECTBUTTON";
         tblTabledvelop_confirmpanel_rejectbutton_Internalname = "TABLEDVELOP_CONFIRMPANEL_REJECTBUTTON";
         edtavDvelop_confirmpanel_rejectbutton_comment_Internalname = "vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT";
         divDiv_dvelop_confirmpanel_rejectbutton_body_Internalname = "DIV_DVELOP_CONFIRMPANEL_REJECTBUTTON_BODY";
         Dvelop_confirmpanel_deletebutton_Internalname = "DVELOP_CONFIRMPANEL_DELETEBUTTON";
         tblTabledvelop_confirmpanel_deletebutton_Internalname = "TABLEDVELOP_CONFIRMPANEL_DELETEBUTTON";
         Grid1_empowerer_Internalname = "GRID1_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtTrn_Id_Jsonclick = "";
         edtEmployeeId_Jsonclick = "";
         edtAuditDescription_Jsonclick = "";
         edtAuditShortDescription_Jsonclick = "";
         edtEmployeeName_Jsonclick = "";
         edtAuditDate_Jsonclick = "";
         edtAuditAction_Jsonclick = "";
         edtAuditTableName_Jsonclick = "";
         edtAuditId_Jsonclick = "";
         subGrid1_Class = "GridWithPaginationBar WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtTrn_Id_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtAuditDescription_Enabled = 0;
         edtAuditShortDescription_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         edtAuditDate_Enabled = 0;
         edtAuditAction_Enabled = 0;
         edtAuditTableName_Enabled = 0;
         edtAuditId_Enabled = 0;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = -1;
         edtavLeaverequest_leaverequestdescription_Enabled = -1;
         edtavLeaverequest_leaverequestduration_Enabled = -1;
         edtavLeaverequest_leaverequestenddate_Enabled = -1;
         edtavLeaverequest_leaverequeststartdate_Enabled = -1;
         edtavLeaverequest_employeebalance_Enabled = -1;
         dynavLeaverequest_leavetypeid.Enabled = -1;
         edtavLeaverequest_employeename_Enabled = -1;
         cmbavLeaverequest_leaverequeststatus_Jsonclick = "";
         cmbavLeaverequest_leaverequeststatus.Visible = 1;
         edtavLeaverequest_leaverequestdate_Jsonclick = "";
         edtavLeaverequest_leaverequestdate_Visible = 1;
         edtavLeaverequest_leavetypename_Jsonclick = "";
         edtavLeaverequest_leavetypename_Visible = 1;
         edtavLeaverequest_leaverequestid_Jsonclick = "";
         edtavLeaverequest_leaverequestid_Visible = 1;
         radavLeaverequest_leavetypevacationleave_Jsonclick = "";
         radavLeaverequest_leavetypevacationleave.Visible = 1;
         edtavGrid1currentpage_Jsonclick = "";
         edtavGrid1currentpage_Visible = 1;
         bttBtndeletebutton_Visible = 1;
         bttBtnrejectbutton_Visible = 1;
         bttBtnapprovebutton_Visible = 1;
         divTableapproveaction_Visible = 1;
         divTableupdateaction_Visible = 1;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         edtavLeaverequest_leaverequestrejectionreason_Visible = 1;
         divLeaverequest_leaverequestrejectionreason_cell_Class = "col-xs-12";
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         edtavLeaverequest_leaverequestduration_Jsonclick = "";
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         radavLeaverequest_leaverequesthalfday_Jsonclick = "";
         radavLeaverequest_leaverequesthalfday.Enabled = 1;
         edtavLeaverequest_leaverequestenddate_Jsonclick = "";
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         edtavLeaverequest_leaverequeststartdate_Jsonclick = "";
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         edtavLeaverequest_employeebalance_Jsonclick = "";
         edtavLeaverequest_employeebalance_Enabled = 0;
         edtavDeductfromvacationdaysvariable_Jsonclick = "";
         edtavDeductfromvacationdaysvariable_Enabled = 1;
         dynavLeaverequest_leavetypeid_Jsonclick = "";
         dynavLeaverequest_leavetypeid.Enabled = 0;
         edtavLeaverequest_employeename_Jsonclick = "";
         edtavLeaverequest_employeename_Enabled = 0;
         divTableeditaction_Visible = 1;
         divMaintable_Width = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Dvelop_confirmpanel_deletebutton_Confirmtype = "1";
         Dvelop_confirmpanel_deletebutton_Yesbuttonposition = "left";
         Dvelop_confirmpanel_deletebutton_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_deletebutton_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_deletebutton_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_deletebutton_Confirmationtext = "Are you sure you want to delete leave?";
         Dvelop_confirmpanel_deletebutton_Title = "Delete leave";
         Dvelop_confirmpanel_rejectbutton_Comment = "Required";
         Dvelop_confirmpanel_rejectbutton_Confirmtype = "1";
         Dvelop_confirmpanel_rejectbutton_Yesbuttonposition = "left";
         Dvelop_confirmpanel_rejectbutton_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_rejectbutton_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_rejectbutton_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_rejectbutton_Confirmationtext = "Are you sure you want to reject leave?";
         Dvelop_confirmpanel_rejectbutton_Title = "Reject leave";
         Dvelop_confirmpanel_approvebutton_Confirmtype = "1";
         Dvelop_confirmpanel_approvebutton_Yesbuttonposition = "left";
         Dvelop_confirmpanel_approvebutton_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_approvebutton_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_approvebutton_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_approvebutton_Confirmationtext = "Are you sure you want to approve this leave?";
         Dvelop_confirmpanel_approvebutton_Title = "Approve leave";
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 2;
         Grid1paginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Grid1paginationbar_Emptygridcaption = "No records found";
         Grid1paginationbar_Caption = "Page <CURRENT_PAGE> of <TOTAL_PAGES>";
         Grid1paginationbar_Next = "WWP_PagingNextCaption";
         Grid1paginationbar_Previous = "WWP_PagingPreviousCaption";
         Grid1paginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Grid1paginationbar_Rowsperpageselectedvalue = 10;
         Grid1paginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Grid1paginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Grid1paginationbar_Pagingcaptionposition = "Left";
         Grid1paginationbar_Pagingbuttonsposition = "Right";
         Grid1paginationbar_Pagestoshow = 5;
         Grid1paginationbar_Showlast = Convert.ToBoolean( 0);
         Grid1paginationbar_Shownext = Convert.ToBoolean( -1);
         Grid1paginationbar_Showprevious = Convert.ToBoolean( -1);
         Grid1paginationbar_Showfirst = Convert.ToBoolean( 0);
         Grid1paginationbar_Class = "PaginationBar";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Details";
         subGrid1_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"av":"dynavLeaverequest_leavetypeid"},{"av":"GXV2","fld":"LEAVEREQUEST_LEAVETYPEID","pic":"ZZZZZZZZZ9"},{"av":"radavLeaverequest_leaverequesthalfday"},{"av":"GXV6","fld":"LEAVEREQUEST_LEAVEREQUESTHALFDAY"},{"av":"radavLeaverequest_leavetypevacationleave"},{"av":"GXV10","fld":"LEAVEREQUEST_LEAVETYPEVACATIONLEAVE"},{"av":"AV41CanApprove","fld":"vCANAPPROVE","hsh":true},{"av":"AV19ActionLeaveRole","fld":"vACTIONLEAVEROLE","hsh":true},{"av":"AV36LoggedInEmployeeId","fld":"vLOGGEDINEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV15LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNAPPROVEBUTTON","prop":"Visible"},{"ctrl":"BTNREJECTBUTTON","prop":"Visible"},{"ctrl":"BTNDELETEBUTTON","prop":"Visible"}]}""");
         setEventMetadata("GRID1.LOAD","""{"handler":"E254H2","iparms":[]}""");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE","""{"handler":"E154H2","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV15LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV41CanApprove","fld":"vCANAPPROVE","hsh":true},{"av":"AV19ActionLeaveRole","fld":"vACTIONLEAVEROLE","hsh":true},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"av":"AV36LoggedInEmployeeId","fld":"vLOGGEDINEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"dynavLeaverequest_leavetypeid"},{"av":"GXV2","fld":"LEAVEREQUEST_LEAVETYPEID","pic":"ZZZZZZZZZ9"},{"av":"radavLeaverequest_leaverequesthalfday"},{"av":"GXV6","fld":"LEAVEREQUEST_LEAVEREQUESTHALFDAY"},{"av":"radavLeaverequest_leavetypevacationleave"},{"av":"GXV10","fld":"LEAVEREQUEST_LEAVETYPEVACATIONLEAVE"},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"Grid1paginationbar_Selectedpage","ctrl":"GRID1PAGINATIONBAR","prop":"SelectedPage"},{"av":"AV47Grid1CurrentPage","fld":"vGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE",""","oparms":[{"av":"AV47Grid1CurrentPage","fld":"vGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"},{"ctrl":"BTNAPPROVEBUTTON","prop":"Visible"},{"ctrl":"BTNREJECTBUTTON","prop":"Visible"},{"ctrl":"BTNDELETEBUTTON","prop":"Visible"}]}""");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E164H2","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV15LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV41CanApprove","fld":"vCANAPPROVE","hsh":true},{"av":"AV19ActionLeaveRole","fld":"vACTIONLEAVEROLE","hsh":true},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"av":"AV36LoggedInEmployeeId","fld":"vLOGGEDINEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"dynavLeaverequest_leavetypeid"},{"av":"GXV2","fld":"LEAVEREQUEST_LEAVETYPEID","pic":"ZZZZZZZZZ9"},{"av":"radavLeaverequest_leaverequesthalfday"},{"av":"GXV6","fld":"LEAVEREQUEST_LEAVEREQUESTHALFDAY"},{"av":"radavLeaverequest_leavetypevacationleave"},{"av":"GXV10","fld":"LEAVEREQUEST_LEAVETYPEVACATIONLEAVE"},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"Grid1paginationbar_Rowsperpageselectedvalue","ctrl":"GRID1PAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV47Grid1CurrentPage","fld":"vGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOAPPROVEBUTTON'","""{"handler":"E124H1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_APPROVEBUTTON.CLOSE","""{"handler":"E174H2","iparms":[{"av":"Dvelop_confirmpanel_approvebutton_Result","ctrl":"DVELOP_CONFIRMPANEL_APPROVEBUTTON","prop":"Result"},{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV15LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV41CanApprove","fld":"vCANAPPROVE","hsh":true},{"av":"AV19ActionLeaveRole","fld":"vACTIONLEAVEROLE","hsh":true},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"av":"AV36LoggedInEmployeeId","fld":"vLOGGEDINEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"dynavLeaverequest_leavetypeid"},{"av":"GXV2","fld":"LEAVEREQUEST_LEAVETYPEID","pic":"ZZZZZZZZZ9"},{"av":"radavLeaverequest_leaverequesthalfday"},{"av":"GXV6","fld":"LEAVEREQUEST_LEAVEREQUESTHALFDAY"},{"av":"radavLeaverequest_leavetypevacationleave"},{"av":"GXV10","fld":"LEAVEREQUEST_LEAVETYPEVACATIONLEAVE"},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_APPROVEBUTTON.CLOSE",""","oparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"ctrl":"BTNAPPROVEBUTTON","prop":"Visible"},{"ctrl":"BTNREJECTBUTTON","prop":"Visible"},{"ctrl":"BTNDELETEBUTTON","prop":"Visible"}]}""");
         setEventMetadata("'DOREJECTBUTTON'","""{"handler":"E134H1","iparms":[]""");
         setEventMetadata("'DOREJECTBUTTON'",""","oparms":[{"av":"AV18DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_REJECTBUTTON.CLOSE","""{"handler":"E184H2","iparms":[{"av":"Dvelop_confirmpanel_rejectbutton_Result","ctrl":"DVELOP_CONFIRMPANEL_REJECTBUTTON","prop":"Result"},{"av":"AV18DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT"},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_REJECTBUTTON.CLOSE",""","oparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("'DODELETEBUTTON'","""{"handler":"E144H1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETEBUTTON.CLOSE","""{"handler":"E194H2","iparms":[{"av":"Dvelop_confirmpanel_deletebutton_Result","ctrl":"DVELOP_CONFIRMPANEL_DELETEBUTTON","prop":"Result"},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETEBUTTON.CLOSE",""","oparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("'DOUPDATEBUTTON'","""{"handler":"E204H2","iparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"av":"AV15LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOUPDATEBUTTON'",""","oparms":[{"av":"divTableeditaction_Visible","ctrl":"TABLEEDITACTION","prop":"Visible"},{"av":"divTableupdateaction_Visible","ctrl":"TABLEUPDATEACTION","prop":"Visible"},{"av":"divTableapproveaction_Visible","ctrl":"TABLEAPPROVEACTION","prop":"Visible"},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"ctrl":"LEAVEREQUEST_EMPLOYEENAME","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVETYPEID","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTSTARTDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTENDDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTHALFDAY","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTDESCRIPTION","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON","prop":"Enabled"}]}""");
         setEventMetadata("'DOCANCELUPDATEBUTTON'","""{"handler":"E214H2","iparms":[{"av":"AV15LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOCANCELUPDATEBUTTON'",""","oparms":[{"av":"divTableapproveaction_Visible","ctrl":"TABLEAPPROVEACTION","prop":"Visible"},{"av":"divTableeditaction_Visible","ctrl":"TABLEEDITACTION","prop":"Visible"},{"av":"divTableupdateaction_Visible","ctrl":"TABLEUPDATEACTION","prop":"Visible"},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"ctrl":"LEAVEREQUEST_EMPLOYEENAME","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVETYPEID","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTSTARTDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTENDDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTHALFDAY","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTDESCRIPTION","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON","prop":"Enabled"}]}""");
         setEventMetadata("'DOEDITBUTTON'","""{"handler":"E114H1","iparms":[]""");
         setEventMetadata("'DOEDITBUTTON'",""","oparms":[{"av":"divTableupdateaction_Visible","ctrl":"TABLEUPDATEACTION","prop":"Visible"},{"av":"divTableapproveaction_Visible","ctrl":"TABLEAPPROVEACTION","prop":"Visible"},{"av":"divTableeditaction_Visible","ctrl":"TABLEEDITACTION","prop":"Visible"},{"ctrl":"LEAVEREQUEST_LEAVETYPEID","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTSTARTDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTENDDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTHALFDAY","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTDESCRIPTION","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON","prop":"Enabled"}]}""");
         setEventMetadata("LEAVEREQUEST_LEAVETYPEID.CONTROLVALUECHANGED","""{"handler":"E224H2","iparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("LEAVEREQUEST_LEAVETYPEID.CONTROLVALUECHANGED",""","oparms":[{"av":"AV20DeductFromVacationDaysVariable","fld":"vDEDUCTFROMVACATIONDAYSVARIABLE"}]}""");
         setEventMetadata("VALIDV_GXV14","""{"handler":"Validv_Gxv14","iparms":[]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Trn_id","iparms":[]}""");
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
         wcpOAV11TrnMode = "";
         Grid1paginationbar_Selectedpage = "";
         Dvelop_confirmpanel_approvebutton_Result = "";
         Dvelop_confirmpanel_rejectbutton_Result = "";
         Dvelop_confirmpanel_deletebutton_Result = "";
         AV8LeaveRequest = new SdtLeaveRequest(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV49Grid1AppliedFilters = "";
         Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname = "";
         Grid1_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTab1_title_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblBtneditbutton_Jsonclick = "";
         TempTags = "";
         AV20DeductFromVacationDaysVariable = "";
         bttBtnupdatebutton_Jsonclick = "";
         bttBtncancelupdatebutton_Jsonclick = "";
         bttBtnapprovebutton_Jsonclick = "";
         bttBtnrejectbutton_Jsonclick = "";
         bttBtndeletebutton_Jsonclick = "";
         lblTab2_title_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         ucGrid1paginationbar = new GXUserControl();
         AV18DVelop_ConfirmPanel_RejectButton_Comment = "";
         ucGrid1_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A206AuditTableName = "";
         A209AuditAction = "";
         A205AuditDate = DateTime.MinValue;
         A148EmployeeName = "";
         A208AuditShortDescription = "";
         A207AuditDescription = "";
         A211Trn_Id = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H004H2_A124LeaveTypeId = new long[1] ;
         H004H2_A125LeaveTypeName = new string[] {""} ;
         H004H3_A124LeaveTypeId = new long[1] ;
         H004H3_A125LeaveTypeName = new string[] {""} ;
         H004H4_A211Trn_Id = new string[] {""} ;
         H004H4_A106EmployeeId = new long[1] ;
         H004H4_A207AuditDescription = new string[] {""} ;
         H004H4_A208AuditShortDescription = new string[] {""} ;
         H004H4_A148EmployeeName = new string[] {""} ;
         H004H4_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         H004H4_A209AuditAction = new string[] {""} ;
         H004H4_A206AuditTableName = new string[] {""} ;
         H004H4_A204AuditId = new long[1] ;
         H004H5_AGRID1_nRecordCount = new long[1] ;
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         ucDvelop_confirmpanel_rejectbutton = new GXUserControl();
         Grid1Row = new GXWebRow();
         AV65GXV15 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV16Employee = new SdtEmployee(context);
         AV17LeaveType = new SdtLeaveType(context);
         AV67GXV17 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_char3 = "";
         GXt_char2 = "";
         AV69GXV19 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV71GXV21 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         ucDvelop_confirmpanel_deletebutton = new GXUserControl();
         ucDvelop_confirmpanel_approvebutton = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         H004H6_A124LeaveTypeId = new long[1] ;
         H004H6_A125LeaveTypeName = new string[] {""} ;
         Grid1Column = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.details__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.details__default(),
            new Object[][] {
                new Object[] {
               H004H2_A124LeaveTypeId, H004H2_A125LeaveTypeName
               }
               , new Object[] {
               H004H3_A124LeaveTypeId, H004H3_A125LeaveTypeName
               }
               , new Object[] {
               H004H4_A211Trn_Id, H004H4_A106EmployeeId, H004H4_A207AuditDescription, H004H4_A208AuditShortDescription, H004H4_A148EmployeeName, H004H4_A205AuditDate, H004H4_A209AuditAction, H004H4_A206AuditTableName, H004H4_A204AuditId
               }
               , new Object[] {
               H004H5_AGRID1_nRecordCount
               }
               , new Object[] {
               H004H6_A124LeaveTypeId, H004H6_A125LeaveTypeName
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         edtavLeaverequest_employeename_Enabled = 0;
         dynavLeaverequest_leavetypeid.Enabled = 0;
         edtavDeductfromvacationdaysvariable_Enabled = 0;
         edtavLeaverequest_employeebalance_Enabled = 0;
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         radavLeaverequest_leaverequesthalfday.Enabled = 0;
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int Grid1paginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_119 ;
      private int subGrid1_Rows ;
      private int nGXsfl_119_idx=1 ;
      private int Grid1paginationbar_Pagestoshow ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int divMaintable_Width ;
      private int divTableeditaction_Visible ;
      private int edtavLeaverequest_employeename_Enabled ;
      private int edtavDeductfromvacationdaysvariable_Enabled ;
      private int edtavLeaverequest_employeebalance_Enabled ;
      private int edtavLeaverequest_leaverequeststartdate_Enabled ;
      private int edtavLeaverequest_leaverequestenddate_Enabled ;
      private int edtavLeaverequest_leaverequestduration_Enabled ;
      private int edtavLeaverequest_leaverequestdescription_Enabled ;
      private int edtavLeaverequest_leaverequestrejectionreason_Visible ;
      private int edtavLeaverequest_leaverequestrejectionreason_Enabled ;
      private int divTableupdateaction_Visible ;
      private int divTableapproveaction_Visible ;
      private int bttBtnapprovebutton_Visible ;
      private int bttBtnrejectbutton_Visible ;
      private int bttBtndeletebutton_Visible ;
      private int edtavGrid1currentpage_Visible ;
      private int edtavLeaverequest_leaverequestid_Visible ;
      private int edtavLeaverequest_leavetypename_Visible ;
      private int edtavLeaverequest_leaverequestdate_Visible ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtAuditId_Enabled ;
      private int edtAuditTableName_Enabled ;
      private int edtAuditAction_Enabled ;
      private int edtAuditDate_Enabled ;
      private int edtEmployeeName_Enabled ;
      private int edtAuditShortDescription_Enabled ;
      private int edtAuditDescription_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtTrn_Id_Enabled ;
      private int AV43PageToGo ;
      private int AV66GXV16 ;
      private int AV68GXV18 ;
      private int AV70GXV20 ;
      private int AV72GXV22 ;
      private int AV73GXV23 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV15LeaveRequestId ;
      private long wcpOAV15LeaveRequestId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV36LoggedInEmployeeId ;
      private long AV48Grid1PageCount ;
      private long AV47Grid1CurrentPage ;
      private long A204AuditId ;
      private long A106EmployeeId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private long GXt_int1 ;
      private string AV11TrnMode ;
      private string wcpOAV11TrnMode ;
      private string Grid1paginationbar_Selectedpage ;
      private string Dvelop_confirmpanel_approvebutton_Result ;
      private string Dvelop_confirmpanel_rejectbutton_Result ;
      private string Dvelop_confirmpanel_deletebutton_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_119_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Grid1paginationbar_Class ;
      private string Grid1paginationbar_Pagingbuttonsposition ;
      private string Grid1paginationbar_Pagingcaptionposition ;
      private string Grid1paginationbar_Emptygridclass ;
      private string Grid1paginationbar_Rowsperpageoptions ;
      private string Grid1paginationbar_Previous ;
      private string Grid1paginationbar_Next ;
      private string Grid1paginationbar_Caption ;
      private string Grid1paginationbar_Emptygridcaption ;
      private string Grid1paginationbar_Rowsperpagecaption ;
      private string Gxuitabspanel_tabs1_Class ;
      private string Dvelop_confirmpanel_approvebutton_Title ;
      private string Dvelop_confirmpanel_approvebutton_Confirmationtext ;
      private string Dvelop_confirmpanel_approvebutton_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_approvebutton_Nobuttoncaption ;
      private string Dvelop_confirmpanel_approvebutton_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_approvebutton_Yesbuttonposition ;
      private string Dvelop_confirmpanel_approvebutton_Confirmtype ;
      private string Dvelop_confirmpanel_rejectbutton_Title ;
      private string Dvelop_confirmpanel_rejectbutton_Confirmationtext ;
      private string Dvelop_confirmpanel_rejectbutton_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_rejectbutton_Nobuttoncaption ;
      private string Dvelop_confirmpanel_rejectbutton_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_rejectbutton_Yesbuttonposition ;
      private string Dvelop_confirmpanel_rejectbutton_Confirmtype ;
      private string Dvelop_confirmpanel_rejectbutton_Comment ;
      private string Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname ;
      private string Dvelop_confirmpanel_deletebutton_Title ;
      private string Dvelop_confirmpanel_deletebutton_Confirmationtext ;
      private string Dvelop_confirmpanel_deletebutton_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_deletebutton_Nobuttoncaption ;
      private string Dvelop_confirmpanel_deletebutton_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_deletebutton_Yesbuttonposition ;
      private string Dvelop_confirmpanel_deletebutton_Confirmtype ;
      private string Grid1_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTab1_title_Internalname ;
      private string lblTab1_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string divLefttable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTableeditaction_Internalname ;
      private string lblBtneditbutton_Internalname ;
      private string lblBtneditbutton_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string edtavLeaverequest_employeename_Internalname ;
      private string TempTags ;
      private string edtavLeaverequest_employeename_Jsonclick ;
      private string dynavLeaverequest_leavetypeid_Internalname ;
      private string dynavLeaverequest_leavetypeid_Jsonclick ;
      private string edtavDeductfromvacationdaysvariable_Internalname ;
      private string AV20DeductFromVacationDaysVariable ;
      private string edtavDeductfromvacationdaysvariable_Jsonclick ;
      private string edtavLeaverequest_employeebalance_Internalname ;
      private string edtavLeaverequest_employeebalance_Jsonclick ;
      private string edtavLeaverequest_leaverequeststartdate_Internalname ;
      private string edtavLeaverequest_leaverequeststartdate_Jsonclick ;
      private string edtavLeaverequest_leaverequestenddate_Internalname ;
      private string edtavLeaverequest_leaverequestenddate_Jsonclick ;
      private string radavLeaverequest_leaverequesthalfday_Internalname ;
      private string radavLeaverequest_leaverequesthalfday_Jsonclick ;
      private string edtavLeaverequest_leaverequestduration_Internalname ;
      private string edtavLeaverequest_leaverequestduration_Jsonclick ;
      private string edtavLeaverequest_leaverequestdescription_Internalname ;
      private string divLeaverequest_leaverequestrejectionreason_cell_Internalname ;
      private string divLeaverequest_leaverequestrejectionreason_cell_Class ;
      private string edtavLeaverequest_leaverequestrejectionreason_Internalname ;
      private string divTableupdateaction_Internalname ;
      private string bttBtnupdatebutton_Internalname ;
      private string bttBtnupdatebutton_Jsonclick ;
      private string bttBtncancelupdatebutton_Internalname ;
      private string bttBtncancelupdatebutton_Jsonclick ;
      private string divTableapproveaction_Internalname ;
      private string bttBtnapprovebutton_Internalname ;
      private string bttBtnapprovebutton_Jsonclick ;
      private string bttBtnrejectbutton_Internalname ;
      private string bttBtnrejectbutton_Jsonclick ;
      private string bttBtndeletebutton_Internalname ;
      private string bttBtndeletebutton_Jsonclick ;
      private string divRighttable_Internalname ;
      private string lblTab2_title_Internalname ;
      private string lblTab2_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divGrid1tablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string Grid1paginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavGrid1currentpage_Internalname ;
      private string edtavGrid1currentpage_Jsonclick ;
      private string radavLeaverequest_leavetypevacationleave_Internalname ;
      private string radavLeaverequest_leavetypevacationleave_Jsonclick ;
      private string edtavLeaverequest_leaverequestid_Internalname ;
      private string edtavLeaverequest_leaverequestid_Jsonclick ;
      private string edtavLeaverequest_leavetypename_Internalname ;
      private string edtavLeaverequest_leavetypename_Jsonclick ;
      private string edtavLeaverequest_leaverequestdate_Internalname ;
      private string edtavLeaverequest_leaverequestdate_Jsonclick ;
      private string cmbavLeaverequest_leaverequeststatus_Internalname ;
      private string cmbavLeaverequest_leaverequeststatus_Jsonclick ;
      private string divDiv_dvelop_confirmpanel_rejectbutton_body_Internalname ;
      private string edtavDvelop_confirmpanel_rejectbutton_comment_Internalname ;
      private string Grid1_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtAuditId_Internalname ;
      private string A206AuditTableName ;
      private string edtAuditTableName_Internalname ;
      private string edtAuditAction_Internalname ;
      private string edtAuditDate_Internalname ;
      private string A148EmployeeName ;
      private string edtEmployeeName_Internalname ;
      private string edtAuditShortDescription_Internalname ;
      private string edtAuditDescription_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string edtTrn_Id_Internalname ;
      private string gxwrpcisep ;
      private string Dvelop_confirmpanel_rejectbutton_Internalname ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string tblTabledvelop_confirmpanel_deletebutton_Internalname ;
      private string Dvelop_confirmpanel_deletebutton_Internalname ;
      private string tblTabledvelop_confirmpanel_rejectbutton_Internalname ;
      private string tblTabledvelop_confirmpanel_approvebutton_Internalname ;
      private string Dvelop_confirmpanel_approvebutton_Internalname ;
      private string sGXsfl_119_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtAuditId_Jsonclick ;
      private string edtAuditTableName_Jsonclick ;
      private string edtAuditAction_Jsonclick ;
      private string edtAuditDate_Jsonclick ;
      private string edtEmployeeName_Jsonclick ;
      private string edtAuditShortDescription_Jsonclick ;
      private string edtAuditDescription_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string edtTrn_Id_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime Gx_date ;
      private DateTime A205AuditDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV41CanApprove ;
      private bool AV19ActionLeaveRole ;
      private bool Grid1paginationbar_Showfirst ;
      private bool Grid1paginationbar_Showprevious ;
      private bool Grid1paginationbar_Shownext ;
      private bool Grid1paginationbar_Showlast ;
      private bool Grid1paginationbar_Rowsperpageselector ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_119_Refreshing=false ;
      private bool returnInSub ;
      private bool AV37IsEditable ;
      private bool AV12LoadSuccess ;
      private bool gx_refresh_fired ;
      private string AV18DVelop_ConfirmPanel_RejectButton_Comment ;
      private string AV49Grid1AppliedFilters ;
      private string A209AuditAction ;
      private string A208AuditShortDescription ;
      private string A207AuditDescription ;
      private string A211Trn_Id ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucGrid1paginationbar ;
      private GXUserControl ucGrid1_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_rejectbutton ;
      private GXUserControl ucDvelop_confirmpanel_deletebutton ;
      private GXUserControl ucDvelop_confirmpanel_approvebutton ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavLeaverequest_leavetypeid ;
      private GXRadio radavLeaverequest_leaverequesthalfday ;
      private GXRadio radavLeaverequest_leavetypevacationleave ;
      private GXCombobox cmbavLeaverequest_leaverequeststatus ;
      private SdtLeaveRequest AV8LeaveRequest ;
      private IDataStoreProvider pr_default ;
      private long[] H004H2_A124LeaveTypeId ;
      private string[] H004H2_A125LeaveTypeName ;
      private long[] H004H3_A124LeaveTypeId ;
      private string[] H004H3_A125LeaveTypeName ;
      private string[] H004H4_A211Trn_Id ;
      private long[] H004H4_A106EmployeeId ;
      private string[] H004H4_A207AuditDescription ;
      private string[] H004H4_A208AuditShortDescription ;
      private string[] H004H4_A148EmployeeName ;
      private DateTime[] H004H4_A205AuditDate ;
      private string[] H004H4_A209AuditAction ;
      private string[] H004H4_A206AuditTableName ;
      private long[] H004H4_A204AuditId ;
      private long[] H004H5_AGRID1_nRecordCount ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV65GXV15 ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private SdtEmployee AV16Employee ;
      private SdtLeaveType AV17LeaveType ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV67GXV17 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV69GXV19 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV71GXV21 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H004H6_A124LeaveTypeId ;
      private string[] H004H6_A125LeaveTypeName ;
      private IDataStoreProvider pr_gam ;
   }

   public class details__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class details__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH004H2;
        prmH004H2 = new Object[] {
        };
        Object[] prmH004H3;
        prmH004H3 = new Object[] {
        };
        Object[] prmH004H4;
        prmH004H4 = new Object[] {
        new ParDef("AV15LeaveRequestId",GXType.Int64,10,0) ,
        new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo2",GXType.Int32,9,0)
        };
        Object[] prmH004H5;
        prmH004H5 = new Object[] {
        new ParDef("AV15LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmH004H6;
        prmH004H6 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H004H2", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H004H3", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H3,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H004H4", "SELECT T1.Trn_Id, T1.EmployeeId, T1.AuditDescription, T1.AuditShortDescription, T2.EmployeeName, T1.AuditDate, T1.AuditAction, T1.AuditTableName, T1.AuditId FROM (Audit T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) WHERE (:AV15LeaveRequestId = TO_NUMBER(0 || RTRIM(LTRIM(T1.Trn_Id)),'9999999999999999999999999999.99999999999999')) AND (RTRIM(LTRIM(T1.AuditTableName)) = ( 'LeaveRequest')) ORDER BY T1.AuditId  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H4,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H004H5", "SELECT COUNT(*) FROM (Audit T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) WHERE (:AV15LeaveRequestId = TO_NUMBER(0 || RTRIM(LTRIM(T1.Trn_Id)),'9999999999999999999999999999.99999999999999')) AND (RTRIM(LTRIM(T1.AuditTableName)) = ( 'LeaveRequest')) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H004H6", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H6,0, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
     }
  }

}

}
