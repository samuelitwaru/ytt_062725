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
   public class company : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A157CompanyLocationId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyLocationId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A157CompanyLocationId) ;
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
               AV7CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7CompanyId", StringUtil.LTrimStr( (decimal)(AV7CompanyId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCOMPANYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CompanyId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Location", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCompanyName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public company( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public company( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_CompanyId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CompanyId = aP1_CompanyId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynCompanyLocationId = new GXCombobox();
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
            return "company_Execute" ;
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
         if ( dynCompanyLocationId.ItemCount > 0 )
         {
            A157CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynCompanyLocationId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynCompanyLocationId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0));
            AssignProp("", false, dynCompanyLocationId_Internalname, "Values", dynCompanyLocationId.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 100, "%", 0, "px", "TableMainTransaction", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:25fr 50fr 25fr;grid-template-rows:auto;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLefttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCompanyName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCompanyName_Internalname, "Location Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCompanyName_Internalname, StringUtil.RTrim( A101CompanyName), StringUtil.RTrim( context.localUtil.Format( A101CompanyName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompanyName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCompanyName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Company.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynCompanyLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynCompanyLocationId_Internalname, "Location Country", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynCompanyLocationId, dynCompanyLocationId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0)), 1, dynCompanyLocationId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynCompanyLocationId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 0, "HLP_Company.htm");
         dynCompanyLocationId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0));
         AssignProp("", false, dynCompanyLocationId_Internalname, "Values", (string)(dynCompanyLocationId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Company.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Company.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Company.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divRighttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCompanyId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")), StringUtil.LTrim( ((edtCompanyId_Enabled!=0) ? context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCompanyId_Jsonclick, 0, "Attribute", "", "", "", "", edtCompanyId_Visible, edtCompanyId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Company.htm");
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
         E110D2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               Z101CompanyName = cgiGet( "Z101CompanyName");
               Z157CompanyLocationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z157CompanyLocationId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N157CompanyLocationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N157CompanyLocationId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCOMPANYID"), ".", ","), 18, MidpointRounding.ToEven));
               AV23Insert_CompanyLocationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_COMPANYLOCATIONID"), ".", ","), 18, MidpointRounding.ToEven));
               A158CompanyLocationName = cgiGet( "COMPANYLOCATIONNAME");
               AV24Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A101CompanyName = cgiGet( edtCompanyName_Internalname);
               AssignAttri("", false, "A101CompanyName", A101CompanyName);
               dynCompanyLocationId.CurrentValue = cgiGet( dynCompanyLocationId_Internalname);
               A157CompanyLocationId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynCompanyLocationId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
               A100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCompanyId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Company");
               A100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCompanyId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
               forbiddenHiddens.Add("CompanyId", context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A100CompanyId != Z100CompanyId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("company:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A100CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
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
                     sMode14 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode14;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound14 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0D0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "COMPANYID");
                        AnyError = 1;
                        GX_FocusControl = edtCompanyId_Internalname;
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
                           E110D2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120D2 ();
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
            E120D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0D14( ) ;
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
            DisableAttributes0D14( ) ;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D14( ) ;
            }
            else
            {
               CheckExtendedTable0D14( ) ;
               CloseExtendedTableCursors0D14( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0D0( )
      {
      }

      protected void E110D2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            while ( AV25GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CompanyLocationId") == 0 )
               {
                  AV23Insert_CompanyLocationId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV23Insert_CompanyLocationId", StringUtil.LTrimStr( (decimal)(AV23Insert_CompanyLocationId), 10, 0));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
               AssignAttri("", false, "AV25GXV1", StringUtil.LTrimStr( (decimal)(AV25GXV1), 8, 0));
            }
         }
         edtCompanyId_Visible = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCompanyId_Visible), 5, 0), true);
      }

      protected void E120D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("companyww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0D14( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z101CompanyName = T000D3_A101CompanyName[0];
               Z157CompanyLocationId = T000D3_A157CompanyLocationId[0];
            }
            else
            {
               Z101CompanyName = A101CompanyName;
               Z157CompanyLocationId = A157CompanyLocationId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z100CompanyId = A100CompanyId;
            Z101CompanyName = A101CompanyName;
            Z157CompanyLocationId = A157CompanyLocationId;
            Z158CompanyLocationName = A158CompanyLocationName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCompanyId_Enabled = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyId_Enabled), 5, 0), true);
         AV24Pgmname = "Company";
         AssignAttri("", false, "AV24Pgmname", AV24Pgmname);
         edtCompanyId_Enabled = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CompanyId) )
         {
            A100CompanyId = AV7CompanyId;
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_CompanyLocationId) )
         {
            dynCompanyLocationId.Enabled = 0;
            AssignProp("", false, dynCompanyLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyLocationId.Enabled), 5, 0), true);
         }
         else
         {
            dynCompanyLocationId.Enabled = 1;
            AssignProp("", false, dynCompanyLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyLocationId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_CompanyLocationId) )
         {
            A157CompanyLocationId = AV23Insert_CompanyLocationId;
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
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
            /* Using cursor T000D4 */
            pr_default.execute(2, new Object[] {A157CompanyLocationId});
            A158CompanyLocationName = T000D4_A158CompanyLocationName[0];
            pr_default.close(2);
         }
      }

      protected void Load0D14( )
      {
         /* Using cursor T000D5 */
         pr_default.execute(3, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound14 = 1;
            A101CompanyName = T000D5_A101CompanyName[0];
            AssignAttri("", false, "A101CompanyName", A101CompanyName);
            A158CompanyLocationName = T000D5_A158CompanyLocationName[0];
            A157CompanyLocationId = T000D5_A157CompanyLocationId[0];
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
            ZM0D14( -9) ;
         }
         pr_default.close(3);
         OnLoadActions0D14( ) ;
      }

      protected void OnLoadActions0D14( )
      {
      }

      protected void CheckExtendedTable0D14( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000D6 */
         pr_default.execute(4, new Object[] {A101CompanyName, A100CompanyId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Company Name"}), 1, "COMPANYNAME");
            AnyError = 1;
            GX_FocusControl = edtCompanyName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A101CompanyName)) )
         {
            GX_msglist.addItem("Company Name cannot be empty", 1, "COMPANYNAME");
            AnyError = 1;
            GX_FocusControl = edtCompanyName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000D4 */
         pr_default.execute(2, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'CompanyLocation'.", "ForeignKeyNotFound", 1, "COMPANYLOCATIONID");
            AnyError = 1;
            GX_FocusControl = dynCompanyLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A158CompanyLocationName = T000D4_A158CompanyLocationName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0D14( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_11( long A157CompanyLocationId )
      {
         /* Using cursor T000D7 */
         pr_default.execute(5, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'CompanyLocation'.", "ForeignKeyNotFound", 1, "COMPANYLOCATIONID");
            AnyError = 1;
            GX_FocusControl = dynCompanyLocationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A158CompanyLocationName = T000D7_A158CompanyLocationName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A158CompanyLocationName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey0D14( )
      {
         /* Using cursor T000D8 */
         pr_default.execute(6, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000D3 */
         pr_default.execute(1, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D14( 9) ;
            RcdFound14 = 1;
            A100CompanyId = T000D3_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            A101CompanyName = T000D3_A101CompanyName[0];
            AssignAttri("", false, "A101CompanyName", A101CompanyName);
            A157CompanyLocationId = T000D3_A157CompanyLocationId[0];
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
            Z100CompanyId = A100CompanyId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0D14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0D14( ) ;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0D14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D14( ) ;
         if ( RcdFound14 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound14 = 0;
         /* Using cursor T000D9 */
         pr_default.execute(7, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000D9_A100CompanyId[0] < A100CompanyId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000D9_A100CompanyId[0] > A100CompanyId ) ) )
            {
               A100CompanyId = T000D9_A100CompanyId[0];
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
               RcdFound14 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound14 = 0;
         /* Using cursor T000D10 */
         pr_default.execute(8, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000D10_A100CompanyId[0] > A100CompanyId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000D10_A100CompanyId[0] < A100CompanyId ) ) )
            {
               A100CompanyId = T000D10_A100CompanyId[0];
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
               RcdFound14 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0D14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCompanyName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0D14( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( A100CompanyId != Z100CompanyId )
               {
                  A100CompanyId = Z100CompanyId;
                  AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COMPANYID");
                  AnyError = 1;
                  GX_FocusControl = edtCompanyId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCompanyName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0D14( ) ;
                  GX_FocusControl = edtCompanyName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A100CompanyId != Z100CompanyId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCompanyName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0D14( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COMPANYID");
                     AnyError = 1;
                     GX_FocusControl = edtCompanyId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCompanyName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0D14( ) ;
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
         if ( A100CompanyId != Z100CompanyId )
         {
            A100CompanyId = Z100CompanyId;
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = edtCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCompanyName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0D14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D2 */
            pr_default.execute(0, new Object[] {A100CompanyId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Company"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z101CompanyName, T000D2_A101CompanyName[0]) != 0 ) || ( Z157CompanyLocationId != T000D2_A157CompanyLocationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z101CompanyName, T000D2_A101CompanyName[0]) != 0 )
               {
                  GXUtil.WriteLog("company:[seudo value changed for attri]"+"CompanyName");
                  GXUtil.WriteLogRaw("Old: ",Z101CompanyName);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A101CompanyName[0]);
               }
               if ( Z157CompanyLocationId != T000D2_A157CompanyLocationId[0] )
               {
                  GXUtil.WriteLog("company:[seudo value changed for attri]"+"CompanyLocationId");
                  GXUtil.WriteLogRaw("Old: ",Z157CompanyLocationId);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A157CompanyLocationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Company"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D14( )
      {
         if ( ! IsAuthorized("company_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D14( 0) ;
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D11 */
                     pr_default.execute(9, new Object[] {A101CompanyName, A157CompanyLocationId});
                     pr_default.close(9);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000D12 */
                     pr_default.execute(10);
                     A100CompanyId = T000D12_A100CompanyId[0];
                     AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Company");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0D0( ) ;
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
               Load0D14( ) ;
            }
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void Update0D14( )
      {
         if ( ! IsAuthorized("company_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D13 */
                     pr_default.execute(11, new Object[] {A101CompanyName, A157CompanyLocationId, A100CompanyId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Company");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Company"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D14( ) ;
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
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void DeferredUpdate0D14( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("company_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D14( ) ;
            AfterConfirm0D14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000D14 */
                  pr_default.execute(12, new Object[] {A100CompanyId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Company");
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0D14( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D14( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000D15 */
            pr_default.execute(13, new Object[] {A157CompanyLocationId});
            A158CompanyLocationName = T000D15_A158CompanyLocationName[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000D16 */
            pr_default.execute(14, new Object[] {A100CompanyId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SiteSetting"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000D17 */
            pr_default.execute(15, new Object[] {A100CompanyId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"LeaveType"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000D18 */
            pr_default.execute(16, new Object[] {A100CompanyId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000D19 */
            pr_default.execute(17, new Object[] {A100CompanyId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel0D14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("company",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("company",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0D14( )
      {
         /* Scan By routine */
         /* Using cursor T000D20 */
         pr_default.execute(18);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound14 = 1;
            A100CompanyId = T000D20_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D14( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound14 = 1;
            A100CompanyId = T000D20_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
      }

      protected void ScanEnd0D14( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0D14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D14( )
      {
         edtCompanyName_Enabled = 0;
         AssignProp("", false, edtCompanyName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyName_Enabled), 5, 0), true);
         dynCompanyLocationId.Enabled = 0;
         AssignProp("", false, dynCompanyLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyLocationId.Enabled), 5, 0), true);
         edtCompanyId_Enabled = 0;
         AssignProp("", false, edtCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCompanyId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0D14( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0D0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("company.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CompanyId,10,0))}, new string[] {"Gx_mode","CompanyId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Company");
         forbiddenHiddens.Add("CompanyId", context.localUtil.Format( (decimal)(A100CompanyId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("company:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z101CompanyName", StringUtil.RTrim( Z101CompanyName));
         GxWebStd.gx_hidden_field( context, "Z157CompanyLocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z157CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N157CompanyLocationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A157CompanyLocationId), 10, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vCOMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMPANYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CompanyId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_COMPANYLOCATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23Insert_CompanyLocationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMPANYLOCATIONNAME", StringUtil.RTrim( A158CompanyLocationName));
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
         return formatLink("company.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CompanyId,10,0))}, new string[] {"Gx_mode","CompanyId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Company" ;
      }

      public override string GetPgmdesc( )
      {
         return "Location" ;
      }

      protected void InitializeNonKey0D14( )
      {
         A157CompanyLocationId = 0;
         AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
         A101CompanyName = "";
         AssignAttri("", false, "A101CompanyName", A101CompanyName);
         A158CompanyLocationName = "";
         AssignAttri("", false, "A158CompanyLocationName", A158CompanyLocationName);
         Z101CompanyName = "";
         Z157CompanyLocationId = 0;
      }

      protected void InitAll0D14( )
      {
         A100CompanyId = 0;
         AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         InitializeNonKey0D14( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562773718", true, true);
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
         context.AddJavascriptSource("company.js", "?2025627737111", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtCompanyName_Internalname = "COMPANYNAME";
         dynCompanyLocationId_Internalname = "COMPANYLOCATIONID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = "Location";
         edtCompanyId_Jsonclick = "";
         edtCompanyId_Enabled = 0;
         edtCompanyId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         dynCompanyLocationId_Jsonclick = "";
         dynCompanyLocationId.Enabled = 1;
         edtCompanyName_Jsonclick = "";
         edtCompanyName_Enabled = 1;
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

      protected void GXDLACOMPANYLOCATIONID0D1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLACOMPANYLOCATIONID_data0D1( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXACOMPANYLOCATIONID_html0D1( )
      {
         long gxdynajaxvalue;
         GXDLACOMPANYLOCATIONID_data0D1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynCompanyLocationId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynCompanyLocationId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLACOMPANYLOCATIONID_data0D1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000D21 */
         pr_default.execute(19);
         while ( (pr_default.getStatus(19) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000D21_A157CompanyLocationId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000D21_A158CompanyLocationName[0]));
            pr_default.readNext(19);
         }
         pr_default.close(19);
      }

      protected void init_web_controls( )
      {
         dynCompanyLocationId.Name = "COMPANYLOCATIONID";
         dynCompanyLocationId.WebTags = "";
         dynCompanyLocationId.removeAllItems();
         /* Using cursor T000D22 */
         pr_default.execute(20);
         while ( (pr_default.getStatus(20) != 101) )
         {
            dynCompanyLocationId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000D22_A157CompanyLocationId[0]), 10, 0)), T000D22_A158CompanyLocationName[0], 0);
            pr_default.readNext(20);
         }
         pr_default.close(20);
         if ( dynCompanyLocationId.ItemCount > 0 )
         {
            A157CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynCompanyLocationId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A157CompanyLocationId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A157CompanyLocationId", StringUtil.LTrimStr( (decimal)(A157CompanyLocationId), 10, 0));
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

      public void Valid_Companyname( )
      {
         A157CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynCompanyLocationId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000D23 */
         pr_default.execute(21, new Object[] {A101CompanyName, A100CompanyId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Company Name"}), 1, "COMPANYNAME");
            AnyError = 1;
            GX_FocusControl = edtCompanyName_Internalname;
         }
         pr_default.close(21);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A101CompanyName)) )
         {
            GX_msglist.addItem("Company Name cannot be empty", 1, "COMPANYNAME");
            AnyError = 1;
            GX_FocusControl = edtCompanyName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Companylocationid( )
      {
         A157CompanyLocationId = (long)(Math.Round(NumberUtil.Val( dynCompanyLocationId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000D15 */
         pr_default.execute(13, new Object[] {A157CompanyLocationId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No matching 'CompanyLocation'.", "ForeignKeyNotFound", 1, "COMPANYLOCATIONID");
            AnyError = 1;
            GX_FocusControl = dynCompanyLocationId_Internalname;
         }
         A158CompanyLocationName = T000D15_A158CompanyLocationName[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A158CompanyLocationName", StringUtil.RTrim( A158CompanyLocationName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7CompanyId","fld":"vCOMPANYID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7CompanyId","fld":"vCOMPANYID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120D2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_COMPANYNAME","""{"handler":"Valid_Companyname","iparms":[{"av":"A101CompanyName","fld":"COMPANYNAME"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_COMPANYNAME",""","oparms":[{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_COMPANYLOCATIONID","""{"handler":"Valid_Companylocationid","iparms":[{"av":"A158CompanyLocationName","fld":"COMPANYLOCATIONNAME"},{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_COMPANYLOCATIONID",""","oparms":[{"av":"A158CompanyLocationName","fld":"COMPANYLOCATIONNAME"},{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_COMPANYID","""{"handler":"Valid_Companyid","iparms":[{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_COMPANYID",""","oparms":[{"av":"dynCompanyLocationId"},{"av":"A157CompanyLocationId","fld":"COMPANYLOCATIONID","pic":"ZZZZZZZZZ9"}]}""");
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
         Z101CompanyName = "";
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
         A101CompanyName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A158CompanyLocationName = "";
         AV24Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode14 = "";
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
         Z158CompanyLocationName = "";
         T000D4_A158CompanyLocationName = new string[] {""} ;
         T000D5_A100CompanyId = new long[1] ;
         T000D5_A101CompanyName = new string[] {""} ;
         T000D5_A158CompanyLocationName = new string[] {""} ;
         T000D5_A157CompanyLocationId = new long[1] ;
         T000D6_A101CompanyName = new string[] {""} ;
         T000D7_A158CompanyLocationName = new string[] {""} ;
         T000D8_A100CompanyId = new long[1] ;
         T000D3_A100CompanyId = new long[1] ;
         T000D3_A101CompanyName = new string[] {""} ;
         T000D3_A157CompanyLocationId = new long[1] ;
         T000D9_A100CompanyId = new long[1] ;
         T000D10_A100CompanyId = new long[1] ;
         T000D2_A100CompanyId = new long[1] ;
         T000D2_A101CompanyName = new string[] {""} ;
         T000D2_A157CompanyLocationId = new long[1] ;
         T000D12_A100CompanyId = new long[1] ;
         T000D15_A158CompanyLocationName = new string[] {""} ;
         T000D16_A160SiteSettingId = new long[1] ;
         T000D17_A124LeaveTypeId = new long[1] ;
         T000D18_A113HolidayId = new long[1] ;
         T000D19_A106EmployeeId = new long[1] ;
         T000D20_A100CompanyId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000D21_A157CompanyLocationId = new long[1] ;
         T000D21_A158CompanyLocationName = new string[] {""} ;
         T000D22_A157CompanyLocationId = new long[1] ;
         T000D22_A158CompanyLocationName = new string[] {""} ;
         T000D23_A101CompanyName = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.company__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.company__default(),
            new Object[][] {
                new Object[] {
               T000D2_A100CompanyId, T000D2_A101CompanyName, T000D2_A157CompanyLocationId
               }
               , new Object[] {
               T000D3_A100CompanyId, T000D3_A101CompanyName, T000D3_A157CompanyLocationId
               }
               , new Object[] {
               T000D4_A158CompanyLocationName
               }
               , new Object[] {
               T000D5_A100CompanyId, T000D5_A101CompanyName, T000D5_A158CompanyLocationName, T000D5_A157CompanyLocationId
               }
               , new Object[] {
               T000D6_A101CompanyName
               }
               , new Object[] {
               T000D7_A158CompanyLocationName
               }
               , new Object[] {
               T000D8_A100CompanyId
               }
               , new Object[] {
               T000D9_A100CompanyId
               }
               , new Object[] {
               T000D10_A100CompanyId
               }
               , new Object[] {
               }
               , new Object[] {
               T000D12_A100CompanyId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D15_A158CompanyLocationName
               }
               , new Object[] {
               T000D16_A160SiteSettingId
               }
               , new Object[] {
               T000D17_A124LeaveTypeId
               }
               , new Object[] {
               T000D18_A113HolidayId
               }
               , new Object[] {
               T000D19_A106EmployeeId
               }
               , new Object[] {
               T000D20_A100CompanyId
               }
               , new Object[] {
               T000D21_A157CompanyLocationId, T000D21_A158CompanyLocationName
               }
               , new Object[] {
               T000D22_A157CompanyLocationId, T000D22_A158CompanyLocationName
               }
               , new Object[] {
               T000D23_A101CompanyName
               }
            }
         );
         AV24Pgmname = "Company";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound14 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtCompanyName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCompanyId_Enabled ;
      private int edtCompanyId_Visible ;
      private int AV25GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private long wcpOAV7CompanyId ;
      private long Z100CompanyId ;
      private long Z157CompanyLocationId ;
      private long N157CompanyLocationId ;
      private long A157CompanyLocationId ;
      private long AV7CompanyId ;
      private long A100CompanyId ;
      private long AV23Insert_CompanyLocationId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z101CompanyName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCompanyName_Internalname ;
      private string dynCompanyLocationId_Internalname ;
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
      private string A101CompanyName ;
      private string edtCompanyName_Jsonclick ;
      private string dynCompanyLocationId_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCompanyId_Internalname ;
      private string edtCompanyId_Jsonclick ;
      private string A158CompanyLocationName ;
      private string AV24Pgmname ;
      private string hsh ;
      private string sMode14 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z158CompanyLocationName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private bool gxdyncontrolsrefreshing ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynCompanyLocationId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000D4_A158CompanyLocationName ;
      private long[] T000D5_A100CompanyId ;
      private string[] T000D5_A101CompanyName ;
      private string[] T000D5_A158CompanyLocationName ;
      private long[] T000D5_A157CompanyLocationId ;
      private string[] T000D6_A101CompanyName ;
      private string[] T000D7_A158CompanyLocationName ;
      private long[] T000D8_A100CompanyId ;
      private long[] T000D3_A100CompanyId ;
      private string[] T000D3_A101CompanyName ;
      private long[] T000D3_A157CompanyLocationId ;
      private long[] T000D9_A100CompanyId ;
      private long[] T000D10_A100CompanyId ;
      private long[] T000D2_A100CompanyId ;
      private string[] T000D2_A101CompanyName ;
      private long[] T000D2_A157CompanyLocationId ;
      private long[] T000D12_A100CompanyId ;
      private string[] T000D15_A158CompanyLocationName ;
      private long[] T000D16_A160SiteSettingId ;
      private long[] T000D17_A124LeaveTypeId ;
      private long[] T000D18_A113HolidayId ;
      private long[] T000D19_A106EmployeeId ;
      private long[] T000D20_A100CompanyId ;
      private long[] T000D21_A157CompanyLocationId ;
      private string[] T000D21_A158CompanyLocationName ;
      private long[] T000D22_A157CompanyLocationId ;
      private string[] T000D22_A158CompanyLocationName ;
      private string[] T000D23_A101CompanyName ;
      private IDataStoreProvider pr_gam ;
   }

   public class company__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class company__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000D2;
        prmT000D2 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D3;
        prmT000D3 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D4;
        prmT000D4 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000D5;
        prmT000D5 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D6;
        prmT000D6 = new Object[] {
        new ParDef("CompanyName",GXType.Char,100,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D7;
        prmT000D7 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000D8;
        prmT000D8 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D9;
        prmT000D9 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D10;
        prmT000D10 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D11;
        prmT000D11 = new Object[] {
        new ParDef("CompanyName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000D12;
        prmT000D12 = new Object[] {
        };
        Object[] prmT000D13;
        prmT000D13 = new Object[] {
        new ParDef("CompanyName",GXType.Char,100,0) ,
        new ParDef("CompanyLocationId",GXType.Int64,10,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D14;
        prmT000D14 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D15;
        prmT000D15 = new Object[] {
        new ParDef("CompanyLocationId",GXType.Int64,10,0)
        };
        Object[] prmT000D16;
        prmT000D16 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D17;
        prmT000D17 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D18;
        prmT000D18 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D19;
        prmT000D19 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000D20;
        prmT000D20 = new Object[] {
        };
        Object[] prmT000D21;
        prmT000D21 = new Object[] {
        };
        Object[] prmT000D22;
        prmT000D22 = new Object[] {
        };
        Object[] prmT000D23;
        prmT000D23 = new Object[] {
        new ParDef("CompanyName",GXType.Char,100,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000D2", "SELECT CompanyId, CompanyName, CompanyLocationId FROM Company WHERE CompanyId = :CompanyId  FOR UPDATE OF Company NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D3", "SELECT CompanyId, CompanyName, CompanyLocationId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D4", "SELECT CompanyLocationName FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D5", "SELECT TM1.CompanyId, TM1.CompanyName, T2.CompanyLocationName, TM1.CompanyLocationId FROM (Company TM1 INNER JOIN CompanyLocation T2 ON T2.CompanyLocationId = TM1.CompanyLocationId) WHERE TM1.CompanyId = :CompanyId ORDER BY TM1.CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D6", "SELECT CompanyName FROM Company WHERE (CompanyName = :CompanyName) AND (Not ( CompanyId = :CompanyId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D7", "SELECT CompanyLocationName FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D8", "SELECT CompanyId FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D9", "SELECT CompanyId FROM Company WHERE ( CompanyId > :CompanyId) ORDER BY CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D10", "SELECT CompanyId FROM Company WHERE ( CompanyId < :CompanyId) ORDER BY CompanyId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D11", "SAVEPOINT gxupdate;INSERT INTO Company(CompanyName, CompanyLocationId) VALUES(:CompanyName, :CompanyLocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000D11)
           ,new CursorDef("T000D12", "SELECT currval('CompanyId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D13", "SAVEPOINT gxupdate;UPDATE Company SET CompanyName=:CompanyName, CompanyLocationId=:CompanyLocationId  WHERE CompanyId = :CompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000D13)
           ,new CursorDef("T000D14", "SAVEPOINT gxupdate;DELETE FROM Company  WHERE CompanyId = :CompanyId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000D14)
           ,new CursorDef("T000D15", "SELECT CompanyLocationName FROM CompanyLocation WHERE CompanyLocationId = :CompanyLocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D16", "SELECT SiteSettingId FROM SiteSetting WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D17", "SELECT LeaveTypeId FROM LeaveType WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D18", "SELECT HolidayId FROM Holiday WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D19", "SELECT EmployeeId FROM Employee WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D20", "SELECT CompanyId FROM Company ORDER BY CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D21", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D21,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D22", "SELECT CompanyLocationId, CompanyLocationName FROM CompanyLocation ORDER BY CompanyLocationName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D22,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D23", "SELECT CompanyName FROM Company WHERE (CompanyName = :CompanyName) AND (Not ( CompanyId = :CompanyId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D23,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
     }
  }

}

}
