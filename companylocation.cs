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
   public class companylocation : GXDataArea
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
               AV7CompanyLocationId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyLocationId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV7CompanyLocationId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCOMPANYLOCATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CompanyLocationId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Company Location", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCompanyLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public companylocation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public companylocation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_CompanyLocationId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CompanyLocationId = aP1_CompanyLocationId;
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
            return "companylocation_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCompanyLocationName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCompanyLocationName_Internalname, "Country Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCompanyLocationName_Internalname, StringUtil.RTrim( A158CompanyLocationName), StringUtil.RTrim( context.localUtil.Format( A158CompanyLocationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompanyLocationName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCompanyLocationName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_CompanyLocation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCompanyLocationCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCompanyLocationCode_Internalname, "Country Code", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCompanyLocationCode_Internalname, StringUtil.RTrim( A159CompanyLocationCode), StringUtil.RTrim( context.localUtil.Format( A159CompanyLocationCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompanyLocationCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCompanyLocationCode_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CompanyLocation.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CompanyLocation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CompanyLocation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CompanyLocation.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCompanyLocationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A157CompanyLocationId), 10, 0, ".", "")), StringUtil.LTrim( ((edtCompanyLocationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A157CompanyLocationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A157CompanyLocationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompanyLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtCompanyLocationId_Visible, edtCompanyLocationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CompanyLocation.htm");
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
         E110M2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z157CompanyLocationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z157CompanyLocationId"), ".", ","), 18, MidpointRounding.ToEven));
               Z158CompanyLocationName = cgiGet( "Z158CompanyLocationName");
               Z159CompanyLocationCode = cgiGet( "Z159CompanyLocationCode");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7CompanyLocationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCOMPANYLOCATIONID"), ".", ","), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A158CompanyLocationName = cgiGet( edtCompanyLocationName_Internalname);
               AssignAttri("", false, "A158CompanyLocationName", A158CompanyLocationName);
               A159CompanyLocationCode = cgiGet( edtCompanyLocationCode_Internalname);
               AssignAttri("", false, "A159CompanyLocationCode", A159CompanyLocationCode);
               A157CompanyLocationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCompanyLocationId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CompanyLocation");
               A157CompanyLocationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCompanyLocationId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
               forbiddenHiddens.Add("CompanyLocationId", context.localUtil.Format( (decimal)(A157CompanyLocationId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A157CompanyLocationId != Z157CompanyLocationId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("companylocation:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A157CompanyLocationId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyLocationId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
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
                     sMode24 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode24;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound24 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0M0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "COMPANYLOCATIONID");
                        AnyError = 1;
                        GX_FocusControl = edtCompanyLocationId_Internalname;
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
                           E110M2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120M2 ();
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
            E120M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0M24( ) ;
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
            DisableAttributes0M24( ) ;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M24( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M24( ) ;
            }
            else
            {
               CheckExtendedTable0M24( ) ;
               CloseExtendedTableCursors0M24( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0M0( )
      {
      }

      protected void E110M2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtCompanyLocationId_Visible = 0;
         AssignProp("", false, edtCompanyLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCompanyLocationId_Visible), 5, 0), true);
      }

      protected void E120M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("companylocationww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0M24( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z158CompanyLocationName = T000M3_A158CompanyLocationName[0];
               Z159CompanyLocationCode = T000M3_A159CompanyLocationCode[0];
            }
            else
            {
               Z158CompanyLocationName = A158CompanyLocationName;
               Z159CompanyLocationCode = A159CompanyLocationCode;
            }
         }
         if ( GX_JID == -7 )
         {
            Z157CompanyLocationId = A157CompanyLocationId;
            Z158CompanyLocationName = A158CompanyLocationName;
            Z159CompanyLocationCode = A159CompanyLocationCode;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCompanyLocationId_Enabled = 0;
         AssignProp("", false, edtCompanyLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyLocationId_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtCompanyLocationCode_Enabled = 0;
            AssignProp("", false, edtCompanyLocationCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyLocationCode_Enabled), 5, 0), true);
         }
         else
         {
            edtCompanyLocationCode_Enabled = 1;
            AssignProp("", false, edtCompanyLocationCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyLocationCode_Enabled), 5, 0), true);
         }
         edtCompanyLocationId_Enabled = 0;
         AssignProp("", false, edtCompanyLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyLocationId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CompanyLocationId) )
         {
            A157CompanyLocationId = AV7CompanyLocationId;
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtCompanyLocationCode_Enabled = 0;
            AssignProp("", false, edtCompanyLocationCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyLocationCode_Enabled), 5, 0), true);
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
      }

      protected void Load0M24( )
      {
         /* Using cursor T000M4 */
         pr_default.execute(2, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound24 = 1;
            A158CompanyLocationName = T000M4_A158CompanyLocationName[0];
            AssignAttri("", false, "A158CompanyLocationName", A158CompanyLocationName);
            A159CompanyLocationCode = T000M4_A159CompanyLocationCode[0];
            AssignAttri("", false, "A159CompanyLocationCode", A159CompanyLocationCode);
            ZM0M24( -7) ;
         }
         pr_default.close(2);
         OnLoadActions0M24( ) ;
      }

      protected void OnLoadActions0M24( )
      {
      }

      protected void CheckExtendedTable0M24( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000M5 */
         pr_default.execute(3, new Object[] {A158CompanyLocationName, A157CompanyLocationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Company Location Name"}), 1, "COMPANYLOCATIONNAME");
            AnyError = 1;
            GX_FocusControl = edtCompanyLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A158CompanyLocationName)) )
         {
            GX_msglist.addItem("Country Name cannot be empty", 1, "COMPANYLOCATIONNAME");
            AnyError = 1;
            GX_FocusControl = edtCompanyLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A159CompanyLocationCode)) )
         {
            GX_msglist.addItem("Country Code cannot be empty", 1, "COMPANYLOCATIONCODE");
            AnyError = 1;
            GX_FocusControl = edtCompanyLocationCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0M24( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M24( )
      {
         /* Using cursor T000M6 */
         pr_default.execute(4, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000M3 */
         pr_default.execute(1, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M24( 7) ;
            RcdFound24 = 1;
            A157CompanyLocationId = T000M3_A157CompanyLocationId[0];
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
            A158CompanyLocationName = T000M3_A158CompanyLocationName[0];
            AssignAttri("", false, "A158CompanyLocationName", A158CompanyLocationName);
            A159CompanyLocationCode = T000M3_A159CompanyLocationCode[0];
            AssignAttri("", false, "A159CompanyLocationCode", A159CompanyLocationCode);
            Z157CompanyLocationId = A157CompanyLocationId;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0M24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0M24( ) ;
            }
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0M24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M24( ) ;
         if ( RcdFound24 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound24 = 0;
         /* Using cursor T000M7 */
         pr_default.execute(5, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000M7_A157CompanyLocationId[0] < A157CompanyLocationId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000M7_A157CompanyLocationId[0] > A157CompanyLocationId ) ) )
            {
               A157CompanyLocationId = T000M7_A157CompanyLocationId[0];
               AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
               RcdFound24 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound24 = 0;
         /* Using cursor T000M8 */
         pr_default.execute(6, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000M8_A157CompanyLocationId[0] > A157CompanyLocationId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000M8_A157CompanyLocationId[0] < A157CompanyLocationId ) ) )
            {
               A157CompanyLocationId = T000M8_A157CompanyLocationId[0];
               AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
               RcdFound24 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0M24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCompanyLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0M24( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( A157CompanyLocationId != Z157CompanyLocationId )
               {
                  A157CompanyLocationId = Z157CompanyLocationId;
                  AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COMPANYLOCATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtCompanyLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCompanyLocationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0M24( ) ;
                  GX_FocusControl = edtCompanyLocationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A157CompanyLocationId != Z157CompanyLocationId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCompanyLocationName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0M24( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COMPANYLOCATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtCompanyLocationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCompanyLocationName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0M24( ) ;
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
         if ( A157CompanyLocationId != Z157CompanyLocationId )
         {
            A157CompanyLocationId = Z157CompanyLocationId;
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COMPANYLOCATIONID");
            AnyError = 1;
            GX_FocusControl = edtCompanyLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCompanyLocationName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0M24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000M2 */
            pr_default.execute(0, new Object[] {A157CompanyLocationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CompanyLocation"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z158CompanyLocationName, T000M2_A158CompanyLocationName[0]) != 0 ) || ( StringUtil.StrCmp(Z159CompanyLocationCode, T000M2_A159CompanyLocationCode[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z158CompanyLocationName, T000M2_A158CompanyLocationName[0]) != 0 )
               {
                  GXUtil.WriteLog("companylocation:[seudo value changed for attri]"+"CompanyLocationName");
                  GXUtil.WriteLogRaw("Old: ",Z158CompanyLocationName);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A158CompanyLocationName[0]);
               }
               if ( StringUtil.StrCmp(Z159CompanyLocationCode, T000M2_A159CompanyLocationCode[0]) != 0 )
               {
                  GXUtil.WriteLog("companylocation:[seudo value changed for attri]"+"CompanyLocationCode");
                  GXUtil.WriteLogRaw("Old: ",Z159CompanyLocationCode);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A159CompanyLocationCode[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CompanyLocation"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M24( )
      {
         if ( ! IsAuthorized("companylocation_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M24( 0) ;
            CheckOptimisticConcurrency0M24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M9 */
                     pr_default.execute(7, new Object[] {A158CompanyLocationName, A159CompanyLocationCode});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000M10 */
                     pr_default.execute(8);
                     A157CompanyLocationId = T000M10_A157CompanyLocationId[0];
                     AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("CompanyLocation");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0M0( ) ;
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
               Load0M24( ) ;
            }
            EndLevel0M24( ) ;
         }
         CloseExtendedTableCursors0M24( ) ;
      }

      protected void Update0M24( )
      {
         if ( ! IsAuthorized("companylocation_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M11 */
                     pr_default.execute(9, new Object[] {A158CompanyLocationName, A159CompanyLocationCode, A157CompanyLocationId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("CompanyLocation");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CompanyLocation"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M24( ) ;
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
            EndLevel0M24( ) ;
         }
         CloseExtendedTableCursors0M24( ) ;
      }

      protected void DeferredUpdate0M24( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("companylocation_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M24( ) ;
            AfterConfirm0M24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M24( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000M12 */
                  pr_default.execute(10, new Object[] {A157CompanyLocationId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("CompanyLocation");
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0M24( ) ;
         Gx_mode = sMode24;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0M24( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000M13 */
            pr_default.execute(11, new Object[] {A157CompanyLocationId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0M24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M24( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("companylocation",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("companylocation",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0M24( )
      {
         /* Scan By routine */
         /* Using cursor T000M14 */
         pr_default.execute(12);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound24 = 1;
            A157CompanyLocationId = T000M14_A157CompanyLocationId[0];
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0M24( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound24 = 1;
            A157CompanyLocationId = T000M14_A157CompanyLocationId[0];
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
         }
      }

      protected void ScanEnd0M24( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0M24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M24( )
      {
         edtCompanyLocationName_Enabled = 0;
         AssignProp("", false, edtCompanyLocationName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyLocationName_Enabled), 5, 0), true);
         edtCompanyLocationCode_Enabled = 0;
         AssignProp("", false, edtCompanyLocationCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyLocationCode_Enabled), 5, 0), true);
         edtCompanyLocationId_Enabled = 0;
         AssignProp("", false, edtCompanyLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyLocationId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0M24( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0M0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("companylocation.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CompanyLocationId,10,0))}, new string[] {"Gx_mode","CompanyLocationId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CompanyLocation");
         forbiddenHiddens.Add("CompanyLocationId", context.localUtil.Format( (decimal)(A157CompanyLocationId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("companylocation:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z157CompanyLocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z157CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z158CompanyLocationName", StringUtil.RTrim( Z158CompanyLocationName));
         GxWebStd.gx_hidden_field( context, "Z159CompanyLocationCode", StringUtil.RTrim( Z159CompanyLocationCode));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vCOMPANYLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMPANYLOCATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CompanyLocationId), "ZZZZZZZZZ9"), context));
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
         return formatLink("companylocation.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CompanyLocationId,10,0))}, new string[] {"Gx_mode","CompanyLocationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "CompanyLocation" ;
      }

      public override string GetPgmdesc( )
      {
         return "Company Location" ;
      }

      protected void InitializeNonKey0M24( )
      {
         A158CompanyLocationName = "";
         AssignAttri("", false, "A158CompanyLocationName", A158CompanyLocationName);
         A159CompanyLocationCode = "";
         AssignAttri("", false, "A159CompanyLocationCode", A159CompanyLocationCode);
         Z158CompanyLocationName = "";
         Z159CompanyLocationCode = "";
      }

      protected void InitAll0M24( )
      {
         A157CompanyLocationId = 0;
         AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
         InitializeNonKey0M24( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257120595439", true, true);
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
         context.AddJavascriptSource("companylocation.js", "?20257120595440", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtCompanyLocationName_Internalname = "COMPANYLOCATIONNAME";
         edtCompanyLocationCode_Internalname = "COMPANYLOCATIONCODE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         edtCompanyLocationId_Internalname = "COMPANYLOCATIONID";
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
         Form.Caption = "Company Location";
         edtCompanyLocationId_Jsonclick = "";
         edtCompanyLocationId_Enabled = 0;
         edtCompanyLocationId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCompanyLocationCode_Jsonclick = "";
         edtCompanyLocationCode_Enabled = 1;
         edtCompanyLocationName_Jsonclick = "";
         edtCompanyLocationName_Enabled = 1;
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

      public void Valid_Companylocationname( )
      {
         /* Using cursor T000M15 */
         pr_default.execute(13, new Object[] {A158CompanyLocationName, A157CompanyLocationId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Company Location Name"}), 1, "COMPANYLOCATIONNAME");
            AnyError = 1;
            GX_FocusControl = edtCompanyLocationName_Internalname;
         }
         pr_default.close(13);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A158CompanyLocationName)) )
         {
            GX_msglist.addItem("Country Name cannot be empty", 1, "COMPANYLOCATIONNAME");
            AnyError = 1;
            GX_FocusControl = edtCompanyLocationName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7CompanyLocationId","fld":"vCOMPANYLOCATIONID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120M2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_COMPANYLOCATIONNAME","""{"handler":"Valid_Companylocationname","iparms":[{"av":"A158CompanyLocationName","fld":"COMPANYLOCATIONNAME"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_COMPANYLOCATIONCODE","""{"handler":"Valid_Companylocationcode","iparms":[]}""");
         setEventMetadata("VALID_COMPANYLOCATIONID","""{"handler":"Valid_Companylocationid","iparms":[]}""");
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
         wcpOGx_mode = "";
         Z158CompanyLocationName = "";
         Z159CompanyLocationCode = "";
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
         A158CompanyLocationName = "";
         A159CompanyLocationCode = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode24 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000M4_A157CompanyLocationId = new long[1] ;
         T000M4_A158CompanyLocationName = new string[] {""} ;
         T000M4_A159CompanyLocationCode = new string[] {""} ;
         T000M5_A158CompanyLocationName = new string[] {""} ;
         T000M6_A157CompanyLocationId = new long[1] ;
         T000M3_A157CompanyLocationId = new long[1] ;
         T000M3_A158CompanyLocationName = new string[] {""} ;
         T000M3_A159CompanyLocationCode = new string[] {""} ;
         T000M7_A157CompanyLocationId = new long[1] ;
         T000M8_A157CompanyLocationId = new long[1] ;
         T000M2_A157CompanyLocationId = new long[1] ;
         T000M2_A158CompanyLocationName = new string[] {""} ;
         T000M2_A159CompanyLocationCode = new string[] {""} ;
         T000M10_A157CompanyLocationId = new long[1] ;
         T000M13_A100CompanyId = new long[1] ;
         T000M14_A157CompanyLocationId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000M15_A158CompanyLocationName = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.companylocation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.companylocation__default(),
            new Object[][] {
                new Object[] {
               T000M2_A157CompanyLocationId, T000M2_A158CompanyLocationName, T000M2_A159CompanyLocationCode
               }
               , new Object[] {
               T000M3_A157CompanyLocationId, T000M3_A158CompanyLocationName, T000M3_A159CompanyLocationCode
               }
               , new Object[] {
               T000M4_A157CompanyLocationId, T000M4_A158CompanyLocationName, T000M4_A159CompanyLocationCode
               }
               , new Object[] {
               T000M5_A158CompanyLocationName
               }
               , new Object[] {
               T000M6_A157CompanyLocationId
               }
               , new Object[] {
               T000M7_A157CompanyLocationId
               }
               , new Object[] {
               T000M8_A157CompanyLocationId
               }
               , new Object[] {
               }
               , new Object[] {
               T000M10_A157CompanyLocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000M13_A100CompanyId
               }
               , new Object[] {
               T000M14_A157CompanyLocationId
               }
               , new Object[] {
               T000M15_A158CompanyLocationName
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
      private short RcdFound24 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtCompanyLocationName_Enabled ;
      private int edtCompanyLocationCode_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCompanyLocationId_Enabled ;
      private int edtCompanyLocationId_Visible ;
      private int idxLst ;
      private long wcpOAV7CompanyLocationId ;
      private long Z157CompanyLocationId ;
      private long AV7CompanyLocationId ;
      private long A157CompanyLocationId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z158CompanyLocationName ;
      private string Z159CompanyLocationCode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCompanyLocationName_Internalname ;
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
      private string A158CompanyLocationName ;
      private string edtCompanyLocationName_Jsonclick ;
      private string edtCompanyLocationCode_Internalname ;
      private string A159CompanyLocationCode ;
      private string edtCompanyLocationCode_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCompanyLocationId_Internalname ;
      private string edtCompanyLocationId_Jsonclick ;
      private string hsh ;
      private string sMode24 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T000M4_A157CompanyLocationId ;
      private string[] T000M4_A158CompanyLocationName ;
      private string[] T000M4_A159CompanyLocationCode ;
      private string[] T000M5_A158CompanyLocationName ;
      private long[] T000M6_A157CompanyLocationId ;
      private long[] T000M3_A157CompanyLocationId ;
      private string[] T000M3_A158CompanyLocationName ;
      private string[] T000M3_A159CompanyLocationCode ;
      private long[] T000M7_A157CompanyLocationId ;
      private long[] T000M8_A157CompanyLocationId ;
      private long[] T000M2_A157CompanyLocationId ;
      private string[] T000M2_A158CompanyLocationName ;
      private string[] T000M2_A159CompanyLocationCode ;
      private long[] T000M10_A157CompanyLocationId ;
      private long[] T000M13_A100CompanyId ;
      private long[] T000M14_A157CompanyLocationId ;
      private string[] T000M15_A158CompanyLocationName ;
      private IDataStoreProvider pr_gam ;
   }

   public class companylocation__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class companylocation__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
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
        Object[] prmT000M2;
        prmT000M2 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000M3;
        prmT000M3 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000M4;
        prmT000M4 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000M5;
        prmT000M5 = new Object[] {
        new ParDef("CompanyLocationName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000M6;
        prmT000M6 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000M7;
        prmT000M7 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000M8;
        prmT000M8 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000M9;
        prmT000M9 = new Object[] {
        new ParDef("CompanyLocationName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationCode",GXType.Char,20,0)
        };
        Object[] prmT000M10;
        prmT000M10 = new Object[] {
        };
        Object[] prmT000M11;
        prmT000M11 = new Object[] {
        new ParDef("CompanyLocationName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationCode",GXType.Char,20,0) ,
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000M12;
        prmT000M12 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000M13;
        prmT000M13 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000M14;
        prmT000M14 = new Object[] {
        };
        Object[] prmT000M15;
        prmT000M15 = new Object[] {
        new ParDef("CompanyLocationName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000M2", "SELECT CompanyLocationId, CompanyLocationName, CompanyLocationCode FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId  FOR UPDATE OF CompanyLocation NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M3", "SELECT CompanyLocationId, CompanyLocationName, CompanyLocationCode FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M4", "SELECT TM1.CompanyLocationId, TM1.CompanyLocationName, TM1.CompanyLocationCode FROM CompanyLocation TM1 WHERE TM1.CompanyLocationId = :CompanyLocationId ORDER BY TM1.CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M5", "SELECT CompanyLocationName FROM CompanyLocation WHERE (CompanyLocationName = :CompanyLocationName) AND (Not ( CompanyLocationId = :CompanyLocationId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M6", "SELECT CompanyLocationId FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M7", "SELECT CompanyLocationId FROM CompanyLocation WHERE ( CompanyLocationId > :CompanyLocationId) ORDER BY CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M8", "SELECT CompanyLocationId FROM CompanyLocation WHERE ( CompanyLocationId < :CompanyLocationId) ORDER BY CompanyLocationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M9", "SAVEPOINT gxupdate;INSERT INTO CompanyLocation(CompanyLocationName, CompanyLocationCode) VALUES(:CompanyLocationName, :CompanyLocationCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000M9)
           ,new CursorDef("T000M10", "SELECT currval('CompanyLocationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M11", "SAVEPOINT gxupdate;UPDATE CompanyLocation SET CompanyLocationName=:CompanyLocationName, CompanyLocationCode=:CompanyLocationCode  WHERE CompanyLocationId = :CompanyLocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000M11)
           ,new CursorDef("T000M12", "SAVEPOINT gxupdate;DELETE FROM CompanyLocation  WHERE CompanyLocationId = :CompanyLocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000M12)
           ,new CursorDef("T000M13", "SELECT CompanyId FROM Company WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M14", "SELECT CompanyLocationId FROM CompanyLocation ORDER BY CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M15", "SELECT CompanyLocationName FROM CompanyLocation WHERE (CompanyLocationName = :CompanyLocationName) AND (Not ( CompanyLocationId = :CompanyLocationId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M15,1, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
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
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
     }
  }

}

}
