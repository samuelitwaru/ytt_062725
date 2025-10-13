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
   public class employeeleavetotal : GXProcedure
   {
      public employeeleavetotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public employeeleavetotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           DateTime aP1_FromDate ,
                           DateTime aP2_ToDate ,
                           out decimal aP3_Duration )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV10FromDate = aP1_FromDate;
         this.AV11ToDate = aP2_ToDate;
         this.AV14Duration = 0 ;
         initialize();
         ExecuteImpl();
         aP3_Duration=this.AV14Duration;
      }

      public decimal executeUdp( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate )
      {
         execute(aP0_EmployeeId, aP1_FromDate, aP2_ToDate, out aP3_Duration);
         return AV14Duration ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 DateTime aP1_FromDate ,
                                 DateTime aP2_ToDate ,
                                 out decimal aP3_Duration )
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
         if ( (0==AV8EmployeeId) && (DateTime.MinValue==AV10FromDate) && (DateTime.MinValue==AV11ToDate) )
         {
            AV8EmployeeId = 245;
            AV10FromDate = context.localUtil.YMDToD( 2025, 9, 8);
            AV11ToDate = context.localUtil.YMDToD( 2025, 9, 14);
         }
         /* Using cursor P009Y2 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P009Y2_A100CompanyId[0];
            A106EmployeeId = P009Y2_A106EmployeeId[0];
            A148EmployeeName = P009Y2_A148EmployeeName[0];
            A157CompanyLocationId = P009Y2_A157CompanyLocationId[0];
            A188EmployeeFTEHours = P009Y2_A188EmployeeFTEHours[0];
            A157CompanyLocationId = P009Y2_A157CompanyLocationId[0];
            AV20EmployeeName = A148EmployeeName;
            AV17CompanyLocationId = A157CompanyLocationId;
            AV25EmployeeFTEHours = A188EmployeeFTEHours;
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
            A139HolidayIsActive = P009Y3_A139HolidayIsActive[0];
            A113HolidayId = P009Y3_A113HolidayId[0];
            A157CompanyLocationId = P009Y3_A157CompanyLocationId[0];
            if ( ( DateTimeUtil.Dow( A115HolidayStartDate) > 1 ) && ( DateTimeUtil.Dow( A115HolidayStartDate) < 7 ) )
            {
               AV18HolidayDates.Add(A115HolidayStartDate, 0);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV14Duration = (decimal)(AV14Duration+(AV18HolidayDates.Count));
         AV29GXLvl35 = 0;
         /* Using cursor P009Y4 */
         pr_default.execute(2, new Object[] {AV8EmployeeId, AV11ToDate, AV10FromDate});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A124LeaveTypeId = P009Y4_A124LeaveTypeId[0];
            A130LeaveRequestEndDate = P009Y4_A130LeaveRequestEndDate[0];
            A129LeaveRequestStartDate = P009Y4_A129LeaveRequestStartDate[0];
            A132LeaveRequestStatus = P009Y4_A132LeaveRequestStatus[0];
            A145LeaveTypeLoggingWorkHours = P009Y4_A145LeaveTypeLoggingWorkHours[0];
            A106EmployeeId = P009Y4_A106EmployeeId[0];
            A131LeaveRequestDuration = P009Y4_A131LeaveRequestDuration[0];
            A127LeaveRequestId = P009Y4_A127LeaveRequestId[0];
            A145LeaveTypeLoggingWorkHours = P009Y4_A145LeaveTypeLoggingWorkHours[0];
            AV29GXLvl35 = 1;
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
            if ( ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV10FromDate ) ) || ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV11ToDate ) ) )
            {
               AV21CurrentDate = AV12LeaveStartDate;
               while ( DateTimeUtil.ResetTime ( AV21CurrentDate ) <= DateTimeUtil.ResetTime ( AV13LeaveEndDate ) )
               {
                  if ( (AV18HolidayDates.IndexOf(AV21CurrentDate)>0) )
                  {
                     AV14Duration = (decimal)(AV14Duration+1);
                  }
                  AV24IsWeekend = (bool)((DateTimeUtil.Dow( AV21CurrentDate)==1)||(DateTimeUtil.Dow( AV21CurrentDate)==7));
                  if ( ! AV24IsWeekend )
                  {
                     AV14Duration = (decimal)(AV14Duration+1);
                  }
                  else
                  {
                  }
                  AV21CurrentDate = DateTimeUtil.DAdd( AV21CurrentDate, (1));
               }
            }
            else
            {
               AV14Duration = (decimal)(AV14Duration+A131LeaveRequestDuration);
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( AV29GXLvl35 == 0 )
         {
         }
         AV26HoursPerDay = (short)(AV25EmployeeFTEHours/ (decimal)(5));
         AV14Duration = (decimal)(AV14Duration*AV26HoursPerDay*60);
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

      public override void initialize( )
      {
         P009Y2_A100CompanyId = new long[1] ;
         P009Y2_A106EmployeeId = new long[1] ;
         P009Y2_A148EmployeeName = new string[] {""} ;
         P009Y2_A157CompanyLocationId = new long[1] ;
         P009Y2_A188EmployeeFTEHours = new short[1] ;
         A148EmployeeName = "";
         AV20EmployeeName = "";
         P009Y3_A100CompanyId = new long[1] ;
         P009Y3_A157CompanyLocationId = new long[1] ;
         P009Y3_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P009Y3_A139HolidayIsActive = new bool[] {false} ;
         P009Y3_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         AV18HolidayDates = new GxSimpleCollection<DateTime>();
         P009Y4_A124LeaveTypeId = new long[1] ;
         P009Y4_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P009Y4_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P009Y4_A132LeaveRequestStatus = new string[] {""} ;
         P009Y4_A145LeaveTypeLoggingWorkHours = new string[] {""} ;
         P009Y4_A106EmployeeId = new long[1] ;
         P009Y4_A131LeaveRequestDuration = new decimal[1] ;
         P009Y4_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         A145LeaveTypeLoggingWorkHours = "";
         AV12LeaveStartDate = DateTime.MinValue;
         AV13LeaveEndDate = DateTime.MinValue;
         AV21CurrentDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeeleavetotal__default(),
            new Object[][] {
                new Object[] {
               P009Y2_A100CompanyId, P009Y2_A106EmployeeId, P009Y2_A148EmployeeName, P009Y2_A157CompanyLocationId, P009Y2_A188EmployeeFTEHours
               }
               , new Object[] {
               P009Y3_A100CompanyId, P009Y3_A157CompanyLocationId, P009Y3_A115HolidayStartDate, P009Y3_A139HolidayIsActive, P009Y3_A113HolidayId
               }
               , new Object[] {
               P009Y4_A124LeaveTypeId, P009Y4_A130LeaveRequestEndDate, P009Y4_A129LeaveRequestStartDate, P009Y4_A132LeaveRequestStatus, P009Y4_A145LeaveTypeLoggingWorkHours, P009Y4_A106EmployeeId, P009Y4_A131LeaveRequestDuration, P009Y4_A127LeaveRequestId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A188EmployeeFTEHours ;
      private short AV25EmployeeFTEHours ;
      private short AV9Count ;
      private short AV29GXLvl35 ;
      private short AV26HoursPerDay ;
      private long AV8EmployeeId ;
      private long A100CompanyId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long AV17CompanyLocationId ;
      private long A113HolidayId ;
      private long A124LeaveTypeId ;
      private long A127LeaveRequestId ;
      private decimal AV14Duration ;
      private decimal A131LeaveRequestDuration ;
      private string A148EmployeeName ;
      private string AV20EmployeeName ;
      private string A132LeaveRequestStatus ;
      private string A145LeaveTypeLoggingWorkHours ;
      private DateTime AV10FromDate ;
      private DateTime AV11ToDate ;
      private DateTime A115HolidayStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime AV12LeaveStartDate ;
      private DateTime AV13LeaveEndDate ;
      private DateTime AV21CurrentDate ;
      private bool A139HolidayIsActive ;
      private bool AV24IsWeekend ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P009Y2_A100CompanyId ;
      private long[] P009Y2_A106EmployeeId ;
      private string[] P009Y2_A148EmployeeName ;
      private long[] P009Y2_A157CompanyLocationId ;
      private short[] P009Y2_A188EmployeeFTEHours ;
      private long[] P009Y3_A100CompanyId ;
      private long[] P009Y3_A157CompanyLocationId ;
      private DateTime[] P009Y3_A115HolidayStartDate ;
      private bool[] P009Y3_A139HolidayIsActive ;
      private long[] P009Y3_A113HolidayId ;
      private GxSimpleCollection<DateTime> AV18HolidayDates ;
      private long[] P009Y4_A124LeaveTypeId ;
      private DateTime[] P009Y4_A130LeaveRequestEndDate ;
      private DateTime[] P009Y4_A129LeaveRequestStartDate ;
      private string[] P009Y4_A132LeaveRequestStatus ;
      private string[] P009Y4_A145LeaveTypeLoggingWorkHours ;
      private long[] P009Y4_A106EmployeeId ;
      private decimal[] P009Y4_A131LeaveRequestDuration ;
      private long[] P009Y4_A127LeaveRequestId ;
      private decimal aP3_Duration ;
   }

   public class employeeleavetotal__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          def= new CursorDef[] {
              new CursorDef("P009Y2", "SELECT T1.CompanyId, T1.EmployeeId, T1.EmployeeName, T2.CompanyLocationId, T1.EmployeeFTEHours FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T1.EmployeeId = :AV8EmployeeId ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Y3", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.HolidayStartDate, T1.HolidayIsActive, T1.HolidayId FROM (Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE (T1.HolidayStartDate >= :AV10FromDate) AND (T1.HolidayStartDate <= :AV11ToDate) AND (T1.HolidayIsActive = TRUE) AND (T2.CompanyLocationId = :AV17CompanyLocationId) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009Y4", "SELECT T1.LeaveTypeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestStatus, T2.LeaveTypeLoggingWorkHours, T1.EmployeeId, T1.LeaveRequestDuration, T1.LeaveRequestId FROM (LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) WHERE (T1.EmployeeId = :AV8EmployeeId) AND (T1.LeaveRequestStartDate <= :AV11ToDate) AND (T1.LeaveRequestEndDate >= :AV10FromDate) AND (T2.LeaveTypeLoggingWorkHours = ( 'No')) AND (T1.LeaveRequestStatus = ( 'Approved')) ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y4,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}
