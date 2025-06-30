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
   public class workhourlogww : GXDataArea
   {
      public workhourlogww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourlogww( IGxContext context )
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
         cmbavWorkhourlogdateoperator = new GXCombobox();
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
         nRC_GXsfl_49 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_49"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_49_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_49_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_49_idx = GetPar( "sGXsfl_49_idx");
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
         AV17OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV18OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV20FilterFullText = GetPar( "FilterFullText");
         cmbavWorkhourlogdateoperator.FromJSonString( GetNextPar( ));
         AV88WorkHourLogDateOperator = (short)(Math.Round(NumberUtil.Val( GetPar( "WorkHourLogDateOperator"), "."), 18, MidpointRounding.ToEven));
         AV90WorkHourLogDate = context.localUtil.ParseDateParm( GetPar( "WorkHourLogDate"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV25ColumnsSelector);
         AV94Pgmname = GetPar( "Pgmname");
         AV89WorkHourLogDate_To = context.localUtil.ParseDateParm( GetPar( "WorkHourLogDate_To"));
         AV33TFWorkHourLogDate = context.localUtil.ParseDateParm( GetPar( "TFWorkHourLogDate"));
         AV34TFWorkHourLogDate_To = context.localUtil.ParseDateParm( GetPar( "TFWorkHourLogDate_To"));
         AV38TFWorkHourLogDuration = GetPar( "TFWorkHourLogDuration");
         AV39TFWorkHourLogDuration_Sel = GetPar( "TFWorkHourLogDuration_Sel");
         AV40TFWorkHourLogHour = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWorkHourLogHour"), "."), 18, MidpointRounding.ToEven));
         AV41TFWorkHourLogHour_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWorkHourLogHour_To"), "."), 18, MidpointRounding.ToEven));
         AV42TFWorkHourLogMinute = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWorkHourLogMinute"), "."), 18, MidpointRounding.ToEven));
         AV43TFWorkHourLogMinute_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWorkHourLogMinute_To"), "."), 18, MidpointRounding.ToEven));
         AV44TFWorkHourLogDescription = GetPar( "TFWorkHourLogDescription");
         AV45TFWorkHourLogDescription_Sel = GetPar( "TFWorkHourLogDescription_Sel");
         AV63TFEmployeeFirstName = GetPar( "TFEmployeeFirstName");
         AV64TFEmployeeFirstName_Sel = GetPar( "TFEmployeeFirstName_Sel");
         AV50TFProjectName = GetPar( "TFProjectName");
         AV51TFProjectName_Sel = GetPar( "TFProjectName_Sel");
         AV56IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV58IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV62IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV88WorkHourLogDateOperator, AV90WorkHourLogDate, AV25ColumnsSelector, AV94Pgmname, AV89WorkHourLogDate_To, AV33TFWorkHourLogDate, AV34TFWorkHourLogDate_To, AV38TFWorkHourLogDuration, AV39TFWorkHourLogDuration_Sel, AV40TFWorkHourLogHour, AV41TFWorkHourLogHour_To, AV42TFWorkHourLogMinute, AV43TFWorkHourLogMinute_To, AV44TFWorkHourLogDescription, AV45TFWorkHourLogDescription_Sel, AV63TFEmployeeFirstName, AV64TFEmployeeFirstName_Sel, AV50TFProjectName, AV51TFProjectName_Sel, AV56IsAuthorized_Update, AV58IsAuthorized_Delete, AV62IsAuthorized_Insert, Gx_date) ;
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
            return "workhourlogww_Execute" ;
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
         PA2X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2X2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workhourlogww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV94Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV94Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV56IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV56IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV58IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV58IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV62IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV62IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV18OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV20FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vWORKHOURLOGDATEOPERATOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV88WorkHourLogDateOperator), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vWORKHOURLOGDATE", context.localUtil.Format(AV90WorkHourLogDate, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_49", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_49), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV67GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV9GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV60AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV60AGExportData);
         }
         GxWebStd.gx_hidden_field( context, "vWORKHOURLOGDATE", context.localUtil.DToC( AV90WorkHourLogDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vWORKHOURLOGDATE_TO", context.localUtil.DToC( AV89WorkHourLogDate_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV25ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV25ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_WORKHOURLOGDATEAUXDATE", context.localUtil.DToC( AV35DDO_WorkHourLogDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_WORKHOURLOGDATEAUXDATETO", context.localUtil.DToC( AV36DDO_WorkHourLogDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV94Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV94Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDATE", context.localUtil.DToC( AV33TFWorkHourLogDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDATE_TO", context.localUtil.DToC( AV34TFWorkHourLogDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDURATION", AV38TFWorkHourLogDuration);
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDURATION_SEL", AV39TFWorkHourLogDuration_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGHOUR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40TFWorkHourLogHour), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGHOUR_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41TFWorkHourLogHour_To), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGMINUTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42TFWorkHourLogMinute), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGMINUTE_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFWorkHourLogMinute_To), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDESCRIPTION", AV44TFWorkHourLogDescription);
         GxWebStd.gx_hidden_field( context, "vTFWORKHOURLOGDESCRIPTION_SEL", AV45TFWorkHourLogDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEFIRSTNAME", StringUtil.RTrim( AV63TFEmployeeFirstName));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEFIRSTNAME_SEL", StringUtil.RTrim( AV64TFEmployeeFirstName_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPROJECTNAME", StringUtil.RTrim( AV50TFProjectName));
         GxWebStd.gx_hidden_field( context, "vTFPROJECTNAME_SEL", StringUtil.RTrim( AV51TFProjectName_Sel));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV18OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV56IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV56IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV58IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV58IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV62IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV62IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
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
            WE2X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2X2( ) ;
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
         return formatLink("workhourlogww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WorkHourLogWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Work Hour Log" ;
      }

      protected void WB2X0( )
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
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(49), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkHourLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(49), 2, 0)+","+"null"+");", "Export", bttBtnagexport_Jsonclick, 0, "Export", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkHourLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(49), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkHourLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV20FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV20FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WorkHourLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfiltertextworkhourlogdate_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFiltertextworkhourlogdate_Internalname, "Log Date", "", "", lblFiltertextworkhourlogdate_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkHourLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_33_2X2( true) ;
         }
         else
         {
            wb_table1_33_2X2( false) ;
         }
         return  ;
      }

      protected void wb_table1_33_2X2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl49( ) ;
         }
         if ( wbEnd == 49 )
         {
            wbEnd = 0;
            nRC_GXsfl_49 = (int)(nGXsfl_49_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV66GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV67GridPageCount);
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
            ucWorkhourlogdate_rangepicker.SetProperty("Start Date", AV90WorkHourLogDate);
            ucWorkhourlogdate_rangepicker.SetProperty("End Date", AV89WorkHourLogDate_To);
            ucWorkhourlogdate_rangepicker.Render(context, "wwp.daterangepicker", Workhourlogdate_rangepicker_Internalname, "WORKHOURLOGDATE_RANGEPICKERContainer");
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV25ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_workhourlogdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_workhourlogdateauxdatetext_Internalname, AV37DDO_WorkHourLogDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV37DDO_WorkHourLogDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_workhourlogdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkHourLogWW.htm");
            /* User Defined Control */
            ucTfworkhourlogdate_rangepicker.SetProperty("Start Date", AV35DDO_WorkHourLogDateAuxDate);
            ucTfworkhourlogdate_rangepicker.SetProperty("End Date", AV36DDO_WorkHourLogDateAuxDateTo);
            ucTfworkhourlogdate_rangepicker.Render(context, "wwp.daterangepicker", Tfworkhourlogdate_rangepicker_Internalname, "TFWORKHOURLOGDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 49 )
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

      protected void START2X2( )
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
         Form.Meta.addItem("description", " Work Hour Log", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2X0( ) ;
      }

      protected void WS2X2( )
      {
         START2X2( ) ;
         EVT2X2( ) ;
      }

      protected void EVT2X2( )
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
                              E112X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E122X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E132X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "WORKHOURLOGDATE_RANGEPICKER.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Workhourlogdate_rangepicker.Daterangechanged */
                              E142X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E152X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E162X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E172X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VWORKHOURLOGDATEOPERATOR.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E182X2 ();
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
                              nGXsfl_49_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
                              SubsflControlProps_492( ) ;
                              AV55Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV55Update);
                              AV57Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV57Delete);
                              A118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A119WorkHourLogDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtWorkHourLogDate_Internalname), 0));
                              A120WorkHourLogDuration = cgiGet( edtWorkHourLogDuration_Internalname);
                              A121WorkHourLogHour = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogHour_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A122WorkHourLogMinute = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogMinute_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A123WorkHourLogDescription = cgiGet( edtWorkHourLogDescription_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A107EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
                              A102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A103ProjectName = cgiGet( edtProjectName_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E192X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E202X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E212X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV17OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV18OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV20FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Workhourlogdateoperator Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vWORKHOURLOGDATEOPERATOR"), ".", ",") != Convert.ToDecimal( AV88WorkHourLogDateOperator )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Workhourlogdate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vWORKHOURLOGDATE"), 0) != AV90WorkHourLogDate )
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

      protected void WE2X2( )
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

      protected void PA2X2( )
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
         SubsflControlProps_492( ) ;
         while ( nGXsfl_49_idx <= nRC_GXsfl_49 )
         {
            sendrow_492( ) ;
            nGXsfl_49_idx = ((subGrid_Islastpage==1)&&(nGXsfl_49_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_49_idx+1);
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV17OrderedBy ,
                                       bool AV18OrderedDsc ,
                                       string AV20FilterFullText ,
                                       short AV88WorkHourLogDateOperator ,
                                       DateTime AV90WorkHourLogDate ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelector ,
                                       string AV94Pgmname ,
                                       DateTime AV89WorkHourLogDate_To ,
                                       DateTime AV33TFWorkHourLogDate ,
                                       DateTime AV34TFWorkHourLogDate_To ,
                                       string AV38TFWorkHourLogDuration ,
                                       string AV39TFWorkHourLogDuration_Sel ,
                                       short AV40TFWorkHourLogHour ,
                                       short AV41TFWorkHourLogHour_To ,
                                       short AV42TFWorkHourLogMinute ,
                                       short AV43TFWorkHourLogMinute_To ,
                                       string AV44TFWorkHourLogDescription ,
                                       string AV45TFWorkHourLogDescription_Sel ,
                                       string AV63TFEmployeeFirstName ,
                                       string AV64TFEmployeeFirstName_Sel ,
                                       string AV50TFProjectName ,
                                       string AV51TFProjectName_Sel ,
                                       bool AV56IsAuthorized_Update ,
                                       bool AV58IsAuthorized_Delete ,
                                       bool AV62IsAuthorized_Insert ,
                                       DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WORKHOURLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", "")));
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
         if ( cmbavWorkhourlogdateoperator.ItemCount > 0 )
         {
            AV88WorkHourLogDateOperator = (short)(Math.Round(NumberUtil.Val( cmbavWorkhourlogdateoperator.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV88WorkHourLogDateOperator), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV88WorkHourLogDateOperator", StringUtil.LTrimStr( (decimal)(AV88WorkHourLogDateOperator), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWorkhourlogdateoperator.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV88WorkHourLogDateOperator), 4, 0));
            AssignProp("", false, cmbavWorkhourlogdateoperator_Internalname, "Values", cmbavWorkhourlogdateoperator.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV94Pgmname = "WorkHourLogWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF2X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 49;
         /* Execute user event: Refresh */
         E202X2 ();
         nGXsfl_49_idx = 1;
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_492( ) ;
         bGXsfl_49_Refreshing = true;
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
            SubsflControlProps_492( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV95Workhourlogwwds_1_filterfulltext ,
                                                 AV88WorkHourLogDateOperator ,
                                                 AV96Workhourlogwwds_2_workhourlogdate ,
                                                 AV97Workhourlogwwds_3_workhourlogdate_to ,
                                                 AV98Workhourlogwwds_4_tfworkhourlogdate ,
                                                 AV99Workhourlogwwds_5_tfworkhourlogdate_to ,
                                                 AV101Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                                 AV100Workhourlogwwds_6_tfworkhourlogduration ,
                                                 AV102Workhourlogwwds_8_tfworkhourloghour ,
                                                 AV103Workhourlogwwds_9_tfworkhourloghour_to ,
                                                 AV104Workhourlogwwds_10_tfworkhourlogminute ,
                                                 AV105Workhourlogwwds_11_tfworkhourlogminute_to ,
                                                 AV107Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                                 AV106Workhourlogwwds_12_tfworkhourlogdescription ,
                                                 AV109Workhourlogwwds_15_tfemployeefirstname_sel ,
                                                 AV108Workhourlogwwds_14_tfemployeefirstname ,
                                                 AV111Workhourlogwwds_17_tfprojectname_sel ,
                                                 AV110Workhourlogwwds_16_tfprojectname ,
                                                 A120WorkHourLogDuration ,
                                                 A121WorkHourLogHour ,
                                                 A122WorkHourLogMinute ,
                                                 A123WorkHourLogDescription ,
                                                 A107EmployeeFirstName ,
                                                 A103ProjectName ,
                                                 A119WorkHourLogDate ,
                                                 AV17OrderedBy ,
                                                 AV18OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
            lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
            lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
            lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
            lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
            lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
            lV100Workhourlogwwds_6_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV100Workhourlogwwds_6_tfworkhourlogduration), "%", "");
            lV106Workhourlogwwds_12_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV106Workhourlogwwds_12_tfworkhourlogdescription), "%", "");
            lV108Workhourlogwwds_14_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV108Workhourlogwwds_14_tfemployeefirstname), 100, "%");
            lV110Workhourlogwwds_16_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV110Workhourlogwwds_16_tfprojectname), 100, "%");
            /* Using cursor H002X2 */
            pr_default.execute(0, new Object[] {lV95Workhourlogwwds_1_filterfulltext, lV95Workhourlogwwds_1_filterfulltext, lV95Workhourlogwwds_1_filterfulltext, lV95Workhourlogwwds_1_filterfulltext, lV95Workhourlogwwds_1_filterfulltext, lV95Workhourlogwwds_1_filterfulltext, AV96Workhourlogwwds_2_workhourlogdate, AV96Workhourlogwwds_2_workhourlogdate, AV96Workhourlogwwds_2_workhourlogdate, AV97Workhourlogwwds_3_workhourlogdate_to, AV96Workhourlogwwds_2_workhourlogdate, AV98Workhourlogwwds_4_tfworkhourlogdate, AV99Workhourlogwwds_5_tfworkhourlogdate_to, lV100Workhourlogwwds_6_tfworkhourlogduration, AV101Workhourlogwwds_7_tfworkhourlogduration_sel, AV102Workhourlogwwds_8_tfworkhourloghour, AV103Workhourlogwwds_9_tfworkhourloghour_to, AV104Workhourlogwwds_10_tfworkhourlogminute, AV105Workhourlogwwds_11_tfworkhourlogminute_to, lV106Workhourlogwwds_12_tfworkhourlogdescription, AV107Workhourlogwwds_13_tfworkhourlogdescription_sel, lV108Workhourlogwwds_14_tfemployeefirstname, AV109Workhourlogwwds_15_tfemployeefirstname_sel, lV110Workhourlogwwds_16_tfprojectname, AV111Workhourlogwwds_17_tfprojectname_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_49_idx = 1;
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A103ProjectName = H002X2_A103ProjectName[0];
               A102ProjectId = H002X2_A102ProjectId[0];
               A107EmployeeFirstName = H002X2_A107EmployeeFirstName[0];
               A106EmployeeId = H002X2_A106EmployeeId[0];
               A123WorkHourLogDescription = H002X2_A123WorkHourLogDescription[0];
               A122WorkHourLogMinute = H002X2_A122WorkHourLogMinute[0];
               A121WorkHourLogHour = H002X2_A121WorkHourLogHour[0];
               A120WorkHourLogDuration = H002X2_A120WorkHourLogDuration[0];
               A119WorkHourLogDate = H002X2_A119WorkHourLogDate[0];
               A118WorkHourLogId = H002X2_A118WorkHourLogId[0];
               A103ProjectName = H002X2_A103ProjectName[0];
               A107EmployeeFirstName = H002X2_A107EmployeeFirstName[0];
               /* Execute user event: Grid.Load */
               E212X2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 49;
            WB2X0( ) ;
         }
         bGXsfl_49_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2X2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV94Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV94Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV56IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV56IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV58IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV58IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV62IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV62IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_WORKHOURLOGID"+"_"+sGXsfl_49_idx, GetSecureSignedToken( sGXsfl_49_idx, context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
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
         AV95Workhourlogwwds_1_filterfulltext = AV20FilterFullText;
         AV96Workhourlogwwds_2_workhourlogdate = AV90WorkHourLogDate;
         AV97Workhourlogwwds_3_workhourlogdate_to = AV89WorkHourLogDate_To;
         AV98Workhourlogwwds_4_tfworkhourlogdate = AV33TFWorkHourLogDate;
         AV99Workhourlogwwds_5_tfworkhourlogdate_to = AV34TFWorkHourLogDate_To;
         AV100Workhourlogwwds_6_tfworkhourlogduration = AV38TFWorkHourLogDuration;
         AV101Workhourlogwwds_7_tfworkhourlogduration_sel = AV39TFWorkHourLogDuration_Sel;
         AV102Workhourlogwwds_8_tfworkhourloghour = AV40TFWorkHourLogHour;
         AV103Workhourlogwwds_9_tfworkhourloghour_to = AV41TFWorkHourLogHour_To;
         AV104Workhourlogwwds_10_tfworkhourlogminute = AV42TFWorkHourLogMinute;
         AV105Workhourlogwwds_11_tfworkhourlogminute_to = AV43TFWorkHourLogMinute_To;
         AV106Workhourlogwwds_12_tfworkhourlogdescription = AV44TFWorkHourLogDescription;
         AV107Workhourlogwwds_13_tfworkhourlogdescription_sel = AV45TFWorkHourLogDescription_Sel;
         AV108Workhourlogwwds_14_tfemployeefirstname = AV63TFEmployeeFirstName;
         AV109Workhourlogwwds_15_tfemployeefirstname_sel = AV64TFEmployeeFirstName_Sel;
         AV110Workhourlogwwds_16_tfprojectname = AV50TFProjectName;
         AV111Workhourlogwwds_17_tfprojectname_sel = AV51TFProjectName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV95Workhourlogwwds_1_filterfulltext ,
                                              AV88WorkHourLogDateOperator ,
                                              AV96Workhourlogwwds_2_workhourlogdate ,
                                              AV97Workhourlogwwds_3_workhourlogdate_to ,
                                              AV98Workhourlogwwds_4_tfworkhourlogdate ,
                                              AV99Workhourlogwwds_5_tfworkhourlogdate_to ,
                                              AV101Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                              AV100Workhourlogwwds_6_tfworkhourlogduration ,
                                              AV102Workhourlogwwds_8_tfworkhourloghour ,
                                              AV103Workhourlogwwds_9_tfworkhourloghour_to ,
                                              AV104Workhourlogwwds_10_tfworkhourlogminute ,
                                              AV105Workhourlogwwds_11_tfworkhourlogminute_to ,
                                              AV107Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                              AV106Workhourlogwwds_12_tfworkhourlogdescription ,
                                              AV109Workhourlogwwds_15_tfemployeefirstname_sel ,
                                              AV108Workhourlogwwds_14_tfemployeefirstname ,
                                              AV111Workhourlogwwds_17_tfprojectname_sel ,
                                              AV110Workhourlogwwds_16_tfprojectname ,
                                              A120WorkHourLogDuration ,
                                              A121WorkHourLogHour ,
                                              A122WorkHourLogMinute ,
                                              A123WorkHourLogDescription ,
                                              A107EmployeeFirstName ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
         lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
         lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
         lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
         lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
         lV95Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext), "%", "");
         lV100Workhourlogwwds_6_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV100Workhourlogwwds_6_tfworkhourlogduration), "%", "");
         lV106Workhourlogwwds_12_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV106Workhourlogwwds_12_tfworkhourlogdescription), "%", "");
         lV108Workhourlogwwds_14_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV108Workhourlogwwds_14_tfemployeefirstname), 100, "%");
         lV110Workhourlogwwds_16_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV110Workhourlogwwds_16_tfprojectname), 100, "%");
         /* Using cursor H002X3 */
         pr_default.execute(1, new Object[] {lV95Workhourlogwwds_1_filterfulltext, lV95Workhourlogwwds_1_filterfulltext, lV95Workhourlogwwds_1_filterfulltext, lV95Workhourlogwwds_1_filterfulltext, lV95Workhourlogwwds_1_filterfulltext, lV95Workhourlogwwds_1_filterfulltext, AV96Workhourlogwwds_2_workhourlogdate, AV96Workhourlogwwds_2_workhourlogdate, AV96Workhourlogwwds_2_workhourlogdate, AV97Workhourlogwwds_3_workhourlogdate_to, AV96Workhourlogwwds_2_workhourlogdate, AV98Workhourlogwwds_4_tfworkhourlogdate, AV99Workhourlogwwds_5_tfworkhourlogdate_to, lV100Workhourlogwwds_6_tfworkhourlogduration, AV101Workhourlogwwds_7_tfworkhourlogduration_sel, AV102Workhourlogwwds_8_tfworkhourloghour, AV103Workhourlogwwds_9_tfworkhourloghour_to, AV104Workhourlogwwds_10_tfworkhourlogminute, AV105Workhourlogwwds_11_tfworkhourlogminute_to, lV106Workhourlogwwds_12_tfworkhourlogdescription, AV107Workhourlogwwds_13_tfworkhourlogdescription_sel, lV108Workhourlogwwds_14_tfemployeefirstname, AV109Workhourlogwwds_15_tfemployeefirstname_sel, lV110Workhourlogwwds_16_tfprojectname, AV111Workhourlogwwds_17_tfprojectname_sel});
         GRID_nRecordCount = H002X3_AGRID_nRecordCount[0];
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
         AV95Workhourlogwwds_1_filterfulltext = AV20FilterFullText;
         AV96Workhourlogwwds_2_workhourlogdate = AV90WorkHourLogDate;
         AV97Workhourlogwwds_3_workhourlogdate_to = AV89WorkHourLogDate_To;
         AV98Workhourlogwwds_4_tfworkhourlogdate = AV33TFWorkHourLogDate;
         AV99Workhourlogwwds_5_tfworkhourlogdate_to = AV34TFWorkHourLogDate_To;
         AV100Workhourlogwwds_6_tfworkhourlogduration = AV38TFWorkHourLogDuration;
         AV101Workhourlogwwds_7_tfworkhourlogduration_sel = AV39TFWorkHourLogDuration_Sel;
         AV102Workhourlogwwds_8_tfworkhourloghour = AV40TFWorkHourLogHour;
         AV103Workhourlogwwds_9_tfworkhourloghour_to = AV41TFWorkHourLogHour_To;
         AV104Workhourlogwwds_10_tfworkhourlogminute = AV42TFWorkHourLogMinute;
         AV105Workhourlogwwds_11_tfworkhourlogminute_to = AV43TFWorkHourLogMinute_To;
         AV106Workhourlogwwds_12_tfworkhourlogdescription = AV44TFWorkHourLogDescription;
         AV107Workhourlogwwds_13_tfworkhourlogdescription_sel = AV45TFWorkHourLogDescription_Sel;
         AV108Workhourlogwwds_14_tfemployeefirstname = AV63TFEmployeeFirstName;
         AV109Workhourlogwwds_15_tfemployeefirstname_sel = AV64TFEmployeeFirstName_Sel;
         AV110Workhourlogwwds_16_tfprojectname = AV50TFProjectName;
         AV111Workhourlogwwds_17_tfprojectname_sel = AV51TFProjectName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV88WorkHourLogDateOperator, AV90WorkHourLogDate, AV25ColumnsSelector, AV94Pgmname, AV89WorkHourLogDate_To, AV33TFWorkHourLogDate, AV34TFWorkHourLogDate_To, AV38TFWorkHourLogDuration, AV39TFWorkHourLogDuration_Sel, AV40TFWorkHourLogHour, AV41TFWorkHourLogHour_To, AV42TFWorkHourLogMinute, AV43TFWorkHourLogMinute_To, AV44TFWorkHourLogDescription, AV45TFWorkHourLogDescription_Sel, AV63TFEmployeeFirstName, AV64TFEmployeeFirstName_Sel, AV50TFProjectName, AV51TFProjectName_Sel, AV56IsAuthorized_Update, AV58IsAuthorized_Delete, AV62IsAuthorized_Insert, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV95Workhourlogwwds_1_filterfulltext = AV20FilterFullText;
         AV96Workhourlogwwds_2_workhourlogdate = AV90WorkHourLogDate;
         AV97Workhourlogwwds_3_workhourlogdate_to = AV89WorkHourLogDate_To;
         AV98Workhourlogwwds_4_tfworkhourlogdate = AV33TFWorkHourLogDate;
         AV99Workhourlogwwds_5_tfworkhourlogdate_to = AV34TFWorkHourLogDate_To;
         AV100Workhourlogwwds_6_tfworkhourlogduration = AV38TFWorkHourLogDuration;
         AV101Workhourlogwwds_7_tfworkhourlogduration_sel = AV39TFWorkHourLogDuration_Sel;
         AV102Workhourlogwwds_8_tfworkhourloghour = AV40TFWorkHourLogHour;
         AV103Workhourlogwwds_9_tfworkhourloghour_to = AV41TFWorkHourLogHour_To;
         AV104Workhourlogwwds_10_tfworkhourlogminute = AV42TFWorkHourLogMinute;
         AV105Workhourlogwwds_11_tfworkhourlogminute_to = AV43TFWorkHourLogMinute_To;
         AV106Workhourlogwwds_12_tfworkhourlogdescription = AV44TFWorkHourLogDescription;
         AV107Workhourlogwwds_13_tfworkhourlogdescription_sel = AV45TFWorkHourLogDescription_Sel;
         AV108Workhourlogwwds_14_tfemployeefirstname = AV63TFEmployeeFirstName;
         AV109Workhourlogwwds_15_tfemployeefirstname_sel = AV64TFEmployeeFirstName_Sel;
         AV110Workhourlogwwds_16_tfprojectname = AV50TFProjectName;
         AV111Workhourlogwwds_17_tfprojectname_sel = AV51TFProjectName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV88WorkHourLogDateOperator, AV90WorkHourLogDate, AV25ColumnsSelector, AV94Pgmname, AV89WorkHourLogDate_To, AV33TFWorkHourLogDate, AV34TFWorkHourLogDate_To, AV38TFWorkHourLogDuration, AV39TFWorkHourLogDuration_Sel, AV40TFWorkHourLogHour, AV41TFWorkHourLogHour_To, AV42TFWorkHourLogMinute, AV43TFWorkHourLogMinute_To, AV44TFWorkHourLogDescription, AV45TFWorkHourLogDescription_Sel, AV63TFEmployeeFirstName, AV64TFEmployeeFirstName_Sel, AV50TFProjectName, AV51TFProjectName_Sel, AV56IsAuthorized_Update, AV58IsAuthorized_Delete, AV62IsAuthorized_Insert, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV95Workhourlogwwds_1_filterfulltext = AV20FilterFullText;
         AV96Workhourlogwwds_2_workhourlogdate = AV90WorkHourLogDate;
         AV97Workhourlogwwds_3_workhourlogdate_to = AV89WorkHourLogDate_To;
         AV98Workhourlogwwds_4_tfworkhourlogdate = AV33TFWorkHourLogDate;
         AV99Workhourlogwwds_5_tfworkhourlogdate_to = AV34TFWorkHourLogDate_To;
         AV100Workhourlogwwds_6_tfworkhourlogduration = AV38TFWorkHourLogDuration;
         AV101Workhourlogwwds_7_tfworkhourlogduration_sel = AV39TFWorkHourLogDuration_Sel;
         AV102Workhourlogwwds_8_tfworkhourloghour = AV40TFWorkHourLogHour;
         AV103Workhourlogwwds_9_tfworkhourloghour_to = AV41TFWorkHourLogHour_To;
         AV104Workhourlogwwds_10_tfworkhourlogminute = AV42TFWorkHourLogMinute;
         AV105Workhourlogwwds_11_tfworkhourlogminute_to = AV43TFWorkHourLogMinute_To;
         AV106Workhourlogwwds_12_tfworkhourlogdescription = AV44TFWorkHourLogDescription;
         AV107Workhourlogwwds_13_tfworkhourlogdescription_sel = AV45TFWorkHourLogDescription_Sel;
         AV108Workhourlogwwds_14_tfemployeefirstname = AV63TFEmployeeFirstName;
         AV109Workhourlogwwds_15_tfemployeefirstname_sel = AV64TFEmployeeFirstName_Sel;
         AV110Workhourlogwwds_16_tfprojectname = AV50TFProjectName;
         AV111Workhourlogwwds_17_tfprojectname_sel = AV51TFProjectName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV88WorkHourLogDateOperator, AV90WorkHourLogDate, AV25ColumnsSelector, AV94Pgmname, AV89WorkHourLogDate_To, AV33TFWorkHourLogDate, AV34TFWorkHourLogDate_To, AV38TFWorkHourLogDuration, AV39TFWorkHourLogDuration_Sel, AV40TFWorkHourLogHour, AV41TFWorkHourLogHour_To, AV42TFWorkHourLogMinute, AV43TFWorkHourLogMinute_To, AV44TFWorkHourLogDescription, AV45TFWorkHourLogDescription_Sel, AV63TFEmployeeFirstName, AV64TFEmployeeFirstName_Sel, AV50TFProjectName, AV51TFProjectName_Sel, AV56IsAuthorized_Update, AV58IsAuthorized_Delete, AV62IsAuthorized_Insert, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV95Workhourlogwwds_1_filterfulltext = AV20FilterFullText;
         AV96Workhourlogwwds_2_workhourlogdate = AV90WorkHourLogDate;
         AV97Workhourlogwwds_3_workhourlogdate_to = AV89WorkHourLogDate_To;
         AV98Workhourlogwwds_4_tfworkhourlogdate = AV33TFWorkHourLogDate;
         AV99Workhourlogwwds_5_tfworkhourlogdate_to = AV34TFWorkHourLogDate_To;
         AV100Workhourlogwwds_6_tfworkhourlogduration = AV38TFWorkHourLogDuration;
         AV101Workhourlogwwds_7_tfworkhourlogduration_sel = AV39TFWorkHourLogDuration_Sel;
         AV102Workhourlogwwds_8_tfworkhourloghour = AV40TFWorkHourLogHour;
         AV103Workhourlogwwds_9_tfworkhourloghour_to = AV41TFWorkHourLogHour_To;
         AV104Workhourlogwwds_10_tfworkhourlogminute = AV42TFWorkHourLogMinute;
         AV105Workhourlogwwds_11_tfworkhourlogminute_to = AV43TFWorkHourLogMinute_To;
         AV106Workhourlogwwds_12_tfworkhourlogdescription = AV44TFWorkHourLogDescription;
         AV107Workhourlogwwds_13_tfworkhourlogdescription_sel = AV45TFWorkHourLogDescription_Sel;
         AV108Workhourlogwwds_14_tfemployeefirstname = AV63TFEmployeeFirstName;
         AV109Workhourlogwwds_15_tfemployeefirstname_sel = AV64TFEmployeeFirstName_Sel;
         AV110Workhourlogwwds_16_tfprojectname = AV50TFProjectName;
         AV111Workhourlogwwds_17_tfprojectname_sel = AV51TFProjectName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV88WorkHourLogDateOperator, AV90WorkHourLogDate, AV25ColumnsSelector, AV94Pgmname, AV89WorkHourLogDate_To, AV33TFWorkHourLogDate, AV34TFWorkHourLogDate_To, AV38TFWorkHourLogDuration, AV39TFWorkHourLogDuration_Sel, AV40TFWorkHourLogHour, AV41TFWorkHourLogHour_To, AV42TFWorkHourLogMinute, AV43TFWorkHourLogMinute_To, AV44TFWorkHourLogDescription, AV45TFWorkHourLogDescription_Sel, AV63TFEmployeeFirstName, AV64TFEmployeeFirstName_Sel, AV50TFProjectName, AV51TFProjectName_Sel, AV56IsAuthorized_Update, AV58IsAuthorized_Delete, AV62IsAuthorized_Insert, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV95Workhourlogwwds_1_filterfulltext = AV20FilterFullText;
         AV96Workhourlogwwds_2_workhourlogdate = AV90WorkHourLogDate;
         AV97Workhourlogwwds_3_workhourlogdate_to = AV89WorkHourLogDate_To;
         AV98Workhourlogwwds_4_tfworkhourlogdate = AV33TFWorkHourLogDate;
         AV99Workhourlogwwds_5_tfworkhourlogdate_to = AV34TFWorkHourLogDate_To;
         AV100Workhourlogwwds_6_tfworkhourlogduration = AV38TFWorkHourLogDuration;
         AV101Workhourlogwwds_7_tfworkhourlogduration_sel = AV39TFWorkHourLogDuration_Sel;
         AV102Workhourlogwwds_8_tfworkhourloghour = AV40TFWorkHourLogHour;
         AV103Workhourlogwwds_9_tfworkhourloghour_to = AV41TFWorkHourLogHour_To;
         AV104Workhourlogwwds_10_tfworkhourlogminute = AV42TFWorkHourLogMinute;
         AV105Workhourlogwwds_11_tfworkhourlogminute_to = AV43TFWorkHourLogMinute_To;
         AV106Workhourlogwwds_12_tfworkhourlogdescription = AV44TFWorkHourLogDescription;
         AV107Workhourlogwwds_13_tfworkhourlogdescription_sel = AV45TFWorkHourLogDescription_Sel;
         AV108Workhourlogwwds_14_tfemployeefirstname = AV63TFEmployeeFirstName;
         AV109Workhourlogwwds_15_tfemployeefirstname_sel = AV64TFEmployeeFirstName_Sel;
         AV110Workhourlogwwds_16_tfprojectname = AV50TFProjectName;
         AV111Workhourlogwwds_17_tfprojectname_sel = AV51TFProjectName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV88WorkHourLogDateOperator, AV90WorkHourLogDate, AV25ColumnsSelector, AV94Pgmname, AV89WorkHourLogDate_To, AV33TFWorkHourLogDate, AV34TFWorkHourLogDate_To, AV38TFWorkHourLogDuration, AV39TFWorkHourLogDuration_Sel, AV40TFWorkHourLogHour, AV41TFWorkHourLogHour_To, AV42TFWorkHourLogMinute, AV43TFWorkHourLogMinute_To, AV44TFWorkHourLogDescription, AV45TFWorkHourLogDescription_Sel, AV63TFEmployeeFirstName, AV64TFEmployeeFirstName_Sel, AV50TFProjectName, AV51TFProjectName_Sel, AV56IsAuthorized_Update, AV58IsAuthorized_Delete, AV62IsAuthorized_Insert, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV94Pgmname = "WorkHourLogWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtWorkHourLogId_Enabled = 0;
         edtWorkHourLogDate_Enabled = 0;
         edtWorkHourLogDuration_Enabled = 0;
         edtWorkHourLogHour_Enabled = 0;
         edtWorkHourLogMinute_Enabled = 0;
         edtWorkHourLogDescription_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtEmployeeFirstName_Enabled = 0;
         edtProjectId_Enabled = 0;
         edtProjectName_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E192X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV60AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV25ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_49 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_49"), ".", ","), 18, MidpointRounding.ToEven));
            AV66GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV67GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV9GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV90WorkHourLogDate = context.localUtil.CToD( cgiGet( "vWORKHOURLOGDATE"), 0);
            AV89WorkHourLogDate_To = context.localUtil.CToD( cgiGet( "vWORKHOURLOGDATE_TO"), 0);
            AV35DDO_WorkHourLogDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_WORKHOURLOGDATEAUXDATE"), 0);
            AV36DDO_WorkHourLogDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_WORKHOURLOGDATEAUXDATETO"), 0);
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
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
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
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV20FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV20FilterFullText", AV20FilterFullText);
            cmbavWorkhourlogdateoperator.Name = cmbavWorkhourlogdateoperator_Internalname;
            cmbavWorkhourlogdateoperator.CurrentValue = cgiGet( cmbavWorkhourlogdateoperator_Internalname);
            AV88WorkHourLogDateOperator = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavWorkhourlogdateoperator_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV88WorkHourLogDateOperator", StringUtil.LTrimStr( (decimal)(AV88WorkHourLogDateOperator), 4, 0));
            AV91WorkHourLogDate_RangeText = cgiGet( edtavWorkhourlogdate_rangetext_Internalname);
            AssignAttri("", false, "AV91WorkHourLogDate_RangeText", AV91WorkHourLogDate_RangeText);
            AV37DDO_WorkHourLogDateAuxDateText = cgiGet( edtavDdo_workhourlogdateauxdatetext_Internalname);
            AssignAttri("", false, "AV37DDO_WorkHourLogDateAuxDateText", AV37DDO_WorkHourLogDateAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV17OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV18OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV20FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vWORKHOURLOGDATEOPERATOR"), ".", ",") != Convert.ToDecimal( AV88WorkHourLogDateOperator )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vWORKHOURLOGDATE"), 2) ) != DateTimeUtil.ResetTime ( AV90WorkHourLogDate ) )
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
         E192X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E192X2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFWORKHOURLOGDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_workhourlogdateauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV60AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV61AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV61AGExportDataItem.gxTpr_Title = "Excel";
         AV61AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV61AGExportDataItem.gxTpr_Eventkey = "Export";
         AV61AGExportDataItem.gxTpr_Isdivider = false;
         AV60AGExportData.Add(AV61AGExportDataItem, 0);
         this.executeUsercontrolMethod("", false, "WORKHOURLOGDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavWorkhourlogdate_rangetext_Internalname});
         AV53GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV54GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV53GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Work Hour Log";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'UPDATEWORKHOURLOGDATEOPERATORVALUES' */
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
         if ( AV17OrderedBy < 1 )
         {
            AV17OrderedBy = 1;
            AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV52DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV52DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E202X2( )
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
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV27Session.Get("WorkHourLogWWColumnsSelector"), "") != 0 )
         {
            AV23ColumnsSelectorXML = AV27Session.Get("WorkHourLogWWColumnsSelector");
            AV25ColumnsSelector.FromXml(AV23ColumnsSelectorXML, null, "", "");
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
         edtWorkHourLogDate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWorkHourLogDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDate_Visible), 5, 0), !bGXsfl_49_Refreshing);
         edtWorkHourLogDuration_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWorkHourLogDuration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDuration_Visible), 5, 0), !bGXsfl_49_Refreshing);
         edtWorkHourLogHour_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWorkHourLogHour_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWorkHourLogHour_Visible), 5, 0), !bGXsfl_49_Refreshing);
         edtWorkHourLogMinute_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWorkHourLogMinute_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWorkHourLogMinute_Visible), 5, 0), !bGXsfl_49_Refreshing);
         edtWorkHourLogDescription_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWorkHourLogDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDescription_Visible), 5, 0), !bGXsfl_49_Refreshing);
         edtEmployeeFirstName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEmployeeFirstName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeFirstName_Visible), 5, 0), !bGXsfl_49_Refreshing);
         edtProjectName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV25ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtProjectName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProjectName_Visible), 5, 0), !bGXsfl_49_Refreshing);
         AV66GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV66GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV66GridCurrentPage), 10, 0));
         AV67GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV67GridPageCount", StringUtil.LTrimStr( (decimal)(AV67GridPageCount), 10, 0));
         GXt_char2 = AV9GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV94Pgmname, out  GXt_char2) ;
         AV9GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV9GridAppliedFilters", AV9GridAppliedFilters);
         AV95Workhourlogwwds_1_filterfulltext = AV20FilterFullText;
         AV96Workhourlogwwds_2_workhourlogdate = AV90WorkHourLogDate;
         AV97Workhourlogwwds_3_workhourlogdate_to = AV89WorkHourLogDate_To;
         AV98Workhourlogwwds_4_tfworkhourlogdate = AV33TFWorkHourLogDate;
         AV99Workhourlogwwds_5_tfworkhourlogdate_to = AV34TFWorkHourLogDate_To;
         AV100Workhourlogwwds_6_tfworkhourlogduration = AV38TFWorkHourLogDuration;
         AV101Workhourlogwwds_7_tfworkhourlogduration_sel = AV39TFWorkHourLogDuration_Sel;
         AV102Workhourlogwwds_8_tfworkhourloghour = AV40TFWorkHourLogHour;
         AV103Workhourlogwwds_9_tfworkhourloghour_to = AV41TFWorkHourLogHour_To;
         AV104Workhourlogwwds_10_tfworkhourlogminute = AV42TFWorkHourLogMinute;
         AV105Workhourlogwwds_11_tfworkhourlogminute_to = AV43TFWorkHourLogMinute_To;
         AV106Workhourlogwwds_12_tfworkhourlogdescription = AV44TFWorkHourLogDescription;
         AV107Workhourlogwwds_13_tfworkhourlogdescription_sel = AV45TFWorkHourLogDescription_Sel;
         AV108Workhourlogwwds_14_tfemployeefirstname = AV63TFEmployeeFirstName;
         AV109Workhourlogwwds_15_tfemployeefirstname_sel = AV64TFEmployeeFirstName_Sel;
         AV110Workhourlogwwds_16_tfprojectname = AV50TFProjectName;
         AV111Workhourlogwwds_17_tfprojectname_sel = AV51TFProjectName_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
      }

      protected void E112X2( )
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
            AV65PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV65PageToGo) ;
         }
      }

      protected void E122X2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E152X2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV17OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
            AV18OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogDate") == 0 )
            {
               AV33TFWorkHourLogDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV33TFWorkHourLogDate", context.localUtil.Format(AV33TFWorkHourLogDate, "99/99/99"));
               AV34TFWorkHourLogDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV34TFWorkHourLogDate_To", context.localUtil.Format(AV34TFWorkHourLogDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogDuration") == 0 )
            {
               AV38TFWorkHourLogDuration = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV38TFWorkHourLogDuration", AV38TFWorkHourLogDuration);
               AV39TFWorkHourLogDuration_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV39TFWorkHourLogDuration_Sel", AV39TFWorkHourLogDuration_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogHour") == 0 )
            {
               AV40TFWorkHourLogHour = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV40TFWorkHourLogHour", StringUtil.LTrimStr( (decimal)(AV40TFWorkHourLogHour), 4, 0));
               AV41TFWorkHourLogHour_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFWorkHourLogHour_To", StringUtil.LTrimStr( (decimal)(AV41TFWorkHourLogHour_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogMinute") == 0 )
            {
               AV42TFWorkHourLogMinute = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFWorkHourLogMinute", StringUtil.LTrimStr( (decimal)(AV42TFWorkHourLogMinute), 4, 0));
               AV43TFWorkHourLogMinute_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFWorkHourLogMinute_To", StringUtil.LTrimStr( (decimal)(AV43TFWorkHourLogMinute_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogDescription") == 0 )
            {
               AV44TFWorkHourLogDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFWorkHourLogDescription", AV44TFWorkHourLogDescription);
               AV45TFWorkHourLogDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFWorkHourLogDescription_Sel", AV45TFWorkHourLogDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeFirstName") == 0 )
            {
               AV63TFEmployeeFirstName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV63TFEmployeeFirstName", AV63TFEmployeeFirstName);
               AV64TFEmployeeFirstName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV64TFEmployeeFirstName_Sel", AV64TFEmployeeFirstName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProjectName") == 0 )
            {
               AV50TFProjectName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFProjectName", AV50TFProjectName);
               AV51TFProjectName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFProjectName_Sel", AV51TFProjectName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E212X2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV55Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV55Update);
         if ( AV56IsAuthorized_Update )
         {
            edtavUpdate_Link = formatLink("workhourlog.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A118WorkHourLogId,10,0))}, new string[] {"Mode","WorkHourLogId"}) ;
         }
         AV57Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV57Delete);
         if ( AV58IsAuthorized_Delete )
         {
            edtavDelete_Link = formatLink("workhourlog.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A118WorkHourLogId,10,0))}, new string[] {"Mode","WorkHourLogId"}) ;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 49;
         }
         sendrow_492( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_49_Refreshing )
         {
            DoAjaxLoad(49, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E162X2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV23ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV25ColumnsSelector.FromJSonString(AV23ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WorkHourLogWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV23ColumnsSelectorXML)) ? "" : AV25ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
      }

      protected void E172X2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV62IsAuthorized_Insert )
         {
            CallWebObject(formatLink("workhourlog.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","WorkHourLogId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
      }

      protected void E132X2( )
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
         /*  Sending Event outputs  */
         cmbavWorkhourlogdateoperator.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV88WorkHourLogDateOperator), 4, 0));
         AssignProp("", false, cmbavWorkhourlogdateoperator_Internalname, "Values", cmbavWorkhourlogdateoperator.ToJavascriptSource(), true);
      }

      protected void E182X2( )
      {
         /* Workhourlogdateoperator_Click Routine */
         returnInSub = false;
         AV90WorkHourLogDate = DateTime.MinValue;
         AssignAttri("", false, "AV90WorkHourLogDate", context.localUtil.Format(AV90WorkHourLogDate, "99/99/99"));
         AV89WorkHourLogDate_To = DateTime.MinValue;
         AssignAttri("", false, "AV89WorkHourLogDate_To", context.localUtil.Format(AV89WorkHourLogDate_To, "99/99/99"));
         /* Execute user subroutine: 'UPDATEWORKHOURLOGDATEOPERATORVALUES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV88WorkHourLogDateOperator, AV90WorkHourLogDate, AV25ColumnsSelector, AV94Pgmname, AV89WorkHourLogDate_To, AV33TFWorkHourLogDate, AV34TFWorkHourLogDate_To, AV38TFWorkHourLogDuration, AV39TFWorkHourLogDuration_Sel, AV40TFWorkHourLogHour, AV41TFWorkHourLogHour_To, AV42TFWorkHourLogMinute, AV43TFWorkHourLogMinute_To, AV44TFWorkHourLogDescription, AV45TFWorkHourLogDescription_Sel, AV63TFEmployeeFirstName, AV64TFEmployeeFirstName_Sel, AV50TFProjectName, AV51TFProjectName_Sel, AV56IsAuthorized_Update, AV58IsAuthorized_Delete, AV62IsAuthorized_Insert, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
      }

      protected void E142X2( )
      {
         /* Workhourlogdate_rangepicker_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV90WorkHourLogDate", context.localUtil.Format(AV90WorkHourLogDate, "99/99/99"));
         AssignAttri("", false, "AV89WorkHourLogDate_To", context.localUtil.Format(AV89WorkHourLogDate_To, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV20FilterFullText, AV88WorkHourLogDateOperator, AV90WorkHourLogDate, AV25ColumnsSelector, AV94Pgmname, AV89WorkHourLogDate_To, AV33TFWorkHourLogDate, AV34TFWorkHourLogDate_To, AV38TFWorkHourLogDuration, AV39TFWorkHourLogDuration_Sel, AV40TFWorkHourLogHour, AV41TFWorkHourLogHour_To, AV42TFWorkHourLogMinute, AV43TFWorkHourLogMinute_To, AV44TFWorkHourLogDescription, AV45TFWorkHourLogDescription_Sel, AV63TFEmployeeFirstName, AV64TFEmployeeFirstName_Sel, AV50TFProjectName, AV51TFProjectName_Sel, AV56IsAuthorized_Update, AV58IsAuthorized_Delete, AV62IsAuthorized_Insert, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25ColumnsSelector", AV25ColumnsSelector);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV17OrderedBy), 4, 0))+":"+(AV18OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV25ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "WorkHourLogDate",  "",  "Log Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "WorkHourLogDuration",  "",  "Log Duration",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "WorkHourLogHour",  "",  "Log Hour",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "WorkHourLogMinute",  "",  "Log Minute",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "WorkHourLogDescription",  "",  "Log Description",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "EmployeeFirstName",  "",  "First Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV25ColumnsSelector,  "ProjectName",  "",  "Name",  true,  "") ;
         GXt_char2 = AV24UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WorkHourLogWWColumnsSelector", out  GXt_char2) ;
         AV24UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV24UserCustomValue)) ) )
         {
            AV26ColumnsSelectorAux.FromXml(AV24UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV26ColumnsSelectorAux, ref  AV25ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV56IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "workhourlog_Update", out  GXt_boolean3) ;
         AV56IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV56IsAuthorized_Update", AV56IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV56IsAuthorized_Update, context));
         if ( ! ( AV56IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_49_Refreshing);
         }
         GXt_boolean3 = AV58IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "workhourlog_Delete", out  GXt_boolean3) ;
         AV58IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV58IsAuthorized_Delete", AV58IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV58IsAuthorized_Delete, context));
         if ( ! ( AV58IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_49_Refreshing);
         }
         GXt_boolean3 = AV62IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "workhourlog_Insert", out  GXt_boolean3) ;
         AV62IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV62IsAuthorized_Insert", AV62IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV62IsAuthorized_Insert, context));
         if ( ! ( AV62IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get(AV94Pgmname+"GridState"), "") == 0 )
         {
            AV15GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV94Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV15GridState.FromXml(AV27Session.Get(AV94Pgmname+"GridState"), null, "", "");
         }
         AV17OrderedBy = AV15GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
         AV18OrderedDsc = AV15GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV112GXV1 = 1;
         while ( AV112GXV1 <= AV15GridState.gxTpr_Filtervalues.Count )
         {
            AV16GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV15GridState.gxTpr_Filtervalues.Item(AV112GXV1));
            if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV20FilterFullText = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20FilterFullText", AV20FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "WORKHOURLOGDATE") == 0 )
            {
               AV90WorkHourLogDate = context.localUtil.CToD( AV16GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV90WorkHourLogDate", context.localUtil.Format(AV90WorkHourLogDate, "99/99/99"));
               AV88WorkHourLogDateOperator = AV16GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV88WorkHourLogDateOperator", StringUtil.LTrimStr( (decimal)(AV88WorkHourLogDateOperator), 4, 0));
               AV89WorkHourLogDate_To = context.localUtil.CToD( AV16GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV89WorkHourLogDate_To", context.localUtil.Format(AV89WorkHourLogDate_To, "99/99/99"));
               /* Execute user subroutine: 'UPDATEWORKHOURLOGDATEOPERATORVALUES' */
               S122 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV33TFWorkHourLogDate = context.localUtil.CToD( AV16GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV33TFWorkHourLogDate", context.localUtil.Format(AV33TFWorkHourLogDate, "99/99/99"));
               AV34TFWorkHourLogDate_To = context.localUtil.CToD( AV16GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV34TFWorkHourLogDate_To", context.localUtil.Format(AV34TFWorkHourLogDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV38TFWorkHourLogDuration = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFWorkHourLogDuration", AV38TFWorkHourLogDuration);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV39TFWorkHourLogDuration_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFWorkHourLogDuration_Sel", AV39TFWorkHourLogDuration_Sel);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGHOUR") == 0 )
            {
               AV40TFWorkHourLogHour = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV40TFWorkHourLogHour", StringUtil.LTrimStr( (decimal)(AV40TFWorkHourLogHour), 4, 0));
               AV41TFWorkHourLogHour_To = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFWorkHourLogHour_To", StringUtil.LTrimStr( (decimal)(AV41TFWorkHourLogHour_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGMINUTE") == 0 )
            {
               AV42TFWorkHourLogMinute = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFWorkHourLogMinute", StringUtil.LTrimStr( (decimal)(AV42TFWorkHourLogMinute), 4, 0));
               AV43TFWorkHourLogMinute_To = (short)(Math.Round(NumberUtil.Val( AV16GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFWorkHourLogMinute_To", StringUtil.LTrimStr( (decimal)(AV43TFWorkHourLogMinute_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV44TFWorkHourLogDescription = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFWorkHourLogDescription", AV44TFWorkHourLogDescription);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV45TFWorkHourLogDescription_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFWorkHourLogDescription_Sel", AV45TFWorkHourLogDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME") == 0 )
            {
               AV63TFEmployeeFirstName = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFEmployeeFirstName", AV63TFEmployeeFirstName);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME_SEL") == 0 )
            {
               AV64TFEmployeeFirstName_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFEmployeeFirstName_Sel", AV64TFEmployeeFirstName_Sel);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV50TFProjectName = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFProjectName", AV50TFProjectName);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV51TFProjectName_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFProjectName_Sel", AV51TFProjectName_Sel);
            }
            AV112GXV1 = (int)(AV112GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFWorkHourLogDuration_Sel)),  AV39TFWorkHourLogDuration_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFWorkHourLogDescription_Sel)),  AV45TFWorkHourLogDescription_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFEmployeeFirstName_Sel)),  AV64TFEmployeeFirstName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProjectName_Sel)),  AV51TFProjectName_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|||"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWorkHourLogDuration)),  AV38TFWorkHourLogDuration, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFWorkHourLogDescription)),  AV44TFWorkHourLogDescription, out  GXt_char5) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFEmployeeFirstName)),  AV63TFEmployeeFirstName, out  GXt_char4) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProjectName)),  AV50TFProjectName, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((DateTime.MinValue==AV33TFWorkHourLogDate) ? "" : context.localUtil.DToC( AV33TFWorkHourLogDate, 2, "/"))+"|"+GXt_char6+"|"+((0==AV40TFWorkHourLogHour) ? "" : StringUtil.Str( (decimal)(AV40TFWorkHourLogHour), 4, 0))+"|"+((0==AV42TFWorkHourLogMinute) ? "" : StringUtil.Str( (decimal)(AV42TFWorkHourLogMinute), 4, 0))+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((DateTime.MinValue==AV34TFWorkHourLogDate_To) ? "" : context.localUtil.DToC( AV34TFWorkHourLogDate_To, 2, "/"))+"||"+((0==AV41TFWorkHourLogHour_To) ? "" : StringUtil.Str( (decimal)(AV41TFWorkHourLogHour_To), 4, 0))+"|"+((0==AV43TFWorkHourLogMinute_To) ? "" : StringUtil.Str( (decimal)(AV43TFWorkHourLogMinute_To), 4, 0))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV15GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV15GridState.gxTpr_Currentpage) ;
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV15GridState.FromXml(AV27Session.Get(AV94Pgmname+"GridState"), null, "", "");
         AV15GridState.gxTpr_Orderedby = AV17OrderedBy;
         AV15GridState.gxTpr_Ordereddsc = AV18OrderedDsc;
         AV15GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20FilterFullText)),  0,  AV20FilterFullText,  AV20FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "WORKHOURLOGDATE",  "Log Date",  !((DateTime.MinValue==AV90WorkHourLogDate)&&(DateTime.MinValue==AV89WorkHourLogDate_To)),  AV88WorkHourLogDateOperator,  StringUtil.Trim( context.localUtil.DToC( AV90WorkHourLogDate, 2, "/")),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV88WorkHourLogDateOperator+1), 10, 0)), "Past", "Today", "This week", "This month", "Range"+" "+StringUtil.Trim( context.localUtil.Format( AV90WorkHourLogDate, "99/99/99")), "", "", "", ""),  (AV88WorkHourLogDateOperator==4),  StringUtil.Trim( context.localUtil.DToC( AV89WorkHourLogDate_To, 2, "/")),  StringUtil.Trim( context.localUtil.Format( AV89WorkHourLogDate_To, "99/99/99"))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "TFWORKHOURLOGDATE",  "Log Date",  !((DateTime.MinValue==AV33TFWorkHourLogDate)&&(DateTime.MinValue==AV34TFWorkHourLogDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV33TFWorkHourLogDate, 2, "/")),  ((DateTime.MinValue==AV33TFWorkHourLogDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV33TFWorkHourLogDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV34TFWorkHourLogDate_To, 2, "/")),  ((DateTime.MinValue==AV34TFWorkHourLogDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV34TFWorkHourLogDate_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFWORKHOURLOGDURATION",  "Log Duration",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWorkHourLogDuration)),  0,  AV38TFWorkHourLogDuration,  AV38TFWorkHourLogDuration,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFWorkHourLogDuration_Sel)),  AV39TFWorkHourLogDuration_Sel,  AV39TFWorkHourLogDuration_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "TFWORKHOURLOGHOUR",  "Log Hour",  !((0==AV40TFWorkHourLogHour)&&(0==AV41TFWorkHourLogHour_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV40TFWorkHourLogHour), 4, 0)),  ((0==AV40TFWorkHourLogHour) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV40TFWorkHourLogHour), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV41TFWorkHourLogHour_To), 4, 0)),  ((0==AV41TFWorkHourLogHour_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV41TFWorkHourLogHour_To), "ZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "TFWORKHOURLOGMINUTE",  "Log Minute",  !((0==AV42TFWorkHourLogMinute)&&(0==AV43TFWorkHourLogMinute_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV42TFWorkHourLogMinute), 4, 0)),  ((0==AV42TFWorkHourLogMinute) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV42TFWorkHourLogMinute), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFWorkHourLogMinute_To), 4, 0)),  ((0==AV43TFWorkHourLogMinute_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV43TFWorkHourLogMinute_To), "ZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFWORKHOURLOGDESCRIPTION",  "Log Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFWorkHourLogDescription)),  0,  AV44TFWorkHourLogDescription,  AV44TFWorkHourLogDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFWorkHourLogDescription_Sel)),  AV45TFWorkHourLogDescription_Sel,  AV45TFWorkHourLogDescription_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFEMPLOYEEFIRSTNAME",  "First Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFEmployeeFirstName)),  0,  AV63TFEmployeeFirstName,  AV63TFEmployeeFirstName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFEmployeeFirstName_Sel)),  AV64TFEmployeeFirstName_Sel,  AV64TFEmployeeFirstName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFPROJECTNAME",  "Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFProjectName)),  0,  AV50TFProjectName,  AV50TFProjectName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProjectName_Sel)),  AV51TFProjectName_Sel,  AV51TFProjectName_Sel) ;
         AV15GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV15GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV94Pgmname+"GridState",  AV15GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV13TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV13TrnContext.gxTpr_Callerobject = AV94Pgmname;
         AV13TrnContext.gxTpr_Callerondelete = true;
         AV13TrnContext.gxTpr_Callerurl = AV12HTTPRequest.ScriptName+"?"+AV12HTTPRequest.QueryString;
         AV13TrnContext.gxTpr_Transactionname = "WorkHourLog";
         AV27Session.Set("TrnContext", AV13TrnContext.ToXml(false, true, "", ""));
      }

      protected void S182( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new workhourlogwwexport(context ).execute( out  AV21ExcelFilename, out  AV22ErrorMessage) ;
         if ( StringUtil.StrCmp(AV21ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV21ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV22ErrorMessage);
         }
      }

      protected void S122( )
      {
         /* 'UPDATEWORKHOURLOGDATEOPERATORVALUES' Routine */
         returnInSub = false;
         cellWorkhourlogdate_range_cell_Class = "Invisible";
         AssignProp("", false, cellWorkhourlogdate_range_cell_Internalname, "Class", cellWorkhourlogdate_range_cell_Class, true);
         if ( AV88WorkHourLogDateOperator == 0 )
         {
            AV90WorkHourLogDate = Gx_date;
            AssignAttri("", false, "AV90WorkHourLogDate", context.localUtil.Format(AV90WorkHourLogDate, "99/99/99"));
         }
         else if ( AV88WorkHourLogDateOperator == 1 )
         {
            AV90WorkHourLogDate = Gx_date;
            AssignAttri("", false, "AV90WorkHourLogDate", context.localUtil.Format(AV90WorkHourLogDate, "99/99/99"));
         }
         else if ( AV88WorkHourLogDateOperator == 2 )
         {
            AV90WorkHourLogDate = DateTimeUtil.DAdd( Gx_date, (-DateTimeUtil.Dow( Gx_date)));
            AssignAttri("", false, "AV90WorkHourLogDate", context.localUtil.Format(AV90WorkHourLogDate, "99/99/99"));
            AV89WorkHourLogDate_To = DateTimeUtil.DAdd( Gx_date, (7-DateTimeUtil.Dow( Gx_date)));
            AssignAttri("", false, "AV89WorkHourLogDate_To", context.localUtil.Format(AV89WorkHourLogDate_To, "99/99/99"));
         }
         else if ( AV88WorkHourLogDateOperator == 3 )
         {
            AV90WorkHourLogDate = DateTimeUtil.DAdd( Gx_date, (-DateTimeUtil.Day( Gx_date)));
            AssignAttri("", false, "AV90WorkHourLogDate", context.localUtil.Format(AV90WorkHourLogDate, "99/99/99"));
            AV89WorkHourLogDate_To = DateTimeUtil.DateEndOfMonth( Gx_date);
            AssignAttri("", false, "AV89WorkHourLogDate_To", context.localUtil.Format(AV89WorkHourLogDate_To, "99/99/99"));
         }
         else if ( AV88WorkHourLogDateOperator == 4 )
         {
            cellWorkhourlogdate_range_cell_Class = "";
            AssignProp("", false, cellWorkhourlogdate_range_cell_Internalname, "Class", cellWorkhourlogdate_range_cell_Class, true);
         }
      }

      protected void wb_table1_33_2X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedworkhourlogdate_Internalname, tblTablemergedworkhourlogdate_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWorkhourlogdateoperator_Internalname, "Work Hour Log Date Operator", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_49_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWorkhourlogdateoperator, cmbavWorkhourlogdateoperator_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV88WorkHourLogDateOperator), 4, 0)), 1, cmbavWorkhourlogdateoperator_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVWORKHOURLOGDATEOPERATOR.CLICK."+"'", "int", "", 1, cmbavWorkhourlogdateoperator.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_WorkHourLogWW.htm");
            cmbavWorkhourlogdateoperator.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV88WorkHourLogDateOperator), 4, 0));
            AssignProp("", false, cmbavWorkhourlogdateoperator_Internalname, "Values", (string)(cmbavWorkhourlogdateoperator.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellWorkhourlogdate_range_cell_Internalname+"\"  class='"+cellWorkhourlogdate_range_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWorkhourlogdate_rangetext_Internalname, "Work Hour Log Date_Range Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWorkhourlogdate_rangetext_Internalname, AV91WorkHourLogDate_RangeText, StringUtil.RTrim( context.localUtil.Format( AV91WorkHourLogDate_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavWorkhourlogdate_rangetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWorkhourlogdate_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkHourLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_33_2X2e( true) ;
         }
         else
         {
            wb_table1_33_2X2e( false) ;
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
         PA2X2( ) ;
         WS2X2( ) ;
         WE2X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256275283712", true, true);
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
         context.AddJavascriptSource("workhourlogww.js", "?20256275283717", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_492( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_49_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_49_idx;
         edtWorkHourLogId_Internalname = "WORKHOURLOGID_"+sGXsfl_49_idx;
         edtWorkHourLogDate_Internalname = "WORKHOURLOGDATE_"+sGXsfl_49_idx;
         edtWorkHourLogDuration_Internalname = "WORKHOURLOGDURATION_"+sGXsfl_49_idx;
         edtWorkHourLogHour_Internalname = "WORKHOURLOGHOUR_"+sGXsfl_49_idx;
         edtWorkHourLogMinute_Internalname = "WORKHOURLOGMINUTE_"+sGXsfl_49_idx;
         edtWorkHourLogDescription_Internalname = "WORKHOURLOGDESCRIPTION_"+sGXsfl_49_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_49_idx;
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME_"+sGXsfl_49_idx;
         edtProjectId_Internalname = "PROJECTID_"+sGXsfl_49_idx;
         edtProjectName_Internalname = "PROJECTNAME_"+sGXsfl_49_idx;
      }

      protected void SubsflControlProps_fel_492( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_49_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_49_fel_idx;
         edtWorkHourLogId_Internalname = "WORKHOURLOGID_"+sGXsfl_49_fel_idx;
         edtWorkHourLogDate_Internalname = "WORKHOURLOGDATE_"+sGXsfl_49_fel_idx;
         edtWorkHourLogDuration_Internalname = "WORKHOURLOGDURATION_"+sGXsfl_49_fel_idx;
         edtWorkHourLogHour_Internalname = "WORKHOURLOGHOUR_"+sGXsfl_49_fel_idx;
         edtWorkHourLogMinute_Internalname = "WORKHOURLOGMINUTE_"+sGXsfl_49_fel_idx;
         edtWorkHourLogDescription_Internalname = "WORKHOURLOGDESCRIPTION_"+sGXsfl_49_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_49_fel_idx;
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME_"+sGXsfl_49_fel_idx;
         edtProjectId_Internalname = "PROJECTID_"+sGXsfl_49_fel_idx;
         edtProjectName_Internalname = "PROJECTNAME_"+sGXsfl_49_fel_idx;
      }

      protected void sendrow_492( )
      {
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_492( ) ;
         WB2X0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_49_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_49_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_49_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_49_idx + "',49)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV55Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_49_idx + "',49)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV57Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWorkHourLogDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDate_Internalname,context.localUtil.Format(A119WorkHourLogDate, "99/99/99"),context.localUtil.Format( A119WorkHourLogDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWorkHourLogDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWorkHourLogDuration_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDuration_Internalname,(string)A120WorkHourLogDuration,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDuration_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWorkHourLogDuration_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWorkHourLogHour_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogHour_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121WorkHourLogHour), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogHour_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWorkHourLogHour_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWorkHourLogMinute_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogMinute_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A122WorkHourLogMinute), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogMinute_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWorkHourLogMinute_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWorkHourLogDescription_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDescription_Internalname,(string)A123WorkHourLogDescription,(string)A123WorkHourLogDescription,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWorkHourLogDescription_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)49,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEmployeeFirstName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeFirstName_Internalname,StringUtil.RTrim( A107EmployeeFirstName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeFirstName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEmployeeFirstName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProjectId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProjectId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtProjectName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProjectName_Internalname,StringUtil.RTrim( A103ProjectName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProjectName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtProjectName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2X2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_49_idx = ((subGrid_Islastpage==1)&&(nGXsfl_49_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_49_idx+1);
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         /* End function sendrow_492 */
      }

      protected void init_web_controls( )
      {
         cmbavWorkhourlogdateoperator.Name = "vWORKHOURLOGDATEOPERATOR";
         cmbavWorkhourlogdateoperator.WebTags = "";
         cmbavWorkhourlogdateoperator.addItem("0", "Past", 0);
         cmbavWorkhourlogdateoperator.addItem("1", "Today", 0);
         cmbavWorkhourlogdateoperator.addItem("2", "This week", 0);
         cmbavWorkhourlogdateoperator.addItem("3", "This month", 0);
         cmbavWorkhourlogdateoperator.addItem("4", "Range", 0);
         if ( cmbavWorkhourlogdateoperator.ItemCount > 0 )
         {
            AV88WorkHourLogDateOperator = (short)(Math.Round(NumberUtil.Val( cmbavWorkhourlogdateoperator.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV88WorkHourLogDateOperator), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV88WorkHourLogDateOperator", StringUtil.LTrimStr( (decimal)(AV88WorkHourLogDateOperator), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl49( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"49\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWorkHourLogDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Log Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWorkHourLogDuration_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Log Duration") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWorkHourLogHour_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Log Hour") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWorkHourLogMinute_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Log Minute") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWorkHourLogDescription_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Log Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeFirstName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "First Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtProjectName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV55Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV57Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A119WorkHourLogDate, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWorkHourLogDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A120WorkHourLogDuration));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWorkHourLogDuration_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWorkHourLogHour_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWorkHourLogMinute_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A123WorkHourLogDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWorkHourLogDescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EmployeeFirstName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeFirstName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A103ProjectName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProjectName_Visible), 5, 0, ".", "")));
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
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         lblFiltertextworkhourlogdate_Internalname = "FILTERTEXTWORKHOURLOGDATE";
         cmbavWorkhourlogdateoperator_Internalname = "vWORKHOURLOGDATEOPERATOR";
         edtavWorkhourlogdate_rangetext_Internalname = "vWORKHOURLOGDATE_RANGETEXT";
         cellWorkhourlogdate_range_cell_Internalname = "WORKHOURLOGDATE_RANGE_CELL";
         tblTablemergedworkhourlogdate_Internalname = "TABLEMERGEDWORKHOURLOGDATE";
         divTablesplittedfiltertextworkhourlogdate_Internalname = "TABLESPLITTEDFILTERTEXTWORKHOURLOGDATE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtWorkHourLogId_Internalname = "WORKHOURLOGID";
         edtWorkHourLogDate_Internalname = "WORKHOURLOGDATE";
         edtWorkHourLogDuration_Internalname = "WORKHOURLOGDURATION";
         edtWorkHourLogHour_Internalname = "WORKHOURLOGHOUR";
         edtWorkHourLogMinute_Internalname = "WORKHOURLOGMINUTE";
         edtWorkHourLogDescription_Internalname = "WORKHOURLOGDESCRIPTION";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME";
         edtProjectId_Internalname = "PROJECTID";
         edtProjectName_Internalname = "PROJECTNAME";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Workhourlogdate_rangepicker_Internalname = "WORKHOURLOGDATE_RANGEPICKER";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_workhourlogdateauxdatetext_Internalname = "vDDO_WORKHOURLOGDATEAUXDATETEXT";
         Tfworkhourlogdate_rangepicker_Internalname = "TFWORKHOURLOGDATE_RANGEPICKER";
         divDdo_workhourlogdateauxdates_Internalname = "DDO_WORKHOURLOGDATEAUXDATES";
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
         edtProjectName_Jsonclick = "";
         edtProjectId_Jsonclick = "";
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeId_Jsonclick = "";
         edtWorkHourLogDescription_Jsonclick = "";
         edtWorkHourLogMinute_Jsonclick = "";
         edtWorkHourLogHour_Jsonclick = "";
         edtWorkHourLogDuration_Jsonclick = "";
         edtWorkHourLogDate_Jsonclick = "";
         edtWorkHourLogId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavWorkhourlogdate_rangetext_Jsonclick = "";
         edtavWorkhourlogdate_rangetext_Enabled = 1;
         cellWorkhourlogdate_range_cell_Class = "";
         cmbavWorkhourlogdateoperator_Jsonclick = "";
         cmbavWorkhourlogdateoperator.Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtProjectName_Visible = -1;
         edtEmployeeFirstName_Visible = -1;
         edtWorkHourLogDescription_Visible = -1;
         edtWorkHourLogMinute_Visible = -1;
         edtWorkHourLogHour_Visible = -1;
         edtWorkHourLogDuration_Visible = -1;
         edtWorkHourLogDate_Visible = -1;
         edtProjectName_Enabled = 0;
         edtProjectId_Enabled = 0;
         edtEmployeeFirstName_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtWorkHourLogDescription_Enabled = 0;
         edtWorkHourLogMinute_Enabled = 0;
         edtWorkHourLogHour_Enabled = 0;
         edtWorkHourLogDuration_Enabled = 0;
         edtWorkHourLogDate_Enabled = 0;
         edtWorkHourLogId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_workhourlogdateauxdatetext_Jsonclick = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Select columns";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "||4.0|4.0|||";
         Ddo_grid_Datalistproc = "WorkHourLogWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|||Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "|T|||T|T|T";
         Ddo_grid_Filterisrange = "P||T|T|||";
         Ddo_grid_Filtertype = "Date|Character|Numeric|Numeric|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7";
         Ddo_grid_Columnids = "3:WorkHourLogDate|4:WorkHourLogDuration|5:WorkHourLogHour|6:WorkHourLogMinute|7:WorkHourLogDescription|9:EmployeeFirstName|11:ProjectName";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Work Hour Log";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"cmbavWorkhourlogdateoperator"},{"av":"AV88WorkHourLogDateOperator","fld":"vWORKHOURLOGDATEOPERATOR","pic":"ZZZ9"},{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWorkHourLogDate_Visible","ctrl":"WORKHOURLOGDATE","prop":"Visible"},{"av":"edtWorkHourLogDuration_Visible","ctrl":"WORKHOURLOGDURATION","prop":"Visible"},{"av":"edtWorkHourLogHour_Visible","ctrl":"WORKHOURLOGHOUR","prop":"Visible"},{"av":"edtWorkHourLogMinute_Visible","ctrl":"WORKHOURLOGMINUTE","prop":"Visible"},{"av":"edtWorkHourLogDescription_Visible","ctrl":"WORKHOURLOGDESCRIPTION","prop":"Visible"},{"av":"edtEmployeeFirstName_Visible","ctrl":"EMPLOYEEFIRSTNAME","prop":"Visible"},{"av":"edtProjectName_Visible","ctrl":"PROJECTNAME","prop":"Visible"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E112X2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"cmbavWorkhourlogdateoperator"},{"av":"AV88WorkHourLogDateOperator","fld":"vWORKHOURLOGDATEOPERATOR","pic":"ZZZ9"},{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E122X2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"cmbavWorkhourlogdateoperator"},{"av":"AV88WorkHourLogDateOperator","fld":"vWORKHOURLOGDATEOPERATOR","pic":"ZZZ9"},{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E152X2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"cmbavWorkhourlogdateoperator"},{"av":"AV88WorkHourLogDateOperator","fld":"vWORKHOURLOGDATEOPERATOR","pic":"ZZZ9"},{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E212X2","iparms":[{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A118WorkHourLogId","fld":"WORKHOURLOGID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV55Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV57Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E162X2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"cmbavWorkhourlogdateoperator"},{"av":"AV88WorkHourLogDateOperator","fld":"vWORKHOURLOGDATEOPERATOR","pic":"ZZZ9"},{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWorkHourLogDate_Visible","ctrl":"WORKHOURLOGDATE","prop":"Visible"},{"av":"edtWorkHourLogDuration_Visible","ctrl":"WORKHOURLOGDURATION","prop":"Visible"},{"av":"edtWorkHourLogHour_Visible","ctrl":"WORKHOURLOGHOUR","prop":"Visible"},{"av":"edtWorkHourLogMinute_Visible","ctrl":"WORKHOURLOGMINUTE","prop":"Visible"},{"av":"edtWorkHourLogDescription_Visible","ctrl":"WORKHOURLOGDESCRIPTION","prop":"Visible"},{"av":"edtEmployeeFirstName_Visible","ctrl":"EMPLOYEEFIRSTNAME","prop":"Visible"},{"av":"edtProjectName_Visible","ctrl":"PROJECTNAME","prop":"Visible"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E172X2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"cmbavWorkhourlogdateoperator"},{"av":"AV88WorkHourLogDateOperator","fld":"vWORKHOURLOGDATEOPERATOR","pic":"ZZZ9"},{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"A118WorkHourLogId","fld":"WORKHOURLOGID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWorkHourLogDate_Visible","ctrl":"WORKHOURLOGDATE","prop":"Visible"},{"av":"edtWorkHourLogDuration_Visible","ctrl":"WORKHOURLOGDURATION","prop":"Visible"},{"av":"edtWorkHourLogHour_Visible","ctrl":"WORKHOURLOGHOUR","prop":"Visible"},{"av":"edtWorkHourLogMinute_Visible","ctrl":"WORKHOURLOGMINUTE","prop":"Visible"},{"av":"edtWorkHourLogDescription_Visible","ctrl":"WORKHOURLOGDESCRIPTION","prop":"Visible"},{"av":"edtEmployeeFirstName_Visible","ctrl":"EMPLOYEEFIRSTNAME","prop":"Visible"},{"av":"edtProjectName_Visible","ctrl":"PROJECTNAME","prop":"Visible"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","""{"handler":"E132X2","iparms":[{"av":"Ddo_agexport_Activeeventkey","ctrl":"DDO_AGEXPORT","prop":"ActiveEventKey"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"cmbavWorkhourlogdateoperator"},{"av":"AV88WorkHourLogDateOperator","fld":"vWORKHOURLOGDATEOPERATOR","pic":"ZZZ9"},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",""","oparms":[{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"cmbavWorkhourlogdateoperator"},{"av":"AV88WorkHourLogDateOperator","fld":"vWORKHOURLOGDATEOPERATOR","pic":"ZZZ9"},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"cellWorkhourlogdate_range_cell_Class","ctrl":"WORKHOURLOGDATE_RANGE_CELL","prop":"Class"}]}""");
         setEventMetadata("VWORKHOURLOGDATEOPERATOR.CLICK","""{"handler":"E182X2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"cmbavWorkhourlogdateoperator"},{"av":"AV88WorkHourLogDateOperator","fld":"vWORKHOURLOGDATEOPERATOR","pic":"ZZZ9"},{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("VWORKHOURLOGDATEOPERATOR.CLICK",""","oparms":[{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"cellWorkhourlogdate_range_cell_Class","ctrl":"WORKHOURLOGDATE_RANGE_CELL","prop":"Class"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWorkHourLogDate_Visible","ctrl":"WORKHOURLOGDATE","prop":"Visible"},{"av":"edtWorkHourLogDuration_Visible","ctrl":"WORKHOURLOGDURATION","prop":"Visible"},{"av":"edtWorkHourLogHour_Visible","ctrl":"WORKHOURLOGHOUR","prop":"Visible"},{"av":"edtWorkHourLogMinute_Visible","ctrl":"WORKHOURLOGMINUTE","prop":"Visible"},{"av":"edtWorkHourLogDescription_Visible","ctrl":"WORKHOURLOGDESCRIPTION","prop":"Visible"},{"av":"edtEmployeeFirstName_Visible","ctrl":"EMPLOYEEFIRSTNAME","prop":"Visible"},{"av":"edtProjectName_Visible","ctrl":"PROJECTNAME","prop":"Visible"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("WORKHOURLOGDATE_RANGEPICKER.DATERANGECHANGED","""{"handler":"E142X2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"cmbavWorkhourlogdateoperator"},{"av":"AV88WorkHourLogDateOperator","fld":"vWORKHOURLOGDATEOPERATOR","pic":"ZZZ9"},{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"AV33TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV34TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV38TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV39TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV40TFWorkHourLogHour","fld":"vTFWORKHOURLOGHOUR","pic":"ZZZ9"},{"av":"AV41TFWorkHourLogHour_To","fld":"vTFWORKHOURLOGHOUR_TO","pic":"ZZZ9"},{"av":"AV42TFWorkHourLogMinute","fld":"vTFWORKHOURLOGMINUTE","pic":"ZZZ9"},{"av":"AV43TFWorkHourLogMinute_To","fld":"vTFWORKHOURLOGMINUTE_TO","pic":"ZZZ9"},{"av":"AV44TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV45TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"AV63TFEmployeeFirstName","fld":"vTFEMPLOYEEFIRSTNAME"},{"av":"AV64TFEmployeeFirstName_Sel","fld":"vTFEMPLOYEEFIRSTNAME_SEL"},{"av":"AV50TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV51TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("WORKHOURLOGDATE_RANGEPICKER.DATERANGECHANGED",""","oparms":[{"av":"AV90WorkHourLogDate","fld":"vWORKHOURLOGDATE"},{"av":"AV89WorkHourLogDate_To","fld":"vWORKHOURLOGDATE_TO"},{"av":"AV25ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWorkHourLogDate_Visible","ctrl":"WORKHOURLOGDATE","prop":"Visible"},{"av":"edtWorkHourLogDuration_Visible","ctrl":"WORKHOURLOGDURATION","prop":"Visible"},{"av":"edtWorkHourLogHour_Visible","ctrl":"WORKHOURLOGHOUR","prop":"Visible"},{"av":"edtWorkHourLogMinute_Visible","ctrl":"WORKHOURLOGMINUTE","prop":"Visible"},{"av":"edtWorkHourLogDescription_Visible","ctrl":"WORKHOURLOGDESCRIPTION","prop":"Visible"},{"av":"edtEmployeeFirstName_Visible","ctrl":"EMPLOYEEFIRSTNAME","prop":"Visible"},{"av":"edtProjectName_Visible","ctrl":"PROJECTNAME","prop":"Visible"},{"av":"AV66GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV67GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV9GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV56IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV58IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV62IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"}]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[]}""");
         setEventMetadata("VALID_PROJECTID","""{"handler":"Valid_Projectid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Projectname","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV20FilterFullText = "";
         AV90WorkHourLogDate = DateTime.MinValue;
         AV25ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV94Pgmname = "";
         AV89WorkHourLogDate_To = DateTime.MinValue;
         AV33TFWorkHourLogDate = DateTime.MinValue;
         AV34TFWorkHourLogDate_To = DateTime.MinValue;
         AV38TFWorkHourLogDuration = "";
         AV39TFWorkHourLogDuration_Sel = "";
         AV44TFWorkHourLogDescription = "";
         AV45TFWorkHourLogDescription_Sel = "";
         AV63TFEmployeeFirstName = "";
         AV64TFEmployeeFirstName_Sel = "";
         AV50TFProjectName = "";
         AV51TFProjectName_Sel = "";
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV9GridAppliedFilters = "";
         AV60AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV52DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV35DDO_WorkHourLogDateAuxDate = DateTime.MinValue;
         AV36DDO_WorkHourLogDateAuxDateTo = DateTime.MinValue;
         Ddo_agexport_Caption = "";
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
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         lblFiltertextworkhourlogdate_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucWorkhourlogdate_rangepicker = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV37DDO_WorkHourLogDateAuxDateText = "";
         ucTfworkhourlogdate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV55Update = "";
         AV57Delete = "";
         A119WorkHourLogDate = DateTime.MinValue;
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A107EmployeeFirstName = "";
         A103ProjectName = "";
         lV95Workhourlogwwds_1_filterfulltext = "";
         lV100Workhourlogwwds_6_tfworkhourlogduration = "";
         lV106Workhourlogwwds_12_tfworkhourlogdescription = "";
         lV108Workhourlogwwds_14_tfemployeefirstname = "";
         lV110Workhourlogwwds_16_tfprojectname = "";
         AV95Workhourlogwwds_1_filterfulltext = "";
         AV96Workhourlogwwds_2_workhourlogdate = DateTime.MinValue;
         AV97Workhourlogwwds_3_workhourlogdate_to = DateTime.MinValue;
         AV98Workhourlogwwds_4_tfworkhourlogdate = DateTime.MinValue;
         AV99Workhourlogwwds_5_tfworkhourlogdate_to = DateTime.MinValue;
         AV101Workhourlogwwds_7_tfworkhourlogduration_sel = "";
         AV100Workhourlogwwds_6_tfworkhourlogduration = "";
         AV107Workhourlogwwds_13_tfworkhourlogdescription_sel = "";
         AV106Workhourlogwwds_12_tfworkhourlogdescription = "";
         AV109Workhourlogwwds_15_tfemployeefirstname_sel = "";
         AV108Workhourlogwwds_14_tfemployeefirstname = "";
         AV111Workhourlogwwds_17_tfprojectname_sel = "";
         AV110Workhourlogwwds_16_tfprojectname = "";
         H002X2_A103ProjectName = new string[] {""} ;
         H002X2_A102ProjectId = new long[1] ;
         H002X2_A107EmployeeFirstName = new string[] {""} ;
         H002X2_A106EmployeeId = new long[1] ;
         H002X2_A123WorkHourLogDescription = new string[] {""} ;
         H002X2_A122WorkHourLogMinute = new short[1] ;
         H002X2_A121WorkHourLogHour = new short[1] ;
         H002X2_A120WorkHourLogDuration = new string[] {""} ;
         H002X2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         H002X2_A118WorkHourLogId = new long[1] ;
         H002X3_AGRID_nRecordCount = new long[1] ;
         AV91WorkHourLogDate_RangeText = "";
         AV61AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV53GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV54GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV23ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV24UserCustomValue = "";
         AV26ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV15GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV16GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV13TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12HTTPRequest = new GxHttpRequest( context);
         AV21ExcelFilename = "";
         AV22ErrorMessage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourlogww__default(),
            new Object[][] {
                new Object[] {
               H002X2_A103ProjectName, H002X2_A102ProjectId, H002X2_A107EmployeeFirstName, H002X2_A106EmployeeId, H002X2_A123WorkHourLogDescription, H002X2_A122WorkHourLogMinute, H002X2_A121WorkHourLogHour, H002X2_A120WorkHourLogDuration, H002X2_A119WorkHourLogDate, H002X2_A118WorkHourLogId
               }
               , new Object[] {
               H002X3_AGRID_nRecordCount
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV94Pgmname = "WorkHourLogWW";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV94Pgmname = "WorkHourLogWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV17OrderedBy ;
      private short AV88WorkHourLogDateOperator ;
      private short AV40TFWorkHourLogHour ;
      private short AV41TFWorkHourLogHour_To ;
      private short AV42TFWorkHourLogMinute ;
      private short AV43TFWorkHourLogMinute_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV102Workhourlogwwds_8_tfworkhourloghour ;
      private short AV103Workhourlogwwds_9_tfworkhourloghour_to ;
      private short AV104Workhourlogwwds_10_tfworkhourlogminute ;
      private short AV105Workhourlogwwds_11_tfworkhourlogminute_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_49 ;
      private int nGXsfl_49_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWorkHourLogId_Enabled ;
      private int edtWorkHourLogDate_Enabled ;
      private int edtWorkHourLogDuration_Enabled ;
      private int edtWorkHourLogHour_Enabled ;
      private int edtWorkHourLogMinute_Enabled ;
      private int edtWorkHourLogDescription_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeFirstName_Enabled ;
      private int edtProjectId_Enabled ;
      private int edtProjectName_Enabled ;
      private int edtWorkHourLogDate_Visible ;
      private int edtWorkHourLogDuration_Visible ;
      private int edtWorkHourLogHour_Visible ;
      private int edtWorkHourLogMinute_Visible ;
      private int edtWorkHourLogDescription_Visible ;
      private int edtEmployeeFirstName_Visible ;
      private int edtProjectName_Visible ;
      private int AV65PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV112GXV1 ;
      private int edtavWorkhourlogdate_rangetext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV66GridCurrentPage ;
      private long AV67GridPageCount ;
      private long A118WorkHourLogId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_49_idx="0001" ;
      private string AV94Pgmname ;
      private string AV63TFEmployeeFirstName ;
      private string AV64TFEmployeeFirstName_Sel ;
      private string AV50TFProjectName ;
      private string AV51TFProjectName_Sel ;
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
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
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
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divTablesplittedfiltertextworkhourlogdate_Internalname ;
      private string lblFiltertextworkhourlogdate_Internalname ;
      private string lblFiltertextworkhourlogdate_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Workhourlogdate_rangepicker_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_workhourlogdateauxdates_Internalname ;
      private string edtavDdo_workhourlogdateauxdatetext_Internalname ;
      private string edtavDdo_workhourlogdateauxdatetext_Jsonclick ;
      private string Tfworkhourlogdate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV55Update ;
      private string edtavUpdate_Internalname ;
      private string AV57Delete ;
      private string edtavDelete_Internalname ;
      private string edtWorkHourLogId_Internalname ;
      private string edtWorkHourLogDate_Internalname ;
      private string edtWorkHourLogDuration_Internalname ;
      private string edtWorkHourLogHour_Internalname ;
      private string edtWorkHourLogMinute_Internalname ;
      private string edtWorkHourLogDescription_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string A107EmployeeFirstName ;
      private string edtEmployeeFirstName_Internalname ;
      private string edtProjectId_Internalname ;
      private string A103ProjectName ;
      private string edtProjectName_Internalname ;
      private string cmbavWorkhourlogdateoperator_Internalname ;
      private string lV108Workhourlogwwds_14_tfemployeefirstname ;
      private string lV110Workhourlogwwds_16_tfprojectname ;
      private string AV109Workhourlogwwds_15_tfemployeefirstname_sel ;
      private string AV108Workhourlogwwds_14_tfemployeefirstname ;
      private string AV111Workhourlogwwds_17_tfprojectname_sel ;
      private string AV110Workhourlogwwds_16_tfprojectname ;
      private string edtavWorkhourlogdate_rangetext_Internalname ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string cellWorkhourlogdate_range_cell_Class ;
      private string cellWorkhourlogdate_range_cell_Internalname ;
      private string tblTablemergedworkhourlogdate_Internalname ;
      private string cmbavWorkhourlogdateoperator_Jsonclick ;
      private string edtavWorkhourlogdate_rangetext_Jsonclick ;
      private string sGXsfl_49_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtWorkHourLogId_Jsonclick ;
      private string edtWorkHourLogDate_Jsonclick ;
      private string edtWorkHourLogDuration_Jsonclick ;
      private string edtWorkHourLogHour_Jsonclick ;
      private string edtWorkHourLogMinute_Jsonclick ;
      private string edtWorkHourLogDescription_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeFirstName_Jsonclick ;
      private string edtProjectId_Jsonclick ;
      private string edtProjectName_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV90WorkHourLogDate ;
      private DateTime AV89WorkHourLogDate_To ;
      private DateTime AV33TFWorkHourLogDate ;
      private DateTime AV34TFWorkHourLogDate_To ;
      private DateTime Gx_date ;
      private DateTime AV35DDO_WorkHourLogDateAuxDate ;
      private DateTime AV36DDO_WorkHourLogDateAuxDateTo ;
      private DateTime A119WorkHourLogDate ;
      private DateTime AV96Workhourlogwwds_2_workhourlogdate ;
      private DateTime AV97Workhourlogwwds_3_workhourlogdate_to ;
      private DateTime AV98Workhourlogwwds_4_tfworkhourlogdate ;
      private DateTime AV99Workhourlogwwds_5_tfworkhourlogdate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18OrderedDsc ;
      private bool AV56IsAuthorized_Update ;
      private bool AV58IsAuthorized_Delete ;
      private bool AV62IsAuthorized_Insert ;
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
      private bool bGXsfl_49_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean3 ;
      private string A123WorkHourLogDescription ;
      private string AV23ColumnsSelectorXML ;
      private string AV24UserCustomValue ;
      private string AV20FilterFullText ;
      private string AV38TFWorkHourLogDuration ;
      private string AV39TFWorkHourLogDuration_Sel ;
      private string AV44TFWorkHourLogDescription ;
      private string AV45TFWorkHourLogDescription_Sel ;
      private string AV9GridAppliedFilters ;
      private string AV37DDO_WorkHourLogDateAuxDateText ;
      private string A120WorkHourLogDuration ;
      private string lV95Workhourlogwwds_1_filterfulltext ;
      private string lV100Workhourlogwwds_6_tfworkhourlogduration ;
      private string lV106Workhourlogwwds_12_tfworkhourlogdescription ;
      private string AV95Workhourlogwwds_1_filterfulltext ;
      private string AV101Workhourlogwwds_7_tfworkhourlogduration_sel ;
      private string AV100Workhourlogwwds_6_tfworkhourlogduration ;
      private string AV107Workhourlogwwds_13_tfworkhourlogdescription_sel ;
      private string AV106Workhourlogwwds_12_tfworkhourlogdescription ;
      private string AV91WorkHourLogDate_RangeText ;
      private string AV21ExcelFilename ;
      private string AV22ErrorMessage ;
      private IGxSession AV27Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucWorkhourlogdate_rangepicker ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfworkhourlogdate_rangepicker ;
      private GxHttpRequest AV12HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavWorkhourlogdateoperator ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelector ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV60AGExportData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H002X2_A103ProjectName ;
      private long[] H002X2_A102ProjectId ;
      private string[] H002X2_A107EmployeeFirstName ;
      private long[] H002X2_A106EmployeeId ;
      private string[] H002X2_A123WorkHourLogDescription ;
      private short[] H002X2_A122WorkHourLogMinute ;
      private short[] H002X2_A121WorkHourLogHour ;
      private string[] H002X2_A120WorkHourLogDuration ;
      private DateTime[] H002X2_A119WorkHourLogDate ;
      private long[] H002X2_A118WorkHourLogId ;
      private long[] H002X3_AGRID_nRecordCount ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item AV61AGExportDataItem ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV53GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV54GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV26ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV15GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV16GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV13TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class workhourlogww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002X2( IGxContext context ,
                                             string AV95Workhourlogwwds_1_filterfulltext ,
                                             short AV88WorkHourLogDateOperator ,
                                             DateTime AV96Workhourlogwwds_2_workhourlogdate ,
                                             DateTime AV97Workhourlogwwds_3_workhourlogdate_to ,
                                             DateTime AV98Workhourlogwwds_4_tfworkhourlogdate ,
                                             DateTime AV99Workhourlogwwds_5_tfworkhourlogdate_to ,
                                             string AV101Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                             string AV100Workhourlogwwds_6_tfworkhourlogduration ,
                                             short AV102Workhourlogwwds_8_tfworkhourloghour ,
                                             short AV103Workhourlogwwds_9_tfworkhourloghour_to ,
                                             short AV104Workhourlogwwds_10_tfworkhourlogminute ,
                                             short AV105Workhourlogwwds_11_tfworkhourlogminute_to ,
                                             string AV107Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                             string AV106Workhourlogwwds_12_tfworkhourlogdescription ,
                                             string AV109Workhourlogwwds_15_tfemployeefirstname_sel ,
                                             string AV108Workhourlogwwds_14_tfemployeefirstname ,
                                             string AV111Workhourlogwwds_17_tfprojectname_sel ,
                                             string AV110Workhourlogwwds_16_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             string A107EmployeeFirstName ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[28];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.ProjectName, T1.ProjectId, T3.EmployeeFirstName, T1.EmployeeId, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDuration, T1.WorkHourLogDate, T1.WorkHourLogId";
         sFromString = " FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV95Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV95Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV95Workhourlogwwds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV95Workhourlogwwds_1_filterfulltext) or ( T3.EmployeeFirstName like '%' || :lV95Workhourlogwwds_1_filterfulltext) or ( T2.ProjectName like '%' || :lV95Workhourlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
         }
         if ( ( AV88WorkHourLogDateOperator == 0 ) && ( ! (DateTime.MinValue==AV96Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate < :AV96Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ( AV88WorkHourLogDateOperator == 1 ) && ( ! (DateTime.MinValue==AV96Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate = :AV96Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ( ( AV88WorkHourLogDateOperator == 2 ) || ( AV88WorkHourLogDateOperator == 3 ) ) && ( ! (DateTime.MinValue==AV96Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate > :AV96Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ( ( AV88WorkHourLogDateOperator == 2 ) || ( AV88WorkHourLogDateOperator == 3 ) || ( AV88WorkHourLogDateOperator == 4 ) ) && ( ! (DateTime.MinValue==AV97Workhourlogwwds_3_workhourlogdate_to) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV97Workhourlogwwds_3_workhourlogdate_to)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ( AV88WorkHourLogDateOperator == 4 ) && ( ! (DateTime.MinValue==AV96Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV96Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Workhourlogwwds_4_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV98Workhourlogwwds_4_tfworkhourlogdate)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV99Workhourlogwwds_5_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV99Workhourlogwwds_5_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Workhourlogwwds_7_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Workhourlogwwds_6_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV100Workhourlogwwds_6_tfworkhourlogduration)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Workhourlogwwds_7_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV101Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV101Workhourlogwwds_7_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV101Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV102Workhourlogwwds_8_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV102Workhourlogwwds_8_tfworkhourloghour)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (0==AV103Workhourlogwwds_9_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV103Workhourlogwwds_9_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! (0==AV104Workhourlogwwds_10_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV104Workhourlogwwds_10_tfworkhourlogminute)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! (0==AV105Workhourlogwwds_11_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV105Workhourlogwwds_11_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Workhourlogwwds_12_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV106Workhourlogwwds_12_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV107Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV107Workhourlogwwds_13_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV107Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Workhourlogwwds_15_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Workhourlogwwds_14_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeFirstName like :lV108Workhourlogwwds_14_tfemployeefirstname)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Workhourlogwwds_15_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV109Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeFirstName = ( :AV109Workhourlogwwds_15_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( StringUtil.StrCmp(AV109Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Workhourlogwwds_17_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Workhourlogwwds_16_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV110Workhourlogwwds_16_tfprojectname)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Workhourlogwwds_17_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV111Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV111Workhourlogwwds_17_tfprojectname_sel))");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( StringUtil.StrCmp(AV111Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDate, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDate DESC, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDuration, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDuration DESC, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogHour, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogHour DESC, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogMinute, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogMinute DESC, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDescription, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDescription DESC, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T3.EmployeeFirstName, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.EmployeeFirstName DESC, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ProjectName, T1.WorkHourLogId";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ProjectName DESC, T1.WorkHourLogId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.WorkHourLogId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H002X3( IGxContext context ,
                                             string AV95Workhourlogwwds_1_filterfulltext ,
                                             short AV88WorkHourLogDateOperator ,
                                             DateTime AV96Workhourlogwwds_2_workhourlogdate ,
                                             DateTime AV97Workhourlogwwds_3_workhourlogdate_to ,
                                             DateTime AV98Workhourlogwwds_4_tfworkhourlogdate ,
                                             DateTime AV99Workhourlogwwds_5_tfworkhourlogdate_to ,
                                             string AV101Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                             string AV100Workhourlogwwds_6_tfworkhourlogduration ,
                                             short AV102Workhourlogwwds_8_tfworkhourloghour ,
                                             short AV103Workhourlogwwds_9_tfworkhourloghour_to ,
                                             short AV104Workhourlogwwds_10_tfworkhourlogminute ,
                                             short AV105Workhourlogwwds_11_tfworkhourlogminute_to ,
                                             string AV107Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                             string AV106Workhourlogwwds_12_tfworkhourlogdescription ,
                                             string AV109Workhourlogwwds_15_tfemployeefirstname_sel ,
                                             string AV108Workhourlogwwds_14_tfemployeefirstname ,
                                             string AV111Workhourlogwwds_17_tfprojectname_sel ,
                                             string AV110Workhourlogwwds_16_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             string A107EmployeeFirstName ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[25];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((WorkHourLog T1 INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId) INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Workhourlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV95Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV95Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV95Workhourlogwwds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV95Workhourlogwwds_1_filterfulltext) or ( T2.EmployeeFirstName like '%' || :lV95Workhourlogwwds_1_filterfulltext) or ( T3.ProjectName like '%' || :lV95Workhourlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
         }
         if ( ( AV88WorkHourLogDateOperator == 0 ) && ( ! (DateTime.MinValue==AV96Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate < :AV96Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ( AV88WorkHourLogDateOperator == 1 ) && ( ! (DateTime.MinValue==AV96Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate = :AV96Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ( ( AV88WorkHourLogDateOperator == 2 ) || ( AV88WorkHourLogDateOperator == 3 ) ) && ( ! (DateTime.MinValue==AV96Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate > :AV96Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ( ( AV88WorkHourLogDateOperator == 2 ) || ( AV88WorkHourLogDateOperator == 3 ) || ( AV88WorkHourLogDateOperator == 4 ) ) && ( ! (DateTime.MinValue==AV97Workhourlogwwds_3_workhourlogdate_to) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV97Workhourlogwwds_3_workhourlogdate_to)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ( AV88WorkHourLogDateOperator == 4 ) && ( ! (DateTime.MinValue==AV96Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV96Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Workhourlogwwds_4_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV98Workhourlogwwds_4_tfworkhourlogdate)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV99Workhourlogwwds_5_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV99Workhourlogwwds_5_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Workhourlogwwds_7_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Workhourlogwwds_6_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV100Workhourlogwwds_6_tfworkhourlogduration)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Workhourlogwwds_7_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV101Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV101Workhourlogwwds_7_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV101Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV102Workhourlogwwds_8_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV102Workhourlogwwds_8_tfworkhourloghour)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! (0==AV103Workhourlogwwds_9_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV103Workhourlogwwds_9_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! (0==AV104Workhourlogwwds_10_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV104Workhourlogwwds_10_tfworkhourlogminute)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! (0==AV105Workhourlogwwds_11_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV105Workhourlogwwds_11_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Workhourlogwwds_12_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV106Workhourlogwwds_12_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV107Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV107Workhourlogwwds_13_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( StringUtil.StrCmp(AV107Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Workhourlogwwds_15_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Workhourlogwwds_14_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName like :lV108Workhourlogwwds_14_tfemployeefirstname)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Workhourlogwwds_15_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV109Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName = ( :AV109Workhourlogwwds_15_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( StringUtil.StrCmp(AV109Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Workhourlogwwds_17_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Workhourlogwwds_16_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName like :lV110Workhourlogwwds_16_tfprojectname)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Workhourlogwwds_17_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV111Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV111Workhourlogwwds_17_tfprojectname_sel))");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( StringUtil.StrCmp(AV111Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
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
                     return conditional_H002X2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] );
               case 1 :
                     return conditional_H002X3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] );
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
          Object[] prmH002X2;
          prmH002X2 = new Object[] {
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV96Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV96Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV96Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV97Workhourlogwwds_3_workhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("AV96Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV98Workhourlogwwds_4_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV99Workhourlogwwds_5_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV100Workhourlogwwds_6_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV101Workhourlogwwds_7_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV102Workhourlogwwds_8_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV103Workhourlogwwds_9_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV104Workhourlogwwds_10_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV105Workhourlogwwds_11_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV106Workhourlogwwds_12_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV107Workhourlogwwds_13_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV108Workhourlogwwds_14_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV109Workhourlogwwds_15_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV110Workhourlogwwds_16_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV111Workhourlogwwds_17_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002X3;
          prmH002X3 = new Object[] {
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV96Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV96Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV96Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV97Workhourlogwwds_3_workhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("AV96Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV98Workhourlogwwds_4_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV99Workhourlogwwds_5_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV100Workhourlogwwds_6_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV101Workhourlogwwds_7_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV102Workhourlogwwds_8_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV103Workhourlogwwds_9_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV104Workhourlogwwds_10_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV105Workhourlogwwds_11_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV106Workhourlogwwds_12_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV107Workhourlogwwds_13_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV108Workhourlogwwds_14_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV109Workhourlogwwds_15_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV110Workhourlogwwds_16_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV111Workhourlogwwds_17_tfprojectname_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002X2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002X3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
