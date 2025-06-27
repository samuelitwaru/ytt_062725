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
   public class getlastworkhourlogdate : GXProcedure
   {
      public getlastworkhourlogdate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getlastworkhourlogdate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out DateTime aP1_FinalWorkHourlogDate )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV10FinalWorkHourlogDate = DateTime.MinValue ;
         initialize();
         ExecuteImpl();
         aP1_FinalWorkHourlogDate=this.AV10FinalWorkHourlogDate;
      }

      public DateTime executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_FinalWorkHourlogDate);
         return AV10FinalWorkHourlogDate ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out DateTime aP1_FinalWorkHourlogDate )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV10FinalWorkHourlogDate = DateTime.MinValue ;
         SubmitImpl();
         aP1_FinalWorkHourlogDate=this.AV10FinalWorkHourlogDate;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11GXLvl1 = 0;
         /* Using cursor P00AD2 */
         pr_default.execute(0, new Object[] {AV9EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00AD2_A106EmployeeId[0];
            A119WorkHourLogDate = P00AD2_A119WorkHourLogDate[0];
            A118WorkHourLogId = P00AD2_A118WorkHourLogId[0];
            AV11GXLvl1 = 1;
            AV10FinalWorkHourlogDate = DateTimeUtil.DAdd( A119WorkHourLogDate, (1));
            if ( ( ( ( DateTimeUtil.Dow( A119WorkHourLogDate) == 1 ) || ( DateTimeUtil.Dow( A119WorkHourLogDate) >= 6 ) ) && ( DateTimeUtil.Dow( Gx_date) == 2 ) ) || ( DateTimeUtil.ResetTime ( AV10FinalWorkHourlogDate ) > DateTimeUtil.ResetTime ( Gx_date ) ) )
            {
               AV10FinalWorkHourlogDate = Gx_date;
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11GXLvl1 == 0 )
         {
            AV10FinalWorkHourlogDate = Gx_date;
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
         AV10FinalWorkHourlogDate = DateTime.MinValue;
         P00AD2_A106EmployeeId = new long[1] ;
         P00AD2_A119WorkHourLogDate = new DateTime[] {DateTime.MinValue} ;
         P00AD2_A118WorkHourLogId = new long[1] ;
         A119WorkHourLogDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getlastworkhourlogdate__default(),
            new Object[][] {
                new Object[] {
               P00AD2_A106EmployeeId, P00AD2_A119WorkHourLogDate, P00AD2_A118WorkHourLogId
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV11GXLvl1 ;
      private long AV9EmployeeId ;
      private long A106EmployeeId ;
      private long A118WorkHourLogId ;
      private DateTime AV10FinalWorkHourlogDate ;
      private DateTime A119WorkHourLogDate ;
      private DateTime Gx_date ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00AD2_A106EmployeeId ;
      private DateTime[] P00AD2_A119WorkHourLogDate ;
      private long[] P00AD2_A118WorkHourLogId ;
      private DateTime aP1_FinalWorkHourlogDate ;
   }

   public class getlastworkhourlogdate__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AD2;
          prmP00AD2 = new Object[] {
          new ParDef("AV9EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AD2", "SELECT EmployeeId, WorkHourLogDate, WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :AV9EmployeeId ORDER BY WorkHourLogDate DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AD2,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
