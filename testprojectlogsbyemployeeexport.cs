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
   public class testprojectlogsbyemployeeexport : GXProcedure
   {
      public testprojectlogsbyemployeeexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public testprojectlogsbyemployeeexport( IGxContext context )
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
         AV12Filename = GXt_char1 + "TestProjectLogsByEmployeeExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (DateTime.MinValue==AV35TFWorkHourLogDate) && (DateTime.MinValue==AV36TFWorkHourLogDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV35TFWorkHourLogDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV36TFWorkHourLogDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWorkHourLogDuration_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Duration") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWorkHourLogDuration_Sel)) ? "(Empty)" : AV38TFWorkHourLogDuration_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWorkHourLogDuration)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Duration") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV37TFWorkHourLogDuration, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFWorkHourLogDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Description") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFWorkHourLogDescription_Sel)) ? "(Empty)" : StringUtil.Substring( AV40TFWorkHourLogDescription_Sel, 1, 1000)), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFWorkHourLogDescription)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Description") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV39TFWorkHourLogDescription, 1, 1000), out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProjectName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProjectName_Sel)) ? "(Empty)" : AV42TFProjectName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProjectName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV41TFProjectName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("TestProjectLogsByEmployeeColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("TestProjectLogsByEmployeeColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV44GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV46Testprojectlogsbyemployeeds_1_filterfulltext = AV19FilterFullText;
         AV47Testprojectlogsbyemployeeds_2_tfworkhourlogdate = AV35TFWorkHourLogDate;
         AV48Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to = AV36TFWorkHourLogDate_To;
         AV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration = AV37TFWorkHourLogDuration;
         AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel = AV38TFWorkHourLogDuration_Sel;
         AV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = AV39TFWorkHourLogDescription;
         AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel = AV40TFWorkHourLogDescription_Sel;
         AV53Testprojectlogsbyemployeeds_8_tfprojectname = AV41TFProjectName;
         AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel = AV42TFProjectName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV46Testprojectlogsbyemployeeds_1_filterfulltext ,
                                              AV47Testprojectlogsbyemployeeds_2_tfworkhourlogdate ,
                                              AV48Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to ,
                                              AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel ,
                                              AV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration ,
                                              AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel ,
                                              AV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ,
                                              AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel ,
                                              AV53Testprojectlogsbyemployeeds_8_tfprojectname ,
                                              A120WorkHourLogDuration ,
                                              A123WorkHourLogDescription ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV46Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV46Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV46Testprojectlogsbyemployeeds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV46Testprojectlogsbyemployeeds_1_filterfulltext), "%", "");
         lV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration), "%", "");
         lV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription), "%", "");
         lV53Testprojectlogsbyemployeeds_8_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV53Testprojectlogsbyemployeeds_8_tfprojectname), 100, "%");
         /* Using cursor P00AH2 */
         pr_default.execute(0, new Object[] {lV46Testprojectlogsbyemployeeds_1_filterfulltext, lV46Testprojectlogsbyemployeeds_1_filterfulltext, lV46Testprojectlogsbyemployeeds_1_filterfulltext, AV47Testprojectlogsbyemployeeds_2_tfworkhourlogdate, AV48Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to, lV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration, AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, lV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription, AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, lV53Testprojectlogsbyemployeeds_8_tfprojectname, AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A102ProjectId = P00AH2_A102ProjectId[0];
            A119WorkHourLogDate = P00AH2_A119WorkHourLogDate[0];
            A103ProjectName = P00AH2_A103ProjectName[0];
            A123WorkHourLogDescription = P00AH2_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P00AH2_A120WorkHourLogDuration[0];
            A118WorkHourLogId = P00AH2_A118WorkHourLogId[0];
            A103ProjectName = P00AH2_A103ProjectName[0];
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
            AV55GXV2 = 1;
            while ( AV55GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV55GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "WorkHourLogDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A119WorkHourLogDate ) ;
                     AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "WorkHourLogDuration") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A120WorkHourLogDuration, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "WorkHourLogDescription") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  StringUtil.Substring( A123WorkHourLogDescription, 1, 1000), out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "ProjectName") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A103ProjectName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV55GXV2 = (int)(AV55GXV2+1);
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
         AV20Session.Set("WWPExportFileName", "TestProjectLogsByEmployeeExport.xlsx");
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
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WorkHourLogDate",  "",  "Log Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WorkHourLogDuration",  "",  "Log Duration",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WorkHourLogDescription",  "",  "Log Description",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ProjectName",  "",  "Name",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "TestProjectLogsByEmployeeColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("TestProjectLogsByEmployeeGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "TestProjectLogsByEmployeeGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("TestProjectLogsByEmployeeGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV56GXV3 = 1;
         while ( AV56GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV56GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV35TFWorkHourLogDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV36TFWorkHourLogDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV37TFWorkHourLogDuration = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV38TFWorkHourLogDuration_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV39TFWorkHourLogDescription = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV40TFWorkHourLogDescription_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV41TFProjectName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV42TFProjectName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV56GXV3 = (int)(AV56GXV3+1);
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
         AV35TFWorkHourLogDate = DateTime.MinValue;
         AV36TFWorkHourLogDate_To = DateTime.MinValue;
         AV38TFWorkHourLogDuration_Sel = "";
         AV37TFWorkHourLogDuration = "";
         AV40TFWorkHourLogDescription_Sel = "";
         AV39TFWorkHourLogDescription = "";
         AV42TFProjectName_Sel = "";
         AV41TFProjectName = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column(context);
         AV46Testprojectlogsbyemployeeds_1_filterfulltext = "";
         AV47Testprojectlogsbyemployeeds_2_tfworkhourlogdate = DateTime.MinValue;
         AV48Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to = DateTime.MinValue;
         AV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration = "";
         AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel = "";
         AV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = "";
         AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel = "";
         AV53Testprojectlogsbyemployeeds_8_tfprojectname = "";
         AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel = "";
         lV46Testprojectlogsbyemployeeds_1_filterfulltext = "";
         lV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration = "";
         lV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription = "";
         lV53Testprojectlogsbyemployeeds_8_tfprojectname = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A103ProjectName = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P00AH2_A102ProjectId = new long[1] ;
         P00AH2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00AH2_A103ProjectName = new string[] {""} ;
         P00AH2_A123WorkHourLogDescription = new string[] {""} ;
         P00AH2_A120WorkHourLogDuration = new string[] {""} ;
         P00AH2_A118WorkHourLogId = new long[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV22GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV23GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.testprojectlogsbyemployeeexport__default(),
            new Object[][] {
                new Object[] {
               P00AH2_A102ProjectId, P00AH2_A119WorkHourLogDate, P00AH2_A103ProjectName, P00AH2_A123WorkHourLogDescription, P00AH2_A120WorkHourLogDuration, P00AH2_A118WorkHourLogId
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
      private int AV44GXV1 ;
      private int AV55GXV2 ;
      private int AV56GXV3 ;
      private long AV32VisibleColumnCount ;
      private long A102ProjectId ;
      private long A118WorkHourLogId ;
      private string AV42TFProjectName_Sel ;
      private string AV41TFProjectName ;
      private string AV53Testprojectlogsbyemployeeds_8_tfprojectname ;
      private string AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel ;
      private string lV53Testprojectlogsbyemployeeds_8_tfprojectname ;
      private string A103ProjectName ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV35TFWorkHourLogDate ;
      private DateTime AV36TFWorkHourLogDate_To ;
      private DateTime AV47Testprojectlogsbyemployeeds_2_tfworkhourlogdate ;
      private DateTime AV48Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string A123WorkHourLogDescription ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV38TFWorkHourLogDuration_Sel ;
      private string AV37TFWorkHourLogDuration ;
      private string AV40TFWorkHourLogDescription_Sel ;
      private string AV39TFWorkHourLogDescription ;
      private string AV46Testprojectlogsbyemployeeds_1_filterfulltext ;
      private string AV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration ;
      private string AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel ;
      private string AV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ;
      private string AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel ;
      private string lV46Testprojectlogsbyemployeeds_1_filterfulltext ;
      private string lV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration ;
      private string lV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ;
      private string A120WorkHourLogDuration ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private long[] P00AH2_A102ProjectId ;
      private DateTime[] P00AH2_A119WorkHourLogDate ;
      private string[] P00AH2_A103ProjectName ;
      private string[] P00AH2_A123WorkHourLogDescription ;
      private string[] P00AH2_A120WorkHourLogDuration ;
      private long[] P00AH2_A118WorkHourLogId ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV22GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class testprojectlogsbyemployeeexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AH2( IGxContext context ,
                                             string AV46Testprojectlogsbyemployeeds_1_filterfulltext ,
                                             DateTime AV47Testprojectlogsbyemployeeds_2_tfworkhourlogdate ,
                                             DateTime AV48Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to ,
                                             string AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel ,
                                             string AV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration ,
                                             string AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel ,
                                             string AV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription ,
                                             string AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel ,
                                             string AV53Testprojectlogsbyemployeeds_8_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             string A123WorkHourLogDescription ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[11];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.ProjectId, T1.WorkHourLogDate, T2.ProjectName, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.WorkHourLogId FROM (WorkHourLog T1 INNER JOIN Project T2 ON T2.ProjectId = T1.ProjectId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Testprojectlogsbyemployeeds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV46Testprojectlogsbyemployeeds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV46Testprojectlogsbyemployeeds_1_filterfulltext) or ( T2.ProjectName like '%' || :lV46Testprojectlogsbyemployeeds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV47Testprojectlogsbyemployeeds_2_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV47Testprojectlogsbyemployeeds_2_tfworkhourlogdate)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV48Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV48Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Testprojectlogsbyemployeeds_8_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName like :lV53Testprojectlogsbyemployeeds_8_tfprojectname)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProjectName = ( :AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ProjectName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDate";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDate DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDuration";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDuration DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDescription";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDescription DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ProjectName";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ProjectName DESC";
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
                     return conditional_P00AH2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP00AH2;
          prmP00AH2 = new Object[] {
          new ParDef("lV46Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Testprojectlogsbyemployeeds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV47Testprojectlogsbyemployeeds_2_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV48Testprojectlogsbyemployeeds_3_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV49Testprojectlogsbyemployeeds_4_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV50Testprojectlogsbyemployeeds_5_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("lV51Testprojectlogsbyemployeeds_6_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV52Testprojectlogsbyemployeeds_7_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Testprojectlogsbyemployeeds_8_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV54Testprojectlogsbyemployeeds_9_tfprojectname_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AH2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AH2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}
