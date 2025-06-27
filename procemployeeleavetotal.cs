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
   public class procemployeeleavetotal : GXProcedure
   {
      public procemployeeleavetotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public procemployeeleavetotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_DateFrom ,
                           ref DateTime aP1_DateTo ,
                           long aP2_LocationId ,
                           long aP3_EmployeeId ,
                           out GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem> aP4_SDTEmployeeHours )
      {
         this.AV11DateFrom = aP0_DateFrom;
         this.AV12DateTo = aP1_DateTo;
         this.AV9LocationId = aP2_LocationId;
         this.AV8EmployeeId = aP3_EmployeeId;
         this.AV17SDTEmployeeHours = new GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem>( context, "SDTEmployeeHoursItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP0_DateFrom=this.AV11DateFrom;
         aP1_DateTo=this.AV12DateTo;
         aP4_SDTEmployeeHours=this.AV17SDTEmployeeHours;
      }

      public GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem> executeUdp( ref DateTime aP0_DateFrom ,
                                                                                    ref DateTime aP1_DateTo ,
                                                                                    long aP2_LocationId ,
                                                                                    long aP3_EmployeeId )
      {
         execute(ref aP0_DateFrom, ref aP1_DateTo, aP2_LocationId, aP3_EmployeeId, out aP4_SDTEmployeeHours);
         return AV17SDTEmployeeHours ;
      }

      public void executeSubmit( ref DateTime aP0_DateFrom ,
                                 ref DateTime aP1_DateTo ,
                                 long aP2_LocationId ,
                                 long aP3_EmployeeId ,
                                 out GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem> aP4_SDTEmployeeHours )
      {
         this.AV11DateFrom = aP0_DateFrom;
         this.AV12DateTo = aP1_DateTo;
         this.AV9LocationId = aP2_LocationId;
         this.AV8EmployeeId = aP3_EmployeeId;
         this.AV17SDTEmployeeHours = new GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem>( context, "SDTEmployeeHoursItem", "YTT_version4") ;
         SubmitImpl();
         aP0_DateFrom=this.AV11DateFrom;
         aP1_DateTo=this.AV12DateTo;
         aP4_SDTEmployeeHours=this.AV17SDTEmployeeHours;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Execute user subroutine: 'GETSTARTDATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'GETHOLIDAYDATES' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8EmployeeId ,
                                              AV9LocationId ,
                                              A106EmployeeId ,
                                              A157CompanyLocationId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor P007A2 */
         pr_default.execute(0, new Object[] {AV8EmployeeId, AV9LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A100CompanyId = P007A2_A100CompanyId[0];
            A106EmployeeId = P007A2_A106EmployeeId[0];
            A157CompanyLocationId = P007A2_A157CompanyLocationId[0];
            A107EmployeeFirstName = P007A2_A107EmployeeFirstName[0];
            A157CompanyLocationId = P007A2_A157CompanyLocationId[0];
            AV10TotalLeaveMinutes = 0;
            /* Using cursor P007A3 */
            pr_default.execute(1, new Object[] {A106EmployeeId, AV12DateTo, AV11DateFrom});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A130LeaveRequestEndDate = P007A3_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = P007A3_A129LeaveRequestStartDate[0];
               A132LeaveRequestStatus = P007A3_A132LeaveRequestStatus[0];
               A127LeaveRequestId = P007A3_A127LeaveRequestId[0];
               if ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV11DateFrom ) )
               {
                  AV13LeaveStartDate = AV12DateTo;
               }
               else
               {
                  AV13LeaveStartDate = A129LeaveRequestStartDate;
               }
               if ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV12DateTo ) )
               {
                  AV14LeaveEndDate = AV12DateTo;
               }
               else
               {
                  AV14LeaveEndDate = A130LeaveRequestEndDate;
               }
               while ( DateTimeUtil.ResetTime ( AV13LeaveStartDate ) <= DateTimeUtil.ResetTime ( AV14LeaveEndDate ) )
               {
                  if ( DateTimeUtil.Dow( AV13LeaveStartDate) == 7 )
                  {
                     AV13LeaveStartDate = DateTimeUtil.DAdd( AV13LeaveStartDate, (2));
                  }
                  else if ( (AV20HolidayDates.IndexOf(AV13LeaveStartDate)>0) )
                  {
                     AV13LeaveStartDate = DateTimeUtil.DAdd( AV13LeaveStartDate, (1));
                  }
                  else
                  {
                     AV10TotalLeaveMinutes = (long)(AV10TotalLeaveMinutes+(8*60));
                     AV13LeaveStartDate = DateTimeUtil.DAdd( AV13LeaveStartDate, (1));
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV15TotalWorkMinutes = 0;
            /* Using cursor P007A4 */
            pr_default.execute(2, new Object[] {A106EmployeeId, AV11DateFrom, AV12DateTo});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A119WorkHourLogDate = P007A4_A119WorkHourLogDate[0];
               A122WorkHourLogMinute = P007A4_A122WorkHourLogMinute[0];
               A121WorkHourLogHour = P007A4_A121WorkHourLogHour[0];
               A118WorkHourLogId = P007A4_A118WorkHourLogId[0];
               AV15TotalWorkMinutes = (long)(AV15TotalWorkMinutes+((A121WorkHourLogHour*60)+A122WorkHourLogMinute));
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV16SDTEmployeeHoursItem = new SdtSDTEmployeeHours_SDTEmployeeHoursItem(context);
            AV16SDTEmployeeHoursItem.gxTpr_Employeename = A107EmployeeFirstName;
            AV16SDTEmployeeHoursItem.gxTpr_Workhours = AV15TotalWorkMinutes;
            AV16SDTEmployeeHoursItem.gxTpr_Leavehours = AV10TotalLeaveMinutes;
            GXt_char1 = "";
            new procformattime(context ).execute(  AV10TotalLeaveMinutes, out  GXt_char1) ;
            AV16SDTEmployeeHoursItem.gxTpr_Formattedleavehours = GXt_char1;
            GXt_char1 = "";
            new procformattime(context ).execute(  AV15TotalWorkMinutes, out  GXt_char1) ;
            AV16SDTEmployeeHoursItem.gxTpr_Formattedworkhours = GXt_char1;
            AV17SDTEmployeeHours.Add(AV16SDTEmployeeHoursItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'GETSTARTDATE' Routine */
         returnInSub = false;
         if ( AV18PeriodicCategory == 1 )
         {
            if ( DateTimeUtil.Dow( AV19FromDate) > 0 )
            {
               AV19FromDate = DateTimeUtil.DAdd( AV19FromDate, (1-DateTimeUtil.Dow( AV19FromDate)));
            }
            else
            {
               AV19FromDate = DateTimeUtil.DAdd( AV19FromDate, (-6));
            }
         }
         else if ( AV18PeriodicCategory == 2 )
         {
            AV19FromDate = context.localUtil.YMDToD( DateTimeUtil.Year( AV19FromDate), DateTimeUtil.Month( AV19FromDate), 1);
         }
         else
         {
            AV19FromDate = context.localUtil.YMDToD( DateTimeUtil.Year( AV19FromDate), 1, 1);
         }
      }

      protected void S121( )
      {
         /* 'GETHOLIDAYDATES' Routine */
         returnInSub = false;
         /* Using cursor P007A5 */
         pr_default.execute(3, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A100CompanyId = P007A5_A100CompanyId[0];
            A106EmployeeId = P007A5_A106EmployeeId[0];
            A157CompanyLocationId = P007A5_A157CompanyLocationId[0];
            A157CompanyLocationId = P007A5_A157CompanyLocationId[0];
            AV9LocationId = A157CompanyLocationId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         /* Using cursor P007A6 */
         pr_default.execute(4, new Object[] {AV11DateFrom, AV12DateTo, AV9LocationId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A100CompanyId = P007A6_A100CompanyId[0];
            A157CompanyLocationId = P007A6_A157CompanyLocationId[0];
            A115HolidayStartDate = P007A6_A115HolidayStartDate[0];
            A113HolidayId = P007A6_A113HolidayId[0];
            A157CompanyLocationId = P007A6_A157CompanyLocationId[0];
            AV20HolidayDates.Add(A115HolidayStartDate, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
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
         AV17SDTEmployeeHours = new GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem>( context, "SDTEmployeeHoursItem", "YTT_version4");
         P007A2_A100CompanyId = new long[1] ;
         P007A2_A106EmployeeId = new long[1] ;
         P007A2_A157CompanyLocationId = new long[1] ;
         P007A2_A107EmployeeFirstName = new string[] {""} ;
         A107EmployeeFirstName = "";
         P007A3_A106EmployeeId = new long[1] ;
         P007A3_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P007A3_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P007A3_A132LeaveRequestStatus = new string[] {""} ;
         P007A3_A127LeaveRequestId = new long[1] ;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A129LeaveRequestStartDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         AV13LeaveStartDate = DateTime.MinValue;
         AV14LeaveEndDate = DateTime.MinValue;
         AV20HolidayDates = new GxSimpleCollection<DateTime>();
         P007A4_A106EmployeeId = new long[1] ;
         P007A4_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P007A4_A122WorkHourLogMinute = new short[1] ;
         P007A4_A121WorkHourLogHour = new short[1] ;
         P007A4_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         AV16SDTEmployeeHoursItem = new SdtSDTEmployeeHours_SDTEmployeeHoursItem(context);
         GXt_char1 = "";
         AV19FromDate = DateTime.MinValue;
         P007A5_A100CompanyId = new long[1] ;
         P007A5_A106EmployeeId = new long[1] ;
         P007A5_A157CompanyLocationId = new long[1] ;
         P007A6_A100CompanyId = new long[1] ;
         P007A6_A157CompanyLocationId = new long[1] ;
         P007A6_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P007A6_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procemployeeleavetotal__default(),
            new Object[][] {
                new Object[] {
               P007A2_A100CompanyId, P007A2_A106EmployeeId, P007A2_A157CompanyLocationId, P007A2_A107EmployeeFirstName
               }
               , new Object[] {
               P007A3_A106EmployeeId, P007A3_A130LeaveRequestEndDate, P007A3_A129LeaveRequestStartDate, P007A3_A132LeaveRequestStatus, P007A3_A127LeaveRequestId
               }
               , new Object[] {
               P007A4_A106EmployeeId, P007A4_A119WorkHourLogDate, P007A4_A122WorkHourLogMinute, P007A4_A121WorkHourLogHour, P007A4_A118WorkHourLogId
               }
               , new Object[] {
               P007A5_A100CompanyId, P007A5_A106EmployeeId, P007A5_A157CompanyLocationId
               }
               , new Object[] {
               P007A6_A100CompanyId, P007A6_A157CompanyLocationId, P007A6_A115HolidayStartDate, P007A6_A113HolidayId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A122WorkHourLogMinute ;
      private short A121WorkHourLogHour ;
      private short AV18PeriodicCategory ;
      private long AV9LocationId ;
      private long AV8EmployeeId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long A100CompanyId ;
      private long AV10TotalLeaveMinutes ;
      private long A127LeaveRequestId ;
      private long AV15TotalWorkMinutes ;
      private long A118WorkHourLogId ;
      private long A113HolidayId ;
      private string A107EmployeeFirstName ;
      private string A132LeaveRequestStatus ;
      private string GXt_char1 ;
      private DateTime AV11DateFrom ;
      private DateTime AV12DateTo ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime AV13LeaveStartDate ;
      private DateTime AV14LeaveEndDate ;
      private DateTime A119WorkHourLogDate ;
      private DateTime AV19FromDate ;
      private DateTime A115HolidayStartDate ;
      private bool returnInSub ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_DateFrom ;
      private DateTime aP1_DateTo ;
      private GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem> AV17SDTEmployeeHours ;
      private IDataStoreProvider pr_default ;
      private long[] P007A2_A100CompanyId ;
      private long[] P007A2_A106EmployeeId ;
      private long[] P007A2_A157CompanyLocationId ;
      private string[] P007A2_A107EmployeeFirstName ;
      private long[] P007A3_A106EmployeeId ;
      private DateTime[] P007A3_A130LeaveRequestEndDate ;
      private DateTime[] P007A3_A129LeaveRequestStartDate ;
      private string[] P007A3_A132LeaveRequestStatus ;
      private long[] P007A3_A127LeaveRequestId ;
      private GxSimpleCollection<DateTime> AV20HolidayDates ;
      private long[] P007A4_A106EmployeeId ;
      private DateTime[] P007A4_A119WorkHourLogDate ;
      private short[] P007A4_A122WorkHourLogMinute ;
      private short[] P007A4_A121WorkHourLogHour ;
      private long[] P007A4_A118WorkHourLogId ;
      private SdtSDTEmployeeHours_SDTEmployeeHoursItem AV16SDTEmployeeHoursItem ;
      private long[] P007A5_A100CompanyId ;
      private long[] P007A5_A106EmployeeId ;
      private long[] P007A5_A157CompanyLocationId ;
      private long[] P007A6_A100CompanyId ;
      private long[] P007A6_A157CompanyLocationId ;
      private DateTime[] P007A6_A115HolidayStartDate ;
      private long[] P007A6_A113HolidayId ;
      private GXBaseCollection<SdtSDTEmployeeHours_SDTEmployeeHoursItem> aP4_SDTEmployeeHours ;
   }

   public class procemployeeleavetotal__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007A2( IGxContext context ,
                                             long AV8EmployeeId ,
                                             long AV9LocationId ,
                                             long A106EmployeeId ,
                                             long A157CompanyLocationId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[2];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId, T1.EmployeeFirstName FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId)";
         if ( ! (0==AV8EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV8EmployeeId)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV9LocationId) )
         {
            AddWhere(sWhereString, "(T2.CompanyLocationId = :AV9LocationId)");
         }
         else
         {
            GXv_int2[1] = 1;
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
               case 0 :
                     return conditional_P007A2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007A3;
          prmP007A3 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV12DateTo",GXType.Date,8,0) ,
          new ParDef("AV11DateFrom",GXType.Date,8,0)
          };
          Object[] prmP007A4;
          prmP007A4 = new Object[] {
          new ParDef("EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV11DateFrom",GXType.Date,8,0) ,
          new ParDef("AV12DateTo",GXType.Date,8,0)
          };
          Object[] prmP007A5;
          prmP007A5 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          Object[] prmP007A6;
          prmP007A6 = new Object[] {
          new ParDef("AV11DateFrom",GXType.Date,8,0) ,
          new ParDef("AV12DateTo",GXType.Date,8,0) ,
          new ParDef("AV9LocationId",GXType.Int64,10,0)
          };
          Object[] prmP007A2;
          prmP007A2 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV9LocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007A3", "SELECT EmployeeId, LeaveRequestEndDate, LeaveRequestStartDate, LeaveRequestStatus, LeaveRequestId FROM LeaveRequest WHERE (EmployeeId = :EmployeeId) AND (LeaveRequestStartDate < :AV12DateTo and LeaveRequestEndDate > :AV11DateFrom) AND (LeaveRequestStatus = ( 'Approved')) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007A4", "SELECT EmployeeId, WorkHourLogDate, WorkHourLogMinute, WorkHourLogHour, WorkHourLogId FROM WorkHourLog WHERE (EmployeeId = :EmployeeId) AND (WorkHourLogDate >= :AV11DateFrom and WorkHourLogDate <= :AV12DateTo) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007A5", "SELECT T1.CompanyId, T1.EmployeeId, T2.CompanyLocationId FROM (Employee T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T1.EmployeeId = :AV8EmployeeId ORDER BY T1.EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007A6", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.HolidayStartDate, T1.HolidayId FROM (Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE (T1.HolidayStartDate >= :AV11DateFrom and T1.HolidayStartDate <= :AV12DateTo) AND (T2.CompanyLocationId = :AV9LocationId) ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007A6,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
