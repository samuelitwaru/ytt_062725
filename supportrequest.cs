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
   public class supportrequest : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A106EmployeeId) ;
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
         Form.Meta.addItem("description", "Support Request", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupportRequestId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public supportrequest( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public supportrequest( IGxContext context )
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
            return "supportrequest_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Support Request", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_SupportRequest.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SupportRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SupportRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SupportRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SupportRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SupportRequest.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupportRequestId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupportRequestId_Internalname, "Request Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupportRequestId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A174SupportRequestId), 10, 0, ".", "")), StringUtil.LTrim( ((edtSupportRequestId_Enabled!=0) ? context.localUtil.Format( (decimal)(A174SupportRequestId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A174SupportRequestId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupportRequestId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupportRequestId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SupportRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupportRequestSubject_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupportRequestSubject_Internalname, "Request Subject", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSupportRequestSubject_Internalname, A169SupportRequestSubject, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtSupportRequestSubject_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "201", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SupportRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSupportRequestDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupportRequestDescription_Internalname, "Request Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSupportRequestDescription_Internalname, A170SupportRequestDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtSupportRequestDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SupportRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeId_Internalname, "Employee Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")), StringUtil.LTrim( ((edtEmployeeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_SupportRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeFirstName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeFirstName_Internalname, "Employee First Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeFirstName_Internalname, StringUtil.RTrim( A107EmployeeFirstName), StringUtil.RTrim( context.localUtil.Format( A107EmployeeFirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeFirstName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeFirstName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_SupportRequest.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SupportRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SupportRequest.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SupportRequest.htm");
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
            Z174SupportRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z174SupportRequestId"), ".", ","), 18, MidpointRounding.ToEven));
            Z169SupportRequestSubject = cgiGet( "Z169SupportRequestSubject");
            Z170SupportRequestDescription = cgiGet( "Z170SupportRequestDescription");
            Z106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A147EmployeeBalance = context.localUtil.CToN( cgiGet( "EMPLOYEEBALANCE"), ".", ",");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSupportRequestId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSupportRequestId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUPPORTREQUESTID");
               AnyError = 1;
               GX_FocusControl = edtSupportRequestId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A174SupportRequestId = 0;
               AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
            }
            else
            {
               A174SupportRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSupportRequestId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
            }
            A169SupportRequestSubject = cgiGet( edtSupportRequestSubject_Internalname);
            AssignAttri("", false, "A169SupportRequestSubject", A169SupportRequestSubject);
            A170SupportRequestDescription = cgiGet( edtSupportRequestDescription_Internalname);
            AssignAttri("", false, "A170SupportRequestDescription", A170SupportRequestDescription);
            if ( ( ( context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEEID");
               AnyError = 1;
               GX_FocusControl = edtEmployeeId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A106EmployeeId = 0;
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            }
            else
            {
               A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            }
            A107EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
            AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
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
               A174SupportRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "SupportRequestId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
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
               InitAll0O26( ) ;
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
         DisableAttributes0O26( ) ;
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

      protected void ResetCaption0O0( )
      {
      }

      protected void ZM0O26( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z169SupportRequestSubject = T000O3_A169SupportRequestSubject[0];
               Z170SupportRequestDescription = T000O3_A170SupportRequestDescription[0];
               Z106EmployeeId = T000O3_A106EmployeeId[0];
            }
            else
            {
               Z169SupportRequestSubject = A169SupportRequestSubject;
               Z170SupportRequestDescription = A170SupportRequestDescription;
               Z106EmployeeId = A106EmployeeId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z174SupportRequestId = A174SupportRequestId;
            Z169SupportRequestSubject = A169SupportRequestSubject;
            Z170SupportRequestDescription = A170SupportRequestDescription;
            Z106EmployeeId = A106EmployeeId;
            Z147EmployeeBalance = A147EmployeeBalance;
            Z107EmployeeFirstName = A107EmployeeFirstName;
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

      protected void Load0O26( )
      {
         /* Using cursor T000O5 */
         pr_default.execute(3, new Object[] {A174SupportRequestId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound26 = 1;
            A147EmployeeBalance = T000O5_A147EmployeeBalance[0];
            A169SupportRequestSubject = T000O5_A169SupportRequestSubject[0];
            AssignAttri("", false, "A169SupportRequestSubject", A169SupportRequestSubject);
            A170SupportRequestDescription = T000O5_A170SupportRequestDescription[0];
            AssignAttri("", false, "A170SupportRequestDescription", A170SupportRequestDescription);
            A107EmployeeFirstName = T000O5_A107EmployeeFirstName[0];
            AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
            A106EmployeeId = T000O5_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            ZM0O26( -1) ;
         }
         pr_default.close(3);
         OnLoadActions0O26( ) ;
      }

      protected void OnLoadActions0O26( )
      {
      }

      protected void CheckExtendedTable0O26( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000O4 */
         pr_default.execute(2, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A147EmployeeBalance = T000O4_A147EmployeeBalance[0];
         A107EmployeeFirstName = T000O4_A107EmployeeFirstName[0];
         AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0O26( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( long A106EmployeeId )
      {
         /* Using cursor T000O6 */
         pr_default.execute(4, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A147EmployeeBalance = T000O6_A147EmployeeBalance[0];
         A107EmployeeFirstName = T000O6_A107EmployeeFirstName[0];
         AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A107EmployeeFirstName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0O26( )
      {
         /* Using cursor T000O7 */
         pr_default.execute(5, new Object[] {A174SupportRequestId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000O3 */
         pr_default.execute(1, new Object[] {A174SupportRequestId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0O26( 1) ;
            RcdFound26 = 1;
            A174SupportRequestId = T000O3_A174SupportRequestId[0];
            AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
            A169SupportRequestSubject = T000O3_A169SupportRequestSubject[0];
            AssignAttri("", false, "A169SupportRequestSubject", A169SupportRequestSubject);
            A170SupportRequestDescription = T000O3_A170SupportRequestDescription[0];
            AssignAttri("", false, "A170SupportRequestDescription", A170SupportRequestDescription);
            A106EmployeeId = T000O3_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            Z174SupportRequestId = A174SupportRequestId;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0O26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0O26( ) ;
            }
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0O26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0O26( ) ;
         if ( RcdFound26 == 0 )
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
         RcdFound26 = 0;
         /* Using cursor T000O8 */
         pr_default.execute(6, new Object[] {A174SupportRequestId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000O8_A174SupportRequestId[0] < A174SupportRequestId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000O8_A174SupportRequestId[0] > A174SupportRequestId ) ) )
            {
               A174SupportRequestId = T000O8_A174SupportRequestId[0];
               AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound26 = 0;
         /* Using cursor T000O9 */
         pr_default.execute(7, new Object[] {A174SupportRequestId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000O9_A174SupportRequestId[0] > A174SupportRequestId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000O9_A174SupportRequestId[0] < A174SupportRequestId ) ) )
            {
               A174SupportRequestId = T000O9_A174SupportRequestId[0];
               AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0O26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSupportRequestId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0O26( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( A174SupportRequestId != Z174SupportRequestId )
               {
                  A174SupportRequestId = Z174SupportRequestId;
                  AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPPORTREQUESTID");
                  AnyError = 1;
                  GX_FocusControl = edtSupportRequestId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupportRequestId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0O26( ) ;
                  GX_FocusControl = edtSupportRequestId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A174SupportRequestId != Z174SupportRequestId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSupportRequestId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0O26( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPPORTREQUESTID");
                     AnyError = 1;
                     GX_FocusControl = edtSupportRequestId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSupportRequestId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0O26( ) ;
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
         if ( A174SupportRequestId != Z174SupportRequestId )
         {
            A174SupportRequestId = Z174SupportRequestId;
            AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPPORTREQUESTID");
            AnyError = 1;
            GX_FocusControl = edtSupportRequestId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupportRequestId_Internalname;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SUPPORTREQUESTID");
            AnyError = 1;
            GX_FocusControl = edtSupportRequestId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSupportRequestSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0O26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSupportRequestSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0O26( ) ;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSupportRequestSubject_Internalname;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSupportRequestSubject_Internalname;
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
         ScanStart0O26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound26 != 0 )
            {
               ScanNext0O26( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSupportRequestSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0O26( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0O26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000O2 */
            pr_default.execute(0, new Object[] {A174SupportRequestId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SupportRequest"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z169SupportRequestSubject, T000O2_A169SupportRequestSubject[0]) != 0 ) || ( StringUtil.StrCmp(Z170SupportRequestDescription, T000O2_A170SupportRequestDescription[0]) != 0 ) || ( Z106EmployeeId != T000O2_A106EmployeeId[0] ) )
            {
               if ( StringUtil.StrCmp(Z169SupportRequestSubject, T000O2_A169SupportRequestSubject[0]) != 0 )
               {
                  GXUtil.WriteLog("supportrequest:[seudo value changed for attri]"+"SupportRequestSubject");
                  GXUtil.WriteLogRaw("Old: ",Z169SupportRequestSubject);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A169SupportRequestSubject[0]);
               }
               if ( StringUtil.StrCmp(Z170SupportRequestDescription, T000O2_A170SupportRequestDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("supportrequest:[seudo value changed for attri]"+"SupportRequestDescription");
                  GXUtil.WriteLogRaw("Old: ",Z170SupportRequestDescription);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A170SupportRequestDescription[0]);
               }
               if ( Z106EmployeeId != T000O2_A106EmployeeId[0] )
               {
                  GXUtil.WriteLog("supportrequest:[seudo value changed for attri]"+"EmployeeId");
                  GXUtil.WriteLogRaw("Old: ",Z106EmployeeId);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A106EmployeeId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SupportRequest"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O26( )
      {
         if ( ! IsAuthorized("supportrequest_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0O26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O26( 0) ;
            CheckOptimisticConcurrency0O26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000O10 */
                     pr_default.execute(8, new Object[] {A169SupportRequestSubject, A170SupportRequestDescription, A106EmployeeId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000O11 */
                     pr_default.execute(9);
                     A174SupportRequestId = T000O11_A174SupportRequestId[0];
                     AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SupportRequest");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0O0( ) ;
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
               Load0O26( ) ;
            }
            EndLevel0O26( ) ;
         }
         CloseExtendedTableCursors0O26( ) ;
      }

      protected void Update0O26( )
      {
         if ( ! IsAuthorized("supportrequest_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0O26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000O12 */
                     pr_default.execute(10, new Object[] {A169SupportRequestSubject, A170SupportRequestDescription, A106EmployeeId, A174SupportRequestId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SupportRequest");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SupportRequest"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O26( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0O0( ) ;
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
            EndLevel0O26( ) ;
         }
         CloseExtendedTableCursors0O26( ) ;
      }

      protected void DeferredUpdate0O26( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("supportrequest_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0O26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O26( ) ;
            AfterConfirm0O26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000O13 */
                  pr_default.execute(11, new Object[] {A174SupportRequestId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("SupportRequest");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound26 == 0 )
                        {
                           InitAll0O26( ) ;
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
                        ResetCaption0O0( ) ;
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0O26( ) ;
         Gx_mode = sMode26;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0O26( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000O14 */
            pr_default.execute(12, new Object[] {A106EmployeeId});
            A147EmployeeBalance = T000O14_A147EmployeeBalance[0];
            A107EmployeeFirstName = T000O14_A107EmployeeFirstName[0];
            AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
            pr_default.close(12);
         }
      }

      protected void EndLevel0O26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0O26( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("supportrequest",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("supportrequest",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0O26( )
      {
         /* Using cursor T000O15 */
         pr_default.execute(13);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound26 = 1;
            A174SupportRequestId = T000O15_A174SupportRequestId[0];
            AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0O26( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound26 = 1;
            A174SupportRequestId = T000O15_A174SupportRequestId[0];
            AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
         }
      }

      protected void ScanEnd0O26( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0O26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0O26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0O26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0O26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0O26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0O26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O26( )
      {
         edtSupportRequestId_Enabled = 0;
         AssignProp("", false, edtSupportRequestId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupportRequestId_Enabled), 5, 0), true);
         edtSupportRequestSubject_Enabled = 0;
         AssignProp("", false, edtSupportRequestSubject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupportRequestSubject_Enabled), 5, 0), true);
         edtSupportRequestDescription_Enabled = 0;
         AssignProp("", false, edtSupportRequestDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupportRequestDescription_Enabled), 5, 0), true);
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         edtEmployeeFirstName_Enabled = 0;
         AssignProp("", false, edtEmployeeFirstName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeFirstName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0O26( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0O0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("supportrequest.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z174SupportRequestId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z174SupportRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z169SupportRequestSubject", Z169SupportRequestSubject);
         GxWebStd.gx_hidden_field( context, "Z170SupportRequestDescription", Z170SupportRequestDescription);
         GxWebStd.gx_hidden_field( context, "Z106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEBALANCE", StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")));
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
         return formatLink("supportrequest.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SupportRequest" ;
      }

      public override string GetPgmdesc( )
      {
         return "Support Request" ;
      }

      protected void InitializeNonKey0O26( )
      {
         A147EmployeeBalance = 0;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
         A169SupportRequestSubject = "";
         AssignAttri("", false, "A169SupportRequestSubject", A169SupportRequestSubject);
         A170SupportRequestDescription = "";
         AssignAttri("", false, "A170SupportRequestDescription", A170SupportRequestDescription);
         A106EmployeeId = 0;
         AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         A107EmployeeFirstName = "";
         AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
         Z169SupportRequestSubject = "";
         Z170SupportRequestDescription = "";
         Z106EmployeeId = 0;
      }

      protected void InitAll0O26( )
      {
         A174SupportRequestId = 0;
         AssignAttri("", false, "A174SupportRequestId", StringUtil.LTrimStr( (decimal)(A174SupportRequestId), 10, 0));
         InitializeNonKey0O26( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267501063", true, true);
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
         context.AddJavascriptSource("supportrequest.js", "?20256267501064", false, true);
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
         edtSupportRequestId_Internalname = "SUPPORTREQUESTID";
         edtSupportRequestSubject_Internalname = "SUPPORTREQUESTSUBJECT";
         edtSupportRequestDescription_Internalname = "SUPPORTREQUESTDESCRIPTION";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME";
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
         Form.Caption = "Support Request";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeFirstName_Enabled = 0;
         edtEmployeeId_Jsonclick = "";
         edtEmployeeId_Enabled = 1;
         edtSupportRequestDescription_Enabled = 1;
         edtSupportRequestSubject_Enabled = 1;
         edtSupportRequestId_Jsonclick = "";
         edtSupportRequestId_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtSupportRequestSubject_Internalname;
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

      public void Valid_Supportrequestid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A169SupportRequestSubject", A169SupportRequestSubject);
         AssignAttri("", false, "A170SupportRequestDescription", A170SupportRequestDescription);
         AssignAttri("", false, "A106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")));
         AssignAttri("", false, "A107EmployeeFirstName", StringUtil.RTrim( A107EmployeeFirstName));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z174SupportRequestId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z174SupportRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z169SupportRequestSubject", Z169SupportRequestSubject);
         GxWebStd.gx_hidden_field( context, "Z170SupportRequestDescription", Z170SupportRequestDescription);
         GxWebStd.gx_hidden_field( context, "Z106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z147EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( Z147EmployeeBalance, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z107EmployeeFirstName", StringUtil.RTrim( Z107EmployeeFirstName));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Employeeid( )
      {
         /* Using cursor T000O14 */
         pr_default.execute(12, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
         }
         A147EmployeeBalance = T000O14_A147EmployeeBalance[0];
         A107EmployeeFirstName = T000O14_A107EmployeeFirstName[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")));
         AssignAttri("", false, "A107EmployeeFirstName", StringUtil.RTrim( A107EmployeeFirstName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_SUPPORTREQUESTID","""{"handler":"Valid_Supportrequestid","iparms":[{"av":"A174SupportRequestId","fld":"SUPPORTREQUESTID","pic":"ZZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_SUPPORTREQUESTID",""","oparms":[{"av":"A169SupportRequestSubject","fld":"SUPPORTREQUESTSUBJECT"},{"av":"A170SupportRequestDescription","fld":"SUPPORTREQUESTDESCRIPTION"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A147EmployeeBalance","fld":"EMPLOYEEBALANCE","pic":"Z9.9"},{"av":"A107EmployeeFirstName","fld":"EMPLOYEEFIRSTNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z174SupportRequestId"},{"av":"Z169SupportRequestSubject"},{"av":"Z170SupportRequestDescription"},{"av":"Z106EmployeeId"},{"av":"Z147EmployeeBalance"},{"av":"Z107EmployeeFirstName"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A147EmployeeBalance","fld":"EMPLOYEEBALANCE","pic":"Z9.9"},{"av":"A107EmployeeFirstName","fld":"EMPLOYEEFIRSTNAME"}]""");
         setEventMetadata("VALID_EMPLOYEEID",""","oparms":[{"av":"A147EmployeeBalance","fld":"EMPLOYEEBALANCE","pic":"Z9.9"},{"av":"A107EmployeeFirstName","fld":"EMPLOYEEFIRSTNAME"}]}""");
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
         Z169SupportRequestSubject = "";
         Z170SupportRequestDescription = "";
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
         A169SupportRequestSubject = "";
         A170SupportRequestDescription = "";
         A107EmployeeFirstName = "";
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
         Z107EmployeeFirstName = "";
         T000O5_A147EmployeeBalance = new decimal[1] ;
         T000O5_A174SupportRequestId = new long[1] ;
         T000O5_A169SupportRequestSubject = new string[] {""} ;
         T000O5_A170SupportRequestDescription = new string[] {""} ;
         T000O5_A107EmployeeFirstName = new string[] {""} ;
         T000O5_A106EmployeeId = new long[1] ;
         T000O4_A147EmployeeBalance = new decimal[1] ;
         T000O4_A107EmployeeFirstName = new string[] {""} ;
         T000O6_A147EmployeeBalance = new decimal[1] ;
         T000O6_A107EmployeeFirstName = new string[] {""} ;
         T000O7_A174SupportRequestId = new long[1] ;
         T000O3_A174SupportRequestId = new long[1] ;
         T000O3_A169SupportRequestSubject = new string[] {""} ;
         T000O3_A170SupportRequestDescription = new string[] {""} ;
         T000O3_A106EmployeeId = new long[1] ;
         sMode26 = "";
         T000O8_A174SupportRequestId = new long[1] ;
         T000O9_A174SupportRequestId = new long[1] ;
         T000O2_A174SupportRequestId = new long[1] ;
         T000O2_A169SupportRequestSubject = new string[] {""} ;
         T000O2_A170SupportRequestDescription = new string[] {""} ;
         T000O2_A106EmployeeId = new long[1] ;
         T000O11_A174SupportRequestId = new long[1] ;
         T000O14_A147EmployeeBalance = new decimal[1] ;
         T000O14_A107EmployeeFirstName = new string[] {""} ;
         T000O15_A174SupportRequestId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ169SupportRequestSubject = "";
         ZZ170SupportRequestDescription = "";
         ZZ107EmployeeFirstName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.supportrequest__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supportrequest__default(),
            new Object[][] {
                new Object[] {
               T000O2_A174SupportRequestId, T000O2_A169SupportRequestSubject, T000O2_A170SupportRequestDescription, T000O2_A106EmployeeId
               }
               , new Object[] {
               T000O3_A174SupportRequestId, T000O3_A169SupportRequestSubject, T000O3_A170SupportRequestDescription, T000O3_A106EmployeeId
               }
               , new Object[] {
               T000O4_A147EmployeeBalance, T000O4_A107EmployeeFirstName
               }
               , new Object[] {
               T000O5_A147EmployeeBalance, T000O5_A174SupportRequestId, T000O5_A169SupportRequestSubject, T000O5_A170SupportRequestDescription, T000O5_A107EmployeeFirstName, T000O5_A106EmployeeId
               }
               , new Object[] {
               T000O6_A147EmployeeBalance, T000O6_A107EmployeeFirstName
               }
               , new Object[] {
               T000O7_A174SupportRequestId
               }
               , new Object[] {
               T000O8_A174SupportRequestId
               }
               , new Object[] {
               T000O9_A174SupportRequestId
               }
               , new Object[] {
               }
               , new Object[] {
               T000O11_A174SupportRequestId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000O14_A147EmployeeBalance, T000O14_A107EmployeeFirstName
               }
               , new Object[] {
               T000O15_A174SupportRequestId
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
      private short RcdFound26 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSupportRequestId_Enabled ;
      private int edtSupportRequestSubject_Enabled ;
      private int edtSupportRequestDescription_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeFirstName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z174SupportRequestId ;
      private long Z106EmployeeId ;
      private long A106EmployeeId ;
      private long A174SupportRequestId ;
      private long ZZ174SupportRequestId ;
      private long ZZ106EmployeeId ;
      private decimal A147EmployeeBalance ;
      private decimal Z147EmployeeBalance ;
      private decimal ZZ147EmployeeBalance ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSupportRequestId_Internalname ;
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
      private string edtSupportRequestId_Jsonclick ;
      private string edtSupportRequestSubject_Internalname ;
      private string edtSupportRequestDescription_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeFirstName_Internalname ;
      private string A107EmployeeFirstName ;
      private string edtEmployeeFirstName_Jsonclick ;
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
      private string Z107EmployeeFirstName ;
      private string sMode26 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ107EmployeeFirstName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z169SupportRequestSubject ;
      private string Z170SupportRequestDescription ;
      private string A169SupportRequestSubject ;
      private string A170SupportRequestDescription ;
      private string ZZ169SupportRequestSubject ;
      private string ZZ170SupportRequestDescription ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000O5_A147EmployeeBalance ;
      private long[] T000O5_A174SupportRequestId ;
      private string[] T000O5_A169SupportRequestSubject ;
      private string[] T000O5_A170SupportRequestDescription ;
      private string[] T000O5_A107EmployeeFirstName ;
      private long[] T000O5_A106EmployeeId ;
      private decimal[] T000O4_A147EmployeeBalance ;
      private string[] T000O4_A107EmployeeFirstName ;
      private decimal[] T000O6_A147EmployeeBalance ;
      private string[] T000O6_A107EmployeeFirstName ;
      private long[] T000O7_A174SupportRequestId ;
      private long[] T000O3_A174SupportRequestId ;
      private string[] T000O3_A169SupportRequestSubject ;
      private string[] T000O3_A170SupportRequestDescription ;
      private long[] T000O3_A106EmployeeId ;
      private long[] T000O8_A174SupportRequestId ;
      private long[] T000O9_A174SupportRequestId ;
      private long[] T000O2_A174SupportRequestId ;
      private string[] T000O2_A169SupportRequestSubject ;
      private string[] T000O2_A170SupportRequestDescription ;
      private long[] T000O2_A106EmployeeId ;
      private long[] T000O11_A174SupportRequestId ;
      private decimal[] T000O14_A147EmployeeBalance ;
      private string[] T000O14_A107EmployeeFirstName ;
      private long[] T000O15_A174SupportRequestId ;
      private IDataStoreProvider pr_gam ;
   }

   public class supportrequest__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class supportrequest__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000O2;
        prmT000O2 = new Object[] {
        new ParDef("SupportRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000O3;
        prmT000O3 = new Object[] {
        new ParDef("SupportRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000O4;
        prmT000O4 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000O5;
        prmT000O5 = new Object[] {
        new ParDef("SupportRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000O6;
        prmT000O6 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000O7;
        prmT000O7 = new Object[] {
        new ParDef("SupportRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000O8;
        prmT000O8 = new Object[] {
        new ParDef("SupportRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000O9;
        prmT000O9 = new Object[] {
        new ParDef("SupportRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000O10;
        prmT000O10 = new Object[] {
        new ParDef("SupportRequestSubject",GXType.VarChar,201,0) ,
        new ParDef("SupportRequestDescription",GXType.VarChar,200,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000O11;
        prmT000O11 = new Object[] {
        };
        Object[] prmT000O12;
        prmT000O12 = new Object[] {
        new ParDef("SupportRequestSubject",GXType.VarChar,201,0) ,
        new ParDef("SupportRequestDescription",GXType.VarChar,200,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("SupportRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000O13;
        prmT000O13 = new Object[] {
        new ParDef("SupportRequestId",GXType.Int64,10,0)
        };
        Object[] prmT000O14;
        prmT000O14 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000O15;
        prmT000O15 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000O2", "SELECT SupportRequestId, SupportRequestSubject, SupportRequestDescription, EmployeeId FROM SupportRequest WHERE SupportRequestId = :SupportRequestId  FOR UPDATE OF SupportRequest NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O3", "SELECT SupportRequestId, SupportRequestSubject, SupportRequestDescription, EmployeeId FROM SupportRequest WHERE SupportRequestId = :SupportRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O4", "SELECT EmployeeBalance, EmployeeFirstName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O5", "SELECT T2.EmployeeBalance, TM1.SupportRequestId, TM1.SupportRequestSubject, TM1.SupportRequestDescription, T2.EmployeeFirstName, TM1.EmployeeId FROM (SupportRequest TM1 INNER JOIN Employee T2 ON T2.EmployeeId = TM1.EmployeeId) WHERE TM1.SupportRequestId = :SupportRequestId ORDER BY TM1.SupportRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O6", "SELECT EmployeeBalance, EmployeeFirstName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O7", "SELECT SupportRequestId FROM SupportRequest WHERE SupportRequestId = :SupportRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O8", "SELECT SupportRequestId FROM SupportRequest WHERE ( SupportRequestId > :SupportRequestId) ORDER BY SupportRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000O9", "SELECT SupportRequestId FROM SupportRequest WHERE ( SupportRequestId < :SupportRequestId) ORDER BY SupportRequestId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000O10", "SAVEPOINT gxupdate;INSERT INTO SupportRequest(SupportRequestSubject, SupportRequestDescription, EmployeeId) VALUES(:SupportRequestSubject, :SupportRequestDescription, :EmployeeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000O10)
           ,new CursorDef("T000O11", "SELECT currval('SupportRequestId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O12", "SAVEPOINT gxupdate;UPDATE SupportRequest SET SupportRequestSubject=:SupportRequestSubject, SupportRequestDescription=:SupportRequestDescription, EmployeeId=:EmployeeId  WHERE SupportRequestId = :SupportRequestId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000O12)
           ,new CursorDef("T000O13", "SAVEPOINT gxupdate;DELETE FROM SupportRequest  WHERE SupportRequestId = :SupportRequestId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000O13)
           ,new CursorDef("T000O14", "SELECT EmployeeBalance, EmployeeFirstName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O15", "SELECT SupportRequestId FROM SupportRequest ORDER BY SupportRequestId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O15,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 2 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 3 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
