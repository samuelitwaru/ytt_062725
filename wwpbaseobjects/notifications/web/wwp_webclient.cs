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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webclient : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A7WWPUserExtendedId = GetPar( "WWPUserExtendedId");
            n7WWPUserExtendedId = false;
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A7WWPUserExtendedId) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "WWP_Web Client", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPWebClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_webclient( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webclient( IGxContext context )
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
         cmbWWPWebClientBrowserId = new GXCombobox();
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
            return "webclient_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         if ( cmbWWPWebClientBrowserId.ItemCount > 0 )
         {
            A49WWPWebClientBrowserId = (short)(Math.Round(NumberUtil.Val( cmbWWPWebClientBrowserId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A49WWPWebClientBrowserId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A49WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A49WWPWebClientBrowserId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebClientBrowserId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A49WWPWebClientBrowserId), 4, 0));
            AssignProp("", false, cmbWWPWebClientBrowserId_Internalname, "Values", cmbWWPWebClientBrowserId.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_Web Client", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
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
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebClientId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebClientId_Internalname, "Client Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebClientId_Internalname, StringUtil.RTrim( A48WWPWebClientId), StringUtil.RTrim( context.localUtil.Format( A48WWPWebClientId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebClientId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebClientId_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPWebClientBrowserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPWebClientBrowserId_Internalname, "Browser Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPWebClientBrowserId, cmbWWPWebClientBrowserId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A49WWPWebClientBrowserId), 4, 0)), 1, cmbWWPWebClientBrowserId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPWebClientBrowserId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         cmbWWPWebClientBrowserId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A49WWPWebClientBrowserId), 4, 0));
         AssignProp("", false, cmbWWPWebClientBrowserId_Internalname, "Values", (string)(cmbWWPWebClientBrowserId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebClientBrowserVersion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebClientBrowserVersion_Internalname, "Browser Version", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebClientBrowserVersion_Internalname, A50WWPWebClientBrowserVersion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtWWPWebClientBrowserVersion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebClientFirstRegistered_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebClientFirstRegistered_Internalname, "First Registered", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebClientFirstRegistered_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebClientFirstRegistered_Internalname, context.localUtil.TToC( A51WWPWebClientFirstRegistered, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A51WWPWebClientFirstRegistered, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebClientFirstRegistered_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebClientFirstRegistered_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebClientFirstRegistered_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebClientFirstRegistered_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebClientLastRegistered_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebClientLastRegistered_Internalname, "Last Registered", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebClientLastRegistered_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebClientLastRegistered_Internalname, context.localUtil.TToC( A52WWPWebClientLastRegistered, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A52WWPWebClientLastRegistered, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebClientLastRegistered_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebClientLastRegistered_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebClientLastRegistered_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebClientLastRegistered_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedId_Internalname, "User Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A7WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A7WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebClient.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z48WWPWebClientId = cgiGet( "Z48WWPWebClientId");
            Z49WWPWebClientBrowserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z49WWPWebClientBrowserId"), ".", ","), 18, MidpointRounding.ToEven));
            Z51WWPWebClientFirstRegistered = context.localUtil.CToT( cgiGet( "Z51WWPWebClientFirstRegistered"), 0);
            Z52WWPWebClientLastRegistered = context.localUtil.CToT( cgiGet( "Z52WWPWebClientLastRegistered"), 0);
            Z7WWPUserExtendedId = cgiGet( "Z7WWPUserExtendedId");
            n7WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A48WWPWebClientId = cgiGet( edtWWPWebClientId_Internalname);
            AssignAttri("", false, "A48WWPWebClientId", A48WWPWebClientId);
            cmbWWPWebClientBrowserId.CurrentValue = cgiGet( cmbWWPWebClientBrowserId_Internalname);
            A49WWPWebClientBrowserId = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPWebClientBrowserId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A49WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A49WWPWebClientBrowserId), 4, 0));
            A50WWPWebClientBrowserVersion = cgiGet( edtWWPWebClientBrowserVersion_Internalname);
            AssignAttri("", false, "A50WWPWebClientBrowserVersion", A50WWPWebClientBrowserVersion);
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebClientFirstRegistered_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Client First Registered"}), 1, "WWPWEBCLIENTFIRSTREGISTERED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebClientFirstRegistered_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A51WWPWebClientFirstRegistered", context.localUtil.TToC( A51WWPWebClientFirstRegistered, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A51WWPWebClientFirstRegistered = context.localUtil.CToT( cgiGet( edtWWPWebClientFirstRegistered_Internalname));
               AssignAttri("", false, "A51WWPWebClientFirstRegistered", context.localUtil.TToC( A51WWPWebClientFirstRegistered, 10, 12, 1, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebClientLastRegistered_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Client Last Registered"}), 1, "WWPWEBCLIENTLASTREGISTERED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebClientLastRegistered_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A52WWPWebClientLastRegistered", context.localUtil.TToC( A52WWPWebClientLastRegistered, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A52WWPWebClientLastRegistered = context.localUtil.CToT( cgiGet( edtWWPWebClientLastRegistered_Internalname));
               AssignAttri("", false, "A52WWPWebClientLastRegistered", context.localUtil.TToC( A52WWPWebClientLastRegistered, 10, 12, 1, 3, "/", ":", " "));
            }
            A7WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n7WWPUserExtendedId = false;
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            n7WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A48WWPWebClientId = GetPar( "WWPWebClientId");
               AssignAttri("", false, "A48WWPWebClientId", A48WWPWebClientId);
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll077( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes077( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z49WWPWebClientBrowserId = T00073_A49WWPWebClientBrowserId[0];
               Z51WWPWebClientFirstRegistered = T00073_A51WWPWebClientFirstRegistered[0];
               Z52WWPWebClientLastRegistered = T00073_A52WWPWebClientLastRegistered[0];
               Z7WWPUserExtendedId = T00073_A7WWPUserExtendedId[0];
            }
            else
            {
               Z49WWPWebClientBrowserId = A49WWPWebClientBrowserId;
               Z51WWPWebClientFirstRegistered = A51WWPWebClientFirstRegistered;
               Z52WWPWebClientLastRegistered = A52WWPWebClientLastRegistered;
               Z7WWPUserExtendedId = A7WWPUserExtendedId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z48WWPWebClientId = A48WWPWebClientId;
            Z49WWPWebClientBrowserId = A49WWPWebClientBrowserId;
            Z50WWPWebClientBrowserVersion = A50WWPWebClientBrowserVersion;
            Z51WWPWebClientFirstRegistered = A51WWPWebClientFirstRegistered;
            Z52WWPWebClientLastRegistered = A52WWPWebClientLastRegistered;
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A51WWPWebClientFirstRegistered) && ( Gx_BScreen == 0 ) )
         {
            A51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A51WWPWebClientFirstRegistered", context.localUtil.TToC( A51WWPWebClientFirstRegistered, 10, 12, 1, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A52WWPWebClientLastRegistered) && ( Gx_BScreen == 0 ) )
         {
            A52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A52WWPWebClientLastRegistered", context.localUtil.TToC( A52WWPWebClientLastRegistered, 10, 12, 1, 3, "/", ":", " "));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load077( )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A48WWPWebClientId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A49WWPWebClientBrowserId = T00075_A49WWPWebClientBrowserId[0];
            AssignAttri("", false, "A49WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A49WWPWebClientBrowserId), 4, 0));
            A50WWPWebClientBrowserVersion = T00075_A50WWPWebClientBrowserVersion[0];
            AssignAttri("", false, "A50WWPWebClientBrowserVersion", A50WWPWebClientBrowserVersion);
            A51WWPWebClientFirstRegistered = T00075_A51WWPWebClientFirstRegistered[0];
            AssignAttri("", false, "A51WWPWebClientFirstRegistered", context.localUtil.TToC( A51WWPWebClientFirstRegistered, 10, 12, 1, 3, "/", ":", " "));
            A52WWPWebClientLastRegistered = T00075_A52WWPWebClientLastRegistered[0];
            AssignAttri("", false, "A52WWPWebClientLastRegistered", context.localUtil.TToC( A52WWPWebClientLastRegistered, 10, 12, 1, 3, "/", ":", " "));
            A7WWPUserExtendedId = T00075_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = T00075_n7WWPUserExtendedId[0];
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            ZM077( -4) ;
         }
         pr_default.close(3);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
      }

      protected void CheckExtendedTable077( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A49WWPWebClientBrowserId == 0 ) || ( A49WWPWebClientBrowserId == 1 ) || ( A49WWPWebClientBrowserId == 2 ) || ( A49WWPWebClientBrowserId == 3 ) || ( A49WWPWebClientBrowserId == 5 ) || ( A49WWPWebClientBrowserId == 6 ) || ( A49WWPWebClientBrowserId == 7 ) || ( A49WWPWebClientBrowserId == 8 ) || ( A49WWPWebClientBrowserId == 9 ) ) )
         {
            GX_msglist.addItem("Field Web Client Browser Id is out of range", "OutOfRange", 1, "WWPWEBCLIENTBROWSERID");
            AnyError = 1;
            GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( string A7WWPUserExtendedId )
      {
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey077( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A48WWPWebClientId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A48WWPWebClientId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 4) ;
            RcdFound7 = 1;
            A48WWPWebClientId = T00073_A48WWPWebClientId[0];
            AssignAttri("", false, "A48WWPWebClientId", A48WWPWebClientId);
            A49WWPWebClientBrowserId = T00073_A49WWPWebClientBrowserId[0];
            AssignAttri("", false, "A49WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A49WWPWebClientBrowserId), 4, 0));
            A50WWPWebClientBrowserVersion = T00073_A50WWPWebClientBrowserVersion[0];
            AssignAttri("", false, "A50WWPWebClientBrowserVersion", A50WWPWebClientBrowserVersion);
            A51WWPWebClientFirstRegistered = T00073_A51WWPWebClientFirstRegistered[0];
            AssignAttri("", false, "A51WWPWebClientFirstRegistered", context.localUtil.TToC( A51WWPWebClientFirstRegistered, 10, 12, 1, 3, "/", ":", " "));
            A52WWPWebClientLastRegistered = T00073_A52WWPWebClientLastRegistered[0];
            AssignAttri("", false, "A52WWPWebClientLastRegistered", context.localUtil.TToC( A52WWPWebClientLastRegistered, 10, 12, 1, 3, "/", ":", " "));
            A7WWPUserExtendedId = T00073_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = T00073_n7WWPUserExtendedId[0];
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            Z48WWPWebClientId = A48WWPWebClientId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A48WWPWebClientId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00078_A48WWPWebClientId[0], A48WWPWebClientId) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00078_A48WWPWebClientId[0], A48WWPWebClientId) > 0 ) ) )
            {
               A48WWPWebClientId = T00078_A48WWPWebClientId[0];
               AssignAttri("", false, "A48WWPWebClientId", A48WWPWebClientId);
               RcdFound7 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A48WWPWebClientId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00079_A48WWPWebClientId[0], A48WWPWebClientId) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00079_A48WWPWebClientId[0], A48WWPWebClientId) < 0 ) ) )
            {
               A48WWPWebClientId = T00079_A48WWPWebClientId[0];
               AssignAttri("", false, "A48WWPWebClientId", A48WWPWebClientId);
               RcdFound7 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPWebClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert077( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( StringUtil.StrCmp(A48WWPWebClientId, Z48WWPWebClientId) != 0 )
               {
                  A48WWPWebClientId = Z48WWPWebClientId;
                  AssignAttri("", false, "A48WWPWebClientId", A48WWPWebClientId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPWEBCLIENTID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPWebClientId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPWebClientId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update077( ) ;
                  GX_FocusControl = edtWWPWebClientId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A48WWPWebClientId, Z48WWPWebClientId) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPWebClientId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert077( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPWEBCLIENTID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPWebClientId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPWebClientId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert077( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( StringUtil.StrCmp(A48WWPWebClientId, Z48WWPWebClientId) != 0 )
         {
            A48WWPWebClientId = Z48WWPWebClientId;
            AssignAttri("", false, "A48WWPWebClientId", A48WWPWebClientId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPWEBCLIENTID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPWebClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPWEBCLIENTID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebClientId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd077( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound7 != 0 )
            {
               ScanNext077( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd077( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A48WWPWebClientId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z49WWPWebClientBrowserId != T00072_A49WWPWebClientBrowserId[0] ) || ( Z51WWPWebClientFirstRegistered != T00072_A51WWPWebClientFirstRegistered[0] ) || ( Z52WWPWebClientLastRegistered != T00072_A52WWPWebClientLastRegistered[0] ) || ( StringUtil.StrCmp(Z7WWPUserExtendedId, T00072_A7WWPUserExtendedId[0]) != 0 ) )
            {
               if ( Z49WWPWebClientBrowserId != T00072_A49WWPWebClientBrowserId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webclient:[seudo value changed for attri]"+"WWPWebClientBrowserId");
                  GXUtil.WriteLogRaw("Old: ",Z49WWPWebClientBrowserId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A49WWPWebClientBrowserId[0]);
               }
               if ( Z51WWPWebClientFirstRegistered != T00072_A51WWPWebClientFirstRegistered[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webclient:[seudo value changed for attri]"+"WWPWebClientFirstRegistered");
                  GXUtil.WriteLogRaw("Old: ",Z51WWPWebClientFirstRegistered);
                  GXUtil.WriteLogRaw("Current: ",T00072_A51WWPWebClientFirstRegistered[0]);
               }
               if ( Z52WWPWebClientLastRegistered != T00072_A52WWPWebClientLastRegistered[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webclient:[seudo value changed for attri]"+"WWPWebClientLastRegistered");
                  GXUtil.WriteLogRaw("Old: ",Z52WWPWebClientLastRegistered);
                  GXUtil.WriteLogRaw("Current: ",T00072_A52WWPWebClientLastRegistered[0]);
               }
               if ( StringUtil.StrCmp(Z7WWPUserExtendedId, T00072_A7WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webclient:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z7WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A7WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebClient"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         if ( ! IsAuthorized("webclient_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000710 */
                     pr_default.execute(8, new Object[] {A48WWPWebClientId, A49WWPWebClientBrowserId, A50WWPWebClientBrowserVersion, A51WWPWebClientFirstRegistered, A52WWPWebClientLastRegistered, n7WWPUserExtendedId, A7WWPUserExtendedId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption070( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         if ( ! IsAuthorized("webclient_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000711 */
                     pr_default.execute(9, new Object[] {A49WWPWebClientBrowserId, A50WWPWebClientBrowserVersion, A51WWPWebClientFirstRegistered, A52WWPWebClientLastRegistered, n7WWPUserExtendedId, A7WWPUserExtendedId, A48WWPWebClientId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption070( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("webclient_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000712 */
                  pr_default.execute(10, new Object[] {A48WWPWebClientId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound7 == 0 )
                        {
                           InitAll077( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption070( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel077( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_webclient",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webclient",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart077( )
      {
         /* Using cursor T000713 */
         pr_default.execute(11);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound7 = 1;
            A48WWPWebClientId = T000713_A48WWPWebClientId[0];
            AssignAttri("", false, "A48WWPWebClientId", A48WWPWebClientId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound7 = 1;
            A48WWPWebClientId = T000713_A48WWPWebClientId[0];
            AssignAttri("", false, "A48WWPWebClientId", A48WWPWebClientId);
         }
      }

      protected void ScanEnd077( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
         edtWWPWebClientId_Enabled = 0;
         AssignProp("", false, edtWWPWebClientId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebClientId_Enabled), 5, 0), true);
         cmbWWPWebClientBrowserId.Enabled = 0;
         AssignProp("", false, cmbWWPWebClientBrowserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPWebClientBrowserId.Enabled), 5, 0), true);
         edtWWPWebClientBrowserVersion_Enabled = 0;
         AssignProp("", false, edtWWPWebClientBrowserVersion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebClientBrowserVersion_Enabled), 5, 0), true);
         edtWWPWebClientFirstRegistered_Enabled = 0;
         AssignProp("", false, edtWWPWebClientFirstRegistered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebClientFirstRegistered_Enabled), 5, 0), true);
         edtWWPWebClientLastRegistered_Enabled = 0;
         AssignProp("", false, edtWWPWebClientLastRegistered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebClientLastRegistered_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.web.wwp_webclient.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z48WWPWebClientId", StringUtil.RTrim( Z48WWPWebClientId));
         GxWebStd.gx_hidden_field( context, "Z49WWPWebClientBrowserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49WWPWebClientBrowserId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z51WWPWebClientFirstRegistered", context.localUtil.TToC( Z51WWPWebClientFirstRegistered, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z52WWPWebClientLastRegistered", context.localUtil.TToC( Z52WWPWebClientLastRegistered, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z7WWPUserExtendedId", StringUtil.RTrim( Z7WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("wwpbaseobjects.notifications.web.wwp_webclient.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Web.WWP_WebClient" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_Web Client" ;
      }

      protected void InitializeNonKey077( )
      {
         A49WWPWebClientBrowserId = 0;
         AssignAttri("", false, "A49WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A49WWPWebClientBrowserId), 4, 0));
         A50WWPWebClientBrowserVersion = "";
         AssignAttri("", false, "A50WWPWebClientBrowserVersion", A50WWPWebClientBrowserVersion);
         A7WWPUserExtendedId = "";
         n7WWPUserExtendedId = false;
         AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
         n7WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ? true : false);
         A51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A51WWPWebClientFirstRegistered", context.localUtil.TToC( A51WWPWebClientFirstRegistered, 10, 12, 1, 3, "/", ":", " "));
         A52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A52WWPWebClientLastRegistered", context.localUtil.TToC( A52WWPWebClientLastRegistered, 10, 12, 1, 3, "/", ":", " "));
         Z49WWPWebClientBrowserId = 0;
         Z51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z7WWPUserExtendedId = "";
      }

      protected void InitAll077( )
      {
         A48WWPWebClientId = "";
         AssignAttri("", false, "A48WWPWebClientId", A48WWPWebClientId);
         InitializeNonKey077( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A51WWPWebClientFirstRegistered = i51WWPWebClientFirstRegistered;
         AssignAttri("", false, "A51WWPWebClientFirstRegistered", context.localUtil.TToC( A51WWPWebClientFirstRegistered, 10, 12, 1, 3, "/", ":", " "));
         A52WWPWebClientLastRegistered = i52WWPWebClientLastRegistered;
         AssignAttri("", false, "A52WWPWebClientLastRegistered", context.localUtil.TToC( A52WWPWebClientLastRegistered, 10, 12, 1, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267482125", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/web/wwp_webclient.js", "?20256267482125", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtWWPWebClientId_Internalname = "WWPWEBCLIENTID";
         cmbWWPWebClientBrowserId_Internalname = "WWPWEBCLIENTBROWSERID";
         edtWWPWebClientBrowserVersion_Internalname = "WWPWEBCLIENTBROWSERVERSION";
         edtWWPWebClientFirstRegistered_Internalname = "WWPWEBCLIENTFIRSTREGISTERED";
         edtWWPWebClientLastRegistered_Internalname = "WWPWEBCLIENTLASTREGISTERED";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WWP_Web Client";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPWebClientLastRegistered_Jsonclick = "";
         edtWWPWebClientLastRegistered_Enabled = 1;
         edtWWPWebClientFirstRegistered_Jsonclick = "";
         edtWWPWebClientFirstRegistered_Enabled = 1;
         edtWWPWebClientBrowserVersion_Enabled = 1;
         cmbWWPWebClientBrowserId_Jsonclick = "";
         cmbWWPWebClientBrowserId.Enabled = 1;
         edtWWPWebClientId_Jsonclick = "";
         edtWWPWebClientId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         cmbWWPWebClientBrowserId.Name = "WWPWEBCLIENTBROWSERID";
         cmbWWPWebClientBrowserId.WebTags = "";
         cmbWWPWebClientBrowserId.addItem("0", "Unknown Agent", 0);
         cmbWWPWebClientBrowserId.addItem("1", "Internet Explorer", 0);
         cmbWWPWebClientBrowserId.addItem("2", "Netscape", 0);
         cmbWWPWebClientBrowserId.addItem("3", "Opera", 0);
         cmbWWPWebClientBrowserId.addItem("5", "Pocket IE", 0);
         cmbWWPWebClientBrowserId.addItem("6", "Firefox", 0);
         cmbWWPWebClientBrowserId.addItem("7", "Chrome", 0);
         cmbWWPWebClientBrowserId.addItem("8", "Safari", 0);
         cmbWWPWebClientBrowserId.addItem("9", "Edge", 0);
         if ( cmbWWPWebClientBrowserId.ItemCount > 0 )
         {
            A49WWPWebClientBrowserId = (short)(Math.Round(NumberUtil.Val( cmbWWPWebClientBrowserId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A49WWPWebClientBrowserId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A49WWPWebClientBrowserId", StringUtil.LTrimStr( (decimal)(A49WWPWebClientBrowserId), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = cmbWWPWebClientBrowserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Wwpwebclientid( )
      {
         A49WWPWebClientBrowserId = (short)(Math.Round(NumberUtil.Val( cmbWWPWebClientBrowserId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPWebClientBrowserId.CurrentValue = StringUtil.LTrimStr( (decimal)(A49WWPWebClientBrowserId), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPWebClientBrowserId.ItemCount > 0 )
         {
            A49WWPWebClientBrowserId = (short)(Math.Round(NumberUtil.Val( cmbWWPWebClientBrowserId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A49WWPWebClientBrowserId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPWebClientBrowserId.CurrentValue = StringUtil.LTrimStr( (decimal)(A49WWPWebClientBrowserId), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebClientBrowserId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A49WWPWebClientBrowserId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A49WWPWebClientBrowserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A49WWPWebClientBrowserId), 4, 0, ".", "")));
         cmbWWPWebClientBrowserId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A49WWPWebClientBrowserId), 4, 0));
         AssignProp("", false, cmbWWPWebClientBrowserId_Internalname, "Values", cmbWWPWebClientBrowserId.ToJavascriptSource(), true);
         AssignAttri("", false, "A50WWPWebClientBrowserVersion", A50WWPWebClientBrowserVersion);
         AssignAttri("", false, "A51WWPWebClientFirstRegistered", context.localUtil.TToC( A51WWPWebClientFirstRegistered, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A52WWPWebClientLastRegistered", context.localUtil.TToC( A52WWPWebClientLastRegistered, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A7WWPUserExtendedId", StringUtil.RTrim( A7WWPUserExtendedId));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z48WWPWebClientId", StringUtil.RTrim( Z48WWPWebClientId));
         GxWebStd.gx_hidden_field( context, "Z49WWPWebClientBrowserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49WWPWebClientBrowserId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z50WWPWebClientBrowserVersion", Z50WWPWebClientBrowserVersion);
         GxWebStd.gx_hidden_field( context, "Z51WWPWebClientFirstRegistered", context.localUtil.TToC( Z51WWPWebClientFirstRegistered, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z52WWPWebClientLastRegistered", context.localUtil.TToC( Z52WWPWebClientLastRegistered, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z7WWPUserExtendedId", StringUtil.RTrim( Z7WWPUserExtendedId));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpuserextendedid( )
      {
         n7WWPUserExtendedId = false;
         /* Using cursor T000714 */
         pr_default.execute(12, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_WWPWEBCLIENTID","""{"handler":"Valid_Wwpwebclientid","iparms":[{"av":"cmbWWPWebClientBrowserId"},{"av":"A49WWPWebClientBrowserId","fld":"WWPWEBCLIENTBROWSERID","pic":"ZZZ9"},{"av":"A48WWPWebClientId","fld":"WWPWEBCLIENTID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A51WWPWebClientFirstRegistered","fld":"WWPWEBCLIENTFIRSTREGISTERED","pic":"99/99/9999 99:99:99.999"},{"av":"A52WWPWebClientLastRegistered","fld":"WWPWEBCLIENTLASTREGISTERED","pic":"99/99/9999 99:99:99.999"}]""");
         setEventMetadata("VALID_WWPWEBCLIENTID",""","oparms":[{"av":"cmbWWPWebClientBrowserId"},{"av":"A49WWPWebClientBrowserId","fld":"WWPWEBCLIENTBROWSERID","pic":"ZZZ9"},{"av":"A50WWPWebClientBrowserVersion","fld":"WWPWEBCLIENTBROWSERVERSION"},{"av":"A51WWPWebClientFirstRegistered","fld":"WWPWEBCLIENTFIRSTREGISTERED","pic":"99/99/9999 99:99:99.999"},{"av":"A52WWPWebClientLastRegistered","fld":"WWPWEBCLIENTLASTREGISTERED","pic":"99/99/9999 99:99:99.999"},{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z48WWPWebClientId"},{"av":"Z49WWPWebClientBrowserId"},{"av":"Z50WWPWebClientBrowserVersion"},{"av":"Z51WWPWebClientFirstRegistered"},{"av":"Z52WWPWebClientLastRegistered"},{"av":"Z7WWPUserExtendedId"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_WWPWEBCLIENTBROWSERID","""{"handler":"Valid_Wwpwebclientbrowserid","iparms":[]}""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","""{"handler":"Valid_Wwpuserextendedid","iparms":[{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"}]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z48WWPWebClientId = "";
         Z51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z7WWPUserExtendedId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A7WWPUserExtendedId = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A48WWPWebClientId = "";
         A50WWPWebClientBrowserVersion = "";
         A51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         A52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z50WWPWebClientBrowserVersion = "";
         T00075_A48WWPWebClientId = new string[] {""} ;
         T00075_A49WWPWebClientBrowserId = new short[1] ;
         T00075_A50WWPWebClientBrowserVersion = new string[] {""} ;
         T00075_A51WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         T00075_A52WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         T00075_A7WWPUserExtendedId = new string[] {""} ;
         T00075_n7WWPUserExtendedId = new bool[] {false} ;
         T00074_A7WWPUserExtendedId = new string[] {""} ;
         T00074_n7WWPUserExtendedId = new bool[] {false} ;
         T00076_A7WWPUserExtendedId = new string[] {""} ;
         T00076_n7WWPUserExtendedId = new bool[] {false} ;
         T00077_A48WWPWebClientId = new string[] {""} ;
         T00073_A48WWPWebClientId = new string[] {""} ;
         T00073_A49WWPWebClientBrowserId = new short[1] ;
         T00073_A50WWPWebClientBrowserVersion = new string[] {""} ;
         T00073_A51WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         T00073_A52WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         T00073_A7WWPUserExtendedId = new string[] {""} ;
         T00073_n7WWPUserExtendedId = new bool[] {false} ;
         sMode7 = "";
         T00078_A48WWPWebClientId = new string[] {""} ;
         T00079_A48WWPWebClientId = new string[] {""} ;
         T00072_A48WWPWebClientId = new string[] {""} ;
         T00072_A49WWPWebClientBrowserId = new short[1] ;
         T00072_A50WWPWebClientBrowserVersion = new string[] {""} ;
         T00072_A51WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         T00072_A52WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         T00072_A7WWPUserExtendedId = new string[] {""} ;
         T00072_n7WWPUserExtendedId = new bool[] {false} ;
         T000713_A48WWPWebClientId = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         i52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         ZZ48WWPWebClientId = "";
         ZZ50WWPWebClientBrowserVersion = "";
         ZZ51WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         ZZ52WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         ZZ7WWPUserExtendedId = "";
         T000714_A7WWPUserExtendedId = new string[] {""} ;
         T000714_n7WWPUserExtendedId = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient__default(),
            new Object[][] {
                new Object[] {
               T00072_A48WWPWebClientId, T00072_A49WWPWebClientBrowserId, T00072_A50WWPWebClientBrowserVersion, T00072_A51WWPWebClientFirstRegistered, T00072_A52WWPWebClientLastRegistered, T00072_A7WWPUserExtendedId, T00072_n7WWPUserExtendedId
               }
               , new Object[] {
               T00073_A48WWPWebClientId, T00073_A49WWPWebClientBrowserId, T00073_A50WWPWebClientBrowserVersion, T00073_A51WWPWebClientFirstRegistered, T00073_A52WWPWebClientLastRegistered, T00073_A7WWPUserExtendedId, T00073_n7WWPUserExtendedId
               }
               , new Object[] {
               T00074_A7WWPUserExtendedId
               }
               , new Object[] {
               T00075_A48WWPWebClientId, T00075_A49WWPWebClientBrowserId, T00075_A50WWPWebClientBrowserVersion, T00075_A51WWPWebClientFirstRegistered, T00075_A52WWPWebClientLastRegistered, T00075_A7WWPUserExtendedId, T00075_n7WWPUserExtendedId
               }
               , new Object[] {
               T00076_A7WWPUserExtendedId
               }
               , new Object[] {
               T00077_A48WWPWebClientId
               }
               , new Object[] {
               T00078_A48WWPWebClientId
               }
               , new Object[] {
               T00079_A48WWPWebClientId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000713_A48WWPWebClientId
               }
               , new Object[] {
               T000714_A7WWPUserExtendedId
               }
            }
         );
         Z52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i52WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i51WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
      }

      private short Z49WWPWebClientBrowserId ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A49WWPWebClientBrowserId ;
      private short Gx_BScreen ;
      private short RcdFound7 ;
      private short gxajaxcallmode ;
      private short ZZ49WWPWebClientBrowserId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPWebClientId_Enabled ;
      private int edtWWPWebClientBrowserVersion_Enabled ;
      private int edtWWPWebClientFirstRegistered_Enabled ;
      private int edtWWPWebClientLastRegistered_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z48WWPWebClientId ;
      private string Z7WWPUserExtendedId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A7WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPWebClientId_Internalname ;
      private string cmbWWPWebClientBrowserId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string A48WWPWebClientId ;
      private string edtWWPWebClientId_Jsonclick ;
      private string cmbWWPWebClientBrowserId_Jsonclick ;
      private string edtWWPWebClientBrowserVersion_Internalname ;
      private string edtWWPWebClientFirstRegistered_Internalname ;
      private string edtWWPWebClientFirstRegistered_Jsonclick ;
      private string edtWWPWebClientLastRegistered_Internalname ;
      private string edtWWPWebClientLastRegistered_Jsonclick ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode7 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ48WWPWebClientId ;
      private string ZZ7WWPUserExtendedId ;
      private DateTime Z51WWPWebClientFirstRegistered ;
      private DateTime Z52WWPWebClientLastRegistered ;
      private DateTime A51WWPWebClientFirstRegistered ;
      private DateTime A52WWPWebClientLastRegistered ;
      private DateTime i51WWPWebClientFirstRegistered ;
      private DateTime i52WWPWebClientLastRegistered ;
      private DateTime ZZ51WWPWebClientFirstRegistered ;
      private DateTime ZZ52WWPWebClientLastRegistered ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n7WWPUserExtendedId ;
      private bool wbErr ;
      private string A50WWPWebClientBrowserVersion ;
      private string Z50WWPWebClientBrowserVersion ;
      private string ZZ50WWPWebClientBrowserVersion ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPWebClientBrowserId ;
      private IDataStoreProvider pr_default ;
      private string[] T00075_A48WWPWebClientId ;
      private short[] T00075_A49WWPWebClientBrowserId ;
      private string[] T00075_A50WWPWebClientBrowserVersion ;
      private DateTime[] T00075_A51WWPWebClientFirstRegistered ;
      private DateTime[] T00075_A52WWPWebClientLastRegistered ;
      private string[] T00075_A7WWPUserExtendedId ;
      private bool[] T00075_n7WWPUserExtendedId ;
      private string[] T00074_A7WWPUserExtendedId ;
      private bool[] T00074_n7WWPUserExtendedId ;
      private string[] T00076_A7WWPUserExtendedId ;
      private bool[] T00076_n7WWPUserExtendedId ;
      private string[] T00077_A48WWPWebClientId ;
      private string[] T00073_A48WWPWebClientId ;
      private short[] T00073_A49WWPWebClientBrowserId ;
      private string[] T00073_A50WWPWebClientBrowserVersion ;
      private DateTime[] T00073_A51WWPWebClientFirstRegistered ;
      private DateTime[] T00073_A52WWPWebClientLastRegistered ;
      private string[] T00073_A7WWPUserExtendedId ;
      private bool[] T00073_n7WWPUserExtendedId ;
      private string[] T00078_A48WWPWebClientId ;
      private string[] T00079_A48WWPWebClientId ;
      private string[] T00072_A48WWPWebClientId ;
      private short[] T00072_A49WWPWebClientBrowserId ;
      private string[] T00072_A50WWPWebClientBrowserVersion ;
      private DateTime[] T00072_A51WWPWebClientFirstRegistered ;
      private DateTime[] T00072_A52WWPWebClientLastRegistered ;
      private string[] T00072_A7WWPUserExtendedId ;
      private bool[] T00072_n7WWPUserExtendedId ;
      private string[] T000713_A48WWPWebClientId ;
      private string[] T000714_A7WWPUserExtendedId ;
      private bool[] T000714_n7WWPUserExtendedId ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webclient__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webclient__default : DataStoreHelperBase, IDataStoreHelper
 {
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00072;
        prmT00072 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmT00073;
        prmT00073 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmT00074;
        prmT00074 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00075;
        prmT00075 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmT00076;
        prmT00076 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00077;
        prmT00077 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmT00078;
        prmT00078 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmT00079;
        prmT00079 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmT000710;
        prmT000710 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0) ,
        new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
        new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000711;
        prmT000711 = new Object[] {
        new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
        new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmT000712;
        prmT000712 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmT000713;
        prmT000713 = new Object[] {
        };
        Object[] prmT000714;
        prmT000714 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00072", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId  FOR UPDATE OF WWP_WebClient NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00073", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00074", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00075", "SELECT TM1.WWPWebClientId, TM1.WWPWebClientBrowserId, TM1.WWPWebClientBrowserVersion, TM1.WWPWebClientFirstRegistered, TM1.WWPWebClientLastRegistered, TM1.WWPUserExtendedId FROM WWP_WebClient TM1 WHERE TM1.WWPWebClientId = ( :WWPWebClientId) ORDER BY TM1.WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00076", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00077", "SELECT WWPWebClientId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00078", "SELECT WWPWebClientId FROM WWP_WebClient WHERE ( WWPWebClientId > ( :WWPWebClientId)) ORDER BY WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00079", "SELECT WWPWebClientId FROM WWP_WebClient WHERE ( WWPWebClientId < ( :WWPWebClientId)) ORDER BY WWPWebClientId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000710", "SAVEPOINT gxupdate;INSERT INTO WWP_WebClient(WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId) VALUES(:WWPWebClientId, :WWPWebClientBrowserId, :WWPWebClientBrowserVersion, :WWPWebClientFirstRegistered, :WWPWebClientLastRegistered, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000710)
           ,new CursorDef("T000711", "SAVEPOINT gxupdate;UPDATE WWP_WebClient SET WWPWebClientBrowserId=:WWPWebClientBrowserId, WWPWebClientBrowserVersion=:WWPWebClientBrowserVersion, WWPWebClientFirstRegistered=:WWPWebClientFirstRegistered, WWPWebClientLastRegistered=:WWPWebClientLastRegistered, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000711)
           ,new CursorDef("T000712", "SAVEPOINT gxupdate;DELETE FROM WWP_WebClient  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000712)
           ,new CursorDef("T000713", "SELECT WWPWebClientId FROM WWP_WebClient ORDER BY WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000714", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
     }
  }

}

}
