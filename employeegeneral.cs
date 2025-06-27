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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class employeegeneral : GXWebComponent
   {
      public employeegeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public employeegeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId )
      {
         this.A106EmployeeId = aP0_EmployeeId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         dynCompanyId = new GXCombobox();
         chkEmployeeIsActive = new GXCheckbox();
         chkEmployeeIsManager = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "EmployeeId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A106EmployeeId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "EmployeeId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "EmployeeId");
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
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA342( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV17Pgmname = "EmployeeGeneral";
               edtavEmployeeapipassword_Enabled = 0;
               AssignProp(sPrefix, false, edtavEmployeeapipassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployeeapipassword_Enabled), 5, 0), true);
               WS342( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Employee General") ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("employeegeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A106EmployeeId,10,0))}, new string[] {"EmployeeId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm342( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "EmployeeGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Employee General" ;
      }

      protected void WB340( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "employeegeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeFirstName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEmployeeFirstName_Internalname, "First Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmployeeFirstName_Internalname, StringUtil.RTrim( A107EmployeeFirstName), StringUtil.RTrim( context.localUtil.Format( A107EmployeeFirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeFirstName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeFirstName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_EmployeeGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeLastName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEmployeeLastName_Internalname, "Last Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmployeeLastName_Internalname, StringUtil.RTrim( A108EmployeeLastName), StringUtil.RTrim( context.localUtil.Format( A108EmployeeLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_EmployeeGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEmployeeEmail_Internalname, "Email", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmployeeEmail_Internalname, A109EmployeeEmail, StringUtil.RTrim( context.localUtil.Format( A109EmployeeEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A109EmployeeEmail, "", "", "", edtEmployeeEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_EmployeeGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynCompanyId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynCompanyId_Internalname, "Location", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynCompanyId, dynCompanyId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0)), 1, dynCompanyId_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynCompanyId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_EmployeeGeneral.htm");
            dynCompanyId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0));
            AssignProp(sPrefix, false, dynCompanyId_Internalname, "Values", (string)(dynCompanyId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkEmployeeIsActive_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkEmployeeIsActive_Internalname, "Is Active", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkEmployeeIsActive_Internalname, StringUtil.BoolToStr( A112EmployeeIsActive), "", "Is Active", 1, chkEmployeeIsActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(32, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,32);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkEmployeeIsManager_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkEmployeeIsManager_Internalname, "Is HR Manager", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkEmployeeIsManager_Internalname, StringUtil.BoolToStr( A110EmployeeIsManager), "", "Is HR Manager", 1, chkEmployeeIsManager.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeFTEHours_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEmployeeFTEHours_Internalname, "FTEHours", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmployeeFTEHours_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A188EmployeeFTEHours), 4, 0, ".", "")), StringUtil.LTrim( ((edtEmployeeFTEHours_Enabled!=0) ? context.localUtil.Format( (decimal)(A188EmployeeFTEHours), "ZZZ9") : context.localUtil.Format( (decimal)(A188EmployeeFTEHours), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeFTEHours_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeFTEHours_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EmployeeGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, divUnnamedtable2_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmployeeapipassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmployeeapipassword_Internalname, "API Token", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmployeeapipassword_Internalname, AV15EmployeeAPIPassword, StringUtil.RTrim( context.localUtil.Format( AV15EmployeeAPIPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployeeapipassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmployeeapipassword_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EmployeeGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11341_client"+"'", TempTags, "", 2, "HLP_EmployeeGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e12341_client"+"'", TempTags, "", 2, "HLP_EmployeeGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtEmployeeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeId_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeId_Visible, 0, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_EmployeeGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEmployeeVactionDays_Internalname, StringUtil.LTrim( StringUtil.NToC( A146EmployeeVactionDays, 4, 1, ".", "")), StringUtil.LTrim( context.localUtil.Format( A146EmployeeVactionDays, "Z9.9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeVactionDays_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeVactionDays_Visible, 0, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EmployeeGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEmployeeName_Internalname, StringUtil.RTrim( A148EmployeeName), StringUtil.RTrim( context.localUtil.Format( A148EmployeeName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeName_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeName_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_EmployeeGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtGAMUserGUID_Internalname, A111GAMUserGUID, StringUtil.RTrim( context.localUtil.Format( A111GAMUserGUID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGAMUserGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtGAMUserGUID_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_EmployeeGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEmployeeBalance_Internalname, StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")), StringUtil.LTrim( context.localUtil.Format( A147EmployeeBalance, "Z9.9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeBalance_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeBalance_Visible, 0, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EmployeeGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtEmployeeVacationDaysSetDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtEmployeeVacationDaysSetDate_Internalname, context.localUtil.Format(A177EmployeeVacationDaysSetDate, "99/99/99"), context.localUtil.Format( A177EmployeeVacationDaysSetDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeVacationDaysSetDate_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeVacationDaysSetDate_Visible, 0, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EmployeeGeneral.htm");
            GxWebStd.gx_bitmap( context, edtEmployeeVacationDaysSetDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtEmployeeVacationDaysSetDate_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EmployeeGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START342( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", "Employee General", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP340( ) ;
            }
         }
      }

      protected void WS342( )
      {
         START342( ) ;
         EVT342( ) ;
      }

      protected void EVT342( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP340( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP340( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13342 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP340( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14342 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP340( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP340( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavEmployeeapipassword_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE342( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm342( ) ;
            }
         }
      }

      protected void PA342( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavEmployeeapipassword_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLACOMPANYID341( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLACOMPANYID_data341( ) ;
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

      protected void GXACOMPANYID_html341( )
      {
         long gxdynajaxvalue;
         GXDLACOMPANYID_data341( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynCompanyId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynCompanyId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynCompanyId.ItemCount > 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
      }

      protected void GXDLACOMPANYID_data341( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00342 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00342_A100CompanyId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00342_A101CompanyName[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynCompanyId.Name = "COMPANYID";
            dynCompanyId.WebTags = "";
            dynCompanyId.removeAllItems();
            /* Using cursor H00343 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynCompanyId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00343_A100CompanyId[0]), 10, 0)), H00343_A101CompanyName[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynCompanyId.ItemCount > 0 )
            {
               A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynCompanyId.ItemCount > 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynCompanyId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0));
            AssignProp(sPrefix, false, dynCompanyId_Internalname, "Values", dynCompanyId.ToJavascriptSource(), true);
         }
         A112EmployeeIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A112EmployeeIsActive));
         AssignAttri(sPrefix, false, "A112EmployeeIsActive", A112EmployeeIsActive);
         A110EmployeeIsManager = StringUtil.StrToBool( StringUtil.BoolToStr( A110EmployeeIsManager));
         AssignAttri(sPrefix, false, "A110EmployeeIsManager", A110EmployeeIsManager);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF342( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "EmployeeGeneral";
         edtavEmployeeapipassword_Enabled = 0;
         AssignProp(sPrefix, false, edtavEmployeeapipassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployeeapipassword_Enabled), 5, 0), true);
      }

      protected void RF342( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00344 */
            pr_default.execute(2, new Object[] {A106EmployeeId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A177EmployeeVacationDaysSetDate = H00344_A177EmployeeVacationDaysSetDate[0];
               AssignAttri(sPrefix, false, "A177EmployeeVacationDaysSetDate", context.localUtil.Format(A177EmployeeVacationDaysSetDate, "99/99/99"));
               A147EmployeeBalance = H00344_A147EmployeeBalance[0];
               AssignAttri(sPrefix, false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
               A111GAMUserGUID = H00344_A111GAMUserGUID[0];
               AssignAttri(sPrefix, false, "A111GAMUserGUID", A111GAMUserGUID);
               A148EmployeeName = H00344_A148EmployeeName[0];
               AssignAttri(sPrefix, false, "A148EmployeeName", A148EmployeeName);
               A146EmployeeVactionDays = H00344_A146EmployeeVactionDays[0];
               AssignAttri(sPrefix, false, "A146EmployeeVactionDays", StringUtil.LTrimStr( A146EmployeeVactionDays, 4, 1));
               A188EmployeeFTEHours = H00344_A188EmployeeFTEHours[0];
               AssignAttri(sPrefix, false, "A188EmployeeFTEHours", StringUtil.LTrimStr( (decimal)(A188EmployeeFTEHours), 4, 0));
               A110EmployeeIsManager = H00344_A110EmployeeIsManager[0];
               AssignAttri(sPrefix, false, "A110EmployeeIsManager", A110EmployeeIsManager);
               A112EmployeeIsActive = H00344_A112EmployeeIsActive[0];
               AssignAttri(sPrefix, false, "A112EmployeeIsActive", A112EmployeeIsActive);
               A100CompanyId = H00344_A100CompanyId[0];
               AssignAttri(sPrefix, false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
               A109EmployeeEmail = H00344_A109EmployeeEmail[0];
               AssignAttri(sPrefix, false, "A109EmployeeEmail", A109EmployeeEmail);
               A108EmployeeLastName = H00344_A108EmployeeLastName[0];
               AssignAttri(sPrefix, false, "A108EmployeeLastName", A108EmployeeLastName);
               A107EmployeeFirstName = H00344_A107EmployeeFirstName[0];
               AssignAttri(sPrefix, false, "A107EmployeeFirstName", A107EmployeeFirstName);
               /* Execute user event: Load */
               E14342 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            WB340( ) ;
         }
      }

      protected void send_integrity_lvl_hashes342( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "EmployeeGeneral";
         edtavEmployeeapipassword_Enabled = 0;
         AssignProp(sPrefix, false, edtavEmployeeapipassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployeeapipassword_Enabled), 5, 0), true);
         edtEmployeeFirstName_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeFirstName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeFirstName_Enabled), 5, 0), true);
         edtEmployeeLastName_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeLastName_Enabled), 5, 0), true);
         edtEmployeeEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), true);
         dynCompanyId.Enabled = 0;
         AssignProp(sPrefix, false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         chkEmployeeIsActive.Enabled = 0;
         AssignProp(sPrefix, false, chkEmployeeIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Enabled), 5, 0), true);
         chkEmployeeIsManager.Enabled = 0;
         AssignProp(sPrefix, false, chkEmployeeIsManager_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsManager.Enabled), 5, 0), true);
         edtEmployeeFTEHours_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeFTEHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeFTEHours_Enabled), 5, 0), true);
         edtEmployeeId_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         edtEmployeeVactionDays_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeVactionDays_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeVactionDays_Enabled), 5, 0), true);
         edtEmployeeName_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Enabled), 5, 0), true);
         edtGAMUserGUID_Enabled = 0;
         AssignProp(sPrefix, false, edtGAMUserGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGAMUserGUID_Enabled), 5, 0), true);
         edtEmployeeBalance_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeBalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeBalance_Enabled), 5, 0), true);
         edtEmployeeVacationDaysSetDate_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeVacationDaysSetDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeVacationDaysSetDate_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP340( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13342 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
            AV13IsAuthorized_Delete = StringUtil.StrToBool( cgiGet( sPrefix+"vISAUTHORIZED_DELETE"));
            AV12IsAuthorized_Update = StringUtil.StrToBool( cgiGet( sPrefix+"vISAUTHORIZED_UPDATE"));
            /* Read variables values. */
            A107EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
            AssignAttri(sPrefix, false, "A107EmployeeFirstName", A107EmployeeFirstName);
            A108EmployeeLastName = cgiGet( edtEmployeeLastName_Internalname);
            AssignAttri(sPrefix, false, "A108EmployeeLastName", A108EmployeeLastName);
            A109EmployeeEmail = cgiGet( edtEmployeeEmail_Internalname);
            AssignAttri(sPrefix, false, "A109EmployeeEmail", A109EmployeeEmail);
            dynCompanyId.CurrentValue = cgiGet( dynCompanyId_Internalname);
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynCompanyId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            A112EmployeeIsActive = StringUtil.StrToBool( cgiGet( chkEmployeeIsActive_Internalname));
            AssignAttri(sPrefix, false, "A112EmployeeIsActive", A112EmployeeIsActive);
            A110EmployeeIsManager = StringUtil.StrToBool( cgiGet( chkEmployeeIsManager_Internalname));
            AssignAttri(sPrefix, false, "A110EmployeeIsManager", A110EmployeeIsManager);
            A188EmployeeFTEHours = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeFTEHours_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A188EmployeeFTEHours", StringUtil.LTrimStr( (decimal)(A188EmployeeFTEHours), 4, 0));
            AV15EmployeeAPIPassword = cgiGet( edtavEmployeeapipassword_Internalname);
            AssignAttri(sPrefix, false, "AV15EmployeeAPIPassword", AV15EmployeeAPIPassword);
            A146EmployeeVactionDays = context.localUtil.CToN( cgiGet( edtEmployeeVactionDays_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A146EmployeeVactionDays", StringUtil.LTrimStr( A146EmployeeVactionDays, 4, 1));
            A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
            AssignAttri(sPrefix, false, "A148EmployeeName", A148EmployeeName);
            A111GAMUserGUID = cgiGet( edtGAMUserGUID_Internalname);
            AssignAttri(sPrefix, false, "A111GAMUserGUID", A111GAMUserGUID);
            A147EmployeeBalance = context.localUtil.CToN( cgiGet( edtEmployeeBalance_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
            A177EmployeeVacationDaysSetDate = context.localUtil.CToD( cgiGet( edtEmployeeVacationDaysSetDate_Internalname), 2);
            AssignAttri(sPrefix, false, "A177EmployeeVacationDaysSetDate", context.localUtil.Format(A177EmployeeVacationDaysSetDate, "99/99/99"));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13342 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13342( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E14342( )
      {
         /* Load Routine */
         returnInSub = false;
         edtEmployeeId_Visible = 0;
         AssignProp(sPrefix, false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), true);
         edtEmployeeVactionDays_Visible = 0;
         AssignProp(sPrefix, false, edtEmployeeVactionDays_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeVactionDays_Visible), 5, 0), true);
         edtEmployeeName_Visible = 0;
         AssignProp(sPrefix, false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), true);
         edtGAMUserGUID_Visible = 0;
         AssignProp(sPrefix, false, edtGAMUserGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtGAMUserGUID_Visible), 5, 0), true);
         edtEmployeeBalance_Visible = 0;
         AssignProp(sPrefix, false, edtEmployeeBalance_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeBalance_Visible), 5, 0), true);
         edtEmployeeVacationDaysSetDate_Visible = 0;
         AssignProp(sPrefix, false, edtEmployeeVacationDaysSetDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeVacationDaysSetDate_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "employee_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "employee_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         divUnnamedtable2_Visible = (((StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divUnnamedtable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable2_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Employee";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A106EmployeeId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA342( ) ;
         WS342( ) ;
         WE342( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA106EmployeeId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA342( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "employeegeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA342( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A106EmployeeId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         wcpOA106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A106EmployeeId != wcpOA106EmployeeId ) ) )
         {
            setjustcreated();
         }
         wcpOA106EmployeeId = A106EmployeeId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA106EmployeeId = cgiGet( sPrefix+"A106EmployeeId_CTRL");
         if ( StringUtil.Len( sCtrlA106EmployeeId) > 0 )
         {
            A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA106EmployeeId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         else
         {
            A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A106EmployeeId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA342( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS342( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS342( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A106EmployeeId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA106EmployeeId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A106EmployeeId_CTRL", StringUtil.RTrim( sCtrlA106EmployeeId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE342( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267483244", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("employeegeneral.js", "?20256267483244", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynCompanyId.Name = "COMPANYID";
         dynCompanyId.WebTags = "";
         dynCompanyId.removeAllItems();
         /* Using cursor H00345 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            dynCompanyId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00345_A100CompanyId[0]), 10, 0)), H00345_A101CompanyName[0], 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( dynCompanyId.ItemCount > 0 )
         {
         }
         chkEmployeeIsActive.Name = "EMPLOYEEISACTIVE";
         chkEmployeeIsActive.WebTags = "";
         chkEmployeeIsActive.Caption = "Is Active";
         AssignProp(sPrefix, false, chkEmployeeIsActive_Internalname, "TitleCaption", chkEmployeeIsActive.Caption, true);
         chkEmployeeIsActive.CheckedValue = "false";
         chkEmployeeIsManager.Name = "EMPLOYEEISMANAGER";
         chkEmployeeIsManager.WebTags = "";
         chkEmployeeIsManager.Caption = "Is HR Manager";
         AssignProp(sPrefix, false, chkEmployeeIsManager_Internalname, "TitleCaption", chkEmployeeIsManager.Caption, true);
         chkEmployeeIsManager.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtEmployeeFirstName_Internalname = sPrefix+"EMPLOYEEFIRSTNAME";
         edtEmployeeLastName_Internalname = sPrefix+"EMPLOYEELASTNAME";
         edtEmployeeEmail_Internalname = sPrefix+"EMPLOYEEEMAIL";
         dynCompanyId_Internalname = sPrefix+"COMPANYID";
         chkEmployeeIsActive_Internalname = sPrefix+"EMPLOYEEISACTIVE";
         chkEmployeeIsManager_Internalname = sPrefix+"EMPLOYEEISMANAGER";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         edtEmployeeFTEHours_Internalname = sPrefix+"EMPLOYEEFTEHOURS";
         edtavEmployeeapipassword_Internalname = sPrefix+"vEMPLOYEEAPIPASSWORD";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtEmployeeId_Internalname = sPrefix+"EMPLOYEEID";
         edtEmployeeVactionDays_Internalname = sPrefix+"EMPLOYEEVACTIONDAYS";
         edtEmployeeName_Internalname = sPrefix+"EMPLOYEENAME";
         edtGAMUserGUID_Internalname = sPrefix+"GAMUSERGUID";
         edtEmployeeBalance_Internalname = sPrefix+"EMPLOYEEBALANCE";
         edtEmployeeVacationDaysSetDate_Internalname = sPrefix+"EMPLOYEEVACATIONDAYSSETDATE";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         chkEmployeeIsManager.Caption = "Is HR Manager";
         chkEmployeeIsActive.Caption = "Is Active";
         edtEmployeeVacationDaysSetDate_Enabled = 0;
         edtEmployeeBalance_Enabled = 0;
         edtGAMUserGUID_Enabled = 0;
         edtEmployeeName_Enabled = 0;
         edtEmployeeVactionDays_Enabled = 0;
         edtEmployeeId_Enabled = 0;
         edtEmployeeVacationDaysSetDate_Jsonclick = "";
         edtEmployeeVacationDaysSetDate_Visible = 1;
         edtEmployeeBalance_Jsonclick = "";
         edtEmployeeBalance_Visible = 1;
         edtGAMUserGUID_Jsonclick = "";
         edtGAMUserGUID_Visible = 1;
         edtEmployeeName_Jsonclick = "";
         edtEmployeeName_Visible = 1;
         edtEmployeeVactionDays_Jsonclick = "";
         edtEmployeeVactionDays_Visible = 1;
         edtEmployeeId_Jsonclick = "";
         edtEmployeeId_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtavEmployeeapipassword_Jsonclick = "";
         edtavEmployeeapipassword_Enabled = 1;
         divUnnamedtable2_Visible = 1;
         edtEmployeeFTEHours_Jsonclick = "";
         edtEmployeeFTEHours_Enabled = 0;
         chkEmployeeIsManager.Enabled = 0;
         chkEmployeeIsActive.Enabled = 0;
         dynCompanyId_Jsonclick = "";
         dynCompanyId.Enabled = 0;
         edtEmployeeEmail_Jsonclick = "";
         edtEmployeeEmail_Enabled = 0;
         edtEmployeeLastName_Jsonclick = "";
         edtEmployeeLastName_Enabled = 0;
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeFirstName_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"},{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E11341","iparms":[{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("'DOUPDATE'",""","oparms":[{"ctrl":"BTNUPDATE","prop":"Visible"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E12341","iparms":[{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("'DODELETE'",""","oparms":[{"ctrl":"BTNDELETE","prop":"Visible"}]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[]}""");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV17Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         A109EmployeeEmail = "";
         ClassString = "";
         StyleString = "";
         AV15EmployeeAPIPassword = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A148EmployeeName = "";
         A111GAMUserGUID = "";
         A177EmployeeVacationDaysSetDate = DateTime.MinValue;
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00342_A100CompanyId = new long[1] ;
         H00342_A101CompanyName = new string[] {""} ;
         H00343_A100CompanyId = new long[1] ;
         H00343_A101CompanyName = new string[] {""} ;
         H00344_A106EmployeeId = new long[1] ;
         H00344_A177EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         H00344_A147EmployeeBalance = new decimal[1] ;
         H00344_A111GAMUserGUID = new string[] {""} ;
         H00344_A148EmployeeName = new string[] {""} ;
         H00344_A146EmployeeVactionDays = new decimal[1] ;
         H00344_A188EmployeeFTEHours = new short[1] ;
         H00344_A110EmployeeIsManager = new bool[] {false} ;
         H00344_A112EmployeeIsActive = new bool[] {false} ;
         H00344_A100CompanyId = new long[1] ;
         H00344_A109EmployeeEmail = new string[] {""} ;
         H00344_A108EmployeeLastName = new string[] {""} ;
         H00344_A107EmployeeFirstName = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         Gx_mode = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA106EmployeeId = "";
         H00345_A100CompanyId = new long[1] ;
         H00345_A101CompanyName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeegeneral__default(),
            new Object[][] {
                new Object[] {
               H00342_A100CompanyId, H00342_A101CompanyName
               }
               , new Object[] {
               H00343_A100CompanyId, H00343_A101CompanyName
               }
               , new Object[] {
               H00344_A106EmployeeId, H00344_A177EmployeeVacationDaysSetDate, H00344_A147EmployeeBalance, H00344_A111GAMUserGUID, H00344_A148EmployeeName, H00344_A146EmployeeVactionDays, H00344_A188EmployeeFTEHours, H00344_A110EmployeeIsManager, H00344_A112EmployeeIsActive, H00344_A100CompanyId,
               H00344_A109EmployeeEmail, H00344_A108EmployeeLastName, H00344_A107EmployeeFirstName
               }
               , new Object[] {
               H00345_A100CompanyId, H00345_A101CompanyName
               }
            }
         );
         AV17Pgmname = "EmployeeGeneral";
         /* GeneXus formulas. */
         AV17Pgmname = "EmployeeGeneral";
         edtavEmployeeapipassword_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A188EmployeeFTEHours ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavEmployeeapipassword_Enabled ;
      private int edtEmployeeFirstName_Enabled ;
      private int edtEmployeeLastName_Enabled ;
      private int edtEmployeeEmail_Enabled ;
      private int edtEmployeeFTEHours_Enabled ;
      private int divUnnamedtable2_Visible ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtEmployeeId_Visible ;
      private int edtEmployeeVactionDays_Visible ;
      private int edtEmployeeName_Visible ;
      private int edtGAMUserGUID_Visible ;
      private int edtEmployeeBalance_Visible ;
      private int edtEmployeeVacationDaysSetDate_Visible ;
      private int gxdynajaxindex ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeVactionDays_Enabled ;
      private int edtEmployeeName_Enabled ;
      private int edtGAMUserGUID_Enabled ;
      private int edtEmployeeBalance_Enabled ;
      private int edtEmployeeVacationDaysSetDate_Enabled ;
      private int idxLst ;
      private long A106EmployeeId ;
      private long wcpOA106EmployeeId ;
      private long A100CompanyId ;
      private decimal A146EmployeeVactionDays ;
      private decimal A147EmployeeBalance ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV17Pgmname ;
      private string edtavEmployeeapipassword_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtEmployeeFirstName_Internalname ;
      private string TempTags ;
      private string A107EmployeeFirstName ;
      private string edtEmployeeFirstName_Jsonclick ;
      private string edtEmployeeLastName_Internalname ;
      private string A108EmployeeLastName ;
      private string edtEmployeeLastName_Jsonclick ;
      private string edtEmployeeEmail_Internalname ;
      private string edtEmployeeEmail_Jsonclick ;
      private string dynCompanyId_Internalname ;
      private string dynCompanyId_Jsonclick ;
      private string chkEmployeeIsActive_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string chkEmployeeIsManager_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtEmployeeFTEHours_Internalname ;
      private string edtEmployeeFTEHours_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string edtavEmployeeapipassword_Jsonclick ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string edtEmployeeId_Jsonclick ;
      private string edtEmployeeVactionDays_Internalname ;
      private string edtEmployeeVactionDays_Jsonclick ;
      private string edtEmployeeName_Internalname ;
      private string A148EmployeeName ;
      private string edtEmployeeName_Jsonclick ;
      private string edtGAMUserGUID_Internalname ;
      private string edtGAMUserGUID_Jsonclick ;
      private string edtEmployeeBalance_Internalname ;
      private string edtEmployeeBalance_Jsonclick ;
      private string edtEmployeeVacationDaysSetDate_Internalname ;
      private string edtEmployeeVacationDaysSetDate_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string Gx_mode ;
      private string sCtrlA106EmployeeId ;
      private DateTime A177EmployeeVacationDaysSetDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool A112EmployeeIsActive ;
      private bool A110EmployeeIsManager ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A109EmployeeEmail ;
      private string AV15EmployeeAPIPassword ;
      private string A111GAMUserGUID ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynCompanyId ;
      private GXCheckbox chkEmployeeIsActive ;
      private GXCheckbox chkEmployeeIsManager ;
      private IDataStoreProvider pr_default ;
      private long[] H00342_A100CompanyId ;
      private string[] H00342_A101CompanyName ;
      private long[] H00343_A100CompanyId ;
      private string[] H00343_A101CompanyName ;
      private long[] H00344_A106EmployeeId ;
      private DateTime[] H00344_A177EmployeeVacationDaysSetDate ;
      private decimal[] H00344_A147EmployeeBalance ;
      private string[] H00344_A111GAMUserGUID ;
      private string[] H00344_A148EmployeeName ;
      private decimal[] H00344_A146EmployeeVactionDays ;
      private short[] H00344_A188EmployeeFTEHours ;
      private bool[] H00344_A110EmployeeIsManager ;
      private bool[] H00344_A112EmployeeIsActive ;
      private long[] H00344_A100CompanyId ;
      private string[] H00344_A109EmployeeEmail ;
      private string[] H00344_A108EmployeeLastName ;
      private string[] H00344_A107EmployeeFirstName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H00345_A100CompanyId ;
      private string[] H00345_A101CompanyName ;
   }

   public class employeegeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00342;
          prmH00342 = new Object[] {
          };
          Object[] prmH00343;
          prmH00343 = new Object[] {
          };
          Object[] prmH00344;
          prmH00344 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmH00345;
          prmH00345 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00342", "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00342,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00343", "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00343,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00344", "SELECT EmployeeId, EmployeeVacationDaysSetDate, EmployeeBalance, GAMUserGUID, EmployeeName, EmployeeVactionDays, EmployeeFTEHours, EmployeeIsManager, EmployeeIsActive, CompanyId, EmployeeEmail, EmployeeLastName, EmployeeFirstName FROM Employee WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00344,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00345", "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00345,0, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((string[]) buf[12])[0] = rslt.getString(13, 100);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
