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
   public class employee : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action25") == 0 )
         {
            A109EmployeeEmail = GetPar( "EmployeeEmail");
            AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
            A107EmployeeFirstName = GetPar( "EmployeeFirstName");
            AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
            A108EmployeeLastName = GetPar( "EmployeeLastName");
            AssignAttri("", false, "A108EmployeeLastName", A108EmployeeLastName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_25_0F16( A109EmployeeEmail, A107EmployeeFirstName, A108EmployeeLastName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action26") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_26_0F16( A106EmployeeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action27") == 0 )
         {
            A109EmployeeEmail = GetPar( "EmployeeEmail");
            AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_27_0F16( A109EmployeeEmail) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action28") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_28_0F16( A106EmployeeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"EMPLOYEEBALANCE") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAEMPLOYEEBALANCE0F16( A106EmployeeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"COMPANYID") == 0 )
         {
            AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "Insert_CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV13Insert_CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX7ASACOMPANYID0F16( AV13Insert_CompanyId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"") == 0 )
         {
            AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "Insert_CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV13Insert_CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXASA1000F16( AV13Insert_CompanyId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel9"+"_"+"") == 0 )
         {
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel14"+"_"+"EMPLOYEEBALANCE") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX14ASAEMPLOYEEBALANCE0F16( A106EmployeeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel15"+"_"+"vEMPLOYEEBALANCE") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX15ASAEMPLOYEEBALANCE0F16( A106EmployeeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel41"+"_"+"") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXASA1000F16( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_35") == 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( GetPar( "CompanyId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_35( A100CompanyId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_38") == 0 )
         {
            A102ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_38( A102ProjectId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_vacationset") == 0 )
         {
            gxnrGridlevel_vacationset_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_project") == 0 )
         {
            gxnrGridlevel_project_newrow_invoke( ) ;
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7EmployeeId", StringUtil.LTrimStr( (decimal)(AV7EmployeeId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmployeeId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Employees", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEmployeeFirstName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_vacationset_newrow_invoke( )
      {
         nRC_GXsfl_76 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_76"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_76_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_76_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_76_idx = GetPar( "sGXsfl_76_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_vacationset_newrow( ) ;
         /* End function gxnrGridlevel_vacationset_newrow_invoke */
      }

      protected void gxnrGridlevel_project_newrow_invoke( )
      {
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
         edtProjectId_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtProjectId_Internalname, "Horizontalalignment", edtProjectId_Horizontalalignment, !bGXsfl_84_Refreshing);
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_project_newrow( ) ;
         /* End function gxnrGridlevel_project_newrow_invoke */
      }

      public employee( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employee( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_EmployeeId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EmployeeId = aP1_EmployeeId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynCompanyId = new GXCombobox();
         chkEmployeeIsActive = new GXCheckbox();
         chkEmployeeIsManager = new GXCheckbox();
         chkEmployeeIsActiveInProject = new GXCheckbox();
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
            return "employee_Execute" ;
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
         if ( dynCompanyId.ItemCount > 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynCompanyId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0));
            AssignProp("", false, dynCompanyId_Internalname, "Values", dynCompanyId.ToJavascriptSource(), true);
         }
         A112EmployeeIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A112EmployeeIsActive));
         AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
         A110EmployeeIsManager = StringUtil.StrToBool( StringUtil.BoolToStr( A110EmployeeIsManager));
         AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 100, "%", 0, "px", "TableMainTransaction", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:20fr 60fr 20fr;grid-template-rows:auto;", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeFirstName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeFirstName_Internalname, "First Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeFirstName_Internalname, StringUtil.RTrim( A107EmployeeFirstName), StringUtil.RTrim( context.localUtil.Format( A107EmployeeFirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeFirstName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeFirstName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeLastName_Internalname, "Last Name", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeLastName_Internalname, StringUtil.RTrim( A108EmployeeLastName), StringUtil.RTrim( context.localUtil.Format( A108EmployeeLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeLastName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmployeeEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeEmail_Internalname, "Email", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeEmail_Internalname, A109EmployeeEmail, StringUtil.RTrim( context.localUtil.Format( A109EmployeeEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A109EmployeeEmail, "", "", "", edtEmployeeEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeEmail_Enabled, 1, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynCompanyId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynCompanyId_Internalname, "Location", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynCompanyId, dynCompanyId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0)), 1, dynCompanyId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynCompanyId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 0, "HLP_Employee.htm");
         dynCompanyId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0));
         AssignProp("", false, dynCompanyId_Internalname, "Values", (string)(dynCompanyId.ToJavascriptSource()), true);
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
         GxWebStd.gx_label_element( context, chkEmployeeIsActive_Internalname, "Is Active", " AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkEmployeeIsActive_Internalname, StringUtil.BoolToStr( A112EmployeeIsActive), "", "Is Active", 1, chkEmployeeIsActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(42, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,42);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkEmployeeIsManager_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkEmployeeIsManager_Internalname, "Is HR Manager", " AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkEmployeeIsManager_Internalname, StringUtil.BoolToStr( A110EmployeeIsManager), "", "Is HR Manager", 1, chkEmployeeIsManager.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(46, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,46);\"");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmployeebalance_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtavEmployeebalance_Internalname, "Balance", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavEmployeebalance_Internalname, StringUtil.LTrim( StringUtil.NToC( AV30EmployeeBalance, 4, 1, ".", "")), StringUtil.LTrim( ((edtavEmployeebalance_Enabled!=0) ? context.localUtil.Format( AV30EmployeeBalance, "Z9.9") : context.localUtil.Format( AV30EmployeeBalance, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployeebalance_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmployeebalance_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divAddvacationdayscell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellPaddingTop24", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnsetvacationdaysbtn_Internalname, "", "Add Vacation Days", bttBtnsetvacationdaysbtn_Jsonclick, 7, "Add Vacation Days", "", StyleString, ClassString, bttBtnsetvacationdaysbtn_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110f16_client"+"'", TempTags, "", 2, "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeFTEHours_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A188EmployeeFTEHours), 4, 0, ".", "")), StringUtil.LTrim( ((edtEmployeeFTEHours_Enabled!=0) ? context.localUtil.Format( (decimal)(A188EmployeeFTEHours), "ZZZ9") : context.localUtil.Format( (decimal)(A188EmployeeFTEHours), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeFTEHours_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeFTEHours_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Employee.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavEmployeeapipassword_Internalname, AV31EmployeeAPIPassword, StringUtil.RTrim( context.localUtil.Format( AV31EmployeeAPIPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmployeeapipassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmployeeapipassword_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellPaddingTop24", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtnuseraction1_Internalname, "", "Generate API Token", bttBtnuseraction1_Jsonclick, 5, "Generate API Token", "", StyleString, ClassString, bttBtnuseraction1_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTION1\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md col-lg-9 hidden-lg CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_vacationset_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "start", "top", "", "", "div");
         gxdraw_Gridlevel_vacationset( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_project_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "start", "top", "", "", "div");
         gxdraw_Gridlevel_project( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Employee.htm");
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
         /* User Defined Control */
         ucCombo_projectid.SetProperty("Caption", Combo_projectid_Caption);
         ucCombo_projectid.SetProperty("Cls", Combo_projectid_Cls);
         ucCombo_projectid.SetProperty("IsGridItem", Combo_projectid_Isgriditem);
         ucCombo_projectid.SetProperty("EmptyItem", Combo_projectid_Emptyitem);
         ucCombo_projectid.SetProperty("DropDownOptionsData", AV15ProjectId_Data);
         ucCombo_projectid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_projectid_Internalname, "COMBO_PROJECTIDContainer");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")), StringUtil.LTrim( ((edtEmployeeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeId_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeId_Visible, edtEmployeeId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Employee.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeVactionDays_Internalname, StringUtil.LTrim( StringUtil.NToC( A146EmployeeVactionDays, 4, 1, ".", "")), StringUtil.LTrim( ((edtEmployeeVactionDays_Enabled!=0) ? context.localUtil.Format( A146EmployeeVactionDays, "Z9.9") : context.localUtil.Format( A146EmployeeVactionDays, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeVactionDays_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeVactionDays_Visible, edtEmployeeVactionDays_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Employee.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeName_Internalname, StringUtil.RTrim( A148EmployeeName), StringUtil.RTrim( context.localUtil.Format( A148EmployeeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeName_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeName_Visible, edtEmployeeName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Employee.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGAMUserGUID_Internalname, A111GAMUserGUID, StringUtil.RTrim( context.localUtil.Format( A111GAMUserGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGAMUserGUID_Jsonclick, 0, "Attribute", "", "", "", "", edtGAMUserGUID_Visible, edtGAMUserGUID_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_Employee.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeBalance_Internalname, StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")), StringUtil.LTrim( ((edtEmployeeBalance_Enabled!=0) ? context.localUtil.Format( A147EmployeeBalance, "Z9.9") : context.localUtil.Format( A147EmployeeBalance, "Z9.9"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeBalance_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeBalance_Visible, edtEmployeeBalance_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Employee.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEmployeeVacationDaysSetDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEmployeeVacationDaysSetDate_Internalname, context.localUtil.Format(A177EmployeeVacationDaysSetDate, "99/99/99"), context.localUtil.Format( A177EmployeeVacationDaysSetDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeVacationDaysSetDate_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeVacationDaysSetDate_Visible, edtEmployeeVacationDaysSetDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Employee.htm");
         GxWebStd.gx_bitmap( context, edtEmployeeVacationDaysSetDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtEmployeeVacationDaysSetDate_Visible==0)||(edtEmployeeVacationDaysSetDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Employee.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablesetvacationdaysbtn_modal_Internalname, tblTablesetvacationdaysbtn_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
         /* User Defined Control */
         ucSetvacationdaysbtn_modal.SetProperty("Width", Setvacationdaysbtn_modal_Width);
         ucSetvacationdaysbtn_modal.SetProperty("Title", Setvacationdaysbtn_modal_Title);
         ucSetvacationdaysbtn_modal.SetProperty("ConfirmType", Setvacationdaysbtn_modal_Confirmtype);
         ucSetvacationdaysbtn_modal.SetProperty("BodyType", Setvacationdaysbtn_modal_Bodytype);
         ucSetvacationdaysbtn_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Setvacationdaysbtn_modal_Internalname, "SETVACATIONDAYSBTN_MODALContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"SETVACATIONDAYSBTN_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0114"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0114"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0114"+"");
               }
               WebComp_Wwpaux_wc.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
         }
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_vacationset( )
      {
         /*  Grid Control  */
         StartGridControl76( ) ;
         nGXsfl_76_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount27 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_27 = 1;
               ScanStart0F27( ) ;
               while ( RcdFound27 != 0 )
               {
                  init_level_properties27( ) ;
                  getByPrimaryKey0F27( ) ;
                  AddRow0F27( ) ;
                  ScanNext0F27( ) ;
               }
               ScanEnd0F27( ) ;
               nBlankRcdCount27 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0F27( ) ;
            standaloneModal0F27( ) ;
            sMode27 = Gx_mode;
            while ( nGXsfl_76_idx < nRC_GXsfl_76 )
            {
               bGXsfl_76_Refreshing = true;
               ReadRow0F27( ) ;
               edtVacationSetDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "VACATIONSETDATE_"+sGXsfl_76_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtVacationSetDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacationSetDate_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               edtVacationSetDays_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "VACATIONSETDAYS_"+sGXsfl_76_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtVacationSetDays_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacationSetDays_Enabled), 5, 0), !bGXsfl_76_Refreshing);
               if ( ( nRcdExists_27 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0F27( ) ;
               }
               SendRow0F27( ) ;
               bGXsfl_76_Refreshing = false;
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount27 = 5;
            nRcdExists_27 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0F27( ) ;
               while ( RcdFound27 != 0 )
               {
                  sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7627( ) ;
                  init_level_properties27( ) ;
                  standaloneNotModal0F27( ) ;
                  getByPrimaryKey0F27( ) ;
                  standaloneModal0F27( ) ;
                  AddRow0F27( ) ;
                  ScanNext0F27( ) ;
               }
               ScanEnd0F27( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode27 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx+1), 4, 0), 4, "0");
            SubsflControlProps_7627( ) ;
            InitAll0F27( ) ;
            init_level_properties27( ) ;
            nRcdExists_27 = 0;
            nIsMod_27 = 0;
            nRcdDeleted_27 = 0;
            nBlankRcdCount27 = (short)(nBlankRcdUsr27+nBlankRcdCount27);
            fRowAdded = 0;
            while ( nBlankRcdCount27 > 0 )
            {
               standaloneNotModal0F27( ) ;
               standaloneModal0F27( ) ;
               AddRow0F27( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtVacationSetDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount27 = (short)(nBlankRcdCount27-1);
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_vacationsetContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_vacationset", Gridlevel_vacationsetContainer, subGridlevel_vacationset_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_vacationsetContainerData", Gridlevel_vacationsetContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_vacationsetContainerData"+"V", Gridlevel_vacationsetContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_vacationsetContainerData"+"V"+"\" value='"+Gridlevel_vacationsetContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_project( )
      {
         /*  Grid Control  */
         StartGridControl84( ) ;
         nGXsfl_84_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount17 = 1;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_17 = 1;
               ScanStart0F17( ) ;
               while ( RcdFound17 != 0 )
               {
                  init_level_properties17( ) ;
                  getByPrimaryKey0F17( ) ;
                  AddRow0F17( ) ;
                  ScanNext0F17( ) ;
               }
               ScanEnd0F17( ) ;
               nBlankRcdCount17 = 1;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0F17( ) ;
            standaloneModal0F17( ) ;
            sMode17 = Gx_mode;
            while ( nGXsfl_84_idx < nRC_GXsfl_84 )
            {
               bGXsfl_84_Refreshing = true;
               ReadRow0F17( ) ;
               edtProjectId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROJECTID_"+sGXsfl_84_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
               edtProjectId_Horizontalalignment = cgiGet( "PROJECTID_"+sGXsfl_84_idx+"Horizontalalignment");
               AssignProp("", false, edtProjectId_Internalname, "Horizontalalignment", edtProjectId_Horizontalalignment, !bGXsfl_84_Refreshing);
               chkEmployeeIsActiveInProject.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "EMPLOYEEISACTIVEINPROJECT_"+sGXsfl_84_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkEmployeeIsActiveInProject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActiveInProject.Enabled), 5, 0), !bGXsfl_84_Refreshing);
               if ( ( nRcdExists_17 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0F17( ) ;
               }
               SendRow0F17( ) ;
               bGXsfl_84_Refreshing = false;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount17 = 1;
            nRcdExists_17 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0F17( ) ;
               while ( RcdFound17 != 0 )
               {
                  sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8417( ) ;
                  init_level_properties17( ) ;
                  standaloneNotModal0F17( ) ;
                  getByPrimaryKey0F17( ) ;
                  standaloneModal0F17( ) ;
                  AddRow0F17( ) ;
                  ScanNext0F17( ) ;
               }
               ScanEnd0F17( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode17 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8417( ) ;
            InitAll0F17( ) ;
            init_level_properties17( ) ;
            nRcdExists_17 = 0;
            nIsMod_17 = 0;
            nRcdDeleted_17 = 0;
            nBlankRcdCount17 = (short)(nBlankRcdUsr17+nBlankRcdCount17);
            fRowAdded = 0;
            while ( nBlankRcdCount17 > 0 )
            {
               standaloneNotModal0F17( ) ;
               standaloneModal0F17( ) ;
               AddRow0F17( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProjectId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount17 = (short)(nBlankRcdCount17-1);
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_projectContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_project", Gridlevel_projectContainer, subGridlevel_project_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_projectContainerData", Gridlevel_projectContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_projectContainerData"+"V", Gridlevel_projectContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_projectContainerData"+"V"+"\" value='"+Gridlevel_projectContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
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
         E120F2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vPROJECTID_DATA"), AV15ProjectId_Data);
               /* Read saved values. */
               Z106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
               Z147EmployeeBalance = context.localUtil.CToN( cgiGet( "Z147EmployeeBalance"), ".", ",");
               Z148EmployeeName = cgiGet( "Z148EmployeeName");
               Z111GAMUserGUID = cgiGet( "Z111GAMUserGUID");
               Z107EmployeeFirstName = cgiGet( "Z107EmployeeFirstName");
               Z108EmployeeLastName = cgiGet( "Z108EmployeeLastName");
               Z109EmployeeEmail = cgiGet( "Z109EmployeeEmail");
               Z110EmployeeIsManager = StringUtil.StrToBool( cgiGet( "Z110EmployeeIsManager"));
               Z112EmployeeIsActive = StringUtil.StrToBool( cgiGet( "Z112EmployeeIsActive"));
               Z146EmployeeVactionDays = context.localUtil.CToN( cgiGet( "Z146EmployeeVactionDays"), ".", ",");
               Z177EmployeeVacationDaysSetDate = context.localUtil.CToD( cgiGet( "Z177EmployeeVacationDaysSetDate"), 0);
               Z187EmployeeAPIPassword = cgiGet( "Z187EmployeeAPIPassword");
               Z188EmployeeFTEHours = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z188EmployeeFTEHours"), ".", ","), 18, MidpointRounding.ToEven));
               Z100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               A187EmployeeAPIPassword = cgiGet( "Z187EmployeeAPIPassword");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_76 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_76"), ".", ","), 18, MidpointRounding.ToEven));
               nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","), 18, MidpointRounding.ToEven));
               N100CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N100CompanyId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPLOYEEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_CompanyId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_COMPANYID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV24Password = cgiGet( "vPASSWORD");
               A187EmployeeAPIPassword = cgiGet( "EMPLOYEEAPIPASSWORD");
               A101CompanyName = cgiGet( "COMPANYNAME");
               AV33Pgmname = cgiGet( "vPGMNAME");
               A189VacationSetDescription = cgiGet( "VACATIONSETDESCRIPTION");
               n189VacationSetDescription = false;
               n189VacationSetDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A189VacationSetDescription)) ? true : false);
               A103ProjectName = cgiGet( "PROJECTNAME");
               Combo_projectid_Objectcall = cgiGet( "COMBO_PROJECTID_Objectcall");
               Combo_projectid_Class = cgiGet( "COMBO_PROJECTID_Class");
               Combo_projectid_Icontype = cgiGet( "COMBO_PROJECTID_Icontype");
               Combo_projectid_Icon = cgiGet( "COMBO_PROJECTID_Icon");
               Combo_projectid_Caption = cgiGet( "COMBO_PROJECTID_Caption");
               Combo_projectid_Tooltip = cgiGet( "COMBO_PROJECTID_Tooltip");
               Combo_projectid_Cls = cgiGet( "COMBO_PROJECTID_Cls");
               Combo_projectid_Selectedvalue_set = cgiGet( "COMBO_PROJECTID_Selectedvalue_set");
               Combo_projectid_Selectedvalue_get = cgiGet( "COMBO_PROJECTID_Selectedvalue_get");
               Combo_projectid_Selectedtext_set = cgiGet( "COMBO_PROJECTID_Selectedtext_set");
               Combo_projectid_Selectedtext_get = cgiGet( "COMBO_PROJECTID_Selectedtext_get");
               Combo_projectid_Gamoauthtoken = cgiGet( "COMBO_PROJECTID_Gamoauthtoken");
               Combo_projectid_Ddointernalname = cgiGet( "COMBO_PROJECTID_Ddointernalname");
               Combo_projectid_Titlecontrolalign = cgiGet( "COMBO_PROJECTID_Titlecontrolalign");
               Combo_projectid_Dropdownoptionstype = cgiGet( "COMBO_PROJECTID_Dropdownoptionstype");
               Combo_projectid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Enabled"));
               Combo_projectid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Visible"));
               Combo_projectid_Titlecontrolidtoreplace = cgiGet( "COMBO_PROJECTID_Titlecontrolidtoreplace");
               Combo_projectid_Datalisttype = cgiGet( "COMBO_PROJECTID_Datalisttype");
               Combo_projectid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Allowmultipleselection"));
               Combo_projectid_Datalistfixedvalues = cgiGet( "COMBO_PROJECTID_Datalistfixedvalues");
               Combo_projectid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Isgriditem"));
               Combo_projectid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Hasdescription"));
               Combo_projectid_Datalistproc = cgiGet( "COMBO_PROJECTID_Datalistproc");
               Combo_projectid_Datalistprocparametersprefix = cgiGet( "COMBO_PROJECTID_Datalistprocparametersprefix");
               Combo_projectid_Remoteservicesparameters = cgiGet( "COMBO_PROJECTID_Remoteservicesparameters");
               Combo_projectid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROJECTID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_projectid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Includeonlyselectedoption"));
               Combo_projectid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Includeselectalloption"));
               Combo_projectid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Emptyitem"));
               Combo_projectid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROJECTID_Includeaddnewoption"));
               Combo_projectid_Htmltemplate = cgiGet( "COMBO_PROJECTID_Htmltemplate");
               Combo_projectid_Multiplevaluestype = cgiGet( "COMBO_PROJECTID_Multiplevaluestype");
               Combo_projectid_Loadingdata = cgiGet( "COMBO_PROJECTID_Loadingdata");
               Combo_projectid_Noresultsfound = cgiGet( "COMBO_PROJECTID_Noresultsfound");
               Combo_projectid_Emptyitemtext = cgiGet( "COMBO_PROJECTID_Emptyitemtext");
               Combo_projectid_Onlyselectedvalues = cgiGet( "COMBO_PROJECTID_Onlyselectedvalues");
               Combo_projectid_Selectalltext = cgiGet( "COMBO_PROJECTID_Selectalltext");
               Combo_projectid_Multiplevaluesseparator = cgiGet( "COMBO_PROJECTID_Multiplevaluesseparator");
               Combo_projectid_Addnewoptiontext = cgiGet( "COMBO_PROJECTID_Addnewoptiontext");
               Combo_projectid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROJECTID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
               Setvacationdaysbtn_modal_Objectcall = cgiGet( "SETVACATIONDAYSBTN_MODAL_Objectcall");
               Setvacationdaysbtn_modal_Enabled = StringUtil.StrToBool( cgiGet( "SETVACATIONDAYSBTN_MODAL_Enabled"));
               Setvacationdaysbtn_modal_Width = cgiGet( "SETVACATIONDAYSBTN_MODAL_Width");
               Setvacationdaysbtn_modal_Height = cgiGet( "SETVACATIONDAYSBTN_MODAL_Height");
               Setvacationdaysbtn_modal_Class = cgiGet( "SETVACATIONDAYSBTN_MODAL_Class");
               Setvacationdaysbtn_modal_Title = cgiGet( "SETVACATIONDAYSBTN_MODAL_Title");
               Setvacationdaysbtn_modal_Confirmationtext = cgiGet( "SETVACATIONDAYSBTN_MODAL_Confirmationtext");
               Setvacationdaysbtn_modal_Yesbuttoncaption = cgiGet( "SETVACATIONDAYSBTN_MODAL_Yesbuttoncaption");
               Setvacationdaysbtn_modal_Nobuttoncaption = cgiGet( "SETVACATIONDAYSBTN_MODAL_Nobuttoncaption");
               Setvacationdaysbtn_modal_Cancelbuttoncaption = cgiGet( "SETVACATIONDAYSBTN_MODAL_Cancelbuttoncaption");
               Setvacationdaysbtn_modal_Yesbuttonposition = cgiGet( "SETVACATIONDAYSBTN_MODAL_Yesbuttonposition");
               Setvacationdaysbtn_modal_Confirmtype = cgiGet( "SETVACATIONDAYSBTN_MODAL_Confirmtype");
               Setvacationdaysbtn_modal_Comment = cgiGet( "SETVACATIONDAYSBTN_MODAL_Comment");
               Setvacationdaysbtn_modal_Bodytype = cgiGet( "SETVACATIONDAYSBTN_MODAL_Bodytype");
               Setvacationdaysbtn_modal_Bodycontentinternalname = cgiGet( "SETVACATIONDAYSBTN_MODAL_Bodycontentinternalname");
               Setvacationdaysbtn_modal_Result = cgiGet( "SETVACATIONDAYSBTN_MODAL_Result");
               Setvacationdaysbtn_modal_Texttype = cgiGet( "SETVACATIONDAYSBTN_MODAL_Texttype");
               Setvacationdaysbtn_modal_Focusedbutton = cgiGet( "SETVACATIONDAYSBTN_MODAL_Focusedbutton");
               Setvacationdaysbtn_modal_Visible = StringUtil.StrToBool( cgiGet( "SETVACATIONDAYSBTN_MODAL_Visible"));
               /* Read variables values. */
               A107EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
               AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
               A108EmployeeLastName = cgiGet( edtEmployeeLastName_Internalname);
               AssignAttri("", false, "A108EmployeeLastName", A108EmployeeLastName);
               A109EmployeeEmail = cgiGet( edtEmployeeEmail_Internalname);
               AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
               dynCompanyId.Name = dynCompanyId_Internalname;
               dynCompanyId.CurrentValue = cgiGet( dynCompanyId_Internalname);
               A100CompanyId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynCompanyId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
               A112EmployeeIsActive = StringUtil.StrToBool( cgiGet( chkEmployeeIsActive_Internalname));
               AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
               A110EmployeeIsManager = StringUtil.StrToBool( cgiGet( chkEmployeeIsManager_Internalname));
               AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
               AV30EmployeeBalance = context.localUtil.CToN( cgiGet( edtavEmployeebalance_Internalname), ".", ",");
               AssignAttri("", false, "AV30EmployeeBalance", StringUtil.LTrimStr( AV30EmployeeBalance, 4, 1));
               if ( ( ( context.localUtil.CToN( cgiGet( edtEmployeeFTEHours_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmployeeFTEHours_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEEFTEHOURS");
                  AnyError = 1;
                  GX_FocusControl = edtEmployeeFTEHours_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A188EmployeeFTEHours = 0;
                  AssignAttri("", false, "A188EmployeeFTEHours", StringUtil.LTrimStr( (decimal)(A188EmployeeFTEHours), 4, 0));
               }
               else
               {
                  A188EmployeeFTEHours = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeFTEHours_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A188EmployeeFTEHours", StringUtil.LTrimStr( (decimal)(A188EmployeeFTEHours), 4, 0));
               }
               AV31EmployeeAPIPassword = cgiGet( edtavEmployeeapipassword_Internalname);
               AssignAttri("", false, "AV31EmployeeAPIPassword", AV31EmployeeAPIPassword);
               A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtEmployeeVactionDays_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmployeeVactionDays_Internalname), ".", ",") > 99.9m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEEVACTIONDAYS");
                  AnyError = 1;
                  GX_FocusControl = edtEmployeeVactionDays_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A146EmployeeVactionDays = 0;
                  AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( A146EmployeeVactionDays, 4, 1));
               }
               else
               {
                  A146EmployeeVactionDays = context.localUtil.CToN( cgiGet( edtEmployeeVactionDays_Internalname), ".", ",");
                  AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( A146EmployeeVactionDays, 4, 1));
               }
               A148EmployeeName = cgiGet( edtEmployeeName_Internalname);
               AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
               A111GAMUserGUID = cgiGet( edtGAMUserGUID_Internalname);
               AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
               A147EmployeeBalance = context.localUtil.CToN( cgiGet( edtEmployeeBalance_Internalname), ".", ",");
               AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
               if ( context.localUtil.VCDate( cgiGet( edtEmployeeVacationDaysSetDate_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Employee Vacation Days Set Date"}), 1, "EMPLOYEEVACATIONDAYSSETDATE");
                  AnyError = 1;
                  GX_FocusControl = edtEmployeeVacationDaysSetDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A177EmployeeVacationDaysSetDate = DateTime.MinValue;
                  AssignAttri("", false, "A177EmployeeVacationDaysSetDate", context.localUtil.Format(A177EmployeeVacationDaysSetDate, "99/99/99"));
               }
               else
               {
                  A177EmployeeVacationDaysSetDate = context.localUtil.CToD( cgiGet( edtEmployeeVacationDaysSetDate_Internalname), 2);
                  AssignAttri("", false, "A177EmployeeVacationDaysSetDate", context.localUtil.Format(A177EmployeeVacationDaysSetDate, "99/99/99"));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Employee");
               A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               forbiddenHiddens.Add("EmployeeId", context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("EmployeeAPIPassword", StringUtil.RTrim( context.localUtil.Format( A187EmployeeAPIPassword, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A106EmployeeId != Z106EmployeeId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("employee:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
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
                     sMode16 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode16;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound16 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "EMPLOYEEID");
                        AnyError = 1;
                        GX_FocusControl = edtEmployeeId_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_PROJECTID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Combo_projectid.Onoptionclicked */
                           E130F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SETVACATIONDAYSBTN_MODAL.CLOSE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Setvacationdaysbtn_modal.Close */
                           E140F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SETVACATIONDAYSBTN_MODAL.ONLOADCOMPONENT") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Setvacationdaysbtn_modal.Onloadcomponent */
                           E150F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E120F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E160F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'DoUserAction1' */
                           E170F2 ();
                           nKeyPressed = 3;
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 4);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 114 )
                     {
                        OldWwpaux_wc = cgiGet( "W0114");
                        if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                        {
                           WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                           WebComp_Wwpaux_wc.ComponentInit();
                           WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                        {
                           WebComp_Wwpaux_wc.componentprocess("W0114", "", sEvt);
                        }
                        WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
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
            E160F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0F16( ) ;
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
            DisableAttributes0F16( ) ;
         }
         AssignProp("", false, edtavEmployeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployeebalance_Enabled), 5, 0), true);
         AssignProp("", false, edtavEmployeeapipassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployeeapipassword_Enabled), 5, 0), true);
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F16( ) ;
            }
            else
            {
               CheckExtendedTable0F16( ) ;
               CloseExtendedTableCursors0F16( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode16 = Gx_mode;
            CONFIRM_0F27( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0F17( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode16;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  IsConfirmed = 1;
                  AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0F17( )
      {
         nGXsfl_84_idx = 0;
         while ( nGXsfl_84_idx < nRC_GXsfl_84 )
         {
            ReadRow0F17( ) ;
            if ( ( nRcdExists_17 != 0 ) || ( nIsMod_17 != 0 ) )
            {
               GetKey0F17( ) ;
               if ( ( nRcdExists_17 == 0 ) && ( nRcdDeleted_17 == 0 ) )
               {
                  if ( RcdFound17 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0F17( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0F17( ) ;
                        CloseExtendedTableCursors0F17( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PROJECTID_" + sGXsfl_84_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProjectId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound17 != 0 )
                  {
                     if ( nRcdDeleted_17 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0F17( ) ;
                        Load0F17( ) ;
                        BeforeValidate0F17( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0F17( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_17 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0F17( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0F17( ) ;
                              CloseExtendedTableCursors0F17( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_17 == 0 )
                     {
                        GXCCtl = "PROJECTID_" + sGXsfl_84_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProjectId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProjectId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", ""))) ;
            ChangePostValue( chkEmployeeIsActiveInProject_Internalname, StringUtil.BoolToStr( A184EmployeeIsActiveInProject)) ;
            ChangePostValue( "ZT_"+"Z102ProjectId_"+sGXsfl_84_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102ProjectId), 10, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z184EmployeeIsActiveInProject_"+sGXsfl_84_idx, StringUtil.BoolToStr( Z184EmployeeIsActiveInProject)) ;
            ChangePostValue( "nRcdDeleted_17_"+sGXsfl_84_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_17), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_17_"+sGXsfl_84_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_17), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_17_"+sGXsfl_84_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_17), 4, 0, ".", ""))) ;
            if ( nIsMod_17 != 0 )
            {
               ChangePostValue( "PROJECTID_"+sGXsfl_84_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProjectId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROJECTID_"+sGXsfl_84_idx+"Horizontalalignment", StringUtil.RTrim( edtProjectId_Horizontalalignment)) ;
               ChangePostValue( "EMPLOYEEISACTIVEINPROJECT_"+sGXsfl_84_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEmployeeIsActiveInProject.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0F27( )
      {
         nGXsfl_76_idx = 0;
         while ( nGXsfl_76_idx < nRC_GXsfl_76 )
         {
            ReadRow0F27( ) ;
            if ( ( nRcdExists_27 != 0 ) || ( nIsMod_27 != 0 ) )
            {
               GetKey0F27( ) ;
               if ( ( nRcdExists_27 == 0 ) && ( nRcdDeleted_27 == 0 ) )
               {
                  if ( RcdFound27 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0F27( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0F27( ) ;
                        CloseExtendedTableCursors0F27( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "VACATIONSETDATE_" + sGXsfl_76_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtVacationSetDate_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound27 != 0 )
                  {
                     if ( nRcdDeleted_27 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0F27( ) ;
                        Load0F27( ) ;
                        BeforeValidate0F27( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0F27( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_27 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0F27( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0F27( ) ;
                              CloseExtendedTableCursors0F27( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_27 == 0 )
                     {
                        GXCCtl = "VACATIONSETDATE_" + sGXsfl_76_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtVacationSetDate_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtVacationSetDate_Internalname, context.localUtil.Format(A186VacationSetDate, "99/99/99")) ;
            ChangePostValue( edtVacationSetDays_Internalname, StringUtil.LTrim( StringUtil.NToC( A179VacationSetDays, 4, 1, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z186VacationSetDate_"+sGXsfl_76_idx, context.localUtil.DToC( Z186VacationSetDate, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z179VacationSetDays_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( Z179VacationSetDays, 4, 1, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z189VacationSetDescription_"+sGXsfl_76_idx, Z189VacationSetDescription) ;
            ChangePostValue( "nRcdDeleted_27_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_27), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_27_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_27), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_27_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_27), 4, 0, ".", ""))) ;
            if ( nIsMod_27 != 0 )
            {
               ChangePostValue( "VACATIONSETDATE_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacationSetDate_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "VACATIONSETDAYS_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacationSetDays_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0F0( )
      {
      }

      protected void E120F2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         Combo_projectid_Titlecontrolidtoreplace = edtProjectId_Internalname;
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "TitleControlIdToReplace", Combo_projectid_Titlecontrolidtoreplace);
         edtProjectId_Horizontalalignment = "Left";
         AssignProp("", false, edtProjectId_Internalname, "Horizontalalignment", edtProjectId_Horizontalalignment, !bGXsfl_84_Refreshing);
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV33Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV34GXV1 = 1;
            AssignAttri("", false, "AV34GXV1", StringUtil.LTrimStr( (decimal)(AV34GXV1), 8, 0));
            while ( AV34GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV34GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CompanyId") == 0 )
               {
                  AV13Insert_CompanyId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_CompanyId", StringUtil.LTrimStr( (decimal)(AV13Insert_CompanyId), 10, 0));
               }
               AV34GXV1 = (int)(AV34GXV1+1);
               AssignAttri("", false, "AV34GXV1", StringUtil.LTrimStr( (decimal)(AV34GXV1), 8, 0));
            }
         }
         edtEmployeeId_Visible = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), true);
         edtEmployeeVactionDays_Visible = 0;
         AssignProp("", false, edtEmployeeVactionDays_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeVactionDays_Visible), 5, 0), true);
         edtEmployeeName_Visible = 0;
         AssignProp("", false, edtEmployeeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Visible), 5, 0), true);
         edtGAMUserGUID_Visible = 0;
         AssignProp("", false, edtGAMUserGUID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtGAMUserGUID_Visible), 5, 0), true);
         edtEmployeeBalance_Visible = 0;
         AssignProp("", false, edtEmployeeBalance_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeBalance_Visible), 5, 0), true);
         edtEmployeeVacationDaysSetDate_Visible = 0;
         AssignProp("", false, edtEmployeeVacationDaysSetDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeVacationDaysSetDate_Visible), 5, 0), true);
      }

      protected void E160F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("employeeww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E170F2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         GXt_char1 = AV31EmployeeAPIPassword;
         new prc_setemployeepassword(context ).execute(  A106EmployeeId, out  GXt_char1) ;
         AV31EmployeeAPIPassword = GXt_char1;
         AssignAttri("", false, "AV31EmployeeAPIPassword", AV31EmployeeAPIPassword);
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void E150F2( )
      {
         /* Setvacationdaysbtn_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_SetEmployeeVacationDays")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_setemployeevacationdays", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WC_SetEmployeeVacationDays";
            WebComp_Wwpaux_wc_Component = "WC_SetEmployeeVacationDays";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0114",(string)"",(long)A106EmployeeId,DateTimeUtil.Today( context),(string)"INS"});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)""+"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0114"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPROJECTID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item2 = AV15ProjectId_Data;
         new employeeloaddvcombo(context ).execute(  "ProjectId",  Gx_mode,  AV7EmployeeId, out  AV17ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item2) ;
         AV15ProjectId_Data = GXt_objcol_SdtDVB_SDTComboData_Item2;
      }

      protected void E130F2( )
      {
         /* Combo_projectid_Onoptionclicked Routine */
         returnInSub = false;
         AV28Value = Combo_projectid_Caption;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV28Value))) )
         {
            subgridlevel_project_addlines( 1) ;
         }
      }

      protected void E140F2( )
      {
         /* Setvacationdaysbtn_modal_Close Routine */
         returnInSub = false;
         GXt_decimal3 = AV30EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         AV30EmployeeBalance = GXt_decimal3;
         AssignAttri("", false, "AV30EmployeeBalance", StringUtil.LTrimStr( AV30EmployeeBalance, 4, 1));
         /*  Sending Event outputs  */
      }

      protected void ZM0F16( short GX_JID )
      {
         if ( ( GX_JID == 33 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z147EmployeeBalance = T000F8_A147EmployeeBalance[0];
               Z148EmployeeName = T000F8_A148EmployeeName[0];
               Z111GAMUserGUID = T000F8_A111GAMUserGUID[0];
               Z107EmployeeFirstName = T000F8_A107EmployeeFirstName[0];
               Z108EmployeeLastName = T000F8_A108EmployeeLastName[0];
               Z109EmployeeEmail = T000F8_A109EmployeeEmail[0];
               Z110EmployeeIsManager = T000F8_A110EmployeeIsManager[0];
               Z112EmployeeIsActive = T000F8_A112EmployeeIsActive[0];
               Z146EmployeeVactionDays = T000F8_A146EmployeeVactionDays[0];
               Z177EmployeeVacationDaysSetDate = T000F8_A177EmployeeVacationDaysSetDate[0];
               Z187EmployeeAPIPassword = T000F8_A187EmployeeAPIPassword[0];
               Z188EmployeeFTEHours = T000F8_A188EmployeeFTEHours[0];
               Z100CompanyId = T000F8_A100CompanyId[0];
            }
            else
            {
               Z147EmployeeBalance = A147EmployeeBalance;
               Z148EmployeeName = A148EmployeeName;
               Z111GAMUserGUID = A111GAMUserGUID;
               Z107EmployeeFirstName = A107EmployeeFirstName;
               Z108EmployeeLastName = A108EmployeeLastName;
               Z109EmployeeEmail = A109EmployeeEmail;
               Z110EmployeeIsManager = A110EmployeeIsManager;
               Z112EmployeeIsActive = A112EmployeeIsActive;
               Z146EmployeeVactionDays = A146EmployeeVactionDays;
               Z177EmployeeVacationDaysSetDate = A177EmployeeVacationDaysSetDate;
               Z187EmployeeAPIPassword = A187EmployeeAPIPassword;
               Z188EmployeeFTEHours = A188EmployeeFTEHours;
               Z100CompanyId = A100CompanyId;
            }
         }
         if ( GX_JID == -33 )
         {
            Z147EmployeeBalance = A147EmployeeBalance;
            Z106EmployeeId = A106EmployeeId;
            Z148EmployeeName = A148EmployeeName;
            Z111GAMUserGUID = A111GAMUserGUID;
            Z107EmployeeFirstName = A107EmployeeFirstName;
            Z108EmployeeLastName = A108EmployeeLastName;
            Z109EmployeeEmail = A109EmployeeEmail;
            Z110EmployeeIsManager = A110EmployeeIsManager;
            Z112EmployeeIsActive = A112EmployeeIsActive;
            Z146EmployeeVactionDays = A146EmployeeVactionDays;
            Z177EmployeeVacationDaysSetDate = A177EmployeeVacationDaysSetDate;
            Z187EmployeeAPIPassword = A187EmployeeAPIPassword;
            Z188EmployeeFTEHours = A188EmployeeFTEHours;
            Z100CompanyId = A100CompanyId;
            Z101CompanyName = A101CompanyName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         GXt_boolean4 = false;
         new userhasrole(context ).execute(  "Manager", out  GXt_boolean4) ;
         GXt_boolean5 = false;
         new userhasrole(context ).execute(  "Project Manager", out  GXt_boolean5) ;
         if ( ( GXt_boolean4 ) || ( GXt_boolean5 ) )
         {
            bttBtnsetvacationdaysbtn_Visible = 1;
            AssignProp("", false, bttBtnsetvacationdaysbtn_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsetvacationdaysbtn_Visible), 5, 0), true);
         }
         else
         {
            GXt_boolean5 = false;
            new userhasrole(context ).execute(  "Manager", out  GXt_boolean5) ;
            GXt_boolean4 = false;
            new userhasrole(context ).execute(  "Project Manager", out  GXt_boolean4) ;
            if ( ! ( ( GXt_boolean5 ) || ( GXt_boolean4 ) ) )
            {
               bttBtnsetvacationdaysbtn_Visible = 0;
               AssignProp("", false, bttBtnsetvacationdaysbtn_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsetvacationdaysbtn_Visible), 5, 0), true);
            }
         }
         divUnnamedtable2_Visible = (((StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable2_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtEmployeeEmail_Enabled = 0;
            AssignProp("", false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), true);
         }
         else
         {
            edtEmployeeEmail_Enabled = 1;
            AssignProp("", false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), true);
         }
         AV33Pgmname = "Employee";
         AssignAttri("", false, "AV33Pgmname", AV33Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            dynCompanyId.Enabled = 0;
            AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         }
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EmployeeId) )
         {
            A106EmployeeId = AV7EmployeeId;
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            dynCompanyId.Enabled = 0;
            AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         }
         else
         {
            GXt_boolean5 = false;
            new userhasrole(context ).execute(  "Manager", out  GXt_boolean5) ;
            if ( GXt_boolean5 )
            {
               dynCompanyId.Enabled = 0;
               AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
            }
            else
            {
               dynCompanyId.Enabled = 1;
               AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
            }
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            chkEmployeeIsActive.Enabled = 0;
            AssignProp("", false, chkEmployeeIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Enabled), 5, 0), true);
         }
         else
         {
            chkEmployeeIsActive.Enabled = 1;
            AssignProp("", false, chkEmployeeIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Enabled), 5, 0), true);
         }
         if ( IsIns( )  )
         {
            chkEmployeeIsActive.Enabled = 0;
            AssignProp("", false, chkEmployeeIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            A100CompanyId = AV13Insert_CompanyId;
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         else
         {
            GXt_boolean5 = false;
            new userhasrole(context ).execute(  "Manager", out  GXt_boolean5) ;
            if ( GXt_boolean5 )
            {
               GXt_int6 = A100CompanyId;
               new getloggedinusercompanyid(context ).execute( out  GXt_int6) ;
               A100CompanyId = GXt_int6;
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            edtEmployeeEmail_Enabled = 0;
            AssignProp("", false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (false==A112EmployeeIsActive) && ( Gx_BScreen == 0 ) )
         {
            A112EmployeeIsActive = false;
            AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
         }
         if ( IsIns( )  && (Convert.ToDecimal(0)==A146EmployeeVactionDays) && ( Gx_BScreen == 0 ) )
         {
            A146EmployeeVactionDays = (decimal)(21);
            AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( A146EmployeeVactionDays, 4, 1));
         }
         if ( IsIns( )  && (0==A188EmployeeFTEHours) && ( Gx_BScreen == 0 ) )
         {
            A188EmployeeFTEHours = 40;
            AssignAttri("", false, "A188EmployeeFTEHours", StringUtil.LTrimStr( (decimal)(A188EmployeeFTEHours), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXt_decimal3 = A147EmployeeBalance;
            new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
            A147EmployeeBalance = GXt_decimal3;
            AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
            GXt_decimal3 = A147EmployeeBalance;
            new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
            A147EmployeeBalance = GXt_decimal3;
            AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
            GXt_decimal3 = AV30EmployeeBalance;
            new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
            AV30EmployeeBalance = GXt_decimal3;
            AssignAttri("", false, "AV30EmployeeBalance", StringUtil.LTrimStr( AV30EmployeeBalance, 4, 1));
            /* Using cursor T000F9 */
            pr_default.execute(7, new Object[] {A100CompanyId});
            A101CompanyName = T000F9_A101CompanyName[0];
            pr_default.close(7);
         }
      }

      protected void Load0F16( )
      {
         /* Using cursor T000F10 */
         pr_default.execute(8, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound16 = 1;
            A147EmployeeBalance = T000F10_A147EmployeeBalance[0];
            AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
            A148EmployeeName = T000F10_A148EmployeeName[0];
            AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
            A111GAMUserGUID = T000F10_A111GAMUserGUID[0];
            AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
            A107EmployeeFirstName = T000F10_A107EmployeeFirstName[0];
            AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
            A108EmployeeLastName = T000F10_A108EmployeeLastName[0];
            AssignAttri("", false, "A108EmployeeLastName", A108EmployeeLastName);
            A109EmployeeEmail = T000F10_A109EmployeeEmail[0];
            AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
            A101CompanyName = T000F10_A101CompanyName[0];
            A110EmployeeIsManager = T000F10_A110EmployeeIsManager[0];
            AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
            A112EmployeeIsActive = T000F10_A112EmployeeIsActive[0];
            AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
            A146EmployeeVactionDays = T000F10_A146EmployeeVactionDays[0];
            AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( A146EmployeeVactionDays, 4, 1));
            A177EmployeeVacationDaysSetDate = T000F10_A177EmployeeVacationDaysSetDate[0];
            AssignAttri("", false, "A177EmployeeVacationDaysSetDate", context.localUtil.Format(A177EmployeeVacationDaysSetDate, "99/99/99"));
            A187EmployeeAPIPassword = T000F10_A187EmployeeAPIPassword[0];
            A188EmployeeFTEHours = T000F10_A188EmployeeFTEHours[0];
            AssignAttri("", false, "A188EmployeeFTEHours", StringUtil.LTrimStr( (decimal)(A188EmployeeFTEHours), 4, 0));
            A100CompanyId = T000F10_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            ZM0F16( -33) ;
         }
         pr_default.close(8);
         OnLoadActions0F16( ) ;
      }

      protected void OnLoadActions0F16( )
      {
         GXt_decimal3 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         A147EmployeeBalance = GXt_decimal3;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
         GXt_decimal3 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         A147EmployeeBalance = GXt_decimal3;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
         GXt_decimal3 = AV30EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         AV30EmployeeBalance = GXt_decimal3;
         AssignAttri("", false, "AV30EmployeeBalance", StringUtil.LTrimStr( AV30EmployeeBalance, 4, 1));
         A148EmployeeName = StringUtil.Trim( A107EmployeeFirstName) + " " + StringUtil.Trim( A108EmployeeLastName);
         AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
      }

      protected void CheckExtendedTable0F16( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000F11 */
         pr_default.execute(9, new Object[] {A109EmployeeEmail, A106EmployeeId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Employee Email"}), 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(9);
         GXt_decimal3 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         A147EmployeeBalance = GXt_decimal3;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
         GXt_decimal3 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         A147EmployeeBalance = GXt_decimal3;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
         GXt_decimal3 = AV30EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         AV30EmployeeBalance = GXt_decimal3;
         AssignAttri("", false, "AV30EmployeeBalance", StringUtil.LTrimStr( AV30EmployeeBalance, 4, 1));
         A148EmployeeName = StringUtil.Trim( A107EmployeeFirstName) + " " + StringUtil.Trim( A108EmployeeLastName);
         AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A107EmployeeFirstName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee First Name", "", "", "", "", "", "", "", ""), 1, "EMPLOYEEFIRSTNAME");
            AnyError = 1;
            GX_FocusControl = edtEmployeeFirstName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A108EmployeeLastName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee Last Name", "", "", "", "", "", "", "", ""), 1, "EMPLOYEELASTNAME");
            AnyError = 1;
            GX_FocusControl = edtEmployeeLastName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A109EmployeeEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Employee Email does not match the specified pattern", "OutOfRange", 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee Email", "", "", "", "", "", "", "", ""), 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Work hours/minutes are required",  "error",  "#"+edtEmployeeEmail_Internalname,  "true",  ""), 0, "EMPLOYEEEMAIL");
         }
         /* Using cursor T000F9 */
         pr_default.execute(7, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = dynCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A101CompanyName = T000F9_A101CompanyName[0];
         pr_default.close(7);
         if ( (0==A100CompanyId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Company Id", "", "", "", "", "", "", "", ""), 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = dynCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0F16( )
      {
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_35( long A100CompanyId )
      {
         /* Using cursor T000F12 */
         pr_default.execute(10, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = dynCompanyId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A101CompanyName = T000F12_A101CompanyName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A101CompanyName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey0F16( )
      {
         /* Using cursor T000F13 */
         pr_default.execute(11, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F8 */
         pr_default.execute(6, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM0F16( 33) ;
            RcdFound16 = 1;
            A147EmployeeBalance = T000F8_A147EmployeeBalance[0];
            AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
            A106EmployeeId = T000F8_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            A148EmployeeName = T000F8_A148EmployeeName[0];
            AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
            A111GAMUserGUID = T000F8_A111GAMUserGUID[0];
            AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
            A107EmployeeFirstName = T000F8_A107EmployeeFirstName[0];
            AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
            A108EmployeeLastName = T000F8_A108EmployeeLastName[0];
            AssignAttri("", false, "A108EmployeeLastName", A108EmployeeLastName);
            A109EmployeeEmail = T000F8_A109EmployeeEmail[0];
            AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
            A110EmployeeIsManager = T000F8_A110EmployeeIsManager[0];
            AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
            A112EmployeeIsActive = T000F8_A112EmployeeIsActive[0];
            AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
            A146EmployeeVactionDays = T000F8_A146EmployeeVactionDays[0];
            AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( A146EmployeeVactionDays, 4, 1));
            A177EmployeeVacationDaysSetDate = T000F8_A177EmployeeVacationDaysSetDate[0];
            AssignAttri("", false, "A177EmployeeVacationDaysSetDate", context.localUtil.Format(A177EmployeeVacationDaysSetDate, "99/99/99"));
            A187EmployeeAPIPassword = T000F8_A187EmployeeAPIPassword[0];
            A188EmployeeFTEHours = T000F8_A188EmployeeFTEHours[0];
            AssignAttri("", false, "A188EmployeeFTEHours", StringUtil.LTrimStr( (decimal)(A188EmployeeFTEHours), 4, 0));
            A100CompanyId = T000F8_A100CompanyId[0];
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            Z106EmployeeId = A106EmployeeId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0F16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0F16( ) ;
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0F16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F16( ) ;
         if ( RcdFound16 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound16 = 0;
         /* Using cursor T000F14 */
         pr_default.execute(12, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000F14_A106EmployeeId[0] < A106EmployeeId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000F14_A106EmployeeId[0] > A106EmployeeId ) ) )
            {
               A106EmployeeId = T000F14_A106EmployeeId[0];
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound16 = 0;
         /* Using cursor T000F15 */
         pr_default.execute(13, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000F15_A106EmployeeId[0] > A106EmployeeId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000F15_A106EmployeeId[0] < A106EmployeeId ) ) )
            {
               A106EmployeeId = T000F15_A106EmployeeId[0];
               AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmployeeFirstName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F16( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A106EmployeeId != Z106EmployeeId )
               {
                  A106EmployeeId = Z106EmployeeId;
                  AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPLOYEEID");
                  AnyError = 1;
                  GX_FocusControl = edtEmployeeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEmployeeFirstName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0F16( ) ;
                  GX_FocusControl = edtEmployeeFirstName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A106EmployeeId != Z106EmployeeId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEmployeeFirstName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F16( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPLOYEEID");
                     AnyError = 1;
                     GX_FocusControl = edtEmployeeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEmployeeFirstName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F16( ) ;
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
         if ( A106EmployeeId != Z106EmployeeId )
         {
            A106EmployeeId = Z106EmployeeId;
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEmployeeFirstName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void subgridlevel_vacationset_addlines( int nLines )
      {
         nKeyPressed = 4;
         nBlankRcdUsr27 = (short)(nBlankRcdUsr27+nLines);
         if ( isFullAjaxMode( ) && ! bGXsfl_76_Refreshing )
         {
            context.DoAjaxAddLines(76, nLines);
         }
      }

      protected void subgridlevel_project_addlines( int nLines )
      {
         nKeyPressed = 4;
         nBlankRcdUsr17 = (short)(nBlankRcdUsr17+nLines);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxAddLines(84, nLines);
         }
      }

      protected void CheckOptimisticConcurrency0F16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F7 */
            pr_default.execute(5, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(5) == 101) || ( Z147EmployeeBalance != T000F7_A147EmployeeBalance[0] ) || ( StringUtil.StrCmp(Z148EmployeeName, T000F7_A148EmployeeName[0]) != 0 ) || ( StringUtil.StrCmp(Z111GAMUserGUID, T000F7_A111GAMUserGUID[0]) != 0 ) || ( StringUtil.StrCmp(Z107EmployeeFirstName, T000F7_A107EmployeeFirstName[0]) != 0 ) || ( StringUtil.StrCmp(Z108EmployeeLastName, T000F7_A108EmployeeLastName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z109EmployeeEmail, T000F7_A109EmployeeEmail[0]) != 0 ) || ( Z110EmployeeIsManager != T000F7_A110EmployeeIsManager[0] ) || ( Z112EmployeeIsActive != T000F7_A112EmployeeIsActive[0] ) || ( Z146EmployeeVactionDays != T000F7_A146EmployeeVactionDays[0] ) || ( DateTimeUtil.ResetTime ( Z177EmployeeVacationDaysSetDate ) != DateTimeUtil.ResetTime ( T000F7_A177EmployeeVacationDaysSetDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z187EmployeeAPIPassword, T000F7_A187EmployeeAPIPassword[0]) != 0 ) || ( Z188EmployeeFTEHours != T000F7_A188EmployeeFTEHours[0] ) || ( Z100CompanyId != T000F7_A100CompanyId[0] ) )
            {
               if ( Z147EmployeeBalance != T000F7_A147EmployeeBalance[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeBalance");
                  GXUtil.WriteLogRaw("Old: ",Z147EmployeeBalance);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A147EmployeeBalance[0]);
               }
               if ( StringUtil.StrCmp(Z148EmployeeName, T000F7_A148EmployeeName[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeName");
                  GXUtil.WriteLogRaw("Old: ",Z148EmployeeName);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A148EmployeeName[0]);
               }
               if ( StringUtil.StrCmp(Z111GAMUserGUID, T000F7_A111GAMUserGUID[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"GAMUserGUID");
                  GXUtil.WriteLogRaw("Old: ",Z111GAMUserGUID);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A111GAMUserGUID[0]);
               }
               if ( StringUtil.StrCmp(Z107EmployeeFirstName, T000F7_A107EmployeeFirstName[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeFirstName");
                  GXUtil.WriteLogRaw("Old: ",Z107EmployeeFirstName);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A107EmployeeFirstName[0]);
               }
               if ( StringUtil.StrCmp(Z108EmployeeLastName, T000F7_A108EmployeeLastName[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeLastName");
                  GXUtil.WriteLogRaw("Old: ",Z108EmployeeLastName);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A108EmployeeLastName[0]);
               }
               if ( StringUtil.StrCmp(Z109EmployeeEmail, T000F7_A109EmployeeEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeEmail");
                  GXUtil.WriteLogRaw("Old: ",Z109EmployeeEmail);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A109EmployeeEmail[0]);
               }
               if ( Z110EmployeeIsManager != T000F7_A110EmployeeIsManager[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeIsManager");
                  GXUtil.WriteLogRaw("Old: ",Z110EmployeeIsManager);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A110EmployeeIsManager[0]);
               }
               if ( Z112EmployeeIsActive != T000F7_A112EmployeeIsActive[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeIsActive");
                  GXUtil.WriteLogRaw("Old: ",Z112EmployeeIsActive);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A112EmployeeIsActive[0]);
               }
               if ( Z146EmployeeVactionDays != T000F7_A146EmployeeVactionDays[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeVactionDays");
                  GXUtil.WriteLogRaw("Old: ",Z146EmployeeVactionDays);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A146EmployeeVactionDays[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z177EmployeeVacationDaysSetDate ) != DateTimeUtil.ResetTime ( T000F7_A177EmployeeVacationDaysSetDate[0] ) )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeVacationDaysSetDate");
                  GXUtil.WriteLogRaw("Old: ",Z177EmployeeVacationDaysSetDate);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A177EmployeeVacationDaysSetDate[0]);
               }
               if ( StringUtil.StrCmp(Z187EmployeeAPIPassword, T000F7_A187EmployeeAPIPassword[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeAPIPassword");
                  GXUtil.WriteLogRaw("Old: ",Z187EmployeeAPIPassword);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A187EmployeeAPIPassword[0]);
               }
               if ( Z188EmployeeFTEHours != T000F7_A188EmployeeFTEHours[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeFTEHours");
                  GXUtil.WriteLogRaw("Old: ",Z188EmployeeFTEHours);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A188EmployeeFTEHours[0]);
               }
               if ( Z100CompanyId != T000F7_A100CompanyId[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"CompanyId");
                  GXUtil.WriteLogRaw("Old: ",Z100CompanyId);
                  GXUtil.WriteLogRaw("Current: ",T000F7_A100CompanyId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Employee"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F16( )
      {
         if ( ! IsAuthorized("employee_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F16( 0) ;
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F16 */
                     pr_default.execute(14, new Object[] {A147EmployeeBalance, A148EmployeeName, A111GAMUserGUID, A107EmployeeFirstName, A108EmployeeLastName, A109EmployeeEmail, A110EmployeeIsManager, A112EmployeeIsActive, A146EmployeeVactionDays, A177EmployeeVacationDaysSetDate, A187EmployeeAPIPassword, A188EmployeeFTEHours, A100CompanyId});
                     pr_default.close(14);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000F17 */
                     pr_default.execute(15);
                     A106EmployeeId = T000F17_A106EmployeeId[0];
                     AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        new assignemployeerole(context ).execute(  A106EmployeeId) ;
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F16( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0F0( ) ;
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
            else
            {
               Load0F16( ) ;
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void Update0F16( )
      {
         if ( ! IsAuthorized("employee_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F18 */
                     pr_default.execute(16, new Object[] {A147EmployeeBalance, A148EmployeeName, A111GAMUserGUID, A107EmployeeFirstName, A108EmployeeLastName, A109EmployeeEmail, A110EmployeeIsManager, A112EmployeeIsActive, A146EmployeeVactionDays, A177EmployeeVacationDaysSetDate, A187EmployeeAPIPassword, A188EmployeeFTEHours, A100CompanyId, A106EmployeeId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Employee"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        new assignemployeerole(context ).execute(  A106EmployeeId) ;
                        new employeestatuscheck(context ).execute(  A106EmployeeId) ;
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F16( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void DeferredUpdate0F16( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("employee_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F16( ) ;
            AfterConfirm0F16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F16( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0F27( ) ;
                  while ( RcdFound27 != 0 )
                  {
                     getByPrimaryKey0F27( ) ;
                     Delete0F27( ) ;
                     ScanNext0F27( ) ;
                  }
                  ScanEnd0F27( ) ;
                  ScanStart0F17( ) ;
                  while ( RcdFound17 != 0 )
                  {
                     getByPrimaryKey0F17( ) ;
                     Delete0F17( ) ;
                     ScanNext0F17( ) ;
                  }
                  ScanEnd0F17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F19 */
                     pr_default.execute(17, new Object[] {A106EmployeeId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("Employee");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        new deleteemployeeaccount(context ).execute(  A109EmployeeEmail) ;
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
         }
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F16( ) ;
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F16( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_decimal3 = AV30EmployeeBalance;
            new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
            AV30EmployeeBalance = GXt_decimal3;
            AssignAttri("", false, "AV30EmployeeBalance", StringUtil.LTrimStr( AV30EmployeeBalance, 4, 1));
            /* Using cursor T000F20 */
            pr_default.execute(18, new Object[] {A100CompanyId});
            A101CompanyName = T000F20_A101CompanyName[0];
            pr_default.close(18);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000F21 */
            pr_default.execute(19, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Project"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000F22 */
            pr_default.execute(20, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Support Request"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T000F23 */
            pr_default.execute(21, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"LeaveRequest"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T000F24 */
            pr_default.execute(22, new Object[] {A106EmployeeId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void ProcessNestedLevel0F27( )
      {
         nGXsfl_76_idx = 0;
         while ( nGXsfl_76_idx < nRC_GXsfl_76 )
         {
            ReadRow0F27( ) ;
            if ( ( nRcdExists_27 != 0 ) || ( nIsMod_27 != 0 ) )
            {
               standaloneNotModal0F27( ) ;
               GetKey0F27( ) ;
               if ( ( nRcdExists_27 == 0 ) && ( nRcdDeleted_27 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0F27( ) ;
               }
               else
               {
                  if ( RcdFound27 != 0 )
                  {
                     if ( ( nRcdDeleted_27 != 0 ) && ( nRcdExists_27 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0F27( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_27 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0F27( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_27 == 0 )
                     {
                        GXCCtl = "VACATIONSETDATE_" + sGXsfl_76_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtVacationSetDate_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtVacationSetDate_Internalname, context.localUtil.Format(A186VacationSetDate, "99/99/99")) ;
            ChangePostValue( edtVacationSetDays_Internalname, StringUtil.LTrim( StringUtil.NToC( A179VacationSetDays, 4, 1, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z186VacationSetDate_"+sGXsfl_76_idx, context.localUtil.DToC( Z186VacationSetDate, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z179VacationSetDays_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( Z179VacationSetDays, 4, 1, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z189VacationSetDescription_"+sGXsfl_76_idx, Z189VacationSetDescription) ;
            ChangePostValue( "nRcdDeleted_27_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_27), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_27_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_27), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_27_"+sGXsfl_76_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_27), 4, 0, ".", ""))) ;
            if ( nIsMod_27 != 0 )
            {
               ChangePostValue( "VACATIONSETDATE_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacationSetDate_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "VACATIONSETDAYS_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacationSetDays_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0F27( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_27 = 0;
         nIsMod_27 = 0;
         nRcdDeleted_27 = 0;
      }

      protected void ProcessNestedLevel0F17( )
      {
         nGXsfl_84_idx = 0;
         while ( nGXsfl_84_idx < nRC_GXsfl_84 )
         {
            ReadRow0F17( ) ;
            if ( ( nRcdExists_17 != 0 ) || ( nIsMod_17 != 0 ) )
            {
               standaloneNotModal0F17( ) ;
               GetKey0F17( ) ;
               if ( ( nRcdExists_17 == 0 ) && ( nRcdDeleted_17 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0F17( ) ;
               }
               else
               {
                  if ( RcdFound17 != 0 )
                  {
                     if ( ( nRcdDeleted_17 != 0 ) && ( nRcdExists_17 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0F17( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_17 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0F17( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_17 == 0 )
                     {
                        GXCCtl = "PROJECTID_" + sGXsfl_84_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProjectId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProjectId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", ""))) ;
            ChangePostValue( chkEmployeeIsActiveInProject_Internalname, StringUtil.BoolToStr( A184EmployeeIsActiveInProject)) ;
            ChangePostValue( "ZT_"+"Z102ProjectId_"+sGXsfl_84_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102ProjectId), 10, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z184EmployeeIsActiveInProject_"+sGXsfl_84_idx, StringUtil.BoolToStr( Z184EmployeeIsActiveInProject)) ;
            ChangePostValue( "nRcdDeleted_17_"+sGXsfl_84_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_17), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_17_"+sGXsfl_84_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_17), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_17_"+sGXsfl_84_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_17), 4, 0, ".", ""))) ;
            if ( nIsMod_17 != 0 )
            {
               ChangePostValue( "PROJECTID_"+sGXsfl_84_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProjectId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROJECTID_"+sGXsfl_84_idx+"Horizontalalignment", StringUtil.RTrim( edtProjectId_Horizontalalignment)) ;
               ChangePostValue( "EMPLOYEEISACTIVEINPROJECT_"+sGXsfl_84_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEmployeeIsActiveInProject.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0F17( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_17 = 0;
         nIsMod_17 = 0;
         nRcdDeleted_17 = 0;
      }

      protected void ProcessLevel0F16( )
      {
         /* Save parent mode. */
         sMode16 = Gx_mode;
         ProcessNestedLevel0F27( ) ;
         ProcessNestedLevel0F17( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0F16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("employee",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("employee",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F16( )
      {
         /* Scan By routine */
         /* Using cursor T000F25 */
         pr_default.execute(23);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound16 = 1;
            A106EmployeeId = T000F25_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F16( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound16 = 1;
            A106EmployeeId = T000F25_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
      }

      protected void ScanEnd0F16( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm0F16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F16( )
      {
         /* Before Insert Rules */
         new createemployeeaccount(context ).execute(  A109EmployeeEmail,  A107EmployeeFirstName,  A108EmployeeLastName, out  A111GAMUserGUID, out  AV24Password) ;
         AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
         AssignAttri("", false, "AV24Password", AV24Password);
      }

      protected void BeforeUpdate0F16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F16( )
      {
         edtEmployeeFirstName_Enabled = 0;
         AssignProp("", false, edtEmployeeFirstName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeFirstName_Enabled), 5, 0), true);
         edtEmployeeLastName_Enabled = 0;
         AssignProp("", false, edtEmployeeLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeLastName_Enabled), 5, 0), true);
         edtEmployeeEmail_Enabled = 0;
         AssignProp("", false, edtEmployeeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeEmail_Enabled), 5, 0), true);
         dynCompanyId.Enabled = 0;
         AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         chkEmployeeIsActive.Enabled = 0;
         AssignProp("", false, chkEmployeeIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActive.Enabled), 5, 0), true);
         chkEmployeeIsManager.Enabled = 0;
         AssignProp("", false, chkEmployeeIsManager_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsManager.Enabled), 5, 0), true);
         edtavEmployeebalance_Enabled = 0;
         AssignProp("", false, edtavEmployeebalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmployeebalance_Enabled), 5, 0), true);
         edtEmployeeFTEHours_Enabled = 0;
         AssignProp("", false, edtEmployeeFTEHours_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeFTEHours_Enabled), 5, 0), true);
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         edtEmployeeVactionDays_Enabled = 0;
         AssignProp("", false, edtEmployeeVactionDays_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeVactionDays_Enabled), 5, 0), true);
         edtEmployeeName_Enabled = 0;
         AssignProp("", false, edtEmployeeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeName_Enabled), 5, 0), true);
         edtGAMUserGUID_Enabled = 0;
         AssignProp("", false, edtGAMUserGUID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGAMUserGUID_Enabled), 5, 0), true);
         edtEmployeeBalance_Enabled = 0;
         AssignProp("", false, edtEmployeeBalance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeBalance_Enabled), 5, 0), true);
         edtEmployeeVacationDaysSetDate_Enabled = 0;
         AssignProp("", false, edtEmployeeVacationDaysSetDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeVacationDaysSetDate_Enabled), 5, 0), true);
      }

      protected void ZM0F27( short GX_JID )
      {
         if ( ( GX_JID == 36 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z179VacationSetDays = T000F6_A179VacationSetDays[0];
               Z189VacationSetDescription = T000F6_A189VacationSetDescription[0];
            }
            else
            {
               Z179VacationSetDays = A179VacationSetDays;
               Z189VacationSetDescription = A189VacationSetDescription;
            }
         }
         if ( GX_JID == -36 )
         {
            Z106EmployeeId = A106EmployeeId;
            Z186VacationSetDate = A186VacationSetDate;
            Z179VacationSetDays = A179VacationSetDays;
            Z189VacationSetDescription = A189VacationSetDescription;
         }
      }

      protected void standaloneNotModal0F27( )
      {
      }

      protected void standaloneModal0F27( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtVacationSetDate_Enabled = 0;
            AssignProp("", false, edtVacationSetDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacationSetDate_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         }
         else
         {
            edtVacationSetDate_Enabled = 1;
            AssignProp("", false, edtVacationSetDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacationSetDate_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         }
      }

      protected void Load0F27( )
      {
         /* Using cursor T000F26 */
         pr_default.execute(24, new Object[] {A106EmployeeId, A186VacationSetDate});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound27 = 1;
            A179VacationSetDays = T000F26_A179VacationSetDays[0];
            A189VacationSetDescription = T000F26_A189VacationSetDescription[0];
            n189VacationSetDescription = T000F26_n189VacationSetDescription[0];
            ZM0F27( -36) ;
         }
         pr_default.close(24);
         OnLoadActions0F27( ) ;
      }

      protected void OnLoadActions0F27( )
      {
      }

      protected void CheckExtendedTable0F27( )
      {
         nIsDirty_27 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0F27( ) ;
      }

      protected void CloseExtendedTableCursors0F27( )
      {
      }

      protected void enableDisable0F27( )
      {
      }

      protected void GetKey0F27( )
      {
         /* Using cursor T000F27 */
         pr_default.execute(25, new Object[] {A106EmployeeId, A186VacationSetDate});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(25);
      }

      protected void getByPrimaryKey0F27( )
      {
         /* Using cursor T000F6 */
         pr_default.execute(4, new Object[] {A106EmployeeId, A186VacationSetDate});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0F27( 36) ;
            RcdFound27 = 1;
            InitializeNonKey0F27( ) ;
            A186VacationSetDate = T000F6_A186VacationSetDate[0];
            A179VacationSetDays = T000F6_A179VacationSetDays[0];
            A189VacationSetDescription = T000F6_A189VacationSetDescription[0];
            n189VacationSetDescription = T000F6_n189VacationSetDescription[0];
            Z106EmployeeId = A106EmployeeId;
            Z186VacationSetDate = A186VacationSetDate;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0F27( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0F27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0F27( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0F27( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency0F27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F5 */
            pr_default.execute(3, new Object[] {A106EmployeeId, A186VacationSetDate});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmployeeVacationSet"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( Z179VacationSetDays != T000F5_A179VacationSetDays[0] ) || ( StringUtil.StrCmp(Z189VacationSetDescription, T000F5_A189VacationSetDescription[0]) != 0 ) )
            {
               if ( Z179VacationSetDays != T000F5_A179VacationSetDays[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"VacationSetDays");
                  GXUtil.WriteLogRaw("Old: ",Z179VacationSetDays);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A179VacationSetDays[0]);
               }
               if ( StringUtil.StrCmp(Z189VacationSetDescription, T000F5_A189VacationSetDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"VacationSetDescription");
                  GXUtil.WriteLogRaw("Old: ",Z189VacationSetDescription);
                  GXUtil.WriteLogRaw("Current: ",T000F5_A189VacationSetDescription[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EmployeeVacationSet"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F27( )
      {
         if ( ! IsAuthorized("employee_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F27( 0) ;
            CheckOptimisticConcurrency0F27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F28 */
                     pr_default.execute(26, new Object[] {A106EmployeeId, A186VacationSetDate, A179VacationSetDays, n189VacationSetDescription, A189VacationSetDescription});
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("EmployeeVacationSet");
                     if ( (pr_default.getStatus(26) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load0F27( ) ;
            }
            EndLevel0F27( ) ;
         }
         CloseExtendedTableCursors0F27( ) ;
      }

      protected void Update0F27( )
      {
         if ( ! IsAuthorized("employee_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F27( ) ;
         }
         if ( ( nIsMod_27 != 0 ) || ( nIsDirty_27 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0F27( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0F27( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0F27( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000F29 */
                        pr_default.execute(27, new Object[] {A179VacationSetDays, n189VacationSetDescription, A189VacationSetDescription, A106EmployeeId, A186VacationSetDate});
                        pr_default.close(27);
                        pr_default.SmartCacheProvider.SetUpdated("EmployeeVacationSet");
                        if ( (pr_default.getStatus(27) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmployeeVacationSet"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0F27( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0F27( ) ;
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
               EndLevel0F27( ) ;
            }
         }
         CloseExtendedTableCursors0F27( ) ;
      }

      protected void DeferredUpdate0F27( )
      {
      }

      protected void Delete0F27( )
      {
         if ( ! IsAuthorized("employee_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0F27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F27( ) ;
            AfterConfirm0F27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F30 */
                  pr_default.execute(28, new Object[] {A106EmployeeId, A186VacationSetDate});
                  pr_default.close(28);
                  pr_default.SmartCacheProvider.SetUpdated("EmployeeVacationSet");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F27( ) ;
         Gx_mode = sMode27;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F27( )
      {
         standaloneModal0F27( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F27( )
      {
         /* Scan By routine */
         /* Using cursor T000F31 */
         pr_default.execute(29, new Object[] {A106EmployeeId});
         RcdFound27 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound27 = 1;
            A186VacationSetDate = T000F31_A186VacationSetDate[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F27( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound27 = 1;
            A186VacationSetDate = T000F31_A186VacationSetDate[0];
         }
      }

      protected void ScanEnd0F27( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm0F27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F27( )
      {
         edtVacationSetDate_Enabled = 0;
         AssignProp("", false, edtVacationSetDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacationSetDate_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtVacationSetDays_Enabled = 0;
         AssignProp("", false, edtVacationSetDays_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacationSetDays_Enabled), 5, 0), !bGXsfl_76_Refreshing);
      }

      protected void send_integrity_lvl_hashes0F27( )
      {
      }

      protected void ZM0F17( short GX_JID )
      {
         if ( ( GX_JID == 37 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z184EmployeeIsActiveInProject = T000F3_A184EmployeeIsActiveInProject[0];
            }
            else
            {
               Z184EmployeeIsActiveInProject = A184EmployeeIsActiveInProject;
            }
         }
         if ( GX_JID == -37 )
         {
            Z106EmployeeId = A106EmployeeId;
            Z184EmployeeIsActiveInProject = A184EmployeeIsActiveInProject;
            Z102ProjectId = A102ProjectId;
            Z103ProjectName = A103ProjectName;
         }
      }

      protected void standaloneNotModal0F17( )
      {
      }

      protected void standaloneModal0F17( )
      {
         if ( IsIns( )  && (false==A184EmployeeIsActiveInProject) && ( Gx_BScreen == 0 ) )
         {
            A184EmployeeIsActiveInProject = true;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProjectId_Enabled = 0;
            AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         }
         else
         {
            edtProjectId_Enabled = 1;
            AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         }
      }

      protected void Load0F17( )
      {
         /* Using cursor T000F32 */
         pr_default.execute(30, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound17 = 1;
            A184EmployeeIsActiveInProject = T000F32_A184EmployeeIsActiveInProject[0];
            A103ProjectName = T000F32_A103ProjectName[0];
            ZM0F17( -37) ;
         }
         pr_default.close(30);
         OnLoadActions0F17( ) ;
      }

      protected void OnLoadActions0F17( )
      {
      }

      protected void CheckExtendedTable0F17( )
      {
         nIsDirty_17 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0F17( ) ;
         /* Using cursor T000F4 */
         pr_default.execute(2, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PROJECTID_" + sGXsfl_84_idx;
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A103ProjectName = T000F4_A103ProjectName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0F17( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0F17( )
      {
      }

      protected void gxLoad_38( long A102ProjectId )
      {
         /* Using cursor T000F33 */
         pr_default.execute(31, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GXCCtl = "PROJECTID_" + sGXsfl_84_idx;
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A103ProjectName = T000F33_A103ProjectName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A103ProjectName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(31) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(31);
      }

      protected void GetKey0F17( )
      {
         /* Using cursor T000F34 */
         pr_default.execute(32, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(32);
      }

      protected void getByPrimaryKey0F17( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F17( 37) ;
            RcdFound17 = 1;
            InitializeNonKey0F17( ) ;
            A184EmployeeIsActiveInProject = T000F3_A184EmployeeIsActiveInProject[0];
            A102ProjectId = T000F3_A102ProjectId[0];
            Z106EmployeeId = A106EmployeeId;
            Z102ProjectId = A102ProjectId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0F17( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0F17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0F17( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0F17( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0F17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmployeeProject"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z184EmployeeIsActiveInProject != T000F2_A184EmployeeIsActiveInProject[0] ) )
            {
               if ( Z184EmployeeIsActiveInProject != T000F2_A184EmployeeIsActiveInProject[0] )
               {
                  GXUtil.WriteLog("employee:[seudo value changed for attri]"+"EmployeeIsActiveInProject");
                  GXUtil.WriteLogRaw("Old: ",Z184EmployeeIsActiveInProject);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A184EmployeeIsActiveInProject[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EmployeeProject"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F17( )
      {
         if ( ! IsAuthorized("employee_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F17( 0) ;
            CheckOptimisticConcurrency0F17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F35 */
                     pr_default.execute(33, new Object[] {A106EmployeeId, A184EmployeeIsActiveInProject, A102ProjectId});
                     pr_default.close(33);
                     pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
                     if ( (pr_default.getStatus(33) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load0F17( ) ;
            }
            EndLevel0F17( ) ;
         }
         CloseExtendedTableCursors0F17( ) ;
      }

      protected void Update0F17( )
      {
         if ( ! IsAuthorized("employee_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F17( ) ;
         }
         if ( ( nIsMod_17 != 0 ) || ( nIsDirty_17 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0F17( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0F17( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0F17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000F36 */
                        pr_default.execute(34, new Object[] {A184EmployeeIsActiveInProject, A106EmployeeId, A102ProjectId});
                        pr_default.close(34);
                        pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
                        if ( (pr_default.getStatus(34) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmployeeProject"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0F17( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0F17( ) ;
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
               EndLevel0F17( ) ;
            }
         }
         CloseExtendedTableCursors0F17( ) ;
      }

      protected void DeferredUpdate0F17( )
      {
      }

      protected void Delete0F17( )
      {
         if ( ! IsAuthorized("employee_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0F17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F17( ) ;
            AfterConfirm0F17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F37 */
                  pr_default.execute(35, new Object[] {A106EmployeeId, A102ProjectId});
                  pr_default.close(35);
                  pr_default.SmartCacheProvider.SetUpdated("EmployeeProject");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F17( )
      {
         standaloneModal0F17( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000F38 */
            pr_default.execute(36, new Object[] {A102ProjectId});
            A103ProjectName = T000F38_A103ProjectName[0];
            pr_default.close(36);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000F39 */
            pr_default.execute(37, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Project"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T000F40 */
            pr_default.execute(38, new Object[] {A106EmployeeId, A102ProjectId});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
         }
      }

      protected void EndLevel0F17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F17( )
      {
         /* Scan By routine */
         /* Using cursor T000F41 */
         pr_default.execute(39, new Object[] {A106EmployeeId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound17 = 1;
            A102ProjectId = T000F41_A102ProjectId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F17( )
      {
         /* Scan next routine */
         pr_default.readNext(39);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound17 = 1;
            A102ProjectId = T000F41_A102ProjectId[0];
         }
      }

      protected void ScanEnd0F17( )
      {
         pr_default.close(39);
      }

      protected void AfterConfirm0F17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F17( )
      {
         edtProjectId_Enabled = 0;
         AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         chkEmployeeIsActiveInProject.Enabled = 0;
         AssignProp("", false, chkEmployeeIsActiveInProject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEmployeeIsActiveInProject.Enabled), 5, 0), !bGXsfl_84_Refreshing);
      }

      protected void send_integrity_lvl_hashes0F17( )
      {
      }

      protected void send_integrity_lvl_hashes0F16( )
      {
      }

      protected void SubsflControlProps_7627( )
      {
         edtVacationSetDate_Internalname = "VACATIONSETDATE_"+sGXsfl_76_idx;
         edtVacationSetDays_Internalname = "VACATIONSETDAYS_"+sGXsfl_76_idx;
      }

      protected void SubsflControlProps_fel_7627( )
      {
         edtVacationSetDate_Internalname = "VACATIONSETDATE_"+sGXsfl_76_fel_idx;
         edtVacationSetDays_Internalname = "VACATIONSETDAYS_"+sGXsfl_76_fel_idx;
      }

      protected void AddRow0F27( )
      {
         nGXsfl_76_idx = (int)(nGXsfl_76_idx+1);
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_7627( ) ;
         SendRow0F27( ) ;
      }

      protected void SendRow0F27( )
      {
         Gridlevel_vacationsetRow = GXWebRow.GetNew(context);
         if ( subGridlevel_vacationset_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_vacationset_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_vacationset_Class, "") != 0 )
            {
               subGridlevel_vacationset_Linesclass = subGridlevel_vacationset_Class+"Odd";
            }
         }
         else if ( subGridlevel_vacationset_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_vacationset_Backstyle = 0;
            subGridlevel_vacationset_Backcolor = subGridlevel_vacationset_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_vacationset_Class, "") != 0 )
            {
               subGridlevel_vacationset_Linesclass = subGridlevel_vacationset_Class+"Uniform";
            }
         }
         else if ( subGridlevel_vacationset_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_vacationset_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_vacationset_Class, "") != 0 )
            {
               subGridlevel_vacationset_Linesclass = subGridlevel_vacationset_Class+"Odd";
            }
            subGridlevel_vacationset_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_vacationset_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_vacationset_Backstyle = 1;
            if ( ((int)((nGXsfl_76_idx) % (2))) == 0 )
            {
               subGridlevel_vacationset_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_vacationset_Class, "") != 0 )
               {
                  subGridlevel_vacationset_Linesclass = subGridlevel_vacationset_Class+"Even";
               }
            }
            else
            {
               subGridlevel_vacationset_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_vacationset_Class, "") != 0 )
               {
                  subGridlevel_vacationset_Linesclass = subGridlevel_vacationset_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_76_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_76_idx + "',76)\"";
         ROClassString = "AttributeDate";
         Gridlevel_vacationsetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVacationSetDate_Internalname,context.localUtil.Format(A186VacationSetDate, "99/99/99"),context.localUtil.Format( A186VacationSetDate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,77);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVacationSetDate_Jsonclick,(short)0,(string)"AttributeDate",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtVacationSetDate_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_76_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_76_idx + "',76)\"";
         ROClassString = "Attribute";
         Gridlevel_vacationsetRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVacationSetDays_Internalname,StringUtil.LTrim( StringUtil.NToC( A179VacationSetDays, 4, 1, ".", "")),StringUtil.LTrim( ((edtVacationSetDays_Enabled!=0) ? context.localUtil.Format( A179VacationSetDays, "Z9.9") : context.localUtil.Format( A179VacationSetDays, "Z9.9"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','1');"+";gx.evt.onblur(this,78);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVacationSetDays_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtVacationSetDays_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridlevel_vacationsetRow);
         send_integrity_lvl_hashes0F27( ) ;
         GXCCtl = "Z186VacationSetDate_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z186VacationSetDate, 0, "/"));
         GXCCtl = "Z179VacationSetDays_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z179VacationSetDays, 4, 1, ".", "")));
         GXCCtl = "Z189VacationSetDescription_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z189VacationSetDescription);
         GXCCtl = "nRcdDeleted_27_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_27), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_27_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_27), 4, 0, ".", "")));
         GXCCtl = "nIsMod_27_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_27), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_76_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vEMPLOYEEID_" + sGXsfl_76_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "VACATIONSETDATE_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacationSetDate_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "VACATIONSETDAYS_"+sGXsfl_76_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacationSetDays_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_vacationsetContainer.AddRow(Gridlevel_vacationsetRow);
      }

      protected void ReadRow0F27( )
      {
         nGXsfl_76_idx = (int)(nGXsfl_76_idx+1);
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_7627( ) ;
         edtVacationSetDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "VACATIONSETDATE_"+sGXsfl_76_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtVacationSetDays_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "VACATIONSETDAYS_"+sGXsfl_76_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         if ( context.localUtil.VCDate( cgiGet( edtVacationSetDate_Internalname), 2) == 0 )
         {
            GXCCtl = "VACATIONSETDATE_" + sGXsfl_76_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Vacation Set Date"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtVacationSetDate_Internalname;
            wbErr = true;
            A186VacationSetDate = DateTime.MinValue;
         }
         else
         {
            A186VacationSetDate = context.localUtil.CToD( cgiGet( edtVacationSetDate_Internalname), 2);
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtVacationSetDays_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVacationSetDays_Internalname), ".", ",") > 99.9m ) ) )
         {
            GXCCtl = "VACATIONSETDAYS_" + sGXsfl_76_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtVacationSetDays_Internalname;
            wbErr = true;
            A179VacationSetDays = 0;
         }
         else
         {
            A179VacationSetDays = context.localUtil.CToN( cgiGet( edtVacationSetDays_Internalname), ".", ",");
         }
         GXCCtl = "Z186VacationSetDate_" + sGXsfl_76_idx;
         Z186VacationSetDate = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         GXCCtl = "Z179VacationSetDays_" + sGXsfl_76_idx;
         Z179VacationSetDays = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z189VacationSetDescription_" + sGXsfl_76_idx;
         Z189VacationSetDescription = cgiGet( GXCCtl);
         n189VacationSetDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A189VacationSetDescription)) ? true : false);
         GXCCtl = "Z189VacationSetDescription_" + sGXsfl_76_idx;
         A189VacationSetDescription = cgiGet( GXCCtl);
         n189VacationSetDescription = false;
         n189VacationSetDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A189VacationSetDescription)) ? true : false);
         GXCCtl = "nRcdDeleted_27_" + sGXsfl_76_idx;
         nRcdDeleted_27 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_27_" + sGXsfl_76_idx;
         nRcdExists_27 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_27_" + sGXsfl_76_idx;
         nIsMod_27 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_8417( )
      {
         edtProjectId_Internalname = "PROJECTID_"+sGXsfl_84_idx;
         chkEmployeeIsActiveInProject_Internalname = "EMPLOYEEISACTIVEINPROJECT_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_8417( )
      {
         edtProjectId_Internalname = "PROJECTID_"+sGXsfl_84_fel_idx;
         chkEmployeeIsActiveInProject_Internalname = "EMPLOYEEISACTIVEINPROJECT_"+sGXsfl_84_fel_idx;
      }

      protected void AddRow0F17( )
      {
         nGXsfl_84_idx = (int)(nGXsfl_84_idx+1);
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_8417( ) ;
         SendRow0F17( ) ;
      }

      protected void SendRow0F17( )
      {
         Gridlevel_projectRow = GXWebRow.GetNew(context);
         if ( subGridlevel_project_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_project_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
            {
               subGridlevel_project_Linesclass = subGridlevel_project_Class+"Odd";
            }
         }
         else if ( subGridlevel_project_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_project_Backstyle = 0;
            subGridlevel_project_Backcolor = subGridlevel_project_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
            {
               subGridlevel_project_Linesclass = subGridlevel_project_Class+"Uniform";
            }
         }
         else if ( subGridlevel_project_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_project_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
            {
               subGridlevel_project_Linesclass = subGridlevel_project_Class+"Odd";
            }
            subGridlevel_project_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_project_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_project_Backstyle = 1;
            if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
            {
               subGridlevel_project_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
               {
                  subGridlevel_project_Linesclass = subGridlevel_project_Class+"Even";
               }
            }
            else
            {
               subGridlevel_project_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_project_Class, "") != 0 )
               {
                  subGridlevel_project_Linesclass = subGridlevel_project_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_17_" + sGXsfl_84_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_84_idx + "',84)\"";
         ROClassString = "Attribute";
         Gridlevel_projectRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProjectId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,85);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProjectId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProjectId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)edtProjectId_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_17_" + sGXsfl_84_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_84_idx + "',84)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GXCCtl = "EMPLOYEEISACTIVEINPROJECT_" + sGXsfl_84_idx;
         chkEmployeeIsActiveInProject.Name = GXCCtl;
         chkEmployeeIsActiveInProject.WebTags = "";
         chkEmployeeIsActiveInProject.Caption = "";
         AssignProp("", false, chkEmployeeIsActiveInProject_Internalname, "TitleCaption", chkEmployeeIsActiveInProject.Caption, !bGXsfl_84_Refreshing);
         chkEmployeeIsActiveInProject.CheckedValue = "false";
         if ( IsIns( ) && (false==A184EmployeeIsActiveInProject) )
         {
            A184EmployeeIsActiveInProject = true;
         }
         Gridlevel_projectRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkEmployeeIsActiveInProject_Internalname,StringUtil.BoolToStr( A184EmployeeIsActiveInProject),(string)"",(string)"",(short)-1,chkEmployeeIsActiveInProject.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(86, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,86);\""});
         ajax_sending_grid_row(Gridlevel_projectRow);
         send_integrity_lvl_hashes0F17( ) ;
         GXCCtl = "Z102ProjectId_" + sGXsfl_84_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102ProjectId), 10, 0, ".", "")));
         GXCCtl = "Z184EmployeeIsActiveInProject_" + sGXsfl_84_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z184EmployeeIsActiveInProject);
         GXCCtl = "nRcdDeleted_17_" + sGXsfl_84_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_17), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_17_" + sGXsfl_84_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_17), 4, 0, ".", "")));
         GXCCtl = "nIsMod_17_" + sGXsfl_84_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_17), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_84_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_84_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vEMPLOYEEID_" + sGXsfl_84_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROJECTID_"+sGXsfl_84_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProjectId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROJECTID_"+sGXsfl_84_idx+"Horizontalalignment", StringUtil.RTrim( edtProjectId_Horizontalalignment));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEISACTIVEINPROJECT_"+sGXsfl_84_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEmployeeIsActiveInProject.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_projectContainer.AddRow(Gridlevel_projectRow);
      }

      protected void ReadRow0F17( )
      {
         nGXsfl_84_idx = (int)(nGXsfl_84_idx+1);
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_8417( ) ;
         edtProjectId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROJECTID_"+sGXsfl_84_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProjectId_Horizontalalignment = cgiGet( "PROJECTID_"+sGXsfl_84_idx+"Horizontalalignment");
         chkEmployeeIsActiveInProject.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "EMPLOYEEISACTIVEINPROJECT_"+sGXsfl_84_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
         {
            GXCCtl = "PROJECTID_" + sGXsfl_84_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
            wbErr = true;
            A102ProjectId = 0;
         }
         else
         {
            A102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         A184EmployeeIsActiveInProject = StringUtil.StrToBool( cgiGet( chkEmployeeIsActiveInProject_Internalname));
         GXCCtl = "Z102ProjectId_" + sGXsfl_84_idx;
         Z102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z184EmployeeIsActiveInProject_" + sGXsfl_84_idx;
         Z184EmployeeIsActiveInProject = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "nRcdDeleted_17_" + sGXsfl_84_idx;
         nRcdDeleted_17 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_17_" + sGXsfl_84_idx;
         nRcdExists_17 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_17_" + sGXsfl_84_idx;
         nIsMod_17 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProjectId_Enabled = edtProjectId_Enabled;
         defedtVacationSetDate_Enabled = edtVacationSetDate_Enabled;
      }

      protected void ConfirmValues0F0( )
      {
         nGXsfl_76_idx = 0;
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_7627( ) ;
         while ( nGXsfl_76_idx < nRC_GXsfl_76 )
         {
            nGXsfl_76_idx = (int)(nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_7627( ) ;
            ChangePostValue( "Z186VacationSetDate_"+sGXsfl_76_idx, cgiGet( "ZT_"+"Z186VacationSetDate_"+sGXsfl_76_idx)) ;
            DeletePostValue( "ZT_"+"Z186VacationSetDate_"+sGXsfl_76_idx) ;
            ChangePostValue( "Z179VacationSetDays_"+sGXsfl_76_idx, cgiGet( "ZT_"+"Z179VacationSetDays_"+sGXsfl_76_idx)) ;
            DeletePostValue( "ZT_"+"Z179VacationSetDays_"+sGXsfl_76_idx) ;
            ChangePostValue( "Z189VacationSetDescription_"+sGXsfl_76_idx, cgiGet( "ZT_"+"Z189VacationSetDescription_"+sGXsfl_76_idx)) ;
            DeletePostValue( "ZT_"+"Z189VacationSetDescription_"+sGXsfl_76_idx) ;
         }
         nGXsfl_84_idx = 0;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_8417( ) ;
         while ( nGXsfl_84_idx < nRC_GXsfl_84 )
         {
            nGXsfl_84_idx = (int)(nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_8417( ) ;
            ChangePostValue( "Z102ProjectId_"+sGXsfl_84_idx, cgiGet( "ZT_"+"Z102ProjectId_"+sGXsfl_84_idx)) ;
            DeletePostValue( "ZT_"+"Z102ProjectId_"+sGXsfl_84_idx) ;
            ChangePostValue( "Z184EmployeeIsActiveInProject_"+sGXsfl_84_idx, cgiGet( "ZT_"+"Z184EmployeeIsActiveInProject_"+sGXsfl_84_idx)) ;
            DeletePostValue( "ZT_"+"Z184EmployeeIsActiveInProject_"+sGXsfl_84_idx) ;
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("employee.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmployeeId,10,0))}, new string[] {"Gx_mode","EmployeeId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Employee");
         forbiddenHiddens.Add("EmployeeId", context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("EmployeeAPIPassword", StringUtil.RTrim( context.localUtil.Format( A187EmployeeAPIPassword, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("employee:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z147EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( Z147EmployeeBalance, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z148EmployeeName", StringUtil.RTrim( Z148EmployeeName));
         GxWebStd.gx_hidden_field( context, "Z111GAMUserGUID", Z111GAMUserGUID);
         GxWebStd.gx_hidden_field( context, "Z107EmployeeFirstName", StringUtil.RTrim( Z107EmployeeFirstName));
         GxWebStd.gx_hidden_field( context, "Z108EmployeeLastName", StringUtil.RTrim( Z108EmployeeLastName));
         GxWebStd.gx_hidden_field( context, "Z109EmployeeEmail", Z109EmployeeEmail);
         GxWebStd.gx_boolean_hidden_field( context, "Z110EmployeeIsManager", Z110EmployeeIsManager);
         GxWebStd.gx_boolean_hidden_field( context, "Z112EmployeeIsActive", Z112EmployeeIsActive);
         GxWebStd.gx_hidden_field( context, "Z146EmployeeVactionDays", StringUtil.LTrim( StringUtil.NToC( Z146EmployeeVactionDays, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z177EmployeeVacationDaysSetDate", context.localUtil.DToC( Z177EmployeeVacationDaysSetDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z187EmployeeAPIPassword", Z187EmployeeAPIPassword);
         GxWebStd.gx_hidden_field( context, "Z188EmployeeFTEHours", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z188EmployeeFTEHours), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z100CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_76", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_76_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_84_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N100CompanyId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID_DATA", AV15ProjectId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID_DATA", AV15ProjectId_Data);
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
         GxWebStd.gx_hidden_field( context, "vEMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPLOYEEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmployeeId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_COMPANYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_CompanyId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPASSWORD", StringUtil.RTrim( AV24Password));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEAPIPASSWORD", A187EmployeeAPIPassword);
         GxWebStd.gx_hidden_field( context, "COMPANYNAME", StringUtil.RTrim( A101CompanyName));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV33Pgmname));
         GxWebStd.gx_hidden_field( context, "VACATIONSETDESCRIPTION", A189VacationSetDescription);
         GxWebStd.gx_hidden_field( context, "PROJECTNAME", StringUtil.RTrim( A103ProjectName));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Objectcall", StringUtil.RTrim( Combo_projectid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Cls", StringUtil.RTrim( Combo_projectid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Enabled", StringUtil.BoolToStr( Combo_projectid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_projectid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Isgriditem", StringUtil.BoolToStr( Combo_projectid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Emptyitem", StringUtil.BoolToStr( Combo_projectid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "SETVACATIONDAYSBTN_MODAL_Objectcall", StringUtil.RTrim( Setvacationdaysbtn_modal_Objectcall));
         GxWebStd.gx_hidden_field( context, "SETVACATIONDAYSBTN_MODAL_Enabled", StringUtil.BoolToStr( Setvacationdaysbtn_modal_Enabled));
         GxWebStd.gx_hidden_field( context, "SETVACATIONDAYSBTN_MODAL_Width", StringUtil.RTrim( Setvacationdaysbtn_modal_Width));
         GxWebStd.gx_hidden_field( context, "SETVACATIONDAYSBTN_MODAL_Title", StringUtil.RTrim( Setvacationdaysbtn_modal_Title));
         GxWebStd.gx_hidden_field( context, "SETVACATIONDAYSBTN_MODAL_Confirmtype", StringUtil.RTrim( Setvacationdaysbtn_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "SETVACATIONDAYSBTN_MODAL_Bodytype", StringUtil.RTrim( Setvacationdaysbtn_modal_Bodytype));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
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
         return formatLink("employee.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmployeeId,10,0))}, new string[] {"Gx_mode","EmployeeId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Employee" ;
      }

      public override string GetPgmdesc( )
      {
         return "Employees" ;
      }

      protected void InitializeNonKey0F16( )
      {
         A100CompanyId = 0;
         AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         A148EmployeeName = "";
         AssignAttri("", false, "A148EmployeeName", A148EmployeeName);
         A111GAMUserGUID = "";
         AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
         AV24Password = "";
         AssignAttri("", false, "AV24Password", AV24Password);
         A147EmployeeBalance = 0;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
         AV30EmployeeBalance = 0;
         AssignAttri("", false, "AV30EmployeeBalance", StringUtil.LTrimStr( AV30EmployeeBalance, 4, 1));
         A107EmployeeFirstName = "";
         AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
         A108EmployeeLastName = "";
         AssignAttri("", false, "A108EmployeeLastName", A108EmployeeLastName);
         A109EmployeeEmail = "";
         AssignAttri("", false, "A109EmployeeEmail", A109EmployeeEmail);
         A101CompanyName = "";
         AssignAttri("", false, "A101CompanyName", A101CompanyName);
         A110EmployeeIsManager = false;
         AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
         A177EmployeeVacationDaysSetDate = DateTime.MinValue;
         AssignAttri("", false, "A177EmployeeVacationDaysSetDate", context.localUtil.Format(A177EmployeeVacationDaysSetDate, "99/99/99"));
         A187EmployeeAPIPassword = "";
         AssignAttri("", false, "A187EmployeeAPIPassword", A187EmployeeAPIPassword);
         A112EmployeeIsActive = false;
         AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
         A146EmployeeVactionDays = (decimal)(21);
         AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( A146EmployeeVactionDays, 4, 1));
         A188EmployeeFTEHours = 40;
         AssignAttri("", false, "A188EmployeeFTEHours", StringUtil.LTrimStr( (decimal)(A188EmployeeFTEHours), 4, 0));
         Z147EmployeeBalance = 0;
         Z148EmployeeName = "";
         Z111GAMUserGUID = "";
         Z107EmployeeFirstName = "";
         Z108EmployeeLastName = "";
         Z109EmployeeEmail = "";
         Z110EmployeeIsManager = false;
         Z112EmployeeIsActive = false;
         Z146EmployeeVactionDays = 0;
         Z177EmployeeVacationDaysSetDate = DateTime.MinValue;
         Z187EmployeeAPIPassword = "";
         Z188EmployeeFTEHours = 0;
         Z100CompanyId = 0;
      }

      protected void InitAll0F16( )
      {
         A106EmployeeId = 0;
         AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         InitializeNonKey0F16( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A112EmployeeIsActive = i112EmployeeIsActive;
         AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
         A146EmployeeVactionDays = i146EmployeeVactionDays;
         AssignAttri("", false, "A146EmployeeVactionDays", StringUtil.LTrimStr( A146EmployeeVactionDays, 4, 1));
         A188EmployeeFTEHours = i188EmployeeFTEHours;
         AssignAttri("", false, "A188EmployeeFTEHours", StringUtil.LTrimStr( (decimal)(A188EmployeeFTEHours), 4, 0));
      }

      protected void InitializeNonKey0F27( )
      {
         A179VacationSetDays = 0;
         A189VacationSetDescription = "";
         n189VacationSetDescription = false;
         AssignAttri("", false, "A189VacationSetDescription", A189VacationSetDescription);
         Z179VacationSetDays = 0;
         Z189VacationSetDescription = "";
      }

      protected void InitAll0F27( )
      {
         A186VacationSetDate = DateTime.MinValue;
         InitializeNonKey0F27( ) ;
      }

      protected void StandaloneModalInsert0F27( )
      {
      }

      protected void InitializeNonKey0F17( )
      {
         A103ProjectName = "";
         AssignAttri("", false, "A103ProjectName", A103ProjectName);
         A184EmployeeIsActiveInProject = true;
         Z184EmployeeIsActiveInProject = false;
      }

      protected void InitAll0F17( )
      {
         A102ProjectId = 0;
         InitializeNonKey0F17( ) ;
      }

      protected void StandaloneModalInsert0F17( )
      {
         A184EmployeeIsActiveInProject = i184EmployeeIsActiveInProject;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256277372029", true, true);
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
         context.AddJavascriptSource("employee.js", "?20256277372032", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties27( )
      {
         edtVacationSetDate_Enabled = defedtVacationSetDate_Enabled;
         AssignProp("", false, edtVacationSetDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVacationSetDate_Enabled), 5, 0), !bGXsfl_76_Refreshing);
      }

      protected void init_level_properties17( )
      {
         edtProjectId_Enabled = defedtProjectId_Enabled;
         AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
      }

      protected void StartGridControl76( )
      {
         Gridlevel_vacationsetContainer.AddObjectProperty("GridName", "Gridlevel_vacationset");
         Gridlevel_vacationsetContainer.AddObjectProperty("Header", subGridlevel_vacationset_Header);
         Gridlevel_vacationsetContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_vacationsetContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_vacationset_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_vacationsetContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_vacationsetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_vacationsetColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A186VacationSetDate, "99/99/99")));
         Gridlevel_vacationsetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacationSetDate_Enabled), 5, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddColumnProperties(Gridlevel_vacationsetColumn);
         Gridlevel_vacationsetColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_vacationsetColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A179VacationSetDays, 4, 1, ".", ""))));
         Gridlevel_vacationsetColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVacationSetDays_Enabled), 5, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddColumnProperties(Gridlevel_vacationsetColumn);
         Gridlevel_vacationsetContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_vacationset_Selectedindex), 4, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_vacationset_Allowselection), 1, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_vacationset_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_vacationset_Allowhovering), 1, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_vacationset_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_vacationset_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_vacationsetContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_vacationset_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl84( )
      {
         Gridlevel_projectContainer.AddObjectProperty("GridName", "Gridlevel_project");
         Gridlevel_projectContainer.AddObjectProperty("Header", subGridlevel_project_Header);
         Gridlevel_projectContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_projectContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_projectContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_projectColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_projectColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", ""))));
         Gridlevel_projectColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProjectId_Enabled), 5, 0, ".", "")));
         Gridlevel_projectColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtProjectId_Horizontalalignment));
         Gridlevel_projectContainer.AddColumnProperties(Gridlevel_projectColumn);
         Gridlevel_projectColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_projectColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A184EmployeeIsActiveInProject)));
         Gridlevel_projectColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkEmployeeIsActiveInProject.Enabled), 5, 0, ".", "")));
         Gridlevel_projectContainer.AddColumnProperties(Gridlevel_projectColumn);
         Gridlevel_projectContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Selectedindex), 4, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Allowselection), 1, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Allowhovering), 1, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_projectContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_project_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME";
         edtEmployeeLastName_Internalname = "EMPLOYEELASTNAME";
         edtEmployeeEmail_Internalname = "EMPLOYEEEMAIL";
         dynCompanyId_Internalname = "COMPANYID";
         chkEmployeeIsActive_Internalname = "EMPLOYEEISACTIVE";
         chkEmployeeIsManager_Internalname = "EMPLOYEEISMANAGER";
         edtavEmployeebalance_Internalname = "vEMPLOYEEBALANCE";
         bttBtnsetvacationdaysbtn_Internalname = "BTNSETVACATIONDAYSBTN";
         divAddvacationdayscell_Internalname = "ADDVACATIONDAYSCELL";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         edtEmployeeFTEHours_Internalname = "EMPLOYEEFTEHOURS";
         edtavEmployeeapipassword_Internalname = "vEMPLOYEEAPIPASSWORD";
         bttBtnuseraction1_Internalname = "BTNUSERACTION1";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtVacationSetDate_Internalname = "VACATIONSETDATE";
         edtVacationSetDays_Internalname = "VACATIONSETDAYS";
         divTableleaflevel_vacationset_Internalname = "TABLELEAFLEVEL_VACATIONSET";
         edtProjectId_Internalname = "PROJECTID";
         chkEmployeeIsActiveInProject_Internalname = "EMPLOYEEISACTIVEINPROJECT";
         divTableleaflevel_project_Internalname = "TABLELEAFLEVEL_PROJECT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         Combo_projectid_Internalname = "COMBO_PROJECTID";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtEmployeeVactionDays_Internalname = "EMPLOYEEVACTIONDAYS";
         edtEmployeeName_Internalname = "EMPLOYEENAME";
         edtGAMUserGUID_Internalname = "GAMUSERGUID";
         edtEmployeeBalance_Internalname = "EMPLOYEEBALANCE";
         edtEmployeeVacationDaysSetDate_Internalname = "EMPLOYEEVACATIONDAYSSETDATE";
         Setvacationdaysbtn_modal_Internalname = "SETVACATIONDAYSBTN_MODAL";
         tblTablesetvacationdaysbtn_modal_Internalname = "TABLESETVACATIONDAYSBTN_MODAL";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_vacationset_Internalname = "GRIDLEVEL_VACATIONSET";
         subGridlevel_project_Internalname = "GRIDLEVEL_PROJECT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_project_Allowcollapsing = 0;
         subGridlevel_project_Allowselection = 0;
         subGridlevel_project_Header = "";
         subGridlevel_vacationset_Allowcollapsing = 0;
         subGridlevel_vacationset_Allowselection = 0;
         subGridlevel_vacationset_Header = "";
         Combo_projectid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Employees";
         chkEmployeeIsActiveInProject.Caption = "";
         edtProjectId_Jsonclick = "";
         subGridlevel_project_Class = "WorkWith";
         subGridlevel_project_Backcolorstyle = 0;
         edtVacationSetDays_Jsonclick = "";
         edtVacationSetDate_Jsonclick = "";
         subGridlevel_vacationset_Class = "WorkWith";
         subGridlevel_vacationset_Backcolorstyle = 0;
         Combo_projectid_Titlecontrolidtoreplace = "";
         chkEmployeeIsActiveInProject.Enabled = 1;
         edtProjectId_Enabled = 1;
         edtVacationSetDays_Enabled = 1;
         edtVacationSetDate_Enabled = 1;
         Setvacationdaysbtn_modal_Bodytype = "WebComponent";
         Setvacationdaysbtn_modal_Confirmtype = "";
         Setvacationdaysbtn_modal_Title = "Set Employee Vacation Days";
         Setvacationdaysbtn_modal_Width = "600";
         edtEmployeeVacationDaysSetDate_Jsonclick = "";
         edtEmployeeVacationDaysSetDate_Enabled = 1;
         edtEmployeeVacationDaysSetDate_Visible = 1;
         edtEmployeeBalance_Jsonclick = "";
         edtEmployeeBalance_Enabled = 0;
         edtEmployeeBalance_Visible = 1;
         edtGAMUserGUID_Jsonclick = "";
         edtGAMUserGUID_Enabled = 1;
         edtGAMUserGUID_Visible = 1;
         edtEmployeeName_Jsonclick = "";
         edtEmployeeName_Enabled = 1;
         edtEmployeeName_Visible = 1;
         edtEmployeeVactionDays_Jsonclick = "";
         edtEmployeeVactionDays_Enabled = 1;
         edtEmployeeVactionDays_Visible = 1;
         edtEmployeeId_Jsonclick = "";
         edtEmployeeId_Enabled = 0;
         edtEmployeeId_Visible = 1;
         Combo_projectid_Emptyitem = Convert.ToBoolean( 0);
         Combo_projectid_Isgriditem = Convert.ToBoolean( -1);
         Combo_projectid_Cls = "ExtendedCombo";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         bttBtnuseraction1_Visible = 1;
         edtavEmployeeapipassword_Jsonclick = "";
         edtavEmployeeapipassword_Enabled = 0;
         divUnnamedtable2_Visible = 1;
         edtEmployeeFTEHours_Jsonclick = "";
         edtEmployeeFTEHours_Enabled = 1;
         bttBtnsetvacationdaysbtn_Visible = 1;
         edtavEmployeebalance_Jsonclick = "";
         edtavEmployeebalance_Enabled = 0;
         chkEmployeeIsManager.Enabled = 1;
         chkEmployeeIsActive.Enabled = 1;
         dynCompanyId_Jsonclick = "";
         dynCompanyId.Enabled = 1;
         edtEmployeeEmail_Jsonclick = "";
         edtEmployeeEmail_Enabled = 1;
         edtEmployeeLastName_Jsonclick = "";
         edtEmployeeLastName_Enabled = 1;
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeFirstName_Enabled = 1;
         divLayoutmaintable_Class = "Table";
         edtProjectId_Horizontalalignment = "end";
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

      protected void GXDLACOMPANYID0F1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLACOMPANYID_data0F1( ) ;
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

      protected void GXACOMPANYID_html0F1( )
      {
         long gxdynajaxvalue;
         GXDLACOMPANYID_data0F1( ) ;
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
      }

      protected void GXDLACOMPANYID_data0F1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000F42 */
         pr_default.execute(40);
         while ( (pr_default.getStatus(40) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000F42_A100CompanyId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000F42_A101CompanyName[0]));
            pr_default.readNext(40);
         }
         pr_default.close(40);
      }

      protected void GX4ASAEMPLOYEEBALANCE0F16( long A106EmployeeId )
      {
         GXt_decimal3 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         A147EmployeeBalance = GXt_decimal3;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX7ASACOMPANYID0F16( long AV13Insert_CompanyId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            A100CompanyId = AV13Insert_CompanyId;
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         else
         {
            GXt_boolean5 = false;
            new userhasrole(context ).execute(  "Manager", out  GXt_boolean5) ;
            if ( GXt_boolean5 )
            {
               GXt_int6 = A100CompanyId;
               new getloggedinusercompanyid(context ).execute( out  GXt_int6) ;
               A100CompanyId = GXt_int6;
               AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A100CompanyId), 10, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GXASA1000F16( long AV13Insert_CompanyId )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_CompanyId) )
         {
            dynCompanyId.Enabled = 0;
            AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         }
         else
         {
            GXt_boolean5 = false;
            new userhasrole(context ).execute(  "Manager", out  GXt_boolean5) ;
            if ( GXt_boolean5 )
            {
               dynCompanyId.Enabled = 0;
               AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
            }
            else
            {
               dynCompanyId.Enabled = 1;
               AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
            }
         }
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

      protected void GX14ASAEMPLOYEEBALANCE0F16( long A106EmployeeId )
      {
         GXt_decimal3 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         A147EmployeeBalance = GXt_decimal3;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX15ASAEMPLOYEEBALANCE0F16( long A106EmployeeId )
      {
         GXt_decimal3 = AV30EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         AV30EmployeeBalance = GXt_decimal3;
         AssignAttri("", false, "AV30EmployeeBalance", StringUtil.LTrimStr( AV30EmployeeBalance, 4, 1));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( AV30EmployeeBalance, 4, 1, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GXASA1000F16( )
      {
         if ( new userhasrole(context).executeUdp(  "Manager") )
         {
            dynCompanyId.Enabled = 0;
            AssignProp("", false, dynCompanyId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynCompanyId.Enabled), 5, 0), true);
         }
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

      protected void XC_25_0F16( string A109EmployeeEmail ,
                                 string A107EmployeeFirstName ,
                                 string A108EmployeeLastName )
      {
         new createemployeeaccount(context ).execute(  A109EmployeeEmail,  A107EmployeeFirstName,  A108EmployeeLastName, out  A111GAMUserGUID, out  AV24Password) ;
         AssignAttri("", false, "A111GAMUserGUID", A111GAMUserGUID);
         AssignAttri("", false, "AV24Password", AV24Password);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A111GAMUserGUID)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( AV24Password))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_26_0F16( long A106EmployeeId )
      {
         new assignemployeerole(context ).execute(  A106EmployeeId) ;
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

      protected void XC_27_0F16( string A109EmployeeEmail )
      {
         new deleteemployeeaccount(context ).execute(  A109EmployeeEmail) ;
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

      protected void XC_28_0F16( long A106EmployeeId )
      {
         new employeestatuscheck(context ).execute(  A106EmployeeId) ;
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

      protected void gxnrGridlevel_vacationset_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_7627( ) ;
         while ( nGXsfl_76_idx <= nRC_GXsfl_76 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0F27( ) ;
            standaloneModal0F27( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0F27( ) ;
            nGXsfl_76_idx = (int)(nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_7627( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_vacationsetContainer)) ;
         /* End function gxnrGridlevel_vacationset_newrow */
      }

      protected void gxnrGridlevel_project_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8417( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0F17( ) ;
            standaloneModal0F17( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0F17( ) ;
            nGXsfl_84_idx = (int)(nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_8417( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_projectContainer)) ;
         /* End function gxnrGridlevel_project_newrow */
      }

      protected void init_web_controls( )
      {
         dynCompanyId.Name = "COMPANYID";
         dynCompanyId.WebTags = "";
         dynCompanyId.removeAllItems();
         /* Using cursor T000F43 */
         pr_default.execute(41);
         while ( (pr_default.getStatus(41) != 101) )
         {
            dynCompanyId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000F43_A100CompanyId[0]), 10, 0)), T000F43_A101CompanyName[0], 0);
            pr_default.readNext(41);
         }
         pr_default.close(41);
         if ( dynCompanyId.ItemCount > 0 )
         {
            A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A100CompanyId), 10, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A100CompanyId", StringUtil.LTrimStr( (decimal)(A100CompanyId), 10, 0));
         }
         chkEmployeeIsActive.Name = "EMPLOYEEISACTIVE";
         chkEmployeeIsActive.WebTags = "";
         chkEmployeeIsActive.Caption = "Is Active";
         AssignProp("", false, chkEmployeeIsActive_Internalname, "TitleCaption", chkEmployeeIsActive.Caption, true);
         chkEmployeeIsActive.CheckedValue = "false";
         if ( IsIns( ) && (false==A112EmployeeIsActive) )
         {
            A112EmployeeIsActive = false;
            AssignAttri("", false, "A112EmployeeIsActive", A112EmployeeIsActive);
         }
         chkEmployeeIsManager.Name = "EMPLOYEEISMANAGER";
         chkEmployeeIsManager.WebTags = "";
         chkEmployeeIsManager.Caption = "Is HR Manager";
         AssignProp("", false, chkEmployeeIsManager_Internalname, "TitleCaption", chkEmployeeIsManager.Caption, true);
         chkEmployeeIsManager.CheckedValue = "false";
         A110EmployeeIsManager = StringUtil.StrToBool( StringUtil.BoolToStr( A110EmployeeIsManager));
         AssignAttri("", false, "A110EmployeeIsManager", A110EmployeeIsManager);
         GXCCtl = "EMPLOYEEISACTIVEINPROJECT_" + sGXsfl_84_idx;
         chkEmployeeIsActiveInProject.Name = GXCCtl;
         chkEmployeeIsActiveInProject.WebTags = "";
         chkEmployeeIsActiveInProject.Caption = "";
         AssignProp("", false, chkEmployeeIsActiveInProject_Internalname, "TitleCaption", chkEmployeeIsActiveInProject.Caption, !bGXsfl_84_Refreshing);
         chkEmployeeIsActiveInProject.CheckedValue = "false";
         if ( IsIns( ) && (false==A184EmployeeIsActiveInProject) )
         {
            A184EmployeeIsActiveInProject = true;
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

      public void Valid_Employeeid( )
      {
         A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         GXt_decimal3 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         A147EmployeeBalance = GXt_decimal3;
         GXt_decimal3 = A147EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         A147EmployeeBalance = GXt_decimal3;
         GXt_decimal3 = AV30EmployeeBalance;
         new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
         AV30EmployeeBalance = GXt_decimal3;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")));
         AssignAttri("", false, "AV30EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( AV30EmployeeBalance, 4, 1, ".", "")));
      }

      public void Valid_Employeeemail( )
      {
         A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000F44 */
         pr_default.execute(42, new Object[] {A109EmployeeEmail, A106EmployeeId});
         if ( (pr_default.getStatus(42) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Employee Email"}), 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
         }
         pr_default.close(42);
         if ( ! ( GxRegex.IsMatch(A109EmployeeEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Employee Email does not match the specified pattern", "OutOfRange", 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Employee Email", "", "", "", "", "", "", "", ""), 1, "EMPLOYEEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtEmployeeEmail_Internalname;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109EmployeeEmail)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  "Work hours/minutes are required",  "error",  "#"+edtEmployeeEmail_Internalname,  "true",  ""), 0, "EMPLOYEEEMAIL");
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Companyid( )
      {
         A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000F20 */
         pr_default.execute(18, new Object[] {A100CompanyId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = dynCompanyId_Internalname;
         }
         A101CompanyName = T000F20_A101CompanyName[0];
         pr_default.close(18);
         if ( (0==A100CompanyId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 is required.", "Company Id", "", "", "", "", "", "", "", ""), 1, "COMPANYID");
            AnyError = 1;
            GX_FocusControl = dynCompanyId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A101CompanyName", StringUtil.RTrim( A101CompanyName));
      }

      public void Valid_Projectid( )
      {
         A100CompanyId = (long)(Math.Round(NumberUtil.Val( dynCompanyId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000F38 */
         pr_default.execute(36, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(36) == 101) )
         {
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
         }
         A103ProjectName = T000F38_A103ProjectName[0];
         pr_default.close(36);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A103ProjectName", StringUtil.RTrim( A103ProjectName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7EmployeeId","fld":"vEMPLOYEEID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A187EmployeeAPIPassword","fld":"EMPLOYEEAPIPASSWORD"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E160F2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E170F2","iparms":[{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("'DOUSERACTION1'",""","oparms":[{"av":"AV31EmployeeAPIPassword","fld":"vEMPLOYEEAPIPASSWORD"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("'DOSETVACATIONDAYSBTN'","""{"handler":"E110F16","iparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("'DOSETVACATIONDAYSBTN'",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("SETVACATIONDAYSBTN_MODAL.ONLOADCOMPONENT","""{"handler":"E150F2","iparms":[{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("SETVACATIONDAYSBTN_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED","""{"handler":"E130F2","iparms":[{"av":"Combo_projectid_Caption","ctrl":"COMBO_PROJECTID","prop":"Caption"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("COMBO_PROJECTID.ONOPTIONCLICKED",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("SETVACATIONDAYSBTN_MODAL.CLOSE","""{"handler":"E140F2","iparms":[{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("SETVACATIONDAYSBTN_MODAL.CLOSE",""","oparms":[{"av":"AV30EmployeeBalance","fld":"vEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("VALID_EMPLOYEEFIRSTNAME","""{"handler":"Valid_Employeefirstname","iparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("VALID_EMPLOYEEFIRSTNAME",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("VALID_EMPLOYEELASTNAME","""{"handler":"Valid_Employeelastname","iparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("VALID_EMPLOYEELASTNAME",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("VALID_EMPLOYEEEMAIL","""{"handler":"Valid_Employeeemail","iparms":[{"av":"A109EmployeeEmail","fld":"EMPLOYEEEMAIL"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("VALID_EMPLOYEEEMAIL",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("VALID_COMPANYID","""{"handler":"Valid_Companyid","iparms":[{"av":"A101CompanyName","fld":"COMPANYNAME"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("VALID_COMPANYID",""","oparms":[{"av":"A101CompanyName","fld":"COMPANYNAME"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A147EmployeeBalance","fld":"EMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV30EmployeeBalance","fld":"vEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("VALID_EMPLOYEEID",""","oparms":[{"av":"A147EmployeeBalance","fld":"EMPLOYEEBALANCE","pic":"Z9.9"},{"av":"AV30EmployeeBalance","fld":"vEMPLOYEEBALANCE","pic":"Z9.9"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("VALID_VACATIONSETDATE","""{"handler":"Valid_Vacationsetdate","iparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("VALID_VACATIONSETDATE",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Vacationsetdays","iparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("NULL",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("VALID_PROJECTID","""{"handler":"Valid_Projectid","iparms":[{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("VALID_PROJECTID",""","oparms":[{"av":"A103ProjectName","fld":"PROJECTNAME"},{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Employeeisactiveinproject","iparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]""");
         setEventMetadata("NULL",""","oparms":[{"av":"dynCompanyId"},{"av":"A100CompanyId","fld":"COMPANYID","pic":"ZZZZZZZZZ9"},{"av":"A112EmployeeIsActive","fld":"EMPLOYEEISACTIVE"},{"av":"A110EmployeeIsManager","fld":"EMPLOYEEISMANAGER"}]}""");
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
         pr_default.close(36);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z148EmployeeName = "";
         Z111GAMUserGUID = "";
         Z107EmployeeFirstName = "";
         Z108EmployeeLastName = "";
         Z109EmployeeEmail = "";
         Z177EmployeeVacationDaysSetDate = DateTime.MinValue;
         Z187EmployeeAPIPassword = "";
         Combo_projectid_Caption = "";
         Z186VacationSetDate = DateTime.MinValue;
         Z189VacationSetDescription = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A109EmployeeEmail = "";
         A107EmployeeFirstName = "";
         A108EmployeeLastName = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtnsetvacationdaysbtn_Jsonclick = "";
         AV31EmployeeAPIPassword = "";
         bttBtnuseraction1_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_projectid = new GXUserControl();
         AV15ProjectId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A148EmployeeName = "";
         A111GAMUserGUID = "";
         A177EmployeeVacationDaysSetDate = DateTime.MinValue;
         sStyleString = "";
         ucSetvacationdaysbtn_modal = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Gridlevel_vacationsetContainer = new GXWebGrid( context);
         sMode27 = "";
         Gridlevel_projectContainer = new GXWebGrid( context);
         sMode17 = "";
         A187EmployeeAPIPassword = "";
         AV24Password = "";
         A101CompanyName = "";
         AV33Pgmname = "";
         A189VacationSetDescription = "";
         A103ProjectName = "";
         Combo_projectid_Objectcall = "";
         Combo_projectid_Class = "";
         Combo_projectid_Icontype = "";
         Combo_projectid_Icon = "";
         Combo_projectid_Tooltip = "";
         Combo_projectid_Selectedvalue_set = "";
         Combo_projectid_Selectedvalue_get = "";
         Combo_projectid_Selectedtext_set = "";
         Combo_projectid_Selectedtext_get = "";
         Combo_projectid_Gamoauthtoken = "";
         Combo_projectid_Ddointernalname = "";
         Combo_projectid_Titlecontrolalign = "";
         Combo_projectid_Dropdownoptionstype = "";
         Combo_projectid_Datalisttype = "";
         Combo_projectid_Datalistfixedvalues = "";
         Combo_projectid_Datalistproc = "";
         Combo_projectid_Datalistprocparametersprefix = "";
         Combo_projectid_Remoteservicesparameters = "";
         Combo_projectid_Htmltemplate = "";
         Combo_projectid_Multiplevaluestype = "";
         Combo_projectid_Loadingdata = "";
         Combo_projectid_Noresultsfound = "";
         Combo_projectid_Emptyitemtext = "";
         Combo_projectid_Onlyselectedvalues = "";
         Combo_projectid_Selectalltext = "";
         Combo_projectid_Multiplevaluesseparator = "";
         Combo_projectid_Addnewoptiontext = "";
         Setvacationdaysbtn_modal_Objectcall = "";
         Setvacationdaysbtn_modal_Height = "";
         Setvacationdaysbtn_modal_Class = "";
         Setvacationdaysbtn_modal_Confirmationtext = "";
         Setvacationdaysbtn_modal_Yesbuttoncaption = "";
         Setvacationdaysbtn_modal_Nobuttoncaption = "";
         Setvacationdaysbtn_modal_Cancelbuttoncaption = "";
         Setvacationdaysbtn_modal_Yesbuttonposition = "";
         Setvacationdaysbtn_modal_Comment = "";
         Setvacationdaysbtn_modal_Bodycontentinternalname = "";
         Setvacationdaysbtn_modal_Result = "";
         Setvacationdaysbtn_modal_Texttype = "";
         Setvacationdaysbtn_modal_Focusedbutton = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode16 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A186VacationSetDate = DateTime.MinValue;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         GXt_char1 = "";
         GXt_objcol_SdtDVB_SDTComboData_Item2 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV17ComboSelectedValue = "";
         AV28Value = "";
         Z101CompanyName = "";
         T000F9_A101CompanyName = new string[] {""} ;
         T000F10_A147EmployeeBalance = new decimal[1] ;
         T000F10_A106EmployeeId = new long[1] ;
         T000F10_A148EmployeeName = new string[] {""} ;
         T000F10_A111GAMUserGUID = new string[] {""} ;
         T000F10_A107EmployeeFirstName = new string[] {""} ;
         T000F10_A108EmployeeLastName = new string[] {""} ;
         T000F10_A109EmployeeEmail = new string[] {""} ;
         T000F10_A101CompanyName = new string[] {""} ;
         T000F10_A110EmployeeIsManager = new bool[] {false} ;
         T000F10_A112EmployeeIsActive = new bool[] {false} ;
         T000F10_A146EmployeeVactionDays = new decimal[1] ;
         T000F10_A177EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         T000F10_A187EmployeeAPIPassword = new string[] {""} ;
         T000F10_A188EmployeeFTEHours = new short[1] ;
         T000F10_A100CompanyId = new long[1] ;
         T000F11_A109EmployeeEmail = new string[] {""} ;
         T000F12_A101CompanyName = new string[] {""} ;
         T000F13_A106EmployeeId = new long[1] ;
         T000F8_A147EmployeeBalance = new decimal[1] ;
         T000F8_A106EmployeeId = new long[1] ;
         T000F8_A148EmployeeName = new string[] {""} ;
         T000F8_A111GAMUserGUID = new string[] {""} ;
         T000F8_A107EmployeeFirstName = new string[] {""} ;
         T000F8_A108EmployeeLastName = new string[] {""} ;
         T000F8_A109EmployeeEmail = new string[] {""} ;
         T000F8_A110EmployeeIsManager = new bool[] {false} ;
         T000F8_A112EmployeeIsActive = new bool[] {false} ;
         T000F8_A146EmployeeVactionDays = new decimal[1] ;
         T000F8_A177EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         T000F8_A187EmployeeAPIPassword = new string[] {""} ;
         T000F8_A188EmployeeFTEHours = new short[1] ;
         T000F8_A100CompanyId = new long[1] ;
         T000F14_A106EmployeeId = new long[1] ;
         T000F15_A106EmployeeId = new long[1] ;
         T000F7_A147EmployeeBalance = new decimal[1] ;
         T000F7_A106EmployeeId = new long[1] ;
         T000F7_A148EmployeeName = new string[] {""} ;
         T000F7_A111GAMUserGUID = new string[] {""} ;
         T000F7_A107EmployeeFirstName = new string[] {""} ;
         T000F7_A108EmployeeLastName = new string[] {""} ;
         T000F7_A109EmployeeEmail = new string[] {""} ;
         T000F7_A110EmployeeIsManager = new bool[] {false} ;
         T000F7_A112EmployeeIsActive = new bool[] {false} ;
         T000F7_A146EmployeeVactionDays = new decimal[1] ;
         T000F7_A177EmployeeVacationDaysSetDate = new DateTime[] {DateTime.MinValue} ;
         T000F7_A187EmployeeAPIPassword = new string[] {""} ;
         T000F7_A188EmployeeFTEHours = new short[1] ;
         T000F7_A100CompanyId = new long[1] ;
         T000F17_A106EmployeeId = new long[1] ;
         T000F20_A101CompanyName = new string[] {""} ;
         T000F21_A102ProjectId = new long[1] ;
         T000F22_A174SupportRequestId = new long[1] ;
         T000F23_A127LeaveRequestId = new long[1] ;
         T000F24_A118WorkHourLogId = new long[1] ;
         T000F25_A106EmployeeId = new long[1] ;
         T000F26_A106EmployeeId = new long[1] ;
         T000F26_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         T000F26_A179VacationSetDays = new decimal[1] ;
         T000F26_A189VacationSetDescription = new string[] {""} ;
         T000F26_n189VacationSetDescription = new bool[] {false} ;
         T000F27_A106EmployeeId = new long[1] ;
         T000F27_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         T000F6_A106EmployeeId = new long[1] ;
         T000F6_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         T000F6_A179VacationSetDays = new decimal[1] ;
         T000F6_A189VacationSetDescription = new string[] {""} ;
         T000F6_n189VacationSetDescription = new bool[] {false} ;
         T000F5_A106EmployeeId = new long[1] ;
         T000F5_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         T000F5_A179VacationSetDays = new decimal[1] ;
         T000F5_A189VacationSetDescription = new string[] {""} ;
         T000F5_n189VacationSetDescription = new bool[] {false} ;
         T000F31_A106EmployeeId = new long[1] ;
         T000F31_A186VacationSetDate = new DateTime[] {DateTime.MinValue} ;
         Z103ProjectName = "";
         T000F32_A106EmployeeId = new long[1] ;
         T000F32_A184EmployeeIsActiveInProject = new bool[] {false} ;
         T000F32_A103ProjectName = new string[] {""} ;
         T000F32_A102ProjectId = new long[1] ;
         T000F4_A103ProjectName = new string[] {""} ;
         T000F33_A103ProjectName = new string[] {""} ;
         T000F34_A106EmployeeId = new long[1] ;
         T000F34_A102ProjectId = new long[1] ;
         T000F3_A106EmployeeId = new long[1] ;
         T000F3_A184EmployeeIsActiveInProject = new bool[] {false} ;
         T000F3_A102ProjectId = new long[1] ;
         T000F2_A106EmployeeId = new long[1] ;
         T000F2_A184EmployeeIsActiveInProject = new bool[] {false} ;
         T000F2_A102ProjectId = new long[1] ;
         T000F38_A103ProjectName = new string[] {""} ;
         T000F39_A102ProjectId = new long[1] ;
         T000F40_A118WorkHourLogId = new long[1] ;
         T000F41_A106EmployeeId = new long[1] ;
         T000F41_A102ProjectId = new long[1] ;
         Gridlevel_vacationsetRow = new GXWebRow();
         subGridlevel_vacationset_Linesclass = "";
         ROClassString = "";
         Gridlevel_projectRow = new GXWebRow();
         subGridlevel_project_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_vacationsetColumn = new GXWebColumn();
         Gridlevel_projectColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000F42_A100CompanyId = new long[1] ;
         T000F42_A101CompanyName = new string[] {""} ;
         T000F43_A100CompanyId = new long[1] ;
         T000F43_A101CompanyName = new string[] {""} ;
         T000F44_A109EmployeeEmail = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.employee__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employee__default(),
            new Object[][] {
                new Object[] {
               T000F2_A106EmployeeId, T000F2_A184EmployeeIsActiveInProject, T000F2_A102ProjectId
               }
               , new Object[] {
               T000F3_A106EmployeeId, T000F3_A184EmployeeIsActiveInProject, T000F3_A102ProjectId
               }
               , new Object[] {
               T000F4_A103ProjectName
               }
               , new Object[] {
               T000F5_A106EmployeeId, T000F5_A186VacationSetDate, T000F5_A179VacationSetDays, T000F5_A189VacationSetDescription, T000F5_n189VacationSetDescription
               }
               , new Object[] {
               T000F6_A106EmployeeId, T000F6_A186VacationSetDate, T000F6_A179VacationSetDays, T000F6_A189VacationSetDescription, T000F6_n189VacationSetDescription
               }
               , new Object[] {
               T000F7_A147EmployeeBalance, T000F7_A106EmployeeId, T000F7_A148EmployeeName, T000F7_A111GAMUserGUID, T000F7_A107EmployeeFirstName, T000F7_A108EmployeeLastName, T000F7_A109EmployeeEmail, T000F7_A110EmployeeIsManager, T000F7_A112EmployeeIsActive, T000F7_A146EmployeeVactionDays,
               T000F7_A177EmployeeVacationDaysSetDate, T000F7_A187EmployeeAPIPassword, T000F7_A188EmployeeFTEHours, T000F7_A100CompanyId
               }
               , new Object[] {
               T000F8_A147EmployeeBalance, T000F8_A106EmployeeId, T000F8_A148EmployeeName, T000F8_A111GAMUserGUID, T000F8_A107EmployeeFirstName, T000F8_A108EmployeeLastName, T000F8_A109EmployeeEmail, T000F8_A110EmployeeIsManager, T000F8_A112EmployeeIsActive, T000F8_A146EmployeeVactionDays,
               T000F8_A177EmployeeVacationDaysSetDate, T000F8_A187EmployeeAPIPassword, T000F8_A188EmployeeFTEHours, T000F8_A100CompanyId
               }
               , new Object[] {
               T000F9_A101CompanyName
               }
               , new Object[] {
               T000F10_A147EmployeeBalance, T000F10_A106EmployeeId, T000F10_A148EmployeeName, T000F10_A111GAMUserGUID, T000F10_A107EmployeeFirstName, T000F10_A108EmployeeLastName, T000F10_A109EmployeeEmail, T000F10_A101CompanyName, T000F10_A110EmployeeIsManager, T000F10_A112EmployeeIsActive,
               T000F10_A146EmployeeVactionDays, T000F10_A177EmployeeVacationDaysSetDate, T000F10_A187EmployeeAPIPassword, T000F10_A188EmployeeFTEHours, T000F10_A100CompanyId
               }
               , new Object[] {
               T000F11_A109EmployeeEmail
               }
               , new Object[] {
               T000F12_A101CompanyName
               }
               , new Object[] {
               T000F13_A106EmployeeId
               }
               , new Object[] {
               T000F14_A106EmployeeId
               }
               , new Object[] {
               T000F15_A106EmployeeId
               }
               , new Object[] {
               }
               , new Object[] {
               T000F17_A106EmployeeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F20_A101CompanyName
               }
               , new Object[] {
               T000F21_A102ProjectId
               }
               , new Object[] {
               T000F22_A174SupportRequestId
               }
               , new Object[] {
               T000F23_A127LeaveRequestId
               }
               , new Object[] {
               T000F24_A118WorkHourLogId
               }
               , new Object[] {
               T000F25_A106EmployeeId
               }
               , new Object[] {
               T000F26_A106EmployeeId, T000F26_A186VacationSetDate, T000F26_A179VacationSetDays, T000F26_A189VacationSetDescription, T000F26_n189VacationSetDescription
               }
               , new Object[] {
               T000F27_A106EmployeeId, T000F27_A186VacationSetDate
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F31_A106EmployeeId, T000F31_A186VacationSetDate
               }
               , new Object[] {
               T000F32_A106EmployeeId, T000F32_A184EmployeeIsActiveInProject, T000F32_A103ProjectName, T000F32_A102ProjectId
               }
               , new Object[] {
               T000F33_A103ProjectName
               }
               , new Object[] {
               T000F34_A106EmployeeId, T000F34_A102ProjectId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F38_A103ProjectName
               }
               , new Object[] {
               T000F39_A102ProjectId
               }
               , new Object[] {
               T000F40_A118WorkHourLogId
               }
               , new Object[] {
               T000F41_A106EmployeeId, T000F41_A102ProjectId
               }
               , new Object[] {
               T000F42_A100CompanyId, T000F42_A101CompanyName
               }
               , new Object[] {
               T000F43_A100CompanyId, T000F43_A101CompanyName
               }
               , new Object[] {
               T000F44_A109EmployeeEmail
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Z184EmployeeIsActiveInProject = true;
         A184EmployeeIsActiveInProject = true;
         i184EmployeeIsActiveInProject = true;
         AV33Pgmname = "Employee";
         Z188EmployeeFTEHours = 40;
         A188EmployeeFTEHours = 40;
         i188EmployeeFTEHours = 40;
         Z146EmployeeVactionDays = (decimal)(21);
         A146EmployeeVactionDays = (decimal)(21);
         i146EmployeeVactionDays = (decimal)(21);
         Z112EmployeeIsActive = false;
         A112EmployeeIsActive = false;
         i112EmployeeIsActive = false;
         Z112EmployeeIsActive = false;
         A112EmployeeIsActive = false;
         i112EmployeeIsActive = false;
      }

      private short Z188EmployeeFTEHours ;
      private short nRcdDeleted_27 ;
      private short nRcdExists_27 ;
      private short nIsMod_27 ;
      private short nRcdDeleted_17 ;
      private short nRcdExists_17 ;
      private short nIsMod_17 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short A188EmployeeFTEHours ;
      private short nBlankRcdCount27 ;
      private short RcdFound27 ;
      private short nBlankRcdUsr27 ;
      private short nBlankRcdCount17 ;
      private short RcdFound17 ;
      private short nBlankRcdUsr17 ;
      private short RcdFound16 ;
      private short nCmpId ;
      private short nIsDirty_27 ;
      private short nIsDirty_17 ;
      private short subGridlevel_vacationset_Backcolorstyle ;
      private short subGridlevel_vacationset_Backstyle ;
      private short subGridlevel_project_Backcolorstyle ;
      private short subGridlevel_project_Backstyle ;
      private short gxajaxcallmode ;
      private short i188EmployeeFTEHours ;
      private short subGridlevel_vacationset_Allowselection ;
      private short subGridlevel_vacationset_Allowhovering ;
      private short subGridlevel_vacationset_Allowcollapsing ;
      private short subGridlevel_vacationset_Collapsed ;
      private short subGridlevel_project_Allowselection ;
      private short subGridlevel_project_Allowhovering ;
      private short subGridlevel_project_Allowcollapsing ;
      private short subGridlevel_project_Collapsed ;
      private int nRC_GXsfl_76 ;
      private int nGXsfl_76_idx=1 ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int trnEnded ;
      private int edtEmployeeFirstName_Enabled ;
      private int edtEmployeeLastName_Enabled ;
      private int edtEmployeeEmail_Enabled ;
      private int edtavEmployeebalance_Enabled ;
      private int bttBtnsetvacationdaysbtn_Visible ;
      private int edtEmployeeFTEHours_Enabled ;
      private int divUnnamedtable2_Visible ;
      private int edtavEmployeeapipassword_Enabled ;
      private int bttBtnuseraction1_Visible ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int edtEmployeeId_Visible ;
      private int edtEmployeeVactionDays_Enabled ;
      private int edtEmployeeVactionDays_Visible ;
      private int edtEmployeeName_Visible ;
      private int edtEmployeeName_Enabled ;
      private int edtGAMUserGUID_Visible ;
      private int edtGAMUserGUID_Enabled ;
      private int edtEmployeeBalance_Enabled ;
      private int edtEmployeeBalance_Visible ;
      private int edtEmployeeVacationDaysSetDate_Visible ;
      private int edtEmployeeVacationDaysSetDate_Enabled ;
      private int edtVacationSetDate_Enabled ;
      private int edtVacationSetDays_Enabled ;
      private int fRowAdded ;
      private int edtProjectId_Enabled ;
      private int Combo_projectid_Datalistupdateminimumcharacters ;
      private int Combo_projectid_Gxcontroltype ;
      private int AV34GXV1 ;
      private int subGridlevel_vacationset_Backcolor ;
      private int subGridlevel_vacationset_Allbackcolor ;
      private int subGridlevel_project_Backcolor ;
      private int subGridlevel_project_Allbackcolor ;
      private int defedtProjectId_Enabled ;
      private int defedtVacationSetDate_Enabled ;
      private int idxLst ;
      private int subGridlevel_vacationset_Selectedindex ;
      private int subGridlevel_vacationset_Selectioncolor ;
      private int subGridlevel_vacationset_Hoveringcolor ;
      private int subGridlevel_project_Selectedindex ;
      private int subGridlevel_project_Selectioncolor ;
      private int subGridlevel_project_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV7EmployeeId ;
      private long Z106EmployeeId ;
      private long Z100CompanyId ;
      private long N100CompanyId ;
      private long Z102ProjectId ;
      private long A106EmployeeId ;
      private long AV13Insert_CompanyId ;
      private long A100CompanyId ;
      private long A102ProjectId ;
      private long AV7EmployeeId ;
      private long GRIDLEVEL_VACATIONSET_nFirstRecordOnPage ;
      private long GRIDLEVEL_PROJECT_nFirstRecordOnPage ;
      private long GXt_int6 ;
      private decimal Z147EmployeeBalance ;
      private decimal Z146EmployeeVactionDays ;
      private decimal Z179VacationSetDays ;
      private decimal AV30EmployeeBalance ;
      private decimal A146EmployeeVactionDays ;
      private decimal A147EmployeeBalance ;
      private decimal A179VacationSetDays ;
      private decimal i146EmployeeVactionDays ;
      private decimal GXt_decimal3 ;
      private decimal ZV30EmployeeBalance ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z148EmployeeName ;
      private string Z107EmployeeFirstName ;
      private string Z108EmployeeLastName ;
      private string Combo_projectid_Caption ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A107EmployeeFirstName ;
      private string A108EmployeeLastName ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEmployeeFirstName_Internalname ;
      private string sGXsfl_76_idx="0001" ;
      private string sGXsfl_84_idx="0001" ;
      private string edtProjectId_Horizontalalignment ;
      private string edtProjectId_Internalname ;
      private string dynCompanyId_Internalname ;
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
      private string edtEmployeeFirstName_Jsonclick ;
      private string edtEmployeeLastName_Internalname ;
      private string edtEmployeeLastName_Jsonclick ;
      private string edtEmployeeEmail_Internalname ;
      private string edtEmployeeEmail_Jsonclick ;
      private string dynCompanyId_Jsonclick ;
      private string chkEmployeeIsActive_Internalname ;
      private string chkEmployeeIsManager_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavEmployeebalance_Internalname ;
      private string edtavEmployeebalance_Jsonclick ;
      private string divAddvacationdayscell_Internalname ;
      private string bttBtnsetvacationdaysbtn_Internalname ;
      private string bttBtnsetvacationdaysbtn_Jsonclick ;
      private string edtEmployeeFTEHours_Internalname ;
      private string edtEmployeeFTEHours_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string edtavEmployeeapipassword_Internalname ;
      private string edtavEmployeeapipassword_Jsonclick ;
      private string bttBtnuseraction1_Internalname ;
      private string bttBtnuseraction1_Jsonclick ;
      private string divTableleaflevel_vacationset_Internalname ;
      private string divTableleaflevel_project_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Combo_projectid_Cls ;
      private string Combo_projectid_Internalname ;
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
      private string sStyleString ;
      private string tblTablesetvacationdaysbtn_modal_Internalname ;
      private string Setvacationdaysbtn_modal_Width ;
      private string Setvacationdaysbtn_modal_Title ;
      private string Setvacationdaysbtn_modal_Confirmtype ;
      private string Setvacationdaysbtn_modal_Bodytype ;
      private string Setvacationdaysbtn_modal_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sMode27 ;
      private string edtVacationSetDate_Internalname ;
      private string edtVacationSetDays_Internalname ;
      private string subGridlevel_vacationset_Internalname ;
      private string sMode17 ;
      private string chkEmployeeIsActiveInProject_Internalname ;
      private string subGridlevel_project_Internalname ;
      private string AV24Password ;
      private string A101CompanyName ;
      private string AV33Pgmname ;
      private string A103ProjectName ;
      private string Combo_projectid_Objectcall ;
      private string Combo_projectid_Class ;
      private string Combo_projectid_Icontype ;
      private string Combo_projectid_Icon ;
      private string Combo_projectid_Tooltip ;
      private string Combo_projectid_Selectedvalue_set ;
      private string Combo_projectid_Selectedvalue_get ;
      private string Combo_projectid_Selectedtext_set ;
      private string Combo_projectid_Selectedtext_get ;
      private string Combo_projectid_Gamoauthtoken ;
      private string Combo_projectid_Ddointernalname ;
      private string Combo_projectid_Titlecontrolalign ;
      private string Combo_projectid_Dropdownoptionstype ;
      private string Combo_projectid_Titlecontrolidtoreplace ;
      private string Combo_projectid_Datalisttype ;
      private string Combo_projectid_Datalistfixedvalues ;
      private string Combo_projectid_Datalistproc ;
      private string Combo_projectid_Datalistprocparametersprefix ;
      private string Combo_projectid_Remoteservicesparameters ;
      private string Combo_projectid_Htmltemplate ;
      private string Combo_projectid_Multiplevaluestype ;
      private string Combo_projectid_Loadingdata ;
      private string Combo_projectid_Noresultsfound ;
      private string Combo_projectid_Emptyitemtext ;
      private string Combo_projectid_Onlyselectedvalues ;
      private string Combo_projectid_Selectalltext ;
      private string Combo_projectid_Multiplevaluesseparator ;
      private string Combo_projectid_Addnewoptiontext ;
      private string Setvacationdaysbtn_modal_Objectcall ;
      private string Setvacationdaysbtn_modal_Height ;
      private string Setvacationdaysbtn_modal_Class ;
      private string Setvacationdaysbtn_modal_Confirmationtext ;
      private string Setvacationdaysbtn_modal_Yesbuttoncaption ;
      private string Setvacationdaysbtn_modal_Nobuttoncaption ;
      private string Setvacationdaysbtn_modal_Cancelbuttoncaption ;
      private string Setvacationdaysbtn_modal_Yesbuttonposition ;
      private string Setvacationdaysbtn_modal_Comment ;
      private string Setvacationdaysbtn_modal_Bodycontentinternalname ;
      private string Setvacationdaysbtn_modal_Result ;
      private string Setvacationdaysbtn_modal_Texttype ;
      private string Setvacationdaysbtn_modal_Focusedbutton ;
      private string hsh ;
      private string sMode16 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string GXt_char1 ;
      private string AV28Value ;
      private string Z101CompanyName ;
      private string Z103ProjectName ;
      private string sGXsfl_76_fel_idx="0001" ;
      private string subGridlevel_vacationset_Class ;
      private string subGridlevel_vacationset_Linesclass ;
      private string ROClassString ;
      private string edtVacationSetDate_Jsonclick ;
      private string edtVacationSetDays_Jsonclick ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGridlevel_project_Class ;
      private string subGridlevel_project_Linesclass ;
      private string edtProjectId_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_vacationset_Header ;
      private string subGridlevel_project_Header ;
      private string gxwrpcisep ;
      private DateTime Z177EmployeeVacationDaysSetDate ;
      private DateTime Z186VacationSetDate ;
      private DateTime A177EmployeeVacationDaysSetDate ;
      private DateTime A186VacationSetDate ;
      private bool Z110EmployeeIsManager ;
      private bool Z112EmployeeIsActive ;
      private bool Z184EmployeeIsActiveInProject ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool A112EmployeeIsActive ;
      private bool A110EmployeeIsManager ;
      private bool Combo_projectid_Isgriditem ;
      private bool Combo_projectid_Emptyitem ;
      private bool bGXsfl_76_Refreshing=false ;
      private bool n189VacationSetDescription ;
      private bool Combo_projectid_Enabled ;
      private bool Combo_projectid_Visible ;
      private bool Combo_projectid_Allowmultipleselection ;
      private bool Combo_projectid_Hasdescription ;
      private bool Combo_projectid_Includeonlyselectedoption ;
      private bool Combo_projectid_Includeselectalloption ;
      private bool Combo_projectid_Includeaddnewoption ;
      private bool Setvacationdaysbtn_modal_Enabled ;
      private bool Setvacationdaysbtn_modal_Visible ;
      private bool A184EmployeeIsActiveInProject ;
      private bool returnInSub ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean4 ;
      private bool Gx_longc ;
      private bool i112EmployeeIsActive ;
      private bool i184EmployeeIsActiveInProject ;
      private bool gxdyncontrolsrefreshing ;
      private bool GXt_boolean5 ;
      private string Z111GAMUserGUID ;
      private string Z109EmployeeEmail ;
      private string Z187EmployeeAPIPassword ;
      private string Z189VacationSetDescription ;
      private string A109EmployeeEmail ;
      private string AV31EmployeeAPIPassword ;
      private string A111GAMUserGUID ;
      private string A187EmployeeAPIPassword ;
      private string A189VacationSetDescription ;
      private string AV17ComboSelectedValue ;
      private IGxSession AV12WebSession ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_vacationsetContainer ;
      private GXWebGrid Gridlevel_projectContainer ;
      private GXWebRow Gridlevel_vacationsetRow ;
      private GXWebRow Gridlevel_projectRow ;
      private GXWebColumn Gridlevel_vacationsetColumn ;
      private GXWebColumn Gridlevel_projectColumn ;
      private GXUserControl ucCombo_projectid ;
      private GXUserControl ucSetvacationdaysbtn_modal ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynCompanyId ;
      private GXCheckbox chkEmployeeIsActive ;
      private GXCheckbox chkEmployeeIsManager ;
      private GXCheckbox chkEmployeeIsActiveInProject ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV15ProjectId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item2 ;
      private IDataStoreProvider pr_default ;
      private string[] T000F9_A101CompanyName ;
      private decimal[] T000F10_A147EmployeeBalance ;
      private long[] T000F10_A106EmployeeId ;
      private string[] T000F10_A148EmployeeName ;
      private string[] T000F10_A111GAMUserGUID ;
      private string[] T000F10_A107EmployeeFirstName ;
      private string[] T000F10_A108EmployeeLastName ;
      private string[] T000F10_A109EmployeeEmail ;
      private string[] T000F10_A101CompanyName ;
      private bool[] T000F10_A110EmployeeIsManager ;
      private bool[] T000F10_A112EmployeeIsActive ;
      private decimal[] T000F10_A146EmployeeVactionDays ;
      private DateTime[] T000F10_A177EmployeeVacationDaysSetDate ;
      private string[] T000F10_A187EmployeeAPIPassword ;
      private short[] T000F10_A188EmployeeFTEHours ;
      private long[] T000F10_A100CompanyId ;
      private string[] T000F11_A109EmployeeEmail ;
      private string[] T000F12_A101CompanyName ;
      private long[] T000F13_A106EmployeeId ;
      private decimal[] T000F8_A147EmployeeBalance ;
      private long[] T000F8_A106EmployeeId ;
      private string[] T000F8_A148EmployeeName ;
      private string[] T000F8_A111GAMUserGUID ;
      private string[] T000F8_A107EmployeeFirstName ;
      private string[] T000F8_A108EmployeeLastName ;
      private string[] T000F8_A109EmployeeEmail ;
      private bool[] T000F8_A110EmployeeIsManager ;
      private bool[] T000F8_A112EmployeeIsActive ;
      private decimal[] T000F8_A146EmployeeVactionDays ;
      private DateTime[] T000F8_A177EmployeeVacationDaysSetDate ;
      private string[] T000F8_A187EmployeeAPIPassword ;
      private short[] T000F8_A188EmployeeFTEHours ;
      private long[] T000F8_A100CompanyId ;
      private long[] T000F14_A106EmployeeId ;
      private long[] T000F15_A106EmployeeId ;
      private decimal[] T000F7_A147EmployeeBalance ;
      private long[] T000F7_A106EmployeeId ;
      private string[] T000F7_A148EmployeeName ;
      private string[] T000F7_A111GAMUserGUID ;
      private string[] T000F7_A107EmployeeFirstName ;
      private string[] T000F7_A108EmployeeLastName ;
      private string[] T000F7_A109EmployeeEmail ;
      private bool[] T000F7_A110EmployeeIsManager ;
      private bool[] T000F7_A112EmployeeIsActive ;
      private decimal[] T000F7_A146EmployeeVactionDays ;
      private DateTime[] T000F7_A177EmployeeVacationDaysSetDate ;
      private string[] T000F7_A187EmployeeAPIPassword ;
      private short[] T000F7_A188EmployeeFTEHours ;
      private long[] T000F7_A100CompanyId ;
      private long[] T000F17_A106EmployeeId ;
      private string[] T000F20_A101CompanyName ;
      private long[] T000F21_A102ProjectId ;
      private long[] T000F22_A174SupportRequestId ;
      private long[] T000F23_A127LeaveRequestId ;
      private long[] T000F24_A118WorkHourLogId ;
      private long[] T000F25_A106EmployeeId ;
      private long[] T000F26_A106EmployeeId ;
      private DateTime[] T000F26_A186VacationSetDate ;
      private decimal[] T000F26_A179VacationSetDays ;
      private string[] T000F26_A189VacationSetDescription ;
      private bool[] T000F26_n189VacationSetDescription ;
      private long[] T000F27_A106EmployeeId ;
      private DateTime[] T000F27_A186VacationSetDate ;
      private long[] T000F6_A106EmployeeId ;
      private DateTime[] T000F6_A186VacationSetDate ;
      private decimal[] T000F6_A179VacationSetDays ;
      private string[] T000F6_A189VacationSetDescription ;
      private bool[] T000F6_n189VacationSetDescription ;
      private long[] T000F5_A106EmployeeId ;
      private DateTime[] T000F5_A186VacationSetDate ;
      private decimal[] T000F5_A179VacationSetDays ;
      private string[] T000F5_A189VacationSetDescription ;
      private bool[] T000F5_n189VacationSetDescription ;
      private long[] T000F31_A106EmployeeId ;
      private DateTime[] T000F31_A186VacationSetDate ;
      private long[] T000F32_A106EmployeeId ;
      private bool[] T000F32_A184EmployeeIsActiveInProject ;
      private string[] T000F32_A103ProjectName ;
      private long[] T000F32_A102ProjectId ;
      private string[] T000F4_A103ProjectName ;
      private string[] T000F33_A103ProjectName ;
      private long[] T000F34_A106EmployeeId ;
      private long[] T000F34_A102ProjectId ;
      private long[] T000F3_A106EmployeeId ;
      private bool[] T000F3_A184EmployeeIsActiveInProject ;
      private long[] T000F3_A102ProjectId ;
      private long[] T000F2_A106EmployeeId ;
      private bool[] T000F2_A184EmployeeIsActiveInProject ;
      private long[] T000F2_A102ProjectId ;
      private string[] T000F38_A103ProjectName ;
      private long[] T000F39_A102ProjectId ;
      private long[] T000F40_A118WorkHourLogId ;
      private long[] T000F41_A106EmployeeId ;
      private long[] T000F41_A102ProjectId ;
      private long[] T000F42_A100CompanyId ;
      private string[] T000F42_A101CompanyName ;
      private long[] T000F43_A100CompanyId ;
      private string[] T000F43_A101CompanyName ;
      private string[] T000F44_A109EmployeeEmail ;
      private IDataStoreProvider pr_gam ;
   }

   public class employee__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class employee__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new UpdateCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new UpdateCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new UpdateCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000F2;
        prmT000F2 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F3;
        prmT000F3 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F4;
        prmT000F4 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F5;
        prmT000F5 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmT000F6;
        prmT000F6 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmT000F7;
        prmT000F7 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F8;
        prmT000F8 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F9;
        prmT000F9 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000F10;
        prmT000F10 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F11;
        prmT000F11 = new Object[] {
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F12;
        prmT000F12 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000F13;
        prmT000F13 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F14;
        prmT000F14 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F15;
        prmT000F15 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F16;
        prmT000F16 = new Object[] {
        new ParDef("EmployeeBalance",GXType.Number,4,1) ,
        new ParDef("EmployeeName",GXType.Char,100,0) ,
        new ParDef("GAMUserGUID",GXType.VarChar,100,60) ,
        new ParDef("EmployeeFirstName",GXType.Char,100,0) ,
        new ParDef("EmployeeLastName",GXType.Char,100,0) ,
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeIsManager",GXType.Boolean,4,0) ,
        new ParDef("EmployeeIsActive",GXType.Boolean,4,0) ,
        new ParDef("EmployeeVactionDays",GXType.Number,4,1) ,
        new ParDef("EmployeeVacationDaysSetDate",GXType.Date,8,0) ,
        new ParDef("EmployeeAPIPassword",GXType.VarChar,40,0) ,
        new ParDef("EmployeeFTEHours",GXType.Int16,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000F17;
        prmT000F17 = new Object[] {
        };
        Object[] prmT000F18;
        prmT000F18 = new Object[] {
        new ParDef("EmployeeBalance",GXType.Number,4,1) ,
        new ParDef("EmployeeName",GXType.Char,100,0) ,
        new ParDef("GAMUserGUID",GXType.VarChar,100,60) ,
        new ParDef("EmployeeFirstName",GXType.Char,100,0) ,
        new ParDef("EmployeeLastName",GXType.Char,100,0) ,
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeIsManager",GXType.Boolean,4,0) ,
        new ParDef("EmployeeIsActive",GXType.Boolean,4,0) ,
        new ParDef("EmployeeVactionDays",GXType.Number,4,1) ,
        new ParDef("EmployeeVacationDaysSetDate",GXType.Date,8,0) ,
        new ParDef("EmployeeAPIPassword",GXType.VarChar,40,0) ,
        new ParDef("EmployeeFTEHours",GXType.Int16,4,0) ,
        new ParDef("CompanyId",GXType.Int64,10,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F19;
        prmT000F19 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F20;
        prmT000F20 = new Object[] {
        new ParDef("CompanyId",GXType.Int64,10,0)
        };
        Object[] prmT000F21;
        prmT000F21 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F22;
        prmT000F22 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F23;
        prmT000F23 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F24;
        prmT000F24 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F25;
        prmT000F25 = new Object[] {
        };
        Object[] prmT000F26;
        prmT000F26 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmT000F27;
        prmT000F27 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmT000F28;
        prmT000F28 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0) ,
        new ParDef("VacationSetDays",GXType.Number,4,1) ,
        new ParDef("VacationSetDescription",GXType.VarChar,200,0){Nullable=true}
        };
        Object[] prmT000F29;
        prmT000F29 = new Object[] {
        new ParDef("VacationSetDays",GXType.Number,4,1) ,
        new ParDef("VacationSetDescription",GXType.VarChar,200,0){Nullable=true} ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmT000F30;
        prmT000F30 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("VacationSetDate",GXType.Date,8,0)
        };
        Object[] prmT000F31;
        prmT000F31 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F32;
        prmT000F32 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F33;
        prmT000F33 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F34;
        prmT000F34 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F35;
        prmT000F35 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("EmployeeIsActiveInProject",GXType.Boolean,4,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F36;
        prmT000F36 = new Object[] {
        new ParDef("EmployeeIsActiveInProject",GXType.Boolean,4,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F37;
        prmT000F37 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F38;
        prmT000F38 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F39;
        prmT000F39 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F40;
        prmT000F40 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000F41;
        prmT000F41 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000F42;
        prmT000F42 = new Object[] {
        };
        Object[] prmT000F43;
        prmT000F43 = new Object[] {
        };
        Object[] prmT000F44;
        prmT000F44 = new Object[] {
        new ParDef("EmployeeEmail",GXType.VarChar,100,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000F2", "SELECT EmployeeId, EmployeeIsActiveInProject, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId  FOR UPDATE OF EmployeeProject NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F3", "SELECT EmployeeId, EmployeeIsActiveInProject, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F4", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F5", "SELECT EmployeeId, VacationSetDate, VacationSetDays, VacationSetDescription FROM EmployeeVacationSet WHERE EmployeeId = :EmployeeId AND VacationSetDate = :VacationSetDate  FOR UPDATE OF EmployeeVacationSet NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F6", "SELECT EmployeeId, VacationSetDate, VacationSetDays, VacationSetDescription FROM EmployeeVacationSet WHERE EmployeeId = :EmployeeId AND VacationSetDate = :VacationSetDate ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F7", "SELECT EmployeeBalance, EmployeeId, EmployeeName, GAMUserGUID, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, EmployeeVacationDaysSetDate, EmployeeAPIPassword, EmployeeFTEHours, CompanyId FROM Employee WHERE EmployeeId = :EmployeeId  FOR UPDATE OF Employee NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F8", "SELECT EmployeeBalance, EmployeeId, EmployeeName, GAMUserGUID, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, EmployeeVacationDaysSetDate, EmployeeAPIPassword, EmployeeFTEHours, CompanyId FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F9", "SELECT CompanyName FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F10", "SELECT TM1.EmployeeBalance, TM1.EmployeeId, TM1.EmployeeName, TM1.GAMUserGUID, TM1.EmployeeFirstName, TM1.EmployeeLastName, TM1.EmployeeEmail, T2.CompanyName, TM1.EmployeeIsManager, TM1.EmployeeIsActive, TM1.EmployeeVactionDays, TM1.EmployeeVacationDaysSetDate, TM1.EmployeeAPIPassword, TM1.EmployeeFTEHours, TM1.CompanyId FROM (Employee TM1 INNER JOIN Company T2 ON T2.CompanyId = TM1.CompanyId) WHERE TM1.EmployeeId = :EmployeeId ORDER BY TM1.EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F11", "SELECT EmployeeEmail FROM Employee WHERE (EmployeeEmail = :EmployeeEmail) AND (Not ( EmployeeId = :EmployeeId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F12", "SELECT CompanyName FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F13", "SELECT EmployeeId FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F14", "SELECT EmployeeId FROM Employee WHERE ( EmployeeId > :EmployeeId) ORDER BY EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F15", "SELECT EmployeeId FROM Employee WHERE ( EmployeeId < :EmployeeId) ORDER BY EmployeeId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F16", "SAVEPOINT gxupdate;INSERT INTO Employee(EmployeeBalance, EmployeeName, GAMUserGUID, EmployeeFirstName, EmployeeLastName, EmployeeEmail, EmployeeIsManager, EmployeeIsActive, EmployeeVactionDays, EmployeeVacationDaysSetDate, EmployeeAPIPassword, EmployeeFTEHours, CompanyId) VALUES(:EmployeeBalance, :EmployeeName, :GAMUserGUID, :EmployeeFirstName, :EmployeeLastName, :EmployeeEmail, :EmployeeIsManager, :EmployeeIsActive, :EmployeeVactionDays, :EmployeeVacationDaysSetDate, :EmployeeAPIPassword, :EmployeeFTEHours, :CompanyId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000F16)
           ,new CursorDef("T000F17", "SELECT currval('EmployeeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F18", "SAVEPOINT gxupdate;UPDATE Employee SET EmployeeBalance=:EmployeeBalance, EmployeeName=:EmployeeName, GAMUserGUID=:GAMUserGUID, EmployeeFirstName=:EmployeeFirstName, EmployeeLastName=:EmployeeLastName, EmployeeEmail=:EmployeeEmail, EmployeeIsManager=:EmployeeIsManager, EmployeeIsActive=:EmployeeIsActive, EmployeeVactionDays=:EmployeeVactionDays, EmployeeVacationDaysSetDate=:EmployeeVacationDaysSetDate, EmployeeAPIPassword=:EmployeeAPIPassword, EmployeeFTEHours=:EmployeeFTEHours, CompanyId=:CompanyId  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F18)
           ,new CursorDef("T000F19", "SAVEPOINT gxupdate;DELETE FROM Employee  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F19)
           ,new CursorDef("T000F20", "SELECT CompanyName FROM Company WHERE CompanyId = :CompanyId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F21", "SELECT ProjectId FROM Project WHERE ProjectManagerId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F22", "SELECT SupportRequestId FROM SupportRequest WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F23", "SELECT LeaveRequestId FROM LeaveRequest WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F24", "SELECT WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F25", "SELECT EmployeeId FROM Employee ORDER BY EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F25,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F26", "SELECT EmployeeId, VacationSetDate, VacationSetDays, VacationSetDescription FROM EmployeeVacationSet WHERE EmployeeId = :EmployeeId and VacationSetDate = :VacationSetDate ORDER BY EmployeeId, VacationSetDate ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F26,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F27", "SELECT EmployeeId, VacationSetDate FROM EmployeeVacationSet WHERE EmployeeId = :EmployeeId AND VacationSetDate = :VacationSetDate ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F28", "SAVEPOINT gxupdate;INSERT INTO EmployeeVacationSet(EmployeeId, VacationSetDate, VacationSetDays, VacationSetDescription) VALUES(:EmployeeId, :VacationSetDate, :VacationSetDays, :VacationSetDescription);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000F28)
           ,new CursorDef("T000F29", "SAVEPOINT gxupdate;UPDATE EmployeeVacationSet SET VacationSetDays=:VacationSetDays, VacationSetDescription=:VacationSetDescription  WHERE EmployeeId = :EmployeeId AND VacationSetDate = :VacationSetDate;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F29)
           ,new CursorDef("T000F30", "SAVEPOINT gxupdate;DELETE FROM EmployeeVacationSet  WHERE EmployeeId = :EmployeeId AND VacationSetDate = :VacationSetDate;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F30)
           ,new CursorDef("T000F31", "SELECT EmployeeId, VacationSetDate FROM EmployeeVacationSet WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId, VacationSetDate ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F31,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F32", "SELECT T1.EmployeeId, T1.EmployeeIsActiveInProject, T2.ProjectName, T1.ProjectId FROM (EmployeeProject T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId) WHERE T1.EmployeeId = :EmployeeId and T1.ProjectId = :ProjectId ORDER BY T1.EmployeeId, T1.ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F32,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F33", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F34", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F35", "SAVEPOINT gxupdate;INSERT INTO EmployeeProject(EmployeeId, EmployeeIsActiveInProject, ProjectId) VALUES(:EmployeeId, :EmployeeIsActiveInProject, :ProjectId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000F35)
           ,new CursorDef("T000F36", "SAVEPOINT gxupdate;UPDATE EmployeeProject SET EmployeeIsActiveInProject=:EmployeeIsActiveInProject  WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F36)
           ,new CursorDef("T000F37", "SAVEPOINT gxupdate;DELETE FROM EmployeeProject  WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F37)
           ,new CursorDef("T000F38", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F38,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F39", "SELECT ProjectId FROM Project WHERE ProjectManagerId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F39,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F40", "SELECT WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F40,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F41", "SELECT EmployeeId, ProjectId FROM EmployeeProject WHERE EmployeeId = :EmployeeId ORDER BY EmployeeId, ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F41,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F42", "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F42,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F43", "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F43,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F44", "SELECT EmployeeEmail FROM Employee WHERE (EmployeeEmail = :EmployeeEmail) AND (Not ( EmployeeId = :EmployeeId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F44,1, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 5 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((long[]) buf[13])[0] = rslt.getLong(14);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((long[]) buf[13])[0] = rslt.getLong(14);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((long[]) buf[14])[0] = rslt.getLong(15);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 32 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 37 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 38 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 39 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 40 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 41 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 42 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
