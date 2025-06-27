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
   public class prc_exportprojectoverview : GXProcedure
   {
      public prc_exportprojectoverview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_exportprojectoverview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                           GxSimpleCollection<long> aP3_ProjectIdCollection ,
                           GxSimpleCollection<long> aP4_CompanyLocationIdCollection ,
                           bool aP5_ShowLeaveTotal ,
                           GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP6_SDT_EmployeeProjectMatrixCollection ,
                           out string aP7_Filename ,
                           out string aP8_ErrorMessage )
      {
         this.AV23FromDate = aP0_FromDate;
         this.AV37ToDate = aP1_ToDate;
         this.AV15EmployeeIdCollection = aP2_EmployeeIdCollection;
         this.AV30ProjectIdCollection = aP3_ProjectIdCollection;
         this.AV14CompanyLocationIdCollection = aP4_CompanyLocationIdCollection;
         this.AV36ShowLeaveTotal = aP5_ShowLeaveTotal;
         this.AV32SDT_EmployeeProjectMatrixCollection = aP6_SDT_EmployeeProjectMatrixCollection;
         this.AV20Filename = "" ;
         this.AV16ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP7_Filename=this.AV20Filename;
         aP8_ErrorMessage=this.AV16ErrorMessage;
      }

      public string executeUdp( DateTime aP0_FromDate ,
                                DateTime aP1_ToDate ,
                                GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                                GxSimpleCollection<long> aP3_ProjectIdCollection ,
                                GxSimpleCollection<long> aP4_CompanyLocationIdCollection ,
                                bool aP5_ShowLeaveTotal ,
                                GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP6_SDT_EmployeeProjectMatrixCollection ,
                                out string aP7_Filename )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_EmployeeIdCollection, aP3_ProjectIdCollection, aP4_CompanyLocationIdCollection, aP5_ShowLeaveTotal, aP6_SDT_EmployeeProjectMatrixCollection, out aP7_Filename, out aP8_ErrorMessage);
         return AV16ErrorMessage ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_EmployeeIdCollection ,
                                 GxSimpleCollection<long> aP3_ProjectIdCollection ,
                                 GxSimpleCollection<long> aP4_CompanyLocationIdCollection ,
                                 bool aP5_ShowLeaveTotal ,
                                 GXBaseCollection<SdtSDT_EmployeeProjectMatrix> aP6_SDT_EmployeeProjectMatrixCollection ,
                                 out string aP7_Filename ,
                                 out string aP8_ErrorMessage )
      {
         this.AV23FromDate = aP0_FromDate;
         this.AV37ToDate = aP1_ToDate;
         this.AV15EmployeeIdCollection = aP2_EmployeeIdCollection;
         this.AV30ProjectIdCollection = aP3_ProjectIdCollection;
         this.AV14CompanyLocationIdCollection = aP4_CompanyLocationIdCollection;
         this.AV36ShowLeaveTotal = aP5_ShowLeaveTotal;
         this.AV32SDT_EmployeeProjectMatrixCollection = aP6_SDT_EmployeeProjectMatrixCollection;
         this.AV20Filename = "" ;
         this.AV16ErrorMessage = "" ;
         SubmitImpl();
         aP7_Filename=this.AV20Filename;
         aP8_ErrorMessage=this.AV16ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV24headerCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV24headerCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV24headerCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV24headerCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV9bodyCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV9bodyCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV22footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV22footCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV22footCellStyle.gxTpr_Font.gxTpr_Size = 13;
         AV22footCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         if ( AV30ProjectIdCollection.Count > 0 )
         {
            GXt_objcol_int1 = AV28ProjectEmployeeIdCollection;
            new getemployeeidsbyproject(context ).execute(  AV30ProjectIdCollection, out  GXt_objcol_int1) ;
            AV28ProjectEmployeeIdCollection = GXt_objcol_int1;
         }
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV32SDT_EmployeeProjectMatrixCollection.Count )
         {
            AV31SDT_EmployeeProjectMatrix = ((SdtSDT_EmployeeProjectMatrix)AV32SDT_EmployeeProjectMatrixCollection.Item(AV44GXV1));
            AV45GXV2 = 1;
            while ( AV45GXV2 <= AV31SDT_EmployeeProjectMatrix.gxTpr_Projects.Count )
            {
               AV43ProjectItem = ((SdtSDT_EmployeeProjectMatrix_ProjectsItem)AV31SDT_EmployeeProjectMatrix.gxTpr_Projects.Item(AV45GXV2));
               if ( ! (AV42ReturnedProjectIdCollection.IndexOf(AV43ProjectItem.gxTpr_Projectid)>0) )
               {
                  AV33SDTProject = new SdtSDTProject(context);
                  AV33SDTProject.gxTpr_Id = AV43ProjectItem.gxTpr_Projectid;
                  AV33SDTProject.gxTpr_Projectname = StringUtil.Trim( AV43ProjectItem.gxTpr_Projectname);
                  AV33SDTProject.gxTpr_Smallcaseprojectname = StringUtil.Trim( StringUtil.Lower( AV43ProjectItem.gxTpr_Projectname));
                  pr_default.dynParam(0, new Object[]{ new Object[]{
                                                       A157CompanyLocationId ,
                                                       AV14CompanyLocationIdCollection ,
                                                       A106EmployeeId ,
                                                       AV15EmployeeIdCollection ,
                                                       AV28ProjectEmployeeIdCollection ,
                                                       AV14CompanyLocationIdCollection.Count ,
                                                       AV15EmployeeIdCollection.Count ,
                                                       AV28ProjectEmployeeIdCollection.Count ,
                                                       A119WorkHourLogDate ,
                                                       AV23FromDate ,
                                                       AV37ToDate ,
                                                       A102ProjectId ,
                                                       AV43ProjectItem.gxTpr_Projectid } ,
                                                       new int[]{
                                                       TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                                       }
                  });
                  /* Using cursor P00B52 */
                  pr_default.execute(0, new Object[] {AV23FromDate, AV37ToDate, AV43ProjectItem.gxTpr_Projectid});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A100CompanyId = P00B52_A100CompanyId[0];
                     A106EmployeeId = P00B52_A106EmployeeId[0];
                     A157CompanyLocationId = P00B52_A157CompanyLocationId[0];
                     A119WorkHourLogDate = P00B52_A119WorkHourLogDate[0];
                     A102ProjectId = P00B52_A102ProjectId[0];
                     A121WorkHourLogHour = P00B52_A121WorkHourLogHour[0];
                     A122WorkHourLogMinute = P00B52_A122WorkHourLogMinute[0];
                     A118WorkHourLogId = P00B52_A118WorkHourLogId[0];
                     A100CompanyId = P00B52_A100CompanyId[0];
                     A157CompanyLocationId = P00B52_A157CompanyLocationId[0];
                     AV33SDTProject.gxTpr_Projecttime = (long)(AV33SDTProject.gxTpr_Projecttime+((A122WorkHourLogMinute+A121WorkHourLogHour*60)));
                     pr_default.readNext(0);
                  }
                  pr_default.close(0);
                  GXt_char2 = "";
                  new formattime(context ).execute(  AV33SDTProject.gxTpr_Projecttime, out  GXt_char2) ;
                  AV33SDTProject.gxTpr_Projectformattedtime = GXt_char2;
                  AV34SDTProjectCollection.Add(AV33SDTProject, 0);
                  AV42ReturnedProjectIdCollection.Add(AV43ProjectItem.gxTpr_Projectid, 0);
               }
               AV45GXV2 = (int)(AV45GXV2+1);
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
         AV34SDTProjectCollection.Sort("SmallCaseProjectName");
         AV13Columns.Add("Projects:", 0);
         AV47GXV3 = 1;
         while ( AV47GXV3 <= AV34SDTProjectCollection.Count )
         {
            AV33SDTProject = ((SdtSDTProject)AV34SDTProjectCollection.Item(AV47GXV3));
            AV13Columns.Add(StringUtil.Trim( AV33SDTProject.gxTpr_Projectname), 0);
            AV47GXV3 = (int)(AV47GXV3+1);
         }
         AV13Columns.Add("Total Work Hours", 0);
         if ( AV36ShowLeaveTotal )
         {
            AV13Columns.Add("Total Leave Hours", 0);
            AV13Columns.Add("Total", 0);
         }
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV17excelcellrange = AV18excelSpreadsheet.cell(1, 1);
         AV17excelcellrange.gxTpr_Valuetext = "Project Overview";
         AV8excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV8excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV8excelCellStyle.gxTpr_Font.gxTpr_Size = 14;
         AV8excelCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV8excelCellStyle.gxTpr_Alignment.gxTpr_Horizontal = 2;
         AV17excelcellrange.setcellstyle( AV8excelCellStyle);
         AV11CellRow = 2;
         AV21FirstColumn = 1;
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV40TotalWorkTime = 0;
         AV39TotalTime = 0;
         AV48GXV4 = 1;
         while ( AV48GXV4 <= AV32SDT_EmployeeProjectMatrixCollection.Count )
         {
            AV31SDT_EmployeeProjectMatrix = ((SdtSDT_EmployeeProjectMatrix)AV32SDT_EmployeeProjectMatrixCollection.Item(AV48GXV4));
            AV11CellRow = (short)(AV11CellRow+1);
            AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow, 1);
            AV17excelcellrange.gxTpr_Valuetext = StringUtil.Trim( AV31SDT_EmployeeProjectMatrix.gxTpr_Employeename);
            AV17excelcellrange.setcellstyle( AV9bodyCellStyle);
            AV49GXV5 = 1;
            while ( AV49GXV5 <= AV31SDT_EmployeeProjectMatrix.gxTpr_Projects.Count )
            {
               AV29ProjectHoursItem = ((SdtSDT_EmployeeProjectMatrix_ProjectsItem)AV31SDT_EmployeeProjectMatrix.gxTpr_Projects.Item(AV49GXV5));
               AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow, AV13Columns.IndexOf(StringUtil.Trim( AV29ProjectHoursItem.gxTpr_Projectname)));
               GXt_char2 = "";
               new formattime(context ).execute(  AV29ProjectHoursItem.gxTpr_Projecthours, out  GXt_char2) ;
               AV17excelcellrange.gxTpr_Valuetext = GXt_char2;
               AV17excelcellrange.setcellstyle( AV9bodyCellStyle);
               AV49GXV5 = (int)(AV49GXV5+1);
            }
            AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow, AV13Columns.IndexOf("Total Work Hours"));
            AV17excelcellrange.gxTpr_Valuetext = AV31SDT_EmployeeProjectMatrix.gxTpr_Formattedworkhours;
            AV17excelcellrange.setcellstyle( AV9bodyCellStyle);
            AV40TotalWorkTime = (long)(AV40TotalWorkTime+(AV31SDT_EmployeeProjectMatrix.gxTpr_Workhours));
            AV39TotalTime = (long)(AV39TotalTime+(AV31SDT_EmployeeProjectMatrix.gxTpr_Employeehours));
            if ( AV36ShowLeaveTotal )
            {
               AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow, AV13Columns.IndexOf("Total Leave Hours"));
               AV17excelcellrange.gxTpr_Valuetext = AV31SDT_EmployeeProjectMatrix.gxTpr_Formattedleavehours;
               AV17excelcellrange.setcellstyle( AV9bodyCellStyle);
               AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow, AV13Columns.IndexOf("Total"));
               AV17excelcellrange.gxTpr_Valuetext = AV31SDT_EmployeeProjectMatrix.gxTpr_Formattedemployeehours;
               AV17excelcellrange.setcellstyle( AV9bodyCellStyle);
            }
            AV48GXV4 = (int)(AV48GXV4+1);
         }
         AV11CellRow = (short)(AV11CellRow+1);
         AV41VisibleColumnCount = 0;
         AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow, AV21FirstColumn+AV41VisibleColumnCount);
         AV17excelcellrange.gxTpr_Valuetext = "Total";
         AV17excelcellrange.setcellstyle( AV22footCellStyle);
         AV50GXV6 = 1;
         while ( AV50GXV6 <= AV34SDTProjectCollection.Count )
         {
            AV33SDTProject = ((SdtSDTProject)AV34SDTProjectCollection.Item(AV50GXV6));
            AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow, AV13Columns.IndexOf(StringUtil.Trim( AV33SDTProject.gxTpr_Projectname)));
            AV17excelcellrange.gxTpr_Valuetext = AV33SDTProject.gxTpr_Projectformattedtime;
            AV17excelcellrange.setcellstyle( AV22footCellStyle);
            AV50GXV6 = (int)(AV50GXV6+1);
         }
         AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow, AV13Columns.IndexOf("Total Work Hours"));
         GXt_char2 = "";
         new formattime(context ).execute(  AV40TotalWorkTime, out  GXt_char2) ;
         AV17excelcellrange.gxTpr_Valuetext = GXt_char2;
         AV17excelcellrange.setcellstyle( AV8excelCellStyle);
         if ( AV36ShowLeaveTotal )
         {
            AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow, AV13Columns.IndexOf("Total"));
            GXt_char2 = "";
            new formattime(context ).execute(  AV39TotalTime, out  GXt_char2) ;
            AV17excelcellrange.gxTpr_Valuetext = GXt_char2;
            AV17excelcellrange.setcellstyle( AV8excelCellStyle);
         }
         AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow+2, 1);
         GXt_char2 = "";
         new formatdatetime(context ).execute(  AV23FromDate,  "DD.MM.YYYY", out  GXt_char2) ;
         AV17excelcellrange.gxTpr_Valuetext = "Start Date "+GXt_char2;
         AV17excelcellrange.setcellstyle( AV22footCellStyle);
         AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow+3, 1);
         GXt_char2 = "";
         new formatdatetime(context ).execute(  AV37ToDate,  "DD.MM.YYYY", out  GXt_char2) ;
         AV17excelcellrange.gxTpr_Valuetext = "End Date "+GXt_char2;
         AV17excelcellrange.setcellstyle( AV22footCellStyle);
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S131 ();
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
         GXt_char2 = AV20Filename;
         new formatdatetime(context ).execute(  AV23FromDate,  "YYYY-MM-DD", out  GXt_char2) ;
         GXt_char3 = AV20Filename;
         new formatdatetime(context ).execute(  AV37ToDate,  "YYYY-MM-DD", out  GXt_char3) ;
         AV20Filename = "HoursReport-" + GXt_char2 + "_" + GXt_char3 + ".xlsx";
         AV19File.Source = AV20Filename;
         AV19File.Delete();
         AV18excelSpreadsheet.open( AV20Filename);
      }

      protected void S121( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV41VisibleColumnCount = 0;
         AV51GXV7 = 1;
         while ( AV51GXV7 <= AV13Columns.Count )
         {
            AV12Column = ((string)AV13Columns.Item(AV51GXV7));
            AV17excelcellrange = AV18excelSpreadsheet.cell(AV11CellRow, AV21FirstColumn+AV41VisibleColumnCount);
            AV17excelcellrange.gxTpr_Valuetext = AV12Column;
            AV17excelcellrange.setcellstyle( AV24headerCellStyle);
            AV41VisibleColumnCount = (short)(AV41VisibleColumnCount+1);
            AV51GXV7 = (int)(AV51GXV7+1);
         }
      }

      protected void S131( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV18excelSpreadsheet.gxTpr_Autofit = true;
         AV10boolean = AV18excelSpreadsheet.save();
         if ( AV10boolean )
         {
            AV18excelSpreadsheet.close();
         }
         else
         {
            GX_msglist.addItem("Error code:"+StringUtil.Str( (decimal)(AV18excelSpreadsheet.gxTpr_Errcode), 8, 0));
            GX_msglist.addItem("Error description:"+AV18excelSpreadsheet.gxTpr_Errdescription);
         }
         AV35Session.Set("WWPExportFilePath", AV20Filename);
         AV35Session.Set("WWPExportFileName", AV20Filename);
         AV20Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
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
         AV20Filename = "";
         AV16ErrorMessage = "";
         AV24headerCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV9bodyCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV22footCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV28ProjectEmployeeIdCollection = new GxSimpleCollection<long>();
         GXt_objcol_int1 = new GxSimpleCollection<long>();
         AV31SDT_EmployeeProjectMatrix = new SdtSDT_EmployeeProjectMatrix(context);
         AV43ProjectItem = new SdtSDT_EmployeeProjectMatrix_ProjectsItem(context);
         AV42ReturnedProjectIdCollection = new GxSimpleCollection<long>();
         AV33SDTProject = new SdtSDTProject(context);
         A119WorkHourLogDate = DateTime.MinValue;
         P00B52_A100CompanyId = new long[1] ;
         P00B52_A106EmployeeId = new long[1] ;
         P00B52_A157CompanyLocationId = new long[1] ;
         P00B52_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00B52_A102ProjectId = new long[1] ;
         P00B52_A121WorkHourLogHour = new short[1] ;
         P00B52_A122WorkHourLogMinute = new short[1] ;
         P00B52_A118WorkHourLogId = new long[1] ;
         AV34SDTProjectCollection = new GXBaseCollection<SdtSDTProject>( context, "SDTProject", "YTT_version4");
         AV13Columns = new GxSimpleCollection<string>();
         AV17excelcellrange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV18excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         AV8excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV29ProjectHoursItem = new SdtSDT_EmployeeProjectMatrix_ProjectsItem(context);
         GXt_char2 = "";
         GXt_char3 = "";
         AV19File = new GxFile(context.GetPhysicalPath());
         AV12Column = "";
         AV35Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_exportprojectoverview__default(),
            new Object[][] {
                new Object[] {
               P00B52_A100CompanyId, P00B52_A106EmployeeId, P00B52_A157CompanyLocationId, P00B52_A119WorkHourLogDate, P00B52_A102ProjectId, P00B52_A121WorkHourLogHour, P00B52_A122WorkHourLogMinute, P00B52_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short AV11CellRow ;
      private short AV21FirstColumn ;
      private short AV41VisibleColumnCount ;
      private int AV44GXV1 ;
      private int AV45GXV2 ;
      private int AV14CompanyLocationIdCollection_Count ;
      private int AV15EmployeeIdCollection_Count ;
      private int AV28ProjectEmployeeIdCollection_Count ;
      private int AV47GXV3 ;
      private int AV48GXV4 ;
      private int AV49GXV5 ;
      private int AV50GXV6 ;
      private int AV51GXV7 ;
      private long AV43ProjectItem_gxTpr_Projectid ;
      private long A157CompanyLocationId ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A100CompanyId ;
      private long A118WorkHourLogId ;
      private long AV40TotalWorkTime ;
      private long AV39TotalTime ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private DateTime AV23FromDate ;
      private DateTime AV37ToDate ;
      private DateTime A119WorkHourLogDate ;
      private bool AV36ShowLeaveTotal ;
      private bool returnInSub ;
      private bool AV10boolean ;
      private string AV20Filename ;
      private string AV16ErrorMessage ;
      private string AV12Column ;
      private IGxSession AV35Session ;
      private GxFile AV19File ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV15EmployeeIdCollection ;
      private GxSimpleCollection<long> AV30ProjectIdCollection ;
      private GxSimpleCollection<long> AV14CompanyLocationIdCollection ;
      private GXBaseCollection<SdtSDT_EmployeeProjectMatrix> AV32SDT_EmployeeProjectMatrixCollection ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV24headerCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV9bodyCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV22footCellStyle ;
      private GxSimpleCollection<long> AV28ProjectEmployeeIdCollection ;
      private GxSimpleCollection<long> GXt_objcol_int1 ;
      private SdtSDT_EmployeeProjectMatrix AV31SDT_EmployeeProjectMatrix ;
      private SdtSDT_EmployeeProjectMatrix_ProjectsItem AV43ProjectItem ;
      private GxSimpleCollection<long> AV42ReturnedProjectIdCollection ;
      private SdtSDTProject AV33SDTProject ;
      private IDataStoreProvider pr_default ;
      private long[] P00B52_A100CompanyId ;
      private long[] P00B52_A106EmployeeId ;
      private long[] P00B52_A157CompanyLocationId ;
      private DateTime[] P00B52_A119WorkHourLogDate ;
      private long[] P00B52_A102ProjectId ;
      private short[] P00B52_A121WorkHourLogHour ;
      private short[] P00B52_A122WorkHourLogMinute ;
      private long[] P00B52_A118WorkHourLogId ;
      private GXBaseCollection<SdtSDTProject> AV34SDTProjectCollection ;
      private GxSimpleCollection<string> AV13Columns ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV17excelcellrange ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV18excelSpreadsheet ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV8excelCellStyle ;
      private SdtSDT_EmployeeProjectMatrix_ProjectsItem AV29ProjectHoursItem ;
      private string aP7_Filename ;
      private string aP8_ErrorMessage ;
   }

   public class prc_exportprojectoverview__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B52( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV14CompanyLocationIdCollection ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV15EmployeeIdCollection ,
                                             GxSimpleCollection<long> AV28ProjectEmployeeIdCollection ,
                                             int AV14CompanyLocationIdCollection_Count ,
                                             int AV15EmployeeIdCollection_Count ,
                                             int AV28ProjectEmployeeIdCollection_Count ,
                                             DateTime A119WorkHourLogDate ,
                                             DateTime AV23FromDate ,
                                             DateTime AV37ToDate ,
                                             long A102ProjectId ,
                                             long AV43ProjectItem_gxTpr_Projectid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[3];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.CompanyId, T1.EmployeeId, T3.CompanyLocationId, T1.WorkHourLogDate, T1.ProjectId, T1.WorkHourLogHour, T1.WorkHourLogMinute, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId)";
         AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV23FromDate and T1.WorkHourLogDate <= :AV37ToDate)");
         AddWhere(sWhereString, "(T1.ProjectId = :AV43ProjectItem__Projectid)");
         if ( AV14CompanyLocationIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV14CompanyLocationIdCollection, "T3.CompanyLocationId IN (", ")")+")");
         }
         if ( AV15EmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV15EmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         if ( AV28ProjectEmployeeIdCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28ProjectEmployeeIdCollection, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogId";
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
                     return conditional_P00B52(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (GxSimpleCollection<long>)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmP00B52;
          prmP00B52 = new Object[] {
          new ParDef("AV23FromDate",GXType.Date,8,0) ,
          new ParDef("AV37ToDate",GXType.Date,8,0) ,
          new ParDef("AV43ProjectItem__Projectid",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B52", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B52,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
