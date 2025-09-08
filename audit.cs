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
   public class audit : GXDataArea
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
         Form.Meta.addItem("description", "Audit", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAuditId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public audit( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public audit( IGxContext context )
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
            return "audit_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Audit", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Audit.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Audit.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A204AuditId), 10, 0, ".", "")), StringUtil.LTrim( ((edtAuditId_Enabled!=0) ? context.localUtil.Format( (decimal)(A204AuditId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A204AuditId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAuditId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditDate_Internalname, "Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAuditDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAuditDate_Internalname, context.localUtil.Format(A205AuditDate, "99/99/99"), context.localUtil.Format( A205AuditDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAuditDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Audit.htm");
         GxWebStd.gx_bitmap( context, edtAuditDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAuditDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Audit.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditTableName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditTableName_Internalname, "Table Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditTableName_Internalname, StringUtil.RTrim( A206AuditTableName), StringUtil.RTrim( context.localUtil.Format( A206AuditTableName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditTableName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAuditTableName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAuditDescription_Internalname, A207AuditDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtAuditDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditShortDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditShortDescription_Internalname, "Short Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAuditShortDescription_Internalname, A208AuditShortDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtAuditShortDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditAction_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditAction_Internalname, "Action", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditAction_Internalname, A209AuditAction, StringUtil.RTrim( context.localUtil.Format( A209AuditAction, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditAction_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAuditAction_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserId_Internalname, "User Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserId), 10, 0, ".", "")), StringUtil.LTrim( ((edtSecUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A210SecUserId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A210SecUserId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecUserId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Audit.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Audit.htm");
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
            Z204AuditId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z204AuditId"), ".", ","), 18, MidpointRounding.ToEven));
            Z205AuditDate = context.localUtil.CToD( cgiGet( "Z205AuditDate"), 0);
            Z206AuditTableName = cgiGet( "Z206AuditTableName");
            Z207AuditDescription = cgiGet( "Z207AuditDescription");
            Z208AuditShortDescription = cgiGet( "Z208AuditShortDescription");
            Z209AuditAction = cgiGet( "Z209AuditAction");
            Z210SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z210SecUserId"), ".", ","), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtAuditId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAuditId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AUDITID");
               AnyError = 1;
               GX_FocusControl = edtAuditId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A204AuditId = 0;
               AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
            }
            else
            {
               A204AuditId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAuditId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtAuditDate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Audit Date"}), 1, "AUDITDATE");
               AnyError = 1;
               GX_FocusControl = edtAuditDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A205AuditDate = DateTime.MinValue;
               AssignAttri("", false, "A205AuditDate", context.localUtil.Format(A205AuditDate, "99/99/99"));
            }
            else
            {
               A205AuditDate = context.localUtil.CToD( cgiGet( edtAuditDate_Internalname), 2);
               AssignAttri("", false, "A205AuditDate", context.localUtil.Format(A205AuditDate, "99/99/99"));
            }
            A206AuditTableName = cgiGet( edtAuditTableName_Internalname);
            AssignAttri("", false, "A206AuditTableName", A206AuditTableName);
            A207AuditDescription = cgiGet( edtAuditDescription_Internalname);
            AssignAttri("", false, "A207AuditDescription", A207AuditDescription);
            A208AuditShortDescription = cgiGet( edtAuditShortDescription_Internalname);
            AssignAttri("", false, "A208AuditShortDescription", A208AuditShortDescription);
            A209AuditAction = cgiGet( edtAuditAction_Internalname);
            AssignAttri("", false, "A209AuditAction", A209AuditAction);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A210SecUserId = 0;
               AssignAttri("", false, "A210SecUserId", StringUtil.LTrimStr( (decimal)(A210SecUserId), 10, 0));
            }
            else
            {
               A210SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A210SecUserId", StringUtil.LTrimStr( (decimal)(A210SecUserId), 10, 0));
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
               A204AuditId = (long)(Math.Round(NumberUtil.Val( GetPar( "AuditId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
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
               InitAll0T32( ) ;
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
         DisableAttributes0T32( ) ;
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

      protected void ResetCaption0T0( )
      {
      }

      protected void ZM0T32( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z205AuditDate = T000T3_A205AuditDate[0];
               Z206AuditTableName = T000T3_A206AuditTableName[0];
               Z207AuditDescription = T000T3_A207AuditDescription[0];
               Z208AuditShortDescription = T000T3_A208AuditShortDescription[0];
               Z209AuditAction = T000T3_A209AuditAction[0];
               Z210SecUserId = T000T3_A210SecUserId[0];
            }
            else
            {
               Z205AuditDate = A205AuditDate;
               Z206AuditTableName = A206AuditTableName;
               Z207AuditDescription = A207AuditDescription;
               Z208AuditShortDescription = A208AuditShortDescription;
               Z209AuditAction = A209AuditAction;
               Z210SecUserId = A210SecUserId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z204AuditId = A204AuditId;
            Z205AuditDate = A205AuditDate;
            Z206AuditTableName = A206AuditTableName;
            Z207AuditDescription = A207AuditDescription;
            Z208AuditShortDescription = A208AuditShortDescription;
            Z209AuditAction = A209AuditAction;
            Z210SecUserId = A210SecUserId;
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

      protected void Load0T32( )
      {
         /* Using cursor T000T4 */
         pr_default.execute(2, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound32 = 1;
            A205AuditDate = T000T4_A205AuditDate[0];
            AssignAttri("", false, "A205AuditDate", context.localUtil.Format(A205AuditDate, "99/99/99"));
            A206AuditTableName = T000T4_A206AuditTableName[0];
            AssignAttri("", false, "A206AuditTableName", A206AuditTableName);
            A207AuditDescription = T000T4_A207AuditDescription[0];
            AssignAttri("", false, "A207AuditDescription", A207AuditDescription);
            A208AuditShortDescription = T000T4_A208AuditShortDescription[0];
            AssignAttri("", false, "A208AuditShortDescription", A208AuditShortDescription);
            A209AuditAction = T000T4_A209AuditAction[0];
            AssignAttri("", false, "A209AuditAction", A209AuditAction);
            A210SecUserId = T000T4_A210SecUserId[0];
            AssignAttri("", false, "A210SecUserId", StringUtil.LTrimStr( (decimal)(A210SecUserId), 10, 0));
            ZM0T32( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0T32( ) ;
      }

      protected void OnLoadActions0T32( )
      {
      }

      protected void CheckExtendedTable0T32( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0T32( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0T32( )
      {
         /* Using cursor T000T5 */
         pr_default.execute(3, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000T3 */
         pr_default.execute(1, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0T32( 1) ;
            RcdFound32 = 1;
            A204AuditId = T000T3_A204AuditId[0];
            AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
            A205AuditDate = T000T3_A205AuditDate[0];
            AssignAttri("", false, "A205AuditDate", context.localUtil.Format(A205AuditDate, "99/99/99"));
            A206AuditTableName = T000T3_A206AuditTableName[0];
            AssignAttri("", false, "A206AuditTableName", A206AuditTableName);
            A207AuditDescription = T000T3_A207AuditDescription[0];
            AssignAttri("", false, "A207AuditDescription", A207AuditDescription);
            A208AuditShortDescription = T000T3_A208AuditShortDescription[0];
            AssignAttri("", false, "A208AuditShortDescription", A208AuditShortDescription);
            A209AuditAction = T000T3_A209AuditAction[0];
            AssignAttri("", false, "A209AuditAction", A209AuditAction);
            A210SecUserId = T000T3_A210SecUserId[0];
            AssignAttri("", false, "A210SecUserId", StringUtil.LTrimStr( (decimal)(A210SecUserId), 10, 0));
            Z204AuditId = A204AuditId;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0T32( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey0T32( ) ;
            }
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey0T32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0T32( ) ;
         if ( RcdFound32 == 0 )
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
         RcdFound32 = 0;
         /* Using cursor T000T6 */
         pr_default.execute(4, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000T6_A204AuditId[0] < A204AuditId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000T6_A204AuditId[0] > A204AuditId ) ) )
            {
               A204AuditId = T000T6_A204AuditId[0];
               AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
               RcdFound32 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound32 = 0;
         /* Using cursor T000T7 */
         pr_default.execute(5, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000T7_A204AuditId[0] > A204AuditId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000T7_A204AuditId[0] < A204AuditId ) ) )
            {
               A204AuditId = T000T7_A204AuditId[0];
               AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
               RcdFound32 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0T32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAuditId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0T32( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( A204AuditId != Z204AuditId )
               {
                  A204AuditId = Z204AuditId;
                  AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AUDITID");
                  AnyError = 1;
                  GX_FocusControl = edtAuditId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAuditId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0T32( ) ;
                  GX_FocusControl = edtAuditId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A204AuditId != Z204AuditId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAuditId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0T32( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AUDITID");
                     AnyError = 1;
                     GX_FocusControl = edtAuditId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAuditId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0T32( ) ;
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
         if ( A204AuditId != Z204AuditId )
         {
            A204AuditId = Z204AuditId;
            AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AUDITID");
            AnyError = 1;
            GX_FocusControl = edtAuditId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAuditId_Internalname;
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AUDITID");
            AnyError = 1;
            GX_FocusControl = edtAuditId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAuditDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0T32( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAuditDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0T32( ) ;
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAuditDate_Internalname;
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAuditDate_Internalname;
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
         ScanStart0T32( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound32 != 0 )
            {
               ScanNext0T32( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAuditDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0T32( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0T32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000T2 */
            pr_default.execute(0, new Object[] {A204AuditId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Audit"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z205AuditDate ) != DateTimeUtil.ResetTime ( T000T2_A205AuditDate[0] ) ) || ( StringUtil.StrCmp(Z206AuditTableName, T000T2_A206AuditTableName[0]) != 0 ) || ( StringUtil.StrCmp(Z207AuditDescription, T000T2_A207AuditDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z208AuditShortDescription, T000T2_A208AuditShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z209AuditAction, T000T2_A209AuditAction[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z210SecUserId != T000T2_A210SecUserId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z205AuditDate ) != DateTimeUtil.ResetTime ( T000T2_A205AuditDate[0] ) )
               {
                  GXUtil.WriteLog("audit:[seudo value changed for attri]"+"AuditDate");
                  GXUtil.WriteLogRaw("Old: ",Z205AuditDate);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A205AuditDate[0]);
               }
               if ( StringUtil.StrCmp(Z206AuditTableName, T000T2_A206AuditTableName[0]) != 0 )
               {
                  GXUtil.WriteLog("audit:[seudo value changed for attri]"+"AuditTableName");
                  GXUtil.WriteLogRaw("Old: ",Z206AuditTableName);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A206AuditTableName[0]);
               }
               if ( StringUtil.StrCmp(Z207AuditDescription, T000T2_A207AuditDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("audit:[seudo value changed for attri]"+"AuditDescription");
                  GXUtil.WriteLogRaw("Old: ",Z207AuditDescription);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A207AuditDescription[0]);
               }
               if ( StringUtil.StrCmp(Z208AuditShortDescription, T000T2_A208AuditShortDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("audit:[seudo value changed for attri]"+"AuditShortDescription");
                  GXUtil.WriteLogRaw("Old: ",Z208AuditShortDescription);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A208AuditShortDescription[0]);
               }
               if ( StringUtil.StrCmp(Z209AuditAction, T000T2_A209AuditAction[0]) != 0 )
               {
                  GXUtil.WriteLog("audit:[seudo value changed for attri]"+"AuditAction");
                  GXUtil.WriteLogRaw("Old: ",Z209AuditAction);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A209AuditAction[0]);
               }
               if ( Z210SecUserId != T000T2_A210SecUserId[0] )
               {
                  GXUtil.WriteLog("audit:[seudo value changed for attri]"+"SecUserId");
                  GXUtil.WriteLogRaw("Old: ",Z210SecUserId);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A210SecUserId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Audit"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T32( )
      {
         if ( ! IsAuthorized("audit_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0T32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T32( 0) ;
            CheckOptimisticConcurrency0T32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T8 */
                     pr_default.execute(6, new Object[] {A205AuditDate, A206AuditTableName, A207AuditDescription, A208AuditShortDescription, A209AuditAction, A210SecUserId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000T9 */
                     pr_default.execute(7);
                     A204AuditId = T000T9_A204AuditId[0];
                     AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Audit");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0T0( ) ;
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
               Load0T32( ) ;
            }
            EndLevel0T32( ) ;
         }
         CloseExtendedTableCursors0T32( ) ;
      }

      protected void Update0T32( )
      {
         if ( ! IsAuthorized("audit_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0T32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T32( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0T32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T10 */
                     pr_default.execute(8, new Object[] {A205AuditDate, A206AuditTableName, A207AuditDescription, A208AuditShortDescription, A209AuditAction, A210SecUserId, A204AuditId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Audit");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Audit"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0T32( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0T0( ) ;
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
            EndLevel0T32( ) ;
         }
         CloseExtendedTableCursors0T32( ) ;
      }

      protected void DeferredUpdate0T32( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("audit_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0T32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T32( ) ;
            AfterConfirm0T32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T32( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000T11 */
                  pr_default.execute(9, new Object[] {A204AuditId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Audit");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound32 == 0 )
                        {
                           InitAll0T32( ) ;
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
                        ResetCaption0T0( ) ;
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0T32( ) ;
         Gx_mode = sMode32;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0T32( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0T32( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0T32( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("audit",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("audit",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0T32( )
      {
         /* Using cursor T000T12 */
         pr_default.execute(10);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound32 = 1;
            A204AuditId = T000T12_A204AuditId[0];
            AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0T32( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound32 = 1;
            A204AuditId = T000T12_A204AuditId[0];
            AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
         }
      }

      protected void ScanEnd0T32( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0T32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0T32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0T32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0T32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0T32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T32( )
      {
         edtAuditId_Enabled = 0;
         AssignProp("", false, edtAuditId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditId_Enabled), 5, 0), true);
         edtAuditDate_Enabled = 0;
         AssignProp("", false, edtAuditDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditDate_Enabled), 5, 0), true);
         edtAuditTableName_Enabled = 0;
         AssignProp("", false, edtAuditTableName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditTableName_Enabled), 5, 0), true);
         edtAuditDescription_Enabled = 0;
         AssignProp("", false, edtAuditDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditDescription_Enabled), 5, 0), true);
         edtAuditShortDescription_Enabled = 0;
         AssignProp("", false, edtAuditShortDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditShortDescription_Enabled), 5, 0), true);
         edtAuditAction_Enabled = 0;
         AssignProp("", false, edtAuditAction_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditAction_Enabled), 5, 0), true);
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0T32( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0T0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("audit.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z204AuditId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z204AuditId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z205AuditDate", context.localUtil.DToC( Z205AuditDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z206AuditTableName", StringUtil.RTrim( Z206AuditTableName));
         GxWebStd.gx_hidden_field( context, "Z207AuditDescription", Z207AuditDescription);
         GxWebStd.gx_hidden_field( context, "Z208AuditShortDescription", Z208AuditShortDescription);
         GxWebStd.gx_hidden_field( context, "Z209AuditAction", Z209AuditAction);
         GxWebStd.gx_hidden_field( context, "Z210SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210SecUserId), 10, 0, ".", "")));
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
         return formatLink("audit.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Audit" ;
      }

      public override string GetPgmdesc( )
      {
         return "Audit" ;
      }

      protected void InitializeNonKey0T32( )
      {
         A205AuditDate = DateTime.MinValue;
         AssignAttri("", false, "A205AuditDate", context.localUtil.Format(A205AuditDate, "99/99/99"));
         A206AuditTableName = "";
         AssignAttri("", false, "A206AuditTableName", A206AuditTableName);
         A207AuditDescription = "";
         AssignAttri("", false, "A207AuditDescription", A207AuditDescription);
         A208AuditShortDescription = "";
         AssignAttri("", false, "A208AuditShortDescription", A208AuditShortDescription);
         A209AuditAction = "";
         AssignAttri("", false, "A209AuditAction", A209AuditAction);
         A210SecUserId = 0;
         AssignAttri("", false, "A210SecUserId", StringUtil.LTrimStr( (decimal)(A210SecUserId), 10, 0));
         Z205AuditDate = DateTime.MinValue;
         Z206AuditTableName = "";
         Z207AuditDescription = "";
         Z208AuditShortDescription = "";
         Z209AuditAction = "";
         Z210SecUserId = 0;
      }

      protected void InitAll0T32( )
      {
         A204AuditId = 0;
         AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
         InitializeNonKey0T32( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025981718483", true, true);
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
         context.AddJavascriptSource("audit.js", "?2025981718483", false, true);
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
         edtAuditId_Internalname = "AUDITID";
         edtAuditDate_Internalname = "AUDITDATE";
         edtAuditTableName_Internalname = "AUDITTABLENAME";
         edtAuditDescription_Internalname = "AUDITDESCRIPTION";
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION";
         edtAuditAction_Internalname = "AUDITACTION";
         edtSecUserId_Internalname = "SECUSERID";
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
         Form.Caption = "Audit";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 1;
         edtAuditAction_Jsonclick = "";
         edtAuditAction_Enabled = 1;
         edtAuditShortDescription_Enabled = 1;
         edtAuditDescription_Enabled = 1;
         edtAuditTableName_Jsonclick = "";
         edtAuditTableName_Enabled = 1;
         edtAuditDate_Jsonclick = "";
         edtAuditDate_Enabled = 1;
         edtAuditId_Jsonclick = "";
         edtAuditId_Enabled = 1;
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
         GX_FocusControl = edtAuditDate_Internalname;
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

      public void Valid_Auditid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A205AuditDate", context.localUtil.Format(A205AuditDate, "99/99/99"));
         AssignAttri("", false, "A206AuditTableName", StringUtil.RTrim( A206AuditTableName));
         AssignAttri("", false, "A207AuditDescription", A207AuditDescription);
         AssignAttri("", false, "A208AuditShortDescription", A208AuditShortDescription);
         AssignAttri("", false, "A209AuditAction", A209AuditAction);
         AssignAttri("", false, "A210SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserId), 10, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z204AuditId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z204AuditId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z205AuditDate", context.localUtil.Format(Z205AuditDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z206AuditTableName", StringUtil.RTrim( Z206AuditTableName));
         GxWebStd.gx_hidden_field( context, "Z207AuditDescription", Z207AuditDescription);
         GxWebStd.gx_hidden_field( context, "Z208AuditShortDescription", Z208AuditShortDescription);
         GxWebStd.gx_hidden_field( context, "Z209AuditAction", Z209AuditAction);
         GxWebStd.gx_hidden_field( context, "Z210SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z210SecUserId), 10, 0, ".", "")));
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_AUDITID","""{"handler":"Valid_Auditid","iparms":[{"av":"A204AuditId","fld":"AUDITID","pic":"ZZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_AUDITID",""","oparms":[{"av":"A205AuditDate","fld":"AUDITDATE"},{"av":"A206AuditTableName","fld":"AUDITTABLENAME"},{"av":"A207AuditDescription","fld":"AUDITDESCRIPTION"},{"av":"A208AuditShortDescription","fld":"AUDITSHORTDESCRIPTION"},{"av":"A209AuditAction","fld":"AUDITACTION"},{"av":"A210SecUserId","fld":"SECUSERID","pic":"ZZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z204AuditId"},{"av":"Z205AuditDate"},{"av":"Z206AuditTableName"},{"av":"Z207AuditDescription"},{"av":"Z208AuditShortDescription"},{"av":"Z209AuditAction"},{"av":"Z210SecUserId"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
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
         Z205AuditDate = DateTime.MinValue;
         Z206AuditTableName = "";
         Z207AuditDescription = "";
         Z208AuditShortDescription = "";
         Z209AuditAction = "";
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
         A205AuditDate = DateTime.MinValue;
         A206AuditTableName = "";
         A207AuditDescription = "";
         A208AuditShortDescription = "";
         A209AuditAction = "";
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
         T000T4_A204AuditId = new long[1] ;
         T000T4_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         T000T4_A206AuditTableName = new string[] {""} ;
         T000T4_A207AuditDescription = new string[] {""} ;
         T000T4_A208AuditShortDescription = new string[] {""} ;
         T000T4_A209AuditAction = new string[] {""} ;
         T000T4_A210SecUserId = new long[1] ;
         T000T5_A204AuditId = new long[1] ;
         T000T3_A204AuditId = new long[1] ;
         T000T3_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         T000T3_A206AuditTableName = new string[] {""} ;
         T000T3_A207AuditDescription = new string[] {""} ;
         T000T3_A208AuditShortDescription = new string[] {""} ;
         T000T3_A209AuditAction = new string[] {""} ;
         T000T3_A210SecUserId = new long[1] ;
         sMode32 = "";
         T000T6_A204AuditId = new long[1] ;
         T000T7_A204AuditId = new long[1] ;
         T000T2_A204AuditId = new long[1] ;
         T000T2_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         T000T2_A206AuditTableName = new string[] {""} ;
         T000T2_A207AuditDescription = new string[] {""} ;
         T000T2_A208AuditShortDescription = new string[] {""} ;
         T000T2_A209AuditAction = new string[] {""} ;
         T000T2_A210SecUserId = new long[1] ;
         T000T9_A204AuditId = new long[1] ;
         T000T12_A204AuditId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ205AuditDate = DateTime.MinValue;
         ZZ206AuditTableName = "";
         ZZ207AuditDescription = "";
         ZZ208AuditShortDescription = "";
         ZZ209AuditAction = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.audit__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.audit__default(),
            new Object[][] {
                new Object[] {
               T000T2_A204AuditId, T000T2_A205AuditDate, T000T2_A206AuditTableName, T000T2_A207AuditDescription, T000T2_A208AuditShortDescription, T000T2_A209AuditAction, T000T2_A210SecUserId
               }
               , new Object[] {
               T000T3_A204AuditId, T000T3_A205AuditDate, T000T3_A206AuditTableName, T000T3_A207AuditDescription, T000T3_A208AuditShortDescription, T000T3_A209AuditAction, T000T3_A210SecUserId
               }
               , new Object[] {
               T000T4_A204AuditId, T000T4_A205AuditDate, T000T4_A206AuditTableName, T000T4_A207AuditDescription, T000T4_A208AuditShortDescription, T000T4_A209AuditAction, T000T4_A210SecUserId
               }
               , new Object[] {
               T000T5_A204AuditId
               }
               , new Object[] {
               T000T6_A204AuditId
               }
               , new Object[] {
               T000T7_A204AuditId
               }
               , new Object[] {
               }
               , new Object[] {
               T000T9_A204AuditId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000T12_A204AuditId
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
      private short RcdFound32 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAuditId_Enabled ;
      private int edtAuditDate_Enabled ;
      private int edtAuditTableName_Enabled ;
      private int edtAuditDescription_Enabled ;
      private int edtAuditShortDescription_Enabled ;
      private int edtAuditAction_Enabled ;
      private int edtSecUserId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z204AuditId ;
      private long Z210SecUserId ;
      private long A204AuditId ;
      private long A210SecUserId ;
      private long ZZ204AuditId ;
      private long ZZ210SecUserId ;
      private string sPrefix ;
      private string Z206AuditTableName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAuditId_Internalname ;
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
      private string edtAuditId_Jsonclick ;
      private string edtAuditDate_Internalname ;
      private string edtAuditDate_Jsonclick ;
      private string edtAuditTableName_Internalname ;
      private string A206AuditTableName ;
      private string edtAuditTableName_Jsonclick ;
      private string edtAuditDescription_Internalname ;
      private string edtAuditShortDescription_Internalname ;
      private string edtAuditAction_Internalname ;
      private string edtAuditAction_Jsonclick ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserId_Jsonclick ;
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
      private string sMode32 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ206AuditTableName ;
      private DateTime Z205AuditDate ;
      private DateTime A205AuditDate ;
      private DateTime ZZ205AuditDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z207AuditDescription ;
      private string Z208AuditShortDescription ;
      private string Z209AuditAction ;
      private string A207AuditDescription ;
      private string A208AuditShortDescription ;
      private string A209AuditAction ;
      private string ZZ207AuditDescription ;
      private string ZZ208AuditShortDescription ;
      private string ZZ209AuditAction ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T000T4_A204AuditId ;
      private DateTime[] T000T4_A205AuditDate ;
      private string[] T000T4_A206AuditTableName ;
      private string[] T000T4_A207AuditDescription ;
      private string[] T000T4_A208AuditShortDescription ;
      private string[] T000T4_A209AuditAction ;
      private long[] T000T4_A210SecUserId ;
      private long[] T000T5_A204AuditId ;
      private long[] T000T3_A204AuditId ;
      private DateTime[] T000T3_A205AuditDate ;
      private string[] T000T3_A206AuditTableName ;
      private string[] T000T3_A207AuditDescription ;
      private string[] T000T3_A208AuditShortDescription ;
      private string[] T000T3_A209AuditAction ;
      private long[] T000T3_A210SecUserId ;
      private long[] T000T6_A204AuditId ;
      private long[] T000T7_A204AuditId ;
      private long[] T000T2_A204AuditId ;
      private DateTime[] T000T2_A205AuditDate ;
      private string[] T000T2_A206AuditTableName ;
      private string[] T000T2_A207AuditDescription ;
      private string[] T000T2_A208AuditShortDescription ;
      private string[] T000T2_A209AuditAction ;
      private long[] T000T2_A210SecUserId ;
      private long[] T000T9_A204AuditId ;
      private long[] T000T12_A204AuditId ;
      private IDataStoreProvider pr_gam ;
   }

   public class audit__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class audit__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000T2;
        prmT000T2 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T3;
        prmT000T3 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T4;
        prmT000T4 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T5;
        prmT000T5 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T6;
        prmT000T6 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T7;
        prmT000T7 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T8;
        prmT000T8 = new Object[] {
        new ParDef("AuditDate",GXType.Date,8,0) ,
        new ParDef("AuditTableName",GXType.Char,100,0) ,
        new ParDef("AuditDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditShortDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditAction",GXType.VarChar,10,0) ,
        new ParDef("SecUserId",GXType.Int64,10,0)
        };
        Object[] prmT000T9;
        prmT000T9 = new Object[] {
        };
        Object[] prmT000T10;
        prmT000T10 = new Object[] {
        new ParDef("AuditDate",GXType.Date,8,0) ,
        new ParDef("AuditTableName",GXType.Char,100,0) ,
        new ParDef("AuditDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditShortDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditAction",GXType.VarChar,10,0) ,
        new ParDef("SecUserId",GXType.Int64,10,0) ,
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T11;
        prmT000T11 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T12;
        prmT000T12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000T2", "SELECT AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, AuditAction, SecUserId FROM Audit WHERE AuditId = :AuditId  FOR UPDATE OF Audit NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T3", "SELECT AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, AuditAction, SecUserId FROM Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T4", "SELECT TM1.AuditId, TM1.AuditDate, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.AuditAction, TM1.SecUserId FROM Audit TM1 WHERE TM1.AuditId = :AuditId ORDER BY TM1.AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T5", "SELECT AuditId FROM Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T6", "SELECT AuditId FROM Audit WHERE ( AuditId > :AuditId) ORDER BY AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T7", "SELECT AuditId FROM Audit WHERE ( AuditId < :AuditId) ORDER BY AuditId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T8", "SAVEPOINT gxupdate;INSERT INTO Audit(AuditDate, AuditTableName, AuditDescription, AuditShortDescription, AuditAction, SecUserId) VALUES(:AuditDate, :AuditTableName, :AuditDescription, :AuditShortDescription, :AuditAction, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000T8)
           ,new CursorDef("T000T9", "SELECT currval('AuditId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T10", "SAVEPOINT gxupdate;UPDATE Audit SET AuditDate=:AuditDate, AuditTableName=:AuditTableName, AuditDescription=:AuditDescription, AuditShortDescription=:AuditShortDescription, AuditAction=:AuditAction, SecUserId=:SecUserId  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T10)
           ,new CursorDef("T000T11", "SAVEPOINT gxupdate;DELETE FROM Audit  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T11)
           ,new CursorDef("T000T12", "SELECT AuditId FROM Audit ORDER BY AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T12,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
