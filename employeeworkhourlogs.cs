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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class employeeworkhourlogs : GXProcedure
   {
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

      public employeeworkhourlogs( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeeworkhourlogs( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GxSimpleCollection<long> aP0_CompanyLocationId ,
                           GxSimpleCollection<long> aP1_ProjectId ,
                           GxSimpleCollection<long> aP2_EmployeeId ,
                           DateTime aP3_DateFrom ,
                           DateTime aP4_DateTo ,
                           out GXBaseCollection<SdtSDTEmployeeWorkHourLogs> aP5_Gxm2rootcol )
      {
         this.AV5CompanyLocationId = aP0_CompanyLocationId;
         this.AV7ProjectId = aP1_ProjectId;
         this.AV6EmployeeId = aP2_EmployeeId;
         this.AV10DateFrom = aP3_DateFrom;
         this.AV11DateTo = aP4_DateTo;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeWorkHourLogs>( context, "SDTEmployeeWorkHourLogs", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP5_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTEmployeeWorkHourLogs> executeUdp( GxSimpleCollection<long> aP0_CompanyLocationId ,
                                                                      GxSimpleCollection<long> aP1_ProjectId ,
                                                                      GxSimpleCollection<long> aP2_EmployeeId ,
                                                                      DateTime aP3_DateFrom ,
                                                                      DateTime aP4_DateTo )
      {
         execute(aP0_CompanyLocationId, aP1_ProjectId, aP2_EmployeeId, aP3_DateFrom, aP4_DateTo, out aP5_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GxSimpleCollection<long> aP0_CompanyLocationId ,
                                 GxSimpleCollection<long> aP1_ProjectId ,
                                 GxSimpleCollection<long> aP2_EmployeeId ,
                                 DateTime aP3_DateFrom ,
                                 DateTime aP4_DateTo ,
                                 out GXBaseCollection<SdtSDTEmployeeWorkHourLogs> aP5_Gxm2rootcol )
      {
         this.AV5CompanyLocationId = aP0_CompanyLocationId;
         this.AV7ProjectId = aP1_ProjectId;
         this.AV6EmployeeId = aP2_EmployeeId;
         this.AV10DateFrom = aP3_DateFrom;
         this.AV11DateTo = aP4_DateTo;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTEmployeeWorkHourLogs>( context, "SDTEmployeeWorkHourLogs", "YTT_version4") ;
         SubmitImpl();
         aP5_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A157CompanyLocationId ,
                                              AV5CompanyLocationId ,
                                              A102ProjectId ,
                                              AV7ProjectId ,
                                              A106EmployeeId ,
                                              AV6EmployeeId ,
                                              AV5CompanyLocationId.Count ,
                                              AV7ProjectId.Count ,
                                              AV6EmployeeId.Count ,
                                              A119WorkHourLogDate ,
                                              AV10DateFrom ,
                                              AV11DateTo } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00142 */
         pr_default.execute(0, new Object[] {AV10DateFrom, AV11DateTo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK142 = false;
            A100CompanyId = P00142_A100CompanyId[0];
            A148EmployeeName = P00142_A148EmployeeName[0];
            A118WorkHourLogId = P00142_A118WorkHourLogId[0];
            A119WorkHourLogDate = P00142_A119WorkHourLogDate[0];
            A120WorkHourLogDuration = P00142_A120WorkHourLogDuration[0];
            A121WorkHourLogHour = P00142_A121WorkHourLogHour[0];
            A122WorkHourLogMinute = P00142_A122WorkHourLogMinute[0];
            A123WorkHourLogDescription = P00142_A123WorkHourLogDescription[0];
            A106EmployeeId = P00142_A106EmployeeId[0];
            A107EmployeeFirstName = P00142_A107EmployeeFirstName[0];
            A102ProjectId = P00142_A102ProjectId[0];
            A103ProjectName = P00142_A103ProjectName[0];
            A157CompanyLocationId = P00142_A157CompanyLocationId[0];
            A100CompanyId = P00142_A100CompanyId[0];
            A148EmployeeName = P00142_A148EmployeeName[0];
            A107EmployeeFirstName = P00142_A107EmployeeFirstName[0];
            A157CompanyLocationId = P00142_A157CompanyLocationId[0];
            A103ProjectName = P00142_A103ProjectName[0];
            Gxm1sdtemployeeworkhourlogs = new SdtSDTEmployeeWorkHourLogs(context);
            Gxm2rootcol.Add(Gxm1sdtemployeeworkhourlogs, 0);
            Gxm1sdtemployeeworkhourlogs.gxTpr_Employeeid = A106EmployeeId;
            Gxm1sdtemployeeworkhourlogs.gxTpr_Employeename = A148EmployeeName;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00142_A148EmployeeName[0], A148EmployeeName) == 0 ) )
            {
               BRK142 = false;
               A118WorkHourLogId = P00142_A118WorkHourLogId[0];
               A119WorkHourLogDate = P00142_A119WorkHourLogDate[0];
               A120WorkHourLogDuration = P00142_A120WorkHourLogDuration[0];
               A121WorkHourLogHour = P00142_A121WorkHourLogHour[0];
               A122WorkHourLogMinute = P00142_A122WorkHourLogMinute[0];
               A123WorkHourLogDescription = P00142_A123WorkHourLogDescription[0];
               A106EmployeeId = P00142_A106EmployeeId[0];
               A107EmployeeFirstName = P00142_A107EmployeeFirstName[0];
               A102ProjectId = P00142_A102ProjectId[0];
               A103ProjectName = P00142_A103ProjectName[0];
               A107EmployeeFirstName = P00142_A107EmployeeFirstName[0];
               A103ProjectName = P00142_A103ProjectName[0];
               Gxm3sdtemployeeworkhourlogs_workhourlog = new SdtSDTEmployeeWorkHourLogs_WorkHourLogItem(context);
               Gxm1sdtemployeeworkhourlogs.gxTpr_Workhourlog.Add(Gxm3sdtemployeeworkhourlogs_workhourlog, 0);
               Gxm3sdtemployeeworkhourlogs_workhourlog.gxTpr_Workhourlogid = A118WorkHourLogId;
               Gxm3sdtemployeeworkhourlogs_workhourlog.gxTpr_Workhourlogdate = A119WorkHourLogDate;
               Gxm3sdtemployeeworkhourlogs_workhourlog.gxTpr_Workhourlogduration = A120WorkHourLogDuration;
               Gxm3sdtemployeeworkhourlogs_workhourlog.gxTpr_Workhourloghour = A121WorkHourLogHour;
               Gxm3sdtemployeeworkhourlogs_workhourlog.gxTpr_Workhourlogminute = A122WorkHourLogMinute;
               Gxm3sdtemployeeworkhourlogs_workhourlog.gxTpr_Workhourlogdescription = A123WorkHourLogDescription;
               Gxm3sdtemployeeworkhourlogs_workhourlog.gxTpr_Employeeid = A106EmployeeId;
               Gxm3sdtemployeeworkhourlogs_workhourlog.gxTpr_Employeefirstname = A107EmployeeFirstName;
               Gxm3sdtemployeeworkhourlogs_workhourlog.gxTpr_Projectid = A102ProjectId;
               Gxm3sdtemployeeworkhourlogs_workhourlog.gxTpr_Projectname = A103ProjectName;
               BRK142 = true;
               pr_default.readNext(0);
            }
            if ( ! BRK142 )
            {
               BRK142 = true;
               pr_default.readNext(0);
            }
         }
         cleanup();
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

      protected override void CloseCursors( )
      {
         pr_default.close(0);
      }

      public override void initialize( )
      {
         A119WorkHourLogDate = DateTime.MinValue;
         P00142_A100CompanyId = new long[1] ;
         P00142_A148EmployeeName = new string[] {""} ;
         P00142_A118WorkHourLogId = new long[1] ;
         P00142_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00142_A120WorkHourLogDuration = new string[] {""} ;
         P00142_A121WorkHourLogHour = new short[1] ;
         P00142_A122WorkHourLogMinute = new short[1] ;
         P00142_A123WorkHourLogDescription = new string[] {""} ;
         P00142_A106EmployeeId = new long[1] ;
         P00142_A107EmployeeFirstName = new string[] {""} ;
         P00142_A102ProjectId = new long[1] ;
         P00142_A103ProjectName = new string[] {""} ;
         P00142_A157CompanyLocationId = new long[1] ;
         A148EmployeeName = "";
         A120WorkHourLogDuration = "";
         A123WorkHourLogDescription = "";
         A107EmployeeFirstName = "";
         A103ProjectName = "";
         Gxm1sdtemployeeworkhourlogs = new SdtSDTEmployeeWorkHourLogs(context);
         Gxm3sdtemployeeworkhourlogs_workhourlog = new SdtSDTEmployeeWorkHourLogs_WorkHourLogItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeeworkhourlogs__default(),
            new Object[][] {
                new Object[] {
               P00142_A100CompanyId, P00142_A148EmployeeName, P00142_A118WorkHourLogId, P00142_A119WorkHourLogDate, P00142_A120WorkHourLogDuration, P00142_A121WorkHourLogHour, P00142_A122WorkHourLogMinute, P00142_A123WorkHourLogDescription, P00142_A106EmployeeId, P00142_A107EmployeeFirstName,
               P00142_A102ProjectId, P00142_A103ProjectName, P00142_A157CompanyLocationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private int AV5CompanyLocationId_Count ;
      private int AV7ProjectId_Count ;
      private int AV6EmployeeId_Count ;
      private long A157CompanyLocationId ;
      private long A102ProjectId ;
      private long A106EmployeeId ;
      private long A100CompanyId ;
      private long A118WorkHourLogId ;
      private string A148EmployeeName ;
      private string A107EmployeeFirstName ;
      private string A103ProjectName ;
      private DateTime AV10DateFrom ;
      private DateTime AV11DateTo ;
      private DateTime A119WorkHourLogDate ;
      private bool BRK142 ;
      private string A123WorkHourLogDescription ;
      private string A120WorkHourLogDuration ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV5CompanyLocationId ;
      private GxSimpleCollection<long> AV7ProjectId ;
      private GxSimpleCollection<long> AV6EmployeeId ;
      private GXBaseCollection<SdtSDTEmployeeWorkHourLogs> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private long[] P00142_A100CompanyId ;
      private string[] P00142_A148EmployeeName ;
      private long[] P00142_A118WorkHourLogId ;
      private DateTime[] P00142_A119WorkHourLogDate ;
      private string[] P00142_A120WorkHourLogDuration ;
      private short[] P00142_A121WorkHourLogHour ;
      private short[] P00142_A122WorkHourLogMinute ;
      private string[] P00142_A123WorkHourLogDescription ;
      private long[] P00142_A106EmployeeId ;
      private string[] P00142_A107EmployeeFirstName ;
      private long[] P00142_A102ProjectId ;
      private string[] P00142_A103ProjectName ;
      private long[] P00142_A157CompanyLocationId ;
      private SdtSDTEmployeeWorkHourLogs Gxm1sdtemployeeworkhourlogs ;
      private SdtSDTEmployeeWorkHourLogs_WorkHourLogItem Gxm3sdtemployeeworkhourlogs_workhourlog ;
      private GXBaseCollection<SdtSDTEmployeeWorkHourLogs> aP5_Gxm2rootcol ;
   }

   public class employeeworkhourlogs__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00142( IGxContext context ,
                                             long A157CompanyLocationId ,
                                             GxSimpleCollection<long> AV5CompanyLocationId ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV7ProjectId ,
                                             long A106EmployeeId ,
                                             GxSimpleCollection<long> AV6EmployeeId ,
                                             int AV5CompanyLocationId_Count ,
                                             int AV7ProjectId_Count ,
                                             int AV6EmployeeId_Count ,
                                             DateTime A119WorkHourLogDate ,
                                             DateTime AV10DateFrom ,
                                             DateTime AV11DateTo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.CompanyId, T2.EmployeeName, T1.WorkHourLogId, T1.WorkHourLogDate, T1.WorkHourLogDuration, T1.WorkHourLogHour, T1.WorkHourLogMinute, T1.WorkHourLogDescription, T1.EmployeeId, T2.EmployeeFirstName, T1.ProjectId, T4.ProjectName, T3.CompanyLocationId FROM (((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) INNER JOIN Project T4 ON T4.ProjectId = T1.ProjectId)";
         AddWhere(sWhereString, "(T1.WorkHourLogDate >= :AV10DateFrom)");
         AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV11DateTo)");
         if ( AV5CompanyLocationId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV5CompanyLocationId, "T3.CompanyLocationId IN (", ")")+")");
         }
         if ( AV7ProjectId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV7ProjectId, "T1.ProjectId IN (", ")")+")");
         }
         if ( AV6EmployeeId_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV6EmployeeId, "T1.EmployeeId IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.EmployeeName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00142(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (long)dynConstraints[2] , (GxSimpleCollection<long>)dynConstraints[3] , (long)dynConstraints[4] , (GxSimpleCollection<long>)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] );
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
          Object[] prmP00142;
          prmP00142 = new Object[] {
          new ParDef("AV10DateFrom",GXType.Date,8,0) ,
          new ParDef("AV11DateTo",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00142", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00142,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((long[]) buf[12])[0] = rslt.getLong(13);
                return;
       }
    }

 }

}
