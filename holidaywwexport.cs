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
   public class holidaywwexport : GXProcedure
   {
      public holidaywwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public holidaywwexport( IGxContext context )
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
         AV12Filename = GXt_char1 + "HolidayWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFHolidayName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "National Holiday Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFHolidayName_Sel)) ? "(Empty)" : AV38TFHolidayName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFHolidayName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "National Holiday Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV37TFHolidayName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV39TFHolidayStartDate) && (DateTime.MinValue==AV40TFHolidayStartDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV39TFHolidayStartDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV40TFHolidayStartDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( (0==AV51TFHolidayIsActive_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Is Active") ;
            AV14CellRow = GXt_int2;
            if ( AV51TFHolidayIsActive_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Checked";
            }
            else if ( AV51TFHolidayIsActive_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Unchecked";
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("HolidayWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("HolidayWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV54GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV56Holidaywwds_1_filterfulltext = AV19FilterFullText;
         AV57Holidaywwds_2_tfholidayname = AV37TFHolidayName;
         AV58Holidaywwds_3_tfholidayname_sel = AV38TFHolidayName_Sel;
         AV59Holidaywwds_4_tfholidaystartdate = AV39TFHolidayStartDate;
         AV60Holidaywwds_5_tfholidaystartdate_to = AV40TFHolidayStartDate_To;
         AV61Holidaywwds_6_tfholidayisactive_sel = AV51TFHolidayIsActive_Sel;
         AV63Udparg7 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV56Holidaywwds_1_filterfulltext ,
                                              AV58Holidaywwds_3_tfholidayname_sel ,
                                              AV57Holidaywwds_2_tfholidayname ,
                                              AV59Holidaywwds_4_tfholidaystartdate ,
                                              AV60Holidaywwds_5_tfholidaystartdate_to ,
                                              AV61Holidaywwds_6_tfholidayisactive_sel ,
                                              A114HolidayName ,
                                              A115HolidayStartDate ,
                                              A139HolidayIsActive ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              Gx_date ,
                                              AV63Udparg7 ,
                                              A100CompanyId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV56Holidaywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Holidaywwds_1_filterfulltext), "%", "");
         lV57Holidaywwds_2_tfholidayname = StringUtil.PadR( StringUtil.RTrim( AV57Holidaywwds_2_tfholidayname), 100, "%");
         /* Using cursor P00582 */
         pr_default.execute(0, new Object[] {AV63Udparg7, Gx_date, Gx_date, lV56Holidaywwds_1_filterfulltext, lV57Holidaywwds_2_tfholidayname, AV58Holidaywwds_3_tfholidayname_sel, AV59Holidaywwds_4_tfholidaystartdate, AV60Holidaywwds_5_tfholidaystartdate_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00582_A100CompanyId[0];
            A139HolidayIsActive = P00582_A139HolidayIsActive[0];
            A115HolidayStartDate = P00582_A115HolidayStartDate[0];
            A114HolidayName = P00582_A114HolidayName[0];
            A113HolidayId = P00582_A113HolidayId[0];
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
            AV64GXV2 = 1;
            while ( AV64GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV64GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "HolidayName") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A114HolidayName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "HolidayStartDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A115HolidayStartDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "HolidayIsActive") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A139HolidayIsActive);
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV64GXV2 = (int)(AV64GXV2+1);
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
         AV20Session.Set("WWPExportFileName", "HolidayWWExport.xlsx");
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
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "HolidayName",  "",  "National Holiday Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "HolidayStartDate",  "",  "Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "HolidayIsActive",  "",  "Is Active",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "HolidayWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("HolidayWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "HolidayWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("HolidayWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV65GXV3 = 1;
         while ( AV65GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV65GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFHOLIDAYNAME") == 0 )
            {
               AV37TFHolidayName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFHOLIDAYNAME_SEL") == 0 )
            {
               AV38TFHolidayName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFHOLIDAYSTARTDATE") == 0 )
            {
               AV39TFHolidayStartDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV40TFHolidayStartDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFHOLIDAYISACTIVE_SEL") == 0 )
            {
               AV51TFHolidayIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV65GXV3 = (int)(AV65GXV3+1);
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
         AV38TFHolidayName_Sel = "";
         AV37TFHolidayName = "";
         AV39TFHolidayStartDate = DateTime.MinValue;
         AV40TFHolidayStartDate_To = DateTime.MinValue;
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column(context);
         AV56Holidaywwds_1_filterfulltext = "";
         AV57Holidaywwds_2_tfholidayname = "";
         AV58Holidaywwds_3_tfholidayname_sel = "";
         AV59Holidaywwds_4_tfholidaystartdate = DateTime.MinValue;
         AV60Holidaywwds_5_tfholidaystartdate_to = DateTime.MinValue;
         lV56Holidaywwds_1_filterfulltext = "";
         lV57Holidaywwds_2_tfholidayname = "";
         A114HolidayName = "";
         A115HolidayStartDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         P00582_A100CompanyId = new long[1] ;
         P00582_A139HolidayIsActive = new bool[] {false} ;
         P00582_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P00582_A114HolidayName = new string[] {""} ;
         P00582_A113HolidayId = new long[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV22GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV23GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.holidaywwexport__default(),
            new Object[][] {
                new Object[] {
               P00582_A100CompanyId, P00582_A139HolidayIsActive, P00582_A115HolidayStartDate, P00582_A114HolidayName, P00582_A113HolidayId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV51TFHolidayIsActive_Sel ;
      private short GXt_int2 ;
      private short AV61Holidaywwds_6_tfholidayisactive_sel ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV54GXV1 ;
      private int AV64GXV2 ;
      private int AV65GXV3 ;
      private long AV32VisibleColumnCount ;
      private long AV63Udparg7 ;
      private long A100CompanyId ;
      private long A113HolidayId ;
      private string AV38TFHolidayName_Sel ;
      private string AV37TFHolidayName ;
      private string AV57Holidaywwds_2_tfholidayname ;
      private string AV58Holidaywwds_3_tfholidayname_sel ;
      private string lV57Holidaywwds_2_tfholidayname ;
      private string A114HolidayName ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV39TFHolidayStartDate ;
      private DateTime AV40TFHolidayStartDate_To ;
      private DateTime AV59Holidaywwds_4_tfholidaystartdate ;
      private DateTime AV60Holidaywwds_5_tfholidaystartdate_to ;
      private DateTime A115HolidayStartDate ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool A139HolidayIsActive ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV56Holidaywwds_1_filterfulltext ;
      private string lV56Holidaywwds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private long[] P00582_A100CompanyId ;
      private bool[] P00582_A139HolidayIsActive ;
      private DateTime[] P00582_A115HolidayStartDate ;
      private string[] P00582_A114HolidayName ;
      private long[] P00582_A113HolidayId ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV22GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class holidaywwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00582( IGxContext context ,
                                             string AV56Holidaywwds_1_filterfulltext ,
                                             string AV58Holidaywwds_3_tfholidayname_sel ,
                                             string AV57Holidaywwds_2_tfholidayname ,
                                             DateTime AV59Holidaywwds_4_tfholidaystartdate ,
                                             DateTime AV60Holidaywwds_5_tfholidaystartdate_to ,
                                             short AV61Holidaywwds_6_tfholidayisactive_sel ,
                                             string A114HolidayName ,
                                             DateTime A115HolidayStartDate ,
                                             bool A139HolidayIsActive ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             DateTime Gx_date ,
                                             long AV63Udparg7 ,
                                             long A100CompanyId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[8];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT CompanyId, HolidayIsActive, HolidayStartDate, HolidayName, HolidayId FROM Holiday";
         AddWhere(sWhereString, "(CompanyId = :AV63Udparg7)");
         AddWhere(sWhereString, "(date_part('year', HolidayStartDate) = date_part('year', :Gx_date) or date_part('year', HolidayStartDate) = date_part('year', (CAST(:Gx_date AS date) + CAST (1 || ' YEAR' AS INTERVAL))))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Holidaywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( HolidayName like '%' || :lV56Holidaywwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Holidaywwds_3_tfholidayname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Holidaywwds_2_tfholidayname)) ) )
         {
            AddWhere(sWhereString, "(HolidayName like :lV57Holidaywwds_2_tfholidayname)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Holidaywwds_3_tfholidayname_sel)) && ! ( StringUtil.StrCmp(AV58Holidaywwds_3_tfholidayname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(HolidayName = ( :AV58Holidaywwds_3_tfholidayname_sel))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV58Holidaywwds_3_tfholidayname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from HolidayName))=0))");
         }
         if ( ! (DateTime.MinValue==AV59Holidaywwds_4_tfholidaystartdate) )
         {
            AddWhere(sWhereString, "(HolidayStartDate >= :AV59Holidaywwds_4_tfholidaystartdate)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Holidaywwds_5_tfholidaystartdate_to) )
         {
            AddWhere(sWhereString, "(HolidayStartDate <= :AV60Holidaywwds_5_tfholidaystartdate_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV61Holidaywwds_6_tfholidayisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(HolidayIsActive = TRUE)");
         }
         if ( AV61Holidaywwds_6_tfholidayisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(HolidayIsActive = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY HolidayStartDate";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY HolidayStartDate DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY HolidayName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY HolidayName DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY HolidayIsActive";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY HolidayIsActive DESC";
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
                     return conditional_P00582(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (bool)dynConstraints[10] , (DateTime)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] );
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
          Object[] prmP00582;
          prmP00582 = new Object[] {
          new ParDef("AV63Udparg7",GXType.Int64,10,0) ,
          new ParDef("Gx_date",GXType.Date,8,0) ,
          new ParDef("Gx_date",GXType.Date,8,0) ,
          new ParDef("lV56Holidaywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Holidaywwds_2_tfholidayname",GXType.Char,100,0) ,
          new ParDef("AV58Holidaywwds_3_tfholidayname_sel",GXType.Char,100,0) ,
          new ParDef("AV59Holidaywwds_4_tfholidaystartdate",GXType.Date,8,0) ,
          new ParDef("AV60Holidaywwds_5_tfholidaystartdate_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00582", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00582,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
