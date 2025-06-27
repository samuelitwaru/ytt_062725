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
   public class leaverequestrejectedgetfilterdata : GXProcedure
   {
      public leaverequestrejectedgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestrejectedgetfilterdata( IGxContext context )
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
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV48OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30MaxItems = 10;
         AV29PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV44SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV27SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? "" : StringUtil.Substring( AV44SearchTxtParms, 3, -1));
         AV28SkipItems = (short)(AV29PageIndex*AV30MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_LEAVETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_LEAVEREQUESTHALFDAY") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTHALFDAYOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV46OptionsJson = AV33Options.ToJSonString(false);
         AV47OptionsDescJson = AV35OptionsDesc.ToJSonString(false);
         AV48OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("LeaveRequestRejectedGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "LeaveRequestRejectedGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("LeaveRequestRejectedGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV49FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV11TFEmployeeName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV12TFEmployeeName_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV13TFLeaveTypeName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV14TFLeaveTypeName_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV17TFLeaveRequestStartDate = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV18TFLeaveRequestStartDate_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV19TFLeaveRequestEndDate = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV20TFLeaveRequestEndDate_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV53TFLeaveRequestHalfDayOperator = AV41GridStateFilterValue.gxTpr_Operator;
               if ( AV53TFLeaveRequestHalfDayOperator == 0 )
               {
                  AV51TFLeaveRequestHalfDay = AV41GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV52TFLeaveRequestHalfDay_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV21TFLeaveRequestDuration = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, ".");
               AV22TFLeaveRequestDuration_To = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEBALANCE") == 0 )
            {
               AV54TFEmployeeBalance = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, ".");
               AV55TFEmployeeBalance_To = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFEmployeeName = AV27SearchTxt;
         AV12TFEmployeeName_Sel = "";
         AV58Leaverequestrejectedds_1_filterfulltext = AV49FilterFullText;
         AV59Leaverequestrejectedds_2_tfemployeename = AV11TFEmployeeName;
         AV60Leaverequestrejectedds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV61Leaverequestrejectedds_4_tfleavetypename = AV13TFLeaveTypeName;
         AV62Leaverequestrejectedds_5_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV63Leaverequestrejectedds_6_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV65Leaverequestrejectedds_8_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV66Leaverequestrejectedds_9_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV67Leaverequestrejectedds_10_tfleaverequesthalfday = AV51TFLeaveRequestHalfDay;
         AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator = AV53TFLeaveRequestHalfDayOperator;
         AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel = AV52TFLeaveRequestHalfDay_Sel;
         AV70Leaverequestrejectedds_13_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV71Leaverequestrejectedds_14_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV72Leaverequestrejectedds_15_tfemployeebalance = AV54TFEmployeeBalance;
         AV73Leaverequestrejectedds_16_tfemployeebalance_to = AV55TFEmployeeBalance_To;
         AV74Udparg17 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV50EmployeeIds ,
                                              AV58Leaverequestrejectedds_1_filterfulltext ,
                                              AV60Leaverequestrejectedds_3_tfemployeename_sel ,
                                              AV59Leaverequestrejectedds_2_tfemployeename ,
                                              AV62Leaverequestrejectedds_5_tfleavetypename_sel ,
                                              AV61Leaverequestrejectedds_4_tfleavetypename ,
                                              AV63Leaverequestrejectedds_6_tfleaverequeststartdate ,
                                              AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to ,
                                              AV65Leaverequestrejectedds_8_tfleaverequestenddate ,
                                              AV66Leaverequestrejectedds_9_tfleaverequestenddate_to ,
                                              AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel ,
                                              AV67Leaverequestrejectedds_10_tfleaverequesthalfday ,
                                              AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator ,
                                              AV70Leaverequestrejectedds_13_tfleaverequestduration ,
                                              AV71Leaverequestrejectedds_14_tfleaverequestduration_to ,
                                              AV72Leaverequestrejectedds_15_tfemployeebalance ,
                                              AV73Leaverequestrejectedds_16_tfemployeebalance_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A147EmployeeBalance ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV74Udparg17 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV59Leaverequestrejectedds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV59Leaverequestrejectedds_2_tfemployeename), 100, "%");
         lV61Leaverequestrejectedds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV61Leaverequestrejectedds_4_tfleavetypename), 100, "%");
         lV67Leaverequestrejectedds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV67Leaverequestrejectedds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P00712 */
         pr_default.execute(0, new Object[] {lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV59Leaverequestrejectedds_2_tfemployeename, AV60Leaverequestrejectedds_3_tfemployeename_sel, lV61Leaverequestrejectedds_4_tfleavetypename, AV62Leaverequestrejectedds_5_tfleavetypename_sel, AV63Leaverequestrejectedds_6_tfleaverequeststartdate, AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to, AV65Leaverequestrejectedds_8_tfleaverequestenddate, AV66Leaverequestrejectedds_9_tfleaverequestenddate_to, lV67Leaverequestrejectedds_10_tfleaverequesthalfday, AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel, AV70Leaverequestrejectedds_13_tfleaverequestduration, AV71Leaverequestrejectedds_14_tfleaverequestduration_to, AV72Leaverequestrejectedds_15_tfemployeebalance, AV73Leaverequestrejectedds_16_tfemployeebalance_to, AV74Udparg17});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK712 = false;
            A124LeaveTypeId = P00712_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P00712_A132LeaveRequestStatus[0];
            A148EmployeeName = P00712_A148EmployeeName[0];
            A106EmployeeId = P00712_A106EmployeeId[0];
            A100CompanyId = P00712_A100CompanyId[0];
            A147EmployeeBalance = P00712_A147EmployeeBalance[0];
            A131LeaveRequestDuration = P00712_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00712_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00712_A129LeaveRequestStartDate[0];
            A171LeaveRequestHalfDay = P00712_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00712_n171LeaveRequestHalfDay[0];
            A125LeaveTypeName = P00712_A125LeaveTypeName[0];
            A127LeaveRequestId = P00712_A127LeaveRequestId[0];
            A100CompanyId = P00712_A100CompanyId[0];
            A125LeaveTypeName = P00712_A125LeaveTypeName[0];
            A148EmployeeName = P00712_A148EmployeeName[0];
            A147EmployeeBalance = P00712_A147EmployeeBalance[0];
            AV37count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00712_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRK712 = false;
               A106EmployeeId = P00712_A106EmployeeId[0];
               A127LeaveRequestId = P00712_A127LeaveRequestId[0];
               AV37count = (long)(AV37count+1);
               BRK712 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148EmployeeName)) ? "<#Empty#>" : A148EmployeeName);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK712 )
            {
               BRK712 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFLeaveTypeName = AV27SearchTxt;
         AV14TFLeaveTypeName_Sel = "";
         AV58Leaverequestrejectedds_1_filterfulltext = AV49FilterFullText;
         AV59Leaverequestrejectedds_2_tfemployeename = AV11TFEmployeeName;
         AV60Leaverequestrejectedds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV61Leaverequestrejectedds_4_tfleavetypename = AV13TFLeaveTypeName;
         AV62Leaverequestrejectedds_5_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV63Leaverequestrejectedds_6_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV65Leaverequestrejectedds_8_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV66Leaverequestrejectedds_9_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV67Leaverequestrejectedds_10_tfleaverequesthalfday = AV51TFLeaveRequestHalfDay;
         AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator = AV53TFLeaveRequestHalfDayOperator;
         AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel = AV52TFLeaveRequestHalfDay_Sel;
         AV70Leaverequestrejectedds_13_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV71Leaverequestrejectedds_14_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV72Leaverequestrejectedds_15_tfemployeebalance = AV54TFEmployeeBalance;
         AV73Leaverequestrejectedds_16_tfemployeebalance_to = AV55TFEmployeeBalance_To;
         AV74Udparg17 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV50EmployeeIds ,
                                              AV58Leaverequestrejectedds_1_filterfulltext ,
                                              AV60Leaverequestrejectedds_3_tfemployeename_sel ,
                                              AV59Leaverequestrejectedds_2_tfemployeename ,
                                              AV62Leaverequestrejectedds_5_tfleavetypename_sel ,
                                              AV61Leaverequestrejectedds_4_tfleavetypename ,
                                              AV63Leaverequestrejectedds_6_tfleaverequeststartdate ,
                                              AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to ,
                                              AV65Leaverequestrejectedds_8_tfleaverequestenddate ,
                                              AV66Leaverequestrejectedds_9_tfleaverequestenddate_to ,
                                              AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel ,
                                              AV67Leaverequestrejectedds_10_tfleaverequesthalfday ,
                                              AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator ,
                                              AV70Leaverequestrejectedds_13_tfleaverequestduration ,
                                              AV71Leaverequestrejectedds_14_tfleaverequestduration_to ,
                                              AV72Leaverequestrejectedds_15_tfemployeebalance ,
                                              AV73Leaverequestrejectedds_16_tfemployeebalance_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A147EmployeeBalance ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV74Udparg17 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV59Leaverequestrejectedds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV59Leaverequestrejectedds_2_tfemployeename), 100, "%");
         lV61Leaverequestrejectedds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV61Leaverequestrejectedds_4_tfleavetypename), 100, "%");
         lV67Leaverequestrejectedds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV67Leaverequestrejectedds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P00713 */
         pr_default.execute(1, new Object[] {lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV59Leaverequestrejectedds_2_tfemployeename, AV60Leaverequestrejectedds_3_tfemployeename_sel, lV61Leaverequestrejectedds_4_tfleavetypename, AV62Leaverequestrejectedds_5_tfleavetypename_sel, AV63Leaverequestrejectedds_6_tfleaverequeststartdate, AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to, AV65Leaverequestrejectedds_8_tfleaverequestenddate, AV66Leaverequestrejectedds_9_tfleaverequestenddate_to, lV67Leaverequestrejectedds_10_tfleaverequesthalfday, AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel, AV70Leaverequestrejectedds_13_tfleaverequestduration, AV71Leaverequestrejectedds_14_tfleaverequestduration_to, AV72Leaverequestrejectedds_15_tfemployeebalance, AV73Leaverequestrejectedds_16_tfemployeebalance_to, AV74Udparg17});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK714 = false;
            A124LeaveTypeId = P00713_A124LeaveTypeId[0];
            A106EmployeeId = P00713_A106EmployeeId[0];
            A100CompanyId = P00713_A100CompanyId[0];
            A132LeaveRequestStatus = P00713_A132LeaveRequestStatus[0];
            A147EmployeeBalance = P00713_A147EmployeeBalance[0];
            A131LeaveRequestDuration = P00713_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00713_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00713_A129LeaveRequestStartDate[0];
            A171LeaveRequestHalfDay = P00713_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00713_n171LeaveRequestHalfDay[0];
            A125LeaveTypeName = P00713_A125LeaveTypeName[0];
            A148EmployeeName = P00713_A148EmployeeName[0];
            A127LeaveRequestId = P00713_A127LeaveRequestId[0];
            A100CompanyId = P00713_A100CompanyId[0];
            A125LeaveTypeName = P00713_A125LeaveTypeName[0];
            A147EmployeeBalance = P00713_A147EmployeeBalance[0];
            A148EmployeeName = P00713_A148EmployeeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00713_A124LeaveTypeId[0] == A124LeaveTypeId ) )
            {
               BRK714 = false;
               A127LeaveRequestId = P00713_A127LeaveRequestId[0];
               AV37count = (long)(AV37count+1);
               BRK714 = true;
               pr_default.readNext(1);
            }
            AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) ? "<#Empty#>" : A125LeaveTypeName);
            AV31InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV32Option, "<#Empty#>") != 0 ) && ( AV31InsertIndex <= AV33Options.Count ) && ( ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) < 0 ) || ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV31InsertIndex = (int)(AV31InsertIndex+1);
            }
            AV33Options.Add(AV32Option, AV31InsertIndex);
            AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), AV31InsertIndex);
            if ( AV33Options.Count == AV28SkipItems + 11 )
            {
               AV33Options.RemoveItem(AV33Options.Count);
               AV36OptionIndexes.RemoveItem(AV36OptionIndexes.Count);
            }
            if ( ! BRK714 )
            {
               BRK714 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV28SkipItems > 0 )
         {
            AV33Options.RemoveItem(1);
            AV36OptionIndexes.RemoveItem(1);
            AV28SkipItems = (short)(AV28SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADLEAVEREQUESTHALFDAYOPTIONS' Routine */
         returnInSub = false;
         AV51TFLeaveRequestHalfDay = AV27SearchTxt;
         AV53TFLeaveRequestHalfDayOperator = 0;
         AV52TFLeaveRequestHalfDay_Sel = "";
         AV58Leaverequestrejectedds_1_filterfulltext = AV49FilterFullText;
         AV59Leaverequestrejectedds_2_tfemployeename = AV11TFEmployeeName;
         AV60Leaverequestrejectedds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV61Leaverequestrejectedds_4_tfleavetypename = AV13TFLeaveTypeName;
         AV62Leaverequestrejectedds_5_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV63Leaverequestrejectedds_6_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV65Leaverequestrejectedds_8_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV66Leaverequestrejectedds_9_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV67Leaverequestrejectedds_10_tfleaverequesthalfday = AV51TFLeaveRequestHalfDay;
         AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator = AV53TFLeaveRequestHalfDayOperator;
         AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel = AV52TFLeaveRequestHalfDay_Sel;
         AV70Leaverequestrejectedds_13_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV71Leaverequestrejectedds_14_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV72Leaverequestrejectedds_15_tfemployeebalance = AV54TFEmployeeBalance;
         AV73Leaverequestrejectedds_16_tfemployeebalance_to = AV55TFEmployeeBalance_To;
         AV74Udparg17 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV50EmployeeIds ,
                                              AV58Leaverequestrejectedds_1_filterfulltext ,
                                              AV60Leaverequestrejectedds_3_tfemployeename_sel ,
                                              AV59Leaverequestrejectedds_2_tfemployeename ,
                                              AV62Leaverequestrejectedds_5_tfleavetypename_sel ,
                                              AV61Leaverequestrejectedds_4_tfleavetypename ,
                                              AV63Leaverequestrejectedds_6_tfleaverequeststartdate ,
                                              AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to ,
                                              AV65Leaverequestrejectedds_8_tfleaverequestenddate ,
                                              AV66Leaverequestrejectedds_9_tfleaverequestenddate_to ,
                                              AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel ,
                                              AV67Leaverequestrejectedds_10_tfleaverequesthalfday ,
                                              AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator ,
                                              AV70Leaverequestrejectedds_13_tfleaverequestduration ,
                                              AV71Leaverequestrejectedds_14_tfleaverequestduration_to ,
                                              AV72Leaverequestrejectedds_15_tfemployeebalance ,
                                              AV73Leaverequestrejectedds_16_tfemployeebalance_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A147EmployeeBalance ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV74Udparg17 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV58Leaverequestrejectedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext), "%", "");
         lV59Leaverequestrejectedds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV59Leaverequestrejectedds_2_tfemployeename), 100, "%");
         lV61Leaverequestrejectedds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV61Leaverequestrejectedds_4_tfleavetypename), 100, "%");
         lV67Leaverequestrejectedds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV67Leaverequestrejectedds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P00714 */
         pr_default.execute(2, new Object[] {lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV58Leaverequestrejectedds_1_filterfulltext, lV59Leaverequestrejectedds_2_tfemployeename, AV60Leaverequestrejectedds_3_tfemployeename_sel, lV61Leaverequestrejectedds_4_tfleavetypename, AV62Leaverequestrejectedds_5_tfleavetypename_sel, AV63Leaverequestrejectedds_6_tfleaverequeststartdate, AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to, AV65Leaverequestrejectedds_8_tfleaverequestenddate, AV66Leaverequestrejectedds_9_tfleaverequestenddate_to, lV67Leaverequestrejectedds_10_tfleaverequesthalfday, AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel, AV70Leaverequestrejectedds_13_tfleaverequestduration, AV71Leaverequestrejectedds_14_tfleaverequestduration_to, AV72Leaverequestrejectedds_15_tfemployeebalance, AV73Leaverequestrejectedds_16_tfemployeebalance_to, AV74Udparg17});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK716 = false;
            A124LeaveTypeId = P00714_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P00714_A132LeaveRequestStatus[0];
            A171LeaveRequestHalfDay = P00714_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00714_n171LeaveRequestHalfDay[0];
            A106EmployeeId = P00714_A106EmployeeId[0];
            A100CompanyId = P00714_A100CompanyId[0];
            A147EmployeeBalance = P00714_A147EmployeeBalance[0];
            A131LeaveRequestDuration = P00714_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00714_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00714_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P00714_A125LeaveTypeName[0];
            A148EmployeeName = P00714_A148EmployeeName[0];
            A127LeaveRequestId = P00714_A127LeaveRequestId[0];
            A100CompanyId = P00714_A100CompanyId[0];
            A125LeaveTypeName = P00714_A125LeaveTypeName[0];
            A147EmployeeBalance = P00714_A147EmployeeBalance[0];
            A148EmployeeName = P00714_A148EmployeeName[0];
            AV37count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00714_A171LeaveRequestHalfDay[0], A171LeaveRequestHalfDay) == 0 ) )
            {
               BRK716 = false;
               A127LeaveRequestId = P00714_A127LeaveRequestId[0];
               AV37count = (long)(AV37count+1);
               BRK716 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV28SkipItems) )
            {
               AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A171LeaveRequestHalfDay)) ? "<#Empty#>" : A171LeaveRequestHalfDay);
               AV33Options.Add(AV32Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV33Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV28SkipItems = (short)(AV28SkipItems-1);
            }
            if ( ! BRK716 )
            {
               BRK716 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV46OptionsJson = "";
         AV47OptionsDescJson = "";
         AV48OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV35OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV27SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38Session = context.GetSession();
         AV40GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV41GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV49FilterFullText = "";
         AV11TFEmployeeName = "";
         AV12TFEmployeeName_Sel = "";
         AV13TFLeaveTypeName = "";
         AV14TFLeaveTypeName_Sel = "";
         AV17TFLeaveRequestStartDate = DateTime.MinValue;
         AV18TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV19TFLeaveRequestEndDate = DateTime.MinValue;
         AV20TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV51TFLeaveRequestHalfDay = "";
         AV52TFLeaveRequestHalfDay_Sel = "";
         AV58Leaverequestrejectedds_1_filterfulltext = "";
         AV59Leaverequestrejectedds_2_tfemployeename = "";
         AV60Leaverequestrejectedds_3_tfemployeename_sel = "";
         AV61Leaverequestrejectedds_4_tfleavetypename = "";
         AV62Leaverequestrejectedds_5_tfleavetypename_sel = "";
         AV63Leaverequestrejectedds_6_tfleaverequeststartdate = DateTime.MinValue;
         AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to = DateTime.MinValue;
         AV65Leaverequestrejectedds_8_tfleaverequestenddate = DateTime.MinValue;
         AV66Leaverequestrejectedds_9_tfleaverequestenddate_to = DateTime.MinValue;
         AV67Leaverequestrejectedds_10_tfleaverequesthalfday = "";
         AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel = "";
         lV58Leaverequestrejectedds_1_filterfulltext = "";
         lV59Leaverequestrejectedds_2_tfemployeename = "";
         lV61Leaverequestrejectedds_4_tfleavetypename = "";
         lV67Leaverequestrejectedds_10_tfleaverequesthalfday = "";
         AV50EmployeeIds = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         A125LeaveTypeName = "";
         A171LeaveRequestHalfDay = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         P00712_A124LeaveTypeId = new long[1] ;
         P00712_A132LeaveRequestStatus = new string[] {""} ;
         P00712_A148EmployeeName = new string[] {""} ;
         P00712_A106EmployeeId = new long[1] ;
         P00712_A100CompanyId = new long[1] ;
         P00712_A147EmployeeBalance = new decimal[1] ;
         P00712_A131LeaveRequestDuration = new decimal[1] ;
         P00712_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00712_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00712_A171LeaveRequestHalfDay = new string[] {""} ;
         P00712_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00712_A125LeaveTypeName = new string[] {""} ;
         P00712_A127LeaveRequestId = new long[1] ;
         AV32Option = "";
         P00713_A124LeaveTypeId = new long[1] ;
         P00713_A106EmployeeId = new long[1] ;
         P00713_A100CompanyId = new long[1] ;
         P00713_A132LeaveRequestStatus = new string[] {""} ;
         P00713_A147EmployeeBalance = new decimal[1] ;
         P00713_A131LeaveRequestDuration = new decimal[1] ;
         P00713_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00713_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00713_A171LeaveRequestHalfDay = new string[] {""} ;
         P00713_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00713_A125LeaveTypeName = new string[] {""} ;
         P00713_A148EmployeeName = new string[] {""} ;
         P00713_A127LeaveRequestId = new long[1] ;
         P00714_A124LeaveTypeId = new long[1] ;
         P00714_A132LeaveRequestStatus = new string[] {""} ;
         P00714_A171LeaveRequestHalfDay = new string[] {""} ;
         P00714_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00714_A106EmployeeId = new long[1] ;
         P00714_A100CompanyId = new long[1] ;
         P00714_A147EmployeeBalance = new decimal[1] ;
         P00714_A131LeaveRequestDuration = new decimal[1] ;
         P00714_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00714_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00714_A125LeaveTypeName = new string[] {""} ;
         P00714_A148EmployeeName = new string[] {""} ;
         P00714_A127LeaveRequestId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestrejectedgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00712_A124LeaveTypeId, P00712_A132LeaveRequestStatus, P00712_A148EmployeeName, P00712_A106EmployeeId, P00712_A100CompanyId, P00712_A147EmployeeBalance, P00712_A131LeaveRequestDuration, P00712_A130LeaveRequestEndDate, P00712_A129LeaveRequestStartDate, P00712_A171LeaveRequestHalfDay,
               P00712_n171LeaveRequestHalfDay, P00712_A125LeaveTypeName, P00712_A127LeaveRequestId
               }
               , new Object[] {
               P00713_A124LeaveTypeId, P00713_A106EmployeeId, P00713_A100CompanyId, P00713_A132LeaveRequestStatus, P00713_A147EmployeeBalance, P00713_A131LeaveRequestDuration, P00713_A130LeaveRequestEndDate, P00713_A129LeaveRequestStartDate, P00713_A171LeaveRequestHalfDay, P00713_n171LeaveRequestHalfDay,
               P00713_A125LeaveTypeName, P00713_A148EmployeeName, P00713_A127LeaveRequestId
               }
               , new Object[] {
               P00714_A124LeaveTypeId, P00714_A132LeaveRequestStatus, P00714_A171LeaveRequestHalfDay, P00714_n171LeaveRequestHalfDay, P00714_A106EmployeeId, P00714_A100CompanyId, P00714_A147EmployeeBalance, P00714_A131LeaveRequestDuration, P00714_A130LeaveRequestEndDate, P00714_A129LeaveRequestStartDate,
               P00714_A125LeaveTypeName, P00714_A148EmployeeName, P00714_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30MaxItems ;
      private short AV29PageIndex ;
      private short AV28SkipItems ;
      private short AV53TFLeaveRequestHalfDayOperator ;
      private short AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator ;
      private int AV56GXV1 ;
      private int AV31InsertIndex ;
      private long AV74Udparg17 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long AV37count ;
      private decimal AV21TFLeaveRequestDuration ;
      private decimal AV22TFLeaveRequestDuration_To ;
      private decimal AV54TFEmployeeBalance ;
      private decimal AV55TFEmployeeBalance_To ;
      private decimal AV70Leaverequestrejectedds_13_tfleaverequestduration ;
      private decimal AV71Leaverequestrejectedds_14_tfleaverequestduration_to ;
      private decimal AV72Leaverequestrejectedds_15_tfemployeebalance ;
      private decimal AV73Leaverequestrejectedds_16_tfemployeebalance_to ;
      private decimal A131LeaveRequestDuration ;
      private decimal A147EmployeeBalance ;
      private string AV11TFEmployeeName ;
      private string AV12TFEmployeeName_Sel ;
      private string AV13TFLeaveTypeName ;
      private string AV14TFLeaveTypeName_Sel ;
      private string AV51TFLeaveRequestHalfDay ;
      private string AV52TFLeaveRequestHalfDay_Sel ;
      private string AV59Leaverequestrejectedds_2_tfemployeename ;
      private string AV60Leaverequestrejectedds_3_tfemployeename_sel ;
      private string AV61Leaverequestrejectedds_4_tfleavetypename ;
      private string AV62Leaverequestrejectedds_5_tfleavetypename_sel ;
      private string AV67Leaverequestrejectedds_10_tfleaverequesthalfday ;
      private string AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel ;
      private string lV59Leaverequestrejectedds_2_tfemployeename ;
      private string lV61Leaverequestrejectedds_4_tfleavetypename ;
      private string lV67Leaverequestrejectedds_10_tfleaverequesthalfday ;
      private string A148EmployeeName ;
      private string A125LeaveTypeName ;
      private string A171LeaveRequestHalfDay ;
      private string A132LeaveRequestStatus ;
      private DateTime AV17TFLeaveRequestStartDate ;
      private DateTime AV18TFLeaveRequestStartDate_To ;
      private DateTime AV19TFLeaveRequestEndDate ;
      private DateTime AV20TFLeaveRequestEndDate_To ;
      private DateTime AV63Leaverequestrejectedds_6_tfleaverequeststartdate ;
      private DateTime AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to ;
      private DateTime AV65Leaverequestrejectedds_8_tfleaverequestenddate ;
      private DateTime AV66Leaverequestrejectedds_9_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool BRK712 ;
      private bool n171LeaveRequestHalfDay ;
      private bool BRK714 ;
      private bool BRK716 ;
      private string AV46OptionsJson ;
      private string AV47OptionsDescJson ;
      private string AV48OptionIndexesJson ;
      private string AV43DDOName ;
      private string AV44SearchTxtParms ;
      private string AV45SearchTxtTo ;
      private string AV27SearchTxt ;
      private string AV49FilterFullText ;
      private string AV58Leaverequestrejectedds_1_filterfulltext ;
      private string lV58Leaverequestrejectedds_1_filterfulltext ;
      private string AV32Option ;
      private IGxSession AV38Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV35OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV40GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private GxSimpleCollection<long> AV50EmployeeIds ;
      private IDataStoreProvider pr_default ;
      private long[] P00712_A124LeaveTypeId ;
      private string[] P00712_A132LeaveRequestStatus ;
      private string[] P00712_A148EmployeeName ;
      private long[] P00712_A106EmployeeId ;
      private long[] P00712_A100CompanyId ;
      private decimal[] P00712_A147EmployeeBalance ;
      private decimal[] P00712_A131LeaveRequestDuration ;
      private DateTime[] P00712_A130LeaveRequestEndDate ;
      private DateTime[] P00712_A129LeaveRequestStartDate ;
      private string[] P00712_A171LeaveRequestHalfDay ;
      private bool[] P00712_n171LeaveRequestHalfDay ;
      private string[] P00712_A125LeaveTypeName ;
      private long[] P00712_A127LeaveRequestId ;
      private long[] P00713_A124LeaveTypeId ;
      private long[] P00713_A106EmployeeId ;
      private long[] P00713_A100CompanyId ;
      private string[] P00713_A132LeaveRequestStatus ;
      private decimal[] P00713_A147EmployeeBalance ;
      private decimal[] P00713_A131LeaveRequestDuration ;
      private DateTime[] P00713_A130LeaveRequestEndDate ;
      private DateTime[] P00713_A129LeaveRequestStartDate ;
      private string[] P00713_A171LeaveRequestHalfDay ;
      private bool[] P00713_n171LeaveRequestHalfDay ;
      private string[] P00713_A125LeaveTypeName ;
      private string[] P00713_A148EmployeeName ;
      private long[] P00713_A127LeaveRequestId ;
      private long[] P00714_A124LeaveTypeId ;
      private string[] P00714_A132LeaveRequestStatus ;
      private string[] P00714_A171LeaveRequestHalfDay ;
      private bool[] P00714_n171LeaveRequestHalfDay ;
      private long[] P00714_A106EmployeeId ;
      private long[] P00714_A100CompanyId ;
      private decimal[] P00714_A147EmployeeBalance ;
      private decimal[] P00714_A131LeaveRequestDuration ;
      private DateTime[] P00714_A130LeaveRequestEndDate ;
      private DateTime[] P00714_A129LeaveRequestStartDate ;
      private string[] P00714_A125LeaveTypeName ;
      private string[] P00714_A148EmployeeName ;
      private long[] P00714_A127LeaveRequestId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class leaverequestrejectedgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00712( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV50EmployeeIds ,
                                             string AV58Leaverequestrejectedds_1_filterfulltext ,
                                             string AV60Leaverequestrejectedds_3_tfemployeename_sel ,
                                             string AV59Leaverequestrejectedds_2_tfemployeename ,
                                             string AV62Leaverequestrejectedds_5_tfleavetypename_sel ,
                                             string AV61Leaverequestrejectedds_4_tfleavetypename ,
                                             DateTime AV63Leaverequestrejectedds_6_tfleaverequeststartdate ,
                                             DateTime AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to ,
                                             DateTime AV65Leaverequestrejectedds_8_tfleaverequestenddate ,
                                             DateTime AV66Leaverequestrejectedds_9_tfleaverequestenddate_to ,
                                             string AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel ,
                                             string AV67Leaverequestrejectedds_10_tfleaverequesthalfday ,
                                             short AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV70Leaverequestrejectedds_13_tfleaverequestduration ,
                                             decimal AV71Leaverequestrejectedds_14_tfleaverequestduration_to ,
                                             decimal AV72Leaverequestrejectedds_15_tfemployeebalance ,
                                             decimal AV73Leaverequestrejectedds_16_tfemployeebalance_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             decimal A147EmployeeBalance ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV74Udparg17 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T3.EmployeeName, T1.EmployeeId, T2.CompanyId, T3.EmployeeBalance, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestHalfDay, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.EmployeeName like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( T2.LeaveTypeName like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.EmployeeBalance,'90.9'), 2) like '%' || :lV58Leaverequestrejectedds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestrejectedds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestrejectedds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV59Leaverequestrejectedds_2_tfemployeename)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestrejectedds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV60Leaverequestrejectedds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV60Leaverequestrejectedds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV60Leaverequestrejectedds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestrejectedds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestrejectedds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV61Leaverequestrejectedds_4_tfleavetypename)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestrejectedds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV62Leaverequestrejectedds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV62Leaverequestrejectedds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62Leaverequestrejectedds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestrejectedds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV63Leaverequestrejectedds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestrejectedds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV65Leaverequestrejectedds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestrejectedds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV66Leaverequestrejectedds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV67Leaverequestrejectedds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestrejectedds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV70Leaverequestrejectedds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestrejectedds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV71Leaverequestrejectedds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV72Leaverequestrejectedds_15_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance >= :AV72Leaverequestrejectedds_15_tfemployeebalance)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Leaverequestrejectedds_16_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance <= :AV73Leaverequestrejectedds_16_tfemployeebalance_to)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV74Udparg17)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.EmployeeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00713( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV50EmployeeIds ,
                                             string AV58Leaverequestrejectedds_1_filterfulltext ,
                                             string AV60Leaverequestrejectedds_3_tfemployeename_sel ,
                                             string AV59Leaverequestrejectedds_2_tfemployeename ,
                                             string AV62Leaverequestrejectedds_5_tfleavetypename_sel ,
                                             string AV61Leaverequestrejectedds_4_tfleavetypename ,
                                             DateTime AV63Leaverequestrejectedds_6_tfleaverequeststartdate ,
                                             DateTime AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to ,
                                             DateTime AV65Leaverequestrejectedds_8_tfleaverequestenddate ,
                                             DateTime AV66Leaverequestrejectedds_9_tfleaverequestenddate_to ,
                                             string AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel ,
                                             string AV67Leaverequestrejectedds_10_tfleaverequesthalfday ,
                                             short AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV70Leaverequestrejectedds_13_tfleaverequestduration ,
                                             decimal AV71Leaverequestrejectedds_14_tfleaverequestduration_to ,
                                             decimal AV72Leaverequestrejectedds_15_tfemployeebalance ,
                                             decimal AV73Leaverequestrejectedds_16_tfemployeebalance_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             decimal A147EmployeeBalance ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV74Udparg17 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestStatus, T3.EmployeeBalance, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestHalfDay, T2.LeaveTypeName, T3.EmployeeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.EmployeeName like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( T2.LeaveTypeName like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.EmployeeBalance,'90.9'), 2) like '%' || :lV58Leaverequestrejectedds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestrejectedds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestrejectedds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV59Leaverequestrejectedds_2_tfemployeename)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestrejectedds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV60Leaverequestrejectedds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV60Leaverequestrejectedds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV60Leaverequestrejectedds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestrejectedds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestrejectedds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV61Leaverequestrejectedds_4_tfleavetypename)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestrejectedds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV62Leaverequestrejectedds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV62Leaverequestrejectedds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62Leaverequestrejectedds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestrejectedds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV63Leaverequestrejectedds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestrejectedds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV65Leaverequestrejectedds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestrejectedds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV66Leaverequestrejectedds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV67Leaverequestrejectedds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestrejectedds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV70Leaverequestrejectedds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestrejectedds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV71Leaverequestrejectedds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV72Leaverequestrejectedds_15_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance >= :AV72Leaverequestrejectedds_15_tfemployeebalance)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Leaverequestrejectedds_16_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance <= :AV73Leaverequestrejectedds_16_tfemployeebalance_to)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV74Udparg17)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00714( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV50EmployeeIds ,
                                             string AV58Leaverequestrejectedds_1_filterfulltext ,
                                             string AV60Leaverequestrejectedds_3_tfemployeename_sel ,
                                             string AV59Leaverequestrejectedds_2_tfemployeename ,
                                             string AV62Leaverequestrejectedds_5_tfleavetypename_sel ,
                                             string AV61Leaverequestrejectedds_4_tfleavetypename ,
                                             DateTime AV63Leaverequestrejectedds_6_tfleaverequeststartdate ,
                                             DateTime AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to ,
                                             DateTime AV65Leaverequestrejectedds_8_tfleaverequestenddate ,
                                             DateTime AV66Leaverequestrejectedds_9_tfleaverequestenddate_to ,
                                             string AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel ,
                                             string AV67Leaverequestrejectedds_10_tfleaverequesthalfday ,
                                             short AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV70Leaverequestrejectedds_13_tfleaverequestduration ,
                                             decimal AV71Leaverequestrejectedds_14_tfleaverequestduration_to ,
                                             decimal AV72Leaverequestrejectedds_15_tfemployeebalance ,
                                             decimal AV73Leaverequestrejectedds_16_tfemployeebalance_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             decimal A147EmployeeBalance ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV74Udparg17 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T1.LeaveRequestHalfDay, T1.EmployeeId, T2.CompanyId, T3.EmployeeBalance, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T3.EmployeeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestrejectedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.EmployeeName like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( T2.LeaveTypeName like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV58Leaverequestrejectedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.EmployeeBalance,'90.9'), 2) like '%' || :lV58Leaverequestrejectedds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestrejectedds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestrejectedds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV59Leaverequestrejectedds_2_tfemployeename)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestrejectedds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV60Leaverequestrejectedds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV60Leaverequestrejectedds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV60Leaverequestrejectedds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestrejectedds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestrejectedds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV61Leaverequestrejectedds_4_tfleavetypename)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestrejectedds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV62Leaverequestrejectedds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV62Leaverequestrejectedds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62Leaverequestrejectedds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestrejectedds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV63Leaverequestrejectedds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestrejectedds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV65Leaverequestrejectedds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestrejectedds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV66Leaverequestrejectedds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestrejectedds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV67Leaverequestrejectedds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV68Leaverequestrejectedds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestrejectedds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV70Leaverequestrejectedds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestrejectedds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV71Leaverequestrejectedds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV72Leaverequestrejectedds_15_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance >= :AV72Leaverequestrejectedds_15_tfemployeebalance)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Leaverequestrejectedds_16_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance <= :AV73Leaverequestrejectedds_16_tfemployeebalance_to)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV74Udparg17)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestHalfDay";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00712(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] );
               case 1 :
                     return conditional_P00713(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] );
               case 2 :
                     return conditional_P00714(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00712;
          prmP00712 = new Object[] {
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestrejectedds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV60Leaverequestrejectedds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV61Leaverequestrejectedds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV62Leaverequestrejectedds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV63Leaverequestrejectedds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV65Leaverequestrejectedds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestrejectedds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV67Leaverequestrejectedds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV70Leaverequestrejectedds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestrejectedds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV72Leaverequestrejectedds_15_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV73Leaverequestrejectedds_16_tfemployeebalance_to",GXType.Number,4,1) ,
          new ParDef("AV74Udparg17",GXType.Int64,10,0)
          };
          Object[] prmP00713;
          prmP00713 = new Object[] {
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestrejectedds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV60Leaverequestrejectedds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV61Leaverequestrejectedds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV62Leaverequestrejectedds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV63Leaverequestrejectedds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV65Leaverequestrejectedds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestrejectedds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV67Leaverequestrejectedds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV70Leaverequestrejectedds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestrejectedds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV72Leaverequestrejectedds_15_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV73Leaverequestrejectedds_16_tfemployeebalance_to",GXType.Number,4,1) ,
          new ParDef("AV74Udparg17",GXType.Int64,10,0)
          };
          Object[] prmP00714;
          prmP00714 = new Object[] {
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestrejectedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestrejectedds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV60Leaverequestrejectedds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV61Leaverequestrejectedds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV62Leaverequestrejectedds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV63Leaverequestrejectedds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV64Leaverequestrejectedds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV65Leaverequestrejectedds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestrejectedds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV67Leaverequestrejectedds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV69Leaverequestrejectedds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV70Leaverequestrejectedds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestrejectedds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV72Leaverequestrejectedds_15_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV73Leaverequestrejectedds_16_tfemployeebalance_to",GXType.Number,4,1) ,
          new ParDef("AV74Udparg17",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00712", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00712,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00713", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00713,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00714", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00714,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
       }
    }

 }

}
