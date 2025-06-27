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
   public class wc_leavedetails : GXWebComponent
   {
      public wc_leavedetails( )
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

      public wc_leavedetails( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_TrnMode ,
                           ref long aP1_LeaveRequestId )
      {
         this.AV21TrnMode = aP0_TrnMode;
         this.AV12LeaveRequestId = aP1_LeaveRequestId;
         ExecuteImpl();
         aP0_TrnMode=this.AV21TrnMode;
         aP1_LeaveRequestId=this.AV12LeaveRequestId;
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
         dynavLeaverequest_leavetypeid = new GXCombobox();
         radavLeaverequest_leaverequesthalfday = new GXRadio();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "TrnMode");
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
                  AV21TrnMode = GetPar( "TrnMode");
                  AssignAttri(sPrefix, false, "AV21TrnMode", AV21TrnMode);
                  AV12LeaveRequestId = (long)(Math.Round(NumberUtil.Val( GetPar( "LeaveRequestId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV12LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV12LeaveRequestId), 10, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV21TrnMode,(long)AV12LeaveRequestId});
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
                  gxfirstwebparm = GetFirstPar( "TrnMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "TrnMode");
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
            PA5L2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               Gx_date = DateTimeUtil.Today( context);
               edtavLeaverequest_employeename_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
               dynavLeaverequest_leavetypeid.Enabled = 0;
               AssignProp(sPrefix, false, dynavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_leavetypeid.Enabled), 5, 0), true);
               edtavDeductfromvacationdaysvariable_Enabled = 0;
               AssignProp(sPrefix, false, edtavDeductfromvacationdaysvariable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeductfromvacationdaysvariable_Enabled), 5, 0), true);
               edtavLeaverequest_employeebalance_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
               edtavLeaverequest_leaverequeststartdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
               edtavLeaverequest_leaverequestenddate_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
               radavLeaverequest_leaverequesthalfday.Enabled = 0;
               AssignProp(sPrefix, false, radavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leaverequesthalfday.Enabled), 5, 0), true);
               edtavLeaverequest_leaverequestduration_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
               edtavLeaverequest_leaverequestdescription_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
               edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
               AssignProp(sPrefix, false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
               WS5L2( ) ;
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
            context.SendWebValue( "WC_Leave Details") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wc_leavedetails.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21TrnMode)),UrlEncode(StringUtil.LTrimStr(AV12LeaveRequestId,10,0))}, new string[] {"TrnMode","LeaveRequestId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Leaverequest", AV11LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Leaverequest", AV11LeaveRequest);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV21TrnMode", StringUtil.RTrim( wcpOAV21TrnMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV12LeaveRequestId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV12LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLEAVEREQUESTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12LeaveRequestId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTRNMODE", StringUtil.RTrim( AV21TrnMode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vLEAVEREQUEST", AV11LeaveRequest);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vLEAVEREQUEST", AV11LeaveRequest);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vLEAVEREQUEST_Leavetypeid", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11LeaveRequest.gxTpr_Leavetypeid), 10, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm5L2( )
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
         return "WC_LeaveDetails" ;
      }

      public override string GetPgmdesc( )
      {
         return "WC_Leave Details" ;
      }

      protected void WB5L0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wc_leavedetails.aspx");
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 hidden-sm", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableleft_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecenter_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableeditaction_Internalname, divTableeditaction_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_employeename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_employeename_Internalname, "Employee Name", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeename_Internalname, StringUtil.RTrim( AV11LeaveRequest.gxTpr_Employeename), StringUtil.RTrim( context.localUtil.Format( AV11LeaveRequest.gxTpr_Employeename, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeename_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeename_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavLeaverequest_leavetypeid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLeaverequest_leavetypeid_Internalname, "Leave Type Id", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLeaverequest_leavetypeid, dynavLeaverequest_leavetypeid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV11LeaveRequest.gxTpr_Leavetypeid), 10, 0)), 1, dynavLeaverequest_leavetypeid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavLeaverequest_leavetypeid.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_WC_LeaveDetails.htm");
            dynavLeaverequest_leavetypeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11LeaveRequest.gxTpr_Leavetypeid), 10, 0));
            AssignProp(sPrefix, false, dynavLeaverequest_leavetypeid_Internalname, "Values", (string)(dynavLeaverequest_leavetypeid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDeductfromvacationdaysvariable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDeductfromvacationdaysvariable_Internalname, "Deduct from vacation days", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDeductfromvacationdaysvariable_Internalname, StringUtil.RTrim( AV7DeductFromVacationDaysVariable), StringUtil.RTrim( context.localUtil.Format( AV7DeductFromVacationDaysVariable, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDeductfromvacationdaysvariable_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDeductfromvacationdaysvariable_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_employeebalance_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_employeebalance_Internalname, "Vacation Days", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_employeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11LeaveRequest.gxTpr_Employeebalance, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_employeebalance_Enabled!=0) ? context.localUtil.Format( AV11LeaveRequest.gxTpr_Employeebalance, "Z9.9") : context.localUtil.Format( AV11LeaveRequest.gxTpr_Employeebalance, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_employeebalance_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_employeebalance_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequeststartdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequeststartdate_Internalname, "Start Date", "col-sm-3 AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequeststartdate_Internalname, context.localUtil.Format(AV11LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), context.localUtil.Format( AV11LeaveRequest.gxTpr_Leaverequeststartdate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequeststartdate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequeststartdate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequeststartdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequeststartdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WC_LeaveDetails.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestenddate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestenddate_Internalname, "End Date", "col-sm-3 AttributeDateLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavLeaverequest_leaverequestenddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestenddate_Internalname, context.localUtil.Format(AV11LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), context.localUtil.Format( AV11LeaveRequest.gxTpr_Leaverequestenddate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,53);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestenddate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavLeaverequest_leaverequestenddate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_bitmap( context, edtavLeaverequest_leaverequestenddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavLeaverequest_leaverequestenddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WC_LeaveDetails.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+radavLeaverequest_leaverequesthalfday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Half Day", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavLeaverequest_leaverequesthalfday, radavLeaverequest_leaverequesthalfday_Internalname, StringUtil.RTrim( AV11LeaveRequest.gxTpr_Leaverequesthalfday), "", 1, radavLeaverequest_leaverequesthalfday.Enabled, 0, 0, StyleString, ClassString, "", "", 0, radavLeaverequest_leaverequesthalfday_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestduration_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestduration_Internalname, "Request Duration", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLeaverequest_leaverequestduration_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11LeaveRequest.gxTpr_Leaverequestduration, 4, 1, ".", "")), StringUtil.LTrim( ((edtavLeaverequest_leaverequestduration_Enabled!=0) ? context.localUtil.Format( AV11LeaveRequest.gxTpr_Leaverequestduration, "Z9.9") : context.localUtil.Format( AV11LeaveRequest.gxTpr_Leaverequestduration, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,62);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLeaverequest_leaverequestduration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLeaverequest_leaverequestduration_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestdescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestdescription_Internalname, "Request Description", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestdescription_Internalname, AV11LeaveRequest.gxTpr_Leaverequestdescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", 0, 1, edtavLeaverequest_leaverequestdescription_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLeaverequest_leaverequestrejectionreason_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLeaverequest_leaverequestrejectionreason_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Rejection Reason", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavLeaverequest_leaverequestrejectionreason_Internalname, AV11LeaveRequest.gxTpr_Leaverequestrejectionreason, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", 0, 1, edtavLeaverequest_leaverequestrejectionreason_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableupdateaction_Internalname, divTableupdateaction_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdatebutton_Internalname, "", "Update", bttBtnupdatebutton_Jsonclick, 5, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATEBUTTON\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancelupdatebutton_Internalname, "", "Cancel", bttBtncancelupdatebutton_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCELUPDATEBUTTON\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableapproveaction_Internalname, divTableapproveaction_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnapprovebutton_Internalname, "", "Approve", bttBtnapprovebutton_Jsonclick, 7, "Approve", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e115l1_client"+"'", TempTags, "", 2, "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnrejectbutton_Internalname, "", "Reject", bttBtnrejectbutton_Jsonclick, 7, "Reject", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e125l1_client"+"'", TempTags, "", 2, "HLP_WC_LeaveDetails.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial RedButton";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndeletebutton_Internalname, "", "Delete", bttBtndeletebutton_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e135l1_client"+"'", TempTags, "", 2, "HLP_WC_LeaveDetails.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 hidden-sm", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableright_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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

      protected void START5L2( )
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
            Form.Meta.addItem("description", "WC_Leave Details", 0) ;
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
               STRUP5L0( ) ;
            }
         }
      }

      protected void WS5L2( )
      {
         START5L2( ) ;
         EVT5L2( ) ;
      }

      protected void EVT5L2( )
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
                                 STRUP5L0( ) ;
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
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E145L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATEBUTTON'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdateButton' */
                                    E155L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCANCELUPDATEBUTTON'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoCancelUpdateButton' */
                                    E165L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUEST_LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Leaverequest_leaverequeststartdate.Controlvaluechanged */
                                    E175L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUEST_LEAVEREQUESTENDDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Leaverequest_leaverequestenddate.Controlvaluechanged */
                                    E185L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUEST_LEAVEREQUESTHALFDAY.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Leaverequest_leaverequesthalfday.Controlvaluechanged */
                                    E195L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LEAVEREQUEST_LEAVETYPEID.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Leaverequest_leavetypeid.Controlvaluechanged */
                                    E205L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E215L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
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
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavLeaverequest_employeename_Internalname;
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

      protected void WE5L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5L2( ) ;
            }
         }
      }

      protected void PA5L2( )
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
               GX_FocusControl = edtavLeaverequest_employeename_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVLEAVEREQUEST_LEAVETYPEID5L1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVLEAVEREQUEST_LEAVETYPEID_data5L1( ) ;
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

      protected void GXVLEAVEREQUEST_LEAVETYPEID_html5L1( )
      {
         long gxdynajaxvalue;
         GXDLVLEAVEREQUEST_LEAVETYPEID_data5L1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLeaverequest_leavetypeid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavLeaverequest_leavetypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
         {
            AV11LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
      }

      protected void GXDLVLEAVEREQUEST_LEAVETYPEID_data5L1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H005L2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005L2_A124LeaveTypeId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H005L2_A125LeaveTypeName[0]));
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
            dynavLeaverequest_leavetypeid.Name = "LEAVEREQUEST_LEAVETYPEID";
            dynavLeaverequest_leavetypeid.WebTags = "";
            dynavLeaverequest_leavetypeid.removeAllItems();
            /* Using cursor H005L3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynavLeaverequest_leavetypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005L3_A124LeaveTypeId[0]), 10, 0)), H005L3_A125LeaveTypeName[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
            {
               AV11LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
         {
            AV11LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( dynavLeaverequest_leavetypeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11LeaveRequest.gxTpr_Leavetypeid), 10, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLeaverequest_leavetypeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11LeaveRequest.gxTpr_Leavetypeid), 10, 0));
            AssignProp(sPrefix, false, dynavLeaverequest_leavetypeid_Internalname, "Values", dynavLeaverequest_leavetypeid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         dynavLeaverequest_leavetypeid.Enabled = 0;
         AssignProp(sPrefix, false, dynavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_leavetypeid.Enabled), 5, 0), true);
         edtavDeductfromvacationdaysvariable_Enabled = 0;
         AssignProp(sPrefix, false, edtavDeductfromvacationdaysvariable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeductfromvacationdaysvariable_Enabled), 5, 0), true);
         edtavLeaverequest_employeebalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         radavLeaverequest_leaverequesthalfday.Enabled = 0;
         AssignProp(sPrefix, false, radavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leaverequesthalfday.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
      }

      protected void RF5L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E215L2 ();
            WB5L0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5L2( )
      {
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         dynavLeaverequest_leavetypeid.Enabled = 0;
         AssignProp(sPrefix, false, dynavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_leavetypeid.Enabled), 5, 0), true);
         edtavDeductfromvacationdaysvariable_Enabled = 0;
         AssignProp(sPrefix, false, edtavDeductfromvacationdaysvariable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDeductfromvacationdaysvariable_Enabled), 5, 0), true);
         edtavLeaverequest_employeebalance_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_employeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeebalance_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         radavLeaverequest_leaverequesthalfday.Enabled = 0;
         AssignProp(sPrefix, false, radavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leaverequesthalfday.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestduration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestduration_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E145L2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vLEAVEREQUEST"), AV11LeaveRequest);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Leaverequest"), AV11LeaveRequest);
            /* Read saved values. */
            wcpOAV21TrnMode = cgiGet( sPrefix+"wcpOAV21TrnMode");
            wcpOAV12LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV12LeaveRequestId"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV11LeaveRequest.gxTpr_Employeename = cgiGet( edtavLeaverequest_employeename_Internalname);
            dynavLeaverequest_leavetypeid.CurrentValue = cgiGet( dynavLeaverequest_leavetypeid_Internalname);
            AV11LeaveRequest.gxTpr_Leavetypeid = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavLeaverequest_leavetypeid_Internalname), "."), 18, MidpointRounding.ToEven));
            AV7DeductFromVacationDaysVariable = cgiGet( edtavDeductfromvacationdaysvariable_Internalname);
            AssignAttri(sPrefix, false, "AV7DeductFromVacationDaysVariable", AV7DeductFromVacationDaysVariable);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_EMPLOYEEBALANCE");
               GX_FocusControl = edtavLeaverequest_employeebalance_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11LeaveRequest.gxTpr_Employeebalance = 0;
            }
            else
            {
               AV11LeaveRequest.gxTpr_Employeebalance = context.localUtil.CToN( cgiGet( edtavLeaverequest_employeebalance_Internalname), ".", ",");
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request Start Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTSTARTDATE");
               GX_FocusControl = edtavLeaverequest_leaverequeststartdate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11LeaveRequest.gxTpr_Leaverequeststartdate = DateTime.MinValue;
            }
            else
            {
               AV11LeaveRequest.gxTpr_Leaverequeststartdate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequeststartdate_Internalname), 2);
            }
            if ( context.localUtil.VCDate( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Leave Request End Date"}), 1, "LEAVEREQUEST_LEAVEREQUESTENDDATE");
               GX_FocusControl = edtavLeaverequest_leaverequestenddate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11LeaveRequest.gxTpr_Leaverequestenddate = DateTime.MinValue;
            }
            else
            {
               AV11LeaveRequest.gxTpr_Leaverequestenddate = context.localUtil.CToD( cgiGet( edtavLeaverequest_leaverequestenddate_Internalname), 2);
            }
            AV11LeaveRequest.gxTpr_Leaverequesthalfday = cgiGet( radavLeaverequest_leaverequesthalfday_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",") > 99.9m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LEAVEREQUEST_LEAVEREQUESTDURATION");
               GX_FocusControl = edtavLeaverequest_leaverequestduration_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11LeaveRequest.gxTpr_Leaverequestduration = 0;
            }
            else
            {
               AV11LeaveRequest.gxTpr_Leaverequestduration = context.localUtil.CToN( cgiGet( edtavLeaverequest_leaverequestduration_Internalname), ".", ",");
            }
            AV11LeaveRequest.gxTpr_Leaverequestdescription = cgiGet( edtavLeaverequest_leaverequestdescription_Internalname);
            AV11LeaveRequest.gxTpr_Leaverequestrejectionreason = cgiGet( edtavLeaverequest_leaverequestrejectionreason_Internalname);
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
         E145L2 ();
         if (returnInSub) return;
      }

      protected void E145L2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV11LeaveRequest.Load(AV12LeaveRequestId);
         GXt_int1 = AV33LoggedInEmployeeId;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV33LoggedInEmployeeId = GXt_int1;
         AV38CanApprove = false;
         AV34IsEditable = false;
         AV5ActionLeaveRole = false;
         if ( new userhasrole(context).executeUdp(  "Manager") || new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AV5ActionLeaveRole = true;
         }
         if ( new userhasrole(context).executeUdp(  "Employee") && ( ( AV11LeaveRequest.gxTpr_Employeeid == AV33LoggedInEmployeeId ) ) && ( ( DateTimeUtil.ResetTime ( AV11LeaveRequest.gxTpr_Leaverequeststartdate ) > DateTimeUtil.ResetTime ( Gx_date ) ) ) )
         {
            AV34IsEditable = true;
         }
         else
         {
            if ( new userhasrole(context).executeUdp(  "Manager") || new userhasrole(context).executeUdp(  "Project Manager") )
            {
               AV34IsEditable = true;
               AV38CanApprove = (bool)(!((StringUtil.StrCmp(AV11LeaveRequest.gxTpr_Leaverequeststatus, "Approved")==0)));
            }
         }
         divTableupdateaction_Visible = 0;
         AssignProp(sPrefix, false, divTableupdateaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableupdateaction_Visible), 5, 0), true);
         AV7DeductFromVacationDaysVariable = AV11LeaveRequest.gxTpr_Leavetypevacationleave;
         AssignAttri(sPrefix, false, "AV7DeductFromVacationDaysVariable", AV7DeductFromVacationDaysVariable);
      }

      protected void E155L2( )
      {
         /* 'DoUpdateButton' Routine */
         returnInSub = false;
         divTableeditaction_Visible = 1;
         AssignProp(sPrefix, false, divTableeditaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableeditaction_Visible), 5, 0), true);
         divTableupdateaction_Visible = 0;
         AssignProp(sPrefix, false, divTableupdateaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableupdateaction_Visible), 5, 0), true);
         divTableapproveaction_Visible = 1;
         AssignProp(sPrefix, false, divTableapproveaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableapproveaction_Visible), 5, 0), true);
         /* Execute user subroutine: 'FORMFIELDSDISABLED' */
         S112 ();
         if (returnInSub) return;
         if ( AV11LeaveRequest.Update() )
         {
            context.CommitDataStores("wc_leavedetails",pr_default);
            GX_msglist.addItem("Leave Updated Successfully");
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
            AV11LeaveRequest.Load(AV12LeaveRequestId);
         }
         else
         {
            AV50GXV11 = 1;
            AV49GXV10 = AV11LeaveRequest.GetMessages();
            while ( AV50GXV11 <= AV49GXV10.Count )
            {
               AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV49GXV10.Item(AV50GXV11));
               GX_msglist.addItem(AV16Message.gxTpr_Description);
               AV50GXV11 = (int)(AV50GXV11+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11LeaveRequest", AV11LeaveRequest);
      }

      protected void E165L2( )
      {
         /* 'DoCancelUpdateButton' Routine */
         returnInSub = false;
         divTableapproveaction_Visible = 1;
         AssignProp(sPrefix, false, divTableapproveaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableapproveaction_Visible), 5, 0), true);
         divTableeditaction_Visible = 1;
         AssignProp(sPrefix, false, divTableeditaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableeditaction_Visible), 5, 0), true);
         divTableupdateaction_Visible = 0;
         AssignProp(sPrefix, false, divTableupdateaction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableupdateaction_Visible), 5, 0), true);
         AV11LeaveRequest.Load(AV12LeaveRequestId);
         /* Execute user subroutine: 'FORMFIELDSDISABLED' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11LeaveRequest", AV11LeaveRequest);
      }

      protected void E175L2( )
      {
         /* Leaverequest_leaverequeststartdate_Controlvaluechanged Routine */
         returnInSub = false;
         if ( DateTimeUtil.ResetTime ( AV11LeaveRequest.gxTpr_Leaverequestenddate ) != DateTimeUtil.ResetTime ( AV11LeaveRequest.gxTpr_Leaverequeststartdate ) )
         {
            AV11LeaveRequest.gxTpr_Leaverequesthalfday = "";
         }
         /* Execute user subroutine: 'LEAVEDURATIONSUB' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11LeaveRequest", AV11LeaveRequest);
      }

      protected void E185L2( )
      {
         /* Leaverequest_leaverequestenddate_Controlvaluechanged Routine */
         returnInSub = false;
         if ( DateTimeUtil.ResetTime ( AV11LeaveRequest.gxTpr_Leaverequestenddate ) != DateTimeUtil.ResetTime ( AV11LeaveRequest.gxTpr_Leaverequeststartdate ) )
         {
            AV11LeaveRequest.gxTpr_Leaverequesthalfday = "";
         }
         /* Execute user subroutine: 'LEAVEDURATIONSUB' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11LeaveRequest", AV11LeaveRequest);
      }

      protected void E195L2( )
      {
         /* Leaverequest_leaverequesthalfday_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11LeaveRequest.gxTpr_Leaverequesthalfday)) )
         {
            AV11LeaveRequest.gxTpr_Leaverequestenddate = AV11LeaveRequest.gxTpr_Leaverequeststartdate;
         }
         /* Execute user subroutine: 'LEAVEDURATIONSUB' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11LeaveRequest", AV11LeaveRequest);
      }

      protected void E205L2( )
      {
         /* Leaverequest_leavetypeid_Controlvaluechanged Routine */
         returnInSub = false;
         AV13LeaveType.Load(AV11LeaveRequest.gxTpr_Leavetypeid);
         AV7DeductFromVacationDaysVariable = AV13LeaveType.gxTpr_Leavetypevacationleave;
         AssignAttri(sPrefix, false, "AV7DeductFromVacationDaysVariable", AV7DeductFromVacationDaysVariable);
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'DO ACTION APPROVEBUTTON' Routine */
         returnInSub = false;
         AV11LeaveRequest.gxTpr_Leaverequeststatus = "Approved";
         if ( AV11LeaveRequest.Update() )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
            AV9Employee.Load(AV11LeaveRequest.gxTpr_Employeeid);
            AV13LeaveType.Load(AV11LeaveRequest.gxTpr_Leavetypeid);
            if ( AV9Employee.Update() )
            {
               GXt_char2 = AV13LeaveType.gxTpr_Leavetypename + " approved";
               GXt_char3 = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Request Approved</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV9Employee.gxTpr_Employeename + ",</p>" + "<p>We are pleased to inform you that your leave request has been approved. </p>" + "<p>Start Date: <b>" + context.localUtil.DToC( AV11LeaveRequest.gxTpr_Leaverequeststartdate, 2, "/") + "</b></p>" + "<p>End Date: <b>" + context.localUtil.DToC( AV11LeaveRequest.gxTpr_Leaverequestenddate, 2, "/") + "</b></p>" + "<p>Description: <b>" + AV11LeaveRequest.gxTpr_Leaverequestdescription + "</b></p><p>If you have any questions or need further assistance, please do not hesitate to contact us.</p><p>Best Regards,</p><p>Yukon Time Tracker Team</p></div></div>";
               new sendemail(context).executeSubmit(  AV9Employee.gxTpr_Employeeemail, ref  GXt_char2, ref  GXt_char3) ;
               new sdsendpushnotifications(context ).execute(  "Leave Request Approved",  "Your leave request made on "+context.localUtil.DToC( AV11LeaveRequest.gxTpr_Leaverequestdate, 2, "/")+" has been approved",  AV11LeaveRequest.gxTpr_Employeeid) ;
               context.CommitDataStores("wc_leavedetails",pr_default);
               context.DoAjaxRefreshCmp(sPrefix);
               GX_msglist.addItem("Leave Approved Successfully");
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
               this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
               context.setWebReturnParms(new Object[] {(string)AV21TrnMode,(long)AV12LeaveRequestId});
               context.setWebReturnParmsMetadata(new Object[] {"AV21TrnMode","AV12LeaveRequestId"});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               context.RollbackDataStores("wc_leavedetails",pr_default);
            }
         }
         else
         {
            context.RollbackDataStores("wc_leavedetails",pr_default);
            AV52GXV13 = 1;
            AV51GXV12 = AV11LeaveRequest.GetMessages();
            while ( AV52GXV13 <= AV51GXV12.Count )
            {
               AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV51GXV12.Item(AV52GXV13));
               GX_msglist.addItem(AV16Message.gxTpr_Description);
               AV52GXV13 = (int)(AV52GXV13+1);
            }
         }
      }

      protected void S152( )
      {
         /* 'DO ACTION REJECTBUTTON' Routine */
         returnInSub = false;
         AV11LeaveRequest.gxTpr_Leaverequeststatus = "Rejected";
         AV11LeaveRequest.gxTpr_Leaverequestrejectionreason = AV8DVelop_ConfirmPanel_RejectButton_Comment;
         if ( AV11LeaveRequest.Update() )
         {
            AV9Employee.Load(AV11LeaveRequest.gxTpr_Employeeid);
            AV13LeaveType.Load(AV11LeaveRequest.gxTpr_Leavetypeid);
            GXt_char3 = AV13LeaveType.gxTpr_Leavetypename + " rejected";
            GXt_char2 = "<div style=\"max-width:600px;margin:0 auto;font-family:Arial,sans-serif;border:1px solid #e0e0e0;padding:20px;box-shadow:0 4px 8px rgba(0,0,0,.1)\"><div style=\"background-color:#f6d300;color:#000;text-align:center;padding:20px 0\"><h2>Leave Request Rejected</h2></div><div style=\"padding:20px;line-height:1.5\"><p>Dear " + AV9Employee.gxTpr_Employeename + ",</p>" + "<p>We regret to inform you that your leave request has been rejected. </p>" + "<p>Start Date: <b>" + context.localUtil.DToC( AV11LeaveRequest.gxTpr_Leaverequeststartdate, 2, "/") + "</b></p>" + "<p>EndDate: <b>" + context.localUtil.DToC( AV11LeaveRequest.gxTpr_Leaverequestenddate, 2, "/") + "</b></p>" + "<p>Reason for Rejection: <b>" + AV11LeaveRequest.gxTpr_Leaverequestrejectionreason + "</b></p><p>If you have any concerns or need clarification, please reach out to us.</p><p> Best Regards</p><p>The Yukon Time Tracker Team</p></div></div>";
            new sendemail(context).executeSubmit(  AV9Employee.gxTpr_Employeeemail, ref  GXt_char3, ref  GXt_char2) ;
            context.CommitDataStores("wc_leavedetails",pr_default);
            GX_msglist.addItem("Leave Rejected Successfully");
            new sdsendpushnotifications(context ).execute(  "Leave Request Rejected",  "Your leave request made on "+context.localUtil.DToC( AV11LeaveRequest.gxTpr_Leaverequestdate, 2, "/")+" has been rejected",  AV11LeaveRequest.gxTpr_Employeeid) ;
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
            context.setWebReturnParms(new Object[] {(string)AV21TrnMode,(long)AV12LeaveRequestId});
            context.setWebReturnParmsMetadata(new Object[] {"AV21TrnMode","AV12LeaveRequestId"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            context.RollbackDataStores("wc_leavedetails",pr_default);
            AV54GXV15 = 1;
            AV53GXV14 = AV11LeaveRequest.GetMessages();
            while ( AV54GXV15 <= AV53GXV14.Count )
            {
               AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV53GXV14.Item(AV54GXV15));
               GX_msglist.addItem(AV16Message.gxTpr_Description);
               AV54GXV15 = (int)(AV54GXV15+1);
            }
         }
      }

      protected void S162( )
      {
         /* 'DO ACTION DELETEBUTTON' Routine */
         returnInSub = false;
         AV11LeaveRequest.Delete();
         if ( AV11LeaveRequest.Success() )
         {
            context.CommitDataStores("wc_leavedetails",pr_default);
            GX_msglist.addItem("Leave Deleted Successfully");
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "PendingLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ApprovedLeaveRequests", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "LeaveRequestStatusChanged", new Object[] {}, true);
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "RejectedLeaveRequests", new Object[] {}, true);
            context.setWebReturnParms(new Object[] {(string)AV21TrnMode,(long)AV12LeaveRequestId});
            context.setWebReturnParmsMetadata(new Object[] {"AV21TrnMode","AV12LeaveRequestId"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV56GXV17 = 1;
            AV55GXV16 = AV11LeaveRequest.GetMessages();
            while ( AV56GXV17 <= AV55GXV16.Count )
            {
               AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV55GXV16.Item(AV56GXV17));
               GX_msglist.addItem(AV16Message.gxTpr_Description);
               AV56GXV17 = (int)(AV56GXV17+1);
            }
         }
      }

      protected void S132( )
      {
         /* 'LEAVEDURATIONSUB' Routine */
         returnInSub = false;
         GXt_decimal4 = 0;
         new getleaverequestdays(context ).execute(  AV11LeaveRequest.gxTpr_Leaverequeststartdate,  AV11LeaveRequest.gxTpr_Leaverequestenddate,  AV11LeaveRequest.gxTpr_Leaverequesthalfday,  AV11LeaveRequest.gxTpr_Employeeid, out  GXt_decimal4) ;
         AV11LeaveRequest.gxTpr_Leaverequestduration = GXt_decimal4;
      }

      protected void S112( )
      {
         /* 'FORMFIELDSDISABLED' Routine */
         returnInSub = false;
         edtavLeaverequest_employeename_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_employeename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_employeename_Enabled), 5, 0), true);
         dynavLeaverequest_leavetypeid.Enabled = 0;
         AssignProp(sPrefix, false, dynavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_leavetypeid.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         radavLeaverequest_leaverequesthalfday.Enabled = 0;
         AssignProp(sPrefix, false, radavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leaverequesthalfday.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
      }

      protected void S122( )
      {
         /* 'FORFIELDSENABLED' Routine */
         returnInSub = false;
         dynavLeaverequest_leavetypeid.Enabled = 1;
         AssignProp(sPrefix, false, dynavLeaverequest_leavetypeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavLeaverequest_leavetypeid.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequeststartdate_Enabled = 1;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequeststartdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequeststartdate_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestenddate_Enabled = 1;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestenddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestenddate_Enabled), 5, 0), true);
         radavLeaverequest_leaverequesthalfday.Enabled = 1;
         AssignProp(sPrefix, false, radavLeaverequest_leaverequesthalfday_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(radavLeaverequest_leaverequesthalfday.Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestdescription_Enabled = 1;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestdescription_Enabled), 5, 0), true);
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 1;
         AssignProp(sPrefix, false, edtavLeaverequest_leaverequestrejectionreason_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLeaverequest_leaverequestrejectionreason_Enabled), 5, 0), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E215L2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV21TrnMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV21TrnMode", AV21TrnMode);
         AV12LeaveRequestId = Convert.ToInt64(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV12LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV12LeaveRequestId), 10, 0));
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
         PA5L2( ) ;
         WS5L2( ) ;
         WE5L2( ) ;
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
         sCtrlAV21TrnMode = (string)((string)getParm(obj,0));
         sCtrlAV12LeaveRequestId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA5L2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wc_leavedetails", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5L2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV21TrnMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV21TrnMode", AV21TrnMode);
            AV12LeaveRequestId = Convert.ToInt64(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV12LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV12LeaveRequestId), 10, 0));
         }
         wcpOAV21TrnMode = cgiGet( sPrefix+"wcpOAV21TrnMode");
         wcpOAV12LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV12LeaveRequestId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV21TrnMode, wcpOAV21TrnMode) != 0 ) || ( AV12LeaveRequestId != wcpOAV12LeaveRequestId ) ) )
         {
            setjustcreated();
         }
         wcpOAV21TrnMode = AV21TrnMode;
         wcpOAV12LeaveRequestId = AV12LeaveRequestId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV21TrnMode = cgiGet( sPrefix+"AV21TrnMode_CTRL");
         if ( StringUtil.Len( sCtrlAV21TrnMode) > 0 )
         {
            AV21TrnMode = cgiGet( sCtrlAV21TrnMode);
            AssignAttri(sPrefix, false, "AV21TrnMode", AV21TrnMode);
         }
         else
         {
            AV21TrnMode = cgiGet( sPrefix+"AV21TrnMode_PARM");
         }
         sCtrlAV12LeaveRequestId = cgiGet( sPrefix+"AV12LeaveRequestId_CTRL");
         if ( StringUtil.Len( sCtrlAV12LeaveRequestId) > 0 )
         {
            AV12LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV12LeaveRequestId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV12LeaveRequestId", StringUtil.LTrimStr( (decimal)(AV12LeaveRequestId), 10, 0));
         }
         else
         {
            AV12LeaveRequestId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV12LeaveRequestId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA5L2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5L2( ) ;
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
         WS5L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV21TrnMode_PARM", StringUtil.RTrim( AV21TrnMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV21TrnMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV21TrnMode_CTRL", StringUtil.RTrim( sCtrlAV21TrnMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12LeaveRequestId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12LeaveRequestId), 10, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12LeaveRequestId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12LeaveRequestId_CTRL", StringUtil.RTrim( sCtrlAV12LeaveRequestId));
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
         WE5L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267493735", true, true);
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
         context.AddJavascriptSource("wc_leavedetails.js", "?20256267493735", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavLeaverequest_leavetypeid.Name = "LEAVEREQUEST_LEAVETYPEID";
         dynavLeaverequest_leavetypeid.WebTags = "";
         dynavLeaverequest_leavetypeid.removeAllItems();
         /* Using cursor H005L4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            dynavLeaverequest_leavetypeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005L4_A124LeaveTypeId[0]), 10, 0)), H005L4_A125LeaveTypeName[0], 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( dynavLeaverequest_leavetypeid.ItemCount > 0 )
         {
         }
         radavLeaverequest_leaverequesthalfday.Name = "LEAVEREQUEST_LEAVEREQUESTHALFDAY";
         radavLeaverequest_leaverequesthalfday.WebTags = "";
         radavLeaverequest_leaverequesthalfday.addItem("", "None", 0);
         radavLeaverequest_leaverequesthalfday.addItem("Morning", "Morning", 0);
         radavLeaverequest_leaverequesthalfday.addItem("Afternoon", "Afternoon", 0);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTableleft_Internalname = sPrefix+"TABLELEFT";
         divTableeditaction_Internalname = sPrefix+"TABLEEDITACTION";
         edtavLeaverequest_employeename_Internalname = sPrefix+"LEAVEREQUEST_EMPLOYEENAME";
         dynavLeaverequest_leavetypeid_Internalname = sPrefix+"LEAVEREQUEST_LEAVETYPEID";
         edtavDeductfromvacationdaysvariable_Internalname = sPrefix+"vDEDUCTFROMVACATIONDAYSVARIABLE";
         edtavLeaverequest_employeebalance_Internalname = sPrefix+"LEAVEREQUEST_EMPLOYEEBALANCE";
         edtavLeaverequest_leaverequeststartdate_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTSTARTDATE";
         edtavLeaverequest_leaverequestenddate_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTENDDATE";
         radavLeaverequest_leaverequesthalfday_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTHALFDAY";
         edtavLeaverequest_leaverequestduration_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTDURATION";
         edtavLeaverequest_leaverequestdescription_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTDESCRIPTION";
         edtavLeaverequest_leaverequestrejectionreason_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON";
         divLeaverequest_leaverequestrejectionreason_cell_Internalname = sPrefix+"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON_CELL";
         bttBtnupdatebutton_Internalname = sPrefix+"BTNUPDATEBUTTON";
         bttBtncancelupdatebutton_Internalname = sPrefix+"BTNCANCELUPDATEBUTTON";
         divTableupdateaction_Internalname = sPrefix+"TABLEUPDATEACTION";
         bttBtnapprovebutton_Internalname = sPrefix+"BTNAPPROVEBUTTON";
         bttBtnrejectbutton_Internalname = sPrefix+"BTNREJECTBUTTON";
         bttBtndeletebutton_Internalname = sPrefix+"BTNDELETEBUTTON";
         divTableapproveaction_Internalname = sPrefix+"TABLEAPPROVEACTION";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablecenter_Internalname = sPrefix+"TABLECENTER";
         divTableright_Internalname = sPrefix+"TABLERIGHT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         divTableapproveaction_Visible = 1;
         divTableupdateaction_Visible = 1;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         edtavLeaverequest_leaverequestduration_Jsonclick = "";
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         radavLeaverequest_leaverequesthalfday_Jsonclick = "";
         radavLeaverequest_leaverequesthalfday.Enabled = 1;
         edtavLeaverequest_leaverequestenddate_Jsonclick = "";
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         edtavLeaverequest_leaverequeststartdate_Jsonclick = "";
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         edtavLeaverequest_employeebalance_Jsonclick = "";
         edtavLeaverequest_employeebalance_Enabled = 0;
         edtavDeductfromvacationdaysvariable_Jsonclick = "";
         edtavDeductfromvacationdaysvariable_Enabled = 1;
         dynavLeaverequest_leavetypeid_Jsonclick = "";
         dynavLeaverequest_leavetypeid.Enabled = 0;
         edtavLeaverequest_employeename_Jsonclick = "";
         edtavLeaverequest_employeename_Enabled = 0;
         divTableeditaction_Visible = 1;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = -1;
         edtavLeaverequest_leaverequestdescription_Enabled = -1;
         edtavLeaverequest_leaverequestduration_Enabled = -1;
         edtavLeaverequest_leaverequestenddate_Enabled = -1;
         edtavLeaverequest_leaverequeststartdate_Enabled = -1;
         edtavLeaverequest_employeebalance_Enabled = -1;
         dynavLeaverequest_leavetypeid.Enabled = -1;
         edtavLeaverequest_employeename_Enabled = -1;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"dynavLeaverequest_leavetypeid"},{"av":"GXV2","fld":"LEAVEREQUEST_LEAVETYPEID","pic":"ZZZZZZZZZ9"},{"av":"radavLeaverequest_leaverequesthalfday"},{"av":"GXV6","fld":"LEAVEREQUEST_LEAVEREQUESTHALFDAY"}]}""");
         setEventMetadata("'DOAPPROVEBUTTON'","""{"handler":"E115L1","iparms":[]}""");
         setEventMetadata("'DOREJECTBUTTON'","""{"handler":"E125L1","iparms":[]}""");
         setEventMetadata("'DODELETEBUTTON'","""{"handler":"E135L1","iparms":[]}""");
         setEventMetadata("'DOUPDATEBUTTON'","""{"handler":"E155L2","iparms":[{"av":"AV11LeaveRequest","fld":"vLEAVEREQUEST"},{"av":"AV12LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("'DOUPDATEBUTTON'",""","oparms":[{"av":"divTableeditaction_Visible","ctrl":"TABLEEDITACTION","prop":"Visible"},{"av":"divTableupdateaction_Visible","ctrl":"TABLEUPDATEACTION","prop":"Visible"},{"av":"divTableapproveaction_Visible","ctrl":"TABLEAPPROVEACTION","prop":"Visible"},{"av":"AV11LeaveRequest","fld":"vLEAVEREQUEST"},{"ctrl":"LEAVEREQUEST_EMPLOYEENAME","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVETYPEID","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTSTARTDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTENDDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTHALFDAY","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTDESCRIPTION","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON","prop":"Enabled"}]}""");
         setEventMetadata("'DOCANCELUPDATEBUTTON'","""{"handler":"E165L2","iparms":[{"av":"AV12LeaveRequestId","fld":"vLEAVEREQUESTID","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("'DOCANCELUPDATEBUTTON'",""","oparms":[{"av":"divTableapproveaction_Visible","ctrl":"TABLEAPPROVEACTION","prop":"Visible"},{"av":"divTableeditaction_Visible","ctrl":"TABLEEDITACTION","prop":"Visible"},{"av":"divTableupdateaction_Visible","ctrl":"TABLEUPDATEACTION","prop":"Visible"},{"av":"AV11LeaveRequest","fld":"vLEAVEREQUEST"},{"ctrl":"LEAVEREQUEST_EMPLOYEENAME","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVETYPEID","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTSTARTDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTENDDATE","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTHALFDAY","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTDESCRIPTION","prop":"Enabled"},{"ctrl":"LEAVEREQUEST_LEAVEREQUESTREJECTIONREASON","prop":"Enabled"}]}""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED","""{"handler":"E175L2","iparms":[{"av":"AV11LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTSTARTDATE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV11LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTENDDATE.CONTROLVALUECHANGED","""{"handler":"E185L2","iparms":[{"av":"AV11LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTENDDATE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV11LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTHALFDAY.CONTROLVALUECHANGED","""{"handler":"E195L2","iparms":[{"av":"AV11LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("LEAVEREQUEST_LEAVEREQUESTHALFDAY.CONTROLVALUECHANGED",""","oparms":[{"av":"AV11LeaveRequest","fld":"vLEAVEREQUEST"}]}""");
         setEventMetadata("LEAVEREQUEST_LEAVETYPEID.CONTROLVALUECHANGED","""{"handler":"E205L2","iparms":[{"av":"AV11LeaveRequest","fld":"vLEAVEREQUEST"}]""");
         setEventMetadata("LEAVEREQUEST_LEAVETYPEID.CONTROLVALUECHANGED",""","oparms":[{"av":"AV7DeductFromVacationDaysVariable","fld":"vDEDUCTFROMVACATIONDAYSVARIABLE"}]}""");
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
         wcpOAV21TrnMode = "";
         AV11LeaveRequest = new SdtLeaveRequest(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV7DeductFromVacationDaysVariable = "";
         bttBtnupdatebutton_Jsonclick = "";
         bttBtncancelupdatebutton_Jsonclick = "";
         bttBtnapprovebutton_Jsonclick = "";
         bttBtnrejectbutton_Jsonclick = "";
         bttBtndeletebutton_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H005L2_A124LeaveTypeId = new long[1] ;
         H005L2_A125LeaveTypeName = new string[] {""} ;
         H005L3_A124LeaveTypeId = new long[1] ;
         H005L3_A125LeaveTypeName = new string[] {""} ;
         AV49GXV10 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV13LeaveType = new SdtLeaveType(context);
         AV9Employee = new SdtEmployee(context);
         AV51GXV12 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8DVelop_ConfirmPanel_RejectButton_Comment = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV53GXV14 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV55GXV16 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV21TrnMode = "";
         sCtrlAV12LeaveRequestId = "";
         H005L4_A124LeaveTypeId = new long[1] ;
         H005L4_A125LeaveTypeName = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wc_leavedetails__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wc_leavedetails__default(),
            new Object[][] {
                new Object[] {
               H005L2_A124LeaveTypeId, H005L2_A125LeaveTypeName
               }
               , new Object[] {
               H005L3_A124LeaveTypeId, H005L3_A125LeaveTypeName
               }
               , new Object[] {
               H005L4_A124LeaveTypeId, H005L4_A125LeaveTypeName
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         edtavLeaverequest_employeename_Enabled = 0;
         dynavLeaverequest_leavetypeid.Enabled = 0;
         edtavDeductfromvacationdaysvariable_Enabled = 0;
         edtavLeaverequest_employeebalance_Enabled = 0;
         edtavLeaverequest_leaverequeststartdate_Enabled = 0;
         edtavLeaverequest_leaverequestenddate_Enabled = 0;
         radavLeaverequest_leaverequesthalfday.Enabled = 0;
         edtavLeaverequest_leaverequestduration_Enabled = 0;
         edtavLeaverequest_leaverequestdescription_Enabled = 0;
         edtavLeaverequest_leaverequestrejectionreason_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavLeaverequest_employeename_Enabled ;
      private int edtavDeductfromvacationdaysvariable_Enabled ;
      private int edtavLeaverequest_employeebalance_Enabled ;
      private int edtavLeaverequest_leaverequeststartdate_Enabled ;
      private int edtavLeaverequest_leaverequestenddate_Enabled ;
      private int edtavLeaverequest_leaverequestduration_Enabled ;
      private int edtavLeaverequest_leaverequestdescription_Enabled ;
      private int edtavLeaverequest_leaverequestrejectionreason_Enabled ;
      private int divTableeditaction_Visible ;
      private int divTableupdateaction_Visible ;
      private int divTableapproveaction_Visible ;
      private int gxdynajaxindex ;
      private int AV50GXV11 ;
      private int AV52GXV13 ;
      private int AV54GXV15 ;
      private int AV56GXV17 ;
      private int idxLst ;
      private long AV12LeaveRequestId ;
      private long wcpOAV12LeaveRequestId ;
      private long AV33LoggedInEmployeeId ;
      private long GXt_int1 ;
      private decimal GXt_decimal4 ;
      private string AV21TrnMode ;
      private string wcpOAV21TrnMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavLeaverequest_employeename_Internalname ;
      private string dynavLeaverequest_leavetypeid_Internalname ;
      private string edtavDeductfromvacationdaysvariable_Internalname ;
      private string edtavLeaverequest_employeebalance_Internalname ;
      private string edtavLeaverequest_leaverequeststartdate_Internalname ;
      private string edtavLeaverequest_leaverequestenddate_Internalname ;
      private string radavLeaverequest_leaverequesthalfday_Internalname ;
      private string edtavLeaverequest_leaverequestduration_Internalname ;
      private string edtavLeaverequest_leaverequestdescription_Internalname ;
      private string edtavLeaverequest_leaverequestrejectionreason_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableleft_Internalname ;
      private string divTablecenter_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTableeditaction_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string TempTags ;
      private string edtavLeaverequest_employeename_Jsonclick ;
      private string dynavLeaverequest_leavetypeid_Jsonclick ;
      private string AV7DeductFromVacationDaysVariable ;
      private string edtavDeductfromvacationdaysvariable_Jsonclick ;
      private string edtavLeaverequest_employeebalance_Jsonclick ;
      private string edtavLeaverequest_leaverequeststartdate_Jsonclick ;
      private string edtavLeaverequest_leaverequestenddate_Jsonclick ;
      private string radavLeaverequest_leaverequesthalfday_Jsonclick ;
      private string edtavLeaverequest_leaverequestduration_Jsonclick ;
      private string divLeaverequest_leaverequestrejectionreason_cell_Internalname ;
      private string divTableupdateaction_Internalname ;
      private string bttBtnupdatebutton_Internalname ;
      private string bttBtnupdatebutton_Jsonclick ;
      private string bttBtncancelupdatebutton_Internalname ;
      private string bttBtncancelupdatebutton_Jsonclick ;
      private string divTableapproveaction_Internalname ;
      private string bttBtnapprovebutton_Internalname ;
      private string bttBtnapprovebutton_Jsonclick ;
      private string bttBtnrejectbutton_Internalname ;
      private string bttBtnrejectbutton_Jsonclick ;
      private string bttBtndeletebutton_Internalname ;
      private string bttBtndeletebutton_Jsonclick ;
      private string divTableright_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sCtrlAV21TrnMode ;
      private string sCtrlAV12LeaveRequestId ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV38CanApprove ;
      private bool AV34IsEditable ;
      private bool AV5ActionLeaveRole ;
      private string AV8DVelop_ConfirmPanel_RejectButton_Comment ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_TrnMode ;
      private long aP1_LeaveRequestId ;
      private GXCombobox dynavLeaverequest_leavetypeid ;
      private GXRadio radavLeaverequest_leaverequesthalfday ;
      private SdtLeaveRequest AV11LeaveRequest ;
      private IDataStoreProvider pr_default ;
      private long[] H005L2_A124LeaveTypeId ;
      private string[] H005L2_A125LeaveTypeName ;
      private long[] H005L3_A124LeaveTypeId ;
      private string[] H005L3_A125LeaveTypeName ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV49GXV10 ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
      private SdtLeaveType AV13LeaveType ;
      private SdtEmployee AV9Employee ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV51GXV12 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV53GXV14 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV55GXV16 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H005L4_A124LeaveTypeId ;
      private string[] H005L4_A125LeaveTypeName ;
      private IDataStoreProvider pr_gam ;
   }

   public class wc_leavedetails__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wc_leavedetails__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH005L2;
        prmH005L2 = new Object[] {
        };
        Object[] prmH005L3;
        prmH005L3 = new Object[] {
        };
        Object[] prmH005L4;
        prmH005L4 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H005L2", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005L3", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L3,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005L4", "SELECT LeaveTypeId, LeaveTypeName FROM LeaveType ORDER BY LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L4,0, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
     }
  }

}

}
