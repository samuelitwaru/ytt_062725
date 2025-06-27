using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class employeehourslistdetailexport : GXProcedure
   {
      public employeehourslistdetailexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeehourslistdetailexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem> aP0_SDTEmployeeHours ,
                           out string aP1_Filename ,
                           out string aP2_ErrorMessage )
      {
         this.AV23SDTEmployeeHours = aP0_SDTEmployeeHours;
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_Filename=this.AV12Filename;
         aP2_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem> aP0_SDTEmployeeHours ,
                                out string aP1_Filename )
      {
         execute(aP0_SDTEmployeeHours, out aP1_Filename, out aP2_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem> aP0_SDTEmployeeHours ,
                                 out string aP1_Filename ,
                                 out string aP2_ErrorMessage )
      {
         this.AV23SDTEmployeeHours = aP0_SDTEmployeeHours;
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         SubmitImpl();
         aP1_Filename=this.AV12Filename;
         aP2_ErrorMessage=this.AV13ErrorMessage;
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
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S171 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S141 ();
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
         AV12Filename = GXt_char1 + "EmployeeHoursListDetailExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV37ColumnsWithSec = 0;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Employee Name";
         if ( AV36IsAuthorizedSDTEmployeeHours )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Bold = 1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Color = 11;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Work Hours";
            AV37ColumnsWithSec = (int)(AV37ColumnsWithSec+1);
         }
         if ( AV36IsAuthorizedSDTEmployeeHours )
         {
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1+AV37ColumnsWithSec, 1, 1).Bold = 1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1+AV37ColumnsWithSec, 1, 1).Color = 11;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1+AV37ColumnsWithSec, 1, 1).Text = "Leave Hours";
            AV37ColumnsWithSec = (int)(AV37ColumnsWithSec+1);
         }
      }

      protected void S141( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV23SDTEmployeeHours.Count )
         {
            AV17SDTEmployeeHoursItem = ((SdtSDTEmployeeHours_SDTEmployeeHoursItem)AV23SDTEmployeeHours.Item(AV38GXV1));
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S151 ();
            if (returnInSub) return;
            AV37ColumnsWithSec = 0;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV17SDTEmployeeHoursItem.gxTpr_Employeename, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = GXt_char1;
            if ( AV36IsAuthorizedSDTEmployeeHours )
            {
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV17SDTEmployeeHoursItem.gxTpr_Formattedworkhours, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               AV37ColumnsWithSec = (int)(AV37ColumnsWithSec+1);
            }
            if ( AV36IsAuthorizedSDTEmployeeHours )
            {
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV17SDTEmployeeHoursItem.gxTpr_Formattedleavehours, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1+AV37ColumnsWithSec, 1, 1).Text = GXt_char1;
               AV37ColumnsWithSec = (int)(AV37ColumnsWithSec+1);
            }
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S161 ();
            if (returnInSub) return;
            AV38GXV1 = (int)(AV38GXV1+1);
         }
      }

      protected void S171( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         AV36IsAuthorizedSDTEmployeeHours = (bool)(((AV39Isworkcolumnvisible==Convert.ToDecimal(true))));
         AV36IsAuthorizedSDTEmployeeHours = (bool)(((AV40Isleavecolumnvisible==Convert.ToDecimal(true))));
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
         AV19Session.Set("WWPExportFilePath", AV12Filename);
         AV19Session.Set("WWPExportFileName", "EmployeeHoursListDetailExport.xlsx");
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
         if ( StringUtil.StrCmp(AV19Session.Get("EmployeeHoursListDetailGridState"), "") == 0 )
         {
            AV21GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "EmployeeHoursListDetailGridState"), null, "", "");
         }
         else
         {
            AV21GridState.FromXml(AV19Session.Get("EmployeeHoursListDetailGridState"), null, "", "");
         }
      }

      protected void S151( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
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
         AV17SDTEmployeeHoursItem = new SdtSDTEmployeeHours_SDTEmployeeHoursItem(context);
         GXt_char1 = "";
         AV19Session = context.GetSession();
         AV21GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         /* GeneXus formulas. */
      }

      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV37ColumnsWithSec ;
      private int AV38GXV1 ;
      private decimal AV39Isworkcolumnvisible ;
      private decimal AV40Isleavecolumnvisible ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV36IsAuthorizedSDTEmployeeHours ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private IGxSession AV19Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem> AV23SDTEmployeeHours ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private SdtSDTEmployeeHours_SDTEmployeeHoursItem AV17SDTEmployeeHoursItem ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV21GridState ;
      private string aP1_Filename ;
      private string aP2_ErrorMessage ;
   }

}
