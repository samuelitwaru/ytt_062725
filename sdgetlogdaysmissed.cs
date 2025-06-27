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
   public class sdgetlogdaysmissed : GXProcedure
   {
      public sdgetlogdaysmissed( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sdgetlogdaysmissed( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_totalDaysMissed )
      {
         this.AV15totalDaysMissed = 0 ;
         initialize();
         ExecuteImpl();
         aP0_totalDaysMissed=this.AV15totalDaysMissed;
      }

      public short executeUdp( )
      {
         execute(out aP0_totalDaysMissed);
         return AV15totalDaysMissed ;
      }

      public void executeSubmit( out short aP0_totalDaysMissed )
      {
         this.AV15totalDaysMissed = 0 ;
         SubmitImpl();
         aP0_totalDaysMissed=this.AV15totalDaysMissed;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15totalDaysMissed = 0;
         AV9EndDate = DateTimeUtil.DateEndOfMonth( Gx_date);
         AV11lastMonthTodayDate = DateTimeUtil.AddMth( Gx_date, -1);
         AV10endOfLastMonthDate = DateTimeUtil.DateEndOfMonth( AV11lastMonthTodayDate);
         AV12StartDate = DateTimeUtil.DAdd( AV10endOfLastMonthDate, (1));
         AV14StartMonthDate = AV12StartDate;
         while ( DateTimeUtil.ResetTime ( AV14StartMonthDate ) < DateTimeUtil.ResetTime ( Gx_date ) )
         {
            AV8CurrentDate = AV14StartMonthDate;
            AV17GXLvl15 = 0;
            AV18Udparg1 = new getloggedinemployeeid(context).executeUdp( );
            /* Using cursor P005R2 */
            pr_default.execute(0, new Object[] {AV18Udparg1, AV8CurrentDate});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A119WorkHourLogDate = P005R2_A119WorkHourLogDate[0];
               A106EmployeeId = P005R2_A106EmployeeId[0];
               A118WorkHourLogId = P005R2_A118WorkHourLogId[0];
               AV17GXLvl15 = 1;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV17GXLvl15 == 0 )
            {
               if ( ( ( DateTimeUtil.Dow( AV8CurrentDate) == 1 ) ) || ( ( DateTimeUtil.Dow( AV8CurrentDate) == 7 ) ) )
               {
               }
               else
               {
                  AV15totalDaysMissed = (short)(AV15totalDaysMissed+1);
               }
            }
            AV14StartMonthDate = DateTimeUtil.DAdd( AV14StartMonthDate, (1));
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
         AV9EndDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV11lastMonthTodayDate = DateTime.MinValue;
         AV10endOfLastMonthDate = DateTime.MinValue;
         AV12StartDate = DateTime.MinValue;
         AV14StartMonthDate = DateTime.MinValue;
         AV8CurrentDate = DateTime.MinValue;
         P005R2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P005R2_A106EmployeeId = new long[1] ;
         P005R2_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdgetlogdaysmissed__default(),
            new Object[][] {
                new Object[] {
               P005R2_A119WorkHourLogDate, P005R2_A106EmployeeId, P005R2_A118WorkHourLogId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV15totalDaysMissed ;
      private short AV17GXLvl15 ;
      private long AV18Udparg1 ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private DateTime AV9EndDate ;
      private DateTime Gx_date ;
      private DateTime AV11lastMonthTodayDate ;
      private DateTime AV10endOfLastMonthDate ;
      private DateTime AV12StartDate ;
      private DateTime AV14StartMonthDate ;
      private DateTime AV8CurrentDate ;
      private DateTime A119WorkHourLogDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P005R2_A119WorkHourLogDate ;
      private long[] P005R2_A106EmployeeId ;
      private long[] P005R2_A118WorkHourLogId ;
      private short aP0_totalDaysMissed ;
   }

   public class sdgetlogdaysmissed__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005R2;
          prmP005R2 = new Object[] {
          new ParDef("AV18Udparg1",GXType.Int64,10,0) ,
          new ParDef("AV8CurrentDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005R2", "SELECT WorkHourLogDate, EmployeeId, WorkHourLogId FROM WorkHourLog WHERE (EmployeeId = :AV18Udparg1) AND (WorkHourLogDate = :AV8CurrentDate) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005R2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
