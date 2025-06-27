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
   public class gamexampleupdateregisteruser : GXHttpHandler
   {
      public gamexampleupdateregisteruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamexampleupdateregisteruser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_IDP_State )
      {
         this.AV13IDP_State = aP0_IDP_State;
         ExecuteImpl();
         aP0_IDP_State=this.AV13IDP_State;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGender = new GXCombobox();
         cmbavLanguage = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "IDP_State");
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
               gxfirstwebparm = GetFirstPar( "IDP_State");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "IDP_State");
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
               AV13IDP_State = gxfirstwebparm;
               AssignAttri("", false, "AV13IDP_State", AV13IDP_State);
               GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13IDP_State, "")), context));
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            ValidateSpaRequest();
            PA072( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS072( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE072( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Update register user") ;
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
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamexampleupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13IDP_State))}, new string[] {"IDP_State"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV13IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13IDP_State, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV13IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13IDP_State, "")), context));
      }

      protected void RenderHtmlCloseForm072( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override string GetPgmname( )
      {
         return "GAMExampleUpdateRegisterUser" ;
      }

      public override string GetPgmdesc( )
      {
         return "Update register user" ;
      }

      protected void WB070( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "table-login stack-top-xxl", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-xl", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbtitle_Internalname, "Update User Data", "", "", lblTbtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavName_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "UserName  *", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV16Name, StringUtil.RTrim( context.localUtil.Format( AV16Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", edtavName_Visible, edtavName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, edtavEmail_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV6EMail, StringUtil.RTrim( context.localUtil.Format( AV6EMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_firstname_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, edtavFirstname_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV7FirstName), StringUtil.RTrim( context.localUtil.Format( AV7FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFirstname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_lastname_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, edtavLastname_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV15LastName), StringUtil.RTrim( context.localUtil.Format( AV15LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLastname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_phone_Internalname, divCell_phone_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPhone_Internalname, edtavPhone_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhone_Internalname, StringUtil.RTrim( AV62Phone), StringUtil.RTrim( context.localUtil.Format( AV62Phone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPhone_Enabled, 0, "text", "", 60, "chr", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_birthday_Internalname, divCell_birthday_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavBirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBirthday_Internalname, edtavBirthday_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavBirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavBirthday_Internalname, context.localUtil.Format(AV5Birthday, "99/99/9999"), context.localUtil.Format( AV5Birthday, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBirthday_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavBirthday_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "end", false, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_bitmap( context, edtavBirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavBirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_gender_Internalname, divCell_gender_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavGender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGender_Internalname, cmbavGender.Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGender, cmbavGender_Internalname, StringUtil.RTrim( AV12Gender), 1, cmbavGender_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_GAMExampleUpdateRegisterUser.htm");
            cmbavGender.CurrentValue = StringUtil.RTrim( AV12Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", (string)(cmbavGender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_address_Internalname, divCell_address_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAddress_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAddress_Internalname, edtavAddress_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAddress_Internalname, StringUtil.RTrim( AV52Address), StringUtil.RTrim( context.localUtil.Format( AV52Address, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAddress_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAddress_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_city_Internalname, divCell_city_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCity_Internalname, edtavCity_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCity_Internalname, StringUtil.RTrim( AV53City), StringUtil.RTrim( context.localUtil.Format( AV53City, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCity_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_state_Internalname, divCell_state_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavState_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavState_Internalname, edtavState_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavState_Internalname, StringUtil.RTrim( AV64State), StringUtil.RTrim( context.localUtil.Format( AV64State, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavState_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavState_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMAddress", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_postcode_Internalname, divCell_postcode_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPostcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPostcode_Internalname, edtavPostcode_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPostcode_Internalname, StringUtil.RTrim( AV63PostCode), StringUtil.RTrim( context.localUtil.Format( AV63PostCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPostcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPostcode_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_language_Internalname, divCell_language_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavLanguage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLanguage_Internalname, cmbavLanguage.Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLanguage, cmbavLanguage_Internalname, StringUtil.RTrim( AV61Language), 1, cmbavLanguage_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavLanguage.Enabled, 0, 0, 30, "%", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_GAMExampleUpdateRegisterUser.htm");
            cmbavLanguage.CurrentValue = StringUtil.RTrim( AV61Language);
            AssignProp("", false, cmbavLanguage_Internalname, "Values", (string)(cmbavLanguage.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_timezone_Internalname, divCell_timezone_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTimezone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTimezone_Internalname, edtavTimezone_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTimezone_Internalname, StringUtil.RTrim( AV65Timezone), StringUtil.RTrim( context.localUtil.Format( AV65Timezone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTimezone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTimezone_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMTimeZone", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_photo_Internalname, divCell_photo_Visible, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUrlimage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUrlimage_Internalname, edtavUrlimage_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUrlimage_Internalname, AV66URLImage, StringUtil.RTrim( context.localUtil.Format( AV66URLImage, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUrlimage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUrlimage_Enabled, 0, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-top-xl", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Button button-secondary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButtonlogin_Internalname, "", "Back to Login", bttButtonlogin_Jsonclick, 5, "Back to Login", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'RETURNTOLOGIN\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButton2_Internalname, "", "Confirm", bttButton2_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMExampleUpdateRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START072( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Update register user", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP070( ) ;
      }

      protected void WS072( )
      {
         START072( ) ;
         EVT072( ) ;
      }

      protected void EVT072( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
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
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                                 /* Execute user event: Enter */
                                 E12072 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'RETURNTOLOGIN'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'ReturnToLogin' */
                           E13072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E14072 ();
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
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

      protected void WE072( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm072( ) ;
            }
         }
      }

      protected void PA072( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavGender.ItemCount > 0 )
         {
            AV12Gender = cmbavGender.getValidValue(AV12Gender);
            AssignAttri("", false, "AV12Gender", AV12Gender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGender.CurrentValue = StringUtil.RTrim( AV12Gender);
            AssignProp("", false, cmbavGender_Internalname, "Values", cmbavGender.ToJavascriptSource(), true);
         }
         if ( cmbavLanguage.ItemCount > 0 )
         {
            AV61Language = cmbavLanguage.getValidValue(AV61Language);
            AssignAttri("", false, "AV61Language", AV61Language);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLanguage.CurrentValue = StringUtil.RTrim( AV61Language);
            AssignProp("", false, cmbavLanguage_Internalname, "Values", cmbavLanguage.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF072( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF072( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14072 ();
            WB070( ) ;
         }
      }

      protected void send_integrity_lvl_hashes072( )
      {
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV13IDP_State));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13IDP_State, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP070( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11072 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV16Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV16Name", AV16Name);
            AV6EMail = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV6EMail", AV6EMail);
            AV7FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV7FirstName", AV7FirstName);
            AV15LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV15LastName", AV15LastName);
            AV62Phone = cgiGet( edtavPhone_Internalname);
            AssignAttri("", false, "AV62Phone", AV62Phone);
            if ( context.localUtil.VCDate( cgiGet( edtavBirthday_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Birthday"}), 1, "vBIRTHDAY");
               GX_FocusControl = edtavBirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5Birthday = DateTime.MinValue;
               AssignAttri("", false, "AV5Birthday", context.localUtil.Format(AV5Birthday, "99/99/9999"));
            }
            else
            {
               AV5Birthday = context.localUtil.CToD( cgiGet( edtavBirthday_Internalname), 2);
               AssignAttri("", false, "AV5Birthday", context.localUtil.Format(AV5Birthday, "99/99/9999"));
            }
            cmbavGender.CurrentValue = cgiGet( cmbavGender_Internalname);
            AV12Gender = cgiGet( cmbavGender_Internalname);
            AssignAttri("", false, "AV12Gender", AV12Gender);
            AV52Address = cgiGet( edtavAddress_Internalname);
            AssignAttri("", false, "AV52Address", AV52Address);
            AV53City = cgiGet( edtavCity_Internalname);
            AssignAttri("", false, "AV53City", AV53City);
            AV64State = cgiGet( edtavState_Internalname);
            AssignAttri("", false, "AV64State", AV64State);
            AV63PostCode = cgiGet( edtavPostcode_Internalname);
            AssignAttri("", false, "AV63PostCode", AV63PostCode);
            cmbavLanguage.CurrentValue = cgiGet( cmbavLanguage_Internalname);
            AV61Language = cgiGet( cmbavLanguage_Internalname);
            AssignAttri("", false, "AV61Language", AV61Language);
            AV65Timezone = cgiGet( edtavTimezone_Internalname);
            AssignAttri("", false, "AV65Timezone", AV65Timezone);
            AV66URLImage = cgiGet( edtavUrlimage_Internalname);
            AssignAttri("", false, "AV66URLImage", AV66URLImage);
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
         E11072 ();
         if (returnInSub) return;
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         AV59GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV59GAMRepository.gxTpr_Useridentification, "email") == 0 )
         {
            edtavName_Visible = 0;
            AssignProp("", false, edtavName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavName_Visible), 5, 0), true);
         }
         /* Execute user subroutine: 'MARKREQUIEREDUSERDATA' */
         S112 ();
         if (returnInSub) return;
         AV60GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbykeytocompleteuserdata(out  AV58GAMErrorCollection);
         if ( AV58GAMErrorCollection.Count > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S122 ();
            if (returnInSub) return;
         }
         else
         {
            AV58GAMErrorCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S122 ();
            if (returnInSub) return;
            AV16Name = AV60GAMUser.gxTpr_Name;
            AssignAttri("", false, "AV16Name", AV16Name);
            AV6EMail = AV60GAMUser.gxTpr_Email;
            AssignAttri("", false, "AV6EMail", AV6EMail);
            AV7FirstName = AV60GAMUser.gxTpr_Firstname;
            AssignAttri("", false, "AV7FirstName", AV7FirstName);
            AV15LastName = AV60GAMUser.gxTpr_Lastname;
            AssignAttri("", false, "AV15LastName", AV15LastName);
            AV62Phone = AV60GAMUser.gxTpr_Phone;
            AssignAttri("", false, "AV62Phone", AV62Phone);
            AV5Birthday = AV60GAMUser.gxTpr_Birthday;
            AssignAttri("", false, "AV5Birthday", context.localUtil.Format(AV5Birthday, "99/99/9999"));
            AV12Gender = AV60GAMUser.gxTpr_Gender;
            AssignAttri("", false, "AV12Gender", AV12Gender);
            AV52Address = AV60GAMUser.gxTpr_Address;
            AssignAttri("", false, "AV52Address", AV52Address);
            AV53City = AV60GAMUser.gxTpr_City;
            AssignAttri("", false, "AV53City", AV53City);
            AV64State = AV60GAMUser.gxTpr_State;
            AssignAttri("", false, "AV64State", AV64State);
            AV63PostCode = AV60GAMUser.gxTpr_Postcode;
            AssignAttri("", false, "AV63PostCode", AV63PostCode);
            AV61Language = AV60GAMUser.gxTpr_Language;
            AssignAttri("", false, "AV61Language", AV61Language);
            AV65Timezone = AV60GAMUser.gxTpr_Timezone;
            AssignAttri("", false, "AV65Timezone", AV65Timezone);
            AV66URLImage = AV60GAMUser.gxTpr_Urlimage;
            AssignAttri("", false, "AV66URLImage", AV66URLImage);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12072 ();
         if (returnInSub) return;
      }

      protected void E12072( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV60GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbykeytocompleteuserdata(out  AV58GAMErrorCollection);
         AV60GAMUser.gxTpr_Name = AV16Name;
         AV60GAMUser.gxTpr_Email = AV6EMail;
         AV60GAMUser.gxTpr_Firstname = AV7FirstName;
         AV60GAMUser.gxTpr_Lastname = AV15LastName;
         AV60GAMUser.gxTpr_Phone = AV62Phone;
         AV60GAMUser.gxTpr_Birthday = AV5Birthday;
         AV60GAMUser.gxTpr_Gender = AV12Gender;
         AV60GAMUser.gxTpr_Address = AV52Address;
         AV60GAMUser.gxTpr_City = AV53City;
         AV60GAMUser.gxTpr_State = AV64State;
         AV60GAMUser.gxTpr_Postcode = AV63PostCode;
         AV60GAMUser.gxTpr_Language = AV61Language;
         AV60GAMUser.gxTpr_Timezone = AV65Timezone;
         AV60GAMUser.gxTpr_Urlimage = AV66URLImage;
         AV14isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).updateuserbykeytocompleteuserdata(AV60GAMUser, out  AV58GAMErrorCollection);
         if ( AV14isOK )
         {
            if ( AV58GAMErrorCollection.Count > 0 )
            {
               GX_msglist.addItem("Your data has been updated successfully!.");
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S122 ();
               if (returnInSub) return;
            }
            else
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV13IDP_State) )
               {
                  new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).redirecttoremoteauthentication(AV13IDP_State) ;
               }
               else
               {
                  AV17URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17URL)) )
                  {
                     CallWebObject(formatLink("gamhome.aspx") );
                     context.wjLocDisableFrm = 1;
                  }
                  else
                  {
                     CallWebObject(formatLink(AV17URL) );
                     context.wjLocDisableFrm = 0;
                  }
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S122 ();
            if (returnInSub) return;
         }
      }

      protected void S112( )
      {
         /* 'MARKREQUIEREDUSERDATA' Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(AV59GAMRepository.gxTpr_Useridentification, "email") == 0 ) || ( StringUtil.StrCmp(AV59GAMRepository.gxTpr_Useridentification, "namema") == 0 ) )
         {
            if ( AV59GAMRepository.gxTpr_Requiredemail )
            {
               edtavEmail_Caption = edtavEmail_Caption+"  *";
               AssignProp("", false, edtavEmail_Internalname, "Caption", edtavEmail_Caption, true);
            }
         }
         if ( AV59GAMRepository.gxTpr_Requiredfirstname )
         {
            edtavFirstname_Caption = edtavFirstname_Caption+"  *";
            AssignProp("", false, edtavFirstname_Internalname, "Caption", edtavFirstname_Caption, true);
         }
         if ( AV59GAMRepository.gxTpr_Requiredlastname )
         {
            edtavLastname_Caption = edtavLastname_Caption+"  *";
            AssignProp("", false, edtavLastname_Internalname, "Caption", edtavLastname_Caption, true);
         }
         divCell_phone_Visible = 0;
         AssignProp("", false, divCell_phone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_phone_Visible), 5, 0), true);
         if ( AV59GAMRepository.gxTpr_Requiredphone )
         {
            divCell_phone_Visible = 1;
            AssignProp("", false, divCell_phone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_phone_Visible), 5, 0), true);
            edtavPhone_Caption = edtavPhone_Caption+"  *";
            AssignProp("", false, edtavPhone_Internalname, "Caption", edtavPhone_Caption, true);
         }
         divCell_birthday_Visible = 0;
         AssignProp("", false, divCell_birthday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_birthday_Visible), 5, 0), true);
         if ( AV59GAMRepository.gxTpr_Requiredbirthday )
         {
            divCell_birthday_Visible = 1;
            AssignProp("", false, divCell_birthday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_birthday_Visible), 5, 0), true);
            edtavBirthday_Caption = edtavBirthday_Caption+"  *";
            AssignProp("", false, edtavBirthday_Internalname, "Caption", edtavBirthday_Caption, true);
         }
         divCell_gender_Visible = 0;
         AssignProp("", false, divCell_gender_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_gender_Visible), 5, 0), true);
         if ( AV59GAMRepository.gxTpr_Requiredgender )
         {
            divCell_gender_Visible = 1;
            AssignProp("", false, divCell_gender_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_gender_Visible), 5, 0), true);
            cmbavGender.Caption = cmbavGender.Caption+"  *";
            AssignProp("", false, cmbavGender_Internalname, "Caption", cmbavGender.Caption, true);
         }
         divCell_address_Visible = 0;
         AssignProp("", false, divCell_address_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_address_Visible), 5, 0), true);
         if ( AV59GAMRepository.gxTpr_Requiredaddress )
         {
            divCell_address_Visible = 1;
            AssignProp("", false, divCell_address_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_address_Visible), 5, 0), true);
            edtavAddress_Caption = edtavAddress_Caption+"  *";
            AssignProp("", false, edtavAddress_Internalname, "Caption", edtavAddress_Caption, true);
         }
         divCell_city_Visible = 0;
         AssignProp("", false, divCell_city_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_city_Visible), 5, 0), true);
         if ( AV59GAMRepository.gxTpr_Requiredcity )
         {
            divCell_city_Visible = 1;
            AssignProp("", false, divCell_city_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_city_Visible), 5, 0), true);
            edtavCity_Caption = edtavCity_Caption+"  *";
            AssignProp("", false, edtavCity_Internalname, "Caption", edtavCity_Caption, true);
         }
         divCell_state_Visible = 0;
         AssignProp("", false, divCell_state_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_state_Visible), 5, 0), true);
         if ( AV59GAMRepository.gxTpr_Requiredstate )
         {
            divCell_state_Visible = 1;
            AssignProp("", false, divCell_state_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_state_Visible), 5, 0), true);
            edtavState_Caption = edtavState_Caption+"  *";
            AssignProp("", false, edtavState_Internalname, "Caption", edtavState_Caption, true);
         }
         divCell_postcode_Visible = 0;
         AssignProp("", false, divCell_postcode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_postcode_Visible), 5, 0), true);
         if ( AV59GAMRepository.gxTpr_Requiredpostcode )
         {
            divCell_postcode_Visible = 1;
            AssignProp("", false, divCell_postcode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_postcode_Visible), 5, 0), true);
            edtavPostcode_Caption = edtavPostcode_Caption+"  *";
            AssignProp("", false, edtavPostcode_Internalname, "Caption", edtavPostcode_Caption, true);
         }
         divCell_language_Visible = 0;
         AssignProp("", false, divCell_language_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_language_Visible), 5, 0), true);
         if ( AV59GAMRepository.gxTpr_Requiredlanguage )
         {
            /* Execute user subroutine: 'LOADLANGUAGES' */
            S132 ();
            if (returnInSub) return;
            divCell_language_Visible = 1;
            AssignProp("", false, divCell_language_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_language_Visible), 5, 0), true);
            cmbavLanguage.Caption = cmbavLanguage.Caption+"  *";
            AssignProp("", false, cmbavLanguage_Internalname, "Caption", cmbavLanguage.Caption, true);
         }
         divCell_timezone_Visible = 0;
         AssignProp("", false, divCell_timezone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_timezone_Visible), 5, 0), true);
         if ( AV59GAMRepository.gxTpr_Requiredtimezone )
         {
            divCell_timezone_Visible = 1;
            AssignProp("", false, divCell_timezone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_timezone_Visible), 5, 0), true);
            edtavTimezone_Caption = edtavTimezone_Caption+"  *";
            AssignProp("", false, edtavTimezone_Internalname, "Caption", edtavTimezone_Caption, true);
         }
         divCell_photo_Visible = 0;
         AssignProp("", false, divCell_photo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_photo_Visible), 5, 0), true);
         if ( AV59GAMRepository.gxTpr_Requiredphoto )
         {
            divCell_photo_Visible = 1;
            AssignProp("", false, divCell_photo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCell_photo_Visible), 5, 0), true);
            edtavUrlimage_Caption = edtavUrlimage_Caption+"  *";
            AssignProp("", false, edtavUrlimage_Internalname, "Caption", edtavUrlimage_Caption, true);
         }
      }

      protected void E13072( )
      {
         /* 'ReturnToLogin' Routine */
         returnInSub = false;
         AV14isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).logout(out  AV58GAMErrorCollection);
         new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgohome("8d9934db-05db-4d64-adba-5e0466c3appU") ;
      }

      protected void S132( )
      {
         /* 'LOADLANGUAGES' Routine */
         returnInSub = false;
         AV54GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV56GAMApplicationLanguageCollection = AV54GAMApplication.gxTpr_Languages;
         AV67GXV1 = 1;
         while ( AV67GXV1 <= AV56GAMApplicationLanguageCollection.Count )
         {
            AV55GAMApplicationLanguage = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage)AV56GAMApplicationLanguageCollection.Item(AV67GXV1));
            if ( AV55GAMApplicationLanguage.gxTpr_Online )
            {
               cmbavLanguage.addItem(AV55GAMApplicationLanguage.gxTpr_Culture, AV55GAMApplicationLanguage.gxTpr_Description, 0);
            }
            AV67GXV1 = (int)(AV67GXV1+1);
         }
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV68GXV2 = 1;
         while ( AV68GXV2 <= AV58GAMErrorCollection.Count )
         {
            AV57GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV58GAMErrorCollection.Item(AV68GXV2));
            GX_msglist.addItem(AV57GAMError.gxTpr_Message);
            AV68GXV2 = (int)(AV68GXV2+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E14072( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV13IDP_State", AV13IDP_State);
         GxWebStd.gx_hidden_field( context, "gxhash_vIDP_STATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV13IDP_State, "")), context));
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
         PA072( ) ;
         WS072( ) ;
         WE072( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256246585143", true, true);
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
         context.AddJavascriptSource("gamexampleupdateregisteruser.js", "?20256246585146", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavGender.Name = "vGENDER";
         cmbavGender.WebTags = "";
         cmbavGender.addItem("N", "(Not Specified)", 0);
         cmbavGender.addItem("F", "Female", 0);
         cmbavGender.addItem("M", "Male", 0);
         if ( cmbavGender.ItemCount > 0 )
         {
            AV12Gender = cmbavGender.getValidValue(AV12Gender);
            AssignAttri("", false, "AV12Gender", AV12Gender);
         }
         cmbavLanguage.Name = "vLANGUAGE";
         cmbavLanguage.WebTags = "";
         cmbavLanguage.addItem("", "(None)", 0);
         if ( cmbavLanguage.ItemCount > 0 )
         {
            AV61Language = cmbavLanguage.getValidValue(AV61Language);
            AssignAttri("", false, "AV61Language", AV61Language);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTbtitle_Internalname = "TBTITLE";
         edtavName_Internalname = "vNAME";
         edtavEmail_Internalname = "vEMAIL";
         edtavFirstname_Internalname = "vFIRSTNAME";
         divCell_firstname_Internalname = "CELL_FIRSTNAME";
         edtavLastname_Internalname = "vLASTNAME";
         divCell_lastname_Internalname = "CELL_LASTNAME";
         edtavPhone_Internalname = "vPHONE";
         divCell_phone_Internalname = "CELL_PHONE";
         edtavBirthday_Internalname = "vBIRTHDAY";
         divCell_birthday_Internalname = "CELL_BIRTHDAY";
         cmbavGender_Internalname = "vGENDER";
         divCell_gender_Internalname = "CELL_GENDER";
         edtavAddress_Internalname = "vADDRESS";
         divCell_address_Internalname = "CELL_ADDRESS";
         edtavCity_Internalname = "vCITY";
         divCell_city_Internalname = "CELL_CITY";
         edtavState_Internalname = "vSTATE";
         divCell_state_Internalname = "CELL_STATE";
         edtavPostcode_Internalname = "vPOSTCODE";
         divCell_postcode_Internalname = "CELL_POSTCODE";
         cmbavLanguage_Internalname = "vLANGUAGE";
         divCell_language_Internalname = "CELL_LANGUAGE";
         edtavTimezone_Internalname = "vTIMEZONE";
         divCell_timezone_Internalname = "CELL_TIMEZONE";
         edtavUrlimage_Internalname = "vURLIMAGE";
         divCell_photo_Internalname = "CELL_PHOTO";
         bttButtonlogin_Internalname = "BUTTONLOGIN";
         bttButton2_Internalname = "BUTTON2";
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
         edtavUrlimage_Jsonclick = "";
         edtavUrlimage_Enabled = 1;
         edtavUrlimage_Caption = "URL image";
         divCell_photo_Visible = 1;
         edtavTimezone_Jsonclick = "";
         edtavTimezone_Enabled = 1;
         edtavTimezone_Caption = "Timezone";
         divCell_timezone_Visible = 1;
         cmbavLanguage_Jsonclick = "";
         cmbavLanguage.Enabled = 1;
         cmbavLanguage.Caption = "Language";
         divCell_language_Visible = 1;
         edtavPostcode_Jsonclick = "";
         edtavPostcode_Enabled = 1;
         edtavPostcode_Caption = "Post Code";
         divCell_postcode_Visible = 1;
         edtavState_Jsonclick = "";
         edtavState_Enabled = 1;
         edtavState_Caption = "State";
         divCell_state_Visible = 1;
         edtavCity_Jsonclick = "";
         edtavCity_Enabled = 1;
         edtavCity_Caption = "City";
         divCell_city_Visible = 1;
         edtavAddress_Jsonclick = "";
         edtavAddress_Enabled = 1;
         edtavAddress_Caption = "Address";
         divCell_address_Visible = 1;
         cmbavGender_Jsonclick = "";
         cmbavGender.Enabled = 1;
         cmbavGender.Caption = "Gender";
         divCell_gender_Visible = 1;
         edtavBirthday_Jsonclick = "";
         edtavBirthday_Enabled = 1;
         edtavBirthday_Caption = "Birthday";
         divCell_birthday_Visible = 1;
         edtavPhone_Jsonclick = "";
         edtavPhone_Enabled = 1;
         edtavPhone_Caption = "Phone";
         divCell_phone_Visible = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         edtavLastname_Caption = "Last Name";
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         edtavFirstname_Caption = "First Name";
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         edtavEmail_Caption = "Email";
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavName_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV13IDP_State","fld":"vIDP_STATE","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E12072","iparms":[{"av":"AV16Name","fld":"vNAME"},{"av":"AV6EMail","fld":"vEMAIL"},{"av":"AV7FirstName","fld":"vFIRSTNAME"},{"av":"AV15LastName","fld":"vLASTNAME"},{"av":"AV62Phone","fld":"vPHONE"},{"av":"AV5Birthday","fld":"vBIRTHDAY"},{"av":"cmbavGender"},{"av":"AV12Gender","fld":"vGENDER"},{"av":"AV52Address","fld":"vADDRESS"},{"av":"AV53City","fld":"vCITY"},{"av":"AV64State","fld":"vSTATE"},{"av":"AV63PostCode","fld":"vPOSTCODE"},{"av":"cmbavLanguage"},{"av":"AV61Language","fld":"vLANGUAGE"},{"av":"AV65Timezone","fld":"vTIMEZONE"},{"av":"AV66URLImage","fld":"vURLIMAGE"},{"av":"AV13IDP_State","fld":"vIDP_STATE","hsh":true}]}""");
         setEventMetadata("'RETURNTOLOGIN'","""{"handler":"E13072","iparms":[]}""");
         setEventMetadata("VALIDV_GENDER","""{"handler":"Validv_Gender","iparms":[]}""");
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
         wcpOAV13IDP_State = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         lblTbtitle_Jsonclick = "";
         TempTags = "";
         AV16Name = "";
         AV6EMail = "";
         AV7FirstName = "";
         AV15LastName = "";
         AV62Phone = "";
         AV5Birthday = DateTime.MinValue;
         AV12Gender = "";
         AV52Address = "";
         AV53City = "";
         AV64State = "";
         AV63PostCode = "";
         AV61Language = "";
         AV65Timezone = "";
         AV66URLImage = "";
         ClassString = "";
         StyleString = "";
         bttButtonlogin_Jsonclick = "";
         bttButton2_Jsonclick = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV59GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV60GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV58GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV17URL = "";
         AV54GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV56GAMApplicationLanguageCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage", "GeneXus.Programs");
         AV55GAMApplicationLanguage = new GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage(context);
         AV57GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavName_Visible ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int divCell_phone_Visible ;
      private int edtavPhone_Enabled ;
      private int divCell_birthday_Visible ;
      private int edtavBirthday_Enabled ;
      private int divCell_gender_Visible ;
      private int divCell_address_Visible ;
      private int edtavAddress_Enabled ;
      private int divCell_city_Visible ;
      private int edtavCity_Enabled ;
      private int divCell_state_Visible ;
      private int edtavState_Enabled ;
      private int divCell_postcode_Visible ;
      private int edtavPostcode_Enabled ;
      private int divCell_language_Visible ;
      private int divCell_timezone_Visible ;
      private int edtavTimezone_Enabled ;
      private int divCell_photo_Visible ;
      private int edtavUrlimage_Enabled ;
      private int AV67GXV1 ;
      private int AV68GXV2 ;
      private int idxLst ;
      private string AV13IDP_State ;
      private string wcpOAV13IDP_State ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTbtitle_Internalname ;
      private string lblTbtitle_Jsonclick ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Caption ;
      private string edtavEmail_Jsonclick ;
      private string divCell_firstname_Internalname ;
      private string edtavFirstname_Internalname ;
      private string edtavFirstname_Caption ;
      private string AV7FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string divCell_lastname_Internalname ;
      private string edtavLastname_Internalname ;
      private string edtavLastname_Caption ;
      private string AV15LastName ;
      private string edtavLastname_Jsonclick ;
      private string divCell_phone_Internalname ;
      private string edtavPhone_Internalname ;
      private string edtavPhone_Caption ;
      private string AV62Phone ;
      private string edtavPhone_Jsonclick ;
      private string divCell_birthday_Internalname ;
      private string edtavBirthday_Internalname ;
      private string edtavBirthday_Caption ;
      private string edtavBirthday_Jsonclick ;
      private string divCell_gender_Internalname ;
      private string cmbavGender_Internalname ;
      private string AV12Gender ;
      private string cmbavGender_Jsonclick ;
      private string divCell_address_Internalname ;
      private string edtavAddress_Internalname ;
      private string edtavAddress_Caption ;
      private string AV52Address ;
      private string edtavAddress_Jsonclick ;
      private string divCell_city_Internalname ;
      private string edtavCity_Internalname ;
      private string edtavCity_Caption ;
      private string AV53City ;
      private string edtavCity_Jsonclick ;
      private string divCell_state_Internalname ;
      private string edtavState_Internalname ;
      private string edtavState_Caption ;
      private string AV64State ;
      private string edtavState_Jsonclick ;
      private string divCell_postcode_Internalname ;
      private string edtavPostcode_Internalname ;
      private string edtavPostcode_Caption ;
      private string AV63PostCode ;
      private string edtavPostcode_Jsonclick ;
      private string divCell_language_Internalname ;
      private string cmbavLanguage_Internalname ;
      private string cmbavLanguage_Jsonclick ;
      private string divCell_timezone_Internalname ;
      private string edtavTimezone_Internalname ;
      private string edtavTimezone_Caption ;
      private string AV65Timezone ;
      private string edtavTimezone_Jsonclick ;
      private string divCell_photo_Internalname ;
      private string edtavUrlimage_Internalname ;
      private string edtavUrlimage_Caption ;
      private string edtavUrlimage_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttButtonlogin_Internalname ;
      private string bttButtonlogin_Jsonclick ;
      private string bttButton2_Internalname ;
      private string bttButton2_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private DateTime AV5Birthday ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV14isOK ;
      private string AV16Name ;
      private string AV6EMail ;
      private string AV61Language ;
      private string AV66URLImage ;
      private string AV17URL ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private GXCombobox cmbavGender ;
      private GXCombobox cmbavLanguage ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV59GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV60GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV58GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV54GAMApplication ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage> AV56GAMApplicationLanguageCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationLanguage AV55GAMApplicationLanguage ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV57GAMError ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
