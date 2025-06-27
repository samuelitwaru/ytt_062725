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
   public class workhourlogdateduration : GXProcedure
   {
      public workhourlogdateduration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public workhourlogdateduration( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_WorkHourLogDate ,
                           out string aP1_TotalDuration )
      {
         this.AV13WorkHourLogDate = aP0_WorkHourLogDate;
         this.AV9TotalDuration = "" ;
         initialize();
         ExecuteImpl();
         aP1_TotalDuration=this.AV9TotalDuration;
      }

      public string executeUdp( DateTime aP0_WorkHourLogDate )
      {
         execute(aP0_WorkHourLogDate, out aP1_TotalDuration);
         return AV9TotalDuration ;
      }

      public void executeSubmit( DateTime aP0_WorkHourLogDate ,
                                 out string aP1_TotalDuration )
      {
         this.AV13WorkHourLogDate = aP0_WorkHourLogDate;
         this.AV9TotalDuration = "" ;
         SubmitImpl();
         aP1_TotalDuration=this.AV9TotalDuration;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12TotalMinute = 0;
         AV10TotalHour = 0;
         AV15Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /* Using cursor P00892 */
         pr_default.execute(0, new Object[] {AV15Udparg1, AV13WorkHourLogDate});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00892_A106EmployeeId[0];
            A119WorkHourLogDate = P00892_A119WorkHourLogDate[0];
            A122WorkHourLogMinute = P00892_A122WorkHourLogMinute[0];
            A121WorkHourLogHour = P00892_A121WorkHourLogHour[0];
            A118WorkHourLogId = P00892_A118WorkHourLogId[0];
            AV12TotalMinute = (short)(A122WorkHourLogMinute+AV12TotalMinute);
            AV10TotalHour = (short)(A121WorkHourLogHour+AV10TotalHour);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8ModTotalMinute = (short)(((int)((AV12TotalMinute) % (60))));
         AV11TotalHoursAndMinutes = (short)(NumberUtil.Trunc( AV12TotalMinute/ (decimal)(60), 0)+AV10TotalHour);
         if ( AV8ModTotalMinute < 10 )
         {
            AV9TotalDuration = StringUtil.Str( (decimal)(AV11TotalHoursAndMinutes), 4, 0) + ":0" + StringUtil.Trim( StringUtil.Str( (decimal)(AV8ModTotalMinute), 4, 0));
         }
         else
         {
            AV9TotalDuration = StringUtil.Str( (decimal)(AV11TotalHoursAndMinutes), 4, 0) + ":" + StringUtil.Trim( StringUtil.Str( (decimal)(AV8ModTotalMinute), 4, 0));
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
         AV9TotalDuration = "";
         P00892_A106EmployeeId = new long[1] ;
         P00892_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00892_A122WorkHourLogMinute = new short[1] ;
         P00892_A121WorkHourLogHour = new short[1] ;
         P00892_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workhourlogdateduration__default(),
            new Object[][] {
                new Object[] {
               P00892_A106EmployeeId, P00892_A119WorkHourLogDate, P00892_A122WorkHourLogMinute, P00892_A121WorkHourLogHour, P00892_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12TotalMinute ;
      private short AV10TotalHour ;
      private short A122WorkHourLogMinute ;
      private short A121WorkHourLogHour ;
      private short AV8ModTotalMinute ;
      private short AV11TotalHoursAndMinutes ;
      private long AV15Udparg1 ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private DateTime AV13WorkHourLogDate ;
      private DateTime A119WorkHourLogDate ;
      private string AV9TotalDuration ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00892_A106EmployeeId ;
      private DateTime[] P00892_A119WorkHourLogDate ;
      private short[] P00892_A122WorkHourLogMinute ;
      private short[] P00892_A121WorkHourLogHour ;
      private long[] P00892_A118WorkHourLogId ;
      private string aP1_TotalDuration ;
   }

   public class workhourlogdateduration__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00892;
          prmP00892 = new Object[] {
          new ParDef("AV15Udparg1",GXType.Int64,10,0) ,
          new ParDef("AV13WorkHourLogDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00892", "SELECT EmployeeId, WorkHourLogDate, WorkHourLogMinute, WorkHourLogHour, WorkHourLogId FROM WorkHourLog WHERE (EmployeeId = :AV15Udparg1) AND (WorkHourLogDate = :AV13WorkHourLogDate) ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00892,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
