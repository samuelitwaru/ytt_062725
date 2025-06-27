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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class leaverequestapprovedexport : GXProcedure
   {
      public leaverequestapprovedexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestapprovedexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV14CellRow = 1;
         AV15FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S201 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S161 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S191 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV16Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV12Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV12Filename = GXt_char1 + "LeaveRequestApprovedExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Main filter") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEmployeeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Employee Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFEmployeeName_Sel)) ? "(Empty)" : AV36TFEmployeeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFEmployeeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Employee Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV35TFEmployeeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFLeaveTypeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Leave Type Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFLeaveTypeName_Sel)) ? "(Empty)" : AV38TFLeaveTypeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFLeaveTypeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Leave Type Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV37TFLeaveTypeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV41TFLeaveRequestStartDate) && (DateTime.MinValue==AV42TFLeaveRequestStartDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Start Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV41TFLeaveRequestStartDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV42TFLeaveRequestStartDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV43TFLeaveRequestEndDate) && (DateTime.MinValue==AV44TFLeaveRequestEndDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "End Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV43TFLeaveRequestEndDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV44TFLeaveRequestEndDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFLeaveRequestHalfDay_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Half Day") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFLeaveRequestHalfDay_Sel)) ? "(Empty)" : AV52TFLeaveRequestHalfDay_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFLeaveRequestHalfDay)) && (0==AV53TFLeaveRequestHalfDayOperator) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Half Day") ;
               AV14CellRow = GXt_int2;
               if ( AV53TFLeaveRequestHalfDayOperator == 0 )
               {
                  GXt_char1 = "";
                  new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV51TFLeaveRequestHalfDay, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
               else if ( AV53TFLeaveRequestHalfDayOperator == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Morning";
               }
               else if ( AV53TFLeaveRequestHalfDayOperator == 2 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Afternoon";
               }
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV45TFLeaveRequestDuration) && (Convert.ToDecimal(0)==AV46TFLeaveRequestDuration_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Duration") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV45TFLeaveRequestDuration);
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV46TFLeaveRequestDuration_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV54TFEmployeeBalance) && (Convert.ToDecimal(0)==AV55TFEmployeeBalance_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Vacation Balance") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV54TFEmployeeBalance);
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV55TFEmployeeBalance_To);
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("LeaveRequestApprovedColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("LeaveRequestApprovedColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible = false;
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV56GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV58Leaverequestapprovedds_1_filterfulltext = AV19FilterFullText;
         AV59Leaverequestapprovedds_2_tfemployeename = AV35TFEmployeeName;
         AV60Leaverequestapprovedds_3_tfemployeename_sel = AV36TFEmployeeName_Sel;
         AV61Leaverequestapprovedds_4_tfleavetypename = AV37TFLeaveTypeName;
         AV62Leaverequestapprovedds_5_tfleavetypename_sel = AV38TFLeaveTypeName_Sel;
         AV63Leaverequestapprovedds_6_tfleaverequeststartdate = AV41TFLeaveRequestStartDate;
         AV64Leaverequestapprovedds_7_tfleaverequeststartdate_to = AV42TFLeaveRequestStartDate_To;
         AV65Leaverequestapprovedds_8_tfleaverequestenddate = AV43TFLeaveRequestEndDate;
         AV66Leaverequestapprovedds_9_tfleaverequestenddate_to = AV44TFLeaveRequestEndDate_To;
         AV67Leaverequestapprovedds_10_tfleaverequesthalfday = AV51TFLeaveRequestHalfDay;
         AV68Leaverequestapprovedds_11_tfleaverequesthalfdayoperator = AV53TFLeaveRequestHalfDayOperator;
         AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel = AV52TFLeaveRequestHalfDay_Sel;
         AV70Leaverequestapprovedds_13_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV71Leaverequestapprovedds_14_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV72Leaverequestapprovedds_15_tfemployeebalance = AV54TFEmployeeBalance;
         AV73Leaverequestapprovedds_16_tfemployeebalance_to = AV55TFEmployeeBalance_To;
         AV74Udparg17 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV50EmployeeIds ,
                                              AV58Leaverequestapprovedds_1_filterfulltext ,
                                              AV60Leaverequestapprovedds_3_tfemployeename_sel ,
                                              AV59Leaverequestapprovedds_2_tfemployeename ,
                                              AV62Leaverequestapprovedds_5_tfleavetypename_sel ,
                                              AV61Leaverequestapprovedds_4_tfleavetypename ,
                                              AV63Leaverequestapprovedds_6_tfleaverequeststartdate ,
                                              AV64Leaverequestapprovedds_7_tfleaverequeststartdate_to ,
                                              AV65Leaverequestapprovedds_8_tfleaverequestenddate ,
                                              AV66Leaverequestapprovedds_9_tfleaverequestenddate_to ,
                                              AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel ,
                                              AV67Leaverequestapprovedds_10_tfleaverequesthalfday ,
                                              AV68Leaverequestapprovedds_11_tfleaverequesthalfdayoperator ,
                                              AV70Leaverequestapprovedds_13_tfleaverequestduration ,
                                              AV71Leaverequestapprovedds_14_tfleaverequestduration_to ,
                                              AV72Leaverequestapprovedds_15_tfemployeebalance ,
                                              AV73Leaverequestapprovedds_16_tfemployeebalance_to ,
                                              A148EmployeeName ,
                                              A125LeaveTypeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A147EmployeeBalance ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A100CompanyId ,
                                              AV74Udparg17 ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              A132LeaveRequestStatus } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV58Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV58Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV58Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV58Leaverequestapprovedds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Leaverequestapprovedds_1_filterfulltext), "%", "");
         lV59Leaverequestapprovedds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV59Leaverequestapprovedds_2_tfemployeename), 100, "%");
         lV61Leaverequestapprovedds_4_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV61Leaverequestapprovedds_4_tfleavetypename), 100, "%");
         lV67Leaverequestapprovedds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV67Leaverequestapprovedds_10_tfleaverequesthalfday), 20, "%");
         /* Using cursor P006X2 */
         pr_default.execute(0, new Object[] {lV58Leaverequestapprovedds_1_filterfulltext, lV58Leaverequestapprovedds_1_filterfulltext, lV58Leaverequestapprovedds_1_filterfulltext, lV58Leaverequestapprovedds_1_filterfulltext, lV58Leaverequestapprovedds_1_filterfulltext, lV59Leaverequestapprovedds_2_tfemployeename, AV60Leaverequestapprovedds_3_tfemployeename_sel, lV61Leaverequestapprovedds_4_tfleavetypename, AV62Leaverequestapprovedds_5_tfleavetypename_sel, AV63Leaverequestapprovedds_6_tfleaverequeststartdate, AV64Leaverequestapprovedds_7_tfleaverequeststartdate_to, AV65Leaverequestapprovedds_8_tfleaverequestenddate, AV66Leaverequestapprovedds_9_tfleaverequestenddate_to, lV67Leaverequestapprovedds_10_tfleaverequesthalfday, AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel, AV70Leaverequestapprovedds_13_tfleaverequestduration, AV71Leaverequestapprovedds_14_tfleaverequestduration_to, AV72Leaverequestapprovedds_15_tfemployeebalance, AV73Leaverequestapprovedds_16_tfemployeebalance_to, AV74Udparg17});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124LeaveTypeId = P006X2_A124LeaveTypeId[0];
            A106EmployeeId = P006X2_A106EmployeeId[0];
            A100CompanyId = P006X2_A100CompanyId[0];
            A132LeaveRequestStatus = P006X2_A132LeaveRequestStatus[0];
            A147EmployeeBalance = P006X2_A147EmployeeBalance[0];
            A131LeaveRequestDuration = P006X2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P006X2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P006X2_A129LeaveRequestStartDate[0];
            A171LeaveRequestHalfDay = P006X2_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P006X2_n171LeaveRequestHalfDay[0];
            A125LeaveTypeName = P006X2_A125LeaveTypeName[0];
            A148EmployeeName = P006X2_A148EmployeeName[0];
            A127LeaveRequestId = P006X2_A127LeaveRequestId[0];
            A100CompanyId = P006X2_A100CompanyId[0];
            A125LeaveTypeName = P006X2_A125LeaveTypeName[0];
            A147EmployeeBalance = P006X2_A147EmployeeBalance[0];
            A148EmployeeName = P006X2_A148EmployeeName[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV32VisibleColumnCount = 0;
            AV75GXV2 = 1;
            while ( AV75GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV75GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeName") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A148EmployeeName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveTypeName") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A125LeaveTypeName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestStartDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A129LeaveRequestStartDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestEndDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A130LeaveRequestEndDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestHalfDay") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A171LeaveRequestHalfDay, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                     if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Morning") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 60, 141, 188);
                     }
                     else if ( StringUtil.StrCmp(A171LeaveRequestHalfDay, "Afternoon") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = GXUtil.RGB( 251, 110, 82);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveRequestDuration") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = (double)(A131LeaveRequestDuration);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeBalance") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = (double)(A147EmployeeBalance);
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV75GXV2 = (int)(AV75GXV2+1);
            }
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S182 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S191( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV20Session.Set("WWPExportFilePath", AV12Filename);
         AV20Session.Set("WWPExportFileName", "LeaveRequestApprovedExport.xlsx");
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV11ExcelDocument.ErrCode != 0 )
         {
            AV12Filename = "";
            AV13ErrorMessage = AV11ExcelDocument.ErrDescription;
            AV11ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S151( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeName",  "",  "Employee Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveTypeName",  "",  "Leave Type Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestStartDate",  "",  "Start Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestEndDate",  "",  "End Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestHalfDay",  "",  "Half Day",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveRequestDuration",  "",  "Request Duration",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "&LeaveRequestDescriptionVariable",  "",  "Leave Description",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeBalance",  "",  "Vacation Balance",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "LeaveRequestApprovedColumnsSelector", out  GXt_char1) ;
         AV28UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV28UserCustomValue)) ) )
         {
            AV25ColumnsSelectorAux.FromXml(AV28UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV25ColumnsSelectorAux, ref  AV24ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get("LeaveRequestApprovedGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "LeaveRequestApprovedGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("LeaveRequestApprovedGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV76GXV3 = 1;
         while ( AV76GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV76GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV35TFEmployeeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV36TFEmployeeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV37TFLeaveTypeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV38TFLeaveTypeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV41TFLeaveRequestStartDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV42TFLeaveRequestStartDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV43TFLeaveRequestEndDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV44TFLeaveRequestEndDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV53TFLeaveRequestHalfDayOperator = AV23GridStateFilterValue.gxTpr_Operator;
               if ( AV53TFLeaveRequestHalfDayOperator == 0 )
               {
                  AV51TFLeaveRequestHalfDay = AV23GridStateFilterValue.gxTpr_Value;
               }
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV52TFLeaveRequestHalfDay_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV45TFLeaveRequestDuration = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV46TFLeaveRequestDuration_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEBALANCE") == 0 )
            {
               AV54TFEmployeeBalance = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV55TFEmployeeBalance_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV76GXV3 = (int)(AV76GXV3+1);
         }
      }

      protected void S172( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S182( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
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
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV36TFEmployeeName_Sel = "";
         AV35TFEmployeeName = "";
         AV38TFLeaveTypeName_Sel = "";
         AV37TFLeaveTypeName = "";
         AV41TFLeaveRequestStartDate = DateTime.MinValue;
         AV42TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV43TFLeaveRequestEndDate = DateTime.MinValue;
         AV44TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV52TFLeaveRequestHalfDay_Sel = "";
         AV51TFLeaveRequestHalfDay = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column(context);
         AV58Leaverequestapprovedds_1_filterfulltext = "";
         AV59Leaverequestapprovedds_2_tfemployeename = "";
         AV60Leaverequestapprovedds_3_tfemployeename_sel = "";
         AV61Leaverequestapprovedds_4_tfleavetypename = "";
         AV62Leaverequestapprovedds_5_tfleavetypename_sel = "";
         AV63Leaverequestapprovedds_6_tfleaverequeststartdate = DateTime.MinValue;
         AV64Leaverequestapprovedds_7_tfleaverequeststartdate_to = DateTime.MinValue;
         AV65Leaverequestapprovedds_8_tfleaverequestenddate = DateTime.MinValue;
         AV66Leaverequestapprovedds_9_tfleaverequestenddate_to = DateTime.MinValue;
         AV67Leaverequestapprovedds_10_tfleaverequesthalfday = "";
         AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel = "";
         lV58Leaverequestapprovedds_1_filterfulltext = "";
         lV59Leaverequestapprovedds_2_tfemployeename = "";
         lV61Leaverequestapprovedds_4_tfleavetypename = "";
         lV67Leaverequestapprovedds_10_tfleaverequesthalfday = "";
         AV50EmployeeIds = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         A125LeaveTypeName = "";
         A171LeaveRequestHalfDay = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         P006X2_A124LeaveTypeId = new long[1] ;
         P006X2_A106EmployeeId = new long[1] ;
         P006X2_A100CompanyId = new long[1] ;
         P006X2_A132LeaveRequestStatus = new string[] {""} ;
         P006X2_A147EmployeeBalance = new decimal[1] ;
         P006X2_A131LeaveRequestDuration = new decimal[1] ;
         P006X2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006X2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006X2_A171LeaveRequestHalfDay = new string[] {""} ;
         P006X2_n171LeaveRequestHalfDay = new bool[] {false} ;
         P006X2_A125LeaveTypeName = new string[] {""} ;
         P006X2_A148EmployeeName = new string[] {""} ;
         P006X2_A127LeaveRequestId = new long[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV22GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV23GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestapprovedexport__default(),
            new Object[][] {
                new Object[] {
               P006X2_A124LeaveTypeId, P006X2_A106EmployeeId, P006X2_A100CompanyId, P006X2_A132LeaveRequestStatus, P006X2_A147EmployeeBalance, P006X2_A131LeaveRequestDuration, P006X2_A130LeaveRequestEndDate, P006X2_A129LeaveRequestStartDate, P006X2_A171LeaveRequestHalfDay, P006X2_n171LeaveRequestHalfDay,
               P006X2_A125LeaveTypeName, P006X2_A148EmployeeName, P006X2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV53TFLeaveRequestHalfDayOperator ;
      private short GXt_int2 ;
      private short AV68Leaverequestapprovedds_11_tfleaverequesthalfdayoperator ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV56GXV1 ;
      private int AV75GXV2 ;
      private int AV76GXV3 ;
      private long AV32VisibleColumnCount ;
      private long AV74Udparg17 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private decimal AV45TFLeaveRequestDuration ;
      private decimal AV46TFLeaveRequestDuration_To ;
      private decimal AV54TFEmployeeBalance ;
      private decimal AV55TFEmployeeBalance_To ;
      private decimal AV70Leaverequestapprovedds_13_tfleaverequestduration ;
      private decimal AV71Leaverequestapprovedds_14_tfleaverequestduration_to ;
      private decimal AV72Leaverequestapprovedds_15_tfemployeebalance ;
      private decimal AV73Leaverequestapprovedds_16_tfemployeebalance_to ;
      private decimal A131LeaveRequestDuration ;
      private decimal A147EmployeeBalance ;
      private string AV36TFEmployeeName_Sel ;
      private string AV35TFEmployeeName ;
      private string AV38TFLeaveTypeName_Sel ;
      private string AV37TFLeaveTypeName ;
      private string AV52TFLeaveRequestHalfDay_Sel ;
      private string AV51TFLeaveRequestHalfDay ;
      private string AV59Leaverequestapprovedds_2_tfemployeename ;
      private string AV60Leaverequestapprovedds_3_tfemployeename_sel ;
      private string AV61Leaverequestapprovedds_4_tfleavetypename ;
      private string AV62Leaverequestapprovedds_5_tfleavetypename_sel ;
      private string AV67Leaverequestapprovedds_10_tfleaverequesthalfday ;
      private string AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel ;
      private string lV59Leaverequestapprovedds_2_tfemployeename ;
      private string lV61Leaverequestapprovedds_4_tfleavetypename ;
      private string lV67Leaverequestapprovedds_10_tfleaverequesthalfday ;
      private string A148EmployeeName ;
      private string A125LeaveTypeName ;
      private string A171LeaveRequestHalfDay ;
      private string A132LeaveRequestStatus ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV41TFLeaveRequestStartDate ;
      private DateTime AV42TFLeaveRequestStartDate_To ;
      private DateTime AV43TFLeaveRequestEndDate ;
      private DateTime AV44TFLeaveRequestEndDate_To ;
      private DateTime AV63Leaverequestapprovedds_6_tfleaverequeststartdate ;
      private DateTime AV64Leaverequestapprovedds_7_tfleaverequeststartdate_to ;
      private DateTime AV65Leaverequestapprovedds_8_tfleaverequestenddate ;
      private DateTime AV66Leaverequestapprovedds_9_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n171LeaveRequestHalfDay ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV58Leaverequestapprovedds_1_filterfulltext ;
      private string lV58Leaverequestapprovedds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private GxSimpleCollection<long> AV50EmployeeIds ;
      private IDataStoreProvider pr_default ;
      private long[] P006X2_A124LeaveTypeId ;
      private long[] P006X2_A106EmployeeId ;
      private long[] P006X2_A100CompanyId ;
      private string[] P006X2_A132LeaveRequestStatus ;
      private decimal[] P006X2_A147EmployeeBalance ;
      private decimal[] P006X2_A131LeaveRequestDuration ;
      private DateTime[] P006X2_A130LeaveRequestEndDate ;
      private DateTime[] P006X2_A129LeaveRequestStartDate ;
      private string[] P006X2_A171LeaveRequestHalfDay ;
      private bool[] P006X2_n171LeaveRequestHalfDay ;
      private string[] P006X2_A125LeaveTypeName ;
      private string[] P006X2_A148EmployeeName ;
      private long[] P006X2_A127LeaveRequestId ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV22GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class leaverequestapprovedexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006X2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV50EmployeeIds ,
                                             string AV58Leaverequestapprovedds_1_filterfulltext ,
                                             string AV60Leaverequestapprovedds_3_tfemployeename_sel ,
                                             string AV59Leaverequestapprovedds_2_tfemployeename ,
                                             string AV62Leaverequestapprovedds_5_tfleavetypename_sel ,
                                             string AV61Leaverequestapprovedds_4_tfleavetypename ,
                                             DateTime AV63Leaverequestapprovedds_6_tfleaverequeststartdate ,
                                             DateTime AV64Leaverequestapprovedds_7_tfleaverequeststartdate_to ,
                                             DateTime AV65Leaverequestapprovedds_8_tfleaverequestenddate ,
                                             DateTime AV66Leaverequestapprovedds_9_tfleaverequestenddate_to ,
                                             string AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel ,
                                             string AV67Leaverequestapprovedds_10_tfleaverequesthalfday ,
                                             short AV68Leaverequestapprovedds_11_tfleaverequesthalfdayoperator ,
                                             decimal AV70Leaverequestapprovedds_13_tfleaverequestduration ,
                                             decimal AV71Leaverequestapprovedds_14_tfleaverequestduration_to ,
                                             decimal AV72Leaverequestapprovedds_15_tfemployeebalance ,
                                             decimal AV73Leaverequestapprovedds_16_tfemployeebalance_to ,
                                             string A148EmployeeName ,
                                             string A125LeaveTypeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             decimal A147EmployeeBalance ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A100CompanyId ,
                                             long AV74Udparg17 ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[20];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T1.EmployeeId, T2.CompanyId, T1.LeaveRequestStatus, T3.EmployeeBalance, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestHalfDay, T2.LeaveTypeName, T3.EmployeeName, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Employee T3 ON T3.EmployeeId = T1.EmployeeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leaverequestapprovedds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.EmployeeName like '%' || :lV58Leaverequestapprovedds_1_filterfulltext) or ( T2.LeaveTypeName like '%' || :lV58Leaverequestapprovedds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV58Leaverequestapprovedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV58Leaverequestapprovedds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.EmployeeBalance,'90.9'), 2) like '%' || :lV58Leaverequestapprovedds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestapprovedds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Leaverequestapprovedds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName like :lV59Leaverequestapprovedds_2_tfemployeename)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Leaverequestapprovedds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV60Leaverequestapprovedds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.EmployeeName = ( :AV60Leaverequestapprovedds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV60Leaverequestapprovedds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestapprovedds_5_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestapprovedds_4_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName like :lV61Leaverequestapprovedds_4_tfleavetypename)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestapprovedds_5_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV62Leaverequestapprovedds_5_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.LeaveTypeName = ( :AV62Leaverequestapprovedds_5_tfleavetypename_sel))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62Leaverequestapprovedds_5_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.LeaveTypeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV63Leaverequestapprovedds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV63Leaverequestapprovedds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Leaverequestapprovedds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV64Leaverequestapprovedds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Leaverequestapprovedds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV65Leaverequestapprovedds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestapprovedds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV66Leaverequestapprovedds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Leaverequestapprovedds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV67Leaverequestapprovedds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( AV68Leaverequestapprovedds_11_tfleaverequesthalfdayoperator == 1 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Morning'))");
         }
         if ( AV68Leaverequestapprovedds_11_tfleaverequesthalfdayoperator == 2 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( 'Afternoon'))");
         }
         if ( ! (Convert.ToDecimal(0)==AV70Leaverequestapprovedds_13_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV70Leaverequestapprovedds_13_tfleaverequestduration)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV71Leaverequestapprovedds_14_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV71Leaverequestapprovedds_14_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV72Leaverequestapprovedds_15_tfemployeebalance) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance >= :AV72Leaverequestapprovedds_15_tfemployeebalance)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Leaverequestapprovedds_16_tfemployeebalance_to) )
         {
            AddWhere(sWhereString, "(T3.EmployeeBalance <= :AV73Leaverequestapprovedds_16_tfemployeebalance_to)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(T2.CompanyId = :AV74Udparg17)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestId DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.EmployeeName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.EmployeeName DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.LeaveTypeName";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.LeaveTypeName DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStartDate";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestStartDate DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestEndDate";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestEndDate DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestHalfDay";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestHalfDay DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDuration";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDuration DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006X2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006X2;
          prmP006X2 = new Object[] {
          new ParDef("lV58Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Leaverequestapprovedds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Leaverequestapprovedds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV60Leaverequestapprovedds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV61Leaverequestapprovedds_4_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV62Leaverequestapprovedds_5_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("AV63Leaverequestapprovedds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV64Leaverequestapprovedds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV65Leaverequestapprovedds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV66Leaverequestapprovedds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV67Leaverequestapprovedds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV69Leaverequestapprovedds_12_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV70Leaverequestapprovedds_13_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV71Leaverequestapprovedds_14_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("AV72Leaverequestapprovedds_15_tfemployeebalance",GXType.Number,4,1) ,
          new ParDef("AV73Leaverequestapprovedds_16_tfemployeebalance_to",GXType.Number,4,1) ,
          new ParDef("AV74Udparg17",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006X2,100, GxCacheFrequency.OFF ,true,false )
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
       }
    }

 }

}
