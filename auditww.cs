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
   public class auditww : GXDataArea
   {
      public auditww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public auditww( IGxContext context )
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
         nRC_GXsfl_39 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
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
         AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV15FilterFullText = GetPar( "FilterFullText");
         AV25ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV20ColumnsSelector);
         AV61Pgmname = GetPar( "Pgmname");
         AV26TFAuditId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFAuditId"), "."), 18, MidpointRounding.ToEven));
         AV27TFAuditId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFAuditId_To"), "."), 18, MidpointRounding.ToEven));
         AV28TFAuditDate = context.localUtil.ParseDateParm( GetPar( "TFAuditDate"));
         AV29TFAuditDate_To = context.localUtil.ParseDateParm( GetPar( "TFAuditDate_To"));
         AV33TFAuditTableName = GetPar( "TFAuditTableName");
         AV34TFAuditTableName_Sel = GetPar( "TFAuditTableName_Sel");
         AV35TFAuditDescription = GetPar( "TFAuditDescription");
         AV36TFAuditDescription_Sel = GetPar( "TFAuditDescription_Sel");
         AV37TFAuditShortDescription = GetPar( "TFAuditShortDescription");
         AV38TFAuditShortDescription_Sel = GetPar( "TFAuditShortDescription_Sel");
         AV39TFAuditAction = GetPar( "TFAuditAction");
         AV40TFAuditAction_Sel = GetPar( "TFAuditAction_Sel");
         AV41TFSecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFSecUserId"), "."), 18, MidpointRounding.ToEven));
         AV42TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFSecUserId_To"), "."), 18, MidpointRounding.ToEven));
         AV43TFEmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFEmployeeId"), "."), 18, MidpointRounding.ToEven));
         AV44TFEmployeeId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFEmployeeId_To"), "."), 18, MidpointRounding.ToEven));
         AV45TFEmployeeName = GetPar( "TFEmployeeName");
         AV46TFEmployeeName_Sel = GetPar( "TFEmployeeName_Sel");
         AV55IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV57IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV60IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV15FilterFullText, AV25ManageFiltersExecutionStep, AV20ColumnsSelector, AV61Pgmname, AV26TFAuditId, AV27TFAuditId_To, AV28TFAuditDate, AV29TFAuditDate_To, AV33TFAuditTableName, AV34TFAuditTableName_Sel, AV35TFAuditDescription, AV36TFAuditDescription_Sel, AV37TFAuditShortDescription, AV38TFAuditShortDescription_Sel, AV39TFAuditAction, AV40TFAuditAction_Sel, AV41TFSecUserId, AV42TFSecUserId_To, AV43TFEmployeeId, AV44TFEmployeeId_To, AV45TFEmployeeName, AV46TFEmployeeName_Sel, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV60IsAuthorized_Insert) ;
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
            return "auditww_Execute" ;
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
         PA5O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5O2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("auditww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV57IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV57IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV60IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV60IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV23ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV23ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV53GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV58AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV58AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV20ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV20ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_AUDITDATEAUXDATE", context.localUtil.DToC( AV30DDO_AuditDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_AUDITDATEAUXDATETO", context.localUtil.DToC( AV31DDO_AuditDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ManageFiltersExecutionStep), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFAUDITID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TFAuditId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFAUDITID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27TFAuditId_To), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFAUDITDATE", context.localUtil.DToC( AV28TFAuditDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFAUDITDATE_TO", context.localUtil.DToC( AV29TFAuditDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFAUDITTABLENAME", StringUtil.RTrim( AV33TFAuditTableName));
         GxWebStd.gx_hidden_field( context, "vTFAUDITTABLENAME_SEL", StringUtil.RTrim( AV34TFAuditTableName_Sel));
         GxWebStd.gx_hidden_field( context, "vTFAUDITDESCRIPTION", AV35TFAuditDescription);
         GxWebStd.gx_hidden_field( context, "vTFAUDITDESCRIPTION_SEL", AV36TFAuditDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAUDITSHORTDESCRIPTION", AV37TFAuditShortDescription);
         GxWebStd.gx_hidden_field( context, "vTFAUDITSHORTDESCRIPTION_SEL", AV38TFAuditShortDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAUDITACTION", AV39TFAuditAction);
         GxWebStd.gx_hidden_field( context, "vTFAUDITACTION_SEL", AV40TFAuditAction_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41TFSecUserId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFSECUSERID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42TFSecUserId_To), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFEmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEEID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFEmployeeId_To), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEENAME", StringUtil.RTrim( AV45TFEmployeeName));
         GxWebStd.gx_hidden_field( context, "vTFEMPLOYEENAME_SEL", StringUtil.RTrim( AV46TFEmployeeName_Sel));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV57IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV57IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV60IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV60IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
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
            WE5O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5O2( ) ;
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
         return formatLink("auditww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AuditWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Audit" ;
      }

      protected void WB5O0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Export", bttBtnagexport_Jsonclick, 0, "Export", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Select columns", bttBtneditcolumns_Jsonclick, 0, "Select columns", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_AuditWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV23ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Search", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_AuditWW.htm");
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
            StartGridControl39( ) ;
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            nRC_GXsfl_39 = (int)(nGXsfl_39_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV51GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV52GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV53GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV58AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV20ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_auditdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_auditdateauxdatetext_Internalname, AV32DDO_AuditDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV32DDO_AuditDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_auditdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AuditWW.htm");
            /* User Defined Control */
            ucTfauditdate_rangepicker.SetProperty("Start Date", AV30DDO_AuditDateAuxDate);
            ucTfauditdate_rangepicker.SetProperty("End Date", AV31DDO_AuditDateAuxDateTo);
            ucTfauditdate_rangepicker.Render(context, "wwp.daterangepicker", Tfauditdate_rangepicker_Internalname, "TFAUDITDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 39 )
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

      protected void START5O2( )
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
         Form.Meta.addItem("description", " Audit", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5O0( ) ;
      }

      protected void WS5O2( )
      {
         START5O2( ) ;
         EVT5O2( ) ;
      }

      protected void EVT5O2( )
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
                              E115O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E125O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E135O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E145O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E155O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E165O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E175O2 ();
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
                              nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              AV54Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV54Update);
                              AV56Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV56Delete);
                              A204AuditId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAuditId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A205AuditDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtAuditDate_Internalname), 0));
                              A206AuditTableName = cgiGet( edtAuditTableName_Internalname);
                              A207AuditDescription = cgiGet( edtAuditDescription_Internalname);
                              A208AuditShortDescription = cgiGet( edtAuditShortDescription_Internalname);
                              A209AuditAction = cgiGet( edtAuditAction_Internalname);
                              A210SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E185O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E195O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E205O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV12OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
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

      protected void WE5O2( )
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

      protected void PA5O2( )
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
         SubsflControlProps_392( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            sendrow_392( ) ;
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       string AV15FilterFullText ,
                                       short AV25ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV20ColumnsSelector ,
                                       string AV61Pgmname ,
                                       long AV26TFAuditId ,
                                       long AV27TFAuditId_To ,
                                       DateTime AV28TFAuditDate ,
                                       DateTime AV29TFAuditDate_To ,
                                       string AV33TFAuditTableName ,
                                       string AV34TFAuditTableName_Sel ,
                                       string AV35TFAuditDescription ,
                                       string AV36TFAuditDescription_Sel ,
                                       string AV37TFAuditShortDescription ,
                                       string AV38TFAuditShortDescription_Sel ,
                                       string AV39TFAuditAction ,
                                       string AV40TFAuditAction_Sel ,
                                       long AV41TFSecUserId ,
                                       long AV42TFSecUserId_To ,
                                       long AV43TFEmployeeId ,
                                       long AV44TFEmployeeId_To ,
                                       string AV45TFEmployeeName ,
                                       string AV46TFEmployeeName_Sel ,
                                       bool AV55IsAuthorized_Update ,
                                       bool AV57IsAuthorized_Delete ,
                                       bool AV60IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5O2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_AUDITID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A204AuditId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "AUDITID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A204AuditId), 10, 0, ".", "")));
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
         RF5O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV61Pgmname = "AuditWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF5O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E195O2 ();
         nGXsfl_39_idx = 1;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         bGXsfl_39_Refreshing = true;
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
            SubsflControlProps_392( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV62Auditwwds_1_filterfulltext ,
                                                 AV63Auditwwds_2_tfauditid ,
                                                 AV64Auditwwds_3_tfauditid_to ,
                                                 AV65Auditwwds_4_tfauditdate ,
                                                 AV66Auditwwds_5_tfauditdate_to ,
                                                 AV68Auditwwds_7_tfaudittablename_sel ,
                                                 AV67Auditwwds_6_tfaudittablename ,
                                                 AV70Auditwwds_9_tfauditdescription_sel ,
                                                 AV69Auditwwds_8_tfauditdescription ,
                                                 AV72Auditwwds_11_tfauditshortdescription_sel ,
                                                 AV71Auditwwds_10_tfauditshortdescription ,
                                                 AV74Auditwwds_13_tfauditaction_sel ,
                                                 AV73Auditwwds_12_tfauditaction ,
                                                 AV75Auditwwds_14_tfsecuserid ,
                                                 AV76Auditwwds_15_tfsecuserid_to ,
                                                 AV77Auditwwds_16_tfemployeeid ,
                                                 AV78Auditwwds_17_tfemployeeid_to ,
                                                 AV80Auditwwds_19_tfemployeename_sel ,
                                                 AV79Auditwwds_18_tfemployeename ,
                                                 A204AuditId ,
                                                 A206AuditTableName ,
                                                 A207AuditDescription ,
                                                 A208AuditShortDescription ,
                                                 A209AuditAction ,
                                                 A210SecUserId ,
                                                 A106EmployeeId ,
                                                 A148EmployeeName ,
                                                 A205AuditDate ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
            lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
            lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
            lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
            lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
            lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
            lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
            lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
            lV67Auditwwds_6_tfaudittablename = StringUtil.PadR( StringUtil.RTrim( AV67Auditwwds_6_tfaudittablename), 100, "%");
            lV69Auditwwds_8_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV69Auditwwds_8_tfauditdescription), "%", "");
            lV71Auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV71Auditwwds_10_tfauditshortdescription), "%", "");
            lV73Auditwwds_12_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV73Auditwwds_12_tfauditaction), "%", "");
            lV79Auditwwds_18_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV79Auditwwds_18_tfemployeename), 100, "%");
            /* Using cursor H005O2 */
            pr_default.execute(0, new Object[] {lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, AV63Auditwwds_2_tfauditid, AV64Auditwwds_3_tfauditid_to, AV65Auditwwds_4_tfauditdate, AV66Auditwwds_5_tfauditdate_to, lV67Auditwwds_6_tfaudittablename, AV68Auditwwds_7_tfaudittablename_sel, lV69Auditwwds_8_tfauditdescription, AV70Auditwwds_9_tfauditdescription_sel, lV71Auditwwds_10_tfauditshortdescription, AV72Auditwwds_11_tfauditshortdescription_sel, lV73Auditwwds_12_tfauditaction, AV74Auditwwds_13_tfauditaction_sel, AV75Auditwwds_14_tfsecuserid, AV76Auditwwds_15_tfsecuserid_to, AV77Auditwwds_16_tfemployeeid, AV78Auditwwds_17_tfemployeeid_to, lV79Auditwwds_18_tfemployeename, AV80Auditwwds_19_tfemployeename_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A148EmployeeName = H005O2_A148EmployeeName[0];
               A106EmployeeId = H005O2_A106EmployeeId[0];
               A210SecUserId = H005O2_A210SecUserId[0];
               A209AuditAction = H005O2_A209AuditAction[0];
               A208AuditShortDescription = H005O2_A208AuditShortDescription[0];
               A207AuditDescription = H005O2_A207AuditDescription[0];
               A206AuditTableName = H005O2_A206AuditTableName[0];
               A205AuditDate = H005O2_A205AuditDate[0];
               A204AuditId = H005O2_A204AuditId[0];
               A148EmployeeName = H005O2_A148EmployeeName[0];
               /* Execute user event: Grid.Load */
               E205O2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WB5O0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5O2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV57IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV57IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV60IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV60IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_AUDITID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(A204AuditId), "ZZZZZZZZZ9"), context));
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
         AV62Auditwwds_1_filterfulltext = AV15FilterFullText;
         AV63Auditwwds_2_tfauditid = AV26TFAuditId;
         AV64Auditwwds_3_tfauditid_to = AV27TFAuditId_To;
         AV65Auditwwds_4_tfauditdate = AV28TFAuditDate;
         AV66Auditwwds_5_tfauditdate_to = AV29TFAuditDate_To;
         AV67Auditwwds_6_tfaudittablename = AV33TFAuditTableName;
         AV68Auditwwds_7_tfaudittablename_sel = AV34TFAuditTableName_Sel;
         AV69Auditwwds_8_tfauditdescription = AV35TFAuditDescription;
         AV70Auditwwds_9_tfauditdescription_sel = AV36TFAuditDescription_Sel;
         AV71Auditwwds_10_tfauditshortdescription = AV37TFAuditShortDescription;
         AV72Auditwwds_11_tfauditshortdescription_sel = AV38TFAuditShortDescription_Sel;
         AV73Auditwwds_12_tfauditaction = AV39TFAuditAction;
         AV74Auditwwds_13_tfauditaction_sel = AV40TFAuditAction_Sel;
         AV75Auditwwds_14_tfsecuserid = AV41TFSecUserId;
         AV76Auditwwds_15_tfsecuserid_to = AV42TFSecUserId_To;
         AV77Auditwwds_16_tfemployeeid = AV43TFEmployeeId;
         AV78Auditwwds_17_tfemployeeid_to = AV44TFEmployeeId_To;
         AV79Auditwwds_18_tfemployeename = AV45TFEmployeeName;
         AV80Auditwwds_19_tfemployeename_sel = AV46TFEmployeeName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV62Auditwwds_1_filterfulltext ,
                                              AV63Auditwwds_2_tfauditid ,
                                              AV64Auditwwds_3_tfauditid_to ,
                                              AV65Auditwwds_4_tfauditdate ,
                                              AV66Auditwwds_5_tfauditdate_to ,
                                              AV68Auditwwds_7_tfaudittablename_sel ,
                                              AV67Auditwwds_6_tfaudittablename ,
                                              AV70Auditwwds_9_tfauditdescription_sel ,
                                              AV69Auditwwds_8_tfauditdescription ,
                                              AV72Auditwwds_11_tfauditshortdescription_sel ,
                                              AV71Auditwwds_10_tfauditshortdescription ,
                                              AV74Auditwwds_13_tfauditaction_sel ,
                                              AV73Auditwwds_12_tfauditaction ,
                                              AV75Auditwwds_14_tfsecuserid ,
                                              AV76Auditwwds_15_tfsecuserid_to ,
                                              AV77Auditwwds_16_tfemployeeid ,
                                              AV78Auditwwds_17_tfemployeeid_to ,
                                              AV80Auditwwds_19_tfemployeename_sel ,
                                              AV79Auditwwds_18_tfemployeename ,
                                              A204AuditId ,
                                              A206AuditTableName ,
                                              A207AuditDescription ,
                                              A208AuditShortDescription ,
                                              A209AuditAction ,
                                              A210SecUserId ,
                                              A106EmployeeId ,
                                              A148EmployeeName ,
                                              A205AuditDate ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
         lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
         lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
         lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
         lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
         lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
         lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
         lV62Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_1_filterfulltext), "%", "");
         lV67Auditwwds_6_tfaudittablename = StringUtil.PadR( StringUtil.RTrim( AV67Auditwwds_6_tfaudittablename), 100, "%");
         lV69Auditwwds_8_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV69Auditwwds_8_tfauditdescription), "%", "");
         lV71Auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV71Auditwwds_10_tfauditshortdescription), "%", "");
         lV73Auditwwds_12_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV73Auditwwds_12_tfauditaction), "%", "");
         lV79Auditwwds_18_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV79Auditwwds_18_tfemployeename), 100, "%");
         /* Using cursor H005O3 */
         pr_default.execute(1, new Object[] {lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, lV62Auditwwds_1_filterfulltext, AV63Auditwwds_2_tfauditid, AV64Auditwwds_3_tfauditid_to, AV65Auditwwds_4_tfauditdate, AV66Auditwwds_5_tfauditdate_to, lV67Auditwwds_6_tfaudittablename, AV68Auditwwds_7_tfaudittablename_sel, lV69Auditwwds_8_tfauditdescription, AV70Auditwwds_9_tfauditdescription_sel, lV71Auditwwds_10_tfauditshortdescription, AV72Auditwwds_11_tfauditshortdescription_sel, lV73Auditwwds_12_tfauditaction, AV74Auditwwds_13_tfauditaction_sel, AV75Auditwwds_14_tfsecuserid, AV76Auditwwds_15_tfsecuserid_to, AV77Auditwwds_16_tfemployeeid, AV78Auditwwds_17_tfemployeeid_to, lV79Auditwwds_18_tfemployeename, AV80Auditwwds_19_tfemployeename_sel});
         GRID_nRecordCount = H005O3_AGRID_nRecordCount[0];
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
         AV62Auditwwds_1_filterfulltext = AV15FilterFullText;
         AV63Auditwwds_2_tfauditid = AV26TFAuditId;
         AV64Auditwwds_3_tfauditid_to = AV27TFAuditId_To;
         AV65Auditwwds_4_tfauditdate = AV28TFAuditDate;
         AV66Auditwwds_5_tfauditdate_to = AV29TFAuditDate_To;
         AV67Auditwwds_6_tfaudittablename = AV33TFAuditTableName;
         AV68Auditwwds_7_tfaudittablename_sel = AV34TFAuditTableName_Sel;
         AV69Auditwwds_8_tfauditdescription = AV35TFAuditDescription;
         AV70Auditwwds_9_tfauditdescription_sel = AV36TFAuditDescription_Sel;
         AV71Auditwwds_10_tfauditshortdescription = AV37TFAuditShortDescription;
         AV72Auditwwds_11_tfauditshortdescription_sel = AV38TFAuditShortDescription_Sel;
         AV73Auditwwds_12_tfauditaction = AV39TFAuditAction;
         AV74Auditwwds_13_tfauditaction_sel = AV40TFAuditAction_Sel;
         AV75Auditwwds_14_tfsecuserid = AV41TFSecUserId;
         AV76Auditwwds_15_tfsecuserid_to = AV42TFSecUserId_To;
         AV77Auditwwds_16_tfemployeeid = AV43TFEmployeeId;
         AV78Auditwwds_17_tfemployeeid_to = AV44TFEmployeeId_To;
         AV79Auditwwds_18_tfemployeename = AV45TFEmployeeName;
         AV80Auditwwds_19_tfemployeename_sel = AV46TFEmployeeName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV15FilterFullText, AV25ManageFiltersExecutionStep, AV20ColumnsSelector, AV61Pgmname, AV26TFAuditId, AV27TFAuditId_To, AV28TFAuditDate, AV29TFAuditDate_To, AV33TFAuditTableName, AV34TFAuditTableName_Sel, AV35TFAuditDescription, AV36TFAuditDescription_Sel, AV37TFAuditShortDescription, AV38TFAuditShortDescription_Sel, AV39TFAuditAction, AV40TFAuditAction_Sel, AV41TFSecUserId, AV42TFSecUserId_To, AV43TFEmployeeId, AV44TFEmployeeId_To, AV45TFEmployeeName, AV46TFEmployeeName_Sel, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV60IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV62Auditwwds_1_filterfulltext = AV15FilterFullText;
         AV63Auditwwds_2_tfauditid = AV26TFAuditId;
         AV64Auditwwds_3_tfauditid_to = AV27TFAuditId_To;
         AV65Auditwwds_4_tfauditdate = AV28TFAuditDate;
         AV66Auditwwds_5_tfauditdate_to = AV29TFAuditDate_To;
         AV67Auditwwds_6_tfaudittablename = AV33TFAuditTableName;
         AV68Auditwwds_7_tfaudittablename_sel = AV34TFAuditTableName_Sel;
         AV69Auditwwds_8_tfauditdescription = AV35TFAuditDescription;
         AV70Auditwwds_9_tfauditdescription_sel = AV36TFAuditDescription_Sel;
         AV71Auditwwds_10_tfauditshortdescription = AV37TFAuditShortDescription;
         AV72Auditwwds_11_tfauditshortdescription_sel = AV38TFAuditShortDescription_Sel;
         AV73Auditwwds_12_tfauditaction = AV39TFAuditAction;
         AV74Auditwwds_13_tfauditaction_sel = AV40TFAuditAction_Sel;
         AV75Auditwwds_14_tfsecuserid = AV41TFSecUserId;
         AV76Auditwwds_15_tfsecuserid_to = AV42TFSecUserId_To;
         AV77Auditwwds_16_tfemployeeid = AV43TFEmployeeId;
         AV78Auditwwds_17_tfemployeeid_to = AV44TFEmployeeId_To;
         AV79Auditwwds_18_tfemployeename = AV45TFEmployeeName;
         AV80Auditwwds_19_tfemployeename_sel = AV46TFEmployeeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV15FilterFullText, AV25ManageFiltersExecutionStep, AV20ColumnsSelector, AV61Pgmname, AV26TFAuditId, AV27TFAuditId_To, AV28TFAuditDate, AV29TFAuditDate_To, AV33TFAuditTableName, AV34TFAuditTableName_Sel, AV35TFAuditDescription, AV36TFAuditDescription_Sel, AV37TFAuditShortDescription, AV38TFAuditShortDescription_Sel, AV39TFAuditAction, AV40TFAuditAction_Sel, AV41TFSecUserId, AV42TFSecUserId_To, AV43TFEmployeeId, AV44TFEmployeeId_To, AV45TFEmployeeName, AV46TFEmployeeName_Sel, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV60IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV62Auditwwds_1_filterfulltext = AV15FilterFullText;
         AV63Auditwwds_2_tfauditid = AV26TFAuditId;
         AV64Auditwwds_3_tfauditid_to = AV27TFAuditId_To;
         AV65Auditwwds_4_tfauditdate = AV28TFAuditDate;
         AV66Auditwwds_5_tfauditdate_to = AV29TFAuditDate_To;
         AV67Auditwwds_6_tfaudittablename = AV33TFAuditTableName;
         AV68Auditwwds_7_tfaudittablename_sel = AV34TFAuditTableName_Sel;
         AV69Auditwwds_8_tfauditdescription = AV35TFAuditDescription;
         AV70Auditwwds_9_tfauditdescription_sel = AV36TFAuditDescription_Sel;
         AV71Auditwwds_10_tfauditshortdescription = AV37TFAuditShortDescription;
         AV72Auditwwds_11_tfauditshortdescription_sel = AV38TFAuditShortDescription_Sel;
         AV73Auditwwds_12_tfauditaction = AV39TFAuditAction;
         AV74Auditwwds_13_tfauditaction_sel = AV40TFAuditAction_Sel;
         AV75Auditwwds_14_tfsecuserid = AV41TFSecUserId;
         AV76Auditwwds_15_tfsecuserid_to = AV42TFSecUserId_To;
         AV77Auditwwds_16_tfemployeeid = AV43TFEmployeeId;
         AV78Auditwwds_17_tfemployeeid_to = AV44TFEmployeeId_To;
         AV79Auditwwds_18_tfemployeename = AV45TFEmployeeName;
         AV80Auditwwds_19_tfemployeename_sel = AV46TFEmployeeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV15FilterFullText, AV25ManageFiltersExecutionStep, AV20ColumnsSelector, AV61Pgmname, AV26TFAuditId, AV27TFAuditId_To, AV28TFAuditDate, AV29TFAuditDate_To, AV33TFAuditTableName, AV34TFAuditTableName_Sel, AV35TFAuditDescription, AV36TFAuditDescription_Sel, AV37TFAuditShortDescription, AV38TFAuditShortDescription_Sel, AV39TFAuditAction, AV40TFAuditAction_Sel, AV41TFSecUserId, AV42TFSecUserId_To, AV43TFEmployeeId, AV44TFEmployeeId_To, AV45TFEmployeeName, AV46TFEmployeeName_Sel, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV60IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV62Auditwwds_1_filterfulltext = AV15FilterFullText;
         AV63Auditwwds_2_tfauditid = AV26TFAuditId;
         AV64Auditwwds_3_tfauditid_to = AV27TFAuditId_To;
         AV65Auditwwds_4_tfauditdate = AV28TFAuditDate;
         AV66Auditwwds_5_tfauditdate_to = AV29TFAuditDate_To;
         AV67Auditwwds_6_tfaudittablename = AV33TFAuditTableName;
         AV68Auditwwds_7_tfaudittablename_sel = AV34TFAuditTableName_Sel;
         AV69Auditwwds_8_tfauditdescription = AV35TFAuditDescription;
         AV70Auditwwds_9_tfauditdescription_sel = AV36TFAuditDescription_Sel;
         AV71Auditwwds_10_tfauditshortdescription = AV37TFAuditShortDescription;
         AV72Auditwwds_11_tfauditshortdescription_sel = AV38TFAuditShortDescription_Sel;
         AV73Auditwwds_12_tfauditaction = AV39TFAuditAction;
         AV74Auditwwds_13_tfauditaction_sel = AV40TFAuditAction_Sel;
         AV75Auditwwds_14_tfsecuserid = AV41TFSecUserId;
         AV76Auditwwds_15_tfsecuserid_to = AV42TFSecUserId_To;
         AV77Auditwwds_16_tfemployeeid = AV43TFEmployeeId;
         AV78Auditwwds_17_tfemployeeid_to = AV44TFEmployeeId_To;
         AV79Auditwwds_18_tfemployeename = AV45TFEmployeeName;
         AV80Auditwwds_19_tfemployeename_sel = AV46TFEmployeeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV15FilterFullText, AV25ManageFiltersExecutionStep, AV20ColumnsSelector, AV61Pgmname, AV26TFAuditId, AV27TFAuditId_To, AV28TFAuditDate, AV29TFAuditDate_To, AV33TFAuditTableName, AV34TFAuditTableName_Sel, AV35TFAuditDescription, AV36TFAuditDescription_Sel, AV37TFAuditShortDescription, AV38TFAuditShortDescription_Sel, AV39TFAuditAction, AV40TFAuditAction_Sel, AV41TFSecUserId, AV42TFSecUserId_To, AV43TFEmployeeId, AV44TFEmployeeId_To, AV45TFEmployeeName, AV46TFEmployeeName_Sel, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV60IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV62Auditwwds_1_filterfulltext = AV15FilterFullText;
         AV63Auditwwds_2_tfauditid = AV26TFAuditId;
         AV64Auditwwds_3_tfauditid_to = AV27TFAuditId_To;
         AV65Auditwwds_4_tfauditdate = AV28TFAuditDate;
         AV66Auditwwds_5_tfauditdate_to = AV29TFAuditDate_To;
         AV67Auditwwds_6_tfaudittablename = AV33TFAuditTableName;
         AV68Auditwwds_7_tfaudittablename_sel = AV34TFAuditTableName_Sel;
         AV69Auditwwds_8_tfauditdescription = AV35TFAuditDescription;
         AV70Auditwwds_9_tfauditdescription_sel = AV36TFAuditDescription_Sel;
         AV71Auditwwds_10_tfauditshortdescription = AV37TFAuditShortDescription;
         AV72Auditwwds_11_tfauditshortdescription_sel = AV38TFAuditShortDescription_Sel;
         AV73Auditwwds_12_tfauditaction = AV39TFAuditAction;
         AV74Auditwwds_13_tfauditaction_sel = AV40TFAuditAction_Sel;
         AV75Auditwwds_14_tfsecuserid = AV41TFSecUserId;
         AV76Auditwwds_15_tfsecuserid_to = AV42TFSecUserId_To;
         AV77Auditwwds_16_tfemployeeid = AV43TFEmployeeId;
         AV78Auditwwds_17_tfemployeeid_to = AV44TFEmployeeId_To;
         AV79Auditwwds_18_tfemployeename = AV45TFEmployeeName;
         AV80Auditwwds_19_tfemployeename_sel = AV46TFEmployeeName_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV15FilterFullText, AV25ManageFiltersExecutionStep, AV20ColumnsSelector, AV61Pgmname, AV26TFAuditId, AV27TFAuditId_To, AV28TFAuditDate, AV29TFAuditDate_To, AV33TFAuditTableName, AV34TFAuditTableName_Sel, AV35TFAuditDescription, AV36TFAuditDescription_Sel, AV37TFAuditShortDescription, AV38TFAuditShortDescription_Sel, AV39TFAuditAction, AV40TFAuditAction_Sel, AV41TFSecUserId, AV42TFSecUserId_To, AV43TFEmployeeId, AV44TFEmployeeId_To, AV45TFEmployeeName, AV46TFEmployeeName_Sel, AV55IsAuthorized_Update, AV57IsAuthorized_Delete, AV60IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV61Pgmname = "AuditWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtAuditId_Enabled = 0;
         edtAuditDate_Enabled = 0;
         edtAuditTableName_Enabled = 0;
         edtAuditDescription_Enabled = 0;
         edtAuditShortDescription_Enabled = 0;
         edtAuditAction_Enabled = 0;
         edtSecUserId_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E185O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV23ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV58AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV47DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV20ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), ".", ","), 18, MidpointRounding.ToEven));
            AV51GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV52GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV53GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV30DDO_AuditDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_AUDITDATEAUXDATE"), 0);
            AV31DDO_AuditDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_AUDITDATEAUXDATETO"), 0);
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
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            AV32DDO_AuditDateAuxDateText = cgiGet( edtavDdo_auditdateauxdatetext_Internalname);
            AssignAttri("", false, "AV32DDO_AuditDateAuxDateText", AV32DDO_AuditDateAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
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
         E185O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E185O2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFAUDITDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_auditdateauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
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
         AV58AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV59AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV59AGExportDataItem.gxTpr_Title = "Excel";
         AV59AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV59AGExportDataItem.gxTpr_Eventkey = "Export";
         AV59AGExportDataItem.gxTpr_Isdivider = false;
         AV58AGExportData.Add(AV59AGExportDataItem, 0);
         AV48GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV49GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV48GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Audit";
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
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV47DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV47DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E195O2( )
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
         if ( AV25ManageFiltersExecutionStep == 1 )
         {
            AV25ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV25ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV25ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV25ManageFiltersExecutionStep == 2 )
         {
            AV25ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV25ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV25ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
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
         if ( StringUtil.StrCmp(AV22Session.Get("AuditWWColumnsSelector"), "") != 0 )
         {
            AV18ColumnsSelectorXML = AV22Session.Get("AuditWWColumnsSelector");
            AV20ColumnsSelector.FromXml(AV18ColumnsSelectorXML, null, "", "");
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
         edtAuditId_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV20ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditId_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtAuditDate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV20ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditDate_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtAuditTableName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV20ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditTableName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditTableName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtAuditDescription_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV20ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditDescription_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtAuditShortDescription_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV20ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditShortDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditShortDescription_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtAuditAction_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV20ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditAction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditAction_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtSecUserId_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV20ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSecUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserId_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtEmployeeId_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV20ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtEmployeeName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV20ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV51GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV51GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV51GridCurrentPage), 10, 0));
         AV52GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV52GridPageCount", StringUtil.LTrimStr( (decimal)(AV52GridPageCount), 10, 0));
         GXt_char2 = AV53GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV61Pgmname, out  GXt_char2) ;
         AV53GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV53GridAppliedFilters", AV53GridAppliedFilters);
         AV62Auditwwds_1_filterfulltext = AV15FilterFullText;
         AV63Auditwwds_2_tfauditid = AV26TFAuditId;
         AV64Auditwwds_3_tfauditid_to = AV27TFAuditId_To;
         AV65Auditwwds_4_tfauditdate = AV28TFAuditDate;
         AV66Auditwwds_5_tfauditdate_to = AV29TFAuditDate_To;
         AV67Auditwwds_6_tfaudittablename = AV33TFAuditTableName;
         AV68Auditwwds_7_tfaudittablename_sel = AV34TFAuditTableName_Sel;
         AV69Auditwwds_8_tfauditdescription = AV35TFAuditDescription;
         AV70Auditwwds_9_tfauditdescription_sel = AV36TFAuditDescription_Sel;
         AV71Auditwwds_10_tfauditshortdescription = AV37TFAuditShortDescription;
         AV72Auditwwds_11_tfauditshortdescription_sel = AV38TFAuditShortDescription_Sel;
         AV73Auditwwds_12_tfauditaction = AV39TFAuditAction;
         AV74Auditwwds_13_tfauditaction_sel = AV40TFAuditAction_Sel;
         AV75Auditwwds_14_tfsecuserid = AV41TFSecUserId;
         AV76Auditwwds_15_tfsecuserid_to = AV42TFSecUserId_To;
         AV77Auditwwds_16_tfemployeeid = AV43TFEmployeeId;
         AV78Auditwwds_17_tfemployeeid_to = AV44TFEmployeeId_To;
         AV79Auditwwds_18_tfemployeename = AV45TFEmployeeName;
         AV80Auditwwds_19_tfemployeename_sel = AV46TFEmployeeName_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ColumnsSelector", AV20ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23ManageFiltersData", AV23ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E125O2( )
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
            AV50PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV50PageToGo) ;
         }
      }

      protected void E135O2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E155O2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditId") == 0 )
            {
               AV26TFAuditId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFAuditId", StringUtil.LTrimStr( (decimal)(AV26TFAuditId), 10, 0));
               AV27TFAuditId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27TFAuditId_To", StringUtil.LTrimStr( (decimal)(AV27TFAuditId_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditDate") == 0 )
            {
               AV28TFAuditDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV28TFAuditDate", context.localUtil.Format(AV28TFAuditDate, "99/99/99"));
               AV29TFAuditDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV29TFAuditDate_To", context.localUtil.Format(AV29TFAuditDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditTableName") == 0 )
            {
               AV33TFAuditTableName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFAuditTableName", AV33TFAuditTableName);
               AV34TFAuditTableName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFAuditTableName_Sel", AV34TFAuditTableName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditDescription") == 0 )
            {
               AV35TFAuditDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFAuditDescription", AV35TFAuditDescription);
               AV36TFAuditDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFAuditDescription_Sel", AV36TFAuditDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditShortDescription") == 0 )
            {
               AV37TFAuditShortDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFAuditShortDescription", AV37TFAuditShortDescription);
               AV38TFAuditShortDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFAuditShortDescription_Sel", AV38TFAuditShortDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditAction") == 0 )
            {
               AV39TFAuditAction = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFAuditAction", AV39TFAuditAction);
               AV40TFAuditAction_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFAuditAction_Sel", AV40TFAuditAction_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserId") == 0 )
            {
               AV41TFSecUserId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFSecUserId", StringUtil.LTrimStr( (decimal)(AV41TFSecUserId), 10, 0));
               AV42TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFSecUserId_To", StringUtil.LTrimStr( (decimal)(AV42TFSecUserId_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeId") == 0 )
            {
               AV43TFEmployeeId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFEmployeeId", StringUtil.LTrimStr( (decimal)(AV43TFEmployeeId), 10, 0));
               AV44TFEmployeeId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFEmployeeId_To", StringUtil.LTrimStr( (decimal)(AV44TFEmployeeId_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EmployeeName") == 0 )
            {
               AV45TFEmployeeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV45TFEmployeeName", AV45TFEmployeeName);
               AV46TFEmployeeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFEmployeeName_Sel", AV46TFEmployeeName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E205O2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV54Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV54Update);
         if ( AV55IsAuthorized_Update )
         {
            edtavUpdate_Link = formatLink("audit.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A204AuditId,10,0))}, new string[] {"Mode","AuditId"}) ;
         }
         AV56Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV56Delete);
         if ( AV57IsAuthorized_Delete )
         {
            edtavDelete_Link = formatLink("audit.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A204AuditId,10,0))}, new string[] {"Mode","AuditId"}) ;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 39;
         }
         sendrow_392( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
         {
            DoAjaxLoad(39, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E165O2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV18ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV20ColumnsSelector.FromJSonString(AV18ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "AuditWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV18ColumnsSelectorXML)) ? "" : AV20ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ColumnsSelector", AV20ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23ManageFiltersData", AV23ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E115O2( )
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
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim("AuditWWFilters")),UrlEncode(StringUtil.RTrim(AV61Pgmname+"GridState"))}, new string[] {"UserKey","GridStateKey"}) , new Object[] {});
            AV25ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV25ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV25ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx", new object[] {UrlEncode(StringUtil.RTrim("AuditWWFilters"))}, new string[] {"UserKey"}) , new Object[] {});
            AV25ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV25ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV25ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV24ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "AuditWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV24ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24ManageFiltersXml)) )
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV61Pgmname+"GridState",  AV24ManageFiltersXml) ;
               AV10GridState.FromXml(AV24ManageFiltersXml, null, "", "");
               AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ColumnsSelector", AV20ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23ManageFiltersData", AV23ManageFiltersData);
      }

      protected void E175O2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV60IsAuthorized_Insert )
         {
            CallWebObject(formatLink("audit.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","AuditId"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("Action no longer available");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ColumnsSelector", AV20ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23ManageFiltersData", AV23ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E145O2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV20ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV20ColumnsSelector,  "AuditId",  "",  "Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV20ColumnsSelector,  "AuditDate",  "",  "Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV20ColumnsSelector,  "AuditTableName",  "",  "Table Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV20ColumnsSelector,  "AuditDescription",  "",  "Description",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV20ColumnsSelector,  "AuditShortDescription",  "",  "Short Description",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV20ColumnsSelector,  "AuditAction",  "",  "Action",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV20ColumnsSelector,  "SecUserId",  "",  "User Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV20ColumnsSelector,  "EmployeeId",  "",  "Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV20ColumnsSelector,  "EmployeeName",  "",  "Name",  true,  "") ;
         GXt_char2 = AV19UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "AuditWWColumnsSelector", out  GXt_char2) ;
         AV19UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19UserCustomValue)) ) )
         {
            AV21ColumnsSelectorAux.FromXml(AV19UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV21ColumnsSelectorAux, ref  AV20ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV55IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "audit_Update", out  GXt_boolean3) ;
         AV55IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV55IsAuthorized_Update", AV55IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV55IsAuthorized_Update, context));
         if ( ! ( AV55IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_39_Refreshing);
         }
         GXt_boolean3 = AV57IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "audit_Delete", out  GXt_boolean3) ;
         AV57IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV57IsAuthorized_Delete", AV57IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV57IsAuthorized_Delete, context));
         if ( ! ( AV57IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_39_Refreshing);
         }
         GXt_boolean3 = AV60IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "audit_Insert", out  GXt_boolean3) ;
         AV60IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV60IsAuthorized_Insert", AV60IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV60IsAuthorized_Insert, context));
         if ( ! ( AV60IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV23ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "AuditWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV23ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV26TFAuditId = 0;
         AssignAttri("", false, "AV26TFAuditId", StringUtil.LTrimStr( (decimal)(AV26TFAuditId), 10, 0));
         AV27TFAuditId_To = 0;
         AssignAttri("", false, "AV27TFAuditId_To", StringUtil.LTrimStr( (decimal)(AV27TFAuditId_To), 10, 0));
         AV28TFAuditDate = DateTime.MinValue;
         AssignAttri("", false, "AV28TFAuditDate", context.localUtil.Format(AV28TFAuditDate, "99/99/99"));
         AV29TFAuditDate_To = DateTime.MinValue;
         AssignAttri("", false, "AV29TFAuditDate_To", context.localUtil.Format(AV29TFAuditDate_To, "99/99/99"));
         AV33TFAuditTableName = "";
         AssignAttri("", false, "AV33TFAuditTableName", AV33TFAuditTableName);
         AV34TFAuditTableName_Sel = "";
         AssignAttri("", false, "AV34TFAuditTableName_Sel", AV34TFAuditTableName_Sel);
         AV35TFAuditDescription = "";
         AssignAttri("", false, "AV35TFAuditDescription", AV35TFAuditDescription);
         AV36TFAuditDescription_Sel = "";
         AssignAttri("", false, "AV36TFAuditDescription_Sel", AV36TFAuditDescription_Sel);
         AV37TFAuditShortDescription = "";
         AssignAttri("", false, "AV37TFAuditShortDescription", AV37TFAuditShortDescription);
         AV38TFAuditShortDescription_Sel = "";
         AssignAttri("", false, "AV38TFAuditShortDescription_Sel", AV38TFAuditShortDescription_Sel);
         AV39TFAuditAction = "";
         AssignAttri("", false, "AV39TFAuditAction", AV39TFAuditAction);
         AV40TFAuditAction_Sel = "";
         AssignAttri("", false, "AV40TFAuditAction_Sel", AV40TFAuditAction_Sel);
         AV41TFSecUserId = 0;
         AssignAttri("", false, "AV41TFSecUserId", StringUtil.LTrimStr( (decimal)(AV41TFSecUserId), 10, 0));
         AV42TFSecUserId_To = 0;
         AssignAttri("", false, "AV42TFSecUserId_To", StringUtil.LTrimStr( (decimal)(AV42TFSecUserId_To), 10, 0));
         AV43TFEmployeeId = 0;
         AssignAttri("", false, "AV43TFEmployeeId", StringUtil.LTrimStr( (decimal)(AV43TFEmployeeId), 10, 0));
         AV44TFEmployeeId_To = 0;
         AssignAttri("", false, "AV44TFEmployeeId_To", StringUtil.LTrimStr( (decimal)(AV44TFEmployeeId_To), 10, 0));
         AV45TFEmployeeName = "";
         AssignAttri("", false, "AV45TFEmployeeName", AV45TFEmployeeName);
         AV46TFEmployeeName_Sel = "";
         AssignAttri("", false, "AV46TFEmployeeName_Sel", AV46TFEmployeeName_Sel);
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
         if ( StringUtil.StrCmp(AV22Session.Get(AV61Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV61Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV22Session.Get(AV61Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV81GXV1 = 1;
         while ( AV81GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV81GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAUDITID") == 0 )
            {
               AV26TFAuditId = (long)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFAuditId", StringUtil.LTrimStr( (decimal)(AV26TFAuditId), 10, 0));
               AV27TFAuditId_To = (long)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27TFAuditId_To", StringUtil.LTrimStr( (decimal)(AV27TFAuditId_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAUDITDATE") == 0 )
            {
               AV28TFAuditDate = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV28TFAuditDate", context.localUtil.Format(AV28TFAuditDate, "99/99/99"));
               AV29TFAuditDate_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV29TFAuditDate_To", context.localUtil.Format(AV29TFAuditDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME") == 0 )
            {
               AV33TFAuditTableName = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFAuditTableName", AV33TFAuditTableName);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME_SEL") == 0 )
            {
               AV34TFAuditTableName_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFAuditTableName_Sel", AV34TFAuditTableName_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION") == 0 )
            {
               AV35TFAuditDescription = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFAuditDescription", AV35TFAuditDescription);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION_SEL") == 0 )
            {
               AV36TFAuditDescription_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFAuditDescription_Sel", AV36TFAuditDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION") == 0 )
            {
               AV37TFAuditShortDescription = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFAuditShortDescription", AV37TFAuditShortDescription);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION_SEL") == 0 )
            {
               AV38TFAuditShortDescription_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFAuditShortDescription_Sel", AV38TFAuditShortDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAUDITACTION") == 0 )
            {
               AV39TFAuditAction = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFAuditAction", AV39TFAuditAction);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAUDITACTION_SEL") == 0 )
            {
               AV40TFAuditAction_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFAuditAction_Sel", AV40TFAuditAction_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSERID") == 0 )
            {
               AV41TFSecUserId = (long)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFSecUserId", StringUtil.LTrimStr( (decimal)(AV41TFSecUserId), 10, 0));
               AV42TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFSecUserId_To", StringUtil.LTrimStr( (decimal)(AV42TFSecUserId_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEID") == 0 )
            {
               AV43TFEmployeeId = (long)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43TFEmployeeId", StringUtil.LTrimStr( (decimal)(AV43TFEmployeeId), 10, 0));
               AV44TFEmployeeId_To = (long)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFEmployeeId_To", StringUtil.LTrimStr( (decimal)(AV44TFEmployeeId_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV45TFEmployeeName = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFEmployeeName", AV45TFEmployeeName);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV46TFEmployeeName_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFEmployeeName_Sel", AV46TFEmployeeName_Sel);
            }
            AV81GXV1 = (int)(AV81GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFAuditTableName_Sel)),  AV34TFAuditTableName_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFAuditDescription_Sel)),  AV36TFAuditDescription_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFAuditShortDescription_Sel)),  AV38TFAuditShortDescription_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFAuditAction_Sel)),  AV40TFAuditAction_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFEmployeeName_Sel)),  AV46TFEmployeeName_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char2+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|||"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFAuditTableName)),  AV33TFAuditTableName, out  GXt_char8) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFAuditDescription)),  AV35TFAuditDescription, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFAuditShortDescription)),  AV37TFAuditShortDescription, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFAuditAction)),  AV39TFAuditAction, out  GXt_char5) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFEmployeeName)),  AV45TFEmployeeName, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((0==AV26TFAuditId) ? "" : StringUtil.Str( (decimal)(AV26TFAuditId), 10, 0))+"|"+((DateTime.MinValue==AV28TFAuditDate) ? "" : context.localUtil.DToC( AV28TFAuditDate, 2, "/"))+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+((0==AV41TFSecUserId) ? "" : StringUtil.Str( (decimal)(AV41TFSecUserId), 10, 0))+"|"+((0==AV43TFEmployeeId) ? "" : StringUtil.Str( (decimal)(AV43TFEmployeeId), 10, 0))+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV27TFAuditId_To) ? "" : StringUtil.Str( (decimal)(AV27TFAuditId_To), 10, 0))+"|"+((DateTime.MinValue==AV29TFAuditDate_To) ? "" : context.localUtil.DToC( AV29TFAuditDate_To, 2, "/"))+"|||||"+((0==AV42TFSecUserId_To) ? "" : StringUtil.Str( (decimal)(AV42TFSecUserId_To), 10, 0))+"|"+((0==AV44TFEmployeeId_To) ? "" : StringUtil.Str( (decimal)(AV44TFEmployeeId_To), 10, 0))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV22Session.Get(AV61Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Main filter",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFAUDITID",  "Id",  !((0==AV26TFAuditId)&&(0==AV27TFAuditId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV26TFAuditId), 10, 0)),  ((0==AV26TFAuditId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV26TFAuditId), "ZZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV27TFAuditId_To), 10, 0)),  ((0==AV27TFAuditId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV27TFAuditId_To), "ZZZZZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFAUDITDATE",  "Date",  !((DateTime.MinValue==AV28TFAuditDate)&&(DateTime.MinValue==AV29TFAuditDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV28TFAuditDate, 2, "/")),  ((DateTime.MinValue==AV28TFAuditDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV28TFAuditDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV29TFAuditDate_To, 2, "/")),  ((DateTime.MinValue==AV29TFAuditDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV29TFAuditDate_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFAUDITTABLENAME",  "Table Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFAuditTableName)),  0,  AV33TFAuditTableName,  AV33TFAuditTableName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFAuditTableName_Sel)),  AV34TFAuditTableName_Sel,  AV34TFAuditTableName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFAUDITDESCRIPTION",  "Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFAuditDescription)),  0,  AV35TFAuditDescription,  AV35TFAuditDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFAuditDescription_Sel)),  AV36TFAuditDescription_Sel,  AV36TFAuditDescription_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFAUDITSHORTDESCRIPTION",  "Short Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFAuditShortDescription)),  0,  AV37TFAuditShortDescription,  AV37TFAuditShortDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFAuditShortDescription_Sel)),  AV38TFAuditShortDescription_Sel,  AV38TFAuditShortDescription_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFAUDITACTION",  "Action",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFAuditAction)),  0,  AV39TFAuditAction,  AV39TFAuditAction,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFAuditAction_Sel)),  AV40TFAuditAction_Sel,  AV40TFAuditAction_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSECUSERID",  "User Id",  !((0==AV41TFSecUserId)&&(0==AV42TFSecUserId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV41TFSecUserId), 10, 0)),  ((0==AV41TFSecUserId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV41TFSecUserId), "ZZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV42TFSecUserId_To), 10, 0)),  ((0==AV42TFSecUserId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV42TFSecUserId_To), "ZZZZZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFEMPLOYEEID",  "Id",  !((0==AV43TFEmployeeId)&&(0==AV44TFEmployeeId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFEmployeeId), 10, 0)),  ((0==AV43TFEmployeeId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV43TFEmployeeId), "ZZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFEmployeeId_To), 10, 0)),  ((0==AV44TFEmployeeId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV44TFEmployeeId_To), "ZZZZZZZZZ9")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFEMPLOYEENAME",  "Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFEmployeeName)),  0,  AV45TFEmployeeName,  AV45TFEmployeeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFEmployeeName_Sel)),  AV46TFEmployeeName_Sel,  AV46TFEmployeeName_Sel) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV61Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV61Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Audit";
         AV22Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S202( )
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
         new auditwwexport(context ).execute( out  AV16ExcelFilename, out  AV17ErrorMessage) ;
         if ( StringUtil.StrCmp(AV16ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV16ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV17ErrorMessage);
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
         PA5O2( ) ;
         WS5O2( ) ;
         WE5O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026182495452", true, true);
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
         context.AddJavascriptSource("auditww.js", "?2026182495457", false, true);
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

      protected void SubsflControlProps_392( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_39_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_39_idx;
         edtAuditId_Internalname = "AUDITID_"+sGXsfl_39_idx;
         edtAuditDate_Internalname = "AUDITDATE_"+sGXsfl_39_idx;
         edtAuditTableName_Internalname = "AUDITTABLENAME_"+sGXsfl_39_idx;
         edtAuditDescription_Internalname = "AUDITDESCRIPTION_"+sGXsfl_39_idx;
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION_"+sGXsfl_39_idx;
         edtAuditAction_Internalname = "AUDITACTION_"+sGXsfl_39_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_39_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_39_idx;
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_39_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_39_fel_idx;
         edtAuditId_Internalname = "AUDITID_"+sGXsfl_39_fel_idx;
         edtAuditDate_Internalname = "AUDITDATE_"+sGXsfl_39_fel_idx;
         edtAuditTableName_Internalname = "AUDITTABLENAME_"+sGXsfl_39_fel_idx;
         edtAuditDescription_Internalname = "AUDITDESCRIPTION_"+sGXsfl_39_fel_idx;
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION_"+sGXsfl_39_fel_idx;
         edtAuditAction_Internalname = "AUDITACTION_"+sGXsfl_39_fel_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_39_fel_idx;
         edtEmployeeId_Internalname = "EMPLOYEEID_"+sGXsfl_39_fel_idx;
         edtEmployeeName_Internalname = "EMPLOYEENAME_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WB5O0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_39_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_39_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV54Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Update",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV56Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Delete",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtAuditId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A204AuditId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A204AuditId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtAuditDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditDate_Internalname,context.localUtil.Format(A205AuditDate, "99/99/99"),context.localUtil.Format( A205AuditDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditTableName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditTableName_Internalname,StringUtil.RTrim( A206AuditTableName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditTableName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditTableName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditDescription_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditDescription_Internalname,(string)A207AuditDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditDescription_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditShortDescription_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditShortDescription_Internalname,(string)A208AuditShortDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditShortDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditShortDescription_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditAction_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditAction_Internalname,(string)A209AuditAction,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditAction_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditAction_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSecUserId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A210SecUserId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtSecUserId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtEmployeeId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEmployeeId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtEmployeeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,StringUtil.RTrim( A148EmployeeName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtEmployeeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes5O2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl39( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"39\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditTableName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Table Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditDescription_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditShortDescription_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Short Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditAction_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Action") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSecUserId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "User Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtEmployeeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV54Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV56Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A204AuditId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A205AuditDate, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A206AuditTableName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditTableName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A207AuditDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditDescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A208AuditShortDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditShortDescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A209AuditAction));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditAction_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecUserId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A148EmployeeName)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeName_Visible), 5, 0, ".", "")));
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
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtAuditId_Internalname = "AUDITID";
         edtAuditDate_Internalname = "AUDITDATE";
         edtAuditTableName_Internalname = "AUDITTABLENAME";
         edtAuditDescription_Internalname = "AUDITDESCRIPTION";
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION";
         edtAuditAction_Internalname = "AUDITACTION";
         edtSecUserId_Internalname = "SECUSERID";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_auditdateauxdatetext_Internalname = "vDDO_AUDITDATEAUXDATETEXT";
         Tfauditdate_rangepicker_Internalname = "TFAUDITDATE_RANGEPICKER";
         divDdo_auditdateauxdates_Internalname = "DDO_AUDITDATEAUXDATES";
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
         edtEmployeeName_Jsonclick = "";
         edtEmployeeId_Jsonclick = "";
         edtSecUserId_Jsonclick = "";
         edtAuditAction_Jsonclick = "";
         edtAuditShortDescription_Jsonclick = "";
         edtAuditDescription_Jsonclick = "";
         edtAuditTableName_Jsonclick = "";
         edtAuditDate_Jsonclick = "";
         edtAuditId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtEmployeeName_Visible = -1;
         edtEmployeeId_Visible = -1;
         edtSecUserId_Visible = -1;
         edtAuditAction_Visible = -1;
         edtAuditShortDescription_Visible = -1;
         edtAuditDescription_Visible = -1;
         edtAuditTableName_Visible = -1;
         edtAuditDate_Visible = -1;
         edtAuditId_Visible = -1;
         edtEmployeeName_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtSecUserId_Enabled = 0;
         edtAuditAction_Enabled = 0;
         edtAuditShortDescription_Enabled = 0;
         edtAuditDescription_Enabled = 0;
         edtAuditTableName_Enabled = 0;
         edtAuditDate_Enabled = 0;
         edtAuditId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_auditdateauxdatetext_Jsonclick = "";
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
         Ddo_grid_Format = "10.0||||||10.0|10.0|";
         Ddo_grid_Datalistproc = "AuditWWGetFilterData";
         Ddo_grid_Datalisttype = "||Dynamic|Dynamic|Dynamic|Dynamic|||Dynamic";
         Ddo_grid_Includedatalist = "||T|T|T|T|||T";
         Ddo_grid_Filterisrange = "T|P|||||T|T|";
         Ddo_grid_Filtertype = "Numeric|Date|Character|Character|Character|Character|Numeric|Numeric|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9";
         Ddo_grid_Columnids = "2:AuditId|3:AuditDate|4:AuditTableName|5:AuditDescription|6:AuditShortDescription|7:AuditAction|8:SecUserId|9:EmployeeId|10:EmployeeName";
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
         Form.Caption = " Audit";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtAuditId_Visible","ctrl":"AUDITID","prop":"Visible"},{"av":"edtAuditDate_Visible","ctrl":"AUDITDATE","prop":"Visible"},{"av":"edtAuditTableName_Visible","ctrl":"AUDITTABLENAME","prop":"Visible"},{"av":"edtAuditDescription_Visible","ctrl":"AUDITDESCRIPTION","prop":"Visible"},{"av":"edtAuditShortDescription_Visible","ctrl":"AUDITSHORTDESCRIPTION","prop":"Visible"},{"av":"edtAuditAction_Visible","ctrl":"AUDITACTION","prop":"Visible"},{"av":"edtSecUserId_Visible","ctrl":"SECUSERID","prop":"Visible"},{"av":"edtEmployeeId_Visible","ctrl":"EMPLOYEEID","prop":"Visible"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV23ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E125O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E135O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E155O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E205O2","iparms":[{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A204AuditId","fld":"AUDITID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV54Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV56Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E165O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtAuditId_Visible","ctrl":"AUDITID","prop":"Visible"},{"av":"edtAuditDate_Visible","ctrl":"AUDITDATE","prop":"Visible"},{"av":"edtAuditTableName_Visible","ctrl":"AUDITTABLENAME","prop":"Visible"},{"av":"edtAuditDescription_Visible","ctrl":"AUDITDESCRIPTION","prop":"Visible"},{"av":"edtAuditShortDescription_Visible","ctrl":"AUDITSHORTDESCRIPTION","prop":"Visible"},{"av":"edtAuditAction_Visible","ctrl":"AUDITACTION","prop":"Visible"},{"av":"edtSecUserId_Visible","ctrl":"SECUSERID","prop":"Visible"},{"av":"edtEmployeeId_Visible","ctrl":"EMPLOYEEID","prop":"Visible"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV23ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E115O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtAuditId_Visible","ctrl":"AUDITID","prop":"Visible"},{"av":"edtAuditDate_Visible","ctrl":"AUDITDATE","prop":"Visible"},{"av":"edtAuditTableName_Visible","ctrl":"AUDITTABLENAME","prop":"Visible"},{"av":"edtAuditDescription_Visible","ctrl":"AUDITDESCRIPTION","prop":"Visible"},{"av":"edtAuditShortDescription_Visible","ctrl":"AUDITSHORTDESCRIPTION","prop":"Visible"},{"av":"edtAuditAction_Visible","ctrl":"AUDITACTION","prop":"Visible"},{"av":"edtSecUserId_Visible","ctrl":"SECUSERID","prop":"Visible"},{"av":"edtEmployeeId_Visible","ctrl":"EMPLOYEEID","prop":"Visible"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV23ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E175O2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A204AuditId","fld":"AUDITID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtAuditId_Visible","ctrl":"AUDITID","prop":"Visible"},{"av":"edtAuditDate_Visible","ctrl":"AUDITDATE","prop":"Visible"},{"av":"edtAuditTableName_Visible","ctrl":"AUDITTABLENAME","prop":"Visible"},{"av":"edtAuditDescription_Visible","ctrl":"AUDITDESCRIPTION","prop":"Visible"},{"av":"edtAuditShortDescription_Visible","ctrl":"AUDITSHORTDESCRIPTION","prop":"Visible"},{"av":"edtAuditAction_Visible","ctrl":"AUDITACTION","prop":"Visible"},{"av":"edtSecUserId_Visible","ctrl":"SECUSERID","prop":"Visible"},{"av":"edtEmployeeId_Visible","ctrl":"EMPLOYEEID","prop":"Visible"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV23ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV10GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","""{"handler":"E145O2","iparms":[{"av":"Ddo_agexport_Activeeventkey","ctrl":"DDO_AGEXPORT","prop":"ActiveEventKey"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV25ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV20ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV26TFAuditId","fld":"vTFAUDITID","pic":"ZZZZZZZZZ9"},{"av":"AV27TFAuditId_To","fld":"vTFAUDITID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV28TFAuditDate","fld":"vTFAUDITDATE"},{"av":"AV29TFAuditDate_To","fld":"vTFAUDITDATE_TO"},{"av":"AV33TFAuditTableName","fld":"vTFAUDITTABLENAME"},{"av":"AV34TFAuditTableName_Sel","fld":"vTFAUDITTABLENAME_SEL"},{"av":"AV35TFAuditDescription","fld":"vTFAUDITDESCRIPTION"},{"av":"AV36TFAuditDescription_Sel","fld":"vTFAUDITDESCRIPTION_SEL"},{"av":"AV37TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV38TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV39TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV40TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV41TFSecUserId","fld":"vTFSECUSERID","pic":"ZZZZZZZZZ9"},{"av":"AV42TFSecUserId_To","fld":"vTFSECUSERID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV43TFEmployeeId","fld":"vTFEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV44TFEmployeeId_To","fld":"vTFEMPLOYEEID_TO","pic":"ZZZZZZZZZ9"},{"av":"AV45TFEmployeeName","fld":"vTFEMPLOYEENAME"},{"av":"AV46TFEmployeeName_Sel","fld":"vTFEMPLOYEENAME_SEL"},{"av":"AV55IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV57IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV60IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"}]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Employeename","iparms":[]}""");
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
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV20ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV61Pgmname = "";
         AV28TFAuditDate = DateTime.MinValue;
         AV29TFAuditDate_To = DateTime.MinValue;
         AV33TFAuditTableName = "";
         AV34TFAuditTableName_Sel = "";
         AV35TFAuditDescription = "";
         AV36TFAuditDescription_Sel = "";
         AV37TFAuditShortDescription = "";
         AV38TFAuditShortDescription_Sel = "";
         AV39TFAuditAction = "";
         AV40TFAuditAction_Sel = "";
         AV45TFEmployeeName = "";
         AV46TFEmployeeName_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV23ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV53GridAppliedFilters = "";
         AV58AGExportData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV47DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV30DDO_AuditDateAuxDate = DateTime.MinValue;
         AV31DDO_AuditDateAuxDateTo = DateTime.MinValue;
         AV10GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
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
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV32DDO_AuditDateAuxDateText = "";
         ucTfauditdate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV54Update = "";
         AV56Delete = "";
         A205AuditDate = DateTime.MinValue;
         A206AuditTableName = "";
         A207AuditDescription = "";
         A208AuditShortDescription = "";
         A209AuditAction = "";
         A148EmployeeName = "";
         lV62Auditwwds_1_filterfulltext = "";
         lV67Auditwwds_6_tfaudittablename = "";
         lV69Auditwwds_8_tfauditdescription = "";
         lV71Auditwwds_10_tfauditshortdescription = "";
         lV73Auditwwds_12_tfauditaction = "";
         lV79Auditwwds_18_tfemployeename = "";
         AV62Auditwwds_1_filterfulltext = "";
         AV65Auditwwds_4_tfauditdate = DateTime.MinValue;
         AV66Auditwwds_5_tfauditdate_to = DateTime.MinValue;
         AV68Auditwwds_7_tfaudittablename_sel = "";
         AV67Auditwwds_6_tfaudittablename = "";
         AV70Auditwwds_9_tfauditdescription_sel = "";
         AV69Auditwwds_8_tfauditdescription = "";
         AV72Auditwwds_11_tfauditshortdescription_sel = "";
         AV71Auditwwds_10_tfauditshortdescription = "";
         AV74Auditwwds_13_tfauditaction_sel = "";
         AV73Auditwwds_12_tfauditaction = "";
         AV80Auditwwds_19_tfemployeename_sel = "";
         AV79Auditwwds_18_tfemployeename = "";
         H005O2_A148EmployeeName = new string[] {""} ;
         H005O2_A106EmployeeId = new long[1] ;
         H005O2_A210SecUserId = new long[1] ;
         H005O2_A209AuditAction = new string[] {""} ;
         H005O2_A208AuditShortDescription = new string[] {""} ;
         H005O2_A207AuditDescription = new string[] {""} ;
         H005O2_A206AuditTableName = new string[] {""} ;
         H005O2_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         H005O2_A204AuditId = new long[1] ;
         H005O3_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         AV59AGExportDataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV48GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV49GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV22Session = context.GetSession();
         AV18ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV24ManageFiltersXml = "";
         AV19UserCustomValue = "";
         AV21ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV11GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV16ExcelFilename = "";
         AV17ErrorMessage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.auditww__default(),
            new Object[][] {
                new Object[] {
               H005O2_A148EmployeeName, H005O2_A106EmployeeId, H005O2_A210SecUserId, H005O2_A209AuditAction, H005O2_A208AuditShortDescription, H005O2_A207AuditDescription, H005O2_A206AuditTableName, H005O2_A205AuditDate, H005O2_A204AuditId
               }
               , new Object[] {
               H005O3_AGRID_nRecordCount
               }
            }
         );
         AV61Pgmname = "AuditWW";
         /* GeneXus formulas. */
         AV61Pgmname = "AuditWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12OrderedBy ;
      private short AV25ManageFiltersExecutionStep ;
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
      private int nRC_GXsfl_39 ;
      private int nGXsfl_39_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtAuditId_Enabled ;
      private int edtAuditDate_Enabled ;
      private int edtAuditTableName_Enabled ;
      private int edtAuditDescription_Enabled ;
      private int edtAuditShortDescription_Enabled ;
      private int edtAuditAction_Enabled ;
      private int edtSecUserId_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeName_Enabled ;
      private int edtAuditId_Visible ;
      private int edtAuditDate_Visible ;
      private int edtAuditTableName_Visible ;
      private int edtAuditDescription_Visible ;
      private int edtAuditShortDescription_Visible ;
      private int edtAuditAction_Visible ;
      private int edtSecUserId_Visible ;
      private int edtEmployeeId_Visible ;
      private int edtEmployeeName_Visible ;
      private int AV50PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV81GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV26TFAuditId ;
      private long AV27TFAuditId_To ;
      private long AV41TFSecUserId ;
      private long AV42TFSecUserId_To ;
      private long AV43TFEmployeeId ;
      private long AV44TFEmployeeId_To ;
      private long AV51GridCurrentPage ;
      private long AV52GridPageCount ;
      private long A204AuditId ;
      private long A210SecUserId ;
      private long A106EmployeeId ;
      private long GRID_nCurrentRecord ;
      private long AV63Auditwwds_2_tfauditid ;
      private long AV64Auditwwds_3_tfauditid_to ;
      private long AV75Auditwwds_14_tfsecuserid ;
      private long AV76Auditwwds_15_tfsecuserid_to ;
      private long AV77Auditwwds_16_tfemployeeid ;
      private long AV78Auditwwds_17_tfemployeeid_to ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV61Pgmname ;
      private string AV33TFAuditTableName ;
      private string AV34TFAuditTableName_Sel ;
      private string AV45TFEmployeeName ;
      private string AV46TFEmployeeName_Sel ;
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
      private string divDdo_auditdateauxdates_Internalname ;
      private string edtavDdo_auditdateauxdatetext_Internalname ;
      private string edtavDdo_auditdateauxdatetext_Jsonclick ;
      private string Tfauditdate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV54Update ;
      private string edtavUpdate_Internalname ;
      private string AV56Delete ;
      private string edtavDelete_Internalname ;
      private string edtAuditId_Internalname ;
      private string edtAuditDate_Internalname ;
      private string A206AuditTableName ;
      private string edtAuditTableName_Internalname ;
      private string edtAuditDescription_Internalname ;
      private string edtAuditShortDescription_Internalname ;
      private string edtAuditAction_Internalname ;
      private string edtSecUserId_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string A148EmployeeName ;
      private string edtEmployeeName_Internalname ;
      private string lV67Auditwwds_6_tfaudittablename ;
      private string lV79Auditwwds_18_tfemployeename ;
      private string AV68Auditwwds_7_tfaudittablename_sel ;
      private string AV67Auditwwds_6_tfaudittablename ;
      private string AV80Auditwwds_19_tfemployeename_sel ;
      private string AV79Auditwwds_18_tfemployeename ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char2 ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtAuditId_Jsonclick ;
      private string edtAuditDate_Jsonclick ;
      private string edtAuditTableName_Jsonclick ;
      private string edtAuditDescription_Jsonclick ;
      private string edtAuditShortDescription_Jsonclick ;
      private string edtAuditAction_Jsonclick ;
      private string edtSecUserId_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeName_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV28TFAuditDate ;
      private DateTime AV29TFAuditDate_To ;
      private DateTime AV30DDO_AuditDateAuxDate ;
      private DateTime AV31DDO_AuditDateAuxDateTo ;
      private DateTime A205AuditDate ;
      private DateTime AV65Auditwwds_4_tfauditdate ;
      private DateTime AV66Auditwwds_5_tfauditdate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool AV55IsAuthorized_Update ;
      private bool AV57IsAuthorized_Delete ;
      private bool AV60IsAuthorized_Insert ;
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
      private bool bGXsfl_39_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean3 ;
      private string AV18ColumnsSelectorXML ;
      private string AV24ManageFiltersXml ;
      private string AV19UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV35TFAuditDescription ;
      private string AV36TFAuditDescription_Sel ;
      private string AV37TFAuditShortDescription ;
      private string AV38TFAuditShortDescription_Sel ;
      private string AV39TFAuditAction ;
      private string AV40TFAuditAction_Sel ;
      private string AV53GridAppliedFilters ;
      private string AV32DDO_AuditDateAuxDateText ;
      private string A207AuditDescription ;
      private string A208AuditShortDescription ;
      private string A209AuditAction ;
      private string lV62Auditwwds_1_filterfulltext ;
      private string lV69Auditwwds_8_tfauditdescription ;
      private string lV71Auditwwds_10_tfauditshortdescription ;
      private string lV73Auditwwds_12_tfauditaction ;
      private string AV62Auditwwds_1_filterfulltext ;
      private string AV70Auditwwds_9_tfauditdescription_sel ;
      private string AV69Auditwwds_8_tfauditdescription ;
      private string AV72Auditwwds_11_tfauditshortdescription_sel ;
      private string AV71Auditwwds_10_tfauditshortdescription ;
      private string AV74Auditwwds_13_tfauditaction_sel ;
      private string AV73Auditwwds_12_tfauditaction ;
      private string AV16ExcelFilename ;
      private string AV17ErrorMessage ;
      private IGxSession AV22Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfauditdate_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV20ColumnsSelector ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV23ManageFiltersData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV58AGExportData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV47DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV10GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H005O2_A148EmployeeName ;
      private long[] H005O2_A106EmployeeId ;
      private long[] H005O2_A210SecUserId ;
      private string[] H005O2_A209AuditAction ;
      private string[] H005O2_A208AuditShortDescription ;
      private string[] H005O2_A207AuditDescription ;
      private string[] H005O2_A206AuditTableName ;
      private DateTime[] H005O2_A205AuditDate ;
      private long[] H005O2_A204AuditId ;
      private long[] H005O3_AGRID_nRecordCount ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item AV59AGExportDataItem ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV48GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV49GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV21ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class auditww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005O2( IGxContext context ,
                                             string AV62Auditwwds_1_filterfulltext ,
                                             long AV63Auditwwds_2_tfauditid ,
                                             long AV64Auditwwds_3_tfauditid_to ,
                                             DateTime AV65Auditwwds_4_tfauditdate ,
                                             DateTime AV66Auditwwds_5_tfauditdate_to ,
                                             string AV68Auditwwds_7_tfaudittablename_sel ,
                                             string AV67Auditwwds_6_tfaudittablename ,
                                             string AV70Auditwwds_9_tfauditdescription_sel ,
                                             string AV69Auditwwds_8_tfauditdescription ,
                                             string AV72Auditwwds_11_tfauditshortdescription_sel ,
                                             string AV71Auditwwds_10_tfauditshortdescription ,
                                             string AV74Auditwwds_13_tfauditaction_sel ,
                                             string AV73Auditwwds_12_tfauditaction ,
                                             long AV75Auditwwds_14_tfsecuserid ,
                                             long AV76Auditwwds_15_tfsecuserid_to ,
                                             long AV77Auditwwds_16_tfemployeeid ,
                                             long AV78Auditwwds_17_tfemployeeid_to ,
                                             string AV80Auditwwds_19_tfemployeename_sel ,
                                             string AV79Auditwwds_18_tfemployeename ,
                                             long A204AuditId ,
                                             string A206AuditTableName ,
                                             string A207AuditDescription ,
                                             string A208AuditShortDescription ,
                                             string A209AuditAction ,
                                             long A210SecUserId ,
                                             long A106EmployeeId ,
                                             string A148EmployeeName ,
                                             DateTime A205AuditDate ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[29];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.EmployeeName, T1.EmployeeId, T1.SecUserId, T1.AuditAction, T1.AuditShortDescription, T1.AuditDescription, T1.AuditTableName, T1.AuditDate, T1.AuditId";
         sFromString = " FROM (Audit T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.AuditId,'9999999999'), 2) like '%' || :lV62Auditwwds_1_filterfulltext) or ( LOWER(T1.AuditTableName) like '%' || LOWER(:lV62Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditDescription) like '%' || LOWER(:lV62Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditShortDescription) like '%' || LOWER(:lV62Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditAction) like '%' || LOWER(:lV62Auditwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.SecUserId,'9999999999'), 2) like '%' || :lV62Auditwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV62Auditwwds_1_filterfulltext) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV62Auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
         }
         if ( ! (0==AV63Auditwwds_2_tfauditid) )
         {
            AddWhere(sWhereString, "(T1.AuditId >= :AV63Auditwwds_2_tfauditid)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! (0==AV64Auditwwds_3_tfauditid_to) )
         {
            AddWhere(sWhereString, "(T1.AuditId <= :AV64Auditwwds_3_tfauditid_to)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Auditwwds_4_tfauditdate) )
         {
            AddWhere(sWhereString, "(T1.AuditDate >= :AV65Auditwwds_4_tfauditdate)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Auditwwds_5_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(T1.AuditDate <= :AV66Auditwwds_5_tfauditdate_to)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName like :lV67Auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV68Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName = ( :AV68Auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV68Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Auditwwds_9_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Auditwwds_8_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription like :lV69Auditwwds_8_tfauditdescription)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Auditwwds_9_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV70Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription = ( :AV70Auditwwds_9_tfauditdescription_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV70Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription like :lV71Auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV72Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription = ( :AV72Auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( StringUtil.StrCmp(AV72Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Auditwwds_13_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Auditwwds_12_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction like :lV73Auditwwds_12_tfauditaction)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Auditwwds_13_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV74Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction = ( :AV74Auditwwds_13_tfauditaction_sel))");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( StringUtil.StrCmp(AV74Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditAction))=0))");
         }
         if ( ! (0==AV75Auditwwds_14_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.SecUserId >= :AV75Auditwwds_14_tfsecuserid)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! (0==AV76Auditwwds_15_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserId <= :AV76Auditwwds_15_tfsecuserid_to)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! (0==AV77Auditwwds_16_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV77Auditwwds_16_tfemployeeid)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! (0==AV78Auditwwds_17_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV78Auditwwds_17_tfemployeeid_to)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Auditwwds_19_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Auditwwds_18_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV79Auditwwds_18_tfemployeename)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Auditwwds_19_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV80Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV80Auditwwds_19_tfemployeename_sel))");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( StringUtil.StrCmp(AV80Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AuditDate, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AuditDate DESC, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AuditId DESC";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AuditTableName, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AuditTableName DESC, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AuditDescription, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AuditDescription DESC, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AuditShortDescription, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AuditShortDescription DESC, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AuditAction, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AuditAction DESC, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecUserId, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecUserId DESC, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.EmployeeId, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.EmployeeId DESC, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T2.EmployeeName, T1.AuditId";
         }
         else if ( ( AV12OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.EmployeeName DESC, T1.AuditId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.AuditId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H005O3( IGxContext context ,
                                             string AV62Auditwwds_1_filterfulltext ,
                                             long AV63Auditwwds_2_tfauditid ,
                                             long AV64Auditwwds_3_tfauditid_to ,
                                             DateTime AV65Auditwwds_4_tfauditdate ,
                                             DateTime AV66Auditwwds_5_tfauditdate_to ,
                                             string AV68Auditwwds_7_tfaudittablename_sel ,
                                             string AV67Auditwwds_6_tfaudittablename ,
                                             string AV70Auditwwds_9_tfauditdescription_sel ,
                                             string AV69Auditwwds_8_tfauditdescription ,
                                             string AV72Auditwwds_11_tfauditshortdescription_sel ,
                                             string AV71Auditwwds_10_tfauditshortdescription ,
                                             string AV74Auditwwds_13_tfauditaction_sel ,
                                             string AV73Auditwwds_12_tfauditaction ,
                                             long AV75Auditwwds_14_tfsecuserid ,
                                             long AV76Auditwwds_15_tfsecuserid_to ,
                                             long AV77Auditwwds_16_tfemployeeid ,
                                             long AV78Auditwwds_17_tfemployeeid_to ,
                                             string AV80Auditwwds_19_tfemployeename_sel ,
                                             string AV79Auditwwds_18_tfemployeename ,
                                             long A204AuditId ,
                                             string A206AuditTableName ,
                                             string A207AuditDescription ,
                                             string A208AuditShortDescription ,
                                             string A209AuditAction ,
                                             long A210SecUserId ,
                                             long A106EmployeeId ,
                                             string A148EmployeeName ,
                                             DateTime A205AuditDate ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[26];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (Audit T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.AuditId,'9999999999'), 2) like '%' || :lV62Auditwwds_1_filterfulltext) or ( LOWER(T1.AuditTableName) like '%' || LOWER(:lV62Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditDescription) like '%' || LOWER(:lV62Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditShortDescription) like '%' || LOWER(:lV62Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditAction) like '%' || LOWER(:lV62Auditwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.SecUserId,'9999999999'), 2) like '%' || :lV62Auditwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV62Auditwwds_1_filterfulltext) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV62Auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
         }
         if ( ! (0==AV63Auditwwds_2_tfauditid) )
         {
            AddWhere(sWhereString, "(T1.AuditId >= :AV63Auditwwds_2_tfauditid)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! (0==AV64Auditwwds_3_tfauditid_to) )
         {
            AddWhere(sWhereString, "(T1.AuditId <= :AV64Auditwwds_3_tfauditid_to)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Auditwwds_4_tfauditdate) )
         {
            AddWhere(sWhereString, "(T1.AuditDate >= :AV65Auditwwds_4_tfauditdate)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Auditwwds_5_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(T1.AuditDate <= :AV66Auditwwds_5_tfauditdate_to)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName like :lV67Auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV68Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName = ( :AV68Auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( StringUtil.StrCmp(AV68Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Auditwwds_9_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Auditwwds_8_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription like :lV69Auditwwds_8_tfauditdescription)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Auditwwds_9_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV70Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription = ( :AV70Auditwwds_9_tfauditdescription_sel))");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( StringUtil.StrCmp(AV70Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription like :lV71Auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV72Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription = ( :AV72Auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( StringUtil.StrCmp(AV72Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Auditwwds_13_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Auditwwds_12_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction like :lV73Auditwwds_12_tfauditaction)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Auditwwds_13_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV74Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction = ( :AV74Auditwwds_13_tfauditaction_sel))");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( StringUtil.StrCmp(AV74Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditAction))=0))");
         }
         if ( ! (0==AV75Auditwwds_14_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.SecUserId >= :AV75Auditwwds_14_tfsecuserid)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! (0==AV76Auditwwds_15_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserId <= :AV76Auditwwds_15_tfsecuserid_to)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( ! (0==AV77Auditwwds_16_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV77Auditwwds_16_tfemployeeid)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( ! (0==AV78Auditwwds_17_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV78Auditwwds_17_tfemployeeid_to)");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Auditwwds_19_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Auditwwds_18_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV79Auditwwds_18_tfemployeename)");
         }
         else
         {
            GXv_int11[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Auditwwds_19_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV80Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV80Auditwwds_19_tfemployeename_sel))");
         }
         else
         {
            GXv_int11[25] = 1;
         }
         if ( StringUtil.StrCmp(AV80Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005O2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] );
               case 1 :
                     return conditional_H005O3(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] );
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
          Object[] prmH005O2;
          prmH005O2 = new Object[] {
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Auditwwds_2_tfauditid",GXType.Int64,10,0) ,
          new ParDef("AV64Auditwwds_3_tfauditid_to",GXType.Int64,10,0) ,
          new ParDef("AV65Auditwwds_4_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV66Auditwwds_5_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("lV67Auditwwds_6_tfaudittablename",GXType.Char,100,0) ,
          new ParDef("AV68Auditwwds_7_tfaudittablename_sel",GXType.Char,100,0) ,
          new ParDef("lV69Auditwwds_8_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV70Auditwwds_9_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV71Auditwwds_10_tfauditshortdescription",GXType.VarChar,200,0) ,
          new ParDef("AV72Auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV73Auditwwds_12_tfauditaction",GXType.VarChar,10,0) ,
          new ParDef("AV74Auditwwds_13_tfauditaction_sel",GXType.VarChar,10,0) ,
          new ParDef("AV75Auditwwds_14_tfsecuserid",GXType.Int64,10,0) ,
          new ParDef("AV76Auditwwds_15_tfsecuserid_to",GXType.Int64,10,0) ,
          new ParDef("AV77Auditwwds_16_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV78Auditwwds_17_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV79Auditwwds_18_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV80Auditwwds_19_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005O3;
          prmH005O3 = new Object[] {
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Auditwwds_2_tfauditid",GXType.Int64,10,0) ,
          new ParDef("AV64Auditwwds_3_tfauditid_to",GXType.Int64,10,0) ,
          new ParDef("AV65Auditwwds_4_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV66Auditwwds_5_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("lV67Auditwwds_6_tfaudittablename",GXType.Char,100,0) ,
          new ParDef("AV68Auditwwds_7_tfaudittablename_sel",GXType.Char,100,0) ,
          new ParDef("lV69Auditwwds_8_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV70Auditwwds_9_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV71Auditwwds_10_tfauditshortdescription",GXType.VarChar,200,0) ,
          new ParDef("AV72Auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV73Auditwwds_12_tfauditaction",GXType.VarChar,10,0) ,
          new ParDef("AV74Auditwwds_13_tfauditaction_sel",GXType.VarChar,10,0) ,
          new ParDef("AV75Auditwwds_14_tfsecuserid",GXType.Int64,10,0) ,
          new ParDef("AV76Auditwwds_15_tfsecuserid_to",GXType.Int64,10,0) ,
          new ParDef("AV77Auditwwds_16_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV78Auditwwds_17_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV79Auditwwds_18_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV80Auditwwds_19_tfemployeename_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O3,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
