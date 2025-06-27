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
   public class employeelistexport : GXProcedure
   {
      public employeelistexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeelistexport( IGxContext context )
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
         AV12Filename = GXt_char1 + "EmployeeListExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFEmployeeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFEmployeeName_Sel)) ? "(Empty)" : AV42TFEmployeeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFEmployeeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV41TFEmployeeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFEmployeeEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Email") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV44TFEmployeeEmail_Sel)) ? "(Empty)" : AV44TFEmployeeEmail_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFEmployeeEmail)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Email") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV43TFEmployeeEmail, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCompanyName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCompanyName_Sel)) ? "(Empty)" : AV48TFCompanyName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCompanyName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV47TFCompanyName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV49TFEmployeeIsManager_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Is Manager") ;
            AV14CellRow = GXt_int2;
            if ( AV49TFEmployeeIsManager_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Checked";
            }
            else if ( AV49TFEmployeeIsManager_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Unchecked";
            }
         }
         if ( ! ( (0==AV52TFEmployeeIsActive_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Is Active") ;
            AV14CellRow = GXt_int2;
            if ( AV52TFEmployeeIsActive_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Checked";
            }
            else if ( AV52TFEmployeeIsActive_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Unchecked";
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV53TFEmployeeVactionDays) && (Convert.ToDecimal(0)==AV54TFEmployeeVactionDays_To) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Vacation Days") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Number = (double)(AV53TFEmployeeVactionDays);
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  false, ref  GXt_int2,  (short)(AV15FirstColumn+2),  "To") ;
            AV14CellRow = GXt_int2;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Number = (double)(AV54TFEmployeeVactionDays_To);
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV32VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV20Session.Get("EmployeeListColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("EmployeeListColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV58GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV60Employeelistds_1_filterfulltext = AV19FilterFullText;
         AV61Employeelistds_2_tfemployeename = AV41TFEmployeeName;
         AV62Employeelistds_3_tfemployeename_sel = AV42TFEmployeeName_Sel;
         AV63Employeelistds_4_tfemployeeemail = AV43TFEmployeeEmail;
         AV64Employeelistds_5_tfemployeeemail_sel = AV44TFEmployeeEmail_Sel;
         AV65Employeelistds_6_tfcompanyname = AV47TFCompanyName;
         AV66Employeelistds_7_tfcompanyname_sel = AV48TFCompanyName_Sel;
         AV67Employeelistds_8_tfemployeeismanager_sel = AV49TFEmployeeIsManager_Sel;
         AV68Employeelistds_9_tfemployeeisactive_sel = AV52TFEmployeeIsActive_Sel;
         AV69Employeelistds_10_tfemployeevactiondays = AV53TFEmployeeVactionDays;
         AV70Employeelistds_11_tfemployeevactiondays_to = AV54TFEmployeeVactionDays_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV60Employeelistds_1_filterfulltext ,
                                              AV62Employeelistds_3_tfemployeename_sel ,
                                              AV61Employeelistds_2_tfemployeename ,
                                              AV64Employeelistds_5_tfemployeeemail_sel ,
                                              AV63Employeelistds_4_tfemployeeemail ,
                                              AV66Employeelistds_7_tfcompanyname_sel ,
                                              AV65Employeelistds_6_tfcompanyname ,
                                              AV67Employeelistds_8_tfemployeeismanager_sel ,
                                              AV68Employeelistds_9_tfemployeeisactive_sel ,
                                              AV69Employeelistds_10_tfemployeevactiondays ,
                                              AV70Employeelistds_11_tfemployeevactiondays_to ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A101CompanyName ,
                                              A146EmployeeVactionDays ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Employeelistds_1_filterfulltext), "%", "");
         lV60Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Employeelistds_1_filterfulltext), "%", "");
         lV60Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Employeelistds_1_filterfulltext), "%", "");
         lV60Employeelistds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Employeelistds_1_filterfulltext), "%", "");
         lV61Employeelistds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV61Employeelistds_2_tfemployeename), 100, "%");
         lV63Employeelistds_4_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV63Employeelistds_4_tfemployeeemail), "%", "");
         lV65Employeelistds_6_tfcompanyname = StringUtil.PadR( StringUtil.RTrim( AV65Employeelistds_6_tfcompanyname), 100, "%");
         /* Using cursor P007T2 */
         pr_default.execute(0, new Object[] {lV60Employeelistds_1_filterfulltext, lV60Employeelistds_1_filterfulltext, lV60Employeelistds_1_filterfulltext, lV60Employeelistds_1_filterfulltext, lV61Employeelistds_2_tfemployeename, AV62Employeelistds_3_tfemployeename_sel, lV63Employeelistds_4_tfemployeeemail, AV64Employeelistds_5_tfemployeeemail_sel, lV65Employeelistds_6_tfcompanyname, AV66Employeelistds_7_tfcompanyname_sel, AV69Employeelistds_10_tfemployeevactiondays, AV70Employeelistds_11_tfemployeevactiondays_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P007T2_A100CompanyId[0];
            A146EmployeeVactionDays = P007T2_A146EmployeeVactionDays[0];
            A112EmployeeIsActive = P007T2_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P007T2_A110EmployeeIsManager[0];
            A101CompanyName = P007T2_A101CompanyName[0];
            A109EmployeeEmail = P007T2_A109EmployeeEmail[0];
            A148EmployeeName = P007T2_A148EmployeeName[0];
            A107EmployeeFirstName = P007T2_A107EmployeeFirstName[0];
            A106EmployeeId = P007T2_A106EmployeeId[0];
            A101CompanyName = P007T2_A101CompanyName[0];
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
            AV71GXV2 = 1;
            while ( AV71GXV2 <= AV24ColumnsSelector.gxTpr_Columns.Count )
            {
               AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV71GXV2));
               if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeName") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A148EmployeeName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeEmail") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A109EmployeeEmail, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "CompanyName") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A101CompanyName, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeIsManager") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A110EmployeeIsManager);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeIsActive") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A112EmployeeIsActive);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeVactionDays") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = (double)(A146EmployeeVactionDays);
                  }
                  AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
               }
               AV71GXV2 = (int)(AV71GXV2+1);
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
         AV20Session.Set("WWPExportFileName", "EmployeeListExport.xlsx");
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
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeName",  "",  "Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeEmail",  "",  "Email",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "CompanyName",  "",  "Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeIsManager",  "",  "Is Manager",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeIsActive",  "",  "Is Active",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeVactionDays",  "",  "Vacation Days",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "EmployeeListColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("EmployeeListGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "EmployeeListGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("EmployeeListGridState"), null, "", "");
         }
         AV17OrderedBy = AV22GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV22GridState.gxTpr_Ordereddsc;
         AV72GXV3 = 1;
         while ( AV72GXV3 <= AV22GridState.gxTpr_Filtervalues.Count )
         {
            AV23GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV22GridState.gxTpr_Filtervalues.Item(AV72GXV3));
            if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV41TFEmployeeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV42TFEmployeeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL") == 0 )
            {
               AV43TFEmployeeEmail = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL_SEL") == 0 )
            {
               AV44TFEmployeeEmail_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME") == 0 )
            {
               AV47TFCompanyName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFCOMPANYNAME_SEL") == 0 )
            {
               AV48TFCompanyName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISMANAGER_SEL") == 0 )
            {
               AV49TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISACTIVE_SEL") == 0 )
            {
               AV52TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEVACTIONDAYS") == 0 )
            {
               AV53TFEmployeeVactionDays = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, ".");
               AV54TFEmployeeVactionDays_To = NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV72GXV3 = (int)(AV72GXV3+1);
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
         AV42TFEmployeeName_Sel = "";
         AV41TFEmployeeName = "";
         AV44TFEmployeeEmail_Sel = "";
         AV43TFEmployeeEmail = "";
         AV48TFCompanyName_Sel = "";
         AV47TFCompanyName = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column(context);
         AV60Employeelistds_1_filterfulltext = "";
         AV61Employeelistds_2_tfemployeename = "";
         AV62Employeelistds_3_tfemployeename_sel = "";
         AV63Employeelistds_4_tfemployeeemail = "";
         AV64Employeelistds_5_tfemployeeemail_sel = "";
         AV65Employeelistds_6_tfcompanyname = "";
         AV66Employeelistds_7_tfcompanyname_sel = "";
         lV60Employeelistds_1_filterfulltext = "";
         lV61Employeelistds_2_tfemployeename = "";
         lV63Employeelistds_4_tfemployeeemail = "";
         lV65Employeelistds_6_tfcompanyname = "";
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         A101CompanyName = "";
         P007T2_A100CompanyId = new long[1] ;
         P007T2_A146EmployeeVactionDays = new decimal[1] ;
         P007T2_A112EmployeeIsActive = new bool[] {false} ;
         P007T2_A110EmployeeIsManager = new bool[] {false} ;
         P007T2_A101CompanyName = new string[] {""} ;
         P007T2_A109EmployeeEmail = new string[] {""} ;
         P007T2_A148EmployeeName = new string[] {""} ;
         P007T2_A107EmployeeFirstName = new string[] {""} ;
         P007T2_A106EmployeeId = new long[1] ;
         A107EmployeeFirstName = "";
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV22GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV23GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeelistexport__default(),
            new Object[][] {
                new Object[] {
               P007T2_A100CompanyId, P007T2_A146EmployeeVactionDays, P007T2_A112EmployeeIsActive, P007T2_A110EmployeeIsManager, P007T2_A101CompanyName, P007T2_A109EmployeeEmail, P007T2_A148EmployeeName, P007T2_A107EmployeeFirstName, P007T2_A106EmployeeId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV49TFEmployeeIsManager_Sel ;
      private short AV52TFEmployeeIsActive_Sel ;
      private short GXt_int2 ;
      private short AV67Employeelistds_8_tfemployeeismanager_sel ;
      private short AV68Employeelistds_9_tfemployeeisactive_sel ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV58GXV1 ;
      private int AV71GXV2 ;
      private int AV72GXV3 ;
      private long AV32VisibleColumnCount ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private decimal AV53TFEmployeeVactionDays ;
      private decimal AV54TFEmployeeVactionDays_To ;
      private decimal AV69Employeelistds_10_tfemployeevactiondays ;
      private decimal AV70Employeelistds_11_tfemployeevactiondays_to ;
      private decimal A146EmployeeVactionDays ;
      private string AV42TFEmployeeName_Sel ;
      private string AV41TFEmployeeName ;
      private string AV48TFCompanyName_Sel ;
      private string AV47TFCompanyName ;
      private string AV61Employeelistds_2_tfemployeename ;
      private string AV62Employeelistds_3_tfemployeename_sel ;
      private string AV65Employeelistds_6_tfcompanyname ;
      private string AV66Employeelistds_7_tfcompanyname_sel ;
      private string lV61Employeelistds_2_tfemployeename ;
      private string lV65Employeelistds_6_tfcompanyname ;
      private string A148EmployeeName ;
      private string A101CompanyName ;
      private string A107EmployeeFirstName ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool A110EmployeeIsManager ;
      private bool A112EmployeeIsActive ;
      private bool AV18OrderedDsc ;
      private string AV27ColumnsSelectorXML ;
      private string AV28UserCustomValue ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV44TFEmployeeEmail_Sel ;
      private string AV43TFEmployeeEmail ;
      private string AV60Employeelistds_1_filterfulltext ;
      private string AV63Employeelistds_4_tfemployeeemail ;
      private string AV64Employeelistds_5_tfemployeeemail_sel ;
      private string lV60Employeelistds_1_filterfulltext ;
      private string lV63Employeelistds_4_tfemployeeemail ;
      private string A109EmployeeEmail ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private long[] P007T2_A100CompanyId ;
      private decimal[] P007T2_A146EmployeeVactionDays ;
      private bool[] P007T2_A112EmployeeIsActive ;
      private bool[] P007T2_A110EmployeeIsManager ;
      private string[] P007T2_A101CompanyName ;
      private string[] P007T2_A109EmployeeEmail ;
      private string[] P007T2_A148EmployeeName ;
      private string[] P007T2_A107EmployeeFirstName ;
      private long[] P007T2_A106EmployeeId ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV22GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class employeelistexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007T2( IGxContext context ,
                                             string AV60Employeelistds_1_filterfulltext ,
                                             string AV62Employeelistds_3_tfemployeename_sel ,
                                             string AV61Employeelistds_2_tfemployeename ,
                                             string AV64Employeelistds_5_tfemployeeemail_sel ,
                                             string AV63Employeelistds_4_tfemployeeemail ,
                                             string AV66Employeelistds_7_tfcompanyname_sel ,
                                             string AV65Employeelistds_6_tfcompanyname ,
                                             short AV67Employeelistds_8_tfemployeeismanager_sel ,
                                             short AV68Employeelistds_9_tfemployeeisactive_sel ,
                                             decimal AV69Employeelistds_10_tfemployeevactiondays ,
                                             decimal AV70Employeelistds_11_tfemployeevactiondays_to ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             string A101CompanyName ,
                                             decimal A146EmployeeVactionDays ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeVactionDays, T1.EmployeeIsActive, T1.EmployeeIsManager, T2.CompanyName, T1.EmployeeEmail, T1.EmployeeName, T1.EmployeeFirstName, T1.EmployeeId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Employeelistds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.EmployeeName like '%' || :lV60Employeelistds_1_filterfulltext) or ( T1.EmployeeEmail like '%' || :lV60Employeelistds_1_filterfulltext) or ( T2.CompanyName like '%' || :lV60Employeelistds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeVactionDays,'90.9'), 2) like '%' || :lV60Employeelistds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeelistds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Employeelistds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName like :lV61Employeelistds_2_tfemployeename)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Employeelistds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV62Employeelistds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeName = ( :AV62Employeelistds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV62Employeelistds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeelistds_5_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Employeelistds_4_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail like :lV63Employeelistds_4_tfemployeeemail)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeelistds_5_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV64Employeelistds_5_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.EmployeeEmail = ( :AV64Employeelistds_5_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV64Employeelistds_5_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.EmployeeEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Employeelistds_7_tfcompanyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Employeelistds_6_tfcompanyname)) ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName like :lV65Employeelistds_6_tfcompanyname)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Employeelistds_7_tfcompanyname_sel)) && ! ( StringUtil.StrCmp(AV66Employeelistds_7_tfcompanyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CompanyName = ( :AV66Employeelistds_7_tfcompanyname_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV66Employeelistds_7_tfcompanyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CompanyName))=0))");
         }
         if ( AV67Employeelistds_8_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = TRUE)");
         }
         if ( AV67Employeelistds_8_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsManager = FALSE)");
         }
         if ( AV68Employeelistds_9_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = TRUE)");
         }
         if ( AV68Employeelistds_9_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.EmployeeIsActive = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV69Employeelistds_10_tfemployeevactiondays) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays >= :AV69Employeelistds_10_tfemployeevactiondays)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV70Employeelistds_11_tfemployeevactiondays_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeVactionDays <= :AV70Employeelistds_11_tfemployeevactiondays_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.EmployeeFirstName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeName DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeEmail";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeEmail DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.CompanyName";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.CompanyName DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeIsManager";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeIsManager DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeIsActive";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeIsActive DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeVactionDays";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeVactionDays DESC";
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
                     return conditional_P007T2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (bool)dynConstraints[15] , (bool)dynConstraints[16] , (short)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmP007T2;
          prmP007T2 = new Object[] {
          new ParDef("lV60Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Employeelistds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Employeelistds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV62Employeelistds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV63Employeelistds_4_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV64Employeelistds_5_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV65Employeelistds_6_tfcompanyname",GXType.Char,100,0) ,
          new ParDef("AV66Employeelistds_7_tfcompanyname_sel",GXType.Char,100,0) ,
          new ParDef("AV69Employeelistds_10_tfemployeevactiondays",GXType.Number,4,1) ,
          new ParDef("AV70Employeelistds_11_tfemployeevactiondays_to",GXType.Number,4,1)
          };
          def= new CursorDef[] {
              new CursorDef("P007T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007T2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
