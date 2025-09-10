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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A106EmployeeId) ;
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
               AV7AuditId = (long)(Math.Round(NumberUtil.Val( GetPar( "AuditId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7AuditId", StringUtil.LTrimStr( (decimal)(AV7AuditId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vAUDITID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AuditId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Audit", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAuditDate_Internalname;
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

      public void execute( string aP0_Gx_mode ,
                           long aP1_AuditId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AuditId = aP1_AuditId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditId_Internalname, "Id", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A204AuditId), 10, 0, ".", "")), StringUtil.LTrim( ((edtAuditId_Enabled!=0) ? context.localUtil.Format( (decimal)(A204AuditId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A204AuditId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAuditId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditDate_Internalname, "Date", " AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAuditDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAuditDate_Internalname, context.localUtil.Format(A205AuditDate, "99/99/99"), context.localUtil.Format( A205AuditDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtAuditDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Audit.htm");
         GxWebStd.gx_bitmap( context, edtAuditDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAuditDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Audit.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditTableName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditTableName_Internalname, "Table Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditTableName_Internalname, StringUtil.RTrim( A206AuditTableName), StringUtil.RTrim( context.localUtil.Format( A206AuditTableName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditTableName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAuditTableName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditDescription_Internalname, "Description", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAuditDescription_Internalname, A207AuditDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtAuditDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditShortDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditShortDescription_Internalname, "Short Description", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAuditShortDescription_Internalname, A208AuditShortDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", 0, 1, edtAuditShortDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditAction_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditAction_Internalname, "Action", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditAction_Internalname, A209AuditAction, StringUtil.RTrim( context.localUtil.Format( A209AuditAction, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditAction_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAuditAction_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserId_Internalname, "User Id", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A210SecUserId), 10, 0, ".", "")), StringUtil.LTrim( ((edtSecUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A210SecUserId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A210SecUserId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecUserId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedemployeeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockemployeeid_Internalname, "Employees", "", "", lblTextblockemployeeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_employeeid.SetProperty("Caption", Combo_employeeid_Caption);
         ucCombo_employeeid.SetProperty("Cls", Combo_employeeid_Cls);
         ucCombo_employeeid.SetProperty("DataListProc", Combo_employeeid_Datalistproc);
         ucCombo_employeeid.SetProperty("DataListProcParametersPrefix", Combo_employeeid_Datalistprocparametersprefix);
         ucCombo_employeeid.SetProperty("EmptyItem", Combo_employeeid_Emptyitem);
         ucCombo_employeeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_employeeid.SetProperty("DropDownOptionsData", AV14EmployeeId_Data);
         ucCombo_employeeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_employeeid_Internalname, "COMBO_EMPLOYEEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeId_Internalname, "Employee Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeId_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeId_Visible, edtEmployeeId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Audit.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeName_Internalname, "Employee Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeName_Internalname, StringUtil.RTrim( A148EmployeeName), StringUtil.RTrim( context.localUtil.Format( A148EmployeeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Audit.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Audit.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_employeeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboemployeeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboEmployeeId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavComboemployeeid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboEmployeeId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboEmployeeId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboemployeeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboemployeeid_Visible, edtavComboemployeeid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Audit.htm");
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
         E110T2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEEID_DATA"), AV14EmployeeId_Data);
               /* Read saved values. */
               Z204AuditId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z204AuditId"), ".", ","), 18, MidpointRounding.ToEven));
               Z205AuditDate = context.localUtil.CToD( cgiGet( "Z205AuditDate"), 0);
               Z206AuditTableName = cgiGet( "Z206AuditTableName");
               Z207AuditDescription = cgiGet( "Z207AuditDescription");
               Z208AuditShortDescription = cgiGet( "Z208AuditShortDescription");
               Z209AuditAction = cgiGet( "Z209AuditAction");
               Z210SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z210SecUserId"), ".", ","), 18, MidpointRounding.ToEven));
               Z211Trn_Id = cgiGet( "Z211Trn_Id");
               Z106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
               A211Trn_Id = cgiGet( "Z211Trn_Id");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7AuditId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vAUDITID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Insert_EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_EMPLOYEEID"), ".", ","), 18, MidpointRounding.ToEven));
               A211Trn_Id = cgiGet( "TRN_ID");
               A147EmployeeBalance = context.localUtil.CToN( cgiGet( "EMPLOYEEBALANCE"), ".", ",");
               AV22Pgmname = cgiGet( "vPGMNAME");
               Combo_employeeid_Objectcall = cgiGet( "COMBO_EMPLOYEEID_Objectcall");
               Combo_employeeid_Class = cgiGet( "COMBO_EMPLOYEEID_Class");
               Combo_employeeid_Icontype = cgiGet( "COMBO_EMPLOYEEID_Icontype");
               Combo_employeeid_Icon = cgiGet( "COMBO_EMPLOYEEID_Icon");
               Combo_employeeid_Caption = cgiGet( "COMBO_EMPLOYEEID_Caption");
               Combo_employeeid_Tooltip = cgiGet( "COMBO_EMPLOYEEID_Tooltip");
               Combo_employeeid_Cls = cgiGet( "COMBO_EMPLOYEEID_Cls");
               Combo_employeeid_Selectedvalue_set = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_set");
               Combo_employeeid_Selectedvalue_get = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_get");
               Combo_employeeid_Selectedtext_set = cgiGet( "COMBO_EMPLOYEEID_Selectedtext_set");
               Combo_employeeid_Selectedtext_get = cgiGet( "COMBO_EMPLOYEEID_Selectedtext_get");
               Combo_employeeid_Gamoauthtoken = cgiGet( "COMBO_EMPLOYEEID_Gamoauthtoken");
               Combo_employeeid_Ddointernalname = cgiGet( "COMBO_EMPLOYEEID_Ddointernalname");
               Combo_employeeid_Titlecontrolalign = cgiGet( "COMBO_EMPLOYEEID_Titlecontrolalign");
               Combo_employeeid_Dropdownoptionstype = cgiGet( "COMBO_EMPLOYEEID_Dropdownoptionstype");
               Combo_employeeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Enabled"));
               Combo_employeeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Visible"));
               Combo_employeeid_Titlecontrolidtoreplace = cgiGet( "COMBO_EMPLOYEEID_Titlecontrolidtoreplace");
               Combo_employeeid_Datalisttype = cgiGet( "COMBO_EMPLOYEEID_Datalisttype");
               Combo_employeeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Allowmultipleselection"));
               Combo_employeeid_Datalistfixedvalues = cgiGet( "COMBO_EMPLOYEEID_Datalistfixedvalues");
               Combo_employeeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Isgriditem"));
               Combo_employeeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Hasdescription"));
               Combo_employeeid_Datalistproc = cgiGet( "COMBO_EMPLOYEEID_Datalistproc");
               Combo_employeeid_Datalistprocparametersprefix = cgiGet( "COMBO_EMPLOYEEID_Datalistprocparametersprefix");
               Combo_employeeid_Remoteservicesparameters = cgiGet( "COMBO_EMPLOYEEID_Remoteservicesparameters");
               Combo_employeeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_EMPLOYEEID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_employeeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Includeonlyselectedoption"));
               Combo_employeeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Includeselectalloption"));
               Combo_employeeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Emptyitem"));
               Combo_employeeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Includeaddnewoption"));
               Combo_employeeid_Htmltemplate = cgiGet( "COMBO_EMPLOYEEID_Htmltemplate");
               Combo_employeeid_Multiplevaluestype = cgiGet( "COMBO_EMPLOYEEID_Multiplevaluestype");
               Combo_employeeid_Loadingdata = cgiGet( "COMBO_EMPLOYEEID_Loadingdata");
               Combo_employeeid_Noresultsfound = cgiGet( "COMBO_EMPLOYEEID_Noresultsfound");
               Combo_employeeid_Emptyitemtext = cgiGet( "COMBO_EMPLOYEEID_Emptyitemtext");
               Combo_employeeid_Onlyselectedvalues = cgiGet( "COMBO_EMPLOYEEID_Onlyselectedvalues");
               Combo_employeeid_Selectalltext = cgiGet( "COMBO_EMPLOYEEID_Selectalltext");
               Combo_employeeid_Multiplevaluesseparator = cgiGet( "COMBO_EMPLOYEEID_Multiplevaluesseparator");
               Combo_employeeid_Addnewoptiontext = cgiGet( "COMBO_EMPLOYEEID_Addnewoptiontext");
               Combo_employeeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_EMPLOYEEID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A204AuditId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAuditId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
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
               A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
               AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
               AV19ComboEmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboemployeeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ComboEmployeeId", StringUtil.LTrimStr( (decimal)(AV19ComboEmployeeId), 10, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Audit");
               A204AuditId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAuditId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
               forbiddenHiddens.Add("AuditId", context.localUtil.Format( (decimal)(A204AuditId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Trn_Id", StringUtil.RTrim( context.localUtil.Format( A211Trn_Id, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A204AuditId != Z204AuditId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("audit:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A204AuditId = (long)(Math.Round(NumberUtil.Val( GetPar( "AuditId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
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
                     sMode32 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode32;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound32 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0T0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "AUDITID");
                        AnyError = 1;
                        GX_FocusControl = edtAuditId_Internalname;
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
                           E110T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120T2 ();
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
            E120T2 ();
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
            DisableAttributes0T32( ) ;
         }
         AssignProp("", false, edtavComboemployeeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboemployeeid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0T0( )
      {
         BeforeValidate0T32( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0T32( ) ;
            }
            else
            {
               CheckExtendedTable0T32( ) ;
               CloseExtendedTableCursors0T32( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0T0( )
      {
      }

      protected void E110T2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV20GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV21GAMErrors);
         Combo_employeeid_Gamoauthtoken = AV20GAMSession.gxTpr_Token;
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "GAMOAuthToken", Combo_employeeid_Gamoauthtoken);
         edtEmployeeId_Visible = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), true);
         AV19ComboEmployeeId = 0;
         AssignAttri("", false, "AV19ComboEmployeeId", StringUtil.LTrimStr( (decimal)(AV19ComboEmployeeId), 10, 0));
         edtavComboemployeeid_Visible = 0;
         AssignProp("", false, edtavComboemployeeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboemployeeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            while ( AV23GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "EmployeeId") == 0 )
               {
                  AV12Insert_EmployeeId = (long)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_EmployeeId", StringUtil.LTrimStr( (decimal)(AV12Insert_EmployeeId), 10, 0));
                  if ( ! (0==AV12Insert_EmployeeId) )
                  {
                     AV19ComboEmployeeId = AV12Insert_EmployeeId;
                     AssignAttri("", false, "AV19ComboEmployeeId", StringUtil.LTrimStr( (decimal)(AV19ComboEmployeeId), 10, 0));
                     Combo_employeeid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboEmployeeId), 10, 0));
                     ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new auditloaddvcombo(context ).execute(  "EmployeeId",  "GET",  false,  AV7AuditId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_employeeid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedText_set", Combo_employeeid_Selectedtext_set);
                     Combo_employeeid_Enabled = false;
                     ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_employeeid_Enabled));
                  }
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
      }

      protected void E120T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("auditww.aspx") );
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
         /* 'LOADCOMBOEMPLOYEEID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new auditloaddvcombo(context ).execute(  "EmployeeId",  Gx_mode,  false,  AV7AuditId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_employeeid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
         Combo_employeeid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedText_set", Combo_employeeid_Selectedtext_set);
         AV19ComboEmployeeId = (long)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19ComboEmployeeId", StringUtil.LTrimStr( (decimal)(AV19ComboEmployeeId), 10, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_employeeid_Enabled = false;
            ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_employeeid_Enabled));
         }
      }

      protected void ZM0T32( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z205AuditDate = T000T3_A205AuditDate[0];
               Z206AuditTableName = T000T3_A206AuditTableName[0];
               Z207AuditDescription = T000T3_A207AuditDescription[0];
               Z208AuditShortDescription = T000T3_A208AuditShortDescription[0];
               Z209AuditAction = T000T3_A209AuditAction[0];
               Z210SecUserId = T000T3_A210SecUserId[0];
               Z211Trn_Id = T000T3_A211Trn_Id[0];
               Z106EmployeeId = T000T3_A106EmployeeId[0];
            }
            else
            {
               Z205AuditDate = A205AuditDate;
               Z206AuditTableName = A206AuditTableName;
               Z207AuditDescription = A207AuditDescription;
               Z208AuditShortDescription = A208AuditShortDescription;
               Z209AuditAction = A209AuditAction;
               Z210SecUserId = A210SecUserId;
               Z211Trn_Id = A211Trn_Id;
               Z106EmployeeId = A106EmployeeId;
            }
         }
         if ( GX_JID == -8 )
         {
            Z204AuditId = A204AuditId;
            Z205AuditDate = A205AuditDate;
            Z206AuditTableName = A206AuditTableName;
            Z207AuditDescription = A207AuditDescription;
            Z208AuditShortDescription = A208AuditShortDescription;
            Z209AuditAction = A209AuditAction;
            Z210SecUserId = A210SecUserId;
            Z211Trn_Id = A211Trn_Id;
            Z106EmployeeId = A106EmployeeId;
            Z147EmployeeBalance = A147EmployeeBalance;
            Z148EmployeeName = A148EmployeeName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAuditId_Enabled = 0;
         AssignProp("", false, edtAuditId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditId_Enabled), 5, 0), true);
         AV22Pgmname = "Audit";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         edtAuditId_Enabled = 0;
         AssignProp("", false, edtAuditId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AuditId) )
         {
            A204AuditId = AV7AuditId;
            AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_EmployeeId) )
         {
            edtEmployeeId_Enabled = 0;
            AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         }
         else
         {
            edtEmployeeId_Enabled = 1;
            AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_EmployeeId) )
         {
            A106EmployeeId = AV12Insert_EmployeeId;
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         else
         {
            A106EmployeeId = AV19ComboEmployeeId;
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000T4 */
            pr_default.execute(2, new Object[] {A106EmployeeId});
            A147EmployeeBalance = T000T4_A147EmployeeBalance[0];
            A148EmployeeName = T000T4_A148EmployeeName[0];
            AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
            pr_default.close(2);
         }
      }

      protected void Load0T32( )
      {
         /* Using cursor T000T5 */
         pr_default.execute(3, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound32 = 1;
            A147EmployeeBalance = T000T5_A147EmployeeBalance[0];
            A205AuditDate = T000T5_A205AuditDate[0];
            AssignAttri("", false, "A205AuditDate", context.localUtil.Format(A205AuditDate, "99/99/99"));
            A206AuditTableName = T000T5_A206AuditTableName[0];
            AssignAttri("", false, "A206AuditTableName", A206AuditTableName);
            A207AuditDescription = T000T5_A207AuditDescription[0];
            AssignAttri("", false, "A207AuditDescription", A207AuditDescription);
            A208AuditShortDescription = T000T5_A208AuditShortDescription[0];
            AssignAttri("", false, "A208AuditShortDescription", A208AuditShortDescription);
            A209AuditAction = T000T5_A209AuditAction[0];
            AssignAttri("", false, "A209AuditAction", A209AuditAction);
            A210SecUserId = T000T5_A210SecUserId[0];
            AssignAttri("", false, "A210SecUserId", StringUtil.LTrimStr( (decimal)(A210SecUserId), 10, 0));
            A148EmployeeName = T000T5_A148EmployeeName[0];
            AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
            A211Trn_Id = T000T5_A211Trn_Id[0];
            A106EmployeeId = T000T5_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            ZM0T32( -8) ;
         }
         pr_default.close(3);
         OnLoadActions0T32( ) ;
      }

      protected void OnLoadActions0T32( )
      {
      }

      protected void CheckExtendedTable0T32( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000T4 */
         pr_default.execute(2, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A147EmployeeBalance = T000T4_A147EmployeeBalance[0];
         A148EmployeeName = T000T4_A148EmployeeName[0];
         AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0T32( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( long A106EmployeeId )
      {
         /* Using cursor T000T6 */
         pr_default.execute(4, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A147EmployeeBalance = T000T6_A147EmployeeBalance[0];
         A148EmployeeName = T000T6_A148EmployeeName[0];
         AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A148EmployeeName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0T32( )
      {
         /* Using cursor T000T7 */
         pr_default.execute(5, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000T3 */
         pr_default.execute(1, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0T32( 8) ;
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
            A211Trn_Id = T000T3_A211Trn_Id[0];
            A106EmployeeId = T000T3_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            Z204AuditId = A204AuditId;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
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
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound32 = 0;
         /* Using cursor T000T8 */
         pr_default.execute(6, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000T8_A204AuditId[0] < A204AuditId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000T8_A204AuditId[0] > A204AuditId ) ) )
            {
               A204AuditId = T000T8_A204AuditId[0];
               AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
               RcdFound32 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound32 = 0;
         /* Using cursor T000T9 */
         pr_default.execute(7, new Object[] {A204AuditId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000T9_A204AuditId[0] > A204AuditId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000T9_A204AuditId[0] < A204AuditId ) ) )
            {
               A204AuditId = T000T9_A204AuditId[0];
               AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
               RcdFound32 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0T32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAuditDate_Internalname;
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
                  GX_FocusControl = edtAuditDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0T32( ) ;
                  GX_FocusControl = edtAuditDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A204AuditId != Z204AuditId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAuditDate_Internalname;
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
                     /* Insert record */
                     GX_FocusControl = edtAuditDate_Internalname;
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
            GX_FocusControl = edtAuditDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
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
            if ( Gx_longc || ( Z210SecUserId != T000T2_A210SecUserId[0] ) || ( StringUtil.StrCmp(Z211Trn_Id, T000T2_A211Trn_Id[0]) != 0 ) || ( Z106EmployeeId != T000T2_A106EmployeeId[0] ) )
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
               if ( StringUtil.StrCmp(Z211Trn_Id, T000T2_A211Trn_Id[0]) != 0 )
               {
                  GXUtil.WriteLog("audit:[seudo value changed for attri]"+"Trn_Id");
                  GXUtil.WriteLogRaw("Old: ",Z211Trn_Id);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A211Trn_Id[0]);
               }
               if ( Z106EmployeeId != T000T2_A106EmployeeId[0] )
               {
                  GXUtil.WriteLog("audit:[seudo value changed for attri]"+"EmployeeId");
                  GXUtil.WriteLogRaw("Old: ",Z106EmployeeId);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A106EmployeeId[0]);
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
                     /* Using cursor T000T10 */
                     pr_default.execute(8, new Object[] {A205AuditDate, A206AuditTableName, A207AuditDescription, A208AuditShortDescription, A209AuditAction, A210SecUserId, A211Trn_Id, A106EmployeeId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000T11 */
                     pr_default.execute(9);
                     A204AuditId = T000T11_A204AuditId[0];
                     AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
                     pr_default.close(9);
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
                     /* Using cursor T000T12 */
                     pr_default.execute(10, new Object[] {A205AuditDate, A206AuditTableName, A207AuditDescription, A208AuditShortDescription, A209AuditAction, A210SecUserId, A211Trn_Id, A106EmployeeId, A204AuditId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Audit");
                     if ( (pr_default.getStatus(10) == 103) )
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
                  /* Using cursor T000T13 */
                  pr_default.execute(11, new Object[] {A204AuditId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Audit");
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
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000T14 */
            pr_default.execute(12, new Object[] {A106EmployeeId});
            A147EmployeeBalance = T000T14_A147EmployeeBalance[0];
            A148EmployeeName = T000T14_A148EmployeeName[0];
            AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
            pr_default.close(12);
         }
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
         /* Scan By routine */
         /* Using cursor T000T15 */
         pr_default.execute(13);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound32 = 1;
            A204AuditId = T000T15_A204AuditId[0];
            AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0T32( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound32 = 1;
            A204AuditId = T000T15_A204AuditId[0];
            AssignAttri("", false, "A204AuditId", StringUtil.LTrimStr( (decimal)(A204AuditId), 10, 0));
         }
      }

      protected void ScanEnd0T32( )
      {
         pr_default.close(13);
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
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         edtEmployeeName_Enabled = 0;
         AssignProp("", false, edtEmployeeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Enabled), 5, 0), true);
         edtavComboemployeeid_Enabled = 0;
         AssignProp("", false, edtavComboemployeeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboemployeeid_Enabled), 5, 0), true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("audit.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AuditId,10,0))}, new string[] {"Gx_mode","AuditId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Audit");
         forbiddenHiddens.Add("AuditId", context.localUtil.Format( (decimal)(A204AuditId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Trn_Id", StringUtil.RTrim( context.localUtil.Format( A211Trn_Id, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("audit:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
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
         GxWebStd.gx_hidden_field( context, "Z211Trn_Id", Z211Trn_Id);
         GxWebStd.gx_hidden_field( context, "Z106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID_DATA", AV14EmployeeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID_DATA", AV14EmployeeId_Data);
         }
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
         GxWebStd.gx_hidden_field( context, "vAUDITID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AuditId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUDITID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AuditId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRN_ID", A211Trn_Id);
         GxWebStd.gx_hidden_field( context, "EMPLOYEEBALANCE", StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Objectcall", StringUtil.RTrim( Combo_employeeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Cls", StringUtil.RTrim( Combo_employeeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_set", StringUtil.RTrim( Combo_employeeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedtext_set", StringUtil.RTrim( Combo_employeeid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Gamoauthtoken", StringUtil.RTrim( Combo_employeeid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Enabled", StringUtil.BoolToStr( Combo_employeeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Datalistproc", StringUtil.RTrim( Combo_employeeid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_employeeid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Emptyitem", StringUtil.BoolToStr( Combo_employeeid_Emptyitem));
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
         return formatLink("audit.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AuditId,10,0))}, new string[] {"Gx_mode","AuditId"})  ;
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
         A106EmployeeId = 0;
         AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         A147EmployeeBalance = 0;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
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
         A148EmployeeName = "";
         AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
         A211Trn_Id = "";
         AssignAttri("", false, "A211Trn_Id", A211Trn_Id);
         Z205AuditDate = DateTime.MinValue;
         Z206AuditTableName = "";
         Z207AuditDescription = "";
         Z208AuditShortDescription = "";
         Z209AuditAction = "";
         Z210SecUserId = 0;
         Z211Trn_Id = "";
         Z106EmployeeId = 0;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20259910161531", true, true);
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
         context.AddJavascriptSource("audit.js", "?20259910161532", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtAuditId_Internalname = "AUDITID";
         edtAuditDate_Internalname = "AUDITDATE";
         edtAuditTableName_Internalname = "AUDITTABLENAME";
         edtAuditDescription_Internalname = "AUDITDESCRIPTION";
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION";
         edtAuditAction_Internalname = "AUDITACTION";
         edtSecUserId_Internalname = "SECUSERID";
         lblTextblockemployeeid_Internalname = "TEXTBLOCKEMPLOYEEID";
         Combo_employeeid_Internalname = "COMBO_EMPLOYEEID";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         divTablesplittedemployeeid_Internalname = "TABLESPLITTEDEMPLOYEEID";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboemployeeid_Internalname = "vCOMBOEMPLOYEEID";
         divSectionattribute_employeeid_Internalname = "SECTIONATTRIBUTE_EMPLOYEEID";
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
         Form.Caption = "Audit";
         edtavComboemployeeid_Jsonclick = "";
         edtavComboemployeeid_Enabled = 0;
         edtavComboemployeeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtEmployeeName_Jsonclick = "";
         edtEmployeeName_Enabled = 0;
         edtEmployeeId_Jsonclick = "";
         edtEmployeeId_Enabled = 1;
         edtEmployeeId_Visible = 1;
         Combo_employeeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_employeeid_Datalistprocparametersprefix = " \"ComboName\": \"EmployeeId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"AuditId\": 0";
         Combo_employeeid_Datalistproc = "AuditLoadDVCombo";
         Combo_employeeid_Cls = "ExtendedCombo Attribute";
         Combo_employeeid_Caption = "";
         Combo_employeeid_Enabled = Convert.ToBoolean( -1);
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
         edtAuditId_Enabled = 0;
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

      public void Valid_Employeeid( )
      {
         /* Using cursor T000T14 */
         pr_default.execute(12, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
         }
         A147EmployeeBalance = T000T14_A147EmployeeBalance[0];
         A148EmployeeName = T000T14_A148EmployeeName[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")));
         AssignAttri("", false, "A148EmployeeName", StringUtil.RTrim( A148EmployeeName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7AuditId","fld":"vAUDITID","pic":"ZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7AuditId","fld":"vAUDITID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A204AuditId","fld":"AUDITID","pic":"ZZZZZZZZZ9"},{"av":"A211Trn_Id","fld":"TRN_ID"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120T2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_AUDITID","""{"handler":"Valid_Auditid","iparms":[]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A147EmployeeBalance","fld":"EMPLOYEEBALANCE","pic":"Z9.9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"}]""");
         setEventMetadata("VALID_EMPLOYEEID",""","oparms":[{"av":"A147EmployeeBalance","fld":"EMPLOYEEBALANCE","pic":"Z9.9"},{"av":"A148EmployeeName","fld":"EMPLOYEENAME"}]}""");
         setEventMetadata("VALIDV_COMBOEMPLOYEEID","""{"handler":"Validv_Comboemployeeid","iparms":[]}""");
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
         wcpOGx_mode = "";
         Z205AuditDate = DateTime.MinValue;
         Z206AuditTableName = "";
         Z207AuditDescription = "";
         Z208AuditShortDescription = "";
         Z209AuditAction = "";
         Z211Trn_Id = "";
         Combo_employeeid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A205AuditDate = DateTime.MinValue;
         A206AuditTableName = "";
         A207AuditDescription = "";
         A208AuditShortDescription = "";
         A209AuditAction = "";
         lblTextblockemployeeid_Jsonclick = "";
         ucCombo_employeeid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14EmployeeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A148EmployeeName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A211Trn_Id = "";
         AV22Pgmname = "";
         Combo_employeeid_Objectcall = "";
         Combo_employeeid_Class = "";
         Combo_employeeid_Icontype = "";
         Combo_employeeid_Icon = "";
         Combo_employeeid_Tooltip = "";
         Combo_employeeid_Selectedvalue_set = "";
         Combo_employeeid_Selectedtext_set = "";
         Combo_employeeid_Selectedtext_get = "";
         Combo_employeeid_Gamoauthtoken = "";
         Combo_employeeid_Ddointernalname = "";
         Combo_employeeid_Titlecontrolalign = "";
         Combo_employeeid_Dropdownoptionstype = "";
         Combo_employeeid_Titlecontrolidtoreplace = "";
         Combo_employeeid_Datalisttype = "";
         Combo_employeeid_Datalistfixedvalues = "";
         Combo_employeeid_Remoteservicesparameters = "";
         Combo_employeeid_Htmltemplate = "";
         Combo_employeeid_Multiplevaluestype = "";
         Combo_employeeid_Loadingdata = "";
         Combo_employeeid_Noresultsfound = "";
         Combo_employeeid_Emptyitemtext = "";
         Combo_employeeid_Onlyselectedvalues = "";
         Combo_employeeid_Selectalltext = "";
         Combo_employeeid_Multiplevaluesseparator = "";
         Combo_employeeid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode32 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV20GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV21GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV18Combo_DataJson = "";
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         GXt_char2 = "";
         Z148EmployeeName = "";
         T000T4_A147EmployeeBalance = new decimal[1] ;
         T000T4_A148EmployeeName = new string[] {""} ;
         T000T5_A147EmployeeBalance = new decimal[1] ;
         T000T5_A204AuditId = new long[1] ;
         T000T5_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         T000T5_A206AuditTableName = new string[] {""} ;
         T000T5_A207AuditDescription = new string[] {""} ;
         T000T5_A208AuditShortDescription = new string[] {""} ;
         T000T5_A209AuditAction = new string[] {""} ;
         T000T5_A210SecUserId = new long[1] ;
         T000T5_A148EmployeeName = new string[] {""} ;
         T000T5_A211Trn_Id = new string[] {""} ;
         T000T5_A106EmployeeId = new long[1] ;
         T000T6_A147EmployeeBalance = new decimal[1] ;
         T000T6_A148EmployeeName = new string[] {""} ;
         T000T7_A204AuditId = new long[1] ;
         T000T3_A204AuditId = new long[1] ;
         T000T3_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         T000T3_A206AuditTableName = new string[] {""} ;
         T000T3_A207AuditDescription = new string[] {""} ;
         T000T3_A208AuditShortDescription = new string[] {""} ;
         T000T3_A209AuditAction = new string[] {""} ;
         T000T3_A210SecUserId = new long[1] ;
         T000T3_A211Trn_Id = new string[] {""} ;
         T000T3_A106EmployeeId = new long[1] ;
         T000T8_A204AuditId = new long[1] ;
         T000T9_A204AuditId = new long[1] ;
         T000T2_A204AuditId = new long[1] ;
         T000T2_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         T000T2_A206AuditTableName = new string[] {""} ;
         T000T2_A207AuditDescription = new string[] {""} ;
         T000T2_A208AuditShortDescription = new string[] {""} ;
         T000T2_A209AuditAction = new string[] {""} ;
         T000T2_A210SecUserId = new long[1] ;
         T000T2_A211Trn_Id = new string[] {""} ;
         T000T2_A106EmployeeId = new long[1] ;
         T000T11_A204AuditId = new long[1] ;
         T000T14_A147EmployeeBalance = new decimal[1] ;
         T000T14_A148EmployeeName = new string[] {""} ;
         T000T15_A204AuditId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.audit__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.audit__default(),
            new Object[][] {
                new Object[] {
               T000T2_A204AuditId, T000T2_A205AuditDate, T000T2_A206AuditTableName, T000T2_A207AuditDescription, T000T2_A208AuditShortDescription, T000T2_A209AuditAction, T000T2_A210SecUserId, T000T2_A211Trn_Id, T000T2_A106EmployeeId
               }
               , new Object[] {
               T000T3_A204AuditId, T000T3_A205AuditDate, T000T3_A206AuditTableName, T000T3_A207AuditDescription, T000T3_A208AuditShortDescription, T000T3_A209AuditAction, T000T3_A210SecUserId, T000T3_A211Trn_Id, T000T3_A106EmployeeId
               }
               , new Object[] {
               T000T4_A147EmployeeBalance, T000T4_A148EmployeeName
               }
               , new Object[] {
               T000T5_A147EmployeeBalance, T000T5_A204AuditId, T000T5_A205AuditDate, T000T5_A206AuditTableName, T000T5_A207AuditDescription, T000T5_A208AuditShortDescription, T000T5_A209AuditAction, T000T5_A210SecUserId, T000T5_A148EmployeeName, T000T5_A211Trn_Id,
               T000T5_A106EmployeeId
               }
               , new Object[] {
               T000T6_A147EmployeeBalance, T000T6_A148EmployeeName
               }
               , new Object[] {
               T000T7_A204AuditId
               }
               , new Object[] {
               T000T8_A204AuditId
               }
               , new Object[] {
               T000T9_A204AuditId
               }
               , new Object[] {
               }
               , new Object[] {
               T000T11_A204AuditId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000T14_A147EmployeeBalance, T000T14_A148EmployeeName
               }
               , new Object[] {
               T000T15_A204AuditId
               }
            }
         );
         AV22Pgmname = "Audit";
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
      private int edtAuditId_Enabled ;
      private int edtAuditDate_Enabled ;
      private int edtAuditTableName_Enabled ;
      private int edtAuditDescription_Enabled ;
      private int edtAuditShortDescription_Enabled ;
      private int edtAuditAction_Enabled ;
      private int edtSecUserId_Enabled ;
      private int edtEmployeeId_Visible ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboemployeeid_Enabled ;
      private int edtavComboemployeeid_Visible ;
      private int Combo_employeeid_Datalistupdateminimumcharacters ;
      private int Combo_employeeid_Gxcontroltype ;
      private int AV23GXV1 ;
      private int idxLst ;
      private long wcpOAV7AuditId ;
      private long Z204AuditId ;
      private long Z210SecUserId ;
      private long Z106EmployeeId ;
      private long N106EmployeeId ;
      private long A106EmployeeId ;
      private long AV7AuditId ;
      private long A204AuditId ;
      private long A210SecUserId ;
      private long AV19ComboEmployeeId ;
      private long AV12Insert_EmployeeId ;
      private decimal A147EmployeeBalance ;
      private decimal Z147EmployeeBalance ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z206AuditTableName ;
      private string Combo_employeeid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAuditDate_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divLefttable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtAuditId_Internalname ;
      private string TempTags ;
      private string edtAuditId_Jsonclick ;
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
      private string divTablesplittedemployeeid_Internalname ;
      private string lblTextblockemployeeid_Internalname ;
      private string lblTextblockemployeeid_Jsonclick ;
      private string Combo_employeeid_Caption ;
      private string Combo_employeeid_Cls ;
      private string Combo_employeeid_Datalistproc ;
      private string Combo_employeeid_Datalistprocparametersprefix ;
      private string Combo_employeeid_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeName_Internalname ;
      private string A148EmployeeName ;
      private string edtEmployeeName_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_employeeid_Internalname ;
      private string edtavComboemployeeid_Internalname ;
      private string edtavComboemployeeid_Jsonclick ;
      private string AV22Pgmname ;
      private string Combo_employeeid_Objectcall ;
      private string Combo_employeeid_Class ;
      private string Combo_employeeid_Icontype ;
      private string Combo_employeeid_Icon ;
      private string Combo_employeeid_Tooltip ;
      private string Combo_employeeid_Selectedvalue_set ;
      private string Combo_employeeid_Selectedtext_set ;
      private string Combo_employeeid_Selectedtext_get ;
      private string Combo_employeeid_Gamoauthtoken ;
      private string Combo_employeeid_Ddointernalname ;
      private string Combo_employeeid_Titlecontrolalign ;
      private string Combo_employeeid_Dropdownoptionstype ;
      private string Combo_employeeid_Titlecontrolidtoreplace ;
      private string Combo_employeeid_Datalisttype ;
      private string Combo_employeeid_Datalistfixedvalues ;
      private string Combo_employeeid_Remoteservicesparameters ;
      private string Combo_employeeid_Htmltemplate ;
      private string Combo_employeeid_Multiplevaluestype ;
      private string Combo_employeeid_Loadingdata ;
      private string Combo_employeeid_Noresultsfound ;
      private string Combo_employeeid_Emptyitemtext ;
      private string Combo_employeeid_Onlyselectedvalues ;
      private string Combo_employeeid_Selectalltext ;
      private string Combo_employeeid_Multiplevaluesseparator ;
      private string Combo_employeeid_Addnewoptiontext ;
      private string hsh ;
      private string sMode32 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string Z148EmployeeName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z205AuditDate ;
      private DateTime A205AuditDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Combo_employeeid_Emptyitem ;
      private bool Combo_employeeid_Enabled ;
      private bool Combo_employeeid_Visible ;
      private bool Combo_employeeid_Allowmultipleselection ;
      private bool Combo_employeeid_Isgriditem ;
      private bool Combo_employeeid_Hasdescription ;
      private bool Combo_employeeid_Includeonlyselectedoption ;
      private bool Combo_employeeid_Includeselectalloption ;
      private bool Combo_employeeid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV18Combo_DataJson ;
      private string Z207AuditDescription ;
      private string Z208AuditShortDescription ;
      private string Z209AuditAction ;
      private string Z211Trn_Id ;
      private string A207AuditDescription ;
      private string A208AuditShortDescription ;
      private string A209AuditAction ;
      private string A211Trn_Id ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_employeeid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV14EmployeeId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV20GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV21GAMErrors ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000T4_A147EmployeeBalance ;
      private string[] T000T4_A148EmployeeName ;
      private decimal[] T000T5_A147EmployeeBalance ;
      private long[] T000T5_A204AuditId ;
      private DateTime[] T000T5_A205AuditDate ;
      private string[] T000T5_A206AuditTableName ;
      private string[] T000T5_A207AuditDescription ;
      private string[] T000T5_A208AuditShortDescription ;
      private string[] T000T5_A209AuditAction ;
      private long[] T000T5_A210SecUserId ;
      private string[] T000T5_A148EmployeeName ;
      private string[] T000T5_A211Trn_Id ;
      private long[] T000T5_A106EmployeeId ;
      private decimal[] T000T6_A147EmployeeBalance ;
      private string[] T000T6_A148EmployeeName ;
      private long[] T000T7_A204AuditId ;
      private long[] T000T3_A204AuditId ;
      private DateTime[] T000T3_A205AuditDate ;
      private string[] T000T3_A206AuditTableName ;
      private string[] T000T3_A207AuditDescription ;
      private string[] T000T3_A208AuditShortDescription ;
      private string[] T000T3_A209AuditAction ;
      private long[] T000T3_A210SecUserId ;
      private string[] T000T3_A211Trn_Id ;
      private long[] T000T3_A106EmployeeId ;
      private long[] T000T8_A204AuditId ;
      private long[] T000T9_A204AuditId ;
      private long[] T000T2_A204AuditId ;
      private DateTime[] T000T2_A205AuditDate ;
      private string[] T000T2_A206AuditTableName ;
      private string[] T000T2_A207AuditDescription ;
      private string[] T000T2_A208AuditShortDescription ;
      private string[] T000T2_A209AuditAction ;
      private long[] T000T2_A210SecUserId ;
      private string[] T000T2_A211Trn_Id ;
      private long[] T000T2_A106EmployeeId ;
      private long[] T000T11_A204AuditId ;
      private decimal[] T000T14_A147EmployeeBalance ;
      private string[] T000T14_A148EmployeeName ;
      private long[] T000T15_A204AuditId ;
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
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000T5;
        prmT000T5 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T6;
        prmT000T6 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000T7;
        prmT000T7 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T8;
        prmT000T8 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T9;
        prmT000T9 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T10;
        prmT000T10 = new Object[] {
        new ParDef("AuditDate",GXType.Date,8,0) ,
        new ParDef("AuditTableName",GXType.Char,100,0) ,
        new ParDef("AuditDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditShortDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditAction",GXType.VarChar,10,0) ,
        new ParDef("SecUserId",GXType.Int64,10,0) ,
        new ParDef("Trn_Id",GXType.VarChar,40,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000T11;
        prmT000T11 = new Object[] {
        };
        Object[] prmT000T12;
        prmT000T12 = new Object[] {
        new ParDef("AuditDate",GXType.Date,8,0) ,
        new ParDef("AuditTableName",GXType.Char,100,0) ,
        new ParDef("AuditDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditShortDescription",GXType.VarChar,200,0) ,
        new ParDef("AuditAction",GXType.VarChar,10,0) ,
        new ParDef("SecUserId",GXType.Int64,10,0) ,
        new ParDef("Trn_Id",GXType.VarChar,40,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T13;
        prmT000T13 = new Object[] {
        new ParDef("AuditId",GXType.Int64,10,0)
        };
        Object[] prmT000T14;
        prmT000T14 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000T15;
        prmT000T15 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000T2", "SELECT AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, AuditAction, SecUserId, Trn_Id, EmployeeId FROM Audit WHERE AuditId = :AuditId  FOR UPDATE OF Audit NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T3", "SELECT AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, AuditAction, SecUserId, Trn_Id, EmployeeId FROM Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T4", "SELECT EmployeeBalance, EmployeeName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T5", "SELECT T2.EmployeeBalance, TM1.AuditId, TM1.AuditDate, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.AuditAction, TM1.SecUserId, T2.EmployeeName, TM1.Trn_Id, TM1.EmployeeId FROM (Audit TM1 INNER JOIN Employee T2 ON T2.EmployeeId = TM1.EmployeeId) WHERE TM1.AuditId = :AuditId ORDER BY TM1.AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T6", "SELECT EmployeeBalance, EmployeeName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T7", "SELECT AuditId FROM Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T8", "SELECT AuditId FROM Audit WHERE ( AuditId > :AuditId) ORDER BY AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T9", "SELECT AuditId FROM Audit WHERE ( AuditId < :AuditId) ORDER BY AuditId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T10", "SAVEPOINT gxupdate;INSERT INTO Audit(AuditDate, AuditTableName, AuditDescription, AuditShortDescription, AuditAction, SecUserId, Trn_Id, EmployeeId) VALUES(:AuditDate, :AuditTableName, :AuditDescription, :AuditShortDescription, :AuditAction, :SecUserId, :Trn_Id, :EmployeeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000T10)
           ,new CursorDef("T000T11", "SELECT currval('AuditId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T12", "SAVEPOINT gxupdate;UPDATE Audit SET AuditDate=:AuditDate, AuditTableName=:AuditTableName, AuditDescription=:AuditDescription, AuditShortDescription=:AuditShortDescription, AuditAction=:AuditAction, SecUserId=:SecUserId, Trn_Id=:Trn_Id, EmployeeId=:EmployeeId  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T12)
           ,new CursorDef("T000T13", "SAVEPOINT gxupdate;DELETE FROM Audit  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T13)
           ,new CursorDef("T000T14", "SELECT EmployeeBalance, EmployeeName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T15", "SELECT AuditId FROM Audit ORDER BY AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              return;
           case 2 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 3 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 100);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
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
