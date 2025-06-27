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
   public class getloggedinemployeename : GXProcedure
   {
      public getloggedinemployeename( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getloggedinemployeename( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_employeename )
      {
         this.AV8employeename = "" ;
         initialize();
         ExecuteImpl();
         aP0_employeename=this.AV8employeename;
      }

      public string executeUdp( )
      {
         execute(out aP0_employeename);
         return AV8employeename ;
      }

      public void executeSubmit( out string aP0_employeename )
      {
         this.AV8employeename = "" ;
         SubmitImpl();
         aP0_employeename=this.AV8employeename;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_int1 = AV9Loggedinemployee;
         new getloggedinemployeeid(context ).execute( out  GXt_int1) ;
         AV9Loggedinemployee = (short)(GXt_int1);
         /* Using cursor P00BA2 */
         pr_default.execute(0, new Object[] {AV9Loggedinemployee});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00BA2_A106EmployeeId[0];
            A148EmployeeName = P00BA2_A148EmployeeName[0];
            AV8employeename = A148EmployeeName;
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
         AV8employeename = "";
         P00BA2_A106EmployeeId = new long[1] ;
         P00BA2_A148EmployeeName = new string[] {""} ;
         A148EmployeeName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getloggedinemployeename__default(),
            new Object[][] {
                new Object[] {
               P00BA2_A106EmployeeId, P00BA2_A148EmployeeName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9Loggedinemployee ;
      private long GXt_int1 ;
      private long A106EmployeeId ;
      private string AV8employeename ;
      private string A148EmployeeName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00BA2_A106EmployeeId ;
      private string[] P00BA2_A148EmployeeName ;
      private string aP0_employeename ;
   }

   public class getloggedinemployeename__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BA2;
          prmP00BA2 = new Object[] {
          new ParDef("AV9Loggedinemployee",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BA2", "SELECT EmployeeId, EmployeeName FROM Employee WHERE EmployeeId = :AV9Loggedinemployee ORDER BY EmployeeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BA2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
