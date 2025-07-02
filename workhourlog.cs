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
   public class workhourlog : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A106EmployeeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A106EmployeeId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            A102ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A106EmployeeId, A102ProjectId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A102ProjectId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProjectId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A102ProjectId) ;
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
               AV7WorkHourLogId = (long)(Math.Round(NumberUtil.Val( GetPar( "WorkHourLogId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7WorkHourLogId", StringUtil.LTrimStr( (decimal)(AV7WorkHourLogId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vWORKHOURLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WorkHourLogId), "ZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Work Hour Log", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWorkHourLogDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public workhourlog( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourlog( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_WorkHourLogId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7WorkHourLogId = aP1_WorkHourLogId;
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
            return "workhourlog_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWorkHourLogId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWorkHourLogId_Internalname, "Log Id", " AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWorkHourLogId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118WorkHourLogId), 10, 0, ".", "")), StringUtil.LTrim( ((edtWorkHourLogId_Enabled!=0) ? context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkHourLogId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWorkHourLogId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_WorkHourLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWorkHourLogDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWorkHourLogDate_Internalname, "Log Date", " AttributeDateLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWorkHourLogDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWorkHourLogDate_Internalname, context.localUtil.Format(A119WorkHourLogDate, "99/99/99"), context.localUtil.Format( A119WorkHourLogDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,12,'eng',false,0);"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkHourLogDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtWorkHourLogDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkHourLog.htm");
         GxWebStd.gx_bitmap( context, edtWorkHourLogDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWorkHourLogDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkHourLog.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWorkHourLogDuration_Internalname, A120WorkHourLogDuration, StringUtil.RTrim( context.localUtil.Format( A120WorkHourLogDuration, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkHourLogDuration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWorkHourLogDuration_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkHourLog.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWorkHourLogHour_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121WorkHourLogHour), 4, 0, ".", "")), StringUtil.LTrim( ((edtWorkHourLogHour_Enabled!=0) ? context.localUtil.Format( (decimal)(A121WorkHourLogHour), "ZZZ9") : context.localUtil.Format( (decimal)(A121WorkHourLogHour), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkHourLogHour_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWorkHourLogHour_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkHourLog.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWorkHourLogMinute_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WorkHourLogMinute), 4, 0, ".", "")), StringUtil.LTrim( ((edtWorkHourLogMinute_Enabled!=0) ? context.localUtil.Format( (decimal)(A122WorkHourLogMinute), "ZZZ9") : context.localUtil.Format( (decimal)(A122WorkHourLogMinute), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWorkHourLogMinute_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWorkHourLogMinute_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkHourLog.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWorkHourLogDescription_Internalname, A123WorkHourLogDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtWorkHourLogDescription_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkHourLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedemployeeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockemployeeid_Internalname, "Employees", "", "", lblTextblockemployeeid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkHourLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_employeeid.SetProperty("Caption", Combo_employeeid_Caption);
         ucCombo_employeeid.SetProperty("Cls", Combo_employeeid_Cls);
         ucCombo_employeeid.SetProperty("DataListProc", Combo_employeeid_Datalistproc);
         ucCombo_employeeid.SetProperty("DataListProcParametersPrefix", Combo_employeeid_Datalistprocparametersprefix);
         ucCombo_employeeid.SetProperty("EmptyItem", Combo_employeeid_Emptyitem);
         ucCombo_employeeid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_employeeid.SetProperty("DropDownOptionsData", AV16EmployeeId_Data);
         ucCombo_employeeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_employeeid_Internalname, "COMBO_EMPLOYEEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeId_Internalname, "Employee Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A106EmployeeId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeId_Jsonclick, 0, "Attribute", "", "", "", "", edtEmployeeId_Visible, edtEmployeeId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_WorkHourLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell DscTop ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedprojectid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprojectid_Internalname, "Employees", "", "", lblTextblockprojectid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkHourLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_projectid.SetProperty("Caption", Combo_projectid_Caption);
         ucCombo_projectid.SetProperty("Cls", Combo_projectid_Cls);
         ucCombo_projectid.SetProperty("DataListProc", Combo_projectid_Datalistproc);
         ucCombo_projectid.SetProperty("EmptyItem", Combo_projectid_Emptyitem);
         ucCombo_projectid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_projectid.SetProperty("DropDownOptionsData", AV24ProjectId_Data);
         ucCombo_projectid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_projectid_Internalname, "COMBO_PROJECTIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProjectId_Internalname, "Project Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProjectId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A102ProjectId), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProjectId_Jsonclick, 0, "Attribute", "", "", "", "", edtProjectId_Visible, edtProjectId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_WorkHourLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProjectName_Internalname, StringUtil.RTrim( A103ProjectName), StringUtil.RTrim( context.localUtil.Format( A103ProjectName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProjectName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProjectName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_WorkHourLog.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirm", bttBtntrn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkHourLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancel", bttBtntrn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkHourLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Delete", bttBtntrn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkHourLog.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_employeeid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboemployeeid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ComboEmployeeId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavComboemployeeid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21ComboEmployeeId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV21ComboEmployeeId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboemployeeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboemployeeid_Visible, edtavComboemployeeid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkHourLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_projectid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboprojectid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ComboProjectId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavComboprojectid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25ComboProjectId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV25ComboProjectId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprojectid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprojectid_Visible, edtavComboprojectid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkHourLog.htm");
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
         E110H2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV17DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vEMPLOYEEID_DATA"), AV16EmployeeId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPROJECTID_DATA"), AV24ProjectId_Data);
               /* Read saved values. */
               Z118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z118WorkHourLogId"), ".", ","), 18, MidpointRounding.ToEven));
               Z119WorkHourLogDate = context.localUtil.CToD( cgiGet( "Z119WorkHourLogDate"), 0);
               Z120WorkHourLogDuration = cgiGet( "Z120WorkHourLogDuration");
               Z121WorkHourLogHour = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z121WorkHourLogHour"), ".", ","), 18, MidpointRounding.ToEven));
               Z122WorkHourLogMinute = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z122WorkHourLogMinute"), ".", ","), 18, MidpointRounding.ToEven));
               Z106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
               Z102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z102ProjectId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N106EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
               N102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N102ProjectId"), ".", ","), 18, MidpointRounding.ToEven));
               AV26Cond_EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCOND_EMPLOYEEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV7WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vWORKHOURLOGID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_EMPLOYEEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV14Insert_ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROJECTID"), ".", ","), 18, MidpointRounding.ToEven));
               A147EmployeeBalance = context.localUtil.CToN( cgiGet( "EMPLOYEEBALANCE"), ".", ",");
               A107EmployeeFirstName = cgiGet( "EMPLOYEEFIRSTNAME");
               AV27Pgmname = cgiGet( "vPGMNAME");
               Combo_employeeid_Objectcall = cgiGet( "COMBO_EMPLOYEEID_Objectcall");
               Combo_employeeid_Class = cgiGet( "COMBO_EMPLOYEEID_Class");
               Combo_employeeid_Icontype = cgiGet( "COMBO_EMPLOYEEID_Icontype");
               Combo_employeeid_Icon = cgiGet( "COMBO_EMPLOYEEID_Icon");
               Combo_employeeid_Caption = cgiGet( "COMBO_EMPLOYEEID_Caption");
               Combo_employeeid_Tooltip = cgiGet( "COMBO_EMPLOYEEID_Tooltip");
               Combo_employeeid_Cls = cgiGet( "COMBO_EMPLOYEEID_Cls");
               Combo_employeeid_Selectedvalue_set = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_set");
               Combo_employeeid_Selectedvalue_get = cgiGet( "COMBO_EMPLOYEEID_Selectedvalue_get");
               Combo_employeeid_Selectedtext_set = cgiGet( "COMBO_EMPLOYEEID_Selectedtext_set");
               Combo_employeeid_Selectedtext_get = cgiGet( "COMBO_EMPLOYEEID_Selectedtext_get");
               Combo_employeeid_Gamoauthtoken = cgiGet( "COMBO_EMPLOYEEID_Gamoauthtoken");
               Combo_employeeid_Ddointernalname = cgiGet( "COMBO_EMPLOYEEID_Ddointernalname");
               Combo_employeeid_Titlecontrolalign = cgiGet( "COMBO_EMPLOYEEID_Titlecontrolalign");
               Combo_employeeid_Dropdownoptionstype = cgiGet( "COMBO_EMPLOYEEID_Dropdownoptionstype");
               Combo_employeeid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Enabled"));
               Combo_employeeid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Visible"));
               Combo_employeeid_Titlecontrolidtoreplace = cgiGet( "COMBO_EMPLOYEEID_Titlecontrolidtoreplace");
               Combo_employeeid_Datalisttype = cgiGet( "COMBO_EMPLOYEEID_Datalisttype");
               Combo_employeeid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Allowmultipleselection"));
               Combo_employeeid_Datalistfixedvalues = cgiGet( "COMBO_EMPLOYEEID_Datalistfixedvalues");
               Combo_employeeid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Isgriditem"));
               Combo_employeeid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Hasdescription"));
               Combo_employeeid_Datalistproc = cgiGet( "COMBO_EMPLOYEEID_Datalistproc");
               Combo_employeeid_Datalistprocparametersprefix = cgiGet( "COMBO_EMPLOYEEID_Datalistprocparametersprefix");
               Combo_employeeid_Remoteservicesparameters = cgiGet( "COMBO_EMPLOYEEID_Remoteservicesparameters");
               Combo_employeeid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_EMPLOYEEID_Datalistupdateminimumcharacters"), ".", ","), 18, MidpointRounding.ToEven));
               Combo_employeeid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Includeonlyselectedoption"));
               Combo_employeeid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Includeselectalloption"));
               Combo_employeeid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Emptyitem"));
               Combo_employeeid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_EMPLOYEEID_Includeaddnewoption"));
               Combo_employeeid_Htmltemplate = cgiGet( "COMBO_EMPLOYEEID_Htmltemplate");
               Combo_employeeid_Multiplevaluestype = cgiGet( "COMBO_EMPLOYEEID_Multiplevaluestype");
               Combo_employeeid_Loadingdata = cgiGet( "COMBO_EMPLOYEEID_Loadingdata");
               Combo_employeeid_Noresultsfound = cgiGet( "COMBO_EMPLOYEEID_Noresultsfound");
               Combo_employeeid_Emptyitemtext = cgiGet( "COMBO_EMPLOYEEID_Emptyitemtext");
               Combo_employeeid_Onlyselectedvalues = cgiGet( "COMBO_EMPLOYEEID_Onlyselectedvalues");
               Combo_employeeid_Selectalltext = cgiGet( "COMBO_EMPLOYEEID_Selectalltext");
               Combo_employeeid_Multiplevaluesseparator = cgiGet( "COMBO_EMPLOYEEID_Multiplevaluesseparator");
               Combo_employeeid_Addnewoptiontext = cgiGet( "COMBO_EMPLOYEEID_Addnewoptiontext");
               Combo_employeeid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_EMPLOYEEID_Gxcontroltype"), ".", ","), 18, MidpointRounding.ToEven));
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
               /* Read variables values. */
               A118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
               if ( context.localUtil.VCDate( cgiGet( edtWorkHourLogDate_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Work Hour Log Date"}), 1, "WORKHOURLOGDATE");
                  AnyError = 1;
                  GX_FocusControl = edtWorkHourLogDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A119WorkHourLogDate = DateTime.MinValue;
                  AssignAttri("", false, "A119WorkHourLogDate", context.localUtil.Format(A119WorkHourLogDate, "99/99/99"));
               }
               else
               {
                  A119WorkHourLogDate = context.localUtil.CToD( cgiGet( edtWorkHourLogDate_Internalname), 2);
                  AssignAttri("", false, "A119WorkHourLogDate", context.localUtil.Format(A119WorkHourLogDate, "99/99/99"));
               }
               A120WorkHourLogDuration = cgiGet( edtWorkHourLogDuration_Internalname);
               AssignAttri("", false, "A120WorkHourLogDuration", A120WorkHourLogDuration);
               if ( ( ( context.localUtil.CToN( cgiGet( edtWorkHourLogHour_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWorkHourLogHour_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WORKHOURLOGHOUR");
                  AnyError = 1;
                  GX_FocusControl = edtWorkHourLogHour_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A121WorkHourLogHour = 0;
                  AssignAttri("", false, "A121WorkHourLogHour", StringUtil.LTrimStr( (decimal)(A121WorkHourLogHour), 4, 0));
               }
               else
               {
                  A121WorkHourLogHour = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogHour_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A121WorkHourLogHour", StringUtil.LTrimStr( (decimal)(A121WorkHourLogHour), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtWorkHourLogMinute_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWorkHourLogMinute_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WORKHOURLOGMINUTE");
                  AnyError = 1;
                  GX_FocusControl = edtWorkHourLogMinute_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A122WorkHourLogMinute = 0;
                  AssignAttri("", false, "A122WorkHourLogMinute", StringUtil.LTrimStr( (decimal)(A122WorkHourLogMinute), 4, 0));
               }
               else
               {
                  A122WorkHourLogMinute = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogMinute_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A122WorkHourLogMinute", StringUtil.LTrimStr( (decimal)(A122WorkHourLogMinute), 4, 0));
               }
               A123WorkHourLogDescription = cgiGet( edtWorkHourLogDescription_Internalname);
               AssignAttri("", false, "A123WorkHourLogDescription", A123WorkHourLogDescription);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEEID");
                  AnyError = 1;
                  GX_FocusControl = edtEmployeeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A106EmployeeId = 0;
                  AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               }
               else
               {
                  A106EmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROJECTID");
                  AnyError = 1;
                  GX_FocusControl = edtProjectId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A102ProjectId = 0;
                  AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
               }
               else
               {
                  A102ProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProjectId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
               }
               A103ProjectName = cgiGet( edtProjectName_Internalname);
               AssignAttri("", false, "A103ProjectName", A103ProjectName);
               AV21ComboEmployeeId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboemployeeid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21ComboEmployeeId", StringUtil.LTrimStr( (decimal)(AV21ComboEmployeeId), 10, 0));
               AV25ComboProjectId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboprojectid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25ComboProjectId", StringUtil.LTrimStr( (decimal)(AV25ComboProjectId), 10, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"WorkHourLog");
               A118WorkHourLogId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWorkHourLogId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
               forbiddenHiddens.Add("WorkHourLogId", context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A118WorkHourLogId != Z118WorkHourLogId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("workhourlog:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A118WorkHourLogId = (long)(Math.Round(NumberUtil.Val( GetPar( "WorkHourLogId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
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
                     sMode19 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode19;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound19 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0H0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "WORKHOURLOGID");
                        AnyError = 1;
                        GX_FocusControl = edtWorkHourLogId_Internalname;
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
                           E110H2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120H2 ();
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
            E120H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0H19( ) ;
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
            DisableAttributes0H19( ) ;
         }
         AssignProp("", false, edtavComboemployeeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboemployeeid_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboprojectid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprojectid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H19( ) ;
            }
            else
            {
               CheckExtendedTable0H19( ) ;
               CloseExtendedTableCursors0H19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0H0( )
      {
      }

      protected void E110H2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV17DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV17DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV23GAMErrors);
         Combo_projectid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "GAMOAuthToken", Combo_projectid_Gamoauthtoken);
         edtProjectId_Visible = 0;
         AssignProp("", false, edtProjectId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProjectId_Visible), 5, 0), true);
         AV25ComboProjectId = 0;
         AssignAttri("", false, "AV25ComboProjectId", StringUtil.LTrimStr( (decimal)(AV25ComboProjectId), 10, 0));
         edtavComboprojectid_Visible = 0;
         AssignProp("", false, edtavComboprojectid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboprojectid_Visible), 5, 0), true);
         Combo_employeeid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "GAMOAuthToken", Combo_employeeid_Gamoauthtoken);
         edtEmployeeId_Visible = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Visible), 5, 0), true);
         AV21ComboEmployeeId = 0;
         AssignAttri("", false, "AV21ComboEmployeeId", StringUtil.LTrimStr( (decimal)(AV21ComboEmployeeId), 10, 0));
         edtavComboemployeeid_Visible = 0;
         AssignProp("", false, edtavComboemployeeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboemployeeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOEMPLOYEEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPROJECTID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            while ( AV28GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "EmployeeId") == 0 )
               {
                  AV13Insert_EmployeeId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_EmployeeId", StringUtil.LTrimStr( (decimal)(AV13Insert_EmployeeId), 10, 0));
                  if ( ! (0==AV13Insert_EmployeeId) )
                  {
                     AV21ComboEmployeeId = AV13Insert_EmployeeId;
                     AssignAttri("", false, "AV21ComboEmployeeId", StringUtil.LTrimStr( (decimal)(AV21ComboEmployeeId), 10, 0));
                     Combo_employeeid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV21ComboEmployeeId), 10, 0));
                     ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
                     GXt_char2 = AV20Combo_DataJson;
                     new workhourlogloaddvcombo(context ).execute(  "EmployeeId",  "GET",  false,  AV7WorkHourLogId,  A106EmployeeId,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
                     AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
                     AV20Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
                     Combo_employeeid_Selectedtext_set = AV19ComboSelectedText;
                     ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedText_set", Combo_employeeid_Selectedtext_set);
                     Combo_employeeid_Enabled = false;
                     ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_employeeid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ProjectId") == 0 )
               {
                  AV14Insert_ProjectId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_ProjectId", StringUtil.LTrimStr( (decimal)(AV14Insert_ProjectId), 10, 0));
                  if ( ! (0==AV14Insert_ProjectId) )
                  {
                     AV25ComboProjectId = AV14Insert_ProjectId;
                     AssignAttri("", false, "AV25ComboProjectId", StringUtil.LTrimStr( (decimal)(AV25ComboProjectId), 10, 0));
                     Combo_projectid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV25ComboProjectId), 10, 0));
                     ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedValue_set", Combo_projectid_Selectedvalue_set);
                     GXt_char2 = AV20Combo_DataJson;
                     new workhourlogloaddvcombo(context ).execute(  "ProjectId",  "GET",  false,  AV7WorkHourLogId,  AV13Insert_EmployeeId,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
                     AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
                     AV20Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
                     Combo_projectid_Selectedtext_set = AV19ComboSelectedText;
                     ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedText_set", Combo_projectid_Selectedtext_set);
                     Combo_projectid_Enabled = false;
                     ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_projectid_Enabled));
                  }
               }
               AV28GXV1 = (int)(AV28GXV1+1);
               AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            }
         }
      }

      protected void E120H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("workhourlogww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROJECTID' Routine */
         returnInSub = false;
         Combo_projectid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"ProjectId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"WorkHourLogId\": 0, \"Cond_EmployeeId\": \"#%1#\"", edtEmployeeId_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "DataListProcParametersPrefix", Combo_projectid_Datalistprocparametersprefix);
         GXt_char2 = AV20Combo_DataJson;
         new workhourlogloaddvcombo(context ).execute(  "ProjectId",  Gx_mode,  false,  AV7WorkHourLogId,  A106EmployeeId,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         Combo_projectid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedValue_set", Combo_projectid_Selectedvalue_set);
         Combo_projectid_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "SelectedText_set", Combo_projectid_Selectedtext_set);
         AV25ComboProjectId = (long)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV25ComboProjectId", StringUtil.LTrimStr( (decimal)(AV25ComboProjectId), 10, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_projectid_Enabled = false;
            ucCombo_projectid.SendProperty(context, "", false, Combo_projectid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_projectid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOEMPLOYEEID' Routine */
         returnInSub = false;
         GXt_char2 = AV20Combo_DataJson;
         new workhourlogloaddvcombo(context ).execute(  "EmployeeId",  Gx_mode,  false,  AV7WorkHourLogId,  A106EmployeeId,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         Combo_employeeid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedValue_set", Combo_employeeid_Selectedvalue_set);
         Combo_employeeid_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "SelectedText_set", Combo_employeeid_Selectedtext_set);
         AV21ComboEmployeeId = (long)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV21ComboEmployeeId", StringUtil.LTrimStr( (decimal)(AV21ComboEmployeeId), 10, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_employeeid_Enabled = false;
            ucCombo_employeeid.SendProperty(context, "", false, Combo_employeeid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_employeeid_Enabled));
         }
      }

      protected void ZM0H19( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z119WorkHourLogDate = T000H3_A119WorkHourLogDate[0];
               Z120WorkHourLogDuration = T000H3_A120WorkHourLogDuration[0];
               Z121WorkHourLogHour = T000H3_A121WorkHourLogHour[0];
               Z122WorkHourLogMinute = T000H3_A122WorkHourLogMinute[0];
               Z106EmployeeId = T000H3_A106EmployeeId[0];
               Z102ProjectId = T000H3_A102ProjectId[0];
            }
            else
            {
               Z119WorkHourLogDate = A119WorkHourLogDate;
               Z120WorkHourLogDuration = A120WorkHourLogDuration;
               Z121WorkHourLogHour = A121WorkHourLogHour;
               Z122WorkHourLogMinute = A122WorkHourLogMinute;
               Z106EmployeeId = A106EmployeeId;
               Z102ProjectId = A102ProjectId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z118WorkHourLogId = A118WorkHourLogId;
            Z119WorkHourLogDate = A119WorkHourLogDate;
            Z120WorkHourLogDuration = A120WorkHourLogDuration;
            Z121WorkHourLogHour = A121WorkHourLogHour;
            Z122WorkHourLogMinute = A122WorkHourLogMinute;
            Z123WorkHourLogDescription = A123WorkHourLogDescription;
            Z106EmployeeId = A106EmployeeId;
            Z102ProjectId = A102ProjectId;
            Z147EmployeeBalance = A147EmployeeBalance;
            Z107EmployeeFirstName = A107EmployeeFirstName;
            Z103ProjectName = A103ProjectName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtWorkHourLogId_Enabled = 0;
         AssignProp("", false, edtWorkHourLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogId_Enabled), 5, 0), true);
         AV27Pgmname = "WorkHourLog";
         AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
         edtWorkHourLogId_Enabled = 0;
         AssignProp("", false, edtWorkHourLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7WorkHourLogId) )
         {
            A118WorkHourLogId = AV7WorkHourLogId;
            AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_EmployeeId) )
         {
            edtEmployeeId_Enabled = 0;
            AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         }
         else
         {
            edtEmployeeId_Enabled = 1;
            AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_ProjectId) )
         {
            edtProjectId_Enabled = 0;
            AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), true);
         }
         else
         {
            edtProjectId_Enabled = 1;
            AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_EmployeeId) )
         {
            A106EmployeeId = AV13Insert_EmployeeId;
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         else
         {
            A106EmployeeId = AV21ComboEmployeeId;
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_ProjectId) )
         {
            A102ProjectId = AV14Insert_ProjectId;
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
         }
         else
         {
            A102ProjectId = AV25ComboProjectId;
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000H4 */
            pr_default.execute(2, new Object[] {A106EmployeeId});
            A147EmployeeBalance = T000H4_A147EmployeeBalance[0];
            A107EmployeeFirstName = T000H4_A107EmployeeFirstName[0];
            pr_default.close(2);
            /* Using cursor T000H5 */
            pr_default.execute(3, new Object[] {A102ProjectId});
            A103ProjectName = T000H5_A103ProjectName[0];
            AssignAttri("", false, "A103ProjectName", A103ProjectName);
            pr_default.close(3);
         }
      }

      protected void Load0H19( )
      {
         /* Using cursor T000H7 */
         pr_default.execute(5, new Object[] {A118WorkHourLogId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound19 = 1;
            A147EmployeeBalance = T000H7_A147EmployeeBalance[0];
            A119WorkHourLogDate = T000H7_A119WorkHourLogDate[0];
            AssignAttri("", false, "A119WorkHourLogDate", context.localUtil.Format(A119WorkHourLogDate, "99/99/99"));
            A120WorkHourLogDuration = T000H7_A120WorkHourLogDuration[0];
            AssignAttri("", false, "A120WorkHourLogDuration", A120WorkHourLogDuration);
            A121WorkHourLogHour = T000H7_A121WorkHourLogHour[0];
            AssignAttri("", false, "A121WorkHourLogHour", StringUtil.LTrimStr( (decimal)(A121WorkHourLogHour), 4, 0));
            A122WorkHourLogMinute = T000H7_A122WorkHourLogMinute[0];
            AssignAttri("", false, "A122WorkHourLogMinute", StringUtil.LTrimStr( (decimal)(A122WorkHourLogMinute), 4, 0));
            A123WorkHourLogDescription = T000H7_A123WorkHourLogDescription[0];
            AssignAttri("", false, "A123WorkHourLogDescription", A123WorkHourLogDescription);
            A107EmployeeFirstName = T000H7_A107EmployeeFirstName[0];
            A103ProjectName = T000H7_A103ProjectName[0];
            AssignAttri("", false, "A103ProjectName", A103ProjectName);
            A106EmployeeId = T000H7_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            A102ProjectId = T000H7_A102ProjectId[0];
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
            ZM0H19( -11) ;
         }
         pr_default.close(5);
         OnLoadActions0H19( ) ;
      }

      protected void OnLoadActions0H19( )
      {
      }

      protected void CheckExtendedTable0H19( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000H4 */
         pr_default.execute(2, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A147EmployeeBalance = T000H4_A147EmployeeBalance[0];
         A107EmployeeFirstName = T000H4_A107EmployeeFirstName[0];
         pr_default.close(2);
         /* Using cursor T000H6 */
         pr_default.execute(4, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T000H5 */
         pr_default.execute(3, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A103ProjectName = T000H5_A103ProjectName[0];
         AssignAttri("", false, "A103ProjectName", A103ProjectName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0H19( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( long A106EmployeeId )
      {
         /* Using cursor T000H8 */
         pr_default.execute(6, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A147EmployeeBalance = T000H8_A147EmployeeBalance[0];
         A107EmployeeFirstName = T000H8_A107EmployeeFirstName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A107EmployeeFirstName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_14( long A106EmployeeId ,
                                long A102ProjectId )
      {
         /* Using cursor T000H9 */
         pr_default.execute(7, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_13( long A102ProjectId )
      {
         /* Using cursor T000H10 */
         pr_default.execute(8, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A103ProjectName = T000H10_A103ProjectName[0];
         AssignAttri("", false, "A103ProjectName", A103ProjectName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A103ProjectName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0H19( )
      {
         /* Using cursor T000H11 */
         pr_default.execute(9, new Object[] {A118WorkHourLogId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000H3 */
         pr_default.execute(1, new Object[] {A118WorkHourLogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H19( 11) ;
            RcdFound19 = 1;
            A118WorkHourLogId = T000H3_A118WorkHourLogId[0];
            AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
            A119WorkHourLogDate = T000H3_A119WorkHourLogDate[0];
            AssignAttri("", false, "A119WorkHourLogDate", context.localUtil.Format(A119WorkHourLogDate, "99/99/99"));
            A120WorkHourLogDuration = T000H3_A120WorkHourLogDuration[0];
            AssignAttri("", false, "A120WorkHourLogDuration", A120WorkHourLogDuration);
            A121WorkHourLogHour = T000H3_A121WorkHourLogHour[0];
            AssignAttri("", false, "A121WorkHourLogHour", StringUtil.LTrimStr( (decimal)(A121WorkHourLogHour), 4, 0));
            A122WorkHourLogMinute = T000H3_A122WorkHourLogMinute[0];
            AssignAttri("", false, "A122WorkHourLogMinute", StringUtil.LTrimStr( (decimal)(A122WorkHourLogMinute), 4, 0));
            A123WorkHourLogDescription = T000H3_A123WorkHourLogDescription[0];
            AssignAttri("", false, "A123WorkHourLogDescription", A123WorkHourLogDescription);
            A106EmployeeId = T000H3_A106EmployeeId[0];
            AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
            A102ProjectId = T000H3_A102ProjectId[0];
            AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
            Z118WorkHourLogId = A118WorkHourLogId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0H19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0H19( ) ;
            }
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0H19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H19( ) ;
         if ( RcdFound19 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound19 = 0;
         /* Using cursor T000H12 */
         pr_default.execute(10, new Object[] {A118WorkHourLogId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000H12_A118WorkHourLogId[0] < A118WorkHourLogId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000H12_A118WorkHourLogId[0] > A118WorkHourLogId ) ) )
            {
               A118WorkHourLogId = T000H12_A118WorkHourLogId[0];
               AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
               RcdFound19 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound19 = 0;
         /* Using cursor T000H13 */
         pr_default.execute(11, new Object[] {A118WorkHourLogId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000H13_A118WorkHourLogId[0] > A118WorkHourLogId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000H13_A118WorkHourLogId[0] < A118WorkHourLogId ) ) )
            {
               A118WorkHourLogId = T000H13_A118WorkHourLogId[0];
               AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
               RcdFound19 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0H19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWorkHourLogDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0H19( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( A118WorkHourLogId != Z118WorkHourLogId )
               {
                  A118WorkHourLogId = Z118WorkHourLogId;
                  AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WORKHOURLOGID");
                  AnyError = 1;
                  GX_FocusControl = edtWorkHourLogId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWorkHourLogDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0H19( ) ;
                  GX_FocusControl = edtWorkHourLogDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A118WorkHourLogId != Z118WorkHourLogId )
               {
                  /* Insert record */
                  GX_FocusControl = edtWorkHourLogDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0H19( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WORKHOURLOGID");
                     AnyError = 1;
                     GX_FocusControl = edtWorkHourLogId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtWorkHourLogDate_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0H19( ) ;
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
         if ( A118WorkHourLogId != Z118WorkHourLogId )
         {
            A118WorkHourLogId = Z118WorkHourLogId;
            AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WORKHOURLOGID");
            AnyError = 1;
            GX_FocusControl = edtWorkHourLogId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWorkHourLogDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0H19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000H2 */
            pr_default.execute(0, new Object[] {A118WorkHourLogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WorkHourLog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z119WorkHourLogDate ) != DateTimeUtil.ResetTime ( T000H2_A119WorkHourLogDate[0] ) ) || ( StringUtil.StrCmp(Z120WorkHourLogDuration, T000H2_A120WorkHourLogDuration[0]) != 0 ) || ( Z121WorkHourLogHour != T000H2_A121WorkHourLogHour[0] ) || ( Z122WorkHourLogMinute != T000H2_A122WorkHourLogMinute[0] ) || ( Z106EmployeeId != T000H2_A106EmployeeId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z102ProjectId != T000H2_A102ProjectId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z119WorkHourLogDate ) != DateTimeUtil.ResetTime ( T000H2_A119WorkHourLogDate[0] ) )
               {
                  GXUtil.WriteLog("workhourlog:[seudo value changed for attri]"+"WorkHourLogDate");
                  GXUtil.WriteLogRaw("Old: ",Z119WorkHourLogDate);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A119WorkHourLogDate[0]);
               }
               if ( StringUtil.StrCmp(Z120WorkHourLogDuration, T000H2_A120WorkHourLogDuration[0]) != 0 )
               {
                  GXUtil.WriteLog("workhourlog:[seudo value changed for attri]"+"WorkHourLogDuration");
                  GXUtil.WriteLogRaw("Old: ",Z120WorkHourLogDuration);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A120WorkHourLogDuration[0]);
               }
               if ( Z121WorkHourLogHour != T000H2_A121WorkHourLogHour[0] )
               {
                  GXUtil.WriteLog("workhourlog:[seudo value changed for attri]"+"WorkHourLogHour");
                  GXUtil.WriteLogRaw("Old: ",Z121WorkHourLogHour);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A121WorkHourLogHour[0]);
               }
               if ( Z122WorkHourLogMinute != T000H2_A122WorkHourLogMinute[0] )
               {
                  GXUtil.WriteLog("workhourlog:[seudo value changed for attri]"+"WorkHourLogMinute");
                  GXUtil.WriteLogRaw("Old: ",Z122WorkHourLogMinute);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A122WorkHourLogMinute[0]);
               }
               if ( Z106EmployeeId != T000H2_A106EmployeeId[0] )
               {
                  GXUtil.WriteLog("workhourlog:[seudo value changed for attri]"+"EmployeeId");
                  GXUtil.WriteLogRaw("Old: ",Z106EmployeeId);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A106EmployeeId[0]);
               }
               if ( Z102ProjectId != T000H2_A102ProjectId[0] )
               {
                  GXUtil.WriteLog("workhourlog:[seudo value changed for attri]"+"ProjectId");
                  GXUtil.WriteLogRaw("Old: ",Z102ProjectId);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A102ProjectId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WorkHourLog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H19( )
      {
         if ( ! IsAuthorized("workhourlog_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H19( 0) ;
            CheckOptimisticConcurrency0H19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H14 */
                     pr_default.execute(12, new Object[] {A119WorkHourLogDate, A120WorkHourLogDuration, A121WorkHourLogHour, A122WorkHourLogMinute, A123WorkHourLogDescription, A106EmployeeId, A102ProjectId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000H15 */
                     pr_default.execute(13);
                     A118WorkHourLogId = T000H15_A118WorkHourLogId[0];
                     AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WorkHourLog");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0H0( ) ;
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
               Load0H19( ) ;
            }
            EndLevel0H19( ) ;
         }
         CloseExtendedTableCursors0H19( ) ;
      }

      protected void Update0H19( )
      {
         if ( ! IsAuthorized("workhourlog_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H16 */
                     pr_default.execute(14, new Object[] {A119WorkHourLogDate, A120WorkHourLogDuration, A121WorkHourLogHour, A122WorkHourLogMinute, A123WorkHourLogDescription, A106EmployeeId, A102ProjectId, A118WorkHourLogId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("WorkHourLog");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WorkHourLog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H19( ) ;
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
            EndLevel0H19( ) ;
         }
         CloseExtendedTableCursors0H19( ) ;
      }

      protected void DeferredUpdate0H19( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("workhourlog_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0H19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H19( ) ;
            AfterConfirm0H19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000H17 */
                  pr_default.execute(15, new Object[] {A118WorkHourLogId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("WorkHourLog");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0H19( ) ;
         Gx_mode = sMode19;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0H19( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000H18 */
            pr_default.execute(16, new Object[] {A106EmployeeId});
            A147EmployeeBalance = T000H18_A147EmployeeBalance[0];
            A107EmployeeFirstName = T000H18_A107EmployeeFirstName[0];
            pr_default.close(16);
            /* Using cursor T000H19 */
            pr_default.execute(17, new Object[] {A102ProjectId});
            A103ProjectName = T000H19_A103ProjectName[0];
            AssignAttri("", false, "A103ProjectName", A103ProjectName);
            pr_default.close(17);
         }
      }

      protected void EndLevel0H19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H19( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("workhourlog",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("workhourlog",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0H19( )
      {
         /* Scan By routine */
         /* Using cursor T000H20 */
         pr_default.execute(18);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound19 = 1;
            A118WorkHourLogId = T000H20_A118WorkHourLogId[0];
            AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0H19( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound19 = 1;
            A118WorkHourLogId = T000H20_A118WorkHourLogId[0];
            AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
         }
      }

      protected void ScanEnd0H19( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0H19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H19( )
      {
         edtWorkHourLogId_Enabled = 0;
         AssignProp("", false, edtWorkHourLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogId_Enabled), 5, 0), true);
         edtWorkHourLogDate_Enabled = 0;
         AssignProp("", false, edtWorkHourLogDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDate_Enabled), 5, 0), true);
         edtWorkHourLogDuration_Enabled = 0;
         AssignProp("", false, edtWorkHourLogDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDuration_Enabled), 5, 0), true);
         edtWorkHourLogHour_Enabled = 0;
         AssignProp("", false, edtWorkHourLogHour_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogHour_Enabled), 5, 0), true);
         edtWorkHourLogMinute_Enabled = 0;
         AssignProp("", false, edtWorkHourLogMinute_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogMinute_Enabled), 5, 0), true);
         edtWorkHourLogDescription_Enabled = 0;
         AssignProp("", false, edtWorkHourLogDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWorkHourLogDescription_Enabled), 5, 0), true);
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         edtProjectId_Enabled = 0;
         AssignProp("", false, edtProjectId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectId_Enabled), 5, 0), true);
         edtProjectName_Enabled = 0;
         AssignProp("", false, edtProjectName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProjectName_Enabled), 5, 0), true);
         edtavComboemployeeid_Enabled = 0;
         AssignProp("", false, edtavComboemployeeid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboemployeeid_Enabled), 5, 0), true);
         edtavComboprojectid_Enabled = 0;
         AssignProp("", false, edtavComboprojectid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprojectid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0H19( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0H0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workhourlog.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7WorkHourLogId,10,0))}, new string[] {"Gx_mode","WorkHourLogId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"WorkHourLog");
         forbiddenHiddens.Add("WorkHourLogId", context.localUtil.Format( (decimal)(A118WorkHourLogId), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workhourlog:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z118WorkHourLogId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118WorkHourLogId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z119WorkHourLogDate", context.localUtil.DToC( Z119WorkHourLogDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z120WorkHourLogDuration", Z120WorkHourLogDuration);
         GxWebStd.gx_hidden_field( context, "Z121WorkHourLogHour", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121WorkHourLogHour), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z122WorkHourLogMinute", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z122WorkHourLogMinute), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z102ProjectId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102ProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N106EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N102ProjectId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102ProjectId), 10, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEMPLOYEEID_DATA", AV16EmployeeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEMPLOYEEID_DATA", AV16EmployeeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROJECTID_DATA", AV24ProjectId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROJECTID_DATA", AV24ProjectId_Data);
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
         GxWebStd.gx_hidden_field( context, "vCOND_EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Cond_EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vWORKHOURLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WorkHourLogId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWORKHOURLOGID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7WorkHourLogId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_EmployeeId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROJECTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_ProjectId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEBALANCE", StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")));
         GxWebStd.gx_hidden_field( context, "EMPLOYEEFIRSTNAME", StringUtil.RTrim( A107EmployeeFirstName));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Objectcall", StringUtil.RTrim( Combo_employeeid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Cls", StringUtil.RTrim( Combo_employeeid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedvalue_set", StringUtil.RTrim( Combo_employeeid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Selectedtext_set", StringUtil.RTrim( Combo_employeeid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Gamoauthtoken", StringUtil.RTrim( Combo_employeeid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Enabled", StringUtil.BoolToStr( Combo_employeeid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Datalistproc", StringUtil.RTrim( Combo_employeeid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_employeeid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_EMPLOYEEID_Emptyitem", StringUtil.BoolToStr( Combo_employeeid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Objectcall", StringUtil.RTrim( Combo_projectid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Cls", StringUtil.RTrim( Combo_projectid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedvalue_set", StringUtil.RTrim( Combo_projectid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Selectedtext_set", StringUtil.RTrim( Combo_projectid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Gamoauthtoken", StringUtil.RTrim( Combo_projectid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Enabled", StringUtil.BoolToStr( Combo_projectid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Datalistproc", StringUtil.RTrim( Combo_projectid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_projectid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PROJECTID_Emptyitem", StringUtil.BoolToStr( Combo_projectid_Emptyitem));
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
         return formatLink("workhourlog.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7WorkHourLogId,10,0))}, new string[] {"Gx_mode","WorkHourLogId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WorkHourLog" ;
      }

      public override string GetPgmdesc( )
      {
         return "Work Hour Log" ;
      }

      protected void InitializeNonKey0H19( )
      {
         A106EmployeeId = 0;
         AssignAttri("", false, "A106EmployeeId", StringUtil.LTrimStr( (decimal)(A106EmployeeId), 10, 0));
         A102ProjectId = 0;
         AssignAttri("", false, "A102ProjectId", StringUtil.LTrimStr( (decimal)(A102ProjectId), 10, 0));
         A147EmployeeBalance = 0;
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrimStr( A147EmployeeBalance, 4, 1));
         A119WorkHourLogDate = DateTime.MinValue;
         AssignAttri("", false, "A119WorkHourLogDate", context.localUtil.Format(A119WorkHourLogDate, "99/99/99"));
         A120WorkHourLogDuration = "";
         AssignAttri("", false, "A120WorkHourLogDuration", A120WorkHourLogDuration);
         A121WorkHourLogHour = 0;
         AssignAttri("", false, "A121WorkHourLogHour", StringUtil.LTrimStr( (decimal)(A121WorkHourLogHour), 4, 0));
         A122WorkHourLogMinute = 0;
         AssignAttri("", false, "A122WorkHourLogMinute", StringUtil.LTrimStr( (decimal)(A122WorkHourLogMinute), 4, 0));
         A123WorkHourLogDescription = "";
         AssignAttri("", false, "A123WorkHourLogDescription", A123WorkHourLogDescription);
         A107EmployeeFirstName = "";
         AssignAttri("", false, "A107EmployeeFirstName", A107EmployeeFirstName);
         A103ProjectName = "";
         AssignAttri("", false, "A103ProjectName", A103ProjectName);
         Z119WorkHourLogDate = DateTime.MinValue;
         Z120WorkHourLogDuration = "";
         Z121WorkHourLogHour = 0;
         Z122WorkHourLogMinute = 0;
         Z106EmployeeId = 0;
         Z102ProjectId = 0;
      }

      protected void InitAll0H19( )
      {
         A118WorkHourLogId = 0;
         AssignAttri("", false, "A118WorkHourLogId", StringUtil.LTrimStr( (decimal)(A118WorkHourLogId), 10, 0));
         InitializeNonKey0H19( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257120595438", true, true);
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
         context.AddJavascriptSource("workhourlog.js", "?20257120595439", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divLefttable_Internalname = "LEFTTABLE";
         edtWorkHourLogId_Internalname = "WORKHOURLOGID";
         edtWorkHourLogDate_Internalname = "WORKHOURLOGDATE";
         edtWorkHourLogDuration_Internalname = "WORKHOURLOGDURATION";
         edtWorkHourLogHour_Internalname = "WORKHOURLOGHOUR";
         edtWorkHourLogMinute_Internalname = "WORKHOURLOGMINUTE";
         edtWorkHourLogDescription_Internalname = "WORKHOURLOGDESCRIPTION";
         lblTextblockemployeeid_Internalname = "TEXTBLOCKEMPLOYEEID";
         Combo_employeeid_Internalname = "COMBO_EMPLOYEEID";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         divTablesplittedemployeeid_Internalname = "TABLESPLITTEDEMPLOYEEID";
         lblTextblockprojectid_Internalname = "TEXTBLOCKPROJECTID";
         Combo_projectid_Internalname = "COMBO_PROJECTID";
         edtProjectId_Internalname = "PROJECTID";
         divTablesplittedprojectid_Internalname = "TABLESPLITTEDPROJECTID";
         edtProjectName_Internalname = "PROJECTNAME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         divRighttable_Internalname = "RIGHTTABLE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboemployeeid_Internalname = "vCOMBOEMPLOYEEID";
         divSectionattribute_employeeid_Internalname = "SECTIONATTRIBUTE_EMPLOYEEID";
         edtavComboprojectid_Internalname = "vCOMBOPROJECTID";
         divSectionattribute_projectid_Internalname = "SECTIONATTRIBUTE_PROJECTID";
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
         Form.Caption = "Work Hour Log";
         Combo_projectid_Datalistprocparametersprefix = "";
         edtavComboprojectid_Jsonclick = "";
         edtavComboprojectid_Enabled = 0;
         edtavComboprojectid_Visible = 1;
         edtavComboemployeeid_Jsonclick = "";
         edtavComboemployeeid_Enabled = 0;
         edtavComboemployeeid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtProjectName_Jsonclick = "";
         edtProjectName_Enabled = 0;
         edtProjectId_Jsonclick = "";
         edtProjectId_Enabled = 1;
         edtProjectId_Visible = 1;
         Combo_projectid_Emptyitem = Convert.ToBoolean( 0);
         Combo_projectid_Datalistproc = "WorkHourLogLoadDVCombo";
         Combo_projectid_Cls = "ExtendedCombo Attribute";
         Combo_projectid_Caption = "";
         Combo_projectid_Enabled = Convert.ToBoolean( -1);
         edtEmployeeId_Jsonclick = "";
         edtEmployeeId_Enabled = 1;
         edtEmployeeId_Visible = 1;
         Combo_employeeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_employeeid_Datalistprocparametersprefix = " \"ComboName\": \"EmployeeId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"WorkHourLogId\": 0";
         Combo_employeeid_Datalistproc = "WorkHourLogLoadDVCombo";
         Combo_employeeid_Cls = "ExtendedCombo Attribute";
         Combo_employeeid_Caption = "";
         Combo_employeeid_Enabled = Convert.ToBoolean( -1);
         edtWorkHourLogDescription_Enabled = 1;
         edtWorkHourLogMinute_Jsonclick = "";
         edtWorkHourLogMinute_Enabled = 1;
         edtWorkHourLogHour_Jsonclick = "";
         edtWorkHourLogHour_Enabled = 1;
         edtWorkHourLogDuration_Jsonclick = "";
         edtWorkHourLogDuration_Enabled = 1;
         edtWorkHourLogDate_Jsonclick = "";
         edtWorkHourLogDate_Enabled = 1;
         edtWorkHourLogId_Jsonclick = "";
         edtWorkHourLogId_Enabled = 0;
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

      public void Valid_Employeeid( )
      {
         /* Using cursor T000H18 */
         pr_default.execute(16, new Object[] {A106EmployeeId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
         }
         A147EmployeeBalance = T000H18_A147EmployeeBalance[0];
         A107EmployeeFirstName = T000H18_A107EmployeeFirstName[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A147EmployeeBalance", StringUtil.LTrim( StringUtil.NToC( A147EmployeeBalance, 4, 1, ".", "")));
         AssignAttri("", false, "A107EmployeeFirstName", StringUtil.RTrim( A107EmployeeFirstName));
      }

      public void Valid_Projectid( )
      {
         /* Using cursor T000H19 */
         pr_default.execute(17, new Object[] {A102ProjectId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Project'.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
            GX_FocusControl = edtProjectId_Internalname;
         }
         A103ProjectName = T000H19_A103ProjectName[0];
         pr_default.close(17);
         /* Using cursor T000H21 */
         pr_default.execute(19, new Object[] {A106EmployeeId, A102ProjectId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching ''.", "ForeignKeyNotFound", 1, "PROJECTID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
         }
         pr_default.close(19);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7WorkHourLogId","fld":"vWORKHOURLOGID","pic":"ZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7WorkHourLogId","fld":"vWORKHOURLOGID","pic":"ZZZZZZZZZ9","hsh":true},{"av":"A118WorkHourLogId","fld":"WORKHOURLOGID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120H2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV11TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_WORKHOURLOGID","""{"handler":"Valid_Workhourlogid","iparms":[]}""");
         setEventMetadata("VALID_EMPLOYEEID","""{"handler":"Valid_Employeeid","iparms":[{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A147EmployeeBalance","fld":"EMPLOYEEBALANCE","pic":"Z9.9"},{"av":"A107EmployeeFirstName","fld":"EMPLOYEEFIRSTNAME"}]""");
         setEventMetadata("VALID_EMPLOYEEID",""","oparms":[{"av":"A147EmployeeBalance","fld":"EMPLOYEEBALANCE","pic":"Z9.9"},{"av":"A107EmployeeFirstName","fld":"EMPLOYEEFIRSTNAME"}]}""");
         setEventMetadata("VALID_PROJECTID","""{"handler":"Valid_Projectid","iparms":[{"av":"A102ProjectId","fld":"PROJECTID","pic":"ZZZZZZZZZ9"},{"av":"A106EmployeeId","fld":"EMPLOYEEID","pic":"ZZZZZZZZZ9"},{"av":"A103ProjectName","fld":"PROJECTNAME"}]""");
         setEventMetadata("VALID_PROJECTID",""","oparms":[{"av":"A103ProjectName","fld":"PROJECTNAME"}]}""");
         setEventMetadata("VALIDV_COMBOEMPLOYEEID","""{"handler":"Validv_Comboemployeeid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOPROJECTID","""{"handler":"Validv_Comboprojectid","iparms":[]}""");
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
         pr_default.close(16);
         pr_default.close(19);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z119WorkHourLogDate = DateTime.MinValue;
         Z120WorkHourLogDuration = "";
         Combo_projectid_Selectedvalue_get = "";
         Combo_employeeid_Selectedvalue_get = "";
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
         A119WorkHourLogDate = DateTime.MinValue;
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         lblTextblockemployeeid_Jsonclick = "";
         ucCombo_employeeid = new GXUserControl();
         AV17DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16EmployeeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockprojectid_Jsonclick = "";
         ucCombo_projectid = new GXUserControl();
         AV24ProjectId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A103ProjectName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A107EmployeeFirstName = "";
         AV27Pgmname = "";
         Combo_employeeid_Objectcall = "";
         Combo_employeeid_Class = "";
         Combo_employeeid_Icontype = "";
         Combo_employeeid_Icon = "";
         Combo_employeeid_Tooltip = "";
         Combo_employeeid_Selectedvalue_set = "";
         Combo_employeeid_Selectedtext_set = "";
         Combo_employeeid_Selectedtext_get = "";
         Combo_employeeid_Gamoauthtoken = "";
         Combo_employeeid_Ddointernalname = "";
         Combo_employeeid_Titlecontrolalign = "";
         Combo_employeeid_Dropdownoptionstype = "";
         Combo_employeeid_Titlecontrolidtoreplace = "";
         Combo_employeeid_Datalisttype = "";
         Combo_employeeid_Datalistfixedvalues = "";
         Combo_employeeid_Remoteservicesparameters = "";
         Combo_employeeid_Htmltemplate = "";
         Combo_employeeid_Multiplevaluestype = "";
         Combo_employeeid_Loadingdata = "";
         Combo_employeeid_Noresultsfound = "";
         Combo_employeeid_Emptyitemtext = "";
         Combo_employeeid_Onlyselectedvalues = "";
         Combo_employeeid_Selectalltext = "";
         Combo_employeeid_Multiplevaluesseparator = "";
         Combo_employeeid_Addnewoptiontext = "";
         Combo_projectid_Objectcall = "";
         Combo_projectid_Class = "";
         Combo_projectid_Icontype = "";
         Combo_projectid_Icon = "";
         Combo_projectid_Tooltip = "";
         Combo_projectid_Selectedvalue_set = "";
         Combo_projectid_Selectedtext_set = "";
         Combo_projectid_Selectedtext_get = "";
         Combo_projectid_Gamoauthtoken = "";
         Combo_projectid_Ddointernalname = "";
         Combo_projectid_Titlecontrolalign = "";
         Combo_projectid_Dropdownoptionstype = "";
         Combo_projectid_Titlecontrolidtoreplace = "";
         Combo_projectid_Datalisttype = "";
         Combo_projectid_Datalistfixedvalues = "";
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
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode19 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV23GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV20Combo_DataJson = "";
         AV18ComboSelectedValue = "";
         AV19ComboSelectedText = "";
         GXt_char2 = "";
         Z123WorkHourLogDescription = "";
         Z107EmployeeFirstName = "";
         Z103ProjectName = "";
         T000H4_A147EmployeeBalance = new decimal[1] ;
         T000H4_A107EmployeeFirstName = new string[] {""} ;
         T000H5_A103ProjectName = new string[] {""} ;
         T000H7_A147EmployeeBalance = new decimal[1] ;
         T000H7_A118WorkHourLogId = new long[1] ;
         T000H7_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         T000H7_A120WorkHourLogDuration = new string[] {""} ;
         T000H7_A121WorkHourLogHour = new short[1] ;
         T000H7_A122WorkHourLogMinute = new short[1] ;
         T000H7_A123WorkHourLogDescription = new string[] {""} ;
         T000H7_A107EmployeeFirstName = new string[] {""} ;
         T000H7_A103ProjectName = new string[] {""} ;
         T000H7_A106EmployeeId = new long[1] ;
         T000H7_A102ProjectId = new long[1] ;
         T000H6_A106EmployeeId = new long[1] ;
         T000H8_A147EmployeeBalance = new decimal[1] ;
         T000H8_A107EmployeeFirstName = new string[] {""} ;
         T000H9_A106EmployeeId = new long[1] ;
         T000H10_A103ProjectName = new string[] {""} ;
         T000H11_A118WorkHourLogId = new long[1] ;
         T000H3_A118WorkHourLogId = new long[1] ;
         T000H3_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         T000H3_A120WorkHourLogDuration = new string[] {""} ;
         T000H3_A121WorkHourLogHour = new short[1] ;
         T000H3_A122WorkHourLogMinute = new short[1] ;
         T000H3_A123WorkHourLogDescription = new string[] {""} ;
         T000H3_A106EmployeeId = new long[1] ;
         T000H3_A102ProjectId = new long[1] ;
         T000H12_A118WorkHourLogId = new long[1] ;
         T000H13_A118WorkHourLogId = new long[1] ;
         T000H2_A118WorkHourLogId = new long[1] ;
         T000H2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         T000H2_A120WorkHourLogDuration = new string[] {""} ;
         T000H2_A121WorkHourLogHour = new short[1] ;
         T000H2_A122WorkHourLogMinute = new short[1] ;
         T000H2_A123WorkHourLogDescription = new string[] {""} ;
         T000H2_A106EmployeeId = new long[1] ;
         T000H2_A102ProjectId = new long[1] ;
         T000H15_A118WorkHourLogId = new long[1] ;
         T000H18_A147EmployeeBalance = new decimal[1] ;
         T000H18_A107EmployeeFirstName = new string[] {""} ;
         T000H19_A103ProjectName = new string[] {""} ;
         T000H20_A118WorkHourLogId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000H21_A106EmployeeId = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workhourlog__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourlog__default(),
            new Object[][] {
                new Object[] {
               T000H2_A118WorkHourLogId, T000H2_A119WorkHourLogDate, T000H2_A120WorkHourLogDuration, T000H2_A121WorkHourLogHour, T000H2_A122WorkHourLogMinute, T000H2_A123WorkHourLogDescription, T000H2_A106EmployeeId, T000H2_A102ProjectId
               }
               , new Object[] {
               T000H3_A118WorkHourLogId, T000H3_A119WorkHourLogDate, T000H3_A120WorkHourLogDuration, T000H3_A121WorkHourLogHour, T000H3_A122WorkHourLogMinute, T000H3_A123WorkHourLogDescription, T000H3_A106EmployeeId, T000H3_A102ProjectId
               }
               , new Object[] {
               T000H4_A147EmployeeBalance, T000H4_A107EmployeeFirstName
               }
               , new Object[] {
               T000H5_A103ProjectName
               }
               , new Object[] {
               T000H6_A106EmployeeId
               }
               , new Object[] {
               T000H7_A147EmployeeBalance, T000H7_A118WorkHourLogId, T000H7_A119WorkHourLogDate, T000H7_A120WorkHourLogDuration, T000H7_A121WorkHourLogHour, T000H7_A122WorkHourLogMinute, T000H7_A123WorkHourLogDescription, T000H7_A107EmployeeFirstName, T000H7_A103ProjectName, T000H7_A106EmployeeId,
               T000H7_A102ProjectId
               }
               , new Object[] {
               T000H8_A147EmployeeBalance, T000H8_A107EmployeeFirstName
               }
               , new Object[] {
               T000H9_A106EmployeeId
               }
               , new Object[] {
               T000H10_A103ProjectName
               }
               , new Object[] {
               T000H11_A118WorkHourLogId
               }
               , new Object[] {
               T000H12_A118WorkHourLogId
               }
               , new Object[] {
               T000H13_A118WorkHourLogId
               }
               , new Object[] {
               }
               , new Object[] {
               T000H15_A118WorkHourLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000H18_A147EmployeeBalance, T000H18_A107EmployeeFirstName
               }
               , new Object[] {
               T000H19_A103ProjectName
               }
               , new Object[] {
               T000H20_A118WorkHourLogId
               }
               , new Object[] {
               T000H21_A106EmployeeId
               }
            }
         );
         AV27Pgmname = "WorkHourLog";
      }

      private short Z121WorkHourLogHour ;
      private short Z122WorkHourLogMinute ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short RcdFound19 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtWorkHourLogId_Enabled ;
      private int edtWorkHourLogDate_Enabled ;
      private int edtWorkHourLogDuration_Enabled ;
      private int edtWorkHourLogHour_Enabled ;
      private int edtWorkHourLogMinute_Enabled ;
      private int edtWorkHourLogDescription_Enabled ;
      private int edtEmployeeId_Visible ;
      private int edtEmployeeId_Enabled ;
      private int edtProjectId_Visible ;
      private int edtProjectId_Enabled ;
      private int edtProjectName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboemployeeid_Enabled ;
      private int edtavComboemployeeid_Visible ;
      private int edtavComboprojectid_Enabled ;
      private int edtavComboprojectid_Visible ;
      private int Combo_employeeid_Datalistupdateminimumcharacters ;
      private int Combo_employeeid_Gxcontroltype ;
      private int Combo_projectid_Datalistupdateminimumcharacters ;
      private int Combo_projectid_Gxcontroltype ;
      private int AV28GXV1 ;
      private int idxLst ;
      private long wcpOAV7WorkHourLogId ;
      private long Z118WorkHourLogId ;
      private long Z106EmployeeId ;
      private long Z102ProjectId ;
      private long N106EmployeeId ;
      private long N102ProjectId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long AV7WorkHourLogId ;
      private long A118WorkHourLogId ;
      private long AV21ComboEmployeeId ;
      private long AV25ComboProjectId ;
      private long AV26Cond_EmployeeId ;
      private long AV13Insert_EmployeeId ;
      private long AV14Insert_ProjectId ;
      private decimal A147EmployeeBalance ;
      private decimal Z147EmployeeBalance ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_projectid_Selectedvalue_get ;
      private string Combo_employeeid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWorkHourLogDate_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divLefttable_Internalname ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtWorkHourLogId_Internalname ;
      private string TempTags ;
      private string edtWorkHourLogId_Jsonclick ;
      private string edtWorkHourLogDate_Jsonclick ;
      private string edtWorkHourLogDuration_Internalname ;
      private string edtWorkHourLogDuration_Jsonclick ;
      private string edtWorkHourLogHour_Internalname ;
      private string edtWorkHourLogHour_Jsonclick ;
      private string edtWorkHourLogMinute_Internalname ;
      private string edtWorkHourLogMinute_Jsonclick ;
      private string edtWorkHourLogDescription_Internalname ;
      private string divTablesplittedemployeeid_Internalname ;
      private string lblTextblockemployeeid_Internalname ;
      private string lblTextblockemployeeid_Jsonclick ;
      private string Combo_employeeid_Caption ;
      private string Combo_employeeid_Cls ;
      private string Combo_employeeid_Datalistproc ;
      private string Combo_employeeid_Datalistprocparametersprefix ;
      private string Combo_employeeid_Internalname ;
      private string edtEmployeeId_Internalname ;
      private string edtEmployeeId_Jsonclick ;
      private string divTablesplittedprojectid_Internalname ;
      private string lblTextblockprojectid_Internalname ;
      private string lblTextblockprojectid_Jsonclick ;
      private string Combo_projectid_Caption ;
      private string Combo_projectid_Cls ;
      private string Combo_projectid_Datalistproc ;
      private string Combo_projectid_Internalname ;
      private string edtProjectId_Internalname ;
      private string edtProjectId_Jsonclick ;
      private string edtProjectName_Internalname ;
      private string A103ProjectName ;
      private string edtProjectName_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divRighttable_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_employeeid_Internalname ;
      private string edtavComboemployeeid_Internalname ;
      private string edtavComboemployeeid_Jsonclick ;
      private string divSectionattribute_projectid_Internalname ;
      private string edtavComboprojectid_Internalname ;
      private string edtavComboprojectid_Jsonclick ;
      private string A107EmployeeFirstName ;
      private string AV27Pgmname ;
      private string Combo_employeeid_Objectcall ;
      private string Combo_employeeid_Class ;
      private string Combo_employeeid_Icontype ;
      private string Combo_employeeid_Icon ;
      private string Combo_employeeid_Tooltip ;
      private string Combo_employeeid_Selectedvalue_set ;
      private string Combo_employeeid_Selectedtext_set ;
      private string Combo_employeeid_Selectedtext_get ;
      private string Combo_employeeid_Gamoauthtoken ;
      private string Combo_employeeid_Ddointernalname ;
      private string Combo_employeeid_Titlecontrolalign ;
      private string Combo_employeeid_Dropdownoptionstype ;
      private string Combo_employeeid_Titlecontrolidtoreplace ;
      private string Combo_employeeid_Datalisttype ;
      private string Combo_employeeid_Datalistfixedvalues ;
      private string Combo_employeeid_Remoteservicesparameters ;
      private string Combo_employeeid_Htmltemplate ;
      private string Combo_employeeid_Multiplevaluestype ;
      private string Combo_employeeid_Loadingdata ;
      private string Combo_employeeid_Noresultsfound ;
      private string Combo_employeeid_Emptyitemtext ;
      private string Combo_employeeid_Onlyselectedvalues ;
      private string Combo_employeeid_Selectalltext ;
      private string Combo_employeeid_Multiplevaluesseparator ;
      private string Combo_employeeid_Addnewoptiontext ;
      private string Combo_projectid_Objectcall ;
      private string Combo_projectid_Class ;
      private string Combo_projectid_Icontype ;
      private string Combo_projectid_Icon ;
      private string Combo_projectid_Tooltip ;
      private string Combo_projectid_Selectedvalue_set ;
      private string Combo_projectid_Selectedtext_set ;
      private string Combo_projectid_Selectedtext_get ;
      private string Combo_projectid_Gamoauthtoken ;
      private string Combo_projectid_Ddointernalname ;
      private string Combo_projectid_Titlecontrolalign ;
      private string Combo_projectid_Dropdownoptionstype ;
      private string Combo_projectid_Titlecontrolidtoreplace ;
      private string Combo_projectid_Datalisttype ;
      private string Combo_projectid_Datalistfixedvalues ;
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
      private string hsh ;
      private string sMode19 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string Z107EmployeeFirstName ;
      private string Z103ProjectName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z119WorkHourLogDate ;
      private DateTime A119WorkHourLogDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Combo_employeeid_Emptyitem ;
      private bool Combo_projectid_Emptyitem ;
      private bool Combo_employeeid_Enabled ;
      private bool Combo_employeeid_Visible ;
      private bool Combo_employeeid_Allowmultipleselection ;
      private bool Combo_employeeid_Isgriditem ;
      private bool Combo_employeeid_Hasdescription ;
      private bool Combo_employeeid_Includeonlyselectedoption ;
      private bool Combo_employeeid_Includeselectalloption ;
      private bool Combo_employeeid_Includeaddnewoption ;
      private bool Combo_projectid_Enabled ;
      private bool Combo_projectid_Visible ;
      private bool Combo_projectid_Allowmultipleselection ;
      private bool Combo_projectid_Isgriditem ;
      private bool Combo_projectid_Hasdescription ;
      private bool Combo_projectid_Includeonlyselectedoption ;
      private bool Combo_projectid_Includeselectalloption ;
      private bool Combo_projectid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A123WorkHourLogDescription ;
      private string AV20Combo_DataJson ;
      private string Z123WorkHourLogDescription ;
      private string Z120WorkHourLogDuration ;
      private string A120WorkHourLogDuration ;
      private string AV18ComboSelectedValue ;
      private string AV19ComboSelectedText ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucCombo_employeeid ;
      private GXUserControl ucCombo_projectid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV17DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV16EmployeeId_Data ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV24ProjectId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000H4_A147EmployeeBalance ;
      private string[] T000H4_A107EmployeeFirstName ;
      private string[] T000H5_A103ProjectName ;
      private decimal[] T000H7_A147EmployeeBalance ;
      private long[] T000H7_A118WorkHourLogId ;
      private DateTime[] T000H7_A119WorkHourLogDate ;
      private string[] T000H7_A120WorkHourLogDuration ;
      private short[] T000H7_A121WorkHourLogHour ;
      private short[] T000H7_A122WorkHourLogMinute ;
      private string[] T000H7_A123WorkHourLogDescription ;
      private string[] T000H7_A107EmployeeFirstName ;
      private string[] T000H7_A103ProjectName ;
      private long[] T000H7_A106EmployeeId ;
      private long[] T000H7_A102ProjectId ;
      private long[] T000H6_A106EmployeeId ;
      private decimal[] T000H8_A147EmployeeBalance ;
      private string[] T000H8_A107EmployeeFirstName ;
      private long[] T000H9_A106EmployeeId ;
      private string[] T000H10_A103ProjectName ;
      private long[] T000H11_A118WorkHourLogId ;
      private long[] T000H3_A118WorkHourLogId ;
      private DateTime[] T000H3_A119WorkHourLogDate ;
      private string[] T000H3_A120WorkHourLogDuration ;
      private short[] T000H3_A121WorkHourLogHour ;
      private short[] T000H3_A122WorkHourLogMinute ;
      private string[] T000H3_A123WorkHourLogDescription ;
      private long[] T000H3_A106EmployeeId ;
      private long[] T000H3_A102ProjectId ;
      private long[] T000H12_A118WorkHourLogId ;
      private long[] T000H13_A118WorkHourLogId ;
      private long[] T000H2_A118WorkHourLogId ;
      private DateTime[] T000H2_A119WorkHourLogDate ;
      private string[] T000H2_A120WorkHourLogDuration ;
      private short[] T000H2_A121WorkHourLogHour ;
      private short[] T000H2_A122WorkHourLogMinute ;
      private string[] T000H2_A123WorkHourLogDescription ;
      private long[] T000H2_A106EmployeeId ;
      private long[] T000H2_A102ProjectId ;
      private long[] T000H15_A118WorkHourLogId ;
      private decimal[] T000H18_A147EmployeeBalance ;
      private string[] T000H18_A107EmployeeFirstName ;
      private string[] T000H19_A103ProjectName ;
      private long[] T000H20_A118WorkHourLogId ;
      private long[] T000H21_A106EmployeeId ;
      private IDataStoreProvider pr_gam ;
   }

   public class workhourlog__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class workhourlog__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
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
        Object[] prmT000H2;
        prmT000H2 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmT000H3;
        prmT000H3 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmT000H4;
        prmT000H4 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000H5;
        prmT000H5 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000H6;
        prmT000H6 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000H7;
        prmT000H7 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmT000H8;
        prmT000H8 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000H9;
        prmT000H9 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000H10;
        prmT000H10 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000H11;
        prmT000H11 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmT000H12;
        prmT000H12 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmT000H13;
        prmT000H13 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmT000H14;
        prmT000H14 = new Object[] {
        new ParDef("WorkHourLogDate",GXType.Date,8,0) ,
        new ParDef("WorkHourLogDuration",GXType.VarChar,40,3) ,
        new ParDef("WorkHourLogHour",GXType.Int16,4,0) ,
        new ParDef("WorkHourLogMinute",GXType.Int16,4,0) ,
        new ParDef("WorkHourLogDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000H15;
        prmT000H15 = new Object[] {
        };
        Object[] prmT000H16;
        prmT000H16 = new Object[] {
        new ParDef("WorkHourLogDate",GXType.Date,8,0) ,
        new ParDef("WorkHourLogDuration",GXType.VarChar,40,3) ,
        new ParDef("WorkHourLogHour",GXType.Int16,4,0) ,
        new ParDef("WorkHourLogMinute",GXType.Int16,4,0) ,
        new ParDef("WorkHourLogDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0) ,
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmT000H17;
        prmT000H17 = new Object[] {
        new ParDef("WorkHourLogId",GXType.Int64,10,0)
        };
        Object[] prmT000H18;
        prmT000H18 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmT000H19;
        prmT000H19 = new Object[] {
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        Object[] prmT000H20;
        prmT000H20 = new Object[] {
        };
        Object[] prmT000H21;
        prmT000H21 = new Object[] {
        new ParDef("EmployeeId",GXType.Int64,10,0) ,
        new ParDef("ProjectId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000H2", "SELECT WorkHourLogId, WorkHourLogDate, WorkHourLogDuration, WorkHourLogHour, WorkHourLogMinute, WorkHourLogDescription, EmployeeId, ProjectId FROM WorkHourLog WHERE WorkHourLogId = :WorkHourLogId  FOR UPDATE OF WorkHourLog NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H3", "SELECT WorkHourLogId, WorkHourLogDate, WorkHourLogDuration, WorkHourLogHour, WorkHourLogMinute, WorkHourLogDescription, EmployeeId, ProjectId FROM WorkHourLog WHERE WorkHourLogId = :WorkHourLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H4", "SELECT EmployeeBalance, EmployeeFirstName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H5", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H6", "SELECT EmployeeId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H7", "SELECT T2.EmployeeBalance, TM1.WorkHourLogId, TM1.WorkHourLogDate, TM1.WorkHourLogDuration, TM1.WorkHourLogHour, TM1.WorkHourLogMinute, TM1.WorkHourLogDescription, T2.EmployeeFirstName, T3.ProjectName, TM1.EmployeeId, TM1.ProjectId FROM ((WorkHourLog TM1 INNER JOIN Employee T2 ON T2.EmployeeId = TM1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = TM1.ProjectId) WHERE TM1.WorkHourLogId = :WorkHourLogId ORDER BY TM1.WorkHourLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H8", "SELECT EmployeeBalance, EmployeeFirstName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H9", "SELECT EmployeeId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H10", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H11", "SELECT WorkHourLogId FROM WorkHourLog WHERE WorkHourLogId = :WorkHourLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H12", "SELECT WorkHourLogId FROM WorkHourLog WHERE ( WorkHourLogId > :WorkHourLogId) ORDER BY WorkHourLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H13", "SELECT WorkHourLogId FROM WorkHourLog WHERE ( WorkHourLogId < :WorkHourLogId) ORDER BY WorkHourLogId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H14", "SAVEPOINT gxupdate;INSERT INTO WorkHourLog(WorkHourLogDate, WorkHourLogDuration, WorkHourLogHour, WorkHourLogMinute, WorkHourLogDescription, EmployeeId, ProjectId) VALUES(:WorkHourLogDate, :WorkHourLogDuration, :WorkHourLogHour, :WorkHourLogMinute, :WorkHourLogDescription, :EmployeeId, :ProjectId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000H14)
           ,new CursorDef("T000H15", "SELECT currval('WorkHourLogId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H16", "SAVEPOINT gxupdate;UPDATE WorkHourLog SET WorkHourLogDate=:WorkHourLogDate, WorkHourLogDuration=:WorkHourLogDuration, WorkHourLogHour=:WorkHourLogHour, WorkHourLogMinute=:WorkHourLogMinute, WorkHourLogDescription=:WorkHourLogDescription, EmployeeId=:EmployeeId, ProjectId=:ProjectId  WHERE WorkHourLogId = :WorkHourLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000H16)
           ,new CursorDef("T000H17", "SAVEPOINT gxupdate;DELETE FROM WorkHourLog  WHERE WorkHourLogId = :WorkHourLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000H17)
           ,new CursorDef("T000H18", "SELECT EmployeeBalance, EmployeeFirstName FROM Employee WHERE EmployeeId = :EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H19", "SELECT ProjectName FROM Project WHERE ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H20", "SELECT WorkHourLogId FROM WorkHourLog ORDER BY WorkHourLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H21", "SELECT EmployeeId FROM EmployeeProject WHERE EmployeeId = :EmployeeId AND ProjectId = :ProjectId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H21,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              return;
           case 2 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((string[]) buf[8])[0] = rslt.getString(9, 100);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
