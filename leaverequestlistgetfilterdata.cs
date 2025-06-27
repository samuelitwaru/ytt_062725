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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class leaverequestlistgetfilterdata : GXProcedure
   {
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
            return "leaverequestlist_Services_Execute" ;
         }

      }

      public leaverequestlistgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestlistgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV50OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV35Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32MaxItems = 10;
         AV31PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV46SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV29SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? "" : StringUtil.Substring( AV46SearchTxtParms, 3, -1));
         AV30SkipItems = (short)(AV31PageIndex*AV32MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_LEAVETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_LEAVEREQUESTHALFDAY") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTHALFDAYOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_LEAVEREQUESTDESCRIPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTDESCRIPTIONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV48OptionsJson = AV35Options.ToJSonString(false);
         AV49OptionsDescJson = AV37OptionsDesc.ToJSonString(false);
         AV50OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get("LeaveRequestListGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "LeaveRequestListGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("LeaveRequestListGridState"), null, "", "");
         }
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV11TFLeaveTypeName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV12TFLeaveTypeName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV13TFEmployeeName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV14TFEmployeeName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV15TFLeaveRequestStartDate = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Value, 2);
               AV16TFLeaveRequestStartDate_To = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV17TFLeaveRequestEndDate = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Value, 2);
               AV18TFLeaveRequestEndDate_To = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV19TFLeaveRequestHalfDay = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV20TFLeaveRequestHalfDay_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV21TFLeaveRequestDuration = NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, ".");
               AV22TFLeaveRequestDuration_To = NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION") == 0 )
            {
               AV25TFLeaveRequestDescription = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION_SEL") == 0 )
            {
               AV26TFLeaveRequestDescription_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "PARM_&LEAVETYPEID") == 0 )
            {
               AV52LeaveTypeId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "PARM_&EMPLOYEEID") == 0 )
            {
               AV53EmployeeId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "PARM_&FROMDATE") == 0 )
            {
               AV54FromDate = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Value, 2);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "PARM_&TODATE") == 0 )
            {
               AV55ToDate = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Value, 2);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "PARM_&COMPANYLOCATIONID") == 0 )
            {
               AV56CompanyLocationId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFLeaveTypeName = AV29SearchTxt;
         AV12TFLeaveTypeName_Sel = "";
         AV59Leaverequestlistds_1_filterfulltext = AV51FilterFullText;
         AV60Leaverequestlistds_2_tfleavetypename = AV11TFLeaveTypeName;
         AV61Leaverequestlistds_3_tfleavetypename_sel = AV12TFLeaveTypeName_Sel;
         AV62Leaverequestlistds_4_tfemployeename = AV13TFEmployeeName;
         AV63Leaverequestlistds_5_tfemployeename_sel = AV14TFEmployeeName_Sel;
         AV64Leaverequestlistds_6_tfleaverequeststartdate = AV15TFLeaveRequestStartDate;
         AV65Leaverequestlistds_7_tfleaverequeststartdate_to = AV16TFLeaveRequestStartDate_To;
         AV66Leaverequestlistds_8_tfleaverequestenddate = AV17TFLeaveRequestEndDate;
         AV67Leaverequestlistds_9_tfleaverequestenddate_to = AV18TFLeaveRequestEndDate_To;
         AV68Leaverequestlistds_10_tfleaverequesthalfday = AV19TFLeaveRequestHalfDay;
         AV69Leaverequestlistds_11_tfleaverequesthalfday_sel = AV20TFLeaveRequestHalfDay_Sel;
         AV70Leaverequestlistds_12_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV71Leaverequestlistds_13_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV72Leaverequestlistds_14_tfleaverequestdescription = AV25TFLeaveRequestDescription;
         AV73Leaverequestlistds_15_tfleaverequestdescription_sel = AV26TFLeaveRequestDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV59Leaverequestlistds_1_filterfulltext ,
                                              AV61Leaverequestlistds_3_tfleavetypename_sel ,
                                              AV60Leaverequestlistds_2_tfleavetypename ,
                                              AV63Leaverequestlistds_5_tfemployeename_sel ,
                                              AV62Leaverequestlistds_4_tfemployeename ,
                                              AV64Leaverequestlistds_6_tfleaverequeststartdate ,
                                              AV65Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                              AV66Leaverequestlistds_8_tfleaverequestenddate ,
                                              AV67Leaverequestlistds_9_tfleaverequestenddate_to ,
                                              AV69Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                              AV68Leaverequestlistds_10_tfleaverequesthalfday ,
                                              AV70Leaverequestlistds_12_tfleaverequestduration ,
                                              AV71Leaverequestlistds_13_tfleaverequestduration_to ,
                                              AV73Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                              AV72Leaverequestlistds_14_tfleaverequestdescription ,
                                              AV52LeaveTypeId ,
                                              AV53EmployeeId ,
                                              A125LeaveTypeName ,
                                              A148EmployeeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A124LeaveTypeId ,
                                              A106EmployeeId ,
                                              AV55ToDate ,
                                              AV54FromDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV60Leaverequestlistds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV60Leaverequestlistds_2_tfleavetypename), 100, "%");
         lV62Leaverequestlistds_4_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV62Leaverequestlistds_4_tfemployeename), 100, "%");
         lV68Leaverequestlistds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV68Leaverequestlistds_10_tfleaverequesthalfday), 20, "%");
         lV72Leaverequestlistds_14_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV72Leaverequestlistds_14_tfleaverequestdescription), "%", "");
         /* Using cursor P00AT2 */
         pr_default.execute(0, new Object[] {AV55ToDate, AV54FromDate, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV60Leaverequestlistds_2_tfleavetypename, AV61Leaverequestlistds_3_tfleavetypename_sel, lV62Leaverequestlistds_4_tfemployeename, AV63Leaverequestlistds_5_tfemployeename_sel, AV64Leaverequestlistds_6_tfleaverequeststartdate, AV65Leaverequestlistds_7_tfleaverequeststartdate_to, AV66Leaverequestlistds_8_tfleaverequestenddate, AV67Leaverequestlistds_9_tfleaverequestenddate_to, lV68Leaverequestlistds_10_tfleaverequesthalfday, AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, AV70Leaverequestlistds_12_tfleaverequestduration, AV71Leaverequestlistds_13_tfleaverequestduration_to, lV72Leaverequestlistds_14_tfleaverequestdescription, AV73Leaverequestlistds_15_tfleaverequestdescription_sel, AV52LeaveTypeId, AV53EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAT2 = false;
            A124LeaveTypeId = P00AT2_A124LeaveTypeId[0];
            A106EmployeeId = P00AT2_A106EmployeeId[0];
            A131LeaveRequestDuration = P00AT2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00AT2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00AT2_A129LeaveRequestStartDate[0];
            A133LeaveRequestDescription = P00AT2_A133LeaveRequestDescription[0];
            A171LeaveRequestHalfDay = P00AT2_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00AT2_n171LeaveRequestHalfDay[0];
            A148EmployeeName = P00AT2_A148EmployeeName[0];
            A125LeaveTypeName = P00AT2_A125LeaveTypeName[0];
            A127LeaveRequestId = P00AT2_A127LeaveRequestId[0];
            A125LeaveTypeName = P00AT2_A125LeaveTypeName[0];
            A148EmployeeName = P00AT2_A148EmployeeName[0];
            AV39count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00AT2_A124LeaveTypeId[0] == A124LeaveTypeId ) )
            {
               BRKAT2 = false;
               A127LeaveRequestId = P00AT2_A127LeaveRequestId[0];
               AV39count = (long)(AV39count+1);
               BRKAT2 = true;
               pr_default.readNext(0);
            }
            AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) ? "<#Empty#>" : A125LeaveTypeName);
            AV33InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV34Option, "<#Empty#>") != 0 ) && ( AV33InsertIndex <= AV35Options.Count ) && ( ( StringUtil.StrCmp(((string)AV35Options.Item(AV33InsertIndex)), AV34Option) < 0 ) || ( StringUtil.StrCmp(((string)AV35Options.Item(AV33InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV33InsertIndex = (int)(AV33InsertIndex+1);
            }
            AV35Options.Add(AV34Option, AV33InsertIndex);
            AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), AV33InsertIndex);
            if ( AV35Options.Count == AV30SkipItems + 11 )
            {
               AV35Options.RemoveItem(AV35Options.Count);
               AV38OptionIndexes.RemoveItem(AV38OptionIndexes.Count);
            }
            if ( ! BRKAT2 )
            {
               BRKAT2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV30SkipItems > 0 )
         {
            AV35Options.RemoveItem(1);
            AV38OptionIndexes.RemoveItem(1);
            AV30SkipItems = (short)(AV30SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFEmployeeName = AV29SearchTxt;
         AV14TFEmployeeName_Sel = "";
         AV59Leaverequestlistds_1_filterfulltext = AV51FilterFullText;
         AV60Leaverequestlistds_2_tfleavetypename = AV11TFLeaveTypeName;
         AV61Leaverequestlistds_3_tfleavetypename_sel = AV12TFLeaveTypeName_Sel;
         AV62Leaverequestlistds_4_tfemployeename = AV13TFEmployeeName;
         AV63Leaverequestlistds_5_tfemployeename_sel = AV14TFEmployeeName_Sel;
         AV64Leaverequestlistds_6_tfleaverequeststartdate = AV15TFLeaveRequestStartDate;
         AV65Leaverequestlistds_7_tfleaverequeststartdate_to = AV16TFLeaveRequestStartDate_To;
         AV66Leaverequestlistds_8_tfleaverequestenddate = AV17TFLeaveRequestEndDate;
         AV67Leaverequestlistds_9_tfleaverequestenddate_to = AV18TFLeaveRequestEndDate_To;
         AV68Leaverequestlistds_10_tfleaverequesthalfday = AV19TFLeaveRequestHalfDay;
         AV69Leaverequestlistds_11_tfleaverequesthalfday_sel = AV20TFLeaveRequestHalfDay_Sel;
         AV70Leaverequestlistds_12_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV71Leaverequestlistds_13_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV72Leaverequestlistds_14_tfleaverequestdescription = AV25TFLeaveRequestDescription;
         AV73Leaverequestlistds_15_tfleaverequestdescription_sel = AV26TFLeaveRequestDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV59Leaverequestlistds_1_filterfulltext ,
                                              AV61Leaverequestlistds_3_tfleavetypename_sel ,
                                              AV60Leaverequestlistds_2_tfleavetypename ,
                                              AV63Leaverequestlistds_5_tfemployeename_sel ,
                                              AV62Leaverequestlistds_4_tfemployeename ,
                                              AV64Leaverequestlistds_6_tfleaverequeststartdate ,
                                              AV65Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                              AV66Leaverequestlistds_8_tfleaverequestenddate ,
                                              AV67Leaverequestlistds_9_tfleaverequestenddate_to ,
                                              AV69Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                              AV68Leaverequestlistds_10_tfleaverequesthalfday ,
                                              AV70Leaverequestlistds_12_tfleaverequestduration ,
                                              AV71Leaverequestlistds_13_tfleaverequestduration_to ,
                                              AV73Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                              AV72Leaverequestlistds_14_tfleaverequestdescription ,
                                              AV52LeaveTypeId ,
                                              AV53EmployeeId ,
                                              A125LeaveTypeName ,
                                              A148EmployeeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A124LeaveTypeId ,
                                              A106EmployeeId ,
                                              AV55ToDate ,
                                              AV54FromDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV60Leaverequestlistds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV60Leaverequestlistds_2_tfleavetypename), 100, "%");
         lV62Leaverequestlistds_4_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV62Leaverequestlistds_4_tfemployeename), 100, "%");
         lV68Leaverequestlistds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV68Leaverequestlistds_10_tfleaverequesthalfday), 20, "%");
         lV72Leaverequestlistds_14_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV72Leaverequestlistds_14_tfleaverequestdescription), "%", "");
         /* Using cursor P00AT3 */
         pr_default.execute(1, new Object[] {AV55ToDate, AV54FromDate, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV60Leaverequestlistds_2_tfleavetypename, AV61Leaverequestlistds_3_tfleavetypename_sel, lV62Leaverequestlistds_4_tfemployeename, AV63Leaverequestlistds_5_tfemployeename_sel, AV64Leaverequestlistds_6_tfleaverequeststartdate, AV65Leaverequestlistds_7_tfleaverequeststartdate_to, AV66Leaverequestlistds_8_tfleaverequestenddate, AV67Leaverequestlistds_9_tfleaverequestenddate_to, lV68Leaverequestlistds_10_tfleaverequesthalfday, AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, AV70Leaverequestlistds_12_tfleaverequestduration, AV71Leaverequestlistds_13_tfleaverequestduration_to, lV72Leaverequestlistds_14_tfleaverequestdescription, AV73Leaverequestlistds_15_tfleaverequestdescription_sel, AV52LeaveTypeId, AV53EmployeeId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAT4 = false;
            A148EmployeeName = P00AT3_A148EmployeeName[0];
            A106EmployeeId = P00AT3_A106EmployeeId[0];
            A124LeaveTypeId = P00AT3_A124LeaveTypeId[0];
            A131LeaveRequestDuration = P00AT3_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00AT3_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00AT3_A129LeaveRequestStartDate[0];
            A133LeaveRequestDescription = P00AT3_A133LeaveRequestDescription[0];
            A171LeaveRequestHalfDay = P00AT3_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00AT3_n171LeaveRequestHalfDay[0];
            A125LeaveTypeName = P00AT3_A125LeaveTypeName[0];
            A127LeaveRequestId = P00AT3_A127LeaveRequestId[0];
            A148EmployeeName = P00AT3_A148EmployeeName[0];
            A125LeaveTypeName = P00AT3_A125LeaveTypeName[0];
            AV39count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AT3_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRKAT4 = false;
               A106EmployeeId = P00AT3_A106EmployeeId[0];
               A127LeaveRequestId = P00AT3_A127LeaveRequestId[0];
               AV39count = (long)(AV39count+1);
               BRKAT4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148EmployeeName)) ? "<#Empty#>" : A148EmployeeName);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRKAT4 )
            {
               BRKAT4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADLEAVEREQUESTHALFDAYOPTIONS' Routine */
         returnInSub = false;
         AV19TFLeaveRequestHalfDay = AV29SearchTxt;
         AV20TFLeaveRequestHalfDay_Sel = "";
         AV59Leaverequestlistds_1_filterfulltext = AV51FilterFullText;
         AV60Leaverequestlistds_2_tfleavetypename = AV11TFLeaveTypeName;
         AV61Leaverequestlistds_3_tfleavetypename_sel = AV12TFLeaveTypeName_Sel;
         AV62Leaverequestlistds_4_tfemployeename = AV13TFEmployeeName;
         AV63Leaverequestlistds_5_tfemployeename_sel = AV14TFEmployeeName_Sel;
         AV64Leaverequestlistds_6_tfleaverequeststartdate = AV15TFLeaveRequestStartDate;
         AV65Leaverequestlistds_7_tfleaverequeststartdate_to = AV16TFLeaveRequestStartDate_To;
         AV66Leaverequestlistds_8_tfleaverequestenddate = AV17TFLeaveRequestEndDate;
         AV67Leaverequestlistds_9_tfleaverequestenddate_to = AV18TFLeaveRequestEndDate_To;
         AV68Leaverequestlistds_10_tfleaverequesthalfday = AV19TFLeaveRequestHalfDay;
         AV69Leaverequestlistds_11_tfleaverequesthalfday_sel = AV20TFLeaveRequestHalfDay_Sel;
         AV70Leaverequestlistds_12_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV71Leaverequestlistds_13_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV72Leaverequestlistds_14_tfleaverequestdescription = AV25TFLeaveRequestDescription;
         AV73Leaverequestlistds_15_tfleaverequestdescription_sel = AV26TFLeaveRequestDescription_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV59Leaverequestlistds_1_filterfulltext ,
                                              AV61Leaverequestlistds_3_tfleavetypename_sel ,
                                              AV60Leaverequestlistds_2_tfleavetypename ,
                                              AV63Leaverequestlistds_5_tfemployeename_sel ,
                                              AV62Leaverequestlistds_4_tfemployeename ,
                                              AV64Leaverequestlistds_6_tfleaverequeststartdate ,
                                              AV65Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                              AV66Leaverequestlistds_8_tfleaverequestenddate ,
                                              AV67Leaverequestlistds_9_tfleaverequestenddate_to ,
                                              AV69Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                              AV68Leaverequestlistds_10_tfleaverequesthalfday ,
                                              AV70Leaverequestlistds_12_tfleaverequestduration ,
                                              AV71Leaverequestlistds_13_tfleaverequestduration_to ,
                                              AV73Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                              AV72Leaverequestlistds_14_tfleaverequestdescription ,
                                              AV52LeaveTypeId ,
                                              AV53EmployeeId ,
                                              A125LeaveTypeName ,
                                              A148EmployeeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A124LeaveTypeId ,
                                              A106EmployeeId ,
                                              AV55ToDate ,
                                              AV54FromDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV60Leaverequestlistds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV60Leaverequestlistds_2_tfleavetypename), 100, "%");
         lV62Leaverequestlistds_4_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV62Leaverequestlistds_4_tfemployeename), 100, "%");
         lV68Leaverequestlistds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV68Leaverequestlistds_10_tfleaverequesthalfday), 20, "%");
         lV72Leaverequestlistds_14_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV72Leaverequestlistds_14_tfleaverequestdescription), "%", "");
         /* Using cursor P00AT4 */
         pr_default.execute(2, new Object[] {AV55ToDate, AV54FromDate, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV60Leaverequestlistds_2_tfleavetypename, AV61Leaverequestlistds_3_tfleavetypename_sel, lV62Leaverequestlistds_4_tfemployeename, AV63Leaverequestlistds_5_tfemployeename_sel, AV64Leaverequestlistds_6_tfleaverequeststartdate, AV65Leaverequestlistds_7_tfleaverequeststartdate_to, AV66Leaverequestlistds_8_tfleaverequestenddate, AV67Leaverequestlistds_9_tfleaverequestenddate_to, lV68Leaverequestlistds_10_tfleaverequesthalfday, AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, AV70Leaverequestlistds_12_tfleaverequestduration, AV71Leaverequestlistds_13_tfleaverequestduration_to, lV72Leaverequestlistds_14_tfleaverequestdescription, AV73Leaverequestlistds_15_tfleaverequestdescription_sel, AV52LeaveTypeId, AV53EmployeeId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAT6 = false;
            A171LeaveRequestHalfDay = P00AT4_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00AT4_n171LeaveRequestHalfDay[0];
            A106EmployeeId = P00AT4_A106EmployeeId[0];
            A124LeaveTypeId = P00AT4_A124LeaveTypeId[0];
            A131LeaveRequestDuration = P00AT4_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00AT4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00AT4_A129LeaveRequestStartDate[0];
            A133LeaveRequestDescription = P00AT4_A133LeaveRequestDescription[0];
            A148EmployeeName = P00AT4_A148EmployeeName[0];
            A125LeaveTypeName = P00AT4_A125LeaveTypeName[0];
            A127LeaveRequestId = P00AT4_A127LeaveRequestId[0];
            A148EmployeeName = P00AT4_A148EmployeeName[0];
            A125LeaveTypeName = P00AT4_A125LeaveTypeName[0];
            AV39count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00AT4_A171LeaveRequestHalfDay[0], A171LeaveRequestHalfDay) == 0 ) )
            {
               BRKAT6 = false;
               A127LeaveRequestId = P00AT4_A127LeaveRequestId[0];
               AV39count = (long)(AV39count+1);
               BRKAT6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A171LeaveRequestHalfDay)) ? "<#Empty#>" : A171LeaveRequestHalfDay);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRKAT6 )
            {
               BRKAT6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADLEAVEREQUESTDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV25TFLeaveRequestDescription = AV29SearchTxt;
         AV26TFLeaveRequestDescription_Sel = "";
         AV59Leaverequestlistds_1_filterfulltext = AV51FilterFullText;
         AV60Leaverequestlistds_2_tfleavetypename = AV11TFLeaveTypeName;
         AV61Leaverequestlistds_3_tfleavetypename_sel = AV12TFLeaveTypeName_Sel;
         AV62Leaverequestlistds_4_tfemployeename = AV13TFEmployeeName;
         AV63Leaverequestlistds_5_tfemployeename_sel = AV14TFEmployeeName_Sel;
         AV64Leaverequestlistds_6_tfleaverequeststartdate = AV15TFLeaveRequestStartDate;
         AV65Leaverequestlistds_7_tfleaverequeststartdate_to = AV16TFLeaveRequestStartDate_To;
         AV66Leaverequestlistds_8_tfleaverequestenddate = AV17TFLeaveRequestEndDate;
         AV67Leaverequestlistds_9_tfleaverequestenddate_to = AV18TFLeaveRequestEndDate_To;
         AV68Leaverequestlistds_10_tfleaverequesthalfday = AV19TFLeaveRequestHalfDay;
         AV69Leaverequestlistds_11_tfleaverequesthalfday_sel = AV20TFLeaveRequestHalfDay_Sel;
         AV70Leaverequestlistds_12_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV71Leaverequestlistds_13_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV72Leaverequestlistds_14_tfleaverequestdescription = AV25TFLeaveRequestDescription;
         AV73Leaverequestlistds_15_tfleaverequestdescription_sel = AV26TFLeaveRequestDescription_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV59Leaverequestlistds_1_filterfulltext ,
                                              AV61Leaverequestlistds_3_tfleavetypename_sel ,
                                              AV60Leaverequestlistds_2_tfleavetypename ,
                                              AV63Leaverequestlistds_5_tfemployeename_sel ,
                                              AV62Leaverequestlistds_4_tfemployeename ,
                                              AV64Leaverequestlistds_6_tfleaverequeststartdate ,
                                              AV65Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                              AV66Leaverequestlistds_8_tfleaverequestenddate ,
                                              AV67Leaverequestlistds_9_tfleaverequestenddate_to ,
                                              AV69Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                              AV68Leaverequestlistds_10_tfleaverequesthalfday ,
                                              AV70Leaverequestlistds_12_tfleaverequestduration ,
                                              AV71Leaverequestlistds_13_tfleaverequestduration_to ,
                                              AV73Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                              AV72Leaverequestlistds_14_tfleaverequestdescription ,
                                              AV52LeaveTypeId ,
                                              AV53EmployeeId ,
                                              A125LeaveTypeName ,
                                              A148EmployeeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A124LeaveTypeId ,
                                              A106EmployeeId ,
                                              AV55ToDate ,
                                              AV54FromDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV59Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext), "%", "");
         lV60Leaverequestlistds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV60Leaverequestlistds_2_tfleavetypename), 100, "%");
         lV62Leaverequestlistds_4_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV62Leaverequestlistds_4_tfemployeename), 100, "%");
         lV68Leaverequestlistds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV68Leaverequestlistds_10_tfleaverequesthalfday), 20, "%");
         lV72Leaverequestlistds_14_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV72Leaverequestlistds_14_tfleaverequestdescription), "%", "");
         /* Using cursor P00AT5 */
         pr_default.execute(3, new Object[] {AV55ToDate, AV54FromDate, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV59Leaverequestlistds_1_filterfulltext, lV60Leaverequestlistds_2_tfleavetypename, AV61Leaverequestlistds_3_tfleavetypename_sel, lV62Leaverequestlistds_4_tfemployeename, AV63Leaverequestlistds_5_tfemployeename_sel, AV64Leaverequestlistds_6_tfleaverequeststartdate, AV65Leaverequestlistds_7_tfleaverequeststartdate_to, AV66Leaverequestlistds_8_tfleaverequestenddate, AV67Leaverequestlistds_9_tfleaverequestenddate_to, lV68Leaverequestlistds_10_tfleaverequesthalfday, AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, AV70Leaverequestlistds_12_tfleaverequestduration, AV71Leaverequestlistds_13_tfleaverequestduration_to, lV72Leaverequestlistds_14_tfleaverequestdescription, AV73Leaverequestlistds_15_tfleaverequestdescription_sel, AV52LeaveTypeId, AV53EmployeeId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKAT8 = false;
            A133LeaveRequestDescription = P00AT5_A133LeaveRequestDescription[0];
            A106EmployeeId = P00AT5_A106EmployeeId[0];
            A124LeaveTypeId = P00AT5_A124LeaveTypeId[0];
            A131LeaveRequestDuration = P00AT5_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00AT5_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00AT5_A129LeaveRequestStartDate[0];
            A171LeaveRequestHalfDay = P00AT5_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00AT5_n171LeaveRequestHalfDay[0];
            A148EmployeeName = P00AT5_A148EmployeeName[0];
            A125LeaveTypeName = P00AT5_A125LeaveTypeName[0];
            A127LeaveRequestId = P00AT5_A127LeaveRequestId[0];
            A148EmployeeName = P00AT5_A148EmployeeName[0];
            A125LeaveTypeName = P00AT5_A125LeaveTypeName[0];
            AV39count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00AT5_A133LeaveRequestDescription[0], A133LeaveRequestDescription) == 0 ) )
            {
               BRKAT8 = false;
               A127LeaveRequestId = P00AT5_A127LeaveRequestId[0];
               AV39count = (long)(AV39count+1);
               BRKAT8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A133LeaveRequestDescription)) ? "<#Empty#>" : A133LeaveRequestDescription);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRKAT8 )
            {
               BRKAT8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV48OptionsJson = "";
         AV49OptionsDescJson = "";
         AV50OptionIndexesJson = "";
         AV35Options = new GxSimpleCollection<string>();
         AV37OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV29SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV42GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV43GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV51FilterFullText = "";
         AV11TFLeaveTypeName = "";
         AV12TFLeaveTypeName_Sel = "";
         AV13TFEmployeeName = "";
         AV14TFEmployeeName_Sel = "";
         AV15TFLeaveRequestStartDate = DateTime.MinValue;
         AV16TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV17TFLeaveRequestEndDate = DateTime.MinValue;
         AV18TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV19TFLeaveRequestHalfDay = "";
         AV20TFLeaveRequestHalfDay_Sel = "";
         AV25TFLeaveRequestDescription = "";
         AV26TFLeaveRequestDescription_Sel = "";
         AV54FromDate = DateTime.MinValue;
         AV55ToDate = DateTime.MinValue;
         AV59Leaverequestlistds_1_filterfulltext = "";
         AV60Leaverequestlistds_2_tfleavetypename = "";
         AV61Leaverequestlistds_3_tfleavetypename_sel = "";
         AV62Leaverequestlistds_4_tfemployeename = "";
         AV63Leaverequestlistds_5_tfemployeename_sel = "";
         AV64Leaverequestlistds_6_tfleaverequeststartdate = DateTime.MinValue;
         AV65Leaverequestlistds_7_tfleaverequeststartdate_to = DateTime.MinValue;
         AV66Leaverequestlistds_8_tfleaverequestenddate = DateTime.MinValue;
         AV67Leaverequestlistds_9_tfleaverequestenddate_to = DateTime.MinValue;
         AV68Leaverequestlistds_10_tfleaverequesthalfday = "";
         AV69Leaverequestlistds_11_tfleaverequesthalfday_sel = "";
         AV72Leaverequestlistds_14_tfleaverequestdescription = "";
         AV73Leaverequestlistds_15_tfleaverequestdescription_sel = "";
         lV59Leaverequestlistds_1_filterfulltext = "";
         lV60Leaverequestlistds_2_tfleavetypename = "";
         lV62Leaverequestlistds_4_tfemployeename = "";
         lV68Leaverequestlistds_10_tfleaverequesthalfday = "";
         lV72Leaverequestlistds_14_tfleaverequestdescription = "";
         A125LeaveTypeName = "";
         A148EmployeeName = "";
         A171LeaveRequestHalfDay = "";
         A133LeaveRequestDescription = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         P00AT2_A124LeaveTypeId = new long[1] ;
         P00AT2_A106EmployeeId = new long[1] ;
         P00AT2_A131LeaveRequestDuration = new decimal[1] ;
         P00AT2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AT2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AT2_A133LeaveRequestDescription = new string[] {""} ;
         P00AT2_A171LeaveRequestHalfDay = new string[] {""} ;
         P00AT2_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00AT2_A148EmployeeName = new string[] {""} ;
         P00AT2_A125LeaveTypeName = new string[] {""} ;
         P00AT2_A127LeaveRequestId = new long[1] ;
         AV34Option = "";
         P00AT3_A148EmployeeName = new string[] {""} ;
         P00AT3_A106EmployeeId = new long[1] ;
         P00AT3_A124LeaveTypeId = new long[1] ;
         P00AT3_A131LeaveRequestDuration = new decimal[1] ;
         P00AT3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AT3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AT3_A133LeaveRequestDescription = new string[] {""} ;
         P00AT3_A171LeaveRequestHalfDay = new string[] {""} ;
         P00AT3_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00AT3_A125LeaveTypeName = new string[] {""} ;
         P00AT3_A127LeaveRequestId = new long[1] ;
         P00AT4_A171LeaveRequestHalfDay = new string[] {""} ;
         P00AT4_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00AT4_A106EmployeeId = new long[1] ;
         P00AT4_A124LeaveTypeId = new long[1] ;
         P00AT4_A131LeaveRequestDuration = new decimal[1] ;
         P00AT4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AT4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AT4_A133LeaveRequestDescription = new string[] {""} ;
         P00AT4_A148EmployeeName = new string[] {""} ;
         P00AT4_A125LeaveTypeName = new string[] {""} ;
         P00AT4_A127LeaveRequestId = new long[1] ;
         P00AT5_A133LeaveRequestDescription = new string[] {""} ;
         P00AT5_A106EmployeeId = new long[1] ;
         P00AT5_A124LeaveTypeId = new long[1] ;
         P00AT5_A131LeaveRequestDuration = new decimal[1] ;
         P00AT5_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AT5_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AT5_A171LeaveRequestHalfDay = new string[] {""} ;
         P00AT5_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00AT5_A148EmployeeName = new string[] {""} ;
         P00AT5_A125LeaveTypeName = new string[] {""} ;
         P00AT5_A127LeaveRequestId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestlistgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AT2_A124LeaveTypeId, P00AT2_A106EmployeeId, P00AT2_A131LeaveRequestDuration, P00AT2_A130LeaveRequestEndDate, P00AT2_A129LeaveRequestStartDate, P00AT2_A133LeaveRequestDescription, P00AT2_A171LeaveRequestHalfDay, P00AT2_n171LeaveRequestHalfDay, P00AT2_A148EmployeeName, P00AT2_A125LeaveTypeName,
               P00AT2_A127LeaveRequestId
               }
               , new Object[] {
               P00AT3_A148EmployeeName, P00AT3_A106EmployeeId, P00AT3_A124LeaveTypeId, P00AT3_A131LeaveRequestDuration, P00AT3_A130LeaveRequestEndDate, P00AT3_A129LeaveRequestStartDate, P00AT3_A133LeaveRequestDescription, P00AT3_A171LeaveRequestHalfDay, P00AT3_n171LeaveRequestHalfDay, P00AT3_A125LeaveTypeName,
               P00AT3_A127LeaveRequestId
               }
               , new Object[] {
               P00AT4_A171LeaveRequestHalfDay, P00AT4_n171LeaveRequestHalfDay, P00AT4_A106EmployeeId, P00AT4_A124LeaveTypeId, P00AT4_A131LeaveRequestDuration, P00AT4_A130LeaveRequestEndDate, P00AT4_A129LeaveRequestStartDate, P00AT4_A133LeaveRequestDescription, P00AT4_A148EmployeeName, P00AT4_A125LeaveTypeName,
               P00AT4_A127LeaveRequestId
               }
               , new Object[] {
               P00AT5_A133LeaveRequestDescription, P00AT5_A106EmployeeId, P00AT5_A124LeaveTypeId, P00AT5_A131LeaveRequestDuration, P00AT5_A130LeaveRequestEndDate, P00AT5_A129LeaveRequestStartDate, P00AT5_A171LeaveRequestHalfDay, P00AT5_n171LeaveRequestHalfDay, P00AT5_A148EmployeeName, P00AT5_A125LeaveTypeName,
               P00AT5_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32MaxItems ;
      private short AV31PageIndex ;
      private short AV30SkipItems ;
      private int AV57GXV1 ;
      private int AV33InsertIndex ;
      private long AV52LeaveTypeId ;
      private long AV53EmployeeId ;
      private long AV56CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private long AV39count ;
      private decimal AV21TFLeaveRequestDuration ;
      private decimal AV22TFLeaveRequestDuration_To ;
      private decimal AV70Leaverequestlistds_12_tfleaverequestduration ;
      private decimal AV71Leaverequestlistds_13_tfleaverequestduration_to ;
      private decimal A131LeaveRequestDuration ;
      private string AV11TFLeaveTypeName ;
      private string AV12TFLeaveTypeName_Sel ;
      private string AV13TFEmployeeName ;
      private string AV14TFEmployeeName_Sel ;
      private string AV19TFLeaveRequestHalfDay ;
      private string AV20TFLeaveRequestHalfDay_Sel ;
      private string AV60Leaverequestlistds_2_tfleavetypename ;
      private string AV61Leaverequestlistds_3_tfleavetypename_sel ;
      private string AV62Leaverequestlistds_4_tfemployeename ;
      private string AV63Leaverequestlistds_5_tfemployeename_sel ;
      private string AV68Leaverequestlistds_10_tfleaverequesthalfday ;
      private string AV69Leaverequestlistds_11_tfleaverequesthalfday_sel ;
      private string lV60Leaverequestlistds_2_tfleavetypename ;
      private string lV62Leaverequestlistds_4_tfemployeename ;
      private string lV68Leaverequestlistds_10_tfleaverequesthalfday ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private string A171LeaveRequestHalfDay ;
      private DateTime AV15TFLeaveRequestStartDate ;
      private DateTime AV16TFLeaveRequestStartDate_To ;
      private DateTime AV17TFLeaveRequestEndDate ;
      private DateTime AV18TFLeaveRequestEndDate_To ;
      private DateTime AV54FromDate ;
      private DateTime AV55ToDate ;
      private DateTime AV64Leaverequestlistds_6_tfleaverequeststartdate ;
      private DateTime AV65Leaverequestlistds_7_tfleaverequeststartdate_to ;
      private DateTime AV66Leaverequestlistds_8_tfleaverequestenddate ;
      private DateTime AV67Leaverequestlistds_9_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool BRKAT2 ;
      private bool n171LeaveRequestHalfDay ;
      private bool BRKAT4 ;
      private bool BRKAT6 ;
      private bool BRKAT8 ;
      private string AV48OptionsJson ;
      private string AV49OptionsDescJson ;
      private string AV50OptionIndexesJson ;
      private string AV45DDOName ;
      private string AV46SearchTxtParms ;
      private string AV47SearchTxtTo ;
      private string AV29SearchTxt ;
      private string AV51FilterFullText ;
      private string AV25TFLeaveRequestDescription ;
      private string AV26TFLeaveRequestDescription_Sel ;
      private string AV59Leaverequestlistds_1_filterfulltext ;
      private string AV72Leaverequestlistds_14_tfleaverequestdescription ;
      private string AV73Leaverequestlistds_15_tfleaverequestdescription_sel ;
      private string lV59Leaverequestlistds_1_filterfulltext ;
      private string lV72Leaverequestlistds_14_tfleaverequestdescription ;
      private string A133LeaveRequestDescription ;
      private string AV34Option ;
      private IGxSession AV40Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV35Options ;
      private GxSimpleCollection<string> AV37OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV42GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private long[] P00AT2_A124LeaveTypeId ;
      private long[] P00AT2_A106EmployeeId ;
      private decimal[] P00AT2_A131LeaveRequestDuration ;
      private DateTime[] P00AT2_A130LeaveRequestEndDate ;
      private DateTime[] P00AT2_A129LeaveRequestStartDate ;
      private string[] P00AT2_A133LeaveRequestDescription ;
      private string[] P00AT2_A171LeaveRequestHalfDay ;
      private bool[] P00AT2_n171LeaveRequestHalfDay ;
      private string[] P00AT2_A148EmployeeName ;
      private string[] P00AT2_A125LeaveTypeName ;
      private long[] P00AT2_A127LeaveRequestId ;
      private string[] P00AT3_A148EmployeeName ;
      private long[] P00AT3_A106EmployeeId ;
      private long[] P00AT3_A124LeaveTypeId ;
      private decimal[] P00AT3_A131LeaveRequestDuration ;
      private DateTime[] P00AT3_A130LeaveRequestEndDate ;
      private DateTime[] P00AT3_A129LeaveRequestStartDate ;
      private string[] P00AT3_A133LeaveRequestDescription ;
      private string[] P00AT3_A171LeaveRequestHalfDay ;
      private bool[] P00AT3_n171LeaveRequestHalfDay ;
      private string[] P00AT3_A125LeaveTypeName ;
      private long[] P00AT3_A127LeaveRequestId ;
      private string[] P00AT4_A171LeaveRequestHalfDay ;
      private bool[] P00AT4_n171LeaveRequestHalfDay ;
      private long[] P00AT4_A106EmployeeId ;
      private long[] P00AT4_A124LeaveTypeId ;
      private decimal[] P00AT4_A131LeaveRequestDuration ;
      private DateTime[] P00AT4_A130LeaveRequestEndDate ;
      private DateTime[] P00AT4_A129LeaveRequestStartDate ;
      private string[] P00AT4_A133LeaveRequestDescription ;
      private string[] P00AT4_A148EmployeeName ;
      private string[] P00AT4_A125LeaveTypeName ;
      private long[] P00AT4_A127LeaveRequestId ;
      private string[] P00AT5_A133LeaveRequestDescription ;
      private long[] P00AT5_A106EmployeeId ;
      private long[] P00AT5_A124LeaveTypeId ;
      private decimal[] P00AT5_A131LeaveRequestDuration ;
      private DateTime[] P00AT5_A130LeaveRequestEndDate ;
      private DateTime[] P00AT5_A129LeaveRequestStartDate ;
      private string[] P00AT5_A171LeaveRequestHalfDay ;
      private bool[] P00AT5_n171LeaveRequestHalfDay ;
      private string[] P00AT5_A148EmployeeName ;
      private string[] P00AT5_A125LeaveTypeName ;
      private long[] P00AT5_A127LeaveRequestId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class leaverequestlistgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AT2( IGxContext context ,
                                             string AV59Leaverequestlistds_1_filterfulltext ,
                                             string AV61Leaverequestlistds_3_tfleavetypename_sel ,
                                             string AV60Leaverequestlistds_2_tfleavetypename ,
                                             string AV63Leaverequestlistds_5_tfemployeename_sel ,
                                             string AV62Leaverequestlistds_4_tfemployeename ,
                                             DateTime AV64Leaverequestlistds_6_tfleaverequeststartdate ,
                                             DateTime AV65Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                             DateTime AV66Leaverequestlistds_8_tfleaverequestenddate ,
                                             DateTime AV67Leaverequestlistds_9_tfleaverequestenddate_to ,
                                             string AV69Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                             string AV68Leaverequestlistds_10_tfleaverequesthalfday ,
                                             decimal AV70Leaverequestlistds_12_tfleaverequestduration ,
                                             decimal AV71Leaverequestlistds_13_tfleaverequestduration_to ,
                                             string AV73Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                             string AV72Leaverequestlistds_14_tfleaverequestdescription ,
                                             long AV52LeaveTypeId ,
                                             long AV53EmployeeId ,
                                             string A125LeaveTypeName ,
                                             string A148EmployeeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A124LeaveTypeId ,
                                             long A106EmployeeId ,
                                             DateTime AV55ToDate ,
                                             DateTime AV54FromDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[23];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDescription, T1.LeaveRequestHalfDay, T3.EmployeeName, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate < :AV55ToDate and T1.LeaveRequestEndDate > :AV54FromDate)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.LeaveTypeName like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T3.EmployeeName like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestDescription like '%' || :lV59Leaverequestlistds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestlistds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestlistds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV60Leaverequestlistds_2_tfleavetypename)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestlistds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV61Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV61Leaverequestlistds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestlistds_5_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestlistds_4_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV62Leaverequestlistds_4_tfemployeename)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestlistds_5_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV63Leaverequestlistds_5_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestlistds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV64Leaverequestlistds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestlistds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV65Leaverequestlistds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestlistds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV66Leaverequestlistds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestlistds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV67Leaverequestlistds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Leaverequestlistds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV68Leaverequestlistds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV69Leaverequestlistds_11_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestlistds_12_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV70Leaverequestlistds_12_tfleaverequestduration)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestlistds_13_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV71Leaverequestlistds_13_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Leaverequestlistds_15_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestlistds_14_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription like :lV72Leaverequestlistds_14_tfleaverequestdescription)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Leaverequestlistds_15_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV73Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV73Leaverequestlistds_15_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( StringUtil.StrCmp(AV73Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( ! (0==AV52LeaveTypeId) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId = :AV52LeaveTypeId)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (0==AV53EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV53EmployeeId)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveTypeId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AT3( IGxContext context ,
                                             string AV59Leaverequestlistds_1_filterfulltext ,
                                             string AV61Leaverequestlistds_3_tfleavetypename_sel ,
                                             string AV60Leaverequestlistds_2_tfleavetypename ,
                                             string AV63Leaverequestlistds_5_tfemployeename_sel ,
                                             string AV62Leaverequestlistds_4_tfemployeename ,
                                             DateTime AV64Leaverequestlistds_6_tfleaverequeststartdate ,
                                             DateTime AV65Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                             DateTime AV66Leaverequestlistds_8_tfleaverequestenddate ,
                                             DateTime AV67Leaverequestlistds_9_tfleaverequestenddate_to ,
                                             string AV69Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                             string AV68Leaverequestlistds_10_tfleaverequesthalfday ,
                                             decimal AV70Leaverequestlistds_12_tfleaverequestduration ,
                                             decimal AV71Leaverequestlistds_13_tfleaverequestduration_to ,
                                             string AV73Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                             string AV72Leaverequestlistds_14_tfleaverequestdescription ,
                                             long AV52LeaveTypeId ,
                                             long AV53EmployeeId ,
                                             string A125LeaveTypeName ,
                                             string A148EmployeeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A124LeaveTypeId ,
                                             long A106EmployeeId ,
                                             DateTime AV55ToDate ,
                                             DateTime AV54FromDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[23];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.EmployeeName, T1.EmployeeId, T1.LeaveTypeId, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDescription, T1.LeaveRequestHalfDay, T3.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T3 ON T3.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate < :AV55ToDate and T1.LeaveRequestEndDate > :AV54FromDate)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.LeaveTypeName like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T2.EmployeeName like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestDescription like '%' || :lV59Leaverequestlistds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestlistds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestlistds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T3.LeaveTypeName like :lV60Leaverequestlistds_2_tfleavetypename)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestlistds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV61Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.LeaveTypeName = ( :AV61Leaverequestlistds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.LeaveTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestlistds_5_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestlistds_4_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV62Leaverequestlistds_4_tfemployeename)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestlistds_5_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV63Leaverequestlistds_5_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestlistds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV64Leaverequestlistds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestlistds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV65Leaverequestlistds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestlistds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV66Leaverequestlistds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestlistds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV67Leaverequestlistds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Leaverequestlistds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV68Leaverequestlistds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV69Leaverequestlistds_11_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestlistds_12_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV70Leaverequestlistds_12_tfleaverequestduration)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestlistds_13_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV71Leaverequestlistds_13_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Leaverequestlistds_15_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestlistds_14_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription like :lV72Leaverequestlistds_14_tfleaverequestdescription)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Leaverequestlistds_15_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV73Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV73Leaverequestlistds_15_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV73Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( ! (0==AV52LeaveTypeId) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId = :AV52LeaveTypeId)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (0==AV53EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV53EmployeeId)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.EmployeeName";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00AT4( IGxContext context ,
                                             string AV59Leaverequestlistds_1_filterfulltext ,
                                             string AV61Leaverequestlistds_3_tfleavetypename_sel ,
                                             string AV60Leaverequestlistds_2_tfleavetypename ,
                                             string AV63Leaverequestlistds_5_tfemployeename_sel ,
                                             string AV62Leaverequestlistds_4_tfemployeename ,
                                             DateTime AV64Leaverequestlistds_6_tfleaverequeststartdate ,
                                             DateTime AV65Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                             DateTime AV66Leaverequestlistds_8_tfleaverequestenddate ,
                                             DateTime AV67Leaverequestlistds_9_tfleaverequestenddate_to ,
                                             string AV69Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                             string AV68Leaverequestlistds_10_tfleaverequesthalfday ,
                                             decimal AV70Leaverequestlistds_12_tfleaverequestduration ,
                                             decimal AV71Leaverequestlistds_13_tfleaverequestduration_to ,
                                             string AV73Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                             string AV72Leaverequestlistds_14_tfleaverequestdescription ,
                                             long AV52LeaveTypeId ,
                                             long AV53EmployeeId ,
                                             string A125LeaveTypeName ,
                                             string A148EmployeeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A124LeaveTypeId ,
                                             long A106EmployeeId ,
                                             DateTime AV55ToDate ,
                                             DateTime AV54FromDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[23];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.LeaveRequestHalfDay, T1.EmployeeId, T1.LeaveTypeId, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDescription, T2.EmployeeName, T3.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T3 ON T3.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate < :AV55ToDate and T1.LeaveRequestEndDate > :AV54FromDate)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.LeaveTypeName like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T2.EmployeeName like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestDescription like '%' || :lV59Leaverequestlistds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestlistds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestlistds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T3.LeaveTypeName like :lV60Leaverequestlistds_2_tfleavetypename)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestlistds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV61Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.LeaveTypeName = ( :AV61Leaverequestlistds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.LeaveTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestlistds_5_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestlistds_4_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV62Leaverequestlistds_4_tfemployeename)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestlistds_5_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV63Leaverequestlistds_5_tfemployeename_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestlistds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV64Leaverequestlistds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestlistds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV65Leaverequestlistds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestlistds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV66Leaverequestlistds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestlistds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV67Leaverequestlistds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Leaverequestlistds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV68Leaverequestlistds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV69Leaverequestlistds_11_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestlistds_12_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV70Leaverequestlistds_12_tfleaverequestduration)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestlistds_13_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV71Leaverequestlistds_13_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Leaverequestlistds_15_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestlistds_14_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription like :lV72Leaverequestlistds_14_tfleaverequestdescription)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Leaverequestlistds_15_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV73Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV73Leaverequestlistds_15_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV73Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( ! (0==AV52LeaveTypeId) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId = :AV52LeaveTypeId)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (0==AV53EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV53EmployeeId)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestHalfDay";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00AT5( IGxContext context ,
                                             string AV59Leaverequestlistds_1_filterfulltext ,
                                             string AV61Leaverequestlistds_3_tfleavetypename_sel ,
                                             string AV60Leaverequestlistds_2_tfleavetypename ,
                                             string AV63Leaverequestlistds_5_tfemployeename_sel ,
                                             string AV62Leaverequestlistds_4_tfemployeename ,
                                             DateTime AV64Leaverequestlistds_6_tfleaverequeststartdate ,
                                             DateTime AV65Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                             DateTime AV66Leaverequestlistds_8_tfleaverequestenddate ,
                                             DateTime AV67Leaverequestlistds_9_tfleaverequestenddate_to ,
                                             string AV69Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                             string AV68Leaverequestlistds_10_tfleaverequesthalfday ,
                                             decimal AV70Leaverequestlistds_12_tfleaverequestduration ,
                                             decimal AV71Leaverequestlistds_13_tfleaverequestduration_to ,
                                             string AV73Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                             string AV72Leaverequestlistds_14_tfleaverequestdescription ,
                                             long AV52LeaveTypeId ,
                                             long AV53EmployeeId ,
                                             string A125LeaveTypeName ,
                                             string A148EmployeeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A124LeaveTypeId ,
                                             long A106EmployeeId ,
                                             DateTime AV55ToDate ,
                                             DateTime AV54FromDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[23];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.LeaveRequestDescription, T1.EmployeeId, T1.LeaveTypeId, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestHalfDay, T2.EmployeeName, T3.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T3 ON T3.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate < :AV55ToDate and T1.LeaveRequestEndDate > :AV54FromDate)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestlistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.LeaveTypeName like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T2.EmployeeName like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV59Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestDescription like '%' || :lV59Leaverequestlistds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestlistds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestlistds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T3.LeaveTypeName like :lV60Leaverequestlistds_2_tfleavetypename)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestlistds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV61Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.LeaveTypeName = ( :AV61Leaverequestlistds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.LeaveTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestlistds_5_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestlistds_4_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV62Leaverequestlistds_4_tfemployeename)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestlistds_5_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV63Leaverequestlistds_5_tfemployeename_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestlistds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV64Leaverequestlistds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestlistds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV65Leaverequestlistds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestlistds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV66Leaverequestlistds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestlistds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV67Leaverequestlistds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Leaverequestlistds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV68Leaverequestlistds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV69Leaverequestlistds_11_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestlistds_12_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV70Leaverequestlistds_12_tfleaverequestduration)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestlistds_13_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV71Leaverequestlistds_13_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Leaverequestlistds_15_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestlistds_14_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription like :lV72Leaverequestlistds_14_tfleaverequestdescription)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Leaverequestlistds_15_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV73Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV73Leaverequestlistds_15_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV73Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( ! (0==AV52LeaveTypeId) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId = :AV52LeaveTypeId)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! (0==AV53EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV53EmployeeId)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestDescription";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AT2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] );
               case 1 :
                     return conditional_P00AT3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] );
               case 2 :
                     return conditional_P00AT4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] );
               case 3 :
                     return conditional_P00AT5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AT2;
          prmP00AT2 = new Object[] {
          new ParDef("AV55ToDate",GXType.Date,8,0) ,
          new ParDef("AV54FromDate",GXType.Date,8,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Leaverequestlistds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV61Leaverequestlistds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("lV62Leaverequestlistds_4_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV63Leaverequestlistds_5_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("AV64Leaverequestlistds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV65Leaverequestlistds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestlistds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestlistds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV68Leaverequestlistds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV69Leaverequestlistds_11_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV70Leaverequestlistds_12_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestlistds_13_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV72Leaverequestlistds_14_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV73Leaverequestlistds_15_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV52LeaveTypeId",GXType.Int64,10,0) ,
          new ParDef("AV53EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00AT3;
          prmP00AT3 = new Object[] {
          new ParDef("AV55ToDate",GXType.Date,8,0) ,
          new ParDef("AV54FromDate",GXType.Date,8,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Leaverequestlistds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV61Leaverequestlistds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("lV62Leaverequestlistds_4_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV63Leaverequestlistds_5_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("AV64Leaverequestlistds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV65Leaverequestlistds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestlistds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestlistds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV68Leaverequestlistds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV69Leaverequestlistds_11_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV70Leaverequestlistds_12_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestlistds_13_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV72Leaverequestlistds_14_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV73Leaverequestlistds_15_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV52LeaveTypeId",GXType.Int64,10,0) ,
          new ParDef("AV53EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00AT4;
          prmP00AT4 = new Object[] {
          new ParDef("AV55ToDate",GXType.Date,8,0) ,
          new ParDef("AV54FromDate",GXType.Date,8,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Leaverequestlistds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV61Leaverequestlistds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("lV62Leaverequestlistds_4_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV63Leaverequestlistds_5_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("AV64Leaverequestlistds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV65Leaverequestlistds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestlistds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestlistds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV68Leaverequestlistds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV69Leaverequestlistds_11_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV70Leaverequestlistds_12_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestlistds_13_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV72Leaverequestlistds_14_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV73Leaverequestlistds_15_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV52LeaveTypeId",GXType.Int64,10,0) ,
          new ParDef("AV53EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP00AT5;
          prmP00AT5 = new Object[] {
          new ParDef("AV55ToDate",GXType.Date,8,0) ,
          new ParDef("AV54FromDate",GXType.Date,8,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Leaverequestlistds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV61Leaverequestlistds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("lV62Leaverequestlistds_4_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV63Leaverequestlistds_5_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("AV64Leaverequestlistds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV65Leaverequestlistds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestlistds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestlistds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV68Leaverequestlistds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV69Leaverequestlistds_11_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV70Leaverequestlistds_12_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestlistds_13_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV72Leaverequestlistds_14_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV73Leaverequestlistds_15_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV52LeaveTypeId",GXType.Int64,10,0) ,
          new ParDef("AV53EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AT2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AT3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AT4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AT5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AT5,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((long[]) buf[10])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
