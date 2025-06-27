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
   public class wpleavereportexport : GXProcedure
   {
      public wpleavereportexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpleavereportexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtSDTLeaveReport aP0_SDTLeaveReport ,
                           out string aP1_Filename ,
                           out string aP2_ErrorMessage )
      {
         this.AV29SDTLeaveReport = aP0_SDTLeaveReport;
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_Filename=this.AV12Filename;
         aP2_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( SdtSDTLeaveReport aP0_SDTLeaveReport ,
                                out string aP1_Filename )
      {
         execute(aP0_SDTLeaveReport, out aP1_Filename, out aP2_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( SdtSDTLeaveReport aP0_SDTLeaveReport ,
                                 out string aP1_Filename ,
                                 out string aP2_ErrorMessage )
      {
         this.AV29SDTLeaveReport = aP0_SDTLeaveReport;
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
         AV12Filename = GXt_char1 + "WPLeaveReportExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (DateTime.MinValue==AV18Date) && (DateTime.MinValue==AV19Date_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Date Range") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV18Date ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  " - ") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV19Date_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (0==AV20PeriodicCategory) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "View") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = gxdomainperiodiccategory.getDescription(context,AV20PeriodicCategory);
         }
         if ( ! ( (0==AV24EmployeeId) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Employee") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new wpleavereportloaddvcombo(context ).execute(  "EmployeeId",  "GET_DSC",  StringUtil.Str( (decimal)(AV24EmployeeId), 10, 0), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( ( AV44ProjectId.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Project") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new wpleavereportloaddvcombo(context ).execute(  "ProjectId",  "GET_DSC_TEXT",  AV44ProjectId.ToJSonString(false), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( (0==AV46CompanyLocationId) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Location") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new wpleavereportloaddvcombo(context ).execute(  "CompanyLocationId",  "GET_DSC",  StringUtil.Str( (decimal)(AV46CompanyLocationId), 10, 0), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV38VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV25Session.Get("WPLeaveReportColumnsSelector"), "") != 0 )
         {
            AV33ColumnsSelectorXML = AV25Session.Get("WPLeaveReportColumnsSelector");
            AV30ColumnsSelector.FromXml(AV33ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV30ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV30ColumnsSelector.gxTpr_Columns.Count )
         {
            AV32ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV30ColumnsSelector.gxTpr_Columns.Item(AV47GXV1));
            if ( AV32ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV32ColumnsSelector_Column.gxTpr_Displayname)) ? AV32ColumnsSelector_Column.gxTpr_Columnname : AV32ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Color = 11;
               AV38VisibleColumnCount = (long)(AV38VisibleColumnCount+1);
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV48GXV2 = 1;
         while ( AV48GXV2 <= AV29SDTLeaveReport.gxTpr_Periodcollection.Count )
         {
            AV17SDTLeaveReportItem = ((SdtSDTLeaveReport_PeriodCollectionItem)AV29SDTLeaveReport.gxTpr_Periodcollection.Item(AV48GXV2));
            AV14CellRow = (int)(AV14CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S171 ();
            if (returnInSub) return;
            AV38VisibleColumnCount = 0;
            AV49GXV3 = 1;
            while ( AV49GXV3 <= AV30ColumnsSelector.gxTpr_Columns.Count )
            {
               AV32ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV30ColumnsSelector.gxTpr_Columns.Item(AV49GXV3));
               if ( AV32ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV32ColumnsSelector_Column.gxTpr_Columnname, "SDTLeaveReport_PeriodCollection__Label") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV17SDTLeaveReportItem.gxTpr_Label, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV32ColumnsSelector_Column.gxTpr_Columnname, "SDTLeaveReport_PeriodCollection__FromDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( AV17SDTLeaveReportItem.gxTpr_Fromdate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV32ColumnsSelector_Column.gxTpr_Columnname, "SDTLeaveReport_PeriodCollection__ToDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( AV17SDTLeaveReportItem.gxTpr_Todate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV32ColumnsSelector_Column.gxTpr_Columnname, "SDTLeaveReport_PeriodCollection__FormattedTotalWork") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV17SDTLeaveReportItem.gxTpr_Formattedtotalwork, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV32ColumnsSelector_Column.gxTpr_Columnname, "SDTLeaveReport_PeriodCollection__FormattedTotalLeave") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV17SDTLeaveReportItem.gxTpr_Formattedtotalleave, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV38VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV38VisibleColumnCount = (long)(AV38VisibleColumnCount+1);
               }
               AV49GXV3 = (int)(AV49GXV3+1);
            }
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S181 ();
            if (returnInSub) return;
            AV48GXV2 = (int)(AV48GXV2+1);
         }
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
         AV25Session.Set("WWPExportFilePath", AV12Filename);
         AV25Session.Set("WWPExportFileName", "WPLeaveReportExport.xlsx");
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
         AV30ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV30ColumnsSelector,  "SDTLeaveReport_PeriodCollection__Label",  "",  "Period",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV30ColumnsSelector,  "SDTLeaveReport_PeriodCollection__FromDate",  "",  "DateFrom",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV30ColumnsSelector,  "SDTLeaveReport_PeriodCollection__ToDate",  "",  "Date To",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV30ColumnsSelector,  "SDTLeaveReport_PeriodCollection__FormattedTotalWork",  "",  "Work Hours",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV30ColumnsSelector,  "SDTLeaveReport_PeriodCollection__FormattedTotalLeave",  "",  "Leave Hours",  true,  "") ;
         GXt_char1 = AV34UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WPLeaveReportColumnsSelector", out  GXt_char1) ;
         AV34UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34UserCustomValue)) ) )
         {
            AV31ColumnsSelectorAux.FromXml(AV34UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV31ColumnsSelectorAux, ref  AV30ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV25Session.Get("WPLeaveReportGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WPLeaveReportGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("WPLeaveReportGridState"), null, "", "");
         }
         AV50GXV4 = 1;
         while ( AV50GXV4 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV50GXV4));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "DATE") == 0 )
            {
               AV18Date = context.localUtil.CToD( AV28GridStateFilterValue.gxTpr_Value, 2);
               AV19Date_To = context.localUtil.CToD( AV28GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "PERIODICCATEGORY") == 0 )
            {
               AV20PeriodicCategory = (short)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "EMPLOYEEID") == 0 )
            {
               AV24EmployeeId = (long)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "PROJECTID") == 0 )
            {
               AV44ProjectId.FromJSonString(AV28GridStateFilterValue.gxTpr_Value, null);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "COMPANYLOCATIONID") == 0 )
            {
               AV46CompanyLocationId = (long)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV50GXV4 = (int)(AV50GXV4+1);
         }
      }

      protected void S171( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S181( )
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
         AV18Date = DateTime.MinValue;
         AV19Date_To = DateTime.MinValue;
         AV44ProjectId = new GxSimpleCollection<long>();
         AV25Session = context.GetSession();
         AV33ColumnsSelectorXML = "";
         AV30ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV32ColumnsSelector_Column = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column(context);
         AV17SDTLeaveReportItem = new SdtSDTLeaveReport_PeriodCollectionItem(context);
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV34UserCustomValue = "";
         GXt_char1 = "";
         AV31ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV27GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV28GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         /* GeneXus formulas. */
      }

      private short AV20PeriodicCategory ;
      private short GXt_int2 ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV47GXV1 ;
      private int AV48GXV2 ;
      private int AV49GXV3 ;
      private int AV50GXV4 ;
      private long AV24EmployeeId ;
      private long AV46CompanyLocationId ;
      private long AV38VisibleColumnCount ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV18Date ;
      private DateTime AV19Date_To ;
      private bool returnInSub ;
      private string AV33ColumnsSelectorXML ;
      private string AV34UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private IGxSession AV25Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private SdtSDTLeaveReport AV29SDTLeaveReport ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<long> AV44ProjectId ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV30ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column AV32ColumnsSelector_Column ;
      private SdtSDTLeaveReport_PeriodCollectionItem AV17SDTLeaveReportItem ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV31ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV27GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private string aP1_Filename ;
      private string aP2_ErrorMessage ;
   }

}
