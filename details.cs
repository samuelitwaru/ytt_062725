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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vLEAVEREQUEST", AV8LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vLEAVEREQUEST", AV8LeaveRequest);
         }
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_approvebutton_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_REJECTBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_rejectbutton_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETEBUTTON_Result", StringUtil.RTrim( Dvelop_confirmpanel_deletebutton_Result));
         GxWebStd.gx_hidden_field( context, "vLEAVEREQUEST_Leavetypeid", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0, ".", "")));
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 100, "%", 0, "px", "TableMainTransaction", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto auto auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLefttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;align-items:center;", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "Center", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeename_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Employeename), StringUtil.RTrim( context.localUtil.Format( AV8LeaveRequest.gxTpr_Employeename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeename_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLeaverequest_leavetypeid, dynavLeaverequest_leavetypeid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8LeaveRequest.gxTpr_Leavetypeid), 10, 0)), 1, dynavLeaverequest_leavetypeid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavLeaverequest_leavetypeid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", true, 0, "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDeductfromvacationdaysvariable_Internalname, StringUtil.RTrim( AV20DeductFromVacationDaysVariable), StringUtil.RTrim( context.localUtil.Format( AV20DeductFromVacationDaysVariable, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDeductfromvacationdaysvariable_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDeductfromvacationdaysvariable_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8LeaveRequest.gxTpr_Employeebalance, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_employeebalance_Enabled!=0) ? context.localUtil.Format( AV8LeaveRequest.gxTpr_Employeebalance, "Z9.9") : context.localUtil.Format( AV8LeaveRequest.gxTpr_Employeebalance, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeebalance_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeebalance_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequeststartdate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequeststartdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequeststartdate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestenddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestenddate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestenddate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequestenddate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavLeaverequest_leaverequesthalfday, radavLeaverequest_leaverequesthalfday_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequesthalfday), "", 1, radavLeaverequest_leaverequesthalfday.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radavLeaverequest_leaverequesthalfday_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestduration_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8LeaveRequest.gxTpr_Leaverequestduration, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_leaverequestduration_Enabled!=0) ? context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestduration, "Z9.9") : context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestduration, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestduration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leaverequestduration_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestdescription_Internalname, AV8LeaveRequest.gxTpr_Leaverequestdescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", 0, 1, edtavLeaverequest_leaverequestdescription_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, AV8LeaveRequest.gxTpr_Leaverequestrejectionreason, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, edtavLeaverequest_leaverequestrejectionreason_Visible, edtavLeaverequest_leaverequestrejectionreason_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdatebutton_Internalname, "", "Update", bttBtnupdatebutton_Jsonclick, 5, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUPDATEBUTTON\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancelupdatebutton_Internalname, "", "Cancel", bttBtncancelupdatebutton_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCANCELUPDATEBUTTON\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Details.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnapprovebutton_Internalname, "", "Approve", bttBtnapprovebutton_Jsonclick, 7, "Approve", "", StyleString, ClassString, bttBtnapprovebutton_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e124h1_client"+"'", TempTags, "", 2, "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrejectbutton_Internalname, "", "Reject", bttBtnrejectbutton_Jsonclick, 7, "Reject", "", StyleString, ClassString, bttBtnrejectbutton_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e134h1_client"+"'", TempTags, "", 2, "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "ButtonMaterial RedButton";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndeletebutton_Internalname, "", "Delete", bttBtndeletebutton_Jsonclick, 7, "Delete", "", StyleString, ClassString, bttBtndeletebutton_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e144h1_client"+"'", TempTags, "", 2, "HLP_Details.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRighttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavLeaverequest_leavetypevacationleave, radavLeaverequest_leavetypevacationleave_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leavetypevacationleave), "", radavLeaverequest_leavetypevacationleave.Visible, 1, 0, 0, StyleString, ClassString, "", "", 0, radavLeaverequest_leavetypevacationleave_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "HLP_Details.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8LeaveRequest.gxTpr_Leaverequestid), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8LeaveRequest.gxTpr_Leaverequestid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestid_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leaverequestid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leavetypename_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leavetypename), StringUtil.RTrim( context.localUtil.Format( AV8LeaveRequest.gxTpr_Leavetypename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leavetypename_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leavetypename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Details.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestdate_Internalname, context.localUtil.Format(AV8LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), context.localUtil.Format( AV8LeaveRequest.gxTpr_Leaverequestdate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestdate_Jsonclick, 0, "Attribute", "", "", "", "", edtavLeaverequest_leaverequestdate_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Details.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavLeaverequest_leaverequestdate_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Details.htm");
            context.WriteHtmlTextNl( "</div>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLeaverequest_leaverequeststatus, cmbavLeaverequest_leaverequeststatus_Internalname, StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus), 1, cmbavLeaverequest_leaverequeststatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavLeaverequest_leaverequeststatus.Visible, 1, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "", true, 0, "HLP_Details.htm");
            cmbavLeaverequest_leaverequeststatus.CurrentValue = StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequeststatus);
            AssignProp("", false, cmbavLeaverequest_leaverequeststatus_Internalname, "Values", (string)(cmbavLeaverequest_leaverequeststatus.ToJavascriptSource()), true);
            wb_table1_106_4H2( true) ;
         }
         else
         {
            wb_table1_106_4H2( false) ;
         }
         return  ;
      }

      protected void wb_table1_106_4H2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_111_4H2( true) ;
         }
         else
         {
            wb_table2_111_4H2( false) ;
         }
         return  ;
      }

      protected void wb_table2_111_4H2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_dvelop_confirmpanel_rejectbutton_body_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            ClassString = "ConfirmComment";
            StyleString = "";
            ClassString = "ConfirmComment";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDvelop_confirmpanel_rejectbutton_comment_Internalname, AV18DVelop_ConfirmPanel_RejectButton_Comment, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", 0, 1, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "Reason for rejection", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Details.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            wb_table3_118_4H2( true) ;
         }
         else
         {
            wb_table3_118_4H2( false) ;
         }
         return  ;
      }

      protected void wb_table3_118_4H2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_APPROVEBUTTON.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_approvebutton.Close */
                              E154H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_REJECTBUTTON.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_rejectbutton.Close */
                              E164H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_DELETEBUTTON.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_deletebutton.Close */
                              E174H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E184H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
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
                           else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUEST_LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Leaverequest_leaverequeststartdate.Controlvaluechanged */
                              E224H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUEST_LEAVEREQUESTENDDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Leaverequest_leaverequestenddate.Controlvaluechanged */
                              E234H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUEST_LEAVEREQUESTHALFDAY.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Leaverequest_leaverequesthalfday.Controlvaluechanged */
                              E244H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUEST_LEAVETYPEID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Leaverequest_leavetypeid.Controlvaluechanged */
                              E254H2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E264H2 ();
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
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
         /* Execute user event: Refresh */
         E194H2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E264H2 ();
            WB4H0( ) ;
         }
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
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E184H2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vLEAVEREQUEST"), AV8LeaveRequest);
            ajax_req_read_hidden_sdt(cgiGet( "Leaverequest"), AV8LeaveRequest);
            /* Read saved values. */
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
            Dvelop_confirmpanel_approvebutton_Result = cgiGet( "DVELOP_CONFIRMPANEL_APPROVEBUTTON_Result");
            Dvelop_confirmpanel_rejectbutton_Result = cgiGet( "DVELOP_CONFIRMPANEL_REJECTBUTTON_Result");
            Dvelop_confirmpanel_deletebutton_Result = cgiGet( "DVELOP_CONFIRMPANEL_DELETEBUTTON_Result");
            /* Read variables values. */
            AV8LeaveRequest.gxTpr_Employeename = cgiGet( edtavLeaverequest_employeename_Internalname);
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
            cmbavLeaverequest_leaverequeststatus.CurrentValue = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV8LeaveRequest.gxTpr_Leaverequeststatus = cgiGet( cmbavLeaverequest_leaverequeststatus_Internalname);
            AV18DVelop_ConfirmPanel_RejectButton_Comment = cgiGet( edtavDvelop_confirmpanel_rejectbutton_comment_Internalname);
            AssignAttri("", false, "AV18DVelop_ConfirmPanel_RejectButton_Comment", AV18DVelop_ConfirmPanel_RejectButton_Comment);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E184H2 ();
         if (returnInSub) return;
      }

      protected void E184H2( )
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
                  if (returnInSub) return;
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
         if (returnInSub) return;
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
         AV20DeductFromVacationDaysVariable = AV8LeaveRequest.gxTpr_Leavetypevacationleave;
         AssignAttri("", false, "AV20DeductFromVacationDaysVariable", AV20DeductFromVacationDaysVariable);
      }

      protected void E194H2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E154H2( )
      {
         /* Dvelop_confirmpanel_approvebutton_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_approvebutton_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION APPROVEBUTTON' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
      }

      protected void E164H2( )
      {
         /* Dvelop_confirmpanel_rejectbutton_Close Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Dvelop_confirmpanel_rejectbutton_Result, "Yes") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18DVelop_ConfirmPanel_RejectButton_Comment)) )
         {
            /* Execute user subroutine: 'DO ACTION REJECTBUTTON' */
            S152 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
      }

      protected void E174H2( )
      {
         /* Dvelop_confirmpanel_deletebutton_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_deletebutton_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION DELETEBUTTON' */
            S162 ();
            if (returnInSub) return;
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
         if (returnInSub) return;
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
            AV58GXV16 = 1;
            AV57GXV15 = AV8LeaveRequest.GetMessages();
            while ( AV58GXV16 <= AV57GXV15.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV57GXV15.Item(AV58GXV16));
               GX_msglist.addItem(AV9Message.gxTpr_Description);
               AV58GXV16 = (int)(AV58GXV16+1);
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
         if (returnInSub) return;
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
            AV60GXV18 = 1;
            AV59GXV17 = AV8LeaveRequest.GetMessages();
            while ( AV60GXV18 <= AV59GXV17.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV59GXV17.Item(AV60GXV18));
               GX_msglist.addItem(AV9Message.gxTpr_Description);
               AV60GXV18 = (int)(AV60GXV18+1);
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
            AV62GXV20 = 1;
            AV61GXV19 = AV8LeaveRequest.GetMessages();
            while ( AV62GXV20 <= AV61GXV19.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV61GXV19.Item(AV62GXV20));
               GX_msglist.addItem(AV9Message.gxTpr_Description);
               AV62GXV20 = (int)(AV62GXV20+1);
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
            AV64GXV22 = 1;
            AV63GXV21 = AV8LeaveRequest.GetMessages();
            while ( AV64GXV22 <= AV63GXV21.Count )
            {
               AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV63GXV21.Item(AV64GXV22));
               GX_msglist.addItem(AV9Message.gxTpr_Description);
               AV64GXV22 = (int)(AV64GXV22+1);
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
         AV65GXV23 = 1;
         while ( AV65GXV23 <= AV10Messages.Count )
         {
            AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV10Messages.Item(AV65GXV23));
            GX_msglist.addItem(AV9Message.gxTpr_Description);
            AV65GXV23 = (int)(AV65GXV23+1);
         }
      }

      protected void E224H2( )
      {
         /* Leaverequest_leaverequeststartdate_Controlvaluechanged Routine */
         returnInSub = false;
         if ( DateTimeUtil.ResetTime ( AV8LeaveRequest.gxTpr_Leaverequestenddate ) != DateTimeUtil.ResetTime ( AV8LeaveRequest.gxTpr_Leaverequeststartdate ) )
         {
            AV8LeaveRequest.gxTpr_Leaverequesthalfday = "";
         }
         /* Execute user subroutine: 'LEAVEDURATIONSUB' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
      }

      protected void E234H2( )
      {
         /* Leaverequest_leaverequestenddate_Controlvaluechanged Routine */
         returnInSub = false;
         if ( DateTimeUtil.ResetTime ( AV8LeaveRequest.gxTpr_Leaverequestenddate ) != DateTimeUtil.ResetTime ( AV8LeaveRequest.gxTpr_Leaverequeststartdate ) )
         {
            AV8LeaveRequest.gxTpr_Leaverequesthalfday = "";
         }
         /* Execute user subroutine: 'LEAVEDURATIONSUB' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
      }

      protected void E244H2( )
      {
         /* Leaverequest_leaverequesthalfday_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8LeaveRequest.gxTpr_Leaverequesthalfday)) )
         {
            AV8LeaveRequest.gxTpr_Leaverequestenddate = AV8LeaveRequest.gxTpr_Leaverequeststartdate;
         }
         /* Execute user subroutine: 'LEAVEDURATIONSUB' */
         S192 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8LeaveRequest", AV8LeaveRequest);
      }

      protected void E254H2( )
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
         GXt_decimal4 = 0;
         new getleaverequestdays(context ).execute(  AV8LeaveRequest.gxTpr_Leaverequeststartdate,  AV8LeaveRequest.gxTpr_Leaverequestenddate,  AV8LeaveRequest.gxTpr_Leaverequesthalfday,  AV8LeaveRequest.gxTpr_Employeeid, out  GXt_decimal4) ;
         AV8LeaveRequest.gxTpr_Leaverequestduration = GXt_decimal4;
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

      protected void nextLoad( )
      {
      }

      protected void E264H2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table3_118_4H2( bool wbgen )
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
            wb_table3_118_4H2e( true) ;
         }
         else
         {
            wb_table3_118_4H2e( false) ;
         }
      }

      protected void wb_table2_111_4H2( bool wbgen )
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
            wb_table2_111_4H2e( true) ;
         }
         else
         {
            wb_table2_111_4H2e( false) ;
         }
      }

      protected void wb_table1_106_4H2( bool wbgen )
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
            wb_table1_106_4H2e( true) ;
         }
         else
         {
            wb_table1_106_4H2e( false) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202563011231632", true, true);
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
         context.AddJavascriptSource("details.js", "?202563011231632", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavLeaverequest_leavetypeid.Name = "LEAVEREQUEST_LEAVETYPEID";
         dynavLeaverequest_leavetypeid.WebTags = "";
         dynavLeaverequest_leavetypeid.removeAllItems();
         /* Using cursor H004H4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            dynavLeaverequest_leavetypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H004H4_A124LeaveTypeId[0]), 10, 0)), H004H4_A125LeaveTypeName[0], 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
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

      protected void init_default_properties( )
      {
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
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
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
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Details";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"av":"dynavLeaverequest_leavetypeid"},{"av":"GXV2","fld":"LEAVEREQUEST_LEAVETYPEID","pic":"ZZZZZZZZZ9"},{"av":"radavLeaverequest_leaverequesthalfday"},{"av":"GXV6","fld":"LEAVEREQUEST_LEAVEREQUESTHALFDAY"},{"av":"radavLeaverequest_leavetypevacationleave"},{"av":"GXV10","fld":"LEAVEREQUEST_LEAVETYPEVACATIONLEAVE"},{"av":"AV41CanApprove","fld":"vCANAPPROVE","hsh":true},{"av":"AV19ActionLeaveRole","fld":"vACTIONLEAVEROLE","hsh":true},{"av":"AV36LoggedInEmployeeId","fld":"vLOGGEDINEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV15LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNAPPROVEBUTTON","prop":"Visible"},{"ctrl":"BTNREJECTBUTTON","prop":"Visible"},{"ctrl":"BTNDELETEBUTTON","prop":"Visible"}]}""");
         setEventMetadata("'DOAPPROVEBUTTON'","""{"handler":"E124H1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_APPROVEBUTTON.CLOSE","""{"handler":"E154H2","iparms":[{"av":"Dvelop_confirmpanel_approvebutton_Result","ctrl":"DVELOP_CONFIRMPANEL_APPROVEBUTTON","prop":"Result"},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_APPROVEBUTTON.CLOSE",""","oparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("'DOREJECTBUTTON'","""{"handler":"E134H1","iparms":[]""");
         setEventMetadata("'DOREJECTBUTTON'",""","oparms":[{"av":"AV18DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_REJECTBUTTON.CLOSE","""{"handler":"E164H2","iparms":[{"av":"Dvelop_confirmpanel_rejectbutton_Result","ctrl":"DVELOP_CONFIRMPANEL_REJECTBUTTON","prop":"Result"},{"av":"AV18DVelop_ConfirmPanel_RejectButton_Comment","fld":"vDVELOP_CONFIRMPANEL_REJECTBUTTON_COMMENT"},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_REJECTBUTTON.CLOSE",""","oparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("'DODELETEBUTTON'","""{"handler":"E144H1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETEBUTTON.CLOSE","""{"handler":"E174H2","iparms":[{"av":"Dvelop_confirmpanel_deletebutton_Result","ctrl":"DVELOP_CONFIRMPANEL_DELETEBUTTON","prop":"Result"},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETEBUTTON.CLOSE",""","oparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("'DOUPDATEBUTTON'","""{"handler":"E204H2","iparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"av":"AV15LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOUPDATEBUTTON'",""","oparms":[{"av":"divTableeditaction_Visible","ctrl":"TABLEEDITACTION","prop":"Visible"},{"av":"divTableupdateaction_Visible","ctrl":"TABLEUPDATEACTION","prop":"Visible"},{"av":"divTableapproveaction_Visible","ctrl":"TABLEAPPROVEACTION","prop":"Visible"},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"ctrl":"LEAVEREQUEST_EMPLOYEENAME","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVETYPEID","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTSTARTDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTENDDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTHALFDAY","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTDESCRIPTION","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON","prop":"Enabled"}]}""");
         setEventMetadata("'DOCANCELUPDATEBUTTON'","""{"handler":"E214H2","iparms":[{"av":"AV15LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOCANCELUPDATEBUTTON'",""","oparms":[{"av":"divTableapproveaction_Visible","ctrl":"TABLEAPPROVEACTION","prop":"Visible"},{"av":"divTableeditaction_Visible","ctrl":"TABLEEDITACTION","prop":"Visible"},{"av":"divTableupdateaction_Visible","ctrl":"TABLEUPDATEACTION","prop":"Visible"},{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"},{"ctrl":"LEAVEREQUEST_EMPLOYEENAME","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVETYPEID","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTSTARTDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTENDDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTHALFDAY","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTDESCRIPTION","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON","prop":"Enabled"}]}""");
         setEventMetadata("'DOEDITBUTTON'","""{"handler":"E114H1","iparms":[]""");
         setEventMetadata("'DOEDITBUTTON'",""","oparms":[{"av":"divTableupdateaction_Visible","ctrl":"TABLEUPDATEACTION","prop":"Visible"},{"av":"divTableapproveaction_Visible","ctrl":"TABLEAPPROVEACTION","prop":"Visible"},{"av":"divTableeditaction_Visible","ctrl":"TABLEEDITACTION","prop":"Visible"},{"ctrl":"LEAVEREQUEST_LEAVETYPEID","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTSTARTDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTENDDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTHALFDAY","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTDESCRIPTION","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON","prop":"Enabled"}]}""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED","""{"handler":"E224H2","iparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTENDDATE.CONTROLVALUECHANGED","""{"handler":"E234H2","iparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTENDDATE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTHALFDAY.CONTROLVALUECHANGED","""{"handler":"E244H2","iparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTHALFDAY.CONTROLVALUECHANGED",""","oparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("LEAVEREQUEST_LEAVETYPEID.CONTROLVALUECHANGED","""{"handler":"E254H2","iparms":[{"av":"AV8LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("LEAVEREQUEST_LEAVETYPEID.CONTROLVALUECHANGED",""","oparms":[{"av":"AV20DeductFromVacationDaysVariable","fld":"vDEDUCTFROMVACATIONDAYSVARIABLE"}]}""");
         setEventMetadata("VALIDV_GXV14","""{"handler":"Validv_Gxv14","iparms":[]}""");
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
         Dvelop_confirmpanel_approvebutton_Result = "";
         Dvelop_confirmpanel_rejectbutton_Result = "";
         Dvelop_confirmpanel_deletebutton_Result = "";
         AV8LeaveRequest = new SdtLeaveRequest(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gx_date = DateTime.MinValue;
         GXKey = "";
         Dvelop_confirmpanel_rejectbutton_Bodycontentinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
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
         AV18DVelop_ConfirmPanel_RejectButton_Comment = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H004H2_A124LeaveTypeId = new long[1] ;
         H004H2_A125LeaveTypeName = new string[] {""} ;
         H004H3_A124LeaveTypeId = new long[1] ;
         H004H3_A125LeaveTypeName = new string[] {""} ;
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         ucDvelop_confirmpanel_rejectbutton = new GXUserControl();
         AV57GXV15 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV16Employee = new SdtEmployee(context);
         AV17LeaveType = new SdtLeaveType(context);
         AV59GXV17 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_char3 = "";
         GXt_char2 = "";
         AV61GXV19 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV63GXV21 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         sStyleString = "";
         ucDvelop_confirmpanel_deletebutton = new GXUserControl();
         ucDvelop_confirmpanel_approvebutton = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H004H4_A124LeaveTypeId = new long[1] ;
         H004H4_A125LeaveTypeName = new string[] {""} ;
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
               H004H4_A124LeaveTypeId, H004H4_A125LeaveTypeName
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

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
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
      private int edtavLeaverequest_leaverequestid_Visible ;
      private int edtavLeaverequest_leavetypename_Visible ;
      private int edtavLeaverequest_leaverequestdate_Visible ;
      private int gxdynajaxindex ;
      private int AV58GXV16 ;
      private int AV60GXV18 ;
      private int AV62GXV20 ;
      private int AV64GXV22 ;
      private int AV65GXV23 ;
      private int idxLst ;
      private long AV15LeaveRequestId ;
      private long wcpOAV15LeaveRequestId ;
      private long AV36LoggedInEmployeeId ;
      private long GXt_int1 ;
      private decimal GXt_decimal4 ;
      private string AV11TrnMode ;
      private string wcpOAV11TrnMode ;
      private string Dvelop_confirmpanel_approvebutton_Result ;
      private string Dvelop_confirmpanel_rejectbutton_Result ;
      private string Dvelop_confirmpanel_deletebutton_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divLefttable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTableeditaction_Internalname ;
      private string lblBtneditbutton_Internalname ;
      private string lblBtneditbutton_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
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
      private string divHtml_bottomauxiliarcontrols_Internalname ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string Dvelop_confirmpanel_rejectbutton_Internalname ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sStyleString ;
      private string tblTabledvelop_confirmpanel_deletebutton_Internalname ;
      private string Dvelop_confirmpanel_deletebutton_Internalname ;
      private string tblTabledvelop_confirmpanel_rejectbutton_Internalname ;
      private string tblTabledvelop_confirmpanel_approvebutton_Internalname ;
      private string Dvelop_confirmpanel_approvebutton_Internalname ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV41CanApprove ;
      private bool AV19ActionLeaveRole ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV37IsEditable ;
      private bool AV12LoadSuccess ;
      private string AV18DVelop_ConfirmPanel_RejectButton_Comment ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
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
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV57GXV15 ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private SdtEmployee AV16Employee ;
      private SdtLeaveType AV17LeaveType ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV59GXV17 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV61GXV19 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV63GXV21 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H004H4_A124LeaveTypeId ;
      private string[] H004H4_A125LeaveTypeName ;
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
        };
        def= new CursorDef[] {
            new CursorDef("H004H2", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H004H3", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H3,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H004H4", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004H4,0, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
     }
  }

}

}
