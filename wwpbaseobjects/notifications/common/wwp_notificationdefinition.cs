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
   public class wwp_notificationdefinition : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel3"+"_"+"WWPNOTIFICATIONDEFINITIONISAUT") == 0 )
         {
            A67WWPNotificationDefinitionSecFu = GetPar( "WWPNotificationDefinitionSecFu");
            AssignAttri("", false, "A67WWPNotificationDefinitionSecFu", A67WWPNotificationDefinitionSecFu);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX3ASAWWPNOTIFICATIONDEFINITIONISAUT088( A67WWPNotificationDefinitionSecFu) ;
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
         Form.Meta.addItem("description", "Notification Definition", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_notificationdefinition( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notificationdefinition( IGxContext context )
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
         cmbWWPNotificationDefinitionAppli = new GXCombobox();
         chkWWPNotificationDefinitionAllow = new GXCheckbox();
         chkWWPNotificationDefinitionIsAut = new GXCheckbox();
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
            return "wwpnotificationdefinition_Execute" ;
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
         if ( cmbWWPNotificationDefinitionAppli.ItemCount > 0 )
         {
            A30WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A30WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0));
            AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Values", cmbWWPNotificationDefinitionAppli.ToJavascriptSource(), true);
         }
         A31WWPNotificationDefinitionAllow = StringUtil.StrToBool( StringUtil.BoolToStr( A31WWPNotificationDefinitionAllow));
         AssignAttri("", false, "A31WWPNotificationDefinitionAllow", A31WWPNotificationDefinitionAllow);
         A68WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A68WWPNotificationDefinitionIsAut));
         AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Notification Definition", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23WWPNotificationDefinitionId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A23WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A23WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionName_Internalname, "Internal Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A59WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A59WWPNotificationDefinitionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPNotificationDefinitionAppli_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPNotificationDefinitionAppli_Internalname, "Applies To", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPNotificationDefinitionAppli, cmbWWPNotificationDefinitionAppli_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0)), 1, cmbWWPNotificationDefinitionAppli_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPNotificationDefinitionAppli.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0));
         AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Values", (string)(cmbWWPNotificationDefinitionAppli.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPNotificationDefinitionAllow_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationDefinitionAllow_Internalname, "Allow User Subscription", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationDefinitionAllow_Internalname, StringUtil.BoolToStr( A31WWPNotificationDefinitionAllow), "", "Allow User Subscription", 1, chkWWPNotificationDefinitionAllow.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionDescr_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionDescr_Internalname, A29WWPNotificationDefinitionDescr, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPNotificationDefinitionDescr_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionIcon_Internalname, "Default Icon", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionIcon_Internalname, A62WWPNotificationDefinitionIcon, StringUtil.RTrim( context.localUtil.Format( A62WWPNotificationDefinitionIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionIcon_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionTitle_Internalname, "Default Title", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionTitle_Internalname, A63WWPNotificationDefinitionTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPNotificationDefinitionTitle_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionShort_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionShort_Internalname, "Default Short Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionShort_Internalname, A64WWPNotificationDefinitionShort, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPNotificationDefinitionShort_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionLongD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionLongD_Internalname, "Default Long Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionLongD_Internalname, A65WWPNotificationDefinitionLongD, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPNotificationDefinitionLongD_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionLink_Internalname, "Default Link", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionLink_Internalname, A66WWPNotificationDefinitionLink, StringUtil.RTrim( context.localUtil.Format( A66WWPNotificationDefinitionLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", A66WWPNotificationDefinitionLink, "_blank", "", "", edtWWPNotificationDefinitionLink_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPEntityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPEntityId_Internalname, "Entity Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20WWPEntityId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWWPEntityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A20WWPEntityId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A20WWPEntityId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A21WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A21WWPEntityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionSecFu_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionSecFu_Internalname, "Funcionality Key", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionSecFu_Internalname, A67WWPNotificationDefinitionSecFu, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", 0, 1, edtWWPNotificationDefinitionSecFu_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPNotificationDefinitionIsAut_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationDefinitionIsAut_Internalname, "User Authorized", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationDefinitionIsAut_Internalname, StringUtil.BoolToStr( A68WWPNotificationDefinitionIsAut), "", "User Authorized", 1, chkWWPNotificationDefinitionIsAut.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(99, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,99);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/Notifications/Common/WWP_NotificationDefinition.htm");
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
            Z23WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z23WWPNotificationDefinitionId"), ".", ","), 18, MidpointRounding.ToEven));
            Z59WWPNotificationDefinitionName = cgiGet( "Z59WWPNotificationDefinitionName");
            Z30WWPNotificationDefinitionAppli = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z30WWPNotificationDefinitionAppli"), ".", ","), 18, MidpointRounding.ToEven));
            Z31WWPNotificationDefinitionAllow = StringUtil.StrToBool( cgiGet( "Z31WWPNotificationDefinitionAllow"));
            Z29WWPNotificationDefinitionDescr = cgiGet( "Z29WWPNotificationDefinitionDescr");
            Z62WWPNotificationDefinitionIcon = cgiGet( "Z62WWPNotificationDefinitionIcon");
            Z63WWPNotificationDefinitionTitle = cgiGet( "Z63WWPNotificationDefinitionTitle");
            Z64WWPNotificationDefinitionShort = cgiGet( "Z64WWPNotificationDefinitionShort");
            Z65WWPNotificationDefinitionLongD = cgiGet( "Z65WWPNotificationDefinitionLongD");
            Z66WWPNotificationDefinitionLink = cgiGet( "Z66WWPNotificationDefinitionLink");
            Z67WWPNotificationDefinitionSecFu = cgiGet( "Z67WWPNotificationDefinitionSecFu");
            Z20WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z20WWPEntityId"), ".", ","), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
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
            cmbWWPNotificationDefinitionAppli.CurrentValue = cgiGet( cmbWWPNotificationDefinitionAppli_Internalname);
            A30WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPNotificationDefinitionAppli_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A30WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0));
            A31WWPNotificationDefinitionAllow = StringUtil.StrToBool( cgiGet( chkWWPNotificationDefinitionAllow_Internalname));
            AssignAttri("", false, "A31WWPNotificationDefinitionAllow", A31WWPNotificationDefinitionAllow);
            A29WWPNotificationDefinitionDescr = cgiGet( edtWWPNotificationDefinitionDescr_Internalname);
            AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
            A62WWPNotificationDefinitionIcon = cgiGet( edtWWPNotificationDefinitionIcon_Internalname);
            AssignAttri("", false, "A62WWPNotificationDefinitionIcon", A62WWPNotificationDefinitionIcon);
            A63WWPNotificationDefinitionTitle = cgiGet( edtWWPNotificationDefinitionTitle_Internalname);
            AssignAttri("", false, "A63WWPNotificationDefinitionTitle", A63WWPNotificationDefinitionTitle);
            A64WWPNotificationDefinitionShort = cgiGet( edtWWPNotificationDefinitionShort_Internalname);
            AssignAttri("", false, "A64WWPNotificationDefinitionShort", A64WWPNotificationDefinitionShort);
            A65WWPNotificationDefinitionLongD = cgiGet( edtWWPNotificationDefinitionLongD_Internalname);
            AssignAttri("", false, "A65WWPNotificationDefinitionLongD", A65WWPNotificationDefinitionLongD);
            A66WWPNotificationDefinitionLink = cgiGet( edtWWPNotificationDefinitionLink_Internalname);
            AssignAttri("", false, "A66WWPNotificationDefinitionLink", A66WWPNotificationDefinitionLink);
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPENTITYID");
               AnyError = 1;
               GX_FocusControl = edtWWPEntityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A20WWPEntityId = 0;
               AssignAttri("", false, "A20WWPEntityId", StringUtil.LTrimStr( (decimal)(A20WWPEntityId), 10, 0));
            }
            else
            {
               A20WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20WWPEntityId", StringUtil.LTrimStr( (decimal)(A20WWPEntityId), 10, 0));
            }
            A21WWPEntityName = cgiGet( edtWWPEntityName_Internalname);
            AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
            A67WWPNotificationDefinitionSecFu = cgiGet( edtWWPNotificationDefinitionSecFu_Internalname);
            AssignAttri("", false, "A67WWPNotificationDefinitionSecFu", A67WWPNotificationDefinitionSecFu);
            A68WWPNotificationDefinitionIsAut = StringUtil.StrToBool( cgiGet( chkWWPNotificationDefinitionIsAut_Internalname));
            AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
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
               A23WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
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
               InitAll088( ) ;
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
         DisableAttributes088( ) ;
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

      protected void ResetCaption080( )
      {
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z59WWPNotificationDefinitionName = T00083_A59WWPNotificationDefinitionName[0];
               Z30WWPNotificationDefinitionAppli = T00083_A30WWPNotificationDefinitionAppli[0];
               Z31WWPNotificationDefinitionAllow = T00083_A31WWPNotificationDefinitionAllow[0];
               Z29WWPNotificationDefinitionDescr = T00083_A29WWPNotificationDefinitionDescr[0];
               Z62WWPNotificationDefinitionIcon = T00083_A62WWPNotificationDefinitionIcon[0];
               Z63WWPNotificationDefinitionTitle = T00083_A63WWPNotificationDefinitionTitle[0];
               Z64WWPNotificationDefinitionShort = T00083_A64WWPNotificationDefinitionShort[0];
               Z65WWPNotificationDefinitionLongD = T00083_A65WWPNotificationDefinitionLongD[0];
               Z66WWPNotificationDefinitionLink = T00083_A66WWPNotificationDefinitionLink[0];
               Z67WWPNotificationDefinitionSecFu = T00083_A67WWPNotificationDefinitionSecFu[0];
               Z20WWPEntityId = T00083_A20WWPEntityId[0];
            }
            else
            {
               Z59WWPNotificationDefinitionName = A59WWPNotificationDefinitionName;
               Z30WWPNotificationDefinitionAppli = A30WWPNotificationDefinitionAppli;
               Z31WWPNotificationDefinitionAllow = A31WWPNotificationDefinitionAllow;
               Z29WWPNotificationDefinitionDescr = A29WWPNotificationDefinitionDescr;
               Z62WWPNotificationDefinitionIcon = A62WWPNotificationDefinitionIcon;
               Z63WWPNotificationDefinitionTitle = A63WWPNotificationDefinitionTitle;
               Z64WWPNotificationDefinitionShort = A64WWPNotificationDefinitionShort;
               Z65WWPNotificationDefinitionLongD = A65WWPNotificationDefinitionLongD;
               Z66WWPNotificationDefinitionLink = A66WWPNotificationDefinitionLink;
               Z67WWPNotificationDefinitionSecFu = A67WWPNotificationDefinitionSecFu;
               Z20WWPEntityId = A20WWPEntityId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            Z59WWPNotificationDefinitionName = A59WWPNotificationDefinitionName;
            Z30WWPNotificationDefinitionAppli = A30WWPNotificationDefinitionAppli;
            Z31WWPNotificationDefinitionAllow = A31WWPNotificationDefinitionAllow;
            Z29WWPNotificationDefinitionDescr = A29WWPNotificationDefinitionDescr;
            Z62WWPNotificationDefinitionIcon = A62WWPNotificationDefinitionIcon;
            Z63WWPNotificationDefinitionTitle = A63WWPNotificationDefinitionTitle;
            Z64WWPNotificationDefinitionShort = A64WWPNotificationDefinitionShort;
            Z65WWPNotificationDefinitionLongD = A65WWPNotificationDefinitionLongD;
            Z66WWPNotificationDefinitionLink = A66WWPNotificationDefinitionLink;
            Z67WWPNotificationDefinitionSecFu = A67WWPNotificationDefinitionSecFu;
            Z20WWPEntityId = A20WWPEntityId;
            Z21WWPEntityName = A21WWPEntityName;
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

      protected void Load088( )
      {
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
            A59WWPNotificationDefinitionName = T00085_A59WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
            A30WWPNotificationDefinitionAppli = T00085_A30WWPNotificationDefinitionAppli[0];
            AssignAttri("", false, "A30WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0));
            A31WWPNotificationDefinitionAllow = T00085_A31WWPNotificationDefinitionAllow[0];
            AssignAttri("", false, "A31WWPNotificationDefinitionAllow", A31WWPNotificationDefinitionAllow);
            A29WWPNotificationDefinitionDescr = T00085_A29WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
            A62WWPNotificationDefinitionIcon = T00085_A62WWPNotificationDefinitionIcon[0];
            AssignAttri("", false, "A62WWPNotificationDefinitionIcon", A62WWPNotificationDefinitionIcon);
            A63WWPNotificationDefinitionTitle = T00085_A63WWPNotificationDefinitionTitle[0];
            AssignAttri("", false, "A63WWPNotificationDefinitionTitle", A63WWPNotificationDefinitionTitle);
            A64WWPNotificationDefinitionShort = T00085_A64WWPNotificationDefinitionShort[0];
            AssignAttri("", false, "A64WWPNotificationDefinitionShort", A64WWPNotificationDefinitionShort);
            A65WWPNotificationDefinitionLongD = T00085_A65WWPNotificationDefinitionLongD[0];
            AssignAttri("", false, "A65WWPNotificationDefinitionLongD", A65WWPNotificationDefinitionLongD);
            A66WWPNotificationDefinitionLink = T00085_A66WWPNotificationDefinitionLink[0];
            AssignAttri("", false, "A66WWPNotificationDefinitionLink", A66WWPNotificationDefinitionLink);
            A21WWPEntityName = T00085_A21WWPEntityName[0];
            AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
            A67WWPNotificationDefinitionSecFu = T00085_A67WWPNotificationDefinitionSecFu[0];
            AssignAttri("", false, "A67WWPNotificationDefinitionSecFu", A67WWPNotificationDefinitionSecFu);
            A20WWPEntityId = T00085_A20WWPEntityId[0];
            AssignAttri("", false, "A20WWPEntityId", StringUtil.LTrimStr( (decimal)(A20WWPEntityId), 10, 0));
            ZM088( -4) ;
         }
         pr_default.close(3);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A67WWPNotificationDefinitionSecFu)) )
         {
            A68WWPNotificationDefinitionIsAut = true;
            AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
         }
         else
         {
            GXt_boolean1 = A68WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A67WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A68WWPNotificationDefinitionIsAut = GXt_boolean1;
            AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
         }
      }

      protected void CheckExtendedTable088( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( A30WWPNotificationDefinitionAppli == 1 ) || ( A30WWPNotificationDefinitionAppli == 2 ) ) )
         {
            GX_msglist.addItem("Field Notification Definition Applies To is out of range", "OutOfRange", 1, "WWPNOTIFICATIONDEFINITIONAPPLI");
            AnyError = 1;
            GX_FocusControl = cmbWWPNotificationDefinitionAppli_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A66WWPNotificationDefinitionLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("Field Notification Definition Default Link does not match the specified pattern", "OutOfRange", 1, "WWPNOTIFICATIONDEFINITIONLINK");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A20WWPEntityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21WWPEntityName = T00084_A21WWPEntityName[0];
         AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A67WWPNotificationDefinitionSecFu)) )
         {
            A68WWPNotificationDefinitionIsAut = true;
            AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
         }
         else
         {
            GXt_boolean1 = A68WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A67WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A68WWPNotificationDefinitionIsAut = GXt_boolean1;
            AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
         }
      }

      protected void CloseExtendedTableCursors088( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( long A20WWPEntityId )
      {
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A20WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21WWPEntityName = T00086_A21WWPEntityName[0];
         AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A21WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey088( )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 4) ;
            RcdFound8 = 1;
            A23WWPNotificationDefinitionId = T00083_A23WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            A59WWPNotificationDefinitionName = T00083_A59WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
            A30WWPNotificationDefinitionAppli = T00083_A30WWPNotificationDefinitionAppli[0];
            AssignAttri("", false, "A30WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0));
            A31WWPNotificationDefinitionAllow = T00083_A31WWPNotificationDefinitionAllow[0];
            AssignAttri("", false, "A31WWPNotificationDefinitionAllow", A31WWPNotificationDefinitionAllow);
            A29WWPNotificationDefinitionDescr = T00083_A29WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
            A62WWPNotificationDefinitionIcon = T00083_A62WWPNotificationDefinitionIcon[0];
            AssignAttri("", false, "A62WWPNotificationDefinitionIcon", A62WWPNotificationDefinitionIcon);
            A63WWPNotificationDefinitionTitle = T00083_A63WWPNotificationDefinitionTitle[0];
            AssignAttri("", false, "A63WWPNotificationDefinitionTitle", A63WWPNotificationDefinitionTitle);
            A64WWPNotificationDefinitionShort = T00083_A64WWPNotificationDefinitionShort[0];
            AssignAttri("", false, "A64WWPNotificationDefinitionShort", A64WWPNotificationDefinitionShort);
            A65WWPNotificationDefinitionLongD = T00083_A65WWPNotificationDefinitionLongD[0];
            AssignAttri("", false, "A65WWPNotificationDefinitionLongD", A65WWPNotificationDefinitionLongD);
            A66WWPNotificationDefinitionLink = T00083_A66WWPNotificationDefinitionLink[0];
            AssignAttri("", false, "A66WWPNotificationDefinitionLink", A66WWPNotificationDefinitionLink);
            A67WWPNotificationDefinitionSecFu = T00083_A67WWPNotificationDefinitionSecFu[0];
            AssignAttri("", false, "A67WWPNotificationDefinitionSecFu", A67WWPNotificationDefinitionSecFu);
            A20WWPEntityId = T00083_A20WWPEntityId[0];
            AssignAttri("", false, "A20WWPEntityId", StringUtil.LTrimStr( (decimal)(A20WWPEntityId), 10, 0));
            Z23WWPNotificationDefinitionId = A23WWPNotificationDefinitionId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
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
         RcdFound8 = 0;
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00088_A23WWPNotificationDefinitionId[0] < A23WWPNotificationDefinitionId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00088_A23WWPNotificationDefinitionId[0] > A23WWPNotificationDefinitionId ) ) )
            {
               A23WWPNotificationDefinitionId = T00088_A23WWPNotificationDefinitionId[0];
               AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A23WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00089_A23WWPNotificationDefinitionId[0] > A23WWPNotificationDefinitionId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00089_A23WWPNotificationDefinitionId[0] < A23WWPNotificationDefinitionId ) ) )
            {
               A23WWPNotificationDefinitionId = T00089_A23WWPNotificationDefinitionId[0];
               AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert088( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A23WWPNotificationDefinitionId != Z23WWPNotificationDefinitionId )
               {
                  A23WWPNotificationDefinitionId = Z23WWPNotificationDefinitionId;
                  AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update088( ) ;
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A23WWPNotificationDefinitionId != Z23WWPNotificationDefinitionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert088( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert088( ) ;
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
         if ( A23WWPNotificationDefinitionId != Z23WWPNotificationDefinitionId )
         {
            A23WWPNotificationDefinitionId = Z23WWPNotificationDefinitionId;
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd088( ) ;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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
         ScanStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound8 != 0 )
            {
               ScanNext088( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd088( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A23WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z59WWPNotificationDefinitionName, T00082_A59WWPNotificationDefinitionName[0]) != 0 ) || ( Z30WWPNotificationDefinitionAppli != T00082_A30WWPNotificationDefinitionAppli[0] ) || ( Z31WWPNotificationDefinitionAllow != T00082_A31WWPNotificationDefinitionAllow[0] ) || ( StringUtil.StrCmp(Z29WWPNotificationDefinitionDescr, T00082_A29WWPNotificationDefinitionDescr[0]) != 0 ) || ( StringUtil.StrCmp(Z62WWPNotificationDefinitionIcon, T00082_A62WWPNotificationDefinitionIcon[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z63WWPNotificationDefinitionTitle, T00082_A63WWPNotificationDefinitionTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z64WWPNotificationDefinitionShort, T00082_A64WWPNotificationDefinitionShort[0]) != 0 ) || ( StringUtil.StrCmp(Z65WWPNotificationDefinitionLongD, T00082_A65WWPNotificationDefinitionLongD[0]) != 0 ) || ( StringUtil.StrCmp(Z66WWPNotificationDefinitionLink, T00082_A66WWPNotificationDefinitionLink[0]) != 0 ) || ( StringUtil.StrCmp(Z67WWPNotificationDefinitionSecFu, T00082_A67WWPNotificationDefinitionSecFu[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z20WWPEntityId != T00082_A20WWPEntityId[0] ) )
            {
               if ( StringUtil.StrCmp(Z59WWPNotificationDefinitionName, T00082_A59WWPNotificationDefinitionName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionName");
                  GXUtil.WriteLogRaw("Old: ",Z59WWPNotificationDefinitionName);
                  GXUtil.WriteLogRaw("Current: ",T00082_A59WWPNotificationDefinitionName[0]);
               }
               if ( Z30WWPNotificationDefinitionAppli != T00082_A30WWPNotificationDefinitionAppli[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionAppli");
                  GXUtil.WriteLogRaw("Old: ",Z30WWPNotificationDefinitionAppli);
                  GXUtil.WriteLogRaw("Current: ",T00082_A30WWPNotificationDefinitionAppli[0]);
               }
               if ( Z31WWPNotificationDefinitionAllow != T00082_A31WWPNotificationDefinitionAllow[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionAllow");
                  GXUtil.WriteLogRaw("Old: ",Z31WWPNotificationDefinitionAllow);
                  GXUtil.WriteLogRaw("Current: ",T00082_A31WWPNotificationDefinitionAllow[0]);
               }
               if ( StringUtil.StrCmp(Z29WWPNotificationDefinitionDescr, T00082_A29WWPNotificationDefinitionDescr[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionDescr");
                  GXUtil.WriteLogRaw("Old: ",Z29WWPNotificationDefinitionDescr);
                  GXUtil.WriteLogRaw("Current: ",T00082_A29WWPNotificationDefinitionDescr[0]);
               }
               if ( StringUtil.StrCmp(Z62WWPNotificationDefinitionIcon, T00082_A62WWPNotificationDefinitionIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionIcon");
                  GXUtil.WriteLogRaw("Old: ",Z62WWPNotificationDefinitionIcon);
                  GXUtil.WriteLogRaw("Current: ",T00082_A62WWPNotificationDefinitionIcon[0]);
               }
               if ( StringUtil.StrCmp(Z63WWPNotificationDefinitionTitle, T00082_A63WWPNotificationDefinitionTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionTitle");
                  GXUtil.WriteLogRaw("Old: ",Z63WWPNotificationDefinitionTitle);
                  GXUtil.WriteLogRaw("Current: ",T00082_A63WWPNotificationDefinitionTitle[0]);
               }
               if ( StringUtil.StrCmp(Z64WWPNotificationDefinitionShort, T00082_A64WWPNotificationDefinitionShort[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionShort");
                  GXUtil.WriteLogRaw("Old: ",Z64WWPNotificationDefinitionShort);
                  GXUtil.WriteLogRaw("Current: ",T00082_A64WWPNotificationDefinitionShort[0]);
               }
               if ( StringUtil.StrCmp(Z65WWPNotificationDefinitionLongD, T00082_A65WWPNotificationDefinitionLongD[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionLongD");
                  GXUtil.WriteLogRaw("Old: ",Z65WWPNotificationDefinitionLongD);
                  GXUtil.WriteLogRaw("Current: ",T00082_A65WWPNotificationDefinitionLongD[0]);
               }
               if ( StringUtil.StrCmp(Z66WWPNotificationDefinitionLink, T00082_A66WWPNotificationDefinitionLink[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionLink");
                  GXUtil.WriteLogRaw("Old: ",Z66WWPNotificationDefinitionLink);
                  GXUtil.WriteLogRaw("Current: ",T00082_A66WWPNotificationDefinitionLink[0]);
               }
               if ( StringUtil.StrCmp(Z67WWPNotificationDefinitionSecFu, T00082_A67WWPNotificationDefinitionSecFu[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPNotificationDefinitionSecFu");
                  GXUtil.WriteLogRaw("Old: ",Z67WWPNotificationDefinitionSecFu);
                  GXUtil.WriteLogRaw("Current: ",T00082_A67WWPNotificationDefinitionSecFu[0]);
               }
               if ( Z20WWPEntityId != T00082_A20WWPEntityId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notificationdefinition:[seudo value changed for attri]"+"WWPEntityId");
                  GXUtil.WriteLogRaw("Old: ",Z20WWPEntityId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A20WWPEntityId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_NotificationDefinition"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         if ( ! IsAuthorized("wwpnotificationdefinition_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000810 */
                     pr_default.execute(8, new Object[] {A59WWPNotificationDefinitionName, A30WWPNotificationDefinitionAppli, A31WWPNotificationDefinitionAllow, A29WWPNotificationDefinitionDescr, A62WWPNotificationDefinitionIcon, A63WWPNotificationDefinitionTitle, A64WWPNotificationDefinitionShort, A65WWPNotificationDefinitionLongD, A66WWPNotificationDefinitionLink, A67WWPNotificationDefinitionSecFu, A20WWPEntityId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000811 */
                     pr_default.execute(9);
                     A23WWPNotificationDefinitionId = T000811_A23WWPNotificationDefinitionId[0];
                     AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption080( ) ;
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         if ( ! IsAuthorized("wwpnotificationdefinition_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000812 */
                     pr_default.execute(10, new Object[] {A59WWPNotificationDefinitionName, A30WWPNotificationDefinitionAppli, A31WWPNotificationDefinitionAllow, A29WWPNotificationDefinitionDescr, A62WWPNotificationDefinitionIcon, A63WWPNotificationDefinitionTitle, A64WWPNotificationDefinitionShort, A65WWPNotificationDefinitionLongD, A66WWPNotificationDefinitionLink, A67WWPNotificationDefinitionSecFu, A20WWPEntityId, A23WWPNotificationDefinitionId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption080( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpnotificationdefinition_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000813 */
                  pr_default.execute(11, new Object[] {A23WWPNotificationDefinitionId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound8 == 0 )
                        {
                           InitAll088( ) ;
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
                        ResetCaption080( ) ;
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel088( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000814 */
            pr_default.execute(12, new Object[] {A20WWPEntityId});
            A21WWPEntityName = T000814_A21WWPEntityName[0];
            AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
            pr_default.close(12);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A67WWPNotificationDefinitionSecFu)) )
            {
               A68WWPNotificationDefinitionIsAut = true;
               AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
            }
            else
            {
               GXt_boolean1 = A68WWPNotificationDefinitionIsAut;
               new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A67WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
               A68WWPNotificationDefinitionIsAut = GXt_boolean1;
               AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000815 */
            pr_default.execute(13, new Object[] {A23WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000816 */
            pr_default.execute(14, new Object[] {A23WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Subscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart088( )
      {
         /* Using cursor T000817 */
         pr_default.execute(15);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound8 = 1;
            A23WWPNotificationDefinitionId = T000817_A23WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound8 = 1;
            A23WWPNotificationDefinitionId = T000817_A23WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
         }
      }

      protected void ScanEnd088( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         cmbWWPNotificationDefinitionAppli.Enabled = 0;
         AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPNotificationDefinitionAppli.Enabled), 5, 0), true);
         chkWWPNotificationDefinitionAllow.Enabled = 0;
         AssignProp("", false, chkWWPNotificationDefinitionAllow_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationDefinitionAllow.Enabled), 5, 0), true);
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionDescr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionDescr_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionIcon_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionIcon_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionTitle_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionTitle_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionShort_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionShort_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionShort_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionLongD_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionLongD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionLongD_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionLink_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionLink_Enabled), 5, 0), true);
         edtWWPEntityId_Enabled = 0;
         AssignProp("", false, edtWWPEntityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityId_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionSecFu_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionSecFu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionSecFu_Enabled), 5, 0), true);
         chkWWPNotificationDefinitionIsAut.Enabled = 0;
         AssignProp("", false, chkWWPNotificationDefinitionIsAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationDefinitionIsAut.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_notificationdefinition.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z59WWPNotificationDefinitionName", Z59WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z30WWPNotificationDefinitionAppli", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30WWPNotificationDefinitionAppli), 1, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z31WWPNotificationDefinitionAllow", Z31WWPNotificationDefinitionAllow);
         GxWebStd.gx_hidden_field( context, "Z29WWPNotificationDefinitionDescr", Z29WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, "Z62WWPNotificationDefinitionIcon", Z62WWPNotificationDefinitionIcon);
         GxWebStd.gx_hidden_field( context, "Z63WWPNotificationDefinitionTitle", Z63WWPNotificationDefinitionTitle);
         GxWebStd.gx_hidden_field( context, "Z64WWPNotificationDefinitionShort", Z64WWPNotificationDefinitionShort);
         GxWebStd.gx_hidden_field( context, "Z65WWPNotificationDefinitionLongD", Z65WWPNotificationDefinitionLongD);
         GxWebStd.gx_hidden_field( context, "Z66WWPNotificationDefinitionLink", Z66WWPNotificationDefinitionLink);
         GxWebStd.gx_hidden_field( context, "Z67WWPNotificationDefinitionSecFu", Z67WWPNotificationDefinitionSecFu);
         GxWebStd.gx_hidden_field( context, "Z20WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_notificationdefinition.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_NotificationDefinition" ;
      }

      public override string GetPgmdesc( )
      {
         return "Notification Definition" ;
      }

      protected void InitializeNonKey088( )
      {
         A68WWPNotificationDefinitionIsAut = false;
         AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
         A59WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
         A30WWPNotificationDefinitionAppli = 0;
         AssignAttri("", false, "A30WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0));
         A31WWPNotificationDefinitionAllow = false;
         AssignAttri("", false, "A31WWPNotificationDefinitionAllow", A31WWPNotificationDefinitionAllow);
         A29WWPNotificationDefinitionDescr = "";
         AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
         A62WWPNotificationDefinitionIcon = "";
         AssignAttri("", false, "A62WWPNotificationDefinitionIcon", A62WWPNotificationDefinitionIcon);
         A63WWPNotificationDefinitionTitle = "";
         AssignAttri("", false, "A63WWPNotificationDefinitionTitle", A63WWPNotificationDefinitionTitle);
         A64WWPNotificationDefinitionShort = "";
         AssignAttri("", false, "A64WWPNotificationDefinitionShort", A64WWPNotificationDefinitionShort);
         A65WWPNotificationDefinitionLongD = "";
         AssignAttri("", false, "A65WWPNotificationDefinitionLongD", A65WWPNotificationDefinitionLongD);
         A66WWPNotificationDefinitionLink = "";
         AssignAttri("", false, "A66WWPNotificationDefinitionLink", A66WWPNotificationDefinitionLink);
         A20WWPEntityId = 0;
         AssignAttri("", false, "A20WWPEntityId", StringUtil.LTrimStr( (decimal)(A20WWPEntityId), 10, 0));
         A21WWPEntityName = "";
         AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
         A67WWPNotificationDefinitionSecFu = "";
         AssignAttri("", false, "A67WWPNotificationDefinitionSecFu", A67WWPNotificationDefinitionSecFu);
         Z59WWPNotificationDefinitionName = "";
         Z30WWPNotificationDefinitionAppli = 0;
         Z31WWPNotificationDefinitionAllow = false;
         Z29WWPNotificationDefinitionDescr = "";
         Z62WWPNotificationDefinitionIcon = "";
         Z63WWPNotificationDefinitionTitle = "";
         Z64WWPNotificationDefinitionShort = "";
         Z65WWPNotificationDefinitionLongD = "";
         Z66WWPNotificationDefinitionLink = "";
         Z67WWPNotificationDefinitionSecFu = "";
         Z20WWPEntityId = 0;
      }

      protected void InitAll088( )
      {
         A23WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A23WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A23WWPNotificationDefinitionId), 10, 0));
         InitializeNonKey088( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267482227", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_notificationdefinition.js", "?20256267482228", false, true);
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
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         cmbWWPNotificationDefinitionAppli_Internalname = "WWPNOTIFICATIONDEFINITIONAPPLI";
         chkWWPNotificationDefinitionAllow_Internalname = "WWPNOTIFICATIONDEFINITIONALLOW";
         edtWWPNotificationDefinitionDescr_Internalname = "WWPNOTIFICATIONDEFINITIONDESCR";
         edtWWPNotificationDefinitionIcon_Internalname = "WWPNOTIFICATIONDEFINITIONICON";
         edtWWPNotificationDefinitionTitle_Internalname = "WWPNOTIFICATIONDEFINITIONTITLE";
         edtWWPNotificationDefinitionShort_Internalname = "WWPNOTIFICATIONDEFINITIONSHORT";
         edtWWPNotificationDefinitionLongD_Internalname = "WWPNOTIFICATIONDEFINITIONLONGD";
         edtWWPNotificationDefinitionLink_Internalname = "WWPNOTIFICATIONDEFINITIONLINK";
         edtWWPEntityId_Internalname = "WWPENTITYID";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPNotificationDefinitionSecFu_Internalname = "WWPNOTIFICATIONDEFINITIONSECFU";
         chkWWPNotificationDefinitionIsAut_Internalname = "WWPNOTIFICATIONDEFINITIONISAUT";
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
         Form.Caption = "Notification Definition";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPNotificationDefinitionIsAut.Enabled = 0;
         edtWWPNotificationDefinitionSecFu_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPEntityId_Jsonclick = "";
         edtWWPEntityId_Enabled = 1;
         edtWWPNotificationDefinitionLink_Jsonclick = "";
         edtWWPNotificationDefinitionLink_Enabled = 1;
         edtWWPNotificationDefinitionLongD_Enabled = 1;
         edtWWPNotificationDefinitionShort_Enabled = 1;
         edtWWPNotificationDefinitionTitle_Enabled = 1;
         edtWWPNotificationDefinitionIcon_Jsonclick = "";
         edtWWPNotificationDefinitionIcon_Enabled = 1;
         edtWWPNotificationDefinitionDescr_Enabled = 1;
         chkWWPNotificationDefinitionAllow.Enabled = 1;
         cmbWWPNotificationDefinitionAppli_Jsonclick = "";
         cmbWWPNotificationDefinitionAppli.Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 1;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
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

      protected void GX3ASAWWPNOTIFICATIONDEFINITIONISAUT088( string A67WWPNotificationDefinitionSecFu )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A67WWPNotificationDefinitionSecFu)) )
         {
            A68WWPNotificationDefinitionIsAut = true;
            AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
         }
         else
         {
            GXt_boolean1 = A68WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A67WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A68WWPNotificationDefinitionIsAut = GXt_boolean1;
            AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A68WWPNotificationDefinitionIsAut))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbWWPNotificationDefinitionAppli.Name = "WWPNOTIFICATIONDEFINITIONAPPLI";
         cmbWWPNotificationDefinitionAppli.WebTags = "";
         cmbWWPNotificationDefinitionAppli.addItem("1", "Any record", 0);
         cmbWWPNotificationDefinitionAppli.addItem("2", "Specific record", 0);
         if ( cmbWWPNotificationDefinitionAppli.ItemCount > 0 )
         {
            A30WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A30WWPNotificationDefinitionAppli", StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0));
         }
         chkWWPNotificationDefinitionAllow.Name = "WWPNOTIFICATIONDEFINITIONALLOW";
         chkWWPNotificationDefinitionAllow.WebTags = "";
         chkWWPNotificationDefinitionAllow.Caption = "Allow User Subscription";
         AssignProp("", false, chkWWPNotificationDefinitionAllow_Internalname, "TitleCaption", chkWWPNotificationDefinitionAllow.Caption, true);
         chkWWPNotificationDefinitionAllow.CheckedValue = "false";
         A31WWPNotificationDefinitionAllow = StringUtil.StrToBool( StringUtil.BoolToStr( A31WWPNotificationDefinitionAllow));
         AssignAttri("", false, "A31WWPNotificationDefinitionAllow", A31WWPNotificationDefinitionAllow);
         chkWWPNotificationDefinitionIsAut.Name = "WWPNOTIFICATIONDEFINITIONISAUT";
         chkWWPNotificationDefinitionIsAut.WebTags = "";
         chkWWPNotificationDefinitionIsAut.Caption = "User Authorized";
         AssignProp("", false, chkWWPNotificationDefinitionIsAut_Internalname, "TitleCaption", chkWWPNotificationDefinitionIsAut.Caption, true);
         chkWWPNotificationDefinitionIsAut.CheckedValue = "false";
         A68WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A68WWPNotificationDefinitionIsAut));
         AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPNotificationDefinitionName_Internalname;
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

      public void Valid_Wwpnotificationdefinitionid( )
      {
         A30WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPNotificationDefinitionAppli.ItemCount > 0 )
         {
            A30WWPNotificationDefinitionAppli = (short)(Math.Round(NumberUtil.Val( cmbWWPNotificationDefinitionAppli.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0));
         }
         A31WWPNotificationDefinitionAllow = StringUtil.StrToBool( StringUtil.BoolToStr( A31WWPNotificationDefinitionAllow));
         A68WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A68WWPNotificationDefinitionIsAut));
         /*  Sending validation outputs */
         AssignAttri("", false, "A59WWPNotificationDefinitionName", A59WWPNotificationDefinitionName);
         AssignAttri("", false, "A30WWPNotificationDefinitionAppli", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0, ".", "")));
         cmbWWPNotificationDefinitionAppli.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A30WWPNotificationDefinitionAppli), 1, 0));
         AssignProp("", false, cmbWWPNotificationDefinitionAppli_Internalname, "Values", cmbWWPNotificationDefinitionAppli.ToJavascriptSource(), true);
         AssignAttri("", false, "A31WWPNotificationDefinitionAllow", A31WWPNotificationDefinitionAllow);
         AssignAttri("", false, "A29WWPNotificationDefinitionDescr", A29WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A62WWPNotificationDefinitionIcon", A62WWPNotificationDefinitionIcon);
         AssignAttri("", false, "A63WWPNotificationDefinitionTitle", A63WWPNotificationDefinitionTitle);
         AssignAttri("", false, "A64WWPNotificationDefinitionShort", A64WWPNotificationDefinitionShort);
         AssignAttri("", false, "A65WWPNotificationDefinitionLongD", A65WWPNotificationDefinitionLongD);
         AssignAttri("", false, "A66WWPNotificationDefinitionLink", A66WWPNotificationDefinitionLink);
         AssignAttri("", false, "A20WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A67WWPNotificationDefinitionSecFu", A67WWPNotificationDefinitionSecFu);
         AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
         AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z23WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z59WWPNotificationDefinitionName", Z59WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z30WWPNotificationDefinitionAppli", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30WWPNotificationDefinitionAppli), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z31WWPNotificationDefinitionAllow", StringUtil.BoolToStr( Z31WWPNotificationDefinitionAllow));
         GxWebStd.gx_hidden_field( context, "Z29WWPNotificationDefinitionDescr", Z29WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, "Z62WWPNotificationDefinitionIcon", Z62WWPNotificationDefinitionIcon);
         GxWebStd.gx_hidden_field( context, "Z63WWPNotificationDefinitionTitle", Z63WWPNotificationDefinitionTitle);
         GxWebStd.gx_hidden_field( context, "Z64WWPNotificationDefinitionShort", Z64WWPNotificationDefinitionShort);
         GxWebStd.gx_hidden_field( context, "Z65WWPNotificationDefinitionLongD", Z65WWPNotificationDefinitionLongD);
         GxWebStd.gx_hidden_field( context, "Z66WWPNotificationDefinitionLink", Z66WWPNotificationDefinitionLink);
         GxWebStd.gx_hidden_field( context, "Z20WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z67WWPNotificationDefinitionSecFu", Z67WWPNotificationDefinitionSecFu);
         GxWebStd.gx_hidden_field( context, "Z21WWPEntityName", Z21WWPEntityName);
         GxWebStd.gx_hidden_field( context, "Z68WWPNotificationDefinitionIsAut", StringUtil.BoolToStr( Z68WWPNotificationDefinitionIsAut));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpentityid( )
      {
         /* Using cursor T000814 */
         pr_default.execute(12, new Object[] {A20WWPEntityId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
         }
         A21WWPEntityName = T000814_A21WWPEntityName[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A21WWPEntityName", A21WWPEntityName);
      }

      public void Valid_Wwpnotificationdefinitionsecfu( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A67WWPNotificationDefinitionSecFu)) )
         {
            A68WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            GXt_boolean1 = A68WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A67WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A68WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
         dynload_actions( ) ;
         A68WWPNotificationDefinitionIsAut = StringUtil.StrToBool( StringUtil.BoolToStr( A68WWPNotificationDefinitionIsAut));
         /*  Sending validation outputs */
         AssignAttri("", false, "A68WWPNotificationDefinitionIsAut", A68WWPNotificationDefinitionIsAut);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","""{"handler":"Valid_Wwpnotificationdefinitionid","iparms":[{"av":"cmbWWPNotificationDefinitionAppli"},{"av":"A30WWPNotificationDefinitionAppli","fld":"WWPNOTIFICATIONDEFINITIONAPPLI","pic":"9"},{"av":"A23WWPNotificationDefinitionId","fld":"WWPNOTIFICATIONDEFINITIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",""","oparms":[{"av":"A59WWPNotificationDefinitionName","fld":"WWPNOTIFICATIONDEFINITIONNAME"},{"av":"cmbWWPNotificationDefinitionAppli"},{"av":"A30WWPNotificationDefinitionAppli","fld":"WWPNOTIFICATIONDEFINITIONAPPLI","pic":"9"},{"av":"A29WWPNotificationDefinitionDescr","fld":"WWPNOTIFICATIONDEFINITIONDESCR"},{"av":"A62WWPNotificationDefinitionIcon","fld":"WWPNOTIFICATIONDEFINITIONICON"},{"av":"A63WWPNotificationDefinitionTitle","fld":"WWPNOTIFICATIONDEFINITIONTITLE"},{"av":"A64WWPNotificationDefinitionShort","fld":"WWPNOTIFICATIONDEFINITIONSHORT"},{"av":"A65WWPNotificationDefinitionLongD","fld":"WWPNOTIFICATIONDEFINITIONLONGD"},{"av":"A66WWPNotificationDefinitionLink","fld":"WWPNOTIFICATIONDEFINITIONLINK"},{"av":"A20WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A67WWPNotificationDefinitionSecFu","fld":"WWPNOTIFICATIONDEFINITIONSECFU"},{"av":"A21WWPEntityName","fld":"WWPENTITYNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z23WWPNotificationDefinitionId"},{"av":"Z59WWPNotificationDefinitionName"},{"av":"Z30WWPNotificationDefinitionAppli"},{"av":"Z31WWPNotificationDefinitionAllow"},{"av":"Z29WWPNotificationDefinitionDescr"},{"av":"Z62WWPNotificationDefinitionIcon"},{"av":"Z63WWPNotificationDefinitionTitle"},{"av":"Z64WWPNotificationDefinitionShort"},{"av":"Z65WWPNotificationDefinitionLongD"},{"av":"Z66WWPNotificationDefinitionLink"},{"av":"Z20WWPEntityId"},{"av":"Z67WWPNotificationDefinitionSecFu"},{"av":"Z21WWPEntityName"},{"av":"Z68WWPNotificationDefinitionIsAut"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONAPPLI","""{"handler":"Valid_Wwpnotificationdefinitionappli","iparms":[{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONAPPLI",""","oparms":[{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONLINK","""{"handler":"Valid_Wwpnotificationdefinitionlink","iparms":[{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONLINK",""","oparms":[{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("VALID_WWPENTITYID","""{"handler":"Valid_Wwpentityid","iparms":[{"av":"A20WWPEntityId","fld":"WWPENTITYID","pic":"ZZZZZZZZZ9"},{"av":"A21WWPEntityName","fld":"WWPENTITYNAME"},{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("VALID_WWPENTITYID",""","oparms":[{"av":"A21WWPEntityName","fld":"WWPENTITYNAME"},{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONSECFU","""{"handler":"Valid_Wwpnotificationdefinitionsecfu","iparms":[{"av":"A67WWPNotificationDefinitionSecFu","fld":"WWPNOTIFICATIONDEFINITIONSECFU"},{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]""");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONSECFU",""","oparms":[{"av":"A31WWPNotificationDefinitionAllow","fld":"WWPNOTIFICATIONDEFINITIONALLOW"},{"av":"A68WWPNotificationDefinitionIsAut","fld":"WWPNOTIFICATIONDEFINITIONISAUT"}]}""");
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
         Z59WWPNotificationDefinitionName = "";
         Z29WWPNotificationDefinitionDescr = "";
         Z62WWPNotificationDefinitionIcon = "";
         Z63WWPNotificationDefinitionTitle = "";
         Z64WWPNotificationDefinitionShort = "";
         Z65WWPNotificationDefinitionLongD = "";
         Z66WWPNotificationDefinitionLink = "";
         Z67WWPNotificationDefinitionSecFu = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A67WWPNotificationDefinitionSecFu = "";
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
         A29WWPNotificationDefinitionDescr = "";
         A62WWPNotificationDefinitionIcon = "";
         A63WWPNotificationDefinitionTitle = "";
         A64WWPNotificationDefinitionShort = "";
         A65WWPNotificationDefinitionLongD = "";
         A66WWPNotificationDefinitionLink = "";
         A21WWPEntityName = "";
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
         Z21WWPEntityName = "";
         T00085_A23WWPNotificationDefinitionId = new long[1] ;
         T00085_A59WWPNotificationDefinitionName = new string[] {""} ;
         T00085_A30WWPNotificationDefinitionAppli = new short[1] ;
         T00085_A31WWPNotificationDefinitionAllow = new bool[] {false} ;
         T00085_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         T00085_A62WWPNotificationDefinitionIcon = new string[] {""} ;
         T00085_A63WWPNotificationDefinitionTitle = new string[] {""} ;
         T00085_A64WWPNotificationDefinitionShort = new string[] {""} ;
         T00085_A65WWPNotificationDefinitionLongD = new string[] {""} ;
         T00085_A66WWPNotificationDefinitionLink = new string[] {""} ;
         T00085_A21WWPEntityName = new string[] {""} ;
         T00085_A67WWPNotificationDefinitionSecFu = new string[] {""} ;
         T00085_A20WWPEntityId = new long[1] ;
         T00084_A21WWPEntityName = new string[] {""} ;
         T00086_A21WWPEntityName = new string[] {""} ;
         T00087_A23WWPNotificationDefinitionId = new long[1] ;
         T00083_A23WWPNotificationDefinitionId = new long[1] ;
         T00083_A59WWPNotificationDefinitionName = new string[] {""} ;
         T00083_A30WWPNotificationDefinitionAppli = new short[1] ;
         T00083_A31WWPNotificationDefinitionAllow = new bool[] {false} ;
         T00083_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         T00083_A62WWPNotificationDefinitionIcon = new string[] {""} ;
         T00083_A63WWPNotificationDefinitionTitle = new string[] {""} ;
         T00083_A64WWPNotificationDefinitionShort = new string[] {""} ;
         T00083_A65WWPNotificationDefinitionLongD = new string[] {""} ;
         T00083_A66WWPNotificationDefinitionLink = new string[] {""} ;
         T00083_A67WWPNotificationDefinitionSecFu = new string[] {""} ;
         T00083_A20WWPEntityId = new long[1] ;
         sMode8 = "";
         T00088_A23WWPNotificationDefinitionId = new long[1] ;
         T00089_A23WWPNotificationDefinitionId = new long[1] ;
         T00082_A23WWPNotificationDefinitionId = new long[1] ;
         T00082_A59WWPNotificationDefinitionName = new string[] {""} ;
         T00082_A30WWPNotificationDefinitionAppli = new short[1] ;
         T00082_A31WWPNotificationDefinitionAllow = new bool[] {false} ;
         T00082_A29WWPNotificationDefinitionDescr = new string[] {""} ;
         T00082_A62WWPNotificationDefinitionIcon = new string[] {""} ;
         T00082_A63WWPNotificationDefinitionTitle = new string[] {""} ;
         T00082_A64WWPNotificationDefinitionShort = new string[] {""} ;
         T00082_A65WWPNotificationDefinitionLongD = new string[] {""} ;
         T00082_A66WWPNotificationDefinitionLink = new string[] {""} ;
         T00082_A67WWPNotificationDefinitionSecFu = new string[] {""} ;
         T00082_A20WWPEntityId = new long[1] ;
         T000811_A23WWPNotificationDefinitionId = new long[1] ;
         T000814_A21WWPEntityName = new string[] {""} ;
         T000815_A22WWPNotificationId = new long[1] ;
         T000816_A25WWPSubscriptionId = new long[1] ;
         T000817_A23WWPNotificationDefinitionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ59WWPNotificationDefinitionName = "";
         ZZ29WWPNotificationDefinitionDescr = "";
         ZZ62WWPNotificationDefinitionIcon = "";
         ZZ63WWPNotificationDefinitionTitle = "";
         ZZ64WWPNotificationDefinitionShort = "";
         ZZ65WWPNotificationDefinitionLongD = "";
         ZZ66WWPNotificationDefinitionLink = "";
         ZZ67WWPNotificationDefinitionSecFu = "";
         ZZ21WWPEntityName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition__default(),
            new Object[][] {
                new Object[] {
               T00082_A23WWPNotificationDefinitionId, T00082_A59WWPNotificationDefinitionName, T00082_A30WWPNotificationDefinitionAppli, T00082_A31WWPNotificationDefinitionAllow, T00082_A29WWPNotificationDefinitionDescr, T00082_A62WWPNotificationDefinitionIcon, T00082_A63WWPNotificationDefinitionTitle, T00082_A64WWPNotificationDefinitionShort, T00082_A65WWPNotificationDefinitionLongD, T00082_A66WWPNotificationDefinitionLink,
               T00082_A67WWPNotificationDefinitionSecFu, T00082_A20WWPEntityId
               }
               , new Object[] {
               T00083_A23WWPNotificationDefinitionId, T00083_A59WWPNotificationDefinitionName, T00083_A30WWPNotificationDefinitionAppli, T00083_A31WWPNotificationDefinitionAllow, T00083_A29WWPNotificationDefinitionDescr, T00083_A62WWPNotificationDefinitionIcon, T00083_A63WWPNotificationDefinitionTitle, T00083_A64WWPNotificationDefinitionShort, T00083_A65WWPNotificationDefinitionLongD, T00083_A66WWPNotificationDefinitionLink,
               T00083_A67WWPNotificationDefinitionSecFu, T00083_A20WWPEntityId
               }
               , new Object[] {
               T00084_A21WWPEntityName
               }
               , new Object[] {
               T00085_A23WWPNotificationDefinitionId, T00085_A59WWPNotificationDefinitionName, T00085_A30WWPNotificationDefinitionAppli, T00085_A31WWPNotificationDefinitionAllow, T00085_A29WWPNotificationDefinitionDescr, T00085_A62WWPNotificationDefinitionIcon, T00085_A63WWPNotificationDefinitionTitle, T00085_A64WWPNotificationDefinitionShort, T00085_A65WWPNotificationDefinitionLongD, T00085_A66WWPNotificationDefinitionLink,
               T00085_A21WWPEntityName, T00085_A67WWPNotificationDefinitionSecFu, T00085_A20WWPEntityId
               }
               , new Object[] {
               T00086_A21WWPEntityName
               }
               , new Object[] {
               T00087_A23WWPNotificationDefinitionId
               }
               , new Object[] {
               T00088_A23WWPNotificationDefinitionId
               }
               , new Object[] {
               T00089_A23WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               T000811_A23WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000814_A21WWPEntityName
               }
               , new Object[] {
               T000815_A22WWPNotificationId
               }
               , new Object[] {
               T000816_A25WWPSubscriptionId
               }
               , new Object[] {
               T000817_A23WWPNotificationDefinitionId
               }
            }
         );
      }

      private short Z30WWPNotificationDefinitionAppli ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A30WWPNotificationDefinitionAppli ;
      private short RcdFound8 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ30WWPNotificationDefinitionAppli ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPNotificationDefinitionDescr_Enabled ;
      private int edtWWPNotificationDefinitionIcon_Enabled ;
      private int edtWWPNotificationDefinitionTitle_Enabled ;
      private int edtWWPNotificationDefinitionShort_Enabled ;
      private int edtWWPNotificationDefinitionLongD_Enabled ;
      private int edtWWPNotificationDefinitionLink_Enabled ;
      private int edtWWPEntityId_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPNotificationDefinitionSecFu_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z23WWPNotificationDefinitionId ;
      private long Z20WWPEntityId ;
      private long A20WWPEntityId ;
      private long A23WWPNotificationDefinitionId ;
      private long ZZ23WWPNotificationDefinitionId ;
      private long ZZ20WWPEntityId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string cmbWWPNotificationDefinitionAppli_Internalname ;
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
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string cmbWWPNotificationDefinitionAppli_Jsonclick ;
      private string chkWWPNotificationDefinitionAllow_Internalname ;
      private string edtWWPNotificationDefinitionDescr_Internalname ;
      private string edtWWPNotificationDefinitionIcon_Internalname ;
      private string edtWWPNotificationDefinitionIcon_Jsonclick ;
      private string edtWWPNotificationDefinitionTitle_Internalname ;
      private string edtWWPNotificationDefinitionShort_Internalname ;
      private string edtWWPNotificationDefinitionLongD_Internalname ;
      private string edtWWPNotificationDefinitionLink_Internalname ;
      private string edtWWPNotificationDefinitionLink_Jsonclick ;
      private string edtWWPEntityId_Internalname ;
      private string edtWWPEntityId_Jsonclick ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPNotificationDefinitionSecFu_Internalname ;
      private string chkWWPNotificationDefinitionIsAut_Internalname ;
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
      private string sMode8 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z31WWPNotificationDefinitionAllow ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A31WWPNotificationDefinitionAllow ;
      private bool A68WWPNotificationDefinitionIsAut ;
      private bool Gx_longc ;
      private bool Z68WWPNotificationDefinitionIsAut ;
      private bool ZZ31WWPNotificationDefinitionAllow ;
      private bool ZZ68WWPNotificationDefinitionIsAut ;
      private bool GXt_boolean1 ;
      private string Z59WWPNotificationDefinitionName ;
      private string Z29WWPNotificationDefinitionDescr ;
      private string Z62WWPNotificationDefinitionIcon ;
      private string Z63WWPNotificationDefinitionTitle ;
      private string Z64WWPNotificationDefinitionShort ;
      private string Z65WWPNotificationDefinitionLongD ;
      private string Z66WWPNotificationDefinitionLink ;
      private string Z67WWPNotificationDefinitionSecFu ;
      private string A67WWPNotificationDefinitionSecFu ;
      private string A59WWPNotificationDefinitionName ;
      private string A29WWPNotificationDefinitionDescr ;
      private string A62WWPNotificationDefinitionIcon ;
      private string A63WWPNotificationDefinitionTitle ;
      private string A64WWPNotificationDefinitionShort ;
      private string A65WWPNotificationDefinitionLongD ;
      private string A66WWPNotificationDefinitionLink ;
      private string A21WWPEntityName ;
      private string Z21WWPEntityName ;
      private string ZZ59WWPNotificationDefinitionName ;
      private string ZZ29WWPNotificationDefinitionDescr ;
      private string ZZ62WWPNotificationDefinitionIcon ;
      private string ZZ63WWPNotificationDefinitionTitle ;
      private string ZZ64WWPNotificationDefinitionShort ;
      private string ZZ65WWPNotificationDefinitionLongD ;
      private string ZZ66WWPNotificationDefinitionLink ;
      private string ZZ67WWPNotificationDefinitionSecFu ;
      private string ZZ21WWPEntityName ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPNotificationDefinitionAppli ;
      private GXCheckbox chkWWPNotificationDefinitionAllow ;
      private GXCheckbox chkWWPNotificationDefinitionIsAut ;
      private IDataStoreProvider pr_default ;
      private long[] T00085_A23WWPNotificationDefinitionId ;
      private string[] T00085_A59WWPNotificationDefinitionName ;
      private short[] T00085_A30WWPNotificationDefinitionAppli ;
      private bool[] T00085_A31WWPNotificationDefinitionAllow ;
      private string[] T00085_A29WWPNotificationDefinitionDescr ;
      private string[] T00085_A62WWPNotificationDefinitionIcon ;
      private string[] T00085_A63WWPNotificationDefinitionTitle ;
      private string[] T00085_A64WWPNotificationDefinitionShort ;
      private string[] T00085_A65WWPNotificationDefinitionLongD ;
      private string[] T00085_A66WWPNotificationDefinitionLink ;
      private string[] T00085_A21WWPEntityName ;
      private string[] T00085_A67WWPNotificationDefinitionSecFu ;
      private long[] T00085_A20WWPEntityId ;
      private string[] T00084_A21WWPEntityName ;
      private string[] T00086_A21WWPEntityName ;
      private long[] T00087_A23WWPNotificationDefinitionId ;
      private long[] T00083_A23WWPNotificationDefinitionId ;
      private string[] T00083_A59WWPNotificationDefinitionName ;
      private short[] T00083_A30WWPNotificationDefinitionAppli ;
      private bool[] T00083_A31WWPNotificationDefinitionAllow ;
      private string[] T00083_A29WWPNotificationDefinitionDescr ;
      private string[] T00083_A62WWPNotificationDefinitionIcon ;
      private string[] T00083_A63WWPNotificationDefinitionTitle ;
      private string[] T00083_A64WWPNotificationDefinitionShort ;
      private string[] T00083_A65WWPNotificationDefinitionLongD ;
      private string[] T00083_A66WWPNotificationDefinitionLink ;
      private string[] T00083_A67WWPNotificationDefinitionSecFu ;
      private long[] T00083_A20WWPEntityId ;
      private long[] T00088_A23WWPNotificationDefinitionId ;
      private long[] T00089_A23WWPNotificationDefinitionId ;
      private long[] T00082_A23WWPNotificationDefinitionId ;
      private string[] T00082_A59WWPNotificationDefinitionName ;
      private short[] T00082_A30WWPNotificationDefinitionAppli ;
      private bool[] T00082_A31WWPNotificationDefinitionAllow ;
      private string[] T00082_A29WWPNotificationDefinitionDescr ;
      private string[] T00082_A62WWPNotificationDefinitionIcon ;
      private string[] T00082_A63WWPNotificationDefinitionTitle ;
      private string[] T00082_A64WWPNotificationDefinitionShort ;
      private string[] T00082_A65WWPNotificationDefinitionLongD ;
      private string[] T00082_A66WWPNotificationDefinitionLink ;
      private string[] T00082_A67WWPNotificationDefinitionSecFu ;
      private long[] T00082_A20WWPEntityId ;
      private long[] T000811_A23WWPNotificationDefinitionId ;
      private string[] T000814_A21WWPEntityName ;
      private long[] T000815_A22WWPNotificationId ;
      private long[] T000816_A25WWPSubscriptionId ;
      private long[] T000817_A23WWPNotificationDefinitionId ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notificationdefinition__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notificationdefinition__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00082;
        prmT00082 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00083;
        prmT00083 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00084;
        prmT00084 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT00085;
        prmT00085 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00086;
        prmT00086 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT00087;
        prmT00087 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00088;
        prmT00088 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00089;
        prmT00089 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000810;
        prmT000810 = new Object[] {
        new ParDef("WWPNotificationDefinitionName",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
        new ParDef("WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionDescr",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionIcon",GXType.VarChar,40,0) ,
        new ParDef("WWPNotificationDefinitionTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionShort",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionLongD",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionSecFu",GXType.VarChar,200,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT000811;
        prmT000811 = new Object[] {
        };
        Object[] prmT000812;
        prmT000812 = new Object[] {
        new ParDef("WWPNotificationDefinitionName",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
        new ParDef("WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionDescr",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionIcon",GXType.VarChar,40,0) ,
        new ParDef("WWPNotificationDefinitionTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionShort",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionLongD",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionSecFu",GXType.VarChar,200,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000813;
        prmT000813 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000814;
        prmT000814 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT000815;
        prmT000815 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000816;
        prmT000816 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000817;
        prmT000817 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00082", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId  FOR UPDATE OF WWP_NotificationDefinition NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00083", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00084", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00085", "SELECT TM1.WWPNotificationDefinitionId, TM1.WWPNotificationDefinitionName, TM1.WWPNotificationDefinitionAppli, TM1.WWPNotificationDefinitionAllow, TM1.WWPNotificationDefinitionDescr, TM1.WWPNotificationDefinitionIcon, TM1.WWPNotificationDefinitionTitle, TM1.WWPNotificationDefinitionShort, TM1.WWPNotificationDefinitionLongD, TM1.WWPNotificationDefinitionLink, T2.WWPEntityName, TM1.WWPNotificationDefinitionSecFu, TM1.WWPEntityId FROM (WWP_NotificationDefinition TM1 INNER JOIN WWP_Entity T2 ON T2.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPNotificationDefinitionId = :WWPNotificationDefinitionId ORDER BY TM1.WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00086", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00087", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00088", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE ( WWPNotificationDefinitionId > :WWPNotificationDefinitionId) ORDER BY WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00089", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE ( WWPNotificationDefinitionId < :WWPNotificationDefinitionId) ORDER BY WWPNotificationDefinitionId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000810", "SAVEPOINT gxupdate;INSERT INTO WWP_NotificationDefinition(WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId) VALUES(:WWPNotificationDefinitionName, :WWPNotificationDefinitionAppli, :WWPNotificationDefinitionAllow, :WWPNotificationDefinitionDescr, :WWPNotificationDefinitionIcon, :WWPNotificationDefinitionTitle, :WWPNotificationDefinitionShort, :WWPNotificationDefinitionLongD, :WWPNotificationDefinitionLink, :WWPNotificationDefinitionSecFu, :WWPEntityId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000810)
           ,new CursorDef("T000811", "SELECT currval('WWPNotificationDefinitionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000812", "SAVEPOINT gxupdate;UPDATE WWP_NotificationDefinition SET WWPNotificationDefinitionName=:WWPNotificationDefinitionName, WWPNotificationDefinitionAppli=:WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow=:WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr=:WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon=:WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle=:WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort=:WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD=:WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink=:WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu=:WWPNotificationDefinitionSecFu, WWPEntityId=:WWPEntityId  WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000812)
           ,new CursorDef("T000813", "SAVEPOINT gxupdate;DELETE FROM WWP_NotificationDefinition  WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000813)
           ,new CursorDef("T000814", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000814,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000815", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000816", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000817", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition ORDER BY WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
