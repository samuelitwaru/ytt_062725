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
   public class gamappmenuoptionentry : GXDataArea
   {
      public gamappmenuoptionentry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamappmenuoptionentry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref long aP1_ApplicationId ,
                           ref long aP2_MenuId ,
                           ref long aP3_Id )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ApplicationId = aP1_ApplicationId;
         this.AV16MenuId = aP2_MenuId;
         this.AV14Id = aP3_Id;
         ExecuteImpl();
         aP0_Gx_mode=this.Gx_mode;
         aP1_ApplicationId=this.AV7ApplicationId;
         aP2_MenuId=this.AV16MenuId;
         aP3_Id=this.AV14Id;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavType = new GXCombobox();
         cmbavMenusid = new GXCombobox();
         cmbavRelresid = new GXCombobox();
         cmbavLink = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
                  AV7ApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ApplicationId", StringUtil.LTrimStr( (decimal)(AV7ApplicationId), 12, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ApplicationId), "ZZZZZZZZZZZ9"), context));
                  AV16MenuId = (long)(Math.Round(NumberUtil.Val( GetPar( "MenuId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV16MenuId", StringUtil.LTrimStr( (decimal)(AV16MenuId), 12, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16MenuId), "ZZZZZZZZZZZ9"), context));
                  AV14Id = (long)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Id", StringUtil.LTrimStr( (decimal)(AV14Id), 12, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14Id), "ZZZZZZZZZZZ9"), context));
               }
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
            return "gamappmenuoptionentry_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA202( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START202( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamappmenuoptionentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV16MenuId,12,0)),UrlEncode(StringUtil.LTrimStr(AV14Id,12,0))}, new string[] {"Gx_mode","ApplicationId","MenuId","Id"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMENUID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16MenuId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16MenuId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Id), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14Id), "ZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMENUID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16MenuId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16MenuId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Id), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14Id), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV6isOK);
      }

      public override void RenderHtmlCloseForm( )
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE202( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT202( ) ;
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
         return formatLink("gamappmenuoptionentry.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ApplicationId,12,0)),UrlEncode(StringUtil.LTrimStr(AV16MenuId,12,0)),UrlEncode(StringUtil.LTrimStr(AV14Id,12,0))}, new string[] {"Gx_mode","ApplicationId","MenuId","Id"})  ;
      }

      public override string GetPgmname( )
      {
         return "GAMAppMenuOptionEntry" ;
      }

      public override string GetPgmdesc( )
      {
         return "Menu Option" ;
      }

      protected void WB200( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-lg-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavGamapplication_name_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGamapplication_name_Internalname, "Application", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavGamapplication_name_Internalname, StringUtil.RTrim( AV5GAMApplication.gxTpr_Name), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", 0, 1, edtavGamapplication_name_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "254", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_GAMAppMenuOptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavApplicationmenu_name_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavApplicationmenu_name_Internalname, "Menu", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavApplicationmenu_name_Internalname, StringUtil.RTrim( AV8ApplicationMenu.gxTpr_Name), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", 0, 1, edtavApplicationmenu_name_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "254", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_GAMAppMenuOptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, "GUID", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV13GUID), StringUtil.RTrim( context.localUtil.Format( AV13GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavGuid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_GAMAppMenuOptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV18Name), StringUtil.RTrim( context.localUtil.Format( AV18Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMAppMenuOptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDsc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDsc_Internalname, "Description", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDsc_Internalname, StringUtil.RTrim( AV10Dsc), StringUtil.RTrim( context.localUtil.Format( AV10Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDsc_Enabled, 1, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMAppMenuOptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavType_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavType_Internalname, "Type", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavType, cmbavType_Internalname, StringUtil.RTrim( AV24Type), 1, cmbavType_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVTYPE.CLICK."+"'", "char", "", 1, cmbavType.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 0, "HLP_GAMAppMenuOptionEntry.htm");
            cmbavType.CurrentValue = StringUtil.RTrim( AV24Type);
            AssignProp("", false, cmbavType_Internalname, "Values", (string)(cmbavType.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMenusid_cell_Internalname, 1, 0, "px", 0, "px", divMenusid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavMenusid.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavMenusid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMenusid_Internalname, "Submenu", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMenusid, cmbavMenusid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17MenusId), 12, 0)), 1, cmbavMenusid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavMenusid.Visible, cmbavMenusid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_GAMAppMenuOptionEntry.htm");
            cmbavMenusid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17MenusId), 12, 0));
            AssignProp("", false, cmbavMenusid_Internalname, "Values", (string)(cmbavMenusid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRelresid_cell_Internalname, 1, 0, "px", 0, "px", divRelresid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavRelresid.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavRelresid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavRelresid_Internalname, "Permission", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavRelresid, cmbavRelresid_Internalname, StringUtil.RTrim( AV21RelResId), 1, cmbavRelresid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavRelresid.Visible, cmbavRelresid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_GAMAppMenuOptionEntry.htm");
            cmbavRelresid.CurrentValue = StringUtil.RTrim( AV21RelResId);
            AssignProp("", false, cmbavRelresid_Internalname, "Values", (string)(cmbavRelresid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResource_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResource_Internalname, "Resource", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResource_Internalname, AV22Resource, StringUtil.RTrim( context.localUtil.Format( AV22Resource, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResource_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResource_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMAppMenuOptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavResourceparameters_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResourceparameters_Internalname, "Resource Parameters", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResourceparameters_Internalname, AV23ResourceParameters, StringUtil.RTrim( context.localUtil.Format( AV23ResourceParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResourceparameters_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResourceparameters_Enabled, 1, "text", "", 0, "px", 1, "row", 2048, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMURL", "start", true, "", "HLP_GAMAppMenuOptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavIconclass_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavIconclass_Internalname, "Icon Class", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavIconclass_Internalname, AV30IconClass, StringUtil.RTrim( context.localUtil.Format( AV30IconClass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavIconclass_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavIconclass_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_GAMAppMenuOptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavLink_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLink_Internalname, "Link Target", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLink, cmbavLink_Internalname, StringUtil.RTrim( AV31Link), 1, cmbavLink_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavLink.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "", true, 0, "HLP_GAMAppMenuOptionEntry.htm");
            cmbavLink.CurrentValue = StringUtil.RTrim( AV31Link);
            AssignProp("", false, cmbavLink_Internalname, "Values", (string)(cmbavLink.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMAppMenuOptionEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMAppMenuOptionEntry.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm col-md-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRighttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START202( )
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
         Form.Meta.addItem("description", "Menu Option", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP200( ) ;
      }

      protected void WS202( )
      {
         START202( ) ;
         EVT202( ) ;
      }

      protected void EVT202( )
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
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
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
                              E11202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VTYPE.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12202 ();
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
                                    E13202 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VRELRESID.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14202 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15202 ();
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
      }

      protected void WE202( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA202( )
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
               GX_FocusControl = edtavGamapplication_name_Internalname;
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
         if ( cmbavType.ItemCount > 0 )
         {
            AV24Type = cmbavType.getValidValue(AV24Type);
            AssignAttri("", false, "AV24Type", AV24Type);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavType.CurrentValue = StringUtil.RTrim( AV24Type);
            AssignProp("", false, cmbavType_Internalname, "Values", cmbavType.ToJavascriptSource(), true);
         }
         if ( cmbavMenusid.ItemCount > 0 )
         {
            AV17MenusId = (long)(Math.Round(NumberUtil.Val( cmbavMenusid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17MenusId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17MenusId", StringUtil.LTrimStr( (decimal)(AV17MenusId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMenusid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17MenusId), 12, 0));
            AssignProp("", false, cmbavMenusid_Internalname, "Values", cmbavMenusid.ToJavascriptSource(), true);
         }
         if ( cmbavRelresid.ItemCount > 0 )
         {
            AV21RelResId = cmbavRelresid.getValidValue(AV21RelResId);
            AssignAttri("", false, "AV21RelResId", AV21RelResId);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavRelresid.CurrentValue = StringUtil.RTrim( AV21RelResId);
            AssignProp("", false, cmbavRelresid_Internalname, "Values", cmbavRelresid.ToJavascriptSource(), true);
         }
         if ( cmbavLink.ItemCount > 0 )
         {
            AV31Link = cmbavLink.getValidValue(AV31Link);
            AssignAttri("", false, "AV31Link", AV31Link);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLink.CurrentValue = StringUtil.RTrim( AV31Link);
            AssignProp("", false, cmbavLink_Internalname, "Values", cmbavLink.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF202( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavGamapplication_name_Enabled = 0;
         AssignProp("", false, edtavGamapplication_name_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamapplication_name_Enabled), 5, 0), true);
         edtavApplicationmenu_name_Enabled = 0;
         AssignProp("", false, edtavApplicationmenu_name_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavApplicationmenu_name_Enabled), 5, 0), true);
      }

      protected void RF202( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15202 ();
            WB200( ) ;
         }
      }

      protected void send_integrity_lvl_hashes202( )
      {
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMENUID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16MenuId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16MenuId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Id), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14Id), "ZZZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         edtavGamapplication_name_Enabled = 0;
         AssignProp("", false, edtavGamapplication_name_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGamapplication_name_Enabled), 5, 0), true);
         edtavApplicationmenu_name_Enabled = 0;
         AssignProp("", false, edtavApplicationmenu_name_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavApplicationmenu_name_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP200( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11202 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV5GAMApplication.gxTpr_Name = cgiGet( edtavGamapplication_name_Internalname);
            AV8ApplicationMenu.gxTpr_Name = cgiGet( edtavApplicationmenu_name_Internalname);
            AV13GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV13GUID", AV13GUID);
            AV18Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV18Name", AV18Name);
            AV10Dsc = cgiGet( edtavDsc_Internalname);
            AssignAttri("", false, "AV10Dsc", AV10Dsc);
            cmbavType.CurrentValue = cgiGet( cmbavType_Internalname);
            AV24Type = cgiGet( cmbavType_Internalname);
            AssignAttri("", false, "AV24Type", AV24Type);
            cmbavMenusid.CurrentValue = cgiGet( cmbavMenusid_Internalname);
            AV17MenusId = (long)(Math.Round(NumberUtil.Val( cgiGet( cmbavMenusid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17MenusId", StringUtil.LTrimStr( (decimal)(AV17MenusId), 12, 0));
            cmbavRelresid.CurrentValue = cgiGet( cmbavRelresid_Internalname);
            AV21RelResId = cgiGet( cmbavRelresid_Internalname);
            AssignAttri("", false, "AV21RelResId", AV21RelResId);
            AV22Resource = cgiGet( edtavResource_Internalname);
            AssignAttri("", false, "AV22Resource", AV22Resource);
            AV23ResourceParameters = cgiGet( edtavResourceparameters_Internalname);
            AssignAttri("", false, "AV23ResourceParameters", AV23ResourceParameters);
            AV30IconClass = cgiGet( edtavIconclass_Internalname);
            AssignAttri("", false, "AV30IconClass", AV30IconClass);
            cmbavLink.CurrentValue = cgiGet( cmbavLink_Internalname);
            AV31Link = cgiGet( cmbavLink_Internalname);
            AssignAttri("", false, "AV31Link", AV31Link);
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
         E11202 ();
         if (returnInSub) return;
      }

      protected void E11202( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5GAMApplication.load( AV7ApplicationId);
         AV8ApplicationMenu = AV5GAMApplication.getmenu(AV16MenuId, out  AV12Errors);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            AV9ApplicationMenuOption = AV8ApplicationMenu.getmenuoptionbyid(AV7ApplicationId, AV14Id, out  AV12Errors);
            AV18Name = AV9ApplicationMenuOption.gxTpr_Name;
            AssignAttri("", false, "AV18Name", AV18Name);
            AV10Dsc = AV9ApplicationMenuOption.gxTpr_Description;
            AssignAttri("", false, "AV10Dsc", AV10Dsc);
            AV13GUID = AV9ApplicationMenuOption.gxTpr_Guid;
            AssignAttri("", false, "AV13GUID", AV13GUID);
            AV24Type = AV9ApplicationMenuOption.gxTpr_Type;
            AssignAttri("", false, "AV24Type", AV24Type);
            AV17MenusId = AV9ApplicationMenuOption.gxTpr_Submenuid;
            AssignAttri("", false, "AV17MenusId", StringUtil.LTrimStr( (decimal)(AV17MenusId), 12, 0));
            AV21RelResId = AV9ApplicationMenuOption.gxTpr_Permissionresourceguid;
            AssignAttri("", false, "AV21RelResId", AV21RelResId);
            AV22Resource = AV9ApplicationMenuOption.gxTpr_Resource;
            AssignAttri("", false, "AV22Resource", AV22Resource);
            AV23ResourceParameters = AV9ApplicationMenuOption.gxTpr_Resourceparameters;
            AssignAttri("", false, "AV23ResourceParameters", AV23ResourceParameters);
            if ( AV9ApplicationMenuOption.gxTpr_Properties.Count > 0 )
            {
               AV30IconClass = ((GeneXus.Programs.genexussecurity.SdtGAMProperty)AV9ApplicationMenuOption.gxTpr_Properties.Item(1)).gxTpr_Value;
               AssignAttri("", false, "AV30IconClass", AV30IconClass);
               AV31Link = ((GeneXus.Programs.genexussecurity.SdtGAMProperty)AV9ApplicationMenuOption.gxTpr_Properties.Item(2)).gxTpr_Value;
               AssignAttri("", false, "AV31Link", AV31Link);
            }
            edtavGuid_Enabled = 0;
            AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
               {
                  bttBtnenter_Visible = 0;
                  AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
               }
               edtavName_Enabled = 0;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
               edtavDsc_Enabled = 0;
               AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), true);
               cmbavType.Enabled = 0;
               AssignProp("", false, cmbavType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavType.Enabled), 5, 0), true);
               cmbavMenusid.Enabled = 0;
               AssignProp("", false, cmbavMenusid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavMenusid.Enabled), 5, 0), true);
               cmbavRelresid.Enabled = 0;
               AssignProp("", false, cmbavRelresid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavRelresid.Enabled), 5, 0), true);
               edtavResource_Enabled = 0;
               AssignProp("", false, edtavResource_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResource_Enabled), 5, 0), true);
               edtavResourceparameters_Enabled = 0;
               AssignProp("", false, edtavResourceparameters_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavResourceparameters_Enabled), 5, 0), true);
               bttBtnenter_Caption = "Delete";
               AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
               cmbavLink.Enabled = 0;
               AssignProp("", false, cmbavLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavLink.Enabled), 5, 0), true);
               edtavIconclass_Enabled = 0;
               AssignProp("", false, edtavIconclass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavIconclass_Enabled), 5, 0), true);
            }
         }
         if ( StringUtil.StrCmp(AV24Type, "S") == 0 )
         {
            AV38GXV4 = 1;
            AV37GXV3 = AV5GAMApplication.getpermissions(AV20PermissionFilter, out  AV12Errors);
            while ( AV38GXV4 <= AV37GXV3.Count )
            {
               AV19Permission = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV37GXV3.Item(AV38GXV4));
               cmbavRelresid.addItem(AV19Permission.gxTpr_Guid, AV19Permission.gxTpr_Name, 0);
               AV38GXV4 = (int)(AV38GXV4+1);
            }
         }
         else
         {
            AV40GXV6 = 1;
            AV39GXV5 = AV5GAMApplication.getsubmenus(AV16MenuId, out  AV12Errors);
            while ( AV40GXV6 <= AV39GXV5.Count )
            {
               AV15Menu = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV39GXV5.Item(AV40GXV6));
               cmbavMenusid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV15Menu.gxTpr_Id), 12, 0)), AV15Menu.gxTpr_Name, 0);
               AV40GXV6 = (int)(AV40GXV6+1);
            }
         }
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV24Type, "M") == 0 ) ) )
         {
            cmbavMenusid.Visible = 0;
            AssignProp("", false, cmbavMenusid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMenusid.Visible), 5, 0), true);
            divMenusid_cell_Class = "Invisible";
            AssignProp("", false, divMenusid_cell_Internalname, "Class", divMenusid_cell_Class, true);
         }
         else
         {
            cmbavMenusid.Visible = 1;
            AssignProp("", false, cmbavMenusid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavMenusid.Visible), 5, 0), true);
            divMenusid_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divMenusid_cell_Internalname, "Class", divMenusid_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV24Type, "S") == 0 ) ) )
         {
            cmbavRelresid.Visible = 0;
            AssignProp("", false, cmbavRelresid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavRelresid.Visible), 5, 0), true);
            divRelresid_cell_Class = "Invisible";
            AssignProp("", false, divRelresid_cell_Internalname, "Class", divRelresid_cell_Class, true);
         }
         else
         {
            cmbavRelresid.Visible = 1;
            AssignProp("", false, cmbavRelresid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavRelresid.Visible), 5, 0), true);
            divRelresid_cell_Class = "col-xs-12 col-sm-6 DataContentCell DscTop";
            AssignProp("", false, divRelresid_cell_Internalname, "Class", divRelresid_cell_Class, true);
         }
      }

      protected void E12202( )
      {
         /* Type_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV24Type, "S") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21RelResId)) )
            {
               AV5GAMApplication.load( AV7ApplicationId);
               AV42GXV8 = 1;
               AV41GXV7 = AV5GAMApplication.getpermissions(AV20PermissionFilter, out  AV12Errors);
               while ( AV42GXV8 <= AV41GXV7.Count )
               {
                  AV19Permission = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission)AV41GXV7.Item(AV42GXV8));
                  cmbavRelresid.addItem(AV19Permission.gxTpr_Guid, AV19Permission.gxTpr_Name, 0);
                  AV42GXV8 = (int)(AV42GXV8+1);
               }
            }
         }
         else
         {
            if ( (0==AV17MenusId) )
            {
               AV5GAMApplication.load( AV7ApplicationId);
               AV44GXV10 = 1;
               AV43GXV9 = AV5GAMApplication.getsubmenus(AV16MenuId, out  AV12Errors);
               while ( AV44GXV10 <= AV43GXV9.Count )
               {
                  AV15Menu = ((GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu)AV43GXV9.Item(AV44GXV10));
                  cmbavMenusid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV15Menu.gxTpr_Id), 12, 0)), AV15Menu.gxTpr_Name, 0);
                  AV44GXV10 = (int)(AV44GXV10+1);
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5GAMApplication", AV5GAMApplication);
         cmbavRelresid.CurrentValue = StringUtil.RTrim( AV21RelResId);
         AssignProp("", false, cmbavRelresid_Internalname, "Values", cmbavRelresid.ToJavascriptSource(), true);
         cmbavMenusid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17MenusId), 12, 0));
         AssignProp("", false, cmbavMenusid_Internalname, "Values", cmbavMenusid.ToJavascriptSource(), true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E13202 ();
         if (returnInSub) return;
      }

      protected void E13202( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV5GAMApplication.load( AV7ApplicationId);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18Name)) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               /* Execute user subroutine: 'LOAD_APPLICATIONMENUOPTION' */
               S122 ();
               if (returnInSub) return;
               AV6isOK = AV5GAMApplication.addmenuoption(AV16MenuId, AV9ApplicationMenuOption, out  AV12Errors);
               AssignAttri("", false, "AV6isOK", AV6isOK);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               AV9ApplicationMenuOption = AV5GAMApplication.getmenuoption(AV16MenuId, AV14Id, out  AV12Errors);
               /* Execute user subroutine: 'LOAD_APPLICATIONMENUOPTION' */
               S122 ();
               if (returnInSub) return;
               AV6isOK = AV5GAMApplication.updatemenuoption(AV16MenuId, AV9ApplicationMenuOption, out  AV12Errors);
               AssignAttri("", false, "AV6isOK", AV6isOK);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV9ApplicationMenuOption = AV5GAMApplication.getmenuoption(AV16MenuId, AV14Id, out  AV12Errors);
               AV6isOK = AV5GAMApplication.deletemenuoption(AV16MenuId, AV9ApplicationMenuOption, out  AV12Errors);
               AssignAttri("", false, "AV6isOK", AV6isOK);
            }
         }
         else
         {
            AV6isOK = false;
            AssignAttri("", false, "AV6isOK", AV6isOK);
            AV11Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
            AV11Error.gxTpr_Code = 239;
            AV11Error.gxTpr_Message = GeneXus.Programs.genexussecuritycommon.gxdomaingamerrormessages.getDescription(context,AV11Error.gxTpr_Code);
            AV12Errors.Add(AV11Error, 0);
         }
         if ( AV6isOK )
         {
            context.CommitDataStores("gamappmenuoptionentry",pr_default);
            context.setWebReturnParms(new Object[] {(string)Gx_mode,(long)AV7ApplicationId,(long)AV16MenuId,(long)AV14Id});
            context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV7ApplicationId","AV16MenuId","AV14Id"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV45GXV11 = 1;
            while ( AV45GXV11 <= AV12Errors.Count )
            {
               AV11Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(AV45GXV11));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV11Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV11Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV45GXV11 = (int)(AV45GXV11+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5GAMApplication", AV5GAMApplication);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9ApplicationMenuOption", AV9ApplicationMenuOption);
      }

      protected void E14202( )
      {
         /* Relresid_Isvalid Routine */
         returnInSub = false;
         AV5GAMApplication.load( AV7ApplicationId);
         AV19Permission = AV5GAMApplication.getpermissionbyguid(AV21RelResId, out  AV12Errors);
         AV22Resource = AV19Permission.gxTpr_Resource;
         AssignAttri("", false, "AV22Resource", AV22Resource);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5GAMApplication", AV5GAMApplication);
      }

      protected void S122( )
      {
         /* 'LOAD_APPLICATIONMENUOPTION' Routine */
         returnInSub = false;
         AV9ApplicationMenuOption.gxTpr_Guid = AV13GUID;
         AV9ApplicationMenuOption.gxTpr_Name = AV18Name;
         AV9ApplicationMenuOption.gxTpr_Description = AV10Dsc;
         AV9ApplicationMenuOption.gxTpr_Type = AV24Type;
         AV9ApplicationMenuOption.gxTpr_Submenuid = AV17MenusId;
         AV9ApplicationMenuOption.gxTpr_Permissionresourceguid = AV21RelResId;
         AV9ApplicationMenuOption.gxTpr_Resource = AV22Resource;
         AV9ApplicationMenuOption.gxTpr_Resourceparameters = AV23ResourceParameters;
         AV33GAMPropertyCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty>( context, "GeneXus.Programs.genexussecurity.SdtGAMProperty", "GeneXus.Programs");
         AV32GAMProperty = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         AV32GAMProperty.gxTpr_Id = "IconClass";
         AV32GAMProperty.gxTpr_Value = AV30IconClass;
         AV33GAMPropertyCollection.Add(AV32GAMProperty, 0);
         AV32GAMProperty = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         AV32GAMProperty.gxTpr_Id = "Link";
         AV32GAMProperty.gxTpr_Value = AV31Link;
         AV33GAMPropertyCollection.Add(AV32GAMProperty, 0);
         AV9ApplicationMenuOption.gxTpr_Properties = AV33GAMPropertyCollection;
      }

      protected void nextLoad( )
      {
      }

      protected void E15202( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV7ApplicationId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV7ApplicationId", StringUtil.LTrimStr( (decimal)(AV7ApplicationId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ApplicationId), "ZZZZZZZZZZZ9"), context));
         AV16MenuId = Convert.ToInt64(getParm(obj,2));
         AssignAttri("", false, "AV16MenuId", StringUtil.LTrimStr( (decimal)(AV16MenuId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16MenuId), "ZZZZZZZZZZZ9"), context));
         AV14Id = Convert.ToInt64(getParm(obj,3));
         AssignAttri("", false, "AV14Id", StringUtil.LTrimStr( (decimal)(AV14Id), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14Id), "ZZZZZZZZZZZ9"), context));
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
         PA202( ) ;
         WS202( ) ;
         WE202( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257120103695", true, true);
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
         context.AddJavascriptSource("gamappmenuoptionentry.js", "?20257120103696", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavType.Name = "vTYPE";
         cmbavType.WebTags = "";
         cmbavType.addItem("S", "Simple", 0);
         cmbavType.addItem("M", "Menu", 0);
         if ( cmbavType.ItemCount > 0 )
         {
            AV24Type = cmbavType.getValidValue(AV24Type);
            AssignAttri("", false, "AV24Type", AV24Type);
         }
         cmbavMenusid.Name = "vMENUSID";
         cmbavMenusid.WebTags = "";
         if ( cmbavMenusid.ItemCount > 0 )
         {
            AV17MenusId = (long)(Math.Round(NumberUtil.Val( cmbavMenusid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17MenusId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17MenusId", StringUtil.LTrimStr( (decimal)(AV17MenusId), 12, 0));
         }
         cmbavRelresid.Name = "vRELRESID";
         cmbavRelresid.WebTags = "";
         if ( cmbavRelresid.ItemCount > 0 )
         {
            AV21RelResId = cmbavRelresid.getValidValue(AV21RelResId);
            AssignAttri("", false, "AV21RelResId", AV21RelResId);
         }
         cmbavLink.Name = "vLINK";
         cmbavLink.WebTags = "";
         cmbavLink.addItem("", "", 0);
         cmbavLink.addItem("_blank", "Blank", 0);
         if ( cmbavLink.ItemCount > 0 )
         {
            AV31Link = cmbavLink.getValidValue(AV31Link);
            AssignAttri("", false, "AV31Link", AV31Link);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtavGamapplication_name_Internalname = "GAMAPPLICATION_NAME";
         edtavApplicationmenu_name_Internalname = "APPLICATIONMENU_NAME";
         edtavGuid_Internalname = "vGUID";
         edtavName_Internalname = "vNAME";
         edtavDsc_Internalname = "vDSC";
         cmbavType_Internalname = "vTYPE";
         cmbavMenusid_Internalname = "vMENUSID";
         divMenusid_cell_Internalname = "MENUSID_CELL";
         cmbavRelresid_Internalname = "vRELRESID";
         divRelresid_cell_Internalname = "RELRESID_CELL";
         edtavResource_Internalname = "vRESOURCE";
         edtavResourceparameters_Internalname = "vRESOURCEPARAMETERS";
         edtavIconclass_Internalname = "vICONCLASS";
         cmbavLink_Internalname = "vLINK";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
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
         edtavApplicationmenu_name_Enabled = -1;
         edtavGamapplication_name_Enabled = -1;
         bttBtnenter_Caption = "Confirm";
         bttBtnenter_Visible = 1;
         cmbavLink_Jsonclick = "";
         cmbavLink.Enabled = 1;
         edtavIconclass_Jsonclick = "";
         edtavIconclass_Enabled = 1;
         edtavResourceparameters_Jsonclick = "";
         edtavResourceparameters_Enabled = 1;
         edtavResource_Jsonclick = "";
         edtavResource_Enabled = 1;
         cmbavRelresid_Jsonclick = "";
         cmbavRelresid.Enabled = 1;
         cmbavRelresid.Visible = 1;
         divRelresid_cell_Class = "col-xs-12 col-sm-6";
         cmbavMenusid_Jsonclick = "";
         cmbavMenusid.Enabled = 1;
         cmbavMenusid.Visible = 1;
         divMenusid_cell_Class = "col-xs-12 col-sm-6";
         cmbavType_Jsonclick = "";
         cmbavType.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavApplicationmenu_name_Enabled = 0;
         edtavGamapplication_name_Enabled = 0;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Menu Option";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV16MenuId","fld":"vMENUID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV14Id","fld":"vID","pic":"ZZZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("VTYPE.CLICK","""{"handler":"E12202","iparms":[{"av":"cmbavType"},{"av":"AV24Type","fld":"vTYPE"},{"av":"cmbavRelresid"},{"av":"AV21RelResId","fld":"vRELRESID"},{"av":"AV7ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"cmbavMenusid"},{"av":"AV17MenusId","fld":"vMENUSID","pic":"ZZZZZZZZZZZ9"},{"av":"AV16MenuId","fld":"vMENUID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("VTYPE.CLICK",""","oparms":[{"av":"cmbavRelresid"},{"av":"AV21RelResId","fld":"vRELRESID"},{"av":"cmbavMenusid"},{"av":"AV17MenusId","fld":"vMENUSID","pic":"ZZZZZZZZZZZ9"},{"av":"divMenusid_cell_Class","ctrl":"MENUSID_CELL","prop":"Class"},{"av":"divRelresid_cell_Class","ctrl":"RELRESID_CELL","prop":"Class"}]}""");
         setEventMetadata("ENTER","""{"handler":"E13202","iparms":[{"av":"AV7ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV18Name","fld":"vNAME"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV16MenuId","fld":"vMENUID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV14Id","fld":"vID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV6isOK","fld":"vISOK"},{"av":"AV13GUID","fld":"vGUID"},{"av":"AV10Dsc","fld":"vDSC"},{"av":"cmbavType"},{"av":"AV24Type","fld":"vTYPE"},{"av":"cmbavMenusid"},{"av":"AV17MenusId","fld":"vMENUSID","pic":"ZZZZZZZZZZZ9"},{"av":"cmbavRelresid"},{"av":"AV21RelResId","fld":"vRELRESID"},{"av":"AV22Resource","fld":"vRESOURCE"},{"av":"AV23ResourceParameters","fld":"vRESOURCEPARAMETERS"},{"av":"AV30IconClass","fld":"vICONCLASS"},{"av":"cmbavLink"},{"av":"AV31Link","fld":"vLINK"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV6isOK","fld":"vISOK"}]}""");
         setEventMetadata("VRELRESID.ISVALID","""{"handler":"E14202","iparms":[{"av":"AV7ApplicationId","fld":"vAPPLICATIONID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"cmbavRelresid"},{"av":"AV21RelResId","fld":"vRELRESID"}]""");
         setEventMetadata("VRELRESID.ISVALID",""","oparms":[{"av":"AV22Resource","fld":"vRESOURCE"}]}""");
         setEventMetadata("VALIDV_TYPE","""{"handler":"Validv_Type","iparms":[]}""");
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
         wcpOGx_mode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV5GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV8ApplicationMenu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV13GUID = "";
         AV18Name = "";
         AV10Dsc = "";
         AV24Type = "";
         AV21RelResId = "";
         AV22Resource = "";
         AV23ResourceParameters = "";
         AV30IconClass = "";
         AV31Link = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV12Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9ApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         AV37GXV3 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission", "GeneXus.Programs");
         AV20PermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter(context);
         AV19Permission = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission(context);
         AV39GXV5 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu", "GeneXus.Programs");
         AV15Menu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV41GXV7 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission", "GeneXus.Programs");
         AV43GXV9 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu", "GeneXus.Programs");
         AV11Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV33GAMPropertyCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty>( context, "GeneXus.Programs.genexussecurity.SdtGAMProperty", "GeneXus.Programs");
         AV32GAMProperty = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamappmenuoptionentry__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamappmenuoptionentry__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         edtavGamapplication_name_Enabled = 0;
         edtavApplicationmenu_name_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavGamapplication_name_Enabled ;
      private int edtavApplicationmenu_name_Enabled ;
      private int edtavGuid_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavResource_Enabled ;
      private int edtavResourceparameters_Enabled ;
      private int edtavIconclass_Enabled ;
      private int bttBtnenter_Visible ;
      private int AV38GXV4 ;
      private int AV40GXV6 ;
      private int AV42GXV8 ;
      private int AV44GXV10 ;
      private int AV45GXV11 ;
      private int idxLst ;
      private long AV7ApplicationId ;
      private long AV16MenuId ;
      private long AV14Id ;
      private long wcpOAV7ApplicationId ;
      private long wcpOAV16MenuId ;
      private long wcpOAV14Id ;
      private long AV17MenusId ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divLefttable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavGamapplication_name_Internalname ;
      private string TempTags ;
      private string edtavApplicationmenu_name_Internalname ;
      private string edtavGuid_Internalname ;
      private string AV13GUID ;
      private string edtavGuid_Jsonclick ;
      private string edtavName_Internalname ;
      private string AV18Name ;
      private string edtavName_Jsonclick ;
      private string edtavDsc_Internalname ;
      private string AV10Dsc ;
      private string edtavDsc_Jsonclick ;
      private string cmbavType_Internalname ;
      private string AV24Type ;
      private string cmbavType_Jsonclick ;
      private string divMenusid_cell_Internalname ;
      private string divMenusid_cell_Class ;
      private string cmbavMenusid_Internalname ;
      private string cmbavMenusid_Jsonclick ;
      private string divRelresid_cell_Internalname ;
      private string divRelresid_cell_Class ;
      private string cmbavRelresid_Internalname ;
      private string AV21RelResId ;
      private string cmbavRelresid_Jsonclick ;
      private string edtavResource_Internalname ;
      private string edtavResource_Jsonclick ;
      private string edtavResourceparameters_Internalname ;
      private string edtavResourceparameters_Jsonclick ;
      private string edtavIconclass_Internalname ;
      private string edtavIconclass_Jsonclick ;
      private string cmbavLink_Internalname ;
      private string cmbavLink_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divRighttable_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV6isOK ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV22Resource ;
      private string AV23ResourceParameters ;
      private string AV30IconClass ;
      private string AV31Link ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private long aP1_ApplicationId ;
      private long aP2_MenuId ;
      private long aP3_Id ;
      private GXCombobox cmbavType ;
      private GXCombobox cmbavMenusid ;
      private GXCombobox cmbavRelresid ;
      private GXCombobox cmbavLink ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV5GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV8ApplicationMenu ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV9ApplicationMenuOption ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission> AV37GXV3 ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermissionFilter AV20PermissionFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission AV19Permission ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu> AV39GXV5 ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV15Menu ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission> AV41GXV7 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu> AV43GXV9 ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV11Error ;
      private IDataStoreProvider pr_default ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMProperty> AV33GAMPropertyCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMProperty AV32GAMProperty ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamappmenuoptionentry__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamappmenuoptionentry__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
