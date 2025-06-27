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
   public class sdgetmonthhours : GXProcedure
   {
      public sdgetmonthhours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sdgetmonthhours( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_TotalDuration )
      {
         this.AV15TotalDuration = "" ;
         initialize();
         ExecuteImpl();
         aP0_TotalDuration=this.AV15TotalDuration;
      }

      public string executeUdp( )
      {
         execute(out aP0_TotalDuration);
         return AV15TotalDuration ;
      }

      public void executeSubmit( out string aP0_TotalDuration )
      {
         this.AV15TotalDuration = "" ;
         SubmitImpl();
         aP0_TotalDuration=this.AV15TotalDuration;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13TotalHour = 0;
         AV14TotalMinute = 0;
         AV9EndDate = DateTimeUtil.DateEndOfMonth( Gx_date);
         AV17lastMonthTodayDate = DateTimeUtil.AddMth( Gx_date, -1);
         AV18endOfLastMonthDate = DateTimeUtil.DateEndOfMonth( AV17lastMonthTodayDate);
         AV12StartDate = DateTimeUtil.DAdd( AV18endOfLastMonthDate, (1));
         AV21Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /* Optimized group. */
         /* Using cursor P005S2 */
         pr_default.execute(0, new Object[] {AV21Udparg1, AV12StartDate, AV9EndDate});
         c121WorkHourLogHour = P005S2_A121WorkHourLogHour[0];
         c122WorkHourLogMinute = P005S2_A122WorkHourLogMinute[0];
         pr_default.close(0);
         AV13TotalHour = (short)(AV13TotalHour+c121WorkHourLogHour);
         AV14TotalMinute = (short)(AV14TotalMinute+c122WorkHourLogMinute);
         /* End optimized group. */
         AV10ModTotalMinute = (short)(((int)((AV14TotalMinute) % (60))));
         AV16TotalHoursAndMinutes = (short)(NumberUtil.Trunc( AV14TotalMinute/ (decimal)(60), 0)+AV13TotalHour);
         if ( AV10ModTotalMinute < 10 )
         {
            AV15TotalDuration = StringUtil.Str( (decimal)(AV16TotalHoursAndMinutes), 4, 0) + "h:0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV10ModTotalMinute), 4, 0)) + "m";
         }
         else
         {
            AV15TotalDuration = StringUtil.Str( (decimal)(AV16TotalHoursAndMinutes), 4, 0) + "h:" + StringUtil.Trim( StringUtil.Str( (decimal)(AV10ModTotalMinute), 4, 0)) + "m";
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
         AV15TotalDuration = "";
         AV9EndDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV17lastMonthTodayDate = DateTime.MinValue;
         AV18endOfLastMonthDate = DateTime.MinValue;
         AV12StartDate = DateTime.MinValue;
         P005S2_A121WorkHourLogHour = new short[1] ;
         P005S2_A122WorkHourLogMinute = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdgetmonthhours__default(),
            new Object[][] {
                new Object[] {
               P005S2_A121WorkHourLogHour, P005S2_A122WorkHourLogMinute
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV13TotalHour ;
      private short AV14TotalMinute ;
      private short c121WorkHourLogHour ;
      private short c122WorkHourLogMinute ;
      private short AV10ModTotalMinute ;
      private short AV16TotalHoursAndMinutes ;
      private long AV21Udparg1 ;
      private string AV15TotalDuration ;
      private DateTime AV9EndDate ;
      private DateTime Gx_date ;
      private DateTime AV17lastMonthTodayDate ;
      private DateTime AV18endOfLastMonthDate ;
      private DateTime AV12StartDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005S2_A121WorkHourLogHour ;
      private short[] P005S2_A122WorkHourLogMinute ;
      private string aP0_TotalDuration ;
   }

   public class sdgetmonthhours__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005S2;
          prmP005S2 = new Object[] {
          new ParDef("AV21Udparg1",GXType.Int64,10,0) ,
          new ParDef("AV12StartDate",GXType.Date,8,0) ,
          new ParDef("AV9EndDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005S2", "SELECT SUM(WorkHourLogHour), SUM(WorkHourLogMinute) FROM WorkHourLog WHERE (EmployeeId = :AV21Udparg1) AND (WorkHourLogDate >= :AV12StartDate and WorkHourLogDate <= :AV9EndDate) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S2,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
