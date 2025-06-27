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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notification : GXDataArea
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
            A23WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A23WWPNotificationDefinitionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
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
            gxLoad_6( A7WWPUserExtendedId) ;
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
         Form.Meta.addItem("description", "Notification", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_notification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notification( IGxContext context )
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
         chkWWPNotificationIsRead = new GXCheckbox();
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
            return "wwp_notification_Execute" ;
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
         A82WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A82WWPNotificationIsRead));
         AssignAttri("", false, "A82WWPNotificationIsRead", A82WWPNotificationIsRead);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Notification", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22WWPNotificationId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A22WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionId_Internalname, "Notification Definition Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A23WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A23WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A59WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A59WWPNotificationDefinitionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "), context.localUtil.Format( A24WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,12,'eng',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationIcon_Internalname, "Icon", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationIcon_Internalname, A76WWPNotificationIcon, StringUtil.RTrim( context.localUtil.Format( A76WWPNotificationIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationIcon_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationTitle_Internalname, "Title", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationTitle_Internalname, A77WWPNotificationTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtWWPNotificationTitle_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationShortDescriptio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationShortDescriptio_Internalname, "Short Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationShortDescriptio_Internalname, A78WWPNotificationShortDescriptio, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPNotificationShortDescriptio_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationLink_Internalname, "Link", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationLink_Internalname, A79WWPNotificationLink, StringUtil.RTrim( context.localUtil.Format( A79WWPNotificationLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", A79WWPNotificationLink, "_blank", "", "", edtWWPNotificationLink_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPNotificationIsRead_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationIsRead_Internalname, "Is Read", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationIsRead_Internalname, StringUtil.BoolToStr( A82WWPNotificationIsRead), "", "Is Read", 1, chkWWPNotificationIsRead.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A7WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A7WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedFullName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, "User Full Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A8WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A8WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationMetadata_Internalname, "Metadata", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationMetadata_Internalname, A60WWPNotificationMetadata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", 0, 1, edtWWPNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_Notification.htm");
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
            Z22WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z22WWPNotificationId"), ".", ","), 18, MidpointRounding.ToEven));
            Z24WWPNotificationCreated = context.localUtil.CToT( cgiGet( "Z24WWPNotificationCreated"), 0);
            Z76WWPNotificationIcon = cgiGet( "Z76WWPNotificationIcon");
            Z77WWPNotificationTitle = cgiGet( "Z77WWPNotificationTitle");
            Z78WWPNotificationShortDescriptio = cgiGet( "Z78WWPNotificationShortDescriptio");
            Z79WWPNotificationLink = cgiGet( "Z79WWPNotificationLink");
            Z82WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( "Z82WWPNotificationIsRead"));
            Z23WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z23WWPNotificationDefinitionId"), ".", ","), 18, MidpointRounding.ToEven));
            Z7WWPUserExtendedId = cgiGet( "Z7WWPUserExtendedId");
            n7WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A23WWPNotificationDefinitionId = 0;
               AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            }
            else
            {
               A23WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            }
            A59WWPNotificationDefinitionName = cgiGet( edtWWPNotificationDefinitionName_Internalname);
            AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPNotificationCreated_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Notification Created Date"}), 1, "WWPNOTIFICATIONCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            else
            {
               A24WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
               AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            }
            A76WWPNotificationIcon = cgiGet( edtWWPNotificationIcon_Internalname);
            AssignAttri("", false, "A76WWPNotificationIcon", A76WWPNotificationIcon);
            A77WWPNotificationTitle = cgiGet( edtWWPNotificationTitle_Internalname);
            AssignAttri("", false, "A77WWPNotificationTitle", A77WWPNotificationTitle);
            A78WWPNotificationShortDescriptio = cgiGet( edtWWPNotificationShortDescriptio_Internalname);
            AssignAttri("", false, "A78WWPNotificationShortDescriptio", A78WWPNotificationShortDescriptio);
            A79WWPNotificationLink = cgiGet( edtWWPNotificationLink_Internalname);
            AssignAttri("", false, "A79WWPNotificationLink", A79WWPNotificationLink);
            A82WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( chkWWPNotificationIsRead_Internalname));
            AssignAttri("", false, "A82WWPNotificationIsRead", A82WWPNotificationIsRead);
            A7WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n7WWPUserExtendedId = false;
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            n7WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ? true : false);
            A8WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
            A60WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
            n60WWPNotificationMetadata = false;
            AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
            n60WWPNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A60WWPNotificationMetadata)) ? true : false);
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
               A22WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationId"), "."), 18, MidpointRounding.ToEven));
               n22WWPNotificationId = false;
               AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
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
               InitAll099( ) ;
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
         DisableAttributes099( ) ;
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

      protected void ResetCaption090( )
      {
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z24WWPNotificationCreated = T00093_A24WWPNotificationCreated[0];
               Z76WWPNotificationIcon = T00093_A76WWPNotificationIcon[0];
               Z77WWPNotificationTitle = T00093_A77WWPNotificationTitle[0];
               Z78WWPNotificationShortDescriptio = T00093_A78WWPNotificationShortDescriptio[0];
               Z79WWPNotificationLink = T00093_A79WWPNotificationLink[0];
               Z82WWPNotificationIsRead = T00093_A82WWPNotificationIsRead[0];
               Z23WWPNotificationDefinitionId = T00093_A23WWPNotificationDefinitionId[0];
               Z7WWPUserExtendedId = T00093_A7WWPUserExtendedId[0];
            }
            else
            {
               Z24WWPNotificationCreated = A24WWPNotificationCreated;
               Z76WWPNotificationIcon = A76WWPNotificationIcon;
               Z77WWPNotificationTitle = A77WWPNotificationTitle;
               Z78WWPNotificationShortDescriptio = A78WWPNotificationShortDescriptio;
               Z79WWPNotificationLink = A79WWPNotificationLink;
               Z82WWPNotificationIsRead = A82WWPNotificationIsRead;
               Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
               Z7WWPUserExtendedId = A7WWPUserExtendedId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z22WWPNotificationId = A22WWPNotificationId;
            Z24WWPNotificationCreated = A24WWPNotificationCreated;
            Z76WWPNotificationIcon = A76WWPNotificationIcon;
            Z77WWPNotificationTitle = A77WWPNotificationTitle;
            Z78WWPNotificationShortDescriptio = A78WWPNotificationShortDescriptio;
            Z79WWPNotificationLink = A79WWPNotificationLink;
            Z82WWPNotificationIsRead = A82WWPNotificationIsRead;
            Z60WWPNotificationMetadata = A60WWPNotificationMetadata;
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
            Z59WWPNotificationDefinitionName = A59WWPNotificationDefinitionName;
            Z8WWPUserExtendedFullName = A8WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A24WWPNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A24WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
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

      protected void Load099( )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
            A59WWPNotificationDefinitionName = T00096_A59WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
            A24WWPNotificationCreated = T00096_A24WWPNotificationCreated[0];
            AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            A76WWPNotificationIcon = T00096_A76WWPNotificationIcon[0];
            AssignAttri("", false, "A76WWPNotificationIcon", A76WWPNotificationIcon);
            A77WWPNotificationTitle = T00096_A77WWPNotificationTitle[0];
            AssignAttri("", false, "A77WWPNotificationTitle", A77WWPNotificationTitle);
            A78WWPNotificationShortDescriptio = T00096_A78WWPNotificationShortDescriptio[0];
            AssignAttri("", false, "A78WWPNotificationShortDescriptio", A78WWPNotificationShortDescriptio);
            A79WWPNotificationLink = T00096_A79WWPNotificationLink[0];
            AssignAttri("", false, "A79WWPNotificationLink", A79WWPNotificationLink);
            A82WWPNotificationIsRead = T00096_A82WWPNotificationIsRead[0];
            AssignAttri("", false, "A82WWPNotificationIsRead", A82WWPNotificationIsRead);
            A8WWPUserExtendedFullName = T00096_A8WWPUserExtendedFullName[0];
            AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
            A60WWPNotificationMetadata = T00096_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = T00096_n60WWPNotificationMetadata[0];
            AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
            A23WWPNotificationDefinitionId = T00096_A23WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            A7WWPUserExtendedId = T00096_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = T00096_n7WWPUserExtendedId[0];
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            ZM099( -4) ;
         }
         pr_default.close(4);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
      }

      protected void CheckExtendedTable099( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A59WWPNotificationDefinitionName = T00094_A59WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A79WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("Field Notification Link does not match the specified pattern", "OutOfRange", 1, "WWPNOTIFICATIONLINK");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A8WWPUserExtendedFullName = T00095_A8WWPUserExtendedFullName[0];
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( long A23WWPNotificationDefinitionId )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A59WWPNotificationDefinitionName = T00097_A59WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A59WWPNotificationDefinitionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_6( string A7WWPUserExtendedId )
      {
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A8WWPUserExtendedFullName = T00098_A8WWPUserExtendedFullName[0];
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A8WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey099( )
      {
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 4) ;
            RcdFound9 = 1;
            A22WWPNotificationId = T00093_A22WWPNotificationId[0];
            n22WWPNotificationId = T00093_n22WWPNotificationId[0];
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            A24WWPNotificationCreated = T00093_A24WWPNotificationCreated[0];
            AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
            A76WWPNotificationIcon = T00093_A76WWPNotificationIcon[0];
            AssignAttri("", false, "A76WWPNotificationIcon", A76WWPNotificationIcon);
            A77WWPNotificationTitle = T00093_A77WWPNotificationTitle[0];
            AssignAttri("", false, "A77WWPNotificationTitle", A77WWPNotificationTitle);
            A78WWPNotificationShortDescriptio = T00093_A78WWPNotificationShortDescriptio[0];
            AssignAttri("", false, "A78WWPNotificationShortDescriptio", A78WWPNotificationShortDescriptio);
            A79WWPNotificationLink = T00093_A79WWPNotificationLink[0];
            AssignAttri("", false, "A79WWPNotificationLink", A79WWPNotificationLink);
            A82WWPNotificationIsRead = T00093_A82WWPNotificationIsRead[0];
            AssignAttri("", false, "A82WWPNotificationIsRead", A82WWPNotificationIsRead);
            A60WWPNotificationMetadata = T00093_A60WWPNotificationMetadata[0];
            n60WWPNotificationMetadata = T00093_n60WWPNotificationMetadata[0];
            AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
            A23WWPNotificationDefinitionId = T00093_A23WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            A7WWPUserExtendedId = T00093_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = T00093_n7WWPUserExtendedId[0];
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            Z22WWPNotificationId = A22WWPNotificationId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         RcdFound9 = 0;
         /* Using cursor T000910 */
         pr_default.execute(8, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000910_A22WWPNotificationId[0] < A22WWPNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000910_A22WWPNotificationId[0] > A22WWPNotificationId ) ) )
            {
               A22WWPNotificationId = T000910_A22WWPNotificationId[0];
               n22WWPNotificationId = T000910_n22WWPNotificationId[0];
               AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000911 */
         pr_default.execute(9, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000911_A22WWPNotificationId[0] > A22WWPNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000911_A22WWPNotificationId[0] < A22WWPNotificationId ) ) )
            {
               A22WWPNotificationId = T000911_A22WWPNotificationId[0];
               n22WWPNotificationId = T000911_n22WWPNotificationId[0];
               AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert099( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A22WWPNotificationId != Z22WWPNotificationId )
               {
                  A22WWPNotificationId = Z22WWPNotificationId;
                  n22WWPNotificationId = false;
                  AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update099( ) ;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A22WWPNotificationId != Z22WWPNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert099( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert099( ) ;
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
         if ( A22WWPNotificationId != Z22WWPNotificationId )
         {
            A22WWPNotificationId = Z22WWPNotificationId;
            n22WWPNotificationId = false;
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPNotificationId_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound9 != 0 )
            {
               ScanNext099( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z24WWPNotificationCreated != T00092_A24WWPNotificationCreated[0] ) || ( StringUtil.StrCmp(Z76WWPNotificationIcon, T00092_A76WWPNotificationIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z77WWPNotificationTitle, T00092_A77WWPNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z78WWPNotificationShortDescriptio, T00092_A78WWPNotificationShortDescriptio[0]) != 0 ) || ( StringUtil.StrCmp(Z79WWPNotificationLink, T00092_A79WWPNotificationLink[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z82WWPNotificationIsRead != T00092_A82WWPNotificationIsRead[0] ) || ( Z23WWPNotificationDefinitionId != T00092_A23WWPNotificationDefinitionId[0] ) || ( StringUtil.StrCmp(Z7WWPUserExtendedId, T00092_A7WWPUserExtendedId[0]) != 0 ) )
            {
               if ( Z24WWPNotificationCreated != T00092_A24WWPNotificationCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationCreated");
                  GXUtil.WriteLogRaw("Old: ",Z24WWPNotificationCreated);
                  GXUtil.WriteLogRaw("Current: ",T00092_A24WWPNotificationCreated[0]);
               }
               if ( StringUtil.StrCmp(Z76WWPNotificationIcon, T00092_A76WWPNotificationIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationIcon");
                  GXUtil.WriteLogRaw("Old: ",Z76WWPNotificationIcon);
                  GXUtil.WriteLogRaw("Current: ",T00092_A76WWPNotificationIcon[0]);
               }
               if ( StringUtil.StrCmp(Z77WWPNotificationTitle, T00092_A77WWPNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z77WWPNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T00092_A77WWPNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z78WWPNotificationShortDescriptio, T00092_A78WWPNotificationShortDescriptio[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationShortDescriptio");
                  GXUtil.WriteLogRaw("Old: ",Z78WWPNotificationShortDescriptio);
                  GXUtil.WriteLogRaw("Current: ",T00092_A78WWPNotificationShortDescriptio[0]);
               }
               if ( StringUtil.StrCmp(Z79WWPNotificationLink, T00092_A79WWPNotificationLink[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationLink");
                  GXUtil.WriteLogRaw("Old: ",Z79WWPNotificationLink);
                  GXUtil.WriteLogRaw("Current: ",T00092_A79WWPNotificationLink[0]);
               }
               if ( Z82WWPNotificationIsRead != T00092_A82WWPNotificationIsRead[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationIsRead");
                  GXUtil.WriteLogRaw("Old: ",Z82WWPNotificationIsRead);
                  GXUtil.WriteLogRaw("Current: ",T00092_A82WWPNotificationIsRead[0]);
               }
               if ( Z23WWPNotificationDefinitionId != T00092_A23WWPNotificationDefinitionId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationDefinitionId");
                  GXUtil.WriteLogRaw("Old: ",Z23WWPNotificationDefinitionId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A23WWPNotificationDefinitionId[0]);
               }
               if ( StringUtil.StrCmp(Z7WWPUserExtendedId, T00092_A7WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z7WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A7WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         if ( ! IsAuthorized("wwp_notification_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000912 */
                     pr_default.execute(10, new Object[] {A24WWPNotificationCreated, A76WWPNotificationIcon, A77WWPNotificationTitle, A78WWPNotificationShortDescriptio, A79WWPNotificationLink, A82WWPNotificationIsRead, n60WWPNotificationMetadata, A60WWPNotificationMetadata, A23WWPNotificationDefinitionId, n7WWPUserExtendedId, A7WWPUserExtendedId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000913 */
                     pr_default.execute(11);
                     A22WWPNotificationId = T000913_A22WWPNotificationId[0];
                     n22WWPNotificationId = T000913_n22WWPNotificationId[0];
                     AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption090( ) ;
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         if ( ! IsAuthorized("wwp_notification_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000914 */
                     pr_default.execute(12, new Object[] {A24WWPNotificationCreated, A76WWPNotificationIcon, A77WWPNotificationTitle, A78WWPNotificationShortDescriptio, A79WWPNotificationLink, A82WWPNotificationIsRead, n60WWPNotificationMetadata, A60WWPNotificationMetadata, A23WWPNotificationDefinitionId, n7WWPUserExtendedId, A7WWPUserExtendedId, n22WWPNotificationId, A22WWPNotificationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption090( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwp_notification_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000915 */
                  pr_default.execute(13, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound9 == 0 )
                        {
                           InitAll099( ) ;
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
                        ResetCaption090( ) ;
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel099( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000916 */
            pr_default.execute(14, new Object[] {A23WWPNotificationDefinitionId});
            A59WWPNotificationDefinitionName = T000916_A59WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
            pr_default.close(14);
            /* Using cursor T000917 */
            pr_default.execute(15, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            A8WWPUserExtendedFullName = T000917_A8WWPUserExtendedFullName[0];
            AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000918 */
            pr_default.execute(16, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Mail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000919 */
            pr_default.execute(17, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_WebNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000920 */
            pr_default.execute(18, new Object[] {n22WWPNotificationId, A22WWPNotificationId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_SMS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_notification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart099( )
      {
         /* Using cursor T000921 */
         pr_default.execute(19);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound9 = 1;
            A22WWPNotificationId = T000921_A22WWPNotificationId[0];
            n22WWPNotificationId = T000921_n22WWPNotificationId[0];
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound9 = 1;
            A22WWPNotificationId = T000921_A22WWPNotificationId[0];
            n22WWPNotificationId = T000921_n22WWPNotificationId[0];
            AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
         }
      }

      protected void ScanEnd099( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) )
         {
            A7WWPUserExtendedId = "";
            n7WWPUserExtendedId = false;
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            n7WWPUserExtendedId = true;
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
         }
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationIcon_Enabled = 0;
         AssignProp("", false, edtWWPNotificationIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationIcon_Enabled), 5, 0), true);
         edtWWPNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationShortDescriptio_Enabled = 0;
         AssignProp("", false, edtWWPNotificationShortDescriptio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationShortDescriptio_Enabled), 5, 0), true);
         edtWWPNotificationLink_Enabled = 0;
         AssignProp("", false, edtWWPNotificationLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Enabled), 5, 0), true);
         chkWWPNotificationIsRead.Enabled = 0;
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationIsRead.Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_notification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24WWPNotificationCreated", context.localUtil.TToC( Z24WWPNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z76WWPNotificationIcon", Z76WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z77WWPNotificationTitle", Z77WWPNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z78WWPNotificationShortDescriptio", Z78WWPNotificationShortDescriptio);
         GxWebStd.gx_hidden_field( context, "Z79WWPNotificationLink", Z79WWPNotificationLink);
         GxWebStd.gx_boolean_hidden_field( context, "Z82WWPNotificationIsRead", Z82WWPNotificationIsRead);
         GxWebStd.gx_hidden_field( context, "Z23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23WWPNotificationDefinitionId), 10, 0, ".", "")));
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_notification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_Notification" ;
      }

      public override string GetPgmdesc( )
      {
         return "Notification" ;
      }

      protected void InitializeNonKey099( )
      {
         A23WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
         A59WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
         A76WWPNotificationIcon = "";
         AssignAttri("", false, "A76WWPNotificationIcon", A76WWPNotificationIcon);
         A77WWPNotificationTitle = "";
         AssignAttri("", false, "A77WWPNotificationTitle", A77WWPNotificationTitle);
         A78WWPNotificationShortDescriptio = "";
         AssignAttri("", false, "A78WWPNotificationShortDescriptio", A78WWPNotificationShortDescriptio);
         A79WWPNotificationLink = "";
         AssignAttri("", false, "A79WWPNotificationLink", A79WWPNotificationLink);
         A82WWPNotificationIsRead = false;
         AssignAttri("", false, "A82WWPNotificationIsRead", A82WWPNotificationIsRead);
         A7WWPUserExtendedId = "";
         n7WWPUserExtendedId = false;
         AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
         n7WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ? true : false);
         A8WWPUserExtendedFullName = "";
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
         A60WWPNotificationMetadata = "";
         n60WWPNotificationMetadata = false;
         AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
         n60WWPNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A60WWPNotificationMetadata)) ? true : false);
         A24WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         Z24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z76WWPNotificationIcon = "";
         Z77WWPNotificationTitle = "";
         Z78WWPNotificationShortDescriptio = "";
         Z79WWPNotificationLink = "";
         Z82WWPNotificationIsRead = false;
         Z23WWPNotificationDefinitionId = 0;
         Z7WWPUserExtendedId = "";
      }

      protected void InitAll099( )
      {
         A22WWPNotificationId = 0;
         n22WWPNotificationId = false;
         AssignAttri("", false, "A22WWPNotificationId", StringUtil.LTrimStr( (decimal)(A22WWPNotificationId), 10, 0));
         InitializeNonKey099( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A24WWPNotificationCreated = i24WWPNotificationCreated;
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267482812", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_notification.js", "?20256267482813", false, true);
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
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         edtWWPNotificationIcon_Internalname = "WWPNOTIFICATIONICON";
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE";
         edtWWPNotificationShortDescriptio_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTIO";
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK";
         chkWWPNotificationIsRead_Internalname = "WWPNOTIFICATIONISREAD";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
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
         Form.Caption = "Notification";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationMetadata_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         chkWWPNotificationIsRead.Enabled = 1;
         edtWWPNotificationLink_Jsonclick = "";
         edtWWPNotificationLink_Enabled = 1;
         edtWWPNotificationShortDescriptio_Enabled = 1;
         edtWWPNotificationTitle_Enabled = 1;
         edtWWPNotificationIcon_Jsonclick = "";
         edtWWPNotificationIcon_Enabled = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 0;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
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
         chkWWPNotificationIsRead.Name = "WWPNOTIFICATIONISREAD";
         chkWWPNotificationIsRead.WebTags = "";
         chkWWPNotificationIsRead.Caption = "Is Read";
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "TitleCaption", chkWWPNotificationIsRead.Caption, true);
         chkWWPNotificationIsRead.CheckedValue = "false";
         A82WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A82WWPNotificationIsRead));
         AssignAttri("", false, "A82WWPNotificationIsRead", A82WWPNotificationIsRead);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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

      public void Valid_Wwpnotificationid( )
      {
         n22WWPNotificationId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A82WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A82WWPNotificationIsRead));
         /*  Sending validation outputs */
         AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A24WWPNotificationCreated", context.localUtil.TToC( A24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A76WWPNotificationIcon", A76WWPNotificationIcon);
         AssignAttri("", false, "A77WWPNotificationTitle", A77WWPNotificationTitle);
         AssignAttri("", false, "A78WWPNotificationShortDescriptio", A78WWPNotificationShortDescriptio);
         AssignAttri("", false, "A79WWPNotificationLink", A79WWPNotificationLink);
         AssignAttri("", false, "A82WWPNotificationIsRead", A82WWPNotificationIsRead);
         AssignAttri("", false, "A7WWPUserExtendedId", StringUtil.RTrim( A7WWPUserExtendedId));
         AssignAttri("", false, "A60WWPNotificationMetadata", A60WWPNotificationMetadata);
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z22WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24WWPNotificationCreated", context.localUtil.TToC( Z24WWPNotificationCreated, 10, 12, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z76WWPNotificationIcon", Z76WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z77WWPNotificationTitle", Z77WWPNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z78WWPNotificationShortDescriptio", Z78WWPNotificationShortDescriptio);
         GxWebStd.gx_hidden_field( context, "Z79WWPNotificationLink", Z79WWPNotificationLink);
         GxWebStd.gx_hidden_field( context, "Z82WWPNotificationIsRead", StringUtil.BoolToStr( Z82WWPNotificationIsRead));
         GxWebStd.gx_hidden_field( context, "Z7WWPUserExtendedId", StringUtil.RTrim( Z7WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z60WWPNotificationMetadata", Z60WWPNotificationMetadata);
         GxWebStd.gx_hidden_field( context, "Z59WWPNotificationDefinitionName", Z59WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z8WWPUserExtendedFullName", Z8WWPUserExtendedFullName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationdefinitionid( )
      {
         /* Using cursor T000916 */
         pr_default.execute(14, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         }
         A59WWPNotificationDefinitionName = T000916_A59WWPNotificationDefinitionName[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
      }

      public void Valid_Wwpuserextendedid( )
      {
         n7WWPUserExtendedId = false;
         /* Using cursor T000917 */
         pr_default.execute(15, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         A8WWPUserExtendedFullName = T000917_A8WWPUserExtendedFullName[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONID","""{"handler":"Valid_Wwpnotificationid","iparms":[{"av":"A22WWPNotificationId","fld":"WWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONID",""","oparms":[{"av":"A23WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A24WWPNotificationCreated","fld":"WWPNOTIFICATIONCREATED","pic":"99/99/9999 99:99:99.999"},{"av":"A76WWPNotificationIcon","fld":"WWPNOTIFICATIONICON"},{"av":"A77WWPNotificationTitle","fld":"WWPNOTIFICATIONTITLE"},{"av":"A78WWPNotificationShortDescriptio","fld":"WWPNOTIFICATIONSHORTDESCRIPTIO"},{"av":"A79WWPNotificationLink","fld":"WWPNOTIFICATIONLINK"},{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A60WWPNotificationMetadata","fld":"WWPNOTIFICATIONMETADATA"},{"av":"A59WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"A8WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z22WWPNotificationId"},{"av":"Z23WWPNotificationDefinitionId"},{"av":"Z24WWPNotificationCreated"},{"av":"Z76WWPNotificationIcon"},{"av":"Z77WWPNotificationTitle"},{"av":"Z78WWPNotificationShortDescriptio"},{"av":"Z79WWPNotificationLink"},{"av":"Z82WWPNotificationIsRead"},{"av":"Z7WWPUserExtendedId"},{"av":"Z60WWPNotificationMetadata"},{"av":"Z59WWPNotificationDefinitionName"},{"av":"Z8WWPUserExtendedFullName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","""{"handler":"Valid_Wwpnotificationdefinitionid","iparms":[{"av":"A23WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A59WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",""","oparms":[{"av":"A59WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONLINK","""{"handler":"Valid_Wwpnotificationlink","iparms":[{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONLINK",""","oparms":[{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","""{"handler":"Valid_Wwpuserextendedid","iparms":[{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A8WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",""","oparms":[{"av":"A8WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A82WWPNotificationIsRead","fld":"WWPNOTIFICATIONISREAD"}]}""");
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
         Z24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z76WWPNotificationIcon = "";
         Z77WWPNotificationTitle = "";
         Z78WWPNotificationShortDescriptio = "";
         Z79WWPNotificationLink = "";
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
         A59WWPNotificationDefinitionName = "";
         A24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A76WWPNotificationIcon = "";
         A77WWPNotificationTitle = "";
         A78WWPNotificationShortDescriptio = "";
         A79WWPNotificationLink = "";
         A8WWPUserExtendedFullName = "";
         A60WWPNotificationMetadata = "";
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
         Z60WWPNotificationMetadata = "";
         Z59WWPNotificationDefinitionName = "";
         Z8WWPUserExtendedFullName = "";
         T00096_A22WWPNotificationId = new long[1] ;
         T00096_n22WWPNotificationId = new bool[] {false} ;
         T00096_A59WWPNotificationDefinitionName = new string[] {""} ;
         T00096_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00096_A76WWPNotificationIcon = new string[] {""} ;
         T00096_A77WWPNotificationTitle = new string[] {""} ;
         T00096_A78WWPNotificationShortDescriptio = new string[] {""} ;
         T00096_A79WWPNotificationLink = new string[] {""} ;
         T00096_A82WWPNotificationIsRead = new bool[] {false} ;
         T00096_A8WWPUserExtendedFullName = new string[] {""} ;
         T00096_A60WWPNotificationMetadata = new string[] {""} ;
         T00096_n60WWPNotificationMetadata = new bool[] {false} ;
         T00096_A23WWPNotificationDefinitionId = new long[1] ;
         T00096_A7WWPUserExtendedId = new string[] {""} ;
         T00096_n7WWPUserExtendedId = new bool[] {false} ;
         T00094_A59WWPNotificationDefinitionName = new string[] {""} ;
         T00095_A8WWPUserExtendedFullName = new string[] {""} ;
         T00097_A59WWPNotificationDefinitionName = new string[] {""} ;
         T00098_A8WWPUserExtendedFullName = new string[] {""} ;
         T00099_A22WWPNotificationId = new long[1] ;
         T00099_n22WWPNotificationId = new bool[] {false} ;
         T00093_A22WWPNotificationId = new long[1] ;
         T00093_n22WWPNotificationId = new bool[] {false} ;
         T00093_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00093_A76WWPNotificationIcon = new string[] {""} ;
         T00093_A77WWPNotificationTitle = new string[] {""} ;
         T00093_A78WWPNotificationShortDescriptio = new string[] {""} ;
         T00093_A79WWPNotificationLink = new string[] {""} ;
         T00093_A82WWPNotificationIsRead = new bool[] {false} ;
         T00093_A60WWPNotificationMetadata = new string[] {""} ;
         T00093_n60WWPNotificationMetadata = new bool[] {false} ;
         T00093_A23WWPNotificationDefinitionId = new long[1] ;
         T00093_A7WWPUserExtendedId = new string[] {""} ;
         T00093_n7WWPUserExtendedId = new bool[] {false} ;
         sMode9 = "";
         T000910_A22WWPNotificationId = new long[1] ;
         T000910_n22WWPNotificationId = new bool[] {false} ;
         T000911_A22WWPNotificationId = new long[1] ;
         T000911_n22WWPNotificationId = new bool[] {false} ;
         T00092_A22WWPNotificationId = new long[1] ;
         T00092_n22WWPNotificationId = new bool[] {false} ;
         T00092_A24WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00092_A76WWPNotificationIcon = new string[] {""} ;
         T00092_A77WWPNotificationTitle = new string[] {""} ;
         T00092_A78WWPNotificationShortDescriptio = new string[] {""} ;
         T00092_A79WWPNotificationLink = new string[] {""} ;
         T00092_A82WWPNotificationIsRead = new bool[] {false} ;
         T00092_A60WWPNotificationMetadata = new string[] {""} ;
         T00092_n60WWPNotificationMetadata = new bool[] {false} ;
         T00092_A23WWPNotificationDefinitionId = new long[1] ;
         T00092_A7WWPUserExtendedId = new string[] {""} ;
         T00092_n7WWPUserExtendedId = new bool[] {false} ;
         T000913_A22WWPNotificationId = new long[1] ;
         T000913_n22WWPNotificationId = new bool[] {false} ;
         T000916_A59WWPNotificationDefinitionName = new string[] {""} ;
         T000917_A8WWPUserExtendedFullName = new string[] {""} ;
         T000918_A80WWPMailId = new long[1] ;
         T000919_A47WWPWebNotificationId = new long[1] ;
         T000920_A33WWPSMSId = new long[1] ;
         T000921_A22WWPNotificationId = new long[1] ;
         T000921_n22WWPNotificationId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ24WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ76WWPNotificationIcon = "";
         ZZ77WWPNotificationTitle = "";
         ZZ78WWPNotificationShortDescriptio = "";
         ZZ79WWPNotificationLink = "";
         ZZ7WWPUserExtendedId = "";
         ZZ60WWPNotificationMetadata = "";
         ZZ59WWPNotificationDefinitionName = "";
         ZZ8WWPUserExtendedFullName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__default(),
            new Object[][] {
                new Object[] {
               T00092_A22WWPNotificationId, T00092_A24WWPNotificationCreated, T00092_A76WWPNotificationIcon, T00092_A77WWPNotificationTitle, T00092_A78WWPNotificationShortDescriptio, T00092_A79WWPNotificationLink, T00092_A82WWPNotificationIsRead, T00092_A60WWPNotificationMetadata, T00092_n60WWPNotificationMetadata, T00092_A23WWPNotificationDefinitionId,
               T00092_A7WWPUserExtendedId, T00092_n7WWPUserExtendedId
               }
               , new Object[] {
               T00093_A22WWPNotificationId, T00093_A24WWPNotificationCreated, T00093_A76WWPNotificationIcon, T00093_A77WWPNotificationTitle, T00093_A78WWPNotificationShortDescriptio, T00093_A79WWPNotificationLink, T00093_A82WWPNotificationIsRead, T00093_A60WWPNotificationMetadata, T00093_n60WWPNotificationMetadata, T00093_A23WWPNotificationDefinitionId,
               T00093_A7WWPUserExtendedId, T00093_n7WWPUserExtendedId
               }
               , new Object[] {
               T00094_A59WWPNotificationDefinitionName
               }
               , new Object[] {
               T00095_A8WWPUserExtendedFullName
               }
               , new Object[] {
               T00096_A22WWPNotificationId, T00096_A59WWPNotificationDefinitionName, T00096_A24WWPNotificationCreated, T00096_A76WWPNotificationIcon, T00096_A77WWPNotificationTitle, T00096_A78WWPNotificationShortDescriptio, T00096_A79WWPNotificationLink, T00096_A82WWPNotificationIsRead, T00096_A8WWPUserExtendedFullName, T00096_A60WWPNotificationMetadata,
               T00096_n60WWPNotificationMetadata, T00096_A23WWPNotificationDefinitionId, T00096_A7WWPUserExtendedId, T00096_n7WWPUserExtendedId
               }
               , new Object[] {
               T00097_A59WWPNotificationDefinitionName
               }
               , new Object[] {
               T00098_A8WWPUserExtendedFullName
               }
               , new Object[] {
               T00099_A22WWPNotificationId
               }
               , new Object[] {
               T000910_A22WWPNotificationId
               }
               , new Object[] {
               T000911_A22WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               T000913_A22WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000916_A59WWPNotificationDefinitionName
               }
               , new Object[] {
               T000917_A8WWPUserExtendedFullName
               }
               , new Object[] {
               T000918_A80WWPMailId
               }
               , new Object[] {
               T000919_A47WWPWebNotificationId
               }
               , new Object[] {
               T000920_A33WWPSMSId
               }
               , new Object[] {
               T000921_A22WWPNotificationId
               }
            }
         );
         Z24WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A24WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i24WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationIcon_Enabled ;
      private int edtWWPNotificationTitle_Enabled ;
      private int edtWWPNotificationShortDescriptio_Enabled ;
      private int edtWWPNotificationLink_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z22WWPNotificationId ;
      private long Z23WWPNotificationDefinitionId ;
      private long A23WWPNotificationDefinitionId ;
      private long A22WWPNotificationId ;
      private long ZZ22WWPNotificationId ;
      private long ZZ23WWPNotificationDefinitionId ;
      private string sPrefix ;
      private string Z7WWPUserExtendedId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A7WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPNotificationId_Internalname ;
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
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string edtWWPNotificationIcon_Internalname ;
      private string edtWWPNotificationIcon_Jsonclick ;
      private string edtWWPNotificationTitle_Internalname ;
      private string edtWWPNotificationShortDescriptio_Internalname ;
      private string edtWWPNotificationLink_Internalname ;
      private string edtWWPNotificationLink_Jsonclick ;
      private string chkWWPNotificationIsRead_Internalname ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPNotificationMetadata_Internalname ;
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
      private string sMode9 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ7WWPUserExtendedId ;
      private DateTime Z24WWPNotificationCreated ;
      private DateTime A24WWPNotificationCreated ;
      private DateTime i24WWPNotificationCreated ;
      private DateTime ZZ24WWPNotificationCreated ;
      private bool Z82WWPNotificationIsRead ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n7WWPUserExtendedId ;
      private bool wbErr ;
      private bool A82WWPNotificationIsRead ;
      private bool n22WWPNotificationId ;
      private bool n60WWPNotificationMetadata ;
      private bool Gx_longc ;
      private bool ZZ82WWPNotificationIsRead ;
      private string A60WWPNotificationMetadata ;
      private string Z60WWPNotificationMetadata ;
      private string ZZ60WWPNotificationMetadata ;
      private string Z76WWPNotificationIcon ;
      private string Z77WWPNotificationTitle ;
      private string Z78WWPNotificationShortDescriptio ;
      private string Z79WWPNotificationLink ;
      private string A59WWPNotificationDefinitionName ;
      private string A76WWPNotificationIcon ;
      private string A77WWPNotificationTitle ;
      private string A78WWPNotificationShortDescriptio ;
      private string A79WWPNotificationLink ;
      private string A8WWPUserExtendedFullName ;
      private string Z59WWPNotificationDefinitionName ;
      private string Z8WWPUserExtendedFullName ;
      private string ZZ76WWPNotificationIcon ;
      private string ZZ77WWPNotificationTitle ;
      private string ZZ78WWPNotificationShortDescriptio ;
      private string ZZ79WWPNotificationLink ;
      private string ZZ59WWPNotificationDefinitionName ;
      private string ZZ8WWPUserExtendedFullName ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPNotificationIsRead ;
      private IDataStoreProvider pr_default ;
      private long[] T00096_A22WWPNotificationId ;
      private bool[] T00096_n22WWPNotificationId ;
      private string[] T00096_A59WWPNotificationDefinitionName ;
      private DateTime[] T00096_A24WWPNotificationCreated ;
      private string[] T00096_A76WWPNotificationIcon ;
      private string[] T00096_A77WWPNotificationTitle ;
      private string[] T00096_A78WWPNotificationShortDescriptio ;
      private string[] T00096_A79WWPNotificationLink ;
      private bool[] T00096_A82WWPNotificationIsRead ;
      private string[] T00096_A8WWPUserExtendedFullName ;
      private string[] T00096_A60WWPNotificationMetadata ;
      private bool[] T00096_n60WWPNotificationMetadata ;
      private long[] T00096_A23WWPNotificationDefinitionId ;
      private string[] T00096_A7WWPUserExtendedId ;
      private bool[] T00096_n7WWPUserExtendedId ;
      private string[] T00094_A59WWPNotificationDefinitionName ;
      private string[] T00095_A8WWPUserExtendedFullName ;
      private string[] T00097_A59WWPNotificationDefinitionName ;
      private string[] T00098_A8WWPUserExtendedFullName ;
      private long[] T00099_A22WWPNotificationId ;
      private bool[] T00099_n22WWPNotificationId ;
      private long[] T00093_A22WWPNotificationId ;
      private bool[] T00093_n22WWPNotificationId ;
      private DateTime[] T00093_A24WWPNotificationCreated ;
      private string[] T00093_A76WWPNotificationIcon ;
      private string[] T00093_A77WWPNotificationTitle ;
      private string[] T00093_A78WWPNotificationShortDescriptio ;
      private string[] T00093_A79WWPNotificationLink ;
      private bool[] T00093_A82WWPNotificationIsRead ;
      private string[] T00093_A60WWPNotificationMetadata ;
      private bool[] T00093_n60WWPNotificationMetadata ;
      private long[] T00093_A23WWPNotificationDefinitionId ;
      private string[] T00093_A7WWPUserExtendedId ;
      private bool[] T00093_n7WWPUserExtendedId ;
      private long[] T000910_A22WWPNotificationId ;
      private bool[] T000910_n22WWPNotificationId ;
      private long[] T000911_A22WWPNotificationId ;
      private bool[] T000911_n22WWPNotificationId ;
      private long[] T00092_A22WWPNotificationId ;
      private bool[] T00092_n22WWPNotificationId ;
      private DateTime[] T00092_A24WWPNotificationCreated ;
      private string[] T00092_A76WWPNotificationIcon ;
      private string[] T00092_A77WWPNotificationTitle ;
      private string[] T00092_A78WWPNotificationShortDescriptio ;
      private string[] T00092_A79WWPNotificationLink ;
      private bool[] T00092_A82WWPNotificationIsRead ;
      private string[] T00092_A60WWPNotificationMetadata ;
      private bool[] T00092_n60WWPNotificationMetadata ;
      private long[] T00092_A23WWPNotificationDefinitionId ;
      private string[] T00092_A7WWPUserExtendedId ;
      private bool[] T00092_n7WWPUserExtendedId ;
      private long[] T000913_A22WWPNotificationId ;
      private bool[] T000913_n22WWPNotificationId ;
      private string[] T000916_A59WWPNotificationDefinitionName ;
      private string[] T000917_A8WWPUserExtendedFullName ;
      private long[] T000918_A80WWPMailId ;
      private long[] T000919_A47WWPWebNotificationId ;
      private long[] T000920_A33WWPSMSId ;
      private long[] T000921_A22WWPNotificationId ;
      private bool[] T000921_n22WWPNotificationId ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notification__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notification__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00092;
        prmT00092 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT00093;
        prmT00093 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT00094;
        prmT00094 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00095;
        prmT00095 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00096;
        prmT00096 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT00097;
        prmT00097 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00098;
        prmT00098 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00099;
        prmT00099 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000910;
        prmT000910 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000911;
        prmT000911 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000912;
        prmT000912 = new Object[] {
        new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000913;
        prmT000913 = new Object[] {
        };
        Object[] prmT000914;
        prmT000914 = new Object[] {
        new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000915;
        prmT000915 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000916;
        prmT000916 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000917;
        prmT000917 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000918;
        prmT000918 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000919;
        prmT000919 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000920;
        prmT000920 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000921;
        prmT000921 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00092", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId  FOR UPDATE OF WWP_Notification NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00093", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00094", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00095", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00096", "SELECT TM1.WWPNotificationId, T2.WWPNotificationDefinitionName, TM1.WWPNotificationCreated, TM1.WWPNotificationIcon, TM1.WWPNotificationTitle, TM1.WWPNotificationShortDescriptio, TM1.WWPNotificationLink, TM1.WWPNotificationIsRead, T3.WWPUserExtendedFullName, TM1.WWPNotificationMetadata, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM ((WWP_Notification TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) LEFT JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPNotificationId = :WWPNotificationId ORDER BY TM1.WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00097", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00098", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00099", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000910", "SELECT WWPNotificationId FROM WWP_Notification WHERE ( WWPNotificationId > :WWPNotificationId) ORDER BY WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000910,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000911", "SELECT WWPNotificationId FROM WWP_Notification WHERE ( WWPNotificationId < :WWPNotificationId) ORDER BY WWPNotificationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000912", "SAVEPOINT gxupdate;INSERT INTO WWP_Notification(WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPNotificationCreated, :WWPNotificationIcon, :WWPNotificationTitle, :WWPNotificationShortDescriptio, :WWPNotificationLink, :WWPNotificationIsRead, :WWPNotificationMetadata, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000912)
           ,new CursorDef("T000913", "SELECT currval('WWPNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000913,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000914", "SAVEPOINT gxupdate;UPDATE WWP_Notification SET WWPNotificationCreated=:WWPNotificationCreated, WWPNotificationIcon=:WWPNotificationIcon, WWPNotificationTitle=:WWPNotificationTitle, WWPNotificationShortDescriptio=:WWPNotificationShortDescriptio, WWPNotificationLink=:WWPNotificationLink, WWPNotificationIsRead=:WWPNotificationIsRead, WWPNotificationMetadata=:WWPNotificationMetadata, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000914)
           ,new CursorDef("T000915", "SAVEPOINT gxupdate;DELETE FROM WWP_Notification  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000915)
           ,new CursorDef("T000916", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000916,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000917", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000918", "SELECT WWPMailId FROM WWP_Mail WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000918,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000919", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000919,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000920", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000920,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000921", "SELECT WWPNotificationId FROM WWP_Notification ORDER BY WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000921,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(12);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
