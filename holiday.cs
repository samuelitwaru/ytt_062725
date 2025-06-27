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
   public class holiday : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"COMPANYID") == 0 )
         {
            AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "Insert_CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV13Insert_CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX5ASACOMPANYID0G18( AV13Insert_CompanyId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A100CompanyId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A157CompanyLocationId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyLocationId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A157CompanyLocationId) ;
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
               AV7HolidayId = (long)(Math.Round(NumberUtil.Val( GetPar( "HolidayId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7HolidayId", StringUtil.LTrimStr( (decimal)(AV7HolidayId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vHOLIDAYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7HolidayId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "National Holidays", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtHolidayName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public holiday( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public holiday( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_HolidayId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7HolidayId = aP1_HolidayId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkHolidayIsActive = new GXCheckbox();
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
            return "holiday_Execute" ;
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
         A139HolidayIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A139HolidayIsActive));
         AssignAttri("", false, "A139HolidayIsActive", A139HolidayIsActive);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHolidayName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHolidayName_Internalname, "National Holiday Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHolidayName_Internalname, StringUtil.RTrim( A114HolidayName), StringUtil.RTrim( context.localUtil.Format( A114HolidayName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHolidayName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHolidayName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Holiday.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHolidayStartDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHolidayStartDate_Internalname, "Date", " AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtHolidayStartDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtHolidayStartDate_Internalname, context.localUtil.Format(A115HolidayStartDate, "99/99/99"), context.localUtil.Format( A115HolidayStartDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHolidayStartDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtHolidayStartDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Holiday.htm");
         GxWebStd.gx_bitmap( context, edtHolidayStartDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHolidayStartDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Holiday.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHolidayisactive_cell_Internalname, 1, 0, "px", 0, "px", divHolidayisactive_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", chkHolidayIsActive.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkHolidayIsActive_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkHolidayIsActive_Internalname, "Active", " AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkHolidayIsActive_Internalname, StringUtil.BoolToStr( A139HolidayIsActive), "", "Active", chkHolidayIsActive.Visible, chkHolidayIsActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(31, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,31);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Holiday.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Holiday.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Holiday.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHolidayId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A113HolidayId), 10, 0, ".", "")), StringUtil.LTrim( ((edtHolidayId_Enabled!=0) ? context.localUtil.Format( (decimal)(A113HolidayId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A113HolidayId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHolidayId_Jsonclick, 0, "Attribute", "", "", "", "", edtHolidayId_Visible, edtHolidayId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Holiday.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtHolidayEndDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtHolidayEndDate_Internalname, context.localUtil.Format(A116HolidayEndDate, "99/99/99"), context.localUtil.Format( A116HolidayEndDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHolidayEndDate_Jsonclick, 0, "Attribute", "", "", "", "", edtHolidayEndDate_Visible, edtHolidayEndDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Holiday.htm");
         GxWebStd.gx_bitmap( context, edtHolidayEndDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtHolidayEndDate_Visible==0)||(edtHolidayEndDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Holiday.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHolidayServiceId_Internalname, StringUtil.RTrim( A117HolidayServiceId), StringUtil.RTrim( context.localUtil.Format( A117HolidayServiceId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHolidayServiceId_Jsonclick, 0, "Attribute", "", "", "", "", edtHolidayServiceId_Visible, edtHolidayServiceId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Holiday.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCompanyId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompanyId_Jsonclick, 0, "Attribute", "", "", "", "", edtCompanyId_Visible, edtCompanyId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Holiday.htm");
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
         E110G2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z113HolidayId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z113HolidayId"), ".", ","), 18, MidpointRounding.ToEven));
               Z114HolidayName = cgiGet( "Z114HolidayName");
               Z115HolidayStartDate = context.localUtil.CToD( cgiGet( "Z115HolidayStartDate"), 0);
               Z116HolidayEndDate = context.localUtil.CToD( cgiGet( "Z116HolidayEndDate"), 0);
               n116HolidayEndDate = ((DateTime.MinValue==A116HolidayEndDate) ? true : false);
               Z117HolidayServiceId = cgiGet( "Z117HolidayServiceId");
               n117HolidayServiceId = (String.IsNullOrEmpty(StringUtil.RTrim( A117HolidayServiceId)) ? true : false);
               Z139HolidayIsActive = StringUtil.StrToBool( cgiGet( "Z139HolidayIsActive"));
               Z100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7HolidayId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vHOLIDAYID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_COMPANYID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               A157CompanyLocationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "COMPANYLOCATIONID"), ".", ","), 18, MidpointRounding.ToEven));
               A159CompanyLocationCode = cgiGet( "COMPANYLOCATIONCODE");
               AV24Pgmname = cgiGet( "vPGMNAME");
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
               A114HolidayName = cgiGet( edtHolidayName_Internalname);
               AssignAttri("", false, "A114HolidayName", A114HolidayName);
               if ( context.localUtil.VCDate( cgiGet( edtHolidayStartDate_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Holiday Start Date"}), 1, "HOLIDAYSTARTDATE");
                  AnyError = 1;
                  GX_FocusControl = edtHolidayStartDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A115HolidayStartDate = DateTime.MinValue;
                  AssignAttri("", false, "A115HolidayStartDate", context.localUtil.Format(A115HolidayStartDate, "99/99/99"));
               }
               else
               {
                  A115HolidayStartDate = context.localUtil.CToD( cgiGet( edtHolidayStartDate_Internalname), 2);
                  AssignAttri("", false, "A115HolidayStartDate", context.localUtil.Format(A115HolidayStartDate, "99/99/99"));
               }
               A139HolidayIsActive = StringUtil.StrToBool( cgiGet( chkHolidayIsActive_Internalname));
               AssignAttri("", false, "A139HolidayIsActive", A139HolidayIsActive);
               A113HolidayId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHolidayId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
               if ( context.localUtil.VCDate( cgiGet( edtHolidayEndDate_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Holiday End Date"}), 1, "HOLIDAYENDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtHolidayEndDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A116HolidayEndDate = DateTime.MinValue;
                  n116HolidayEndDate = false;
                  AssignAttri("", false, "A116HolidayEndDate", context.localUtil.Format(A116HolidayEndDate, "99/99/99"));
               }
               else
               {
                  A116HolidayEndDate = context.localUtil.CToD( cgiGet( edtHolidayEndDate_Internalname), 2);
                  n116HolidayEndDate = false;
                  AssignAttri("", false, "A116HolidayEndDate", context.localUtil.Format(A116HolidayEndDate, "99/99/99"));
               }
               n116HolidayEndDate = ((DateTime.MinValue==A116HolidayEndDate) ? true : false);
               A117HolidayServiceId = cgiGet( edtHolidayServiceId_Internalname);
               n117HolidayServiceId = false;
               AssignAttri("", false, "A117HolidayServiceId", A117HolidayServiceId);
               n117HolidayServiceId = (String.IsNullOrEmpty(StringUtil.RTrim( A117HolidayServiceId)) ? true : false);
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
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Holiday");
               A113HolidayId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHolidayId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
               forbiddenHiddens.Add("HolidayId", context.localUtil.Format( (decimal)(A113HolidayId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A113HolidayId != Z113HolidayId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("holiday:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A113HolidayId = (long)(Math.Round(NumberUtil.Val( GetPar( "HolidayId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
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
                     sMode18 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode18;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound18 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0G0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "HOLIDAYID");
                        AnyError = 1;
                        GX_FocusControl = edtHolidayId_Internalname;
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
                           E110G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120G2 ();
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
            E120G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0G18( ) ;
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
            DisableAttributes0G18( ) ;
         }
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

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G18( ) ;
            }
            else
            {
               CheckExtendedTable0G18( ) ;
               CloseExtendedTableCursors0G18( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0G0( )
      {
      }

      protected void E110G2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            while ( AV25GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CompanyId") == 0 )
               {
                  AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV13Insert_CompanyId), 10, 0));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
               AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            }
         }
         edtHolidayId_Visible = 0;
         AssignProp("", false, edtHolidayId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHolidayId_Visible), 5, 0), true);
         edtHolidayEndDate_Visible = 0;
         AssignProp("", false, edtHolidayEndDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHolidayEndDate_Visible), 5, 0), true);
         edtHolidayServiceId_Visible = 0;
         AssignProp("", false, edtHolidayServiceId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtHolidayServiceId_Visible), 5, 0), true);
         edtCompanyId_Visible = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCompanyId_Visible), 5, 0), true);
      }

      protected void E120G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("holidayww.aspx") );
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
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         chkHolidayIsActive.Visible = 0;
         AssignProp("", false, chkHolidayIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkHolidayIsActive.Visible), 5, 0), true);
         divHolidayisactive_cell_Class = "Invisible";
         AssignProp("", false, divHolidayisactive_cell_Internalname, "Class", divHolidayisactive_cell_Class, true);
      }

      protected void ZM0G18( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z114HolidayName = T000G3_A114HolidayName[0];
               Z115HolidayStartDate = T000G3_A115HolidayStartDate[0];
               Z116HolidayEndDate = T000G3_A116HolidayEndDate[0];
               Z117HolidayServiceId = T000G3_A117HolidayServiceId[0];
               Z139HolidayIsActive = T000G3_A139HolidayIsActive[0];
               Z100CompanyId = T000G3_A100CompanyId[0];
            }
            else
            {
               Z114HolidayName = A114HolidayName;
               Z115HolidayStartDate = A115HolidayStartDate;
               Z116HolidayEndDate = A116HolidayEndDate;
               Z117HolidayServiceId = A117HolidayServiceId;
               Z139HolidayIsActive = A139HolidayIsActive;
               Z100CompanyId = A100CompanyId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z113HolidayId = A113HolidayId;
            Z114HolidayName = A114HolidayName;
            Z115HolidayStartDate = A115HolidayStartDate;
            Z116HolidayEndDate = A116HolidayEndDate;
            Z117HolidayServiceId = A117HolidayServiceId;
            Z139HolidayIsActive = A139HolidayIsActive;
            Z100CompanyId = A100CompanyId;
            Z157CompanyLocationId = A157CompanyLocationId;
            Z159CompanyLocationCode = A159CompanyLocationCode;
         }
      }

      protected void standaloneNotModal( )
      {
         edtHolidayId_Enabled = 0;
         AssignProp("", false, edtHolidayId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHolidayId_Enabled), 5, 0), true);
         chkHolidayIsActive.Visible = ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? 1 : 0);
         AssignProp("", false, chkHolidayIsActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkHolidayIsActive.Visible), 5, 0), true);
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            divHolidayisactive_cell_Class = "Invisible";
            AssignProp("", false, divHolidayisactive_cell_Internalname, "Class", divHolidayisactive_cell_Class, true);
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               divHolidayisactive_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
               AssignProp("", false, divHolidayisactive_cell_Internalname, "Class", divHolidayisactive_cell_Class, true);
            }
         }
         AV24Pgmname = "Holiday";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtHolidayId_Enabled = 0;
         AssignProp("", false, edtHolidayId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHolidayId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7HolidayId) )
         {
            A113HolidayId = AV7HolidayId;
            AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
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
            GXt_int1 = A100CompanyId;
            new getloggedinusercompanyid(context ).execute( out  GXt_int1) ;
            A100CompanyId = GXt_int1;
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
         if ( IsIns( )  && (false==A139HolidayIsActive) && ( Gx_BScreen == 0 ) )
         {
            A139HolidayIsActive = true;
            AssignAttri("", false, "A139HolidayIsActive", A139HolidayIsActive);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000G4 */
            pr_default.execute(2, new Object[] {A100CompanyId});
            A157CompanyLocationId = T000G4_A157CompanyLocationId[0];
            pr_default.close(2);
            /* Using cursor T000G5 */
            pr_default.execute(3, new Object[] {A157CompanyLocationId});
            A159CompanyLocationCode = T000G5_A159CompanyLocationCode[0];
            pr_default.close(3);
         }
      }

      protected void Load0G18( )
      {
         /* Using cursor T000G6 */
         pr_default.execute(4, new Object[] {A113HolidayId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound18 = 1;
            A157CompanyLocationId = T000G6_A157CompanyLocationId[0];
            A114HolidayName = T000G6_A114HolidayName[0];
            AssignAttri("", false, "A114HolidayName", A114HolidayName);
            A115HolidayStartDate = T000G6_A115HolidayStartDate[0];
            AssignAttri("", false, "A115HolidayStartDate", context.localUtil.Format(A115HolidayStartDate, "99/99/99"));
            A116HolidayEndDate = T000G6_A116HolidayEndDate[0];
            n116HolidayEndDate = T000G6_n116HolidayEndDate[0];
            AssignAttri("", false, "A116HolidayEndDate", context.localUtil.Format(A116HolidayEndDate, "99/99/99"));
            A117HolidayServiceId = T000G6_A117HolidayServiceId[0];
            n117HolidayServiceId = T000G6_n117HolidayServiceId[0];
            AssignAttri("", false, "A117HolidayServiceId", A117HolidayServiceId);
            A159CompanyLocationCode = T000G6_A159CompanyLocationCode[0];
            A139HolidayIsActive = T000G6_A139HolidayIsActive[0];
            AssignAttri("", false, "A139HolidayIsActive", A139HolidayIsActive);
            A100CompanyId = T000G6_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            ZM0G18( -13) ;
         }
         pr_default.close(4);
         OnLoadActions0G18( ) ;
      }

      protected void OnLoadActions0G18( )
      {
      }

      protected void CheckExtendedTable0G18( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000G7 */
         pr_default.execute(5, new Object[] {n117HolidayServiceId, A117HolidayServiceId, A113HolidayId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Holiday Service Id"}), 1, "HOLIDAYSERVICEID");
            AnyError = 1;
            GX_FocusControl = edtHolidayServiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A114HolidayName)) )
         {
            GX_msglist.addItem("Holiday Name cannot be empty", 1, "HOLIDAYNAME");
            AnyError = 1;
            GX_FocusControl = edtHolidayName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A115HolidayStartDate) )
         {
            GX_msglist.addItem("Holiday start date cannot be empty", 1, "HOLIDAYSTARTDATE");
            AnyError = 1;
            GX_FocusControl = edtHolidayStartDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000G4 */
         pr_default.execute(2, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A157CompanyLocationId = T000G4_A157CompanyLocationId[0];
         pr_default.close(2);
         /* Using cursor T000G5 */
         pr_default.execute(3, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'CompanyLocation'.", "ForeignKeyNotFound", 1, "COMPANYLOCATIONID");
            AnyError = 1;
         }
         A159CompanyLocationCode = T000G5_A159CompanyLocationCode[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0G18( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( long A100CompanyId )
      {
         /* Using cursor T000G8 */
         pr_default.execute(6, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A157CompanyLocationId = T000G8_A157CompanyLocationId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A157CompanyLocationId), 10, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_16( long A157CompanyLocationId )
      {
         /* Using cursor T000G9 */
         pr_default.execute(7, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'CompanyLocation'.", "ForeignKeyNotFound", 1, "COMPANYLOCATIONID");
            AnyError = 1;
         }
         A159CompanyLocationCode = T000G9_A159CompanyLocationCode[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A159CompanyLocationCode))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey0G18( )
      {
         /* Using cursor T000G10 */
         pr_default.execute(8, new Object[] {A113HolidayId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G3 */
         pr_default.execute(1, new Object[] {A113HolidayId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G18( 13) ;
            RcdFound18 = 1;
            A113HolidayId = T000G3_A113HolidayId[0];
            AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
            A114HolidayName = T000G3_A114HolidayName[0];
            AssignAttri("", false, "A114HolidayName", A114HolidayName);
            A115HolidayStartDate = T000G3_A115HolidayStartDate[0];
            AssignAttri("", false, "A115HolidayStartDate", context.localUtil.Format(A115HolidayStartDate, "99/99/99"));
            A116HolidayEndDate = T000G3_A116HolidayEndDate[0];
            n116HolidayEndDate = T000G3_n116HolidayEndDate[0];
            AssignAttri("", false, "A116HolidayEndDate", context.localUtil.Format(A116HolidayEndDate, "99/99/99"));
            A117HolidayServiceId = T000G3_A117HolidayServiceId[0];
            n117HolidayServiceId = T000G3_n117HolidayServiceId[0];
            AssignAttri("", false, "A117HolidayServiceId", A117HolidayServiceId);
            A139HolidayIsActive = T000G3_A139HolidayIsActive[0];
            AssignAttri("", false, "A139HolidayIsActive", A139HolidayIsActive);
            A100CompanyId = T000G3_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            Z113HolidayId = A113HolidayId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0G18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0G18( ) ;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0G18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G18( ) ;
         if ( RcdFound18 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound18 = 0;
         /* Using cursor T000G11 */
         pr_default.execute(9, new Object[] {A113HolidayId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000G11_A113HolidayId[0] < A113HolidayId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000G11_A113HolidayId[0] > A113HolidayId ) ) )
            {
               A113HolidayId = T000G11_A113HolidayId[0];
               AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound18 = 0;
         /* Using cursor T000G12 */
         pr_default.execute(10, new Object[] {A113HolidayId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000G12_A113HolidayId[0] > A113HolidayId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000G12_A113HolidayId[0] < A113HolidayId ) ) )
            {
               A113HolidayId = T000G12_A113HolidayId[0];
               AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtHolidayName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G18( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( A113HolidayId != Z113HolidayId )
               {
                  A113HolidayId = Z113HolidayId;
                  AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "HOLIDAYID");
                  AnyError = 1;
                  GX_FocusControl = edtHolidayId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtHolidayName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0G18( ) ;
                  GX_FocusControl = edtHolidayName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A113HolidayId != Z113HolidayId )
               {
                  /* Insert record */
                  GX_FocusControl = edtHolidayName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G18( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "HOLIDAYID");
                     AnyError = 1;
                     GX_FocusControl = edtHolidayId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtHolidayName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G18( ) ;
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
         if ( A113HolidayId != Z113HolidayId )
         {
            A113HolidayId = Z113HolidayId;
            AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "HOLIDAYID");
            AnyError = 1;
            GX_FocusControl = edtHolidayId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtHolidayName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0G18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_default.execute(0, new Object[] {A113HolidayId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Holiday"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z114HolidayName, T000G2_A114HolidayName[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z115HolidayStartDate ) != DateTimeUtil.ResetTime ( T000G2_A115HolidayStartDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z116HolidayEndDate ) != DateTimeUtil.ResetTime ( T000G2_A116HolidayEndDate[0] ) ) || ( StringUtil.StrCmp(Z117HolidayServiceId, T000G2_A117HolidayServiceId[0]) != 0 ) || ( Z139HolidayIsActive != T000G2_A139HolidayIsActive[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z100CompanyId != T000G2_A100CompanyId[0] ) )
            {
               if ( StringUtil.StrCmp(Z114HolidayName, T000G2_A114HolidayName[0]) != 0 )
               {
                  GXUtil.WriteLog("holiday:[seudo value changed for attri]"+"HolidayName");
                  GXUtil.WriteLogRaw("Old: ",Z114HolidayName);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A114HolidayName[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z115HolidayStartDate ) != DateTimeUtil.ResetTime ( T000G2_A115HolidayStartDate[0] ) )
               {
                  GXUtil.WriteLog("holiday:[seudo value changed for attri]"+"HolidayStartDate");
                  GXUtil.WriteLogRaw("Old: ",Z115HolidayStartDate);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A115HolidayStartDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z116HolidayEndDate ) != DateTimeUtil.ResetTime ( T000G2_A116HolidayEndDate[0] ) )
               {
                  GXUtil.WriteLog("holiday:[seudo value changed for attri]"+"HolidayEndDate");
                  GXUtil.WriteLogRaw("Old: ",Z116HolidayEndDate);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A116HolidayEndDate[0]);
               }
               if ( StringUtil.StrCmp(Z117HolidayServiceId, T000G2_A117HolidayServiceId[0]) != 0 )
               {
                  GXUtil.WriteLog("holiday:[seudo value changed for attri]"+"HolidayServiceId");
                  GXUtil.WriteLogRaw("Old: ",Z117HolidayServiceId);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A117HolidayServiceId[0]);
               }
               if ( Z139HolidayIsActive != T000G2_A139HolidayIsActive[0] )
               {
                  GXUtil.WriteLog("holiday:[seudo value changed for attri]"+"HolidayIsActive");
                  GXUtil.WriteLogRaw("Old: ",Z139HolidayIsActive);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A139HolidayIsActive[0]);
               }
               if ( Z100CompanyId != T000G2_A100CompanyId[0] )
               {
                  GXUtil.WriteLog("holiday:[seudo value changed for attri]"+"CompanyId");
                  GXUtil.WriteLogRaw("Old: ",Z100CompanyId);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A100CompanyId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Holiday"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G18( )
      {
         if ( ! IsAuthorized("holiday_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G18( 0) ;
            CheckOptimisticConcurrency0G18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G13 */
                     pr_default.execute(11, new Object[] {A114HolidayName, A115HolidayStartDate, n116HolidayEndDate, A116HolidayEndDate, n117HolidayServiceId, A117HolidayServiceId, A139HolidayIsActive, A100CompanyId});
                     pr_default.close(11);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000G14 */
                     pr_default.execute(12);
                     A113HolidayId = T000G14_A113HolidayId[0];
                     AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Holiday");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0G0( ) ;
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
               Load0G18( ) ;
            }
            EndLevel0G18( ) ;
         }
         CloseExtendedTableCursors0G18( ) ;
      }

      protected void Update0G18( )
      {
         if ( ! IsAuthorized("holiday_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G15 */
                     pr_default.execute(13, new Object[] {A114HolidayName, A115HolidayStartDate, n116HolidayEndDate, A116HolidayEndDate, n117HolidayServiceId, A117HolidayServiceId, A139HolidayIsActive, A100CompanyId, A113HolidayId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Holiday");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Holiday"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G18( ) ;
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
            EndLevel0G18( ) ;
         }
         CloseExtendedTableCursors0G18( ) ;
      }

      protected void DeferredUpdate0G18( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("holiday_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G18( ) ;
            AfterConfirm0G18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G16 */
                  pr_default.execute(14, new Object[] {A113HolidayId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("Holiday");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G18( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G18( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000G17 */
            pr_default.execute(15, new Object[] {A100CompanyId});
            A157CompanyLocationId = T000G17_A157CompanyLocationId[0];
            pr_default.close(15);
            /* Using cursor T000G18 */
            pr_default.execute(16, new Object[] {A157CompanyLocationId});
            A159CompanyLocationCode = T000G18_A159CompanyLocationCode[0];
            pr_default.close(16);
         }
      }

      protected void EndLevel0G18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G18( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("holiday",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("holiday",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G18( )
      {
         /* Scan By routine */
         /* Using cursor T000G19 */
         pr_default.execute(17);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound18 = 1;
            A113HolidayId = T000G19_A113HolidayId[0];
            AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G18( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound18 = 1;
            A113HolidayId = T000G19_A113HolidayId[0];
            AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
         }
      }

      protected void ScanEnd0G18( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0G18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G18( )
      {
         edtHolidayName_Enabled = 0;
         AssignProp("", false, edtHolidayName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHolidayName_Enabled), 5, 0), true);
         edtHolidayStartDate_Enabled = 0;
         AssignProp("", false, edtHolidayStartDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHolidayStartDate_Enabled), 5, 0), true);
         chkHolidayIsActive.Enabled = 0;
         AssignProp("", false, chkHolidayIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkHolidayIsActive.Enabled), 5, 0), true);
         edtHolidayId_Enabled = 0;
         AssignProp("", false, edtHolidayId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHolidayId_Enabled), 5, 0), true);
         edtHolidayEndDate_Enabled = 0;
         AssignProp("", false, edtHolidayEndDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHolidayEndDate_Enabled), 5, 0), true);
         edtHolidayServiceId_Enabled = 0;
         AssignProp("", false, edtHolidayServiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHolidayServiceId_Enabled), 5, 0), true);
         edtCompanyId_Enabled = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0G18( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0G0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("holiday.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7HolidayId,10,0))}, new string[] {"Gx_mode","HolidayId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Holiday");
         forbiddenHiddens.Add("HolidayId", context.localUtil.Format( (decimal)(A113HolidayId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("holiday:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z113HolidayId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z113HolidayId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z114HolidayName", StringUtil.RTrim( Z114HolidayName));
         GxWebStd.gx_hidden_field( context, "Z115HolidayStartDate", context.localUtil.DToC( Z115HolidayStartDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z116HolidayEndDate", context.localUtil.DToC( Z116HolidayEndDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z117HolidayServiceId", StringUtil.RTrim( Z117HolidayServiceId));
         GxWebStd.gx_boolean_hidden_field( context, "Z139HolidayIsActive", Z139HolidayIsActive);
         GxWebStd.gx_hidden_field( context, "Z100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vHOLIDAYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7HolidayId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vHOLIDAYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7HolidayId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_COMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMPANYLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A157CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMPANYLOCATIONCODE", StringUtil.RTrim( A159CompanyLocationCode));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV24Pgmname));
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
         return formatLink("holiday.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7HolidayId,10,0))}, new string[] {"Gx_mode","HolidayId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Holiday" ;
      }

      public override string GetPgmdesc( )
      {
         return "National Holidays" ;
      }

      protected void InitializeNonKey0G18( )
      {
         A157CompanyLocationId = 0;
         AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
         A100CompanyId = 0;
         AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         A114HolidayName = "";
         AssignAttri("", false, "A114HolidayName", A114HolidayName);
         A115HolidayStartDate = DateTime.MinValue;
         AssignAttri("", false, "A115HolidayStartDate", context.localUtil.Format(A115HolidayStartDate, "99/99/99"));
         A116HolidayEndDate = DateTime.MinValue;
         n116HolidayEndDate = false;
         AssignAttri("", false, "A116HolidayEndDate", context.localUtil.Format(A116HolidayEndDate, "99/99/99"));
         n116HolidayEndDate = ((DateTime.MinValue==A116HolidayEndDate) ? true : false);
         A117HolidayServiceId = "";
         n117HolidayServiceId = false;
         AssignAttri("", false, "A117HolidayServiceId", A117HolidayServiceId);
         n117HolidayServiceId = (String.IsNullOrEmpty(StringUtil.RTrim( A117HolidayServiceId)) ? true : false);
         A159CompanyLocationCode = "";
         AssignAttri("", false, "A159CompanyLocationCode", A159CompanyLocationCode);
         A139HolidayIsActive = true;
         AssignAttri("", false, "A139HolidayIsActive", A139HolidayIsActive);
         Z114HolidayName = "";
         Z115HolidayStartDate = DateTime.MinValue;
         Z116HolidayEndDate = DateTime.MinValue;
         Z117HolidayServiceId = "";
         Z139HolidayIsActive = false;
         Z100CompanyId = 0;
      }

      protected void InitAll0G18( )
      {
         A113HolidayId = 0;
         AssignAttri("", false, "A113HolidayId", StringUtil.LTrimStr( (decimal)(A113HolidayId), 10, 0));
         InitializeNonKey0G18( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A139HolidayIsActive = i139HolidayIsActive;
         AssignAttri("", false, "A139HolidayIsActive", A139HolidayIsActive);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267491189", true, true);
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
         context.AddJavascriptSource("holiday.js", "?20256267491192", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtHolidayName_Internalname = "HOLIDAYNAME";
         edtHolidayStartDate_Internalname = "HOLIDAYSTARTDATE";
         chkHolidayIsActive_Internalname = "HOLIDAYISACTIVE";
         divHolidayisactive_cell_Internalname = "HOLIDAYISACTIVE_CELL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtHolidayId_Internalname = "HOLIDAYID";
         edtHolidayEndDate_Internalname = "HOLIDAYENDDATE";
         edtHolidayServiceId_Internalname = "HOLIDAYSERVICEID";
         edtCompanyId_Internalname = "COMPANYID";
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
         Form.Caption = "National Holidays";
         edtCompanyId_Jsonclick = "";
         edtCompanyId_Enabled = 1;
         edtCompanyId_Visible = 1;
         edtHolidayServiceId_Jsonclick = "";
         edtHolidayServiceId_Enabled = 1;
         edtHolidayServiceId_Visible = 1;
         edtHolidayEndDate_Jsonclick = "";
         edtHolidayEndDate_Enabled = 1;
         edtHolidayEndDate_Visible = 1;
         edtHolidayId_Jsonclick = "";
         edtHolidayId_Enabled = 0;
         edtHolidayId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkHolidayIsActive.Enabled = 1;
         chkHolidayIsActive.Visible = 1;
         divHolidayisactive_cell_Class = "col-xs-12 col-sm-6";
         edtHolidayStartDate_Jsonclick = "";
         edtHolidayStartDate_Enabled = 1;
         edtHolidayName_Jsonclick = "";
         edtHolidayName_Enabled = 1;
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

      protected void GX5ASACOMPANYID0G18( long AV13Insert_CompanyId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            A100CompanyId = AV13Insert_CompanyId;
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         else
         {
            GXt_int1 = A100CompanyId;
            new getloggedinusercompanyid(context ).execute( out  GXt_int1) ;
            A100CompanyId = GXt_int1;
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")))+"\"") ;
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
         chkHolidayIsActive.Name = "HOLIDAYISACTIVE";
         chkHolidayIsActive.WebTags = "";
         chkHolidayIsActive.Caption = "Active";
         AssignProp("", false, chkHolidayIsActive_Internalname, "TitleCaption", chkHolidayIsActive.Caption, true);
         chkHolidayIsActive.CheckedValue = "false";
         if ( IsIns( ) && (false==A139HolidayIsActive) )
         {
            A139HolidayIsActive = true;
            AssignAttri("", false, "A139HolidayIsActive", A139HolidayIsActive);
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

      public void Valid_Holidayserviceid( )
      {
         n117HolidayServiceId = false;
         /* Using cursor T000G20 */
         pr_default.execute(18, new Object[] {n117HolidayServiceId, A117HolidayServiceId, A113HolidayId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Holiday Service Id"}), 1, "HOLIDAYSERVICEID");
            AnyError = 1;
            GX_FocusControl = edtHolidayServiceId_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Companyid( )
      {
         /* Using cursor T000G17 */
         pr_default.execute(15, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
         }
         A157CompanyLocationId = T000G17_A157CompanyLocationId[0];
         pr_default.close(15);
         /* Using cursor T000G18 */
         pr_default.execute(16, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'CompanyLocation'.", "ForeignKeyNotFound", 1, "COMPANYLOCATIONID");
            AnyError = 1;
         }
         A159CompanyLocationCode = T000G18_A159CompanyLocationCode[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A157CompanyLocationId), 10, 0, ".", "")));
         AssignAttri("", false, "A159CompanyLocationCode", StringUtil.RTrim( A159CompanyLocationCode));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7HolidayId","fld":"vHOLIDAYID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7HolidayId","fld":"vHOLIDAYID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A113HolidayId","fld":"HOLIDAYID","pic":"ZZZZZZZZZ9"},{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120G2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]}""");
         setEventMetadata("VALID_HOLIDAYNAME","""{"handler":"Valid_Holidayname","iparms":[{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]""");
         setEventMetadata("VALID_HOLIDAYNAME",""","oparms":[{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]}""");
         setEventMetadata("VALID_HOLIDAYSTARTDATE","""{"handler":"Valid_Holidaystartdate","iparms":[{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]""");
         setEventMetadata("VALID_HOLIDAYSTARTDATE",""","oparms":[{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]}""");
         setEventMetadata("VALID_HOLIDAYID","""{"handler":"Valid_Holidayid","iparms":[{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]""");
         setEventMetadata("VALID_HOLIDAYID",""","oparms":[{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]}""");
         setEventMetadata("VALID_HOLIDAYSERVICEID","""{"handler":"Valid_Holidayserviceid","iparms":[{"av":"A117HolidayServiceId","fld":"HOLIDAYSERVICEID"},{"av":"A113HolidayId","fld":"HOLIDAYID","pic":"ZZZZZZZZZ9"},{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]""");
         setEventMetadata("VALID_HOLIDAYSERVICEID",""","oparms":[{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]}""");
         setEventMetadata("VALID_COMPANYID","""{"handler":"Valid_Companyid","iparms":[{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A159CompanyLocationCode","fld":"COMPANYLOCATIONCODE"},{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]""");
         setEventMetadata("VALID_COMPANYID",""","oparms":[{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"},{"av":"A159CompanyLocationCode","fld":"COMPANYLOCATIONCODE"},{"av":"A139HolidayIsActive","fld":"HOLIDAYISACTIVE"}]}""");
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
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z114HolidayName = "";
         Z115HolidayStartDate = DateTime.MinValue;
         Z116HolidayEndDate = DateTime.MinValue;
         Z117HolidayServiceId = "";
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
         A114HolidayName = "";
         A115HolidayStartDate = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A116HolidayEndDate = DateTime.MinValue;
         A117HolidayServiceId = "";
         A159CompanyLocationCode = "";
         AV24Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode18 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z159CompanyLocationCode = "";
         T000G4_A157CompanyLocationId = new long[1] ;
         T000G5_A159CompanyLocationCode = new string[] {""} ;
         T000G6_A157CompanyLocationId = new long[1] ;
         T000G6_A113HolidayId = new long[1] ;
         T000G6_A114HolidayName = new string[] {""} ;
         T000G6_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         T000G6_A116HolidayEndDate = new DateTime[] {DateTime.MinValue} ;
         T000G6_n116HolidayEndDate = new bool[] {false} ;
         T000G6_A117HolidayServiceId = new string[] {""} ;
         T000G6_n117HolidayServiceId = new bool[] {false} ;
         T000G6_A159CompanyLocationCode = new string[] {""} ;
         T000G6_A139HolidayIsActive = new bool[] {false} ;
         T000G6_A100CompanyId = new long[1] ;
         T000G7_A117HolidayServiceId = new string[] {""} ;
         T000G7_n117HolidayServiceId = new bool[] {false} ;
         T000G8_A157CompanyLocationId = new long[1] ;
         T000G9_A159CompanyLocationCode = new string[] {""} ;
         T000G10_A113HolidayId = new long[1] ;
         T000G3_A113HolidayId = new long[1] ;
         T000G3_A114HolidayName = new string[] {""} ;
         T000G3_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         T000G3_A116HolidayEndDate = new DateTime[] {DateTime.MinValue} ;
         T000G3_n116HolidayEndDate = new bool[] {false} ;
         T000G3_A117HolidayServiceId = new string[] {""} ;
         T000G3_n117HolidayServiceId = new bool[] {false} ;
         T000G3_A139HolidayIsActive = new bool[] {false} ;
         T000G3_A100CompanyId = new long[1] ;
         T000G11_A113HolidayId = new long[1] ;
         T000G12_A113HolidayId = new long[1] ;
         T000G2_A113HolidayId = new long[1] ;
         T000G2_A114HolidayName = new string[] {""} ;
         T000G2_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         T000G2_A116HolidayEndDate = new DateTime[] {DateTime.MinValue} ;
         T000G2_n116HolidayEndDate = new bool[] {false} ;
         T000G2_A117HolidayServiceId = new string[] {""} ;
         T000G2_n117HolidayServiceId = new bool[] {false} ;
         T000G2_A139HolidayIsActive = new bool[] {false} ;
         T000G2_A100CompanyId = new long[1] ;
         T000G14_A113HolidayId = new long[1] ;
         T000G17_A157CompanyLocationId = new long[1] ;
         T000G18_A159CompanyLocationCode = new string[] {""} ;
         T000G19_A113HolidayId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000G20_A117HolidayServiceId = new string[] {""} ;
         T000G20_n117HolidayServiceId = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.holiday__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.holiday__default(),
            new Object[][] {
                new Object[] {
               T000G2_A113HolidayId, T000G2_A114HolidayName, T000G2_A115HolidayStartDate, T000G2_A116HolidayEndDate, T000G2_n116HolidayEndDate, T000G2_A117HolidayServiceId, T000G2_n117HolidayServiceId, T000G2_A139HolidayIsActive, T000G2_A100CompanyId
               }
               , new Object[] {
               T000G3_A113HolidayId, T000G3_A114HolidayName, T000G3_A115HolidayStartDate, T000G3_A116HolidayEndDate, T000G3_n116HolidayEndDate, T000G3_A117HolidayServiceId, T000G3_n117HolidayServiceId, T000G3_A139HolidayIsActive, T000G3_A100CompanyId
               }
               , new Object[] {
               T000G4_A157CompanyLocationId
               }
               , new Object[] {
               T000G5_A159CompanyLocationCode
               }
               , new Object[] {
               T000G6_A157CompanyLocationId, T000G6_A113HolidayId, T000G6_A114HolidayName, T000G6_A115HolidayStartDate, T000G6_A116HolidayEndDate, T000G6_n116HolidayEndDate, T000G6_A117HolidayServiceId, T000G6_n117HolidayServiceId, T000G6_A159CompanyLocationCode, T000G6_A139HolidayIsActive,
               T000G6_A100CompanyId
               }
               , new Object[] {
               T000G7_A117HolidayServiceId, T000G7_n117HolidayServiceId
               }
               , new Object[] {
               T000G8_A157CompanyLocationId
               }
               , new Object[] {
               T000G9_A159CompanyLocationCode
               }
               , new Object[] {
               T000G10_A113HolidayId
               }
               , new Object[] {
               T000G11_A113HolidayId
               }
               , new Object[] {
               T000G12_A113HolidayId
               }
               , new Object[] {
               }
               , new Object[] {
               T000G14_A113HolidayId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G17_A157CompanyLocationId
               }
               , new Object[] {
               T000G18_A159CompanyLocationCode
               }
               , new Object[] {
               T000G19_A113HolidayId
               }
               , new Object[] {
               T000G20_A117HolidayServiceId, T000G20_n117HolidayServiceId
               }
            }
         );
         AV24Pgmname = "Holiday";
         Z139HolidayIsActive = true;
         A139HolidayIsActive = true;
         i139HolidayIsActive = true;
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound18 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtHolidayName_Enabled ;
      private int edtHolidayStartDate_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtHolidayId_Enabled ;
      private int edtHolidayId_Visible ;
      private int edtHolidayEndDate_Visible ;
      private int edtHolidayEndDate_Enabled ;
      private int edtHolidayServiceId_Visible ;
      private int edtHolidayServiceId_Enabled ;
      private int edtCompanyId_Visible ;
      private int edtCompanyId_Enabled ;
      private int AV25GXV1 ;
      private int idxLst ;
      private long wcpOAV7HolidayId ;
      private long Z113HolidayId ;
      private long Z100CompanyId ;
      private long N100CompanyId ;
      private long AV13Insert_CompanyId ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long AV7HolidayId ;
      private long A113HolidayId ;
      private long Z157CompanyLocationId ;
      private long GXt_int1 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z114HolidayName ;
      private string Z117HolidayServiceId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtHolidayName_Internalname ;
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
      private string TempTags ;
      private string A114HolidayName ;
      private string edtHolidayName_Jsonclick ;
      private string edtHolidayStartDate_Internalname ;
      private string edtHolidayStartDate_Jsonclick ;
      private string divHolidayisactive_cell_Internalname ;
      private string divHolidayisactive_cell_Class ;
      private string chkHolidayIsActive_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtHolidayId_Internalname ;
      private string edtHolidayId_Jsonclick ;
      private string edtHolidayEndDate_Internalname ;
      private string edtHolidayEndDate_Jsonclick ;
      private string edtHolidayServiceId_Internalname ;
      private string A117HolidayServiceId ;
      private string edtHolidayServiceId_Jsonclick ;
      private string edtCompanyId_Internalname ;
      private string edtCompanyId_Jsonclick ;
      private string A159CompanyLocationCode ;
      private string AV24Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode18 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z159CompanyLocationCode ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z115HolidayStartDate ;
      private DateTime Z116HolidayEndDate ;
      private DateTime A115HolidayStartDate ;
      private DateTime A116HolidayEndDate ;
      private bool Z139HolidayIsActive ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A139HolidayIsActive ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n116HolidayEndDate ;
      private bool n117HolidayServiceId ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i139HolidayIsActive ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkHolidayIsActive ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] T000G4_A157CompanyLocationId ;
      private string[] T000G5_A159CompanyLocationCode ;
      private long[] T000G6_A157CompanyLocationId ;
      private long[] T000G6_A113HolidayId ;
      private string[] T000G6_A114HolidayName ;
      private DateTime[] T000G6_A115HolidayStartDate ;
      private DateTime[] T000G6_A116HolidayEndDate ;
      private bool[] T000G6_n116HolidayEndDate ;
      private string[] T000G6_A117HolidayServiceId ;
      private bool[] T000G6_n117HolidayServiceId ;
      private string[] T000G6_A159CompanyLocationCode ;
      private bool[] T000G6_A139HolidayIsActive ;
      private long[] T000G6_A100CompanyId ;
      private string[] T000G7_A117HolidayServiceId ;
      private bool[] T000G7_n117HolidayServiceId ;
      private long[] T000G8_A157CompanyLocationId ;
      private string[] T000G9_A159CompanyLocationCode ;
      private long[] T000G10_A113HolidayId ;
      private long[] T000G3_A113HolidayId ;
      private string[] T000G3_A114HolidayName ;
      private DateTime[] T000G3_A115HolidayStartDate ;
      private DateTime[] T000G3_A116HolidayEndDate ;
      private bool[] T000G3_n116HolidayEndDate ;
      private string[] T000G3_A117HolidayServiceId ;
      private bool[] T000G3_n117HolidayServiceId ;
      private bool[] T000G3_A139HolidayIsActive ;
      private long[] T000G3_A100CompanyId ;
      private long[] T000G11_A113HolidayId ;
      private long[] T000G12_A113HolidayId ;
      private long[] T000G2_A113HolidayId ;
      private string[] T000G2_A114HolidayName ;
      private DateTime[] T000G2_A115HolidayStartDate ;
      private DateTime[] T000G2_A116HolidayEndDate ;
      private bool[] T000G2_n116HolidayEndDate ;
      private string[] T000G2_A117HolidayServiceId ;
      private bool[] T000G2_n117HolidayServiceId ;
      private bool[] T000G2_A139HolidayIsActive ;
      private long[] T000G2_A100CompanyId ;
      private long[] T000G14_A113HolidayId ;
      private long[] T000G17_A157CompanyLocationId ;
      private string[] T000G18_A159CompanyLocationCode ;
      private long[] T000G19_A113HolidayId ;
      private string[] T000G20_A117HolidayServiceId ;
      private bool[] T000G20_n117HolidayServiceId ;
      private IDataStoreProvider pr_gam ;
   }

   public class holiday__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class holiday__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000G2;
        prmT000G2 = new Object[] {
        new ParDef("HolidayId",GXType.Int64,10,0)
        };
        Object[] prmT000G3;
        prmT000G3 = new Object[] {
        new ParDef("HolidayId",GXType.Int64,10,0)
        };
        Object[] prmT000G4;
        prmT000G4 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000G5;
        prmT000G5 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000G6;
        prmT000G6 = new Object[] {
        new ParDef("HolidayId",GXType.Int64,10,0)
        };
        Object[] prmT000G7;
        prmT000G7 = new Object[] {
        new ParDef("HolidayServiceId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("HolidayId",GXType.Int64,10,0)
        };
        Object[] prmT000G8;
        prmT000G8 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000G9;
        prmT000G9 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000G10;
        prmT000G10 = new Object[] {
        new ParDef("HolidayId",GXType.Int64,10,0)
        };
        Object[] prmT000G11;
        prmT000G11 = new Object[] {
        new ParDef("HolidayId",GXType.Int64,10,0)
        };
        Object[] prmT000G12;
        prmT000G12 = new Object[] {
        new ParDef("HolidayId",GXType.Int64,10,0)
        };
        Object[] prmT000G13;
        prmT000G13 = new Object[] {
        new ParDef("HolidayName",GXType.Char,100,0) ,
        new ParDef("HolidayStartDate",GXType.Date,8,0) ,
        new ParDef("HolidayEndDate",GXType.Date,8,0){Nullable=true} ,
        new ParDef("HolidayServiceId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("HolidayIsActive",GXType.Boolean,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000G14;
        prmT000G14 = new Object[] {
        };
        Object[] prmT000G15;
        prmT000G15 = new Object[] {
        new ParDef("HolidayName",GXType.Char,100,0) ,
        new ParDef("HolidayStartDate",GXType.Date,8,0) ,
        new ParDef("HolidayEndDate",GXType.Date,8,0){Nullable=true} ,
        new ParDef("HolidayServiceId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("HolidayIsActive",GXType.Boolean,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0) ,
        new ParDef("HolidayId",GXType.Int64,10,0)
        };
        Object[] prmT000G16;
        prmT000G16 = new Object[] {
        new ParDef("HolidayId",GXType.Int64,10,0)
        };
        Object[] prmT000G17;
        prmT000G17 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000G18;
        prmT000G18 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000G19;
        prmT000G19 = new Object[] {
        };
        Object[] prmT000G20;
        prmT000G20 = new Object[] {
        new ParDef("HolidayServiceId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("HolidayId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000G2", "SELECT HolidayId, HolidayName, HolidayStartDate, HolidayEndDate, HolidayServiceId, HolidayIsActive, CompanyId FROM Holiday WHERE HolidayId = :HolidayId  FOR UPDATE OF Holiday NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G3", "SELECT HolidayId, HolidayName, HolidayStartDate, HolidayEndDate, HolidayServiceId, HolidayIsActive, CompanyId FROM Holiday WHERE HolidayId = :HolidayId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G4", "SELECT CompanyLocationId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G5", "SELECT CompanyLocationCode FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G6", "SELECT T2.CompanyLocationId, TM1.HolidayId, TM1.HolidayName, TM1.HolidayStartDate, TM1.HolidayEndDate, TM1.HolidayServiceId, T3.CompanyLocationCode, TM1.HolidayIsActive, TM1.CompanyId FROM ((Holiday TM1 INNER JOIN Company T2 ON T2.CompanyId = TM1.CompanyId) INNER JOIN CompanyLocation T3 ON T3.CompanyLocationId = T2.CompanyLocationId) WHERE TM1.HolidayId = :HolidayId ORDER BY TM1.HolidayId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G7", "SELECT HolidayServiceId FROM Holiday WHERE (HolidayServiceId = :HolidayServiceId) AND (Not ( HolidayId = :HolidayId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G8", "SELECT CompanyLocationId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G9", "SELECT CompanyLocationCode FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G10", "SELECT HolidayId FROM Holiday WHERE HolidayId = :HolidayId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G11", "SELECT HolidayId FROM Holiday WHERE ( HolidayId > :HolidayId) ORDER BY HolidayId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G12", "SELECT HolidayId FROM Holiday WHERE ( HolidayId < :HolidayId) ORDER BY HolidayId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G13", "SAVEPOINT gxupdate;INSERT INTO Holiday(HolidayName, HolidayStartDate, HolidayEndDate, HolidayServiceId, HolidayIsActive, CompanyId) VALUES(:HolidayName, :HolidayStartDate, :HolidayEndDate, :HolidayServiceId, :HolidayIsActive, :CompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000G13)
           ,new CursorDef("T000G14", "SELECT currval('HolidayId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G15", "SAVEPOINT gxupdate;UPDATE Holiday SET HolidayName=:HolidayName, HolidayStartDate=:HolidayStartDate, HolidayEndDate=:HolidayEndDate, HolidayServiceId=:HolidayServiceId, HolidayIsActive=:HolidayIsActive, CompanyId=:CompanyId  WHERE HolidayId = :HolidayId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G15)
           ,new CursorDef("T000G16", "SAVEPOINT gxupdate;DELETE FROM Holiday  WHERE HolidayId = :HolidayId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G16)
           ,new CursorDef("T000G17", "SELECT CompanyLocationId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G18", "SELECT CompanyLocationCode FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G19", "SELECT HolidayId FROM Holiday ORDER BY HolidayId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G20", "SELECT HolidayServiceId FROM Holiday WHERE (HolidayServiceId = :HolidayServiceId) AND (Not ( HolidayId = :HolidayId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G20,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((bool[]) buf[7])[0] = rslt.getBool(6);
              ((long[]) buf[8])[0] = rslt.getLong(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((bool[]) buf[7])[0] = rslt.getBool(6);
              ((long[]) buf[8])[0] = rslt.getLong(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 40);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 20);
              ((bool[]) buf[9])[0] = rslt.getBool(8);
              ((long[]) buf[10])[0] = rslt.getLong(9);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
     }
  }

}

}
