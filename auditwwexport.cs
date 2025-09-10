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
   public class auditwwexport : GXProcedure
   {
      public auditwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public auditwwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV12ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
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
         AV13CellRow = 1;
         AV14FirstColumn = 1;
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
         AV15Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV11Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV11Filename = GXt_char1 + "AuditWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
         AV10ExcelDocument.Open(AV11Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Main filter") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV18FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( ! ( (0==AV34TFAuditId) && (0==AV35TFAuditId_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Id") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFAuditId;
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "To") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFAuditId_To;
         }
         if ( ! ( (DateTime.MinValue==AV36TFAuditDate) && (DateTime.MinValue==AV37TFAuditDate_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Date") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV36TFAuditDate ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "To") ;
            AV13CellRow = GXt_int2;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV37TFAuditDate_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFAuditTableName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Table Name") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV39TFAuditTableName_Sel)) ? "(Empty)" : AV39TFAuditTableName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFAuditTableName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Table Name") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV38TFAuditTableName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFAuditDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Description") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV41TFAuditDescription_Sel)) ? "(Empty)" : AV41TFAuditDescription_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFAuditDescription)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Description") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV40TFAuditDescription, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFAuditShortDescription_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Short Description") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV43TFAuditShortDescription_Sel)) ? "(Empty)" : AV43TFAuditShortDescription_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFAuditShortDescription)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Short Description") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV42TFAuditShortDescription, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFAuditAction_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Action") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV45TFAuditAction_Sel)) ? "(Empty)" : AV45TFAuditAction_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFAuditAction)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Action") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV44TFAuditAction, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV46TFSecUserId) && (0==AV47TFSecUserId_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "User Id") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV46TFSecUserId;
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "To") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV47TFSecUserId_To;
         }
         if ( ! ( (0==AV48TFEmployeeId) && (0==AV49TFEmployeeId_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Id") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV48TFEmployeeId;
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "To") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV49TFEmployeeId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFEmployeeName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Name") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV51TFEmployeeName_Sel)) ? "(Empty)" : AV51TFEmployeeName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFEmployeeName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new WorkWithPlus.workwithplus_web.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Name") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  AV50TFEmployeeName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV31VisibleColumnCount = 0;
         if ( StringUtil.StrCmp(AV19Session.Get("AuditWWColumnsSelector"), "") != 0 )
         {
            AV26ColumnsSelectorXML = AV19Session.Get("AuditWWColumnsSelector");
            AV23ColumnsSelector.FromXml(AV26ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S151 ();
            if (returnInSub) return;
         }
         AV23ColumnsSelector.gxTpr_Columns.Sort("Order");
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV23ColumnsSelector.gxTpr_Columns.Count )
         {
            AV25ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV23ColumnsSelector.gxTpr_Columns.Item(AV53GXV1));
            if ( AV25ColumnsSelector_Column.gxTpr_Isvisible )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Text = context.GetMessage( (String.IsNullOrEmpty(StringUtil.RTrim( AV25ColumnsSelector_Column.gxTpr_Displayname)) ? AV25ColumnsSelector_Column.gxTpr_Columnname : AV25ColumnsSelector_Column.gxTpr_Displayname), "");
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Bold = 1;
               AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Color = 11;
               AV31VisibleColumnCount = (long)(AV31VisibleColumnCount+1);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
      }

      protected void S161( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV55Auditwwds_1_filterfulltext = AV18FilterFullText;
         AV56Auditwwds_2_tfauditid = AV34TFAuditId;
         AV57Auditwwds_3_tfauditid_to = AV35TFAuditId_To;
         AV58Auditwwds_4_tfauditdate = AV36TFAuditDate;
         AV59Auditwwds_5_tfauditdate_to = AV37TFAuditDate_To;
         AV60Auditwwds_6_tfaudittablename = AV38TFAuditTableName;
         AV61Auditwwds_7_tfaudittablename_sel = AV39TFAuditTableName_Sel;
         AV62Auditwwds_8_tfauditdescription = AV40TFAuditDescription;
         AV63Auditwwds_9_tfauditdescription_sel = AV41TFAuditDescription_Sel;
         AV64Auditwwds_10_tfauditshortdescription = AV42TFAuditShortDescription;
         AV65Auditwwds_11_tfauditshortdescription_sel = AV43TFAuditShortDescription_Sel;
         AV66Auditwwds_12_tfauditaction = AV44TFAuditAction;
         AV67Auditwwds_13_tfauditaction_sel = AV45TFAuditAction_Sel;
         AV68Auditwwds_14_tfsecuserid = AV46TFSecUserId;
         AV69Auditwwds_15_tfsecuserid_to = AV47TFSecUserId_To;
         AV70Auditwwds_16_tfemployeeid = AV48TFEmployeeId;
         AV71Auditwwds_17_tfemployeeid_to = AV49TFEmployeeId_To;
         AV72Auditwwds_18_tfemployeename = AV50TFEmployeeName;
         AV73Auditwwds_19_tfemployeename_sel = AV51TFEmployeeName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Auditwwds_1_filterfulltext ,
                                              AV56Auditwwds_2_tfauditid ,
                                              AV57Auditwwds_3_tfauditid_to ,
                                              AV58Auditwwds_4_tfauditdate ,
                                              AV59Auditwwds_5_tfauditdate_to ,
                                              AV61Auditwwds_7_tfaudittablename_sel ,
                                              AV60Auditwwds_6_tfaudittablename ,
                                              AV63Auditwwds_9_tfauditdescription_sel ,
                                              AV62Auditwwds_8_tfauditdescription ,
                                              AV65Auditwwds_11_tfauditshortdescription_sel ,
                                              AV64Auditwwds_10_tfauditshortdescription ,
                                              AV67Auditwwds_13_tfauditaction_sel ,
                                              AV66Auditwwds_12_tfauditaction ,
                                              AV68Auditwwds_14_tfsecuserid ,
                                              AV69Auditwwds_15_tfsecuserid_to ,
                                              AV70Auditwwds_16_tfemployeeid ,
                                              AV71Auditwwds_17_tfemployeeid_to ,
                                              AV73Auditwwds_19_tfemployeename_sel ,
                                              AV72Auditwwds_18_tfemployeename ,
                                              A204AuditId ,
                                              A206AuditTableName ,
                                              A207AuditDescription ,
                                              A208AuditShortDescription ,
                                              A209AuditAction ,
                                              A210SecUserId ,
                                              A106EmployeeId ,
                                              A148EmployeeName ,
                                              A205AuditDate ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Auditwwds_1_filterfulltext), "%", "");
         lV55Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Auditwwds_1_filterfulltext), "%", "");
         lV55Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Auditwwds_1_filterfulltext), "%", "");
         lV55Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Auditwwds_1_filterfulltext), "%", "");
         lV55Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Auditwwds_1_filterfulltext), "%", "");
         lV55Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Auditwwds_1_filterfulltext), "%", "");
         lV55Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Auditwwds_1_filterfulltext), "%", "");
         lV55Auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Auditwwds_1_filterfulltext), "%", "");
         lV60Auditwwds_6_tfaudittablename = StringUtil.PadR( StringUtil.RTrim( AV60Auditwwds_6_tfaudittablename), 100, "%");
         lV62Auditwwds_8_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV62Auditwwds_8_tfauditdescription), "%", "");
         lV64Auditwwds_10_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV64Auditwwds_10_tfauditshortdescription), "%", "");
         lV66Auditwwds_12_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV66Auditwwds_12_tfauditaction), "%", "");
         lV72Auditwwds_18_tfemployeename = StringUtil.PadR( StringUtil.RTrim( AV72Auditwwds_18_tfemployeename), 100, "%");
         /* Using cursor P00BV2 */
         pr_default.execute(0, new Object[] {lV55Auditwwds_1_filterfulltext, lV55Auditwwds_1_filterfulltext, lV55Auditwwds_1_filterfulltext, lV55Auditwwds_1_filterfulltext, lV55Auditwwds_1_filterfulltext, lV55Auditwwds_1_filterfulltext, lV55Auditwwds_1_filterfulltext, lV55Auditwwds_1_filterfulltext, AV56Auditwwds_2_tfauditid, AV57Auditwwds_3_tfauditid_to, AV58Auditwwds_4_tfauditdate, AV59Auditwwds_5_tfauditdate_to, lV60Auditwwds_6_tfaudittablename, AV61Auditwwds_7_tfaudittablename_sel, lV62Auditwwds_8_tfauditdescription, AV63Auditwwds_9_tfauditdescription_sel, lV64Auditwwds_10_tfauditshortdescription, AV65Auditwwds_11_tfauditshortdescription_sel, lV66Auditwwds_12_tfauditaction, AV67Auditwwds_13_tfauditaction_sel, AV68Auditwwds_14_tfsecuserid, AV69Auditwwds_15_tfsecuserid_to, AV70Auditwwds_16_tfemployeeid, AV71Auditwwds_17_tfemployeeid_to, lV72Auditwwds_18_tfemployeename, AV73Auditwwds_19_tfemployeename_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A148EmployeeName = P00BV2_A148EmployeeName[0];
            A106EmployeeId = P00BV2_A106EmployeeId[0];
            A210SecUserId = P00BV2_A210SecUserId[0];
            A209AuditAction = P00BV2_A209AuditAction[0];
            A208AuditShortDescription = P00BV2_A208AuditShortDescription[0];
            A207AuditDescription = P00BV2_A207AuditDescription[0];
            A206AuditTableName = P00BV2_A206AuditTableName[0];
            A205AuditDate = P00BV2_A205AuditDate[0];
            A204AuditId = P00BV2_A204AuditId[0];
            A148EmployeeName = P00BV2_A148EmployeeName[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV31VisibleColumnCount = 0;
            AV74GXV2 = 1;
            while ( AV74GXV2 <= AV23ColumnsSelector.gxTpr_Columns.Count )
            {
               AV25ColumnsSelector_Column = ((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV23ColumnsSelector.gxTpr_Columns.Item(AV74GXV2));
               if ( AV25ColumnsSelector_Column.gxTpr_Isvisible )
               {
                  if ( StringUtil.StrCmp(AV25ColumnsSelector_Column.gxTpr_Columnname, "AuditId") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Number = A204AuditId;
                  }
                  else if ( StringUtil.StrCmp(AV25ColumnsSelector_Column.gxTpr_Columnname, "AuditDate") == 0 )
                  {
                     GXt_dtime3 = DateTimeUtil.ResetTime( A205AuditDate ) ;
                     AV10ExcelDocument.SetDateFormat(context, 8, 5, 1, 3, "/", ":", " ");
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Date = GXt_dtime3;
                  }
                  else if ( StringUtil.StrCmp(AV25ColumnsSelector_Column.gxTpr_Columnname, "AuditTableName") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A206AuditTableName, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV25ColumnsSelector_Column.gxTpr_Columnname, "AuditDescription") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A207AuditDescription, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV25ColumnsSelector_Column.gxTpr_Columnname, "AuditShortDescription") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A208AuditShortDescription, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV25ColumnsSelector_Column.gxTpr_Columnname, "AuditAction") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A209AuditAction, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  else if ( StringUtil.StrCmp(AV25ColumnsSelector_Column.gxTpr_Columnname, "SecUserId") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Number = A210SecUserId;
                  }
                  else if ( StringUtil.StrCmp(AV25ColumnsSelector_Column.gxTpr_Columnname, "EmployeeId") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Number = A106EmployeeId;
                  }
                  else if ( StringUtil.StrCmp(AV25ColumnsSelector_Column.gxTpr_Columnname, "EmployeeName") == 0 )
                  {
                     GXt_char1 = "";
                     new WorkWithPlus.workwithplus_web.wwp_export_securetext(context ).execute(  A148EmployeeName, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, (int)(AV14FirstColumn+AV31VisibleColumnCount), 1, 1).Text = GXt_char1;
                  }
                  AV31VisibleColumnCount = (long)(AV31VisibleColumnCount+1);
               }
               AV74GXV2 = (int)(AV74GXV2+1);
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
         AV10ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Close();
         AV19Session.Set("WWPExportFilePath", AV11Filename);
         AV19Session.Set("WWPExportFileName", "AuditWWExport.xlsx");
         AV11Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV10ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV12ErrorMessage = AV10ExcelDocument.ErrDescription;
            AV10ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S151( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV23ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "AuditId",  "",  "Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "AuditDate",  "",  "Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "AuditTableName",  "",  "Table Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "AuditDescription",  "",  "Description",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "AuditShortDescription",  "",  "Short Description",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "AuditAction",  "",  "Action",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "SecUserId",  "",  "User Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "EmployeeId",  "",  "Id",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV23ColumnsSelector,  "EmployeeName",  "",  "Name",  true,  "") ;
         GXt_char1 = AV27UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "AuditWWColumnsSelector", out  GXt_char1) ;
         AV27UserCustomValue = GXt_char1;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV27UserCustomValue)) ) )
         {
            AV24ColumnsSelectorAux.FromXml(AV27UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV24ColumnsSelectorAux, ref  AV23ColumnsSelector) ;
         }
      }

      protected void S201( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV19Session.Get("AuditWWGridState"), "") == 0 )
         {
            AV21GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  "AuditWWGridState"), null, "", "");
         }
         else
         {
            AV21GridState.FromXml(AV19Session.Get("AuditWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV21GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV21GridState.gxTpr_Ordereddsc;
         AV75GXV3 = 1;
         while ( AV75GXV3 <= AV21GridState.gxTpr_Filtervalues.Count )
         {
            AV22GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV21GridState.gxTpr_Filtervalues.Item(AV75GXV3));
            if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFAUDITID") == 0 )
            {
               AV34TFAuditId = (long)(Math.Round(NumberUtil.Val( AV22GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV35TFAuditId_To = (long)(Math.Round(NumberUtil.Val( AV22GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFAUDITDATE") == 0 )
            {
               AV36TFAuditDate = context.localUtil.CToD( AV22GridStateFilterValue.gxTpr_Value, 2);
               AV37TFAuditDate_To = context.localUtil.CToD( AV22GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME") == 0 )
            {
               AV38TFAuditTableName = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME_SEL") == 0 )
            {
               AV39TFAuditTableName_Sel = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION") == 0 )
            {
               AV40TFAuditDescription = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION_SEL") == 0 )
            {
               AV41TFAuditDescription_Sel = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION") == 0 )
            {
               AV42TFAuditShortDescription = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION_SEL") == 0 )
            {
               AV43TFAuditShortDescription_Sel = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFAUDITACTION") == 0 )
            {
               AV44TFAuditAction = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFAUDITACTION_SEL") == 0 )
            {
               AV45TFAuditAction_Sel = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFSECUSERID") == 0 )
            {
               AV46TFSecUserId = (long)(Math.Round(NumberUtil.Val( AV22GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV47TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV22GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFEMPLOYEEID") == 0 )
            {
               AV48TFEmployeeId = (long)(Math.Round(NumberUtil.Val( AV22GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV49TFEmployeeId_To = (long)(Math.Round(NumberUtil.Val( AV22GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME") == 0 )
            {
               AV50TFEmployeeName = AV22GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV22GridStateFilterValue.gxTpr_Name, "TFEMPLOYEENAME_SEL") == 0 )
            {
               AV51TFEmployeeName_Sel = AV22GridStateFilterValue.gxTpr_Value;
            }
            AV75GXV3 = (int)(AV75GXV3+1);
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
         AV11Filename = "";
         AV12ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV18FilterFullText = "";
         AV36TFAuditDate = DateTime.MinValue;
         AV37TFAuditDate_To = DateTime.MinValue;
         AV39TFAuditTableName_Sel = "";
         AV38TFAuditTableName = "";
         AV41TFAuditDescription_Sel = "";
         AV40TFAuditDescription = "";
         AV43TFAuditShortDescription_Sel = "";
         AV42TFAuditShortDescription = "";
         AV45TFAuditAction_Sel = "";
         AV44TFAuditAction = "";
         AV51TFEmployeeName_Sel = "";
         AV50TFEmployeeName = "";
         AV19Session = context.GetSession();
         AV26ColumnsSelectorXML = "";
         AV23ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV25ColumnsSelector_Column = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column(context);
         AV55Auditwwds_1_filterfulltext = "";
         AV58Auditwwds_4_tfauditdate = DateTime.MinValue;
         AV59Auditwwds_5_tfauditdate_to = DateTime.MinValue;
         AV60Auditwwds_6_tfaudittablename = "";
         AV61Auditwwds_7_tfaudittablename_sel = "";
         AV62Auditwwds_8_tfauditdescription = "";
         AV63Auditwwds_9_tfauditdescription_sel = "";
         AV64Auditwwds_10_tfauditshortdescription = "";
         AV65Auditwwds_11_tfauditshortdescription_sel = "";
         AV66Auditwwds_12_tfauditaction = "";
         AV67Auditwwds_13_tfauditaction_sel = "";
         AV72Auditwwds_18_tfemployeename = "";
         AV73Auditwwds_19_tfemployeename_sel = "";
         lV55Auditwwds_1_filterfulltext = "";
         lV60Auditwwds_6_tfaudittablename = "";
         lV62Auditwwds_8_tfauditdescription = "";
         lV64Auditwwds_10_tfauditshortdescription = "";
         lV66Auditwwds_12_tfauditaction = "";
         lV72Auditwwds_18_tfemployeename = "";
         A206AuditTableName = "";
         A207AuditDescription = "";
         A208AuditShortDescription = "";
         A209AuditAction = "";
         A148EmployeeName = "";
         A205AuditDate = DateTime.MinValue;
         P00BV2_A148EmployeeName = new string[] {""} ;
         P00BV2_A106EmployeeId = new long[1] ;
         P00BV2_A210SecUserId = new long[1] ;
         P00BV2_A209AuditAction = new string[] {""} ;
         P00BV2_A208AuditShortDescription = new string[] {""} ;
         P00BV2_A207AuditDescription = new string[] {""} ;
         P00BV2_A206AuditTableName = new string[] {""} ;
         P00BV2_A205AuditDate = new DateTime[] {DateTime.MinValue} ;
         P00BV2_A204AuditId = new long[1] ;
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV27UserCustomValue = "";
         GXt_char1 = "";
         AV24ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV21GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV22GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.auditwwexport__default(),
            new Object[][] {
                new Object[] {
               P00BV2_A148EmployeeName, P00BV2_A106EmployeeId, P00BV2_A210SecUserId, P00BV2_A209AuditAction, P00BV2_A208AuditShortDescription, P00BV2_A207AuditDescription, P00BV2_A206AuditTableName, P00BV2_A205AuditDate, P00BV2_A204AuditId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV53GXV1 ;
      private int AV74GXV2 ;
      private int AV75GXV3 ;
      private long AV34TFAuditId ;
      private long AV35TFAuditId_To ;
      private long AV46TFSecUserId ;
      private long AV47TFSecUserId_To ;
      private long AV48TFEmployeeId ;
      private long AV49TFEmployeeId_To ;
      private long AV31VisibleColumnCount ;
      private long AV56Auditwwds_2_tfauditid ;
      private long AV57Auditwwds_3_tfauditid_to ;
      private long AV68Auditwwds_14_tfsecuserid ;
      private long AV69Auditwwds_15_tfsecuserid_to ;
      private long AV70Auditwwds_16_tfemployeeid ;
      private long AV71Auditwwds_17_tfemployeeid_to ;
      private long A204AuditId ;
      private long A210SecUserId ;
      private long A106EmployeeId ;
      private string AV39TFAuditTableName_Sel ;
      private string AV38TFAuditTableName ;
      private string AV51TFEmployeeName_Sel ;
      private string AV50TFEmployeeName ;
      private string AV60Auditwwds_6_tfaudittablename ;
      private string AV61Auditwwds_7_tfaudittablename_sel ;
      private string AV72Auditwwds_18_tfemployeename ;
      private string AV73Auditwwds_19_tfemployeename_sel ;
      private string lV60Auditwwds_6_tfaudittablename ;
      private string lV72Auditwwds_18_tfemployeename ;
      private string A206AuditTableName ;
      private string A148EmployeeName ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV36TFAuditDate ;
      private DateTime AV37TFAuditDate_To ;
      private DateTime AV58Auditwwds_4_tfauditdate ;
      private DateTime AV59Auditwwds_5_tfauditdate_to ;
      private DateTime A205AuditDate ;
      private bool returnInSub ;
      private bool AV17OrderedDsc ;
      private string AV26ColumnsSelectorXML ;
      private string AV27UserCustomValue ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV41TFAuditDescription_Sel ;
      private string AV40TFAuditDescription ;
      private string AV43TFAuditShortDescription_Sel ;
      private string AV42TFAuditShortDescription ;
      private string AV45TFAuditAction_Sel ;
      private string AV44TFAuditAction ;
      private string AV55Auditwwds_1_filterfulltext ;
      private string AV62Auditwwds_8_tfauditdescription ;
      private string AV63Auditwwds_9_tfauditdescription_sel ;
      private string AV64Auditwwds_10_tfauditshortdescription ;
      private string AV65Auditwwds_11_tfauditshortdescription_sel ;
      private string AV66Auditwwds_12_tfauditaction ;
      private string AV67Auditwwds_13_tfauditaction_sel ;
      private string lV55Auditwwds_1_filterfulltext ;
      private string lV62Auditwwds_8_tfauditdescription ;
      private string lV64Auditwwds_10_tfauditshortdescription ;
      private string lV66Auditwwds_12_tfauditaction ;
      private string A207AuditDescription ;
      private string A208AuditShortDescription ;
      private string A209AuditAction ;
      private IGxSession AV19Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV23ColumnsSelector ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column AV25ColumnsSelector_Column ;
      private IDataStoreProvider pr_default ;
      private string[] P00BV2_A148EmployeeName ;
      private long[] P00BV2_A106EmployeeId ;
      private long[] P00BV2_A210SecUserId ;
      private string[] P00BV2_A209AuditAction ;
      private string[] P00BV2_A208AuditShortDescription ;
      private string[] P00BV2_A207AuditDescription ;
      private string[] P00BV2_A206AuditTableName ;
      private DateTime[] P00BV2_A205AuditDate ;
      private long[] P00BV2_A204AuditId ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelectorAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV21GridState ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV22GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class auditwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BV2( IGxContext context ,
                                             string AV55Auditwwds_1_filterfulltext ,
                                             long AV56Auditwwds_2_tfauditid ,
                                             long AV57Auditwwds_3_tfauditid_to ,
                                             DateTime AV58Auditwwds_4_tfauditdate ,
                                             DateTime AV59Auditwwds_5_tfauditdate_to ,
                                             string AV61Auditwwds_7_tfaudittablename_sel ,
                                             string AV60Auditwwds_6_tfaudittablename ,
                                             string AV63Auditwwds_9_tfauditdescription_sel ,
                                             string AV62Auditwwds_8_tfauditdescription ,
                                             string AV65Auditwwds_11_tfauditshortdescription_sel ,
                                             string AV64Auditwwds_10_tfauditshortdescription ,
                                             string AV67Auditwwds_13_tfauditaction_sel ,
                                             string AV66Auditwwds_12_tfauditaction ,
                                             long AV68Auditwwds_14_tfsecuserid ,
                                             long AV69Auditwwds_15_tfsecuserid_to ,
                                             long AV70Auditwwds_16_tfemployeeid ,
                                             long AV71Auditwwds_17_tfemployeeid_to ,
                                             string AV73Auditwwds_19_tfemployeename_sel ,
                                             string AV72Auditwwds_18_tfemployeename ,
                                             long A204AuditId ,
                                             string A206AuditTableName ,
                                             string A207AuditDescription ,
                                             string A208AuditShortDescription ,
                                             string A209AuditAction ,
                                             long A210SecUserId ,
                                             long A106EmployeeId ,
                                             string A148EmployeeName ,
                                             DateTime A205AuditDate ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[26];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.EmployeeName, T1.EmployeeId, T1.SecUserId, T1.AuditAction, T1.AuditShortDescription, T1.AuditDescription, T1.AuditTableName, T1.AuditDate, T1.AuditId FROM (Audit T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.AuditId,'9999999999'), 2) like '%' || :lV55Auditwwds_1_filterfulltext) or ( LOWER(T1.AuditTableName) like '%' || LOWER(:lV55Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditDescription) like '%' || LOWER(:lV55Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditShortDescription) like '%' || LOWER(:lV55Auditwwds_1_filterfulltext)) or ( LOWER(T1.AuditAction) like '%' || LOWER(:lV55Auditwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.SecUserId,'9999999999'), 2) like '%' || :lV55Auditwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.EmployeeId,'9999999999'), 2) like '%' || :lV55Auditwwds_1_filterfulltext) or ( LOWER(T2.EmployeeName) like '%' || LOWER(:lV55Auditwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV56Auditwwds_2_tfauditid) )
         {
            AddWhere(sWhereString, "(T1.AuditId >= :AV56Auditwwds_2_tfauditid)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV57Auditwwds_3_tfauditid_to) )
         {
            AddWhere(sWhereString, "(T1.AuditId <= :AV57Auditwwds_3_tfauditid_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Auditwwds_4_tfauditdate) )
         {
            AddWhere(sWhereString, "(T1.AuditDate >= :AV58Auditwwds_4_tfauditdate)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Auditwwds_5_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(T1.AuditDate <= :AV59Auditwwds_5_tfauditdate_to)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_7_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Auditwwds_6_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName like :lV60Auditwwds_6_tfaudittablename)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Auditwwds_7_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV61Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditTableName = ( :AV61Auditwwds_7_tfaudittablename_sel))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV61Auditwwds_7_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_9_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Auditwwds_8_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription like :lV62Auditwwds_8_tfauditdescription)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Auditwwds_9_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV63Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditDescription = ( :AV63Auditwwds_9_tfauditdescription_sel))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( StringUtil.StrCmp(AV63Auditwwds_9_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_11_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Auditwwds_10_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription like :lV64Auditwwds_10_tfauditshortdescription)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Auditwwds_11_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV65Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditShortDescription = ( :AV65Auditwwds_11_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( StringUtil.StrCmp(AV65Auditwwds_11_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Auditwwds_13_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Auditwwds_12_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction like :lV66Auditwwds_12_tfauditaction)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Auditwwds_13_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV67Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AuditAction = ( :AV67Auditwwds_13_tfauditaction_sel))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( StringUtil.StrCmp(AV67Auditwwds_13_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.AuditAction))=0))");
         }
         if ( ! (0==AV68Auditwwds_14_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.SecUserId >= :AV68Auditwwds_14_tfsecuserid)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (0==AV69Auditwwds_15_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserId <= :AV69Auditwwds_15_tfsecuserid_to)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (0==AV70Auditwwds_16_tfemployeeid) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId >= :AV70Auditwwds_16_tfemployeeid)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (0==AV71Auditwwds_17_tfemployeeid_to) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId <= :AV71Auditwwds_17_tfemployeeid_to)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Auditwwds_19_tfemployeename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Auditwwds_18_tfemployeename)) ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName like :lV72Auditwwds_18_tfemployeename)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Auditwwds_19_tfemployeename_sel)) && ! ( StringUtil.StrCmp(AV73Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.EmployeeName = ( :AV73Auditwwds_19_tfemployeename_sel))");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( StringUtil.StrCmp(AV73Auditwwds_19_tfemployeename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.EmployeeName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AuditDate";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AuditDate DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AuditId";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AuditId DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AuditTableName";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AuditTableName DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AuditDescription";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AuditDescription DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AuditShortDescription";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AuditShortDescription DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AuditAction";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AuditAction DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecUserId";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecUserId DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.EmployeeId";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.EmployeeId DESC";
         }
         else if ( ( AV16OrderedBy == 9 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.EmployeeName";
         }
         else if ( ( AV16OrderedBy == 9 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.EmployeeName DESC";
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
                     return conditional_P00BV2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] );
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
          Object[] prmP00BV2;
          prmP00BV2 = new Object[] {
          new ParDef("lV55Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV56Auditwwds_2_tfauditid",GXType.Int64,10,0) ,
          new ParDef("AV57Auditwwds_3_tfauditid_to",GXType.Int64,10,0) ,
          new ParDef("AV58Auditwwds_4_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV59Auditwwds_5_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("lV60Auditwwds_6_tfaudittablename",GXType.Char,100,0) ,
          new ParDef("AV61Auditwwds_7_tfaudittablename_sel",GXType.Char,100,0) ,
          new ParDef("lV62Auditwwds_8_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV63Auditwwds_9_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV64Auditwwds_10_tfauditshortdescription",GXType.VarChar,200,0) ,
          new ParDef("AV65Auditwwds_11_tfauditshortdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV66Auditwwds_12_tfauditaction",GXType.VarChar,10,0) ,
          new ParDef("AV67Auditwwds_13_tfauditaction_sel",GXType.VarChar,10,0) ,
          new ParDef("AV68Auditwwds_14_tfsecuserid",GXType.Int64,10,0) ,
          new ParDef("AV69Auditwwds_15_tfsecuserid_to",GXType.Int64,10,0) ,
          new ParDef("AV70Auditwwds_16_tfemployeeid",GXType.Int64,10,0) ,
          new ParDef("AV71Auditwwds_17_tfemployeeid_to",GXType.Int64,10,0) ,
          new ParDef("lV72Auditwwds_18_tfemployeename",GXType.Char,100,0) ,
          new ParDef("AV73Auditwwds_19_tfemployeename_sel",GXType.Char,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BV2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BV2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
