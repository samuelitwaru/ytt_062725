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
   public class aemployeeleavetotal : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aemployeeleavetotal().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
          long aP0_EmployeeId ;
         DateTime aP1_FromDate = new DateTime()  ;
         DateTime aP2_ToDate = new DateTime()  ;
          short aP3_Duration ;
         if ( 0 < args.Length )
         {
            aP0_EmployeeId=((long)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_EmployeeId=0;
         }
         if ( 1 < args.Length )
         {
            aP1_FromDate=((DateTime)(context.localUtil.CToD( (string)(args[1]), 2)));
         }
         else
         {
            aP1_FromDate=DateTime.MinValue;
         }
         if ( 2 < args.Length )
         {
            aP2_ToDate=((DateTime)(context.localUtil.CToD( (string)(args[2]), 2)));
         }
         else
         {
            aP2_ToDate=DateTime.MinValue;
         }
         if ( 3 < args.Length )
         {
            aP3_Duration=((short)(NumberUtil.Val( (string)(args[3]), ".")));
         }
         else
         {
            aP3_Duration=0;
         }
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, out aP3_Duration);
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

      public aemployeeleavetotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aemployeeleavetotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           out short aP3_Duration )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV14Duration = 0 ;
         initialize();
         ExecuteImpl();
         aP3_Duration=this.AV14Duration;
      }

      public short executeUdp( long aP0_EmployeeId ,
                               DateTime aP1_FromDate ,
                               DateTime aP2_ToDate )
      {
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, out aP3_Duration);
         return AV14Duration ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 out short aP3_Duration )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV14Duration = 0 ;
         SubmitImpl();
         aP3_Duration=this.AV14Duration;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8EmployeeId = 302;
         AV10FromDate = context.localUtil.YMDToD( 2024, 11, 25);
         AV11ToDate = context.localUtil.YMDToD( 2024, 12, 1);
         /* Using cursor P009Y2 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P009Y2_A100CompanyId[0];
            A106EmployeeId = P009Y2_A106EmployeeId[0];
            A148EmployeeName = P009Y2_A148EmployeeName[0];
            A157CompanyLocationId = P009Y2_A157CompanyLocationId[0];
            A157CompanyLocationId = P009Y2_A157CompanyLocationId[0];
            AV20EmployeeName = A148EmployeeName;
            AV17CompanyLocationId = A157CompanyLocationId;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV9Count = 0;
         AV14Duration = 0;
         /* Using cursor P009Y3 */
         pr_default.execute(1, new Object[] {AV10FromDate, AV11ToDate, AV17CompanyLocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A100CompanyId = P009Y3_A100CompanyId[0];
            A157CompanyLocationId = P009Y3_A157CompanyLocationId[0];
            A115HolidayStartDate = P009Y3_A115HolidayStartDate[0];
            A113HolidayId = P009Y3_A113HolidayId[0];
            A157CompanyLocationId = P009Y3_A157CompanyLocationId[0];
            if ( ( DateTimeUtil.Dow( A115HolidayStartDate) > 1 ) && ( DateTimeUtil.Dow( A115HolidayStartDate) < 7 ) )
            {
               AV18HolidayDates.Add(A115HolidayStartDate, 0);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV24GXLvl27 = 0;
         /* Using cursor P009Y4 */
         pr_default.execute(2, new Object[] {AV8EmployeeId, AV11ToDate, AV10FromDate});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A124LeaveTypeId = P009Y4_A124LeaveTypeId[0];
            A100CompanyId = P009Y4_A100CompanyId[0];
            A130LeaveRequestEndDate = P009Y4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P009Y4_A129LeaveRequestStartDate[0];
            A106EmployeeId = P009Y4_A106EmployeeId[0];
            A127LeaveRequestId = P009Y4_A127LeaveRequestId[0];
            A100CompanyId = P009Y4_A100CompanyId[0];
            AV24GXLvl27 = 1;
            if ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV10FromDate ) )
            {
               AV12LeaveStartDate = AV10FromDate;
            }
            else
            {
               AV12LeaveStartDate = A129LeaveRequestStartDate;
            }
            if ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV11ToDate ) )
            {
               AV13LeaveEndDate = AV11ToDate;
            }
            else
            {
               AV13LeaveEndDate = A130LeaveRequestEndDate;
            }
            AV14Duration = 0;
            AV21CurrentDate = AV12LeaveStartDate;
            while ( DateTimeUtil.ResetTime ( AV21CurrentDate ) <= DateTimeUtil.ResetTime ( AV13LeaveEndDate ) )
            {
               if ( ( DateTimeUtil.Dow( AV21CurrentDate) == 1 ) || ( DateTimeUtil.Dow( AV21CurrentDate) == 7 ) )
               {
                  AV21CurrentDate = DateTimeUtil.DAdd( AV21CurrentDate, (1));
               }
               else if ( DateTimeUtil.Dow( AV21CurrentDate) == 2 )
               {
                  if ( ( DateTimeUtil.DDiff( AV13LeaveEndDate , AV21CurrentDate ) > 5 ) )
                  {
                     AV14Duration = (short)(AV14Duration+5);
                     AV21CurrentDate = DateTimeUtil.DAdd( AV21CurrentDate, (7));
                  }
                  else
                  {
                     AV14Duration = (short)(AV14Duration+(DateTimeUtil.DDiff(AV13LeaveEndDate,AV21CurrentDate)));
                     if (true) break;
                  }
               }
               else
               {
                  AV21CurrentDate = DateTimeUtil.DAdd( AV21CurrentDate, (1));
                  AV14Duration = (short)(AV14Duration+1);
               }
            }
            /* Optimized group. */
            /* Using cursor P009Y5 */
            pr_default.execute(3, new Object[] {A100CompanyId, AV10FromDate, AV12LeaveStartDate, AV13LeaveEndDate, AV11ToDate, AV17CompanyLocationId});
            cV14Duration = P009Y5_AV14Duration[0];
            pr_default.close(3);
            AV14Duration = (short)(AV14Duration+cV14Duration*1);
            /* End optimized group. */
            AV9Count = (short)(AV9Count+1);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor P009Y7 */
         pr_default.execute(4, new Object[] {AV10FromDate, AV11ToDate, AV17CompanyLocationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A40000GXC1 = P009Y7_A40000GXC1[0];
            n40000GXC1 = P009Y7_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(4);
         if ( AV24GXLvl27 == 0 )
         {
            AV15HolidayCount = (short)(A40000GXC1);
            AV14Duration = (short)(AV14Duration+AV15HolidayCount);
         }
         AV14Duration = (short)(AV14Duration*8*60);
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
      }

      public override void initialize( )
      {
         P009Y2_A100CompanyId = new long[1] ;
         P009Y2_A106EmployeeId = new long[1] ;
         P009Y2_A148EmployeeName = new string[] {""} ;
         P009Y2_A157CompanyLocationId = new long[1] ;
         A148EmployeeName = "";
         AV20EmployeeName = "";
         P009Y3_A100CompanyId = new long[1] ;
         P009Y3_A157CompanyLocationId = new long[1] ;
         P009Y3_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P009Y3_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         AV18HolidayDates = new GxSimpleCollection<DateTime>();
         P009Y4_A124LeaveTypeId = new long[1] ;
         P009Y4_A100CompanyId = new long[1] ;
         P009Y4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P009Y4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P009Y4_A106EmployeeId = new long[1] ;
         P009Y4_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         AV12LeaveStartDate = DateTime.MinValue;
         AV13LeaveEndDate = DateTime.MinValue;
         AV21CurrentDate = DateTime.MinValue;
         P009Y5_AV14Duration = new short[1] ;
         P009Y7_A40000GXC1 = new int[1] ;
         P009Y7_n40000GXC1 = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aemployeeleavetotal__default(),
            new Object[][] {
                new Object[] {
               P009Y2_A100CompanyId, P009Y2_A106EmployeeId, P009Y2_A148EmployeeName, P009Y2_A157CompanyLocationId
               }
               , new Object[] {
               P009Y3_A100CompanyId, P009Y3_A157CompanyLocationId, P009Y3_A115HolidayStartDate, P009Y3_A113HolidayId
               }
               , new Object[] {
               P009Y4_A124LeaveTypeId, P009Y4_A100CompanyId, P009Y4_A130LeaveRequestEndDate, P009Y4_A129LeaveRequestStartDate, P009Y4_A106EmployeeId, P009Y4_A127LeaveRequestId
               }
               , new Object[] {
               P009Y5_AV14Duration
               }
               , new Object[] {
               P009Y7_A40000GXC1, P009Y7_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14Duration ;
      private short AV9Count ;
      private short AV24GXLvl27 ;
      private short cV14Duration ;
      private short AV15HolidayCount ;
      private int A40000GXC1 ;
      private long AV8EmployeeId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long AV17CompanyLocationId ;
      private long A113HolidayId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private string A148EmployeeName ;
      private string AV20EmployeeName ;
      private DateTime AV10FromDate ;
      private DateTime AV11ToDate ;
      private DateTime A115HolidayStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime AV12LeaveStartDate ;
      private DateTime AV13LeaveEndDate ;
      private DateTime AV21CurrentDate ;
      private bool n40000GXC1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P009Y2_A100CompanyId ;
      private long[] P009Y2_A106EmployeeId ;
      private string[] P009Y2_A148EmployeeName ;
      private long[] P009Y2_A157CompanyLocationId ;
      private long[] P009Y3_A100CompanyId ;
      private long[] P009Y3_A157CompanyLocationId ;
      private DateTime[] P009Y3_A115HolidayStartDate ;
      private long[] P009Y3_A113HolidayId ;
      private GxSimpleCollection<DateTime> AV18HolidayDates ;
      private long[] P009Y4_A124LeaveTypeId ;
      private long[] P009Y4_A100CompanyId ;
      private DateTime[] P009Y4_A130LeaveRequestEndDate ;
      private DateTime[] P009Y4_A129LeaveRequestStartDate ;
      private long[] P009Y4_A106EmployeeId ;
      private long[] P009Y4_A127LeaveRequestId ;
      private short[] P009Y5_AV14Duration ;
      private int[] P009Y7_A40000GXC1 ;
      private bool[] P009Y7_n40000GXC1 ;
      private short aP3_Duration ;
   }

   public class aemployeeleavetotal__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009Y2;
          prmP009Y2 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP009Y3;
          prmP009Y3 = new Object[] {
          new ParDef("AV10FromDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV17CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP009Y4;
          prmP009Y4 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV10FromDate",GXType.Date,8,0)
          };
          Object[] prmP009Y5;
          prmP009Y5 = new Object[] {
          new ParDef("CompanyId",GXType.Int64,10,0) ,
          new ParDef("AV10FromDate",GXType.Date,8,0) ,
          new ParDef("AV12LeaveStartDate",GXType.Date,8,0) ,
          new ParDef("AV13LeaveEndDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV17CompanyLocationId",GXType.Int64,10,0)
          };
          Object[] prmP009Y7;
          prmP009Y7 = new Object[] {
          new ParDef("AV10FromDate",GXType.Date,8,0) ,
          new ParDef("AV11ToDate",GXType.Date,8,0) ,
          new ParDef("AV17CompanyLocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009Y2", "SELECT T1.CompanyId, T1.EmployeeId, T1.EmployeeName, T2.CompanyLocationId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T1.EmployeeId = :AV8EmployeeId ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Y3", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.HolidayStartDate, T1.HolidayId FROM (Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE (T1.HolidayStartDate >= :AV10FromDate) AND (T1.HolidayStartDate <= :AV11ToDate) AND (T2.CompanyLocationId = :AV17CompanyLocationId) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009Y4", "SELECT T1.LeaveTypeId, T2.CompanyId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.EmployeeId, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV8EmployeeId) AND (T1.LeaveRequestStartDate < :AV11ToDate) AND (T1.LeaveRequestEndDate > :AV10FromDate) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009Y5", "SELECT COUNT(*) FROM (Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE (T1.CompanyId = :CompanyId) AND (( T1.HolidayStartDate >= :AV10FromDate and T1.HolidayStartDate <= :AV12LeaveStartDate) or ( T1.HolidayStartDate > :AV13LeaveEndDate and T1.HolidayStartDate < :AV11ToDate)) AND (T2.CompanyLocationId = :AV17CompanyLocationId) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009Y7", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM (Holiday T2 INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId) WHERE (T2.HolidayStartDate >= :AV10FromDate) AND (T2.HolidayStartDate <= :AV11ToDate) AND ((date_part('dow', CAST(T2.HolidayStartDate AS date)) + 1) > 1) AND ((date_part('dow', CAST(T2.HolidayStartDate AS date)) + 1) < 7) AND (T3.CompanyLocationId = :AV17CompanyLocationId) ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y7,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
