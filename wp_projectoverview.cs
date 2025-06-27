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
   public class wp_projectoverview : GXDataArea
   {
      public wp_projectoverview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_projectoverview( IGxContext context )
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
         chkavShowleavetotal = new GXCheckbox();
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
            return "wp_projectoverview_Execute" ;
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
         PA5A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5A2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_PivotTableRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_projectoverview.aspx") +"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_OPENPROJECTDETAILS", AV35IsAuthorized_OpenProjectDetails);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_OPENPROJECTDETAILS", GetSecureSignedToken( "", AV35IsAuthorized_OpenProjectDetails, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSEREMPLOYEEIDCOLLECTION", AV32UserEmployeeIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSEREMPLOYEEIDCOLLECTION", AV32UserEmployeeIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSEREMPLOYEEIDCOLLECTION", GetSecureSignedToken( "", AV32UserEmployeeIdCollection, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSERPROJECTIDCOLLECTION", AV33UserProjectIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSERPROJECTIDCOLLECTION", AV33UserProjectIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERPROJECTIDCOLLECTION", GetSecureSignedToken( "", AV33UserProjectIdCollection, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID_DATA", AV14ProjectId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID_DATA", AV14ProjectId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYLOCATIONID_DATA", AV17CompanyLocationId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYLOCATIONID_DATA", AV17CompanyLocationId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID_DATA", AV18EmployeeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID_DATA", AV18EmployeeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION", AV22SDT_EmployeeProjectMatrixCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION", AV22SDT_EmployeeProjectMatrixCollection);
         }
         GxWebStd.gx_hidden_field( context, "vDATERANGE", context.localUtil.DToC( AV10DateRange, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATERANGE_TO", context.localUtil.DToC( AV20DateRange_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDATERANGE_RANGEPICKEROPTIONS", AV21DateRange_RangePickerOptions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDATERANGE_RANGEPICKEROPTIONS", AV21DateRange_RangePickerOptions);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_OPENPROJECTDETAILS", AV35IsAuthorized_OpenProjectDetails);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_OPENPROJECTDETAILS", GetSecureSignedToken( "", AV35IsAuthorized_OpenProjectDetails, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTPROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36CurrentProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCURRENTEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37CurrentEmployeeId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID", AV11ProjectId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID", AV11ProjectId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID", AV13EmployeeId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID", AV13EmployeeId);
         }
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSEREMPLOYEEIDCOLLECTION", AV32UserEmployeeIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSEREMPLOYEEIDCOLLECTION", AV32UserEmployeeIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSEREMPLOYEEIDCOLLECTION", GetSecureSignedToken( "", AV32UserEmployeeIdCollection, context));
         GxWebStd.gx_hidden_field( context, "COMPANYLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A157CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSERPROJECTIDCOLLECTION", AV33UserProjectIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSERPROJECTIDCOLLECTION", AV33UserProjectIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERPROJECTIDCOLLECTION", GetSecureSignedToken( "", AV33UserProjectIdCollection, context));
         GxWebStd.gx_hidden_field( context, "PROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEENAME", StringUtil.RTrim( A148EmployeeName));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTOSHOWEMPLOYEEIDCOLLECTION", AV26ToShowEmployeeIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTOSHOWEMPLOYEEIDCOLLECTION", AV26ToShowEmployeeIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "PROJECTNAME", StringUtil.RTrim( A103ProjectName));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTOSHOWPROJECTIDCOLLECTION", AV27ToShowProjectIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTOSHOWPROJECTIDCOLLECTION", AV27ToShowProjectIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Cls", StringUtil.RTrim( Combo_projectid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_set", StringUtil.RTrim( Combo_projectid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Allowmultipleselection", StringUtil.BoolToStr( Combo_projectid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_projectid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Emptyitem", StringUtil.BoolToStr( Combo_projectid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Multiplevaluestype", StringUtil.RTrim( Combo_projectid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Cls", StringUtil.RTrim( Combo_companylocationid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_set", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Enabled", StringUtil.BoolToStr( Combo_companylocationid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Allowmultipleselection", StringUtil.BoolToStr( Combo_companylocationid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_companylocationid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Emptyitem", StringUtil.BoolToStr( Combo_companylocationid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Multiplevaluestype", StringUtil.RTrim( Combo_companylocationid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Cls", StringUtil.RTrim( Combo_employeeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_set", StringUtil.RTrim( Combo_employeeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Allowmultipleselection", StringUtil.BoolToStr( Combo_employeeid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Includeonlyselectedoption", StringUtil.BoolToStr( Combo_employeeid_Includeonlyselectedoption));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Emptyitem", StringUtil.BoolToStr( Combo_employeeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Multiplevaluestype", StringUtil.RTrim( Combo_employeeid_Multiplevaluestype));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Showleavetotal", StringUtil.BoolToStr( Usercontrol1_Showleavetotal));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Formattedoveralltotalhours", StringUtil.RTrim( Usercontrol1_Formattedoveralltotalhours));
         GxWebStd.gx_hidden_field( context, "OPENPROJECTDETAILS_MODAL_Width", StringUtil.RTrim( Openprojectdetails_modal_Width));
         GxWebStd.gx_hidden_field( context, "OPENPROJECTDETAILS_MODAL_Title", StringUtil.RTrim( Openprojectdetails_modal_Title));
         GxWebStd.gx_hidden_field( context, "OPENPROJECTDETAILS_MODAL_Confirmtype", StringUtil.RTrim( Openprojectdetails_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "OPENPROJECTDETAILS_MODAL_Bodytype", StringUtil.RTrim( Openprojectdetails_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "OPENEMPLOYEEDETAILS_MODAL_Width", StringUtil.RTrim( Openemployeedetails_modal_Width));
         GxWebStd.gx_hidden_field( context, "OPENEMPLOYEEDETAILS_MODAL_Title", StringUtil.RTrim( Openemployeedetails_modal_Title));
         GxWebStd.gx_hidden_field( context, "OPENEMPLOYEEDETAILS_MODAL_Confirmtype", StringUtil.RTrim( Openemployeedetails_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "OPENEMPLOYEEDETAILS_MODAL_Bodytype", StringUtil.RTrim( Openemployeedetails_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Currentemployeeid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Usercontrol1_Currentemployeeid), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Currentprojectid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Usercontrol1_Currentprojectid), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_get", StringUtil.RTrim( Combo_employeeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYLOCATIONID_Selectedvalue_get", StringUtil.RTrim( Combo_companylocationid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_get", StringUtil.RTrim( Combo_projectid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Currentprojectid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Usercontrol1_Currentprojectid), 9, 0, ".", "")));
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
            WE5A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5A2( ) ;
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
         return formatLink("wp_projectoverview.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_ProjectOverview" ;
      }

      public override string GetPgmdesc( )
      {
         return "Project Overview" ;
      }

      protected void WB5A0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:row-reverse;justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportexcel_Internalname, "", "Export", bttBtnexportexcel_Jsonclick, 5, "Export", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ProjectOverview.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingLeft10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOverviewtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "CellMarginLeftRight3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDaterange_rangetext_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDaterange_rangetext_Internalname, "Date Range", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDaterange_rangetext_Internalname, AV19DateRange_RangeText, StringUtil.RTrim( context.localUtil.Format( AV19DateRange_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDaterange_rangetext_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavDaterange_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ProjectOverview.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedprojectid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_projectid_Internalname, "Project", "", "", lblTextblockcombo_projectid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProjectOverview.htm");
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
            ucCombo_projectid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
            ucCombo_projectid.SetProperty("DropDownOptionsData", AV14ProjectId_Data);
            ucCombo_projectid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_projectid_Internalname, "COMBO_PROJECTIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcompanylocationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_companylocationid_Internalname, "Location", "", "", lblTextblockcombo_companylocationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProjectOverview.htm");
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
            ucCombo_companylocationid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
            ucCombo_companylocationid.SetProperty("DropDownOptionsData", AV17CompanyLocationId_Data);
            ucCombo_companylocationid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_companylocationid_Internalname, "COMBO_COMPANYLOCATIONIDContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DscTop ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedemployeeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_employeeid_Internalname, "Employee", "", "", lblTextblockcombo_employeeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProjectOverview.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_employeeid.SetProperty("Caption", Combo_employeeid_Caption);
            ucCombo_employeeid.SetProperty("Cls", Combo_employeeid_Cls);
            ucCombo_employeeid.SetProperty("AllowMultipleSelection", Combo_employeeid_Allowmultipleselection);
            ucCombo_employeeid.SetProperty("IncludeOnlySelectedOption", Combo_employeeid_Includeonlyselectedoption);
            ucCombo_employeeid.SetProperty("EmptyItem", Combo_employeeid_Emptyitem);
            ucCombo_employeeid.SetProperty("MultipleValuesType", Combo_employeeid_Multiplevaluestype);
            ucCombo_employeeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
            ucCombo_employeeid.SetProperty("DropDownOptionsData", AV18EmployeeId_Data);
            ucCombo_employeeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_employeeid_Internalname, "COMBO_EMPLOYEEIDContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:row-reverse;justify-content:center;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableshowleavetotal_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockshowleavetotal_Internalname, "Show Leave Total", "", "", lblTextblockshowleavetotal_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ProjectOverview.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavShowleavetotal_Internalname, "Show Leave Total", "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavShowleavetotal_Internalname, StringUtil.BoolToStr( AV9ShowLeaveTotal), "", "Show Leave Total", 1, chkavShowleavetotal.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(60, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,60);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUsercontrol1.SetProperty("SDT_EmployeeProjectMatrixCollection", AV22SDT_EmployeeProjectMatrixCollection);
            ucUsercontrol1.Render(context, "uc_pivottable", Usercontrol1_Internalname, "USERCONTROL1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, divUnnamedtable4_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnopenprojectdetails_Internalname, "", "OpenProjectDetails", bttBtnopenprojectdetails_Jsonclick, 5, "OpenProjectDetails", "", StyleString, ClassString, bttBtnopenprojectdetails_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOOPENPROJECTDETAILS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ProjectOverview.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnopenemployeedetails_Internalname, "", "OpenEmployeeDetails", bttBtnopenemployeedetails_Jsonclick, 7, "OpenEmployeeDetails", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e115a1_client"+"'", TempTags, "", 2, "HLP_WP_ProjectOverview.htm");
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
            ucDaterange_rangepicker.SetProperty("Start Date", AV10DateRange);
            ucDaterange_rangepicker.SetProperty("End Date", AV20DateRange_To);
            ucDaterange_rangepicker.SetProperty("PickerOptions", AV21DateRange_RangePickerOptions);
            ucDaterange_rangepicker.Render(context, "wwp.daterangepicker", Daterange_rangepicker_Internalname, "DATERANGE_RANGEPICKERContainer");
            wb_table1_80_5A2( true) ;
         }
         else
         {
            wb_table1_80_5A2( false) ;
         }
         return  ;
      }

      protected void wb_table1_80_5A2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_85_5A2( true) ;
         }
         else
         {
            wb_table2_85_5A2( false) ;
         }
         return  ;
      }

      protected void wb_table2_85_5A2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0091"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0091"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0091"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
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
         wbLoad = true;
      }

      protected void START5A2( )
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
         Form.Meta.addItem("description", "Project Overview", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5A0( ) ;
      }

      protected void WS5A2( )
      {
         START5A2( ) ;
         EVT5A2( ) ;
      }

      protected void EVT5A2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_PROJECTID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_projectid.Onoptionclicked */
                              E125A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_companylocationid.Onoptionclicked */
                              E135A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_EMPLOYEEID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Combo_employeeid.Onoptionclicked */
                              E145A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "USERCONTROL1.PROJECTCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Usercontrol1.Projectclicked */
                              E155A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DATERANGE_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Daterange_rangepicker.Daterangechanged */
                              E165A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "OPENPROJECTDETAILS_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Openprojectdetails_modal.Close */
                              E175A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "OPENEMPLOYEEDETAILS_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Openemployeedetails_modal.Close */
                              E185A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E195A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E205A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOOPENPROJECTDETAILS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoOpenProjectDetails' */
                              E215A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTEXCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportExcel' */
                              E225A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSHOWLEAVETOTAL.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E235A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E245A2 ();
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 91 )
                        {
                           OldWwpaux_wc = cgiGet( "W0091");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0091", "", sEvt);
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

      protected void WE5A2( )
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

      protected void PA5A2( )
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
         AV9ShowLeaveTotal = StringUtil.StrToBool( StringUtil.BoolToStr( AV9ShowLeaveTotal));
         AssignAttri("", false, "AV9ShowLeaveTotal", AV9ShowLeaveTotal);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void RF5A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E205A2 ();
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
            /* Execute user event: Load */
            E245A2 ();
            WB5A0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5A2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_OPENPROJECTDETAILS", AV35IsAuthorized_OpenProjectDetails);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_OPENPROJECTDETAILS", GetSecureSignedToken( "", AV35IsAuthorized_OpenProjectDetails, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSEREMPLOYEEIDCOLLECTION", AV32UserEmployeeIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSEREMPLOYEEIDCOLLECTION", AV32UserEmployeeIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSEREMPLOYEEIDCOLLECTION", GetSecureSignedToken( "", AV32UserEmployeeIdCollection, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSERPROJECTIDCOLLECTION", AV33UserProjectIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSERPROJECTIDCOLLECTION", AV33UserProjectIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERPROJECTIDCOLLECTION", GetSecureSignedToken( "", AV33UserProjectIdCollection, context));
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E195A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vPROJECTID_DATA"), AV14ProjectId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vCOMPANYLOCATIONID_DATA"), AV17CompanyLocationId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEEID_DATA"), AV18EmployeeId_Data);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"), AV22SDT_EmployeeProjectMatrixCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vDATERANGE_RANGEPICKEROPTIONS"), AV21DateRange_RangePickerOptions);
            ajax_req_read_hidden_sdt(cgiGet( "vPROJECTID"), AV11ProjectId);
            /* Read saved values. */
            AV10DateRange = context.localUtil.CToD( cgiGet( "vDATERANGE"), 0);
            AV20DateRange_To = context.localUtil.CToD( cgiGet( "vDATERANGE_TO"), 0);
            AV37CurrentEmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCURRENTEMPLOYEEID"), ".", ","), 18, MidpointRounding.ToEven));
            AV36CurrentProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCURRENTPROJECTID"), ".", ","), 18, MidpointRounding.ToEven));
            Combo_projectid_Cls = cgiGet( "COMBO_PROJECTID_Cls");
            Combo_projectid_Selectedvalue_set = cgiGet( "COMBO_PROJECTID_Selectedvalue_set");
            Combo_projectid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Allowmultipleselection"));
            Combo_projectid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Includeonlyselectedoption"));
            Combo_projectid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Emptyitem"));
            Combo_projectid_Multiplevaluestype = cgiGet( "COMBO_PROJECTID_Multiplevaluestype");
            Combo_companylocationid_Cls = cgiGet( "COMBO_COMPANYLOCATIONID_Cls");
            Combo_companylocationid_Selectedvalue_set = cgiGet( "COMBO_COMPANYLOCATIONID_Selectedvalue_set");
            Combo_companylocationid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Enabled"));
            Combo_companylocationid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Allowmultipleselection"));
            Combo_companylocationid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Includeonlyselectedoption"));
            Combo_companylocationid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYLOCATIONID_Emptyitem"));
            Combo_companylocationid_Multiplevaluestype = cgiGet( "COMBO_COMPANYLOCATIONID_Multiplevaluestype");
            Combo_employeeid_Cls = cgiGet( "COMBO_EMPLOYEEID_Cls");
            Combo_employeeid_Selectedvalue_set = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_set");
            Combo_employeeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Allowmultipleselection"));
            Combo_employeeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Includeonlyselectedoption"));
            Combo_employeeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Emptyitem"));
            Combo_employeeid_Multiplevaluestype = cgiGet( "COMBO_EMPLOYEEID_Multiplevaluestype");
            Usercontrol1_Showleavetotal = StringUtil.StrToBool( cgiGet( "USERCONTROL1_Showleavetotal"));
            Usercontrol1_Formattedoveralltotalhours = cgiGet( "USERCONTROL1_Formattedoveralltotalhours");
            Openprojectdetails_modal_Width = cgiGet( "OPENPROJECTDETAILS_MODAL_Width");
            Openprojectdetails_modal_Title = cgiGet( "OPENPROJECTDETAILS_MODAL_Title");
            Openprojectdetails_modal_Confirmtype = cgiGet( "OPENPROJECTDETAILS_MODAL_Confirmtype");
            Openprojectdetails_modal_Bodytype = cgiGet( "OPENPROJECTDETAILS_MODAL_Bodytype");
            Openemployeedetails_modal_Width = cgiGet( "OPENEMPLOYEEDETAILS_MODAL_Width");
            Openemployeedetails_modal_Title = cgiGet( "OPENEMPLOYEEDETAILS_MODAL_Title");
            Openemployeedetails_modal_Confirmtype = cgiGet( "OPENEMPLOYEEDETAILS_MODAL_Confirmtype");
            Openemployeedetails_modal_Bodytype = cgiGet( "OPENEMPLOYEEDETAILS_MODAL_Bodytype");
            Combo_employeeid_Selectedvalue_get = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_get");
            Combo_companylocationid_Selectedvalue_get = cgiGet( "COMBO_COMPANYLOCATIONID_Selectedvalue_get");
            Combo_projectid_Selectedvalue_get = cgiGet( "COMBO_PROJECTID_Selectedvalue_get");
            Usercontrol1_Currentprojectid = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USERCONTROL1_Currentprojectid"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV19DateRange_RangeText = cgiGet( edtavDaterange_rangetext_Internalname);
            AssignAttri("", false, "AV19DateRange_RangeText", AV19DateRange_RangeText);
            AV9ShowLeaveTotal = StringUtil.StrToBool( cgiGet( chkavShowleavetotal_Internalname));
            AssignAttri("", false, "AV9ShowLeaveTotal", AV9ShowLeaveTotal);
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
         E195A2 ();
         if (returnInSub) return;
      }

      protected void E195A2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10DateRange = context.localUtil.YMDToD( DateTimeUtil.Year( Gx_date), DateTimeUtil.Month( Gx_date), 1);
         AssignAttri("", false, "AV10DateRange", context.localUtil.Format(AV10DateRange, "99/99/99"));
         AV20DateRange_To = DateTimeUtil.DateEndOfMonth( Gx_date);
         AssignAttri("", false, "AV20DateRange_To", context.localUtil.Format(AV20DateRange_To, "99/99/99"));
         GXt_boolean1 = AV28IsProjectManager;
         new userhasrole(context ).execute(  "Project Manager", out  GXt_boolean1) ;
         AV28IsProjectManager = GXt_boolean1;
         GXt_boolean1 = AV31IsManager;
         new userhasrole(context ).execute(  "Manager", out  GXt_boolean1) ;
         AV31IsManager = GXt_boolean1;
         GXt_boolean1 = AV38IsEmployee;
         new userhasrole(context ).execute(  "Employee", out  GXt_boolean1) ;
         AV38IsEmployee = GXt_boolean1;
         GXt_int2 = AV39LoggedInEmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int2) ;
         AV39LoggedInEmployeeId = GXt_int2;
         AssignAttri("", false, "AV39LoggedInEmployeeId", StringUtil.LTrimStr( (decimal)(AV39LoggedInEmployeeId), 10, 0));
         if ( AV38IsEmployee )
         {
            /* Using cursor H005A2 */
            pr_default.execute(0, new Object[] {AV39LoggedInEmployeeId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A100CompanyId = H005A2_A100CompanyId[0];
               A106EmployeeId = H005A2_A106EmployeeId[0];
               A157CompanyLocationId = H005A2_A157CompanyLocationId[0];
               A157CompanyLocationId = H005A2_A157CompanyLocationId[0];
               AV32UserEmployeeIdCollection.Add(AV39LoggedInEmployeeId, 0);
               AV12CompanyLocationId.Add(A157CompanyLocationId, 0);
               Combo_companylocationid_Enabled = false;
               ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_companylocationid_Enabled));
               AV13EmployeeId.Add(AV39LoggedInEmployeeId, 0);
               /* Using cursor H005A3 */
               pr_default.execute(1, new Object[] {A106EmployeeId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A102ProjectId = H005A3_A102ProjectId[0];
                  AV33UserProjectIdCollection.Add(A102ProjectId, 0);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
         if ( AV31IsManager )
         {
            AV44Udparg1 = new getloggedinusercompanyid(context).executeUdp( );
            /* Using cursor H005A4 */
            pr_default.execute(2, new Object[] {AV44Udparg1});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A100CompanyId = H005A4_A100CompanyId[0];
               A106EmployeeId = H005A4_A106EmployeeId[0];
               AV32UserEmployeeIdCollection.Add(A106EmployeeId, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         if ( AV28IsProjectManager )
         {
            /* Using cursor H005A5 */
            pr_default.execute(3, new Object[] {AV39LoggedInEmployeeId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A162ProjectManagerId = H005A5_A162ProjectManagerId[0];
               n162ProjectManagerId = H005A5_n162ProjectManagerId[0];
               A102ProjectId = H005A5_A102ProjectId[0];
               AV33UserProjectIdCollection.Add(A102ProjectId, 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            GXt_objcol_int3 = AV32UserEmployeeIdCollection;
            new getemployeeidsbyproject(context ).execute(  AV33UserProjectIdCollection, out  GXt_objcol_int3) ;
            AV32UserEmployeeIdCollection = GXt_objcol_int3;
         }
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4;
         this.executeUsercontrolMethod("", false, "DATERANGE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDaterange_rangetext_Internalname});
         GXt_SdtWWPDateRangePickerOptions5 = AV21DateRange_RangePickerOptions;
         new GeneXus.Programs.wwpbaseobjects.wwp_rangepicker_getoptionsreports(context ).execute( out  GXt_SdtWWPDateRangePickerOptions5) ;
         AV21DateRange_RangePickerOptions = GXt_SdtWWPDateRangePickerOptions5;
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOCOMPANYLOCATIONID' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S152 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "USERCONTROL1Container", "Refresh", "", new Object[] {});
      }

      protected void E205A2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E215A2( )
      {
         /* 'DoOpenProjectDetails' Routine */
         returnInSub = false;
         if ( AV35IsAuthorized_OpenProjectDetails )
         {
            this.executeUsercontrolMethod("", false, "OPENPROJECTDETAILS_MODALContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
      }

      protected void E175A2( )
      {
         /* Openprojectdetails_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E185A2( )
      {
         /* Openemployeedetails_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E225A2( )
      {
         /* 'DoExportExcel' Routine */
         returnInSub = false;
         new prc_exportprojectoverview(context ).execute(  AV10DateRange,  AV20DateRange_To,  AV13EmployeeId,  AV11ProjectId,  AV12CompanyLocationId,  AV9ShowLeaveTotal,  AV22SDT_EmployeeProjectMatrixCollection, out  AV23Filename, out  AV24ErrorMessage) ;
         if ( StringUtil.StrCmp(AV23Filename, "") != 0 )
         {
            CallWebObject(formatLink(AV23Filename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV24ErrorMessage);
         }
      }

      protected void E145A2( )
      {
         /* Combo_employeeid_Onoptionclicked Routine */
         returnInSub = false;
         AV13EmployeeId.FromJSonString(Combo_employeeid_Selectedvalue_get, null);
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13EmployeeId", AV13EmployeeId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_EmployeeProjectMatrixCollection", AV22SDT_EmployeeProjectMatrixCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ToShowEmployeeIdCollection", AV26ToShowEmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ToShowProjectIdCollection", AV27ToShowProjectIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18EmployeeId_Data", AV18EmployeeId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14ProjectId_Data", AV14ProjectId_Data);
      }

      protected void E135A2( )
      {
         /* Combo_companylocationid_Onoptionclicked Routine */
         returnInSub = false;
         AV12CompanyLocationId.FromJSonString(Combo_companylocationid_Selectedvalue_get, null);
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CompanyLocationId", AV12CompanyLocationId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_EmployeeProjectMatrixCollection", AV22SDT_EmployeeProjectMatrixCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ToShowEmployeeIdCollection", AV26ToShowEmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ToShowProjectIdCollection", AV27ToShowProjectIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18EmployeeId_Data", AV18EmployeeId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14ProjectId_Data", AV14ProjectId_Data);
      }

      protected void E125A2( )
      {
         /* Combo_projectid_Onoptionclicked Routine */
         returnInSub = false;
         AV11ProjectId.FromJSonString(Combo_projectid_Selectedvalue_get, null);
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11ProjectId", AV11ProjectId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_EmployeeProjectMatrixCollection", AV22SDT_EmployeeProjectMatrixCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ToShowEmployeeIdCollection", AV26ToShowEmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ToShowProjectIdCollection", AV27ToShowProjectIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18EmployeeId_Data", AV18EmployeeId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14ProjectId_Data", AV14ProjectId_Data);
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV35IsAuthorized_OpenProjectDetails;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "<Check_Is_Authenticated>", out  GXt_boolean1) ;
         AV35IsAuthorized_OpenProjectDetails = GXt_boolean1;
         AssignAttri("", false, "AV35IsAuthorized_OpenProjectDetails", AV35IsAuthorized_OpenProjectDetails);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_OPENPROJECTDETAILS", GetSecureSignedToken( "", AV35IsAuthorized_OpenProjectDetails, context));
         if ( ! ( AV35IsAuthorized_OpenProjectDetails ) )
         {
            bttBtnopenprojectdetails_Visible = 0;
            AssignProp("", false, bttBtnopenprojectdetails_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnopenprojectdetails_Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divUnnamedtable4_Visible = (((1==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable4_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable4_Visible), 5, 0), true);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOEMPLOYEEID' Routine */
         returnInSub = false;
         AV18EmployeeId_Data.Clear();
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV26ToShowEmployeeIdCollection ,
                                              AV26ToShowEmployeeIdCollection.Count } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT
                                              }
         });
         /* Using cursor H005A6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A106EmployeeId = H005A6_A106EmployeeId[0];
            A148EmployeeName = H005A6_A148EmployeeName[0];
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A106EmployeeId), 10, 0));
            AV16Combo_DataItem.gxTpr_Title = A148EmployeeName;
            AV18EmployeeId_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         Combo_employeeid_Selectedvalue_set = AV13EmployeeId.ToJSonString(false);
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCOMPANYLOCATIONID' Routine */
         returnInSub = false;
         /* Using cursor H005A7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A157CompanyLocationId = H005A7_A157CompanyLocationId[0];
            A158CompanyLocationName = H005A7_A158CompanyLocationName[0];
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0));
            AV16Combo_DataItem.gxTpr_Title = A158CompanyLocationName;
            AV17CompanyLocationId_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         Combo_companylocationid_Selectedvalue_set = AV12CompanyLocationId.ToJSonString(false);
         ucCombo_companylocationid.SendProperty(context, "", false, Combo_companylocationid_Internalname, "SelectedValue_set", Combo_companylocationid_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROJECTID' Routine */
         returnInSub = false;
         AV14ProjectId_Data.Clear();
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV27ToShowProjectIdCollection } ,
                                              new int[]{
                                              TypeConstants.LONG
                                              }
         });
         /* Using cursor H005A8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A102ProjectId = H005A8_A102ProjectId[0];
            A103ProjectName = H005A8_A103ProjectName[0];
            AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV16Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A102ProjectId), 10, 0));
            AV16Combo_DataItem.gxTpr_Title = A103ProjectName;
            AV14ProjectId_Data.Add(AV16Combo_DataItem, 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         Combo_projectid_Selectedvalue_set = AV11ProjectId.ToJSonString(false);
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedValue_set", Combo_projectid_Selectedvalue_set);
      }

      protected void E165A2( )
      {
         /* Daterange_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_EmployeeProjectMatrixCollection", AV22SDT_EmployeeProjectMatrixCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ToShowEmployeeIdCollection", AV26ToShowEmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ToShowProjectIdCollection", AV27ToShowProjectIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18EmployeeId_Data", AV18EmployeeId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14ProjectId_Data", AV14ProjectId_Data);
      }

      protected void E235A2( )
      {
         /* Showleavetotal_Controlvaluechanged Routine */
         returnInSub = false;
         Usercontrol1_Showleavetotal = AV9ShowLeaveTotal;
         ucUsercontrol1.SendProperty(context, "", false, Usercontrol1_Internalname, "ShowLeaveTotal", StringUtil.BoolToStr( Usercontrol1_Showleavetotal));
         /* Execute user subroutine: 'GETDATA' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22SDT_EmployeeProjectMatrixCollection", AV22SDT_EmployeeProjectMatrixCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ToShowEmployeeIdCollection", AV26ToShowEmployeeIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ToShowProjectIdCollection", AV27ToShowProjectIdCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18EmployeeId_Data", AV18EmployeeId_Data);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14ProjectId_Data", AV14ProjectId_Data);
      }

      protected void E155A2( )
      {
         /* Usercontrol1_Projectclicked Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S172 ();
         if (returnInSub) return;
         AV36CurrentProjectId = Usercontrol1_Currentprojectid;
         AssignAttri("", false, "AV36CurrentProjectId", StringUtil.LTrimStr( (decimal)(AV36CurrentProjectId), 10, 0));
         this.executeUsercontrolMethod("", false, "OPENPROJECTDETAILS_MODALContainer", "Confirm", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'GETDATA' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETEMPLOYEESTOSHOW' */
         S182 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETPROJECTSTOSHOW' */
         S192 ();
         if (returnInSub) return;
         GXt_objcol_SdtSDT_EmployeeProjectMatrix6 = AV22SDT_EmployeeProjectMatrixCollection;
         new prc_employeeprojectmatrixreport(context ).execute(  AV10DateRange,  AV20DateRange_To,  AV11ProjectId,  AV12CompanyLocationId,  AV13EmployeeId,  AV32UserEmployeeIdCollection,  AV9ShowLeaveTotal, out  AV25OverallTotalHours, out  GXt_objcol_SdtSDT_EmployeeProjectMatrix6) ;
         AV22SDT_EmployeeProjectMatrixCollection = GXt_objcol_SdtSDT_EmployeeProjectMatrix6;
         GXt_char7 = "";
         new formattime(context ).execute(  AV25OverallTotalHours, out  GXt_char7) ;
         Usercontrol1_Formattedoveralltotalhours = GXt_char7;
         ucUsercontrol1.SendProperty(context, "", false, Usercontrol1_Internalname, "FormattedOverallTotalHours", Usercontrol1_Formattedoveralltotalhours);
         this.executeUsercontrolMethod("", false, "USERCONTROL1Container", "Refresh", "", new Object[] {});
      }

      protected void S182( )
      {
         /* 'GETEMPLOYEESTOSHOW' Routine */
         returnInSub = false;
         if ( AV32UserEmployeeIdCollection.Count > 0 )
         {
            AV26ToShowEmployeeIdCollection = AV32UserEmployeeIdCollection;
         }
         else
         {
            AV26ToShowEmployeeIdCollection.Clear();
            GXt_objcol_int3 = AV26ToShowEmployeeIdCollection;
            new getemployeeidsbyproject(context ).execute(  AV11ProjectId, out  GXt_objcol_int3) ;
            AV26ToShowEmployeeIdCollection = GXt_objcol_int3;
            pr_default.dynParam(7, new Object[]{ new Object[]{
                                                 A157CompanyLocationId ,
                                                 AV12CompanyLocationId } ,
                                                 new int[]{
                                                 TypeConstants.LONG
                                                 }
            });
            /* Using cursor H005A9 */
            pr_default.execute(7);
            while ( (pr_default.getStatus(7) != 101) )
            {
               A100CompanyId = H005A9_A100CompanyId[0];
               A157CompanyLocationId = H005A9_A157CompanyLocationId[0];
               A106EmployeeId = H005A9_A106EmployeeId[0];
               A157CompanyLocationId = H005A9_A157CompanyLocationId[0];
               AV26ToShowEmployeeIdCollection.Add(A106EmployeeId, 0);
               pr_default.readNext(7);
            }
            pr_default.close(7);
         }
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S192( )
      {
         /* 'GETPROJECTSTOSHOW' Routine */
         returnInSub = false;
         if ( AV33UserProjectIdCollection.Count > 0 )
         {
            AV27ToShowProjectIdCollection = AV33UserProjectIdCollection;
         }
         else
         {
            AV27ToShowProjectIdCollection.Clear();
            pr_default.dynParam(8, new Object[]{ new Object[]{
                                                 A106EmployeeId ,
                                                 AV13EmployeeId ,
                                                 AV13EmployeeId.Count } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.INT
                                                 }
            });
            /* Using cursor H005A10 */
            pr_default.execute(8);
            while ( (pr_default.getStatus(8) != 101) )
            {
               A106EmployeeId = H005A10_A106EmployeeId[0];
               /* Using cursor H005A11 */
               pr_default.execute(9, new Object[] {A106EmployeeId});
               while ( (pr_default.getStatus(9) != 101) )
               {
                  A102ProjectId = H005A11_A102ProjectId[0];
                  AV27ToShowProjectIdCollection.Add(A102ProjectId, 0);
                  pr_default.readNext(9);
               }
               pr_default.close(9);
               pr_default.readNext(8);
            }
            pr_default.close(8);
         }
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S122 ();
         if (returnInSub) return;
      }

      protected void S172( )
      {
         /* 'UPDATESESSIONVARIABLES' Routine */
         returnInSub = false;
         AV34WebSession.Set("CompanyLocationId", AV12CompanyLocationId.ToJSonString(false));
         AV34WebSession.Set("EmployeeId", AV13EmployeeId.ToJSonString(false));
         AV34WebSession.Set("ProjectId", AV11ProjectId.ToJSonString(false));
         AV34WebSession.Set("FromDate", context.localUtil.DToC( AV10DateRange, 2, "/"));
         AV34WebSession.Set("ToDate", context.localUtil.DToC( AV20DateRange_To, 2, "/"));
         AV34WebSession.Set("ShowLeaveTotal", StringUtil.BoolToStr( AV9ShowLeaveTotal));
      }

      protected void nextLoad( )
      {
      }

      protected void E245A2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_85_5A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableopenemployeedetails_modal_Internalname, tblTableopenemployeedetails_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucOpenemployeedetails_modal.SetProperty("Width", Openemployeedetails_modal_Width);
            ucOpenemployeedetails_modal.SetProperty("Title", Openemployeedetails_modal_Title);
            ucOpenemployeedetails_modal.SetProperty("ConfirmType", Openemployeedetails_modal_Confirmtype);
            ucOpenemployeedetails_modal.SetProperty("BodyType", Openemployeedetails_modal_Bodytype);
            ucOpenemployeedetails_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Openemployeedetails_modal_Internalname, "OPENEMPLOYEEDETAILS_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"OPENEMPLOYEEDETAILS_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_85_5A2e( true) ;
         }
         else
         {
            wb_table2_85_5A2e( false) ;
         }
      }

      protected void wb_table1_80_5A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableopenprojectdetails_modal_Internalname, tblTableopenprojectdetails_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucOpenprojectdetails_modal.SetProperty("Width", Openprojectdetails_modal_Width);
            ucOpenprojectdetails_modal.SetProperty("Title", Openprojectdetails_modal_Title);
            ucOpenprojectdetails_modal.SetProperty("ConfirmType", Openprojectdetails_modal_Confirmtype);
            ucOpenprojectdetails_modal.SetProperty("BodyType", Openprojectdetails_modal_Bodytype);
            ucOpenprojectdetails_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Openprojectdetails_modal_Internalname, "OPENPROJECTDETAILS_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"OPENPROJECTDETAILS_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_80_5A2e( true) ;
         }
         else
         {
            wb_table1_80_5A2e( false) ;
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
         PA5A2( ) ;
         WS5A2( ) ;
         WE5A2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267554019", true, true);
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
         context.AddJavascriptSource("wp_projectoverview.js", "?20256267554019", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_PivotTableRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         chkavShowleavetotal.Name = "vSHOWLEAVETOTAL";
         chkavShowleavetotal.WebTags = "";
         chkavShowleavetotal.Caption = "Show Leave Total";
         AssignProp("", false, chkavShowleavetotal_Internalname, "TitleCaption", chkavShowleavetotal.Caption, true);
         chkavShowleavetotal.CheckedValue = "false";
         AV9ShowLeaveTotal = StringUtil.StrToBool( StringUtil.BoolToStr( AV9ShowLeaveTotal));
         AssignAttri("", false, "AV9ShowLeaveTotal", AV9ShowLeaveTotal);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnexportexcel_Internalname = "BTNEXPORTEXCEL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         edtavDaterange_rangetext_Internalname = "vDATERANGE_RANGETEXT";
         lblTextblockcombo_projectid_Internalname = "TEXTBLOCKCOMBO_PROJECTID";
         Combo_projectid_Internalname = "COMBO_PROJECTID";
         divTablesplittedprojectid_Internalname = "TABLESPLITTEDPROJECTID";
         lblTextblockcombo_companylocationid_Internalname = "TEXTBLOCKCOMBO_COMPANYLOCATIONID";
         Combo_companylocationid_Internalname = "COMBO_COMPANYLOCATIONID";
         divTablesplittedcompanylocationid_Internalname = "TABLESPLITTEDCOMPANYLOCATIONID";
         lblTextblockcombo_employeeid_Internalname = "TEXTBLOCKCOMBO_EMPLOYEEID";
         Combo_employeeid_Internalname = "COMBO_EMPLOYEEID";
         divTablesplittedemployeeid_Internalname = "TABLESPLITTEDEMPLOYEEID";
         divTable1_Internalname = "TABLE1";
         lblTextblockshowleavetotal_Internalname = "TEXTBLOCKSHOWLEAVETOTAL";
         chkavShowleavetotal_Internalname = "vSHOWLEAVETOTAL";
         divUnnamedtableshowleavetotal_Internalname = "UNNAMEDTABLESHOWLEAVETOTAL";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         Usercontrol1_Internalname = "USERCONTROL1";
         bttBtnopenprojectdetails_Internalname = "BTNOPENPROJECTDETAILS";
         bttBtnopenemployeedetails_Internalname = "BTNOPENEMPLOYEEDETAILS";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divOverviewtable_Internalname = "OVERVIEWTABLE";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         Daterange_rangepicker_Internalname = "DATERANGE_RANGEPICKER";
         Openprojectdetails_modal_Internalname = "OPENPROJECTDETAILS_MODAL";
         tblTableopenprojectdetails_modal_Internalname = "TABLEOPENPROJECTDETAILS_MODAL";
         Openemployeedetails_modal_Internalname = "OPENEMPLOYEEDETAILS_MODAL";
         tblTableopenemployeedetails_modal_Internalname = "TABLEOPENEMPLOYEEDETAILS_MODAL";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         chkavShowleavetotal.Caption = "Show Leave Total";
         bttBtnopenprojectdetails_Visible = 1;
         divUnnamedtable4_Visible = 1;
         chkavShowleavetotal.Enabled = 1;
         Combo_employeeid_Caption = "";
         Combo_companylocationid_Caption = "";
         Combo_projectid_Caption = "";
         edtavDaterange_rangetext_Jsonclick = "";
         edtavDaterange_rangetext_Enabled = 1;
         Usercontrol1_Currentprojectid = 0;
         Usercontrol1_Currentemployeeid = 0;
         Openemployeedetails_modal_Bodytype = "WebComponent";
         Openemployeedetails_modal_Confirmtype = "";
         Openemployeedetails_modal_Title = " Work Hour Log";
         Openemployeedetails_modal_Width = "1240";
         Openprojectdetails_modal_Bodytype = "WebComponent";
         Openprojectdetails_modal_Confirmtype = "";
         Openprojectdetails_modal_Title = "Project Details";
         Openprojectdetails_modal_Width = "1240";
         Usercontrol1_Formattedoveralltotalhours = "";
         Usercontrol1_Showleavetotal = Convert.ToBoolean( 0);
         Combo_employeeid_Multiplevaluestype = "Tags";
         Combo_employeeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_employeeid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_employeeid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_employeeid_Cls = "ExtendedCombo BlobContentAttribute";
         Combo_companylocationid_Multiplevaluestype = "Tags";
         Combo_companylocationid_Emptyitem = Convert.ToBoolean( 0);
         Combo_companylocationid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_companylocationid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_companylocationid_Enabled = Convert.ToBoolean( -1);
         Combo_companylocationid_Cls = "ExtendedCombo BlobContentAttribute";
         Combo_projectid_Multiplevaluestype = "Tags";
         Combo_projectid_Emptyitem = Convert.ToBoolean( 0);
         Combo_projectid_Includeonlyselectedoption = Convert.ToBoolean( -1);
         Combo_projectid_Allowmultipleselection = Convert.ToBoolean( -1);
         Combo_projectid_Cls = "ExtendedCombo BlobContentAttribute";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Project Overview";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV9ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"AV35IsAuthorized_OpenProjectDetails","fld":"vISAUTHORIZED_OPENPROJECTDETAILS","hsh":true},{"av":"AV32UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"AV33UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV35IsAuthorized_OpenProjectDetails","fld":"vISAUTHORIZED_OPENPROJECTDETAILS","hsh":true},{"ctrl":"BTNOPENPROJECTDETAILS","prop":"Visible"}]}""");
         setEventMetadata("'DOOPENPROJECTDETAILS'","""{"handler":"E215A2","iparms":[{"av":"AV35IsAuthorized_OpenProjectDetails","fld":"vISAUTHORIZED_OPENPROJECTDETAILS","hsh":true}]}""");
         setEventMetadata("OPENPROJECTDETAILS_MODAL.CLOSE","""{"handler":"E175A2","iparms":[]}""");
         setEventMetadata("'DOOPENEMPLOYEEDETAILS'","""{"handler":"E115A1","iparms":[]}""");
         setEventMetadata("OPENEMPLOYEEDETAILS_MODAL.CLOSE","""{"handler":"E185A2","iparms":[]}""");
         setEventMetadata("'DOEXPORTEXCEL'","""{"handler":"E225A2","iparms":[{"av":"AV10DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV13EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV11ProjectId","fld":"vPROJECTID"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV9ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"AV22SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"}]}""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED","""{"handler":"E145A2","iparms":[{"av":"Combo_employeeid_Selectedvalue_get","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_get"},{"av":"AV10DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV11ProjectId","fld":"vPROJECTID"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV13EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV32UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"AV9ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV33UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV26ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"AV27ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"}]""");
         setEventMetadata("COMBO_EMPLOYEEID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV22SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV26ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV27ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV18EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV14ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED","""{"handler":"E135A2","iparms":[{"av":"Combo_companylocationid_Selectedvalue_get","ctrl":"COMBO_COMPANYLOCATIONID","prop":"SelectedValue_get"},{"av":"AV10DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV11ProjectId","fld":"vPROJECTID"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV13EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV32UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"AV9ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV33UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV26ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"AV27ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"}]""");
         setEventMetadata("COMBO_COMPANYLOCATIONID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV22SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV26ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV27ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV18EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV14ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED","""{"handler":"E125A2","iparms":[{"av":"Combo_projectid_Selectedvalue_get","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_get"},{"av":"AV10DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV11ProjectId","fld":"vPROJECTID"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV13EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV32UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"AV9ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV33UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV26ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"AV27ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"}]""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED",""","oparms":[{"av":"AV11ProjectId","fld":"vPROJECTID"},{"av":"AV22SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV26ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV27ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV18EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV14ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED","""{"handler":"E165A2","iparms":[{"av":"AV10DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV11ProjectId","fld":"vPROJECTID"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV13EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV32UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"AV9ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV33UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV26ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"AV27ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"}]""");
         setEventMetadata("DATERANGE_RANGEPICKER.DATERANGECHANGED",""","oparms":[{"av":"AV22SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV26ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV27ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV18EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV14ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("VSHOWLEAVETOTAL.CONTROLVALUECHANGED","""{"handler":"E235A2","iparms":[{"av":"AV9ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"},{"av":"AV10DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV11ProjectId","fld":"vPROJECTID"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV13EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV32UserEmployeeIdCollection","fld":"vUSEREMPLOYEEIDCOLLECTION","hsh":true},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV33UserProjectIdCollection","fld":"vUSERPROJECTIDCOLLECTION","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV26ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"AV27ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"}]""");
         setEventMetadata("VSHOWLEAVETOTAL.CONTROLVALUECHANGED",""","oparms":[{"av":"Usercontrol1_Showleavetotal","ctrl":"USERCONTROL1","prop":"ShowLeaveTotal"},{"av":"AV22SDT_EmployeeProjectMatrixCollection","fld":"vSDT_EMPLOYEEPROJECTMATRIXCOLLECTION"},{"av":"Usercontrol1_Formattedoveralltotalhours","ctrl":"USERCONTROL1","prop":"FormattedOverallTotalHours"},{"av":"AV26ToShowEmployeeIdCollection","fld":"vTOSHOWEMPLOYEEIDCOLLECTION"},{"av":"AV27ToShowProjectIdCollection","fld":"vTOSHOWPROJECTIDCOLLECTION"},{"av":"AV18EmployeeId_Data","fld":"vEMPLOYEEID_DATA"},{"av":"Combo_employeeid_Selectedvalue_set","ctrl":"COMBO_EMPLOYEEID","prop":"SelectedValue_set"},{"av":"AV14ProjectId_Data","fld":"vPROJECTID_DATA"},{"av":"Combo_projectid_Selectedvalue_set","ctrl":"COMBO_PROJECTID","prop":"SelectedValue_set"}]}""");
         setEventMetadata("USERCONTROL1.PROJECTCLICKED","""{"handler":"E155A2","iparms":[{"av":"Usercontrol1_Currentprojectid","ctrl":"USERCONTROL1","prop":"CurrentProjectId"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV13EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV11ProjectId","fld":"vPROJECTID"},{"av":"AV10DateRange","fld":"vDATERANGE"},{"av":"AV20DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV9ShowLeaveTotal","fld":"vSHOWLEAVETOTAL"}]""");
         setEventMetadata("USERCONTROL1.PROJECTCLICKED",""","oparms":[{"av":"AV36CurrentProjectId","fld":"vCURRENTPROJECTID","pic":"ZZZZZZZZZ9"}]}""");
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
         Combo_employeeid_Selectedvalue_get = "";
         Combo_companylocationid_Selectedvalue_get = "";
         Combo_projectid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV32UserEmployeeIdCollection = new GxSimpleCollection<long>();
         AV33UserProjectIdCollection = new GxSimpleCollection<long>();
         GXKey = "";
         AV15DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14ProjectId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17CompanyLocationId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV18EmployeeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV22SDT_EmployeeProjectMatrixCollection = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4");
         AV10DateRange = DateTime.MinValue;
         AV20DateRange_To = DateTime.MinValue;
         AV21DateRange_RangePickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         AV11ProjectId = new GxSimpleCollection<long>();
         AV13EmployeeId = new GxSimpleCollection<long>();
         AV12CompanyLocationId = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         AV26ToShowEmployeeIdCollection = new GxSimpleCollection<long>();
         A103ProjectName = "";
         AV27ToShowProjectIdCollection = new GxSimpleCollection<long>();
         Combo_projectid_Selectedvalue_set = "";
         Combo_companylocationid_Selectedvalue_set = "";
         Combo_employeeid_Selectedvalue_set = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnexportexcel_Jsonclick = "";
         AV19DateRange_RangeText = "";
         lblTextblockcombo_projectid_Jsonclick = "";
         ucCombo_projectid = new GXUserControl();
         lblTextblockcombo_companylocationid_Jsonclick = "";
         ucCombo_companylocationid = new GXUserControl();
         lblTextblockcombo_employeeid_Jsonclick = "";
         ucCombo_employeeid = new GXUserControl();
         lblTextblockshowleavetotal_Jsonclick = "";
         ucUsercontrol1 = new GXUserControl();
         bttBtnopenprojectdetails_Jsonclick = "";
         bttBtnopenemployeedetails_Jsonclick = "";
         ucDaterange_rangepicker = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Gx_date = DateTime.MinValue;
         H005A2_A100CompanyId = new long[1] ;
         H005A2_A106EmployeeId = new long[1] ;
         H005A2_A157CompanyLocationId = new long[1] ;
         H005A3_A106EmployeeId = new long[1] ;
         H005A3_A102ProjectId = new long[1] ;
         H005A4_A100CompanyId = new long[1] ;
         H005A4_A106EmployeeId = new long[1] ;
         H005A5_A162ProjectManagerId = new long[1] ;
         H005A5_n162ProjectManagerId = new bool[] {false} ;
         H005A5_A102ProjectId = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_SdtWWPDateRangePickerOptions5 = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         AV23Filename = "";
         AV24ErrorMessage = "";
         H005A6_A106EmployeeId = new long[1] ;
         H005A6_A148EmployeeName = new string[] {""} ;
         AV16Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         H005A7_A157CompanyLocationId = new long[1] ;
         H005A7_A158CompanyLocationName = new string[] {""} ;
         A158CompanyLocationName = "";
         H005A8_A102ProjectId = new long[1] ;
         H005A8_A103ProjectName = new string[] {""} ;
         GXt_objcol_SdtSDT_EmployeeProjectMatrix6 = new GXBaseCollection<SdtSDT_EmployeeProjectMatrix>( context, "SDT_EmployeeProjectMatrix", "YTT_version4");
         GXt_char7 = "";
         GXt_objcol_int3 = new GxSimpleCollection<long>();
         H005A9_A100CompanyId = new long[1] ;
         H005A9_A157CompanyLocationId = new long[1] ;
         H005A9_A106EmployeeId = new long[1] ;
         H005A10_A106EmployeeId = new long[1] ;
         H005A11_A106EmployeeId = new long[1] ;
         H005A11_A102ProjectId = new long[1] ;
         AV34WebSession = context.GetSession();
         sStyleString = "";
         ucOpenemployeedetails_modal = new GXUserControl();
         ucOpenprojectdetails_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_projectoverview__default(),
            new Object[][] {
                new Object[] {
               H005A2_A100CompanyId, H005A2_A106EmployeeId, H005A2_A157CompanyLocationId
               }
               , new Object[] {
               H005A3_A106EmployeeId, H005A3_A102ProjectId
               }
               , new Object[] {
               H005A4_A100CompanyId, H005A4_A106EmployeeId
               }
               , new Object[] {
               H005A5_A162ProjectManagerId, H005A5_n162ProjectManagerId, H005A5_A102ProjectId
               }
               , new Object[] {
               H005A6_A106EmployeeId, H005A6_A148EmployeeName
               }
               , new Object[] {
               H005A7_A157CompanyLocationId, H005A7_A158CompanyLocationName
               }
               , new Object[] {
               H005A8_A102ProjectId, H005A8_A103ProjectName
               }
               , new Object[] {
               H005A9_A100CompanyId, H005A9_A157CompanyLocationId, H005A9_A106EmployeeId
               }
               , new Object[] {
               H005A10_A106EmployeeId
               }
               , new Object[] {
               H005A11_A106EmployeeId, H005A11_A102ProjectId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_12 ;
      private short nIsMod_12 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Usercontrol1_Currentemployeeid ;
      private int Usercontrol1_Currentprojectid ;
      private int edtavDaterange_rangetext_Enabled ;
      private int divUnnamedtable4_Visible ;
      private int bttBtnopenprojectdetails_Visible ;
      private int AV26ToShowEmployeeIdCollection_Count ;
      private int AV13EmployeeId_Count ;
      private int idxLst ;
      private long AV36CurrentProjectId ;
      private long AV37CurrentEmployeeId ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long AV39LoggedInEmployeeId ;
      private long GXt_int2 ;
      private long A100CompanyId ;
      private long AV44Udparg1 ;
      private long A162ProjectManagerId ;
      private long AV25OverallTotalHours ;
      private string Combo_employeeid_Selectedvalue_get ;
      private string Combo_companylocationid_Selectedvalue_get ;
      private string Combo_projectid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A148EmployeeName ;
      private string A103ProjectName ;
      private string Combo_projectid_Cls ;
      private string Combo_projectid_Selectedvalue_set ;
      private string Combo_projectid_Multiplevaluestype ;
      private string Combo_companylocationid_Cls ;
      private string Combo_companylocationid_Selectedvalue_set ;
      private string Combo_companylocationid_Multiplevaluestype ;
      private string Combo_employeeid_Cls ;
      private string Combo_employeeid_Selectedvalue_set ;
      private string Combo_employeeid_Multiplevaluestype ;
      private string Usercontrol1_Formattedoveralltotalhours ;
      private string Openprojectdetails_modal_Width ;
      private string Openprojectdetails_modal_Title ;
      private string Openprojectdetails_modal_Confirmtype ;
      private string Openprojectdetails_modal_Bodytype ;
      private string Openemployeedetails_modal_Width ;
      private string Openemployeedetails_modal_Title ;
      private string Openemployeedetails_modal_Confirmtype ;
      private string Openemployeedetails_modal_Bodytype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divUnnamedtable1_Internalname ;
      private string TempTags ;
      private string bttBtnexportexcel_Internalname ;
      private string bttBtnexportexcel_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string divOverviewtable_Internalname ;
      private string divTable1_Internalname ;
      private string edtavDaterange_rangetext_Internalname ;
      private string edtavDaterange_rangetext_Jsonclick ;
      private string divTablesplittedprojectid_Internalname ;
      private string lblTextblockcombo_projectid_Internalname ;
      private string lblTextblockcombo_projectid_Jsonclick ;
      private string Combo_projectid_Caption ;
      private string Combo_projectid_Internalname ;
      private string divTablesplittedcompanylocationid_Internalname ;
      private string lblTextblockcombo_companylocationid_Internalname ;
      private string lblTextblockcombo_companylocationid_Jsonclick ;
      private string Combo_companylocationid_Caption ;
      private string Combo_companylocationid_Internalname ;
      private string divTablesplittedemployeeid_Internalname ;
      private string lblTextblockcombo_employeeid_Internalname ;
      private string lblTextblockcombo_employeeid_Jsonclick ;
      private string Combo_employeeid_Caption ;
      private string Combo_employeeid_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string divUnnamedtableshowleavetotal_Internalname ;
      private string lblTextblockshowleavetotal_Internalname ;
      private string lblTextblockshowleavetotal_Jsonclick ;
      private string chkavShowleavetotal_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string Usercontrol1_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string bttBtnopenprojectdetails_Internalname ;
      private string bttBtnopenprojectdetails_Jsonclick ;
      private string bttBtnopenemployeedetails_Internalname ;
      private string bttBtnopenemployeedetails_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Daterange_rangepicker_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A158CompanyLocationName ;
      private string GXt_char7 ;
      private string sStyleString ;
      private string tblTableopenemployeedetails_modal_Internalname ;
      private string Openemployeedetails_modal_Internalname ;
      private string tblTableopenprojectdetails_modal_Internalname ;
      private string Openprojectdetails_modal_Internalname ;
      private DateTime AV10DateRange ;
      private DateTime AV20DateRange_To ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV35IsAuthorized_OpenProjectDetails ;
      private bool Combo_projectid_Allowmultipleselection ;
      private bool Combo_projectid_Includeonlyselectedoption ;
      private bool Combo_projectid_Emptyitem ;
      private bool Combo_companylocationid_Enabled ;
      private bool Combo_companylocationid_Allowmultipleselection ;
      private bool Combo_companylocationid_Includeonlyselectedoption ;
      private bool Combo_companylocationid_Emptyitem ;
      private bool Combo_employeeid_Allowmultipleselection ;
      private bool Combo_employeeid_Includeonlyselectedoption ;
      private bool Combo_employeeid_Emptyitem ;
      private bool Usercontrol1_Showleavetotal ;
      private bool wbLoad ;
      private bool AV9ShowLeaveTotal ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV28IsProjectManager ;
      private bool AV31IsManager ;
      private bool AV38IsEmployee ;
      private bool n162ProjectManagerId ;
      private bool GXt_boolean1 ;
      private string AV19DateRange_RangeText ;
      private string AV23Filename ;
      private string AV24ErrorMessage ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucCombo_projectid ;
      private GXUserControl ucCombo_companylocationid ;
      private GXUserControl ucCombo_employeeid ;
      private GXUserControl ucUsercontrol1 ;
      private GXUserControl ucDaterange_rangepicker ;
      private GXUserControl ucOpenemployeedetails_modal ;
      private GXUserControl ucOpenprojectdetails_modal ;
      private IGxSession AV34WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavShowleavetotal ;
      private GxSimpleCollection<long> AV32UserEmployeeIdCollection ;
      private GxSimpleCollection<long> AV33UserProjectIdCollection ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV14ProjectId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV17CompanyLocationId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV18EmployeeId_Data ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> AV22SDT_EmployeeProjectMatrixCollection ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions AV21DateRange_RangePickerOptions ;
      private GxSimpleCollection<long> AV11ProjectId ;
      private GxSimpleCollection<long> AV13EmployeeId ;
      private GxSimpleCollection<long> AV12CompanyLocationId ;
      private GxSimpleCollection<long> AV26ToShowEmployeeIdCollection ;
      private GxSimpleCollection<long> AV27ToShowProjectIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] H005A2_A100CompanyId ;
      private long[] H005A2_A106EmployeeId ;
      private long[] H005A2_A157CompanyLocationId ;
      private long[] H005A3_A106EmployeeId ;
      private long[] H005A3_A102ProjectId ;
      private long[] H005A4_A100CompanyId ;
      private long[] H005A4_A106EmployeeId ;
      private long[] H005A5_A162ProjectManagerId ;
      private bool[] H005A5_n162ProjectManagerId ;
      private long[] H005A5_A102ProjectId ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions5 ;
      private long[] H005A6_A106EmployeeId ;
      private string[] H005A6_A148EmployeeName ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV16Combo_DataItem ;
      private long[] H005A7_A157CompanyLocationId ;
      private string[] H005A7_A158CompanyLocationName ;
      private long[] H005A8_A102ProjectId ;
      private string[] H005A8_A103ProjectName ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> GXt_objcol_SdtSDT_EmployeeProjectMatrix6 ;
      private GxSimpleCollection<long> GXt_objcol_int3 ;
      private long[] H005A9_A100CompanyId ;
      private long[] H005A9_A157CompanyLocationId ;
      private long[] H005A9_A106EmployeeId ;
      private long[] H005A10_A106EmployeeId ;
      private long[] H005A11_A106EmployeeId ;
      private long[] H005A11_A102ProjectId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_projectoverview__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005A6( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV26ToShowEmployeeIdCollection ,
                                             int AV26ToShowEmployeeIdCollection_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT EmployeeId, EmployeeName FROM Employee";
         if ( AV26ToShowEmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV26ToShowEmployeeIdCollection, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeName";
         GXv_Object8[0] = scmdbuf;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H005A8( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV27ToShowProjectIdCollection )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT ProjectId, ProjectName FROM Project";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV27ToShowProjectIdCollection, "ProjectId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ProjectName";
         GXv_Object10[0] = scmdbuf;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H005A9( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV12CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12CompanyLocationId, "T2.CompanyLocationId IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object12[0] = scmdbuf;
         return GXv_Object12 ;
      }

      protected Object[] conditional_H005A10( IGxContext context ,
                                              long A106EmployeeId ,
                                              GxSimpleCollection<long> AV13EmployeeId ,
                                              int AV13EmployeeId_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT EmployeeId FROM Employee";
         if ( AV13EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13EmployeeId, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY EmployeeId";
         GXv_Object14[0] = scmdbuf;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 4 :
                     return conditional_H005A6(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
               case 6 :
                     return conditional_H005A8(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
               case 7 :
                     return conditional_H005A9(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] );
               case 8 :
                     return conditional_H005A10(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] );
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005A2;
          prmH005A2 = new Object[] {
          new ParDef("AV39LoggedInEmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH005A3;
          prmH005A3 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH005A4;
          prmH005A4 = new Object[] {
          new ParDef("AV44Udparg1",GXType.Int64,10,0)
          };
          Object[] prmH005A5;
          prmH005A5 = new Object[] {
          new ParDef("AV39LoggedInEmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH005A7;
          prmH005A7 = new Object[] {
          };
          Object[] prmH005A11;
          prmH005A11 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH005A6;
          prmH005A6 = new Object[] {
          };
          Object[] prmH005A8;
          prmH005A8 = new Object[] {
          };
          Object[] prmH005A9;
          prmH005A9 = new Object[] {
          };
          Object[] prmH005A10;
          prmH005A10 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H005A2", "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T1.EmployeeId = :AV39LoggedInEmployeeId ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H005A3", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005A4", "SELECT CompanyId, EmployeeId FROM Employee WHERE CompanyId = :AV44Udparg1 ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005A5", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV39LoggedInEmployeeId ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005A6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005A7", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005A8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005A9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005A10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005A11", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005A11,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
