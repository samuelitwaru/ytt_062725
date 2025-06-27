using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class employeeloadredundancy : GXProcedure
   {
      public employeeloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public employeeloadredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor EMPLOYEELO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = EMPLOYEELO2_A106EmployeeId[0];
            A147EmployeeBalance = EMPLOYEELO2_A147EmployeeBalance[0];
            GXt_decimal1 = A147EmployeeBalance;
            new prc_getemployeebalance(context ).execute(  A106EmployeeId, out  GXt_decimal1) ;
            A147EmployeeBalance = GXt_decimal1;
            /* Using cursor EMPLOYEELO3 */
            pr_default.execute(1, new Object[] {A147EmployeeBalance, A106EmployeeId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Employee");
            pr_default.readNext(0);
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
         EMPLOYEELO2_A106EmployeeId = new long[1] ;
         EMPLOYEELO2_A147EmployeeBalance = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.employeeloadredundancy__default(),
            new Object[][] {
                new Object[] {
               EMPLOYEELO2_A106EmployeeId, EMPLOYEELO2_A147EmployeeBalance
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A106EmployeeId ;
      private decimal A147EmployeeBalance ;
      private decimal GXt_decimal1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] EMPLOYEELO2_A106EmployeeId ;
      private decimal[] EMPLOYEELO2_A147EmployeeBalance ;
   }

   public class employeeloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmEMPLOYEELO2;
          prmEMPLOYEELO2 = new Object[] {
          };
          Object[] prmEMPLOYEELO3;
          prmEMPLOYEELO3 = new Object[] {
          new ParDef("EmployeeBalance",GXType.Number,4,1) ,
          new ParDef("EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("EMPLOYEELO2", "SELECT EmployeeId, EmployeeBalance FROM Employee ORDER BY EmployeeId  FOR UPDATE OF Employee",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmEMPLOYEELO2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("EMPLOYEELO3", "UPDATE Employee SET EmployeeBalance=:EmployeeBalance  WHERE EmployeeId = :EmployeeId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmEMPLOYEELO3)
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
