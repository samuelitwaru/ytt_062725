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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sms : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A22WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationId"), "."), 18, MidpointRounding.ToEven));
            n22WWPNotificationId = false;
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A22WWPNotificationId) ;
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
         Form.Meta.addItem("description", "WWP_SMS", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_sms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sms( IGxContext context )
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
         cmbWWPSMSStatus = new GXCombobox();
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
            return "sms_Execute" ;
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
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A34WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A34WWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A34WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A34WWPSMSStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A34WWPSMSStatus), 4, 0));
            AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", cmbWWPSMSStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_SMS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSMSId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33WWPSMSId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPSMSId_Enabled!=0) ? context.localUtil.Format( (decimal)(A33WWPSMSId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A33WWPSMSId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSMessage_Internalname, "Message", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSMessage_Internalname, A37WWPSMSMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtWWPSMSMessage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSSenderNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSSenderNumber_Internalname, "Sender Number", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSSenderNumber_Internalname, A38WWPSMSSenderNumber, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtWWPSMSSenderNumber_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSRecipientNumbers_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSRecipientNumbers_Internalname, "Recipient Numbers", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSRecipientNumbers_Internalname, A39WWPSMSRecipientNumbers, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtWWPSMSRecipientNumbers_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPSMSStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPSMSStatus_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPSMSStatus, cmbWWPSMSStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A34WWPSMSStatus), 4, 0)), 1, cmbWWPSMSStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPSMSStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A34WWPSMSStatus), 4, 0));
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", (string)(cmbWWPSMSStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSCreated_Internalname, "Created", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSCreated_Internalname, context.localUtil.TToC( A40WWPSMSCreated, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A40WWPSMSCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSScheduled_Internalname, "Scheduled", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSScheduled_Internalname, context.localUtil.TToC( A41WWPSMSScheduled, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A41WWPSMSScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSScheduled_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSProcessed_Internalname, "Processed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSProcessed_Internalname, context.localUtil.TToC( A35WWPSMSProcessed, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A35WWPSMSProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSProcessed_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSDetail_Internalname, "Detail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSDetail_Internalname, A36WWPSMSDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPSMSDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationId_Internalname, "Notification Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, "Notification Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A24WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SMS/WWP_SMS.htm");
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
            Z33WWPSMSId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z33WWPSMSId"), ".", ","), 18, MidpointRounding.ToEven));
            Z34WWPSMSStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z34WWPSMSStatus"), ".", ","), 18, MidpointRounding.ToEven));
            Z40WWPSMSCreated = context.localUtil.CToT( cgiGet( "Z40WWPSMSCreated"), 0);
            Z41WWPSMSScheduled = context.localUtil.CToT( cgiGet( "Z41WWPSMSScheduled"), 0);
            Z35WWPSMSProcessed = context.localUtil.CToT( cgiGet( "Z35WWPSMSProcessed"), 0);
            n35WWPSMSProcessed = ((DateTime.MinValue==A35WWPSMSProcessed) ? true : false);
            Z22WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z22WWPNotificationId"), ".", ","), 18, MidpointRounding.ToEven));
            n22WWPNotificationId = ((0==A22WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPSMSID");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A33WWPSMSId = 0;
               AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
            }
            else
            {
               A33WWPSMSId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
            }
            A37WWPSMSMessage = cgiGet( edtWWPSMSMessage_Internalname);
            AssignAttri("", false, "A37WWPSMSMessage", A37WWPSMSMessage);
            A38WWPSMSSenderNumber = cgiGet( edtWWPSMSSenderNumber_Internalname);
            AssignAttri("", false, "A38WWPSMSSenderNumber", A38WWPSMSSenderNumber);
            A39WWPSMSRecipientNumbers = cgiGet( edtWWPSMSRecipientNumbers_Internalname);
            AssignAttri("", false, "A39WWPSMSRecipientNumbers", A39WWPSMSRecipientNumbers);
            cmbWWPSMSStatus.CurrentValue = cgiGet( cmbWWPSMSStatus_Internalname);
            A34WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPSMSStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A34WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A34WWPSMSStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSCreated_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"SMS Created"}), 1, "WWPSMSCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A40WWPSMSCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A40WWPSMSCreated", context.localUtil.TToC( A40WWPSMSCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A40WWPSMSCreated = context.localUtil.CToT( cgiGet( edtWWPSMSCreated_Internalname));
               AssignAttri("", false, "A40WWPSMSCreated", context.localUtil.TToC( A40WWPSMSCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSScheduled_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"SMS Scheduled"}), 1, "WWPSMSSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A41WWPSMSScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A41WWPSMSScheduled", context.localUtil.TToC( A41WWPSMSScheduled, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A41WWPSMSScheduled = context.localUtil.CToT( cgiGet( edtWWPSMSScheduled_Internalname));
               AssignAttri("", false, "A41WWPSMSScheduled", context.localUtil.TToC( A41WWPSMSScheduled, 10, 12, 1, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSProcessed_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"SMS Processed"}), 1, "WWPSMSPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A35WWPSMSProcessed = (DateTime)(DateTime.MinValue);
               n35WWPSMSProcessed = false;
               AssignAttri("", false, "A35WWPSMSProcessed", context.localUtil.TToC( A35WWPSMSProcessed, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A35WWPSMSProcessed = context.localUtil.CToT( cgiGet( edtWWPSMSProcessed_Internalname));
               n35WWPSMSProcessed = false;
               AssignAttri("", false, "A35WWPSMSProcessed", context.localUtil.TToC( A35WWPSMSProcessed, 10, 12, 1, 3, "/", ":", " "));
            }
            n35WWPSMSProcessed = ((DateTime.MinValue==A35WWPSMSProcessed) ? true : false);
            A36WWPSMSDetail = cgiGet( edtWWPSMSDetail_Internalname);
            n36WWPSMSDetail = false;
            AssignAttri("", false, "A36WWPSMSDetail", A36WWPSMSDetail);
            n36WWPSMSDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A36WWPSMSDetail)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A22WWPNotificationId = 0;
               n22WWPNotificationId = false;
               AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            }
            else
            {
               A22WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n22WWPNotificationId = false;
               AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            }
            n22WWPNotificationId = ((0==A22WWPNotificationId) ? true : false);
            A24WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
            AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
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
               A33WWPSMSId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSMSId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
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
               InitAll055( ) ;
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
         DisableAttributes055( ) ;
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

      protected void ResetCaption050( )
      {
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z34WWPSMSStatus = T00053_A34WWPSMSStatus[0];
               Z40WWPSMSCreated = T00053_A40WWPSMSCreated[0];
               Z41WWPSMSScheduled = T00053_A41WWPSMSScheduled[0];
               Z35WWPSMSProcessed = T00053_A35WWPSMSProcessed[0];
               Z22WWPNotificationId = T00053_A22WWPNotificationId[0];
            }
            else
            {
               Z34WWPSMSStatus = A34WWPSMSStatus;
               Z40WWPSMSCreated = A40WWPSMSCreated;
               Z41WWPSMSScheduled = A41WWPSMSScheduled;
               Z35WWPSMSProcessed = A35WWPSMSProcessed;
               Z22WWPNotificationId = A22WWPNotificationId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z33WWPSMSId = A33WWPSMSId;
            Z37WWPSMSMessage = A37WWPSMSMessage;
            Z38WWPSMSSenderNumber = A38WWPSMSSenderNumber;
            Z39WWPSMSRecipientNumbers = A39WWPSMSRecipientNumbers;
            Z34WWPSMSStatus = A34WWPSMSStatus;
            Z40WWPSMSCreated = A40WWPSMSCreated;
            Z41WWPSMSScheduled = A41WWPSMSScheduled;
            Z35WWPSMSProcessed = A35WWPSMSProcessed;
            Z36WWPSMSDetail = A36WWPSMSDetail;
            Z22WWPNotificationId = A22WWPNotificationId;
            Z24WWPNotificationCreated = A24WWPNotificationCreated;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A34WWPSMSStatus) && ( Gx_BScreen == 0 ) )
         {
            A34WWPSMSStatus = 1;
            AssignAttri("", false, "A34WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A34WWPSMSStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A40WWPSMSCreated) && ( Gx_BScreen == 0 ) )
         {
            A40WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A40WWPSMSCreated", context.localUtil.TToC( A40WWPSMSCreated, 10, 12, 1, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A41WWPSMSScheduled) && ( Gx_BScreen == 0 ) )
         {
            A41WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A41WWPSMSScheduled", context.localUtil.TToC( A41WWPSMSScheduled, 10, 12, 1, 3, "/", ":", " "));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load055( )
      {
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A33WWPSMSId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A37WWPSMSMessage = T00055_A37WWPSMSMessage[0];
            AssignAttri("", false, "A37WWPSMSMessage", A37WWPSMSMessage);
            A38WWPSMSSenderNumber = T00055_A38WWPSMSSenderNumber[0];
            AssignAttri("", false, "A38WWPSMSSenderNumber", A38WWPSMSSenderNumber);
            A39WWPSMSRecipientNumbers = T00055_A39WWPSMSRecipientNumbers[0];
            AssignAttri("", false, "A39WWPSMSRecipientNumbers", A39WWPSMSRecipientNumbers);
            A34WWPSMSStatus = T00055_A34WWPSMSStatus[0];
            AssignAttri("", false, "A34WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A34WWPSMSStatus), 4, 0));
            A40WWPSMSCreated = T00055_A40WWPSMSCreated[0];
            AssignAttri("", false, "A40WWPSMSCreated", context.localUtil.TToC( A40WWPSMSCreated, 10, 12, 1, 3, "/", ":", " "));
            A41WWPSMSScheduled = T00055_A41WWPSMSScheduled[0];
            AssignAttri("", false, "A41WWPSMSScheduled", context.localUtil.TToC( A41WWPSMSScheduled, 10, 12, 1, 3, "/", ":", " "));
            A35WWPSMSProcessed = T00055_A35WWPSMSProcessed[0];
            n35WWPSMSProcessed = T00055_n35WWPSMSProcessed[0];
            AssignAttri("", false, "A35WWPSMSProcessed", context.localUtil.TToC( A35WWPSMSProcessed, 10, 12, 1, 3, "/", ":", " "));
            A36WWPSMSDetail = T00055_A36WWPSMSDetail[0];
            n36WWPSMSDetail = T00055_n36WWPSMSDetail[0];
            AssignAttri("", false, "A36WWPSMSDetail", A36WWPSMSDetail);
            A24WWPNotificationCreated = T00055_A24WWPNotificationCreated[0];
            AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            A22WWPNotificationId = T00055_A22WWPNotificationId[0];
            n22WWPNotificationId = T00055_n22WWPNotificationId[0];
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            ZM055( -5) ;
         }
         pr_default.close(3);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
      }

      protected void CheckExtendedTable055( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A34WWPSMSStatus == 1 ) || ( A34WWPSMSStatus == 2 ) || ( A34WWPSMSStatus == 3 ) ) )
         {
            GX_msglist.addItem("Field SMS Status is out of range", "OutOfRange", 1, "WWPSMSSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPSMSStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A22WWPNotificationId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A24WWPNotificationCreated = T00054_A24WWPNotificationCreated[0];
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( long A22WWPNotificationId )
      {
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A22WWPNotificationId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A24WWPNotificationCreated = T00056_A24WWPNotificationCreated[0];
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey055( )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A33WWPSMSId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A33WWPSMSId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 5) ;
            RcdFound5 = 1;
            A33WWPSMSId = T00053_A33WWPSMSId[0];
            AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
            A37WWPSMSMessage = T00053_A37WWPSMSMessage[0];
            AssignAttri("", false, "A37WWPSMSMessage", A37WWPSMSMessage);
            A38WWPSMSSenderNumber = T00053_A38WWPSMSSenderNumber[0];
            AssignAttri("", false, "A38WWPSMSSenderNumber", A38WWPSMSSenderNumber);
            A39WWPSMSRecipientNumbers = T00053_A39WWPSMSRecipientNumbers[0];
            AssignAttri("", false, "A39WWPSMSRecipientNumbers", A39WWPSMSRecipientNumbers);
            A34WWPSMSStatus = T00053_A34WWPSMSStatus[0];
            AssignAttri("", false, "A34WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A34WWPSMSStatus), 4, 0));
            A40WWPSMSCreated = T00053_A40WWPSMSCreated[0];
            AssignAttri("", false, "A40WWPSMSCreated", context.localUtil.TToC( A40WWPSMSCreated, 10, 12, 1, 3, "/", ":", " "));
            A41WWPSMSScheduled = T00053_A41WWPSMSScheduled[0];
            AssignAttri("", false, "A41WWPSMSScheduled", context.localUtil.TToC( A41WWPSMSScheduled, 10, 12, 1, 3, "/", ":", " "));
            A35WWPSMSProcessed = T00053_A35WWPSMSProcessed[0];
            n35WWPSMSProcessed = T00053_n35WWPSMSProcessed[0];
            AssignAttri("", false, "A35WWPSMSProcessed", context.localUtil.TToC( A35WWPSMSProcessed, 10, 12, 1, 3, "/", ":", " "));
            A36WWPSMSDetail = T00053_A36WWPSMSDetail[0];
            n36WWPSMSDetail = T00053_n36WWPSMSDetail[0];
            AssignAttri("", false, "A36WWPSMSDetail", A36WWPSMSDetail);
            A22WWPNotificationId = T00053_A22WWPNotificationId[0];
            n22WWPNotificationId = T00053_n22WWPNotificationId[0];
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            Z33WWPSMSId = A33WWPSMSId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
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
         RcdFound5 = 0;
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A33WWPSMSId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00058_A33WWPSMSId[0] < A33WWPSMSId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00058_A33WWPSMSId[0] > A33WWPSMSId ) ) )
            {
               A33WWPSMSId = T00058_A33WWPSMSId[0];
               AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A33WWPSMSId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00059_A33WWPSMSId[0] > A33WWPSMSId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00059_A33WWPSMSId[0] < A33WWPSMSId ) ) )
            {
               A33WWPSMSId = T00059_A33WWPSMSId[0];
               AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A33WWPSMSId != Z33WWPSMSId )
               {
                  A33WWPSMSId = Z33WWPSMSId;
                  AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPSMSID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A33WWPSMSId != Z33WWPSMSId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPSMSID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPSMSId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPSMSId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
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
         if ( A33WWPSMSId != Z33WWPSMSId )
         {
            A33WWPSMSId = Z33WWPSMSId;
            AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPSMSID");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPSMSId_Internalname;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPSMSID");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound5 != 0 )
            {
               ScanNext055( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A33WWPSMSId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z34WWPSMSStatus != T00052_A34WWPSMSStatus[0] ) || ( Z40WWPSMSCreated != T00052_A40WWPSMSCreated[0] ) || ( Z41WWPSMSScheduled != T00052_A41WWPSMSScheduled[0] ) || ( Z35WWPSMSProcessed != T00052_A35WWPSMSProcessed[0] ) || ( Z22WWPNotificationId != T00052_A22WWPNotificationId[0] ) )
            {
               if ( Z34WWPSMSStatus != T00052_A34WWPSMSStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSStatus");
                  GXUtil.WriteLogRaw("Old: ",Z34WWPSMSStatus);
                  GXUtil.WriteLogRaw("Current: ",T00052_A34WWPSMSStatus[0]);
               }
               if ( Z40WWPSMSCreated != T00052_A40WWPSMSCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSCreated");
                  GXUtil.WriteLogRaw("Old: ",Z40WWPSMSCreated);
                  GXUtil.WriteLogRaw("Current: ",T00052_A40WWPSMSCreated[0]);
               }
               if ( Z41WWPSMSScheduled != T00052_A41WWPSMSScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z41WWPSMSScheduled);
                  GXUtil.WriteLogRaw("Current: ",T00052_A41WWPSMSScheduled[0]);
               }
               if ( Z35WWPSMSProcessed != T00052_A35WWPSMSProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z35WWPSMSProcessed);
                  GXUtil.WriteLogRaw("Current: ",T00052_A35WWPSMSProcessed[0]);
               }
               if ( Z22WWPNotificationId != T00052_A22WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z22WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A22WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_SMS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         if ( ! IsAuthorized("sms_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000510 */
                     pr_default.execute(8, new Object[] {A37WWPSMSMessage, A38WWPSMSSenderNumber, A39WWPSMSRecipientNumbers, A34WWPSMSStatus, A40WWPSMSCreated, A41WWPSMSScheduled, n35WWPSMSProcessed, A35WWPSMSProcessed, n36WWPSMSDetail, A36WWPSMSDetail, n22WWPNotificationId, A22WWPNotificationId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000511 */
                     pr_default.execute(9);
                     A33WWPSMSId = T000511_A33WWPSMSId[0];
                     AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         if ( ! IsAuthorized("sms_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000512 */
                     pr_default.execute(10, new Object[] {A37WWPSMSMessage, A38WWPSMSSenderNumber, A39WWPSMSRecipientNumbers, A34WWPSMSStatus, A40WWPSMSCreated, A41WWPSMSScheduled, n35WWPSMSProcessed, A35WWPSMSProcessed, n36WWPSMSDetail, A36WWPSMSDetail, n22WWPNotificationId, A22WWPNotificationId, A33WWPSMSId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption050( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("sms_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000513 */
                  pr_default.execute(11, new Object[] {A33WWPSMSId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound5 == 0 )
                        {
                           InitAll055( ) ;
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
                        ResetCaption050( ) ;
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000514 */
            pr_default.execute(12, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            A24WWPNotificationCreated = T000514_A24WWPNotificationCreated[0];
            AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            pr_default.close(12);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.sms.wwp_sms",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.sms.wwp_sms",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Using cursor T000515 */
         pr_default.execute(13);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound5 = 1;
            A33WWPSMSId = T000515_A33WWPSMSId[0];
            AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound5 = 1;
            A33WWPSMSId = T000515_A33WWPSMSId[0];
            AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
         edtWWPSMSId_Enabled = 0;
         AssignProp("", false, edtWWPSMSId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSId_Enabled), 5, 0), true);
         edtWWPSMSMessage_Enabled = 0;
         AssignProp("", false, edtWWPSMSMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSMessage_Enabled), 5, 0), true);
         edtWWPSMSSenderNumber_Enabled = 0;
         AssignProp("", false, edtWWPSMSSenderNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSSenderNumber_Enabled), 5, 0), true);
         edtWWPSMSRecipientNumbers_Enabled = 0;
         AssignProp("", false, edtWWPSMSRecipientNumbers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSRecipientNumbers_Enabled), 5, 0), true);
         cmbWWPSMSStatus.Enabled = 0;
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPSMSStatus.Enabled), 5, 0), true);
         edtWWPSMSCreated_Enabled = 0;
         AssignProp("", false, edtWWPSMSCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSCreated_Enabled), 5, 0), true);
         edtWWPSMSScheduled_Enabled = 0;
         AssignProp("", false, edtWWPSMSScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSScheduled_Enabled), 5, 0), true);
         edtWWPSMSProcessed_Enabled = 0;
         AssignProp("", false, edtWWPSMSProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSProcessed_Enabled), 5, 0), true);
         edtWWPSMSDetail_Enabled = 0;
         AssignProp("", false, edtWWPSMSDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSDetail_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.sms.wwp_sms.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z33WWPSMSId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33WWPSMSId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z34WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34WWPSMSStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z40WWPSMSCreated", context.localUtil.TToC( Z40WWPSMSCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z41WWPSMSScheduled", context.localUtil.TToC( Z41WWPSMSScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z35WWPSMSProcessed", context.localUtil.TToC( Z35WWPSMSProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22WWPNotificationId), 10, 0, ".", "")));
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
         return formatLink("wwpbaseobjects.sms.wwp_sms.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SMS.WWP_SMS" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_SMS" ;
      }

      protected void InitializeNonKey055( )
      {
         A37WWPSMSMessage = "";
         AssignAttri("", false, "A37WWPSMSMessage", A37WWPSMSMessage);
         A38WWPSMSSenderNumber = "";
         AssignAttri("", false, "A38WWPSMSSenderNumber", A38WWPSMSSenderNumber);
         A39WWPSMSRecipientNumbers = "";
         AssignAttri("", false, "A39WWPSMSRecipientNumbers", A39WWPSMSRecipientNumbers);
         A35WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         n35WWPSMSProcessed = false;
         AssignAttri("", false, "A35WWPSMSProcessed", context.localUtil.TToC( A35WWPSMSProcessed, 10, 12, 1, 3, "/", ":", " "));
         n35WWPSMSProcessed = ((DateTime.MinValue==A35WWPSMSProcessed) ? true : false);
         A36WWPSMSDetail = "";
         n36WWPSMSDetail = false;
         AssignAttri("", false, "A36WWPSMSDetail", A36WWPSMSDetail);
         n36WWPSMSDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A36WWPSMSDetail)) ? true : false);
         A22WWPNotificationId = 0;
         n22WWPNotificationId = false;
         AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
         n22WWPNotificationId = ((0==A22WWPNotificationId) ? true : false);
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         A34WWPSMSStatus = 1;
         AssignAttri("", false, "A34WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A34WWPSMSStatus), 4, 0));
         A40WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A40WWPSMSCreated", context.localUtil.TToC( A40WWPSMSCreated, 10, 12, 1, 3, "/", ":", " "));
         A41WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A41WWPSMSScheduled", context.localUtil.TToC( A41WWPSMSScheduled, 10, 12, 1, 3, "/", ":", " "));
         Z34WWPSMSStatus = 0;
         Z40WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z41WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z35WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z22WWPNotificationId = 0;
      }

      protected void InitAll055( )
      {
         A33WWPSMSId = 0;
         AssignAttri("", false, "A33WWPSMSId", StringUtil.LTrimStr( (decimal)(A33WWPSMSId), 10, 0));
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A34WWPSMSStatus = i34WWPSMSStatus;
         AssignAttri("", false, "A34WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A34WWPSMSStatus), 4, 0));
         A40WWPSMSCreated = i40WWPSMSCreated;
         AssignAttri("", false, "A40WWPSMSCreated", context.localUtil.TToC( A40WWPSMSCreated, 10, 12, 1, 3, "/", ":", " "));
         A41WWPSMSScheduled = i41WWPSMSScheduled;
         AssignAttri("", false, "A41WWPSMSScheduled", context.localUtil.TToC( A41WWPSMSScheduled, 10, 12, 1, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267482649", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/sms/wwp_sms.js", "?20256267482649", false, true);
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
         edtWWPSMSId_Internalname = "WWPSMSID";
         edtWWPSMSMessage_Internalname = "WWPSMSMESSAGE";
         edtWWPSMSSenderNumber_Internalname = "WWPSMSSENDERNUMBER";
         edtWWPSMSRecipientNumbers_Internalname = "WWPSMSRECIPIENTNUMBERS";
         cmbWWPSMSStatus_Internalname = "WWPSMSSTATUS";
         edtWWPSMSCreated_Internalname = "WWPSMSCREATED";
         edtWWPSMSScheduled_Internalname = "WWPSMSSCHEDULED";
         edtWWPSMSProcessed_Internalname = "WWPSMSPROCESSED";
         edtWWPSMSDetail_Internalname = "WWPSMSDETAIL";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
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
         Form.Caption = "WWP_SMS";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPSMSDetail_Enabled = 1;
         edtWWPSMSProcessed_Jsonclick = "";
         edtWWPSMSProcessed_Enabled = 1;
         edtWWPSMSScheduled_Jsonclick = "";
         edtWWPSMSScheduled_Enabled = 1;
         edtWWPSMSCreated_Jsonclick = "";
         edtWWPSMSCreated_Enabled = 1;
         cmbWWPSMSStatus_Jsonclick = "";
         cmbWWPSMSStatus.Enabled = 1;
         edtWWPSMSRecipientNumbers_Enabled = 1;
         edtWWPSMSSenderNumber_Enabled = 1;
         edtWWPSMSMessage_Enabled = 1;
         edtWWPSMSId_Jsonclick = "";
         edtWWPSMSId_Enabled = 1;
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
         cmbWWPSMSStatus.Name = "WWPSMSSTATUS";
         cmbWWPSMSStatus.WebTags = "";
         cmbWWPSMSStatus.addItem("1", "Pending", 0);
         cmbWWPSMSStatus.addItem("2", "Sent", 0);
         cmbWWPSMSStatus.addItem("3", "Error", 0);
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A34WWPSMSStatus) )
            {
               A34WWPSMSStatus = 1;
               AssignAttri("", false, "A34WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A34WWPSMSStatus), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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

      public void Valid_Wwpsmsid( )
      {
         A34WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPSMSStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A34WWPSMSStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A34WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A34WWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPSMSStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A34WWPSMSStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A34WWPSMSStatus), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A37WWPSMSMessage", A37WWPSMSMessage);
         AssignAttri("", false, "A38WWPSMSSenderNumber", A38WWPSMSSenderNumber);
         AssignAttri("", false, "A39WWPSMSRecipientNumbers", A39WWPSMSRecipientNumbers);
         AssignAttri("", false, "A34WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A34WWPSMSStatus), 4, 0, ".", "")));
         cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A34WWPSMSStatus), 4, 0));
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", cmbWWPSMSStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A40WWPSMSCreated", context.localUtil.TToC( A40WWPSMSCreated, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A41WWPSMSScheduled", context.localUtil.TToC( A41WWPSMSScheduled, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A35WWPSMSProcessed", context.localUtil.TToC( A35WWPSMSProcessed, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A36WWPSMSDetail", A36WWPSMSDetail);
         AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z33WWPSMSId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33WWPSMSId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z37WWPSMSMessage", Z37WWPSMSMessage);
         GxWebStd.gx_hidden_field( context, "Z38WWPSMSSenderNumber", Z38WWPSMSSenderNumber);
         GxWebStd.gx_hidden_field( context, "Z39WWPSMSRecipientNumbers", Z39WWPSMSRecipientNumbers);
         GxWebStd.gx_hidden_field( context, "Z34WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34WWPSMSStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z40WWPSMSCreated", context.localUtil.TToC( Z40WWPSMSCreated, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z41WWPSMSScheduled", context.localUtil.TToC( Z41WWPSMSScheduled, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z35WWPSMSProcessed", context.localUtil.TToC( Z35WWPSMSProcessed, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z36WWPSMSDetail", Z36WWPSMSDetail);
         GxWebStd.gx_hidden_field( context, "Z22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24WWPNotificationCreated", context.localUtil.TToC( Z24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n22WWPNotificationId = false;
         /* Using cursor T000514 */
         pr_default.execute(12, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A22WWPNotificationId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
            }
         }
         A24WWPNotificationCreated = T000514_A24WWPNotificationCreated[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_WWPSMSID","""{"handler":"Valid_Wwpsmsid","iparms":[{"av":"A33WWPSMSId","fld":"WWPSMSID","pic":"ZZZZZZZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"cmbWWPSMSStatus"},{"av":"A34WWPSMSStatus","fld":"WWPSMSSTATUS","pic":"ZZZ9"},{"av":"A40WWPSMSCreated","fld":"WWPSMSCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A41WWPSMSScheduled","fld":"WWPSMSSCHEDULED","pic":"99/99/9999 99:99:99.999"}]""");
         setEventMetadata("VALID_WWPSMSID",""","oparms":[{"av":"A37WWPSMSMessage","fld":"WWPSMSMESSAGE"},{"av":"A38WWPSMSSenderNumber","fld":"WWPSMSSENDERNUMBER"},{"av":"A39WWPSMSRecipientNumbers","fld":"WWPSMSRECIPIENTNUMBERS"},{"av":"cmbWWPSMSStatus"},{"av":"A34WWPSMSStatus","fld":"WWPSMSSTATUS","pic":"ZZZ9"},{"av":"A40WWPSMSCreated","fld":"WWPSMSCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A41WWPSMSScheduled","fld":"WWPSMSSCHEDULED","pic":"99/99/9999 99:99:99.999"},{"av":"A35WWPSMSProcessed","fld":"WWPSMSPROCESSED","pic":"99/99/9999 99:99:99.999"},{"av":"A36WWPSMSDetail","fld":"WWPSMSDETAIL"},{"av":"A22WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z33WWPSMSId"},{"av":"Z37WWPSMSMessage"},{"av":"Z38WWPSMSSenderNumber"},{"av":"Z39WWPSMSRecipientNumbers"},{"av":"Z34WWPSMSStatus"},{"av":"Z40WWPSMSCreated"},{"av":"Z41WWPSMSScheduled"},{"av":"Z35WWPSMSProcessed"},{"av":"Z36WWPSMSDetail"},{"av":"Z22WWPNotificationId"},{"av":"Z24WWPNotificationCreated"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_WWPSMSSTATUS","""{"handler":"Valid_Wwpsmsstatus","iparms":[]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONID","""{"handler":"Valid_Wwpnotificationid","iparms":[{"av":"A22WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONID",""","oparms":[{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"}]}""");
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
         Z40WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z41WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z35WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A37WWPSMSMessage = "";
         A38WWPSMSSenderNumber = "";
         A39WWPSMSRecipientNumbers = "";
         A40WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A41WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A35WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         A36WWPSMSDetail = "";
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
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
         Z37WWPSMSMessage = "";
         Z38WWPSMSSenderNumber = "";
         Z39WWPSMSRecipientNumbers = "";
         Z36WWPSMSDetail = "";
         Z24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         T00055_A33WWPSMSId = new long[1] ;
         T00055_A37WWPSMSMessage = new string[] {""} ;
         T00055_A38WWPSMSSenderNumber = new string[] {""} ;
         T00055_A39WWPSMSRecipientNumbers = new string[] {""} ;
         T00055_A34WWPSMSStatus = new short[1] ;
         T00055_A40WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T00055_A41WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T00055_A35WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T00055_n35WWPSMSProcessed = new bool[] {false} ;
         T00055_A36WWPSMSDetail = new string[] {""} ;
         T00055_n36WWPSMSDetail = new bool[] {false} ;
         T00055_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00055_A22WWPNotificationId = new long[1] ;
         T00055_n22WWPNotificationId = new bool[] {false} ;
         T00054_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00056_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00057_A33WWPSMSId = new long[1] ;
         T00053_A33WWPSMSId = new long[1] ;
         T00053_A37WWPSMSMessage = new string[] {""} ;
         T00053_A38WWPSMSSenderNumber = new string[] {""} ;
         T00053_A39WWPSMSRecipientNumbers = new string[] {""} ;
         T00053_A34WWPSMSStatus = new short[1] ;
         T00053_A40WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T00053_A41WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T00053_A35WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T00053_n35WWPSMSProcessed = new bool[] {false} ;
         T00053_A36WWPSMSDetail = new string[] {""} ;
         T00053_n36WWPSMSDetail = new bool[] {false} ;
         T00053_A22WWPNotificationId = new long[1] ;
         T00053_n22WWPNotificationId = new bool[] {false} ;
         sMode5 = "";
         T00058_A33WWPSMSId = new long[1] ;
         T00059_A33WWPSMSId = new long[1] ;
         T00052_A33WWPSMSId = new long[1] ;
         T00052_A37WWPSMSMessage = new string[] {""} ;
         T00052_A38WWPSMSSenderNumber = new string[] {""} ;
         T00052_A39WWPSMSRecipientNumbers = new string[] {""} ;
         T00052_A34WWPSMSStatus = new short[1] ;
         T00052_A40WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T00052_A41WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T00052_A35WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T00052_n35WWPSMSProcessed = new bool[] {false} ;
         T00052_A36WWPSMSDetail = new string[] {""} ;
         T00052_n36WWPSMSDetail = new bool[] {false} ;
         T00052_A22WWPNotificationId = new long[1] ;
         T00052_n22WWPNotificationId = new bool[] {false} ;
         T000511_A33WWPSMSId = new long[1] ;
         T000514_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000515_A33WWPSMSId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i40WWPSMSCreated = (DateTime)(DateTime.MinValue);
         i41WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         ZZ37WWPSMSMessage = "";
         ZZ38WWPSMSSenderNumber = "";
         ZZ39WWPSMSRecipientNumbers = "";
         ZZ40WWPSMSCreated = (DateTime)(DateTime.MinValue);
         ZZ41WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         ZZ35WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         ZZ36WWPSMSDetail = "";
         ZZ24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__default(),
            new Object[][] {
                new Object[] {
               T00052_A33WWPSMSId, T00052_A37WWPSMSMessage, T00052_A38WWPSMSSenderNumber, T00052_A39WWPSMSRecipientNumbers, T00052_A34WWPSMSStatus, T00052_A40WWPSMSCreated, T00052_A41WWPSMSScheduled, T00052_A35WWPSMSProcessed, T00052_n35WWPSMSProcessed, T00052_A36WWPSMSDetail,
               T00052_n36WWPSMSDetail, T00052_A22WWPNotificationId, T00052_n22WWPNotificationId
               }
               , new Object[] {
               T00053_A33WWPSMSId, T00053_A37WWPSMSMessage, T00053_A38WWPSMSSenderNumber, T00053_A39WWPSMSRecipientNumbers, T00053_A34WWPSMSStatus, T00053_A40WWPSMSCreated, T00053_A41WWPSMSScheduled, T00053_A35WWPSMSProcessed, T00053_n35WWPSMSProcessed, T00053_A36WWPSMSDetail,
               T00053_n36WWPSMSDetail, T00053_A22WWPNotificationId, T00053_n22WWPNotificationId
               }
               , new Object[] {
               T00054_A24WWPNotificationCreated
               }
               , new Object[] {
               T00055_A33WWPSMSId, T00055_A37WWPSMSMessage, T00055_A38WWPSMSSenderNumber, T00055_A39WWPSMSRecipientNumbers, T00055_A34WWPSMSStatus, T00055_A40WWPSMSCreated, T00055_A41WWPSMSScheduled, T00055_A35WWPSMSProcessed, T00055_n35WWPSMSProcessed, T00055_A36WWPSMSDetail,
               T00055_n36WWPSMSDetail, T00055_A24WWPNotificationCreated, T00055_A22WWPNotificationId, T00055_n22WWPNotificationId
               }
               , new Object[] {
               T00056_A24WWPNotificationCreated
               }
               , new Object[] {
               T00057_A33WWPSMSId
               }
               , new Object[] {
               T00058_A33WWPSMSId
               }
               , new Object[] {
               T00059_A33WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               T000511_A33WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000514_A24WWPNotificationCreated
               }
               , new Object[] {
               T000515_A33WWPSMSId
               }
            }
         );
         Z41WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A41WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i41WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z40WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A40WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i40WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z34WWPSMSStatus = 1;
         A34WWPSMSStatus = 1;
         i34WWPSMSStatus = 1;
      }

      private short Z34WWPSMSStatus ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A34WWPSMSStatus ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private short gxajaxcallmode ;
      private short i34WWPSMSStatus ;
      private short ZZ34WWPSMSStatus ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPSMSId_Enabled ;
      private int edtWWPSMSMessage_Enabled ;
      private int edtWWPSMSSenderNumber_Enabled ;
      private int edtWWPSMSRecipientNumbers_Enabled ;
      private int edtWWPSMSCreated_Enabled ;
      private int edtWWPSMSScheduled_Enabled ;
      private int edtWWPSMSProcessed_Enabled ;
      private int edtWWPSMSDetail_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z33WWPSMSId ;
      private long Z22WWPNotificationId ;
      private long A22WWPNotificationId ;
      private long A33WWPSMSId ;
      private long ZZ33WWPSMSId ;
      private long ZZ22WWPNotificationId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPSMSId_Internalname ;
      private string cmbWWPSMSStatus_Internalname ;
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
      private string edtWWPSMSId_Jsonclick ;
      private string edtWWPSMSMessage_Internalname ;
      private string edtWWPSMSSenderNumber_Internalname ;
      private string edtWWPSMSRecipientNumbers_Internalname ;
      private string cmbWWPSMSStatus_Jsonclick ;
      private string edtWWPSMSCreated_Internalname ;
      private string edtWWPSMSCreated_Jsonclick ;
      private string edtWWPSMSScheduled_Internalname ;
      private string edtWWPSMSScheduled_Jsonclick ;
      private string edtWWPSMSProcessed_Internalname ;
      private string edtWWPSMSProcessed_Jsonclick ;
      private string edtWWPSMSDetail_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
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
      private string sMode5 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z40WWPSMSCreated ;
      private DateTime Z41WWPSMSScheduled ;
      private DateTime Z35WWPSMSProcessed ;
      private DateTime A40WWPSMSCreated ;
      private DateTime A41WWPSMSScheduled ;
      private DateTime A35WWPSMSProcessed ;
      private DateTime A24WWPNotificationCreated ;
      private DateTime Z24WWPNotificationCreated ;
      private DateTime i40WWPSMSCreated ;
      private DateTime i41WWPSMSScheduled ;
      private DateTime ZZ40WWPSMSCreated ;
      private DateTime ZZ41WWPSMSScheduled ;
      private DateTime ZZ35WWPSMSProcessed ;
      private DateTime ZZ24WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n22WWPNotificationId ;
      private bool wbErr ;
      private bool n35WWPSMSProcessed ;
      private bool n36WWPSMSDetail ;
      private string A37WWPSMSMessage ;
      private string A38WWPSMSSenderNumber ;
      private string A39WWPSMSRecipientNumbers ;
      private string A36WWPSMSDetail ;
      private string Z37WWPSMSMessage ;
      private string Z38WWPSMSSenderNumber ;
      private string Z39WWPSMSRecipientNumbers ;
      private string Z36WWPSMSDetail ;
      private string ZZ37WWPSMSMessage ;
      private string ZZ38WWPSMSSenderNumber ;
      private string ZZ39WWPSMSRecipientNumbers ;
      private string ZZ36WWPSMSDetail ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPSMSStatus ;
      private IDataStoreProvider pr_default ;
      private long[] T00055_A33WWPSMSId ;
      private string[] T00055_A37WWPSMSMessage ;
      private string[] T00055_A38WWPSMSSenderNumber ;
      private string[] T00055_A39WWPSMSRecipientNumbers ;
      private short[] T00055_A34WWPSMSStatus ;
      private DateTime[] T00055_A40WWPSMSCreated ;
      private DateTime[] T00055_A41WWPSMSScheduled ;
      private DateTime[] T00055_A35WWPSMSProcessed ;
      private bool[] T00055_n35WWPSMSProcessed ;
      private string[] T00055_A36WWPSMSDetail ;
      private bool[] T00055_n36WWPSMSDetail ;
      private DateTime[] T00055_A24WWPNotificationCreated ;
      private long[] T00055_A22WWPNotificationId ;
      private bool[] T00055_n22WWPNotificationId ;
      private DateTime[] T00054_A24WWPNotificationCreated ;
      private DateTime[] T00056_A24WWPNotificationCreated ;
      private long[] T00057_A33WWPSMSId ;
      private long[] T00053_A33WWPSMSId ;
      private string[] T00053_A37WWPSMSMessage ;
      private string[] T00053_A38WWPSMSSenderNumber ;
      private string[] T00053_A39WWPSMSRecipientNumbers ;
      private short[] T00053_A34WWPSMSStatus ;
      private DateTime[] T00053_A40WWPSMSCreated ;
      private DateTime[] T00053_A41WWPSMSScheduled ;
      private DateTime[] T00053_A35WWPSMSProcessed ;
      private bool[] T00053_n35WWPSMSProcessed ;
      private string[] T00053_A36WWPSMSDetail ;
      private bool[] T00053_n36WWPSMSDetail ;
      private long[] T00053_A22WWPNotificationId ;
      private bool[] T00053_n22WWPNotificationId ;
      private long[] T00058_A33WWPSMSId ;
      private long[] T00059_A33WWPSMSId ;
      private long[] T00052_A33WWPSMSId ;
      private string[] T00052_A37WWPSMSMessage ;
      private string[] T00052_A38WWPSMSSenderNumber ;
      private string[] T00052_A39WWPSMSRecipientNumbers ;
      private short[] T00052_A34WWPSMSStatus ;
      private DateTime[] T00052_A40WWPSMSCreated ;
      private DateTime[] T00052_A41WWPSMSScheduled ;
      private DateTime[] T00052_A35WWPSMSProcessed ;
      private bool[] T00052_n35WWPSMSProcessed ;
      private string[] T00052_A36WWPSMSDetail ;
      private bool[] T00052_n36WWPSMSDetail ;
      private long[] T00052_A22WWPNotificationId ;
      private bool[] T00052_n22WWPNotificationId ;
      private long[] T000511_A33WWPSMSId ;
      private DateTime[] T000514_A24WWPNotificationCreated ;
      private long[] T000515_A33WWPSMSId ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_sms__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sms__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00052;
        prmT00052 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT00053;
        prmT00053 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT00054;
        prmT00054 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT00055;
        prmT00055 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT00056;
        prmT00056 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT00057;
        prmT00057 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT00058;
        prmT00058 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT00059;
        prmT00059 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT000510;
        prmT000510 = new Object[] {
        new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000511;
        prmT000511 = new Object[] {
        };
        Object[] prmT000512;
        prmT000512 = new Object[] {
        new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT000513;
        prmT000513 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT000514;
        prmT000514 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000515;
        prmT000515 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00052", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId  FOR UPDATE OF WWP_SMS NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00053", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00054", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00055", "SELECT TM1.WWPSMSId, TM1.WWPSMSMessage, TM1.WWPSMSSenderNumber, TM1.WWPSMSRecipientNumbers, TM1.WWPSMSStatus, TM1.WWPSMSCreated, TM1.WWPSMSScheduled, TM1.WWPSMSProcessed, TM1.WWPSMSDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_SMS TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPSMSId = :WWPSMSId ORDER BY TM1.WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00056", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00057", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00058", "SELECT WWPSMSId FROM WWP_SMS WHERE ( WWPSMSId > :WWPSMSId) ORDER BY WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00059", "SELECT WWPSMSId FROM WWP_SMS WHERE ( WWPSMSId < :WWPSMSId) ORDER BY WWPSMSId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000510", "SAVEPOINT gxupdate;INSERT INTO WWP_SMS(WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId) VALUES(:WWPSMSMessage, :WWPSMSSenderNumber, :WWPSMSRecipientNumbers, :WWPSMSStatus, :WWPSMSCreated, :WWPSMSScheduled, :WWPSMSProcessed, :WWPSMSDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000510)
           ,new CursorDef("T000511", "SELECT currval('WWPSMSId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000512", "SAVEPOINT gxupdate;UPDATE WWP_SMS SET WWPSMSMessage=:WWPSMSMessage, WWPSMSSenderNumber=:WWPSMSSenderNumber, WWPSMSRecipientNumbers=:WWPSMSRecipientNumbers, WWPSMSStatus=:WWPSMSStatus, WWPSMSCreated=:WWPSMSCreated, WWPSMSScheduled=:WWPSMSScheduled, WWPSMSProcessed=:WWPSMSProcessed, WWPSMSDetail=:WWPSMSDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000512)
           ,new CursorDef("T000513", "SAVEPOINT gxupdate;DELETE FROM WWP_SMS  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000513)
           ,new CursorDef("T000514", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000515", "SELECT WWPSMSId FROM WWP_SMS ORDER BY WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((long[]) buf[12])[0] = rslt.getLong(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
