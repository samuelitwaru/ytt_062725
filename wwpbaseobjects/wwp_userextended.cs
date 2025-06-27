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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_userextended : GXDataArea
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
         Form.Meta.addItem("description", "Extended User from GAMUser", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_userextended( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_userextended( IGxContext context )
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
         chkWWPUserExtendedSMSNotif = new GXCheckbox();
         chkWWPUserExtendedMobileNotif = new GXCheckbox();
         chkWWPUserExtendedDesktopNotif = new GXCheckbox();
         chkWWPUserExtendedDeleted = new GXCheckbox();
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
            return "wwpuserextended_Execute" ;
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
         A12WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A12WWPUserExtendedSMSNotif));
         AssignAttri("", false, "A12WWPUserExtendedSMSNotif", A12WWPUserExtendedSMSNotif);
         A13WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A13WWPUserExtendedMobileNotif));
         AssignAttri("", false, "A13WWPUserExtendedMobileNotif", A13WWPUserExtendedMobileNotif);
         A14WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A14WWPUserExtendedDesktopNotif));
         AssignAttri("", false, "A14WWPUserExtendedDesktopNotif", A14WWPUserExtendedDesktopNotif);
         A17WWPUserExtendedDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A17WWPUserExtendedDeleted));
         AssignAttri("", false, "A17WWPUserExtendedDeleted", A17WWPUserExtendedDeleted);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Extended User from GAMUser", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/WWP_UserExtended.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/WWP_UserExtended.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A7WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A7WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgWWPUserExtendedPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A10WWPUserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A10WWPUserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000WWPUserExtendedPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A10WWPUserExtendedPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A10WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A10WWPUserExtendedPhoto));
         GxWebStd.gx_bitmap( context, imgWWPUserExtendedPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgWWPUserExtendedPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", "", "", 0, A10WWPUserExtendedPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A10WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A10WWPUserExtendedPhoto)), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A10WWPUserExtendedPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedName_Internalname, "Extended Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedName_Internalname, A16WWPUserExtendedName, StringUtil.RTrim( context.localUtil.Format( A16WWPUserExtendedName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
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
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, "Full Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A8WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A8WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedPhone_Internalname, "Phone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A15WWPUserExtendedPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedPhone_Internalname, StringUtil.RTrim( A15WWPUserExtendedPhone), StringUtil.RTrim( context.localUtil.Format( A15WWPUserExtendedPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtWWPUserExtendedPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedEmail_Internalname, A9WWPUserExtendedEmail, StringUtil.RTrim( context.localUtil.Format( A9WWPUserExtendedEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A9WWPUserExtendedEmail, "", "", "", edtWWPUserExtendedEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedEmaiNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedEmaiNotif_Internalname, "Email Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedEmaiNotif_Internalname, StringUtil.BoolToStr( A11WWPUserExtendedEmaiNotif), StringUtil.BoolToStr( A11WWPUserExtendedEmaiNotif), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedEmaiNotif_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedEmaiNotif_Enabled, 0, "text", "", 100, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedSMSNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedSMSNotif_Internalname, "SMS Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedSMSNotif_Internalname, StringUtil.BoolToStr( A12WWPUserExtendedSMSNotif), "", "SMS Notifications", 1, chkWWPUserExtendedSMSNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedMobileNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedMobileNotif_Internalname, "Mobile Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedMobileNotif_Internalname, StringUtil.BoolToStr( A13WWPUserExtendedMobileNotif), "", "Mobile Notifications", 1, chkWWPUserExtendedMobileNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedDesktopNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedDesktopNotif_Internalname, "Destkop Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedDesktopNotif_Internalname, StringUtil.BoolToStr( A14WWPUserExtendedDesktopNotif), "", "Destkop Notifications", 1, chkWWPUserExtendedDesktopNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedDeleted_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedDeleted_Internalname, "Extended Deleted", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedDeleted_Internalname, StringUtil.BoolToStr( A17WWPUserExtendedDeleted), "", "Extended Deleted", 1, chkWWPUserExtendedDeleted.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedDeletedIn_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedDeletedIn_Internalname, "Deleted In", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPUserExtendedDeletedIn_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedDeletedIn_Internalname, context.localUtil.TToC( A18WWPUserExtendedDeletedIn, 10, 8, 1, 3, "/", ":", " "), context.localUtil.Format( A18WWPUserExtendedDeletedIn, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,12,'eng',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedDeletedIn_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedDeletedIn_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_bitmap( context, edtWWPUserExtendedDeletedIn_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPUserExtendedDeletedIn_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/WWP_UserExtended.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/WWP_UserExtended.htm");
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
            Z7WWPUserExtendedId = cgiGet( "Z7WWPUserExtendedId");
            Z16WWPUserExtendedName = cgiGet( "Z16WWPUserExtendedName");
            Z8WWPUserExtendedFullName = cgiGet( "Z8WWPUserExtendedFullName");
            Z15WWPUserExtendedPhone = cgiGet( "Z15WWPUserExtendedPhone");
            Z9WWPUserExtendedEmail = cgiGet( "Z9WWPUserExtendedEmail");
            Z11WWPUserExtendedEmaiNotif = StringUtil.StrToBool( cgiGet( "Z11WWPUserExtendedEmaiNotif"));
            Z12WWPUserExtendedSMSNotif = StringUtil.StrToBool( cgiGet( "Z12WWPUserExtendedSMSNotif"));
            Z13WWPUserExtendedMobileNotif = StringUtil.StrToBool( cgiGet( "Z13WWPUserExtendedMobileNotif"));
            Z14WWPUserExtendedDesktopNotif = StringUtil.StrToBool( cgiGet( "Z14WWPUserExtendedDesktopNotif"));
            Z17WWPUserExtendedDeleted = StringUtil.StrToBool( cgiGet( "Z17WWPUserExtendedDeleted"));
            Z18WWPUserExtendedDeletedIn = context.localUtil.CToT( cgiGet( "Z18WWPUserExtendedDeletedIn"), 0);
            n18WWPUserExtendedDeletedIn = ((DateTime.MinValue==A18WWPUserExtendedDeletedIn) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A40000WWPUserExtendedPhoto_GXI = cgiGet( "WWPUSEREXTENDEDPHOTO_GXI");
            /* Read variables values. */
            A7WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n7WWPUserExtendedId = false;
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            A10WWPUserExtendedPhoto = cgiGet( imgWWPUserExtendedPhoto_Internalname);
            AssignAttri("", false, "A10WWPUserExtendedPhoto", A10WWPUserExtendedPhoto);
            A16WWPUserExtendedName = cgiGet( edtWWPUserExtendedName_Internalname);
            AssignAttri("", false, "A16WWPUserExtendedName", A16WWPUserExtendedName);
            A8WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
            A15WWPUserExtendedPhone = cgiGet( edtWWPUserExtendedPhone_Internalname);
            AssignAttri("", false, "A15WWPUserExtendedPhone", A15WWPUserExtendedPhone);
            A9WWPUserExtendedEmail = cgiGet( edtWWPUserExtendedEmail_Internalname);
            AssignAttri("", false, "A9WWPUserExtendedEmail", A9WWPUserExtendedEmail);
            A11WWPUserExtendedEmaiNotif = StringUtil.StrToBool( cgiGet( edtWWPUserExtendedEmaiNotif_Internalname));
            AssignAttri("", false, "A11WWPUserExtendedEmaiNotif", A11WWPUserExtendedEmaiNotif);
            A12WWPUserExtendedSMSNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedSMSNotif_Internalname));
            AssignAttri("", false, "A12WWPUserExtendedSMSNotif", A12WWPUserExtendedSMSNotif);
            A13WWPUserExtendedMobileNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedMobileNotif_Internalname));
            AssignAttri("", false, "A13WWPUserExtendedMobileNotif", A13WWPUserExtendedMobileNotif);
            A14WWPUserExtendedDesktopNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedDesktopNotif_Internalname));
            AssignAttri("", false, "A14WWPUserExtendedDesktopNotif", A14WWPUserExtendedDesktopNotif);
            A17WWPUserExtendedDeleted = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedDeleted_Internalname));
            AssignAttri("", false, "A17WWPUserExtendedDeleted", A17WWPUserExtendedDeleted);
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPUserExtendedDeletedIn_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"WWPUser Extended Deleted In"}), 1, "WWPUSEREXTENDEDDELETEDIN");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedDeletedIn_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A18WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
               n18WWPUserExtendedDeletedIn = false;
               AssignAttri("", false, "A18WWPUserExtendedDeletedIn", context.localUtil.TToC( A18WWPUserExtendedDeletedIn, 8, 5, 1, 3, "/", ":", " "));
            }
            else
            {
               A18WWPUserExtendedDeletedIn = context.localUtil.CToT( cgiGet( edtWWPUserExtendedDeletedIn_Internalname));
               n18WWPUserExtendedDeletedIn = false;
               AssignAttri("", false, "A18WWPUserExtendedDeletedIn", context.localUtil.TToC( A18WWPUserExtendedDeletedIn, 8, 5, 1, 3, "/", ":", " "));
            }
            n18WWPUserExtendedDeletedIn = ((DateTime.MinValue==A18WWPUserExtendedDeletedIn) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgWWPUserExtendedPhoto_Internalname, ref  A10WWPUserExtendedPhoto, ref  A40000WWPUserExtendedPhoto_GXI);
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
               A7WWPUserExtendedId = GetPar( "WWPUserExtendedId");
               n7WWPUserExtendedId = false;
               AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
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
               InitAll011( ) ;
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
         DisableAttributes011( ) ;
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

      protected void ResetCaption010( )
      {
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z16WWPUserExtendedName = T00013_A16WWPUserExtendedName[0];
               Z8WWPUserExtendedFullName = T00013_A8WWPUserExtendedFullName[0];
               Z15WWPUserExtendedPhone = T00013_A15WWPUserExtendedPhone[0];
               Z9WWPUserExtendedEmail = T00013_A9WWPUserExtendedEmail[0];
               Z11WWPUserExtendedEmaiNotif = T00013_A11WWPUserExtendedEmaiNotif[0];
               Z12WWPUserExtendedSMSNotif = T00013_A12WWPUserExtendedSMSNotif[0];
               Z13WWPUserExtendedMobileNotif = T00013_A13WWPUserExtendedMobileNotif[0];
               Z14WWPUserExtendedDesktopNotif = T00013_A14WWPUserExtendedDesktopNotif[0];
               Z17WWPUserExtendedDeleted = T00013_A17WWPUserExtendedDeleted[0];
               Z18WWPUserExtendedDeletedIn = T00013_A18WWPUserExtendedDeletedIn[0];
            }
            else
            {
               Z16WWPUserExtendedName = A16WWPUserExtendedName;
               Z8WWPUserExtendedFullName = A8WWPUserExtendedFullName;
               Z15WWPUserExtendedPhone = A15WWPUserExtendedPhone;
               Z9WWPUserExtendedEmail = A9WWPUserExtendedEmail;
               Z11WWPUserExtendedEmaiNotif = A11WWPUserExtendedEmaiNotif;
               Z12WWPUserExtendedSMSNotif = A12WWPUserExtendedSMSNotif;
               Z13WWPUserExtendedMobileNotif = A13WWPUserExtendedMobileNotif;
               Z14WWPUserExtendedDesktopNotif = A14WWPUserExtendedDesktopNotif;
               Z17WWPUserExtendedDeleted = A17WWPUserExtendedDeleted;
               Z18WWPUserExtendedDeletedIn = A18WWPUserExtendedDeletedIn;
            }
         }
         if ( GX_JID == -2 )
         {
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
            Z10WWPUserExtendedPhoto = A10WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z16WWPUserExtendedName = A16WWPUserExtendedName;
            Z8WWPUserExtendedFullName = A8WWPUserExtendedFullName;
            Z15WWPUserExtendedPhone = A15WWPUserExtendedPhone;
            Z9WWPUserExtendedEmail = A9WWPUserExtendedEmail;
            Z11WWPUserExtendedEmaiNotif = A11WWPUserExtendedEmaiNotif;
            Z12WWPUserExtendedSMSNotif = A12WWPUserExtendedSMSNotif;
            Z13WWPUserExtendedMobileNotif = A13WWPUserExtendedMobileNotif;
            Z14WWPUserExtendedDesktopNotif = A14WWPUserExtendedDesktopNotif;
            Z17WWPUserExtendedDeleted = A17WWPUserExtendedDeleted;
            Z18WWPUserExtendedDeletedIn = A18WWPUserExtendedDeletedIn;
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

      protected void Load011( )
      {
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A40000WWPUserExtendedPhoto_GXI = T00014_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A10WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A10WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A10WWPUserExtendedPhoto), true);
            A16WWPUserExtendedName = T00014_A16WWPUserExtendedName[0];
            AssignAttri("", false, "A16WWPUserExtendedName", A16WWPUserExtendedName);
            A8WWPUserExtendedFullName = T00014_A8WWPUserExtendedFullName[0];
            AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
            A15WWPUserExtendedPhone = T00014_A15WWPUserExtendedPhone[0];
            AssignAttri("", false, "A15WWPUserExtendedPhone", A15WWPUserExtendedPhone);
            A9WWPUserExtendedEmail = T00014_A9WWPUserExtendedEmail[0];
            AssignAttri("", false, "A9WWPUserExtendedEmail", A9WWPUserExtendedEmail);
            A11WWPUserExtendedEmaiNotif = T00014_A11WWPUserExtendedEmaiNotif[0];
            AssignAttri("", false, "A11WWPUserExtendedEmaiNotif", A11WWPUserExtendedEmaiNotif);
            A12WWPUserExtendedSMSNotif = T00014_A12WWPUserExtendedSMSNotif[0];
            AssignAttri("", false, "A12WWPUserExtendedSMSNotif", A12WWPUserExtendedSMSNotif);
            A13WWPUserExtendedMobileNotif = T00014_A13WWPUserExtendedMobileNotif[0];
            AssignAttri("", false, "A13WWPUserExtendedMobileNotif", A13WWPUserExtendedMobileNotif);
            A14WWPUserExtendedDesktopNotif = T00014_A14WWPUserExtendedDesktopNotif[0];
            AssignAttri("", false, "A14WWPUserExtendedDesktopNotif", A14WWPUserExtendedDesktopNotif);
            A17WWPUserExtendedDeleted = T00014_A17WWPUserExtendedDeleted[0];
            AssignAttri("", false, "A17WWPUserExtendedDeleted", A17WWPUserExtendedDeleted);
            A18WWPUserExtendedDeletedIn = T00014_A18WWPUserExtendedDeletedIn[0];
            n18WWPUserExtendedDeletedIn = T00014_n18WWPUserExtendedDeletedIn[0];
            AssignAttri("", false, "A18WWPUserExtendedDeletedIn", context.localUtil.TToC( A18WWPUserExtendedDeletedIn, 8, 5, 1, 3, "/", ":", " "));
            A10WWPUserExtendedPhoto = T00014_A10WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A10WWPUserExtendedPhoto", A10WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A10WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A10WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A10WWPUserExtendedPhoto), true);
            ZM011( -2) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A9WWPUserExtendedEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field User Email does not match the specified pattern", "OutOfRange", 1, "WWPUSEREXTENDEDEMAIL");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 2) ;
            RcdFound1 = 1;
            A7WWPUserExtendedId = T00013_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = T00013_n7WWPUserExtendedId[0];
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            A40000WWPUserExtendedPhoto_GXI = T00013_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A10WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A10WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A10WWPUserExtendedPhoto), true);
            A16WWPUserExtendedName = T00013_A16WWPUserExtendedName[0];
            AssignAttri("", false, "A16WWPUserExtendedName", A16WWPUserExtendedName);
            A8WWPUserExtendedFullName = T00013_A8WWPUserExtendedFullName[0];
            AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
            A15WWPUserExtendedPhone = T00013_A15WWPUserExtendedPhone[0];
            AssignAttri("", false, "A15WWPUserExtendedPhone", A15WWPUserExtendedPhone);
            A9WWPUserExtendedEmail = T00013_A9WWPUserExtendedEmail[0];
            AssignAttri("", false, "A9WWPUserExtendedEmail", A9WWPUserExtendedEmail);
            A11WWPUserExtendedEmaiNotif = T00013_A11WWPUserExtendedEmaiNotif[0];
            AssignAttri("", false, "A11WWPUserExtendedEmaiNotif", A11WWPUserExtendedEmaiNotif);
            A12WWPUserExtendedSMSNotif = T00013_A12WWPUserExtendedSMSNotif[0];
            AssignAttri("", false, "A12WWPUserExtendedSMSNotif", A12WWPUserExtendedSMSNotif);
            A13WWPUserExtendedMobileNotif = T00013_A13WWPUserExtendedMobileNotif[0];
            AssignAttri("", false, "A13WWPUserExtendedMobileNotif", A13WWPUserExtendedMobileNotif);
            A14WWPUserExtendedDesktopNotif = T00013_A14WWPUserExtendedDesktopNotif[0];
            AssignAttri("", false, "A14WWPUserExtendedDesktopNotif", A14WWPUserExtendedDesktopNotif);
            A17WWPUserExtendedDeleted = T00013_A17WWPUserExtendedDeleted[0];
            AssignAttri("", false, "A17WWPUserExtendedDeleted", A17WWPUserExtendedDeleted);
            A18WWPUserExtendedDeletedIn = T00013_A18WWPUserExtendedDeletedIn[0];
            n18WWPUserExtendedDeletedIn = T00013_n18WWPUserExtendedDeletedIn[0];
            AssignAttri("", false, "A18WWPUserExtendedDeletedIn", context.localUtil.TToC( A18WWPUserExtendedDeletedIn, 8, 5, 1, 3, "/", ":", " "));
            A10WWPUserExtendedPhoto = T00013_A10WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A10WWPUserExtendedPhoto", A10WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A10WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A10WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A10WWPUserExtendedPhoto), true);
            Z7WWPUserExtendedId = A7WWPUserExtendedId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         RcdFound1 = 0;
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00016_A7WWPUserExtendedId[0], A7WWPUserExtendedId) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00016_A7WWPUserExtendedId[0], A7WWPUserExtendedId) > 0 ) ) )
            {
               A7WWPUserExtendedId = T00016_A7WWPUserExtendedId[0];
               n7WWPUserExtendedId = T00016_n7WWPUserExtendedId[0];
               AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
               RcdFound1 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00017_A7WWPUserExtendedId[0], A7WWPUserExtendedId) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00017_A7WWPUserExtendedId[0], A7WWPUserExtendedId) < 0 ) ) )
            {
               A7WWPUserExtendedId = T00017_A7WWPUserExtendedId[0];
               n7WWPUserExtendedId = T00017_n7WWPUserExtendedId[0];
               AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
               RcdFound1 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( StringUtil.StrCmp(A7WWPUserExtendedId, Z7WWPUserExtendedId) != 0 )
               {
                  A7WWPUserExtendedId = Z7WWPUserExtendedId;
                  n7WWPUserExtendedId = false;
                  AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPUSEREXTENDEDID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A7WWPUserExtendedId, Z7WWPUserExtendedId) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPUSEREXTENDEDID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPUserExtendedId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPUserExtendedId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( StringUtil.StrCmp(A7WWPUserExtendedId, Z7WWPUserExtendedId) != 0 )
         {
            A7WWPUserExtendedId = Z7WWPUserExtendedId;
            n7WWPUserExtendedId = false;
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound1 != 0 )
            {
               ScanNext011( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z16WWPUserExtendedName, T00012_A16WWPUserExtendedName[0]) != 0 ) || ( StringUtil.StrCmp(Z8WWPUserExtendedFullName, T00012_A8WWPUserExtendedFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z15WWPUserExtendedPhone, T00012_A15WWPUserExtendedPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z9WWPUserExtendedEmail, T00012_A9WWPUserExtendedEmail[0]) != 0 ) || ( Z11WWPUserExtendedEmaiNotif != T00012_A11WWPUserExtendedEmaiNotif[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z12WWPUserExtendedSMSNotif != T00012_A12WWPUserExtendedSMSNotif[0] ) || ( Z13WWPUserExtendedMobileNotif != T00012_A13WWPUserExtendedMobileNotif[0] ) || ( Z14WWPUserExtendedDesktopNotif != T00012_A14WWPUserExtendedDesktopNotif[0] ) || ( Z17WWPUserExtendedDeleted != T00012_A17WWPUserExtendedDeleted[0] ) || ( Z18WWPUserExtendedDeletedIn != T00012_A18WWPUserExtendedDeletedIn[0] ) )
            {
               if ( StringUtil.StrCmp(Z16WWPUserExtendedName, T00012_A16WWPUserExtendedName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedName");
                  GXUtil.WriteLogRaw("Old: ",Z16WWPUserExtendedName);
                  GXUtil.WriteLogRaw("Current: ",T00012_A16WWPUserExtendedName[0]);
               }
               if ( StringUtil.StrCmp(Z8WWPUserExtendedFullName, T00012_A8WWPUserExtendedFullName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedFullName");
                  GXUtil.WriteLogRaw("Old: ",Z8WWPUserExtendedFullName);
                  GXUtil.WriteLogRaw("Current: ",T00012_A8WWPUserExtendedFullName[0]);
               }
               if ( StringUtil.StrCmp(Z15WWPUserExtendedPhone, T00012_A15WWPUserExtendedPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedPhone");
                  GXUtil.WriteLogRaw("Old: ",Z15WWPUserExtendedPhone);
                  GXUtil.WriteLogRaw("Current: ",T00012_A15WWPUserExtendedPhone[0]);
               }
               if ( StringUtil.StrCmp(Z9WWPUserExtendedEmail, T00012_A9WWPUserExtendedEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedEmail");
                  GXUtil.WriteLogRaw("Old: ",Z9WWPUserExtendedEmail);
                  GXUtil.WriteLogRaw("Current: ",T00012_A9WWPUserExtendedEmail[0]);
               }
               if ( Z11WWPUserExtendedEmaiNotif != T00012_A11WWPUserExtendedEmaiNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedEmaiNotif");
                  GXUtil.WriteLogRaw("Old: ",Z11WWPUserExtendedEmaiNotif);
                  GXUtil.WriteLogRaw("Current: ",T00012_A11WWPUserExtendedEmaiNotif[0]);
               }
               if ( Z12WWPUserExtendedSMSNotif != T00012_A12WWPUserExtendedSMSNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedSMSNotif");
                  GXUtil.WriteLogRaw("Old: ",Z12WWPUserExtendedSMSNotif);
                  GXUtil.WriteLogRaw("Current: ",T00012_A12WWPUserExtendedSMSNotif[0]);
               }
               if ( Z13WWPUserExtendedMobileNotif != T00012_A13WWPUserExtendedMobileNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedMobileNotif");
                  GXUtil.WriteLogRaw("Old: ",Z13WWPUserExtendedMobileNotif);
                  GXUtil.WriteLogRaw("Current: ",T00012_A13WWPUserExtendedMobileNotif[0]);
               }
               if ( Z14WWPUserExtendedDesktopNotif != T00012_A14WWPUserExtendedDesktopNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedDesktopNotif");
                  GXUtil.WriteLogRaw("Old: ",Z14WWPUserExtendedDesktopNotif);
                  GXUtil.WriteLogRaw("Current: ",T00012_A14WWPUserExtendedDesktopNotif[0]);
               }
               if ( Z17WWPUserExtendedDeleted != T00012_A17WWPUserExtendedDeleted[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedDeleted");
                  GXUtil.WriteLogRaw("Old: ",Z17WWPUserExtendedDeleted);
                  GXUtil.WriteLogRaw("Current: ",T00012_A17WWPUserExtendedDeleted[0]);
               }
               if ( Z18WWPUserExtendedDeletedIn != T00012_A18WWPUserExtendedDeletedIn[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedDeletedIn");
                  GXUtil.WriteLogRaw("Old: ",Z18WWPUserExtendedDeletedIn);
                  GXUtil.WriteLogRaw("Current: ",T00012_A18WWPUserExtendedDeletedIn[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_UserExtended"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         if ( ! IsAuthorized("wwpuserextended_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00018 */
                     pr_default.execute(6, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId, A10WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, A16WWPUserExtendedName, A8WWPUserExtendedFullName, A15WWPUserExtendedPhone, A9WWPUserExtendedEmail, A11WWPUserExtendedEmaiNotif, A12WWPUserExtendedSMSNotif, A13WWPUserExtendedMobileNotif, A14WWPUserExtendedDesktopNotif, A17WWPUserExtendedDeleted, n18WWPUserExtendedDeletedIn, A18WWPUserExtendedDeletedIn});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         if ( ! IsAuthorized("wwpuserextended_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00019 */
                     pr_default.execute(7, new Object[] {A16WWPUserExtendedName, A8WWPUserExtendedFullName, A15WWPUserExtendedPhone, A9WWPUserExtendedEmail, A11WWPUserExtendedEmaiNotif, A12WWPUserExtendedSMSNotif, A13WWPUserExtendedMobileNotif, A14WWPUserExtendedDesktopNotif, A17WWPUserExtendedDeleted, n18WWPUserExtendedDeletedIn, A18WWPUserExtendedDeletedIn, n7WWPUserExtendedId, A7WWPUserExtendedId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption010( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000110 */
            pr_default.execute(8, new Object[] {A10WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, n7WWPUserExtendedId, A7WWPUserExtendedId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpuserextended_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000111 */
                  pr_default.execute(9, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound1 == 0 )
                        {
                           InitAll011( ) ;
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
                        ResetCaption010( ) ;
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000112 */
            pr_default.execute(10, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000113 */
            pr_default.execute(11, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_WebClient"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000114 */
            pr_default.execute(12, new Object[] {n7WWPUserExtendedId, A7WWPUserExtendedId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Subscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.wwp_userextended",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.wwp_userextended",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Using cursor T000115 */
         pr_default.execute(13);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
            A7WWPUserExtendedId = T000115_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = T000115_n7WWPUserExtendedId[0];
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
            A7WWPUserExtendedId = T000115_A7WWPUserExtendedId[0];
            n7WWPUserExtendedId = T000115_n7WWPUserExtendedId[0];
            AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         imgWWPUserExtendedPhoto_Enabled = 0;
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgWWPUserExtendedPhoto_Enabled), 5, 0), true);
         edtWWPUserExtendedName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedName_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPUserExtendedPhone_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedPhone_Enabled), 5, 0), true);
         edtWWPUserExtendedEmail_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedEmail_Enabled), 5, 0), true);
         edtWWPUserExtendedEmaiNotif_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedEmaiNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedEmaiNotif_Enabled), 5, 0), true);
         chkWWPUserExtendedSMSNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedSMSNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedSMSNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedMobileNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedMobileNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedMobileNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedDesktopNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedDesktopNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedDesktopNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedDeleted.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedDeleted_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedDeleted.Enabled), 5, 0), true);
         edtWWPUserExtendedDeletedIn_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedDeletedIn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedDeletedIn_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_userextended.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z7WWPUserExtendedId", StringUtil.RTrim( Z7WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z16WWPUserExtendedName", Z16WWPUserExtendedName);
         GxWebStd.gx_hidden_field( context, "Z8WWPUserExtendedFullName", Z8WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "Z15WWPUserExtendedPhone", StringUtil.RTrim( Z15WWPUserExtendedPhone));
         GxWebStd.gx_hidden_field( context, "Z9WWPUserExtendedEmail", Z9WWPUserExtendedEmail);
         GxWebStd.gx_boolean_hidden_field( context, "Z11WWPUserExtendedEmaiNotif", Z11WWPUserExtendedEmaiNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z12WWPUserExtendedSMSNotif", Z12WWPUserExtendedSMSNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z13WWPUserExtendedMobileNotif", Z13WWPUserExtendedMobileNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z14WWPUserExtendedDesktopNotif", Z14WWPUserExtendedDesktopNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z17WWPUserExtendedDeleted", Z17WWPUserExtendedDeleted);
         GxWebStd.gx_hidden_field( context, "Z18WWPUserExtendedDeletedIn", context.localUtil.TToC( Z18WWPUserExtendedDeletedIn, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDPHOTO_GXI", A40000WWPUserExtendedPhoto_GXI);
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A10WWPUserExtendedPhoto);
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
         return formatLink("wwpbaseobjects.wwp_userextended.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WWP_UserExtended" ;
      }

      public override string GetPgmdesc( )
      {
         return "Extended User from GAMUser" ;
      }

      protected void InitializeNonKey011( )
      {
         A10WWPUserExtendedPhoto = "";
         AssignAttri("", false, "A10WWPUserExtendedPhoto", A10WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A10WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A10WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A10WWPUserExtendedPhoto), true);
         A40000WWPUserExtendedPhoto_GXI = "";
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A10WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A10WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A10WWPUserExtendedPhoto), true);
         A16WWPUserExtendedName = "";
         AssignAttri("", false, "A16WWPUserExtendedName", A16WWPUserExtendedName);
         A8WWPUserExtendedFullName = "";
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
         A15WWPUserExtendedPhone = "";
         AssignAttri("", false, "A15WWPUserExtendedPhone", A15WWPUserExtendedPhone);
         A9WWPUserExtendedEmail = "";
         AssignAttri("", false, "A9WWPUserExtendedEmail", A9WWPUserExtendedEmail);
         A11WWPUserExtendedEmaiNotif = false;
         AssignAttri("", false, "A11WWPUserExtendedEmaiNotif", A11WWPUserExtendedEmaiNotif);
         A12WWPUserExtendedSMSNotif = false;
         AssignAttri("", false, "A12WWPUserExtendedSMSNotif", A12WWPUserExtendedSMSNotif);
         A13WWPUserExtendedMobileNotif = false;
         AssignAttri("", false, "A13WWPUserExtendedMobileNotif", A13WWPUserExtendedMobileNotif);
         A14WWPUserExtendedDesktopNotif = false;
         AssignAttri("", false, "A14WWPUserExtendedDesktopNotif", A14WWPUserExtendedDesktopNotif);
         A17WWPUserExtendedDeleted = false;
         AssignAttri("", false, "A17WWPUserExtendedDeleted", A17WWPUserExtendedDeleted);
         A18WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         n18WWPUserExtendedDeletedIn = false;
         AssignAttri("", false, "A18WWPUserExtendedDeletedIn", context.localUtil.TToC( A18WWPUserExtendedDeletedIn, 8, 5, 1, 3, "/", ":", " "));
         n18WWPUserExtendedDeletedIn = ((DateTime.MinValue==A18WWPUserExtendedDeletedIn) ? true : false);
         Z16WWPUserExtendedName = "";
         Z8WWPUserExtendedFullName = "";
         Z15WWPUserExtendedPhone = "";
         Z9WWPUserExtendedEmail = "";
         Z11WWPUserExtendedEmaiNotif = false;
         Z12WWPUserExtendedSMSNotif = false;
         Z13WWPUserExtendedMobileNotif = false;
         Z14WWPUserExtendedDesktopNotif = false;
         Z17WWPUserExtendedDeleted = false;
         Z18WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll011( )
      {
         A7WWPUserExtendedId = "";
         n7WWPUserExtendedId = false;
         AssignAttri("", false, "A7WWPUserExtendedId", A7WWPUserExtendedId);
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267482097", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/wwp_userextended.js", "?20256267482097", false, true);
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
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         imgWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO";
         edtWWPUserExtendedName_Internalname = "WWPUSEREXTENDEDNAME";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPUserExtendedPhone_Internalname = "WWPUSEREXTENDEDPHONE";
         edtWWPUserExtendedEmail_Internalname = "WWPUSEREXTENDEDEMAIL";
         edtWWPUserExtendedEmaiNotif_Internalname = "WWPUSEREXTENDEDEMAINOTIF";
         chkWWPUserExtendedSMSNotif_Internalname = "WWPUSEREXTENDEDSMSNOTIF";
         chkWWPUserExtendedMobileNotif_Internalname = "WWPUSEREXTENDEDMOBILENOTIF";
         chkWWPUserExtendedDesktopNotif_Internalname = "WWPUSEREXTENDEDDESKTOPNOTIF";
         chkWWPUserExtendedDeleted_Internalname = "WWPUSEREXTENDEDDELETED";
         edtWWPUserExtendedDeletedIn_Internalname = "WWPUSEREXTENDEDDELETEDIN";
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
         Form.Caption = "Extended User from GAMUser";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPUserExtendedDeletedIn_Jsonclick = "";
         edtWWPUserExtendedDeletedIn_Enabled = 1;
         chkWWPUserExtendedDeleted.Enabled = 1;
         chkWWPUserExtendedDesktopNotif.Enabled = 1;
         chkWWPUserExtendedMobileNotif.Enabled = 1;
         chkWWPUserExtendedSMSNotif.Enabled = 1;
         edtWWPUserExtendedEmaiNotif_Jsonclick = "";
         edtWWPUserExtendedEmaiNotif_Enabled = 1;
         edtWWPUserExtendedEmail_Jsonclick = "";
         edtWWPUserExtendedEmail_Enabled = 1;
         edtWWPUserExtendedPhone_Jsonclick = "";
         edtWWPUserExtendedPhone_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 1;
         edtWWPUserExtendedName_Jsonclick = "";
         edtWWPUserExtendedName_Enabled = 1;
         imgWWPUserExtendedPhoto_Enabled = 1;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
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
         chkWWPUserExtendedSMSNotif.Name = "WWPUSEREXTENDEDSMSNOTIF";
         chkWWPUserExtendedSMSNotif.WebTags = "";
         chkWWPUserExtendedSMSNotif.Caption = "SMS Notifications";
         AssignProp("", false, chkWWPUserExtendedSMSNotif_Internalname, "TitleCaption", chkWWPUserExtendedSMSNotif.Caption, true);
         chkWWPUserExtendedSMSNotif.CheckedValue = "false";
         A12WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A12WWPUserExtendedSMSNotif));
         AssignAttri("", false, "A12WWPUserExtendedSMSNotif", A12WWPUserExtendedSMSNotif);
         chkWWPUserExtendedMobileNotif.Name = "WWPUSEREXTENDEDMOBILENOTIF";
         chkWWPUserExtendedMobileNotif.WebTags = "";
         chkWWPUserExtendedMobileNotif.Caption = "Mobile Notifications";
         AssignProp("", false, chkWWPUserExtendedMobileNotif_Internalname, "TitleCaption", chkWWPUserExtendedMobileNotif.Caption, true);
         chkWWPUserExtendedMobileNotif.CheckedValue = "false";
         A13WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A13WWPUserExtendedMobileNotif));
         AssignAttri("", false, "A13WWPUserExtendedMobileNotif", A13WWPUserExtendedMobileNotif);
         chkWWPUserExtendedDesktopNotif.Name = "WWPUSEREXTENDEDDESKTOPNOTIF";
         chkWWPUserExtendedDesktopNotif.WebTags = "";
         chkWWPUserExtendedDesktopNotif.Caption = "Destkop Notifications";
         AssignProp("", false, chkWWPUserExtendedDesktopNotif_Internalname, "TitleCaption", chkWWPUserExtendedDesktopNotif.Caption, true);
         chkWWPUserExtendedDesktopNotif.CheckedValue = "false";
         A14WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A14WWPUserExtendedDesktopNotif));
         AssignAttri("", false, "A14WWPUserExtendedDesktopNotif", A14WWPUserExtendedDesktopNotif);
         chkWWPUserExtendedDeleted.Name = "WWPUSEREXTENDEDDELETED";
         chkWWPUserExtendedDeleted.WebTags = "";
         chkWWPUserExtendedDeleted.Caption = "Extended Deleted";
         AssignProp("", false, chkWWPUserExtendedDeleted_Internalname, "TitleCaption", chkWWPUserExtendedDeleted.Caption, true);
         chkWWPUserExtendedDeleted.CheckedValue = "false";
         A17WWPUserExtendedDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A17WWPUserExtendedDeleted));
         AssignAttri("", false, "A17WWPUserExtendedDeleted", A17WWPUserExtendedDeleted);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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

      public void Valid_Wwpuserextendedid( )
      {
         n7WWPUserExtendedId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A12WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A12WWPUserExtendedSMSNotif));
         A13WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A13WWPUserExtendedMobileNotif));
         A14WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A14WWPUserExtendedDesktopNotif));
         A17WWPUserExtendedDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A17WWPUserExtendedDeleted));
         /*  Sending validation outputs */
         AssignAttri("", false, "A10WWPUserExtendedPhoto", context.PathToRelativeUrl( A10WWPUserExtendedPhoto));
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A10WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A16WWPUserExtendedName", A16WWPUserExtendedName);
         AssignAttri("", false, "A8WWPUserExtendedFullName", A8WWPUserExtendedFullName);
         AssignAttri("", false, "A15WWPUserExtendedPhone", StringUtil.RTrim( A15WWPUserExtendedPhone));
         AssignAttri("", false, "A9WWPUserExtendedEmail", A9WWPUserExtendedEmail);
         AssignAttri("", false, "A11WWPUserExtendedEmaiNotif", A11WWPUserExtendedEmaiNotif);
         AssignAttri("", false, "A12WWPUserExtendedSMSNotif", A12WWPUserExtendedSMSNotif);
         AssignAttri("", false, "A13WWPUserExtendedMobileNotif", A13WWPUserExtendedMobileNotif);
         AssignAttri("", false, "A14WWPUserExtendedDesktopNotif", A14WWPUserExtendedDesktopNotif);
         AssignAttri("", false, "A17WWPUserExtendedDeleted", A17WWPUserExtendedDeleted);
         AssignAttri("", false, "A18WWPUserExtendedDeletedIn", context.localUtil.TToC( A18WWPUserExtendedDeletedIn, 10, 8, 1, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z7WWPUserExtendedId", StringUtil.RTrim( Z7WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z10WWPUserExtendedPhoto", context.PathToRelativeUrl( Z10WWPUserExtendedPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000WWPUserExtendedPhoto_GXI", Z40000WWPUserExtendedPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z16WWPUserExtendedName", Z16WWPUserExtendedName);
         GxWebStd.gx_hidden_field( context, "Z8WWPUserExtendedFullName", Z8WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "Z15WWPUserExtendedPhone", StringUtil.RTrim( Z15WWPUserExtendedPhone));
         GxWebStd.gx_hidden_field( context, "Z9WWPUserExtendedEmail", Z9WWPUserExtendedEmail);
         GxWebStd.gx_hidden_field( context, "Z11WWPUserExtendedEmaiNotif", StringUtil.BoolToStr( Z11WWPUserExtendedEmaiNotif));
         GxWebStd.gx_hidden_field( context, "Z12WWPUserExtendedSMSNotif", StringUtil.BoolToStr( Z12WWPUserExtendedSMSNotif));
         GxWebStd.gx_hidden_field( context, "Z13WWPUserExtendedMobileNotif", StringUtil.BoolToStr( Z13WWPUserExtendedMobileNotif));
         GxWebStd.gx_hidden_field( context, "Z14WWPUserExtendedDesktopNotif", StringUtil.BoolToStr( Z14WWPUserExtendedDesktopNotif));
         GxWebStd.gx_hidden_field( context, "Z17WWPUserExtendedDeleted", StringUtil.BoolToStr( Z17WWPUserExtendedDeleted));
         GxWebStd.gx_hidden_field( context, "Z18WWPUserExtendedDeletedIn", context.localUtil.TToC( Z18WWPUserExtendedDeletedIn, 10, 8, 1, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A12WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A13WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A14WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A17WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A12WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A13WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A14WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A17WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A12WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A13WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A14WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A17WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A12WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A13WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A14WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A17WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]}""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","""{"handler":"Valid_Wwpuserextendedid","iparms":[{"av":"A7WWPUserExtendedId","fld":"WWPUSEREXTENDEDID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A12WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A13WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A14WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A17WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]""");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",""","oparms":[{"av":"A10WWPUserExtendedPhoto","fld":"WWPUSEREXTENDEDPHOTO"},{"av":"A40000WWPUserExtendedPhoto_GXI","fld":"WWPUSEREXTENDEDPHOTO_GXI"},{"av":"A16WWPUserExtendedName","fld":"WWPUSEREXTENDEDNAME"},{"av":"A8WWPUserExtendedFullName","fld":"WWPUSEREXTENDEDFULLNAME"},{"av":"A15WWPUserExtendedPhone","fld":"WWPUSEREXTENDEDPHONE"},{"av":"A9WWPUserExtendedEmail","fld":"WWPUSEREXTENDEDEMAIL"},{"av":"A11WWPUserExtendedEmaiNotif","fld":"WWPUSEREXTENDEDEMAINOTIF"},{"av":"A18WWPUserExtendedDeletedIn","fld":"WWPUSEREXTENDEDDELETEDIN","pic":"99/99/99 99:99"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z7WWPUserExtendedId"},{"av":"Z10WWPUserExtendedPhoto"},{"av":"Z40000WWPUserExtendedPhoto_GXI"},{"av":"Z16WWPUserExtendedName"},{"av":"Z8WWPUserExtendedFullName"},{"av":"Z15WWPUserExtendedPhone"},{"av":"Z9WWPUserExtendedEmail"},{"av":"Z11WWPUserExtendedEmaiNotif"},{"av":"Z12WWPUserExtendedSMSNotif"},{"av":"Z13WWPUserExtendedMobileNotif"},{"av":"Z14WWPUserExtendedDesktopNotif"},{"av":"Z17WWPUserExtendedDeleted"},{"av":"Z18WWPUserExtendedDeletedIn"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A12WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A13WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A14WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A17WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]}""");
         setEventMetadata("VALID_WWPUSEREXTENDEDEMAIL","""{"handler":"Valid_Wwpuserextendedemail","iparms":[{"av":"A12WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A13WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A14WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A17WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]""");
         setEventMetadata("VALID_WWPUSEREXTENDEDEMAIL",""","oparms":[{"av":"A12WWPUserExtendedSMSNotif","fld":"WWPUSEREXTENDEDSMSNOTIF"},{"av":"A13WWPUserExtendedMobileNotif","fld":"WWPUSEREXTENDEDMOBILENOTIF"},{"av":"A14WWPUserExtendedDesktopNotif","fld":"WWPUSEREXTENDEDDESKTOPNOTIF"},{"av":"A17WWPUserExtendedDeleted","fld":"WWPUSEREXTENDEDDELETED"}]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z7WWPUserExtendedId = "";
         Z16WWPUserExtendedName = "";
         Z8WWPUserExtendedFullName = "";
         Z15WWPUserExtendedPhone = "";
         Z9WWPUserExtendedEmail = "";
         Z18WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
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
         A7WWPUserExtendedId = "";
         A10WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         sImgUrl = "";
         A16WWPUserExtendedName = "";
         A8WWPUserExtendedFullName = "";
         gxphoneLink = "";
         A15WWPUserExtendedPhone = "";
         A9WWPUserExtendedEmail = "";
         A18WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
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
         Z10WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         T00014_A7WWPUserExtendedId = new string[] {""} ;
         T00014_n7WWPUserExtendedId = new bool[] {false} ;
         T00014_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T00014_A16WWPUserExtendedName = new string[] {""} ;
         T00014_A8WWPUserExtendedFullName = new string[] {""} ;
         T00014_A15WWPUserExtendedPhone = new string[] {""} ;
         T00014_A9WWPUserExtendedEmail = new string[] {""} ;
         T00014_A11WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T00014_A12WWPUserExtendedSMSNotif = new bool[] {false} ;
         T00014_A13WWPUserExtendedMobileNotif = new bool[] {false} ;
         T00014_A14WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T00014_A17WWPUserExtendedDeleted = new bool[] {false} ;
         T00014_A18WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         T00014_n18WWPUserExtendedDeletedIn = new bool[] {false} ;
         T00014_A10WWPUserExtendedPhoto = new string[] {""} ;
         T00015_A7WWPUserExtendedId = new string[] {""} ;
         T00015_n7WWPUserExtendedId = new bool[] {false} ;
         T00013_A7WWPUserExtendedId = new string[] {""} ;
         T00013_n7WWPUserExtendedId = new bool[] {false} ;
         T00013_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T00013_A16WWPUserExtendedName = new string[] {""} ;
         T00013_A8WWPUserExtendedFullName = new string[] {""} ;
         T00013_A15WWPUserExtendedPhone = new string[] {""} ;
         T00013_A9WWPUserExtendedEmail = new string[] {""} ;
         T00013_A11WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T00013_A12WWPUserExtendedSMSNotif = new bool[] {false} ;
         T00013_A13WWPUserExtendedMobileNotif = new bool[] {false} ;
         T00013_A14WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T00013_A17WWPUserExtendedDeleted = new bool[] {false} ;
         T00013_A18WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         T00013_n18WWPUserExtendedDeletedIn = new bool[] {false} ;
         T00013_A10WWPUserExtendedPhoto = new string[] {""} ;
         sMode1 = "";
         T00016_A7WWPUserExtendedId = new string[] {""} ;
         T00016_n7WWPUserExtendedId = new bool[] {false} ;
         T00017_A7WWPUserExtendedId = new string[] {""} ;
         T00017_n7WWPUserExtendedId = new bool[] {false} ;
         T00012_A7WWPUserExtendedId = new string[] {""} ;
         T00012_n7WWPUserExtendedId = new bool[] {false} ;
         T00012_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T00012_A16WWPUserExtendedName = new string[] {""} ;
         T00012_A8WWPUserExtendedFullName = new string[] {""} ;
         T00012_A15WWPUserExtendedPhone = new string[] {""} ;
         T00012_A9WWPUserExtendedEmail = new string[] {""} ;
         T00012_A11WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T00012_A12WWPUserExtendedSMSNotif = new bool[] {false} ;
         T00012_A13WWPUserExtendedMobileNotif = new bool[] {false} ;
         T00012_A14WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T00012_A17WWPUserExtendedDeleted = new bool[] {false} ;
         T00012_A18WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         T00012_n18WWPUserExtendedDeletedIn = new bool[] {false} ;
         T00012_A10WWPUserExtendedPhoto = new string[] {""} ;
         T000112_A22WWPNotificationId = new long[1] ;
         T000113_A48WWPWebClientId = new string[] {""} ;
         T000114_A25WWPSubscriptionId = new long[1] ;
         T000115_A7WWPUserExtendedId = new string[] {""} ;
         T000115_n7WWPUserExtendedId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ7WWPUserExtendedId = "";
         ZZ10WWPUserExtendedPhoto = "";
         ZZ40000WWPUserExtendedPhoto_GXI = "";
         ZZ16WWPUserExtendedName = "";
         ZZ8WWPUserExtendedFullName = "";
         ZZ15WWPUserExtendedPhone = "";
         ZZ9WWPUserExtendedEmail = "";
         ZZ18WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended__default(),
            new Object[][] {
                new Object[] {
               T00012_A7WWPUserExtendedId, T00012_A40000WWPUserExtendedPhoto_GXI, T00012_A16WWPUserExtendedName, T00012_A8WWPUserExtendedFullName, T00012_A15WWPUserExtendedPhone, T00012_A9WWPUserExtendedEmail, T00012_A11WWPUserExtendedEmaiNotif, T00012_A12WWPUserExtendedSMSNotif, T00012_A13WWPUserExtendedMobileNotif, T00012_A14WWPUserExtendedDesktopNotif,
               T00012_A17WWPUserExtendedDeleted, T00012_A18WWPUserExtendedDeletedIn, T00012_n18WWPUserExtendedDeletedIn, T00012_A10WWPUserExtendedPhoto
               }
               , new Object[] {
               T00013_A7WWPUserExtendedId, T00013_A40000WWPUserExtendedPhoto_GXI, T00013_A16WWPUserExtendedName, T00013_A8WWPUserExtendedFullName, T00013_A15WWPUserExtendedPhone, T00013_A9WWPUserExtendedEmail, T00013_A11WWPUserExtendedEmaiNotif, T00013_A12WWPUserExtendedSMSNotif, T00013_A13WWPUserExtendedMobileNotif, T00013_A14WWPUserExtendedDesktopNotif,
               T00013_A17WWPUserExtendedDeleted, T00013_A18WWPUserExtendedDeletedIn, T00013_n18WWPUserExtendedDeletedIn, T00013_A10WWPUserExtendedPhoto
               }
               , new Object[] {
               T00014_A7WWPUserExtendedId, T00014_A40000WWPUserExtendedPhoto_GXI, T00014_A16WWPUserExtendedName, T00014_A8WWPUserExtendedFullName, T00014_A15WWPUserExtendedPhone, T00014_A9WWPUserExtendedEmail, T00014_A11WWPUserExtendedEmaiNotif, T00014_A12WWPUserExtendedSMSNotif, T00014_A13WWPUserExtendedMobileNotif, T00014_A14WWPUserExtendedDesktopNotif,
               T00014_A17WWPUserExtendedDeleted, T00014_A18WWPUserExtendedDeletedIn, T00014_n18WWPUserExtendedDeletedIn, T00014_A10WWPUserExtendedPhoto
               }
               , new Object[] {
               T00015_A7WWPUserExtendedId
               }
               , new Object[] {
               T00016_A7WWPUserExtendedId
               }
               , new Object[] {
               T00017_A7WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000112_A22WWPNotificationId
               }
               , new Object[] {
               T000113_A48WWPWebClientId
               }
               , new Object[] {
               T000114_A25WWPSubscriptionId
               }
               , new Object[] {
               T000115_A7WWPUserExtendedId
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
      private short RcdFound1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPUserExtendedId_Enabled ;
      private int imgWWPUserExtendedPhoto_Enabled ;
      private int edtWWPUserExtendedName_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPUserExtendedPhone_Enabled ;
      private int edtWWPUserExtendedEmail_Enabled ;
      private int edtWWPUserExtendedEmaiNotif_Enabled ;
      private int edtWWPUserExtendedDeletedIn_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z7WWPUserExtendedId ;
      private string Z15WWPUserExtendedPhone ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPUserExtendedId_Internalname ;
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
      private string A7WWPUserExtendedId ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string imgWWPUserExtendedPhoto_Internalname ;
      private string sImgUrl ;
      private string edtWWPUserExtendedName_Internalname ;
      private string edtWWPUserExtendedName_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPUserExtendedPhone_Internalname ;
      private string gxphoneLink ;
      private string A15WWPUserExtendedPhone ;
      private string edtWWPUserExtendedPhone_Jsonclick ;
      private string edtWWPUserExtendedEmail_Internalname ;
      private string edtWWPUserExtendedEmail_Jsonclick ;
      private string edtWWPUserExtendedEmaiNotif_Internalname ;
      private string edtWWPUserExtendedEmaiNotif_Jsonclick ;
      private string chkWWPUserExtendedSMSNotif_Internalname ;
      private string chkWWPUserExtendedMobileNotif_Internalname ;
      private string chkWWPUserExtendedDesktopNotif_Internalname ;
      private string chkWWPUserExtendedDeleted_Internalname ;
      private string edtWWPUserExtendedDeletedIn_Internalname ;
      private string edtWWPUserExtendedDeletedIn_Jsonclick ;
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
      private string sMode1 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ7WWPUserExtendedId ;
      private string ZZ15WWPUserExtendedPhone ;
      private DateTime Z18WWPUserExtendedDeletedIn ;
      private DateTime A18WWPUserExtendedDeletedIn ;
      private DateTime ZZ18WWPUserExtendedDeletedIn ;
      private bool Z11WWPUserExtendedEmaiNotif ;
      private bool Z12WWPUserExtendedSMSNotif ;
      private bool Z13WWPUserExtendedMobileNotif ;
      private bool Z14WWPUserExtendedDesktopNotif ;
      private bool Z17WWPUserExtendedDeleted ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A12WWPUserExtendedSMSNotif ;
      private bool A13WWPUserExtendedMobileNotif ;
      private bool A14WWPUserExtendedDesktopNotif ;
      private bool A17WWPUserExtendedDeleted ;
      private bool A10WWPUserExtendedPhoto_IsBlob ;
      private bool A11WWPUserExtendedEmaiNotif ;
      private bool n18WWPUserExtendedDeletedIn ;
      private bool n7WWPUserExtendedId ;
      private bool Gx_longc ;
      private bool ZZ11WWPUserExtendedEmaiNotif ;
      private bool ZZ12WWPUserExtendedSMSNotif ;
      private bool ZZ13WWPUserExtendedMobileNotif ;
      private bool ZZ14WWPUserExtendedDesktopNotif ;
      private bool ZZ17WWPUserExtendedDeleted ;
      private string Z16WWPUserExtendedName ;
      private string Z8WWPUserExtendedFullName ;
      private string Z9WWPUserExtendedEmail ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string A16WWPUserExtendedName ;
      private string A8WWPUserExtendedFullName ;
      private string A9WWPUserExtendedEmail ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string ZZ40000WWPUserExtendedPhoto_GXI ;
      private string ZZ16WWPUserExtendedName ;
      private string ZZ8WWPUserExtendedFullName ;
      private string ZZ9WWPUserExtendedEmail ;
      private string A10WWPUserExtendedPhoto ;
      private string Z10WWPUserExtendedPhoto ;
      private string ZZ10WWPUserExtendedPhoto ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPUserExtendedSMSNotif ;
      private GXCheckbox chkWWPUserExtendedMobileNotif ;
      private GXCheckbox chkWWPUserExtendedDesktopNotif ;
      private GXCheckbox chkWWPUserExtendedDeleted ;
      private IDataStoreProvider pr_default ;
      private string[] T00014_A7WWPUserExtendedId ;
      private bool[] T00014_n7WWPUserExtendedId ;
      private string[] T00014_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T00014_A16WWPUserExtendedName ;
      private string[] T00014_A8WWPUserExtendedFullName ;
      private string[] T00014_A15WWPUserExtendedPhone ;
      private string[] T00014_A9WWPUserExtendedEmail ;
      private bool[] T00014_A11WWPUserExtendedEmaiNotif ;
      private bool[] T00014_A12WWPUserExtendedSMSNotif ;
      private bool[] T00014_A13WWPUserExtendedMobileNotif ;
      private bool[] T00014_A14WWPUserExtendedDesktopNotif ;
      private bool[] T00014_A17WWPUserExtendedDeleted ;
      private DateTime[] T00014_A18WWPUserExtendedDeletedIn ;
      private bool[] T00014_n18WWPUserExtendedDeletedIn ;
      private string[] T00014_A10WWPUserExtendedPhoto ;
      private string[] T00015_A7WWPUserExtendedId ;
      private bool[] T00015_n7WWPUserExtendedId ;
      private string[] T00013_A7WWPUserExtendedId ;
      private bool[] T00013_n7WWPUserExtendedId ;
      private string[] T00013_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T00013_A16WWPUserExtendedName ;
      private string[] T00013_A8WWPUserExtendedFullName ;
      private string[] T00013_A15WWPUserExtendedPhone ;
      private string[] T00013_A9WWPUserExtendedEmail ;
      private bool[] T00013_A11WWPUserExtendedEmaiNotif ;
      private bool[] T00013_A12WWPUserExtendedSMSNotif ;
      private bool[] T00013_A13WWPUserExtendedMobileNotif ;
      private bool[] T00013_A14WWPUserExtendedDesktopNotif ;
      private bool[] T00013_A17WWPUserExtendedDeleted ;
      private DateTime[] T00013_A18WWPUserExtendedDeletedIn ;
      private bool[] T00013_n18WWPUserExtendedDeletedIn ;
      private string[] T00013_A10WWPUserExtendedPhoto ;
      private string[] T00016_A7WWPUserExtendedId ;
      private bool[] T00016_n7WWPUserExtendedId ;
      private string[] T00017_A7WWPUserExtendedId ;
      private bool[] T00017_n7WWPUserExtendedId ;
      private string[] T00012_A7WWPUserExtendedId ;
      private bool[] T00012_n7WWPUserExtendedId ;
      private string[] T00012_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T00012_A16WWPUserExtendedName ;
      private string[] T00012_A8WWPUserExtendedFullName ;
      private string[] T00012_A15WWPUserExtendedPhone ;
      private string[] T00012_A9WWPUserExtendedEmail ;
      private bool[] T00012_A11WWPUserExtendedEmaiNotif ;
      private bool[] T00012_A12WWPUserExtendedSMSNotif ;
      private bool[] T00012_A13WWPUserExtendedMobileNotif ;
      private bool[] T00012_A14WWPUserExtendedDesktopNotif ;
      private bool[] T00012_A17WWPUserExtendedDeleted ;
      private DateTime[] T00012_A18WWPUserExtendedDeletedIn ;
      private bool[] T00012_n18WWPUserExtendedDeletedIn ;
      private string[] T00012_A10WWPUserExtendedPhoto ;
      private long[] T000112_A22WWPNotificationId ;
      private string[] T000113_A48WWPWebClientId ;
      private long[] T000114_A25WWPSubscriptionId ;
      private string[] T000115_A7WWPUserExtendedId ;
      private bool[] T000115_n7WWPUserExtendedId ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_userextended__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_userextended__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00012;
        prmT00012 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00013;
        prmT00013 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00014;
        prmT00014 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00015;
        prmT00015 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00016;
        prmT00016 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00017;
        prmT00017 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00018;
        prmT00018 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
        new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
        new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
        new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true}
        };
        Object[] prmT00019;
        prmT00019 = new Object[] {
        new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
        new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
        new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000110;
        prmT000110 = new Object[] {
        new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000111;
        prmT000111 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000112;
        prmT000112 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000113;
        prmT000113 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000114;
        prmT000114 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000115;
        prmT000115 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00012", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId  FOR UPDATE OF WWP_UserExtended NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00013", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00014", "SELECT TM1.WWPUserExtendedId, TM1.WWPUserExtendedPhoto_GXI, TM1.WWPUserExtendedName, TM1.WWPUserExtendedFullName, TM1.WWPUserExtendedPhone, TM1.WWPUserExtendedEmail, TM1.WWPUserExtendedEmaiNotif, TM1.WWPUserExtendedSMSNotif, TM1.WWPUserExtendedMobileNotif, TM1.WWPUserExtendedDesktopNotif, TM1.WWPUserExtendedDeleted, TM1.WWPUserExtendedDeletedIn, TM1.WWPUserExtendedPhoto FROM WWP_UserExtended TM1 WHERE TM1.WWPUserExtendedId = ( :WWPUserExtendedId) ORDER BY TM1.WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00015", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00016", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE ( WWPUserExtendedId > ( :WWPUserExtendedId)) ORDER BY WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00017", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE ( WWPUserExtendedId < ( :WWPUserExtendedId)) ORDER BY WWPUserExtendedId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00018", "SAVEPOINT gxupdate;INSERT INTO WWP_UserExtended(WWPUserExtendedId, WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn) VALUES(:WWPUserExtendedId, :WWPUserExtendedPhoto, :WWPUserExtendedPhoto_GXI, :WWPUserExtendedName, :WWPUserExtendedFullName, :WWPUserExtendedPhone, :WWPUserExtendedEmail, :WWPUserExtendedEmaiNotif, :WWPUserExtendedSMSNotif, :WWPUserExtendedMobileNotif, :WWPUserExtendedDesktopNotif, :WWPUserExtendedDeleted, :WWPUserExtendedDeletedIn);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00018)
           ,new CursorDef("T00019", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedName=:WWPUserExtendedName, WWPUserExtendedFullName=:WWPUserExtendedFullName, WWPUserExtendedPhone=:WWPUserExtendedPhone, WWPUserExtendedEmail=:WWPUserExtendedEmail, WWPUserExtendedEmaiNotif=:WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif=:WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif=:WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif=:WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted=:WWPUserExtendedDeleted, WWPUserExtendedDeletedIn=:WWPUserExtendedDeletedIn  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT00019)
           ,new CursorDef("T000110", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedPhoto=:WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI=:WWPUserExtendedPhoto_GXI  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000110)
           ,new CursorDef("T000111", "SAVEPOINT gxupdate;DELETE FROM WWP_UserExtended  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000111)
           ,new CursorDef("T000112", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000113", "SELECT WWPWebClientId FROM WWP_WebClient WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000114", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000115", "SELECT WWPUserExtendedId FROM WWP_UserExtended ORDER BY WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000115,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
     }
  }

}

}
