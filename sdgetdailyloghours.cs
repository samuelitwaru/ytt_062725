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
   public class sdgetdailyloghours : GXProcedure
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

      public sdgetdailyloghours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sdgetdailyloghours( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GxSimpleCollection<decimal> aP0_dailyLogs )
      {
         this.AV11dailyLogs = new GxSimpleCollection<decimal>() ;
         initialize();
         ExecuteImpl();
         aP0_dailyLogs=this.AV11dailyLogs;
      }

      public GxSimpleCollection<decimal> executeUdp( )
      {
         execute(out aP0_dailyLogs);
         return AV11dailyLogs ;
      }

      public void executeSubmit( out GxSimpleCollection<decimal> aP0_dailyLogs )
      {
         this.AV11dailyLogs = new GxSimpleCollection<decimal>() ;
         SubmitImpl();
         aP0_dailyLogs=this.AV11dailyLogs;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23TotalHour = 0;
         AV25TotalMinute = 0;
         AV17ModTotalMinute = 0;
         AV24TotalHoursAndMinutes = 0;
         AV11dailyLogs = (GxSimpleCollection<decimal>)(new GxSimpleCollection<decimal>());
         if ( DateTimeUtil.Dow( Gx_date) == 1 )
         {
            AV21StartDate = Gx_date;
            AV19num1 = AV12dayNumber;
         }
         else
         {
            AV13daysToStart = (short)(DateTimeUtil.Dow( Gx_date)-1);
            AV21StartDate = DateTimeUtil.DAdd( Gx_date, (-AV13daysToStart));
            AV19num1 = (short)(AV12dayNumber-1);
         }
         AV10count = 0;
         while ( AV10count <= 6 )
         {
            AV23TotalHour = 0;
            AV25TotalMinute = 0;
            AV17ModTotalMinute = 0;
            AV24TotalHoursAndMinutes = 0;
            AV22TotalDuration = 0;
            AV20searchDate = DateTimeUtil.DAdd( AV21StartDate, (AV10count));
            AV27GXLvl32 = 0;
            AV28Udparg1 = new getloggedinemployeeid(context).executeUdp( );
            /* Using cursor P005Z2 */
            pr_default.execute(0, new Object[] {AV20searchDate, AV28Udparg1});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A119WorkHourLogDate = P005Z2_A119WorkHourLogDate[0];
               A106EmployeeId = P005Z2_A106EmployeeId[0];
               A121WorkHourLogHour = P005Z2_A121WorkHourLogHour[0];
               A122WorkHourLogMinute = P005Z2_A122WorkHourLogMinute[0];
               A118WorkHourLogId = P005Z2_A118WorkHourLogId[0];
               AV27GXLvl32 = 1;
               AV23TotalHour = (short)(AV23TotalHour+A121WorkHourLogHour);
               AV25TotalMinute = (short)(AV25TotalMinute+A122WorkHourLogMinute);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV27GXLvl32 == 0 )
            {
               AV23TotalHour = 0;
               AV25TotalMinute = 0;
            }
            AV17ModTotalMinute = (short)(((int)((AV25TotalMinute) % (60))));
            AV24TotalHoursAndMinutes = (short)(NumberUtil.Trunc( AV25TotalMinute/ (decimal)(60), 0)+AV23TotalHour);
            AV22TotalDuration = (decimal)(AV24TotalHoursAndMinutes+(AV17ModTotalMinute/ (decimal)(60)));
            AV11dailyLogs.Add(AV22TotalDuration, 0);
            AV10count = (short)(AV10count+1);
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

      public override void initialize( )
      {
         AV11dailyLogs = new GxSimpleCollection<decimal>();
         Gx_date = DateTime.MinValue;
         AV21StartDate = DateTime.MinValue;
         AV20searchDate = DateTime.MinValue;
         P005Z2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P005Z2_A106EmployeeId = new long[1] ;
         P005Z2_A121WorkHourLogHour = new short[1] ;
         P005Z2_A122WorkHourLogMinute = new short[1] ;
         P005Z2_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdgetdailyloghours__default(),
            new Object[][] {
                new Object[] {
               P005Z2_A119WorkHourLogDate, P005Z2_A106EmployeeId, P005Z2_A121WorkHourLogHour, P005Z2_A122WorkHourLogMinute, P005Z2_A118WorkHourLogId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV23TotalHour ;
      private short AV25TotalMinute ;
      private short AV17ModTotalMinute ;
      private short AV24TotalHoursAndMinutes ;
      private short AV19num1 ;
      private short AV12dayNumber ;
      private short AV13daysToStart ;
      private short AV10count ;
      private short AV27GXLvl32 ;
      private short A121WorkHourLogHour ;
      private short A122WorkHourLogMinute ;
      private long AV28Udparg1 ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private decimal AV22TotalDuration ;
      private DateTime Gx_date ;
      private DateTime AV21StartDate ;
      private DateTime AV20searchDate ;
      private DateTime A119WorkHourLogDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<decimal> AV11dailyLogs ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P005Z2_A119WorkHourLogDate ;
      private long[] P005Z2_A106EmployeeId ;
      private short[] P005Z2_A121WorkHourLogHour ;
      private short[] P005Z2_A122WorkHourLogMinute ;
      private long[] P005Z2_A118WorkHourLogId ;
      private GxSimpleCollection<decimal> aP0_dailyLogs ;
   }

   public class sdgetdailyloghours__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005Z2;
          prmP005Z2 = new Object[] {
          new ParDef("AV20searchDate",GXType.Date,8,0) ,
          new ParDef("AV28Udparg1",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005Z2", "SELECT WorkHourLogDate, EmployeeId, WorkHourLogHour, WorkHourLogMinute, WorkHourLogId FROM WorkHourLog WHERE (WorkHourLogDate = :AV20searchDate) AND (EmployeeId = :AV28Udparg1) ORDER BY WorkHourLogDate ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005Z2,100, GxCacheFrequency.OFF ,false,false )
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
