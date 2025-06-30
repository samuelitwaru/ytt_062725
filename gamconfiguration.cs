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
   public class gamconfiguration : GXDataArea
   {
      public gamconfiguration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamconfiguration( IGxContext context )
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
         cmbavDefaultrepository = new GXCombobox();
         cmbavEnabletracing = new GXCombobox();
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
            return "gamconfiguration_Execute" ;
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
         PA232( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START232( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamconfiguration.aspx") +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"GAMConfiguration");
         forbiddenHiddens.Add("GAMDatabaseVersion", StringUtil.RTrim( context.localUtil.Format( AV12GAMDatabaseVersion, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("gamconfiguration:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
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
            WE232( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT232( ) ;
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
         return formatLink("gamconfiguration.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "GAMConfiguration" ;
      }

      public override string GetPgmdesc( )
      {
         return "GAM Configuration" ;
      }

      protected void WB230( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 100, "%", 0, "px", "TableMainTransaction", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:25fr 50fr 25fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLefttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavGamdatabaseversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamdatabaseversion_Internalname, "Database version", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamdatabaseversion_Internalname, StringUtil.RTrim( AV12GAMDatabaseVersion), StringUtil.RTrim( context.localUtil.Format( AV12GAMDatabaseVersion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamdatabaseversion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavGamdatabaseversion_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavGamapiversion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamapiversion_Internalname, "API version", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGamapiversion_Internalname, StringUtil.RTrim( AV11GAMAPIVersion), StringUtil.RTrim( context.localUtil.Format( AV11GAMAPIVersion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGamapiversion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavGamapiversion_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDefaultrepository_cell_Internalname, 1, 0, "px", 0, "px", divDefaultrepository_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavDefaultrepository.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavDefaultrepository_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDefaultrepository_Internalname, "Default repository", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDefaultrepository, cmbavDefaultrepository_Internalname, StringUtil.RTrim( AV5DefaultRepository), 1, cmbavDefaultrepository_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavDefaultrepository.Visible, cmbavDefaultrepository.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_GAMConfiguration.htm");
            cmbavDefaultrepository.CurrentValue = StringUtil.RTrim( AV5DefaultRepository);
            AssignProp("", false, cmbavDefaultrepository_Internalname, "Values", (string)(cmbavDefaultrepository.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEmailregularexpression_cell_Internalname, 1, 0, "px", 0, "px", divEmailregularexpression_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavEmailregularexpression_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmailregularexpression_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmailregularexpression_Internalname, "Custom email regular expression", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmailregularexpression_Internalname, AV6EmailRegularExpression, StringUtil.RTrim( context.localUtil.Format( AV6EmailRegularExpression, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmailregularexpression_Jsonclick, 0, "Attribute", "", "", "", "", edtavEmailregularexpression_Visible, edtavEmailregularexpression_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_GAMConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavEnabletracing_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEnabletracing_Internalname, "Enable tracing", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEnabletracing, cmbavEnabletracing_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7EnableTracing), 4, 0)), 1, cmbavEnabletracing_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavEnabletracing.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_GAMConfiguration.htm");
            cmbavEnabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7EnableTracing), 4, 0));
            AssignProp("", false, cmbavEnabletracing_Internalname, "Values", (string)(cmbavEnabletracing.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirm", bttBtnenter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMConfiguration.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START232( )
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
         Form.Meta.addItem("description", "GAM Configuration", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP230( ) ;
      }

      protected void WS232( )
      {
         START232( ) ;
         EVT232( ) ;
      }

      protected void EVT232( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11232 ();
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
                                    E12232 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13232 ();
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

      protected void WE232( )
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

      protected void PA232( )
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
               GX_FocusControl = edtavGamdatabaseversion_Internalname;
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
         if ( cmbavDefaultrepository.ItemCount > 0 )
         {
            AV5DefaultRepository = cmbavDefaultrepository.getValidValue(AV5DefaultRepository);
            AssignAttri("", false, "AV5DefaultRepository", AV5DefaultRepository);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDefaultrepository.CurrentValue = StringUtil.RTrim( AV5DefaultRepository);
            AssignProp("", false, cmbavDefaultrepository_Internalname, "Values", cmbavDefaultrepository.ToJavascriptSource(), true);
         }
         if ( cmbavEnabletracing.ItemCount > 0 )
         {
            AV7EnableTracing = (short)(Math.Round(NumberUtil.Val( cmbavEnabletracing.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7EnableTracing), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EnableTracing", StringUtil.LTrimStr( (decimal)(AV7EnableTracing), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEnabletracing.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7EnableTracing), 4, 0));
            AssignProp("", false, cmbavEnabletracing_Internalname, "Values", cmbavEnabletracing.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF232( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavGamdatabaseversion_Enabled = 0;
         AssignProp("", false, edtavGamdatabaseversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamdatabaseversion_Enabled), 5, 0), true);
         edtavGamapiversion_Enabled = 0;
         AssignProp("", false, edtavGamapiversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamapiversion_Enabled), 5, 0), true);
      }

      protected void RF232( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13232 ();
            WB230( ) ;
         }
      }

      protected void send_integrity_lvl_hashes232( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavGamdatabaseversion_Enabled = 0;
         AssignProp("", false, edtavGamdatabaseversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamdatabaseversion_Enabled), 5, 0), true);
         edtavGamapiversion_Enabled = 0;
         AssignProp("", false, edtavGamapiversion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamapiversion_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP230( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11232 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV12GAMDatabaseVersion = cgiGet( edtavGamdatabaseversion_Internalname);
            AssignAttri("", false, "AV12GAMDatabaseVersion", AV12GAMDatabaseVersion);
            AV11GAMAPIVersion = cgiGet( edtavGamapiversion_Internalname);
            AssignAttri("", false, "AV11GAMAPIVersion", AV11GAMAPIVersion);
            cmbavDefaultrepository.CurrentValue = cgiGet( cmbavDefaultrepository_Internalname);
            AV5DefaultRepository = cgiGet( cmbavDefaultrepository_Internalname);
            AssignAttri("", false, "AV5DefaultRepository", AV5DefaultRepository);
            AV6EmailRegularExpression = cgiGet( edtavEmailregularexpression_Internalname);
            AssignAttri("", false, "AV6EmailRegularExpression", AV6EmailRegularExpression);
            cmbavEnabletracing.CurrentValue = cgiGet( cmbavEnabletracing_Internalname);
            AV7EnableTracing = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavEnabletracing_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EnableTracing", StringUtil.LTrimStr( (decimal)(AV7EnableTracing), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"GAMConfiguration");
            AV12GAMDatabaseVersion = cgiGet( edtavGamdatabaseversion_Internalname);
            AssignAttri("", false, "AV12GAMDatabaseVersion", AV12GAMDatabaseVersion);
            forbiddenHiddens.Add("GAMDatabaseVersion", StringUtil.RTrim( context.localUtil.Format( AV12GAMDatabaseVersion, "")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("gamconfiguration:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E11232 ();
         if (returnInSub) return;
      }

      protected void E11232( )
      {
         /* Start Routine */
         returnInSub = false;
         AV22GXV2 = 1;
         AV21GXV1 = (GxSimpleCollection<string>)(GeneXus.Programs.genexussecuritycommon.gxdomaingamversion.getValues());
         while ( AV22GXV2 <= AV21GXV1.Count )
         {
            AV11GAMAPIVersion = AV21GXV1.GetString(AV22GXV2);
            AssignAttri("", false, "AV11GAMAPIVersion", AV11GAMAPIVersion);
            if (true) break;
            AV22GXV2 = (int)(AV22GXV2+1);
         }
         AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).getdatabaseversion(out  AV12GAMDatabaseVersion);
         AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).getenabletracing(out  AV7EnableTracing);
         AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV5DefaultRepository);
         AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).getregularexpressiontovalidateemail(out  AV6EmailRegularExpression);
         AV17isAdminGAM = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isgamadministrator(out  AV9Errors);
         AssignAttri("", false, "AV17isAdminGAM", AV17isAdminGAM);
         cmbavDefaultrepository.removeAllItems();
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5DefaultRepository)) || new GeneXus.Programs.genexussecurity.SdtGAM(context).ismultitenant() )
         {
            if ( AV17isAdminGAM )
            {
               cmbavDefaultrepository.addItem("", "(none)", 0);
            }
            AV18LoadDefaultOK = false;
            AV14GAMRepositoryCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getallrepositories(AV10Filter, out  AV9Errors);
            if ( AV14GAMRepositoryCollection.Count > 0 )
            {
               AV23GXV3 = 1;
               while ( AV23GXV3 <= AV14GAMRepositoryCollection.Count )
               {
                  AV15GAMRepositoryItem = ((GeneXus.Programs.genexussecurity.SdtGAMRepository)AV14GAMRepositoryCollection.Item(AV23GXV3));
                  if ( (0==AV15GAMRepositoryItem.gxTpr_Authenticationmasterrepositoryid) )
                  {
                     if ( StringUtil.StrCmp(AV15GAMRepositoryItem.gxTpr_Guid, AV5DefaultRepository) == 0 )
                     {
                        AV18LoadDefaultOK = true;
                     }
                     cmbavDefaultrepository.addItem(AV15GAMRepositoryItem.gxTpr_Guid, AV15GAMRepositoryItem.gxTpr_Name, 0);
                  }
                  AV23GXV3 = (int)(AV23GXV3+1);
               }
            }
            if ( ! AV18LoadDefaultOK && ! String.IsNullOrEmpty(StringUtil.RTrim( AV5DefaultRepository)) )
            {
               cmbavDefaultrepository.removeAllItems();
               cmbavDefaultrepository.addItem(AV5DefaultRepository, AV5DefaultRepository, 0);
            }
         }
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5DefaultRepository)) || new GeneXus.Programs.genexussecurity.SdtGAM(context).ismultitenant() ) )
         {
            cmbavDefaultrepository.Visible = 0;
            AssignProp("", false, cmbavDefaultrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDefaultrepository.Visible), 5, 0), true);
            divDefaultrepository_cell_Class = "Invisible";
            AssignProp("", false, divDefaultrepository_cell_Internalname, "Class", divDefaultrepository_cell_Class, true);
         }
         else
         {
            cmbavDefaultrepository.Visible = 1;
            AssignProp("", false, cmbavDefaultrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDefaultrepository.Visible), 5, 0), true);
            divDefaultrepository_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp("", false, divDefaultrepository_cell_Internalname, "Class", divDefaultrepository_cell_Class, true);
         }
         if ( ! ( AV17isAdminGAM ) )
         {
            edtavEmailregularexpression_Visible = 0;
            AssignProp("", false, edtavEmailregularexpression_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmailregularexpression_Visible), 5, 0), true);
            divEmailregularexpression_cell_Class = "Invisible";
            AssignProp("", false, divEmailregularexpression_cell_Internalname, "Class", divEmailregularexpression_cell_Class, true);
         }
         else
         {
            edtavEmailregularexpression_Visible = 1;
            AssignProp("", false, edtavEmailregularexpression_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEmailregularexpression_Visible), 5, 0), true);
            divEmailregularexpression_cell_Class = "col-xs-12 DataContentCell DscTop";
            AssignProp("", false, divEmailregularexpression_cell_Internalname, "Class", divEmailregularexpression_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12232 ();
         if (returnInSub) return;
      }

      protected void E12232( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).setenabletracing(AV7EnableTracing);
         if ( AV16isOk )
         {
            AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isgamadministrator(out  AV9Errors) )
            {
               AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).setregularexpressiontovalidateemail(AV6EmailRegularExpression);
               AV16isOk = new GeneXus.Programs.genexussecurity.SdtGAM(context).setdefaultrepository(AV5DefaultRepository);
               if ( AV16isOk )
               {
                  GX_msglist.addItem(context.GetMessage( "Data has been successfully updated.", ""));
               }
               else
               {
                  GX_msglist.addItem("Default repository could not be saved");
               }
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "Data has been successfully updated.", ""));
            }
         }
         else
         {
            GX_msglist.addItem("Tracing status could not be saved");
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E13232( )
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
         PA232( ) ;
         WS232( ) ;
         WE232( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256277383074", true, true);
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
         context.AddJavascriptSource("gamconfiguration.js", "?20256277383076", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavDefaultrepository.Name = "vDEFAULTREPOSITORY";
         cmbavDefaultrepository.WebTags = "";
         if ( cmbavDefaultrepository.ItemCount > 0 )
         {
            AV5DefaultRepository = cmbavDefaultrepository.getValidValue(AV5DefaultRepository);
            AssignAttri("", false, "AV5DefaultRepository", AV5DefaultRepository);
         }
         cmbavEnabletracing.Name = "vENABLETRACING";
         cmbavEnabletracing.WebTags = "";
         cmbavEnabletracing.addItem("0", "0 - Off", 0);
         cmbavEnabletracing.addItem("1", "1 - Debug", 0);
         if ( cmbavEnabletracing.ItemCount > 0 )
         {
            AV7EnableTracing = (short)(Math.Round(NumberUtil.Val( cmbavEnabletracing.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7EnableTracing), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EnableTracing", StringUtil.LTrimStr( (decimal)(AV7EnableTracing), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtavGamdatabaseversion_Internalname = "vGAMDATABASEVERSION";
         edtavGamapiversion_Internalname = "vGAMAPIVERSION";
         cmbavDefaultrepository_Internalname = "vDEFAULTREPOSITORY";
         divDefaultrepository_cell_Internalname = "DEFAULTREPOSITORY_CELL";
         edtavEmailregularexpression_Internalname = "vEMAILREGULAREXPRESSION";
         divEmailregularexpression_cell_Internalname = "EMAILREGULAREXPRESSION_CELL";
         cmbavEnabletracing_Internalname = "vENABLETRACING";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
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
         cmbavEnabletracing_Jsonclick = "";
         cmbavEnabletracing.Enabled = 1;
         edtavEmailregularexpression_Jsonclick = "";
         edtavEmailregularexpression_Enabled = 1;
         edtavEmailregularexpression_Visible = 1;
         divEmailregularexpression_cell_Class = "col-xs-12";
         cmbavDefaultrepository_Jsonclick = "";
         cmbavDefaultrepository.Enabled = 1;
         cmbavDefaultrepository.Visible = 1;
         divDefaultrepository_cell_Class = "col-xs-12";
         edtavGamapiversion_Jsonclick = "";
         edtavGamapiversion_Enabled = 1;
         edtavGamdatabaseversion_Jsonclick = "";
         edtavGamdatabaseversion_Enabled = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "GAM Configuration";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV12GAMDatabaseVersion","fld":"vGAMDATABASEVERSION"}]}""");
         setEventMetadata("ENTER","""{"handler":"E12232","iparms":[{"av":"cmbavEnabletracing"},{"av":"AV7EnableTracing","fld":"vENABLETRACING","pic":"ZZZ9"},{"av":"AV6EmailRegularExpression","fld":"vEMAILREGULAREXPRESSION"},{"av":"cmbavDefaultrepository"},{"av":"AV5DefaultRepository","fld":"vDEFAULTREPOSITORY"}]}""");
         setEventMetadata("VALIDV_ENABLETRACING","""{"handler":"Validv_Enabletracing","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         AV12GAMDatabaseVersion = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV11GAMAPIVersion = "";
         AV5DefaultRepository = "";
         AV6EmailRegularExpression = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         hsh = "";
         AV21GXV1 = new GxSimpleCollection<string>();
         AV9Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14GAMRepositoryCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepository>( context, "GeneXus.Programs.genexussecurity.SdtGAMRepository", "GeneXus.Programs");
         AV10Filter = new GeneXus.Programs.genexussecurity.SdtGAMRepositoryFilter(context);
         AV15GAMRepositoryItem = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV13GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         edtavGamdatabaseversion_Enabled = 0;
         edtavGamapiversion_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV7EnableTracing ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavGamdatabaseversion_Enabled ;
      private int edtavGamapiversion_Enabled ;
      private int edtavEmailregularexpression_Visible ;
      private int edtavEmailregularexpression_Enabled ;
      private int AV22GXV2 ;
      private int AV23GXV3 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV12GAMDatabaseVersion ;
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
      private string edtavGamdatabaseversion_Internalname ;
      private string TempTags ;
      private string edtavGamdatabaseversion_Jsonclick ;
      private string edtavGamapiversion_Internalname ;
      private string AV11GAMAPIVersion ;
      private string edtavGamapiversion_Jsonclick ;
      private string divDefaultrepository_cell_Internalname ;
      private string divDefaultrepository_cell_Class ;
      private string cmbavDefaultrepository_Internalname ;
      private string AV5DefaultRepository ;
      private string cmbavDefaultrepository_Jsonclick ;
      private string divEmailregularexpression_cell_Internalname ;
      private string divEmailregularexpression_cell_Class ;
      private string edtavEmailregularexpression_Internalname ;
      private string edtavEmailregularexpression_Jsonclick ;
      private string cmbavEnabletracing_Internalname ;
      private string cmbavEnabletracing_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divRighttable_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV16isOk ;
      private bool AV17isAdminGAM ;
      private bool AV18LoadDefaultOK ;
      private string AV6EmailRegularExpression ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDefaultrepository ;
      private GXCombobox cmbavEnabletracing ;
      private GxSimpleCollection<string> AV21GXV1 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepository> AV14GAMRepositoryCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepositoryFilter AV10Filter ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV15GAMRepositoryItem ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV13GAMRepository ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
