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
   public class leaverequestapprovedgetfilterdata : GXProcedure
   {
      public leaverequestapprovedgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestapprovedgetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28MaxItems = 10;
         AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
         AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_EMPLOYEENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPLOYEENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_LEAVETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_LEAVEREQUESTHALFDAY") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTHALFDAYOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("LeaveRequestApprovedGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "LeaveRequestApprovedGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("LeaveRequestApprovedGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV11TFEmployeeName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV12TFEmployeeName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV13TFLeaveTypeName = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV14TFLeaveTypeName_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV17TFLeaveRequestStartDate = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV18TFLeaveRequestStartDate_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV19TFLeaveRequestEndDate = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV20TFLeaveRequestEndDate_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV51TFLeaveRequestHalfDayOperator = AV39GridStateFilterValue.gxTpr_Operator;
               if ( AV51TFLeaveRequestHalfDayOperator == 0 )
               {
                  AV49TFLeaveRequestHalfDay = AV39GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV50TFLeaveRequestHalfDay_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV21TFLeaveRequestDuration = NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, ".");
               AV22TFLeaveRequestDuration_To = NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEBALANCE") == 0 )
            {
               AV52TFEmployeeBalance = NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, ".");
               AV53TFEmployeeBalance_To = NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADEMPLOYEENAMEOPTIONS' Routine */
         returnInSub = false;
         AV11TFEmployeeName = AV25SearchTxt;
         AV12TFEmployeeName_Sel = "";
         AV56Leaverequestapprovedds_1_filterfulltext = AV47FilterFullText;
         AV57Leaverequestapprovedds_2_tfemployeename = AV11TFEmployeeName;
         AV58Leaverequestapprovedds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV59Leaverequestapprovedds_4_tfleavetypename = AV13TFLeaveTypeName;
         AV60Leaverequestapprovedds_5_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV61Leaverequestapprovedds_6_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV63Leaverequestapprovedds_8_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV64Leaverequestapprovedds_9_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV65Leaverequestapprovedds_10_tfleaverequesthalfday = AV49TFLeaveRequestHalfDay;
         AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator = AV51TFLeaveRequestHalfDayOperator;
         AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel = AV50TFLeaveRequestHalfDay_Sel;
         AV68Leaverequestapprovedds_13_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV69Leaverequestapprovedds_14_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV70Leaverequestapprovedds_15_tfemployeebalance = AV52TFEmployeeBalance;
         AV71Leaverequestapprovedds_16_tfemployeebalance_to = AV53TFEmployeeBalance_To;
         AV72Udparg17 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV48EmployeeIds ,
                                              AV56Leaverequestapprovedds_1_filterfulltext ,
                                              AV58Leaverequestapprovedds_3_tfemployeename_sel ,
                                              AV57Leaverequestapprovedds_2_tfemployeename ,
                                              AV60Leaverequestapprovedds_5_tfleavetypename_sel ,
                                              AV59Leaverequestapprovedds_4_tfleavetypename ,
                                              AV61Leaverequestapprovedds_6_tfleaverequeststartdate ,
                                              AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to ,
                                              AV63Leaverequestapprovedds_8_tfleaverequestenddate ,
                                              AV64Leaverequestapprovedds_9_tfleaverequestenddate_to ,
                                              AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel ,
                                              AV65Leaverequestapprovedds_10_tfleaverequesthalfday ,
                                              AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator ,
                                              AV68Leaverequestapprovedds_13_tfleaverequestduration ,
                                              AV69Leaverequestapprovedds_14_tfleaverequestduration_to ,
                                              AV70Leaverequestapprovedds_15_tfemployeebalance ,
                                              AV71Leaverequestapprovedds_16_tfemployeebalance_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A147EmployeeBalance ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV72Udparg17 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV57Leaverequestapprovedds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV57Leaverequestapprovedds_2_tfemployeename), 100, "%");
         lV59Leaverequestapprovedds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV59Leaverequestapprovedds_4_tfleavetypename), 100, "%");
         lV65Leaverequestapprovedds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV65Leaverequestapprovedds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P006Y2 */
         pr_default.execute(0, new Object[] {lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV57Leaverequestapprovedds_2_tfemployeename, AV58Leaverequestapprovedds_3_tfemployeename_sel, lV59Leaverequestapprovedds_4_tfleavetypename, AV60Leaverequestapprovedds_5_tfleavetypename_sel, AV61Leaverequestapprovedds_6_tfleaverequeststartdate, AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to, AV63Leaverequestapprovedds_8_tfleaverequestenddate, AV64Leaverequestapprovedds_9_tfleaverequestenddate_to, lV65Leaverequestapprovedds_10_tfleaverequesthalfday, AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel, AV68Leaverequestapprovedds_13_tfleaverequestduration, AV69Leaverequestapprovedds_14_tfleaverequestduration_to, AV70Leaverequestapprovedds_15_tfemployeebalance, AV71Leaverequestapprovedds_16_tfemployeebalance_to, AV72Udparg17});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6Y2 = false;
            A124LeaveTypeId = P006Y2_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P006Y2_A132LeaveRequestStatus[0];
            A148EmployeeName = P006Y2_A148EmployeeName[0];
            A106EmployeeId = P006Y2_A106EmployeeId[0];
            A100CompanyId = P006Y2_A100CompanyId[0];
            A147EmployeeBalance = P006Y2_A147EmployeeBalance[0];
            A131LeaveRequestDuration = P006Y2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P006Y2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006Y2_A129LeaveRequestStartDate[0];
            A171LeaveRequestHalfDay = P006Y2_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P006Y2_n171LeaveRequestHalfDay[0];
            A125LeaveTypeName = P006Y2_A125LeaveTypeName[0];
            A127LeaveRequestId = P006Y2_A127LeaveRequestId[0];
            A100CompanyId = P006Y2_A100CompanyId[0];
            A125LeaveTypeName = P006Y2_A125LeaveTypeName[0];
            A148EmployeeName = P006Y2_A148EmployeeName[0];
            A147EmployeeBalance = P006Y2_A147EmployeeBalance[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006Y2_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRK6Y2 = false;
               A106EmployeeId = P006Y2_A106EmployeeId[0];
               A127LeaveRequestId = P006Y2_A127LeaveRequestId[0];
               AV35count = (long)(AV35count+1);
               BRK6Y2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A148EmployeeName)) ? "<#Empty#>" : A148EmployeeName);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK6Y2 )
            {
               BRK6Y2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFLeaveTypeName = AV25SearchTxt;
         AV14TFLeaveTypeName_Sel = "";
         AV56Leaverequestapprovedds_1_filterfulltext = AV47FilterFullText;
         AV57Leaverequestapprovedds_2_tfemployeename = AV11TFEmployeeName;
         AV58Leaverequestapprovedds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV59Leaverequestapprovedds_4_tfleavetypename = AV13TFLeaveTypeName;
         AV60Leaverequestapprovedds_5_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV61Leaverequestapprovedds_6_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV63Leaverequestapprovedds_8_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV64Leaverequestapprovedds_9_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV65Leaverequestapprovedds_10_tfleaverequesthalfday = AV49TFLeaveRequestHalfDay;
         AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator = AV51TFLeaveRequestHalfDayOperator;
         AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel = AV50TFLeaveRequestHalfDay_Sel;
         AV68Leaverequestapprovedds_13_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV69Leaverequestapprovedds_14_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV70Leaverequestapprovedds_15_tfemployeebalance = AV52TFEmployeeBalance;
         AV71Leaverequestapprovedds_16_tfemployeebalance_to = AV53TFEmployeeBalance_To;
         AV72Udparg17 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV48EmployeeIds ,
                                              AV56Leaverequestapprovedds_1_filterfulltext ,
                                              AV58Leaverequestapprovedds_3_tfemployeename_sel ,
                                              AV57Leaverequestapprovedds_2_tfemployeename ,
                                              AV60Leaverequestapprovedds_5_tfleavetypename_sel ,
                                              AV59Leaverequestapprovedds_4_tfleavetypename ,
                                              AV61Leaverequestapprovedds_6_tfleaverequeststartdate ,
                                              AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to ,
                                              AV63Leaverequestapprovedds_8_tfleaverequestenddate ,
                                              AV64Leaverequestapprovedds_9_tfleaverequestenddate_to ,
                                              AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel ,
                                              AV65Leaverequestapprovedds_10_tfleaverequesthalfday ,
                                              AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator ,
                                              AV68Leaverequestapprovedds_13_tfleaverequestduration ,
                                              AV69Leaverequestapprovedds_14_tfleaverequestduration_to ,
                                              AV70Leaverequestapprovedds_15_tfemployeebalance ,
                                              AV71Leaverequestapprovedds_16_tfemployeebalance_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A147EmployeeBalance ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV72Udparg17 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV57Leaverequestapprovedds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV57Leaverequestapprovedds_2_tfemployeename), 100, "%");
         lV59Leaverequestapprovedds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV59Leaverequestapprovedds_4_tfleavetypename), 100, "%");
         lV65Leaverequestapprovedds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV65Leaverequestapprovedds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P006Y3 */
         pr_default.execute(1, new Object[] {lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV57Leaverequestapprovedds_2_tfemployeename, AV58Leaverequestapprovedds_3_tfemployeename_sel, lV59Leaverequestapprovedds_4_tfleavetypename, AV60Leaverequestapprovedds_5_tfleavetypename_sel, AV61Leaverequestapprovedds_6_tfleaverequeststartdate, AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to, AV63Leaverequestapprovedds_8_tfleaverequestenddate, AV64Leaverequestapprovedds_9_tfleaverequestenddate_to, lV65Leaverequestapprovedds_10_tfleaverequesthalfday, AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel, AV68Leaverequestapprovedds_13_tfleaverequestduration, AV69Leaverequestapprovedds_14_tfleaverequestduration_to, AV70Leaverequestapprovedds_15_tfemployeebalance, AV71Leaverequestapprovedds_16_tfemployeebalance_to, AV72Udparg17});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6Y4 = false;
            A124LeaveTypeId = P006Y3_A124LeaveTypeId[0];
            A106EmployeeId = P006Y3_A106EmployeeId[0];
            A100CompanyId = P006Y3_A100CompanyId[0];
            A132LeaveRequestStatus = P006Y3_A132LeaveRequestStatus[0];
            A147EmployeeBalance = P006Y3_A147EmployeeBalance[0];
            A131LeaveRequestDuration = P006Y3_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P006Y3_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006Y3_A129LeaveRequestStartDate[0];
            A171LeaveRequestHalfDay = P006Y3_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P006Y3_n171LeaveRequestHalfDay[0];
            A125LeaveTypeName = P006Y3_A125LeaveTypeName[0];
            A148EmployeeName = P006Y3_A148EmployeeName[0];
            A127LeaveRequestId = P006Y3_A127LeaveRequestId[0];
            A100CompanyId = P006Y3_A100CompanyId[0];
            A125LeaveTypeName = P006Y3_A125LeaveTypeName[0];
            A147EmployeeBalance = P006Y3_A147EmployeeBalance[0];
            A148EmployeeName = P006Y3_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P006Y3_A124LeaveTypeId[0] == A124LeaveTypeId ) )
            {
               BRK6Y4 = false;
               A127LeaveRequestId = P006Y3_A127LeaveRequestId[0];
               AV35count = (long)(AV35count+1);
               BRK6Y4 = true;
               pr_default.readNext(1);
            }
            AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) ? "<#Empty#>" : A125LeaveTypeName);
            AV29InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV30Option, "<#Empty#>") != 0 ) && ( AV29InsertIndex <= AV31Options.Count ) && ( ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), AV30Option) < 0 ) || ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV29InsertIndex = (int)(AV29InsertIndex+1);
            }
            AV31Options.Add(AV30Option, AV29InsertIndex);
            AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), AV29InsertIndex);
            if ( AV31Options.Count == AV26SkipItems + 11 )
            {
               AV31Options.RemoveItem(AV31Options.Count);
               AV34OptionIndexes.RemoveItem(AV34OptionIndexes.Count);
            }
            if ( ! BRK6Y4 )
            {
               BRK6Y4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV26SkipItems > 0 )
         {
            AV31Options.RemoveItem(1);
            AV34OptionIndexes.RemoveItem(1);
            AV26SkipItems = (short)(AV26SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADLEAVEREQUESTHALFDAYOPTIONS' Routine */
         returnInSub = false;
         AV49TFLeaveRequestHalfDay = AV25SearchTxt;
         AV51TFLeaveRequestHalfDayOperator = 0;
         AV50TFLeaveRequestHalfDay_Sel = "";
         AV56Leaverequestapprovedds_1_filterfulltext = AV47FilterFullText;
         AV57Leaverequestapprovedds_2_tfemployeename = AV11TFEmployeeName;
         AV58Leaverequestapprovedds_3_tfemployeename_sel = AV12TFEmployeeName_Sel;
         AV59Leaverequestapprovedds_4_tfleavetypename = AV13TFLeaveTypeName;
         AV60Leaverequestapprovedds_5_tfleavetypename_sel = AV14TFLeaveTypeName_Sel;
         AV61Leaverequestapprovedds_6_tfleaverequeststartdate = AV17TFLeaveRequestStartDate;
         AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to = AV18TFLeaveRequestStartDate_To;
         AV63Leaverequestapprovedds_8_tfleaverequestenddate = AV19TFLeaveRequestEndDate;
         AV64Leaverequestapprovedds_9_tfleaverequestenddate_to = AV20TFLeaveRequestEndDate_To;
         AV65Leaverequestapprovedds_10_tfleaverequesthalfday = AV49TFLeaveRequestHalfDay;
         AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator = AV51TFLeaveRequestHalfDayOperator;
         AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel = AV50TFLeaveRequestHalfDay_Sel;
         AV68Leaverequestapprovedds_13_tfleaverequestduration = AV21TFLeaveRequestDuration;
         AV69Leaverequestapprovedds_14_tfleaverequestduration_to = AV22TFLeaveRequestDuration_To;
         AV70Leaverequestapprovedds_15_tfemployeebalance = AV52TFEmployeeBalance;
         AV71Leaverequestapprovedds_16_tfemployeebalance_to = AV53TFEmployeeBalance_To;
         AV72Udparg17 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV48EmployeeIds ,
                                              AV56Leaverequestapprovedds_1_filterfulltext ,
                                              AV58Leaverequestapprovedds_3_tfemployeename_sel ,
                                              AV57Leaverequestapprovedds_2_tfemployeename ,
                                              AV60Leaverequestapprovedds_5_tfleavetypename_sel ,
                                              AV59Leaverequestapprovedds_4_tfleavetypename ,
                                              AV61Leaverequestapprovedds_6_tfleaverequeststartdate ,
                                              AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to ,
                                              AV63Leaverequestapprovedds_8_tfleaverequestenddate ,
                                              AV64Leaverequestapprovedds_9_tfleaverequestenddate_to ,
                                              AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel ,
                                              AV65Leaverequestapprovedds_10_tfleaverequesthalfday ,
                                              AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator ,
                                              AV68Leaverequestapprovedds_13_tfleaverequestduration ,
                                              AV69Leaverequestapprovedds_14_tfleaverequestduration_to ,
                                              AV70Leaverequestapprovedds_15_tfemployeebalance ,
                                              AV71Leaverequestapprovedds_16_tfemployeebalance_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A147EmployeeBalance ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV72Udparg17 ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV56Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV57Leaverequestapprovedds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV57Leaverequestapprovedds_2_tfemployeename), 100, "%");
         lV59Leaverequestapprovedds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV59Leaverequestapprovedds_4_tfleavetypename), 100, "%");
         lV65Leaverequestapprovedds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV65Leaverequestapprovedds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P006Y4 */
         pr_default.execute(2, new Object[] {lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV56Leaverequestapprovedds_1_filterfulltext, lV57Leaverequestapprovedds_2_tfemployeename, AV58Leaverequestapprovedds_3_tfemployeename_sel, lV59Leaverequestapprovedds_4_tfleavetypename, AV60Leaverequestapprovedds_5_tfleavetypename_sel, AV61Leaverequestapprovedds_6_tfleaverequeststartdate, AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to, AV63Leaverequestapprovedds_8_tfleaverequestenddate, AV64Leaverequestapprovedds_9_tfleaverequestenddate_to, lV65Leaverequestapprovedds_10_tfleaverequesthalfday, AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel, AV68Leaverequestapprovedds_13_tfleaverequestduration, AV69Leaverequestapprovedds_14_tfleaverequestduration_to, AV70Leaverequestapprovedds_15_tfemployeebalance, AV71Leaverequestapprovedds_16_tfemployeebalance_to, AV72Udparg17});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6Y6 = false;
            A124LeaveTypeId = P006Y4_A124LeaveTypeId[0];
            A132LeaveRequestStatus = P006Y4_A132LeaveRequestStatus[0];
            A171LeaveRequestHalfDay = P006Y4_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P006Y4_n171LeaveRequestHalfDay[0];
            A106EmployeeId = P006Y4_A106EmployeeId[0];
            A100CompanyId = P006Y4_A100CompanyId[0];
            A147EmployeeBalance = P006Y4_A147EmployeeBalance[0];
            A131LeaveRequestDuration = P006Y4_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P006Y4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006Y4_A129LeaveRequestStartDate[0];
            A125LeaveTypeName = P006Y4_A125LeaveTypeName[0];
            A148EmployeeName = P006Y4_A148EmployeeName[0];
            A127LeaveRequestId = P006Y4_A127LeaveRequestId[0];
            A100CompanyId = P006Y4_A100CompanyId[0];
            A125LeaveTypeName = P006Y4_A125LeaveTypeName[0];
            A147EmployeeBalance = P006Y4_A147EmployeeBalance[0];
            A148EmployeeName = P006Y4_A148EmployeeName[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006Y4_A171LeaveRequestHalfDay[0], A171LeaveRequestHalfDay) == 0 ) )
            {
               BRK6Y6 = false;
               A127LeaveRequestId = P006Y4_A127LeaveRequestId[0];
               AV35count = (long)(AV35count+1);
               BRK6Y6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A171LeaveRequestHalfDay)) ? "<#Empty#>" : A171LeaveRequestHalfDay);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK6Y6 )
            {
               BRK6Y6 = true;
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV39GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV11TFEmployeeName = "";
         AV12TFEmployeeName_Sel = "";
         AV13TFLeaveTypeName = "";
         AV14TFLeaveTypeName_Sel = "";
         AV17TFLeaveRequestStartDate = DateTime.MinValue;
         AV18TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV19TFLeaveRequestEndDate = DateTime.MinValue;
         AV20TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV49TFLeaveRequestHalfDay = "";
         AV50TFLeaveRequestHalfDay_Sel = "";
         AV56Leaverequestapprovedds_1_filterfulltext = "";
         AV57Leaverequestapprovedds_2_tfemployeename = "";
         AV58Leaverequestapprovedds_3_tfemployeename_sel = "";
         AV59Leaverequestapprovedds_4_tfleavetypename = "";
         AV60Leaverequestapprovedds_5_tfleavetypename_sel = "";
         AV61Leaverequestapprovedds_6_tfleaverequeststartdate = DateTime.MinValue;
         AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to = DateTime.MinValue;
         AV63Leaverequestapprovedds_8_tfleaverequestenddate = DateTime.MinValue;
         AV64Leaverequestapprovedds_9_tfleaverequestenddate_to = DateTime.MinValue;
         AV65Leaverequestapprovedds_10_tfleaverequesthalfday = "";
         AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel = "";
         lV56Leaverequestapprovedds_1_filterfulltext = "";
         lV57Leaverequestapprovedds_2_tfemployeename = "";
         lV59Leaverequestapprovedds_4_tfleavetypename = "";
         lV65Leaverequestapprovedds_10_tfleaverequesthalfday = "";
         AV48EmployeeIds = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         A125LeaveTypeName = "";
         A171LeaveRequestHalfDay = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         P006Y2_A124LeaveTypeId = new long[1] ;
         P006Y2_A132LeaveRequestStatus = new string[] {""} ;
         P006Y2_A148EmployeeName = new string[] {""} ;
         P006Y2_A106EmployeeId = new long[1] ;
         P006Y2_A100CompanyId = new long[1] ;
         P006Y2_A147EmployeeBalance = new decimal[1] ;
         P006Y2_A131LeaveRequestDuration = new decimal[1] ;
         P006Y2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006Y2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006Y2_A171LeaveRequestHalfDay = new string[] {""} ;
         P006Y2_n171LeaveRequestHalfDay = new bool[] {false} ;
         P006Y2_A125LeaveTypeName = new string[] {""} ;
         P006Y2_A127LeaveRequestId = new long[1] ;
         AV30Option = "";
         P006Y3_A124LeaveTypeId = new long[1] ;
         P006Y3_A106EmployeeId = new long[1] ;
         P006Y3_A100CompanyId = new long[1] ;
         P006Y3_A132LeaveRequestStatus = new string[] {""} ;
         P006Y3_A147EmployeeBalance = new decimal[1] ;
         P006Y3_A131LeaveRequestDuration = new decimal[1] ;
         P006Y3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006Y3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006Y3_A171LeaveRequestHalfDay = new string[] {""} ;
         P006Y3_n171LeaveRequestHalfDay = new bool[] {false} ;
         P006Y3_A125LeaveTypeName = new string[] {""} ;
         P006Y3_A148EmployeeName = new string[] {""} ;
         P006Y3_A127LeaveRequestId = new long[1] ;
         P006Y4_A124LeaveTypeId = new long[1] ;
         P006Y4_A132LeaveRequestStatus = new string[] {""} ;
         P006Y4_A171LeaveRequestHalfDay = new string[] {""} ;
         P006Y4_n171LeaveRequestHalfDay = new bool[] {false} ;
         P006Y4_A106EmployeeId = new long[1] ;
         P006Y4_A100CompanyId = new long[1] ;
         P006Y4_A147EmployeeBalance = new decimal[1] ;
         P006Y4_A131LeaveRequestDuration = new decimal[1] ;
         P006Y4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006Y4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006Y4_A125LeaveTypeName = new string[] {""} ;
         P006Y4_A148EmployeeName = new string[] {""} ;
         P006Y4_A127LeaveRequestId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestapprovedgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006Y2_A124LeaveTypeId, P006Y2_A132LeaveRequestStatus, P006Y2_A148EmployeeName, P006Y2_A106EmployeeId, P006Y2_A100CompanyId, P006Y2_A147EmployeeBalance, P006Y2_A131LeaveRequestDuration, P006Y2_A130LeaveRequestEndDate, P006Y2_A129LeaveRequestStartDate, P006Y2_A171LeaveRequestHalfDay,
               P006Y2_n171LeaveRequestHalfDay, P006Y2_A125LeaveTypeName, P006Y2_A127LeaveRequestId
               }
               , new Object[] {
               P006Y3_A124LeaveTypeId, P006Y3_A106EmployeeId, P006Y3_A100CompanyId, P006Y3_A132LeaveRequestStatus, P006Y3_A147EmployeeBalance, P006Y3_A131LeaveRequestDuration, P006Y3_A130LeaveRequestEndDate, P006Y3_A129LeaveRequestStartDate, P006Y3_A171LeaveRequestHalfDay, P006Y3_n171LeaveRequestHalfDay,
               P006Y3_A125LeaveTypeName, P006Y3_A148EmployeeName, P006Y3_A127LeaveRequestId
               }
               , new Object[] {
               P006Y4_A124LeaveTypeId, P006Y4_A132LeaveRequestStatus, P006Y4_A171LeaveRequestHalfDay, P006Y4_n171LeaveRequestHalfDay, P006Y4_A106EmployeeId, P006Y4_A100CompanyId, P006Y4_A147EmployeeBalance, P006Y4_A131LeaveRequestDuration, P006Y4_A130LeaveRequestEndDate, P006Y4_A129LeaveRequestStartDate,
               P006Y4_A125LeaveTypeName, P006Y4_A148EmployeeName, P006Y4_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV51TFLeaveRequestHalfDayOperator ;
      private short AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator ;
      private int AV54GXV1 ;
      private int AV29InsertIndex ;
      private long AV72Udparg17 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long AV35count ;
      private decimal AV21TFLeaveRequestDuration ;
      private decimal AV22TFLeaveRequestDuration_To ;
      private decimal AV52TFEmployeeBalance ;
      private decimal AV53TFEmployeeBalance_To ;
      private decimal AV68Leaverequestapprovedds_13_tfleaverequestduration ;
      private decimal AV69Leaverequestapprovedds_14_tfleaverequestduration_to ;
      private decimal AV70Leaverequestapprovedds_15_tfemployeebalance ;
      private decimal AV71Leaverequestapprovedds_16_tfemployeebalance_to ;
      private decimal A131LeaveRequestDuration ;
      private decimal A147EmployeeBalance ;
      private string AV11TFEmployeeName ;
      private string AV12TFEmployeeName_Sel ;
      private string AV13TFLeaveTypeName ;
      private string AV14TFLeaveTypeName_Sel ;
      private string AV49TFLeaveRequestHalfDay ;
      private string AV50TFLeaveRequestHalfDay_Sel ;
      private string AV57Leaverequestapprovedds_2_tfemployeename ;
      private string AV58Leaverequestapprovedds_3_tfemployeename_sel ;
      private string AV59Leaverequestapprovedds_4_tfleavetypename ;
      private string AV60Leaverequestapprovedds_5_tfleavetypename_sel ;
      private string AV65Leaverequestapprovedds_10_tfleaverequesthalfday ;
      private string AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel ;
      private string lV57Leaverequestapprovedds_2_tfemployeename ;
      private string lV59Leaverequestapprovedds_4_tfleavetypename ;
      private string lV65Leaverequestapprovedds_10_tfleaverequesthalfday ;
      private string A148EmployeeName ;
      private string A125LeaveTypeName ;
      private string A171LeaveRequestHalfDay ;
      private string A132LeaveRequestStatus ;
      private DateTime AV17TFLeaveRequestStartDate ;
      private DateTime AV18TFLeaveRequestStartDate_To ;
      private DateTime AV19TFLeaveRequestEndDate ;
      private DateTime AV20TFLeaveRequestEndDate_To ;
      private DateTime AV61Leaverequestapprovedds_6_tfleaverequeststartdate ;
      private DateTime AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to ;
      private DateTime AV63Leaverequestapprovedds_8_tfleaverequestenddate ;
      private DateTime AV64Leaverequestapprovedds_9_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool BRK6Y2 ;
      private bool n171LeaveRequestHalfDay ;
      private bool BRK6Y4 ;
      private bool BRK6Y6 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV56Leaverequestapprovedds_1_filterfulltext ;
      private string lV56Leaverequestapprovedds_1_filterfulltext ;
      private string AV30Option ;
      private IGxSession AV36Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV38GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GxSimpleCollection<long> AV48EmployeeIds ;
      private IDataStoreProvider pr_default ;
      private long[] P006Y2_A124LeaveTypeId ;
      private string[] P006Y2_A132LeaveRequestStatus ;
      private string[] P006Y2_A148EmployeeName ;
      private long[] P006Y2_A106EmployeeId ;
      private long[] P006Y2_A100CompanyId ;
      private decimal[] P006Y2_A147EmployeeBalance ;
      private decimal[] P006Y2_A131LeaveRequestDuration ;
      private DateTime[] P006Y2_A130LeaveRequestEndDate ;
      private DateTime[] P006Y2_A129LeaveRequestStartDate ;
      private string[] P006Y2_A171LeaveRequestHalfDay ;
      private bool[] P006Y2_n171LeaveRequestHalfDay ;
      private string[] P006Y2_A125LeaveTypeName ;
      private long[] P006Y2_A127LeaveRequestId ;
      private long[] P006Y3_A124LeaveTypeId ;
      private long[] P006Y3_A106EmployeeId ;
      private long[] P006Y3_A100CompanyId ;
      private string[] P006Y3_A132LeaveRequestStatus ;
      private decimal[] P006Y3_A147EmployeeBalance ;
      private decimal[] P006Y3_A131LeaveRequestDuration ;
      private DateTime[] P006Y3_A130LeaveRequestEndDate ;
      private DateTime[] P006Y3_A129LeaveRequestStartDate ;
      private string[] P006Y3_A171LeaveRequestHalfDay ;
      private bool[] P006Y3_n171LeaveRequestHalfDay ;
      private string[] P006Y3_A125LeaveTypeName ;
      private string[] P006Y3_A148EmployeeName ;
      private long[] P006Y3_A127LeaveRequestId ;
      private long[] P006Y4_A124LeaveTypeId ;
      private string[] P006Y4_A132LeaveRequestStatus ;
      private string[] P006Y4_A171LeaveRequestHalfDay ;
      private bool[] P006Y4_n171LeaveRequestHalfDay ;
      private long[] P006Y4_A106EmployeeId ;
      private long[] P006Y4_A100CompanyId ;
      private decimal[] P006Y4_A147EmployeeBalance ;
      private decimal[] P006Y4_A131LeaveRequestDuration ;
      private DateTime[] P006Y4_A130LeaveRequestEndDate ;
      private DateTime[] P006Y4_A129LeaveRequestStartDate ;
      private string[] P006Y4_A125LeaveTypeName ;
      private string[] P006Y4_A148EmployeeName ;
      private long[] P006Y4_A127LeaveRequestId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class leaverequestapprovedgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006Y2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV48EmployeeIds ,
                                             string AV56Leaverequestapprovedds_1_filterfulltext ,
                                             string AV58Leaverequestapprovedds_3_tfemployeename_sel ,
                                             string AV57Leaverequestapprovedds_2_tfemployeename ,
                                             string AV60Leaverequestapprovedds_5_tfleavetypename_sel ,
                                             string AV59Leaverequestapprovedds_4_tfleavetypename ,
                                             DateTime AV61Leaverequestapprovedds_6_tfleaverequeststartdate ,
                                             DateTime AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to ,
                                             DateTime AV63Leaverequestapprovedds_8_tfleaverequestenddate ,
                                             DateTime AV64Leaverequestapprovedds_9_tfleaverequestenddate_to ,
                                             string AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel ,
                                             string AV65Leaverequestapprovedds_10_tfleaverequesthalfday ,
                                             short AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV68Leaverequestapprovedds_13_tfleaverequestduration ,
                                             decimal AV69Leaverequestapprovedds_14_tfleaverequestduration_to ,
                                             decimal AV70Leaverequestapprovedds_15_tfemployeebalance ,
                                             decimal AV71Leaverequestapprovedds_16_tfemployeebalance_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             decimal A147EmployeeBalance ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV72Udparg17 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T3.EmployeeName, T1.EmployeeId, T2.CompanyId, T3.EmployeeBalance, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestHalfDay, T2.LeaveTypeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.EmployeeName like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( T2.LeaveTypeName like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.EmployeeBalance,'90.9'), 2) like '%' || :lV56Leaverequestapprovedds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestapprovedds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leaverequestapprovedds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV57Leaverequestapprovedds_2_tfemployeename)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestapprovedds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV58Leaverequestapprovedds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV58Leaverequestapprovedds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV58Leaverequestapprovedds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestapprovedds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestapprovedds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV59Leaverequestapprovedds_4_tfleavetypename)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestapprovedds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV60Leaverequestapprovedds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV60Leaverequestapprovedds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV60Leaverequestapprovedds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV61Leaverequestapprovedds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV61Leaverequestapprovedds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestapprovedds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV63Leaverequestapprovedds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestapprovedds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV64Leaverequestapprovedds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestapprovedds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV65Leaverequestapprovedds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV68Leaverequestapprovedds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV68Leaverequestapprovedds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV69Leaverequestapprovedds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV69Leaverequestapprovedds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestapprovedds_15_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance >= :AV70Leaverequestapprovedds_15_tfemployeebalance)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestapprovedds_16_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance <= :AV71Leaverequestapprovedds_16_tfemployeebalance_to)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV72Udparg17)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV48EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.EmployeeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006Y3( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV48EmployeeIds ,
                                             string AV56Leaverequestapprovedds_1_filterfulltext ,
                                             string AV58Leaverequestapprovedds_3_tfemployeename_sel ,
                                             string AV57Leaverequestapprovedds_2_tfemployeename ,
                                             string AV60Leaverequestapprovedds_5_tfleavetypename_sel ,
                                             string AV59Leaverequestapprovedds_4_tfleavetypename ,
                                             DateTime AV61Leaverequestapprovedds_6_tfleaverequeststartdate ,
                                             DateTime AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to ,
                                             DateTime AV63Leaverequestapprovedds_8_tfleaverequestenddate ,
                                             DateTime AV64Leaverequestapprovedds_9_tfleaverequestenddate_to ,
                                             string AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel ,
                                             string AV65Leaverequestapprovedds_10_tfleaverequesthalfday ,
                                             short AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV68Leaverequestapprovedds_13_tfleaverequestduration ,
                                             decimal AV69Leaverequestapprovedds_14_tfleaverequestduration_to ,
                                             decimal AV70Leaverequestapprovedds_15_tfemployeebalance ,
                                             decimal AV71Leaverequestapprovedds_16_tfemployeebalance_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             decimal A147EmployeeBalance ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV72Udparg17 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestStatus, T3.EmployeeBalance, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestHalfDay, T2.LeaveTypeName, T3.EmployeeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.EmployeeName like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( T2.LeaveTypeName like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.EmployeeBalance,'90.9'), 2) like '%' || :lV56Leaverequestapprovedds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestapprovedds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leaverequestapprovedds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV57Leaverequestapprovedds_2_tfemployeename)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestapprovedds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV58Leaverequestapprovedds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV58Leaverequestapprovedds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV58Leaverequestapprovedds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestapprovedds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestapprovedds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV59Leaverequestapprovedds_4_tfleavetypename)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestapprovedds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV60Leaverequestapprovedds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV60Leaverequestapprovedds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV60Leaverequestapprovedds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV61Leaverequestapprovedds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV61Leaverequestapprovedds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestapprovedds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV63Leaverequestapprovedds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestapprovedds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV64Leaverequestapprovedds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestapprovedds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV65Leaverequestapprovedds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV68Leaverequestapprovedds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV68Leaverequestapprovedds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV69Leaverequestapprovedds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV69Leaverequestapprovedds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestapprovedds_15_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance >= :AV70Leaverequestapprovedds_15_tfemployeebalance)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestapprovedds_16_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance <= :AV71Leaverequestapprovedds_16_tfemployeebalance_to)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV72Udparg17)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV48EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveTypeId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006Y4( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV48EmployeeIds ,
                                             string AV56Leaverequestapprovedds_1_filterfulltext ,
                                             string AV58Leaverequestapprovedds_3_tfemployeename_sel ,
                                             string AV57Leaverequestapprovedds_2_tfemployeename ,
                                             string AV60Leaverequestapprovedds_5_tfleavetypename_sel ,
                                             string AV59Leaverequestapprovedds_4_tfleavetypename ,
                                             DateTime AV61Leaverequestapprovedds_6_tfleaverequeststartdate ,
                                             DateTime AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to ,
                                             DateTime AV63Leaverequestapprovedds_8_tfleaverequestenddate ,
                                             DateTime AV64Leaverequestapprovedds_9_tfleaverequestenddate_to ,
                                             string AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel ,
                                             string AV65Leaverequestapprovedds_10_tfleaverequesthalfday ,
                                             short AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV68Leaverequestapprovedds_13_tfleaverequestduration ,
                                             decimal AV69Leaverequestapprovedds_14_tfleaverequestduration_to ,
                                             decimal AV70Leaverequestapprovedds_15_tfemployeebalance ,
                                             decimal AV71Leaverequestapprovedds_16_tfemployeebalance_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             decimal A147EmployeeBalance ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV72Udparg17 ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.LeaveRequestStatus, T1.LeaveRequestHalfDay, T1.EmployeeId, T2.CompanyId, T3.EmployeeBalance, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T2.LeaveTypeName, T3.EmployeeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Leaverequestapprovedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.EmployeeName like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( T2.LeaveTypeName like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV56Leaverequestapprovedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.EmployeeBalance,'90.9'), 2) like '%' || :lV56Leaverequestapprovedds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestapprovedds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leaverequestapprovedds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV57Leaverequestapprovedds_2_tfemployeename)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestapprovedds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV58Leaverequestapprovedds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV58Leaverequestapprovedds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV58Leaverequestapprovedds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestapprovedds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestapprovedds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV59Leaverequestapprovedds_4_tfleavetypename)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestapprovedds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV60Leaverequestapprovedds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV60Leaverequestapprovedds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV60Leaverequestapprovedds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV61Leaverequestapprovedds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV61Leaverequestapprovedds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestapprovedds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV63Leaverequestapprovedds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestapprovedds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV64Leaverequestapprovedds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestapprovedds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV65Leaverequestapprovedds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV66Leaverequestapprovedds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV68Leaverequestapprovedds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV68Leaverequestapprovedds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV69Leaverequestapprovedds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV69Leaverequestapprovedds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestapprovedds_15_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance >= :AV70Leaverequestapprovedds_15_tfemployeebalance)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestapprovedds_16_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance <= :AV71Leaverequestapprovedds_16_tfemployeebalance_to)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV72Udparg17)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV48EmployeeIds, "T1.EmployeeId IN (", ")")+")");
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
                     return conditional_P006Y2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] );
               case 1 :
                     return conditional_P006Y3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] );
               case 2 :
                     return conditional_P006Y4(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] );
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
          Object[] prmP006Y2;
          prmP006Y2 = new Object[] {
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Leaverequestapprovedds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV58Leaverequestapprovedds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV59Leaverequestapprovedds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV60Leaverequestapprovedds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV61Leaverequestapprovedds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV63Leaverequestapprovedds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV64Leaverequestapprovedds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV65Leaverequestapprovedds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV68Leaverequestapprovedds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV69Leaverequestapprovedds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV70Leaverequestapprovedds_15_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestapprovedds_16_tfemployeebalance_to",GXType.Number,4,1) ,
          new ParDef("AV72Udparg17",GXType.Int64,10,0)
          };
          Object[] prmP006Y3;
          prmP006Y3 = new Object[] {
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Leaverequestapprovedds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV58Leaverequestapprovedds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV59Leaverequestapprovedds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV60Leaverequestapprovedds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV61Leaverequestapprovedds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV63Leaverequestapprovedds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV64Leaverequestapprovedds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV65Leaverequestapprovedds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV68Leaverequestapprovedds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV69Leaverequestapprovedds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV70Leaverequestapprovedds_15_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestapprovedds_16_tfemployeebalance_to",GXType.Number,4,1) ,
          new ParDef("AV72Udparg17",GXType.Int64,10,0)
          };
          Object[] prmP006Y4;
          prmP006Y4 = new Object[] {
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Leaverequestapprovedds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV58Leaverequestapprovedds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV59Leaverequestapprovedds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV60Leaverequestapprovedds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV61Leaverequestapprovedds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV62Leaverequestapprovedds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV63Leaverequestapprovedds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV64Leaverequestapprovedds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV65Leaverequestapprovedds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV67Leaverequestapprovedds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV68Leaverequestapprovedds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV69Leaverequestapprovedds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV70Leaverequestapprovedds_15_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestapprovedds_16_tfemployeebalance_to",GXType.Number,4,1) ,
          new ParDef("AV72Udparg17",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Y4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Y4,100, GxCacheFrequency.OFF ,true,false )
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
