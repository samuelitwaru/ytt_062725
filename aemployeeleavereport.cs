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
   public class aemployeeleavereport : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aemployeeleavereport().MainImpl(args); ;
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

      public aemployeeleavereport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aemployeeleavereport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CompanyLocationId ,
                           ref GxSimpleCollection<long> aP1_EmployeeIds ,
                           ref DateTime aP2_Date ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV20CompanyLocationId = aP0_CompanyLocationId;
         this.AV28EmployeeIds = aP1_EmployeeIds;
         this.AV26Date = aP2_Date;
         this.AV10Filename = "" ;
         this.AV21ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeIds=this.AV28EmployeeIds;
         aP2_Date=this.AV26Date;
         aP3_Filename=this.AV10Filename;
         aP4_ErrorMessage=this.AV21ErrorMessage;
      }

      public string executeUdp( long aP0_CompanyLocationId ,
                                ref GxSimpleCollection<long> aP1_EmployeeIds ,
                                ref DateTime aP2_Date ,
                                out string aP3_Filename )
      {
         execute(aP0_CompanyLocationId, ref aP1_EmployeeIds, ref aP2_Date, out aP3_Filename, out aP4_ErrorMessage);
         return AV21ErrorMessage ;
      }

      public void executeSubmit( long aP0_CompanyLocationId ,
                                 ref GxSimpleCollection<long> aP1_EmployeeIds ,
                                 ref DateTime aP2_Date ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         this.AV20CompanyLocationId = aP0_CompanyLocationId;
         this.AV28EmployeeIds = aP1_EmployeeIds;
         this.AV26Date = aP2_Date;
         this.AV10Filename = "" ;
         this.AV21ErrorMessage = "" ;
         SubmitImpl();
         aP1_EmployeeIds=this.AV28EmployeeIds;
         aP2_Date=this.AV26Date;
         aP3_Filename=this.AV10Filename;
         aP4_ErrorMessage=this.AV21ErrorMessage;
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
         /* Using cursor P009X2 */
         pr_default.execute(0, new Object[] {AV20CompanyLocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P009X2_A100CompanyId[0];
            A157CompanyLocationId = P009X2_A157CompanyLocationId[0];
            A101CompanyName = P009X2_A101CompanyName[0];
            A125LeaveTypeName = P009X2_A125LeaveTypeName[0];
            A124LeaveTypeId = P009X2_A124LeaveTypeId[0];
            A157CompanyLocationId = P009X2_A157CompanyLocationId[0];
            A101CompanyName = P009X2_A101CompanyName[0];
            AV22CompanyName = StringUtil.Trim( A101CompanyName);
            AV8LeaveTypeNames.Add(StringUtil.Trim( A125LeaveTypeName), 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8LeaveTypeNames.Add("Vacation Days Left", 0);
         AV25excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV25excelCellStyle.gxTpr_Font.gxTpr_Bold = true;
         AV25excelCellStyle.gxTpr_Font.gxTpr_Color.setcolorrgb(25, 25, 112) ;
         AV18ExcelCellRange = AV19excelSpreadsheet.cell(1, 1);
         GXt_char1 = "";
         new formatdatetime(context ).execute(  AV26Date,  "YYYY", out  GXt_char1) ;
         AV18ExcelCellRange.gxTpr_Valuetext = "Leave Overview "+GXt_char1+" For "+AV22CompanyName;
         AV18ExcelCellRange.setcellstyle( AV25excelCellStyle);
         AV12col = 1;
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV8LeaveTypeNames.Count )
         {
            AV15Name = AV8LeaveTypeNames.GetString(AV30GXV1);
            AV18ExcelCellRange = AV19excelSpreadsheet.cell(3, AV12col);
            AV18ExcelCellRange.gxTpr_Valuetext = AV15Name;
            AV18ExcelCellRange.setcellstyle( AV25excelCellStyle);
            AV12col = (short)(AV12col+1);
            AV30GXV1 = (int)(AV30GXV1+1);
         }
         AV13row = 4;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A106EmployeeId ,
                                              AV28EmployeeIds ,
                                              AV28EmployeeIds.Count ,
                                              A157CompanyLocationId ,
                                              AV20CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P009X3 */
         pr_default.execute(1, new Object[] {AV20CompanyLocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P009X3_A100CompanyId[0];
            A157CompanyLocationId = P009X3_A157CompanyLocationId[0];
            A106EmployeeId = P009X3_A106EmployeeId[0];
            A148EmployeeName = P009X3_A148EmployeeName[0];
            A147EmployeeBalance = P009X3_A147EmployeeBalance[0];
            A157CompanyLocationId = P009X3_A157CompanyLocationId[0];
            AV18ExcelCellRange = AV19excelSpreadsheet.cell(AV13row, 1);
            AV18ExcelCellRange.gxTpr_Valuetext = StringUtil.Trim( A148EmployeeName);
            AV18ExcelCellRange = AV19excelSpreadsheet.cell(AV13row, AV8LeaveTypeNames.IndexOf("Vacation Days Left"));
            AV18ExcelCellRange.gxTpr_Valuenumber = A147EmployeeBalance;
            /* Using cursor P009X5 */
            pr_default.execute(2, new Object[] {A148EmployeeName, AV26Date, A100CompanyId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A124LeaveTypeId = P009X5_A124LeaveTypeId[0];
               A125LeaveTypeName = P009X5_A125LeaveTypeName[0];
               A40000GXC1 = P009X5_A40000GXC1[0];
               n40000GXC1 = P009X5_n40000GXC1[0];
               A40000GXC1 = P009X5_A40000GXC1[0];
               n40000GXC1 = P009X5_n40000GXC1[0];
               AV14count = (short)(Math.Round(A40000GXC1, 18, MidpointRounding.ToEven));
               if ( AV14count > 0 )
               {
                  AV17index = (short)(AV8LeaveTypeNames.IndexOf(StringUtil.Trim( A125LeaveTypeName)));
                  AV18ExcelCellRange = AV19excelSpreadsheet.cell(AV13row, AV17index);
                  AV18ExcelCellRange.gxTpr_Valuenumber = (decimal)(AV14count);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV13row = (short)(AV13row+1);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         P009X2_A100CompanyId = new long[1] ;
         P009X2_A157CompanyLocationId = new long[1] ;
         P009X2_A101CompanyName = new string[] {""} ;
         P009X2_A125LeaveTypeName = new string[] {""} ;
         P009X2_A124LeaveTypeId = new long[1] ;
         A101CompanyName = "";
         A125LeaveTypeName = "";
         AV22CompanyName = "";
         AV25excelCellStyle = new GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle(context);
         AV18ExcelCellRange = new GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange(context);
         AV19excelSpreadsheet = new GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet(context);
         GXt_char1 = "";
         AV15Name = "";
         P009X3_A100CompanyId = new long[1] ;
         P009X3_A157CompanyLocationId = new long[1] ;
         P009X3_A106EmployeeId = new long[1] ;
         P009X3_A148EmployeeName = new string[] {""} ;
         P009X3_A147EmployeeBalance = new decimal[1] ;
         A148EmployeeName = "";
         P009X5_A124LeaveTypeId = new long[1] ;
         P009X5_A100CompanyId = new long[1] ;
         P009X5_A125LeaveTypeName = new string[] {""} ;
         P009X5_A40000GXC1 = new decimal[1] ;
         P009X5_n40000GXC1 = new bool[] {false} ;
         Gx_date = DateTime.MinValue;
         AV27File = new GxFile(context.GetPhysicalPath());
         AV11Session = context.GetSession();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemployeeleavereport__default(),
            new Object[][] {
                new Object[] {
               P009X2_A100CompanyId, P009X2_A157CompanyLocationId, P009X2_A101CompanyName, P009X2_A125LeaveTypeName, P009X2_A124LeaveTypeId
               }
               , new Object[] {
               P009X3_A100CompanyId, P009X3_A157CompanyLocationId, P009X3_A106EmployeeId, P009X3_A148EmployeeName, P009X3_A147EmployeeBalance
               }
               , new Object[] {
               P009X5_A124LeaveTypeId, P009X5_A100CompanyId, P009X5_A125LeaveTypeName, P009X5_A40000GXC1, P009X5_n40000GXC1
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV12col ;
      private short AV13row ;
      private short AV14count ;
      private short AV17index ;
      private int AV30GXV1 ;
      private int AV28EmployeeIds_Count ;
      private long AV20CompanyLocationId ;
      private long A100CompanyId ;
      private long A157CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A106EmployeeId ;
      private decimal A147EmployeeBalance ;
      private decimal A40000GXC1 ;
      private string AV10Filename ;
      private string A101CompanyName ;
      private string A125LeaveTypeName ;
      private string AV22CompanyName ;
      private string GXt_char1 ;
      private string AV15Name ;
      private string A148EmployeeName ;
      private DateTime AV26Date ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool n40000GXC1 ;
      private bool AV24boolean ;
      private string AV21ErrorMessage ;
      private IGxSession AV11Session ;
      private GxFile AV27File ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV28EmployeeIds ;
      private GxSimpleCollection<long> aP1_EmployeeIds ;
      private DateTime aP2_Date ;
      private GxSimpleCollection<string> AV8LeaveTypeNames ;
      private IDataStoreProvider pr_default ;
      private long[] P009X2_A100CompanyId ;
      private long[] P009X2_A157CompanyLocationId ;
      private string[] P009X2_A101CompanyName ;
      private string[] P009X2_A125LeaveTypeName ;
      private long[] P009X2_A124LeaveTypeId ;
      private GeneXus.Programs.genexusoffice.office.excel.style.SdtExcelCellStyle AV25excelCellStyle ;
      private GeneXus.Programs.genexusoffice.office.excel.cells.SdtExcelCellRange AV18ExcelCellRange ;
      private GeneXus.Programs.genexusoffice.office.excel.SdtExcelSpreadsheet AV19excelSpreadsheet ;
      private long[] P009X3_A100CompanyId ;
      private long[] P009X3_A157CompanyLocationId ;
      private long[] P009X3_A106EmployeeId ;
      private string[] P009X3_A148EmployeeName ;
      private decimal[] P009X3_A147EmployeeBalance ;
      private long[] P009X5_A124LeaveTypeId ;
      private long[] P009X5_A100CompanyId ;
      private string[] P009X5_A125LeaveTypeName ;
      private decimal[] P009X5_A40000GXC1 ;
      private bool[] P009X5_n40000GXC1 ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
   }

   public class aemployeeleavereport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009X3( IGxContext context ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV28EmployeeIds ,
                                             int AV28EmployeeIds_Count ,
                                             long A157CompanyLocationId ,
                                             long AV20CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T2.CompanyLocationId, T1.EmployeeId, T1.EmployeeName, T1.EmployeeBalance FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         AddWhere(sWhereString, "(T2.CompanyLocationId = :AV20CompanyLocationId)");
         if ( AV28EmployeeIds_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28EmployeeIds, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.EmployeeId";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P009X3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009X2;
          prmP009X2 = new Object[] {
          new ParDef("AV20CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP009X5;
          prmP009X5 = new Object[] {
          new ParDef("EmployeeName",GXType.Char,100,0) ,
          new ParDef("AV26Date",GXType.Date,8,0) ,
          new ParDef("CompanyId",GXType.Int64,10,0)
          };
          Object[] prmP009X3;
          prmP009X3 = new Object[] {
          new ParDef("AV20CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009X2", "SELECT T1.CompanyId, T2.CompanyLocationId, T2.CompanyName, T1.LeaveTypeName, T1.LeaveTypeId FROM (LeaveType T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T2.CompanyLocationId = :AV20CompanyLocationId ORDER BY T1.LeaveTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009X5", "SELECT T1.LeaveTypeId, T1.CompanyId, T1.LeaveTypeName, COALESCE( T2.GXC1, 0) AS GXC1 FROM (LeaveType T1 LEFT JOIN LATERAL (SELECT SUM(T3.LeaveRequestDuration) AS GXC1, T3.LeaveTypeId FROM (LeaveRequest T3 INNER JOIN Employee T4 ON T4.EmployeeId = T3.EmployeeId) WHERE (T1.LeaveTypeId = T3.LeaveTypeId) AND (T4.EmployeeName = ( :EmployeeName) and T3.LeaveRequestStartDate >= TO_DATE(date_part('year', :AV26Date)||'-'||1||'-'||1, 'YYYY-MM-DD') and T3.LeaveRequestStartDate < TO_DATE(date_part('year', :AV26Date)||'-'||12||'-'||31, 'YYYY-MM-DD')) GROUP BY T3.LeaveTypeId ) T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE T1.CompanyId = :CompanyId ORDER BY T1.CompanyId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X5,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
