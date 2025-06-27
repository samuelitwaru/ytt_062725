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
   public class project : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action12") == 0 )
         {
            A162ProjectManagerId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectManagerId"), "."), 18, MidpointRounding.ToEven));
            n162ProjectManagerId = false;
            AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
            A102ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_12_0E15( A162ProjectManagerId, A102ProjectId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A162ProjectManagerId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectManagerId"), "."), 18, MidpointRounding.ToEven));
            n162ProjectManagerId = false;
            AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
            A102ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A162ProjectManagerId, A102ProjectId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A162ProjectManagerId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectManagerId"), "."), 18, MidpointRounding.ToEven));
            n162ProjectManagerId = false;
            AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A162ProjectManagerId) ;
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
               AV7ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7ProjectId", StringUtil.LTrimStr( (decimal)(AV7ProjectId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProjectId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Project", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public project( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public project( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ProjectId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProjectId = aP1_ProjectId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbProjectStatus = new GXCombobox();
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
            return "project_Execute" ;
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
         if ( cmbProjectStatus.ItemCount > 0 )
         {
            A105ProjectStatus = cmbProjectStatus.getValidValue(A105ProjectStatus);
            AssignAttri("", false, "A105ProjectStatus", A105ProjectStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProjectStatus.CurrentValue = StringUtil.RTrim( A105ProjectStatus);
            AssignProp("", false, cmbProjectStatus_Internalname, "Values", cmbProjectStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProjectName_Internalname, StringUtil.RTrim( A103ProjectName), StringUtil.RTrim( context.localUtil.Format( A103ProjectName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProjectName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProjectName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Project.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProjectDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProjectDescription_Internalname, "Description", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProjectDescription_Internalname, A104ProjectDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", 0, 1, edtProjectDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Project.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProjectStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProjectStatus_Internalname, "Status", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProjectStatus, cmbProjectStatus_Internalname, StringUtil.RTrim( A105ProjectStatus), 1, cmbProjectStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProjectStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_Project.htm");
         cmbProjectStatus.CurrentValue = StringUtil.RTrim( A105ProjectStatus);
         AssignProp("", false, cmbProjectStatus_Internalname, "Values", (string)(cmbProjectStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedprojectmanagerid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprojectmanagerid_Internalname, "Project Manager", "", "", lblTextblockprojectmanagerid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Project.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_projectmanagerid.SetProperty("Caption", Combo_projectmanagerid_Caption);
         ucCombo_projectmanagerid.SetProperty("Cls", Combo_projectmanagerid_Cls);
         ucCombo_projectmanagerid.SetProperty("EmptyItem", Combo_projectmanagerid_Emptyitem);
         ucCombo_projectmanagerid.SetProperty("DropDownOptionsTitleSettingsIcons", AV24DDO_TitleSettingsIcons);
         ucCombo_projectmanagerid.SetProperty("DropDownOptionsData", AV21ProjectManagerId_Data);
         ucCombo_projectmanagerid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_projectmanagerid_Internalname, "COMBO_PROJECTMANAGERIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProjectManagerId_Internalname, "Project Manager Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProjectManagerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A162ProjectManagerId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A162ProjectManagerId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProjectManagerId_Jsonclick, 0, "Attribute", "", "", "", "", edtProjectManagerId_Visible, edtProjectManagerId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Project.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Project.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Project.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Project.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_projectmanagerid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboprojectmanagerid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ComboProjectManagerId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavComboprojectmanagerid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV22ComboProjectManagerId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV22ComboProjectManagerId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprojectmanagerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprojectmanagerid_Visible, edtavComboprojectmanagerid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Project.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProjectId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")), StringUtil.LTrim( ((edtProjectId_Enabled!=0) ? context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProjectId_Jsonclick, 0, "Attribute", "", "", "", "", edtProjectId_Visible, edtProjectId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Project.htm");
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
         E110E2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV24DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPROJECTMANAGERID_DATA"), AV21ProjectManagerId_Data);
               /* Read saved values. */
               Z102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z102ProjectId"), ".", ","), 18, MidpointRounding.ToEven));
               Z103ProjectName = cgiGet( "Z103ProjectName");
               Z104ProjectDescription = cgiGet( "Z104ProjectDescription");
               Z105ProjectStatus = cgiGet( "Z105ProjectStatus");
               Z162ProjectManagerId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z162ProjectManagerId"), ".", ","), 18, MidpointRounding.ToEven));
               n162ProjectManagerId = ((0==A162ProjectManagerId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N162ProjectManagerId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N162ProjectManagerId"), ".", ","), 18, MidpointRounding.ToEven));
               n162ProjectManagerId = ((0==A162ProjectManagerId) ? true : false);
               AV7ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPROJECTID"), ".", ","), 18, MidpointRounding.ToEven));
               AV20Insert_ProjectManagerId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROJECTMANAGERID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               A163ProjectManagerName = cgiGet( "PROJECTMANAGERNAME");
               A175ProjectManagerEmail = cgiGet( "PROJECTMANAGEREMAIL");
               A176ProjectManagerIsActive = StringUtil.StrToBool( cgiGet( "PROJECTMANAGERISACTIVE"));
               AV32Pgmname = cgiGet( "vPGMNAME");
               Combo_projectmanagerid_Objectcall = cgiGet( "COMBO_PROJECTMANAGERID_Objectcall");
               Combo_projectmanagerid_Class = cgiGet( "COMBO_PROJECTMANAGERID_Class");
               Combo_projectmanagerid_Icontype = cgiGet( "COMBO_PROJECTMANAGERID_Icontype");
               Combo_projectmanagerid_Icon = cgiGet( "COMBO_PROJECTMANAGERID_Icon");
               Combo_projectmanagerid_Caption = cgiGet( "COMBO_PROJECTMANAGERID_Caption");
               Combo_projectmanagerid_Tooltip = cgiGet( "COMBO_PROJECTMANAGERID_Tooltip");
               Combo_projectmanagerid_Cls = cgiGet( "COMBO_PROJECTMANAGERID_Cls");
               Combo_projectmanagerid_Selectedvalue_set = cgiGet( "COMBO_PROJECTMANAGERID_Selectedvalue_set");
               Combo_projectmanagerid_Selectedvalue_get = cgiGet( "COMBO_PROJECTMANAGERID_Selectedvalue_get");
               Combo_projectmanagerid_Selectedtext_set = cgiGet( "COMBO_PROJECTMANAGERID_Selectedtext_set");
               Combo_projectmanagerid_Selectedtext_get = cgiGet( "COMBO_PROJECTMANAGERID_Selectedtext_get");
               Combo_projectmanagerid_Gamoauthtoken = cgiGet( "COMBO_PROJECTMANAGERID_Gamoauthtoken");
               Combo_projectmanagerid_Ddointernalname = cgiGet( "COMBO_PROJECTMANAGERID_Ddointernalname");
               Combo_projectmanagerid_Titlecontrolalign = cgiGet( "COMBO_PROJECTMANAGERID_Titlecontrolalign");
               Combo_projectmanagerid_Dropdownoptionstype = cgiGet( "COMBO_PROJECTMANAGERID_Dropdownoptionstype");
               Combo_projectmanagerid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTMANAGERID_Enabled"));
               Combo_projectmanagerid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTMANAGERID_Visible"));
               Combo_projectmanagerid_Titlecontrolidtoreplace = cgiGet( "COMBO_PROJECTMANAGERID_Titlecontrolidtoreplace");
               Combo_projectmanagerid_Datalisttype = cgiGet( "COMBO_PROJECTMANAGERID_Datalisttype");
               Combo_projectmanagerid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTMANAGERID_Allowmultipleselection"));
               Combo_projectmanagerid_Datalistfixedvalues = cgiGet( "COMBO_PROJECTMANAGERID_Datalistfixedvalues");
               Combo_projectmanagerid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTMANAGERID_Isgriditem"));
               Combo_projectmanagerid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTMANAGERID_Hasdescription"));
               Combo_projectmanagerid_Datalistproc = cgiGet( "COMBO_PROJECTMANAGERID_Datalistproc");
               Combo_projectmanagerid_Datalistprocparametersprefix = cgiGet( "COMBO_PROJECTMANAGERID_Datalistprocparametersprefix");
               Combo_projectmanagerid_Remoteservicesparameters = cgiGet( "COMBO_PROJECTMANAGERID_Remoteservicesparameters");
               Combo_projectmanagerid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROJECTMANAGERID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_projectmanagerid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTMANAGERID_Includeonlyselectedoption"));
               Combo_projectmanagerid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTMANAGERID_Includeselectalloption"));
               Combo_projectmanagerid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTMANAGERID_Emptyitem"));
               Combo_projectmanagerid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTMANAGERID_Includeaddnewoption"));
               Combo_projectmanagerid_Htmltemplate = cgiGet( "COMBO_PROJECTMANAGERID_Htmltemplate");
               Combo_projectmanagerid_Multiplevaluestype = cgiGet( "COMBO_PROJECTMANAGERID_Multiplevaluestype");
               Combo_projectmanagerid_Loadingdata = cgiGet( "COMBO_PROJECTMANAGERID_Loadingdata");
               Combo_projectmanagerid_Noresultsfound = cgiGet( "COMBO_PROJECTMANAGERID_Noresultsfound");
               Combo_projectmanagerid_Emptyitemtext = cgiGet( "COMBO_PROJECTMANAGERID_Emptyitemtext");
               Combo_projectmanagerid_Onlyselectedvalues = cgiGet( "COMBO_PROJECTMANAGERID_Onlyselectedvalues");
               Combo_projectmanagerid_Selectalltext = cgiGet( "COMBO_PROJECTMANAGERID_Selectalltext");
               Combo_projectmanagerid_Multiplevaluesseparator = cgiGet( "COMBO_PROJECTMANAGERID_Multiplevaluesseparator");
               Combo_projectmanagerid_Addnewoptiontext = cgiGet( "COMBO_PROJECTMANAGERID_Addnewoptiontext");
               Combo_projectmanagerid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROJECTMANAGERID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( "DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               /* Read variables values. */
               A103ProjectName = cgiGet( edtProjectName_Internalname);
               AssignAttri("", false, "A103ProjectName", A103ProjectName);
               A104ProjectDescription = cgiGet( edtProjectDescription_Internalname);
               AssignAttri("", false, "A104ProjectDescription", A104ProjectDescription);
               cmbProjectStatus.CurrentValue = cgiGet( cmbProjectStatus_Internalname);
               A105ProjectStatus = cgiGet( cmbProjectStatus_Internalname);
               AssignAttri("", false, "A105ProjectStatus", A105ProjectStatus);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProjectManagerId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProjectManagerId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROJECTMANAGERID");
                  AnyError = 1;
                  GX_FocusControl = edtProjectManagerId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A162ProjectManagerId = 0;
                  n162ProjectManagerId = false;
                  AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
               }
               else
               {
                  A162ProjectManagerId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProjectManagerId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  n162ProjectManagerId = false;
                  AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
               }
               n162ProjectManagerId = ((0==A162ProjectManagerId) ? true : false);
               AV22ComboProjectManagerId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboprojectmanagerid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22ComboProjectManagerId", StringUtil.LTrimStr( (decimal)(AV22ComboProjectManagerId), 10, 0));
               A102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Project");
               A102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
               forbiddenHiddens.Add("ProjectId", context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A102ProjectId != Z102ProjectId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("project:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A102ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
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
                     sMode15 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode15;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound15 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0E0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROJECTID");
                        AnyError = 1;
                        GX_FocusControl = edtProjectId_Internalname;
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
                           E110E2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120E2 ();
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
            E120E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0E15( ) ;
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
            DisableAttributes0E15( ) ;
         }
         AssignProp("", false, edtavComboprojectmanagerid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprojectmanagerid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E15( ) ;
            }
            else
            {
               CheckExtendedTable0E15( ) ;
               CloseExtendedTableCursors0E15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0E0( )
      {
      }

      protected void E110E2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV24DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV24DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtProjectManagerId_Visible = 0;
         AssignProp("", false, edtProjectManagerId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProjectManagerId_Visible), 5, 0), true);
         AV22ComboProjectManagerId = 0;
         AssignAttri("", false, "AV22ComboProjectManagerId", StringUtil.LTrimStr( (decimal)(AV22ComboProjectManagerId), 10, 0));
         edtavComboprojectmanagerid_Visible = 0;
         AssignProp("", false, edtavComboprojectmanagerid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboprojectmanagerid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPROJECTMANAGERID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            while ( AV33GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ProjectManagerId") == 0 )
               {
                  AV20Insert_ProjectManagerId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV20Insert_ProjectManagerId", StringUtil.LTrimStr( (decimal)(AV20Insert_ProjectManagerId), 10, 0));
                  if ( ! (0==AV20Insert_ProjectManagerId) )
                  {
                     AV22ComboProjectManagerId = AV20Insert_ProjectManagerId;
                     AssignAttri("", false, "AV22ComboProjectManagerId", StringUtil.LTrimStr( (decimal)(AV22ComboProjectManagerId), 10, 0));
                     Combo_projectmanagerid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV22ComboProjectManagerId), 10, 0));
                     ucCombo_projectmanagerid.SendProperty(context, "", false, Combo_projectmanagerid_Internalname, "SelectedValue_set", Combo_projectmanagerid_Selectedvalue_set);
                     Combo_projectmanagerid_Enabled = false;
                     ucCombo_projectmanagerid.SendProperty(context, "", false, Combo_projectmanagerid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_projectmanagerid_Enabled));
                  }
               }
               AV33GXV1 = (int)(AV33GXV1+1);
               AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            }
         }
         edtProjectId_Visible = 0;
         AssignProp("", false, edtProjectId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProjectId_Visible), 5, 0), true);
      }

      protected void E120E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new assignprojectmanager(context ).execute(  AV22ComboProjectManagerId,  A102ProjectId) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("projectww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPROJECTMANAGERID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item2 = AV21ProjectManagerId_Data;
         new projectloaddvcombo(context ).execute(  "ProjectManagerId",  Gx_mode,  AV7ProjectId, out  AV16ComboSelectedValue, out  AV23ComboSelectedText, out  GXt_objcol_SdtDVB_SDTComboData_Item2) ;
         AV21ProjectManagerId_Data = GXt_objcol_SdtDVB_SDTComboData_Item2;
         Combo_projectmanagerid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_projectmanagerid.SendProperty(context, "", false, Combo_projectmanagerid_Internalname, "SelectedValue_set", Combo_projectmanagerid_Selectedvalue_set);
         AV22ComboProjectManagerId = (long)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV22ComboProjectManagerId", StringUtil.LTrimStr( (decimal)(AV22ComboProjectManagerId), 10, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_projectmanagerid_Enabled = false;
            ucCombo_projectmanagerid.SendProperty(context, "", false, Combo_projectmanagerid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_projectmanagerid_Enabled));
         }
      }

      protected void ZM0E15( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z103ProjectName = T000E3_A103ProjectName[0];
               Z104ProjectDescription = T000E3_A104ProjectDescription[0];
               Z105ProjectStatus = T000E3_A105ProjectStatus[0];
               Z162ProjectManagerId = T000E3_A162ProjectManagerId[0];
            }
            else
            {
               Z103ProjectName = A103ProjectName;
               Z104ProjectDescription = A104ProjectDescription;
               Z105ProjectStatus = A105ProjectStatus;
               Z162ProjectManagerId = A162ProjectManagerId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z103ProjectName = A103ProjectName;
            Z104ProjectDescription = A104ProjectDescription;
            Z105ProjectStatus = A105ProjectStatus;
            Z162ProjectManagerId = A162ProjectManagerId;
            Z102ProjectId = A102ProjectId;
            Z163ProjectManagerName = A163ProjectManagerName;
            Z175ProjectManagerEmail = A175ProjectManagerEmail;
            Z176ProjectManagerIsActive = A176ProjectManagerIsActive;
         }
      }

      protected void standaloneNotModal( )
      {
         edtProjectId_Enabled = 0;
         AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), true);
         AV32Pgmname = "Project";
         AssignAttri("", false, "AV32Pgmname", AV32Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtProjectId_Enabled = 0;
         AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProjectId) )
         {
            A102ProjectId = AV7ProjectId;
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_ProjectManagerId) )
         {
            edtProjectManagerId_Enabled = 0;
            AssignProp("", false, edtProjectManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectManagerId_Enabled), 5, 0), true);
         }
         else
         {
            edtProjectManagerId_Enabled = 1;
            AssignProp("", false, edtProjectManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectManagerId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_ProjectManagerId) )
         {
            A162ProjectManagerId = AV20Insert_ProjectManagerId;
            n162ProjectManagerId = false;
            AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
         }
         else
         {
            if ( (0==AV22ComboProjectManagerId) )
            {
               A162ProjectManagerId = 0;
               n162ProjectManagerId = false;
               AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
               n162ProjectManagerId = true;
               AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
            }
            else
            {
               if ( ! (0==AV22ComboProjectManagerId) )
               {
                  A162ProjectManagerId = AV22ComboProjectManagerId;
                  n162ProjectManagerId = false;
                  AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
               }
            }
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A105ProjectStatus)) && ( Gx_BScreen == 0 ) )
         {
            A105ProjectStatus = "Active";
            AssignAttri("", false, "A105ProjectStatus", A105ProjectStatus);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000E4 */
            pr_default.execute(2, new Object[] {n162ProjectManagerId, A162ProjectManagerId});
            A163ProjectManagerName = T000E4_A163ProjectManagerName[0];
            A175ProjectManagerEmail = T000E4_A175ProjectManagerEmail[0];
            A176ProjectManagerIsActive = T000E4_A176ProjectManagerIsActive[0];
            pr_default.close(2);
         }
      }

      protected void Load0E15( )
      {
         /* Using cursor T000E6 */
         pr_default.execute(4, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound15 = 1;
            A103ProjectName = T000E6_A103ProjectName[0];
            AssignAttri("", false, "A103ProjectName", A103ProjectName);
            A104ProjectDescription = T000E6_A104ProjectDescription[0];
            AssignAttri("", false, "A104ProjectDescription", A104ProjectDescription);
            A105ProjectStatus = T000E6_A105ProjectStatus[0];
            AssignAttri("", false, "A105ProjectStatus", A105ProjectStatus);
            A163ProjectManagerName = T000E6_A163ProjectManagerName[0];
            A175ProjectManagerEmail = T000E6_A175ProjectManagerEmail[0];
            A176ProjectManagerIsActive = T000E6_A176ProjectManagerIsActive[0];
            A162ProjectManagerId = T000E6_A162ProjectManagerId[0];
            n162ProjectManagerId = T000E6_n162ProjectManagerId[0];
            AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
            ZM0E15( -13) ;
         }
         pr_default.close(4);
         OnLoadActions0E15( ) ;
      }

      protected void OnLoadActions0E15( )
      {
      }

      protected void CheckExtendedTable0E15( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000E5 */
         pr_default.execute(3, new Object[] {n162ProjectManagerId, A162ProjectManagerId, A102ProjectId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A162ProjectManagerId) || (0==A102ProjectId) ) )
            {
               GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "PROJECTID");
               AnyError = 1;
               GX_FocusControl = edtProjectManagerId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T000E7 */
         pr_default.execute(5, new Object[] {A103ProjectName, A102ProjectId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Project Name"}), 1, "PROJECTNAME");
            AnyError = 1;
            GX_FocusControl = edtProjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A103ProjectName)) )
         {
            GX_msglist.addItem("Project Name cannot be empty", 1, "PROJECTNAME");
            AnyError = 1;
            GX_FocusControl = edtProjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A105ProjectStatus, "Active") == 0 ) || ( StringUtil.StrCmp(A105ProjectStatus, "Inactive") == 0 ) ) )
         {
            GX_msglist.addItem("Field Project Status is out of range", "OutOfRange", 1, "PROJECTSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbProjectStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000E4 */
         pr_default.execute(2, new Object[] {n162ProjectManagerId, A162ProjectManagerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A162ProjectManagerId) ) )
            {
               GX_msglist.addItem("No matching 'Project Manager'.", "ForeignKeyNotFound", 1, "PROJECTMANAGERID");
               AnyError = 1;
               GX_FocusControl = edtProjectManagerId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A163ProjectManagerName = T000E4_A163ProjectManagerName[0];
         A175ProjectManagerEmail = T000E4_A175ProjectManagerEmail[0];
         A176ProjectManagerIsActive = T000E4_A176ProjectManagerIsActive[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0E15( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( long A162ProjectManagerId ,
                                long A102ProjectId )
      {
         /* Using cursor T000E8 */
         pr_default.execute(6, new Object[] {n162ProjectManagerId, A162ProjectManagerId, A102ProjectId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A162ProjectManagerId) || (0==A102ProjectId) ) )
            {
               GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "PROJECTID");
               AnyError = 1;
               GX_FocusControl = edtProjectManagerId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_15( long A162ProjectManagerId )
      {
         /* Using cursor T000E9 */
         pr_default.execute(7, new Object[] {n162ProjectManagerId, A162ProjectManagerId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A162ProjectManagerId) ) )
            {
               GX_msglist.addItem("No matching 'Project Manager'.", "ForeignKeyNotFound", 1, "PROJECTMANAGERID");
               AnyError = 1;
               GX_FocusControl = edtProjectManagerId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A163ProjectManagerName = T000E9_A163ProjectManagerName[0];
         A175ProjectManagerEmail = T000E9_A175ProjectManagerEmail[0];
         A176ProjectManagerIsActive = T000E9_A176ProjectManagerIsActive[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A163ProjectManagerName))+"\""+","+"\""+GXUtil.EncodeJSConstant( A175ProjectManagerEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A176ProjectManagerIsActive))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey0E15( )
      {
         /* Using cursor T000E10 */
         pr_default.execute(8, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000E3 */
         pr_default.execute(1, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E15( 13) ;
            RcdFound15 = 1;
            A103ProjectName = T000E3_A103ProjectName[0];
            AssignAttri("", false, "A103ProjectName", A103ProjectName);
            A104ProjectDescription = T000E3_A104ProjectDescription[0];
            AssignAttri("", false, "A104ProjectDescription", A104ProjectDescription);
            A105ProjectStatus = T000E3_A105ProjectStatus[0];
            AssignAttri("", false, "A105ProjectStatus", A105ProjectStatus);
            A162ProjectManagerId = T000E3_A162ProjectManagerId[0];
            n162ProjectManagerId = T000E3_n162ProjectManagerId[0];
            AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
            A102ProjectId = T000E3_A102ProjectId[0];
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
            Z102ProjectId = A102ProjectId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0E15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0E15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0E15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E15( ) ;
         if ( RcdFound15 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound15 = 0;
         /* Using cursor T000E11 */
         pr_default.execute(9, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000E11_A102ProjectId[0] < A102ProjectId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000E11_A102ProjectId[0] > A102ProjectId ) ) )
            {
               A102ProjectId = T000E11_A102ProjectId[0];
               AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000E12 */
         pr_default.execute(10, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000E12_A102ProjectId[0] > A102ProjectId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000E12_A102ProjectId[0] < A102ProjectId ) ) )
            {
               A102ProjectId = T000E12_A102ProjectId[0];
               AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0E15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0E15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A102ProjectId != Z102ProjectId )
               {
                  A102ProjectId = Z102ProjectId;
                  AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROJECTID");
                  AnyError = 1;
                  GX_FocusControl = edtProjectId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0E15( ) ;
                  GX_FocusControl = edtProjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A102ProjectId != Z102ProjectId )
               {
                  /* Insert record */
                  GX_FocusControl = edtProjectName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0E15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROJECTID");
                     AnyError = 1;
                     GX_FocusControl = edtProjectId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProjectName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0E15( ) ;
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
         if ( A102ProjectId != Z102ProjectId )
         {
            A102ProjectId = Z102ProjectId;
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROJECTID");
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProjectName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0E15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000E2 */
            pr_default.execute(0, new Object[] {A102ProjectId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Project"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z103ProjectName, T000E2_A103ProjectName[0]) != 0 ) || ( StringUtil.StrCmp(Z104ProjectDescription, T000E2_A104ProjectDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z105ProjectStatus, T000E2_A105ProjectStatus[0]) != 0 ) || ( Z162ProjectManagerId != T000E2_A162ProjectManagerId[0] ) )
            {
               if ( StringUtil.StrCmp(Z103ProjectName, T000E2_A103ProjectName[0]) != 0 )
               {
                  GXUtil.WriteLog("project:[seudo value changed for attri]"+"ProjectName");
                  GXUtil.WriteLogRaw("Old: ",Z103ProjectName);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A103ProjectName[0]);
               }
               if ( StringUtil.StrCmp(Z104ProjectDescription, T000E2_A104ProjectDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("project:[seudo value changed for attri]"+"ProjectDescription");
                  GXUtil.WriteLogRaw("Old: ",Z104ProjectDescription);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A104ProjectDescription[0]);
               }
               if ( StringUtil.StrCmp(Z105ProjectStatus, T000E2_A105ProjectStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("project:[seudo value changed for attri]"+"ProjectStatus");
                  GXUtil.WriteLogRaw("Old: ",Z105ProjectStatus);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A105ProjectStatus[0]);
               }
               if ( Z162ProjectManagerId != T000E2_A162ProjectManagerId[0] )
               {
                  GXUtil.WriteLog("project:[seudo value changed for attri]"+"ProjectManagerId");
                  GXUtil.WriteLogRaw("Old: ",Z162ProjectManagerId);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A162ProjectManagerId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Project"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E15( )
      {
         if ( ! IsAuthorized("project_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E15( 0) ;
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E13 */
                     pr_default.execute(11, new Object[] {A103ProjectName, A104ProjectDescription, A105ProjectStatus, n162ProjectManagerId, A162ProjectManagerId});
                     pr_default.close(11);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000E14 */
                     pr_default.execute(12);
                     A102ProjectId = T000E14_A102ProjectId[0];
                     AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Project");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0E0( ) ;
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
               Load0E15( ) ;
            }
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void Update0E15( )
      {
         if ( ! IsAuthorized("project_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E15 */
                     pr_default.execute(13, new Object[] {A103ProjectName, A104ProjectDescription, A105ProjectStatus, n162ProjectManagerId, A162ProjectManagerId, A102ProjectId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Project");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Project"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E15( ) ;
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
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void DeferredUpdate0E15( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("project_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E15( ) ;
            AfterConfirm0E15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000E16 */
                  pr_default.execute(14, new Object[] {A102ProjectId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("Project");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0E15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0E15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000E17 */
            pr_default.execute(15, new Object[] {n162ProjectManagerId, A162ProjectManagerId});
            A163ProjectManagerName = T000E17_A163ProjectManagerName[0];
            A175ProjectManagerEmail = T000E17_A175ProjectManagerEmail[0];
            A176ProjectManagerIsActive = T000E17_A176ProjectManagerIsActive[0];
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000E18 */
            pr_default.execute(16, new Object[] {A102ProjectId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel0E15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("project",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("project",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0E15( )
      {
         /* Scan By routine */
         /* Using cursor T000E19 */
         pr_default.execute(17);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound15 = 1;
            A102ProjectId = T000E19_A102ProjectId[0];
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0E15( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound15 = 1;
            A102ProjectId = T000E19_A102ProjectId[0];
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
         }
      }

      protected void ScanEnd0E15( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0E15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E15( )
      {
         /* Before Insert Rules */
         A162ProjectManagerId = 0;
         n162ProjectManagerId = false;
         AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
         n162ProjectManagerId = true;
         AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
         new assignprojectmanagerrole(context ).execute(  A162ProjectManagerId,  A102ProjectId) ;
      }

      protected void BeforeUpdate0E15( )
      {
         /* Before Update Rules */
         new assignprojectmanagerrole(context ).execute(  A162ProjectManagerId,  A102ProjectId) ;
      }

      protected void BeforeDelete0E15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E15( )
      {
         edtProjectName_Enabled = 0;
         AssignProp("", false, edtProjectName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectName_Enabled), 5, 0), true);
         edtProjectDescription_Enabled = 0;
         AssignProp("", false, edtProjectDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectDescription_Enabled), 5, 0), true);
         cmbProjectStatus.Enabled = 0;
         AssignProp("", false, cmbProjectStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProjectStatus.Enabled), 5, 0), true);
         edtProjectManagerId_Enabled = 0;
         AssignProp("", false, edtProjectManagerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectManagerId_Enabled), 5, 0), true);
         edtavComboprojectmanagerid_Enabled = 0;
         AssignProp("", false, edtavComboprojectmanagerid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprojectmanagerid_Enabled), 5, 0), true);
         edtProjectId_Enabled = 0;
         AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0E15( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0E0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("project.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProjectId,10,0))}, new string[] {"Gx_mode","ProjectId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Project");
         forbiddenHiddens.Add("ProjectId", context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("project:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z102ProjectId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102ProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z103ProjectName", StringUtil.RTrim( Z103ProjectName));
         GxWebStd.gx_hidden_field( context, "Z104ProjectDescription", Z104ProjectDescription);
         GxWebStd.gx_hidden_field( context, "Z105ProjectStatus", StringUtil.RTrim( Z105ProjectStatus));
         GxWebStd.gx_hidden_field( context, "Z162ProjectManagerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z162ProjectManagerId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N162ProjectManagerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A162ProjectManagerId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV24DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV24DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTMANAGERID_DATA", AV21ProjectManagerId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTMANAGERID_DATA", AV21ProjectManagerId_Data);
         }
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
         GxWebStd.gx_hidden_field( context, "vPROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROJECTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProjectId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROJECTMANAGERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Insert_ProjectManagerId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROJECTMANAGERNAME", StringUtil.RTrim( A163ProjectManagerName));
         GxWebStd.gx_hidden_field( context, "PROJECTMANAGEREMAIL", A175ProjectManagerEmail);
         GxWebStd.gx_boolean_hidden_field( context, "PROJECTMANAGERISACTIVE", A176ProjectManagerIsActive);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTMANAGERID_Objectcall", StringUtil.RTrim( Combo_projectmanagerid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTMANAGERID_Cls", StringUtil.RTrim( Combo_projectmanagerid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTMANAGERID_Selectedvalue_set", StringUtil.RTrim( Combo_projectmanagerid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTMANAGERID_Enabled", StringUtil.BoolToStr( Combo_projectmanagerid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTMANAGERID_Emptyitem", StringUtil.BoolToStr( Combo_projectmanagerid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
         return formatLink("project.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProjectId,10,0))}, new string[] {"Gx_mode","ProjectId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Project" ;
      }

      public override string GetPgmdesc( )
      {
         return "Project" ;
      }

      protected void InitializeNonKey0E15( )
      {
         A106EmployeeId = 0;
         AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         A162ProjectManagerId = 0;
         n162ProjectManagerId = false;
         AssignAttri("", false, "A162ProjectManagerId", StringUtil.LTrimStr( (decimal)(A162ProjectManagerId), 10, 0));
         n162ProjectManagerId = ((0==A162ProjectManagerId) ? true : false);
         A103ProjectName = "";
         AssignAttri("", false, "A103ProjectName", A103ProjectName);
         A104ProjectDescription = "";
         AssignAttri("", false, "A104ProjectDescription", A104ProjectDescription);
         A163ProjectManagerName = "";
         AssignAttri("", false, "A163ProjectManagerName", A163ProjectManagerName);
         A175ProjectManagerEmail = "";
         AssignAttri("", false, "A175ProjectManagerEmail", A175ProjectManagerEmail);
         A176ProjectManagerIsActive = false;
         AssignAttri("", false, "A176ProjectManagerIsActive", A176ProjectManagerIsActive);
         A105ProjectStatus = "Active";
         AssignAttri("", false, "A105ProjectStatus", A105ProjectStatus);
         Z103ProjectName = "";
         Z104ProjectDescription = "";
         Z105ProjectStatus = "";
         Z162ProjectManagerId = 0;
      }

      protected void InitAll0E15( )
      {
         A102ProjectId = 0;
         AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
         InitializeNonKey0E15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A105ProjectStatus = i105ProjectStatus;
         AssignAttri("", false, "A105ProjectStatus", A105ProjectStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256267491410", true, true);
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
         context.AddJavascriptSource("project.js", "?20256267491410", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtProjectName_Internalname = "PROJECTNAME";
         edtProjectDescription_Internalname = "PROJECTDESCRIPTION";
         cmbProjectStatus_Internalname = "PROJECTSTATUS";
         lblTextblockprojectmanagerid_Internalname = "TEXTBLOCKPROJECTMANAGERID";
         Combo_projectmanagerid_Internalname = "COMBO_PROJECTMANAGERID";
         edtProjectManagerId_Internalname = "PROJECTMANAGERID";
         divTablesplittedprojectmanagerid_Internalname = "TABLESPLITTEDPROJECTMANAGERID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboprojectmanagerid_Internalname = "vCOMBOPROJECTMANAGERID";
         divSectionattribute_projectmanagerid_Internalname = "SECTIONATTRIBUTE_PROJECTMANAGERID";
         edtProjectId_Internalname = "PROJECTID";
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
         Form.Caption = "Project";
         edtProjectId_Jsonclick = "";
         edtProjectId_Enabled = 0;
         edtProjectId_Visible = 1;
         edtavComboprojectmanagerid_Jsonclick = "";
         edtavComboprojectmanagerid_Enabled = 0;
         edtavComboprojectmanagerid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtProjectManagerId_Jsonclick = "";
         edtProjectManagerId_Enabled = 1;
         edtProjectManagerId_Visible = 1;
         Combo_projectmanagerid_Emptyitem = Convert.ToBoolean( 0);
         Combo_projectmanagerid_Cls = "ExtendedCombo Attribute";
         Combo_projectmanagerid_Caption = "";
         Combo_projectmanagerid_Enabled = Convert.ToBoolean( -1);
         cmbProjectStatus_Jsonclick = "";
         cmbProjectStatus.Enabled = 1;
         edtProjectDescription_Enabled = 1;
         edtProjectName_Jsonclick = "";
         edtProjectName_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "General Information";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
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

      protected void XC_12_0E15( long A162ProjectManagerId ,
                                 long A102ProjectId )
      {
         new assignprojectmanagerrole(context ).execute(  A162ProjectManagerId,  A102ProjectId) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbProjectStatus.Name = "PROJECTSTATUS";
         cmbProjectStatus.WebTags = "";
         cmbProjectStatus.addItem("Active", "Active", 0);
         cmbProjectStatus.addItem("Inactive", "Inactive", 0);
         if ( cmbProjectStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A105ProjectStatus)) )
            {
               A105ProjectStatus = "Active";
               AssignAttri("", false, "A105ProjectStatus", A105ProjectStatus);
            }
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

      public void Valid_Projectname( )
      {
         /* Using cursor T000E20 */
         pr_default.execute(18, new Object[] {A103ProjectName, A102ProjectId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Project Name"}), 1, "PROJECTNAME");
            AnyError = 1;
            GX_FocusControl = edtProjectName_Internalname;
         }
         pr_default.close(18);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A103ProjectName)) )
         {
            GX_msglist.addItem("Project Name cannot be empty", 1, "PROJECTNAME");
            AnyError = 1;
            GX_FocusControl = edtProjectName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Projectmanagerid( )
      {
         n162ProjectManagerId = false;
         /* Using cursor T000E17 */
         pr_default.execute(15, new Object[] {n162ProjectManagerId, A162ProjectManagerId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A162ProjectManagerId) ) )
            {
               GX_msglist.addItem("No matching 'Project Manager'.", "ForeignKeyNotFound", 1, "PROJECTMANAGERID");
               AnyError = 1;
               GX_FocusControl = edtProjectManagerId_Internalname;
            }
         }
         A163ProjectManagerName = T000E17_A163ProjectManagerName[0];
         A175ProjectManagerEmail = T000E17_A175ProjectManagerEmail[0];
         A176ProjectManagerIsActive = T000E17_A176ProjectManagerIsActive[0];
         pr_default.close(15);
         /* Using cursor T000E21 */
         pr_default.execute(19, new Object[] {n162ProjectManagerId, A162ProjectManagerId, A102ProjectId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A162ProjectManagerId) || (0==A102ProjectId) ) )
            {
               GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "PROJECTID");
               AnyError = 1;
               GX_FocusControl = edtProjectManagerId_Internalname;
            }
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A163ProjectManagerName", StringUtil.RTrim( A163ProjectManagerName));
         AssignAttri("", false, "A175ProjectManagerEmail", A175ProjectManagerEmail);
         AssignAttri("", false, "A176ProjectManagerIsActive", A176ProjectManagerIsActive);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7ProjectId","fld":"vPROJECTID","pic":"ZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7ProjectId","fld":"vPROJECTID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120E2","iparms":[{"av":"AV22ComboProjectManagerId","fld":"vCOMBOPROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_PROJECTNAME","""{"handler":"Valid_Projectname","iparms":[{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_PROJECTSTATUS","""{"handler":"Valid_Projectstatus","iparms":[]}""");
         setEventMetadata("VALID_PROJECTMANAGERID","""{"handler":"Valid_Projectmanagerid","iparms":[{"av":"A162ProjectManagerId","fld":"PROJECTMANAGERID","pic":"ZZZZZZZZZ9"},{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A163ProjectManagerName","fld":"PROJECTMANAGERNAME"},{"av":"A175ProjectManagerEmail","fld":"PROJECTMANAGEREMAIL"},{"av":"A176ProjectManagerIsActive","fld":"PROJECTMANAGERISACTIVE"}]""");
         setEventMetadata("VALID_PROJECTMANAGERID",""","oparms":[{"av":"A163ProjectManagerName","fld":"PROJECTMANAGERNAME"},{"av":"A175ProjectManagerEmail","fld":"PROJECTMANAGEREMAIL"},{"av":"A176ProjectManagerIsActive","fld":"PROJECTMANAGERISACTIVE"}]}""");
         setEventMetadata("VALIDV_COMBOPROJECTMANAGERID","""{"handler":"Validv_Comboprojectmanagerid","iparms":[]}""");
         setEventMetadata("VALID_PROJECTID","""{"handler":"Valid_Projectid","iparms":[]}""");
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
         pr_default.close(19);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z103ProjectName = "";
         Z104ProjectDescription = "";
         Z105ProjectStatus = "";
         Combo_projectmanagerid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A105ProjectStatus = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A103ProjectName = "";
         A104ProjectDescription = "";
         lblTextblockprojectmanagerid_Jsonclick = "";
         ucCombo_projectmanagerid = new GXUserControl();
         AV24DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21ProjectManagerId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A163ProjectManagerName = "";
         A175ProjectManagerEmail = "";
         AV32Pgmname = "";
         Combo_projectmanagerid_Objectcall = "";
         Combo_projectmanagerid_Class = "";
         Combo_projectmanagerid_Icontype = "";
         Combo_projectmanagerid_Icon = "";
         Combo_projectmanagerid_Tooltip = "";
         Combo_projectmanagerid_Selectedvalue_set = "";
         Combo_projectmanagerid_Selectedtext_set = "";
         Combo_projectmanagerid_Selectedtext_get = "";
         Combo_projectmanagerid_Gamoauthtoken = "";
         Combo_projectmanagerid_Ddointernalname = "";
         Combo_projectmanagerid_Titlecontrolalign = "";
         Combo_projectmanagerid_Dropdownoptionstype = "";
         Combo_projectmanagerid_Titlecontrolidtoreplace = "";
         Combo_projectmanagerid_Datalisttype = "";
         Combo_projectmanagerid_Datalistfixedvalues = "";
         Combo_projectmanagerid_Datalistproc = "";
         Combo_projectmanagerid_Datalistprocparametersprefix = "";
         Combo_projectmanagerid_Remoteservicesparameters = "";
         Combo_projectmanagerid_Htmltemplate = "";
         Combo_projectmanagerid_Multiplevaluestype = "";
         Combo_projectmanagerid_Loadingdata = "";
         Combo_projectmanagerid_Noresultsfound = "";
         Combo_projectmanagerid_Emptyitemtext = "";
         Combo_projectmanagerid_Onlyselectedvalues = "";
         Combo_projectmanagerid_Selectalltext = "";
         Combo_projectmanagerid_Multiplevaluesseparator = "";
         Combo_projectmanagerid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode15 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         GXt_objcol_SdtDVB_SDTComboData_Item2 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV16ComboSelectedValue = "";
         AV23ComboSelectedText = "";
         Z163ProjectManagerName = "";
         Z175ProjectManagerEmail = "";
         T000E4_A163ProjectManagerName = new string[] {""} ;
         T000E4_A175ProjectManagerEmail = new string[] {""} ;
         T000E4_A176ProjectManagerIsActive = new bool[] {false} ;
         T000E6_A103ProjectName = new string[] {""} ;
         T000E6_A104ProjectDescription = new string[] {""} ;
         T000E6_A105ProjectStatus = new string[] {""} ;
         T000E6_A163ProjectManagerName = new string[] {""} ;
         T000E6_A175ProjectManagerEmail = new string[] {""} ;
         T000E6_A176ProjectManagerIsActive = new bool[] {false} ;
         T000E6_A162ProjectManagerId = new long[1] ;
         T000E6_n162ProjectManagerId = new bool[] {false} ;
         T000E6_A102ProjectId = new long[1] ;
         T000E5_A106EmployeeId = new long[1] ;
         T000E7_A103ProjectName = new string[] {""} ;
         T000E8_A106EmployeeId = new long[1] ;
         T000E9_A163ProjectManagerName = new string[] {""} ;
         T000E9_A175ProjectManagerEmail = new string[] {""} ;
         T000E9_A176ProjectManagerIsActive = new bool[] {false} ;
         T000E10_A102ProjectId = new long[1] ;
         T000E3_A103ProjectName = new string[] {""} ;
         T000E3_A104ProjectDescription = new string[] {""} ;
         T000E3_A105ProjectStatus = new string[] {""} ;
         T000E3_A162ProjectManagerId = new long[1] ;
         T000E3_n162ProjectManagerId = new bool[] {false} ;
         T000E3_A102ProjectId = new long[1] ;
         T000E11_A102ProjectId = new long[1] ;
         T000E12_A102ProjectId = new long[1] ;
         T000E2_A103ProjectName = new string[] {""} ;
         T000E2_A104ProjectDescription = new string[] {""} ;
         T000E2_A105ProjectStatus = new string[] {""} ;
         T000E2_A162ProjectManagerId = new long[1] ;
         T000E2_n162ProjectManagerId = new bool[] {false} ;
         T000E2_A102ProjectId = new long[1] ;
         T000E14_A102ProjectId = new long[1] ;
         T000E17_A163ProjectManagerName = new string[] {""} ;
         T000E17_A175ProjectManagerEmail = new string[] {""} ;
         T000E17_A176ProjectManagerIsActive = new bool[] {false} ;
         T000E18_A106EmployeeId = new long[1] ;
         T000E18_A102ProjectId = new long[1] ;
         T000E19_A102ProjectId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i105ProjectStatus = "";
         T000E20_A103ProjectName = new string[] {""} ;
         T000E21_A106EmployeeId = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.project__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.project__default(),
            new Object[][] {
                new Object[] {
               T000E2_A103ProjectName, T000E2_A104ProjectDescription, T000E2_A105ProjectStatus, T000E2_A162ProjectManagerId, T000E2_n162ProjectManagerId, T000E2_A102ProjectId
               }
               , new Object[] {
               T000E3_A103ProjectName, T000E3_A104ProjectDescription, T000E3_A105ProjectStatus, T000E3_A162ProjectManagerId, T000E3_n162ProjectManagerId, T000E3_A102ProjectId
               }
               , new Object[] {
               T000E4_A163ProjectManagerName, T000E4_A175ProjectManagerEmail, T000E4_A176ProjectManagerIsActive
               }
               , new Object[] {
               T000E5_A106EmployeeId
               }
               , new Object[] {
               T000E6_A103ProjectName, T000E6_A104ProjectDescription, T000E6_A105ProjectStatus, T000E6_A163ProjectManagerName, T000E6_A175ProjectManagerEmail, T000E6_A176ProjectManagerIsActive, T000E6_A162ProjectManagerId, T000E6_n162ProjectManagerId, T000E6_A102ProjectId
               }
               , new Object[] {
               T000E7_A103ProjectName
               }
               , new Object[] {
               T000E8_A106EmployeeId
               }
               , new Object[] {
               T000E9_A163ProjectManagerName, T000E9_A175ProjectManagerEmail, T000E9_A176ProjectManagerIsActive
               }
               , new Object[] {
               T000E10_A102ProjectId
               }
               , new Object[] {
               T000E11_A102ProjectId
               }
               , new Object[] {
               T000E12_A102ProjectId
               }
               , new Object[] {
               }
               , new Object[] {
               T000E14_A102ProjectId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000E17_A163ProjectManagerName, T000E17_A175ProjectManagerEmail, T000E17_A176ProjectManagerIsActive
               }
               , new Object[] {
               T000E18_A106EmployeeId, T000E18_A102ProjectId
               }
               , new Object[] {
               T000E19_A102ProjectId
               }
               , new Object[] {
               T000E20_A103ProjectName
               }
               , new Object[] {
               T000E21_A106EmployeeId
               }
            }
         );
         AV32Pgmname = "Project";
         Z105ProjectStatus = "Active";
         A105ProjectStatus = "Active";
         i105ProjectStatus = "Active";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtProjectName_Enabled ;
      private int edtProjectDescription_Enabled ;
      private int edtProjectManagerId_Visible ;
      private int edtProjectManagerId_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboprojectmanagerid_Enabled ;
      private int edtavComboprojectmanagerid_Visible ;
      private int edtProjectId_Enabled ;
      private int edtProjectId_Visible ;
      private int Combo_projectmanagerid_Datalistupdateminimumcharacters ;
      private int Combo_projectmanagerid_Gxcontroltype ;
      private int AV33GXV1 ;
      private int idxLst ;
      private long wcpOAV7ProjectId ;
      private long Z102ProjectId ;
      private long Z162ProjectManagerId ;
      private long N162ProjectManagerId ;
      private long A162ProjectManagerId ;
      private long A102ProjectId ;
      private long AV7ProjectId ;
      private long AV22ComboProjectManagerId ;
      private long AV20Insert_ProjectManagerId ;
      private long A106EmployeeId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z103ProjectName ;
      private string Z105ProjectStatus ;
      private string Combo_projectmanagerid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProjectName_Internalname ;
      private string A105ProjectStatus ;
      private string cmbProjectStatus_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string A103ProjectName ;
      private string edtProjectName_Jsonclick ;
      private string edtProjectDescription_Internalname ;
      private string cmbProjectStatus_Jsonclick ;
      private string divTablesplittedprojectmanagerid_Internalname ;
      private string lblTextblockprojectmanagerid_Internalname ;
      private string lblTextblockprojectmanagerid_Jsonclick ;
      private string Combo_projectmanagerid_Caption ;
      private string Combo_projectmanagerid_Cls ;
      private string Combo_projectmanagerid_Internalname ;
      private string edtProjectManagerId_Internalname ;
      private string edtProjectManagerId_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_projectmanagerid_Internalname ;
      private string edtavComboprojectmanagerid_Internalname ;
      private string edtavComboprojectmanagerid_Jsonclick ;
      private string edtProjectId_Internalname ;
      private string edtProjectId_Jsonclick ;
      private string A163ProjectManagerName ;
      private string AV32Pgmname ;
      private string Combo_projectmanagerid_Objectcall ;
      private string Combo_projectmanagerid_Class ;
      private string Combo_projectmanagerid_Icontype ;
      private string Combo_projectmanagerid_Icon ;
      private string Combo_projectmanagerid_Tooltip ;
      private string Combo_projectmanagerid_Selectedvalue_set ;
      private string Combo_projectmanagerid_Selectedtext_set ;
      private string Combo_projectmanagerid_Selectedtext_get ;
      private string Combo_projectmanagerid_Gamoauthtoken ;
      private string Combo_projectmanagerid_Ddointernalname ;
      private string Combo_projectmanagerid_Titlecontrolalign ;
      private string Combo_projectmanagerid_Dropdownoptionstype ;
      private string Combo_projectmanagerid_Titlecontrolidtoreplace ;
      private string Combo_projectmanagerid_Datalisttype ;
      private string Combo_projectmanagerid_Datalistfixedvalues ;
      private string Combo_projectmanagerid_Datalistproc ;
      private string Combo_projectmanagerid_Datalistprocparametersprefix ;
      private string Combo_projectmanagerid_Remoteservicesparameters ;
      private string Combo_projectmanagerid_Htmltemplate ;
      private string Combo_projectmanagerid_Multiplevaluestype ;
      private string Combo_projectmanagerid_Loadingdata ;
      private string Combo_projectmanagerid_Noresultsfound ;
      private string Combo_projectmanagerid_Emptyitemtext ;
      private string Combo_projectmanagerid_Onlyselectedvalues ;
      private string Combo_projectmanagerid_Selectalltext ;
      private string Combo_projectmanagerid_Multiplevaluesseparator ;
      private string Combo_projectmanagerid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode15 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z163ProjectManagerName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i105ProjectStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n162ProjectManagerId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_projectmanagerid_Emptyitem ;
      private bool A176ProjectManagerIsActive ;
      private bool Combo_projectmanagerid_Enabled ;
      private bool Combo_projectmanagerid_Visible ;
      private bool Combo_projectmanagerid_Allowmultipleselection ;
      private bool Combo_projectmanagerid_Isgriditem ;
      private bool Combo_projectmanagerid_Hasdescription ;
      private bool Combo_projectmanagerid_Includeonlyselectedoption ;
      private bool Combo_projectmanagerid_Includeselectalloption ;
      private bool Combo_projectmanagerid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Z176ProjectManagerIsActive ;
      private string Z104ProjectDescription ;
      private string A104ProjectDescription ;
      private string A175ProjectManagerEmail ;
      private string AV16ComboSelectedValue ;
      private string AV23ComboSelectedText ;
      private string Z175ProjectManagerEmail ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_projectmanagerid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProjectStatus ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV24DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV21ProjectManagerId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item2 ;
      private IDataStoreProvider pr_default ;
      private string[] T000E4_A163ProjectManagerName ;
      private string[] T000E4_A175ProjectManagerEmail ;
      private bool[] T000E4_A176ProjectManagerIsActive ;
      private string[] T000E6_A103ProjectName ;
      private string[] T000E6_A104ProjectDescription ;
      private string[] T000E6_A105ProjectStatus ;
      private string[] T000E6_A163ProjectManagerName ;
      private string[] T000E6_A175ProjectManagerEmail ;
      private bool[] T000E6_A176ProjectManagerIsActive ;
      private long[] T000E6_A162ProjectManagerId ;
      private bool[] T000E6_n162ProjectManagerId ;
      private long[] T000E6_A102ProjectId ;
      private long[] T000E5_A106EmployeeId ;
      private string[] T000E7_A103ProjectName ;
      private long[] T000E8_A106EmployeeId ;
      private string[] T000E9_A163ProjectManagerName ;
      private string[] T000E9_A175ProjectManagerEmail ;
      private bool[] T000E9_A176ProjectManagerIsActive ;
      private long[] T000E10_A102ProjectId ;
      private string[] T000E3_A103ProjectName ;
      private string[] T000E3_A104ProjectDescription ;
      private string[] T000E3_A105ProjectStatus ;
      private long[] T000E3_A162ProjectManagerId ;
      private bool[] T000E3_n162ProjectManagerId ;
      private long[] T000E3_A102ProjectId ;
      private long[] T000E11_A102ProjectId ;
      private long[] T000E12_A102ProjectId ;
      private string[] T000E2_A103ProjectName ;
      private string[] T000E2_A104ProjectDescription ;
      private string[] T000E2_A105ProjectStatus ;
      private long[] T000E2_A162ProjectManagerId ;
      private bool[] T000E2_n162ProjectManagerId ;
      private long[] T000E2_A102ProjectId ;
      private long[] T000E14_A102ProjectId ;
      private string[] T000E17_A163ProjectManagerName ;
      private string[] T000E17_A175ProjectManagerEmail ;
      private bool[] T000E17_A176ProjectManagerIsActive ;
      private long[] T000E18_A106EmployeeId ;
      private long[] T000E18_A102ProjectId ;
      private long[] T000E19_A102ProjectId ;
      private string[] T000E20_A103ProjectName ;
      private long[] T000E21_A106EmployeeId ;
      private IDataStoreProvider pr_gam ;
   }

   public class project__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class project__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000E2;
        prmT000E2 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E3;
        prmT000E3 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E4;
        prmT000E4 = new Object[] {
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000E5;
        prmT000E5 = new Object[] {
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E6;
        prmT000E6 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E7;
        prmT000E7 = new Object[] {
        new ParDef("ProjectName",GXType.Char,100,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E8;
        prmT000E8 = new Object[] {
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E9;
        prmT000E9 = new Object[] {
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000E10;
        prmT000E10 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E11;
        prmT000E11 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E12;
        prmT000E12 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E13;
        prmT000E13 = new Object[] {
        new ParDef("ProjectName",GXType.Char,100,0) ,
        new ParDef("ProjectDescription",GXType.VarChar,200,0) ,
        new ParDef("ProjectStatus",GXType.Char,20,0) ,
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000E14;
        prmT000E14 = new Object[] {
        };
        Object[] prmT000E15;
        prmT000E15 = new Object[] {
        new ParDef("ProjectName",GXType.Char,100,0) ,
        new ParDef("ProjectDescription",GXType.VarChar,200,0) ,
        new ParDef("ProjectStatus",GXType.Char,20,0) ,
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E16;
        prmT000E16 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E17;
        prmT000E17 = new Object[] {
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000E18;
        prmT000E18 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E19;
        prmT000E19 = new Object[] {
        };
        Object[] prmT000E20;
        prmT000E20 = new Object[] {
        new ParDef("ProjectName",GXType.Char,100,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000E21;
        prmT000E21 = new Object[] {
        new ParDef("ProjectManagerId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000E2", "SELECT ProjectName, ProjectDescription, ProjectStatus, ProjectManagerId, ProjectId FROM Project WHERE ProjectId = :ProjectId  FOR UPDATE OF Project NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E3", "SELECT ProjectName, ProjectDescription, ProjectStatus, ProjectManagerId, ProjectId FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E4", "SELECT EmployeeName AS ProjectManagerName, EmployeeEmail AS ProjectManagerEmail, EmployeeIsActive AS ProjectManagerIsActive FROM Employee WHERE EmployeeId = :ProjectManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E5", "SELECT EmployeeId FROM EmployeeProject WHERE EmployeeId = :ProjectManagerId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E6", "SELECT TM1.ProjectName, TM1.ProjectDescription, TM1.ProjectStatus, T2.EmployeeName AS ProjectManagerName, T2.EmployeeEmail AS ProjectManagerEmail, T2.EmployeeIsActive AS ProjectManagerIsActive, TM1.ProjectManagerId AS ProjectManagerId, TM1.ProjectId FROM (Project TM1 LEFT JOIN Employee T2 ON T2.EmployeeId = TM1.ProjectManagerId) WHERE TM1.ProjectId = :ProjectId ORDER BY TM1.ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E7", "SELECT ProjectName FROM Project WHERE (ProjectName = :ProjectName) AND (Not ( ProjectId = :ProjectId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E8", "SELECT EmployeeId FROM EmployeeProject WHERE EmployeeId = :ProjectManagerId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E9", "SELECT EmployeeName AS ProjectManagerName, EmployeeEmail AS ProjectManagerEmail, EmployeeIsActive AS ProjectManagerIsActive FROM Employee WHERE EmployeeId = :ProjectManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E10", "SELECT ProjectId FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E11", "SELECT ProjectId FROM Project WHERE ( ProjectId > :ProjectId) ORDER BY ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E12", "SELECT ProjectId FROM Project WHERE ( ProjectId < :ProjectId) ORDER BY ProjectId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E13", "SAVEPOINT gxupdate;INSERT INTO Project(ProjectName, ProjectDescription, ProjectStatus, ProjectManagerId) VALUES(:ProjectName, :ProjectDescription, :ProjectStatus, :ProjectManagerId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000E13)
           ,new CursorDef("T000E14", "SELECT currval('ProjectId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E15", "SAVEPOINT gxupdate;UPDATE Project SET ProjectName=:ProjectName, ProjectDescription=:ProjectDescription, ProjectStatus=:ProjectStatus, ProjectManagerId=:ProjectManagerId  WHERE ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000E15)
           ,new CursorDef("T000E16", "SAVEPOINT gxupdate;DELETE FROM Project  WHERE ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000E16)
           ,new CursorDef("T000E17", "SELECT EmployeeName AS ProjectManagerName, EmployeeEmail AS ProjectManagerEmail, EmployeeIsActive AS ProjectManagerIsActive FROM Employee WHERE EmployeeId = :ProjectManagerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E18", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E19", "SELECT ProjectId FROM Project ORDER BY ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E20", "SELECT ProjectName FROM Project WHERE (ProjectName = :ProjectName) AND (Not ( ProjectId = :ProjectId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E21", "SELECT EmployeeId FROM EmployeeProject WHERE EmployeeId = :ProjectManagerId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E21,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
