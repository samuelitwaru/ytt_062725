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
   public class gamuserentry : GXDataArea
   {
      public gamuserentry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamuserentry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref string aP1_UserId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV55UserId = aP1_UserId;
         ExecuteImpl();
         aP0_Gx_mode=this.Gx_mode;
         aP1_UserId=this.AV55UserId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavAuthenticationtypename = new GXCombobox();
         cmbavGender = new GXCombobox();
         chkavIsactive = new GXCheckbox();
         chkavDontreceiveinformation = new GXCheckbox();
         chkavCannotchangepassword = new GXCheckbox();
         chkavMustchangepassword = new GXCheckbox();
         chkavPasswordneverexpires = new GXCheckbox();
         chkavIsblocked = new GXCheckbox();
         cmbavSecuritypolicyid = new GXCombobox();
         chkavIsenabledinrepository = new GXCheckbox();
         chkavEnabletwofactorauthentication = new GXCheckbox();
         chkavUser_isenabledinrepository = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
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
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV55UserId = GetPar( "UserId");
                  AssignAttri("", false, "AV55UserId", AV55UserId);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
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
            return "gamuserentry_Execute" ;
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
         PA1M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1M2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamuserentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV55UserId))}, new string[] {"Gx_mode","UserId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV59CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vPHOTO", AV46Photo);
         GxWebStd.gx_hidden_field( context, "vAUTHTYPEID", StringUtil.RTrim( AV10AuthTypeId));
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
            WE1M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1M2( ) ;
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
         return formatLink("gamuserentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV55UserId))}, new string[] {"Gx_mode","UserId"})  ;
      }

      public override string GetPgmname( )
      {
         return "GAMUserEntry" ;
      }

      public override string GetPgmdesc( )
      {
         return "User " ;
      }

      protected void WB1M0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserid_Internalname, "GUID", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserid_Internalname, StringUtil.RTrim( AV55UserId), StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUserid_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsernamespace_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsernamespace_Internalname, "Namespace", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsernamespace_Internalname, StringUtil.RTrim( AV56UserNameSpace), StringUtil.RTrim( context.localUtil.Format( AV56UserNameSpace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsernamespace_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsernamespace_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAuthenticationtypename_cell_Internalname, 1, 0, "px", 0, "px", divAuthenticationtypename_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavAuthenticationtypename.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAuthenticationtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAuthenticationtypename_Internalname, "Auth. type", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAuthenticationtypename, cmbavAuthenticationtypename_Internalname, StringUtil.RTrim( AV7AuthenticationTypeName), 1, cmbavAuthenticationtypename_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavAuthenticationtypename.Visible, cmbavAuthenticationtypename.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_GAMUserEntry.htm");
            cmbavAuthenticationtypename.CurrentValue = StringUtil.RTrim( AV7AuthenticationTypeName);
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Values", (string)(cmbavAuthenticationtypename.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "User name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV36Name, StringUtil.RTrim( context.localUtil.Format( AV36Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEmail_cell_Internalname, 1, 0, "px", 0, "px", divEmail_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV16Email, StringUtil.RTrim( context.localUtil.Format( AV16Email, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPassword_cell_Internalname, 1, 0, "px", 0, "px", divPassword_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPassword_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, "Password", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, StringUtil.RTrim( AV41Password), StringUtil.RTrim( context.localUtil.Format( AV41Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassword_Jsonclick, 0, "Attribute", "", "", "", "", edtavPassword_Visible, edtavPassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPasswordconf_cell_Internalname, 1, 0, "px", 0, "px", divPasswordconf_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPasswordconf_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPasswordconf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPasswordconf_Internalname, "Conf. password", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPasswordconf_Internalname, StringUtil.RTrim( AV42PasswordConf), StringUtil.RTrim( context.localUtil.Format( AV42PasswordConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPasswordconf_Jsonclick, 0, "Attribute", "", "", "", "", edtavPasswordconf_Visible, edtavPasswordconf_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFirstname_cell_Internalname, 1, 0, "px", 0, "px", divFirstname_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, "First name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV22FirstName), StringUtil.RTrim( context.localUtil.Format( AV22FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFirstname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLastname_cell_Internalname, 1, 0, "px", 0, "px", divLastname_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, "Last name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV31LastName), StringUtil.RTrim( context.localUtil.Format( AV31LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLastname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavExternalid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavExternalid_Internalname, "External Id", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavExternalid_Internalname, AV20ExternalId, StringUtil.RTrim( context.localUtil.Format( AV20ExternalId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavExternalid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavExternalid_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBirthday_cell_Internalname, 1, 0, "px", 0, "px", divBirthday_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavBirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBirthday_Internalname, "Birthday", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavBirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavBirthday_Internalname, context.localUtil.Format(AV11Birthday, "99/99/9999"), context.localUtil.Format( AV11Birthday, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBirthday_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavBirthday_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "end", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavBirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavBirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGender_cell_Internalname, 1, 0, "px", 0, "px", divGender_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavGender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGender_Internalname, "Gender", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGender, cmbavGender_Internalname, StringUtil.RTrim( AV24Gender), 1, cmbavGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGender.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_GAMUserEntry.htm");
            cmbavGender.CurrentValue = StringUtil.RTrim( AV24Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", (string)(cmbavGender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPhone_cell_Internalname, 1, 0, "px", 0, "px", divPhone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPhone_Internalname, "Phone", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhone_Internalname, StringUtil.RTrim( AV45Phone), StringUtil.RTrim( context.localUtil.Format( AV45Phone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPhone_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUrlprofile_cell_Internalname, 1, 0, "px", 0, "px", divUrlprofile_cell_Class, "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableurlprofile_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockurlprofile_Internalname, "URL profile", "", "", lblTextblockurlprofile_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUrlprofile_Internalname, "URLProfile", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUrlprofile_Internalname, AV52URLProfile, StringUtil.RTrim( context.localUtil.Format( AV52URLProfile, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUrlprofile_Jsonclick, 0, "Attribute", "", "", "", "", edtavUrlprofile_Visible, edtavUrlprofile_Enabled, 1, "text", "", 80, "chr", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "Button ButtonMaterialGAM";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnurlprofilego_Internalname, "", "WWP_GAM_Go", bttBtnurlprofilego_Jsonclick, 7, "WWP_GAM_Go", "", StyleString, ClassString, bttBtnurlprofilego_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e111m1_client"+"'", TempTags, "", 2, "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImage_cell_Internalname, 1, 0, "px", 0, "px", divImage_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", imgavImage_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgavImage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "External Image", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute" + " " + ((StringUtil.StrCmp(imgavImage_gximage, "")==0) ? "" : "GX_Image_"+imgavImage_gximage+"_Class");
            StyleString = "";
            AV25Image_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV25Image))&&String.IsNullOrEmpty(StringUtil.RTrim( AV64Image_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV25Image)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV25Image)) ? AV64Image_GXI : context.PathToRelativeUrl( AV25Image));
            GxWebStd.gx_bitmap( context, imgavImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavImage_Visible, imgavImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV25Image_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divIsactive_cell_Internalname, 1, 0, "px", 0, "px", divIsactive_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavIsactive.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavIsactive_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsactive_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsactive_Internalname, StringUtil.BoolToStr( AV26IsActive), "", " ", chkavIsactive.Visible, chkavIsactive.Enabled, "true", "Account is active?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(100, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,100);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActivationdate_cell_Internalname, 1, 0, "px", 0, "px", divActivationdate_cell_Class, "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableactivationdate_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockactivationdate_Internalname, "Activation date", "", "", lblTextblockactivationdate_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavActivationdate_Internalname, "Activation Date", "col-sm-3 AttributeDateTimeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavActivationdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavActivationdate_Internalname, context.localUtil.TToC( AV5ActivationDate, 10, 8, 1, 3, "/", ":", " "), context.localUtil.Format( AV5ActivationDate, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,12,'eng',false,0);"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavActivationdate_Jsonclick, 0, "AttributeDateTime", "", "", "", "", edtavActivationdate_Visible, edtavActivationdate_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "end", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavActivationdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavActivationdate_Visible==0)||(edtavActivationdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            ClassString = "Button ButtonMaterialGAM";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsendactivationemail_Internalname, "", "Send activation email", bttBtnsendactivationemail_Jsonclick, 5, "Send activation email", "", StyleString, ClassString, bttBtnsendactivationemail_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOSENDACTIVATIONEMAIL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavDontreceiveinformation_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDontreceiveinformation_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDontreceiveinformation_Internalname, StringUtil.BoolToStr( AV15DontReceiveInformation), "", " ", 1, chkavDontreceiveinformation.Enabled, "true", "Don't want to receive information", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(117, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,117);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavCannotchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCannotchangepassword_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCannotchangepassword_Internalname, StringUtil.BoolToStr( AV13CannotChangePassword), "", " ", 1, chkavCannotchangepassword.Enabled, "true", "Cannot change password", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(121, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,121);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavMustchangepassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavMustchangepassword_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavMustchangepassword_Internalname, StringUtil.BoolToStr( AV35MustChangePassword), "", " ", 1, chkavMustchangepassword.Enabled, "true", "Must change password", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(126, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,126);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavPasswordneverexpires_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavPasswordneverexpires_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavPasswordneverexpires_Internalname, StringUtil.BoolToStr( AV44PasswordNeverExpires), "", " ", 1, chkavPasswordneverexpires.Enabled, "true", "Password never expires", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(130, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,130);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavIsblocked_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsblocked_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsblocked_Internalname, StringUtil.BoolToStr( AV27IsBlocked), "", " ", 1, chkavIsblocked.Enabled, "true", "Is blocked?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(135, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,135);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavSecuritypolicyid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavSecuritypolicyid_Internalname, "Security policy", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavSecuritypolicyid, cmbavSecuritypolicyid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV50SecurityPolicyId), 9, 0)), 1, cmbavSecuritypolicyid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavSecuritypolicyid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "", true, 0, "HLP_GAMUserEntry.htm");
            cmbavSecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV50SecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Values", (string)(cmbavSecuritypolicyid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divIsenabledinrepository_cell_Internalname, 1, 0, "px", 0, "px", divIsenabledinrepository_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavIsenabledinrepository.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavIsenabledinrepository_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsenabledinrepository_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsenabledinrepository_Internalname, StringUtil.BoolToStr( AV28IsEnabledInRepository), "", " ", chkavIsenabledinrepository.Visible, chkavIsenabledinrepository.Enabled, "true", "Is enabled in repository?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(144, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,144);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatelastauthentication_cell_Internalname, 1, 0, "px", 0, "px", divDatelastauthentication_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavDatelastauthentication_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDatelastauthentication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDatelastauthentication_Internalname, "Last Authentication", " AttributeDateTimeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatelastauthentication_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatelastauthentication_Internalname, context.localUtil.TToC( AV14DateLastAuthentication, 10, 8, 1, 3, "/", ":", " "), context.localUtil.Format( AV14DateLastAuthentication, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,12,'eng',false,0);"+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatelastauthentication_Jsonclick, 0, "AttributeDateTime", "", "", "", "", edtavDatelastauthentication_Visible, edtavDatelastauthentication_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "end", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavDatelastauthentication_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavDatelastauthentication_Visible==0)||(edtavDatelastauthentication_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEnabletwofactorauthentication_cell_Internalname, 1, 0, "px", 0, "px", divEnabletwofactorauthentication_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavEnabletwofactorauthentication.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavEnabletwofactorauthentication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavEnabletwofactorauthentication_Internalname, " ", " AttributeCheckBoxLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavEnabletwofactorauthentication_Internalname, StringUtil.BoolToStr( AV17EnableTwoFactorAuthentication), "", " ", chkavEnabletwofactorauthentication.Visible, chkavEnabletwofactorauthentication.Enabled, "true", "Enable Two Factor Authentication?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(153, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,153);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOtpnumberlocked_cell_Internalname, 1, 0, "px", 0, "px", divOtpnumberlocked_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavOtpnumberlocked_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOtpnumberlocked_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpnumberlocked_Internalname, "Number of locked OTP codes", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpnumberlocked_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40OTPNumberLocked), 3, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40OTPNumberLocked), "ZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,158);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpnumberlocked_Jsonclick, 0, "Attribute", "", "", "", "", edtavOtpnumberlocked_Visible, edtavOtpnumberlocked_Enabled, 1, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOtplastlockeddate_cell_Internalname, 1, 0, "px", 0, "px", divOtplastlockeddate_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavOtplastlockeddate_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOtplastlockeddate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtplastlockeddate_Internalname, "Last time OTP code was locked", " AttributeDateTimeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavOtplastlockeddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavOtplastlockeddate_Internalname, context.localUtil.TToC( AV39OTPLastLockedDate, 10, 8, 1, 3, "/", ":", " "), context.localUtil.Format( AV39OTPLastLockedDate, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,12,'eng',false,0);"+";gx.evt.onblur(this,162);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtplastlockeddate_Jsonclick, 0, "AttributeDateTime", "", "", "", "", edtavOtplastlockeddate_Visible, edtavOtplastlockeddate_Enabled, 1, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDateTime", "end", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavOtplastlockeddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavOtplastlockeddate_Visible==0)||(edtavOtplastlockeddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOtpdailynumbercodes_cell_Internalname, 1, 0, "px", 0, "px", divOtpdailynumbercodes_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavOtpdailynumbercodes_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOtpdailynumbercodes_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtpdailynumbercodes_Internalname, "Number of daily OTP codes requested", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOtpdailynumbercodes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37OTPDailyNumberCodes), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV37OTPDailyNumberCodes), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtpdailynumbercodes_Jsonclick, 0, "Attribute", "", "", "", "", edtavOtpdailynumbercodes_Visible, edtavOtpdailynumbercodes_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOtplastdaterequestcode_cell_Internalname, 1, 0, "px", 0, "px", divOtplastdaterequestcode_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavOtplastdaterequestcode_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOtplastdaterequestcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOtplastdaterequestcode_Internalname, "Last date requested a OTP code", " AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavOtplastdaterequestcode_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavOtplastdaterequestcode_Internalname, context.localUtil.Format(AV38OTPLastDateRequestCode, "99/99/9999"), context.localUtil.Format( AV38OTPLastDateRequestCode, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOtplastdaterequestcode_Jsonclick, 0, "AttributeDate", "", "", "", "", edtavOtplastdaterequestcode_Visible, edtavOtplastdaterequestcode_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "end", false, "", "HLP_GAMUserEntry.htm");
            GxWebStd.gx_bitmap( context, edtavOtplastdaterequestcode_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavOtplastdaterequestcode_Visible==0)||(edtavOtplastdaterequestcode_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMUserEntry.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUserEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMUserEntry.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUser_isenabledinrepository_Internalname, StringUtil.BoolToStr( AV53User.gxTpr_Isenabledinrepository), "", "", chkavUser_isenabledinrepository.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(184, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,184);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START1M2( )
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
         Form.Meta.addItem("description", "User ", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1M0( ) ;
      }

      protected void WS1M2( )
      {
         START1M2( ) ;
         EVT1M2( ) ;
      }

      protected void EVT1M2( )
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
                              E121M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E131M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSENDACTIVATIONEMAIL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoSendActivationEmail' */
                              E141M2 ();
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
                                    E151M2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VAUTHENTICATIONTYPENAME.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E161M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E171M2 ();
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

      protected void WE1M2( )
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

      protected void PA1M2( )
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
               GX_FocusControl = edtavUsernamespace_Internalname;
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
         if ( cmbavAuthenticationtypename.ItemCount > 0 )
         {
            AV7AuthenticationTypeName = cmbavAuthenticationtypename.getValidValue(AV7AuthenticationTypeName);
            AssignAttri("", false, "AV7AuthenticationTypeName", AV7AuthenticationTypeName);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAuthenticationtypename.CurrentValue = StringUtil.RTrim( AV7AuthenticationTypeName);
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Values", cmbavAuthenticationtypename.ToJavascriptSource(), true);
         }
         if ( cmbavGender.ItemCount > 0 )
         {
            AV24Gender = cmbavGender.getValidValue(AV24Gender);
            AssignAttri("", false, "AV24Gender", AV24Gender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGender.CurrentValue = StringUtil.RTrim( AV24Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", cmbavGender.ToJavascriptSource(), true);
         }
         AV26IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV26IsActive));
         AssignAttri("", false, "AV26IsActive", AV26IsActive);
         AV15DontReceiveInformation = StringUtil.StrToBool( StringUtil.BoolToStr( AV15DontReceiveInformation));
         AssignAttri("", false, "AV15DontReceiveInformation", AV15DontReceiveInformation);
         AV13CannotChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV13CannotChangePassword));
         AssignAttri("", false, "AV13CannotChangePassword", AV13CannotChangePassword);
         AV35MustChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV35MustChangePassword));
         AssignAttri("", false, "AV35MustChangePassword", AV35MustChangePassword);
         AV44PasswordNeverExpires = StringUtil.StrToBool( StringUtil.BoolToStr( AV44PasswordNeverExpires));
         AssignAttri("", false, "AV44PasswordNeverExpires", AV44PasswordNeverExpires);
         AV27IsBlocked = StringUtil.StrToBool( StringUtil.BoolToStr( AV27IsBlocked));
         AssignAttri("", false, "AV27IsBlocked", AV27IsBlocked);
         if ( cmbavSecuritypolicyid.ItemCount > 0 )
         {
            AV50SecurityPolicyId = (int)(Math.Round(NumberUtil.Val( cmbavSecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV50SecurityPolicyId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV50SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV50SecurityPolicyId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavSecuritypolicyid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV50SecurityPolicyId), 9, 0));
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Values", cmbavSecuritypolicyid.ToJavascriptSource(), true);
         }
         AV28IsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV28IsEnabledInRepository));
         AssignAttri("", false, "AV28IsEnabledInRepository", AV28IsEnabledInRepository);
         AV17EnableTwoFactorAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV17EnableTwoFactorAuthentication));
         AssignAttri("", false, "AV17EnableTwoFactorAuthentication", AV17EnableTwoFactorAuthentication);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavUserid_Enabled = 0;
         AssignProp("", false, edtavUserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserid_Enabled), 5, 0), true);
         edtavUsernamespace_Enabled = 0;
         AssignProp("", false, edtavUsernamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsernamespace_Enabled), 5, 0), true);
         edtavActivationdate_Enabled = 0;
         AssignProp("", false, edtavActivationdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Enabled), 5, 0), true);
         edtavDatelastauthentication_Enabled = 0;
         AssignProp("", false, edtavDatelastauthentication_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDatelastauthentication_Enabled), 5, 0), true);
         edtavOtpnumberlocked_Enabled = 0;
         AssignProp("", false, edtavOtpnumberlocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Enabled), 5, 0), true);
         edtavOtplastlockeddate_Enabled = 0;
         AssignProp("", false, edtavOtplastlockeddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Enabled), 5, 0), true);
         edtavOtpdailynumbercodes_Enabled = 0;
         AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Enabled), 5, 0), true);
         edtavOtplastdaterequestcode_Enabled = 0;
         AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Enabled), 5, 0), true);
      }

      protected void RF1M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E131M2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E171M2 ();
            WB1M0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1M2( )
      {
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
      }

      protected void before_start_formulas( )
      {
         edtavUserid_Enabled = 0;
         AssignProp("", false, edtavUserid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUserid_Enabled), 5, 0), true);
         edtavUsernamespace_Enabled = 0;
         AssignProp("", false, edtavUsernamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsernamespace_Enabled), 5, 0), true);
         edtavActivationdate_Enabled = 0;
         AssignProp("", false, edtavActivationdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Enabled), 5, 0), true);
         edtavDatelastauthentication_Enabled = 0;
         AssignProp("", false, edtavDatelastauthentication_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDatelastauthentication_Enabled), 5, 0), true);
         edtavOtpnumberlocked_Enabled = 0;
         AssignProp("", false, edtavOtpnumberlocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Enabled), 5, 0), true);
         edtavOtplastlockeddate_Enabled = 0;
         AssignProp("", false, edtavOtplastlockeddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Enabled), 5, 0), true);
         edtavOtpdailynumbercodes_Enabled = 0;
         AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Enabled), 5, 0), true);
         edtavOtplastdaterequestcode_Enabled = 0;
         AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E121M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV55UserId = cgiGet( edtavUserid_Internalname);
            AssignAttri("", false, "AV55UserId", AV55UserId);
            GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
            AV56UserNameSpace = cgiGet( edtavUsernamespace_Internalname);
            AssignAttri("", false, "AV56UserNameSpace", AV56UserNameSpace);
            cmbavAuthenticationtypename.CurrentValue = cgiGet( cmbavAuthenticationtypename_Internalname);
            AV7AuthenticationTypeName = cgiGet( cmbavAuthenticationtypename_Internalname);
            AssignAttri("", false, "AV7AuthenticationTypeName", AV7AuthenticationTypeName);
            AV36Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV36Name", AV36Name);
            AV16Email = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV16Email", AV16Email);
            AV41Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV41Password", AV41Password);
            AV42PasswordConf = cgiGet( edtavPasswordconf_Internalname);
            AssignAttri("", false, "AV42PasswordConf", AV42PasswordConf);
            AV22FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV22FirstName", AV22FirstName);
            AV31LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV31LastName", AV31LastName);
            AV20ExternalId = cgiGet( edtavExternalid_Internalname);
            AssignAttri("", false, "AV20ExternalId", AV20ExternalId);
            if ( context.localUtil.VCDate( cgiGet( edtavBirthday_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Birthday"}), 1, "vBIRTHDAY");
               GX_FocusControl = edtavBirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11Birthday = DateTime.MinValue;
               AssignAttri("", false, "AV11Birthday", context.localUtil.Format(AV11Birthday, "99/99/9999"));
            }
            else
            {
               AV11Birthday = context.localUtil.CToD( cgiGet( edtavBirthday_Internalname), 2);
               AssignAttri("", false, "AV11Birthday", context.localUtil.Format(AV11Birthday, "99/99/9999"));
            }
            cmbavGender.CurrentValue = cgiGet( cmbavGender_Internalname);
            AV24Gender = cgiGet( cmbavGender_Internalname);
            AssignAttri("", false, "AV24Gender", AV24Gender);
            AV45Phone = cgiGet( edtavPhone_Internalname);
            AssignAttri("", false, "AV45Phone", AV45Phone);
            AV52URLProfile = cgiGet( edtavUrlprofile_Internalname);
            AssignAttri("", false, "AV52URLProfile", AV52URLProfile);
            AV25Image = cgiGet( imgavImage_Internalname);
            AV26IsActive = StringUtil.StrToBool( cgiGet( chkavIsactive_Internalname));
            AssignAttri("", false, "AV26IsActive", AV26IsActive);
            if ( context.localUtil.VCDateTime( cgiGet( edtavActivationdate_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Activation Date"}), 1, "vACTIVATIONDATE");
               GX_FocusControl = edtavActivationdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5ActivationDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV5ActivationDate", context.localUtil.TToC( AV5ActivationDate, 10, 5, 1, 3, "/", ":", " "));
            }
            else
            {
               AV5ActivationDate = context.localUtil.CToT( cgiGet( edtavActivationdate_Internalname));
               AssignAttri("", false, "AV5ActivationDate", context.localUtil.TToC( AV5ActivationDate, 10, 5, 1, 3, "/", ":", " "));
            }
            AV15DontReceiveInformation = StringUtil.StrToBool( cgiGet( chkavDontreceiveinformation_Internalname));
            AssignAttri("", false, "AV15DontReceiveInformation", AV15DontReceiveInformation);
            AV13CannotChangePassword = StringUtil.StrToBool( cgiGet( chkavCannotchangepassword_Internalname));
            AssignAttri("", false, "AV13CannotChangePassword", AV13CannotChangePassword);
            AV35MustChangePassword = StringUtil.StrToBool( cgiGet( chkavMustchangepassword_Internalname));
            AssignAttri("", false, "AV35MustChangePassword", AV35MustChangePassword);
            AV44PasswordNeverExpires = StringUtil.StrToBool( cgiGet( chkavPasswordneverexpires_Internalname));
            AssignAttri("", false, "AV44PasswordNeverExpires", AV44PasswordNeverExpires);
            AV27IsBlocked = StringUtil.StrToBool( cgiGet( chkavIsblocked_Internalname));
            AssignAttri("", false, "AV27IsBlocked", AV27IsBlocked);
            cmbavSecuritypolicyid.CurrentValue = cgiGet( cmbavSecuritypolicyid_Internalname);
            AV50SecurityPolicyId = (int)(Math.Round(NumberUtil.Val( cgiGet( cmbavSecuritypolicyid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV50SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV50SecurityPolicyId), 9, 0));
            AV28IsEnabledInRepository = StringUtil.StrToBool( cgiGet( chkavIsenabledinrepository_Internalname));
            AssignAttri("", false, "AV28IsEnabledInRepository", AV28IsEnabledInRepository);
            if ( context.localUtil.VCDateTime( cgiGet( edtavDatelastauthentication_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Date Last Authentication"}), 1, "vDATELASTAUTHENTICATION");
               GX_FocusControl = edtavDatelastauthentication_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14DateLastAuthentication = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV14DateLastAuthentication", context.localUtil.TToC( AV14DateLastAuthentication, 10, 5, 1, 3, "/", ":", " "));
            }
            else
            {
               AV14DateLastAuthentication = context.localUtil.CToT( cgiGet( edtavDatelastauthentication_Internalname));
               AssignAttri("", false, "AV14DateLastAuthentication", context.localUtil.TToC( AV14DateLastAuthentication, 10, 5, 1, 3, "/", ":", " "));
            }
            AV17EnableTwoFactorAuthentication = StringUtil.StrToBool( cgiGet( chkavEnabletwofactorauthentication_Internalname));
            AssignAttri("", false, "AV17EnableTwoFactorAuthentication", AV17EnableTwoFactorAuthentication);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpnumberlocked_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpnumberlocked_Internalname), ".", ",") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPNUMBERLOCKED");
               GX_FocusControl = edtavOtpnumberlocked_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV40OTPNumberLocked = 0;
               AssignAttri("", false, "AV40OTPNumberLocked", StringUtil.LTrimStr( (decimal)(AV40OTPNumberLocked), 3, 0));
            }
            else
            {
               AV40OTPNumberLocked = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOtpnumberlocked_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV40OTPNumberLocked", StringUtil.LTrimStr( (decimal)(AV40OTPNumberLocked), 3, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavOtplastlockeddate_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Last time OTP code is locked"}), 1, "vOTPLASTLOCKEDDATE");
               GX_FocusControl = edtavOtplastlockeddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39OTPLastLockedDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV39OTPLastLockedDate", context.localUtil.TToC( AV39OTPLastLockedDate, 10, 5, 1, 3, "/", ":", " "));
            }
            else
            {
               AV39OTPLastLockedDate = context.localUtil.CToT( cgiGet( edtavOtplastlockeddate_Internalname));
               AssignAttri("", false, "AV39OTPLastLockedDate", context.localUtil.TToC( AV39OTPLastLockedDate, 10, 5, 1, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOtpdailynumbercodes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOtpdailynumbercodes_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vOTPDAILYNUMBERCODES");
               GX_FocusControl = edtavOtpdailynumbercodes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV37OTPDailyNumberCodes = 0;
               AssignAttri("", false, "AV37OTPDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV37OTPDailyNumberCodes), 4, 0));
            }
            else
            {
               AV37OTPDailyNumberCodes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOtpdailynumbercodes_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV37OTPDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV37OTPDailyNumberCodes), 4, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavOtplastdaterequestcode_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Last date requested a OTP code"}), 1, "vOTPLASTDATEREQUESTCODE");
               GX_FocusControl = edtavOtplastdaterequestcode_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV38OTPLastDateRequestCode = DateTime.MinValue;
               AssignAttri("", false, "AV38OTPLastDateRequestCode", context.localUtil.Format(AV38OTPLastDateRequestCode, "99/99/9999"));
            }
            else
            {
               AV38OTPLastDateRequestCode = context.localUtil.CToD( cgiGet( edtavOtplastdaterequestcode_Internalname), 2);
               AssignAttri("", false, "AV38OTPLastDateRequestCode", context.localUtil.Format(AV38OTPLastDateRequestCode, "99/99/9999"));
            }
            AV53User.gxTpr_Isenabledinrepository = StringUtil.StrToBool( cgiGet( chkavUser_isenabledinrepository_Internalname));
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
         E121M2 ();
         if (returnInSub) return;
      }

      protected void E121M2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV23GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( (0==AV23GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
         {
            cmbavAuthenticationtypename.removeAllItems();
            AV8AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV30Language, out  AV19Errors);
            AV62GXV2 = 1;
            while ( AV62GXV2 <= AV8AuthenticationTypes.Count )
            {
               AV9AuthenticationTypesIns = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV8AuthenticationTypes.Item(AV62GXV2));
               cmbavAuthenticationtypename.addItem(AV9AuthenticationTypesIns.gxTpr_Name, AV9AuthenticationTypesIns.gxTpr_Description, 0);
               AV62GXV2 = (int)(AV62GXV2+1);
            }
         }
         else
         {
            cmbavAuthenticationtypename.Visible = 0;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Visible), 5, 0), true);
         }
         AV48SecurityPolicies = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getsecuritypolicies(AV21FilterSecPol, out  AV19Errors);
         cmbavSecuritypolicyid.addItem("0", "(None)", 0);
         AV63GXV3 = 1;
         while ( AV63GXV3 <= AV48SecurityPolicies.Count )
         {
            AV49SecurityPolicy = ((GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy)AV48SecurityPolicies.Item(AV63GXV3));
            cmbavSecuritypolicyid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV49SecurityPolicy.gxTpr_Id), 9, 0)), AV49SecurityPolicy.gxTpr_Name, 0);
            AV63GXV3 = (int)(AV63GXV3+1);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            chkavIsenabledinrepository.Enabled = 0;
            AssignProp("", false, chkavIsenabledinrepository_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Enabled), 5, 0), true);
            cmbavAuthenticationtypename.Enabled = 1;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Enabled), 5, 0), true);
            AV7AuthenticationTypeName = "local";
            AssignAttri("", false, "AV7AuthenticationTypeName", AV7AuthenticationTypeName);
            AV10AuthTypeId = AV6AuthenticationType.gettypebyname(AV7AuthenticationTypeName, out  AV19Errors);
            AssignAttri("", false, "AV10AuthTypeId", AV10AuthTypeId);
            AV47Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            AV56UserNameSpace = AV47Repository.gxTpr_Namespace;
            AssignAttri("", false, "AV56UserNameSpace", AV56UserNameSpace);
            AV17EnableTwoFactorAuthentication = false;
            AssignAttri("", false, "AV17EnableTwoFactorAuthentication", AV17EnableTwoFactorAuthentication);
         }
         else
         {
            AV53User.load( AV55UserId);
            cmbavAuthenticationtypename.Enabled = 0;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Enabled), 5, 0), true);
            AV7AuthenticationTypeName = AV53User.gxTpr_Authenticationtypename;
            AssignAttri("", false, "AV7AuthenticationTypeName", AV7AuthenticationTypeName);
            AV10AuthTypeId = AV6AuthenticationType.gettypebyname(AV7AuthenticationTypeName, out  AV19Errors);
            AssignAttri("", false, "AV10AuthTypeId", AV10AuthTypeId);
            if ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 )
            {
               edtavName_Enabled = 1;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
               imgavImage_Enabled = 1;
               AssignProp("", false, imgavImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgavImage_Enabled), 5, 0), true);
               edtavUrlprofile_Enabled = 0;
               AssignProp("", false, edtavUrlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Enabled), 5, 0), true);
            }
            else
            {
               edtavName_Enabled = 0;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
               imgavImage_Enabled = 0;
               AssignProp("", false, imgavImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgavImage_Enabled), 5, 0), true);
               edtavUrlprofile_Enabled = 1;
               AssignProp("", false, edtavUrlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Enabled), 5, 0), true);
            }
            AV55UserId = AV53User.gxTpr_Guid;
            AssignAttri("", false, "AV55UserId", AV55UserId);
            GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
            AV56UserNameSpace = AV53User.gxTpr_Namespace;
            AssignAttri("", false, "AV56UserNameSpace", AV56UserNameSpace);
            AV36Name = AV53User.gxTpr_Name;
            AssignAttri("", false, "AV36Name", AV36Name);
            AV16Email = AV53User.gxTpr_Email;
            AssignAttri("", false, "AV16Email", AV16Email);
            AV22FirstName = AV53User.gxTpr_Firstname;
            AssignAttri("", false, "AV22FirstName", AV22FirstName);
            AV31LastName = AV53User.gxTpr_Lastname;
            AssignAttri("", false, "AV31LastName", AV31LastName);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53User.gxTpr_Urlimage)) )
            {
               AV25Image = AV53User.gxTpr_Urlimage;
               AssignProp("", false, imgavImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25Image)) ? AV64Image_GXI : context.convertURL( context.PathToRelativeUrl( AV25Image))), true);
               AssignProp("", false, imgavImage_Internalname, "SrcSet", context.GetImageSrcSet( AV25Image), true);
               AV64Image_GXI = GXDbFile.PathToUrl( AV53User.gxTpr_Urlimage, context);
               AssignProp("", false, imgavImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV25Image)) ? AV64Image_GXI : context.convertURL( context.PathToRelativeUrl( AV25Image))), true);
               AssignProp("", false, imgavImage_Internalname, "SrcSet", context.GetImageSrcSet( AV25Image), true);
            }
            AV20ExternalId = AV53User.gxTpr_Externalid;
            AssignAttri("", false, "AV20ExternalId", AV20ExternalId);
            AV11Birthday = AV53User.gxTpr_Birthday;
            AssignAttri("", false, "AV11Birthday", context.localUtil.Format(AV11Birthday, "99/99/9999"));
            AV24Gender = AV53User.gxTpr_Gender;
            AssignAttri("", false, "AV24Gender", AV24Gender);
            AV45Phone = AV53User.gxTpr_Phone;
            AssignAttri("", false, "AV45Phone", AV45Phone);
            AV26IsActive = AV53User.gxTpr_Isactive;
            AssignAttri("", false, "AV26IsActive", AV26IsActive);
            AV5ActivationDate = AV53User.gxTpr_Activationdate;
            AssignAttri("", false, "AV5ActivationDate", context.localUtil.TToC( AV5ActivationDate, 10, 5, 1, 3, "/", ":", " "));
            AV15DontReceiveInformation = AV53User.gxTpr_Dontreceiveinformation;
            AssignAttri("", false, "AV15DontReceiveInformation", AV15DontReceiveInformation);
            AV13CannotChangePassword = AV53User.gxTpr_Cannotchangepassword;
            AssignAttri("", false, "AV13CannotChangePassword", AV13CannotChangePassword);
            AV35MustChangePassword = AV53User.gxTpr_Mustchangepassword;
            AssignAttri("", false, "AV35MustChangePassword", AV35MustChangePassword);
            AV44PasswordNeverExpires = AV53User.gxTpr_Passwordneverexpires;
            AssignAttri("", false, "AV44PasswordNeverExpires", AV44PasswordNeverExpires);
            AV27IsBlocked = AV53User.gxTpr_Isblocked;
            AssignAttri("", false, "AV27IsBlocked", AV27IsBlocked);
            AV50SecurityPolicyId = AV53User.gxTpr_Securitypolicyid;
            AssignAttri("", false, "AV50SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV50SecurityPolicyId), 9, 0));
            AV28IsEnabledInRepository = AV53User.gxTpr_Isenabledinrepository;
            AssignAttri("", false, "AV28IsEnabledInRepository", AV28IsEnabledInRepository);
            AV14DateLastAuthentication = AV53User.gxTpr_Datelastauthentication;
            AssignAttri("", false, "AV14DateLastAuthentication", context.localUtil.TToC( AV14DateLastAuthentication, 10, 5, 1, 3, "/", ":", " "));
            AV17EnableTwoFactorAuthentication = AV53User.gxTpr_Enabletwofactorauthentication;
            AssignAttri("", false, "AV17EnableTwoFactorAuthentication", AV17EnableTwoFactorAuthentication);
            AV37OTPDailyNumberCodes = AV53User.gxTpr_Otpdailynumbercodes;
            AssignAttri("", false, "AV37OTPDailyNumberCodes", StringUtil.LTrimStr( (decimal)(AV37OTPDailyNumberCodes), 4, 0));
            AV38OTPLastDateRequestCode = AV53User.gxTpr_Otplastdaterequestcode;
            AssignAttri("", false, "AV38OTPLastDateRequestCode", context.localUtil.Format(AV38OTPLastDateRequestCode, "99/99/9999"));
            AV39OTPLastLockedDate = DateTimeUtil.ResetTime( AV53User.gxTpr_Otplastlockeddate ) ;
            AssignAttri("", false, "AV39OTPLastLockedDate", context.localUtil.TToC( AV39OTPLastLockedDate, 10, 5, 1, 3, "/", ":", " "));
            AV40OTPNumberLocked = AV53User.gxTpr_Otpnumberlocked;
            AssignAttri("", false, "AV40OTPNumberLocked", StringUtil.LTrimStr( (decimal)(AV40OTPNumberLocked), 3, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            edtavName_Enabled = 0;
            AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
            edtavEmail_Enabled = 0;
            AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
            edtavFirstname_Enabled = 0;
            AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
            edtavLastname_Enabled = 0;
            AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
            edtavUrlprofile_Enabled = 0;
            AssignProp("", false, edtavUrlprofile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Enabled), 5, 0), true);
            edtavExternalid_Enabled = 0;
            AssignProp("", false, edtavExternalid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavExternalid_Enabled), 5, 0), true);
            edtavBirthday_Enabled = 0;
            AssignProp("", false, edtavBirthday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavBirthday_Enabled), 5, 0), true);
            cmbavGender.Enabled = 0;
            AssignProp("", false, cmbavGender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavGender.Enabled), 5, 0), true);
            edtavPhone_Enabled = 0;
            AssignProp("", false, edtavPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPhone_Enabled), 5, 0), true);
            chkavIsactive.Enabled = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
            chkavDontreceiveinformation.Enabled = 0;
            AssignProp("", false, chkavDontreceiveinformation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavDontreceiveinformation.Enabled), 5, 0), true);
            chkavCannotchangepassword.Enabled = 0;
            AssignProp("", false, chkavCannotchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavCannotchangepassword.Enabled), 5, 0), true);
            chkavMustchangepassword.Enabled = 0;
            AssignProp("", false, chkavMustchangepassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavMustchangepassword.Enabled), 5, 0), true);
            chkavIsblocked.Enabled = 0;
            AssignProp("", false, chkavIsblocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsblocked.Enabled), 5, 0), true);
            chkavPasswordneverexpires.Enabled = 0;
            AssignProp("", false, chkavPasswordneverexpires_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavPasswordneverexpires.Enabled), 5, 0), true);
            cmbavSecuritypolicyid.Enabled = 0;
            AssignProp("", false, cmbavSecuritypolicyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSecuritypolicyid.Enabled), 5, 0), true);
            chkavIsenabledinrepository.Enabled = 0;
            AssignProp("", false, chkavIsenabledinrepository_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Enabled), 5, 0), true);
            if ( AV17EnableTwoFactorAuthentication )
            {
               chkavEnabletwofactorauthentication.Enabled = 0;
               AssignProp("", false, chkavEnabletwofactorauthentication_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavEnabletwofactorauthentication.Enabled), 5, 0), true);
               edtavOtpdailynumbercodes_Enabled = 0;
               AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Enabled), 5, 0), true);
               edtavOtplastdaterequestcode_Enabled = 0;
               AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Enabled), 5, 0), true);
               edtavOtplastlockeddate_Enabled = 0;
               AssignProp("", false, edtavOtplastlockeddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Enabled), 5, 0), true);
               edtavOtpnumberlocked_Enabled = 0;
               AssignProp("", false, edtavOtpnumberlocked_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Enabled), 5, 0), true);
            }
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               bttBtnenter_Caption = "Delete";
               AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
            }
            else
            {
               bttBtnenter_Visible = 0;
               AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
            }
         }
         if ( AV26IsActive )
         {
            chkavIsactive.Enabled = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsactive.Enabled), 5, 0), true);
         }
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         chkavUser_isenabledinrepository.Visible = 0;
         AssignProp("", false, chkavUser_isenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUser_isenabledinrepository.Visible), 5, 0), true);
      }

      protected void E131M2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E141M2( )
      {
         /* 'DoSendActivationEmail' Routine */
         returnInSub = false;
         AV53User.load( AV55UserId);
         if ( ! AV53User.gxTpr_Isactive )
         {
            AV54UserActivationKey = AV53User.getnewactivationkey(out  AV19Errors);
            context.CommitDataStores("gamuserentry",pr_default);
            AV32LinkURL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgetaccountactivationurl("");
            new gam_checkuseractivationmethod(context ).execute(  AV55UserId,  AV32LinkURL, out  AV34Messages) ;
            AV65GXV4 = 1;
            while ( AV65GXV4 <= AV34Messages.Count )
            {
               AV33Message = ((GeneXus.Utils.SdtMessages_Message)AV34Messages.Item(AV65GXV4));
               GX_msglist.addItem(AV33Message.gxTpr_Description);
               AV65GXV4 = (int)(AV65GXV4+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53User", AV53User);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV26IsActive && AV23GAMRepository.gxTpr_Email.gxTpr_Sendemailwhenuseractivateaccount ) )
         {
            bttBtnsendactivationemail_Visible = 0;
            AssignProp("", false, bttBtnsendactivationemail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsendactivationemail_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53User.gxTpr_Urlprofile)) && ( StringUtil.StrCmp(AV53User.gxTpr_Authenticationtypename, "GAMLocal") != 0 ) ) ) )
         {
            bttBtnurlprofilego_Visible = 0;
            AssignProp("", false, bttBtnurlprofilego_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnurlprofilego_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV59CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36Name)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "User name", "", "", "", "", "", "", "", ""),  "error",  edtavName_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredemail ) && String.IsNullOrEmpty(StringUtil.RTrim( AV16Email)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Email", "", "", "", "", "", "", "", ""),  "error",  edtavEmail_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredpassword && ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV41Password)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Password", "", "", "", "", "", "", "", ""),  "error",  edtavPassword_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredpassword && ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( AV42PasswordConf)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Conf. password", "", "", "", "", "", "", "", ""),  "error",  edtavPasswordconf_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredfirstname ) && String.IsNullOrEmpty(StringUtil.RTrim( AV22FirstName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "First name", "", "", "", "", "", "", "", ""),  "error",  edtavFirstname_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredlastname ) && String.IsNullOrEmpty(StringUtil.RTrim( AV31LastName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Last name", "", "", "", "", "", "", "", ""),  "error",  edtavLastname_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredbirthday ) && (DateTime.MinValue==AV11Birthday) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Birthday", "", "", "", "", "", "", "", ""),  "error",  edtavBirthday_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredgender ) && String.IsNullOrEmpty(StringUtil.RTrim( AV24Gender)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Gender", "", "", "", "", "", "", "", ""),  "error",  cmbavGender_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
         if ( ( AV23GAMRepository.gxTpr_Requiredphone ) && String.IsNullOrEmpty(StringUtil.RTrim( AV45Phone)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Phone", "", "", "", "", "", "", "", ""),  "error",  edtavPhone_Internalname,  "true",  ""));
            AV59CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV59CheckRequiredFieldsResult", AV59CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( cmbavAuthenticationtypename.ItemCount > 1 ) ) )
         {
            cmbavAuthenticationtypename.Visible = 0;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Visible), 5, 0), true);
            divAuthenticationtypename_cell_Class = "Invisible";
            AssignProp("", false, divAuthenticationtypename_cell_Internalname, "Class", divAuthenticationtypename_cell_Class, true);
         }
         else
         {
            cmbavAuthenticationtypename.Visible = 1;
            AssignProp("", false, cmbavAuthenticationtypename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAuthenticationtypename.Visible), 5, 0), true);
            divAuthenticationtypename_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divAuthenticationtypename_cell_Internalname, "Class", divAuthenticationtypename_cell_Class, true);
         }
         if ( AV23GAMRepository.gxTpr_Requiredemail )
         {
            divEmail_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divEmail_cell_Internalname, "Class", divEmail_cell_Class, true);
         }
         else
         {
            divEmail_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divEmail_cell_Internalname, "Class", divEmail_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) )
         {
            edtavPassword_Visible = 0;
            AssignProp("", false, edtavPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword_Visible), 5, 0), true);
            divPassword_cell_Class = "Invisible";
            AssignProp("", false, divPassword_cell_Internalname, "Class", divPassword_cell_Class, true);
         }
         else
         {
            edtavPassword_Visible = 1;
            AssignProp("", false, edtavPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPassword_Visible), 5, 0), true);
            if ( AV23GAMRepository.gxTpr_Requiredpassword && ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) )
            {
               divPassword_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
               AssignProp("", false, divPassword_cell_Internalname, "Class", divPassword_cell_Class, true);
            }
            else
            {
               divPassword_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
               AssignProp("", false, divPassword_cell_Internalname, "Class", divPassword_cell_Class, true);
            }
         }
         if ( ! ( ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) )
         {
            edtavPasswordconf_Visible = 0;
            AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
            divPasswordconf_cell_Class = "Invisible";
            AssignProp("", false, divPasswordconf_cell_Internalname, "Class", divPasswordconf_cell_Class, true);
         }
         else
         {
            edtavPasswordconf_Visible = 1;
            AssignProp("", false, edtavPasswordconf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Visible), 5, 0), true);
            if ( AV23GAMRepository.gxTpr_Requiredpassword && ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 ) )
            {
               divPasswordconf_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
               AssignProp("", false, divPasswordconf_cell_Internalname, "Class", divPasswordconf_cell_Class, true);
            }
            else
            {
               divPasswordconf_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
               AssignProp("", false, divPasswordconf_cell_Internalname, "Class", divPasswordconf_cell_Class, true);
            }
         }
         if ( AV23GAMRepository.gxTpr_Requiredfirstname )
         {
            divFirstname_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divFirstname_cell_Internalname, "Class", divFirstname_cell_Class, true);
         }
         else
         {
            divFirstname_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divFirstname_cell_Internalname, "Class", divFirstname_cell_Class, true);
         }
         if ( AV23GAMRepository.gxTpr_Requiredlastname )
         {
            divLastname_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divLastname_cell_Internalname, "Class", divLastname_cell_Class, true);
         }
         else
         {
            divLastname_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divLastname_cell_Internalname, "Class", divLastname_cell_Class, true);
         }
         if ( AV23GAMRepository.gxTpr_Requiredbirthday )
         {
            divBirthday_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divBirthday_cell_Internalname, "Class", divBirthday_cell_Class, true);
         }
         else
         {
            divBirthday_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divBirthday_cell_Internalname, "Class", divBirthday_cell_Class, true);
         }
         if ( AV23GAMRepository.gxTpr_Requiredgender )
         {
            divGender_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divGender_cell_Internalname, "Class", divGender_cell_Class, true);
         }
         else
         {
            divGender_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divGender_cell_Internalname, "Class", divGender_cell_Class, true);
         }
         if ( AV23GAMRepository.gxTpr_Requiredphone )
         {
            divPhone_cell_Class = "col-xs-12 col-sm-6 RequiredDataContentCell DscTop";
            AssignProp("", false, divPhone_cell_Internalname, "Class", divPhone_cell_Class, true);
         }
         else
         {
            divPhone_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divPhone_cell_Internalname, "Class", divPhone_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV53User.gxTpr_Urlimage)) ) )
         {
            imgavImage_Visible = 0;
            AssignProp("", false, imgavImage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavImage_Visible), 5, 0), true);
            divImage_cell_Class = "Invisible";
            AssignProp("", false, divImage_cell_Internalname, "Class", divImage_cell_Class, true);
         }
         else
         {
            imgavImage_Visible = 1;
            AssignProp("", false, imgavImage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavImage_Visible), 5, 0), true);
            divImage_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divImage_cell_Internalname, "Class", divImage_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            chkavIsactive.Visible = 0;
            AssignProp("", false, chkavIsactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsactive.Visible), 5, 0), true);
            divIsactive_cell_Class = "Invisible";
            AssignProp("", false, divIsactive_cell_Internalname, "Class", divIsactive_cell_Class, true);
         }
         else
         {
            chkavIsactive.Visible = 1;
            AssignProp("", false, chkavIsactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsactive.Visible), 5, 0), true);
            divIsactive_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divIsactive_cell_Internalname, "Class", divIsactive_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            chkavIsenabledinrepository.Visible = 0;
            AssignProp("", false, chkavIsenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Visible), 5, 0), true);
            divIsenabledinrepository_cell_Class = "Invisible";
            AssignProp("", false, divIsenabledinrepository_cell_Internalname, "Class", divIsenabledinrepository_cell_Class, true);
         }
         else
         {
            chkavIsenabledinrepository.Visible = 1;
            AssignProp("", false, chkavIsenabledinrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsenabledinrepository.Visible), 5, 0), true);
            divIsenabledinrepository_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divIsenabledinrepository_cell_Internalname, "Class", divIsenabledinrepository_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            edtavDatelastauthentication_Visible = 0;
            AssignProp("", false, edtavDatelastauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDatelastauthentication_Visible), 5, 0), true);
            divDatelastauthentication_cell_Class = "Invisible";
            AssignProp("", false, divDatelastauthentication_cell_Internalname, "Class", divDatelastauthentication_cell_Class, true);
         }
         else
         {
            edtavDatelastauthentication_Visible = 1;
            AssignProp("", false, edtavDatelastauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDatelastauthentication_Visible), 5, 0), true);
            divDatelastauthentication_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divDatelastauthentication_cell_Internalname, "Class", divDatelastauthentication_cell_Class, true);
         }
         if ( ! ( AV23GAMRepository.istwofactorauthenticationenabled() ) )
         {
            chkavEnabletwofactorauthentication.Visible = 0;
            AssignProp("", false, chkavEnabletwofactorauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavEnabletwofactorauthentication.Visible), 5, 0), true);
            divEnabletwofactorauthentication_cell_Class = "Invisible";
            AssignProp("", false, divEnabletwofactorauthentication_cell_Internalname, "Class", divEnabletwofactorauthentication_cell_Class, true);
         }
         else
         {
            chkavEnabletwofactorauthentication.Visible = 1;
            AssignProp("", false, chkavEnabletwofactorauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavEnabletwofactorauthentication.Visible), 5, 0), true);
            divEnabletwofactorauthentication_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divEnabletwofactorauthentication_cell_Internalname, "Class", divEnabletwofactorauthentication_cell_Class, true);
         }
         if ( ! ( AV23GAMRepository.isonetimepasswordenabled() ) )
         {
            edtavOtpnumberlocked_Visible = 0;
            AssignProp("", false, edtavOtpnumberlocked_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Visible), 5, 0), true);
            divOtpnumberlocked_cell_Class = "Invisible";
            AssignProp("", false, divOtpnumberlocked_cell_Internalname, "Class", divOtpnumberlocked_cell_Class, true);
         }
         else
         {
            edtavOtpnumberlocked_Visible = 1;
            AssignProp("", false, edtavOtpnumberlocked_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtpnumberlocked_Visible), 5, 0), true);
            divOtpnumberlocked_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divOtpnumberlocked_cell_Internalname, "Class", divOtpnumberlocked_cell_Class, true);
         }
         if ( ! ( AV23GAMRepository.isonetimepasswordenabled() ) )
         {
            edtavOtplastlockeddate_Visible = 0;
            AssignProp("", false, edtavOtplastlockeddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Visible), 5, 0), true);
            divOtplastlockeddate_cell_Class = "Invisible";
            AssignProp("", false, divOtplastlockeddate_cell_Internalname, "Class", divOtplastlockeddate_cell_Class, true);
         }
         else
         {
            edtavOtplastlockeddate_Visible = 1;
            AssignProp("", false, edtavOtplastlockeddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtplastlockeddate_Visible), 5, 0), true);
            divOtplastlockeddate_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divOtplastlockeddate_cell_Internalname, "Class", divOtplastlockeddate_cell_Class, true);
         }
         if ( ! ( AV23GAMRepository.isonetimepasswordenabled() ) )
         {
            edtavOtpdailynumbercodes_Visible = 0;
            AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Visible), 5, 0), true);
            divOtpdailynumbercodes_cell_Class = "Invisible";
            AssignProp("", false, divOtpdailynumbercodes_cell_Internalname, "Class", divOtpdailynumbercodes_cell_Class, true);
         }
         else
         {
            edtavOtpdailynumbercodes_Visible = 1;
            AssignProp("", false, edtavOtpdailynumbercodes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtpdailynumbercodes_Visible), 5, 0), true);
            divOtpdailynumbercodes_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divOtpdailynumbercodes_cell_Internalname, "Class", divOtpdailynumbercodes_cell_Class, true);
         }
         if ( ! ( AV23GAMRepository.isonetimepasswordenabled() ) )
         {
            edtavOtplastdaterequestcode_Visible = 0;
            AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Visible), 5, 0), true);
            divOtplastdaterequestcode_cell_Class = "Invisible";
            AssignProp("", false, divOtplastdaterequestcode_cell_Internalname, "Class", divOtplastdaterequestcode_cell_Class, true);
         }
         else
         {
            edtavOtplastdaterequestcode_Visible = 1;
            AssignProp("", false, edtavOtplastdaterequestcode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOtplastdaterequestcode_Visible), 5, 0), true);
            divOtplastdaterequestcode_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divOtplastdaterequestcode_cell_Internalname, "Class", divOtplastdaterequestcode_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) ) )
         {
            edtavActivationdate_Visible = 0;
            AssignProp("", false, edtavActivationdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Visible), 5, 0), true);
            divActivationdate_cell_Class = "Invisible";
            AssignProp("", false, divActivationdate_cell_Internalname, "Class", divActivationdate_cell_Class, true);
         }
         else
         {
            edtavActivationdate_Visible = 1;
            AssignProp("", false, edtavActivationdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavActivationdate_Visible), 5, 0), true);
            divActivationdate_cell_Class = "DataContentCell DscTop";
            AssignProp("", false, divActivationdate_cell_Internalname, "Class", divActivationdate_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) && ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") != 0 ) ) )
         {
            edtavUrlprofile_Visible = 0;
            AssignProp("", false, edtavUrlprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Visible), 5, 0), true);
            divUrlprofile_cell_Class = "Invisible";
            AssignProp("", false, divUrlprofile_cell_Internalname, "Class", divUrlprofile_cell_Class, true);
         }
         else
         {
            edtavUrlprofile_Visible = 1;
            AssignProp("", false, edtavUrlprofile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUrlprofile_Visible), 5, 0), true);
            divUrlprofile_cell_Class = "DataContentCell DscTop";
            AssignProp("", false, divUrlprofile_cell_Internalname, "Class", divUrlprofile_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E151M2 ();
         if (returnInSub) return;
      }

      protected void E151M2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV59CheckRequiredFieldsResult )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               AV53User.load( AV55UserId);
            }
            AV43PasswordIsOK = true;
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
               {
                  AV10AuthTypeId = AV6AuthenticationType.gettypebyname(AV7AuthenticationTypeName, out  AV19Errors);
                  AssignAttri("", false, "AV10AuthTypeId", AV10AuthTypeId);
                  AV28IsEnabledInRepository = true;
                  AssignAttri("", false, "AV28IsEnabledInRepository", AV28IsEnabledInRepository);
                  if ( StringUtil.StrCmp(AV10AuthTypeId, "GAMLocal") == 0 )
                  {
                     if ( StringUtil.StrCmp(AV41Password, AV42PasswordConf) != 0 )
                     {
                        AV43PasswordIsOK = false;
                        GX_msglist.addItem("The password and confirmation password does not match.");
                     }
                  }
                  else
                  {
                     AV41Password = "";
                     AssignAttri("", false, "AV41Password", AV41Password);
                  }
               }
               if ( AV43PasswordIsOK )
               {
                  AV53User.gxTpr_Authenticationtypename = AV7AuthenticationTypeName;
                  AV53User.gxTpr_Name = AV36Name;
                  AV53User.gxTpr_Email = AV16Email;
                  AV53User.gxTpr_Firstname = AV22FirstName;
                  AV53User.gxTpr_Lastname = AV31LastName;
                  AV53User.gxTpr_Password = AV41Password;
                  AV53User.gxTpr_Externalid = AV20ExternalId;
                  AV53User.gxTpr_Birthday = AV11Birthday;
                  AV53User.gxTpr_Phone = AV45Phone;
                  AV53User.gxTpr_Gender = AV24Gender;
                  AV53User.gxTpr_Isactive = AV26IsActive;
                  AV12BlobPhoto = AV46Photo;
                  AV53User.gxTpr_Urlprofile = AV52URLProfile;
                  AV53User.gxTpr_Dontreceiveinformation = AV15DontReceiveInformation;
                  AV53User.gxTpr_Cannotchangepassword = AV13CannotChangePassword;
                  AV53User.gxTpr_Mustchangepassword = AV35MustChangePassword;
                  AV53User.gxTpr_Isblocked = AV27IsBlocked;
                  AV53User.gxTpr_Passwordneverexpires = AV44PasswordNeverExpires;
                  AV53User.gxTpr_Securitypolicyid = AV50SecurityPolicyId;
                  AV53User.gxTpr_Enabletwofactorauthentication = AV17EnableTwoFactorAuthentication;
                  AV53User.save();
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV53User.delete();
            }
            if ( AV43PasswordIsOK )
            {
               if ( AV53User.success() )
               {
                  context.CommitDataStores("gamuserentry",pr_default);
                  AV29isOK = true;
                  if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
                  {
                     if ( AV28IsEnabledInRepository != AV53User.gxTpr_Isenabledinrepository )
                     {
                        if ( AV28IsEnabledInRepository )
                        {
                           AV29isOK = AV53User.repositoryenable(out  AV19Errors);
                        }
                        else
                        {
                           AV29isOK = AV53User.repositorydisable(out  AV19Errors);
                        }
                     }
                  }
                  if ( AV29isOK )
                  {
                     context.CommitDataStores("gamuserentry",pr_default);
                     if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
                     {
                        CallWebObject(formatLink("gamwwusers.aspx") );
                        context.wjLocDisableFrm = 1;
                     }
                     else
                     {
                        context.setWebReturnParms(new Object[] {(string)Gx_mode,(string)AV55UserId});
                        context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV55UserId"});
                        context.wjLocDisableFrm = 1;
                        context.nUserReturn = 1;
                        returnInSub = true;
                        if (true) return;
                     }
                  }
                  else
                  {
                     AV66GXV5 = 1;
                     while ( AV66GXV5 <= AV19Errors.Count )
                     {
                        AV18Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV19Errors.Item(AV66GXV5));
                        GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV18Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV18Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                        AV66GXV5 = (int)(AV66GXV5+1);
                     }
                  }
               }
               else
               {
                  AV19Errors = AV53User.geterrors();
                  AV67GXV6 = 1;
                  while ( AV67GXV6 <= AV19Errors.Count )
                  {
                     AV18Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV19Errors.Item(AV67GXV6));
                     GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV18Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV18Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                     AV67GXV6 = (int)(AV67GXV6+1);
                  }
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV53User", AV53User);
      }

      protected void E161M2( )
      {
         /* Authenticationtypename_Isvalid Routine */
         returnInSub = false;
         AV10AuthTypeId = AV6AuthenticationType.gettypebyname(AV7AuthenticationTypeName, out  AV19Errors);
         AssignAttri("", false, "AV10AuthTypeId", AV10AuthTypeId);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E171M2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV55UserId = (string)getParm(obj,1);
         AssignAttri("", false, "AV55UserId", AV55UserId);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55UserId, "")), context));
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
         PA1M2( ) ;
         WS1M2( ) ;
         WE1M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256275283251", true, true);
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
         context.AddJavascriptSource("gamuserentry.js", "?20256275283257", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavAuthenticationtypename.Name = "vAUTHENTICATIONTYPENAME";
         cmbavAuthenticationtypename.WebTags = "";
         if ( cmbavAuthenticationtypename.ItemCount > 0 )
         {
            AV7AuthenticationTypeName = cmbavAuthenticationtypename.getValidValue(AV7AuthenticationTypeName);
            AssignAttri("", false, "AV7AuthenticationTypeName", AV7AuthenticationTypeName);
         }
         cmbavGender.Name = "vGENDER";
         cmbavGender.WebTags = "";
         cmbavGender.addItem("N", "Not Specified", 0);
         cmbavGender.addItem("F", "Female", 0);
         cmbavGender.addItem("M", "Male", 0);
         if ( cmbavGender.ItemCount > 0 )
         {
            AV24Gender = cmbavGender.getValidValue(AV24Gender);
            AssignAttri("", false, "AV24Gender", AV24Gender);
         }
         chkavIsactive.Name = "vISACTIVE";
         chkavIsactive.WebTags = "";
         chkavIsactive.Caption = " ";
         AssignProp("", false, chkavIsactive_Internalname, "TitleCaption", chkavIsactive.Caption, true);
         chkavIsactive.CheckedValue = "false";
         AV26IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV26IsActive));
         AssignAttri("", false, "AV26IsActive", AV26IsActive);
         chkavDontreceiveinformation.Name = "vDONTRECEIVEINFORMATION";
         chkavDontreceiveinformation.WebTags = "";
         chkavDontreceiveinformation.Caption = " ";
         AssignProp("", false, chkavDontreceiveinformation_Internalname, "TitleCaption", chkavDontreceiveinformation.Caption, true);
         chkavDontreceiveinformation.CheckedValue = "false";
         AV15DontReceiveInformation = StringUtil.StrToBool( StringUtil.BoolToStr( AV15DontReceiveInformation));
         AssignAttri("", false, "AV15DontReceiveInformation", AV15DontReceiveInformation);
         chkavCannotchangepassword.Name = "vCANNOTCHANGEPASSWORD";
         chkavCannotchangepassword.WebTags = "";
         chkavCannotchangepassword.Caption = " ";
         AssignProp("", false, chkavCannotchangepassword_Internalname, "TitleCaption", chkavCannotchangepassword.Caption, true);
         chkavCannotchangepassword.CheckedValue = "false";
         AV13CannotChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV13CannotChangePassword));
         AssignAttri("", false, "AV13CannotChangePassword", AV13CannotChangePassword);
         chkavMustchangepassword.Name = "vMUSTCHANGEPASSWORD";
         chkavMustchangepassword.WebTags = "";
         chkavMustchangepassword.Caption = " ";
         AssignProp("", false, chkavMustchangepassword_Internalname, "TitleCaption", chkavMustchangepassword.Caption, true);
         chkavMustchangepassword.CheckedValue = "false";
         AV35MustChangePassword = StringUtil.StrToBool( StringUtil.BoolToStr( AV35MustChangePassword));
         AssignAttri("", false, "AV35MustChangePassword", AV35MustChangePassword);
         chkavPasswordneverexpires.Name = "vPASSWORDNEVEREXPIRES";
         chkavPasswordneverexpires.WebTags = "";
         chkavPasswordneverexpires.Caption = " ";
         AssignProp("", false, chkavPasswordneverexpires_Internalname, "TitleCaption", chkavPasswordneverexpires.Caption, true);
         chkavPasswordneverexpires.CheckedValue = "false";
         AV44PasswordNeverExpires = StringUtil.StrToBool( StringUtil.BoolToStr( AV44PasswordNeverExpires));
         AssignAttri("", false, "AV44PasswordNeverExpires", AV44PasswordNeverExpires);
         chkavIsblocked.Name = "vISBLOCKED";
         chkavIsblocked.WebTags = "";
         chkavIsblocked.Caption = " ";
         AssignProp("", false, chkavIsblocked_Internalname, "TitleCaption", chkavIsblocked.Caption, true);
         chkavIsblocked.CheckedValue = "false";
         AV27IsBlocked = StringUtil.StrToBool( StringUtil.BoolToStr( AV27IsBlocked));
         AssignAttri("", false, "AV27IsBlocked", AV27IsBlocked);
         cmbavSecuritypolicyid.Name = "vSECURITYPOLICYID";
         cmbavSecuritypolicyid.WebTags = "";
         if ( cmbavSecuritypolicyid.ItemCount > 0 )
         {
            AV50SecurityPolicyId = (int)(Math.Round(NumberUtil.Val( cmbavSecuritypolicyid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV50SecurityPolicyId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV50SecurityPolicyId", StringUtil.LTrimStr( (decimal)(AV50SecurityPolicyId), 9, 0));
         }
         chkavIsenabledinrepository.Name = "vISENABLEDINREPOSITORY";
         chkavIsenabledinrepository.WebTags = "";
         chkavIsenabledinrepository.Caption = " ";
         AssignProp("", false, chkavIsenabledinrepository_Internalname, "TitleCaption", chkavIsenabledinrepository.Caption, true);
         chkavIsenabledinrepository.CheckedValue = "false";
         AV28IsEnabledInRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV28IsEnabledInRepository));
         AssignAttri("", false, "AV28IsEnabledInRepository", AV28IsEnabledInRepository);
         chkavEnabletwofactorauthentication.Name = "vENABLETWOFACTORAUTHENTICATION";
         chkavEnabletwofactorauthentication.WebTags = "";
         chkavEnabletwofactorauthentication.Caption = " ";
         AssignProp("", false, chkavEnabletwofactorauthentication_Internalname, "TitleCaption", chkavEnabletwofactorauthentication.Caption, true);
         chkavEnabletwofactorauthentication.CheckedValue = "false";
         AV17EnableTwoFactorAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV17EnableTwoFactorAuthentication));
         AssignAttri("", false, "AV17EnableTwoFactorAuthentication", AV17EnableTwoFactorAuthentication);
         chkavUser_isenabledinrepository.Name = "USER_ISENABLEDINREPOSITORY";
         chkavUser_isenabledinrepository.WebTags = "";
         chkavUser_isenabledinrepository.Caption = "";
         AssignProp("", false, chkavUser_isenabledinrepository_Internalname, "TitleCaption", chkavUser_isenabledinrepository.Caption, true);
         chkavUser_isenabledinrepository.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtavUserid_Internalname = "vUSERID";
         edtavUsernamespace_Internalname = "vUSERNAMESPACE";
         cmbavAuthenticationtypename_Internalname = "vAUTHENTICATIONTYPENAME";
         divAuthenticationtypename_cell_Internalname = "AUTHENTICATIONTYPENAME_CELL";
         edtavName_Internalname = "vNAME";
         edtavEmail_Internalname = "vEMAIL";
         divEmail_cell_Internalname = "EMAIL_CELL";
         edtavPassword_Internalname = "vPASSWORD";
         divPassword_cell_Internalname = "PASSWORD_CELL";
         edtavPasswordconf_Internalname = "vPASSWORDCONF";
         divPasswordconf_cell_Internalname = "PASSWORDCONF_CELL";
         edtavFirstname_Internalname = "vFIRSTNAME";
         divFirstname_cell_Internalname = "FIRSTNAME_CELL";
         edtavLastname_Internalname = "vLASTNAME";
         divLastname_cell_Internalname = "LASTNAME_CELL";
         edtavExternalid_Internalname = "vEXTERNALID";
         edtavBirthday_Internalname = "vBIRTHDAY";
         divBirthday_cell_Internalname = "BIRTHDAY_CELL";
         cmbavGender_Internalname = "vGENDER";
         divGender_cell_Internalname = "GENDER_CELL";
         edtavPhone_Internalname = "vPHONE";
         divPhone_cell_Internalname = "PHONE_CELL";
         lblTextblockurlprofile_Internalname = "TEXTBLOCKURLPROFILE";
         edtavUrlprofile_Internalname = "vURLPROFILE";
         divUnnamedtableurlprofile_Internalname = "UNNAMEDTABLEURLPROFILE";
         divUrlprofile_cell_Internalname = "URLPROFILE_CELL";
         bttBtnurlprofilego_Internalname = "BTNURLPROFILEGO";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         imgavImage_Internalname = "vIMAGE";
         divImage_cell_Internalname = "IMAGE_CELL";
         chkavIsactive_Internalname = "vISACTIVE";
         divIsactive_cell_Internalname = "ISACTIVE_CELL";
         lblTextblockactivationdate_Internalname = "TEXTBLOCKACTIVATIONDATE";
         edtavActivationdate_Internalname = "vACTIVATIONDATE";
         divUnnamedtableactivationdate_Internalname = "UNNAMEDTABLEACTIVATIONDATE";
         divActivationdate_cell_Internalname = "ACTIVATIONDATE_CELL";
         bttBtnsendactivationemail_Internalname = "BTNSENDACTIVATIONEMAIL";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         chkavDontreceiveinformation_Internalname = "vDONTRECEIVEINFORMATION";
         chkavCannotchangepassword_Internalname = "vCANNOTCHANGEPASSWORD";
         chkavMustchangepassword_Internalname = "vMUSTCHANGEPASSWORD";
         chkavPasswordneverexpires_Internalname = "vPASSWORDNEVEREXPIRES";
         chkavIsblocked_Internalname = "vISBLOCKED";
         cmbavSecuritypolicyid_Internalname = "vSECURITYPOLICYID";
         chkavIsenabledinrepository_Internalname = "vISENABLEDINREPOSITORY";
         divIsenabledinrepository_cell_Internalname = "ISENABLEDINREPOSITORY_CELL";
         edtavDatelastauthentication_Internalname = "vDATELASTAUTHENTICATION";
         divDatelastauthentication_cell_Internalname = "DATELASTAUTHENTICATION_CELL";
         chkavEnabletwofactorauthentication_Internalname = "vENABLETWOFACTORAUTHENTICATION";
         divEnabletwofactorauthentication_cell_Internalname = "ENABLETWOFACTORAUTHENTICATION_CELL";
         edtavOtpnumberlocked_Internalname = "vOTPNUMBERLOCKED";
         divOtpnumberlocked_cell_Internalname = "OTPNUMBERLOCKED_CELL";
         edtavOtplastlockeddate_Internalname = "vOTPLASTLOCKEDDATE";
         divOtplastlockeddate_cell_Internalname = "OTPLASTLOCKEDDATE_CELL";
         edtavOtpdailynumbercodes_Internalname = "vOTPDAILYNUMBERCODES";
         divOtpdailynumbercodes_cell_Internalname = "OTPDAILYNUMBERCODES_CELL";
         edtavOtplastdaterequestcode_Internalname = "vOTPLASTDATEREQUESTCODE";
         divOtplastdaterequestcode_cell_Internalname = "OTPLASTDATEREQUESTCODE_CELL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         chkavUser_isenabledinrepository_Internalname = "USER_ISENABLEDINREPOSITORY";
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
         chkavUser_isenabledinrepository.Caption = "";
         chkavEnabletwofactorauthentication.Caption = " ";
         chkavIsenabledinrepository.Caption = " ";
         chkavIsblocked.Caption = " ";
         chkavPasswordneverexpires.Caption = " ";
         chkavMustchangepassword.Caption = " ";
         chkavCannotchangepassword.Caption = " ";
         chkavDontreceiveinformation.Caption = " ";
         chkavIsactive.Caption = " ";
         chkavUser_isenabledinrepository.Visible = 1;
         bttBtnenter_Caption = "Confirm";
         bttBtnenter_Visible = 1;
         edtavOtplastdaterequestcode_Jsonclick = "";
         edtavOtplastdaterequestcode_Enabled = 1;
         edtavOtplastdaterequestcode_Visible = 1;
         divOtplastdaterequestcode_cell_Class = "col-xs-12 col-sm-6";
         edtavOtpdailynumbercodes_Jsonclick = "";
         edtavOtpdailynumbercodes_Enabled = 1;
         edtavOtpdailynumbercodes_Visible = 1;
         divOtpdailynumbercodes_cell_Class = "col-xs-12 col-sm-6";
         edtavOtplastlockeddate_Jsonclick = "";
         edtavOtplastlockeddate_Enabled = 1;
         edtavOtplastlockeddate_Visible = 1;
         divOtplastlockeddate_cell_Class = "col-xs-12 col-sm-6";
         edtavOtpnumberlocked_Jsonclick = "";
         edtavOtpnumberlocked_Enabled = 1;
         edtavOtpnumberlocked_Visible = 1;
         divOtpnumberlocked_cell_Class = "col-xs-12 col-sm-6";
         chkavEnabletwofactorauthentication.Enabled = 1;
         chkavEnabletwofactorauthentication.Visible = 1;
         divEnabletwofactorauthentication_cell_Class = "col-xs-12 col-sm-6";
         edtavDatelastauthentication_Jsonclick = "";
         edtavDatelastauthentication_Enabled = 1;
         edtavDatelastauthentication_Visible = 1;
         divDatelastauthentication_cell_Class = "col-xs-12 col-sm-6";
         chkavIsenabledinrepository.Enabled = 1;
         chkavIsenabledinrepository.Visible = 1;
         divIsenabledinrepository_cell_Class = "col-xs-12 col-sm-6";
         cmbavSecuritypolicyid_Jsonclick = "";
         cmbavSecuritypolicyid.Enabled = 1;
         chkavIsblocked.Enabled = 1;
         chkavPasswordneverexpires.Enabled = 1;
         chkavMustchangepassword.Enabled = 1;
         chkavCannotchangepassword.Enabled = 1;
         chkavDontreceiveinformation.Enabled = 1;
         bttBtnsendactivationemail_Visible = 1;
         edtavActivationdate_Jsonclick = "";
         edtavActivationdate_Enabled = 1;
         edtavActivationdate_Visible = 1;
         divActivationdate_cell_Class = "";
         chkavIsactive.Enabled = 1;
         chkavIsactive.Visible = 1;
         divIsactive_cell_Class = "col-xs-12 col-sm-6";
         imgavImage_gximage = "";
         imgavImage_Enabled = 0;
         imgavImage_Visible = 1;
         divImage_cell_Class = "col-xs-12 col-sm-6";
         bttBtnurlprofilego_Visible = 1;
         edtavUrlprofile_Jsonclick = "";
         edtavUrlprofile_Enabled = 1;
         edtavUrlprofile_Visible = 1;
         divUrlprofile_cell_Class = "";
         edtavPhone_Jsonclick = "";
         edtavPhone_Enabled = 1;
         divPhone_cell_Class = "col-xs-12 col-sm-6";
         cmbavGender_Jsonclick = "";
         cmbavGender.Enabled = 1;
         divGender_cell_Class = "col-xs-12 col-sm-6";
         edtavBirthday_Jsonclick = "";
         edtavBirthday_Enabled = 1;
         divBirthday_cell_Class = "col-xs-12 col-sm-6";
         edtavExternalid_Jsonclick = "";
         edtavExternalid_Enabled = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         divLastname_cell_Class = "col-xs-12 col-sm-6";
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         divFirstname_cell_Class = "col-xs-12 col-sm-6";
         edtavPasswordconf_Jsonclick = "";
         edtavPasswordconf_Enabled = 1;
         edtavPasswordconf_Visible = 1;
         divPasswordconf_cell_Class = "col-xs-12 col-sm-6";
         edtavPassword_Jsonclick = "";
         edtavPassword_Enabled = 1;
         edtavPassword_Visible = 1;
         divPassword_cell_Class = "col-xs-12 col-sm-6";
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         divEmail_cell_Class = "col-xs-12 col-sm-6";
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         cmbavAuthenticationtypename_Jsonclick = "";
         cmbavAuthenticationtypename.Enabled = 1;
         cmbavAuthenticationtypename.Visible = 1;
         divAuthenticationtypename_cell_Class = "col-xs-12 col-sm-6";
         edtavUsernamespace_Jsonclick = "";
         edtavUsernamespace_Enabled = 1;
         edtavUserid_Jsonclick = "";
         edtavUserid_Enabled = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "User ";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV26IsActive","fld":"vISACTIVE"},{"av":"AV15DontReceiveInformation","fld":"vDONTRECEIVEINFORMATION"},{"av":"AV13CannotChangePassword","fld":"vCANNOTCHANGEPASSWORD"},{"av":"AV35MustChangePassword","fld":"vMUSTCHANGEPASSWORD"},{"av":"AV44PasswordNeverExpires","fld":"vPASSWORDNEVEREXPIRES"},{"av":"AV27IsBlocked","fld":"vISBLOCKED"},{"av":"AV28IsEnabledInRepository","fld":"vISENABLEDINREPOSITORY"},{"av":"AV17EnableTwoFactorAuthentication","fld":"vENABLETWOFACTORAUTHENTICATION"},{"av":"GXV1","fld":"USER_ISENABLEDINREPOSITORY"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV55UserId","fld":"vUSERID","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNSENDACTIVATIONEMAIL","prop":"Visible"},{"ctrl":"BTNURLPROFILEGO","prop":"Visible"}]}""");
         setEventMetadata("'DOSENDACTIVATIONEMAIL'","""{"handler":"E141M2","iparms":[{"av":"AV55UserId","fld":"vUSERID","hsh":true}]}""");
         setEventMetadata("'DOURLPROFILEGO'","""{"handler":"E111M1","iparms":[{"av":"AV52URLProfile","fld":"vURLPROFILE"}]}""");
         setEventMetadata("ENTER","""{"handler":"E151M2","iparms":[{"av":"AV59CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV55UserId","fld":"vUSERID","hsh":true},{"av":"cmbavAuthenticationtypename"},{"av":"AV7AuthenticationTypeName","fld":"vAUTHENTICATIONTYPENAME"},{"av":"AV41Password","fld":"vPASSWORD"},{"av":"AV42PasswordConf","fld":"vPASSWORDCONF"},{"av":"AV36Name","fld":"vNAME"},{"av":"AV16Email","fld":"vEMAIL"},{"av":"AV22FirstName","fld":"vFIRSTNAME"},{"av":"AV31LastName","fld":"vLASTNAME"},{"av":"AV20ExternalId","fld":"vEXTERNALID"},{"av":"AV11Birthday","fld":"vBIRTHDAY"},{"av":"AV45Phone","fld":"vPHONE"},{"av":"cmbavGender"},{"av":"AV24Gender","fld":"vGENDER"},{"av":"AV26IsActive","fld":"vISACTIVE"},{"av":"AV46Photo","fld":"vPHOTO"},{"av":"AV52URLProfile","fld":"vURLPROFILE"},{"av":"AV15DontReceiveInformation","fld":"vDONTRECEIVEINFORMATION"},{"av":"AV13CannotChangePassword","fld":"vCANNOTCHANGEPASSWORD"},{"av":"AV35MustChangePassword","fld":"vMUSTCHANGEPASSWORD"},{"av":"AV27IsBlocked","fld":"vISBLOCKED"},{"av":"AV44PasswordNeverExpires","fld":"vPASSWORDNEVEREXPIRES"},{"av":"cmbavSecuritypolicyid"},{"av":"AV50SecurityPolicyId","fld":"vSECURITYPOLICYID","pic":"ZZZZZZZZ9"},{"av":"AV17EnableTwoFactorAuthentication","fld":"vENABLETWOFACTORAUTHENTICATION"},{"av":"AV28IsEnabledInRepository","fld":"vISENABLEDINREPOSITORY"},{"av":"AV10AuthTypeId","fld":"vAUTHTYPEID"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV10AuthTypeId","fld":"vAUTHTYPEID"},{"av":"AV28IsEnabledInRepository","fld":"vISENABLEDINREPOSITORY"},{"av":"AV41Password","fld":"vPASSWORD"},{"av":"AV59CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VAUTHENTICATIONTYPENAME.ISVALID","""{"handler":"E161M2","iparms":[{"av":"cmbavAuthenticationtypename"},{"av":"AV7AuthenticationTypeName","fld":"vAUTHENTICATIONTYPENAME"},{"av":"AV10AuthTypeId","fld":"vAUTHTYPEID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true}]""");
         setEventMetadata("VAUTHENTICATIONTYPENAME.ISVALID",""","oparms":[{"av":"AV10AuthTypeId","fld":"vAUTHTYPEID"},{"av":"cmbavAuthenticationtypename"},{"av":"divAuthenticationtypename_cell_Class","ctrl":"AUTHENTICATIONTYPENAME_CELL","prop":"Class"},{"av":"divEmail_cell_Class","ctrl":"EMAIL_CELL","prop":"Class"},{"av":"edtavPassword_Visible","ctrl":"vPASSWORD","prop":"Visible"},{"av":"divPassword_cell_Class","ctrl":"PASSWORD_CELL","prop":"Class"},{"av":"edtavPasswordconf_Visible","ctrl":"vPASSWORDCONF","prop":"Visible"},{"av":"divPasswordconf_cell_Class","ctrl":"PASSWORDCONF_CELL","prop":"Class"},{"av":"divFirstname_cell_Class","ctrl":"FIRSTNAME_CELL","prop":"Class"},{"av":"divLastname_cell_Class","ctrl":"LASTNAME_CELL","prop":"Class"},{"av":"divBirthday_cell_Class","ctrl":"BIRTHDAY_CELL","prop":"Class"},{"av":"divGender_cell_Class","ctrl":"GENDER_CELL","prop":"Class"},{"av":"divPhone_cell_Class","ctrl":"PHONE_CELL","prop":"Class"},{"av":"imgavImage_Visible","ctrl":"vIMAGE","prop":"Visible"},{"av":"divImage_cell_Class","ctrl":"IMAGE_CELL","prop":"Class"},{"av":"chkavIsactive.Visible","ctrl":"vISACTIVE","prop":"Visible"},{"av":"divIsactive_cell_Class","ctrl":"ISACTIVE_CELL","prop":"Class"},{"av":"chkavIsenabledinrepository.Visible","ctrl":"vISENABLEDINREPOSITORY","prop":"Visible"},{"av":"divIsenabledinrepository_cell_Class","ctrl":"ISENABLEDINREPOSITORY_CELL","prop":"Class"},{"av":"edtavDatelastauthentication_Visible","ctrl":"vDATELASTAUTHENTICATION","prop":"Visible"},{"av":"divDatelastauthentication_cell_Class","ctrl":"DATELASTAUTHENTICATION_CELL","prop":"Class"},{"av":"chkavEnabletwofactorauthentication.Visible","ctrl":"vENABLETWOFACTORAUTHENTICATION","prop":"Visible"},{"av":"divEnabletwofactorauthentication_cell_Class","ctrl":"ENABLETWOFACTORAUTHENTICATION_CELL","prop":"Class"},{"av":"edtavOtpnumberlocked_Visible","ctrl":"vOTPNUMBERLOCKED","prop":"Visible"},{"av":"divOtpnumberlocked_cell_Class","ctrl":"OTPNUMBERLOCKED_CELL","prop":"Class"},{"av":"edtavOtplastlockeddate_Visible","ctrl":"vOTPLASTLOCKEDDATE","prop":"Visible"},{"av":"divOtplastlockeddate_cell_Class","ctrl":"OTPLASTLOCKEDDATE_CELL","prop":"Class"},{"av":"edtavOtpdailynumbercodes_Visible","ctrl":"vOTPDAILYNUMBERCODES","prop":"Visible"},{"av":"divOtpdailynumbercodes_cell_Class","ctrl":"OTPDAILYNUMBERCODES_CELL","prop":"Class"},{"av":"edtavOtplastdaterequestcode_Visible","ctrl":"vOTPLASTDATEREQUESTCODE","prop":"Visible"},{"av":"divOtplastdaterequestcode_cell_Class","ctrl":"OTPLASTDATEREQUESTCODE_CELL","prop":"Class"},{"av":"edtavActivationdate_Visible","ctrl":"vACTIVATIONDATE","prop":"Visible"},{"av":"divActivationdate_cell_Class","ctrl":"ACTIVATIONDATE_CELL","prop":"Class"},{"av":"edtavUrlprofile_Visible","ctrl":"vURLPROFILE","prop":"Visible"},{"av":"divUrlprofile_cell_Class","ctrl":"URLPROFILE_CELL","prop":"Class"}]}""");
         setEventMetadata("VALIDV_GENDER","""{"handler":"Validv_Gender","iparms":[]}""");
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
         wcpOGx_mode = "";
         wcpOAV55UserId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV46Photo = "";
         AV10AuthTypeId = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV56UserNameSpace = "";
         AV7AuthenticationTypeName = "";
         AV36Name = "";
         AV16Email = "";
         AV41Password = "";
         AV42PasswordConf = "";
         AV22FirstName = "";
         AV31LastName = "";
         AV20ExternalId = "";
         AV11Birthday = DateTime.MinValue;
         AV24Gender = "";
         AV45Phone = "";
         lblTextblockurlprofile_Jsonclick = "";
         AV52URLProfile = "";
         bttBtnurlprofilego_Jsonclick = "";
         AV25Image = "";
         AV64Image_GXI = "";
         sImgUrl = "";
         lblTextblockactivationdate_Jsonclick = "";
         AV5ActivationDate = (DateTime)(DateTime.MinValue);
         bttBtnsendactivationemail_Jsonclick = "";
         AV14DateLastAuthentication = (DateTime)(DateTime.MinValue);
         AV39OTPLastLockedDate = (DateTime)(DateTime.MinValue);
         AV38OTPLastDateRequestCode = DateTime.MinValue;
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         AV53User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV23GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV8AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV30Language = "";
         AV19Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9AuthenticationTypesIns = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV48SecurityPolicies = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy>( context, "GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy", "GeneXus.Programs");
         AV21FilterSecPol = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter(context);
         AV49SecurityPolicy = new GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy(context);
         AV6AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType(context);
         AV47Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV54UserActivationKey = "";
         AV32LinkURL = "";
         AV34Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV33Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12BlobPhoto = "";
         AV18Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamuserentry__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamuserentry__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavUserid_Enabled = 0;
         edtavUsernamespace_Enabled = 0;
         edtavActivationdate_Enabled = 0;
         edtavDatelastauthentication_Enabled = 0;
         edtavOtpnumberlocked_Enabled = 0;
         edtavOtplastlockeddate_Enabled = 0;
         edtavOtpdailynumbercodes_Enabled = 0;
         edtavOtplastdaterequestcode_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV40OTPNumberLocked ;
      private short AV37OTPDailyNumberCodes ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavUserid_Enabled ;
      private int edtavUsernamespace_Enabled ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavPassword_Visible ;
      private int edtavPassword_Enabled ;
      private int edtavPasswordconf_Visible ;
      private int edtavPasswordconf_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int edtavExternalid_Enabled ;
      private int edtavBirthday_Enabled ;
      private int edtavPhone_Enabled ;
      private int edtavUrlprofile_Visible ;
      private int edtavUrlprofile_Enabled ;
      private int bttBtnurlprofilego_Visible ;
      private int imgavImage_Visible ;
      private int imgavImage_Enabled ;
      private int edtavActivationdate_Visible ;
      private int edtavActivationdate_Enabled ;
      private int bttBtnsendactivationemail_Visible ;
      private int AV50SecurityPolicyId ;
      private int edtavDatelastauthentication_Visible ;
      private int edtavDatelastauthentication_Enabled ;
      private int edtavOtpnumberlocked_Visible ;
      private int edtavOtpnumberlocked_Enabled ;
      private int edtavOtplastlockeddate_Visible ;
      private int edtavOtplastlockeddate_Enabled ;
      private int edtavOtpdailynumbercodes_Visible ;
      private int edtavOtpdailynumbercodes_Enabled ;
      private int edtavOtplastdaterequestcode_Visible ;
      private int edtavOtplastdaterequestcode_Enabled ;
      private int bttBtnenter_Visible ;
      private int AV62GXV2 ;
      private int AV63GXV3 ;
      private int AV65GXV4 ;
      private int AV66GXV5 ;
      private int AV67GXV6 ;
      private int idxLst ;
      private string Gx_mode ;
      private string AV55UserId ;
      private string wcpOGx_mode ;
      private string wcpOAV55UserId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV10AuthTypeId ;
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
      private string edtavUserid_Internalname ;
      private string TempTags ;
      private string edtavUserid_Jsonclick ;
      private string edtavUsernamespace_Internalname ;
      private string AV56UserNameSpace ;
      private string edtavUsernamespace_Jsonclick ;
      private string divAuthenticationtypename_cell_Internalname ;
      private string divAuthenticationtypename_cell_Class ;
      private string cmbavAuthenticationtypename_Internalname ;
      private string AV7AuthenticationTypeName ;
      private string cmbavAuthenticationtypename_Jsonclick ;
      private string edtavName_Internalname ;
      private string edtavName_Jsonclick ;
      private string divEmail_cell_Internalname ;
      private string divEmail_cell_Class ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string divPassword_cell_Internalname ;
      private string divPassword_cell_Class ;
      private string edtavPassword_Internalname ;
      private string AV41Password ;
      private string edtavPassword_Jsonclick ;
      private string divPasswordconf_cell_Internalname ;
      private string divPasswordconf_cell_Class ;
      private string edtavPasswordconf_Internalname ;
      private string AV42PasswordConf ;
      private string edtavPasswordconf_Jsonclick ;
      private string divFirstname_cell_Internalname ;
      private string divFirstname_cell_Class ;
      private string edtavFirstname_Internalname ;
      private string AV22FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string divLastname_cell_Internalname ;
      private string divLastname_cell_Class ;
      private string edtavLastname_Internalname ;
      private string AV31LastName ;
      private string edtavLastname_Jsonclick ;
      private string edtavExternalid_Internalname ;
      private string edtavExternalid_Jsonclick ;
      private string divBirthday_cell_Internalname ;
      private string divBirthday_cell_Class ;
      private string edtavBirthday_Internalname ;
      private string edtavBirthday_Jsonclick ;
      private string divGender_cell_Internalname ;
      private string divGender_cell_Class ;
      private string cmbavGender_Internalname ;
      private string AV24Gender ;
      private string cmbavGender_Jsonclick ;
      private string divPhone_cell_Internalname ;
      private string divPhone_cell_Class ;
      private string edtavPhone_Internalname ;
      private string AV45Phone ;
      private string edtavPhone_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divUrlprofile_cell_Internalname ;
      private string divUrlprofile_cell_Class ;
      private string divUnnamedtableurlprofile_Internalname ;
      private string lblTextblockurlprofile_Internalname ;
      private string lblTextblockurlprofile_Jsonclick ;
      private string edtavUrlprofile_Internalname ;
      private string edtavUrlprofile_Jsonclick ;
      private string bttBtnurlprofilego_Internalname ;
      private string bttBtnurlprofilego_Jsonclick ;
      private string divImage_cell_Internalname ;
      private string divImage_cell_Class ;
      private string imgavImage_Internalname ;
      private string imgavImage_gximage ;
      private string sImgUrl ;
      private string divIsactive_cell_Internalname ;
      private string divIsactive_cell_Class ;
      private string chkavIsactive_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string divActivationdate_cell_Internalname ;
      private string divActivationdate_cell_Class ;
      private string divUnnamedtableactivationdate_Internalname ;
      private string lblTextblockactivationdate_Internalname ;
      private string lblTextblockactivationdate_Jsonclick ;
      private string edtavActivationdate_Internalname ;
      private string edtavActivationdate_Jsonclick ;
      private string bttBtnsendactivationemail_Internalname ;
      private string bttBtnsendactivationemail_Jsonclick ;
      private string chkavDontreceiveinformation_Internalname ;
      private string chkavCannotchangepassword_Internalname ;
      private string chkavMustchangepassword_Internalname ;
      private string chkavPasswordneverexpires_Internalname ;
      private string chkavIsblocked_Internalname ;
      private string cmbavSecuritypolicyid_Internalname ;
      private string cmbavSecuritypolicyid_Jsonclick ;
      private string divIsenabledinrepository_cell_Internalname ;
      private string divIsenabledinrepository_cell_Class ;
      private string chkavIsenabledinrepository_Internalname ;
      private string divDatelastauthentication_cell_Internalname ;
      private string divDatelastauthentication_cell_Class ;
      private string edtavDatelastauthentication_Internalname ;
      private string edtavDatelastauthentication_Jsonclick ;
      private string divEnabletwofactorauthentication_cell_Internalname ;
      private string divEnabletwofactorauthentication_cell_Class ;
      private string chkavEnabletwofactorauthentication_Internalname ;
      private string divOtpnumberlocked_cell_Internalname ;
      private string divOtpnumberlocked_cell_Class ;
      private string edtavOtpnumberlocked_Internalname ;
      private string edtavOtpnumberlocked_Jsonclick ;
      private string divOtplastlockeddate_cell_Internalname ;
      private string divOtplastlockeddate_cell_Class ;
      private string edtavOtplastlockeddate_Internalname ;
      private string edtavOtplastlockeddate_Jsonclick ;
      private string divOtpdailynumbercodes_cell_Internalname ;
      private string divOtpdailynumbercodes_cell_Class ;
      private string edtavOtpdailynumbercodes_Internalname ;
      private string edtavOtpdailynumbercodes_Jsonclick ;
      private string divOtplastdaterequestcode_cell_Internalname ;
      private string divOtplastdaterequestcode_cell_Class ;
      private string edtavOtplastdaterequestcode_Internalname ;
      private string edtavOtplastdaterequestcode_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavUser_isenabledinrepository_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV30Language ;
      private string AV54UserActivationKey ;
      private DateTime AV5ActivationDate ;
      private DateTime AV14DateLastAuthentication ;
      private DateTime AV39OTPLastLockedDate ;
      private DateTime AV11Birthday ;
      private DateTime AV38OTPLastDateRequestCode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV59CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool AV25Image_IsBlob ;
      private bool AV26IsActive ;
      private bool AV15DontReceiveInformation ;
      private bool AV13CannotChangePassword ;
      private bool AV35MustChangePassword ;
      private bool AV44PasswordNeverExpires ;
      private bool AV27IsBlocked ;
      private bool AV28IsEnabledInRepository ;
      private bool AV17EnableTwoFactorAuthentication ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV43PasswordIsOK ;
      private bool AV29isOK ;
      private string AV36Name ;
      private string AV16Email ;
      private string AV20ExternalId ;
      private string AV52URLProfile ;
      private string AV64Image_GXI ;
      private string AV32LinkURL ;
      private string AV46Photo ;
      private string AV25Image ;
      private string AV12BlobPhoto ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP1_UserId ;
      private GXCombobox cmbavAuthenticationtypename ;
      private GXCombobox cmbavGender ;
      private GXCheckbox chkavIsactive ;
      private GXCheckbox chkavDontreceiveinformation ;
      private GXCheckbox chkavCannotchangepassword ;
      private GXCheckbox chkavMustchangepassword ;
      private GXCheckbox chkavPasswordneverexpires ;
      private GXCheckbox chkavIsblocked ;
      private GXCombobox cmbavSecuritypolicyid ;
      private GXCheckbox chkavIsenabledinrepository ;
      private GXCheckbox chkavEnabletwofactorauthentication ;
      private GXCheckbox chkavUser_isenabledinrepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV53User ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV23GAMRepository ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV8AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV19Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV9AuthenticationTypesIns ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy> AV48SecurityPolicies ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicyFilter AV21FilterSecPol ;
      private GeneXus.Programs.genexussecurity.SdtGAMSecurityPolicy AV49SecurityPolicy ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationType AV6AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV47Repository ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV34Messages ;
      private GeneXus.Utils.SdtMessages_Message AV33Message ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV18Error ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamuserentry__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamuserentry__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
