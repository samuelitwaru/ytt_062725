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
   public class procgetperiodicleavehours : GXProcedure
   {
      public procgetperiodicleavehours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public procgetperiodicleavehours( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_FromDate ,
                           DateTime aP1_ToDate ,
                           GxSimpleCollection<long> aP2_ProjectId ,
                           long aP3_EmployeeId ,
                           long aP4_LocationId ,
                           short aP5_PeriodicCategory ,
                           out GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem> aP6_Periods )
      {
         this.AV9FromDate = aP0_FromDate;
         this.AV12ToDate = aP1_ToDate;
         this.AV11ProjectId = aP2_ProjectId;
         this.AV8EmployeeId = aP3_EmployeeId;
         this.AV17LocationId = aP4_LocationId;
         this.AV16PeriodicCategory = aP5_PeriodicCategory;
         this.AV19Periods = new GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem>( context, "SDTLeaveReport.PeriodCollectionItem", "YTT_version4") ;
         initialize();
         ExecuteImpl();
         aP6_Periods=this.AV19Periods;
      }

      public GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem> executeUdp( DateTime aP0_FromDate ,
                                                                                  DateTime aP1_ToDate ,
                                                                                  GxSimpleCollection<long> aP2_ProjectId ,
                                                                                  long aP3_EmployeeId ,
                                                                                  long aP4_LocationId ,
                                                                                  short aP5_PeriodicCategory )
      {
         execute(aP0_FromDate, aP1_ToDate, aP2_ProjectId, aP3_EmployeeId, aP4_LocationId, aP5_PeriodicCategory, out aP6_Periods);
         return AV19Periods ;
      }

      public void executeSubmit( DateTime aP0_FromDate ,
                                 DateTime aP1_ToDate ,
                                 GxSimpleCollection<long> aP2_ProjectId ,
                                 long aP3_EmployeeId ,
                                 long aP4_LocationId ,
                                 short aP5_PeriodicCategory ,
                                 out GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem> aP6_Periods )
      {
         this.AV9FromDate = aP0_FromDate;
         this.AV12ToDate = aP1_ToDate;
         this.AV11ProjectId = aP2_ProjectId;
         this.AV8EmployeeId = aP3_EmployeeId;
         this.AV17LocationId = aP4_LocationId;
         this.AV16PeriodicCategory = aP5_PeriodicCategory;
         this.AV19Periods = new GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem>( context, "SDTLeaveReport.PeriodCollectionItem", "YTT_version4") ;
         SubmitImpl();
         aP6_Periods=this.AV19Periods;
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
         while ( DateTimeUtil.ResetTime ( AV9FromDate ) <= DateTimeUtil.ResetTime ( AV12ToDate ) )
         {
            AV20Period = new SdtSDTLeaveReport_PeriodCollectionItem(context);
            AV20Period.gxTpr_Fromdate = AV9FromDate;
            if ( AV16PeriodicCategory == 1 )
            {
               AV20Period.gxTpr_Todate = DateTimeUtil.DAdd( AV9FromDate, (6));
               AV20Period.gxTpr_Label = "Week "+context.localUtil.DToC( AV20Period.gxTpr_Fromdate, 2, "/")+" - "+context.localUtil.DToC( AV20Period.gxTpr_Todate, 2, "/");
            }
            else if ( AV16PeriodicCategory == 2 )
            {
               AV20Period.gxTpr_Todate = DateTimeUtil.DateEndOfMonth( AV9FromDate);
               AV20Period.gxTpr_Label = DateTimeUtil.CMonth( AV9FromDate, "eng")+" "+StringUtil.Str( (decimal)(DateTimeUtil.Year( AV9FromDate)), 10, 0);
            }
            else
            {
               AV20Period.gxTpr_Todate = context.localUtil.YMDToD( DateTimeUtil.Year( AV9FromDate), 12, 31);
               AV20Period.gxTpr_Label = "Year "+StringUtil.Str( (decimal)(DateTimeUtil.Year( AV9FromDate)), 10, 0);
            }
            AV20Period.gxTpr_Totalleave = 0;
            AV20Period.gxTpr_Totalwork = 0;
            AV20Period.gxTpr_Number = 0;
            AV20Period.gxTpr_Mean = 0;
            if ( AV16PeriodicCategory == 1 )
            {
               AV9FromDate = DateTimeUtil.DAdd( AV9FromDate, (7));
            }
            else if ( AV16PeriodicCategory == 2 )
            {
               AV9FromDate = DateTimeUtil.DAdd( AV20Period.gxTpr_Todate, (1));
            }
            else
            {
               AV9FromDate = DateTimeUtil.AddYr( AV9FromDate, 1);
            }
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8EmployeeId ,
                                                 AV17LocationId ,
                                                 A106EmployeeId ,
                                                 A157CompanyLocationId ,
                                                 A129LeaveRequestStartDate ,
                                                 AV20Period.gxTpr_Todate ,
                                                 A130LeaveRequestEndDate ,
                                                 AV20Period.gxTpr_Fromdate ,
                                                 A132LeaveRequestStatus } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P006R2 */
            pr_default.execute(0, new Object[] {AV20Period.gxTpr_Todate, AV20Period.gxTpr_Fromdate, AV8EmployeeId, AV17LocationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A124LeaveTypeId = P006R2_A124LeaveTypeId[0];
               A100CompanyId = P006R2_A100CompanyId[0];
               A157CompanyLocationId = P006R2_A157CompanyLocationId[0];
               A106EmployeeId = P006R2_A106EmployeeId[0];
               A130LeaveRequestEndDate = P006R2_A130LeaveRequestEndDate[0];
               A129LeaveRequestStartDate = P006R2_A129LeaveRequestStartDate[0];
               A132LeaveRequestStatus = P006R2_A132LeaveRequestStatus[0];
               A127LeaveRequestId = P006R2_A127LeaveRequestId[0];
               A100CompanyId = P006R2_A100CompanyId[0];
               A157CompanyLocationId = P006R2_A157CompanyLocationId[0];
               if ( DateTimeUtil.ResetTime ( A129LeaveRequestStartDate ) < DateTimeUtil.ResetTime ( AV20Period.gxTpr_Fromdate ) )
               {
                  AV21LeaveStartDate = AV20Period.gxTpr_Fromdate;
               }
               else
               {
                  AV21LeaveStartDate = A129LeaveRequestStartDate;
               }
               if ( DateTimeUtil.ResetTime ( A130LeaveRequestEndDate ) > DateTimeUtil.ResetTime ( AV20Period.gxTpr_Todate ) )
               {
                  AV22LeaveEndDate = AV20Period.gxTpr_Todate;
               }
               else
               {
                  AV22LeaveEndDate = A130LeaveRequestEndDate;
               }
               AV18TotalMinutes = 0;
               while ( DateTimeUtil.ResetTime ( AV21LeaveStartDate ) <= DateTimeUtil.ResetTime ( AV22LeaveEndDate ) )
               {
                  if ( DateTimeUtil.Dow( AV21LeaveStartDate) == 7 )
                  {
                     AV21LeaveStartDate = DateTimeUtil.DAdd( AV21LeaveStartDate, (2));
                  }
                  else if ( (AV23HolidayDates.IndexOf(AV21LeaveStartDate)>0) )
                  {
                     AV21LeaveStartDate = DateTimeUtil.DAdd( AV21LeaveStartDate, (1));
                  }
                  else
                  {
                     AV18TotalMinutes = (long)(AV18TotalMinutes+(8*60));
                     AV21LeaveStartDate = DateTimeUtil.DAdd( AV21LeaveStartDate, (1));
                  }
               }
               AV20Period.gxTpr_Totalleave = (long)(AV20Period.gxTpr_Totalleave+AV18TotalMinutes);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A102ProjectId ,
                                                 AV11ProjectId ,
                                                 AV11ProjectId.Count ,
                                                 AV8EmployeeId ,
                                                 AV17LocationId ,
                                                 A106EmployeeId ,
                                                 A157CompanyLocationId ,
                                                 A119WorkHourLogDate ,
                                                 AV20Period.gxTpr_Todate ,
                                                 AV20Period.gxTpr_Fromdate } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P006R3 */
            pr_default.execute(1, new Object[] {AV20Period.gxTpr_Todate, AV20Period.gxTpr_Fromdate, AV8EmployeeId, AV17LocationId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A100CompanyId = P006R3_A100CompanyId[0];
               A157CompanyLocationId = P006R3_A157CompanyLocationId[0];
               A106EmployeeId = P006R3_A106EmployeeId[0];
               A119WorkHourLogDate = P006R3_A119WorkHourLogDate[0];
               A102ProjectId = P006R3_A102ProjectId[0];
               A122WorkHourLogMinute = P006R3_A122WorkHourLogMinute[0];
               A121WorkHourLogHour = P006R3_A121WorkHourLogHour[0];
               A118WorkHourLogId = P006R3_A118WorkHourLogId[0];
               A100CompanyId = P006R3_A100CompanyId[0];
               A157CompanyLocationId = P006R3_A157CompanyLocationId[0];
               AV20Period.gxTpr_Totalwork = (long)(AV20Period.gxTpr_Totalwork+((A121WorkHourLogHour*60)+A122WorkHourLogMinute));
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV19Periods.Add(AV20Period, 0);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GETSTARTDATE' Routine */
         returnInSub = false;
         if ( AV16PeriodicCategory == 1 )
         {
            if ( DateTimeUtil.Dow( AV9FromDate) > 0 )
            {
               AV9FromDate = DateTimeUtil.DAdd( AV9FromDate, (1-DateTimeUtil.Dow( AV9FromDate)));
            }
            else
            {
               AV9FromDate = DateTimeUtil.DAdd( AV9FromDate, (-6));
            }
         }
         else if ( AV16PeriodicCategory == 2 )
         {
            AV9FromDate = context.localUtil.YMDToD( DateTimeUtil.Year( AV9FromDate), DateTimeUtil.Month( AV9FromDate), 1);
         }
         else
         {
            AV9FromDate = context.localUtil.YMDToD( DateTimeUtil.Year( AV9FromDate), 1, 1);
         }
      }

      protected void S121( )
      {
         /* 'GETHOLIDAYDATES' Routine */
         returnInSub = false;
         /* Using cursor P006R4 */
         pr_default.execute(2, new Object[] {AV17LocationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A100CompanyId = P006R4_A100CompanyId[0];
            A157CompanyLocationId = P006R4_A157CompanyLocationId[0];
            A115HolidayStartDate = P006R4_A115HolidayStartDate[0];
            A113HolidayId = P006R4_A113HolidayId[0];
            A157CompanyLocationId = P006R4_A157CompanyLocationId[0];
            AV23HolidayDates.Add(A115HolidayStartDate, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         AV19Periods = new GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem>( context, "SDTLeaveReport.PeriodCollectionItem", "YTT_version4");
         AV20Period = new SdtSDTLeaveReport_PeriodCollectionItem(context);
         A129LeaveRequestStartDate = DateTime.MinValue;
         A130LeaveRequestEndDate = DateTime.MinValue;
         A132LeaveRequestStatus = "";
         P006R2_A124LeaveTypeId = new long[1] ;
         P006R2_A100CompanyId = new long[1] ;
         P006R2_A157CompanyLocationId = new long[1] ;
         P006R2_A106EmployeeId = new long[1] ;
         P006R2_A130LeaveRequestEndDate = new DateTime[] {DateTime.MinValue} ;
         P006R2_A129LeaveRequestStartDate = new DateTime[] {DateTime.MinValue} ;
         P006R2_A132LeaveRequestStatus = new string[] {""} ;
         P006R2_A127LeaveRequestId = new long[1] ;
         AV21LeaveStartDate = DateTime.MinValue;
         AV22LeaveEndDate = DateTime.MinValue;
         AV23HolidayDates = new GxSimpleCollection<DateTime>();
         A119WorkHourLogDate = DateTime.MinValue;
         P006R3_A100CompanyId = new long[1] ;
         P006R3_A157CompanyLocationId = new long[1] ;
         P006R3_A106EmployeeId = new long[1] ;
         P006R3_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P006R3_A102ProjectId = new long[1] ;
         P006R3_A122WorkHourLogMinute = new short[1] ;
         P006R3_A121WorkHourLogHour = new short[1] ;
         P006R3_A118WorkHourLogId = new long[1] ;
         P006R4_A100CompanyId = new long[1] ;
         P006R4_A157CompanyLocationId = new long[1] ;
         P006R4_A115HolidayStartDate = new DateTime[] {DateTime.MinValue} ;
         P006R4_A113HolidayId = new long[1] ;
         A115HolidayStartDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procgetperiodicleavehours__default(),
            new Object[][] {
                new Object[] {
               P006R2_A124LeaveTypeId, P006R2_A100CompanyId, P006R2_A157CompanyLocationId, P006R2_A106EmployeeId, P006R2_A130LeaveRequestEndDate, P006R2_A129LeaveRequestStartDate, P006R2_A132LeaveRequestStatus, P006R2_A127LeaveRequestId
               }
               , new Object[] {
               P006R3_A100CompanyId, P006R3_A157CompanyLocationId, P006R3_A106EmployeeId, P006R3_A119WorkHourLogDate, P006R3_A102ProjectId, P006R3_A122WorkHourLogMinute, P006R3_A121WorkHourLogHour, P006R3_A118WorkHourLogId
               }
               , new Object[] {
               P006R4_A100CompanyId, P006R4_A157CompanyLocationId, P006R4_A115HolidayStartDate, P006R4_A113HolidayId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16PeriodicCategory ;
      private short A122WorkHourLogMinute ;
      private short A121WorkHourLogHour ;
      private int AV11ProjectId_Count ;
      private long AV8EmployeeId ;
      private long AV17LocationId ;
      private long A106EmployeeId ;
      private long A157CompanyLocationId ;
      private long A124LeaveTypeId ;
      private long A100CompanyId ;
      private long A127LeaveRequestId ;
      private long AV18TotalMinutes ;
      private long A102ProjectId ;
      private long A118WorkHourLogId ;
      private long A113HolidayId ;
      private string A132LeaveRequestStatus ;
      private DateTime AV9FromDate ;
      private DateTime AV12ToDate ;
      private DateTime AV20Period_gxTpr_Todate ;
      private DateTime AV20Period_gxTpr_Fromdate ;
      private DateTime A129LeaveRequestStartDate ;
      private DateTime A130LeaveRequestEndDate ;
      private DateTime AV21LeaveStartDate ;
      private DateTime AV22LeaveEndDate ;
      private DateTime A119WorkHourLogDate ;
      private DateTime A115HolidayStartDate ;
      private bool returnInSub ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV11ProjectId ;
      private GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem> AV19Periods ;
      private SdtSDTLeaveReport_PeriodCollectionItem AV20Period ;
      private IDataStoreProvider pr_default ;
      private long[] P006R2_A124LeaveTypeId ;
      private long[] P006R2_A100CompanyId ;
      private long[] P006R2_A157CompanyLocationId ;
      private long[] P006R2_A106EmployeeId ;
      private DateTime[] P006R2_A130LeaveRequestEndDate ;
      private DateTime[] P006R2_A129LeaveRequestStartDate ;
      private string[] P006R2_A132LeaveRequestStatus ;
      private long[] P006R2_A127LeaveRequestId ;
      private GxSimpleCollection<DateTime> AV23HolidayDates ;
      private long[] P006R3_A100CompanyId ;
      private long[] P006R3_A157CompanyLocationId ;
      private long[] P006R3_A106EmployeeId ;
      private DateTime[] P006R3_A119WorkHourLogDate ;
      private long[] P006R3_A102ProjectId ;
      private short[] P006R3_A122WorkHourLogMinute ;
      private short[] P006R3_A121WorkHourLogHour ;
      private long[] P006R3_A118WorkHourLogId ;
      private long[] P006R4_A100CompanyId ;
      private long[] P006R4_A157CompanyLocationId ;
      private DateTime[] P006R4_A115HolidayStartDate ;
      private long[] P006R4_A113HolidayId ;
      private GXBaseCollection<SdtSDTLeaveReport_PeriodCollectionItem> aP6_Periods ;
   }

   public class procgetperiodicleavehours__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006R2( IGxContext context ,
                                             long AV8EmployeeId ,
                                             long AV17LocationId ,
                                             long A106EmployeeId ,
                                             long A157CompanyLocationId ,
                                             DateTime A129LeaveRequestStartDate ,
                                             DateTime AV20Period_gxTpr_Todate ,
                                             DateTime A130LeaveRequestEndDate ,
                                             DateTime AV20Period_gxTpr_Fromdate ,
                                             string A132LeaveRequestStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.LeaveTypeId, T2.CompanyId, T3.CompanyLocationId, T1.EmployeeId, T1.LeaveRequestEndDate, T1.LeaveRequestStartDate, T1.LeaveRequestStatus, T1.LeaveRequestId FROM ((LeaveRequest T1 INNER JOIN LeaveType T2 ON T2.LeaveTypeId = T1.LeaveTypeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId)";
         AddWhere(sWhereString, "(T1.LeaveRequestStartDate < :AV20Period__Todate and T1.LeaveRequestEndDate > :AV20Period__Fromdate)");
         AddWhere(sWhereString, "(T1.LeaveRequestStatus = ( 'Approved'))");
         if ( ! (0==AV8EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV8EmployeeId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV17LocationId) )
         {
            AddWhere(sWhereString, "(T3.CompanyLocationId = :AV17LocationId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.LeaveRequestId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006R3( IGxContext context ,
                                             long A102ProjectId ,
                                             GxSimpleCollection<long> AV11ProjectId ,
                                             int AV11ProjectId_Count ,
                                             long AV8EmployeeId ,
                                             long AV17LocationId ,
                                             long A106EmployeeId ,
                                             long A157CompanyLocationId ,
                                             DateTime A119WorkHourLogDate ,
                                             DateTime AV20Period_gxTpr_Todate ,
                                             DateTime AV20Period_gxTpr_Fromdate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.CompanyId, T3.CompanyLocationId, T1.EmployeeId, T1.WorkHourLogDate, T1.ProjectId, T1.WorkHourLogMinute, T1.WorkHourLogHour, T1.WorkHourLogId FROM ((WorkHourLog T1 INNER JOIN Employee T2 ON T2.EmployeeId = T1.EmployeeId) INNER JOIN Company T3 ON T3.CompanyId = T2.CompanyId)";
         AddWhere(sWhereString, "(T1.WorkHourLogDate <= :AV20Period__Todate and T1.WorkHourLogDate >= :AV20Period__Fromdate)");
         if ( ! ( AV11ProjectId_Count == 0 ) )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV11ProjectId, "T1.ProjectId IN (", ")")+")");
         }
         if ( ! (0==AV8EmployeeId) )
         {
            AddWhere(sWhereString, "(T1.EmployeeId = :AV8EmployeeId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV17LocationId) )
         {
            AddWhere(sWhereString, "(T3.CompanyLocationId = :AV17LocationId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.WorkHourLogId";
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
                     return conditional_P006R2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] );
               case 1 :
                     return conditional_P006R3(context, (long)dynConstraints[0] , (GxSimpleCollection<long>)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] );
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
          Object[] prmP006R4;
          prmP006R4 = new Object[] {
          new ParDef("AV17LocationId",GXType.Int64,10,0)
          };
          Object[] prmP006R2;
          prmP006R2 = new Object[] {
          new ParDef("AV20Period__Todate",GXType.Date,8,0) ,
          new ParDef("AV20Period__Fromdate",GXType.Date,8,0) ,
          new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV17LocationId",GXType.Int64,10,0)
          };
          Object[] prmP006R3;
          prmP006R3 = new Object[] {
          new ParDef("AV20Period__Todate",GXType.Date,8,0) ,
          new ParDef("AV20Period__Fromdate",GXType.Date,8,0) ,
          new ParDef("AV8EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV17LocationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006R4", "SELECT T1.CompanyId, T2.CompanyLocationId, T1.HolidayStartDate, T1.HolidayId FROM (Holiday T1 INNER JOIN Company T2 ON T2.CompanyId = T1.CompanyId) WHERE T2.CompanyLocationId = :AV17LocationId ORDER BY T1.HolidayId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R4,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
