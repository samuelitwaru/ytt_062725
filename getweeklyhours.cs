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
   public class getweeklyhours : GXProcedure
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
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public getweeklyhours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getweeklyhours( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( [GxJsonFormat("yyyy-MM-dd")] DateTime aP0_WeekDate ,
                           long aP1_EmployeeId ,
                           out string aP2_WeeklyTotal ,
                           out string aP3_DailyTotal ,
                           out string aP4_MonthlyTotal )
      {
         this.AV25WeekDate = aP0_WeekDate;
         this.AV36EmployeeId = aP1_EmployeeId;
         this.AV26WeeklyTotal = "" ;
         this.AV8DailyTotal = "" ;
         this.AV31MonthlyTotal = "" ;
         initialize();
         ExecuteImpl();
         aP2_WeeklyTotal=this.AV26WeeklyTotal;
         aP3_DailyTotal=this.AV8DailyTotal;
         aP4_MonthlyTotal=this.AV31MonthlyTotal;
      }

      public string executeUdp( DateTime aP0_WeekDate ,
                                long aP1_EmployeeId ,
                                out string aP2_WeeklyTotal ,
                                out string aP3_DailyTotal )
      {
         execute(aP0_WeekDate, aP1_EmployeeId, out aP2_WeeklyTotal, out aP3_DailyTotal, out aP4_MonthlyTotal);
         return AV31MonthlyTotal ;
      }

      public void executeSubmit( DateTime aP0_WeekDate ,
                                 long aP1_EmployeeId ,
                                 out string aP2_WeeklyTotal ,
                                 out string aP3_DailyTotal ,
                                 out string aP4_MonthlyTotal )
      {
         this.AV25WeekDate = aP0_WeekDate;
         this.AV36EmployeeId = aP1_EmployeeId;
         this.AV26WeeklyTotal = "" ;
         this.AV8DailyTotal = "" ;
         this.AV31MonthlyTotal = "" ;
         SubmitImpl();
         aP2_WeeklyTotal=this.AV26WeeklyTotal;
         aP3_DailyTotal=this.AV8DailyTotal;
         aP4_MonthlyTotal=this.AV31MonthlyTotal;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21TotalHour = 0;
         AV24TotalMinute = 0;
         AV35TotalMonthlyHour = 0;
         AV33TotalMonthlyMinute = 0;
         AV27TotalDailyHour = 0;
         AV28TotalDailyMinute = 0;
         if ( DateTimeUtil.Dow( AV25WeekDate) == 2 )
         {
            AV17StartDate = AV25WeekDate;
            AV11EndDate = DateTimeUtil.DAdd( AV25WeekDate, (6));
         }
         else
         {
            if ( DateTimeUtil.Dow( AV25WeekDate) == 1 )
            {
               AV17StartDate = DateTimeUtil.DAdd( AV25WeekDate, (-6));
               AV11EndDate = DateTimeUtil.DAdd( AV17StartDate, (6));
            }
            else
            {
               AV9daysToStart = (short)(DateTimeUtil.Dow( AV25WeekDate)-2);
               AV17StartDate = DateTimeUtil.DAdd( AV25WeekDate, (-AV9daysToStart));
               AV11EndDate = DateTimeUtil.DAdd( AV17StartDate, (6));
            }
         }
         /* Using cursor P008A2 */
         pr_default.execute(0, new Object[] {AV36EmployeeId, AV25WeekDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A119WorkHourLogDate = P008A2_A119WorkHourLogDate[0];
            A106EmployeeId = P008A2_A106EmployeeId[0];
            A121WorkHourLogHour = P008A2_A121WorkHourLogHour[0];
            A122WorkHourLogMinute = P008A2_A122WorkHourLogMinute[0];
            A118WorkHourLogId = P008A2_A118WorkHourLogId[0];
            AV35TotalMonthlyHour = (short)(AV35TotalMonthlyHour+A121WorkHourLogHour);
            AV33TotalMonthlyMinute = (short)(AV33TotalMonthlyMinute+A122WorkHourLogMinute);
            if ( ( DateTimeUtil.ResetTime ( A119WorkHourLogDate ) >= DateTimeUtil.ResetTime ( AV17StartDate ) ) && ( DateTimeUtil.ResetTime ( A119WorkHourLogDate ) <= DateTimeUtil.ResetTime ( AV11EndDate ) ) )
            {
               AV21TotalHour = (short)(AV21TotalHour+A121WorkHourLogHour);
               AV24TotalMinute = (short)(AV24TotalMinute+A122WorkHourLogMinute);
            }
            if ( DateTimeUtil.ResetTime ( A119WorkHourLogDate ) == DateTimeUtil.ResetTime ( AV25WeekDate ) )
            {
               AV27TotalDailyHour = (short)(AV27TotalDailyHour+A121WorkHourLogHour);
               AV28TotalDailyMinute = (short)(AV28TotalDailyMinute+A122WorkHourLogMinute);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV34ModTotalMonthlyMinute = (short)(((int)((AV33TotalMonthlyMinute) % (60))));
         AV32TotalMonthlyHoursAndMinutes = (short)(NumberUtil.Trunc( AV33TotalMonthlyMinute/ (decimal)(60), 0)+AV35TotalMonthlyHour);
         if ( AV32TotalMonthlyHoursAndMinutes < 10 )
         {
            AV37TotalMonthlyHoursAndMinutesString = "0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV32TotalMonthlyHoursAndMinutes), 4, 0));
         }
         else
         {
            AV37TotalMonthlyHoursAndMinutesString = StringUtil.Trim( StringUtil.Str( (decimal)(AV32TotalMonthlyHoursAndMinutes), 4, 0));
         }
         if ( AV34ModTotalMonthlyMinute < 10 )
         {
            AV38ModTotalMonthlyMinuteString = "0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV34ModTotalMonthlyMinute), 4, 0));
         }
         else
         {
            AV38ModTotalMonthlyMinuteString = StringUtil.Trim( StringUtil.Str( (decimal)(AV34ModTotalMonthlyMinute), 4, 0));
         }
         AV31MonthlyTotal = AV37TotalMonthlyHoursAndMinutesString + ":" + AV38ModTotalMonthlyMinuteString;
         AV13ModTotalMinute = (short)(((int)((AV24TotalMinute) % (60))));
         AV23TotalHoursAndMinutes = (short)(NumberUtil.Trunc( AV24TotalMinute/ (decimal)(60), 0)+AV21TotalHour);
         if ( AV23TotalHoursAndMinutes < 10 )
         {
            AV39TotalHoursAndMinutesString = "0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV23TotalHoursAndMinutes), 4, 0));
         }
         else
         {
            AV39TotalHoursAndMinutesString = StringUtil.Trim( StringUtil.Str( (decimal)(AV23TotalHoursAndMinutes), 4, 0));
         }
         if ( AV13ModTotalMinute < 10 )
         {
            AV40ModTotalMinuteString = "0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV13ModTotalMinute), 4, 0));
         }
         else
         {
            AV40ModTotalMinuteString = StringUtil.Trim( StringUtil.Str( (decimal)(AV13ModTotalMinute), 4, 0));
         }
         AV26WeeklyTotal = AV39TotalHoursAndMinutesString + ":" + AV40ModTotalMinuteString;
         AV29ModTotalDailyMinute = (short)(((int)((AV28TotalDailyMinute) % (60))));
         AV30TotalDailyHoursAndMinutes = (short)(NumberUtil.Trunc( AV28TotalDailyMinute/ (decimal)(60), 0)+AV27TotalDailyHour);
         if ( AV30TotalDailyHoursAndMinutes < 10 )
         {
            AV41TotalDailyHoursAndMinutesString = "0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV30TotalDailyHoursAndMinutes), 4, 0));
         }
         else
         {
            AV41TotalDailyHoursAndMinutesString = StringUtil.Trim( StringUtil.Str( (decimal)(AV30TotalDailyHoursAndMinutes), 4, 0));
         }
         if ( AV29ModTotalDailyMinute < 10 )
         {
            AV42ModTotalDailyMinuteString = "0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV29ModTotalDailyMinute), 4, 0));
         }
         else
         {
            AV42ModTotalDailyMinuteString = StringUtil.Trim( StringUtil.Str( (decimal)(AV29ModTotalDailyMinute), 4, 0));
         }
         AV8DailyTotal = AV41TotalDailyHoursAndMinutesString + ":" + AV42ModTotalDailyMinuteString;
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
         AV26WeeklyTotal = "";
         AV8DailyTotal = "";
         AV31MonthlyTotal = "";
         AV17StartDate = DateTime.MinValue;
         AV11EndDate = DateTime.MinValue;
         P008A2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P008A2_A106EmployeeId = new long[1] ;
         P008A2_A121WorkHourLogHour = new short[1] ;
         P008A2_A122WorkHourLogMinute = new short[1] ;
         P008A2_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         AV37TotalMonthlyHoursAndMinutesString = "";
         AV38ModTotalMonthlyMinuteString = "";
         AV39TotalHoursAndMinutesString = "";
         AV40ModTotalMinuteString = "";
         AV41TotalDailyHoursAndMinutesString = "";
         AV42ModTotalDailyMinuteString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getweeklyhours__default(),
            new Object[][] {
                new Object[] {
               P008A2_A119WorkHourLogDate, P008A2_A106EmployeeId, P008A2_A121WorkHourLogHour, P008A2_A122WorkHourLogMinute, P008A2_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21TotalHour ;
      private short AV24TotalMinute ;
      private short AV35TotalMonthlyHour ;
      private short AV33TotalMonthlyMinute ;
      private short AV27TotalDailyHour ;
      private short AV28TotalDailyMinute ;
      private short AV9daysToStart ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private short AV34ModTotalMonthlyMinute ;
      private short AV32TotalMonthlyHoursAndMinutes ;
      private short AV13ModTotalMinute ;
      private short AV23TotalHoursAndMinutes ;
      private short AV29ModTotalDailyMinute ;
      private short AV30TotalDailyHoursAndMinutes ;
      private long AV36EmployeeId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private string AV26WeeklyTotal ;
      private string AV8DailyTotal ;
      private string AV31MonthlyTotal ;
      private DateTime AV25WeekDate ;
      private DateTime AV17StartDate ;
      private DateTime AV11EndDate ;
      private DateTime A119WorkHourLogDate ;
      private string AV37TotalMonthlyHoursAndMinutesString ;
      private string AV38ModTotalMonthlyMinuteString ;
      private string AV39TotalHoursAndMinutesString ;
      private string AV40ModTotalMinuteString ;
      private string AV41TotalDailyHoursAndMinutesString ;
      private string AV42ModTotalDailyMinuteString ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P008A2_A119WorkHourLogDate ;
      private long[] P008A2_A106EmployeeId ;
      private short[] P008A2_A121WorkHourLogHour ;
      private short[] P008A2_A122WorkHourLogMinute ;
      private long[] P008A2_A118WorkHourLogId ;
      private string aP2_WeeklyTotal ;
      private string aP3_DailyTotal ;
      private string aP4_MonthlyTotal ;
   }

   public class getweeklyhours__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008A2;
          prmP008A2 = new Object[] {
          new ParDef("AV36EmployeeId",GXType.Int64,10,0) ,
          new ParDef("AV25WeekDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008A2", "SELECT WorkHourLogDate, EmployeeId, WorkHourLogHour, WorkHourLogMinute, WorkHourLogId FROM WorkHourLog WHERE (EmployeeId = :AV36EmployeeId) AND (date_part('month', WorkHourLogDate) = date_part('month', :AV25WeekDate)) AND (date_part('year', WorkHourLogDate) = date_part('year', :AV25WeekDate)) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
