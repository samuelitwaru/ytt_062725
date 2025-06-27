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
   public class wwp_webnotification : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A23WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A23WWPNotificationDefinitionId) ;
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
         Form.Meta.addItem("description", "WWP_Web Notification", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_webnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webnotification( IGxContext context )
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
         cmbWWPWebNotificationStatus = new GXCombobox();
         chkWWPWebNotificationReceived = new GXCheckbox();
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
            return "webnotification_Execute" ;
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
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A54WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A54WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A54WWPWebNotificationStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0));
            AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", cmbWWPWebNotificationStatus.ToJavascriptSource(), true);
         }
         A57WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A57WWPWebNotificationReceived));
         n57WWPWebNotificationReceived = false;
         AssignAttri("", false, "A57WWPWebNotificationReceived", A57WWPWebNotificationReceived);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_Web Notification", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationId_Internalname, "Notification Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A47WWPWebNotificationId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPWebNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A47WWPWebNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A47WWPWebNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationTitle_Internalname, "Notification Title", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationTitle_Internalname, A42WWPWebNotificationTitle, StringUtil.RTrim( context.localUtil.Format( A42WWPWebNotificationTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationTitle_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A24WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationMetadata_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationMetadata_Internalname, "WWPNotification Metadata", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationMetadata_Internalname, A60WWPNotificationMetadata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionName_Internalname, "Notification Definition Internal Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A59WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A59WWPNotificationDefinitionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationText_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationText_Internalname, "Notification Text", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationText_Internalname, A43WWPWebNotificationText, StringUtil.RTrim( context.localUtil.Format( A43WWPWebNotificationText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationText_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationText_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationIcon_Internalname, "Notification Icon", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationIcon_Internalname, A44WWPWebNotificationIcon, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPWebNotificationIcon_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationClientId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationClientId_Internalname, "Client Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationClientId_Internalname, A53WWPWebNotificationClientId, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPWebNotificationClientId_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPWebNotificationStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPWebNotificationStatus_Internalname, "Notification Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPWebNotificationStatus, cmbWWPWebNotificationStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0)), 1, cmbWWPWebNotificationStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPWebNotificationStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0));
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", (string)(cmbWWPWebNotificationStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationCreated_Internalname, "Notification Created", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationCreated_Internalname, context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A45WWPWebNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationScheduled_Internalname, "Notification Scheduled", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationScheduled_Internalname, context.localUtil.TToC( A58WWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A58WWPWebNotificationScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationScheduled_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationProcessed_Internalname, "Notification Processed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationProcessed_Internalname, context.localUtil.TToC( A55WWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A55WWPWebNotificationProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationProcessed_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationRead_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationRead_Internalname, "Notification Read", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationRead_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationRead_Internalname, context.localUtil.TToC( A46WWPWebNotificationRead, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A46WWPWebNotificationRead, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationRead_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationRead_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationRead_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationRead_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationDetail_Internalname, "Notification Detail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationDetail_Internalname, A56WWPWebNotificationDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", 0, 1, edtWWPWebNotificationDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPWebNotificationReceived_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPWebNotificationReceived_Internalname, "Notification Received", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPWebNotificationReceived_Internalname, StringUtil.BoolToStr( A57WWPWebNotificationReceived), "", "Notification Received", 1, chkWWPWebNotificationReceived.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(109, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,109);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Web/WWP_WebNotification.htm");
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
            Z47WWPWebNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z47WWPWebNotificationId"), ".", ","), 18, MidpointRounding.ToEven));
            Z42WWPWebNotificationTitle = cgiGet( "Z42WWPWebNotificationTitle");
            Z43WWPWebNotificationText = cgiGet( "Z43WWPWebNotificationText");
            Z44WWPWebNotificationIcon = cgiGet( "Z44WWPWebNotificationIcon");
            Z54WWPWebNotificationStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z54WWPWebNotificationStatus"), ".", ","), 18, MidpointRounding.ToEven));
            Z45WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( "Z45WWPWebNotificationCreated"), 0);
            Z58WWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( "Z58WWPWebNotificationScheduled"), 0);
            Z55WWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( "Z55WWPWebNotificationProcessed"), 0);
            Z46WWPWebNotificationRead = context.localUtil.CToT( cgiGet( "Z46WWPWebNotificationRead"), 0);
            n46WWPWebNotificationRead = ((DateTime.MinValue==A46WWPWebNotificationRead) ? true : false);
            Z57WWPWebNotificationReceived = StringUtil.StrToBool( cgiGet( "Z57WWPWebNotificationReceived"));
            n57WWPWebNotificationReceived = ((false==A57WWPWebNotificationReceived) ? true : false);
            Z22WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z22WWPNotificationId"), ".", ","), 18, MidpointRounding.ToEven));
            n22WWPNotificationId = ((0==A22WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
            A23WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "WWPNOTIFICATIONDEFINITIONID"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPWEBNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A47WWPWebNotificationId = 0;
               AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
            }
            else
            {
               A47WWPWebNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
            }
            A42WWPWebNotificationTitle = cgiGet( edtWWPWebNotificationTitle_Internalname);
            AssignAttri("", false, "A42WWPWebNotificationTitle", A42WWPWebNotificationTitle);
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
            A60WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
            n60WWPNotificationMetadata = false;
            AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
            A59WWPNotificationDefinitionName = cgiGet( edtWWPNotificationDefinitionName_Internalname);
            AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
            A43WWPWebNotificationText = cgiGet( edtWWPWebNotificationText_Internalname);
            AssignAttri("", false, "A43WWPWebNotificationText", A43WWPWebNotificationText);
            A44WWPWebNotificationIcon = cgiGet( edtWWPWebNotificationIcon_Internalname);
            AssignAttri("", false, "A44WWPWebNotificationIcon", A44WWPWebNotificationIcon);
            A53WWPWebNotificationClientId = cgiGet( edtWWPWebNotificationClientId_Internalname);
            AssignAttri("", false, "A53WWPWebNotificationClientId", A53WWPWebNotificationClientId);
            cmbWWPWebNotificationStatus.CurrentValue = cgiGet( cmbWWPWebNotificationStatus_Internalname);
            A54WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPWebNotificationStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A54WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A54WWPWebNotificationStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationCreated_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Created"}), 1, "WWPWEBNOTIFICATIONCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A45WWPWebNotificationCreated", context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A45WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPWebNotificationCreated_Internalname));
               AssignAttri("", false, "A45WWPWebNotificationCreated", context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationScheduled_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Scheduled"}), 1, "WWPWEBNOTIFICATIONSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A58WWPWebNotificationScheduled", context.localUtil.TToC( A58WWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A58WWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( edtWWPWebNotificationScheduled_Internalname));
               AssignAttri("", false, "A58WWPWebNotificationScheduled", context.localUtil.TToC( A58WWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationProcessed_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Processed"}), 1, "WWPWEBNOTIFICATIONPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A55WWPWebNotificationProcessed", context.localUtil.TToC( A55WWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A55WWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( edtWWPWebNotificationProcessed_Internalname));
               AssignAttri("", false, "A55WWPWebNotificationProcessed", context.localUtil.TToC( A55WWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationRead_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Read"}), 1, "WWPWEBNOTIFICATIONREAD");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationRead_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A46WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
               n46WWPWebNotificationRead = false;
               AssignAttri("", false, "A46WWPWebNotificationRead", context.localUtil.TToC( A46WWPWebNotificationRead, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A46WWPWebNotificationRead = context.localUtil.CToT( cgiGet( edtWWPWebNotificationRead_Internalname));
               n46WWPWebNotificationRead = false;
               AssignAttri("", false, "A46WWPWebNotificationRead", context.localUtil.TToC( A46WWPWebNotificationRead, 10, 12, 1, 3, "/", ":", " "));
            }
            n46WWPWebNotificationRead = ((DateTime.MinValue==A46WWPWebNotificationRead) ? true : false);
            A56WWPWebNotificationDetail = cgiGet( edtWWPWebNotificationDetail_Internalname);
            n56WWPWebNotificationDetail = false;
            AssignAttri("", false, "A56WWPWebNotificationDetail", A56WWPWebNotificationDetail);
            n56WWPWebNotificationDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A56WWPWebNotificationDetail)) ? true : false);
            A57WWPWebNotificationReceived = StringUtil.StrToBool( cgiGet( chkWWPWebNotificationReceived_Internalname));
            n57WWPWebNotificationReceived = false;
            AssignAttri("", false, "A57WWPWebNotificationReceived", A57WWPWebNotificationReceived);
            n57WWPWebNotificationReceived = ((false==A57WWPWebNotificationReceived) ? true : false);
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
               A47WWPWebNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPWebNotificationId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
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
               InitAll066( ) ;
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
         DisableAttributes066( ) ;
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

      protected void ResetCaption060( )
      {
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z42WWPWebNotificationTitle = T00063_A42WWPWebNotificationTitle[0];
               Z43WWPWebNotificationText = T00063_A43WWPWebNotificationText[0];
               Z44WWPWebNotificationIcon = T00063_A44WWPWebNotificationIcon[0];
               Z54WWPWebNotificationStatus = T00063_A54WWPWebNotificationStatus[0];
               Z45WWPWebNotificationCreated = T00063_A45WWPWebNotificationCreated[0];
               Z58WWPWebNotificationScheduled = T00063_A58WWPWebNotificationScheduled[0];
               Z55WWPWebNotificationProcessed = T00063_A55WWPWebNotificationProcessed[0];
               Z46WWPWebNotificationRead = T00063_A46WWPWebNotificationRead[0];
               Z57WWPWebNotificationReceived = T00063_A57WWPWebNotificationReceived[0];
               Z22WWPNotificationId = T00063_A22WWPNotificationId[0];
            }
            else
            {
               Z42WWPWebNotificationTitle = A42WWPWebNotificationTitle;
               Z43WWPWebNotificationText = A43WWPWebNotificationText;
               Z44WWPWebNotificationIcon = A44WWPWebNotificationIcon;
               Z54WWPWebNotificationStatus = A54WWPWebNotificationStatus;
               Z45WWPWebNotificationCreated = A45WWPWebNotificationCreated;
               Z58WWPWebNotificationScheduled = A58WWPWebNotificationScheduled;
               Z55WWPWebNotificationProcessed = A55WWPWebNotificationProcessed;
               Z46WWPWebNotificationRead = A46WWPWebNotificationRead;
               Z57WWPWebNotificationReceived = A57WWPWebNotificationReceived;
               Z22WWPNotificationId = A22WWPNotificationId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z47WWPWebNotificationId = A47WWPWebNotificationId;
            Z42WWPWebNotificationTitle = A42WWPWebNotificationTitle;
            Z43WWPWebNotificationText = A43WWPWebNotificationText;
            Z44WWPWebNotificationIcon = A44WWPWebNotificationIcon;
            Z53WWPWebNotificationClientId = A53WWPWebNotificationClientId;
            Z54WWPWebNotificationStatus = A54WWPWebNotificationStatus;
            Z45WWPWebNotificationCreated = A45WWPWebNotificationCreated;
            Z58WWPWebNotificationScheduled = A58WWPWebNotificationScheduled;
            Z55WWPWebNotificationProcessed = A55WWPWebNotificationProcessed;
            Z46WWPWebNotificationRead = A46WWPWebNotificationRead;
            Z56WWPWebNotificationDetail = A56WWPWebNotificationDetail;
            Z57WWPWebNotificationReceived = A57WWPWebNotificationReceived;
            Z22WWPNotificationId = A22WWPNotificationId;
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z24WWPNotificationCreated = A24WWPNotificationCreated;
            Z60WWPNotificationMetadata = A60WWPNotificationMetadata;
            Z59WWPNotificationDefinitionName = A59WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A54WWPWebNotificationStatus) && ( Gx_BScreen == 0 ) )
         {
            A54WWPWebNotificationStatus = 1;
            AssignAttri("", false, "A54WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A54WWPWebNotificationStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A45WWPWebNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A45WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A45WWPWebNotificationCreated", context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A58WWPWebNotificationScheduled) && ( Gx_BScreen == 0 ) )
         {
            A58WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A58WWPWebNotificationScheduled", context.localUtil.TToC( A58WWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
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

      protected void Load066( )
      {
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A47WWPWebNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound6 = 1;
            A23WWPNotificationDefinitionId = T00066_A23WWPNotificationDefinitionId[0];
            A42WWPWebNotificationTitle = T00066_A42WWPWebNotificationTitle[0];
            AssignAttri("", false, "A42WWPWebNotificationTitle", A42WWPWebNotificationTitle);
            A24WWPNotificationCreated = T00066_A24WWPNotificationCreated[0];
            AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            A60WWPNotificationMetadata = T00066_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = T00066_n60WWPNotificationMetadata[0];
            AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
            A59WWPNotificationDefinitionName = T00066_A59WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
            A43WWPWebNotificationText = T00066_A43WWPWebNotificationText[0];
            AssignAttri("", false, "A43WWPWebNotificationText", A43WWPWebNotificationText);
            A44WWPWebNotificationIcon = T00066_A44WWPWebNotificationIcon[0];
            AssignAttri("", false, "A44WWPWebNotificationIcon", A44WWPWebNotificationIcon);
            A53WWPWebNotificationClientId = T00066_A53WWPWebNotificationClientId[0];
            AssignAttri("", false, "A53WWPWebNotificationClientId", A53WWPWebNotificationClientId);
            A54WWPWebNotificationStatus = T00066_A54WWPWebNotificationStatus[0];
            AssignAttri("", false, "A54WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A54WWPWebNotificationStatus), 4, 0));
            A45WWPWebNotificationCreated = T00066_A45WWPWebNotificationCreated[0];
            AssignAttri("", false, "A45WWPWebNotificationCreated", context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            A58WWPWebNotificationScheduled = T00066_A58WWPWebNotificationScheduled[0];
            AssignAttri("", false, "A58WWPWebNotificationScheduled", context.localUtil.TToC( A58WWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
            A55WWPWebNotificationProcessed = T00066_A55WWPWebNotificationProcessed[0];
            AssignAttri("", false, "A55WWPWebNotificationProcessed", context.localUtil.TToC( A55WWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "));
            A46WWPWebNotificationRead = T00066_A46WWPWebNotificationRead[0];
            n46WWPWebNotificationRead = T00066_n46WWPWebNotificationRead[0];
            AssignAttri("", false, "A46WWPWebNotificationRead", context.localUtil.TToC( A46WWPWebNotificationRead, 10, 12, 1, 3, "/", ":", " "));
            A56WWPWebNotificationDetail = T00066_A56WWPWebNotificationDetail[0];
            n56WWPWebNotificationDetail = T00066_n56WWPWebNotificationDetail[0];
            AssignAttri("", false, "A56WWPWebNotificationDetail", A56WWPWebNotificationDetail);
            A57WWPWebNotificationReceived = T00066_A57WWPWebNotificationReceived[0];
            n57WWPWebNotificationReceived = T00066_n57WWPWebNotificationReceived[0];
            AssignAttri("", false, "A57WWPWebNotificationReceived", A57WWPWebNotificationReceived);
            A22WWPNotificationId = T00066_A22WWPNotificationId[0];
            n22WWPNotificationId = T00066_n22WWPNotificationId[0];
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            ZM066( -5) ;
         }
         pr_default.close(4);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
      }

      protected void CheckExtendedTable066( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00064 */
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
         A23WWPNotificationDefinitionId = T00064_A23WWPNotificationDefinitionId[0];
         A24WWPNotificationCreated = T00064_A24WWPNotificationCreated[0];
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         A60WWPNotificationMetadata = T00064_A60WWPNotificationMetadata[0];
         n60WWPNotificationMetadata = T00064_n60WWPNotificationMetadata[0];
         AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
         pr_default.close(2);
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A23WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A59WWPNotificationDefinitionName = T00065_A59WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
         pr_default.close(3);
         if ( ! ( ( A54WWPWebNotificationStatus == 1 ) || ( A54WWPWebNotificationStatus == 2 ) || ( A54WWPWebNotificationStatus == 3 ) ) )
         {
            GX_msglist.addItem("Field Web Notification Status is out of range", "OutOfRange", 1, "WWPWEBNOTIFICATIONSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPWebNotificationStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( long A22WWPNotificationId )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A22WWPNotificationId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A23WWPNotificationDefinitionId = T00067_A23WWPNotificationDefinitionId[0];
         A24WWPNotificationCreated = T00067_A24WWPNotificationCreated[0];
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         A60WWPNotificationMetadata = T00067_A60WWPNotificationMetadata[0];
         n60WWPNotificationMetadata = T00067_n60WWPNotificationMetadata[0];
         AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( A60WWPNotificationMetadata)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_7( long A23WWPNotificationDefinitionId )
      {
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A23WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A59WWPNotificationDefinitionName = T00068_A59WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A59WWPNotificationDefinitionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey066( )
      {
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A47WWPWebNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A47WWPWebNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 5) ;
            RcdFound6 = 1;
            A47WWPWebNotificationId = T00063_A47WWPWebNotificationId[0];
            AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
            A42WWPWebNotificationTitle = T00063_A42WWPWebNotificationTitle[0];
            AssignAttri("", false, "A42WWPWebNotificationTitle", A42WWPWebNotificationTitle);
            A43WWPWebNotificationText = T00063_A43WWPWebNotificationText[0];
            AssignAttri("", false, "A43WWPWebNotificationText", A43WWPWebNotificationText);
            A44WWPWebNotificationIcon = T00063_A44WWPWebNotificationIcon[0];
            AssignAttri("", false, "A44WWPWebNotificationIcon", A44WWPWebNotificationIcon);
            A53WWPWebNotificationClientId = T00063_A53WWPWebNotificationClientId[0];
            AssignAttri("", false, "A53WWPWebNotificationClientId", A53WWPWebNotificationClientId);
            A54WWPWebNotificationStatus = T00063_A54WWPWebNotificationStatus[0];
            AssignAttri("", false, "A54WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A54WWPWebNotificationStatus), 4, 0));
            A45WWPWebNotificationCreated = T00063_A45WWPWebNotificationCreated[0];
            AssignAttri("", false, "A45WWPWebNotificationCreated", context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            A58WWPWebNotificationScheduled = T00063_A58WWPWebNotificationScheduled[0];
            AssignAttri("", false, "A58WWPWebNotificationScheduled", context.localUtil.TToC( A58WWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
            A55WWPWebNotificationProcessed = T00063_A55WWPWebNotificationProcessed[0];
            AssignAttri("", false, "A55WWPWebNotificationProcessed", context.localUtil.TToC( A55WWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "));
            A46WWPWebNotificationRead = T00063_A46WWPWebNotificationRead[0];
            n46WWPWebNotificationRead = T00063_n46WWPWebNotificationRead[0];
            AssignAttri("", false, "A46WWPWebNotificationRead", context.localUtil.TToC( A46WWPWebNotificationRead, 10, 12, 1, 3, "/", ":", " "));
            A56WWPWebNotificationDetail = T00063_A56WWPWebNotificationDetail[0];
            n56WWPWebNotificationDetail = T00063_n56WWPWebNotificationDetail[0];
            AssignAttri("", false, "A56WWPWebNotificationDetail", A56WWPWebNotificationDetail);
            A57WWPWebNotificationReceived = T00063_A57WWPWebNotificationReceived[0];
            n57WWPWebNotificationReceived = T00063_n57WWPWebNotificationReceived[0];
            AssignAttri("", false, "A57WWPWebNotificationReceived", A57WWPWebNotificationReceived);
            A22WWPNotificationId = T00063_A22WWPNotificationId[0];
            n22WWPNotificationId = T00063_n22WWPNotificationId[0];
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            Z47WWPWebNotificationId = A47WWPWebNotificationId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
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
         RcdFound6 = 0;
         /* Using cursor T000610 */
         pr_default.execute(8, new Object[] {A47WWPWebNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000610_A47WWPWebNotificationId[0] < A47WWPWebNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000610_A47WWPWebNotificationId[0] > A47WWPWebNotificationId ) ) )
            {
               A47WWPWebNotificationId = T000610_A47WWPWebNotificationId[0];
               AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000611 */
         pr_default.execute(9, new Object[] {A47WWPWebNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000611_A47WWPWebNotificationId[0] > A47WWPWebNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000611_A47WWPWebNotificationId[0] < A47WWPWebNotificationId ) ) )
            {
               A47WWPWebNotificationId = T000611_A47WWPWebNotificationId[0];
               AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert066( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A47WWPWebNotificationId != Z47WWPWebNotificationId )
               {
                  A47WWPWebNotificationId = Z47WWPWebNotificationId;
                  AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPWEBNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update066( ) ;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A47WWPWebNotificationId != Z47WWPWebNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert066( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPWEBNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPWebNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPWebNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert066( ) ;
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
         if ( A47WWPWebNotificationId != Z47WWPWebNotificationId )
         {
            A47WWPWebNotificationId = Z47WWPWebNotificationId;
            AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPWEBNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPWEBNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd066( ) ;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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
         ScanStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound6 != 0 )
            {
               ScanNext066( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd066( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A47WWPWebNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z42WWPWebNotificationTitle, T00062_A42WWPWebNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z43WWPWebNotificationText, T00062_A43WWPWebNotificationText[0]) != 0 ) || ( StringUtil.StrCmp(Z44WWPWebNotificationIcon, T00062_A44WWPWebNotificationIcon[0]) != 0 ) || ( Z54WWPWebNotificationStatus != T00062_A54WWPWebNotificationStatus[0] ) || ( Z45WWPWebNotificationCreated != T00062_A45WWPWebNotificationCreated[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z58WWPWebNotificationScheduled != T00062_A58WWPWebNotificationScheduled[0] ) || ( Z55WWPWebNotificationProcessed != T00062_A55WWPWebNotificationProcessed[0] ) || ( Z46WWPWebNotificationRead != T00062_A46WWPWebNotificationRead[0] ) || ( Z57WWPWebNotificationReceived != T00062_A57WWPWebNotificationReceived[0] ) || ( Z22WWPNotificationId != T00062_A22WWPNotificationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z42WWPWebNotificationTitle, T00062_A42WWPWebNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z42WWPWebNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T00062_A42WWPWebNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z43WWPWebNotificationText, T00062_A43WWPWebNotificationText[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationText");
                  GXUtil.WriteLogRaw("Old: ",Z43WWPWebNotificationText);
                  GXUtil.WriteLogRaw("Current: ",T00062_A43WWPWebNotificationText[0]);
               }
               if ( StringUtil.StrCmp(Z44WWPWebNotificationIcon, T00062_A44WWPWebNotificationIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationIcon");
                  GXUtil.WriteLogRaw("Old: ",Z44WWPWebNotificationIcon);
                  GXUtil.WriteLogRaw("Current: ",T00062_A44WWPWebNotificationIcon[0]);
               }
               if ( Z54WWPWebNotificationStatus != T00062_A54WWPWebNotificationStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationStatus");
                  GXUtil.WriteLogRaw("Old: ",Z54WWPWebNotificationStatus);
                  GXUtil.WriteLogRaw("Current: ",T00062_A54WWPWebNotificationStatus[0]);
               }
               if ( Z45WWPWebNotificationCreated != T00062_A45WWPWebNotificationCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationCreated");
                  GXUtil.WriteLogRaw("Old: ",Z45WWPWebNotificationCreated);
                  GXUtil.WriteLogRaw("Current: ",T00062_A45WWPWebNotificationCreated[0]);
               }
               if ( Z58WWPWebNotificationScheduled != T00062_A58WWPWebNotificationScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z58WWPWebNotificationScheduled);
                  GXUtil.WriteLogRaw("Current: ",T00062_A58WWPWebNotificationScheduled[0]);
               }
               if ( Z55WWPWebNotificationProcessed != T00062_A55WWPWebNotificationProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z55WWPWebNotificationProcessed);
                  GXUtil.WriteLogRaw("Current: ",T00062_A55WWPWebNotificationProcessed[0]);
               }
               if ( Z46WWPWebNotificationRead != T00062_A46WWPWebNotificationRead[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationRead");
                  GXUtil.WriteLogRaw("Old: ",Z46WWPWebNotificationRead);
                  GXUtil.WriteLogRaw("Current: ",T00062_A46WWPWebNotificationRead[0]);
               }
               if ( Z57WWPWebNotificationReceived != T00062_A57WWPWebNotificationReceived[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationReceived");
                  GXUtil.WriteLogRaw("Old: ",Z57WWPWebNotificationReceived);
                  GXUtil.WriteLogRaw("Current: ",T00062_A57WWPWebNotificationReceived[0]);
               }
               if ( Z22WWPNotificationId != T00062_A22WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z22WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A22WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         if ( ! IsAuthorized("webnotification_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000612 */
                     pr_default.execute(10, new Object[] {A42WWPWebNotificationTitle, A43WWPWebNotificationText, A44WWPWebNotificationIcon, A53WWPWebNotificationClientId, A54WWPWebNotificationStatus, A45WWPWebNotificationCreated, A58WWPWebNotificationScheduled, A55WWPWebNotificationProcessed, n46WWPWebNotificationRead, A46WWPWebNotificationRead, n56WWPWebNotificationDetail, A56WWPWebNotificationDetail, n57WWPWebNotificationReceived, A57WWPWebNotificationReceived, n22WWPNotificationId, A22WWPNotificationId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000613 */
                     pr_default.execute(11);
                     A47WWPWebNotificationId = T000613_A47WWPWebNotificationId[0];
                     AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption060( ) ;
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         if ( ! IsAuthorized("webnotification_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000614 */
                     pr_default.execute(12, new Object[] {A42WWPWebNotificationTitle, A43WWPWebNotificationText, A44WWPWebNotificationIcon, A53WWPWebNotificationClientId, A54WWPWebNotificationStatus, A45WWPWebNotificationCreated, A58WWPWebNotificationScheduled, A55WWPWebNotificationProcessed, n46WWPWebNotificationRead, A46WWPWebNotificationRead, n56WWPWebNotificationDetail, A56WWPWebNotificationDetail, n57WWPWebNotificationReceived, A57WWPWebNotificationReceived, n22WWPNotificationId, A22WWPNotificationId, A47WWPWebNotificationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption060( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("webnotification_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000615 */
                  pr_default.execute(13, new Object[] {A47WWPWebNotificationId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound6 == 0 )
                        {
                           InitAll066( ) ;
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
                        ResetCaption060( ) ;
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel066( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000616 */
            pr_default.execute(14, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            A23WWPNotificationDefinitionId = T000616_A23WWPNotificationDefinitionId[0];
            A24WWPNotificationCreated = T000616_A24WWPNotificationCreated[0];
            AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            A60WWPNotificationMetadata = T000616_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = T000616_n60WWPNotificationMetadata[0];
            AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
            pr_default.close(14);
            /* Using cursor T000617 */
            pr_default.execute(15, new Object[] {A23WWPNotificationDefinitionId});
            A59WWPNotificationDefinitionName = T000617_A59WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
            pr_default.close(15);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_webnotification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webnotification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart066( )
      {
         /* Using cursor T000618 */
         pr_default.execute(16);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound6 = 1;
            A47WWPWebNotificationId = T000618_A47WWPWebNotificationId[0];
            AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound6 = 1;
            A47WWPWebNotificationId = T000618_A47WWPWebNotificationId[0];
            AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
         }
      }

      protected void ScanEnd066( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
         edtWWPWebNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationId_Enabled), 5, 0), true);
         edtWWPWebNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         edtWWPWebNotificationText_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationText_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationText_Enabled), 5, 0), true);
         edtWWPWebNotificationIcon_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationIcon_Enabled), 5, 0), true);
         edtWWPWebNotificationClientId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationClientId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationClientId_Enabled), 5, 0), true);
         cmbWWPWebNotificationStatus.Enabled = 0;
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPWebNotificationStatus.Enabled), 5, 0), true);
         edtWWPWebNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationCreated_Enabled), 5, 0), true);
         edtWWPWebNotificationScheduled_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationScheduled_Enabled), 5, 0), true);
         edtWWPWebNotificationProcessed_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationProcessed_Enabled), 5, 0), true);
         edtWWPWebNotificationRead_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationRead_Enabled), 5, 0), true);
         edtWWPWebNotificationDetail_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationDetail_Enabled), 5, 0), true);
         chkWWPWebNotificationReceived.Enabled = 0;
         AssignProp("", false, chkWWPWebNotificationReceived_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPWebNotificationReceived.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.web.wwp_webnotification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z47WWPWebNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z47WWPWebNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42WWPWebNotificationTitle", Z42WWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z43WWPWebNotificationText", Z43WWPWebNotificationText);
         GxWebStd.gx_hidden_field( context, "Z44WWPWebNotificationIcon", Z44WWPWebNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z54WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z54WWPWebNotificationStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z45WWPWebNotificationCreated", context.localUtil.TToC( Z45WWPWebNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z58WWPWebNotificationScheduled", context.localUtil.TToC( Z58WWPWebNotificationScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z55WWPWebNotificationProcessed", context.localUtil.TToC( Z55WWPWebNotificationProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z46WWPWebNotificationRead", context.localUtil.TToC( Z46WWPWebNotificationRead, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z57WWPWebNotificationReceived", Z57WWPWebNotificationReceived);
         GxWebStd.gx_hidden_field( context, "Z22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")));
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
         return formatLink("wwpbaseobjects.notifications.web.wwp_webnotification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Web.WWP_WebNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_Web Notification" ;
      }

      protected void InitializeNonKey066( )
      {
         A23WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
         A42WWPWebNotificationTitle = "";
         AssignAttri("", false, "A42WWPWebNotificationTitle", A42WWPWebNotificationTitle);
         A22WWPNotificationId = 0;
         n22WWPNotificationId = false;
         AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
         n22WWPNotificationId = ((0==A22WWPNotificationId) ? true : false);
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         A60WWPNotificationMetadata = "";
         n60WWPNotificationMetadata = false;
         AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
         A59WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
         A43WWPWebNotificationText = "";
         AssignAttri("", false, "A43WWPWebNotificationText", A43WWPWebNotificationText);
         A44WWPWebNotificationIcon = "";
         AssignAttri("", false, "A44WWPWebNotificationIcon", A44WWPWebNotificationIcon);
         A53WWPWebNotificationClientId = "";
         AssignAttri("", false, "A53WWPWebNotificationClientId", A53WWPWebNotificationClientId);
         A55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A55WWPWebNotificationProcessed", context.localUtil.TToC( A55WWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "));
         A46WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         n46WWPWebNotificationRead = false;
         AssignAttri("", false, "A46WWPWebNotificationRead", context.localUtil.TToC( A46WWPWebNotificationRead, 10, 12, 1, 3, "/", ":", " "));
         n46WWPWebNotificationRead = ((DateTime.MinValue==A46WWPWebNotificationRead) ? true : false);
         A56WWPWebNotificationDetail = "";
         n56WWPWebNotificationDetail = false;
         AssignAttri("", false, "A56WWPWebNotificationDetail", A56WWPWebNotificationDetail);
         n56WWPWebNotificationDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A56WWPWebNotificationDetail)) ? true : false);
         A57WWPWebNotificationReceived = false;
         n57WWPWebNotificationReceived = false;
         AssignAttri("", false, "A57WWPWebNotificationReceived", A57WWPWebNotificationReceived);
         n57WWPWebNotificationReceived = ((false==A57WWPWebNotificationReceived) ? true : false);
         A54WWPWebNotificationStatus = 1;
         AssignAttri("", false, "A54WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A54WWPWebNotificationStatus), 4, 0));
         A45WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A45WWPWebNotificationCreated", context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         A58WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A58WWPWebNotificationScheduled", context.localUtil.TToC( A58WWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
         Z42WWPWebNotificationTitle = "";
         Z43WWPWebNotificationText = "";
         Z44WWPWebNotificationIcon = "";
         Z54WWPWebNotificationStatus = 0;
         Z45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z46WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z57WWPWebNotificationReceived = false;
         Z22WWPNotificationId = 0;
      }

      protected void InitAll066( )
      {
         A47WWPWebNotificationId = 0;
         AssignAttri("", false, "A47WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A47WWPWebNotificationId), 10, 0));
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A54WWPWebNotificationStatus = i54WWPWebNotificationStatus;
         AssignAttri("", false, "A54WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A54WWPWebNotificationStatus), 4, 0));
         A45WWPWebNotificationCreated = i45WWPWebNotificationCreated;
         AssignAttri("", false, "A45WWPWebNotificationCreated", context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         A58WWPWebNotificationScheduled = i58WWPWebNotificationScheduled;
         AssignAttri("", false, "A58WWPWebNotificationScheduled", context.localUtil.TToC( A58WWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267482573", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/web/wwp_webnotification.js", "?20256267482573", false, true);
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
         edtWWPWebNotificationId_Internalname = "WWPWEBNOTIFICATIONID";
         edtWWPWebNotificationTitle_Internalname = "WWPWEBNOTIFICATIONTITLE";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         edtWWPWebNotificationText_Internalname = "WWPWEBNOTIFICATIONTEXT";
         edtWWPWebNotificationIcon_Internalname = "WWPWEBNOTIFICATIONICON";
         edtWWPWebNotificationClientId_Internalname = "WWPWEBNOTIFICATIONCLIENTID";
         cmbWWPWebNotificationStatus_Internalname = "WWPWEBNOTIFICATIONSTATUS";
         edtWWPWebNotificationCreated_Internalname = "WWPWEBNOTIFICATIONCREATED";
         edtWWPWebNotificationScheduled_Internalname = "WWPWEBNOTIFICATIONSCHEDULED";
         edtWWPWebNotificationProcessed_Internalname = "WWPWEBNOTIFICATIONPROCESSED";
         edtWWPWebNotificationRead_Internalname = "WWPWEBNOTIFICATIONREAD";
         edtWWPWebNotificationDetail_Internalname = "WWPWEBNOTIFICATIONDETAIL";
         chkWWPWebNotificationReceived_Internalname = "WWPWEBNOTIFICATIONRECEIVED";
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
         Form.Caption = "WWP_Web Notification";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPWebNotificationReceived.Enabled = 1;
         edtWWPWebNotificationDetail_Enabled = 1;
         edtWWPWebNotificationRead_Jsonclick = "";
         edtWWPWebNotificationRead_Enabled = 1;
         edtWWPWebNotificationProcessed_Jsonclick = "";
         edtWWPWebNotificationProcessed_Enabled = 1;
         edtWWPWebNotificationScheduled_Jsonclick = "";
         edtWWPWebNotificationScheduled_Enabled = 1;
         edtWWPWebNotificationCreated_Jsonclick = "";
         edtWWPWebNotificationCreated_Enabled = 1;
         cmbWWPWebNotificationStatus_Jsonclick = "";
         cmbWWPWebNotificationStatus.Enabled = 1;
         edtWWPWebNotificationClientId_Enabled = 1;
         edtWWPWebNotificationIcon_Enabled = 1;
         edtWWPWebNotificationText_Jsonclick = "";
         edtWWPWebNotificationText_Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 0;
         edtWWPNotificationMetadata_Enabled = 0;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPWebNotificationTitle_Jsonclick = "";
         edtWWPWebNotificationTitle_Enabled = 1;
         edtWWPWebNotificationId_Jsonclick = "";
         edtWWPWebNotificationId_Enabled = 1;
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
         cmbWWPWebNotificationStatus.Name = "WWPWEBNOTIFICATIONSTATUS";
         cmbWWPWebNotificationStatus.WebTags = "";
         cmbWWPWebNotificationStatus.addItem("1", "Pending", 0);
         cmbWWPWebNotificationStatus.addItem("2", "Sent", 0);
         cmbWWPWebNotificationStatus.addItem("3", "Error", 0);
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A54WWPWebNotificationStatus) )
            {
               A54WWPWebNotificationStatus = 1;
               AssignAttri("", false, "A54WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A54WWPWebNotificationStatus), 4, 0));
            }
         }
         chkWWPWebNotificationReceived.Name = "WWPWEBNOTIFICATIONRECEIVED";
         chkWWPWebNotificationReceived.WebTags = "";
         chkWWPWebNotificationReceived.Caption = "Notification Received";
         AssignProp("", false, chkWWPWebNotificationReceived_Internalname, "TitleCaption", chkWWPWebNotificationReceived.Caption, true);
         chkWWPWebNotificationReceived.CheckedValue = "false";
         A57WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A57WWPWebNotificationReceived));
         n57WWPWebNotificationReceived = false;
         AssignAttri("", false, "A57WWPWebNotificationReceived", A57WWPWebNotificationReceived);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
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

      public void Valid_Wwpwebnotificationid( )
      {
         A54WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A54WWPWebNotificationStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A54WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A54WWPWebNotificationStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0));
         }
         A57WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A57WWPWebNotificationReceived));
         n57WWPWebNotificationReceived = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A42WWPWebNotificationTitle", A42WWPWebNotificationTitle);
         AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A43WWPWebNotificationText", A43WWPWebNotificationText);
         AssignAttri("", false, "A44WWPWebNotificationIcon", A44WWPWebNotificationIcon);
         AssignAttri("", false, "A53WWPWebNotificationClientId", A53WWPWebNotificationClientId);
         AssignAttri("", false, "A54WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A54WWPWebNotificationStatus), 4, 0, ".", "")));
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A54WWPWebNotificationStatus), 4, 0));
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", cmbWWPWebNotificationStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A45WWPWebNotificationCreated", context.localUtil.TToC( A45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A58WWPWebNotificationScheduled", context.localUtil.TToC( A58WWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A55WWPWebNotificationProcessed", context.localUtil.TToC( A55WWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A46WWPWebNotificationRead", context.localUtil.TToC( A46WWPWebNotificationRead, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A56WWPWebNotificationDetail", A56WWPWebNotificationDetail);
         AssignAttri("", false, "A57WWPWebNotificationReceived", A57WWPWebNotificationReceived);
         AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z47WWPWebNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z47WWPWebNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42WWPWebNotificationTitle", Z42WWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z43WWPWebNotificationText", Z43WWPWebNotificationText);
         GxWebStd.gx_hidden_field( context, "Z44WWPWebNotificationIcon", Z44WWPWebNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z53WWPWebNotificationClientId", Z53WWPWebNotificationClientId);
         GxWebStd.gx_hidden_field( context, "Z54WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z54WWPWebNotificationStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z45WWPWebNotificationCreated", context.localUtil.TToC( Z45WWPWebNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z58WWPWebNotificationScheduled", context.localUtil.TToC( Z58WWPWebNotificationScheduled, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z55WWPWebNotificationProcessed", context.localUtil.TToC( Z55WWPWebNotificationProcessed, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z46WWPWebNotificationRead", context.localUtil.TToC( Z46WWPWebNotificationRead, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z56WWPWebNotificationDetail", Z56WWPWebNotificationDetail);
         GxWebStd.gx_hidden_field( context, "Z57WWPWebNotificationReceived", StringUtil.BoolToStr( Z57WWPWebNotificationReceived));
         GxWebStd.gx_hidden_field( context, "Z23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24WWPNotificationCreated", context.localUtil.TToC( Z24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z60WWPNotificationMetadata", Z60WWPNotificationMetadata);
         GxWebStd.gx_hidden_field( context, "Z59WWPNotificationDefinitionName", Z59WWPNotificationDefinitionName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n22WWPNotificationId = false;
         n60WWPNotificationMetadata = false;
         /* Using cursor T000616 */
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
         A23WWPNotificationDefinitionId = T000616_A23WWPNotificationDefinitionId[0];
         A24WWPNotificationCreated = T000616_A24WWPNotificationCreated[0];
         A60WWPNotificationMetadata = T000616_A60WWPNotificationMetadata[0];
         n60WWPNotificationMetadata = T000616_n60WWPNotificationMetadata[0];
         pr_default.close(14);
         /* Using cursor T000617 */
         pr_default.execute(15, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A23WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A59WWPNotificationDefinitionName = T000617_A59WWPNotificationDefinitionName[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A57WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A57WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A57WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A57WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]}""");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONID","""{"handler":"Valid_Wwpwebnotificationid","iparms":[{"av":"A47WWPWebNotificationId","fld":"WWPWEBNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"cmbWWPWebNotificationStatus"},{"av":"A54WWPWebNotificationStatus","fld":"WWPWEBNOTIFICATIONSTATUS","pic":"ZZZ9"},{"av":"A45WWPWebNotificationCreated","fld":"WWPWEBNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A58WWPWebNotificationScheduled","fld":"WWPWEBNOTIFICATIONSCHEDULED","pic":"99/99/9999 99:99:99.999"},{"av":"A57WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]""");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONID",""","oparms":[{"av":"A42WWPWebNotificationTitle","fld":"WWPWEBNOTIFICATIONTITLE"},{"av":"A22WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"A43WWPWebNotificationText","fld":"WWPWEBNOTIFICATIONTEXT"},{"av":"A44WWPWebNotificationIcon","fld":"WWPWEBNOTIFICATIONICON"},{"av":"A53WWPWebNotificationClientId","fld":"WWPWEBNOTIFICATIONCLIENTID"},{"av":"cmbWWPWebNotificationStatus"},{"av":"A54WWPWebNotificationStatus","fld":"WWPWEBNOTIFICATIONSTATUS","pic":"ZZZ9"},{"av":"A45WWPWebNotificationCreated","fld":"WWPWEBNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A58WWPWebNotificationScheduled","fld":"WWPWEBNOTIFICATIONSCHEDULED","pic":"99/99/9999 99:99:99.999"},{"av":"A55WWPWebNotificationProcessed","fld":"WWPWEBNOTIFICATIONPROCESSED","pic":"99/99/9999 99:99:99.999"},{"av":"A46WWPWebNotificationRead","fld":"WWPWEBNOTIFICATIONREAD","pic":"99/99/9999 99:99:99.999"},{"av":"A56WWPWebNotificationDetail","fld":"WWPWEBNOTIFICATIONDETAIL"},{"av":"A23WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A60WWPNotificationMetadata","fld":"WWPNOTIFICATIONMETADATA"},{"av":"A59WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z47WWPWebNotificationId"},{"av":"Z42WWPWebNotificationTitle"},{"av":"Z22WWPNotificationId"},{"av":"Z43WWPWebNotificationText"},{"av":"Z44WWPWebNotificationIcon"},{"av":"Z53WWPWebNotificationClientId"},{"av":"Z54WWPWebNotificationStatus"},{"av":"Z45WWPWebNotificationCreated"},{"av":"Z58WWPWebNotificationScheduled"},{"av":"Z55WWPWebNotificationProcessed"},{"av":"Z46WWPWebNotificationRead"},{"av":"Z56WWPWebNotificationDetail"},{"av":"Z57WWPWebNotificationReceived"},{"av":"Z23WWPNotificationDefinitionId"},{"av":"Z24WWPNotificationCreated"},{"av":"Z60WWPNotificationMetadata"},{"av":"Z59WWPNotificationDefinitionName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A57WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONID","""{"handler":"Valid_Wwpnotificationid","iparms":[{"av":"A22WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"A23WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A60WWPNotificationMetadata","fld":"WWPNOTIFICATIONMETADATA"},{"av":"A59WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"A57WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONID",""","oparms":[{"av":"A23WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A60WWPNotificationMetadata","fld":"WWPNOTIFICATIONMETADATA"},{"av":"A59WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"A57WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]}""");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSTATUS","""{"handler":"Valid_Wwpwebnotificationstatus","iparms":[{"av":"A57WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]""");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSTATUS",""","oparms":[{"av":"A57WWPWebNotificationReceived","fld":"WWPWEBNOTIFICATIONRECEIVED"}]}""");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z42WWPWebNotificationTitle = "";
         Z43WWPWebNotificationText = "";
         Z44WWPWebNotificationIcon = "";
         Z45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z46WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
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
         A42WWPWebNotificationTitle = "";
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A60WWPNotificationMetadata = "";
         A59WWPNotificationDefinitionName = "";
         A43WWPWebNotificationText = "";
         A44WWPWebNotificationIcon = "";
         A53WWPWebNotificationClientId = "";
         A45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         A58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A46WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         A56WWPWebNotificationDetail = "";
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
         Z53WWPWebNotificationClientId = "";
         Z56WWPWebNotificationDetail = "";
         Z24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z60WWPNotificationMetadata = "";
         Z59WWPNotificationDefinitionName = "";
         T00066_A23WWPNotificationDefinitionId = new long[1] ;
         T00066_A47WWPWebNotificationId = new long[1] ;
         T00066_A42WWPWebNotificationTitle = new string[] {""} ;
         T00066_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00066_A60WWPNotificationMetadata = new string[] {""} ;
         T00066_n60WWPNotificationMetadata = new bool[] {false} ;
         T00066_A59WWPNotificationDefinitionName = new string[] {""} ;
         T00066_A43WWPWebNotificationText = new string[] {""} ;
         T00066_A44WWPWebNotificationIcon = new string[] {""} ;
         T00066_A53WWPWebNotificationClientId = new string[] {""} ;
         T00066_A54WWPWebNotificationStatus = new short[1] ;
         T00066_A45WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00066_A58WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T00066_A55WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T00066_A46WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T00066_n46WWPWebNotificationRead = new bool[] {false} ;
         T00066_A56WWPWebNotificationDetail = new string[] {""} ;
         T00066_n56WWPWebNotificationDetail = new bool[] {false} ;
         T00066_A57WWPWebNotificationReceived = new bool[] {false} ;
         T00066_n57WWPWebNotificationReceived = new bool[] {false} ;
         T00066_A22WWPNotificationId = new long[1] ;
         T00066_n22WWPNotificationId = new bool[] {false} ;
         T00064_A23WWPNotificationDefinitionId = new long[1] ;
         T00064_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00064_A60WWPNotificationMetadata = new string[] {""} ;
         T00064_n60WWPNotificationMetadata = new bool[] {false} ;
         T00065_A59WWPNotificationDefinitionName = new string[] {""} ;
         T00067_A23WWPNotificationDefinitionId = new long[1] ;
         T00067_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00067_A60WWPNotificationMetadata = new string[] {""} ;
         T00067_n60WWPNotificationMetadata = new bool[] {false} ;
         T00068_A59WWPNotificationDefinitionName = new string[] {""} ;
         T00069_A47WWPWebNotificationId = new long[1] ;
         T00063_A47WWPWebNotificationId = new long[1] ;
         T00063_A42WWPWebNotificationTitle = new string[] {""} ;
         T00063_A43WWPWebNotificationText = new string[] {""} ;
         T00063_A44WWPWebNotificationIcon = new string[] {""} ;
         T00063_A53WWPWebNotificationClientId = new string[] {""} ;
         T00063_A54WWPWebNotificationStatus = new short[1] ;
         T00063_A45WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00063_A58WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T00063_A55WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T00063_A46WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T00063_n46WWPWebNotificationRead = new bool[] {false} ;
         T00063_A56WWPWebNotificationDetail = new string[] {""} ;
         T00063_n56WWPWebNotificationDetail = new bool[] {false} ;
         T00063_A57WWPWebNotificationReceived = new bool[] {false} ;
         T00063_n57WWPWebNotificationReceived = new bool[] {false} ;
         T00063_A22WWPNotificationId = new long[1] ;
         T00063_n22WWPNotificationId = new bool[] {false} ;
         sMode6 = "";
         T000610_A47WWPWebNotificationId = new long[1] ;
         T000611_A47WWPWebNotificationId = new long[1] ;
         T00062_A47WWPWebNotificationId = new long[1] ;
         T00062_A42WWPWebNotificationTitle = new string[] {""} ;
         T00062_A43WWPWebNotificationText = new string[] {""} ;
         T00062_A44WWPWebNotificationIcon = new string[] {""} ;
         T00062_A53WWPWebNotificationClientId = new string[] {""} ;
         T00062_A54WWPWebNotificationStatus = new short[1] ;
         T00062_A45WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00062_A58WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T00062_A55WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T00062_A46WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T00062_n46WWPWebNotificationRead = new bool[] {false} ;
         T00062_A56WWPWebNotificationDetail = new string[] {""} ;
         T00062_n56WWPWebNotificationDetail = new bool[] {false} ;
         T00062_A57WWPWebNotificationReceived = new bool[] {false} ;
         T00062_n57WWPWebNotificationReceived = new bool[] {false} ;
         T00062_A22WWPNotificationId = new long[1] ;
         T00062_n22WWPNotificationId = new bool[] {false} ;
         T000613_A47WWPWebNotificationId = new long[1] ;
         T000616_A23WWPNotificationDefinitionId = new long[1] ;
         T000616_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000616_A60WWPNotificationMetadata = new string[] {""} ;
         T000616_n60WWPNotificationMetadata = new bool[] {false} ;
         T000617_A59WWPNotificationDefinitionName = new string[] {""} ;
         T000618_A47WWPWebNotificationId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         i58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         ZZ42WWPWebNotificationTitle = "";
         ZZ43WWPWebNotificationText = "";
         ZZ44WWPWebNotificationIcon = "";
         ZZ53WWPWebNotificationClientId = "";
         ZZ45WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ58WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         ZZ55WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         ZZ46WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         ZZ56WWPWebNotificationDetail = "";
         ZZ24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ60WWPNotificationMetadata = "";
         ZZ59WWPNotificationDefinitionName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__default(),
            new Object[][] {
                new Object[] {
               T00062_A47WWPWebNotificationId, T00062_A42WWPWebNotificationTitle, T00062_A43WWPWebNotificationText, T00062_A44WWPWebNotificationIcon, T00062_A53WWPWebNotificationClientId, T00062_A54WWPWebNotificationStatus, T00062_A45WWPWebNotificationCreated, T00062_A58WWPWebNotificationScheduled, T00062_A55WWPWebNotificationProcessed, T00062_A46WWPWebNotificationRead,
               T00062_n46WWPWebNotificationRead, T00062_A56WWPWebNotificationDetail, T00062_n56WWPWebNotificationDetail, T00062_A57WWPWebNotificationReceived, T00062_n57WWPWebNotificationReceived, T00062_A22WWPNotificationId, T00062_n22WWPNotificationId
               }
               , new Object[] {
               T00063_A47WWPWebNotificationId, T00063_A42WWPWebNotificationTitle, T00063_A43WWPWebNotificationText, T00063_A44WWPWebNotificationIcon, T00063_A53WWPWebNotificationClientId, T00063_A54WWPWebNotificationStatus, T00063_A45WWPWebNotificationCreated, T00063_A58WWPWebNotificationScheduled, T00063_A55WWPWebNotificationProcessed, T00063_A46WWPWebNotificationRead,
               T00063_n46WWPWebNotificationRead, T00063_A56WWPWebNotificationDetail, T00063_n56WWPWebNotificationDetail, T00063_A57WWPWebNotificationReceived, T00063_n57WWPWebNotificationReceived, T00063_A22WWPNotificationId, T00063_n22WWPNotificationId
               }
               , new Object[] {
               T00064_A23WWPNotificationDefinitionId, T00064_A24WWPNotificationCreated, T00064_A60WWPNotificationMetadata, T00064_n60WWPNotificationMetadata
               }
               , new Object[] {
               T00065_A59WWPNotificationDefinitionName
               }
               , new Object[] {
               T00066_A23WWPNotificationDefinitionId, T00066_A47WWPWebNotificationId, T00066_A42WWPWebNotificationTitle, T00066_A24WWPNotificationCreated, T00066_A60WWPNotificationMetadata, T00066_n60WWPNotificationMetadata, T00066_A59WWPNotificationDefinitionName, T00066_A43WWPWebNotificationText, T00066_A44WWPWebNotificationIcon, T00066_A53WWPWebNotificationClientId,
               T00066_A54WWPWebNotificationStatus, T00066_A45WWPWebNotificationCreated, T00066_A58WWPWebNotificationScheduled, T00066_A55WWPWebNotificationProcessed, T00066_A46WWPWebNotificationRead, T00066_n46WWPWebNotificationRead, T00066_A56WWPWebNotificationDetail, T00066_n56WWPWebNotificationDetail, T00066_A57WWPWebNotificationReceived, T00066_n57WWPWebNotificationReceived,
               T00066_A22WWPNotificationId, T00066_n22WWPNotificationId
               }
               , new Object[] {
               T00067_A23WWPNotificationDefinitionId, T00067_A24WWPNotificationCreated, T00067_A60WWPNotificationMetadata, T00067_n60WWPNotificationMetadata
               }
               , new Object[] {
               T00068_A59WWPNotificationDefinitionName
               }
               , new Object[] {
               T00069_A47WWPWebNotificationId
               }
               , new Object[] {
               T000610_A47WWPWebNotificationId
               }
               , new Object[] {
               T000611_A47WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               T000613_A47WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000616_A23WWPNotificationDefinitionId, T000616_A24WWPNotificationCreated, T000616_A60WWPNotificationMetadata, T000616_n60WWPNotificationMetadata
               }
               , new Object[] {
               T000617_A59WWPNotificationDefinitionName
               }
               , new Object[] {
               T000618_A47WWPWebNotificationId
               }
            }
         );
         Z58WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A58WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i58WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z45WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A45WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i45WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z54WWPWebNotificationStatus = 1;
         A54WWPWebNotificationStatus = 1;
         i54WWPWebNotificationStatus = 1;
      }

      private short Z54WWPWebNotificationStatus ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A54WWPWebNotificationStatus ;
      private short Gx_BScreen ;
      private short RcdFound6 ;
      private short gxajaxcallmode ;
      private short i54WWPWebNotificationStatus ;
      private short ZZ54WWPWebNotificationStatus ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPWebNotificationId_Enabled ;
      private int edtWWPWebNotificationTitle_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPWebNotificationText_Enabled ;
      private int edtWWPWebNotificationIcon_Enabled ;
      private int edtWWPWebNotificationClientId_Enabled ;
      private int edtWWPWebNotificationCreated_Enabled ;
      private int edtWWPWebNotificationScheduled_Enabled ;
      private int edtWWPWebNotificationProcessed_Enabled ;
      private int edtWWPWebNotificationRead_Enabled ;
      private int edtWWPWebNotificationDetail_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z47WWPWebNotificationId ;
      private long Z22WWPNotificationId ;
      private long A22WWPNotificationId ;
      private long A23WWPNotificationDefinitionId ;
      private long A47WWPWebNotificationId ;
      private long Z23WWPNotificationDefinitionId ;
      private long ZZ47WWPWebNotificationId ;
      private long ZZ22WWPNotificationId ;
      private long ZZ23WWPNotificationDefinitionId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPWebNotificationId_Internalname ;
      private string cmbWWPWebNotificationStatus_Internalname ;
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
      private string edtWWPWebNotificationId_Jsonclick ;
      private string edtWWPWebNotificationTitle_Internalname ;
      private string edtWWPWebNotificationTitle_Jsonclick ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string edtWWPNotificationMetadata_Internalname ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string edtWWPWebNotificationText_Internalname ;
      private string edtWWPWebNotificationText_Jsonclick ;
      private string edtWWPWebNotificationIcon_Internalname ;
      private string edtWWPWebNotificationClientId_Internalname ;
      private string cmbWWPWebNotificationStatus_Jsonclick ;
      private string edtWWPWebNotificationCreated_Internalname ;
      private string edtWWPWebNotificationCreated_Jsonclick ;
      private string edtWWPWebNotificationScheduled_Internalname ;
      private string edtWWPWebNotificationScheduled_Jsonclick ;
      private string edtWWPWebNotificationProcessed_Internalname ;
      private string edtWWPWebNotificationProcessed_Jsonclick ;
      private string edtWWPWebNotificationRead_Internalname ;
      private string edtWWPWebNotificationRead_Jsonclick ;
      private string edtWWPWebNotificationDetail_Internalname ;
      private string chkWWPWebNotificationReceived_Internalname ;
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
      private string sMode6 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z45WWPWebNotificationCreated ;
      private DateTime Z58WWPWebNotificationScheduled ;
      private DateTime Z55WWPWebNotificationProcessed ;
      private DateTime Z46WWPWebNotificationRead ;
      private DateTime A24WWPNotificationCreated ;
      private DateTime A45WWPWebNotificationCreated ;
      private DateTime A58WWPWebNotificationScheduled ;
      private DateTime A55WWPWebNotificationProcessed ;
      private DateTime A46WWPWebNotificationRead ;
      private DateTime Z24WWPNotificationCreated ;
      private DateTime i45WWPWebNotificationCreated ;
      private DateTime i58WWPWebNotificationScheduled ;
      private DateTime ZZ45WWPWebNotificationCreated ;
      private DateTime ZZ58WWPWebNotificationScheduled ;
      private DateTime ZZ55WWPWebNotificationProcessed ;
      private DateTime ZZ46WWPWebNotificationRead ;
      private DateTime ZZ24WWPNotificationCreated ;
      private bool Z57WWPWebNotificationReceived ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n22WWPNotificationId ;
      private bool wbErr ;
      private bool A57WWPWebNotificationReceived ;
      private bool n57WWPWebNotificationReceived ;
      private bool n46WWPWebNotificationRead ;
      private bool n60WWPNotificationMetadata ;
      private bool n56WWPWebNotificationDetail ;
      private bool Gx_longc ;
      private bool ZZ57WWPWebNotificationReceived ;
      private string A60WWPNotificationMetadata ;
      private string A53WWPWebNotificationClientId ;
      private string A56WWPWebNotificationDetail ;
      private string Z53WWPWebNotificationClientId ;
      private string Z56WWPWebNotificationDetail ;
      private string Z60WWPNotificationMetadata ;
      private string ZZ53WWPWebNotificationClientId ;
      private string ZZ56WWPWebNotificationDetail ;
      private string ZZ60WWPNotificationMetadata ;
      private string Z42WWPWebNotificationTitle ;
      private string Z43WWPWebNotificationText ;
      private string Z44WWPWebNotificationIcon ;
      private string A42WWPWebNotificationTitle ;
      private string A59WWPNotificationDefinitionName ;
      private string A43WWPWebNotificationText ;
      private string A44WWPWebNotificationIcon ;
      private string Z59WWPNotificationDefinitionName ;
      private string ZZ42WWPWebNotificationTitle ;
      private string ZZ43WWPWebNotificationText ;
      private string ZZ44WWPWebNotificationIcon ;
      private string ZZ59WWPNotificationDefinitionName ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPWebNotificationStatus ;
      private GXCheckbox chkWWPWebNotificationReceived ;
      private IDataStoreProvider pr_default ;
      private long[] T00066_A23WWPNotificationDefinitionId ;
      private long[] T00066_A47WWPWebNotificationId ;
      private string[] T00066_A42WWPWebNotificationTitle ;
      private DateTime[] T00066_A24WWPNotificationCreated ;
      private string[] T00066_A60WWPNotificationMetadata ;
      private bool[] T00066_n60WWPNotificationMetadata ;
      private string[] T00066_A59WWPNotificationDefinitionName ;
      private string[] T00066_A43WWPWebNotificationText ;
      private string[] T00066_A44WWPWebNotificationIcon ;
      private string[] T00066_A53WWPWebNotificationClientId ;
      private short[] T00066_A54WWPWebNotificationStatus ;
      private DateTime[] T00066_A45WWPWebNotificationCreated ;
      private DateTime[] T00066_A58WWPWebNotificationScheduled ;
      private DateTime[] T00066_A55WWPWebNotificationProcessed ;
      private DateTime[] T00066_A46WWPWebNotificationRead ;
      private bool[] T00066_n46WWPWebNotificationRead ;
      private string[] T00066_A56WWPWebNotificationDetail ;
      private bool[] T00066_n56WWPWebNotificationDetail ;
      private bool[] T00066_A57WWPWebNotificationReceived ;
      private bool[] T00066_n57WWPWebNotificationReceived ;
      private long[] T00066_A22WWPNotificationId ;
      private bool[] T00066_n22WWPNotificationId ;
      private long[] T00064_A23WWPNotificationDefinitionId ;
      private DateTime[] T00064_A24WWPNotificationCreated ;
      private string[] T00064_A60WWPNotificationMetadata ;
      private bool[] T00064_n60WWPNotificationMetadata ;
      private string[] T00065_A59WWPNotificationDefinitionName ;
      private long[] T00067_A23WWPNotificationDefinitionId ;
      private DateTime[] T00067_A24WWPNotificationCreated ;
      private string[] T00067_A60WWPNotificationMetadata ;
      private bool[] T00067_n60WWPNotificationMetadata ;
      private string[] T00068_A59WWPNotificationDefinitionName ;
      private long[] T00069_A47WWPWebNotificationId ;
      private long[] T00063_A47WWPWebNotificationId ;
      private string[] T00063_A42WWPWebNotificationTitle ;
      private string[] T00063_A43WWPWebNotificationText ;
      private string[] T00063_A44WWPWebNotificationIcon ;
      private string[] T00063_A53WWPWebNotificationClientId ;
      private short[] T00063_A54WWPWebNotificationStatus ;
      private DateTime[] T00063_A45WWPWebNotificationCreated ;
      private DateTime[] T00063_A58WWPWebNotificationScheduled ;
      private DateTime[] T00063_A55WWPWebNotificationProcessed ;
      private DateTime[] T00063_A46WWPWebNotificationRead ;
      private bool[] T00063_n46WWPWebNotificationRead ;
      private string[] T00063_A56WWPWebNotificationDetail ;
      private bool[] T00063_n56WWPWebNotificationDetail ;
      private bool[] T00063_A57WWPWebNotificationReceived ;
      private bool[] T00063_n57WWPWebNotificationReceived ;
      private long[] T00063_A22WWPNotificationId ;
      private bool[] T00063_n22WWPNotificationId ;
      private long[] T000610_A47WWPWebNotificationId ;
      private long[] T000611_A47WWPWebNotificationId ;
      private long[] T00062_A47WWPWebNotificationId ;
      private string[] T00062_A42WWPWebNotificationTitle ;
      private string[] T00062_A43WWPWebNotificationText ;
      private string[] T00062_A44WWPWebNotificationIcon ;
      private string[] T00062_A53WWPWebNotificationClientId ;
      private short[] T00062_A54WWPWebNotificationStatus ;
      private DateTime[] T00062_A45WWPWebNotificationCreated ;
      private DateTime[] T00062_A58WWPWebNotificationScheduled ;
      private DateTime[] T00062_A55WWPWebNotificationProcessed ;
      private DateTime[] T00062_A46WWPWebNotificationRead ;
      private bool[] T00062_n46WWPWebNotificationRead ;
      private string[] T00062_A56WWPWebNotificationDetail ;
      private bool[] T00062_n56WWPWebNotificationDetail ;
      private bool[] T00062_A57WWPWebNotificationReceived ;
      private bool[] T00062_n57WWPWebNotificationReceived ;
      private long[] T00062_A22WWPNotificationId ;
      private bool[] T00062_n22WWPNotificationId ;
      private long[] T000613_A47WWPWebNotificationId ;
      private long[] T000616_A23WWPNotificationDefinitionId ;
      private DateTime[] T000616_A24WWPNotificationCreated ;
      private string[] T000616_A60WWPNotificationMetadata ;
      private bool[] T000616_n60WWPNotificationMetadata ;
      private string[] T000617_A59WWPNotificationDefinitionName ;
      private long[] T000618_A47WWPWebNotificationId ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webnotification__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00062;
        prmT00062 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT00063;
        prmT00063 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT00064;
        prmT00064 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT00065;
        prmT00065 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00066;
        prmT00066 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT00067;
        prmT00067 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT00068;
        prmT00068 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00069;
        prmT00069 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000610;
        prmT000610 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000611;
        prmT000611 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000612;
        prmT000612 = new Object[] {
        new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
        new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
        new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
        new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000613;
        prmT000613 = new Object[] {
        };
        Object[] prmT000614;
        prmT000614 = new Object[] {
        new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
        new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
        new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
        new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000615;
        prmT000615 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000616;
        prmT000616 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000617;
        prmT000617 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000618;
        prmT000618 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00062", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId  FOR UPDATE OF WWP_WebNotification NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00063", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00064", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00065", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00066", "SELECT T2.WWPNotificationDefinitionId, TM1.WWPWebNotificationId, TM1.WWPWebNotificationTitle, T2.WWPNotificationCreated, T2.WWPNotificationMetadata, T3.WWPNotificationDefinitionName, TM1.WWPWebNotificationText, TM1.WWPWebNotificationIcon, TM1.WWPWebNotificationClientId, TM1.WWPWebNotificationStatus, TM1.WWPWebNotificationCreated, TM1.WWPWebNotificationScheduled, TM1.WWPWebNotificationProcessed, TM1.WWPWebNotificationRead, TM1.WWPWebNotificationDetail, TM1.WWPWebNotificationReceived, TM1.WWPNotificationId FROM ((WWP_WebNotification TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) LEFT JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE TM1.WWPWebNotificationId = :WWPWebNotificationId ORDER BY TM1.WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00067", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00068", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00069", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000610", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE ( WWPWebNotificationId > :WWPWebNotificationId) ORDER BY WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000611", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE ( WWPWebNotificationId < :WWPWebNotificationId) ORDER BY WWPWebNotificationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000612", "SAVEPOINT gxupdate;INSERT INTO WWP_WebNotification(WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId) VALUES(:WWPWebNotificationTitle, :WWPWebNotificationText, :WWPWebNotificationIcon, :WWPWebNotificationClientId, :WWPWebNotificationStatus, :WWPWebNotificationCreated, :WWPWebNotificationScheduled, :WWPWebNotificationProcessed, :WWPWebNotificationRead, :WWPWebNotificationDetail, :WWPWebNotificationReceived, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000612)
           ,new CursorDef("T000613", "SELECT currval('WWPWebNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000614", "SAVEPOINT gxupdate;UPDATE WWP_WebNotification SET WWPWebNotificationTitle=:WWPWebNotificationTitle, WWPWebNotificationText=:WWPWebNotificationText, WWPWebNotificationIcon=:WWPWebNotificationIcon, WWPWebNotificationClientId=:WWPWebNotificationClientId, WWPWebNotificationStatus=:WWPWebNotificationStatus, WWPWebNotificationCreated=:WWPWebNotificationCreated, WWPWebNotificationScheduled=:WWPWebNotificationScheduled, WWPWebNotificationProcessed=:WWPWebNotificationProcessed, WWPWebNotificationRead=:WWPWebNotificationRead, WWPWebNotificationDetail=:WWPWebNotificationDetail, WWPWebNotificationReceived=:WWPWebNotificationReceived, WWPNotificationId=:WWPNotificationId  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000614)
           ,new CursorDef("T000615", "SAVEPOINT gxupdate;DELETE FROM WWP_WebNotification  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000615)
           ,new CursorDef("T000616", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000617", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000618", "SELECT WWPWebNotificationId FROM WWP_WebNotification ORDER BY WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000618,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((bool[]) buf[18])[0] = rslt.getBool(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((long[]) buf[20])[0] = rslt.getLong(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
