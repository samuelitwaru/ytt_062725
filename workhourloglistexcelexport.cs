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
   public class workhourloglistexcelexport : GXProcedure
   {
      public workhourloglistexcelexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourloglistexcelexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           GxSimpleCollection<long> aP3_ProjectIds ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV33ProjectIds = aP3_ProjectIds;
         this.AV12Filename = "" ;
         this.AV16ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP4_Filename=this.AV12Filename;
         aP5_ErrorMessage=this.AV16ErrorMessage;
      }

      public string executeUdp( long aP0_EmployeeId ,
                                DateTime aP1_FromDate ,
                                DateTime aP2_ToDate ,
                                GxSimpleCollection<long> aP3_ProjectIds ,
                                out string aP4_Filename )
      {
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, aP3_ProjectIds, out aP4_Filename, out aP5_ErrorMessage);
         return AV16ErrorMessage ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 GxSimpleCollection<long> aP3_ProjectIds ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9FromDate = aP1_FromDate;
         this.AV10ToDate = aP2_ToDate;
         this.AV33ProjectIds = aP3_ProjectIds;
         this.AV12Filename = "" ;
         this.AV16ErrorMessage = "" ;
         SubmitImpl();
         aP4_Filename=this.AV12Filename;
         aP5_ErrorMessage=this.AV16ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV30headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV30headerCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV30headerCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV30headerCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV30headerCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 1;
         AV49footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV49footCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV49footCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV49footCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S151 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV20excelcellrange = AV19excelSpreadsheet.cell(1, 1);
         AV20excelcellrange.gxTpr_Valuetext = "Work Hour Log Details";
         AV50excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV50excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV50excelCellStyle.gxTpr_Font.gxTpr_Size = 14;
         AV50excelCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV50excelCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV20excelcellrange.setcellstyle( AV50excelCellStyle);
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEROWS' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV20excelcellrange = AV19excelSpreadsheet.cell(AV25CellRow+2, 1);
         GXt_char1 = "";
         new formatdatetime(context ).execute(  AV9FromDate,  "DD.MM.YYYY", out  GXt_char1) ;
         AV20excelcellrange.gxTpr_Valuetext = "Start Date "+GXt_char1;
         AV20excelcellrange.setcellstyle( AV49footCellStyle);
         AV20excelcellrange = AV19excelSpreadsheet.cell(AV25CellRow+3, 1);
         GXt_char1 = "";
         new formatdatetime(context ).execute(  AV10ToDate,  "DD.MM.YYYY", out  GXt_char1) ;
         AV20excelcellrange.gxTpr_Valuetext = "End Date "+GXt_char1;
         AV20excelcellrange.setcellstyle( AV49footCellStyle);
         AV20excelcellrange = AV19excelSpreadsheet.cell(AV25CellRow+4, 1);
         GXt_char1 = "";
         new formattime(context ).execute(  (long)(Math.Round(AV51Total, 18, MidpointRounding.ToEven)), out  GXt_char1) ;
         AV20excelcellrange.gxTpr_Valuetext = "Total "+GXt_char1+" ";
         AV20excelcellrange.setcellstyle( AV49footCellStyle);
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S141 ();
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
         GXt_char1 = AV12Filename;
         new formatdatetime(context ).execute(  AV9FromDate,  "YYYY-MM-DD", out  GXt_char1) ;
         GXt_char2 = AV12Filename;
         new formatdatetime(context ).execute(  AV10ToDate,  "YYYY-MM-DD", out  GXt_char2) ;
         AV12Filename = "HoursReport-" + GXt_char1 + "_" + GXt_char2 + ".xlsx";
         AV18File.Source = AV12Filename;
         AV18File.Delete();
         AV19excelSpreadsheet.open( AV12Filename);
      }

      protected void S121( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV25CellRow = 3;
         AV26FirstColumn = 1;
         AV32Columns.Add("Employee Name", 0);
         AV32Columns.Add("Project Name", 0);
         AV32Columns.Add("Log Date", 0);
         AV32Columns.Add("Log Hours", 0);
         AV32Columns.Add("Log Description", 0);
         AV21VisibleColumnCount = 0;
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV32Columns.Count )
         {
            AV27Column = ((string)AV32Columns.Item(AV52GXV1));
            AV20excelcellrange = AV19excelSpreadsheet.cell(AV25CellRow, AV26FirstColumn+AV21VisibleColumnCount);
            AV20excelcellrange.gxTpr_Valuetext = AV27Column;
            AV20excelcellrange.setcellstyle( AV30headerCellStyle);
            AV21VisibleColumnCount = (short)(AV21VisibleColumnCount+1);
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'WRITEROWS' Routine */
         returnInSub = false;
         AV25CellRow = 4;
         AV53Cellcol = 1;
         AV51Total = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A102ProjectId ,
                                              AV33ProjectIds ,
                                              AV33ProjectIds.Count ,
                                              AV43FilterFullText ,
                                              A106EmployeeId ,
                                              AV8EmployeeId ,
                                              AV9FromDate ,
                                              A119WorkHourLogDate ,
                                              AV10ToDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AI2 */
         pr_default.execute(0, new Object[] {AV9FromDate, AV43FilterFullText, AV8EmployeeId, AV10ToDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00AI2_A106EmployeeId[0];
            A103ProjectName = P00AI2_A103ProjectName[0];
            A102ProjectId = P00AI2_A102ProjectId[0];
            A119WorkHourLogDate = P00AI2_A119WorkHourLogDate[0];
            A148EmployeeName = P00AI2_A148EmployeeName[0];
            A120WorkHourLogDuration = P00AI2_A120WorkHourLogDuration[0];
            A123WorkHourLogDescription = P00AI2_A123WorkHourLogDescription[0];
            A122WorkHourLogMinute = P00AI2_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00AI2_A121WorkHourLogHour[0];
            A118WorkHourLogId = P00AI2_A118WorkHourLogId[0];
            A148EmployeeName = P00AI2_A148EmployeeName[0];
            A103ProjectName = P00AI2_A103ProjectName[0];
            AV20excelcellrange = AV19excelSpreadsheet.cell(AV25CellRow, 1);
            AV20excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A148EmployeeName);
            AV20excelcellrange = AV19excelSpreadsheet.cell(AV25CellRow, 2);
            AV20excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A103ProjectName);
            AV20excelcellrange = AV19excelSpreadsheet.cell(AV25CellRow, 3);
            GXt_char2 = "";
            new formatdatetime(context ).execute(  A119WorkHourLogDate,  "DD/MM/YYYY", out  GXt_char2) ;
            AV20excelcellrange.gxTpr_Valuetext = GXt_char2;
            AV20excelcellrange = AV19excelSpreadsheet.cell(AV25CellRow, 4);
            AV20excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A120WorkHourLogDuration);
            AV20excelcellrange = AV19excelSpreadsheet.cell(AV25CellRow, 5);
            AV20excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A123WorkHourLogDescription);
            AV25CellRow = (short)(AV25CellRow+1);
            AV51Total = (decimal)(AV51Total+(A121WorkHourLogHour*60+A122WorkHourLogMinute));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S141( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV19excelSpreadsheet.gxTpr_Autofit = true;
         AV24boolean = AV19excelSpreadsheet.save();
         if ( AV24boolean )
         {
            AV19excelSpreadsheet.close();
         }
         else
         {
            GX_msglist.addItem("Error code:"+StringUtil.Str( (decimal)(AV19excelSpreadsheet.gxTpr_Errcode), 8, 0));
            GX_msglist.addItem("Error description:"+AV19excelSpreadsheet.gxTpr_Errdescription);
         }
         AV17Session.Set("WWPExportFilePath", AV12Filename);
         AV17Session.Set("WWPExportFileName", AV12Filename);
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get("WorkHourLogListGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WorkHourLogListGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV17Session.Get("WorkHourLogListGridState"), null, "", "");
         }
         AV40OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV42OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV55GXV2 = 1;
         while ( AV55GXV2 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV55GXV2));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV35TFEmployeeName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV44TFEmployeeName_Sel = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV36TFProjectName = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV45TFProjectName_Sel = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV37TFWorkHourLogDate = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV48TFWorkHourLogDate_To = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV38TFWorkHourLogDuration = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV46TFWorkHourLogDuration_Sel = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV39TFWorkHourLogDescription = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV47TFWorkHourLogDescription_Sel = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV55GXV2 = (int)(AV55GXV2+1);
         }
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
         AV16ErrorMessage = "";
         AV30headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV49footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV20excelcellrange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV19excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         AV50excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         GXt_char1 = "";
         AV18File = new GxFile(context.GetPhysicalPath());
         AV32Columns = new GxSimpleCollection<string>();
         AV27Column = "";
         AV43FilterFullText = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P00AI2_A106EmployeeId = new long[1] ;
         P00AI2_A103ProjectName = new string[] {""} ;
         P00AI2_A102ProjectId = new long[1] ;
         P00AI2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00AI2_A148EmployeeName = new string[] {""} ;
         P00AI2_A120WorkHourLogDuration = new string[] {""} ;
         P00AI2_A123WorkHourLogDescription = new string[] {""} ;
         P00AI2_A122WorkHourLogMinute = new short[1] ;
         P00AI2_A121WorkHourLogHour = new short[1] ;
         P00AI2_A118WorkHourLogId = new long[1] ;
         A103ProjectName = "";
         A148EmployeeName = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         GXt_char2 = "";
         AV17Session = context.GetSession();
         AV34GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV41GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV35TFEmployeeName = "";
         AV36TFProjectName = "";
         AV37TFWorkHourLogDate = DateTime.MinValue;
         AV38TFWorkHourLogDuration = "";
         AV39TFWorkHourLogDescription = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourloglistexcelexport__default(),
            new Object[][] {
                new Object[] {
               P00AI2_A106EmployeeId, P00AI2_A103ProjectName, P00AI2_A102ProjectId, P00AI2_A119WorkHourLogDate, P00AI2_A148EmployeeName, P00AI2_A120WorkHourLogDuration, P00AI2_A123WorkHourLogDescription, P00AI2_A122WorkHourLogMinute, P00AI2_A121WorkHourLogHour, P00AI2_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25CellRow ;
      private short AV26FirstColumn ;
      private short AV21VisibleColumnCount ;
      private short AV53Cellcol ;
      private short A122WorkHourLogMinute ;
      private short A121WorkHourLogHour ;
      private short AV40OrderedBy ;
      private short AV44TFEmployeeName_Sel ;
      private short AV45TFProjectName_Sel ;
      private short AV48TFWorkHourLogDate_To ;
      private short AV46TFWorkHourLogDuration_Sel ;
      private short AV47TFWorkHourLogDescription_Sel ;
      private int AV52GXV1 ;
      private int AV33ProjectIds_Count ;
      private int AV55GXV2 ;
      private long AV8EmployeeId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private decimal AV51Total ;
      private string AV12Filename ;
      private string GXt_char1 ;
      private string A103ProjectName ;
      private string A148EmployeeName ;
      private string GXt_char2 ;
      private string AV35TFEmployeeName ;
      private string AV36TFProjectName ;
      private DateTime AV9FromDate ;
      private DateTime AV10ToDate ;
      private DateTime A119WorkHourLogDate ;
      private DateTime AV37TFWorkHourLogDate ;
      private bool returnInSub ;
      private bool AV24boolean ;
      private bool AV42OrderedDsc ;
      private string A123WorkHourLogDescription ;
      private string AV39TFWorkHourLogDescription ;
      private string AV16ErrorMessage ;
      private string AV27Column ;
      private string AV43FilterFullText ;
      private string A120WorkHourLogDuration ;
      private string AV38TFWorkHourLogDuration ;
      private IGxSession AV17Session ;
      private GxFile AV18File ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV33ProjectIds ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV30headerCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV49footCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV20excelcellrange ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV19excelSpreadsheet ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV50excelCellStyle ;
      private GxSimpleCollection<string> AV32Columns ;
      private IDataStoreProvider pr_default ;
      private long[] P00AI2_A106EmployeeId ;
      private string[] P00AI2_A103ProjectName ;
      private long[] P00AI2_A102ProjectId ;
      private DateTime[] P00AI2_A119WorkHourLogDate ;
      private string[] P00AI2_A148EmployeeName ;
      private string[] P00AI2_A120WorkHourLogDuration ;
      private string[] P00AI2_A123WorkHourLogDescription ;
      private short[] P00AI2_A122WorkHourLogMinute ;
      private short[] P00AI2_A121WorkHourLogHour ;
      private long[] P00AI2_A118WorkHourLogId ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV34GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
   }

   public class workhourloglistexcelexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AI2( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV33ProjectIds ,
                                             int AV33ProjectIds_Count ,
                                             string AV43FilterFullText ,
                                             long A106EmployeeId ,
                                             long AV8EmployeeId ,
                                             DateTime AV9FromDate ,
                                             DateTime A119WorkHourLogDate ,
                                             DateTime AV10ToDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T3.ProjectName, T1.ProjectId, T1.WorkHourLogDate, T2.EmployeeName, T1.WorkHourLogDuration, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV9FromDate)");
         AddWhere(sWhereString, "(POSITION(RTRIM(LOWER(:AV43FilterFullText)) IN LOWER(T3.ProjectName)) >= 1)");
         AddWhere(sWhereString, "(T1.EmployeeId = :AV8EmployeeId)");
         AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV10ToDate)");
         if ( AV33ProjectIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV33ProjectIds, "T1.ProjectId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogDate, T3.ProjectName";
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
                     return conditional_P00AI2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
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
          Object[] prmP00AI2;
          prmP00AI2 = new Object[] {
          new ParDef("AV9FromDate",GXType.Date,8,0) ,
          new ParDef("AV43FilterFullText",GXType.VarChar,40,0) ,
          new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV10ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AI2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AI2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
