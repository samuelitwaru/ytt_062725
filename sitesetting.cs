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
   public class sitesetting : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A100CompanyId) ;
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
               AV7SiteSettingId = (long)(Math.Round(NumberUtil.Val( GetPar( "SiteSettingId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7SiteSettingId", StringUtil.LTrimStr( (decimal)(AV7SiteSettingId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSITESETTINGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SiteSettingId), "ZZZZZZZZZ9"), context));
            }
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
         Form.Meta.addItem("description", "Site Setting", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sitesetting( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sitesetting( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_SiteSettingId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SiteSettingId = aP1_SiteSettingId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkIsLogHourOpen = new GXCheckbox();
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
            return "sitesetting_Execute" ;
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
         A161IsLogHourOpen = StringUtil.StrToBool( StringUtil.BoolToStr( A161IsLogHourOpen));
         AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSiteSettingId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSiteSettingId_Internalname, "Setting Id", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSiteSettingId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A160SiteSettingId), 10, 0, ".", "")), StringUtil.LTrim( ((edtSiteSettingId_Enabled!=0) ? context.localUtil.Format( (decimal)(A160SiteSettingId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A160SiteSettingId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSiteSettingId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSiteSettingId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcompanyid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcompanyid_Internalname, "Location", "", "", lblTextblockcompanyid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_companyid.SetProperty("Caption", Combo_companyid_Caption);
         ucCombo_companyid.SetProperty("Cls", Combo_companyid_Cls);
         ucCombo_companyid.SetProperty("DataListProc", Combo_companyid_Datalistproc);
         ucCombo_companyid.SetProperty("DataListProcParametersPrefix", Combo_companyid_Datalistprocparametersprefix);
         ucCombo_companyid.SetProperty("EmptyItem", Combo_companyid_Emptyitem);
         ucCombo_companyid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_companyid.SetProperty("DropDownOptionsData", AV15CompanyId_Data);
         ucCombo_companyid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_companyid_Internalname, "COMBO_COMPANYIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCompanyId_Internalname, "Company Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCompanyId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompanyId_Jsonclick, 0, "Attribute", "", "", "", "", edtCompanyId_Visible, edtCompanyId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkIsLogHourOpen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkIsLogHourOpen_Internalname, "Hour Open", " AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkIsLogHourOpen_Internalname, StringUtil.BoolToStr( A161IsLogHourOpen), "", "Hour Open", 1, chkIsLogHourOpen.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(37, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,37);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SiteSetting.htm");
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
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_companyid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombocompanyid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboCompanyId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavCombocompanyid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboCompanyId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV20ComboCompanyId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocompanyid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocompanyid_Visible, edtavCombocompanyid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SiteSetting.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110N2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCOMPANYID_DATA"), AV15CompanyId_Data);
               /* Read saved values. */
               Z160SiteSettingId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z160SiteSettingId"), ".", ","), 18, MidpointRounding.ToEven));
               Z161IsLogHourOpen = StringUtil.StrToBool( cgiGet( "Z161IsLogHourOpen"));
               Z100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7SiteSettingId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vSITESETTINGID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_COMPANYID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV23Pgmname = cgiGet( "vPGMNAME");
               Combo_companyid_Objectcall = cgiGet( "COMBO_COMPANYID_Objectcall");
               Combo_companyid_Class = cgiGet( "COMBO_COMPANYID_Class");
               Combo_companyid_Icontype = cgiGet( "COMBO_COMPANYID_Icontype");
               Combo_companyid_Icon = cgiGet( "COMBO_COMPANYID_Icon");
               Combo_companyid_Caption = cgiGet( "COMBO_COMPANYID_Caption");
               Combo_companyid_Tooltip = cgiGet( "COMBO_COMPANYID_Tooltip");
               Combo_companyid_Cls = cgiGet( "COMBO_COMPANYID_Cls");
               Combo_companyid_Selectedvalue_set = cgiGet( "COMBO_COMPANYID_Selectedvalue_set");
               Combo_companyid_Selectedvalue_get = cgiGet( "COMBO_COMPANYID_Selectedvalue_get");
               Combo_companyid_Selectedtext_set = cgiGet( "COMBO_COMPANYID_Selectedtext_set");
               Combo_companyid_Selectedtext_get = cgiGet( "COMBO_COMPANYID_Selectedtext_get");
               Combo_companyid_Gamoauthtoken = cgiGet( "COMBO_COMPANYID_Gamoauthtoken");
               Combo_companyid_Ddointernalname = cgiGet( "COMBO_COMPANYID_Ddointernalname");
               Combo_companyid_Titlecontrolalign = cgiGet( "COMBO_COMPANYID_Titlecontrolalign");
               Combo_companyid_Dropdownoptionstype = cgiGet( "COMBO_COMPANYID_Dropdownoptionstype");
               Combo_companyid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYID_Enabled"));
               Combo_companyid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYID_Visible"));
               Combo_companyid_Titlecontrolidtoreplace = cgiGet( "COMBO_COMPANYID_Titlecontrolidtoreplace");
               Combo_companyid_Datalisttype = cgiGet( "COMBO_COMPANYID_Datalisttype");
               Combo_companyid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYID_Allowmultipleselection"));
               Combo_companyid_Datalistfixedvalues = cgiGet( "COMBO_COMPANYID_Datalistfixedvalues");
               Combo_companyid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYID_Isgriditem"));
               Combo_companyid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYID_Hasdescription"));
               Combo_companyid_Datalistproc = cgiGet( "COMBO_COMPANYID_Datalistproc");
               Combo_companyid_Datalistprocparametersprefix = cgiGet( "COMBO_COMPANYID_Datalistprocparametersprefix");
               Combo_companyid_Remoteservicesparameters = cgiGet( "COMBO_COMPANYID_Remoteservicesparameters");
               Combo_companyid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_COMPANYID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_companyid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYID_Includeonlyselectedoption"));
               Combo_companyid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYID_Includeselectalloption"));
               Combo_companyid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYID_Emptyitem"));
               Combo_companyid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_COMPANYID_Includeaddnewoption"));
               Combo_companyid_Htmltemplate = cgiGet( "COMBO_COMPANYID_Htmltemplate");
               Combo_companyid_Multiplevaluestype = cgiGet( "COMBO_COMPANYID_Multiplevaluestype");
               Combo_companyid_Loadingdata = cgiGet( "COMBO_COMPANYID_Loadingdata");
               Combo_companyid_Noresultsfound = cgiGet( "COMBO_COMPANYID_Noresultsfound");
               Combo_companyid_Emptyitemtext = cgiGet( "COMBO_COMPANYID_Emptyitemtext");
               Combo_companyid_Onlyselectedvalues = cgiGet( "COMBO_COMPANYID_Onlyselectedvalues");
               Combo_companyid_Selectalltext = cgiGet( "COMBO_COMPANYID_Selectalltext");
               Combo_companyid_Multiplevaluesseparator = cgiGet( "COMBO_COMPANYID_Multiplevaluesseparator");
               Combo_companyid_Addnewoptiontext = cgiGet( "COMBO_COMPANYID_Addnewoptiontext");
               Combo_companyid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_COMPANYID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( "DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               /* Read variables values. */
               A160SiteSettingId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSiteSettingId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtCompanyId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCompanyId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMPANYID");
                  AnyError = 1;
                  GX_FocusControl = edtCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A100CompanyId = 0;
                  AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
               }
               else
               {
                  A100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCompanyId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
               }
               A161IsLogHourOpen = StringUtil.StrToBool( cgiGet( chkIsLogHourOpen_Internalname));
               AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
               AV20ComboCompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombocompanyid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboCompanyId", StringUtil.LTrimStr( (decimal)(AV20ComboCompanyId), 10, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"SiteSetting");
               A160SiteSettingId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSiteSettingId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
               forbiddenHiddens.Add("SiteSettingId", context.localUtil.Format( (decimal)(A160SiteSettingId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A160SiteSettingId != Z160SiteSettingId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("sitesetting:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A160SiteSettingId = (long)(Math.Round(NumberUtil.Val( GetPar( "SiteSettingId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode25 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode25;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound25 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0N0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SITESETTINGID");
                        AnyError = 1;
                        GX_FocusControl = edtSiteSettingId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110N2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120N2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            /* Execute user event: After Trn */
            E120N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0N25( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0N25( ) ;
         }
         AssignProp("", false, edtavCombocompanyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocompanyid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0N0( )
      {
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0N25( ) ;
            }
            else
            {
               CheckExtendedTable0N25( ) ;
               CloseExtendedTableCursors0N25( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0N0( )
      {
      }

      protected void E110N2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV22GAMErrors);
         Combo_companyid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_companyid.SendProperty(context, "", false, Combo_companyid_Internalname, "GAMOAuthToken", Combo_companyid_Gamoauthtoken);
         edtCompanyId_Visible = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCompanyId_Visible), 5, 0), true);
         AV20ComboCompanyId = 0;
         AssignAttri("", false, "AV20ComboCompanyId", StringUtil.LTrimStr( (decimal)(AV20ComboCompanyId), 10, 0));
         edtavCombocompanyid_Visible = 0;
         AssignProp("", false, edtavCombocompanyid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocompanyid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCOMPANYID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            while ( AV24GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CompanyId") == 0 )
               {
                  AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV13Insert_CompanyId), 10, 0));
                  if ( ! (0==AV13Insert_CompanyId) )
                  {
                     AV20ComboCompanyId = AV13Insert_CompanyId;
                     AssignAttri("", false, "AV20ComboCompanyId", StringUtil.LTrimStr( (decimal)(AV20ComboCompanyId), 10, 0));
                     Combo_companyid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboCompanyId), 10, 0));
                     ucCombo_companyid.SendProperty(context, "", false, Combo_companyid_Internalname, "SelectedValue_set", Combo_companyid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new sitesettingloaddvcombo(context ).execute(  "CompanyId",  "GET",  false,  AV7SiteSettingId,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_companyid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_companyid.SendProperty(context, "", false, Combo_companyid_Internalname, "SelectedText_set", Combo_companyid_Selectedtext_set);
                     Combo_companyid_Enabled = false;
                     ucCombo_companyid.SendProperty(context, "", false, Combo_companyid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_companyid_Enabled));
                  }
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
      }

      protected void E120N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("sitesettingww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCOMPANYID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new sitesettingloaddvcombo(context ).execute(  "CompanyId",  Gx_mode,  false,  AV7SiteSettingId,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_companyid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_companyid.SendProperty(context, "", false, Combo_companyid_Internalname, "SelectedValue_set", Combo_companyid_Selectedvalue_set);
         Combo_companyid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_companyid.SendProperty(context, "", false, Combo_companyid_Internalname, "SelectedText_set", Combo_companyid_Selectedtext_set);
         AV20ComboCompanyId = (long)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboCompanyId", StringUtil.LTrimStr( (decimal)(AV20ComboCompanyId), 10, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_companyid_Enabled = false;
            ucCombo_companyid.SendProperty(context, "", false, Combo_companyid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_companyid_Enabled));
         }
      }

      protected void ZM0N25( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z161IsLogHourOpen = T000N3_A161IsLogHourOpen[0];
               Z100CompanyId = T000N3_A100CompanyId[0];
            }
            else
            {
               Z161IsLogHourOpen = A161IsLogHourOpen;
               Z100CompanyId = A100CompanyId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z160SiteSettingId = A160SiteSettingId;
            Z161IsLogHourOpen = A161IsLogHourOpen;
            Z100CompanyId = A100CompanyId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSiteSettingId_Enabled = 0;
         AssignProp("", false, edtSiteSettingId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSiteSettingId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV23Pgmname = "SiteSetting";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         edtSiteSettingId_Enabled = 0;
         AssignProp("", false, edtSiteSettingId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSiteSettingId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SiteSettingId) )
         {
            A160SiteSettingId = AV7SiteSettingId;
            AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            edtCompanyId_Enabled = 0;
            AssignProp("", false, edtCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyId_Enabled), 5, 0), true);
         }
         else
         {
            edtCompanyId_Enabled = 1;
            AssignProp("", false, edtCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            A100CompanyId = AV13Insert_CompanyId;
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         else
         {
            A100CompanyId = AV20ComboCompanyId;
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (false==A161IsLogHourOpen) && ( Gx_BScreen == 0 ) )
         {
            A161IsLogHourOpen = false;
            AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
         }
      }

      protected void Load0N25( )
      {
         /* Using cursor T000N5 */
         pr_default.execute(3, new Object[] {A160SiteSettingId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
            A161IsLogHourOpen = T000N5_A161IsLogHourOpen[0];
            AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
            A100CompanyId = T000N5_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            ZM0N25( -9) ;
         }
         pr_default.close(3);
         OnLoadActions0N25( ) ;
      }

      protected void OnLoadActions0N25( )
      {
      }

      protected void CheckExtendedTable0N25( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000N4 */
         pr_default.execute(2, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0N25( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( long A100CompanyId )
      {
         /* Using cursor T000N6 */
         pr_default.execute(4, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void GetKey0N25( )
      {
         /* Using cursor T000N7 */
         pr_default.execute(5, new Object[] {A160SiteSettingId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000N3 */
         pr_default.execute(1, new Object[] {A160SiteSettingId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N25( 9) ;
            RcdFound25 = 1;
            A160SiteSettingId = T000N3_A160SiteSettingId[0];
            AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
            A161IsLogHourOpen = T000N3_A161IsLogHourOpen[0];
            AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
            A100CompanyId = T000N3_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            Z160SiteSettingId = A160SiteSettingId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0N25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0N25( ) ;
            }
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0N25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N25( ) ;
         if ( RcdFound25 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound25 = 0;
         /* Using cursor T000N8 */
         pr_default.execute(6, new Object[] {A160SiteSettingId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000N8_A160SiteSettingId[0] < A160SiteSettingId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000N8_A160SiteSettingId[0] > A160SiteSettingId ) ) )
            {
               A160SiteSettingId = T000N8_A160SiteSettingId[0];
               AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound25 = 0;
         /* Using cursor T000N9 */
         pr_default.execute(7, new Object[] {A160SiteSettingId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000N9_A160SiteSettingId[0] > A160SiteSettingId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000N9_A160SiteSettingId[0] < A160SiteSettingId ) ) )
            {
               A160SiteSettingId = T000N9_A160SiteSettingId[0];
               AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0N25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0N25( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A160SiteSettingId != Z160SiteSettingId )
               {
                  A160SiteSettingId = Z160SiteSettingId;
                  AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SITESETTINGID");
                  AnyError = 1;
                  GX_FocusControl = edtSiteSettingId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0N25( ) ;
                  GX_FocusControl = edtCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A160SiteSettingId != Z160SiteSettingId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0N25( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SITESETTINGID");
                     AnyError = 1;
                     GX_FocusControl = edtSiteSettingId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCompanyId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0N25( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A160SiteSettingId != Z160SiteSettingId )
         {
            A160SiteSettingId = Z160SiteSettingId;
            AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SITESETTINGID");
            AnyError = 1;
            GX_FocusControl = edtSiteSettingId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0N25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N2 */
            pr_default.execute(0, new Object[] {A160SiteSettingId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SiteSetting"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z161IsLogHourOpen != T000N2_A161IsLogHourOpen[0] ) || ( Z100CompanyId != T000N2_A100CompanyId[0] ) )
            {
               if ( Z161IsLogHourOpen != T000N2_A161IsLogHourOpen[0] )
               {
                  GXUtil.WriteLog("sitesetting:[seudo value changed for attri]"+"IsLogHourOpen");
                  GXUtil.WriteLogRaw("Old: ",Z161IsLogHourOpen);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A161IsLogHourOpen[0]);
               }
               if ( Z100CompanyId != T000N2_A100CompanyId[0] )
               {
                  GXUtil.WriteLog("sitesetting:[seudo value changed for attri]"+"CompanyId");
                  GXUtil.WriteLogRaw("Old: ",Z100CompanyId);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A100CompanyId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SiteSetting"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N25( )
      {
         if ( ! IsAuthorized("sitesetting_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N25( 0) ;
            CheckOptimisticConcurrency0N25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N10 */
                     pr_default.execute(8, new Object[] {A161IsLogHourOpen, A100CompanyId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000N11 */
                     pr_default.execute(9);
                     A160SiteSettingId = T000N11_A160SiteSettingId[0];
                     AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SiteSetting");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0N0( ) ;
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
               Load0N25( ) ;
            }
            EndLevel0N25( ) ;
         }
         CloseExtendedTableCursors0N25( ) ;
      }

      protected void Update0N25( )
      {
         if ( ! IsAuthorized("sitesetting_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N12 */
                     pr_default.execute(10, new Object[] {A161IsLogHourOpen, A100CompanyId, A160SiteSettingId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SiteSetting");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SiteSetting"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N25( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
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
            }
            EndLevel0N25( ) ;
         }
         CloseExtendedTableCursors0N25( ) ;
      }

      protected void DeferredUpdate0N25( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("sitesetting_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N25( ) ;
            AfterConfirm0N25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000N13 */
                  pr_default.execute(11, new Object[] {A160SiteSettingId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("SiteSetting");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
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
         }
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0N25( ) ;
         Gx_mode = sMode25;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N25( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0N25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N25( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("sitesetting",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("sitesetting",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0N25( )
      {
         /* Scan By routine */
         /* Using cursor T000N14 */
         pr_default.execute(12);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound25 = 1;
            A160SiteSettingId = T000N14_A160SiteSettingId[0];
            AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N25( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound25 = 1;
            A160SiteSettingId = T000N14_A160SiteSettingId[0];
            AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
         }
      }

      protected void ScanEnd0N25( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0N25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N25( )
      {
         edtSiteSettingId_Enabled = 0;
         AssignProp("", false, edtSiteSettingId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSiteSettingId_Enabled), 5, 0), true);
         edtCompanyId_Enabled = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyId_Enabled), 5, 0), true);
         chkIsLogHourOpen.Enabled = 0;
         AssignProp("", false, chkIsLogHourOpen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkIsLogHourOpen.Enabled), 5, 0), true);
         edtavCombocompanyid_Enabled = 0;
         AssignProp("", false, edtavCombocompanyid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocompanyid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0N25( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0N0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sitesetting.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SiteSettingId,10,0))}, new string[] {"Gx_mode","SiteSettingId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"SiteSetting");
         forbiddenHiddens.Add("SiteSettingId", context.localUtil.Format( (decimal)(A160SiteSettingId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("sitesetting:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z160SiteSettingId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z160SiteSettingId), 10, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z161IsLogHourOpen", Z161IsLogHourOpen);
         GxWebStd.gx_hidden_field( context, "Z100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOMPANYID_DATA", AV15CompanyId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOMPANYID_DATA", AV15CompanyId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vSITESETTINGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SiteSettingId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSITESETTINGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SiteSettingId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_COMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYID_Objectcall", StringUtil.RTrim( Combo_companyid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYID_Cls", StringUtil.RTrim( Combo_companyid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYID_Selectedvalue_set", StringUtil.RTrim( Combo_companyid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYID_Selectedtext_set", StringUtil.RTrim( Combo_companyid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYID_Gamoauthtoken", StringUtil.RTrim( Combo_companyid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYID_Enabled", StringUtil.BoolToStr( Combo_companyid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYID_Datalistproc", StringUtil.RTrim( Combo_companyid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_companyid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_COMPANYID_Emptyitem", StringUtil.BoolToStr( Combo_companyid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
         return formatLink("sitesetting.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SiteSettingId,10,0))}, new string[] {"Gx_mode","SiteSettingId"})  ;
      }

      public override string GetPgmname( )
      {
         return "SiteSetting" ;
      }

      public override string GetPgmdesc( )
      {
         return "Site Setting" ;
      }

      protected void InitializeNonKey0N25( )
      {
         A100CompanyId = 0;
         AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         A161IsLogHourOpen = false;
         AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
         Z161IsLogHourOpen = false;
         Z100CompanyId = 0;
      }

      protected void InitAll0N25( )
      {
         A160SiteSettingId = 0;
         AssignAttri("", false, "A160SiteSettingId", StringUtil.LTrimStr( (decimal)(A160SiteSettingId), 10, 0));
         InitializeNonKey0N25( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A161IsLogHourOpen = i161IsLogHourOpen;
         AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267501579", true, true);
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
         context.AddJavascriptSource("sitesetting.js", "?20256267501581", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSiteSettingId_Internalname = "SITESETTINGID";
         lblTextblockcompanyid_Internalname = "TEXTBLOCKCOMPANYID";
         Combo_companyid_Internalname = "COMBO_COMPANYID";
         edtCompanyId_Internalname = "COMPANYID";
         divTablesplittedcompanyid_Internalname = "TABLESPLITTEDCOMPANYID";
         chkIsLogHourOpen_Internalname = "ISLOGHOUROPEN";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocompanyid_Internalname = "vCOMBOCOMPANYID";
         divSectionattribute_companyid_Internalname = "SECTIONATTRIBUTE_COMPANYID";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Site Setting";
         edtavCombocompanyid_Jsonclick = "";
         edtavCombocompanyid_Enabled = 0;
         edtavCombocompanyid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkIsLogHourOpen.Enabled = 1;
         edtCompanyId_Jsonclick = "";
         edtCompanyId_Enabled = 1;
         edtCompanyId_Visible = 1;
         Combo_companyid_Emptyitem = Convert.ToBoolean( 0);
         Combo_companyid_Datalistprocparametersprefix = " \"ComboName\": \"CompanyId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"SiteSettingId\": 0";
         Combo_companyid_Datalistproc = "SiteSettingLoadDVCombo";
         Combo_companyid_Cls = "ExtendedCombo Attribute";
         Combo_companyid_Caption = "";
         Combo_companyid_Enabled = Convert.ToBoolean( -1);
         edtSiteSettingId_Jsonclick = "";
         edtSiteSettingId_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "General Information";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         divLayoutmaintable_Class = "Table";
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
         chkIsLogHourOpen.Name = "ISLOGHOUROPEN";
         chkIsLogHourOpen.WebTags = "";
         chkIsLogHourOpen.Caption = "Hour Open";
         AssignProp("", false, chkIsLogHourOpen_Internalname, "TitleCaption", chkIsLogHourOpen.Caption, true);
         chkIsLogHourOpen.CheckedValue = "false";
         if ( IsIns( ) && (false==A161IsLogHourOpen) )
         {
            A161IsLogHourOpen = false;
            AssignAttri("", false, "A161IsLogHourOpen", A161IsLogHourOpen);
         }
         /* End function init_web_controls */
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

      public void Valid_Companyid( )
      {
         /* Using cursor T000N15 */
         pr_default.execute(13, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7SiteSettingId","fld":"vSITESETTINGID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7SiteSettingId","fld":"vSITESETTINGID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A160SiteSettingId","fld":"SITESETTINGID","pic":"ZZZZZZZZZ9"},{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120N2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]}""");
         setEventMetadata("VALID_SITESETTINGID","""{"handler":"Valid_Sitesettingid","iparms":[{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]""");
         setEventMetadata("VALID_SITESETTINGID",""","oparms":[{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]}""");
         setEventMetadata("VALID_COMPANYID","""{"handler":"Valid_Companyid","iparms":[{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]""");
         setEventMetadata("VALID_COMPANYID",""","oparms":[{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]}""");
         setEventMetadata("VALIDV_COMBOCOMPANYID","""{"handler":"Validv_Combocompanyid","iparms":[{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]""");
         setEventMetadata("VALIDV_COMBOCOMPANYID",""","oparms":[{"av":"A161IsLogHourOpen","fld":"ISLOGHOUROPEN"}]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Combo_companyid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockcompanyid_Jsonclick = "";
         ucCombo_companyid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15CompanyId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV23Pgmname = "";
         Combo_companyid_Objectcall = "";
         Combo_companyid_Class = "";
         Combo_companyid_Icontype = "";
         Combo_companyid_Icon = "";
         Combo_companyid_Tooltip = "";
         Combo_companyid_Selectedvalue_set = "";
         Combo_companyid_Selectedtext_set = "";
         Combo_companyid_Selectedtext_get = "";
         Combo_companyid_Gamoauthtoken = "";
         Combo_companyid_Ddointernalname = "";
         Combo_companyid_Titlecontrolalign = "";
         Combo_companyid_Dropdownoptionstype = "";
         Combo_companyid_Titlecontrolidtoreplace = "";
         Combo_companyid_Datalisttype = "";
         Combo_companyid_Datalistfixedvalues = "";
         Combo_companyid_Remoteservicesparameters = "";
         Combo_companyid_Htmltemplate = "";
         Combo_companyid_Multiplevaluestype = "";
         Combo_companyid_Loadingdata = "";
         Combo_companyid_Noresultsfound = "";
         Combo_companyid_Emptyitemtext = "";
         Combo_companyid_Onlyselectedvalues = "";
         Combo_companyid_Selectalltext = "";
         Combo_companyid_Multiplevaluesseparator = "";
         Combo_companyid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode25 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV22GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         T000N5_A160SiteSettingId = new long[1] ;
         T000N5_A161IsLogHourOpen = new bool[] {false} ;
         T000N5_A100CompanyId = new long[1] ;
         T000N4_A100CompanyId = new long[1] ;
         T000N6_A100CompanyId = new long[1] ;
         T000N7_A160SiteSettingId = new long[1] ;
         T000N3_A160SiteSettingId = new long[1] ;
         T000N3_A161IsLogHourOpen = new bool[] {false} ;
         T000N3_A100CompanyId = new long[1] ;
         T000N8_A160SiteSettingId = new long[1] ;
         T000N9_A160SiteSettingId = new long[1] ;
         T000N2_A160SiteSettingId = new long[1] ;
         T000N2_A161IsLogHourOpen = new bool[] {false} ;
         T000N2_A100CompanyId = new long[1] ;
         T000N11_A160SiteSettingId = new long[1] ;
         T000N14_A160SiteSettingId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000N15_A100CompanyId = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.sitesetting__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sitesetting__default(),
            new Object[][] {
                new Object[] {
               T000N2_A160SiteSettingId, T000N2_A161IsLogHourOpen, T000N2_A100CompanyId
               }
               , new Object[] {
               T000N3_A160SiteSettingId, T000N3_A161IsLogHourOpen, T000N3_A100CompanyId
               }
               , new Object[] {
               T000N4_A100CompanyId
               }
               , new Object[] {
               T000N5_A160SiteSettingId, T000N5_A161IsLogHourOpen, T000N5_A100CompanyId
               }
               , new Object[] {
               T000N6_A100CompanyId
               }
               , new Object[] {
               T000N7_A160SiteSettingId
               }
               , new Object[] {
               T000N8_A160SiteSettingId
               }
               , new Object[] {
               T000N9_A160SiteSettingId
               }
               , new Object[] {
               }
               , new Object[] {
               T000N11_A160SiteSettingId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N14_A160SiteSettingId
               }
               , new Object[] {
               T000N15_A100CompanyId
               }
            }
         );
         Z161IsLogHourOpen = false;
         A161IsLogHourOpen = false;
         i161IsLogHourOpen = false;
         AV23Pgmname = "SiteSetting";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound25 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtSiteSettingId_Enabled ;
      private int edtCompanyId_Visible ;
      private int edtCompanyId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombocompanyid_Enabled ;
      private int edtavCombocompanyid_Visible ;
      private int Combo_companyid_Datalistupdateminimumcharacters ;
      private int Combo_companyid_Gxcontroltype ;
      private int AV24GXV1 ;
      private int idxLst ;
      private long wcpOAV7SiteSettingId ;
      private long Z160SiteSettingId ;
      private long Z100CompanyId ;
      private long N100CompanyId ;
      private long A100CompanyId ;
      private long AV7SiteSettingId ;
      private long A160SiteSettingId ;
      private long AV20ComboCompanyId ;
      private long AV13Insert_CompanyId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_companyid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCompanyId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtSiteSettingId_Internalname ;
      private string TempTags ;
      private string edtSiteSettingId_Jsonclick ;
      private string divTablesplittedcompanyid_Internalname ;
      private string lblTextblockcompanyid_Internalname ;
      private string lblTextblockcompanyid_Jsonclick ;
      private string Combo_companyid_Caption ;
      private string Combo_companyid_Cls ;
      private string Combo_companyid_Datalistproc ;
      private string Combo_companyid_Datalistprocparametersprefix ;
      private string Combo_companyid_Internalname ;
      private string edtCompanyId_Jsonclick ;
      private string chkIsLogHourOpen_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_companyid_Internalname ;
      private string edtavCombocompanyid_Internalname ;
      private string edtavCombocompanyid_Jsonclick ;
      private string AV23Pgmname ;
      private string Combo_companyid_Objectcall ;
      private string Combo_companyid_Class ;
      private string Combo_companyid_Icontype ;
      private string Combo_companyid_Icon ;
      private string Combo_companyid_Tooltip ;
      private string Combo_companyid_Selectedvalue_set ;
      private string Combo_companyid_Selectedtext_set ;
      private string Combo_companyid_Selectedtext_get ;
      private string Combo_companyid_Gamoauthtoken ;
      private string Combo_companyid_Ddointernalname ;
      private string Combo_companyid_Titlecontrolalign ;
      private string Combo_companyid_Dropdownoptionstype ;
      private string Combo_companyid_Titlecontrolidtoreplace ;
      private string Combo_companyid_Datalisttype ;
      private string Combo_companyid_Datalistfixedvalues ;
      private string Combo_companyid_Remoteservicesparameters ;
      private string Combo_companyid_Htmltemplate ;
      private string Combo_companyid_Multiplevaluestype ;
      private string Combo_companyid_Loadingdata ;
      private string Combo_companyid_Noresultsfound ;
      private string Combo_companyid_Emptyitemtext ;
      private string Combo_companyid_Onlyselectedvalues ;
      private string Combo_companyid_Selectalltext ;
      private string Combo_companyid_Multiplevaluesseparator ;
      private string Combo_companyid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode25 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z161IsLogHourOpen ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A161IsLogHourOpen ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_companyid_Emptyitem ;
      private bool Combo_companyid_Enabled ;
      private bool Combo_companyid_Visible ;
      private bool Combo_companyid_Allowmultipleselection ;
      private bool Combo_companyid_Isgriditem ;
      private bool Combo_companyid_Hasdescription ;
      private bool Combo_companyid_Includeonlyselectedoption ;
      private bool Combo_companyid_Includeselectalloption ;
      private bool Combo_companyid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool i161IsLogHourOpen ;
      private string AV19Combo_DataJson ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_companyid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkIsLogHourOpen ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15CompanyId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] T000N5_A160SiteSettingId ;
      private bool[] T000N5_A161IsLogHourOpen ;
      private long[] T000N5_A100CompanyId ;
      private long[] T000N4_A100CompanyId ;
      private long[] T000N6_A100CompanyId ;
      private long[] T000N7_A160SiteSettingId ;
      private long[] T000N3_A160SiteSettingId ;
      private bool[] T000N3_A161IsLogHourOpen ;
      private long[] T000N3_A100CompanyId ;
      private long[] T000N8_A160SiteSettingId ;
      private long[] T000N9_A160SiteSettingId ;
      private long[] T000N2_A160SiteSettingId ;
      private bool[] T000N2_A161IsLogHourOpen ;
      private long[] T000N2_A100CompanyId ;
      private long[] T000N11_A160SiteSettingId ;
      private long[] T000N14_A160SiteSettingId ;
      private long[] T000N15_A100CompanyId ;
      private IDataStoreProvider pr_gam ;
   }

   public class sitesetting__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class sitesetting__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000N2;
        prmT000N2 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N3;
        prmT000N3 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N4;
        prmT000N4 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000N5;
        prmT000N5 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N6;
        prmT000N6 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000N7;
        prmT000N7 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N8;
        prmT000N8 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N9;
        prmT000N9 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N10;
        prmT000N10 = new Object[] {
        new ParDef("IsLogHourOpen",GXType.Boolean,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000N11;
        prmT000N11 = new Object[] {
        };
        Object[] prmT000N12;
        prmT000N12 = new Object[] {
        new ParDef("IsLogHourOpen",GXType.Boolean,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0) ,
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N13;
        prmT000N13 = new Object[] {
        new ParDef("SiteSettingId",GXType.Int64,10,0)
        };
        Object[] prmT000N14;
        prmT000N14 = new Object[] {
        };
        Object[] prmT000N15;
        prmT000N15 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000N2", "SELECT SiteSettingId, IsLogHourOpen, CompanyId FROM SiteSetting WHERE SiteSettingId = :SiteSettingId  FOR UPDATE OF SiteSetting NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N3", "SELECT SiteSettingId, IsLogHourOpen, CompanyId FROM SiteSetting WHERE SiteSettingId = :SiteSettingId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N4", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N5", "SELECT TM1.SiteSettingId, TM1.IsLogHourOpen, TM1.CompanyId FROM SiteSetting TM1 WHERE TM1.SiteSettingId = :SiteSettingId ORDER BY TM1.SiteSettingId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N6", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N7", "SELECT SiteSettingId FROM SiteSetting WHERE SiteSettingId = :SiteSettingId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N8", "SELECT SiteSettingId FROM SiteSetting WHERE ( SiteSettingId > :SiteSettingId) ORDER BY SiteSettingId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N9", "SELECT SiteSettingId FROM SiteSetting WHERE ( SiteSettingId < :SiteSettingId) ORDER BY SiteSettingId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N10", "SAVEPOINT gxupdate;INSERT INTO SiteSetting(IsLogHourOpen, CompanyId) VALUES(:IsLogHourOpen, :CompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N10)
           ,new CursorDef("T000N11", "SELECT currval('SiteSettingId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N12", "SAVEPOINT gxupdate;UPDATE SiteSetting SET IsLogHourOpen=:IsLogHourOpen, CompanyId=:CompanyId  WHERE SiteSettingId = :SiteSettingId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N12)
           ,new CursorDef("T000N13", "SAVEPOINT gxupdate;DELETE FROM SiteSetting  WHERE SiteSettingId = :SiteSettingId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N13)
           ,new CursorDef("T000N14", "SELECT SiteSettingId FROM SiteSetting ORDER BY SiteSettingId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N15", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N15,1, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
