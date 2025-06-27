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
   public class projectdetails : GXWebComponent
   {
      public projectdetails( )
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

      public projectdetails( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_OneProjectId ,
                           ref DateTime aP1_FromDate ,
                           ref DateTime aP2_ToDate )
      {
         this.AV22OneProjectId = aP0_OneProjectId;
         this.AV15FromDate = aP1_FromDate;
         this.AV16ToDate = aP2_ToDate;
         ExecuteImpl();
         aP1_FromDate=this.AV15FromDate;
         aP2_ToDate=this.AV16ToDate;
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
               gxfirstwebparm = GetFirstPar( "OneProjectId");
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
                  AV22OneProjectId = (short)(Math.Round(NumberUtil.Val( GetPar( "OneProjectId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV22OneProjectId", StringUtil.LTrimStr( (decimal)(AV22OneProjectId), 4, 0));
                  AV15FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
                  AssignAttri(sPrefix, false, "AV15FromDate", context.localUtil.Format(AV15FromDate, "99/99/99"));
                  AV16ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
                  AssignAttri(sPrefix, false, "AV16ToDate", context.localUtil.Format(AV16ToDate, "99/99/99"));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV22OneProjectId,(DateTime)AV15FromDate,(DateTime)AV16ToDate});
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
                  gxfirstwebparm = GetFirstPar( "OneProjectId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "OneProjectId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Freestylegrid1") == 0 )
               {
                  gxnrFreestylegrid1_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Freestylegrid1") == 0 )
               {
                  gxgrFreestylegrid1_refresh_invoke( ) ;
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

      protected void gxnrFreestylegrid1_newrow_invoke( )
      {
         nRC_GXsfl_23 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_23"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_23_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_23_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_23_idx = GetPar( "sGXsfl_23_idx");
         sPrefix = GetPar( "sPrefix");
         edtEmployeeName_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_23_Refreshing);
         edtEmployeeId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), !bGXsfl_23_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFreestylegrid1_newrow( ) ;
         /* End function gxnrFreestylegrid1_newrow_invoke */
      }

      protected void gxgrFreestylegrid1_refresh_invoke( )
      {
         subFreestylegrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subFreestylegrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV22OneProjectId = (short)(Math.Round(NumberUtil.Val( GetPar( "OneProjectId"), "."), 18, MidpointRounding.ToEven));
         AV15FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV16ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         edtEmployeeName_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_23_Refreshing);
         edtEmployeeId_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), !bGXsfl_23_Refreshing);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22OneProjectId, AV15FromDate, AV16ToDate, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFreestylegrid1_refresh_invoke */
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
            return GAMSecurityLevel.SecurityLow ;
         }

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
            PA4L2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS4L2( ) ;
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
            context.SendWebValue( "Project Details") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("projectdetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV22OneProjectId,4,0)),UrlEncode(DateTimeUtil.FormatDateParm(AV15FromDate)),UrlEncode(DateTimeUtil.FormatDateParm(AV16ToDate))}, new string[] {"OneProjectId","FromDate","ToDate"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_23", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_23), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFREESTYLEGRID1PAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10FreeStyleGrid1PageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFREESTYLEGRID1APPLIEDFILTERS", AV11FreeStyleGrid1AppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV22OneProjectId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV22OneProjectId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV15FromDate", context.localUtil.DToC( wcpOAV15FromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16ToDate", context.localUtil.DToC( wcpOAV16ToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFROMDATE", context.localUtil.DToC( AV15FromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODATE", context.localUtil.DToC( AV16ToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vONEPROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22OneProjectId), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPROJECTID", AV14ProjectId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPROJECTID", AV14ProjectId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vEMPLOYEEID", AV13EmployeeId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vEMPLOYEEID", AV13EmployeeId);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDATERANGE", context.localUtil.DToC( AV21DateRange, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDATERANGE_TO", context.localUtil.DToC( AV26DateRange_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOMPANYLOCATIONID", AV12CompanyLocationId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOMPANYLOCATIONID", AV12CompanyLocationId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vINPROJECTID", AV32InProjectId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vINPROJECTID", AV32InProjectId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vINEMPLOYEEID", AV31InEmployeeId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vINEMPLOYEEID", AV31InEmployeeId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vINCOMPANYLOCATIONID", AV30InCompanyLocationId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vINCOMPANYLOCATIONID", AV30InCompanyLocationId);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Class", StringUtil.RTrim( Freestylegrid1paginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Freestylegrid1paginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Freestylegrid1paginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Shownext", StringUtil.BoolToStr( Freestylegrid1paginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Showlast", StringUtil.BoolToStr( Freestylegrid1paginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Freestylegrid1paginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Freestylegrid1paginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Freestylegrid1paginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Freestylegrid1paginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Freestylegrid1paginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Freestylegrid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Freestylegrid1paginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Previous", StringUtil.RTrim( Freestylegrid1paginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Next", StringUtil.RTrim( Freestylegrid1paginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Caption", StringUtil.RTrim( Freestylegrid1paginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Freestylegrid1paginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Freestylegrid1paginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"INNEWWINDOW1_Name", StringUtil.RTrim( Innewwindow1_Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Freestylegrid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Freestylegrid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"EMPLOYEENAME_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeName_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"EMPLOYEEID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeId_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Freestylegrid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Freestylegrid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm4L2( )
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
            if ( ! ( WebComp_Wcreportsworkhourlogdetails == null ) )
            {
               WebComp_Wcreportsworkhourlogdetails.componentjscripts();
            }
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
         return "ProjectDetails" ;
      }

      public override string GetPgmdesc( )
      {
         return "Project Details" ;
      }

      protected void WB4L0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "projectdetails.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
               context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            ClassString = "btn-group";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportexcel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(23), 2, 0)+","+"null"+");", "Export", bttBtnexportexcel_Jsonclick, 5, "Export", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORTEXCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProjectDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFreestylegrid1tablewithpaging_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            StartGridControl23( ) ;
         }
         if ( wbEnd == 23 )
         {
            wbEnd = 0;
            nRC_GXsfl_23 = (int)(nGXsfl_23_idx-1);
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucFreestylegrid1paginationbar.SetProperty("Class", Freestylegrid1paginationbar_Class);
            ucFreestylegrid1paginationbar.SetProperty("ShowFirst", Freestylegrid1paginationbar_Showfirst);
            ucFreestylegrid1paginationbar.SetProperty("ShowPrevious", Freestylegrid1paginationbar_Showprevious);
            ucFreestylegrid1paginationbar.SetProperty("ShowNext", Freestylegrid1paginationbar_Shownext);
            ucFreestylegrid1paginationbar.SetProperty("ShowLast", Freestylegrid1paginationbar_Showlast);
            ucFreestylegrid1paginationbar.SetProperty("PagesToShow", Freestylegrid1paginationbar_Pagestoshow);
            ucFreestylegrid1paginationbar.SetProperty("PagingButtonsPosition", Freestylegrid1paginationbar_Pagingbuttonsposition);
            ucFreestylegrid1paginationbar.SetProperty("PagingCaptionPosition", Freestylegrid1paginationbar_Pagingcaptionposition);
            ucFreestylegrid1paginationbar.SetProperty("EmptyGridClass", Freestylegrid1paginationbar_Emptygridclass);
            ucFreestylegrid1paginationbar.SetProperty("RowsPerPageSelector", Freestylegrid1paginationbar_Rowsperpageselector);
            ucFreestylegrid1paginationbar.SetProperty("RowsPerPageOptions", Freestylegrid1paginationbar_Rowsperpageoptions);
            ucFreestylegrid1paginationbar.SetProperty("Previous", Freestylegrid1paginationbar_Previous);
            ucFreestylegrid1paginationbar.SetProperty("Next", Freestylegrid1paginationbar_Next);
            ucFreestylegrid1paginationbar.SetProperty("Caption", Freestylegrid1paginationbar_Caption);
            ucFreestylegrid1paginationbar.SetProperty("EmptyGridCaption", Freestylegrid1paginationbar_Emptygridcaption);
            ucFreestylegrid1paginationbar.SetProperty("RowsPerPageCaption", Freestylegrid1paginationbar_Rowsperpagecaption);
            ucFreestylegrid1paginationbar.SetProperty("CurrentPage", AV9FreeStyleGrid1CurrentPage);
            ucFreestylegrid1paginationbar.SetProperty("PageCount", AV10FreeStyleGrid1PageCount);
            ucFreestylegrid1paginationbar.SetProperty("AppliedFilters", AV11FreeStyleGrid1AppliedFilters);
            ucFreestylegrid1paginationbar.Render(context, "dvelop.dvpaginationbar", Freestylegrid1paginationbar_Internalname, sPrefix+"FREESTYLEGRID1PAGINATIONBARContainer");
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
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, sPrefix+"INNEWWINDOW1Container");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_23_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFreestylegrid1currentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9FreeStyleGrid1CurrentPage), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9FreeStyleGrid1CurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFreestylegrid1currentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavFreestylegrid1currentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProjectDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 23 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Freestylegrid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Freestylegrid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Freestylegrid1", Freestylegrid1Container, subFreestylegrid1_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData", Freestylegrid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Freestylegrid1ContainerData"+"V", Freestylegrid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Freestylegrid1ContainerData"+"V"+"\" value='"+Freestylegrid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4L2( )
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
            Form.Meta.addItem("description", "Project Details", 0) ;
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
               STRUP4L0( ) ;
            }
         }
      }

      protected void WS4L2( )
      {
         START4L2( ) ;
         EVT4L2( ) ;
      }

      protected void EVT4L2( )
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
                                 STRUP4L0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1PAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid1paginationbar.Changepage */
                                    E114L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1PAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Freestylegrid1paginationbar.Changerowsperpage */
                                    E124L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTEXCEL'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExportExcel' */
                                    E134L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFreestylegrid1currentpage_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FREESTYLEGRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "FREESTYLEGRID1.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
                              }
                              nGXsfl_23_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
                              SubsflControlProps_232( ) ;
                              A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
                              A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
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
                                          GX_FocusControl = edtavFreestylegrid1currentpage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E144L2 ();
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
                                          GX_FocusControl = edtavFreestylegrid1currentpage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E154L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFreestylegrid1currentpage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Freestylegrid1.Load */
                                          E164L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FREESTYLEGRID1.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFreestylegrid1currentpage_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Freestylegrid1.Refresh */
                                          E174L2 ();
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
                                       STRUP4L0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFreestylegrid1currentpage_Internalname;
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 27 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0027" + sEvtType;
                           OldWcreportsworkhourlogdetails = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldWcreportsworkhourlogdetails) == 0 ) || ( StringUtil.StrCmp(OldWcreportsworkhourlogdetails, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWcreportsworkhourlogdetails, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWcreportsworkhourlogdetails";
                              WebComp_GX_Process_Component = OldWcreportsworkhourlogdetails;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0027", sEvtType, sEvt);
                           }
                           nGXsfl_23_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Wcreportsworkhourlogdetails";
                           WebComp_GX_Process_Component = OldWcreportsworkhourlogdetails;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4L2( ) ;
            }
         }
      }

      protected void PA4L2( )
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
               GX_FocusControl = edtavFreestylegrid1currentpage_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFreestylegrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_232( ) ;
         while ( nGXsfl_23_idx <= nRC_GXsfl_23 )
         {
            sendrow_232( ) ;
            nGXsfl_23_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_23_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_23_idx+1);
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Freestylegrid1Container)) ;
         /* End function gxnrFreestylegrid1_newrow */
      }

      protected void gxgrFreestylegrid1_refresh( int subFreestylegrid1_Rows ,
                                                 short AV22OneProjectId ,
                                                 DateTime AV15FromDate ,
                                                 DateTime AV16ToDate ,
                                                 string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FREESTYLEGRID1_nCurrentRecord = 0;
         RF4L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFreestylegrid1_refresh */
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
         /* Execute user event: Refresh */
         E154L2 ();
         RF4L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Freestylegrid1Container.ClearRows();
         }
         wbStart = 23;
         /* Execute user event: Refresh */
         E154L2 ();
         /* Execute user event: Freestylegrid1.Refresh */
         E174L2 ();
         nGXsfl_23_idx = 1;
         sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
         SubsflControlProps_232( ) ;
         bGXsfl_23_Refreshing = true;
         Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         Freestylegrid1Container.AddObjectProperty("CmpContext", sPrefix);
         Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
         Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
         Freestylegrid1Container.PageSize = subFreestylegrid1_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcreportsworkhourlogdetails_Component) != 0 )
               {
                  WebComp_Wcreportsworkhourlogdetails.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_232( ) ;
            GXPagingFrom2 = (int)(((subFreestylegrid1_Rows==0) ? 0 : FREESTYLEGRID1_nFirstRecordOnPage));
            GXPagingTo2 = ((subFreestylegrid1_Rows==0) ? 10000 : subFreestylegrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A157CompanyLocationId ,
                                                 AV12CompanyLocationId ,
                                                 A106EmployeeId ,
                                                 AV13EmployeeId ,
                                                 AV12CompanyLocationId.Count ,
                                                 AV13EmployeeId.Count ,
                                                 AV15FromDate ,
                                                 AV16ToDate ,
                                                 A119WorkHourLogDate ,
                                                 A102ProjectId ,
                                                 AV22OneProjectId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H004L2 */
            pr_default.execute(0, new Object[] {AV22OneProjectId, AV15FromDate, AV16ToDate, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_23_idx = 1;
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subFreestylegrid1_Rows == 0 ) || ( FREESTYLEGRID1_nCurrentRecord < subFreestylegrid1_fnc_Recordsperpage( ) ) ) ) )
            {
               A100CompanyId = H004L2_A100CompanyId[0];
               A102ProjectId = H004L2_A102ProjectId[0];
               A119WorkHourLogDate = H004L2_A119WorkHourLogDate[0];
               A157CompanyLocationId = H004L2_A157CompanyLocationId[0];
               A106EmployeeId = H004L2_A106EmployeeId[0];
               A148EmployeeName = H004L2_A148EmployeeName[0];
               A118WorkHourLogId = H004L2_A118WorkHourLogId[0];
               A100CompanyId = H004L2_A100CompanyId[0];
               A148EmployeeName = H004L2_A148EmployeeName[0];
               A157CompanyLocationId = H004L2_A157CompanyLocationId[0];
               /* Execute user event: Freestylegrid1.Load */
               E164L2 ();
               pr_default.readNext(0);
            }
            FREESTYLEGRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 23;
            WB4L0( ) ;
         }
         bGXsfl_23_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4L2( )
      {
      }

      protected int subFreestylegrid1_fnc_Pagecount( )
      {
         FREESTYLEGRID1_nRecordCount = subFreestylegrid1_fnc_Recordcount( );
         if ( ((int)((FREESTYLEGRID1_nRecordCount) % (subFreestylegrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(FREESTYLEGRID1_nRecordCount/ (decimal)(subFreestylegrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(FREESTYLEGRID1_nRecordCount/ (decimal)(subFreestylegrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subFreestylegrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV12CompanyLocationId ,
                                              A106EmployeeId ,
                                              AV13EmployeeId ,
                                              AV12CompanyLocationId.Count ,
                                              AV13EmployeeId.Count ,
                                              AV15FromDate ,
                                              AV16ToDate ,
                                              A119WorkHourLogDate ,
                                              A102ProjectId ,
                                              AV22OneProjectId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         /* Using cursor H004L3 */
         pr_default.execute(1, new Object[] {AV22OneProjectId, AV15FromDate, AV16ToDate});
         FREESTYLEGRID1_nRecordCount = H004L3_AFREESTYLEGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(FREESTYLEGRID1_nRecordCount) ;
      }

      protected int subFreestylegrid1_fnc_Recordsperpage( )
      {
         if ( subFreestylegrid1_Rows > 0 )
         {
            return subFreestylegrid1_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subFreestylegrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(FREESTYLEGRID1_nFirstRecordOnPage/ (decimal)(subFreestylegrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subfreestylegrid1_firstpage( )
      {
         FREESTYLEGRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22OneProjectId, AV15FromDate, AV16ToDate, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subfreestylegrid1_nextpage( )
      {
         FREESTYLEGRID1_nRecordCount = subFreestylegrid1_fnc_Recordcount( );
         if ( ( FREESTYLEGRID1_nRecordCount >= subFreestylegrid1_fnc_Recordsperpage( ) ) && ( FREESTYLEGRID1_nEOF == 0 ) )
         {
            FREESTYLEGRID1_nFirstRecordOnPage = (long)(FREESTYLEGRID1_nFirstRecordOnPage+subFreestylegrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Freestylegrid1Container.AddObjectProperty("FREESTYLEGRID1_nFirstRecordOnPage", FREESTYLEGRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22OneProjectId, AV15FromDate, AV16ToDate, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((FREESTYLEGRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subfreestylegrid1_previouspage( )
      {
         if ( FREESTYLEGRID1_nFirstRecordOnPage >= subFreestylegrid1_fnc_Recordsperpage( ) )
         {
            FREESTYLEGRID1_nFirstRecordOnPage = (long)(FREESTYLEGRID1_nFirstRecordOnPage-subFreestylegrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22OneProjectId, AV15FromDate, AV16ToDate, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subfreestylegrid1_lastpage( )
      {
         FREESTYLEGRID1_nRecordCount = subFreestylegrid1_fnc_Recordcount( );
         if ( FREESTYLEGRID1_nRecordCount > subFreestylegrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((FREESTYLEGRID1_nRecordCount) % (subFreestylegrid1_fnc_Recordsperpage( )))) == 0 )
            {
               FREESTYLEGRID1_nFirstRecordOnPage = (long)(FREESTYLEGRID1_nRecordCount-subFreestylegrid1_fnc_Recordsperpage( ));
            }
            else
            {
               FREESTYLEGRID1_nFirstRecordOnPage = (long)(FREESTYLEGRID1_nRecordCount-((int)((FREESTYLEGRID1_nRecordCount) % (subFreestylegrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            FREESTYLEGRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22OneProjectId, AV15FromDate, AV16ToDate, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subfreestylegrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            FREESTYLEGRID1_nFirstRecordOnPage = (long)(subFreestylegrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            FREESTYLEGRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(FREESTYLEGRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrFreestylegrid1_refresh( subFreestylegrid1_Rows, AV22OneProjectId, AV15FromDate, AV16ToDate, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtEmployeeName_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E144L2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_23 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_23"), ".", ","), 18, MidpointRounding.ToEven));
            AV10FreeStyleGrid1PageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vFREESTYLEGRID1PAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV11FreeStyleGrid1AppliedFilters = cgiGet( sPrefix+"vFREESTYLEGRID1APPLIEDFILTERS");
            wcpOAV22OneProjectId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV22OneProjectId"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOAV15FromDate = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV15FromDate"), 0);
            wcpOAV16ToDate = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV16ToDate"), 0);
            AV16ToDate = context.localUtil.CToD( cgiGet( sPrefix+"vTODATE"), 0);
            AV26DateRange_To = context.localUtil.CToD( cgiGet( sPrefix+"vDATERANGE_TO"), 0);
            AV15FromDate = context.localUtil.CToD( cgiGet( sPrefix+"vFROMDATE"), 0);
            AV21DateRange = context.localUtil.CToD( cgiGet( sPrefix+"vDATERANGE"), 0);
            FREESTYLEGRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"FREESTYLEGRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            FREESTYLEGRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"FREESTYLEGRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subFreestylegrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"FREESTYLEGRID1_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
            Freestylegrid1paginationbar_Class = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Class");
            Freestylegrid1paginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Showfirst"));
            Freestylegrid1paginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Showprevious"));
            Freestylegrid1paginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Shownext"));
            Freestylegrid1paginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Showlast"));
            Freestylegrid1paginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Pagestoshow"), ".", ","), 18, MidpointRounding.ToEven));
            Freestylegrid1paginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Pagingbuttonsposition");
            Freestylegrid1paginationbar_Pagingcaptionposition = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Pagingcaptionposition");
            Freestylegrid1paginationbar_Emptygridclass = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Emptygridclass");
            Freestylegrid1paginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselector"));
            Freestylegrid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Freestylegrid1paginationbar_Rowsperpageoptions = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpageoptions");
            Freestylegrid1paginationbar_Previous = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Previous");
            Freestylegrid1paginationbar_Next = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Next");
            Freestylegrid1paginationbar_Caption = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Caption");
            Freestylegrid1paginationbar_Emptygridcaption = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Emptygridcaption");
            Freestylegrid1paginationbar_Rowsperpagecaption = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpagecaption");
            Innewwindow1_Name = cgiGet( sPrefix+"INNEWWINDOW1_Name");
            Innewwindow1_Target = cgiGet( sPrefix+"INNEWWINDOW1_Target");
            Freestylegrid1paginationbar_Selectedpage = cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Selectedpage");
            Freestylegrid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"FREESTYLEGRID1PAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            subFreestylegrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"FREESTYLEGRID1_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFreestylegrid1currentpage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFreestylegrid1currentpage_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFREESTYLEGRID1CURRENTPAGE");
               GX_FocusControl = edtavFreestylegrid1currentpage_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9FreeStyleGrid1CurrentPage = 0;
               AssignAttri(sPrefix, false, "AV9FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV9FreeStyleGrid1CurrentPage), 10, 0));
            }
            else
            {
               AV9FreeStyleGrid1CurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavFreestylegrid1currentpage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV9FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV9FreeStyleGrid1CurrentPage), 10, 0));
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
         E144L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E144L2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETSESSIONVARIABLES' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV14ProjectId.Add(AV22OneProjectId, 0);
         if ( AV13EmployeeId.Count == 0 )
         {
            GXt_objcol_int1 = AV13EmployeeId;
            new getemployeeidsbyproject(context ).execute(  AV14ProjectId, out  GXt_objcol_int1) ;
            AV13EmployeeId = GXt_objcol_int1;
         }
         new logtofile(context ).execute(  "Employeees: "+AV13EmployeeId.ToJSonString(false)) ;
         new logtofile(context ).execute(  "Project: "+StringUtil.Str( (decimal)(AV22OneProjectId), 4, 0)) ;
         new logtofile(context ).execute(  "Dates: "+context.localUtil.DToC( AV15FromDate, 2, "/")+" "+context.localUtil.DToC( AV16ToDate, 2, "/")) ;
         GXt_int2 = AV17LoggedInEmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int2) ;
         AV17LoggedInEmployeeId = GXt_int2;
         GXt_boolean3 = AV19IsManager;
         new userhasrole(context ).execute(  "Manager", out  GXt_boolean3) ;
         AV19IsManager = GXt_boolean3;
         subFreestylegrid1_Rows = 5;
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
         edtEmployeeName_Visible = 0;
         AssignProp(sPrefix, false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), !bGXsfl_23_Refreshing);
         edtEmployeeId_Visible = 0;
         AssignProp(sPrefix, false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), !bGXsfl_23_Refreshing);
         AV9FreeStyleGrid1CurrentPage = 1;
         AssignAttri(sPrefix, false, "AV9FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV9FreeStyleGrid1CurrentPage), 10, 0));
         edtavFreestylegrid1currentpage_Visible = 0;
         AssignProp(sPrefix, false, edtavFreestylegrid1currentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFreestylegrid1currentpage_Visible), 5, 0), true);
         AV10FreeStyleGrid1PageCount = -1;
         AssignAttri(sPrefix, false, "AV10FreeStyleGrid1PageCount", StringUtil.LTrimStr( (decimal)(AV10FreeStyleGrid1PageCount), 10, 0));
         Freestylegrid1paginationbar_Rowsperpageselectedvalue = subFreestylegrid1_Rows;
         ucFreestylegrid1paginationbar.SendProperty(context, sPrefix, false, Freestylegrid1paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Freestylegrid1paginationbar_Rowsperpageselectedvalue), 9, 0));
         /* Execute user subroutine: 'UPDATESESSIONVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E154L2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
      }

      private void E164L2( )
      {
         /* Freestylegrid1_Load Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            bDynCreated_Wcreportsworkhourlogdetails = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcreportsworkhourlogdetails_Component), StringUtil.Lower( "ReportsWorkHourLogDetails")) != 0 )
         {
            WebComp_Wcreportsworkhourlogdetails = getWebComponent(GetType(), "GeneXus.Programs", "reportsworkhourlogdetails", new Object[] {context} );
            WebComp_Wcreportsworkhourlogdetails.ComponentInit();
            WebComp_Wcreportsworkhourlogdetails.Name = "ReportsWorkHourLogDetails";
            WebComp_Wcreportsworkhourlogdetails_Component = "ReportsWorkHourLogDetails";
         }
         if ( StringUtil.Len( WebComp_Wcreportsworkhourlogdetails_Component) != 0 )
         {
            WebComp_Wcreportsworkhourlogdetails.setjustcreated();
            WebComp_Wcreportsworkhourlogdetails.componentprepare(new Object[] {(string)sPrefix+"W0027",(string)sGXsfl_23_idx,(long)A106EmployeeId,(string)A148EmployeeName,(DateTime)AV15FromDate,(DateTime)AV16ToDate,(short)AV22OneProjectId});
            WebComp_Wcreportsworkhourlogdetails.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)"",(string)""});
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 23;
         }
         sendrow_232( ) ;
         FREESTYLEGRID1_nCurrentRecord = (long)(FREESTYLEGRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_23_Refreshing )
         {
            DoAjaxLoad(23, Freestylegrid1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E114L2( )
      {
         /* Freestylegrid1paginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Freestylegrid1paginationbar_Selectedpage, "Previous") == 0 )
         {
            AV9FreeStyleGrid1CurrentPage = (long)(AV9FreeStyleGrid1CurrentPage-1);
            AssignAttri(sPrefix, false, "AV9FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV9FreeStyleGrid1CurrentPage), 10, 0));
            subfreestylegrid1_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Freestylegrid1paginationbar_Selectedpage, "Next") == 0 )
         {
            AV9FreeStyleGrid1CurrentPage = (long)(AV9FreeStyleGrid1CurrentPage+1);
            AssignAttri(sPrefix, false, "AV9FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV9FreeStyleGrid1CurrentPage), 10, 0));
            subfreestylegrid1_nextpage( ) ;
         }
         else
         {
            AV8PageToGo = (int)(Math.Round(NumberUtil.Val( Freestylegrid1paginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV9FreeStyleGrid1CurrentPage = AV8PageToGo;
            AssignAttri(sPrefix, false, "AV9FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV9FreeStyleGrid1CurrentPage), 10, 0));
            subfreestylegrid1_gotopage( AV8PageToGo) ;
         }
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E124L2( )
      {
         /* Freestylegrid1paginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subFreestylegrid1_Rows = Freestylegrid1paginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"FREESTYLEGRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Rows), 6, 0, ".", "")));
         AV9FreeStyleGrid1CurrentPage = 1;
         AssignAttri(sPrefix, false, "AV9FreeStyleGrid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV9FreeStyleGrid1CurrentPage), 10, 0));
         subfreestylegrid1_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E134L2( )
      {
         /* 'DoExportExcel' Routine */
         returnInSub = false;
         new logtofile(context ).execute(  "Projects: "+AV14ProjectId.ToJSonString(false)) ;
         new logtofile(context ).execute(  "Employees: "+AV13EmployeeId.ToJSonString(false)) ;
         new employeehoursreport(context ).execute( ref  AV21DateRange, ref  AV26DateRange_To, ref  AV14ProjectId, ref  AV12CompanyLocationId, ref  AV13EmployeeId, out  AV35ExcelFilename, out  AV36ErrorMessage) ;
         AssignAttri(sPrefix, false, "AV21DateRange", context.localUtil.Format(AV21DateRange, "99/99/99"));
         AssignAttri(sPrefix, false, "AV26DateRange_To", context.localUtil.Format(AV26DateRange_To, "99/99/99"));
         Innewwindow1_Target = AV35ExcelFilename;
         ucInnewwindow1.SendProperty(context, sPrefix, false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Name = "_parent";
         ucInnewwindow1.SendProperty(context, sPrefix, false, Innewwindow1_Internalname, "Name", Innewwindow1_Name);
         this.executeUsercontrolMethod(sPrefix, false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13EmployeeId", AV13EmployeeId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12CompanyLocationId", AV12CompanyLocationId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV14ProjectId", AV14ProjectId);
      }

      protected void E174L2( )
      {
         /* Freestylegrid1_Refresh Routine */
         returnInSub = false;
         AV37RecordCount = (short)(subFreestylegrid1_fnc_Recordcount( ));
         AV10FreeStyleGrid1PageCount = (long)(AV37RecordCount/ (decimal)(subFreestylegrid1_Rows)+((((int)((AV37RecordCount) % (subFreestylegrid1_Rows)))>0) ? 1 : 0));
         AssignAttri(sPrefix, false, "AV10FreeStyleGrid1PageCount", StringUtil.LTrimStr( (decimal)(AV10FreeStyleGrid1PageCount), 10, 0));
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDATESESSIONVARIABLES' Routine */
         returnInSub = false;
         AV34WebSession.Set("CompanyLocationId", AV12CompanyLocationId.ToJSonString(false));
         AV34WebSession.Set("EmployeeId", AV13EmployeeId.ToJSonString(false));
         AV34WebSession.Set("OneProjectId", StringUtil.Str( (decimal)(AV22OneProjectId), 4, 0));
         AV34WebSession.Set("FromDate", context.localUtil.DToC( AV15FromDate, 2, "/"));
         AV34WebSession.Set("ToDate", context.localUtil.DToC( AV16ToDate, 2, "/"));
      }

      protected void S112( )
      {
         /* 'GETSESSIONVARIABLES' Routine */
         returnInSub = false;
         AV12CompanyLocationId.FromJSonString(AV34WebSession.Get("CompanyLocationId"), null);
         AV13EmployeeId.FromJSonString(AV34WebSession.Get("EmployeeId"), null);
         AV15FromDate = context.localUtil.CToD( AV34WebSession.Get("FromDate"), 2);
         AssignAttri(sPrefix, false, "AV15FromDate", context.localUtil.Format(AV15FromDate, "99/99/99"));
         AV16ToDate = context.localUtil.CToD( AV34WebSession.Get("ToDate"), 2);
         AssignAttri(sPrefix, false, "AV16ToDate", context.localUtil.Format(AV16ToDate, "99/99/99"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV22OneProjectId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV22OneProjectId", StringUtil.LTrimStr( (decimal)(AV22OneProjectId), 4, 0));
         AV15FromDate = (DateTime)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV15FromDate", context.localUtil.Format(AV15FromDate, "99/99/99"));
         AV16ToDate = (DateTime)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV16ToDate", context.localUtil.Format(AV16ToDate, "99/99/99"));
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
         PA4L2( ) ;
         WS4L2( ) ;
         WE4L2( ) ;
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
         sCtrlAV22OneProjectId = (string)((string)getParm(obj,0));
         sCtrlAV15FromDate = (string)((string)getParm(obj,1));
         sCtrlAV16ToDate = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4L2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "projectdetails", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4L2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV22OneProjectId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV22OneProjectId", StringUtil.LTrimStr( (decimal)(AV22OneProjectId), 4, 0));
            AV15FromDate = (DateTime)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV15FromDate", context.localUtil.Format(AV15FromDate, "99/99/99"));
            AV16ToDate = (DateTime)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV16ToDate", context.localUtil.Format(AV16ToDate, "99/99/99"));
         }
         wcpOAV22OneProjectId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV22OneProjectId"), ".", ","), 18, MidpointRounding.ToEven));
         wcpOAV15FromDate = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV15FromDate"), 0);
         wcpOAV16ToDate = context.localUtil.CToD( cgiGet( sPrefix+"wcpOAV16ToDate"), 0);
         if ( ! GetJustCreated( ) && ( ( AV22OneProjectId != wcpOAV22OneProjectId ) || ( DateTimeUtil.ResetTime ( AV15FromDate ) != DateTimeUtil.ResetTime ( wcpOAV15FromDate ) ) || ( DateTimeUtil.ResetTime ( AV16ToDate ) != DateTimeUtil.ResetTime ( wcpOAV16ToDate ) ) ) )
         {
            setjustcreated();
         }
         wcpOAV22OneProjectId = AV22OneProjectId;
         wcpOAV15FromDate = AV15FromDate;
         wcpOAV16ToDate = AV16ToDate;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV22OneProjectId = cgiGet( sPrefix+"AV22OneProjectId_CTRL");
         if ( StringUtil.Len( sCtrlAV22OneProjectId) > 0 )
         {
            AV22OneProjectId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV22OneProjectId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22OneProjectId", StringUtil.LTrimStr( (decimal)(AV22OneProjectId), 4, 0));
         }
         else
         {
            AV22OneProjectId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV22OneProjectId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
         sCtrlAV15FromDate = cgiGet( sPrefix+"AV15FromDate_CTRL");
         if ( StringUtil.Len( sCtrlAV15FromDate) > 0 )
         {
            AV15FromDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( sCtrlAV15FromDate), 0));
            AssignAttri(sPrefix, false, "AV15FromDate", context.localUtil.Format(AV15FromDate, "99/99/99"));
         }
         else
         {
            AV15FromDate = context.localUtil.CToD( cgiGet( sPrefix+"AV15FromDate_PARM"), 0);
         }
         sCtrlAV16ToDate = cgiGet( sPrefix+"AV16ToDate_CTRL");
         if ( StringUtil.Len( sCtrlAV16ToDate) > 0 )
         {
            AV16ToDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( sCtrlAV16ToDate), 0));
            AssignAttri(sPrefix, false, "AV16ToDate", context.localUtil.Format(AV16ToDate, "99/99/99"));
         }
         else
         {
            AV16ToDate = context.localUtil.CToD( cgiGet( sPrefix+"AV16ToDate_PARM"), 0);
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
         PA4L2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4L2( ) ;
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
         WS4L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV22OneProjectId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22OneProjectId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV22OneProjectId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV22OneProjectId_CTRL", StringUtil.RTrim( sCtrlAV22OneProjectId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV15FromDate_PARM", context.localUtil.DToC( AV15FromDate, 0, "/"));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15FromDate)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15FromDate_CTRL", StringUtil.RTrim( sCtrlAV15FromDate));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16ToDate_PARM", context.localUtil.DToC( AV16ToDate, 0, "/"));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16ToDate)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16ToDate_CTRL", StringUtil.RTrim( sCtrlAV16ToDate));
         }
      }

      public override void componentdraw( )
      {
         if ( CheckCmpSecurityAccess() )
         {
            if ( nDoneStart == 0 )
            {
               WCStart( ) ;
            }
            BackMsgLst = context.GX_msglist;
            context.GX_msglist = LclMsgLst;
            WCParametersSet( ) ;
            WE4L2( ) ;
            SaveComponentMsgList(sPrefix);
            context.GX_msglist = BackMsgLst;
         }
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
         if ( ! ( WebComp_GX_Process == null ) )
         {
            WebComp_GX_Process.componentjscripts();
         }
         if ( ! ( WebComp_Wcreportsworkhourlogdetails == null ) )
         {
            WebComp_Wcreportsworkhourlogdetails.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcreportsworkhourlogdetails == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcreportsworkhourlogdetails_Component) != 0 )
            {
               WebComp_Wcreportsworkhourlogdetails.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267491646", true, true);
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
         context.AddJavascriptSource("projectdetails.js", "?20256267491647", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_232( )
      {
         edtEmployeeName_Internalname = sPrefix+"EMPLOYEENAME_"+sGXsfl_23_idx;
         edtEmployeeId_Internalname = sPrefix+"EMPLOYEEID_"+sGXsfl_23_idx;
      }

      protected void SubsflControlProps_fel_232( )
      {
         edtEmployeeName_Internalname = sPrefix+"EMPLOYEENAME_"+sGXsfl_23_fel_idx;
         edtEmployeeId_Internalname = sPrefix+"EMPLOYEEID_"+sGXsfl_23_fel_idx;
      }

      protected void sendrow_232( )
      {
         sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
         SubsflControlProps_232( ) ;
         WB4L0( ) ;
         if ( ( subFreestylegrid1_Rows * 1 == 0 ) || ( nGXsfl_23_idx <= subFreestylegrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Freestylegrid1Row = GXWebRow.GetNew(context,Freestylegrid1Container);
            if ( subFreestylegrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subFreestylegrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
               }
            }
            else if ( subFreestylegrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subFreestylegrid1_Backstyle = 0;
               subFreestylegrid1_Backcolor = subFreestylegrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Uniform";
               }
            }
            else if ( subFreestylegrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subFreestylegrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
               {
                  subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
               }
               subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
            }
            else if ( subFreestylegrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subFreestylegrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_23_idx) % (2))) == 0 )
               {
                  subFreestylegrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
                  {
                     subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Even";
                  }
               }
               else
               {
                  subFreestylegrid1_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subFreestylegrid1_Class, "") != 0 )
                  {
                     subFreestylegrid1_Linesclass = subFreestylegrid1_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subFreestylegrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_23_idx+"\">") ;
            }
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divFreestylegrid1layouttable_Internalname+"_"+sGXsfl_23_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, sPrefix+"W0027"+sGXsfl_23_idx, StringUtil.RTrim( WebComp_Wcreportsworkhourlogdetails_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
            context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0027"+sGXsfl_23_idx+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( bGXsfl_23_Refreshing )
            {
               if ( StringUtil.Len( WebComp_Wcreportsworkhourlogdetails_Component) != 0 )
               {
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0027"+sGXsfl_23_idx, cgiGet( "_EventName"), 1) != 0 ) )
                  {
                     if ( 1 != 0 )
                     {
                        if ( StringUtil.Len( WebComp_Wcreportsworkhourlogdetails_Component) != 0 )
                        {
                           WebComp_Wcreportsworkhourlogdetails.componentstart();
                        }
                     }
                  }
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcreportsworkhourlogdetails), StringUtil.Lower( WebComp_Wcreportsworkhourlogdetails_Component)) != 0 ) )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0027"+sGXsfl_23_idx);
                  }
                  WebComp_Wcreportsworkhourlogdetails.componentdraw();
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcreportsworkhourlogdetails), StringUtil.Lower( WebComp_Wcreportsworkhourlogdetails_Component)) != 0 ) )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            context.WriteHtmlText( "</div>") ;
            WebComp_Wcreportsworkhourlogdetails_Component = "";
            WebComp_Wcreportsworkhourlogdetails.componentjscripts();
            Freestylegrid1Row.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Wcreportsworkhourlogdetails"});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            Freestylegrid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsfreestylegrid1_Internalname+"_"+sGXsfl_23_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            Freestylegrid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,(string)"Employee Name",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeName_Internalname,StringUtil.RTrim( A148EmployeeName),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtEmployeeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("cell");
            }
            Freestylegrid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            Freestylegrid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            Freestylegrid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,(string)"Employee Id",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Single line edit */
            ROClassString = "Attribute";
            Freestylegrid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmployeeId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmployeeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtEmployeeId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("cell");
            }
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("row");
            }
            if ( Freestylegrid1Container.GetWrapped() == 1 )
            {
               Freestylegrid1Container.CloseTag("table");
            }
            /* End of table */
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            Freestylegrid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            send_integrity_lvl_hashes4L2( ) ;
            /* End of Columns property logic. */
            Freestylegrid1Container.AddRow(Freestylegrid1Row);
            nGXsfl_23_idx = ((subFreestylegrid1_Islastpage==1)&&(nGXsfl_23_idx+1>subFreestylegrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_23_idx+1);
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
         }
         /* End function sendrow_232 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl23( )
      {
         if ( Freestylegrid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Freestylegrid1Container"+"DivS\" data-gxgridid=\"23\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFreestylegrid1_Internalname, subFreestylegrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Freestylegrid1Container = new GXWebGrid( context);
            }
            else
            {
               Freestylegrid1Container.Clear();
            }
            Freestylegrid1Container.SetIsFreestyle(true);
            Freestylegrid1Container.SetWrapped(nGXWrapped);
            Freestylegrid1Container.AddObjectProperty("GridName", "Freestylegrid1");
            Freestylegrid1Container.AddObjectProperty("Header", subFreestylegrid1_Header);
            Freestylegrid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Freestylegrid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Freestylegrid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Backcolorstyle), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("CmpContext", sPrefix);
            Freestylegrid1Container.AddObjectProperty("InMasterPage", "false");
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A148EmployeeName)));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeName_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", ""))));
            Freestylegrid1Column.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEmployeeId_Visible), 5, 0, ".", "")));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Freestylegrid1Container.AddColumnProperties(Freestylegrid1Column);
            Freestylegrid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectedindex), 4, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowselection), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Selectioncolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowhovering), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Hoveringcolor), 9, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Allowcollapsing), 1, 0, ".", "")));
            Freestylegrid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFreestylegrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnexportexcel_Internalname = sPrefix+"BTNEXPORTEXCEL";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         edtEmployeeName_Internalname = sPrefix+"EMPLOYEENAME";
         edtEmployeeId_Internalname = sPrefix+"EMPLOYEEID";
         tblUnnamedtablecontentfsfreestylegrid1_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSFREESTYLEGRID1";
         divFreestylegrid1layouttable_Internalname = sPrefix+"FREESTYLEGRID1LAYOUTTABLE";
         Freestylegrid1paginationbar_Internalname = sPrefix+"FREESTYLEGRID1PAGINATIONBAR";
         divFreestylegrid1tablewithpaging_Internalname = sPrefix+"FREESTYLEGRID1TABLEWITHPAGING";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Innewwindow1_Internalname = sPrefix+"INNEWWINDOW1";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavFreestylegrid1currentpage_Internalname = sPrefix+"vFREESTYLEGRID1CURRENTPAGE";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subFreestylegrid1_Internalname = sPrefix+"FREESTYLEGRID1";
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
         subFreestylegrid1_Allowcollapsing = 0;
         edtEmployeeId_Jsonclick = "";
         edtEmployeeName_Jsonclick = "";
         subFreestylegrid1_Class = "FreeStyleGrid";
         edtEmployeeId_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         subFreestylegrid1_Backcolorstyle = 0;
         edtavFreestylegrid1currentpage_Jsonclick = "";
         edtavFreestylegrid1currentpage_Visible = 1;
         Innewwindow1_Target = "";
         Innewwindow1_Name = "";
         Freestylegrid1paginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Freestylegrid1paginationbar_Emptygridcaption = "No records found.";
         Freestylegrid1paginationbar_Caption = "Page <CURRENT_PAGE> of <TOTAL_PAGES>";
         Freestylegrid1paginationbar_Next = "WWP_PagingNextCaption";
         Freestylegrid1paginationbar_Previous = "WWP_PagingPreviousCaption";
         Freestylegrid1paginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Freestylegrid1paginationbar_Rowsperpageselectedvalue = 10;
         Freestylegrid1paginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Freestylegrid1paginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Freestylegrid1paginationbar_Pagingcaptionposition = "Left";
         Freestylegrid1paginationbar_Pagingbuttonsposition = "Right";
         Freestylegrid1paginationbar_Pagestoshow = 5;
         Freestylegrid1paginationbar_Showlast = Convert.ToBoolean( 0);
         Freestylegrid1paginationbar_Shownext = Convert.ToBoolean( -1);
         Freestylegrid1paginationbar_Showprevious = Convert.ToBoolean( -1);
         Freestylegrid1paginationbar_Showfirst = Convert.ToBoolean( 0);
         Freestylegrid1paginationbar_Class = "PaginationBar";
         edtEmployeeId_Visible = 1;
         edtEmployeeName_Visible = 1;
         subFreestylegrid1_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"},{"av":"AV22OneProjectId","fld":"vONEPROJECTID","pic":"ZZZ9"},{"av":"AV15FromDate","fld":"vFROMDATE"},{"av":"AV16ToDate","fld":"vTODATE"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"edtEmployeeId_Visible","ctrl":"EMPLOYEEID","prop":"Visible"},{"av":"sPrefix"}]}""");
         setEventMetadata("FREESTYLEGRID1.LOAD","""{"handler":"E164L2","iparms":[{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"},{"av":"AV15FromDate","fld":"vFROMDATE"},{"av":"AV16ToDate","fld":"vTODATE"},{"av":"AV22OneProjectId","fld":"vONEPROJECTID","pic":"ZZZ9"}]""");
         setEventMetadata("FREESTYLEGRID1.LOAD",""","oparms":[{"ctrl":"WCREPORTSWORKHOURLOGDETAILS"}]}""");
         setEventMetadata("FREESTYLEGRID1PAGINATIONBAR.CHANGEPAGE","""{"handler":"E114L2","iparms":[{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"},{"av":"AV22OneProjectId","fld":"vONEPROJECTID","pic":"ZZZ9"},{"av":"AV15FromDate","fld":"vFROMDATE"},{"av":"AV16ToDate","fld":"vTODATE"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"edtEmployeeId_Visible","ctrl":"EMPLOYEEID","prop":"Visible"},{"av":"sPrefix"},{"av":"Freestylegrid1paginationbar_Selectedpage","ctrl":"FREESTYLEGRID1PAGINATIONBAR","prop":"SelectedPage"},{"av":"AV9FreeStyleGrid1CurrentPage","fld":"vFREESTYLEGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("FREESTYLEGRID1PAGINATIONBAR.CHANGEPAGE",""","oparms":[{"av":"AV9FreeStyleGrid1CurrentPage","fld":"vFREESTYLEGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("FREESTYLEGRID1PAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E124L2","iparms":[{"av":"FREESTYLEGRID1_nFirstRecordOnPage"},{"av":"FREESTYLEGRID1_nEOF"},{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"},{"av":"AV22OneProjectId","fld":"vONEPROJECTID","pic":"ZZZ9"},{"av":"AV15FromDate","fld":"vFROMDATE"},{"av":"AV16ToDate","fld":"vTODATE"},{"av":"edtEmployeeName_Visible","ctrl":"EMPLOYEENAME","prop":"Visible"},{"av":"edtEmployeeId_Visible","ctrl":"EMPLOYEEID","prop":"Visible"},{"av":"sPrefix"},{"av":"Freestylegrid1paginationbar_Rowsperpageselectedvalue","ctrl":"FREESTYLEGRID1PAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("FREESTYLEGRID1PAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"},{"av":"AV9FreeStyleGrid1CurrentPage","fld":"vFREESTYLEGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOEXPORTEXCEL'","""{"handler":"E134L2","iparms":[{"av":"AV14ProjectId","fld":"vPROJECTID"},{"av":"AV13EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV21DateRange","fld":"vDATERANGE"},{"av":"AV26DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"}]""");
         setEventMetadata("'DOEXPORTEXCEL'",""","oparms":[{"av":"AV13EmployeeId","fld":"vEMPLOYEEID"},{"av":"AV12CompanyLocationId","fld":"vCOMPANYLOCATIONID"},{"av":"AV14ProjectId","fld":"vPROJECTID"},{"av":"AV26DateRange_To","fld":"vDATERANGE_TO"},{"av":"AV21DateRange","fld":"vDATERANGE"},{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Name","ctrl":"INNEWWINDOW1","prop":"Name"}]}""");
         setEventMetadata("FREESTYLEGRID1.REFRESH","""{"handler":"E174L2","iparms":[{"av":"subFreestylegrid1_Rows","ctrl":"FREESTYLEGRID1","prop":"Rows"}]""");
         setEventMetadata("FREESTYLEGRID1.REFRESH",""","oparms":[{"av":"AV10FreeStyleGrid1PageCount","fld":"vFREESTYLEGRID1PAGECOUNT","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[]}""");
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
         wcpOAV15FromDate = DateTime.MinValue;
         wcpOAV16ToDate = DateTime.MinValue;
         Freestylegrid1paginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV11FreeStyleGrid1AppliedFilters = "";
         AV14ProjectId = new GxSimpleCollection<long>();
         AV13EmployeeId = new GxSimpleCollection<long>();
         AV21DateRange = DateTime.MinValue;
         AV26DateRange_To = DateTime.MinValue;
         AV12CompanyLocationId = new GxSimpleCollection<long>();
         AV32InProjectId = new GxSimpleCollection<long>();
         AV31InEmployeeId = new GxSimpleCollection<long>();
         AV30InCompanyLocationId = new GxSimpleCollection<long>();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnexportexcel_Jsonclick = "";
         Freestylegrid1Container = new GXWebGrid( context);
         sStyleString = "";
         ucFreestylegrid1paginationbar = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A148EmployeeName = "";
         OldWcreportsworkhourlogdetails = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         WebComp_Wcreportsworkhourlogdetails_Component = "";
         A119WorkHourLogDate = DateTime.MinValue;
         H004L2_A100CompanyId = new long[1] ;
         H004L2_A102ProjectId = new long[1] ;
         H004L2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         H004L2_A157CompanyLocationId = new long[1] ;
         H004L2_A106EmployeeId = new long[1] ;
         H004L2_A148EmployeeName = new string[] {""} ;
         H004L2_A118WorkHourLogId = new long[1] ;
         H004L3_AFREESTYLEGRID1_nRecordCount = new long[1] ;
         GXt_objcol_int1 = new GxSimpleCollection<long>();
         Freestylegrid1Row = new GXWebRow();
         AV35ExcelFilename = "";
         AV36ErrorMessage = "";
         AV34WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV22OneProjectId = "";
         sCtrlAV15FromDate = "";
         sCtrlAV16ToDate = "";
         subFreestylegrid1_Linesclass = "";
         ROClassString = "";
         subFreestylegrid1_Header = "";
         Freestylegrid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.projectdetails__default(),
            new Object[][] {
                new Object[] {
               H004L2_A100CompanyId, H004L2_A102ProjectId, H004L2_A119WorkHourLogDate, H004L2_A157CompanyLocationId, H004L2_A106EmployeeId, H004L2_A148EmployeeName, H004L2_A118WorkHourLogId
               }
               , new Object[] {
               H004L3_AFREESTYLEGRID1_nRecordCount
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcreportsworkhourlogdetails = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV22OneProjectId ;
      private short wcpOAV22OneProjectId ;
      private short FREESTYLEGRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subFreestylegrid1_Backcolorstyle ;
      private short AV37RecordCount ;
      private short nGXWrapped ;
      private short subFreestylegrid1_Backstyle ;
      private short subFreestylegrid1_Allowselection ;
      private short subFreestylegrid1_Allowhovering ;
      private short subFreestylegrid1_Allowcollapsing ;
      private short subFreestylegrid1_Collapsed ;
      private int edtEmployeeName_Visible ;
      private int edtEmployeeId_Visible ;
      private int Freestylegrid1paginationbar_Rowsperpageselectedvalue ;
      private int subFreestylegrid1_Rows ;
      private int nRC_GXsfl_23 ;
      private int nGXsfl_23_idx=1 ;
      private int Freestylegrid1paginationbar_Pagestoshow ;
      private int edtavFreestylegrid1currentpage_Visible ;
      private int nGXsfl_23_webc_idx=0 ;
      private int subFreestylegrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV12CompanyLocationId_Count ;
      private int AV13EmployeeId_Count ;
      private int edtEmployeeName_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int AV8PageToGo ;
      private int idxLst ;
      private int subFreestylegrid1_Backcolor ;
      private int subFreestylegrid1_Allbackcolor ;
      private int subFreestylegrid1_Selectedindex ;
      private int subFreestylegrid1_Selectioncolor ;
      private int subFreestylegrid1_Hoveringcolor ;
      private long FREESTYLEGRID1_nFirstRecordOnPage ;
      private long AV10FreeStyleGrid1PageCount ;
      private long AV9FreeStyleGrid1CurrentPage ;
      private long A106EmployeeId ;
      private long FREESTYLEGRID1_nCurrentRecord ;
      private long A157CompanyLocationId ;
      private long A102ProjectId ;
      private long A100CompanyId ;
      private long A118WorkHourLogId ;
      private long FREESTYLEGRID1_nRecordCount ;
      private long AV17LoggedInEmployeeId ;
      private long GXt_int2 ;
      private string Freestylegrid1paginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_23_idx="0001" ;
      private string edtEmployeeName_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Freestylegrid1paginationbar_Class ;
      private string Freestylegrid1paginationbar_Pagingbuttonsposition ;
      private string Freestylegrid1paginationbar_Pagingcaptionposition ;
      private string Freestylegrid1paginationbar_Emptygridclass ;
      private string Freestylegrid1paginationbar_Rowsperpageoptions ;
      private string Freestylegrid1paginationbar_Previous ;
      private string Freestylegrid1paginationbar_Next ;
      private string Freestylegrid1paginationbar_Caption ;
      private string Freestylegrid1paginationbar_Emptygridcaption ;
      private string Freestylegrid1paginationbar_Rowsperpagecaption ;
      private string Innewwindow1_Name ;
      private string Innewwindow1_Target ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divUnnamedtable1_Internalname ;
      private string TempTags ;
      private string bttBtnexportexcel_Internalname ;
      private string bttBtnexportexcel_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string divFreestylegrid1tablewithpaging_Internalname ;
      private string sStyleString ;
      private string subFreestylegrid1_Internalname ;
      private string Freestylegrid1paginationbar_Internalname ;
      private string Innewwindow1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavFreestylegrid1currentpage_Internalname ;
      private string edtavFreestylegrid1currentpage_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A148EmployeeName ;
      private string OldWcreportsworkhourlogdetails ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string WebComp_Wcreportsworkhourlogdetails_Component ;
      private string sCtrlAV22OneProjectId ;
      private string sCtrlAV15FromDate ;
      private string sCtrlAV16ToDate ;
      private string sGXsfl_23_fel_idx="0001" ;
      private string subFreestylegrid1_Class ;
      private string subFreestylegrid1_Linesclass ;
      private string divFreestylegrid1layouttable_Internalname ;
      private string tblUnnamedtablecontentfsfreestylegrid1_Internalname ;
      private string ROClassString ;
      private string edtEmployeeName_Jsonclick ;
      private string edtEmployeeId_Jsonclick ;
      private string subFreestylegrid1_Header ;
      private DateTime AV15FromDate ;
      private DateTime AV16ToDate ;
      private DateTime wcpOAV15FromDate ;
      private DateTime wcpOAV16ToDate ;
      private DateTime AV21DateRange ;
      private DateTime AV26DateRange_To ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_23_Refreshing=false ;
      private bool Freestylegrid1paginationbar_Showfirst ;
      private bool Freestylegrid1paginationbar_Showprevious ;
      private bool Freestylegrid1paginationbar_Shownext ;
      private bool Freestylegrid1paginationbar_Showlast ;
      private bool Freestylegrid1paginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV19IsManager ;
      private bool GXt_boolean3 ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wcreportsworkhourlogdetails ;
      private string AV11FreeStyleGrid1AppliedFilters ;
      private string AV35ExcelFilename ;
      private string AV36ErrorMessage ;
      private GXWebComponent WebComp_Wcreportsworkhourlogdetails ;
      private GXWebGrid Freestylegrid1Container ;
      private GXWebRow Freestylegrid1Row ;
      private GXWebColumn Freestylegrid1Column ;
      private GXUserControl ucFreestylegrid1paginationbar ;
      private GXUserControl ucInnewwindow1 ;
      private GXWebForm Form ;
      private IGxSession AV34WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP1_FromDate ;
      private DateTime aP2_ToDate ;
      private GxSimpleCollection<long> AV14ProjectId ;
      private GxSimpleCollection<long> AV13EmployeeId ;
      private GxSimpleCollection<long> AV12CompanyLocationId ;
      private GxSimpleCollection<long> AV32InProjectId ;
      private GxSimpleCollection<long> AV31InEmployeeId ;
      private GxSimpleCollection<long> AV30InCompanyLocationId ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private long[] H004L2_A100CompanyId ;
      private long[] H004L2_A102ProjectId ;
      private DateTime[] H004L2_A119WorkHourLogDate ;
      private long[] H004L2_A157CompanyLocationId ;
      private long[] H004L2_A106EmployeeId ;
      private string[] H004L2_A148EmployeeName ;
      private long[] H004L2_A118WorkHourLogId ;
      private long[] H004L3_AFREESTYLEGRID1_nRecordCount ;
      private GxSimpleCollection<long> GXt_objcol_int1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class projectdetails__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004L2( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV12CompanyLocationId ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV13EmployeeId ,
                                             int AV12CompanyLocationId_Count ,
                                             int AV13EmployeeId_Count ,
                                             DateTime AV15FromDate ,
                                             DateTime AV16ToDate ,
                                             DateTime A119WorkHourLogDate ,
                                             long A102ProjectId ,
                                             short AV22OneProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT NULL AS CompanyId, NULL AS ProjectId, NULL AS WorkHourLogDate, NULL AS CompanyLocationId, EmployeeId, EmployeeName, NULL AS WorkHourLogId FROM ( SELECT T2.CompanyId, T1.ProjectId, T1.WorkHourLogDate, T3.CompanyLocationId, T1.EmployeeId, T2.EmployeeName, T1.WorkHourLogId";
         sFromString = " FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId)";
         sOrderString = "";
         string sOrderStringT;
         sOrderStringT = " ORDER BY EmployeeName";
         AddWhere(sWhereString, "(T1.ProjectId = :AV22OneProjectId)");
         if ( AV12CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12CompanyLocationId, "T3.CompanyLocationId IN (", ")")+")");
         }
         if ( AV13EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13EmployeeId, "T1.EmployeeId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV15FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV15FromDate)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV16ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV16ToDate)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         sOrderString += " ORDER BY T2.EmployeeName, T1.WorkHourLogId";
         sOrderStringT = " ORDER BY EmployeeName";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + ") DistinctT" + sOrderStringT + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H004L3( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV12CompanyLocationId ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV13EmployeeId ,
                                             int AV12CompanyLocationId_Count ,
                                             int AV13EmployeeId_Count ,
                                             DateTime AV15FromDate ,
                                             DateTime AV16ToDate ,
                                             DateTime A119WorkHourLogDate ,
                                             long A102ProjectId ,
                                             short AV22OneProjectId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[3];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ( SELECT T2.EmployeeName, T1.EmployeeId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId)";
         AddWhere(sWhereString, "(T1.ProjectId = :AV22OneProjectId)");
         if ( AV12CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12CompanyLocationId, "T3.CompanyLocationId IN (", ")")+")");
         }
         if ( AV13EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13EmployeeId, "T1.EmployeeId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV15FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV15FromDate)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV16ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV16ToDate)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " GROUP BY T2.EmployeeName, T1.EmployeeId) GroupByT";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H004L2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H004L3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmH004L2;
          prmH004L2 = new Object[] {
          new ParDef("AV22OneProjectId",GXType.Int16,4,0) ,
          new ParDef("AV15FromDate",GXType.Date,8,0) ,
          new ParDef("AV16ToDate",GXType.Date,8,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004L3;
          prmH004L3 = new Object[] {
          new ParDef("AV22OneProjectId",GXType.Int16,4,0) ,
          new ParDef("AV15FromDate",GXType.Date,8,0) ,
          new ParDef("AV16ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004L2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004L3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
