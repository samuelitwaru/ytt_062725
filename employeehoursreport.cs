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
   public class employeehoursreport : GXProcedure
   {
      public employeehoursreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeehoursreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FromDate ,
                           ref DateTime aP1_ToDate ,
                           ref GxSimpleCollection<long> aP2_ProjectId ,
                           ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP4_EmployeeId ,
                           out string aP5_Filename ,
                           out string aP6_ErrorMessage )
      {
         this.AV9FromDate = aP0_FromDate;
         this.AV10ToDate = aP1_ToDate;
         this.AV16ProjectId = aP2_ProjectId;
         this.AV12CompanyLocationId = aP3_CompanyLocationId;
         this.AV13EmployeeId = aP4_EmployeeId;
         this.AV27Filename = "" ;
         this.AV26ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_FromDate=this.AV9FromDate;
         aP1_ToDate=this.AV10ToDate;
         aP2_ProjectId=this.AV16ProjectId;
         aP3_CompanyLocationId=this.AV12CompanyLocationId;
         aP4_EmployeeId=this.AV13EmployeeId;
         aP5_Filename=this.AV27Filename;
         aP6_ErrorMessage=this.AV26ErrorMessage;
      }

      public string executeUdp( ref DateTime aP0_FromDate ,
                                ref DateTime aP1_ToDate ,
                                ref GxSimpleCollection<long> aP2_ProjectId ,
                                ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP4_EmployeeId ,
                                out string aP5_Filename )
      {
         execute(ref aP0_FromDate, ref aP1_ToDate, ref aP2_ProjectId, ref aP3_CompanyLocationId, ref aP4_EmployeeId, out aP5_Filename, out aP6_ErrorMessage);
         return AV26ErrorMessage ;
      }

      public void executeSubmit( ref DateTime aP0_FromDate ,
                                 ref DateTime aP1_ToDate ,
                                 ref GxSimpleCollection<long> aP2_ProjectId ,
                                 ref GxSimpleCollection<long> aP3_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP4_EmployeeId ,
                                 out string aP5_Filename ,
                                 out string aP6_ErrorMessage )
      {
         this.AV9FromDate = aP0_FromDate;
         this.AV10ToDate = aP1_ToDate;
         this.AV16ProjectId = aP2_ProjectId;
         this.AV12CompanyLocationId = aP3_CompanyLocationId;
         this.AV13EmployeeId = aP4_EmployeeId;
         this.AV27Filename = "" ;
         this.AV26ErrorMessage = "" ;
         SubmitImpl();
         aP0_FromDate=this.AV9FromDate;
         aP1_ToDate=this.AV10ToDate;
         aP2_ProjectId=this.AV16ProjectId;
         aP3_CompanyLocationId=this.AV12CompanyLocationId;
         aP4_EmployeeId=this.AV13EmployeeId;
         aP5_Filename=this.AV27Filename;
         aP6_ErrorMessage=this.AV26ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: 'GETSESSIONVARIABLES' */
         S161 ();
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
         AV25TotalMinutes = 0;
         AV29headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV29headerCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV29headerCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV29headerCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV30leftAlign = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV30leftAlign.gxTpr_Alignment.gxTpr_Horizontal = 1;
         AV32footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV32footCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV32footCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV32footCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         /* Using cursor P00A22 */
         pr_default.execute(0, new Object[] {AV8OneProjectId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A102ProjectId = P00A22_A102ProjectId[0];
            A103ProjectName = P00A22_A103ProjectName[0];
            AV19excelcellrange = AV11excelSpreadsheet.cell(1, 1);
            AV19excelcellrange.gxTpr_Valuetext = "Timeline Report ("+StringUtil.Trim( A103ProjectName)+")";
            AV20excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
            AV20excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
            AV20excelCellStyle.gxTpr_Font.gxTpr_Size = 14;
            AV20excelCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
            AV19excelcellrange.setcellstyle( AV20excelCellStyle);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFOOT' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S151 ();
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
         GXt_char1 = AV27Filename;
         new formatdatetime(context ).execute(  AV9FromDate,  "YYYY-MM-DD", out  GXt_char1) ;
         GXt_char2 = AV27Filename;
         new formatdatetime(context ).execute(  AV10ToDate,  "YYYY-MM-DD", out  GXt_char2) ;
         AV27Filename = "HoursReport-" + GXt_char1 + "_" + GXt_char2 + ".xlsx";
         AV31File.Source = AV27Filename;
         AV31File.Delete();
         AV11excelSpreadsheet.open( AV27Filename);
      }

      protected void S121( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV23CellRow = 2;
         AV24FirstColumn = 1;
         AV21Columns.Add("Date", 0);
         AV21Columns.Add("Employee Name", 0);
         AV21Columns.Add("Project", 0);
         AV21Columns.Add("Duration", 0);
         AV21Columns.Add("Description", 0);
         AV28VisibleColumnCount = 0;
         AV34GXV1 = 1;
         while ( AV34GXV1 <= AV21Columns.Count )
         {
            AV22Column = AV21Columns.GetString(AV34GXV1);
            AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, AV24FirstColumn+AV28VisibleColumnCount);
            AV19excelcellrange.setcellstyle( AV29headerCellStyle);
            AV19excelcellrange.gxTpr_Valuetext = AV22Column;
            AV28VisibleColumnCount = (short)(AV28VisibleColumnCount+1);
            AV34GXV1 = (int)(AV34GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV23CellRow = (short)(AV23CellRow+2);
         AV24FirstColumn = 1;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV12CompanyLocationId ,
                                              A106EmployeeId ,
                                              AV13EmployeeId ,
                                              AV8OneProjectId ,
                                              AV12CompanyLocationId.Count ,
                                              AV13EmployeeId.Count ,
                                              AV9FromDate ,
                                              AV10ToDate ,
                                              A102ProjectId ,
                                              A119WorkHourLogDate } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00A23 */
         pr_default.execute(1, new Object[] {AV8OneProjectId, AV9FromDate, AV10ToDate});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKA23 = false;
            A100CompanyId = P00A23_A100CompanyId[0];
            A148EmployeeName = P00A23_A148EmployeeName[0];
            A103ProjectName = P00A23_A103ProjectName[0];
            A120WorkHourLogDuration = P00A23_A120WorkHourLogDuration[0];
            A123WorkHourLogDescription = P00A23_A123WorkHourLogDescription[0];
            A122WorkHourLogMinute = P00A23_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00A23_A121WorkHourLogHour[0];
            A119WorkHourLogDate = P00A23_A119WorkHourLogDate[0];
            A106EmployeeId = P00A23_A106EmployeeId[0];
            A157CompanyLocationId = P00A23_A157CompanyLocationId[0];
            A102ProjectId = P00A23_A102ProjectId[0];
            A118WorkHourLogId = P00A23_A118WorkHourLogId[0];
            A100CompanyId = P00A23_A100CompanyId[0];
            A148EmployeeName = P00A23_A148EmployeeName[0];
            A157CompanyLocationId = P00A23_A157CompanyLocationId[0];
            A103ProjectName = P00A23_A103ProjectName[0];
            AV14TotalWorkTime = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00A23_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRKA23 = false;
               A103ProjectName = P00A23_A103ProjectName[0];
               A120WorkHourLogDuration = P00A23_A120WorkHourLogDuration[0];
               A123WorkHourLogDescription = P00A23_A123WorkHourLogDescription[0];
               A122WorkHourLogMinute = P00A23_A122WorkHourLogMinute[0];
               A121WorkHourLogHour = P00A23_A121WorkHourLogHour[0];
               A119WorkHourLogDate = P00A23_A119WorkHourLogDate[0];
               A106EmployeeId = P00A23_A106EmployeeId[0];
               A102ProjectId = P00A23_A102ProjectId[0];
               A118WorkHourLogId = P00A23_A118WorkHourLogId[0];
               A103ProjectName = P00A23_A103ProjectName[0];
               AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, AV24FirstColumn+0);
               AV19excelcellrange.setcellstyle( AV30leftAlign);
               GXt_char2 = "";
               new formatdatetime(context ).execute(  A119WorkHourLogDate,  "DD/MM/YYYY", out  GXt_char2) ;
               AV19excelcellrange.gxTpr_Valuetext = GXt_char2;
               AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, AV24FirstColumn+1);
               AV19excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A148EmployeeName);
               AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, AV24FirstColumn+2);
               AV19excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A103ProjectName);
               AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, AV24FirstColumn+3);
               AV19excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A120WorkHourLogDuration);
               AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, AV24FirstColumn+4);
               AV19excelcellrange.gxTpr_Valuetext = StringUtil.Trim( A123WorkHourLogDescription);
               AV14TotalWorkTime = (decimal)(AV14TotalWorkTime+((A121WorkHourLogHour*60)+A122WorkHourLogMinute));
               AV23CellRow = (short)(AV23CellRow+1);
               BRKA23 = true;
               pr_default.readNext(1);
            }
            AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, AV24FirstColumn);
            AV19excelcellrange.gxTpr_Valuetext = "Total";
            AV20excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
            AV20excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
            AV20excelCellStyle.gxTpr_Font.gxTpr_Size = 13;
            AV19excelcellrange.setcellstyle( AV20excelCellStyle);
            AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, AV24FirstColumn+1);
            GXt_char2 = "";
            new procformattime(context ).execute(  (long)(Math.Round(AV14TotalWorkTime, 18, MidpointRounding.ToEven)), out  GXt_char2) ;
            AV19excelcellrange.gxTpr_Valuetext = GXt_char2;
            AV19excelcellrange.setcellstyle( AV20excelCellStyle);
            AV25TotalMinutes = (int)(AV25TotalMinutes+AV14TotalWorkTime);
            AV23CellRow = (short)(AV23CellRow+2);
            if ( ! BRKA23 )
            {
               BRKA23 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'WRITEFOOT' Routine */
         returnInSub = false;
         AV23CellRow = (short)(AV23CellRow+1);
         AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, 1);
         GXt_char2 = "";
         new formatdatetime(context ).execute(  AV9FromDate,  "DD.MM.YYYY", out  GXt_char2) ;
         AV19excelcellrange.gxTpr_Valuetext = "Start Date "+GXt_char2;
         AV19excelcellrange.setcellstyle( AV32footCellStyle);
         AV23CellRow = (short)(AV23CellRow+1);
         AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, 1);
         GXt_char2 = "";
         new formatdatetime(context ).execute(  AV10ToDate,  "DD.MM.YYYY", out  GXt_char2) ;
         AV19excelcellrange.gxTpr_Valuetext = "End Date "+GXt_char2;
         AV19excelcellrange.setcellstyle( AV32footCellStyle);
         AV23CellRow = (short)(AV23CellRow+1);
         AV19excelcellrange = AV11excelSpreadsheet.cell(AV23CellRow, 1);
         GXt_char2 = "";
         new procformattime(context ).execute(  AV25TotalMinutes, out  GXt_char2) ;
         AV19excelcellrange.gxTpr_Valuetext = "Hours Total "+GXt_char2;
         AV19excelcellrange.setcellstyle( AV32footCellStyle);
      }

      protected void S151( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV11excelSpreadsheet.gxTpr_Autofit = true;
         AV18boolean = AV11excelSpreadsheet.save();
         if ( AV18boolean )
         {
            AV11excelSpreadsheet.close();
         }
         else
         {
            GX_msglist.addItem("Error code:"+StringUtil.Str( (decimal)(AV11excelSpreadsheet.gxTpr_Errcode), 8, 0));
            GX_msglist.addItem("Error description:"+AV11excelSpreadsheet.gxTpr_Errdescription);
         }
         AV17Session.Set("WWPExportFilePath", AV27Filename);
         AV17Session.Set("WWPExportFileName", AV27Filename);
         AV27Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S161( )
      {
         /* 'GETSESSIONVARIABLES' Routine */
         returnInSub = false;
         AV12CompanyLocationId.FromJSonString(AV15WebSession.Get("CompanyLocationId"), null);
         AV13EmployeeId.FromJSonString(AV15WebSession.Get("EmployeeId"), null);
         AV16ProjectId.FromJSonString(AV15WebSession.Get("ProjectId"), null);
         AV8OneProjectId = (long)(Math.Round(NumberUtil.Val( AV15WebSession.Get("OneProjectId"), "."), 18, MidpointRounding.ToEven));
         AV9FromDate = context.localUtil.CToD( AV15WebSession.Get("FromDate"), 2);
         AV10ToDate = context.localUtil.CToD( AV15WebSession.Get("ToDate"), 2);
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
         AV27Filename = "";
         AV26ErrorMessage = "";
         AV29headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV30leftAlign = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV32footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         P00A22_A102ProjectId = new long[1] ;
         P00A22_A103ProjectName = new string[] {""} ;
         A103ProjectName = "";
         AV19excelcellrange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV11excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         AV20excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         GXt_char1 = "";
         AV31File = new GxFile(context.GetPhysicalPath());
         AV21Columns = new GxSimpleCollection<string>();
         AV22Column = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P00A23_A100CompanyId = new long[1] ;
         P00A23_A148EmployeeName = new string[] {""} ;
         P00A23_A103ProjectName = new string[] {""} ;
         P00A23_A120WorkHourLogDuration = new string[] {""} ;
         P00A23_A123WorkHourLogDescription = new string[] {""} ;
         P00A23_A122WorkHourLogMinute = new short[1] ;
         P00A23_A121WorkHourLogHour = new short[1] ;
         P00A23_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00A23_A106EmployeeId = new long[1] ;
         P00A23_A157CompanyLocationId = new long[1] ;
         P00A23_A102ProjectId = new long[1] ;
         P00A23_A118WorkHourLogId = new long[1] ;
         A148EmployeeName = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         GXt_char2 = "";
         AV17Session = context.GetSession();
         AV15WebSession = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeehoursreport__default(),
            new Object[][] {
                new Object[] {
               P00A22_A102ProjectId, P00A22_A103ProjectName
               }
               , new Object[] {
               P00A23_A100CompanyId, P00A23_A148EmployeeName, P00A23_A103ProjectName, P00A23_A120WorkHourLogDuration, P00A23_A123WorkHourLogDescription, P00A23_A122WorkHourLogMinute, P00A23_A121WorkHourLogHour, P00A23_A119WorkHourLogDate, P00A23_A106EmployeeId, P00A23_A157CompanyLocationId,
               P00A23_A102ProjectId, P00A23_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23CellRow ;
      private short AV24FirstColumn ;
      private short AV28VisibleColumnCount ;
      private short A122WorkHourLogMinute ;
      private short A121WorkHourLogHour ;
      private int AV25TotalMinutes ;
      private int AV34GXV1 ;
      private int AV12CompanyLocationId_Count ;
      private int AV13EmployeeId_Count ;
      private long AV8OneProjectId ;
      private long A102ProjectId ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A118WorkHourLogId ;
      private decimal AV14TotalWorkTime ;
      private string A103ProjectName ;
      private string GXt_char1 ;
      private string AV22Column ;
      private string A148EmployeeName ;
      private string GXt_char2 ;
      private DateTime AV9FromDate ;
      private DateTime AV10ToDate ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool BRKA23 ;
      private bool AV18boolean ;
      private string A123WorkHourLogDescription ;
      private string AV27Filename ;
      private string AV26ErrorMessage ;
      private string A120WorkHourLogDuration ;
      private IGxSession AV15WebSession ;
      private IGxSession AV17Session ;
      private GxFile AV31File ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FromDate ;
      private DateTime aP1_ToDate ;
      private GxSimpleCollection<long> AV16ProjectId ;
      private GxSimpleCollection<long> aP2_ProjectId ;
      private GxSimpleCollection<long> AV12CompanyLocationId ;
      private GxSimpleCollection<long> aP3_CompanyLocationId ;
      private GxSimpleCollection<long> AV13EmployeeId ;
      private GxSimpleCollection<long> aP4_EmployeeId ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV29headerCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV30leftAlign ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV32footCellStyle ;
      private IDataStoreProvider pr_default ;
      private long[] P00A22_A102ProjectId ;
      private string[] P00A22_A103ProjectName ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV19excelcellrange ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV11excelSpreadsheet ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV20excelCellStyle ;
      private GxSimpleCollection<string> AV21Columns ;
      private long[] P00A23_A100CompanyId ;
      private string[] P00A23_A148EmployeeName ;
      private string[] P00A23_A103ProjectName ;
      private string[] P00A23_A120WorkHourLogDuration ;
      private string[] P00A23_A123WorkHourLogDescription ;
      private short[] P00A23_A122WorkHourLogMinute ;
      private short[] P00A23_A121WorkHourLogHour ;
      private DateTime[] P00A23_A119WorkHourLogDate ;
      private long[] P00A23_A106EmployeeId ;
      private long[] P00A23_A157CompanyLocationId ;
      private long[] P00A23_A102ProjectId ;
      private long[] P00A23_A118WorkHourLogId ;
      private string aP5_Filename ;
      private string aP6_ErrorMessage ;
   }

   public class employeehoursreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A23( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV12CompanyLocationId ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV13EmployeeId ,
                                             long AV8OneProjectId ,
                                             int AV12CompanyLocationId_Count ,
                                             int AV13EmployeeId_Count ,
                                             DateTime AV9FromDate ,
                                             DateTime AV10ToDate ,
                                             long A102ProjectId ,
                                             DateTime A119WorkHourLogDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[3];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.CompanyId, T2.EmployeeName, T4.ProjectName, T1.WorkHourLogDuration, T1.WorkHourLogDescription, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDate, T1.EmployeeId, T3.CompanyLocationId, T1.ProjectId, T1.WorkHourLogId FROM (((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) INNER JOIN Project T4 ON T4.ProjectId = T1.ProjectId)";
         if ( ! (0==AV8OneProjectId) )
         {
            AddWhere(sWhereString, "(T1.ProjectId = :AV8OneProjectId)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( AV12CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV12CompanyLocationId, "T3.CompanyLocationId IN (", ")")+")");
         }
         if ( AV13EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13EmployeeId, "T1.EmployeeId IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV9FromDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV9FromDate)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV10ToDate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV10ToDate)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.EmployeeName, T1.WorkHourLogDate";
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
               case 1 :
                     return conditional_P00A23(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (long)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (long)dynConstraints[9] , (DateTime)dynConstraints[10] );
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
          Object[] prmP00A22;
          prmP00A22 = new Object[] {
          new ParDef("AV8OneProjectId",GXType.Int64,10,0)
          };
          Object[] prmP00A23;
          prmP00A23 = new Object[] {
          new ParDef("AV8OneProjectId",GXType.Int64,10,0) ,
          new ParDef("AV9FromDate",GXType.Date,8,0) ,
          new ParDef("AV10ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A22", "SELECT ProjectId, ProjectName FROM Project WHERE ProjectId = :AV8OneProjectId ORDER BY ProjectId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00A23", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A23,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                return;
       }
    }

 }

}
