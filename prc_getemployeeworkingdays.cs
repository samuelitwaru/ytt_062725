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
   public class prc_getemployeeworkingdays : GXProcedure
   {
      public prc_getemployeeworkingdays( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getemployeeworkingdays( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out string aP1_EmployeeWorkingDays )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV10EmployeeWorkingDays = "" ;
         initialize();
         ExecuteImpl();
         aP1_EmployeeWorkingDays=this.AV10EmployeeWorkingDays;
      }

      public string executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_EmployeeWorkingDays);
         return AV10EmployeeWorkingDays ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out string aP1_EmployeeWorkingDays )
      {
         this.AV9EmployeeId = aP0_EmployeeId;
         this.AV10EmployeeWorkingDays = "" ;
         SubmitImpl();
         aP1_EmployeeWorkingDays=this.AV10EmployeeWorkingDays;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new logtofile(context ).execute(  "GETTING >>"+StringUtil.Str( (decimal)(AV9EmployeeId), 10, 0)) ;
         /* Using cursor P00C62 */
         pr_default.execute(0, new Object[] {AV9EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00C62_A106EmployeeId[0];
            A212EmployeeWorkingDays = P00C62_A212EmployeeWorkingDays[0];
            n212EmployeeWorkingDays = P00C62_n212EmployeeWorkingDays[0];
            AV10EmployeeWorkingDays = A212EmployeeWorkingDays;
            new logtofile(context ).execute(  "&EmployeeWorkingDays"+AV10EmployeeWorkingDays) ;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         new logtofile(context ).execute(  "&EmployeeWorkingDays"+AV10EmployeeWorkingDays) ;
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
         AV10EmployeeWorkingDays = "";
         P00C62_A106EmployeeId = new long[1] ;
         P00C62_A212EmployeeWorkingDays = new string[] {""} ;
         P00C62_n212EmployeeWorkingDays = new bool[] {false} ;
         A212EmployeeWorkingDays = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getemployeeworkingdays__default(),
            new Object[][] {
                new Object[] {
               P00C62_A106EmployeeId, P00C62_A212EmployeeWorkingDays, P00C62_n212EmployeeWorkingDays
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9EmployeeId ;
      private long A106EmployeeId ;
      private bool n212EmployeeWorkingDays ;
      private string AV10EmployeeWorkingDays ;
      private string A212EmployeeWorkingDays ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00C62_A106EmployeeId ;
      private string[] P00C62_A212EmployeeWorkingDays ;
      private bool[] P00C62_n212EmployeeWorkingDays ;
      private string aP1_EmployeeWorkingDays ;
   }

   public class prc_getemployeeworkingdays__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00C62;
          prmP00C62 = new Object[] {
          new ParDef("AV9EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C62", "SELECT EmployeeId, EmployeeWorkingDays FROM Employee WHERE EmployeeId = :AV9EmployeeId ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C62,1, GxCacheFrequency.OFF ,true,true )
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
