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
   public class leaverequestaction : GXDataArea
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
            A127LeaveRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A127LeaveRequestId) ;
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
         Form.Meta.addItem("description", "Leave Request Action", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLeaveRequestActionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public leaverequestaction( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestaction( IGxContext context )
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
         cmbLeaveRequestActionType = new GXCombobox();
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
            return "leaverequestaction_Execute" ;
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
         if ( cmbLeaveRequestActionType.ItemCount > 0 )
         {
            A203LeaveRequestActionType = cmbLeaveRequestActionType.getValidValue(A203LeaveRequestActionType);
            AssignAttri("", false, "A203LeaveRequestActionType", A203LeaveRequestActionType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbLeaveRequestActionType.CurrentValue = StringUtil.RTrim( A203LeaveRequestActionType);
            AssignProp("", false, cmbLeaveRequestActionType_Internalname, "Values", cmbLeaveRequestActionType.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Leave Request Action", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_LeaveRequestAction.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_LeaveRequestAction.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveRequestActionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLeaveRequestActionId_Internalname, "Action Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLeaveRequestActionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A201LeaveRequestActionId), 10, 0, ".", "")), StringUtil.LTrim( ((edtLeaveRequestActionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A201LeaveRequestActionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A201LeaveRequestActionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestActionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLeaveRequestActionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LeaveRequestAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveRequestActionDateTime_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLeaveRequestActionDateTime_Internalname, "Date Time", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLeaveRequestActionDateTime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLeaveRequestActionDateTime_Internalname, context.localUtil.TToC( A202LeaveRequestActionDateTime, 10, 8, 1, 3, "/", ":", " "), context.localUtil.Format( A202LeaveRequestActionDateTime, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestActionDateTime_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLeaveRequestActionDateTime_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LeaveRequestAction.htm");
         GxWebStd.gx_bitmap( context, edtLeaveRequestActionDateTime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLeaveRequestActionDateTime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LeaveRequestAction.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbLeaveRequestActionType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbLeaveRequestActionType_Internalname, "Action Type", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbLeaveRequestActionType, cmbLeaveRequestActionType_Internalname, StringUtil.RTrim( A203LeaveRequestActionType), 1, cmbLeaveRequestActionType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbLeaveRequestActionType.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_LeaveRequestAction.htm");
         cmbLeaveRequestActionType.CurrentValue = StringUtil.RTrim( A203LeaveRequestActionType);
         AssignProp("", false, cmbLeaveRequestActionType_Internalname, "Values", (string)(cmbLeaveRequestActionType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveActionGAMUserGUID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLeaveActionGAMUserGUID_Internalname, "GAMUser GUID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLeaveActionGAMUserGUID_Internalname, A199LeaveActionGAMUserGUID.ToString(), A199LeaveActionGAMUserGUID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveActionGAMUserGUID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLeaveActionGAMUserGUID_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_LeaveRequestAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveRequestId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLeaveRequestId_Internalname, "Leave Request Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLeaveRequestId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", "")), StringUtil.LTrim( ((edtLeaveRequestId_Enabled!=0) ? context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A127LeaveRequestId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveRequestId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLeaveRequestId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LeaveRequestAction.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestAction.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveRequestAction.htm");
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
            Z201LeaveRequestActionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z201LeaveRequestActionId"), ".", ","), 18, MidpointRounding.ToEven));
            Z202LeaveRequestActionDateTime = context.localUtil.CToT( cgiGet( "Z202LeaveRequestActionDateTime"), 0);
            Z203LeaveRequestActionType = cgiGet( "Z203LeaveRequestActionType");
            Z199LeaveActionGAMUserGUID = StringUtil.StrToGuid( cgiGet( "Z199LeaveActionGAMUserGUID"));
            Z127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z127LeaveRequestId"), ".", ","), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtLeaveRequestActionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLeaveRequestActionId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUESTACTIONID");
               AnyError = 1;
               GX_FocusControl = edtLeaveRequestActionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A201LeaveRequestActionId = 0;
               AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
            }
            else
            {
               A201LeaveRequestActionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveRequestActionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtLeaveRequestActionDateTime_Internalname), 2, 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Leave Request Action Date Time"}), 1, "LEAVEREQUESTACTIONDATETIME");
               AnyError = 1;
               GX_FocusControl = edtLeaveRequestActionDateTime_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A202LeaveRequestActionDateTime = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A202LeaveRequestActionDateTime", context.localUtil.TToC( A202LeaveRequestActionDateTime, 8, 5, 1, 3, "/", ":", " "));
            }
            else
            {
               A202LeaveRequestActionDateTime = context.localUtil.CToT( cgiGet( edtLeaveRequestActionDateTime_Internalname));
               AssignAttri("", false, "A202LeaveRequestActionDateTime", context.localUtil.TToC( A202LeaveRequestActionDateTime, 8, 5, 1, 3, "/", ":", " "));
            }
            cmbLeaveRequestActionType.CurrentValue = cgiGet( cmbLeaveRequestActionType_Internalname);
            A203LeaveRequestActionType = cgiGet( cmbLeaveRequestActionType_Internalname);
            AssignAttri("", false, "A203LeaveRequestActionType", A203LeaveRequestActionType);
            if ( StringUtil.StrCmp(cgiGet( edtLeaveActionGAMUserGUID_Internalname), "") == 0 )
            {
               A199LeaveActionGAMUserGUID = Guid.Empty;
               AssignAttri("", false, "A199LeaveActionGAMUserGUID", A199LeaveActionGAMUserGUID.ToString());
            }
            else
            {
               try
               {
                  A199LeaveActionGAMUserGUID = StringUtil.StrToGuid( cgiGet( edtLeaveActionGAMUserGUID_Internalname));
                  AssignAttri("", false, "A199LeaveActionGAMUserGUID", A199LeaveActionGAMUserGUID.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "LEAVEACTIONGAMUSERGUID");
                  AnyError = 1;
                  GX_FocusControl = edtLeaveActionGAMUserGUID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLeaveRequestId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLeaveRequestId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUESTID");
               AnyError = 1;
               GX_FocusControl = edtLeaveRequestId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A127LeaveRequestId = 0;
               AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
            }
            else
            {
               A127LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveRequestId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
            }
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
               A201LeaveRequestActionId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestActionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
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
               InitAll0S31( ) ;
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
         DisableAttributes0S31( ) ;
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

      protected void ResetCaption0S0( )
      {
      }

      protected void ZM0S31( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z202LeaveRequestActionDateTime = T000S3_A202LeaveRequestActionDateTime[0];
               Z203LeaveRequestActionType = T000S3_A203LeaveRequestActionType[0];
               Z199LeaveActionGAMUserGUID = T000S3_A199LeaveActionGAMUserGUID[0];
               Z127LeaveRequestId = T000S3_A127LeaveRequestId[0];
            }
            else
            {
               Z202LeaveRequestActionDateTime = A202LeaveRequestActionDateTime;
               Z203LeaveRequestActionType = A203LeaveRequestActionType;
               Z199LeaveActionGAMUserGUID = A199LeaveActionGAMUserGUID;
               Z127LeaveRequestId = A127LeaveRequestId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z201LeaveRequestActionId = A201LeaveRequestActionId;
            Z202LeaveRequestActionDateTime = A202LeaveRequestActionDateTime;
            Z203LeaveRequestActionType = A203LeaveRequestActionType;
            Z199LeaveActionGAMUserGUID = A199LeaveActionGAMUserGUID;
            Z127LeaveRequestId = A127LeaveRequestId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A199LeaveActionGAMUserGUID) && ( Gx_BScreen == 0 ) )
         {
            A199LeaveActionGAMUserGUID = Guid.NewGuid( );
            AssignAttri("", false, "A199LeaveActionGAMUserGUID", A199LeaveActionGAMUserGUID.ToString());
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

      protected void Load0S31( )
      {
         /* Using cursor T000S5 */
         pr_default.execute(3, new Object[] {A201LeaveRequestActionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound31 = 1;
            A202LeaveRequestActionDateTime = T000S5_A202LeaveRequestActionDateTime[0];
            AssignAttri("", false, "A202LeaveRequestActionDateTime", context.localUtil.TToC( A202LeaveRequestActionDateTime, 8, 5, 1, 3, "/", ":", " "));
            A203LeaveRequestActionType = T000S5_A203LeaveRequestActionType[0];
            AssignAttri("", false, "A203LeaveRequestActionType", A203LeaveRequestActionType);
            A199LeaveActionGAMUserGUID = T000S5_A199LeaveActionGAMUserGUID[0];
            AssignAttri("", false, "A199LeaveActionGAMUserGUID", A199LeaveActionGAMUserGUID.ToString());
            A127LeaveRequestId = T000S5_A127LeaveRequestId[0];
            AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
            ZM0S31( -4) ;
         }
         pr_default.close(3);
         OnLoadActions0S31( ) ;
      }

      protected void OnLoadActions0S31( )
      {
      }

      protected void CheckExtendedTable0S31( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A203LeaveRequestActionType, "Request") == 0 ) || ( StringUtil.StrCmp(A203LeaveRequestActionType, "Rejection") == 0 ) || ( StringUtil.StrCmp(A203LeaveRequestActionType, "Approval") == 0 ) || ( StringUtil.StrCmp(A203LeaveRequestActionType, "Update") == 0 ) ) )
         {
            GX_msglist.addItem("Field Leave Request Action Type is out of range", "OutOfRange", 1, "LEAVEREQUESTACTIONTYPE");
            AnyError = 1;
            GX_FocusControl = cmbLeaveRequestActionType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000S4 */
         pr_default.execute(2, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'LeaveRequest'.", "ForeignKeyNotFound", 1, "LEAVEREQUESTID");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0S31( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( long A127LeaveRequestId )
      {
         /* Using cursor T000S6 */
         pr_default.execute(4, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'LeaveRequest'.", "ForeignKeyNotFound", 1, "LEAVEREQUESTID");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestId_Internalname;
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

      protected void GetKey0S31( )
      {
         /* Using cursor T000S7 */
         pr_default.execute(5, new Object[] {A201LeaveRequestActionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound31 = 1;
         }
         else
         {
            RcdFound31 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000S3 */
         pr_default.execute(1, new Object[] {A201LeaveRequestActionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0S31( 4) ;
            RcdFound31 = 1;
            A201LeaveRequestActionId = T000S3_A201LeaveRequestActionId[0];
            AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
            A202LeaveRequestActionDateTime = T000S3_A202LeaveRequestActionDateTime[0];
            AssignAttri("", false, "A202LeaveRequestActionDateTime", context.localUtil.TToC( A202LeaveRequestActionDateTime, 8, 5, 1, 3, "/", ":", " "));
            A203LeaveRequestActionType = T000S3_A203LeaveRequestActionType[0];
            AssignAttri("", false, "A203LeaveRequestActionType", A203LeaveRequestActionType);
            A199LeaveActionGAMUserGUID = T000S3_A199LeaveActionGAMUserGUID[0];
            AssignAttri("", false, "A199LeaveActionGAMUserGUID", A199LeaveActionGAMUserGUID.ToString());
            A127LeaveRequestId = T000S3_A127LeaveRequestId[0];
            AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
            Z201LeaveRequestActionId = A201LeaveRequestActionId;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0S31( ) ;
            if ( AnyError == 1 )
            {
               RcdFound31 = 0;
               InitializeNonKey0S31( ) ;
            }
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound31 = 0;
            InitializeNonKey0S31( ) ;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0S31( ) ;
         if ( RcdFound31 == 0 )
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
         RcdFound31 = 0;
         /* Using cursor T000S8 */
         pr_default.execute(6, new Object[] {A201LeaveRequestActionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000S8_A201LeaveRequestActionId[0] < A201LeaveRequestActionId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000S8_A201LeaveRequestActionId[0] > A201LeaveRequestActionId ) ) )
            {
               A201LeaveRequestActionId = T000S8_A201LeaveRequestActionId[0];
               AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
               RcdFound31 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound31 = 0;
         /* Using cursor T000S9 */
         pr_default.execute(7, new Object[] {A201LeaveRequestActionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000S9_A201LeaveRequestActionId[0] > A201LeaveRequestActionId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000S9_A201LeaveRequestActionId[0] < A201LeaveRequestActionId ) ) )
            {
               A201LeaveRequestActionId = T000S9_A201LeaveRequestActionId[0];
               AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
               RcdFound31 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0S31( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLeaveRequestActionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0S31( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound31 == 1 )
            {
               if ( A201LeaveRequestActionId != Z201LeaveRequestActionId )
               {
                  A201LeaveRequestActionId = Z201LeaveRequestActionId;
                  AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LEAVEREQUESTACTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtLeaveRequestActionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLeaveRequestActionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0S31( ) ;
                  GX_FocusControl = edtLeaveRequestActionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A201LeaveRequestActionId != Z201LeaveRequestActionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLeaveRequestActionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0S31( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LEAVEREQUESTACTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtLeaveRequestActionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLeaveRequestActionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0S31( ) ;
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
         if ( A201LeaveRequestActionId != Z201LeaveRequestActionId )
         {
            A201LeaveRequestActionId = Z201LeaveRequestActionId;
            AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LEAVEREQUESTACTIONID");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestActionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLeaveRequestActionId_Internalname;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LEAVEREQUESTACTIONID");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestActionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLeaveRequestActionDateTime_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0S31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLeaveRequestActionDateTime_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0S31( ) ;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLeaveRequestActionDateTime_Internalname;
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
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLeaveRequestActionDateTime_Internalname;
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
         ScanStart0S31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound31 != 0 )
            {
               ScanNext0S31( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLeaveRequestActionDateTime_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0S31( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0S31( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000S2 */
            pr_default.execute(0, new Object[] {A201LeaveRequestActionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LeaveRequestAction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z202LeaveRequestActionDateTime != T000S2_A202LeaveRequestActionDateTime[0] ) || ( StringUtil.StrCmp(Z203LeaveRequestActionType, T000S2_A203LeaveRequestActionType[0]) != 0 ) || ( Z199LeaveActionGAMUserGUID != T000S2_A199LeaveActionGAMUserGUID[0] ) || ( Z127LeaveRequestId != T000S2_A127LeaveRequestId[0] ) )
            {
               if ( Z202LeaveRequestActionDateTime != T000S2_A202LeaveRequestActionDateTime[0] )
               {
                  GXUtil.WriteLog("leaverequestaction:[seudo value changed for attri]"+"LeaveRequestActionDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z202LeaveRequestActionDateTime);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A202LeaveRequestActionDateTime[0]);
               }
               if ( StringUtil.StrCmp(Z203LeaveRequestActionType, T000S2_A203LeaveRequestActionType[0]) != 0 )
               {
                  GXUtil.WriteLog("leaverequestaction:[seudo value changed for attri]"+"LeaveRequestActionType");
                  GXUtil.WriteLogRaw("Old: ",Z203LeaveRequestActionType);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A203LeaveRequestActionType[0]);
               }
               if ( Z199LeaveActionGAMUserGUID != T000S2_A199LeaveActionGAMUserGUID[0] )
               {
                  GXUtil.WriteLog("leaverequestaction:[seudo value changed for attri]"+"LeaveActionGAMUserGUID");
                  GXUtil.WriteLogRaw("Old: ",Z199LeaveActionGAMUserGUID);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A199LeaveActionGAMUserGUID[0]);
               }
               if ( Z127LeaveRequestId != T000S2_A127LeaveRequestId[0] )
               {
                  GXUtil.WriteLog("leaverequestaction:[seudo value changed for attri]"+"LeaveRequestId");
                  GXUtil.WriteLogRaw("Old: ",Z127LeaveRequestId);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A127LeaveRequestId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LeaveRequestAction"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S31( )
      {
         if ( ! IsAuthorized("leaverequestaction_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0S31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S31( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S31( 0) ;
            CheckOptimisticConcurrency0S31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S10 */
                     pr_default.execute(8, new Object[] {A202LeaveRequestActionDateTime, A203LeaveRequestActionType, A199LeaveActionGAMUserGUID, A127LeaveRequestId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000S11 */
                     pr_default.execute(9);
                     A201LeaveRequestActionId = T000S11_A201LeaveRequestActionId[0];
                     AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("LeaveRequestAction");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0S0( ) ;
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
               Load0S31( ) ;
            }
            EndLevel0S31( ) ;
         }
         CloseExtendedTableCursors0S31( ) ;
      }

      protected void Update0S31( )
      {
         if ( ! IsAuthorized("leaverequestaction_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0S31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S31( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S12 */
                     pr_default.execute(10, new Object[] {A202LeaveRequestActionDateTime, A203LeaveRequestActionType, A199LeaveActionGAMUserGUID, A127LeaveRequestId, A201LeaveRequestActionId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("LeaveRequestAction");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LeaveRequestAction"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S31( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0S0( ) ;
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
            EndLevel0S31( ) ;
         }
         CloseExtendedTableCursors0S31( ) ;
      }

      protected void DeferredUpdate0S31( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("leaverequestaction_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0S31( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S31( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S31( ) ;
            AfterConfirm0S31( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S31( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000S13 */
                  pr_default.execute(11, new Object[] {A201LeaveRequestActionId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("LeaveRequestAction");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound31 == 0 )
                        {
                           InitAll0S31( ) ;
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
                        ResetCaption0S0( ) ;
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
         sMode31 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0S31( ) ;
         Gx_mode = sMode31;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0S31( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0S31( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0S31( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("leaverequestaction",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("leaverequestaction",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0S31( )
      {
         /* Using cursor T000S14 */
         pr_default.execute(12);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound31 = 1;
            A201LeaveRequestActionId = T000S14_A201LeaveRequestActionId[0];
            AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0S31( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound31 = 1;
            A201LeaveRequestActionId = T000S14_A201LeaveRequestActionId[0];
            AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
         }
      }

      protected void ScanEnd0S31( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0S31( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S31( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S31( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S31( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S31( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S31( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S31( )
      {
         edtLeaveRequestActionId_Enabled = 0;
         AssignProp("", false, edtLeaveRequestActionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestActionId_Enabled), 5, 0), true);
         edtLeaveRequestActionDateTime_Enabled = 0;
         AssignProp("", false, edtLeaveRequestActionDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestActionDateTime_Enabled), 5, 0), true);
         cmbLeaveRequestActionType.Enabled = 0;
         AssignProp("", false, cmbLeaveRequestActionType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbLeaveRequestActionType.Enabled), 5, 0), true);
         edtLeaveActionGAMUserGUID_Enabled = 0;
         AssignProp("", false, edtLeaveActionGAMUserGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveActionGAMUserGUID_Enabled), 5, 0), true);
         edtLeaveRequestId_Enabled = 0;
         AssignProp("", false, edtLeaveRequestId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveRequestId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0S31( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0S0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leaverequestaction.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z201LeaveRequestActionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z201LeaveRequestActionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z202LeaveRequestActionDateTime", context.localUtil.TToC( Z202LeaveRequestActionDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z203LeaveRequestActionType", Z203LeaveRequestActionType);
         GxWebStd.gx_hidden_field( context, "Z199LeaveActionGAMUserGUID", Z199LeaveActionGAMUserGUID.ToString());
         GxWebStd.gx_hidden_field( context, "Z127LeaveRequestId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127LeaveRequestId), 10, 0, ".", "")));
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
         return formatLink("leaverequestaction.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "LeaveRequestAction" ;
      }

      public override string GetPgmdesc( )
      {
         return "Leave Request Action" ;
      }

      protected void InitializeNonKey0S31( )
      {
         A202LeaveRequestActionDateTime = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A202LeaveRequestActionDateTime", context.localUtil.TToC( A202LeaveRequestActionDateTime, 8, 5, 1, 3, "/", ":", " "));
         A203LeaveRequestActionType = "";
         AssignAttri("", false, "A203LeaveRequestActionType", A203LeaveRequestActionType);
         A127LeaveRequestId = 0;
         AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrimStr( (decimal)(A127LeaveRequestId), 10, 0));
         A199LeaveActionGAMUserGUID = Guid.NewGuid( );
         AssignAttri("", false, "A199LeaveActionGAMUserGUID", A199LeaveActionGAMUserGUID.ToString());
         Z202LeaveRequestActionDateTime = (DateTime)(DateTime.MinValue);
         Z203LeaveRequestActionType = "";
         Z199LeaveActionGAMUserGUID = Guid.Empty;
         Z127LeaveRequestId = 0;
      }

      protected void InitAll0S31( )
      {
         A201LeaveRequestActionId = 0;
         AssignAttri("", false, "A201LeaveRequestActionId", StringUtil.LTrimStr( (decimal)(A201LeaveRequestActionId), 10, 0));
         InitializeNonKey0S31( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A199LeaveActionGAMUserGUID = i199LeaveActionGAMUserGUID;
         AssignAttri("", false, "A199LeaveActionGAMUserGUID", A199LeaveActionGAMUserGUID.ToString());
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20259317281615", true, true);
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
         context.AddJavascriptSource("leaverequestaction.js", "?20259317281616", false, true);
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
         edtLeaveRequestActionId_Internalname = "LEAVEREQUESTACTIONID";
         edtLeaveRequestActionDateTime_Internalname = "LEAVEREQUESTACTIONDATETIME";
         cmbLeaveRequestActionType_Internalname = "LEAVEREQUESTACTIONTYPE";
         edtLeaveActionGAMUserGUID_Internalname = "LEAVEACTIONGAMUSERGUID";
         edtLeaveRequestId_Internalname = "LEAVEREQUESTID";
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
         Form.Caption = "Leave Request Action";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLeaveRequestId_Jsonclick = "";
         edtLeaveRequestId_Enabled = 1;
         edtLeaveActionGAMUserGUID_Jsonclick = "";
         edtLeaveActionGAMUserGUID_Enabled = 1;
         cmbLeaveRequestActionType_Jsonclick = "";
         cmbLeaveRequestActionType.Enabled = 1;
         edtLeaveRequestActionDateTime_Jsonclick = "";
         edtLeaveRequestActionDateTime_Enabled = 1;
         edtLeaveRequestActionId_Jsonclick = "";
         edtLeaveRequestActionId_Enabled = 1;
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
         cmbLeaveRequestActionType.Name = "LEAVEREQUESTACTIONTYPE";
         cmbLeaveRequestActionType.WebTags = "";
         cmbLeaveRequestActionType.addItem("Request", "Request", 0);
         cmbLeaveRequestActionType.addItem("Rejection", "Rejection", 0);
         cmbLeaveRequestActionType.addItem("Approval", "Approval", 0);
         cmbLeaveRequestActionType.addItem("Update", "Update", 0);
         if ( cmbLeaveRequestActionType.ItemCount > 0 )
         {
            A203LeaveRequestActionType = cmbLeaveRequestActionType.getValidValue(A203LeaveRequestActionType);
            AssignAttri("", false, "A203LeaveRequestActionType", A203LeaveRequestActionType);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtLeaveRequestActionDateTime_Internalname;
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

      public void Valid_Leaverequestactionid( )
      {
         A203LeaveRequestActionType = cmbLeaveRequestActionType.CurrentValue;
         cmbLeaveRequestActionType.CurrentValue = A203LeaveRequestActionType;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbLeaveRequestActionType.ItemCount > 0 )
         {
            A203LeaveRequestActionType = cmbLeaveRequestActionType.getValidValue(A203LeaveRequestActionType);
            cmbLeaveRequestActionType.CurrentValue = A203LeaveRequestActionType;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbLeaveRequestActionType.CurrentValue = StringUtil.RTrim( A203LeaveRequestActionType);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A202LeaveRequestActionDateTime", context.localUtil.TToC( A202LeaveRequestActionDateTime, 10, 8, 1, 3, "/", ":", " "));
         AssignAttri("", false, "A203LeaveRequestActionType", A203LeaveRequestActionType);
         cmbLeaveRequestActionType.CurrentValue = StringUtil.RTrim( A203LeaveRequestActionType);
         AssignProp("", false, cmbLeaveRequestActionType_Internalname, "Values", cmbLeaveRequestActionType.ToJavascriptSource(), true);
         AssignAttri("", false, "A199LeaveActionGAMUserGUID", A199LeaveActionGAMUserGUID.ToString());
         AssignAttri("", false, "A127LeaveRequestId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127LeaveRequestId), 10, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z201LeaveRequestActionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z201LeaveRequestActionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z202LeaveRequestActionDateTime", context.localUtil.TToC( Z202LeaveRequestActionDateTime, 10, 8, 1, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z203LeaveRequestActionType", Z203LeaveRequestActionType);
         GxWebStd.gx_hidden_field( context, "Z199LeaveActionGAMUserGUID", Z199LeaveActionGAMUserGUID.ToString());
         GxWebStd.gx_hidden_field( context, "Z127LeaveRequestId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127LeaveRequestId), 10, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Leaverequestid( )
      {
         /* Using cursor T000S15 */
         pr_default.execute(13, new Object[] {A127LeaveRequestId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No matching 'LeaveRequest'.", "ForeignKeyNotFound", 1, "LEAVEREQUESTID");
            AnyError = 1;
            GX_FocusControl = edtLeaveRequestId_Internalname;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_LEAVEREQUESTACTIONID","""{"handler":"Valid_Leaverequestactionid","iparms":[{"av":"cmbLeaveRequestActionType"},{"av":"A203LeaveRequestActionType","fld":"LEAVEREQUESTACTIONTYPE"},{"av":"A201LeaveRequestActionId","fld":"LEAVEREQUESTACTIONID","pic":"ZZZZZZZZZ9"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A199LeaveActionGAMUserGUID","fld":"LEAVEACTIONGAMUSERGUID"}]""");
         setEventMetadata("VALID_LEAVEREQUESTACTIONID",""","oparms":[{"av":"A202LeaveRequestActionDateTime","fld":"LEAVEREQUESTACTIONDATETIME","pic":"99/99/99 99:99"},{"av":"cmbLeaveRequestActionType"},{"av":"A203LeaveRequestActionType","fld":"LEAVEREQUESTACTIONTYPE"},{"av":"A199LeaveActionGAMUserGUID","fld":"LEAVEACTIONGAMUSERGUID"},{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z201LeaveRequestActionId"},{"av":"Z202LeaveRequestActionDateTime"},{"av":"Z203LeaveRequestActionType"},{"av":"Z199LeaveActionGAMUserGUID"},{"av":"Z127LeaveRequestId"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_LEAVEREQUESTACTIONTYPE","""{"handler":"Valid_Leaverequestactiontype","iparms":[]}""");
         setEventMetadata("VALID_LEAVEACTIONGAMUSERGUID","""{"handler":"Valid_Leaveactiongamuserguid","iparms":[]}""");
         setEventMetadata("VALID_LEAVEREQUESTID","""{"handler":"Valid_Leaverequestid","iparms":[{"av":"A127LeaveRequestId","fld":"LEAVEREQUESTID","pic":"ZZZZZZZZZ9"}]}""");
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
         Z202LeaveRequestActionDateTime = (DateTime)(DateTime.MinValue);
         Z203LeaveRequestActionType = "";
         Z199LeaveActionGAMUserGUID = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A203LeaveRequestActionType = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A202LeaveRequestActionDateTime = (DateTime)(DateTime.MinValue);
         A199LeaveActionGAMUserGUID = Guid.Empty;
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
         T000S5_A201LeaveRequestActionId = new long[1] ;
         T000S5_A202LeaveRequestActionDateTime = new DateTime[] {DateTime.MinValue} ;
         T000S5_A203LeaveRequestActionType = new string[] {""} ;
         T000S5_A199LeaveActionGAMUserGUID = new Guid[] {Guid.Empty} ;
         T000S5_A127LeaveRequestId = new long[1] ;
         T000S4_A127LeaveRequestId = new long[1] ;
         T000S6_A127LeaveRequestId = new long[1] ;
         T000S7_A201LeaveRequestActionId = new long[1] ;
         T000S3_A201LeaveRequestActionId = new long[1] ;
         T000S3_A202LeaveRequestActionDateTime = new DateTime[] {DateTime.MinValue} ;
         T000S3_A203LeaveRequestActionType = new string[] {""} ;
         T000S3_A199LeaveActionGAMUserGUID = new Guid[] {Guid.Empty} ;
         T000S3_A127LeaveRequestId = new long[1] ;
         sMode31 = "";
         T000S8_A201LeaveRequestActionId = new long[1] ;
         T000S9_A201LeaveRequestActionId = new long[1] ;
         T000S2_A201LeaveRequestActionId = new long[1] ;
         T000S2_A202LeaveRequestActionDateTime = new DateTime[] {DateTime.MinValue} ;
         T000S2_A203LeaveRequestActionType = new string[] {""} ;
         T000S2_A199LeaveActionGAMUserGUID = new Guid[] {Guid.Empty} ;
         T000S2_A127LeaveRequestId = new long[1] ;
         T000S11_A201LeaveRequestActionId = new long[1] ;
         T000S14_A201LeaveRequestActionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i199LeaveActionGAMUserGUID = Guid.Empty;
         ZZ202LeaveRequestActionDateTime = (DateTime)(DateTime.MinValue);
         ZZ203LeaveRequestActionType = "";
         ZZ199LeaveActionGAMUserGUID = Guid.Empty;
         T000S15_A127LeaveRequestId = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.leaverequestaction__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestaction__default(),
            new Object[][] {
                new Object[] {
               T000S2_A201LeaveRequestActionId, T000S2_A202LeaveRequestActionDateTime, T000S2_A203LeaveRequestActionType, T000S2_A199LeaveActionGAMUserGUID, T000S2_A127LeaveRequestId
               }
               , new Object[] {
               T000S3_A201LeaveRequestActionId, T000S3_A202LeaveRequestActionDateTime, T000S3_A203LeaveRequestActionType, T000S3_A199LeaveActionGAMUserGUID, T000S3_A127LeaveRequestId
               }
               , new Object[] {
               T000S4_A127LeaveRequestId
               }
               , new Object[] {
               T000S5_A201LeaveRequestActionId, T000S5_A202LeaveRequestActionDateTime, T000S5_A203LeaveRequestActionType, T000S5_A199LeaveActionGAMUserGUID, T000S5_A127LeaveRequestId
               }
               , new Object[] {
               T000S6_A127LeaveRequestId
               }
               , new Object[] {
               T000S7_A201LeaveRequestActionId
               }
               , new Object[] {
               T000S8_A201LeaveRequestActionId
               }
               , new Object[] {
               T000S9_A201LeaveRequestActionId
               }
               , new Object[] {
               }
               , new Object[] {
               T000S11_A201LeaveRequestActionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000S14_A201LeaveRequestActionId
               }
               , new Object[] {
               T000S15_A127LeaveRequestId
               }
            }
         );
         Z199LeaveActionGAMUserGUID = Guid.NewGuid( );
         A199LeaveActionGAMUserGUID = Guid.NewGuid( );
         i199LeaveActionGAMUserGUID = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound31 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLeaveRequestActionId_Enabled ;
      private int edtLeaveRequestActionDateTime_Enabled ;
      private int edtLeaveActionGAMUserGUID_Enabled ;
      private int edtLeaveRequestId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z201LeaveRequestActionId ;
      private long Z127LeaveRequestId ;
      private long A127LeaveRequestId ;
      private long A201LeaveRequestActionId ;
      private long ZZ201LeaveRequestActionId ;
      private long ZZ127LeaveRequestId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLeaveRequestActionId_Internalname ;
      private string cmbLeaveRequestActionType_Internalname ;
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
      private string edtLeaveRequestActionId_Jsonclick ;
      private string edtLeaveRequestActionDateTime_Internalname ;
      private string edtLeaveRequestActionDateTime_Jsonclick ;
      private string cmbLeaveRequestActionType_Jsonclick ;
      private string edtLeaveActionGAMUserGUID_Internalname ;
      private string edtLeaveActionGAMUserGUID_Jsonclick ;
      private string edtLeaveRequestId_Internalname ;
      private string edtLeaveRequestId_Jsonclick ;
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
      private string sMode31 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z202LeaveRequestActionDateTime ;
      private DateTime A202LeaveRequestActionDateTime ;
      private DateTime ZZ202LeaveRequestActionDateTime ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z203LeaveRequestActionType ;
      private string A203LeaveRequestActionType ;
      private string ZZ203LeaveRequestActionType ;
      private Guid Z199LeaveActionGAMUserGUID ;
      private Guid A199LeaveActionGAMUserGUID ;
      private Guid i199LeaveActionGAMUserGUID ;
      private Guid ZZ199LeaveActionGAMUserGUID ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbLeaveRequestActionType ;
      private IDataStoreProvider pr_default ;
      private long[] T000S5_A201LeaveRequestActionId ;
      private DateTime[] T000S5_A202LeaveRequestActionDateTime ;
      private string[] T000S5_A203LeaveRequestActionType ;
      private Guid[] T000S5_A199LeaveActionGAMUserGUID ;
      private long[] T000S5_A127LeaveRequestId ;
      private long[] T000S4_A127LeaveRequestId ;
      private long[] T000S6_A127LeaveRequestId ;
      private long[] T000S7_A201LeaveRequestActionId ;
      private long[] T000S3_A201LeaveRequestActionId ;
      private DateTime[] T000S3_A202LeaveRequestActionDateTime ;
      private string[] T000S3_A203LeaveRequestActionType ;
      private Guid[] T000S3_A199LeaveActionGAMUserGUID ;
      private long[] T000S3_A127LeaveRequestId ;
      private long[] T000S8_A201LeaveRequestActionId ;
      private long[] T000S9_A201LeaveRequestActionId ;
      private long[] T000S2_A201LeaveRequestActionId ;
      private DateTime[] T000S2_A202LeaveRequestActionDateTime ;
      private string[] T000S2_A203LeaveRequestActionType ;
      private Guid[] T000S2_A199LeaveActionGAMUserGUID ;
      private long[] T000S2_A127LeaveRequestId ;
      private long[] T000S11_A201LeaveRequestActionId ;
      private long[] T000S14_A201LeaveRequestActionId ;
      private long[] T000S15_A127LeaveRequestId ;
      private IDataStoreProvider pr_gam ;
   }

   public class leaverequestaction__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class leaverequestaction__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000S2;
        prmT000S2 = new Object[] {
        new ParDef("LeaveRequestActionId",GXType.Int64,10,0)
        };
        Object[] prmT000S3;
        prmT000S3 = new Object[] {
        new ParDef("LeaveRequestActionId",GXType.Int64,10,0)
        };
        Object[] prmT000S4;
        prmT000S4 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000S5;
        prmT000S5 = new Object[] {
        new ParDef("LeaveRequestActionId",GXType.Int64,10,0)
        };
        Object[] prmT000S6;
        prmT000S6 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000S7;
        prmT000S7 = new Object[] {
        new ParDef("LeaveRequestActionId",GXType.Int64,10,0)
        };
        Object[] prmT000S8;
        prmT000S8 = new Object[] {
        new ParDef("LeaveRequestActionId",GXType.Int64,10,0)
        };
        Object[] prmT000S9;
        prmT000S9 = new Object[] {
        new ParDef("LeaveRequestActionId",GXType.Int64,10,0)
        };
        Object[] prmT000S10;
        prmT000S10 = new Object[] {
        new ParDef("LeaveRequestActionDateTime",GXType.DateTime,8,5) ,
        new ParDef("LeaveRequestActionType",GXType.VarChar,40,0) ,
        new ParDef("LeaveActionGAMUserGUID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000S11;
        prmT000S11 = new Object[] {
        };
        Object[] prmT000S12;
        prmT000S12 = new Object[] {
        new ParDef("LeaveRequestActionDateTime",GXType.DateTime,8,5) ,
        new ParDef("LeaveRequestActionType",GXType.VarChar,40,0) ,
        new ParDef("LeaveActionGAMUserGUID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("LeaveRequestId",GXType.Int64,10,0) ,
        new ParDef("LeaveRequestActionId",GXType.Int64,10,0)
        };
        Object[] prmT000S13;
        prmT000S13 = new Object[] {
        new ParDef("LeaveRequestActionId",GXType.Int64,10,0)
        };
        Object[] prmT000S14;
        prmT000S14 = new Object[] {
        };
        Object[] prmT000S15;
        prmT000S15 = new Object[] {
        new ParDef("LeaveRequestId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000S2", "SELECT LeaveRequestActionId, LeaveRequestActionDateTime, LeaveRequestActionType, LeaveActionGAMUserGUID, LeaveRequestId FROM LeaveRequestAction WHERE LeaveRequestActionId = :LeaveRequestActionId  FOR UPDATE OF LeaveRequestAction NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S3", "SELECT LeaveRequestActionId, LeaveRequestActionDateTime, LeaveRequestActionType, LeaveActionGAMUserGUID, LeaveRequestId FROM LeaveRequestAction WHERE LeaveRequestActionId = :LeaveRequestActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S4", "SELECT LeaveRequestId FROM LeaveRequest WHERE LeaveRequestId = :LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S5", "SELECT TM1.LeaveRequestActionId, TM1.LeaveRequestActionDateTime, TM1.LeaveRequestActionType, TM1.LeaveActionGAMUserGUID, TM1.LeaveRequestId FROM LeaveRequestAction TM1 WHERE TM1.LeaveRequestActionId = :LeaveRequestActionId ORDER BY TM1.LeaveRequestActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S6", "SELECT LeaveRequestId FROM LeaveRequest WHERE LeaveRequestId = :LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S7", "SELECT LeaveRequestActionId FROM LeaveRequestAction WHERE LeaveRequestActionId = :LeaveRequestActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S8", "SELECT LeaveRequestActionId FROM LeaveRequestAction WHERE ( LeaveRequestActionId > :LeaveRequestActionId) ORDER BY LeaveRequestActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S9", "SELECT LeaveRequestActionId FROM LeaveRequestAction WHERE ( LeaveRequestActionId < :LeaveRequestActionId) ORDER BY LeaveRequestActionId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S10", "SAVEPOINT gxupdate;INSERT INTO LeaveRequestAction(LeaveRequestActionDateTime, LeaveRequestActionType, LeaveActionGAMUserGUID, LeaveRequestId) VALUES(:LeaveRequestActionDateTime, :LeaveRequestActionType, :LeaveActionGAMUserGUID, :LeaveRequestId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000S10)
           ,new CursorDef("T000S11", "SELECT currval('LeaveRequestActionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S12", "SAVEPOINT gxupdate;UPDATE LeaveRequestAction SET LeaveRequestActionDateTime=:LeaveRequestActionDateTime, LeaveRequestActionType=:LeaveRequestActionType, LeaveActionGAMUserGUID=:LeaveActionGAMUserGUID, LeaveRequestId=:LeaveRequestId  WHERE LeaveRequestActionId = :LeaveRequestActionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000S12)
           ,new CursorDef("T000S13", "SAVEPOINT gxupdate;DELETE FROM LeaveRequestAction  WHERE LeaveRequestActionId = :LeaveRequestActionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000S13)
           ,new CursorDef("T000S14", "SELECT LeaveRequestActionId FROM LeaveRequestAction ORDER BY LeaveRequestActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S15", "SELECT LeaveRequestId FROM LeaveRequest WHERE LeaveRequestId = :LeaveRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S15,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
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
