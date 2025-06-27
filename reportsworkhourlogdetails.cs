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
   public class reportsworkhourlogdetails : GXWebComponent
   {
      public reportsworkhourlogdetails( )
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

      public reportsworkhourlogdetails( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           string aP1_EmployeeName ,
                           DateTime aP2_FromDate ,
                           DateTime aP3_ToDate ,
                           ref long aP4_OneProjectId )
      {
         this.AV34EmployeeId = aP0_EmployeeId;
         this.AV37EmployeeName = aP1_EmployeeName;
         this.AV41FromDate = aP2_FromDate;
         this.AV42ToDate = aP3_ToDate;
         this.AV43OneProjectId = aP4_OneProjectId;
         ExecuteImpl();
         aP4_OneProjectId=this.AV43OneProjectId;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "EmployeeId");
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
                  AV34EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV34EmployeeId", StringUtil.LTrimStr( (decimal)(AV34EmployeeId), 10, 0));
                  AV37EmployeeName = GetPar( "EmployeeName");
                  AssignAttri(sPrefix, false, "AV37EmployeeName", AV37EmployeeName);
                  AV41FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
                  AssignAttri(sPrefix, false, "AV41FromDate", context.localUtil.Format(AV41FromDate, "99/99/99"));
                  AV42ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
                  AssignAttri(sPrefix, false, "AV42ToDate", context.localUtil.Format(AV42ToDate, "99/99/99"));
                  AV43OneProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "OneProjectId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV43OneProjectId", StringUtil.LTrimStr( (decimal)(AV43OneProjectId), 10, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV34EmployeeId,(string)AV37EmployeeName,(DateTime)AV41FromDate,(DateTime)AV42ToDate,(long)AV43OneProjectId});
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
                  gxfirstwebparm = GetFirstPar( "EmployeeId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "EmployeeId");
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
         nRC_GXsfl_15 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV34EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
         AV41FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV42ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         AV43OneProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "OneProjectId"), "."), 18, MidpointRounding.ToEven));
         AV47Pgmname = GetPar( "Pgmname");
         AV16TFWorkHourLogDate = context.localUtil.ParseDateParm( GetPar( "TFWorkHourLogDate"));
         AV17TFWorkHourLogDate_To = context.localUtil.ParseDateParm( GetPar( "TFWorkHourLogDate_To"));
         AV21TFProjectName = GetPar( "TFProjectName");
         AV22TFProjectName_Sel = GetPar( "TFProjectName_Sel");
         AV23TFWorkHourLogDuration = GetPar( "TFWorkHourLogDuration");
         AV24TFWorkHourLogDuration_Sel = GetPar( "TFWorkHourLogDuration_Sel");
         AV25TFWorkHourLogDescription = GetPar( "TFWorkHourLogDescription");
         AV26TFWorkHourLogDescription_Sel = GetPar( "TFWorkHourLogDescription_Sel");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34EmployeeId, AV41FromDate, AV42ToDate, AV43OneProjectId, AV47Pgmname, AV16TFWorkHourLogDate, AV17TFWorkHourLogDate_To, AV21TFProjectName, AV22TFProjectName_Sel, AV23TFWorkHourLogDuration, AV24TFWorkHourLogDuration_Sel, AV25TFWorkHourLogDescription, AV26TFWorkHourLogDescription_Sel, sPrefix) ;
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
            PA4K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV47Pgmname = "ReportsWorkHourLogDetails";
               WS4K2( ) ;
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
            context.SendWebValue( " Work Hour Log") ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reportsworkhourlogdetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV34EmployeeId,10,0)),UrlEncode(StringUtil.RTrim(AV37EmployeeName)),UrlEncode(DateTimeUtil.FormatDateParm(AV41FromDate)),UrlEncode(DateTimeUtil.FormatDateParm(AV42ToDate)),UrlEncode(StringUtil.LTrimStr(AV43OneProjectId,10,0))}, new string[] {"EmployeeId","EmployeeName","FromDate","ToDate","OneProjectId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV47Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV33GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV27DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV27DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_WORKHOURLOGDATEAUXDATE", context.localUtil.DToC( AV18DDO_WorkHourLogDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_WORKHOURLOGDATEAUXDATETO", context.localUtil.DToC( AV19DDO_WorkHourLogDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV34EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV34EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV37EmployeeName", StringUtil.RTrim( wcpOAV37EmployeeName));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV41FromDate", context.localUtil.DToC( wcpOAV41FromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV42ToDate", context.localUtil.DToC( wcpOAV42ToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV43OneProjectId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV43OneProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV47Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWORKHOURLOGDATE", context.localUtil.DToC( AV16TFWorkHourLogDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWORKHOURLOGDATE_TO", context.localUtil.DToC( AV17TFWorkHourLogDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROJECTNAME", StringUtil.RTrim( AV21TFProjectName));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROJECTNAME_SEL", StringUtil.RTrim( AV22TFProjectName_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWORKHOURLOGDURATION", AV23TFWorkHourLogDuration);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWORKHOURLOGDURATION_SEL", AV24TFWorkHourLogDuration_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWORKHOURLOGDESCRIPTION", AV25TFWorkHourLogDescription);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFWORKHOURLOGDESCRIPTION_SEL", AV26TFWorkHourLogDescription_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vEMPLOYEENAME", StringUtil.RTrim( AV37EmployeeName));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFROMDATE", context.localUtil.DToC( AV41FromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODATE", context.localUtil.DToC( AV42ToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vONEPROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43OneProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
      }

      protected void RenderHtmlCloseForm4K2( )
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
         return "ReportsWorkHourLogDetails" ;
      }

      public override string GetPgmdesc( )
      {
         return " Work Hour Log" ;
      }

      protected void WB4K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "reportsworkhourlogdetails.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, divTablemain_Width, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, lblTextblock1_Caption, "", "", lblTextblock1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "font-size:"+StringUtil.Str( (decimal)(lblTextblock1_Fontsize), 3, 0)+"pt;"+((lblTextblock1_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ReportsWorkHourLogDetails.htm");
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
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV31GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV32GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV33GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV27DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_workhourlogdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'" + sGXsfl_15_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_workhourlogdateauxdatetext_Internalname, AV20DDO_WorkHourLogDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV20DDO_WorkHourLogDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_workhourlogdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReportsWorkHourLogDetails.htm");
            /* User Defined Control */
            ucTfworkhourlogdate_rangepicker.SetProperty("Start Date", AV18DDO_WorkHourLogDateAuxDate);
            ucTfworkhourlogdate_rangepicker.SetProperty("End Date", AV19DDO_WorkHourLogDateAuxDateTo);
            ucTfworkhourlogdate_rangepicker.Render(context, "wwp.daterangepicker", Tfworkhourlogdate_rangepicker_Internalname, sPrefix+"TFWORKHOURLOGDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 15 )
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

      protected void START4K2( )
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
            Form.Meta.addItem("description", " Work Hour Log", 0) ;
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
               STRUP4K0( ) ;
            }
         }
      }

      protected void WS4K2( )
      {
         START4K2( ) ;
         EVT4K2( ) ;
      }

      protected void EVT4K2( )
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
                                 STRUP4K0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E114K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E124K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E134K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDdo_workhourlogdateauxdatetext_Internalname;
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
                                 STRUP4K0( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              A118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A119WorkHourLogDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtWorkHourLogDate_Internalname), 0));
                              A103ProjectName = cgiGet( edtProjectName_Internalname);
                              A120WorkHourLogDuration = cgiGet( edtWorkHourLogDuration_Internalname);
                              A121WorkHourLogHour = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogHour_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A122WorkHourLogMinute = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogMinute_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A123WorkHourLogDescription = cgiGet( edtWorkHourLogDescription_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A107EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
                              A102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
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
                                          GX_FocusControl = edtavDdo_workhourlogdateauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E144K2 ();
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
                                          GX_FocusControl = edtavDdo_workhourlogdateauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E154K2 ();
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
                                          GX_FocusControl = edtavDdo_workhourlogdateauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E164K2 ();
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
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV13OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
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
                                       STRUP4K0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDdo_workhourlogdateauxdatetext_Internalname;
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

      protected void WE4K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4K2( ) ;
            }
         }
      }

      protected void PA4K2( )
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
               GX_FocusControl = edtavDdo_workhourlogdateauxdatetext_Internalname;
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
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       long AV34EmployeeId ,
                                       DateTime AV41FromDate ,
                                       DateTime AV42ToDate ,
                                       long AV43OneProjectId ,
                                       string AV47Pgmname ,
                                       DateTime AV16TFWorkHourLogDate ,
                                       DateTime AV17TFWorkHourLogDate_To ,
                                       string AV21TFProjectName ,
                                       string AV22TFProjectName_Sel ,
                                       string AV23TFWorkHourLogDuration ,
                                       string AV24TFWorkHourLogDuration_Sel ,
                                       string AV25TFWorkHourLogDescription ,
                                       string AV26TFWorkHourLogDescription_Sel ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4K2( ) ;
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
         RF4K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV47Pgmname = "ReportsWorkHourLogDetails";
      }

      protected void RF4K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E154K2 ();
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            SubsflControlProps_152( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate ,
                                                 AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ,
                                                 AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel ,
                                                 AV50Reportsworkhourlogdetailsds_3_tfprojectname ,
                                                 AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ,
                                                 AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration ,
                                                 AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ,
                                                 AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ,
                                                 AV41FromDate ,
                                                 AV42ToDate ,
                                                 A119WorkHourLogDate ,
                                                 A103ProjectName ,
                                                 A120WorkHourLogDuration ,
                                                 A123WorkHourLogDescription ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A106EmployeeId ,
                                                 AV34EmployeeId ,
                                                 A102ProjectId ,
                                                 AV43OneProjectId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.LONG
                                                 }
            });
            lV50Reportsworkhourlogdetailsds_3_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV50Reportsworkhourlogdetailsds_3_tfprojectname), 100, "%");
            lV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration), "%", "");
            lV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription), "%", "");
            /* Using cursor H004K2 */
            pr_default.execute(0, new Object[] {AV34EmployeeId, AV43OneProjectId, AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate, AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to, lV50Reportsworkhourlogdetailsds_3_tfprojectname, AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel, lV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration, AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, lV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription, AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, AV41FromDate, AV42ToDate, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A102ProjectId = H004K2_A102ProjectId[0];
               A107EmployeeFirstName = H004K2_A107EmployeeFirstName[0];
               A106EmployeeId = H004K2_A106EmployeeId[0];
               A123WorkHourLogDescription = H004K2_A123WorkHourLogDescription[0];
               A122WorkHourLogMinute = H004K2_A122WorkHourLogMinute[0];
               A121WorkHourLogHour = H004K2_A121WorkHourLogHour[0];
               A120WorkHourLogDuration = H004K2_A120WorkHourLogDuration[0];
               A103ProjectName = H004K2_A103ProjectName[0];
               A119WorkHourLogDate = H004K2_A119WorkHourLogDate[0];
               A118WorkHourLogId = H004K2_A118WorkHourLogId[0];
               A103ProjectName = H004K2_A103ProjectName[0];
               A107EmployeeFirstName = H004K2_A107EmployeeFirstName[0];
               /* Execute user event: Grid.Load */
               E164K2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 15;
            WB4K0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4K2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV47Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV47Pgmname, "")), context));
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
         AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate = AV16TFWorkHourLogDate;
         AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = AV17TFWorkHourLogDate_To;
         AV50Reportsworkhourlogdetailsds_3_tfprojectname = AV21TFProjectName;
         AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel = AV22TFProjectName_Sel;
         AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = AV23TFWorkHourLogDuration;
         AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = AV24TFWorkHourLogDuration_Sel;
         AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = AV25TFWorkHourLogDescription;
         AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = AV26TFWorkHourLogDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate ,
                                              AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ,
                                              AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel ,
                                              AV50Reportsworkhourlogdetailsds_3_tfprojectname ,
                                              AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ,
                                              AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration ,
                                              AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ,
                                              AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ,
                                              AV41FromDate ,
                                              AV42ToDate ,
                                              A119WorkHourLogDate ,
                                              A103ProjectName ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A106EmployeeId ,
                                              AV34EmployeeId ,
                                              A102ProjectId ,
                                              AV43OneProjectId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV50Reportsworkhourlogdetailsds_3_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV50Reportsworkhourlogdetailsds_3_tfprojectname), 100, "%");
         lV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration), "%", "");
         lV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription), "%", "");
         /* Using cursor H004K3 */
         pr_default.execute(1, new Object[] {AV34EmployeeId, AV43OneProjectId, AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate, AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to, lV50Reportsworkhourlogdetailsds_3_tfprojectname, AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel, lV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration, AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, lV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription, AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, AV41FromDate, AV42ToDate});
         GRID_nRecordCount = H004K3_AGRID_nRecordCount[0];
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
         AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate = AV16TFWorkHourLogDate;
         AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = AV17TFWorkHourLogDate_To;
         AV50Reportsworkhourlogdetailsds_3_tfprojectname = AV21TFProjectName;
         AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel = AV22TFProjectName_Sel;
         AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = AV23TFWorkHourLogDuration;
         AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = AV24TFWorkHourLogDuration_Sel;
         AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = AV25TFWorkHourLogDescription;
         AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = AV26TFWorkHourLogDescription_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34EmployeeId, AV41FromDate, AV42ToDate, AV43OneProjectId, AV47Pgmname, AV16TFWorkHourLogDate, AV17TFWorkHourLogDate_To, AV21TFProjectName, AV22TFProjectName_Sel, AV23TFWorkHourLogDuration, AV24TFWorkHourLogDuration_Sel, AV25TFWorkHourLogDescription, AV26TFWorkHourLogDescription_Sel, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate = AV16TFWorkHourLogDate;
         AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = AV17TFWorkHourLogDate_To;
         AV50Reportsworkhourlogdetailsds_3_tfprojectname = AV21TFProjectName;
         AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel = AV22TFProjectName_Sel;
         AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = AV23TFWorkHourLogDuration;
         AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = AV24TFWorkHourLogDuration_Sel;
         AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = AV25TFWorkHourLogDescription;
         AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = AV26TFWorkHourLogDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34EmployeeId, AV41FromDate, AV42ToDate, AV43OneProjectId, AV47Pgmname, AV16TFWorkHourLogDate, AV17TFWorkHourLogDate_To, AV21TFProjectName, AV22TFProjectName_Sel, AV23TFWorkHourLogDuration, AV24TFWorkHourLogDuration_Sel, AV25TFWorkHourLogDescription, AV26TFWorkHourLogDescription_Sel, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate = AV16TFWorkHourLogDate;
         AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = AV17TFWorkHourLogDate_To;
         AV50Reportsworkhourlogdetailsds_3_tfprojectname = AV21TFProjectName;
         AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel = AV22TFProjectName_Sel;
         AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = AV23TFWorkHourLogDuration;
         AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = AV24TFWorkHourLogDuration_Sel;
         AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = AV25TFWorkHourLogDescription;
         AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = AV26TFWorkHourLogDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34EmployeeId, AV41FromDate, AV42ToDate, AV43OneProjectId, AV47Pgmname, AV16TFWorkHourLogDate, AV17TFWorkHourLogDate_To, AV21TFProjectName, AV22TFProjectName_Sel, AV23TFWorkHourLogDuration, AV24TFWorkHourLogDuration_Sel, AV25TFWorkHourLogDescription, AV26TFWorkHourLogDescription_Sel, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate = AV16TFWorkHourLogDate;
         AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = AV17TFWorkHourLogDate_To;
         AV50Reportsworkhourlogdetailsds_3_tfprojectname = AV21TFProjectName;
         AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel = AV22TFProjectName_Sel;
         AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = AV23TFWorkHourLogDuration;
         AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = AV24TFWorkHourLogDuration_Sel;
         AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = AV25TFWorkHourLogDescription;
         AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = AV26TFWorkHourLogDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34EmployeeId, AV41FromDate, AV42ToDate, AV43OneProjectId, AV47Pgmname, AV16TFWorkHourLogDate, AV17TFWorkHourLogDate_To, AV21TFProjectName, AV22TFProjectName_Sel, AV23TFWorkHourLogDuration, AV24TFWorkHourLogDuration_Sel, AV25TFWorkHourLogDescription, AV26TFWorkHourLogDescription_Sel, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate = AV16TFWorkHourLogDate;
         AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = AV17TFWorkHourLogDate_To;
         AV50Reportsworkhourlogdetailsds_3_tfprojectname = AV21TFProjectName;
         AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel = AV22TFProjectName_Sel;
         AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = AV23TFWorkHourLogDuration;
         AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = AV24TFWorkHourLogDuration_Sel;
         AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = AV25TFWorkHourLogDescription;
         AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = AV26TFWorkHourLogDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34EmployeeId, AV41FromDate, AV42ToDate, AV43OneProjectId, AV47Pgmname, AV16TFWorkHourLogDate, AV17TFWorkHourLogDate_To, AV21TFProjectName, AV22TFProjectName_Sel, AV23TFWorkHourLogDuration, AV24TFWorkHourLogDuration_Sel, AV25TFWorkHourLogDescription, AV26TFWorkHourLogDescription_Sel, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV47Pgmname = "ReportsWorkHourLogDetails";
         edtWorkHourLogId_Enabled = 0;
         edtWorkHourLogDate_Enabled = 0;
         edtProjectName_Enabled = 0;
         edtWorkHourLogDuration_Enabled = 0;
         edtWorkHourLogHour_Enabled = 0;
         edtWorkHourLogMinute_Enabled = 0;
         edtWorkHourLogDescription_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtEmployeeFirstName_Enabled = 0;
         edtProjectId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E144K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV27DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), ".", ","), 18, MidpointRounding.ToEven));
            AV31GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ".", ","), 18, MidpointRounding.ToEven));
            AV32GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV33GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV18DDO_WorkHourLogDateAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_WORKHOURLOGDATEAUXDATE"), 0);
            AV19DDO_WorkHourLogDateAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_WORKHOURLOGDATEAUXDATETO"), 0);
            wcpOAV34EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV34EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOAV37EmployeeName = cgiGet( sPrefix+"wcpOAV37EmployeeName");
            wcpOAV41FromDate = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV41FromDate"), 0);
            wcpOAV42ToDate = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV42ToDate"), 0);
            wcpOAV43OneProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV43OneProjectId"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            /* Read variables values. */
            AV20DDO_WorkHourLogDateAuxDateText = cgiGet( edtavDdo_workhourlogdateauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV20DDO_WorkHourLogDateAuxDateText", AV20DDO_WorkHourLogDateAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
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
         E144K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E144K2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV44Hours = 0;
         AV45Minutes = 0;
         new logtofile(context ).execute(  StringUtil.Str( (decimal)(AV34EmployeeId), 10, 0)) ;
         new logtofile(context ).execute(  context.localUtil.DToC( AV41FromDate, 2, "/")) ;
         new logtofile(context ).execute(  context.localUtil.DToC( AV42ToDate, 2, "/")) ;
         new logtofile(context ).execute(  StringUtil.Str( (decimal)(AV43OneProjectId), 10, 0)) ;
         /* Optimized group. */
         /* Using cursor H004K4 */
         pr_default.execute(2, new Object[] {AV34EmployeeId, AV43OneProjectId, AV41FromDate, AV42ToDate});
         c121WorkHourLogHour = H004K4_A121WorkHourLogHour[0];
         c122WorkHourLogMinute = H004K4_A122WorkHourLogMinute[0];
         pr_default.close(2);
         AV44Hours = (short)(AV44Hours+c121WorkHourLogHour);
         AV45Minutes = (short)(AV45Minutes+c122WorkHourLogMinute);
         /* End optimized group. */
         GXt_char1 = "";
         new formattime(context ).execute(  AV44Hours*60+AV45Minutes, out  GXt_char1) ;
         lblTextblock1_Caption = StringUtil.Trim( AV37EmployeeName)+" | "+GXt_char1;
         AssignProp(sPrefix, false, lblTextblock1_Internalname, "Caption", lblTextblock1_Caption, true);
         lblTextblock1_Fontsize = 14;
         AssignProp(sPrefix, false, lblTextblock1_Internalname, "Fontsize", StringUtil.LTrimStr( (decimal)(lblTextblock1_Fontsize), 9, 0), true);
         lblTextblock1_Fontbold = 1;
         AssignProp(sPrefix, false, lblTextblock1_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock1_Fontbold), 1, 0), true);
         divTablemain_Width = 1200;
         AssignProp(sPrefix, false, divTablemain_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablemain_Width), 9, 0), true);
         this.executeUsercontrolMethod(sPrefix, false, "TFWORKHOURLOGDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_workhourlogdateauxdatetext_Internalname});
         subGrid_Rows = 5;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
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
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV27DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV27DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E154K2( )
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
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV31GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV31GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV31GridCurrentPage), 10, 0));
         AV32GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV32GridPageCount", StringUtil.LTrimStr( (decimal)(AV32GridPageCount), 10, 0));
         GXt_char1 = AV33GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV47Pgmname, out  GXt_char1) ;
         AV33GridAppliedFilters = GXt_char1;
         AssignAttri(sPrefix, false, "AV33GridAppliedFilters", AV33GridAppliedFilters);
         AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate = AV16TFWorkHourLogDate;
         AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = AV17TFWorkHourLogDate_To;
         AV50Reportsworkhourlogdetailsds_3_tfprojectname = AV21TFProjectName;
         AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel = AV22TFProjectName_Sel;
         AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = AV23TFWorkHourLogDuration;
         AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = AV24TFWorkHourLogDuration_Sel;
         AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = AV25TFWorkHourLogDescription;
         AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = AV26TFWorkHourLogDescription_Sel;
         /*  Sending Event outputs  */
      }

      protected void E114K2( )
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
            AV30PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV30PageToGo) ;
         }
      }

      protected void E124K2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E134K2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogDate") == 0 )
            {
               AV16TFWorkHourLogDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri(sPrefix, false, "AV16TFWorkHourLogDate", context.localUtil.Format(AV16TFWorkHourLogDate, "99/99/99"));
               AV17TFWorkHourLogDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri(sPrefix, false, "AV17TFWorkHourLogDate_To", context.localUtil.Format(AV17TFWorkHourLogDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProjectName") == 0 )
            {
               AV21TFProjectName = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV21TFProjectName", AV21TFProjectName);
               AV22TFProjectName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV22TFProjectName_Sel", AV22TFProjectName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogDuration") == 0 )
            {
               AV23TFWorkHourLogDuration = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFWorkHourLogDuration", AV23TFWorkHourLogDuration);
               AV24TFWorkHourLogDuration_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFWorkHourLogDuration_Sel", AV24TFWorkHourLogDuration_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WorkHourLogDescription") == 0 )
            {
               AV25TFWorkHourLogDescription = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV25TFWorkHourLogDescription", AV25TFWorkHourLogDescription);
               AV26TFWorkHourLogDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV26TFWorkHourLogDescription_Sel", AV26TFWorkHourLogDescription_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E164K2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, GridRow);
         }
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV15Session.Get(AV47Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV47Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV15Session.Get(AV47Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV16TFWorkHourLogDate = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV16TFWorkHourLogDate", context.localUtil.Format(AV16TFWorkHourLogDate, "99/99/99"));
               AV17TFWorkHourLogDate_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri(sPrefix, false, "AV17TFWorkHourLogDate_To", context.localUtil.Format(AV17TFWorkHourLogDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV21TFProjectName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV21TFProjectName", AV21TFProjectName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV22TFProjectName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV22TFProjectName_Sel", AV22TFProjectName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV23TFWorkHourLogDuration = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFWorkHourLogDuration", AV23TFWorkHourLogDuration);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV24TFWorkHourLogDuration_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFWorkHourLogDuration_Sel", AV24TFWorkHourLogDuration_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV25TFWorkHourLogDescription = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFWorkHourLogDescription", AV25TFWorkHourLogDescription);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV26TFWorkHourLogDescription_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFWorkHourLogDescription_Sel", AV26TFWorkHourLogDescription_Sel);
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         GXt_char1 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProjectName_Sel)),  AV22TFProjectName_Sel, out  GXt_char1) ;
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFWorkHourLogDuration_Sel)),  AV24TFWorkHourLogDuration_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFWorkHourLogDescription_Sel)),  AV26TFWorkHourLogDescription_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char1+"|"+GXt_char3+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProjectName)),  AV21TFProjectName, out  GXt_char4) ;
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFWorkHourLogDuration)),  AV23TFWorkHourLogDuration, out  GXt_char3) ;
         GXt_char1 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWorkHourLogDescription)),  AV25TFWorkHourLogDescription, out  GXt_char1) ;
         Ddo_grid_Filteredtext_set = ((DateTime.MinValue==AV16TFWorkHourLogDate) ? "" : context.localUtil.DToC( AV16TFWorkHourLogDate, 2, "/"))+"|"+GXt_char4+"|"+GXt_char3+"|"+GXt_char1;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((DateTime.MinValue==AV17TFWorkHourLogDate_To) ? "" : context.localUtil.DToC( AV17TFWorkHourLogDate_To, 2, "/"))+"|||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV15Session.Get(AV47Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFWORKHOURLOGDATE",  "Log Date",  !((DateTime.MinValue==AV16TFWorkHourLogDate)&&(DateTime.MinValue==AV17TFWorkHourLogDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV16TFWorkHourLogDate, 2, "/")),  ((DateTime.MinValue==AV16TFWorkHourLogDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV16TFWorkHourLogDate, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV17TFWorkHourLogDate_To, 2, "/")),  ((DateTime.MinValue==AV17TFWorkHourLogDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV17TFWorkHourLogDate_To, "99/99/99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPROJECTNAME",  "Name",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFProjectName)),  0,  AV21TFProjectName,  AV21TFProjectName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFProjectName_Sel)),  AV22TFProjectName_Sel,  AV22TFProjectName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFWORKHOURLOGDURATION",  "Log Duration",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFWorkHourLogDuration)),  0,  AV23TFWorkHourLogDuration,  AV23TFWorkHourLogDuration,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFWorkHourLogDuration_Sel)),  AV24TFWorkHourLogDuration_Sel,  AV24TFWorkHourLogDuration_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFWORKHOURLOGDESCRIPTION",  "Log Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFWorkHourLogDescription)),  0,  AV25TFWorkHourLogDescription,  AV25TFWorkHourLogDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFWorkHourLogDescription_Sel)),  AV26TFWorkHourLogDescription_Sel,  AV26TFWorkHourLogDescription_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV47Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV47Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "WorkHourLog";
         AV15Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV34EmployeeId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV34EmployeeId", StringUtil.LTrimStr( (decimal)(AV34EmployeeId), 10, 0));
         AV37EmployeeName = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV37EmployeeName", AV37EmployeeName);
         AV41FromDate = (DateTime)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV41FromDate", context.localUtil.Format(AV41FromDate, "99/99/99"));
         AV42ToDate = (DateTime)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV42ToDate", context.localUtil.Format(AV42ToDate, "99/99/99"));
         AV43OneProjectId = Convert.ToInt64(getParm(obj,4));
         AssignAttri(sPrefix, false, "AV43OneProjectId", StringUtil.LTrimStr( (decimal)(AV43OneProjectId), 10, 0));
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
         PA4K2( ) ;
         WS4K2( ) ;
         WE4K2( ) ;
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
         sCtrlAV34EmployeeId = (string)((string)getParm(obj,0));
         sCtrlAV37EmployeeName = (string)((string)getParm(obj,1));
         sCtrlAV41FromDate = (string)((string)getParm(obj,2));
         sCtrlAV42ToDate = (string)((string)getParm(obj,3));
         sCtrlAV43OneProjectId = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "reportsworkhourlogdetails", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4K2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV34EmployeeId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV34EmployeeId", StringUtil.LTrimStr( (decimal)(AV34EmployeeId), 10, 0));
            AV37EmployeeName = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV37EmployeeName", AV37EmployeeName);
            AV41FromDate = (DateTime)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV41FromDate", context.localUtil.Format(AV41FromDate, "99/99/99"));
            AV42ToDate = (DateTime)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV42ToDate", context.localUtil.Format(AV42ToDate, "99/99/99"));
            AV43OneProjectId = Convert.ToInt64(getParm(obj,6));
            AssignAttri(sPrefix, false, "AV43OneProjectId", StringUtil.LTrimStr( (decimal)(AV43OneProjectId), 10, 0));
         }
         wcpOAV34EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV34EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
         wcpOAV37EmployeeName = cgiGet( sPrefix+"wcpOAV37EmployeeName");
         wcpOAV41FromDate = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV41FromDate"), 0);
         wcpOAV42ToDate = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV42ToDate"), 0);
         wcpOAV43OneProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV43OneProjectId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV34EmployeeId != wcpOAV34EmployeeId ) || ( StringUtil.StrCmp(AV37EmployeeName, wcpOAV37EmployeeName) != 0 ) || ( DateTimeUtil.ResetTime ( AV41FromDate ) != DateTimeUtil.ResetTime ( wcpOAV41FromDate ) ) || ( DateTimeUtil.ResetTime ( AV42ToDate ) != DateTimeUtil.ResetTime ( wcpOAV42ToDate ) ) || ( AV43OneProjectId != wcpOAV43OneProjectId ) ) )
         {
            setjustcreated();
         }
         wcpOAV34EmployeeId = AV34EmployeeId;
         wcpOAV37EmployeeName = AV37EmployeeName;
         wcpOAV41FromDate = AV41FromDate;
         wcpOAV42ToDate = AV42ToDate;
         wcpOAV43OneProjectId = AV43OneProjectId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV34EmployeeId = cgiGet( sPrefix+"AV34EmployeeId_CTRL");
         if ( StringUtil.Len( sCtrlAV34EmployeeId) > 0 )
         {
            AV34EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV34EmployeeId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV34EmployeeId", StringUtil.LTrimStr( (decimal)(AV34EmployeeId), 10, 0));
         }
         else
         {
            AV34EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV34EmployeeId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
         sCtrlAV37EmployeeName = cgiGet( sPrefix+"AV37EmployeeName_CTRL");
         if ( StringUtil.Len( sCtrlAV37EmployeeName) > 0 )
         {
            AV37EmployeeName = cgiGet( sCtrlAV37EmployeeName);
            AssignAttri(sPrefix, false, "AV37EmployeeName", AV37EmployeeName);
         }
         else
         {
            AV37EmployeeName = cgiGet( sPrefix+"AV37EmployeeName_PARM");
         }
         sCtrlAV41FromDate = cgiGet( sPrefix+"AV41FromDate_CTRL");
         if ( StringUtil.Len( sCtrlAV41FromDate) > 0 )
         {
            AV41FromDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( sCtrlAV41FromDate), 0));
            AssignAttri(sPrefix, false, "AV41FromDate", context.localUtil.Format(AV41FromDate, "99/99/99"));
         }
         else
         {
            AV41FromDate = context.localUtil.CToD( cgiGet( sPrefix+"AV41FromDate_PARM"), 0);
         }
         sCtrlAV42ToDate = cgiGet( sPrefix+"AV42ToDate_CTRL");
         if ( StringUtil.Len( sCtrlAV42ToDate) > 0 )
         {
            AV42ToDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( sCtrlAV42ToDate), 0));
            AssignAttri(sPrefix, false, "AV42ToDate", context.localUtil.Format(AV42ToDate, "99/99/99"));
         }
         else
         {
            AV42ToDate = context.localUtil.CToD( cgiGet( sPrefix+"AV42ToDate_PARM"), 0);
         }
         sCtrlAV43OneProjectId = cgiGet( sPrefix+"AV43OneProjectId_CTRL");
         if ( StringUtil.Len( sCtrlAV43OneProjectId) > 0 )
         {
            AV43OneProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV43OneProjectId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV43OneProjectId", StringUtil.LTrimStr( (decimal)(AV43OneProjectId), 10, 0));
         }
         else
         {
            AV43OneProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV43OneProjectId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
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
         PA4K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4K2( ) ;
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
         WS4K2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV34EmployeeId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34EmployeeId), 10, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV34EmployeeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV34EmployeeId_CTRL", StringUtil.RTrim( sCtrlAV34EmployeeId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV37EmployeeName_PARM", StringUtil.RTrim( AV37EmployeeName));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV37EmployeeName)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV37EmployeeName_CTRL", StringUtil.RTrim( sCtrlAV37EmployeeName));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV41FromDate_PARM", context.localUtil.DToC( AV41FromDate, 0, "/"));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV41FromDate)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV41FromDate_CTRL", StringUtil.RTrim( sCtrlAV41FromDate));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV42ToDate_PARM", context.localUtil.DToC( AV42ToDate, 0, "/"));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV42ToDate)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV42ToDate_CTRL", StringUtil.RTrim( sCtrlAV42ToDate));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV43OneProjectId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43OneProjectId), 10, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV43OneProjectId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV43OneProjectId_CTRL", StringUtil.RTrim( sCtrlAV43OneProjectId));
         }
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
         WE4K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267492654", true, true);
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
         context.AddJavascriptSource("reportsworkhourlogdetails.js", "?20256267492656", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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

      protected void SubsflControlProps_152( )
      {
         edtWorkHourLogId_Internalname = sPrefix+"WORKHOURLOGID_"+sGXsfl_15_idx;
         edtWorkHourLogDate_Internalname = sPrefix+"WORKHOURLOGDATE_"+sGXsfl_15_idx;
         edtProjectName_Internalname = sPrefix+"PROJECTNAME_"+sGXsfl_15_idx;
         edtWorkHourLogDuration_Internalname = sPrefix+"WORKHOURLOGDURATION_"+sGXsfl_15_idx;
         edtWorkHourLogHour_Internalname = sPrefix+"WORKHOURLOGHOUR_"+sGXsfl_15_idx;
         edtWorkHourLogMinute_Internalname = sPrefix+"WORKHOURLOGMINUTE_"+sGXsfl_15_idx;
         edtWorkHourLogDescription_Internalname = sPrefix+"WORKHOURLOGDESCRIPTION_"+sGXsfl_15_idx;
         edtEmployeeId_Internalname = sPrefix+"EMPLOYEEID_"+sGXsfl_15_idx;
         edtEmployeeFirstName_Internalname = sPrefix+"EMPLOYEEFIRSTNAME_"+sGXsfl_15_idx;
         edtProjectId_Internalname = sPrefix+"PROJECTID_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtWorkHourLogId_Internalname = sPrefix+"WORKHOURLOGID_"+sGXsfl_15_fel_idx;
         edtWorkHourLogDate_Internalname = sPrefix+"WORKHOURLOGDATE_"+sGXsfl_15_fel_idx;
         edtProjectName_Internalname = sPrefix+"PROJECTNAME_"+sGXsfl_15_fel_idx;
         edtWorkHourLogDuration_Internalname = sPrefix+"WORKHOURLOGDURATION_"+sGXsfl_15_fel_idx;
         edtWorkHourLogHour_Internalname = sPrefix+"WORKHOURLOGHOUR_"+sGXsfl_15_fel_idx;
         edtWorkHourLogMinute_Internalname = sPrefix+"WORKHOURLOGMINUTE_"+sGXsfl_15_fel_idx;
         edtWorkHourLogDescription_Internalname = sPrefix+"WORKHOURLOGDESCRIPTION_"+sGXsfl_15_fel_idx;
         edtEmployeeId_Internalname = sPrefix+"EMPLOYEEID_"+sGXsfl_15_fel_idx;
         edtEmployeeFirstName_Internalname = sPrefix+"EMPLOYEEFIRSTNAME_"+sGXsfl_15_fel_idx;
         edtProjectId_Internalname = sPrefix+"PROJECTID_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB4K0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_15_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_15_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)100,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDate_Internalname,context.localUtil.Format(A119WorkHourLogDate, "99/99/99"),context.localUtil.Format( A119WorkHourLogDate, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)70,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProjectName_Internalname,StringUtil.RTrim( A103ProjectName),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProjectName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)100,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDuration_Internalname,(string)A120WorkHourLogDuration,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDuration_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)50,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogHour_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121WorkHourLogHour), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogHour_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogMinute_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A122WorkHourLogMinute), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogMinute_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWorkHourLogDescription_Internalname,(string)A123WorkHourLogDescription,(string)A123WorkHourLogDescription,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWorkHourLogDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)15,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeFirstName_Internalname,StringUtil.RTrim( A107EmployeeFirstName),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeFirstName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProjectId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProjectId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes4K2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl15( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"15\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(100), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Log Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(70), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Log Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(100), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(50), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Log Duration") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Log Hour") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Log Minute") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Log Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "First Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A119WorkHourLogDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A103ProjectName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A120WorkHourLogDuration));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A123WorkHourLogDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EmployeeFirstName)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", ""))));
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
         lblTextblock1_Internalname = sPrefix+"TEXTBLOCK1";
         edtWorkHourLogId_Internalname = sPrefix+"WORKHOURLOGID";
         edtWorkHourLogDate_Internalname = sPrefix+"WORKHOURLOGDATE";
         edtProjectName_Internalname = sPrefix+"PROJECTNAME";
         edtWorkHourLogDuration_Internalname = sPrefix+"WORKHOURLOGDURATION";
         edtWorkHourLogHour_Internalname = sPrefix+"WORKHOURLOGHOUR";
         edtWorkHourLogMinute_Internalname = sPrefix+"WORKHOURLOGMINUTE";
         edtWorkHourLogDescription_Internalname = sPrefix+"WORKHOURLOGDESCRIPTION";
         edtEmployeeId_Internalname = sPrefix+"EMPLOYEEID";
         edtEmployeeFirstName_Internalname = sPrefix+"EMPLOYEEFIRSTNAME";
         edtProjectId_Internalname = sPrefix+"PROJECTID";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_workhourlogdateauxdatetext_Internalname = sPrefix+"vDDO_WORKHOURLOGDATEAUXDATETEXT";
         Tfworkhourlogdate_rangepicker_Internalname = sPrefix+"TFWORKHOURLOGDATE_RANGEPICKER";
         divDdo_workhourlogdateauxdates_Internalname = sPrefix+"DDO_WORKHOURLOGDATEAUXDATES";
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
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtProjectId_Jsonclick = "";
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeId_Jsonclick = "";
         edtWorkHourLogDescription_Jsonclick = "";
         edtWorkHourLogMinute_Jsonclick = "";
         edtWorkHourLogHour_Jsonclick = "";
         edtWorkHourLogDuration_Jsonclick = "";
         edtProjectName_Jsonclick = "";
         edtWorkHourLogDate_Jsonclick = "";
         edtWorkHourLogId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtProjectId_Enabled = 0;
         edtEmployeeFirstName_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtWorkHourLogDescription_Enabled = 0;
         edtWorkHourLogMinute_Enabled = 0;
         edtWorkHourLogHour_Enabled = 0;
         edtWorkHourLogDuration_Enabled = 0;
         edtProjectName_Enabled = 0;
         edtWorkHourLogDate_Enabled = 0;
         edtWorkHourLogId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_workhourlogdateauxdatetext_Jsonclick = "";
         lblTextblock1_Fontbold = 0;
         lblTextblock1_Fontsize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         lblTextblock1_Caption = "";
         divTablemain_Width = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "ReportsWorkHourLogDetailsGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T";
         Ddo_grid_Filterisrange = "P|||";
         Ddo_grid_Filtertype = "Date|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "1:WorkHourLogDate|2:ProjectName|3:WorkHourLogDuration|6:WorkHourLogDescription";
         Ddo_grid_Gridinternalname = "";
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
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV34EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV41FromDate","fld":"vFROMDATE"},{"av":"AV42ToDate","fld":"vTODATE"},{"av":"AV43OneProjectId","fld":"vONEPROJECTID","pic":"ZZZZZZZZZ9"},{"av":"sPrefix"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV16TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV17TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV21TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV22TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV23TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV24TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV25TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV26TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV31GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV32GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV33GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E114K2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV34EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV41FromDate","fld":"vFROMDATE"},{"av":"AV42ToDate","fld":"vTODATE"},{"av":"AV43OneProjectId","fld":"vONEPROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV16TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV17TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV21TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV22TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV23TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV24TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV25TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV26TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"sPrefix"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E124K2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV34EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV41FromDate","fld":"vFROMDATE"},{"av":"AV42ToDate","fld":"vTODATE"},{"av":"AV43OneProjectId","fld":"vONEPROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV16TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV17TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV21TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV22TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV23TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV24TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV25TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV26TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"sPrefix"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E134K2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV34EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"AV41FromDate","fld":"vFROMDATE"},{"av":"AV42ToDate","fld":"vTODATE"},{"av":"AV43OneProjectId","fld":"vONEPROJECTID","pic":"ZZZZZZZZZ9"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV16TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV17TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV21TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV22TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV23TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV24TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV25TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV26TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"sPrefix"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV16TFWorkHourLogDate","fld":"vTFWORKHOURLOGDATE"},{"av":"AV17TFWorkHourLogDate_To","fld":"vTFWORKHOURLOGDATE_TO"},{"av":"AV21TFProjectName","fld":"vTFPROJECTNAME"},{"av":"AV22TFProjectName_Sel","fld":"vTFPROJECTNAME_SEL"},{"av":"AV23TFWorkHourLogDuration","fld":"vTFWORKHOURLOGDURATION"},{"av":"AV24TFWorkHourLogDuration_Sel","fld":"vTFWORKHOURLOGDURATION_SEL"},{"av":"AV25TFWorkHourLogDescription","fld":"vTFWORKHOURLOGDESCRIPTION"},{"av":"AV26TFWorkHourLogDescription_Sel","fld":"vTFWORKHOURLOGDESCRIPTION_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E164K2","iparms":[]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[]}""");
         setEventMetadata("VALID_PROJECTID","""{"handler":"Valid_Projectid","iparms":[]}""");
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
         wcpOAV37EmployeeName = "";
         wcpOAV41FromDate = DateTime.MinValue;
         wcpOAV42ToDate = DateTime.MinValue;
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV47Pgmname = "";
         AV16TFWorkHourLogDate = DateTime.MinValue;
         AV17TFWorkHourLogDate_To = DateTime.MinValue;
         AV21TFProjectName = "";
         AV22TFProjectName_Sel = "";
         AV23TFWorkHourLogDuration = "";
         AV24TFWorkHourLogDuration_Sel = "";
         AV25TFWorkHourLogDescription = "";
         AV26TFWorkHourLogDescription_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV33GridAppliedFilters = "";
         AV27DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18DDO_WorkHourLogDateAuxDate = DateTime.MinValue;
         AV19DDO_WorkHourLogDateAuxDateTo = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         lblTextblock1_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         TempTags = "";
         AV20DDO_WorkHourLogDateAuxDateText = "";
         ucTfworkhourlogdate_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A119WorkHourLogDate = DateTime.MinValue;
         A103ProjectName = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A107EmployeeFirstName = "";
         lV50Reportsworkhourlogdetailsds_3_tfprojectname = "";
         lV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = "";
         lV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = "";
         AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate = DateTime.MinValue;
         AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to = DateTime.MinValue;
         AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel = "";
         AV50Reportsworkhourlogdetailsds_3_tfprojectname = "";
         AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel = "";
         AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration = "";
         AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel = "";
         AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription = "";
         H004K2_A102ProjectId = new long[1] ;
         H004K2_A107EmployeeFirstName = new string[] {""} ;
         H004K2_A106EmployeeId = new long[1] ;
         H004K2_A123WorkHourLogDescription = new string[] {""} ;
         H004K2_A122WorkHourLogMinute = new short[1] ;
         H004K2_A121WorkHourLogHour = new short[1] ;
         H004K2_A120WorkHourLogDuration = new string[] {""} ;
         H004K2_A103ProjectName = new string[] {""} ;
         H004K2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         H004K2_A118WorkHourLogId = new long[1] ;
         H004K3_AGRID_nRecordCount = new long[1] ;
         H004K4_A121WorkHourLogHour = new short[1] ;
         H004K4_A122WorkHourLogMinute = new short[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV15Session = context.GetSession();
         AV11GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV12GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char1 = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV34EmployeeId = "";
         sCtrlAV37EmployeeName = "";
         sCtrlAV41FromDate = "";
         sCtrlAV42ToDate = "";
         sCtrlAV43OneProjectId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportsworkhourlogdetails__default(),
            new Object[][] {
                new Object[] {
               H004K2_A102ProjectId, H004K2_A107EmployeeFirstName, H004K2_A106EmployeeId, H004K2_A123WorkHourLogDescription, H004K2_A122WorkHourLogMinute, H004K2_A121WorkHourLogHour, H004K2_A120WorkHourLogDuration, H004K2_A103ProjectName, H004K2_A119WorkHourLogDate, H004K2_A118WorkHourLogId
               }
               , new Object[] {
               H004K3_AGRID_nRecordCount
               }
               , new Object[] {
               H004K4_A121WorkHourLogHour, H004K4_A122WorkHourLogMinute
               }
            }
         );
         AV47Pgmname = "ReportsWorkHourLogDetails";
         /* GeneXus formulas. */
         AV47Pgmname = "ReportsWorkHourLogDetails";
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13OrderedBy ;
      private short wbEnd ;
      private short wbStart ;
      private short lblTextblock1_Fontbold ;
      private short nDraw ;
      private short nDoneStart ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV44Hours ;
      private short AV45Minutes ;
      private short c121WorkHourLogHour ;
      private short c122WorkHourLogMinute ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int divTablemain_Width ;
      private int lblTextblock1_Fontsize ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWorkHourLogId_Enabled ;
      private int edtWorkHourLogDate_Enabled ;
      private int edtProjectName_Enabled ;
      private int edtWorkHourLogDuration_Enabled ;
      private int edtWorkHourLogHour_Enabled ;
      private int edtWorkHourLogMinute_Enabled ;
      private int edtWorkHourLogDescription_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeFirstName_Enabled ;
      private int edtProjectId_Enabled ;
      private int AV30PageToGo ;
      private int AV56GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV34EmployeeId ;
      private long AV43OneProjectId ;
      private long wcpOAV34EmployeeId ;
      private long wcpOAV43OneProjectId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV31GridCurrentPage ;
      private long AV32GridPageCount ;
      private long A118WorkHourLogId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string AV37EmployeeName ;
      private string wcpOAV37EmployeeName ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_15_idx="0001" ;
      private string AV47Pgmname ;
      private string AV21TFProjectName ;
      private string AV22TFProjectName_Sel ;
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
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Caption ;
      private string lblTextblock1_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_workhourlogdateauxdates_Internalname ;
      private string TempTags ;
      private string edtavDdo_workhourlogdateauxdatetext_Internalname ;
      private string edtavDdo_workhourlogdateauxdatetext_Jsonclick ;
      private string Tfworkhourlogdate_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtWorkHourLogId_Internalname ;
      private string edtWorkHourLogDate_Internalname ;
      private string A103ProjectName ;
      private string edtProjectName_Internalname ;
      private string edtWorkHourLogDuration_Internalname ;
      private string edtWorkHourLogHour_Internalname ;
      private string edtWorkHourLogMinute_Internalname ;
      private string edtWorkHourLogDescription_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string A107EmployeeFirstName ;
      private string edtEmployeeFirstName_Internalname ;
      private string edtProjectId_Internalname ;
      private string lV50Reportsworkhourlogdetailsds_3_tfprojectname ;
      private string AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel ;
      private string AV50Reportsworkhourlogdetailsds_3_tfprojectname ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char1 ;
      private string sCtrlAV34EmployeeId ;
      private string sCtrlAV37EmployeeName ;
      private string sCtrlAV41FromDate ;
      private string sCtrlAV42ToDate ;
      private string sCtrlAV43OneProjectId ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtWorkHourLogId_Jsonclick ;
      private string edtWorkHourLogDate_Jsonclick ;
      private string edtProjectName_Jsonclick ;
      private string edtWorkHourLogDuration_Jsonclick ;
      private string edtWorkHourLogHour_Jsonclick ;
      private string edtWorkHourLogMinute_Jsonclick ;
      private string edtWorkHourLogDescription_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeFirstName_Jsonclick ;
      private string edtProjectId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV41FromDate ;
      private DateTime AV42ToDate ;
      private DateTime wcpOAV41FromDate ;
      private DateTime wcpOAV42ToDate ;
      private DateTime AV16TFWorkHourLogDate ;
      private DateTime AV17TFWorkHourLogDate_To ;
      private DateTime AV18DDO_WorkHourLogDateAuxDate ;
      private DateTime AV19DDO_WorkHourLogDateAuxDateTo ;
      private DateTime A119WorkHourLogDate ;
      private DateTime AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate ;
      private DateTime AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string A123WorkHourLogDescription ;
      private string AV23TFWorkHourLogDuration ;
      private string AV24TFWorkHourLogDuration_Sel ;
      private string AV25TFWorkHourLogDescription ;
      private string AV26TFWorkHourLogDescription_Sel ;
      private string AV33GridAppliedFilters ;
      private string AV20DDO_WorkHourLogDateAuxDateText ;
      private string A120WorkHourLogDuration ;
      private string lV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration ;
      private string lV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ;
      private string AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ;
      private string AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration ;
      private string AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ;
      private string AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ;
      private IGxSession AV15Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfworkhourlogdate_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP4_OneProjectId ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV27DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private long[] H004K2_A102ProjectId ;
      private string[] H004K2_A107EmployeeFirstName ;
      private long[] H004K2_A106EmployeeId ;
      private string[] H004K2_A123WorkHourLogDescription ;
      private short[] H004K2_A122WorkHourLogMinute ;
      private short[] H004K2_A121WorkHourLogHour ;
      private string[] H004K2_A120WorkHourLogDuration ;
      private string[] H004K2_A103ProjectName ;
      private DateTime[] H004K2_A119WorkHourLogDate ;
      private long[] H004K2_A118WorkHourLogId ;
      private long[] H004K3_AGRID_nRecordCount ;
      private short[] H004K4_A121WorkHourLogHour ;
      private short[] H004K4_A122WorkHourLogMinute ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reportsworkhourlogdetails__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004K2( IGxContext context ,
                                             DateTime AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate ,
                                             DateTime AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ,
                                             string AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel ,
                                             string AV50Reportsworkhourlogdetailsds_3_tfprojectname ,
                                             string AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ,
                                             string AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration ,
                                             string AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ,
                                             string AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ,
                                             DateTime AV41FromDate ,
                                             DateTime AV42ToDate ,
                                             DateTime A119WorkHourLogDate ,
                                             string A103ProjectName ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             long A106EmployeeId ,
                                             long AV34EmployeeId ,
                                             long A102ProjectId ,
                                             long AV43OneProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.ProjectId, T3.EmployeeFirstName, T1.EmployeeId, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDuration, T2.ProjectName, T1.WorkHourLogDate, T1.WorkHourLogId";
         sFromString = " FROM ((WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV34EmployeeId)");
         AddWhere(sWhereString, "(T1.ProjectId = :AV43OneProjectId)");
         if ( ! (DateTime.MinValue==AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Reportsworkhourlogdetailsds_3_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV50Reportsworkhourlogdetailsds_3_tfprojectname)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (DateTime.MinValue==AV41FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV41FromDate)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV42ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV42ToDate)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDate, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDate DESC, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ProjectName, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ProjectName DESC, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDuration, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDuration DESC, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDescription, T1.WorkHourLogId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.WorkHourLogDescription DESC, T1.WorkHourLogId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.WorkHourLogId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H004K3( IGxContext context ,
                                             DateTime AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate ,
                                             DateTime AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to ,
                                             string AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel ,
                                             string AV50Reportsworkhourlogdetailsds_3_tfprojectname ,
                                             string AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel ,
                                             string AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration ,
                                             string AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel ,
                                             string AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription ,
                                             DateTime AV41FromDate ,
                                             DateTime AV42ToDate ,
                                             DateTime A119WorkHourLogDate ,
                                             string A103ProjectName ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             long A106EmployeeId ,
                                             long AV34EmployeeId ,
                                             long A102ProjectId ,
                                             long AV43OneProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((WorkHourLog T1 INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId) INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV34EmployeeId)");
         AddWhere(sWhereString, "(T1.ProjectId = :AV43OneProjectId)");
         if ( ! (DateTime.MinValue==AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Reportsworkhourlogdetailsds_3_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName like :lV50Reportsworkhourlogdetailsds_3_tfprojectname)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( ! (DateTime.MinValue==AV41FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV41FromDate)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV42ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV42ToDate)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H004K2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] );
               case 1 :
                     return conditional_H004K3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] );
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
          Object[] prmH004K4;
          prmH004K4 = new Object[] {
          new ParDef("AV34EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV43OneProjectId",GXType.Int64,10,0) ,
          new ParDef("AV41FromDate",GXType.Date,8,0) ,
          new ParDef("AV42ToDate",GXType.Date,8,0)
          };
          Object[] prmH004K2;
          prmH004K2 = new Object[] {
          new ParDef("AV34EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV43OneProjectId",GXType.Int64,10,0) ,
          new ParDef("AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV50Reportsworkhourlogdetailsds_3_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("lV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV41FromDate",GXType.Date,8,0) ,
          new ParDef("AV42ToDate",GXType.Date,8,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004K3;
          prmH004K3 = new Object[] {
          new ParDef("AV34EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV43OneProjectId",GXType.Int64,10,0) ,
          new ParDef("AV48Reportsworkhourlogdetailsds_1_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV49Reportsworkhourlogdetailsds_2_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV50Reportsworkhourlogdetailsds_3_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV51Reportsworkhourlogdetailsds_4_tfprojectname_sel",GXType.Char,100,0) ,
          new ParDef("lV52Reportsworkhourlogdetailsds_5_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV53Reportsworkhourlogdetailsds_6_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV54Reportsworkhourlogdetailsds_7_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV55Reportsworkhourlogdetailsds_8_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV41FromDate",GXType.Date,8,0) ,
          new ParDef("AV42ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004K4", "SELECT SUM(WorkHourLogHour), SUM(WorkHourLogMinute) FROM WorkHourLog WHERE (EmployeeId = :AV34EmployeeId and ProjectId = :AV43OneProjectId) AND (WorkHourLogDate >= :AV41FromDate) AND (WorkHourLogDate <= :AV42ToDate) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K4,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
