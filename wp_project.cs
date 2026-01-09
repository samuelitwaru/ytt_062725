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
   public class wp_project : GXDataArea
   {
      public wp_project( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_project( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TrnMode ,
                           long aP1_ProjectId )
      {
         this.AV15TrnMode = aP0_TrnMode;
         this.AV19ProjectId = aP1_ProjectId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavProject_projectstatus = new GXCombobox();
         dynavEmployeeid = new GXCombobox();
         chkavProject_projectmanagerisactive = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
               return  ;
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
               AV15TrnMode = gxfirstwebparm;
               AssignAttri("", false, "AV15TrnMode", AV15TrnMode);
               GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15TrnMode, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV19ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV19ProjectId", StringUtil.LTrimStr( (decimal)(AV19ProjectId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ProjectId), "ZZZZZZZZZ9"), context));
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_47 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_47"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_47_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_47_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_47_idx = GetPar( "sGXsfl_47_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV15TrnMode = GetPar( "TrnMode");
         AV7Project.gxTpr_Projectmanagerisactive = StringUtil.StrToBool( GetNextPar( ));
         AV19ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV15TrnMode, AV7Project.gxTpr_Projectmanagerisactive, AV19ProjectId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
         PA5S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5S2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_project.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15TrnMode)),UrlEncode(StringUtil.LTrimStr(AV19ProjectId,10,0))}, new string[] {"TrnMode","ProjectId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV15TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15TrnMode, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ProjectId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Project", AV7Project);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Project", AV7Project);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_47", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_47), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRID1PAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Grid1PageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRID1APPLIEDFILTERS", AV12Grid1AppliedFilters);
         GxWebStd.gx_hidden_field( context, "vTRNMODE", StringUtil.RTrim( AV15TrnMode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15TrnMode, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV17CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV14Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV14Messages);
         }
         GxWebStd.gx_hidden_field( context, "vPROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ProjectId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "subGrid1_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Recordcount), 5, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECT", AV7Project);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECT", AV7Project);
         }
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Class", StringUtil.RTrim( Grid1paginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Grid1paginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Grid1paginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Shownext", StringUtil.BoolToStr( Grid1paginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Showlast", StringUtil.BoolToStr( Grid1paginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Grid1paginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Grid1paginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Grid1paginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Grid1paginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Grid1paginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Previous", StringUtil.RTrim( Grid1paginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Next", StringUtil.RTrim( Grid1paginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Caption", StringUtil.RTrim( Grid1paginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Grid1paginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Grid1paginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "GRID1_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid1_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Selectedpage", StringUtil.RTrim( Grid1paginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRID1PAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
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
            WE5S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5S2( ) ;
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
         return formatLink("wp_project.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15TrnMode)),UrlEncode(StringUtil.LTrimStr(AV19ProjectId,10,0))}, new string[] {"TrnMode","ProjectId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WP_Project" ;
      }

      public override string GetPgmdesc( )
      {
         return "WP_Project" ;
      }

      protected void WB5S0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProject_projectname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProject_projectname_Internalname, "Name", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProject_projectname_Internalname, StringUtil.RTrim( AV7Project.gxTpr_Projectname), StringUtil.RTrim( context.localUtil.Format( AV7Project.gxTpr_Projectname, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProject_projectname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProject_projectname_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_Project.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProject_projectdescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProject_projectdescription_Internalname, "Description", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_47_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavProject_projectdescription_Internalname, AV7Project.gxTpr_Projectdescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", 0, 1, edtavProject_projectdescription_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_Project.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavProject_projectstatus_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavProject_projectstatus_Internalname, "Status", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_47_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavProject_projectstatus, cmbavProject_projectstatus_Internalname, StringUtil.RTrim( AV7Project.gxTpr_Projectstatus), 1, cmbavProject_projectstatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavProject_projectstatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WP_Project.htm");
            cmbavProject_projectstatus.CurrentValue = StringUtil.RTrim( AV7Project.gxTpr_Projectstatus);
            AssignProp("", false, cmbavProject_projectstatus_Internalname, "Values", (string)(cmbavProject_projectstatus.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProject_projectmanagerid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProject_projectmanagerid_Internalname, "Project Manager", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProject_projectmanagerid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Project.gxTpr_Projectmanagerid), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7Project.gxTpr_Projectmanagerid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProject_projectmanagerid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProject_projectmanagerid_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_Project.htm");
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
            GxWebStd.gx_div_start( context, divEmployeetable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGrid1tablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl47( ) ;
         }
         if ( wbEnd == 47 )
         {
            wbEnd = 0;
            nRC_GXsfl_47 = (int)(nGXsfl_47_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGrid1paginationbar.SetProperty("Class", Grid1paginationbar_Class);
            ucGrid1paginationbar.SetProperty("ShowFirst", Grid1paginationbar_Showfirst);
            ucGrid1paginationbar.SetProperty("ShowPrevious", Grid1paginationbar_Showprevious);
            ucGrid1paginationbar.SetProperty("ShowNext", Grid1paginationbar_Shownext);
            ucGrid1paginationbar.SetProperty("ShowLast", Grid1paginationbar_Showlast);
            ucGrid1paginationbar.SetProperty("PagesToShow", Grid1paginationbar_Pagestoshow);
            ucGrid1paginationbar.SetProperty("PagingButtonsPosition", Grid1paginationbar_Pagingbuttonsposition);
            ucGrid1paginationbar.SetProperty("PagingCaptionPosition", Grid1paginationbar_Pagingcaptionposition);
            ucGrid1paginationbar.SetProperty("EmptyGridClass", Grid1paginationbar_Emptygridclass);
            ucGrid1paginationbar.SetProperty("RowsPerPageSelector", Grid1paginationbar_Rowsperpageselector);
            ucGrid1paginationbar.SetProperty("RowsPerPageOptions", Grid1paginationbar_Rowsperpageoptions);
            ucGrid1paginationbar.SetProperty("Previous", Grid1paginationbar_Previous);
            ucGrid1paginationbar.SetProperty("Next", Grid1paginationbar_Next);
            ucGrid1paginationbar.SetProperty("Caption", Grid1paginationbar_Caption);
            ucGrid1paginationbar.SetProperty("EmptyGridCaption", Grid1paginationbar_Emptygridcaption);
            ucGrid1paginationbar.SetProperty("RowsPerPageCaption", Grid1paginationbar_Rowsperpagecaption);
            ucGrid1paginationbar.SetProperty("CurrentPage", AV10Grid1CurrentPage);
            ucGrid1paginationbar.SetProperty("PageCount", AV11Grid1PageCount);
            ucGrid1paginationbar.SetProperty("AppliedFilters", AV12Grid1AppliedFilters);
            ucGrid1paginationbar.Render(context, "dvelop.dvpaginationbar", Grid1paginationbar_Internalname, "GRID1PAGINATIONBARContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", "Confirm", bttBtnenter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtnenter_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_Project.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_Project.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGrid1currentpage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10Grid1CurrentPage), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10Grid1CurrentPage), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGrid1currentpage_Jsonclick, 0, "Attribute", "", "", "", "", edtavGrid1currentpage_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_Project.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProject_projectid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Project.gxTpr_Projectid), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7Project.gxTpr_Projectid), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProject_projectid_Jsonclick, 0, "Attribute", "", "", "", "", edtavProject_projectid_Visible, 1, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_Project.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProject_projectmanagername_Internalname, StringUtil.RTrim( AV7Project.gxTpr_Projectmanagername), StringUtil.RTrim( context.localUtil.Format( AV7Project.gxTpr_Projectmanagername, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProject_projectmanagername_Jsonclick, 0, "Attribute", "", "", "", "", edtavProject_projectmanagername_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_Project.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProject_projectmanageremail_Internalname, AV7Project.gxTpr_Projectmanageremail, StringUtil.RTrim( context.localUtil.Format( AV7Project.gxTpr_Projectmanageremail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProject_projectmanageremail_Jsonclick, 0, "Attribute", "", "", "", "", edtavProject_projectmanageremail_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_Project.htm");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_47_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavProject_projectmanagerisactive_Internalname, StringUtil.BoolToStr( AV7Project.gxTpr_Projectmanagerisactive), "", "", chkavProject_projectmanagerisactive.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\"");
            /* User Defined Control */
            ucGrid1_empowerer.Render(context, "wwp.gridempowerer", Grid1_empowerer_Internalname, "GRID1_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 47 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5S2( )
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
         Form.Meta.addItem("description", "WP_Project", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5S0( ) ;
      }

      protected void WS5S2( )
      {
         START5S2( ) ;
         EVT5S2( ) ;
      }

      protected void EVT5S2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Grid1paginationbar.Changepage */
                              E115S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Grid1paginationbar.Changerowsperpage */
                              E125S2 ();
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
                                    E135S2 ();
                                 }
                                 dynload_actions( ) ;
                              }
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) )
                           {
                              nGXsfl_47_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
                              SubsflControlProps_472( ) ;
                              dynavEmployeeid.Name = dynavEmployeeid_Internalname;
                              dynavEmployeeid.CurrentValue = cgiGet( dynavEmployeeid_Internalname);
                              AV6EmployeeId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavEmployeeid_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, dynavEmployeeid_Internalname, StringUtil.LTrimStr( (decimal)(AV6EmployeeId), 10, 0));
                              AV20delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV20delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E145S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E155S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid1.Load */
                                    E165S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5S2( )
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

      protected void PA5S2( )
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
               GX_FocusControl = edtavProject_projectname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_472( ) ;
         while ( nGXsfl_47_idx <= nRC_GXsfl_47 )
         {
            sendrow_472( ) ;
            nGXsfl_47_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_47_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        string AV15TrnMode ,
                                        bool GXV8 ,
                                        long AV19ProjectId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF5S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
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
         if ( cmbavProject_projectstatus.ItemCount > 0 )
         {
            AV7Project.gxTpr_Projectstatus = cmbavProject_projectstatus.getValidValue(AV7Project.gxTpr_Projectstatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavProject_projectstatus.CurrentValue = StringUtil.RTrim( AV7Project.gxTpr_Projectstatus);
            AssignProp("", false, cmbavProject_projectstatus_Internalname, "Values", cmbavProject_projectstatus.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         dynavEmployeeid.Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF5S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 47;
         /* Execute user event: Refresh */
         E155S2 ();
         nGXsfl_47_idx = 1;
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_472( ) ;
         bGXsfl_47_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         if ( subGrid1_Islastpage != 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordcount( )-subGrid1_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_472( ) ;
            /* Execute user event: Grid1.Load */
            E165S2 ();
            if ( ( subGrid1_Islastpage == 0 ) && ( GRID1_nCurrentRecord > 0 ) && ( GRID1_nGridOutOfScope == 0 ) && ( nGXsfl_47_idx == 1 ) )
            {
               GRID1_nCurrentRecord = 0;
               GRID1_nGridOutOfScope = 1;
               subgrid1_firstpage( ) ;
               /* Execute user event: Grid1.Load */
               E165S2 ();
            }
            wbEnd = 47;
            WB5S0( ) ;
         }
         bGXsfl_47_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5S2( )
      {
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(((subGrid1_Recordcount==0) ? GRID1_nFirstRecordOnPage+1 : subGrid1_Recordcount)) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         if ( subGrid1_Rows > 0 )
         {
            return subGrid1_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(((subGrid1_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGrid1_fnc_Recordcount( )/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGrid1_fnc_Recordcount( )) % (subGrid1_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV15TrnMode, AV7Project.gxTpr_Projectmanagerisactive, AV19ProjectId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         if ( GRID1_nEOF == 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV15TrnMode, AV7Project.gxTpr_Projectmanagerisactive, AV19ProjectId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV15TrnMode, AV7Project.gxTpr_Projectmanagerisactive, AV19ProjectId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         subGrid1_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV15TrnMode, AV7Project.gxTpr_Projectmanagerisactive, AV19ProjectId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV15TrnMode, AV7Project.gxTpr_Projectmanagerisactive, AV19ProjectId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         dynavEmployeeid.Enabled = 0;
         edtavDelete_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E145S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vPROJECT"), AV7Project);
            ajax_req_read_hidden_sdt(cgiGet( "Project"), AV7Project);
            /* Read saved values. */
            nRC_GXsfl_47 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_47"), ".", ","), 18, MidpointRounding.ToEven));
            AV11Grid1PageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRID1PAGECOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV12Grid1AppliedFilters = cgiGet( "vGRID1APPLIEDFILTERS");
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid1_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid1_Recordcount"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid1_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
            Grid1paginationbar_Class = cgiGet( "GRID1PAGINATIONBAR_Class");
            Grid1paginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Showfirst"));
            Grid1paginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Showprevious"));
            Grid1paginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Shownext"));
            Grid1paginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Showlast"));
            Grid1paginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Pagestoshow"), ".", ","), 18, MidpointRounding.ToEven));
            Grid1paginationbar_Pagingbuttonsposition = cgiGet( "GRID1PAGINATIONBAR_Pagingbuttonsposition");
            Grid1paginationbar_Pagingcaptionposition = cgiGet( "GRID1PAGINATIONBAR_Pagingcaptionposition");
            Grid1paginationbar_Emptygridclass = cgiGet( "GRID1PAGINATIONBAR_Emptygridclass");
            Grid1paginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselector"));
            Grid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            Grid1paginationbar_Rowsperpageoptions = cgiGet( "GRID1PAGINATIONBAR_Rowsperpageoptions");
            Grid1paginationbar_Previous = cgiGet( "GRID1PAGINATIONBAR_Previous");
            Grid1paginationbar_Next = cgiGet( "GRID1PAGINATIONBAR_Next");
            Grid1paginationbar_Caption = cgiGet( "GRID1PAGINATIONBAR_Caption");
            Grid1paginationbar_Emptygridcaption = cgiGet( "GRID1PAGINATIONBAR_Emptygridcaption");
            Grid1paginationbar_Rowsperpagecaption = cgiGet( "GRID1PAGINATIONBAR_Rowsperpagecaption");
            Grid1_empowerer_Gridinternalname = cgiGet( "GRID1_EMPOWERER_Gridinternalname");
            Grid1paginationbar_Selectedpage = cgiGet( "GRID1PAGINATIONBAR_Selectedpage");
            Grid1paginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1PAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV7Project.gxTpr_Projectname = cgiGet( edtavProject_projectname_Internalname);
            AV7Project.gxTpr_Projectdescription = cgiGet( edtavProject_projectdescription_Internalname);
            cmbavProject_projectstatus.Name = cmbavProject_projectstatus_Internalname;
            cmbavProject_projectstatus.CurrentValue = cgiGet( cmbavProject_projectstatus_Internalname);
            AV7Project.gxTpr_Projectstatus = cgiGet( cmbavProject_projectstatus_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProject_projectmanagerid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProject_projectmanagerid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROJECT_PROJECTMANAGERID");
               GX_FocusControl = edtavProject_projectmanagerid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Project.gxTpr_Projectmanagerid = 0;
            }
            else
            {
               AV7Project.gxTpr_Projectmanagerid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavProject_projectmanagerid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vGRID1CURRENTPAGE");
               GX_FocusControl = edtavGrid1currentpage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10Grid1CurrentPage = 0;
               AssignAttri("", false, "AV10Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV10Grid1CurrentPage), 10, 0));
            }
            else
            {
               AV10Grid1CurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavGrid1currentpage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV10Grid1CurrentPage), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProject_projectid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProject_projectid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROJECT_PROJECTID");
               GX_FocusControl = edtavProject_projectid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7Project.gxTpr_Projectid = 0;
            }
            else
            {
               AV7Project.gxTpr_Projectid = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavProject_projectid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            }
            AV7Project.gxTpr_Projectmanagername = cgiGet( edtavProject_projectmanagername_Internalname);
            AV7Project.gxTpr_Projectmanageremail = cgiGet( edtavProject_projectmanageremail_Internalname);
            AV7Project.gxTpr_Projectmanagerisactive = StringUtil.StrToBool( cgiGet( chkavProject_projectmanagerisactive_Internalname));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E145S2 ();
         if (returnInSub) return;
      }

      protected void E145S2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV16LoadSuccess = true;
         if ( ( ( StringUtil.StrCmp(AV15TrnMode, "DSP") == 0 ) ) || ( ( StringUtil.StrCmp(AV15TrnMode, "INS") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "project_Insert") ) || ( ( StringUtil.StrCmp(AV15TrnMode, "UPD") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "project_Update") ) || ( ( StringUtil.StrCmp(AV15TrnMode, "DLT") == 0 ) && new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context).executeUdp(  "project_Delete") ) )
         {
            if ( StringUtil.StrCmp(AV15TrnMode, "INS") != 0 )
            {
               AV7Project.Load(AV19ProjectId);
               AV16LoadSuccess = AV7Project.Success();
               if ( ! AV16LoadSuccess )
               {
                  AV14Messages = AV7Project.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
               if ( ( StringUtil.StrCmp(AV15TrnMode, "DSP") == 0 ) || ( StringUtil.StrCmp(AV15TrnMode, "DLT") == 0 ) )
               {
                  edtavProject_projectname_Enabled = 0;
                  AssignProp("", false, edtavProject_projectname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProject_projectname_Enabled), 5, 0), true);
                  edtavProject_projectdescription_Enabled = 0;
                  AssignProp("", false, edtavProject_projectdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProject_projectdescription_Enabled), 5, 0), true);
                  cmbavProject_projectstatus.Enabled = 0;
                  AssignProp("", false, cmbavProject_projectstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavProject_projectstatus.Enabled), 5, 0), true);
                  edtavProject_projectmanagerid_Enabled = 0;
                  AssignProp("", false, edtavProject_projectmanagerid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProject_projectmanagerid_Enabled), 5, 0), true);
               }
            }
         }
         else
         {
            AV16LoadSuccess = false;
            CallWebObject(formatLink("gamnotauthorized.aspx") );
            context.wjLocDisableFrm = 1;
         }
         if ( AV16LoadSuccess )
         {
            if ( StringUtil.StrCmp(AV15TrnMode, "DLT") == 0 )
            {
               GX_msglist.addItem("Confirm deletion.");
            }
         }
         edtavProject_projectid_Visible = 0;
         AssignProp("", false, edtavProject_projectid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProject_projectid_Visible), 5, 0), true);
         edtavProject_projectmanagername_Visible = 0;
         AssignProp("", false, edtavProject_projectmanagername_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProject_projectmanagername_Visible), 5, 0), true);
         edtavProject_projectmanageremail_Visible = 0;
         AssignProp("", false, edtavProject_projectmanageremail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProject_projectmanageremail_Visible), 5, 0), true);
         chkavProject_projectmanagerisactive.Visible = 0;
         AssignProp("", false, chkavProject_projectmanagerisactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavProject_projectmanagerisactive.Visible), 5, 0), true);
         Grid1_empowerer_Gridinternalname = subGrid1_Internalname;
         ucGrid1_empowerer.SendProperty(context, "", false, Grid1_empowerer_Internalname, "GridInternalName", Grid1_empowerer_Gridinternalname);
         subGrid1_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV10Grid1CurrentPage = 1;
         AssignAttri("", false, "AV10Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV10Grid1CurrentPage), 10, 0));
         edtavGrid1currentpage_Visible = 0;
         AssignProp("", false, edtavGrid1currentpage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGrid1currentpage_Visible), 5, 0), true);
         AV11Grid1PageCount = -1;
         AssignAttri("", false, "AV11Grid1PageCount", StringUtil.LTrimStr( (decimal)(AV11Grid1PageCount), 10, 0));
         Grid1paginationbar_Rowsperpageselectedvalue = subGrid1_Rows;
         ucGrid1paginationbar.SendProperty(context, "", false, Grid1paginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Grid1paginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E155S2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      private void E165S2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV20delete = "<i class=\"fas fa-xmark\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV20delete);
         /*  Sending Event outputs  */
      }

      protected void E115S2( )
      {
         /* Grid1paginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Previous") == 0 )
         {
            AV10Grid1CurrentPage = (long)(AV10Grid1CurrentPage-1);
            AssignAttri("", false, "AV10Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV10Grid1CurrentPage), 10, 0));
            subgrid1_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Grid1paginationbar_Selectedpage, "Next") == 0 )
         {
            AV10Grid1CurrentPage = (long)(AV10Grid1CurrentPage+1);
            AssignAttri("", false, "AV10Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV10Grid1CurrentPage), 10, 0));
            subgrid1_nextpage( ) ;
         }
         else
         {
            AV9PageToGo = (int)(Math.Round(NumberUtil.Val( Grid1paginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            AV10Grid1CurrentPage = AV9PageToGo;
            AssignAttri("", false, "AV10Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV10Grid1CurrentPage), 10, 0));
            subgrid1_gotopage( AV9PageToGo) ;
         }
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void E125S2( )
      {
         /* Grid1paginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid1_Rows = Grid1paginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID1_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Rows), 6, 0, ".", "")));
         AV10Grid1CurrentPage = 1;
         AssignAttri("", false, "AV10Grid1CurrentPage", StringUtil.LTrimStr( (decimal)(AV10Grid1CurrentPage), 10, 0));
         subgrid1_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E135S2 ();
         if (returnInSub) return;
      }

      protected void E135S2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV15TrnMode, "DSP") != 0 )
         {
            if ( StringUtil.StrCmp(AV15TrnMode, "DLT") != 0 )
            {
               /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
               S132 ();
               if (returnInSub) return;
            }
            if ( ( StringUtil.StrCmp(AV15TrnMode, "DLT") == 0 ) || AV17CheckRequiredFieldsResult )
            {
               if ( StringUtil.StrCmp(AV15TrnMode, "DLT") == 0 )
               {
                  AV7Project.Delete();
               }
               else
               {
                  AV7Project.Save();
               }
               if ( AV7Project.Success() )
               {
                  /* Execute user subroutine: 'AFTER_TRN' */
                  S142 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV14Messages = AV7Project.GetMessages();
                  /* Execute user subroutine: 'SHOW MESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7Project", AV7Project);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14Messages", AV14Messages);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV15TrnMode, "DSP") != 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp("", false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'SHOW MESSAGES' Routine */
         returnInSub = false;
         AV29GXV9 = 1;
         while ( AV29GXV9 <= AV14Messages.Count )
         {
            AV13Message = ((GeneXus.Utils.SdtMessages_Message)AV14Messages.Item(AV29GXV9));
            GX_msglist.addItem(AV13Message.gxTpr_Description);
            AV29GXV9 = (int)(AV29GXV9+1);
         }
      }

      protected void S142( )
      {
         /* 'AFTER_TRN' Routine */
         returnInSub = false;
         context.CommitDataStores("wp_project",pr_default);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV17CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV17CheckRequiredFieldsResult", AV17CheckRequiredFieldsResult);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15TrnMode = (string)getParm(obj,0);
         AssignAttri("", false, "AV15TrnMode", AV15TrnMode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15TrnMode, "")), context));
         AV19ProjectId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV19ProjectId", StringUtil.LTrimStr( (decimal)(AV19ProjectId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19ProjectId), "ZZZZZZZZZ9"), context));
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
         PA5S2( ) ;
         WS5S2( ) ;
         WE5S2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026188182952", true, true);
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
         context.AddJavascriptSource("wp_project.js", "?2026188182952", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_472( )
      {
         dynavEmployeeid_Internalname = "vEMPLOYEEID_"+sGXsfl_47_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_47_idx;
      }

      protected void SubsflControlProps_fel_472( )
      {
         dynavEmployeeid_Internalname = "vEMPLOYEEID_"+sGXsfl_47_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_47_fel_idx;
      }

      protected void sendrow_472( )
      {
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_472( ) ;
         WB5S0( ) ;
         if ( ( subGrid1_Rows * 1 == 0 ) || ( nGXsfl_47_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_47_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_47_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_47_idx + "',47)\"";
            if ( ( dynavEmployeeid.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vEMPLOYEEID_" + sGXsfl_47_idx;
               dynavEmployeeid.Name = GXCCtl;
               dynavEmployeeid.WebTags = "";
               dynavEmployeeid.removeAllItems();
               /* Using cursor H005S2 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  dynavEmployeeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005S2_A106EmployeeId[0]), 10, 0)), H005S2_A148EmployeeName[0], 0);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               if ( dynavEmployeeid.ItemCount > 0 )
               {
                  AV6EmployeeId = (long)(Math.Round(NumberUtil.Val( dynavEmployeeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6EmployeeId), 10, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, dynavEmployeeid_Internalname, StringUtil.LTrimStr( (decimal)(AV6EmployeeId), 10, 0));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynavEmployeeid,(string)dynavEmployeeid_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV6EmployeeId), 10, 0)),(short)1,(string)dynavEmployeeid_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynavEmployeeid.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"",(string)"",(bool)true,(short)0});
            dynavEmployeeid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6EmployeeId), 10, 0));
            AssignProp("", false, dynavEmployeeid_Internalname, "Values", (string)(dynavEmployeeid.ToJavascriptSource()), !bGXsfl_47_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_47_idx + "',47)\"";
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV20delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes5S2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_47_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_47_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
         /* End function sendrow_472 */
      }

      protected void init_web_controls( )
      {
         cmbavProject_projectstatus.Name = "PROJECT_PROJECTSTATUS";
         cmbavProject_projectstatus.WebTags = "";
         cmbavProject_projectstatus.addItem("Active", "Active", 0);
         cmbavProject_projectstatus.addItem("Inactive", "Inactive", 0);
         if ( cmbavProject_projectstatus.ItemCount > 0 )
         {
            AV7Project.gxTpr_Projectstatus = cmbavProject_projectstatus.getValidValue(AV7Project.gxTpr_Projectstatus);
         }
         GXCCtl = "vEMPLOYEEID_" + sGXsfl_47_idx;
         dynavEmployeeid.Name = GXCCtl;
         dynavEmployeeid.WebTags = "";
         dynavEmployeeid.removeAllItems();
         /* Using cursor H005S3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            dynavEmployeeid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005S3_A106EmployeeId[0]), 10, 0)), H005S3_A148EmployeeName[0], 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( dynavEmployeeid.ItemCount > 0 )
         {
            AV6EmployeeId = (long)(Math.Round(NumberUtil.Val( dynavEmployeeid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6EmployeeId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, dynavEmployeeid_Internalname, StringUtil.LTrimStr( (decimal)(AV6EmployeeId), 10, 0));
         }
         chkavProject_projectmanagerisactive.Name = "PROJECT_PROJECTMANAGERISACTIVE";
         chkavProject_projectmanagerisactive.WebTags = "";
         chkavProject_projectmanagerisactive.Caption = "";
         AssignProp("", false, chkavProject_projectmanagerisactive_Internalname, "TitleCaption", chkavProject_projectmanagerisactive.Caption, true);
         chkavProject_projectmanagerisactive.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl47( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"47\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Employee Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6EmployeeId), 10, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynavEmployeeid.Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV20delete)));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtavProject_projectname_Internalname = "PROJECT_PROJECTNAME";
         edtavProject_projectdescription_Internalname = "PROJECT_PROJECTDESCRIPTION";
         cmbavProject_projectstatus_Internalname = "PROJECT_PROJECTSTATUS";
         edtavProject_projectmanagerid_Internalname = "PROJECT_PROJECTMANAGERID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         dynavEmployeeid_Internalname = "vEMPLOYEEID";
         edtavDelete_Internalname = "vDELETE";
         Grid1paginationbar_Internalname = "GRID1PAGINATIONBAR";
         divGrid1tablewithpaginationbar_Internalname = "GRID1TABLEWITHPAGINATIONBAR";
         divEmployeetable_Internalname = "EMPLOYEETABLE";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavGrid1currentpage_Internalname = "vGRID1CURRENTPAGE";
         edtavProject_projectid_Internalname = "PROJECT_PROJECTID";
         edtavProject_projectmanagername_Internalname = "PROJECT_PROJECTMANAGERNAME";
         edtavProject_projectmanageremail_Internalname = "PROJECT_PROJECTMANAGEREMAIL";
         chkavProject_projectmanagerisactive_Internalname = "PROJECT_PROJECTMANAGERISACTIVE";
         Grid1_empowerer_Internalname = "GRID1_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         chkavProject_projectmanagerisactive.Caption = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Enabled = 0;
         dynavEmployeeid_Jsonclick = "";
         dynavEmployeeid.Enabled = 0;
         subGrid1_Class = "GridWithPaginationBar WorkWith";
         subGrid1_Backcolorstyle = 0;
         edtavProject_projectmanagerid_Enabled = 1;
         cmbavProject_projectstatus.Enabled = 1;
         edtavProject_projectdescription_Enabled = 1;
         edtavProject_projectname_Enabled = 1;
         chkavProject_projectmanagerisactive.Visible = 1;
         edtavProject_projectmanageremail_Jsonclick = "";
         edtavProject_projectmanageremail_Visible = 1;
         edtavProject_projectmanagername_Jsonclick = "";
         edtavProject_projectmanagername_Visible = 1;
         edtavProject_projectid_Jsonclick = "";
         edtavProject_projectid_Visible = 1;
         edtavGrid1currentpage_Jsonclick = "";
         edtavGrid1currentpage_Visible = 1;
         bttBtnenter_Visible = 1;
         edtavProject_projectmanagerid_Jsonclick = "";
         edtavProject_projectmanagerid_Enabled = 1;
         cmbavProject_projectstatus_Jsonclick = "";
         cmbavProject_projectstatus.Enabled = 1;
         edtavProject_projectdescription_Enabled = 1;
         edtavProject_projectname_Jsonclick = "";
         edtavProject_projectname_Enabled = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Grid1paginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Grid1paginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Grid1paginationbar_Caption = "Page <CURRENT_PAGE> of <TOTAL_PAGES>";
         Grid1paginationbar_Next = "WWP_PagingNextCaption";
         Grid1paginationbar_Previous = "WWP_PagingPreviousCaption";
         Grid1paginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Grid1paginationbar_Rowsperpageselectedvalue = 10;
         Grid1paginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Grid1paginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Grid1paginationbar_Pagingcaptionposition = "Left";
         Grid1paginationbar_Pagingbuttonsposition = "Right";
         Grid1paginationbar_Pagestoshow = 5;
         Grid1paginationbar_Showlast = Convert.ToBoolean( 0);
         Grid1paginationbar_Shownext = Convert.ToBoolean( -1);
         Grid1paginationbar_Showprevious = Convert.ToBoolean( -1);
         Grid1paginationbar_Showfirst = Convert.ToBoolean( 0);
         Grid1paginationbar_Class = "PaginationBar";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WP_Project";
         subGrid1_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"GXV8","fld":"PROJECT_PROJECTMANAGERISACTIVE"},{"av":"AV15TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV19ProjectId","fld":"vPROJECTID","pic":"ZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("GRID1.LOAD","""{"handler":"E165S2","iparms":[]""");
         setEventMetadata("GRID1.LOAD",""","oparms":[{"av":"AV20delete","fld":"vDELETE"}]}""");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE","""{"handler":"E115S2","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV15TrnMode","fld":"vTRNMODE","hsh":true},{"av":"GXV8","fld":"PROJECT_PROJECTMANAGERISACTIVE"},{"av":"AV19ProjectId","fld":"vPROJECTID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Grid1paginationbar_Selectedpage","ctrl":"GRID1PAGINATIONBAR","prop":"SelectedPage"},{"av":"AV10Grid1CurrentPage","fld":"vGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"}]""");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEPAGE",""","oparms":[{"av":"AV10Grid1CurrentPage","fld":"vGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"},{"ctrl":"BTNENTER","prop":"Visible"}]}""");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E125S2","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV15TrnMode","fld":"vTRNMODE","hsh":true},{"av":"GXV8","fld":"PROJECT_PROJECTMANAGERISACTIVE"},{"av":"AV19ProjectId","fld":"vPROJECTID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"Grid1paginationbar_Rowsperpageselectedvalue","ctrl":"GRID1PAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRID1PAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV10Grid1CurrentPage","fld":"vGRID1CURRENTPAGE","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("ENTER","""{"handler":"E135S2","iparms":[{"av":"AV15TrnMode","fld":"vTRNMODE","hsh":true},{"av":"AV17CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV7Project","fld":"vPROJECT"},{"av":"AV14Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV7Project","fld":"vPROJECT"},{"av":"AV14Messages","fld":"vMESSAGES"},{"av":"AV17CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Delete","iparms":[]}""");
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
         wcpOAV15TrnMode = "";
         Grid1paginationbar_Selectedpage = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7Project = new SdtProject(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV12Grid1AppliedFilters = "";
         AV14Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Grid1_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         ucGrid1paginationbar = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucGrid1_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV20delete = "";
         AV13Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Grid1Row = new GXWebRow();
         subGrid1_Linesclass = "";
         GXCCtl = "";
         H005S2_A106EmployeeId = new long[1] ;
         H005S2_A148EmployeeName = new string[] {""} ;
         ROClassString = "";
         H005S3_A106EmployeeId = new long[1] ;
         H005S3_A148EmployeeName = new string[] {""} ;
         Grid1Column = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_project__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_project__default(),
            new Object[][] {
                new Object[] {
               H005S2_A106EmployeeId, H005S2_A148EmployeeName
               }
               , new Object[] {
               H005S3_A106EmployeeId, H005S3_A148EmployeeName
               }
            }
         );
         /* GeneXus formulas. */
         dynavEmployeeid.Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int Grid1paginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_47 ;
      private int subGrid1_Recordcount ;
      private int subGrid1_Rows ;
      private int nGXsfl_47_idx=1 ;
      private int Grid1paginationbar_Pagestoshow ;
      private int edtavProject_projectname_Enabled ;
      private int edtavProject_projectdescription_Enabled ;
      private int edtavProject_projectmanagerid_Enabled ;
      private int bttBtnenter_Visible ;
      private int edtavGrid1currentpage_Visible ;
      private int edtavProject_projectid_Visible ;
      private int edtavProject_projectmanagername_Visible ;
      private int edtavProject_projectmanageremail_Visible ;
      private int subGrid1_Islastpage ;
      private int edtavDelete_Enabled ;
      private int GRID1_nGridOutOfScope ;
      private int AV9PageToGo ;
      private int AV29GXV9 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV19ProjectId ;
      private long wcpOAV19ProjectId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV11Grid1PageCount ;
      private long AV10Grid1CurrentPage ;
      private long AV6EmployeeId ;
      private long GRID1_nCurrentRecord ;
      private string AV15TrnMode ;
      private string wcpOAV15TrnMode ;
      private string Grid1paginationbar_Selectedpage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_47_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Grid1paginationbar_Class ;
      private string Grid1paginationbar_Pagingbuttonsposition ;
      private string Grid1paginationbar_Pagingcaptionposition ;
      private string Grid1paginationbar_Emptygridclass ;
      private string Grid1paginationbar_Rowsperpageoptions ;
      private string Grid1paginationbar_Previous ;
      private string Grid1paginationbar_Next ;
      private string Grid1paginationbar_Caption ;
      private string Grid1paginationbar_Emptygridcaption ;
      private string Grid1paginationbar_Rowsperpagecaption ;
      private string Grid1_empowerer_Gridinternalname ;
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
      private string edtavProject_projectname_Internalname ;
      private string TempTags ;
      private string edtavProject_projectname_Jsonclick ;
      private string edtavProject_projectdescription_Internalname ;
      private string cmbavProject_projectstatus_Internalname ;
      private string cmbavProject_projectstatus_Jsonclick ;
      private string edtavProject_projectmanagerid_Internalname ;
      private string edtavProject_projectmanagerid_Jsonclick ;
      private string divEmployeetable_Internalname ;
      private string divGrid1tablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string Grid1paginationbar_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavGrid1currentpage_Internalname ;
      private string edtavGrid1currentpage_Jsonclick ;
      private string edtavProject_projectid_Internalname ;
      private string edtavProject_projectid_Jsonclick ;
      private string edtavProject_projectmanagername_Internalname ;
      private string edtavProject_projectmanagername_Jsonclick ;
      private string edtavProject_projectmanageremail_Internalname ;
      private string edtavProject_projectmanageremail_Jsonclick ;
      private string chkavProject_projectmanagerisactive_Internalname ;
      private string Grid1_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string dynavEmployeeid_Internalname ;
      private string AV20delete ;
      private string edtavDelete_Internalname ;
      private string sGXsfl_47_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string GXCCtl ;
      private string dynavEmployeeid_Jsonclick ;
      private string ROClassString ;
      private string edtavDelete_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17CheckRequiredFieldsResult ;
      private bool Grid1paginationbar_Showfirst ;
      private bool Grid1paginationbar_Showprevious ;
      private bool Grid1paginationbar_Shownext ;
      private bool Grid1paginationbar_Showlast ;
      private bool Grid1paginationbar_Rowsperpageselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_47_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV16LoadSuccess ;
      private bool gx_refresh_fired ;
      private string AV12Grid1AppliedFilters ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucGrid1paginationbar ;
      private GXUserControl ucGrid1_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavProject_projectstatus ;
      private GXCombobox dynavEmployeeid ;
      private GXCheckbox chkavProject_projectmanagerisactive ;
      private SdtProject AV7Project ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV14Messages ;
      private GeneXus.Utils.SdtMessages_Message AV13Message ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H005S2_A106EmployeeId ;
      private string[] H005S2_A148EmployeeName ;
      private long[] H005S3_A106EmployeeId ;
      private string[] H005S3_A148EmployeeName ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_project__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_project__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmH005S2;
        prmH005S2 = new Object[] {
        };
        Object[] prmH005S3;
        prmH005S3 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H005S2", "SELECT EmployeeId, EmployeeName FROM Employee ORDER BY EmployeeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005S2,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H005S3", "SELECT EmployeeId, EmployeeName FROM Employee ORDER BY EmployeeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005S3,0, GxCacheFrequency.OFF ,true,false )
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
     }
  }

}

}
