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
   public class leavetypewwexport : GXProcedure
   {
      public leavetypewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public leavetypewwexport( IGxContext context )
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
         AV12Filename = GXt_char1 + "LeaveTypeWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( ( AV44TFLeaveTypeVacationLeave_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Deduct from vacation days ") ;
            AV14CellRow = GXt_int2;
            AV41i = 1;
            AV52GXV1 = 1;
            while ( AV52GXV1 <= AV44TFLeaveTypeVacationLeave_Sels.Count )
            {
               AV43TFLeaveTypeVacationLeave_Sel = AV44TFLeaveTypeVacationLeave_Sels.GetString(AV52GXV1);
               if ( AV41i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV43TFLeaveTypeVacationLeave_Sel), "No") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"No";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV43TFLeaveTypeVacationLeave_Sel), "Yes") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"Yes";
               }
               AV41i = (long)(AV41i+1);
               AV52GXV1 = (int)(AV52GXV1+1);
            }
         }
         if ( ! ( ( AV47TFLeaveTypeLoggingWorkHours_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Log Work Hours") ;
            AV14CellRow = GXt_int2;
            AV41i = 1;
            AV53GXV2 = 1;
            while ( AV53GXV2 <= AV47TFLeaveTypeLoggingWorkHours_Sels.Count )
            {
               AV46TFLeaveTypeLoggingWorkHours_Sel = AV47TFLeaveTypeLoggingWorkHours_Sels.GetString(AV53GXV2);
               if ( AV41i == 1 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV46TFLeaveTypeLoggingWorkHours_Sel), "No") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"No";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV46TFLeaveTypeLoggingWorkHours_Sel), "Yes") == 0 )
               {
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text+"Yes";
               }
               AV41i = (long)(AV41i+1);
               AV53GXV2 = (int)(AV53GXV2+1);
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("LeaveTypeWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("LeaveTypeWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV54GXV3 = 1;
         while ( AV54GXV3 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV54GXV3));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV54GXV3 = (int)(AV54GXV3+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV56Leavetypewwds_1_filterfulltext = AV19FilterFullText;
         AV57Leavetypewwds_2_tfleavetypename = AV37TFLeaveTypeName;
         AV58Leavetypewwds_3_tfleavetypename_sel = AV38TFLeaveTypeName_Sel;
         AV59Leavetypewwds_4_tfleavetypevacationleave_sels = AV44TFLeaveTypeVacationLeave_Sels;
         AV60Leavetypewwds_5_tfleavetypeloggingworkhours_sels = AV47TFLeaveTypeLoggingWorkHours_Sels;
         AV61Udparg6 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A144LeaveTypeVacationLeave ,
                                              AV59Leavetypewwds_4_tfleavetypevacationleave_sels ,
                                              A145LeaveTypeLoggingWorkHours ,
                                              AV60Leavetypewwds_5_tfleavetypeloggingworkhours_sels ,
                                              AV56Leavetypewwds_1_filterfulltext ,
                                              AV58Leavetypewwds_3_tfleavetypename_sel ,
                                              AV57Leavetypewwds_2_tfleavetypename ,
                                              AV59Leavetypewwds_4_tfleavetypevacationleave_sels.Count ,
                                              AV60Leavetypewwds_5_tfleavetypeloggingworkhours_sels.Count ,
                                              A125LeaveTypeName ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc ,
                                              AV61Udparg6 ,
                                              A100CompanyId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV56Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leavetypewwds_1_filterfulltext), "%", "");
         lV56Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leavetypewwds_1_filterfulltext), "%", "");
         lV56Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leavetypewwds_1_filterfulltext), "%", "");
         lV56Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leavetypewwds_1_filterfulltext), "%", "");
         lV56Leavetypewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Leavetypewwds_1_filterfulltext), "%", "");
         lV57Leavetypewwds_2_tfleavetypename = StringUtil.PadR( StringUtil.RTrim( AV57Leavetypewwds_2_tfleavetypename), 100, "%");
         /* Using cursor P005E2 */
         pr_default.execute(0, new Object[] {AV61Udparg6, lV56Leavetypewwds_1_filterfulltext, lV56Leavetypewwds_1_filterfulltext, lV56Leavetypewwds_1_filterfulltext, lV56Leavetypewwds_1_filterfulltext, lV56Leavetypewwds_1_filterfulltext, lV57Leavetypewwds_2_tfleavetypename, AV58Leavetypewwds_3_tfleavetypename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P005E2_A100CompanyId[0];
            A145LeaveTypeLoggingWorkHours = P005E2_A145LeaveTypeLoggingWorkHours[0];
            A144LeaveTypeVacationLeave = P005E2_A144LeaveTypeVacationLeave[0];
            A125LeaveTypeName = P005E2_A125LeaveTypeName[0];
            A124LeaveTypeId = P005E2_A124LeaveTypeId[0];
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
            AV62GXV4 = 1;
            while ( AV62GXV4 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV62GXV4));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveTypeName") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A125LeaveTypeName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveTypeVacationLeave") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( A144LeaveTypeVacationLeave), "No") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "No";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A144LeaveTypeVacationLeave), "Yes") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "Yes";
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "LeaveTypeLoggingWorkHours") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( A145LeaveTypeLoggingWorkHours), "No") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "No";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( A145LeaveTypeLoggingWorkHours), "Yes") == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = "Yes";
                     }
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV62GXV4 = (int)(AV62GXV4+1);
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
         AV20Session.Set("WWPExportFileName", "LeaveTypeWWExport.xlsx");
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
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveTypeName",  "",  "Leave Type Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveTypeVacationLeave",  "",  "Deduct from vacation days ",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "LeaveTypeLoggingWorkHours",  "",  "Log Work Hours",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "LeaveTypeWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("LeaveTypeWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "LeaveTypeWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("LeaveTypeWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV63GXV5 = 1;
         while ( AV63GXV5 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV63GXV5));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME") == 0 )
            {
               AV37TFLeaveTypeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPENAME_SEL") == 0 )
            {
               AV38TFLeaveTypeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPEVACATIONLEAVE_SEL") == 0 )
            {
               AV42TFLeaveTypeVacationLeave_SelsJson = AV23GridStateFilterValue.gxTpr_Value;
               AV44TFLeaveTypeVacationLeave_Sels.FromJSonString(AV42TFLeaveTypeVacationLeave_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFLEAVETYPELOGGINGWORKHOURS_SEL") == 0 )
            {
               AV45TFLeaveTypeLoggingWorkHours_SelsJson = AV23GridStateFilterValue.gxTpr_Value;
               AV47TFLeaveTypeLoggingWorkHours_Sels.FromJSonString(AV45TFLeaveTypeLoggingWorkHours_SelsJson, null);
            }
            AV63GXV5 = (int)(AV63GXV5+1);
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
         AV38TFLeaveTypeName_Sel = "";
         AV37TFLeaveTypeName = "";
         AV44TFLeaveTypeVacationLeave_Sels = new GxSimpleCollection<string>();
         AV43TFLeaveTypeVacationLeave_Sel = "";
         AV47TFLeaveTypeLoggingWorkHours_Sels = new GxSimpleCollection<string>();
         AV46TFLeaveTypeLoggingWorkHours_Sel = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column(context);
         AV56Leavetypewwds_1_filterfulltext = "";
         AV57Leavetypewwds_2_tfleavetypename = "";
         AV58Leavetypewwds_3_tfleavetypename_sel = "";
         AV59Leavetypewwds_4_tfleavetypevacationleave_sels = new GxSimpleCollection<string>();
         AV60Leavetypewwds_5_tfleavetypeloggingworkhours_sels = new GxSimpleCollection<string>();
         lV56Leavetypewwds_1_filterfulltext = "";
         lV57Leavetypewwds_2_tfleavetypename = "";
         A144LeaveTypeVacationLeave = "";
         A145LeaveTypeLoggingWorkHours = "";
         A125LeaveTypeName = "";
         P005E2_A100CompanyId = new long[1] ;
         P005E2_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P005E2_A144LeaveTypeVacationLeave = new string[] {""} ;
         P005E2_A125LeaveTypeName = new string[] {""} ;
         P005E2_A124LeaveTypeId = new long[1] ;
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV22GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV23GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         AV42TFLeaveTypeVacationLeave_SelsJson = "";
         AV45TFLeaveTypeLoggingWorkHours_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.leavetypewwexport__default(),
            new Object[][] {
                new Object[] {
               P005E2_A100CompanyId, P005E2_A145LeaveTypeLoggingWorkHours, P005E2_A144LeaveTypeVacationLeave, P005E2_A125LeaveTypeName, P005E2_A124LeaveTypeId
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
      private int AV52GXV1 ;
      private int AV53GXV2 ;
      private int AV54GXV3 ;
      private int AV59Leavetypewwds_4_tfleavetypevacationleave_sels_Count ;
      private int AV60Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count ;
      private int AV62GXV4 ;
      private int AV63GXV5 ;
      private long AV41i ;
      private long AV32VisibleColumnCount ;
      private long AV61Udparg6 ;
      private long A100CompanyId ;
      private long A124LeaveTypeId ;
      private string AV38TFLeaveTypeName_Sel ;
      private string AV37TFLeaveTypeName ;
      private string AV43TFLeaveTypeVacationLeave_Sel ;
      private string AV46TFLeaveTypeLoggingWorkHours_Sel ;
      private string AV57Leavetypewwds_2_tfleavetypename ;
      private string AV58Leavetypewwds_3_tfleavetypename_sel ;
      private string lV57Leavetypewwds_2_tfleavetypename ;
      private string A144LeaveTypeVacationLeave ;
      private string A145LeaveTypeLoggingWorkHours ;
      private string A125LeaveTypeName ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV42TFLeaveTypeVacationLeave_SelsJson ;
      private string AV45TFLeaveTypeLoggingWorkHours_SelsJson ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV56Leavetypewwds_1_filterfulltext ;
      private string lV56Leavetypewwds_1_filterfulltext ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV44TFLeaveTypeVacationLeave_Sels ;
      private GxSimpleCollection<string> AV47TFLeaveTypeLoggingWorkHours_Sels ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private GxSimpleCollection<string> AV59Leavetypewwds_4_tfleavetypevacationleave_sels ;
      private GxSimpleCollection<string> AV60Leavetypewwds_5_tfleavetypeloggingworkhours_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P005E2_A100CompanyId ;
      private string[] P005E2_A145LeaveTypeLoggingWorkHours ;
      private string[] P005E2_A144LeaveTypeVacationLeave ;
      private string[] P005E2_A125LeaveTypeName ;
      private long[] P005E2_A124LeaveTypeId ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV22GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class leavetypewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005E2( IGxContext context ,
                                             string A144LeaveTypeVacationLeave ,
                                             GxSimpleCollection<string> AV59Leavetypewwds_4_tfleavetypevacationleave_sels ,
                                             string A145LeaveTypeLoggingWorkHours ,
                                             GxSimpleCollection<string> AV60Leavetypewwds_5_tfleavetypeloggingworkhours_sels ,
                                             string AV56Leavetypewwds_1_filterfulltext ,
                                             string AV58Leavetypewwds_3_tfleavetypename_sel ,
                                             string AV57Leavetypewwds_2_tfleavetypename ,
                                             int AV59Leavetypewwds_4_tfleavetypevacationleave_sels_Count ,
                                             int AV60Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count ,
                                             string A125LeaveTypeName ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc ,
                                             long AV61Udparg6 ,
                                             long A100CompanyId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT CompanyId, LeaveTypeLoggingWorkHours, LeaveTypeVacationLeave, LeaveTypeName, LeaveTypeId FROM LeaveType";
         AddWhere(sWhereString, "(CompanyId = :AV61Udparg6)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Leavetypewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LeaveTypeName like '%' || :lV56Leavetypewwds_1_filterfulltext) or ( 'no' like '%' || LOWER(:lV56Leavetypewwds_1_filterfulltext) and LeaveTypeVacationLeave = ( 'No')) or ( 'yes' like '%' || LOWER(:lV56Leavetypewwds_1_filterfulltext) and LeaveTypeVacationLeave = ( 'Yes')) or ( 'no' like '%' || LOWER(:lV56Leavetypewwds_1_filterfulltext) and LeaveTypeLoggingWorkHours = ( 'No')) or ( 'yes' like '%' || LOWER(:lV56Leavetypewwds_1_filterfulltext) and LeaveTypeLoggingWorkHours = ( 'Yes')))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Leavetypewwds_3_tfleavetypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Leavetypewwds_2_tfleavetypename)) ) )
         {
            AddWhere(sWhereString, "(LeaveTypeName like :lV57Leavetypewwds_2_tfleavetypename)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Leavetypewwds_3_tfleavetypename_sel)) && ! ( StringUtil.StrCmp(AV58Leavetypewwds_3_tfleavetypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LeaveTypeName = ( :AV58Leavetypewwds_3_tfleavetypename_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Leavetypewwds_3_tfleavetypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from LeaveTypeName))=0))");
         }
         if ( AV59Leavetypewwds_4_tfleavetypevacationleave_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV59Leavetypewwds_4_tfleavetypevacationleave_sels, "LeaveTypeVacationLeave IN (", ")")+")");
         }
         if ( AV60Leavetypewwds_5_tfleavetypeloggingworkhours_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV60Leavetypewwds_5_tfleavetypeloggingworkhours_sels, "LeaveTypeLoggingWorkHours IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY LeaveTypeName";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LeaveTypeName DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY LeaveTypeVacationLeave";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LeaveTypeVacationLeave DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY LeaveTypeLoggingWorkHours";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY LeaveTypeLoggingWorkHours DESC";
         }
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
                     return conditional_P005E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (bool)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] );
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
          Object[] prmP005E2;
          prmP005E2 = new Object[] {
          new ParDef("AV61Udparg6",GXType.Int64,10,0) ,
          new ParDef("lV56Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Leavetypewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Leavetypewwds_2_tfleavetypename",GXType.Char,100,0) ,
          new ParDef("AV58Leavetypewwds_3_tfleavetypename_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005E2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
