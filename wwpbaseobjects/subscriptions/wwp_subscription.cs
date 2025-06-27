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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscription : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A23WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A23WWPNotificationDefinitionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A20WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A20WWPEntityId", StringUtil.LTrimStr( (decimal)(A20WWPEntityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A20WWPEntityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
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
            gxLoad_4( A7WWPUserExtendedId) ;
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
         Form.Meta.addItem("description", "WWP_Subscription", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_subscription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscription( IGxContext context )
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
         chkWWPSubscriptionSubscribed = new GXCheckbox();
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
            return "wwpsubscription_Execute" ;
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
         A27WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A27WWPSubscriptionSubscribed));
         AssignAttri("", false, "A27WWPSubscriptionSubscribed", A27WWPSubscriptionSubscribed);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_Subscription", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSubscriptionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25WWPSubscriptionId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPSubscriptionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A25WWPSubscriptionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A25WWPSubscriptionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSubscriptionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSubscriptionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A23WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A23WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionDescr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionDescr_Internalname, "Notification Definition Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionDescr_Internalname, A29WWPNotificationDefinitionDescr, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtWWPNotificationDefinitionDescr_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPEntityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPEntityName_Internalname, "Entity Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A21WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A21WWPEntityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A7WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A7WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A8WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A8WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionEntityRecordId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionEntityRecordId_Internalname, "Record Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSubscriptionEntityRecordId_Internalname, A26WWPSubscriptionEntityRecordId, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPSubscriptionEntityRecordId_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionEntityRecordDes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionEntityRecordDes_Internalname, "Record Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSubscriptionEntityRecordDes_Internalname, A28WWPSubscriptionEntityRecordDes, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPSubscriptionEntityRecordDes_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionRoleId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionRoleId_Internalname, "Role Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSubscriptionRoleId_Internalname, StringUtil.RTrim( A19WWPSubscriptionRoleId), StringUtil.RTrim( context.localUtil.Format( A19WWPSubscriptionRoleId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSubscriptionRoleId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSubscriptionRoleId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPSubscriptionSubscribed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPSubscriptionSubscribed_Internalname, "Subscribed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPSubscriptionSubscribed_Internalname, StringUtil.BoolToStr( A27WWPSubscriptionSubscribed), "", "Subscribed", 1, chkWWPSubscriptionSubscribed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Subscriptions/WWP_Subscription.htm");
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
            Z25WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z25WWPSubscriptionId"), ".", ","), 18, MidpointRounding.ToEven));
            Z26WWPSubscriptionEntityRecordId = cgiGet( "Z26WWPSubscriptionEntityRecordId");
            Z28WWPSubscriptionEntityRecordDes = cgiGet( "Z28WWPSubscriptionEntityRecordDes");
            Z19WWPSubscriptionRoleId = cgiGet( "Z19WWPSubscriptionRoleId");
            n19WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A19WWPSubscriptionRoleId)) ? true : false);
            Z27WWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( "Z27WWPSubscriptionSubscribed"));
            Z23WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z23WWPNotificationDefinitionId"), ".", ","), 18, MidpointRounding.ToEven));
            Z7WWPUserExtendedId = cgiGet( "Z7WWPUserExtendedId");
            n7WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A20WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "WWPENTITYID"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPSUBSCRIPTIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPSubscriptionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A25WWPSubscriptionId = 0;
               AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
            }
            else
            {
               A25WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
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
            A29WWPNotificationDefinitionDescr = cgiGet( edtWWPNotificationDefinitionDescr_Internalname);
            AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
            A21WWPEntityName = cgiGet( edtWWPEntityName_Internalname);
            AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
            A7WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n7WWPUserExtendedId = false;
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            n7WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ? true : false);
            A8WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
            A26WWPSubscriptionEntityRecordId = cgiGet( edtWWPSubscriptionEntityRecordId_Internalname);
            AssignAttri("", false, "A26WWPSubscriptionEntityRecordId", A26WWPSubscriptionEntityRecordId);
            A28WWPSubscriptionEntityRecordDes = cgiGet( edtWWPSubscriptionEntityRecordDes_Internalname);
            AssignAttri("", false, "A28WWPSubscriptionEntityRecordDes", A28WWPSubscriptionEntityRecordDes);
            A19WWPSubscriptionRoleId = cgiGet( edtWWPSubscriptionRoleId_Internalname);
            n19WWPSubscriptionRoleId = false;
            AssignAttri("", false, "A19WWPSubscriptionRoleId", A19WWPSubscriptionRoleId);
            n19WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A19WWPSubscriptionRoleId)) ? true : false);
            A27WWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( chkWWPSubscriptionSubscribed_Internalname));
            AssignAttri("", false, "A27WWPSubscriptionSubscribed", A27WWPSubscriptionSubscribed);
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
               A25WWPSubscriptionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSubscriptionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
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
               InitAll044( ) ;
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
         DisableAttributes044( ) ;
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

      protected void ResetCaption040( )
      {
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z26WWPSubscriptionEntityRecordId = T00043_A26WWPSubscriptionEntityRecordId[0];
               Z28WWPSubscriptionEntityRecordDes = T00043_A28WWPSubscriptionEntityRecordDes[0];
               Z19WWPSubscriptionRoleId = T00043_A19WWPSubscriptionRoleId[0];
               Z27WWPSubscriptionSubscribed = T00043_A27WWPSubscriptionSubscribed[0];
               Z23WWPNotificationDefinitionId = T00043_A23WWPNotificationDefinitionId[0];
               Z7WWPUserExtendedId = T00043_A7WWPUserExtendedId[0];
            }
            else
            {
               Z26WWPSubscriptionEntityRecordId = A26WWPSubscriptionEntityRecordId;
               Z28WWPSubscriptionEntityRecordDes = A28WWPSubscriptionEntityRecordDes;
               Z19WWPSubscriptionRoleId = A19WWPSubscriptionRoleId;
               Z27WWPSubscriptionSubscribed = A27WWPSubscriptionSubscribed;
               Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
               Z7WWPUserExtendedId = A7WWPUserExtendedId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z25WWPSubscriptionId = A25WWPSubscriptionId;
            Z26WWPSubscriptionEntityRecordId = A26WWPSubscriptionEntityRecordId;
            Z28WWPSubscriptionEntityRecordDes = A28WWPSubscriptionEntityRecordDes;
            Z19WWPSubscriptionRoleId = A19WWPSubscriptionRoleId;
            Z27WWPSubscriptionSubscribed = A27WWPSubscriptionSubscribed;
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
            Z20WWPEntityId = A20WWPEntityId;
            Z29WWPNotificationDefinitionDescr = A29WWPNotificationDefinitionDescr;
            Z21WWPEntityName = A21WWPEntityName;
            Z8WWPUserExtendedFullName = A8WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
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

      protected void Load044( )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A25WWPSubscriptionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
            A20WWPEntityId = T00047_A20WWPEntityId[0];
            A29WWPNotificationDefinitionDescr = T00047_A29WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
            A21WWPEntityName = T00047_A21WWPEntityName[0];
            AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
            A8WWPUserExtendedFullName = T00047_A8WWPUserExtendedFullName[0];
            AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
            A26WWPSubscriptionEntityRecordId = T00047_A26WWPSubscriptionEntityRecordId[0];
            AssignAttri("", false, "A26WWPSubscriptionEntityRecordId", A26WWPSubscriptionEntityRecordId);
            A28WWPSubscriptionEntityRecordDes = T00047_A28WWPSubscriptionEntityRecordDes[0];
            AssignAttri("", false, "A28WWPSubscriptionEntityRecordDes", A28WWPSubscriptionEntityRecordDes);
            A19WWPSubscriptionRoleId = T00047_A19WWPSubscriptionRoleId[0];
            n19WWPSubscriptionRoleId = T00047_n19WWPSubscriptionRoleId[0];
            AssignAttri("", false, "A19WWPSubscriptionRoleId", A19WWPSubscriptionRoleId);
            A27WWPSubscriptionSubscribed = T00047_A27WWPSubscriptionSubscribed[0];
            AssignAttri("", false, "A27WWPSubscriptionSubscribed", A27WWPSubscriptionSubscribed);
            A23WWPNotificationDefinitionId = T00047_A23WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            A7WWPUserExtendedId = T00047_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = T00047_n7WWPUserExtendedId[0];
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            ZM044( -2) ;
         }
         pr_default.close(5);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20WWPEntityId = T00044_A20WWPEntityId[0];
         A29WWPNotificationDefinitionDescr = T00044_A29WWPNotificationDefinitionDescr[0];
         AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
         pr_default.close(2);
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A20WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A21WWPEntityName = T00046_A21WWPEntityName[0];
         AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
         pr_default.close(4);
         /* Using cursor T00045 */
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
         A8WWPUserExtendedFullName = T00045_A8WWPUserExtendedFullName[0];
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( long A23WWPNotificationDefinitionId )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20WWPEntityId = T00048_A20WWPEntityId[0];
         A29WWPNotificationDefinitionDescr = T00048_A29WWPNotificationDefinitionDescr[0];
         AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20WWPEntityId), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A29WWPNotificationDefinitionDescr)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_5( long A20WWPEntityId )
      {
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A20WWPEntityId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A21WWPEntityName = T00049_A21WWPEntityName[0];
         AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A21WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( string A7WWPUserExtendedId )
      {
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A8WWPUserExtendedFullName = T000410_A8WWPUserExtendedFullName[0];
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A8WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey044( )
      {
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {A25WWPSubscriptionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A25WWPSubscriptionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 2) ;
            RcdFound4 = 1;
            A25WWPSubscriptionId = T00043_A25WWPSubscriptionId[0];
            AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
            A26WWPSubscriptionEntityRecordId = T00043_A26WWPSubscriptionEntityRecordId[0];
            AssignAttri("", false, "A26WWPSubscriptionEntityRecordId", A26WWPSubscriptionEntityRecordId);
            A28WWPSubscriptionEntityRecordDes = T00043_A28WWPSubscriptionEntityRecordDes[0];
            AssignAttri("", false, "A28WWPSubscriptionEntityRecordDes", A28WWPSubscriptionEntityRecordDes);
            A19WWPSubscriptionRoleId = T00043_A19WWPSubscriptionRoleId[0];
            n19WWPSubscriptionRoleId = T00043_n19WWPSubscriptionRoleId[0];
            AssignAttri("", false, "A19WWPSubscriptionRoleId", A19WWPSubscriptionRoleId);
            A27WWPSubscriptionSubscribed = T00043_A27WWPSubscriptionSubscribed[0];
            AssignAttri("", false, "A27WWPSubscriptionSubscribed", A27WWPSubscriptionSubscribed);
            A23WWPNotificationDefinitionId = T00043_A23WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            A7WWPUserExtendedId = T00043_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = T00043_n7WWPUserExtendedId[0];
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            Z25WWPSubscriptionId = A25WWPSubscriptionId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         RcdFound4 = 0;
         /* Using cursor T000412 */
         pr_default.execute(10, new Object[] {A25WWPSubscriptionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000412_A25WWPSubscriptionId[0] < A25WWPSubscriptionId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000412_A25WWPSubscriptionId[0] > A25WWPSubscriptionId ) ) )
            {
               A25WWPSubscriptionId = T000412_A25WWPSubscriptionId[0];
               AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000413 */
         pr_default.execute(11, new Object[] {A25WWPSubscriptionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000413_A25WWPSubscriptionId[0] > A25WWPSubscriptionId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000413_A25WWPSubscriptionId[0] < A25WWPSubscriptionId ) ) )
            {
               A25WWPSubscriptionId = T000413_A25WWPSubscriptionId[0];
               AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A25WWPSubscriptionId != Z25WWPSubscriptionId )
               {
                  A25WWPSubscriptionId = Z25WWPSubscriptionId;
                  AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPSUBSCRIPTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update044( ) ;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A25WWPSubscriptionId != Z25WWPSubscriptionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPSUBSCRIPTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPSubscriptionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPSubscriptionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert044( ) ;
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
         if ( A25WWPSubscriptionId != Z25WWPSubscriptionId )
         {
            A25WWPSubscriptionId = Z25WWPSubscriptionId;
            AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPSUBSCRIPTIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPSUBSCRIPTIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
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
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
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
         ScanEnd044( ) ;
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
         if ( RcdFound4 == 0 )
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
         if ( RcdFound4 == 0 )
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
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound4 != 0 )
            {
               ScanNext044( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A25WWPSubscriptionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z26WWPSubscriptionEntityRecordId, T00042_A26WWPSubscriptionEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z28WWPSubscriptionEntityRecordDes, T00042_A28WWPSubscriptionEntityRecordDes[0]) != 0 ) || ( StringUtil.StrCmp(Z19WWPSubscriptionRoleId, T00042_A19WWPSubscriptionRoleId[0]) != 0 ) || ( Z27WWPSubscriptionSubscribed != T00042_A27WWPSubscriptionSubscribed[0] ) || ( Z23WWPNotificationDefinitionId != T00042_A23WWPNotificationDefinitionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z7WWPUserExtendedId, T00042_A7WWPUserExtendedId[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z26WWPSubscriptionEntityRecordId, T00042_A26WWPSubscriptionEntityRecordId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionEntityRecordId");
                  GXUtil.WriteLogRaw("Old: ",Z26WWPSubscriptionEntityRecordId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A26WWPSubscriptionEntityRecordId[0]);
               }
               if ( StringUtil.StrCmp(Z28WWPSubscriptionEntityRecordDes, T00042_A28WWPSubscriptionEntityRecordDes[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionEntityRecordDes");
                  GXUtil.WriteLogRaw("Old: ",Z28WWPSubscriptionEntityRecordDes);
                  GXUtil.WriteLogRaw("Current: ",T00042_A28WWPSubscriptionEntityRecordDes[0]);
               }
               if ( StringUtil.StrCmp(Z19WWPSubscriptionRoleId, T00042_A19WWPSubscriptionRoleId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionRoleId");
                  GXUtil.WriteLogRaw("Old: ",Z19WWPSubscriptionRoleId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A19WWPSubscriptionRoleId[0]);
               }
               if ( Z27WWPSubscriptionSubscribed != T00042_A27WWPSubscriptionSubscribed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionSubscribed");
                  GXUtil.WriteLogRaw("Old: ",Z27WWPSubscriptionSubscribed);
                  GXUtil.WriteLogRaw("Current: ",T00042_A27WWPSubscriptionSubscribed[0]);
               }
               if ( Z23WWPNotificationDefinitionId != T00042_A23WWPNotificationDefinitionId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPNotificationDefinitionId");
                  GXUtil.WriteLogRaw("Old: ",Z23WWPNotificationDefinitionId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A23WWPNotificationDefinitionId[0]);
               }
               if ( StringUtil.StrCmp(Z7WWPUserExtendedId, T00042_A7WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z7WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A7WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Subscription"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         if ( ! IsAuthorized("wwpsubscription_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000414 */
                     pr_default.execute(12, new Object[] {A26WWPSubscriptionEntityRecordId, A28WWPSubscriptionEntityRecordDes, n19WWPSubscriptionRoleId, A19WWPSubscriptionRoleId, A27WWPSubscriptionSubscribed, A23WWPNotificationDefinitionId, n7WWPUserExtendedId, A7WWPUserExtendedId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000415 */
                     pr_default.execute(13);
                     A25WWPSubscriptionId = T000415_A25WWPSubscriptionId[0];
                     AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         if ( ! IsAuthorized("wwpsubscription_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000416 */
                     pr_default.execute(14, new Object[] {A26WWPSubscriptionEntityRecordId, A28WWPSubscriptionEntityRecordDes, n19WWPSubscriptionRoleId, A19WWPSubscriptionRoleId, A27WWPSubscriptionSubscribed, A23WWPNotificationDefinitionId, n7WWPUserExtendedId, A7WWPUserExtendedId, A25WWPSubscriptionId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption040( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpsubscription_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000417 */
                  pr_default.execute(15, new Object[] {A25WWPSubscriptionId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound4 == 0 )
                        {
                           InitAll044( ) ;
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
                        ResetCaption040( ) ;
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000418 */
            pr_default.execute(16, new Object[] {A23WWPNotificationDefinitionId});
            A20WWPEntityId = T000418_A20WWPEntityId[0];
            A29WWPNotificationDefinitionDescr = T000418_A29WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
            pr_default.close(16);
            /* Using cursor T000419 */
            pr_default.execute(17, new Object[] {A20WWPEntityId});
            A21WWPEntityName = T000419_A21WWPEntityName[0];
            AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
            pr_default.close(17);
            /* Using cursor T000420 */
            pr_default.execute(18, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            A8WWPUserExtendedFullName = T000420_A8WWPUserExtendedFullName[0];
            AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
            pr_default.close(18);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_subscription",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.subscriptions.wwp_subscription",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Using cursor T000421 */
         pr_default.execute(19);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound4 = 1;
            A25WWPSubscriptionId = T000421_A25WWPSubscriptionId[0];
            AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound4 = 1;
            A25WWPSubscriptionId = T000421_A25WWPSubscriptionId[0];
            AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm044( )
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

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
         edtWWPSubscriptionId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionDescr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionDescr_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPSubscriptionEntityRecordId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionEntityRecordId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionEntityRecordId_Enabled), 5, 0), true);
         edtWWPSubscriptionEntityRecordDes_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionEntityRecordDes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionEntityRecordDes_Enabled), 5, 0), true);
         edtWWPSubscriptionRoleId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionRoleId_Enabled), 5, 0), true);
         chkWWPSubscriptionSubscribed.Enabled = 0;
         AssignProp("", false, chkWWPSubscriptionSubscribed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPSubscriptionSubscribed.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscription.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z25WWPSubscriptionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25WWPSubscriptionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z26WWPSubscriptionEntityRecordId", Z26WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z28WWPSubscriptionEntityRecordDes", Z28WWPSubscriptionEntityRecordDes);
         GxWebStd.gx_hidden_field( context, "Z19WWPSubscriptionRoleId", StringUtil.RTrim( Z19WWPSubscriptionRoleId));
         GxWebStd.gx_boolean_hidden_field( context, "Z27WWPSubscriptionSubscribed", Z27WWPSubscriptionSubscribed);
         GxWebStd.gx_hidden_field( context, "Z23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z7WWPUserExtendedId", StringUtil.RTrim( Z7WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "WWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20WWPEntityId), 10, 0, ".", "")));
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
         return formatLink("wwpbaseobjects.subscriptions.wwp_subscription.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Subscriptions.WWP_Subscription" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_Subscription" ;
      }

      protected void InitializeNonKey044( )
      {
         A20WWPEntityId = 0;
         AssignAttri("", false, "A20WWPEntityId", StringUtil.LTrimStr( (decimal)(A20WWPEntityId), 10, 0));
         A23WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
         A29WWPNotificationDefinitionDescr = "";
         AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
         A21WWPEntityName = "";
         AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
         A7WWPUserExtendedId = "";
         n7WWPUserExtendedId = false;
         AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
         n7WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ? true : false);
         A8WWPUserExtendedFullName = "";
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
         A26WWPSubscriptionEntityRecordId = "";
         AssignAttri("", false, "A26WWPSubscriptionEntityRecordId", A26WWPSubscriptionEntityRecordId);
         A28WWPSubscriptionEntityRecordDes = "";
         AssignAttri("", false, "A28WWPSubscriptionEntityRecordDes", A28WWPSubscriptionEntityRecordDes);
         A19WWPSubscriptionRoleId = "";
         n19WWPSubscriptionRoleId = false;
         AssignAttri("", false, "A19WWPSubscriptionRoleId", A19WWPSubscriptionRoleId);
         n19WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A19WWPSubscriptionRoleId)) ? true : false);
         A27WWPSubscriptionSubscribed = false;
         AssignAttri("", false, "A27WWPSubscriptionSubscribed", A27WWPSubscriptionSubscribed);
         Z26WWPSubscriptionEntityRecordId = "";
         Z28WWPSubscriptionEntityRecordDes = "";
         Z19WWPSubscriptionRoleId = "";
         Z27WWPSubscriptionSubscribed = false;
         Z23WWPNotificationDefinitionId = 0;
         Z7WWPUserExtendedId = "";
      }

      protected void InitAll044( )
      {
         A25WWPSubscriptionId = 0;
         AssignAttri("", false, "A25WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A25WWPSubscriptionId), 10, 0));
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267482435", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscription.js", "?20256267482435", false, true);
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
         edtWWPSubscriptionId_Internalname = "WWPSUBSCRIPTIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionDescr_Internalname = "WWPNOTIFICATIONDEFINITIONDESCR";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPSubscriptionEntityRecordId_Internalname = "WWPSUBSCRIPTIONENTITYRECORDID";
         edtWWPSubscriptionEntityRecordDes_Internalname = "WWPSUBSCRIPTIONENTITYRECORDDES";
         edtWWPSubscriptionRoleId_Internalname = "WWPSUBSCRIPTIONROLEID";
         chkWWPSubscriptionSubscribed_Internalname = "WWPSUBSCRIPTIONSUBSCRIBED";
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
         Form.Caption = "WWP_Subscription";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPSubscriptionSubscribed.Enabled = 1;
         edtWWPSubscriptionRoleId_Jsonclick = "";
         edtWWPSubscriptionRoleId_Enabled = 1;
         edtWWPSubscriptionEntityRecordDes_Enabled = 1;
         edtWWPSubscriptionEntityRecordId_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
         edtWWPSubscriptionId_Jsonclick = "";
         edtWWPSubscriptionId_Enabled = 1;
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
         chkWWPSubscriptionSubscribed.Name = "WWPSUBSCRIPTIONSUBSCRIBED";
         chkWWPSubscriptionSubscribed.WebTags = "";
         chkWWPSubscriptionSubscribed.Caption = "Subscribed";
         AssignProp("", false, chkWWPSubscriptionSubscribed_Internalname, "TitleCaption", chkWWPSubscriptionSubscribed.Caption, true);
         chkWWPSubscriptionSubscribed.CheckedValue = "false";
         A27WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A27WWPSubscriptionSubscribed));
         AssignAttri("", false, "A27WWPSubscriptionSubscribed", A27WWPSubscriptionSubscribed);
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

      public void Valid_Wwpsubscriptionid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A27WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A27WWPSubscriptionSubscribed));
         /*  Sending validation outputs */
         AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A7WWPUserExtendedId", StringUtil.RTrim( A7WWPUserExtendedId));
         AssignAttri("", false, "A26WWPSubscriptionEntityRecordId", A26WWPSubscriptionEntityRecordId);
         AssignAttri("", false, "A28WWPSubscriptionEntityRecordDes", A28WWPSubscriptionEntityRecordDes);
         AssignAttri("", false, "A19WWPSubscriptionRoleId", StringUtil.RTrim( A19WWPSubscriptionRoleId));
         AssignAttri("", false, "A27WWPSubscriptionSubscribed", A27WWPSubscriptionSubscribed);
         AssignAttri("", false, "A20WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z25WWPSubscriptionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25WWPSubscriptionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z7WWPUserExtendedId", StringUtil.RTrim( Z7WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z26WWPSubscriptionEntityRecordId", Z26WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z28WWPSubscriptionEntityRecordDes", Z28WWPSubscriptionEntityRecordDes);
         GxWebStd.gx_hidden_field( context, "Z19WWPSubscriptionRoleId", StringUtil.RTrim( Z19WWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, "Z27WWPSubscriptionSubscribed", StringUtil.BoolToStr( Z27WWPSubscriptionSubscribed));
         GxWebStd.gx_hidden_field( context, "Z20WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z29WWPNotificationDefinitionDescr", Z29WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, "Z21WWPEntityName", Z21WWPEntityName);
         GxWebStd.gx_hidden_field( context, "Z8WWPUserExtendedFullName", Z8WWPUserExtendedFullName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationdefinitionid( )
      {
         /* Using cursor T000418 */
         pr_default.execute(16, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         }
         A20WWPEntityId = T000418_A20WWPEntityId[0];
         A29WWPNotificationDefinitionDescr = T000418_A29WWPNotificationDefinitionDescr[0];
         pr_default.close(16);
         /* Using cursor T000419 */
         pr_default.execute(17, new Object[] {A20WWPEntityId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A21WWPEntityName = T000419_A21WWPEntityName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A20WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
      }

      public void Valid_Wwpuserextendedid( )
      {
         n7WWPUserExtendedId = false;
         /* Using cursor T000420 */
         pr_default.execute(18, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A7WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("No matching 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         A8WWPUserExtendedFullName = T000420_A8WWPUserExtendedFullName[0];
         pr_default.close(18);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]}""");
         setEventMetadata("VALID_WWPSUBSCRIPTIONID","""{"handler":"Valid_Wwpsubscriptionid","iparms":[{"av":"A25WWPSubscriptionId","fld":"WWPSUBSCRIPTIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]""");
         setEventMetadata("VALID_WWPSUBSCRIPTIONID",""","oparms":[{"av":"A23WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A26WWPSubscriptionEntityRecordId","fld":"WWPSUBSCRIPTIONENTITYRECORDID"},{"av":"A28WWPSubscriptionEntityRecordDes","fld":"WWPSUBSCRIPTIONENTITYRECORDDES"},{"av":"A19WWPSubscriptionRoleId","fld":"WWPSUBSCRIPTIONROLEID"},{"av":"A20WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A29WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A21WWPEntityName","fld":"WWPENTITYNAME"},{"av":"A8WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z25WWPSubscriptionId"},{"av":"Z23WWPNotificationDefinitionId"},{"av":"Z7WWPUserExtendedId"},{"av":"Z26WWPSubscriptionEntityRecordId"},{"av":"Z28WWPSubscriptionEntityRecordDes"},{"av":"Z19WWPSubscriptionRoleId"},{"av":"Z27WWPSubscriptionSubscribed"},{"av":"Z20WWPEntityId"},{"av":"Z29WWPNotificationDefinitionDescr"},{"av":"Z21WWPEntityName"},{"av":"Z8WWPUserExtendedFullName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","""{"handler":"Valid_Wwpnotificationdefinitionid","iparms":[{"av":"A23WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"A20WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A29WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A21WWPEntityName","fld":"WWPENTITYNAME"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",""","oparms":[{"av":"A20WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A29WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A21WWPEntityName","fld":"WWPENTITYNAME"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]}""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","""{"handler":"Valid_Wwpuserextendedid","iparms":[{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"A8WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",""","oparms":[{"av":"A8WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A27WWPSubscriptionSubscribed","fld":"WWPSUBSCRIPTIONSUBSCRIBED"}]}""");
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
         pr_default.close(16);
         pr_default.close(18);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z26WWPSubscriptionEntityRecordId = "";
         Z28WWPSubscriptionEntityRecordDes = "";
         Z19WWPSubscriptionRoleId = "";
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
         A29WWPNotificationDefinitionDescr = "";
         A21WWPEntityName = "";
         A8WWPUserExtendedFullName = "";
         A26WWPSubscriptionEntityRecordId = "";
         A28WWPSubscriptionEntityRecordDes = "";
         A19WWPSubscriptionRoleId = "";
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
         Z29WWPNotificationDefinitionDescr = "";
         Z21WWPEntityName = "";
         Z8WWPUserExtendedFullName = "";
         T00047_A20WWPEntityId = new long[1] ;
         T00047_A25WWPSubscriptionId = new long[1] ;
         T00047_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         T00047_A21WWPEntityName = new string[] {""} ;
         T00047_A8WWPUserExtendedFullName = new string[] {""} ;
         T00047_A26WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00047_A28WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T00047_A19WWPSubscriptionRoleId = new string[] {""} ;
         T00047_n19WWPSubscriptionRoleId = new bool[] {false} ;
         T00047_A27WWPSubscriptionSubscribed = new bool[] {false} ;
         T00047_A23WWPNotificationDefinitionId = new long[1] ;
         T00047_A7WWPUserExtendedId = new string[] {""} ;
         T00047_n7WWPUserExtendedId = new bool[] {false} ;
         T00044_A20WWPEntityId = new long[1] ;
         T00044_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         T00046_A21WWPEntityName = new string[] {""} ;
         T00045_A8WWPUserExtendedFullName = new string[] {""} ;
         T00048_A20WWPEntityId = new long[1] ;
         T00048_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         T00049_A21WWPEntityName = new string[] {""} ;
         T000410_A8WWPUserExtendedFullName = new string[] {""} ;
         T000411_A25WWPSubscriptionId = new long[1] ;
         T00043_A25WWPSubscriptionId = new long[1] ;
         T00043_A26WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00043_A28WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T00043_A19WWPSubscriptionRoleId = new string[] {""} ;
         T00043_n19WWPSubscriptionRoleId = new bool[] {false} ;
         T00043_A27WWPSubscriptionSubscribed = new bool[] {false} ;
         T00043_A23WWPNotificationDefinitionId = new long[1] ;
         T00043_A7WWPUserExtendedId = new string[] {""} ;
         T00043_n7WWPUserExtendedId = new bool[] {false} ;
         sMode4 = "";
         T000412_A25WWPSubscriptionId = new long[1] ;
         T000413_A25WWPSubscriptionId = new long[1] ;
         T00042_A25WWPSubscriptionId = new long[1] ;
         T00042_A26WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00042_A28WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T00042_A19WWPSubscriptionRoleId = new string[] {""} ;
         T00042_n19WWPSubscriptionRoleId = new bool[] {false} ;
         T00042_A27WWPSubscriptionSubscribed = new bool[] {false} ;
         T00042_A23WWPNotificationDefinitionId = new long[1] ;
         T00042_A7WWPUserExtendedId = new string[] {""} ;
         T00042_n7WWPUserExtendedId = new bool[] {false} ;
         T000415_A25WWPSubscriptionId = new long[1] ;
         T000418_A20WWPEntityId = new long[1] ;
         T000418_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         T000419_A21WWPEntityName = new string[] {""} ;
         T000420_A8WWPUserExtendedFullName = new string[] {""} ;
         T000421_A25WWPSubscriptionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ7WWPUserExtendedId = "";
         ZZ26WWPSubscriptionEntityRecordId = "";
         ZZ28WWPSubscriptionEntityRecordDes = "";
         ZZ19WWPSubscriptionRoleId = "";
         ZZ29WWPNotificationDefinitionDescr = "";
         ZZ21WWPEntityName = "";
         ZZ8WWPUserExtendedFullName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__default(),
            new Object[][] {
                new Object[] {
               T00042_A25WWPSubscriptionId, T00042_A26WWPSubscriptionEntityRecordId, T00042_A28WWPSubscriptionEntityRecordDes, T00042_A19WWPSubscriptionRoleId, T00042_n19WWPSubscriptionRoleId, T00042_A27WWPSubscriptionSubscribed, T00042_A23WWPNotificationDefinitionId, T00042_A7WWPUserExtendedId, T00042_n7WWPUserExtendedId
               }
               , new Object[] {
               T00043_A25WWPSubscriptionId, T00043_A26WWPSubscriptionEntityRecordId, T00043_A28WWPSubscriptionEntityRecordDes, T00043_A19WWPSubscriptionRoleId, T00043_n19WWPSubscriptionRoleId, T00043_A27WWPSubscriptionSubscribed, T00043_A23WWPNotificationDefinitionId, T00043_A7WWPUserExtendedId, T00043_n7WWPUserExtendedId
               }
               , new Object[] {
               T00044_A20WWPEntityId, T00044_A29WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T00045_A8WWPUserExtendedFullName
               }
               , new Object[] {
               T00046_A21WWPEntityName
               }
               , new Object[] {
               T00047_A20WWPEntityId, T00047_A25WWPSubscriptionId, T00047_A29WWPNotificationDefinitionDescr, T00047_A21WWPEntityName, T00047_A8WWPUserExtendedFullName, T00047_A26WWPSubscriptionEntityRecordId, T00047_A28WWPSubscriptionEntityRecordDes, T00047_A19WWPSubscriptionRoleId, T00047_n19WWPSubscriptionRoleId, T00047_A27WWPSubscriptionSubscribed,
               T00047_A23WWPNotificationDefinitionId, T00047_A7WWPUserExtendedId, T00047_n7WWPUserExtendedId
               }
               , new Object[] {
               T00048_A20WWPEntityId, T00048_A29WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T00049_A21WWPEntityName
               }
               , new Object[] {
               T000410_A8WWPUserExtendedFullName
               }
               , new Object[] {
               T000411_A25WWPSubscriptionId
               }
               , new Object[] {
               T000412_A25WWPSubscriptionId
               }
               , new Object[] {
               T000413_A25WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               T000415_A25WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000418_A20WWPEntityId, T000418_A29WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T000419_A21WWPEntityName
               }
               , new Object[] {
               T000420_A8WWPUserExtendedFullName
               }
               , new Object[] {
               T000421_A25WWPSubscriptionId
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound4 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPSubscriptionId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionDescr_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPSubscriptionEntityRecordId_Enabled ;
      private int edtWWPSubscriptionEntityRecordDes_Enabled ;
      private int edtWWPSubscriptionRoleId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z25WWPSubscriptionId ;
      private long Z23WWPNotificationDefinitionId ;
      private long A23WWPNotificationDefinitionId ;
      private long A20WWPEntityId ;
      private long A25WWPSubscriptionId ;
      private long Z20WWPEntityId ;
      private long ZZ25WWPSubscriptionId ;
      private long ZZ23WWPNotificationDefinitionId ;
      private long ZZ20WWPEntityId ;
      private string sPrefix ;
      private string Z19WWPSubscriptionRoleId ;
      private string Z7WWPUserExtendedId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A7WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPSubscriptionId_Internalname ;
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
      private string edtWWPSubscriptionId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionDescr_Internalname ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPSubscriptionEntityRecordId_Internalname ;
      private string edtWWPSubscriptionEntityRecordDes_Internalname ;
      private string edtWWPSubscriptionRoleId_Internalname ;
      private string A19WWPSubscriptionRoleId ;
      private string edtWWPSubscriptionRoleId_Jsonclick ;
      private string chkWWPSubscriptionSubscribed_Internalname ;
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
      private string sMode4 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ7WWPUserExtendedId ;
      private string ZZ19WWPSubscriptionRoleId ;
      private bool Z27WWPSubscriptionSubscribed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n7WWPUserExtendedId ;
      private bool wbErr ;
      private bool A27WWPSubscriptionSubscribed ;
      private bool n19WWPSubscriptionRoleId ;
      private bool Gx_longc ;
      private bool ZZ27WWPSubscriptionSubscribed ;
      private string Z26WWPSubscriptionEntityRecordId ;
      private string Z28WWPSubscriptionEntityRecordDes ;
      private string A29WWPNotificationDefinitionDescr ;
      private string A21WWPEntityName ;
      private string A8WWPUserExtendedFullName ;
      private string A26WWPSubscriptionEntityRecordId ;
      private string A28WWPSubscriptionEntityRecordDes ;
      private string Z29WWPNotificationDefinitionDescr ;
      private string Z21WWPEntityName ;
      private string Z8WWPUserExtendedFullName ;
      private string ZZ26WWPSubscriptionEntityRecordId ;
      private string ZZ28WWPSubscriptionEntityRecordDes ;
      private string ZZ29WWPNotificationDefinitionDescr ;
      private string ZZ21WWPEntityName ;
      private string ZZ8WWPUserExtendedFullName ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPSubscriptionSubscribed ;
      private IDataStoreProvider pr_default ;
      private long[] T00047_A20WWPEntityId ;
      private long[] T00047_A25WWPSubscriptionId ;
      private string[] T00047_A29WWPNotificationDefinitionDescr ;
      private string[] T00047_A21WWPEntityName ;
      private string[] T00047_A8WWPUserExtendedFullName ;
      private string[] T00047_A26WWPSubscriptionEntityRecordId ;
      private string[] T00047_A28WWPSubscriptionEntityRecordDes ;
      private string[] T00047_A19WWPSubscriptionRoleId ;
      private bool[] T00047_n19WWPSubscriptionRoleId ;
      private bool[] T00047_A27WWPSubscriptionSubscribed ;
      private long[] T00047_A23WWPNotificationDefinitionId ;
      private string[] T00047_A7WWPUserExtendedId ;
      private bool[] T00047_n7WWPUserExtendedId ;
      private long[] T00044_A20WWPEntityId ;
      private string[] T00044_A29WWPNotificationDefinitionDescr ;
      private string[] T00046_A21WWPEntityName ;
      private string[] T00045_A8WWPUserExtendedFullName ;
      private long[] T00048_A20WWPEntityId ;
      private string[] T00048_A29WWPNotificationDefinitionDescr ;
      private string[] T00049_A21WWPEntityName ;
      private string[] T000410_A8WWPUserExtendedFullName ;
      private long[] T000411_A25WWPSubscriptionId ;
      private long[] T00043_A25WWPSubscriptionId ;
      private string[] T00043_A26WWPSubscriptionEntityRecordId ;
      private string[] T00043_A28WWPSubscriptionEntityRecordDes ;
      private string[] T00043_A19WWPSubscriptionRoleId ;
      private bool[] T00043_n19WWPSubscriptionRoleId ;
      private bool[] T00043_A27WWPSubscriptionSubscribed ;
      private long[] T00043_A23WWPNotificationDefinitionId ;
      private string[] T00043_A7WWPUserExtendedId ;
      private bool[] T00043_n7WWPUserExtendedId ;
      private long[] T000412_A25WWPSubscriptionId ;
      private long[] T000413_A25WWPSubscriptionId ;
      private long[] T00042_A25WWPSubscriptionId ;
      private string[] T00042_A26WWPSubscriptionEntityRecordId ;
      private string[] T00042_A28WWPSubscriptionEntityRecordDes ;
      private string[] T00042_A19WWPSubscriptionRoleId ;
      private bool[] T00042_n19WWPSubscriptionRoleId ;
      private bool[] T00042_A27WWPSubscriptionSubscribed ;
      private long[] T00042_A23WWPNotificationDefinitionId ;
      private string[] T00042_A7WWPUserExtendedId ;
      private bool[] T00042_n7WWPUserExtendedId ;
      private long[] T000415_A25WWPSubscriptionId ;
      private long[] T000418_A20WWPEntityId ;
      private string[] T000418_A29WWPNotificationDefinitionDescr ;
      private string[] T000419_A21WWPEntityName ;
      private string[] T000420_A8WWPUserExtendedFullName ;
      private long[] T000421_A25WWPSubscriptionId ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_subscription__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscription__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
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
        Object[] prmT00042;
        prmT00042 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT00043;
        prmT00043 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT00044;
        prmT00044 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00045;
        prmT00045 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00046;
        prmT00046 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT00047;
        prmT00047 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT00048;
        prmT00048 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00049;
        prmT00049 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT000410;
        prmT000410 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000411;
        prmT000411 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT000412;
        prmT000412 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT000413;
        prmT000413 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT000414;
        prmT000414 = new Object[] {
        new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
        new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
        new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000415;
        prmT000415 = new Object[] {
        };
        Object[] prmT000416;
        prmT000416 = new Object[] {
        new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
        new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
        new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT000417;
        prmT000417 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT000418;
        prmT000418 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000419;
        prmT000419 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT000420;
        prmT000420 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000421;
        prmT000421 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00042", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId  FOR UPDATE OF WWP_Subscription NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00043", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00044", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00045", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00046", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00047", "SELECT T2.WWPEntityId, TM1.WWPSubscriptionId, T2.WWPNotificationDefinitionDescr, T3.WWPEntityName, T4.WWPUserExtendedFullName, TM1.WWPSubscriptionEntityRecordId, TM1.WWPSubscriptionEntityRecordDes, TM1.WWPSubscriptionRoleId, TM1.WWPSubscriptionSubscribed, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM (((WWP_Subscription TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = T2.WWPEntityId) LEFT JOIN WWP_UserExtended T4 ON T4.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPSubscriptionId = :WWPSubscriptionId ORDER BY TM1.WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00048", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00049", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000410", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000411", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000412", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE ( WWPSubscriptionId > :WWPSubscriptionId) ORDER BY WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000412,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000413", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE ( WWPSubscriptionId < :WWPSubscriptionId) ORDER BY WWPSubscriptionId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000414", "SAVEPOINT gxupdate;INSERT INTO WWP_Subscription(WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPSubscriptionEntityRecordId, :WWPSubscriptionEntityRecordDes, :WWPSubscriptionRoleId, :WWPSubscriptionSubscribed, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000414)
           ,new CursorDef("T000415", "SELECT currval('WWPSubscriptionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000416", "SAVEPOINT gxupdate;UPDATE WWP_Subscription SET WWPSubscriptionEntityRecordId=:WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes=:WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId=:WWPSubscriptionRoleId, WWPSubscriptionSubscribed=:WWPSubscriptionSubscribed, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000416)
           ,new CursorDef("T000417", "SAVEPOINT gxupdate;DELETE FROM WWP_Subscription  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000417)
           ,new CursorDef("T000418", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000419", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000420", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000421", "SELECT WWPSubscriptionId FROM WWP_Subscription ORDER BY WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((bool[]) buf[9])[0] = rslt.getBool(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 40);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
