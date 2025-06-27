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
   public class aemployeeleavedetailsexport : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aemployeeleavedetailsexport().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      public aemployeeleavedetailsexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aemployeeleavedetailsexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP1_EmployeeIds ,
                           ref DateTime aP2_Date ,
                           ref GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP3_SDTEmployeeLeaveDetailsCollection ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV20CompanyLocationId = aP0_CompanyLocationId;
         this.AV28EmployeeIds = aP1_EmployeeIds;
         this.AV26Date = aP2_Date;
         this.AV29SDTEmployeeLeaveDetailsCollection = aP3_SDTEmployeeLeaveDetailsCollection;
         this.AV10Filename = "" ;
         this.AV21ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeIds=this.AV28EmployeeIds;
         aP2_Date=this.AV26Date;
         aP3_SDTEmployeeLeaveDetailsCollection=this.AV29SDTEmployeeLeaveDetailsCollection;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV21ErrorMessage;
      }

      public string executeUdp( long aP0_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP1_EmployeeIds ,
                                ref DateTime aP2_Date ,
                                ref GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP3_SDTEmployeeLeaveDetailsCollection ,
                                out string aP4_Filename )
      {
         execute(aP0_CompanyLocationId, ref aP1_EmployeeIds, ref aP2_Date, ref aP3_SDTEmployeeLeaveDetailsCollection, out aP4_Filename, out aP5_ErrorMessage);
         return AV21ErrorMessage ;
      }

      public void executeSubmit( long aP0_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP1_EmployeeIds ,
                                 ref DateTime aP2_Date ,
                                 ref GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP3_SDTEmployeeLeaveDetailsCollection ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         this.AV20CompanyLocationId = aP0_CompanyLocationId;
         this.AV28EmployeeIds = aP1_EmployeeIds;
         this.AV26Date = aP2_Date;
         this.AV29SDTEmployeeLeaveDetailsCollection = aP3_SDTEmployeeLeaveDetailsCollection;
         this.AV10Filename = "" ;
         this.AV21ErrorMessage = "" ;
         SubmitImpl();
         aP1_EmployeeIds=this.AV28EmployeeIds;
         aP2_Date=this.AV26Date;
         aP3_SDTEmployeeLeaveDetailsCollection=this.AV29SDTEmployeeLeaveDetailsCollection;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV21ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV8LeaveTypeNames.Add("Employee Name", 0);
         AV8LeaveTypeNames.Add("Leave Date", 0);
         AV33LeaveTypeIdCollection.Add(0, 0);
         AV33LeaveTypeIdCollection.Add(0, 0);
         /* Using cursor P00AV2 */
         pr_default.execute(0, new Object[] {AV20CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P00AV2_A100CompanyId[0];
            A157CompanyLocationId = P00AV2_A157CompanyLocationId[0];
            A101CompanyName = P00AV2_A101CompanyName[0];
            A124LeaveTypeId = P00AV2_A124LeaveTypeId[0];
            A125LeaveTypeName = P00AV2_A125LeaveTypeName[0];
            A157CompanyLocationId = P00AV2_A157CompanyLocationId[0];
            A101CompanyName = P00AV2_A101CompanyName[0];
            AV22CompanyName = StringUtil.Trim( A101CompanyName);
            AV8LeaveTypeNames.Add(StringUtil.Trim( A125LeaveTypeName), 0);
            AV33LeaveTypeIdCollection.Add(A124LeaveTypeId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8LeaveTypeNames.Add("Vacation Days Left", 0);
         AV33LeaveTypeIdCollection.Add(0, 0);
         AV25excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV25excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV25excelCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV18ExcelCellRange = AV19excelSpreadsheet.cell(1, 1);
         GXt_char1 = "";
         new formatdatetime(context ).execute(  AV26Date,  "YYYY", out  GXt_char1) ;
         AV18ExcelCellRange.gxTpr_Valuetext = "Leave Overview "+GXt_char1+" For "+AV22CompanyName;
         AV18ExcelCellRange.setcellstyle( AV25excelCellStyle);
         AV12col = 1;
         AV35GXV1 = 1;
         while ( AV35GXV1 <= AV8LeaveTypeNames.Count )
         {
            AV15Name = AV8LeaveTypeNames.GetString(AV35GXV1);
            AV18ExcelCellRange = AV19excelSpreadsheet.cell(3, AV12col);
            AV18ExcelCellRange.gxTpr_Valuetext = AV15Name;
            AV18ExcelCellRange.setcellstyle( AV25excelCellStyle);
            AV12col = (short)(AV12col+1);
            AV35GXV1 = (int)(AV35GXV1+1);
         }
         AV13row = 4;
         AV36GXV2 = 1;
         while ( AV36GXV2 <= AV29SDTEmployeeLeaveDetailsCollection.Count )
         {
            AV30SDTEmployeeLeaveDetails = ((SdtSDTEmployeeLeaveDetails)AV29SDTEmployeeLeaveDetailsCollection.Item(AV36GXV2));
            AV18ExcelCellRange = AV19excelSpreadsheet.cell(AV13row, 1);
            AV18ExcelCellRange.gxTpr_Valuetext = AV30SDTEmployeeLeaveDetails.gxTpr_Employeename;
            AV18ExcelCellRange = AV19excelSpreadsheet.cell(AV13row, 2);
            AV18ExcelCellRange.gxTpr_Valuetext = AV30SDTEmployeeLeaveDetails.gxTpr_Firstleaverequeststartdatestring;
            AV18ExcelCellRange = AV19excelSpreadsheet.cell(AV13row, AV33LeaveTypeIdCollection.IndexOf(AV30SDTEmployeeLeaveDetails.gxTpr_Firstleavetypeid));
            AV18ExcelCellRange.gxTpr_Valuenumber = AV30SDTEmployeeLeaveDetails.gxTpr_Firstleaverequestduration;
            AV18ExcelCellRange = AV19excelSpreadsheet.cell(AV13row, AV33LeaveTypeIdCollection.Count);
            AV18ExcelCellRange.gxTpr_Valuenumber = AV30SDTEmployeeLeaveDetails.gxTpr_Employeebalance;
            AV13row = (short)(AV13row+1);
            AV37GXV3 = 1;
            while ( AV37GXV3 <= AV30SDTEmployeeLeaveDetails.gxTpr_Leaverequest.Count )
            {
               AV31SDTLeaveRequestItem = ((SdtSDTEmployeeLeaveDetails_LeaveRequestItem)AV30SDTEmployeeLeaveDetails.gxTpr_Leaverequest.Item(AV37GXV3));
               AV18ExcelCellRange = AV19excelSpreadsheet.cell(AV13row, 2);
               AV18ExcelCellRange.gxTpr_Valuetext = AV31SDTLeaveRequestItem.gxTpr_Leaverequeststartdatestring;
               AV18ExcelCellRange = AV19excelSpreadsheet.cell(AV13row, AV33LeaveTypeIdCollection.IndexOf(AV31SDTLeaveRequestItem.gxTpr_Leavetypeid));
               AV18ExcelCellRange.gxTpr_Valuenumber = AV31SDTLeaveRequestItem.gxTpr_Leaverequestduration;
               AV13row = (short)(AV13row+1);
               AV37GXV3 = (int)(AV37GXV3+1);
            }
            AV36GXV2 = (int)(AV36GXV2+1);
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S121 ();
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
         AV10Filename = "LeaveReport-" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( Gx_date)), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( Gx_date)), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( Gx_date)), 10, 0)) + ".xlsx";
         AV19excelSpreadsheet.open( AV10Filename);
         AV27File.Source = AV10Filename;
         AV27File.Delete();
         AV19excelSpreadsheet.open( AV10Filename);
      }

      protected void S121( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV19excelSpreadsheet.gxTpr_Autofit = true;
         AV24boolean = AV19excelSpreadsheet.save();
         if ( AV24boolean )
         {
            AV19excelSpreadsheet.close();
         }
         else
         {
            GX_msglist.addItem("Error code:"+StringUtil.Str( (decimal)(AV19excelSpreadsheet.gxTpr_Errcode), 8, 0));
            GX_msglist.addItem("Error description:"+AV19excelSpreadsheet.gxTpr_Errdescription);
         }
         AV11Session.Set("WWPExportFilePath", AV10Filename);
         AV11Session.Set("WWPExportFileName", AV10Filename);
         AV10Filename = formatLink("wwpbaseobjects.wwp_downloadreport.aspx") ;
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
         AV10Filename = "";
         AV21ErrorMessage = "";
         AV8LeaveTypeNames = new GxSimpleCollection<string>();
         AV33LeaveTypeIdCollection = new GxSimpleCollection<long>();
         P00AV2_A100CompanyId = new long[1] ;
         P00AV2_A157CompanyLocationId = new long[1] ;
         P00AV2_A101CompanyName = new string[] {""} ;
         P00AV2_A124LeaveTypeId = new long[1] ;
         P00AV2_A125LeaveTypeName = new string[] {""} ;
         A101CompanyName = "";
         A125LeaveTypeName = "";
         AV22CompanyName = "";
         AV25excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV18ExcelCellRange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV19excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         GXt_char1 = "";
         AV15Name = "";
         AV30SDTEmployeeLeaveDetails = new SdtSDTEmployeeLeaveDetails(context);
         AV31SDTLeaveRequestItem = new SdtSDTEmployeeLeaveDetails_LeaveRequestItem(context);
         Gx_date = DateTime.MinValue;
         AV27File = new GxFile(context.GetPhysicalPath());
         AV11Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemployeeleavedetailsexport__default(),
            new Object[][] {
                new Object[] {
               P00AV2_A100CompanyId, P00AV2_A157CompanyLocationId, P00AV2_A101CompanyName, P00AV2_A124LeaveTypeId, P00AV2_A125LeaveTypeName
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV12col ;
      private short AV13row ;
      private int AV35GXV1 ;
      private int AV36GXV2 ;
      private int AV37GXV3 ;
      private long AV20CompanyLocationId ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A124LeaveTypeId ;
      private string AV10Filename ;
      private string A101CompanyName ;
      private string A125LeaveTypeName ;
      private string AV22CompanyName ;
      private string GXt_char1 ;
      private string AV15Name ;
      private DateTime AV26Date ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool AV24boolean ;
      private string AV21ErrorMessage ;
      private IGxSession AV11Session ;
      private GxFile AV27File ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV28EmployeeIds ;
      private GxSimpleCollection<long> aP1_EmployeeIds ;
      private DateTime aP2_Date ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> AV29SDTEmployeeLeaveDetailsCollection ;
      private GXBaseCollection<SdtSDTEmployeeLeaveDetails> aP3_SDTEmployeeLeaveDetailsCollection ;
      private GxSimpleCollection<string> AV8LeaveTypeNames ;
      private GxSimpleCollection<long> AV33LeaveTypeIdCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00AV2_A100CompanyId ;
      private long[] P00AV2_A157CompanyLocationId ;
      private string[] P00AV2_A101CompanyName ;
      private long[] P00AV2_A124LeaveTypeId ;
      private string[] P00AV2_A125LeaveTypeName ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV25excelCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV18ExcelCellRange ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV19excelSpreadsheet ;
      private SdtSDTEmployeeLeaveDetails AV30SDTEmployeeLeaveDetails ;
      private SdtSDTEmployeeLeaveDetails_LeaveRequestItem AV31SDTLeaveRequestItem ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
   }

   public class aemployeeleavedetailsexport__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00AV2;
          prmP00AV2 = new Object[] {
          new ParDef("AV20CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AV2", "SELECT T1.CompanyId, T2.CompanyLocationId, T2.CompanyName, T1.LeaveTypeId, T1.LeaveTypeName FROM (LeaveType T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T2.CompanyLocationId = :AV20CompanyLocationId ORDER BY T1.LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AV2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
