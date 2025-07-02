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
   public class leavetype : GXDataArea
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
            AV12Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "Insert_CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV12Insert_CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX5ASACOMPANYID0I20( AV12Insert_CompanyId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A100CompanyId) ;
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
               AV14LeaveTypeId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveTypeId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14LeaveTypeId", StringUtil.LTrimStr( (decimal)(AV14LeaveTypeId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vLEAVETYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14LeaveTypeId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Leave Types", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLeaveTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public leavetype( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leavetype( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_LeaveTypeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV14LeaveTypeId = aP1_LeaveTypeId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         radLeaveTypeVacationLeave = new GXRadio();
         radLeaveTypeLoggingWorkHours = new GXRadio();
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
            return "leavetype_Execute" ;
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
         A144LeaveTypeVacationLeave = StringUtil.RTrim( A144LeaveTypeVacationLeave);
         AssignAttri("", false, "A144LeaveTypeVacationLeave", A144LeaveTypeVacationLeave);
         A145LeaveTypeLoggingWorkHours = StringUtil.RTrim( A145LeaveTypeLoggingWorkHours);
         AssignAttri("", false, "A145LeaveTypeLoggingWorkHours", A145LeaveTypeLoggingWorkHours);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm col-md-3", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLefttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveTypeName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLeaveTypeName_Internalname, "Leave Type Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLeaveTypeName_Internalname, StringUtil.RTrim( A125LeaveTypeName), StringUtil.RTrim( context.localUtil.Format( A125LeaveTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveTypeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLeaveTypeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_LeaveType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLeaveTypeColorApproved_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLeaveTypeColorApproved_Internalname, "Approved Leave Color", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLeaveTypeColorApproved_Internalname, StringUtil.RTrim( A173LeaveTypeColorApproved), StringUtil.RTrim( context.localUtil.Format( A173LeaveTypeColorApproved, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveTypeColorApproved_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLeaveTypeColorApproved_Enabled, 0, "color", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "Color", "start", true, "", "HLP_LeaveType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radLeaveTypeVacationLeave_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Deduct from vacation days", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Radio button */
         ClassString = "Attribute";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_radio_ctrl( context, radLeaveTypeVacationLeave, radLeaveTypeVacationLeave_Internalname, StringUtil.RTrim( A144LeaveTypeVacationLeave), "", 1, radLeaveTypeVacationLeave.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radLeaveTypeVacationLeave_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "HLP_LeaveType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radLeaveTypeLoggingWorkHours_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Log Work Hours During Leave", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Radio button */
         ClassString = "Attribute";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_radio_ctrl( context, radLeaveTypeLoggingWorkHours, radLeaveTypeLoggingWorkHours_Internalname, StringUtil.RTrim( A145LeaveTypeLoggingWorkHours), "", 1, radLeaveTypeLoggingWorkHours.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radLeaveTypeLoggingWorkHours_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "HLP_LeaveType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_LeaveType.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm col-md-3", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divRighttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLeaveTypeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A124LeaveTypeId), 10, 0, ".", "")), StringUtil.LTrim( ((edtLeaveTypeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A124LeaveTypeId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A124LeaveTypeId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveTypeId_Jsonclick, 0, "Attribute", "", "", "", "", edtLeaveTypeId_Visible, edtLeaveTypeId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LeaveType.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCompanyId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompanyId_Jsonclick, 0, "Attribute", "", "", "", "", edtCompanyId_Visible, edtCompanyId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LeaveType.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLeaveTypeColorPending_Internalname, StringUtil.RTrim( A172LeaveTypeColorPending), StringUtil.RTrim( context.localUtil.Format( A172LeaveTypeColorPending, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLeaveTypeColorPending_Jsonclick, 0, "Attribute", "", "", "", "", edtLeaveTypeColorPending_Visible, edtLeaveTypeColorPending_Enabled, 0, "color", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "Color", "start", true, "", "HLP_LeaveType.htm");
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
         E110I2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z124LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z124LeaveTypeId"), ".", ","), 18, MidpointRounding.ToEven));
               Z125LeaveTypeName = cgiGet( "Z125LeaveTypeName");
               Z144LeaveTypeVacationLeave = cgiGet( "Z144LeaveTypeVacationLeave");
               Z145LeaveTypeLoggingWorkHours = cgiGet( "Z145LeaveTypeLoggingWorkHours");
               Z172LeaveTypeColorPending = cgiGet( "Z172LeaveTypeColorPending");
               n172LeaveTypeColorPending = (String.IsNullOrEmpty(StringUtil.RTrim( A172LeaveTypeColorPending)) ? true : false);
               Z173LeaveTypeColorApproved = cgiGet( "Z173LeaveTypeColorApproved");
               n173LeaveTypeColorApproved = (String.IsNullOrEmpty(StringUtil.RTrim( A173LeaveTypeColorApproved)) ? true : false);
               Z100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               N144LeaveTypeVacationLeave = cgiGet( "N144LeaveTypeVacationLeave");
               N145LeaveTypeLoggingWorkHours = cgiGet( "N145LeaveTypeLoggingWorkHours");
               AV14LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vLEAVETYPEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Insert_CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_COMPANYID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV24Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A125LeaveTypeName = cgiGet( edtLeaveTypeName_Internalname);
               AssignAttri("", false, "A125LeaveTypeName", A125LeaveTypeName);
               A173LeaveTypeColorApproved = cgiGet( edtLeaveTypeColorApproved_Internalname);
               n173LeaveTypeColorApproved = false;
               AssignAttri("", false, "A173LeaveTypeColorApproved", A173LeaveTypeColorApproved);
               n173LeaveTypeColorApproved = (String.IsNullOrEmpty(StringUtil.RTrim( A173LeaveTypeColorApproved)) ? true : false);
               A144LeaveTypeVacationLeave = cgiGet( radLeaveTypeVacationLeave_Internalname);
               AssignAttri("", false, "A144LeaveTypeVacationLeave", A144LeaveTypeVacationLeave);
               A145LeaveTypeLoggingWorkHours = cgiGet( radLeaveTypeLoggingWorkHours_Internalname);
               AssignAttri("", false, "A145LeaveTypeLoggingWorkHours", A145LeaveTypeLoggingWorkHours);
               A124LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
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
               A172LeaveTypeColorPending = cgiGet( edtLeaveTypeColorPending_Internalname);
               n172LeaveTypeColorPending = false;
               AssignAttri("", false, "A172LeaveTypeColorPending", A172LeaveTypeColorPending);
               n172LeaveTypeColorPending = (String.IsNullOrEmpty(StringUtil.RTrim( A172LeaveTypeColorPending)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"LeaveType");
               A124LeaveTypeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtLeaveTypeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
               forbiddenHiddens.Add("LeaveTypeId", context.localUtil.Format( (decimal)(A124LeaveTypeId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A124LeaveTypeId != Z124LeaveTypeId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("leavetype:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A124LeaveTypeId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveTypeId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
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
                     sMode20 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode20;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound20 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0I0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LEAVETYPEID");
                        AnyError = 1;
                        GX_FocusControl = edtLeaveTypeId_Internalname;
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
                           E110I2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120I2 ();
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
            E120I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0I20( ) ;
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
            DisableAttributes0I20( ) ;
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I20( ) ;
            }
            else
            {
               CheckExtendedTable0I20( ) ;
               CloseExtendedTableCursors0I20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0I0( )
      {
      }

      protected void E110I2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV7WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            while ( AV25GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CompanyId") == 0 )
               {
                  AV12Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV12Insert_CompanyId), 10, 0));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
               AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            }
         }
         edtLeaveTypeId_Visible = 0;
         AssignProp("", false, edtLeaveTypeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveTypeId_Visible), 5, 0), true);
         edtCompanyId_Visible = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCompanyId_Visible), 5, 0), true);
         edtLeaveTypeColorPending_Visible = 0;
         AssignProp("", false, edtLeaveTypeColorPending_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLeaveTypeColorPending_Visible), 5, 0), true);
      }

      protected void E120I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("leavetypeww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0I20( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z125LeaveTypeName = T000I3_A125LeaveTypeName[0];
               Z144LeaveTypeVacationLeave = T000I3_A144LeaveTypeVacationLeave[0];
               Z145LeaveTypeLoggingWorkHours = T000I3_A145LeaveTypeLoggingWorkHours[0];
               Z172LeaveTypeColorPending = T000I3_A172LeaveTypeColorPending[0];
               Z173LeaveTypeColorApproved = T000I3_A173LeaveTypeColorApproved[0];
               Z100CompanyId = T000I3_A100CompanyId[0];
            }
            else
            {
               Z125LeaveTypeName = A125LeaveTypeName;
               Z144LeaveTypeVacationLeave = A144LeaveTypeVacationLeave;
               Z145LeaveTypeLoggingWorkHours = A145LeaveTypeLoggingWorkHours;
               Z172LeaveTypeColorPending = A172LeaveTypeColorPending;
               Z173LeaveTypeColorApproved = A173LeaveTypeColorApproved;
               Z100CompanyId = A100CompanyId;
            }
         }
         if ( GX_JID == -17 )
         {
            Z124LeaveTypeId = A124LeaveTypeId;
            Z125LeaveTypeName = A125LeaveTypeName;
            Z144LeaveTypeVacationLeave = A144LeaveTypeVacationLeave;
            Z145LeaveTypeLoggingWorkHours = A145LeaveTypeLoggingWorkHours;
            Z172LeaveTypeColorPending = A172LeaveTypeColorPending;
            Z173LeaveTypeColorApproved = A173LeaveTypeColorApproved;
            Z100CompanyId = A100CompanyId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtLeaveTypeId_Enabled = 0;
         AssignProp("", false, edtLeaveTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveTypeId_Enabled), 5, 0), true);
         AV24Pgmname = "LeaveType";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtLeaveTypeId_Enabled = 0;
         AssignProp("", false, edtLeaveTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveTypeId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV14LeaveTypeId) )
         {
            A124LeaveTypeId = AV14LeaveTypeId;
            AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CompanyId) )
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CompanyId) )
         {
            A100CompanyId = AV12Insert_CompanyId;
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A145LeaveTypeLoggingWorkHours)) && ( Gx_BScreen == 0 ) )
         {
            A145LeaveTypeLoggingWorkHours = "No";
            AssignAttri("", false, "A145LeaveTypeLoggingWorkHours", A145LeaveTypeLoggingWorkHours);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A144LeaveTypeVacationLeave)) && ( Gx_BScreen == 0 ) )
         {
            A144LeaveTypeVacationLeave = "No";
            AssignAttri("", false, "A144LeaveTypeVacationLeave", A144LeaveTypeVacationLeave);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A173LeaveTypeColorApproved)) && ( Gx_BScreen == 0 ) )
         {
            A173LeaveTypeColorApproved = "#D5DDF6";
            n173LeaveTypeColorApproved = false;
            AssignAttri("", false, "A173LeaveTypeColorApproved", A173LeaveTypeColorApproved);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            if ( StringUtil.StrCmp(A145LeaveTypeLoggingWorkHours, "Yes") == 0 )
            {
               radLeaveTypeVacationLeave.Enabled = 0;
               AssignProp("", false, radLeaveTypeVacationLeave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeVacationLeave.Enabled), 5, 0), true);
            }
            else
            {
               radLeaveTypeVacationLeave.Enabled = 1;
               AssignProp("", false, radLeaveTypeVacationLeave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeVacationLeave.Enabled), 5, 0), true);
            }
            if ( StringUtil.StrCmp(A144LeaveTypeVacationLeave, "Yes") == 0 )
            {
               radLeaveTypeLoggingWorkHours.Enabled = 0;
               AssignProp("", false, radLeaveTypeLoggingWorkHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeLoggingWorkHours.Enabled), 5, 0), true);
            }
            else
            {
               radLeaveTypeLoggingWorkHours.Enabled = 1;
               AssignProp("", false, radLeaveTypeLoggingWorkHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeLoggingWorkHours.Enabled), 5, 0), true);
            }
         }
      }

      protected void Load0I20( )
      {
         /* Using cursor T000I5 */
         pr_default.execute(3, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
            A125LeaveTypeName = T000I5_A125LeaveTypeName[0];
            AssignAttri("", false, "A125LeaveTypeName", A125LeaveTypeName);
            A144LeaveTypeVacationLeave = T000I5_A144LeaveTypeVacationLeave[0];
            AssignAttri("", false, "A144LeaveTypeVacationLeave", A144LeaveTypeVacationLeave);
            A145LeaveTypeLoggingWorkHours = T000I5_A145LeaveTypeLoggingWorkHours[0];
            AssignAttri("", false, "A145LeaveTypeLoggingWorkHours", A145LeaveTypeLoggingWorkHours);
            A172LeaveTypeColorPending = T000I5_A172LeaveTypeColorPending[0];
            n172LeaveTypeColorPending = T000I5_n172LeaveTypeColorPending[0];
            AssignAttri("", false, "A172LeaveTypeColorPending", A172LeaveTypeColorPending);
            A173LeaveTypeColorApproved = T000I5_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = T000I5_n173LeaveTypeColorApproved[0];
            AssignAttri("", false, "A173LeaveTypeColorApproved", A173LeaveTypeColorApproved);
            A100CompanyId = T000I5_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            ZM0I20( -17) ;
         }
         pr_default.close(3);
         OnLoadActions0I20( ) ;
      }

      protected void OnLoadActions0I20( )
      {
         if ( StringUtil.StrCmp(A144LeaveTypeVacationLeave, "Yes") == 0 )
         {
            radLeaveTypeLoggingWorkHours.Enabled = 0;
            AssignProp("", false, radLeaveTypeLoggingWorkHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeLoggingWorkHours.Enabled), 5, 0), true);
         }
         else
         {
            radLeaveTypeLoggingWorkHours.Enabled = 1;
            AssignProp("", false, radLeaveTypeLoggingWorkHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeLoggingWorkHours.Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(A145LeaveTypeLoggingWorkHours, "Yes") == 0 )
         {
            radLeaveTypeVacationLeave.Enabled = 0;
            AssignProp("", false, radLeaveTypeVacationLeave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeVacationLeave.Enabled), 5, 0), true);
         }
         else
         {
            radLeaveTypeVacationLeave.Enabled = 1;
            AssignProp("", false, radLeaveTypeVacationLeave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeVacationLeave.Enabled), 5, 0), true);
         }
      }

      protected void CheckExtendedTable0I20( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Leave Type Name", "", "", "", "", "", "", "", ""), 1, "LEAVETYPENAME");
            AnyError = 1;
            GX_FocusControl = edtLeaveTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( StringUtil.StrCmp(A144LeaveTypeVacationLeave, "Yes") == 0 )
         {
            radLeaveTypeLoggingWorkHours.Enabled = 0;
            AssignProp("", false, radLeaveTypeLoggingWorkHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeLoggingWorkHours.Enabled), 5, 0), true);
         }
         else
         {
            radLeaveTypeLoggingWorkHours.Enabled = 1;
            AssignProp("", false, radLeaveTypeLoggingWorkHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeLoggingWorkHours.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(A145LeaveTypeLoggingWorkHours, "Yes") == 0 ) && ( StringUtil.StrCmp(A144LeaveTypeVacationLeave, "Yes") == 0 ) )
         {
            GX_msglist.addItem("You can't select both Vacation days and Work log setting on", 1, "LEAVETYPEVACATIONLEAVE");
            AnyError = 1;
            GX_FocusControl = radLeaveTypeVacationLeave_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( StringUtil.StrCmp(A145LeaveTypeLoggingWorkHours, "Yes") == 0 )
         {
            radLeaveTypeVacationLeave.Enabled = 0;
            AssignProp("", false, radLeaveTypeVacationLeave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeVacationLeave.Enabled), 5, 0), true);
         }
         else
         {
            radLeaveTypeVacationLeave.Enabled = 1;
            AssignProp("", false, radLeaveTypeVacationLeave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeVacationLeave.Enabled), 5, 0), true);
         }
         /* Using cursor T000I4 */
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

      protected void CloseExtendedTableCursors0I20( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_18( long A100CompanyId )
      {
         /* Using cursor T000I6 */
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

      protected void GetKey0I20( )
      {
         /* Using cursor T000I7 */
         pr_default.execute(5, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000I3 */
         pr_default.execute(1, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I20( 17) ;
            RcdFound20 = 1;
            A124LeaveTypeId = T000I3_A124LeaveTypeId[0];
            AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
            A125LeaveTypeName = T000I3_A125LeaveTypeName[0];
            AssignAttri("", false, "A125LeaveTypeName", A125LeaveTypeName);
            A144LeaveTypeVacationLeave = T000I3_A144LeaveTypeVacationLeave[0];
            AssignAttri("", false, "A144LeaveTypeVacationLeave", A144LeaveTypeVacationLeave);
            A145LeaveTypeLoggingWorkHours = T000I3_A145LeaveTypeLoggingWorkHours[0];
            AssignAttri("", false, "A145LeaveTypeLoggingWorkHours", A145LeaveTypeLoggingWorkHours);
            A172LeaveTypeColorPending = T000I3_A172LeaveTypeColorPending[0];
            n172LeaveTypeColorPending = T000I3_n172LeaveTypeColorPending[0];
            AssignAttri("", false, "A172LeaveTypeColorPending", A172LeaveTypeColorPending);
            A173LeaveTypeColorApproved = T000I3_A173LeaveTypeColorApproved[0];
            n173LeaveTypeColorApproved = T000I3_n173LeaveTypeColorApproved[0];
            AssignAttri("", false, "A173LeaveTypeColorApproved", A173LeaveTypeColorApproved);
            A100CompanyId = T000I3_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            Z124LeaveTypeId = A124LeaveTypeId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0I20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0I20( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0I20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I20( ) ;
         if ( RcdFound20 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound20 = 0;
         /* Using cursor T000I8 */
         pr_default.execute(6, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000I8_A124LeaveTypeId[0] < A124LeaveTypeId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000I8_A124LeaveTypeId[0] > A124LeaveTypeId ) ) )
            {
               A124LeaveTypeId = T000I8_A124LeaveTypeId[0];
               AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T000I9 */
         pr_default.execute(7, new Object[] {A124LeaveTypeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000I9_A124LeaveTypeId[0] > A124LeaveTypeId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000I9_A124LeaveTypeId[0] < A124LeaveTypeId ) ) )
            {
               A124LeaveTypeId = T000I9_A124LeaveTypeId[0];
               AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0I20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLeaveTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0I20( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A124LeaveTypeId != Z124LeaveTypeId )
               {
                  A124LeaveTypeId = Z124LeaveTypeId;
                  AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LEAVETYPEID");
                  AnyError = 1;
                  GX_FocusControl = edtLeaveTypeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLeaveTypeName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0I20( ) ;
                  GX_FocusControl = edtLeaveTypeName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A124LeaveTypeId != Z124LeaveTypeId )
               {
                  /* Insert record */
                  GX_FocusControl = edtLeaveTypeName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0I20( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LEAVETYPEID");
                     AnyError = 1;
                     GX_FocusControl = edtLeaveTypeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtLeaveTypeName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0I20( ) ;
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
         if ( A124LeaveTypeId != Z124LeaveTypeId )
         {
            A124LeaveTypeId = Z124LeaveTypeId;
            AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LEAVETYPEID");
            AnyError = 1;
            GX_FocusControl = edtLeaveTypeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLeaveTypeName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0I20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000I2 */
            pr_default.execute(0, new Object[] {A124LeaveTypeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LeaveType"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z125LeaveTypeName, T000I2_A125LeaveTypeName[0]) != 0 ) || ( StringUtil.StrCmp(Z144LeaveTypeVacationLeave, T000I2_A144LeaveTypeVacationLeave[0]) != 0 ) || ( StringUtil.StrCmp(Z145LeaveTypeLoggingWorkHours, T000I2_A145LeaveTypeLoggingWorkHours[0]) != 0 ) || ( StringUtil.StrCmp(Z172LeaveTypeColorPending, T000I2_A172LeaveTypeColorPending[0]) != 0 ) || ( StringUtil.StrCmp(Z173LeaveTypeColorApproved, T000I2_A173LeaveTypeColorApproved[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z100CompanyId != T000I2_A100CompanyId[0] ) )
            {
               if ( StringUtil.StrCmp(Z125LeaveTypeName, T000I2_A125LeaveTypeName[0]) != 0 )
               {
                  GXUtil.WriteLog("leavetype:[seudo value changed for attri]"+"LeaveTypeName");
                  GXUtil.WriteLogRaw("Old: ",Z125LeaveTypeName);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A125LeaveTypeName[0]);
               }
               if ( StringUtil.StrCmp(Z144LeaveTypeVacationLeave, T000I2_A144LeaveTypeVacationLeave[0]) != 0 )
               {
                  GXUtil.WriteLog("leavetype:[seudo value changed for attri]"+"LeaveTypeVacationLeave");
                  GXUtil.WriteLogRaw("Old: ",Z144LeaveTypeVacationLeave);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A144LeaveTypeVacationLeave[0]);
               }
               if ( StringUtil.StrCmp(Z145LeaveTypeLoggingWorkHours, T000I2_A145LeaveTypeLoggingWorkHours[0]) != 0 )
               {
                  GXUtil.WriteLog("leavetype:[seudo value changed for attri]"+"LeaveTypeLoggingWorkHours");
                  GXUtil.WriteLogRaw("Old: ",Z145LeaveTypeLoggingWorkHours);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A145LeaveTypeLoggingWorkHours[0]);
               }
               if ( StringUtil.StrCmp(Z172LeaveTypeColorPending, T000I2_A172LeaveTypeColorPending[0]) != 0 )
               {
                  GXUtil.WriteLog("leavetype:[seudo value changed for attri]"+"LeaveTypeColorPending");
                  GXUtil.WriteLogRaw("Old: ",Z172LeaveTypeColorPending);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A172LeaveTypeColorPending[0]);
               }
               if ( StringUtil.StrCmp(Z173LeaveTypeColorApproved, T000I2_A173LeaveTypeColorApproved[0]) != 0 )
               {
                  GXUtil.WriteLog("leavetype:[seudo value changed for attri]"+"LeaveTypeColorApproved");
                  GXUtil.WriteLogRaw("Old: ",Z173LeaveTypeColorApproved);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A173LeaveTypeColorApproved[0]);
               }
               if ( Z100CompanyId != T000I2_A100CompanyId[0] )
               {
                  GXUtil.WriteLog("leavetype:[seudo value changed for attri]"+"CompanyId");
                  GXUtil.WriteLogRaw("Old: ",Z100CompanyId);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A100CompanyId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LeaveType"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I20( )
      {
         if ( ! IsAuthorized("leavetype_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I20( 0) ;
            CheckOptimisticConcurrency0I20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I10 */
                     pr_default.execute(8, new Object[] {A125LeaveTypeName, A144LeaveTypeVacationLeave, A145LeaveTypeLoggingWorkHours, n172LeaveTypeColorPending, A172LeaveTypeColorPending, n173LeaveTypeColorApproved, A173LeaveTypeColorApproved, A100CompanyId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000I11 */
                     pr_default.execute(9);
                     A124LeaveTypeId = T000I11_A124LeaveTypeId[0];
                     AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("LeaveType");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0I0( ) ;
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
               Load0I20( ) ;
            }
            EndLevel0I20( ) ;
         }
         CloseExtendedTableCursors0I20( ) ;
      }

      protected void Update0I20( )
      {
         if ( ! IsAuthorized("leavetype_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I12 */
                     pr_default.execute(10, new Object[] {A125LeaveTypeName, A144LeaveTypeVacationLeave, A145LeaveTypeLoggingWorkHours, n172LeaveTypeColorPending, A172LeaveTypeColorPending, n173LeaveTypeColorApproved, A173LeaveTypeColorApproved, A100CompanyId, A124LeaveTypeId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("LeaveType");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LeaveType"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I20( ) ;
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
            EndLevel0I20( ) ;
         }
         CloseExtendedTableCursors0I20( ) ;
      }

      protected void DeferredUpdate0I20( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("leavetype_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I20( ) ;
            AfterConfirm0I20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000I13 */
                  pr_default.execute(11, new Object[] {A124LeaveTypeId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("LeaveType");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0I20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0I20( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( StringUtil.StrCmp(A144LeaveTypeVacationLeave, "Yes") == 0 )
            {
               radLeaveTypeLoggingWorkHours.Enabled = 0;
               AssignProp("", false, radLeaveTypeLoggingWorkHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeLoggingWorkHours.Enabled), 5, 0), true);
            }
            else
            {
               radLeaveTypeLoggingWorkHours.Enabled = 1;
               AssignProp("", false, radLeaveTypeLoggingWorkHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeLoggingWorkHours.Enabled), 5, 0), true);
            }
            if ( StringUtil.StrCmp(A145LeaveTypeLoggingWorkHours, "Yes") == 0 )
            {
               radLeaveTypeVacationLeave.Enabled = 0;
               AssignProp("", false, radLeaveTypeVacationLeave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeVacationLeave.Enabled), 5, 0), true);
            }
            else
            {
               radLeaveTypeVacationLeave.Enabled = 1;
               AssignProp("", false, radLeaveTypeVacationLeave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeVacationLeave.Enabled), 5, 0), true);
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000I14 */
            pr_default.execute(12, new Object[] {A124LeaveTypeId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"LeaveRequest"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0I20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I20( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("leavetype",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("leavetype",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0I20( )
      {
         /* Scan By routine */
         /* Using cursor T000I15 */
         pr_default.execute(13);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound20 = 1;
            A124LeaveTypeId = T000I15_A124LeaveTypeId[0];
            AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0I20( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound20 = 1;
            A124LeaveTypeId = T000I15_A124LeaveTypeId[0];
            AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
         }
      }

      protected void ScanEnd0I20( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0I20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I20( )
      {
         edtLeaveTypeName_Enabled = 0;
         AssignProp("", false, edtLeaveTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveTypeName_Enabled), 5, 0), true);
         edtLeaveTypeColorApproved_Enabled = 0;
         AssignProp("", false, edtLeaveTypeColorApproved_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveTypeColorApproved_Enabled), 5, 0), true);
         radLeaveTypeVacationLeave.Enabled = 0;
         AssignProp("", false, radLeaveTypeVacationLeave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeVacationLeave.Enabled), 5, 0), true);
         radLeaveTypeLoggingWorkHours.Enabled = 0;
         AssignProp("", false, radLeaveTypeLoggingWorkHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radLeaveTypeLoggingWorkHours.Enabled), 5, 0), true);
         edtLeaveTypeId_Enabled = 0;
         AssignProp("", false, edtLeaveTypeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveTypeId_Enabled), 5, 0), true);
         edtCompanyId_Enabled = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyId_Enabled), 5, 0), true);
         edtLeaveTypeColorPending_Enabled = 0;
         AssignProp("", false, edtLeaveTypeColorPending_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLeaveTypeColorPending_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0I20( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0I0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("leavetype.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV14LeaveTypeId,10,0))}, new string[] {"Gx_mode","LeaveTypeId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"LeaveType");
         forbiddenHiddens.Add("LeaveTypeId", context.localUtil.Format( (decimal)(A124LeaveTypeId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("leavetype:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z124LeaveTypeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z124LeaveTypeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z125LeaveTypeName", StringUtil.RTrim( Z125LeaveTypeName));
         GxWebStd.gx_hidden_field( context, "Z144LeaveTypeVacationLeave", StringUtil.RTrim( Z144LeaveTypeVacationLeave));
         GxWebStd.gx_hidden_field( context, "Z145LeaveTypeLoggingWorkHours", StringUtil.RTrim( Z145LeaveTypeLoggingWorkHours));
         GxWebStd.gx_hidden_field( context, "Z172LeaveTypeColorPending", StringUtil.RTrim( Z172LeaveTypeColorPending));
         GxWebStd.gx_hidden_field( context, "Z173LeaveTypeColorApproved", StringUtil.RTrim( Z173LeaveTypeColorApproved));
         GxWebStd.gx_hidden_field( context, "Z100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N144LeaveTypeVacationLeave", StringUtil.RTrim( A144LeaveTypeVacationLeave));
         GxWebStd.gx_hidden_field( context, "N145LeaveTypeLoggingWorkHours", StringUtil.RTrim( A145LeaveTypeLoggingWorkHours));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vLEAVETYPEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14LeaveTypeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLEAVETYPEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14LeaveTypeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_COMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV24Pgmname));
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
         return formatLink("leavetype.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV14LeaveTypeId,10,0))}, new string[] {"Gx_mode","LeaveTypeId"})  ;
      }

      public override string GetPgmname( )
      {
         return "LeaveType" ;
      }

      public override string GetPgmdesc( )
      {
         return "Leave Types" ;
      }

      protected void InitializeNonKey0I20( )
      {
         A100CompanyId = 0;
         AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         A125LeaveTypeName = "";
         AssignAttri("", false, "A125LeaveTypeName", A125LeaveTypeName);
         A172LeaveTypeColorPending = "";
         n172LeaveTypeColorPending = false;
         AssignAttri("", false, "A172LeaveTypeColorPending", A172LeaveTypeColorPending);
         n172LeaveTypeColorPending = (String.IsNullOrEmpty(StringUtil.RTrim( A172LeaveTypeColorPending)) ? true : false);
         A144LeaveTypeVacationLeave = "No";
         AssignAttri("", false, "A144LeaveTypeVacationLeave", A144LeaveTypeVacationLeave);
         A145LeaveTypeLoggingWorkHours = "No";
         AssignAttri("", false, "A145LeaveTypeLoggingWorkHours", A145LeaveTypeLoggingWorkHours);
         A173LeaveTypeColorApproved = "#D5DDF6";
         n173LeaveTypeColorApproved = false;
         AssignAttri("", false, "A173LeaveTypeColorApproved", A173LeaveTypeColorApproved);
         Z125LeaveTypeName = "";
         Z144LeaveTypeVacationLeave = "";
         Z145LeaveTypeLoggingWorkHours = "";
         Z172LeaveTypeColorPending = "";
         Z173LeaveTypeColorApproved = "";
         Z100CompanyId = 0;
      }

      protected void InitAll0I20( )
      {
         A124LeaveTypeId = 0;
         AssignAttri("", false, "A124LeaveTypeId", StringUtil.LTrimStr( (decimal)(A124LeaveTypeId), 10, 0));
         InitializeNonKey0I20( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A145LeaveTypeLoggingWorkHours = i145LeaveTypeLoggingWorkHours;
         AssignAttri("", false, "A145LeaveTypeLoggingWorkHours", A145LeaveTypeLoggingWorkHours);
         A144LeaveTypeVacationLeave = i144LeaveTypeVacationLeave;
         AssignAttri("", false, "A144LeaveTypeVacationLeave", A144LeaveTypeVacationLeave);
         A173LeaveTypeColorApproved = i173LeaveTypeColorApproved;
         n173LeaveTypeColorApproved = false;
         AssignAttri("", false, "A173LeaveTypeColorApproved", A173LeaveTypeColorApproved);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257120595091", true, true);
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
         context.AddJavascriptSource("leavetype.js", "?20257120595093", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtLeaveTypeName_Internalname = "LEAVETYPENAME";
         edtLeaveTypeColorApproved_Internalname = "LEAVETYPECOLORAPPROVED";
         radLeaveTypeVacationLeave_Internalname = "LEAVETYPEVACATIONLEAVE";
         radLeaveTypeLoggingWorkHours_Internalname = "LEAVETYPELOGGINGWORKHOURS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         edtLeaveTypeId_Internalname = "LEAVETYPEID";
         edtCompanyId_Internalname = "COMPANYID";
         edtLeaveTypeColorPending_Internalname = "LEAVETYPECOLORPENDING";
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
         Form.Caption = "Leave Types";
         edtLeaveTypeColorPending_Jsonclick = "";
         edtLeaveTypeColorPending_Enabled = 1;
         edtLeaveTypeColorPending_Visible = 1;
         edtCompanyId_Jsonclick = "";
         edtCompanyId_Enabled = 1;
         edtCompanyId_Visible = 1;
         edtLeaveTypeId_Jsonclick = "";
         edtLeaveTypeId_Enabled = 0;
         edtLeaveTypeId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         radLeaveTypeLoggingWorkHours_Jsonclick = "";
         radLeaveTypeLoggingWorkHours.Enabled = 1;
         radLeaveTypeVacationLeave_Jsonclick = "";
         radLeaveTypeVacationLeave.Enabled = 1;
         edtLeaveTypeColorApproved_Jsonclick = "";
         edtLeaveTypeColorApproved_Enabled = 1;
         edtLeaveTypeName_Jsonclick = "";
         edtLeaveTypeName_Enabled = 1;
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

      protected void GX5ASACOMPANYID0I20( long AV12Insert_CompanyId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CompanyId) )
         {
            A100CompanyId = AV12Insert_CompanyId;
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
         radLeaveTypeVacationLeave.Name = "LEAVETYPEVACATIONLEAVE";
         radLeaveTypeVacationLeave.WebTags = "";
         radLeaveTypeVacationLeave.addItem("No", "No", 0);
         radLeaveTypeVacationLeave.addItem("Yes", "Yes", 0);
         radLeaveTypeLoggingWorkHours.Name = "LEAVETYPELOGGINGWORKHOURS";
         radLeaveTypeLoggingWorkHours.WebTags = "";
         radLeaveTypeLoggingWorkHours.addItem("No", "No", 0);
         radLeaveTypeLoggingWorkHours.addItem("Yes", "Yes", 0);
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
         /* Using cursor T000I16 */
         pr_default.execute(14, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV14LeaveTypeId","fld":"vLEAVETYPEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV14LeaveTypeId","fld":"vLEAVETYPEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A124LeaveTypeId","fld":"LEAVETYPEID","pic":"ZZZZZZZZZ9"},{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120I2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]}""");
         setEventMetadata("VALID_LEAVETYPENAME","""{"handler":"Valid_Leavetypename","iparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]""");
         setEventMetadata("VALID_LEAVETYPENAME",""","oparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]}""");
         setEventMetadata("VALID_LEAVETYPEVACATIONLEAVE","""{"handler":"Valid_Leavetypevacationleave","iparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]""");
         setEventMetadata("VALID_LEAVETYPEVACATIONLEAVE",""","oparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]}""");
         setEventMetadata("VALID_LEAVETYPELOGGINGWORKHOURS","""{"handler":"Valid_Leavetypeloggingworkhours","iparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]""");
         setEventMetadata("VALID_LEAVETYPELOGGINGWORKHOURS",""","oparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]}""");
         setEventMetadata("VALID_LEAVETYPEID","""{"handler":"Valid_Leavetypeid","iparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]""");
         setEventMetadata("VALID_LEAVETYPEID",""","oparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]}""");
         setEventMetadata("VALID_COMPANYID","""{"handler":"Valid_Companyid","iparms":[{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]""");
         setEventMetadata("VALID_COMPANYID",""","oparms":[{"av":"radLeaveTypeVacationLeave"},{"av":"A144LeaveTypeVacationLeave","fld":"LEAVETYPEVACATIONLEAVE"},{"av":"radLeaveTypeLoggingWorkHours"},{"av":"A145LeaveTypeLoggingWorkHours","fld":"LEAVETYPELOGGINGWORKHOURS"}]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z125LeaveTypeName = "";
         Z144LeaveTypeVacationLeave = "";
         Z145LeaveTypeLoggingWorkHours = "";
         Z172LeaveTypeColorPending = "";
         Z173LeaveTypeColorApproved = "";
         N144LeaveTypeVacationLeave = "";
         N145LeaveTypeLoggingWorkHours = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A144LeaveTypeVacationLeave = "";
         A145LeaveTypeLoggingWorkHours = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A125LeaveTypeName = "";
         A173LeaveTypeColorApproved = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A172LeaveTypeColorPending = "";
         AV24Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode20 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV7WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         T000I5_A124LeaveTypeId = new long[1] ;
         T000I5_A125LeaveTypeName = new string[] {""} ;
         T000I5_A144LeaveTypeVacationLeave = new string[] {""} ;
         T000I5_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         T000I5_A172LeaveTypeColorPending = new string[] {""} ;
         T000I5_n172LeaveTypeColorPending = new bool[] {false} ;
         T000I5_A173LeaveTypeColorApproved = new string[] {""} ;
         T000I5_n173LeaveTypeColorApproved = new bool[] {false} ;
         T000I5_A100CompanyId = new long[1] ;
         T000I4_A100CompanyId = new long[1] ;
         T000I6_A100CompanyId = new long[1] ;
         T000I7_A124LeaveTypeId = new long[1] ;
         T000I3_A124LeaveTypeId = new long[1] ;
         T000I3_A125LeaveTypeName = new string[] {""} ;
         T000I3_A144LeaveTypeVacationLeave = new string[] {""} ;
         T000I3_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         T000I3_A172LeaveTypeColorPending = new string[] {""} ;
         T000I3_n172LeaveTypeColorPending = new bool[] {false} ;
         T000I3_A173LeaveTypeColorApproved = new string[] {""} ;
         T000I3_n173LeaveTypeColorApproved = new bool[] {false} ;
         T000I3_A100CompanyId = new long[1] ;
         T000I8_A124LeaveTypeId = new long[1] ;
         T000I9_A124LeaveTypeId = new long[1] ;
         T000I2_A124LeaveTypeId = new long[1] ;
         T000I2_A125LeaveTypeName = new string[] {""} ;
         T000I2_A144LeaveTypeVacationLeave = new string[] {""} ;
         T000I2_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         T000I2_A172LeaveTypeColorPending = new string[] {""} ;
         T000I2_n172LeaveTypeColorPending = new bool[] {false} ;
         T000I2_A173LeaveTypeColorApproved = new string[] {""} ;
         T000I2_n173LeaveTypeColorApproved = new bool[] {false} ;
         T000I2_A100CompanyId = new long[1] ;
         T000I11_A124LeaveTypeId = new long[1] ;
         T000I14_A127LeaveRequestId = new long[1] ;
         T000I15_A124LeaveTypeId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i145LeaveTypeLoggingWorkHours = "";
         i144LeaveTypeVacationLeave = "";
         i173LeaveTypeColorApproved = "";
         T000I16_A100CompanyId = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.leavetype__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leavetype__default(),
            new Object[][] {
                new Object[] {
               T000I2_A124LeaveTypeId, T000I2_A125LeaveTypeName, T000I2_A144LeaveTypeVacationLeave, T000I2_A145LeaveTypeLoggingWorkHours, T000I2_A172LeaveTypeColorPending, T000I2_n172LeaveTypeColorPending, T000I2_A173LeaveTypeColorApproved, T000I2_n173LeaveTypeColorApproved, T000I2_A100CompanyId
               }
               , new Object[] {
               T000I3_A124LeaveTypeId, T000I3_A125LeaveTypeName, T000I3_A144LeaveTypeVacationLeave, T000I3_A145LeaveTypeLoggingWorkHours, T000I3_A172LeaveTypeColorPending, T000I3_n172LeaveTypeColorPending, T000I3_A173LeaveTypeColorApproved, T000I3_n173LeaveTypeColorApproved, T000I3_A100CompanyId
               }
               , new Object[] {
               T000I4_A100CompanyId
               }
               , new Object[] {
               T000I5_A124LeaveTypeId, T000I5_A125LeaveTypeName, T000I5_A144LeaveTypeVacationLeave, T000I5_A145LeaveTypeLoggingWorkHours, T000I5_A172LeaveTypeColorPending, T000I5_n172LeaveTypeColorPending, T000I5_A173LeaveTypeColorApproved, T000I5_n173LeaveTypeColorApproved, T000I5_A100CompanyId
               }
               , new Object[] {
               T000I6_A100CompanyId
               }
               , new Object[] {
               T000I7_A124LeaveTypeId
               }
               , new Object[] {
               T000I8_A124LeaveTypeId
               }
               , new Object[] {
               T000I9_A124LeaveTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               T000I11_A124LeaveTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000I14_A127LeaveRequestId
               }
               , new Object[] {
               T000I15_A124LeaveTypeId
               }
               , new Object[] {
               T000I16_A100CompanyId
               }
            }
         );
         AV24Pgmname = "LeaveType";
         Z173LeaveTypeColorApproved = "#D5DDF6";
         n173LeaveTypeColorApproved = false;
         A173LeaveTypeColorApproved = "#D5DDF6";
         n173LeaveTypeColorApproved = false;
         i173LeaveTypeColorApproved = "#D5DDF6";
         n173LeaveTypeColorApproved = false;
         Z144LeaveTypeVacationLeave = "No";
         N144LeaveTypeVacationLeave = "No";
         A144LeaveTypeVacationLeave = "No";
         i144LeaveTypeVacationLeave = "No";
         Z145LeaveTypeLoggingWorkHours = "No";
         N145LeaveTypeLoggingWorkHours = "No";
         A145LeaveTypeLoggingWorkHours = "No";
         i145LeaveTypeLoggingWorkHours = "No";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound20 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtLeaveTypeName_Enabled ;
      private int edtLeaveTypeColorApproved_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtLeaveTypeId_Enabled ;
      private int edtLeaveTypeId_Visible ;
      private int edtCompanyId_Visible ;
      private int edtCompanyId_Enabled ;
      private int edtLeaveTypeColorPending_Visible ;
      private int edtLeaveTypeColorPending_Enabled ;
      private int AV25GXV1 ;
      private int idxLst ;
      private long wcpOAV14LeaveTypeId ;
      private long Z124LeaveTypeId ;
      private long Z100CompanyId ;
      private long N100CompanyId ;
      private long AV12Insert_CompanyId ;
      private long A100CompanyId ;
      private long AV14LeaveTypeId ;
      private long A124LeaveTypeId ;
      private long GXt_int1 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z125LeaveTypeName ;
      private string Z144LeaveTypeVacationLeave ;
      private string Z145LeaveTypeLoggingWorkHours ;
      private string Z172LeaveTypeColorPending ;
      private string Z173LeaveTypeColorApproved ;
      private string N144LeaveTypeVacationLeave ;
      private string N145LeaveTypeLoggingWorkHours ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLeaveTypeName_Internalname ;
      private string A144LeaveTypeVacationLeave ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divLefttable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string A125LeaveTypeName ;
      private string edtLeaveTypeName_Jsonclick ;
      private string edtLeaveTypeColorApproved_Internalname ;
      private string A173LeaveTypeColorApproved ;
      private string edtLeaveTypeColorApproved_Jsonclick ;
      private string radLeaveTypeVacationLeave_Internalname ;
      private string radLeaveTypeVacationLeave_Jsonclick ;
      private string radLeaveTypeLoggingWorkHours_Internalname ;
      private string radLeaveTypeLoggingWorkHours_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtLeaveTypeId_Internalname ;
      private string edtLeaveTypeId_Jsonclick ;
      private string edtCompanyId_Internalname ;
      private string edtCompanyId_Jsonclick ;
      private string edtLeaveTypeColorPending_Internalname ;
      private string A172LeaveTypeColorPending ;
      private string edtLeaveTypeColorPending_Jsonclick ;
      private string AV24Pgmname ;
      private string hsh ;
      private string sMode20 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i145LeaveTypeLoggingWorkHours ;
      private string i144LeaveTypeVacationLeave ;
      private string i173LeaveTypeColorApproved ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n172LeaveTypeColorPending ;
      private bool n173LeaveTypeColorApproved ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXRadio radLeaveTypeVacationLeave ;
      private GXRadio radLeaveTypeLoggingWorkHours ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV7WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] T000I5_A124LeaveTypeId ;
      private string[] T000I5_A125LeaveTypeName ;
      private string[] T000I5_A144LeaveTypeVacationLeave ;
      private string[] T000I5_A145LeaveTypeLoggingWorkHours ;
      private string[] T000I5_A172LeaveTypeColorPending ;
      private bool[] T000I5_n172LeaveTypeColorPending ;
      private string[] T000I5_A173LeaveTypeColorApproved ;
      private bool[] T000I5_n173LeaveTypeColorApproved ;
      private long[] T000I5_A100CompanyId ;
      private long[] T000I4_A100CompanyId ;
      private long[] T000I6_A100CompanyId ;
      private long[] T000I7_A124LeaveTypeId ;
      private long[] T000I3_A124LeaveTypeId ;
      private string[] T000I3_A125LeaveTypeName ;
      private string[] T000I3_A144LeaveTypeVacationLeave ;
      private string[] T000I3_A145LeaveTypeLoggingWorkHours ;
      private string[] T000I3_A172LeaveTypeColorPending ;
      private bool[] T000I3_n172LeaveTypeColorPending ;
      private string[] T000I3_A173LeaveTypeColorApproved ;
      private bool[] T000I3_n173LeaveTypeColorApproved ;
      private long[] T000I3_A100CompanyId ;
      private long[] T000I8_A124LeaveTypeId ;
      private long[] T000I9_A124LeaveTypeId ;
      private long[] T000I2_A124LeaveTypeId ;
      private string[] T000I2_A125LeaveTypeName ;
      private string[] T000I2_A144LeaveTypeVacationLeave ;
      private string[] T000I2_A145LeaveTypeLoggingWorkHours ;
      private string[] T000I2_A172LeaveTypeColorPending ;
      private bool[] T000I2_n172LeaveTypeColorPending ;
      private string[] T000I2_A173LeaveTypeColorApproved ;
      private bool[] T000I2_n173LeaveTypeColorApproved ;
      private long[] T000I2_A100CompanyId ;
      private long[] T000I11_A124LeaveTypeId ;
      private long[] T000I14_A127LeaveRequestId ;
      private long[] T000I15_A124LeaveTypeId ;
      private long[] T000I16_A100CompanyId ;
      private IDataStoreProvider pr_gam ;
   }

   public class leavetype__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class leavetype__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000I2;
        prmT000I2 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000I3;
        prmT000I3 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000I4;
        prmT000I4 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000I5;
        prmT000I5 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000I6;
        prmT000I6 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000I7;
        prmT000I7 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000I8;
        prmT000I8 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000I9;
        prmT000I9 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000I10;
        prmT000I10 = new Object[] {
        new ParDef("LeaveTypeName",GXType.Char,100,0) ,
        new ParDef("LeaveTypeVacationLeave",GXType.Char,20,0) ,
        new ParDef("LeaveTypeLoggingWorkHours",GXType.Char,20,0) ,
        new ParDef("LeaveTypeColorPending",GXType.Char,20,0){Nullable=true} ,
        new ParDef("LeaveTypeColorApproved",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000I11;
        prmT000I11 = new Object[] {
        };
        Object[] prmT000I12;
        prmT000I12 = new Object[] {
        new ParDef("LeaveTypeName",GXType.Char,100,0) ,
        new ParDef("LeaveTypeVacationLeave",GXType.Char,20,0) ,
        new ParDef("LeaveTypeLoggingWorkHours",GXType.Char,20,0) ,
        new ParDef("LeaveTypeColorPending",GXType.Char,20,0){Nullable=true} ,
        new ParDef("LeaveTypeColorApproved",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CompanyId",GXType.Int64,10,0) ,
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000I13;
        prmT000I13 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000I14;
        prmT000I14 = new Object[] {
        new ParDef("LeaveTypeId",GXType.Int64,10,0)
        };
        Object[] prmT000I15;
        prmT000I15 = new Object[] {
        };
        Object[] prmT000I16;
        prmT000I16 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000I2", "SELECT LeaveTypeId, LeaveTypeName, LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours, LeaveTypeColorPending, LeaveTypeColorApproved, CompanyId FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId  FOR UPDATE OF LeaveType NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I3", "SELECT LeaveTypeId, LeaveTypeName, LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours, LeaveTypeColorPending, LeaveTypeColorApproved, CompanyId FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I4", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I5", "SELECT TM1.LeaveTypeId, TM1.LeaveTypeName, TM1.LeaveTypeVacationLeave, TM1.LeaveTypeLoggingWorkHours, TM1.LeaveTypeColorPending, TM1.LeaveTypeColorApproved, TM1.CompanyId FROM LeaveType TM1 WHERE TM1.LeaveTypeId = :LeaveTypeId ORDER BY TM1.LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I6", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I7", "SELECT LeaveTypeId FROM LeaveType WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I8", "SELECT LeaveTypeId FROM LeaveType WHERE ( LeaveTypeId > :LeaveTypeId) ORDER BY LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I9", "SELECT LeaveTypeId FROM LeaveType WHERE ( LeaveTypeId < :LeaveTypeId) ORDER BY LeaveTypeId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I10", "SAVEPOINT gxupdate;INSERT INTO LeaveType(LeaveTypeName, LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours, LeaveTypeColorPending, LeaveTypeColorApproved, CompanyId) VALUES(:LeaveTypeName, :LeaveTypeVacationLeave, :LeaveTypeLoggingWorkHours, :LeaveTypeColorPending, :LeaveTypeColorApproved, :CompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000I10)
           ,new CursorDef("T000I11", "SELECT currval('LeaveTypeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I12", "SAVEPOINT gxupdate;UPDATE LeaveType SET LeaveTypeName=:LeaveTypeName, LeaveTypeVacationLeave=:LeaveTypeVacationLeave, LeaveTypeLoggingWorkHours=:LeaveTypeLoggingWorkHours, LeaveTypeColorPending=:LeaveTypeColorPending, LeaveTypeColorApproved=:LeaveTypeColorApproved, CompanyId=:CompanyId  WHERE LeaveTypeId = :LeaveTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000I12)
           ,new CursorDef("T000I13", "SAVEPOINT gxupdate;DELETE FROM LeaveType  WHERE LeaveTypeId = :LeaveTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000I13)
           ,new CursorDef("T000I14", "SELECT LeaveRequestId FROM LeaveRequest WHERE LeaveTypeId = :LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I15", "SELECT LeaveTypeId FROM LeaveType ORDER BY LeaveTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I16", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I16,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((long[]) buf[8])[0] = rslt.getLong(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((long[]) buf[8])[0] = rslt.getLong(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 20);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((long[]) buf[8])[0] = rslt.getLong(7);
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
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
