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
   public class createemployee : GXDataArea
   {
      public createemployee( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public createemployee( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           long aP1_EmployeeId )
      {
         this.AV11TrnMode = aP0_TrnMode;
         this.AV15EmployeeId = aP1_EmployeeId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavEmployee_companyid = new GXCombobox();
         chkavEmployee_employeeismanager = new GXCheckbox();
         chkavEmployee_employeeisactive = new GXCheckbox();
         dynavEmployee_project__projectid = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"EMPLOYEE_PROJECT__PROJECTID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVEMPLOYEE_PROJECT__PROJECTID3Y2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_project") == 0 )
            {
               gxnrGridlevel_project_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridlevel_project") == 0 )
            {
               gxgrGridlevel_project_refresh_invoke( ) ;
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
                  AV15EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15EmployeeId", StringUtil.LTrimStr( (decimal)(AV15EmployeeId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15EmployeeId), "ZZZZZZZZZ9"), context));
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

      protected void gxnrGridlevel_project_newrow_invoke( )
      {
         nRC_GXsfl_55 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_55"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_55_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_55_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_55_idx = GetPar( "sGXsfl_55_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_project_newrow( ) ;
         /* End function gxnrGridlevel_project_newrow_invoke */
      }

      protected void gxgrGridlevel_project_refresh_invoke( )
      {
         subGridlevel_project_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridlevel_project_Rows"), "."), 18, MidpointRounding.ToEven));
         AV11TrnMode = GetPar( "TrnMode");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV7Employee);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV18EmployeeProjectDeleted);
         dynavEmployee_companyid.FromJSonString( GetNextPar( ));
         AV7Employee.gxTpr_Companyid = (long)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AV7Employee.gxTpr_Employeeismanager = StringUtil.StrToBool( GetNextPar( ));
         AV7Employee.gxTpr_Employeeisactive = StringUtil.StrToBool( GetNextPar( ));
         AV15EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridlevel_project_refresh( subGridlevel_project_Rows, AV11TrnMode, AV7Employee, AV18EmployeeProjectDeleted, AV7Employee.gxTpr_Companyid, AV7Employee.gxTpr_Employeeismanager, AV7Employee.gxTpr_Employeeisactive, AV15EmployeeId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridlevel_project_refresh_invoke */
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
         PA3Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3Y2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("createemployee.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11TrnMode)),UrlEncode(StringUtil.LTrimStr(AV15EmployeeId,10,0))}, new string[] {"TrnMode","EmployeeId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15EmployeeId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Employee", AV7Employee);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Employee", AV7Employee);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_55", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_55), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV11TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEPROJECTDELETED", AV18EmployeeProjectDeleted);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEPROJECTDELETED", AV18EmployeeProjectDeleted);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV13CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV10Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV10Messages);
         }
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_PROJECT_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_PROJECT_nEOF), 1, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEE", AV7Employee);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEE", AV7Employee);
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridlevel_project_empowerer_Gridinternalname));
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
            WE3Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3Y2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("createemployee.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11TrnMode)),UrlEncode(StringUtil.LTrimStr(AV15EmployeeId,10,0))}, new string[] {"TrnMode","EmployeeId"})  ;
      }

      public override string GetPgmname( )
      {
         return "CreateEmployee" ;
      }

      public override string GetPgmdesc( )
      {
         return "Create Employee" ;
      }

      protected void WB3Y0( )
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
            ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
            ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
            ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
            ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
            ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
            ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
            ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
            ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
            ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
            ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmployee_employeefirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmployee_employeefirstname_Internalname, "First Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployee_employeefirstname_Internalname, StringUtil.RTrim( AV7Employee.gxTpr_Employeefirstname), StringUtil.RTrim( context.localUtil.Format( AV7Employee.gxTpr_Employeefirstname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployee_employeefirstname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmployee_employeefirstname_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateEmployee.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmployee_employeelastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmployee_employeelastname_Internalname, "Last Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployee_employeelastname_Internalname, StringUtil.RTrim( AV7Employee.gxTpr_Employeelastname), StringUtil.RTrim( context.localUtil.Format( AV7Employee.gxTpr_Employeelastname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployee_employeelastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmployee_employeelastname_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateEmployee.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmployee_employeeemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmployee_employeeemail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployee_employeeemail_Internalname, AV7Employee.gxTpr_Employeeemail, StringUtil.RTrim( context.localUtil.Format( AV7Employee.gxTpr_Employeeemail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployee_employeeemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmployee_employeeemail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_CreateEmployee.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavEmployee_companyid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEmployee_companyid_Internalname, "Company", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_55_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEmployee_companyid, dynavEmployee_companyid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7Employee.gxTpr_Companyid), 10, 0)), 1, dynavEmployee_companyid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEmployee_companyid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_CreateEmployee.htm");
            dynavEmployee_companyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Employee.gxTpr_Companyid), 10, 0));
            AssignProp("", false, dynavEmployee_companyid_Internalname, "Values", (string)(dynavEmployee_companyid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavEmployee_employeeismanager_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEmployee_employeeismanager_Internalname, "Is Manager", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_55_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEmployee_employeeismanager_Internalname, StringUtil.BoolToStr( AV7Employee.gxTpr_Employeeismanager), "", "Is Manager", 1, chkavEmployee_employeeismanager.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(40, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,40);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavEmployee_employeeisactive_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEmployee_employeeisactive_Internalname, "Is Active", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_55_idx + "',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEmployee_employeeisactive_Internalname, StringUtil.BoolToStr( AV7Employee.gxTpr_Employeeisactive), "", "Is Active", 1, chkavEmployee_employeeisactive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmployee_employeevactiondays_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmployee_employeevactiondays_Internalname, "Vacation Days", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployee_employeevactiondays_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Employee.gxTpr_Employeevactiondays, 4, 1, ".", "")), StringUtil.LTrim( context.localUtil.Format( AV7Employee.gxTpr_Employeevactiondays, "Z9.9")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployee_employeevactiondays_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmployee_employeevactiondays_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CreateEmployee.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableleaflevel_project_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridlevel_projectContainer.SetWrapped(nGXWrapped);
            StartGridControl55( ) ;
         }
         if ( wbEnd == 55 )
         {
            wbEnd = 0;
            nRC_GXsfl_55 = (int)(nGXsfl_55_idx-1);
            if ( Gridlevel_projectContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridlevel_projectContainer.AddObjectProperty("GRIDLEVEL_PROJECT_nEOF", GRIDLEVEL_PROJECT_nEOF);
               Gridlevel_projectContainer.AddObjectProperty("GRIDLEVEL_PROJECT_nFirstRecordOnPage", GRIDLEVEL_PROJECT_nFirstRecordOnPage);
               AV27GXV8 = nGXsfl_55_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Gridlevel_projectContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_project", Gridlevel_projectContainer, subGridlevel_project_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridlevel_projectContainerData", Gridlevel_projectContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Gridlevel_projectContainerData"+"V", Gridlevel_projectContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_projectContainerData"+"V"+"\" value='"+Gridlevel_projectContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ButtonAddGridLineCell", "Center", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "ButtonAddNewRow";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnaddgridlinegridlevel_project_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(55), 2, 0)+","+"null"+");", "[[New row]]", bttBtnaddgridlinegridlevel_project_Jsonclick, 5, "[[New row]]", "", StyleString, ClassString, bttBtnaddgridlinegridlevel_project_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOADDGRIDLINEGRIDLEVEL_PROJECT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateEmployee.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(55), 2, 0)+","+"null"+");", "Confirm", bttBtnenter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateEmployee.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(55), 2, 0)+","+"null"+");", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateEmployee.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(55), 2, 0)+","+"null"+");", "Save", bttBtnuseraction1_Jsonclick, 5, "Save", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CreateEmployee.htm");
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
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployee_employeeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Employee.gxTpr_Employeeid), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7Employee.gxTpr_Employeeid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployee_employeeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmployee_employeeid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CreateEmployee.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployee_employeename_Internalname, StringUtil.RTrim( AV7Employee.gxTpr_Employeename), StringUtil.RTrim( context.localUtil.Format( AV7Employee.gxTpr_Employeename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployee_employeename_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmployee_employeename_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateEmployee.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployee_companyname_Internalname, StringUtil.RTrim( AV7Employee.gxTpr_Companyname), StringUtil.RTrim( context.localUtil.Format( AV7Employee.gxTpr_Companyname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployee_companyname_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmployee_companyname_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CreateEmployee.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployee_gamuserguid_Internalname, AV7Employee.gxTpr_Gamuserguid, StringUtil.RTrim( context.localUtil.Format( AV7Employee.gxTpr_Gamuserguid, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployee_gamuserguid_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmployee_gamuserguid_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "", "start", true, "", "HLP_CreateEmployee.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployee_employeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV7Employee.gxTpr_Employeebalance, 4, 1, ".", "")), StringUtil.LTrim( context.localUtil.Format( AV7Employee.gxTpr_Employeebalance, "Z9.9")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployee_employeebalance_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmployee_employeebalance_Visible, 1, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CreateEmployee.htm");
            /* User Defined Control */
            ucGridlevel_project_empowerer.Render(context, "wwp.gridempowerer", Gridlevel_project_empowerer_Internalname, "GRIDLEVEL_PROJECT_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 55 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridlevel_projectContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridlevel_projectContainer.AddObjectProperty("GRIDLEVEL_PROJECT_nEOF", GRIDLEVEL_PROJECT_nEOF);
                  Gridlevel_projectContainer.AddObjectProperty("GRIDLEVEL_PROJECT_nFirstRecordOnPage", GRIDLEVEL_PROJECT_nFirstRecordOnPage);
                  AV27GXV8 = nGXsfl_55_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Gridlevel_projectContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_project", Gridlevel_projectContainer, subGridlevel_project_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridlevel_projectContainerData", Gridlevel_projectContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Gridlevel_projectContainerData"+"V", Gridlevel_projectContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_projectContainerData"+"V"+"\" value='"+Gridlevel_projectContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3Y2( )
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
         Form.Meta.addItem("description", "Create Employee", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3Y0( ) ;
      }

      protected void WS3Y2( )
      {
         START3Y2( ) ;
         EVT3Y2( ) ;
      }

      protected void EVT3Y2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserAction1' */
                              E113Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADDGRIDLINEGRIDLEVEL_PROJECT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAddGridLineGridLevel_Project' */
                              E123Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E133Y2 ();
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDLEVEL_PROJECTPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDLEVEL_PROJECTPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridlevel_project_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridlevel_project_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridlevel_project_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridlevel_project_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDLEVEL_PROJECT.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 38), "VDELETEGRIDLINEGRIDLEVEL_PROJECT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 38), "VDELETEGRIDLINEGRIDLEVEL_PROJECT.CLICK") == 0 ) )
                           {
                              nGXsfl_55_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
                              SubsflControlProps_552( ) ;
                              AV27GXV8 = (int)(nGXsfl_55_idx+GRIDLEVEL_PROJECT_nFirstRecordOnPage);
                              if ( ( AV7Employee.gxTpr_Project.Count >= AV27GXV8 ) && ( AV27GXV8 > 0 ) )
                              {
                                 AV7Employee.gxTpr_Project.CurrentItem = ((SdtEmployee_Project)AV7Employee.gxTpr_Project.Item(AV27GXV8));
                                 AV8DeleteGridLineGridLevel_Project = cgiGet( edtavDeletegridlinegridlevel_project_Internalname);
                                 AssignAttri("", false, edtavDeletegridlinegridlevel_project_Internalname, AV8DeleteGridLineGridLevel_Project);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E143Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E153Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDLEVEL_PROJECT.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridlevel_project.Load */
                                    E163Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETEGRIDLINEGRIDLEVEL_PROJECT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E173Y2 ();
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

      protected void WE3Y2( )
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

      protected void PA3Y2( )
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
               GX_FocusControl = edtavEmployee_employeefirstname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVEMPLOYEE_COMPANYID3Y1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVEMPLOYEE_COMPANYID_data3Y1( ) ;
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

      protected void GXVEMPLOYEE_COMPANYID_html3Y1( )
      {
         long gxdynajaxvalue;
         GXDLVEMPLOYEE_COMPANYID_data3Y1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEmployee_companyid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavEmployee_companyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavEmployee_companyid.ItemCount > 0 )
         {
            AV7Employee.gxTpr_Companyid = (long)(Math.Round(NumberUtil.Val( dynavEmployee_companyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Employee.gxTpr_Companyid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
      }

      protected void GXDLVEMPLOYEE_COMPANYID_data3Y1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H003Y2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H003Y2_A100CompanyId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H003Y2_A101CompanyName[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVEMPLOYEE_PROJECT__PROJECTID3Y2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVEMPLOYEE_PROJECT__PROJECTID_data3Y2( ) ;
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

      protected void GXVEMPLOYEE_PROJECT__PROJECTID_html3Y2( )
      {
         long gxdynajaxvalue;
         GXDLVEMPLOYEE_PROJECT__PROJECTID_data3Y2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEmployee_project__projectid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavEmployee_project__projectid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVEMPLOYEE_PROJECT__PROJECTID_data3Y2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H003Y3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H003Y3_A102ProjectId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H003Y3_A103ProjectName[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGridlevel_project_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_552( ) ;
         while ( nGXsfl_55_idx <= nRC_GXsfl_55 )
         {
            sendrow_552( ) ;
            nGXsfl_55_idx = ((subGridlevel_project_Islastpage==1)&&(nGXsfl_55_idx+1>subGridlevel_project_fnc_Recordsperpage( )) ? 1 : nGXsfl_55_idx+1);
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_552( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_projectContainer)) ;
         /* End function gxnrGridlevel_project_newrow */
      }

      protected void gxgrGridlevel_project_refresh( int subGridlevel_project_Rows ,
                                                    string AV11TrnMode ,
                                                    SdtEmployee AV7Employee ,
                                                    GxSimpleCollection<short> AV18EmployeeProjectDeleted ,
                                                    long GXV4 ,
                                                    bool GXV5 ,
                                                    bool GXV6 ,
                                                    long AV15EmployeeId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDLEVEL_PROJECT_nCurrentRecord = 0;
         RF3Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridlevel_project_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavEmployee_companyid.Name = "EMPLOYEE_COMPANYID";
            dynavEmployee_companyid.WebTags = "";
            dynavEmployee_companyid.removeAllItems();
            /* Using cursor H003Y4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynavEmployee_companyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H003Y4_A100CompanyId[0]), 10, 0)), H003Y4_A101CompanyName[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynavEmployee_companyid.ItemCount > 0 )
            {
               AV7Employee.gxTpr_Companyid = (long)(Math.Round(NumberUtil.Val( dynavEmployee_companyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Employee.gxTpr_Companyid), 10, 0))), "."), 18, MidpointRounding.ToEven));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavEmployee_companyid.ItemCount > 0 )
         {
            AV7Employee.gxTpr_Companyid = (long)(Math.Round(NumberUtil.Val( dynavEmployee_companyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Employee.gxTpr_Companyid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEmployee_companyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Employee.gxTpr_Companyid), 10, 0));
            AssignProp("", false, dynavEmployee_companyid_Internalname, "Values", dynavEmployee_companyid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavDeletegridlinegridlevel_project_Enabled = 0;
         edtavEmployee_project__projectname_Enabled = 0;
      }

      protected void RF3Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridlevel_projectContainer.ClearRows();
         }
         wbStart = 55;
         /* Execute user event: Refresh */
         E153Y2 ();
         nGXsfl_55_idx = 1;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_552( ) ;
         bGXsfl_55_Refreshing = true;
         Gridlevel_projectContainer.AddObjectProperty("GridName", "Gridlevel_project");
         Gridlevel_projectContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_projectContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_projectContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_projectContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_projectContainer.PageSize = subGridlevel_project_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_552( ) ;
            /* Execute user event: Gridlevel_project.Load */
            E163Y2 ();
            if ( ( subGridlevel_project_Islastpage == 0 ) && ( GRIDLEVEL_PROJECT_nCurrentRecord > 0 ) && ( GRIDLEVEL_PROJECT_nGridOutOfScope == 0 ) && ( nGXsfl_55_idx == 1 ) )
            {
               GRIDLEVEL_PROJECT_nCurrentRecord = 0;
               GRIDLEVEL_PROJECT_nGridOutOfScope = 1;
               subgridlevel_project_firstpage( ) ;
               /* Execute user event: Gridlevel_project.Load */
               E163Y2 ();
            }
            wbEnd = 55;
            WB3Y0( ) ;
         }
         bGXsfl_55_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Y2( )
      {
      }

      protected int subGridlevel_project_fnc_Pagecount( )
      {
         GRIDLEVEL_PROJECT_nRecordCount = subGridlevel_project_fnc_Recordcount( );
         if ( ((int)((GRIDLEVEL_PROJECT_nRecordCount) % (subGridlevel_project_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_PROJECT_nRecordCount/ (decimal)(subGridlevel_project_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_PROJECT_nRecordCount/ (decimal)(subGridlevel_project_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridlevel_project_fnc_Recordcount( )
      {
         return AV7Employee.gxTpr_Project.Count ;
      }

      protected int subGridlevel_project_fnc_Recordsperpage( )
      {
         if ( subGridlevel_project_Rows > 0 )
         {
            return subGridlevel_project_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridlevel_project_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDLEVEL_PROJECT_nFirstRecordOnPage/ (decimal)(subGridlevel_project_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridlevel_project_firstpage( )
      {
         GRIDLEVEL_PROJECT_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_PROJECT_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_project_refresh( subGridlevel_project_Rows, AV11TrnMode, AV7Employee, AV18EmployeeProjectDeleted, AV7Employee.gxTpr_Companyid, AV7Employee.gxTpr_Employeeismanager, AV7Employee.gxTpr_Employeeisactive, AV15EmployeeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlevel_project_nextpage( )
      {
         GRIDLEVEL_PROJECT_nRecordCount = subGridlevel_project_fnc_Recordcount( );
         if ( ( GRIDLEVEL_PROJECT_nRecordCount >= subGridlevel_project_fnc_Recordsperpage( ) ) && ( GRIDLEVEL_PROJECT_nEOF == 0 ) )
         {
            GRIDLEVEL_PROJECT_nFirstRecordOnPage = (long)(GRIDLEVEL_PROJECT_nFirstRecordOnPage+subGridlevel_project_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_PROJECT_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("GRIDLEVEL_PROJECT_nFirstRecordOnPage", GRIDLEVEL_PROJECT_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_project_refresh( subGridlevel_project_Rows, AV11TrnMode, AV7Employee, AV18EmployeeProjectDeleted, AV7Employee.gxTpr_Companyid, AV7Employee.gxTpr_Employeeismanager, AV7Employee.gxTpr_Employeeisactive, AV15EmployeeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDLEVEL_PROJECT_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridlevel_project_previouspage( )
      {
         if ( GRIDLEVEL_PROJECT_nFirstRecordOnPage >= subGridlevel_project_fnc_Recordsperpage( ) )
         {
            GRIDLEVEL_PROJECT_nFirstRecordOnPage = (long)(GRIDLEVEL_PROJECT_nFirstRecordOnPage-subGridlevel_project_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_PROJECT_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_project_refresh( subGridlevel_project_Rows, AV11TrnMode, AV7Employee, AV18EmployeeProjectDeleted, AV7Employee.gxTpr_Companyid, AV7Employee.gxTpr_Employeeismanager, AV7Employee.gxTpr_Employeeisactive, AV15EmployeeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridlevel_project_lastpage( )
      {
         GRIDLEVEL_PROJECT_nRecordCount = subGridlevel_project_fnc_Recordcount( );
         if ( GRIDLEVEL_PROJECT_nRecordCount > subGridlevel_project_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDLEVEL_PROJECT_nRecordCount) % (subGridlevel_project_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDLEVEL_PROJECT_nFirstRecordOnPage = (long)(GRIDLEVEL_PROJECT_nRecordCount-subGridlevel_project_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDLEVEL_PROJECT_nFirstRecordOnPage = (long)(GRIDLEVEL_PROJECT_nRecordCount-((int)((GRIDLEVEL_PROJECT_nRecordCount) % (subGridlevel_project_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDLEVEL_PROJECT_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_PROJECT_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_project_refresh( subGridlevel_project_Rows, AV11TrnMode, AV7Employee, AV18EmployeeProjectDeleted, AV7Employee.gxTpr_Companyid, AV7Employee.gxTpr_Employeeismanager, AV7Employee.gxTpr_Employeeisactive, AV15EmployeeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridlevel_project_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDLEVEL_PROJECT_nFirstRecordOnPage = (long)(subGridlevel_project_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDLEVEL_PROJECT_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_PROJECT_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridlevel_project_refresh( subGridlevel_project_Rows, AV11TrnMode, AV7Employee, AV18EmployeeProjectDeleted, AV7Employee.gxTpr_Companyid, AV7Employee.gxTpr_Employeeismanager, AV7Employee.gxTpr_Employeeisactive, AV15EmployeeId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavDeletegridlinegridlevel_project_Enabled = 0;
         edtavEmployee_project__projectname_Enabled = 0;
         GXVEMPLOYEE_PROJECT__PROJECTID_html3Y2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E143Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEE"), AV7Employee);
            ajax_req_read_hidden_sdt(cgiGet( "Employee"), AV7Employee);
            /* Read saved values. */
            nRC_GXsfl_55 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_55"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDLEVEL_PROJECT_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_PROJECT_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDLEVEL_PROJECT_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_PROJECT_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGridlevel_project_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDLEVEL_PROJECT_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Rows), 6, 0, ".", "")));
            Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
            Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
            Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
            Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
            Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
            Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
            Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
            Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
            Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
            Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
            Gridlevel_project_empowerer_Gridinternalname = cgiGet( "GRIDLEVEL_PROJECT_EMPOWERER_Gridinternalname");
            nRC_GXsfl_55 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_55"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_55_fel_idx = 0;
            while ( nGXsfl_55_fel_idx < nRC_GXsfl_55 )
            {
               nGXsfl_55_fel_idx = ((subGridlevel_project_Islastpage==1)&&(nGXsfl_55_fel_idx+1>subGridlevel_project_fnc_Recordsperpage( )) ? 1 : nGXsfl_55_fel_idx+1);
               sGXsfl_55_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_552( ) ;
               AV27GXV8 = (int)(nGXsfl_55_fel_idx+GRIDLEVEL_PROJECT_nFirstRecordOnPage);
               if ( ( AV7Employee.gxTpr_Project.Count >= AV27GXV8 ) && ( AV27GXV8 > 0 ) )
               {
                  AV7Employee.gxTpr_Project.CurrentItem = ((SdtEmployee_Project)AV7Employee.gxTpr_Project.Item(AV27GXV8));
                  AV8DeleteGridLineGridLevel_Project = cgiGet( edtavDeletegridlinegridlevel_project_Internalname);
               }
            }
            if ( nGXsfl_55_fel_idx == 0 )
            {
               nGXsfl_55_idx = 1;
               sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
               SubsflControlProps_552( ) ;
            }
            nGXsfl_55_fel_idx = 1;
            /* Read variables values. */
            AV7Employee.gxTpr_Employeefirstname = cgiGet( edtavEmployee_employeefirstname_Internalname);
            AV7Employee.gxTpr_Employeelastname = cgiGet( edtavEmployee_employeelastname_Internalname);
            AV7Employee.gxTpr_Employeeemail = cgiGet( edtavEmployee_employeeemail_Internalname);
            dynavEmployee_companyid.Name = dynavEmployee_companyid_Internalname;
            dynavEmployee_companyid.CurrentValue = cgiGet( dynavEmployee_companyid_Internalname);
            AV7Employee.gxTpr_Companyid = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavEmployee_companyid_Internalname), "."), 18, MidpointRounding.ToEven));
            AV7Employee.gxTpr_Employeeismanager = StringUtil.StrToBool( cgiGet( chkavEmployee_employeeismanager_Internalname));
            AV7Employee.gxTpr_Employeeisactive = StringUtil.StrToBool( cgiGet( chkavEmployee_employeeisactive_Internalname));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployee_employeevactiondays_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployee_employeevactiondays_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEE_EMPLOYEEVACTIONDAYS");
               GX_FocusControl = edtavEmployee_employeevactiondays_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Employee.gxTpr_Employeevactiondays = 0;
            }
            else
            {
               AV7Employee.gxTpr_Employeevactiondays = context.localUtil.CToN( cgiGet( edtavEmployee_employeevactiondays_Internalname), ".", ",");
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployee_employeeid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployee_employeeid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEE_EMPLOYEEID");
               GX_FocusControl = edtavEmployee_employeeid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Employee.gxTpr_Employeeid = 0;
            }
            else
            {
               AV7Employee.gxTpr_Employeeid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavEmployee_employeeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            AV7Employee.gxTpr_Employeename = cgiGet( edtavEmployee_employeename_Internalname);
            AV7Employee.gxTpr_Companyname = cgiGet( edtavEmployee_companyname_Internalname);
            AV7Employee.gxTpr_Gamuserguid = cgiGet( edtavEmployee_gamuserguid_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavEmployee_employeebalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavEmployee_employeebalance_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEE_EMPLOYEEBALANCE");
               GX_FocusControl = edtavEmployee_employeebalance_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Employee.gxTpr_Employeebalance = 0;
            }
            else
            {
               AV7Employee.gxTpr_Employeebalance = context.localUtil.CToN( cgiGet( edtavEmployee_employeebalance_Internalname), ".", ",");
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
         E143Y2 ();
         if (returnInSub) return;
      }

      protected void E143Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Work hours/minutes are required",  "error",  "#"+edtavEmployee_employeefirstname_Internalname,  "true",  ""));
         GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "The name is required",  "error",  "#"+edtavEmployee_employeefirstname_Internalname,  "true",  ""));
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV12LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV11TrnMode, "INS") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "employee_Insert") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "UPD") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "employee_Update") ) || ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "employee_Delete") ) )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "INS") != 0 )
            {
               AV7Employee.Load(AV15EmployeeId);
               gx_BV55 = true;
               AV12LoadSuccess = AV7Employee.Success();
               if ( ! AV12LoadSuccess )
               {
                  AV10Messages = AV7Employee.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) )
               {
                  edtavEmployee_employeefirstname_Enabled = 0;
                  AssignProp("", false, edtavEmployee_employeefirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployee_employeefirstname_Enabled), 5, 0), true);
                  edtavEmployee_employeelastname_Enabled = 0;
                  AssignProp("", false, edtavEmployee_employeelastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployee_employeelastname_Enabled), 5, 0), true);
                  edtavEmployee_employeeemail_Enabled = 0;
                  AssignProp("", false, edtavEmployee_employeeemail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployee_employeeemail_Enabled), 5, 0), true);
                  dynavEmployee_companyid.Enabled = 0;
                  AssignProp("", false, dynavEmployee_companyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavEmployee_companyid.Enabled), 5, 0), true);
                  chkavEmployee_employeeismanager.Enabled = 0;
                  AssignProp("", false, chkavEmployee_employeeismanager_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavEmployee_employeeismanager.Enabled), 5, 0), true);
                  chkavEmployee_employeeisactive.Enabled = 0;
                  AssignProp("", false, chkavEmployee_employeeisactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavEmployee_employeeisactive.Enabled), 5, 0), true);
                  edtavEmployee_employeevactiondays_Enabled = 0;
                  AssignProp("", false, edtavEmployee_employeevactiondays_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployee_employeevactiondays_Enabled), 5, 0), true);
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
         edtavEmployee_employeeid_Visible = 0;
         AssignProp("", false, edtavEmployee_employeeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmployee_employeeid_Visible), 5, 0), true);
         edtavEmployee_employeename_Visible = 0;
         AssignProp("", false, edtavEmployee_employeename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmployee_employeename_Visible), 5, 0), true);
         edtavEmployee_companyname_Visible = 0;
         AssignProp("", false, edtavEmployee_companyname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmployee_companyname_Visible), 5, 0), true);
         edtavEmployee_gamuserguid_Visible = 0;
         AssignProp("", false, edtavEmployee_gamuserguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmployee_gamuserguid_Visible), 5, 0), true);
         edtavEmployee_employeebalance_Visible = 0;
         AssignProp("", false, edtavEmployee_employeebalance_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmployee_employeebalance_Visible), 5, 0), true);
         Gridlevel_project_empowerer_Gridinternalname = subGridlevel_project_Internalname;
         ucGridlevel_project_empowerer.SendProperty(context, "", false, Gridlevel_project_empowerer_Internalname, "GridInternalName", Gridlevel_project_empowerer_Gridinternalname);
         subGridlevel_project_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Rows), 6, 0, ".", "")));
      }

      protected void E153Y2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         edtavDeletegridlinegridlevel_project_Columnheaderclass = "WWIconActionColumn";
         AssignProp("", false, edtavDeletegridlinegridlevel_project_Internalname, "Columnheaderclass", edtavDeletegridlinegridlevel_project_Columnheaderclass, !bGXsfl_55_Refreshing);
         dynavEmployee_project__projectid_Columnheaderclass = "WWColumn";
         AssignProp("", false, dynavEmployee_project__projectid_Internalname, "Columnheaderclass", dynavEmployee_project__projectid_Columnheaderclass, !bGXsfl_55_Refreshing);
         edtavEmployee_project__projectname_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavEmployee_project__projectname_Internalname, "Columnheaderclass", edtavEmployee_project__projectname_Columnheaderclass, !bGXsfl_55_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E163Y2( )
      {
         /* Gridlevel_project_Load Routine */
         returnInSub = false;
         AV27GXV8 = 1;
         while ( AV27GXV8 <= AV7Employee.gxTpr_Project.Count )
         {
            AV7Employee.gxTpr_Project.CurrentItem = ((SdtEmployee_Project)AV7Employee.gxTpr_Project.Item(AV27GXV8));
            AV14LineDeleted = (bool)(((AV18EmployeeProjectDeleted.IndexOf((short)(AV7Employee.gxTpr_Project.IndexOf(AV7Employee.gxTpr_Project.CurrentItem)))>0)));
            dynavEmployee_project__projectid.Enabled = (((StringUtil.StrCmp(AV11TrnMode, "INS")==0)||(StringUtil.StrCmp(AV11TrnMode, "UPD")==0))&&(!AV14LineDeleted)&&StringUtil.Contains( AV7Employee.gxTpr_Project.CurrentItem.ToXml(false, true, "", ""), "<Mode>INS</Mode>") ? 1 : 0);
            AV8DeleteGridLineGridLevel_Project = "<i class=\"TrnGridDelete fa fa-times\"></i>";
            AssignAttri("", false, edtavDeletegridlinegridlevel_project_Internalname, AV8DeleteGridLineGridLevel_Project);
            if ( ( StringUtil.StrCmp(AV11TrnMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV11TrnMode, "UPD") == 0 ) )
            {
               edtavDeletegridlinegridlevel_project_Class = "Attribute";
            }
            else
            {
               edtavDeletegridlinegridlevel_project_Class = "Invisible";
            }
            edtavDeletegridlinegridlevel_project_Columnclass = (AV14LineDeleted ? "WWIconActionColumn WWColumnLineThrough WWColumnLineThroughFirstColumn" : "WWIconActionColumn");
            dynavEmployee_project__projectid_Columnclass = (AV14LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            edtavEmployee_project__projectname_Columnclass = (AV14LineDeleted ? "WWColumn WWColumnLineThrough" : "WWColumn");
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 55;
            }
            if ( ( subGridlevel_project_Islastpage == 1 ) || ( subGridlevel_project_Rows == 0 ) || ( ( GRIDLEVEL_PROJECT_nCurrentRecord >= GRIDLEVEL_PROJECT_nFirstRecordOnPage ) && ( GRIDLEVEL_PROJECT_nCurrentRecord < GRIDLEVEL_PROJECT_nFirstRecordOnPage + subGridlevel_project_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_552( ) ;
            }
            GRIDLEVEL_PROJECT_nEOF = (short)(((GRIDLEVEL_PROJECT_nCurrentRecord<GRIDLEVEL_PROJECT_nFirstRecordOnPage+subGridlevel_project_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDLEVEL_PROJECT_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDLEVEL_PROJECT_nEOF), 1, 0, ".", "")));
            GRIDLEVEL_PROJECT_nCurrentRecord = (long)(GRIDLEVEL_PROJECT_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_55_Refreshing )
            {
               DoAjaxLoad(55, Gridlevel_projectRow);
            }
            AV27GXV8 = (int)(AV27GXV8+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E113Y2( )
      {
         AV27GXV8 = (int)(nGXsfl_55_idx+GRIDLEVEL_PROJECT_nFirstRecordOnPage);
         if ( ( AV27GXV8 > 0 ) && ( AV7Employee.gxTpr_Project.Count >= AV27GXV8 ) )
         {
            AV7Employee.gxTpr_Project.CurrentItem = ((SdtEmployee_Project)AV7Employee.gxTpr_Project.Item(AV27GXV8));
         }
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV11TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S132 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) || AV13CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 )
               {
                  AV7Employee.Delete();
                  gx_BV55 = true;
               }
               else
               {
                  AV18EmployeeProjectDeleted.Sort("");
                  while ( AV18EmployeeProjectDeleted.Count > 0 )
                  {
                     AV7Employee.gxTpr_Project.RemoveItem((int)(AV18EmployeeProjectDeleted.GetNumeric(AV18EmployeeProjectDeleted.Count)));
                     gx_BV55 = true;
                     AV18EmployeeProjectDeleted.RemoveItem(AV18EmployeeProjectDeleted.Count);
                  }
                  AV7Employee.Save();
                  gx_BV55 = true;
               }
               if ( AV7Employee.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S142 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV10Messages = AV7Employee.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18EmployeeProjectDeleted", AV18EmployeeProjectDeleted);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Employee", AV7Employee);
         nGXsfl_55_bak_idx = nGXsfl_55_idx;
         gxgrGridlevel_project_refresh( subGridlevel_project_Rows, AV11TrnMode, AV7Employee, AV18EmployeeProjectDeleted, AV7Employee.gxTpr_Companyid, AV7Employee.gxTpr_Employeeismanager, AV7Employee.gxTpr_Employeeisactive, AV15EmployeeId) ;
         nGXsfl_55_idx = nGXsfl_55_bak_idx;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_552( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Messages", AV10Messages);
      }

      protected void E123Y2( )
      {
         AV27GXV8 = (int)(nGXsfl_55_idx+GRIDLEVEL_PROJECT_nFirstRecordOnPage);
         if ( ( AV27GXV8 > 0 ) && ( AV7Employee.gxTpr_Project.Count >= AV27GXV8 ) )
         {
            AV7Employee.gxTpr_Project.CurrentItem = ((SdtEmployee_Project)AV7Employee.gxTpr_Project.Item(AV27GXV8));
         }
         /* 'DoAddGridLineGridLevel_Project' Routine */
         returnInSub = false;
         AV16EmployeeProjectItem = new SdtEmployee_Project(context);
         AV7Employee.gxTpr_Project.Add(AV16EmployeeProjectItem, 0);
         gx_BV55 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Employee", AV7Employee);
         nGXsfl_55_bak_idx = nGXsfl_55_idx;
         gxgrGridlevel_project_refresh( subGridlevel_project_Rows, AV11TrnMode, AV7Employee, AV18EmployeeProjectDeleted, AV7Employee.gxTpr_Companyid, AV7Employee.gxTpr_Employeeismanager, AV7Employee.gxTpr_Employeeisactive, AV15EmployeeId) ;
         nGXsfl_55_idx = nGXsfl_55_bak_idx;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_552( ) ;
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E133Y2 ();
         if (returnInSub) return;
      }

      protected void E133Y2( )
      {
         AV27GXV8 = (int)(nGXsfl_55_idx+GRIDLEVEL_PROJECT_nFirstRecordOnPage);
         if ( ( AV27GXV8 > 0 ) && ( AV7Employee.gxTpr_Project.Count >= AV27GXV8 ) )
         {
            AV7Employee.gxTpr_Project.CurrentItem = ((SdtEmployee_Project)AV7Employee.gxTpr_Project.Item(AV27GXV8));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV11TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV11TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S132 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 ) || AV13CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV11TrnMode, "DLT") == 0 )
               {
                  AV7Employee.Delete();
                  gx_BV55 = true;
               }
               else
               {
                  AV18EmployeeProjectDeleted.Sort("");
                  while ( AV18EmployeeProjectDeleted.Count > 0 )
                  {
                     AV7Employee.gxTpr_Project.RemoveItem((int)(AV18EmployeeProjectDeleted.GetNumeric(AV18EmployeeProjectDeleted.Count)));
                     gx_BV55 = true;
                     AV18EmployeeProjectDeleted.RemoveItem(AV18EmployeeProjectDeleted.Count);
                  }
                  AV7Employee.Save();
                  gx_BV55 = true;
               }
               if ( AV7Employee.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S142 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV10Messages = AV7Employee.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18EmployeeProjectDeleted", AV18EmployeeProjectDeleted);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Employee", AV7Employee);
         nGXsfl_55_bak_idx = nGXsfl_55_idx;
         gxgrGridlevel_project_refresh( subGridlevel_project_Rows, AV11TrnMode, AV7Employee, AV18EmployeeProjectDeleted, AV7Employee.gxTpr_Companyid, AV7Employee.gxTpr_Employeeismanager, AV7Employee.gxTpr_Employeeisactive, AV15EmployeeId) ;
         nGXsfl_55_idx = nGXsfl_55_bak_idx;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_552( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Messages", AV10Messages);
      }

      protected void E173Y2( )
      {
         AV27GXV8 = (int)(nGXsfl_55_idx+GRIDLEVEL_PROJECT_nFirstRecordOnPage);
         if ( ( AV27GXV8 > 0 ) && ( AV7Employee.gxTpr_Project.Count >= AV27GXV8 ) )
         {
            AV7Employee.gxTpr_Project.CurrentItem = ((SdtEmployee_Project)AV7Employee.gxTpr_Project.Item(AV27GXV8));
         }
         /* Deletegridlinegridlevel_project_Click Routine */
         returnInSub = false;
         AV17Index = (short)(AV7Employee.gxTpr_Project.IndexOf(AV7Employee.gxTpr_Project.CurrentItem));
         if ( AV18EmployeeProjectDeleted.IndexOf(AV17Index) > 0 )
         {
            AV18EmployeeProjectDeleted.RemoveItem(AV18EmployeeProjectDeleted.IndexOf(AV17Index));
         }
         else
         {
            AV18EmployeeProjectDeleted.Add(AV17Index, 0);
         }
         gxgrGridlevel_project_refresh( subGridlevel_project_Rows, AV11TrnMode, AV7Employee, AV18EmployeeProjectDeleted, AV7Employee.gxTpr_Companyid, AV7Employee.gxTpr_Employeeismanager, AV7Employee.gxTpr_Employeeisactive, AV15EmployeeId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18EmployeeProjectDeleted", AV18EmployeeProjectDeleted);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV11TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV11TrnMode, "INS") == 0 ) || ( StringUtil.StrCmp(AV11TrnMode, "UPD") == 0 ) ) )
         {
            bttBtnaddgridlinegridlevel_project_Visible = 0;
            AssignProp("", false, bttBtnaddgridlinegridlevel_project_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnaddgridlinegridlevel_project_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV35GXV16 = 1;
         while ( AV35GXV16 <= AV10Messages.Count )
         {
            AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV10Messages.Item(AV35GXV16));
            GX_msglist.addItem(AV9Message.gxTpr_Description);
            AV35GXV16 = (int)(AV35GXV16+1);
         }
      }

      protected void S142( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("createemployee",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV13CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV13CheckRequiredFieldsResult", AV13CheckRequiredFieldsResult);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV11TrnMode", AV11TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV11TrnMode, "")), context));
         AV15EmployeeId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV15EmployeeId", StringUtil.LTrimStr( (decimal)(AV15EmployeeId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15EmployeeId), "ZZZZZZZZZ9"), context));
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
         PA3Y2( ) ;
         WS3Y2( ) ;
         WE3Y2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025626754382", true, true);
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
         context.AddJavascriptSource("createemployee.js", "?2025626754382", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_552( )
      {
         edtavDeletegridlinegridlevel_project_Internalname = "vDELETEGRIDLINEGRIDLEVEL_PROJECT_"+sGXsfl_55_idx;
         dynavEmployee_project__projectid_Internalname = "EMPLOYEE_PROJECT__PROJECTID_"+sGXsfl_55_idx;
         edtavEmployee_project__projectname_Internalname = "EMPLOYEE_PROJECT__PROJECTNAME_"+sGXsfl_55_idx;
      }

      protected void SubsflControlProps_fel_552( )
      {
         edtavDeletegridlinegridlevel_project_Internalname = "vDELETEGRIDLINEGRIDLEVEL_PROJECT_"+sGXsfl_55_fel_idx;
         dynavEmployee_project__projectid_Internalname = "EMPLOYEE_PROJECT__PROJECTID_"+sGXsfl_55_fel_idx;
         edtavEmployee_project__projectname_Internalname = "EMPLOYEE_PROJECT__PROJECTNAME_"+sGXsfl_55_fel_idx;
      }

      protected void sendrow_552( )
      {
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_552( ) ;
         WB3Y0( ) ;
         if ( ( subGridlevel_project_Rows * 1 == 0 ) || ( nGXsfl_55_idx <= subGridlevel_project_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridlevel_projectRow = GXWebRow.GetNew(context,Gridlevel_projectContainer);
            if ( subGridlevel_project_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridlevel_project_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
               {
                  subGridlevel_project_Linesclass = subGridlevel_project_Class+"Odd";
               }
            }
            else if ( subGridlevel_project_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridlevel_project_Backstyle = 0;
               subGridlevel_project_Backcolor = subGridlevel_project_Allbackcolor;
               if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
               {
                  subGridlevel_project_Linesclass = subGridlevel_project_Class+"Uniform";
               }
            }
            else if ( subGridlevel_project_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridlevel_project_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
               {
                  subGridlevel_project_Linesclass = subGridlevel_project_Class+"Odd";
               }
               subGridlevel_project_Backcolor = (int)(0x0);
            }
            else if ( subGridlevel_project_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridlevel_project_Backstyle = 1;
               if ( ((int)((nGXsfl_55_idx) % (2))) == 0 )
               {
                  subGridlevel_project_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
                  {
                     subGridlevel_project_Linesclass = subGridlevel_project_Class+"Even";
                  }
               }
               else
               {
                  subGridlevel_project_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
                  {
                     subGridlevel_project_Linesclass = subGridlevel_project_Class+"Odd";
                  }
               }
            }
            if ( Gridlevel_projectContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_55_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridlevel_projectContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_55_idx + "',55)\"";
            ROClassString = edtavDeletegridlinegridlevel_project_Class;
            Gridlevel_projectRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeletegridlinegridlevel_project_Internalname,StringUtil.RTrim( AV8DeleteGridLineGridLevel_Project),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"","'"+""+"'"+",false,"+"'"+"EVDELETEGRIDLINEGRIDLEVEL_PROJECT.CLICK."+sGXsfl_55_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDeletegridlinegridlevel_project_Jsonclick,(short)5,(string)edtavDeletegridlinegridlevel_project_Class,(string)"",(string)ROClassString,(string)edtavDeletegridlinegridlevel_project_Columnclass,(string)edtavDeletegridlinegridlevel_project_Columnheaderclass,(short)-1,(int)edtavDeletegridlinegridlevel_project_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)55,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            GXVEMPLOYEE_PROJECT__PROJECTID_html3Y2( ) ;
            /* Subfile cell */
            if ( Gridlevel_projectContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_55_idx + "',55)\"";
            GXCCtl = "EMPLOYEE_PROJECT__PROJECTID_" + sGXsfl_55_idx;
            dynavEmployee_project__projectid.Name = GXCCtl;
            dynavEmployee_project__projectid.WebTags = "";
            /* ComboBox */
            Gridlevel_projectRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavEmployee_project__projectid,(string)dynavEmployee_project__projectid_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(((SdtEmployee_Project)AV7Employee.gxTpr_Project.Item(AV27GXV8)).gxTpr_Projectid), 10, 0)),(short)1,(string)dynavEmployee_project__projectid_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynavEmployee_project__projectid.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)dynavEmployee_project__projectid_Columnclass,(string)dynavEmployee_project__projectid_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"",(bool)true,(short)0});
            dynavEmployee_project__projectid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(((SdtEmployee_Project)AV7Employee.gxTpr_Project.Item(AV27GXV8)).gxTpr_Projectid), 10, 0));
            AssignProp("", false, dynavEmployee_project__projectid_Internalname, "Values", (string)(dynavEmployee_project__projectid.ToJavascriptSource()), !bGXsfl_55_Refreshing);
            /* Subfile cell */
            if ( Gridlevel_projectContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_55_idx + "',55)\"";
            ROClassString = "Attribute";
            Gridlevel_projectRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavEmployee_project__projectname_Internalname,StringUtil.RTrim( ((SdtEmployee_Project)AV7Employee.gxTpr_Project.Item(AV27GXV8)).gxTpr_Projectname),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavEmployee_project__projectname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavEmployee_project__projectname_Columnclass,(string)edtavEmployee_project__projectname_Columnheaderclass,(short)-1,(int)edtavEmployee_project__projectname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)55,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes3Y2( ) ;
            Gridlevel_projectContainer.AddRow(Gridlevel_projectRow);
            nGXsfl_55_idx = ((subGridlevel_project_Islastpage==1)&&(nGXsfl_55_idx+1>subGridlevel_project_fnc_Recordsperpage( )) ? 1 : nGXsfl_55_idx+1);
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_552( ) ;
         }
         /* End function sendrow_552 */
      }

      protected void init_web_controls( )
      {
         dynavEmployee_companyid.Name = "EMPLOYEE_COMPANYID";
         dynavEmployee_companyid.WebTags = "";
         dynavEmployee_companyid.removeAllItems();
         /* Using cursor H003Y5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            dynavEmployee_companyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H003Y5_A100CompanyId[0]), 10, 0)), H003Y5_A101CompanyName[0], 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( dynavEmployee_companyid.ItemCount > 0 )
         {
            AV7Employee.gxTpr_Companyid = (long)(Math.Round(NumberUtil.Val( dynavEmployee_companyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Employee.gxTpr_Companyid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
         chkavEmployee_employeeismanager.Name = "EMPLOYEE_EMPLOYEEISMANAGER";
         chkavEmployee_employeeismanager.WebTags = "";
         chkavEmployee_employeeismanager.Caption = "Is Manager";
         AssignProp("", false, chkavEmployee_employeeismanager_Internalname, "TitleCaption", chkavEmployee_employeeismanager.Caption, true);
         chkavEmployee_employeeismanager.CheckedValue = "false";
         chkavEmployee_employeeisactive.Name = "EMPLOYEE_EMPLOYEEISACTIVE";
         chkavEmployee_employeeisactive.WebTags = "";
         chkavEmployee_employeeisactive.Caption = "Is Active";
         AssignProp("", false, chkavEmployee_employeeisactive_Internalname, "TitleCaption", chkavEmployee_employeeisactive.Caption, true);
         chkavEmployee_employeeisactive.CheckedValue = "false";
         GXCCtl = "EMPLOYEE_PROJECT__PROJECTID_" + sGXsfl_55_idx;
         dynavEmployee_project__projectid.Name = GXCCtl;
         dynavEmployee_project__projectid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl55( )
      {
         if ( Gridlevel_projectContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Gridlevel_projectContainer"+"DivS\" data-gxgridid=\"55\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridlevel_project_Internalname, subGridlevel_project_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridlevel_project_Backcolorstyle == 0 )
            {
               subGridlevel_project_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridlevel_project_Class) > 0 )
               {
                  subGridlevel_project_Linesclass = subGridlevel_project_Class+"Title";
               }
            }
            else
            {
               subGridlevel_project_Titlebackstyle = 1;
               if ( subGridlevel_project_Backcolorstyle == 1 )
               {
                  subGridlevel_project_Titlebackcolor = subGridlevel_project_Allbackcolor;
                  if ( StringUtil.Len( subGridlevel_project_Class) > 0 )
                  {
                     subGridlevel_project_Linesclass = subGridlevel_project_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridlevel_project_Class) > 0 )
                  {
                     subGridlevel_project_Linesclass = subGridlevel_project_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDeletegridlinegridlevel_project_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Project Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Project Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridlevel_projectContainer.AddObjectProperty("GridName", "Gridlevel_project");
         }
         else
         {
            Gridlevel_projectContainer.AddObjectProperty("GridName", "Gridlevel_project");
            Gridlevel_projectContainer.AddObjectProperty("Header", subGridlevel_project_Header);
            Gridlevel_projectContainer.AddObjectProperty("Class", "WorkWith");
            Gridlevel_projectContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridlevel_projectContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridlevel_projectContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Backcolorstyle), 1, 0, ".", "")));
            Gridlevel_projectContainer.AddObjectProperty("CmpContext", "");
            Gridlevel_projectContainer.AddObjectProperty("InMasterPage", "false");
            Gridlevel_projectColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_projectColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV8DeleteGridLineGridLevel_Project)));
            Gridlevel_projectColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavDeletegridlinegridlevel_project_Columnclass));
            Gridlevel_projectColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavDeletegridlinegridlevel_project_Columnheaderclass));
            Gridlevel_projectColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDeletegridlinegridlevel_project_Class));
            Gridlevel_projectColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeletegridlinegridlevel_project_Enabled), 5, 0, ".", "")));
            Gridlevel_projectContainer.AddColumnProperties(Gridlevel_projectColumn);
            Gridlevel_projectColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_projectColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( dynavEmployee_project__projectid_Columnclass));
            Gridlevel_projectColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( dynavEmployee_project__projectid_Columnheaderclass));
            Gridlevel_projectColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavEmployee_project__projectid.Enabled), 5, 0, ".", "")));
            Gridlevel_projectContainer.AddColumnProperties(Gridlevel_projectColumn);
            Gridlevel_projectColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridlevel_projectColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavEmployee_project__projectname_Columnclass));
            Gridlevel_projectColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavEmployee_project__projectname_Columnheaderclass));
            Gridlevel_projectColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavEmployee_project__projectname_Enabled), 5, 0, ".", "")));
            Gridlevel_projectContainer.AddColumnProperties(Gridlevel_projectColumn);
            Gridlevel_projectContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Selectedindex), 4, 0, ".", "")));
            Gridlevel_projectContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Allowselection), 1, 0, ".", "")));
            Gridlevel_projectContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Selectioncolor), 9, 0, ".", "")));
            Gridlevel_projectContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Allowhovering), 1, 0, ".", "")));
            Gridlevel_projectContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Hoveringcolor), 9, 0, ".", "")));
            Gridlevel_projectContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Allowcollapsing), 1, 0, ".", "")));
            Gridlevel_projectContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavEmployee_employeefirstname_Internalname = "EMPLOYEE_EMPLOYEEFIRSTNAME";
         edtavEmployee_employeelastname_Internalname = "EMPLOYEE_EMPLOYEELASTNAME";
         edtavEmployee_employeeemail_Internalname = "EMPLOYEE_EMPLOYEEEMAIL";
         dynavEmployee_companyid_Internalname = "EMPLOYEE_COMPANYID";
         chkavEmployee_employeeismanager_Internalname = "EMPLOYEE_EMPLOYEEISMANAGER";
         chkavEmployee_employeeisactive_Internalname = "EMPLOYEE_EMPLOYEEISACTIVE";
         edtavEmployee_employeevactiondays_Internalname = "EMPLOYEE_EMPLOYEEVACTIONDAYS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtavDeletegridlinegridlevel_project_Internalname = "vDELETEGRIDLINEGRIDLEVEL_PROJECT";
         dynavEmployee_project__projectid_Internalname = "EMPLOYEE_PROJECT__PROJECTID";
         edtavEmployee_project__projectname_Internalname = "EMPLOYEE_PROJECT__PROJECTNAME";
         bttBtnaddgridlinegridlevel_project_Internalname = "BTNADDGRIDLINEGRIDLEVEL_PROJECT";
         divTableleaflevel_project_Internalname = "TABLELEAFLEVEL_PROJECT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
         divTablemain_Internalname = "TABLEMAIN";
         edtavEmployee_employeeid_Internalname = "EMPLOYEE_EMPLOYEEID";
         edtavEmployee_employeename_Internalname = "EMPLOYEE_EMPLOYEENAME";
         edtavEmployee_companyname_Internalname = "EMPLOYEE_COMPANYNAME";
         edtavEmployee_gamuserguid_Internalname = "EMPLOYEE_GAMUSERGUID";
         edtavEmployee_employeebalance_Internalname = "EMPLOYEE_EMPLOYEEBALANCE";
         Gridlevel_project_empowerer_Internalname = "GRIDLEVEL_PROJECT_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_project_Internalname = "GRIDLEVEL_PROJECT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_project_Allowcollapsing = 0;
         subGridlevel_project_Allowselection = 0;
         subGridlevel_project_Header = "";
         chkavEmployee_employeeisactive.Caption = "Is Active";
         chkavEmployee_employeeismanager.Caption = "Is Manager";
         edtavEmployee_project__projectname_Jsonclick = "";
         edtavEmployee_project__projectname_Columnheaderclass = "";
         edtavEmployee_project__projectname_Columnclass = "WWColumn";
         edtavEmployee_project__projectname_Enabled = 0;
         dynavEmployee_project__projectid_Jsonclick = "";
         dynavEmployee_project__projectid.Enabled = 1;
         dynavEmployee_project__projectid_Columnheaderclass = "";
         dynavEmployee_project__projectid_Columnclass = "WWColumn";
         edtavDeletegridlinegridlevel_project_Jsonclick = "";
         edtavDeletegridlinegridlevel_project_Columnclass = "WWIconActionColumn";
         edtavDeletegridlinegridlevel_project_Class = "Attribute";
         edtavDeletegridlinegridlevel_project_Enabled = 1;
         subGridlevel_project_Class = "WorkWith";
         subGridlevel_project_Backcolorstyle = 0;
         edtavDeletegridlinegridlevel_project_Columnheaderclass = "";
         edtavEmployee_employeevactiondays_Enabled = 1;
         chkavEmployee_employeeisactive.Enabled = 1;
         chkavEmployee_employeeismanager.Enabled = 1;
         dynavEmployee_companyid.Enabled = 1;
         edtavEmployee_employeeemail_Enabled = 1;
         edtavEmployee_employeelastname_Enabled = 1;
         edtavEmployee_employeefirstname_Enabled = 1;
         edtavEmployee_project__projectname_Enabled = -1;
         edtavEmployee_employeebalance_Jsonclick = "";
         edtavEmployee_employeebalance_Visible = 1;
         edtavEmployee_gamuserguid_Jsonclick = "";
         edtavEmployee_gamuserguid_Visible = 1;
         edtavEmployee_companyname_Jsonclick = "";
         edtavEmployee_companyname_Visible = 1;
         edtavEmployee_employeename_Jsonclick = "";
         edtavEmployee_employeename_Visible = 1;
         edtavEmployee_employeeid_Jsonclick = "";
         edtavEmployee_employeeid_Visible = 1;
         bttBtnenter_Visible = 1;
         bttBtnaddgridlinegridlevel_project_Visible = 1;
         edtavEmployee_employeevactiondays_Jsonclick = "";
         edtavEmployee_employeevactiondays_Enabled = 1;
         chkavEmployee_employeeisactive.Enabled = 1;
         chkavEmployee_employeeismanager.Enabled = 1;
         dynavEmployee_companyid_Jsonclick = "";
         dynavEmployee_companyid.Enabled = 1;
         edtavEmployee_employeeemail_Jsonclick = "";
         edtavEmployee_employeeemail_Enabled = 1;
         edtavEmployee_employeelastname_Jsonclick = "";
         edtavEmployee_employeelastname_Enabled = 1;
         edtavEmployee_employeefirstname_Jsonclick = "";
         edtavEmployee_employeefirstname_Enabled = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "General Information";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Create Employee";
         subGridlevel_project_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"GRIDLEVEL_PROJECT_nEOF"},{"av":"subGridlevel_project_Rows","ctrl":"GRIDLEVEL_PROJECT","prop":"Rows"},{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"dynavEmployee_companyid"},{"av":"GXV4","fld":"EMPLOYEE_COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"GXV5","fld":"EMPLOYEE_EMPLOYEEISMANAGER"},{"av":"GXV6","fld":"EMPLOYEE_EMPLOYEEISACTIVE"},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV15EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"edtavDeletegridlinegridlevel_project_Columnheaderclass","ctrl":"vDELETEGRIDLINEGRIDLEVEL_PROJECT","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTID","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTNAME","prop":"Columnheaderclass"},{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNADDGRIDLINEGRIDLEVEL_PROJECT","prop":"Visible"}]}""");
         setEventMetadata("GRIDLEVEL_PROJECT.LOAD","""{"handler":"E163Y2","iparms":[{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true}]""");
         setEventMetadata("GRIDLEVEL_PROJECT.LOAD",""","oparms":[{"ctrl":"EMPLOYEE_PROJECT__PROJECTID","prop":"Enabled"},{"av":"AV8DeleteGridLineGridLevel_Project","fld":"vDELETEGRIDLINEGRIDLEVEL_PROJECT"},{"av":"edtavDeletegridlinegridlevel_project_Class","ctrl":"vDELETEGRIDLINEGRIDLEVEL_PROJECT","prop":"Class"},{"av":"edtavDeletegridlinegridlevel_project_Columnclass","ctrl":"vDELETEGRIDLINEGRIDLEVEL_PROJECT","prop":"Columnclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTID","prop":"Columnclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTNAME","prop":"Columnclass"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E113Y2","iparms":[{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV13CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"AV10Messages","fld":"vMESSAGES"},{"av":"GRIDLEVEL_PROJECT_nEOF"},{"av":"subGridlevel_project_Rows","ctrl":"GRIDLEVEL_PROJECT","prop":"Rows"},{"av":"dynavEmployee_companyid"},{"av":"GXV4","fld":"EMPLOYEE_COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"GXV5","fld":"EMPLOYEE_EMPLOYEEISMANAGER"},{"av":"GXV6","fld":"EMPLOYEE_EMPLOYEEISACTIVE"},{"av":"AV15EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOUSERACTION1'",""","oparms":[{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV10Messages","fld":"vMESSAGES"},{"av":"AV13CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("'DOADDGRIDLINEGRIDLEVEL_PROJECT'","""{"handler":"E123Y2","iparms":[{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"GRIDLEVEL_PROJECT_nEOF"},{"av":"subGridlevel_project_Rows","ctrl":"GRIDLEVEL_PROJECT","prop":"Rows"},{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"dynavEmployee_companyid"},{"av":"GXV4","fld":"EMPLOYEE_COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"GXV5","fld":"EMPLOYEE_EMPLOYEEISMANAGER"},{"av":"GXV6","fld":"EMPLOYEE_EMPLOYEEISACTIVE"},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV15EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("'DOADDGRIDLINEGRIDLEVEL_PROJECT'",""","oparms":[{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55}]}""");
         setEventMetadata("ENTER","""{"handler":"E133Y2","iparms":[{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV13CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"AV10Messages","fld":"vMESSAGES"},{"av":"GRIDLEVEL_PROJECT_nEOF"},{"av":"subGridlevel_project_Rows","ctrl":"GRIDLEVEL_PROJECT","prop":"Rows"},{"av":"dynavEmployee_companyid"},{"av":"GXV4","fld":"EMPLOYEE_COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"GXV5","fld":"EMPLOYEE_EMPLOYEEISMANAGER"},{"av":"GXV6","fld":"EMPLOYEE_EMPLOYEEISACTIVE"},{"av":"AV15EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV10Messages","fld":"vMESSAGES"},{"av":"AV13CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VDELETEGRIDLINEGRIDLEVEL_PROJECT.CLICK","""{"handler":"E173Y2","iparms":[{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"GRIDLEVEL_PROJECT_nEOF"},{"av":"subGridlevel_project_Rows","ctrl":"GRIDLEVEL_PROJECT","prop":"Rows"},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"dynavEmployee_companyid"},{"av":"GXV4","fld":"EMPLOYEE_COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"GXV5","fld":"EMPLOYEE_EMPLOYEEISMANAGER"},{"av":"GXV6","fld":"EMPLOYEE_EMPLOYEEISACTIVE"},{"av":"AV15EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VDELETEGRIDLINEGRIDLEVEL_PROJECT.CLICK",""","oparms":[{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"edtavDeletegridlinegridlevel_project_Columnheaderclass","ctrl":"vDELETEGRIDLINEGRIDLEVEL_PROJECT","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTID","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTNAME","prop":"Columnheaderclass"},{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNADDGRIDLINEGRIDLEVEL_PROJECT","prop":"Visible"}]}""");
         setEventMetadata("GRIDLEVEL_PROJECT_FIRSTPAGE","""{"handler":"subgridlevel_project_firstpage","iparms":[{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"GRIDLEVEL_PROJECT_nEOF"},{"av":"subGridlevel_project_Rows","ctrl":"GRIDLEVEL_PROJECT","prop":"Rows"},{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"AV15EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"dynavEmployee_companyid"},{"av":"GXV4","fld":"EMPLOYEE_COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"GXV5","fld":"EMPLOYEE_EMPLOYEEISMANAGER"},{"av":"GXV6","fld":"EMPLOYEE_EMPLOYEEISACTIVE"}]""");
         setEventMetadata("GRIDLEVEL_PROJECT_FIRSTPAGE",""","oparms":[{"av":"edtavDeletegridlinegridlevel_project_Columnheaderclass","ctrl":"vDELETEGRIDLINEGRIDLEVEL_PROJECT","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTID","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTNAME","prop":"Columnheaderclass"},{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNADDGRIDLINEGRIDLEVEL_PROJECT","prop":"Visible"}]}""");
         setEventMetadata("GRIDLEVEL_PROJECT_PREVPAGE","""{"handler":"subgridlevel_project_previouspage","iparms":[{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"GRIDLEVEL_PROJECT_nEOF"},{"av":"subGridlevel_project_Rows","ctrl":"GRIDLEVEL_PROJECT","prop":"Rows"},{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"AV15EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"dynavEmployee_companyid"},{"av":"GXV4","fld":"EMPLOYEE_COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"GXV5","fld":"EMPLOYEE_EMPLOYEEISMANAGER"},{"av":"GXV6","fld":"EMPLOYEE_EMPLOYEEISACTIVE"}]""");
         setEventMetadata("GRIDLEVEL_PROJECT_PREVPAGE",""","oparms":[{"av":"edtavDeletegridlinegridlevel_project_Columnheaderclass","ctrl":"vDELETEGRIDLINEGRIDLEVEL_PROJECT","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTID","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTNAME","prop":"Columnheaderclass"},{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNADDGRIDLINEGRIDLEVEL_PROJECT","prop":"Visible"}]}""");
         setEventMetadata("GRIDLEVEL_PROJECT_NEXTPAGE","""{"handler":"subgridlevel_project_nextpage","iparms":[{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"GRIDLEVEL_PROJECT_nEOF"},{"av":"subGridlevel_project_Rows","ctrl":"GRIDLEVEL_PROJECT","prop":"Rows"},{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"AV15EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"dynavEmployee_companyid"},{"av":"GXV4","fld":"EMPLOYEE_COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"GXV5","fld":"EMPLOYEE_EMPLOYEEISMANAGER"},{"av":"GXV6","fld":"EMPLOYEE_EMPLOYEEISACTIVE"}]""");
         setEventMetadata("GRIDLEVEL_PROJECT_NEXTPAGE",""","oparms":[{"av":"edtavDeletegridlinegridlevel_project_Columnheaderclass","ctrl":"vDELETEGRIDLINEGRIDLEVEL_PROJECT","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTID","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTNAME","prop":"Columnheaderclass"},{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNADDGRIDLINEGRIDLEVEL_PROJECT","prop":"Visible"}]}""");
         setEventMetadata("GRIDLEVEL_PROJECT_LASTPAGE","""{"handler":"subgridlevel_project_lastpage","iparms":[{"av":"GRIDLEVEL_PROJECT_nFirstRecordOnPage"},{"av":"GRIDLEVEL_PROJECT_nEOF"},{"av":"subGridlevel_project_Rows","ctrl":"GRIDLEVEL_PROJECT","prop":"Rows"},{"av":"AV7Employee","fld":"vEMPLOYEE"},{"av":"nRC_GXsfl_55","ctrl":"GRIDLEVEL_PROJECT","prop":"GridRC","grid":55},{"av":"AV18EmployeeProjectDeleted","fld":"vEMPLOYEEPROJECTDELETED"},{"av":"AV15EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"AV11TrnMode","fld":"vTRNMODE","hsh":true},{"av":"dynavEmployee_companyid"},{"av":"GXV4","fld":"EMPLOYEE_COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"GXV5","fld":"EMPLOYEE_EMPLOYEEISMANAGER"},{"av":"GXV6","fld":"EMPLOYEE_EMPLOYEEISACTIVE"}]""");
         setEventMetadata("GRIDLEVEL_PROJECT_LASTPAGE",""","oparms":[{"av":"edtavDeletegridlinegridlevel_project_Columnheaderclass","ctrl":"vDELETEGRIDLINEGRIDLEVEL_PROJECT","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTID","prop":"Columnheaderclass"},{"ctrl":"EMPLOYEE_PROJECT__PROJECTNAME","prop":"Columnheaderclass"},{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNADDGRIDLINEGRIDLEVEL_PROJECT","prop":"Visible"}]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv10","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7Employee = new SdtEmployee(context);
         AV18EmployeeProjectDeleted = new GxSimpleCollection<short>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV10Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Gridlevel_project_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         Gridlevel_projectContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtnaddgridlinegridlevel_project_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         bttBtnuseraction1_Jsonclick = "";
         ucGridlevel_project_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8DeleteGridLineGridLevel_Project = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H003Y2_A100CompanyId = new long[1] ;
         H003Y2_A101CompanyName = new string[] {""} ;
         H003Y3_A102ProjectId = new long[1] ;
         H003Y3_A103ProjectName = new string[] {""} ;
         H003Y4_A100CompanyId = new long[1] ;
         H003Y4_A101CompanyName = new string[] {""} ;
         Gridlevel_projectRow = new GXWebRow();
         AV16EmployeeProjectItem = new SdtEmployee_Project(context);
         AV9Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridlevel_project_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         H003Y5_A100CompanyId = new long[1] ;
         H003Y5_A101CompanyName = new string[] {""} ;
         Gridlevel_projectColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.createemployee__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.createemployee__default(),
            new Object[][] {
                new Object[] {
               H003Y2_A100CompanyId, H003Y2_A101CompanyName
               }
               , new Object[] {
               H003Y3_A102ProjectId, H003Y3_A103ProjectName
               }
               , new Object[] {
               H003Y4_A100CompanyId, H003Y4_A101CompanyName
               }
               , new Object[] {
               H003Y5_A100CompanyId, H003Y5_A101CompanyName
               }
            }
         );
         /* GeneXus formulas. */
         edtavDeletegridlinegridlevel_project_Enabled = 0;
         edtavEmployee_project__projectname_Enabled = 0;
      }

      private short GRIDLEVEL_PROJECT_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridlevel_project_Backcolorstyle ;
      private short AV17Index ;
      private short nGXWrapped ;
      private short subGridlevel_project_Backstyle ;
      private short subGridlevel_project_Titlebackstyle ;
      private short subGridlevel_project_Allowselection ;
      private short subGridlevel_project_Allowhovering ;
      private short subGridlevel_project_Allowcollapsing ;
      private short subGridlevel_project_Collapsed ;
      private int nRC_GXsfl_55 ;
      private int subGridlevel_project_Rows ;
      private int nGXsfl_55_idx=1 ;
      private int edtavEmployee_employeefirstname_Enabled ;
      private int edtavEmployee_employeelastname_Enabled ;
      private int edtavEmployee_employeeemail_Enabled ;
      private int edtavEmployee_employeevactiondays_Enabled ;
      private int AV27GXV8 ;
      private int bttBtnaddgridlinegridlevel_project_Visible ;
      private int bttBtnenter_Visible ;
      private int edtavEmployee_employeeid_Visible ;
      private int edtavEmployee_employeename_Visible ;
      private int edtavEmployee_companyname_Visible ;
      private int edtavEmployee_gamuserguid_Visible ;
      private int edtavEmployee_employeebalance_Visible ;
      private int gxdynajaxindex ;
      private int subGridlevel_project_Islastpage ;
      private int edtavDeletegridlinegridlevel_project_Enabled ;
      private int edtavEmployee_project__projectname_Enabled ;
      private int GRIDLEVEL_PROJECT_nGridOutOfScope ;
      private int nGXsfl_55_fel_idx=1 ;
      private int nGXsfl_55_bak_idx=1 ;
      private int AV35GXV16 ;
      private int idxLst ;
      private int subGridlevel_project_Backcolor ;
      private int subGridlevel_project_Allbackcolor ;
      private int subGridlevel_project_Titlebackcolor ;
      private int subGridlevel_project_Selectedindex ;
      private int subGridlevel_project_Selectioncolor ;
      private int subGridlevel_project_Hoveringcolor ;
      private long AV15EmployeeId ;
      private long wcpOAV15EmployeeId ;
      private long GRIDLEVEL_PROJECT_nFirstRecordOnPage ;
      private long GRIDLEVEL_PROJECT_nCurrentRecord ;
      private long GRIDLEVEL_PROJECT_nRecordCount ;
      private string AV11TrnMode ;
      private string wcpOAV11TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_55_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Gridlevel_project_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavEmployee_employeefirstname_Internalname ;
      private string TempTags ;
      private string edtavEmployee_employeefirstname_Jsonclick ;
      private string edtavEmployee_employeelastname_Internalname ;
      private string edtavEmployee_employeelastname_Jsonclick ;
      private string edtavEmployee_employeeemail_Internalname ;
      private string edtavEmployee_employeeemail_Jsonclick ;
      private string dynavEmployee_companyid_Internalname ;
      private string dynavEmployee_companyid_Jsonclick ;
      private string chkavEmployee_employeeismanager_Internalname ;
      private string chkavEmployee_employeeisactive_Internalname ;
      private string edtavEmployee_employeevactiondays_Internalname ;
      private string edtavEmployee_employeevactiondays_Jsonclick ;
      private string divTableleaflevel_project_Internalname ;
      private string sStyleString ;
      private string subGridlevel_project_Internalname ;
      private string bttBtnaddgridlinegridlevel_project_Internalname ;
      private string bttBtnaddgridlinegridlevel_project_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavEmployee_employeeid_Internalname ;
      private string edtavEmployee_employeeid_Jsonclick ;
      private string edtavEmployee_employeename_Internalname ;
      private string edtavEmployee_employeename_Jsonclick ;
      private string edtavEmployee_companyname_Internalname ;
      private string edtavEmployee_companyname_Jsonclick ;
      private string edtavEmployee_gamuserguid_Internalname ;
      private string edtavEmployee_gamuserguid_Jsonclick ;
      private string edtavEmployee_employeebalance_Internalname ;
      private string edtavEmployee_employeebalance_Jsonclick ;
      private string Gridlevel_project_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV8DeleteGridLineGridLevel_Project ;
      private string edtavDeletegridlinegridlevel_project_Internalname ;
      private string gxwrpcisep ;
      private string sGXsfl_55_fel_idx="0001" ;
      private string edtavDeletegridlinegridlevel_project_Columnheaderclass ;
      private string dynavEmployee_project__projectid_Columnheaderclass ;
      private string dynavEmployee_project__projectid_Internalname ;
      private string edtavEmployee_project__projectname_Columnheaderclass ;
      private string edtavEmployee_project__projectname_Internalname ;
      private string edtavDeletegridlinegridlevel_project_Class ;
      private string edtavDeletegridlinegridlevel_project_Columnclass ;
      private string dynavEmployee_project__projectid_Columnclass ;
      private string edtavEmployee_project__projectname_Columnclass ;
      private string subGridlevel_project_Class ;
      private string subGridlevel_project_Linesclass ;
      private string ROClassString ;
      private string edtavDeletegridlinegridlevel_project_Jsonclick ;
      private string GXCCtl ;
      private string dynavEmployee_project__projectid_Jsonclick ;
      private string edtavEmployee_project__projectname_Jsonclick ;
      private string subGridlevel_project_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13CheckRequiredFieldsResult ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_55_Refreshing=false ;
      private bool returnInSub ;
      private bool AV12LoadSuccess ;
      private bool gx_BV55 ;
      private bool gx_refresh_fired ;
      private bool AV14LineDeleted ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Gridlevel_projectContainer ;
      private GXWebRow Gridlevel_projectRow ;
      private GXWebColumn Gridlevel_projectColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucGridlevel_project_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavEmployee_companyid ;
      private GXCheckbox chkavEmployee_employeeismanager ;
      private GXCheckbox chkavEmployee_employeeisactive ;
      private GXCombobox dynavEmployee_project__projectid ;
      private SdtEmployee AV7Employee ;
      private GxSimpleCollection<short> AV18EmployeeProjectDeleted ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10Messages ;
      private IDataStoreProvider pr_default ;
      private long[] H003Y2_A100CompanyId ;
      private string[] H003Y2_A101CompanyName ;
      private long[] H003Y3_A102ProjectId ;
      private string[] H003Y3_A103ProjectName ;
      private long[] H003Y4_A100CompanyId ;
      private string[] H003Y4_A101CompanyName ;
      private SdtEmployee_Project AV16EmployeeProjectItem ;
      private GeneXus.Utils.SdtMessages_Message AV9Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H003Y5_A100CompanyId ;
      private string[] H003Y5_A101CompanyName ;
      private IDataStoreProvider pr_gam ;
   }

   public class createemployee__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class createemployee__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH003Y2;
        prmH003Y2 = new Object[] {
        };
        Object[] prmH003Y3;
        prmH003Y3 = new Object[] {
        };
        Object[] prmH003Y4;
        prmH003Y4 = new Object[] {
        };
        Object[] prmH003Y5;
        prmH003Y5 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H003Y2", "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H003Y3", "SELECT ProjectId, ProjectName FROM Project ORDER BY ProjectName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y3,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H003Y4", "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y4,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H003Y5", "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y5,0, GxCacheFrequency.OFF ,true,false )
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
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
     }
  }

}

}
