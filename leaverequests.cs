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
   public class leaverequests : GXDataArea
   {
      public leaverequests( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequests( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Mesage )
      {
         this.AV64Mesage = aP0_Mesage;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mesage");
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
               gxfirstwebparm = GetFirstPar( "Mesage");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mesage");
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
               AV64Mesage = gxfirstwebparm;
               AssignAttri("", false, "AV64Mesage", AV64Mesage);
               GxWebStd.gx_hidden_field( context, "gxhash_vMESAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Mesage, "")), context));
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
         AV35OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV37OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV19FilterFullText = GetPar( "FilterFullText");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6ColumnsSelector);
         AV73Pgmname = GetPar( "Pgmname");
         AV55TFLeaveTypeName = GetPar( "TFLeaveTypeName");
         AV56TFLeaveTypeName_Sel = GetPar( "TFLeaveTypeName_Sel");
         AV51TFLeaveRequestStartDate = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestStartDate"));
         AV52TFLeaveRequestStartDate_To = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestStartDate_To"));
         AV47TFLeaveRequestEndDate = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestEndDate"));
         AV48TFLeaveRequestEndDate_To = context.localUtil.ParseDateParm( GetPar( "TFLeaveRequestEndDate_To"));
         AV68TFLeaveRequestHalfDay = GetPar( "TFLeaveRequestHalfDay");
         AV69TFLeaveRequestHalfDay_Sel = GetPar( "TFLeaveRequestHalfDay_Sel");
         AV45TFLeaveRequestDuration = NumberUtil.Val( GetPar( "TFLeaveRequestDuration"), ".");
         AV46TFLeaveRequestDuration_To = NumberUtil.Val( GetPar( "TFLeaveRequestDuration_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV53TFLeaveRequestStatus_Sels);
         AV43TFLeaveRequestDescription = GetPar( "TFLeaveRequestDescription");
         AV44TFLeaveRequestDescription_Sel = GetPar( "TFLeaveRequestDescription_Sel");
         AV49TFLeaveRequestRejectionReason = GetPar( "TFLeaveRequestRejectionReason");
         AV50TFLeaveRequestRejectionReason_Sel = GetPar( "TFLeaveRequestRejectionReason_Sel");
         AV66checking = StringUtil.StrToBool( GetPar( "checking"));
         AV30IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV29IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         AV34MsgVar = GetPar( "MsgVar");
         AV64Mesage = GetPar( "Mesage");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV19FilterFullText, AV6ColumnsSelector, AV73Pgmname, AV55TFLeaveTypeName, AV56TFLeaveTypeName_Sel, AV51TFLeaveRequestStartDate, AV52TFLeaveRequestStartDate_To, AV47TFLeaveRequestEndDate, AV48TFLeaveRequestEndDate_To, AV68TFLeaveRequestHalfDay, AV69TFLeaveRequestHalfDay_Sel, AV45TFLeaveRequestDuration, AV46TFLeaveRequestDuration_To, AV53TFLeaveRequestStatus_Sels, AV43TFLeaveRequestDescription, AV44TFLeaveRequestDescription_Sel, AV49TFLeaveRequestRejectionReason, AV50TFLeaveRequestRejectionReason_Sel, AV66checking, AV30IsAuthorized_Update, AV29IsAuthorized_Insert, AV34MsgVar, AV64Mesage) ;
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
            return "leaverequests_Execute" ;
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
         PA4B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4B2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leaverequests.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV64Mesage))}, new string[] {"Mesage"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKING", AV66checking);
         GxWebStd.gx_hidden_field( context, "gxhash_vCHECKING", GetSecureSignedToken( "", AV66checking, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV30IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV30IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV29IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV29IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vMSGVAR", StringUtil.RTrim( AV34MsgVar));
         GxWebStd.gx_hidden_field( context, "gxhash_vMSGVAR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34MsgVar, "")), context));
         GxWebStd.gx_hidden_field( context, "vMESAGE", StringUtil.RTrim( AV64Mesage));
         GxWebStd.gx_hidden_field( context, "gxhash_vMESAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Mesage, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV37OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV19FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV22GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV18DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV18DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV6ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV6ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTSTARTDATEAUXDATE", context.localUtil.DToC( AV15DDO_LeaveRequestStartDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTSTARTDATEAUXDATETO", context.localUtil.DToC( AV17DDO_LeaveRequestStartDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTENDDATEAUXDATE", context.localUtil.DToC( AV12DDO_LeaveRequestEndDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_LEAVEREQUESTENDDATEAUXDATETO", context.localUtil.DToC( AV14DDO_LeaveRequestEndDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFLEAVETYPENAME", StringUtil.RTrim( AV55TFLeaveTypeName));
         GxWebStd.gx_hidden_field( context, "vTFLEAVETYPENAME_SEL", StringUtil.RTrim( AV56TFLeaveTypeName_Sel));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTSTARTDATE", context.localUtil.DToC( AV51TFLeaveRequestStartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTSTARTDATE_TO", context.localUtil.DToC( AV52TFLeaveRequestStartDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTENDDATE", context.localUtil.DToC( AV47TFLeaveRequestEndDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTENDDATE_TO", context.localUtil.DToC( AV48TFLeaveRequestEndDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTHALFDAY", StringUtil.RTrim( AV68TFLeaveRequestHalfDay));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTHALFDAY_SEL", StringUtil.RTrim( AV69TFLeaveRequestHalfDay_Sel));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDURATION", StringUtil.LTrim( StringUtil.NToC( AV45TFLeaveRequestDuration, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDURATION_TO", StringUtil.LTrim( StringUtil.NToC( AV46TFLeaveRequestDuration_To, 4, 1, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFLEAVEREQUESTSTATUS_SELS", AV53TFLeaveRequestStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFLEAVEREQUESTSTATUS_SELS", AV53TFLeaveRequestStatus_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDESCRIPTION", AV43TFLeaveRequestDescription);
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTDESCRIPTION_SEL", AV44TFLeaveRequestDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTREJECTIONREASON", AV49TFLeaveRequestRejectionReason);
         GxWebStd.gx_hidden_field( context, "vTFLEAVEREQUESTREJECTIONREASON_SEL", AV50TFLeaveRequestRejectionReason_Sel);
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKING", AV66checking);
         GxWebStd.gx_hidden_field( context, "gxhash_vCHECKING", GetSecureSignedToken( "", AV66checking, context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV37OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV30IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV30IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV29IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV29IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vMSGVAR", StringUtil.RTrim( AV34MsgVar));
         GxWebStd.gx_hidden_field( context, "gxhash_vMSGVAR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34MsgVar, "")), context));
         GxWebStd.gx_hidden_field( context, "vMESAGE", StringUtil.RTrim( AV64Mesage));
         GxWebStd.gx_hidden_field( context, "gxhash_vMESAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Mesage, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Visible", StringUtil.BoolToStr( Ddo_gridcolumnsselector_Visible));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
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
            WE4B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4B2( ) ;
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
         return formatLink("leaverequests.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV64Mesage))}, new string[] {"Mesage"})  ;
      }

      public override string GetPgmname( )
      {
         return "LeaveRequests" ;
      }

      public override string GetPgmdesc( )
      {
         return " My Leave Requests" ;
      }

      protected void WB4B0( )
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
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequests.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequests.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV19FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV19FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_LeaveRequests.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV23GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV24GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV22GridAppliedFilters);
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
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV6ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_leaverequeststartdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_leaverequeststartdateauxdatetext_Internalname, AV16DDO_LeaveRequestStartDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV16DDO_LeaveRequestStartDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_leaverequeststartdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequests.htm");
            /* User Defined Control */
            ucTfleaverequeststartdate_rangepicker.SetProperty("Start Date", AV15DDO_LeaveRequestStartDateAuxDate);
            ucTfleaverequeststartdate_rangepicker.SetProperty("End Date", AV17DDO_LeaveRequestStartDateAuxDateTo);
            ucTfleaverequeststartdate_rangepicker.Render(context, "wwp.daterangepicker", Tfleaverequeststartdate_rangepicker_Internalname, "TFLEAVEREQUESTSTARTDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_leaverequestenddateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_leaverequestenddateauxdatetext_Internalname, AV13DDO_LeaveRequestEndDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV13DDO_LeaveRequestEndDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_leaverequestenddateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LeaveRequests.htm");
            /* User Defined Control */
            ucTfleaverequestenddate_rangepicker.SetProperty("Start Date", AV12DDO_LeaveRequestEndDateAuxDate);
            ucTfleaverequestenddate_rangepicker.SetProperty("End Date", AV14DDO_LeaveRequestEndDateAuxDateTo);
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

      protected void START4B2( )
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
         Form.Meta.addItem("description", " My Leave Requests", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4B0( ) ;
      }

      protected void WS4B2( )
      {
         START4B2( ) ;
         EVT4B2( ) ;
      }

      protected void EVT4B2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E114B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E124B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E134B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E144B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E154B2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VUSERACTION1.CLICK") == 0 ) )
                           {
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              AV60UserAction1 = cgiGet( edtavUseraction1_Internalname);
                              AssignAttri("", false, edtavUseraction1_Internalname, AV60UserAction1);
                              AV59Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV59Update);
                              A127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveRequestId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A124LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
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
                              A134LeaveRequestRejectionReason = cgiGet( edtLeaveRequestRejectionReason_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E164B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E174B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E184B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUSERACTION1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E194B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV35OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV37OrderedDsc )
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

      protected void WE4B2( )
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

      protected void PA4B2( )
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
                                       short AV35OrderedBy ,
                                       bool AV37OrderedDsc ,
                                       string AV19FilterFullText ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV6ColumnsSelector ,
                                       string AV73Pgmname ,
                                       string AV55TFLeaveTypeName ,
                                       string AV56TFLeaveTypeName_Sel ,
                                       DateTime AV51TFLeaveRequestStartDate ,
                                       DateTime AV52TFLeaveRequestStartDate_To ,
                                       DateTime AV47TFLeaveRequestEndDate ,
                                       DateTime AV48TFLeaveRequestEndDate_To ,
                                       string AV68TFLeaveRequestHalfDay ,
                                       string AV69TFLeaveRequestHalfDay_Sel ,
                                       decimal AV45TFLeaveRequestDuration ,
                                       decimal AV46TFLeaveRequestDuration_To ,
                                       GxSimpleCollection<string> AV53TFLeaveRequestStatus_Sels ,
                                       string AV43TFLeaveRequestDescription ,
                                       string AV44TFLeaveRequestDescription_Sel ,
                                       string AV49TFLeaveRequestRejectionReason ,
                                       string AV50TFLeaveRequestRejectionReason_Sel ,
                                       bool AV66checking ,
                                       bool AV30IsAuthorized_Update ,
                                       bool AV29IsAuthorized_Insert ,
                                       string AV34MsgVar ,
                                       string AV64Mesage )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4B2( ) ;
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
         RF4B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV73Pgmname = "LeaveRequests";
         edtavUseraction1_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      protected void RF4B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 35;
         /* Execute user event: Refresh */
         E174B2 ();
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
                                                 A132LeaveRequestStatus ,
                                                 AV85Leaverequestsds_13_tfleaverequeststatus_sels ,
                                                 AV74Leaverequestsds_2_filterfulltext ,
                                                 AV76Leaverequestsds_4_tfleavetypename_sel ,
                                                 AV75Leaverequestsds_3_tfleavetypename ,
                                                 AV77Leaverequestsds_5_tfleaverequeststartdate ,
                                                 AV78Leaverequestsds_6_tfleaverequeststartdate_to ,
                                                 AV79Leaverequestsds_7_tfleaverequestenddate ,
                                                 AV80Leaverequestsds_8_tfleaverequestenddate_to ,
                                                 AV82Leaverequestsds_10_tfleaverequesthalfday_sel ,
                                                 AV81Leaverequestsds_9_tfleaverequesthalfday ,
                                                 AV83Leaverequestsds_11_tfleaverequestduration ,
                                                 AV84Leaverequestsds_12_tfleaverequestduration_to ,
                                                 AV85Leaverequestsds_13_tfleaverequeststatus_sels.Count ,
                                                 AV87Leaverequestsds_15_tfleaverequestdescription_sel ,
                                                 AV86Leaverequestsds_14_tfleaverequestdescription ,
                                                 AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel ,
                                                 AV88Leaverequestsds_16_tfleaverequestrejectionreason ,
                                                 A125LeaveTypeName ,
                                                 A171LeaveRequestHalfDay ,
                                                 A131LeaveRequestDuration ,
                                                 A133LeaveRequestDescription ,
                                                 A134LeaveRequestRejectionReason ,
                                                 A129LeaveRequestStartDate ,
                                                 A130LeaveRequestEndDate ,
                                                 AV35OrderedBy ,
                                                 AV37OrderedDsc ,
                                                 A106EmployeeId ,
                                                 AV72Udparg1 } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
            lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
            lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
            lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
            lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
            lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
            lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
            lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
            lV75Leaverequestsds_3_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV75Leaverequestsds_3_tfleavetypename), 100, "%");
            lV81Leaverequestsds_9_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV81Leaverequestsds_9_tfleaverequesthalfday), 20, "%");
            lV86Leaverequestsds_14_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV86Leaverequestsds_14_tfleaverequestdescription), "%", "");
            lV88Leaverequestsds_16_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV88Leaverequestsds_16_tfleaverequestrejectionreason), "%", "");
            /* Using cursor H004B2 */
            pr_default.execute(0, new Object[] {AV72Udparg1, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV75Leaverequestsds_3_tfleavetypename, AV76Leaverequestsds_4_tfleavetypename_sel, AV77Leaverequestsds_5_tfleaverequeststartdate, AV78Leaverequestsds_6_tfleaverequeststartdate_to, AV79Leaverequestsds_7_tfleaverequestenddate, AV80Leaverequestsds_8_tfleaverequestenddate_to, lV81Leaverequestsds_9_tfleaverequesthalfday, AV82Leaverequestsds_10_tfleaverequesthalfday_sel, AV83Leaverequestsds_11_tfleaverequestduration, AV84Leaverequestsds_12_tfleaverequestduration_to, lV86Leaverequestsds_14_tfleaverequestdescription, AV87Leaverequestsds_15_tfleaverequestdescription_sel, lV88Leaverequestsds_16_tfleaverequestrejectionreason, AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_35_idx = 1;
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A106EmployeeId = H004B2_A106EmployeeId[0];
               A134LeaveRequestRejectionReason = H004B2_A134LeaveRequestRejectionReason[0];
               A133LeaveRequestDescription = H004B2_A133LeaveRequestDescription[0];
               A132LeaveRequestStatus = H004B2_A132LeaveRequestStatus[0];
               A131LeaveRequestDuration = H004B2_A131LeaveRequestDuration[0];
               A171LeaveRequestHalfDay = H004B2_A171LeaveRequestHalfDay[0];
               n171LeaveRequestHalfDay = H004B2_n171LeaveRequestHalfDay[0];
               A130LeaveRequestEndDate = H004B2_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = H004B2_A129LeaveRequestStartDate[0];
               A128LeaveRequestDate = H004B2_A128LeaveRequestDate[0];
               A125LeaveTypeName = H004B2_A125LeaveTypeName[0];
               A124LeaveTypeId = H004B2_A124LeaveTypeId[0];
               A127LeaveRequestId = H004B2_A127LeaveRequestId[0];
               A125LeaveTypeName = H004B2_A125LeaveTypeName[0];
               /* Execute user event: Grid.Load */
               E184B2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 35;
            WB4B0( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4B2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKING", AV66checking);
         GxWebStd.gx_hidden_field( context, "gxhash_vCHECKING", GetSecureSignedToken( "", AV66checking, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV30IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV30IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV29IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV29IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vMSGVAR", StringUtil.RTrim( AV34MsgVar));
         GxWebStd.gx_hidden_field( context, "gxhash_vMSGVAR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34MsgVar, "")), context));
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
         AV74Leaverequestsds_2_filterfulltext = AV19FilterFullText;
         AV75Leaverequestsds_3_tfleavetypename = AV55TFLeaveTypeName;
         AV76Leaverequestsds_4_tfleavetypename_sel = AV56TFLeaveTypeName_Sel;
         AV77Leaverequestsds_5_tfleaverequeststartdate = AV51TFLeaveRequestStartDate;
         AV78Leaverequestsds_6_tfleaverequeststartdate_to = AV52TFLeaveRequestStartDate_To;
         AV79Leaverequestsds_7_tfleaverequestenddate = AV47TFLeaveRequestEndDate;
         AV80Leaverequestsds_8_tfleaverequestenddate_to = AV48TFLeaveRequestEndDate_To;
         AV81Leaverequestsds_9_tfleaverequesthalfday = AV68TFLeaveRequestHalfDay;
         AV82Leaverequestsds_10_tfleaverequesthalfday_sel = AV69TFLeaveRequestHalfDay_Sel;
         AV83Leaverequestsds_11_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV84Leaverequestsds_12_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV85Leaverequestsds_13_tfleaverequeststatus_sels = AV53TFLeaveRequestStatus_Sels;
         AV86Leaverequestsds_14_tfleaverequestdescription = AV43TFLeaveRequestDescription;
         AV87Leaverequestsds_15_tfleaverequestdescription_sel = AV44TFLeaveRequestDescription_Sel;
         AV88Leaverequestsds_16_tfleaverequestrejectionreason = AV49TFLeaveRequestRejectionReason;
         AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel = AV50TFLeaveRequestRejectionReason_Sel;
         AV72Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV85Leaverequestsds_13_tfleaverequeststatus_sels ,
                                              AV74Leaverequestsds_2_filterfulltext ,
                                              AV76Leaverequestsds_4_tfleavetypename_sel ,
                                              AV75Leaverequestsds_3_tfleavetypename ,
                                              AV77Leaverequestsds_5_tfleaverequeststartdate ,
                                              AV78Leaverequestsds_6_tfleaverequeststartdate_to ,
                                              AV79Leaverequestsds_7_tfleaverequestenddate ,
                                              AV80Leaverequestsds_8_tfleaverequestenddate_to ,
                                              AV82Leaverequestsds_10_tfleaverequesthalfday_sel ,
                                              AV81Leaverequestsds_9_tfleaverequesthalfday ,
                                              AV83Leaverequestsds_11_tfleaverequestduration ,
                                              AV84Leaverequestsds_12_tfleaverequestduration_to ,
                                              AV85Leaverequestsds_13_tfleaverequeststatus_sels.Count ,
                                              AV87Leaverequestsds_15_tfleaverequestdescription_sel ,
                                              AV86Leaverequestsds_14_tfleaverequestdescription ,
                                              AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel ,
                                              AV88Leaverequestsds_16_tfleaverequestrejectionreason ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A134LeaveRequestRejectionReason ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              AV35OrderedBy ,
                                              AV37OrderedDsc ,
                                              A106EmployeeId ,
                                              AV72Udparg1 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
         lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
         lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
         lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
         lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
         lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
         lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
         lV74Leaverequestsds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext), "%", "");
         lV75Leaverequestsds_3_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV75Leaverequestsds_3_tfleavetypename), 100, "%");
         lV81Leaverequestsds_9_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV81Leaverequestsds_9_tfleaverequesthalfday), 20, "%");
         lV86Leaverequestsds_14_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV86Leaverequestsds_14_tfleaverequestdescription), "%", "");
         lV88Leaverequestsds_16_tfleaverequestrejectionreason = StringUtil.Concat( StringUtil.RTrim( AV88Leaverequestsds_16_tfleaverequestrejectionreason), "%", "");
         /* Using cursor H004B3 */
         pr_default.execute(1, new Object[] {AV72Udparg1, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV74Leaverequestsds_2_filterfulltext, lV75Leaverequestsds_3_tfleavetypename, AV76Leaverequestsds_4_tfleavetypename_sel, AV77Leaverequestsds_5_tfleaverequeststartdate, AV78Leaverequestsds_6_tfleaverequeststartdate_to, AV79Leaverequestsds_7_tfleaverequestenddate, AV80Leaverequestsds_8_tfleaverequestenddate_to, lV81Leaverequestsds_9_tfleaverequesthalfday, AV82Leaverequestsds_10_tfleaverequesthalfday_sel, AV83Leaverequestsds_11_tfleaverequestduration, AV84Leaverequestsds_12_tfleaverequestduration_to, lV86Leaverequestsds_14_tfleaverequestdescription, AV87Leaverequestsds_15_tfleaverequestdescription_sel, lV88Leaverequestsds_16_tfleaverequestrejectionreason, AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel});
         GRID_nRecordCount = H004B3_AGRID_nRecordCount[0];
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
         AV74Leaverequestsds_2_filterfulltext = AV19FilterFullText;
         AV75Leaverequestsds_3_tfleavetypename = AV55TFLeaveTypeName;
         AV76Leaverequestsds_4_tfleavetypename_sel = AV56TFLeaveTypeName_Sel;
         AV77Leaverequestsds_5_tfleaverequeststartdate = AV51TFLeaveRequestStartDate;
         AV78Leaverequestsds_6_tfleaverequeststartdate_to = AV52TFLeaveRequestStartDate_To;
         AV79Leaverequestsds_7_tfleaverequestenddate = AV47TFLeaveRequestEndDate;
         AV80Leaverequestsds_8_tfleaverequestenddate_to = AV48TFLeaveRequestEndDate_To;
         AV81Leaverequestsds_9_tfleaverequesthalfday = AV68TFLeaveRequestHalfDay;
         AV82Leaverequestsds_10_tfleaverequesthalfday_sel = AV69TFLeaveRequestHalfDay_Sel;
         AV83Leaverequestsds_11_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV84Leaverequestsds_12_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV85Leaverequestsds_13_tfleaverequeststatus_sels = AV53TFLeaveRequestStatus_Sels;
         AV86Leaverequestsds_14_tfleaverequestdescription = AV43TFLeaveRequestDescription;
         AV87Leaverequestsds_15_tfleaverequestdescription_sel = AV44TFLeaveRequestDescription_Sel;
         AV88Leaverequestsds_16_tfleaverequestrejectionreason = AV49TFLeaveRequestRejectionReason;
         AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel = AV50TFLeaveRequestRejectionReason_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV19FilterFullText, AV6ColumnsSelector, AV73Pgmname, AV55TFLeaveTypeName, AV56TFLeaveTypeName_Sel, AV51TFLeaveRequestStartDate, AV52TFLeaveRequestStartDate_To, AV47TFLeaveRequestEndDate, AV48TFLeaveRequestEndDate_To, AV68TFLeaveRequestHalfDay, AV69TFLeaveRequestHalfDay_Sel, AV45TFLeaveRequestDuration, AV46TFLeaveRequestDuration_To, AV53TFLeaveRequestStatus_Sels, AV43TFLeaveRequestDescription, AV44TFLeaveRequestDescription_Sel, AV49TFLeaveRequestRejectionReason, AV50TFLeaveRequestRejectionReason_Sel, AV66checking, AV30IsAuthorized_Update, AV29IsAuthorized_Insert, AV34MsgVar, AV64Mesage) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV74Leaverequestsds_2_filterfulltext = AV19FilterFullText;
         AV75Leaverequestsds_3_tfleavetypename = AV55TFLeaveTypeName;
         AV76Leaverequestsds_4_tfleavetypename_sel = AV56TFLeaveTypeName_Sel;
         AV77Leaverequestsds_5_tfleaverequeststartdate = AV51TFLeaveRequestStartDate;
         AV78Leaverequestsds_6_tfleaverequeststartdate_to = AV52TFLeaveRequestStartDate_To;
         AV79Leaverequestsds_7_tfleaverequestenddate = AV47TFLeaveRequestEndDate;
         AV80Leaverequestsds_8_tfleaverequestenddate_to = AV48TFLeaveRequestEndDate_To;
         AV81Leaverequestsds_9_tfleaverequesthalfday = AV68TFLeaveRequestHalfDay;
         AV82Leaverequestsds_10_tfleaverequesthalfday_sel = AV69TFLeaveRequestHalfDay_Sel;
         AV83Leaverequestsds_11_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV84Leaverequestsds_12_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV85Leaverequestsds_13_tfleaverequeststatus_sels = AV53TFLeaveRequestStatus_Sels;
         AV86Leaverequestsds_14_tfleaverequestdescription = AV43TFLeaveRequestDescription;
         AV87Leaverequestsds_15_tfleaverequestdescription_sel = AV44TFLeaveRequestDescription_Sel;
         AV88Leaverequestsds_16_tfleaverequestrejectionreason = AV49TFLeaveRequestRejectionReason;
         AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel = AV50TFLeaveRequestRejectionReason_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV19FilterFullText, AV6ColumnsSelector, AV73Pgmname, AV55TFLeaveTypeName, AV56TFLeaveTypeName_Sel, AV51TFLeaveRequestStartDate, AV52TFLeaveRequestStartDate_To, AV47TFLeaveRequestEndDate, AV48TFLeaveRequestEndDate_To, AV68TFLeaveRequestHalfDay, AV69TFLeaveRequestHalfDay_Sel, AV45TFLeaveRequestDuration, AV46TFLeaveRequestDuration_To, AV53TFLeaveRequestStatus_Sels, AV43TFLeaveRequestDescription, AV44TFLeaveRequestDescription_Sel, AV49TFLeaveRequestRejectionReason, AV50TFLeaveRequestRejectionReason_Sel, AV66checking, AV30IsAuthorized_Update, AV29IsAuthorized_Insert, AV34MsgVar, AV64Mesage) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV74Leaverequestsds_2_filterfulltext = AV19FilterFullText;
         AV75Leaverequestsds_3_tfleavetypename = AV55TFLeaveTypeName;
         AV76Leaverequestsds_4_tfleavetypename_sel = AV56TFLeaveTypeName_Sel;
         AV77Leaverequestsds_5_tfleaverequeststartdate = AV51TFLeaveRequestStartDate;
         AV78Leaverequestsds_6_tfleaverequeststartdate_to = AV52TFLeaveRequestStartDate_To;
         AV79Leaverequestsds_7_tfleaverequestenddate = AV47TFLeaveRequestEndDate;
         AV80Leaverequestsds_8_tfleaverequestenddate_to = AV48TFLeaveRequestEndDate_To;
         AV81Leaverequestsds_9_tfleaverequesthalfday = AV68TFLeaveRequestHalfDay;
         AV82Leaverequestsds_10_tfleaverequesthalfday_sel = AV69TFLeaveRequestHalfDay_Sel;
         AV83Leaverequestsds_11_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV84Leaverequestsds_12_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV85Leaverequestsds_13_tfleaverequeststatus_sels = AV53TFLeaveRequestStatus_Sels;
         AV86Leaverequestsds_14_tfleaverequestdescription = AV43TFLeaveRequestDescription;
         AV87Leaverequestsds_15_tfleaverequestdescription_sel = AV44TFLeaveRequestDescription_Sel;
         AV88Leaverequestsds_16_tfleaverequestrejectionreason = AV49TFLeaveRequestRejectionReason;
         AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel = AV50TFLeaveRequestRejectionReason_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV19FilterFullText, AV6ColumnsSelector, AV73Pgmname, AV55TFLeaveTypeName, AV56TFLeaveTypeName_Sel, AV51TFLeaveRequestStartDate, AV52TFLeaveRequestStartDate_To, AV47TFLeaveRequestEndDate, AV48TFLeaveRequestEndDate_To, AV68TFLeaveRequestHalfDay, AV69TFLeaveRequestHalfDay_Sel, AV45TFLeaveRequestDuration, AV46TFLeaveRequestDuration_To, AV53TFLeaveRequestStatus_Sels, AV43TFLeaveRequestDescription, AV44TFLeaveRequestDescription_Sel, AV49TFLeaveRequestRejectionReason, AV50TFLeaveRequestRejectionReason_Sel, AV66checking, AV30IsAuthorized_Update, AV29IsAuthorized_Insert, AV34MsgVar, AV64Mesage) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV74Leaverequestsds_2_filterfulltext = AV19FilterFullText;
         AV75Leaverequestsds_3_tfleavetypename = AV55TFLeaveTypeName;
         AV76Leaverequestsds_4_tfleavetypename_sel = AV56TFLeaveTypeName_Sel;
         AV77Leaverequestsds_5_tfleaverequeststartdate = AV51TFLeaveRequestStartDate;
         AV78Leaverequestsds_6_tfleaverequeststartdate_to = AV52TFLeaveRequestStartDate_To;
         AV79Leaverequestsds_7_tfleaverequestenddate = AV47TFLeaveRequestEndDate;
         AV80Leaverequestsds_8_tfleaverequestenddate_to = AV48TFLeaveRequestEndDate_To;
         AV81Leaverequestsds_9_tfleaverequesthalfday = AV68TFLeaveRequestHalfDay;
         AV82Leaverequestsds_10_tfleaverequesthalfday_sel = AV69TFLeaveRequestHalfDay_Sel;
         AV83Leaverequestsds_11_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV84Leaverequestsds_12_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV85Leaverequestsds_13_tfleaverequeststatus_sels = AV53TFLeaveRequestStatus_Sels;
         AV86Leaverequestsds_14_tfleaverequestdescription = AV43TFLeaveRequestDescription;
         AV87Leaverequestsds_15_tfleaverequestdescription_sel = AV44TFLeaveRequestDescription_Sel;
         AV88Leaverequestsds_16_tfleaverequestrejectionreason = AV49TFLeaveRequestRejectionReason;
         AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel = AV50TFLeaveRequestRejectionReason_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV19FilterFullText, AV6ColumnsSelector, AV73Pgmname, AV55TFLeaveTypeName, AV56TFLeaveTypeName_Sel, AV51TFLeaveRequestStartDate, AV52TFLeaveRequestStartDate_To, AV47TFLeaveRequestEndDate, AV48TFLeaveRequestEndDate_To, AV68TFLeaveRequestHalfDay, AV69TFLeaveRequestHalfDay_Sel, AV45TFLeaveRequestDuration, AV46TFLeaveRequestDuration_To, AV53TFLeaveRequestStatus_Sels, AV43TFLeaveRequestDescription, AV44TFLeaveRequestDescription_Sel, AV49TFLeaveRequestRejectionReason, AV50TFLeaveRequestRejectionReason_Sel, AV66checking, AV30IsAuthorized_Update, AV29IsAuthorized_Insert, AV34MsgVar, AV64Mesage) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV74Leaverequestsds_2_filterfulltext = AV19FilterFullText;
         AV75Leaverequestsds_3_tfleavetypename = AV55TFLeaveTypeName;
         AV76Leaverequestsds_4_tfleavetypename_sel = AV56TFLeaveTypeName_Sel;
         AV77Leaverequestsds_5_tfleaverequeststartdate = AV51TFLeaveRequestStartDate;
         AV78Leaverequestsds_6_tfleaverequeststartdate_to = AV52TFLeaveRequestStartDate_To;
         AV79Leaverequestsds_7_tfleaverequestenddate = AV47TFLeaveRequestEndDate;
         AV80Leaverequestsds_8_tfleaverequestenddate_to = AV48TFLeaveRequestEndDate_To;
         AV81Leaverequestsds_9_tfleaverequesthalfday = AV68TFLeaveRequestHalfDay;
         AV82Leaverequestsds_10_tfleaverequesthalfday_sel = AV69TFLeaveRequestHalfDay_Sel;
         AV83Leaverequestsds_11_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV84Leaverequestsds_12_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV85Leaverequestsds_13_tfleaverequeststatus_sels = AV53TFLeaveRequestStatus_Sels;
         AV86Leaverequestsds_14_tfleaverequestdescription = AV43TFLeaveRequestDescription;
         AV87Leaverequestsds_15_tfleaverequestdescription_sel = AV44TFLeaveRequestDescription_Sel;
         AV88Leaverequestsds_16_tfleaverequestrejectionreason = AV49TFLeaveRequestRejectionReason;
         AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel = AV50TFLeaveRequestRejectionReason_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV35OrderedBy, AV37OrderedDsc, AV19FilterFullText, AV6ColumnsSelector, AV73Pgmname, AV55TFLeaveTypeName, AV56TFLeaveTypeName_Sel, AV51TFLeaveRequestStartDate, AV52TFLeaveRequestStartDate_To, AV47TFLeaveRequestEndDate, AV48TFLeaveRequestEndDate_To, AV68TFLeaveRequestHalfDay, AV69TFLeaveRequestHalfDay_Sel, AV45TFLeaveRequestDuration, AV46TFLeaveRequestDuration_To, AV53TFLeaveRequestStatus_Sels, AV43TFLeaveRequestDescription, AV44TFLeaveRequestDescription_Sel, AV49TFLeaveRequestRejectionReason, AV50TFLeaveRequestRejectionReason_Sel, AV66checking, AV30IsAuthorized_Update, AV29IsAuthorized_Insert, AV34MsgVar, AV64Mesage) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV73Pgmname = "LeaveRequests";
         edtavUseraction1_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtLeaveRequestId_Enabled = 0;
         edtLeaveTypeId_Enabled = 0;
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
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E164B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV18DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV6ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), ".", ","), 18, MidpointRounding.ToEven));
            AV23GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV24GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV22GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV15DDO_LeaveRequestStartDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTSTARTDATEAUXDATE"), 0);
            AV17DDO_LeaveRequestStartDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTSTARTDATEAUXDATETO"), 0);
            AV12DDO_LeaveRequestEndDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTENDDATEAUXDATE"), 0);
            AV14DDO_LeaveRequestEndDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_LEAVEREQUESTENDDATEAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
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
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Visible = StringUtil.StrToBool( cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Visible"));
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
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            /* Read variables values. */
            AV19FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            AV16DDO_LeaveRequestStartDateAuxDateText = cgiGet( edtavDdo_leaverequeststartdateauxdatetext_Internalname);
            AssignAttri("", false, "AV16DDO_LeaveRequestStartDateAuxDateText", AV16DDO_LeaveRequestStartDateAuxDateText);
            AV13DDO_LeaveRequestEndDateAuxDateText = cgiGet( edtavDdo_leaverequestenddateauxdatetext_Internalname);
            AssignAttri("", false, "AV13DDO_LeaveRequestEndDateAuxDateText", AV13DDO_LeaveRequestEndDateAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV35OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV37OrderedDsc )
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
         E164B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E164B2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV66checking = AV65GAMUser.checkrole("Manager");
         AssignAttri("", false, "AV66checking", AV66checking);
         GxWebStd.gx_hidden_field( context, "gxhash_vCHECKING", GetSecureSignedToken( "", AV66checking, context));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Mesage)) )
         {
            GX_msglist.addItem(AV64Mesage);
            AV64Mesage = "";
            AssignAttri("", false, "AV64Mesage", AV64Mesage);
            GxWebStd.gx_hidden_field( context, "gxhash_vMESAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Mesage, "")), context));
         }
         AV34MsgVar = "Leave Request Deleted.";
         AssignAttri("", false, "AV34MsgVar", AV34MsgVar);
         GxWebStd.gx_hidden_field( context, "gxhash_vMSGVAR", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34MsgVar, "")), context));
         this.executeUsercontrolMethod("", false, "TFLEAVEREQUESTENDDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_leaverequestenddateauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFLEAVEREQUESTSTARTDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_leaverequeststartdateauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV20GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " My Leave Requests";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV35OrderedBy < 1 )
         {
            AV35OrderedBy = 1;
            AssignAttri("", false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV18DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV18DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E174B2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV62WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV40Session.Get("LeaveRequestsColumnsSelector"), "") != 0 )
         {
            AV8ColumnsSelectorXML = AV40Session.Get("LeaveRequestsColumnsSelector");
            AV6ColumnsSelector.FromXml(AV8ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtLeaveTypeName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveTypeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveTypeName_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtLeaveRequestStartDate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestStartDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestStartDate_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtLeaveRequestEndDate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestEndDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestEndDate_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtLeaveRequestHalfDay_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestHalfDay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestHalfDay_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtLeaveRequestDuration_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestDuration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDuration_Visible), 5, 0), !bGXsfl_35_Refreshing);
         cmbLeaveRequestStatus.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbLeaveRequestStatus.Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtLeaveRequestDescription_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestDescription_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtLeaveRequestRejectionReason_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV6ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtLeaveRequestRejectionReason_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveRequestRejectionReason_Visible), 5, 0), !bGXsfl_35_Refreshing);
         AV23GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV23GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV23GridCurrentPage), 10, 0));
         AV24GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV24GridPageCount", StringUtil.LTrimStr( (decimal)(AV24GridPageCount), 10, 0));
         GXt_char2 = AV22GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV73Pgmname, out  GXt_char2) ;
         AV22GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV22GridAppliedFilters", AV22GridAppliedFilters);
         cmbLeaveRequestStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Columnheaderclass", cmbLeaveRequestStatus_Columnheaderclass, !bGXsfl_35_Refreshing);
         AV74Leaverequestsds_2_filterfulltext = AV19FilterFullText;
         AV75Leaverequestsds_3_tfleavetypename = AV55TFLeaveTypeName;
         AV76Leaverequestsds_4_tfleavetypename_sel = AV56TFLeaveTypeName_Sel;
         AV77Leaverequestsds_5_tfleaverequeststartdate = AV51TFLeaveRequestStartDate;
         AV78Leaverequestsds_6_tfleaverequeststartdate_to = AV52TFLeaveRequestStartDate_To;
         AV79Leaverequestsds_7_tfleaverequestenddate = AV47TFLeaveRequestEndDate;
         AV80Leaverequestsds_8_tfleaverequestenddate_to = AV48TFLeaveRequestEndDate_To;
         AV81Leaverequestsds_9_tfleaverequesthalfday = AV68TFLeaveRequestHalfDay;
         AV82Leaverequestsds_10_tfleaverequesthalfday_sel = AV69TFLeaveRequestHalfDay_Sel;
         AV83Leaverequestsds_11_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV84Leaverequestsds_12_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV85Leaverequestsds_13_tfleaverequeststatus_sels = AV53TFLeaveRequestStatus_Sels;
         AV86Leaverequestsds_14_tfleaverequestdescription = AV43TFLeaveRequestDescription;
         AV87Leaverequestsds_15_tfleaverequestdescription_sel = AV44TFLeaveRequestDescription_Sel;
         AV88Leaverequestsds_16_tfleaverequestrejectionreason = AV49TFLeaveRequestRejectionReason;
         AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel = AV50TFLeaveRequestRejectionReason_Sel;
         AV72Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6ColumnsSelector", AV6ColumnsSelector);
      }

      protected void E114B2( )
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
            AV38PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV38PageToGo) ;
         }
      }

      protected void E124B2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E134B2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV35OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
            AV37OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV37OrderedDsc", AV37OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
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
               AV55TFLeaveTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV55TFLeaveTypeName", AV55TFLeaveTypeName);
               AV56TFLeaveTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV56TFLeaveTypeName_Sel", AV56TFLeaveTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestStartDate") == 0 )
            {
               AV51TFLeaveRequestStartDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV51TFLeaveRequestStartDate", context.localUtil.Format(AV51TFLeaveRequestStartDate, "99/99/99"));
               AV52TFLeaveRequestStartDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV52TFLeaveRequestStartDate_To", context.localUtil.Format(AV52TFLeaveRequestStartDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestEndDate") == 0 )
            {
               AV47TFLeaveRequestEndDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV47TFLeaveRequestEndDate", context.localUtil.Format(AV47TFLeaveRequestEndDate, "99/99/99"));
               AV48TFLeaveRequestEndDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV48TFLeaveRequestEndDate_To", context.localUtil.Format(AV48TFLeaveRequestEndDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestHalfDay") == 0 )
            {
               AV68TFLeaveRequestHalfDay = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV68TFLeaveRequestHalfDay", AV68TFLeaveRequestHalfDay);
               AV69TFLeaveRequestHalfDay_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV69TFLeaveRequestHalfDay_Sel", AV69TFLeaveRequestHalfDay_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestDuration") == 0 )
            {
               AV45TFLeaveRequestDuration = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV45TFLeaveRequestDuration", StringUtil.LTrimStr( AV45TFLeaveRequestDuration, 4, 1));
               AV46TFLeaveRequestDuration_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV46TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV46TFLeaveRequestDuration_To, 4, 1));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestStatus") == 0 )
            {
               AV54TFLeaveRequestStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV54TFLeaveRequestStatus_SelsJson", AV54TFLeaveRequestStatus_SelsJson);
               AV53TFLeaveRequestStatus_Sels.FromJSonString(AV54TFLeaveRequestStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestDescription") == 0 )
            {
               AV43TFLeaveRequestDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFLeaveRequestDescription", AV43TFLeaveRequestDescription);
               AV44TFLeaveRequestDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFLeaveRequestDescription_Sel", AV44TFLeaveRequestDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LeaveRequestRejectionReason") == 0 )
            {
               AV49TFLeaveRequestRejectionReason = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV49TFLeaveRequestRejectionReason", AV49TFLeaveRequestRejectionReason);
               AV50TFLeaveRequestRejectionReason_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV50TFLeaveRequestRejectionReason_Sel", AV50TFLeaveRequestRejectionReason_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53TFLeaveRequestStatus_Sels", AV53TFLeaveRequestStatus_Sels);
      }

      private void E184B2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV60UserAction1 = "<i class=\"fas fa-xmark\"></i>";
         AssignAttri("", false, edtavUseraction1_Internalname, AV60UserAction1);
         if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 )
         {
            edtavUseraction1_Class = "Attribute";
         }
         else
         {
            edtavUseraction1_Class = "Invisible";
         }
         AV59Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV59Update);
         if ( AV30IsAuthorized_Update )
         {
            if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 )
            {
               edtavUpdate_Link = formatLink("leaverequest.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A127LeaveRequestId,10,0))}, new string[] {"Mode","LeaveRequestId"}) ;
               edtavUpdate_Class = "Attribute";
            }
            else
            {
               edtavUpdate_Link = "";
               edtavUpdate_Class = "Invisible";
            }
         }
         if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Pending") == 0 )
         {
            cmbLeaveRequestStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
         }
         else if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Approved") == 0 )
         {
            cmbLeaveRequestStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A132LeaveRequestStatus, "Rejected") == 0 )
         {
            cmbLeaveRequestStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else
         {
            cmbLeaveRequestStatus_Columnclass = "WWColumn";
         }
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
         /*  Sending Event outputs  */
      }

      protected void E144B2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV8ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV6ColumnsSelector.FromJSonString(AV8ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "LeaveRequestsColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV8ColumnsSelectorXML)) ? "" : AV6ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6ColumnsSelector", AV6ColumnsSelector);
      }

      protected void E154B2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV29IsAuthorized_Insert )
         {
            CallWebObject(formatLink("leaverequest.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","LeaveRequestId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6ColumnsSelector", AV6ColumnsSelector);
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV35OrderedBy), 4, 0))+":"+(AV37OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S162( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV6ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "LeaveTypeName",  "",  "Type Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "LeaveRequestStartDate",  "",  "Start Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "LeaveRequestEndDate",  "",  "End Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "LeaveRequestHalfDay",  "",  "Half Day",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "LeaveRequestDuration",  "",  "Request Duration",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "LeaveRequestStatus",  "",  "Request Status",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "LeaveRequestDescription",  "",  "Request Description",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV6ColumnsSelector,  "LeaveRequestRejectionReason",  "",  "Rejection Reason",  true,  "") ;
         GXt_char2 = AV61UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "LeaveRequestsColumnsSelector", out  GXt_char2) ;
         AV61UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61UserCustomValue)) ) )
         {
            AV7ColumnsSelectorAux.FromXml(AV61UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV7ColumnsSelectorAux, ref  AV6ColumnsSelector) ;
         }
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV30IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequest_Update", out  GXt_boolean3) ;
         AV30IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV30IsAuthorized_Update", AV30IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV30IsAuthorized_Update, context));
         if ( ! ( AV30IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_35_Refreshing);
         }
         GXt_boolean3 = AV29IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "leaverequest_Insert", out  GXt_boolean3) ;
         AV29IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV29IsAuthorized_Insert", AV29IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV29IsAuthorized_Insert, context));
         if ( ! ( AV29IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( ( AV66checking ) ) )
         {
            Ddo_gridcolumnsselector_Visible = false;
            ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "Visible", StringUtil.BoolToStr( Ddo_gridcolumnsselector_Visible));
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV73Pgmname+"GridState"), "") == 0 )
         {
            AV25GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV73Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV25GridState.FromXml(AV40Session.Get(AV73Pgmname+"GridState"), null, "", "");
         }
         AV35OrderedBy = AV25GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV35OrderedBy", StringUtil.LTrimStr( (decimal)(AV35OrderedBy), 4, 0));
         AV37OrderedDsc = AV25GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV37OrderedDsc", AV37OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV90GXV1 = 1;
         while ( AV90GXV1 <= AV25GridState.gxTpr_Filtervalues.Count )
         {
            AV26GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV25GridState.gxTpr_Filtervalues.Item(AV90GXV1));
            if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV55TFLeaveTypeName = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFLeaveTypeName", AV55TFLeaveTypeName);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV56TFLeaveTypeName_Sel = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFLeaveTypeName_Sel", AV56TFLeaveTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV51TFLeaveRequestStartDate = context.localUtil.CToD( AV26GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV51TFLeaveRequestStartDate", context.localUtil.Format(AV51TFLeaveRequestStartDate, "99/99/99"));
               AV52TFLeaveRequestStartDate_To = context.localUtil.CToD( AV26GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV52TFLeaveRequestStartDate_To", context.localUtil.Format(AV52TFLeaveRequestStartDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV47TFLeaveRequestEndDate = context.localUtil.CToD( AV26GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV47TFLeaveRequestEndDate", context.localUtil.Format(AV47TFLeaveRequestEndDate, "99/99/99"));
               AV48TFLeaveRequestEndDate_To = context.localUtil.CToD( AV26GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV48TFLeaveRequestEndDate_To", context.localUtil.Format(AV48TFLeaveRequestEndDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV68TFLeaveRequestHalfDay = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFLeaveRequestHalfDay", AV68TFLeaveRequestHalfDay);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV69TFLeaveRequestHalfDay_Sel = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69TFLeaveRequestHalfDay_Sel", AV69TFLeaveRequestHalfDay_Sel);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV45TFLeaveRequestDuration = NumberUtil.Val( AV26GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV45TFLeaveRequestDuration", StringUtil.LTrimStr( AV45TFLeaveRequestDuration, 4, 1));
               AV46TFLeaveRequestDuration_To = NumberUtil.Val( AV26GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV46TFLeaveRequestDuration_To", StringUtil.LTrimStr( AV46TFLeaveRequestDuration_To, 4, 1));
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTATUS_SEL") == 0 )
            {
               AV54TFLeaveRequestStatus_SelsJson = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFLeaveRequestStatus_SelsJson", AV54TFLeaveRequestStatus_SelsJson);
               AV53TFLeaveRequestStatus_Sels.FromJSonString(AV54TFLeaveRequestStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION") == 0 )
            {
               AV43TFLeaveRequestDescription = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFLeaveRequestDescription", AV43TFLeaveRequestDescription);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION_SEL") == 0 )
            {
               AV44TFLeaveRequestDescription_Sel = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFLeaveRequestDescription_Sel", AV44TFLeaveRequestDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTREJECTIONREASON") == 0 )
            {
               AV49TFLeaveRequestRejectionReason = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFLeaveRequestRejectionReason", AV49TFLeaveRequestRejectionReason);
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTREJECTIONREASON_SEL") == 0 )
            {
               AV50TFLeaveRequestRejectionReason_Sel = AV26GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFLeaveRequestRejectionReason_Sel", AV50TFLeaveRequestRejectionReason_Sel);
            }
            AV90GXV1 = (int)(AV90GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFLeaveTypeName_Sel)),  AV56TFLeaveTypeName_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV69TFLeaveRequestHalfDay_Sel)),  AV69TFLeaveRequestHalfDay_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  (AV53TFLeaveRequestStatus_Sels.Count==0),  AV54TFLeaveRequestStatus_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFLeaveRequestDescription_Sel)),  AV44TFLeaveRequestDescription_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFLeaveRequestRejectionReason_Sel)),  AV50TFLeaveRequestRejectionReason_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|||"+GXt_char4+"||"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFLeaveTypeName)),  AV55TFLeaveTypeName, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFLeaveRequestHalfDay)),  AV68TFLeaveRequestHalfDay, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFLeaveRequestDescription)),  AV43TFLeaveRequestDescription, out  GXt_char5) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFLeaveRequestRejectionReason)),  AV49TFLeaveRequestRejectionReason, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+((DateTime.MinValue==AV51TFLeaveRequestStartDate) ? "" : context.localUtil.DToC( AV51TFLeaveRequestStartDate, 2, "/"))+"|"+((DateTime.MinValue==AV47TFLeaveRequestEndDate) ? "" : context.localUtil.DToC( AV47TFLeaveRequestEndDate, 2, "/"))+"|"+GXt_char6+"|"+((Convert.ToDecimal(0)==AV45TFLeaveRequestDuration) ? "" : StringUtil.Str( AV45TFLeaveRequestDuration, 4, 1))+"||"+GXt_char5+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((DateTime.MinValue==AV52TFLeaveRequestStartDate_To) ? "" : context.localUtil.DToC( AV52TFLeaveRequestStartDate_To, 2, "/"))+"|"+((DateTime.MinValue==AV48TFLeaveRequestEndDate_To) ? "" : context.localUtil.DToC( AV48TFLeaveRequestEndDate_To, 2, "/"))+"||"+((Convert.ToDecimal(0)==AV46TFLeaveRequestDuration_To) ? "" : StringUtil.Str( AV46TFLeaveRequestDuration_To, 4, 1))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV25GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV25GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV25GridState.gxTpr_Currentpage) ;
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV25GridState.FromXml(AV40Session.Get(AV73Pgmname+"GridState"), null, "", "");
         AV25GridState.gxTpr_Orderedby = AV35OrderedBy;
         AV25GridState.gxTpr_Ordereddsc = AV37OrderedDsc;
         AV25GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)),  0,  AV19FilterFullText,  AV19FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV25GridState,  "TFLEAVETYPENAME",  "Type Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFLeaveTypeName)),  0,  AV55TFLeaveTypeName,  AV55TFLeaveTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFLeaveTypeName_Sel)),  AV56TFLeaveTypeName_Sel,  AV56TFLeaveTypeName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "TFLEAVEREQUESTSTARTDATE",  "Start Date",  !((DateTime.MinValue==AV51TFLeaveRequestStartDate)&&(DateTime.MinValue==AV52TFLeaveRequestStartDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV51TFLeaveRequestStartDate, 2, "/")),  ((DateTime.MinValue==AV51TFLeaveRequestStartDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV51TFLeaveRequestStartDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV52TFLeaveRequestStartDate_To, 2, "/")),  ((DateTime.MinValue==AV52TFLeaveRequestStartDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV52TFLeaveRequestStartDate_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "TFLEAVEREQUESTENDDATE",  "End Date",  !((DateTime.MinValue==AV47TFLeaveRequestEndDate)&&(DateTime.MinValue==AV48TFLeaveRequestEndDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV47TFLeaveRequestEndDate, 2, "/")),  ((DateTime.MinValue==AV47TFLeaveRequestEndDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV47TFLeaveRequestEndDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV48TFLeaveRequestEndDate_To, 2, "/")),  ((DateTime.MinValue==AV48TFLeaveRequestEndDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV48TFLeaveRequestEndDate_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV25GridState,  "TFLEAVEREQUESTHALFDAY",  "Half Day",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFLeaveRequestHalfDay)),  0,  AV68TFLeaveRequestHalfDay,  AV68TFLeaveRequestHalfDay,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV69TFLeaveRequestHalfDay_Sel)),  AV69TFLeaveRequestHalfDay_Sel,  AV69TFLeaveRequestHalfDay_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "TFLEAVEREQUESTDURATION",  "Request Duration",  !((Convert.ToDecimal(0)==AV45TFLeaveRequestDuration)&&(Convert.ToDecimal(0)==AV46TFLeaveRequestDuration_To)),  0,  StringUtil.Trim( StringUtil.Str( AV45TFLeaveRequestDuration, 4, 1)),  ((Convert.ToDecimal(0)==AV45TFLeaveRequestDuration) ? "" : StringUtil.Trim( context.localUtil.Format( AV45TFLeaveRequestDuration, "Z9.9"))),  true,  StringUtil.Trim( StringUtil.Str( AV46TFLeaveRequestDuration_To, 4, 1)),  ((Convert.ToDecimal(0)==AV46TFLeaveRequestDuration_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV46TFLeaveRequestDuration_To, "Z9.9")))) ;
         AV5AuxText = ((AV53TFLeaveRequestStatus_Sels.Count==1) ? "["+AV53TFLeaveRequestStatus_Sels.GetString(1)+"]" : "multiple values");
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV25GridState,  "TFLEAVEREQUESTSTATUS_SEL",  "Request Status",  !(AV53TFLeaveRequestStatus_Sels.Count==0),  0,  AV53TFLeaveRequestStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV5AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV5AuxText, "[Pending]", "Pending"), "[Approved]", "Approved"), "[Rejected]", "Rejected")),  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV25GridState,  "TFLEAVEREQUESTDESCRIPTION",  "Request Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFLeaveRequestDescription)),  0,  AV43TFLeaveRequestDescription,  AV43TFLeaveRequestDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFLeaveRequestDescription_Sel)),  AV44TFLeaveRequestDescription_Sel,  AV44TFLeaveRequestDescription_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV25GridState,  "TFLEAVEREQUESTREJECTIONREASON",  "Rejection Reason",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFLeaveRequestRejectionReason)),  0,  AV49TFLeaveRequestRejectionReason,  AV49TFLeaveRequestRejectionReason,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFLeaveRequestRejectionReason_Sel)),  AV50TFLeaveRequestRejectionReason_Sel,  AV50TFLeaveRequestRejectionReason_Sel) ;
         AV25GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV25GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV73Pgmname+"GridState",  AV25GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV57TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV57TrnContext.gxTpr_Callerobject = AV73Pgmname;
         AV57TrnContext.gxTpr_Callerondelete = true;
         AV57TrnContext.gxTpr_Callerurl = AV27HTTPRequest.ScriptName+"?"+AV27HTTPRequest.QueryString;
         AV57TrnContext.gxTpr_Transactionname = "LeaveRequest";
         AV40Session.Set("TrnContext", AV57TrnContext.ToXml(false, true, "", ""));
      }

      protected void E194B2( )
      {
         /* Useraction1_Click Routine */
         returnInSub = false;
         AV63LeaveRequest.Load(A127LeaveRequestId);
         AV63LeaveRequest.Delete();
         if ( AV63LeaveRequest.Success() )
         {
            context.CommitDataStores("leaverequests",pr_default);
            GX_msglist.addItem(AV34MsgVar);
            new sendleaverequestdeletionmail(context).executeSubmit(  A127LeaveRequestId) ;
         }
         else
         {
            GX_msglist.addItem("Delete Failed.");
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6ColumnsSelector", AV6ColumnsSelector);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV64Mesage = (string)getParm(obj,0);
         AssignAttri("", false, "AV64Mesage", AV64Mesage);
         GxWebStd.gx_hidden_field( context, "gxhash_vMESAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV64Mesage, "")), context));
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
         PA4B2( ) ;
         WS4B2( ) ;
         WE4B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025627529317", true, true);
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
         context.AddJavascriptSource("leaverequests.js", "?20256275293113", false, true);
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
         edtavUseraction1_Internalname = "vUSERACTION1_"+sGXsfl_35_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_35_idx;
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID_"+sGXsfl_35_idx;
         edtLeaveTypeId_Internalname = "LEAVETYPEID_"+sGXsfl_35_idx;
         edtLeaveTypeName_Internalname = "LEAVETYPENAME_"+sGXsfl_35_idx;
         edtLeaveRequestDate_Internalname = "LEAVEREQUESTDATE_"+sGXsfl_35_idx;
         edtLeaveRequestStartDate_Internalname = "LEAVEREQUESTSTARTDATE_"+sGXsfl_35_idx;
         edtLeaveRequestEndDate_Internalname = "LEAVEREQUESTENDDATE_"+sGXsfl_35_idx;
         edtLeaveRequestHalfDay_Internalname = "LEAVEREQUESTHALFDAY_"+sGXsfl_35_idx;
         edtLeaveRequestDuration_Internalname = "LEAVEREQUESTDURATION_"+sGXsfl_35_idx;
         cmbLeaveRequestStatus_Internalname = "LEAVEREQUESTSTATUS_"+sGXsfl_35_idx;
         edtLeaveRequestDescription_Internalname = "LEAVEREQUESTDESCRIPTION_"+sGXsfl_35_idx;
         edtLeaveRequestRejectionReason_Internalname = "LEAVEREQUESTREJECTIONREASON_"+sGXsfl_35_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         edtavUseraction1_Internalname = "vUSERACTION1_"+sGXsfl_35_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_35_fel_idx;
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID_"+sGXsfl_35_fel_idx;
         edtLeaveTypeId_Internalname = "LEAVETYPEID_"+sGXsfl_35_fel_idx;
         edtLeaveTypeName_Internalname = "LEAVETYPENAME_"+sGXsfl_35_fel_idx;
         edtLeaveRequestDate_Internalname = "LEAVEREQUESTDATE_"+sGXsfl_35_fel_idx;
         edtLeaveRequestStartDate_Internalname = "LEAVEREQUESTSTARTDATE_"+sGXsfl_35_fel_idx;
         edtLeaveRequestEndDate_Internalname = "LEAVEREQUESTENDDATE_"+sGXsfl_35_fel_idx;
         edtLeaveRequestHalfDay_Internalname = "LEAVEREQUESTHALFDAY_"+sGXsfl_35_fel_idx;
         edtLeaveRequestDuration_Internalname = "LEAVEREQUESTDURATION_"+sGXsfl_35_fel_idx;
         cmbLeaveRequestStatus_Internalname = "LEAVEREQUESTSTATUS_"+sGXsfl_35_fel_idx;
         edtLeaveRequestDescription_Internalname = "LEAVEREQUESTDESCRIPTION_"+sGXsfl_35_fel_idx;
         edtLeaveRequestRejectionReason_Internalname = "LEAVEREQUESTREJECTIONREASON_"+sGXsfl_35_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         WB4B0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = edtavUseraction1_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUseraction1_Internalname,StringUtil.RTrim( AV60UserAction1),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"","'"+""+"'"+",false,"+"'"+"EVUSERACTION1.CLICK."+sGXsfl_35_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUseraction1_Jsonclick,(short)5,(string)edtavUseraction1_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUseraction1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = edtavUpdate_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV59Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)edtavUpdate_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtLeaveTypeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveTypeName_Internalname,StringUtil.RTrim( A125LeaveTypeName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtLeaveTypeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtLeaveRequestStartDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestStartDate_Internalname,context.localUtil.Format(A129LeaveRequestStartDate, "99/99/99"),context.localUtil.Format( A129LeaveRequestStartDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestStartDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtLeaveRequestStartDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtLeaveRequestEndDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestEndDate_Internalname,context.localUtil.Format(A130LeaveRequestEndDate, "99/99/99"),context.localUtil.Format( A130LeaveRequestEndDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestEndDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtLeaveRequestEndDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtLeaveRequestHalfDay_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestHalfDay_Internalname,StringUtil.RTrim( A171LeaveRequestHalfDay),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestHalfDay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtLeaveRequestHalfDay_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtLeaveRequestDuration_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDuration_Internalname,StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", "")),StringUtil.LTrim( context.localUtil.Format( A131LeaveRequestDuration, "Z9.9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDuration_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtLeaveRequestDuration_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbLeaveRequestStatus.Visible==0) ? "display:none;" : "")+"\">") ;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbLeaveRequestStatus,(string)cmbLeaveRequestStatus_Internalname,StringUtil.RTrim( A132LeaveRequestStatus),(short)1,(string)cmbLeaveRequestStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbLeaveRequestStatus.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbLeaveRequestStatus_Columnclass,(string)cmbLeaveRequestStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbLeaveRequestStatus.CurrentValue = StringUtil.RTrim( A132LeaveRequestStatus);
            AssignProp("", false, cmbLeaveRequestStatus_Internalname, "Values", (string)(cmbLeaveRequestStatus.ToJavascriptSource()), !bGXsfl_35_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtLeaveRequestDescription_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestDescription_Internalname,(string)A133LeaveRequestDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtLeaveRequestDescription_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtLeaveRequestRejectionReason_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLeaveRequestRejectionReason_Internalname,(string)A134LeaveRequestRejectionReason,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLeaveRequestRejectionReason_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtLeaveRequestRejectionReason_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes4B2( ) ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUseraction1_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUpdate_Class+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveTypeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Type Name") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbLeaveRequestStatus.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Request Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestDescription_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Request Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtLeaveRequestRejectionReason_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Rejection Reason") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV60UserAction1)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUseraction1_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUseraction1_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV59Update)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUpdate_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A124LeaveTypeId), 10, 0, ".", ""))));
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
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestHalfDay_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A131LeaveRequestDuration, 4, 1, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestDuration_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A132LeaveRequestStatus)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbLeaveRequestStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbLeaveRequestStatus_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbLeaveRequestStatus.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A133LeaveRequestDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestDescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A134LeaveRequestRejectionReason));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLeaveRequestRejectionReason_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
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
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavUseraction1_Internalname = "vUSERACTION1";
         edtavUpdate_Internalname = "vUPDATE";
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID";
         edtLeaveTypeId_Internalname = "LEAVETYPEID";
         edtLeaveTypeName_Internalname = "LEAVETYPENAME";
         edtLeaveRequestDate_Internalname = "LEAVEREQUESTDATE";
         edtLeaveRequestStartDate_Internalname = "LEAVEREQUESTSTARTDATE";
         edtLeaveRequestEndDate_Internalname = "LEAVEREQUESTENDDATE";
         edtLeaveRequestHalfDay_Internalname = "LEAVEREQUESTHALFDAY";
         edtLeaveRequestDuration_Internalname = "LEAVEREQUESTDURATION";
         cmbLeaveRequestStatus_Internalname = "LEAVEREQUESTSTATUS";
         edtLeaveRequestDescription_Internalname = "LEAVEREQUESTDESCRIPTION";
         edtLeaveRequestRejectionReason_Internalname = "LEAVEREQUESTREJECTIONREASON";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
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
         edtEmployeeId_Jsonclick = "";
         edtLeaveRequestRejectionReason_Jsonclick = "";
         edtLeaveRequestDescription_Jsonclick = "";
         cmbLeaveRequestStatus_Jsonclick = "";
         cmbLeaveRequestStatus_Columnclass = "WWColumn";
         edtLeaveRequestDuration_Jsonclick = "";
         edtLeaveRequestHalfDay_Jsonclick = "";
         edtLeaveRequestEndDate_Jsonclick = "";
         edtLeaveRequestStartDate_Jsonclick = "";
         edtLeaveRequestDate_Jsonclick = "";
         edtLeaveTypeName_Jsonclick = "";
         edtLeaveTypeId_Jsonclick = "";
         edtLeaveRequestId_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Class = "Attribute";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 1;
         edtavUseraction1_Jsonclick = "";
         edtavUseraction1_Class = "Attribute";
         edtavUseraction1_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavUpdate_Visible = -1;
         cmbLeaveRequestStatus_Columnheaderclass = "";
         edtLeaveRequestRejectionReason_Visible = -1;
         edtLeaveRequestDescription_Visible = -1;
         cmbLeaveRequestStatus.Visible = -1;
         edtLeaveRequestDuration_Visible = -1;
         edtLeaveRequestHalfDay_Visible = -1;
         edtLeaveRequestEndDate_Visible = -1;
         edtLeaveRequestStartDate_Visible = -1;
         edtLeaveTypeName_Visible = -1;
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
         edtLeaveTypeId_Enabled = 0;
         edtLeaveRequestId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_leaverequestenddateauxdatetext_Jsonclick = "";
         edtavDdo_leaverequeststartdateauxdatetext_Jsonclick = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Visible = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "||||4.1|||";
         Ddo_grid_Datalistproc = "LeaveRequestsGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||Pending:Pending,Approved:Approved,Rejected:Rejected||";
         Ddo_grid_Allowmultipleselection = "|||||T||";
         Ddo_grid_Datalisttype = "Dynamic|||Dynamic||FixedValues|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T|||T||T|T|T";
         Ddo_grid_Filterisrange = "|P|P||T|||";
         Ddo_grid_Filtertype = "Character|Date|Date|Character|Numeric||Character|Character";
         Ddo_grid_Includefilter = "T|T|T|T|T||T|T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8|9";
         Ddo_grid_Columnids = "4:LeaveTypeName|6:LeaveRequestStartDate|7:LeaveRequestEndDate|8:LeaveRequestHalfDay|9:LeaveRequestDuration|10:LeaveRequestStatus|11:LeaveRequestDescription|12:LeaveRequestRejectionReason";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "No requested leaves";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " My Leave Requests";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV55TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV56TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV51TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV52TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV47TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV48TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV68TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV69TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV45TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV46TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV53TFLeaveRequestStatus_Sels","fld":"vTFLEAVEREQUESTSTATUS_SELS"},{"av":"AV43TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV44TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV49TFLeaveRequestRejectionReason","fld":"vTFLEAVEREQUESTREJECTIONREASON"},{"av":"AV50TFLeaveRequestRejectionReason_Sel","fld":"vTFLEAVEREQUESTREJECTIONREASON_SEL"},{"av":"AV66checking","fld":"vCHECKING","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV34MsgVar","fld":"vMSGVAR","hsh":true},{"av":"AV64Mesage","fld":"vMESAGE","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtLeaveTypeName_Visible","ctrl":"LEAVETYPENAME","prop":"Visible"},{"av":"edtLeaveRequestStartDate_Visible","ctrl":"LEAVEREQUESTSTARTDATE","prop":"Visible"},{"av":"edtLeaveRequestEndDate_Visible","ctrl":"LEAVEREQUESTENDDATE","prop":"Visible"},{"av":"edtLeaveRequestHalfDay_Visible","ctrl":"LEAVEREQUESTHALFDAY","prop":"Visible"},{"av":"edtLeaveRequestDuration_Visible","ctrl":"LEAVEREQUESTDURATION","prop":"Visible"},{"av":"cmbLeaveRequestStatus"},{"av":"edtLeaveRequestDescription_Visible","ctrl":"LEAVEREQUESTDESCRIPTION","prop":"Visible"},{"av":"edtLeaveRequestRejectionReason_Visible","ctrl":"LEAVEREQUESTREJECTIONREASON","prop":"Visible"},{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV22GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"Ddo_gridcolumnsselector_Visible","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"Visible"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E114B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV55TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV56TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV51TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV52TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV47TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV48TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV68TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV69TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV45TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV46TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV53TFLeaveRequestStatus_Sels","fld":"vTFLEAVEREQUESTSTATUS_SELS"},{"av":"AV43TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV44TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV49TFLeaveRequestRejectionReason","fld":"vTFLEAVEREQUESTREJECTIONREASON"},{"av":"AV50TFLeaveRequestRejectionReason_Sel","fld":"vTFLEAVEREQUESTREJECTIONREASON_SEL"},{"av":"AV66checking","fld":"vCHECKING","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV34MsgVar","fld":"vMSGVAR","hsh":true},{"av":"AV64Mesage","fld":"vMESAGE","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E124B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV55TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV56TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV51TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV52TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV47TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV48TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV68TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV69TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV45TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV46TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV53TFLeaveRequestStatus_Sels","fld":"vTFLEAVEREQUESTSTATUS_SELS"},{"av":"AV43TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV44TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV49TFLeaveRequestRejectionReason","fld":"vTFLEAVEREQUESTREJECTIONREASON"},{"av":"AV50TFLeaveRequestRejectionReason_Sel","fld":"vTFLEAVEREQUESTREJECTIONREASON_SEL"},{"av":"AV66checking","fld":"vCHECKING","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV34MsgVar","fld":"vMSGVAR","hsh":true},{"av":"AV64Mesage","fld":"vMESAGE","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E134B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV55TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV56TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV51TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV52TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV47TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV48TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV68TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV69TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV45TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV46TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV53TFLeaveRequestStatus_Sels","fld":"vTFLEAVEREQUESTSTATUS_SELS"},{"av":"AV43TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV44TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV49TFLeaveRequestRejectionReason","fld":"vTFLEAVEREQUESTREJECTIONREASON"},{"av":"AV50TFLeaveRequestRejectionReason_Sel","fld":"vTFLEAVEREQUESTREJECTIONREASON_SEL"},{"av":"AV66checking","fld":"vCHECKING","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV34MsgVar","fld":"vMSGVAR","hsh":true},{"av":"AV64Mesage","fld":"vMESAGE","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV49TFLeaveRequestRejectionReason","fld":"vTFLEAVEREQUESTREJECTIONREASON"},{"av":"AV50TFLeaveRequestRejectionReason_Sel","fld":"vTFLEAVEREQUESTREJECTIONREASON_SEL"},{"av":"AV43TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV44TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV54TFLeaveRequestStatus_SelsJson","fld":"vTFLEAVEREQUESTSTATUS_SELSJSON"},{"av":"AV53TFLeaveRequestStatus_Sels","fld":"vTFLEAVEREQUESTSTATUS_SELS"},{"av":"AV45TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV46TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV68TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV69TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV47TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV48TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV51TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV52TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV55TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV56TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E184B2","iparms":[{"av":"cmbLeaveRequestStatus"},{"av":"A132LeaveRequestStatus","fld":"LEAVEREQUESTSTATUS"},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV60UserAction1","fld":"vUSERACTION1"},{"av":"edtavUseraction1_Class","ctrl":"vUSERACTION1","prop":"Class"},{"av":"AV59Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"edtavUpdate_Class","ctrl":"vUPDATE","prop":"Class"},{"av":"cmbLeaveRequestStatus"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E144B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV55TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV56TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV51TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV52TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV47TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV48TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV68TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV69TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV45TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV46TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV53TFLeaveRequestStatus_Sels","fld":"vTFLEAVEREQUESTSTATUS_SELS"},{"av":"AV43TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV44TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV49TFLeaveRequestRejectionReason","fld":"vTFLEAVEREQUESTREJECTIONREASON"},{"av":"AV50TFLeaveRequestRejectionReason_Sel","fld":"vTFLEAVEREQUESTREJECTIONREASON_SEL"},{"av":"AV66checking","fld":"vCHECKING","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV34MsgVar","fld":"vMSGVAR","hsh":true},{"av":"AV64Mesage","fld":"vMESAGE","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtLeaveTypeName_Visible","ctrl":"LEAVETYPENAME","prop":"Visible"},{"av":"edtLeaveRequestStartDate_Visible","ctrl":"LEAVEREQUESTSTARTDATE","prop":"Visible"},{"av":"edtLeaveRequestEndDate_Visible","ctrl":"LEAVEREQUESTENDDATE","prop":"Visible"},{"av":"edtLeaveRequestHalfDay_Visible","ctrl":"LEAVEREQUESTHALFDAY","prop":"Visible"},{"av":"edtLeaveRequestDuration_Visible","ctrl":"LEAVEREQUESTDURATION","prop":"Visible"},{"av":"cmbLeaveRequestStatus"},{"av":"edtLeaveRequestDescription_Visible","ctrl":"LEAVEREQUESTDESCRIPTION","prop":"Visible"},{"av":"edtLeaveRequestRejectionReason_Visible","ctrl":"LEAVEREQUESTREJECTIONREASON","prop":"Visible"},{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV22GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"Ddo_gridcolumnsselector_Visible","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"Visible"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E154B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV55TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV56TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV51TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV52TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV47TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV48TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV68TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV69TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV45TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV46TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV53TFLeaveRequestStatus_Sels","fld":"vTFLEAVEREQUESTSTATUS_SELS"},{"av":"AV43TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV44TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV49TFLeaveRequestRejectionReason","fld":"vTFLEAVEREQUESTREJECTIONREASON"},{"av":"AV50TFLeaveRequestRejectionReason_Sel","fld":"vTFLEAVEREQUESTREJECTIONREASON_SEL"},{"av":"AV66checking","fld":"vCHECKING","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV34MsgVar","fld":"vMSGVAR","hsh":true},{"av":"AV64Mesage","fld":"vMESAGE","hsh":true},{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtLeaveTypeName_Visible","ctrl":"LEAVETYPENAME","prop":"Visible"},{"av":"edtLeaveRequestStartDate_Visible","ctrl":"LEAVEREQUESTSTARTDATE","prop":"Visible"},{"av":"edtLeaveRequestEndDate_Visible","ctrl":"LEAVEREQUESTENDDATE","prop":"Visible"},{"av":"edtLeaveRequestHalfDay_Visible","ctrl":"LEAVEREQUESTHALFDAY","prop":"Visible"},{"av":"edtLeaveRequestDuration_Visible","ctrl":"LEAVEREQUESTDURATION","prop":"Visible"},{"av":"cmbLeaveRequestStatus"},{"av":"edtLeaveRequestDescription_Visible","ctrl":"LEAVEREQUESTDESCRIPTION","prop":"Visible"},{"av":"edtLeaveRequestRejectionReason_Visible","ctrl":"LEAVEREQUESTREJECTIONREASON","prop":"Visible"},{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV22GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"Ddo_gridcolumnsselector_Visible","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"Visible"}]}""");
         setEventMetadata("VUSERACTION1.CLICK","""{"handler":"E194B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV35OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV37OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV55TFLeaveTypeName","fld":"vTFLEAVETYPENAME"},{"av":"AV56TFLeaveTypeName_Sel","fld":"vTFLEAVETYPENAME_SEL"},{"av":"AV51TFLeaveRequestStartDate","fld":"vTFLEAVEREQUESTSTARTDATE"},{"av":"AV52TFLeaveRequestStartDate_To","fld":"vTFLEAVEREQUESTSTARTDATE_TO"},{"av":"AV47TFLeaveRequestEndDate","fld":"vTFLEAVEREQUESTENDDATE"},{"av":"AV48TFLeaveRequestEndDate_To","fld":"vTFLEAVEREQUESTENDDATE_TO"},{"av":"AV68TFLeaveRequestHalfDay","fld":"vTFLEAVEREQUESTHALFDAY"},{"av":"AV69TFLeaveRequestHalfDay_Sel","fld":"vTFLEAVEREQUESTHALFDAY_SEL"},{"av":"AV45TFLeaveRequestDuration","fld":"vTFLEAVEREQUESTDURATION","pic":"Z9.9"},{"av":"AV46TFLeaveRequestDuration_To","fld":"vTFLEAVEREQUESTDURATION_TO","pic":"Z9.9"},{"av":"AV53TFLeaveRequestStatus_Sels","fld":"vTFLEAVEREQUESTSTATUS_SELS"},{"av":"AV43TFLeaveRequestDescription","fld":"vTFLEAVEREQUESTDESCRIPTION"},{"av":"AV44TFLeaveRequestDescription_Sel","fld":"vTFLEAVEREQUESTDESCRIPTION_SEL"},{"av":"AV49TFLeaveRequestRejectionReason","fld":"vTFLEAVEREQUESTREJECTIONREASON"},{"av":"AV50TFLeaveRequestRejectionReason_Sel","fld":"vTFLEAVEREQUESTREJECTIONREASON_SEL"},{"av":"AV66checking","fld":"vCHECKING","hsh":true},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"AV34MsgVar","fld":"vMSGVAR","hsh":true},{"av":"AV64Mesage","fld":"vMESAGE","hsh":true},{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("VUSERACTION1.CLICK",""","oparms":[{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9"},{"av":"AV6ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtLeaveTypeName_Visible","ctrl":"LEAVETYPENAME","prop":"Visible"},{"av":"edtLeaveRequestStartDate_Visible","ctrl":"LEAVEREQUESTSTARTDATE","prop":"Visible"},{"av":"edtLeaveRequestEndDate_Visible","ctrl":"LEAVEREQUESTENDDATE","prop":"Visible"},{"av":"edtLeaveRequestHalfDay_Visible","ctrl":"LEAVEREQUESTHALFDAY","prop":"Visible"},{"av":"edtLeaveRequestDuration_Visible","ctrl":"LEAVEREQUESTDURATION","prop":"Visible"},{"av":"cmbLeaveRequestStatus"},{"av":"edtLeaveRequestDescription_Visible","ctrl":"LEAVEREQUESTDESCRIPTION","prop":"Visible"},{"av":"edtLeaveRequestRejectionReason_Visible","ctrl":"LEAVEREQUESTREJECTIONREASON","prop":"Visible"},{"av":"AV23GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV24GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV22GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV30IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV29IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"Ddo_gridcolumnsselector_Visible","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"Visible"}]}""");
         setEventMetadata("VALID_LEAVETYPEID","""{"handler":"Valid_Leavetypeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Employeeid","iparms":[]}""");
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
         wcpOAV64Mesage = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV19FilterFullText = "";
         AV6ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV73Pgmname = "";
         AV55TFLeaveTypeName = "";
         AV56TFLeaveTypeName_Sel = "";
         AV51TFLeaveRequestStartDate = DateTime.MinValue;
         AV52TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV47TFLeaveRequestEndDate = DateTime.MinValue;
         AV48TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV68TFLeaveRequestHalfDay = "";
         AV69TFLeaveRequestHalfDay_Sel = "";
         AV53TFLeaveRequestStatus_Sels = new GxSimpleCollection<string>();
         AV43TFLeaveRequestDescription = "";
         AV44TFLeaveRequestDescription_Sel = "";
         AV49TFLeaveRequestRejectionReason = "";
         AV50TFLeaveRequestRejectionReason_Sel = "";
         AV34MsgVar = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22GridAppliedFilters = "";
         AV18DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15DDO_LeaveRequestStartDateAuxDate = DateTime.MinValue;
         AV17DDO_LeaveRequestStartDateAuxDateTo = DateTime.MinValue;
         AV12DDO_LeaveRequestEndDateAuxDate = DateTime.MinValue;
         AV14DDO_LeaveRequestEndDateAuxDateTo = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
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
         bttBtneditcolumns_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV16DDO_LeaveRequestStartDateAuxDateText = "";
         ucTfleaverequeststartdate_rangepicker = new GXUserControl();
         AV13DDO_LeaveRequestEndDateAuxDateText = "";
         ucTfleaverequestenddate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV60UserAction1 = "";
         AV59Update = "";
         A125LeaveTypeName = "";
         A128LeaveRequestDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A171LeaveRequestHalfDay = "";
         A132LeaveRequestStatus = "";
         A133LeaveRequestDescription = "";
         A134LeaveRequestRejectionReason = "";
         AV85Leaverequestsds_13_tfleaverequeststatus_sels = new GxSimpleCollection<string>();
         lV74Leaverequestsds_2_filterfulltext = "";
         lV75Leaverequestsds_3_tfleavetypename = "";
         lV81Leaverequestsds_9_tfleaverequesthalfday = "";
         lV86Leaverequestsds_14_tfleaverequestdescription = "";
         lV88Leaverequestsds_16_tfleaverequestrejectionreason = "";
         AV74Leaverequestsds_2_filterfulltext = "";
         AV76Leaverequestsds_4_tfleavetypename_sel = "";
         AV75Leaverequestsds_3_tfleavetypename = "";
         AV77Leaverequestsds_5_tfleaverequeststartdate = DateTime.MinValue;
         AV78Leaverequestsds_6_tfleaverequeststartdate_to = DateTime.MinValue;
         AV79Leaverequestsds_7_tfleaverequestenddate = DateTime.MinValue;
         AV80Leaverequestsds_8_tfleaverequestenddate_to = DateTime.MinValue;
         AV82Leaverequestsds_10_tfleaverequesthalfday_sel = "";
         AV81Leaverequestsds_9_tfleaverequesthalfday = "";
         AV87Leaverequestsds_15_tfleaverequestdescription_sel = "";
         AV86Leaverequestsds_14_tfleaverequestdescription = "";
         AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel = "";
         AV88Leaverequestsds_16_tfleaverequestrejectionreason = "";
         H004B2_A106EmployeeId = new long[1] ;
         H004B2_A134LeaveRequestRejectionReason = new string[] {""} ;
         H004B2_A133LeaveRequestDescription = new string[] {""} ;
         H004B2_A132LeaveRequestStatus = new string[] {""} ;
         H004B2_A131LeaveRequestDuration = new decimal[1] ;
         H004B2_A171LeaveRequestHalfDay = new string[] {""} ;
         H004B2_n171LeaveRequestHalfDay = new bool[] {false} ;
         H004B2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         H004B2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         H004B2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         H004B2_A125LeaveTypeName = new string[] {""} ;
         H004B2_A124LeaveTypeId = new long[1] ;
         H004B2_A127LeaveRequestId = new long[1] ;
         H004B3_AGRID_nRecordCount = new long[1] ;
         AV65GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV20GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV62WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV8ColumnsSelectorXML = "";
         AV54TFLeaveRequestStatus_SelsJson = "";
         GridRow = new GXWebRow();
         AV61UserCustomValue = "";
         AV7ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV25GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV26GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV5AuxText = "";
         AV57TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV27HTTPRequest = new GxHttpRequest( context);
         AV63LeaveRequest = new SdtLeaveRequest(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.leaverequests__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequests__default(),
            new Object[][] {
                new Object[] {
               H004B2_A106EmployeeId, H004B2_A134LeaveRequestRejectionReason, H004B2_A133LeaveRequestDescription, H004B2_A132LeaveRequestStatus, H004B2_A131LeaveRequestDuration, H004B2_A171LeaveRequestHalfDay, H004B2_n171LeaveRequestHalfDay, H004B2_A130LeaveRequestEndDate, H004B2_A129LeaveRequestStartDate, H004B2_A128LeaveRequestDate,
               H004B2_A125LeaveTypeName, H004B2_A124LeaveTypeId, H004B2_A127LeaveRequestId
               }
               , new Object[] {
               H004B3_AGRID_nRecordCount
               }
            }
         );
         AV73Pgmname = "LeaveRequests";
         /* GeneXus formulas. */
         AV73Pgmname = "LeaveRequests";
         edtavUseraction1_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV35OrderedBy ;
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
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUseraction1_Enabled ;
      private int edtavUpdate_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV85Leaverequestsds_13_tfleaverequeststatus_sels_Count ;
      private int edtLeaveRequestId_Enabled ;
      private int edtLeaveTypeId_Enabled ;
      private int edtLeaveTypeName_Enabled ;
      private int edtLeaveRequestDate_Enabled ;
      private int edtLeaveRequestStartDate_Enabled ;
      private int edtLeaveRequestEndDate_Enabled ;
      private int edtLeaveRequestHalfDay_Enabled ;
      private int edtLeaveRequestDuration_Enabled ;
      private int edtLeaveRequestDescription_Enabled ;
      private int edtLeaveRequestRejectionReason_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtLeaveTypeName_Visible ;
      private int edtLeaveRequestStartDate_Visible ;
      private int edtLeaveRequestEndDate_Visible ;
      private int edtLeaveRequestHalfDay_Visible ;
      private int edtLeaveRequestDuration_Visible ;
      private int edtLeaveRequestDescription_Visible ;
      private int edtLeaveRequestRejectionReason_Visible ;
      private int AV38PageToGo ;
      private int edtavUpdate_Visible ;
      private int AV90GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV23GridCurrentPage ;
      private long AV24GridPageCount ;
      private long A127LeaveRequestId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long GRID_nCurrentRecord ;
      private long AV72Udparg1 ;
      private long GRID_nRecordCount ;
      private decimal AV45TFLeaveRequestDuration ;
      private decimal AV46TFLeaveRequestDuration_To ;
      private decimal A131LeaveRequestDuration ;
      private decimal AV83Leaverequestsds_11_tfleaverequestduration ;
      private decimal AV84Leaverequestsds_12_tfleaverequestduration_to ;
      private string AV64Mesage ;
      private string wcpOAV64Mesage ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_35_idx="0001" ;
      private string AV73Pgmname ;
      private string AV55TFLeaveTypeName ;
      private string AV56TFLeaveTypeName_Sel ;
      private string AV68TFLeaveRequestHalfDay ;
      private string AV69TFLeaveRequestHalfDay_Sel ;
      private string AV34MsgVar ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
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
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
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
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV60UserAction1 ;
      private string edtavUseraction1_Internalname ;
      private string AV59Update ;
      private string edtavUpdate_Internalname ;
      private string edtLeaveRequestId_Internalname ;
      private string edtLeaveTypeId_Internalname ;
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
      private string lV75Leaverequestsds_3_tfleavetypename ;
      private string lV81Leaverequestsds_9_tfleaverequesthalfday ;
      private string AV76Leaverequestsds_4_tfleavetypename_sel ;
      private string AV75Leaverequestsds_3_tfleavetypename ;
      private string AV82Leaverequestsds_10_tfleaverequesthalfday_sel ;
      private string AV81Leaverequestsds_9_tfleaverequesthalfday ;
      private string cmbLeaveRequestStatus_Columnheaderclass ;
      private string edtavUseraction1_Class ;
      private string edtavUpdate_Link ;
      private string edtavUpdate_Class ;
      private string cmbLeaveRequestStatus_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUseraction1_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtLeaveRequestId_Jsonclick ;
      private string edtLeaveTypeId_Jsonclick ;
      private string edtLeaveTypeName_Jsonclick ;
      private string edtLeaveRequestDate_Jsonclick ;
      private string edtLeaveRequestStartDate_Jsonclick ;
      private string edtLeaveRequestEndDate_Jsonclick ;
      private string edtLeaveRequestHalfDay_Jsonclick ;
      private string edtLeaveRequestDuration_Jsonclick ;
      private string GXCCtl ;
      private string cmbLeaveRequestStatus_Jsonclick ;
      private string edtLeaveRequestDescription_Jsonclick ;
      private string edtLeaveRequestRejectionReason_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV51TFLeaveRequestStartDate ;
      private DateTime AV52TFLeaveRequestStartDate_To ;
      private DateTime AV47TFLeaveRequestEndDate ;
      private DateTime AV48TFLeaveRequestEndDate_To ;
      private DateTime AV15DDO_LeaveRequestStartDateAuxDate ;
      private DateTime AV17DDO_LeaveRequestStartDateAuxDateTo ;
      private DateTime AV12DDO_LeaveRequestEndDateAuxDate ;
      private DateTime AV14DDO_LeaveRequestEndDateAuxDateTo ;
      private DateTime A128LeaveRequestDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime AV77Leaverequestsds_5_tfleaverequeststartdate ;
      private DateTime AV78Leaverequestsds_6_tfleaverequeststartdate_to ;
      private DateTime AV79Leaverequestsds_7_tfleaverequestenddate ;
      private DateTime AV80Leaverequestsds_8_tfleaverequestenddate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV37OrderedDsc ;
      private bool AV66checking ;
      private bool AV30IsAuthorized_Update ;
      private bool AV29IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Ddo_gridcolumnsselector_Visible ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n171LeaveRequestHalfDay ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean3 ;
      private string AV8ColumnsSelectorXML ;
      private string AV54TFLeaveRequestStatus_SelsJson ;
      private string AV61UserCustomValue ;
      private string AV19FilterFullText ;
      private string AV43TFLeaveRequestDescription ;
      private string AV44TFLeaveRequestDescription_Sel ;
      private string AV49TFLeaveRequestRejectionReason ;
      private string AV50TFLeaveRequestRejectionReason_Sel ;
      private string AV22GridAppliedFilters ;
      private string AV16DDO_LeaveRequestStartDateAuxDateText ;
      private string AV13DDO_LeaveRequestEndDateAuxDateText ;
      private string A133LeaveRequestDescription ;
      private string A134LeaveRequestRejectionReason ;
      private string lV74Leaverequestsds_2_filterfulltext ;
      private string lV86Leaverequestsds_14_tfleaverequestdescription ;
      private string lV88Leaverequestsds_16_tfleaverequestrejectionreason ;
      private string AV74Leaverequestsds_2_filterfulltext ;
      private string AV87Leaverequestsds_15_tfleaverequestdescription_sel ;
      private string AV86Leaverequestsds_14_tfleaverequestdescription ;
      private string AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel ;
      private string AV88Leaverequestsds_16_tfleaverequestrejectionreason ;
      private string AV5AuxText ;
      private IGxSession AV40Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfleaverequeststartdate_rangepicker ;
      private GXUserControl ucTfleaverequestenddate_rangepicker ;
      private GxHttpRequest AV27HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbLeaveRequestStatus ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV6ColumnsSelector ;
      private GxSimpleCollection<string> AV53TFLeaveRequestStatus_Sels ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV18DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV85Leaverequestsds_13_tfleaverequeststatus_sels ;
      private IDataStoreProvider pr_default ;
      private long[] H004B2_A106EmployeeId ;
      private string[] H004B2_A134LeaveRequestRejectionReason ;
      private string[] H004B2_A133LeaveRequestDescription ;
      private string[] H004B2_A132LeaveRequestStatus ;
      private decimal[] H004B2_A131LeaveRequestDuration ;
      private string[] H004B2_A171LeaveRequestHalfDay ;
      private bool[] H004B2_n171LeaveRequestHalfDay ;
      private DateTime[] H004B2_A130LeaveRequestEndDate ;
      private DateTime[] H004B2_A129LeaveRequestStartDate ;
      private DateTime[] H004B2_A128LeaveRequestDate ;
      private string[] H004B2_A125LeaveTypeName ;
      private long[] H004B2_A124LeaveTypeId ;
      private long[] H004B2_A127LeaveRequestId ;
      private long[] H004B3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV65GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV20GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV62WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV7ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV25GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV26GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV57TrnContext ;
      private SdtLeaveRequest AV63LeaveRequest ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class leaverequests__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class leaverequests__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H004B2( IGxContext context ,
                                           string A132LeaveRequestStatus ,
                                           GxSimpleCollection<string> AV85Leaverequestsds_13_tfleaverequeststatus_sels ,
                                           string AV74Leaverequestsds_2_filterfulltext ,
                                           string AV76Leaverequestsds_4_tfleavetypename_sel ,
                                           string AV75Leaverequestsds_3_tfleavetypename ,
                                           DateTime AV77Leaverequestsds_5_tfleaverequeststartdate ,
                                           DateTime AV78Leaverequestsds_6_tfleaverequeststartdate_to ,
                                           DateTime AV79Leaverequestsds_7_tfleaverequestenddate ,
                                           DateTime AV80Leaverequestsds_8_tfleaverequestenddate_to ,
                                           string AV82Leaverequestsds_10_tfleaverequesthalfday_sel ,
                                           string AV81Leaverequestsds_9_tfleaverequesthalfday ,
                                           decimal AV83Leaverequestsds_11_tfleaverequestduration ,
                                           decimal AV84Leaverequestsds_12_tfleaverequestduration_to ,
                                           int AV85Leaverequestsds_13_tfleaverequeststatus_sels_Count ,
                                           string AV87Leaverequestsds_15_tfleaverequestdescription_sel ,
                                           string AV86Leaverequestsds_14_tfleaverequestdescription ,
                                           string AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel ,
                                           string AV88Leaverequestsds_16_tfleaverequestrejectionreason ,
                                           string A125LeaveTypeName ,
                                           string A171LeaveRequestHalfDay ,
                                           decimal A131LeaveRequestDuration ,
                                           string A133LeaveRequestDescription ,
                                           string A134LeaveRequestRejectionReason ,
                                           DateTime A129LeaveRequestStartDate ,
                                           DateTime A130LeaveRequestEndDate ,
                                           short AV35OrderedBy ,
                                           bool AV37OrderedDsc ,
                                           long A106EmployeeId ,
                                           long AV72Udparg1 )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int8 = new short[26];
       Object[] GXv_Object9 = new Object[2];
       string sSelectString;
       string sFromString;
       string sOrderString;
       sSelectString = " T1.EmployeeId, T1.LeaveRequestRejectionReason, T1.LeaveRequestDescription, T1.LeaveRequestStatus, T1.LeaveRequestDuration, T1.LeaveRequestHalfDay, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDate, T2.LeaveTypeName, T1.LeaveTypeId, T1.LeaveRequestId";
       sFromString = " FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
       sOrderString = "";
       AddWhere(sWhereString, "(T1.EmployeeId = :AV72Udparg1)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext)) )
       {
          AddWhere(sWhereString, "(( T2.LeaveTypeName like '%' || :lV74Leaverequestsds_2_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV74Leaverequestsds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV74Leaverequestsds_2_filterfulltext) or ( 'pending' like '%' || LOWER(:lV74Leaverequestsds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV74Leaverequestsds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV74Leaverequestsds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( T1.LeaveRequestDescription like '%' || :lV74Leaverequestsds_2_filterfulltext) or ( T1.LeaveRequestRejectionReason like '%' || :lV74Leaverequestsds_2_filterfulltext))");
       }
       else
       {
          GXv_int8[1] = 1;
          GXv_int8[2] = 1;
          GXv_int8[3] = 1;
          GXv_int8[4] = 1;
          GXv_int8[5] = 1;
          GXv_int8[6] = 1;
          GXv_int8[7] = 1;
          GXv_int8[8] = 1;
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Leaverequestsds_4_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Leaverequestsds_3_tfleavetypename)) ) )
       {
          AddWhere(sWhereString, "(T2.LeaveTypeName like :lV75Leaverequestsds_3_tfleavetypename)");
       }
       else
       {
          GXv_int8[9] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Leaverequestsds_4_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV76Leaverequestsds_4_tfleavetypename_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV76Leaverequestsds_4_tfleavetypename_sel))");
       }
       else
       {
          GXv_int8[10] = 1;
       }
       if ( StringUtil.StrCmp(AV76Leaverequestsds_4_tfleavetypename_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
       }
       if ( ! (DateTime.MinValue==AV77Leaverequestsds_5_tfleaverequeststartdate) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV77Leaverequestsds_5_tfleaverequeststartdate)");
       }
       else
       {
          GXv_int8[11] = 1;
       }
       if ( ! (DateTime.MinValue==AV78Leaverequestsds_6_tfleaverequeststartdate_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV78Leaverequestsds_6_tfleaverequeststartdate_to)");
       }
       else
       {
          GXv_int8[12] = 1;
       }
       if ( ! (DateTime.MinValue==AV79Leaverequestsds_7_tfleaverequestenddate) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV79Leaverequestsds_7_tfleaverequestenddate)");
       }
       else
       {
          GXv_int8[13] = 1;
       }
       if ( ! (DateTime.MinValue==AV80Leaverequestsds_8_tfleaverequestenddate_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV80Leaverequestsds_8_tfleaverequestenddate_to)");
       }
       else
       {
          GXv_int8[14] = 1;
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Leaverequestsds_10_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestsds_9_tfleaverequesthalfday)) ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV81Leaverequestsds_9_tfleaverequesthalfday)");
       }
       else
       {
          GXv_int8[15] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Leaverequestsds_10_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV82Leaverequestsds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV82Leaverequestsds_10_tfleaverequesthalfday_sel))");
       }
       else
       {
          GXv_int8[16] = 1;
       }
       if ( StringUtil.StrCmp(AV82Leaverequestsds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
       }
       if ( ! (Convert.ToDecimal(0)==AV83Leaverequestsds_11_tfleaverequestduration) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV83Leaverequestsds_11_tfleaverequestduration)");
       }
       else
       {
          GXv_int8[17] = 1;
       }
       if ( ! (Convert.ToDecimal(0)==AV84Leaverequestsds_12_tfleaverequestduration_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV84Leaverequestsds_12_tfleaverequestduration_to)");
       }
       else
       {
          GXv_int8[18] = 1;
       }
       if ( AV85Leaverequestsds_13_tfleaverequeststatus_sels_Count > 0 )
       {
          AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV85Leaverequestsds_13_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Leaverequestsds_15_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Leaverequestsds_14_tfleaverequestdescription)) ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDescription like :lV86Leaverequestsds_14_tfleaverequestdescription)");
       }
       else
       {
          GXv_int8[19] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Leaverequestsds_15_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV87Leaverequestsds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV87Leaverequestsds_15_tfleaverequestdescription_sel))");
       }
       else
       {
          GXv_int8[20] = 1;
       }
       if ( StringUtil.StrCmp(AV87Leaverequestsds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Leaverequestsds_16_tfleaverequestrejectionreason)) ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason like :lV88Leaverequestsds_16_tfleaverequestrejectionreason)");
       }
       else
       {
          GXv_int8[21] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel))");
       }
       else
       {
          GXv_int8[22] = 1;
       }
       if ( StringUtil.StrCmp(AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
       }
       if ( AV35OrderedBy == 1 )
       {
          sOrderString += " ORDER BY T1.LeaveRequestId DESC";
       }
       else if ( ( AV35OrderedBy == 2 ) && ! AV37OrderedDsc )
       {
          sOrderString += " ORDER BY T2.LeaveTypeName, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 2 ) && ( AV37OrderedDsc ) )
       {
          sOrderString += " ORDER BY T2.LeaveTypeName DESC, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 3 ) && ! AV37OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestStartDate, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 3 ) && ( AV37OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestStartDate DESC, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 4 ) && ! AV37OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestEndDate, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 4 ) && ( AV37OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestEndDate DESC, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 5 ) && ! AV37OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestHalfDay, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 5 ) && ( AV37OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestHalfDay DESC, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 6 ) && ! AV37OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestDuration, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 6 ) && ( AV37OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestDuration DESC, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 7 ) && ! AV37OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestStatus, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 7 ) && ( AV37OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestStatus DESC, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 8 ) && ! AV37OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestDescription, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 8 ) && ( AV37OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestDescription DESC, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 9 ) && ! AV37OrderedDsc )
       {
          sOrderString += " ORDER BY T1.LeaveRequestRejectionReason, T1.LeaveRequestId";
       }
       else if ( ( AV35OrderedBy == 9 ) && ( AV37OrderedDsc ) )
       {
          sOrderString += " ORDER BY T1.LeaveRequestRejectionReason DESC, T1.LeaveRequestId";
       }
       else if ( true )
       {
          sOrderString += " ORDER BY T1.LeaveRequestId";
       }
       scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
       GXv_Object9[0] = scmdbuf;
       GXv_Object9[1] = GXv_int8;
       return GXv_Object9 ;
    }

    protected Object[] conditional_H004B3( IGxContext context ,
                                           string A132LeaveRequestStatus ,
                                           GxSimpleCollection<string> AV85Leaverequestsds_13_tfleaverequeststatus_sels ,
                                           string AV74Leaverequestsds_2_filterfulltext ,
                                           string AV76Leaverequestsds_4_tfleavetypename_sel ,
                                           string AV75Leaverequestsds_3_tfleavetypename ,
                                           DateTime AV77Leaverequestsds_5_tfleaverequeststartdate ,
                                           DateTime AV78Leaverequestsds_6_tfleaverequeststartdate_to ,
                                           DateTime AV79Leaverequestsds_7_tfleaverequestenddate ,
                                           DateTime AV80Leaverequestsds_8_tfleaverequestenddate_to ,
                                           string AV82Leaverequestsds_10_tfleaverequesthalfday_sel ,
                                           string AV81Leaverequestsds_9_tfleaverequesthalfday ,
                                           decimal AV83Leaverequestsds_11_tfleaverequestduration ,
                                           decimal AV84Leaverequestsds_12_tfleaverequestduration_to ,
                                           int AV85Leaverequestsds_13_tfleaverequeststatus_sels_Count ,
                                           string AV87Leaverequestsds_15_tfleaverequestdescription_sel ,
                                           string AV86Leaverequestsds_14_tfleaverequestdescription ,
                                           string AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel ,
                                           string AV88Leaverequestsds_16_tfleaverequestrejectionreason ,
                                           string A125LeaveTypeName ,
                                           string A171LeaveRequestHalfDay ,
                                           decimal A131LeaveRequestDuration ,
                                           string A133LeaveRequestDescription ,
                                           string A134LeaveRequestRejectionReason ,
                                           DateTime A129LeaveRequestStartDate ,
                                           DateTime A130LeaveRequestEndDate ,
                                           short AV35OrderedBy ,
                                           bool AV37OrderedDsc ,
                                           long A106EmployeeId ,
                                           long AV72Udparg1 )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int10 = new short[23];
       Object[] GXv_Object11 = new Object[2];
       scmdbuf = "SELECT COUNT(*) FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
       AddWhere(sWhereString, "(T1.EmployeeId = :AV72Udparg1)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestsds_2_filterfulltext)) )
       {
          AddWhere(sWhereString, "(( T2.LeaveTypeName like '%' || :lV74Leaverequestsds_2_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV74Leaverequestsds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV74Leaverequestsds_2_filterfulltext) or ( 'pending' like '%' || LOWER(:lV74Leaverequestsds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV74Leaverequestsds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV74Leaverequestsds_2_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')) or ( T1.LeaveRequestDescription like '%' || :lV74Leaverequestsds_2_filterfulltext) or ( T1.LeaveRequestRejectionReason like '%' || :lV74Leaverequestsds_2_filterfulltext))");
       }
       else
       {
          GXv_int10[1] = 1;
          GXv_int10[2] = 1;
          GXv_int10[3] = 1;
          GXv_int10[4] = 1;
          GXv_int10[5] = 1;
          GXv_int10[6] = 1;
          GXv_int10[7] = 1;
          GXv_int10[8] = 1;
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Leaverequestsds_4_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Leaverequestsds_3_tfleavetypename)) ) )
       {
          AddWhere(sWhereString, "(T2.LeaveTypeName like :lV75Leaverequestsds_3_tfleavetypename)");
       }
       else
       {
          GXv_int10[9] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Leaverequestsds_4_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV76Leaverequestsds_4_tfleavetypename_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV76Leaverequestsds_4_tfleavetypename_sel))");
       }
       else
       {
          GXv_int10[10] = 1;
       }
       if ( StringUtil.StrCmp(AV76Leaverequestsds_4_tfleavetypename_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
       }
       if ( ! (DateTime.MinValue==AV77Leaverequestsds_5_tfleaverequeststartdate) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV77Leaverequestsds_5_tfleaverequeststartdate)");
       }
       else
       {
          GXv_int10[11] = 1;
       }
       if ( ! (DateTime.MinValue==AV78Leaverequestsds_6_tfleaverequeststartdate_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV78Leaverequestsds_6_tfleaverequeststartdate_to)");
       }
       else
       {
          GXv_int10[12] = 1;
       }
       if ( ! (DateTime.MinValue==AV79Leaverequestsds_7_tfleaverequestenddate) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV79Leaverequestsds_7_tfleaverequestenddate)");
       }
       else
       {
          GXv_int10[13] = 1;
       }
       if ( ! (DateTime.MinValue==AV80Leaverequestsds_8_tfleaverequestenddate_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV80Leaverequestsds_8_tfleaverequestenddate_to)");
       }
       else
       {
          GXv_int10[14] = 1;
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Leaverequestsds_10_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Leaverequestsds_9_tfleaverequesthalfday)) ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV81Leaverequestsds_9_tfleaverequesthalfday)");
       }
       else
       {
          GXv_int10[15] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Leaverequestsds_10_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV82Leaverequestsds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV82Leaverequestsds_10_tfleaverequesthalfday_sel))");
       }
       else
       {
          GXv_int10[16] = 1;
       }
       if ( StringUtil.StrCmp(AV82Leaverequestsds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
       }
       if ( ! (Convert.ToDecimal(0)==AV83Leaverequestsds_11_tfleaverequestduration) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV83Leaverequestsds_11_tfleaverequestduration)");
       }
       else
       {
          GXv_int10[17] = 1;
       }
       if ( ! (Convert.ToDecimal(0)==AV84Leaverequestsds_12_tfleaverequestduration_to) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV84Leaverequestsds_12_tfleaverequestduration_to)");
       }
       else
       {
          GXv_int10[18] = 1;
       }
       if ( AV85Leaverequestsds_13_tfleaverequeststatus_sels_Count > 0 )
       {
          AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV85Leaverequestsds_13_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Leaverequestsds_15_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Leaverequestsds_14_tfleaverequestdescription)) ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDescription like :lV86Leaverequestsds_14_tfleaverequestdescription)");
       }
       else
       {
          GXv_int10[19] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Leaverequestsds_15_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV87Leaverequestsds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV87Leaverequestsds_15_tfleaverequestdescription_sel))");
       }
       else
       {
          GXv_int10[20] = 1;
       }
       if ( StringUtil.StrCmp(AV87Leaverequestsds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
       }
       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Leaverequestsds_16_tfleaverequestrejectionreason)) ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason like :lV88Leaverequestsds_16_tfleaverequestrejectionreason)");
       }
       else
       {
          GXv_int10[21] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel)) && ! ( StringUtil.StrCmp(AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 ) )
       {
          AddWhere(sWhereString, "(T1.LeaveRequestRejectionReason = ( :AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel))");
       }
       else
       {
          GXv_int10[22] = 1;
       }
       if ( StringUtil.StrCmp(AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel, "<#Empty#>") == 0 )
       {
          AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestRejectionReason))=0))");
       }
       scmdbuf += sWhereString;
       if ( AV35OrderedBy == 1 )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 2 ) && ! AV37OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 2 ) && ( AV37OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 3 ) && ! AV37OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 3 ) && ( AV37OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 4 ) && ! AV37OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 4 ) && ( AV37OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 5 ) && ! AV37OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 5 ) && ( AV37OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 6 ) && ! AV37OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 6 ) && ( AV37OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 7 ) && ! AV37OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 7 ) && ( AV37OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 8 ) && ! AV37OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 8 ) && ( AV37OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 9 ) && ! AV37OrderedDsc )
       {
          scmdbuf += "";
       }
       else if ( ( AV35OrderedBy == 9 ) && ( AV37OrderedDsc ) )
       {
          scmdbuf += "";
       }
       else if ( true )
       {
          scmdbuf += "";
       }
       GXv_Object11[0] = scmdbuf;
       GXv_Object11[1] = GXv_int10;
       return GXv_Object11 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_H004B2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] );
             case 1 :
                   return conditional_H004B3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] );
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
        Object[] prmH004B2;
        prmH004B2 = new Object[] {
        new ParDef("AV72Udparg1",GXType.Int64,10,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV75Leaverequestsds_3_tfleavetypename",GXType.Char,100,0) ,
        new ParDef("AV76Leaverequestsds_4_tfleavetypename_sel",GXType.Char,100,0) ,
        new ParDef("AV77Leaverequestsds_5_tfleaverequeststartdate",GXType.Date,8,0) ,
        new ParDef("AV78Leaverequestsds_6_tfleaverequeststartdate_to",GXType.Date,8,0) ,
        new ParDef("AV79Leaverequestsds_7_tfleaverequestenddate",GXType.Date,8,0) ,
        new ParDef("AV80Leaverequestsds_8_tfleaverequestenddate_to",GXType.Date,8,0) ,
        new ParDef("lV81Leaverequestsds_9_tfleaverequesthalfday",GXType.Char,20,0) ,
        new ParDef("AV82Leaverequestsds_10_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
        new ParDef("AV83Leaverequestsds_11_tfleaverequestduration",GXType.Number,4,1) ,
        new ParDef("AV84Leaverequestsds_12_tfleaverequestduration_to",GXType.Number,4,1) ,
        new ParDef("lV86Leaverequestsds_14_tfleaverequestdescription",GXType.VarChar,200,0) ,
        new ParDef("AV87Leaverequestsds_15_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
        new ParDef("lV88Leaverequestsds_16_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
        new ParDef("AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0) ,
        new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
        new ParDef("GXPagingTo2",GXType.Int32,9,0)
        };
        Object[] prmH004B3;
        prmH004B3 = new Object[] {
        new ParDef("AV72Udparg1",GXType.Int64,10,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV74Leaverequestsds_2_filterfulltext",GXType.VarChar,100,0) ,
        new ParDef("lV75Leaverequestsds_3_tfleavetypename",GXType.Char,100,0) ,
        new ParDef("AV76Leaverequestsds_4_tfleavetypename_sel",GXType.Char,100,0) ,
        new ParDef("AV77Leaverequestsds_5_tfleaverequeststartdate",GXType.Date,8,0) ,
        new ParDef("AV78Leaverequestsds_6_tfleaverequeststartdate_to",GXType.Date,8,0) ,
        new ParDef("AV79Leaverequestsds_7_tfleaverequestenddate",GXType.Date,8,0) ,
        new ParDef("AV80Leaverequestsds_8_tfleaverequestenddate_to",GXType.Date,8,0) ,
        new ParDef("lV81Leaverequestsds_9_tfleaverequesthalfday",GXType.Char,20,0) ,
        new ParDef("AV82Leaverequestsds_10_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
        new ParDef("AV83Leaverequestsds_11_tfleaverequestduration",GXType.Number,4,1) ,
        new ParDef("AV84Leaverequestsds_12_tfleaverequestduration_to",GXType.Number,4,1) ,
        new ParDef("lV86Leaverequestsds_14_tfleaverequestdescription",GXType.VarChar,200,0) ,
        new ParDef("AV87Leaverequestsds_15_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
        new ParDef("lV88Leaverequestsds_16_tfleaverequestrejectionreason",GXType.VarChar,200,0) ,
        new ParDef("AV89Leaverequestsds_17_tfleaverequestrejectionreason_sel",GXType.VarChar,200,0)
        };
        def= new CursorDef[] {
            new CursorDef("H004B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004B2,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H004B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004B3,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 100);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              ((long[]) buf[12])[0] = rslt.getLong(12);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
