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
   public class sdgetweekhours : GXProcedure
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

      public sdgetweekhours( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sdgetweekhours( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_TotalDuration ,
                           out short aP1_TotalHoursAndMinutes )
      {
         this.AV15TotalDuration = "" ;
         this.AV8TotalHoursAndMinutes = 0 ;
         initialize();
         ExecuteImpl();
         aP0_TotalDuration=this.AV15TotalDuration;
         aP1_TotalHoursAndMinutes=this.AV8TotalHoursAndMinutes;
      }

      public short executeUdp( out string aP0_TotalDuration )
      {
         execute(out aP0_TotalDuration, out aP1_TotalHoursAndMinutes);
         return AV8TotalHoursAndMinutes ;
      }

      public void executeSubmit( out string aP0_TotalDuration ,
                                 out short aP1_TotalHoursAndMinutes )
      {
         this.AV15TotalDuration = "" ;
         this.AV8TotalHoursAndMinutes = 0 ;
         SubmitImpl();
         aP0_TotalDuration=this.AV15TotalDuration;
         aP1_TotalHoursAndMinutes=this.AV8TotalHoursAndMinutes;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16TotalHour = 0;
         AV9TotalMinute = 0;
         if ( DateTimeUtil.Dow( Gx_date) == 1 )
         {
            AV14StartDate = Gx_date;
            AV11EndDate = DateTimeUtil.DAdd( Gx_date, (6));
         }
         else
         {
            AV10daysToStart = (short)(DateTimeUtil.Dow( Gx_date)-1);
            AV14StartDate = DateTimeUtil.DAdd( Gx_date, (-AV10daysToStart));
            AV11EndDate = DateTimeUtil.DAdd( AV14StartDate, (6));
         }
         AV26Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /* Optimized group. */
         /* Using cursor P005H2 */
         pr_default.execute(0, new Object[] {AV14StartDate, AV26Udparg1, AV11EndDate});
         c121WorkHourLogHour = P005H2_A121WorkHourLogHour[0];
         c122WorkHourLogMinute = P005H2_A122WorkHourLogMinute[0];
         pr_default.close(0);
         AV16TotalHour = (short)(AV16TotalHour+c121WorkHourLogHour);
         AV9TotalMinute = (short)(AV9TotalMinute+c122WorkHourLogMinute);
         /* End optimized group. */
         AV12ModTotalMinute = (short)(((int)((AV9TotalMinute) % (60))));
         AV8TotalHoursAndMinutes = (short)(NumberUtil.Trunc( AV9TotalMinute/ (decimal)(60), 0)+AV16TotalHour);
         if ( AV12ModTotalMinute < 10 )
         {
            AV15TotalDuration = StringUtil.Str( (decimal)(AV8TotalHoursAndMinutes), 4, 0) + ":0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV12ModTotalMinute), 4, 0)) + "hrs";
         }
         else
         {
            AV15TotalDuration = StringUtil.Str( (decimal)(AV8TotalHoursAndMinutes), 4, 0) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV12ModTotalMinute), 4, 0)) + "hrs";
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
         Gx_date = DateTime.MinValue;
         AV14StartDate = DateTime.MinValue;
         AV11EndDate = DateTime.MinValue;
         P005H2_A121WorkHourLogHour = new short[1] ;
         P005H2_A122WorkHourLogMinute = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdgetweekhours__default(),
            new Object[][] {
                new Object[] {
               P005H2_A121WorkHourLogHour, P005H2_A122WorkHourLogMinute
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV8TotalHoursAndMinutes ;
      private short AV16TotalHour ;
      private short AV9TotalMinute ;
      private short AV10daysToStart ;
      private short c121WorkHourLogHour ;
      private short c122WorkHourLogMinute ;
      private short AV12ModTotalMinute ;
      private long AV26Udparg1 ;
      private string AV15TotalDuration ;
      private DateTime Gx_date ;
      private DateTime AV14StartDate ;
      private DateTime AV11EndDate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005H2_A121WorkHourLogHour ;
      private short[] P005H2_A122WorkHourLogMinute ;
      private string aP0_TotalDuration ;
      private short aP1_TotalHoursAndMinutes ;
   }

   public class sdgetweekhours__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005H2;
          prmP005H2 = new Object[] {
          new ParDef("AV14StartDate",GXType.Date,8,0) ,
          new ParDef("AV26Udparg1",GXType.Int64,10,0) ,
          new ParDef("AV11EndDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005H2", "SELECT SUM(WorkHourLogHour), SUM(WorkHourLogMinute) FROM WorkHourLog WHERE (WorkHourLogDate >= :AV14StartDate) AND (EmployeeId = :AV26Udparg1) AND (WorkHourLogDate <= :AV11EndDate) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005H2,1, GxCacheFrequency.OFF ,true,false )
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
