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
   public class getemployeelastloggedproject : GXProcedure
   {
      public getemployeelastloggedproject( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public getemployeelastloggedproject( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_ProjectId )
      {
         this.AV8ProjectId = 0 ;
         initialize();
         ExecuteImpl();
         aP0_ProjectId=this.AV8ProjectId;
      }

      public long executeUdp( )
      {
         execute(out aP0_ProjectId);
         return AV8ProjectId ;
      }

      public void executeSubmit( out long aP0_ProjectId )
      {
         this.AV8ProjectId = 0 ;
         SubmitImpl();
         aP0_ProjectId=this.AV8ProjectId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Udparg1 = new getloggedinemployeeid(context).executeUdp( );
         /* Using cursor P00752 */
         pr_default.execute(0, new Object[] {AV10Udparg1});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106EmployeeId = P00752_A106EmployeeId[0];
            A102ProjectId = P00752_A102ProjectId[0];
            A118WorkHourLogId = P00752_A118WorkHourLogId[0];
            AV8ProjectId = A102ProjectId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         P00752_A106EmployeeId = new long[1] ;
         P00752_A102ProjectId = new long[1] ;
         P00752_A118WorkHourLogId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getemployeelastloggedproject__default(),
            new Object[][] {
                new Object[] {
               P00752_A106EmployeeId, P00752_A102ProjectId, P00752_A118WorkHourLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8ProjectId ;
      private long AV10Udparg1 ;
      private long A106EmployeeId ;
      private long A102ProjectId ;
      private long A118WorkHourLogId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00752_A106EmployeeId ;
      private long[] P00752_A102ProjectId ;
      private long[] P00752_A118WorkHourLogId ;
      private long aP0_ProjectId ;
   }

   public class getemployeelastloggedproject__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00752;
          prmP00752 = new Object[] {
          new ParDef("AV10Udparg1",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00752", "SELECT EmployeeId, ProjectId, WorkHourLogId FROM WorkHourLog WHERE EmployeeId = :AV10Udparg1 ORDER BY WorkHourLogId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00752,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
