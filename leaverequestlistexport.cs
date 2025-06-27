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
   public class leaverequestlistexport : GXProcedure
   {
      public leaverequestlistexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leaverequestlistexport( IGxContext context )
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
         S191 ();
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
         S151 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S181 ();
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
         AV12Filename = GXt_char1 + "LeaveRequestListExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFLeaveTypeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Type Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFLeaveTypeName_Sel)) ? "(Empty)" : AV36TFLeaveTypeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFLeaveTypeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Type Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV35TFLeaveTypeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEmployeeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFEmployeeName_Sel)) ? "(Empty)" : AV38TFEmployeeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFEmployeeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV37TFEmployeeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV39TFLeaveRequestStartDate) && (DateTime.MinValue==AV40TFLeaveRequestStartDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Start Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV39TFLeaveRequestStartDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV40TFLeaveRequestStartDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (DateTime.MinValue==AV41TFLeaveRequestEndDate) && (DateTime.MinValue==AV42TFLeaveRequestEndDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "End Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV41TFLeaveRequestEndDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV42TFLeaveRequestEndDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFLeaveRequestHalfDay_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Half Day") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV44TFLeaveRequestHalfDay_Sel)) ? "(Empty)" : AV44TFLeaveRequestHalfDay_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFLeaveRequestHalfDay)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Half Day") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV43TFLeaveRequestHalfDay, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFLeaveRequestDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Description") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV51TFLeaveRequestDescription_Sel)) ? "(Empty)" : AV51TFLeaveRequestDescription_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFLeaveRequestDescription)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Request Description") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV50TFLeaveRequestDescription, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Type Name";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Name";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = "Start Date";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = "End Date";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = "Half Day";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = "Request Duration";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = "Request Description";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV61Leaverequestlistds_1_filterfulltext = AV19FilterFullText;
         AV62Leaverequestlistds_2_tfleavetypename = AV35TFLeaveTypeName;
         AV63Leaverequestlistds_3_tfleavetypename_sel = AV36TFLeaveTypeName_Sel;
         AV64Leaverequestlistds_4_tfemployeename = AV37TFEmployeeName;
         AV65Leaverequestlistds_5_tfemployeename_sel = AV38TFEmployeeName_Sel;
         AV66Leaverequestlistds_6_tfleaverequeststartdate = AV39TFLeaveRequestStartDate;
         AV67Leaverequestlistds_7_tfleaverequeststartdate_to = AV40TFLeaveRequestStartDate_To;
         AV68Leaverequestlistds_8_tfleaverequestenddate = AV41TFLeaveRequestEndDate;
         AV69Leaverequestlistds_9_tfleaverequestenddate_to = AV42TFLeaveRequestEndDate_To;
         AV70Leaverequestlistds_10_tfleaverequesthalfday = AV43TFLeaveRequestHalfDay;
         AV71Leaverequestlistds_11_tfleaverequesthalfday_sel = AV44TFLeaveRequestHalfDay_Sel;
         AV72Leaverequestlistds_12_tfleaverequestduration = AV45TFLeaveRequestDuration;
         AV73Leaverequestlistds_13_tfleaverequestduration_to = AV46TFLeaveRequestDuration_To;
         AV74Leaverequestlistds_14_tfleaverequestdescription = AV50TFLeaveRequestDescription;
         AV75Leaverequestlistds_15_tfleaverequestdescription_sel = AV51TFLeaveRequestDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Leaverequestlistds_1_filterfulltext ,
                                              AV63Leaverequestlistds_3_tfleavetypename_sel ,
                                              AV62Leaverequestlistds_2_tfleavetypename ,
                                              AV65Leaverequestlistds_5_tfemployeename_sel ,
                                              AV64Leaverequestlistds_4_tfemployeename ,
                                              AV66Leaverequestlistds_6_tfleaverequeststartdate ,
                                              AV67Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                              AV68Leaverequestlistds_8_tfleaverequestenddate ,
                                              AV69Leaverequestlistds_9_tfleaverequestenddate_to ,
                                              AV71Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                              AV70Leaverequestlistds_10_tfleaverequesthalfday ,
                                              AV72Leaverequestlistds_12_tfleaverequestduration ,
                                              AV73Leaverequestlistds_13_tfleaverequestduration_to ,
                                              AV75Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                              AV74Leaverequestlistds_14_tfleaverequestdescription ,
                                              AV55LeaveTypeId ,
                                              AV56EmployeeId ,
                                              A125LeaveTypeName ,
                                              A148EmployeeName ,
                                              A171LeaveRequestHalfDay ,
                                              A131LeaveRequestDuration ,
                                              A133LeaveRequestDescription ,
                                              A129LeaveRequestStartDate ,
                                              A130LeaveRequestEndDate ,
                                              A124LeaveTypeId ,
                                              A106EmployeeId ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV58ToDate ,
                                              AV57FromDate } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV61Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Leaverequestlistds_1_filterfulltext), "%", "");
         lV61Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Leaverequestlistds_1_filterfulltext), "%", "");
         lV61Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Leaverequestlistds_1_filterfulltext), "%", "");
         lV61Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Leaverequestlistds_1_filterfulltext), "%", "");
         lV61Leaverequestlistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Leaverequestlistds_1_filterfulltext), "%", "");
         lV62Leaverequestlistds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV62Leaverequestlistds_2_tfleavetypename), 100, "%");
         lV64Leaverequestlistds_4_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV64Leaverequestlistds_4_tfemployeename), 100, "%");
         lV70Leaverequestlistds_10_tfleaverequesthalfday = StringUtil.PadR( StringUtil.RTrim( AV70Leaverequestlistds_10_tfleaverequesthalfday), 20, "%");
         lV74Leaverequestlistds_14_tfleaverequestdescription = StringUtil.Concat( StringUtil.RTrim( AV74Leaverequestlistds_14_tfleaverequestdescription), "%", "");
         /* Using cursor P00AS2 */
         pr_default.execute(0, new Object[] {AV58ToDate, AV57FromDate, lV61Leaverequestlistds_1_filterfulltext, lV61Leaverequestlistds_1_filterfulltext, lV61Leaverequestlistds_1_filterfulltext, lV61Leaverequestlistds_1_filterfulltext, lV61Leaverequestlistds_1_filterfulltext, lV62Leaverequestlistds_2_tfleavetypename, AV63Leaverequestlistds_3_tfleavetypename_sel, lV64Leaverequestlistds_4_tfemployeename, AV65Leaverequestlistds_5_tfemployeename_sel, AV66Leaverequestlistds_6_tfleaverequeststartdate, AV67Leaverequestlistds_7_tfleaverequeststartdate_to, AV68Leaverequestlistds_8_tfleaverequestenddate, AV69Leaverequestlistds_9_tfleaverequestenddate_to, lV70Leaverequestlistds_10_tfleaverequesthalfday, AV71Leaverequestlistds_11_tfleaverequesthalfday_sel, AV72Leaverequestlistds_12_tfleaverequestduration, AV73Leaverequestlistds_13_tfleaverequestduration_to, lV74Leaverequestlistds_14_tfleaverequestdescription, AV75Leaverequestlistds_15_tfleaverequestdescription_sel, AV55LeaveTypeId, AV56EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00AS2_A106EmployeeId[0];
            A124LeaveTypeId = P00AS2_A124LeaveTypeId[0];
            A131LeaveRequestDuration = P00AS2_A131LeaveRequestDuration[0];
            A130LeaveRequestEndDate = P00AS2_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P00AS2_A129LeaveRequestStartDate[0];
            A133LeaveRequestDescription = P00AS2_A133LeaveRequestDescription[0];
            A171LeaveRequestHalfDay = P00AS2_A171LeaveRequestHalfDay[0];
            n171LeaveRequestHalfDay = P00AS2_n171LeaveRequestHalfDay[0];
            A148EmployeeName = P00AS2_A148EmployeeName[0];
            A125LeaveTypeName = P00AS2_A125LeaveTypeName[0];
            A128LeaveRequestDate = P00AS2_A128LeaveRequestDate[0];
            A127LeaveRequestId = P00AS2_A127LeaveRequestId[0];
            A148EmployeeName = P00AS2_A148EmployeeName[0];
            A125LeaveTypeName = P00AS2_A125LeaveTypeName[0];
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A125LeaveTypeName, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A148EmployeeName, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_dtime3 = DateTimeUtil.ResetTime( A129LeaveRequestStartDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Date = GXt_dtime3;
            GXt_dtime3 = DateTimeUtil.ResetTime( A130LeaveRequestEndDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A171LeaveRequestHalfDay, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = GXt_char1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(A131LeaveRequestDuration);
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A133LeaveRequestDescription, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = GXt_char1;
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S172 ();
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

      protected void S181( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV20Session.Set("WWPExportFilePath", AV12Filename);
         AV20Session.Set("WWPExportFileName", "LeaveRequestListExport.xlsx");
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

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV20Session.Get("LeaveRequestListGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "LeaveRequestListGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("LeaveRequestListGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV76GXV1));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV35TFLeaveTypeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV36TFLeaveTypeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV37TFEmployeeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV38TFEmployeeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTSTARTDATE") == 0 )
            {
               AV39TFLeaveRequestStartDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV40TFLeaveRequestStartDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTENDDATE") == 0 )
            {
               AV41TFLeaveRequestEndDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV42TFLeaveRequestEndDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY") == 0 )
            {
               AV43TFLeaveRequestHalfDay = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTHALFDAY_SEL") == 0 )
            {
               AV44TFLeaveRequestHalfDay_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDURATION") == 0 )
            {
               AV45TFLeaveRequestDuration = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV46TFLeaveRequestDuration_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION") == 0 )
            {
               AV50TFLeaveRequestDescription = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVEREQUESTDESCRIPTION_SEL") == 0 )
            {
               AV51TFLeaveRequestDescription_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "PARM_&LEAVETYPEID") == 0 )
            {
               AV55LeaveTypeId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "PARM_&EMPLOYEEID") == 0 )
            {
               AV56EmployeeId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "PARM_&FROMDATE") == 0 )
            {
               AV57FromDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "PARM_&TODATE") == 0 )
            {
               AV58ToDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "PARM_&COMPANYLOCATIONID") == 0 )
            {
               AV59CompanyLocationId = (long)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV76GXV1 = (int)(AV76GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S172( )
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
         AV36TFLeaveTypeName_Sel = "";
         AV35TFLeaveTypeName = "";
         AV38TFEmployeeName_Sel = "";
         AV37TFEmployeeName = "";
         AV39TFLeaveRequestStartDate = DateTime.MinValue;
         AV40TFLeaveRequestStartDate_To = DateTime.MinValue;
         AV41TFLeaveRequestEndDate = DateTime.MinValue;
         AV42TFLeaveRequestEndDate_To = DateTime.MinValue;
         AV44TFLeaveRequestHalfDay_Sel = "";
         AV43TFLeaveRequestHalfDay = "";
         AV51TFLeaveRequestDescription_Sel = "";
         AV50TFLeaveRequestDescription = "";
         AV61Leaverequestlistds_1_filterfulltext = "";
         AV62Leaverequestlistds_2_tfleavetypename = "";
         AV63Leaverequestlistds_3_tfleavetypename_sel = "";
         AV64Leaverequestlistds_4_tfemployeename = "";
         AV65Leaverequestlistds_5_tfemployeename_sel = "";
         AV66Leaverequestlistds_6_tfleaverequeststartdate = DateTime.MinValue;
         AV67Leaverequestlistds_7_tfleaverequeststartdate_to = DateTime.MinValue;
         AV68Leaverequestlistds_8_tfleaverequestenddate = DateTime.MinValue;
         AV69Leaverequestlistds_9_tfleaverequestenddate_to = DateTime.MinValue;
         AV70Leaverequestlistds_10_tfleaverequesthalfday = "";
         AV71Leaverequestlistds_11_tfleaverequesthalfday_sel = "";
         AV74Leaverequestlistds_14_tfleaverequestdescription = "";
         AV75Leaverequestlistds_15_tfleaverequestdescription_sel = "";
         lV61Leaverequestlistds_1_filterfulltext = "";
         lV62Leaverequestlistds_2_tfleavetypename = "";
         lV64Leaverequestlistds_4_tfemployeename = "";
         lV70Leaverequestlistds_10_tfleaverequesthalfday = "";
         lV74Leaverequestlistds_14_tfleaverequestdescription = "";
         A125LeaveTypeName = "";
         A148EmployeeName = "";
         A171LeaveRequestHalfDay = "";
         A133LeaveRequestDescription = "";
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         AV58ToDate = DateTime.MinValue;
         AV57FromDate = DateTime.MinValue;
         P00AS2_A106EmployeeId = new long[1] ;
         P00AS2_A124LeaveTypeId = new long[1] ;
         P00AS2_A131LeaveRequestDuration = new decimal[1] ;
         P00AS2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P00AS2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P00AS2_A133LeaveRequestDescription = new string[] {""} ;
         P00AS2_A171LeaveRequestHalfDay = new string[] {""} ;
         P00AS2_n171LeaveRequestHalfDay = new bool[] {false} ;
         P00AS2_A148EmployeeName = new string[] {""} ;
         P00AS2_A125LeaveTypeName = new string[] {""} ;
         P00AS2_A128LeaveRequestDate = new DateTime[] {DateTime.MinValue} ;
         P00AS2_A127LeaveRequestId = new long[1] ;
         A128LeaveRequestDate = DateTime.MinValue;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         AV20Session = context.GetSession();
         AV22GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV23GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leaverequestlistexport__default(),
            new Object[][] {
                new Object[] {
               P00AS2_A106EmployeeId, P00AS2_A124LeaveTypeId, P00AS2_A131LeaveRequestDuration, P00AS2_A130LeaveRequestEndDate, P00AS2_A129LeaveRequestStartDate, P00AS2_A133LeaveRequestDescription, P00AS2_A171LeaveRequestHalfDay, P00AS2_n171LeaveRequestHalfDay, P00AS2_A148EmployeeName, P00AS2_A125LeaveTypeName,
               P00AS2_A128LeaveRequestDate, P00AS2_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV76GXV1 ;
      private long AV55LeaveTypeId ;
      private long AV56EmployeeId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private long A127LeaveRequestId ;
      private long AV59CompanyLocationId ;
      private decimal AV45TFLeaveRequestDuration ;
      private decimal AV46TFLeaveRequestDuration_To ;
      private decimal AV72Leaverequestlistds_12_tfleaverequestduration ;
      private decimal AV73Leaverequestlistds_13_tfleaverequestduration_to ;
      private decimal A131LeaveRequestDuration ;
      private string AV36TFLeaveTypeName_Sel ;
      private string AV35TFLeaveTypeName ;
      private string AV38TFEmployeeName_Sel ;
      private string AV37TFEmployeeName ;
      private string AV44TFLeaveRequestHalfDay_Sel ;
      private string AV43TFLeaveRequestHalfDay ;
      private string AV62Leaverequestlistds_2_tfleavetypename ;
      private string AV63Leaverequestlistds_3_tfleavetypename_sel ;
      private string AV64Leaverequestlistds_4_tfemployeename ;
      private string AV65Leaverequestlistds_5_tfemployeename_sel ;
      private string AV70Leaverequestlistds_10_tfleaverequesthalfday ;
      private string AV71Leaverequestlistds_11_tfleaverequesthalfday_sel ;
      private string lV62Leaverequestlistds_2_tfleavetypename ;
      private string lV64Leaverequestlistds_4_tfemployeename ;
      private string lV70Leaverequestlistds_10_tfleaverequesthalfday ;
      private string A125LeaveTypeName ;
      private string A148EmployeeName ;
      private string A171LeaveRequestHalfDay ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV39TFLeaveRequestStartDate ;
      private DateTime AV40TFLeaveRequestStartDate_To ;
      private DateTime AV41TFLeaveRequestEndDate ;
      private DateTime AV42TFLeaveRequestEndDate_To ;
      private DateTime AV66Leaverequestlistds_6_tfleaverequeststartdate ;
      private DateTime AV67Leaverequestlistds_7_tfleaverequeststartdate_to ;
      private DateTime AV68Leaverequestlistds_8_tfleaverequestenddate ;
      private DateTime AV69Leaverequestlistds_9_tfleaverequestenddate_to ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime AV58ToDate ;
      private DateTime AV57FromDate ;
      private DateTime A128LeaveRequestDate ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private bool n171LeaveRequestHalfDay ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV51TFLeaveRequestDescription_Sel ;
      private string AV50TFLeaveRequestDescription ;
      private string AV61Leaverequestlistds_1_filterfulltext ;
      private string AV74Leaverequestlistds_14_tfleaverequestdescription ;
      private string AV75Leaverequestlistds_15_tfleaverequestdescription_sel ;
      private string lV61Leaverequestlistds_1_filterfulltext ;
      private string lV74Leaverequestlistds_14_tfleaverequestdescription ;
      private string A133LeaveRequestDescription ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private long[] P00AS2_A106EmployeeId ;
      private long[] P00AS2_A124LeaveTypeId ;
      private decimal[] P00AS2_A131LeaveRequestDuration ;
      private DateTime[] P00AS2_A130LeaveRequestEndDate ;
      private DateTime[] P00AS2_A129LeaveRequestStartDate ;
      private string[] P00AS2_A133LeaveRequestDescription ;
      private string[] P00AS2_A171LeaveRequestHalfDay ;
      private bool[] P00AS2_n171LeaveRequestHalfDay ;
      private string[] P00AS2_A148EmployeeName ;
      private string[] P00AS2_A125LeaveTypeName ;
      private DateTime[] P00AS2_A128LeaveRequestDate ;
      private long[] P00AS2_A127LeaveRequestId ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV22GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class leaverequestlistexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AS2( IGxContext context ,
                                             string AV61Leaverequestlistds_1_filterfulltext ,
                                             string AV63Leaverequestlistds_3_tfleavetypename_sel ,
                                             string AV62Leaverequestlistds_2_tfleavetypename ,
                                             string AV65Leaverequestlistds_5_tfemployeename_sel ,
                                             string AV64Leaverequestlistds_4_tfemployeename ,
                                             DateTime AV66Leaverequestlistds_6_tfleaverequeststartdate ,
                                             DateTime AV67Leaverequestlistds_7_tfleaverequeststartdate_to ,
                                             DateTime AV68Leaverequestlistds_8_tfleaverequestenddate ,
                                             DateTime AV69Leaverequestlistds_9_tfleaverequestenddate_to ,
                                             string AV71Leaverequestlistds_11_tfleaverequesthalfday_sel ,
                                             string AV70Leaverequestlistds_10_tfleaverequesthalfday ,
                                             decimal AV72Leaverequestlistds_12_tfleaverequestduration ,
                                             decimal AV73Leaverequestlistds_13_tfleaverequestduration_to ,
                                             string AV75Leaverequestlistds_15_tfleaverequestdescription_sel ,
                                             string AV74Leaverequestlistds_14_tfleaverequestdescription ,
                                             long AV55LeaveTypeId ,
                                             long AV56EmployeeId ,
                                             string A125LeaveTypeName ,
                                             string A148EmployeeName ,
                                             string A171LeaveRequestHalfDay ,
                                             decimal A131LeaveRequestDuration ,
                                             string A133LeaveRequestDescription ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             long A124LeaveTypeId ,
                                             long A106EmployeeId ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             DateTime AV58ToDate ,
                                             DateTime AV57FromDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[23];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.LeaveTypeId, T1.LeaveRequestDuration, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestDescription, T1.LeaveRequestHalfDay, T2.EmployeeName, T3.LeaveTypeName, T1.LeaveRequestDate, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN LeaveType T3 ON T3.LeaveTypeId = T1.LeaveTypeId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate < :AV58ToDate and T1.LeaveRequestEndDate > :AV57FromDate)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Leaverequestlistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.LeaveTypeName like '%' || :lV61Leaverequestlistds_1_filterfulltext) or ( T2.EmployeeName like '%' || :lV61Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestHalfDay like '%' || :lV61Leaverequestlistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.LeaveRequestDuration,'90.9'), 2) like '%' || :lV61Leaverequestlistds_1_filterfulltext) or ( T1.LeaveRequestDescription like '%' || :lV61Leaverequestlistds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestlistds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Leaverequestlistds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(T3.LeaveTypeName like :lV62Leaverequestlistds_2_tfleavetypename)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Leaverequestlistds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV63Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.LeaveTypeName = ( :AV63Leaverequestlistds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV63Leaverequestlistds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.LeaveTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestlistds_5_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Leaverequestlistds_4_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV64Leaverequestlistds_4_tfemployeename)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Leaverequestlistds_5_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV65Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV65Leaverequestlistds_5_tfemployeename_sel))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV65Leaverequestlistds_5_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         if ( ! (DateTime.MinValue==AV66Leaverequestlistds_6_tfleaverequeststartdate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate >= :AV66Leaverequestlistds_6_tfleaverequeststartdate)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV67Leaverequestlistds_7_tfleaverequeststartdate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestStartDate <= :AV67Leaverequestlistds_7_tfleaverequeststartdate_to)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV68Leaverequestlistds_8_tfleaverequestenddate) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate >= :AV68Leaverequestlistds_8_tfleaverequestenddate)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV69Leaverequestlistds_9_tfleaverequestenddate_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestEndDate <= :AV69Leaverequestlistds_9_tfleaverequestenddate_to)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Leaverequestlistds_10_tfleaverequesthalfday)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay like :lV70Leaverequestlistds_10_tfleaverequesthalfday)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Leaverequestlistds_11_tfleaverequesthalfday_sel)) && ! ( StringUtil.StrCmp(AV71Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay = ( :AV71Leaverequestlistds_11_tfleaverequesthalfday_sel))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( StringUtil.StrCmp(AV71Leaverequestlistds_11_tfleaverequesthalfday_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestHalfDay IS NULL or (char_length(trim(trailing ' ' from T1.LeaveRequestHalfDay))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV72Leaverequestlistds_12_tfleaverequestduration) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration >= :AV72Leaverequestlistds_12_tfleaverequestduration)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Leaverequestlistds_13_tfleaverequestduration_to) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDuration <= :AV73Leaverequestlistds_13_tfleaverequestduration_to)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Leaverequestlistds_15_tfleaverequestdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Leaverequestlistds_14_tfleaverequestdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription like :lV74Leaverequestlistds_14_tfleaverequestdescription)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Leaverequestlistds_15_tfleaverequestdescription_sel)) && ! ( StringUtil.StrCmp(AV75Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.LeaveRequestDescription = ( :AV75Leaverequestlistds_15_tfleaverequestdescription_sel))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV75Leaverequestlistds_15_tfleaverequestdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.LeaveRequestDescription))=0))");
         }
         if ( ! (0==AV55LeaveTypeId) )
         {
            AddWhere(sWhereString, "(T1.LeaveTypeId = :AV55LeaveTypeId)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (0==AV56EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV56EmployeeId)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDate";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.LeaveTypeName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.LeaveTypeName DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.EmployeeName";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.EmployeeName DESC";
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
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDescription";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.LeaveRequestDescription DESC";
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
                     return conditional_P00AS2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] );
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
          Object[] prmP00AS2;
          prmP00AS2 = new Object[] {
          new ParDef("AV58ToDate",GXType.Date,8,0) ,
          new ParDef("AV57FromDate",GXType.Date,8,0) ,
          new ParDef("lV61Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Leaverequestlistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Leaverequestlistds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV63Leaverequestlistds_3_tfleavetypename_sel",GXType.Char,100,0) ,
          new ParDef("lV64Leaverequestlistds_4_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV65Leaverequestlistds_5_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("AV66Leaverequestlistds_6_tfleaverequeststartdate",GXType.Date,8,0) ,
          new ParDef("AV67Leaverequestlistds_7_tfleaverequeststartdate_to",GXType.Date,8,0) ,
          new ParDef("AV68Leaverequestlistds_8_tfleaverequestenddate",GXType.Date,8,0) ,
          new ParDef("AV69Leaverequestlistds_9_tfleaverequestenddate_to",GXType.Date,8,0) ,
          new ParDef("lV70Leaverequestlistds_10_tfleaverequesthalfday",GXType.Char,20,0) ,
          new ParDef("AV71Leaverequestlistds_11_tfleaverequesthalfday_sel",GXType.Char,20,0) ,
          new ParDef("AV72Leaverequestlistds_12_tfleaverequestduration",GXType.Number,4,1) ,
          new ParDef("AV73Leaverequestlistds_13_tfleaverequestduration_to",GXType.Number,4,1) ,
          new ParDef("lV74Leaverequestlistds_14_tfleaverequestdescription",GXType.VarChar,200,0) ,
          new ParDef("AV75Leaverequestlistds_15_tfleaverequestdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("AV55LeaveTypeId",GXType.Int64,10,0) ,
          new ParDef("AV56EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AS2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AS2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
                ((long[]) buf[11])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
