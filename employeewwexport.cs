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
   public class employeewwexport : GXProcedure
   {
      public employeewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeewwexport( IGxContext context )
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
         AV12Filename = GXt_char1 + "EmployeeWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFEmployeeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Employee Name") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFEmployeeName_Sel)) ? "(Empty)" : AV57TFEmployeeName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFEmployeeName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Employee Name") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV56TFEmployeeName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFEmployeeEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Email") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFEmployeeEmail_Sel)) ? "(Empty)" : AV42TFEmployeeEmail_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFEmployeeEmail)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Email") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV41TFEmployeeEmail, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV47TFEmployeeIsManager_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Is HR Manager") ;
            AV14CellRow = GXt_int2;
            if ( AV47TFEmployeeIsManager_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Checked";
            }
            else if ( AV47TFEmployeeIsManager_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Unchecked";
            }
         }
         if ( ! ( (0==AV50TFEmployeeIsActive_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Is Active") ;
            AV14CellRow = GXt_int2;
            if ( AV50TFEmployeeIsActive_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Checked";
            }
            else if ( AV50TFEmployeeIsActive_Sel == 2 )
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
         if ( StringUtil.StrCmp(AV20Session.Get("EmployeeWWColumnsSelector"), "") != 0 )
         {
            AV27ColumnsSelectorXML = AV20Session.Get("EmployeeWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV27ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV24ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV24ColumnsSelector.gxTpr_Columns.Count )
         {
            AV26ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(AV61GXV1));
            if ( AV26ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV26ColumnsSelector_Column.gxTpr_Displayname)) ? AV26ColumnsSelector_Column.gxTpr_Columnname : AV26ColumnsSelector_Column.gxTpr_Displayname), "");
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Bold = 1;
               AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Color = 11;
               AV32VisibleColumnCount = (long)(AV32VisibleColumnCount+1);
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV63Employeewwds_1_filterfulltext = AV19FilterFullText;
         AV64Employeewwds_2_tfemployeename = AV56TFEmployeeName;
         AV65Employeewwds_3_tfemployeename_sel = AV57TFEmployeeName_Sel;
         AV66Employeewwds_4_tfemployeeemail = AV41TFEmployeeEmail;
         AV67Employeewwds_5_tfemployeeemail_sel = AV42TFEmployeeEmail_Sel;
         AV68Employeewwds_6_tfemployeeismanager_sel = AV47TFEmployeeIsManager_Sel;
         AV69Employeewwds_7_tfemployeeisactive_sel = AV50TFEmployeeIsActive_Sel;
         AV70Udparg8 = new getloggedinusercompanyid(context).executeUdp( );
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV58EmployeeIds ,
                                              AV63Employeewwds_1_filterfulltext ,
                                              AV65Employeewwds_3_tfemployeename_sel ,
                                              AV64Employeewwds_2_tfemployeename ,
                                              AV67Employeewwds_5_tfemployeeemail_sel ,
                                              AV66Employeewwds_4_tfemployeeemail ,
                                              AV68Employeewwds_6_tfemployeeismanager_sel ,
                                              AV69Employeewwds_7_tfemployeeisactive_sel ,
                                              A148EmployeeName ,
                                              A109EmployeeEmail ,
                                              A110EmployeeIsManager ,
                                              A112EmployeeIsActive ,
                                              A100CompanyId ,
                                              AV70Udparg8 ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Employeewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Employeewwds_1_filterfulltext), "%", "");
         lV63Employeewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Employeewwds_1_filterfulltext), "%", "");
         lV64Employeewwds_2_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV64Employeewwds_2_tfemployeename), 100, "%");
         lV66Employeewwds_4_tfemployeeemail = StringUtil.Concat( StringUtil.RTrim( AV66Employeewwds_4_tfemployeeemail), "%", "");
         /* Using cursor P006T2 */
         pr_default.execute(0, new Object[] {lV63Employeewwds_1_filterfulltext, lV63Employeewwds_1_filterfulltext, lV64Employeewwds_2_tfemployeename, AV65Employeewwds_3_tfemployeename_sel, lV66Employeewwds_4_tfemployeeemail, AV67Employeewwds_5_tfemployeeemail_sel, AV70Udparg8});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P006T2_A106EmployeeId[0];
            A100CompanyId = P006T2_A100CompanyId[0];
            A112EmployeeIsActive = P006T2_A112EmployeeIsActive[0];
            A110EmployeeIsManager = P006T2_A110EmployeeIsManager[0];
            A109EmployeeEmail = P006T2_A109EmployeeEmail[0];
            A148EmployeeName = P006T2_A148EmployeeName[0];
            A107EmployeeFirstName = P006T2_A107EmployeeFirstName[0];
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
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeIsManager") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A110EmployeeIsManager);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "EmployeeIsActive") == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Text = StringUtil.BoolToStr( A112EmployeeIsActive);
                  }
                  else if ( StringUtil.StrCmp(AV26ColumnsSelector_Column.gxTpr_Columnname, "&EmployeeBalance") == 0 )
                  {
                     GXt_decimal3 = AV60EmployeeBalance;
                     new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal3) ;
                     AV60EmployeeBalance = GXt_decimal3;
                     AV11ExcelDocument.get_Cells(AV14CellRow, (int)(AV15FirstColumn+AV32VisibleColumnCount), 1, 1).Number = (double)(AV60EmployeeBalance);
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
         AV20Session.Set("WWPExportFileName", "EmployeeWWExport.xlsx");
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
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeName",  "",  "Employee Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeEmail",  "",  "Email",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeIsManager",  "",  "Is HR Manager",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "EmployeeIsActive",  "",  "Is Active",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "&EmployeeBalance",  "",  "Balance",  true,  "") ;
         GXt_char1 = AV28UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "EmployeeWWColumnsSelector", out  GXt_char1) ;
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
         if ( StringUtil.StrCmp(AV20Session.Get("EmployeeWWGridState"), "") == 0 )
         {
            AV22GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "EmployeeWWGridState"), null, "", "");
         }
         else
         {
            AV22GridState.FromXml(AV20Session.Get("EmployeeWWGridState"), null, "", "");
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
               AV56TFEmployeeName = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV57TFEmployeeName_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL") == 0 )
            {
               AV41TFEmployeeEmail = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEEMAIL_SEL") == 0 )
            {
               AV42TFEmployeeEmail_Sel = AV23GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISMANAGER_SEL") == 0 )
            {
               AV47TFEmployeeIsManager_Sel = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV23GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEISACTIVE_SEL") == 0 )
            {
               AV50TFEmployeeIsActive_Sel = (short)(Math.Round(NumberUtil.Val( AV23GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
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
         AV57TFEmployeeName_Sel = "";
         AV56TFEmployeeName = "";
         AV42TFEmployeeEmail_Sel = "";
         AV41TFEmployeeEmail = "";
         AV20Session = context.GetSession();
         AV27ColumnsSelectorXML = "";
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV26ColumnsSelector_Column = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column(context);
         AV63Employeewwds_1_filterfulltext = "";
         AV64Employeewwds_2_tfemployeename = "";
         AV65Employeewwds_3_tfemployeename_sel = "";
         AV66Employeewwds_4_tfemployeeemail = "";
         AV67Employeewwds_5_tfemployeeemail_sel = "";
         lV63Employeewwds_1_filterfulltext = "";
         lV64Employeewwds_2_tfemployeename = "";
         lV66Employeewwds_4_tfemployeeemail = "";
         AV58EmployeeIds = new GxSimpleCollection<long>();
         A148EmployeeName = "";
         A109EmployeeEmail = "";
         P006T2_A106EmployeeId = new long[1] ;
         P006T2_A100CompanyId = new long[1] ;
         P006T2_A112EmployeeIsActive = new bool[] {false} ;
         P006T2_A110EmployeeIsManager = new bool[] {false} ;
         P006T2_A109EmployeeEmail = new string[] {""} ;
         P006T2_A148EmployeeName = new string[] {""} ;
         P006T2_A107EmployeeFirstName = new string[] {""} ;
         A107EmployeeFirstName = "";
         AV28UserCustomValue = "";
         GXt_char1 = "";
         AV25ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV22GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV23GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeewwexport__default(),
            new Object[][] {
                new Object[] {
               P006T2_A106EmployeeId, P006T2_A100CompanyId, P006T2_A112EmployeeIsActive, P006T2_A110EmployeeIsManager, P006T2_A109EmployeeEmail, P006T2_A148EmployeeName, P006T2_A107EmployeeFirstName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV47TFEmployeeIsManager_Sel ;
      private short AV50TFEmployeeIsActive_Sel ;
      private short GXt_int2 ;
      private short AV68Employeewwds_6_tfemployeeismanager_sel ;
      private short AV69Employeewwds_7_tfemployeeisactive_sel ;
      private short AV17OrderedBy ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV61GXV1 ;
      private int AV71GXV2 ;
      private int AV72GXV3 ;
      private long AV32VisibleColumnCount ;
      private long AV70Udparg8 ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private decimal AV60EmployeeBalance ;
      private decimal GXt_decimal3 ;
      private string AV57TFEmployeeName_Sel ;
      private string AV56TFEmployeeName ;
      private string AV64Employeewwds_2_tfemployeename ;
      private string AV65Employeewwds_3_tfemployeename_sel ;
      private string lV64Employeewwds_2_tfemployeename ;
      private string A148EmployeeName ;
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
      private string AV42TFEmployeeEmail_Sel ;
      private string AV41TFEmployeeEmail ;
      private string AV63Employeewwds_1_filterfulltext ;
      private string AV66Employeewwds_4_tfemployeeemail ;
      private string AV67Employeewwds_5_tfemployeeemail_sel ;
      private string lV63Employeewwds_1_filterfulltext ;
      private string lV66Employeewwds_4_tfemployeeemail ;
      private string A109EmployeeEmail ;
      private IGxSession AV20Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column AV26ColumnsSelector_Column ;
      private GxSimpleCollection<long> AV58EmployeeIds ;
      private IDataStoreProvider pr_default ;
      private long[] P006T2_A106EmployeeId ;
      private long[] P006T2_A100CompanyId ;
      private bool[] P006T2_A112EmployeeIsActive ;
      private bool[] P006T2_A110EmployeeIsManager ;
      private string[] P006T2_A109EmployeeEmail ;
      private string[] P006T2_A148EmployeeName ;
      private string[] P006T2_A107EmployeeFirstName ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV22GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV23GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class employeewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006T2( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV58EmployeeIds ,
                                             string AV63Employeewwds_1_filterfulltext ,
                                             string AV65Employeewwds_3_tfemployeename_sel ,
                                             string AV64Employeewwds_2_tfemployeename ,
                                             string AV67Employeewwds_5_tfemployeeemail_sel ,
                                             string AV66Employeewwds_4_tfemployeeemail ,
                                             short AV68Employeewwds_6_tfemployeeismanager_sel ,
                                             short AV69Employeewwds_7_tfemployeeisactive_sel ,
                                             string A148EmployeeName ,
                                             string A109EmployeeEmail ,
                                             bool A110EmployeeIsManager ,
                                             bool A112EmployeeIsActive ,
                                             long A100CompanyId ,
                                             long AV70Udparg8 ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[7];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT EmployeeId, CompanyId, EmployeeIsActive, EmployeeIsManager, EmployeeEmail, EmployeeName, EmployeeFirstName FROM Employee";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Employeewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EmployeeName like '%' || :lV63Employeewwds_1_filterfulltext) or ( EmployeeEmail like '%' || :lV63Employeewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Employeewwds_3_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Employeewwds_2_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(EmployeeName like :lV64Employeewwds_2_tfemployeename)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Employeewwds_3_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV65Employeewwds_3_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmployeeName = ( :AV65Employeewwds_3_tfemployeename_sel))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV65Employeewwds_3_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EmployeeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Employeewwds_5_tfemployeeemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Employeewwds_4_tfemployeeemail)) ) )
         {
            AddWhere(sWhereString, "(EmployeeEmail like :lV66Employeewwds_4_tfemployeeemail)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Employeewwds_5_tfemployeeemail_sel)) && ! ( StringUtil.StrCmp(AV67Employeewwds_5_tfemployeeemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmployeeEmail = ( :AV67Employeewwds_5_tfemployeeemail_sel))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV67Employeewwds_5_tfemployeeemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from EmployeeEmail))=0))");
         }
         if ( AV68Employeewwds_6_tfemployeeismanager_sel == 1 )
         {
            AddWhere(sWhereString, "(EmployeeIsManager = TRUE)");
         }
         if ( AV68Employeewwds_6_tfemployeeismanager_sel == 2 )
         {
            AddWhere(sWhereString, "(EmployeeIsManager = FALSE)");
         }
         if ( AV69Employeewwds_7_tfemployeeisactive_sel == 1 )
         {
            AddWhere(sWhereString, "(EmployeeIsActive = TRUE)");
         }
         if ( AV69Employeewwds_7_tfemployeeisactive_sel == 2 )
         {
            AddWhere(sWhereString, "(EmployeeIsActive = FALSE)");
         }
         if ( new userhasrole(context).executeUdp(  "Manager") && ! new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "(CompanyId = :AV70Udparg8)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( new userhasrole(context).executeUdp(  "Project Manager") )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV58EmployeeIds, "EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY EmployeeFirstName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY EmployeeName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmployeeName DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY EmployeeEmail";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmployeeEmail DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY EmployeeIsManager";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmployeeIsManager DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY EmployeeIsActive";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmployeeIsActive DESC";
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
                     return conditional_P006T2(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (bool)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] );
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
          Object[] prmP006T2;
          prmP006T2 = new Object[] {
          new ParDef("lV63Employeewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Employeewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Employeewwds_2_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV65Employeewwds_3_tfemployeename_sel",GXType.Char,100,0) ,
          new ParDef("lV66Employeewwds_4_tfemployeeemail",GXType.VarChar,100,0) ,
          new ParDef("AV67Employeewwds_5_tfemployeeemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV70Udparg8",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006T2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
       }
    }

 }

}
