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
namespace GeneXus.Programs.wwpbaseobjects {
   public class savefilteras : GXDataArea
   {
      public savefilteras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public savefilteras( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserKey ,
                           string aP1_GridStateKey )
      {
         this.AV15UserKey = aP0_UserKey;
         this.AV5GridStateKey = aP1_GridStateKey;
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "UserKey");
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
               gxfirstwebparm = GetFirstPar( "UserKey");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "UserKey");
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
               AV15UserKey = gxfirstwebparm;
               AssignAttri("", false, "AV15UserKey", AV15UserKey);
               GxWebStd.gx_hidden_field( context, "gxhash_vUSERKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15UserKey, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV5GridStateKey = GetPar( "GridStateKey");
                  AssignAttri("", false, "AV5GridStateKey", AV5GridStateKey);
                  GxWebStd.gx_hidden_field( context, "gxhash_vGRIDSTATEKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5GridStateKey, "")), context));
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
            return "savefilteras_Execute" ;
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
         PA0P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0P2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
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
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
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
         context.WriteHtmlText( " "+"class=\"FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"FormNoBackgroundColor\" data-gx-class=\"FormNoBackgroundColor\" novalidate action=\""+formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15UserKey)),UrlEncode(StringUtil.RTrim(AV5GridStateKey))}, new string[] {"UserKey","GridStateKey"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vUSERKEY", AV15UserKey);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15UserKey, "")), context));
         GxWebStd.gx_hidden_field( context, "vGRIDSTATEKEY", AV5GridStateKey);
         GxWebStd.gx_hidden_field( context, "gxhash_vGRIDSTATEKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5GridStateKey, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV20CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, "vUSERKEY", AV15UserKey);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15UserKey, "")), context));
         GxWebStd.gx_hidden_field( context, "vGRIDSTATEKEY", AV5GridStateKey);
         GxWebStd.gx_hidden_field( context, "gxhash_vGRIDSTATEKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5GridStateKey, "")), context));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Stoponerror", StringUtil.BoolToStr( Ucmessage_Stoponerror));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0P2( ) ;
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
         return formatLink("wwpbaseobjects.savefilteras.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15UserKey)),UrlEncode(StringUtil.RTrim(AV5GridStateKey))}, new string[] {"UserKey","GridStateKey"})  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SaveFilterAs" ;
      }

      public override string GetPgmdesc( )
      {
         return "Save filter as..." ;
      }

      protected void WB0P0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            wb_table1_2_0P2( true) ;
         }
         else
         {
            wb_table1_2_0P2( false) ;
         }
         return  ;
      }

      protected void wb_table1_2_0P2e( bool wbgen )
      {
         if ( wbgen )
         {
         }
         wbLoad = true;
      }

      protected void START0P2( )
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
         Form.Meta.addItem("description", "Save filter as...", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0P0( ) ;
      }

      protected void WS0P2( )
      {
         START0P2( ) ;
         EVT0P2( ) ;
      }

      protected void EVT0P2( )
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
                              E110P2 ();
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
                                    E120P2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E130P2 ();
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

      protected void WE0P2( )
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

