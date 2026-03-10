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
   public class prc_setemployeeworkingdays : GXProcedure
   {
      public prc_setemployeeworkingdays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_setemployeeworkingdays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           string aP1_EmployeeWorkingDays )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV10EmployeeWorkingDays = aP1_EmployeeWorkingDays;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 string aP1_EmployeeWorkingDays )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV10EmployeeWorkingDays = aP1_EmployeeWorkingDays;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new logtofile(context ).execute(  "SETTING"+StringUtil.Str( (decimal)(AV9EmployeeId), 10, 0)) ;
         /* Using cursor P00C52 */
         pr_default.execute(0, new Object[] {AV9EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTC52 = 0;
            A106EmployeeId = P00C52_A106EmployeeId[0];
            A212EmployeeWorkingDays = P00C52_A212EmployeeWorkingDays[0];
            n212EmployeeWorkingDays = P00C52_n212EmployeeWorkingDays[0];
            A212EmployeeWorkingDays = AV10EmployeeWorkingDays;
            n212EmployeeWorkingDays = false;
            GXTC52 = 1;
            /* Using cursor P00C53 */
            pr_default.execute(1, new Object[] {n212EmployeeWorkingDays, A212EmployeeWorkingDays, A106EmployeeId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Employee");
            if ( GXTC52 == 1 )
            {
               context.CommitDataStores("prc_setemployeeworkingdays",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_setemployeeworkingdays",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00C52_A106EmployeeId = new long[1] ;
         P00C52_A212EmployeeWorkingDays = new string[] {""} ;
         P00C52_n212EmployeeWorkingDays = new bool[] {false} ;
         A212EmployeeWorkingDays = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_setemployeeworkingdays__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_setemployeeworkingdays__default(),
            new Object[][] {
                new Object[] {
               P00C52_A106EmployeeId, P00C52_A212EmployeeWorkingDays, P00C52_n212EmployeeWorkingDays
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTC52 ;
      private long AV9EmployeeId ;
      private long A106EmployeeId ;
      private bool n212EmployeeWorkingDays ;
      private string AV10EmployeeWorkingDays ;
      private string A212EmployeeWorkingDays ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00C52_A106EmployeeId ;
      private string[] P00C52_A212EmployeeWorkingDays ;
      private bool[] P00C52_n212EmployeeWorkingDays ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_setemployeeworkingdays__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class prc_setemployeeworkingdays__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00C52;
        prmP00C52 = new Object[] {
        new ParDef("AV9EmployeeId",GXType.Int64,10,0)
        };
        Object[] prmP00C53;
        prmP00C53 = new Object[] {
        new ParDef("EmployeeWorkingDays",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("EmployeeId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00C52", "SELECT EmployeeId, EmployeeWorkingDays FROM Employee WHERE EmployeeId = :AV9EmployeeId ORDER BY EmployeeId  FOR UPDATE OF Employee",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C52,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00C53", "SAVEPOINT gxupdate;UPDATE Employee SET EmployeeWorkingDays=:EmployeeWorkingDays  WHERE EmployeeId = :EmployeeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00C53)
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
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
     }
  }

}

}
