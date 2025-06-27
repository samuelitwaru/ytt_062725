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
   public class getemployeevactiondaysleft : GXProcedure
   {
      public getemployeevactiondaysleft( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getemployeevactiondaysleft( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out short aP1_EmployeeVacationDays )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9EmployeeVacationDays = 0 ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeVacationDays=this.AV9EmployeeVacationDays;
      }

      public short executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_EmployeeVacationDays);
         return AV9EmployeeVacationDays ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out short aP1_EmployeeVacationDays )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9EmployeeVacationDays = 0 ;
         SubmitImpl();
         aP1_EmployeeVacationDays=this.AV9EmployeeVacationDays;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P007I2 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P007I2_A106EmployeeId[0];
            A147EmployeeBalance = P007I2_A147EmployeeBalance[0];
            AV9EmployeeVacationDays = (short)(Math.Round(A147EmployeeBalance, 18, MidpointRounding.ToEven));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
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
         P007I2_A106EmployeeId = new long[1] ;
         P007I2_A147EmployeeBalance = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getemployeevactiondaysleft__default(),
            new Object[][] {
                new Object[] {
               P007I2_A106EmployeeId, P007I2_A147EmployeeBalance
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9EmployeeVacationDays ;
      private long AV8EmployeeId ;
      private long A106EmployeeId ;
      private decimal A147EmployeeBalance ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P007I2_A106EmployeeId ;
      private decimal[] P007I2_A147EmployeeBalance ;
      private short aP1_EmployeeVacationDays ;
   }

   public class getemployeevactiondaysleft__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007I2;
          prmP007I2 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007I2", "SELECT EmployeeId, EmployeeBalance FROM Employee WHERE EmployeeId = :AV8EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I2,1, GxCacheFrequency.OFF ,false,true )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
       }
    }

 }

}
