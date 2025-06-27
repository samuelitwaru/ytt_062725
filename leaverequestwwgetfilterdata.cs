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
   public class leaverequestwwgetfilterdata : GXProcedure
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
            return "leaverequestww_Services_Execute" ;
         }

      }

      public leaverequestwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestwwgetfilterdata( IGxContext context )
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
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV54OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV39Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36MaxItems = 10;
         AV35PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV50SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV33SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? "" : StringUtil.Substring( AV50SearchTxtParms, 3, -1));
         AV34SkipItems = (short)(AV35PageIndex*AV36MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_LEAVETYPENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVETYPENAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_LEAVEREQUESTHALFDAY") == 0 )
         {
            /* Execute user subroutine: 'LOADLEAVEREQUESTHALFDAYOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV52OptionsJson = AV39Options.ToJSonString(false);
         AV53OptionsDescJson = AV41OptionsDesc.ToJSonString(false);
         AV54OptionIndexesJson = AV42OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV44Session.Get("LeaveRequestWWGridState"), "") == 0 )
         {
            AV46GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "LeaveRequestWWGridState"), null, "", "");
         }
         else
         {
            AV46GridState.FromXml(AV44Session.Get("LeaveRequestWWGridState"), null, "", "");
         }
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV46GridState.gxTpr_Filtervalues.Count )
         {
            AV47GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV46GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV55FilterFullText = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV15TFLeaveTypeName = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV16TFLeaveTypeName_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV19TFLeaveRequestStartDate = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Value, 2);
               AV20TFLeaveRequestStartDate_To = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV21TFLeaveRequestEndDate = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Value, 2);
               AV22TFLeaveRequestEndDate_To = context.localUtil.CToD( AV47GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV60TFLeaveRequestHalfDayOperator = AV47GridStateFilterValue.gxTpr_Operator;
               if ( AV60TFLeaveRequestHalfDayOperator == 0 )
               {
                  AV56TFLeaveRequestHalfDay = AV47GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV57TFLeaveRequestHalfDay_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV23TFLeaveRequestDuration = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, ".");
               AV24TFLeaveRequestDuration_To = NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTATUS") == 0 )
            {
               AV59TFLeaveRequestStatusOperator = AV47GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTATUS_SEL") == 0 )
            {
               AV25TFLeaveRequestStatus_SelsJson = AV47GridStateFilterValue.gxTpr_Value;
               AV26TFLeaveRequestStatus_Sels.FromJSonString(AV25TFLeaveRequestStatus_SelsJson, null);
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADLEAVETYPENAMEOPTIONS' Routine */
         returnInSub = false;
         AV15TFLeaveTypeName = AV33SearchTxt;
         AV16TFLeaveTypeName_Sel = "";
         AV65Leaverequestwwds_1_filterfulltext = AV55FilterFullText;
         AV66Leaverequestwwds_2_tfleavetypename = AV15TFLeaveTypeName;
         AV67Leaverequestwwds_3_tfleavetypename_sel = AV16TFLeaveTypeName_Sel;
         AV68Leaverequestwwds_4_tfleaverequeststartdate = AV19TFLeaveRequestStartDate;
         AV69Leaverequestwwds_5_tfleaverequeststartdate_to = AV20TFLeaveRequestStartDate_To;
         AV70Leaverequestwwds_6_tfleaverequestenddate = AV21TFLeaveRequestEndDate;
         AV71Leaverequestwwds_7_tfleaverequestenddate_to = AV22TFLeaveRequestEndDate_To;
         AV72Leaverequestwwds_8_tfleaverequesthalfday = AV56TFLeaveRequestHalfDay;
         AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator = AV60TFLeaveRequestHalfDayOperator;
         AV74Leaverequestwwds_10_tfleaverequesthalfday_sel = AV57TFLeaveRequestHalfDay_Sel;
         AV75Leaverequestwwds_11_tfleaverequestduration = AV23TFLeaveRequestDuration;
         AV76Leaverequestwwds_12_tfleaverequestduration_to = AV24TFLeaveRequestDuration_To;
         AV77Leaverequestwwds_13_tfleaverequeststatus = AV58TFLeaveRequestStatus;
         AV78Leaverequestwwds_14_tfleaverequeststatusoperator = AV59TFLeaveRequestStatusOperator;
         AV79Leaverequestwwds_15_tfleaverequeststatus_sels = AV26TFLeaveRequestStatus_Sels;
         AV80Udparg16 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV79Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                              AV65Leaverequestwwds_1_filterfulltext ,
                                              AV67Leaverequestwwds_3_tfleavetypename_sel ,
                                              AV66Leaverequestwwds_2_tfleavetypename ,
                                              AV68Leaverequestwwds_4_tfleaverequeststartdate ,
                                              AV69Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                              AV70Leaverequestwwds_6_tfleaverequestenddate ,
                                              AV71Leaverequestwwds_7_tfleaverequestenddate_to ,
                                              AV74Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                              AV72Leaverequestwwds_8_tfleaverequesthalfday ,
                                              AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                              AV75Leaverequestwwds_11_tfleaverequestduration ,
                                              AV76Leaverequestwwds_12_tfleaverequestduration_to ,
                                              AV79Leaverequestwwds_15_tfleaverequeststatus_sels.Count ,
                                              AV78Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A106EmployeeId ,
                                              AV80Udparg16 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV66Leaverequestwwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV66Leaverequestwwds_2_tfleavetypename), 100, "%");
         lV72Leaverequestwwds_8_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV72Leaverequestwwds_8_tfleaverequesthalfday), 20, "%");
         /* Using cursor P008C2 */
         pr_default.execute(0, new Object[] {AV80Udparg16, lV65Leaverequestwwds_1_filterfulltext, lV65Leaverequestwwds_1_filterfulltext, lV65Leaverequestwwds_1_filterfulltext, lV65Leaverequestwwds_1_filterfulltext, lV65Leaverequestwwds_1_filterfulltext, lV65Leaverequestwwds_1_filterfulltext, lV66Leaverequestwwds_2_tfleavetypename, AV67Leaverequestwwds_3_tfleavetypename_sel, AV68Leaverequestwwds_4_tfleaverequeststartdate, AV69Leaverequestwwds_5_tfleaverequeststartdate_to, AV70Leaverequestwwds_6_tfleaverequestenddate, AV71Leaverequestwwds_7_tfleaverequestenddate_to, lV72Leaverequestwwds_8_tfleaverequesthalfday, AV74Leaverequestwwds_10_tfleaverequesthalfday_sel, AV75Leaverequestwwds_11_tfleaverequestduration, AV76Leaverequestwwds_12_tfleaverequestduration_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8C2 = false;
            A124LeaveTypeId = P008C2_A124LeaveTypeId[0];
            A106EmployeeId = P008C2_A106EmployeeId[0];
            A131LeaveRequestDuration = P008C2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P008C2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008C2_A129LeaveRequestStartDate[0];
            A132LeaveRequestStatus = P008C2_A132LeaveRequestStatus[0];
            A171LeaveRequestHalfDay = P008C2_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P008C2_n171LeaveRequestHalfDay[0];
            A125LeaveTypeName = P008C2_A125LeaveTypeName[0];
            A127LeaveRequestId = P008C2_A127LeaveRequestId[0];
            A125LeaveTypeName = P008C2_A125LeaveTypeName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P008C2_A124LeaveTypeId[0] == A124LeaveTypeId ) )
            {
               BRK8C2 = false;
               A127LeaveRequestId = P008C2_A127LeaveRequestId[0];
               AV43count = (long)(AV43count+1);
               BRK8C2 = true;
               pr_default.readNext(0);
            }
            AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A125LeaveTypeName)) ? "<#Empty#>" : A125LeaveTypeName);
            AV37InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV38Option, "<#Empty#>") != 0 ) && ( AV37InsertIndex <= AV39Options.Count ) && ( ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), AV38Option) < 0 ) || ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV37InsertIndex = (int)(AV37InsertIndex+1);
            }
            AV39Options.Add(AV38Option, AV37InsertIndex);
            AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), AV37InsertIndex);
            if ( AV39Options.Count == AV34SkipItems + 11 )
            {
               AV39Options.RemoveItem(AV39Options.Count);
               AV42OptionIndexes.RemoveItem(AV42OptionIndexes.Count);
            }
            if ( ! BRK8C2 )
            {
               BRK8C2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV34SkipItems > 0 )
         {
            AV39Options.RemoveItem(1);
            AV42OptionIndexes.RemoveItem(1);
            AV34SkipItems = (short)(AV34SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADLEAVEREQUESTHALFDAYOPTIONS' Routine */
         returnInSub = false;
         AV56TFLeaveRequestHalfDay = AV33SearchTxt;
         AV60TFLeaveRequestHalfDayOperator = 0;
         AV57TFLeaveRequestHalfDay_Sel = "";
         AV65Leaverequestwwds_1_filterfulltext = AV55FilterFullText;
         AV66Leaverequestwwds_2_tfleavetypename = AV15TFLeaveTypeName;
         AV67Leaverequestwwds_3_tfleavetypename_sel = AV16TFLeaveTypeName_Sel;
         AV68Leaverequestwwds_4_tfleaverequeststartdate = AV19TFLeaveRequestStartDate;
         AV69Leaverequestwwds_5_tfleaverequeststartdate_to = AV20TFLeaveRequestStartDate_To;
         AV70Leaverequestwwds_6_tfleaverequestenddate = AV21TFLeaveRequestEndDate;
         AV71Leaverequestwwds_7_tfleaverequestenddate_to = AV22TFLeaveRequestEndDate_To;
         AV72Leaverequestwwds_8_tfleaverequesthalfday = AV56TFLeaveRequestHalfDay;
         AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator = AV60TFLeaveRequestHalfDayOperator;
         AV74Leaverequestwwds_10_tfleaverequesthalfday_sel = AV57TFLeaveRequestHalfDay_Sel;
         AV75Leaverequestwwds_11_tfleaverequestduration = AV23TFLeaveRequestDuration;
         AV76Leaverequestwwds_12_tfleaverequestduration_to = AV24TFLeaveRequestDuration_To;
         AV77Leaverequestwwds_13_tfleaverequeststatus = AV58TFLeaveRequestStatus;
         AV78Leaverequestwwds_14_tfleaverequeststatusoperator = AV59TFLeaveRequestStatusOperator;
         AV79Leaverequestwwds_15_tfleaverequeststatus_sels = AV26TFLeaveRequestStatus_Sels;
         AV80Udparg16 = new getloggedinemployeeid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A132LeaveRequestStatus ,
                                              AV79Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                              AV65Leaverequestwwds_1_filterfulltext ,
                                              AV67Leaverequestwwds_3_tfleavetypename_sel ,
                                              AV66Leaverequestwwds_2_tfleavetypename ,
                                              AV68Leaverequestwwds_4_tfleaverequeststartdate ,
                                              AV69Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                              AV70Leaverequestwwds_6_tfleaverequestenddate ,
                                              AV71Leaverequestwwds_7_tfleaverequestenddate_to ,
                                              AV74Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                              AV72Leaverequestwwds_8_tfleaverequesthalfday ,
                                              AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                              AV75Leaverequestwwds_11_tfleaverequestduration ,
                                              AV76Leaverequestwwds_12_tfleaverequestduration_to ,
                                              AV79Leaverequestwwds_15_tfleaverequeststatus_sels.Count ,
                                              AV78Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A106EmployeeId ,
                                              AV80Udparg16 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV65Leaverequestwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext), "%", "");
         lV66Leaverequestwwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV66Leaverequestwwds_2_tfleavetypename), 100, "%");
         lV72Leaverequestwwds_8_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV72Leaverequestwwds_8_tfleaverequesthalfday), 20, "%");
         /* Using cursor P008C3 */
         pr_default.execute(1, new Object[] {AV80Udparg16, lV65Leaverequestwwds_1_filterfulltext, lV65Leaverequestwwds_1_filterfulltext, lV65Leaverequestwwds_1_filterfulltext, lV65Leaverequestwwds_1_filterfulltext, lV65Leaverequestwwds_1_filterfulltext, lV65Leaverequestwwds_1_filterfulltext, lV66Leaverequestwwds_2_tfleavetypename, AV67Leaverequestwwds_3_tfleavetypename_sel, AV68Leaverequestwwds_4_tfleaverequeststartdate, AV69Leaverequestwwds_5_tfleaverequeststartdate_to, AV70Leaverequestwwds_6_tfleaverequestenddate, AV71Leaverequestwwds_7_tfleaverequestenddate_to, lV72Leaverequestwwds_8_tfleaverequesthalfday, AV74Leaverequestwwds_10_tfleaverequesthalfday_sel, AV75Leaverequestwwds_11_tfleaverequestduration, AV76Leaverequestwwds_12_tfleaverequestduration_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8C4 = false;
            A124LeaveTypeId = P008C3_A124LeaveTypeId[0];
            A106EmployeeId = P008C3_A106EmployeeId[0];
            A171LeaveRequestHalfDay = P008C3_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P008C3_n171LeaveRequestHalfDay[0];
            A131LeaveRequestDuration = P008C3_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P008C3_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P008C3_A129LeaveRequestStartDate[0];
            A132LeaveRequestStatus = P008C3_A132LeaveRequestStatus[0];
            A125LeaveTypeName = P008C3_A125LeaveTypeName[0];
            A127LeaveRequestId = P008C3_A127LeaveRequestId[0];
            A125LeaveTypeName = P008C3_A125LeaveTypeName[0];
            AV43count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008C3_A171LeaveRequestHalfDay[0], A171LeaveRequestHalfDay) == 0 ) )
            {
               BRK8C4 = false;
               A127LeaveRequestId = P008C3_A127LeaveRequestId[0];
               AV43count = (long)(AV43count+1);
               BRK8C4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV34SkipItems) )
            {
               AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A171LeaveRequestHalfDay)) ? "<#Empty#>" : A171LeaveRequestHalfDay);
               AV39Options.Add(AV38Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV39Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV34SkipItems = (short)(AV34SkipItems-1);
            }
            if ( ! BRK8C4 )
            {
               BRK8C4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV52OptionsJson = "";
         AV53OptionsDescJson = "";
         AV54OptionIndexesJson = "";
         AV39Options = new GxSimpleCollection<string>();
         AV41OptionsDesc = new GxSimpleCollection<string>();
         AV42OptionIndexes = new GxSimpleCollection<string>();
         AV33SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV44Session = context.GetSession();
         AV46GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV47GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV55FilterFullText = "";
         AV15TFLeaveTypeName = "";
         AV16TFLeaveTypeName_Sel = "";
         AV19TFLeaveRequestStartDate = DateTime.MinValue;
         AV20TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV21TFLeaveRequestEndDate = DateTime.MinValue;
         AV22TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV56TFLeaveRequestHalfDay = "";
         AV57TFLeaveRequestHalfDay_Sel = "";
         AV25TFLeaveRequestStatus_SelsJson = "";
         AV26TFLeaveRequestStatus_Sels = new GxSimpleCollection<string>();
         AV65Leaverequestwwds_1_filterfulltext = "";
         AV66Leaverequestwwds_2_tfleavetypename = "";
         AV67Leaverequestwwds_3_tfleavetypename_sel = "";
         AV68Leaverequestwwds_4_tfleaverequeststartdate = DateTime.MinValue;
         AV69Leaverequestwwds_5_tfleaverequeststartdate_to = DateTime.MinValue;
         AV70Leaverequestwwds_6_tfleaverequestenddate = DateTime.MinValue;
         AV71Leaverequestwwds_7_tfleaverequestenddate_to = DateTime.MinValue;
         AV72Leaverequestwwds_8_tfleaverequesthalfday = "";
         AV74Leaverequestwwds_10_tfleaverequesthalfday_sel = "";
         AV77Leaverequestwwds_13_tfleaverequeststatus = "";
         AV58TFLeaveRequestStatus = "";
         AV79Leaverequestwwds_15_tfleaverequeststatus_sels = new GxSimpleCollection<string>();
         lV65Leaverequestwwds_1_filterfulltext = "";
         lV66Leaverequestwwds_2_tfleavetypename = "";
         lV72Leaverequestwwds_8_tfleaverequesthalfday = "";
         A132LeaveRequestStatus = "";
         A125LeaveTypeName = "";
         A171LeaveRequestHalfDay = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         P008C2_A124LeaveTypeId = new long[1] ;
         P008C2_A106EmployeeId = new long[1] ;
         P008C2_A131LeaveRequestDuration = new decimal[1] ;
         P008C2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008C2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008C2_A132LeaveRequestStatus = new string[] {""} ;
         P008C2_A171LeaveRequestHalfDay = new string[] {""} ;
         P008C2_n171LeaveRequestHalfDay = new bool[] {false} ;
         P008C2_A125LeaveTypeName = new string[] {""} ;
         P008C2_A127LeaveRequestId = new long[1] ;
         AV38Option = "";
         P008C3_A124LeaveTypeId = new long[1] ;
         P008C3_A106EmployeeId = new long[1] ;
         P008C3_A171LeaveRequestHalfDay = new string[] {""} ;
         P008C3_n171LeaveRequestHalfDay = new bool[] {false} ;
         P008C3_A131LeaveRequestDuration = new decimal[1] ;
         P008C3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P008C3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P008C3_A132LeaveRequestStatus = new string[] {""} ;
         P008C3_A125LeaveTypeName = new string[] {""} ;
         P008C3_A127LeaveRequestId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008C2_A124LeaveTypeId, P008C2_A106EmployeeId, P008C2_A131LeaveRequestDuration, P008C2_A130LeaveRequestEndDate, P008C2_A129LeaveRequestStartDate, P008C2_A132LeaveRequestStatus, P008C2_A171LeaveRequestHalfDay, P008C2_n171LeaveRequestHalfDay, P008C2_A125LeaveTypeName, P008C2_A127LeaveRequestId
               }
               , new Object[] {
               P008C3_A124LeaveTypeId, P008C3_A106EmployeeId, P008C3_A171LeaveRequestHalfDay, P008C3_n171LeaveRequestHalfDay, P008C3_A131LeaveRequestDuration, P008C3_A130LeaveRequestEndDate, P008C3_A129LeaveRequestStartDate, P008C3_A132LeaveRequestStatus, P008C3_A125LeaveTypeName, P008C3_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36MaxItems ;
      private short AV35PageIndex ;
      private short AV34SkipItems ;
      private short AV60TFLeaveRequestHalfDayOperator ;
      private short AV59TFLeaveRequestStatusOperator ;
      private short AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator ;
      private short AV78Leaverequestwwds_14_tfleaverequeststatusoperator ;
      private int AV63GXV1 ;
      private int AV79Leaverequestwwds_15_tfleaverequeststatus_sels_Count ;
      private int AV37InsertIndex ;
      private long AV80Udparg16 ;
      private long A106EmployeeId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private long AV43count ;
      private decimal AV23TFLeaveRequestDuration ;
      private decimal AV24TFLeaveRequestDuration_To ;
      private decimal AV75Leaverequestwwds_11_tfleaverequestduration ;
      private decimal AV76Leaverequestwwds_12_tfleaverequestduration_to ;
      private decimal A131LeaveRequestDuration ;
      private string AV15TFLeaveTypeName ;
      private string AV16TFLeaveTypeName_Sel ;
      private string AV56TFLeaveRequestHalfDay ;
      private string AV57TFLeaveRequestHalfDay_Sel ;
      private string AV66Leaverequestwwds_2_tfleavetypename ;
      private string AV67Leaverequestwwds_3_tfleavetypename_sel ;
      private string AV72Leaverequestwwds_8_tfleaverequesthalfday ;
      private string AV74Leaverequestwwds_10_tfleaverequesthalfday_sel ;
      private string AV77Leaverequestwwds_13_tfleaverequeststatus ;
      private string AV58TFLeaveRequestStatus ;
      private string lV66Leaverequestwwds_2_tfleavetypename ;
      private string lV72Leaverequestwwds_8_tfleaverequesthalfday ;
      private string A132LeaveRequestStatus ;
      private string A125LeaveTypeName ;
      private string A171LeaveRequestHalfDay ;
      private DateTime AV19TFLeaveRequestStartDate ;
      private DateTime AV20TFLeaveRequestStartDate_To ;
      private DateTime AV21TFLeaveRequestEndDate ;
      private DateTime AV22TFLeaveRequestEndDate_To ;
      private DateTime AV68Leaverequestwwds_4_tfleaverequeststartdate ;
      private DateTime AV69Leaverequestwwds_5_tfleaverequeststartdate_to ;
      private DateTime AV70Leaverequestwwds_6_tfleaverequestenddate ;
      private DateTime AV71Leaverequestwwds_7_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool BRK8C2 ;
      private bool n171LeaveRequestHalfDay ;
      private bool BRK8C4 ;
      private string AV52OptionsJson ;
      private string AV53OptionsDescJson ;
      private string AV54OptionIndexesJson ;
      private string AV25TFLeaveRequestStatus_SelsJson ;
      private string AV49DDOName ;
      private string AV50SearchTxtParms ;
      private string AV51SearchTxtTo ;
      private string AV33SearchTxt ;
      private string AV55FilterFullText ;
      private string AV65Leaverequestwwds_1_filterfulltext ;
      private string lV65Leaverequestwwds_1_filterfulltext ;
      private string AV38Option ;
      private IGxSession AV44Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV39Options ;
      private GxSimpleCollection<string> AV41OptionsDesc ;
      private GxSimpleCollection<string> AV42OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV46GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV47GridStateFilterValue ;
      private GxSimpleCollection<string> AV26TFLeaveRequestStatus_Sels ;
      private GxSimpleCollection<string> AV79Leaverequestwwds_15_tfleaverequeststatus_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P008C2_A124LeaveTypeId ;
      private long[] P008C2_A106EmployeeId ;
      private decimal[] P008C2_A131LeaveRequestDuration ;
      private DateTime[] P008C2_A130LeaveRequestEndDate ;
      private DateTime[] P008C2_A129LeaveRequestStartDate ;
      private string[] P008C2_A132LeaveRequestStatus ;
      private string[] P008C2_A171LeaveRequestHalfDay ;
      private bool[] P008C2_n171LeaveRequestHalfDay ;
      private string[] P008C2_A125LeaveTypeName ;
      private long[] P008C2_A127LeaveRequestId ;
      private long[] P008C3_A124LeaveTypeId ;
      private long[] P008C3_A106EmployeeId ;
      private string[] P008C3_A171LeaveRequestHalfDay ;
      private bool[] P008C3_n171LeaveRequestHalfDay ;
      private decimal[] P008C3_A131LeaveRequestDuration ;
      private DateTime[] P008C3_A130LeaveRequestEndDate ;
      private DateTime[] P008C3_A129LeaveRequestStartDate ;
      private string[] P008C3_A132LeaveRequestStatus ;
      private string[] P008C3_A125LeaveTypeName ;
      private long[] P008C3_A127LeaveRequestId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class leaverequestwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008C2( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV79Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                             string AV65Leaverequestwwds_1_filterfulltext ,
                                             string AV67Leaverequestwwds_3_tfleavetypename_sel ,
                                             string AV66Leaverequestwwds_2_tfleavetypename ,
                                             DateTime AV68Leaverequestwwds_4_tfleaverequeststartdate ,
                                             DateTime AV69Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                             DateTime AV70Leaverequestwwds_6_tfleaverequestenddate ,
                                             DateTime AV71Leaverequestwwds_7_tfleaverequestenddate_to ,
                                             string AV74Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                             string AV72Leaverequestwwds_8_tfleaverequesthalfday ,
                                             short AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                             decimal AV75Leaverequestwwds_11_tfleaverequestduration ,
                                             decimal AV76Leaverequestwwds_12_tfleaverequestduration_to ,
                                             int AV79Leaverequestwwds_15_tfleaverequeststatus_sels_Count ,
                                             short AV78Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                             string A125LeaveTypeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A106EmployeeId ,
                                             long AV80Udparg16 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestStatus, T1.LeaveRequestHalfDay, T2.LeaveTypeName, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV80Udparg16)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.LeaveTypeName like '%' || :lV65Leaverequestwwds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV65Leaverequestwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV65Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV65Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV65Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV65Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestwwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestwwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV66Leaverequestwwds_2_tfleavetypename)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestwwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV67Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV67Leaverequestwwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV67Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV68Leaverequestwwds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV68Leaverequestwwds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestwwds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV69Leaverequestwwds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Leaverequestwwds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV70Leaverequestwwds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Leaverequestwwds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV71Leaverequestwwds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestwwds_8_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV72Leaverequestwwds_8_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV74Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV74Leaverequestwwds_10_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV74Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV75Leaverequestwwds_11_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV75Leaverequestwwds_11_tfleaverequestduration)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Leaverequestwwds_12_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV76Leaverequestwwds_12_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV79Leaverequestwwds_15_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV79Leaverequestwwds_15_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( AV78Leaverequestwwds_14_tfleaverequeststatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         }
         if ( AV78Leaverequestwwds_14_tfleaverequeststatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         }
         if ( AV78Leaverequestwwds_14_tfleaverequeststatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveTypeId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008C3( IGxContext context ,
                                             string A132LeaveRequestStatus ,
                                             GxSimpleCollection<string> AV79Leaverequestwwds_15_tfleaverequeststatus_sels ,
                                             string AV65Leaverequestwwds_1_filterfulltext ,
                                             string AV67Leaverequestwwds_3_tfleavetypename_sel ,
                                             string AV66Leaverequestwwds_2_tfleavetypename ,
                                             DateTime AV68Leaverequestwwds_4_tfleaverequeststartdate ,
                                             DateTime AV69Leaverequestwwds_5_tfleaverequeststartdate_to ,
                                             DateTime AV70Leaverequestwwds_6_tfleaverequestenddate ,
                                             DateTime AV71Leaverequestwwds_7_tfleaverequestenddate_to ,
                                             string AV74Leaverequestwwds_10_tfleaverequesthalfday_sel ,
                                             string AV72Leaverequestwwds_8_tfleaverequesthalfday ,
                                             short AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator ,
                                             decimal AV75Leaverequestwwds_11_tfleaverequestduration ,
                                             decimal AV76Leaverequestwwds_12_tfleaverequestduration_to ,
                                             int AV79Leaverequestwwds_15_tfleaverequeststatus_sels_Count ,
                                             short AV78Leaverequestwwds_14_tfleaverequeststatusoperator ,
                                             string A125LeaveTypeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A106EmployeeId ,
                                             long AV80Udparg16 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T1.LeaveRequestHalfDay, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestStatus, T2.LeaveTypeName, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.EmployeeId = :AV80Udparg16)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.LeaveTypeName like '%' || :lV65Leaverequestwwds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV65Leaverequestwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV65Leaverequestwwds_1_filterfulltext) or ( 'pending' like '%' || LOWER(:lV65Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Pending')) or ( 'approved' like '%' || LOWER(:lV65Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Approved')) or ( 'rejected' like '%' || LOWER(:lV65Leaverequestwwds_1_filterfulltext) and T1.LeaveRequestStatus = ( 'Rejected')))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestwwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Leaverequestwwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV66Leaverequestwwds_2_tfleavetypename)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestwwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV67Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV67Leaverequestwwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV67Leaverequestwwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV68Leaverequestwwds_4_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV68Leaverequestwwds_4_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestwwds_5_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV69Leaverequestwwds_5_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Leaverequestwwds_6_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV70Leaverequestwwds_6_tfleaverequestenddate)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Leaverequestwwds_7_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV71Leaverequestwwds_7_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Leaverequestwwds_8_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV72Leaverequestwwds_8_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestwwds_10_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV74Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV74Leaverequestwwds_10_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV74Leaverequestwwds_10_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV73Leaverequestwwds_9_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV75Leaverequestwwds_11_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV75Leaverequestwwds_11_tfleaverequestduration)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Leaverequestwwds_12_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV76Leaverequestwwds_12_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV79Leaverequestwwds_15_tfleaverequeststatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV79Leaverequestwwds_15_tfleaverequeststatus_sels, "T1.LeaveRequestStatus IN (", ")")+")");
         }
         if ( AV78Leaverequestwwds_14_tfleaverequeststatusoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Pending'))");
         }
         if ( AV78Leaverequestwwds_14_tfleaverequeststatusoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         }
         if ( AV78Leaverequestwwds_14_tfleaverequeststatusoperator == 3 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Rejected'))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestHalfDay";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008C2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
               case 1 :
                     return conditional_P008C3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP008C2;
          prmP008C2 = new Object[] {
          new ParDef("AV80Udparg16",GXType.Int64,10,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Leaverequestwwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV67Leaverequestwwds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV68Leaverequestwwds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV69Leaverequestwwds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV70Leaverequestwwds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV71Leaverequestwwds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV72Leaverequestwwds_8_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV74Leaverequestwwds_10_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV75Leaverequestwwds_11_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV76Leaverequestwwds_12_tfleaverequestduration_to",GXType.Number,4,1)
          };
          Object[] prmP008C3;
          prmP008C3 = new Object[] {
          new ParDef("AV80Udparg16",GXType.Int64,10,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Leaverequestwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Leaverequestwwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV67Leaverequestwwds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV68Leaverequestwwds_4_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV69Leaverequestwwds_5_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV70Leaverequestwwds_6_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV71Leaverequestwwds_7_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV72Leaverequestwwds_8_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV74Leaverequestwwds_10_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV75Leaverequestwwds_11_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV76Leaverequestwwds_12_tfleaverequestduration_to",GXType.Number,4,1)
          };
          def= new CursorDef[] {
              new CursorDef("P008C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
