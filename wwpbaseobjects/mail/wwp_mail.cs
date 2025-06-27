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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mail : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridwwp_mail_attachments") == 0 )
         {
            gxnrGridwwp_mail_attachments_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", "Mail", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridwwp_mail_attachments_newrow_invoke( )
      {
         nRC_GXsfl_113 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_113"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_113_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_113_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_113_idx = GetPar( "sGXsfl_113_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridwwp_mail_attachments_newrow( ) ;
         /* End function gxnrGridwwp_mail_attachments_newrow_invoke */
      }

      public wwp_mail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mail( IGxContext context )
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
         cmbWWPMailStatus = new GXCombobox();
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
            return "wwpmail_Execute" ;
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
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            A81WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A81WWPMailStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A81WWPMailStatus", StringUtil.LTrimStr( (decimal)(A81WWPMailStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A81WWPMailStatus), 4, 0));
            AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", cmbWWPMailStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Mail", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A80WWPMailId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPMailId_Enabled!=0) ? context.localUtil.Format( (decimal)(A80WWPMailId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A80WWPMailId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailSubject_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSubject_Internalname, "Subject", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailSubject_Internalname, A69WWPMailSubject, StringUtil.RTrim( context.localUtil.Format( A69WWPMailSubject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailSubject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailSubject_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailBody_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailBody_Internalname, "Body", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailBody_Internalname, A61WWPMailBody, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 1, 1, edtWWPMailBody_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTo_Internalname, "To", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTo_Internalname, A70WWPMailTo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtWWPMailTo_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailCC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailCC_Internalname, "CC", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailCC_Internalname, A83WWPMailCC, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPMailCC_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailBCC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailBCC_Internalname, "BCC", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailBCC_Internalname, A84WWPMailBCC, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtWWPMailBCC_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailSenderAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSenderAddress_Internalname, "Sender Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailSenderAddress_Internalname, A71WWPMailSenderAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPMailSenderAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailSenderName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSenderName_Internalname, "Sender Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailSenderName_Internalname, A72WWPMailSenderName, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPMailSenderName_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPMailStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPMailStatus_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPMailStatus, cmbWWPMailStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A81WWPMailStatus), 4, 0)), 1, cmbWWPMailStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPMailStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A81WWPMailStatus), 4, 0));
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", (string)(cmbWWPMailStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailCreated_Internalname, "Created", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailCreated_Internalname, context.localUtil.TToC( A91WWPMailCreated, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A91WWPMailCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailScheduled_Internalname, "Scheduled", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailScheduled_Internalname, context.localUtil.TToC( A92WWPMailScheduled, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A92WWPMailScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailScheduled_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailProcessed_Internalname, "Processed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailProcessed_Internalname, context.localUtil.TToC( A86WWPMailProcessed, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A86WWPMailProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailProcessed_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailDetail_Internalname, "Detail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailDetail_Internalname, A87WWPMailDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", 0, 1, edtWWPMailDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A24WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divAttachmentstable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleattachments_Internalname, "Attachments", "", "", lblTitleattachments_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridwwp_mail_attachments( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Mail/WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridwwp_mail_attachments( )
      {
         /*  Grid Control  */
         StartGridControl113( ) ;
         nGXsfl_113_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount12 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_12 = 1;
               ScanStart0B12( ) ;
               while ( RcdFound12 != 0 )
               {
                  init_level_properties12( ) ;
                  getByPrimaryKey0B12( ) ;
                  AddRow0B12( ) ;
                  ScanNext0B12( ) ;
               }
               ScanEnd0B12( ) ;
               nBlankRcdCount12 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0B12( ) ;
            standaloneModal0B12( ) ;
            sMode12 = Gx_mode;
            while ( nGXsfl_113_idx < nRC_GXsfl_113 )
            {
               bGXsfl_113_Refreshing = true;
               ReadRow0B12( ) ;
               edtWWPMailAttachmentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               edtWWPMailAttachmentFile_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPMailAttachmentFile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               if ( ( nRcdExists_12 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0B12( ) ;
               }
               SendRow0B12( ) ;
               bGXsfl_113_Refreshing = false;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount12 = 5;
            nRcdExists_12 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0B12( ) ;
               while ( RcdFound12 != 0 )
               {
                  sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_11312( ) ;
                  init_level_properties12( ) ;
                  standaloneNotModal0B12( ) ;
                  getByPrimaryKey0B12( ) ;
                  standaloneModal0B12( ) ;
                  AddRow0B12( ) ;
                  ScanNext0B12( ) ;
               }
               ScanEnd0B12( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode12 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx+1), 4, 0), 4, "0");
         SubsflControlProps_11312( ) ;
         InitAll0B12( ) ;
         init_level_properties12( ) ;
         nRcdExists_12 = 0;
         nIsMod_12 = 0;
         nRcdDeleted_12 = 0;
         nBlankRcdCount12 = (short)(nBlankRcdUsr12+nBlankRcdCount12);
         fRowAdded = 0;
         while ( nBlankRcdCount12 > 0 )
         {
            standaloneNotModal0B12( ) ;
            standaloneModal0B12( ) ;
            AddRow0B12( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtWWPMailAttachmentName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount12 = (short)(nBlankRcdCount12-1);
         }
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridwwp_mail_attachmentsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwwp_mail_attachments", Gridwwp_mail_attachmentsContainer, subGridwwp_mail_attachments_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridwwp_mail_attachmentsContainerData", Gridwwp_mail_attachmentsContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridwwp_mail_attachmentsContainerData"+"V", Gridwwp_mail_attachmentsContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridwwp_mail_attachmentsContainerData"+"V"+"\" value='"+Gridwwp_mail_attachmentsContainer.GridValuesHidden()+"'/>") ;
         }
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
            Z80WWPMailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z80WWPMailId"), ".", ","), 18, MidpointRounding.ToEven));
            Z69WWPMailSubject = cgiGet( "Z69WWPMailSubject");
            Z81WWPMailStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z81WWPMailStatus"), ".", ","), 18, MidpointRounding.ToEven));
            Z91WWPMailCreated = context.localUtil.CToT( cgiGet( "Z91WWPMailCreated"), 0);
            Z92WWPMailScheduled = context.localUtil.CToT( cgiGet( "Z92WWPMailScheduled"), 0);
            Z86WWPMailProcessed = context.localUtil.CToT( cgiGet( "Z86WWPMailProcessed"), 0);
            n86WWPMailProcessed = ((DateTime.MinValue==A86WWPMailProcessed) ? true : false);
            Z22WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z22WWPNotificationId"), ".", ","), 18, MidpointRounding.ToEven));
            n22WWPNotificationId = ((0==A22WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_113 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_113"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPMAILID");
               AnyError = 1;
               GX_FocusControl = edtWWPMailId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A80WWPMailId = 0;
               AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
            }
            else
            {
               A80WWPMailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
            }
            A69WWPMailSubject = cgiGet( edtWWPMailSubject_Internalname);
            AssignAttri("", false, "A69WWPMailSubject", A69WWPMailSubject);
            A61WWPMailBody = cgiGet( edtWWPMailBody_Internalname);
            AssignAttri("", false, "A61WWPMailBody", A61WWPMailBody);
            A70WWPMailTo = cgiGet( edtWWPMailTo_Internalname);
            n70WWPMailTo = false;
            AssignAttri("", false, "A70WWPMailTo", A70WWPMailTo);
            n70WWPMailTo = (String.IsNullOrEmpty(StringUtil.RTrim( A70WWPMailTo)) ? true : false);
            A83WWPMailCC = cgiGet( edtWWPMailCC_Internalname);
            n83WWPMailCC = false;
            AssignAttri("", false, "A83WWPMailCC", A83WWPMailCC);
            n83WWPMailCC = (String.IsNullOrEmpty(StringUtil.RTrim( A83WWPMailCC)) ? true : false);
            A84WWPMailBCC = cgiGet( edtWWPMailBCC_Internalname);
            n84WWPMailBCC = false;
            AssignAttri("", false, "A84WWPMailBCC", A84WWPMailBCC);
            n84WWPMailBCC = (String.IsNullOrEmpty(StringUtil.RTrim( A84WWPMailBCC)) ? true : false);
            A71WWPMailSenderAddress = cgiGet( edtWWPMailSenderAddress_Internalname);
            AssignAttri("", false, "A71WWPMailSenderAddress", A71WWPMailSenderAddress);
            A72WWPMailSenderName = cgiGet( edtWWPMailSenderName_Internalname);
            AssignAttri("", false, "A72WWPMailSenderName", A72WWPMailSenderName);
            cmbWWPMailStatus.Name = cmbWWPMailStatus_Internalname;
            cmbWWPMailStatus.CurrentValue = cgiGet( cmbWWPMailStatus_Internalname);
            A81WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPMailStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A81WWPMailStatus", StringUtil.LTrimStr( (decimal)(A81WWPMailStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailCreated_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Mail Created"}), 1, "WWPMAILCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A91WWPMailCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A91WWPMailCreated", context.localUtil.TToC( A91WWPMailCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A91WWPMailCreated = context.localUtil.CToT( cgiGet( edtWWPMailCreated_Internalname));
               AssignAttri("", false, "A91WWPMailCreated", context.localUtil.TToC( A91WWPMailCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailScheduled_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Mail Scheduled"}), 1, "WWPMAILSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A92WWPMailScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A92WWPMailScheduled", context.localUtil.TToC( A92WWPMailScheduled, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A92WWPMailScheduled = context.localUtil.CToT( cgiGet( edtWWPMailScheduled_Internalname));
               AssignAttri("", false, "A92WWPMailScheduled", context.localUtil.TToC( A92WWPMailScheduled, 10, 12, 1, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailProcessed_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Mail Processed"}), 1, "WWPMAILPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A86WWPMailProcessed = (DateTime)(DateTime.MinValue);
               n86WWPMailProcessed = false;
               AssignAttri("", false, "A86WWPMailProcessed", context.localUtil.TToC( A86WWPMailProcessed, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A86WWPMailProcessed = context.localUtil.CToT( cgiGet( edtWWPMailProcessed_Internalname));
               n86WWPMailProcessed = false;
               AssignAttri("", false, "A86WWPMailProcessed", context.localUtil.TToC( A86WWPMailProcessed, 10, 12, 1, 3, "/", ":", " "));
            }
            n86WWPMailProcessed = ((DateTime.MinValue==A86WWPMailProcessed) ? true : false);
            A87WWPMailDetail = cgiGet( edtWWPMailDetail_Internalname);
            n87WWPMailDetail = false;
            AssignAttri("", false, "A87WWPMailDetail", A87WWPMailDetail);
            n87WWPMailDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A87WWPMailDetail)) ? true : false);
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
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A80WWPMailId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPMailId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll0B11( ) ;
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
         DisableAttributes0B11( ) ;
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

      protected void CONFIRM_0B12( )
      {
         nGXsfl_113_idx = 0;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            ReadRow0B12( ) ;
            if ( ( nRcdExists_12 != 0 ) || ( nIsMod_12 != 0 ) )
            {
               GetKey0B12( ) ;
               if ( ( nRcdExists_12 == 0 ) && ( nRcdDeleted_12 == 0 ) )
               {
                  if ( RcdFound12 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0B12( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0B12( ) ;
                        CloseExtendedTableCursors0B12( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_113_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound12 != 0 )
                  {
                     if ( nRcdDeleted_12 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0B12( ) ;
                        Load0B12( ) ;
                        BeforeValidate0B12( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0B12( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_12 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0B12( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0B12( ) ;
                              CloseExtendedTableCursors0B12( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_12 == 0 )
                     {
                        GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_113_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtWWPMailAttachmentName_Internalname, A93WWPMailAttachmentName) ;
            ChangePostValue( edtWWPMailAttachmentFile_Internalname, A85WWPMailAttachmentFile) ;
            ChangePostValue( "ZT_"+"Z93WWPMailAttachmentName_"+sGXsfl_113_idx, Z93WWPMailAttachmentName) ;
            ChangePostValue( "nRcdDeleted_12_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_12_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_12_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", ""))) ;
            if ( nIsMod_12 != 0 )
            {
               ChangePostValue( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0B0( )
      {
      }

      protected void ZM0B11( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z69WWPMailSubject = T000B5_A69WWPMailSubject[0];
               Z81WWPMailStatus = T000B5_A81WWPMailStatus[0];
               Z91WWPMailCreated = T000B5_A91WWPMailCreated[0];
               Z92WWPMailScheduled = T000B5_A92WWPMailScheduled[0];
               Z86WWPMailProcessed = T000B5_A86WWPMailProcessed[0];
               Z22WWPNotificationId = T000B5_A22WWPNotificationId[0];
            }
            else
            {
               Z69WWPMailSubject = A69WWPMailSubject;
               Z81WWPMailStatus = A81WWPMailStatus;
               Z91WWPMailCreated = A91WWPMailCreated;
               Z92WWPMailScheduled = A92WWPMailScheduled;
               Z86WWPMailProcessed = A86WWPMailProcessed;
               Z22WWPNotificationId = A22WWPNotificationId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z80WWPMailId = A80WWPMailId;
            Z69WWPMailSubject = A69WWPMailSubject;
            Z61WWPMailBody = A61WWPMailBody;
            Z70WWPMailTo = A70WWPMailTo;
            Z83WWPMailCC = A83WWPMailCC;
            Z84WWPMailBCC = A84WWPMailBCC;
            Z71WWPMailSenderAddress = A71WWPMailSenderAddress;
            Z72WWPMailSenderName = A72WWPMailSenderName;
            Z81WWPMailStatus = A81WWPMailStatus;
            Z91WWPMailCreated = A91WWPMailCreated;
            Z92WWPMailScheduled = A92WWPMailScheduled;
            Z86WWPMailProcessed = A86WWPMailProcessed;
            Z87WWPMailDetail = A87WWPMailDetail;
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
         if ( IsIns( )  && (0==A81WWPMailStatus) && ( Gx_BScreen == 0 ) )
         {
            A81WWPMailStatus = 1;
            AssignAttri("", false, "A81WWPMailStatus", StringUtil.LTrimStr( (decimal)(A81WWPMailStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A91WWPMailCreated) && ( Gx_BScreen == 0 ) )
         {
            A91WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A91WWPMailCreated", context.localUtil.TToC( A91WWPMailCreated, 10, 12, 1, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A92WWPMailScheduled) && ( Gx_BScreen == 0 ) )
         {
            A92WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A92WWPMailScheduled", context.localUtil.TToC( A92WWPMailScheduled, 10, 12, 1, 3, "/", ":", " "));
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

      protected void Load0B11( )
      {
         /* Using cursor T000B7 */
         pr_default.execute(5, new Object[] {A80WWPMailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound11 = 1;
            A69WWPMailSubject = T000B7_A69WWPMailSubject[0];
            AssignAttri("", false, "A69WWPMailSubject", A69WWPMailSubject);
            A61WWPMailBody = T000B7_A61WWPMailBody[0];
            AssignAttri("", false, "A61WWPMailBody", A61WWPMailBody);
            A70WWPMailTo = T000B7_A70WWPMailTo[0];
            n70WWPMailTo = T000B7_n70WWPMailTo[0];
            AssignAttri("", false, "A70WWPMailTo", A70WWPMailTo);
            A83WWPMailCC = T000B7_A83WWPMailCC[0];
            n83WWPMailCC = T000B7_n83WWPMailCC[0];
            AssignAttri("", false, "A83WWPMailCC", A83WWPMailCC);
            A84WWPMailBCC = T000B7_A84WWPMailBCC[0];
            n84WWPMailBCC = T000B7_n84WWPMailBCC[0];
            AssignAttri("", false, "A84WWPMailBCC", A84WWPMailBCC);
            A71WWPMailSenderAddress = T000B7_A71WWPMailSenderAddress[0];
            AssignAttri("", false, "A71WWPMailSenderAddress", A71WWPMailSenderAddress);
            A72WWPMailSenderName = T000B7_A72WWPMailSenderName[0];
            AssignAttri("", false, "A72WWPMailSenderName", A72WWPMailSenderName);
            A81WWPMailStatus = T000B7_A81WWPMailStatus[0];
            AssignAttri("", false, "A81WWPMailStatus", StringUtil.LTrimStr( (decimal)(A81WWPMailStatus), 4, 0));
            A91WWPMailCreated = T000B7_A91WWPMailCreated[0];
            AssignAttri("", false, "A91WWPMailCreated", context.localUtil.TToC( A91WWPMailCreated, 10, 12, 1, 3, "/", ":", " "));
            A92WWPMailScheduled = T000B7_A92WWPMailScheduled[0];
            AssignAttri("", false, "A92WWPMailScheduled", context.localUtil.TToC( A92WWPMailScheduled, 10, 12, 1, 3, "/", ":", " "));
            A86WWPMailProcessed = T000B7_A86WWPMailProcessed[0];
            n86WWPMailProcessed = T000B7_n86WWPMailProcessed[0];
            AssignAttri("", false, "A86WWPMailProcessed", context.localUtil.TToC( A86WWPMailProcessed, 10, 12, 1, 3, "/", ":", " "));
            A87WWPMailDetail = T000B7_A87WWPMailDetail[0];
            n87WWPMailDetail = T000B7_n87WWPMailDetail[0];
            AssignAttri("", false, "A87WWPMailDetail", A87WWPMailDetail);
            A24WWPNotificationCreated = T000B7_A24WWPNotificationCreated[0];
            AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            A22WWPNotificationId = T000B7_A22WWPNotificationId[0];
            n22WWPNotificationId = T000B7_n22WWPNotificationId[0];
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            ZM0B11( -5) ;
         }
         pr_default.close(5);
         OnLoadActions0B11( ) ;
      }

      protected void OnLoadActions0B11( )
      {
      }

      protected void CheckExtendedTable0B11( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A81WWPMailStatus == 1 ) || ( A81WWPMailStatus == 2 ) || ( A81WWPMailStatus == 3 ) ) )
         {
            GX_msglist.addItem("Field Mail Status is out of range", "OutOfRange", 1, "WWPMAILSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPMailStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000B6 */
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
         A24WWPNotificationCreated = T000B6_A24WWPNotificationCreated[0];
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0B11( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( long A22WWPNotificationId )
      {
         /* Using cursor T000B8 */
         pr_default.execute(6, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A22WWPNotificationId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A24WWPNotificationCreated = T000B8_A24WWPNotificationCreated[0];
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0B11( )
      {
         /* Using cursor T000B9 */
         pr_default.execute(7, new Object[] {A80WWPMailId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B5 */
         pr_default.execute(3, new Object[] {A80WWPMailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0B11( 5) ;
            RcdFound11 = 1;
            A80WWPMailId = T000B5_A80WWPMailId[0];
            AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
            A69WWPMailSubject = T000B5_A69WWPMailSubject[0];
            AssignAttri("", false, "A69WWPMailSubject", A69WWPMailSubject);
            A61WWPMailBody = T000B5_A61WWPMailBody[0];
            AssignAttri("", false, "A61WWPMailBody", A61WWPMailBody);
            A70WWPMailTo = T000B5_A70WWPMailTo[0];
            n70WWPMailTo = T000B5_n70WWPMailTo[0];
            AssignAttri("", false, "A70WWPMailTo", A70WWPMailTo);
            A83WWPMailCC = T000B5_A83WWPMailCC[0];
            n83WWPMailCC = T000B5_n83WWPMailCC[0];
            AssignAttri("", false, "A83WWPMailCC", A83WWPMailCC);
            A84WWPMailBCC = T000B5_A84WWPMailBCC[0];
            n84WWPMailBCC = T000B5_n84WWPMailBCC[0];
            AssignAttri("", false, "A84WWPMailBCC", A84WWPMailBCC);
            A71WWPMailSenderAddress = T000B5_A71WWPMailSenderAddress[0];
            AssignAttri("", false, "A71WWPMailSenderAddress", A71WWPMailSenderAddress);
            A72WWPMailSenderName = T000B5_A72WWPMailSenderName[0];
            AssignAttri("", false, "A72WWPMailSenderName", A72WWPMailSenderName);
            A81WWPMailStatus = T000B5_A81WWPMailStatus[0];
            AssignAttri("", false, "A81WWPMailStatus", StringUtil.LTrimStr( (decimal)(A81WWPMailStatus), 4, 0));
            A91WWPMailCreated = T000B5_A91WWPMailCreated[0];
            AssignAttri("", false, "A91WWPMailCreated", context.localUtil.TToC( A91WWPMailCreated, 10, 12, 1, 3, "/", ":", " "));
            A92WWPMailScheduled = T000B5_A92WWPMailScheduled[0];
            AssignAttri("", false, "A92WWPMailScheduled", context.localUtil.TToC( A92WWPMailScheduled, 10, 12, 1, 3, "/", ":", " "));
            A86WWPMailProcessed = T000B5_A86WWPMailProcessed[0];
            n86WWPMailProcessed = T000B5_n86WWPMailProcessed[0];
            AssignAttri("", false, "A86WWPMailProcessed", context.localUtil.TToC( A86WWPMailProcessed, 10, 12, 1, 3, "/", ":", " "));
            A87WWPMailDetail = T000B5_A87WWPMailDetail[0];
            n87WWPMailDetail = T000B5_n87WWPMailDetail[0];
            AssignAttri("", false, "A87WWPMailDetail", A87WWPMailDetail);
            A22WWPNotificationId = T000B5_A22WWPNotificationId[0];
            n22WWPNotificationId = T000B5_n22WWPNotificationId[0];
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            Z80WWPMailId = A80WWPMailId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0B11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0B11( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0B11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B11( ) ;
         if ( RcdFound11 == 0 )
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
         RcdFound11 = 0;
         /* Using cursor T000B10 */
         pr_default.execute(8, new Object[] {A80WWPMailId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000B10_A80WWPMailId[0] < A80WWPMailId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000B10_A80WWPMailId[0] > A80WWPMailId ) ) )
            {
               A80WWPMailId = T000B10_A80WWPMailId[0];
               AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T000B11 */
         pr_default.execute(9, new Object[] {A80WWPMailId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000B11_A80WWPMailId[0] > A80WWPMailId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000B11_A80WWPMailId[0] < A80WWPMailId ) ) )
            {
               A80WWPMailId = T000B11_A80WWPMailId[0];
               AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0B11( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( A80WWPMailId != Z80WWPMailId )
               {
                  A80WWPMailId = Z80WWPMailId;
                  AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPMAILID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0B11( ) ;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A80WWPMailId != Z80WWPMailId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0B11( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPMAILID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPMailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0B11( ) ;
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
         if ( A80WWPMailId != Z80WWPMailId )
         {
            A80WWPMailId = Z80WWPMailId;
            AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPMAILID");
            AnyError = 1;
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPMailId_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPMAILID");
            AnyError = 1;
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B11( ) ;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
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
         ScanStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound11 != 0 )
            {
               ScanNext0B11( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B11( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0B11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B4 */
            pr_default.execute(2, new Object[] {A80WWPMailId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z69WWPMailSubject, T000B4_A69WWPMailSubject[0]) != 0 ) || ( Z81WWPMailStatus != T000B4_A81WWPMailStatus[0] ) || ( Z91WWPMailCreated != T000B4_A91WWPMailCreated[0] ) || ( Z92WWPMailScheduled != T000B4_A92WWPMailScheduled[0] ) || ( Z86WWPMailProcessed != T000B4_A86WWPMailProcessed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z22WWPNotificationId != T000B4_A22WWPNotificationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z69WWPMailSubject, T000B4_A69WWPMailSubject[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailSubject");
                  GXUtil.WriteLogRaw("Old: ",Z69WWPMailSubject);
                  GXUtil.WriteLogRaw("Current: ",T000B4_A69WWPMailSubject[0]);
               }
               if ( Z81WWPMailStatus != T000B4_A81WWPMailStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailStatus");
                  GXUtil.WriteLogRaw("Old: ",Z81WWPMailStatus);
                  GXUtil.WriteLogRaw("Current: ",T000B4_A81WWPMailStatus[0]);
               }
               if ( Z91WWPMailCreated != T000B4_A91WWPMailCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailCreated");
                  GXUtil.WriteLogRaw("Old: ",Z91WWPMailCreated);
                  GXUtil.WriteLogRaw("Current: ",T000B4_A91WWPMailCreated[0]);
               }
               if ( Z92WWPMailScheduled != T000B4_A92WWPMailScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z92WWPMailScheduled);
                  GXUtil.WriteLogRaw("Current: ",T000B4_A92WWPMailScheduled[0]);
               }
               if ( Z86WWPMailProcessed != T000B4_A86WWPMailProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z86WWPMailProcessed);
                  GXUtil.WriteLogRaw("Current: ",T000B4_A86WWPMailProcessed[0]);
               }
               if ( Z22WWPNotificationId != T000B4_A22WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z22WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T000B4_A22WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Mail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B11( )
      {
         if ( ! IsAuthorized("wwpmail_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B11( 0) ;
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B12 */
                     pr_default.execute(10, new Object[] {A69WWPMailSubject, A61WWPMailBody, n70WWPMailTo, A70WWPMailTo, n83WWPMailCC, A83WWPMailCC, n84WWPMailBCC, A84WWPMailBCC, A71WWPMailSenderAddress, A72WWPMailSenderName, A81WWPMailStatus, A91WWPMailCreated, A92WWPMailScheduled, n86WWPMailProcessed, A86WWPMailProcessed, n87WWPMailDetail, A87WWPMailDetail, n22WWPNotificationId, A22WWPNotificationId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000B13 */
                     pr_default.execute(11);
                     A80WWPMailId = T000B13_A80WWPMailId[0];
                     AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0B11( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0B0( ) ;
                           }
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
               Load0B11( ) ;
            }
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void Update0B11( )
      {
         if ( ! IsAuthorized("wwpmail_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B14 */
                     pr_default.execute(12, new Object[] {A69WWPMailSubject, A61WWPMailBody, n70WWPMailTo, A70WWPMailTo, n83WWPMailCC, A83WWPMailCC, n84WWPMailBCC, A84WWPMailBCC, A71WWPMailSenderAddress, A72WWPMailSenderName, A81WWPMailStatus, A91WWPMailCreated, A92WWPMailScheduled, n86WWPMailProcessed, A86WWPMailProcessed, n87WWPMailDetail, A87WWPMailDetail, n22WWPNotificationId, A22WWPNotificationId, A80WWPMailId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B11( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0B11( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption0B0( ) ;
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
            }
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void DeferredUpdate0B11( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpmail_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B11( ) ;
            AfterConfirm0B11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B11( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0B12( ) ;
                  while ( RcdFound12 != 0 )
                  {
                     getByPrimaryKey0B12( ) ;
                     Delete0B12( ) ;
                     ScanNext0B12( ) ;
                  }
                  ScanEnd0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B15 */
                     pr_default.execute(13, new Object[] {A80WWPMailId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound11 == 0 )
                           {
                              InitAll0B11( ) ;
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
                           ResetCaption0B0( ) ;
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
         }
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B11( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000B16 */
            pr_default.execute(14, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            A24WWPNotificationCreated = T000B16_A24WWPNotificationCreated[0];
            AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel0B12( )
      {
         nGXsfl_113_idx = 0;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            ReadRow0B12( ) ;
            if ( ( nRcdExists_12 != 0 ) || ( nIsMod_12 != 0 ) )
            {
               standaloneNotModal0B12( ) ;
               GetKey0B12( ) ;
               if ( ( nRcdExists_12 == 0 ) && ( nRcdDeleted_12 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0B12( ) ;
               }
               else
               {
                  if ( RcdFound12 != 0 )
                  {
                     if ( ( nRcdDeleted_12 != 0 ) && ( nRcdExists_12 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0B12( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_12 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0B12( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_12 == 0 )
                     {
                        GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_113_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtWWPMailAttachmentName_Internalname, A93WWPMailAttachmentName) ;
            ChangePostValue( edtWWPMailAttachmentFile_Internalname, A85WWPMailAttachmentFile) ;
            ChangePostValue( "ZT_"+"Z93WWPMailAttachmentName_"+sGXsfl_113_idx, Z93WWPMailAttachmentName) ;
            ChangePostValue( "nRcdDeleted_12_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_12_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_12_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", ""))) ;
            if ( nIsMod_12 != 0 )
            {
               ChangePostValue( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0B12( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_12 = 0;
         nIsMod_12 = 0;
         nRcdDeleted_12 = 0;
      }

      protected void ProcessLevel0B11( )
      {
         /* Save parent mode. */
         sMode11 = Gx_mode;
         ProcessNestedLevel0B12( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0B11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.mail.wwp_mail",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.mail.wwp_mail",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B11( )
      {
         /* Using cursor T000B17 */
         pr_default.execute(15);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound11 = 1;
            A80WWPMailId = T000B17_A80WWPMailId[0];
            AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B11( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound11 = 1;
            A80WWPMailId = T000B17_A80WWPMailId[0];
            AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
         }
      }

      protected void ScanEnd0B11( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0B11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B11( )
      {
         edtWWPMailId_Enabled = 0;
         AssignProp("", false, edtWWPMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailId_Enabled), 5, 0), true);
         edtWWPMailSubject_Enabled = 0;
         AssignProp("", false, edtWWPMailSubject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSubject_Enabled), 5, 0), true);
         edtWWPMailBody_Enabled = 0;
         AssignProp("", false, edtWWPMailBody_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailBody_Enabled), 5, 0), true);
         edtWWPMailTo_Enabled = 0;
         AssignProp("", false, edtWWPMailTo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTo_Enabled), 5, 0), true);
         edtWWPMailCC_Enabled = 0;
         AssignProp("", false, edtWWPMailCC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailCC_Enabled), 5, 0), true);
         edtWWPMailBCC_Enabled = 0;
         AssignProp("", false, edtWWPMailBCC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailBCC_Enabled), 5, 0), true);
         edtWWPMailSenderAddress_Enabled = 0;
         AssignProp("", false, edtWWPMailSenderAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSenderAddress_Enabled), 5, 0), true);
         edtWWPMailSenderName_Enabled = 0;
         AssignProp("", false, edtWWPMailSenderName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSenderName_Enabled), 5, 0), true);
         cmbWWPMailStatus.Enabled = 0;
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPMailStatus.Enabled), 5, 0), true);
         edtWWPMailCreated_Enabled = 0;
         AssignProp("", false, edtWWPMailCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailCreated_Enabled), 5, 0), true);
         edtWWPMailScheduled_Enabled = 0;
         AssignProp("", false, edtWWPMailScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailScheduled_Enabled), 5, 0), true);
         edtWWPMailProcessed_Enabled = 0;
         AssignProp("", false, edtWWPMailProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailProcessed_Enabled), 5, 0), true);
         edtWWPMailDetail_Enabled = 0;
         AssignProp("", false, edtWWPMailDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailDetail_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
      }

      protected void ZM0B12( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -7 )
         {
            Z80WWPMailId = A80WWPMailId;
            Z93WWPMailAttachmentName = A93WWPMailAttachmentName;
            Z85WWPMailAttachmentFile = A85WWPMailAttachmentFile;
         }
      }

      protected void standaloneNotModal0B12( )
      {
      }

      protected void standaloneModal0B12( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPMailAttachmentName_Enabled = 0;
            AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         }
         else
         {
            edtWWPMailAttachmentName_Enabled = 1;
            AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         }
      }

      protected void Load0B12( )
      {
         /* Using cursor T000B18 */
         pr_default.execute(16, new Object[] {A80WWPMailId, A93WWPMailAttachmentName});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound12 = 1;
            A85WWPMailAttachmentFile = T000B18_A85WWPMailAttachmentFile[0];
            ZM0B12( -7) ;
         }
         pr_default.close(16);
         OnLoadActions0B12( ) ;
      }

      protected void OnLoadActions0B12( )
      {
      }

      protected void CheckExtendedTable0B12( )
      {
         nIsDirty_12 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0B12( ) ;
      }

      protected void CloseExtendedTableCursors0B12( )
      {
      }

      protected void enableDisable0B12( )
      {
      }

      protected void GetKey0B12( )
      {
         /* Using cursor T000B19 */
         pr_default.execute(17, new Object[] {A80WWPMailId, A93WWPMailAttachmentName});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey0B12( )
      {
         /* Using cursor T000B3 */
         pr_default.execute(1, new Object[] {A80WWPMailId, A93WWPMailAttachmentName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B12( 7) ;
            RcdFound12 = 1;
            InitializeNonKey0B12( ) ;
            A93WWPMailAttachmentName = T000B3_A93WWPMailAttachmentName[0];
            A85WWPMailAttachmentFile = T000B3_A85WWPMailAttachmentFile[0];
            Z80WWPMailId = A80WWPMailId;
            Z93WWPMailAttachmentName = A93WWPMailAttachmentName;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0B12( ) ;
            Load0B12( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0B12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0B12( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0B12( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0B12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_default.execute(0, new Object[] {A80WWPMailId, A93WWPMailAttachmentName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailAttachments"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B12( )
      {
         if ( ! IsAuthorized("wwpmail_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B12( 0) ;
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B20 */
                     pr_default.execute(18, new Object[] {A80WWPMailId, A93WWPMailAttachmentName, A85WWPMailAttachmentFile});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(18) == 1) )
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
               Load0B12( ) ;
            }
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void Update0B12( )
      {
         if ( ! IsAuthorized("wwpmail_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( ( nIsMod_12 != 0 ) || ( nIsDirty_12 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0B12( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0B12( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000B21 */
                        pr_default.execute(19, new Object[] {A85WWPMailAttachmentFile, A80WWPMailId, A93WWPMailAttachmentName});
                        pr_default.close(19);
                        pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                        if ( (pr_default.getStatus(19) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0B12( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0B12( ) ;
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
               EndLevel0B12( ) ;
            }
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void DeferredUpdate0B12( )
      {
      }

      protected void Delete0B12( )
      {
         if ( ! IsAuthorized("wwpmail_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B12( ) ;
            AfterConfirm0B12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B22 */
                  pr_default.execute(20, new Object[] {A80WWPMailId, A93WWPMailAttachmentName});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B12( ) ;
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B12( )
      {
         standaloneModal0B12( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0B12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B12( )
      {
         /* Scan By routine */
         /* Using cursor T000B23 */
         pr_default.execute(21, new Object[] {A80WWPMailId});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound12 = 1;
            A93WWPMailAttachmentName = T000B23_A93WWPMailAttachmentName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B12( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound12 = 1;
            A93WWPMailAttachmentName = T000B23_A93WWPMailAttachmentName[0];
         }
      }

      protected void ScanEnd0B12( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0B12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B12( )
      {
         edtWWPMailAttachmentName_Enabled = 0;
         AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtWWPMailAttachmentFile_Enabled = 0;
         AssignProp("", false, edtWWPMailAttachmentFile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0), !bGXsfl_113_Refreshing);
      }

      protected void send_integrity_lvl_hashes0B12( )
      {
      }

      protected void send_integrity_lvl_hashes0B11( )
      {
      }

      protected void SubsflControlProps_11312( )
      {
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx;
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx;
      }

      protected void SubsflControlProps_fel_11312( )
      {
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME_"+sGXsfl_113_fel_idx;
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE_"+sGXsfl_113_fel_idx;
      }

      protected void AddRow0B12( )
      {
         nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_11312( ) ;
         SendRow0B12( ) ;
      }

      protected void SendRow0B12( )
      {
         Gridwwp_mail_attachmentsRow = GXWebRow.GetNew(context);
         if ( subGridwwp_mail_attachments_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
            }
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 0;
            subGridwwp_mail_attachments_Backcolor = subGridwwp_mail_attachments_Allbackcolor;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Uniform";
            }
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
            }
            subGridwwp_mail_attachments_Backcolor = (int)(0x0);
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 1;
            if ( ((int)((nGXsfl_113_idx) % (2))) == 0 )
            {
               subGridwwp_mail_attachments_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
               {
                  subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Even";
               }
            }
            else
            {
               subGridwwp_mail_attachments_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
               {
                  subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_113_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 114,'',false,'" + sGXsfl_113_idx + "',113)\"";
         ROClassString = "Attribute";
         Gridwwp_mail_attachmentsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailAttachmentName_Internalname,(string)A93WWPMailAttachmentName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPMailAttachmentName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtWWPMailAttachmentName_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_113_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_113_idx + "',113)\"";
         ROClassString = "Attribute";
         Gridwwp_mail_attachmentsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailAttachmentFile_Internalname,(string)A85WWPMailAttachmentFile,(string)A85WWPMailAttachmentFile,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPMailAttachmentFile_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtWWPMailAttachmentFile_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)113,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         ajax_sending_grid_row(Gridwwp_mail_attachmentsRow);
         send_integrity_lvl_hashes0B12( ) ;
         GXCCtl = "Z93WWPMailAttachmentName_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z93WWPMailAttachmentName);
         GXCCtl = "nRcdDeleted_12_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_12_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", "")));
         GXCCtl = "nIsMod_12_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridwwp_mail_attachmentsContainer.AddRow(Gridwwp_mail_attachmentsRow);
      }

      protected void ReadRow0B12( )
      {
         nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_11312( ) ;
         edtWWPMailAttachmentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtWWPMailAttachmentFile_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         A93WWPMailAttachmentName = cgiGet( edtWWPMailAttachmentName_Internalname);
         A85WWPMailAttachmentFile = cgiGet( edtWWPMailAttachmentFile_Internalname);
         GXCCtl = "Z93WWPMailAttachmentName_" + sGXsfl_113_idx;
         Z93WWPMailAttachmentName = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_12_" + sGXsfl_113_idx;
         nRcdDeleted_12 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_12_" + sGXsfl_113_idx;
         nRcdExists_12 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_12_" + sGXsfl_113_idx;
         nIsMod_12 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtWWPMailAttachmentName_Enabled = edtWWPMailAttachmentName_Enabled;
      }

      protected void ConfirmValues0B0( )
      {
         nGXsfl_113_idx = 0;
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_11312( ) ;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_11312( ) ;
            ChangePostValue( "Z93WWPMailAttachmentName_"+sGXsfl_113_idx, cgiGet( "ZT_"+"Z93WWPMailAttachmentName_"+sGXsfl_113_idx)) ;
            DeletePostValue( "ZT_"+"Z93WWPMailAttachmentName_"+sGXsfl_113_idx) ;
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.mail.wwp_mail.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z80WWPMailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z80WWPMailId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z69WWPMailSubject", Z69WWPMailSubject);
         GxWebStd.gx_hidden_field( context, "Z81WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z81WWPMailStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91WWPMailCreated", context.localUtil.TToC( Z91WWPMailCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z92WWPMailScheduled", context.localUtil.TToC( Z92WWPMailScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z86WWPMailProcessed", context.localUtil.TToC( Z86WWPMailProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_113", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_113_idx), 8, 0, ".", "")));
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
         return formatLink("wwpbaseobjects.mail.wwp_mail.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Mail.WWP_Mail" ;
      }

      public override string GetPgmdesc( )
      {
         return "Mail" ;
      }

      protected void InitializeNonKey0B11( )
      {
         A69WWPMailSubject = "";
         AssignAttri("", false, "A69WWPMailSubject", A69WWPMailSubject);
         A61WWPMailBody = "";
         AssignAttri("", false, "A61WWPMailBody", A61WWPMailBody);
         A70WWPMailTo = "";
         n70WWPMailTo = false;
         AssignAttri("", false, "A70WWPMailTo", A70WWPMailTo);
         n70WWPMailTo = (String.IsNullOrEmpty(StringUtil.RTrim( A70WWPMailTo)) ? true : false);
         A83WWPMailCC = "";
         n83WWPMailCC = false;
         AssignAttri("", false, "A83WWPMailCC", A83WWPMailCC);
         n83WWPMailCC = (String.IsNullOrEmpty(StringUtil.RTrim( A83WWPMailCC)) ? true : false);
         A84WWPMailBCC = "";
         n84WWPMailBCC = false;
         AssignAttri("", false, "A84WWPMailBCC", A84WWPMailBCC);
         n84WWPMailBCC = (String.IsNullOrEmpty(StringUtil.RTrim( A84WWPMailBCC)) ? true : false);
         A71WWPMailSenderAddress = "";
         AssignAttri("", false, "A71WWPMailSenderAddress", A71WWPMailSenderAddress);
         A72WWPMailSenderName = "";
         AssignAttri("", false, "A72WWPMailSenderName", A72WWPMailSenderName);
         A86WWPMailProcessed = (DateTime)(DateTime.MinValue);
         n86WWPMailProcessed = false;
         AssignAttri("", false, "A86WWPMailProcessed", context.localUtil.TToC( A86WWPMailProcessed, 10, 12, 1, 3, "/", ":", " "));
         n86WWPMailProcessed = ((DateTime.MinValue==A86WWPMailProcessed) ? true : false);
         A87WWPMailDetail = "";
         n87WWPMailDetail = false;
         AssignAttri("", false, "A87WWPMailDetail", A87WWPMailDetail);
         n87WWPMailDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A87WWPMailDetail)) ? true : false);
         A22WWPNotificationId = 0;
         n22WWPNotificationId = false;
         AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
         n22WWPNotificationId = ((0==A22WWPNotificationId) ? true : false);
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         A81WWPMailStatus = 1;
         AssignAttri("", false, "A81WWPMailStatus", StringUtil.LTrimStr( (decimal)(A81WWPMailStatus), 4, 0));
         A91WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A91WWPMailCreated", context.localUtil.TToC( A91WWPMailCreated, 10, 12, 1, 3, "/", ":", " "));
         A92WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A92WWPMailScheduled", context.localUtil.TToC( A92WWPMailScheduled, 10, 12, 1, 3, "/", ":", " "));
         Z69WWPMailSubject = "";
         Z81WWPMailStatus = 0;
         Z91WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z92WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z86WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z22WWPNotificationId = 0;
      }

      protected void InitAll0B11( )
      {
         A80WWPMailId = 0;
         AssignAttri("", false, "A80WWPMailId", StringUtil.LTrimStr( (decimal)(A80WWPMailId), 10, 0));
         InitializeNonKey0B11( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A81WWPMailStatus = i81WWPMailStatus;
         AssignAttri("", false, "A81WWPMailStatus", StringUtil.LTrimStr( (decimal)(A81WWPMailStatus), 4, 0));
         A91WWPMailCreated = i91WWPMailCreated;
         AssignAttri("", false, "A91WWPMailCreated", context.localUtil.TToC( A91WWPMailCreated, 10, 12, 1, 3, "/", ":", " "));
         A92WWPMailScheduled = i92WWPMailScheduled;
         AssignAttri("", false, "A92WWPMailScheduled", context.localUtil.TToC( A92WWPMailScheduled, 10, 12, 1, 3, "/", ":", " "));
      }

      protected void InitializeNonKey0B12( )
      {
         A85WWPMailAttachmentFile = "";
      }

      protected void InitAll0B12( )
      {
         A93WWPMailAttachmentName = "";
         InitializeNonKey0B12( ) ;
      }

      protected void StandaloneModalInsert0B12( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267482997", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/mail/wwp_mail.js", "?20256267482997", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties12( )
      {
         edtWWPMailAttachmentName_Enabled = defedtWWPMailAttachmentName_Enabled;
         AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
      }

      protected void StartGridControl113( )
      {
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("GridName", "Gridwwp_mail_attachments");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Header", subGridwwp_mail_attachments_Header);
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Class", "Grid");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Backcolorstyle), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("CmpContext", "");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("InMasterPage", "false");
         Gridwwp_mail_attachmentsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A93WWPMailAttachmentName));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddColumnProperties(Gridwwp_mail_attachmentsColumn);
         Gridwwp_mail_attachmentsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A85WWPMailAttachmentFile));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddColumnProperties(Gridwwp_mail_attachmentsColumn);
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Selectedindex), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowselection), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Selectioncolor), 9, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowhovering), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Hoveringcolor), 9, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowcollapsing), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Collapsed), 1, 0, ".", "")));
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
         edtWWPMailId_Internalname = "WWPMAILID";
         edtWWPMailSubject_Internalname = "WWPMAILSUBJECT";
         edtWWPMailBody_Internalname = "WWPMAILBODY";
         edtWWPMailTo_Internalname = "WWPMAILTO";
         edtWWPMailCC_Internalname = "WWPMAILCC";
         edtWWPMailBCC_Internalname = "WWPMAILBCC";
         edtWWPMailSenderAddress_Internalname = "WWPMAILSENDERADDRESS";
         edtWWPMailSenderName_Internalname = "WWPMAILSENDERNAME";
         cmbWWPMailStatus_Internalname = "WWPMAILSTATUS";
         edtWWPMailCreated_Internalname = "WWPMAILCREATED";
         edtWWPMailScheduled_Internalname = "WWPMAILSCHEDULED";
         edtWWPMailProcessed_Internalname = "WWPMAILPROCESSED";
         edtWWPMailDetail_Internalname = "WWPMAILDETAIL";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         lblTitleattachments_Internalname = "TITLEATTACHMENTS";
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME";
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE";
         divAttachmentstable_Internalname = "ATTACHMENTSTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridwwp_mail_attachments_Internalname = "GRIDWWP_MAIL_ATTACHMENTS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridwwp_mail_attachments_Allowcollapsing = 0;
         subGridwwp_mail_attachments_Allowselection = 0;
         subGridwwp_mail_attachments_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Mail";
         edtWWPMailAttachmentFile_Jsonclick = "";
         edtWWPMailAttachmentName_Jsonclick = "";
         subGridwwp_mail_attachments_Class = "Grid";
         subGridwwp_mail_attachments_Backcolorstyle = 0;
         edtWWPMailAttachmentFile_Enabled = 1;
         edtWWPMailAttachmentName_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPMailDetail_Enabled = 1;
         edtWWPMailProcessed_Jsonclick = "";
         edtWWPMailProcessed_Enabled = 1;
         edtWWPMailScheduled_Jsonclick = "";
         edtWWPMailScheduled_Enabled = 1;
         edtWWPMailCreated_Jsonclick = "";
         edtWWPMailCreated_Enabled = 1;
         cmbWWPMailStatus_Jsonclick = "";
         cmbWWPMailStatus.Enabled = 1;
         edtWWPMailSenderName_Enabled = 1;
         edtWWPMailSenderAddress_Enabled = 1;
         edtWWPMailBCC_Enabled = 1;
         edtWWPMailCC_Enabled = 1;
         edtWWPMailTo_Enabled = 1;
         edtWWPMailBody_Enabled = 1;
         edtWWPMailSubject_Jsonclick = "";
         edtWWPMailSubject_Enabled = 1;
         edtWWPMailId_Jsonclick = "";
         edtWWPMailId_Enabled = 1;
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

      protected void gxnrGridwwp_mail_attachments_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_11312( ) ;
         while ( nGXsfl_113_idx <= nRC_GXsfl_113 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0B12( ) ;
            standaloneModal0B12( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0B12( ) ;
            nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_11312( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridwwp_mail_attachmentsContainer)) ;
         /* End function gxnrGridwwp_mail_attachments_newrow */
      }

      protected void init_web_controls( )
      {
         cmbWWPMailStatus.Name = "WWPMAILSTATUS";
         cmbWWPMailStatus.WebTags = "";
         cmbWWPMailStatus.addItem("1", "Pending", 0);
         cmbWWPMailStatus.addItem("2", "Sent", 0);
         cmbWWPMailStatus.addItem("3", "Error", 0);
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A81WWPMailStatus) )
            {
               A81WWPMailStatus = 1;
               AssignAttri("", false, "A81WWPMailStatus", StringUtil.LTrimStr( (decimal)(A81WWPMailStatus), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPMailSubject_Internalname;
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

      public void Valid_Wwpmailid( )
      {
         A81WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPMailStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A81WWPMailStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            A81WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A81WWPMailStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPMailStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A81WWPMailStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A81WWPMailStatus), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A69WWPMailSubject", A69WWPMailSubject);
         AssignAttri("", false, "A61WWPMailBody", A61WWPMailBody);
         AssignAttri("", false, "A70WWPMailTo", A70WWPMailTo);
         AssignAttri("", false, "A83WWPMailCC", A83WWPMailCC);
         AssignAttri("", false, "A84WWPMailBCC", A84WWPMailBCC);
         AssignAttri("", false, "A71WWPMailSenderAddress", A71WWPMailSenderAddress);
         AssignAttri("", false, "A72WWPMailSenderName", A72WWPMailSenderName);
         AssignAttri("", false, "A81WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A81WWPMailStatus), 4, 0, ".", "")));
         cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A81WWPMailStatus), 4, 0));
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", cmbWWPMailStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A91WWPMailCreated", context.localUtil.TToC( A91WWPMailCreated, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A92WWPMailScheduled", context.localUtil.TToC( A92WWPMailScheduled, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A86WWPMailProcessed", context.localUtil.TToC( A86WWPMailProcessed, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A87WWPMailDetail", A87WWPMailDetail);
         AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z80WWPMailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z80WWPMailId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z69WWPMailSubject", Z69WWPMailSubject);
         GxWebStd.gx_hidden_field( context, "Z61WWPMailBody", Z61WWPMailBody);
         GxWebStd.gx_hidden_field( context, "Z70WWPMailTo", Z70WWPMailTo);
         GxWebStd.gx_hidden_field( context, "Z83WWPMailCC", Z83WWPMailCC);
         GxWebStd.gx_hidden_field( context, "Z84WWPMailBCC", Z84WWPMailBCC);
         GxWebStd.gx_hidden_field( context, "Z71WWPMailSenderAddress", Z71WWPMailSenderAddress);
         GxWebStd.gx_hidden_field( context, "Z72WWPMailSenderName", Z72WWPMailSenderName);
         GxWebStd.gx_hidden_field( context, "Z81WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z81WWPMailStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91WWPMailCreated", context.localUtil.TToC( Z91WWPMailCreated, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z92WWPMailScheduled", context.localUtil.TToC( Z92WWPMailScheduled, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z86WWPMailProcessed", context.localUtil.TToC( Z86WWPMailProcessed, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z87WWPMailDetail", Z87WWPMailDetail);
         GxWebStd.gx_hidden_field( context, "Z22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24WWPNotificationCreated", context.localUtil.TToC( Z24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n22WWPNotificationId = false;
         /* Using cursor T000B16 */
         pr_default.execute(14, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A22WWPNotificationId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
            }
         }
         A24WWPNotificationCreated = T000B16_A24WWPNotificationCreated[0];
         pr_default.close(14);
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
         setEventMetadata("VALID_WWPMAILID","""{"handler":"Valid_Wwpmailid","iparms":[{"av":"A80WWPMailId","fld":"WWPMAILID","pic":"ZZZZZZZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"cmbWWPMailStatus"},{"av":"A81WWPMailStatus","fld":"WWPMAILSTATUS","pic":"ZZZ9"},{"av":"A91WWPMailCreated","fld":"WWPMAILCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A92WWPMailScheduled","fld":"WWPMAILSCHEDULED","pic":"99/99/9999 99:99:99.999"}]""");
         setEventMetadata("VALID_WWPMAILID",""","oparms":[{"av":"A69WWPMailSubject","fld":"WWPMAILSUBJECT"},{"av":"A61WWPMailBody","fld":"WWPMAILBODY"},{"av":"A70WWPMailTo","fld":"WWPMAILTO"},{"av":"A83WWPMailCC","fld":"WWPMAILCC"},{"av":"A84WWPMailBCC","fld":"WWPMAILBCC"},{"av":"A71WWPMailSenderAddress","fld":"WWPMAILSENDERADDRESS"},{"av":"A72WWPMailSenderName","fld":"WWPMAILSENDERNAME"},{"av":"cmbWWPMailStatus"},{"av":"A81WWPMailStatus","fld":"WWPMAILSTATUS","pic":"ZZZ9"},{"av":"A91WWPMailCreated","fld":"WWPMAILCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A92WWPMailScheduled","fld":"WWPMAILSCHEDULED","pic":"99/99/9999 99:99:99.999"},{"av":"A86WWPMailProcessed","fld":"WWPMAILPROCESSED","pic":"99/99/9999 99:99:99.999"},{"av":"A87WWPMailDetail","fld":"WWPMAILDETAIL"},{"av":"A22WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z80WWPMailId"},{"av":"Z69WWPMailSubject"},{"av":"Z61WWPMailBody"},{"av":"Z70WWPMailTo"},{"av":"Z83WWPMailCC"},{"av":"Z84WWPMailBCC"},{"av":"Z71WWPMailSenderAddress"},{"av":"Z72WWPMailSenderName"},{"av":"Z81WWPMailStatus"},{"av":"Z91WWPMailCreated"},{"av":"Z92WWPMailScheduled"},{"av":"Z86WWPMailProcessed"},{"av":"Z87WWPMailDetail"},{"av":"Z22WWPNotificationId"},{"av":"Z24WWPNotificationCreated"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_WWPMAILSTATUS","""{"handler":"Valid_Wwpmailstatus","iparms":[]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONID","""{"handler":"Valid_Wwpnotificationid","iparms":[{"av":"A22WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONID",""","oparms":[{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"}]}""");
         setEventMetadata("VALID_WWPMAILATTACHMENTNAME","""{"handler":"Valid_Wwpmailattachmentname","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Wwpmailattachmentfile","iparms":[]}""");
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
         pr_default.close(3);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z69WWPMailSubject = "";
         Z91WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z92WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z86WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z93WWPMailAttachmentName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A69WWPMailSubject = "";
         A61WWPMailBody = "";
         A70WWPMailTo = "";
         A83WWPMailCC = "";
         A84WWPMailBCC = "";
         A71WWPMailSenderAddress = "";
         A72WWPMailSenderName = "";
         A91WWPMailCreated = (DateTime)(DateTime.MinValue);
         A92WWPMailScheduled = (DateTime)(DateTime.MinValue);
         A86WWPMailProcessed = (DateTime)(DateTime.MinValue);
         A87WWPMailDetail = "";
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         lblTitleattachments_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridwwp_mail_attachmentsContainer = new GXWebGrid( context);
         sMode12 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A93WWPMailAttachmentName = "";
         A85WWPMailAttachmentFile = "";
         Z61WWPMailBody = "";
         Z70WWPMailTo = "";
         Z83WWPMailCC = "";
         Z84WWPMailBCC = "";
         Z71WWPMailSenderAddress = "";
         Z72WWPMailSenderName = "";
         Z87WWPMailDetail = "";
         Z24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         T000B7_A80WWPMailId = new long[1] ;
         T000B7_A69WWPMailSubject = new string[] {""} ;
         T000B7_A61WWPMailBody = new string[] {""} ;
         T000B7_A70WWPMailTo = new string[] {""} ;
         T000B7_n70WWPMailTo = new bool[] {false} ;
         T000B7_A83WWPMailCC = new string[] {""} ;
         T000B7_n83WWPMailCC = new bool[] {false} ;
         T000B7_A84WWPMailBCC = new string[] {""} ;
         T000B7_n84WWPMailBCC = new bool[] {false} ;
         T000B7_A71WWPMailSenderAddress = new string[] {""} ;
         T000B7_A72WWPMailSenderName = new string[] {""} ;
         T000B7_A81WWPMailStatus = new short[1] ;
         T000B7_A91WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000B7_A92WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000B7_A86WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000B7_n86WWPMailProcessed = new bool[] {false} ;
         T000B7_A87WWPMailDetail = new string[] {""} ;
         T000B7_n87WWPMailDetail = new bool[] {false} ;
         T000B7_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B7_A22WWPNotificationId = new long[1] ;
         T000B7_n22WWPNotificationId = new bool[] {false} ;
         T000B6_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B8_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B9_A80WWPMailId = new long[1] ;
         T000B5_A80WWPMailId = new long[1] ;
         T000B5_A69WWPMailSubject = new string[] {""} ;
         T000B5_A61WWPMailBody = new string[] {""} ;
         T000B5_A70WWPMailTo = new string[] {""} ;
         T000B5_n70WWPMailTo = new bool[] {false} ;
         T000B5_A83WWPMailCC = new string[] {""} ;
         T000B5_n83WWPMailCC = new bool[] {false} ;
         T000B5_A84WWPMailBCC = new string[] {""} ;
         T000B5_n84WWPMailBCC = new bool[] {false} ;
         T000B5_A71WWPMailSenderAddress = new string[] {""} ;
         T000B5_A72WWPMailSenderName = new string[] {""} ;
         T000B5_A81WWPMailStatus = new short[1] ;
         T000B5_A91WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000B5_A92WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000B5_A86WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000B5_n86WWPMailProcessed = new bool[] {false} ;
         T000B5_A87WWPMailDetail = new string[] {""} ;
         T000B5_n87WWPMailDetail = new bool[] {false} ;
         T000B5_A22WWPNotificationId = new long[1] ;
         T000B5_n22WWPNotificationId = new bool[] {false} ;
         sMode11 = "";
         T000B10_A80WWPMailId = new long[1] ;
         T000B11_A80WWPMailId = new long[1] ;
         T000B4_A80WWPMailId = new long[1] ;
         T000B4_A69WWPMailSubject = new string[] {""} ;
         T000B4_A61WWPMailBody = new string[] {""} ;
         T000B4_A70WWPMailTo = new string[] {""} ;
         T000B4_n70WWPMailTo = new bool[] {false} ;
         T000B4_A83WWPMailCC = new string[] {""} ;
         T000B4_n83WWPMailCC = new bool[] {false} ;
         T000B4_A84WWPMailBCC = new string[] {""} ;
         T000B4_n84WWPMailBCC = new bool[] {false} ;
         T000B4_A71WWPMailSenderAddress = new string[] {""} ;
         T000B4_A72WWPMailSenderName = new string[] {""} ;
         T000B4_A81WWPMailStatus = new short[1] ;
         T000B4_A91WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000B4_A92WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000B4_A86WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000B4_n86WWPMailProcessed = new bool[] {false} ;
         T000B4_A87WWPMailDetail = new string[] {""} ;
         T000B4_n87WWPMailDetail = new bool[] {false} ;
         T000B4_A22WWPNotificationId = new long[1] ;
         T000B4_n22WWPNotificationId = new bool[] {false} ;
         T000B13_A80WWPMailId = new long[1] ;
         T000B16_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000B17_A80WWPMailId = new long[1] ;
         Z85WWPMailAttachmentFile = "";
         T000B18_A80WWPMailId = new long[1] ;
         T000B18_A93WWPMailAttachmentName = new string[] {""} ;
         T000B18_A85WWPMailAttachmentFile = new string[] {""} ;
         T000B19_A80WWPMailId = new long[1] ;
         T000B19_A93WWPMailAttachmentName = new string[] {""} ;
         T000B3_A80WWPMailId = new long[1] ;
         T000B3_A93WWPMailAttachmentName = new string[] {""} ;
         T000B3_A85WWPMailAttachmentFile = new string[] {""} ;
         T000B2_A80WWPMailId = new long[1] ;
         T000B2_A93WWPMailAttachmentName = new string[] {""} ;
         T000B2_A85WWPMailAttachmentFile = new string[] {""} ;
         T000B23_A80WWPMailId = new long[1] ;
         T000B23_A93WWPMailAttachmentName = new string[] {""} ;
         Gridwwp_mail_attachmentsRow = new GXWebRow();
         subGridwwp_mail_attachments_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i91WWPMailCreated = (DateTime)(DateTime.MinValue);
         i92WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Gridwwp_mail_attachmentsColumn = new GXWebColumn();
         ZZ69WWPMailSubject = "";
         ZZ61WWPMailBody = "";
         ZZ70WWPMailTo = "";
         ZZ83WWPMailCC = "";
         ZZ84WWPMailBCC = "";
         ZZ71WWPMailSenderAddress = "";
         ZZ72WWPMailSenderName = "";
         ZZ91WWPMailCreated = (DateTime)(DateTime.MinValue);
         ZZ92WWPMailScheduled = (DateTime)(DateTime.MinValue);
         ZZ86WWPMailProcessed = (DateTime)(DateTime.MinValue);
         ZZ87WWPMailDetail = "";
         ZZ24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail__default(),
            new Object[][] {
                new Object[] {
               T000B2_A80WWPMailId, T000B2_A93WWPMailAttachmentName, T000B2_A85WWPMailAttachmentFile
               }
               , new Object[] {
               T000B3_A80WWPMailId, T000B3_A93WWPMailAttachmentName, T000B3_A85WWPMailAttachmentFile
               }
               , new Object[] {
               T000B4_A80WWPMailId, T000B4_A69WWPMailSubject, T000B4_A61WWPMailBody, T000B4_A70WWPMailTo, T000B4_n70WWPMailTo, T000B4_A83WWPMailCC, T000B4_n83WWPMailCC, T000B4_A84WWPMailBCC, T000B4_n84WWPMailBCC, T000B4_A71WWPMailSenderAddress,
               T000B4_A72WWPMailSenderName, T000B4_A81WWPMailStatus, T000B4_A91WWPMailCreated, T000B4_A92WWPMailScheduled, T000B4_A86WWPMailProcessed, T000B4_n86WWPMailProcessed, T000B4_A87WWPMailDetail, T000B4_n87WWPMailDetail, T000B4_A22WWPNotificationId, T000B4_n22WWPNotificationId
               }
               , new Object[] {
               T000B5_A80WWPMailId, T000B5_A69WWPMailSubject, T000B5_A61WWPMailBody, T000B5_A70WWPMailTo, T000B5_n70WWPMailTo, T000B5_A83WWPMailCC, T000B5_n83WWPMailCC, T000B5_A84WWPMailBCC, T000B5_n84WWPMailBCC, T000B5_A71WWPMailSenderAddress,
               T000B5_A72WWPMailSenderName, T000B5_A81WWPMailStatus, T000B5_A91WWPMailCreated, T000B5_A92WWPMailScheduled, T000B5_A86WWPMailProcessed, T000B5_n86WWPMailProcessed, T000B5_A87WWPMailDetail, T000B5_n87WWPMailDetail, T000B5_A22WWPNotificationId, T000B5_n22WWPNotificationId
               }
               , new Object[] {
               T000B6_A24WWPNotificationCreated
               }
               , new Object[] {
               T000B7_A80WWPMailId, T000B7_A69WWPMailSubject, T000B7_A61WWPMailBody, T000B7_A70WWPMailTo, T000B7_n70WWPMailTo, T000B7_A83WWPMailCC, T000B7_n83WWPMailCC, T000B7_A84WWPMailBCC, T000B7_n84WWPMailBCC, T000B7_A71WWPMailSenderAddress,
               T000B7_A72WWPMailSenderName, T000B7_A81WWPMailStatus, T000B7_A91WWPMailCreated, T000B7_A92WWPMailScheduled, T000B7_A86WWPMailProcessed, T000B7_n86WWPMailProcessed, T000B7_A87WWPMailDetail, T000B7_n87WWPMailDetail, T000B7_A24WWPNotificationCreated, T000B7_A22WWPNotificationId,
               T000B7_n22WWPNotificationId
               }
               , new Object[] {
               T000B8_A24WWPNotificationCreated
               }
               , new Object[] {
               T000B9_A80WWPMailId
               }
               , new Object[] {
               T000B10_A80WWPMailId
               }
               , new Object[] {
               T000B11_A80WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               T000B13_A80WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B16_A24WWPNotificationCreated
               }
               , new Object[] {
               T000B17_A80WWPMailId
               }
               , new Object[] {
               T000B18_A80WWPMailId, T000B18_A93WWPMailAttachmentName, T000B18_A85WWPMailAttachmentFile
               }
               , new Object[] {
               T000B19_A80WWPMailId, T000B19_A93WWPMailAttachmentName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B23_A80WWPMailId, T000B23_A93WWPMailAttachmentName
               }
            }
         );
         Z92WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A92WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i92WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z91WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A91WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i91WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z81WWPMailStatus = 1;
         A81WWPMailStatus = 1;
         i81WWPMailStatus = 1;
      }

      private short Z81WWPMailStatus ;
      private short nRcdDeleted_12 ;
      private short nRcdExists_12 ;
      private short nIsMod_12 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A81WWPMailStatus ;
      private short nBlankRcdCount12 ;
      private short RcdFound12 ;
      private short nBlankRcdUsr12 ;
      private short Gx_BScreen ;
      private short RcdFound11 ;
      private short nIsDirty_12 ;
      private short subGridwwp_mail_attachments_Backcolorstyle ;
      private short subGridwwp_mail_attachments_Backstyle ;
      private short gxajaxcallmode ;
      private short i81WWPMailStatus ;
      private short subGridwwp_mail_attachments_Allowselection ;
      private short subGridwwp_mail_attachments_Allowhovering ;
      private short subGridwwp_mail_attachments_Allowcollapsing ;
      private short subGridwwp_mail_attachments_Collapsed ;
      private short ZZ81WWPMailStatus ;
      private int nRC_GXsfl_113 ;
      private int nGXsfl_113_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPMailId_Enabled ;
      private int edtWWPMailSubject_Enabled ;
      private int edtWWPMailBody_Enabled ;
      private int edtWWPMailTo_Enabled ;
      private int edtWWPMailCC_Enabled ;
      private int edtWWPMailBCC_Enabled ;
      private int edtWWPMailSenderAddress_Enabled ;
      private int edtWWPMailSenderName_Enabled ;
      private int edtWWPMailCreated_Enabled ;
      private int edtWWPMailScheduled_Enabled ;
      private int edtWWPMailProcessed_Enabled ;
      private int edtWWPMailDetail_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtWWPMailAttachmentName_Enabled ;
      private int edtWWPMailAttachmentFile_Enabled ;
      private int fRowAdded ;
      private int subGridwwp_mail_attachments_Backcolor ;
      private int subGridwwp_mail_attachments_Allbackcolor ;
      private int defedtWWPMailAttachmentName_Enabled ;
      private int idxLst ;
      private int subGridwwp_mail_attachments_Selectedindex ;
      private int subGridwwp_mail_attachments_Selectioncolor ;
      private int subGridwwp_mail_attachments_Hoveringcolor ;
      private long Z80WWPMailId ;
      private long Z22WWPNotificationId ;
      private long A22WWPNotificationId ;
      private long A80WWPMailId ;
      private long GRIDWWP_MAIL_ATTACHMENTS_nFirstRecordOnPage ;
      private long ZZ80WWPMailId ;
      private long ZZ22WWPNotificationId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPMailId_Internalname ;
      private string sGXsfl_113_idx="0001" ;
      private string Gx_mode ;
      private string cmbWWPMailStatus_Internalname ;
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
      private string edtWWPMailId_Jsonclick ;
      private string edtWWPMailSubject_Internalname ;
      private string edtWWPMailSubject_Jsonclick ;
      private string edtWWPMailBody_Internalname ;
      private string edtWWPMailTo_Internalname ;
      private string edtWWPMailCC_Internalname ;
      private string edtWWPMailBCC_Internalname ;
      private string edtWWPMailSenderAddress_Internalname ;
      private string edtWWPMailSenderName_Internalname ;
      private string cmbWWPMailStatus_Jsonclick ;
      private string edtWWPMailCreated_Internalname ;
      private string edtWWPMailCreated_Jsonclick ;
      private string edtWWPMailScheduled_Internalname ;
      private string edtWWPMailScheduled_Jsonclick ;
      private string edtWWPMailProcessed_Internalname ;
      private string edtWWPMailProcessed_Jsonclick ;
      private string edtWWPMailDetail_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string divAttachmentstable_Internalname ;
      private string lblTitleattachments_Internalname ;
      private string lblTitleattachments_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode12 ;
      private string edtWWPMailAttachmentName_Internalname ;
      private string edtWWPMailAttachmentFile_Internalname ;
      private string sStyleString ;
      private string subGridwwp_mail_attachments_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode11 ;
      private string sGXsfl_113_fel_idx="0001" ;
      private string subGridwwp_mail_attachments_Class ;
      private string subGridwwp_mail_attachments_Linesclass ;
      private string ROClassString ;
      private string edtWWPMailAttachmentName_Jsonclick ;
      private string edtWWPMailAttachmentFile_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridwwp_mail_attachments_Header ;
      private DateTime Z91WWPMailCreated ;
      private DateTime Z92WWPMailScheduled ;
      private DateTime Z86WWPMailProcessed ;
      private DateTime A91WWPMailCreated ;
      private DateTime A92WWPMailScheduled ;
      private DateTime A86WWPMailProcessed ;
      private DateTime A24WWPNotificationCreated ;
      private DateTime Z24WWPNotificationCreated ;
      private DateTime i91WWPMailCreated ;
      private DateTime i92WWPMailScheduled ;
      private DateTime ZZ91WWPMailCreated ;
      private DateTime ZZ92WWPMailScheduled ;
      private DateTime ZZ86WWPMailProcessed ;
      private DateTime ZZ24WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n22WWPNotificationId ;
      private bool wbErr ;
      private bool bGXsfl_113_Refreshing=false ;
      private bool n86WWPMailProcessed ;
      private bool n70WWPMailTo ;
      private bool n83WWPMailCC ;
      private bool n84WWPMailBCC ;
      private bool n87WWPMailDetail ;
      private bool Gx_longc ;
      private string A61WWPMailBody ;
      private string A70WWPMailTo ;
      private string A83WWPMailCC ;
      private string A84WWPMailBCC ;
      private string A71WWPMailSenderAddress ;
      private string A72WWPMailSenderName ;
      private string A87WWPMailDetail ;
      private string A85WWPMailAttachmentFile ;
      private string Z61WWPMailBody ;
      private string Z70WWPMailTo ;
      private string Z83WWPMailCC ;
      private string Z84WWPMailBCC ;
      private string Z71WWPMailSenderAddress ;
      private string Z72WWPMailSenderName ;
      private string Z87WWPMailDetail ;
      private string Z85WWPMailAttachmentFile ;
      private string ZZ61WWPMailBody ;
      private string ZZ70WWPMailTo ;
      private string ZZ83WWPMailCC ;
      private string ZZ84WWPMailBCC ;
      private string ZZ71WWPMailSenderAddress ;
      private string ZZ72WWPMailSenderName ;
      private string ZZ87WWPMailDetail ;
      private string Z69WWPMailSubject ;
      private string Z93WWPMailAttachmentName ;
      private string A69WWPMailSubject ;
      private string A93WWPMailAttachmentName ;
      private string ZZ69WWPMailSubject ;
      private GXWebGrid Gridwwp_mail_attachmentsContainer ;
      private GXWebRow Gridwwp_mail_attachmentsRow ;
      private GXWebColumn Gridwwp_mail_attachmentsColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPMailStatus ;
      private IDataStoreProvider pr_default ;
      private long[] T000B7_A80WWPMailId ;
      private string[] T000B7_A69WWPMailSubject ;
      private string[] T000B7_A61WWPMailBody ;
      private string[] T000B7_A70WWPMailTo ;
      private bool[] T000B7_n70WWPMailTo ;
      private string[] T000B7_A83WWPMailCC ;
      private bool[] T000B7_n83WWPMailCC ;
      private string[] T000B7_A84WWPMailBCC ;
      private bool[] T000B7_n84WWPMailBCC ;
      private string[] T000B7_A71WWPMailSenderAddress ;
      private string[] T000B7_A72WWPMailSenderName ;
      private short[] T000B7_A81WWPMailStatus ;
      private DateTime[] T000B7_A91WWPMailCreated ;
      private DateTime[] T000B7_A92WWPMailScheduled ;
      private DateTime[] T000B7_A86WWPMailProcessed ;
      private bool[] T000B7_n86WWPMailProcessed ;
      private string[] T000B7_A87WWPMailDetail ;
      private bool[] T000B7_n87WWPMailDetail ;
      private DateTime[] T000B7_A24WWPNotificationCreated ;
      private long[] T000B7_A22WWPNotificationId ;
      private bool[] T000B7_n22WWPNotificationId ;
      private DateTime[] T000B6_A24WWPNotificationCreated ;
      private DateTime[] T000B8_A24WWPNotificationCreated ;
      private long[] T000B9_A80WWPMailId ;
      private long[] T000B5_A80WWPMailId ;
      private string[] T000B5_A69WWPMailSubject ;
      private string[] T000B5_A61WWPMailBody ;
      private string[] T000B5_A70WWPMailTo ;
      private bool[] T000B5_n70WWPMailTo ;
      private string[] T000B5_A83WWPMailCC ;
      private bool[] T000B5_n83WWPMailCC ;
      private string[] T000B5_A84WWPMailBCC ;
      private bool[] T000B5_n84WWPMailBCC ;
      private string[] T000B5_A71WWPMailSenderAddress ;
      private string[] T000B5_A72WWPMailSenderName ;
      private short[] T000B5_A81WWPMailStatus ;
      private DateTime[] T000B5_A91WWPMailCreated ;
      private DateTime[] T000B5_A92WWPMailScheduled ;
      private DateTime[] T000B5_A86WWPMailProcessed ;
      private bool[] T000B5_n86WWPMailProcessed ;
      private string[] T000B5_A87WWPMailDetail ;
      private bool[] T000B5_n87WWPMailDetail ;
      private long[] T000B5_A22WWPNotificationId ;
      private bool[] T000B5_n22WWPNotificationId ;
      private long[] T000B10_A80WWPMailId ;
      private long[] T000B11_A80WWPMailId ;
      private long[] T000B4_A80WWPMailId ;
      private string[] T000B4_A69WWPMailSubject ;
      private string[] T000B4_A61WWPMailBody ;
      private string[] T000B4_A70WWPMailTo ;
      private bool[] T000B4_n70WWPMailTo ;
      private string[] T000B4_A83WWPMailCC ;
      private bool[] T000B4_n83WWPMailCC ;
      private string[] T000B4_A84WWPMailBCC ;
      private bool[] T000B4_n84WWPMailBCC ;
      private string[] T000B4_A71WWPMailSenderAddress ;
      private string[] T000B4_A72WWPMailSenderName ;
      private short[] T000B4_A81WWPMailStatus ;
      private DateTime[] T000B4_A91WWPMailCreated ;
      private DateTime[] T000B4_A92WWPMailScheduled ;
      private DateTime[] T000B4_A86WWPMailProcessed ;
      private bool[] T000B4_n86WWPMailProcessed ;
      private string[] T000B4_A87WWPMailDetail ;
      private bool[] T000B4_n87WWPMailDetail ;
      private long[] T000B4_A22WWPNotificationId ;
      private bool[] T000B4_n22WWPNotificationId ;
      private long[] T000B13_A80WWPMailId ;
      private DateTime[] T000B16_A24WWPNotificationCreated ;
      private long[] T000B17_A80WWPMailId ;
      private long[] T000B18_A80WWPMailId ;
      private string[] T000B18_A93WWPMailAttachmentName ;
      private string[] T000B18_A85WWPMailAttachmentFile ;
      private long[] T000B19_A80WWPMailId ;
      private string[] T000B19_A93WWPMailAttachmentName ;
      private long[] T000B3_A80WWPMailId ;
      private string[] T000B3_A93WWPMailAttachmentName ;
      private string[] T000B3_A85WWPMailAttachmentFile ;
      private long[] T000B2_A80WWPMailId ;
      private string[] T000B2_A93WWPMailAttachmentName ;
      private string[] T000B2_A85WWPMailAttachmentFile ;
      private long[] T000B23_A80WWPMailId ;
      private string[] T000B23_A93WWPMailAttachmentName ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_mail__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mail__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000B2;
        prmT000B2 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000B3;
        prmT000B3 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000B4;
        prmT000B4 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000B5;
        prmT000B5 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000B6;
        prmT000B6 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000B7;
        prmT000B7 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000B8;
        prmT000B8 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000B9;
        prmT000B9 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000B10;
        prmT000B10 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000B11;
        prmT000B11 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000B12;
        prmT000B12 = new Object[] {
        new ParDef("WWPMailSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTo",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailBCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPMailDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000B13;
        prmT000B13 = new Object[] {
        };
        Object[] prmT000B14;
        prmT000B14 = new Object[] {
        new ParDef("WWPMailSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTo",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailBCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPMailDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000B15;
        prmT000B15 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000B16;
        prmT000B16 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000B17;
        prmT000B17 = new Object[] {
        };
        Object[] prmT000B18;
        prmT000B18 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000B19;
        prmT000B19 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000B20;
        prmT000B20 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0) ,
        new ParDef("WWPMailAttachmentFile",GXType.LongVarChar,2097152,0)
        };
        Object[] prmT000B21;
        prmT000B21 = new Object[] {
        new ParDef("WWPMailAttachmentFile",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000B22;
        prmT000B22 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000B23;
        prmT000B23 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000B2", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName  FOR UPDATE OF WWP_MailAttachments NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B3", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B4", "SELECT WWPMailId, WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId FROM WWP_Mail WHERE WWPMailId = :WWPMailId  FOR UPDATE OF WWP_Mail NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B5", "SELECT WWPMailId, WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId FROM WWP_Mail WHERE WWPMailId = :WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B6", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B7", "SELECT TM1.WWPMailId, TM1.WWPMailSubject, TM1.WWPMailBody, TM1.WWPMailTo, TM1.WWPMailCC, TM1.WWPMailBCC, TM1.WWPMailSenderAddress, TM1.WWPMailSenderName, TM1.WWPMailStatus, TM1.WWPMailCreated, TM1.WWPMailScheduled, TM1.WWPMailProcessed, TM1.WWPMailDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_Mail TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPMailId = :WWPMailId ORDER BY TM1.WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B8", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B9", "SELECT WWPMailId FROM WWP_Mail WHERE WWPMailId = :WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B10", "SELECT WWPMailId FROM WWP_Mail WHERE ( WWPMailId > :WWPMailId) ORDER BY WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B11", "SELECT WWPMailId FROM WWP_Mail WHERE ( WWPMailId < :WWPMailId) ORDER BY WWPMailId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B12", "SAVEPOINT gxupdate;INSERT INTO WWP_Mail(WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId) VALUES(:WWPMailSubject, :WWPMailBody, :WWPMailTo, :WWPMailCC, :WWPMailBCC, :WWPMailSenderAddress, :WWPMailSenderName, :WWPMailStatus, :WWPMailCreated, :WWPMailScheduled, :WWPMailProcessed, :WWPMailDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000B12)
           ,new CursorDef("T000B13", "SELECT currval('WWPMailId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B14", "SAVEPOINT gxupdate;UPDATE WWP_Mail SET WWPMailSubject=:WWPMailSubject, WWPMailBody=:WWPMailBody, WWPMailTo=:WWPMailTo, WWPMailCC=:WWPMailCC, WWPMailBCC=:WWPMailBCC, WWPMailSenderAddress=:WWPMailSenderAddress, WWPMailSenderName=:WWPMailSenderName, WWPMailStatus=:WWPMailStatus, WWPMailCreated=:WWPMailCreated, WWPMailScheduled=:WWPMailScheduled, WWPMailProcessed=:WWPMailProcessed, WWPMailDetail=:WWPMailDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPMailId = :WWPMailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000B14)
           ,new CursorDef("T000B15", "SAVEPOINT gxupdate;DELETE FROM WWP_Mail  WHERE WWPMailId = :WWPMailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000B15)
           ,new CursorDef("T000B16", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B17", "SELECT WWPMailId FROM WWP_Mail ORDER BY WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B18", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId and WWPMailAttachmentName = ( :WWPMailAttachmentName) ORDER BY WWPMailId, WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B18,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B19", "SELECT WWPMailId, WWPMailAttachmentName FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B20", "SAVEPOINT gxupdate;INSERT INTO WWP_MailAttachments(WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile) VALUES(:WWPMailId, :WWPMailAttachmentName, :WWPMailAttachmentFile);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000B20)
           ,new CursorDef("T000B21", "SAVEPOINT gxupdate;UPDATE WWP_MailAttachments SET WWPMailAttachmentFile=:WWPMailAttachmentFile  WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000B21)
           ,new CursorDef("T000B22", "SAVEPOINT gxupdate;DELETE FROM WWP_MailAttachments  WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000B22)
           ,new CursorDef("T000B23", "SELECT WWPMailId, WWPMailAttachmentName FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId ORDER BY WWPMailId, WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B23,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
              ((long[]) buf[19])[0] = rslt.getLong(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              return;
           case 6 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}
