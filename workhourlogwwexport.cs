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
   public class workhourlogwwexport : GXProcedure
   {
      public workhourlogwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourlogwwexport( IGxContext context )
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
         AV12Filename = GXt_char1 + "WorkHourLogWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (DateTime.MinValue==AV74WorkHourLogDate) && (DateTime.MinValue==AV73WorkHourLogDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "") ;
            AV14CellRow = GXt_int2;
            AV58PrintFilterValue = false;
            if ( AV72WorkHourLogDateOperator == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Log Date";
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Past";
            }
            else if ( AV72WorkHourLogDateOperator == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Log Date";
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Today";
            }
            else if ( AV72WorkHourLogDateOperator == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Log Date";
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "This week";
            }
            else if ( AV72WorkHourLogDateOperator == 3 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Log Date";
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "This month";
            }
            else if ( AV72WorkHourLogDateOperator == 4 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Log Date", "Range", "", "", "", "", "", "", "");
               AV58PrintFilterValue = true;
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  " - ") ;
               AV14CellRow = GXt_int2;
            }
            if ( AV58PrintFilterValue )
            {
               GXt_dtime3 = DateTimeUtil.ResetTime( AV74WorkHourLogDate ) ;
               AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
               if ( AV58PrintFilterValue )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Italic = 1;
                  GXt_dtime3 = DateTimeUtil.ResetTime( AV73WorkHourLogDate_To ) ;
                  AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
               }
            }
         }
         if ( ! ( (DateTime.MinValue==AV37TFWorkHourLogDate) && (DateTime.MinValue==AV38TFWorkHourLogDate_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Date") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV37TFWorkHourLogDate ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV38TFWorkHourLogDate_To ) ;
            AV11ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFWorkHourLogDuration_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Duration") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFWorkHourLogDuration_Sel)) ? "(Empty)" : AV40TFWorkHourLogDuration_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFWorkHourLogDuration)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Duration") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV39TFWorkHourLogDuration, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV41TFWorkHourLogHour) && (0==AV42TFWorkHourLogHour_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Hour") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV41TFWorkHourLogHour;
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV42TFWorkHourLogHour_To;
         }
         if ( ! ( (0==AV43TFWorkHourLogMinute) && (0==AV44TFWorkHourLogMinute_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Minute") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = AV43TFWorkHourLogMinute;
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = AV44TFWorkHourLogMinute_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFWorkHourLogDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Description") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV46TFWorkHourLogDescription_Sel)) ? "(Empty)" : StringUtil.Substring( AV46TFWorkHourLogDescription_Sel, 1, 1000)), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFWorkHourLogDescription)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Description") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  StringUtil.Substring( AV45TFWorkHourLogDescription, 1, 1000), out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFEmployeeFirstName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "First Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV55TFEmployeeFirstName_Sel)) ? "(Empty)" : AV55TFEmployeeFirstName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV54TFEmployeeFirstName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "First Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV54TFEmployeeFirstName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProjectName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFProjectName_Sel)) ? "(Empty)" : AV52TFProjectName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFProjectName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV51TFProjectName, out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("WorkHourLogWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("WorkHourLogWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV75GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV75GXV1 = (int)(AV75GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV77Workhourlogwwds_1_filterfulltext = AV19FilterFullText;
         AV78Workhourlogwwds_2_workhourlogdate = AV74WorkHourLogDate;
         AV79Workhourlogwwds_3_workhourlogdate_to = AV73WorkHourLogDate_To;
         AV80Workhourlogwwds_4_tfworkhourlogdate = AV37TFWorkHourLogDate;
         AV81Workhourlogwwds_5_tfworkhourlogdate_to = AV38TFWorkHourLogDate_To;
         AV82Workhourlogwwds_6_tfworkhourlogduration = AV39TFWorkHourLogDuration;
         AV83Workhourlogwwds_7_tfworkhourlogduration_sel = AV40TFWorkHourLogDuration_Sel;
         AV84Workhourlogwwds_8_tfworkhourloghour = AV41TFWorkHourLogHour;
         AV85Workhourlogwwds_9_tfworkhourloghour_to = AV42TFWorkHourLogHour_To;
         AV86Workhourlogwwds_10_tfworkhourlogminute = AV43TFWorkHourLogMinute;
         AV87Workhourlogwwds_11_tfworkhourlogminute_to = AV44TFWorkHourLogMinute_To;
         AV88Workhourlogwwds_12_tfworkhourlogdescription = AV45TFWorkHourLogDescription;
         AV89Workhourlogwwds_13_tfworkhourlogdescription_sel = AV46TFWorkHourLogDescription_Sel;
         AV90Workhourlogwwds_14_tfemployeefirstname = AV54TFEmployeeFirstName;
         AV91Workhourlogwwds_15_tfemployeefirstname_sel = AV55TFEmployeeFirstName_Sel;
         AV92Workhourlogwwds_16_tfprojectname = AV51TFProjectName;
         AV93Workhourlogwwds_17_tfprojectname_sel = AV52TFProjectName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV77Workhourlogwwds_1_filterfulltext ,
                                              AV72WorkHourLogDateOperator ,
                                              AV78Workhourlogwwds_2_workhourlogdate ,
                                              AV79Workhourlogwwds_3_workhourlogdate_to ,
                                              AV80Workhourlogwwds_4_tfworkhourlogdate ,
                                              AV81Workhourlogwwds_5_tfworkhourlogdate_to ,
                                              AV83Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                              AV82Workhourlogwwds_6_tfworkhourlogduration ,
                                              AV84Workhourlogwwds_8_tfworkhourloghour ,
                                              AV85Workhourlogwwds_9_tfworkhourloghour_to ,
                                              AV86Workhourlogwwds_10_tfworkhourlogminute ,
                                              AV87Workhourlogwwds_11_tfworkhourlogminute_to ,
                                              AV89Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                              AV88Workhourlogwwds_12_tfworkhourlogdescription ,
                                              AV91Workhourlogwwds_15_tfemployeefirstname_sel ,
                                              AV90Workhourlogwwds_14_tfemployeefirstname ,
                                              AV93Workhourlogwwds_17_tfprojectname_sel ,
                                              AV92Workhourlogwwds_16_tfprojectname ,
                                              A120WorkHourLogDuration ,
                                              A121WorkHourLogHour ,
                                              A122WorkHourLogMinute ,
                                              A123WorkHourLogDescription ,
                                              A107EmployeeFirstName ,
                                              A103ProjectName ,
                                              A119WorkHourLogDate ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV77Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Workhourlogwwds_1_filterfulltext), "%", "");
         lV77Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Workhourlogwwds_1_filterfulltext), "%", "");
         lV77Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Workhourlogwwds_1_filterfulltext), "%", "");
         lV77Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Workhourlogwwds_1_filterfulltext), "%", "");
         lV77Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Workhourlogwwds_1_filterfulltext), "%", "");
         lV77Workhourlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Workhourlogwwds_1_filterfulltext), "%", "");
         lV82Workhourlogwwds_6_tfworkhourlogduration = StringUtil.Concat( StringUtil.RTrim( AV82Workhourlogwwds_6_tfworkhourlogduration), "%", "");
         lV88Workhourlogwwds_12_tfworkhourlogdescription = StringUtil.Concat( StringUtil.RTrim( AV88Workhourlogwwds_12_tfworkhourlogdescription), "%", "");
         lV90Workhourlogwwds_14_tfemployeefirstname = StringUtil.PadR( StringUtil.RTrim( AV90Workhourlogwwds_14_tfemployeefirstname), 100, "%");
         lV92Workhourlogwwds_16_tfprojectname = StringUtil.PadR( StringUtil.RTrim( AV92Workhourlogwwds_16_tfprojectname), 100, "%");
         /* Using cursor P006O2 */
         pr_default.execute(0, new Object[] {lV77Workhourlogwwds_1_filterfulltext, lV77Workhourlogwwds_1_filterfulltext, lV77Workhourlogwwds_1_filterfulltext, lV77Workhourlogwwds_1_filterfulltext, lV77Workhourlogwwds_1_filterfulltext, lV77Workhourlogwwds_1_filterfulltext, AV78Workhourlogwwds_2_workhourlogdate, AV78Workhourlogwwds_2_workhourlogdate, AV78Workhourlogwwds_2_workhourlogdate, AV79Workhourlogwwds_3_workhourlogdate_to, AV78Workhourlogwwds_2_workhourlogdate, AV80Workhourlogwwds_4_tfworkhourlogdate, AV81Workhourlogwwds_5_tfworkhourlogdate_to, lV82Workhourlogwwds_6_tfworkhourlogduration, AV83Workhourlogwwds_7_tfworkhourlogduration_sel, AV84Workhourlogwwds_8_tfworkhourloghour, AV85Workhourlogwwds_9_tfworkhourloghour_to, AV86Workhourlogwwds_10_tfworkhourlogminute, AV87Workhourlogwwds_11_tfworkhourlogminute_to, lV88Workhourlogwwds_12_tfworkhourlogdescription, AV89Workhourlogwwds_13_tfworkhourlogdescription_sel, lV90Workhourlogwwds_14_tfemployeefirstname, AV91Workhourlogwwds_15_tfemployeefirstname_sel, lV92Workhourlogwwds_16_tfprojectname, AV93Workhourlogwwds_17_tfprojectname_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P006O2_A106EmployeeId[0];
            A102ProjectId = P006O2_A102ProjectId[0];
            A122WorkHourLogMinute = P006O2_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P006O2_A121WorkHourLogHour[0];
            A119WorkHourLogDate = P006O2_A119WorkHourLogDate[0];
            A103ProjectName = P006O2_A103ProjectName[0];
            A107EmployeeFirstName = P006O2_A107EmployeeFirstName[0];
            A123WorkHourLogDescription = P006O2_A123WorkHourLogDescription[0];
            A120WorkHourLogDuration = P006O2_A120WorkHourLogDuration[0];
            A118WorkHourLogId = P006O2_A118WorkHourLogId[0];
            A107EmployeeFirstName = P006O2_A107EmployeeFirstName[0];
            A103ProjectName = P006O2_A103ProjectName[0];
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
            AV94GXV2 = 1;
            while ( AV94GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV94GXV2));
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
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "WorkHourLogHour") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A121WorkHourLogHour;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "WorkHourLogMinute") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = A122WorkHourLogMinute;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "WorkHourLogDescription") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  StringUtil.Substring( A123WorkHourLogDescription, 1, 1000), out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeFirstName") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A107EmployeeFirstName, out  GXt_char1) ;
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
               AV94GXV2 = (int)(AV94GXV2+1);
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
         AV20Session.Set("WWPExportFileName", "WorkHourLogWWExport.xlsx");
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
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WorkHourLogHour",  "",  "Log Hour",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WorkHourLogMinute",  "",  "Log Minute",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WorkHourLogDescription",  "",  "Log Description",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeFirstName",  "",  "First Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "ProjectName",  "",  "Name",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WorkHourLogWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("WorkHourLogWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "WorkHourLogWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("WorkHourLogWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV95GXV3 = 1;
         while ( AV95GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV95GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "WORKHOURLOGDATE") == 0 )
            {
               AV74WorkHourLogDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV72WorkHourLogDateOperator = AV23GridStateFilterValue.gxTpr_Operator;
               AV73WorkHourLogDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDATE") == 0 )
            {
               AV37TFWorkHourLogDate = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Value, 2);
               AV38TFWorkHourLogDate_To = context.localUtil.CToD( AV23GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION") == 0 )
            {
               AV39TFWorkHourLogDuration = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDURATION_SEL") == 0 )
            {
               AV40TFWorkHourLogDuration_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGHOUR") == 0 )
            {
               AV41TFWorkHourLogHour = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV42TFWorkHourLogHour_To = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGMINUTE") == 0 )
            {
               AV43TFWorkHourLogMinute = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV44TFWorkHourLogMinute_To = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION") == 0 )
            {
               AV45TFWorkHourLogDescription = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFWORKHOURLOGDESCRIPTION_SEL") == 0 )
            {
               AV46TFWorkHourLogDescription_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME") == 0 )
            {
               AV54TFEmployeeFirstName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEFIRSTNAME_SEL") == 0 )
            {
               AV55TFEmployeeFirstName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME") == 0 )
            {
               AV51TFProjectName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFPROJECTNAME_SEL") == 0 )
            {
               AV52TFProjectName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            AV95GXV3 = (int)(AV95GXV3+1);
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
         AV74WorkHourLogDate = DateTime.MinValue;
         AV73WorkHourLogDate_To = DateTime.MinValue;
         AV37TFWorkHourLogDate = DateTime.MinValue;
         AV38TFWorkHourLogDate_To = DateTime.MinValue;
         AV40TFWorkHourLogDuration_Sel = "";
         AV39TFWorkHourLogDuration = "";
         AV46TFWorkHourLogDescription_Sel = "";
         AV45TFWorkHourLogDescription = "";
         AV55TFEmployeeFirstName_Sel = "";
         AV54TFEmployeeFirstName = "";
         AV52TFProjectName_Sel = "";
         AV51TFProjectName = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column(context);
         AV77Workhourlogwwds_1_filterfulltext = "";
         AV78Workhourlogwwds_2_workhourlogdate = DateTime.MinValue;
         AV79Workhourlogwwds_3_workhourlogdate_to = DateTime.MinValue;
         AV80Workhourlogwwds_4_tfworkhourlogdate = DateTime.MinValue;
         AV81Workhourlogwwds_5_tfworkhourlogdate_to = DateTime.MinValue;
         AV82Workhourlogwwds_6_tfworkhourlogduration = "";
         AV83Workhourlogwwds_7_tfworkhourlogduration_sel = "";
         AV88Workhourlogwwds_12_tfworkhourlogdescription = "";
         AV89Workhourlogwwds_13_tfworkhourlogdescription_sel = "";
         AV90Workhourlogwwds_14_tfemployeefirstname = "";
         AV91Workhourlogwwds_15_tfemployeefirstname_sel = "";
         AV92Workhourlogwwds_16_tfprojectname = "";
         AV93Workhourlogwwds_17_tfprojectname_sel = "";
         lV77Workhourlogwwds_1_filterfulltext = "";
         lV82Workhourlogwwds_6_tfworkhourlogduration = "";
         lV88Workhourlogwwds_12_tfworkhourlogdescription = "";
         lV90Workhourlogwwds_14_tfemployeefirstname = "";
         lV92Workhourlogwwds_16_tfprojectname = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A107EmployeeFirstName = "";
         A103ProjectName = "";
         A119WorkHourLogDate = DateTime.MinValue;
         P006O2_A106EmployeeId = new long[1] ;
         P006O2_A102ProjectId = new long[1] ;
         P006O2_A122WorkHourLogMinute = new short[1] ;
         P006O2_A121WorkHourLogHour = new short[1] ;
         P006O2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P006O2_A103ProjectName = new string[] {""} ;
         P006O2_A107EmployeeFirstName = new string[] {""} ;
         P006O2_A123WorkHourLogDescription = new string[] {""} ;
         P006O2_A120WorkHourLogDuration = new string[] {""} ;
         P006O2_A118WorkHourLogId = new long[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV22GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV23GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourlogwwexport__default(),
            new Object[][] {
                new Object[] {
               P006O2_A106EmployeeId, P006O2_A102ProjectId, P006O2_A122WorkHourLogMinute, P006O2_A121WorkHourLogHour, P006O2_A119WorkHourLogDate, P006O2_A103ProjectName, P006O2_A107EmployeeFirstName, P006O2_A123WorkHourLogDescription, P006O2_A120WorkHourLogDuration, P006O2_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV72WorkHourLogDateOperator ;
      private short AV41TFWorkHourLogHour ;
      private short AV42TFWorkHourLogHour_To ;
      private short AV43TFWorkHourLogMinute ;
      private short AV44TFWorkHourLogMinute_To ;
      private short GXt_int2 ;
      private short AV84Workhourlogwwds_8_tfworkhourloghour ;
      private short AV85Workhourlogwwds_9_tfworkhourloghour_to ;
      private short AV86Workhourlogwwds_10_tfworkhourlogminute ;
      private short AV87Workhourlogwwds_11_tfworkhourlogminute_to ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV75GXV1 ;
      private int AV94GXV2 ;
      private int AV95GXV3 ;
      private long AV32VisibleColumnCount ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A118WorkHourLogId ;
      private string AV55TFEmployeeFirstName_Sel ;
      private string AV54TFEmployeeFirstName ;
      private string AV52TFProjectName_Sel ;
      private string AV51TFProjectName ;
      private string AV90Workhourlogwwds_14_tfemployeefirstname ;
      private string AV91Workhourlogwwds_15_tfemployeefirstname_sel ;
      private string AV92Workhourlogwwds_16_tfprojectname ;
      private string AV93Workhourlogwwds_17_tfprojectname_sel ;
      private string lV90Workhourlogwwds_14_tfemployeefirstname ;
      private string lV92Workhourlogwwds_16_tfprojectname ;
      private string A107EmployeeFirstName ;
      private string A103ProjectName ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV74WorkHourLogDate ;
      private DateTime AV73WorkHourLogDate_To ;
      private DateTime AV37TFWorkHourLogDate ;
      private DateTime AV38TFWorkHourLogDate_To ;
      private DateTime AV78Workhourlogwwds_2_workhourlogdate ;
      private DateTime AV79Workhourlogwwds_3_workhourlogdate_to ;
      private DateTime AV80Workhourlogwwds_4_tfworkhourlogdate ;
      private DateTime AV81Workhourlogwwds_5_tfworkhourlogdate_to ;
      private DateTime A119WorkHourLogDate ;
      private bool returnInSub ;
      private bool AV58PrintFilterValue ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string A123WorkHourLogDescription ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV40TFWorkHourLogDuration_Sel ;
      private string AV39TFWorkHourLogDuration ;
      private string AV46TFWorkHourLogDescription_Sel ;
      private string AV45TFWorkHourLogDescription ;
      private string AV77Workhourlogwwds_1_filterfulltext ;
      private string AV82Workhourlogwwds_6_tfworkhourlogduration ;
      private string AV83Workhourlogwwds_7_tfworkhourlogduration_sel ;
      private string AV88Workhourlogwwds_12_tfworkhourlogdescription ;
      private string AV89Workhourlogwwds_13_tfworkhourlogdescription_sel ;
      private string lV77Workhourlogwwds_1_filterfulltext ;
      private string lV82Workhourlogwwds_6_tfworkhourlogduration ;
      private string lV88Workhourlogwwds_12_tfworkhourlogdescription ;
      private string A120WorkHourLogDuration ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private long[] P006O2_A106EmployeeId ;
      private long[] P006O2_A102ProjectId ;
      private short[] P006O2_A122WorkHourLogMinute ;
      private short[] P006O2_A121WorkHourLogHour ;
      private DateTime[] P006O2_A119WorkHourLogDate ;
      private string[] P006O2_A103ProjectName ;
      private string[] P006O2_A107EmployeeFirstName ;
      private string[] P006O2_A123WorkHourLogDescription ;
      private string[] P006O2_A120WorkHourLogDuration ;
      private long[] P006O2_A118WorkHourLogId ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV22GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class workhourlogwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006O2( IGxContext context ,
                                             string AV77Workhourlogwwds_1_filterfulltext ,
                                             short AV72WorkHourLogDateOperator ,
                                             DateTime AV78Workhourlogwwds_2_workhourlogdate ,
                                             DateTime AV79Workhourlogwwds_3_workhourlogdate_to ,
                                             DateTime AV80Workhourlogwwds_4_tfworkhourlogdate ,
                                             DateTime AV81Workhourlogwwds_5_tfworkhourlogdate_to ,
                                             string AV83Workhourlogwwds_7_tfworkhourlogduration_sel ,
                                             string AV82Workhourlogwwds_6_tfworkhourlogduration ,
                                             short AV84Workhourlogwwds_8_tfworkhourloghour ,
                                             short AV85Workhourlogwwds_9_tfworkhourloghour_to ,
                                             short AV86Workhourlogwwds_10_tfworkhourlogminute ,
                                             short AV87Workhourlogwwds_11_tfworkhourlogminute_to ,
                                             string AV89Workhourlogwwds_13_tfworkhourlogdescription_sel ,
                                             string AV88Workhourlogwwds_12_tfworkhourlogdescription ,
                                             string AV91Workhourlogwwds_15_tfemployeefirstname_sel ,
                                             string AV90Workhourlogwwds_14_tfemployeefirstname ,
                                             string AV93Workhourlogwwds_17_tfprojectname_sel ,
                                             string AV92Workhourlogwwds_16_tfprojectname ,
                                             string A120WorkHourLogDuration ,
                                             short A121WorkHourLogHour ,
                                             short A122WorkHourLogMinute ,
                                             string A123WorkHourLogDescription ,
                                             string A107EmployeeFirstName ,
                                             string A103ProjectName ,
                                             DateTime A119WorkHourLogDate ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[25];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.EmployeeId, T1.ProjectId, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogDate, T3.ProjectName, T2.EmployeeFirstName, T1.WorkHourLogDescription, T1.WorkHourLogDuration, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Project T3 ON T3.ProjectId = T1.ProjectId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Workhourlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.WorkHourLogDuration like '%' || :lV77Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogHour,'9999'), 2) like '%' || :lV77Workhourlogwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.WorkHourLogMinute,'9999'), 2) like '%' || :lV77Workhourlogwwds_1_filterfulltext) or ( T1.WorkHourLogDescription like '%' || :lV77Workhourlogwwds_1_filterfulltext) or ( T2.EmployeeFirstName like '%' || :lV77Workhourlogwwds_1_filterfulltext) or ( T3.ProjectName like '%' || :lV77Workhourlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
         }
         if ( ( AV72WorkHourLogDateOperator == 0 ) && ( ! (DateTime.MinValue==AV78Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate < :AV78Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ( AV72WorkHourLogDateOperator == 1 ) && ( ! (DateTime.MinValue==AV78Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate = :AV78Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ( ( AV72WorkHourLogDateOperator == 2 ) || ( AV72WorkHourLogDateOperator == 3 ) ) && ( ! (DateTime.MinValue==AV78Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate > :AV78Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( ( AV72WorkHourLogDateOperator == 2 ) || ( AV72WorkHourLogDateOperator == 3 ) || ( AV72WorkHourLogDateOperator == 4 ) ) && ( ! (DateTime.MinValue==AV79Workhourlogwwds_3_workhourlogdate_to) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV79Workhourlogwwds_3_workhourlogdate_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ( AV72WorkHourLogDateOperator == 4 ) && ( ! (DateTime.MinValue==AV78Workhourlogwwds_2_workhourlogdate) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV78Workhourlogwwds_2_workhourlogdate)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Workhourlogwwds_4_tfworkhourlogdate) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV80Workhourlogwwds_4_tfworkhourlogdate)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Workhourlogwwds_5_tfworkhourlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV81Workhourlogwwds_5_tfworkhourlogdate_to)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Workhourlogwwds_7_tfworkhourlogduration_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Workhourlogwwds_6_tfworkhourlogduration)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration like :lV82Workhourlogwwds_6_tfworkhourlogduration)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Workhourlogwwds_7_tfworkhourlogduration_sel)) && ! ( StringUtil.StrCmp(AV83Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDuration = ( :AV83Workhourlogwwds_7_tfworkhourlogduration_sel))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( StringUtil.StrCmp(AV83Workhourlogwwds_7_tfworkhourlogduration_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDuration))=0))");
         }
         if ( ! (0==AV84Workhourlogwwds_8_tfworkhourloghour) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour >= :AV84Workhourlogwwds_8_tfworkhourloghour)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (0==AV85Workhourlogwwds_9_tfworkhourloghour_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogHour <= :AV85Workhourlogwwds_9_tfworkhourloghour_to)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (0==AV86Workhourlogwwds_10_tfworkhourlogminute) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute >= :AV86Workhourlogwwds_10_tfworkhourlogminute)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (0==AV87Workhourlogwwds_11_tfworkhourlogminute_to) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogMinute <= :AV87Workhourlogwwds_11_tfworkhourlogminute_to)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Workhourlogwwds_12_tfworkhourlogdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription like :lV88Workhourlogwwds_12_tfworkhourlogdescription)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Workhourlogwwds_13_tfworkhourlogdescription_sel)) && ! ( StringUtil.StrCmp(AV89Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.WorkHourLogDescription = ( :AV89Workhourlogwwds_13_tfworkhourlogdescription_sel))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV89Workhourlogwwds_13_tfworkhourlogdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WorkHourLogDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Workhourlogwwds_15_tfemployeefirstname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Workhourlogwwds_14_tfemployeefirstname)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName like :lV90Workhourlogwwds_14_tfemployeefirstname)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Workhourlogwwds_15_tfemployeefirstname_sel)) && ! ( StringUtil.StrCmp(AV91Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeFirstName = ( :AV91Workhourlogwwds_15_tfemployeefirstname_sel))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( StringUtil.StrCmp(AV91Workhourlogwwds_15_tfemployeefirstname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeFirstName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Workhourlogwwds_17_tfprojectname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Workhourlogwwds_16_tfprojectname)) ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName like :lV92Workhourlogwwds_16_tfprojectname)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Workhourlogwwds_17_tfprojectname_sel)) && ! ( StringUtil.StrCmp(AV93Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProjectName = ( :AV93Workhourlogwwds_17_tfprojectname_sel))");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( StringUtil.StrCmp(AV93Workhourlogwwds_17_tfprojectname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.ProjectName))=0))");
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
            scmdbuf += " ORDER BY T1.WorkHourLogHour";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogHour DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogMinute";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogMinute DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDescription";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.WorkHourLogDescription DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.EmployeeFirstName";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.EmployeeFirstName DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ProjectName";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ProjectName DESC";
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
                     return conditional_P006O2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] );
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
          Object[] prmP006O2;
          prmP006O2 = new Object[] {
          new ParDef("lV77Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Workhourlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV78Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV78Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV78Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV79Workhourlogwwds_3_workhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("AV78Workhourlogwwds_2_workhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV80Workhourlogwwds_4_tfworkhourlogdate",GXType.Date,8,0) ,
          new ParDef("AV81Workhourlogwwds_5_tfworkhourlogdate_to",GXType.Date,8,0) ,
          new ParDef("lV82Workhourlogwwds_6_tfworkhourlogduration",GXType.VarChar,40,3) ,
          new ParDef("AV83Workhourlogwwds_7_tfworkhourlogduration_sel",GXType.VarChar,40,3) ,
          new ParDef("AV84Workhourlogwwds_8_tfworkhourloghour",GXType.Int16,4,0) ,
          new ParDef("AV85Workhourlogwwds_9_tfworkhourloghour_to",GXType.Int16,4,0) ,
          new ParDef("AV86Workhourlogwwds_10_tfworkhourlogminute",GXType.Int16,4,0) ,
          new ParDef("AV87Workhourlogwwds_11_tfworkhourlogminute_to",GXType.Int16,4,0) ,
          new ParDef("lV88Workhourlogwwds_12_tfworkhourlogdescription",GXType.VarChar,200,0) ,
          new ParDef("AV89Workhourlogwwds_13_tfworkhourlogdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV90Workhourlogwwds_14_tfemployeefirstname",GXType.Char,100,0) ,
          new ParDef("AV91Workhourlogwwds_15_tfemployeefirstname_sel",GXType.Char,100,0) ,
          new ParDef("lV92Workhourlogwwds_16_tfprojectname",GXType.Char,100,0) ,
          new ParDef("AV93Workhourlogwwds_17_tfprojectname_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