      protected void PA0P2( )
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
               GX_FocusControl = edtavFiltername_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E130P2 ();
            WB0P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0P2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Ucmessage_Stoponerror = StringUtil.StrToBool( cgiGet( "UCMESSAGE_Stoponerror"));
            /* Read variables values. */
            AV8FilterName = cgiGet( edtavFiltername_Internalname);
            AssignAttri("", false, "AV8FilterName", AV8FilterName);
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
         E110P2 ();
         if (returnInSub) return;
      }

      protected void E110P2( )
      {
         /* Start Routine */
         returnInSub = false;
         tblLayoutmaintable_Class = tblLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, tblLayoutmaintable_Internalname, "Class", tblLayoutmaintable_Class, true);
      }

      protected void S112( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV20CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV20CheckRequiredFieldsResult", AV20CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8FilterName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 is required.", "Name", "", "", "", "", "", "", "", ""),  "error",  edtavFiltername_Internalname,  "true",  ""));
            AV20CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV20CheckRequiredFieldsResult", AV20CheckRequiredFieldsResult);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E120P2 ();
         if (returnInSub) return;
      }

      protected void E120P2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV8FilterName = StringUtil.Trim( AV8FilterName);
         AssignAttri("", false, "AV8FilterName", AV8FilterName);
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S112 ();
         if (returnInSub) return;
         if ( AV20CheckRequiredFieldsResult )
         {
            AV10GridStateCollection.FromXml(new WorkWithPlus.workwithplus_web.loadmanagefiltersstate(context).executeUdp(  AV15UserKey), null, "Items", "");
            AV12IsNameUnique = true;
            AV21GXV1 = 1;
            while ( AV21GXV1 <= AV10GridStateCollection.Count )
            {
               AV11GridStateCollectionItem = ((WorkWithPlus.workwithplus_web.SdtGridStateCollection_Item)AV10GridStateCollection.Item(AV21GXV1));
               if ( StringUtil.StrCmp(AV11GridStateCollectionItem.gxTpr_Title, AV8FilterName) == 0 )
               {
                  AV12IsNameUnique = false;
               }
               AV21GXV1 = (int)(AV21GXV1+1);
            }
            if ( AV12IsNameUnique )
            {
               AV11GridStateCollectionItem = new WorkWithPlus.workwithplus_web.SdtGridStateCollection_Item(context);
               AV11GridStateCollectionItem.gxTpr_Title = AV8FilterName;
               AV11GridStateCollectionItem.gxTpr_Gridstatexml = AV6Session.Get(AV5GridStateKey);
               AV10GridStateCollection.Add(AV11GridStateCollectionItem, 1);
               new WorkWithPlus.workwithplus_web.savemanagefiltersstate(context ).execute(  AV15UserKey,  AV10GridStateCollection.ToXml(false, true, "Items", "")) ;
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
            else
            {
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Name must be unique",  "error",  edtavFiltername_Internalname,  "true",  ""));
            }
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E130P2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_2_0P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutmaintable_Internalname, tblLayoutmaintable_Internalname, "", tblLayoutmaintable_Class, 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_5_0P2( true) ;
         }
         else
         {
            wb_table2_5_0P2( false) ;
         }
         return  ;
      }

      protected void wb_table2_5_0P2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_2_0P2e( true) ;
         }
         else
         {
            wb_table1_2_0P2e( false) ;
         }
      }

      protected void wb_table2_5_0P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            sStyleString += " height: " + StringUtil.LTrimStr( (decimal)(150), 10, 0) + "px" + ";";
            sStyleString += " width: " + StringUtil.LTrimStr( (decimal)(380), 10, 0) + "px" + ";";
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableMain", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\" class='PopupContentCell'>") ;
            wb_table3_8_0P2( true) ;
         }
         else
         {
            wb_table3_8_0P2( false) ;
         }
         return  ;
      }

      protected void wb_table3_8_0P2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divActiongroup_actions_Internalname, 1, 0, "px", 0, "px", "ActionGroupRightHTML", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "btn btn-default Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Save", bttBtnenter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SaveFilterAs.htm");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            ClassString = "btn btn-default BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SaveFilterAs.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucUcmessage.SetProperty("StopOnError", Ucmessage_Stoponerror);
            ucUcmessage.Render(context, "dvelop.dvmessage", Ucmessage_Internalname, "UCMESSAGEContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_5_0P2e( true) ;
         }
         else
         {
            wb_table2_5_0P2e( false) ;
         }
      }

      protected void wb_table3_8_0P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablecontent_Internalname, tblTablecontent_Internalname, "", "TableContent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataDescriptionCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfiltername_Internalname, "Name", "", "", lblTextblockfiltername_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SaveFilterAs.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='RequiredDataContentCell'>") ;
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFiltername_Internalname, AV8FilterName, StringUtil.RTrim( context.localUtil.Format( AV8FilterName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltername_Jsonclick, 0, "AttributeManageFilters", "", "", "", "", 1, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SaveFilterAs.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_8_0P2e( true) ;
         }
         else
         {
            wb_table3_8_0P2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15UserKey = (string)getParm(obj,0);
         AssignAttri("", false, "AV15UserKey", AV15UserKey);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15UserKey, "")), context));
         AV5GridStateKey = (string)getParm(obj,1);
         AssignAttri("", false, "AV5GridStateKey", AV5GridStateKey);
         GxWebStd.gx_hidden_field( context, "gxhash_vGRIDSTATEKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5GridStateKey, "")), context));
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
         PA0P2( ) ;
         WS0P2( ) ;
         WE0P2( ) ;
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
         AddStyleSheetFile("DVelop/DVMessage/DVMessage.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256275245329", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/savefilteras.js", "?20256275245330", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockfiltername_Internalname = "TEXTBLOCKFILTERNAME";
         edtavFiltername_Internalname = "vFILTERNAME";
         tblTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divActiongroup_actions_Internalname = "ACTIONGROUP_ACTIONS";
         Ucmessage_Internalname = "UCMESSAGE";
         tblTablemain_Internalname = "TABLEMAIN";
         tblLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         edtavFiltername_Jsonclick = "";
         tblLayoutmaintable_Class = "Table TableTransactionTemplate";
         Ucmessage_Stoponerror = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Save filter as...";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV15UserKey","fld":"vUSERKEY","hsh":true},{"av":"AV5GridStateKey","fld":"vGRIDSTATEKEY","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E120P2","iparms":[{"av":"AV8FilterName","fld":"vFILTERNAME"},{"av":"AV20CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV15UserKey","fld":"vUSERKEY","hsh":true},{"av":"AV5GridStateKey","fld":"vGRIDSTATEKEY","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV8FilterName","fld":"vFILTERNAME"},{"av":"AV20CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
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
         wcpOAV15UserKey = "";
         wcpOAV5GridStateKey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8FilterName = "";
         AV10GridStateCollection = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtGridStateCollection_Item>( context, "Item", "");
         AV11GridStateCollectionItem = new WorkWithPlus.workwithplus_web.SdtGridStateCollection_Item(context);
         AV6Session = context.GetSession();
         sStyleString = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucUcmessage = new GXUserControl();
         lblTextblockfiltername_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV21GXV1 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavFiltername_Internalname ;
      private string tblLayoutmaintable_Class ;
      private string tblLayoutmaintable_Internalname ;
      private string sStyleString ;
      private string tblTablemain_Internalname ;
      private string divActiongroup_actions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string Ucmessage_Internalname ;
      private string tblTablecontent_Internalname ;
      private string lblTextblockfiltername_Internalname ;
      private string lblTextblockfiltername_Jsonclick ;
      private string edtavFiltername_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV20CheckRequiredFieldsResult ;
      private bool Ucmessage_Stoponerror ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12IsNameUnique ;
      private string AV15UserKey ;
      private string AV5GridStateKey ;
      private string wcpOAV15UserKey ;
      private string wcpOAV5GridStateKey ;
      private string AV8FilterName ;
      private IGxSession AV6Session ;
      private GXUserControl ucUcmessage ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtGridStateCollection_Item> AV10GridStateCollection ;
      private WorkWithPlus.workwithplus_web.SdtGridStateCollection_Item AV11GridStateCollectionItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
