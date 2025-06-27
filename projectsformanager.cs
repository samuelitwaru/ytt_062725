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
   public class projectsformanager : GXProcedure
   {
      public projectsformanager( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public projectsformanager( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmployeeId ,
                           out GxSimpleCollection<long> aP1_projectIds )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9projectIds = new GxSimpleCollection<long>() ;
         initialize();
         ExecuteImpl();
         aP1_projectIds=this.AV9projectIds;
      }

      public GxSimpleCollection<long> executeUdp( long aP0_EmployeeId )
      {
         execute(aP0_EmployeeId, out aP1_projectIds);
         return AV9projectIds ;
      }

      public void executeSubmit( long aP0_EmployeeId ,
                                 out GxSimpleCollection<long> aP1_projectIds )
      {
         this.AV8EmployeeId = aP0_EmployeeId;
         this.AV9projectIds = new GxSimpleCollection<long>() ;
         SubmitImpl();
         aP1_projectIds=this.AV9projectIds;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10GXLvl1 = 0;
         /* Using cursor P00AK2 */
         pr_default.execute(0, new Object[] {AV8EmployeeId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A162ProjectManagerId = P00AK2_A162ProjectManagerId[0];
            n162ProjectManagerId = P00AK2_n162ProjectManagerId[0];
            A102ProjectId = P00AK2_A102ProjectId[0];
            AV10GXLvl1 = 1;
            AV9projectIds.Add(A102ProjectId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV10GXLvl1 == 0 )
         {
            AV9projectIds.Clear();
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
         AV9projectIds = new GxSimpleCollection<long>();
         P00AK2_A162ProjectManagerId = new long[1] ;
         P00AK2_n162ProjectManagerId = new bool[] {false} ;
         P00AK2_A102ProjectId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.projectsformanager__default(),
            new Object[][] {
                new Object[] {
               P00AK2_A162ProjectManagerId, P00AK2_n162ProjectManagerId, P00AK2_A102ProjectId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10GXLvl1 ;
      private long AV8EmployeeId ;
      private long A162ProjectManagerId ;
      private long A102ProjectId ;
      private bool n162ProjectManagerId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV9projectIds ;
      private IDataStoreProvider pr_default ;
      private long[] P00AK2_A162ProjectManagerId ;
      private bool[] P00AK2_n162ProjectManagerId ;
      private long[] P00AK2_A102ProjectId ;
      private GxSimpleCollection<long> aP1_projectIds ;
   }

   public class projectsformanager__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AK2;
          prmP00AK2 = new Object[] {
          new ParDef("AV8EmployeeId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AK2", "SELECT ProjectManagerId, ProjectId FROM Project WHERE ProjectManagerId = :AV8EmployeeId ORDER BY ProjectManagerId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AK2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
