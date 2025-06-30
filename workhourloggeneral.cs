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
   public class workhourloggeneral : GXWebComponent
   {
      public workhourloggeneral( )
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

      public workhourloggeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WorkHourLogId )
      {
         this.A118WorkHourLogId = aP0_WorkHourLogId;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WorkHourLogId");
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
                  A118WorkHourLogId = (long)(Math.Round(NumberUtil.Val( GetPar( "WorkHourLogId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A118WorkHourLogId});
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
                  gxfirstwebparm = GetFirstPar( "WorkHourLogId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WorkHourLogId");
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
            PA372( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV15Pgmname = "WorkHourLogGeneral";
               WS372( ) ;
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
            context.SendWebValue( "Work Hour Log General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workhourloggeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A118WorkHourLogId,10,0))}, new string[] {"WorkHourLogId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA118WorkHourLogId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA118WorkHourLogId), 10, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm372( )
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
         return "WorkHourLogGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Work Hour Log General" ;
      }

      protected void WB370( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workhourloggeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWorkHourLogId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWorkHourLogId_Internalname, "Log Id", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWorkHourLogId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWorkHourLogId_Enabled!=0) ? context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkHourLogId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWorkHourLogId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_WorkHourLogGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWorkHourLogDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWorkHourLogDate_Internalname, "Log Date", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtWorkHourLogDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtWorkHourLogDate_Internalname, context.localUtil.Format(A119WorkHourLogDate, "99/99/99"), context.localUtil.Format( A119WorkHourLogDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkHourLogDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWorkHourLogDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkHourLogGeneral.htm");
            GxWebStd.gx_bitmap( context, edtWorkHourLogDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWorkHourLogDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkHourLogGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWorkHourLogDuration_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWorkHourLogDuration_Internalname, "Log Duration", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWorkHourLogDuration_Internalname, A120WorkHourLogDuration, StringUtil.RTrim( context.localUtil.Format( A120WorkHourLogDuration, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkHourLogDuration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWorkHourLogDuration_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkHourLogGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWorkHourLogHour_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWorkHourLogHour_Internalname, "Log Hour", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWorkHourLogHour_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", "")), StringUtil.LTrim( ((edtWorkHourLogHour_Enabled!=0) ? context.localUtil.Format( (decimal)(A121WorkHourLogHour), "ZZZ9") : context.localUtil.Format( (decimal)(A121WorkHourLogHour), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,27);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkHourLogHour_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWorkHourLogHour_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkHourLogGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWorkHourLogMinute_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWorkHourLogMinute_Internalname, "Log Minute", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtWorkHourLogMinute_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", "")), StringUtil.LTrim( ((edtWorkHourLogMinute_Enabled!=0) ? context.localUtil.Format( (decimal)(A122WorkHourLogMinute), "ZZZ9") : context.localUtil.Format( (decimal)(A122WorkHourLogMinute), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,32);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkHourLogMinute_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWorkHourLogMinute_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkHourLogGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWorkHourLogDescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWorkHourLogDescription_Internalname, "Log Description", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtWorkHourLogDescription_Internalname, A123WorkHourLogDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", 0, 1, edtWorkHourLogDescription_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkHourLogGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeFirstName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEmployeeFirstName_Internalname, "Employees", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmployeeFirstName_Internalname, StringUtil.RTrim( A107EmployeeFirstName), StringUtil.RTrim( context.localUtil.Format( A107EmployeeFirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeFirstName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeFirstName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_WorkHourLogGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeIsActiveInProject_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEmployeeIsActiveInProject_Internalname, "Employees", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEmployeeIsActiveInProject_Internalname, StringUtil.BoolToStr( A184EmployeeIsActiveInProject), StringUtil.BoolToStr( A184EmployeeIsActiveInProject), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeIsActiveInProject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeIsActiveInProject_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_WorkHourLogGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProjectName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProjectName_Internalname, "Project Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtProjectName_Internalname, StringUtil.RTrim( A103ProjectName), StringUtil.RTrim( context.localUtil.Format( A103ProjectName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProjectName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProjectName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_WorkHourLogGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11371_client"+"'", TempTags, "", 2, "HLP_WorkHourLogGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e12371_client"+"'", TempTags, "", 2, "HLP_WorkHourLogGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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

      protected void START372( )
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
            Form.Meta.addItem("description", "Work Hour Log General", 0) ;
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
               STRUP370( ) ;
            }
         }
      }

      protected void WS372( )
      {
         START372( ) ;
         EVT372( ) ;
      }

      protected void EVT372( )
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
                                 STRUP370( ) ;
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
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13372 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14372 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP370( ) ;
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
                                 STRUP370( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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

      protected void WE372( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm372( ) ;
            }
         }
      }

      protected void PA372( )
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF372( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV15Pgmname = "WorkHourLogGeneral";
      }

      protected void RF372( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00372 */
            pr_default.execute(0, new Object[] {A118WorkHourLogId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A106EmployeeId = H00372_A106EmployeeId[0];
               A102ProjectId = H00372_A102ProjectId[0];
               A162ProjectManagerId = H00372_A162ProjectManagerId[0];
               n162ProjectManagerId = H00372_n162ProjectManagerId[0];
               A103ProjectName = H00372_A103ProjectName[0];
               AssignAttri(sPrefix, false, "A103ProjectName", A103ProjectName);
               A184EmployeeIsActiveInProject = H00372_A184EmployeeIsActiveInProject[0];
               AssignAttri(sPrefix, false, "A184EmployeeIsActiveInProject", A184EmployeeIsActiveInProject);
               A107EmployeeFirstName = H00372_A107EmployeeFirstName[0];
               AssignAttri(sPrefix, false, "A107EmployeeFirstName", A107EmployeeFirstName);
               A123WorkHourLogDescription = H00372_A123WorkHourLogDescription[0];
               AssignAttri(sPrefix, false, "A123WorkHourLogDescription", A123WorkHourLogDescription);
               A122WorkHourLogMinute = H00372_A122WorkHourLogMinute[0];
               AssignAttri(sPrefix, false, "A122WorkHourLogMinute", StringUtil.LTrimStr( (decimal)(A122WorkHourLogMinute), 4, 0));
               A121WorkHourLogHour = H00372_A121WorkHourLogHour[0];
               AssignAttri(sPrefix, false, "A121WorkHourLogHour", StringUtil.LTrimStr( (decimal)(A121WorkHourLogHour), 4, 0));
               A120WorkHourLogDuration = H00372_A120WorkHourLogDuration[0];
               AssignAttri(sPrefix, false, "A120WorkHourLogDuration", A120WorkHourLogDuration);
               A119WorkHourLogDate = H00372_A119WorkHourLogDate[0];
               AssignAttri(sPrefix, false, "A119WorkHourLogDate", context.localUtil.Format(A119WorkHourLogDate, "99/99/99"));
               A107EmployeeFirstName = H00372_A107EmployeeFirstName[0];
               AssignAttri(sPrefix, false, "A107EmployeeFirstName", A107EmployeeFirstName);
               A162ProjectManagerId = H00372_A162ProjectManagerId[0];
               n162ProjectManagerId = H00372_n162ProjectManagerId[0];
               A103ProjectName = H00372_A103ProjectName[0];
               AssignAttri(sPrefix, false, "A103ProjectName", A103ProjectName);
               A184EmployeeIsActiveInProject = H00372_A184EmployeeIsActiveInProject[0];
               AssignAttri(sPrefix, false, "A184EmployeeIsActiveInProject", A184EmployeeIsActiveInProject);
               /* Using cursor H00373 */
               pr_default.execute(1, new Object[] {n162ProjectManagerId, A162ProjectManagerId, A102ProjectId});
               A184EmployeeIsActiveInProject = H00373_A184EmployeeIsActiveInProject[0];
               AssignAttri(sPrefix, false, "A184EmployeeIsActiveInProject", A184EmployeeIsActiveInProject);
               pr_default.close(1);
               /* Execute user event: Load */
               E14372 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB370( ) ;
         }
      }

      protected void send_integrity_lvl_hashes372( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV15Pgmname = "WorkHourLogGeneral";
         edtWorkHourLogId_Enabled = 0;
         AssignProp(sPrefix, false, edtWorkHourLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogId_Enabled), 5, 0), true);
         edtWorkHourLogDate_Enabled = 0;
         AssignProp(sPrefix, false, edtWorkHourLogDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDate_Enabled), 5, 0), true);
         edtWorkHourLogDuration_Enabled = 0;
         AssignProp(sPrefix, false, edtWorkHourLogDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDuration_Enabled), 5, 0), true);
         edtWorkHourLogHour_Enabled = 0;
         AssignProp(sPrefix, false, edtWorkHourLogHour_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogHour_Enabled), 5, 0), true);
         edtWorkHourLogMinute_Enabled = 0;
         AssignProp(sPrefix, false, edtWorkHourLogMinute_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogMinute_Enabled), 5, 0), true);
         edtWorkHourLogDescription_Enabled = 0;
         AssignProp(sPrefix, false, edtWorkHourLogDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDescription_Enabled), 5, 0), true);
         edtEmployeeFirstName_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeFirstName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeFirstName_Enabled), 5, 0), true);
         edtEmployeeIsActiveInProject_Enabled = 0;
         AssignProp(sPrefix, false, edtEmployeeIsActiveInProject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeIsActiveInProject_Enabled), 5, 0), true);
         edtProjectName_Enabled = 0;
         AssignProp(sPrefix, false, edtProjectName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectName_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP370( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13372 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA118WorkHourLogId"), ".", ","), 18, MidpointRounding.ToEven));
            AV13IsAuthorized_Delete = StringUtil.StrToBool( cgiGet( sPrefix+"vISAUTHORIZED_DELETE"));
            AV12IsAuthorized_Update = StringUtil.StrToBool( cgiGet( sPrefix+"vISAUTHORIZED_UPDATE"));
            /* Read variables values. */
            A119WorkHourLogDate = context.localUtil.CToD( cgiGet( edtWorkHourLogDate_Internalname), 2);
            AssignAttri(sPrefix, false, "A119WorkHourLogDate", context.localUtil.Format(A119WorkHourLogDate, "99/99/99"));
            A120WorkHourLogDuration = cgiGet( edtWorkHourLogDuration_Internalname);
            AssignAttri(sPrefix, false, "A120WorkHourLogDuration", A120WorkHourLogDuration);
            A121WorkHourLogHour = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogHour_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A121WorkHourLogHour", StringUtil.LTrimStr( (decimal)(A121WorkHourLogHour), 4, 0));
            A122WorkHourLogMinute = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogMinute_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A122WorkHourLogMinute", StringUtil.LTrimStr( (decimal)(A122WorkHourLogMinute), 4, 0));
            A123WorkHourLogDescription = cgiGet( edtWorkHourLogDescription_Internalname);
            AssignAttri(sPrefix, false, "A123WorkHourLogDescription", A123WorkHourLogDescription);
            A107EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
            AssignAttri(sPrefix, false, "A107EmployeeFirstName", A107EmployeeFirstName);
            A184EmployeeIsActiveInProject = StringUtil.StrToBool( cgiGet( edtEmployeeIsActiveInProject_Internalname));
            AssignAttri(sPrefix, false, "A184EmployeeIsActiveInProject", A184EmployeeIsActiveInProject);
            A103ProjectName = cgiGet( edtProjectName_Internalname);
            AssignAttri(sPrefix, false, "A103ProjectName", A103ProjectName);
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
         E13372 ();
         if ( returnInSub )
         {
            pr_default.close(1);
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13372( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            pr_default.close(1);
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E14372( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "workhourlog_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "workhourlog_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV15Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "WorkHourLog";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A118WorkHourLogId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
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
         PA372( ) ;
         WS372( ) ;
         WE372( ) ;
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
         sCtrlA118WorkHourLogId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA372( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workhourloggeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA372( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A118WorkHourLogId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
         }
         wcpOA118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA118WorkHourLogId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A118WorkHourLogId != wcpOA118WorkHourLogId ) ) )
         {
            setjustcreated();
         }
         wcpOA118WorkHourLogId = A118WorkHourLogId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA118WorkHourLogId = cgiGet( sPrefix+"A118WorkHourLogId_CTRL");
         if ( StringUtil.Len( sCtrlA118WorkHourLogId) > 0 )
         {
            A118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA118WorkHourLogId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
         }
         else
         {
            A118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A118WorkHourLogId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA372( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS372( ) ;
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
         WS372( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A118WorkHourLogId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA118WorkHourLogId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A118WorkHourLogId_CTRL", StringUtil.RTrim( sCtrlA118WorkHourLogId));
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
         WE372( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025627523256", true, true);
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
         context.AddJavascriptSource("workhourloggeneral.js", "?2025627523256", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtWorkHourLogId_Internalname = sPrefix+"WORKHOURLOGID";
         edtWorkHourLogDate_Internalname = sPrefix+"WORKHOURLOGDATE";
         edtWorkHourLogDuration_Internalname = sPrefix+"WORKHOURLOGDURATION";
         edtWorkHourLogHour_Internalname = sPrefix+"WORKHOURLOGHOUR";
         edtWorkHourLogMinute_Internalname = sPrefix+"WORKHOURLOGMINUTE";
         edtWorkHourLogDescription_Internalname = sPrefix+"WORKHOURLOGDESCRIPTION";
         edtEmployeeFirstName_Internalname = sPrefix+"EMPLOYEEFIRSTNAME";
         edtEmployeeIsActiveInProject_Internalname = sPrefix+"EMPLOYEEISACTIVEINPROJECT";
         edtProjectName_Internalname = sPrefix+"PROJECTNAME";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
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
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtProjectName_Jsonclick = "";
         edtProjectName_Enabled = 0;
         edtEmployeeIsActiveInProject_Jsonclick = "";
         edtEmployeeIsActiveInProject_Enabled = 0;
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeFirstName_Enabled = 0;
         edtWorkHourLogDescription_Enabled = 0;
         edtWorkHourLogMinute_Jsonclick = "";
         edtWorkHourLogMinute_Enabled = 0;
         edtWorkHourLogHour_Jsonclick = "";
         edtWorkHourLogHour_Enabled = 0;
         edtWorkHourLogDuration_Jsonclick = "";
         edtWorkHourLogDuration_Enabled = 0;
         edtWorkHourLogDate_Jsonclick = "";
         edtWorkHourLogDate_Enabled = 0;
         edtWorkHourLogId_Jsonclick = "";
         edtWorkHourLogId_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A118WorkHourLogId","fld":"WORKHOURLOGID","pic":"ZZZZZZZZZ9"},{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E11371","iparms":[{"av":"AV12IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A118WorkHourLogId","fld":"WORKHOURLOGID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("'DOUPDATE'",""","oparms":[{"ctrl":"BTNUPDATE","prop":"Visible"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E12371","iparms":[{"av":"AV13IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"A118WorkHourLogId","fld":"WORKHOURLOGID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("'DODELETE'",""","oparms":[{"ctrl":"BTNDELETE","prop":"Visible"}]}""");
         setEventMetadata("VALID_WORKHOURLOGID","""{"handler":"Valid_Workhourlogid","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         A119WorkHourLogDate = DateTime.MinValue;
         A120WorkHourLogDuration = "";
         ClassString = "";
         StyleString = "";
         A123WorkHourLogDescription = "";
         A107EmployeeFirstName = "";
         A103ProjectName = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H00372_A106EmployeeId = new long[1] ;
         H00372_A102ProjectId = new long[1] ;
         H00372_A162ProjectManagerId = new long[1] ;
         H00372_n162ProjectManagerId = new bool[] {false} ;
         H00372_A118WorkHourLogId = new long[1] ;
         H00372_A103ProjectName = new string[] {""} ;
         H00372_A184EmployeeIsActiveInProject = new bool[] {false} ;
         H00372_A107EmployeeFirstName = new string[] {""} ;
         H00372_A123WorkHourLogDescription = new string[] {""} ;
         H00372_A122WorkHourLogMinute = new short[1] ;
         H00372_A121WorkHourLogHour = new short[1] ;
         H00372_A120WorkHourLogDuration = new string[] {""} ;
         H00372_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         H00373_A184EmployeeIsActiveInProject = new bool[] {false} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA118WorkHourLogId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourloggeneral__default(),
            new Object[][] {
                new Object[] {
               H00372_A106EmployeeId, H00372_A102ProjectId, H00372_A162ProjectManagerId, H00372_n162ProjectManagerId, H00372_A118WorkHourLogId, H00372_A103ProjectName, H00372_A184EmployeeIsActiveInProject, H00372_A107EmployeeFirstName, H00372_A123WorkHourLogDescription, H00372_A122WorkHourLogMinute,
               H00372_A121WorkHourLogHour, H00372_A120WorkHourLogDuration, H00372_A119WorkHourLogDate
               }
               , new Object[] {
               H00373_A184EmployeeIsActiveInProject
               }
            }
         );
         AV15Pgmname = "WorkHourLogGeneral";
         /* GeneXus formulas. */
         AV15Pgmname = "WorkHourLogGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtWorkHourLogId_Enabled ;
      private int edtWorkHourLogDate_Enabled ;
      private int edtWorkHourLogDuration_Enabled ;
      private int edtWorkHourLogHour_Enabled ;
      private int edtWorkHourLogMinute_Enabled ;
      private int edtWorkHourLogDescription_Enabled ;
      private int edtEmployeeFirstName_Enabled ;
      private int edtEmployeeIsActiveInProject_Enabled ;
      private int edtProjectName_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int idxLst ;
      private long A118WorkHourLogId ;
      private long wcpOA118WorkHourLogId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A162ProjectManagerId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV15Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtWorkHourLogId_Internalname ;
      private string TempTags ;
      private string edtWorkHourLogId_Jsonclick ;
      private string edtWorkHourLogDate_Internalname ;
      private string edtWorkHourLogDate_Jsonclick ;
      private string edtWorkHourLogDuration_Internalname ;
      private string edtWorkHourLogDuration_Jsonclick ;
      private string edtWorkHourLogHour_Internalname ;
      private string edtWorkHourLogHour_Jsonclick ;
      private string edtWorkHourLogMinute_Internalname ;
      private string edtWorkHourLogMinute_Jsonclick ;
      private string edtWorkHourLogDescription_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string edtEmployeeFirstName_Internalname ;
      private string A107EmployeeFirstName ;
      private string edtEmployeeFirstName_Jsonclick ;
      private string edtEmployeeIsActiveInProject_Internalname ;
      private string edtEmployeeIsActiveInProject_Jsonclick ;
      private string edtProjectName_Internalname ;
      private string A103ProjectName ;
      private string edtProjectName_Jsonclick ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlA118WorkHourLogId ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool A184EmployeeIsActiveInProject ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n162ProjectManagerId ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A123WorkHourLogDescription ;
      private string A120WorkHourLogDuration ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H00372_A106EmployeeId ;
      private long[] H00372_A102ProjectId ;
      private long[] H00372_A162ProjectManagerId ;
      private bool[] H00372_n162ProjectManagerId ;
      private long[] H00372_A118WorkHourLogId ;
      private string[] H00372_A103ProjectName ;
      private bool[] H00372_A184EmployeeIsActiveInProject ;
      private string[] H00372_A107EmployeeFirstName ;
      private string[] H00372_A123WorkHourLogDescription ;
      private short[] H00372_A122WorkHourLogMinute ;
      private short[] H00372_A121WorkHourLogHour ;
      private string[] H00372_A120WorkHourLogDuration ;
      private DateTime[] H00372_A119WorkHourLogDate ;
      private bool[] H00373_A184EmployeeIsActiveInProject ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class workhourloggeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00372;
          prmH00372 = new Object[] {
          new ParDef("WorkHourLogId",GXType.Int64,10,0)
          };
          Object[] prmH00373;
          prmH00373 = new Object[] {
          new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("ProjectId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00372", "SELECT T1.EmployeeId, T1.ProjectId, T3.ProjectManagerId, T1.WorkHourLogId, T3.ProjectName, T4.EmployeeIsActiveInProject, T2.EmployeeFirstName, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDuration, T1.WorkHourLogDate FROM (((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId) INNER JOIN EmployeeProject T4 ON T4.EmployeeId = T1.EmployeeId AND T4.ProjectId = T1.ProjectId) WHERE T1.WorkHourLogId = :WorkHourLogId ORDER BY T1.WorkHourLogId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00372,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00373", "SELECT EmployeeIsActiveInProject FROM EmployeeProject WHERE EmployeeId = :ProjectManagerId AND ProjectId = :ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00373,1, GxCacheFrequency.OFF ,true,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((bool[]) buf[6])[0] = rslt.getBool(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                return;
       }
    }

 }

}
