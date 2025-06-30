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
   public class leavecalendarold : GXDataArea
   {
      public leavecalendarold( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leavecalendarold( IGxContext context )
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
         dynavCompanylocationid = new GXCombobox();
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
            return "leavecalendar_Execute" ;
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
         PA3I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3I2( ) ;
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
         context.AddJavascriptSource("GXScheduler/dhtmlxscheduler.js", "", false, true);
         context.AddJavascriptSource("GXScheduler/GXSchedulerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leavecalendarold.aspx") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCURRENTEVENT", AV7currentEvent);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCURRENTEVENT", AV7currentEvent);
         }
         GxWebStd.gx_hidden_field( context, "vINITIALDATE", context.localUtil.DToC( AV8initialDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Autoload", StringUtil.RTrim( Gxscheduler_Autoload));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Loadeventsobject", StringUtil.RTrim( Gxscheduler_Loadeventsobject));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Detailsformobject", StringUtil.RTrim( Gxscheduler_Detailsformobject));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_View", StringUtil.RTrim( Gxscheduler_View));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Theme", StringUtil.RTrim( Gxscheduler_Theme));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Displayweektab", StringUtil.RTrim( Gxscheduler_Displayweektab));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Displaydaytab", StringUtil.RTrim( Gxscheduler_Displaydaytab));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Displaynavigationbuttons", StringUtil.RTrim( Gxscheduler_Displaynavigationbuttons));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Montheventsview", StringUtil.RTrim( Gxscheduler_Montheventsview));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Readonly", StringUtil.RTrim( Gxscheduler_Readonly));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Detailsoncreate", StringUtil.RTrim( Gxscheduler_Detailsoncreate));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Detailsondblclick", StringUtil.RTrim( Gxscheduler_Detailsondblclick));
         GxWebStd.gx_hidden_field( context, "GXSCHEDULER_Openlinknewwindow", StringUtil.RTrim( Gxscheduler_Openlinknewwindow));
         GxWebStd.gx_hidden_field( context, "vCURRENTEVENT_Id", StringUtil.RTrim( AV7currentEvent.gxTpr_Id));
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
            WE3I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3I2( ) ;
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
         return formatLink("leavecalendarold.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "LeaveCalendarOld" ;
      }

      public override string GetPgmdesc( )
      {
         return "Leave Calendar Old" ;
      }

      protected void WB3I0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, divUnnamedtable1_Visible, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCompanylocationid_cell_Internalname, 1, 0, "px", 0, "px", divCompanylocationid_cell_Class, "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablecompanylocationid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcompanylocationid_Internalname, "Location", "", "", lblTextblockcompanylocationid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_LeaveCalendarOld.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCompanylocationid_Internalname, "Company Location Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCompanylocationid, dynavCompanylocationid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10CompanyLocationId), 10, 0)), 1, dynavCompanylocationid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavCompanylocationid.Visible, dynavCompanylocationid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_LeaveCalendarOld.htm");
            dynavCompanylocationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10CompanyLocationId), 10, 0));
            AssignProp("", false, dynavCompanylocationid_Internalname, "Values", (string)(dynavCompanylocationid.ToJavascriptSource()), true);
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
            ucGxscheduler.SetProperty("AutoLoad", Gxscheduler_Autoload);
            ucGxscheduler.SetProperty("LoadEventsObject", Gxscheduler_Loadeventsobject);
            ucGxscheduler.SetProperty("DetailsFormObject", Gxscheduler_Detailsformobject);
            ucGxscheduler.SetProperty("View", Gxscheduler_View);
            ucGxscheduler.SetProperty("Theme", Gxscheduler_Theme);
            ucGxscheduler.SetProperty("DisplayWeekTab", Gxscheduler_Displayweektab);
            ucGxscheduler.SetProperty("DisplayDayTab", Gxscheduler_Displaydaytab);
            ucGxscheduler.SetProperty("DisplayNavigationButtons", Gxscheduler_Displaynavigationbuttons);
            ucGxscheduler.SetProperty("MonthEventsView", Gxscheduler_Montheventsview);
            ucGxscheduler.SetProperty("ReadOnly", Gxscheduler_Readonly);
            ucGxscheduler.SetProperty("DetailsOnCreate", Gxscheduler_Detailsoncreate);
            ucGxscheduler.SetProperty("DetailsOnDblClick", Gxscheduler_Detailsondblclick);
            ucGxscheduler.SetProperty("OpenLinkNewWindow", Gxscheduler_Openlinknewwindow);
            ucGxscheduler.SetProperty("CurrentEvent", AV7currentEvent);
            ucGxscheduler.SetProperty("InitialDate", AV8initialDate);
            ucGxscheduler.Render(context, "gxscheduler", Gxscheduler_Internalname, "GXSCHEDULERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3I2( )
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
         Form.Meta.addItem("description", "Leave Calendar Old", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3I0( ) ;
      }

      protected void WS3I2( )
      {
         START3I2( ) ;
         EVT3I2( ) ;
      }

      protected void EVT3I2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GXSCHEDULER.EVENTSELECTED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gxscheduler.Eventselected */
                              E113I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E123I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCOMPANYLOCATIONID.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E133I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E143I2 ();
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

      protected void WE3I2( )
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

      protected void PA3I2( )
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
               GX_FocusControl = dynavCompanylocationid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvCOMPANYLOCATIONID3I1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCOMPANYLOCATIONID_data3I1( ) ;
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

      protected void GXVvCOMPANYLOCATIONID_html3I1( )
      {
         long gxdynajaxvalue;
         GXDLVvCOMPANYLOCATIONID_data3I1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCompanylocationid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavCompanylocationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavCompanylocationid.ItemCount > 0 )
         {
            AV10CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV10CompanyLocationId), 10, 0));
         }
      }

      protected void GXDLVvCOMPANYLOCATIONID_data3I1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H003I2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H003I2_A157CompanyLocationId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H003I2_A158CompanyLocationName[0]));
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
            dynavCompanylocationid.Name = "vCOMPANYLOCATIONID";
            dynavCompanylocationid.WebTags = "";
            dynavCompanylocationid.removeAllItems();
            /* Using cursor H003I3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynavCompanylocationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H003I3_A157CompanyLocationId[0]), 10, 0)), H003I3_A158CompanyLocationName[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynavCompanylocationid.ItemCount > 0 )
            {
               AV10CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV10CompanyLocationId), 10, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavCompanylocationid.ItemCount > 0 )
         {
            AV10CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV10CompanyLocationId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCompanylocationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10CompanyLocationId), 10, 0));
            AssignProp("", false, dynavCompanylocationid_Internalname, "Values", dynavCompanylocationid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF3I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E143I2 ();
            WB3I0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3I2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E123I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vCURRENTEVENT"), AV7currentEvent);
            /* Read saved values. */
            AV8initialDate = context.localUtil.CToD( cgiGet( "vINITIALDATE"), 0);
            Gxscheduler_Autoload = cgiGet( "GXSCHEDULER_Autoload");
            Gxscheduler_Loadeventsobject = cgiGet( "GXSCHEDULER_Loadeventsobject");
            Gxscheduler_Detailsformobject = cgiGet( "GXSCHEDULER_Detailsformobject");
            Gxscheduler_View = cgiGet( "GXSCHEDULER_View");
            Gxscheduler_Theme = cgiGet( "GXSCHEDULER_Theme");
            Gxscheduler_Displayweektab = cgiGet( "GXSCHEDULER_Displayweektab");
            Gxscheduler_Displaydaytab = cgiGet( "GXSCHEDULER_Displaydaytab");
            Gxscheduler_Displaynavigationbuttons = cgiGet( "GXSCHEDULER_Displaynavigationbuttons");
            Gxscheduler_Montheventsview = cgiGet( "GXSCHEDULER_Montheventsview");
            Gxscheduler_Readonly = cgiGet( "GXSCHEDULER_Readonly");
            Gxscheduler_Detailsoncreate = cgiGet( "GXSCHEDULER_Detailsoncreate");
            Gxscheduler_Detailsondblclick = cgiGet( "GXSCHEDULER_Detailsondblclick");
            Gxscheduler_Openlinknewwindow = cgiGet( "GXSCHEDULER_Openlinknewwindow");
            /* Read variables values. */
            dynavCompanylocationid.CurrentValue = cgiGet( dynavCompanylocationid_Internalname);
            AV10CompanyLocationId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavCompanylocationid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV10CompanyLocationId), 10, 0));
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
         E123I2 ();
         if (returnInSub) return;
      }

      protected void E123I2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_int1 = AV15CompanyId;
         new getloggedinusercompanyid(context ).execute( out  GXt_int1) ;
         AV15CompanyId = GXt_int1;
         AssignAttri("", false, "AV15CompanyId", StringUtil.LTrimStr( (decimal)(AV15CompanyId), 10, 0));
         if ( ! (0==AV15CompanyId) )
         {
            /* Using cursor H003I4 */
            pr_default.execute(2, new Object[] {AV15CompanyId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A100CompanyId = H003I4_A100CompanyId[0];
               A157CompanyLocationId = H003I4_A157CompanyLocationId[0];
               AV10CompanyLocationId = A157CompanyLocationId;
               AssignAttri("", false, "AV10CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV10CompanyLocationId), 10, 0));
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            dynavCompanylocationid.Enabled = 0;
            AssignProp("", false, dynavCompanylocationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavCompanylocationid.Enabled), 5, 0), true);
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         AV12Session.Set("LeaveCalendarCompanyLocationId", StringUtil.Str( (decimal)(AV10CompanyLocationId), 10, 0));
         this.executeUsercontrolMethod("", false, "GXSCHEDULERContainer", "Refresh", "", new Object[] {});
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( (0==AV15CompanyId) ) ) )
         {
            dynavCompanylocationid.Visible = 0;
            AssignProp("", false, dynavCompanylocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavCompanylocationid.Visible), 5, 0), true);
            divCompanylocationid_cell_Class = "Invisible";
            AssignProp("", false, divCompanylocationid_cell_Internalname, "Class", divCompanylocationid_cell_Class, true);
         }
         else
         {
            dynavCompanylocationid.Visible = 1;
            AssignProp("", false, dynavCompanylocationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavCompanylocationid.Visible), 5, 0), true);
            divCompanylocationid_cell_Class = "DscTop";
            AssignProp("", false, divCompanylocationid_cell_Internalname, "Class", divCompanylocationid_cell_Class, true);
         }
         if ( dynavCompanylocationid.Visible == 0 )
         {
            divUnnamedtable1_Visible = 0;
            AssignProp("", false, divUnnamedtable1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable1_Visible), 5, 0), true);
         }
      }

      protected void E133I2( )
      {
         /* Companylocationid_Controlvaluechanged Routine */
         returnInSub = false;
         AV12Session.Set("LeaveCalendarCompanyLocationId", StringUtil.Str( (decimal)(AV10CompanyLocationId), 10, 0));
         this.executeUsercontrolMethod("", false, "GXSCHEDULERContainer", "Refresh", "", new Object[] {});
      }

      protected void E113I2( )
      {
         /* Gxscheduler_Eventselected Routine */
         returnInSub = false;
         AV9websession.Set("currentevent", AV7currentEvent.gxTpr_Id);
      }

      protected void nextLoad( )
      {
      }

      protected void E143I2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA3I2( ) ;
         WS3I2( ) ;
         WE3I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025627738372", true, true);
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
         context.AddJavascriptSource("leavecalendarold.js", "?2025627738372", false, true);
         context.AddJavascriptSource("GXScheduler/dhtmlxscheduler.js", "", false, true);
         context.AddJavascriptSource("GXScheduler/GXSchedulerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavCompanylocationid.Name = "vCOMPANYLOCATIONID";
         dynavCompanylocationid.WebTags = "";
         dynavCompanylocationid.removeAllItems();
         /* Using cursor H003I5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            dynavCompanylocationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H003I5_A157CompanyLocationId[0]), 10, 0)), H003I5_A158CompanyLocationName[0], 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( dynavCompanylocationid.ItemCount > 0 )
         {
            AV10CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynavCompanylocationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV10CompanyLocationId), 10, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockcompanylocationid_Internalname = "TEXTBLOCKCOMPANYLOCATIONID";
         dynavCompanylocationid_Internalname = "vCOMPANYLOCATIONID";
         divUnnamedtablecompanylocationid_Internalname = "UNNAMEDTABLECOMPANYLOCATIONID";
         divCompanylocationid_cell_Internalname = "COMPANYLOCATIONID_CELL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxscheduler_Internalname = "GXSCHEDULER";
         divTablemain_Internalname = "TABLEMAIN";
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
         dynavCompanylocationid_Jsonclick = "";
         dynavCompanylocationid.Visible = 1;
         dynavCompanylocationid.Enabled = 1;
         divCompanylocationid_cell_Class = "";
         divUnnamedtable1_Visible = 1;
         Gxscheduler_Openlinknewwindow = "true";
         Gxscheduler_Detailsondblclick = "true";
         Gxscheduler_Detailsoncreate = "true";
         Gxscheduler_Readonly = "false";
         Gxscheduler_Montheventsview = "singleline";
         Gxscheduler_Displaynavigationbuttons = "true";
         Gxscheduler_Displaydaytab = "false";
         Gxscheduler_Displayweektab = "true";
         Gxscheduler_Theme = "classic";
         Gxscheduler_View = "month";
         Gxscheduler_Detailsformobject = "details.aspx";
         Gxscheduler_Loadeventsobject = "getleaveevents";
         Gxscheduler_Autoload = "month";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Leave Calendar Old";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"dynavCompanylocationid"},{"av":"AV10CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("VCOMPANYLOCATIONID.CONTROLVALUECHANGED","""{"handler":"E133I2","iparms":[{"av":"dynavCompanylocationid"},{"av":"AV10CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("GXSCHEDULER.EVENTSELECTED","""{"handler":"E113I2","iparms":[{"av":"AV7currentEvent","fld":"vCURRENTEVENT"}]}""");
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
         AV7currentEvent = new SdtSchedulerEvents_event(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV8initialDate = DateTime.MinValue;
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblockcompanylocationid_Jsonclick = "";
         TempTags = "";
         ucGxscheduler = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H003I2_A157CompanyLocationId = new long[1] ;
         H003I2_A158CompanyLocationName = new string[] {""} ;
         H003I3_A157CompanyLocationId = new long[1] ;
         H003I3_A158CompanyLocationName = new string[] {""} ;
         H003I4_A100CompanyId = new long[1] ;
         H003I4_A157CompanyLocationId = new long[1] ;
         AV12Session = context.GetSession();
         AV9websession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H003I5_A157CompanyLocationId = new long[1] ;
         H003I5_A158CompanyLocationName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leavecalendarold__default(),
            new Object[][] {
                new Object[] {
               H003I2_A157CompanyLocationId, H003I2_A158CompanyLocationName
               }
               , new Object[] {
               H003I3_A157CompanyLocationId, H003I3_A158CompanyLocationName
               }
               , new Object[] {
               H003I4_A100CompanyId, H003I4_A157CompanyLocationId
               }
               , new Object[] {
               H003I5_A157CompanyLocationId, H003I5_A158CompanyLocationName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int divUnnamedtable1_Visible ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long AV10CompanyLocationId ;
      private long AV15CompanyId ;
      private long GXt_int1 ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gxscheduler_Autoload ;
      private string Gxscheduler_Loadeventsobject ;
      private string Gxscheduler_Detailsformobject ;
      private string Gxscheduler_View ;
      private string Gxscheduler_Theme ;
      private string Gxscheduler_Displayweektab ;
      private string Gxscheduler_Displaydaytab ;
      private string Gxscheduler_Displaynavigationbuttons ;
      private string Gxscheduler_Montheventsview ;
      private string Gxscheduler_Readonly ;
      private string Gxscheduler_Detailsoncreate ;
      private string Gxscheduler_Detailsondblclick ;
      private string Gxscheduler_Openlinknewwindow ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divUnnamedtable1_Internalname ;
      private string divCompanylocationid_cell_Internalname ;
      private string divCompanylocationid_cell_Class ;
      private string divUnnamedtablecompanylocationid_Internalname ;
      private string lblTextblockcompanylocationid_Internalname ;
      private string lblTextblockcompanylocationid_Jsonclick ;
      private string dynavCompanylocationid_Internalname ;
      private string TempTags ;
      private string dynavCompanylocationid_Jsonclick ;
      private string Gxscheduler_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private DateTime AV8initialDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucGxscheduler ;
      private IGxSession AV12Session ;
      private IGxSession AV9websession ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavCompanylocationid ;
      private SdtSchedulerEvents_event AV7currentEvent ;
      private IDataStoreProvider pr_default ;
      private long[] H003I2_A157CompanyLocationId ;
      private string[] H003I2_A158CompanyLocationName ;
      private long[] H003I3_A157CompanyLocationId ;
      private string[] H003I3_A158CompanyLocationName ;
      private long[] H003I4_A100CompanyId ;
      private long[] H003I4_A157CompanyLocationId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H003I5_A157CompanyLocationId ;
      private string[] H003I5_A158CompanyLocationName ;
   }

   public class leavecalendarold__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003I2;
          prmH003I2 = new Object[] {
          };
          Object[] prmH003I3;
          prmH003I3 = new Object[] {
          };
          Object[] prmH003I4;
          prmH003I4 = new Object[] {
          new ParDef("AV15CompanyId",GXType.Int64,10,0)
          };
          Object[] prmH003I5;
          prmH003I5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H003I2", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003I2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003I3", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003I3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003I4", "SELECT CompanyId, CompanyLocationId FROM Company WHERE CompanyId = :AV15CompanyId ORDER BY CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003I4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H003I5", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003I5,0, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
