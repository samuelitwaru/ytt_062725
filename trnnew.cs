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
   public class trnnew : GXDataArea
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
               AV7TrnNewId = (long)(Math.Round(NumberUtil.Val( GetPar( "TrnNewId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7TrnNewId", StringUtil.LTrimStr( (decimal)(AV7TrnNewId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTRNNEWID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TrnNewId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Trn New", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrnNewName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trnnew( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trnnew( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_TrnNewId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TrnNewId = aP1_TrnNewId;
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
            return "trnnew_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrnNewId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrnNewId_Internalname, "New Id", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrnNewId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A180TrnNewId), 10, 0, ".", "")), StringUtil.LTrim( ((edtTrnNewId_Enabled!=0) ? context.localUtil.Format( (decimal)(A180TrnNewId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A180TrnNewId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrnNewId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrnNewId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_TrnNew.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrnNewName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrnNewName_Internalname, "New Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrnNewName_Internalname, StringUtil.RTrim( A181TrnNewName), StringUtil.RTrim( context.localUtil.Format( A181TrnNewName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrnNewName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrnNewName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_TrnNew.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrnNewDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrnNewDate_Internalname, "New Date", " AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrnNewDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrnNewDate_Internalname, context.localUtil.Format(A182TrnNewDate, "99/99/99"), context.localUtil.Format( A182TrnNewDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrnNewDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtTrnNewDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TrnNew.htm");
         GxWebStd.gx_bitmap( context, edtTrnNewDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrnNewDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrnNew.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgTrnNewImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "New Image", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A183TrnNewImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A183TrnNewImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000TrnNewImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A183TrnNewImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A183TrnNewImage)) ? A40000TrnNewImage_GXI : context.PathToRelativeUrl( A183TrnNewImage));
         GxWebStd.gx_bitmap( context, imgTrnNewImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgTrnNewImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", "", "", 0, A183TrnNewImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_TrnNew.htm");
         AssignProp("", false, imgTrnNewImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A183TrnNewImage)) ? A40000TrnNewImage_GXI : context.PathToRelativeUrl( A183TrnNewImage)), true);
         AssignProp("", false, imgTrnNewImage_Internalname, "IsBlob", StringUtil.BoolToStr( A183TrnNewImage_IsBlob), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrnNew.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrnNew.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrnNew.htm");
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
         E110P2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z180TrnNewId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z180TrnNewId"), ".", ","), 18, MidpointRounding.ToEven));
               Z181TrnNewName = cgiGet( "Z181TrnNewName");
               Z182TrnNewDate = context.localUtil.CToD( cgiGet( "Z182TrnNewDate"), 0);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7TrnNewId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vTRNNEWID"), ".", ","), 18, MidpointRounding.ToEven));
               A40000TrnNewImage_GXI = cgiGet( "TRNNEWIMAGE_GXI");
               /* Read variables values. */
               A180TrnNewId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTrnNewId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
               A181TrnNewName = cgiGet( edtTrnNewName_Internalname);
               AssignAttri("", false, "A181TrnNewName", A181TrnNewName);
               if ( context.localUtil.VCDate( cgiGet( edtTrnNewDate_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Trn New Date"}), 1, "TRNNEWDATE");
                  AnyError = 1;
                  GX_FocusControl = edtTrnNewDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A182TrnNewDate = DateTime.MinValue;
                  AssignAttri("", false, "A182TrnNewDate", context.localUtil.Format(A182TrnNewDate, "99/99/99"));
               }
               else
               {
                  A182TrnNewDate = context.localUtil.CToD( cgiGet( edtTrnNewDate_Internalname), 2);
                  AssignAttri("", false, "A182TrnNewDate", context.localUtil.Format(A182TrnNewDate, "99/99/99"));
               }
               A183TrnNewImage = cgiGet( imgTrnNewImage_Internalname);
               AssignAttri("", false, "A183TrnNewImage", A183TrnNewImage);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgTrnNewImage_Internalname, ref  A183TrnNewImage, ref  A40000TrnNewImage_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TrnNew");
               A180TrnNewId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTrnNewId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
               forbiddenHiddens.Add("TrnNewId", context.localUtil.Format( (decimal)(A180TrnNewId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A180TrnNewId != Z180TrnNewId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("trnnew:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A180TrnNewId = (long)(Math.Round(NumberUtil.Val( GetPar( "TrnNewId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
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
                     sMode28 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode28;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound28 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0P0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TRNNEWID");
                        AnyError = 1;
                        GX_FocusControl = edtTrnNewId_Internalname;
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
                           E110P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120P2 ();
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
            E120P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0P28( ) ;
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
            DisableAttributes0P28( ) ;
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

      protected void CONFIRM_0P0( )
      {
         BeforeValidate0P28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0P28( ) ;
            }
            else
            {
               CheckExtendedTable0P28( ) ;
               CloseExtendedTableCursors0P28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0P0( )
      {
      }

      protected void E110P2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("trnnewww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0P28( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z181TrnNewName = T000P3_A181TrnNewName[0];
               Z182TrnNewDate = T000P3_A182TrnNewDate[0];
            }
            else
            {
               Z181TrnNewName = A181TrnNewName;
               Z182TrnNewDate = A182TrnNewDate;
            }
         }
         if ( GX_JID == -3 )
         {
            Z180TrnNewId = A180TrnNewId;
            Z181TrnNewName = A181TrnNewName;
            Z182TrnNewDate = A182TrnNewDate;
            Z183TrnNewImage = A183TrnNewImage;
            Z40000TrnNewImage_GXI = A40000TrnNewImage_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTrnNewId_Enabled = 0;
         AssignProp("", false, edtTrnNewId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrnNewId_Enabled), 5, 0), true);
         edtTrnNewId_Enabled = 0;
         AssignProp("", false, edtTrnNewId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrnNewId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TrnNewId) )
         {
            A180TrnNewId = AV7TrnNewId;
            AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
         }
      }

      protected void standaloneModal( )
      {
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

      protected void Load0P28( )
      {
         /* Using cursor T000P4 */
         pr_default.execute(2, new Object[] {A180TrnNewId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound28 = 1;
            A181TrnNewName = T000P4_A181TrnNewName[0];
            AssignAttri("", false, "A181TrnNewName", A181TrnNewName);
            A182TrnNewDate = T000P4_A182TrnNewDate[0];
            AssignAttri("", false, "A182TrnNewDate", context.localUtil.Format(A182TrnNewDate, "99/99/99"));
            A40000TrnNewImage_GXI = T000P4_A40000TrnNewImage_GXI[0];
            AssignProp("", false, imgTrnNewImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A183TrnNewImage)) ? A40000TrnNewImage_GXI : context.convertURL( context.PathToRelativeUrl( A183TrnNewImage))), true);
            AssignProp("", false, imgTrnNewImage_Internalname, "SrcSet", context.GetImageSrcSet( A183TrnNewImage), true);
            A183TrnNewImage = T000P4_A183TrnNewImage[0];
            AssignAttri("", false, "A183TrnNewImage", A183TrnNewImage);
            AssignProp("", false, imgTrnNewImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A183TrnNewImage)) ? A40000TrnNewImage_GXI : context.convertURL( context.PathToRelativeUrl( A183TrnNewImage))), true);
            AssignProp("", false, imgTrnNewImage_Internalname, "SrcSet", context.GetImageSrcSet( A183TrnNewImage), true);
            ZM0P28( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0P28( ) ;
      }

      protected void OnLoadActions0P28( )
      {
      }

      protected void CheckExtendedTable0P28( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0P28( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0P28( )
      {
         /* Using cursor T000P5 */
         pr_default.execute(3, new Object[] {A180TrnNewId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000P3 */
         pr_default.execute(1, new Object[] {A180TrnNewId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0P28( 3) ;
            RcdFound28 = 1;
            A180TrnNewId = T000P3_A180TrnNewId[0];
            AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
            A181TrnNewName = T000P3_A181TrnNewName[0];
            AssignAttri("", false, "A181TrnNewName", A181TrnNewName);
            A182TrnNewDate = T000P3_A182TrnNewDate[0];
            AssignAttri("", false, "A182TrnNewDate", context.localUtil.Format(A182TrnNewDate, "99/99/99"));
            A40000TrnNewImage_GXI = T000P3_A40000TrnNewImage_GXI[0];
            AssignProp("", false, imgTrnNewImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A183TrnNewImage)) ? A40000TrnNewImage_GXI : context.convertURL( context.PathToRelativeUrl( A183TrnNewImage))), true);
            AssignProp("", false, imgTrnNewImage_Internalname, "SrcSet", context.GetImageSrcSet( A183TrnNewImage), true);
            A183TrnNewImage = T000P3_A183TrnNewImage[0];
            AssignAttri("", false, "A183TrnNewImage", A183TrnNewImage);
            AssignProp("", false, imgTrnNewImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A183TrnNewImage)) ? A40000TrnNewImage_GXI : context.convertURL( context.PathToRelativeUrl( A183TrnNewImage))), true);
            AssignProp("", false, imgTrnNewImage_Internalname, "SrcSet", context.GetImageSrcSet( A183TrnNewImage), true);
            Z180TrnNewId = A180TrnNewId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0P28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0P28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0P28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0P28( ) ;
         if ( RcdFound28 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound28 = 0;
         /* Using cursor T000P6 */
         pr_default.execute(4, new Object[] {A180TrnNewId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000P6_A180TrnNewId[0] < A180TrnNewId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000P6_A180TrnNewId[0] > A180TrnNewId ) ) )
            {
               A180TrnNewId = T000P6_A180TrnNewId[0];
               AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T000P7 */
         pr_default.execute(5, new Object[] {A180TrnNewId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000P7_A180TrnNewId[0] > A180TrnNewId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000P7_A180TrnNewId[0] < A180TrnNewId ) ) )
            {
               A180TrnNewId = T000P7_A180TrnNewId[0];
               AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0P28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrnNewName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0P28( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A180TrnNewId != Z180TrnNewId )
               {
                  A180TrnNewId = Z180TrnNewId;
                  AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRNNEWID");
                  AnyError = 1;
                  GX_FocusControl = edtTrnNewId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrnNewName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0P28( ) ;
                  GX_FocusControl = edtTrnNewName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A180TrnNewId != Z180TrnNewId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTrnNewName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0P28( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRNNEWID");
                     AnyError = 1;
                     GX_FocusControl = edtTrnNewId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTrnNewName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0P28( ) ;
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
         if ( A180TrnNewId != Z180TrnNewId )
         {
            A180TrnNewId = Z180TrnNewId;
            AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRNNEWID");
            AnyError = 1;
            GX_FocusControl = edtTrnNewId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrnNewName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0P28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000P2 */
            pr_default.execute(0, new Object[] {A180TrnNewId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrnNew"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z181TrnNewName, T000P2_A181TrnNewName[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z182TrnNewDate ) != DateTimeUtil.ResetTime ( T000P2_A182TrnNewDate[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z181TrnNewName, T000P2_A181TrnNewName[0]) != 0 )
               {
                  GXUtil.WriteLog("trnnew:[seudo value changed for attri]"+"TrnNewName");
                  GXUtil.WriteLogRaw("Old: ",Z181TrnNewName);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A181TrnNewName[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z182TrnNewDate ) != DateTimeUtil.ResetTime ( T000P2_A182TrnNewDate[0] ) )
               {
                  GXUtil.WriteLog("trnnew:[seudo value changed for attri]"+"TrnNewDate");
                  GXUtil.WriteLogRaw("Old: ",Z182TrnNewDate);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A182TrnNewDate[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrnNew"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0P28( )
      {
         if ( ! IsAuthorized("trnnew_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0P28( 0) ;
            CheckOptimisticConcurrency0P28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0P28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P8 */
                     pr_default.execute(6, new Object[] {A181TrnNewName, A182TrnNewDate, A183TrnNewImage, A40000TrnNewImage_GXI});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000P9 */
                     pr_default.execute(7);
                     A180TrnNewId = T000P9_A180TrnNewId[0];
                     AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("TrnNew");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0P0( ) ;
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
               Load0P28( ) ;
            }
            EndLevel0P28( ) ;
         }
         CloseExtendedTableCursors0P28( ) ;
      }

      protected void Update0P28( )
      {
         if ( ! IsAuthorized("trnnew_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0P28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P10 */
                     pr_default.execute(8, new Object[] {A181TrnNewName, A182TrnNewDate, A180TrnNewId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("TrnNew");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrnNew"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0P28( ) ;
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
            EndLevel0P28( ) ;
         }
         CloseExtendedTableCursors0P28( ) ;
      }

      protected void DeferredUpdate0P28( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000P11 */
            pr_default.execute(9, new Object[] {A183TrnNewImage, A40000TrnNewImage_GXI, A180TrnNewId});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("TrnNew");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trnnew_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0P28( ) ;
            AfterConfirm0P28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0P28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000P12 */
                  pr_default.execute(10, new Object[] {A180TrnNewId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("TrnNew");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0P28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0P28( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0P28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0P28( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trnnew",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trnnew",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0P28( )
      {
         /* Scan By routine */
         /* Using cursor T000P13 */
         pr_default.execute(11);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound28 = 1;
            A180TrnNewId = T000P13_A180TrnNewId[0];
            AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0P28( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound28 = 1;
            A180TrnNewId = T000P13_A180TrnNewId[0];
            AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
         }
      }

      protected void ScanEnd0P28( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0P28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0P28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0P28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0P28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0P28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0P28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0P28( )
      {
         edtTrnNewId_Enabled = 0;
         AssignProp("", false, edtTrnNewId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrnNewId_Enabled), 5, 0), true);
         edtTrnNewName_Enabled = 0;
         AssignProp("", false, edtTrnNewName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrnNewName_Enabled), 5, 0), true);
         edtTrnNewDate_Enabled = 0;
         AssignProp("", false, edtTrnNewDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrnNewDate_Enabled), 5, 0), true);
         imgTrnNewImage_Enabled = 0;
         AssignProp("", false, imgTrnNewImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgTrnNewImage_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0P28( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0P0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trnnew.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7TrnNewId,10,0))}, new string[] {"Gx_mode","TrnNewId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TrnNew");
         forbiddenHiddens.Add("TrnNewId", context.localUtil.Format( (decimal)(A180TrnNewId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("trnnew:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z180TrnNewId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180TrnNewId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z181TrnNewName", StringUtil.RTrim( Z181TrnNewName));
         GxWebStd.gx_hidden_field( context, "Z182TrnNewDate", context.localUtil.DToC( Z182TrnNewDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "vTRNNEWID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TrnNewId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNNEWID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TrnNewId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRNNEWIMAGE_GXI", A40000TrnNewImage_GXI);
         GXCCtlgxBlob = "TRNNEWIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A183TrnNewImage);
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
         return formatLink("trnnew.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7TrnNewId,10,0))}, new string[] {"Gx_mode","TrnNewId"})  ;
      }

      public override string GetPgmname( )
      {
         return "TrnNew" ;
      }

      public override string GetPgmdesc( )
      {
         return "Trn New" ;
      }

      protected void InitializeNonKey0P28( )
      {
         A181TrnNewName = "";
         AssignAttri("", false, "A181TrnNewName", A181TrnNewName);
         A182TrnNewDate = DateTime.MinValue;
         AssignAttri("", false, "A182TrnNewDate", context.localUtil.Format(A182TrnNewDate, "99/99/99"));
         A183TrnNewImage = "";
         AssignAttri("", false, "A183TrnNewImage", A183TrnNewImage);
         AssignProp("", false, imgTrnNewImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A183TrnNewImage)) ? A40000TrnNewImage_GXI : context.convertURL( context.PathToRelativeUrl( A183TrnNewImage))), true);
         AssignProp("", false, imgTrnNewImage_Internalname, "SrcSet", context.GetImageSrcSet( A183TrnNewImage), true);
         A40000TrnNewImage_GXI = "";
         AssignProp("", false, imgTrnNewImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A183TrnNewImage)) ? A40000TrnNewImage_GXI : context.convertURL( context.PathToRelativeUrl( A183TrnNewImage))), true);
         AssignProp("", false, imgTrnNewImage_Internalname, "SrcSet", context.GetImageSrcSet( A183TrnNewImage), true);
         Z181TrnNewName = "";
         Z182TrnNewDate = DateTime.MinValue;
      }

      protected void InitAll0P28( )
      {
         A180TrnNewId = 0;
         AssignAttri("", false, "A180TrnNewId", StringUtil.LTrimStr( (decimal)(A180TrnNewId), 10, 0));
         InitializeNonKey0P28( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257120595834", true, true);
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
         context.AddJavascriptSource("trnnew.js", "?20257120595834", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtTrnNewId_Internalname = "TRNNEWID";
         edtTrnNewName_Internalname = "TRNNEWNAME";
         edtTrnNewDate_Internalname = "TRNNEWDATE";
         imgTrnNewImage_Internalname = "TRNNEWIMAGE";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Trn New";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgTrnNewImage_Enabled = 1;
         edtTrnNewDate_Jsonclick = "";
         edtTrnNewDate_Enabled = 1;
         edtTrnNewName_Jsonclick = "";
         edtTrnNewName_Enabled = 1;
         edtTrnNewId_Jsonclick = "";
         edtTrnNewId_Enabled = 0;
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7TrnNewId","fld":"vTRNNEWID","pic":"ZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7TrnNewId","fld":"vTRNNEWID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A180TrnNewId","fld":"TRNNEWID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120P2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_TRNNEWID","""{"handler":"Valid_Trnnewid","iparms":[]}""");
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
         Z181TrnNewName = "";
         Z182TrnNewDate = DateTime.MinValue;
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
         A181TrnNewName = "";
         A182TrnNewDate = DateTime.MinValue;
         A183TrnNewImage = "";
         A40000TrnNewImage_GXI = "";
         sImgUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode28 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z183TrnNewImage = "";
         Z40000TrnNewImage_GXI = "";
         T000P4_A180TrnNewId = new long[1] ;
         T000P4_A181TrnNewName = new string[] {""} ;
         T000P4_A182TrnNewDate = new DateTime[] {DateTime.MinValue} ;
         T000P4_A40000TrnNewImage_GXI = new string[] {""} ;
         T000P4_A183TrnNewImage = new string[] {""} ;
         T000P5_A180TrnNewId = new long[1] ;
         T000P3_A180TrnNewId = new long[1] ;
         T000P3_A181TrnNewName = new string[] {""} ;
         T000P3_A182TrnNewDate = new DateTime[] {DateTime.MinValue} ;
         T000P3_A40000TrnNewImage_GXI = new string[] {""} ;
         T000P3_A183TrnNewImage = new string[] {""} ;
         T000P6_A180TrnNewId = new long[1] ;
         T000P7_A180TrnNewId = new long[1] ;
         T000P2_A180TrnNewId = new long[1] ;
         T000P2_A181TrnNewName = new string[] {""} ;
         T000P2_A182TrnNewDate = new DateTime[] {DateTime.MinValue} ;
         T000P2_A40000TrnNewImage_GXI = new string[] {""} ;
         T000P2_A183TrnNewImage = new string[] {""} ;
         T000P9_A180TrnNewId = new long[1] ;
         T000P13_A180TrnNewId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trnnew__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trnnew__default(),
            new Object[][] {
                new Object[] {
               T000P2_A180TrnNewId, T000P2_A181TrnNewName, T000P2_A182TrnNewDate, T000P2_A40000TrnNewImage_GXI, T000P2_A183TrnNewImage
               }
               , new Object[] {
               T000P3_A180TrnNewId, T000P3_A181TrnNewName, T000P3_A182TrnNewDate, T000P3_A40000TrnNewImage_GXI, T000P3_A183TrnNewImage
               }
               , new Object[] {
               T000P4_A180TrnNewId, T000P4_A181TrnNewName, T000P4_A182TrnNewDate, T000P4_A40000TrnNewImage_GXI, T000P4_A183TrnNewImage
               }
               , new Object[] {
               T000P5_A180TrnNewId
               }
               , new Object[] {
               T000P6_A180TrnNewId
               }
               , new Object[] {
               T000P7_A180TrnNewId
               }
               , new Object[] {
               }
               , new Object[] {
               T000P9_A180TrnNewId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000P13_A180TrnNewId
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
      private short RcdFound28 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtTrnNewId_Enabled ;
      private int edtTrnNewName_Enabled ;
      private int edtTrnNewDate_Enabled ;
      private int imgTrnNewImage_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int idxLst ;
      private long wcpOAV7TrnNewId ;
      private long Z180TrnNewId ;
      private long AV7TrnNewId ;
      private long A180TrnNewId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z181TrnNewName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrnNewName_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divLefttable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtTrnNewId_Internalname ;
      private string TempTags ;
      private string edtTrnNewId_Jsonclick ;
      private string A181TrnNewName ;
      private string edtTrnNewName_Jsonclick ;
      private string edtTrnNewDate_Internalname ;
      private string edtTrnNewDate_Jsonclick ;
      private string imgTrnNewImage_Internalname ;
      private string sImgUrl ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divRighttable_Internalname ;
      private string hsh ;
      private string sMode28 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private DateTime Z182TrnNewDate ;
      private DateTime A182TrnNewDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A183TrnNewImage_IsBlob ;
      private bool returnInSub ;
      private string A40000TrnNewImage_GXI ;
      private string Z40000TrnNewImage_GXI ;
      private string A183TrnNewImage ;
      private string Z183TrnNewImage ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T000P4_A180TrnNewId ;
      private string[] T000P4_A181TrnNewName ;
      private DateTime[] T000P4_A182TrnNewDate ;
      private string[] T000P4_A40000TrnNewImage_GXI ;
      private string[] T000P4_A183TrnNewImage ;
      private long[] T000P5_A180TrnNewId ;
      private long[] T000P3_A180TrnNewId ;
      private string[] T000P3_A181TrnNewName ;
      private DateTime[] T000P3_A182TrnNewDate ;
      private string[] T000P3_A40000TrnNewImage_GXI ;
      private string[] T000P3_A183TrnNewImage ;
      private long[] T000P6_A180TrnNewId ;
      private long[] T000P7_A180TrnNewId ;
      private long[] T000P2_A180TrnNewId ;
      private string[] T000P2_A181TrnNewName ;
      private DateTime[] T000P2_A182TrnNewDate ;
      private string[] T000P2_A40000TrnNewImage_GXI ;
      private string[] T000P2_A183TrnNewImage ;
      private long[] T000P9_A180TrnNewId ;
      private long[] T000P13_A180TrnNewId ;
      private IDataStoreProvider pr_gam ;
   }

   public class trnnew__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class trnnew__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000P2;
        prmT000P2 = new Object[] {
        new ParDef("TrnNewId",GXType.Int64,10,0)
        };
        Object[] prmT000P3;
        prmT000P3 = new Object[] {
        new ParDef("TrnNewId",GXType.Int64,10,0)
        };
        Object[] prmT000P4;
        prmT000P4 = new Object[] {
        new ParDef("TrnNewId",GXType.Int64,10,0)
        };
        Object[] prmT000P5;
        prmT000P5 = new Object[] {
        new ParDef("TrnNewId",GXType.Int64,10,0)
        };
        Object[] prmT000P6;
        prmT000P6 = new Object[] {
        new ParDef("TrnNewId",GXType.Int64,10,0)
        };
        Object[] prmT000P7;
        prmT000P7 = new Object[] {
        new ParDef("TrnNewId",GXType.Int64,10,0)
        };
        Object[] prmT000P8;
        prmT000P8 = new Object[] {
        new ParDef("TrnNewName",GXType.Char,100,0) ,
        new ParDef("TrnNewDate",GXType.Date,8,0) ,
        new ParDef("TrnNewImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("TrnNewImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="TrnNew", Fld="TrnNewImage"}
        };
        Object[] prmT000P9;
        prmT000P9 = new Object[] {
        };
        Object[] prmT000P10;
        prmT000P10 = new Object[] {
        new ParDef("TrnNewName",GXType.Char,100,0) ,
        new ParDef("TrnNewDate",GXType.Date,8,0) ,
        new ParDef("TrnNewId",GXType.Int64,10,0)
        };
        Object[] prmT000P11;
        prmT000P11 = new Object[] {
        new ParDef("TrnNewImage",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("TrnNewImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="TrnNew", Fld="TrnNewImage"} ,
        new ParDef("TrnNewId",GXType.Int64,10,0)
        };
        Object[] prmT000P12;
        prmT000P12 = new Object[] {
        new ParDef("TrnNewId",GXType.Int64,10,0)
        };
        Object[] prmT000P13;
        prmT000P13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000P2", "SELECT TrnNewId, TrnNewName, TrnNewDate, TrnNewImage_GXI, TrnNewImage FROM TrnNew WHERE TrnNewId = :TrnNewId  FOR UPDATE OF TrnNew NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P3", "SELECT TrnNewId, TrnNewName, TrnNewDate, TrnNewImage_GXI, TrnNewImage FROM TrnNew WHERE TrnNewId = :TrnNewId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P4", "SELECT TM1.TrnNewId, TM1.TrnNewName, TM1.TrnNewDate, TM1.TrnNewImage_GXI, TM1.TrnNewImage FROM TrnNew TM1 WHERE TM1.TrnNewId = :TrnNewId ORDER BY TM1.TrnNewId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P5", "SELECT TrnNewId FROM TrnNew WHERE TrnNewId = :TrnNewId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P6", "SELECT TrnNewId FROM TrnNew WHERE ( TrnNewId > :TrnNewId) ORDER BY TrnNewId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P7", "SELECT TrnNewId FROM TrnNew WHERE ( TrnNewId < :TrnNewId) ORDER BY TrnNewId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P8", "SAVEPOINT gxupdate;INSERT INTO TrnNew(TrnNewName, TrnNewDate, TrnNewImage, TrnNewImage_GXI) VALUES(:TrnNewName, :TrnNewDate, :TrnNewImage, :TrnNewImage_GXI);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000P8)
           ,new CursorDef("T000P9", "SELECT currval('TrnNewId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P10", "SAVEPOINT gxupdate;UPDATE TrnNew SET TrnNewName=:TrnNewName, TrnNewDate=:TrnNewDate  WHERE TrnNewId = :TrnNewId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000P10)
           ,new CursorDef("T000P11", "SAVEPOINT gxupdate;UPDATE TrnNew SET TrnNewImage=:TrnNewImage, TrnNewImage_GXI=:TrnNewImage_GXI  WHERE TrnNewId = :TrnNewId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000P11)
           ,new CursorDef("T000P12", "SAVEPOINT gxupdate;DELETE FROM TrnNew  WHERE TrnNewId = :TrnNewId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000P12)
           ,new CursorDef("T000P13", "SELECT TrnNewId FROM TrnNew ORDER BY TrnNewId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P13,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
